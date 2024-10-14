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
    /// Enables rehydration of chats for the lifespan of a contact. For more information about
    /// chat rehydration, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/chat-persistence.html">Enable
    /// persistent chat</a> in the <i>Amazon Connect Administrator Guide</i>.
    /// </summary>
    [Cmdlet("New", "CONNPersistentContactAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Service CreatePersistentContactAssociation API operation.", Operation = new[] {"CreatePersistentContactAssociation"}, SelectReturnType = typeof(Amazon.Connect.Model.CreatePersistentContactAssociationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Connect.Model.CreatePersistentContactAssociationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Connect.Model.CreatePersistentContactAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCONNPersistentContactAssociationCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InitialContactId
        /// <summary>
        /// <para>
        /// <para>This is the contactId of the current contact that the <c>CreatePersistentContactAssociation</c>
        /// API is being called from.</para>
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
        public System.String InitialContactId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter RehydrationType
        /// <summary>
        /// <para>
        /// <para>The contactId chosen for rehydration depends on the type chosen.</para><ul><li><para><c>ENTIRE_PAST_SESSION</c>: Rehydrates a chat from the most recently terminated past
        /// chat contact of the specified past ended chat session. To use this type, provide the
        /// <c>initialContactId</c> of the past ended chat session in the <c>sourceContactId</c>
        /// field. In this type, Amazon Connect determines what the most recent chat contact on
        /// the past ended chat session and uses it to start a persistent chat. </para></li><li><para><c>FROM_SEGMENT</c>: Rehydrates a chat from the specified past chat contact provided
        /// in the <c>sourceContactId</c> field. </para></li></ul><para>The actual contactId used for rehydration is provided in the response of this API.</para><para>To illustrate how to use rehydration type, consider the following example: A customer
        /// starts a chat session. Agent a1 accepts the chat and a conversation starts between
        /// the customer and Agent a1. This first contact creates a contact ID <b>C1</b>. Agent
        /// a1 then transfers the chat to Agent a2. This creates another contact ID <b>C2</b>.
        /// At this point Agent a2 ends the chat. The customer is forwarded to the disconnect
        /// flow for a post chat survey that creates another contact ID <b>C3</b>. After the chat
        /// survey, the chat session ends. Later, the customer returns and wants to resume their
        /// past chat session. At this point, the customer can have following use cases: </para><ul><li><para><b>Use Case 1</b>: The customer wants to continue the past chat session but they
        /// want to hide the post chat survey. For this they will use the following configuration:</para><ul><li><para><b>Configuration</b></para><ul><li><para>SourceContactId = "C2"</para></li><li><para>RehydrationType = "FROM_SEGMENT"</para></li></ul></li><li><para><b>Expected behavior</b></para><ul><li><para>This starts a persistent chat session from the specified past ended contact (C2).
        /// Transcripts of past chat sessions C2 and C1 are accessible in the current persistent
        /// chat session. Note that chat segment C3 is dropped from the persistent chat session.</para></li></ul></li></ul></li><li><para><b>Use Case 2</b>: The customer wants to continue the past chat session and see the
        /// transcript of the entire past engagement, including the post chat survey. For this
        /// they will use the following configuration:</para><ul><li><para><b>Configuration</b></para><ul><li><para>SourceContactId = "C1"</para></li><li><para>RehydrationType = "ENTIRE_PAST_SESSION"</para></li></ul></li><li><para><b>Expected behavior</b></para><ul><li><para>This starts a persistent chat session from the most recently ended chat contact (C3).
        /// Transcripts of past chat sessions C3, C2 and C1 are accessible in the current persistent
        /// chat session.</para></li></ul></li></ul></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.RehydrationType")]
        public Amazon.Connect.RehydrationType RehydrationType { get; set; }
        #endregion
        
        #region Parameter SourceContactId
        /// <summary>
        /// <para>
        /// <para>The contactId from which a persistent chat session must be started.</para>
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
        public System.String SourceContactId { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContinuedFromContactId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreatePersistentContactAssociationResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreatePersistentContactAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContinuedFromContactId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InitialContactId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNPersistentContactAssociation (CreatePersistentContactAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreatePersistentContactAssociationResponse, NewCONNPersistentContactAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.InitialContactId = this.InitialContactId;
            #if MODULAR
            if (this.InitialContactId == null && ParameterWasBound(nameof(this.InitialContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter InitialContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RehydrationType = this.RehydrationType;
            #if MODULAR
            if (this.RehydrationType == null && ParameterWasBound(nameof(this.RehydrationType)))
            {
                WriteWarning("You are passing $null as a value for parameter RehydrationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceContactId = this.SourceContactId;
            #if MODULAR
            if (this.SourceContactId == null && ParameterWasBound(nameof(this.SourceContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Connect.Model.CreatePersistentContactAssociationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InitialContactId != null)
            {
                request.InitialContactId = cmdletContext.InitialContactId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.RehydrationType != null)
            {
                request.RehydrationType = cmdletContext.RehydrationType;
            }
            if (cmdletContext.SourceContactId != null)
            {
                request.SourceContactId = cmdletContext.SourceContactId;
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
        
        private Amazon.Connect.Model.CreatePersistentContactAssociationResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreatePersistentContactAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreatePersistentContactAssociation");
            try
            {
                #if DESKTOP
                return client.CreatePersistentContactAssociation(request);
                #elif CORECLR
                return client.CreatePersistentContactAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String InitialContactId { get; set; }
            public System.String InstanceId { get; set; }
            public Amazon.Connect.RehydrationType RehydrationType { get; set; }
            public System.String SourceContactId { get; set; }
            public System.Func<Amazon.Connect.Model.CreatePersistentContactAssociationResponse, NewCONNPersistentContactAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContinuedFromContactId;
        }
        
    }
}
