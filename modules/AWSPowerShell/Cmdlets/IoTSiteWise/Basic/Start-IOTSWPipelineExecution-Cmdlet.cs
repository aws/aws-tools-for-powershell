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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Starts execution of a pipeline in the specified workspace. Each compute node runs
    /// according to the DAG dependency order defined in the pipeline. Nodes without dependencies
    /// start immediately, while dependent nodes wait for all upstream nodes to complete successfully.
    /// 
    ///  
    /// <para>
    /// You can provide runtime environment variable overrides that take the highest priority
    /// in the environment variable hierarchy, without modifying the pipeline definition.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "IOTSWPipelineExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT SiteWise StartPipelineExecution API operation.", Operation = new[] {"StartPipelineExecution"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.StartPipelineExecutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTSiteWise.Model.StartPipelineExecutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTSiteWise.Model.StartPipelineExecutionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartIOTSWPipelineExecutionCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExecutionEnvironmentVariableOverrides_ComputeNode
        /// <summary>
        /// <para>
        /// <para>Per-compute-node environment variable overrides. Each entry maps a compute node name
        /// to its environment variable overrides.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionEnvironmentVariableOverrides_ComputeNodes")]
        public System.Collections.Hashtable ExecutionEnvironmentVariableOverrides_ComputeNode { get; set; }
        #endregion
        
        #region Parameter ExecutionMountOverrides_ComputeNode
        /// <summary>
        /// <para>
        /// <para>The mount overrides for each compute node, keyed by compute node name.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionMountOverrides_ComputeNodes")]
        public System.Collections.Hashtable ExecutionMountOverrides_ComputeNode { get; set; }
        #endregion
        
        #region Parameter ExecutionPriority
        /// <summary>
        /// <para>
        /// <para>Scheduling priority for the execution. Lower values indicate higher priority. Defaults
        /// to 2 when not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ExecutionPriority { get; set; }
        #endregion
        
        #region Parameter ExecutionEnvironmentVariableOverrides_Global
        /// <summary>
        /// <para>
        /// <para>Global environment variables that apply to all compute nodes in the pipeline execution.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ExecutionEnvironmentVariableOverrides_Global { get; set; }
        #endregion
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline to execute.</para>
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
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter WorkspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the workspace containing the pipeline.</para>
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
        public System.String WorkspaceName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you retry a request that completed successfully using the same client
        /// token, the server returns the cached result from the original successful request without
        /// performing the operation again.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PipelineExecutionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.StartPipelineExecutionResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.StartPipelineExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PipelineExecutionId";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.PipelineName),
                nameof(this.WorkspaceName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTSWPipelineExecution (StartPipelineExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.StartPipelineExecutionResponse, StartIOTSWPipelineExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.ExecutionEnvironmentVariableOverrides_ComputeNode != null)
            {
                context.ExecutionEnvironmentVariableOverrides_ComputeNode = new Dictionary<System.String, Dictionary<System.String, System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExecutionEnvironmentVariableOverrides_ComputeNode.Keys)
                {
                    context.ExecutionEnvironmentVariableOverrides_ComputeNode.Add((String)hashKey, (Dictionary<System.String,System.String>)(this.ExecutionEnvironmentVariableOverrides_ComputeNode[hashKey]));
                }
            }
            if (this.ExecutionEnvironmentVariableOverrides_Global != null)
            {
                context.ExecutionEnvironmentVariableOverrides_Global = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExecutionEnvironmentVariableOverrides_Global.Keys)
                {
                    context.ExecutionEnvironmentVariableOverrides_Global.Add((String)hashKey, (System.String)(this.ExecutionEnvironmentVariableOverrides_Global[hashKey]));
                }
            }
            if (this.ExecutionMountOverrides_ComputeNode != null)
            {
                context.ExecutionMountOverrides_ComputeNode = new Dictionary<System.String, List<Amazon.IoTSiteWise.Model.Mount>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExecutionMountOverrides_ComputeNode.Keys)
                {
                    object hashValue = this.ExecutionMountOverrides_ComputeNode[hashKey];
                    if (hashValue == null)
                    {
                        context.ExecutionMountOverrides_ComputeNode.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.IoTSiteWise.Model.Mount>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.IoTSiteWise.Model.Mount)s);
                    }
                    context.ExecutionMountOverrides_ComputeNode.Add((String)hashKey, valueSet);
                }
            }
            context.ExecutionPriority = this.ExecutionPriority;
            context.PipelineName = this.PipelineName;
            #if MODULAR
            if (this.PipelineName == null && ParameterWasBound(nameof(this.PipelineName)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkspaceName = this.WorkspaceName;
            #if MODULAR
            if (this.WorkspaceName == null && ParameterWasBound(nameof(this.WorkspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.StartPipelineExecutionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ExecutionEnvironmentVariableOverrides
            var requestExecutionEnvironmentVariableOverridesIsNull = true;
            request.ExecutionEnvironmentVariableOverrides = new Amazon.IoTSiteWise.Model.ExecutionEnvironmentVariables();
            Dictionary<System.String, Dictionary<System.String, System.String>> requestExecutionEnvironmentVariableOverrides_executionEnvironmentVariableOverrides_ComputeNode = null;
            if (cmdletContext.ExecutionEnvironmentVariableOverrides_ComputeNode != null)
            {
                requestExecutionEnvironmentVariableOverrides_executionEnvironmentVariableOverrides_ComputeNode = cmdletContext.ExecutionEnvironmentVariableOverrides_ComputeNode;
            }
            if (requestExecutionEnvironmentVariableOverrides_executionEnvironmentVariableOverrides_ComputeNode != null)
            {
                request.ExecutionEnvironmentVariableOverrides.ComputeNodes = requestExecutionEnvironmentVariableOverrides_executionEnvironmentVariableOverrides_ComputeNode;
                requestExecutionEnvironmentVariableOverridesIsNull = false;
            }
            Dictionary<System.String, System.String> requestExecutionEnvironmentVariableOverrides_executionEnvironmentVariableOverrides_Global = null;
            if (cmdletContext.ExecutionEnvironmentVariableOverrides_Global != null)
            {
                requestExecutionEnvironmentVariableOverrides_executionEnvironmentVariableOverrides_Global = cmdletContext.ExecutionEnvironmentVariableOverrides_Global;
            }
            if (requestExecutionEnvironmentVariableOverrides_executionEnvironmentVariableOverrides_Global != null)
            {
                request.ExecutionEnvironmentVariableOverrides.Global = requestExecutionEnvironmentVariableOverrides_executionEnvironmentVariableOverrides_Global;
                requestExecutionEnvironmentVariableOverridesIsNull = false;
            }
             // determine if request.ExecutionEnvironmentVariableOverrides should be set to null
            if (requestExecutionEnvironmentVariableOverridesIsNull)
            {
                request.ExecutionEnvironmentVariableOverrides = null;
            }
            
             // populate ExecutionMountOverrides
            var requestExecutionMountOverridesIsNull = true;
            request.ExecutionMountOverrides = new Amazon.IoTSiteWise.Model.MountOverrides();
            Dictionary<System.String, List<Amazon.IoTSiteWise.Model.Mount>> requestExecutionMountOverrides_executionMountOverrides_ComputeNode = null;
            if (cmdletContext.ExecutionMountOverrides_ComputeNode != null)
            {
                requestExecutionMountOverrides_executionMountOverrides_ComputeNode = cmdletContext.ExecutionMountOverrides_ComputeNode;
            }
            if (requestExecutionMountOverrides_executionMountOverrides_ComputeNode != null)
            {
                request.ExecutionMountOverrides.ComputeNodes = requestExecutionMountOverrides_executionMountOverrides_ComputeNode;
                requestExecutionMountOverridesIsNull = false;
            }
             // determine if request.ExecutionMountOverrides should be set to null
            if (requestExecutionMountOverridesIsNull)
            {
                request.ExecutionMountOverrides = null;
            }
            if (cmdletContext.ExecutionPriority != null)
            {
                request.ExecutionPriority = cmdletContext.ExecutionPriority.Value;
            }
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
            }
            if (cmdletContext.WorkspaceName != null)
            {
                request.WorkspaceName = cmdletContext.WorkspaceName;
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
        
        private Amazon.IoTSiteWise.Model.StartPipelineExecutionResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.StartPipelineExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "StartPipelineExecution");
            try
            {
                return client.StartPipelineExecutionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, Dictionary<System.String, System.String>> ExecutionEnvironmentVariableOverrides_ComputeNode { get; set; }
            public Dictionary<System.String, System.String> ExecutionEnvironmentVariableOverrides_Global { get; set; }
            public Dictionary<System.String, List<Amazon.IoTSiteWise.Model.Mount>> ExecutionMountOverrides_ComputeNode { get; set; }
            public System.Int32? ExecutionPriority { get; set; }
            public System.String PipelineName { get; set; }
            public System.String WorkspaceName { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.StartPipelineExecutionResponse, StartIOTSWPipelineExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PipelineExecutionId;
        }
        
    }
}
