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
using System.Threading;
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Starts the process of verifying an email identity. An <i>identity</i> is an email
    /// address or domain that you use when you send email. Before you can use an identity
    /// to send email, you first have to verify it. By verifying an identity, you demonstrate
    /// that you're the owner of the identity, and that you've given Amazon SES API v2 permission
    /// to send email from the identity.
    /// 
    ///  
    /// <para>
    /// When you verify an email address, Amazon SES sends an email to the address. Your email
    /// address is verified as soon as you follow the link in the verification email. 
    /// </para><para>
    /// When you verify a domain without specifying the <c>DkimSigningAttributes</c> object,
    /// this operation provides a set of DKIM tokens. You can convert these tokens into CNAME
    /// records, which you then add to the DNS configuration for your domain. Your domain
    /// is verified when Amazon SES detects these records in the DNS configuration for your
    /// domain. This verification method is known as <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/easy-dkim.html">Easy
    /// DKIM</a>.
    /// </para><para>
    /// Alternatively, you can perform the verification process by providing your own public-private
    /// key pair. This verification method is known as Bring Your Own DKIM (BYODKIM). To use
    /// BYODKIM, your call to the <c>CreateEmailIdentity</c> operation has to include the
    /// <c>DkimSigningAttributes</c> object. When you specify this object, you provide a selector
    /// (a component of the DNS record name that identifies the public key to use for DKIM
    /// authentication) and a private key.
    /// </para><para>
    /// When you verify a domain, this operation provides a set of DKIM tokens, which you
    /// can convert into CNAME tokens. You add these CNAME tokens to the DNS configuration
    /// for your domain. Your domain is verified when Amazon SES detects these records in
    /// the DNS configuration for your domain. For some DNS providers, it can take 72 hours
    /// or more to complete the domain verification process.
    /// </para><para>
    /// Additionally, you can associate an existing configuration set with the email identity
    /// that you're verifying.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SES2EmailIdentity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) CreateEmailIdentity API operation.", Operation = new[] {"CreateEmailIdentity"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse))]
    [AWSCmdletOutput("Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse",
        "This cmdlet returns an Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse object containing multiple properties."
    )]
    public partial class NewSES2EmailIdentityCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The configuration set to use by default when sending from this identity. Note that
        /// any configuration set defined in the email sending request takes precedence. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter DkimSigningAttributes_DomainSigningAttributesOrigin
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
        public Amazon.SimpleEmailV2.DkimSigningAttributesOrigin DkimSigningAttributes_DomainSigningAttributesOrigin { get; set; }
        #endregion
        
        #region Parameter DkimSigningAttributes_DomainSigningPrivateKey
        /// <summary>
        /// <para>
        /// <para>[Bring Your Own DKIM] A private key that's used to generate a DKIM signature.</para><para>The private key must use 1024 or 2048-bit RSA encryption, and must be encoded using
        /// base64 encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DkimSigningAttributes_DomainSigningPrivateKey { get; set; }
        #endregion
        
        #region Parameter DkimSigningAttributes_DomainSigningSelector
        /// <summary>
        /// <para>
        /// <para>[Bring Your Own DKIM] A string that's used to identify a public key in the DNS configuration
        /// for a domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DkimSigningAttributes_DomainSigningSelector { get; set; }
        #endregion
        
        #region Parameter EmailIdentity
        /// <summary>
        /// <para>
        /// <para>The email address or domain to verify.</para>
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
        
        #region Parameter DkimSigningAttributes_NextSigningKeyLength
        /// <summary>
        /// <para>
        /// <para>[Easy DKIM] The key length of the future DKIM key pair to be generated. This can be
        /// changed at most once per day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.DkimSigningKeyLength")]
        public Amazon.SimpleEmailV2.DkimSigningKeyLength DkimSigningAttributes_NextSigningKeyLength { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of objects that define the tags (keys and values) to associate with the email
        /// identity.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleEmailV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EmailIdentity), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SES2EmailIdentity (CreateEmailIdentity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse, NewSES2EmailIdentityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            context.DkimSigningAttributes_DomainSigningAttributesOrigin = this.DkimSigningAttributes_DomainSigningAttributesOrigin;
            context.DkimSigningAttributes_DomainSigningPrivateKey = this.DkimSigningAttributes_DomainSigningPrivateKey;
            context.DkimSigningAttributes_DomainSigningSelector = this.DkimSigningAttributes_DomainSigningSelector;
            context.DkimSigningAttributes_NextSigningKeyLength = this.DkimSigningAttributes_NextSigningKeyLength;
            context.EmailIdentity = this.EmailIdentity;
            #if MODULAR
            if (this.EmailIdentity == null && ParameterWasBound(nameof(this.EmailIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleEmailV2.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.SimpleEmailV2.Model.CreateEmailIdentityRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            
             // populate DkimSigningAttributes
            var requestDkimSigningAttributesIsNull = true;
            request.DkimSigningAttributes = new Amazon.SimpleEmailV2.Model.DkimSigningAttributes();
            Amazon.SimpleEmailV2.DkimSigningAttributesOrigin requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningAttributesOrigin = null;
            if (cmdletContext.DkimSigningAttributes_DomainSigningAttributesOrigin != null)
            {
                requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningAttributesOrigin = cmdletContext.DkimSigningAttributes_DomainSigningAttributesOrigin;
            }
            if (requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningAttributesOrigin != null)
            {
                request.DkimSigningAttributes.DomainSigningAttributesOrigin = requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningAttributesOrigin;
                requestDkimSigningAttributesIsNull = false;
            }
            System.String requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningPrivateKey = null;
            if (cmdletContext.DkimSigningAttributes_DomainSigningPrivateKey != null)
            {
                requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningPrivateKey = cmdletContext.DkimSigningAttributes_DomainSigningPrivateKey;
            }
            if (requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningPrivateKey != null)
            {
                request.DkimSigningAttributes.DomainSigningPrivateKey = requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningPrivateKey;
                requestDkimSigningAttributesIsNull = false;
            }
            System.String requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningSelector = null;
            if (cmdletContext.DkimSigningAttributes_DomainSigningSelector != null)
            {
                requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningSelector = cmdletContext.DkimSigningAttributes_DomainSigningSelector;
            }
            if (requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningSelector != null)
            {
                request.DkimSigningAttributes.DomainSigningSelector = requestDkimSigningAttributes_dkimSigningAttributes_DomainSigningSelector;
                requestDkimSigningAttributesIsNull = false;
            }
            Amazon.SimpleEmailV2.DkimSigningKeyLength requestDkimSigningAttributes_dkimSigningAttributes_NextSigningKeyLength = null;
            if (cmdletContext.DkimSigningAttributes_NextSigningKeyLength != null)
            {
                requestDkimSigningAttributes_dkimSigningAttributes_NextSigningKeyLength = cmdletContext.DkimSigningAttributes_NextSigningKeyLength;
            }
            if (requestDkimSigningAttributes_dkimSigningAttributes_NextSigningKeyLength != null)
            {
                request.DkimSigningAttributes.NextSigningKeyLength = requestDkimSigningAttributes_dkimSigningAttributes_NextSigningKeyLength;
                requestDkimSigningAttributesIsNull = false;
            }
             // determine if request.DkimSigningAttributes should be set to null
            if (requestDkimSigningAttributesIsNull)
            {
                request.DkimSigningAttributes = null;
            }
            if (cmdletContext.EmailIdentity != null)
            {
                request.EmailIdentity = cmdletContext.EmailIdentity;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.CreateEmailIdentityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "CreateEmailIdentity");
            try
            {
                return client.CreateEmailIdentityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public Amazon.SimpleEmailV2.DkimSigningAttributesOrigin DkimSigningAttributes_DomainSigningAttributesOrigin { get; set; }
            public System.String DkimSigningAttributes_DomainSigningPrivateKey { get; set; }
            public System.String DkimSigningAttributes_DomainSigningSelector { get; set; }
            public Amazon.SimpleEmailV2.DkimSigningKeyLength DkimSigningAttributes_NextSigningKeyLength { get; set; }
            public System.String EmailIdentity { get; set; }
            public List<Amazon.SimpleEmailV2.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse, NewSES2EmailIdentityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
