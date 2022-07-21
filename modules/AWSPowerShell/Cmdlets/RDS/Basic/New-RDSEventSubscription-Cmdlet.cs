/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates an RDS event notification subscription. This operation requires a topic Amazon
    /// Resource Name (ARN) created by either the RDS console, the SNS console, or the SNS
    /// API. To obtain an ARN with SNS, you must create a topic in Amazon SNS and subscribe
    /// to the topic. The ARN is displayed in the SNS console.
    /// 
    ///  
    /// <para>
    /// You can specify the type of source (<code>SourceType</code>) that you want to be notified
    /// of and provide a list of RDS sources (<code>SourceIds</code>) that triggers the events.
    /// You can also provide a list of event categories (<code>EventCategories</code>) for
    /// events that you want to be notified of. For example, you can specify <code>SourceType</code>
    /// = <code>db-instance</code>, <code>SourceIds</code> = <code>mydbinstance1</code>, <code>mydbinstance2</code>
    /// and <code>EventCategories</code> = <code>Availability</code>, <code>Backup</code>.
    /// </para><para>
    /// If you specify both the <code>SourceType</code> and <code>SourceIds</code>, such as
    /// <code>SourceType</code> = <code>db-instance</code> and <code>SourceIds</code> = <code>myDBInstance1</code>,
    /// you are notified of all the <code>db-instance</code> events for the specified source.
    /// If you specify a <code>SourceType</code> but do not specify <code>SourceIds</code>,
    /// you receive notice of the events for that source type for all your RDS sources. If
    /// you don't specify either the SourceType or the <code>SourceIds</code>, you are notified
    /// of events generated from all RDS sources belonging to your customer account.
    /// </para><note><para>
    /// RDS event notification is only available for unencrypted SNS topics. If you specify
    /// an encrypted SNS topic, event notifications aren't sent for the topic.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "RDSEventSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.EventSubscription")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateEventSubscription API operation.", Operation = new[] {"CreateEventSubscription"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateEventSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.EventSubscription or Amazon.RDS.Model.CreateEventSubscriptionResponse",
        "This cmdlet returns an Amazon.RDS.Model.EventSubscription object.",
        "The service call response (type Amazon.RDS.Model.CreateEventSubscriptionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRDSEventSubscriptionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to activate the subscription. If the event notification
        /// subscription isn't activated, the subscription is created but not active.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter EventCategory
        /// <summary>
        /// <para>
        /// <para>A list of event categories for a particular source type (<code>SourceType</code>)
        /// that you want to subscribe to. You can see a list of the categories for a given source
        /// type in the "Amazon RDS event categories and event messages" section of the <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Events.Messages.html"><i>Amazon RDS User Guide</i></a> or the <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_Events.Messages.html"><i>Amazon Aurora User Guide</i></a>. You can also see this list by using the <code>DescribeEventCategories</code>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter SourceId
        /// <summary>
        /// <para>
        /// <para>The list of identifiers of the event sources for which events are returned. If not
        /// specified, then all sources are included in the response. An identifier must begin
        /// with a letter and must contain only ASCII letters, digits, and hyphens. It can't end
        /// with a hyphen or contain two consecutive hyphens.</para><para>Constraints:</para><ul><li><para>If <code>SourceIds</code> are supplied, <code>SourceType</code> must also be provided.</para></li><li><para>If the source type is a DB instance, a <code>DBInstanceIdentifier</code> value must
        /// be supplied.</para></li><li><para>If the source type is a DB cluster, a <code>DBClusterIdentifier</code> value must
        /// be supplied.</para></li><li><para>If the source type is a DB parameter group, a <code>DBParameterGroupName</code> value
        /// must be supplied.</para></li><li><para>If the source type is a DB security group, a <code>DBSecurityGroupName</code> value
        /// must be supplied.</para></li><li><para>If the source type is a DB snapshot, a <code>DBSnapshotIdentifier</code> value must
        /// be supplied.</para></li><li><para>If the source type is a DB cluster snapshot, a <code>DBClusterSnapshotIdentifier</code>
        /// value must be supplied.</para></li><li><para>If the source type is an RDS Proxy, a <code>DBProxyName</code> value must be supplied.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceIds")]
        public System.String[] SourceId { get; set; }
        #endregion
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para>The type of source that is generating the events. For example, if you want to be notified
        /// of events generated by a DB instance, you set this parameter to <code>db-instance</code>.
        /// For RDS Proxy events, specify <code>db-proxy</code>. If this value isn't specified,
        /// all events are returned.</para><para>Valid values: <code>db-instance</code> | <code>db-cluster</code> | <code>db-parameter-group</code>
        /// | <code>db-security-group</code> | <code>db-snapshot</code> | <code>db-cluster-snapshot</code>
        /// | <code>db-proxy</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String SourceType { get; set; }
        #endregion
        
        #region Parameter SubscriptionName
        /// <summary>
        /// <para>
        /// <para>The name of the subscription.</para><para>Constraints: The name must be less than 255 characters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SubscriptionName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventSubscription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateEventSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateEventSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventSubscription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SubscriptionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SubscriptionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SubscriptionName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriptionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSEventSubscription (CreateEventSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateEventSubscriptionResponse, NewRDSEventSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SubscriptionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Enabled = this.Enabled;
            if (this.EventCategory != null)
            {
                context.EventCategory = new List<System.String>(this.EventCategory);
            }
            context.SnsTopicArn = this.SnsTopicArn;
            #if MODULAR
            if (this.SnsTopicArn == null && ParameterWasBound(nameof(this.SnsTopicArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SnsTopicArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SourceId != null)
            {
                context.SourceId = new List<System.String>(this.SourceId);
            }
            context.SourceType = this.SourceType;
            context.SubscriptionName = this.SubscriptionName;
            #if MODULAR
            if (this.SubscriptionName == null && ParameterWasBound(nameof(this.SubscriptionName)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
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
            var request = new Amazon.RDS.Model.CreateEventSubscriptionRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.EventCategory != null)
            {
                request.EventCategories = cmdletContext.EventCategory;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArn = cmdletContext.SnsTopicArn;
            }
            if (cmdletContext.SourceId != null)
            {
                request.SourceIds = cmdletContext.SourceId;
            }
            if (cmdletContext.SourceType != null)
            {
                request.SourceType = cmdletContext.SourceType;
            }
            if (cmdletContext.SubscriptionName != null)
            {
                request.SubscriptionName = cmdletContext.SubscriptionName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.RDS.Model.CreateEventSubscriptionResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateEventSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateEventSubscription");
            try
            {
                #if DESKTOP
                return client.CreateEventSubscription(request);
                #elif CORECLR
                return client.CreateEventSubscriptionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> EventCategory { get; set; }
            public System.String SnsTopicArn { get; set; }
            public List<System.String> SourceId { get; set; }
            public System.String SourceType { get; set; }
            public System.String SubscriptionName { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.RDS.Model.CreateEventSubscriptionResponse, NewRDSEventSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventSubscription;
        }
        
    }
}
