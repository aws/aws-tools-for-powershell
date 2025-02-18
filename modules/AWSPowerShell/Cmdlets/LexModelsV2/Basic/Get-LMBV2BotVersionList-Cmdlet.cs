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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Gets information about all of the versions of a bot.
    /// 
    ///  
    /// <para>
    /// The <c>ListBotVersions</c> operation returns a summary of each version of a bot. For
    /// example, if a bot has three numbered versions, the <c>ListBotVersions</c> operation
    /// returns for summaries, one for each numbered version and one for the <c>DRAFT</c>
    /// version.
    /// </para><para>
    /// The <c>ListBotVersions</c> operation always returns at least one version, the <c>DRAFT</c>
    /// version.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LMBV2BotVersionList")]
    [OutputType("Amazon.LexModelsV2.Model.ListBotVersionsResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 ListBotVersions API operation.", Operation = new[] {"ListBotVersions"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.ListBotVersionsResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.ListBotVersionsResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.ListBotVersionsResponse object containing multiple properties."
    )]
    public partial class GetLMBV2BotVersionListCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SortBy_Attribute
        /// <summary>
        /// <para>
        /// <para>The attribute to use to sort the list of versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.BotVersionSortAttribute")]
        public Amazon.LexModelsV2.BotVersionSortAttribute SortBy_Attribute { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot to list versions for.</para>
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
        public System.String BotId { get; set; }
        #endregion
        
        #region Parameter SortBy_Order
        /// <summary>
        /// <para>
        /// <para>The order to sort the list. You can specify ascending or descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.SortOrder")]
        public Amazon.LexModelsV2.SortOrder SortBy_Order { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of versions to return in each page of results. If there are fewer
        /// results than the max page size, only the actual number of results are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the response to the <c>ListBotVersion</c> operation contains more results than
        /// specified in the <c>maxResults</c> parameter, a token is returned in the response.
        /// Use that token in the <c>nextToken</c> parameter to return the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.ListBotVersionsResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.ListBotVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.ListBotVersionsResponse, GetLMBV2BotVersionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy_Attribute = this.SortBy_Attribute;
            context.SortBy_Order = this.SortBy_Order;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.LexModelsV2.Model.ListBotVersionsRequest();
            
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate SortBy
            var requestSortByIsNull = true;
            request.SortBy = new Amazon.LexModelsV2.Model.BotVersionSortBy();
            Amazon.LexModelsV2.BotVersionSortAttribute requestSortBy_sortBy_Attribute = null;
            if (cmdletContext.SortBy_Attribute != null)
            {
                requestSortBy_sortBy_Attribute = cmdletContext.SortBy_Attribute;
            }
            if (requestSortBy_sortBy_Attribute != null)
            {
                request.SortBy.Attribute = requestSortBy_sortBy_Attribute;
                requestSortByIsNull = false;
            }
            Amazon.LexModelsV2.SortOrder requestSortBy_sortBy_Order = null;
            if (cmdletContext.SortBy_Order != null)
            {
                requestSortBy_sortBy_Order = cmdletContext.SortBy_Order;
            }
            if (requestSortBy_sortBy_Order != null)
            {
                request.SortBy.Order = requestSortBy_sortBy_Order;
                requestSortByIsNull = false;
            }
             // determine if request.SortBy should be set to null
            if (requestSortByIsNull)
            {
                request.SortBy = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LexModelsV2.Model.ListBotVersionsResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.ListBotVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "ListBotVersions");
            try
            {
                return client.ListBotVersionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BotId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.LexModelsV2.BotVersionSortAttribute SortBy_Attribute { get; set; }
            public Amazon.LexModelsV2.SortOrder SortBy_Order { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.ListBotVersionsResponse, GetLMBV2BotVersionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
