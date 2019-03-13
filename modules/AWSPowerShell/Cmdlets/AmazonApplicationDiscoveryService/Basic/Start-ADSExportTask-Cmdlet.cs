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
using Amazon.ApplicationDiscoveryService;
using Amazon.ApplicationDiscoveryService.Model;

namespace Amazon.PowerShell.Cmdlets.ADS
{
    /// <summary>
    /// Begins the export of discovered data to an S3 bucket.
    /// 
    ///  
    /// <para>
    ///  If you specify <code>agentIds</code> in a filter, the task exports up to 72 hours
    /// of detailed data collected by the identified Application Discovery Agent, including
    /// network, process, and performance details. A time range for exported agent data may
    /// be set by using <code>startTime</code> and <code>endTime</code>. Export of detailed
    /// agent data is limited to five concurrently running exports. 
    /// </para><para>
    ///  If you do not include an <code>agentIds</code> filter, summary data is exported that
    /// includes both AWS Agentless Discovery Connector data and summary data from AWS Discovery
    /// Agents. Export of summary data is limited to two exports per day. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "ADSExportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Application Discovery Service StartExportTask API operation.", Operation = new[] {"StartExportTask"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.ApplicationDiscoveryService.Model.StartExportTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartADSExportTaskCmdlet : AmazonApplicationDiscoveryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end timestamp for exported data from the single Application Discovery Agent selected
        /// in the filters. If no value is specified, exported data includes the most recent data
        /// collected by the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter ExportDataFormat
        /// <summary>
        /// <para>
        /// <para>The file format for the returned export data. Default value is <code>CSV</code>. <b>Note:</b><i>The</i><code>GRAPHML</code><i>option has been deprecated.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String[] ExportDataFormat { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>If a filter is present, it selects the single <code>agentId</code> of the Application
        /// Discovery Agent for which data is exported. The <code>agentId</code> can be found
        /// in the results of the <code>DescribeAgents</code> API or CLI. If no filter is present,
        /// <code>startTime</code> and <code>endTime</code> are ignored and exported data includes
        /// both Agentless Discovery Connector data and summary data from Application Discovery
        /// agents. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.ApplicationDiscoveryService.Model.ExportFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start timestamp for exported data from the single Application Discovery Agent
        /// selected in the filters. If no value is specified, data is exported starting from
        /// the first data collected by the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ADSExportTask (StartExportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            if (this.ExportDataFormat != null)
            {
                context.ExportDataFormat = new List<System.String>(this.ExportDataFormat);
            }
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.ApplicationDiscoveryService.Model.ExportFilter>(this.Filter);
            }
            if (ParameterWasBound("StartTime"))
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
            // create request
            var request = new Amazon.ApplicationDiscoveryService.Model.StartExportTaskRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.ExportDataFormat != null)
            {
                request.ExportDataFormat = cmdletContext.ExportDataFormat;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ExportId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.ApplicationDiscoveryService.Model.StartExportTaskResponse CallAWSServiceOperation(IAmazonApplicationDiscoveryService client, Amazon.ApplicationDiscoveryService.Model.StartExportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Discovery Service", "StartExportTask");
            try
            {
                #if DESKTOP
                return client.StartExportTask(request);
                #elif CORECLR
                return client.StartExportTaskAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ExportDataFormat { get; set; }
            public List<Amazon.ApplicationDiscoveryService.Model.ExportFilter> Filters { get; set; }
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
