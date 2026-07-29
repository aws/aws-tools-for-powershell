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
    /// Updates an existing task in the specified workspace. Only the fields provided in the
    /// request are updated; fields not included in the request are preserved unchanged.
    /// </summary>
    [Cmdlet("Update", "IOTSWTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.UpdateTaskResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise UpdateTask API operation.", Operation = new[] {"UpdateTask"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.UpdateTaskResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.UpdateTaskResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.UpdateTaskResponse object containing multiple properties."
    )]
    public partial class UpdateIOTSWTaskCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TaskConfiguration_ContainerTaskConfiguration_Command
        /// <summary>
        /// <para>
        /// <para>The command to execute in the container.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TaskConfiguration_ContainerTaskConfiguration_Command { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TaskConfiguration_ContainerTaskConfiguration_EcrUri
        /// <summary>
        /// <para>
        /// <para>The Amazon ECR image URI for the task container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskConfiguration_ContainerTaskConfiguration_EcrUri { get; set; }
        #endregion
        
        #region Parameter TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>Environment variables passed to the container at runtime.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariables")]
        public System.Collections.Hashtable TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter TaskConfiguration_ContainerTaskConfiguration_ProcessingType
        /// <summary>
        /// <para>
        /// <para>The processing type for compute resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.ProcessingType")]
        public Amazon.IoTSiteWise.ProcessingType TaskConfiguration_ContainerTaskConfiguration_ProcessingType { get; set; }
        #endregion
        
        #region Parameter TaskConfiguration_ContainerTaskConfiguration_ProcessingUnit
        /// <summary>
        /// <para>
        /// <para>The processing unit allocation that determines the vCPU, memory, and GPU resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.ProcessingUnit")]
        public Amazon.IoTSiteWise.ProcessingUnit TaskConfiguration_ContainerTaskConfiguration_ProcessingUnit { get; set; }
        #endregion
        
        #region Parameter TaskConfiguration_ContainerTaskConfiguration_TaskExecutionRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants the containerized workload permissions to access
        /// AWS resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskConfiguration_ContainerTaskConfiguration_TaskExecutionRole { get; set; }
        #endregion
        
        #region Parameter TaskName
        /// <summary>
        /// <para>
        /// <para>The name of the task to update.</para>
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
        public System.String TaskName { get; set; }
        #endregion
        
        #region Parameter TaskConfiguration_ContainerTaskConfiguration_TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The timeout in seconds for task execution. Default: 3600 (1 hour).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskConfiguration_ContainerTaskConfiguration_TimeoutSeconds")]
        public System.Int64? TaskConfiguration_ContainerTaskConfiguration_TimeoutSecond { get; set; }
        #endregion
        
        #region Parameter WorkspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the workspace.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.UpdateTaskResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.UpdateTaskResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSWTask (UpdateTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.UpdateTaskResponse, UpdateIOTSWTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            if (this.TaskConfiguration_ContainerTaskConfiguration_Command != null)
            {
                context.TaskConfiguration_ContainerTaskConfiguration_Command = new List<System.String>(this.TaskConfiguration_ContainerTaskConfiguration_Command);
            }
            context.TaskConfiguration_ContainerTaskConfiguration_EcrUri = this.TaskConfiguration_ContainerTaskConfiguration_EcrUri;
            if (this.TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariable != null)
            {
                context.TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariable.Keys)
                {
                    context.TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariable.Add((String)hashKey, (System.String)(this.TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariable[hashKey]));
                }
            }
            context.TaskConfiguration_ContainerTaskConfiguration_ProcessingType = this.TaskConfiguration_ContainerTaskConfiguration_ProcessingType;
            context.TaskConfiguration_ContainerTaskConfiguration_ProcessingUnit = this.TaskConfiguration_ContainerTaskConfiguration_ProcessingUnit;
            context.TaskConfiguration_ContainerTaskConfiguration_TaskExecutionRole = this.TaskConfiguration_ContainerTaskConfiguration_TaskExecutionRole;
            context.TaskConfiguration_ContainerTaskConfiguration_TimeoutSecond = this.TaskConfiguration_ContainerTaskConfiguration_TimeoutSecond;
            context.TaskName = this.TaskName;
            #if MODULAR
            if (this.TaskName == null && ParameterWasBound(nameof(this.TaskName)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.UpdateTaskRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate TaskConfiguration
            var requestTaskConfigurationIsNull = true;
            request.TaskConfiguration = new Amazon.IoTSiteWise.Model.TaskConfiguration();
            Amazon.IoTSiteWise.Model.ContainerTaskConfiguration requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration = null;
            
             // populate ContainerTaskConfiguration
            var requestTaskConfiguration_taskConfiguration_ContainerTaskConfigurationIsNull = true;
            requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration = new Amazon.IoTSiteWise.Model.ContainerTaskConfiguration();
            List<System.String> requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_Command = null;
            if (cmdletContext.TaskConfiguration_ContainerTaskConfiguration_Command != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_Command = cmdletContext.TaskConfiguration_ContainerTaskConfiguration_Command;
            }
            if (requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_Command != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration.Command = requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_Command;
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfigurationIsNull = false;
            }
            System.String requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_EcrUri = null;
            if (cmdletContext.TaskConfiguration_ContainerTaskConfiguration_EcrUri != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_EcrUri = cmdletContext.TaskConfiguration_ContainerTaskConfiguration_EcrUri;
            }
            if (requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_EcrUri != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration.EcrUri = requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_EcrUri;
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_EnvironmentVariable = null;
            if (cmdletContext.TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariable != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_EnvironmentVariable = cmdletContext.TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariable;
            }
            if (requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_EnvironmentVariable != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration.EnvironmentVariables = requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_EnvironmentVariable;
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfigurationIsNull = false;
            }
            Amazon.IoTSiteWise.ProcessingType requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_ProcessingType = null;
            if (cmdletContext.TaskConfiguration_ContainerTaskConfiguration_ProcessingType != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_ProcessingType = cmdletContext.TaskConfiguration_ContainerTaskConfiguration_ProcessingType;
            }
            if (requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_ProcessingType != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration.ProcessingType = requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_ProcessingType;
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfigurationIsNull = false;
            }
            Amazon.IoTSiteWise.ProcessingUnit requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_ProcessingUnit = null;
            if (cmdletContext.TaskConfiguration_ContainerTaskConfiguration_ProcessingUnit != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_ProcessingUnit = cmdletContext.TaskConfiguration_ContainerTaskConfiguration_ProcessingUnit;
            }
            if (requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_ProcessingUnit != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration.ProcessingUnit = requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_ProcessingUnit;
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfigurationIsNull = false;
            }
            System.String requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_TaskExecutionRole = null;
            if (cmdletContext.TaskConfiguration_ContainerTaskConfiguration_TaskExecutionRole != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_TaskExecutionRole = cmdletContext.TaskConfiguration_ContainerTaskConfiguration_TaskExecutionRole;
            }
            if (requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_TaskExecutionRole != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration.TaskExecutionRole = requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_TaskExecutionRole;
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfigurationIsNull = false;
            }
            System.Int64? requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_TimeoutSecond = null;
            if (cmdletContext.TaskConfiguration_ContainerTaskConfiguration_TimeoutSecond != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_TimeoutSecond = cmdletContext.TaskConfiguration_ContainerTaskConfiguration_TimeoutSecond.Value;
            }
            if (requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_TimeoutSecond != null)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration.TimeoutSeconds = requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_taskConfiguration_ContainerTaskConfiguration_TimeoutSecond.Value;
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfigurationIsNull = false;
            }
             // determine if requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration should be set to null
            if (requestTaskConfiguration_taskConfiguration_ContainerTaskConfigurationIsNull)
            {
                requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration = null;
            }
            if (requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration != null)
            {
                request.TaskConfiguration.ContainerTaskConfiguration = requestTaskConfiguration_taskConfiguration_ContainerTaskConfiguration;
                requestTaskConfigurationIsNull = false;
            }
             // determine if request.TaskConfiguration should be set to null
            if (requestTaskConfigurationIsNull)
            {
                request.TaskConfiguration = null;
            }
            if (cmdletContext.TaskName != null)
            {
                request.TaskName = cmdletContext.TaskName;
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
        
        private Amazon.IoTSiteWise.Model.UpdateTaskResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.UpdateTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "UpdateTask");
            try
            {
                return client.UpdateTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<System.String> TaskConfiguration_ContainerTaskConfiguration_Command { get; set; }
            public System.String TaskConfiguration_ContainerTaskConfiguration_EcrUri { get; set; }
            public Dictionary<System.String, System.String> TaskConfiguration_ContainerTaskConfiguration_EnvironmentVariable { get; set; }
            public Amazon.IoTSiteWise.ProcessingType TaskConfiguration_ContainerTaskConfiguration_ProcessingType { get; set; }
            public Amazon.IoTSiteWise.ProcessingUnit TaskConfiguration_ContainerTaskConfiguration_ProcessingUnit { get; set; }
            public System.String TaskConfiguration_ContainerTaskConfiguration_TaskExecutionRole { get; set; }
            public System.Int64? TaskConfiguration_ContainerTaskConfiguration_TimeoutSecond { get; set; }
            public System.String TaskName { get; set; }
            public System.String WorkspaceName { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.UpdateTaskResponse, UpdateIOTSWTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
