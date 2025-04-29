/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.SSMIncidents;
using Amazon.SSMIncidents.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSMI
{
    /// <summary>
    /// Creates a response plan that automates the initial response to incidents. A response
    /// plan engages contacts, starts chat channel collaboration, and initiates runbooks at
    /// the beginning of an incident.
    /// </summary>
    [Cmdlet("New", "SSMIResponsePlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager CreateResponsePlan API operation.", Operation = new[] {"CreateResponsePlan"}, SelectReturnType = typeof(Amazon.SSMIncidents.Model.CreateResponsePlanResponse))]
    [AWSCmdletOutput("System.String or Amazon.SSMIncidents.Model.CreateResponsePlanResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SSMIncidents.Model.CreateResponsePlanResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSSMIResponsePlanCmdlet : AmazonSSMIncidentsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The actions that the response plan starts at the beginning of an incident.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Actions")]
        public Amazon.SSMIncidents.Model.Action[] Action { get; set; }
        #endregion
        
        #region Parameter ChatChannel_ChatbotSn
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS targets that Chatbot uses to notify the chat channel of updates to
        /// an incident. You can also make updates to the incident through the chat channel by
        /// using the Amazon SNS topics. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChatChannel_ChatbotSns")]
        public System.String[] ChatChannel_ChatbotSn { get; set; }
        #endregion
        
        #region Parameter IncidentTemplate_DedupeString
        /// <summary>
        /// <para>
        /// <para>The string Incident Manager uses to prevent the same root cause from creating multiple
        /// incidents in the same account.</para><para>A deduplication string is a term or phrase the system uses to check for duplicate
        /// incidents. If you specify a deduplication string, Incident Manager searches for open
        /// incidents that contain the same string in the <c>dedupeString</c> field when it creates
        /// the incident. If a duplicate is detected, Incident Manager deduplicates the newer
        /// incident into the existing incident.</para><note><para>By default, Incident Manager automatically deduplicates multiple incidents created
        /// by the same Amazon CloudWatch alarm or Amazon EventBridge event. You don't have to
        /// enter your own deduplication string to prevent duplication for these resource types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IncidentTemplate_DedupeString { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The long format of the response plan name. This field can contain spaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ChatChannel_Empty
        /// <summary>
        /// <para>
        /// <para>Used to remove the chat channel from an incident record or response plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SSMIncidents.Model.EmptyChatChannel ChatChannel_Empty { get; set; }
        #endregion
        
        #region Parameter Engagement
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the contacts and escalation plans that the response
        /// plan engages during an incident.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Engagements")]
        public System.String[] Engagement { get; set; }
        #endregion
        
        #region Parameter IncidentTemplate_Impact
        /// <summary>
        /// <para>
        /// <para>The impact of the incident on your customers and applications.</para><para><b>Supported impact codes</b></para><ul><li><para><c>1</c> - Critical</para></li><li><para><c>2</c> - High</para></li><li><para><c>3</c> - Medium</para></li><li><para><c>4</c> - Low</para></li><li><para><c>5</c> - No Impact</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? IncidentTemplate_Impact { get; set; }
        #endregion
        
        #region Parameter IncidentTemplate_IncidentTag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the template. When the <c>StartIncident</c> API action is called,
        /// Incident Manager assigns the tags specified in the template to the incident.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncidentTemplate_IncidentTags")]
        public System.Collections.Hashtable IncidentTemplate_IncidentTag { get; set; }
        #endregion
        
        #region Parameter Integration
        /// <summary>
        /// <para>
        /// <para>Information about third-party services integrated into the response plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Integrations")]
        public Amazon.SSMIncidents.Model.Integration[] Integration { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The short format name of the response plan. Can't include spaces.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter IncidentTemplate_NotificationTarget
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS targets that are notified when updates are made to an incident.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncidentTemplate_NotificationTargets")]
        public Amazon.SSMIncidents.Model.NotificationTargetItem[] IncidentTemplate_NotificationTarget { get; set; }
        #endregion
        
        #region Parameter IncidentTemplate_Summary
        /// <summary>
        /// <para>
        /// <para>The summary of the incident. The summary is a brief synopsis of what occurred, what's
        /// currently happening, and context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IncidentTemplate_Summary { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags that you are adding to the response plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter IncidentTemplate_Title
        /// <summary>
        /// <para>
        /// <para>The title of the incident. </para>
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
        public System.String IncidentTemplate_Title { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token ensuring that the operation is called only once with the specified details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMIncidents.Model.CreateResponsePlanResponse).
        /// Specifying the name of a property of type Amazon.SSMIncidents.Model.CreateResponsePlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMIResponsePlan (CreateResponsePlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMIncidents.Model.CreateResponsePlanResponse, NewSSMIResponsePlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Action != null)
            {
                context.Action = new List<Amazon.SSMIncidents.Model.Action>(this.Action);
            }
            if (this.ChatChannel_ChatbotSn != null)
            {
                context.ChatChannel_ChatbotSn = new List<System.String>(this.ChatChannel_ChatbotSn);
            }
            context.ChatChannel_Empty = this.ChatChannel_Empty;
            context.ClientToken = this.ClientToken;
            context.DisplayName = this.DisplayName;
            if (this.Engagement != null)
            {
                context.Engagement = new List<System.String>(this.Engagement);
            }
            context.IncidentTemplate_DedupeString = this.IncidentTemplate_DedupeString;
            context.IncidentTemplate_Impact = this.IncidentTemplate_Impact;
            #if MODULAR
            if (this.IncidentTemplate_Impact == null && ParameterWasBound(nameof(this.IncidentTemplate_Impact)))
            {
                WriteWarning("You are passing $null as a value for parameter IncidentTemplate_Impact which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.IncidentTemplate_IncidentTag != null)
            {
                context.IncidentTemplate_IncidentTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.IncidentTemplate_IncidentTag.Keys)
                {
                    context.IncidentTemplate_IncidentTag.Add((String)hashKey, (System.String)(this.IncidentTemplate_IncidentTag[hashKey]));
                }
            }
            if (this.IncidentTemplate_NotificationTarget != null)
            {
                context.IncidentTemplate_NotificationTarget = new List<Amazon.SSMIncidents.Model.NotificationTargetItem>(this.IncidentTemplate_NotificationTarget);
            }
            context.IncidentTemplate_Summary = this.IncidentTemplate_Summary;
            context.IncidentTemplate_Title = this.IncidentTemplate_Title;
            #if MODULAR
            if (this.IncidentTemplate_Title == null && ParameterWasBound(nameof(this.IncidentTemplate_Title)))
            {
                WriteWarning("You are passing $null as a value for parameter IncidentTemplate_Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Integration != null)
            {
                context.Integration = new List<Amazon.SSMIncidents.Model.Integration>(this.Integration);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.SSMIncidents.Model.CreateResponsePlanRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            
             // populate ChatChannel
            var requestChatChannelIsNull = true;
            request.ChatChannel = new Amazon.SSMIncidents.Model.ChatChannel();
            List<System.String> requestChatChannel_chatChannel_ChatbotSn = null;
            if (cmdletContext.ChatChannel_ChatbotSn != null)
            {
                requestChatChannel_chatChannel_ChatbotSn = cmdletContext.ChatChannel_ChatbotSn;
            }
            if (requestChatChannel_chatChannel_ChatbotSn != null)
            {
                request.ChatChannel.ChatbotSns = requestChatChannel_chatChannel_ChatbotSn;
                requestChatChannelIsNull = false;
            }
            Amazon.SSMIncidents.Model.EmptyChatChannel requestChatChannel_chatChannel_Empty = null;
            if (cmdletContext.ChatChannel_Empty != null)
            {
                requestChatChannel_chatChannel_Empty = cmdletContext.ChatChannel_Empty;
            }
            if (requestChatChannel_chatChannel_Empty != null)
            {
                request.ChatChannel.Empty = requestChatChannel_chatChannel_Empty;
                requestChatChannelIsNull = false;
            }
             // determine if request.ChatChannel should be set to null
            if (requestChatChannelIsNull)
            {
                request.ChatChannel = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.Engagement != null)
            {
                request.Engagements = cmdletContext.Engagement;
            }
            
             // populate IncidentTemplate
            var requestIncidentTemplateIsNull = true;
            request.IncidentTemplate = new Amazon.SSMIncidents.Model.IncidentTemplate();
            System.String requestIncidentTemplate_incidentTemplate_DedupeString = null;
            if (cmdletContext.IncidentTemplate_DedupeString != null)
            {
                requestIncidentTemplate_incidentTemplate_DedupeString = cmdletContext.IncidentTemplate_DedupeString;
            }
            if (requestIncidentTemplate_incidentTemplate_DedupeString != null)
            {
                request.IncidentTemplate.DedupeString = requestIncidentTemplate_incidentTemplate_DedupeString;
                requestIncidentTemplateIsNull = false;
            }
            System.Int32? requestIncidentTemplate_incidentTemplate_Impact = null;
            if (cmdletContext.IncidentTemplate_Impact != null)
            {
                requestIncidentTemplate_incidentTemplate_Impact = cmdletContext.IncidentTemplate_Impact.Value;
            }
            if (requestIncidentTemplate_incidentTemplate_Impact != null)
            {
                request.IncidentTemplate.Impact = requestIncidentTemplate_incidentTemplate_Impact.Value;
                requestIncidentTemplateIsNull = false;
            }
            Dictionary<System.String, System.String> requestIncidentTemplate_incidentTemplate_IncidentTag = null;
            if (cmdletContext.IncidentTemplate_IncidentTag != null)
            {
                requestIncidentTemplate_incidentTemplate_IncidentTag = cmdletContext.IncidentTemplate_IncidentTag;
            }
            if (requestIncidentTemplate_incidentTemplate_IncidentTag != null)
            {
                request.IncidentTemplate.IncidentTags = requestIncidentTemplate_incidentTemplate_IncidentTag;
                requestIncidentTemplateIsNull = false;
            }
            List<Amazon.SSMIncidents.Model.NotificationTargetItem> requestIncidentTemplate_incidentTemplate_NotificationTarget = null;
            if (cmdletContext.IncidentTemplate_NotificationTarget != null)
            {
                requestIncidentTemplate_incidentTemplate_NotificationTarget = cmdletContext.IncidentTemplate_NotificationTarget;
            }
            if (requestIncidentTemplate_incidentTemplate_NotificationTarget != null)
            {
                request.IncidentTemplate.NotificationTargets = requestIncidentTemplate_incidentTemplate_NotificationTarget;
                requestIncidentTemplateIsNull = false;
            }
            System.String requestIncidentTemplate_incidentTemplate_Summary = null;
            if (cmdletContext.IncidentTemplate_Summary != null)
            {
                requestIncidentTemplate_incidentTemplate_Summary = cmdletContext.IncidentTemplate_Summary;
            }
            if (requestIncidentTemplate_incidentTemplate_Summary != null)
            {
                request.IncidentTemplate.Summary = requestIncidentTemplate_incidentTemplate_Summary;
                requestIncidentTemplateIsNull = false;
            }
            System.String requestIncidentTemplate_incidentTemplate_Title = null;
            if (cmdletContext.IncidentTemplate_Title != null)
            {
                requestIncidentTemplate_incidentTemplate_Title = cmdletContext.IncidentTemplate_Title;
            }
            if (requestIncidentTemplate_incidentTemplate_Title != null)
            {
                request.IncidentTemplate.Title = requestIncidentTemplate_incidentTemplate_Title;
                requestIncidentTemplateIsNull = false;
            }
             // determine if request.IncidentTemplate should be set to null
            if (requestIncidentTemplateIsNull)
            {
                request.IncidentTemplate = null;
            }
            if (cmdletContext.Integration != null)
            {
                request.Integrations = cmdletContext.Integration;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.SSMIncidents.Model.CreateResponsePlanResponse CallAWSServiceOperation(IAmazonSSMIncidents client, Amazon.SSMIncidents.Model.CreateResponsePlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager", "CreateResponsePlan");
            try
            {
                return client.CreateResponsePlanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SSMIncidents.Model.Action> Action { get; set; }
            public List<System.String> ChatChannel_ChatbotSn { get; set; }
            public Amazon.SSMIncidents.Model.EmptyChatChannel ChatChannel_Empty { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DisplayName { get; set; }
            public List<System.String> Engagement { get; set; }
            public System.String IncidentTemplate_DedupeString { get; set; }
            public System.Int32? IncidentTemplate_Impact { get; set; }
            public Dictionary<System.String, System.String> IncidentTemplate_IncidentTag { get; set; }
            public List<Amazon.SSMIncidents.Model.NotificationTargetItem> IncidentTemplate_NotificationTarget { get; set; }
            public System.String IncidentTemplate_Summary { get; set; }
            public System.String IncidentTemplate_Title { get; set; }
            public List<Amazon.SSMIncidents.Model.Integration> Integration { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SSMIncidents.Model.CreateResponsePlanResponse, NewSSMIResponsePlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
