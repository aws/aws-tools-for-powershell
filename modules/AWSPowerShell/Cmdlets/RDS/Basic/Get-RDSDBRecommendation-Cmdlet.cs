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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Describes the recommendations to resolve the issues for your DB instances, DB clusters,
    /// and DB parameter groups.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RDSDBRecommendation")]
    [OutputType("Amazon.RDS.Model.DBRecommendation")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeDBRecommendations API operation.", Operation = new[] {"DescribeDBRecommendations"}, SelectReturnType = typeof(Amazon.RDS.Model.DescribeDBRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBRecommendation or Amazon.RDS.Model.DescribeDBRecommendationsResponse",
        "This cmdlet returns a collection of Amazon.RDS.Model.DBRecommendation objects.",
        "The service call response (type Amazon.RDS.Model.DescribeDBRecommendationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRDSDBRecommendationCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A filter that specifies one or more recommendations to describe.</para><para>Supported Filters:</para><ul><li><para><code>recommendation-id</code> - Accepts a list of recommendation identifiers. The
        /// results list only includes the recommendations whose identifier is one of the specified
        /// filter values.</para></li><li><para><code>status</code> - Accepts a list of recommendation statuses.</para><para>Valid values:</para><ul><li><para><code>active</code> - The recommendations which are ready for you to apply.</para></li><li><para><code>pending</code> - The applied or scheduled recommendations which are in progress.</para></li><li><para><code>resolved</code> - The recommendations which are completed.</para></li><li><para><code>dismissed</code> - The recommendations that you dismissed.</para></li></ul><para>The results list only includes the recommendations whose status is one of the specified
        /// filter values.</para></li><li><para><code>severity</code> - Accepts a list of recommendation severities. The results
        /// list only includes the recommendations whose severity is one of the specified filter
        /// values.</para><para>Valid values:</para><ul><li><para><code>high</code></para></li><li><para><code>medium</code></para></li><li><para><code>low</code></para></li><li><para><code>informational</code></para></li></ul></li><li><para><code>type-id</code> - Accepts a list of recommendation type identifiers. The results
        /// list only includes the recommendations whose type is one of the specified filter values.</para></li><li><para><code>dbi-resource-id</code> - Accepts a list of database resource identifiers. The
        /// results list only includes the recommendations that generated for the specified databases.</para></li><li><para><code>cluster-resource-id</code> - Accepts a list of cluster resource identifiers.
        /// The results list only includes the recommendations that generated for the specified
        /// clusters.</para></li><li><para><code>pg-arn</code> - Accepts a list of parameter group ARNs. The results list only
        /// includes the recommendations that generated for the specified parameter groups.</para></li><li><para><code>cluster-pg-arn</code> - Accepts a list of cluster parameter group ARNs. The
        /// results list only includes the recommendations that generated for the specified cluster
        /// parameter groups.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter LastUpdatedAfter
        /// <summary>
        /// <para>
        /// <para>A filter to include only the recommendations that were updated after this specified
        /// time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? LastUpdatedAfter { get; set; }
        #endregion
        
        #region Parameter LastUpdatedBefore
        /// <summary>
        /// <para>
        /// <para>A filter to include only the recommendations that were updated before this specified
        /// time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? LastUpdatedBefore { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The language that you choose to return the list of recommendations.</para><para>Valid values:</para><ul><li><para><code>en</code></para></li><li><para><code>en_UK</code></para></li><li><para><code>de</code></para></li><li><para><code>es</code></para></li><li><para><code>fr</code></para></li><li><para><code>id</code></para></li><li><para><code>it</code></para></li><li><para><code>ja</code></para></li><li><para><code>ko</code></para></li><li><para><code>pt_BR</code></para></li><li><para><code>zh_TW</code></para></li><li><para><code>zh_CN</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous <code>DescribeDBRecommendations</code>
        /// request. If this parameter is specified, the response includes only records beyond
        /// the marker, up to the value specified by <code>MaxRecords</code>. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-Marker $null' for the first call and '-Marker $AWSHistory.LastServiceResponse.Marker' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of recommendations to include in the response. If more records
        /// exist than the specified <code>MaxRecords</code> value, a pagination token called
        /// a marker is included in the response so that you can retrieve the remaining results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBRecommendations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DescribeDBRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DescribeDBRecommendationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBRecommendations";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DescribeDBRecommendationsResponse, GetRDSDBRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.RDS.Model.Filter>(this.Filter);
            }
            context.LastUpdatedAfter = this.LastUpdatedAfter;
            context.LastUpdatedBefore = this.LastUpdatedBefore;
            context.Locale = this.Locale;
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            
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
            var request = new Amazon.RDS.Model.DescribeDBRecommendationsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.LastUpdatedAfter != null)
            {
                request.LastUpdatedAfter = cmdletContext.LastUpdatedAfter.Value;
            }
            if (cmdletContext.LastUpdatedBefore != null)
            {
                request.LastUpdatedBefore = cmdletContext.LastUpdatedBefore.Value;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.RDS.Model.DescribeDBRecommendationsResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeDBRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeDBRecommendations");
            try
            {
                #if DESKTOP
                return client.DescribeDBRecommendations(request);
                #elif CORECLR
                return client.DescribeDBRecommendationsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.RDS.Model.Filter> Filter { get; set; }
            public System.DateTime? LastUpdatedAfter { get; set; }
            public System.DateTime? LastUpdatedBefore { get; set; }
            public System.String Locale { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.Func<Amazon.RDS.Model.DescribeDBRecommendationsResponse, GetRDSDBRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBRecommendations;
        }
        
    }
}
