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
    /// Creates a profiling group.
    /// </summary>
    [Cmdlet("New", "CGPProfilingGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeGuruProfiler.Model.ProfilingGroupDescription")]
    [AWSCmdlet("Calls the Amazon CodeGuru Profiler CreateProfilingGroup API operation.", Operation = new[] {"CreateProfilingGroup"}, SelectReturnType = typeof(Amazon.CodeGuruProfiler.Model.CreateProfilingGroupResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruProfiler.Model.ProfilingGroupDescription or Amazon.CodeGuruProfiler.Model.CreateProfilingGroupResponse",
        "This cmdlet returns an Amazon.CodeGuruProfiler.Model.ProfilingGroupDescription object.",
        "The service call response (type Amazon.CodeGuruProfiler.Model.CreateProfilingGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCGPProfilingGroupCmdlet : AmazonCodeGuruProfilerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComputePlatform
        /// <summary>
        /// <para>
        /// <para> The compute platform of the profiling group. Use <c>AWSLambda</c> if your application
        /// runs on AWS Lambda. Use <c>Default</c> if your application runs on a compute platform
        /// that is not AWS Lambda, such an Amazon EC2 instance, an on-premises server, or a different
        /// platform. If not specified, <c>Default</c> is used. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeGuruProfiler.ComputePlatform")]
        public Amazon.CodeGuruProfiler.ComputePlatform ComputePlatform { get; set; }
        #endregion
        
        #region Parameter AgentOrchestrationConfig_ProfilingEnabled
        /// <summary>
        /// <para>
        /// <para> A <c>Boolean</c> that specifies whether the profiling agent collects profiling data
        /// or not. Set to <c>true</c> to enable profiling. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AgentOrchestrationConfig_ProfilingEnabled { get; set; }
        #endregion
        
        #region Parameter ProfilingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the profiling group to create.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A list of tags to add to the created profiling group. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> Amazon CodeGuru Profiler uses this universally unique identifier (UUID) to prevent
        /// the accidental creation of duplicate profiling groups if there are failures and retries.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProfilingGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruProfiler.Model.CreateProfilingGroupResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruProfiler.Model.CreateProfilingGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProfilingGroup";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGPProfilingGroup (CreateProfilingGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruProfiler.Model.CreateProfilingGroupResponse, NewCGPProfilingGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentOrchestrationConfig_ProfilingEnabled = this.AgentOrchestrationConfig_ProfilingEnabled;
            context.ClientToken = this.ClientToken;
            context.ComputePlatform = this.ComputePlatform;
            context.ProfilingGroupName = this.ProfilingGroupName;
            #if MODULAR
            if (this.ProfilingGroupName == null && ParameterWasBound(nameof(this.ProfilingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfilingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.CodeGuruProfiler.Model.CreateProfilingGroupRequest();
            
            
             // populate AgentOrchestrationConfig
            var requestAgentOrchestrationConfigIsNull = true;
            request.AgentOrchestrationConfig = new Amazon.CodeGuruProfiler.Model.AgentOrchestrationConfig();
            System.Boolean? requestAgentOrchestrationConfig_agentOrchestrationConfig_ProfilingEnabled = null;
            if (cmdletContext.AgentOrchestrationConfig_ProfilingEnabled != null)
            {
                requestAgentOrchestrationConfig_agentOrchestrationConfig_ProfilingEnabled = cmdletContext.AgentOrchestrationConfig_ProfilingEnabled.Value;
            }
            if (requestAgentOrchestrationConfig_agentOrchestrationConfig_ProfilingEnabled != null)
            {
                request.AgentOrchestrationConfig.ProfilingEnabled = requestAgentOrchestrationConfig_agentOrchestrationConfig_ProfilingEnabled.Value;
                requestAgentOrchestrationConfigIsNull = false;
            }
             // determine if request.AgentOrchestrationConfig should be set to null
            if (requestAgentOrchestrationConfigIsNull)
            {
                request.AgentOrchestrationConfig = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ComputePlatform != null)
            {
                request.ComputePlatform = cmdletContext.ComputePlatform;
            }
            if (cmdletContext.ProfilingGroupName != null)
            {
                request.ProfilingGroupName = cmdletContext.ProfilingGroupName;
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
        
        private Amazon.CodeGuruProfiler.Model.CreateProfilingGroupResponse CallAWSServiceOperation(IAmazonCodeGuruProfiler client, Amazon.CodeGuruProfiler.Model.CreateProfilingGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Profiler", "CreateProfilingGroup");
            try
            {
                return client.CreateProfilingGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AgentOrchestrationConfig_ProfilingEnabled { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.CodeGuruProfiler.ComputePlatform ComputePlatform { get; set; }
            public System.String ProfilingGroupName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CodeGuruProfiler.Model.CreateProfilingGroupResponse, NewCGPProfilingGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProfilingGroup;
        }
        
    }
}
