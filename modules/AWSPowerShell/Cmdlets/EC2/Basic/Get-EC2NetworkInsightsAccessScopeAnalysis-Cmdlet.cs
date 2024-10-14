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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the specified Network Access Scope analyses.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2NetworkInsightsAccessScopeAnalysis")]
    [OutputType("Amazon.EC2.Model.NetworkInsightsAccessScopeAnalysis")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeNetworkInsightsAccessScopeAnalyses API operation.", Operation = new[] {"DescribeNetworkInsightsAccessScopeAnalyses"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeNetworkInsightsAccessScopeAnalysesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.NetworkInsightsAccessScopeAnalysis or Amazon.EC2.Model.DescribeNetworkInsightsAccessScopeAnalysesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.NetworkInsightsAccessScopeAnalysis objects.",
        "The service call response (type Amazon.EC2.Model.DescribeNetworkInsightsAccessScopeAnalysesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2NetworkInsightsAccessScopeAnalysisCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnalysisStartTimeBegin
        /// <summary>
        /// <para>
        /// <para>Filters the results based on the start time. The analysis must have started on or
        /// after this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? AnalysisStartTimeBegin { get; set; }
        #endregion
        
        #region Parameter AnalysisStartTimeEnd
        /// <summary>
        /// <para>
        /// <para>Filters the results based on the start time. The analysis must have started on or
        /// before this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? AnalysisStartTimeEnd { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>There are no supported filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter NetworkInsightsAccessScopeAnalysisId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Network Access Scope analyses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkInsightsAccessScopeAnalysisIds")]
        public System.String[] NetworkInsightsAccessScopeAnalysisId { get; set; }
        #endregion
        
        #region Parameter NetworkInsightsAccessScopeId
        /// <summary>
        /// <para>
        /// <para>The ID of the Network Access Scope.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NetworkInsightsAccessScopeId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkInsightsAccessScopeAnalyses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeNetworkInsightsAccessScopeAnalysesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeNetworkInsightsAccessScopeAnalysesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkInsightsAccessScopeAnalyses";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkInsightsAccessScopeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkInsightsAccessScopeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkInsightsAccessScopeId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeNetworkInsightsAccessScopeAnalysesResponse, GetEC2NetworkInsightsAccessScopeAnalysisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkInsightsAccessScopeId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnalysisStartTimeBegin = this.AnalysisStartTimeBegin;
            context.AnalysisStartTimeEnd = this.AnalysisStartTimeEnd;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            if (this.NetworkInsightsAccessScopeAnalysisId != null)
            {
                context.NetworkInsightsAccessScopeAnalysisId = new List<System.String>(this.NetworkInsightsAccessScopeAnalysisId);
            }
            context.NetworkInsightsAccessScopeId = this.NetworkInsightsAccessScopeId;
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeNetworkInsightsAccessScopeAnalysesRequest();
            
            if (cmdletContext.AnalysisStartTimeBegin != null)
            {
                request.AnalysisStartTimeBegin = cmdletContext.AnalysisStartTimeBegin.Value;
            }
            if (cmdletContext.AnalysisStartTimeEnd != null)
            {
                request.AnalysisStartTimeEnd = cmdletContext.AnalysisStartTimeEnd.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NetworkInsightsAccessScopeAnalysisId != null)
            {
                request.NetworkInsightsAccessScopeAnalysisIds = cmdletContext.NetworkInsightsAccessScopeAnalysisId;
            }
            if (cmdletContext.NetworkInsightsAccessScopeId != null)
            {
                request.NetworkInsightsAccessScopeId = cmdletContext.NetworkInsightsAccessScopeId;
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
        
        private Amazon.EC2.Model.DescribeNetworkInsightsAccessScopeAnalysesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeNetworkInsightsAccessScopeAnalysesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeNetworkInsightsAccessScopeAnalyses");
            try
            {
                #if DESKTOP
                return client.DescribeNetworkInsightsAccessScopeAnalyses(request);
                #elif CORECLR
                return client.DescribeNetworkInsightsAccessScopeAnalysesAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? AnalysisStartTimeBegin { get; set; }
            public System.DateTime? AnalysisStartTimeEnd { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<System.String> NetworkInsightsAccessScopeAnalysisId { get; set; }
            public System.String NetworkInsightsAccessScopeId { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeNetworkInsightsAccessScopeAnalysesResponse, GetEC2NetworkInsightsAccessScopeAnalysisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkInsightsAccessScopeAnalyses;
        }
        
    }
}
