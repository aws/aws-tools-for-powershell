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
    /// Update your Amazon SES account details.
    /// </summary>
    [Cmdlet("Write", "SES2AccountDetail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) PutAccountDetails API operation.", Operation = new[] {"PutAccountDetails"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.PutAccountDetailsResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.PutAccountDetailsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.PutAccountDetailsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSES2AccountDetailCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter AdditionalContactEmailAddress
        /// <summary>
        /// <para>
        /// <para>Additional email addresses that you would like to be notified regarding Amazon SES
        /// matters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalContactEmailAddresses")]
        public System.String[] AdditionalContactEmailAddress { get; set; }
        #endregion
        
        #region Parameter ContactLanguage
        /// <summary>
        /// <para>
        /// <para>The language you would prefer to be contacted with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.ContactLanguage")]
        public Amazon.SimpleEmailV2.ContactLanguage ContactLanguage { get; set; }
        #endregion
        
        #region Parameter MailType
        /// <summary>
        /// <para>
        /// <para>The type of email your account will send.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.MailType")]
        public Amazon.SimpleEmailV2.MailType MailType { get; set; }
        #endregion
        
        #region Parameter ProductionAccessEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether or not your account should have production access in the current
        /// Amazon Web Services Region.</para><para>If the value is <code>false</code>, then your account is in the <i>sandbox</i>. When
        /// your account is in the sandbox, you can only send email to verified identities. Additionally,
        /// the maximum number of emails you can send in a 24-hour period (your sending quota)
        /// is 200, and the maximum number of emails you can send per second (your maximum sending
        /// rate) is 1.</para><para>If the value is <code>true</code>, then your account has production access. When your
        /// account has production access, you can send email to any address. The sending quota
        /// and maximum sending rate for your account vary based on your specific use case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ProductionAccessEnabled { get; set; }
        #endregion
        
        #region Parameter UseCaseDescription
        /// <summary>
        /// <para>
        /// <para>A description of the types of email that you plan to send.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String UseCaseDescription { get; set; }
        #endregion
        
        #region Parameter WebsiteURL
        /// <summary>
        /// <para>
        /// <para>The URL of your website. This information helps us better understand the type of content
        /// that you plan to send.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String WebsiteURL { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.PutAccountDetailsResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SES2AccountDetail (PutAccountDetails)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.PutAccountDetailsResponse, WriteSES2AccountDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalContactEmailAddress != null)
            {
                context.AdditionalContactEmailAddress = new List<System.String>(this.AdditionalContactEmailAddress);
            }
            context.ContactLanguage = this.ContactLanguage;
            context.MailType = this.MailType;
            #if MODULAR
            if (this.MailType == null && ParameterWasBound(nameof(this.MailType)))
            {
                WriteWarning("You are passing $null as a value for parameter MailType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProductionAccessEnabled = this.ProductionAccessEnabled;
            context.UseCaseDescription = this.UseCaseDescription;
            #if MODULAR
            if (this.UseCaseDescription == null && ParameterWasBound(nameof(this.UseCaseDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter UseCaseDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WebsiteURL = this.WebsiteURL;
            #if MODULAR
            if (this.WebsiteURL == null && ParameterWasBound(nameof(this.WebsiteURL)))
            {
                WriteWarning("You are passing $null as a value for parameter WebsiteURL which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmailV2.Model.PutAccountDetailsRequest();
            
            if (cmdletContext.AdditionalContactEmailAddress != null)
            {
                request.AdditionalContactEmailAddresses = cmdletContext.AdditionalContactEmailAddress;
            }
            if (cmdletContext.ContactLanguage != null)
            {
                request.ContactLanguage = cmdletContext.ContactLanguage;
            }
            if (cmdletContext.MailType != null)
            {
                request.MailType = cmdletContext.MailType;
            }
            if (cmdletContext.ProductionAccessEnabled != null)
            {
                request.ProductionAccessEnabled = cmdletContext.ProductionAccessEnabled.Value;
            }
            if (cmdletContext.UseCaseDescription != null)
            {
                request.UseCaseDescription = cmdletContext.UseCaseDescription;
            }
            if (cmdletContext.WebsiteURL != null)
            {
                request.WebsiteURL = cmdletContext.WebsiteURL;
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
        
        private Amazon.SimpleEmailV2.Model.PutAccountDetailsResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.PutAccountDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "PutAccountDetails");
            try
            {
                #if DESKTOP
                return client.PutAccountDetails(request);
                #elif CORECLR
                return client.PutAccountDetailsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AdditionalContactEmailAddress { get; set; }
            public Amazon.SimpleEmailV2.ContactLanguage ContactLanguage { get; set; }
            public Amazon.SimpleEmailV2.MailType MailType { get; set; }
            public System.Boolean? ProductionAccessEnabled { get; set; }
            public System.String UseCaseDescription { get; set; }
            public System.String WebsiteURL { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.PutAccountDetailsResponse, WriteSES2AccountDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
