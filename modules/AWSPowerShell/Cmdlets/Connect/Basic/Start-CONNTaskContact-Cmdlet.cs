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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Initiates a flow to start a new task contact. For more information about task contacts,
    /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/tasks.html">Concepts:
    /// Tasks in Amazon Connect</a> in the <i>Amazon Connect Administrator Guide</i>. 
    /// 
    ///  
    /// <para>
    /// When using <c>PreviousContactId</c> and <c>RelatedContactId</c> input parameters,
    /// note the following:
    /// </para><ul><li><para><c>PreviousContactId</c></para><ul><li><para>
    /// Any updates to user-defined task contact attributes on any contact linked through
    /// the same <c>PreviousContactId</c> will affect every contact in the chain.
    /// </para></li><li><para>
    /// There can be a maximum of 12 linked task contacts in a chain. That is, 12 task contacts
    /// can be created that share the same <c>PreviousContactId</c>.
    /// </para></li></ul></li><li><para><c>RelatedContactId</c></para><ul><li><para>
    /// Copies contact attributes from the related task contact to the new contact.
    /// </para></li><li><para>
    /// Any update on attributes in a new task contact does not update attributes on previous
    /// contact.
    /// </para></li><li><para>
    /// There’s no limit on the number of task contacts that can be created that use the same
    /// <c>RelatedContactId</c>.
    /// </para></li></ul></li></ul><para>
    /// In addition, when calling StartTaskContact include only one of these parameters: <c>ContactFlowID</c>,
    /// <c>QuickConnectID</c>, or <c>TaskTemplateID</c>. Only one parameter is required as
    /// long as the task template has a flow configured to run it. If more than one parameter
    /// is specified, or only the <c>TaskTemplateID</c> is specified but it does not have
    /// a flow configured, the request returns an error because Amazon Connect cannot identify
    /// the unique flow to run when the task is created.
    /// </para><para>
    /// A <c>ServiceQuotaExceededException</c> occurs when the number of open tasks exceeds
    /// the active tasks quota or there are already 12 tasks referencing the same <c>PreviousContactId</c>.
    /// For more information about service quotas for task contacts, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/amazon-connect-service-limits.html">Amazon
    /// Connect service quotas</a> in the <i>Amazon Connect Administrator Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CONNTaskContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Service StartTaskContact API operation.", Operation = new[] {"StartTaskContact"}, SelectReturnType = typeof(Amazon.Connect.Model.StartTaskContactResponse))]
    [AWSCmdletOutput("System.String or Amazon.Connect.Model.StartTaskContactResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Connect.Model.StartTaskContactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCONNTaskContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A custom key-value pair using an attribute map. The attributes are standard Amazon
        /// Connect attributes, and can be accessed in flows just like any other contact attributes.</para><para>There can be up to 32,768 UTF-8 bytes across all key-value pairs per contact. Attribute
        /// keys can include only alphanumeric, dash, and underscore characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the flow for initiating the tasks. To see the ContactFlowId in the
        /// Amazon Connect admin website, on the navigation menu go to <b>Routing</b>, <b>Contact
        /// Flows</b>. Choose the flow. On the flow page, under the name of the flow, choose <b>Show
        /// additional flow information</b>. The ContactFlowId is the last part of the ARN, shown
        /// here in bold: </para><para>arn:aws:connect:us-west-2:xxxxxxxxxxxx:instance/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/contact-flow/<b>846ec553-a005-41c0-8341-xxxxxxxxxxxx</b></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactFlowId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the task that is shown to an agent in the Contact Control Panel (CCP).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of a task that is shown to an agent in the Contact Control Panel (CCP).</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PreviousContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the previous chat, voice, or task contact. Any updates to user-defined
        /// attributes to task contacts linked using the same <c>PreviousContactID</c> will affect
        /// every contact in the chain. There can be a maximum of 12 linked task contacts in a
        /// chain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreviousContactId { get; set; }
        #endregion
        
        #region Parameter QuickConnectId
        /// <summary>
        /// <para>
        /// <para>The identifier for the quick connect. Tasks that are created by using <c>QuickConnectId</c>
        /// will use the flow that is defined on agent or queue quick connect. For more information
        /// about quick connects, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/quick-connects.html">Create
        /// quick connects</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QuickConnectId { get; set; }
        #endregion
        
        #region Parameter Reference
        /// <summary>
        /// <para>
        /// <para>A formatted URL that is shown to an agent in the Contact Control Panel (CCP). Tasks
        /// can have the following reference types at the time of creation: <c>URL</c> | <c>NUMBER</c>
        /// | <c>STRING</c> | <c>DATE</c> | <c>EMAIL</c>. <c>ATTACHMENT</c> is not a supported
        /// reference type during task creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("References")]
        public System.Collections.Hashtable Reference { get; set; }
        #endregion
        
        #region Parameter RelatedContactId
        /// <summary>
        /// <para>
        /// <para>The contactId that is <a href="https://docs.aws.amazon.com/connect/latest/adminguide/tasks.html#linked-tasks">related</a>
        /// to this contact. Linking tasks together by using <c>RelatedContactID</c> copies over
        /// contact attributes from the related task contact to the new task contact. All updates
        /// to user-defined attributes in the new task contact are limited to the individual contact
        /// ID, unlike what happens when tasks are linked by using <c>PreviousContactID</c>. There
        /// are no limits to the number of contacts that can be linked by using <c>RelatedContactId</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedContactId { get; set; }
        #endregion
        
        #region Parameter ScheduledTime
        /// <summary>
        /// <para>
        /// <para>The timestamp, in Unix Epoch seconds format, at which to start running the inbound
        /// flow. The scheduled time cannot be in the past. It must be within up to 6 days in
        /// future. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ScheduledTime { get; set; }
        #endregion
        
        #region Parameter TaskTemplateId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the task template. For more information about task templates,
        /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/task-templates.html">Create
        /// task templates</a> in the <i>Amazon Connect Administrator Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskTemplateId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContactId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartTaskContactResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.StartTaskContactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContactId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNTaskContact (StartTaskContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartTaskContactResponse, StartCONNTaskContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.ClientToken = this.ClientToken;
            context.ContactFlowId = this.ContactFlowId;
            context.Description = this.Description;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PreviousContactId = this.PreviousContactId;
            context.QuickConnectId = this.QuickConnectId;
            if (this.Reference != null)
            {
                context.Reference = new Dictionary<System.String, Amazon.Connect.Model.Reference>(StringComparer.Ordinal);
                foreach (var hashKey in this.Reference.Keys)
                {
                    context.Reference.Add((String)hashKey, (Amazon.Connect.Model.Reference)(this.Reference[hashKey]));
                }
            }
            context.RelatedContactId = this.RelatedContactId;
            context.ScheduledTime = this.ScheduledTime;
            context.TaskTemplateId = this.TaskTemplateId;
            
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
            var request = new Amazon.Connect.Model.StartTaskContactRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContactFlowId != null)
            {
                request.ContactFlowId = cmdletContext.ContactFlowId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PreviousContactId != null)
            {
                request.PreviousContactId = cmdletContext.PreviousContactId;
            }
            if (cmdletContext.QuickConnectId != null)
            {
                request.QuickConnectId = cmdletContext.QuickConnectId;
            }
            if (cmdletContext.Reference != null)
            {
                request.References = cmdletContext.Reference;
            }
            if (cmdletContext.RelatedContactId != null)
            {
                request.RelatedContactId = cmdletContext.RelatedContactId;
            }
            if (cmdletContext.ScheduledTime != null)
            {
                request.ScheduledTime = cmdletContext.ScheduledTime.Value;
            }
            if (cmdletContext.TaskTemplateId != null)
            {
                request.TaskTemplateId = cmdletContext.TaskTemplateId;
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
        
        private Amazon.Connect.Model.StartTaskContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartTaskContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartTaskContact");
            try
            {
                #if DESKTOP
                return client.StartTaskContact(request);
                #elif CORECLR
                return client.StartTaskContactAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ContactFlowId { get; set; }
            public System.String Description { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public System.String PreviousContactId { get; set; }
            public System.String QuickConnectId { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.Reference> Reference { get; set; }
            public System.String RelatedContactId { get; set; }
            public System.DateTime? ScheduledTime { get; set; }
            public System.String TaskTemplateId { get; set; }
            public System.Func<Amazon.Connect.Model.StartTaskContactResponse, StartCONNTaskContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContactId;
        }
        
    }
}
