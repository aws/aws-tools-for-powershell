/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ComputeOptimizerAutomation;
using Amazon.ComputeOptimizerAutomation.Model;

namespace Amazon.PowerShell.Cmdlets.COA
{
    /// <summary>
    /// Lists automation events based on specified filters. You can retrieve events that were
    /// created within the past year.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "COAAutomationEventList")]
    [OutputType("Amazon.ComputeOptimizerAutomation.Model.AutomationEvent")]
    [AWSCmdlet("Calls the Compute Optimizer Automation Service ListAutomationEvents API operation.", Operation = new[] {"ListAutomationEvents"}, SelectReturnType = typeof(Amazon.ComputeOptimizerAutomation.Model.ListAutomationEventsResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizerAutomation.Model.AutomationEvent or Amazon.ComputeOptimizerAutomation.Model.ListAutomationEventsResponse",
        "This cmdlet returns a collection of Amazon.ComputeOptimizerAutomation.Model.AutomationEvent objects.",
        "The service call response (type Amazon.ComputeOptimizerAutomation.Model.ListAutomationEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCOAAutomationEventListCmdlet : AmazonComputeOptimizerAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTimeExclusive
        /// <summary>
        /// <para>
        /// <para> The end of the time range to query for events. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTimeExclusive { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para> The filters to apply to the list of automation events. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.ComputeOptimizerAutomation.Model.AutomationEventFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter StartTimeInclusive
        /// <summary>
        /// <para>
        /// <para> The start of the time range to query for events. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTimeInclusive { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of results to return in a single call. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The token for the next page of results. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutomationEvents'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizerAutomation.Model.ListAutomationEventsResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizerAutomation.Model.ListAutomationEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutomationEvents";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizerAutomation.Model.ListAutomationEventsResponse, GetCOAAutomationEventListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTimeExclusive = this.EndTimeExclusive;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.ComputeOptimizerAutomation.Model.AutomationEventFilter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StartTimeInclusive = this.StartTimeInclusive;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ComputeOptimizerAutomation.Model.ListAutomationEventsRequest();
            
            if (cmdletContext.EndTimeExclusive != null)
            {
                request.EndTimeExclusive = cmdletContext.EndTimeExclusive.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.StartTimeInclusive != null)
            {
                request.StartTimeInclusive = cmdletContext.StartTimeInclusive.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ComputeOptimizerAutomation.Model.ListAutomationEventsResponse CallAWSServiceOperation(IAmazonComputeOptimizerAutomation client, Amazon.ComputeOptimizerAutomation.Model.ListAutomationEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Compute Optimizer Automation Service", "ListAutomationEvents");
            try
            {
                #if DESKTOP
                return client.ListAutomationEvents(request);
                #elif CORECLR
                return client.ListAutomationEventsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTimeExclusive { get; set; }
            public List<Amazon.ComputeOptimizerAutomation.Model.AutomationEventFilter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTimeInclusive { get; set; }
            public System.Func<Amazon.ComputeOptimizerAutomation.Model.ListAutomationEventsResponse, GetCOAAutomationEventListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutomationEvents;
        }
        
    }
}
