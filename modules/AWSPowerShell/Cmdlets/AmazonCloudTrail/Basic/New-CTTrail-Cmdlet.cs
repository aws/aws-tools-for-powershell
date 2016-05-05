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
    /// Creates a trail that specifies the settings for delivery of log data to an Amazon
    /// S3 bucket. A maximum of five trails can exist in a region, irrespective of the region
    /// in which they were created.
    /// </summary>
    [Cmdlet("New", "CTTrail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.CreateTrailResponse")]
    [AWSCmdlet("Invokes the CreateTrail operation against AWS CloudTrail.", Operation = new[] {"CreateTrail"})]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.CreateTrailResponse",
        "This cmdlet returns a Amazon.CloudTrail.Model.CreateTrailResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewCTTrailCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        #region Parameter CloudWatchLogsLogGroupArn
        /// <summary>
        /// <para>
        /// <para>Specifies a log group name using an Amazon Resource Name (ARN), a unique identifier
        /// that represents the log group to which CloudTrail logs will be delivered. Not required
        /// unless you specify CloudWatchLogsRoleArn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloudWatchLogsLogGroupArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsRoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies the role for the CloudWatch Logs endpoint to assume to write to a user's
        /// log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloudWatchLogsRoleArn { get; set; }
        #endregion
        
        #region Parameter EnableLogFileValidation
        /// <summary>
        /// <para>
        /// <para>Specifies whether log file integrity validation is enabled. The default is false.</para><note><para>When you disable log file integrity validation, the chain of digest files is broken
        /// after one hour. CloudTrail will not create digest files for log files that were delivered
        /// during a period in which log file integrity validation was disabled. For example,
        /// if you enable log file integrity validation at noon on January 1, disable it at noon
        /// on January 2, and re-enable it at noon on January 10, digest files will not be created
        /// for the log files delivered from noon on January 2 to noon on January 10. The same
        /// applies whenever you stop CloudTrail logging or delete a trail.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableLogFileValidation { get; set; }
        #endregion
        
        #region Parameter IncludeGlobalServiceEvent
        /// <summary>
        /// <para>
        /// <para>Specifies whether the trail is publishing events from global services such as IAM
        /// to the log files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IncludeGlobalServiceEvents")]
        public System.Boolean IncludeGlobalServiceEvent { get; set; }
        #endregion
        
        #region Parameter IsMultiRegionTrail
        /// <summary>
        /// <para>
        /// <para>Specifies whether the trail is created in the current region or in all regions. The
        /// default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean IsMultiRegionTrail { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>Specifies the KMS key ID to use to encrypt the logs delivered by CloudTrail. The value
        /// can be a an alias name prefixed by "alias/", a fully specified ARN to an alias, a
        /// fully specified ARN to a key, or a globally unique identifier.</para><para>Examples:</para><ul><li><para>alias/MyAliasName</para></li><li><para>arn:aws:kms:us-east-1:123456789012:alias/MyAliasName</para></li><li><para>arn:aws:kms:us-east-1:123456789012:key/12345678-1234-1234-1234-123456789012</para></li><li><para>12345678-1234-1234-1234-123456789012</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the trail. The name must meet the following requirements:</para><ul><li><para>Contain only ASCII letters (a-z, A-Z), numbers (0-9), periods (.), underscores (_),
        /// or dashes (-)</para></li><li><para>Start with a letter or number, and end with a letter or number</para></li><li><para>Be between 3 and 128 characters</para></li><li><para>Have no adjacent periods, underscores or dashes. Names like <code>my-_namespace</code>
        /// and <code>my--namespace</code> are invalid.</para></li><li><para>Not be in IP address format (for example, 192.168.5.4)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3BucketName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket designated for publishing log files. See
        /// <a href="http://docs.aws.amazon.com/awscloudtrail/latest/userguide/create_trail_naming_policy.html">Amazon
        /// S3 Bucket Naming Requirements</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String S3BucketName { get; set; }
        #endregion
        
        #region Parameter S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key prefix that comes after the name of the bucket you have
        /// designated for log file delivery. For more information, see <a href="http://docs.aws.amazon.com/awscloudtrail/latest/userguide/cloudtrail-find-log-files.html">Finding
        /// Your CloudTrail Log Files</a>. The maximum length is 200 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter SnsTopicName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon SNS topic defined for notification of log file delivery.
        /// The maximum length is 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnsTopicName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CTTrail (CreateTrail)"))
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
            if (ParameterWasBound("EnableLogFileValidation"))
                context.EnableLogFileValidation = this.EnableLogFileValidation;
            if (ParameterWasBound("IncludeGlobalServiceEvent"))
                context.IncludeGlobalServiceEvents = this.IncludeGlobalServiceEvent;
            if (ParameterWasBound("IsMultiRegionTrail"))
                context.IsMultiRegionTrail = this.IsMultiRegionTrail;
            context.KmsKeyId = this.KmsKeyId;
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
            var request = new Amazon.CloudTrail.Model.CreateTrailRequest();
            
            if (cmdletContext.CloudWatchLogsLogGroupArn != null)
            {
                request.CloudWatchLogsLogGroupArn = cmdletContext.CloudWatchLogsLogGroupArn;
            }
            if (cmdletContext.CloudWatchLogsRoleArn != null)
            {
                request.CloudWatchLogsRoleArn = cmdletContext.CloudWatchLogsRoleArn;
            }
            if (cmdletContext.EnableLogFileValidation != null)
            {
                request.EnableLogFileValidation = cmdletContext.EnableLogFileValidation.Value;
            }
            if (cmdletContext.IncludeGlobalServiceEvents != null)
            {
                request.IncludeGlobalServiceEvents = cmdletContext.IncludeGlobalServiceEvents.Value;
            }
            if (cmdletContext.IsMultiRegionTrail != null)
            {
                request.IsMultiRegionTrail = cmdletContext.IsMultiRegionTrail.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
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
                var response = client.CreateTrail(request);
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
            public System.String CloudWatchLogsLogGroupArn { get; set; }
            public System.String CloudWatchLogsRoleArn { get; set; }
            public System.Boolean? EnableLogFileValidation { get; set; }
            public System.Boolean? IncludeGlobalServiceEvents { get; set; }
            public System.Boolean? IsMultiRegionTrail { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public System.String S3BucketName { get; set; }
            public System.String S3KeyPrefix { get; set; }
            public System.String SnsTopicName { get; set; }
        }
        
    }
}
