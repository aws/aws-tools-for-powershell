/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.InternetMonitor;
using Amazon.InternetMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.CWIM
{
    /// <summary>
    /// Lists internet events that cause performance or availability issues for client locations.
    /// Amazon CloudWatch Internet Monitor displays information about recent global health
    /// events, called internet events, on a global outages map that is available to all Amazon
    /// Web Services customers. 
    /// 
    ///  
    /// <para>
    /// You can constrain the list of internet events returned by providing a start time and
    /// end time to define a total time frame for events you want to list. Both start time
    /// and end time specify the time when an event started. End time is optional. If you
    /// don't include it, the default end time is the current time.
    /// </para><para>
    /// You can also limit the events returned to a specific status (<c>ACTIVE</c> or <c>RESOLVED</c>)
    /// or type (<c>PERFORMANCE</c> or <c>AVAILABILITY</c>).
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWIMInternetEventList")]
    [OutputType("Amazon.InternetMonitor.Model.InternetEventSummary")]
    [AWSCmdlet("Calls the Amazon CloudWatch Internet Monitor ListInternetEvents API operation.", Operation = new[] {"ListInternetEvents"}, SelectReturnType = typeof(Amazon.InternetMonitor.Model.ListInternetEventsResponse))]
    [AWSCmdletOutput("Amazon.InternetMonitor.Model.InternetEventSummary or Amazon.InternetMonitor.Model.ListInternetEventsResponse",
        "This cmdlet returns a collection of Amazon.InternetMonitor.Model.InternetEventSummary objects.",
        "The service call response (type Amazon.InternetMonitor.Model.ListInternetEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWIMInternetEventListCmdlet : AmazonInternetMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the time window that you want to get a list of internet events for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter EventStatus
        /// <summary>
        /// <para>
        /// <para>The status of an internet event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventStatus { get; set; }
        #endregion
        
        #region Parameter EventType
        /// <summary>
        /// <para>
        /// <para>The type of network impairment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventType { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the time window that you want to get a list of internet events for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The number of query results that you want to return with this call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. You receive this token from a previous call.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InternetEvents'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.InternetMonitor.Model.ListInternetEventsResponse).
        /// Specifying the name of a property of type Amazon.InternetMonitor.Model.ListInternetEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InternetEvents";
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
                context.Select = CreateSelectDelegate<Amazon.InternetMonitor.Model.ListInternetEventsResponse, GetCWIMInternetEventListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            context.EventStatus = this.EventStatus;
            context.EventType = this.EventType;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.StartTime = this.StartTime;
            
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
            var request = new Amazon.InternetMonitor.Model.ListInternetEventsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.EventStatus != null)
            {
                request.EventStatus = cmdletContext.EventStatus;
            }
            if (cmdletContext.EventType != null)
            {
                request.EventType = cmdletContext.EventType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.InternetMonitor.Model.ListInternetEventsResponse CallAWSServiceOperation(IAmazonInternetMonitor client, Amazon.InternetMonitor.Model.ListInternetEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Internet Monitor", "ListInternetEvents");
            try
            {
                #if DESKTOP
                return client.ListInternetEvents(request);
                #elif CORECLR
                return client.ListInternetEventsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String EventStatus { get; set; }
            public System.String EventType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.InternetMonitor.Model.ListInternetEventsResponse, GetCWIMInternetEventListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InternetEvents;
        }
        
    }
}
