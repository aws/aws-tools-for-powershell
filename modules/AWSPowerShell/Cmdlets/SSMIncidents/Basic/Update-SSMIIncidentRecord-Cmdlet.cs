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
using Amazon.SSMIncidents;
using Amazon.SSMIncidents.Model;

namespace Amazon.PowerShell.Cmdlets.SSMI
{
    /// <summary>
    /// Update the details of an incident record. You can use this operation to update an
    /// incident record from the defined chat channel. For more information about using actions
    /// in chat channels, see <a href="https://docs.aws.amazon.com/incident-manager/latest/userguide/chat.html#chat-interact">Interacting
    /// through chat</a>.
    /// </summary>
    [Cmdlet("Update", "SSMIIncidentRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager UpdateIncidentRecord API operation.", Operation = new[] {"UpdateIncidentRecord"}, SelectReturnType = typeof(Amazon.SSMIncidents.Model.UpdateIncidentRecordResponse))]
    [AWSCmdletOutput("None or Amazon.SSMIncidents.Model.UpdateIncidentRecordResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSMIncidents.Model.UpdateIncidentRecordResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSSMIIncidentRecordCmdlet : AmazonSSMIncidentsClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the incident record you are updating.</para>
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
        public System.String Arn { get; set; }
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
        
        #region Parameter ChatChannel_Empty
        /// <summary>
        /// <para>
        /// <para>Used to remove the chat channel from an incident record or response plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SSMIncidents.Model.EmptyChatChannel ChatChannel_Empty { get; set; }
        #endregion
        
        #region Parameter Impact
        /// <summary>
        /// <para>
        /// <para>Defines the impact of the incident to customers and applications. If you provide an
        /// impact for an incident, it overwrites the impact provided by the response plan.</para><para><b>Possible impacts:</b></para><ul><li><para><code>1</code> - Critical impact, full application failure that impacts many to all
        /// customers. </para></li><li><para><code>2</code> - High impact, partial application failure with impact to many customers.</para></li><li><para><code>3</code> - Medium impact, the application is providing reduced service to customers.</para></li><li><para><code>4</code> - Low impact, customer aren't impacted by the problem yet.</para></li><li><para><code>5</code> - No impact, customers aren't currently impacted but urgent action
        /// is needed to avoid impact.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Impact { get; set; }
        #endregion
        
        #region Parameter NotificationTarget
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS targets that Incident Manager notifies when a client updates an incident.</para><para>Using multiple SNS topics creates redundancy in the event that a Region is down during
        /// the incident.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotificationTargets")]
        public Amazon.SSMIncidents.Model.NotificationTargetItem[] NotificationTarget { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the incident. Possible statuses are <code>Open</code> or <code>Resolved</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SSMIncidents.IncidentRecordStatus")]
        public Amazon.SSMIncidents.IncidentRecordStatus Status { get; set; }
        #endregion
        
        #region Parameter Summary
        /// <summary>
        /// <para>
        /// <para>A longer description of what occurred during the incident.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Summary { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>A brief description of the incident.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures that a client calls the operation only once with the specified
        /// details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMIncidents.Model.UpdateIncidentRecordResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMIIncidentRecord (UpdateIncidentRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMIncidents.Model.UpdateIncidentRecordResponse, UpdateSSMIIncidentRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ChatChannel_ChatbotSn != null)
            {
                context.ChatChannel_ChatbotSn = new List<System.String>(this.ChatChannel_ChatbotSn);
            }
            context.ChatChannel_Empty = this.ChatChannel_Empty;
            context.ClientToken = this.ClientToken;
            context.Impact = this.Impact;
            if (this.NotificationTarget != null)
            {
                context.NotificationTarget = new List<Amazon.SSMIncidents.Model.NotificationTargetItem>(this.NotificationTarget);
            }
            context.Status = this.Status;
            context.Summary = this.Summary;
            context.Title = this.Title;
            
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
            var request = new Amazon.SSMIncidents.Model.UpdateIncidentRecordRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
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
            if (cmdletContext.Impact != null)
            {
                request.Impact = cmdletContext.Impact.Value;
            }
            if (cmdletContext.NotificationTarget != null)
            {
                request.NotificationTargets = cmdletContext.NotificationTarget;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.Summary != null)
            {
                request.Summary = cmdletContext.Summary;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.SSMIncidents.Model.UpdateIncidentRecordResponse CallAWSServiceOperation(IAmazonSSMIncidents client, Amazon.SSMIncidents.Model.UpdateIncidentRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager", "UpdateIncidentRecord");
            try
            {
                #if DESKTOP
                return client.UpdateIncidentRecord(request);
                #elif CORECLR
                return client.UpdateIncidentRecordAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public List<System.String> ChatChannel_ChatbotSn { get; set; }
            public Amazon.SSMIncidents.Model.EmptyChatChannel ChatChannel_Empty { get; set; }
            public System.String ClientToken { get; set; }
            public System.Int32? Impact { get; set; }
            public List<Amazon.SSMIncidents.Model.NotificationTargetItem> NotificationTarget { get; set; }
            public Amazon.SSMIncidents.IncidentRecordStatus Status { get; set; }
            public System.String Summary { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.SSMIncidents.Model.UpdateIncidentRecordResponse, UpdateSSMIIncidentRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
