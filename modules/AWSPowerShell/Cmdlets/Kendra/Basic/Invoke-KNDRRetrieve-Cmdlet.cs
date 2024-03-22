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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Retrieves relevant passages or text excerpts given an input query.
    /// 
    ///  
    /// <para>
    /// This API is similar to the <a href="https://docs.aws.amazon.com/kendra/latest/APIReference/API_Query.html">Query</a>
    /// API. However, by default, the <c>Query</c> API only returns excerpt passages of up
    /// to 100 token words. With the <c>Retrieve</c> API, you can retrieve longer passages
    /// of up to 200 token words and up to 100 semantically relevant passages. This doesn't
    /// include question-answer or FAQ type responses from your index. The passages are text
    /// excerpts that can be semantically extracted from multiple documents and multiple parts
    /// of the same document. If in extreme cases your documents produce zero passages using
    /// the <c>Retrieve</c> API, you can alternatively use the <c>Query</c> API and its types
    /// of responses.
    /// </para><para>
    /// You can also do the following:
    /// </para><ul><li><para>
    /// Override boosting at the index level
    /// </para></li><li><para>
    /// Filter based on document fields or attributes
    /// </para></li><li><para>
    /// Filter based on the user or their group access to documents
    /// </para></li><li><para>
    /// View the confidence score bucket for a retrieved passage result. The confidence bucket
    /// provides a relative ranking that indicates how confident Amazon Kendra is that the
    /// response is relevant to the query.
    /// </para><note><para>
    /// Confidence score buckets are currently available only for English.
    /// </para></note></li></ul><para>
    /// You can also include certain fields in the response that might provide useful additional
    /// information.
    /// </para><para>
    /// The <c>Retrieve</c> API shares the number of <a href="https://docs.aws.amazon.com/kendra/latest/APIReference/API_CapacityUnitsConfiguration.html">query
    /// capacity units</a> that you set for your index. For more information on what's included
    /// in a single capacity unit and the default base capacity for an index, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/adjusting-capacity.html">Adjusting
    /// capacity</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KNDRRetrieve", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kendra.Model.RetrieveResponse")]
    [AWSCmdlet("Calls the Amazon Kendra Retrieve API operation.", Operation = new[] {"Retrieve"}, SelectReturnType = typeof(Amazon.Kendra.Model.RetrieveResponse))]
    [AWSCmdletOutput("Amazon.Kendra.Model.RetrieveResponse",
        "This cmdlet returns an Amazon.Kendra.Model.RetrieveResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeKNDRRetrieveCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeFilter
        /// <summary>
        /// <para>
        /// <para>Filters search results by document fields/attributes. You can only provide one attribute
        /// filter; however, the <c>AndAllFilters</c>, <c>NotFilter</c>, and <c>OrAllFilters</c>
        /// parameters contain a list of other filters.</para><para>The <c>AttributeFilter</c> parameter means you can create a set of filtering rules
        /// that a document must satisfy to be included in the query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Kendra.Model.AttributeFilter AttributeFilter { get; set; }
        #endregion
        
        #region Parameter UserContext_DataSourceGroup
        /// <summary>
        /// <para>
        /// <para>The list of data source groups you want to filter search results based on groups'
        /// access to documents in that data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserContext_DataSourceGroups")]
        public Amazon.Kendra.Model.DataSourceGroup[] UserContext_DataSourceGroup { get; set; }
        #endregion
        
        #region Parameter DocumentRelevanceOverrideConfiguration
        /// <summary>
        /// <para>
        /// <para>Overrides relevance tuning configurations of fields/attributes set at the index level.</para><para>If you use this API to override the relevance tuning configured at the index level,
        /// but there is no relevance tuning configured at the index level, then Amazon Kendra
        /// does not apply any relevance tuning.</para><para>If there is relevance tuning configured for fields at the index level, and you use
        /// this API to override only some of these fields, then for the fields you did not override,
        /// the importance is set to 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentRelevanceOverrideConfigurations")]
        public Amazon.Kendra.Model.DocumentRelevanceConfiguration[] DocumentRelevanceOverrideConfiguration { get; set; }
        #endregion
        
        #region Parameter UserContext_Group
        /// <summary>
        /// <para>
        /// <para>The list of groups you want to filter search results based on the groups' access to
        /// documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserContext_Groups")]
        public System.String[] UserContext_Group { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index to retrieve relevant passages for the search.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter PageNumber
        /// <summary>
        /// <para>
        /// <para>Retrieved relevant passages are returned in pages the size of the <c>PageSize</c>
        /// parameter. By default, Amazon Kendra returns the first page of results. Use this parameter
        /// to get result pages after the first one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageNumber { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The input query text to retrieve relevant passages for the search. Amazon Kendra truncates
        /// queries at 30 token words, which excludes punctuation and stop words. Truncation still
        /// applies if you use Boolean or more advanced, complex queries. For example, <c>Timeoff
        /// AND October AND Category:HR</c> is counted as 3 tokens: <c>timeoff</c>, <c>october</c>,
        /// <c>hr</c>. For more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/searching-example.html#searching-index-query-syntax">Searching
        /// with advanced query syntax</a> in the Amazon Kendra Developer Guide. </para>
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
        public System.String QueryText { get; set; }
        #endregion
        
        #region Parameter RequestedDocumentAttribute
        /// <summary>
        /// <para>
        /// <para>A list of document fields/attributes to include in the response. You can limit the
        /// response to include certain document fields. By default, all document fields are included
        /// in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedDocumentAttributes")]
        public System.String[] RequestedDocumentAttribute { get; set; }
        #endregion
        
        #region Parameter UserContext_Token
        /// <summary>
        /// <para>
        /// <para>The user context token for filtering search results for a user. It must be a JWT or
        /// a JSON token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserContext_Token { get; set; }
        #endregion
        
        #region Parameter UserContext_UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user you want to filter search results based on their access
        /// to documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserContext_UserId { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>Sets the number of retrieved relevant passages that are returned in each page of results.
        /// The default page size is 10. The maximum number of results returned is 100. If you
        /// ask for more than 100 results, only 100 are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.RetrieveResponse).
        /// Specifying the name of a property of type Amazon.Kendra.Model.RetrieveResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QueryText parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QueryText' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QueryText' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IndexId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-KNDRRetrieve (Retrieve)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.RetrieveResponse, InvokeKNDRRetrieveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QueryText;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AttributeFilter = this.AttributeFilter;
            if (this.DocumentRelevanceOverrideConfiguration != null)
            {
                context.DocumentRelevanceOverrideConfiguration = new List<Amazon.Kendra.Model.DocumentRelevanceConfiguration>(this.DocumentRelevanceOverrideConfiguration);
            }
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PageNumber = this.PageNumber;
            context.PageSize = this.PageSize;
            context.QueryText = this.QueryText;
            #if MODULAR
            if (this.QueryText == null && ParameterWasBound(nameof(this.QueryText)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RequestedDocumentAttribute != null)
            {
                context.RequestedDocumentAttribute = new List<System.String>(this.RequestedDocumentAttribute);
            }
            if (this.UserContext_DataSourceGroup != null)
            {
                context.UserContext_DataSourceGroup = new List<Amazon.Kendra.Model.DataSourceGroup>(this.UserContext_DataSourceGroup);
            }
            if (this.UserContext_Group != null)
            {
                context.UserContext_Group = new List<System.String>(this.UserContext_Group);
            }
            context.UserContext_Token = this.UserContext_Token;
            context.UserContext_UserId = this.UserContext_UserId;
            
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
            var request = new Amazon.Kendra.Model.RetrieveRequest();
            
            if (cmdletContext.AttributeFilter != null)
            {
                request.AttributeFilter = cmdletContext.AttributeFilter;
            }
            if (cmdletContext.DocumentRelevanceOverrideConfiguration != null)
            {
                request.DocumentRelevanceOverrideConfigurations = cmdletContext.DocumentRelevanceOverrideConfiguration;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.PageNumber != null)
            {
                request.PageNumber = cmdletContext.PageNumber.Value;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            if (cmdletContext.QueryText != null)
            {
                request.QueryText = cmdletContext.QueryText;
            }
            if (cmdletContext.RequestedDocumentAttribute != null)
            {
                request.RequestedDocumentAttributes = cmdletContext.RequestedDocumentAttribute;
            }
            
             // populate UserContext
            var requestUserContextIsNull = true;
            request.UserContext = new Amazon.Kendra.Model.UserContext();
            List<Amazon.Kendra.Model.DataSourceGroup> requestUserContext_userContext_DataSourceGroup = null;
            if (cmdletContext.UserContext_DataSourceGroup != null)
            {
                requestUserContext_userContext_DataSourceGroup = cmdletContext.UserContext_DataSourceGroup;
            }
            if (requestUserContext_userContext_DataSourceGroup != null)
            {
                request.UserContext.DataSourceGroups = requestUserContext_userContext_DataSourceGroup;
                requestUserContextIsNull = false;
            }
            List<System.String> requestUserContext_userContext_Group = null;
            if (cmdletContext.UserContext_Group != null)
            {
                requestUserContext_userContext_Group = cmdletContext.UserContext_Group;
            }
            if (requestUserContext_userContext_Group != null)
            {
                request.UserContext.Groups = requestUserContext_userContext_Group;
                requestUserContextIsNull = false;
            }
            System.String requestUserContext_userContext_Token = null;
            if (cmdletContext.UserContext_Token != null)
            {
                requestUserContext_userContext_Token = cmdletContext.UserContext_Token;
            }
            if (requestUserContext_userContext_Token != null)
            {
                request.UserContext.Token = requestUserContext_userContext_Token;
                requestUserContextIsNull = false;
            }
            System.String requestUserContext_userContext_UserId = null;
            if (cmdletContext.UserContext_UserId != null)
            {
                requestUserContext_userContext_UserId = cmdletContext.UserContext_UserId;
            }
            if (requestUserContext_userContext_UserId != null)
            {
                request.UserContext.UserId = requestUserContext_userContext_UserId;
                requestUserContextIsNull = false;
            }
             // determine if request.UserContext should be set to null
            if (requestUserContextIsNull)
            {
                request.UserContext = null;
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
        
        private Amazon.Kendra.Model.RetrieveResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.RetrieveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "Retrieve");
            try
            {
                #if DESKTOP
                return client.Retrieve(request);
                #elif CORECLR
                return client.RetrieveAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Kendra.Model.AttributeFilter AttributeFilter { get; set; }
            public List<Amazon.Kendra.Model.DocumentRelevanceConfiguration> DocumentRelevanceOverrideConfiguration { get; set; }
            public System.String IndexId { get; set; }
            public System.Int32? PageNumber { get; set; }
            public System.Int32? PageSize { get; set; }
            public System.String QueryText { get; set; }
            public List<System.String> RequestedDocumentAttribute { get; set; }
            public List<Amazon.Kendra.Model.DataSourceGroup> UserContext_DataSourceGroup { get; set; }
            public List<System.String> UserContext_Group { get; set; }
            public System.String UserContext_Token { get; set; }
            public System.String UserContext_UserId { get; set; }
            public System.Func<Amazon.Kendra.Model.RetrieveResponse, InvokeKNDRRetrieveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
