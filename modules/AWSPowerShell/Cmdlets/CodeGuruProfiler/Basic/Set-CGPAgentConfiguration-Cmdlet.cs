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
using Amazon.CodeGuruProfiler;
using Amazon.CodeGuruProfiler.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGP
{
    /// <summary>
    /// Used by profiler agents to report their current state and to receive remote configuration
    /// updates. For example, <c>ConfigureAgent</c> can be used to tell an agent whether to
    /// profile or not and for how long to return profiling data.
    /// </summary>
    [Cmdlet("Set", "CGPAgentConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeGuruProfiler.Model.AgentConfiguration")]
    [AWSCmdlet("Calls the Amazon CodeGuru Profiler ConfigureAgent API operation.", Operation = new[] {"ConfigureAgent"}, SelectReturnType = typeof(Amazon.CodeGuruProfiler.Model.ConfigureAgentResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruProfiler.Model.AgentConfiguration or Amazon.CodeGuruProfiler.Model.ConfigureAgentResponse",
        "This cmdlet returns an Amazon.CodeGuruProfiler.Model.AgentConfiguration object.",
        "The service call response (type Amazon.CodeGuruProfiler.Model.ConfigureAgentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetCGPAgentConfigurationCmdlet : AmazonCodeGuruProfilerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FleetInstanceId
        /// <summary>
        /// <para>
        /// <para> A universally unique identifier (UUID) for a profiling instance. For example, if
        /// the profiling instance is an Amazon EC2 instance, it is the instance ID. If it is
        /// an AWS Fargate container, it is the container's task ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FleetInstanceId { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para> Metadata captured about the compute platform the agent is running on. It includes
        /// information about sampling and reporting. The valid fields are:</para><ul><li><para><c>COMPUTE_PLATFORM</c> - The compute platform on which the agent is running </para></li><li><para><c>AGENT_ID</c> - The ID for an agent instance. </para></li><li><para><c>AWS_REQUEST_ID</c> - The AWS request ID of a Lambda invocation. </para></li><li><para><c>EXECUTION_ENVIRONMENT</c> - The execution environment a Lambda function is running
        /// on. </para></li><li><para><c>LAMBDA_FUNCTION_ARN</c> - The Amazon Resource Name (ARN) that is used to invoke
        /// a Lambda function. </para></li><li><para><c>LAMBDA_MEMORY_LIMIT_IN_MB</c> - The memory allocated to a Lambda function. </para></li><li><para><c>LAMBDA_REMAINING_TIME_IN_MILLISECONDS</c> - The time in milliseconds before execution
        /// of a Lambda function times out. </para></li><li><para><c>LAMBDA_TIME_GAP_BETWEEN_INVOKES_IN_MILLISECONDS</c> - The time in milliseconds
        /// between two invocations of a Lambda function. </para></li><li><para><c>LAMBDA_PREVIOUS_EXECUTION_TIME_IN_MILLISECONDS</c> - The time in milliseconds
        /// for the previous Lambda invocation. </para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion
        
        #region Parameter ProfilingGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the profiling group for which the configured agent is collecting profiling
        /// data. </para>
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
        public System.String ProfilingGroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Configuration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruProfiler.Model.ConfigureAgentResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruProfiler.Model.ConfigureAgentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Configuration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfilingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGPAgentConfiguration (ConfigureAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruProfiler.Model.ConfigureAgentResponse, SetCGPAgentConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FleetInstanceId = this.FleetInstanceId;
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (System.String)(this.Metadata[hashKey]));
                }
            }
            context.ProfilingGroupName = this.ProfilingGroupName;
            #if MODULAR
            if (this.ProfilingGroupName == null && ParameterWasBound(nameof(this.ProfilingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfilingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeGuruProfiler.Model.ConfigureAgentRequest();
            
            if (cmdletContext.FleetInstanceId != null)
            {
                request.FleetInstanceId = cmdletContext.FleetInstanceId;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.ProfilingGroupName != null)
            {
                request.ProfilingGroupName = cmdletContext.ProfilingGroupName;
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
        
        private Amazon.CodeGuruProfiler.Model.ConfigureAgentResponse CallAWSServiceOperation(IAmazonCodeGuruProfiler client, Amazon.CodeGuruProfiler.Model.ConfigureAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Profiler", "ConfigureAgent");
            try
            {
                return client.ConfigureAgentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FleetInstanceId { get; set; }
            public Dictionary<System.String, System.String> Metadata { get; set; }
            public System.String ProfilingGroupName { get; set; }
            public System.Func<Amazon.CodeGuruProfiler.Model.ConfigureAgentResponse, SetCGPAgentConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Configuration;
        }
        
    }
}
