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
using Amazon.Snowball;
using Amazon.Snowball.Model;

namespace Amazon.PowerShell.Cmdlets.SNOW
{
    /// <summary>
    /// While a job's <code>JobState</code> value is <code>New</code>, you can update some
    /// of the information associated with a job. Once the job changes to a different job
    /// state, usually within 60 minutes of the job being created, this action is no longer
    /// available.
    /// </summary>
    [Cmdlet("Update", "SNOWJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateJob operation against AWS Import/Export Snowball.", Operation = new[] {"UpdateJob"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the JobId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Snowball.Model.UpdateJobResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateSNOWJobCmdlet : AmazonSnowballClientCmdlet, IExecutor
    {
        
        #region Parameter AddressId
        /// <summary>
        /// <para>
        /// <para>The ID of the updated <a>Address</a> object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AddressId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of this job's <a>JobMetadata</a> object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The job ID of the job that you want to update, for example <code>JID123e4567-e89b-12d3-a456-426655440000</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter Notification_JobStatesToNotify
        /// <summary>
        /// <para>
        /// <para>The list of job states that will trigger a notification for this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] Notification_JobStatesToNotify { get; set; }
        #endregion
        
        #region Parameter Notification_NotifyAll
        /// <summary>
        /// <para>
        /// <para>Any change in job state will trigger a notification for this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Notification_NotifyAll { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The new role Amazon Resource Name (ARN) that you want to associate with this job.
        /// To create a role ARN, use the <a href="http://docs.aws.amazon.com/IAM/latest/APIReference/API_CreateRole.html">CreateRole</a>
        /// AWS Identity and Access Management (IAM) API action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter Resources_S3Resource
        /// <summary>
        /// <para>
        /// <para>An array of <code>S3Resource</code> objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Resources_S3Resources")]
        public Amazon.Snowball.Model.S3Resource[] Resources_S3Resource { get; set; }
        #endregion
        
        #region Parameter ShippingOption
        /// <summary>
        /// <para>
        /// <para>The updated shipping option value of this job's <a>ShippingDetails</a> object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Snowball.ShippingOption")]
        public Amazon.Snowball.ShippingOption ShippingOption { get; set; }
        #endregion
        
        #region Parameter SnowballCapacityPreference
        /// <summary>
        /// <para>
        /// <para>The updated <code>SnowballCapacityPreference</code> of this job's <a>JobMetadata</a>
        /// object. Note that the 50 TB Snowballs are only available in the US regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Snowball.SnowballCapacity")]
        public Amazon.Snowball.SnowballCapacity SnowballCapacityPreference { get; set; }
        #endregion
        
        #region Parameter Notification_SnsTopicARN
        /// <summary>
        /// <para>
        /// <para>The new SNS <code>TopicArn</code> that you want to associate with this job. You can
        /// create Amazon Resource Names (ARNs) for topics by using the <a href="http://docs.aws.amazon.com/sns/latest/api/API_CreateTopic.html">CreateTopic</a>
        /// Amazon SNS API action.</para><para>Note that you can subscribe email addresses to an Amazon SNS topic through the AWS
        /// Management Console, or by using the <a href="http://docs.aws.amazon.com/sns/latest/api/API_Subscribe.html">Subscribe</a>
        /// AWS Simple Notification Service (SNS) API action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Notification_SnsTopicARN { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the JobId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SNOWJob (UpdateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AddressId = this.AddressId;
            context.Description = this.Description;
            context.JobId = this.JobId;
            if (this.Notification_JobStatesToNotify != null)
            {
                context.Notification_JobStatesToNotify = new List<System.String>(this.Notification_JobStatesToNotify);
            }
            if (ParameterWasBound("Notification_NotifyAll"))
                context.Notification_NotifyAll = this.Notification_NotifyAll;
            context.Notification_SnsTopicARN = this.Notification_SnsTopicARN;
            if (this.Resources_S3Resource != null)
            {
                context.Resources_S3Resources = new List<Amazon.Snowball.Model.S3Resource>(this.Resources_S3Resource);
            }
            context.RoleARN = this.RoleARN;
            context.ShippingOption = this.ShippingOption;
            context.SnowballCapacityPreference = this.SnowballCapacityPreference;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Snowball.Model.UpdateJobRequest();
            
            if (cmdletContext.AddressId != null)
            {
                request.AddressId = cmdletContext.AddressId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            
             // populate Notification
            bool requestNotificationIsNull = true;
            request.Notification = new Amazon.Snowball.Model.Notification();
            List<System.String> requestNotification_notification_JobStatesToNotify = null;
            if (cmdletContext.Notification_JobStatesToNotify != null)
            {
                requestNotification_notification_JobStatesToNotify = cmdletContext.Notification_JobStatesToNotify;
            }
            if (requestNotification_notification_JobStatesToNotify != null)
            {
                request.Notification.JobStatesToNotify = requestNotification_notification_JobStatesToNotify;
                requestNotificationIsNull = false;
            }
            System.Boolean? requestNotification_notification_NotifyAll = null;
            if (cmdletContext.Notification_NotifyAll != null)
            {
                requestNotification_notification_NotifyAll = cmdletContext.Notification_NotifyAll.Value;
            }
            if (requestNotification_notification_NotifyAll != null)
            {
                request.Notification.NotifyAll = requestNotification_notification_NotifyAll.Value;
                requestNotificationIsNull = false;
            }
            System.String requestNotification_notification_SnsTopicARN = null;
            if (cmdletContext.Notification_SnsTopicARN != null)
            {
                requestNotification_notification_SnsTopicARN = cmdletContext.Notification_SnsTopicARN;
            }
            if (requestNotification_notification_SnsTopicARN != null)
            {
                request.Notification.SnsTopicARN = requestNotification_notification_SnsTopicARN;
                requestNotificationIsNull = false;
            }
             // determine if request.Notification should be set to null
            if (requestNotificationIsNull)
            {
                request.Notification = null;
            }
            
             // populate Resources
            bool requestResourcesIsNull = true;
            request.Resources = new Amazon.Snowball.Model.JobResource();
            List<Amazon.Snowball.Model.S3Resource> requestResources_resources_S3Resource = null;
            if (cmdletContext.Resources_S3Resources != null)
            {
                requestResources_resources_S3Resource = cmdletContext.Resources_S3Resources;
            }
            if (requestResources_resources_S3Resource != null)
            {
                request.Resources.S3Resources = requestResources_resources_S3Resource;
                requestResourcesIsNull = false;
            }
             // determine if request.Resources should be set to null
            if (requestResourcesIsNull)
            {
                request.Resources = null;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            if (cmdletContext.ShippingOption != null)
            {
                request.ShippingOption = cmdletContext.ShippingOption;
            }
            if (cmdletContext.SnowballCapacityPreference != null)
            {
                request.SnowballCapacityPreference = cmdletContext.SnowballCapacityPreference;
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
                    pipelineOutput = this.JobId;
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
        
        private static Amazon.Snowball.Model.UpdateJobResponse CallAWSServiceOperation(IAmazonSnowball client, Amazon.Snowball.Model.UpdateJobRequest request)
        {
            return client.UpdateJob(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AddressId { get; set; }
            public System.String Description { get; set; }
            public System.String JobId { get; set; }
            public List<System.String> Notification_JobStatesToNotify { get; set; }
            public System.Boolean? Notification_NotifyAll { get; set; }
            public System.String Notification_SnsTopicARN { get; set; }
            public List<Amazon.Snowball.Model.S3Resource> Resources_S3Resources { get; set; }
            public System.String RoleARN { get; set; }
            public Amazon.Snowball.ShippingOption ShippingOption { get; set; }
            public Amazon.Snowball.SnowballCapacity SnowballCapacityPreference { get; set; }
        }
        
    }
}
