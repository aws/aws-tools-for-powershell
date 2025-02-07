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
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email CreateConfigurationSet API operation.", Operation = new[] {"CreateConfigurationSet"}, SelectReturnType = typeof(Amazon.PinpointEmail.Model.CreateConfigurationSetResponse))]
    [AWSCmdletOutput("None or Amazon.PinpointEmail.Model.CreateConfigurationSetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.PinpointEmail.Model.CreateConfigurationSetResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewPINEConfigurationSetCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set.</para>
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
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter TrackingOptions_CustomRedirectDomain
        /// <summary>
        /// <para>
        /// <para>The domain that you want to use for tracking open and click events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ReputationOptions_LastFreshStart { get; set; }
        #endregion
        
        #region Parameter ReputationOptions_ReputationMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, tracking of reputation metrics is enabled for the configuration set.
        /// If <c>false</c>, tracking of reputation metrics is disabled for the configuration
        /// set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReputationOptions_ReputationMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter SendingOptions_SendingEnabled
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, email sending is enabled for the configuration set. If <c>false</c>,
        /// email sending is disabled for the configuration set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SendingOptions_SendingEnabled { get; set; }
        #endregion
        
        #region Parameter DeliveryOptions_SendingPoolName
        /// <summary>
        /// <para>
        /// <para>The name of the dedicated IP pool that you want to associate with the configuration
        /// set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryOptions_SendingPoolName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of objects that define the tags (keys and values) that you want to associate
        /// with the configuration set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PinpointEmail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter DeliveryOptions_TlsPolicy
        /// <summary>
        /// <para>
        /// <para>Specifies whether messages that use the configuration set are required to use Transport
        /// Layer Security (TLS). If the value is <c>Require</c>, messages are only delivered
        /// if a TLS connection can be established. If the value is <c>Optional</c>, messages
        /// can be delivered in plain text if a TLS connection can't be established.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PinpointEmail.TlsPolicy")]
        public Amazon.PinpointEmail.TlsPolicy DeliveryOptions_TlsPolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointEmail.Model.CreateConfigurationSetResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINEConfigurationSet (CreateConfigurationSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointEmail.Model.CreateConfigurationSetResponse, NewPINEConfigurationSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            #if MODULAR
            if (this.ConfigurationSetName == null && ParameterWasBound(nameof(this.ConfigurationSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeliveryOptions_SendingPoolName = this.DeliveryOptions_SendingPoolName;
            context.DeliveryOptions_TlsPolicy = this.DeliveryOptions_TlsPolicy;
            context.ReputationOptions_LastFreshStart = this.ReputationOptions_LastFreshStart;
            context.ReputationOptions_ReputationMetricsEnabled = this.ReputationOptions_ReputationMetricsEnabled;
            context.SendingOptions_SendingEnabled = this.SendingOptions_SendingEnabled;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PinpointEmail.Model.Tag>(this.Tag);
            }
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
            var requestDeliveryOptionsIsNull = true;
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
            Amazon.PinpointEmail.TlsPolicy requestDeliveryOptions_deliveryOptions_TlsPolicy = null;
            if (cmdletContext.DeliveryOptions_TlsPolicy != null)
            {
                requestDeliveryOptions_deliveryOptions_TlsPolicy = cmdletContext.DeliveryOptions_TlsPolicy;
            }
            if (requestDeliveryOptions_deliveryOptions_TlsPolicy != null)
            {
                request.DeliveryOptions.TlsPolicy = requestDeliveryOptions_deliveryOptions_TlsPolicy;
                requestDeliveryOptionsIsNull = false;
            }
             // determine if request.DeliveryOptions should be set to null
            if (requestDeliveryOptionsIsNull)
            {
                request.DeliveryOptions = null;
            }
            
             // populate ReputationOptions
            var requestReputationOptionsIsNull = true;
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
            var requestSendingOptionsIsNull = true;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TrackingOptions
            var requestTrackingOptionsIsNull = true;
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
            public Amazon.PinpointEmail.TlsPolicy DeliveryOptions_TlsPolicy { get; set; }
            public System.DateTime? ReputationOptions_LastFreshStart { get; set; }
            public System.Boolean? ReputationOptions_ReputationMetricsEnabled { get; set; }
            public System.Boolean? SendingOptions_SendingEnabled { get; set; }
            public List<Amazon.PinpointEmail.Model.Tag> Tag { get; set; }
            public System.String TrackingOptions_CustomRedirectDomain { get; set; }
            public System.Func<Amazon.PinpointEmail.Model.CreateConfigurationSetResponse, NewPINEConfigurationSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
