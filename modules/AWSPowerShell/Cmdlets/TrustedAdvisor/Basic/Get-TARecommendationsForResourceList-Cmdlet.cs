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
using Amazon.TrustedAdvisor;
using Amazon.TrustedAdvisor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TA
{
    /// <summary>
    /// List all Trusted Advisor recommendations for a given AWS resource ARN.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "TARecommendationsForResourceList")]
    [OutputType("Amazon.TrustedAdvisor.Model.RecommendationForResourceSummary")]
    [AWSCmdlet("Calls the Trusted Advisor ListRecommendationsForResource API operation.", Operation = new[] {"ListRecommendationsForResource"}, SelectReturnType = typeof(Amazon.TrustedAdvisor.Model.ListRecommendationsForResourceResponse))]
    [AWSCmdletOutput("Amazon.TrustedAdvisor.Model.RecommendationForResourceSummary or Amazon.TrustedAdvisor.Model.ListRecommendationsForResourceResponse",
        "This cmdlet returns a collection of Amazon.TrustedAdvisor.Model.RecommendationForResourceSummary objects.",
        "The service call response (type Amazon.TrustedAdvisor.Model.ListRecommendationsForResourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetTARecommendationsForResourceListCmdlet : AmazonTrustedAdvisorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS resource to query recommendations for</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AwsResourceArn { get; set; }
        #endregion
        
        #region Parameter CheckArn
        /// <summary>
        /// <para>
        /// <para>The AWS Trusted Advisor Check ARN that relates to the Recommendation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CheckArn { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The ISO 639-1 code for the language that you want your recommendations to appear in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.RecommendationLanguage")]
        public Amazon.TrustedAdvisor.RecommendationLanguage Language { get; set; }
        #endregion
        
        #region Parameter Pillar
        /// <summary>
        /// <para>
        /// <para>The pillar that the recommendation belongs to</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.RecommendationPillar")]
        public Amazon.TrustedAdvisor.RecommendationPillar Pillar { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The current status of the Recommendation Resource</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.ResourceStatus")]
        public Amazon.TrustedAdvisor.ResourceStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page</para>
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
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommendationForResourceSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TrustedAdvisor.Model.ListRecommendationsForResourceResponse).
        /// Specifying the name of a property of type Amazon.TrustedAdvisor.Model.ListRecommendationsForResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommendationForResourceSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.TrustedAdvisor.Model.ListRecommendationsForResourceResponse, GetTARecommendationsForResourceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsResourceArn = this.AwsResourceArn;
            #if MODULAR
            if (this.AwsResourceArn == null && ParameterWasBound(nameof(this.AwsResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CheckArn = this.CheckArn;
            context.Language = this.Language;
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
            context.Pillar = this.Pillar;
            context.Status = this.Status;
            
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
            var request = new Amazon.TrustedAdvisor.Model.ListRecommendationsForResourceRequest();
            
            if (cmdletContext.AwsResourceArn != null)
            {
                request.AwsResourceArn = cmdletContext.AwsResourceArn;
            }
            if (cmdletContext.CheckArn != null)
            {
                request.CheckArn = cmdletContext.CheckArn;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Pillar != null)
            {
                request.Pillar = cmdletContext.Pillar;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.TrustedAdvisor.Model.ListRecommendationsForResourceResponse CallAWSServiceOperation(IAmazonTrustedAdvisor client, Amazon.TrustedAdvisor.Model.ListRecommendationsForResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Trusted Advisor", "ListRecommendationsForResource");
            try
            {
                return client.ListRecommendationsForResourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsResourceArn { get; set; }
            public System.String CheckArn { get; set; }
            public Amazon.TrustedAdvisor.RecommendationLanguage Language { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.TrustedAdvisor.RecommendationPillar Pillar { get; set; }
            public Amazon.TrustedAdvisor.ResourceStatus Status { get; set; }
            public System.Func<Amazon.TrustedAdvisor.Model.ListRecommendationsForResourceResponse, GetTARecommendationsForResourceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommendationForResourceSummaries;
        }
        
    }
}
