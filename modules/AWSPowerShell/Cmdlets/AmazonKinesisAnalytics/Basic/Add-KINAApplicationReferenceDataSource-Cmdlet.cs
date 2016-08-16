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
    /// Adds a reference data source to an existing application.
    /// 
    ///  
    /// <para>
    /// Amazon Kinesis Analytics reads reference data (that is, an Amazon S3 object) and creates
    /// an in-application table within your application. In the request, you provide the source
    /// (S3 bucket name and object key name), name of the in-application table to create,
    /// and the necessary mapping information that describes how data in Amazon S3 object
    /// maps to columns in the resulting in-application table.
    /// </para><para>
    ///  For conceptual information, see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/how-it-works-input.html">Configuring
    /// Application Input</a>. For the limits on data sources you can add to your application,
    /// see <a href="http://docs.aws.amazon.com/kinesisanalytics/latest/dev/limits.html">Limits</a>.
    /// 
    /// </para><para>
    ///  This operation requires permissions to perform the <code>kinesisanalytics:AddApplicationOutput</code>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("Add", "KINAApplicationReferenceDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the AddApplicationReferenceDataSource operation against Amazon Kinesis Analytics.", Operation = new[] {"AddApplicationReferenceDataSource"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ApplicationName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.KinesisAnalytics.Model.AddApplicationReferenceDataSourceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddKINAApplicationReferenceDataSourceCmdlet : AmazonKinesisAnalyticsClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>Name of an existing application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter S3ReferenceDataSource_BucketARN
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReferenceDataSource_S3ReferenceDataSource_BucketARN")]
        public System.String S3ReferenceDataSource_BucketARN { get; set; }
        #endregion
        
        #region Parameter CurrentApplicationVersionId
        /// <summary>
        /// <para>
        /// <para>Version of the application for which you are adding the reference data source. You
        /// can use the <a>DescribeApplication</a> operation to get the current application version.
        /// If the version specified is not the current version, the <code>ConcurrentModificationException</code>
        /// is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64 CurrentApplicationVersionId { get; set; }
        #endregion
        
        #region Parameter S3ReferenceDataSource_FileKey
        /// <summary>
        /// <para>
        /// <para>Object key name containing reference data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReferenceDataSource_S3ReferenceDataSource_FileKey")]
        public System.String S3ReferenceDataSource_FileKey { get; set; }
        #endregion
        
        #region Parameter CSVMappingParameters_RecordColumnDelimiter
        /// <summary>
        /// <para>
        /// <para>Column delimiter. For example, in a CSV format, a comma (",") is the typical column
        /// delimiter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter")]
        public System.String CSVMappingParameters_RecordColumnDelimiter { get; set; }
        #endregion
        
        #region Parameter ReferenceSchema_RecordColumn
        /// <summary>
        /// <para>
        /// <para>A list of <code>RecordColumn</code> objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReferenceDataSource_ReferenceSchema_RecordColumns")]
        public Amazon.KinesisAnalytics.Model.RecordColumn[] ReferenceSchema_RecordColumn { get; set; }
        #endregion
        
        #region Parameter ReferenceSchema_RecordEncoding
        /// <summary>
        /// <para>
        /// <para>Specifies the encoding of the records in the streaming source. For example, UTF-8.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReferenceDataSource_ReferenceSchema_RecordEncoding")]
        public System.String ReferenceSchema_RecordEncoding { get; set; }
        #endregion
        
        #region Parameter RecordFormat_RecordFormatType
        /// <summary>
        /// <para>
        /// <para>The type of record format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReferenceDataSource_ReferenceSchema_RecordFormat_RecordFormatType")]
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
        [Alias("ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter")]
        public System.String CSVMappingParameters_RecordRowDelimiter { get; set; }
        #endregion
        
        #region Parameter JSONMappingParameters_RecordRowPath
        /// <summary>
        /// <para>
        /// <para>Path to the top-level parent that contains the records.</para><para>For example, consider the following JSON record:</para><para>In the <code>RecordRowPath</code>, <code>"$"</code> refers to the root and path <code>"$.vehicle.Model"</code>
        /// refers to the specific <code>"Model"</code> key in the JSON.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath")]
        public System.String JSONMappingParameters_RecordRowPath { get; set; }
        #endregion
        
        #region Parameter S3ReferenceDataSource_ReferenceRoleARN
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that the service can assume to read data on your behalf. This
        /// role must have permission for the <code>s3:GetObject</code> action on the object and
        /// trust policy that allows Amazon Kinesis Analytics service principal to assume this
        /// role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReferenceDataSource_S3ReferenceDataSource_ReferenceRoleARN")]
        public System.String S3ReferenceDataSource_ReferenceRoleARN { get; set; }
        #endregion
        
        #region Parameter ReferenceDataSource_TableName
        /// <summary>
        /// <para>
        /// <para>Name of the in-application table to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReferenceDataSource_TableName { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-KINAApplicationReferenceDataSource (AddApplicationReferenceDataSource)"))
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
            if (this.ReferenceSchema_RecordColumn != null)
            {
                context.ReferenceDataSource_ReferenceSchema_RecordColumns = new List<Amazon.KinesisAnalytics.Model.RecordColumn>(this.ReferenceSchema_RecordColumn);
            }
            context.ReferenceDataSource_ReferenceSchema_RecordEncoding = this.ReferenceSchema_RecordEncoding;
            context.ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter = this.CSVMappingParameters_RecordColumnDelimiter;
            context.ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter = this.CSVMappingParameters_RecordRowDelimiter;
            context.ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath = this.JSONMappingParameters_RecordRowPath;
            context.ReferenceDataSource_ReferenceSchema_RecordFormat_RecordFormatType = this.RecordFormat_RecordFormatType;
            context.ReferenceDataSource_S3ReferenceDataSource_BucketARN = this.S3ReferenceDataSource_BucketARN;
            context.ReferenceDataSource_S3ReferenceDataSource_FileKey = this.S3ReferenceDataSource_FileKey;
            context.ReferenceDataSource_S3ReferenceDataSource_ReferenceRoleARN = this.S3ReferenceDataSource_ReferenceRoleARN;
            context.ReferenceDataSource_TableName = this.ReferenceDataSource_TableName;
            
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
            var request = new Amazon.KinesisAnalytics.Model.AddApplicationReferenceDataSourceRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CurrentApplicationVersionId != null)
            {
                request.CurrentApplicationVersionId = cmdletContext.CurrentApplicationVersionId.Value;
            }
            
             // populate ReferenceDataSource
            bool requestReferenceDataSourceIsNull = true;
            request.ReferenceDataSource = new Amazon.KinesisAnalytics.Model.ReferenceDataSource();
            System.String requestReferenceDataSource_referenceDataSource_TableName = null;
            if (cmdletContext.ReferenceDataSource_TableName != null)
            {
                requestReferenceDataSource_referenceDataSource_TableName = cmdletContext.ReferenceDataSource_TableName;
            }
            if (requestReferenceDataSource_referenceDataSource_TableName != null)
            {
                request.ReferenceDataSource.TableName = requestReferenceDataSource_referenceDataSource_TableName;
                requestReferenceDataSourceIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.SourceSchema requestReferenceDataSource_referenceDataSource_ReferenceSchema = null;
            
             // populate ReferenceSchema
            bool requestReferenceDataSource_referenceDataSource_ReferenceSchemaIsNull = true;
            requestReferenceDataSource_referenceDataSource_ReferenceSchema = new Amazon.KinesisAnalytics.Model.SourceSchema();
            List<Amazon.KinesisAnalytics.Model.RecordColumn> requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceSchema_RecordColumn = null;
            if (cmdletContext.ReferenceDataSource_ReferenceSchema_RecordColumns != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceSchema_RecordColumn = cmdletContext.ReferenceDataSource_ReferenceSchema_RecordColumns;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceSchema_RecordColumn != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema.RecordColumns = requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceSchema_RecordColumn;
                requestReferenceDataSource_referenceDataSource_ReferenceSchemaIsNull = false;
            }
            System.String requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceSchema_RecordEncoding = null;
            if (cmdletContext.ReferenceDataSource_ReferenceSchema_RecordEncoding != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceSchema_RecordEncoding = cmdletContext.ReferenceDataSource_ReferenceSchema_RecordEncoding;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceSchema_RecordEncoding != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema.RecordEncoding = requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceSchema_RecordEncoding;
                requestReferenceDataSource_referenceDataSource_ReferenceSchemaIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.RecordFormat requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat = null;
            
             // populate RecordFormat
            bool requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormatIsNull = true;
            requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat = new Amazon.KinesisAnalytics.Model.RecordFormat();
            Amazon.KinesisAnalytics.RecordFormatType requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_recordFormat_RecordFormatType = null;
            if (cmdletContext.ReferenceDataSource_ReferenceSchema_RecordFormat_RecordFormatType != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_recordFormat_RecordFormatType = cmdletContext.ReferenceDataSource_ReferenceSchema_RecordFormat_RecordFormatType;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_recordFormat_RecordFormatType != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat.RecordFormatType = requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_recordFormat_RecordFormatType;
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormatIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.MappingParameters requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters = null;
            
             // populate MappingParameters
            bool requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParametersIsNull = true;
            requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters = new Amazon.KinesisAnalytics.Model.MappingParameters();
            Amazon.KinesisAnalytics.Model.JSONMappingParameters requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters = null;
            
             // populate JSONMappingParameters
            bool requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParametersIsNull = true;
            requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters = new Amazon.KinesisAnalytics.Model.JSONMappingParameters();
            System.String requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters_jSONMappingParameters_RecordRowPath = null;
            if (cmdletContext.ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters_jSONMappingParameters_RecordRowPath = cmdletContext.ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters_jSONMappingParameters_RecordRowPath != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters.RecordRowPath = requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters_jSONMappingParameters_RecordRowPath;
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParametersIsNull = false;
            }
             // determine if requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters should be set to null
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParametersIsNull)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters = null;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters.JSONMappingParameters = requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters;
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParametersIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.CSVMappingParameters requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters = null;
            
             // populate CSVMappingParameters
            bool requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParametersIsNull = true;
            requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters = new Amazon.KinesisAnalytics.Model.CSVMappingParameters();
            System.String requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter = null;
            if (cmdletContext.ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter = cmdletContext.ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters.RecordColumnDelimiter = requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordColumnDelimiter;
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParametersIsNull = false;
            }
            System.String requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordRowDelimiter = null;
            if (cmdletContext.ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordRowDelimiter = cmdletContext.ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordRowDelimiter != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters.RecordRowDelimiter = requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_cSVMappingParameters_RecordRowDelimiter;
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParametersIsNull = false;
            }
             // determine if requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters should be set to null
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParametersIsNull)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters = null;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters.CSVMappingParameters = requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters;
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParametersIsNull = false;
            }
             // determine if requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters should be set to null
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParametersIsNull)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters = null;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat.MappingParameters = requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat_referenceDataSource_ReferenceSchema_RecordFormat_MappingParameters;
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormatIsNull = false;
            }
             // determine if requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat should be set to null
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormatIsNull)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat = null;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat != null)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema.RecordFormat = requestReferenceDataSource_referenceDataSource_ReferenceSchema_referenceDataSource_ReferenceSchema_RecordFormat;
                requestReferenceDataSource_referenceDataSource_ReferenceSchemaIsNull = false;
            }
             // determine if requestReferenceDataSource_referenceDataSource_ReferenceSchema should be set to null
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchemaIsNull)
            {
                requestReferenceDataSource_referenceDataSource_ReferenceSchema = null;
            }
            if (requestReferenceDataSource_referenceDataSource_ReferenceSchema != null)
            {
                request.ReferenceDataSource.ReferenceSchema = requestReferenceDataSource_referenceDataSource_ReferenceSchema;
                requestReferenceDataSourceIsNull = false;
            }
            Amazon.KinesisAnalytics.Model.S3ReferenceDataSource requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource = null;
            
             // populate S3ReferenceDataSource
            bool requestReferenceDataSource_referenceDataSource_S3ReferenceDataSourceIsNull = true;
            requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource = new Amazon.KinesisAnalytics.Model.S3ReferenceDataSource();
            System.String requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_BucketARN = null;
            if (cmdletContext.ReferenceDataSource_S3ReferenceDataSource_BucketARN != null)
            {
                requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_BucketARN = cmdletContext.ReferenceDataSource_S3ReferenceDataSource_BucketARN;
            }
            if (requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_BucketARN != null)
            {
                requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource.BucketARN = requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_BucketARN;
                requestReferenceDataSource_referenceDataSource_S3ReferenceDataSourceIsNull = false;
            }
            System.String requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_FileKey = null;
            if (cmdletContext.ReferenceDataSource_S3ReferenceDataSource_FileKey != null)
            {
                requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_FileKey = cmdletContext.ReferenceDataSource_S3ReferenceDataSource_FileKey;
            }
            if (requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_FileKey != null)
            {
                requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource.FileKey = requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_FileKey;
                requestReferenceDataSource_referenceDataSource_S3ReferenceDataSourceIsNull = false;
            }
            System.String requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_ReferenceRoleARN = null;
            if (cmdletContext.ReferenceDataSource_S3ReferenceDataSource_ReferenceRoleARN != null)
            {
                requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_ReferenceRoleARN = cmdletContext.ReferenceDataSource_S3ReferenceDataSource_ReferenceRoleARN;
            }
            if (requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_ReferenceRoleARN != null)
            {
                requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource.ReferenceRoleARN = requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource_s3ReferenceDataSource_ReferenceRoleARN;
                requestReferenceDataSource_referenceDataSource_S3ReferenceDataSourceIsNull = false;
            }
             // determine if requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource should be set to null
            if (requestReferenceDataSource_referenceDataSource_S3ReferenceDataSourceIsNull)
            {
                requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource = null;
            }
            if (requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource != null)
            {
                request.ReferenceDataSource.S3ReferenceDataSource = requestReferenceDataSource_referenceDataSource_S3ReferenceDataSource;
                requestReferenceDataSourceIsNull = false;
            }
             // determine if request.ReferenceDataSource should be set to null
            if (requestReferenceDataSourceIsNull)
            {
                request.ReferenceDataSource = null;
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
        
        private static Amazon.KinesisAnalytics.Model.AddApplicationReferenceDataSourceResponse CallAWSServiceOperation(IAmazonKinesisAnalytics client, Amazon.KinesisAnalytics.Model.AddApplicationReferenceDataSourceRequest request)
        {
            #if DESKTOP
            return client.AddApplicationReferenceDataSource(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AddApplicationReferenceDataSourceAsync(request);
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
            public List<Amazon.KinesisAnalytics.Model.RecordColumn> ReferenceDataSource_ReferenceSchema_RecordColumns { get; set; }
            public System.String ReferenceDataSource_ReferenceSchema_RecordEncoding { get; set; }
            public System.String ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordColumnDelimiter { get; set; }
            public System.String ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_CSVMappingParameters_RecordRowDelimiter { get; set; }
            public System.String ReferenceDataSource_ReferenceSchema_RecordFormat_MappingParameters_JSONMappingParameters_RecordRowPath { get; set; }
            public Amazon.KinesisAnalytics.RecordFormatType ReferenceDataSource_ReferenceSchema_RecordFormat_RecordFormatType { get; set; }
            public System.String ReferenceDataSource_S3ReferenceDataSource_BucketARN { get; set; }
            public System.String ReferenceDataSource_S3ReferenceDataSource_FileKey { get; set; }
            public System.String ReferenceDataSource_S3ReferenceDataSource_ReferenceRoleARN { get; set; }
            public System.String ReferenceDataSource_TableName { get; set; }
        }
        
    }
}
