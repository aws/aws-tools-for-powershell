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
using Amazon.LookoutMetrics;
using Amazon.LookoutMetrics.Model;

namespace Amazon.PowerShell.Cmdlets.LOM
{
    /// <summary>
    /// Returns a selection of sample records from an Amazon S3 datasource.
    /// </summary>
    [Cmdlet("Get", "LOMSampleData")]
    [OutputType("Amazon.LookoutMetrics.Model.GetSampleDataResponse")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics GetSampleData API operation.", Operation = new[] {"GetSampleData"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.GetSampleDataResponse))]
    [AWSCmdletOutput("Amazon.LookoutMetrics.Model.GetSampleDataResponse",
        "This cmdlet returns an Amazon.LookoutMetrics.Model.GetSampleDataResponse object containing multiple properties."
    )]
    public partial class GetLOMSampleDataCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CsvFormatDescriptor_Charset
        /// <summary>
        /// <para>
        /// <para>The character set in which the source CSV file is written.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_Charset")]
        public System.String CsvFormatDescriptor_Charset { get; set; }
        #endregion
        
        #region Parameter JsonFormatDescriptor_Charset
        /// <summary>
        /// <para>
        /// <para>The character set in which the source JSON file is written.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_Charset")]
        public System.String JsonFormatDescriptor_Charset { get; set; }
        #endregion
        
        #region Parameter CsvFormatDescriptor_ContainsHeader
        /// <summary>
        /// <para>
        /// <para>Whether or not the source CSV file contains a header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_ContainsHeader")]
        public System.Boolean? CsvFormatDescriptor_ContainsHeader { get; set; }
        #endregion
        
        #region Parameter CsvFormatDescriptor_Delimiter
        /// <summary>
        /// <para>
        /// <para>The character used to delimit the source CSV file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_Delimiter")]
        public System.String CsvFormatDescriptor_Delimiter { get; set; }
        #endregion
        
        #region Parameter CsvFormatDescriptor_FileCompression
        /// <summary>
        /// <para>
        /// <para>The level of compression of the source CSV file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_FileCompression")]
        [AWSConstantClassSource("Amazon.LookoutMetrics.CSVFileCompression")]
        public Amazon.LookoutMetrics.CSVFileCompression CsvFormatDescriptor_FileCompression { get; set; }
        #endregion
        
        #region Parameter JsonFormatDescriptor_FileCompression
        /// <summary>
        /// <para>
        /// <para>The level of compression of the source CSV file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_FileCompression")]
        [AWSConstantClassSource("Amazon.LookoutMetrics.JsonFileCompression")]
        public Amazon.LookoutMetrics.JsonFileCompression JsonFormatDescriptor_FileCompression { get; set; }
        #endregion
        
        #region Parameter CsvFormatDescriptor_HeaderList
        /// <summary>
        /// <para>
        /// <para>A list of the source CSV file's headers, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_HeaderList")]
        public System.String[] CsvFormatDescriptor_HeaderList { get; set; }
        #endregion
        
        #region Parameter S3SourceConfig_HistoricalDataPathList
        /// <summary>
        /// <para>
        /// <para>An array of strings containing the historical set of data paths.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] S3SourceConfig_HistoricalDataPathList { get; set; }
        #endregion
        
        #region Parameter CsvFormatDescriptor_QuoteSymbol
        /// <summary>
        /// <para>
        /// <para>The character used as a quote character.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_QuoteSymbol")]
        public System.String CsvFormatDescriptor_QuoteSymbol { get; set; }
        #endregion
        
        #region Parameter S3SourceConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3SourceConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter S3SourceConfig_TemplatedPathList
        /// <summary>
        /// <para>
        /// <para>An array of strings containing the list of templated paths.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] S3SourceConfig_TemplatedPathList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.GetSampleDataResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.GetSampleDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.GetSampleDataResponse, GetLOMSampleDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CsvFormatDescriptor_Charset = this.CsvFormatDescriptor_Charset;
            context.CsvFormatDescriptor_ContainsHeader = this.CsvFormatDescriptor_ContainsHeader;
            context.CsvFormatDescriptor_Delimiter = this.CsvFormatDescriptor_Delimiter;
            context.CsvFormatDescriptor_FileCompression = this.CsvFormatDescriptor_FileCompression;
            if (this.CsvFormatDescriptor_HeaderList != null)
            {
                context.CsvFormatDescriptor_HeaderList = new List<System.String>(this.CsvFormatDescriptor_HeaderList);
            }
            context.CsvFormatDescriptor_QuoteSymbol = this.CsvFormatDescriptor_QuoteSymbol;
            context.JsonFormatDescriptor_Charset = this.JsonFormatDescriptor_Charset;
            context.JsonFormatDescriptor_FileCompression = this.JsonFormatDescriptor_FileCompression;
            if (this.S3SourceConfig_HistoricalDataPathList != null)
            {
                context.S3SourceConfig_HistoricalDataPathList = new List<System.String>(this.S3SourceConfig_HistoricalDataPathList);
            }
            context.S3SourceConfig_RoleArn = this.S3SourceConfig_RoleArn;
            if (this.S3SourceConfig_TemplatedPathList != null)
            {
                context.S3SourceConfig_TemplatedPathList = new List<System.String>(this.S3SourceConfig_TemplatedPathList);
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
            var request = new Amazon.LookoutMetrics.Model.GetSampleDataRequest();
            
            
             // populate S3SourceConfig
            var requestS3SourceConfigIsNull = true;
            request.S3SourceConfig = new Amazon.LookoutMetrics.Model.SampleDataS3SourceConfig();
            List<System.String> requestS3SourceConfig_s3SourceConfig_HistoricalDataPathList = null;
            if (cmdletContext.S3SourceConfig_HistoricalDataPathList != null)
            {
                requestS3SourceConfig_s3SourceConfig_HistoricalDataPathList = cmdletContext.S3SourceConfig_HistoricalDataPathList;
            }
            if (requestS3SourceConfig_s3SourceConfig_HistoricalDataPathList != null)
            {
                request.S3SourceConfig.HistoricalDataPathList = requestS3SourceConfig_s3SourceConfig_HistoricalDataPathList;
                requestS3SourceConfigIsNull = false;
            }
            System.String requestS3SourceConfig_s3SourceConfig_RoleArn = null;
            if (cmdletContext.S3SourceConfig_RoleArn != null)
            {
                requestS3SourceConfig_s3SourceConfig_RoleArn = cmdletContext.S3SourceConfig_RoleArn;
            }
            if (requestS3SourceConfig_s3SourceConfig_RoleArn != null)
            {
                request.S3SourceConfig.RoleArn = requestS3SourceConfig_s3SourceConfig_RoleArn;
                requestS3SourceConfigIsNull = false;
            }
            List<System.String> requestS3SourceConfig_s3SourceConfig_TemplatedPathList = null;
            if (cmdletContext.S3SourceConfig_TemplatedPathList != null)
            {
                requestS3SourceConfig_s3SourceConfig_TemplatedPathList = cmdletContext.S3SourceConfig_TemplatedPathList;
            }
            if (requestS3SourceConfig_s3SourceConfig_TemplatedPathList != null)
            {
                request.S3SourceConfig.TemplatedPathList = requestS3SourceConfig_s3SourceConfig_TemplatedPathList;
                requestS3SourceConfigIsNull = false;
            }
            Amazon.LookoutMetrics.Model.FileFormatDescriptor requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor = null;
            
             // populate FileFormatDescriptor
            var requestS3SourceConfig_s3SourceConfig_FileFormatDescriptorIsNull = true;
            requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor = new Amazon.LookoutMetrics.Model.FileFormatDescriptor();
            Amazon.LookoutMetrics.Model.JsonFormatDescriptor requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor = null;
            
             // populate JsonFormatDescriptor
            var requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptorIsNull = true;
            requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor = new Amazon.LookoutMetrics.Model.JsonFormatDescriptor();
            System.String requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_Charset = null;
            if (cmdletContext.JsonFormatDescriptor_Charset != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_Charset = cmdletContext.JsonFormatDescriptor_Charset;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_Charset != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor.Charset = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_Charset;
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptorIsNull = false;
            }
            Amazon.LookoutMetrics.JsonFileCompression requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_FileCompression = null;
            if (cmdletContext.JsonFormatDescriptor_FileCompression != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_FileCompression = cmdletContext.JsonFormatDescriptor_FileCompression;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_FileCompression != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor.FileCompression = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_FileCompression;
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptorIsNull = false;
            }
             // determine if requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor should be set to null
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptorIsNull)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor = null;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor.JsonFormatDescriptor = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor;
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptorIsNull = false;
            }
            Amazon.LookoutMetrics.Model.CsvFormatDescriptor requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor = null;
            
