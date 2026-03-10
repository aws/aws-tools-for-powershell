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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Retrieves the analysis results and recommendations for bot optimization. The analysis
    /// must be in <c>Available</c> status before recommendations can be retrieved.
    /// 
    ///  
    /// <para>
    /// Recommendations are returned with pagination support. Each recommendation includes
    /// the issue location, priority level, detailed description, and proposed fix.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LMBV2BotAnalyzerRecommendationDetail")]
    [OutputType("Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 DescribeBotAnalyzerRecommendation API operation.", Operation = new[] {"DescribeBotAnalyzerRecommendation"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationResponse object containing multiple properties."
    )]
    public partial class GetLMBV2BotAnalyzerRecommendationDetailCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BotAnalyzerRequestId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the analysis request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BotAnalyzerRequestId { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the bot.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BotId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of recommendations to return in the response. The default is 5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the response from a previous request was truncated, the <c>nextToken</c> value
        /// is used to retrieve the next page of recommendations.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationResponse, GetLMBV2BotAnalyzerRecommendationDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BotAnalyzerRequestId = this.BotAnalyzerRequestId;
            #if MODULAR
            if (this.BotAnalyzerRequestId == null && ParameterWasBound(nameof(this.BotAnalyzerRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotAnalyzerRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationRequest();
            
            if (cmdletContext.BotAnalyzerRequestId != null)
            {
                request.BotAnalyzerRequestId = cmdletContext.BotAnalyzerRequestId;
            }
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
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
        
        private Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "DescribeBotAnalyzerRecommendation");
            try
            {
                #if DESKTOP
                return client.DescribeBotAnalyzerRecommendation(request);
                #elif CORECLR
                return client.DescribeBotAnalyzerRecommendationAsync(request).GetAwaiter().GetResult();
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
            public System.String BotAnalyzerRequestId { get; set; }
            public System.String BotId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.DescribeBotAnalyzerRecommendationResponse, GetLMBV2BotAnalyzerRecommendationDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
