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
using Amazon.CloudWatchRUM;
using Amazon.CloudWatchRUM.Model;

namespace Amazon.PowerShell.Cmdlets.CWRUM
{
    /// <summary>
    /// Retrieves the raw performance events that RUM has collected from your web application,
    /// so that you can do your own processing or analysis of this data.
    /// </summary>
    [Cmdlet("Get", "CWRUMAppMonitorData")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CloudWatch RUM GetAppMonitorData API operation.", Operation = new[] {"GetAppMonitorData"}, SelectReturnType = typeof(Amazon.CloudWatchRUM.Model.GetAppMonitorDataResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudWatchRUM.Model.GetAppMonitorDataResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.CloudWatchRUM.Model.GetAppMonitorDataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWRUMAppMonitorDataCmdlet : AmazonCloudWatchRUMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TimeRange_After
        /// <summary>
        /// <para>
        /// <para>The beginning of the time range to retrieve performance events from.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? TimeRange_After { get; set; }
        #endregion
        
        #region Parameter TimeRange_Before
        /// <summary>
        /// <para>
        /// <para>The end of the time range to retrieve performance events from. If you omit this, the
        /// time range extends to the time that this operation is performed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? TimeRange_Before { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>An array of structures that you can use to filter the results to those that match
        /// one or more sets of key-value pairs that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.CloudWatchRUM.Model.QueryFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the app monitor that collected the data that you want to retrieve.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in one operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Use the token returned by the previous operation to request the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Events'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchRUM.Model.GetAppMonitorDataResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchRUM.Model.GetAppMonitorDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Events";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchRUM.Model.GetAppMonitorDataResponse, GetCWRUMAppMonitorDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.CloudWatchRUM.Model.QueryFilter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.TimeRange_After = this.TimeRange_After;
            #if MODULAR
            if (this.TimeRange_After == null && ParameterWasBound(nameof(this.TimeRange_After)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeRange_After which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeRange_Before = this.TimeRange_Before;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudWatchRUM.Model.GetAppMonitorDataRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate TimeRange
            var requestTimeRangeIsNull = true;
            request.TimeRange = new Amazon.CloudWatchRUM.Model.TimeRange();
            System.Int64? requestTimeRange_timeRange_After = null;
            if (cmdletContext.TimeRange_After != null)
            {
                requestTimeRange_timeRange_After = cmdletContext.TimeRange_After.Value;
            }
            if (requestTimeRange_timeRange_After != null)
            {
                request.TimeRange.After = requestTimeRange_timeRange_After.Value;
                requestTimeRangeIsNull = false;
            }
            System.Int64? requestTimeRange_timeRange_Before = null;
            if (cmdletContext.TimeRange_Before != null)
            {
                requestTimeRange_timeRange_Before = cmdletContext.TimeRange_Before.Value;
            }
            if (requestTimeRange_timeRange_Before != null)
            {
                request.TimeRange.Before = requestTimeRange_timeRange_Before.Value;
                requestTimeRangeIsNull = false;
            }
             // determine if request.TimeRange should be set to null
            if (requestTimeRangeIsNull)
            {
                request.TimeRange = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudWatchRUM.Model.GetAppMonitorDataResponse CallAWSServiceOperation(IAmazonCloudWatchRUM client, Amazon.CloudWatchRUM.Model.GetAppMonitorDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch RUM", "GetAppMonitorData");
            try
            {
                #if DESKTOP
                return client.GetAppMonitorData(request);
                #elif CORECLR
                return client.GetAppMonitorDataAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudWatchRUM.Model.QueryFilter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String Name { get; set; }
            public System.String NextToken { get; set; }
            public System.Int64? TimeRange_After { get; set; }
            public System.Int64? TimeRange_Before { get; set; }
            public System.Func<Amazon.CloudWatchRUM.Model.GetAppMonitorDataResponse, GetCWRUMAppMonitorDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Events;
        }
        
    }
}
