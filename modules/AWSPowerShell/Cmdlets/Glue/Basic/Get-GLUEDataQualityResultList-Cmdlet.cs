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
    /// Returns all data quality execution results for your account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUEDataQualityResultList")]
    [OutputType("Amazon.Glue.Model.DataQualityResultDescription")]
    [AWSCmdlet("Calls the AWS Glue ListDataQualityResults API operation.", Operation = new[] {"ListDataQualityResults"}, SelectReturnType = typeof(Amazon.Glue.Model.ListDataQualityResultsResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.DataQualityResultDescription or Amazon.Glue.Model.ListDataQualityResultsResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.DataQualityResultDescription objects.",
        "The service call response (type Amazon.Glue.Model.ListDataQualityResultsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGLUEDataQualityResultListCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GlueTable_AdditionalOption
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
        public System.Collections.Hashtable GlueTable_AdditionalOption { get; set; }
        #endregion
        
        #region Parameter GlueTable_CatalogId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_DataSource_GlueTable_CatalogId")]
        public System.String GlueTable_CatalogId { get; set; }
        #endregion
        
        #region Parameter GlueTable_ConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the connection to the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_DataSource_GlueTable_ConnectionName")]
        public System.String GlueTable_ConnectionName { get; set; }
        #endregion
        
        #region Parameter GlueTable_DatabaseName
        /// <summary>
        /// <para>
        /// <para>A database name in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_DataSource_GlueTable_DatabaseName")]
        public System.String GlueTable_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Filter_JobName
        /// <summary>
        /// <para>
        /// <para>Filter results by the specified job name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_JobName { get; set; }
        #endregion
        
        #region Parameter Filter_JobRunId
        /// <summary>
        /// <para>
        /// <para>Filter results by the specified job run ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_JobRunId { get; set; }
        #endregion
        
        #region Parameter Filter_StartedAfter
        /// <summary>
        /// <para>
        /// <para>Filter results by runs that started after this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_StartedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_StartedBefore
        /// <summary>
        /// <para>
        /// <para>Filter results by runs that started before this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_StartedBefore { get; set; }
        #endregion
        
        #region Parameter GlueTable_TableName
        /// <summary>
        /// <para>
        /// <para>A table name in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_DataSource_GlueTable_TableName")]
        public System.String GlueTable_TableName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A paginated token to offset the results.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.ListDataQualityResultsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.ListDataQualityResultsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.ListDataQualityResultsResponse, GetGLUEDataQualityResultListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.GlueTable_AdditionalOption != null)
            {
                context.GlueTable_AdditionalOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.GlueTable_AdditionalOption.Keys)
                {
                    context.GlueTable_AdditionalOption.Add((String)hashKey, (System.String)(this.GlueTable_AdditionalOption[hashKey]));
                }
            }
            context.GlueTable_CatalogId = this.GlueTable_CatalogId;
            context.GlueTable_ConnectionName = this.GlueTable_ConnectionName;
            context.GlueTable_DatabaseName = this.GlueTable_DatabaseName;
            context.GlueTable_TableName = this.GlueTable_TableName;
            context.Filter_JobName = this.Filter_JobName;
            context.Filter_JobRunId = this.Filter_JobRunId;
            context.Filter_StartedAfter = this.Filter_StartedAfter;
            context.Filter_StartedBefore = this.Filter_StartedBefore;
            context.MaxResult = this.MaxResult;
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
            var request = new Amazon.Glue.Model.ListDataQualityResultsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Glue.Model.DataQualityResultFilterCriteria();
            System.String requestFilter_filter_JobName = null;
            if (cmdletContext.Filter_JobName != null)
            {
                requestFilter_filter_JobName = cmdletContext.Filter_JobName;
            }
            if (requestFilter_filter_JobName != null)
            {
                request.Filter.JobName = requestFilter_filter_JobName;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_JobRunId = null;
            if (cmdletContext.Filter_JobRunId != null)
            {
                requestFilter_filter_JobRunId = cmdletContext.Filter_JobRunId;
            }
            if (requestFilter_filter_JobRunId != null)
            {
                request.Filter.JobRunId = requestFilter_filter_JobRunId;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_StartedAfter = null;
            if (cmdletContext.Filter_StartedAfter != null)
            {
                requestFilter_filter_StartedAfter = cmdletContext.Filter_StartedAfter.Value;
            }
            if (requestFilter_filter_StartedAfter != null)
            {
                request.Filter.StartedAfter = requestFilter_filter_StartedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_StartedBefore = null;
            if (cmdletContext.Filter_StartedBefore != null)
            {
                requestFilter_filter_StartedBefore = cmdletContext.Filter_StartedBefore.Value;
            }
            if (requestFilter_filter_StartedBefore != null)
            {
                request.Filter.StartedBefore = requestFilter_filter_StartedBefore.Value;
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
            Dictionary<System.String, System.String> requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_AdditionalOption = null;
            if (cmdletContext.GlueTable_AdditionalOption != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_AdditionalOption = cmdletContext.GlueTable_AdditionalOption;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_AdditionalOption != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable.AdditionalOptions = requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_AdditionalOption;
                requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_CatalogId = null;
            if (cmdletContext.GlueTable_CatalogId != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_CatalogId = cmdletContext.GlueTable_CatalogId;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_CatalogId != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable.CatalogId = requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_CatalogId;
                requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_ConnectionName = null;
            if (cmdletContext.GlueTable_ConnectionName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_ConnectionName = cmdletContext.GlueTable_ConnectionName;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_ConnectionName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable.ConnectionName = requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_ConnectionName;
                requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_DatabaseName = null;
            if (cmdletContext.GlueTable_DatabaseName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_DatabaseName = cmdletContext.GlueTable_DatabaseName;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_DatabaseName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable.DatabaseName = requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_DatabaseName;
                requestFilter_filter_DataSource_filter_DataSource_GlueTableIsNull = false;
            }
            System.String requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_TableName = null;
            if (cmdletContext.GlueTable_TableName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_TableName = cmdletContext.GlueTable_TableName;
            }
            if (requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_TableName != null)
            {
                requestFilter_filter_DataSource_filter_DataSource_GlueTable.TableName = requestFilter_filter_DataSource_filter_DataSource_GlueTable_glueTable_TableName;
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
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.Glue.Model.ListDataQualityResultsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.ListDataQualityResultsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "ListDataQualityResults");
            try
            {
                return client.ListDataQualityResultsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> GlueTable_AdditionalOption { get; set; }
            public System.String GlueTable_CatalogId { get; set; }
            public System.String GlueTable_ConnectionName { get; set; }
            public System.String GlueTable_DatabaseName { get; set; }
            public System.String GlueTable_TableName { get; set; }
            public System.String Filter_JobName { get; set; }
            public System.String Filter_JobRunId { get; set; }
            public System.DateTime? Filter_StartedAfter { get; set; }
            public System.DateTime? Filter_StartedBefore { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Glue.Model.ListDataQualityResultsResponse, GetGLUEDataQualityResultListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
