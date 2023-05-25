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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Returns a paginated list of rulesets for the specified list of Glue tables.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUEDataQualityRulesetList")]
    [OutputType("Amazon.Glue.Model.DataQualityRulesetListDetails")]
    [AWSCmdlet("Calls the AWS Glue ListDataQualityRulesets API operation.", Operation = new[] {"ListDataQualityRulesets"}, SelectReturnType = typeof(Amazon.Glue.Model.ListDataQualityRulesetsResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.DataQualityRulesetListDetails or Amazon.Glue.Model.ListDataQualityRulesetsResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.DataQualityRulesetListDetails objects.",
        "The service call response (type Amazon.Glue.Model.ListDataQualityRulesetsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEDataQualityRulesetListCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter TargetTable_CatalogId
        /// <summary>
        /// <para>
        /// <para>The catalog id where the Glue table exists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_TargetTable_CatalogId")]
        public System.String TargetTable_CatalogId { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedAfter
        /// <summary>
        /// <para>
        /// <para>Filter on rulesets created after this date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedBefore
        /// <summary>
        /// <para>
        /// <para>Filter on rulesets created before this date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedBefore { get; set; }
        #endregion
        
        #region Parameter TargetTable_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database where the Glue table exists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_TargetTable_DatabaseName")]
        public System.String TargetTable_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Filter_Description
        /// <summary>
        /// <para>
        /// <para>The description of the ruleset filter criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_Description { get; set; }
        #endregion
        
        #region Parameter Filter_LastModifiedAfter
        /// <summary>
        /// <para>
        /// <para>Filter on rulesets last modified after this date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_LastModifiedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_LastModifiedBefore
        /// <summary>
        /// <para>
        /// <para>Filter on rulesets last modified before this date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_LastModifiedBefore { get; set; }
        #endregion
        
        #region Parameter Filter_Name
        /// <summary>
        /// <para>
        /// <para>The name of the ruleset filter criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_Name { get; set; }
        #endregion
        
        #region Parameter TargetTable_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the Glue table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_TargetTable_TableName")]
        public System.String TargetTable_TableName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pair tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Rulesets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.ListDataQualityRulesetsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.ListDataQualityRulesetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Rulesets";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.ListDataQualityRulesetsResponse, GetGLUEDataQualityRulesetListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter_CreatedAfter = this.Filter_CreatedAfter;
            context.Filter_CreatedBefore = this.Filter_CreatedBefore;
            context.Filter_Description = this.Filter_Description;
            context.Filter_LastModifiedAfter = this.Filter_LastModifiedAfter;
            context.Filter_LastModifiedBefore = this.Filter_LastModifiedBefore;
            context.Filter_Name = this.Filter_Name;
            context.TargetTable_CatalogId = this.TargetTable_CatalogId;
            context.TargetTable_DatabaseName = this.TargetTable_DatabaseName;
            context.TargetTable_TableName = this.TargetTable_TableName;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Glue.Model.ListDataQualityRulesetsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Glue.Model.DataQualityRulesetFilterCriteria();
            System.DateTime? requestFilter_filter_CreatedAfter = null;
            if (cmdletContext.Filter_CreatedAfter != null)
            {
                requestFilter_filter_CreatedAfter = cmdletContext.Filter_CreatedAfter.Value;
            }
            if (requestFilter_filter_CreatedAfter != null)
            {
                request.Filter.CreatedAfter = requestFilter_filter_CreatedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreatedBefore = null;
            if (cmdletContext.Filter_CreatedBefore != null)
            {
                requestFilter_filter_CreatedBefore = cmdletContext.Filter_CreatedBefore.Value;
            }
            if (requestFilter_filter_CreatedBefore != null)
            {
                request.Filter.CreatedBefore = requestFilter_filter_CreatedBefore.Value;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_Description = null;
            if (cmdletContext.Filter_Description != null)
            {
                requestFilter_filter_Description = cmdletContext.Filter_Description;
            }
            if (requestFilter_filter_Description != null)
            {
                request.Filter.Description = requestFilter_filter_Description;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_LastModifiedAfter = null;
            if (cmdletContext.Filter_LastModifiedAfter != null)
            {
                requestFilter_filter_LastModifiedAfter = cmdletContext.Filter_LastModifiedAfter.Value;
            }
            if (requestFilter_filter_LastModifiedAfter != null)
            {
                request.Filter.LastModifiedAfter = requestFilter_filter_LastModifiedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_LastModifiedBefore = null;
            if (cmdletContext.Filter_LastModifiedBefore != null)
            {
                requestFilter_filter_LastModifiedBefore = cmdletContext.Filter_LastModifiedBefore.Value;
            }
            if (requestFilter_filter_LastModifiedBefore != null)
            {
                request.Filter.LastModifiedBefore = requestFilter_filter_LastModifiedBefore.Value;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_Name = null;
            if (cmdletContext.Filter_Name != null)
            {
                requestFilter_filter_Name = cmdletContext.Filter_Name;
            }
            if (requestFilter_filter_Name != null)
            {
                request.Filter.Name = requestFilter_filter_Name;
                requestFilterIsNull = false;
            }
            Amazon.Glue.Model.DataQualityTargetTable requestFilter_filter_TargetTable = null;
            
             // populate TargetTable
            var requestFilter_filter_TargetTableIsNull = true;
            requestFilter_filter_TargetTable = new Amazon.Glue.Model.DataQualityTargetTable();
            System.String requestFilter_filter_TargetTable_targetTable_CatalogId = null;
            if (cmdletContext.TargetTable_CatalogId != null)
            {
                requestFilter_filter_TargetTable_targetTable_CatalogId = cmdletContext.TargetTable_CatalogId;
            }
            if (requestFilter_filter_TargetTable_targetTable_CatalogId != null)
            {
                requestFilter_filter_TargetTable.CatalogId = requestFilter_filter_TargetTable_targetTable_CatalogId;
                requestFilter_filter_TargetTableIsNull = false;
            }
            System.String requestFilter_filter_TargetTable_targetTable_DatabaseName = null;
            if (cmdletContext.TargetTable_DatabaseName != null)
            {
                requestFilter_filter_TargetTable_targetTable_DatabaseName = cmdletContext.TargetTable_DatabaseName;
            }
            if (requestFilter_filter_TargetTable_targetTable_DatabaseName != null)
            {
                requestFilter_filter_TargetTable.DatabaseName = requestFilter_filter_TargetTable_targetTable_DatabaseName;
                requestFilter_filter_TargetTableIsNull = false;
            }
            System.String requestFilter_filter_TargetTable_targetTable_TableName = null;
            if (cmdletContext.TargetTable_TableName != null)
            {
                requestFilter_filter_TargetTable_targetTable_TableName = cmdletContext.TargetTable_TableName;
            }
            if (requestFilter_filter_TargetTable_targetTable_TableName != null)
            {
                requestFilter_filter_TargetTable.TableName = requestFilter_filter_TargetTable_targetTable_TableName;
                requestFilter_filter_TargetTableIsNull = false;
            }
             // determine if requestFilter_filter_TargetTable should be set to null
            if (requestFilter_filter_TargetTableIsNull)
            {
                requestFilter_filter_TargetTable = null;
            }
            if (requestFilter_filter_TargetTable != null)
            {
                request.Filter.TargetTable = requestFilter_filter_TargetTable;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Glue.Model.ListDataQualityRulesetsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.ListDataQualityRulesetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "ListDataQualityRulesets");
            try
            {
                #if DESKTOP
                return client.ListDataQualityRulesets(request);
                #elif CORECLR
                return client.ListDataQualityRulesetsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? Filter_CreatedAfter { get; set; }
            public System.DateTime? Filter_CreatedBefore { get; set; }
            public System.String Filter_Description { get; set; }
            public System.DateTime? Filter_LastModifiedAfter { get; set; }
            public System.DateTime? Filter_LastModifiedBefore { get; set; }
            public System.String Filter_Name { get; set; }
            public System.String TargetTable_CatalogId { get; set; }
            public System.String TargetTable_DatabaseName { get; set; }
            public System.String TargetTable_TableName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Glue.Model.ListDataQualityRulesetsResponse, GetGLUEDataQualityRulesetListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Rulesets;
        }
        
    }
}
