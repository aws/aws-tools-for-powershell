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
    /// Infers a schema by evaluating sample records on the specified streaming source (Amazon
    /// Kinesis stream or Amazon Kinesis Firehose delivery stream) or S3 object. In the response,
    /// the operation returns the inferred schema and also the sample records that the operation
    /// used to infer the schema.
    /// </para><para>
    ///  You can use the inferred schema when configuring a streaming source for your application.
    /// For conceptual information, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works-input.html">Configuring
    /// Application Input</a>. Note that when you create an application using the Amazon Kinesis
    /// Analytics console, the console uses this operation to infer a schema and show it in
    /// the console user interface. 
    /// </para><para>
    ///  This operation requires permissions to perform the <c>kinesisanalytics:DiscoverInputSchema</c>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("Find", "KINAInputSchema")]
    [OutputType("Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics DiscoverInputSchema API operation.", Operation = new[] {"DiscoverInputSchema"}, SelectReturnType = typeof(Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse",
        "This cmdlet returns an Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse object containing multiple properties."
    )]
    public partial class FindKINAInputSchemaCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3Configuration_BucketARN
        /// <summary>
        /// <para>
        /// <para>ARN of the S3 bucket that contains the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Configuration_BucketARN { get; set; }
        #endregion
        
        #region Parameter S3Configuration_FileKey
        /// <summary>
        /// <para>
        /// <para>The name of the object that contains the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Configuration_FileKey { get; set; }
        #endregion
        
        #region Parameter InputStartingPositionConfiguration_InputStartingPosition
        /// <summary>
        /// <para>
        /// <para>The starting position on the stream.</para><ul><li><para><c>NOW</c> - Start reading just after the most recent record in the stream, start
        /// at the request time stamp that the customer issued.</para></li><li><para><c>TRIM_HORIZON</c> - Start reading at the last untrimmed record in the stream, which
        /// is the oldest record available in the stream. This option is not available for an
        /// Amazon Kinesis Firehose delivery stream.</para></li><li><para><c>LAST_STOPPED_POINT</c> - Resume reading from where the application last stopped
        /// reading.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisAnalytics.InputStartingPosition")]
        public Amazon.KinesisAnalytics.InputStartingPosition InputStartingPositionConfiguration_InputStartingPosition { get; set; }
        #endregion
        
        #region Parameter InputLambdaProcessor_ResourceARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the <a href="https://docs.aws.amazon.com/lambda/">AWS Lambda</a> function
        /// that operates on records in the stream.</para><note><para>To specify an earlier version of the Lambda function than the latest, include the
        /// Lambda function version in the Lambda function ARN. For more information about Lambda
        /// ARNs, see <a href="/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-lambda">Example
        /// ARNs: AWS Lambda</a></para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputProcessingConfiguration_InputLambdaProcessor_ResourceARN")]
        public System.String InputLambdaProcessor_ResourceARN { get; set; }
        #endregion
        
        #region Parameter ResourceARN
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the streaming source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceARN { get; set; }
        #endregion
        
        #region Parameter InputLambdaProcessor_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that is used to access the AWS Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputProcessingConfiguration_InputLambdaProcessor_RoleARN")]
        public System.String InputLambdaProcessor_RoleARN { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that Amazon Kinesis Analytics can assume to access the stream
        /// on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter S3Configuration_RoleARN
        /// <summary>
        /// <para>
        /// <para>IAM ARN of the role used to access the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Configuration_RoleARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse, FindKINAInputSchemaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InputLambdaProcessor_ResourceARN = this.InputLambdaProcessor_ResourceARN;
            context.InputLambdaProcessor_RoleARN = this.InputLambdaProcessor_RoleARN;
            context.InputStartingPositionConfiguration_InputStartingPosition = this.InputStartingPositionConfiguration_InputStartingPosition;
            context.ResourceARN = this.ResourceARN;
            context.RoleARN = this.RoleARN;
            context.S3Configuration_BucketARN = this.S3Configuration_BucketARN;
            context.S3Configuration_FileKey = this.S3Configuration_FileKey;
            context.S3Configuration_RoleARN = this.S3Configuration_RoleARN;
            
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
            var request = new Amazon.KinesisAnalytics.Model.DiscoverInputSchemaRequest();
            
            
             // populate InputProcessingConfiguration
            var requestInputProcessingConfigurationIsNull = true;
            request.InputProcessingConfiguration = new Amazon.KinesisAnalytics.Model.InputProcessingConfiguration();
            Amazon.KinesisAnalytics.Model.InputLambdaProcessor requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor = null;
            
             // populate InputLambdaProcessor
            var requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessorIsNull = true;
            requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor = new Amazon.KinesisAnalytics.Model.InputLambdaProcessor();
            System.String requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN = null;
            if (cmdletContext.InputLambdaProcessor_ResourceARN != null)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN = cmdletContext.InputLambdaProcessor_ResourceARN;
            }
            if (requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN != null)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor.ResourceARN = requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN;
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessorIsNull = false;
            }
            System.String requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_RoleARN = null;
            if (cmdletContext.InputLambdaProcessor_RoleARN != null)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_RoleARN = cmdletContext.InputLambdaProcessor_RoleARN;
            }
            if (requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_RoleARN != null)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor.RoleARN = requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_RoleARN;
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessorIsNull = false;
            }
             // determine if requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor should be set to null
            if (requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessorIsNull)
            {
                requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor = null;
            }
            if (requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor != null)
            {
                request.InputProcessingConfiguration.InputLambdaProcessor = requestInputProcessingConfiguration_inputProcessingConfiguration_InputLambdaProcessor;
                requestInputProcessingConfigurationIsNull = false;
            }
             // determine if request.InputProcessingConfiguration should be set to null
            if (requestInputProcessingConfigurationIsNull)
            {
                request.InputProcessingConfiguration = null;
            }
            
             // populate InputStartingPositionConfiguration
            var requestInputStartingPositionConfigurationIsNull = true;
            request.InputStartingPositionConfiguration = new Amazon.KinesisAnalytics.Model.InputStartingPositionConfiguration();
            Amazon.KinesisAnalytics.InputStartingPosition requestInputStartingPositionConfiguration_inputStartingPositionConfiguration_InputStartingPosition = null;
            if (cmdletContext.InputStartingPositionConfiguration_InputStartingPosition != null)
            {
                requestInputStartingPositionConfiguration_inputStartingPositionConfiguration_InputStartingPosition = cmdletContext.InputStartingPositionConfiguration_InputStartingPosition;
            }
            if (requestInputStartingPositionConfiguration_inputStartingPositionConfiguration_InputStartingPosition != null)
            {
                request.InputStartingPositionConfiguration.InputStartingPosition = requestInputStartingPositionConfiguration_inputStartingPositionConfiguration_InputStartingPosition;
                requestInputStartingPositionConfigurationIsNull = false;
            }
             // determine if request.InputStartingPositionConfiguration should be set to null
            if (requestInputStartingPositionConfigurationIsNull)
            {
                request.InputStartingPositionConfiguration = null;
            }
            if (cmdletContext.ResourceARN != null)
            {
                request.ResourceARN = cmdletContext.ResourceARN;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            
             // populate S3Configuration
            var requestS3ConfigurationIsNull = true;
            request.S3Configuration = new Amazon.KinesisAnalytics.Model.S3Configuration();
            System.String requestS3Configuration_s3Configuration_BucketARN = null;
            if (cmdletContext.S3Configuration_BucketARN != null)
            {
                requestS3Configuration_s3Configuration_BucketARN = cmdletContext.S3Configuration_BucketARN;
            }
            if (requestS3Configuration_s3Configuration_BucketARN != null)
            {
                request.S3Configuration.BucketARN = requestS3Configuration_s3Configuration_BucketARN;
                requestS3ConfigurationIsNull = false;
            }
            System.String requestS3Configuration_s3Configuration_FileKey = null;
            if (cmdletContext.S3Configuration_FileKey != null)
            {
                requestS3Configuration_s3Configuration_FileKey = cmdletContext.S3Configuration_FileKey;
            }
            if (requestS3Configuration_s3Configuration_FileKey != null)
            {
                request.S3Configuration.FileKey = requestS3Configuration_s3Configuration_FileKey;
                requestS3ConfigurationIsNull = false;
            }
            System.String requestS3Configuration_s3Configuration_RoleARN = null;
            if (cmdletContext.S3Configuration_RoleARN != null)
            {
                requestS3Configuration_s3Configuration_RoleARN = cmdletContext.S3Configuration_RoleARN;
            }
            if (requestS3Configuration_s3Configuration_RoleARN != null)
            {
                request.S3Configuration.RoleARN = requestS3Configuration_s3Configuration_RoleARN;
                requestS3ConfigurationIsNull = false;
            }
             // determine if request.S3Configuration should be set to null
            if (requestS3ConfigurationIsNull)
            {
                request.S3Configuration = null;
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
        
        private Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.DiscoverInputSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "DiscoverInputSchema");
            try
            {
                return client.DiscoverInputSchemaAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InputLambdaProcessor_ResourceARN { get; set; }
            public System.String InputLambdaProcessor_RoleARN { get; set; }
            public Amazon.KinesisAnalytics.InputStartingPosition InputStartingPositionConfiguration_InputStartingPosition { get; set; }
            public System.String ResourceARN { get; set; }
            public System.String RoleARN { get; set; }
            public System.String S3Configuration_BucketARN { get; set; }
            public System.String S3Configuration_FileKey { get; set; }
            public System.String S3Configuration_RoleARN { get; set; }
            public System.Func<Amazon.KinesisAnalytics.Model.DiscoverInputSchemaResponse, FindKINAInputSchemaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
