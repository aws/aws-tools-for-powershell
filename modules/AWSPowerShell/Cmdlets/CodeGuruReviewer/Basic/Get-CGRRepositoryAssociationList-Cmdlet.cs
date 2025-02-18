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
using Amazon.CodeGuruReviewer;
using Amazon.CodeGuruReviewer.Model;

namespace Amazon.PowerShell.Cmdlets.CGR
{
    /// <summary>
    /// Returns a list of <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-api/API_RepositoryAssociationSummary.html">RepositoryAssociationSummary</a>
    /// objects that contain summary information about a repository association. You can filter
    /// the returned list by <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-api/API_RepositoryAssociationSummary.html#reviewer-Type-RepositoryAssociationSummary-ProviderType">ProviderType</a>,
    /// <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-api/API_RepositoryAssociationSummary.html#reviewer-Type-RepositoryAssociationSummary-Name">Name</a>,
    /// <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-api/API_RepositoryAssociationSummary.html#reviewer-Type-RepositoryAssociationSummary-State">State</a>,
    /// and <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-api/API_RepositoryAssociationSummary.html#reviewer-Type-RepositoryAssociationSummary-Owner">Owner</a>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CGRRepositoryAssociationList")]
    [OutputType("Amazon.CodeGuruReviewer.Model.RepositoryAssociationSummary")]
    [AWSCmdlet("Calls the Amazon CodeGuru Reviewer ListRepositoryAssociations API operation.", Operation = new[] {"ListRepositoryAssociations"}, SelectReturnType = typeof(Amazon.CodeGuruReviewer.Model.ListRepositoryAssociationsResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruReviewer.Model.RepositoryAssociationSummary or Amazon.CodeGuruReviewer.Model.ListRepositoryAssociationsResponse",
        "This cmdlet returns a collection of Amazon.CodeGuruReviewer.Model.RepositoryAssociationSummary objects.",
        "The service call response (type Amazon.CodeGuruReviewer.Model.ListRepositoryAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCGRRepositoryAssociationListCmdlet : AmazonCodeGuruReviewerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>List of repository names to use as a filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Names")]
        public System.String[] Name { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para>List of owners to use as a filter. For Amazon Web Services CodeCommit, it is the name
        /// of the CodeCommit account that was used to associate the repository. For other repository
        /// source providers, such as Bitbucket and GitHub Enterprise Server, this is name of
        /// the account that was used to associate the repository. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Owners")]
        public System.String[] Owner { get; set; }
        #endregion
        
        #region Parameter ProviderType
        /// <summary>
        /// <para>
        /// <para>List of provider types to use as a filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProviderTypes")]
        public System.String[] ProviderType { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>List of repository association states to use as a filter.</para><para>The valid repository association states are:</para><ul><li><para><b>Associated</b>: The repository association is complete.</para></li><li><para><b>Associating</b>: CodeGuru Reviewer is:</para><ul><li><para>Setting up pull request notifications. This is required for pull requests to trigger
        /// a CodeGuru Reviewer review.</para><note><para>If your repository <c>ProviderType</c> is <c>GitHub</c>, <c>GitHub Enterprise Server</c>,
        /// or <c>Bitbucket</c>, CodeGuru Reviewer creates webhooks in your repository to trigger
        /// CodeGuru Reviewer reviews. If you delete these webhooks, reviews of code in your repository
        /// cannot be triggered.</para></note></li><li><para>Setting up source code access. This is required for CodeGuru Reviewer to securely
        /// clone code in your repository.</para></li></ul></li><li><para><b>Failed</b>: The repository failed to associate or disassociate.</para></li><li><para><b>Disassociating</b>: CodeGuru Reviewer is removing the repository's pull request
        /// notifications and source code access.</para></li><li><para><b>Disassociated</b>: CodeGuru Reviewer successfully disassociated the repository.
        /// You can create a new association with this repository if you want to review source
        /// code in it later. You can control access to code reviews created in anassociated repository
        /// with tags after it has been disassociated. For more information, see <a href="https://docs.aws.amazon.com/codeguru/latest/reviewer-ug/auth-and-access-control-using-tags.html">Using
        /// tags to control access to associated repositories</a> in the <i>Amazon CodeGuru Reviewer
        /// User Guide</i>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("States")]
        public System.String[] State { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of repository association results returned by <c>ListRepositoryAssociations</c>
        /// in paginated output. When this parameter is used, <c>ListRepositoryAssociations</c>
        /// only returns <c>maxResults</c> results in a single page with a <c>nextToken</c> response
        /// element. The remaining results of the initial request can be seen by sending another
        /// <c>ListRepositoryAssociations</c> request with the returned <c>nextToken</c> value.
        /// This value can be between 1 and 100. If this parameter is not used, <c>ListRepositoryAssociations</c>
        /// returns up to 100 results and a <c>nextToken</c> value if applicable. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> value returned from a previous paginated <c>ListRepositoryAssociations</c>
        /// request where <c>maxResults</c> was used and the results exceeded the value of that
        /// parameter. Pagination continues from the end of the previous results that returned
        /// the <c>nextToken</c> value. </para><note><para>Treat this token as an opaque identifier that is only used to retrieve the next items
        /// in a list and not for other programmatic purposes.</para></note>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RepositoryAssociationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruReviewer.Model.ListRepositoryAssociationsResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruReviewer.Model.ListRepositoryAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RepositoryAssociationSummaries";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruReviewer.Model.ListRepositoryAssociationsResponse, GetCGRRepositoryAssociationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            if (this.Name != null)
            {
                context.Name = new List<System.String>(this.Name);
            }
            context.NextToken = this.NextToken;
            if (this.Owner != null)
            {
                context.Owner = new List<System.String>(this.Owner);
            }
            if (this.ProviderType != null)
            {
                context.ProviderType = new List<System.String>(this.ProviderType);
            }
            if (this.State != null)
            {
                context.State = new List<System.String>(this.State);
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.CodeGuruReviewer.Model.ListRepositoryAssociationsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Names = cmdletContext.Name;
            }
            if (cmdletContext.Owner != null)
            {
                request.Owners = cmdletContext.Owner;
            }
            if (cmdletContext.ProviderType != null)
            {
                request.ProviderTypes = cmdletContext.ProviderType;
            }
            if (cmdletContext.State != null)
            {
                request.States = cmdletContext.State;
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
        
        private Amazon.CodeGuruReviewer.Model.ListRepositoryAssociationsResponse CallAWSServiceOperation(IAmazonCodeGuruReviewer client, Amazon.CodeGuruReviewer.Model.ListRepositoryAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Reviewer", "ListRepositoryAssociations");
            try
            {
                return client.ListRepositoryAssociationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Name { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> Owner { get; set; }
            public List<System.String> ProviderType { get; set; }
            public List<System.String> State { get; set; }
            public System.Func<Amazon.CodeGuruReviewer.Model.ListRepositoryAssociationsResponse, GetCGRRepositoryAssociationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RepositoryAssociationSummaries;
        }
        
    }
}
