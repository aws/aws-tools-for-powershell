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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Returns a structured, line-level diff between two blob versions in a repository. The
    /// diff is returned as an ordered list of hunks, where each hunk represents a contiguous
    /// run of changed lines together with any surrounding unchanged context lines.
    /// 
    ///  
    /// <para>
    /// Results are paginated. Use <c>MaxResults</c> and <c>NextToken</c> to retrieve additional
    /// pages.
    /// </para><para>
    /// For the typical usage workflow, see <a>GetDifferences</a>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CCBlobDifference")]
    [OutputType("Amazon.CodeCommit.Model.GetBlobDifferencesResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit GetBlobDifferences API operation.", Operation = new[] {"GetBlobDifferences"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.GetBlobDifferencesResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.GetBlobDifferencesResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.GetBlobDifferencesResponse object containing multiple properties."
    )]
    public partial class GetCCBlobDifferenceCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AfterBlobId
        /// <summary>
        /// <para>
        /// <para>The ID of the "after" (destination) blob in the diff. Typically the value of <c>afterBlob.blobId</c>
        /// from a <c>Difference</c> object returned by <a>GetDifferences</a>.</para>
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
        public System.String AfterBlobId { get; set; }
        #endregion
        
        #region Parameter BeforeBlobId
        /// <summary>
        /// <para>
        /// <para>The ID of the "before" (source) blob in the diff. Typically the value of <c>beforeBlob.blobId</c>
        /// from a <c>Difference</c> object returned by <a>GetDifferences</a>.</para><para>If you do not specify a value, the operation returns a diff against an empty before-state.
        /// This is equivalent to treating the file as newly added.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BeforeBlobId { get; set; }
        #endregion
        
        #region Parameter ContextLine
        /// <summary>
        /// <para>
        /// <para>The number of unchanged lines of context to include before and after each block of
        /// changes in a hunk. Valid values are 0 through 20. Defaults to <c>3</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContextLines")]
        public System.Int32? ContextLine { get; set; }
        #endregion
        
        #region Parameter IgnoreWhitespace
        /// <summary>
        /// <para>
        /// <para>Specifies whether to ignore whitespace-only changes when computing the diff. When
        /// <c>true</c>, the operation treats lines that differ only in whitespace as unchanged.
        /// Defaults to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IgnoreWhitespace { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository that contains the blobs to compare.</para>
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
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of <c>DiffHunk</c> entries to return in a single response page.
        /// Defaults to <c>100</c>.</para>
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
        /// <para>An enumeration token that returns the next batch of results when present in a request.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.GetBlobDifferencesResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.GetBlobDifferencesResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.GetBlobDifferencesResponse, GetCCBlobDifferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AfterBlobId = this.AfterBlobId;
            #if MODULAR
            if (this.AfterBlobId == null && ParameterWasBound(nameof(this.AfterBlobId)))
            {
                WriteWarning("You are passing $null as a value for parameter AfterBlobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BeforeBlobId = this.BeforeBlobId;
            context.ContextLine = this.ContextLine;
            context.IgnoreWhitespace = this.IgnoreWhitespace;
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
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.CodeCommit.Model.GetBlobDifferencesRequest();
            
            if (cmdletContext.AfterBlobId != null)
            {
                request.AfterBlobId = cmdletContext.AfterBlobId;
            }
            if (cmdletContext.BeforeBlobId != null)
            {
                request.BeforeBlobId = cmdletContext.BeforeBlobId;
            }
            if (cmdletContext.ContextLine != null)
            {
                request.ContextLines = cmdletContext.ContextLine.Value;
            }
            if (cmdletContext.IgnoreWhitespace != null)
            {
                request.IgnoreWhitespace = cmdletContext.IgnoreWhitespace.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
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
        
        private Amazon.CodeCommit.Model.GetBlobDifferencesResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.GetBlobDifferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "GetBlobDifferences");
            try
            {
                return client.GetBlobDifferencesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AfterBlobId { get; set; }
            public System.String BeforeBlobId { get; set; }
            public System.Int32? ContextLine { get; set; }
            public System.Boolean? IgnoreWhitespace { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String RepositoryName { get; set; }
            public System.Func<Amazon.CodeCommit.Model.GetBlobDifferencesResponse, GetCCBlobDifferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
