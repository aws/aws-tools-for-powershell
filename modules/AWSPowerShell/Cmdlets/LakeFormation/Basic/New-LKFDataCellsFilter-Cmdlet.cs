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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// Creates a data cell filter to allow one to grant access to certain columns on certain
    /// rows.
    /// </summary>
    [Cmdlet("New", "LKFDataCellsFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Lake Formation CreateDataCellsFilter API operation.", Operation = new[] {"CreateDataCellsFilter"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.CreateDataCellsFilterResponse))]
    [AWSCmdletOutput("None or Amazon.LakeFormation.Model.CreateDataCellsFilterResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LakeFormation.Model.CreateDataCellsFilterResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewLKFDataCellsFilterCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RowFilter_AllRowsWildcard
        /// <summary>
        /// <para>
        /// <para>A wildcard for all rows.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableData_RowFilter_AllRowsWildcard")]
        public Amazon.LakeFormation.Model.AllRowsWildcard RowFilter_AllRowsWildcard { get; set; }
        #endregion
        
        #region Parameter TableData_ColumnName
        /// <summary>
        /// <para>
        /// <para>A list of column names and/or nested column attributes. When specifying nested attributes,
        /// use a qualified dot (.) delimited format such as "address"."zip". Nested attributes
        /// within this list may not exceed a depth of 5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableData_ColumnNames")]
        public System.String[] TableData_ColumnName { get; set; }
        #endregion
        
        #region Parameter TableData_DatabaseName
        /// <summary>
        /// <para>
        /// <para>A database in the Glue Data Catalog.</para>
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
        public System.String TableData_DatabaseName { get; set; }
        #endregion
        
        #region Parameter ColumnWildcard_ExcludedColumnName
        /// <summary>
        /// <para>
        /// <para>Excludes column names. Any column with this name will be excluded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableData_ColumnWildcard_ExcludedColumnNames")]
        public System.String[] ColumnWildcard_ExcludedColumnName { get; set; }
        #endregion
        
        #region Parameter RowFilter_FilterExpression
        /// <summary>
        /// <para>
        /// <para>A filter expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableData_RowFilter_FilterExpression")]
        public System.String RowFilter_FilterExpression { get; set; }
        #endregion
        
        #region Parameter TableData_Name
        /// <summary>
        /// <para>
        /// <para>The name given by the user to the data filter cell.</para>
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
        public System.String TableData_Name { get; set; }
        #endregion
        
        #region Parameter TableData_TableCatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the catalog to which the table belongs.</para>
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
        public System.String TableData_TableCatalogId { get; set; }
        #endregion
        
        #region Parameter TableData_TableName
        /// <summary>
        /// <para>
        /// <para>A table in the database.</para>
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
        public System.String TableData_TableName { get; set; }
        #endregion
        
        #region Parameter TableData_VersionId
        /// <summary>
        /// <para>
        /// <para>The ID of the data cells filter version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TableData_VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.CreateDataCellsFilterResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableData_TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LKFDataCellsFilter (CreateDataCellsFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.CreateDataCellsFilterResponse, NewLKFDataCellsFilterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.TableData_ColumnName != null)
            {
                context.TableData_ColumnName = new List<System.String>(this.TableData_ColumnName);
            }
            if (this.ColumnWildcard_ExcludedColumnName != null)
            {
                context.ColumnWildcard_ExcludedColumnName = new List<System.String>(this.ColumnWildcard_ExcludedColumnName);
            }
            context.TableData_DatabaseName = this.TableData_DatabaseName;
            #if MODULAR
            if (this.TableData_DatabaseName == null && ParameterWasBound(nameof(this.TableData_DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableData_DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableData_Name = this.TableData_Name;
            #if MODULAR
            if (this.TableData_Name == null && ParameterWasBound(nameof(this.TableData_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter TableData_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RowFilter_AllRowsWildcard = this.RowFilter_AllRowsWildcard;
            context.RowFilter_FilterExpression = this.RowFilter_FilterExpression;
            context.TableData_TableCatalogId = this.TableData_TableCatalogId;
            #if MODULAR
            if (this.TableData_TableCatalogId == null && ParameterWasBound(nameof(this.TableData_TableCatalogId)))
            {
                WriteWarning("You are passing $null as a value for parameter TableData_TableCatalogId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableData_TableName = this.TableData_TableName;
            #if MODULAR
            if (this.TableData_TableName == null && ParameterWasBound(nameof(this.TableData_TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableData_TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableData_VersionId = this.TableData_VersionId;
            
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
            var request = new Amazon.LakeFormation.Model.CreateDataCellsFilterRequest();
            
            
             // populate TableData
            var requestTableDataIsNull = true;
            request.TableData = new Amazon.LakeFormation.Model.DataCellsFilter();
            List<System.String> requestTableData_tableData_ColumnName = null;
            if (cmdletContext.TableData_ColumnName != null)
            {
                requestTableData_tableData_ColumnName = cmdletContext.TableData_ColumnName;
            }
            if (requestTableData_tableData_ColumnName != null)
            {
                request.TableData.ColumnNames = requestTableData_tableData_ColumnName;
                requestTableDataIsNull = false;
            }
            System.String requestTableData_tableData_DatabaseName = null;
            if (cmdletContext.TableData_DatabaseName != null)
            {
                requestTableData_tableData_DatabaseName = cmdletContext.TableData_DatabaseName;
            }
            if (requestTableData_tableData_DatabaseName != null)
            {
                request.TableData.DatabaseName = requestTableData_tableData_DatabaseName;
                requestTableDataIsNull = false;
            }
            System.String requestTableData_tableData_Name = null;
            if (cmdletContext.TableData_Name != null)
            {
                requestTableData_tableData_Name = cmdletContext.TableData_Name;
            }
            if (requestTableData_tableData_Name != null)
            {
                request.TableData.Name = requestTableData_tableData_Name;
                requestTableDataIsNull = false;
            }
            System.String requestTableData_tableData_TableCatalogId = null;
            if (cmdletContext.TableData_TableCatalogId != null)
            {
                requestTableData_tableData_TableCatalogId = cmdletContext.TableData_TableCatalogId;
            }
            if (requestTableData_tableData_TableCatalogId != null)
            {
                request.TableData.TableCatalogId = requestTableData_tableData_TableCatalogId;
                requestTableDataIsNull = false;
            }
            System.String requestTableData_tableData_TableName = null;
            if (cmdletContext.TableData_TableName != null)
            {
                requestTableData_tableData_TableName = cmdletContext.TableData_TableName;
            }
            if (requestTableData_tableData_TableName != null)
            {
                request.TableData.TableName = requestTableData_tableData_TableName;
                requestTableDataIsNull = false;
            }
            System.String requestTableData_tableData_VersionId = null;
            if (cmdletContext.TableData_VersionId != null)
            {
                requestTableData_tableData_VersionId = cmdletContext.TableData_VersionId;
            }
            if (requestTableData_tableData_VersionId != null)
            {
                request.TableData.VersionId = requestTableData_tableData_VersionId;
                requestTableDataIsNull = false;
            }
            Amazon.LakeFormation.Model.ColumnWildcard requestTableData_tableData_ColumnWildcard = null;
            
             // populate ColumnWildcard
            var requestTableData_tableData_ColumnWildcardIsNull = true;
            requestTableData_tableData_ColumnWildcard = new Amazon.LakeFormation.Model.ColumnWildcard();
            List<System.String> requestTableData_tableData_ColumnWildcard_columnWildcard_ExcludedColumnName = null;
            if (cmdletContext.ColumnWildcard_ExcludedColumnName != null)
            {
                requestTableData_tableData_ColumnWildcard_columnWildcard_ExcludedColumnName = cmdletContext.ColumnWildcard_ExcludedColumnName;
            }
            if (requestTableData_tableData_ColumnWildcard_columnWildcard_ExcludedColumnName != null)
            {
                requestTableData_tableData_ColumnWildcard.ExcludedColumnNames = requestTableData_tableData_ColumnWildcard_columnWildcard_ExcludedColumnName;
                requestTableData_tableData_ColumnWildcardIsNull = false;
            }
             // determine if requestTableData_tableData_ColumnWildcard should be set to null
            if (requestTableData_tableData_ColumnWildcardIsNull)
            {
                requestTableData_tableData_ColumnWildcard = null;
            }
            if (requestTableData_tableData_ColumnWildcard != null)
            {
                request.TableData.ColumnWildcard = requestTableData_tableData_ColumnWildcard;
                requestTableDataIsNull = false;
            }
            Amazon.LakeFormation.Model.RowFilter requestTableData_tableData_RowFilter = null;
            
             // populate RowFilter
            var requestTableData_tableData_RowFilterIsNull = true;
            requestTableData_tableData_RowFilter = new Amazon.LakeFormation.Model.RowFilter();
            Amazon.LakeFormation.Model.AllRowsWildcard requestTableData_tableData_RowFilter_rowFilter_AllRowsWildcard = null;
            if (cmdletContext.RowFilter_AllRowsWildcard != null)
            {
                requestTableData_tableData_RowFilter_rowFilter_AllRowsWildcard = cmdletContext.RowFilter_AllRowsWildcard;
            }
            if (requestTableData_tableData_RowFilter_rowFilter_AllRowsWildcard != null)
            {
                requestTableData_tableData_RowFilter.AllRowsWildcard = requestTableData_tableData_RowFilter_rowFilter_AllRowsWildcard;
                requestTableData_tableData_RowFilterIsNull = false;
            }
            System.String requestTableData_tableData_RowFilter_rowFilter_FilterExpression = null;
            if (cmdletContext.RowFilter_FilterExpression != null)
            {
                requestTableData_tableData_RowFilter_rowFilter_FilterExpression = cmdletContext.RowFilter_FilterExpression;
            }
            if (requestTableData_tableData_RowFilter_rowFilter_FilterExpression != null)
            {
                requestTableData_tableData_RowFilter.FilterExpression = requestTableData_tableData_RowFilter_rowFilter_FilterExpression;
                requestTableData_tableData_RowFilterIsNull = false;
            }
             // determine if requestTableData_tableData_RowFilter should be set to null
            if (requestTableData_tableData_RowFilterIsNull)
            {
                requestTableData_tableData_RowFilter = null;
            }
            if (requestTableData_tableData_RowFilter != null)
            {
                request.TableData.RowFilter = requestTableData_tableData_RowFilter;
                requestTableDataIsNull = false;
            }
             // determine if request.TableData should be set to null
            if (requestTableDataIsNull)
            {
                request.TableData = null;
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
        
        private Amazon.LakeFormation.Model.CreateDataCellsFilterResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.CreateDataCellsFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "CreateDataCellsFilter");
            try
            {
                return client.CreateDataCellsFilterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> TableData_ColumnName { get; set; }
            public List<System.String> ColumnWildcard_ExcludedColumnName { get; set; }
            public System.String TableData_DatabaseName { get; set; }
            public System.String TableData_Name { get; set; }
            public Amazon.LakeFormation.Model.AllRowsWildcard RowFilter_AllRowsWildcard { get; set; }
            public System.String RowFilter_FilterExpression { get; set; }
            public System.String TableData_TableCatalogId { get; set; }
            public System.String TableData_TableName { get; set; }
            public System.String TableData_VersionId { get; set; }
            public System.Func<Amazon.LakeFormation.Model.CreateDataCellsFilterResponse, NewLKFDataCellsFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
