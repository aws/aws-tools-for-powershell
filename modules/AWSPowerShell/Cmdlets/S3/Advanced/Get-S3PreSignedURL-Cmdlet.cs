/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <para>
    /// Create a signed URL allowing access to a resource that would usually require authentication.
    /// </para>
    /// <para>
    /// Note that you can pipe an Amazon.S3.Model.S3Object instance to this cmdlet and its members will be used to
    /// satisfy the BucketName, Key and optionally VersionId (if an S3ObjectVersion instance is supplied), parameters.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "S3PreSignedURL")]
    [OutputType("System.String")]
    [AWSCmdlet("Generates a pre-signed URL to an object in an Amazon S3 bucket.", Operation = new[] {"GetPreSignedURL"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a System.String object containing multiple properties. The object can be returned by specifying '-Select *'."
    )]
    public class GetS3PreSignedURLCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        protected override bool IsSensitiveRequest { get; set; } = true;

        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket to create a pre-signed url to, or containing the object.
        /// </para>
        ///  
        /// <para>
        /// When using this action with an access point, you must direct requests to the access
        /// point hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ResponseHeaderOverrides_CacheControl
        /// <summary>
        /// <para>
        /// CacheControl header value.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResponseHeaderOverrides_CacheControl { get; set; }
        #endregion
        
        #region Parameter ResponseHeaderOverrides_ContentDisposition
        /// <summary>
        /// <para>
        /// Specifies presentational information for the object. For more information, see <a
        /// href="https://www.rfc-editor.org/rfc/rfc6266#section-4">https://www.rfc-editor.org/rfc/rfc6266#section-4</a>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResponseHeaderOverrides_ContentDisposition { get; set; }
        #endregion
        
        #region Parameter ResponseHeaderOverrides_ContentEncoding
        /// <summary>
        /// <para>
        /// Specifies what content encodings have been applied to the object and thus what decoding
        /// mechanisms must be applied to obtain the media-type referenced by the Content-Type
        /// header field. For more information, see <a href="https://www.rfc-editor.org/rfc/rfc9110.html#field.content-encoding">https://www.rfc-editor.org/rfc/rfc9110.html#field.content-encoding</a>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResponseHeaderOverrides_ContentEncoding { get; set; }
        #endregion
        
        #region Parameter ResponseHeaderOverrides_ContentLanguage
        /// <summary>
        /// <para>
        /// ContentLanguage header value.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResponseHeaderOverrides_ContentLanguage { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// A standard MIME type describing the format of the contents. For more information,
        /// see <a href="https://www.rfc-editor.org/rfc/rfc9110.html#name-content-type">https://www.rfc-editor.org/rfc/rfc9110.html#name-content-type</a>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter ResponseHeaderOverrides_ContentType
        /// <summary>
        /// <para>
        /// A standard MIME type describing the format of the object data.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResponseHeaderOverrides_ContentType { get; set; }
        #endregion
        
        #region Parameter Expire
        /// <summary>
        /// <para>
        /// The expiry date and time for the pre-signed url.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Expires")]
        public System.DateTime Expire { get; set; }
        #endregion
        
        #region Parameter ResponseHeaderOverrides_Expire
        /// <summary>
        /// <para>
        /// Expiry header value.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResponseHeaderOverrides_Expires")]
        public System.String ResponseHeaderOverrides_Expire { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// The key to the object for which a pre-signed url should be created.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// The requested protocol (http/https) for the pre-signed url.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.S3.Protocol Protocol { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerMethod
        /// <summary>
        /// <para>
        /// The Server-side encryption algorithm to be used with the customer provided key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionKeyManagementServiceKeyId
        /// <summary>
        /// <para>
        /// The id of the AWS Key Management Service key that Amazon S3 should use to encrypt and decrypt the object.
        /// If a key id is not specified, the default key will be used for encryption and decryption.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServerSideEncryptionKeyManagementServiceKeyId { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionMethod
        /// <summary>
        /// <para>
        /// Specifies the encryption used on the server to store the content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionMethod")]
        public Amazon.S3.ServerSideEncryptionMethod ServerSideEncryptionMethod { get; set; }
        #endregion
        
        #region Parameter Verb
        /// <summary>
        /// <para>
        /// The verb for the pre-signed url. 
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.S3.HttpVerb Verb { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// Version id for the object that the pre-signed url will reference. If not set,
        /// the url will reference the latest version of the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName=true)]
        public System.String VersionId { get; set; }
        #endregion

        #region Parameter RequestorPay
        /// <summary>
        /// Confirms that the requester knows that they will be charged for the request.
        /// Bucket owners do not need to specify this parameter.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter RequestorPay { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();

            context.BucketName = this.BucketName;
            context.Key = this.Key;
            context.ContentType = this.ContentType;
            if (ParameterWasBound("Expire"))
                context.Expires = this.Expire;
            if (ParameterWasBound("Protocol"))
                context.Protocol = this.Protocol;
            if (ParameterWasBound("Verb"))
                context.Verb = this.Verb;
            context.VersionId = this.VersionId;
            context.ServerSideEncryptionMethod = this.ServerSideEncryptionMethod;
            context.ServerSideEncryptionKeyManagementServiceKeyId = this.ServerSideEncryptionKeyManagementServiceKeyId;
            context.ServerSideEncryptionCustomerMethod = this.ServerSideEncryptionCustomerMethod;
            context.ResponseHeaderOverrides_ContentType = this.ResponseHeaderOverrides_ContentType;
            context.ResponseHeaderOverrides_ContentLanguage = this.ResponseHeaderOverrides_ContentLanguage;
            context.ResponseHeaderOverrides_Expires = this.ResponseHeaderOverrides_Expire;
            context.ResponseHeaderOverrides_CacheControl = this.ResponseHeaderOverrides_CacheControl;
            context.ResponseHeaderOverrides_ContentDisposition = this.ResponseHeaderOverrides_ContentDisposition;
            context.ResponseHeaderOverrides_ContentEncoding = this.ResponseHeaderOverrides_ContentEncoding;
            context.RequestorPays = this.RequestorPay;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.S3.Model.GetPreSignedUrlRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
            }
            if (cmdletContext.Expires != null)
            {
                request.Expires = cmdletContext.Expires.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol.Value;
            }
            if (cmdletContext.Verb != null)
            {
                request.Verb = cmdletContext.Verb.Value;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
            }
            if (cmdletContext.ServerSideEncryptionMethod != null)
            {
                request.ServerSideEncryptionMethod = cmdletContext.ServerSideEncryptionMethod;
            }
            if (cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId != null)
            {
                request.ServerSideEncryptionKeyManagementServiceKeyId = cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId;
            }
            if (cmdletContext.ServerSideEncryptionCustomerMethod != null)
            {
                request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            }
            
             // populate ResponseHeaderOverrides
            bool requestResponseHeaderOverridesIsNull = true;
            request.ResponseHeaderOverrides = new Amazon.S3.Model.ResponseHeaderOverrides();
            System.String requestResponseHeaderOverrides_responseHeaderOverrides_ContentType = null;
            if (cmdletContext.ResponseHeaderOverrides_ContentType != null)
            {
                requestResponseHeaderOverrides_responseHeaderOverrides_ContentType = cmdletContext.ResponseHeaderOverrides_ContentType;
            }
            if (requestResponseHeaderOverrides_responseHeaderOverrides_ContentType != null)
            {
                request.ResponseHeaderOverrides.ContentType = requestResponseHeaderOverrides_responseHeaderOverrides_ContentType;
                requestResponseHeaderOverridesIsNull = false;
            }
            System.String requestResponseHeaderOverrides_responseHeaderOverrides_ContentLanguage = null;
            if (cmdletContext.ResponseHeaderOverrides_ContentLanguage != null)
            {
                requestResponseHeaderOverrides_responseHeaderOverrides_ContentLanguage = cmdletContext.ResponseHeaderOverrides_ContentLanguage;
            }
            if (requestResponseHeaderOverrides_responseHeaderOverrides_ContentLanguage != null)
            {
                request.ResponseHeaderOverrides.ContentLanguage = requestResponseHeaderOverrides_responseHeaderOverrides_ContentLanguage;
                requestResponseHeaderOverridesIsNull = false;
            }
            System.String requestResponseHeaderOverrides_responseHeaderOverrides_Expire = null;
            if (cmdletContext.ResponseHeaderOverrides_Expires != null)
            {
                requestResponseHeaderOverrides_responseHeaderOverrides_Expire = cmdletContext.ResponseHeaderOverrides_Expires;
            }
            if (requestResponseHeaderOverrides_responseHeaderOverrides_Expire != null)
            {
                request.ResponseHeaderOverrides.Expires = requestResponseHeaderOverrides_responseHeaderOverrides_Expire;
                requestResponseHeaderOverridesIsNull = false;
            }
            System.String requestResponseHeaderOverrides_responseHeaderOverrides_CacheControl = null;
            if (cmdletContext.ResponseHeaderOverrides_CacheControl != null)
            {
                requestResponseHeaderOverrides_responseHeaderOverrides_CacheControl = cmdletContext.ResponseHeaderOverrides_CacheControl;
            }
            if (requestResponseHeaderOverrides_responseHeaderOverrides_CacheControl != null)
            {
                request.ResponseHeaderOverrides.CacheControl = requestResponseHeaderOverrides_responseHeaderOverrides_CacheControl;
                requestResponseHeaderOverridesIsNull = false;
            }
            System.String requestResponseHeaderOverrides_responseHeaderOverrides_ContentDisposition = null;
            if (cmdletContext.ResponseHeaderOverrides_ContentDisposition != null)
            {
                requestResponseHeaderOverrides_responseHeaderOverrides_ContentDisposition = cmdletContext.ResponseHeaderOverrides_ContentDisposition;
            }
            if (requestResponseHeaderOverrides_responseHeaderOverrides_ContentDisposition != null)
            {
                request.ResponseHeaderOverrides.ContentDisposition = requestResponseHeaderOverrides_responseHeaderOverrides_ContentDisposition;
                requestResponseHeaderOverridesIsNull = false;
            }
            System.String requestResponseHeaderOverrides_responseHeaderOverrides_ContentEncoding = null;
            if (cmdletContext.ResponseHeaderOverrides_ContentEncoding != null)
            {
                requestResponseHeaderOverrides_responseHeaderOverrides_ContentEncoding = cmdletContext.ResponseHeaderOverrides_ContentEncoding;
            }
            if (requestResponseHeaderOverrides_responseHeaderOverrides_ContentEncoding != null)
            {
                request.ResponseHeaderOverrides.ContentEncoding = requestResponseHeaderOverrides_responseHeaderOverrides_ContentEncoding;
                requestResponseHeaderOverridesIsNull = false;
            }
             // determine if request.ResponseHeaderOverrides should be set to null
            if (requestResponseHeaderOverridesIsNull)
            {
                request.ResponseHeaderOverrides = null;
            }
            if (cmdletContext.RequestorPays)
            {
                request.RequestPayer = RequestPayer.Requester;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private static System.String CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.GetPreSignedUrlRequest request)
        {
            return client.GetPreSignedURL(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String BucketName { get; set; }
            public System.String Key { get; set; }
            public System.String ContentType { get; set; }
            public System.DateTime? Expires { get; set; }
            public Amazon.S3.Protocol? Protocol { get; set; }
            public Amazon.S3.HttpVerb? Verb { get; set; }
            public System.String VersionId { get; set; }
            public Amazon.S3.ServerSideEncryptionMethod ServerSideEncryptionMethod { get; set; }
            public System.String ServerSideEncryptionKeyManagementServiceKeyId { get; set; }
            public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
            public System.String ResponseHeaderOverrides_ContentType { get; set; }
            public System.String ResponseHeaderOverrides_ContentLanguage { get; set; }
            public System.String ResponseHeaderOverrides_Expires { get; set; }
            public System.String ResponseHeaderOverrides_CacheControl { get; set; }
            public System.String ResponseHeaderOverrides_ContentDisposition { get; set; }
            public System.String ResponseHeaderOverrides_ContentEncoding { get; set; }
            public bool RequestorPays { get; set; }
        }
        
    }
}
