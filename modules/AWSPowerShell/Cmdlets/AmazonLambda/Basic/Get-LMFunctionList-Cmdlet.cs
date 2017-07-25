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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Returns a list of your Lambda functions. For each function, the response includes
    /// the function configuration information. You must use <a>GetFunction</a> to retrieve
    /// the code for your function.
    /// 
    ///  
    /// <para>
    /// This operation requires permission for the <code>lambda:ListFunctions</code> action.
    /// </para><para>
    /// If you are using the versioning feature, you can list all of your functions or only
    /// <code>$LATEST</code> versions. For information about the versioning feature, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-aliases.html">AWS Lambda
    /// Function Versioning and Aliases</a>. 
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "LMFunctionList")]
    [OutputType("Amazon.Lambda.Model.FunctionConfiguration")]
    [AWSCmdlet("Invokes the ListFunctions operation against Amazon Lambda.", Operation = new[] {"ListFunctions"}, LegacyAlias="Get-LMFunctions")]
    [AWSCmdletOutput("Amazon.Lambda.Model.FunctionConfiguration",
        "This cmdlet returns a collection of FunctionConfiguration objects.",
        "The service call response (type Amazon.Lambda.Model.ListFunctionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextMarker (type System.String)"
    )]
    public partial class GetLMFunctionListCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter FunctionVersion
        /// <summary>
        /// <para>
        /// <para>Optional string. If not specified, only the unqualified functions ARNs (Amazon Resource
        /// Names) will be returned.</para><para>Valid value:</para><para><code>ALL</code> _ Will return all versions, including <code>$LATEST</code> which
        /// will have fully qualified ARNs (Amazon Resource Names).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Lambda.FunctionVersion")]
        public Amazon.Lambda.FunctionVersion FunctionVersion { get; set; }
        #endregion
        
        #region Parameter MasterRegion
        /// <summary>
        /// <para>
        /// <para>Optional string. If not specified, will return only regular function versions (i.e.,
        /// non-replicated versions).</para><para>Valid values are:</para><para>The region from which the functions are replicated. For example, if you specify <code>us-east-1</code>,
        /// only functions replicated from that region will be returned.</para><para><code>ALL</code> _ Will return all functions from any region. If specified, you also
        /// must specify a valid FunctionVersion parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterRegion { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Optional string. An opaque pagination token returned from a previous <code>ListFunctions</code>
        /// operation. If present, indicates where to continue the listing. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Optional integer. Specifies the maximum number of AWS Lambda functions to return in
        /// response. This parameter value must be greater than 0.</para>
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
            
            context.FunctionVersion = this.FunctionVersion;
            context.Marker = this.Marker;
            context.MasterRegion = this.MasterRegion;
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
            var request = new Amazon.Lambda.Model.ListFunctionsRequest();
            if (cmdletContext.FunctionVersion != null)
            {
                request.FunctionVersion = cmdletContext.FunctionVersion;
            }
            if (cmdletContext.MasterRegion != null)
            {
                request.MasterRegion = cmdletContext.MasterRegion;
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
                        object pipelineOutput = response.Functions;
                        notes = new Dictionary<string, object>();
                        notes["NextMarker"] = response.NextMarker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Functions.Count;
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
        
        private Amazon.Lambda.Model.ListFunctionsResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.ListFunctionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lambda", "ListFunctions");
            #if DESKTOP
            return client.ListFunctions(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ListFunctionsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.Lambda.FunctionVersion FunctionVersion { get; set; }
            public System.String Marker { get; set; }
            public System.String MasterRegion { get; set; }
            public int? MaxItems { get; set; }
        }
        
    }
}
