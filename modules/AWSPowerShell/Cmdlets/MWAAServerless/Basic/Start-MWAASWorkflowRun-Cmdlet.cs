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
using Amazon.MWAAServerless;
using Amazon.MWAAServerless.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MWAAS
{
    /// <summary>
    /// Starts a new execution of a workflow. This operation creates a workflow run that executes
    /// the tasks that are defined in the workflow. Amazon Managed Workflows for Apache Airflow
    /// Serverless schedules the workflow execution across its managed Airflow environment,
    /// automatically scaling ECS worker tasks based on the workload. The service handles
    /// task isolation, dependency resolution, and provides comprehensive monitoring and logging
    /// throughout the execution lifecycle.
    /// </summary>
    [Cmdlet("Start", "MWAASWorkflowRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MWAAServerless.Model.StartWorkflowRunResponse")]
    [AWSCmdlet("Calls the AmazonMWAAServerless StartWorkflowRun API operation.", Operation = new[] {"StartWorkflowRun"}, SelectReturnType = typeof(Amazon.MWAAServerless.Model.StartWorkflowRunResponse))]
    [AWSCmdletOutput("Amazon.MWAAServerless.Model.StartWorkflowRunResponse",
        "This cmdlet returns an Amazon.MWAAServerless.Model.StartWorkflowRunResponse object containing multiple properties."
    )]
    public partial class StartMWAASWorkflowRunCmdlet : AmazonMWAAServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OverrideParameter
        /// <summary>
        /// <para>
        /// <para>Optional parameters to override default workflow parameters for this specific run.
        /// These parameters are passed to the workflow during execution and can be used to customize
        /// behavior without modifying the workflow definition. Parameters are made available
        /// as environment variables to tasks and you can reference them within the YAML workflow
        /// definition using standard parameter substitution syntax.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OverrideParameters")]
        public System.Collections.Hashtable OverrideParameter { get; set; }
        #endregion
        
        #region Parameter WorkflowArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the workflow you want to run.</para>
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
        public System.String WorkflowArn { get; set; }
        #endregion
        
        #region Parameter WorkflowVersion
        /// <summary>
        /// <para>
        /// <para>Optional. The specific version of the workflow to execute. If not specified, the latest
        /// version is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkflowVersion { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. This token prevents duplicate workflow run requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MWAAServerless.Model.StartWorkflowRunResponse).
        /// Specifying the name of a property of type Amazon.MWAAServerless.Model.StartWorkflowRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkflowArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-MWAASWorkflowRun (StartWorkflowRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MWAAServerless.Model.StartWorkflowRunResponse, StartMWAASWorkflowRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.OverrideParameter != null)
            {
                context.OverrideParameter = new Dictionary<System.String, Amazon.Runtime.Documents.Document>(StringComparer.Ordinal);
                foreach (var hashKey in this.OverrideParameter.Keys)
                {
                    context.OverrideParameter.Add((String)hashKey, Amazon.PowerShell.Common.DocumentHelper.ToDocument(this.OverrideParameter[hashKey]));
                }
            }
            context.WorkflowArn = this.WorkflowArn;
            #if MODULAR
            if (this.WorkflowArn == null && ParameterWasBound(nameof(this.WorkflowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowVersion = this.WorkflowVersion;
            
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
            var request = new Amazon.MWAAServerless.Model.StartWorkflowRunRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.OverrideParameter != null)
            {
                request.OverrideParameters = cmdletContext.OverrideParameter;
            }
            if (cmdletContext.WorkflowArn != null)
            {
                request.WorkflowArn = cmdletContext.WorkflowArn;
            }
            if (cmdletContext.WorkflowVersion != null)
            {
                request.WorkflowVersion = cmdletContext.WorkflowVersion;
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
        
        private Amazon.MWAAServerless.Model.StartWorkflowRunResponse CallAWSServiceOperation(IAmazonMWAAServerless client, Amazon.MWAAServerless.Model.StartWorkflowRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonMWAAServerless", "StartWorkflowRun");
            try
            {
                return client.StartWorkflowRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.Runtime.Documents.Document> OverrideParameter { get; set; }
            public System.String WorkflowArn { get; set; }
            public System.String WorkflowVersion { get; set; }
            public System.Func<Amazon.MWAAServerless.Model.StartWorkflowRunResponse, StartMWAASWorkflowRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
