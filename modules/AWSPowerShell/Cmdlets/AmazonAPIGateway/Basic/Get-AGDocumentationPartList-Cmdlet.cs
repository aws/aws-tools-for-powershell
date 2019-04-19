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
    /// <br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "AGDocumentationPartList")]
    [OutputType("Amazon.APIGateway.Model.DocumentationPart")]
    [AWSCmdlet("Calls the Amazon API Gateway GetDocumentationParts API operation.", Operation = new[] {"GetDocumentationParts"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.DocumentationPart",
        "This cmdlet returns a collection of DocumentationPart objects.",
        "The service call response (type Amazon.APIGateway.Model.GetDocumentationPartsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Position (type System.String)"
    )]
    public partial class GetAGDocumentationPartListCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter LocationStatus
        /// <summary>
        /// <para>
        /// <para>The status of the API documentation parts to retrieve. Valid values are <code>DOCUMENTED</code>
        /// for retrieving <a>DocumentationPart</a> resources with content and <code>UNDOCUMENTED</code>
        /// for <a>DocumentationPart</a> resources without content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.LocationStatusType")]
        public Amazon.APIGateway.LocationStatusType LocationStatus { get; set; }
        #endregion
        
        #region Parameter NameQuery
        /// <summary>
        /// <para>
        /// <para>The name of API entities of the to-be-retrieved documentation parts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NameQuery { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The path of API entities of the to-be-retrieved documentation parts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Path { get; set; }
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of API entities of the to-be-retrieved documentation parts. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.DocumentationPartType")]
        public Amazon.APIGateway.DocumentationPartType Type { get; set; }
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
            
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.LocationStatus = this.LocationStatus;
            context.NameQuery = this.NameQuery;
            context.Path = this.Path;
            context.Position = this.Position;
            context.RestApiId = this.RestApiId;
            context.Type = this.Type;
            
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
            var request = new Amazon.APIGateway.Model.GetDocumentationPartsRequest();
            if (cmdletContext.LocationStatus != null)
            {
                request.LocationStatus = cmdletContext.LocationStatus;
            }
            if (cmdletContext.NameQuery != null)
            {
                request.NameQuery = cmdletContext.NameQuery;
            }
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.APIGateway.Model.GetDocumentationPartsResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetDocumentationPartsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetDocumentationParts");
            try
            {
                #if DESKTOP
                return client.GetDocumentationParts(request);
                #elif CORECLR
                return client.GetDocumentationPartsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.APIGateway.LocationStatusType LocationStatus { get; set; }
            public System.String NameQuery { get; set; }
            public System.String Path { get; set; }
            public System.String Position { get; set; }
            public System.String RestApiId { get; set; }
            public Amazon.APIGateway.DocumentationPartType Type { get; set; }
        }
        
    }
}
