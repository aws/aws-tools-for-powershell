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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Retrieves a list of your historical recommendation generations within the past 30
    /// days.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CESavingsPlansPurchaseRecommendationGenerationList")]
    [OutputType("Amazon.CostExplorer.Model.GenerationSummary")]
    [AWSCmdlet("Calls the AWS Cost Explorer ListSavingsPlansPurchaseRecommendationGeneration API operation.", Operation = new[] {"ListSavingsPlansPurchaseRecommendationGeneration"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.ListSavingsPlansPurchaseRecommendationGenerationResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GenerationSummary or Amazon.CostExplorer.Model.ListSavingsPlansPurchaseRecommendationGenerationResponse",
        "This cmdlet returns a collection of Amazon.CostExplorer.Model.GenerationSummary objects.",
        "The service call response (type Amazon.CostExplorer.Model.ListSavingsPlansPurchaseRecommendationGenerationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCESavingsPlansPurchaseRecommendationGenerationListCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GenerationStatus
        /// <summary>
        /// <para>
        /// <para>The status of the recommendation generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.GenerationStatus")]
        public Amazon.CostExplorer.GenerationStatus GenerationStatus { get; set; }
        #endregion
        
        #region Parameter RecommendationId
        /// <summary>
        /// <para>
        /// <para>The IDs for each specific recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationIds")]
        public System.String[] RecommendationId { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextPageToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextPageToken' to null for the first call then set the 'NextPageToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextPageToken { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The number of recommendations that you want returned in a single response object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GenerationSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.ListSavingsPlansPurchaseRecommendationGenerationResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.ListSavingsPlansPurchaseRecommendationGenerationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GenerationSummaryList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GenerationStatus parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GenerationStatus' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GenerationStatus' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextPageToken
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
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.ListSavingsPlansPurchaseRecommendationGenerationResponse, GetCESavingsPlansPurchaseRecommendationGenerationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GenerationStatus;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GenerationStatus = this.GenerationStatus;
            context.NextPageToken = this.NextPageToken;
            context.PageSize = this.PageSize;
            if (this.RecommendationId != null)
            {
                context.RecommendationId = new List<System.String>(this.RecommendationId);
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.CostExplorer.Model.ListSavingsPlansPurchaseRecommendationGenerationRequest();
            
            if (cmdletContext.GenerationStatus != null)
            {
                request.GenerationStatus = cmdletContext.GenerationStatus;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            if (cmdletContext.RecommendationId != null)
            {
                request.RecommendationIds = cmdletContext.RecommendationId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextPageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextPageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextPageToken = _nextToken;
                
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
                    
                    _nextToken = response.NextPageToken;
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
        
        private Amazon.CostExplorer.Model.ListSavingsPlansPurchaseRecommendationGenerationResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.ListSavingsPlansPurchaseRecommendationGenerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "ListSavingsPlansPurchaseRecommendationGeneration");
            try
            {
                #if DESKTOP
                return client.ListSavingsPlansPurchaseRecommendationGeneration(request);
                #elif CORECLR
                return client.ListSavingsPlansPurchaseRecommendationGenerationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CostExplorer.GenerationStatus GenerationStatus { get; set; }
            public System.String NextPageToken { get; set; }
            public System.Int32? PageSize { get; set; }
            public List<System.String> RecommendationId { get; set; }
            public System.Func<Amazon.CostExplorer.Model.ListSavingsPlansPurchaseRecommendationGenerationResponse, GetCESavingsPlansPurchaseRecommendationGenerationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GenerationSummaryList;
        }
        
    }
}
