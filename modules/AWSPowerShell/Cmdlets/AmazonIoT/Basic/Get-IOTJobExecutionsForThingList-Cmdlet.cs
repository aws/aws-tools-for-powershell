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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Lists the job executions for the specified thing.
    /// </summary>
    [Cmdlet("Get", "IOTJobExecutionsForThingList")]
    [OutputType("Amazon.IoT.Model.JobExecutionSummaryForThing")]
    [AWSCmdlet("Calls the AWS IoT ListJobExecutionsForThing API operation.", Operation = new[] {"ListJobExecutionsForThing"})]
    [AWSCmdletOutput("Amazon.IoT.Model.JobExecutionSummaryForThing",
        "This cmdlet returns a collection of JobExecutionSummaryForThing objects.",
        "The service call response (type Amazon.IoT.Model.ListJobExecutionsForThingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetIOTJobExecutionsForThingListCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>An optional filter that lets you search for jobs that have the specified status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.JobExecutionStatus")]
        public Amazon.IoT.JobExecutionStatus Status { get; set; }
        #endregion
        
        #region Parameter ThingName
        /// <summary>
        /// <para>
        /// <para>The thing name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ThingName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned per request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
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
            
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Status = this.Status;
            context.ThingName = this.ThingName;
            
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
            var request = new Amazon.IoT.Model.ListJobExecutionsForThingRequest();
            
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResults.Value);
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.ThingName != null)
            {
                request.ThingName = cmdletContext.ThingName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ExecutionSummaries;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
        
        private Amazon.IoT.Model.ListJobExecutionsForThingResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.ListJobExecutionsForThingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "ListJobExecutionsForThing");
            try
            {
                #if DESKTOP
                return client.ListJobExecutionsForThing(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListJobExecutionsForThingAsync(request);
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
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.IoT.JobExecutionStatus Status { get; set; }
            public System.String ThingName { get; set; }
        }
        
    }
}
