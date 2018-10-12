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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Returns a list of event source mappings you created using the <code>CreateEventSourceMapping</code>
    /// (see <a>CreateEventSourceMapping</a>). 
    /// 
    ///  
    /// <para>
    /// For each mapping, the API returns configuration information. You can optionally specify
    /// filters to retrieve specific event source mappings.
    /// </para><para>
    /// This operation requires permission for the <code>lambda:ListEventSourceMappings</code>
    /// action.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "LMEventSourceMappingList")]
    [OutputType("Amazon.Lambda.Model.EventSourceMappingConfiguration")]
    [AWSCmdlet("Calls the AWS Lambda ListEventSourceMappings API operation.", Operation = new[] {"ListEventSourceMappings"}, LegacyAlias="Get-LMEventSourceMappings")]
    [AWSCmdletOutput("Amazon.Lambda.Model.EventSourceMappingConfiguration",
        "This cmdlet returns a collection of EventSourceMappingConfiguration objects.",
        "The service call response (type Amazon.Lambda.Model.ListEventSourceMappingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextMarker (type System.String)"
    )]
    public partial class GetLMEventSourceMappingListCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter EventSourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Kinesis or DynamoDB stream. (This parameter
        /// is optional.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EventSourceArn { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.ListEventSourceMappingsRequest.FunctionName
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Optional string. An opaque pagination token returned from a previous <code>ListEventSourceMappings</code>
        /// operation. If present, specifies to continue the list from where the returning call
        /// left off. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Optional integer. Specifies the maximum number of event sources to return in response.
        /// This value must be greater than 0.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.EventSourceArn = this.EventSourceArn;
            context.FunctionName = this.FunctionName;
            context.Marker = this.Marker;
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
            var request = new Amazon.Lambda.Model.ListEventSourceMappingsRequest();
            if (cmdletContext.EventSourceArn != null)
            {
                request.EventSourceArn = cmdletContext.EventSourceArn;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
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
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.EventSourceMappings;
                        notes = new Dictionary<string, object>();
                        notes["NextMarker"] = response.NextMarker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.EventSourceMappings.Count;
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
        
        private Amazon.Lambda.Model.ListEventSourceMappingsResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.ListEventSourceMappingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "ListEventSourceMappings");
            try
            {
                #if DESKTOP
                return client.ListEventSourceMappings(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListEventSourceMappingsAsync(request);
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
            public System.String EventSourceArn { get; set; }
            public System.String FunctionName { get; set; }
            public System.String Marker { get; set; }
            public int? MaxItems { get; set; }
        }
        
    }
}
