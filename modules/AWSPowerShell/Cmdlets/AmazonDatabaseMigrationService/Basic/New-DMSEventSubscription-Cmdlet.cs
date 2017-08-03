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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Creates an AWS DMS event notification subscription. 
    /// 
    ///  
    /// <para>
    /// You can specify the type of source (<code>SourceType</code>) you want to be notified
    /// of, provide a list of AWS DMS source IDs (<code>SourceIds</code>) that triggers the
    /// events, and provide a list of event categories (<code>EventCategories</code>) for
    /// events you want to be notified of. If you specify both the <code>SourceType</code>
    /// and <code>SourceIds</code>, such as <code>SourceType = replication-instance</code>
    /// and <code>SourceIdentifier = my-replinstance</code>, you will be notified of all the
    /// replication instance events for the specified source. If you specify a <code>SourceType</code>
    /// but don't specify a <code>SourceIdentifier</code>, you receive notice of the events
    /// for that source type for all your AWS DMS sources. If you don't specify either <code>SourceType</code>
    /// nor <code>SourceIdentifier</code>, you will be notified of events generated from all
    /// AWS DMS sources belonging to your customer account.
    /// </para><para>
    /// For more information about AWS DMS events, see <a href="http://docs.aws.amazon.com/dms/latest/userguide/CHAP_Events.html">
    /// Working with Events and Notifications </a> in the AWS Database MIgration Service User
    /// Guide.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DMSEventSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.EventSubscription")]
    [AWSCmdlet("Invokes the CreateEventSubscription operation against AWS Database Migration Service.", Operation = new[] {"CreateEventSubscription"})]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.EventSubscription",
        "This cmdlet returns a EventSubscription object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.CreateEventSubscriptionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDMSEventSubscriptionCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para> A Boolean value; set to <b>true</b> to activate the subscription, or set to <b>false</b>
        /// to create the subscription but not activate it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Enabled { get; set; }
        #endregion
        
        #region Parameter EventCategory
        /// <summary>
        /// <para>
        /// <para> A list of event categories for a source type that you want to subscribe to. You can
        /// see a list of the categories for a given source type by calling the <b>DescribeEventCategories</b>
        /// action or in the topic <a href="http://docs.aws.amazon.com/dms/latest/userguide/CHAP_Events.html">
        /// Working with Events and Notifications</a> in the AWS Database Migration Service User
        /// Guide. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventCategories")]
        public System.String[] EventCategory { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Amazon SNS topic created for event notification.
        /// The ARN is created by Amazon SNS when you create a topic and subscribe to it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter SourceId
        /// <summary>
        /// <para>
        /// <para> The list of identifiers of the event sources for which events will be returned. If
        /// not specified, then all sources are included in the response. An identifier must begin
        /// with a letter and must contain only ASCII letters, digits, and hyphens; it cannot
        /// end with a hyphen or contain two consecutive hyphens. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SourceIds")]
        public System.String[] SourceId { get; set; }
        #endregion
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para> The type of AWS DMS resource that generates the events. For example, if you want
        /// to be notified of events generated by a replication instance, you set this parameter
        /// to <code>replication-instance</code>. If this value is not specified, all events are
        /// returned. </para><para>Valid values: replication-instance | migration-task</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceType { get; set; }
        #endregion
        
        #region Parameter SubscriptionName
        /// <summary>
        /// <para>
        /// <para>The name of the DMS event notification subscription. </para><para>Constraints: The name must be less than 255 characters. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SubscriptionName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A tag to be attached to the event subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SubscriptionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DMSEventSubscription (CreateEventSubscription)"))
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
            
            if (ParameterWasBound("Enabled"))
                context.Enabled = this.Enabled;
            if (this.EventCategory != null)
            {
                context.EventCategories = new List<System.String>(this.EventCategory);
            }
            context.SnsTopicArn = this.SnsTopicArn;
            if (this.SourceId != null)
            {
                context.SourceIds = new List<System.String>(this.SourceId);
            }
            context.SourceType = this.SourceType;
            context.SubscriptionName = this.SubscriptionName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.DatabaseMigrationService.Model.CreateEventSubscriptionRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.EventCategories != null)
            {
                request.EventCategories = cmdletContext.EventCategories;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.DatabaseMigrationService.Model.CreateEventSubscriptionResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.CreateEventSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "CreateEventSubscription");
            #if DESKTOP
            return client.CreateEventSubscription(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateEventSubscriptionAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Boolean? Enabled { get; set; }
            public List<System.String> EventCategories { get; set; }
            public System.String SnsTopicArn { get; set; }
            public List<System.String> SourceIds { get; set; }
            public System.String SourceType { get; set; }
            public System.String SubscriptionName { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tags { get; set; }
        }
        
    }
}
