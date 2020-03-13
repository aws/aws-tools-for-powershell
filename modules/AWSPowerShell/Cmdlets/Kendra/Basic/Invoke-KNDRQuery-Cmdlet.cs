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
    /// Searches an active index. Use this API to search your documents using query. The <code>Query</code>
    /// operation enables to do faceted search and to filter results based on document attributes.
    /// 
    ///  
    /// <para>
    /// It also enables you to provide user context that Amazon Kendra uses to enforce document
    /// access control in the search results. 
    /// </para><para>
    /// Amazon Kendra searches your index for text content and question and answer (FAQ) content.
    /// By default the response contains three types of results.
    /// </para><ul><li><para>
    /// Relevant passages
    /// </para></li><li><para>
    /// Matching FAQs
    /// </para></li><li><para>
    /// Relevant documents
    /// </para></li></ul><para>
    /// You can specify that the query return only one type of result using the <code>QueryResultTypeConfig</code>
    /// parameter.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KNDRQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kendra.Model.QueryResponse")]
    [AWSCmdlet("Calls the Amazon Kendra Query API operation.", Operation = new[] {"Query"}, SelectReturnType = typeof(Amazon.Kendra.Model.QueryResponse))]
    [AWSCmdletOutput("Amazon.Kendra.Model.QueryResponse",
        "This cmdlet returns an Amazon.Kendra.Model.QueryResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeKNDRQueryCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeFilter
        /// <summary>
        /// <para>
        /// <para>Enables filtered searches based on document attributes. You can only provide one attribute
        /// filter; however, the <code>AndAllFilters</code>, <code>NotFilter</code>, and <code>OrAllFilters</code>
        /// parameters contain a list of other filters.</para><para>The <code>AttributeFilter</code> parameter enables you to create a set of filtering
        /// rules that a document must satisfy to be included in the query results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Kendra.Model.AttributeFilter AttributeFilter { get; set; }
        #endregion
        
        #region Parameter Facet
        /// <summary>
        /// <para>
        /// <para>An array of documents attributes. Amazon Kendra returns a count for each attribute
        /// key specified. You can use this information to help narrow the search for your user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Facets")]
        public Amazon.Kendra.Model.Facet[] Facet { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the index to search. The identifier is returned in the response
        /// from the operation.</para>
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
        /// <para>Query results are returned in pages the size of the <code>PageSize</code> parameter.
        /// By default, Amazon Kendra returns the first page of results. Use this parameter to
        /// get result pages after the first one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageNumber { get; set; }
        #endregion
        
        #region Parameter QueryResultTypeFilter
        /// <summary>
        /// <para>
        /// <para>Sets the type of query. Only results for the specified query type are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kendra.QueryResultType")]
        public Amazon.Kendra.QueryResultType QueryResultTypeFilter { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The text to search for.</para>
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
        /// <para>An array of document attributes to include in the response. No other document attributes
        /// are included in the response. By default all document attributes are included in the
        /// response. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedDocumentAttributes")]
        public System.String[] RequestedDocumentAttribute { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>Sets the number of results that are returned in each page of results. The default
        /// page size is 10. The maximum number of results returned is 100. If you ask for more
        /// than 100 results, only 100 are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.QueryResponse).
        /// Specifying the name of a property of type Amazon.Kendra.Model.QueryResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IndexId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-KNDRQuery (Query)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.QueryResponse, InvokeKNDRQueryCmdlet>(Select) ??
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
            if (this.Facet != null)
            {
                context.Facet = new List<Amazon.Kendra.Model.Facet>(this.Facet);
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
            context.QueryResultTypeFilter = this.QueryResultTypeFilter;
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
            var request = new Amazon.Kendra.Model.QueryRequest();
            
            if (cmdletContext.AttributeFilter != null)
            {
                request.AttributeFilter = cmdletContext.AttributeFilter;
            }
            if (cmdletContext.Facet != null)
            {
                request.Facets = cmdletContext.Facet;
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
            if (cmdletContext.QueryResultTypeFilter != null)
            {
                request.QueryResultTypeFilter = cmdletContext.QueryResultTypeFilter;
            }
            if (cmdletContext.QueryText != null)
            {
                request.QueryText = cmdletContext.QueryText;
            }
            if (cmdletContext.RequestedDocumentAttribute != null)
            {
                request.RequestedDocumentAttributes = cmdletContext.RequestedDocumentAttribute;
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
        
        private Amazon.Kendra.Model.QueryResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.QueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "Query");
            try
            {
                #if DESKTOP
                return client.Query(request);
                #elif CORECLR
                return client.QueryAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Kendra.Model.Facet> Facet { get; set; }
            public System.String IndexId { get; set; }
            public System.Int32? PageNumber { get; set; }
            public System.Int32? PageSize { get; set; }
            public Amazon.Kendra.QueryResultType QueryResultTypeFilter { get; set; }
            public System.String QueryText { get; set; }
            public List<System.String> RequestedDocumentAttribute { get; set; }
            public System.Func<Amazon.Kendra.Model.QueryResponse, InvokeKNDRQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
