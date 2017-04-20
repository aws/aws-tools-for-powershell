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
    /// Obtains information about the WorkSpace bundles that are available to your account
    /// in the specified region.
    /// 
    ///  
    /// <para>
    /// You can filter the results with either the <code>BundleIds</code> parameter, or the
    /// <code>Owner</code> parameter, but not both.
    /// </para><para>
    /// This operation supports pagination with the use of the <code>NextToken</code> request
    /// and response parameters. If more results are available, the <code>NextToken</code>
    /// response member contains a token that you pass in the next call to this operation
    /// to retrieve the next set of items.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "WKSWorkspaceBundles")]
    [OutputType("Amazon.WorkSpaces.Model.WorkspaceBundle")]
    [AWSCmdlet("Invokes the DescribeWorkspaceBundles operation against Amazon WorkSpaces.", Operation = new[] {"DescribeWorkspaceBundles"})]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.WorkspaceBundle",
        "This cmdlet returns a collection of WorkspaceBundle objects.",
        "The service call response (type Amazon.WorkSpaces.Model.DescribeWorkspaceBundlesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetWKSWorkspaceBundlesCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        #region Parameter BundleId
        /// <summary>
        /// <para>
        /// <para>An array of strings that contains the identifiers of the bundles to retrieve. This
        /// parameter cannot be combined with any other filter parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BundleIds")]
        public System.String[] BundleId { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>NextToken</code> value from a previous call to this operation. Pass null
        /// if this is the first call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Owner
        /// <summary>
        /// <para>
        /// <para>The owner of the bundles to retrieve. This parameter cannot be combined with any other
        /// filter parameter.</para><para>This contains one of the following values:</para><ul><li><para>null- Retrieves the bundles that belong to the account making the call.</para></li><li><para><code>AMAZON</code>- Retrieves the bundles that are provided by AWS.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Owner { get; set; }
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
            
            if (this.BundleId != null)
            {
                context.BundleIds = new List<System.String>(this.BundleId);
            }
            context.NextToken = this.NextToken;
            context.Owner = this.Owner;
            
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
            var request = new Amazon.WorkSpaces.Model.DescribeWorkspaceBundlesRequest();
            
            if (cmdletContext.BundleIds != null)
            {
                request.BundleIds = cmdletContext.BundleIds;
            }
            if (cmdletContext.Owner != null)
            {
                request.Owner = cmdletContext.Owner;
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
                        object pipelineOutput = response.Bundles;
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
                            int _receivedThisCall = response.Bundles.Count;
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
        
        private Amazon.WorkSpaces.Model.DescribeWorkspaceBundlesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.DescribeWorkspaceBundlesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "DescribeWorkspaceBundles");
            #if DESKTOP
            return client.DescribeWorkspaceBundles(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeWorkspaceBundlesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> BundleIds { get; set; }
            public System.String NextToken { get; set; }
            public System.String Owner { get; set; }
        }
        
    }
}
