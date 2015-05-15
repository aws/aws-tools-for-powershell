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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Lists the deployments within a deployment group for an application registered with
    /// the applicable IAM user or AWS account.
    /// </summary>
    [Cmdlet("Get", "CDDeploymentList")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListDeployments operation against Amazon CodeDeploy.", Operation = new[] {"ListDeployments"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type ListDeploymentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetCDDeploymentListCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of an existing AWS CodeDeploy application associated with the applicable
        /// IAM user or AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String ApplicationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of an existing deployment group for the specified application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeploymentGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The time range's end time.</para><note>Specify null to leave the time range's end time open-ended.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime CreateTimeRange_End { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A subset of deployments to list, by status:</para><ul><li>Created: Include in the resulting list created deployments.</li><li>Queued:
        /// Include in the resulting list queued deployments.</li><li>In Progress: Include in
        /// the resulting list in-progress deployments.</li><li>Succeeded: Include in the resulting
        /// list succeeded deployments.</li><li>Failed: Include in the resulting list failed
        /// deployments.</li><li>Aborted: Include in the resulting list aborted deployments.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IncludeOnlyStatuses")]
        public System.String[] IncludeOnlyStatus { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The time range's start time.</para><note>Specify null to leave the time range's start time open-ended.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime CreateTimeRange_Start { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An identifier that was returned from the previous list deployments call, which can
        /// be used to return the next set of deployments in the list.</para>
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
            
            context.ApplicationName = this.ApplicationName;
            if (ParameterWasBound("CreateTimeRange_End"))
                context.CreateTimeRange_End = this.CreateTimeRange_End;
            if (ParameterWasBound("CreateTimeRange_Start"))
                context.CreateTimeRange_Start = this.CreateTimeRange_Start;
            context.DeploymentGroupName = this.DeploymentGroupName;
            if (this.IncludeOnlyStatus != null)
            {
                context.IncludeOnlyStatuses = new List<String>(this.IncludeOnlyStatus);
            }
            context.NextToken = this.NextToken;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ListDeploymentsRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            
             // populate CreateTimeRange
            bool requestCreateTimeRangeIsNull = true;
            request.CreateTimeRange = new TimeRange();
            DateTime? requestCreateTimeRange_createTimeRange_End = null;
            if (cmdletContext.CreateTimeRange_End != null)
            {
                requestCreateTimeRange_createTimeRange_End = cmdletContext.CreateTimeRange_End.Value;
            }
            if (requestCreateTimeRange_createTimeRange_End != null)
            {
                request.CreateTimeRange.End = requestCreateTimeRange_createTimeRange_End.Value;
                requestCreateTimeRangeIsNull = false;
            }
            DateTime? requestCreateTimeRange_createTimeRange_Start = null;
            if (cmdletContext.CreateTimeRange_Start != null)
            {
                requestCreateTimeRange_createTimeRange_Start = cmdletContext.CreateTimeRange_Start.Value;
            }
            if (requestCreateTimeRange_createTimeRange_Start != null)
            {
                request.CreateTimeRange.Start = requestCreateTimeRange_createTimeRange_Start.Value;
                requestCreateTimeRangeIsNull = false;
            }
             // determine if request.CreateTimeRange should be set to null
            if (requestCreateTimeRangeIsNull)
            {
                request.CreateTimeRange = null;
            }
            if (cmdletContext.DeploymentGroupName != null)
            {
                request.DeploymentGroupName = cmdletContext.DeploymentGroupName;
            }
            if (cmdletContext.IncludeOnlyStatuses != null)
            {
                request.IncludeOnlyStatuses = cmdletContext.IncludeOnlyStatuses;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListDeployments(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Deployments;
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
            public String ApplicationName { get; set; }
            public DateTime? CreateTimeRange_End { get; set; }
            public DateTime? CreateTimeRange_Start { get; set; }
            public String DeploymentGroupName { get; set; }
            public List<String> IncludeOnlyStatuses { get; set; }
            public String NextToken { get; set; }
        }
        
    }
}
