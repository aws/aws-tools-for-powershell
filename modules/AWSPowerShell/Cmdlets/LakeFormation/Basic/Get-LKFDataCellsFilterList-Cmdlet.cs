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
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// Lists all the data cell filters on a table.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LKFDataCellsFilterList")]
    [OutputType("Amazon.LakeFormation.Model.DataCellsFilter")]
    [AWSCmdlet("Calls the AWS Lake Formation ListDataCellsFilter API operation.", Operation = new[] {"ListDataCellsFilter"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.ListDataCellsFilterResponse))]
    [AWSCmdletOutput("Amazon.LakeFormation.Model.DataCellsFilter or Amazon.LakeFormation.Model.ListDataCellsFilterResponse",
        "This cmdlet returns a collection of Amazon.LakeFormation.Model.DataCellsFilter objects.",
        "The service call response (type Amazon.LakeFormation.Model.ListDataCellsFilterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLKFDataCellsFilterListCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Table_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Data Catalog. By default, it is the account ID of the caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Table_CatalogId { get; set; }
        #endregion
        
        #region Parameter Table_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database for the table. Unique to a Data Catalog. A database is a
        /// set of associated table definitions organized into a logical group. You can Grant
        /// and Revoke database privileges to a principal. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Table_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Table_Name
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Table_Name { get; set; }
        #endregion
        
        #region Parameter Table_TableWildcard
        /// <summary>
        /// <para>
        /// <para>A wildcard object representing every table under a database.</para><para>At least one of <code>TableResource$Name</code> or <code>TableResource$TableWildcard</code>
        /// is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LakeFormation.Model.TableWildcard Table_TableWildcard { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum size of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A continuation token, if this is a continuation call.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataCellsFilters'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.ListDataCellsFilterResponse).
        /// Specifying the name of a property of type Amazon.LakeFormation.Model.ListDataCellsFilterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataCellsFilters";
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.ListDataCellsFilterResponse, GetLKFDataCellsFilterListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Table_CatalogId = this.Table_CatalogId;
            context.Table_DatabaseName = this.Table_DatabaseName;
            context.Table_Name = this.Table_Name;
            context.Table_TableWildcard = this.Table_TableWildcard;
            
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
            var request = new Amazon.LakeFormation.Model.ListDataCellsFilterRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate Table
            var requestTableIsNull = true;
            request.Table = new Amazon.LakeFormation.Model.TableResource();
            System.String requestTable_table_CatalogId = null;
            if (cmdletContext.Table_CatalogId != null)
            {
                requestTable_table_CatalogId = cmdletContext.Table_CatalogId;
            }
            if (requestTable_table_CatalogId != null)
            {
                request.Table.CatalogId = requestTable_table_CatalogId;
                requestTableIsNull = false;
            }
            System.String requestTable_table_DatabaseName = null;
            if (cmdletContext.Table_DatabaseName != null)
            {
                requestTable_table_DatabaseName = cmdletContext.Table_DatabaseName;
            }
            if (requestTable_table_DatabaseName != null)
            {
                request.Table.DatabaseName = requestTable_table_DatabaseName;
                requestTableIsNull = false;
            }
            System.String requestTable_table_Name = null;
            if (cmdletContext.Table_Name != null)
            {
                requestTable_table_Name = cmdletContext.Table_Name;
            }
            if (requestTable_table_Name != null)
            {
                request.Table.Name = requestTable_table_Name;
                requestTableIsNull = false;
            }
            Amazon.LakeFormation.Model.TableWildcard requestTable_table_TableWildcard = null;
            if (cmdletContext.Table_TableWildcard != null)
            {
                requestTable_table_TableWildcard = cmdletContext.Table_TableWildcard;
            }
            if (requestTable_table_TableWildcard != null)
            {
                request.Table.TableWildcard = requestTable_table_TableWildcard;
                requestTableIsNull = false;
            }
             // determine if request.Table should be set to null
            if (requestTableIsNull)
            {
                request.Table = null;
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
        
        private Amazon.LakeFormation.Model.ListDataCellsFilterResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.ListDataCellsFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "ListDataCellsFilter");
            try
            {
                #if DESKTOP
                return client.ListDataCellsFilter(request);
                #elif CORECLR
                return client.ListDataCellsFilterAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Table_CatalogId { get; set; }
            public System.String Table_DatabaseName { get; set; }
            public System.String Table_Name { get; set; }
            public Amazon.LakeFormation.Model.TableWildcard Table_TableWildcard { get; set; }
            public System.Func<Amazon.LakeFormation.Model.ListDataCellsFilterResponse, GetLKFDataCellsFilterListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataCellsFilters;
        }
        
    }
}
