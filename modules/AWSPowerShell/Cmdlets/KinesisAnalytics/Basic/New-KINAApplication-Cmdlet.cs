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

namespace Amazon.PowerShell.Cmdlets.KINA
{
    /// <summary>
    /// <note><para>
    /// This documentation is for version 1 of the Amazon Kinesis Data Analytics API, which
    /// only supports SQL applications. Version 2 of the API supports SQL and Java applications.
    /// For more information about version 2, see <a href="/kinesisanalytics/latest/apiv2/Welcome.html">Amazon
    /// Kinesis Data Analytics API V2 Documentation</a>.
    /// </para></note><para>
    ///  Creates an Amazon Kinesis Analytics application. You can configure each application
    /// with one streaming source as input, application code to process the input, and up
    /// to three destinations where you want Amazon Kinesis Analytics to write the output
    /// data from your application. For an overview, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works.html">How
    /// it Works</a>. 
    /// </para><para>
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
    /// IAM roles. This operation requires permissions to perform the <c>kinesisanalytics:CreateApplication</c>
    /// action. 
    /// </para><para>
    ///  For introductory exercises to create an Amazon Kinesis Analytics application, see
    /// <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/getting-started.html">Getting
    /// Started</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINAApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KinesisAnalytics.Model.ApplicationSummary")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.KinesisAnalytics.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalytics.Model.ApplicationSummary or Amazon.KinesisAnalytics.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.KinesisAnalytics.Model.ApplicationSummary object.",
        "The service call response (type Amazon.KinesisAnalytics.Model.CreateApplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewKINAApplicationCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationCode
        /// <summary>
        /// <para>
        /// <para>One or more SQL statements that read input data, transform it, and generate output.
        /// For example, you can write a SQL statement that reads data from one in-application
        /// stream, generates a running average of the number of advertisement clicks by vendor,
        /// and insert resulting rows in another in-application stream using pumps. For more information
        /// about the typical pattern, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works-app-code.html">Application
        /// Code</a>. </para><para>You can provide such series of SQL statements, where output of one statement can be
        /// used as the input for the next statement. You store intermediate results by creating
        /// in-application streams and pumps.</para><para>Note that the application code must create the streams with names specified in the
        /// <c>Outputs</c>. For example, if your <c>Outputs</c> defines output streams named <c>ExampleOutputStream1</c>
        /// and <c>ExampleOutputStream2</c>, then your application code must create these streams.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationCode { get; set; }
        #endregion
        
        #region Parameter ApplicationDescription
        /// <summary>
        /// <para>
        /// <para>Summary description of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationDescription { get; set; }
        #endregion
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>Name of your Amazon Kinesis Analytics application (for example, <c>sample-app</c>).</para>
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
        
        #region Parameter CloudWatchLoggingOption
        /// <summary>
        /// <para>
        /// <para>Use this parameter to configure a CloudWatch log stream to monitor application configuration
        /// errors. For more information, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/cloudwatch-logs.html">Working
        /// with Amazon CloudWatch Logs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Inputs")]
        public Amazon.KinesisAnalytics.Model.Input[] Input { get; set; }
        #endregion
        
        #region Parameter Output
        /// <summary>
        /// <para>
        /// <para>You can configure application output to write data from any of the in-application
        /// streams to up to three destinations.</para><para>These destinations can be Amazon Kinesis streams, Amazon Kinesis Firehose delivery
        /// streams, AWS Lambda destinations, or any combination of the three.</para><para>In the configuration, you specify the in-application stream name, the destination
        /// stream or Lambda function Amazon Resource Name (ARN), and the format to use when writing
        /// data. You must also provide an IAM role that Amazon Kinesis Analytics can assume to
        /// write to the destination stream or Lambda function on your behalf.</para><para>In the output configuration, you also provide the output stream or Lambda function
        /// ARN. For stream destinations, you provide the format of data in the stream (for example,
        /// JSON, CSV). You also must provide an IAM role that Amazon Kinesis Analytics can assume
        /// to write to the stream or Lambda function on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Outputs")]
        public Amazon.KinesisAnalytics.Model.Output[] Output { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of one or more tags to assign to the application. A tag is a key-value pair
        /// that identifies an application. Note that the maximum number of application tags includes
        /// system tags. The maximum number of user-defined application tags is 50. For more information,
        /// see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-tagging.html">Using
        /// Tagging</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KinesisAnalytics.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalytics.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalytics.Model.CreateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationSummary";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINAApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalytics.Model.CreateApplicationResponse, NewKINAApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationCode = this.ApplicationCode;
            context.ApplicationDescription = this.ApplicationDescription;
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CloudWatchLoggingOption != null)
            {
                context.CloudWatchLoggingOption = new List<Amazon.KinesisAnalytics.Model.CloudWatchLoggingOption>(this.CloudWatchLoggingOption);
            }
            if (this.Input != null)
            {
                context.Input = new List<Amazon.KinesisAnalytics.Model.Input>(this.Input);
            }
            if (this.Output != null)
            {
                context.Output = new List<Amazon.KinesisAnalytics.Model.Output>(this.Output);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.KinesisAnalytics.Model.Tag>(this.Tag);
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
            if (cmdletContext.CloudWatchLoggingOption != null)
            {
                request.CloudWatchLoggingOptions = cmdletContext.CloudWatchLoggingOption;
            }
            if (cmdletContext.Input != null)
            {
                request.Inputs = cmdletContext.Input;
            }
            if (cmdletContext.Output != null)
            {
                request.Outputs = cmdletContext.Output;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.KinesisAnalytics.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "CreateApplication");
            try
            {
                return client.CreateApplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.KinesisAnalytics.Model.CloudWatchLoggingOption> CloudWatchLoggingOption { get; set; }
            public List<Amazon.KinesisAnalytics.Model.Input> Input { get; set; }
            public List<Amazon.KinesisAnalytics.Model.Output> Output { get; set; }
            public List<Amazon.KinesisAnalytics.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KinesisAnalytics.Model.CreateApplicationResponse, NewKINAApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationSummary;
        }
        
    }
}
