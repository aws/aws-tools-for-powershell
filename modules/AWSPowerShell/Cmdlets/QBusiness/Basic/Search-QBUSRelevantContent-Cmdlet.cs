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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Searches for relevant content in a Amazon Q Business application based on a query.
    /// This operation takes a search query text, the Amazon Q Business application identifier,
    /// and optional filters (such as content source and maximum results) as input. It returns
    /// a list of relevant content items, where each item includes the content text, the unique
    /// document identifier, the document title, the document URI, any relevant document attributes,
    /// and score attributes indicating the confidence level of the relevance.
    /// </summary>
    [Cmdlet("Search", "QBUSRelevantContent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QBusiness.Model.RelevantContent")]
    [AWSCmdlet("Calls the Amazon QBusiness SearchRelevantContent API operation.", Operation = new[] {"SearchRelevantContent"}, SelectReturnType = typeof(Amazon.QBusiness.Model.SearchRelevantContentResponse))]
    [AWSCmdletOutput("Amazon.QBusiness.Model.RelevantContent or Amazon.QBusiness.Model.SearchRelevantContentResponse",
        "This cmdlet returns a collection of Amazon.QBusiness.Model.RelevantContent objects.",
        "The service call response (type Amazon.QBusiness.Model.SearchRelevantContentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchQBUSRelevantContentCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon Q Business application to search.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter AttributeFilter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QBusiness.Model.AttributeFilter AttributeFilter { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The text to search for.</para>
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
        public System.String QueryText { get; set; }
        #endregion
        
        #region Parameter Retriever_RetrieverId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the retriever to use as the content source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContentSource_Retriever_RetrieverId")]
        public System.String Retriever_RetrieverId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. (You received this token from a previous call.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RelevantContent'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.SearchRelevantContentResponse).
        /// Specifying the name of a property of type Amazon.QBusiness.Model.SearchRelevantContentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RelevantContent";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-QBUSRelevantContent (SearchRelevantContent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.SearchRelevantContentResponse, SearchQBUSRelevantContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttributeFilter = this.AttributeFilter;
            context.Retriever_RetrieverId = this.Retriever_RetrieverId;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.QueryText = this.QueryText;
            #if MODULAR
            if (this.QueryText == null && ParameterWasBound(nameof(this.QueryText)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QBusiness.Model.SearchRelevantContentRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.AttributeFilter != null)
            {
                request.AttributeFilter = cmdletContext.AttributeFilter;
            }
            
             // populate ContentSource
            var requestContentSourceIsNull = true;
            request.ContentSource = new Amazon.QBusiness.Model.ContentSource();
            Amazon.QBusiness.Model.RetrieverContentSource requestContentSource_contentSource_Retriever = null;
            
             // populate Retriever
            var requestContentSource_contentSource_RetrieverIsNull = true;
            requestContentSource_contentSource_Retriever = new Amazon.QBusiness.Model.RetrieverContentSource();
            System.String requestContentSource_contentSource_Retriever_retriever_RetrieverId = null;
            if (cmdletContext.Retriever_RetrieverId != null)
            {
                requestContentSource_contentSource_Retriever_retriever_RetrieverId = cmdletContext.Retriever_RetrieverId;
            }
            if (requestContentSource_contentSource_Retriever_retriever_RetrieverId != null)
            {
                requestContentSource_contentSource_Retriever.RetrieverId = requestContentSource_contentSource_Retriever_retriever_RetrieverId;
                requestContentSource_contentSource_RetrieverIsNull = false;
            }
             // determine if requestContentSource_contentSource_Retriever should be set to null
            if (requestContentSource_contentSource_RetrieverIsNull)
            {
                requestContentSource_contentSource_Retriever = null;
            }
            if (requestContentSource_contentSource_Retriever != null)
            {
                request.ContentSource.Retriever = requestContentSource_contentSource_Retriever;
                requestContentSourceIsNull = false;
            }
             // determine if request.ContentSource should be set to null
            if (requestContentSourceIsNull)
            {
                request.ContentSource = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.QueryText != null)
            {
                request.QueryText = cmdletContext.QueryText;
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
        
        private Amazon.QBusiness.Model.SearchRelevantContentResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.SearchRelevantContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "SearchRelevantContent");
            try
            {
                #if DESKTOP
                return client.SearchRelevantContent(request);
                #elif CORECLR
                return client.SearchRelevantContentAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public Amazon.QBusiness.Model.AttributeFilter AttributeFilter { get; set; }
            public System.String Retriever_RetrieverId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String QueryText { get; set; }
            public System.Func<Amazon.QBusiness.Model.SearchRelevantContentResponse, SearchQBUSRelevantContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RelevantContent;
        }
        
    }
}
