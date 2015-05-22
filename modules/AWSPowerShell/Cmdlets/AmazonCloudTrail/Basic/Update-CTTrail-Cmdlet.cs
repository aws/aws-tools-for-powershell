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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// From the command line, use <code>update-subscription</code>.
    /// 
    ///  
    /// <para>
    /// Updates the settings that specify delivery of log files. Changes to a trail do not
    /// require stopping the CloudTrail service. Use this action to designate an existing
    /// bucket for log delivery. If the existing bucket has previously been a target for CloudTrail
    /// log files, an IAM policy exists for the bucket. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CTTrail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.UpdateTrailResponse")]
    [AWSCmdlet("Invokes the UpdateTrail operation against AWS CloudTrail.", Operation = new[] {"UpdateTrail"})]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.UpdateTrailResponse",
        "This cmdlet returns a UpdateTrailResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateCTTrailCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Specifies a log group name using an Amazon Resource Name (ARN), a unique identifier
        /// that represents the log group to which CloudTrail logs will be delivered. Not required
        /// unless you specify CloudWatchLogsRoleArn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CloudWatchLogsLogGroupArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the role for the CloudWatch Logs endpoint to assume to write to a user’s
        /// log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CloudWatchLogsRoleArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies whether the trail is publishing events from global services such as IAM
        /// to the log files. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean IncludeGlobalServiceEvents { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the trail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket designated for publishing log files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String S3BucketName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key prefix that precedes the name of the bucket you have designated
        /// for log file delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public String S3KeyPrefix { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon SNS topic defined for notification of log file delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String SnsTopicName { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CTTrail (UpdateTrail)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CloudWatchLogsLogGroupArn = this.CloudWatchLogsLogGroupArn;
            context.CloudWatchLogsRoleArn = this.CloudWatchLogsRoleArn;
            if (ParameterWasBound("IncludeGlobalServiceEvents"))
                context.IncludeGlobalServiceEvents = this.IncludeGlobalServiceEvents;
            context.Name = this.Name;
            context.S3BucketName = this.S3BucketName;
            context.S3KeyPrefix = this.S3KeyPrefix;
            context.SnsTopicName = this.SnsTopicName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateTrailRequest();
            
            if (cmdletContext.CloudWatchLogsLogGroupArn != null)
            {
                request.CloudWatchLogsLogGroupArn = cmdletContext.CloudWatchLogsLogGroupArn;
            }
            if (cmdletContext.CloudWatchLogsRoleArn != null)
            {
                request.CloudWatchLogsRoleArn = cmdletContext.CloudWatchLogsRoleArn;
            }
            if (cmdletContext.IncludeGlobalServiceEvents != null)
            {
                request.IncludeGlobalServiceEvents = cmdletContext.IncludeGlobalServiceEvents.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.S3BucketName != null)
            {
                request.S3BucketName = cmdletContext.S3BucketName;
            }
            if (cmdletContext.S3KeyPrefix != null)
            {
                request.S3KeyPrefix = cmdletContext.S3KeyPrefix;
            }
            if (cmdletContext.SnsTopicName != null)
            {
                request.SnsTopicName = cmdletContext.SnsTopicName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateTrail(request);
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
            public String CloudWatchLogsLogGroupArn { get; set; }
            public String CloudWatchLogsRoleArn { get; set; }
            public Boolean? IncludeGlobalServiceEvents { get; set; }
            public String Name { get; set; }
            public String S3BucketName { get; set; }
            public String S3KeyPrefix { get; set; }
            public String SnsTopicName { get; set; }
        }
        
    }
}
