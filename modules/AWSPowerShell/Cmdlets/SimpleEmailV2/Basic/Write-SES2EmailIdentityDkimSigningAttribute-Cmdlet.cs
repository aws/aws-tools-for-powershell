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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Used to configure or change the DKIM authentication settings for an email domain identity.
    /// You can use this operation to do any of the following:
    /// 
    ///  <ul><li><para>
    /// Update the signing attributes for an identity that uses Bring Your Own DKIM (BYODKIM).
    /// </para></li><li><para>
    /// Update the key length that should be used for Easy DKIM.
    /// </para></li><li><para>
    /// Change from using no DKIM authentication to using Easy DKIM.
    /// </para></li><li><para>
    /// Change from using no DKIM authentication to using BYODKIM.
    /// </para></li><li><para>
    /// Change from using Easy DKIM to using BYODKIM.
    /// </para></li><li><para>
    /// Change from using BYODKIM to using Easy DKIM.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Write", "SES2EmailIdentityDkimSigningAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesResponse")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) PutEmailIdentityDkimSigningAttributes API operation.", Operation = new[] {"PutEmailIdentityDkimSigningAttributes"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesResponse))]
    [AWSCmdletOutput("Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesResponse",
        "This cmdlet returns an Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesResponse object containing multiple properties."
    )]
    public partial class WriteSES2EmailIdentityDkimSigningAttributeCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SigningAttributes_DomainSigningAttributesOrigin
        /// <summary>
        /// <para>
        /// <para>The attribute to use for configuring DKIM for the identity depends on the operation:
        /// </para><ol><li><para>For <c>PutEmailIdentityDkimSigningAttributes</c>: </para><ul><li><para>None of the values are allowed - use the <a href="https://docs.aws.amazon.com/ses/latest/APIReference-V2/API_PutEmailIdentityDkimSigningAttributes.html#SES-PutEmailIdentityDkimSigningAttributes-request-SigningAttributesOrigin"><c>SigningAttributesOrigin</c></a> parameter instead </para></li></ul></li><li><para>For <c>CreateEmailIdentity</c> when replicating a parent identity's DKIM configuration:
        /// </para><ul><li><para>Allowed values: All values except <c>AWS_SES</c> and <c>EXTERNAL</c></para></li></ul></li></ol><ul><li><para><c>AWS_SES</c> – Configure DKIM for the identity by using Easy DKIM. </para></li><li><para><c>EXTERNAL</c> – Configure DKIM for the identity by using Bring Your Own DKIM (BYODKIM).
        /// </para></li><li><para><c>AWS_SES_AF_SOUTH_1</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in Africa (Cape Town) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_EU_NORTH_1</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in Europe (Stockholm) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_AP_SOUTH_1</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in Asia Pacific (Mumbai) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_EU_WEST_3</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in Europe (Paris) region using Deterministic Easy-DKIM (DEED). </para></li><li><para><c>AWS_SES_EU_WEST_2</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in Europe (London) region using Deterministic Easy-DKIM (DEED). </para></li><li><para><c>AWS_SES_EU_SOUTH_1</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in Europe (Milan) region using Deterministic Easy-DKIM (DEED). </para></li><li><para><c>AWS_SES_EU_WEST_1</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in Europe (Ireland) region using Deterministic Easy-DKIM (DEED). </para></li><li><para><c>AWS_SES_AP_NORTHEAST_3</c> – Configure DKIM for the identity by replicating from
        /// a parent identity in Asia Pacific (Osaka) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_AP_NORTHEAST_2</c> – Configure DKIM for the identity by replicating from
        /// a parent identity in Asia Pacific (Seoul) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_ME_SOUTH_1</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in Middle East (Bahrain) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_AP_NORTHEAST_1</c> – Configure DKIM for the identity by replicating from
        /// a parent identity in Asia Pacific (Tokyo) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_IL_CENTRAL_1</c> – Configure DKIM for the identity by replicating from
        /// a parent identity in Israel (Tel Aviv) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_SA_EAST_1</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in South America (São Paulo) region using Deterministic Easy-DKIM
        /// (DEED). </para></li><li><para><c>AWS_SES_CA_CENTRAL_1</c> – Configure DKIM for the identity by replicating from
        /// a parent identity in Canada (Central) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_AP_SOUTHEAST_1</c> – Configure DKIM for the identity by replicating from
        /// a parent identity in Asia Pacific (Singapore) region using Deterministic Easy-DKIM
        /// (DEED). </para></li><li><para><c>AWS_SES_AP_SOUTHEAST_2</c> – Configure DKIM for the identity by replicating from
        /// a parent identity in Asia Pacific (Sydney) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_AP_SOUTHEAST_3</c> – Configure DKIM for the identity by replicating from
        /// a parent identity in Asia Pacific (Jakarta) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_EU_CENTRAL_1</c> – Configure DKIM for the identity by replicating from
        /// a parent identity in Europe (Frankfurt) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_US_EAST_1</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in US East (N. Virginia) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_US_EAST_2</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in US East (Ohio) region using Deterministic Easy-DKIM (DEED). </para></li><li><para><c>AWS_SES_US_WEST_1</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in US West (N. California) region using Deterministic Easy-DKIM (DEED).
        /// </para></li><li><para><c>AWS_SES_US_WEST_2</c> – Configure DKIM for the identity by replicating from a
        /// parent identity in US West (Oregon) region using Deterministic Easy-DKIM (DEED). </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.DkimSigningAttributesOrigin")]
        public Amazon.SimpleEmailV2.DkimSigningAttributesOrigin SigningAttributes_DomainSigningAttributesOrigin { get; set; }
        #endregion
        
        #region Parameter SigningAttributes_DomainSigningPrivateKey
        /// <summary>
        /// <para>
        /// <para>[Bring Your Own DKIM] A private key that's used to generate a DKIM signature.</para><para>The private key must use 1024 or 2048-bit RSA encryption, and must be encoded using
        /// base64 encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SigningAttributes_DomainSigningPrivateKey { get; set; }
        #endregion
        
        #region Parameter SigningAttributes_DomainSigningSelector
        /// <summary>
        /// <para>
        /// <para>[Bring Your Own DKIM] A string that's used to identify a public key in the DNS configuration
        /// for a domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SigningAttributes_DomainSigningSelector { get; set; }
        #endregion
        
        #region Parameter EmailIdentity
        /// <summary>
        /// <para>
        /// <para>The email identity.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EmailIdentity { get; set; }
        #endregion
        
        #region Parameter SigningAttributes_NextSigningKeyLength
        /// <summary>
        /// <para>
        /// <para>[Easy DKIM] The key length of the future DKIM key pair to be generated. This can be
        /// changed at most once per day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.DkimSigningKeyLength")]
        public Amazon.SimpleEmailV2.DkimSigningKeyLength SigningAttributes_NextSigningKeyLength { get; set; }
        #endregion
        
        #region Parameter SigningAttributesOrigin
        /// <summary>
        /// <para>
        /// <para>The method to use to configure DKIM for the identity. There are the following possible
        /// values:</para><ul><li><para><c>AWS_SES</c> – Configure DKIM for the identity by using <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/easy-dkim.html">Easy
        /// DKIM</a>.</para></li><li><para><c>EXTERNAL</c> – Configure DKIM for the identity by using Bring Your Own DKIM (BYODKIM).</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.DkimSigningAttributesOrigin")]
        public Amazon.SimpleEmailV2.DkimSigningAttributesOrigin SigningAttributesOrigin { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EmailIdentity), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SES2EmailIdentityDkimSigningAttribute (PutEmailIdentityDkimSigningAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesResponse, WriteSES2EmailIdentityDkimSigningAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EmailIdentity = this.EmailIdentity;
            #if MODULAR
            if (this.EmailIdentity == null && ParameterWasBound(nameof(this.EmailIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SigningAttributes_DomainSigningAttributesOrigin = this.SigningAttributes_DomainSigningAttributesOrigin;
            context.SigningAttributes_DomainSigningPrivateKey = this.SigningAttributes_DomainSigningPrivateKey;
            context.SigningAttributes_DomainSigningSelector = this.SigningAttributes_DomainSigningSelector;
            context.SigningAttributes_NextSigningKeyLength = this.SigningAttributes_NextSigningKeyLength;
            context.SigningAttributesOrigin = this.SigningAttributesOrigin;
            #if MODULAR
            if (this.SigningAttributesOrigin == null && ParameterWasBound(nameof(this.SigningAttributesOrigin)))
            {
                WriteWarning("You are passing $null as a value for parameter SigningAttributesOrigin which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesRequest();
            
            if (cmdletContext.EmailIdentity != null)
            {
                request.EmailIdentity = cmdletContext.EmailIdentity;
            }
            
             // populate SigningAttributes
            var requestSigningAttributesIsNull = true;
            request.SigningAttributes = new Amazon.SimpleEmailV2.Model.DkimSigningAttributes();
            Amazon.SimpleEmailV2.DkimSigningAttributesOrigin requestSigningAttributes_signingAttributes_DomainSigningAttributesOrigin = null;
            if (cmdletContext.SigningAttributes_DomainSigningAttributesOrigin != null)
            {
                requestSigningAttributes_signingAttributes_DomainSigningAttributesOrigin = cmdletContext.SigningAttributes_DomainSigningAttributesOrigin;
            }
            if (requestSigningAttributes_signingAttributes_DomainSigningAttributesOrigin != null)
            {
                request.SigningAttributes.DomainSigningAttributesOrigin = requestSigningAttributes_signingAttributes_DomainSigningAttributesOrigin;
                requestSigningAttributesIsNull = false;
            }
            System.String requestSigningAttributes_signingAttributes_DomainSigningPrivateKey = null;
            if (cmdletContext.SigningAttributes_DomainSigningPrivateKey != null)
            {
                requestSigningAttributes_signingAttributes_DomainSigningPrivateKey = cmdletContext.SigningAttributes_DomainSigningPrivateKey;
            }
            if (requestSigningAttributes_signingAttributes_DomainSigningPrivateKey != null)
            {
                request.SigningAttributes.DomainSigningPrivateKey = requestSigningAttributes_signingAttributes_DomainSigningPrivateKey;
                requestSigningAttributesIsNull = false;
            }
            System.String requestSigningAttributes_signingAttributes_DomainSigningSelector = null;
            if (cmdletContext.SigningAttributes_DomainSigningSelector != null)
            {
                requestSigningAttributes_signingAttributes_DomainSigningSelector = cmdletContext.SigningAttributes_DomainSigningSelector;
            }
            if (requestSigningAttributes_signingAttributes_DomainSigningSelector != null)
            {
                request.SigningAttributes.DomainSigningSelector = requestSigningAttributes_signingAttributes_DomainSigningSelector;
                requestSigningAttributesIsNull = false;
            }
            Amazon.SimpleEmailV2.DkimSigningKeyLength requestSigningAttributes_signingAttributes_NextSigningKeyLength = null;
            if (cmdletContext.SigningAttributes_NextSigningKeyLength != null)
            {
                requestSigningAttributes_signingAttributes_NextSigningKeyLength = cmdletContext.SigningAttributes_NextSigningKeyLength;
            }
            if (requestSigningAttributes_signingAttributes_NextSigningKeyLength != null)
            {
                request.SigningAttributes.NextSigningKeyLength = requestSigningAttributes_signingAttributes_NextSigningKeyLength;
                requestSigningAttributesIsNull = false;
            }
             // determine if request.SigningAttributes should be set to null
            if (requestSigningAttributesIsNull)
            {
                request.SigningAttributes = null;
            }
            if (cmdletContext.SigningAttributesOrigin != null)
            {
                request.SigningAttributesOrigin = cmdletContext.SigningAttributesOrigin;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
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
        
        private Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "PutEmailIdentityDkimSigningAttributes");
            try
            {
                #if DESKTOP
                return client.PutEmailIdentityDkimSigningAttributes(request);
                #elif CORECLR
                return client.PutEmailIdentityDkimSigningAttributesAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String EmailIdentity { get; set; }
            public Amazon.SimpleEmailV2.DkimSigningAttributesOrigin SigningAttributes_DomainSigningAttributesOrigin { get; set; }
            public System.String SigningAttributes_DomainSigningPrivateKey { get; set; }
            public System.String SigningAttributes_DomainSigningSelector { get; set; }
            public Amazon.SimpleEmailV2.DkimSigningKeyLength SigningAttributes_NextSigningKeyLength { get; set; }
            public Amazon.SimpleEmailV2.DkimSigningAttributesOrigin SigningAttributesOrigin { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.PutEmailIdentityDkimSigningAttributesResponse, WriteSES2EmailIdentityDkimSigningAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
