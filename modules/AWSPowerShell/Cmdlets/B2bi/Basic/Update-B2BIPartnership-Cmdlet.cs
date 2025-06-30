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
using Amazon.B2bi;
using Amazon.B2bi.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.B2BI
{
    /// <summary>
    /// Updates some of the parameters for a partnership between a customer and trading partner.
    /// A partnership represents the connection between you and your trading partner. It ties
    /// together a profile and one or more trading capabilities.
    /// </summary>
    [Cmdlet("Update", "B2BIPartnership", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.B2bi.Model.UpdatePartnershipResponse")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange UpdatePartnership API operation.", Operation = new[] {"UpdatePartnership"}, SelectReturnType = typeof(Amazon.B2bi.Model.UpdatePartnershipResponse))]
    [AWSCmdletOutput("Amazon.B2bi.Model.UpdatePartnershipResponse",
        "This cmdlet returns an Amazon.B2bi.Model.UpdatePartnershipResponse object containing multiple properties."
    )]
    public partial class UpdateB2BIPartnershipCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InterchangeControlHeaders_AcknowledgmentRequestedCode
        /// <summary>
        /// <para>
        /// <para>Located at position ISA-14 in the header. The value "1" indicates that the sender
        /// is requesting an interchange acknowledgment at receipt of the interchange. The value
        /// "0" is used otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_AcknowledgmentRequestedCode")]
        public System.String InterchangeControlHeaders_AcknowledgmentRequestedCode { get; set; }
        #endregion
        
        #region Parameter FunctionalGroupHeaders_ApplicationReceiverCode
        /// <summary>
        /// <para>
        /// <para>A value representing the code used to identify the party receiving a message, at position
        /// GS-03.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_ApplicationReceiverCode")]
        public System.String FunctionalGroupHeaders_ApplicationReceiverCode { get; set; }
        #endregion
        
        #region Parameter FunctionalGroupHeaders_ApplicationSenderCode
        /// <summary>
        /// <para>
        /// <para>A value representing the code used to identify the party transmitting a message, at
        /// position GS-02.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_ApplicationSenderCode")]
        public System.String FunctionalGroupHeaders_ApplicationSenderCode { get; set; }
        #endregion
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>List of the capabilities associated with this partnership.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter Delimiters_ComponentSeparator
        /// <summary>
        /// <para>
        /// <para>The component, or sub-element, separator. The default value is <c>:</c> (colon).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_Delimiters_ComponentSeparator")]
        public System.String Delimiters_ComponentSeparator { get; set; }
        #endregion
        
        #region Parameter Delimiters_DataElementSeparator
        /// <summary>
        /// <para>
        /// <para>The data element separator. The default value is <c>*</c> (asterisk).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_Delimiters_DataElementSeparator")]
        public System.String Delimiters_DataElementSeparator { get; set; }
        #endregion
        
        #region Parameter AcknowledgmentOptions_FunctionalAcknowledgment
        /// <summary>
        /// <para>
        /// <para>Specifies whether functional acknowledgments (997/999) should be generated for incoming
        /// X12 transactions. Valid values are <c>DO_NOT_GENERATE</c>, <c>GENERATE_ALL_SEGMENTS</c>
        /// and <c>GENERATE_WITHOUT_TRANSACTION_SET_RESPONSE_LOOP</c>.</para><para>If you choose <c>GENERATE_WITHOUT_TRANSACTION_SET_RESPONSE_LOOP</c>, Amazon Web Services
        /// B2B Data Interchange skips the AK2_Loop when generating an acknowledgment document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_InboundEdi_X12_AcknowledgmentOptions_FunctionalAcknowledgment")]
        [AWSConstantClassSource("Amazon.B2bi.X12FunctionalAcknowledgment")]
        public Amazon.B2bi.X12FunctionalAcknowledgment AcknowledgmentOptions_FunctionalAcknowledgment { get; set; }
        #endregion
        
        #region Parameter Common_Gs05TimeFormat
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_Gs05TimeFormat")]
        [AWSConstantClassSource("Amazon.B2bi.X12GS05TimeFormat")]
        public Amazon.B2bi.X12GS05TimeFormat Common_Gs05TimeFormat { get; set; }
        #endregion
        
        #region Parameter WrapOptions_LineLength
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum length of a line before wrapping occurs. This value is used
        /// when <c>wrapBy</c> is set to <c>LINE_LENGTH</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_WrapOptions_LineLength")]
        public System.Int32? WrapOptions_LineLength { get; set; }
        #endregion
        
        #region Parameter WrapOptions_LineTerminator
        /// <summary>
        /// <para>
        /// <para>Specifies the character sequence used to terminate lines when wrapping. Valid values:</para><ul><li><para><c>CRLF</c>: carriage return and line feed</para></li><li><para><c>LF</c>: line feed)</para></li><li><para><c>CR</c>: carriage return</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_WrapOptions_LineTerminator")]
        [AWSConstantClassSource("Amazon.B2bi.LineTerminator")]
        public Amazon.B2bi.LineTerminator WrapOptions_LineTerminator { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the partnership, used to identify it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PartnershipId
        /// <summary>
        /// <para>
        /// <para>Specifies the unique, system-generated identifier for a partnership.</para>
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
        public System.String PartnershipId { get; set; }
        #endregion
        
        #region Parameter InterchangeControlHeaders_ReceiverId
        /// <summary>
        /// <para>
        /// <para>Located at position ISA-08 in the header. This value (along with the <c>receiverIdQualifier</c>)
        /// identifies the intended recipient of the interchange. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_ReceiverId")]
        public System.String InterchangeControlHeaders_ReceiverId { get; set; }
        #endregion
        
        #region Parameter InterchangeControlHeaders_ReceiverIdQualifier
        /// <summary>
        /// <para>
        /// <para>Located at position ISA-07 in the header. Qualifier for the receiver ID. Together,
        /// the ID and qualifier uniquely identify the receiving trading partner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_ReceiverIdQualifier")]
        public System.String InterchangeControlHeaders_ReceiverIdQualifier { get; set; }
        #endregion
        
        #region Parameter InterchangeControlHeaders_RepetitionSeparator
        /// <summary>
        /// <para>
        /// <para>Located at position ISA-11 in the header. This string makes it easier when you need
        /// to group similar adjacent element values together without using extra segments.</para><note><para>This parameter is only honored for version greater than 401 (<c>VERSION_4010</c> and
        /// higher).</para><para>For versions less than 401, this field is called <a href="https://www.stedi.com/edi/x12-004010/segment/ISA#ISA-11">StandardsId</a>,
        /// in which case our service sets the value to <c>U</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_RepetitionSeparator")]
        public System.String InterchangeControlHeaders_RepetitionSeparator { get; set; }
        #endregion
        
        #region Parameter FunctionalGroupHeaders_ResponsibleAgencyCode
        /// <summary>
        /// <para>
        /// <para>A code that identifies the issuer of the standard, at position GS-07.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_ResponsibleAgencyCode")]
        public System.String FunctionalGroupHeaders_ResponsibleAgencyCode { get; set; }
        #endregion
        
        #region Parameter Delimiters_SegmentTerminator
        /// <summary>
        /// <para>
        /// <para>The segment terminator. The default value is <c>~</c> (tilde).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_Delimiters_SegmentTerminator")]
        public System.String Delimiters_SegmentTerminator { get; set; }
        #endregion
        
        #region Parameter InterchangeControlHeaders_SenderId
        /// <summary>
        /// <para>
        /// <para>Located at position ISA-06 in the header. This value (along with the <c>senderIdQualifier</c>)
        /// identifies the sender of the interchange. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_SenderId")]
        public System.String InterchangeControlHeaders_SenderId { get; set; }
        #endregion
        
        #region Parameter InterchangeControlHeaders_SenderIdQualifier
        /// <summary>
        /// <para>
        /// <para>Located at position ISA-05 in the header. Qualifier for the sender ID. Together, the
        /// ID and qualifier uniquely identify the sending trading partner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_SenderIdQualifier")]
        public System.String InterchangeControlHeaders_SenderIdQualifier { get; set; }
        #endregion
        
        #region Parameter ControlNumbers_StartingFunctionalGroupControlNumber
        /// <summary>
        /// <para>
        /// <para>Specifies the starting functional group control number (GS06) to use for X12 EDI generation.
        /// This number is incremented for each new functional group. For the GS (functional group)
        /// envelope, Amazon Web Services B2B Data Interchange generates a functional group control
        /// number that is unique to the sender ID, receiver ID, and functional identifier code
        /// combination. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_ControlNumbers_StartingFunctionalGroupControlNumber")]
        public System.Int32? ControlNumbers_StartingFunctionalGroupControlNumber { get; set; }
        #endregion
        
        #region Parameter ControlNumbers_StartingInterchangeControlNumber
        /// <summary>
        /// <para>
        /// <para>Specifies the starting interchange control number (ISA13) to use for X12 EDI generation.
        /// This number is incremented for each new interchange. For the ISA (interchange) envelope,
        /// Amazon Web Services B2B Data Interchange generates an interchange control number that
        /// is unique for the ISA05 and ISA06 (sender) &amp; ISA07 and ISA08 (receiver) combination.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_ControlNumbers_StartingInterchangeControlNumber")]
        public System.Int32? ControlNumbers_StartingInterchangeControlNumber { get; set; }
        #endregion
        
        #region Parameter ControlNumbers_StartingTransactionSetControlNumber
        /// <summary>
        /// <para>
        /// <para>Specifies the starting transaction set control number (ST02) to use for X12 EDI generation.
        /// This number is incremented for each new transaction set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_ControlNumbers_StartingTransactionSetControlNumber")]
        public System.Int32? ControlNumbers_StartingTransactionSetControlNumber { get; set; }
        #endregion
        
        #region Parameter AcknowledgmentOptions_TechnicalAcknowledgment
        /// <summary>
        /// <para>
        /// <para>Specifies whether technical acknowledgments (TA1) should be generated for incoming
        /// X12 interchanges. Valid values are <c>DO_NOT_GENERATE</c> and <c>GENERATE_ALL_SEGMENTS</c>
        /// and.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_InboundEdi_X12_AcknowledgmentOptions_TechnicalAcknowledgment")]
        [AWSConstantClassSource("Amazon.B2bi.X12TechnicalAcknowledgment")]
        public Amazon.B2bi.X12TechnicalAcknowledgment AcknowledgmentOptions_TechnicalAcknowledgment { get; set; }
        #endregion
        
        #region Parameter InterchangeControlHeaders_UsageIndicatorCode
        /// <summary>
        /// <para>
        /// <para>Located at position ISA-15 in the header. Specifies how this interchange is being
        /// used:</para><ul><li><para><c>T</c> indicates this interchange is for testing.</para></li><li><para><c>P</c> indicates this interchange is for production.</para></li><li><para><c>I</c> indicates this interchange is informational.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_UsageIndicatorCode")]
        public System.String InterchangeControlHeaders_UsageIndicatorCode { get; set; }
        #endregion
        
        #region Parameter Common_ValidateEdi
        /// <summary>
        /// <para>
        /// <para>Specifies whether or not to validate the EDI for this X12 object: <c>TRUE</c> or <c>FALSE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_Common_ValidateEdi")]
        public System.Boolean? Common_ValidateEdi { get; set; }
        #endregion
        
        #region Parameter WrapOptions_WrapBy
        /// <summary>
        /// <para>
        /// <para>Specifies the method used for wrapping lines in the EDI output. Valid values:</para><ul><li><para><c>SEGMENT</c>: Wraps by segment.</para></li><li><para><c>ONE_LINE</c>: Indicates that the entire content is on a single line.</para><note><para>When you specify <c>ONE_LINE</c>, do not provide either the line length nor the line
        /// terminator value.</para></note></li><li><para><c>LINE_LENGTH</c>: Wraps by character count, as specified by <c>lineLength</c> value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapabilityOptions_OutboundEdi_X12_WrapOptions_WrapBy")]
        [AWSConstantClassSource("Amazon.B2bi.WrapFormat")]
        public Amazon.B2bi.WrapFormat WrapOptions_WrapBy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.UpdatePartnershipResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.UpdatePartnershipResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PartnershipId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-B2BIPartnership (UpdatePartnership)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.UpdatePartnershipResponse, UpdateB2BIPartnershipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            context.AcknowledgmentOptions_FunctionalAcknowledgment = this.AcknowledgmentOptions_FunctionalAcknowledgment;
            context.AcknowledgmentOptions_TechnicalAcknowledgment = this.AcknowledgmentOptions_TechnicalAcknowledgment;
            context.ControlNumbers_StartingFunctionalGroupControlNumber = this.ControlNumbers_StartingFunctionalGroupControlNumber;
            context.ControlNumbers_StartingInterchangeControlNumber = this.ControlNumbers_StartingInterchangeControlNumber;
            context.ControlNumbers_StartingTransactionSetControlNumber = this.ControlNumbers_StartingTransactionSetControlNumber;
            context.Delimiters_ComponentSeparator = this.Delimiters_ComponentSeparator;
            context.Delimiters_DataElementSeparator = this.Delimiters_DataElementSeparator;
            context.Delimiters_SegmentTerminator = this.Delimiters_SegmentTerminator;
            context.FunctionalGroupHeaders_ApplicationReceiverCode = this.FunctionalGroupHeaders_ApplicationReceiverCode;
            context.FunctionalGroupHeaders_ApplicationSenderCode = this.FunctionalGroupHeaders_ApplicationSenderCode;
            context.FunctionalGroupHeaders_ResponsibleAgencyCode = this.FunctionalGroupHeaders_ResponsibleAgencyCode;
            context.Common_Gs05TimeFormat = this.Common_Gs05TimeFormat;
            context.InterchangeControlHeaders_AcknowledgmentRequestedCode = this.InterchangeControlHeaders_AcknowledgmentRequestedCode;
            context.InterchangeControlHeaders_ReceiverId = this.InterchangeControlHeaders_ReceiverId;
            context.InterchangeControlHeaders_ReceiverIdQualifier = this.InterchangeControlHeaders_ReceiverIdQualifier;
            context.InterchangeControlHeaders_RepetitionSeparator = this.InterchangeControlHeaders_RepetitionSeparator;
            context.InterchangeControlHeaders_SenderId = this.InterchangeControlHeaders_SenderId;
            context.InterchangeControlHeaders_SenderIdQualifier = this.InterchangeControlHeaders_SenderIdQualifier;
            context.InterchangeControlHeaders_UsageIndicatorCode = this.InterchangeControlHeaders_UsageIndicatorCode;
            context.Common_ValidateEdi = this.Common_ValidateEdi;
            context.WrapOptions_LineLength = this.WrapOptions_LineLength;
            context.WrapOptions_LineTerminator = this.WrapOptions_LineTerminator;
            context.WrapOptions_WrapBy = this.WrapOptions_WrapBy;
            context.Name = this.Name;
            context.PartnershipId = this.PartnershipId;
            #if MODULAR
            if (this.PartnershipId == null && ParameterWasBound(nameof(this.PartnershipId)))
            {
                WriteWarning("You are passing $null as a value for parameter PartnershipId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.B2bi.Model.UpdatePartnershipRequest();
            
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            
             // populate CapabilityOptions
            var requestCapabilityOptionsIsNull = true;
            request.CapabilityOptions = new Amazon.B2bi.Model.CapabilityOptions();
            Amazon.B2bi.Model.InboundEdiOptions requestCapabilityOptions_capabilityOptions_InboundEdi = null;
            
             // populate InboundEdi
            var requestCapabilityOptions_capabilityOptions_InboundEdiIsNull = true;
            requestCapabilityOptions_capabilityOptions_InboundEdi = new Amazon.B2bi.Model.InboundEdiOptions();
            Amazon.B2bi.Model.X12InboundEdiOptions requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12 = null;
            
             // populate X12
            var requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12IsNull = true;
            requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12 = new Amazon.B2bi.Model.X12InboundEdiOptions();
            Amazon.B2bi.Model.X12AcknowledgmentOptions requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions = null;
            
             // populate AcknowledgmentOptions
            var requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptionsIsNull = true;
            requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions = new Amazon.B2bi.Model.X12AcknowledgmentOptions();
            Amazon.B2bi.X12FunctionalAcknowledgment requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions_acknowledgmentOptions_FunctionalAcknowledgment = null;
            if (cmdletContext.AcknowledgmentOptions_FunctionalAcknowledgment != null)
            {
                requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions_acknowledgmentOptions_FunctionalAcknowledgment = cmdletContext.AcknowledgmentOptions_FunctionalAcknowledgment;
            }
            if (requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions_acknowledgmentOptions_FunctionalAcknowledgment != null)
            {
                requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions.FunctionalAcknowledgment = requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions_acknowledgmentOptions_FunctionalAcknowledgment;
                requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptionsIsNull = false;
            }
            Amazon.B2bi.X12TechnicalAcknowledgment requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions_acknowledgmentOptions_TechnicalAcknowledgment = null;
            if (cmdletContext.AcknowledgmentOptions_TechnicalAcknowledgment != null)
            {
                requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions_acknowledgmentOptions_TechnicalAcknowledgment = cmdletContext.AcknowledgmentOptions_TechnicalAcknowledgment;
            }
            if (requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions_acknowledgmentOptions_TechnicalAcknowledgment != null)
            {
                requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions.TechnicalAcknowledgment = requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions_acknowledgmentOptions_TechnicalAcknowledgment;
                requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptionsIsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions should be set to null
            if (requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptionsIsNull)
            {
                requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions = null;
            }
            if (requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions != null)
            {
                requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12.AcknowledgmentOptions = requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12_capabilityOptions_InboundEdi_X12_AcknowledgmentOptions;
                requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12IsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12 should be set to null
            if (requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12IsNull)
            {
                requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12 = null;
            }
            if (requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12 != null)
            {
                requestCapabilityOptions_capabilityOptions_InboundEdi.X12 = requestCapabilityOptions_capabilityOptions_InboundEdi_capabilityOptions_InboundEdi_X12;
                requestCapabilityOptions_capabilityOptions_InboundEdiIsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_InboundEdi should be set to null
            if (requestCapabilityOptions_capabilityOptions_InboundEdiIsNull)
            {
                requestCapabilityOptions_capabilityOptions_InboundEdi = null;
            }
            if (requestCapabilityOptions_capabilityOptions_InboundEdi != null)
            {
                request.CapabilityOptions.InboundEdi = requestCapabilityOptions_capabilityOptions_InboundEdi;
                requestCapabilityOptionsIsNull = false;
            }
            Amazon.B2bi.Model.OutboundEdiOptions requestCapabilityOptions_capabilityOptions_OutboundEdi = null;
            
             // populate OutboundEdi
            var requestCapabilityOptions_capabilityOptions_OutboundEdiIsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi = new Amazon.B2bi.Model.OutboundEdiOptions();
            Amazon.B2bi.Model.X12Envelope requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12 = null;
            
             // populate X12
            var requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12IsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12 = new Amazon.B2bi.Model.X12Envelope();
            Amazon.B2bi.Model.WrapOptions requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions = null;
            
             // populate WrapOptions
            var requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptionsIsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions = new Amazon.B2bi.Model.WrapOptions();
            System.Int32? requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_LineLength = null;
            if (cmdletContext.WrapOptions_LineLength != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_LineLength = cmdletContext.WrapOptions_LineLength.Value;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_LineLength != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions.LineLength = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_LineLength.Value;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptionsIsNull = false;
            }
            Amazon.B2bi.LineTerminator requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_LineTerminator = null;
            if (cmdletContext.WrapOptions_LineTerminator != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_LineTerminator = cmdletContext.WrapOptions_LineTerminator;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_LineTerminator != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions.LineTerminator = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_LineTerminator;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptionsIsNull = false;
            }
            Amazon.B2bi.WrapFormat requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_WrapBy = null;
            if (cmdletContext.WrapOptions_WrapBy != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_WrapBy = cmdletContext.WrapOptions_WrapBy;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_WrapBy != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions.WrapBy = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions_wrapOptions_WrapBy;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptionsIsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions should be set to null
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptionsIsNull)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions = null;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12.WrapOptions = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_WrapOptions;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12IsNull = false;
            }
            Amazon.B2bi.Model.X12OutboundEdiHeaders requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common = null;
            
             // populate Common
            var requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_CommonIsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common = new Amazon.B2bi.Model.X12OutboundEdiHeaders();
            Amazon.B2bi.X12GS05TimeFormat requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_common_Gs05TimeFormat = null;
            if (cmdletContext.Common_Gs05TimeFormat != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_common_Gs05TimeFormat = cmdletContext.Common_Gs05TimeFormat;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_common_Gs05TimeFormat != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common.Gs05TimeFormat = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_common_Gs05TimeFormat;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_CommonIsNull = false;
            }
            System.Boolean? requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_common_ValidateEdi = null;
            if (cmdletContext.Common_ValidateEdi != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_common_ValidateEdi = cmdletContext.Common_ValidateEdi.Value;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_common_ValidateEdi != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common.ValidateEdi = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_common_ValidateEdi.Value;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_CommonIsNull = false;
            }
            Amazon.B2bi.Model.X12ControlNumbers requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers = null;
            
             // populate ControlNumbers
            var requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbersIsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers = new Amazon.B2bi.Model.X12ControlNumbers();
            System.Int32? requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingFunctionalGroupControlNumber = null;
            if (cmdletContext.ControlNumbers_StartingFunctionalGroupControlNumber != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingFunctionalGroupControlNumber = cmdletContext.ControlNumbers_StartingFunctionalGroupControlNumber.Value;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingFunctionalGroupControlNumber != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers.StartingFunctionalGroupControlNumber = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingFunctionalGroupControlNumber.Value;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbersIsNull = false;
            }
            System.Int32? requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingInterchangeControlNumber = null;
            if (cmdletContext.ControlNumbers_StartingInterchangeControlNumber != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingInterchangeControlNumber = cmdletContext.ControlNumbers_StartingInterchangeControlNumber.Value;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingInterchangeControlNumber != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers.StartingInterchangeControlNumber = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingInterchangeControlNumber.Value;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbersIsNull = false;
            }
            System.Int32? requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingTransactionSetControlNumber = null;
            if (cmdletContext.ControlNumbers_StartingTransactionSetControlNumber != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingTransactionSetControlNumber = cmdletContext.ControlNumbers_StartingTransactionSetControlNumber.Value;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingTransactionSetControlNumber != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers.StartingTransactionSetControlNumber = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers_controlNumbers_StartingTransactionSetControlNumber.Value;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbersIsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers should be set to null
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbersIsNull)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers = null;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common.ControlNumbers = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_ControlNumbers;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_CommonIsNull = false;
            }
            Amazon.B2bi.Model.X12Delimiters requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters = null;
            
             // populate Delimiters
            var requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_DelimitersIsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters = new Amazon.B2bi.Model.X12Delimiters();
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_ComponentSeparator = null;
            if (cmdletContext.Delimiters_ComponentSeparator != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_ComponentSeparator = cmdletContext.Delimiters_ComponentSeparator;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_ComponentSeparator != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters.ComponentSeparator = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_ComponentSeparator;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_DelimitersIsNull = false;
            }
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_DataElementSeparator = null;
            if (cmdletContext.Delimiters_DataElementSeparator != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_DataElementSeparator = cmdletContext.Delimiters_DataElementSeparator;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_DataElementSeparator != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters.DataElementSeparator = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_DataElementSeparator;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_DelimitersIsNull = false;
            }
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_SegmentTerminator = null;
            if (cmdletContext.Delimiters_SegmentTerminator != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_SegmentTerminator = cmdletContext.Delimiters_SegmentTerminator;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_SegmentTerminator != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters.SegmentTerminator = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters_delimiters_SegmentTerminator;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_DelimitersIsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters should be set to null
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_DelimitersIsNull)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters = null;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common.Delimiters = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_Delimiters;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_CommonIsNull = false;
            }
            Amazon.B2bi.Model.X12FunctionalGroupHeaders requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders = null;
            
             // populate FunctionalGroupHeaders
            var requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeadersIsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders = new Amazon.B2bi.Model.X12FunctionalGroupHeaders();
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ApplicationReceiverCode = null;
            if (cmdletContext.FunctionalGroupHeaders_ApplicationReceiverCode != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ApplicationReceiverCode = cmdletContext.FunctionalGroupHeaders_ApplicationReceiverCode;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ApplicationReceiverCode != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders.ApplicationReceiverCode = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ApplicationReceiverCode;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeadersIsNull = false;
            }
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ApplicationSenderCode = null;
            if (cmdletContext.FunctionalGroupHeaders_ApplicationSenderCode != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ApplicationSenderCode = cmdletContext.FunctionalGroupHeaders_ApplicationSenderCode;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ApplicationSenderCode != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders.ApplicationSenderCode = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ApplicationSenderCode;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeadersIsNull = false;
            }
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ResponsibleAgencyCode = null;
            if (cmdletContext.FunctionalGroupHeaders_ResponsibleAgencyCode != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ResponsibleAgencyCode = cmdletContext.FunctionalGroupHeaders_ResponsibleAgencyCode;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ResponsibleAgencyCode != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders.ResponsibleAgencyCode = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders_functionalGroupHeaders_ResponsibleAgencyCode;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeadersIsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders should be set to null
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeadersIsNull)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders = null;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common.FunctionalGroupHeaders = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_FunctionalGroupHeaders;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_CommonIsNull = false;
            }
            Amazon.B2bi.Model.X12InterchangeControlHeaders requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders = null;
            
             // populate InterchangeControlHeaders
            var requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeadersIsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders = new Amazon.B2bi.Model.X12InterchangeControlHeaders();
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_AcknowledgmentRequestedCode = null;
            if (cmdletContext.InterchangeControlHeaders_AcknowledgmentRequestedCode != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_AcknowledgmentRequestedCode = cmdletContext.InterchangeControlHeaders_AcknowledgmentRequestedCode;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_AcknowledgmentRequestedCode != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders.AcknowledgmentRequestedCode = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_AcknowledgmentRequestedCode;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeadersIsNull = false;
            }
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_ReceiverId = null;
            if (cmdletContext.InterchangeControlHeaders_ReceiverId != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_ReceiverId = cmdletContext.InterchangeControlHeaders_ReceiverId;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_ReceiverId != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders.ReceiverId = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_ReceiverId;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeadersIsNull = false;
            }
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_ReceiverIdQualifier = null;
            if (cmdletContext.InterchangeControlHeaders_ReceiverIdQualifier != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_ReceiverIdQualifier = cmdletContext.InterchangeControlHeaders_ReceiverIdQualifier;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_ReceiverIdQualifier != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders.ReceiverIdQualifier = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_ReceiverIdQualifier;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeadersIsNull = false;
            }
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_RepetitionSeparator = null;
            if (cmdletContext.InterchangeControlHeaders_RepetitionSeparator != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_RepetitionSeparator = cmdletContext.InterchangeControlHeaders_RepetitionSeparator;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_RepetitionSeparator != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders.RepetitionSeparator = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_RepetitionSeparator;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeadersIsNull = false;
            }
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_SenderId = null;
            if (cmdletContext.InterchangeControlHeaders_SenderId != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_SenderId = cmdletContext.InterchangeControlHeaders_SenderId;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_SenderId != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders.SenderId = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_SenderId;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeadersIsNull = false;
            }
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_SenderIdQualifier = null;
            if (cmdletContext.InterchangeControlHeaders_SenderIdQualifier != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_SenderIdQualifier = cmdletContext.InterchangeControlHeaders_SenderIdQualifier;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_SenderIdQualifier != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders.SenderIdQualifier = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_SenderIdQualifier;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeadersIsNull = false;
            }
            System.String requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_UsageIndicatorCode = null;
            if (cmdletContext.InterchangeControlHeaders_UsageIndicatorCode != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_UsageIndicatorCode = cmdletContext.InterchangeControlHeaders_UsageIndicatorCode;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_UsageIndicatorCode != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders.UsageIndicatorCode = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders_interchangeControlHeaders_UsageIndicatorCode;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeadersIsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders should be set to null
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeadersIsNull)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders = null;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common.InterchangeControlHeaders = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common_capabilityOptions_OutboundEdi_X12_Common_InterchangeControlHeaders;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_CommonIsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common should be set to null
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_CommonIsNull)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common = null;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12.Common = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common;
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12IsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12 should be set to null
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12IsNull)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12 = null;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12 != null)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi.X12 = requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12;
                requestCapabilityOptions_capabilityOptions_OutboundEdiIsNull = false;
            }
             // determine if requestCapabilityOptions_capabilityOptions_OutboundEdi should be set to null
            if (requestCapabilityOptions_capabilityOptions_OutboundEdiIsNull)
            {
                requestCapabilityOptions_capabilityOptions_OutboundEdi = null;
            }
            if (requestCapabilityOptions_capabilityOptions_OutboundEdi != null)
            {
                request.CapabilityOptions.OutboundEdi = requestCapabilityOptions_capabilityOptions_OutboundEdi;
                requestCapabilityOptionsIsNull = false;
            }
             // determine if request.CapabilityOptions should be set to null
            if (requestCapabilityOptionsIsNull)
            {
                request.CapabilityOptions = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PartnershipId != null)
            {
                request.PartnershipId = cmdletContext.PartnershipId;
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
        
        private Amazon.B2bi.Model.UpdatePartnershipResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.UpdatePartnershipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "UpdatePartnership");
            try
            {
                return client.UpdatePartnershipAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Capability { get; set; }
            public Amazon.B2bi.X12FunctionalAcknowledgment AcknowledgmentOptions_FunctionalAcknowledgment { get; set; }
            public Amazon.B2bi.X12TechnicalAcknowledgment AcknowledgmentOptions_TechnicalAcknowledgment { get; set; }
            public System.Int32? ControlNumbers_StartingFunctionalGroupControlNumber { get; set; }
            public System.Int32? ControlNumbers_StartingInterchangeControlNumber { get; set; }
            public System.Int32? ControlNumbers_StartingTransactionSetControlNumber { get; set; }
            public System.String Delimiters_ComponentSeparator { get; set; }
            public System.String Delimiters_DataElementSeparator { get; set; }
            public System.String Delimiters_SegmentTerminator { get; set; }
            public System.String FunctionalGroupHeaders_ApplicationReceiverCode { get; set; }
            public System.String FunctionalGroupHeaders_ApplicationSenderCode { get; set; }
            public System.String FunctionalGroupHeaders_ResponsibleAgencyCode { get; set; }
            public Amazon.B2bi.X12GS05TimeFormat Common_Gs05TimeFormat { get; set; }
            public System.String InterchangeControlHeaders_AcknowledgmentRequestedCode { get; set; }
            public System.String InterchangeControlHeaders_ReceiverId { get; set; }
            public System.String InterchangeControlHeaders_ReceiverIdQualifier { get; set; }
            public System.String InterchangeControlHeaders_RepetitionSeparator { get; set; }
            public System.String InterchangeControlHeaders_SenderId { get; set; }
            public System.String InterchangeControlHeaders_SenderIdQualifier { get; set; }
            public System.String InterchangeControlHeaders_UsageIndicatorCode { get; set; }
            public System.Boolean? Common_ValidateEdi { get; set; }
            public System.Int32? WrapOptions_LineLength { get; set; }
            public Amazon.B2bi.LineTerminator WrapOptions_LineTerminator { get; set; }
            public Amazon.B2bi.WrapFormat WrapOptions_WrapBy { get; set; }
            public System.String Name { get; set; }
            public System.String PartnershipId { get; set; }
            public System.Func<Amazon.B2bi.Model.UpdatePartnershipResponse, UpdateB2BIPartnershipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
