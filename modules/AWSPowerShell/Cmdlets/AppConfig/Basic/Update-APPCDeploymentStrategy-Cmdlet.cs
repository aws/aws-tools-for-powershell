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
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// Updates a deployment strategy.
    /// </summary>
    [Cmdlet("Update", "APPCDeploymentStrategy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.UpdateDeploymentStrategyResponse")]
    [AWSCmdlet("Calls the AWS AppConfig UpdateDeploymentStrategy API operation.", Operation = new[] {"UpdateDeploymentStrategy"}, SelectReturnType = typeof(Amazon.AppConfig.Model.UpdateDeploymentStrategyResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.UpdateDeploymentStrategyResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.UpdateDeploymentStrategyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAPPCDeploymentStrategyCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        #region Parameter DeploymentDurationInMinute
        /// <summary>
        /// <para>
        /// <para>Total amount of time for a deployment to last.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentDurationInMinutes")]
        public System.Int32? DeploymentDurationInMinute { get; set; }
        #endregion
        
        #region Parameter DeploymentStrategyId
        /// <summary>
        /// <para>
        /// <para>The deployment strategy ID.</para>
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
        public System.String DeploymentStrategyId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the deployment strategy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FinalBakeTimeInMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time AppConfig monitors for alarms before considering the deployment
        /// to be complete and no longer eligible for automatic roll back.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FinalBakeTimeInMinutes")]
        public System.Int32? FinalBakeTimeInMinute { get; set; }
        #endregion
        
        #region Parameter GrowthFactor
        /// <summary>
        /// <para>
        /// <para>The percentage of targets to receive a deployed configuration during each interval.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? GrowthFactor { get; set; }
        #endregion
        
        #region Parameter GrowthType
        /// <summary>
        /// <para>
        /// <para>The algorithm used to define how percentage grows over time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppConfig.GrowthType")]
        public Amazon.AppConfig.GrowthType GrowthType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.UpdateDeploymentStrategyResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.UpdateDeploymentStrategyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DeploymentStrategyId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DeploymentStrategyId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DeploymentStrategyId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeploymentStrategyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APPCDeploymentStrategy (UpdateDeploymentStrategy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.UpdateDeploymentStrategyResponse, UpdateAPPCDeploymentStrategyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DeploymentStrategyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeploymentDurationInMinute = this.DeploymentDurationInMinute;
            context.DeploymentStrategyId = this.DeploymentStrategyId;
            #if MODULAR
            if (this.DeploymentStrategyId == null && ParameterWasBound(nameof(this.DeploymentStrategyId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentStrategyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.FinalBakeTimeInMinute = this.FinalBakeTimeInMinute;
            context.GrowthFactor = this.GrowthFactor;
            context.GrowthType = this.GrowthType;
            
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
            var request = new Amazon.AppConfig.Model.UpdateDeploymentStrategyRequest();
            
            if (cmdletContext.DeploymentDurationInMinute != null)
            {
                request.DeploymentDurationInMinutes = cmdletContext.DeploymentDurationInMinute.Value;
            }
            if (cmdletContext.DeploymentStrategyId != null)
            {
                request.DeploymentStrategyId = cmdletContext.DeploymentStrategyId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FinalBakeTimeInMinute != null)
            {
                request.FinalBakeTimeInMinutes = cmdletContext.FinalBakeTimeInMinute.Value;
            }
            if (cmdletContext.GrowthFactor != null)
            {
                request.GrowthFactor = cmdletContext.GrowthFactor.Value;
            }
            if (cmdletContext.GrowthType != null)
            {
                request.GrowthType = cmdletContext.GrowthType;
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
        
        private Amazon.AppConfig.Model.UpdateDeploymentStrategyResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.UpdateDeploymentStrategyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "UpdateDeploymentStrategy");
            try
            {
                #if DESKTOP
                return client.UpdateDeploymentStrategy(request);
                #elif CORECLR
                return client.UpdateDeploymentStrategyAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DeploymentDurationInMinute { get; set; }
            public System.String DeploymentStrategyId { get; set; }
            public System.String Description { get; set; }
            public System.Int32? FinalBakeTimeInMinute { get; set; }
            public System.Single? GrowthFactor { get; set; }
            public Amazon.AppConfig.GrowthType GrowthType { get; set; }
            public System.Func<Amazon.AppConfig.Model.UpdateDeploymentStrategyResponse, UpdateAPPCDeploymentStrategyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
