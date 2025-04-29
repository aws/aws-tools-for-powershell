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
using Amazon.Ivschat;
using Amazon.Ivschat.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IVSC
{
    /// <summary>
    /// Updates a specified logging configuration.
    /// </summary>
    [Cmdlet("Update", "IVSCLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Ivschat.Model.UpdateLoggingConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service Chat UpdateLoggingConfiguration API operation.", Operation = new[] {"UpdateLoggingConfiguration"}, SelectReturnType = typeof(Amazon.Ivschat.Model.UpdateLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Ivschat.Model.UpdateLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.Ivschat.Model.UpdateLoggingConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateIVSCLoggingConfigurationCmdlet : AmazonIvschatClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3_BucketName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon S3 bucket where chat activity will be logged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter Firehose_DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon Kinesis Firehose delivery stream where chat activity will be logged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_Firehose_DeliveryStreamName")]
        public System.String Firehose_DeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>Identifier of the logging configuration to be updated.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_LogGroupName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon Cloudwatch Logs destination where chat activity will be logged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_CloudWatchLogs_LogGroupName")]
        public System.String CloudWatchLogs_LogGroupName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Logging-configuration name. The value does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Ivschat.Model.UpdateLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Ivschat.Model.UpdateLoggingConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IVSCLoggingConfiguration (UpdateLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Ivschat.Model.UpdateLoggingConfigurationResponse, UpdateIVSCLoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CloudWatchLogs_LogGroupName = this.CloudWatchLogs_LogGroupName;
            context.Firehose_DeliveryStreamName = this.Firehose_DeliveryStreamName;
            context.S3_BucketName = this.S3_BucketName;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            
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
            var request = new Amazon.Ivschat.Model.UpdateLoggingConfigurationRequest();
            
            
             // populate DestinationConfiguration
            var requestDestinationConfigurationIsNull = true;
            request.DestinationConfiguration = new Amazon.Ivschat.Model.DestinationConfiguration();
            Amazon.Ivschat.Model.CloudWatchLogsDestinationConfiguration requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestDestinationConfiguration_destinationConfiguration_CloudWatchLogsIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs = new Amazon.Ivschat.Model.CloudWatchLogsDestinationConfiguration();
            System.String requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs_cloudWatchLogs_LogGroupName = null;
            if (cmdletContext.CloudWatchLogs_LogGroupName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs_cloudWatchLogs_LogGroupName = cmdletContext.CloudWatchLogs_LogGroupName;
            }
            if (requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs_cloudWatchLogs_LogGroupName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs.LogGroupName = requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs_cloudWatchLogs_LogGroupName;
                requestDestinationConfiguration_destinationConfiguration_CloudWatchLogsIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_CloudWatchLogsIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs != null)
            {
                request.DestinationConfiguration.CloudWatchLogs = requestDestinationConfiguration_destinationConfiguration_CloudWatchLogs;
                requestDestinationConfigurationIsNull = false;
            }
            Amazon.Ivschat.Model.FirehoseDestinationConfiguration requestDestinationConfiguration_destinationConfiguration_Firehose = null;
            
             // populate Firehose
            var requestDestinationConfiguration_destinationConfiguration_FirehoseIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_Firehose = new Amazon.Ivschat.Model.FirehoseDestinationConfiguration();
            System.String requestDestinationConfiguration_destinationConfiguration_Firehose_firehose_DeliveryStreamName = null;
            if (cmdletContext.Firehose_DeliveryStreamName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_Firehose_firehose_DeliveryStreamName = cmdletContext.Firehose_DeliveryStreamName;
            }
            if (requestDestinationConfiguration_destinationConfiguration_Firehose_firehose_DeliveryStreamName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_Firehose.DeliveryStreamName = requestDestinationConfiguration_destinationConfiguration_Firehose_firehose_DeliveryStreamName;
                requestDestinationConfiguration_destinationConfiguration_FirehoseIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_Firehose should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_FirehoseIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_Firehose = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_Firehose != null)
            {
                request.DestinationConfiguration.Firehose = requestDestinationConfiguration_destinationConfiguration_Firehose;
                requestDestinationConfigurationIsNull = false;
            }
            Amazon.Ivschat.Model.S3DestinationConfiguration requestDestinationConfiguration_destinationConfiguration_S3 = null;
            
             // populate S3
            var requestDestinationConfiguration_destinationConfiguration_S3IsNull = true;
            requestDestinationConfiguration_destinationConfiguration_S3 = new Amazon.Ivschat.Model.S3DestinationConfiguration();
            System.String requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName = null;
            if (cmdletContext.S3_BucketName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName = cmdletContext.S3_BucketName;
            }
            if (requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_S3.BucketName = requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName;
                requestDestinationConfiguration_destinationConfiguration_S3IsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_S3 should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_S3IsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_S3 = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_S3 != null)
            {
                request.DestinationConfiguration.S3 = requestDestinationConfiguration_destinationConfiguration_S3;
                requestDestinationConfigurationIsNull = false;
            }
             // determine if request.DestinationConfiguration should be set to null
            if (requestDestinationConfigurationIsNull)
            {
                request.DestinationConfiguration = null;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Ivschat.Model.UpdateLoggingConfigurationResponse CallAWSServiceOperation(IAmazonIvschat client, Amazon.Ivschat.Model.UpdateLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service Chat", "UpdateLoggingConfiguration");
            try
            {
                return client.UpdateLoggingConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CloudWatchLogs_LogGroupName { get; set; }
            public System.String Firehose_DeliveryStreamName { get; set; }
            public System.String S3_BucketName { get; set; }
            public System.String Identifier { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.Ivschat.Model.UpdateLoggingConfigurationResponse, UpdateIVSCLoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
