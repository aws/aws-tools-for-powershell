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
using Amazon.Drs;
using Amazon.Drs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Updates a Recovery Plan step's name or configuration. Step type is immutable.
    /// </summary>
    [Cmdlet("Update", "EDRSRecoveryPlanStep", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Drs.Model.RecoveryPlanStep")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service UpdateRecoveryPlanStep API operation.", Operation = new[] {"UpdateRecoveryPlanStep"}, SelectReturnType = typeof(Amazon.Drs.Model.UpdateRecoveryPlanStepResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.RecoveryPlanStep or Amazon.Drs.Model.UpdateRecoveryPlanStepResponse",
        "This cmdlet returns an Amazon.Drs.Model.RecoveryPlanStep object.",
        "The service call response (type Amazon.Drs.Model.UpdateRecoveryPlanStepResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEDRSRecoveryPlanStepCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RecoveryPlanStepArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Recovery Plan step to update.</para>
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
        public System.String RecoveryPlanStepArn { get; set; }
        #endregion
        
        #region Parameter Configuration_ServerStepConfiguration_Server
        /// <summary>
        /// <para>
        /// <para>The list of servers to recover in this step.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServerStepConfiguration_Servers")]
        public Amazon.Drs.Model.RecoveryPlanServer[] Configuration_ServerStepConfiguration_Server { get; set; }
        #endregion
        
        #region Parameter StepName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StepName { get; set; }
        #endregion
        
        #region Parameter Configuration_WaitStepConfiguration_WaitDurationMinute
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_WaitStepConfiguration_WaitDurationMinutes")]
        public System.Int32? Configuration_WaitStepConfiguration_WaitDurationMinute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecoveryPlanStep'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.UpdateRecoveryPlanStepResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.UpdateRecoveryPlanStepResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecoveryPlanStep";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecoveryPlanStepArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EDRSRecoveryPlanStep (UpdateRecoveryPlanStep)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.UpdateRecoveryPlanStepResponse, UpdateEDRSRecoveryPlanStepCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Configuration_ServerStepConfiguration_Server != null)
            {
                context.Configuration_ServerStepConfiguration_Server = new List<Amazon.Drs.Model.RecoveryPlanServer>(this.Configuration_ServerStepConfiguration_Server);
            }
            context.Configuration_WaitStepConfiguration_WaitDurationMinute = this.Configuration_WaitStepConfiguration_WaitDurationMinute;
            context.RecoveryPlanStepArn = this.RecoveryPlanStepArn;
            #if MODULAR
            if (this.RecoveryPlanStepArn == null && ParameterWasBound(nameof(this.RecoveryPlanStepArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryPlanStepArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StepName = this.StepName;
            
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
            var request = new Amazon.Drs.Model.UpdateRecoveryPlanStepRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.Drs.Model.RecoveryPlanStepConfiguration();
            Amazon.Drs.Model.ServerStepConfiguration requestConfiguration_configuration_ServerStepConfiguration = null;
            
             // populate ServerStepConfiguration
            var requestConfiguration_configuration_ServerStepConfigurationIsNull = true;
            requestConfiguration_configuration_ServerStepConfiguration = new Amazon.Drs.Model.ServerStepConfiguration();
            List<Amazon.Drs.Model.RecoveryPlanServer> requestConfiguration_configuration_ServerStepConfiguration_configuration_ServerStepConfiguration_Server = null;
            if (cmdletContext.Configuration_ServerStepConfiguration_Server != null)
            {
                requestConfiguration_configuration_ServerStepConfiguration_configuration_ServerStepConfiguration_Server = cmdletContext.Configuration_ServerStepConfiguration_Server;
            }
            if (requestConfiguration_configuration_ServerStepConfiguration_configuration_ServerStepConfiguration_Server != null)
            {
                requestConfiguration_configuration_ServerStepConfiguration.Servers = requestConfiguration_configuration_ServerStepConfiguration_configuration_ServerStepConfiguration_Server;
                requestConfiguration_configuration_ServerStepConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ServerStepConfiguration should be set to null
            if (requestConfiguration_configuration_ServerStepConfigurationIsNull)
            {
                requestConfiguration_configuration_ServerStepConfiguration = null;
            }
            if (requestConfiguration_configuration_ServerStepConfiguration != null)
            {
                request.Configuration.ServerStepConfiguration = requestConfiguration_configuration_ServerStepConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.Drs.Model.WaitStepConfiguration requestConfiguration_configuration_WaitStepConfiguration = null;
            
             // populate WaitStepConfiguration
            var requestConfiguration_configuration_WaitStepConfigurationIsNull = true;
            requestConfiguration_configuration_WaitStepConfiguration = new Amazon.Drs.Model.WaitStepConfiguration();
            System.Int32? requestConfiguration_configuration_WaitStepConfiguration_configuration_WaitStepConfiguration_WaitDurationMinute = null;
            if (cmdletContext.Configuration_WaitStepConfiguration_WaitDurationMinute != null)
            {
                requestConfiguration_configuration_WaitStepConfiguration_configuration_WaitStepConfiguration_WaitDurationMinute = cmdletContext.Configuration_WaitStepConfiguration_WaitDurationMinute.Value;
            }
            if (requestConfiguration_configuration_WaitStepConfiguration_configuration_WaitStepConfiguration_WaitDurationMinute != null)
            {
                requestConfiguration_configuration_WaitStepConfiguration.WaitDurationMinutes = requestConfiguration_configuration_WaitStepConfiguration_configuration_WaitStepConfiguration_WaitDurationMinute.Value;
                requestConfiguration_configuration_WaitStepConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_WaitStepConfiguration should be set to null
            if (requestConfiguration_configuration_WaitStepConfigurationIsNull)
            {
                requestConfiguration_configuration_WaitStepConfiguration = null;
            }
            if (requestConfiguration_configuration_WaitStepConfiguration != null)
            {
                request.Configuration.WaitStepConfiguration = requestConfiguration_configuration_WaitStepConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.RecoveryPlanStepArn != null)
            {
                request.RecoveryPlanStepArn = cmdletContext.RecoveryPlanStepArn;
            }
            if (cmdletContext.StepName != null)
            {
                request.StepName = cmdletContext.StepName;
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
        
        private Amazon.Drs.Model.UpdateRecoveryPlanStepResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.UpdateRecoveryPlanStepRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "UpdateRecoveryPlanStep");
            try
            {
                return client.UpdateRecoveryPlanStepAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Drs.Model.RecoveryPlanServer> Configuration_ServerStepConfiguration_Server { get; set; }
            public System.Int32? Configuration_WaitStepConfiguration_WaitDurationMinute { get; set; }
            public System.String RecoveryPlanStepArn { get; set; }
            public System.String StepName { get; set; }
            public System.Func<Amazon.Drs.Model.UpdateRecoveryPlanStepResponse, UpdateEDRSRecoveryPlanStepCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecoveryPlanStep;
        }
        
    }
}
