/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Updates an AWS Batch compute environment.
    /// </summary>
    [Cmdlet("Update", "BATComputeEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.UpdateComputeEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Batch UpdateComputeEnvironment API operation.", Operation = new[] {"UpdateComputeEnvironment"})]
    [AWSCmdletOutput("Amazon.Batch.Model.UpdateComputeEnvironmentResponse",
        "This cmdlet returns a Amazon.Batch.Model.UpdateComputeEnvironmentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBATComputeEnvironmentCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        #region Parameter ComputeEnvironment
        /// <summary>
        /// <para>
        /// <para>The name or full Amazon Resource Name (ARN) of the compute environment to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ComputeEnvironment { get; set; }
        #endregion
        
        #region Parameter ComputeResources_DesiredvCpu
        /// <summary>
        /// <para>
        /// <para>The desired number of EC2 vCPUS in the compute environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_DesiredvCpus")]
        public System.Int32 ComputeResources_DesiredvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_MaxvCpu
        /// <summary>
        /// <para>
        /// <para>The maximum number of EC2 vCPUs that an environment can reach.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_MaxvCpus")]
        public System.Int32 ComputeResources_MaxvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_MinvCpu
        /// <summary>
        /// <para>
        /// <para>The minimum number of EC2 vCPUs that an environment should maintain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeResources_MinvCpus")]
        public System.Int32 ComputeResources_MinvCpu { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The full Amazon Resource Name (ARN) of the IAM role that allows AWS Batch to make
        /// calls to other AWS services on your behalf.</para><para>If your specified role has a path other than <code>/</code>, then you must either
        /// specify the full role ARN (this is recommended) or prefix the role name with the path.</para><note><para>Depending on how you created your AWS Batch service role, its ARN may contain the
        /// <code>service-role</code> path prefix. When you only specify the name of the service
        /// role, AWS Batch assumes that your ARN does not use the <code>service-role</code> path
        /// prefix. Because of this, we recommend that you specify the full ARN of your service
        /// role when you create compute environments.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state of the compute environment. Compute environments in the <code>ENABLED</code>
        /// state can accept jobs from a queue and scale in or out automatically based on the
        /// workload demand of its associated queues.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Batch.CEState")]
        public Amazon.Batch.CEState State { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ComputeEnvironment", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BATComputeEnvironment (UpdateComputeEnvironment)"))
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
            
            context.ComputeEnvironment = this.ComputeEnvironment;
            if (ParameterWasBound("ComputeResources_DesiredvCpu"))
                context.ComputeResources_DesiredvCpus = this.ComputeResources_DesiredvCpu;
            if (ParameterWasBound("ComputeResources_MaxvCpu"))
                context.ComputeResources_MaxvCpus = this.ComputeResources_MaxvCpu;
            if (ParameterWasBound("ComputeResources_MinvCpu"))
                context.ComputeResources_MinvCpus = this.ComputeResources_MinvCpu;
            context.ServiceRole = this.ServiceRole;
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
            var request = new Amazon.Batch.Model.UpdateComputeEnvironmentRequest();
            
            if (cmdletContext.ComputeEnvironment != null)
            {
                request.ComputeEnvironment = cmdletContext.ComputeEnvironment;
            }
            
             // populate ComputeResources
            bool requestComputeResourcesIsNull = true;
            request.ComputeResources = new Amazon.Batch.Model.ComputeResourceUpdate();
            System.Int32? requestComputeResources_computeResources_DesiredvCpu = null;
            if (cmdletContext.ComputeResources_DesiredvCpus != null)
            {
                requestComputeResources_computeResources_DesiredvCpu = cmdletContext.ComputeResources_DesiredvCpus.Value;
            }
            if (requestComputeResources_computeResources_DesiredvCpu != null)
            {
                request.ComputeResources.DesiredvCpus = requestComputeResources_computeResources_DesiredvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_MaxvCpu = null;
            if (cmdletContext.ComputeResources_MaxvCpus != null)
            {
                requestComputeResources_computeResources_MaxvCpu = cmdletContext.ComputeResources_MaxvCpus.Value;
            }
            if (requestComputeResources_computeResources_MaxvCpu != null)
            {
                request.ComputeResources.MaxvCpus = requestComputeResources_computeResources_MaxvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_MinvCpu = null;
            if (cmdletContext.ComputeResources_MinvCpus != null)
            {
                requestComputeResources_computeResources_MinvCpu = cmdletContext.ComputeResources_MinvCpus.Value;
            }
            if (requestComputeResources_computeResources_MinvCpu != null)
            {
                request.ComputeResources.MinvCpus = requestComputeResources_computeResources_MinvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
             // determine if request.ComputeResources should be set to null
            if (requestComputeResourcesIsNull)
            {
                request.ComputeResources = null;
            }
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
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
                object pipelineOutput = response;
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
        
        private Amazon.Batch.Model.UpdateComputeEnvironmentResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.UpdateComputeEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "UpdateComputeEnvironment");
            try
            {
                #if DESKTOP
                return client.UpdateComputeEnvironment(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateComputeEnvironmentAsync(request);
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
            public System.String ComputeEnvironment { get; set; }
            public System.Int32? ComputeResources_DesiredvCpus { get; set; }
            public System.Int32? ComputeResources_MaxvCpus { get; set; }
            public System.Int32? ComputeResources_MinvCpus { get; set; }
            public System.String ServiceRole { get; set; }
            public Amazon.Batch.CEState State { get; set; }
        }
        
    }
}
