/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Honeycode;
using Amazon.Honeycode.Model;

namespace Amazon.PowerShell.Cmdlets.HC
{
    /// <summary>
    /// The StartTableDataImportJob API allows you to start an import job on a table. This
    /// API will only return the id of the job that was started. To find out the status of
    /// the import request, you need to call the DescribeTableDataImportJob API.
    /// </summary>
    [Cmdlet("Start", "HCTableDataImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Honeycode.Model.StartTableDataImportJobResponse")]
    [AWSCmdlet("Calls the Amazon Honeycode StartTableDataImportJob API operation.", Operation = new[] {"StartTableDataImportJob"}, SelectReturnType = typeof(Amazon.Honeycode.Model.StartTableDataImportJobResponse))]
    [AWSCmdletOutput("Amazon.Honeycode.Model.StartTableDataImportJobResponse",
        "This cmdlet returns an Amazon.Honeycode.Model.StartTableDataImportJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartHCTableDataImportJobCmdlet : AmazonHoneycodeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para> The request token for performing the update action. Request tokens help to identify
        /// duplicate requests. If a call times out or fails due to a transient error like a failed
        /// network connection, you can retry the call with the same request token. The service
        /// ensures that if the first call using that request token is successfully performed,
        /// the second call will not perform the action again. </para><para> Note that request tokens are valid only for a few minutes. You cannot use request
        /// tokens to dedupe requests spanning hours or days. </para>
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
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_ColumnMap
        /// <summary>
        /// <para>
        /// <para>A map of the column id to the import properties for each column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportOptions_DestinationOptions_ColumnMap")]
        public System.Collections.Hashtable DestinationOptions_ColumnMap { get; set; }
        #endregion
        
        #region Parameter DelimitedTextOptions_DataCharacterEncoding
        /// <summary>
        /// <para>
        /// <para>The encoding of the data in the input file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportOptions_DelimitedTextOptions_DataCharacterEncoding")]
        [AWSConstantClassSource("Amazon.Honeycode.ImportDataCharacterEncoding")]
        public Amazon.Honeycode.ImportDataCharacterEncoding DelimitedTextOptions_DataCharacterEncoding { get; set; }
        #endregion
        
        #region Parameter DataFormat
        /// <summary>
        /// <para>
        /// <para> The format of the data that is being imported. Currently the only option supported
        /// is "DELIMITED_TEXT". </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Honeycode.ImportSourceDataFormat")]
        public Amazon.Honeycode.ImportSourceDataFormat DataFormat { get; set; }
        #endregion
        
        #region Parameter DataSourceConfig_DataSourceUrl
        /// <summary>
        /// <para>
        /// <para> The URL from which source data will be downloaded for the import request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSource_DataSourceConfig_DataSourceUrl")]
        public System.String DataSourceConfig_DataSourceUrl { get; set; }
        #endregion
        
        #region Parameter DelimitedTextOptions_Delimiter
        /// <summary>
        /// <para>
        /// <para>The delimiter to use for separating columns in a single row of the input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportOptions_DelimitedTextOptions_Delimiter")]
        public System.String DelimitedTextOptions_Delimiter { get; set; }
        #endregion
        
        #region Parameter DestinationTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the table where the rows are being imported.</para><para> If a table with the specified id could not be found, this API throws ResourceNotFoundException.
        /// </para>
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
        public System.String DestinationTableId { get; set; }
        #endregion
        
        #region Parameter DelimitedTextOptions_HasHeaderRow
        /// <summary>
        /// <para>
        /// <para>Indicates whether the input file has a header row at the top containing the column
        /// names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportOptions_DelimitedTextOptions_HasHeaderRow")]
        public System.Boolean? DelimitedTextOptions_HasHeaderRow { get; set; }
        #endregion
        
        #region Parameter DelimitedTextOptions_IgnoreEmptyRow
        /// <summary>
        /// <para>
        /// <para>A parameter to indicate whether empty rows should be ignored or be included in the
        /// import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportOptions_DelimitedTextOptions_IgnoreEmptyRows")]
        public System.Boolean? DelimitedTextOptions_IgnoreEmptyRow { get; set; }
        #endregion
        
        #region Parameter WorkbookId
        /// <summary>
        /// <para>
        /// <para>The ID of the workbook where the rows are being imported.</para><para> If a workbook with the specified id could not be found, this API throws ResourceNotFoundException.
        /// </para>
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
        public System.String WorkbookId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Honeycode.Model.StartTableDataImportJobResponse).
        /// Specifying the name of a property of type Amazon.Honeycode.Model.StartTableDataImportJobResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DestinationTableId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-HCTableDataImportJob (StartTableDataImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Honeycode.Model.StartTableDataImportJobResponse, StartHCTableDataImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            #if MODULAR
            if (this.ClientRequestToken == null && ParameterWasBound(nameof(this.ClientRequestToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientRequestToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataFormat = this.DataFormat;
            #if MODULAR
            if (this.DataFormat == null && ParameterWasBound(nameof(this.DataFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter DataFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSourceConfig_DataSourceUrl = this.DataSourceConfig_DataSourceUrl;
            context.DestinationTableId = this.DestinationTableId;
            #if MODULAR
            if (this.DestinationTableId == null && ParameterWasBound(nameof(this.DestinationTableId)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationTableId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DelimitedTextOptions_DataCharacterEncoding = this.DelimitedTextOptions_DataCharacterEncoding;
            context.DelimitedTextOptions_Delimiter = this.DelimitedTextOptions_Delimiter;
            context.DelimitedTextOptions_HasHeaderRow = this.DelimitedTextOptions_HasHeaderRow;
            context.DelimitedTextOptions_IgnoreEmptyRow = this.DelimitedTextOptions_IgnoreEmptyRow;
            if (this.DestinationOptions_ColumnMap != null)
            {
                context.DestinationOptions_ColumnMap = new Dictionary<System.String, Amazon.Honeycode.Model.SourceDataColumnProperties>(StringComparer.Ordinal);
                foreach (var hashKey in this.DestinationOptions_ColumnMap.Keys)
                {
                    context.DestinationOptions_ColumnMap.Add((String)hashKey, (Amazon.Honeycode.Model.SourceDataColumnProperties)(this.DestinationOptions_ColumnMap[hashKey]));
                }
            }
            context.WorkbookId = this.WorkbookId;
            #if MODULAR
            if (this.WorkbookId == null && ParameterWasBound(nameof(this.WorkbookId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkbookId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Honeycode.Model.StartTableDataImportJobRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DataFormat != null)
            {
                request.DataFormat = cmdletContext.DataFormat;
            }
            
             // populate DataSource
            var requestDataSourceIsNull = true;
            request.DataSource = new Amazon.Honeycode.Model.ImportDataSource();
            Amazon.Honeycode.Model.ImportDataSourceConfig requestDataSource_dataSource_DataSourceConfig = null;
            
             // populate DataSourceConfig
            var requestDataSource_dataSource_DataSourceConfigIsNull = true;
            requestDataSource_dataSource_DataSourceConfig = new Amazon.Honeycode.Model.ImportDataSourceConfig();
            System.String requestDataSource_dataSource_DataSourceConfig_dataSourceConfig_DataSourceUrl = null;
            if (cmdletContext.DataSourceConfig_DataSourceUrl != null)
            {
                requestDataSource_dataSource_DataSourceConfig_dataSourceConfig_DataSourceUrl = cmdletContext.DataSourceConfig_DataSourceUrl;
            }
            if (requestDataSource_dataSource_DataSourceConfig_dataSourceConfig_DataSourceUrl != null)
            {
                requestDataSource_dataSource_DataSourceConfig.DataSourceUrl = requestDataSource_dataSource_DataSourceConfig_dataSourceConfig_DataSourceUrl;
                requestDataSource_dataSource_DataSourceConfigIsNull = false;
            }
             // determine if requestDataSource_dataSource_DataSourceConfig should be set to null
            if (requestDataSource_dataSource_DataSourceConfigIsNull)
            {
                requestDataSource_dataSource_DataSourceConfig = null;
            }
            if (requestDataSource_dataSource_DataSourceConfig != null)
            {
                request.DataSource.DataSourceConfig = requestDataSource_dataSource_DataSourceConfig;
                requestDataSourceIsNull = false;
            }
             // determine if request.DataSource should be set to null
            if (requestDataSourceIsNull)
            {
                request.DataSource = null;
            }
            if (cmdletContext.DestinationTableId != null)
            {
                request.DestinationTableId = cmdletContext.DestinationTableId;
            }
            
             // populate ImportOptions
            var requestImportOptionsIsNull = true;
            request.ImportOptions = new Amazon.Honeycode.Model.ImportOptions();
            Amazon.Honeycode.Model.DestinationOptions requestImportOptions_importOptions_DestinationOptions = null;
            
             // populate DestinationOptions
            var requestImportOptions_importOptions_DestinationOptionsIsNull = true;
            requestImportOptions_importOptions_DestinationOptions = new Amazon.Honeycode.Model.DestinationOptions();
            Dictionary<System.String, Amazon.Honeycode.Model.SourceDataColumnProperties> requestImportOptions_importOptions_DestinationOptions_destinationOptions_ColumnMap = null;
            if (cmdletContext.DestinationOptions_ColumnMap != null)
            {
                requestImportOptions_importOptions_DestinationOptions_destinationOptions_ColumnMap = cmdletContext.DestinationOptions_ColumnMap;
            }
            if (requestImportOptions_importOptions_DestinationOptions_destinationOptions_ColumnMap != null)
            {
                requestImportOptions_importOptions_DestinationOptions.ColumnMap = requestImportOptions_importOptions_DestinationOptions_destinationOptions_ColumnMap;
                requestImportOptions_importOptions_DestinationOptionsIsNull = false;
            }
             // determine if requestImportOptions_importOptions_DestinationOptions should be set to null
            if (requestImportOptions_importOptions_DestinationOptionsIsNull)
            {
                requestImportOptions_importOptions_DestinationOptions = null;
            }
            if (requestImportOptions_importOptions_DestinationOptions != null)
            {
                request.ImportOptions.DestinationOptions = requestImportOptions_importOptions_DestinationOptions;
                requestImportOptionsIsNull = false;
            }
            Amazon.Honeycode.Model.DelimitedTextImportOptions requestImportOptions_importOptions_DelimitedTextOptions = null;
            
             // populate DelimitedTextOptions
            var requestImportOptions_importOptions_DelimitedTextOptionsIsNull = true;
            requestImportOptions_importOptions_DelimitedTextOptions = new Amazon.Honeycode.Model.DelimitedTextImportOptions();
            Amazon.Honeycode.ImportDataCharacterEncoding requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_DataCharacterEncoding = null;
            if (cmdletContext.DelimitedTextOptions_DataCharacterEncoding != null)
            {
                requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_DataCharacterEncoding = cmdletContext.DelimitedTextOptions_DataCharacterEncoding;
            }
            if (requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_DataCharacterEncoding != null)
            {
                requestImportOptions_importOptions_DelimitedTextOptions.DataCharacterEncoding = requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_DataCharacterEncoding;
                requestImportOptions_importOptions_DelimitedTextOptionsIsNull = false;
            }
            System.String requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_Delimiter = null;
            if (cmdletContext.DelimitedTextOptions_Delimiter != null)
            {
                requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_Delimiter = cmdletContext.DelimitedTextOptions_Delimiter;
            }
            if (requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_Delimiter != null)
            {
                requestImportOptions_importOptions_DelimitedTextOptions.Delimiter = requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_Delimiter;
                requestImportOptions_importOptions_DelimitedTextOptionsIsNull = false;
            }
            System.Boolean? requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_HasHeaderRow = null;
            if (cmdletContext.DelimitedTextOptions_HasHeaderRow != null)
            {
                requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_HasHeaderRow = cmdletContext.DelimitedTextOptions_HasHeaderRow.Value;
            }
            if (requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_HasHeaderRow != null)
            {
                requestImportOptions_importOptions_DelimitedTextOptions.HasHeaderRow = requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_HasHeaderRow.Value;
                requestImportOptions_importOptions_DelimitedTextOptionsIsNull = false;
            }
            System.Boolean? requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_IgnoreEmptyRow = null;
            if (cmdletContext.DelimitedTextOptions_IgnoreEmptyRow != null)
            {
                requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_IgnoreEmptyRow = cmdletContext.DelimitedTextOptions_IgnoreEmptyRow.Value;
            }
            if (requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_IgnoreEmptyRow != null)
            {
                requestImportOptions_importOptions_DelimitedTextOptions.IgnoreEmptyRows = requestImportOptions_importOptions_DelimitedTextOptions_delimitedTextOptions_IgnoreEmptyRow.Value;
                requestImportOptions_importOptions_DelimitedTextOptionsIsNull = false;
            }
             // determine if requestImportOptions_importOptions_DelimitedTextOptions should be set to null
            if (requestImportOptions_importOptions_DelimitedTextOptionsIsNull)
            {
                requestImportOptions_importOptions_DelimitedTextOptions = null;
            }
            if (requestImportOptions_importOptions_DelimitedTextOptions != null)
            {
                request.ImportOptions.DelimitedTextOptions = requestImportOptions_importOptions_DelimitedTextOptions;
                requestImportOptionsIsNull = false;
            }
             // determine if request.ImportOptions should be set to null
            if (requestImportOptionsIsNull)
            {
                request.ImportOptions = null;
            }
            if (cmdletContext.WorkbookId != null)
            {
                request.WorkbookId = cmdletContext.WorkbookId;
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
        
        private Amazon.Honeycode.Model.StartTableDataImportJobResponse CallAWSServiceOperation(IAmazonHoneycode client, Amazon.Honeycode.Model.StartTableDataImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Honeycode", "StartTableDataImportJob");
            try
            {
                #if DESKTOP
                return client.StartTableDataImportJob(request);
                #elif CORECLR
                return client.StartTableDataImportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public Amazon.Honeycode.ImportSourceDataFormat DataFormat { get; set; }
            public System.String DataSourceConfig_DataSourceUrl { get; set; }
            public System.String DestinationTableId { get; set; }
            public Amazon.Honeycode.ImportDataCharacterEncoding DelimitedTextOptions_DataCharacterEncoding { get; set; }
            public System.String DelimitedTextOptions_Delimiter { get; set; }
            public System.Boolean? DelimitedTextOptions_HasHeaderRow { get; set; }
            public System.Boolean? DelimitedTextOptions_IgnoreEmptyRow { get; set; }
            public Dictionary<System.String, Amazon.Honeycode.Model.SourceDataColumnProperties> DestinationOptions_ColumnMap { get; set; }
            public System.String WorkbookId { get; set; }
            public System.Func<Amazon.Honeycode.Model.StartTableDataImportJobResponse, StartHCTableDataImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
