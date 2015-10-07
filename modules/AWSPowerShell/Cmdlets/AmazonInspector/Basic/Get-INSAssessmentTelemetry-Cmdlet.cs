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
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Returns the metadata about the telemetry (application behavioral data) for the assessment
    /// specified by the assessment ARN.
    /// </summary>
    [Cmdlet("Get", "INSAssessmentTelemetry")]
    [OutputType("Amazon.Inspector.Model.Telemetry")]
    [AWSCmdlet("Invokes the GetAssessmentTelemetry operation against Amazon Inspector.", Operation = new[] {"GetAssessmentTelemetry"})]
    [AWSCmdletOutput("Amazon.Inspector.Model.Telemetry",
        "This cmdlet returns a collection of Telemetry objects.",
        "The service call response (type GetAssessmentTelemetryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetINSAssessmentTelemetryCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The ARN specifying the assessment the telemetry of which you want to obtain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String AssessmentArn { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AssessmentArn = this.AssessmentArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetAssessmentTelemetryRequest();
            
            if (cmdletContext.AssessmentArn != null)
            {
                request.AssessmentArn = cmdletContext.AssessmentArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetAssessmentTelemetry(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Telemetry;
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
            public String AssessmentArn { get; set; }
        }
        
    }
}
