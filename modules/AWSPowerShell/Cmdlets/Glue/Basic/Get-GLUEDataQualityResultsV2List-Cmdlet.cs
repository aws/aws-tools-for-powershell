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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Returns a paginated list of data quality execution results for your account, filtered
    /// by the specified criteria. Use the <c>NextToken</c> parameter to retrieve additional
    /// results.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUEDataQualityResultsV2List")]
    [OutputType("Amazon.Glue.Model.DataQualityResultsV2Description")]
    [AWSCmdlet("Calls the AWS Glue ListDataQualityResultsV2 API operation.", Operation = new[] {"ListDataQualityResultsV2"}, SelectReturnType = typeof(Amazon.Glue.Model.ListDataQualityResultsV2Response))]
    [AWSCmdletOutput("Amazon.Glue.Model.DataQualityResultsV2Description or Amazon.Glue.Model.ListDataQualityResultsV2Response",
        "This cmdlet returns a collection of Amazon.Glue.Model.DataQualityResultsV2Description objects.",
        "The service call response (type Amazon.Glue.Model.ListDataQualityResultsV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class GetGLUEDataQualityResultsV2ListCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter_DataSource_DataQualityGlueTable_AdditionalOption
        /// <summary>
        /// <para>
        /// <para>Additional options for the table. Currently there are two keys supported:</para><ul><li><para><c>pushDownPredicate</c>: to filter on partitions without having to list and read
        /// all the files in your dataset.</para></li><li><para><c>catalogPartitionPredicate</c>: to use server-side partition pruning using partition
        /// indexes in the Glue Data Catalog.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_DataSource_DataQualityGlueTable_AdditionalOptions")]
        public System.Collections.Hashtable Filter_DataSource_DataQualityGlueTable_AdditionalOption { get; set; }
        #endregion
        
        #region Parameter Filter_DataSource_GlueTable_AdditionalOption
        /// <summary>
        /// <para>
        /// <para>Additional options for the table. Currently there are two keys supported:</para><ul><li><para><c>pushDownPredicate</c>: to filter on partitions without having to list and read
        /// all the files in your dataset.</para></li><li><para><c>catalogPartitionPredicate</c>: to use server-side partition pruning using partition
        /// indexes in the Glue Data Catalog.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_DataSource_GlueTable_AdditionalOptions")]
        public System.Collections.Hashtable Filter_DataSource_GlueTable_AdditionalOption { get; set; }
        #endregion
        
        #region Parameter Filter_DataSource_DataQualityGlueTable_CatalogId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_DataSource_DataQualityGlueTable_CatalogId { get; set; }
        #endregion
        
        #region Parameter Filter_DataSource_GlueTable_CatalogId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_DataSource_GlueTable_CatalogId { get; set; }
        #endregion
        
        #region Parameter Filter_DataSource_DataQualityGlueTable_ConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the connection to the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_DataSource_DataQualityGlueTable_ConnectionName { get; set; }
        #endregion
        
        #region Parameter Filter_DataSource_GlueTable_ConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the connection to the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_DataSource_GlueTable_ConnectionName { get; set; }
        #endregion
        
        #region Parameter Filter_DataSource_DataQualityGlueTable_DatabaseName
        /// <summary>
        /// <para>
        /// <para>A database name in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_DataSource_DataQualityGlueTable_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Filter_DataSource_GlueTable_DatabaseName
        /// <summary>
        /// <para>
        /// <para>A database name in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_DataSource_GlueTable_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Filter_Dimension
        /// <summary>
        /// <para>
        /// <para>The platform dimensions to filter results by.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Dimensions")]
        public System.Collections.Hashtable Filter_Dimension { get; set; }
        #endregion
        
        #region Parameter Filter_EvaluationContext
        /// <summary>
        /// <para>
        /// <para>The evaluation context to filter results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_EvaluationContext { get; set; }
        #endregion
        
        #region Parameter Filter_DataSource_DataQualityGlueTable_PreProcessingQuery
        /// <summary>
        /// <para>
        /// <para>SQL Query of SparkSQL format that can be used to pre-process the data for the table
        /// in Glue Data Catalog, before running the Data Quality Operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_DataSource_DataQualityGlueTable_PreProcessingQuery { get; set; }
        #endregion
        
        #region Parameter Filter_PublishedAfter
        /// <summary>
        /// <para>
        /// <para>The time after which to include published results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_PublishedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_PublishedBefore
        /// <summary>
        /// <para>
        /// <para>The time before which to include published results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_PublishedBefore { get; set; }
        #endregion
        
        #region Parameter Filter_DataSource_DataQualityGlueTable_TableName
        /// <summary>
        /// <para>
        /// <para>A table name in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_DataSource_DataQualityGlueTable_TableName { get; set; }
        #endregion
        
        #region Parameter Filter_DataSource_GlueTable_TableName
        /// <summary>
        /// <para>
        /// <para>A table name in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_DataSource_GlueTable_TableName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. If you don't specify a value, the operation
        /// uses the default number of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A pagination token to retrieve the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.ListDataQualityResultsV2Response).
        /// Specifying the name of a property of type Amazon.Glue.Model.ListDataQualityResultsV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.ListDataQualityResultsV2Response, GetGLUEDataQualityResultsV2ListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter_DataSource_DataQualityGlueTable_AdditionalOption != null)
            {
                context.Filter_DataSource_DataQualityGlueTable_AdditionalOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filter_DataSource_DataQualityGlueTable_AdditionalOption.Keys)
                {
                    context.Filter_DataSource_DataQualityGlueTable_AdditionalOption.Add((String)hashKey, (System.String)(this.Filter_DataSource_DataQualityGlueTable_AdditionalOption[hashKey]));
                }
            }
            context.Filter_DataSource_DataQualityGlueTable_CatalogId = this.Filter_DataSource_DataQualityGlueTable_CatalogId;
            context.Filter_DataSource_DataQualityGlueTable_ConnectionName = this.Filter_DataSource_DataQualityGlueTable_ConnectionName;
            context.Filter_DataSource_DataQualityGlueTable_DatabaseName = this.Filter_DataSource_DataQualityGlueTable_DatabaseName;
            context.Filter_DataSource_DataQualityGlueTable_PreProcessingQuery = this.Filter_DataSource_DataQualityGlueTable_PreProcessingQuery;
            context.Filter_DataSource_DataQualityGlueTable_TableName = this.Filter_DataSource_DataQualityGlueTable_TableName;
            if (this.Filter_DataSource_GlueTable_AdditionalOption != null)
            {
                context.Filter_DataSource_GlueTable_AdditionalOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filter_DataSource_GlueTable_AdditionalOption.Keys)
                {
                    context.Filter_DataSource_GlueTable_AdditionalOption.Add((String)hashKey, (System.String)(this.Filter_DataSource_GlueTable_AdditionalOption[hashKey]));
                }
            }
            context.Filter_DataSource_GlueTable_CatalogId = this.Filter_DataSource_GlueTable_CatalogId;
            context.Filter_DataSource_GlueTable_ConnectionName = this.Filter_DataSource_GlueTable_ConnectionName;
            context.Filter_DataSource_GlueTable_DatabaseName = this.Filter_DataSource_GlueTable_DatabaseName;
            context.Filter_DataSource_GlueTable_TableName = this.Filter_DataSource_GlueTable_TableName;
            if (this.Filter_Dimension != null)
            {
                context.Filter_Dimension = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filter_Dimension.Keys)
                {
                    context.Filter_Dimension.Add((String)hashKey, (System.String)(this.Filter_Dimension[hashKey]));
                }
            }
            context.Filter_EvaluationContext = this.Filter_EvaluationContext;
            context.Filter_PublishedAfter = this.Filter_PublishedAfter;
            context.Filter_PublishedBefore = this.Filter_PublishedBefore;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Glue.Model.ListDataQualityResultsV2Request();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Glue.Model.DataQualityResultsV2FilterCriteria();
            Dictionary<System.String, System.String> requestFilter_filter_Dimension = null;
            if (cmdletContext.Filter_Dimension != null)
            {
                requestFilter_filter_Dimension = cmdletContext.Filter_Dimension;
            }
            if (requestFilter_filter_Dimension != null)
            {
                request.Filter.Dimensions = requestFilter_filter_Dimension;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_EvaluationContext = null;
            if (cmdletContext.Filter_EvaluationContext != null)
            {
                requestFilter_filter_EvaluationContext = cmdletContext.Filter_EvaluationContext;
            }
            if (requestFilter_filter_EvaluationContext != null)
            {
                request.Filter.EvaluationContext = requestFilter_filter_EvaluationContext;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_PublishedAfter = null;
            if (cmdletContext.Filter_PublishedAfter != null)
            {
                requestFilter_filter_PublishedAfter = cmdletContext.Filter_PublishedAfter.Value;
            }
            if (requestFilter_filter_PublishedAfter != null)
            {
                request.Filter.PublishedAfter = requestFilter_filter_PublishedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_PublishedBefore = null;
            if (cmdletContext.Filter_PublishedBefore != null)
            {
                requestFilter_filter_PublishedBefore = cmdletContext.Filter_PublishedBefore.Value;
            }
            if (requestFilter_filter_PublishedBefore != null)
            {
                request.Filter.PublishedBefore = requestFilter_filter_PublishedBefore.Value;
                requestFilterIsNull = false;
            }
            Amazon.Glue.Model.DataSource requestFilter_filter_DataSource = null;
            
             // populate DataSource
            var requestFilter_filter_DataSourceIsNull = true;
            requestFilter_filter_DataSource = new Amazon.Glue.Model.DataSource();
            Amazon.Glue.Model.GlueTable requestFilter_filter_DataSource_filter_DataSource_GlueTable = null;
            
             // populate GlueTable
            var requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull = true;
            requestFilter_filter_DataSource_filter_DataSource_GlueTable = new Amazon.Glue.Model.GlueTable();
            Dictionary<System.String, System.String> requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_AdditionalOption = null;
            if (cmdletContext.Filter_DataSource_GlueTable_AdditionalOption != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_AdditionalOption = cmdletContext.Filter_DataSource_GlueTable_AdditionalOption;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_AdditionalOption != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable.AdditionalOptions = requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_AdditionalOption;
                requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_CatalogId = null;
            if (cmdletContext.Filter_DataSource_GlueTable_CatalogId != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_CatalogId = cmdletContext.Filter_DataSource_GlueTable_CatalogId;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_CatalogId != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable.CatalogId = requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_CatalogId;
                requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_ConnectionName = null;
            if (cmdletContext.Filter_DataSource_GlueTable_ConnectionName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_ConnectionName = cmdletContext.Filter_DataSource_GlueTable_ConnectionName;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_ConnectionName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable.ConnectionName = requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_ConnectionName;
                requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_DatabaseName = null;
            if (cmdletContext.Filter_DataSource_GlueTable_DatabaseName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_DatabaseName = cmdletContext.Filter_DataSource_GlueTable_DatabaseName;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_DatabaseName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable.DatabaseName = requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_DatabaseName;
                requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_TableName = null;
            if (cmdletContext.Filter_DataSource_GlueTable_TableName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_TableName = cmdletContext.Filter_DataSource_GlueTable_TableName;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_TableName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable.TableName = requestFilter_filter_DataSource_filter_DataSource_GlueTable_filter_DataSource_GlueTable_TableName;
                requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull = false;
            }
             // determine if requestFilter_filter_DataSource_filter_DataSource_GlueTable should be set to null
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable = null;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable != null)
            {
                requestFilter_filter_DataSource.GlueTable = requestFilter_filter_DataSource_filter_DataSource_GlueTable;
                requestFilter_filter_DataSourceIsNull = false;
            }
            Amazon.Glue.Model.DataQualityGlueTable requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable = null;
            
             // populate DataQualityGlueTable
            var requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTableIsNull = true;
            requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable = new Amazon.Glue.Model.DataQualityGlueTable();
            Dictionary<System.String, System.String> requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_AdditionalOption = null;
            if (cmdletContext.Filter_DataSource_DataQualityGlueTable_AdditionalOption != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_AdditionalOption = cmdletContext.Filter_DataSource_DataQualityGlueTable_AdditionalOption;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_AdditionalOption != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable.AdditionalOptions = requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_AdditionalOption;
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_CatalogId = null;
            if (cmdletContext.Filter_DataSource_DataQualityGlueTable_CatalogId != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_CatalogId = cmdletContext.Filter_DataSource_DataQualityGlueTable_CatalogId;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_CatalogId != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable.CatalogId = requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_CatalogId;
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_ConnectionName = null;
            if (cmdletContext.Filter_DataSource_DataQualityGlueTable_ConnectionName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_ConnectionName = cmdletContext.Filter_DataSource_DataQualityGlueTable_ConnectionName;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_ConnectionName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable.ConnectionName = requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_ConnectionName;
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_DatabaseName = null;
            if (cmdletContext.Filter_DataSource_DataQualityGlueTable_DatabaseName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_DatabaseName = cmdletContext.Filter_DataSource_DataQualityGlueTable_DatabaseName;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_DatabaseName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable.DatabaseName = requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_DatabaseName;
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_PreProcessingQuery = null;
            if (cmdletContext.Filter_DataSource_DataQualityGlueTable_PreProcessingQuery != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_PreProcessingQuery = cmdletContext.Filter_DataSource_DataQualityGlueTable_PreProcessingQuery;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_PreProcessingQuery != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable.PreProcessingQuery = requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_PreProcessingQuery;
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_TableName = null;
            if (cmdletContext.Filter_DataSource_DataQualityGlueTable_TableName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_TableName = cmdletContext.Filter_DataSource_DataQualityGlueTable_TableName;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_TableName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable.TableName = requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable_filter_DataSource_DataQualityGlueTable_TableName;
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTableIsNull = false;
            }
             // determine if requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable should be set to null
            if (requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTableIsNull)
            {
                requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable = null;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable != null)
            {
                requestFilter_filter_DataSource.DataQualityGlueTable = requestFilter_filter_DataSource_filter_DataSource_DataQualityGlueTable;
                requestFilter_filter_DataSourceIsNull = false;
            }
             // determine if requestFilter_filter_DataSource should be set to null
            if (requestFilter_filter_DataSourceIsNull)
            {
                requestFilter_filter_DataSource = null;
            }
            if (requestFilter_filter_DataSource != null)
            {
                request.Filter.DataSource = requestFilter_filter_DataSource;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Glue.Model.ListDataQualityResultsV2Response CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.ListDataQualityResultsV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "ListDataQualityResultsV2");
            try
            {
                return client.ListDataQualityResultsV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Filter_DataSource_DataQualityGlueTable_AdditionalOption { get; set; }
            public System.String Filter_DataSource_DataQualityGlueTable_CatalogId { get; set; }
            public System.String Filter_DataSource_DataQualityGlueTable_ConnectionName { get; set; }
            public System.String Filter_DataSource_DataQualityGlueTable_DatabaseName { get; set; }
            public System.String Filter_DataSource_DataQualityGlueTable_PreProcessingQuery { get; set; }
            public System.String Filter_DataSource_DataQualityGlueTable_TableName { get; set; }
            public Dictionary<System.String, System.String> Filter_DataSource_GlueTable_AdditionalOption { get; set; }
            public System.String Filter_DataSource_GlueTable_CatalogId { get; set; }
            public System.String Filter_DataSource_GlueTable_ConnectionName { get; set; }
            public System.String Filter_DataSource_GlueTable_DatabaseName { get; set; }
            public System.String Filter_DataSource_GlueTable_TableName { get; set; }
            public Dictionary<System.String, System.String> Filter_Dimension { get; set; }
            public System.String Filter_EvaluationContext { get; set; }
            public System.DateTime? Filter_PublishedAfter { get; set; }
            public System.DateTime? Filter_PublishedBefore { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Glue.Model.ListDataQualityResultsV2Response, GetGLUEDataQualityResultsV2ListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
