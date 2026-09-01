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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Updates the data freshness interval or the Amazon CloudWatch Logs configuration of
    /// an existing channel. You cannot change the destination, source stream, record format,
    /// schema, encryption configuration, or service execution role of an existing channel.
    /// To change any other setting, delete the channel and create a new one.
    /// 
    ///  
    /// <para>
    /// Updating a channel is an asynchronous operation. Upon receiving the request, Amazon
    /// Kinesis Data Streams sets the channel to the <c>UPDATING</c> state and returns immediately.
    /// After the change is applied, Amazon Kinesis Data Streams sets the channel back to
    /// the <c>ACTIVE</c> state.
    /// </para><para>
    /// This operation has a call limit of 5 transactions per second (TPS) for each Amazon
    /// Web Services account. Exceeding 5 TPS results in a <c>LimitExceededException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.ChannelDescription")]
    [AWSCmdlet("Calls the Amazon Kinesis UpdateChannel API operation.", Operation = new[] {"UpdateChannel"}, SelectReturnType = typeof(Amazon.Kinesis.Model.UpdateChannelResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.ChannelDescription or Amazon.Kinesis.Model.UpdateChannelResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.ChannelDescription object.",
        "The service call response (type Amazon.Kinesis.Model.UpdateChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateKINChannelCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChannelARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the channel to update.</para>
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
        public System.String ChannelARN { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_DataFreshnessInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum age, in seconds, of undelivered data. Valid range is 300 to 900 seconds
        /// (5 to 15 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3DestinationConfiguration_DataFreshnessInSeconds")]
        public System.Int32? S3DestinationConfiguration_DataFreshnessInSecond { get; set; }
        #endregion
        
        #region Parameter S3TablesDestinationConfiguration_DataFreshnessInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum age, in seconds, of undelivered data. Valid range is 300 to 900 seconds
        /// (5 to 15 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3TablesDestinationConfiguration_DataFreshnessInSeconds")]
        public System.Int32? S3TablesDestinationConfiguration_DataFreshnessInSecond { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_CloudWatchLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether logging to Amazon CloudWatch Logs is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingConfiguration_CloudWatchLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_CloudWatchLogs_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon CloudWatch Logs log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_CloudWatchLogs_LogGroupName { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_CloudWatchLogs_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon CloudWatch Logs log stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_CloudWatchLogs_LogStreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.UpdateChannelResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.UpdateChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelDescription";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINChannel (UpdateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.UpdateChannelResponse, UpdateKINChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelARN = this.ChannelARN;
            #if MODULAR
            if (this.ChannelARN == null && ParameterWasBound(nameof(this.ChannelARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoggingConfiguration_CloudWatchLogs_Enabled = this.LoggingConfiguration_CloudWatchLogs_Enabled;
            context.LoggingConfiguration_CloudWatchLogs_LogGroupName = this.LoggingConfiguration_CloudWatchLogs_LogGroupName;
            context.LoggingConfiguration_CloudWatchLogs_LogStreamName = this.LoggingConfiguration_CloudWatchLogs_LogStreamName;
            context.S3DestinationConfiguration_DataFreshnessInSecond = this.S3DestinationConfiguration_DataFreshnessInSecond;
            context.S3TablesDestinationConfiguration_DataFreshnessInSecond = this.S3TablesDestinationConfiguration_DataFreshnessInSecond;
            
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
            var request = new Amazon.Kinesis.Model.UpdateChannelRequest();
            
            if (cmdletContext.ChannelARN != null)
            {
                request.ChannelARN = cmdletContext.ChannelARN;
            }
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.Kinesis.Model.ChannelLoggingUpdateInput();
            Amazon.Kinesis.Model.CloudWatchLogsUpdateInput requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestLoggingConfiguration_loggingConfiguration_CloudWatchLogsIsNull = true;
            requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs = new Amazon.Kinesis.Model.CloudWatchLogsUpdateInput();
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_Enabled = null;
            if (cmdletContext.LoggingConfiguration_CloudWatchLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_Enabled = cmdletContext.LoggingConfiguration_CloudWatchLogs_Enabled.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs.Enabled = requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_Enabled.Value;
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogsIsNull = false;
            }
            System.String requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogGroupName = null;
            if (cmdletContext.LoggingConfiguration_CloudWatchLogs_LogGroupName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogGroupName = cmdletContext.LoggingConfiguration_CloudWatchLogs_LogGroupName;
            }
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogGroupName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs.LogGroupName = requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogGroupName;
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogsIsNull = false;
            }
            System.String requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogStreamName = null;
            if (cmdletContext.LoggingConfiguration_CloudWatchLogs_LogStreamName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogStreamName = cmdletContext.LoggingConfiguration_CloudWatchLogs_LogStreamName;
            }
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogStreamName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs.LogStreamName = requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogStreamName;
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogsIsNull = false;
            }
             // determine if requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs should be set to null
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogsIsNull)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs = null;
            }
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs != null)
            {
                request.LoggingConfiguration.CloudWatchLogs = requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
            }
            
             // populate S3DestinationConfiguration
            var requestS3DestinationConfigurationIsNull = true;
            request.S3DestinationConfiguration = new Amazon.Kinesis.Model.S3DestinationUpdateInput();
            System.Int32? requestS3DestinationConfiguration_s3DestinationConfiguration_DataFreshnessInSecond = null;
            if (cmdletContext.S3DestinationConfiguration_DataFreshnessInSecond != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DataFreshnessInSecond = cmdletContext.S3DestinationConfiguration_DataFreshnessInSecond.Value;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DataFreshnessInSecond != null)
            {
                request.S3DestinationConfiguration.DataFreshnessInSeconds = requestS3DestinationConfiguration_s3DestinationConfiguration_DataFreshnessInSecond.Value;
                requestS3DestinationConfigurationIsNull = false;
            }
             // determine if request.S3DestinationConfiguration should be set to null
            if (requestS3DestinationConfigurationIsNull)
            {
                request.S3DestinationConfiguration = null;
            }
            
             // populate S3TablesDestinationConfiguration
            var requestS3TablesDestinationConfigurationIsNull = true;
            request.S3TablesDestinationConfiguration = new Amazon.Kinesis.Model.S3TablesDestinationUpdateInput();
            System.Int32? requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DataFreshnessInSecond = null;
            if (cmdletContext.S3TablesDestinationConfiguration_DataFreshnessInSecond != null)
            {
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DataFreshnessInSecond = cmdletContext.S3TablesDestinationConfiguration_DataFreshnessInSecond.Value;
            }
            if (requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DataFreshnessInSecond != null)
            {
                request.S3TablesDestinationConfiguration.DataFreshnessInSeconds = requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DataFreshnessInSecond.Value;
                requestS3TablesDestinationConfigurationIsNull = false;
            }
             // determine if request.S3TablesDestinationConfiguration should be set to null
            if (requestS3TablesDestinationConfigurationIsNull)
            {
                request.S3TablesDestinationConfiguration = null;
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
        
        private Amazon.Kinesis.Model.UpdateChannelResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.UpdateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "UpdateChannel");
            try
            {
                return client.UpdateChannelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChannelARN { get; set; }
            public System.Boolean? LoggingConfiguration_CloudWatchLogs_Enabled { get; set; }
            public System.String LoggingConfiguration_CloudWatchLogs_LogGroupName { get; set; }
            public System.String LoggingConfiguration_CloudWatchLogs_LogStreamName { get; set; }
            public System.Int32? S3DestinationConfiguration_DataFreshnessInSecond { get; set; }
            public System.Int32? S3TablesDestinationConfiguration_DataFreshnessInSecond { get; set; }
            public System.Func<Amazon.Kinesis.Model.UpdateChannelResponse, UpdateKINChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelDescription;
        }
        
    }
}
