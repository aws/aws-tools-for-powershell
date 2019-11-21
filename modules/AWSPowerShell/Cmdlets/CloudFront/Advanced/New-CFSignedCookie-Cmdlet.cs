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
using System.IO;
using System.Management.Automation;
using Amazon.CloudFront;
using Amazon.PowerShell.Common;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Creates signed cookies that grants universal access to private content until a given date (using a canned policy) 
    /// or tailored access to private content based on an access time window and ip range.
    /// </summary>
    [Cmdlet("New", "CFSignedCookie", DefaultParameterSetName = CannedPolicyParameterSet)]
    [OutputType(typeof(CookiesForCannedPolicy), typeof(CookiesForCustomPolicy))]
    [AWSCmdlet("Creates signed cookies that grants universal access to private content until a given date (using a canned policy)" + 
               " or tailored access to private content based on an access time window and ip range.")]
    [AWSCmdletOutput("Amazon.CloudFront.CookiesForCannedPolicy",
        "This cmdlet returns an Amazon.CloudFront.CookiesForCannedPolicy object containing signed cookies to a resource using a canned policy.")]
    [AWSCmdletOutput("Amazon.CloudFront.CookiesForCustomPolicy",
        "This cmdlet returns an Amazon.CloudFront.CookiesForCustomPolicy object containing signed cookies to a resource using a custom policy.")]
    [AWSClientCmdlet("Amazon CloudFront", "CF", null, "CloudFront")]
    public class NewCFSignedCookieCmdlet : BaseCmdlet
    {
        private const string CannedPolicyParameterSet = "CannedPolicy";
        private const string CustomPolicyParameterSet = "CustomPolicy";

        #region Parameter ResourceUri
        /// <summary>
        /// The URL or path that uniquely identifies a resource within a
        /// distribution. For standard distributions the resource URL will
        /// be <i>"http://" + distributionName + "/" + path</i>
        /// (may also include URL parameters. For distributions with the
        /// HTTPS required protocol, the resource URL must start with
        /// <i>"https://"</i>. RTMP resources do not take the form of a
        /// URL, and instead the resource path is nothing but the stream's
        /// name.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName=CannedPolicyParameterSet)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName=CustomPolicyParameterSet)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Uri ResourceUri { get; set; }
        #endregion

        #region Parameter KeyPairId
        /// <summary>
        /// The key pair id corresponding to the private key file given.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName=CannedPolicyParameterSet)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName=CustomPolicyParameterSet)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String KeyPairId { get; set; }
        #endregion

        #region Parameter PrivateKeyFile
        /// <summary>
        /// The private key file. RSA private key (.pem) are supported.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName=CannedPolicyParameterSet)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName=CustomPolicyParameterSet)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PrivateKeyFile { get; set; }
        #endregion

        #region Parameter ExpiresOn
        /// <summary>
        /// The expiration date till which content can be accessed using the generated cookies.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName=CannedPolicyParameterSet)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName=CustomPolicyParameterSet)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime ExpiresOn { get; set; }
        #endregion

        #region Parameter ActiveFrom
        /// <summary>
        /// The date from which content can be accessed using the generated cookies.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = CustomPolicyParameterSet)]
        public System.DateTime ActiveFrom { get; set; }
        #endregion

        #region Parameter IpRange
        /// <summary>
        /// The allowed IP address range of the client making the GET request, in CIDR form (e.g. 192.168.0.1/24).
        ///  If not specified, a CIDR of 0.0.0.0/0 (i.e. no IP restriction) is used.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = CustomPolicyParameterSet)]
        public System.String IpRange { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!File.Exists(PrivateKeyFile))
                ThrowArgumentError("The private key file does not exist", PrivateKeyFile);

            CmdletOutput output;
            if (ParameterSetName.Equals(CustomPolicyParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var cookies = CreateSignedCookiesForCustomPolicy();
                output = new CmdletOutput
                {
                    PipelineOutput = cookies
                };
            }
            else
            {
                var cookies = CreateSignedCookiesForCannedPolicy();
                output = new CmdletOutput
                {
                    PipelineOutput = cookies
                };
            }

            ProcessOutput(output);
        }

        private CookiesForCannedPolicy CreateSignedCookiesForCannedPolicy()
        {
            var privateKeyFileInfo = new FileInfo(PrivateKeyFile);

            return AmazonCloudFrontCookieSigner.GetCookiesForCannedPolicy(ResourceUri.ToString(), 
                                                                          KeyPairId, 
                                                                          privateKeyFileInfo, 
                                                                          ExpiresOn);
        }

        private CookiesForCustomPolicy CreateSignedCookiesForCustomPolicy()
        {
            // coreclr StreamReader does not have ctor that takes filename
            using (var fs = File.OpenRead(PrivateKeyFile))
            using (var reader = new StreamReader(fs))
            {
                return AmazonCloudFrontCookieSigner.GetCookiesForCustomPolicy(ResourceUri.ToString(),
                                                                                reader,
                                                                                KeyPairId,
                                                                                ExpiresOn,
                                                                                ActiveFrom,
                                                                                IpRange);
            }
        }
    }
}
