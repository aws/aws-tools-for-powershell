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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Creates an Amazon Redshift event notification subscription. This action requires
    /// an ARN (Amazon Resource Name) of an Amazon SNS topic created by either the Amazon
    /// Redshift console, the Amazon SNS console, or the Amazon SNS API. To obtain an ARN
    /// with Amazon SNS, you must create a topic in Amazon SNS and subscribe to the topic.
    /// The ARN is displayed in the SNS console. 
    /// 
    ///  
    /// <para>
    ///  You can specify the source type, and lists of Amazon Redshift source IDs, event categories,
    /// and event severities. Notifications will be sent for all events you want that match
    /// those criteria. For example, you can specify source type = cluster, source ID = my-cluster-1
    /// and mycluster2, event categories = Availability, Backup, and severity = ERROR. The
    /// subscription will only send notifications for those ERROR events in the Availability
    /// and Backup categories for the specified clusters. 
    /// </para><para>
    ///  If you specify both the source type and source IDs, such as source type = cluster
    /// and source identifier = my-cluster-1, notifications will be sent for all the cluster
    /// events for my-cluster-1. If you specify a source type but do not specify a source
    /// identifier, you will receive notice of the events for the objects of that type in
    /// your AWS account. If you do not specify either the SourceType nor the SourceIdentifier,
    /// you will be notified of events generated from all Amazon Redshift sources belonging
    /// to your AWS account. You must specify a source type if you specify a source ID. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "RSEventSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.EventSubscription")]
    [AWSCmdlet("Invokes the CreateEventSubscription operation against Amazon Redshift.", Operation = new[] {"CreateEventSubscription"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.EventSubscription",
        "This cmdlet returns a EventSubscription object.",
        "The service call response (type Amazon.Redshift.Model.CreateEventSubscriptionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewRSEventSubscriptionCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> A Boolean value; set to <code>true</code> to activate the subscription, set to <code>false</code>
        /// to create the subscription but not active it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Enabled { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Redshift event categories to be published by the event notification
        /// subscription.</para><para>Values: Configuration, Management, Monitoring, Security</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventCategories")]
        public System.String[] EventCategory { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Redshift event severity to be published by the event notification
        /// subscription.</para><para>Values: ERROR, INFO</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Severity { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Amazon SNS topic used to transmit the event
        /// notifications. The ARN is created by Amazon SNS when you create a topic and subscribe
        /// to it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnsTopicArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A list of one or more identifiers of Amazon Redshift source objects. All of the objects
        /// must be of the same type as was specified in the source type parameter. The event
        /// subscription will return only events generated by the specified objects. If not specified,
        /// then events are returned for all objects within the source type specified. </para><para>Example: my-cluster-1, my-cluster-2</para><para>Example: my-snapshot-20131010</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SourceIds")]
        public System.String[] SourceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The type of source that will be generating the events. For example, if you want to
        /// be notified of events generated by a cluster, you would set this parameter to cluster.
        /// If this value is not specified, events are returned for all Amazon Redshift objects
        /// in your AWS account. You must specify a source type in order to specify source IDs.
        /// </para><para>Valid values: cluster, cluster-parameter-group, cluster-security-group, and cluster-snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the event subscription to be created. </para><para>Constraints:</para><ul><li>Cannot be null, empty, or blank.</li><li>Must contain from 1 to 255 alphanumeric
        /// characters or hyphens.</li><li>First character must be a letter.</li><li>Cannot
        /// end with a hyphen or contain two consecutive hyphens.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscriptionName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of tag instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SubscriptionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSEventSubscription (CreateEventSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("Enabled"))
                context.Enabled = this.Enabled;
            if (this.EventCategory != null)
            {
                context.EventCategories = new List<System.String>(this.EventCategory);
            }
            context.Severity = this.Severity;
            context.SnsTopicArn = this.SnsTopicArn;
            if (this.SourceId != null)
            {
                context.SourceIds = new List<System.String>(this.SourceId);
            }
            context.SourceType = this.SourceType;
            context.SubscriptionName = this.SubscriptionName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Redshift.Model.Tag>(this.Tag);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Redshift.Model.CreateEventSubscriptionRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.EventCategories != null)
            {
                request.EventCategories = cmdletContext.EventCategories;
            }
            if (cmdletContext.Severity != null)
            {
                request.Severity = cmdletContext.Severity;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArn = cmdletContext.SnsTopicArn;
            }
            if (cmdletContext.SourceIds != null)
            {
                request.SourceIds = cmdletContext.SourceIds;
            }
            if (cmdletContext.SourceType != null)
            {
                request.SourceType = cmdletContext.SourceType;
            }
            if (cmdletContext.SubscriptionName != null)
            {
                request.SubscriptionName = cmdletContext.SubscriptionName;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateEventSubscription(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EventSubscription;
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
            public System.Boolean? Enabled { get; set; }
            public List<System.String> EventCategories { get; set; }
            public System.String Severity { get; set; }
            public System.String SnsTopicArn { get; set; }
            public List<System.String> SourceIds { get; set; }
            public System.String SourceType { get; set; }
            public System.String SubscriptionName { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tags { get; set; }
        }
        
    }
}
