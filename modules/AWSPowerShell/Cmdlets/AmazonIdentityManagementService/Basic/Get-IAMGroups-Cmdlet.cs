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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Lists the IAM groups that have the specified path prefix.
    /// 
    ///  
    /// <para>
    ///  You can paginate the results using the <code>MaxItems</code> and <code>Marker</code>
    /// parameters.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMGroups")]
    [OutputType("Amazon.IdentityManagement.Model.Group")]
    [AWSCmdlet("Invokes the ListGroups operation against AWS Identity and Access Management.", Operation = new[] {"ListGroups"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.Group",
        "This cmdlet returns a collection of Group objects.",
        "The service call response (type Amazon.IdentityManagement.Model.ListGroupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: IsTruncated (type System.Boolean), Marker (type System.String)"
    )]
    public class GetIAMGroupsCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter PathPrefix
        /// <summary>
        /// <para>
        /// <para> The path prefix for filtering the results. For example, the prefix <code>/division_abc/subdivision_xyz/</code>
        /// gets all groups whose path starts with <code>/division_abc/subdivision_xyz/</code>.</para><para>This parameter is optional. If it is not included, it defaults to a slash (/), listing
        /// all groups. The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for this
        /// parameter is a string of characters consisting of either a forward slash (/) by itself
        /// or a string that must begin and end with forward slashes, containing any ASCII character
        /// from the ! (\u0021) thru the DEL character (\u007F), including most punctuation characters,
        /// digits, and upper and lowercased letters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PathPrefix { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this parameter only when paginating results and only after you receive a response
        /// indicating that the results are truncated. Set it to the value of the <code>Marker</code>
        /// element in the response that you received to indicate where the next call should start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Use this only when paginating results to indicate the maximum number of items you
        /// want in the response. If additional items exist beyond the maximum you specify, the
        /// <code>IsTruncated</code> response element is <code>true</code>.</para><para>This parameter is optional. If you do not include it, it defaults to 100. Note that
        /// IAM might return fewer results, even when there are more results available. In that
        /// case, the <code>IsTruncated</code> response element returns <code>true</code> and
        /// <code>Marker</code> contains a value to include in the subsequent call that tells
        /// the service where to continue from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            context.PathPrefix = this.PathPrefix;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.IdentityManagement.Model.ListGroupsRequest();
            if (cmdletContext.PathPrefix != null)
            {
                request.PathPrefix = cmdletContext.PathPrefix;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxItems))
            {
                _emitLimit = cmdletContext.MaxItems;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.Marker) || AutoIterationHelpers.HasValue(cmdletContext.MaxItems);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.ListGroups(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Groups;
                        notes = new Dictionary<string, object>();
                        notes["IsTruncated"] = response.IsTruncated;
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Groups.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
                        
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
            public System.String Marker { get; set; }
            public int? MaxItems { get; set; }
            public System.String PathPrefix { get; set; }
        }
        
    }
}