             // populate CsvFormatDescriptor
            var requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = true;
            requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor = new Amazon.LookoutMetrics.Model.CsvFormatDescriptor();
            System.String requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Charset = null;
            if (cmdletContext.CsvFormatDescriptor_Charset != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Charset = cmdletContext.CsvFormatDescriptor_Charset;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Charset != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.Charset = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Charset;
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
            System.Boolean? requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_ContainsHeader = null;
            if (cmdletContext.CsvFormatDescriptor_ContainsHeader != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_ContainsHeader = cmdletContext.CsvFormatDescriptor_ContainsHeader.Value;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_ContainsHeader != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.ContainsHeader = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_ContainsHeader.Value;
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
            System.String requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Delimiter = null;
            if (cmdletContext.CsvFormatDescriptor_Delimiter != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Delimiter = cmdletContext.CsvFormatDescriptor_Delimiter;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Delimiter != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.Delimiter = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Delimiter;
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
            Amazon.LookoutMetrics.CSVFileCompression requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_FileCompression = null;
            if (cmdletContext.CsvFormatDescriptor_FileCompression != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_FileCompression = cmdletContext.CsvFormatDescriptor_FileCompression;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_FileCompression != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.FileCompression = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_FileCompression;
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
            List<System.String> requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_HeaderList = null;
            if (cmdletContext.CsvFormatDescriptor_HeaderList != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_HeaderList = cmdletContext.CsvFormatDescriptor_HeaderList;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_HeaderList != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.HeaderList = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_HeaderList;
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
            System.String requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_QuoteSymbol = null;
            if (cmdletContext.CsvFormatDescriptor_QuoteSymbol != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_QuoteSymbol = cmdletContext.CsvFormatDescriptor_QuoteSymbol;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_QuoteSymbol != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.QuoteSymbol = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_QuoteSymbol;
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
             // determine if requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor should be set to null
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor = null;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor != null)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor.CsvFormatDescriptor = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor_s3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor;
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptorIsNull = false;
            }
             // determine if requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor should be set to null
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptorIsNull)
            {
                requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor = null;
            }
            if (requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor != null)
            {
                request.S3SourceConfig.FileFormatDescriptor = requestS3SourceConfig_s3SourceConfig_FileFormatDescriptor;
                requestS3SourceConfigIsNull = false;
            }
             // determine if request.S3SourceConfig should be set to null
            if (requestS3SourceConfigIsNull)
            {
                request.S3SourceConfig = null;
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
        
        private Amazon.LookoutMetrics.Model.GetSampleDataResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.GetSampleDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "GetSampleData");
            try
            {
                #if DESKTOP
                return client.GetSampleData(request);
                #elif CORECLR
                return client.GetSampleDataAsync(request).GetAwaiter().GetResult();
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
            public System.String CsvFormatDescriptor_Charset { get; set; }
            public System.Boolean? CsvFormatDescriptor_ContainsHeader { get; set; }
            public System.String CsvFormatDescriptor_Delimiter { get; set; }
            public Amazon.LookoutMetrics.CSVFileCompression CsvFormatDescriptor_FileCompression { get; set; }
            public List<System.String> CsvFormatDescriptor_HeaderList { get; set; }
            public System.String CsvFormatDescriptor_QuoteSymbol { get; set; }
            public System.String JsonFormatDescriptor_Charset { get; set; }
            public Amazon.LookoutMetrics.JsonFileCompression JsonFormatDescriptor_FileCompression { get; set; }
            public List<System.String> S3SourceConfig_HistoricalDataPathList { get; set; }
            public System.String S3SourceConfig_RoleArn { get; set; }
            public List<System.String> S3SourceConfig_TemplatedPathList { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.GetSampleDataResponse, GetLOMSampleDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
