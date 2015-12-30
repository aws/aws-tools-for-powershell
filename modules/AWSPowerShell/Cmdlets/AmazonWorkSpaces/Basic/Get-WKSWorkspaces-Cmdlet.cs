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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Obtains information about the specified WorkSpaces. 
    /// 
    ///  
    /// <para>
    /// Only one of the filter parameters, such as <code>BundleId</code>, <code>DirectoryId</code>,
    /// or <code>WorkspaceIds</code>, can be specified at a time.
    /// </para><para>
    /// This operation supports pagination with the use of the <code>NextToken</code> request
    /// and response parameters. If more results are available, the <code>NextToken</code>
    /// response member contains a token that you pass in the next call to this operation
    /// to retrieve the next set of items.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WKSWorkspaces")]
    [OutputType("Amazon.WorkSpaces.Model.Workspace")]
    [AWSCmdlet("Invokes the DescribeWorkspaces operation against Amazon WorkSpaces.", Operation = new[] {"DescribeWorkspaces"})]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.Workspace",
        "This cmdlet returns a collection of Workspace objects.",
        "The service call response (type Amazon.WorkSpaces.Model.DescribeWorkspacesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetWKSWorkspacesCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        #region Parameter BundleId
        /// <summary>
        /// <para>
        /// <para>The identifier of a bundle to obtain the WorkSpaces for. All WorkSpaces that are created
        /// from this bundle will be retrieved. This parameter cannot be combined with any other
        /// filter parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BundleId { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>Specifies the directory identifier to which to limit the WorkSpaces. Optionally, you
        /// can specify a specific directory user with the <code>UserName</code> parameter. This
        /// parameter cannot be combined with any other filter parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>Used with the <code>DirectoryId</code> parameter to specify the directory user for
        /// which to obtain the WorkSpace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>An array of strings that contain the identifiers of the WorkSpaces for which to retrieve
        /// information. This parameter cannot be combined with any other filter parameter.</para><para>Because the <a>CreateWorkspaces</a> operation is asynchronous, the identifier returned
        /// by <a>CreateWorkspaces</a> is not immediately available. If you immediately call <a>DescribeWorkspaces</a>
        /// with this identifier, no information will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WorkspaceIds")]
        public System.String[] WorkspaceId { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>NextToken</code> value from a previous call to this operation. Pass null
        /// if this is the first call.</para>
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
            
            context.BundleId = this.BundleId;
            context.DirectoryId = this.DirectoryId;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            context.UserName = this.UserName;
            if (this.WorkspaceId != null)
            {
                context.WorkspaceIds = new List<System.String>(this.WorkspaceId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.WorkSpaces.Model.DescribeWorkspacesRequest();
            if (cmdletContext.BundleId != null)
            {
                request.BundleId = cmdletContext.BundleId;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            if (cmdletContext.WorkspaceIds != null)
            {
                request.WorkspaceIds = cmdletContext.WorkspaceIds;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                _emitLimit = cmdletContext.Limit;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.Limit);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.DescribeWorkspaces(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Workspaces;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Workspaces.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String BundleId { get; set; }
            public System.String DirectoryId { get; set; }
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String UserName { get; set; }
            public List<System.String> WorkspaceIds { get; set; }
        }
        
    }
}
