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
    /// Places an inbound in-app, web, or video call to a contact, and then initiates the
    /// flow. It performs the actions in the flow that are specified (in ContactFlowId) and
    /// present in the Amazon Connect instance (specified as InstanceId).
    /// </summary>
    [Cmdlet("Start", "CONNWebRTCContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.StartWebRTCContactResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service StartWebRTCContact API operation.", Operation = new[] {"StartWebRTCContact"}, SelectReturnType = typeof(Amazon.Connect.Model.StartWebRTCContactResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.StartWebRTCContactResponse",
        "This cmdlet returns an Amazon.Connect.Model.StartWebRTCContactResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCONNWebRTCContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A custom key-value pair using an attribute map. The attributes are standard Amazon
        /// Connect attributes, and can be accessed in flows just like any other contact attributes.</para><para>There can be up to 32,768 UTF-8 bytes across all key-value pairs per contact. Attribute
        /// keys can include only alphanumeric, -, and _ characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the flow for the call. To see the ContactFlowId in the Amazon Connect
        /// admin website, on the navigation menu go to <b>Routing</b>, <b>Contact Flows</b>.
        /// Choose the flow. On the flow page, under the name of the flow, choose <b>Show additional
        /// flow information</b>. The ContactFlowId is the last part of the ARN, shown here in
        /// bold: </para><para>arn:aws:connect:us-west-2:xxxxxxxxxxxx:instance/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/contact-flow/<b>846ec553-a005-41c0-8341-xxxxxxxxxxxx</b></para>
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
        
        #region Parameter ParticipantDetails_DisplayName
        /// <summary>
        /// <para>
        /// <para>Display name of the participant.</para>
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
        public System.String ParticipantDetails_DisplayName { get; set; }
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
        /// <para>The unique identifier for an Amazon Connect contact. This identifier is related to
        /// the contact starting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedContactId { get; set; }
        #endregion
        
        #region Parameter Agent_Video
        /// <summary>
        /// <para>
        /// <para>The configuration having the video sharing capabilities for participants over the
        /// call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedCapabilities_Agent_Video")]
        [AWSConstantClassSource("Amazon.Connect.VideoCapability")]
        public Amazon.Connect.VideoCapability Agent_Video { get; set; }
        #endregion
        
        #region Parameter Customer_Video
        /// <summary>
        /// <para>
        /// <para>The configuration having the video sharing capabilities for participants over the
        /// call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedCapabilities_Customer_Video")]
        [AWSConstantClassSource("Amazon.Connect.VideoCapability")]
        public Amazon.Connect.VideoCapability Customer_Video { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para><para>The token is valid for 7 days after creation. If a contact is already started, the
        /// contact ID is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartWebRTCContactResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.StartWebRTCContactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNWebRTCContact (StartWebRTCContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartWebRTCContactResponse, StartCONNWebRTCContactCmdlet>(Select) ??
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
            context.Agent_Video = this.Agent_Video;
            context.Customer_Video = this.Customer_Video;
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
            #if MODULAR
            if (this.ContactFlowId == null && ParameterWasBound(nameof(this.ContactFlowId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactFlowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParticipantDetails_DisplayName = this.ParticipantDetails_DisplayName;
            #if MODULAR
            if (this.ParticipantDetails_DisplayName == null && ParameterWasBound(nameof(this.ParticipantDetails_DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter ParticipantDetails_DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Reference != null)
            {
                context.Reference = new Dictionary<System.String, Amazon.Connect.Model.Reference>(StringComparer.Ordinal);
                foreach (var hashKey in this.Reference.Keys)
                {
                    context.Reference.Add((String)hashKey, (Amazon.Connect.Model.Reference)(this.Reference[hashKey]));
                }
            }
            context.RelatedContactId = this.RelatedContactId;
            
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
            var request = new Amazon.Connect.Model.StartWebRTCContactRequest();
            
            
             // populate AllowedCapabilities
            var requestAllowedCapabilitiesIsNull = true;
            request.AllowedCapabilities = new Amazon.Connect.Model.AllowedCapabilities();
            Amazon.Connect.Model.ParticipantCapabilities requestAllowedCapabilities_allowedCapabilities_Agent = null;
            
             // populate Agent
            var requestAllowedCapabilities_allowedCapabilities_AgentIsNull = true;
            requestAllowedCapabilities_allowedCapabilities_Agent = new Amazon.Connect.Model.ParticipantCapabilities();
            Amazon.Connect.VideoCapability requestAllowedCapabilities_allowedCapabilities_Agent_agent_Video = null;
            if (cmdletContext.Agent_Video != null)
            {
                requestAllowedCapabilities_allowedCapabilities_Agent_agent_Video = cmdletContext.Agent_Video;
            }
            if (requestAllowedCapabilities_allowedCapabilities_Agent_agent_Video != null)
            {
                requestAllowedCapabilities_allowedCapabilities_Agent.Video = requestAllowedCapabilities_allowedCapabilities_Agent_agent_Video;
                requestAllowedCapabilities_allowedCapabilities_AgentIsNull = false;
            }
             // determine if requestAllowedCapabilities_allowedCapabilities_Agent should be set to null
            if (requestAllowedCapabilities_allowedCapabilities_AgentIsNull)
            {
                requestAllowedCapabilities_allowedCapabilities_Agent = null;
            }
            if (requestAllowedCapabilities_allowedCapabilities_Agent != null)
            {
                request.AllowedCapabilities.Agent = requestAllowedCapabilities_allowedCapabilities_Agent;
                requestAllowedCapabilitiesIsNull = false;
            }
            Amazon.Connect.Model.ParticipantCapabilities requestAllowedCapabilities_allowedCapabilities_Customer = null;
            
             // populate Customer
            var requestAllowedCapabilities_allowedCapabilities_CustomerIsNull = true;
            requestAllowedCapabilities_allowedCapabilities_Customer = new Amazon.Connect.Model.ParticipantCapabilities();
            Amazon.Connect.VideoCapability requestAllowedCapabilities_allowedCapabilities_Customer_customer_Video = null;
            if (cmdletContext.Customer_Video != null)
            {
                requestAllowedCapabilities_allowedCapabilities_Customer_customer_Video = cmdletContext.Customer_Video;
            }
            if (requestAllowedCapabilities_allowedCapabilities_Customer_customer_Video != null)
            {
                requestAllowedCapabilities_allowedCapabilities_Customer.Video = requestAllowedCapabilities_allowedCapabilities_Customer_customer_Video;
                requestAllowedCapabilities_allowedCapabilities_CustomerIsNull = false;
            }
             // determine if requestAllowedCapabilities_allowedCapabilities_Customer should be set to null
            if (requestAllowedCapabilities_allowedCapabilities_CustomerIsNull)
            {
                requestAllowedCapabilities_allowedCapabilities_Customer = null;
            }
            if (requestAllowedCapabilities_allowedCapabilities_Customer != null)
            {
                request.AllowedCapabilities.Customer = requestAllowedCapabilities_allowedCapabilities_Customer;
                requestAllowedCapabilitiesIsNull = false;
            }
             // determine if request.AllowedCapabilities should be set to null
            if (requestAllowedCapabilitiesIsNull)
            {
                request.AllowedCapabilities = null;
            }
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
            
             // populate ParticipantDetails
            var requestParticipantDetailsIsNull = true;
            request.ParticipantDetails = new Amazon.Connect.Model.ParticipantDetails();
            System.String requestParticipantDetails_participantDetails_DisplayName = null;
            if (cmdletContext.ParticipantDetails_DisplayName != null)
            {
                requestParticipantDetails_participantDetails_DisplayName = cmdletContext.ParticipantDetails_DisplayName;
            }
            if (requestParticipantDetails_participantDetails_DisplayName != null)
            {
                request.ParticipantDetails.DisplayName = requestParticipantDetails_participantDetails_DisplayName;
                requestParticipantDetailsIsNull = false;
            }
             // determine if request.ParticipantDetails should be set to null
            if (requestParticipantDetailsIsNull)
            {
                request.ParticipantDetails = null;
            }
            if (cmdletContext.Reference != null)
            {
                request.References = cmdletContext.Reference;
            }
            if (cmdletContext.RelatedContactId != null)
            {
                request.RelatedContactId = cmdletContext.RelatedContactId;
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
        
        private Amazon.Connect.Model.StartWebRTCContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartWebRTCContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartWebRTCContact");
            try
            {
                #if DESKTOP
                return client.StartWebRTCContact(request);
                #elif CORECLR
                return client.StartWebRTCContactAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Connect.VideoCapability Agent_Video { get; set; }
            public Amazon.Connect.VideoCapability Customer_Video { get; set; }
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ContactFlowId { get; set; }
            public System.String Description { get; set; }
            public System.String InstanceId { get; set; }
            public System.String ParticipantDetails_DisplayName { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.Reference> Reference { get; set; }
            public System.String RelatedContactId { get; set; }
            public System.Func<Amazon.Connect.Model.StartWebRTCContactResponse, StartCONNWebRTCContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
