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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Lists information about a collection of <a>Resource</a> resources.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "AGResourceList")]
    [OutputType("Amazon.APIGateway.Model.Resource")]
    [AWSCmdlet("Calls the Amazon API Gateway GetResources API operation.", Operation = new[] {"GetResources"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.Resource",
        "This cmdlet returns a collection of Resource objects.",
        "The service call response (type Amazon.APIGateway.Model.GetResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Position (type System.String)"
    )]
    public partial class GetAGResourceListCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter Embed
        /// <summary>
        /// <para>
        /// <para>A query parameter used to retrieve the specified resources embedded in the returned
        /// <a>Resources</a> resource in the response. This <code>embed</code> parameter value
        /// is a list of comma-separated strings. Currently, the request supports only retrieval
        /// of the embedded <a>Method</a> resources this way. The query parameter value must be
        /// a single-valued list and contain the <code>"methods"</code> string. For example, <code>GET
        /// /restapis/{restapi_id}/resources?embed=methods</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] Embed { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>[Required] The string identifier of the associated <a>RestApi</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of returned results per page. The default value is 25 and the maximum
        /// value is 500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        #region Parameter Position
        /// <summary>
        /// <para>
        /// <para>The current pagination position in the paged result set.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.Position, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Position { get; set; }
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
            
            if (this.Embed != null)
            {
                context.Embed = new List<System.String>(this.Embed);
            }
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.Position = this.Position;
            context.RestApiId = this.RestApiId;
            
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
            var request = new Amazon.APIGateway.Model.GetResourcesRequest();
            if (cmdletContext.Embed != null)
            {
                request.Embed = cmdletContext.Embed;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Position))
            {
                _nextMarker = cmdletContext.Position;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                _emitLimit = cmdletContext.Limit;
            }
            bool _userControllingPaging = ParameterWasBound("Position");
            
            try
            {
                do
                {
                    request.Position = _nextMarker;
                    if (_emitLimit.HasValue)
                    {
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Items;
                        notes = new Dictionary<string, object>();
                        notes["Position"] = response.Position;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Items.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Position));
                        }
                        
                        _nextMarker = response.Position;
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
        
        private Amazon.APIGateway.Model.GetResourcesResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetResources");
            try
            {
                #if DESKTOP
                return client.GetResources(request);
                #elif CORECLR
                return client.GetResourcesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Embed { get; set; }
            public int? Limit { get; set; }
            public System.String Position { get; set; }
            public System.String RestApiId { get; set; }
        }
        
    }
}
