/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;

namespace Amazon.PowerShell.Cmdlets.PINE
{
    /// <summary>
    /// Create a configuration set. <i>Configuration sets</i> are groups of rules that you
    /// can apply to the emails you send using Amazon Pinpoint. You apply a configuration
    /// set to an email by including a reference to the configuration set in the headers of
    /// the email. When you apply a configuration set to an email, all of the rules in that
    /// configuration set are applied to the email.
    /// </summary>
    [Cmdlet("New", "PINEConfigurationSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email CreateConfigurationSet API operation.", Operation = new[] {"CreateConfigurationSet"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ConfigurationSetName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.PinpointEmail.Model.CreateConfigurationSetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINEConfigurationSetCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter TrackingOptions_CustomRedirectDomain
        /// <summary>
        /// <para>
        /// <para>The domain that you want to use for tracking open and click events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TrackingOptions_CustomRedirectDomain { get; set; }
        #endregion
        
        #region Parameter ReputationOptions_LastFreshStart
        /// <summary>
        /// <para>
        /// <para>The date and time (in Unix time) when the reputation metrics were last given a fresh
        /// start. When your account is given a fresh start, your reputation metrics are calculated
        /// starting from the date of the fresh start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ReputationOptions_LastFreshStart { get; set; }
        #endregion
        
        #region Parameter ReputationOptions_ReputationMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, tracking of reputation metrics is enabled for the configuration
        /// set. If <code>false</code>, tracking of reputation metrics is disabled for the configuration
        /// set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ReputationOptions_ReputationMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter SendingOptions_SendingEnabled
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, email sending is enabled for the configuration set. If <code>false</code>,
        /// email sending is disabled for the configuration set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SendingOptions_SendingEnabled { get; set; }
        #endregion
        
        #region Parameter DeliveryOptions_SendingPoolName
        /// <summary>
        /// <para>
        /// <para>The name of the dedicated IP pool that you want to associate with the configuration
        /// set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeliveryOptions_SendingPoolName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ConfigurationSetName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConfigurationSetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINEConfigurationSet (CreateConfigurationSet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConfigurationSetName = this.ConfigurationSetName;
            context.DeliveryOptions_SendingPoolName = this.DeliveryOptions_SendingPoolName;
            if (ParameterWasBound("ReputationOptions_LastFreshStart"))
                context.ReputationOptions_LastFreshStart = this.ReputationOptions_LastFreshStart;
            if (ParameterWasBound("ReputationOptions_ReputationMetricsEnabled"))
                context.ReputationOptions_ReputationMetricsEnabled = this.ReputationOptions_ReputationMetricsEnabled;
            if (ParameterWasBound("SendingOptions_SendingEnabled"))
                context.SendingOptions_SendingEnabled = this.SendingOptions_SendingEnabled;
            context.TrackingOptions_CustomRedirectDomain = this.TrackingOptions_CustomRedirectDomain;
            
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
            var request = new Amazon.PinpointEmail.Model.CreateConfigurationSetRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            
             // populate DeliveryOptions
            bool requestDeliveryOptionsIsNull = true;
            request.DeliveryOptions = new Amazon.PinpointEmail.Model.DeliveryOptions();
            System.String requestDeliveryOptions_deliveryOptions_SendingPoolName = null;
            if (cmdletContext.DeliveryOptions_SendingPoolName != null)
            {
                requestDeliveryOptions_deliveryOptions_SendingPoolName = cmdletContext.DeliveryOptions_SendingPoolName;
            }
            if (requestDeliveryOptions_deliveryOptions_SendingPoolName != null)
            {
                request.DeliveryOptions.SendingPoolName = requestDeliveryOptions_deliveryOptions_SendingPoolName;
                requestDeliveryOptionsIsNull = false;
            }
             // determine if request.DeliveryOptions should be set to null
            if (requestDeliveryOptionsIsNull)
            {
                request.DeliveryOptions = null;
            }
            
             // populate ReputationOptions
            bool requestReputationOptionsIsNull = true;
            request.ReputationOptions = new Amazon.PinpointEmail.Model.ReputationOptions();
            System.DateTime? requestReputationOptions_reputationOptions_LastFreshStart = null;
            if (cmdletContext.ReputationOptions_LastFreshStart != null)
            {
                requestReputationOptions_reputationOptions_LastFreshStart = cmdletContext.ReputationOptions_LastFreshStart.Value;
            }
            if (requestReputationOptions_reputationOptions_LastFreshStart != null)
            {
                request.ReputationOptions.LastFreshStart = requestReputationOptions_reputationOptions_LastFreshStart.Value;
                requestReputationOptionsIsNull = false;
            }
            System.Boolean? requestReputationOptions_reputationOptions_ReputationMetricsEnabled = null;
            if (cmdletContext.ReputationOptions_ReputationMetricsEnabled != null)
            {
                requestReputationOptions_reputationOptions_ReputationMetricsEnabled = cmdletContext.ReputationOptions_ReputationMetricsEnabled.Value;
            }
            if (requestReputationOptions_reputationOptions_ReputationMetricsEnabled != null)
            {
                request.ReputationOptions.ReputationMetricsEnabled = requestReputationOptions_reputationOptions_ReputationMetricsEnabled.Value;
                requestReputationOptionsIsNull = false;
            }
             // determine if request.ReputationOptions should be set to null
            if (requestReputationOptionsIsNull)
            {
                request.ReputationOptions = null;
            }
            
             // populate SendingOptions
            bool requestSendingOptionsIsNull = true;
            request.SendingOptions = new Amazon.PinpointEmail.Model.SendingOptions();
            System.Boolean? requestSendingOptions_sendingOptions_SendingEnabled = null;
            if (cmdletContext.SendingOptions_SendingEnabled != null)
            {
                requestSendingOptions_sendingOptions_SendingEnabled = cmdletContext.SendingOptions_SendingEnabled.Value;
            }
            if (requestSendingOptions_sendingOptions_SendingEnabled != null)
            {
                request.SendingOptions.SendingEnabled = requestSendingOptions_sendingOptions_SendingEnabled.Value;
                requestSendingOptionsIsNull = false;
            }
             // determine if request.SendingOptions should be set to null
            if (requestSendingOptionsIsNull)
            {
                request.SendingOptions = null;
            }
            
             // populate TrackingOptions
            bool requestTrackingOptionsIsNull = true;
            request.TrackingOptions = new Amazon.PinpointEmail.Model.TrackingOptions();
            System.String requestTrackingOptions_trackingOptions_CustomRedirectDomain = null;
            if (cmdletContext.TrackingOptions_CustomRedirectDomain != null)
            {
                requestTrackingOptions_trackingOptions_CustomRedirectDomain = cmdletContext.TrackingOptions_CustomRedirectDomain;
            }
            if (requestTrackingOptions_trackingOptions_CustomRedirectDomain != null)
            {
                request.TrackingOptions.CustomRedirectDomain = requestTrackingOptions_trackingOptions_CustomRedirectDomain;
                requestTrackingOptionsIsNull = false;
            }
             // determine if request.TrackingOptions should be set to null
            if (requestTrackingOptionsIsNull)
            {
                request.TrackingOptions = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ConfigurationSetName;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.PinpointEmail.Model.CreateConfigurationSetResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.CreateConfigurationSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "CreateConfigurationSet");
            try
            {
                #if DESKTOP
                return client.CreateConfigurationSet(request);
                #elif CORECLR
                return client.CreateConfigurationSetAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public System.String DeliveryOptions_SendingPoolName { get; set; }
            public System.DateTime? ReputationOptions_LastFreshStart { get; set; }
            public System.Boolean? ReputationOptions_ReputationMetricsEnabled { get; set; }
            public System.Boolean? SendingOptions_SendingEnabled { get; set; }
            public System.String TrackingOptions_CustomRedirectDomain { get; set; }
        }
        
    }
}
