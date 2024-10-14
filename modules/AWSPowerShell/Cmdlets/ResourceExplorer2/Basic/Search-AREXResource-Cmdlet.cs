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
using Amazon.ResourceExplorer2;
using Amazon.ResourceExplorer2.Model;

namespace Amazon.PowerShell.Cmdlets.AREX
{
    /// <summary>
    /// Searches for resources and displays details about all resources that match the specified
    /// criteria. You must specify a query string.
    /// 
    ///  
    /// <para>
    /// All search queries must use a view. If you don't explicitly specify a view, then Amazon
    /// Web Services Resource Explorer uses the default view for the Amazon Web Services Region
    /// in which you call this operation. The results are the logical intersection of the
    /// results that match both the <c>QueryString</c> parameter supplied to this operation
    /// and the <c>SearchFilter</c> parameter attached to the view.
    /// </para><para>
    /// For the complete syntax supported by the <c>QueryString</c> parameter, see <a href="https://docs.aws.amazon.com/resource-explorer/latest/APIReference/about-query-syntax.html">Search
    /// query syntax reference for Resource Explorer</a>.
    /// </para><para>
    /// If your search results are empty, or are missing results that you think should be
    /// there, see <a href="https://docs.aws.amazon.com/resource-explorer/latest/userguide/troubleshooting_search.html">Troubleshooting
    /// Resource Explorer search</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Search", "AREXResource")]
    [OutputType("Amazon.ResourceExplorer2.Model.SearchResponse")]
    [AWSCmdlet("Calls the AWS Resource Explorer Search API operation.", Operation = new[] {"Search"}, SelectReturnType = typeof(Amazon.ResourceExplorer2.Model.SearchResponse))]
    [AWSCmdletOutput("Amazon.ResourceExplorer2.Model.SearchResponse",
        "This cmdlet returns an Amazon.ResourceExplorer2.Model.SearchResponse object containing multiple properties."
    )]
    public partial class SearchAREXResourceCmdlet : AmazonResourceExplorer2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para>A string that includes keywords and filters that specify the resources that you want
        /// to include in the results.</para><para>For the complete syntax supported by the <c>QueryString</c> parameter, see <a href="https://docs.aws.amazon.com/resource-explorer/latest/userguide/using-search-query-syntax.html">Search
        /// query syntax reference for Resource Explorer</a>.</para><para>The search is completely case insensitive. You can specify an empty string to return
        /// all results up to the limit of 1,000 total results.</para><note><para>The operation can return only the first 1,000 results. If the resource you want is
        /// not included, then use a different value for <c>QueryString</c> to refine the results.</para></note>
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
        public System.String QueryString { get; set; }
        #endregion
        
        #region Parameter ViewArn
        /// <summary>
        /// <para>
        /// <para>Specifies the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// resource name (ARN)</a> of the view to use for the query. If you don't specify a value
        /// for this parameter, then the operation automatically uses the default view for the
        /// Amazon Web Services Region in which you called this operation. If the Region either
        /// doesn't have a default view or if you don't have permission to use the default view,
        /// then the operation fails with a <c>401 Unauthorized</c> exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ViewArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that you want included on each page of the response.
        /// If you do not include this parameter, it defaults to a value appropriate to the operation.
        /// If additional items exist beyond those included in the current response, the <c>NextToken</c>
        /// response element is present and has a value (is not null). Include that value as the
        /// <c>NextToken</c> request parameter in the next call to the operation to get the next
        /// part of the results.</para><note><para>An API operation can return fewer results than the maximum even when there are more
        /// results available. You should check <c>NextToken</c> after every operation to ensure
        /// that you receive all of the results.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The parameter for receiving additional results if you receive a <c>NextToken</c> response
        /// in a previous request. A <c>NextToken</c> response indicates that more output is available.
        /// Set this parameter to the value of the previous call's <c>NextToken</c> response to
        /// indicate where the output should continue from. The pagination tokens expire after
        /// 24 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceExplorer2.Model.SearchResponse).
        /// Specifying the name of a property of type Amazon.ResourceExplorer2.Model.SearchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QueryString parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QueryString' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QueryString' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.ResourceExplorer2.Model.SearchResponse, SearchAREXResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QueryString;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.QueryString = this.QueryString;
            #if MODULAR
            if (this.QueryString == null && ParameterWasBound(nameof(this.QueryString)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ViewArn = this.ViewArn;
            
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
            var request = new Amazon.ResourceExplorer2.Model.SearchRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.QueryString != null)
            {
                request.QueryString = cmdletContext.QueryString;
            }
            if (cmdletContext.ViewArn != null)
            {
                request.ViewArn = cmdletContext.ViewArn;
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
        
        private Amazon.ResourceExplorer2.Model.SearchResponse CallAWSServiceOperation(IAmazonResourceExplorer2 client, Amazon.ResourceExplorer2.Model.SearchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Explorer", "Search");
            try
            {
                #if DESKTOP
                return client.Search(request);
                #elif CORECLR
                return client.SearchAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String QueryString { get; set; }
            public System.String ViewArn { get; set; }
            public System.Func<Amazon.ResourceExplorer2.Model.SearchResponse, SearchAREXResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
