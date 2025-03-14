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
using Amazon.B2bi;
using Amazon.B2bi.Model;

namespace Amazon.PowerShell.Cmdlets.B2BI
{
    /// <summary>
    /// Creates a partnership between a customer and a trading partner, based on the supplied
    /// parameters. A partnership represents the connection between you and your trading partner.
    /// It ties together a profile and one or more trading capabilities.
    /// </summary>
    [Cmdlet("New", "B2BIPartnership", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.B2bi.Model.CreatePartnershipResponse")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange CreatePartnership API operation.", Operation = new[] {"CreatePartnership"}, SelectReturnType = typeof(Amazon.B2bi.Model.CreatePartnershipResponse))]
    [AWSCmdletOutput("Amazon.B2bi.Model.CreatePartnershipResponse",
        "This cmdlet returns an Amazon.B2bi.Model.CreatePartnershipResponse object containing multiple properties."
    )]
    public partial class NewB2BIPartnershipCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>Specifies a list of the capabilities associated with this partnership.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>Specifies the email address associated with this trading partner.</para>
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
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies a descriptive name for the partnership.</para>
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
        
        #region Parameter Phone
        /// <summary>
        /// <para>
        /// <para>Specifies the phone number associated with the partnership.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Phone { get; set; }
        #endregion
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para>Specifies the unique, system-generated identifier for the profile connected to this
        /// partnership.</para>
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
        public System.String ProfileId { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies the key-value pairs assigned to ARNs that you can use to group and search
        /// for resources by type. You can attach this metadata to resources (capabilities, partnerships,
        /// and so on) for any purpose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.B2bi.Model.Tag[] Tag { get; set; }
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.CreatePartnershipResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.CreatePartnershipResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-B2BIPartnership (CreatePartnership)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.CreatePartnershipResponse, NewB2BIPartnershipCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            #if MODULAR
            if (this.Capability == null && ParameterWasBound(nameof(this.Capability)))
            {
                WriteWarning("You are passing $null as a value for parameter Capability which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Delimiters_ComponentSeparator = this.Delimiters_ComponentSeparator;
            context.Delimiters_DataElementSeparator = this.Delimiters_DataElementSeparator;
            context.Delimiters_SegmentTerminator = this.Delimiters_SegmentTerminator;
            context.FunctionalGroupHeaders_ApplicationReceiverCode = this.FunctionalGroupHeaders_ApplicationReceiverCode;
            context.FunctionalGroupHeaders_ApplicationSenderCode = this.FunctionalGroupHeaders_ApplicationSenderCode;
            context.FunctionalGroupHeaders_ResponsibleAgencyCode = this.FunctionalGroupHeaders_ResponsibleAgencyCode;
            context.InterchangeControlHeaders_AcknowledgmentRequestedCode = this.InterchangeControlHeaders_AcknowledgmentRequestedCode;
            context.InterchangeControlHeaders_ReceiverId = this.InterchangeControlHeaders_ReceiverId;
            context.InterchangeControlHeaders_ReceiverIdQualifier = this.InterchangeControlHeaders_ReceiverIdQualifier;
            context.InterchangeControlHeaders_RepetitionSeparator = this.InterchangeControlHeaders_RepetitionSeparator;
            context.InterchangeControlHeaders_SenderId = this.InterchangeControlHeaders_SenderId;
            context.InterchangeControlHeaders_SenderIdQualifier = this.InterchangeControlHeaders_SenderIdQualifier;
            context.InterchangeControlHeaders_UsageIndicatorCode = this.InterchangeControlHeaders_UsageIndicatorCode;
            context.Common_ValidateEdi = this.Common_ValidateEdi;
            context.ClientToken = this.ClientToken;
            context.Email = this.Email;
            #if MODULAR
            if (this.Email == null && ParameterWasBound(nameof(this.Email)))
            {
                WriteWarning("You are passing $null as a value for parameter Email which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Phone = this.Phone;
            context.ProfileId = this.ProfileId;
            #if MODULAR
            if (this.ProfileId == null && ParameterWasBound(nameof(this.ProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.B2bi.Model.Tag>(this.Tag);
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
            var request = new Amazon.B2bi.Model.CreatePartnershipRequest();
            
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            
             // populate CapabilityOptions
            var requestCapabilityOptionsIsNull = true;
            request.CapabilityOptions = new Amazon.B2bi.Model.CapabilityOptions();
            Amazon.B2bi.Model.OutboundEdiOptions requestCapabilityOptions_capabilityOptions_OutboundEdi = null;
            
             // populate OutboundEdi
            var requestCapabilityOptions_capabilityOptions_OutboundEdiIsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi = new Amazon.B2bi.Model.OutboundEdiOptions();
            Amazon.B2bi.Model.X12Envelope requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12 = null;
            
             // populate X12
            var requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12IsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12 = new Amazon.B2bi.Model.X12Envelope();
            Amazon.B2bi.Model.X12OutboundEdiHeaders requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common = null;
            
             // populate Common
            var requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_CommonIsNull = true;
            requestCapabilityOptions_capabilityOptions_OutboundEdi_capabilityOptions_OutboundEdi_X12_capabilityOptions_OutboundEdi_X12_Common = new Amazon.B2bi.Model.X12OutboundEdiHeaders();
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
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Phone != null)
            {
                request.Phone = cmdletContext.Phone;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileId = cmdletContext.ProfileId;
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
        
        private Amazon.B2bi.Model.CreatePartnershipResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.CreatePartnershipRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "CreatePartnership");
            try
            {
                #if DESKTOP
                return client.CreatePartnership(request);
                #elif CORECLR
                return client.CreatePartnershipAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Capability { get; set; }
            public System.String Delimiters_ComponentSeparator { get; set; }
            public System.String Delimiters_DataElementSeparator { get; set; }
            public System.String Delimiters_SegmentTerminator { get; set; }
            public System.String FunctionalGroupHeaders_ApplicationReceiverCode { get; set; }
            public System.String FunctionalGroupHeaders_ApplicationSenderCode { get; set; }
            public System.String FunctionalGroupHeaders_ResponsibleAgencyCode { get; set; }
            public System.String InterchangeControlHeaders_AcknowledgmentRequestedCode { get; set; }
            public System.String InterchangeControlHeaders_ReceiverId { get; set; }
            public System.String InterchangeControlHeaders_ReceiverIdQualifier { get; set; }
            public System.String InterchangeControlHeaders_RepetitionSeparator { get; set; }
            public System.String InterchangeControlHeaders_SenderId { get; set; }
            public System.String InterchangeControlHeaders_SenderIdQualifier { get; set; }
            public System.String InterchangeControlHeaders_UsageIndicatorCode { get; set; }
            public System.Boolean? Common_ValidateEdi { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Email { get; set; }
            public System.String Name { get; set; }
            public System.String Phone { get; set; }
            public System.String ProfileId { get; set; }
            public List<Amazon.B2bi.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.B2bi.Model.CreatePartnershipResponse, NewB2BIPartnershipCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
