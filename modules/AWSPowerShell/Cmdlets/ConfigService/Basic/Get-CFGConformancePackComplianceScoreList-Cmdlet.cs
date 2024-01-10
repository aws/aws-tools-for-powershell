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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns a list of conformance pack compliance scores. A compliance score is the percentage
    /// of the number of compliant rule-resource combinations in a conformance pack compared
    /// to the number of total possible rule-resource combinations in the conformance pack.
    /// This metric provides you with a high-level view of the compliance state of your conformance
    /// packs. You can use it to identify, investigate, and understand the level of compliance
    /// in your conformance packs.
    /// 
    ///  <note><para>
    /// Conformance packs with no evaluation results will have a compliance score of <c>INSUFFICIENT_DATA</c>.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFGConformancePackComplianceScoreList")]
    [OutputType("Amazon.ConfigService.Model.ConformancePackComplianceScore")]
    [AWSCmdlet("Calls the AWS Config ListConformancePackComplianceScores API operation.", Operation = new[] {"ListConformancePackComplianceScores"}, SelectReturnType = typeof(Amazon.ConfigService.Model.ListConformancePackComplianceScoresResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConformancePackComplianceScore or Amazon.ConfigService.Model.ListConformancePackComplianceScoresResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.ConformancePackComplianceScore objects.",
        "The service call response (type Amazon.ConfigService.Model.ListConformancePackComplianceScoresResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGConformancePackComplianceScoreListCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_ConformancePackName
        /// <summary>
        /// <para>
        /// <para>The names of the conformance packs whose compliance scores you want to include in
        /// the conformance pack compliance score result set. You can include up to 25 conformance
        /// packs in the <c>ConformancePackNames</c> array of strings, each with a character limit
        /// of 256 characters for the conformance pack name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ConformancePackNames")]
        public System.String[] Filters_ConformancePackName { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Sorts your conformance pack compliance scores in either ascending or descending order,
        /// depending on <c>SortOrder</c>.</para><para>By default, conformance pack compliance scores are sorted in alphabetical order by
        /// name of the conformance pack. Enter <c>SCORE</c>, to sort conformance pack compliance
        /// scores by the numerical value of the compliance score.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.SortBy")]
        public Amazon.ConfigService.SortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Determines the order in which conformance pack compliance scores are sorted. Either
        /// in ascending or descending order.</para><para>By default, conformance pack compliance scores are sorted in alphabetical order by
        /// name of the conformance pack. Conformance pack compliance scores are sorted in reverse
        /// alphabetical order if you enter <c>DESCENDING</c>.</para><para>You can sort conformance pack compliance scores by the numerical value of the compliance
        /// score by entering <c>SCORE</c> in the <c>SortBy</c> action. When compliance scores
        /// are sorted by <c>SCORE</c>, conformance packs with a compliance score of <c>INSUFFICIENT_DATA</c>
        /// will be last when sorting by ascending order and first when sorting by descending
        /// order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.SortOrder")]
        public Amazon.ConfigService.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of conformance pack compliance scores returned on each page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> string in a prior request that you can use to get the paginated
        /// response for the next set of conformance pack compliance scores.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConformancePackComplianceScores'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.ListConformancePackComplianceScoresResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.ListConformancePackComplianceScoresResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConformancePackComplianceScores";
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
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.ListConformancePackComplianceScoresResponse, GetCFGConformancePackComplianceScoreListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filters_ConformancePackName != null)
            {
                context.Filters_ConformancePackName = new List<System.String>(this.Filters_ConformancePackName);
            }
            context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
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
            var request = new Amazon.ConfigService.Model.ListConformancePackComplianceScoresRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.ConformancePackComplianceScoresFilters();
            List<System.String> requestFilters_filters_ConformancePackName = null;
            if (cmdletContext.Filters_ConformancePackName != null)
            {
                requestFilters_filters_ConformancePackName = cmdletContext.Filters_ConformancePackName;
            }
            if (requestFilters_filters_ConformancePackName != null)
            {
                request.Filters.ConformancePackNames = requestFilters_filters_ConformancePackName;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
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
        
        private Amazon.ConfigService.Model.ListConformancePackComplianceScoresResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.ListConformancePackComplianceScoresRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "ListConformancePackComplianceScores");
            try
            {
                #if DESKTOP
                return client.ListConformancePackComplianceScores(request);
                #elif CORECLR
                return client.ListConformancePackComplianceScoresAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Filters_ConformancePackName { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ConfigService.SortBy SortBy { get; set; }
            public Amazon.ConfigService.SortOrder SortOrder { get; set; }
            public System.Func<Amazon.ConfigService.Model.ListConformancePackComplianceScoresResponse, GetCFGConformancePackComplianceScoreListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConformancePackComplianceScores;
        }
        
    }
}
