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
using Amazon.KinesisVideo;
using Amazon.KinesisVideo.Model;

namespace Amazon.PowerShell.Cmdlets.KV
{
    /// <summary>
    /// An asynchronous API that updates a stream’s existing edge configuration. If this API
    /// is invoked for the first time, a new edge configuration will be created for the stream,
    /// and the sync status will be set to <code>SYNCING</code>. 
    /// 
    ///  
    /// <para>
    /// The Kinesis Video Stream will sync the stream’s edge configuration with the Edge Agent
    /// IoT Greengrass component that runs on an IoT Hub Device setup at your premise. The
    /// time to sync can vary and depends on the connectivity of the Hub Device. The <code>SyncStatus</code>
    /// will be updated as the edge configuration is acknowledged, and synced with the Edge
    /// Agent. You will have to wait for the sync status to reach a terminal state such as:
    /// <code>IN_SYNC</code> and <code>SYNC_FAILED</code>, before using this API again.
    /// </para><para>
    /// If you invoke this API during the syncing process, a <code>ResourceInUseException</code>
    /// will be thrown. The connectivity of the stream's edge configuration and the Edge Agent
    /// will be retried for 15 minutes. After 15 minutes, the status will transition into
    /// the <code>SYNC_FAILED</code> state. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "KVEdgeConfigurationUpdate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams StartEdgeConfigurationUpdate API operation.", Operation = new[] {"StartEdgeConfigurationUpdate"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateResponse))]
    [AWSCmdletOutput("Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateResponse",
        "This cmdlet returns an Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartKVEdgeConfigurationUpdateCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        #region Parameter DeletionConfig_DeleteAfterUpload
        /// <summary>
        /// <para>
        /// <para>The <code>boolean</code> value used to indicate whether or not you want to mark the
        /// media for deletion, once it has been uploaded to the Kinesis Video Stream cloud. The
        /// media files can be deleted if any of the deletion configuration values are set to
        /// <code>true</code>, such as when the limit for the <code>EdgeRetentionInHours</code>,
        /// or the <code>MaxLocalMediaSizeInMB</code>, has been reached. </para><para>Since the default value is set to <code>true</code>, configure the uploader schedule
        /// such that the media files are not being deleted before they are initially uploaded
        /// to AWS cloud.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdgeConfig_DeletionConfig_DeleteAfterUpload")]
        public System.Boolean? DeletionConfig_DeleteAfterUpload { get; set; }
        #endregion
        
        #region Parameter EdgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The total duration to record the media. If the <code>ScheduleExpression</code> attribute
        /// is provided, then the <code>DurationInSeconds</code> attribute should also be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EdgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter EdgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The total duration to record the media. If the <code>ScheduleExpression</code> attribute
        /// is provided, then the <code>DurationInSeconds</code> attribute should also be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EdgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter DeletionConfig_EdgeRetentionInHour
        /// <summary>
        /// <para>
        /// <para>The number of hours that you want to retain the data in the stream on the Edge Agent.
        /// The default value of the retention time is 720 hours, which translates to 30 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdgeConfig_DeletionConfig_EdgeRetentionInHours")]
        public System.Int32? DeletionConfig_EdgeRetentionInHour { get; set; }
        #endregion
        
        #region Parameter EdgeConfig_HubDeviceArn
        /// <summary>
        /// <para>
        /// <para>The "<b>Internet of Things (IoT) Thing</b>" Arn of the stream.</para>
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
        public System.String EdgeConfig_HubDeviceArn { get; set; }
        #endregion
        
        #region Parameter LocalSizeConfig_MaxLocalMediaSizeInMB
        /// <summary>
        /// <para>
        /// <para>The overall maximum size of the media that you want to store for a stream on the Edge
        /// Agent. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdgeConfig_DeletionConfig_LocalSizeConfig_MaxLocalMediaSizeInMB")]
        public System.Int32? LocalSizeConfig_MaxLocalMediaSizeInMB { get; set; }
        #endregion
        
        #region Parameter MediaSourceConfig_MediaUriSecretArn
        /// <summary>
        /// <para>
        /// <para>The AWS Secrets Manager ARN for the username and password of the camera, or a local
        /// media file location.</para>
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
        [Alias("EdgeConfig_RecorderConfig_MediaSourceConfig_MediaUriSecretArn")]
        public System.String MediaSourceConfig_MediaUriSecretArn { get; set; }
        #endregion
        
        #region Parameter MediaSourceConfig_MediaUriType
        /// <summary>
        /// <para>
        /// <para>The Uniform Resource Identifier (Uri) type. The <code>FILE_URI</code> value can be
        /// used to stream local media files.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("EdgeConfig_RecorderConfig_MediaSourceConfig_MediaUriType")]
        [AWSConstantClassSource("Amazon.KinesisVideo.MediaUriType")]
        public Amazon.KinesisVideo.MediaUriType MediaSourceConfig_MediaUriType { get; set; }
        #endregion
        
        #region Parameter EdgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The Quartz cron expression that takes care of scheduling jobs to record from the camera,
        /// or local media file, onto the Edge Agent. If the <code>ScheduleExpression</code> is
        /// not provided for the <code>RecorderConfig</code>, then the Edge Agent will always
        /// be set to recording mode.</para><para>For more information about Quartz, refer to the <a href="http://www.quartz-scheduler.org/documentation/quartz-2.3.0/tutorials/crontrigger.html"><i>Cron Trigger Tutorial</i></a> page to understand the valid expressions and its
        /// use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EdgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter EdgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The Quartz cron expression that takes care of scheduling jobs to record from the camera,
        /// or local media file, onto the Edge Agent. If the <code>ScheduleExpression</code> is
        /// not provided for the <code>RecorderConfig</code>, then the Edge Agent will always
        /// be set to recording mode.</para><para>For more information about Quartz, refer to the <a href="http://www.quartz-scheduler.org/documentation/quartz-2.3.0/tutorials/crontrigger.html"><i>Cron Trigger Tutorial</i></a> page to understand the valid expressions and its
        /// use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EdgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter LocalSizeConfig_StrategyOnFullSize
        /// <summary>
        /// <para>
        /// <para>The strategy to perform when a stream’s <code>MaxLocalMediaSizeInMB</code> limit is
        /// reached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EdgeConfig_DeletionConfig_LocalSizeConfig_StrategyOnFullSize")]
        [AWSConstantClassSource("Amazon.KinesisVideo.StrategyOnFullSize")]
        public Amazon.KinesisVideo.StrategyOnFullSize LocalSizeConfig_StrategyOnFullSize { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the stream. Specify either the <code>StreamName</code>
        /// or the <code>StreamARN</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream whose edge configuration you want to update. Specify either
        /// the <code>StreamName</code> or the <code>StreamARN</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateResponse).
        /// Specifying the name of a property of type Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StreamARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StreamARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StreamARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-KVEdgeConfigurationUpdate (StartEdgeConfigurationUpdate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateResponse, StartKVEdgeConfigurationUpdateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StreamARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeletionConfig_DeleteAfterUpload = this.DeletionConfig_DeleteAfterUpload;
            context.DeletionConfig_EdgeRetentionInHour = this.DeletionConfig_EdgeRetentionInHour;
            context.LocalSizeConfig_MaxLocalMediaSizeInMB = this.LocalSizeConfig_MaxLocalMediaSizeInMB;
            context.LocalSizeConfig_StrategyOnFullSize = this.LocalSizeConfig_StrategyOnFullSize;
            context.EdgeConfig_HubDeviceArn = this.EdgeConfig_HubDeviceArn;
            #if MODULAR
            if (this.EdgeConfig_HubDeviceArn == null && ParameterWasBound(nameof(this.EdgeConfig_HubDeviceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EdgeConfig_HubDeviceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaSourceConfig_MediaUriSecretArn = this.MediaSourceConfig_MediaUriSecretArn;
            #if MODULAR
            if (this.MediaSourceConfig_MediaUriSecretArn == null && ParameterWasBound(nameof(this.MediaSourceConfig_MediaUriSecretArn)))
            {
                WriteWarning("You are passing $null as a value for parameter MediaSourceConfig_MediaUriSecretArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaSourceConfig_MediaUriType = this.MediaSourceConfig_MediaUriType;
            #if MODULAR
            if (this.MediaSourceConfig_MediaUriType == null && ParameterWasBound(nameof(this.MediaSourceConfig_MediaUriType)))
            {
                WriteWarning("You are passing $null as a value for parameter MediaSourceConfig_MediaUriType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EdgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds = this.EdgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds;
            context.EdgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression = this.EdgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression;
            context.EdgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds = this.EdgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds;
            context.EdgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression = this.EdgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression;
            context.StreamARN = this.StreamARN;
            context.StreamName = this.StreamName;
            
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
            var request = new Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateRequest();
            
            
             // populate EdgeConfig
            var requestEdgeConfigIsNull = true;
            request.EdgeConfig = new Amazon.KinesisVideo.Model.EdgeConfig();
            System.String requestEdgeConfig_edgeConfig_HubDeviceArn = null;
            if (cmdletContext.EdgeConfig_HubDeviceArn != null)
            {
                requestEdgeConfig_edgeConfig_HubDeviceArn = cmdletContext.EdgeConfig_HubDeviceArn;
            }
            if (requestEdgeConfig_edgeConfig_HubDeviceArn != null)
            {
                request.EdgeConfig.HubDeviceArn = requestEdgeConfig_edgeConfig_HubDeviceArn;
                requestEdgeConfigIsNull = false;
            }
            Amazon.KinesisVideo.Model.UploaderConfig requestEdgeConfig_edgeConfig_UploaderConfig = null;
            
             // populate UploaderConfig
            var requestEdgeConfig_edgeConfig_UploaderConfigIsNull = true;
            requestEdgeConfig_edgeConfig_UploaderConfig = new Amazon.KinesisVideo.Model.UploaderConfig();
            Amazon.KinesisVideo.Model.ScheduleConfig requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig = null;
            
             // populate ScheduleConfig
            var requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfigIsNull = true;
            requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig = new Amazon.KinesisVideo.Model.ScheduleConfig();
            System.Int32? requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig_edgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds = null;
            if (cmdletContext.EdgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds != null)
            {
                requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig_edgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds = cmdletContext.EdgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds.Value;
            }
            if (requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig_edgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds != null)
            {
                requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig.DurationInSeconds = requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig_edgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds.Value;
                requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfigIsNull = false;
            }
            System.String requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig_edgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression = null;
            if (cmdletContext.EdgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression != null)
            {
                requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig_edgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression = cmdletContext.EdgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression;
            }
            if (requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig_edgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression != null)
            {
                requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig.ScheduleExpression = requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig_edgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression;
                requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfigIsNull = false;
            }
             // determine if requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig should be set to null
            if (requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfigIsNull)
            {
                requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig = null;
            }
            if (requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig != null)
            {
                requestEdgeConfig_edgeConfig_UploaderConfig.ScheduleConfig = requestEdgeConfig_edgeConfig_UploaderConfig_edgeConfig_UploaderConfig_ScheduleConfig;
                requestEdgeConfig_edgeConfig_UploaderConfigIsNull = false;
            }
             // determine if requestEdgeConfig_edgeConfig_UploaderConfig should be set to null
            if (requestEdgeConfig_edgeConfig_UploaderConfigIsNull)
            {
                requestEdgeConfig_edgeConfig_UploaderConfig = null;
            }
            if (requestEdgeConfig_edgeConfig_UploaderConfig != null)
            {
                request.EdgeConfig.UploaderConfig = requestEdgeConfig_edgeConfig_UploaderConfig;
                requestEdgeConfigIsNull = false;
            }
            Amazon.KinesisVideo.Model.RecorderConfig requestEdgeConfig_edgeConfig_RecorderConfig = null;
            
             // populate RecorderConfig
            var requestEdgeConfig_edgeConfig_RecorderConfigIsNull = true;
            requestEdgeConfig_edgeConfig_RecorderConfig = new Amazon.KinesisVideo.Model.RecorderConfig();
            Amazon.KinesisVideo.Model.MediaSourceConfig requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig = null;
            
             // populate MediaSourceConfig
            var requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfigIsNull = true;
            requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig = new Amazon.KinesisVideo.Model.MediaSourceConfig();
            System.String requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig_mediaSourceConfig_MediaUriSecretArn = null;
            if (cmdletContext.MediaSourceConfig_MediaUriSecretArn != null)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig_mediaSourceConfig_MediaUriSecretArn = cmdletContext.MediaSourceConfig_MediaUriSecretArn;
            }
            if (requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig_mediaSourceConfig_MediaUriSecretArn != null)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig.MediaUriSecretArn = requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig_mediaSourceConfig_MediaUriSecretArn;
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfigIsNull = false;
            }
            Amazon.KinesisVideo.MediaUriType requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig_mediaSourceConfig_MediaUriType = null;
            if (cmdletContext.MediaSourceConfig_MediaUriType != null)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig_mediaSourceConfig_MediaUriType = cmdletContext.MediaSourceConfig_MediaUriType;
            }
            if (requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig_mediaSourceConfig_MediaUriType != null)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig.MediaUriType = requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig_mediaSourceConfig_MediaUriType;
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfigIsNull = false;
            }
             // determine if requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig should be set to null
            if (requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfigIsNull)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig = null;
            }
            if (requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig != null)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig.MediaSourceConfig = requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_MediaSourceConfig;
                requestEdgeConfig_edgeConfig_RecorderConfigIsNull = false;
            }
            Amazon.KinesisVideo.Model.ScheduleConfig requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig = null;
            
             // populate ScheduleConfig
            var requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfigIsNull = true;
            requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig = new Amazon.KinesisVideo.Model.ScheduleConfig();
            System.Int32? requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig_edgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds = null;
            if (cmdletContext.EdgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds != null)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig_edgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds = cmdletContext.EdgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds.Value;
            }
            if (requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig_edgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds != null)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig.DurationInSeconds = requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig_edgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds.Value;
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfigIsNull = false;
            }
            System.String requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig_edgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression = null;
            if (cmdletContext.EdgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression != null)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig_edgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression = cmdletContext.EdgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression;
            }
            if (requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig_edgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression != null)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig.ScheduleExpression = requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig_edgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression;
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfigIsNull = false;
            }
             // determine if requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig should be set to null
            if (requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfigIsNull)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig = null;
            }
            if (requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig != null)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig.ScheduleConfig = requestEdgeConfig_edgeConfig_RecorderConfig_edgeConfig_RecorderConfig_ScheduleConfig;
                requestEdgeConfig_edgeConfig_RecorderConfigIsNull = false;
            }
             // determine if requestEdgeConfig_edgeConfig_RecorderConfig should be set to null
            if (requestEdgeConfig_edgeConfig_RecorderConfigIsNull)
            {
                requestEdgeConfig_edgeConfig_RecorderConfig = null;
            }
            if (requestEdgeConfig_edgeConfig_RecorderConfig != null)
            {
                request.EdgeConfig.RecorderConfig = requestEdgeConfig_edgeConfig_RecorderConfig;
                requestEdgeConfigIsNull = false;
            }
            Amazon.KinesisVideo.Model.DeletionConfig requestEdgeConfig_edgeConfig_DeletionConfig = null;
            
             // populate DeletionConfig
            var requestEdgeConfig_edgeConfig_DeletionConfigIsNull = true;
            requestEdgeConfig_edgeConfig_DeletionConfig = new Amazon.KinesisVideo.Model.DeletionConfig();
            System.Boolean? requestEdgeConfig_edgeConfig_DeletionConfig_deletionConfig_DeleteAfterUpload = null;
            if (cmdletContext.DeletionConfig_DeleteAfterUpload != null)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig_deletionConfig_DeleteAfterUpload = cmdletContext.DeletionConfig_DeleteAfterUpload.Value;
            }
            if (requestEdgeConfig_edgeConfig_DeletionConfig_deletionConfig_DeleteAfterUpload != null)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig.DeleteAfterUpload = requestEdgeConfig_edgeConfig_DeletionConfig_deletionConfig_DeleteAfterUpload.Value;
                requestEdgeConfig_edgeConfig_DeletionConfigIsNull = false;
            }
            System.Int32? requestEdgeConfig_edgeConfig_DeletionConfig_deletionConfig_EdgeRetentionInHour = null;
            if (cmdletContext.DeletionConfig_EdgeRetentionInHour != null)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig_deletionConfig_EdgeRetentionInHour = cmdletContext.DeletionConfig_EdgeRetentionInHour.Value;
            }
            if (requestEdgeConfig_edgeConfig_DeletionConfig_deletionConfig_EdgeRetentionInHour != null)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig.EdgeRetentionInHours = requestEdgeConfig_edgeConfig_DeletionConfig_deletionConfig_EdgeRetentionInHour.Value;
                requestEdgeConfig_edgeConfig_DeletionConfigIsNull = false;
            }
            Amazon.KinesisVideo.Model.LocalSizeConfig requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig = null;
            
             // populate LocalSizeConfig
            var requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfigIsNull = true;
            requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig = new Amazon.KinesisVideo.Model.LocalSizeConfig();
            System.Int32? requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig_localSizeConfig_MaxLocalMediaSizeInMB = null;
            if (cmdletContext.LocalSizeConfig_MaxLocalMediaSizeInMB != null)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig_localSizeConfig_MaxLocalMediaSizeInMB = cmdletContext.LocalSizeConfig_MaxLocalMediaSizeInMB.Value;
            }
            if (requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig_localSizeConfig_MaxLocalMediaSizeInMB != null)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig.MaxLocalMediaSizeInMB = requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig_localSizeConfig_MaxLocalMediaSizeInMB.Value;
                requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfigIsNull = false;
            }
            Amazon.KinesisVideo.StrategyOnFullSize requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig_localSizeConfig_StrategyOnFullSize = null;
            if (cmdletContext.LocalSizeConfig_StrategyOnFullSize != null)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig_localSizeConfig_StrategyOnFullSize = cmdletContext.LocalSizeConfig_StrategyOnFullSize;
            }
            if (requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig_localSizeConfig_StrategyOnFullSize != null)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig.StrategyOnFullSize = requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig_localSizeConfig_StrategyOnFullSize;
                requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfigIsNull = false;
            }
             // determine if requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig should be set to null
            if (requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfigIsNull)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig = null;
            }
            if (requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig != null)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig.LocalSizeConfig = requestEdgeConfig_edgeConfig_DeletionConfig_edgeConfig_DeletionConfig_LocalSizeConfig;
                requestEdgeConfig_edgeConfig_DeletionConfigIsNull = false;
            }
             // determine if requestEdgeConfig_edgeConfig_DeletionConfig should be set to null
            if (requestEdgeConfig_edgeConfig_DeletionConfigIsNull)
            {
                requestEdgeConfig_edgeConfig_DeletionConfig = null;
            }
            if (requestEdgeConfig_edgeConfig_DeletionConfig != null)
            {
                request.EdgeConfig.DeletionConfig = requestEdgeConfig_edgeConfig_DeletionConfig;
                requestEdgeConfigIsNull = false;
            }
             // determine if request.EdgeConfig should be set to null
            if (requestEdgeConfigIsNull)
            {
                request.EdgeConfig = null;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
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
        
        private Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "StartEdgeConfigurationUpdate");
            try
            {
                #if DESKTOP
                return client.StartEdgeConfigurationUpdate(request);
                #elif CORECLR
                return client.StartEdgeConfigurationUpdateAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeletionConfig_DeleteAfterUpload { get; set; }
            public System.Int32? DeletionConfig_EdgeRetentionInHour { get; set; }
            public System.Int32? LocalSizeConfig_MaxLocalMediaSizeInMB { get; set; }
            public Amazon.KinesisVideo.StrategyOnFullSize LocalSizeConfig_StrategyOnFullSize { get; set; }
            public System.String EdgeConfig_HubDeviceArn { get; set; }
            public System.String MediaSourceConfig_MediaUriSecretArn { get; set; }
            public Amazon.KinesisVideo.MediaUriType MediaSourceConfig_MediaUriType { get; set; }
            public System.Int32? EdgeConfig_RecorderConfig_ScheduleConfig_DurationInSeconds { get; set; }
            public System.String EdgeConfig_RecorderConfig_ScheduleConfig_ScheduleExpression { get; set; }
            public System.Int32? EdgeConfig_UploaderConfig_ScheduleConfig_DurationInSeconds { get; set; }
            public System.String EdgeConfig_UploaderConfig_ScheduleConfig_ScheduleExpression { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.StartEdgeConfigurationUpdateResponse, StartKVEdgeConfigurationUpdateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
