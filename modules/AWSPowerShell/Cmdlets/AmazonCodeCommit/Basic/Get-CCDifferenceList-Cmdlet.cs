/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Returns information about the differences in a valid commit specifier (such as a branch,
    /// tag, HEAD, commit ID or other fully qualified reference). Results can be limited to
    /// a specified path.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "CCDifferenceList")]
    [OutputType("Amazon.CodeCommit.Model.Difference")]
    [AWSCmdlet("Invokes the GetDifferences operation against AWS CodeCommit.", Operation = new[] {"GetDifferences"})]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.Difference",
        "This cmdlet returns a collection of Difference objects.",
        "The service call response (type Amazon.CodeCommit.Model.GetDifferencesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCCDifferenceListCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter AfterCommitSpecifier
        /// <summary>
        /// <para>
        /// <para>The branch, tag, HEAD, or other fully qualified reference used to identify a commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AfterCommitSpecifier { get; set; }
        #endregion
        
        #region Parameter AfterPath
        /// <summary>
        /// <para>
        /// <para>The file path in which to check differences. Limits the results to this path. Can
        /// also be used to specify the changed name of a directory or folder, if it has changed.
        /// If not specified, differences will be shown for all paths.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AfterPath { get; set; }
        #endregion
        
        #region Parameter BeforeCommitSpecifier
        /// <summary>
        /// <para>
        /// <para>The branch, tag, HEAD, or other fully qualified reference used to identify a commit.
        /// For example, the full commit ID. Optional. If not specified, all changes prior to
        /// the <code>afterCommitSpecifier</code> value will be shown. If you do not use <code>beforeCommitSpecifier</code>
        /// in your request, consider limiting the results with <code>maxResults</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BeforeCommitSpecifier { get; set; }
        #endregion
        
        #region Parameter BeforePath
        /// <summary>
        /// <para>
        /// <para>The file path in which to check for differences. Limits the results to this path.
        /// Can also be used to specify the previous name of a directory or folder. If <code>beforePath</code>
        /// and <code>afterPath</code> are not specified, differences will be shown for all paths.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BeforePath { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository where you want to get differences.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>A non-negative integer used to limit the number of returned results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An enumeration token that when provided in a request, returns the next batch of the
        /// results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AfterCommitSpecifier = this.AfterCommitSpecifier;
            context.AfterPath = this.AfterPath;
            context.BeforeCommitSpecifier = this.BeforeCommitSpecifier;
            context.BeforePath = this.BeforePath;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RepositoryName = this.RepositoryName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.CodeCommit.Model.GetDifferencesRequest();
            
            if (cmdletContext.AfterCommitSpecifier != null)
            {
                request.AfterCommitSpecifier = cmdletContext.AfterCommitSpecifier;
            }
            if (cmdletContext.AfterPath != null)
            {
                request.AfterPath = cmdletContext.AfterPath;
            }
            if (cmdletContext.BeforeCommitSpecifier != null)
            {
                request.BeforeCommitSpecifier = cmdletContext.BeforeCommitSpecifier;
            }
            if (cmdletContext.BeforePath != null)
            {
                request.BeforePath = cmdletContext.BeforePath;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            
            // Initialize loop variant and commence piping
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Differences;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.Differences.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (AutoIterationHelpers.HasValue(_nextMarker));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private static Amazon.CodeCommit.Model.GetDifferencesResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.GetDifferencesRequest request)
        {
            #if DESKTOP
            return client.GetDifferences(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetDifferencesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AfterCommitSpecifier { get; set; }
            public System.String AfterPath { get; set; }
            public System.String BeforeCommitSpecifier { get; set; }
            public System.String BeforePath { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String RepositoryName { get; set; }
        }
        
    }
}
