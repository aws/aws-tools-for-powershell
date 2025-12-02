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
using Amazon.NovaAct;
using Amazon.NovaAct.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NOVA
{
    /// <summary>
    /// Creates a new AI task (act) within a session that can interact with tools and perform
    /// specific actions.
    /// </summary>
    [Cmdlet("New", "NOVAAct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NovaAct.Model.CreateActResponse")]
    [AWSCmdlet("Calls the Amazon Nova Act CreateAct API operation.", Operation = new[] {"CreateAct"}, SelectReturnType = typeof(Amazon.NovaAct.Model.CreateActResponse))]
    [AWSCmdletOutput("Amazon.NovaAct.Model.CreateActResponse",
        "This cmdlet returns an Amazon.NovaAct.Model.CreateActResponse object containing multiple properties."
    )]
    public partial class NewNOVAActCmdlet : AmazonNovaActClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the session to create the act in.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Task
        /// <summary>
        /// <para>
        /// <para>The task description that defines what the act should accomplish.</para>
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
        public System.String Task { get; set; }
        #endregion
        
        #region Parameter ToolSpec
        /// <summary>
        /// <para>
        /// <para>A list of tool specifications that the act can invoke to complete its task.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ToolSpecs")]
        public Amazon.NovaAct.Model.ToolSpec[] ToolSpec { get; set; }
        #endregion
        
        #region Parameter WorkflowDefinitionName
        /// <summary>
        /// <para>
        /// <para>The name of the workflow definition containing the session.</para>
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
        public System.String WorkflowDefinitionName { get; set; }
        #endregion
        
        #region Parameter WorkflowRunId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the workflow run containing the session.</para>
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
        public System.String WorkflowRunId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NovaAct.Model.CreateActResponse).
        /// Specifying the name of a property of type Amazon.NovaAct.Model.CreateActResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.SessionId),
                nameof(this.WorkflowRunId),
                nameof(this.WorkflowDefinitionName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NOVAAct (CreateAct)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NovaAct.Model.CreateActResponse, NewNOVAActCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Task = this.Task;
            #if MODULAR
            if (this.Task == null && ParameterWasBound(nameof(this.Task)))
            {
                WriteWarning("You are passing $null as a value for parameter Task which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ToolSpec != null)
            {
                context.ToolSpec = new List<Amazon.NovaAct.Model.ToolSpec>(this.ToolSpec);
            }
            context.WorkflowDefinitionName = this.WorkflowDefinitionName;
            #if MODULAR
            if (this.WorkflowDefinitionName == null && ParameterWasBound(nameof(this.WorkflowDefinitionName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowDefinitionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowRunId = this.WorkflowRunId;
            #if MODULAR
            if (this.WorkflowRunId == null && ParameterWasBound(nameof(this.WorkflowRunId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowRunId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NovaAct.Model.CreateActRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            if (cmdletContext.Task != null)
            {
                request.Task = cmdletContext.Task;
            }
            if (cmdletContext.ToolSpec != null)
            {
                request.ToolSpecs = cmdletContext.ToolSpec;
            }
            if (cmdletContext.WorkflowDefinitionName != null)
            {
                request.WorkflowDefinitionName = cmdletContext.WorkflowDefinitionName;
            }
            if (cmdletContext.WorkflowRunId != null)
            {
                request.WorkflowRunId = cmdletContext.WorkflowRunId;
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
        
        private Amazon.NovaAct.Model.CreateActResponse CallAWSServiceOperation(IAmazonNovaAct client, Amazon.NovaAct.Model.CreateActRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nova Act", "CreateAct");
            try
            {
                return client.CreateActAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SessionId { get; set; }
            public System.String Task { get; set; }
            public List<Amazon.NovaAct.Model.ToolSpec> ToolSpec { get; set; }
            public System.String WorkflowDefinitionName { get; set; }
            public System.String WorkflowRunId { get; set; }
            public System.Func<Amazon.NovaAct.Model.CreateActResponse, NewNOVAActCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
