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
using Amazon.DataPipeline;
using Amazon.DataPipeline.Model;

namespace Amazon.PowerShell.Cmdlets.DP
{
    /// <summary>
    /// Gets the object definitions for a set of objects associated with the pipeline. Object
    /// definitions are composed of a set of fields that define the properties of the object.
    /// </summary>
    [Cmdlet("Get", "DPObject")]
    [OutputType("Amazon.DataPipeline.Model.PipelineObject")]
    [AWSCmdlet("Invokes the DescribeObjects operation against AWS Data Pipeline.", Operation = new[] {"DescribeObjects"})]
    [AWSCmdletOutput("Amazon.DataPipeline.Model.PipelineObject",
        "This cmdlet returns a collection of PipelineObject objects.",
        "The service call response (type Amazon.DataPipeline.Model.DescribeObjectsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: HasMoreResults (type System.Boolean), Marker (type System.String)"
    )]
    public class GetDPObjectCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        #region Parameter EvaluateExpression
        /// <summary>
        /// <para>
        /// <para>Indicates whether any expressions in the object should be evaluated when the object
        /// descriptions are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("EvaluateExpressions")]
        public System.Boolean EvaluateExpression { get; set; }
        #endregion
        
        #region Parameter ObjectId
        /// <summary>
        /// <para>
        /// <para>The IDs of the pipeline objects that contain the definitions to be described. You
        /// can pass as many as 25 identifiers in a single call to <code>DescribeObjects</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("ObjectIds")]
        public System.String[] ObjectId { get; set; }
        #endregion
        
        #region Parameter PipelineId
        /// <summary>
        /// <para>
        /// <para>The ID of the pipeline that contains the object definitions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PipelineId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The starting point for the results to be returned. For the first call, this value
        /// should be empty. As long as there are more results, continue to call <code>DescribeObjects</code>
        /// with the marker value from the previous call to retrieve the next set of results.</para>
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
            
            if (ParameterWasBound("EvaluateExpression"))
                context.EvaluateExpressions = this.EvaluateExpression;
            context.Marker = this.Marker;
            if (this.ObjectId != null)
            {
                context.ObjectIds = new List<System.String>(this.ObjectId);
            }
            context.PipelineId = this.PipelineId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.DataPipeline.Model.DescribeObjectsRequest();
            
            if (cmdletContext.EvaluateExpressions != null)
            {
                request.EvaluateExpressions = cmdletContext.EvaluateExpressions.Value;
            }
            if (cmdletContext.ObjectIds != null)
            {
                request.ObjectIds = cmdletContext.ObjectIds;
            }
            if (cmdletContext.PipelineId != null)
            {
                request.PipelineId = cmdletContext.PipelineId;
            }
            
            // Initialize loop variant and commence piping
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.PipelineObjects;
                        notes = new Dictionary<string, object>();
                        notes["HasMoreResults"] = response.HasMoreResults;
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.PipelineObjects.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
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
        
        private static Amazon.DataPipeline.Model.DescribeObjectsResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.DescribeObjectsRequest request)
        {
            return client.DescribeObjects(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Boolean? EvaluateExpressions { get; set; }
            public System.String Marker { get; set; }
            public List<System.String> ObjectIds { get; set; }
            public System.String PipelineId { get; set; }
        }
        
    }
}
