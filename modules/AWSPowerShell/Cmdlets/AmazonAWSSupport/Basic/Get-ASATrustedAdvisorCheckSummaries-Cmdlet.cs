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
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Returns the summaries of the results of the Trusted Advisor checks that have the specified
    /// check IDs. Check IDs can be obtained by calling <a>DescribeTrustedAdvisorChecks</a>.
    /// 
    ///  
    /// <para>
    /// The response contains an array of <a>TrustedAdvisorCheckSummary</a> objects.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ASATrustedAdvisorCheckSummaries")]
    [OutputType("Amazon.AWSSupport.Model.TrustedAdvisorCheckSummary")]
    [AWSCmdlet("Invokes the DescribeTrustedAdvisorCheckSummaries operation against AWS Support API.", Operation = new[] {"DescribeTrustedAdvisorCheckSummaries"})]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.TrustedAdvisorCheckSummary",
        "This cmdlet returns a collection of TrustedAdvisorCheckSummary objects.",
        "The service call response (type DescribeTrustedAdvisorCheckSummariesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetASATrustedAdvisorCheckSummariesCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The IDs of the Trusted Advisor checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("CheckIds")]
        public System.String[] CheckId { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.CheckId != null)
            {
                context.CheckIds = new List<String>(this.CheckId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeTrustedAdvisorCheckSummariesRequest();
            
            if (cmdletContext.CheckIds != null)
            {
                request.CheckIds = cmdletContext.CheckIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeTrustedAdvisorCheckSummaries(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Summaries;
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
            public List<String> CheckIds { get; set; }
        }
        
    }
}
