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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Searches existing Amazon Q quick responses in a Amazon Q knowledge base.
    /// </summary>
    [Cmdlet("Search", "QCQuickResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.QuickResponseSearchResultData")]
    [AWSCmdlet("Calls the Amazon Q Connect SearchQuickResponses API operation.", Operation = new[] {"SearchQuickResponses"}, SelectReturnType = typeof(Amazon.QConnect.Model.SearchQuickResponsesResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.QuickResponseSearchResultData or Amazon.QConnect.Model.SearchQuickResponsesResponse",
        "This cmdlet returns a collection of Amazon.QConnect.Model.QuickResponseSearchResultData objects.",
        "The service call response (type Amazon.QConnect.Model.SearchQuickResponsesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchQCQuickResponseCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/connect/latest/adminguide/connect-attrib-list.html#user-defined-attributes">user-defined
        /// Amazon Connect contact attributes</a> to be resolved when search results are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter SearchExpression_Filter
        /// <summary>
        /// <para>
        /// <para>The configuration of filtering rules applied to quick response query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchExpression_Filters")]
        public Amazon.QConnect.Model.QuickResponseFilterField[] SearchExpression_Filter { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base. This should be a QUICK_RESPONSES type knowledge
        /// base. Can be either the ID or the ARN. URLs cannot contain the ARN.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter OrderOnField_Name
        /// <summary>
        /// <para>
        /// <para>The name of the attribute to order the quick response query results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchExpression_OrderOnField_Name")]
        public System.String OrderOnField_Name { get; set; }
        #endregion
        
        #region Parameter OrderOnField_Order
        /// <summary>
        /// <para>
        /// <para>The order at which the quick responses are sorted by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchExpression_OrderOnField_Order")]
        [AWSConstantClassSource("Amazon.QConnect.Order")]
        public Amazon.QConnect.Order OrderOnField_Order { get; set; }
        #endregion
        
        #region Parameter SearchExpression_Query
        /// <summary>
        /// <para>
        /// <para>The quick response query expressions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchExpression_Queries")]
        public Amazon.QConnect.Model.QuickResponseQueryField[] SearchExpression_Query { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.SearchQuickResponsesResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.SearchQuickResponsesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KnowledgeBaseId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KnowledgeBaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-QCQuickResponse (SearchQuickResponses)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.SearchQuickResponsesResponse, SearchQCQuickResponseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KnowledgeBaseId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SearchExpression_Filter != null)
            {
                context.SearchExpression_Filter = new List<Amazon.QConnect.Model.QuickResponseFilterField>(this.SearchExpression_Filter);
            }
            context.OrderOnField_Name = this.OrderOnField_Name;
            context.OrderOnField_Order = this.OrderOnField_Order;
            if (this.SearchExpression_Query != null)
            {
                context.SearchExpression_Query = new List<Amazon.QConnect.Model.QuickResponseQueryField>(this.SearchExpression_Query);
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
            // create request
            var request = new Amazon.QConnect.Model.SearchQuickResponsesRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
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
            request.SearchExpression = new Amazon.QConnect.Model.QuickResponseSearchExpression();
            List<Amazon.QConnect.Model.QuickResponseFilterField> requestSearchExpression_searchExpression_Filter = null;
            if (cmdletContext.SearchExpression_Filter != null)
            {
                requestSearchExpression_searchExpression_Filter = cmdletContext.SearchExpression_Filter;
            }
            if (requestSearchExpression_searchExpression_Filter != null)
            {
                request.SearchExpression.Filters = requestSearchExpression_searchExpression_Filter;
                requestSearchExpressionIsNull = false;
            }
            List<Amazon.QConnect.Model.QuickResponseQueryField> requestSearchExpression_searchExpression_Query = null;
            if (cmdletContext.SearchExpression_Query != null)
            {
                requestSearchExpression_searchExpression_Query = cmdletContext.SearchExpression_Query;
            }
            if (requestSearchExpression_searchExpression_Query != null)
            {
                request.SearchExpression.Queries = requestSearchExpression_searchExpression_Query;
                requestSearchExpressionIsNull = false;
            }
            Amazon.QConnect.Model.QuickResponseOrderField requestSearchExpression_searchExpression_OrderOnField = null;
            
             // populate OrderOnField
            var requestSearchExpression_searchExpression_OrderOnFieldIsNull = true;
            requestSearchExpression_searchExpression_OrderOnField = new Amazon.QConnect.Model.QuickResponseOrderField();
            System.String requestSearchExpression_searchExpression_OrderOnField_orderOnField_Name = null;
            if (cmdletContext.OrderOnField_Name != null)
            {
                requestSearchExpression_searchExpression_OrderOnField_orderOnField_Name = cmdletContext.OrderOnField_Name;
            }
            if (requestSearchExpression_searchExpression_OrderOnField_orderOnField_Name != null)
            {
                requestSearchExpression_searchExpression_OrderOnField.Name = requestSearchExpression_searchExpression_OrderOnField_orderOnField_Name;
                requestSearchExpression_searchExpression_OrderOnFieldIsNull = false;
            }
            Amazon.QConnect.Order requestSearchExpression_searchExpression_OrderOnField_orderOnField_Order = null;
            if (cmdletContext.OrderOnField_Order != null)
            {
                requestSearchExpression_searchExpression_OrderOnField_orderOnField_Order = cmdletContext.OrderOnField_Order;
            }
            if (requestSearchExpression_searchExpression_OrderOnField_orderOnField_Order != null)
            {
                requestSearchExpression_searchExpression_OrderOnField.Order = requestSearchExpression_searchExpression_OrderOnField_orderOnField_Order;
                requestSearchExpression_searchExpression_OrderOnFieldIsNull = false;
            }
             // determine if requestSearchExpression_searchExpression_OrderOnField should be set to null
            if (requestSearchExpression_searchExpression_OrderOnFieldIsNull)
            {
                requestSearchExpression_searchExpression_OrderOnField = null;
            }
            if (requestSearchExpression_searchExpression_OrderOnField != null)
            {
                request.SearchExpression.OrderOnField = requestSearchExpression_searchExpression_OrderOnField;
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
        
        private Amazon.QConnect.Model.SearchQuickResponsesResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.SearchQuickResponsesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "SearchQuickResponses");
            try
            {
                #if DESKTOP
                return client.SearchQuickResponses(request);
                #elif CORECLR
                return client.SearchQuickResponsesAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.QConnect.Model.QuickResponseFilterField> SearchExpression_Filter { get; set; }
            public System.String OrderOnField_Name { get; set; }
            public Amazon.QConnect.Order OrderOnField_Order { get; set; }
            public List<Amazon.QConnect.Model.QuickResponseQueryField> SearchExpression_Query { get; set; }
            public System.Func<Amazon.QConnect.Model.SearchQuickResponsesResponse, SearchQCQuickResponseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
