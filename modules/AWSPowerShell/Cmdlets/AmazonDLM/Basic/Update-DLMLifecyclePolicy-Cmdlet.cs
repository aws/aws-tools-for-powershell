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
using Amazon.DLM;
using Amazon.DLM.Model;

namespace Amazon.PowerShell.Cmdlets.DLM
{
    /// <summary>
    /// Updates the specified lifecycle policy.
    /// </summary>
    [Cmdlet("Update", "DLMLifecyclePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Data Lifecycle Manager UpdateLifecyclePolicy API operation.", Operation = new[] {"UpdateLifecyclePolicy"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the PolicyId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.DLM.Model.UpdateLifecyclePolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDLMLifecyclePolicyCmdlet : AmazonDLMClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the lifecycle policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role used to run the operations specified
        /// by the lifecycle policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the lifecycle policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PolicyId { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PolicyDetails_ResourceTypes")]
        public System.String[] PolicyDetails_ResourceType { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_Schedule
        /// <summary>
        /// <para>
        /// <para>The schedule of policy-defined actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PolicyDetails_Schedules")]
        public Amazon.DLM.Model.Schedule[] PolicyDetails_Schedule { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The desired activation state of the lifecycle policy after creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DLM.SettablePolicyStateValues")]
        public Amazon.DLM.SettablePolicyStateValues State { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_TargetTag
        /// <summary>
        /// <para>
        /// <para>The single tag that identifies targeted resources for this policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PolicyDetails_TargetTags")]
        public Amazon.DLM.Model.Tag[] PolicyDetails_TargetTag { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the PolicyId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PolicyId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DLMLifecyclePolicy (UpdateLifecyclePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Description = this.Description;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            if (this.PolicyDetails_ResourceType != null)
            {
                context.PolicyDetails_ResourceTypes = new List<System.String>(this.PolicyDetails_ResourceType);
            }
            if (this.PolicyDetails_Schedule != null)
            {
                context.PolicyDetails_Schedules = new List<Amazon.DLM.Model.Schedule>(this.PolicyDetails_Schedule);
            }
            if (this.PolicyDetails_TargetTag != null)
            {
                context.PolicyDetails_TargetTags = new List<Amazon.DLM.Model.Tag>(this.PolicyDetails_TargetTag);
            }
            context.PolicyId = this.PolicyId;
            context.State = this.State;
            
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
            var request = new Amazon.DLM.Model.UpdateLifecyclePolicyRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate PolicyDetails
            bool requestPolicyDetailsIsNull = true;
            request.PolicyDetails = new Amazon.DLM.Model.PolicyDetails();
            List<System.String> requestPolicyDetails_policyDetails_ResourceType = null;
            if (cmdletContext.PolicyDetails_ResourceTypes != null)
            {
                requestPolicyDetails_policyDetails_ResourceType = cmdletContext.PolicyDetails_ResourceTypes;
            }
            if (requestPolicyDetails_policyDetails_ResourceType != null)
            {
                request.PolicyDetails.ResourceTypes = requestPolicyDetails_policyDetails_ResourceType;
                requestPolicyDetailsIsNull = false;
            }
            List<Amazon.DLM.Model.Schedule> requestPolicyDetails_policyDetails_Schedule = null;
            if (cmdletContext.PolicyDetails_Schedules != null)
            {
                requestPolicyDetails_policyDetails_Schedule = cmdletContext.PolicyDetails_Schedules;
            }
            if (requestPolicyDetails_policyDetails_Schedule != null)
            {
                request.PolicyDetails.Schedules = requestPolicyDetails_policyDetails_Schedule;
                requestPolicyDetailsIsNull = false;
            }
            List<Amazon.DLM.Model.Tag> requestPolicyDetails_policyDetails_TargetTag = null;
            if (cmdletContext.PolicyDetails_TargetTags != null)
            {
                requestPolicyDetails_policyDetails_TargetTag = cmdletContext.PolicyDetails_TargetTags;
            }
            if (requestPolicyDetails_policyDetails_TargetTag != null)
            {
                request.PolicyDetails.TargetTags = requestPolicyDetails_policyDetails_TargetTag;
                requestPolicyDetailsIsNull = false;
            }
             // determine if request.PolicyDetails should be set to null
            if (requestPolicyDetailsIsNull)
            {
                request.PolicyDetails = null;
            }
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyId = cmdletContext.PolicyId;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.PolicyId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.DLM.Model.UpdateLifecyclePolicyResponse CallAWSServiceOperation(IAmazonDLM client, Amazon.DLM.Model.UpdateLifecyclePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Data Lifecycle Manager", "UpdateLifecyclePolicy");
            try
            {
                #if DESKTOP
                return client.UpdateLifecyclePolicy(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateLifecyclePolicyAsync(request);
                return task.Result;
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
            public System.String Description { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public List<System.String> PolicyDetails_ResourceTypes { get; set; }
            public List<Amazon.DLM.Model.Schedule> PolicyDetails_Schedules { get; set; }
            public List<Amazon.DLM.Model.Tag> PolicyDetails_TargetTags { get; set; }
            public System.String PolicyId { get; set; }
            public Amazon.DLM.SettablePolicyStateValues State { get; set; }
        }
        
    }
}
