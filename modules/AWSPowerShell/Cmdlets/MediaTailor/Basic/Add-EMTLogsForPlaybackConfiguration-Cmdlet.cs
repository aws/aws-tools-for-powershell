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
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// Defines where AWS Elemental MediaTailor sends logs for the playback configuration.
    /// </summary>
    [Cmdlet("Add", "EMTLogsForPlaybackConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor ConfigureLogsForPlaybackConfiguration API operation.", Operation = new[] {"ConfigureLogsForPlaybackConfiguration"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse))]
    [AWSCmdletOutput("Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse",
        "This cmdlet returns an Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse object containing multiple properties."
    )]
    public partial class AddEMTLogsForPlaybackConfigurationCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EnabledLoggingStrategy
        /// <summary>
        /// <para>
        /// <para>The method used for collecting logs from AWS Elemental MediaTailor. To configure MediaTailor
        /// to send logs directly to Amazon CloudWatch Logs, choose <c>LEGACY_CLOUDWATCH</c>.
        /// To configure MediaTailor to send logs to CloudWatch, which then vends the logs to
        /// your destination of choice, choose <c>VENDED_LOGS</c>. Supported destinations are
        /// CloudWatch Logs log group, Amazon S3 bucket, and Amazon Data Firehose stream.</para><para>To use vended logs, you must configure the delivery destination in Amazon CloudWatch,
        /// as described in <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/AWS-logs-and-resource-policy.html#AWS-vended-logs-permissions-V2">Enable
        /// logging from AWS services, Logging that requires additional permissions [V2]</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnabledLoggingStrategies")]
        public System.String[] EnabledLoggingStrategy { get; set; }
        #endregion
        
        #region Parameter AdsInteractionLog_ExcludeEventType
        /// <summary>
        /// <para>
        /// <para>Indicates that MediaTailor won't emit the selected events in the logs for playback
        /// sessions that are initialized with this configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdsInteractionLog_ExcludeEventTypes")]
        public System.String[] AdsInteractionLog_ExcludeEventType { get; set; }
        #endregion
        
        #region Parameter ManifestServiceInteractionLog_ExcludeEventType
        /// <summary>
        /// <para>
        /// <para>Indicates that MediaTailor won't emit the selected events in the logs for playback
        /// sessions that are initialized with this configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestServiceInteractionLog_ExcludeEventTypes")]
        public System.String[] ManifestServiceInteractionLog_ExcludeEventType { get; set; }
        #endregion
        
        #region Parameter PercentEnabled
        /// <summary>
        /// <para>
        /// <para>The percentage of session logs that MediaTailor sends to your CloudWatch Logs account.
        /// For example, if your playback configuration has 1000 sessions and percentEnabled is
        /// set to <c>60</c>, MediaTailor sends logs for 600 of the sessions to CloudWatch Logs.
        /// MediaTailor decides at random which of the playback configuration sessions to send
        /// logs for. If you want to view logs for a specific session, you can use the <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/debug-log-mode.html">debug
        /// log mode</a>.</para><para>Valid values: <c>0</c> - <c>100</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? PercentEnabled { get; set; }
        #endregion
        
        #region Parameter PlaybackConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the playback configuration.</para>
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
        public System.String PlaybackConfigurationName { get; set; }
        #endregion
        
        #region Parameter AdsInteractionLog_PublishOptInEventType
        /// <summary>
        /// <para>
        /// <para>Indicates that MediaTailor emits <c>RAW_ADS_RESPONSE</c> logs for playback sessions
        /// that are initialized with this configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdsInteractionLog_PublishOptInEventTypes")]
        public System.String[] AdsInteractionLog_PublishOptInEventType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse).
        /// Specifying the name of a property of type Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PlaybackConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EMTLogsForPlaybackConfiguration (ConfigureLogsForPlaybackConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse, AddEMTLogsForPlaybackConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdsInteractionLog_ExcludeEventType != null)
            {
                context.AdsInteractionLog_ExcludeEventType = new List<System.String>(this.AdsInteractionLog_ExcludeEventType);
            }
            if (this.AdsInteractionLog_PublishOptInEventType != null)
            {
                context.AdsInteractionLog_PublishOptInEventType = new List<System.String>(this.AdsInteractionLog_PublishOptInEventType);
            }
            if (this.EnabledLoggingStrategy != null)
            {
                context.EnabledLoggingStrategy = new List<System.String>(this.EnabledLoggingStrategy);
            }
            if (this.ManifestServiceInteractionLog_ExcludeEventType != null)
            {
                context.ManifestServiceInteractionLog_ExcludeEventType = new List<System.String>(this.ManifestServiceInteractionLog_ExcludeEventType);
            }
            context.PercentEnabled = this.PercentEnabled;
            #if MODULAR
            if (this.PercentEnabled == null && ParameterWasBound(nameof(this.PercentEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter PercentEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlaybackConfigurationName = this.PlaybackConfigurationName;
            #if MODULAR
            if (this.PlaybackConfigurationName == null && ParameterWasBound(nameof(this.PlaybackConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter PlaybackConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationRequest();
            
            
             // populate AdsInteractionLog
            var requestAdsInteractionLogIsNull = true;
            request.AdsInteractionLog = new Amazon.MediaTailor.Model.AdsInteractionLog();
            List<System.String> requestAdsInteractionLog_adsInteractionLog_ExcludeEventType = null;
            if (cmdletContext.AdsInteractionLog_ExcludeEventType != null)
            {
                requestAdsInteractionLog_adsInteractionLog_ExcludeEventType = cmdletContext.AdsInteractionLog_ExcludeEventType;
            }
            if (requestAdsInteractionLog_adsInteractionLog_ExcludeEventType != null)
            {
                request.AdsInteractionLog.ExcludeEventTypes = requestAdsInteractionLog_adsInteractionLog_ExcludeEventType;
                requestAdsInteractionLogIsNull = false;
            }
            List<System.String> requestAdsInteractionLog_adsInteractionLog_PublishOptInEventType = null;
            if (cmdletContext.AdsInteractionLog_PublishOptInEventType != null)
            {
                requestAdsInteractionLog_adsInteractionLog_PublishOptInEventType = cmdletContext.AdsInteractionLog_PublishOptInEventType;
            }
            if (requestAdsInteractionLog_adsInteractionLog_PublishOptInEventType != null)
            {
                request.AdsInteractionLog.PublishOptInEventTypes = requestAdsInteractionLog_adsInteractionLog_PublishOptInEventType;
                requestAdsInteractionLogIsNull = false;
            }
             // determine if request.AdsInteractionLog should be set to null
            if (requestAdsInteractionLogIsNull)
            {
                request.AdsInteractionLog = null;
            }
            if (cmdletContext.EnabledLoggingStrategy != null)
            {
                request.EnabledLoggingStrategies = cmdletContext.EnabledLoggingStrategy;
            }
            
             // populate ManifestServiceInteractionLog
            var requestManifestServiceInteractionLogIsNull = true;
            request.ManifestServiceInteractionLog = new Amazon.MediaTailor.Model.ManifestServiceInteractionLog();
            List<System.String> requestManifestServiceInteractionLog_manifestServiceInteractionLog_ExcludeEventType = null;
            if (cmdletContext.ManifestServiceInteractionLog_ExcludeEventType != null)
            {
                requestManifestServiceInteractionLog_manifestServiceInteractionLog_ExcludeEventType = cmdletContext.ManifestServiceInteractionLog_ExcludeEventType;
            }
            if (requestManifestServiceInteractionLog_manifestServiceInteractionLog_ExcludeEventType != null)
            {
                request.ManifestServiceInteractionLog.ExcludeEventTypes = requestManifestServiceInteractionLog_manifestServiceInteractionLog_ExcludeEventType;
                requestManifestServiceInteractionLogIsNull = false;
            }
             // determine if request.ManifestServiceInteractionLog should be set to null
            if (requestManifestServiceInteractionLogIsNull)
            {
                request.ManifestServiceInteractionLog = null;
            }
            if (cmdletContext.PercentEnabled != null)
            {
                request.PercentEnabled = cmdletContext.PercentEnabled.Value;
            }
            if (cmdletContext.PlaybackConfigurationName != null)
            {
                request.PlaybackConfigurationName = cmdletContext.PlaybackConfigurationName;
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
        
        private Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "ConfigureLogsForPlaybackConfiguration");
            try
            {
                return client.ConfigureLogsForPlaybackConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AdsInteractionLog_ExcludeEventType { get; set; }
            public List<System.String> AdsInteractionLog_PublishOptInEventType { get; set; }
            public List<System.String> EnabledLoggingStrategy { get; set; }
            public List<System.String> ManifestServiceInteractionLog_ExcludeEventType { get; set; }
            public System.Int32? PercentEnabled { get; set; }
            public System.String PlaybackConfigurationName { get; set; }
            public System.Func<Amazon.MediaTailor.Model.ConfigureLogsForPlaybackConfigurationResponse, AddEMTLogsForPlaybackConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
