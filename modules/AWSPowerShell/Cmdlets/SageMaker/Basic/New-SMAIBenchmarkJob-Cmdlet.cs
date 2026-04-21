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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a benchmark job that runs performance benchmarks against inference infrastructure
    /// using a predefined AI workload configuration. The benchmark job measures metrics such
    /// as latency, throughput, and cost for your generative AI inference endpoints.
    /// </summary>
    [Cmdlet("New", "SMAIBenchmarkJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateAIBenchmarkJob API operation.", Operation = new[] {"CreateAIBenchmarkJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateAIBenchmarkJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateAIBenchmarkJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateAIBenchmarkJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMAIBenchmarkJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AIBenchmarkJobName
        /// <summary>
        /// <para>
        /// <para>The name of the AI benchmark job. The name must be unique within your Amazon Web Services
        /// account in the current Amazon Web Services Region.</para>
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
        public System.String AIBenchmarkJobName { get; set; }
        #endregion
        
        #region Parameter AIWorkloadConfigIdentifier
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the AI workload configuration to use for
        /// this benchmark job.</para>
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
        public System.String AIWorkloadConfigIdentifier { get; set; }
        #endregion
        
        #region Parameter BenchmarkTarget_Endpoint_Identifier
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the SageMaker endpoint to benchmark.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BenchmarkTarget_Endpoint_Identifier { get; set; }
        #endregion
        
        #region Parameter BenchmarkTarget_Endpoint_InferenceComponent
        /// <summary>
        /// <para>
        /// <para>The list of inference components to benchmark on the endpoint.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BenchmarkTarget_Endpoint_InferenceComponents")]
        public Amazon.SageMaker.Model.AIBenchmarkInferenceComponent[] BenchmarkTarget_Endpoint_InferenceComponent { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that enables Amazon SageMaker AI to
        /// perform tasks on your behalf.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3OutputLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI where benchmark results are stored.</para>
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
        public System.String OutputConfig_S3OutputLocation { get; set; }
        #endregion
        
        #region Parameter NetworkConfig_VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form <c>sg-xxxxxxxx</c>. Specify the security groups
        /// for the VPC that is specified in the <c>Subnets</c> field.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfig_VpcConfig_SecurityGroupIds")]
        public System.String[] NetworkConfig_VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter NetworkConfig_VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC to which you want to connect your training job or
        /// model. For information about the availability of specific instance types, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/instance-types-az.html">Supported
        /// Instance Types and Availability Zones</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfig_VpcConfig_Subnets")]
        public System.String[] NetworkConfig_VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to Amazon Web Services resources to help you categorize
        /// and organize them. Each tag consists of a key and a value, both of which you define.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter BenchmarkTarget_Endpoint_TargetContainerHostname
        /// <summary>
        /// <para>
        /// <para>The hostname of the specific container to target within a multi-container endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BenchmarkTarget_Endpoint_TargetContainerHostname { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AIBenchmarkJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateAIBenchmarkJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateAIBenchmarkJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AIBenchmarkJobArn";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AIBenchmarkJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMAIBenchmarkJob (CreateAIBenchmarkJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateAIBenchmarkJobResponse, NewSMAIBenchmarkJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AIBenchmarkJobName = this.AIBenchmarkJobName;
            #if MODULAR
            if (this.AIBenchmarkJobName == null && ParameterWasBound(nameof(this.AIBenchmarkJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter AIBenchmarkJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AIWorkloadConfigIdentifier = this.AIWorkloadConfigIdentifier;
            #if MODULAR
            if (this.AIWorkloadConfigIdentifier == null && ParameterWasBound(nameof(this.AIWorkloadConfigIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AIWorkloadConfigIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BenchmarkTarget_Endpoint_Identifier = this.BenchmarkTarget_Endpoint_Identifier;
            if (this.BenchmarkTarget_Endpoint_InferenceComponent != null)
            {
                context.BenchmarkTarget_Endpoint_InferenceComponent = new List<Amazon.SageMaker.Model.AIBenchmarkInferenceComponent>(this.BenchmarkTarget_Endpoint_InferenceComponent);
            }
            context.BenchmarkTarget_Endpoint_TargetContainerHostname = this.BenchmarkTarget_Endpoint_TargetContainerHostname;
            if (this.NetworkConfig_VpcConfig_SecurityGroupId != null)
            {
                context.NetworkConfig_VpcConfig_SecurityGroupId = new List<System.String>(this.NetworkConfig_VpcConfig_SecurityGroupId);
            }
            if (this.NetworkConfig_VpcConfig_Subnet != null)
            {
                context.NetworkConfig_VpcConfig_Subnet = new List<System.String>(this.NetworkConfig_VpcConfig_Subnet);
            }
            context.OutputConfig_S3OutputLocation = this.OutputConfig_S3OutputLocation;
            #if MODULAR
            if (this.OutputConfig_S3OutputLocation == null && ParameterWasBound(nameof(this.OutputConfig_S3OutputLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_S3OutputLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateAIBenchmarkJobRequest();
            
            if (cmdletContext.AIBenchmarkJobName != null)
            {
                request.AIBenchmarkJobName = cmdletContext.AIBenchmarkJobName;
            }
            if (cmdletContext.AIWorkloadConfigIdentifier != null)
            {
                request.AIWorkloadConfigIdentifier = cmdletContext.AIWorkloadConfigIdentifier;
            }
            
             // populate BenchmarkTarget
            var requestBenchmarkTargetIsNull = true;
            request.BenchmarkTarget = new Amazon.SageMaker.Model.AIBenchmarkTarget();
            Amazon.SageMaker.Model.AIBenchmarkEndpoint requestBenchmarkTarget_benchmarkTarget_Endpoint = null;
            
             // populate Endpoint
            var requestBenchmarkTarget_benchmarkTarget_EndpointIsNull = true;
            requestBenchmarkTarget_benchmarkTarget_Endpoint = new Amazon.SageMaker.Model.AIBenchmarkEndpoint();
            System.String requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_Identifier = null;
            if (cmdletContext.BenchmarkTarget_Endpoint_Identifier != null)
            {
                requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_Identifier = cmdletContext.BenchmarkTarget_Endpoint_Identifier;
            }
            if (requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_Identifier != null)
            {
                requestBenchmarkTarget_benchmarkTarget_Endpoint.Identifier = requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_Identifier;
                requestBenchmarkTarget_benchmarkTarget_EndpointIsNull = false;
            }
            List<Amazon.SageMaker.Model.AIBenchmarkInferenceComponent> requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_InferenceComponent = null;
            if (cmdletContext.BenchmarkTarget_Endpoint_InferenceComponent != null)
            {
                requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_InferenceComponent = cmdletContext.BenchmarkTarget_Endpoint_InferenceComponent;
            }
            if (requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_InferenceComponent != null)
            {
                requestBenchmarkTarget_benchmarkTarget_Endpoint.InferenceComponents = requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_InferenceComponent;
                requestBenchmarkTarget_benchmarkTarget_EndpointIsNull = false;
            }
            System.String requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_TargetContainerHostname = null;
            if (cmdletContext.BenchmarkTarget_Endpoint_TargetContainerHostname != null)
            {
                requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_TargetContainerHostname = cmdletContext.BenchmarkTarget_Endpoint_TargetContainerHostname;
            }
            if (requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_TargetContainerHostname != null)
            {
                requestBenchmarkTarget_benchmarkTarget_Endpoint.TargetContainerHostname = requestBenchmarkTarget_benchmarkTarget_Endpoint_benchmarkTarget_Endpoint_TargetContainerHostname;
                requestBenchmarkTarget_benchmarkTarget_EndpointIsNull = false;
            }
             // determine if requestBenchmarkTarget_benchmarkTarget_Endpoint should be set to null
            if (requestBenchmarkTarget_benchmarkTarget_EndpointIsNull)
            {
                requestBenchmarkTarget_benchmarkTarget_Endpoint = null;
            }
            if (requestBenchmarkTarget_benchmarkTarget_Endpoint != null)
            {
                request.BenchmarkTarget.Endpoint = requestBenchmarkTarget_benchmarkTarget_Endpoint;
                requestBenchmarkTargetIsNull = false;
            }
             // determine if request.BenchmarkTarget should be set to null
            if (requestBenchmarkTargetIsNull)
            {
                request.BenchmarkTarget = null;
            }
            
             // populate NetworkConfig
            var requestNetworkConfigIsNull = true;
            request.NetworkConfig = new Amazon.SageMaker.Model.AIBenchmarkNetworkConfig();
            Amazon.SageMaker.Model.VpcConfig requestNetworkConfig_networkConfig_VpcConfig = null;
            
             // populate VpcConfig
            var requestNetworkConfig_networkConfig_VpcConfigIsNull = true;
            requestNetworkConfig_networkConfig_VpcConfig = new Amazon.SageMaker.Model.VpcConfig();
            List<System.String> requestNetworkConfig_networkConfig_VpcConfig_networkConfig_VpcConfig_SecurityGroupId = null;
            if (cmdletContext.NetworkConfig_VpcConfig_SecurityGroupId != null)
            {
                requestNetworkConfig_networkConfig_VpcConfig_networkConfig_VpcConfig_SecurityGroupId = cmdletContext.NetworkConfig_VpcConfig_SecurityGroupId;
            }
            if (requestNetworkConfig_networkConfig_VpcConfig_networkConfig_VpcConfig_SecurityGroupId != null)
            {
                requestNetworkConfig_networkConfig_VpcConfig.SecurityGroupIds = requestNetworkConfig_networkConfig_VpcConfig_networkConfig_VpcConfig_SecurityGroupId;
                requestNetworkConfig_networkConfig_VpcConfigIsNull = false;
            }
            List<System.String> requestNetworkConfig_networkConfig_VpcConfig_networkConfig_VpcConfig_Subnet = null;
            if (cmdletContext.NetworkConfig_VpcConfig_Subnet != null)
            {
                requestNetworkConfig_networkConfig_VpcConfig_networkConfig_VpcConfig_Subnet = cmdletContext.NetworkConfig_VpcConfig_Subnet;
            }
            if (requestNetworkConfig_networkConfig_VpcConfig_networkConfig_VpcConfig_Subnet != null)
            {
                requestNetworkConfig_networkConfig_VpcConfig.Subnets = requestNetworkConfig_networkConfig_VpcConfig_networkConfig_VpcConfig_Subnet;
                requestNetworkConfig_networkConfig_VpcConfigIsNull = false;
            }
             // determine if requestNetworkConfig_networkConfig_VpcConfig should be set to null
            if (requestNetworkConfig_networkConfig_VpcConfigIsNull)
            {
                requestNetworkConfig_networkConfig_VpcConfig = null;
            }
            if (requestNetworkConfig_networkConfig_VpcConfig != null)
            {
                request.NetworkConfig.VpcConfig = requestNetworkConfig_networkConfig_VpcConfig;
                requestNetworkConfigIsNull = false;
            }
             // determine if request.NetworkConfig should be set to null
            if (requestNetworkConfigIsNull)
            {
                request.NetworkConfig = null;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.AIBenchmarkOutputConfig();
            System.String requestOutputConfig_outputConfig_S3OutputLocation = null;
            if (cmdletContext.OutputConfig_S3OutputLocation != null)
            {
                requestOutputConfig_outputConfig_S3OutputLocation = cmdletContext.OutputConfig_S3OutputLocation;
            }
            if (requestOutputConfig_outputConfig_S3OutputLocation != null)
            {
                request.OutputConfig.S3OutputLocation = requestOutputConfig_outputConfig_S3OutputLocation;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateAIBenchmarkJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateAIBenchmarkJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateAIBenchmarkJob");
            try
            {
                return client.CreateAIBenchmarkJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AIBenchmarkJobName { get; set; }
            public System.String AIWorkloadConfigIdentifier { get; set; }
            public System.String BenchmarkTarget_Endpoint_Identifier { get; set; }
            public List<Amazon.SageMaker.Model.AIBenchmarkInferenceComponent> BenchmarkTarget_Endpoint_InferenceComponent { get; set; }
            public System.String BenchmarkTarget_Endpoint_TargetContainerHostname { get; set; }
            public List<System.String> NetworkConfig_VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> NetworkConfig_VpcConfig_Subnet { get; set; }
            public System.String OutputConfig_S3OutputLocation { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateAIBenchmarkJobResponse, NewSMAIBenchmarkJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AIBenchmarkJobArn;
        }
        
    }
}
