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
using Amazon.PartnerCentralAccount;
using Amazon.PartnerCentralAccount.Model;

namespace Amazon.PowerShell.Cmdlets.PCAA
{
    /// <summary>
    /// Creates or updates the alliance lead contact information for a partner account.
    /// </summary>
    [Cmdlet("Write", "PCAAAllianceLeadContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactResponse")]
    [AWSCmdlet("Calls the Partner Central Account API PutAllianceLeadContact API operation.", Operation = new[] {"PutAllianceLeadContact"}, SelectReturnType = typeof(Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactResponse",
        "This cmdlet returns an Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactResponse object containing multiple properties."
    )]
    public partial class WritePCAAAllianceLeadContactCmdlet : AmazonPartnerCentralAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllianceLeadContact_BusinessTitle
        /// <summary>
        /// <para>
        /// <para>The business title or role of the alliance lead contact person.</para>
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
        public System.String AllianceLeadContact_BusinessTitle { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog identifier for the partner account.</para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter AllianceLeadContact_Email
        /// <summary>
        /// <para>
        /// <para>The email address of the alliance lead contact person.</para>
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
        public System.String AllianceLeadContact_Email { get; set; }
        #endregion
        
        #region Parameter EmailVerificationCode
        /// <summary>
        /// <para>
        /// <para>The verification code sent to the alliance lead contact's email to confirm the update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailVerificationCode { get; set; }
        #endregion
        
        #region Parameter AllianceLeadContact_FirstName
        /// <summary>
        /// <para>
        /// <para>The first name of the alliance lead contact person.</para>
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
        public System.String AllianceLeadContact_FirstName { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the partner account.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter AllianceLeadContact_LastName
        /// <summary>
        /// <para>
        /// <para>The last name of the alliance lead contact person.</para>
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
        public System.String AllianceLeadContact_LastName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-PCAAAllianceLeadContact (PutAllianceLeadContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactResponse, WritePCAAAllianceLeadContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllianceLeadContact_BusinessTitle = this.AllianceLeadContact_BusinessTitle;
            #if MODULAR
            if (this.AllianceLeadContact_BusinessTitle == null && ParameterWasBound(nameof(this.AllianceLeadContact_BusinessTitle)))
            {
                WriteWarning("You are passing $null as a value for parameter AllianceLeadContact_BusinessTitle which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AllianceLeadContact_Email = this.AllianceLeadContact_Email;
            #if MODULAR
            if (this.AllianceLeadContact_Email == null && ParameterWasBound(nameof(this.AllianceLeadContact_Email)))
            {
                WriteWarning("You are passing $null as a value for parameter AllianceLeadContact_Email which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AllianceLeadContact_FirstName = this.AllianceLeadContact_FirstName;
            #if MODULAR
            if (this.AllianceLeadContact_FirstName == null && ParameterWasBound(nameof(this.AllianceLeadContact_FirstName)))
            {
                WriteWarning("You are passing $null as a value for parameter AllianceLeadContact_FirstName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AllianceLeadContact_LastName = this.AllianceLeadContact_LastName;
            #if MODULAR
            if (this.AllianceLeadContact_LastName == null && ParameterWasBound(nameof(this.AllianceLeadContact_LastName)))
            {
                WriteWarning("You are passing $null as a value for parameter AllianceLeadContact_LastName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailVerificationCode = this.EmailVerificationCode;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactRequest();
            
            
             // populate AllianceLeadContact
            var requestAllianceLeadContactIsNull = true;
            request.AllianceLeadContact = new Amazon.PartnerCentralAccount.Model.AllianceLeadContact();
            System.String requestAllianceLeadContact_allianceLeadContact_BusinessTitle = null;
            if (cmdletContext.AllianceLeadContact_BusinessTitle != null)
            {
                requestAllianceLeadContact_allianceLeadContact_BusinessTitle = cmdletContext.AllianceLeadContact_BusinessTitle;
            }
            if (requestAllianceLeadContact_allianceLeadContact_BusinessTitle != null)
            {
                request.AllianceLeadContact.BusinessTitle = requestAllianceLeadContact_allianceLeadContact_BusinessTitle;
                requestAllianceLeadContactIsNull = false;
            }
            System.String requestAllianceLeadContact_allianceLeadContact_Email = null;
            if (cmdletContext.AllianceLeadContact_Email != null)
            {
                requestAllianceLeadContact_allianceLeadContact_Email = cmdletContext.AllianceLeadContact_Email;
            }
            if (requestAllianceLeadContact_allianceLeadContact_Email != null)
            {
                request.AllianceLeadContact.Email = requestAllianceLeadContact_allianceLeadContact_Email;
                requestAllianceLeadContactIsNull = false;
            }
            System.String requestAllianceLeadContact_allianceLeadContact_FirstName = null;
            if (cmdletContext.AllianceLeadContact_FirstName != null)
            {
                requestAllianceLeadContact_allianceLeadContact_FirstName = cmdletContext.AllianceLeadContact_FirstName;
            }
            if (requestAllianceLeadContact_allianceLeadContact_FirstName != null)
            {
                request.AllianceLeadContact.FirstName = requestAllianceLeadContact_allianceLeadContact_FirstName;
                requestAllianceLeadContactIsNull = false;
            }
            System.String requestAllianceLeadContact_allianceLeadContact_LastName = null;
            if (cmdletContext.AllianceLeadContact_LastName != null)
            {
                requestAllianceLeadContact_allianceLeadContact_LastName = cmdletContext.AllianceLeadContact_LastName;
            }
            if (requestAllianceLeadContact_allianceLeadContact_LastName != null)
            {
                request.AllianceLeadContact.LastName = requestAllianceLeadContact_allianceLeadContact_LastName;
                requestAllianceLeadContactIsNull = false;
            }
             // determine if request.AllianceLeadContact should be set to null
            if (requestAllianceLeadContactIsNull)
            {
                request.AllianceLeadContact = null;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.EmailVerificationCode != null)
            {
                request.EmailVerificationCode = cmdletContext.EmailVerificationCode;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
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
        
        private Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactResponse CallAWSServiceOperation(IAmazonPartnerCentralAccount client, Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Account API", "PutAllianceLeadContact");
            try
            {
                #if DESKTOP
                return client.PutAllianceLeadContact(request);
                #elif CORECLR
                return client.PutAllianceLeadContactAsync(request).GetAwaiter().GetResult();
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
            public System.String AllianceLeadContact_BusinessTitle { get; set; }
            public System.String AllianceLeadContact_Email { get; set; }
            public System.String AllianceLeadContact_FirstName { get; set; }
            public System.String AllianceLeadContact_LastName { get; set; }
            public System.String Catalog { get; set; }
            public System.String EmailVerificationCode { get; set; }
            public System.String Identifier { get; set; }
            public System.Func<Amazon.PartnerCentralAccount.Model.PutAllianceLeadContactResponse, WritePCAAAllianceLeadContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
