/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Retrieves information about the partitions in a table.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "GLUEPartitionList")]
    [OutputType("Amazon.Glue.Model.Partition")]
    [AWSCmdlet("Calls the AWS Glue GetPartitions API operation.", Operation = new[] {"GetPartitions"})]
    [AWSCmdletOutput("Amazon.Glue.Model.Partition",
        "This cmdlet returns a collection of Partition objects.",
        "The service call response (type Amazon.Glue.Model.GetPartitionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetGLUEPartitionListCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog where the partitions in question reside. If none is supplied,
        /// the AWS account ID is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the catalog database where the partitions reside.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter Expression
        /// <summary>
        /// <para>
        /// <para>An expression filtering the partitions to be returned.</para><para>The expression uses SQL syntax similar to the SQL <code>WHERE</code> filter clause.
        /// The SQL statement parser <a href="http://jsqlparser.sourceforge.net/home.php">JSQLParser</a>
        /// parses the expression. </para><para><i>Operators</i>: The following are the operators that you can use in the <code>Expression</code>
        /// API call:</para><dl><dt>=</dt><dd><para>Checks if the values of the two operands are equal or not; if yes, then the condition
        /// becomes true.</para><para>Example: Assume 'variable a' holds 10 and 'variable b' holds 20. </para><para>(a = b) is not true.</para></dd><dt>&lt; &gt;</dt><dd><para>Checks if the values of two operands are equal or not; if the values are not equal,
        /// then the condition becomes true.</para><para>Example: (a &lt; &gt; b) is true.</para></dd><dt>&gt;</dt><dd><para>Checks if the value of the left operand is greater than the value of the right operand;
        /// if yes, then the condition becomes true.</para><para>Example: (a &gt; b) is not true.</para></dd><dt>&lt;</dt><dd><para>Checks if the value of the left operand is less than the value of the right operand;
        /// if yes, then the condition becomes true.</para><para>Example: (a &lt; b) is true.</para></dd><dt>&gt;=</dt><dd><para>Checks if the value of the left operand is greater than or equal to the value of the
        /// right operand; if yes, then the condition becomes true.</para><para>Example: (a &gt;= b) is not true.</para></dd><dt>&lt;=</dt><dd><para>Checks if the value of the left operand is less than or equal to the value of the
        /// right operand; if yes, then the condition becomes true.</para><para>Example: (a &lt;= b) is true.</para></dd><dt>AND, OR, IN, BETWEEN, LIKE, NOT, IS NULL</dt><dd><para>Logical operators.</para></dd></dl><para><i>Supported Partition Key Types</i>: The following are the the supported partition
        /// keys.</para><ul><li><para><code>string</code></para></li><li><para><code>date</code></para></li><li><para><code>timestamp</code></para></li><li><para><code>int</code></para></li><li><para><code>bigint</code></para></li><li><para><code>long</code></para></li><li><para><code>tinyint</code></para></li><li><para><code>smallint</code></para></li><li><para><code>decimal</code></para></li></ul><para>If an invalid type is encountered, an exception is thrown. </para><para>The following list shows the valid operators on each type. When you define a crawler,
        /// the <code>partitionKey</code> type is created as a <code>STRING</code>, to be compatible
        /// with the catalog partitions. </para><para><i>Sample API Call</i>: </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Expression { get; set; }
        #endregion
        
        #region Parameter Segment
        /// <summary>
        /// <para>
        /// <para>The segment of the table's partitions to scan in this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Glue.Model.Segment Segment { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the partitions' table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of partitions to return in a single response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A continuation token, if this is not the first call to retrieve these partitions.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CatalogId = this.CatalogId;
            context.DatabaseName = this.DatabaseName;
            context.Expression = this.Expression;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Segment = this.Segment;
            context.TableName = this.TableName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.Glue.Model.GetPartitionsRequest();
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.Expression != null)
            {
                request.Expression = cmdletContext.Expression;
            }
            if (cmdletContext.Segment != null)
            {
                request.Segment = cmdletContext.Segment;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken");
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    int correctPageSize = 1000;
                    if (_emitLimit.HasValue)
                    {
                        correctPageSize = AutoIterationHelpers.Min(1000, _emitLimit.Value);
                    }
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Partitions;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Partitions.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        _retrievedSoFar += _receivedThisCall;
                        if (_emitLimit.HasValue)
                        {
                            _emitLimit -= _receivedThisCall;
                        }
                    }
                    catch (Exception e)
                    {
                        if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                        {
                            output = new CmdletOutput { ErrorResponse = e };
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    ProcessOutput(output);
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
            }
            finally
            {
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Glue.Model.GetPartitionsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetPartitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetPartitions");
            try
            {
                #if DESKTOP
                return client.GetPartitions(request);
                #elif CORECLR
                return client.GetPartitionsAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogId { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String Expression { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Glue.Model.Segment Segment { get; set; }
            public System.String TableName { get; set; }
        }
        
    }
}
