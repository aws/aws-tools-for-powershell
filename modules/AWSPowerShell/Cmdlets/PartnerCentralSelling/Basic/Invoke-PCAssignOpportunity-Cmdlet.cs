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
using Amazon.PartnerCentralSelling;
using Amazon.PartnerCentralSelling.Model;

namespace Amazon.PowerShell.Cmdlets.PC
{
    /// <summary>
    /// Enables you to reassign an existing <c>Opportunity</c> to another user within your
    /// Partner Central account. The specified user receives the opportunity, and it appears
    /// on their Partner Central dashboard, allowing them to take necessary actions or proceed
    /// with the opportunity.
    /// 
    ///  
    /// <para>
    /// This is useful for distributing opportunities to the appropriate team members or departments
    /// within your organization, ensuring that each opportunity is handled by the right person.
    /// By default, the opportunity owner is the one who creates it. Currently, there's no
    /// API to enumerate the list of available users.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "PCAssignOpportunity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Partner Central Selling API AssignOpportunity API operation.", Operation = new[] {"AssignOpportunity"}, SelectReturnType = typeof(Amazon.PartnerCentralSelling.Model.AssignOpportunityResponse))]
    [AWSCmdletOutput("None or Amazon.PartnerCentralSelling.Model.AssignOpportunityResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.PartnerCentralSelling.Model.AssignOpportunityResponse) be returned by specifying '-Select *'."
    )]
    public partial class InvokePCAssignOpportunityCmdlet : AmazonPartnerCentralSellingClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Assignee_BusinessTitle
        /// <summary>
        /// <para>
        /// <para>Specifies the business title of the assignee managing the opportunity. This helps
        /// clarify the individual's role and responsibilities within the organization. Use the
        /// value <c>PartnerAccountManager</c> to update details of the opportunity owner.</para>
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
        public System.String Assignee_BusinessTitle { get; set; }
        #endregion
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>Specifies the catalog associated with the request. This field takes a string value
        /// from a predefined list: <c>AWS</c> or <c>Sandbox</c>. The catalog determines which
        /// environment the opportunity is assigned in. Use <c>AWS</c> to assign real opportunities
        /// in the Amazon Web Services catalog, and <c>Sandbox</c> for testing in secure, isolated
        /// environments.</para>
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
        
        #region Parameter Assignee_Email
        /// <summary>
        /// <para>
        /// <para>Provides the email address of the assignee. This email is used for communications
        /// and notifications related to the opportunity.</para>
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
        public System.String Assignee_Email { get; set; }
        #endregion
        
        #region Parameter Assignee_FirstName
        /// <summary>
        /// <para>
        /// <para>Specifies the first name of the assignee managing the opportunity. The system automatically
        /// retrieves this value from the user profile by referencing the associated email address.</para>
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
        public System.String Assignee_FirstName { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>Requires the <c>Opportunity</c>'s unique identifier when you want to assign it to
        /// another user. Provide the correct identifier so the intended opportunity is reassigned.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Assignee_LastName
        /// <summary>
        /// <para>
        /// <para>Specifies the last name of the assignee managing the opportunity. The system automatically
        /// retrieves this value from the user profile by referencing the associated email address.</para>
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
        public System.String Assignee_LastName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralSelling.Model.AssignOpportunityResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-PCAssignOpportunity (AssignOpportunity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralSelling.Model.AssignOpportunityResponse, InvokePCAssignOpportunityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Assignee_BusinessTitle = this.Assignee_BusinessTitle;
            #if MODULAR
            if (this.Assignee_BusinessTitle == null && ParameterWasBound(nameof(this.Assignee_BusinessTitle)))
            {
                WriteWarning("You are passing $null as a value for parameter Assignee_BusinessTitle which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Assignee_Email = this.Assignee_Email;
            #if MODULAR
            if (this.Assignee_Email == null && ParameterWasBound(nameof(this.Assignee_Email)))
            {
                WriteWarning("You are passing $null as a value for parameter Assignee_Email which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Assignee_FirstName = this.Assignee_FirstName;
            #if MODULAR
            if (this.Assignee_FirstName == null && ParameterWasBound(nameof(this.Assignee_FirstName)))
            {
                WriteWarning("You are passing $null as a value for parameter Assignee_FirstName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Assignee_LastName = this.Assignee_LastName;
            #if MODULAR
            if (this.Assignee_LastName == null && ParameterWasBound(nameof(this.Assignee_LastName)))
            {
                WriteWarning("You are passing $null as a value for parameter Assignee_LastName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.PartnerCentralSelling.Model.AssignOpportunityRequest();
            
            
             // populate Assignee
            var requestAssigneeIsNull = true;
            request.Assignee = new Amazon.PartnerCentralSelling.Model.AssigneeContact();
            System.String requestAssignee_assignee_BusinessTitle = null;
            if (cmdletContext.Assignee_BusinessTitle != null)
            {
                requestAssignee_assignee_BusinessTitle = cmdletContext.Assignee_BusinessTitle;
            }
            if (requestAssignee_assignee_BusinessTitle != null)
            {
                request.Assignee.BusinessTitle = requestAssignee_assignee_BusinessTitle;
                requestAssigneeIsNull = false;
            }
            System.String requestAssignee_assignee_Email = null;
            if (cmdletContext.Assignee_Email != null)
            {
                requestAssignee_assignee_Email = cmdletContext.Assignee_Email;
            }
            if (requestAssignee_assignee_Email != null)
            {
                request.Assignee.Email = requestAssignee_assignee_Email;
                requestAssigneeIsNull = false;
            }
            System.String requestAssignee_assignee_FirstName = null;
            if (cmdletContext.Assignee_FirstName != null)
            {
                requestAssignee_assignee_FirstName = cmdletContext.Assignee_FirstName;
            }
            if (requestAssignee_assignee_FirstName != null)
            {
                request.Assignee.FirstName = requestAssignee_assignee_FirstName;
                requestAssigneeIsNull = false;
            }
            System.String requestAssignee_assignee_LastName = null;
            if (cmdletContext.Assignee_LastName != null)
            {
                requestAssignee_assignee_LastName = cmdletContext.Assignee_LastName;
            }
            if (requestAssignee_assignee_LastName != null)
            {
                request.Assignee.LastName = requestAssignee_assignee_LastName;
                requestAssigneeIsNull = false;
            }
             // determine if request.Assignee should be set to null
            if (requestAssigneeIsNull)
            {
                request.Assignee = null;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
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
        
        private Amazon.PartnerCentralSelling.Model.AssignOpportunityResponse CallAWSServiceOperation(IAmazonPartnerCentralSelling client, Amazon.PartnerCentralSelling.Model.AssignOpportunityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Selling API", "AssignOpportunity");
            try
            {
                #if DESKTOP
                return client.AssignOpportunity(request);
                #elif CORECLR
                return client.AssignOpportunityAsync(request).GetAwaiter().GetResult();
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
            public System.String Assignee_BusinessTitle { get; set; }
            public System.String Assignee_Email { get; set; }
            public System.String Assignee_FirstName { get; set; }
            public System.String Assignee_LastName { get; set; }
            public System.String Catalog { get; set; }
            public System.String Identifier { get; set; }
            public System.Func<Amazon.PartnerCentralSelling.Model.AssignOpportunityResponse, InvokePCAssignOpportunityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
