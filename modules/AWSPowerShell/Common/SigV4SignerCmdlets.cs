/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************/

using System;
using System.Collections;
using System.IO;
using System.Management.Automation;
using System.Net.Http;
using System.Text;
using Amazon.Runtime;
using Amazon.Runtime.Signing;

namespace Amazon.PowerShell.Common
{
    public abstract class SigV4SignerCmdletBase : AWSCommonArgumentsCmdlet
    {
        #region Parameter Uri
        /// <summary>
        /// The absolute URI of the request, including any query string.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public Uri Uri { get; set; }
        #endregion

        #region Parameter Method
        /// <summary>
        /// The HTTP method of the request. Defaults to GET.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateSet("DELETE", "GET", "HEAD", "OPTIONS", "PATCH", "POST", "PUT")]
        public string Method { get; set; } = "GET";
        #endregion

        #region Parameter Service
        /// <summary>
        /// The signing name of the target service, for example 'execute-api', 'lambda', 's3' or 'aoss'.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Service { get; set; }
        #endregion

        #region Parameter Header
        /// <summary>
        /// Additional headers to include in the signature. The host header is derived from the Uri.
        /// An 'x-amz-content-sha256' header with a precomputed payload hash is used as-is by the signer.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public IDictionary Header { get; set; }
        #endregion

        protected AWSSigV4Parameters BuildSigningParameters()
        {
            if (string.IsNullOrWhiteSpace(this.Service))
                ThrowArgumentError("Service must be specified.", this);

            // Resolve credentials and region like ServiceCmdlet does; anything left null is
            // resolved by the SDK's default chains inside the signer.
            var parameters = new AWSSigV4Parameters { Service = this.Service };

            if (this.TryGetCredentials(Host, out var awsPSCredentials, SessionState))
            {
                parameters.Credentials = awsPSCredentials.Credentials;
                WriteCredentialSourceDiagnostic(awsPSCredentials);
                SettingsStore.ThrowIfSsoLoginRequired(parameters.Credentials);
            }
            else
                WriteVerbose("Offloading credential resolution to .NET SDK.");

            this.TryGetRegion(useInstanceMetadata: true, out var region, out var regionSource, SessionState);
            if (region != null)
            {
                parameters.Region = region;
                WriteRegionSourceDiagnostic(regionSource, region.SystemName);
            }
            else
                WriteVerbose("Offloading region resolution to .NET SDK.");

            return parameters;
        }

        protected AWSSigningRequest BuildSigningRequest()
        {
            if (!this.Uri.IsAbsoluteUri)
                ThrowArgumentError("Uri must be an absolute URI.", this);

            var request = new AWSSigningRequest
            {
                HttpMethod = new HttpMethod(this.Method.ToUpperInvariant()),
                RequestUri = this.Uri
            };

            if (this.Header != null)
            {
                foreach (DictionaryEntry entry in this.Header)
                    request.Headers[entry.Key.ToString()] = entry.Value?.ToString() ?? string.Empty;
            }

            return request;
        }
    }

    public abstract class SigV4RequestSignerCmdletBase : SigV4SignerCmdletBase
    {
        #region Parameter Body
        /// <summary>
        /// The request payload as a string (UTF-8 encoded), byte array or seekable stream. The bytes sent must
        /// match exactly; on Windows PowerShell 5.1 pass non-ASCII payloads to Invoke-RestMethod as a byte array,
        /// or use Get-AWSSigV4SignedRequest.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public object Body { get; set; }
        #endregion

        #region Parameter UnsignedPayload
        /// <summary>
        /// Sign with 'UNSIGNED-PAYLOAD' instead of hashing the body. Requires HTTPS.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter UnsignedPayload { get; set; }
        #endregion

        protected Hashtable SignRequest(out AWSSigningRequest request)
        {
            var parameters = BuildSigningParameters();
            parameters.SignPayload = !this.UnsignedPayload.IsPresent;

            request = BuildSigningRequest();
            switch (this.Body is PSObject psObject ? psObject.BaseObject : this.Body)
            {
                case null: break;
                case string s: request.Content = Encoding.UTF8.GetBytes(s); break;
                case byte[] bytes: request.Content = bytes; break;
                case Stream stream: request.ContentStream = stream; break;
                default: ThrowArgumentError("Body must be a string, a byte array or a stream.", this.Body); break;
            }

            var headers = new Hashtable(StringComparer.OrdinalIgnoreCase);
            try
            {
                foreach (var header in AWSSigV4Signer.Sign(request, parameters).Headers)
                    headers[header.Key] = header.Value;
            }
            catch (Exception e)
            {
                ThrowError(e);
            }
            return headers;
        }
    }

