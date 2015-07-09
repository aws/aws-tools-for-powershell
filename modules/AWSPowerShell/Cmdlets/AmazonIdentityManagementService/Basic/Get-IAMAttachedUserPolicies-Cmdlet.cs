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
    /// Lists all managed policies that are attached to the specified user. 
    /// 
    ///  
    /// <para>
    /// A user can also have inline policies embedded with it. To list the inline policies
    /// for a user, use the <a>ListUserPolicies</a> API. For information about policies, refer
    /// to <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/policies-managed-vs-inline.html">Managed
    /// Policies and Inline Policies</a> in the <i>Using IAM</i> guide. 
    /// </para><para>
    /// You can paginate the results using the <code>MaxItems</code> and <code>Marker</code>
    /// parameters. You can use the <code>PathPrefix</code> parameter to limit the list of
    /// policies to only those matching the specified path prefix. If there are no policies
    /// attached to the specified group (or none that match the specified path prefix), the
    /// action returns an empty list. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMAttachedUserPolicies")]
    [OutputType("Amazon.IdentityManagement.Model.AttachedPolicyType")]
    [AWSCmdlet("Invokes the ListAttachedUserPolicies operation against AWS Identity and Access Management.", Operation = new[] {"ListAttachedUserPolicies"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.AttachedPolicyType",
        "This cmdlet returns a collection of AttachedPolicyType objects.",
        "The service call response (type ListAttachedUserPoliciesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: IsTruncated (type Boolean), Marker (type String)"
    )]
    public class GetIAMAttachedUserPoliciesCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The path prefix for filtering the results. This parameter is optional. If it is not
        /// included, it defaults to a slash (/), listing all policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PathPrefix { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name (friendly name, not ARN) of the user to list attached policies for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String UserName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Use this parameter only when paginating results and only after you have received a
        /// response where the results are truncated. Set it to the value of the <code>Marker</code>
        /// element in the response you just received.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Use this only when paginating results to indicate the maximum number of items you
        /// want in the response. If there are additional items beyond the maximum you specify,
        /// the <code>IsTruncated</code> response element is <code>true</code>.</para><para>This parameter is optional. If you do not include it, it defaults to 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        
        
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
            context.UserName = this.UserName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new ListAttachedUserPoliciesRequest();
            if (cmdletContext.PathPrefix != null)
            {
                request.PathPrefix = cmdletContext.PathPrefix;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            
            // Initialize loop variants and commence piping
            String _nextMarker = null;
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
                        
                        var response = client.ListAttachedUserPolicies(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.AttachedPolicies;
                        notes = new Dictionary<string, object>();
                        notes["IsTruncated"] = response.IsTruncated;
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.AttachedPolicies.Count;
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
            public String Marker { get; set; }
            public int? MaxItems { get; set; }
            public String PathPrefix { get; set; }
            public String UserName { get; set; }
        }
        
    }
}
