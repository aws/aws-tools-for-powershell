/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// While a cluster's <code>ClusterState</code> value is in the <code>AwaitingQuorum</code>
    /// state, you can update some of the information associated with a cluster. Once the
    /// cluster changes to a different job state, usually 60 minutes after the cluster being
    /// created, this action is no longer available.
    /// </summary>
    [Cmdlet("Update", "SNOWCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Import/Export Snowball UpdateCluster API operation.", Operation = new[] {"UpdateCluster"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ClusterId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Snowball.Model.UpdateClusterResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSNOWClusterCmdlet : AmazonSnowballClientCmdlet, IExecutor
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
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The cluster ID of the cluster that you want to update, for example <code>CID123e4567-e89b-12d3-a456-426655440000</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of this cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Resources_Ec2AmiResource
        /// <summary>
        /// <para>
        /// <para>The Amazon Machine Images (AMIs) associated with this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Resources_Ec2AmiResources")]
        public Amazon.Snowball.Model.Ec2AmiResource[] Resources_Ec2AmiResource { get; set; }
        #endregion
        
        #region Parameter ForwardingAddressId
        /// <summary>
        /// <para>
        /// <para>The updated ID for the forwarding address for a cluster. This field is not supported
        /// in most regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ForwardingAddressId { get; set; }
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
        
        #region Parameter Resources_LambdaResource
        /// <summary>
        /// <para>
        /// <para>The Python-language Lambda functions for this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Resources_LambdaResources")]
        public Amazon.Snowball.Model.LambdaResource[] Resources_LambdaResource { get; set; }
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
        /// <para>The new role Amazon Resource Name (ARN) that you want to associate with this cluster.
        /// To create a role ARN, use the <a href="http://docs.aws.amazon.com/IAM/latest/APIReference/API_CreateRole.html">CreateRole</a>
        /// API action in AWS Identity and Access Management (IAM).</para>
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
        /// <para>The updated shipping option value of this cluster's <a>ShippingDetails</a> object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Snowball.ShippingOption")]
        public Amazon.Snowball.ShippingOption ShippingOption { get; set; }
        #endregion
        
        #region Parameter Notification_SnsTopicARN
        /// <summary>
        /// <para>
        /// <para>The new SNS <code>TopicArn</code> that you want to associate with this job. You can
        /// create Amazon Resource Names (ARNs) for topics by using the <a href="http://docs.aws.amazon.com/sns/latest/api/API_CreateTopic.html">CreateTopic</a>
        /// Amazon SNS API action.</para><para>You can subscribe email addresses to an Amazon SNS topic through the AWS Management
        /// Console, or by using the <a href="http://docs.aws.amazon.com/sns/latest/api/API_Subscribe.html">Subscribe</a>
        /// AWS Simple Notification Service (SNS) API action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Notification_SnsTopicARN { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ClusterId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SNOWCluster (UpdateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AddressId = this.AddressId;
            context.ClusterId = this.ClusterId;
            context.Description = this.Description;
            context.ForwardingAddressId = this.ForwardingAddressId;
            if (this.Notification_JobStatesToNotify != null)
            {
                context.Notification_JobStatesToNotify = new List<System.String>(this.Notification_JobStatesToNotify);
            }
            if (ParameterWasBound("Notification_NotifyAll"))
                context.Notification_NotifyAll = this.Notification_NotifyAll;
            context.Notification_SnsTopicARN = this.Notification_SnsTopicARN;
            if (this.Resources_Ec2AmiResource != null)
            {
                context.Resources_Ec2AmiResources = new List<Amazon.Snowball.Model.Ec2AmiResource>(this.Resources_Ec2AmiResource);
            }
            if (this.Resources_LambdaResource != null)
            {
                context.Resources_LambdaResources = new List<Amazon.Snowball.Model.LambdaResource>(this.Resources_LambdaResource);
            }
            if (this.Resources_S3Resource != null)
            {
                context.Resources_S3Resources = new List<Amazon.Snowball.Model.S3Resource>(this.Resources_S3Resource);
            }
            context.RoleARN = this.RoleARN;
            context.ShippingOption = this.ShippingOption;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Snowball.Model.UpdateClusterRequest();
            
            if (cmdletContext.AddressId != null)
            {
                request.AddressId = cmdletContext.AddressId;
            }
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ForwardingAddressId != null)
            {
                request.ForwardingAddressId = cmdletContext.ForwardingAddressId;
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
            List<Amazon.Snowball.Model.Ec2AmiResource> requestResources_resources_Ec2AmiResource = null;
            if (cmdletContext.Resources_Ec2AmiResources != null)
            {
                requestResources_resources_Ec2AmiResource = cmdletContext.Resources_Ec2AmiResources;
            }
            if (requestResources_resources_Ec2AmiResource != null)
            {
                request.Resources.Ec2AmiResources = requestResources_resources_Ec2AmiResource;
                requestResourcesIsNull = false;
            }
            List<Amazon.Snowball.Model.LambdaResource> requestResources_resources_LambdaResource = null;
            if (cmdletContext.Resources_LambdaResources != null)
            {
                requestResources_resources_LambdaResource = cmdletContext.Resources_LambdaResources;
            }
            if (requestResources_resources_LambdaResource != null)
            {
                request.Resources.LambdaResources = requestResources_resources_LambdaResource;
                requestResourcesIsNull = false;
            }
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ClusterId;
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
        
        private Amazon.Snowball.Model.UpdateClusterResponse CallAWSServiceOperation(IAmazonSnowball client, Amazon.Snowball.Model.UpdateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Import/Export Snowball", "UpdateCluster");
            try
            {
                #if DESKTOP
                return client.UpdateCluster(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateClusterAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AddressId { get; set; }
            public System.String ClusterId { get; set; }
            public System.String Description { get; set; }
            public System.String ForwardingAddressId { get; set; }
            public List<System.String> Notification_JobStatesToNotify { get; set; }
            public System.Boolean? Notification_NotifyAll { get; set; }
            public System.String Notification_SnsTopicARN { get; set; }
            public List<Amazon.Snowball.Model.Ec2AmiResource> Resources_Ec2AmiResources { get; set; }
            public List<Amazon.Snowball.Model.LambdaResource> Resources_LambdaResources { get; set; }
            public List<Amazon.Snowball.Model.S3Resource> Resources_S3Resources { get; set; }
            public System.String RoleARN { get; set; }
            public Amazon.Snowball.ShippingOption ShippingOption { get; set; }
        }
        
    }
}
