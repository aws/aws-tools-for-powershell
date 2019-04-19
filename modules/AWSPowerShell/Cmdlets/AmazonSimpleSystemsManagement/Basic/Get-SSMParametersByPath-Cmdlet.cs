/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Retrieve parameters in a specific hierarchy. For more information, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/sysman-paramstore-working.html">Working
    /// with Systems Manager Parameters</a> in the <i>AWS Systems Manager User Guide</i>.
    /// 
    /// 
    ///  
    /// <para>
    /// Request results are returned on a best-effort basis. If you specify <code>MaxResults</code>
    /// in the request, the response includes information up to the limit specified. The number
    /// of items returned, however, can be between zero and the value of <code>MaxResults</code>.
    /// If the service reaches an internal limit while processing the results, it stops the
    /// operation and returns the matching values up to that point and a <code>NextToken</code>.
    /// You can specify the <code>NextToken</code> in a subsequent call to get the next set
    /// of results.
    /// </para><note><para>
    /// This API action doesn't support filtering by tags. 
    /// </para></note><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "SSMParametersByPath")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.Parameter")]
    [AWSCmdlet("Calls the AWS Systems Manager GetParametersByPath API operation.", Operation = new[] {"GetParametersByPath"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.Parameter",
        "This cmdlet returns a collection of Parameter objects.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetSSMParametersByPathCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter ParameterFilter
        /// <summary>
        /// <para>
        /// <para>Filters to limit the request results.</para><note><para>You can't filter using the parameter name.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ParameterFilters")]
        public Amazon.SimpleSystemsManagement.Model.ParameterStringFilter[] ParameterFilter { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The hierarchy for the parameter. Hierarchies start with a forward slash (/) and end
        /// with the parameter name. A parameter name hierarchy can have a maximum of 15 levels.
        /// Here is an example of a hierarchy: <code>/Finance/Prod/IAD/WinServ2016/license33</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter Recursive
        /// <summary>
        /// <para>
        /// <para>Retrieve all parameters within a hierarchy.</para><important><para>If a user has access to a path, then the user can access all levels of that path.
        /// For example, if a user has permission to access path <code>/a</code>, then the user
        /// can also access <code>/a/b</code>. Even if a user has explicitly been denied access
        /// in IAM for parameter <code>/a/b</code>, they can still call the GetParametersByPath
        /// API action recursively for <code>/a</code> and view <code>/a/b</code>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Recursive { get; set; }
        #endregion
        
        #region Parameter WithDecryption
        /// <summary>
        /// <para>
        /// <para>Retrieve all parameters in a hierarchy with their value decrypted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean WithDecryption { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this call. The call also returns a token
        /// that you can specify in a subsequent call to get the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to start the list. Use this token to get the next set of results. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
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
            
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.ParameterFilter != null)
            {
                context.ParameterFilters = new List<Amazon.SimpleSystemsManagement.Model.ParameterStringFilter>(this.ParameterFilter);
            }
            context.Path = this.Path;
            if (ParameterWasBound("Recursive"))
                context.Recursive = this.Recursive;
            if (ParameterWasBound("WithDecryption"))
                context.WithDecryption = this.WithDecryption;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.GetParametersByPathRequest();
            if (cmdletContext.ParameterFilters != null)
            {
                request.ParameterFilters = cmdletContext.ParameterFilters;
            }
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.Recursive != null)
            {
                request.Recursive = cmdletContext.Recursive.Value;
            }
            if (cmdletContext.WithDecryption != null)
            {
                request.WithDecryption = cmdletContext.WithDecryption.Value;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                // The service has a maximum page size of 10. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 10 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken");
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    int correctPageSize = 10;
                    if (_emitLimit.HasValue)
                    {
                        correctPageSize = AutoIterationHelpers.Min(10, _emitLimit.Value);
                    }
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Parameters;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Parameters.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        _retrievedSoFar += _receivedThisCall;
                        if (_emitLimit.HasValue)
                        {
                            _emitLimit -= _receivedThisCall;
                        }
                    }
                    catch (Exception e)
                    {
                        if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                        {
                            output = new CmdletOutput { ErrorResponse = e };
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    ProcessOutput(output);
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
            }
            finally
            {
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleSystemsManagement.Model.GetParametersByPathResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.GetParametersByPathRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "GetParametersByPath");
            try
            {
                #if DESKTOP
                return client.GetParametersByPath(request);
                #elif CORECLR
                return client.GetParametersByPathAsync(request).GetAwaiter().GetResult();
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
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.ParameterStringFilter> ParameterFilters { get; set; }
            public System.String Path { get; set; }
            public System.Boolean? Recursive { get; set; }
            public System.Boolean? WithDecryption { get; set; }
        }
        
    }
}
