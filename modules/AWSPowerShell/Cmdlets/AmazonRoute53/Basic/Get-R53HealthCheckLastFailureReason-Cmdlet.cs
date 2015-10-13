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
    /// If you want to learn why a health check is currently failing or why it failed most
    /// recently (if at all), you can get the failure reason for the most recent failure.
    /// Send a <code>GET</code> request to the <code>2013-04-01/healthcheck/<i>health check
    /// ID</i>/lastfailurereason</code> resource.
    /// </summary>
    [Cmdlet("Get", "R53HealthCheckLastFailureReason")]
    [OutputType("Amazon.Route53.Model.HealthCheckObservation")]
    [AWSCmdlet("Invokes the GetHealthCheckLastFailureReason operation against AWS Route 53.", Operation = new[] {"GetHealthCheckLastFailureReason"})]
    [AWSCmdletOutput("Amazon.Route53.Model.HealthCheckObservation",
        "This cmdlet returns a collection of HealthCheckObservation objects.",
        "The service call response (type Amazon.Route53.Model.GetHealthCheckLastFailureReasonResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetR53HealthCheckLastFailureReasonCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The ID of the health check for which you want to retrieve the reason for the most
        /// recent failure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String HealthCheckId { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.HealthCheckId = this.HealthCheckId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.GetHealthCheckLastFailureReasonRequest();
            
            if (cmdletContext.HealthCheckId != null)
            {
                request.HealthCheckId = cmdletContext.HealthCheckId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetHealthCheckLastFailureReason(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String HealthCheckId { get; set; }
        }
        
    }
}
