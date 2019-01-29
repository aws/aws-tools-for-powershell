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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns a list of log events for a database in Amazon Lightsail.
    /// </summary>
    [Cmdlet("Get", "LSRelationalDatabaseLogEvent")]
    [OutputType("Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse")]
    [AWSCmdlet("Calls the Amazon Lightsail GetRelationalDatabaseLogEvents API operation.", Operation = new[] {"GetRelationalDatabaseLogEvents"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse",
        "This cmdlet returns a Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLSRelationalDatabaseLogEventCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time interval from which to get log events.</para><para>Constraints:</para><ul><li><para>Specified in Universal Coordinated Time (UTC).</para></li><li><para>Specified in the Unix time format.</para><para>For example, if you wish to use an end time of October 1, 2018, at 8 PM UTC, then
        /// you input <code>1538424000</code> as the end time.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter LogStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the log stream.</para><para>Use the <code>get relational database log streams</code> operation to get a list of
        /// available log streams.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LogStreamName { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of your database for which to get log events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RelationalDatabaseName { get; set; }
        #endregion
        
        #region Parameter StartFromHead
        /// <summary>
        /// <para>
        /// <para>Parameter to specify if the log should start from head or tail. If <code>true</code>
        /// is specified, the log event starts from the head of the log. If <code>false</code>
        /// is specified, the log event starts from the tail of the log.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean StartFromHead { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time interval from which to get log events.</para><para>Constraints:</para><ul><li><para>Specified in Universal Coordinated Time (UTC).</para></li><li><para>Specified in the Unix time format.</para><para>For example, if you wish to use a start time of October 1, 2018, at 8 PM UTC, then
        /// you input <code>1538424000</code> as the start time.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para>A token used for advancing to a specific page of results for your <code>get relational
        /// database log events</code> request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String PageToken { get; set; }
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
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            context.LogStreamName = this.LogStreamName;
            context.PageToken = this.PageToken;
            context.RelationalDatabaseName = this.RelationalDatabaseName;
            if (ParameterWasBound("StartFromHead"))
                context.StartFromHead = this.StartFromHead;
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
            var request = new Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.LogStreamName != null)
            {
                request.LogStreamName = cmdletContext.LogStreamName;
            }
            if (cmdletContext.PageToken != null)
            {
                request.PageToken = cmdletContext.PageToken;
            }
            if (cmdletContext.RelationalDatabaseName != null)
            {
                request.RelationalDatabaseName = cmdletContext.RelationalDatabaseName;
            }
            if (cmdletContext.StartFromHead != null)
            {
                request.StartFromHead = cmdletContext.StartFromHead.Value;
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
                object pipelineOutput = response;
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
        
        private Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetRelationalDatabaseLogEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetRelationalDatabaseLogEvents");
            try
            {
                #if DESKTOP
                return client.GetRelationalDatabaseLogEvents(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetRelationalDatabaseLogEventsAsync(request);
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
            public System.DateTime? EndTime { get; set; }
            public System.String LogStreamName { get; set; }
            public System.String PageToken { get; set; }
            public System.String RelationalDatabaseName { get; set; }
            public System.Boolean? StartFromHead { get; set; }
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
