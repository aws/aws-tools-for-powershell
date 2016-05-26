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
    /// Submits feedback about the status of an instance. The instance must be in the <code>running</code>
    /// state. If your experience with the instance differs from the instance status returned
    /// by <a>DescribeInstanceStatus</a>, use <a>ReportInstanceStatus</a> to report your experience
    /// with the instance. Amazon EC2 collects this information to improve the accuracy of
    /// status checks.
    /// 
    ///  
    /// <para>
    /// Use of this action does not change the value returned by <a>DescribeInstanceStatus</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "EC2InstanceStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ReportInstanceStatus operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ReportInstanceStatus"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Instance parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.ReportInstanceStatusResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SendEC2InstanceStatusCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Descriptive text about the health state of your instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 5)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The time at which the reported instance health state ended.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter Instance
        /// <summary>
        /// <para>
        /// <para>One or more instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("InstanceId","Instances")]
        public System.String[] Instance { get; set; }
        #endregion
        
        #region Parameter ReasonCode
        /// <summary>
        /// <para>
        /// <para>One or more reason codes that describes the health state of your instance.</para><ul><li><para><code>instance-stuck-in-state</code>: My instance is stuck in a state.</para></li><li><para><code>unresponsive</code>: My instance is unresponsive.</para></li><li><para><code>not-accepting-credentials</code>: My instance is not accepting my credentials.</para></li><li><para><code>password-not-available</code>: A password is not available for my instance.</para></li><li><para><code>performance-network</code>: My instance is experiencing performance problems
        /// which I believe are network related.</para></li><li><para><code>performance-instance-store</code>: My instance is experiencing performance problems
        /// which I believe are related to the instance stores.</para></li><li><para><code>performance-ebs-volume</code>: My instance is experiencing performance problems
        /// which I believe are related to an EBS volume.</para></li><li><para><code>performance-other</code>: My instance is experiencing performance problems.</para></li><li><para><code>other</code>: [explain using the description parameter]</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        [Alias("ReasonCodes")]
        public System.String[] ReasonCode { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The time at which the reported instance health state began.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of all instances listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.ReportStatusType")]
        public Amazon.EC2.ReportStatusType Status { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Instance parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Instance", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-EC2InstanceStatus (ReportInstanceStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Description = this.Description;
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            if (this.Instance != null)
            {
                context.Instances = new List<System.String>(this.Instance);
            }
            if (this.ReasonCode != null)
            {
                context.ReasonCodes = new List<System.String>(this.ReasonCode);
            }
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            context.Status = this.Status;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.ReportInstanceStatusRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Instances != null)
            {
                request.Instances = cmdletContext.Instances;
            }
            if (cmdletContext.ReasonCodes != null)
            {
                request.ReasonCodes = cmdletContext.ReasonCodes;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.Instance;
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
        
        private static Amazon.EC2.Model.ReportInstanceStatusResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ReportInstanceStatusRequest request)
        {
            return client.ReportInstanceStatus(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Description { get; set; }
            public System.DateTime? EndTime { get; set; }
            public List<System.String> Instances { get; set; }
            public List<System.String> ReasonCodes { get; set; }
            public System.DateTime? StartTime { get; set; }
            public Amazon.EC2.ReportStatusType Status { get; set; }
        }
        
    }
}
