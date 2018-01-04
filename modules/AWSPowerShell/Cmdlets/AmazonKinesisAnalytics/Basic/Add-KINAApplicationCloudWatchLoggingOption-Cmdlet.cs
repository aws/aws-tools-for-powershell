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
using Amazon.KinesisAnalytics;
using Amazon.KinesisAnalytics.Model;

namespace Amazon.PowerShell.Cmdlets.KINA
{
    /// <summary>
    /// Adds a CloudWatch log stream to monitor application configuration errors. For more
    /// information about using CloudWatch log streams with Amazon Kinesis Analytics applications,
    /// see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/cloudwatch-logs.html">Working
    /// with Amazon CloudWatch Logs</a>.
    /// </summary>
    [Cmdlet("Add", "KINAApplicationCloudWatchLoggingOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics AddApplicationCloudWatchLoggingOption API operation.", Operation = new[] {"AddApplicationCloudWatchLoggingOption"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ApplicationName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddKINAApplicationCloudWatchLoggingOptionCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The Kinesis Analytics application name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the Kinesis Analytics application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64 CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOption_LogStreamARN
        /// <summary>
        /// <para>
        /// <para>ARN of the CloudWatch log to receive application messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloudWatchLoggingOption_LogStreamARN { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOption_RoleARN
        /// <summary>
        /// <para>
        /// <para>IAM ARN of the role to use to send application messages. Note: To write application
        /// messages to CloudWatch, the IAM role that is used must have the <code>PutLogEvents</code>
        /// policy action enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloudWatchLoggingOption_RoleARN { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ApplicationName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KINAApplicationCloudWatchLoggingOption (AddApplicationCloudWatchLoggingOption)"))
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
            
            context.ApplicationName = this.ApplicationName;
            context.CloudWatchLoggingOption_LogStreamARN = this.CloudWatchLoggingOption_LogStreamARN;
            context.CloudWatchLoggingOption_RoleARN = this.CloudWatchLoggingOption_RoleARN;
            if (ParameterWasBound("CurrentApplicationVersionId"))
                context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            
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
            bool requestCloudWatchLoggingOptionIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ApplicationName;
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
        
        private Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.AddApplicationCloudWatchLoggingOptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "AddApplicationCloudWatchLoggingOption");
            try
            {
                #if DESKTOP
                return client.AddApplicationCloudWatchLoggingOption(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AddApplicationCloudWatchLoggingOptionAsync(request);
                return task.Result;
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
            public System.String ApplicationName { get; set; }
            public System.String CloudWatchLoggingOption_LogStreamARN { get; set; }
            public System.String CloudWatchLoggingOption_RoleARN { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
        }
        
    }
}
