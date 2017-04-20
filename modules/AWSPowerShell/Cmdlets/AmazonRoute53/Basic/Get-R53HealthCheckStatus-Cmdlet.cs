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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets status of a specified health check. Send a <code>GET</code> request to the <code>/2013-04-01/healthcheck/<i>health
    /// check ID</i>/status</code> resource. You can use this call to get a health check's
    /// current status.
    /// </summary>
    [Cmdlet("Get", "R53HealthCheckStatus")]
    [OutputType("Amazon.Route53.Model.HealthCheckObservation")]
    [AWSCmdlet("Invokes the GetHealthCheckStatus operation against Amazon Route 53.", Operation = new[] {"GetHealthCheckStatus"})]
    [AWSCmdletOutput("Amazon.Route53.Model.HealthCheckObservation",
        "This cmdlet returns a collection of HealthCheckObservation objects.",
        "The service call response (type Amazon.Route53.Model.GetHealthCheckStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53HealthCheckStatusCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter HealthCheckId
        /// <summary>
        /// <para>
        /// <para>The ID for the health check for which you want the current status. When you created
        /// the health check, <code>CreateHealthCheck</code> returned the ID in the response,
        /// in the <code>HealthCheckId</code> element.</para><note><para>If you want to check the status of a calculated health check, you must use the Amazon
        /// Route 53 console or the CloudWatch console. You can't use <code>GetHealthCheckStatus</code>
        /// to get the status of a calculated health check.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HealthCheckId { get; set; }
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
            
            context.HealthCheckId = this.HealthCheckId;
            
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
            var request = new Amazon.Route53.Model.GetHealthCheckStatusRequest();
            
            if (cmdletContext.HealthCheckId != null)
            {
                request.HealthCheckId = cmdletContext.HealthCheckId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.HealthCheckObservations;
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
        
        private Amazon.Route53.Model.GetHealthCheckStatusResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.GetHealthCheckStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "GetHealthCheckStatus");
            #if DESKTOP
            return client.GetHealthCheckStatus(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetHealthCheckStatusAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String HealthCheckId { get; set; }
        }
        
    }
}
