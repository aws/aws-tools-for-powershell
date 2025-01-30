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
using Amazon.ConnectWisdomService;
using Amazon.ConnectWisdomService.Model;

namespace Amazon.PowerShell.Cmdlets.WSDM
{
    /// <summary>
    /// Searches for sessions.
    /// </summary>
    [Cmdlet("Search", "WSDMSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectWisdomService.Model.SessionSummary")]
    [AWSCmdlet("Calls the Amazon Connect Wisdom Service SearchSessions API operation.", Operation = new[] {"SearchSessions"}, SelectReturnType = typeof(Amazon.ConnectWisdomService.Model.SearchSessionsResponse))]
    [AWSCmdletOutput("Amazon.ConnectWisdomService.Model.SessionSummary or Amazon.ConnectWisdomService.Model.SearchSessionsResponse",
        "This cmdlet returns a collection of Amazon.ConnectWisdomService.Model.SessionSummary objects.",
        "The service call response (type Amazon.ConnectWisdomService.Model.SearchSessionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchWSDMSessionCmdlet : AmazonConnectWisdomServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssistantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Wisdom assistant. Can be either the ID or the ARN. URLs cannot
        /// contain the ARN.</para>
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
        public System.String AssistantId { get; set; }
        #endregion
        
        #region Parameter SearchExpression_Filter
        /// <summary>
        /// <para>
        /// <para>The search expression filters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SearchExpression_Filters")]
        public Amazon.ConnectWisdomService.Model.Filter[] SearchExpression_Filter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SessionSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectWisdomService.Model.SearchSessionsResponse).
        /// Specifying the name of a property of type Amazon.ConnectWisdomService.Model.SearchSessionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SessionSummaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssistantId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssistantId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssistantId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssistantId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-WSDMSession (SearchSessions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectWisdomService.Model.SearchSessionsResponse, SearchWSDMSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssistantId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SearchExpression_Filter != null)
            {
                context.SearchExpression_Filter = new List<Amazon.ConnectWisdomService.Model.Filter>(this.SearchExpression_Filter);
            }
            #if MODULAR
            if (this.SearchExpression_Filter == null && ParameterWasBound(nameof(this.SearchExpression_Filter)))
            {
                WriteWarning("You are passing $null as a value for parameter SearchExpression_Filter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ConnectWisdomService.Model.SearchSessionsRequest();
            
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate SearchExpression
            var requestSearchExpressionIsNull = true;
            request.SearchExpression = new Amazon.ConnectWisdomService.Model.SearchExpression();
            List<Amazon.ConnectWisdomService.Model.Filter> requestSearchExpression_searchExpression_Filter = null;
            if (cmdletContext.SearchExpression_Filter != null)
            {
                requestSearchExpression_searchExpression_Filter = cmdletContext.SearchExpression_Filter;
            }
            if (requestSearchExpression_searchExpression_Filter != null)
            {
                request.SearchExpression.Filters = requestSearchExpression_searchExpression_Filter;
                requestSearchExpressionIsNull = false;
            }
             // determine if request.SearchExpression should be set to null
            if (requestSearchExpressionIsNull)
            {
                request.SearchExpression = null;
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
        
        private Amazon.ConnectWisdomService.Model.SearchSessionsResponse CallAWSServiceOperation(IAmazonConnectWisdomService client, Amazon.ConnectWisdomService.Model.SearchSessionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Wisdom Service", "SearchSessions");
            try
            {
                #if DESKTOP
                return client.SearchSessions(request);
                #elif CORECLR
                return client.SearchSessionsAsync(request).GetAwaiter().GetResult();
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
            public System.String AssistantId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.ConnectWisdomService.Model.Filter> SearchExpression_Filter { get; set; }
            public System.Func<Amazon.ConnectWisdomService.Model.SearchSessionsResponse, SearchWSDMSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SessionSummaries;
        }
        
    }
}
