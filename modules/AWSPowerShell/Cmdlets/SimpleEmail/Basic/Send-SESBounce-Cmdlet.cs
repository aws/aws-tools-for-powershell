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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Generates and sends a bounce message to the sender of an email you received through
    /// Amazon SES. You can only use this operation on an email up to 24 hours after you receive
    /// it.
    /// 
    ///  <note><para>
    /// You cannot use this operation to send generic bounces for mail that was not received
    /// by Amazon SES.
    /// </para></note><para>
    /// For information about receiving email through Amazon SES, see the <a href="https://docs.aws.amazon.com/ses/latest/dg/receiving-email.html">Amazon
    /// SES Developer Guide</a>.
    /// </para><para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "SESBounce", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) SendBounce API operation.", Operation = new[] {"SendBounce"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.SendBounceResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleEmail.Model.SendBounceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleEmail.Model.SendBounceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSESBounceCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter MessageDsn_UtcArrivalDate
        /// <summary>
        /// <para>
        /// <para>When the message was received by the reporting mail transfer agent (MTA), in <a href="https://www.ietf.org/rfc/rfc0822.txt">RFC
        /// 822</a> date-time format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? MessageDsn_UtcArrivalDate { get; set; }
        #endregion
        
        #region Parameter BouncedRecipientInfoList
        /// <summary>
        /// <para>
        /// <para>A list of recipients of the bounced message, including the information required to
        /// create the Delivery Status Notifications (DSNs) for the recipients. You must specify
        /// at least one <code>BouncedRecipientInfo</code> in the list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.SimpleEmail.Model.BouncedRecipientInfo[] BouncedRecipientInfoList { get; set; }
        #endregion
        
        #region Parameter BounceSender
        /// <summary>
        /// <para>
        /// <para>The address to use in the "From" header of the bounce message. This must be an identity
        /// that you have verified with Amazon SES.</para>
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
        public System.String BounceSender { get; set; }
        #endregion
        
        #region Parameter BounceSenderArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to use the
        /// address in the "From" header of the bounce. For more information about sending authorization,
        /// see the <a href="https://docs.aws.amazon.com/ses/latest/dg/sending-authorization.html">Amazon
        /// SES Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BounceSenderArn { get; set; }
        #endregion
        
        #region Parameter Explanation
        /// <summary>
        /// <para>
        /// <para>Human-readable text for the bounce message to explain the failure. If not specified,
        /// the text is auto-generated based on the bounced recipient information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Explanation { get; set; }
        #endregion
        
        #region Parameter MessageDsn_ExtensionField
        /// <summary>
        /// <para>
        /// <para>Additional X-headers to include in the DSN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageDsn_ExtensionFields")]
        public Amazon.SimpleEmail.Model.ExtensionField[] MessageDsn_ExtensionField { get; set; }
        #endregion
        
        #region Parameter OriginalMessageId
        /// <summary>
        /// <para>
        /// <para>The message ID of the message to be bounced.</para>
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
        public System.String OriginalMessageId { get; set; }
        #endregion
        
        #region Parameter MessageDsn_ReportingMta
        /// <summary>
        /// <para>
        /// <para>The reporting MTA that attempted to deliver the message, formatted as specified in
        /// <a href="https://tools.ietf.org/html/rfc3464">RFC 3464</a> (<code>mta-name-type; mta-name</code>).
        /// The default value is <code>dns; inbound-smtp.[region].amazonaws.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageDsn_ReportingMta { get; set; }
        #endregion
        
        #region Parameter MessageDsn_ArrivalDate
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use ArrivalDateUtc instead. Setting either ArrivalDate
        /// or ArrivalDateUtc results in both ArrivalDate and ArrivalDateUtc being assigned, the
        /// latest assignment to either one of the two property is reflected in the value of both.
        /// ArrivalDate is provided for backwards compatibility only and assigning a non-Utc DateTime
        /// to it results in the wrong timestamp being passed to the service.</para><para>When the message was received by the reporting mail transfer agent (MTA), in <a href="https://www.ietf.org/rfc/rfc0822.txt">RFC
        /// 822</a> date-time format.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use MessageDsn_UtcArrivalDate instead.")]
        public System.DateTime? MessageDsn_ArrivalDate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.SendBounceResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmail.Model.SendBounceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BouncedRecipientInfoList parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BouncedRecipientInfoList' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BouncedRecipientInfoList' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BounceSender), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SESBounce (SendBounce)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.SendBounceResponse, SendSESBounceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BouncedRecipientInfoList;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BouncedRecipientInfoList != null)
            {
                context.BouncedRecipientInfoList = new List<Amazon.SimpleEmail.Model.BouncedRecipientInfo>(this.BouncedRecipientInfoList);
            }
            #if MODULAR
            if (this.BouncedRecipientInfoList == null && ParameterWasBound(nameof(this.BouncedRecipientInfoList)))
            {
                WriteWarning("You are passing $null as a value for parameter BouncedRecipientInfoList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BounceSender = this.BounceSender;
            #if MODULAR
            if (this.BounceSender == null && ParameterWasBound(nameof(this.BounceSender)))
            {
                WriteWarning("You are passing $null as a value for parameter BounceSender which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BounceSenderArn = this.BounceSenderArn;
            context.Explanation = this.Explanation;
            context.MessageDsn_UtcArrivalDate = this.MessageDsn_UtcArrivalDate;
            if (this.MessageDsn_ExtensionField != null)
            {
                context.MessageDsn_ExtensionField = new List<Amazon.SimpleEmail.Model.ExtensionField>(this.MessageDsn_ExtensionField);
            }
            context.MessageDsn_ReportingMta = this.MessageDsn_ReportingMta;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MessageDsn_ArrivalDate = this.MessageDsn_ArrivalDate;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.OriginalMessageId = this.OriginalMessageId;
            #if MODULAR
            if (this.OriginalMessageId == null && ParameterWasBound(nameof(this.OriginalMessageId)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginalMessageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmail.Model.SendBounceRequest();
            
            if (cmdletContext.BouncedRecipientInfoList != null)
            {
                request.BouncedRecipientInfoList = cmdletContext.BouncedRecipientInfoList;
            }
            if (cmdletContext.BounceSender != null)
            {
                request.BounceSender = cmdletContext.BounceSender;
            }
            if (cmdletContext.BounceSenderArn != null)
            {
                request.BounceSenderArn = cmdletContext.BounceSenderArn;
            }
            if (cmdletContext.Explanation != null)
            {
                request.Explanation = cmdletContext.Explanation;
            }
            
             // populate MessageDsn
            var requestMessageDsnIsNull = true;
            request.MessageDsn = new Amazon.SimpleEmail.Model.MessageDsn();
            System.DateTime? requestMessageDsn_messageDsn_UtcArrivalDate = null;
            if (cmdletContext.MessageDsn_UtcArrivalDate != null)
            {
                requestMessageDsn_messageDsn_UtcArrivalDate = cmdletContext.MessageDsn_UtcArrivalDate.Value;
            }
            if (requestMessageDsn_messageDsn_UtcArrivalDate != null)
            {
                request.MessageDsn.ArrivalDateUtc = requestMessageDsn_messageDsn_UtcArrivalDate.Value;
                requestMessageDsnIsNull = false;
            }
            List<Amazon.SimpleEmail.Model.ExtensionField> requestMessageDsn_messageDsn_ExtensionField = null;
            if (cmdletContext.MessageDsn_ExtensionField != null)
            {
                requestMessageDsn_messageDsn_ExtensionField = cmdletContext.MessageDsn_ExtensionField;
            }
            if (requestMessageDsn_messageDsn_ExtensionField != null)
            {
                request.MessageDsn.ExtensionFields = requestMessageDsn_messageDsn_ExtensionField;
                requestMessageDsnIsNull = false;
            }
            System.String requestMessageDsn_messageDsn_ReportingMta = null;
            if (cmdletContext.MessageDsn_ReportingMta != null)
            {
                requestMessageDsn_messageDsn_ReportingMta = cmdletContext.MessageDsn_ReportingMta;
            }
            if (requestMessageDsn_messageDsn_ReportingMta != null)
            {
                request.MessageDsn.ReportingMta = requestMessageDsn_messageDsn_ReportingMta;
                requestMessageDsnIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestMessageDsn_messageDsn_ArrivalDate = null;
            if (cmdletContext.MessageDsn_ArrivalDate != null)
            {
                if (cmdletContext.MessageDsn_UtcArrivalDate != null)
                {
                    throw new System.ArgumentException("Parameters MessageDsn_ArrivalDate and MessageDsn_UtcArrivalDate are mutually exclusive.", nameof(this.MessageDsn_ArrivalDate));
                }
                requestMessageDsn_messageDsn_ArrivalDate = cmdletContext.MessageDsn_ArrivalDate.Value;
            }
            if (requestMessageDsn_messageDsn_ArrivalDate != null)
            {
                request.MessageDsn.ArrivalDate = requestMessageDsn_messageDsn_ArrivalDate.Value;
                requestMessageDsnIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if request.MessageDsn should be set to null
            if (requestMessageDsnIsNull)
            {
                request.MessageDsn = null;
            }
            if (cmdletContext.OriginalMessageId != null)
            {
                request.OriginalMessageId = cmdletContext.OriginalMessageId;
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
        
        private Amazon.SimpleEmail.Model.SendBounceResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SendBounceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "SendBounce");
            try
            {
                #if DESKTOP
                return client.SendBounce(request);
                #elif CORECLR
                return client.SendBounceAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleEmail.Model.BouncedRecipientInfo> BouncedRecipientInfoList { get; set; }
            public System.String BounceSender { get; set; }
            public System.String BounceSenderArn { get; set; }
            public System.String Explanation { get; set; }
            public System.DateTime? MessageDsn_UtcArrivalDate { get; set; }
            public List<Amazon.SimpleEmail.Model.ExtensionField> MessageDsn_ExtensionField { get; set; }
            public System.String MessageDsn_ReportingMta { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? MessageDsn_ArrivalDate { get; set; }
            public System.String OriginalMessageId { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.SendBounceResponse, SendSESBounceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
