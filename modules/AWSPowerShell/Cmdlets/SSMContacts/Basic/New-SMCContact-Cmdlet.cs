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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Contacts are either the contacts that Incident Manager engages during an incident
    /// or the escalation plans that Incident Manager uses to engage contacts in phases during
    /// an incident.
    /// </summary>
    [Cmdlet("New", "SMCContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager Contacts CreateContact API operation.", Operation = new[] {"CreateContact"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.CreateContactResponse))]
    [AWSCmdletOutput("System.String or Amazon.SSMContacts.Model.CreateContactResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SSMContacts.Model.CreateContactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMCContactCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>The short name to quickly identify a contact or escalation plan. The contact alias
        /// must be unique and identifiable.</para>
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
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The full name of the contact or escalation plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A token ensuring that the operation is called only once with the specified details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Plan_RotationId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the on-call rotations associated with the plan.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Plan_RotationIds")]
        public System.String[] Plan_RotationId { get; set; }
        #endregion
        
        #region Parameter Plan_Stage
        /// <summary>
        /// <para>
        /// <para>A list of stages that the escalation plan or engagement plan uses to engage contacts
        /// and contact methods.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Plan_Stages")]
        public Amazon.SSMContacts.Model.Stage[] Plan_Stage { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds a tag to the target. You can only tag resources created in the first Region of
        /// your replication set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SSMContacts.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>To create an escalation plan use <c>ESCALATION</c>. To create a contact use <c>PERSONAL</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SSMContacts.ContactType")]
        public Amazon.SSMContacts.ContactType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContactArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.CreateContactResponse).
        /// Specifying the name of a property of type Amazon.SSMContacts.Model.CreateContactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContactArn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Alias), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMCContact (CreateContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.CreateContactResponse, NewSMCContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Alias = this.Alias;
            #if MODULAR
            if (this.Alias == null && ParameterWasBound(nameof(this.Alias)))
            {
                WriteWarning("You are passing $null as a value for parameter Alias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DisplayName = this.DisplayName;
            context.IdempotencyToken = this.IdempotencyToken;
            if (this.Plan_RotationId != null)
            {
                context.Plan_RotationId = new List<System.String>(this.Plan_RotationId);
            }
            if (this.Plan_Stage != null)
            {
                context.Plan_Stage = new List<Amazon.SSMContacts.Model.Stage>(this.Plan_Stage);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SSMContacts.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSMContacts.Model.CreateContactRequest();
            
            if (cmdletContext.Alias != null)
            {
                request.Alias = cmdletContext.Alias;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            
             // populate Plan
            var requestPlanIsNull = true;
            request.Plan = new Amazon.SSMContacts.Model.Plan();
            List<System.String> requestPlan_plan_RotationId = null;
            if (cmdletContext.Plan_RotationId != null)
            {
                requestPlan_plan_RotationId = cmdletContext.Plan_RotationId;
            }
            if (requestPlan_plan_RotationId != null)
            {
                request.Plan.RotationIds = requestPlan_plan_RotationId;
                requestPlanIsNull = false;
            }
            List<Amazon.SSMContacts.Model.Stage> requestPlan_plan_Stage = null;
            if (cmdletContext.Plan_Stage != null)
            {
                requestPlan_plan_Stage = cmdletContext.Plan_Stage;
            }
            if (requestPlan_plan_Stage != null)
            {
                request.Plan.Stages = requestPlan_plan_Stage;
                requestPlanIsNull = false;
            }
             // determine if request.Plan should be set to null
            if (requestPlanIsNull)
            {
                request.Plan = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.SSMContacts.Model.CreateContactResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.CreateContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager Contacts", "CreateContact");
            try
            {
                return client.CreateContactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Alias { get; set; }
            public System.String DisplayName { get; set; }
            public System.String IdempotencyToken { get; set; }
            public List<System.String> Plan_RotationId { get; set; }
            public List<Amazon.SSMContacts.Model.Stage> Plan_Stage { get; set; }
            public List<Amazon.SSMContacts.Model.Tag> Tag { get; set; }
            public Amazon.SSMContacts.ContactType Type { get; set; }
            public System.Func<Amazon.SSMContacts.Model.CreateContactResponse, NewSMCContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContactArn;
        }
        
    }
}
