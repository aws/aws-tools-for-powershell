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
    /// Queries the specified pipeline for the names of objects that match the specified set
    /// of conditions.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Find", "DPObject")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Data Pipeline QueryObjects API operation.", Operation = new[] {"QueryObjects"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.DataPipeline.Model.QueryObjectsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: HasMoreResults (type System.Boolean), Marker (type System.String)"
    )]
    public partial class FindDPObjectCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        #region Parameter PipelineId
        /// <summary>
        /// <para>
        /// <para>The ID of the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PipelineId { get; set; }
        #endregion
        
        #region Parameter Query_Selector
        /// <summary>
        /// <para>
        /// <para>List of selectors that define the query. An object must satisfy all of the selectors
        /// to match the query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Query_Selectors")]
        public Amazon.DataPipeline.Model.Selector[] Query_Selector { get; set; }
        #endregion
        
        #region Parameter Sphere
        /// <summary>
        /// <para>
        /// <para>Indicates whether the query applies to components or instances. The possible values
        /// are: <code>COMPONENT</code>, <code>INSTANCE</code>, and <code>ATTEMPT</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Sphere { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of object names that <code>QueryObjects</code> will return in a
        /// single call. The default value is 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The starting point for the results to be returned. For the first call, this value
        /// should be empty. As long as there are more results, continue to call <code>QueryObjects</code>
        /// with the marker value from the previous call to retrieve the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
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
            context.PipelineId = this.PipelineId;
            if (this.Query_Selector != null)
            {
                context.Query_Selectors = new List<Amazon.DataPipeline.Model.Selector>(this.Query_Selector);
            }
            context.Sphere = this.Sphere;
            
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
            var request = new Amazon.DataPipeline.Model.QueryObjectsRequest();
            
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.PipelineId != null)
            {
                request.PipelineId = cmdletContext.PipelineId;
            }
            
             // populate Query
            bool requestQueryIsNull = true;
            request.Query = new Amazon.DataPipeline.Model.Query();
            List<Amazon.DataPipeline.Model.Selector> requestQuery_query_Selector = null;
            if (cmdletContext.Query_Selectors != null)
            {
                requestQuery_query_Selector = cmdletContext.Query_Selectors;
            }
            if (requestQuery_query_Selector != null)
            {
                request.Query.Selectors = requestQuery_query_Selector;
                requestQueryIsNull = false;
            }
             // determine if request.Query should be set to null
            if (requestQueryIsNull)
            {
                request.Query = null;
            }
            if (cmdletContext.Sphere != null)
            {
                request.Sphere = cmdletContext.Sphere;
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
                        object pipelineOutput = response.Ids;
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
                            int _receivedThisCall = response.Ids.Count;
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
        
        private Amazon.DataPipeline.Model.QueryObjectsResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.QueryObjectsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Pipeline", "QueryObjects");
            try
            {
                #if DESKTOP
                return client.QueryObjects(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.QueryObjectsAsync(request);
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
            public System.Int32? Limit { get; set; }
            public System.String Marker { get; set; }
            public System.String PipelineId { get; set; }
            public List<Amazon.DataPipeline.Model.Selector> Query_Selectors { get; set; }
            public System.String Sphere { get; set; }
        }
        
    }
}
