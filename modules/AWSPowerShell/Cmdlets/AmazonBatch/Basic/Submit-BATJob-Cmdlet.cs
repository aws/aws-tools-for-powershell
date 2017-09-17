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
    /// Submits an AWS Batch job from a job definition. Parameters specified during <a>SubmitJob</a>
    /// override parameters defined in the job definition.
    /// </summary>
    [Cmdlet("Submit", "BATJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.SubmitJobResponse")]
    [AWSCmdlet("Invokes the SubmitJob operation against AWS Batch.", Operation = new[] {"SubmitJob"})]
    [AWSCmdletOutput("Amazon.Batch.Model.SubmitJobResponse",
        "This cmdlet returns a Amazon.Batch.Model.SubmitJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SubmitBATJobCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        #region Parameter RetryStrategy_Attempt
        /// <summary>
        /// <para>
        /// <para>The number of times to move a job to the <code>RUNNABLE</code> status. You may specify
        /// between 1 and 10 attempts. If <code>attempts</code> is greater than one, the job is
        /// retried if it fails until it has moved to <code>RUNNABLE</code> that many times.</para>
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
        /// <para>A list of job IDs on which this job depends. A job can depend upon a maximum of 20
        /// jobs. </para>
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
        /// variables from the Docker image or the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Batch.Model.KeyValuePair[] ContainerOverrides_Environment { get; set; }
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
        /// <para>The job queue into which the job will be submitted. You can specify either the name
        /// or the Amazon Resource Name (ARN) of the queue. </para>
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
            
            if (this.ContainerOverrides_Command != null)
            {
                context.ContainerOverrides_Command = new List<System.String>(this.ContainerOverrides_Command);
            }
            if (this.ContainerOverrides_Environment != null)
            {
                context.ContainerOverrides_Environment = new List<Amazon.Batch.Model.KeyValuePair>(this.ContainerOverrides_Environment);
            }
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
            public List<System.String> ContainerOverrides_Command { get; set; }
            public List<Amazon.Batch.Model.KeyValuePair> ContainerOverrides_Environment { get; set; }
            public System.Int32? ContainerOverrides_Memory { get; set; }
            public System.Int32? ContainerOverrides_Vcpus { get; set; }
            public List<Amazon.Batch.Model.JobDependency> DependsOn { get; set; }
            public System.String JobDefinition { get; set; }
            public System.String JobName { get; set; }
            public System.String JobQueue { get; set; }
            public Dictionary<System.String, System.String> Parameters { get; set; }
            public System.Int32? RetryStrategy_Attempts { get; set; }
        }
        
    }
}
