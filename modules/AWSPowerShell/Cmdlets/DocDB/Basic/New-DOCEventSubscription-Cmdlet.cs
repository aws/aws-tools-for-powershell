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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Creates an Amazon DocumentDB event notification subscription. This action requires
    /// a topic Amazon Resource Name (ARN) created by using the Amazon DocumentDB console,
    /// the Amazon SNS console, or the Amazon SNS API. To obtain an ARN with Amazon SNS, you
    /// must create a topic in Amazon SNS and subscribe to the topic. The ARN is displayed
    /// in the Amazon SNS console.
    /// 
    ///  
    /// <para>
    /// You can specify the type of source (<c>SourceType</c>) that you want to be notified
    /// of. You can also provide a list of Amazon DocumentDB sources (<c>SourceIds</c>) that
    /// trigger the events, and you can provide a list of event categories (<c>EventCategories</c>)
    /// for events that you want to be notified of. For example, you can specify <c>SourceType
    /// = db-instance</c>, <c>SourceIds = mydbinstance1, mydbinstance2</c> and <c>EventCategories
    /// = Availability, Backup</c>.
    /// </para><para>
    /// If you specify both the <c>SourceType</c> and <c>SourceIds</c> (such as <c>SourceType
    /// = db-instance</c> and <c>SourceIdentifier = myDBInstance1</c>), you are notified of
    /// all the <c>db-instance</c> events for the specified source. If you specify a <c>SourceType</c>
    /// but do not specify a <c>SourceIdentifier</c>, you receive notice of the events for
    /// that source type for all your Amazon DocumentDB sources. If you do not specify either
    /// the <c>SourceType</c> or the <c>SourceIdentifier</c>, you are notified of events generated
    /// from all Amazon DocumentDB sources belonging to your customer account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DOCEventSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.EventSubscription")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) CreateEventSubscription API operation.", Operation = new[] {"CreateEventSubscription"}, SelectReturnType = typeof(Amazon.DocDB.Model.CreateEventSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.EventSubscription or Amazon.DocDB.Model.CreateEventSubscriptionResponse",
        "This cmdlet returns an Amazon.DocDB.Model.EventSubscription object.",
        "The service call response (type Amazon.DocDB.Model.CreateEventSubscriptionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDOCEventSubscriptionCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para> A Boolean value; set to <c>true</c> to activate the subscription, set to <c>false</c>
        /// to create the subscription but not active it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter EventCategory
        /// <summary>
        /// <para>
        /// <para> A list of event categories for a <c>SourceType</c> that you want to subscribe to.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventCategories")]
        public System.String[] EventCategory { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the SNS topic created for event notification. Amazon
        /// SNS creates the ARN when you create a topic and subscribe to it.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
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
        /// with a letter and must contain only ASCII letters, digits, and hyphens; it can't end
        /// with a hyphen or contain two consecutive hyphens.</para><para>Constraints:</para><ul><li><para>If <c>SourceIds</c> are provided, <c>SourceType</c> must also be provided.</para></li><li><para>If the source type is an instance, a <c>DBInstanceIdentifier</c> must be provided.</para></li><li><para>If the source type is a security group, a <c>DBSecurityGroupName</c> must be provided.</para></li><li><para>If the source type is a parameter group, a <c>DBParameterGroupName</c> must be provided.</para></li><li><para>If the source type is a snapshot, a <c>DBSnapshotIdentifier</c> must be provided.</para></li></ul>
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
        /// of events generated by an instance, you would set this parameter to <c>db-instance</c>.
        /// If this value is not specified, all events are returned.</para><para>Valid values: <c>db-instance</c>, <c>db-cluster</c>, <c>db-parameter-group</c>, <c>db-security-group</c>,
        /// <c>db-cluster-snapshot</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceType { get; set; }
        #endregion
        
        #region Parameter SubscriptionName
        /// <summary>
        /// <para>
        /// <para>The name of the subscription.</para><para>Constraints: The name must be fewer than 255 characters.</para>
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
        /// <para>The tags to be assigned to the event subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DocDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventSubscription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.CreateEventSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.CreateEventSubscriptionResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriptionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DOCEventSubscription (CreateEventSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.CreateEventSubscriptionResponse, NewDOCEventSubscriptionCmdlet>(Select) ??
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
                context.Tag = new List<Amazon.DocDB.Model.Tag>(this.Tag);
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
            var request = new Amazon.DocDB.Model.CreateEventSubscriptionRequest();
            
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
        
        private Amazon.DocDB.Model.CreateEventSubscriptionResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.CreateEventSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "CreateEventSubscription");
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
            public List<Amazon.DocDB.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.DocDB.Model.CreateEventSubscriptionResponse, NewDOCEventSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventSubscription;
        }
        
    }
}
