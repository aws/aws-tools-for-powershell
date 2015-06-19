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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates one or more flow logs to capture IP traffic for a specific network interface,
    /// subnet, or VPC. Flow logs are delivered to a specified log group in Amazon CloudWatch
    /// Logs. If you specify a VPC or subnet in the request, a log stream is created in CloudWatch
    /// Logs for each network interface in the subnet or VPC. Log streams can include information
    /// about accepted and rejected traffic to a network interface. You can view the data
    /// in your log streams using Amazon CloudWatch Logs. 
    /// 
    ///  
    /// <para>
    /// In your request, you must also specify an IAM role that has permission to publish
    /// logs to CloudWatch Logs.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2FlowLogs", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateFlowLogsResponse")]
    [AWSCmdlet("Invokes the CreateFlowLogs operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateFlowLogs"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateFlowLogsResponse",
        "This cmdlet returns a CreateFlowLogsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2FlowLogsCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">How
        /// to Ensure Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ClientToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN for the IAM role that's used to post flow logs to a CloudWatch Logs log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeliverLogsPermissionArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String LogGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more subnet, network interface, or VPC IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIds")]
        public System.String[] ResourceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The type of resource on which to create the flow log.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public FlowLogsResourceType ResourceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The type of traffic to log.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public TrafficType TrafficType { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LogGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2FlowLogs (CreateFlowLogs)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClientToken = this.ClientToken;
            context.DeliverLogsPermissionArn = this.DeliverLogsPermissionArn;
            context.LogGroupName = this.LogGroupName;
            if (this.ResourceId != null)
            {
                context.ResourceIds = new List<String>(this.ResourceId);
            }
            context.ResourceType = this.ResourceType;
            context.TrafficType = this.TrafficType;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateFlowLogsRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeliverLogsPermissionArn != null)
            {
                request.DeliverLogsPermissionArn = cmdletContext.DeliverLogsPermissionArn;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.ResourceIds != null)
            {
                request.ResourceIds = cmdletContext.ResourceIds;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.TrafficType != null)
            {
                request.TrafficType = cmdletContext.TrafficType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateFlowLogs(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String ClientToken { get; set; }
            public String DeliverLogsPermissionArn { get; set; }
            public String LogGroupName { get; set; }
            public List<String> ResourceIds { get; set; }
            public FlowLogsResourceType ResourceType { get; set; }
            public TrafficType TrafficType { get; set; }
        }
        
    }
}
