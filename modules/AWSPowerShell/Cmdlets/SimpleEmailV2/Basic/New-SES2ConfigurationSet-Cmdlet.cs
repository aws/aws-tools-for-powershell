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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Create a configuration set. <i>Configuration sets</i> are groups of rules that you
    /// can apply to the emails that you send. You apply a configuration set to an email by
    /// specifying the name of the configuration set when you call the Amazon SES API v2.
    /// When you apply a configuration set to an email, all of the rules in that configuration
    /// set are applied to the email.
    /// </summary>
    [Cmdlet("New", "SES2ConfigurationSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) CreateConfigurationSet API operation.", Operation = new[] {"CreateConfigurationSet"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.CreateConfigurationSetResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.CreateConfigurationSetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.CreateConfigurationSetResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewSES2ConfigurationSetCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set. The name can contain up to 64 alphanumeric characters,
        /// including letters, numbers, hyphens (-) and underscores (_) only.</para>
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
        /// <para>The domain to use for tracking open and click events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrackingOptions_CustomRedirectDomain { get; set; }
        #endregion
        
        #region Parameter DashboardOptions_EngagementMetric
        /// <summary>
        /// <para>
        /// <para>Specifies the status of your VDM engagement metrics collection. Can be one of the
        /// following:</para><ul><li><para><c>ENABLED</c> – Amazon SES enables engagement metrics for the configuration set.</para></li><li><para><c>DISABLED</c> – Amazon SES disables engagement metrics for the configuration set.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VdmOptions_DashboardOptions_EngagementMetrics")]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.FeatureStatus")]
        public Amazon.SimpleEmailV2.FeatureStatus DashboardOptions_EngagementMetric { get; set; }
        #endregion
        
        #region Parameter TrackingOptions_HttpsPolicy
        /// <summary>
        /// <para>
        /// <para>The https policy to use for tracking open and click events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.HttpsPolicy")]
        public Amazon.SimpleEmailV2.HttpsPolicy TrackingOptions_HttpsPolicy { get; set; }
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
        
        #region Parameter DeliveryOptions_MaxDeliverySecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, that Amazon SES API v2 will attempt delivery
        /// of email. If specified, the value must greater than or equal to 300 seconds (5 minutes)
        /// and less than or equal to 50400 seconds (840 minutes). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeliveryOptions_MaxDeliverySeconds")]
        public System.Int64? DeliveryOptions_MaxDeliverySecond { get; set; }
        #endregion
        
        #region Parameter GuardianOptions_OptimizedSharedDelivery
        /// <summary>
        /// <para>
        /// <para>Specifies the status of your VDM optimized shared delivery. Can be one of the following:</para><ul><li><para><c>ENABLED</c> – Amazon SES enables optimized shared delivery for the configuration
        /// set.</para></li><li><para><c>DISABLED</c> – Amazon SES disables optimized shared delivery for the configuration
        /// set.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VdmOptions_GuardianOptions_OptimizedSharedDelivery")]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.FeatureStatus")]
        public Amazon.SimpleEmailV2.FeatureStatus GuardianOptions_OptimizedSharedDelivery { get; set; }
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
        /// <para>The name of the dedicated IP pool to associate with the configuration set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryOptions_SendingPoolName { get; set; }
        #endregion
        
        #region Parameter SuppressionOptions_SuppressedReason
        /// <summary>
        /// <para>
        /// <para>A list that contains the reasons that email addresses are automatically added to the
        /// suppression list for your account. This list can contain any or all of the following:</para><ul><li><para><c>COMPLAINT</c> – Amazon SES adds an email address to the suppression list for your
        /// account when a message sent to that address results in a complaint.</para></li><li><para><c>BOUNCE</c> – Amazon SES adds an email address to the suppression list for your
        /// account when a message sent to that address results in a hard bounce.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SuppressionOptions_SuppressedReasons")]
        public System.String[] SuppressionOptions_SuppressedReason { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of objects that define the tags (keys and values) to associate with the configuration
        /// set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleEmailV2.Model.Tag[] Tag { get; set; }
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
        [AWSConstantClassSource("Amazon.SimpleEmailV2.TlsPolicy")]
        public Amazon.SimpleEmailV2.TlsPolicy DeliveryOptions_TlsPolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.CreateConfigurationSetResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SES2ConfigurationSet (CreateConfigurationSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.CreateConfigurationSetResponse, NewSES2ConfigurationSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            #if MODULAR
            if (this.ConfigurationSetName == null && ParameterWasBound(nameof(this.ConfigurationSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeliveryOptions_MaxDeliverySecond = this.DeliveryOptions_MaxDeliverySecond;
            context.DeliveryOptions_SendingPoolName = this.DeliveryOptions_SendingPoolName;
            context.DeliveryOptions_TlsPolicy = this.DeliveryOptions_TlsPolicy;
            context.ReputationOptions_LastFreshStart = this.ReputationOptions_LastFreshStart;
            context.ReputationOptions_ReputationMetricsEnabled = this.ReputationOptions_ReputationMetricsEnabled;
            context.SendingOptions_SendingEnabled = this.SendingOptions_SendingEnabled;
            if (this.SuppressionOptions_SuppressedReason != null)
            {
                context.SuppressionOptions_SuppressedReason = new List<System.String>(this.SuppressionOptions_SuppressedReason);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleEmailV2.Model.Tag>(this.Tag);
            }
            context.TrackingOptions_CustomRedirectDomain = this.TrackingOptions_CustomRedirectDomain;
            context.TrackingOptions_HttpsPolicy = this.TrackingOptions_HttpsPolicy;
            context.DashboardOptions_EngagementMetric = this.DashboardOptions_EngagementMetric;
            context.GuardianOptions_OptimizedSharedDelivery = this.GuardianOptions_OptimizedSharedDelivery;
            
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
            var request = new Amazon.SimpleEmailV2.Model.CreateConfigurationSetRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            
             // populate DeliveryOptions
            var requestDeliveryOptionsIsNull = true;
            request.DeliveryOptions = new Amazon.SimpleEmailV2.Model.DeliveryOptions();
            System.Int64? requestDeliveryOptions_deliveryOptions_MaxDeliverySecond = null;
            if (cmdletContext.DeliveryOptions_MaxDeliverySecond != null)
            {
                requestDeliveryOptions_deliveryOptions_MaxDeliverySecond = cmdletContext.DeliveryOptions_MaxDeliverySecond.Value;
            }
            if (requestDeliveryOptions_deliveryOptions_MaxDeliverySecond != null)
            {
                request.DeliveryOptions.MaxDeliverySeconds = requestDeliveryOptions_deliveryOptions_MaxDeliverySecond.Value;
                requestDeliveryOptionsIsNull = false;
            }
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
            Amazon.SimpleEmailV2.TlsPolicy requestDeliveryOptions_deliveryOptions_TlsPolicy = null;
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
            request.ReputationOptions = new Amazon.SimpleEmailV2.Model.ReputationOptions();
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
            request.SendingOptions = new Amazon.SimpleEmailV2.Model.SendingOptions();
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
            
             // populate SuppressionOptions
            var requestSuppressionOptionsIsNull = true;
            request.SuppressionOptions = new Amazon.SimpleEmailV2.Model.SuppressionOptions();
            List<System.String> requestSuppressionOptions_suppressionOptions_SuppressedReason = null;
            if (cmdletContext.SuppressionOptions_SuppressedReason != null)
            {
                requestSuppressionOptions_suppressionOptions_SuppressedReason = cmdletContext.SuppressionOptions_SuppressedReason;
            }
            if (requestSuppressionOptions_suppressionOptions_SuppressedReason != null)
            {
                request.SuppressionOptions.SuppressedReasons = requestSuppressionOptions_suppressionOptions_SuppressedReason;
                requestSuppressionOptionsIsNull = false;
            }
             // determine if request.SuppressionOptions should be set to null
            if (requestSuppressionOptionsIsNull)
            {
                request.SuppressionOptions = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TrackingOptions
            var requestTrackingOptionsIsNull = true;
            request.TrackingOptions = new Amazon.SimpleEmailV2.Model.TrackingOptions();
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
            Amazon.SimpleEmailV2.HttpsPolicy requestTrackingOptions_trackingOptions_HttpsPolicy = null;
            if (cmdletContext.TrackingOptions_HttpsPolicy != null)
            {
                requestTrackingOptions_trackingOptions_HttpsPolicy = cmdletContext.TrackingOptions_HttpsPolicy;
            }
            if (requestTrackingOptions_trackingOptions_HttpsPolicy != null)
            {
                request.TrackingOptions.HttpsPolicy = requestTrackingOptions_trackingOptions_HttpsPolicy;
                requestTrackingOptionsIsNull = false;
            }
             // determine if request.TrackingOptions should be set to null
            if (requestTrackingOptionsIsNull)
            {
                request.TrackingOptions = null;
            }
            
             // populate VdmOptions
            var requestVdmOptionsIsNull = true;
            request.VdmOptions = new Amazon.SimpleEmailV2.Model.VdmOptions();
            Amazon.SimpleEmailV2.Model.DashboardOptions requestVdmOptions_vdmOptions_DashboardOptions = null;
            
             // populate DashboardOptions
            var requestVdmOptions_vdmOptions_DashboardOptionsIsNull = true;
            requestVdmOptions_vdmOptions_DashboardOptions = new Amazon.SimpleEmailV2.Model.DashboardOptions();
            Amazon.SimpleEmailV2.FeatureStatus requestVdmOptions_vdmOptions_DashboardOptions_dashboardOptions_EngagementMetric = null;
            if (cmdletContext.DashboardOptions_EngagementMetric != null)
            {
                requestVdmOptions_vdmOptions_DashboardOptions_dashboardOptions_EngagementMetric = cmdletContext.DashboardOptions_EngagementMetric;
            }
            if (requestVdmOptions_vdmOptions_DashboardOptions_dashboardOptions_EngagementMetric != null)
            {
                requestVdmOptions_vdmOptions_DashboardOptions.EngagementMetrics = requestVdmOptions_vdmOptions_DashboardOptions_dashboardOptions_EngagementMetric;
                requestVdmOptions_vdmOptions_DashboardOptionsIsNull = false;
            }
             // determine if requestVdmOptions_vdmOptions_DashboardOptions should be set to null
            if (requestVdmOptions_vdmOptions_DashboardOptionsIsNull)
            {
                requestVdmOptions_vdmOptions_DashboardOptions = null;
            }
            if (requestVdmOptions_vdmOptions_DashboardOptions != null)
            {
                request.VdmOptions.DashboardOptions = requestVdmOptions_vdmOptions_DashboardOptions;
                requestVdmOptionsIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.GuardianOptions requestVdmOptions_vdmOptions_GuardianOptions = null;
            
             // populate GuardianOptions
            var requestVdmOptions_vdmOptions_GuardianOptionsIsNull = true;
            requestVdmOptions_vdmOptions_GuardianOptions = new Amazon.SimpleEmailV2.Model.GuardianOptions();
            Amazon.SimpleEmailV2.FeatureStatus requestVdmOptions_vdmOptions_GuardianOptions_guardianOptions_OptimizedSharedDelivery = null;
            if (cmdletContext.GuardianOptions_OptimizedSharedDelivery != null)
            {
                requestVdmOptions_vdmOptions_GuardianOptions_guardianOptions_OptimizedSharedDelivery = cmdletContext.GuardianOptions_OptimizedSharedDelivery;
            }
            if (requestVdmOptions_vdmOptions_GuardianOptions_guardianOptions_OptimizedSharedDelivery != null)
            {
                requestVdmOptions_vdmOptions_GuardianOptions.OptimizedSharedDelivery = requestVdmOptions_vdmOptions_GuardianOptions_guardianOptions_OptimizedSharedDelivery;
                requestVdmOptions_vdmOptions_GuardianOptionsIsNull = false;
            }
             // determine if requestVdmOptions_vdmOptions_GuardianOptions should be set to null
            if (requestVdmOptions_vdmOptions_GuardianOptionsIsNull)
            {
                requestVdmOptions_vdmOptions_GuardianOptions = null;
            }
            if (requestVdmOptions_vdmOptions_GuardianOptions != null)
            {
                request.VdmOptions.GuardianOptions = requestVdmOptions_vdmOptions_GuardianOptions;
                requestVdmOptionsIsNull = false;
            }
             // determine if request.VdmOptions should be set to null
            if (requestVdmOptionsIsNull)
            {
                request.VdmOptions = null;
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
        
        private Amazon.SimpleEmailV2.Model.CreateConfigurationSetResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.CreateConfigurationSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "CreateConfigurationSet");
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
            public System.Int64? DeliveryOptions_MaxDeliverySecond { get; set; }
            public System.String DeliveryOptions_SendingPoolName { get; set; }
            public Amazon.SimpleEmailV2.TlsPolicy DeliveryOptions_TlsPolicy { get; set; }
            public System.DateTime? ReputationOptions_LastFreshStart { get; set; }
            public System.Boolean? ReputationOptions_ReputationMetricsEnabled { get; set; }
            public System.Boolean? SendingOptions_SendingEnabled { get; set; }
            public List<System.String> SuppressionOptions_SuppressedReason { get; set; }
            public List<Amazon.SimpleEmailV2.Model.Tag> Tag { get; set; }
            public System.String TrackingOptions_CustomRedirectDomain { get; set; }
            public Amazon.SimpleEmailV2.HttpsPolicy TrackingOptions_HttpsPolicy { get; set; }
            public Amazon.SimpleEmailV2.FeatureStatus DashboardOptions_EngagementMetric { get; set; }
            public Amazon.SimpleEmailV2.FeatureStatus GuardianOptions_OptimizedSharedDelivery { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.CreateConfigurationSetResponse, NewSES2ConfigurationSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
