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
    /// Returns the results of the Trusted Advisor check that has the specified check ID.
    /// Check IDs can be obtained by calling <a>DescribeTrustedAdvisorChecks</a>.
    /// 
    ///  
    /// <para>
    /// The response contains a <a>TrustedAdvisorCheckResult</a> object, which contains these
    /// three objects:
    /// </para><ul><li><a>TrustedAdvisorCategorySpecificSummary</a></li><li><a>TrustedAdvisorResourceDetail</a></li><li><a>TrustedAdvisorResourcesSummary</a></li></ul><para>
    /// In addition, the response contains these fields:
    /// </para><ul><li><b>Status.</b> The alert status of the check: "ok" (green), "warning" (yellow),
    /// "error" (red), or "not_available".</li><li><b>Timestamp.</b> The time of the last
    /// refresh of the check.</li><li><b>CheckId.</b> The unique identifier for the check.</li></ul>
    /// </summary>
    [Cmdlet("Get", "ASATrustedAdvisorCheckResult")]
    [OutputType("Amazon.AWSSupport.Model.TrustedAdvisorCheckResult")]
    [AWSCmdlet("Invokes the DescribeTrustedAdvisorCheckResult operation against AWS Support API.", Operation = new[] {"DescribeTrustedAdvisorCheckResult"})]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.TrustedAdvisorCheckResult",
        "This cmdlet returns a TrustedAdvisorCheckResult object.",
        "The service call response (type DescribeTrustedAdvisorCheckResultResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetASATrustedAdvisorCheckResultCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the Trusted Advisor check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String CheckId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ISO 639-1 code for the language in which AWS provides support. AWS Support currently
        /// supports English ("en") and Japanese ("ja"). Language parameters must be passed explicitly
        /// for operations that take them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String Language { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CheckId = this.CheckId;
            context.Language = this.Language;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeTrustedAdvisorCheckResultRequest();
            
            if (cmdletContext.CheckId != null)
            {
                request.CheckId = cmdletContext.CheckId;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeTrustedAdvisorCheckResult(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Result;
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
            public String CheckId { get; set; }
            public String Language { get; set; }
        }
        
    }
}
