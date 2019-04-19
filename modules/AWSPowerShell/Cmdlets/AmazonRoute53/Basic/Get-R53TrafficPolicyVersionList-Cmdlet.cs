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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets information about all of the versions for a specified traffic policy.
    /// 
    ///  
    /// <para>
    /// Traffic policy versions are listed in numerical order by <code>VersionNumber</code>.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "R53TrafficPolicyVersionList")]
    [OutputType("Amazon.Route53.Model.TrafficPolicy")]
    [AWSCmdlet("Calls the Amazon Route 53 ListTrafficPolicyVersions API operation.", Operation = new[] {"ListTrafficPolicyVersions"}, LegacyAlias="Get-R53TrafficPolicyVersions")]
    [AWSCmdletOutput("Amazon.Route53.Model.TrafficPolicy",
        "This cmdlet returns a collection of TrafficPolicy objects.",
        "The service call response (type Amazon.Route53.Model.ListTrafficPolicyVersionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: IsTruncated (type System.Boolean), TrafficPolicyVersionMarker (type System.String), MaxItems (type System.String)"
    )]
    public partial class GetR53TrafficPolicyVersionListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>Specify the value of <code>Id</code> of the traffic policy for which you want to list
        /// all versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of traffic policy versions that you want Amazon Route 53 to include
        /// in the response body for this request. If the specified traffic policy has more than
        /// <code>MaxItems</code> versions, the value of <code>IsTruncated</code> in the response
        /// is <code>true</code>, and the value of the <code>TrafficPolicyVersionMarker</code>
        /// element is the ID of the first version that Route 53 will return if you submit another
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyVersionMarker
        /// <summary>
        /// <para>
        /// <para>For your first request to <code>ListTrafficPolicyVersions</code>, don't include the
        /// <code>TrafficPolicyVersionMarker</code> parameter.</para><para>If you have more traffic policy versions than the value of <code>MaxItems</code>,
        /// <code>ListTrafficPolicyVersions</code> returns only the first group of <code>MaxItems</code>
        /// versions. To get more traffic policy versions, submit another <code>ListTrafficPolicyVersions</code>
        /// request. For the value of <code>TrafficPolicyVersionMarker</code>, specify the value
        /// of <code>TrafficPolicyVersionMarker</code> in the previous response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.TrafficPolicyVersionMarker, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String TrafficPolicyVersionMarker { get; set; }
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
            
            context.Id = this.Id;
            context.TrafficPolicyVersionMarker = this.TrafficPolicyVersionMarker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            
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
            var request = new Amazon.Route53.Model.ListTrafficPolicyVersionsRequest();
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.TrafficPolicyVersionMarker))
            {
                _nextMarker = cmdletContext.TrafficPolicyVersionMarker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxItems))
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxItems;
            }
            bool _userControllingPaging = ParameterWasBound("TrafficPolicyVersionMarker");
            
            try
            {
                do
                {
                    request.TrafficPolicyVersionMarker = _nextMarker;
                    int correctPageSize = 100;
                    if (_emitLimit.HasValue)
                    {
                        correctPageSize = AutoIterationHelpers.Min(100, _emitLimit.Value);
                    }
                    request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToString(correctPageSize);
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.TrafficPolicies;
                        notes = new Dictionary<string, object>();
                        notes["IsTruncated"] = response.IsTruncated;
                        notes["TrafficPolicyVersionMarker"] = response.TrafficPolicyVersionMarker;
                        notes["MaxItems"] = response.MaxItems;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.TrafficPolicies.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.TrafficPolicyVersionMarker));
                        }
                        
                        _nextMarker = response.TrafficPolicyVersionMarker;
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
        
        private Amazon.Route53.Model.ListTrafficPolicyVersionsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListTrafficPolicyVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListTrafficPolicyVersions");
            try
            {
                #if DESKTOP
                return client.ListTrafficPolicyVersions(request);
                #elif CORECLR
                return client.ListTrafficPolicyVersionsAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String TrafficPolicyVersionMarker { get; set; }
            public int? MaxItems { get; set; }
        }
        
    }
}
