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

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates an edge deployment plan, consisting of multiple stages. Each stage may have
    /// a different deployment configuration and devices.
    /// </summary>
    [Cmdlet("New", "SMEdgeDeploymentPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateEdgeDeploymentPlan API operation.", Operation = new[] {"CreateEdgeDeploymentPlan"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateEdgeDeploymentPlanResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateEdgeDeploymentPlanResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateEdgeDeploymentPlanResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMEdgeDeploymentPlanCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeviceFleetName
        /// <summary>
        /// <para>
        /// <para>The device fleet used for this edge deployment plan.</para>
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
        
        #region Parameter EdgeDeploymentPlanName
        /// <summary>
        /// <para>
        /// <para>The name of the edge deployment plan.</para>
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
        public System.String EdgeDeploymentPlanName { get; set; }
        #endregion
        
        #region Parameter ModelConfig
        /// <summary>
        /// <para>
        /// <para>List of models associated with the edge deployment plan.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ModelConfigs")]
        public Amazon.SageMaker.Model.EdgeDeploymentModelConfig[] ModelConfig { get; set; }
        #endregion
        
        #region Parameter Stage
        /// <summary>
        /// <para>
        /// <para>List of stages of the edge deployment plan. The number of stages is limited to 10
        /// per deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Stages")]
        public Amazon.SageMaker.Model.DeploymentStage[] Stage { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>List of tags with which to tag the edge deployment plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EdgeDeploymentPlanArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateEdgeDeploymentPlanResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateEdgeDeploymentPlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EdgeDeploymentPlanArn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EdgeDeploymentPlanName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMEdgeDeploymentPlan (CreateEdgeDeploymentPlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateEdgeDeploymentPlanResponse, NewSMEdgeDeploymentPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeviceFleetName = this.DeviceFleetName;
            #if MODULAR
            if (this.DeviceFleetName == null && ParameterWasBound(nameof(this.DeviceFleetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceFleetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EdgeDeploymentPlanName = this.EdgeDeploymentPlanName;
            #if MODULAR
            if (this.EdgeDeploymentPlanName == null && ParameterWasBound(nameof(this.EdgeDeploymentPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter EdgeDeploymentPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ModelConfig != null)
            {
                context.ModelConfig = new List<Amazon.SageMaker.Model.EdgeDeploymentModelConfig>(this.ModelConfig);
            }
            #if MODULAR
            if (this.ModelConfig == null && ParameterWasBound(nameof(this.ModelConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Stage != null)
            {
                context.Stage = new List<Amazon.SageMaker.Model.DeploymentStage>(this.Stage);
            }
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
            var request = new Amazon.SageMaker.Model.CreateEdgeDeploymentPlanRequest();
            
            if (cmdletContext.DeviceFleetName != null)
            {
                request.DeviceFleetName = cmdletContext.DeviceFleetName;
            }
            if (cmdletContext.EdgeDeploymentPlanName != null)
            {
                request.EdgeDeploymentPlanName = cmdletContext.EdgeDeploymentPlanName;
            }
            if (cmdletContext.ModelConfig != null)
            {
                request.ModelConfigs = cmdletContext.ModelConfig;
            }
            if (cmdletContext.Stage != null)
            {
                request.Stages = cmdletContext.Stage;
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
        
        private Amazon.SageMaker.Model.CreateEdgeDeploymentPlanResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateEdgeDeploymentPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateEdgeDeploymentPlan");
            try
            {
                return client.CreateEdgeDeploymentPlanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DeviceFleetName { get; set; }
            public System.String EdgeDeploymentPlanName { get; set; }
            public List<Amazon.SageMaker.Model.EdgeDeploymentModelConfig> ModelConfig { get; set; }
            public List<Amazon.SageMaker.Model.DeploymentStage> Stage { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateEdgeDeploymentPlanResponse, NewSMEdgeDeploymentPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EdgeDeploymentPlanArn;
        }
        
    }
}
