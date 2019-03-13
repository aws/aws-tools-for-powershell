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
using Amazon.AutoScalingPlans;
using Amazon.AutoScalingPlans.Model;

namespace Amazon.PowerShell.Cmdlets.ASP
{
    /// <summary>
    /// Updates the specified scaling plan.
    /// 
    ///  
    /// <para>
    /// You cannot update a scaling plan if it is in the process of being created, updated,
    /// or deleted.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ASPScalingPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Auto Scaling Plans UpdateScalingPlan API operation.", Operation = new[] {"UpdateScalingPlan"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ScalingPlanName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AutoScalingPlans.Model.UpdateScalingPlanResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateASPScalingPlanCmdlet : AmazonAutoScalingPlansClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationSource_CloudFormationStackARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a AWS CloudFormation stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApplicationSource_CloudFormationStackARN { get; set; }
        #endregion
        
        #region Parameter ScalingInstruction
        /// <summary>
        /// <para>
        /// <para>The scaling instructions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ScalingInstructions")]
        public Amazon.AutoScalingPlans.Model.ScalingInstruction[] ScalingInstruction { get; set; }
        #endregion
        
        #region Parameter ScalingPlanName
        /// <summary>
        /// <para>
        /// <para>The name of the scaling plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ScalingPlanName { get; set; }
        #endregion
        
        #region Parameter ScalingPlanVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the scaling plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 ScalingPlanVersion { get; set; }
        #endregion
        
        #region Parameter ApplicationSource_TagFilter
        /// <summary>
        /// <para>
        /// <para>A set of tags (up to 50).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ApplicationSource_TagFilters")]
        public Amazon.AutoScalingPlans.Model.TagFilter[] ApplicationSource_TagFilter { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ScalingPlanName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ScalingPlanName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ASPScalingPlan (UpdateScalingPlan)"))
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
            
            context.ApplicationSource_CloudFormationStackARN = this.ApplicationSource_CloudFormationStackARN;
            if (this.ApplicationSource_TagFilter != null)
            {
                context.ApplicationSource_TagFilters = new List<Amazon.AutoScalingPlans.Model.TagFilter>(this.ApplicationSource_TagFilter);
            }
            if (this.ScalingInstruction != null)
            {
                context.ScalingInstructions = new List<Amazon.AutoScalingPlans.Model.ScalingInstruction>(this.ScalingInstruction);
            }
            context.ScalingPlanName = this.ScalingPlanName;
            if (ParameterWasBound("ScalingPlanVersion"))
                context.ScalingPlanVersion = this.ScalingPlanVersion;
            
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
            var request = new Amazon.AutoScalingPlans.Model.UpdateScalingPlanRequest();
            
            
             // populate ApplicationSource
            bool requestApplicationSourceIsNull = true;
            request.ApplicationSource = new Amazon.AutoScalingPlans.Model.ApplicationSource();
            System.String requestApplicationSource_applicationSource_CloudFormationStackARN = null;
            if (cmdletContext.ApplicationSource_CloudFormationStackARN != null)
            {
                requestApplicationSource_applicationSource_CloudFormationStackARN = cmdletContext.ApplicationSource_CloudFormationStackARN;
            }
            if (requestApplicationSource_applicationSource_CloudFormationStackARN != null)
            {
                request.ApplicationSource.CloudFormationStackARN = requestApplicationSource_applicationSource_CloudFormationStackARN;
                requestApplicationSourceIsNull = false;
            }
            List<Amazon.AutoScalingPlans.Model.TagFilter> requestApplicationSource_applicationSource_TagFilter = null;
            if (cmdletContext.ApplicationSource_TagFilters != null)
            {
                requestApplicationSource_applicationSource_TagFilter = cmdletContext.ApplicationSource_TagFilters;
            }
            if (requestApplicationSource_applicationSource_TagFilter != null)
            {
                request.ApplicationSource.TagFilters = requestApplicationSource_applicationSource_TagFilter;
                requestApplicationSourceIsNull = false;
            }
             // determine if request.ApplicationSource should be set to null
            if (requestApplicationSourceIsNull)
            {
                request.ApplicationSource = null;
            }
            if (cmdletContext.ScalingInstructions != null)
            {
                request.ScalingInstructions = cmdletContext.ScalingInstructions;
            }
            if (cmdletContext.ScalingPlanName != null)
            {
                request.ScalingPlanName = cmdletContext.ScalingPlanName;
            }
            if (cmdletContext.ScalingPlanVersion != null)
            {
                request.ScalingPlanVersion = cmdletContext.ScalingPlanVersion.Value;
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
                    pipelineOutput = this.ScalingPlanName;
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
        
        private Amazon.AutoScalingPlans.Model.UpdateScalingPlanResponse CallAWSServiceOperation(IAmazonAutoScalingPlans client, Amazon.AutoScalingPlans.Model.UpdateScalingPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling Plans", "UpdateScalingPlan");
            try
            {
                #if DESKTOP
                return client.UpdateScalingPlan(request);
                #elif CORECLR
                return client.UpdateScalingPlanAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationSource_CloudFormationStackARN { get; set; }
            public List<Amazon.AutoScalingPlans.Model.TagFilter> ApplicationSource_TagFilters { get; set; }
            public List<Amazon.AutoScalingPlans.Model.ScalingInstruction> ScalingInstructions { get; set; }
            public System.String ScalingPlanName { get; set; }
            public System.Int64? ScalingPlanVersion { get; set; }
        }
        
    }
}
