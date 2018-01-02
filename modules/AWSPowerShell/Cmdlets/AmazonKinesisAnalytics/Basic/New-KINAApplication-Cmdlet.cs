/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates an Amazon Kinesis Analytics application. You can configure each application
    /// with one streaming source as input, application code to process the input, and up
    /// to three destinations where you want Amazon Kinesis Analytics to write the output
    /// data from your application. For an overview, see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works.html">How
    /// it Works</a>. 
    /// 
    ///  
    /// <para>
    /// In the input configuration, you map the streaming source to an in-application stream,
    /// which you can think of as a constantly updating table. In the mapping, you must provide
    /// a schema for the in-application stream and map each data column in the in-application
    /// stream to a data element in the streaming source.
    /// </para><para>
    /// Your application code is one or more SQL statements that read input data, transform
    /// it, and generate output. Your application code can create one or more SQL artifacts
    /// like SQL streams or pumps.
    /// </para><para>
    /// In the output configuration, you can configure the application to write data from
    /// in-application streams created in your applications to up to three destinations.
    /// </para><para>
    ///  To read data from your source stream or write data to destination streams, Amazon
    /// Kinesis Analytics needs your permissions. You grant these permissions by creating
    /// IAM roles. This operation requires permissions to perform the <code>kinesisanalytics:CreateApplication</code>
    /// action. 
    /// </para><para>
    ///  For introductory exercises to create an Amazon Kinesis Analytics application, see
    /// <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/getting-started.html">Getting
    /// Started</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINAApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalytics.Model.ApplicationSummary")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics CreateApplication API operation.", Operation = new[] {"CreateApplication"})]
    [AWSCmdletOutput("Amazon.KinesisAnalytics.Model.ApplicationSummary",
        "This cmdlet returns a ApplicationSummary object.",
        "The service call response (type Amazon.KinesisAnalytics.Model.CreateApplicationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKINAApplicationCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationCode
        /// <summary>
        /// <para>
        /// <para>One or more SQL statements that read input data, transform it, and generate output.
        /// For example, you can write a SQL statement that reads data from one in-application
        /// stream, generates a running average of the number of advertisement clicks by vendor,
        /// and insert resulting rows in another in-application stream using pumps. For more information
        /// about the typical pattern, see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works-app-code.html">Application
        /// Code</a>. </para><para>You can provide such series of SQL statements, where output of one statement can be
        /// used as the input for the next statement. You store intermediate results by creating
        /// in-application streams and pumps.</para><para>Note that the application code must create the streams with names specified in the
        /// <code>Outputs</code>. For example, if your <code>Outputs</code> defines output streams
        /// named <code>ExampleOutputStream1</code> and <code>ExampleOutputStream2</code>, then
        /// your application code must create these streams. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApplicationCode { get; set; }
        #endregion
        
        #region Parameter ApplicationDescription
        /// <summary>
        /// <para>
        /// <para>Summary description of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApplicationDescription { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>Name of your Amazon Kinesis Analytics application (for example, <code>sample-app</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOption
        /// <summary>
        /// <para>
        /// <para>Use this parameter to configure a CloudWatch log stream to monitor application configuration
        /// errors. For more information, see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/cloudwatch-logs.html">Working
        /// with Amazon CloudWatch Logs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CloudWatchLoggingOptions")]
        public Amazon.KinesisAnalytics.Model.CloudWatchLoggingOption[] CloudWatchLoggingOption { get; set; }
        #endregion
        
        #region Parameter Input
        /// <summary>
        /// <para>
        /// <para>Use this parameter to configure the application input.</para><para>You can configure your application to receive input from a single streaming source.
        /// In this configuration, you map this streaming source to an in-application stream that
        /// is created. Your application code can then query the in-application stream like a
        /// table (you can think of it as a constantly updating table).</para><para>For the streaming source, you provide its Amazon Resource Name (ARN) and format of
        /// data on the stream (for example, JSON, CSV, etc.). You also must provide an IAM role
        /// that Amazon Kinesis Analytics can assume to read this stream on your behalf.</para><para>To create the in-application stream, you need to specify a schema to transform your
        /// data into a schematized version used in SQL. In the schema, you provide the necessary
        /// mapping of the data elements in the streaming source to record columns in the in-app
        /// stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Inputs")]
        public Amazon.KinesisAnalytics.Model.Input[] Input { get; set; }
        #endregion
        
        #region Parameter Output
        /// <summary>
        /// <para>
        /// <para>You can configure application output to write data from any of the in-application
        /// streams to up to three destinations.</para><para>These destinations can be Amazon Kinesis streams, Amazon Kinesis Firehose delivery
        /// streams, Amazon Lambda destinations, or any combination of the three.</para><para>In the configuration, you specify the in-application stream name, the destination
        /// stream or Lambda function Amazon Resource Name (ARN), and the format to use when writing
        /// data. You must also provide an IAM role that Amazon Kinesis Analytics can assume to
        /// write to the destination stream or Lambda function on your behalf.</para><para>In the output configuration, you also provide the output stream or Lambda function
        /// ARN. For stream destinations, you provide the format of data in the stream (for example,
        /// JSON, CSV). You also must provide an IAM role that Amazon Kinesis Analytics can assume
        /// to write to the stream or Lambda function on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Outputs")]
        public Amazon.KinesisAnalytics.Model.Output[] Output { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINAApplication (CreateApplication)"))
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
            
            context.ApplicationCode = this.ApplicationCode;
            context.ApplicationDescription = this.ApplicationDescription;
            context.ApplicationName = this.ApplicationName;
            if (this.CloudWatchLoggingOption != null)
            {
                context.CloudWatchLoggingOptions = new List<Amazon.KinesisAnalytics.Model.CloudWatchLoggingOption>(this.CloudWatchLoggingOption);
            }
            if (this.Input != null)
            {
                context.Inputs = new List<Amazon.KinesisAnalytics.Model.Input>(this.Input);
            }
            if (this.Output != null)
            {
                context.Outputs = new List<Amazon.KinesisAnalytics.Model.Output>(this.Output);
            }
            
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
            var request = new Amazon.KinesisAnalytics.Model.CreateApplicationRequest();
            
            if (cmdletContext.ApplicationCode != null)
            {
                request.ApplicationCode = cmdletContext.ApplicationCode;
            }
            if (cmdletContext.ApplicationDescription != null)
            {
                request.ApplicationDescription = cmdletContext.ApplicationDescription;
            }
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CloudWatchLoggingOptions != null)
            {
                request.CloudWatchLoggingOptions = cmdletContext.CloudWatchLoggingOptions;
            }
            if (cmdletContext.Inputs != null)
            {
                request.Inputs = cmdletContext.Inputs;
            }
            if (cmdletContext.Outputs != null)
            {
                request.Outputs = cmdletContext.Outputs;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ApplicationSummary;
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
        
        private Amazon.KinesisAnalytics.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "CreateApplication");
            try
            {
                #if DESKTOP
                return client.CreateApplication(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateApplicationAsync(request);
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
            public System.String ApplicationCode { get; set; }
            public System.String ApplicationDescription { get; set; }
            public System.String ApplicationName { get; set; }
            public List<Amazon.KinesisAnalytics.Model.CloudWatchLoggingOption> CloudWatchLoggingOptions { get; set; }
            public List<Amazon.KinesisAnalytics.Model.Input> Inputs { get; set; }
            public List<Amazon.KinesisAnalytics.Model.Output> Outputs { get; set; }
        }
        
    }
}
