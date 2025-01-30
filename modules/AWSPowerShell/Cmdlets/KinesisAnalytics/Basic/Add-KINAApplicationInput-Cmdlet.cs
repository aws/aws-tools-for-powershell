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
    ///  Adds a streaming source to your Amazon Kinesis application. For conceptual information,
    /// see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works-input.html">Configuring
    /// Application Input</a>. 
    /// </para><para>
    /// You can add a streaming source either when you create an application or you can use
    /// this operation to add a streaming source after you create an application. For more
    /// information, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/API_CreateApplication.html">CreateApplication</a>.
    /// </para><para>
    /// Any configuration update, including adding a streaming source using this operation,
    /// results in a new version of the application. You can use the <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/API_DescribeApplication.html">DescribeApplication</a>
    /// operation to find the current application version. 
    /// </para><para>
    /// This operation requires permissions to perform the <c>kinesisanalytics:AddApplicationInput</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "KINAApplicationInput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics AddApplicationInput API operation.", Operation = new[] {"AddApplicationInput"}, SelectReturnType = typeof(Amazon.KinesisAnalytics.Model.AddApplicationInputResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisAnalytics.Model.AddApplicationInputResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisAnalytics.Model.AddApplicationInputResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddKINAApplicationInputCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>Name of your existing Amazon Kinesis Analytics application to which you want to add
        /// the streaming source.</para>
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
        
        #region Parameter InputParallelism_Count
        /// <summary>
        /// <para>
        /// <para>Number of in-application streams to create. For more information, see <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/limits.html">Limits</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_InputParallelism_Count")]
        public System.Int32? InputParallelism_Count { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>Current version of your Amazon Kinesis Analytics application. You can use the <a href="https://docs.aws.amazon.com/kinesisanalytics/latest/dev/API_DescribeApplication.html">DescribeApplication</a>
        /// operation to find the current application version.</para>
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
        
        #region Parameter Input_NamePrefix
        /// <summary>
        /// <para>
        /// <para>Name prefix to use when creating an in-application stream. Suppose that you specify
        /// a prefix "MyInApplicationStream." Amazon Kinesis Analytics then creates one or more
        /// (as per the <c>InputParallelism</c> count you specified) in-application streams with
        /// names "MyInApplicationStream_001," "MyInApplicationStream_002," and so on. </para>
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
        public System.String Input_NamePrefix { get; set; }
        #endregion
        
        #region Parameter CSVMappingParameters_RecordColumnDelimiter
        /// <summary>
        /// <para>
        /// <para>Column delimiter. For example, in a CSV format, a comma (",") is the typical column
        /// delimiter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter")]
        public System.String CSVMappingParameters_RecordColumnDelimiter { get; set; }
        #endregion
        
        #region Parameter InputSchema_RecordColumn
        /// <summary>
        /// <para>
        /// <para>A list of <c>RecordColumn</c> objects.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Input_InputSchema_RecordColumns")]
        public Amazon.KinesisAnalytics.Model.RecordColumn[] InputSchema_RecordColumn { get; set; }
        #endregion
        
        #region Parameter InputSchema_RecordEncoding
        /// <summary>
        /// <para>
        /// <para>Specifies the encoding of the records in the streaming source. For example, UTF-8.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_InputSchema_RecordEncoding")]
        public System.String InputSchema_RecordEncoding { get; set; }
        #endregion
        
        #region Parameter RecordFormat_RecordFormatType
        /// <summary>
        /// <para>
        /// <para>The type of record format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Input_InputSchema_RecordFormat_RecordFormatType")]
        [AWSConstantClassSource("Amazon.KinesisAnalytics.RecordFormatType")]
        public Amazon.KinesisAnalytics.RecordFormatType RecordFormat_RecordFormatType { get; set; }
        #endregion
        
        #region Parameter CSVMappingParameters_RecordRowDelimiter
        /// <summary>
        /// <para>
        /// <para>Row delimiter. For example, in a CSV format, <i>'\n'</i> is the typical row delimiter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter")]
        public System.String CSVMappingParameters_RecordRowDelimiter { get; set; }
        #endregion
        
        #region Parameter JSONMappingParameters_RecordRowPath
        /// <summary>
        /// <para>
        /// <para>Path to the top-level parent that contains the records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath")]
        public System.String JSONMappingParameters_RecordRowPath { get; set; }
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
        [Alias("Input_InputProcessingConfiguration_InputLambdaProcessor_ResourceARN")]
        public System.String InputLambdaProcessor_ResourceARN { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseInput_ResourceARN
        /// <summary>
        /// <para>
        /// <para>ARN of the input delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_KinesisFirehoseInput_ResourceARN")]
        public System.String KinesisFirehoseInput_ResourceARN { get; set; }
        #endregion
        
        #region Parameter KinesisStreamsInput_ResourceARN
        /// <summary>
        /// <para>
        /// <para>ARN of the input Amazon Kinesis stream to read.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_KinesisStreamsInput_ResourceARN")]
        public System.String KinesisStreamsInput_ResourceARN { get; set; }
        #endregion
        
        #region Parameter InputLambdaProcessor_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that is used to access the AWS Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_InputProcessingConfiguration_InputLambdaProcessor_RoleARN")]
        public System.String InputLambdaProcessor_RoleARN { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseInput_RoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that Amazon Kinesis Analytics can assume to access the stream
        /// on your behalf. You need to make sure that the role has the necessary permissions
        /// to access the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_KinesisFirehoseInput_RoleARN")]
        public System.String KinesisFirehoseInput_RoleARN { get; set; }
        #endregion
        
        #region Parameter KinesisStreamsInput_RoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that Amazon Kinesis Analytics can assume to access the stream
        /// on your behalf. You need to grant the necessary permissions to this role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_KinesisStreamsInput_RoleARN")]
        public System.String KinesisStreamsInput_RoleARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalytics.Model.AddApplicationInputResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KINAApplicationInput (AddApplicationInput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalytics.Model.AddApplicationInputResponse, AddKINAApplicationInputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            #if MODULAR
            if (this.CurrentApplicationVersionId == null && ParameterWasBound(nameof(this.CurrentApplicationVersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentApplicationVersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputParallelism_Count = this.InputParallelism_Count;
            context.InputLambdaProcessor_ResourceARN = this.InputLambdaProcessor_ResourceARN;
            context.InputLambdaProcessor_RoleARN = this.InputLambdaProcessor_RoleARN;
            if (this.InputSchema_RecordColumn != null)
            {
                context.InputSchema_RecordColumn = new List<Amazon.KinesisAnalytics.Model.RecordColumn>(this.InputSchema_RecordColumn);
            }
            #if MODULAR
            if (this.InputSchema_RecordColumn == null && ParameterWasBound(nameof(this.InputSchema_RecordColumn)))
            {
                WriteWarning("You are passing $null as a value for parameter InputSchema_RecordColumn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputSchema_RecordEncoding = this.InputSchema_RecordEncoding;
            context.CSVMappingParameters_RecordColumnDelimiter = this.CSVMappingParameters_RecordColumnDelimiter;
            context.CSVMappingParameters_RecordRowDelimiter = this.CSVMappingParameters_RecordRowDelimiter;
            context.JSONMappingParameters_RecordRowPath = this.JSONMappingParameters_RecordRowPath;
            context.RecordFormat_RecordFormatType = this.RecordFormat_RecordFormatType;
            #if MODULAR
            if (this.RecordFormat_RecordFormatType == null && ParameterWasBound(nameof(this.RecordFormat_RecordFormatType)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordFormat_RecordFormatType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KinesisFirehoseInput_ResourceARN = this.KinesisFirehoseInput_ResourceARN;
            context.KinesisFirehoseInput_RoleARN = this.KinesisFirehoseInput_RoleARN;
            context.KinesisStreamsInput_ResourceARN = this.KinesisStreamsInput_ResourceARN;
            context.KinesisStreamsInput_RoleARN = this.KinesisStreamsInput_RoleARN;
            context.Input_NamePrefix = this.Input_NamePrefix;
            #if MODULAR
            if (this.Input_NamePrefix == null && ParameterWasBound(nameof(this.Input_NamePrefix)))
            {
                WriteWarning("You are passing $null as a value for parameter Input_NamePrefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisAnalytics.Model.AddApplicationInputRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
            }
            
             // populate Input
            var requestInputIsNull = true;
            request.Input = new Amazon.KinesisAnalytics.Model.Input();
            System.String requestInput_input_NamePrefix = null;
            if (cmdletContext.Input_NamePrefix != null)
            {
                requestInput_input_NamePrefix = cmdletContext.Input_NamePrefix;
            }
            if (requestInput_input_NamePrefix != null)
            {
                request.Input.NamePrefix = requestInput_input_NamePrefix;
                requestInputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.InputParallelism requestInput_input_InputParallelism = null;
            
             // populate InputParallelism
            var requestInput_input_InputParallelismIsNull = true;
            requestInput_input_InputParallelism = new Amazon.KinesisAnalytics.Model.InputParallelism();
            System.Int32? requestInput_input_InputParallelism_inputParallelism_Count = null;
            if (cmdletContext.InputParallelism_Count != null)
            {
                requestInput_input_InputParallelism_inputParallelism_Count = cmdletContext.InputParallelism_Count.Value;
            }
            if (requestInput_input_InputParallelism_inputParallelism_Count != null)
            {
                requestInput_input_InputParallelism.Count = requestInput_input_InputParallelism_inputParallelism_Count.Value;
                requestInput_input_InputParallelismIsNull = false;
            }
             // determine if requestInput_input_InputParallelism should be set to null
            if (requestInput_input_InputParallelismIsNull)
            {
                requestInput_input_InputParallelism = null;
            }
            if (requestInput_input_InputParallelism != null)
            {
                request.Input.InputParallelism = requestInput_input_InputParallelism;
                requestInputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.InputProcessingConfiguration requestInput_input_InputProcessingConfiguration = null;
            
             // populate InputProcessingConfiguration
            var requestInput_input_InputProcessingConfigurationIsNull = true;
            requestInput_input_InputProcessingConfiguration = new Amazon.KinesisAnalytics.Model.InputProcessingConfiguration();
            Amazon.KinesisAnalytics.Model.InputLambdaProcessor requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor = null;
            
             // populate InputLambdaProcessor
            var requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessorIsNull = true;
            requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor = new Amazon.KinesisAnalytics.Model.InputLambdaProcessor();
            System.String requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN = null;
            if (cmdletContext.InputLambdaProcessor_ResourceARN != null)
            {
                requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN = cmdletContext.InputLambdaProcessor_ResourceARN;
            }
            if (requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN != null)
            {
                requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor.ResourceARN = requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_ResourceARN;
                requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessorIsNull = false;
            }
            System.String requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_RoleARN = null;
            if (cmdletContext.InputLambdaProcessor_RoleARN != null)
            {
                requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_RoleARN = cmdletContext.InputLambdaProcessor_RoleARN;
            }
            if (requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_RoleARN != null)
            {
                requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor.RoleARN = requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor_inputLambdaProcessor_RoleARN;
                requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessorIsNull = false;
            }
             // determine if requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor should be set to null
            if (requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessorIsNull)
            {
                requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor = null;
            }
            if (requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor != null)
            {
                requestInput_input_InputProcessingConfiguration.InputLambdaProcessor = requestInput_input_InputProcessingConfiguration_input_InputProcessingConfiguration_InputLambdaProcessor;
                requestInput_input_InputProcessingConfigurationIsNull = false;
            }
             // determine if requestInput_input_InputProcessingConfiguration should be set to null
            if (requestInput_input_InputProcessingConfigurationIsNull)
            {
                requestInput_input_InputProcessingConfiguration = null;
            }
            if (requestInput_input_InputProcessingConfiguration != null)
            {
                request.Input.InputProcessingConfiguration = requestInput_input_InputProcessingConfiguration;
                requestInputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.KinesisFirehoseInput requestInput_input_KinesisFirehoseInput = null;
            
             // populate KinesisFirehoseInput
            var requestInput_input_KinesisFirehoseInputIsNull = true;
            requestInput_input_KinesisFirehoseInput = new Amazon.KinesisAnalytics.Model.KinesisFirehoseInput();
            System.String requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_ResourceARN = null;
            if (cmdletContext.KinesisFirehoseInput_ResourceARN != null)
            {
                requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_ResourceARN = cmdletContext.KinesisFirehoseInput_ResourceARN;
            }
            if (requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_ResourceARN != null)
            {
                requestInput_input_KinesisFirehoseInput.ResourceARN = requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_ResourceARN;
                requestInput_input_KinesisFirehoseInputIsNull = false;
            }
            System.String requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_RoleARN = null;
            if (cmdletContext.KinesisFirehoseInput_RoleARN != null)
            {
                requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_RoleARN = cmdletContext.KinesisFirehoseInput_RoleARN;
            }
            if (requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_RoleARN != null)
            {
                requestInput_input_KinesisFirehoseInput.RoleARN = requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_RoleARN;
                requestInput_input_KinesisFirehoseInputIsNull = false;
            }
             // determine if requestInput_input_KinesisFirehoseInput should be set to null
            if (requestInput_input_KinesisFirehoseInputIsNull)
            {
                requestInput_input_KinesisFirehoseInput = null;
            }
            if (requestInput_input_KinesisFirehoseInput != null)
            {
                request.Input.KinesisFirehoseInput = requestInput_input_KinesisFirehoseInput;
                requestInputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.KinesisStreamsInput requestInput_input_KinesisStreamsInput = null;
            
             // populate KinesisStreamsInput
            var requestInput_input_KinesisStreamsInputIsNull = true;
            requestInput_input_KinesisStreamsInput = new Amazon.KinesisAnalytics.Model.KinesisStreamsInput();
            System.String requestInput_input_KinesisStreamsInput_kinesisStreamsInput_ResourceARN = null;
            if (cmdletContext.KinesisStreamsInput_ResourceARN != null)
            {
                requestInput_input_KinesisStreamsInput_kinesisStreamsInput_ResourceARN = cmdletContext.KinesisStreamsInput_ResourceARN;
            }
            if (requestInput_input_KinesisStreamsInput_kinesisStreamsInput_ResourceARN != null)
            {
                requestInput_input_KinesisStreamsInput.ResourceARN = requestInput_input_KinesisStreamsInput_kinesisStreamsInput_ResourceARN;
                requestInput_input_KinesisStreamsInputIsNull = false;
            }
            System.String requestInput_input_KinesisStreamsInput_kinesisStreamsInput_RoleARN = null;
            if (cmdletContext.KinesisStreamsInput_RoleARN != null)
            {
                requestInput_input_KinesisStreamsInput_kinesisStreamsInput_RoleARN = cmdletContext.KinesisStreamsInput_RoleARN;
            }
            if (requestInput_input_KinesisStreamsInput_kinesisStreamsInput_RoleARN != null)
            {
                requestInput_input_KinesisStreamsInput.RoleARN = requestInput_input_KinesisStreamsInput_kinesisStreamsInput_RoleARN;
                requestInput_input_KinesisStreamsInputIsNull = false;
            }
             // determine if requestInput_input_KinesisStreamsInput should be set to null
            if (requestInput_input_KinesisStreamsInputIsNull)
            {
                requestInput_input_KinesisStreamsInput = null;
            }
            if (requestInput_input_KinesisStreamsInput != null)
            {
                request.Input.KinesisStreamsInput = requestInput_input_KinesisStreamsInput;
                requestInputIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.SourceSchema requestInput_input_InputSchema = null;
            
             // populate InputSchema
            var requestInput_input_InputSchemaIsNull = true;
            requestInput_input_InputSchema = new Amazon.KinesisAnalytics.Model.SourceSchema();
            List<Amazon.KinesisAnalytics.Model.RecordColumn> requestInput_input_InputSchema_inputSchema_RecordColumn = null;
            if (cmdletContext.InputSchema_RecordColumn != null)
            {
                requestInput_input_InputSchema_inputSchema_RecordColumn = cmdletContext.InputSchema_RecordColumn;
            }
            if (requestInput_input_InputSchema_inputSchema_RecordColumn != null)
            {
                requestInput_input_InputSchema.RecordColumns = requestInput_input_InputSchema_inputSchema_RecordColumn;
                requestInput_input_InputSchemaIsNull = false;
            }
            System.String requestInput_input_InputSchema_inputSchema_RecordEncoding = null;
            if (cmdletContext.InputSchema_RecordEncoding != null)
            {
                requestInput_input_InputSchema_inputSchema_RecordEncoding = cmdletContext.InputSchema_RecordEncoding;
            }
            if (requestInput_input_InputSchema_inputSchema_RecordEncoding != null)
            {
                requestInput_input_InputSchema.RecordEncoding = requestInput_input_InputSchema_inputSchema_RecordEncoding;
                requestInput_input_InputSchemaIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.RecordFormat requestInput_input_InputSchema_input_InputSchema_RecordFormat = null;
            
             // populate RecordFormat
            var requestInput_input_InputSchema_input_InputSchema_RecordFormatIsNull = true;
            requestInput_input_InputSchema_input_InputSchema_RecordFormat = new Amazon.KinesisAnalytics.Model.RecordFormat();
            Amazon.KinesisAnalytics.RecordFormatType requestInput_input_InputSchema_input_InputSchema_RecordFormat_recordFormat_RecordFormatType = null;
            if (cmdletContext.RecordFormat_RecordFormatType != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_recordFormat_RecordFormatType = cmdletContext.RecordFormat_RecordFormatType;
            }
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_recordFormat_RecordFormatType != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat.RecordFormatType = requestInput_input_InputSchema_input_InputSchema_RecordFormat_recordFormat_RecordFormatType;
                requestInput_input_InputSchema_input_InputSchema_RecordFormatIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.MappingParameters requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters = null;
            
             // populate MappingParameters
            var requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParametersIsNull = true;
            requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters = new Amazon.KinesisAnalytics.Model.MappingParameters();
            Amazon.KinesisAnalytics.Model.JSONMappingParameters requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters = null;
            
             // populate JSONMappingParameters
            var requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParametersIsNull = true;
            requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters = new Amazon.KinesisAnalytics.Model.JSONMappingParameters();
            System.String requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_jSONMappingParameters_RecordRowPath = null;
            if (cmdletContext.JSONMappingParameters_RecordRowPath != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_jSONMappingParameters_RecordRowPath = cmdletContext.JSONMappingParameters_RecordRowPath;
            }
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_jSONMappingParameters_RecordRowPath != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters.RecordRowPath = requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_jSONMappingParameters_RecordRowPath;
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParametersIsNull = false;
            }
             // determine if requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters should be set to null
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParametersIsNull)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters = null;
            }
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters.JSONMappingParameters = requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters;
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParametersIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.CSVMappingParameters requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters = null;
            
             // populate CSVMappingParameters
            var requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParametersIsNull = true;
            requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters = new Amazon.KinesisAnalytics.Model.CSVMappingParameters();
            System.String requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter = null;
            if (cmdletContext.CSVMappingParameters_RecordColumnDelimiter != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter = cmdletContext.CSVMappingParameters_RecordColumnDelimiter;
            }
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters.RecordColumnDelimiter = requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter;
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParametersIsNull = false;
            }
            System.String requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordRowDelimiter = null;
            if (cmdletContext.CSVMappingParameters_RecordRowDelimiter != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordRowDelimiter = cmdletContext.CSVMappingParameters_RecordRowDelimiter;
            }
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordRowDelimiter != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters.RecordRowDelimiter = requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordRowDelimiter;
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParametersIsNull = false;
            }
             // determine if requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters should be set to null
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParametersIsNull)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters = null;
            }
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters.CSVMappingParameters = requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters;
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParametersIsNull = false;
            }
             // determine if requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters should be set to null
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParametersIsNull)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters = null;
            }
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat.MappingParameters = requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters;
                requestInput_input_InputSchema_input_InputSchema_RecordFormatIsNull = false;
            }
             // determine if requestInput_input_InputSchema_input_InputSchema_RecordFormat should be set to null
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormatIsNull)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat = null;
            }
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat != null)
            {
                requestInput_input_InputSchema.RecordFormat = requestInput_input_InputSchema_input_InputSchema_RecordFormat;
                requestInput_input_InputSchemaIsNull = false;
            }
             // determine if requestInput_input_InputSchema should be set to null
            if (requestInput_input_InputSchemaIsNull)
            {
                requestInput_input_InputSchema = null;
            }
            if (requestInput_input_InputSchema != null)
            {
                request.Input.InputSchema = requestInput_input_InputSchema;
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
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
        
        private Amazon.KinesisAnalytics.Model.AddApplicationInputResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.AddApplicationInputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "AddApplicationInput");
            try
            {
                #if DESKTOP
                return client.AddApplicationInput(request);
                #elif CORECLR
                return client.AddApplicationInputAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public System.Int32? InputParallelism_Count { get; set; }
            public System.String InputLambdaProcessor_ResourceARN { get; set; }
            public System.String InputLambdaProcessor_RoleARN { get; set; }
            public List<Amazon.KinesisAnalytics.Model.RecordColumn> InputSchema_RecordColumn { get; set; }
            public System.String InputSchema_RecordEncoding { get; set; }
            public System.String CSVMappingParameters_RecordColumnDelimiter { get; set; }
            public System.String CSVMappingParameters_RecordRowDelimiter { get; set; }
            public System.String JSONMappingParameters_RecordRowPath { get; set; }
            public Amazon.KinesisAnalytics.RecordFormatType RecordFormat_RecordFormatType { get; set; }
            public System.String KinesisFirehoseInput_ResourceARN { get; set; }
            public System.String KinesisFirehoseInput_RoleARN { get; set; }
            public System.String KinesisStreamsInput_ResourceARN { get; set; }
            public System.String KinesisStreamsInput_RoleARN { get; set; }
            public System.String Input_NamePrefix { get; set; }
            public System.Func<Amazon.KinesisAnalytics.Model.AddApplicationInputResponse, AddKINAApplicationInputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
