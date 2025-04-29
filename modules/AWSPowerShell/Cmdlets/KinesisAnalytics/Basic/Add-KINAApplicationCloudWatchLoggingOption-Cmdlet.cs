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
using Amazon.KinesisAnalytics;
using Amazon.KinesisAnalytics.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KINA
{
    /// <summary>
    /// <note><para>
    /// This documentation is for version 1 of the Amazon Kinesis Data Analytics API, which
    /// only supports SQL applications. Version 2 of the API supports SQL and Java applications.
    /// For more information about version 2, see <a href="/kinesisanalytics/latest/apiv2/Welcome.html">Amazon
    /// Kinesis Data Analytics API V2 Documentation</a>.
    /// </para></note><para>
    /// Adds a CloudWatch log stream to monitor application configuration errors. For more
    /// information about using CloudWatch log streams with Amazon Kinesis Analytics applications,
    /// see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/cloudwatch-logs.html">Working
    /// with Amazon CloudWatch Logs</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "KINAApplicationCloudWatchLoggingOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics AddApplicationCloudWatchLoggingOption API operation.", Operation = new[] {"AddApplicationCloudWatchLoggingOption"}, SelectReturnType = typeof(Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddKINAApplicationCloudWatchLoggingOptionCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The Kinesis Analytics application name.</para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the Kinesis Analytics application.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOption_LogStreamARN
        /// <summary>
        /// <para>
        /// <para>ARN of the CloudWatch log to receive application messages.</para>
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
        public System.String CloudWatchLoggingOption_LogStreamARN { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOption_RoleARN
        /// <summary>
        /// <para>
        /// <para>IAM ARN of the role to use to send application messages. Note: To write application
        /// messages to CloudWatch, the IAM role that is used must have the <c>PutLogEvents</c>
        /// policy action enabled.</para>
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
        public System.String CloudWatchLoggingOption_RoleARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KINAApplicationCloudWatchLoggingOption (AddApplicationCloudWatchLoggingOption)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionResponse, AddKINAApplicationCloudWatchLoggingOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudWatchLoggingOption_LogStreamARN = this.CloudWatchLoggingOption_LogStreamARN;
            #if MODULAR
            if (this.CloudWatchLoggingOption_LogStreamARN == null && ParameterWasBound(nameof(this.CloudWatchLoggingOption_LogStreamARN)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudWatchLoggingOption_LogStreamARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudWatchLoggingOption_RoleARN = this.CloudWatchLoggingOption_RoleARN;
            #if MODULAR
            if (this.CloudWatchLoggingOption_RoleARN == null && ParameterWasBound(nameof(this.CloudWatchLoggingOption_RoleARN)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudWatchLoggingOption_RoleARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            #if MODULAR
            if (this.CurrentApplicationVersionId == null && ParameterWasBound(nameof(this.CurrentApplicationVersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentApplicationVersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            
             // populate CloudWatchLoggingOption
            var requestCloudWatchLoggingOptionIsNull = true;
            request.CloudWatchLoggingOption = new Amazon.KinesisAnalytics.Model.CloudWatchLoggingOption();
            System.String requestCloudWatchLoggingOption_cloudWatchLoggingOption_LogStreamARN = null;
            if (cmdletContext.CloudWatchLoggingOption_LogStreamARN != null)
            {
                requestCloudWatchLoggingOption_cloudWatchLoggingOption_LogStreamARN = cmdletContext.CloudWatchLoggingOption_LogStreamARN;
            }
            if (requestCloudWatchLoggingOption_cloudWatchLoggingOption_LogStreamARN != null)
            {
                request.CloudWatchLoggingOption.LogStreamARN = requestCloudWatchLoggingOption_cloudWatchLoggingOption_LogStreamARN;
                requestCloudWatchLoggingOptionIsNull = false;
            }
            System.String requestCloudWatchLoggingOption_cloudWatchLoggingOption_RoleARN = null;
            if (cmdletContext.CloudWatchLoggingOption_RoleARN != null)
            {
                requestCloudWatchLoggingOption_cloudWatchLoggingOption_RoleARN = cmdletContext.CloudWatchLoggingOption_RoleARN;
            }
            if (requestCloudWatchLoggingOption_cloudWatchLoggingOption_RoleARN != null)
            {
                request.CloudWatchLoggingOption.RoleARN = requestCloudWatchLoggingOption_cloudWatchLoggingOption_RoleARN;
                requestCloudWatchLoggingOptionIsNull = false;
            }
             // determine if request.CloudWatchLoggingOption should be set to null
            if (requestCloudWatchLoggingOptionIsNull)
            {
                request.CloudWatchLoggingOption = null;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
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
        
        private Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "AddApplicationCloudWatchLoggingOption");
            try
            {
                return client.AddApplicationCloudWatchLoggingOptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public System.String CloudWatchLoggingOption_LogStreamARN { get; set; }
            public System.String CloudWatchLoggingOption_RoleARN { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public System.Func<Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionResponse, AddKINAApplicationCloudWatchLoggingOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
