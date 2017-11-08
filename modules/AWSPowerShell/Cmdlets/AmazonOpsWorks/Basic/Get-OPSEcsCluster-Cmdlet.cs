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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Describes Amazon ECS clusters that are registered with a stack. If you specify only
    /// a stack ID, you can use the <code>MaxResults</code> and <code>NextToken</code> parameters
    /// to paginate the response. However, AWS OpsWorks Stacks currently supports only one
    /// cluster per layer, so the result set has a maximum of one element.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Show, Deploy,
    /// or Manage permissions level for the stack or an attached policy that explicitly grants
    /// permission. For more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para><para>
    /// This call accepts only one resource-identifying parameter.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "OPSEcsCluster")]
    [OutputType("Amazon.OpsWorks.Model.EcsCluster")]
    [AWSCmdlet("Calls the AWS OpsWorks DescribeEcsClusters API operation.", Operation = new[] {"DescribeEcsClusters"})]
    [AWSCmdletOutput("Amazon.OpsWorks.Model.EcsCluster",
        "This cmdlet returns a collection of EcsCluster objects.",
        "The service call response (type Amazon.OpsWorks.Model.DescribeEcsClustersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetOPSEcsClusterCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        #region Parameter EcsClusterArn
        /// <summary>
        /// <para>
        /// <para>A list of ARNs, one for each cluster to be described.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EcsClusterArns")]
        public System.String[] EcsClusterArn { get; set; }
        #endregion
        
        #region Parameter StackId
        /// <summary>
        /// <para>
        /// <para>A stack ID. <code>DescribeEcsClusters</code> returns a description of the cluster
        /// that is registered with the stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>To receive a paginated response, use this parameter to specify the maximum number
        /// of results to be returned with a single call. If the number of available results exceeds
        /// this maximum, the response includes a <code>NextToken</code> value that you can assign
        /// to the <code>NextToken</code> request parameter to get the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous paginated request did not return all of the remaining results, the
        /// response object's<code>NextToken</code> parameter value is set to a token. To retrieve
        /// the next set of results, call <code>DescribeEcsClusters</code> again and assign that
        /// token to the request object's <code>NextToken</code> parameter. If there are no remaining
        /// results, the previous response object's <code>NextToken</code> parameter is set to
        /// <code>null</code>.</para>
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
            
            if (this.EcsClusterArn != null)
            {
                context.EcsClusterArns = new List<System.String>(this.EcsClusterArn);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StackId = this.StackId;
            
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
            var request = new Amazon.OpsWorks.Model.DescribeEcsClustersRequest();
            if (cmdletContext.EcsClusterArns != null)
            {
                request.EcsClusterArns = cmdletContext.EcsClusterArns;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
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
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.EcsClusters;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.EcsClusters.Count;
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
        
        #region AWS Service Operation Call
        
        private Amazon.OpsWorks.Model.DescribeEcsClustersResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.DescribeEcsClustersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "DescribeEcsClusters");
            try
            {
                #if DESKTOP
                return client.DescribeEcsClusters(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeEcsClustersAsync(request);
                return task.Result;
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
            public List<System.String> EcsClusterArns { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String StackId { get; set; }
        }
        
    }
}
