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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Submits an AWS Batch job from a job definition. Parameters specified during <a>SubmitJob</a>
    /// override parameters defined in the job definition.
    /// </summary>
    [Cmdlet("Submit", "BATJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.SubmitJobResponse")]
    [AWSCmdlet("Calls the AWS Batch SubmitJob API operation.", Operation = new[] {"SubmitJob"})]
    [AWSCmdletOutput("Amazon.Batch.Model.SubmitJobResponse",
        "This cmdlet returns a Amazon.Batch.Model.SubmitJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SubmitBATJobCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        #region Parameter RetryStrategy_Attempt
        /// <summary>
        /// <para>
        /// <para>The number of times to move a job to the <code>RUNNABLE</code> status. You may specify
        /// between 1 and 10 attempts. If the value of <code>attempts</code> is greater than one,
        /// the job is retried on failure the same number of attempts as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RetryStrategy_Attempts")]
        public System.Int32 RetryStrategy_Attempt { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_Command
        /// <summary>
        /// <para>
        /// <para>The command to send to the container that overrides the default command from the Docker
        /// image or the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ContainerOverrides_Command { get; set; }
        #endregion
        
        #region Parameter DependsOn
        /// <summary>
        /// <para>
        /// <para>A list of dependencies for the job. A job can depend upon a maximum of 20 jobs. You
        /// can specify a <code>SEQUENTIAL</code> type dependency without specifying a job ID
        /// for array jobs so that each child array job completes sequentially, starting at index
        /// 0. You can also specify an <code>N_TO_N</code> type dependency with a job ID for array
        /// jobs. In that case, each index child of this job must wait for the corresponding index
        /// child of each dependency to complete before it can begin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Batch.Model.JobDependency[] DependsOn { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to send to the container. You can add new environment variables,
        /// which are added to the container at launch, or you can override the existing environment
        /// variables from the Docker image or the job definition.</para><note><para>Environment variables must not start with <code>AWS_BATCH</code>; this naming convention
        /// is reserved for variables that are set by the AWS Batch service.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Batch.Model.KeyValuePair[] ContainerOverrides_Environment { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to use for a multi-node parallel job. This parameter is not valid
        /// for single-node container jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContainerOverrides_InstanceType { get; set; }
        #endregion
        
        #region Parameter JobDefinition
        /// <summary>
        /// <para>
        /// <para>The job definition used by this job. This value can be either a <code>name:revision</code>
        /// or the Amazon Resource Name (ARN) for the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String JobDefinition { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name of the job. The first character must be alphanumeric, and up to 128 letters
        /// (uppercase and lowercase), numbers, hyphens, and underscores are allowed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter JobQueue
        /// <summary>
        /// <para>
        /// <para>The job queue into which the job is submitted. You can specify either the name or
        /// the Amazon Resource Name (ARN) of the queue. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String JobQueue { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_Memory
        /// <summary>
        /// <para>
        /// <para>The number of MiB of memory reserved for the job. This value overrides the value set
        /// in the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ContainerOverrides_Memory { get; set; }
        #endregion
        
        #region Parameter NodeOverrides_NodePropertyOverride
        /// <summary>
        /// <para>
        /// <para>The node property overrides for the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NodeOverrides_NodePropertyOverrides")]
        public Amazon.Batch.Model.NodePropertyOverride[] NodeOverrides_NodePropertyOverride { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>Additional parameters passed to the job that replace parameter substitution placeholders
        /// that are set in the job definition. Parameters are specified as a key and value pair
        /// mapping. Parameters in a <code>SubmitJob</code> request override any corresponding
        /// parameter defaults from the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ArrayProperties_Size
        /// <summary>
        /// <para>
        /// <para>The size of the array job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ArrayProperties_Size { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The timeout configuration for this <a>SubmitJob</a> operation. You can specify a timeout
        /// duration after which AWS Batch terminates your jobs if they have not finished. If
        /// a job is terminated due to a timeout, it is not retried. The minimum value for the
        /// timeout is 60 seconds. This configuration overrides any timeout configuration specified
        /// in the job definition. For array jobs, child jobs have the same timeout configuration
        /// as the parent job. For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/job_timeouts.html">Job
        /// Timeouts</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Batch.Model.JobTimeout Timeout { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_Vcpu
        /// <summary>
        /// <para>
        /// <para>The number of vCPUs to reserve for the container. This value overrides the value set
        /// in the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContainerOverrides_Vcpus")]
        public System.Int32 ContainerOverrides_Vcpu { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-BATJob (SubmitJob)"))
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
            
            if (ParameterWasBound("ArrayProperties_Size"))
                context.ArrayProperties_Size = this.ArrayProperties_Size;
            if (this.ContainerOverrides_Command != null)
            {
                context.ContainerOverrides_Command = new List<System.String>(this.ContainerOverrides_Command);
            }
            if (this.ContainerOverrides_Environment != null)
            {
                context.ContainerOverrides_Environment = new List<Amazon.Batch.Model.KeyValuePair>(this.ContainerOverrides_Environment);
            }
            context.ContainerOverrides_InstanceType = this.ContainerOverrides_InstanceType;
            if (ParameterWasBound("ContainerOverrides_Memory"))
                context.ContainerOverrides_Memory = this.ContainerOverrides_Memory;
            if (ParameterWasBound("ContainerOverrides_Vcpu"))
                context.ContainerOverrides_Vcpus = this.ContainerOverrides_Vcpu;
            if (this.DependsOn != null)
            {
                context.DependsOn = new List<Amazon.Batch.Model.JobDependency>(this.DependsOn);
            }
            context.JobDefinition = this.JobDefinition;
            context.JobName = this.JobName;
            context.JobQueue = this.JobQueue;
            if (this.NodeOverrides_NodePropertyOverride != null)
            {
                context.NodeOverrides_NodePropertyOverrides = new List<Amazon.Batch.Model.NodePropertyOverride>(this.NodeOverrides_NodePropertyOverride);
            }
            if (this.Parameter != null)
            {
                context.Parameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameters.Add((String)hashKey, (String)(this.Parameter[hashKey]));
                }
            }
            if (ParameterWasBound("RetryStrategy_Attempt"))
                context.RetryStrategy_Attempts = this.RetryStrategy_Attempt;
            context.Timeout = this.Timeout;
            
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
            var request = new Amazon.Batch.Model.SubmitJobRequest();
            
            
             // populate ArrayProperties
            bool requestArrayPropertiesIsNull = true;
            request.ArrayProperties = new Amazon.Batch.Model.ArrayProperties();
            System.Int32? requestArrayProperties_arrayProperties_Size = null;
            if (cmdletContext.ArrayProperties_Size != null)
            {
                requestArrayProperties_arrayProperties_Size = cmdletContext.ArrayProperties_Size.Value;
            }
            if (requestArrayProperties_arrayProperties_Size != null)
            {
                request.ArrayProperties.Size = requestArrayProperties_arrayProperties_Size.Value;
                requestArrayPropertiesIsNull = false;
            }
             // determine if request.ArrayProperties should be set to null
            if (requestArrayPropertiesIsNull)
            {
                request.ArrayProperties = null;
            }
            
             // populate ContainerOverrides
            bool requestContainerOverridesIsNull = true;
            request.ContainerOverrides = new Amazon.Batch.Model.ContainerOverrides();
            List<System.String> requestContainerOverrides_containerOverrides_Command = null;
            if (cmdletContext.ContainerOverrides_Command != null)
            {
                requestContainerOverrides_containerOverrides_Command = cmdletContext.ContainerOverrides_Command;
            }
            if (requestContainerOverrides_containerOverrides_Command != null)
            {
                request.ContainerOverrides.Command = requestContainerOverrides_containerOverrides_Command;
                requestContainerOverridesIsNull = false;
            }
            List<Amazon.Batch.Model.KeyValuePair> requestContainerOverrides_containerOverrides_Environment = null;
            if (cmdletContext.ContainerOverrides_Environment != null)
            {
                requestContainerOverrides_containerOverrides_Environment = cmdletContext.ContainerOverrides_Environment;
            }
            if (requestContainerOverrides_containerOverrides_Environment != null)
            {
                request.ContainerOverrides.Environment = requestContainerOverrides_containerOverrides_Environment;
                requestContainerOverridesIsNull = false;
            }
            System.String requestContainerOverrides_containerOverrides_InstanceType = null;
            if (cmdletContext.ContainerOverrides_InstanceType != null)
            {
                requestContainerOverrides_containerOverrides_InstanceType = cmdletContext.ContainerOverrides_InstanceType;
            }
            if (requestContainerOverrides_containerOverrides_InstanceType != null)
            {
                request.ContainerOverrides.InstanceType = requestContainerOverrides_containerOverrides_InstanceType;
                requestContainerOverridesIsNull = false;
            }
            System.Int32? requestContainerOverrides_containerOverrides_Memory = null;
            if (cmdletContext.ContainerOverrides_Memory != null)
            {
                requestContainerOverrides_containerOverrides_Memory = cmdletContext.ContainerOverrides_Memory.Value;
            }
            if (requestContainerOverrides_containerOverrides_Memory != null)
            {
                request.ContainerOverrides.Memory = requestContainerOverrides_containerOverrides_Memory.Value;
                requestContainerOverridesIsNull = false;
            }
            System.Int32? requestContainerOverrides_containerOverrides_Vcpu = null;
            if (cmdletContext.ContainerOverrides_Vcpus != null)
            {
                requestContainerOverrides_containerOverrides_Vcpu = cmdletContext.ContainerOverrides_Vcpus.Value;
            }
            if (requestContainerOverrides_containerOverrides_Vcpu != null)
            {
                request.ContainerOverrides.Vcpus = requestContainerOverrides_containerOverrides_Vcpu.Value;
                requestContainerOverridesIsNull = false;
            }
             // determine if request.ContainerOverrides should be set to null
            if (requestContainerOverridesIsNull)
            {
                request.ContainerOverrides = null;
            }
            if (cmdletContext.DependsOn != null)
            {
                request.DependsOn = cmdletContext.DependsOn;
            }
            if (cmdletContext.JobDefinition != null)
            {
                request.JobDefinition = cmdletContext.JobDefinition;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobQueue != null)
            {
                request.JobQueue = cmdletContext.JobQueue;
            }
            
             // populate NodeOverrides
            bool requestNodeOverridesIsNull = true;
            request.NodeOverrides = new Amazon.Batch.Model.NodeOverrides();
            List<Amazon.Batch.Model.NodePropertyOverride> requestNodeOverrides_nodeOverrides_NodePropertyOverride = null;
            if (cmdletContext.NodeOverrides_NodePropertyOverrides != null)
            {
                requestNodeOverrides_nodeOverrides_NodePropertyOverride = cmdletContext.NodeOverrides_NodePropertyOverrides;
            }
            if (requestNodeOverrides_nodeOverrides_NodePropertyOverride != null)
            {
                request.NodeOverrides.NodePropertyOverrides = requestNodeOverrides_nodeOverrides_NodePropertyOverride;
                requestNodeOverridesIsNull = false;
            }
             // determine if request.NodeOverrides should be set to null
            if (requestNodeOverridesIsNull)
            {
                request.NodeOverrides = null;
            }
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            
             // populate RetryStrategy
            bool requestRetryStrategyIsNull = true;
            request.RetryStrategy = new Amazon.Batch.Model.RetryStrategy();
            System.Int32? requestRetryStrategy_retryStrategy_Attempt = null;
            if (cmdletContext.RetryStrategy_Attempts != null)
            {
                requestRetryStrategy_retryStrategy_Attempt = cmdletContext.RetryStrategy_Attempts.Value;
            }
            if (requestRetryStrategy_retryStrategy_Attempt != null)
            {
                request.RetryStrategy.Attempts = requestRetryStrategy_retryStrategy_Attempt.Value;
                requestRetryStrategyIsNull = false;
            }
             // determine if request.RetryStrategy should be set to null
            if (requestRetryStrategyIsNull)
            {
                request.RetryStrategy = null;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout;
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
        
        private Amazon.Batch.Model.SubmitJobResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.SubmitJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "SubmitJob");
            try
            {
                #if DESKTOP
                return client.SubmitJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SubmitJobAsync(request);
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
            public System.Int32? ArrayProperties_Size { get; set; }
            public List<System.String> ContainerOverrides_Command { get; set; }
            public List<Amazon.Batch.Model.KeyValuePair> ContainerOverrides_Environment { get; set; }
            public System.String ContainerOverrides_InstanceType { get; set; }
            public System.Int32? ContainerOverrides_Memory { get; set; }
            public System.Int32? ContainerOverrides_Vcpus { get; set; }
            public List<Amazon.Batch.Model.JobDependency> DependsOn { get; set; }
            public System.String JobDefinition { get; set; }
            public System.String JobName { get; set; }
            public System.String JobQueue { get; set; }
            public List<Amazon.Batch.Model.NodePropertyOverride> NodeOverrides_NodePropertyOverrides { get; set; }
            public Dictionary<System.String, System.String> Parameters { get; set; }
            public System.Int32? RetryStrategy_Attempts { get; set; }
            public Amazon.Batch.Model.JobTimeout Timeout { get; set; }
        }
        
    }
}
