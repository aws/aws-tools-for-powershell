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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Creates an event notification subscription. This action requires a topic ARN (Amazon
    /// Resource Name) created by either the Neptune console, the SNS console, or the SNS
    /// API. To obtain an ARN with SNS, you must create a topic in Amazon SNS and subscribe
    /// to the topic. The ARN is displayed in the SNS console.
    /// 
    ///  
    /// <para>
    /// You can specify the type of source (SourceType) you want to be notified of, provide
    /// a list of Neptune sources (SourceIds) that triggers the events, and provide a list
    /// of event categories (EventCategories) for events you want to be notified of. For example,
    /// you can specify SourceType = db-instance, SourceIds = mydbinstance1, mydbinstance2
    /// and EventCategories = Availability, Backup.
    /// </para><para>
    /// If you specify both the SourceType and SourceIds, such as SourceType = db-instance
    /// and SourceIdentifier = myDBInstance1, you are notified of all the db-instance events
    /// for the specified source. If you specify a SourceType but do not specify a SourceIdentifier,
    /// you receive notice of the events for that source type for all your Neptune sources.
    /// If you do not specify either the SourceType nor the SourceIdentifier, you are notified
    /// of events generated from all Neptune sources belonging to your customer account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "NPTEventSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptune.Model.EventSubscription")]
    [AWSCmdlet("Calls the Amazon Neptune CreateEventSubscription API operation.", Operation = new[] {"CreateEventSubscription"})]
    [AWSCmdletOutput("Amazon.Neptune.Model.EventSubscription",
        "This cmdlet returns a EventSubscription object.",
        "The service call response (type Amazon.Neptune.Model.CreateEventSubscriptionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewNPTEventSubscriptionCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para> A Boolean value; set to <b>true</b> to activate the subscription, set to <b>false</b>
        /// to create the subscription but not active it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Enabled { get; set; }
        #endregion
        
        #region Parameter EventCategory
        /// <summary>
        /// <para>
        /// <para> A list of event categories for a SourceType that you want to subscribe to. You can
        /// see a list of the categories for a given SourceType by using the <b>DescribeEventCategories</b>
        /// action. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventCategories")]
        public System.String[] EventCategory { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the SNS topic created for event notification. The
        /// ARN is created by Amazon SNS when you create a topic and subscribe to it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter SourceId
        /// <summary>
        /// <para>
        /// <para>The list of identifiers of the event sources for which events are returned. If not
        /// specified, then all sources are included in the response. An identifier must begin
        /// with a letter and must contain only ASCII letters, digits, and hyphens; it can't end
        /// with a hyphen or contain two consecutive hyphens.</para><para>Constraints:</para><ul><li><para>If SourceIds are supplied, SourceType must also be provided.</para></li><li><para>If the source type is a DB instance, then a <code>DBInstanceIdentifier</code> must
        /// be supplied.</para></li><li><para>If the source type is a DB security group, a <code>DBSecurityGroupName</code> must
        /// be supplied.</para></li><li><para>If the source type is a DB parameter group, a <code>DBParameterGroupName</code> must
        /// be supplied.</para></li><li><para>If the source type is a DB snapshot, a <code>DBSnapshotIdentifier</code> must be supplied.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SourceIds")]
        public System.String[] SourceId { get; set; }
        #endregion
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para>The type of source that is generating the events. For example, if you want to be notified
        /// of events generated by a DB instance, you would set this parameter to db-instance.
        /// if this value is not specified, all events are returned.</para><para>Valid values: <code>db-instance</code> | <code>db-cluster</code> | <code>db-parameter-group</code>
        /// | <code>db-security-group</code> | <code>db-snapshot</code> | <code>db-cluster-snapshot</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceType { get; set; }
        #endregion
        
        #region Parameter SubscriptionName
        /// <summary>
        /// <para>
        /// <para>The name of the subscription.</para><para>Constraints: The name must be less than 255 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SubscriptionName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Neptune.Model.Tag[] Tag { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NPTEventSubscription (CreateEventSubscription)"))
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
                context.Tags = new List<Amazon.Neptune.Model.Tag>(this.Tag);
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
            var request = new Amazon.Neptune.Model.CreateEventSubscriptionRequest();
            
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
        
        private Amazon.Neptune.Model.CreateEventSubscriptionResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.CreateEventSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "CreateEventSubscription");
            try
            {
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
            public System.Boolean? Enabled { get; set; }
            public List<System.String> EventCategories { get; set; }
            public System.String SnsTopicArn { get; set; }
            public List<System.String> SourceIds { get; set; }
            public System.String SourceType { get; set; }
            public System.String SubscriptionName { get; set; }
            public List<Amazon.Neptune.Model.Tag> Tags { get; set; }
        }
        
    }
}
