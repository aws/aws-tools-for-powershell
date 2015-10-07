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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the evaluation results for the specified AWS resource. The results indicate
    /// which AWS Config rules were used to evaluate the resource, when each rule was last
    /// used, and whether the resource complies with each rule.
    /// </summary>
    [Cmdlet("Get", "CFGComplianceDetailsByResource")]
    [OutputType("Amazon.ConfigService.Model.EvaluationResult")]
    [AWSCmdlet("Invokes the GetComplianceDetailsByResource operation against Amazon Config.", Operation = new[] {"GetComplianceDetailsByResource"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.EvaluationResult",
        "This cmdlet returns a collection of EvaluationResult objects.",
        "The service call response (type GetComplianceDetailsByResourceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetCFGComplianceDetailsByResourceCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Specify to filter the results by compliance. The valid values are <code>Compliant</code>,
        /// <code>NonCompliant</code>, and <code>NotApplicable</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComplianceTypes")]
        public System.String[] ComplianceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS resource for which you want compliance information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ResourceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The type of the AWS resource for which you want compliance information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ResourceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ComplianceType != null)
            {
                context.ComplianceTypes = new List<String>(this.ComplianceType);
            }
            context.NextToken = this.NextToken;
            context.ResourceId = this.ResourceId;
            context.ResourceType = this.ResourceType;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetComplianceDetailsByResourceRequest();
            
            if (cmdletContext.ComplianceTypes != null)
            {
                request.ComplianceTypes = cmdletContext.ComplianceTypes;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetComplianceDetailsByResource(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EvaluationResults;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<String> ComplianceTypes { get; set; }
            public String NextToken { get; set; }
            public String ResourceId { get; set; }
            public String ResourceType { get; set; }
        }
        
    }
}