    /// <summary>
    /// <para>
    /// Signs an HTTP request with AWS Signature Version 4 and returns the headers to add to it. Use this
    /// to call SigV4-protected endpoints that have no dedicated cmdlet, such as Amazon API Gateway APIs
    /// with IAM authorization or Lambda function URLs. To call the endpoint with Invoke-RestMethod or
    /// Invoke-WebRequest, Get-AWSSigV4SignedRequest returns the whole request as their parameters instead.
    /// </para>
    /// <para>
    /// All returned headers must be sent, and the request sent must match the signed Uri, Method,
    /// Header and Body exactly. Credentials and region are resolved as for any other cmdlet; if none
    /// are found, resolution is left to the AWS SDK for .NET default chain.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AWSSigV4Signature")]
    [AWSCmdlet("Signs an HTTP request with AWS Signature Version 4 and returns the headers to add to the request.")]
    [OutputType(typeof(Hashtable))]
    [AWSCmdletOutput("System.Collections.Hashtable",
        "The headers to add to the request: Authorization, X-Amz-Date and, when applicable, X-Amz-Content-SHA256 and X-Amz-Security-Token.")]
    public class GetSigV4SignatureCmdlet : SigV4RequestSignerCmdletBase
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            WriteObject(SignRequest(out _));
        }
    }

    /// <summary>
    /// <para>
    /// Signs an HTTP request with AWS Signature Version 4 and returns it as a hashtable of Invoke-RestMethod
    /// and Invoke-WebRequest parameters, to be passed with the splatting operator:
    /// <code>$request = Get-AWSSigV4SignedRequest -Uri $uri -Service execute-api; Invoke-RestMethod @request</code>
    /// </para>
    /// <para>
    /// The hashtable carries the signed Uri, Method, Headers (the signature headers merged with -Header) and,
    /// when a body was supplied, the exact Body bytes that were signed. On PowerShell 7 it also sets
    /// SkipHeaderValidation, which Invoke-RestMethod requires to accept the SigV4 Authorization header.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AWSSigV4SignedRequest")]
    [AWSCmdlet("Signs an HTTP request with AWS Signature Version 4 and returns it as a hashtable of Invoke-RestMethod or Invoke-WebRequest parameters.")]
    [OutputType(typeof(Hashtable))]
    [AWSCmdletOutput("System.Collections.Hashtable",
        "Invoke-RestMethod parameters: Uri, Method, Headers, Body (when supplied) and SkipHeaderValidation (PowerShell 7 only).")]
    public class GetSigV4SignedRequestCmdlet : SigV4RequestSignerCmdletBase
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var headers = SignRequest(out var request);
            if (this.Header != null)
            {
                foreach (DictionaryEntry entry in this.Header)
                {
                    var name = entry.Key.ToString();
                    var value = entry.Value?.ToString() ?? string.Empty;
                    if (!headers.ContainsKey(name))
                        headers[name] = value;
                    else if (!string.Equals((string)headers[name], value, StringComparison.Ordinal))
                        WriteWarning($"Header '{name}' was replaced by the value set by the signer.");
                }
            }

            var invokeParameters = new Hashtable(StringComparer.OrdinalIgnoreCase)
            {
                ["Uri"] = this.Uri,
                ["Method"] = request.HttpMethod.Method,
                ["Headers"] = headers
            };
            if (request.ContentStream != null)
                invokeParameters["Body"] = request.ContentStream;
            else if (request.Content != null)
                invokeParameters["Body"] = request.Content;

            // PowerShell 7 rejects the commas in the SigV4 Authorization header unless validation is skipped.
            // The switch does not exist on Windows PowerShell, which does not validate header values.
            if (string.Equals(SessionState.PSVariable.GetValue("PSEdition") as string, "Core", StringComparison.OrdinalIgnoreCase))
                invokeParameters["SkipHeaderValidation"] = true;

            WriteObject(invokeParameters);
        }
    }

    /// <summary>
    /// <para>
    /// Generates a pre-signed URL for an HTTP request using AWS Signature Version 4. The URL carries the
    /// signature in its query string and can be used until it expires without further authentication.
    /// </para>
    /// <para>
    /// The result is a hashtable with the URL under Uri and, under Headers, any headers passed via -Header;
    /// these are part of the signature and must be sent with the request. The hashtable can be passed to
    /// Invoke-RestMethod or Invoke-WebRequest as their parameters. A request body is not supported, and with temporary
    /// credentials the URL cannot outlive the credentials.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "AWSSigV4PreSignedURL")]
    [AWSCmdlet("Generates a pre-signed URL for an HTTP request using AWS Signature Version 4.")]
    [OutputType(typeof(Hashtable))]
    [AWSCmdletOutput("System.Collections.Hashtable", "Uri: the pre-signed URL. Headers: the signed headers that must be sent with the request.")]
    public class GetSigV4PreSignedURLCmdlet : SigV4SignerCmdletBase
    {
        #region Parameter Expire
        /// <summary>
        /// The date and time at which the URL expires, between one second and seven days from now. A value
        /// without timezone information is interpreted as local time.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("Expires")]
        public DateTime Expire { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var parameters = BuildSigningParameters();
            var request = BuildSigningRequest();

            // Same conversion as the S3 presigner: skew-corrected baseline, rounded to whole seconds. The
            // endpoint key must match the one the signer uses (Uri.ToString() of the authority, trailing slash).
            var endpoint = new Uri(this.Uri.GetLeftPart(UriPartial.Authority)).ToString();
            var baselineTime = CorrectClockSkew.GetCorrectedUtcNowForEndpoint(endpoint);
            var expiry = TimeSpan.FromSeconds(Convert.ToInt64((this.Expire.ToUniversalTime() - baselineTime).TotalSeconds));

            try
            {
                var result = AWSSigV4Signer.Presign(request, parameters, expiry);
                var headers = new Hashtable(StringComparer.OrdinalIgnoreCase);
                foreach (var header in result.SignedHeaders)
                    headers[header.Key] = header.Value;
                WriteObject(new Hashtable(StringComparer.OrdinalIgnoreCase)
                {
                    ["Uri"] = result.Uri.AbsoluteUri,
                    ["Headers"] = headers
                });
            }
            catch (Exception e)
            {
                ThrowError(e);
            }
        }
    }
}
