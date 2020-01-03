/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// When you verify a domain without specifying the <code>DkimSigningAttributes</code>
    /// object, this operation provides a set of DKIM tokens. You can convert these tokens
    /// into CNAME records, which you then add to the DNS configuration for your domain. Your
    /// domain is verified when Amazon SES detects these records in the DNS configuration
    /// for your domain. This verification method is known as <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/easy-dkim.html">Easy
    /// DKIM</a>.
    /// </para><para>
    /// Alternatively, you can perform the verification process by providing your own public-private
    /// key pair. This verification method is known as Bring Your Own DKIM (BYODKIM). To use
    /// BYODKIM, your call to the <code>CreateEmailIdentity</code> operation has to include
    /// the <code>DkimSigningAttributes</code> object. When you specify this object, you provide
    /// a selector (a component of the DNS record name that identifies the public key that
    /// you want to use for DKIM authentication) and a private key.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SES2EmailIdentity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) CreateEmailIdentity API operation.", Operation = new[] {"CreateEmailIdentity"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse))]
    [AWSCmdletOutput("Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse",
        "This cmdlet returns an Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSES2EmailIdentityCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        #region Parameter DkimSigningAttributes_DomainSigningPrivateKey
        /// <summary>
        /// <para>
        /// <para>A private key that's used to generate a DKIM signature.</para><para>The private key must use 1024-bit RSA encryption, and must be encoded using base64
        /// encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DkimSigningAttributes_DomainSigningPrivateKey { get; set; }
        #endregion
        
        #region Parameter DkimSigningAttributes_DomainSigningSelector
        /// <summary>
        /// <para>
        /// <para>A string that's used to identify a public key in the DNS configuration for a domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DkimSigningAttributes_DomainSigningSelector { get; set; }
        #endregion
        
        #region Parameter EmailIdentity
        /// <summary>
        /// <para>
        /// <para>The email address or domain that you want to verify.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of objects that define the tags (keys and values) that you want to associate
        /// with the email identity.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EmailIdentity parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EmailIdentity' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EmailIdentity' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EmailIdentity), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SES2EmailIdentity (CreateEmailIdentity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse, NewSES2EmailIdentityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EmailIdentity;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DkimSigningAttributes_DomainSigningPrivateKey = this.DkimSigningAttributes_DomainSigningPrivateKey;
            context.DkimSigningAttributes_DomainSigningSelector = this.DkimSigningAttributes_DomainSigningSelector;
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
            
            
             // populate DkimSigningAttributes
            var requestDkimSigningAttributesIsNull = true;
            request.DkimSigningAttributes = new Amazon.SimpleEmailV2.Model.DkimSigningAttributes();
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
                #if DESKTOP
                return client.CreateEmailIdentity(request);
                #elif CORECLR
                return client.CreateEmailIdentityAsync(request).GetAwaiter().GetResult();
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
            public System.String DkimSigningAttributes_DomainSigningPrivateKey { get; set; }
            public System.String DkimSigningAttributes_DomainSigningSelector { get; set; }
            public System.String EmailIdentity { get; set; }
            public List<Amazon.SimpleEmailV2.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.CreateEmailIdentityResponse, NewSES2EmailIdentityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
