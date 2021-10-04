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
using Amazon.Batch;
using Amazon.Batch.Model;

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Updates an Batch compute environment.
    /// </summary>
    [Cmdlet("Update", "BATComputeEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.UpdateComputeEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Batch UpdateComputeEnvironment API operation.", Operation = new[] {"UpdateComputeEnvironment"}, SelectReturnType = typeof(Amazon.Batch.Model.UpdateComputeEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.UpdateComputeEnvironmentResponse",
        "This cmdlet returns an Amazon.Batch.Model.UpdateComputeEnvironmentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBATComputeEnvironmentCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        #region Parameter ComputeEnvironment
        /// <summary>
        /// <para>
        /// <para>The name or full Amazon Resource Name (ARN) of the compute environment to update.</para>
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
        public System.String ComputeEnvironment { get; set; }
        #endregion
        
        #region Parameter ComputeResources_DesiredvCpu
        /// <summary>
        /// <para>
        /// <para>The desired number of Amazon EC2 vCPUS in the compute environment.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources, and
        /// shouldn't be specified.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_DesiredvCpus")]
        public System.Int32? ComputeResources_DesiredvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_MaxvCpu
        /// <summary>
        /// <para>
        /// <para>The maximum number of Amazon EC2 vCPUs that an environment can reach.</para><note><para>With both <code>BEST_FIT_PROGRESSIVE</code> and <code>SPOT_CAPACITY_OPTIMIZED</code>
        /// allocation strategies, Batch might need to exceed <code>maxvCpus</code> to meet your
        /// capacity requirements. In this event, Batch never exceeds <code>maxvCpus</code> by
        /// more than a single instance. That is, no more than a single instance from among those
        /// specified in your compute environment.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_MaxvCpus")]
        public System.Int32? ComputeResources_MaxvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_MinvCpu
        /// <summary>
        /// <para>
        /// <para>The minimum number of Amazon EC2 vCPUs that an environment should maintain.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources, and
        /// shouldn't be specified.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_MinvCpus")]
        public System.Int32? ComputeResources_MinvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 security groups associated with instances launched in the compute environment.
        /// This parameter is required for Fargate compute resources, where it can contain up
        /// to 5 security groups. This can't be specified for EC2 compute resources. Providing
        /// an empty list is handled as if this parameter wasn't specified and no change is made.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_SecurityGroupIds")]
        public System.String[] ComputeResources_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The full Amazon Resource Name (ARN) of the IAM role that allows Batch to make calls
        /// to other Amazon Web Services services on your behalf. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/service_IAM_role.html">Batch
        /// service IAM role</a> in the <i>Batch User Guide</i>.</para><important><para>If the compute environment has a service-linked role, it can't be changed to use a
        /// regular IAM role. Likewise, if the compute environment has a regular IAM role, it
        /// can't be changed to use a service-linked role.</para></important><para>If your specified role has a path other than <code>/</code>, then you must either
        /// specify the full role ARN (this is recommended) or prefix the role name with the path.</para><note><para>Depending on how you created your Batch service role, its ARN might contain the <code>service-role</code>
        /// path prefix. When you only specify the name of the service role, Batch assumes that
        /// your ARN doesn't use the <code>service-role</code> path prefix. Because of this, we
        /// recommend that you specify the full ARN of your service role when you create compute
        /// environments.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state of the compute environment. Compute environments in the <code>ENABLED</code>
        /// state can accept jobs from a queue and scale in or out automatically based on the
        /// workload demand of its associated queues.</para><para>If the state is <code>ENABLED</code>, then the Batch scheduler can attempt to place
        /// jobs from an associated job queue on the compute resources within the environment.
        /// If the compute environment is managed, then it can scale its instances out or in automatically,
        /// based on the job queue demand.</para><para>If the state is <code>DISABLED</code>, then the Batch scheduler doesn't attempt to
        /// place jobs within the environment. Jobs in a <code>STARTING</code> or <code>RUNNING</code>
        /// state continue to progress normally. Managed compute environments in the <code>DISABLED</code>
        /// state don't scale out. However, they scale in to <code>minvCpus</code> value after
        /// instances become idle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.CEState")]
        public Amazon.Batch.CEState State { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Subnet
        /// <summary>
        /// <para>
        /// <para>The VPC subnets where the compute resources are launched. Fargate compute resources
        /// can contain up to 16 subnets. Providing an empty list will be handled as if this parameter
        /// wasn't specified and no change is made. This can't be specified for EC2 compute resources.
        /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">VPCs
        /// and Subnets</a> in the <i>Amazon VPC User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_Subnets")]
        public System.String[] ComputeResources_Subnet { get; set; }
        #endregion
        
        #region Parameter UnmanagedvCpu
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs expected to be used for an unmanaged compute environment.
        /// This parameter should not be specified for a managed compute environment. This parameter
        /// is only used for fair share scheduling to reserve vCPU capacity for new share identifiers.
        /// If this parameter is not provided for a fair share job queue, no vCPU capacity will
        /// be reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UnmanagedvCpus")]
        public System.Int32? UnmanagedvCpu { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.UpdateComputeEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.UpdateComputeEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ComputeEnvironment parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ComputeEnvironment' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ComputeEnvironment' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ComputeEnvironment), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BATComputeEnvironment (UpdateComputeEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.UpdateComputeEnvironmentResponse, UpdateBATComputeEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ComputeEnvironment;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ComputeEnvironment = this.ComputeEnvironment;
            #if MODULAR
            if (this.ComputeEnvironment == null && ParameterWasBound(nameof(this.ComputeEnvironment)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeEnvironment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputeResources_DesiredvCpu = this.ComputeResources_DesiredvCpu;
            context.ComputeResources_MaxvCpu = this.ComputeResources_MaxvCpu;
            context.ComputeResources_MinvCpu = this.ComputeResources_MinvCpu;
            if (this.ComputeResources_SecurityGroupId != null)
            {
                context.ComputeResources_SecurityGroupId = new List<System.String>(this.ComputeResources_SecurityGroupId);
            }
            if (this.ComputeResources_Subnet != null)
            {
                context.ComputeResources_Subnet = new List<System.String>(this.ComputeResources_Subnet);
            }
            context.ServiceRole = this.ServiceRole;
            context.State = this.State;
            context.UnmanagedvCpu = this.UnmanagedvCpu;
            
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
            var requestComputeResourcesIsNull = true;
            request.ComputeResources = new Amazon.Batch.Model.ComputeResourceUpdate();
            System.Int32? requestComputeResources_computeResources_DesiredvCpu = null;
            if (cmdletContext.ComputeResources_DesiredvCpu != null)
            {
                requestComputeResources_computeResources_DesiredvCpu = cmdletContext.ComputeResources_DesiredvCpu.Value;
            }
            if (requestComputeResources_computeResources_DesiredvCpu != null)
            {
                request.ComputeResources.DesiredvCpus = requestComputeResources_computeResources_DesiredvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_MaxvCpu = null;
            if (cmdletContext.ComputeResources_MaxvCpu != null)
            {
                requestComputeResources_computeResources_MaxvCpu = cmdletContext.ComputeResources_MaxvCpu.Value;
            }
            if (requestComputeResources_computeResources_MaxvCpu != null)
            {
                request.ComputeResources.MaxvCpus = requestComputeResources_computeResources_MaxvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_MinvCpu = null;
            if (cmdletContext.ComputeResources_MinvCpu != null)
            {
                requestComputeResources_computeResources_MinvCpu = cmdletContext.ComputeResources_MinvCpu.Value;
            }
            if (requestComputeResources_computeResources_MinvCpu != null)
            {
                request.ComputeResources.MinvCpus = requestComputeResources_computeResources_MinvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            List<System.String> requestComputeResources_computeResources_SecurityGroupId = null;
            if (cmdletContext.ComputeResources_SecurityGroupId != null)
            {
                requestComputeResources_computeResources_SecurityGroupId = cmdletContext.ComputeResources_SecurityGroupId;
            }
            if (requestComputeResources_computeResources_SecurityGroupId != null)
            {
                request.ComputeResources.SecurityGroupIds = requestComputeResources_computeResources_SecurityGroupId;
                requestComputeResourcesIsNull = false;
            }
            List<System.String> requestComputeResources_computeResources_Subnet = null;
            if (cmdletContext.ComputeResources_Subnet != null)
            {
                requestComputeResources_computeResources_Subnet = cmdletContext.ComputeResources_Subnet;
            }
            if (requestComputeResources_computeResources_Subnet != null)
            {
                request.ComputeResources.Subnets = requestComputeResources_computeResources_Subnet;
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
            if (cmdletContext.UnmanagedvCpu != null)
            {
                request.UnmanagedvCpus = cmdletContext.UnmanagedvCpu.Value;
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
        
        private Amazon.Batch.Model.UpdateComputeEnvironmentResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.UpdateComputeEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "UpdateComputeEnvironment");
            try
            {
                #if DESKTOP
                return client.UpdateComputeEnvironment(request);
                #elif CORECLR
                return client.UpdateComputeEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ComputeResources_DesiredvCpu { get; set; }
            public System.Int32? ComputeResources_MaxvCpu { get; set; }
            public System.Int32? ComputeResources_MinvCpu { get; set; }
            public List<System.String> ComputeResources_SecurityGroupId { get; set; }
            public List<System.String> ComputeResources_Subnet { get; set; }
            public System.String ServiceRole { get; set; }
            public Amazon.Batch.CEState State { get; set; }
            public System.Int32? UnmanagedvCpu { get; set; }
            public System.Func<Amazon.Batch.Model.UpdateComputeEnvironmentResponse, UpdateBATComputeEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
