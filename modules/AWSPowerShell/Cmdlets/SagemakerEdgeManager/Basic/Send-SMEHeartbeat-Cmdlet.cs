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
using Amazon.SagemakerEdgeManager;
using Amazon.SagemakerEdgeManager.Model;

namespace Amazon.PowerShell.Cmdlets.SME
{
    /// <summary>
    /// Use to get the current status of devices registered on SageMaker Edge Manager.
    /// </summary>
    [Cmdlet("Send", "SMEHeartbeat", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Sagemaker Edge Manager SendHeartbeat API operation.", Operation = new[] {"SendHeartbeat"}, SelectReturnType = typeof(Amazon.SagemakerEdgeManager.Model.SendHeartbeatResponse))]
    [AWSCmdletOutput("None or Amazon.SagemakerEdgeManager.Model.SendHeartbeatResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SagemakerEdgeManager.Model.SendHeartbeatResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSMEHeartbeatCmdlet : AmazonSagemakerEdgeManagerClientCmdlet, IExecutor
    {
        
        #region Parameter AgentMetric
        /// <summary>
        /// <para>
        /// <para>For internal use. Returns a list of SageMaker Edge Manager agent operating metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentMetrics")]
        public Amazon.SagemakerEdgeManager.Model.EdgeMetric[] AgentMetric { get; set; }
        #endregion
        
        #region Parameter AgentVersion
        /// <summary>
        /// <para>
        /// <para>Returns the version of the agent.</para>
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
        public System.String AgentVersion { get; set; }
        #endregion
        
        #region Parameter DeploymentResult_DeploymentEndTime
        /// <summary>
        /// <para>
        /// <para>The timestamp of when the deployment was ended, and the agent got the deployment results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DeploymentResult_DeploymentEndTime { get; set; }
        #endregion
        
        #region Parameter DeploymentResult_DeploymentModel
        /// <summary>
        /// <para>
        /// <para>Returns a list of models deployed on the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentResult_DeploymentModels")]
        public Amazon.SagemakerEdgeManager.Model.DeploymentModel[] DeploymentResult_DeploymentModel { get; set; }
        #endregion
        
        #region Parameter DeploymentResult_DeploymentName
        /// <summary>
        /// <para>
        /// <para>The name and unique ID of the deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentResult_DeploymentName { get; set; }
        #endregion
        
        #region Parameter DeploymentResult_DeploymentStartTime
        /// <summary>
        /// <para>
        /// <para>The timestamp of when the deployment was started on the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DeploymentResult_DeploymentStartTime { get; set; }
        #endregion
        
        #region Parameter DeploymentResult_DeploymentStatus
        /// <summary>
        /// <para>
        /// <para>Returns the bucket error code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentResult_DeploymentStatus { get; set; }
        #endregion
        
        #region Parameter DeploymentResult_DeploymentStatusMessage
        /// <summary>
        /// <para>
        /// <para>Returns the detailed error message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentResult_DeploymentStatusMessage { get; set; }
        #endregion
        
        #region Parameter DeviceFleetName
        /// <summary>
        /// <para>
        /// <para>The name of the fleet that the device belongs to.</para>
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
        public System.String DeviceFleetName { get; set; }
        #endregion
        
        #region Parameter DeviceName
        /// <summary>
        /// <para>
        /// <para>The unique name of the device.</para>
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
        public System.String DeviceName { get; set; }
        #endregion
        
        #region Parameter Model
        /// <summary>
        /// <para>
        /// <para>Returns a list of models deployed on the the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Models")]
        public Amazon.SagemakerEdgeManager.Model.Model[] Model { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SagemakerEdgeManager.Model.SendHeartbeatResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DeviceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DeviceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DeviceName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SMEHeartbeat (SendHeartbeat)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SagemakerEdgeManager.Model.SendHeartbeatResponse, SendSMEHeartbeatCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DeviceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AgentMetric != null)
            {
                context.AgentMetric = new List<Amazon.SagemakerEdgeManager.Model.EdgeMetric>(this.AgentMetric);
            }
            context.AgentVersion = this.AgentVersion;
            #if MODULAR
            if (this.AgentVersion == null && ParameterWasBound(nameof(this.AgentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeploymentResult_DeploymentEndTime = this.DeploymentResult_DeploymentEndTime;
            if (this.DeploymentResult_DeploymentModel != null)
            {
                context.DeploymentResult_DeploymentModel = new List<Amazon.SagemakerEdgeManager.Model.DeploymentModel>(this.DeploymentResult_DeploymentModel);
            }
            context.DeploymentResult_DeploymentName = this.DeploymentResult_DeploymentName;
            context.DeploymentResult_DeploymentStartTime = this.DeploymentResult_DeploymentStartTime;
            context.DeploymentResult_DeploymentStatus = this.DeploymentResult_DeploymentStatus;
            context.DeploymentResult_DeploymentStatusMessage = this.DeploymentResult_DeploymentStatusMessage;
            context.DeviceFleetName = this.DeviceFleetName;
            #if MODULAR
            if (this.DeviceFleetName == null && ParameterWasBound(nameof(this.DeviceFleetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceFleetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceName = this.DeviceName;
            #if MODULAR
            if (this.DeviceName == null && ParameterWasBound(nameof(this.DeviceName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Model != null)
            {
                context.Model = new List<Amazon.SagemakerEdgeManager.Model.Model>(this.Model);
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
            var request = new Amazon.SagemakerEdgeManager.Model.SendHeartbeatRequest();
            
            if (cmdletContext.AgentMetric != null)
            {
                request.AgentMetrics = cmdletContext.AgentMetric;
            }
            if (cmdletContext.AgentVersion != null)
            {
                request.AgentVersion = cmdletContext.AgentVersion;
            }
            
             // populate DeploymentResult
            var requestDeploymentResultIsNull = true;
            request.DeploymentResult = new Amazon.SagemakerEdgeManager.Model.DeploymentResult();
            System.DateTime? requestDeploymentResult_deploymentResult_DeploymentEndTime = null;
            if (cmdletContext.DeploymentResult_DeploymentEndTime != null)
            {
                requestDeploymentResult_deploymentResult_DeploymentEndTime = cmdletContext.DeploymentResult_DeploymentEndTime.Value;
            }
            if (requestDeploymentResult_deploymentResult_DeploymentEndTime != null)
            {
                request.DeploymentResult.DeploymentEndTime = requestDeploymentResult_deploymentResult_DeploymentEndTime.Value;
                requestDeploymentResultIsNull = false;
            }
            List<Amazon.SagemakerEdgeManager.Model.DeploymentModel> requestDeploymentResult_deploymentResult_DeploymentModel = null;
            if (cmdletContext.DeploymentResult_DeploymentModel != null)
            {
                requestDeploymentResult_deploymentResult_DeploymentModel = cmdletContext.DeploymentResult_DeploymentModel;
            }
            if (requestDeploymentResult_deploymentResult_DeploymentModel != null)
            {
                request.DeploymentResult.DeploymentModels = requestDeploymentResult_deploymentResult_DeploymentModel;
                requestDeploymentResultIsNull = false;
            }
            System.String requestDeploymentResult_deploymentResult_DeploymentName = null;
            if (cmdletContext.DeploymentResult_DeploymentName != null)
            {
                requestDeploymentResult_deploymentResult_DeploymentName = cmdletContext.DeploymentResult_DeploymentName;
            }
            if (requestDeploymentResult_deploymentResult_DeploymentName != null)
            {
                request.DeploymentResult.DeploymentName = requestDeploymentResult_deploymentResult_DeploymentName;
                requestDeploymentResultIsNull = false;
            }
            System.DateTime? requestDeploymentResult_deploymentResult_DeploymentStartTime = null;
            if (cmdletContext.DeploymentResult_DeploymentStartTime != null)
            {
                requestDeploymentResult_deploymentResult_DeploymentStartTime = cmdletContext.DeploymentResult_DeploymentStartTime.Value;
            }
            if (requestDeploymentResult_deploymentResult_DeploymentStartTime != null)
            {
                request.DeploymentResult.DeploymentStartTime = requestDeploymentResult_deploymentResult_DeploymentStartTime.Value;
                requestDeploymentResultIsNull = false;
            }
            System.String requestDeploymentResult_deploymentResult_DeploymentStatus = null;
            if (cmdletContext.DeploymentResult_DeploymentStatus != null)
            {
                requestDeploymentResult_deploymentResult_DeploymentStatus = cmdletContext.DeploymentResult_DeploymentStatus;
            }
            if (requestDeploymentResult_deploymentResult_DeploymentStatus != null)
            {
                request.DeploymentResult.DeploymentStatus = requestDeploymentResult_deploymentResult_DeploymentStatus;
                requestDeploymentResultIsNull = false;
            }
            System.String requestDeploymentResult_deploymentResult_DeploymentStatusMessage = null;
            if (cmdletContext.DeploymentResult_DeploymentStatusMessage != null)
            {
                requestDeploymentResult_deploymentResult_DeploymentStatusMessage = cmdletContext.DeploymentResult_DeploymentStatusMessage;
            }
            if (requestDeploymentResult_deploymentResult_DeploymentStatusMessage != null)
            {
                request.DeploymentResult.DeploymentStatusMessage = requestDeploymentResult_deploymentResult_DeploymentStatusMessage;
                requestDeploymentResultIsNull = false;
            }
             // determine if request.DeploymentResult should be set to null
            if (requestDeploymentResultIsNull)
            {
                request.DeploymentResult = null;
            }
            if (cmdletContext.DeviceFleetName != null)
            {
                request.DeviceFleetName = cmdletContext.DeviceFleetName;
            }
            if (cmdletContext.DeviceName != null)
            {
                request.DeviceName = cmdletContext.DeviceName;
            }
            if (cmdletContext.Model != null)
            {
                request.Models = cmdletContext.Model;
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
        
        private Amazon.SagemakerEdgeManager.Model.SendHeartbeatResponse CallAWSServiceOperation(IAmazonSagemakerEdgeManager client, Amazon.SagemakerEdgeManager.Model.SendHeartbeatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Sagemaker Edge Manager", "SendHeartbeat");
            try
            {
                #if DESKTOP
                return client.SendHeartbeat(request);
                #elif CORECLR
                return client.SendHeartbeatAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SagemakerEdgeManager.Model.EdgeMetric> AgentMetric { get; set; }
            public System.String AgentVersion { get; set; }
            public System.DateTime? DeploymentResult_DeploymentEndTime { get; set; }
            public List<Amazon.SagemakerEdgeManager.Model.DeploymentModel> DeploymentResult_DeploymentModel { get; set; }
            public System.String DeploymentResult_DeploymentName { get; set; }
            public System.DateTime? DeploymentResult_DeploymentStartTime { get; set; }
            public System.String DeploymentResult_DeploymentStatus { get; set; }
            public System.String DeploymentResult_DeploymentStatusMessage { get; set; }
            public System.String DeviceFleetName { get; set; }
            public System.String DeviceName { get; set; }
            public List<Amazon.SagemakerEdgeManager.Model.Model> Model { get; set; }
            public System.Func<Amazon.SagemakerEdgeManager.Model.SendHeartbeatResponse, SendSMEHeartbeatCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
