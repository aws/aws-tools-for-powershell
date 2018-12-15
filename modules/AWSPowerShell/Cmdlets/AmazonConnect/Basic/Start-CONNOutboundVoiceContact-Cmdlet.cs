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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// The <code>StartOutboundVoiceContact</code> operation initiates a contact flow to place
    /// an outbound call to a customer.
    /// 
    ///  
    /// <para>
    /// If you are using an IAM account, it must have permission to the <code>connect:StartOutboundVoiceContact</code>
    /// action.
    /// </para><para>
    /// There is a 60 second dialing timeout for this operation. If the call is not connected
    /// after 60 seconds, the call fails.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CONNOutboundVoiceContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Service StartOutboundVoiceContact API operation.", Operation = new[] {"StartOutboundVoiceContact"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Connect.Model.StartOutboundVoiceContactResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCONNOutboundVoiceContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>Specify a custom key-value pair using an attribute map. The attributes are standard
        /// Amazon Connect attributes, and can be accessed in contact flows just like any other
        /// contact attributes.</para><para>There can be up to 32,768 UTF-8 bytes across all key-value pairs per contact. Attribute
        /// keys can include only alphanumeric, dash, and underscore characters.</para><para>For example, if you want play a greeting when the customer answers the call, you can
        /// pass the customer name in attributes similar to the following:</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. The token is valid for 7 days after creation. If a contact is already
        /// started, the contact ID is returned. If the contact is disconnected, a new contact
        /// is started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier for the contact flow to connect the outbound call to.</para><para>To find the <code>ContactFlowId</code>, open the contact flow you want to use in the
        /// Amazon Connect contact flow editor. The ID for the contact flow is displayed in the
        /// address bar as part of the URL. For example, the contact flow ID is the set of characters
        /// at the end of the URL, after 'contact-flow/' such as <code>78ea8fd5-2659-4f2b-b528-699760ccfc1b</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ContactFlowId { get; set; }
        #endregion
        
        #region Parameter DestinationPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the customer in E.164 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DestinationPhoneNumber { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier for your Amazon Connect instance. To find the ID of your instance,
        /// open the AWS console and select Amazon Connect. Select the alias of the instance in
        /// the Instance alias column. The instance ID is displayed in the Overview section of
        /// your instance settings. For example, the instance ID is the set of characters at the
        /// end of the instance ARN, after instance/, such as 10a4c4eb-f57e-4d4c-b602-bf39176ced07.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter QueueId
        /// <summary>
        /// <para>
        /// <para>The queue to add the call to. If you specify a queue, the phone displayed for caller
        /// ID is the phone number specified in the queue. If you do not specify a queue, the
        /// queue used will be the queue defined in the contact flow.</para><para>To find the <code>QueueId</code>, open the queue you want to use in the Amazon Connect
        /// Queue editor. The ID for the queue is displayed in the address bar as part of the
        /// URL. For example, the queue ID is the set of characters at the end of the URL, after
        /// 'queue/' such as <code>queue/aeg40574-2d01-51c3-73d6-bf8624d2168c</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String QueueId { get; set; }
        #endregion
        
        #region Parameter SourcePhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number, in E.164 format, associated with your Amazon Connect instance to
        /// use for the outbound call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourcePhoneNumber { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ContactFlowId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNOutboundVoiceContact (StartOutboundVoiceContact)"))
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
            
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.ClientToken = this.ClientToken;
            context.ContactFlowId = this.ContactFlowId;
            context.DestinationPhoneNumber = this.DestinationPhoneNumber;
            context.InstanceId = this.InstanceId;
            context.QueueId = this.QueueId;
            context.SourcePhoneNumber = this.SourcePhoneNumber;
            
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
            var request = new Amazon.Connect.Model.StartOutboundVoiceContactRequest();
            
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContactFlowId != null)
            {
                request.ContactFlowId = cmdletContext.ContactFlowId;
            }
            if (cmdletContext.DestinationPhoneNumber != null)
            {
                request.DestinationPhoneNumber = cmdletContext.DestinationPhoneNumber;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.QueueId != null)
            {
                request.QueueId = cmdletContext.QueueId;
            }
            if (cmdletContext.SourcePhoneNumber != null)
            {
                request.SourcePhoneNumber = cmdletContext.SourcePhoneNumber;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ContactId;
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
        
        private Amazon.Connect.Model.StartOutboundVoiceContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartOutboundVoiceContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartOutboundVoiceContact");
            try
            {
                #if DESKTOP
                return client.StartOutboundVoiceContact(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartOutboundVoiceContactAsync(request);
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
            public Dictionary<System.String, System.String> Attributes { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ContactFlowId { get; set; }
            public System.String DestinationPhoneNumber { get; set; }
            public System.String InstanceId { get; set; }
            public System.String QueueId { get; set; }
            public System.String SourcePhoneNumber { get; set; }
        }
        
    }
}
