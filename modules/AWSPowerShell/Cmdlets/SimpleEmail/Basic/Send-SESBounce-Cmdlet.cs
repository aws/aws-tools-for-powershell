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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

#pragma warning disable CS0618, CS0612
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
        "The service call response (type Amazon.SimpleEmail.Model.SendBounceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendSESBounceCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MessageDsn_ArrivalDate
        /// <summary>
        /// <para>
        /// <para>When the message was received by the reporting mail transfer agent (MTA), in <a href="https://www.ietf.org/rfc/rfc0822.txt">RFC
        /// 822</a> date-time format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? MessageDsn_ArrivalDate { get; set; }
        #endregion
        
        #region Parameter BouncedRecipientInfoList
        /// <summary>
        /// <para>
        /// <para>A list of recipients of the bounced message, including the information required to
        /// create the Delivery Status Notifications (DSNs) for the recipients. You must specify
        /// at least one <c>BouncedRecipientInfo</c> in the list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>Additional X-headers to include in the DSN.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <a href="https://tools.ietf.org/html/rfc3464">RFC 3464</a> (<c>mta-name-type; mta-name</c>).
        /// The default value is <c>dns; inbound-smtp.[region].amazonaws.com</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageDsn_ReportingMta { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BounceSender), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SESBounce (SendBounce)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.SendBounceResponse, SendSESBounceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.MessageDsn_ArrivalDate = this.MessageDsn_ArrivalDate;
            if (this.MessageDsn_ExtensionField != null)
            {
                context.MessageDsn_ExtensionField = new List<Amazon.SimpleEmail.Model.ExtensionField>(this.MessageDsn_ExtensionField);
            }
            context.MessageDsn_ReportingMta = this.MessageDsn_ReportingMta;
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
            System.DateTime? requestMessageDsn_messageDsn_ArrivalDate = null;
            if (cmdletContext.MessageDsn_ArrivalDate != null)
            {
                requestMessageDsn_messageDsn_ArrivalDate = cmdletContext.MessageDsn_ArrivalDate.Value;
            }
            if (requestMessageDsn_messageDsn_ArrivalDate != null)
            {
                request.MessageDsn.ArrivalDate = requestMessageDsn_messageDsn_ArrivalDate.Value;
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
                return client.SendBounceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? MessageDsn_ArrivalDate { get; set; }
            public List<Amazon.SimpleEmail.Model.ExtensionField> MessageDsn_ExtensionField { get; set; }
            public System.String MessageDsn_ReportingMta { get; set; }
            public System.String OriginalMessageId { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.SendBounceResponse, SendSESBounceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
