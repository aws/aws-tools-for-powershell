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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Returns a list of all grants for which the grant's <code>RetiringPrincipal</code>
    /// matches the one specified.
    /// 
    ///  
    /// <para>
    /// A typical use is to list all grants that you are able to retire. To retire a grant,
    /// use <a>RetireGrant</a>.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "KMSRetirableGrant")]
    [OutputType("Amazon.KeyManagementService.Model.GrantListEntry")]
    [AWSCmdlet("Calls the AWS Key Management Service ListRetirableGrants API operation.", Operation = new[] {"ListRetirableGrants"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GrantListEntry",
        "This cmdlet returns a collection of GrantListEntry objects.",
        "The service call response (type Amazon.KeyManagementService.Model.ListRetirableGrantsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextMarker (type System.String), Truncated (type System.Boolean)"
    )]
    public partial class GetKMSRetirableGrantCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter RetiringPrincipal
        /// <summary>
        /// <para>
        /// <para>The retiring principal for which to list grants.</para><para>To specify the retiring principal, use the <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of an AWS principal. Valid AWS principals include AWS accounts
        /// (root), IAM users, federated users, and assumed role users. For examples of the ARN
        /// syntax for specifying a principal, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-iam">AWS
        /// Identity and Access Management (IAM)</a> in the Example ARNs section of the <i>Amazon
        /// Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RetiringPrincipal { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Use this parameter to specify the maximum number of items to return. When this value
        /// is present, AWS KMS does not return more than the specified number of items, but it
        /// might return fewer.</para><para>This value is optional. If you include a value, it must be between 1 and 100, inclusive.
        /// If you do not include a value, it defaults to 50.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this parameter in a subsequent request after you receive a response with truncated
        /// results. Set it to the value of <code>NextMarker</code> from the truncated response
        /// you just received.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
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
            
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.Marker = this.Marker;
            context.RetiringPrincipal = this.RetiringPrincipal;
            
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
            var request = new Amazon.KeyManagementService.Model.ListRetirableGrantsRequest();
            if (cmdletContext.RetiringPrincipal != null)
            {
                request.RetiringPrincipal = cmdletContext.RetiringPrincipal;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                _emitLimit = cmdletContext.Limit;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.Marker) || AutoIterationHelpers.HasValue(cmdletContext.Limit);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Grants;
                        notes = new Dictionary<string, object>();
                        notes["NextMarker"] = response.NextMarker;
                        notes["Truncated"] = response.Truncated;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Grants.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.NextMarker;
                        
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
        
        private Amazon.KeyManagementService.Model.ListRetirableGrantsResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.ListRetirableGrantsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "ListRetirableGrants");
            try
            {
                #if DESKTOP
                return client.ListRetirableGrants(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListRetirableGrantsAsync(request);
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
            public int? Limit { get; set; }
            public System.String Marker { get; set; }
            public System.String RetiringPrincipal { get; set; }
        }
        
    }
}
