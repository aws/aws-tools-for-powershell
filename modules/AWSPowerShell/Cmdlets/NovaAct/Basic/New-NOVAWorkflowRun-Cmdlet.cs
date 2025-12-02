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
using Amazon.NovaAct;
using Amazon.NovaAct.Model;

namespace Amazon.PowerShell.Cmdlets.NOVA
{
    /// <summary>
    /// Creates a new execution instance of a workflow definition with specified parameters.
    /// </summary>
    [Cmdlet("New", "NOVAWorkflowRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NovaAct.Model.CreateWorkflowRunResponse")]
    [AWSCmdlet("Calls the Amazon Nova Act CreateWorkflowRun API operation.", Operation = new[] {"CreateWorkflowRun"}, SelectReturnType = typeof(Amazon.NovaAct.Model.CreateWorkflowRunResponse))]
    [AWSCmdletOutput("Amazon.NovaAct.Model.CreateWorkflowRunResponse",
        "This cmdlet returns an Amazon.NovaAct.Model.CreateWorkflowRunResponse object containing multiple properties."
    )]
    public partial class NewNOVAWorkflowRunCmdlet : AmazonNovaActClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientInfo_CompatibilityVersion
        /// <summary>
        /// <para>
        /// <para>The compatibility version of the client, used to ensure API compatibility.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ClientInfo_CompatibilityVersion { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log group name for storing workflow execution logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the AI model to use for workflow execution.</para>
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
        public System.String ModelId { get; set; }
        #endregion
        
        #region Parameter ClientInfo_SdkVersion
        /// <summary>
        /// <para>
        /// <para>The version of the SDK being used by the client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientInfo_SdkVersion { get; set; }
        #endregion
        
        #region Parameter WorkflowDefinitionName
        /// <summary>
        /// <para>
        /// <para>The name of the workflow definition to execute.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NovaAct.Model.CreateWorkflowRunResponse).
        /// Specifying the name of a property of type Amazon.NovaAct.Model.CreateWorkflowRunResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.ModelId),
                nameof(this.WorkflowDefinitionName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NOVAWorkflowRun (CreateWorkflowRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NovaAct.Model.CreateWorkflowRunResponse, NewNOVAWorkflowRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientInfo_CompatibilityVersion = this.ClientInfo_CompatibilityVersion;
            #if MODULAR
            if (this.ClientInfo_CompatibilityVersion == null && ParameterWasBound(nameof(this.ClientInfo_CompatibilityVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientInfo_CompatibilityVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientInfo_SdkVersion = this.ClientInfo_SdkVersion;
            context.ClientToken = this.ClientToken;
            context.LogGroupName = this.LogGroupName;
            context.ModelId = this.ModelId;
            #if MODULAR
            if (this.ModelId == null && ParameterWasBound(nameof(this.ModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowDefinitionName = this.WorkflowDefinitionName;
            #if MODULAR
            if (this.WorkflowDefinitionName == null && ParameterWasBound(nameof(this.WorkflowDefinitionName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowDefinitionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NovaAct.Model.CreateWorkflowRunRequest();
            
            
             // populate ClientInfo
            var requestClientInfoIsNull = true;
            request.ClientInfo = new Amazon.NovaAct.Model.ClientInfo();
            System.Int32? requestClientInfo_clientInfo_CompatibilityVersion = null;
            if (cmdletContext.ClientInfo_CompatibilityVersion != null)
            {
                requestClientInfo_clientInfo_CompatibilityVersion = cmdletContext.ClientInfo_CompatibilityVersion.Value;
            }
            if (requestClientInfo_clientInfo_CompatibilityVersion != null)
            {
                request.ClientInfo.CompatibilityVersion = requestClientInfo_clientInfo_CompatibilityVersion.Value;
                requestClientInfoIsNull = false;
            }
            System.String requestClientInfo_clientInfo_SdkVersion = null;
            if (cmdletContext.ClientInfo_SdkVersion != null)
            {
                requestClientInfo_clientInfo_SdkVersion = cmdletContext.ClientInfo_SdkVersion;
            }
            if (requestClientInfo_clientInfo_SdkVersion != null)
            {
                request.ClientInfo.SdkVersion = requestClientInfo_clientInfo_SdkVersion;
                requestClientInfoIsNull = false;
            }
             // determine if request.ClientInfo should be set to null
            if (requestClientInfoIsNull)
            {
                request.ClientInfo = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.ModelId != null)
            {
                request.ModelId = cmdletContext.ModelId;
            }
            if (cmdletContext.WorkflowDefinitionName != null)
            {
                request.WorkflowDefinitionName = cmdletContext.WorkflowDefinitionName;
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
        
        private Amazon.NovaAct.Model.CreateWorkflowRunResponse CallAWSServiceOperation(IAmazonNovaAct client, Amazon.NovaAct.Model.CreateWorkflowRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nova Act", "CreateWorkflowRun");
            try
            {
                #if DESKTOP
                return client.CreateWorkflowRun(request);
                #elif CORECLR
                return client.CreateWorkflowRunAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ClientInfo_CompatibilityVersion { get; set; }
            public System.String ClientInfo_SdkVersion { get; set; }
            public System.String ClientToken { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String ModelId { get; set; }
            public System.String WorkflowDefinitionName { get; set; }
            public System.Func<Amazon.NovaAct.Model.CreateWorkflowRunResponse, NewNOVAWorkflowRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
