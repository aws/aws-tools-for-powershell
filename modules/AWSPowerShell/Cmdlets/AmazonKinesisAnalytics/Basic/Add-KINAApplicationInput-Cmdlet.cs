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
    /// Adds a streaming source to your Amazon Kinesis application. For conceptual information,
    /// see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works-input.html">Configuring
    /// Application Input</a>. 
    /// 
    ///  
    /// <para>
    /// You can add a streaming source either when you create an application or you can use
    /// this operation to add a streaming source after you create an application. For more
    /// information, see <a>CreateApplication</a>.
    /// </para><para>
    /// Any configuration update, including adding a streaming source using this operation,
    /// results in a new version of the application. You can use the <a>DescribeApplication</a>
    /// operation to find the current application version. 
    /// </para><para>
    /// This operation requires permissions to perform the <code>kinesisanalytics:AddApplicationInput</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "KINAApplicationInput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the AddApplicationInput operation against Amazon Kinesis Analytics.", Operation = new[] {"AddApplicationInput"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ApplicationName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.KinesisAnalytics.Model.AddApplicationInputResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddKINAApplicationInputCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>Name of your existing Amazon Kinesis Analytics application to which you want to add
        /// the streaming source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter InputParallelism_Count
        /// <summary>
        /// <para>
        /// <para>Number of in-application streams to create. For more information, see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/limits.html">Limits</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Input_InputParallelism_Count")]
        public System.Int32 InputParallelism_Count { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>Current version of your Amazon Kinesis Analytics application. You can use the <a>DescribeApplication</a>
        /// operation to find the current application version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64 CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter Input_NamePrefix
        /// <summary>
        /// <para>
        /// <para>Name prefix to use when creating in-application stream. Suppose you specify a prefix
        /// "MyInApplicationStream". Amazon Kinesis Analytics will then create one or more (as
        /// per the <code>InputParallelism</code> count you specified) in-application streams
        /// with names "MyInApplicationStream_001", "MyInApplicationStream_002" and so on. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Input_NamePrefix { get; set; }
        #endregion
        
        #region Parameter CSVMappingParameters_RecordColumnDelimiter
        /// <summary>
        /// <para>
        /// <para>Column delimiter. For example, in a CSV format, a comma (",") is the typical column
        /// delimiter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter")]
        public System.String CSVMappingParameters_RecordColumnDelimiter { get; set; }
        #endregion
        
        #region Parameter InputSchema_RecordColumn
        /// <summary>
        /// <para>
        /// <para>A list of <code>RecordColumn</code> objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Input_InputSchema_RecordColumns")]
        public Amazon.KinesisAnalytics.Model.RecordColumn[] InputSchema_RecordColumn { get; set; }
        #endregion
        
        #region Parameter InputSchema_RecordEncoding
        /// <summary>
        /// <para>
        /// <para>Specifies the encoding of the records in the streaming source. For example, UTF-8.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Input_InputSchema_RecordEncoding")]
        public System.String InputSchema_RecordEncoding { get; set; }
        #endregion
        
        #region Parameter RecordFormat_RecordFormatType
        /// <summary>
        /// <para>
        /// <para>The type of record format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter")]
        public System.String CSVMappingParameters_RecordRowDelimiter { get; set; }
        #endregion
        
        #region Parameter JSONMappingParameters_RecordRowPath
        /// <summary>
        /// <para>
        /// <para>Path to the top-level parent that contains the records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath")]
        public System.String JSONMappingParameters_RecordRowPath { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseInput_ResourceARN
        /// <summary>
        /// <para>
        /// <para>ARN of the input Firehose delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Input_KinesisFirehoseInput_ResourceARN")]
        public System.String KinesisFirehoseInput_ResourceARN { get; set; }
        #endregion
        
        #region Parameter KinesisStreamsInput_ResourceARN
        /// <summary>
        /// <para>
        /// <para>ARN of the input Amazon Kinesis stream to read.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Input_KinesisStreamsInput_ResourceARN")]
        public System.String KinesisStreamsInput_ResourceARN { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseInput_RoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that Amazon Kinesis Analytics can assume to access the stream
        /// on your behalf. You need to make sure the role has necessary permissions to access
        /// the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("Input_KinesisStreamsInput_RoleARN")]
        public System.String KinesisStreamsInput_RoleARN { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KINAApplicationInput (AddApplicationInput)"))
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
            if (ParameterWasBound("CurrentApplicationVersionId"))
                context.CurrentApplicationVersionId = this.CurrentApplicationVersionId;
            if (ParameterWasBound("InputParallelism_Count"))
                context.Input_InputParallelism_Count = this.InputParallelism_Count;
            if (this.InputSchema_RecordColumn != null)
            {
                context.Input_InputSchema_RecordColumns = new List<Amazon.KinesisAnalytics.Model.RecordColumn>(this.InputSchema_RecordColumn);
            }
            context.Input_InputSchema_RecordEncoding = this.InputSchema_RecordEncoding;
            context.Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter = this.CSVMappingParameters_RecordColumnDelimiter;
            context.Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter = this.CSVMappingParameters_RecordRowDelimiter;
            context.Input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath = this.JSONMappingParameters_RecordRowPath;
            context.Input_InputSchema_RecordFormat_RecordFormatType = this.RecordFormat_RecordFormatType;
            context.Input_KinesisFirehoseInput_ResourceARN = this.KinesisFirehoseInput_ResourceARN;
            context.Input_KinesisFirehoseInput_RoleARN = this.KinesisFirehoseInput_RoleARN;
            context.Input_KinesisStreamsInput_ResourceARN = this.KinesisStreamsInput_ResourceARN;
            context.Input_KinesisStreamsInput_RoleARN = this.KinesisStreamsInput_RoleARN;
            context.Input_NamePrefix = this.Input_NamePrefix;
            
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
            bool requestInputIsNull = true;
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
            bool requestInput_input_InputParallelismIsNull = true;
            requestInput_input_InputParallelism = new Amazon.KinesisAnalytics.Model.InputParallelism();
            System.Int32? requestInput_input_InputParallelism_inputParallelism_Count = null;
            if (cmdletContext.Input_InputParallelism_Count != null)
            {
                requestInput_input_InputParallelism_inputParallelism_Count = cmdletContext.Input_InputParallelism_Count.Value;
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
            Amazon.KinesisAnalytics.Model.KinesisFirehoseInput requestInput_input_KinesisFirehoseInput = null;
            
             // populate KinesisFirehoseInput
            bool requestInput_input_KinesisFirehoseInputIsNull = true;
            requestInput_input_KinesisFirehoseInput = new Amazon.KinesisAnalytics.Model.KinesisFirehoseInput();
            System.String requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_ResourceARN = null;
            if (cmdletContext.Input_KinesisFirehoseInput_ResourceARN != null)
            {
                requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_ResourceARN = cmdletContext.Input_KinesisFirehoseInput_ResourceARN;
            }
            if (requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_ResourceARN != null)
            {
                requestInput_input_KinesisFirehoseInput.ResourceARN = requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_ResourceARN;
                requestInput_input_KinesisFirehoseInputIsNull = false;
            }
            System.String requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_RoleARN = null;
            if (cmdletContext.Input_KinesisFirehoseInput_RoleARN != null)
            {
                requestInput_input_KinesisFirehoseInput_kinesisFirehoseInput_RoleARN = cmdletContext.Input_KinesisFirehoseInput_RoleARN;
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
            bool requestInput_input_KinesisStreamsInputIsNull = true;
            requestInput_input_KinesisStreamsInput = new Amazon.KinesisAnalytics.Model.KinesisStreamsInput();
            System.String requestInput_input_KinesisStreamsInput_kinesisStreamsInput_ResourceARN = null;
            if (cmdletContext.Input_KinesisStreamsInput_ResourceARN != null)
            {
                requestInput_input_KinesisStreamsInput_kinesisStreamsInput_ResourceARN = cmdletContext.Input_KinesisStreamsInput_ResourceARN;
            }
            if (requestInput_input_KinesisStreamsInput_kinesisStreamsInput_ResourceARN != null)
            {
                requestInput_input_KinesisStreamsInput.ResourceARN = requestInput_input_KinesisStreamsInput_kinesisStreamsInput_ResourceARN;
                requestInput_input_KinesisStreamsInputIsNull = false;
            }
            System.String requestInput_input_KinesisStreamsInput_kinesisStreamsInput_RoleARN = null;
            if (cmdletContext.Input_KinesisStreamsInput_RoleARN != null)
            {
                requestInput_input_KinesisStreamsInput_kinesisStreamsInput_RoleARN = cmdletContext.Input_KinesisStreamsInput_RoleARN;
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
            bool requestInput_input_InputSchemaIsNull = true;
            requestInput_input_InputSchema = new Amazon.KinesisAnalytics.Model.SourceSchema();
            List<Amazon.KinesisAnalytics.Model.RecordColumn> requestInput_input_InputSchema_inputSchema_RecordColumn = null;
            if (cmdletContext.Input_InputSchema_RecordColumns != null)
            {
                requestInput_input_InputSchema_inputSchema_RecordColumn = cmdletContext.Input_InputSchema_RecordColumns;
            }
            if (requestInput_input_InputSchema_inputSchema_RecordColumn != null)
            {
                requestInput_input_InputSchema.RecordColumns = requestInput_input_InputSchema_inputSchema_RecordColumn;
                requestInput_input_InputSchemaIsNull = false;
            }
            System.String requestInput_input_InputSchema_inputSchema_RecordEncoding = null;
            if (cmdletContext.Input_InputSchema_RecordEncoding != null)
            {
                requestInput_input_InputSchema_inputSchema_RecordEncoding = cmdletContext.Input_InputSchema_RecordEncoding;
            }
            if (requestInput_input_InputSchema_inputSchema_RecordEncoding != null)
            {
                requestInput_input_InputSchema.RecordEncoding = requestInput_input_InputSchema_inputSchema_RecordEncoding;
                requestInput_input_InputSchemaIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.RecordFormat requestInput_input_InputSchema_input_InputSchema_RecordFormat = null;
            
             // populate RecordFormat
            bool requestInput_input_InputSchema_input_InputSchema_RecordFormatIsNull = true;
            requestInput_input_InputSchema_input_InputSchema_RecordFormat = new Amazon.KinesisAnalytics.Model.RecordFormat();
            Amazon.KinesisAnalytics.RecordFormatType requestInput_input_InputSchema_input_InputSchema_RecordFormat_recordFormat_RecordFormatType = null;
            if (cmdletContext.Input_InputSchema_RecordFormat_RecordFormatType != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_recordFormat_RecordFormatType = cmdletContext.Input_InputSchema_RecordFormat_RecordFormatType;
            }
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_recordFormat_RecordFormatType != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat.RecordFormatType = requestInput_input_InputSchema_input_InputSchema_RecordFormat_recordFormat_RecordFormatType;
                requestInput_input_InputSchema_input_InputSchema_RecordFormatIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.MappingParameters requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters = null;
            
             // populate MappingParameters
            bool requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParametersIsNull = true;
            requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters = new Amazon.KinesisAnalytics.Model.MappingParameters();
            Amazon.KinesisAnalytics.Model.JSONMappingParameters requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters = null;
            
             // populate JSONMappingParameters
            bool requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParametersIsNull = true;
            requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters = new Amazon.KinesisAnalytics.Model.JSONMappingParameters();
            System.String requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_jSONMappingParameters_RecordRowPath = null;
            if (cmdletContext.Input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_jSONMappingParameters_RecordRowPath = cmdletContext.Input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath;
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
            bool requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParametersIsNull = true;
            requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters = new Amazon.KinesisAnalytics.Model.CSVMappingParameters();
            System.String requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter = null;
            if (cmdletContext.Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter = cmdletContext.Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter;
            }
            if (requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters.RecordColumnDelimiter = requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter;
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParametersIsNull = false;
            }
            System.String requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordRowDelimiter = null;
            if (cmdletContext.Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter != null)
            {
                requestInput_input_InputSchema_input_InputSchema_RecordFormat_input_InputSchema_RecordFormat_MappingParameters_input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordRowDelimiter = cmdletContext.Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter;
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
        
        private Amazon.KinesisAnalytics.Model.AddApplicationInputResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.AddApplicationInputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics", "AddApplicationInput");
            #if DESKTOP
            return client.AddApplicationInput(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AddApplicationInputAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ApplicationName { get; set; }
            public System.Int64? CurrentApplicationVersionId { get; set; }
            public System.Int32? Input_InputParallelism_Count { get; set; }
            public List<Amazon.KinesisAnalytics.Model.RecordColumn> Input_InputSchema_RecordColumns { get; set; }
            public System.String Input_InputSchema_RecordEncoding { get; set; }
            public System.String Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter { get; set; }
            public System.String Input_InputSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter { get; set; }
            public System.String Input_InputSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath { get; set; }
            public Amazon.KinesisAnalytics.RecordFormatType Input_InputSchema_RecordFormat_RecordFormatType { get; set; }
            public System.String Input_KinesisFirehoseInput_ResourceARN { get; set; }
            public System.String Input_KinesisFirehoseInput_RoleARN { get; set; }
            public System.String Input_KinesisStreamsInput_ResourceARN { get; set; }
            public System.String Input_KinesisStreamsInput_RoleARN { get; set; }
            public System.String Input_NamePrefix { get; set; }
        }
        
    }
}
