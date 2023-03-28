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
using Amazon.SSMContacts;
using Amazon.SSMContacts.Model;

namespace Amazon.PowerShell.Cmdlets.SMC
{
    /// <summary>
    /// Updates the contact or escalation plan specified.
    /// </summary>
    [Cmdlet("Update", "SMCContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS System Manager Contacts UpdateContact API operation.", Operation = new[] {"UpdateContact"}, SelectReturnType = typeof(Amazon.SSMContacts.Model.UpdateContactResponse))]
    [AWSCmdletOutput("None or Amazon.SSMContacts.Model.UpdateContactResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSMContacts.Model.UpdateContactResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMCContactCmdlet : AmazonSSMContactsClientCmdlet, IExecutor
    {
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the contact or escalation plan you're updating.</para>
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
        public System.String ContactId { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMContacts.Model.UpdateContactResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ContactId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ContactId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ContactId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMCContact (UpdateContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMContacts.Model.UpdateContactResponse, UpdateSMCContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ContactId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContactId = this.ContactId;
            #if MODULAR
            if (this.ContactId == null && ParameterWasBound(nameof(this.ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DisplayName = this.DisplayName;
            if (this.Plan_RotationId != null)
            {
                context.Plan_RotationId = new List<System.String>(this.Plan_RotationId);
            }
            if (this.Plan_Stage != null)
            {
                context.Plan_Stage = new List<Amazon.SSMContacts.Model.Stage>(this.Plan_Stage);
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
            var request = new Amazon.SSMContacts.Model.UpdateContactRequest();
            
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
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
        
        private Amazon.SSMContacts.Model.UpdateContactResponse CallAWSServiceOperation(IAmazonSSMContacts client, Amazon.SSMContacts.Model.UpdateContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS System Manager Contacts", "UpdateContact");
            try
            {
                #if DESKTOP
                return client.UpdateContact(request);
                #elif CORECLR
                return client.UpdateContactAsync(request).GetAwaiter().GetResult();
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
            public System.String ContactId { get; set; }
            public System.String DisplayName { get; set; }
            public List<System.String> Plan_RotationId { get; set; }
            public List<Amazon.SSMContacts.Model.Stage> Plan_Stage { get; set; }
            public System.Func<Amazon.SSMContacts.Model.UpdateContactResponse, UpdateSMCContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
