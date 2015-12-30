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
    /// Returns the number of resources that are compliant and the number that are noncompliant.
    /// You can specify one or more resource types to get these numbers for each resource
    /// type. The maximum number returned is 100.
    /// </summary>
    [Cmdlet("Get", "CFGComplianceSummaryByResourceType")]
    [OutputType("Amazon.ConfigService.Model.ComplianceSummaryByResourceType")]
    [AWSCmdlet("Invokes the GetComplianceSummaryByResourceType operation against AWS Config.", Operation = new[] {"GetComplianceSummaryByResourceType"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ComplianceSummaryByResourceType",
        "This cmdlet returns a collection of ComplianceSummaryByResourceType objects.",
        "The service call response (type Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCFGComplianceSummaryByResourceTypeCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Specify one or more resource types to get the number of resources that are compliant
        /// and the number that are noncompliant for each resource type.</para><para>For this request, you can specify an AWS resource type such as <code>AWS::EC2::Instance</code>,
        /// and you can specify that the resource type is an AWS account by specifying <code>AWS::::Account</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ResourceType != null)
            {
                context.ResourceTypes = new List<System.String>(this.ResourceType);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ConfigService.Model.GetComplianceSummaryByResourceTypeRequest();
            
            if (cmdletContext.ResourceTypes != null)
            {
                request.ResourceTypes = cmdletContext.ResourceTypes;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetComplianceSummaryByResourceType(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ComplianceSummariesByResourceType;
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
            public List<System.String> ResourceTypes { get; set; }
        }
        
    }
}
