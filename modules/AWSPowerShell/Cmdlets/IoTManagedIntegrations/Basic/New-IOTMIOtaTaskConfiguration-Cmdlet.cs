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
using Amazon.IoTManagedIntegrations;
using Amazon.IoTManagedIntegrations.Model;

namespace Amazon.PowerShell.Cmdlets.IOTMI
{
    /// <summary>
    /// Create a configuraiton for the over-the-air (OTA) task.
    /// </summary>
    [Cmdlet("New", "IOTMIOtaTaskConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management CreateOtaTaskConfiguration API operation.", Operation = new[] {"CreateOtaTaskConfiguration"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.CreateOtaTaskConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTManagedIntegrations.Model.CreateOtaTaskConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTManagedIntegrations.Model.CreateOtaTaskConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIOTMIOtaTaskConfigurationCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AbortConfig_AbortConfigCriteriaList
        /// <summary>
        /// <para>
        /// <para>The list of criteria for the abort config.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushConfig_AbortConfig_AbortConfigCriteriaList")]
        public Amazon.IoTManagedIntegrations.Model.AbortConfigCriteria[] AbortConfig_AbortConfigCriteriaList { get; set; }
        #endregion
        
        #region Parameter ExponentialRolloutRate_BaseRatePerMinute
        /// <summary>
        /// <para>
        /// <para>The base rate per minute for the rollout of an over-the-air (OTA) task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushConfig_RolloutConfig_ExponentialRolloutRate_BaseRatePerMinute")]
        public System.Int32? ExponentialRolloutRate_BaseRatePerMinute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the over-the-air (OTA) task configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExponentialRolloutRate_IncrementFactor
        /// <summary>
        /// <para>
        /// <para>The incremental factor for increasing the rollout rate of an over-the-air (OTA) task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushConfig_RolloutConfig_ExponentialRolloutRate_IncrementFactor")]
        public System.Double? ExponentialRolloutRate_IncrementFactor { get; set; }
        #endregion
        
        #region Parameter TimeoutConfig_InProgressTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of time the device has to finish execution of this task. The
        /// timeout interval can be anywhere between 1 minute and 7 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushConfig_TimeoutConfig_InProgressTimeoutInMinutes")]
        public System.Int64? TimeoutConfig_InProgressTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter RolloutConfig_MaximumPerMinute
        /// <summary>
        /// <para>
        /// <para>The maximum number of things that will be notified of a pending task, per minute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushConfig_RolloutConfig_MaximumPerMinute")]
        public System.Int32? RolloutConfig_MaximumPerMinute { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the over-the-air (OTA) task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RateIncreaseCriteria_NumberOfNotifiedThing
        /// <summary>
        /// <para>
        /// <para>The threshold for number of notified things that will initiate the increase in rate
        /// of rollout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria_NumberOfNotifiedThings")]
        public System.Int32? RateIncreaseCriteria_NumberOfNotifiedThing { get; set; }
        #endregion
        
        #region Parameter RateIncreaseCriteria_NumberOfSucceededThing
        /// <summary>
        /// <para>
        /// <para>The threshold for number of succeeded things that will initiate the increase in rate
        /// of rollout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria_NumberOfSucceededThings")]
        public System.Int32? RateIncreaseCriteria_NumberOfSucceededThing { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token. If you retry a request that completed successfully initially
        /// using the same client token and parameters, then the retry attempt will succeed without
        /// performing any further actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskConfigurationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.CreateOtaTaskConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IoTManagedIntegrations.Model.CreateOtaTaskConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskConfigurationId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTMIOtaTaskConfiguration (CreateOtaTaskConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.CreateOtaTaskConfigurationResponse, NewIOTMIOtaTaskConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            if (this.AbortConfig_AbortConfigCriteriaList != null)
            {
                context.AbortConfig_AbortConfigCriteriaList = new List<Amazon.IoTManagedIntegrations.Model.AbortConfigCriteria>(this.AbortConfig_AbortConfigCriteriaList);
            }
            context.ExponentialRolloutRate_BaseRatePerMinute = this.ExponentialRolloutRate_BaseRatePerMinute;
            context.ExponentialRolloutRate_IncrementFactor = this.ExponentialRolloutRate_IncrementFactor;
            context.RateIncreaseCriteria_NumberOfNotifiedThing = this.RateIncreaseCriteria_NumberOfNotifiedThing;
            context.RateIncreaseCriteria_NumberOfSucceededThing = this.RateIncreaseCriteria_NumberOfSucceededThing;
            context.RolloutConfig_MaximumPerMinute = this.RolloutConfig_MaximumPerMinute;
            context.TimeoutConfig_InProgressTimeoutInMinute = this.TimeoutConfig_InProgressTimeoutInMinute;
            
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
            var request = new Amazon.IoTManagedIntegrations.Model.CreateOtaTaskConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PushConfig
            var requestPushConfigIsNull = true;
            request.PushConfig = new Amazon.IoTManagedIntegrations.Model.PushConfig();
            Amazon.IoTManagedIntegrations.Model.OtaTaskAbortConfig requestPushConfig_pushConfig_AbortConfig = null;
            
             // populate AbortConfig
            var requestPushConfig_pushConfig_AbortConfigIsNull = true;
            requestPushConfig_pushConfig_AbortConfig = new Amazon.IoTManagedIntegrations.Model.OtaTaskAbortConfig();
            List<Amazon.IoTManagedIntegrations.Model.AbortConfigCriteria> requestPushConfig_pushConfig_AbortConfig_abortConfig_AbortConfigCriteriaList = null;
            if (cmdletContext.AbortConfig_AbortConfigCriteriaList != null)
            {
                requestPushConfig_pushConfig_AbortConfig_abortConfig_AbortConfigCriteriaList = cmdletContext.AbortConfig_AbortConfigCriteriaList;
            }
            if (requestPushConfig_pushConfig_AbortConfig_abortConfig_AbortConfigCriteriaList != null)
            {
                requestPushConfig_pushConfig_AbortConfig.AbortConfigCriteriaList = requestPushConfig_pushConfig_AbortConfig_abortConfig_AbortConfigCriteriaList;
                requestPushConfig_pushConfig_AbortConfigIsNull = false;
            }
             // determine if requestPushConfig_pushConfig_AbortConfig should be set to null
            if (requestPushConfig_pushConfig_AbortConfigIsNull)
            {
                requestPushConfig_pushConfig_AbortConfig = null;
            }
            if (requestPushConfig_pushConfig_AbortConfig != null)
            {
                request.PushConfig.AbortConfig = requestPushConfig_pushConfig_AbortConfig;
                requestPushConfigIsNull = false;
            }
            Amazon.IoTManagedIntegrations.Model.OtaTaskTimeoutConfig requestPushConfig_pushConfig_TimeoutConfig = null;
            
             // populate TimeoutConfig
            var requestPushConfig_pushConfig_TimeoutConfigIsNull = true;
            requestPushConfig_pushConfig_TimeoutConfig = new Amazon.IoTManagedIntegrations.Model.OtaTaskTimeoutConfig();
            System.Int64? requestPushConfig_pushConfig_TimeoutConfig_timeoutConfig_InProgressTimeoutInMinute = null;
            if (cmdletContext.TimeoutConfig_InProgressTimeoutInMinute != null)
            {
                requestPushConfig_pushConfig_TimeoutConfig_timeoutConfig_InProgressTimeoutInMinute = cmdletContext.TimeoutConfig_InProgressTimeoutInMinute.Value;
            }
            if (requestPushConfig_pushConfig_TimeoutConfig_timeoutConfig_InProgressTimeoutInMinute != null)
            {
                requestPushConfig_pushConfig_TimeoutConfig.InProgressTimeoutInMinutes = requestPushConfig_pushConfig_TimeoutConfig_timeoutConfig_InProgressTimeoutInMinute.Value;
                requestPushConfig_pushConfig_TimeoutConfigIsNull = false;
            }
             // determine if requestPushConfig_pushConfig_TimeoutConfig should be set to null
            if (requestPushConfig_pushConfig_TimeoutConfigIsNull)
            {
                requestPushConfig_pushConfig_TimeoutConfig = null;
            }
            if (requestPushConfig_pushConfig_TimeoutConfig != null)
            {
                request.PushConfig.TimeoutConfig = requestPushConfig_pushConfig_TimeoutConfig;
                requestPushConfigIsNull = false;
            }
            Amazon.IoTManagedIntegrations.Model.OtaTaskExecutionRolloutConfig requestPushConfig_pushConfig_RolloutConfig = null;
            
             // populate RolloutConfig
            var requestPushConfig_pushConfig_RolloutConfigIsNull = true;
            requestPushConfig_pushConfig_RolloutConfig = new Amazon.IoTManagedIntegrations.Model.OtaTaskExecutionRolloutConfig();
            System.Int32? requestPushConfig_pushConfig_RolloutConfig_rolloutConfig_MaximumPerMinute = null;
            if (cmdletContext.RolloutConfig_MaximumPerMinute != null)
            {
                requestPushConfig_pushConfig_RolloutConfig_rolloutConfig_MaximumPerMinute = cmdletContext.RolloutConfig_MaximumPerMinute.Value;
            }
            if (requestPushConfig_pushConfig_RolloutConfig_rolloutConfig_MaximumPerMinute != null)
            {
                requestPushConfig_pushConfig_RolloutConfig.MaximumPerMinute = requestPushConfig_pushConfig_RolloutConfig_rolloutConfig_MaximumPerMinute.Value;
                requestPushConfig_pushConfig_RolloutConfigIsNull = false;
            }
            Amazon.IoTManagedIntegrations.Model.ExponentialRolloutRate requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate = null;
            
             // populate ExponentialRolloutRate
            var requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRateIsNull = true;
            requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate = new Amazon.IoTManagedIntegrations.Model.ExponentialRolloutRate();
            System.Int32? requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_exponentialRolloutRate_BaseRatePerMinute = null;
            if (cmdletContext.ExponentialRolloutRate_BaseRatePerMinute != null)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_exponentialRolloutRate_BaseRatePerMinute = cmdletContext.ExponentialRolloutRate_BaseRatePerMinute.Value;
            }
            if (requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_exponentialRolloutRate_BaseRatePerMinute != null)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate.BaseRatePerMinute = requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_exponentialRolloutRate_BaseRatePerMinute.Value;
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRateIsNull = false;
            }
            System.Double? requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_exponentialRolloutRate_IncrementFactor = null;
            if (cmdletContext.ExponentialRolloutRate_IncrementFactor != null)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_exponentialRolloutRate_IncrementFactor = cmdletContext.ExponentialRolloutRate_IncrementFactor.Value;
            }
            if (requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_exponentialRolloutRate_IncrementFactor != null)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate.IncrementFactor = requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_exponentialRolloutRate_IncrementFactor.Value;
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRateIsNull = false;
            }
            Amazon.IoTManagedIntegrations.Model.RolloutRateIncreaseCriteria requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria = null;
            
             // populate RateIncreaseCriteria
            var requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteriaIsNull = true;
            requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria = new Amazon.IoTManagedIntegrations.Model.RolloutRateIncreaseCriteria();
            System.Int32? requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing = null;
            if (cmdletContext.RateIncreaseCriteria_NumberOfNotifiedThing != null)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing = cmdletContext.RateIncreaseCriteria_NumberOfNotifiedThing.Value;
            }
            if (requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing != null)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria.NumberOfNotifiedThings = requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing.Value;
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteriaIsNull = false;
            }
            System.Int32? requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing = null;
            if (cmdletContext.RateIncreaseCriteria_NumberOfSucceededThing != null)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing = cmdletContext.RateIncreaseCriteria_NumberOfSucceededThing.Value;
            }
            if (requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing != null)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria.NumberOfSucceededThings = requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing.Value;
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteriaIsNull = false;
            }
             // determine if requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria should be set to null
            if (requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteriaIsNull)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria = null;
            }
            if (requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria != null)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate.RateIncreaseCriteria = requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate_pushConfig_RolloutConfig_ExponentialRolloutRate_RateIncreaseCriteria;
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRateIsNull = false;
            }
             // determine if requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate should be set to null
            if (requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRateIsNull)
            {
                requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate = null;
            }
            if (requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate != null)
            {
                requestPushConfig_pushConfig_RolloutConfig.ExponentialRolloutRate = requestPushConfig_pushConfig_RolloutConfig_pushConfig_RolloutConfig_ExponentialRolloutRate;
                requestPushConfig_pushConfig_RolloutConfigIsNull = false;
            }
             // determine if requestPushConfig_pushConfig_RolloutConfig should be set to null
            if (requestPushConfig_pushConfig_RolloutConfigIsNull)
            {
                requestPushConfig_pushConfig_RolloutConfig = null;
            }
            if (requestPushConfig_pushConfig_RolloutConfig != null)
            {
                request.PushConfig.RolloutConfig = requestPushConfig_pushConfig_RolloutConfig;
                requestPushConfigIsNull = false;
            }
             // determine if request.PushConfig should be set to null
            if (requestPushConfigIsNull)
            {
                request.PushConfig = null;
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
        
        private Amazon.IoTManagedIntegrations.Model.CreateOtaTaskConfigurationResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.CreateOtaTaskConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "CreateOtaTaskConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateOtaTaskConfiguration(request);
                #elif CORECLR
                return client.CreateOtaTaskConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.IoTManagedIntegrations.Model.AbortConfigCriteria> AbortConfig_AbortConfigCriteriaList { get; set; }
            public System.Int32? ExponentialRolloutRate_BaseRatePerMinute { get; set; }
            public System.Double? ExponentialRolloutRate_IncrementFactor { get; set; }
            public System.Int32? RateIncreaseCriteria_NumberOfNotifiedThing { get; set; }
            public System.Int32? RateIncreaseCriteria_NumberOfSucceededThing { get; set; }
            public System.Int32? RolloutConfig_MaximumPerMinute { get; set; }
            public System.Int64? TimeoutConfig_InProgressTimeoutInMinute { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.CreateOtaTaskConfigurationResponse, NewIOTMIOtaTaskConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskConfigurationId;
        }
        
    }
}
