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
    /// Registers an AWS Batch job definition.
    /// </summary>
    [Cmdlet("Register", "BATJobDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.RegisterJobDefinitionResponse")]
    [AWSCmdlet("Calls the AWS Batch RegisterJobDefinition API operation.", Operation = new[] {"RegisterJobDefinition"})]
    [AWSCmdletOutput("Amazon.Batch.Model.RegisterJobDefinitionResponse",
        "This cmdlet returns a Amazon.Batch.Model.RegisterJobDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterBATJobDefinitionCmdlet : AmazonBatchClientCmdlet, IExecutor
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
        
        #region Parameter ContainerProperties_Command
        /// <summary>
        /// <para>
        /// <para>The command that is passed to the container. This parameter maps to <code>Cmd</code>
        /// in the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/">Docker
        /// Remote API</a> and the <code>COMMAND</code> parameter to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>. For more information, see <a href="https://docs.docker.com/engine/reference/builder/#cmd">https://docs.docker.com/engine/reference/builder/#cmd</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ContainerProperties_Command { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to pass to a container. This parameter maps to <code>Env</code>
        /// in the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/">Docker
        /// Remote API</a> and the <code>--env</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para><important><para>We do not recommend using plain text environment variables for sensitive information,
        /// such as credential data.</para></important><note><para>Environment variables must not start with <code>AWS_BATCH</code>; this naming convention
        /// is reserved for variables that are set by the AWS Batch service.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Batch.Model.KeyValuePair[] ContainerProperties_Environment { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Image
        /// <summary>
        /// <para>
        /// <para>The image used to start a container. This string is passed directly to the Docker
        /// daemon. Images in the Docker Hub registry are available by default. Other repositories
        /// are specified with <code><i>repository-url</i>/<i>image</i>:<i>tag</i></code>. Up
        /// to 255 letters (uppercase and lowercase), numbers, hyphens, underscores, colons, periods,
        /// forward slashes, and number signs are allowed. This parameter maps to <code>Image</code>
        /// in the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/">Docker
        /// Remote API</a> and the <code>IMAGE</code> parameter of <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para><ul><li><para>Images in Amazon ECR repositories use the full registry and repository URI (for example,
        /// <code>012345678910.dkr.ecr.&lt;region-name&gt;.amazonaws.com/&lt;repository-name&gt;</code>).
        /// </para></li><li><para>Images in official repositories on Docker Hub use a single name (for example, <code>ubuntu</code>
        /// or <code>mongo</code>).</para></li><li><para>Images in other repositories on Docker Hub are qualified with an organization name
        /// (for example, <code>amazon/amazon-ecs-agent</code>).</para></li><li><para>Images in other online repositories are qualified further by a domain name (for example,
        /// <code>quay.io/assemblyline/ubuntu</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContainerProperties_Image { get; set; }
        #endregion
        
        #region Parameter JobDefinitionName
        /// <summary>
        /// <para>
        /// <para>The name of the job definition to register. Up to 128 letters (uppercase and lowercase),
        /// numbers, hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String JobDefinitionName { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_JobRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the container can assume for AWS
        /// permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContainerProperties_JobRoleArn { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Memory
        /// <summary>
        /// <para>
        /// <para>The hard limit (in MiB) of memory to present to the container. If your container attempts
        /// to exceed the memory specified here, the container is killed. This parameter maps
        /// to <code>Memory</code> in the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/">Docker
        /// Remote API</a> and the <code>--memory</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>. You must specify at least 4 MiB of memory for a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ContainerProperties_Memory { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_MountPoint
        /// <summary>
        /// <para>
        /// <para>The mount points for data volumes in your container. This parameter maps to <code>Volumes</code>
        /// in the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/">Docker
        /// Remote API</a> and the <code>--volume</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContainerProperties_MountPoints")]
        public Amazon.Batch.Model.MountPoint[] ContainerProperties_MountPoint { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>Default parameter substitution placeholders to set in the job definition. Parameters
        /// are specified as a key-value pair mapping. Parameters in a <code>SubmitJob</code>
        /// request override any corresponding parameter defaults from the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Privileged
        /// <summary>
        /// <para>
        /// <para>When this parameter is true, the container is given elevated privileges on the host
        /// container instance (similar to the <code>root</code> user). This parameter maps to
        /// <code>Privileged</code> in the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/">Docker
        /// Remote API</a> and the <code>--privileged</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ContainerProperties_Privileged { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_ReadonlyRootFilesystem
        /// <summary>
        /// <para>
        /// <para>When this parameter is true, the container is given read-only access to its root file
        /// system. This parameter maps to <code>ReadonlyRootfs</code> in the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/">Docker
        /// Remote API</a> and the <code>--read-only</code> option to <code>docker run</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ContainerProperties_ReadonlyRootFilesystem { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Batch.JobDefinitionType")]
        public Amazon.Batch.JobDefinitionType Type { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Ulimit
        /// <summary>
        /// <para>
        /// <para>A list of <code>ulimits</code> to set in the container. This parameter maps to <code>Ulimits</code>
        /// in the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/">Docker
        /// Remote API</a> and the <code>--ulimit</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContainerProperties_Ulimits")]
        public Amazon.Batch.Model.Ulimit[] ContainerProperties_Ulimit { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_User
        /// <summary>
        /// <para>
        /// <para>The user name to use inside the container. This parameter maps to <code>User</code>
        /// in the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/">Docker
        /// Remote API</a> and the <code>--user</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContainerProperties_User { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Vcpu
        /// <summary>
        /// <para>
        /// <para>The number of vCPUs reserved for the container. This parameter maps to <code>CpuShares</code>
        /// in the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/#create-a-container">Create
        /// a container</a> section of the <a href="https://docs.docker.com/engine/reference/api/docker_remote_api_v1.23/">Docker
        /// Remote API</a> and the <code>--cpu-shares</code> option to <a href="https://docs.docker.com/engine/reference/run/">docker
        /// run</a>. Each vCPU is equivalent to 1,024 CPU shares. You must specify at least 1
        /// vCPU.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContainerProperties_Vcpus")]
        public System.Int32 ContainerProperties_Vcpu { get; set; }
        #endregion
        
        #region Parameter ContainerProperties_Volume
        /// <summary>
        /// <para>
        /// <para>A list of data volumes used in a job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContainerProperties_Volumes")]
        public Amazon.Batch.Model.Volume[] ContainerProperties_Volume { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobDefinitionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-BATJobDefinition (RegisterJobDefinition)"))
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
            
            if (this.ContainerProperties_Command != null)
            {
                context.ContainerProperties_Command = new List<System.String>(this.ContainerProperties_Command);
            }
            if (this.ContainerProperties_Environment != null)
            {
                context.ContainerProperties_Environment = new List<Amazon.Batch.Model.KeyValuePair>(this.ContainerProperties_Environment);
            }
            context.ContainerProperties_Image = this.ContainerProperties_Image;
            context.ContainerProperties_JobRoleArn = this.ContainerProperties_JobRoleArn;
            if (ParameterWasBound("ContainerProperties_Memory"))
                context.ContainerProperties_Memory = this.ContainerProperties_Memory;
            if (this.ContainerProperties_MountPoint != null)
            {
                context.ContainerProperties_MountPoints = new List<Amazon.Batch.Model.MountPoint>(this.ContainerProperties_MountPoint);
            }
            if (ParameterWasBound("ContainerProperties_Privileged"))
                context.ContainerProperties_Privileged = this.ContainerProperties_Privileged;
            if (ParameterWasBound("ContainerProperties_ReadonlyRootFilesystem"))
                context.ContainerProperties_ReadonlyRootFilesystem = this.ContainerProperties_ReadonlyRootFilesystem;
            if (this.ContainerProperties_Ulimit != null)
            {
                context.ContainerProperties_Ulimits = new List<Amazon.Batch.Model.Ulimit>(this.ContainerProperties_Ulimit);
            }
            context.ContainerProperties_User = this.ContainerProperties_User;
            if (ParameterWasBound("ContainerProperties_Vcpu"))
                context.ContainerProperties_Vcpus = this.ContainerProperties_Vcpu;
            if (this.ContainerProperties_Volume != null)
            {
                context.ContainerProperties_Volumes = new List<Amazon.Batch.Model.Volume>(this.ContainerProperties_Volume);
            }
            context.JobDefinitionName = this.JobDefinitionName;
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
            context.Type = this.Type;
            
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
            var request = new Amazon.Batch.Model.RegisterJobDefinitionRequest();
            
            
             // populate ContainerProperties
            bool requestContainerPropertiesIsNull = true;
            request.ContainerProperties = new Amazon.Batch.Model.ContainerProperties();
            List<System.String> requestContainerProperties_containerProperties_Command = null;
            if (cmdletContext.ContainerProperties_Command != null)
            {
                requestContainerProperties_containerProperties_Command = cmdletContext.ContainerProperties_Command;
            }
            if (requestContainerProperties_containerProperties_Command != null)
            {
                request.ContainerProperties.Command = requestContainerProperties_containerProperties_Command;
                requestContainerPropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.KeyValuePair> requestContainerProperties_containerProperties_Environment = null;
            if (cmdletContext.ContainerProperties_Environment != null)
            {
                requestContainerProperties_containerProperties_Environment = cmdletContext.ContainerProperties_Environment;
            }
            if (requestContainerProperties_containerProperties_Environment != null)
            {
                request.ContainerProperties.Environment = requestContainerProperties_containerProperties_Environment;
                requestContainerPropertiesIsNull = false;
            }
            System.String requestContainerProperties_containerProperties_Image = null;
            if (cmdletContext.ContainerProperties_Image != null)
            {
                requestContainerProperties_containerProperties_Image = cmdletContext.ContainerProperties_Image;
            }
            if (requestContainerProperties_containerProperties_Image != null)
            {
                request.ContainerProperties.Image = requestContainerProperties_containerProperties_Image;
                requestContainerPropertiesIsNull = false;
            }
            System.String requestContainerProperties_containerProperties_JobRoleArn = null;
            if (cmdletContext.ContainerProperties_JobRoleArn != null)
            {
                requestContainerProperties_containerProperties_JobRoleArn = cmdletContext.ContainerProperties_JobRoleArn;
            }
            if (requestContainerProperties_containerProperties_JobRoleArn != null)
            {
                request.ContainerProperties.JobRoleArn = requestContainerProperties_containerProperties_JobRoleArn;
                requestContainerPropertiesIsNull = false;
            }
            System.Int32? requestContainerProperties_containerProperties_Memory = null;
            if (cmdletContext.ContainerProperties_Memory != null)
            {
                requestContainerProperties_containerProperties_Memory = cmdletContext.ContainerProperties_Memory.Value;
            }
            if (requestContainerProperties_containerProperties_Memory != null)
            {
                request.ContainerProperties.Memory = requestContainerProperties_containerProperties_Memory.Value;
                requestContainerPropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.MountPoint> requestContainerProperties_containerProperties_MountPoint = null;
            if (cmdletContext.ContainerProperties_MountPoints != null)
            {
                requestContainerProperties_containerProperties_MountPoint = cmdletContext.ContainerProperties_MountPoints;
            }
            if (requestContainerProperties_containerProperties_MountPoint != null)
            {
                request.ContainerProperties.MountPoints = requestContainerProperties_containerProperties_MountPoint;
                requestContainerPropertiesIsNull = false;
            }
            System.Boolean? requestContainerProperties_containerProperties_Privileged = null;
            if (cmdletContext.ContainerProperties_Privileged != null)
            {
                requestContainerProperties_containerProperties_Privileged = cmdletContext.ContainerProperties_Privileged.Value;
            }
            if (requestContainerProperties_containerProperties_Privileged != null)
            {
                request.ContainerProperties.Privileged = requestContainerProperties_containerProperties_Privileged.Value;
                requestContainerPropertiesIsNull = false;
            }
            System.Boolean? requestContainerProperties_containerProperties_ReadonlyRootFilesystem = null;
            if (cmdletContext.ContainerProperties_ReadonlyRootFilesystem != null)
            {
                requestContainerProperties_containerProperties_ReadonlyRootFilesystem = cmdletContext.ContainerProperties_ReadonlyRootFilesystem.Value;
            }
            if (requestContainerProperties_containerProperties_ReadonlyRootFilesystem != null)
            {
                request.ContainerProperties.ReadonlyRootFilesystem = requestContainerProperties_containerProperties_ReadonlyRootFilesystem.Value;
                requestContainerPropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.Ulimit> requestContainerProperties_containerProperties_Ulimit = null;
            if (cmdletContext.ContainerProperties_Ulimits != null)
            {
                requestContainerProperties_containerProperties_Ulimit = cmdletContext.ContainerProperties_Ulimits;
            }
            if (requestContainerProperties_containerProperties_Ulimit != null)
            {
                request.ContainerProperties.Ulimits = requestContainerProperties_containerProperties_Ulimit;
                requestContainerPropertiesIsNull = false;
            }
            System.String requestContainerProperties_containerProperties_User = null;
            if (cmdletContext.ContainerProperties_User != null)
            {
                requestContainerProperties_containerProperties_User = cmdletContext.ContainerProperties_User;
            }
            if (requestContainerProperties_containerProperties_User != null)
            {
                request.ContainerProperties.User = requestContainerProperties_containerProperties_User;
                requestContainerPropertiesIsNull = false;
            }
            System.Int32? requestContainerProperties_containerProperties_Vcpu = null;
            if (cmdletContext.ContainerProperties_Vcpus != null)
            {
                requestContainerProperties_containerProperties_Vcpu = cmdletContext.ContainerProperties_Vcpus.Value;
            }
            if (requestContainerProperties_containerProperties_Vcpu != null)
            {
                request.ContainerProperties.Vcpus = requestContainerProperties_containerProperties_Vcpu.Value;
                requestContainerPropertiesIsNull = false;
            }
            List<Amazon.Batch.Model.Volume> requestContainerProperties_containerProperties_Volume = null;
            if (cmdletContext.ContainerProperties_Volumes != null)
            {
                requestContainerProperties_containerProperties_Volume = cmdletContext.ContainerProperties_Volumes;
            }
            if (requestContainerProperties_containerProperties_Volume != null)
            {
                request.ContainerProperties.Volumes = requestContainerProperties_containerProperties_Volume;
                requestContainerPropertiesIsNull = false;
            }
             // determine if request.ContainerProperties should be set to null
            if (requestContainerPropertiesIsNull)
            {
                request.ContainerProperties = null;
            }
            if (cmdletContext.JobDefinitionName != null)
            {
                request.JobDefinitionName = cmdletContext.JobDefinitionName;
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
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.Batch.Model.RegisterJobDefinitionResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.RegisterJobDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "RegisterJobDefinition");
            try
            {
                #if DESKTOP
                return client.RegisterJobDefinition(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RegisterJobDefinitionAsync(request);
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
            public List<System.String> ContainerProperties_Command { get; set; }
            public List<Amazon.Batch.Model.KeyValuePair> ContainerProperties_Environment { get; set; }
            public System.String ContainerProperties_Image { get; set; }
            public System.String ContainerProperties_JobRoleArn { get; set; }
            public System.Int32? ContainerProperties_Memory { get; set; }
            public List<Amazon.Batch.Model.MountPoint> ContainerProperties_MountPoints { get; set; }
            public System.Boolean? ContainerProperties_Privileged { get; set; }
            public System.Boolean? ContainerProperties_ReadonlyRootFilesystem { get; set; }
            public List<Amazon.Batch.Model.Ulimit> ContainerProperties_Ulimits { get; set; }
            public System.String ContainerProperties_User { get; set; }
            public System.Int32? ContainerProperties_Vcpus { get; set; }
            public List<Amazon.Batch.Model.Volume> ContainerProperties_Volumes { get; set; }
            public System.String JobDefinitionName { get; set; }
            public Dictionary<System.String, System.String> Parameters { get; set; }
            public System.Int32? RetryStrategy_Attempts { get; set; }
            public Amazon.Batch.JobDefinitionType Type { get; set; }
        }
        
    }
}
