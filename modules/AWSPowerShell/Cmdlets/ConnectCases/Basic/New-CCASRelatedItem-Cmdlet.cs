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
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

namespace Amazon.PowerShell.Cmdlets.CCAS
{
    /// <summary>
    /// Creates a related item (comments, tasks, and contacts) and associates it with a case.
    /// 
    ///  
    /// <para>
    /// There's a quota for the number of fields allowed in a Custom type related item. See
    /// <a href="https://docs.aws.amazon.com/connect/latest/adminguide/amazon-connect-service-limits.html#cases-quotas">Amazon
    /// Connect Cases quotas</a>.
    /// </para><para><b>Use cases</b></para><para>
    /// Following are examples of related items that you may want to associate with a case:
    /// </para><ul><li><para>
    /// Related contacts, such as calls, chats, emails tasks
    /// </para></li><li><para>
    /// Comments, for agent notes
    /// </para></li><li><para>
    /// SLAs, to capture target resolution goals
    /// </para></li><li><para>
    /// Cases, to capture related Amazon Connect Cases
    /// </para></li><li><para>
    /// Files, such as policy documentation or customer-provided attachments
    /// </para></li><li><para>
    /// Custom related items, which provide flexibility for you to define related items that
    /// such as bookings, orders, products, notices, and more
    /// </para></li></ul><para><b>Important things to know</b></para><ul><li><para>
    /// If you are associating a contact to a case by passing in <c>Contact</c> for a <c>type</c>,
    /// you must have <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DescribeContact.html">DescribeContact</a>
    /// permission on the ARN of the contact that you provide in <c>content.contact.contactArn</c>.
    /// </para></li><li><para>
    /// A Related Item is a resource that is associated with a case. It may or may not have
    /// an external identifier linking it to an external resource (for example, a <c>contactArn</c>).
    /// All Related Items have their own internal identifier, the <c>relatedItemArn</c>. Examples
    /// of related items include <c>comments</c> and <c>contacts</c>.
    /// </para></li><li><para>
    /// If you provide a value for <c>performedBy.userArn</c> you must also have <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DescribeUser.html">DescribeUser</a>
    /// permission on the ARN of the user that you provide.
    /// </para></li><li><para>
    /// The <c>type</c> field is reserved for internal use only.
    /// </para></li></ul><para><b>Endpoints</b>: See <a href="https://docs.aws.amazon.com/general/latest/gr/connect_region.html">Amazon
    /// Connect endpoints and quotas</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CCASRelatedItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCases.Model.CreateRelatedItemResponse")]
    [AWSCmdlet("Calls the Amazon Connect Cases CreateRelatedItem API operation.", Operation = new[] {"CreateRelatedItem"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.CreateRelatedItemResponse))]
    [AWSCmdletOutput("Amazon.ConnectCases.Model.CreateRelatedItemResponse",
        "This cmdlet returns an Amazon.ConnectCases.Model.CreateRelatedItemResponse object containing multiple properties."
    )]
    public partial class NewCCASRelatedItemCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Comment_Body
        /// <summary>
        /// <para>
        /// <para>Text in the body of a <c>Comment</c> on a case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Comment_Body")]
        public System.String Comment_Body { get; set; }
        #endregion
        
        #region Parameter CaseId
        /// <summary>
        /// <para>
        /// <para>A unique identifier of the case.</para>
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
        public System.String CaseId { get; set; }
        #endregion
        
        #region Parameter ConnectCase_CaseId
        /// <summary>
        /// <para>
        /// <para>A unique identifier of the case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_ConnectCase_CaseId")]
        public System.String ConnectCase_CaseId { get; set; }
        #endregion
        
        #region Parameter Contact_ContactArn
        /// <summary>
        /// <para>
        /// <para>A unique identifier of a contact in Amazon Connect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Contact_ContactArn")]
        public System.String Contact_ContactArn { get; set; }
        #endregion
        
        #region Parameter Comment_ContentType
        /// <summary>
        /// <para>
        /// <para>Type of the text in the box of a <c>Comment</c> on a case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Comment_ContentType")]
        [AWSConstantClassSource("Amazon.ConnectCases.CommentBodyTextType")]
        public Amazon.ConnectCases.CommentBodyTextType Comment_ContentType { get; set; }
        #endregion
        
        #region Parameter PerformedBy_CustomEntity
        /// <summary>
        /// <para>
        /// <para>Any provided entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformedBy_CustomEntity { get; set; }
        #endregion
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Cases domain. </para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter SlaInputConfiguration_FieldId
        /// <summary>
        /// <para>
        /// <para>Unique identifier of a field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Sla_SlaInputConfiguration_FieldId")]
        public System.String SlaInputConfiguration_FieldId { get; set; }
        #endregion
        
        #region Parameter Custom_Field
        /// <summary>
        /// <para>
        /// <para>List of field values for the <c>Custom</c> related item.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Custom_Fields")]
        public Amazon.ConnectCases.Model.FieldValue[] Custom_Field { get; set; }
        #endregion
        
        #region Parameter File_FileArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a File in Amazon Connect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_File_FileArn")]
        public System.String File_FileArn { get; set; }
        #endregion
        
        #region Parameter SlaInputConfiguration_Name
        /// <summary>
        /// <para>
        /// <para>Name of an SLA.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Sla_SlaInputConfiguration_Name")]
        public System.String SlaInputConfiguration_Name { get; set; }
        #endregion
        
        #region Parameter SlaInputConfiguration_TargetFieldValue
        /// <summary>
        /// <para>
        /// <para>Represents a list of target field values for the fieldId specified in SlaInputConfiguration.
        /// The SLA is considered met if any one of these target field values matches the actual
        /// field value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Sla_SlaInputConfiguration_TargetFieldValues")]
        public Amazon.ConnectCases.Model.FieldValueUnion[] SlaInputConfiguration_TargetFieldValue { get; set; }
        #endregion
        
        #region Parameter SlaInputConfiguration_TargetSlaMinute
        /// <summary>
        /// <para>
        /// <para>Target duration in minutes within which an SLA should be completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Sla_SlaInputConfiguration_TargetSlaMinutes")]
        public System.Int64? SlaInputConfiguration_TargetSlaMinute { get; set; }
        #endregion
        
        #region Parameter SlaInputConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>Type of SLA.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Sla_SlaInputConfiguration_Type")]
        [AWSConstantClassSource("Amazon.ConnectCases.SlaType")]
        public Amazon.ConnectCases.SlaType SlaInputConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of a related item.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ConnectCases.RelatedItemType")]
        public Amazon.ConnectCases.RelatedItemType Type { get; set; }
        #endregion
        
        #region Parameter PerformedBy_UserArn
        /// <summary>
        /// <para>
        /// <para>Represents the Amazon Connect ARN of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformedBy_UserArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCases.Model.CreateRelatedItemResponse).
        /// Specifying the name of a property of type Amazon.ConnectCases.Model.CreateRelatedItemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCASRelatedItem (CreateRelatedItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.CreateRelatedItemResponse, NewCCASRelatedItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CaseId = this.CaseId;
            #if MODULAR
            if (this.CaseId == null && ParameterWasBound(nameof(this.CaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter CaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Comment_Body = this.Comment_Body;
            context.Comment_ContentType = this.Comment_ContentType;
            context.ConnectCase_CaseId = this.ConnectCase_CaseId;
            context.Contact_ContactArn = this.Contact_ContactArn;
            if (this.Custom_Field != null)
            {
                context.Custom_Field = new List<Amazon.ConnectCases.Model.FieldValue>(this.Custom_Field);
            }
            context.File_FileArn = this.File_FileArn;
            context.SlaInputConfiguration_FieldId = this.SlaInputConfiguration_FieldId;
            context.SlaInputConfiguration_Name = this.SlaInputConfiguration_Name;
            if (this.SlaInputConfiguration_TargetFieldValue != null)
            {
                context.SlaInputConfiguration_TargetFieldValue = new List<Amazon.ConnectCases.Model.FieldValueUnion>(this.SlaInputConfiguration_TargetFieldValue);
            }
            context.SlaInputConfiguration_TargetSlaMinute = this.SlaInputConfiguration_TargetSlaMinute;
            context.SlaInputConfiguration_Type = this.SlaInputConfiguration_Type;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PerformedBy_CustomEntity = this.PerformedBy_CustomEntity;
            context.PerformedBy_UserArn = this.PerformedBy_UserArn;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectCases.Model.CreateRelatedItemRequest();
            
            if (cmdletContext.CaseId != null)
            {
                request.CaseId = cmdletContext.CaseId;
            }
            
             // populate Content
            var requestContentIsNull = true;
            request.Content = new Amazon.ConnectCases.Model.RelatedItemInputContent();
            Amazon.ConnectCases.Model.ConnectCaseInputContent requestContent_content_ConnectCase = null;
            
             // populate ConnectCase
            var requestContent_content_ConnectCaseIsNull = true;
            requestContent_content_ConnectCase = new Amazon.ConnectCases.Model.ConnectCaseInputContent();
            System.String requestContent_content_ConnectCase_connectCase_CaseId = null;
            if (cmdletContext.ConnectCase_CaseId != null)
            {
                requestContent_content_ConnectCase_connectCase_CaseId = cmdletContext.ConnectCase_CaseId;
            }
            if (requestContent_content_ConnectCase_connectCase_CaseId != null)
            {
                requestContent_content_ConnectCase.CaseId = requestContent_content_ConnectCase_connectCase_CaseId;
                requestContent_content_ConnectCaseIsNull = false;
            }
             // determine if requestContent_content_ConnectCase should be set to null
            if (requestContent_content_ConnectCaseIsNull)
            {
                requestContent_content_ConnectCase = null;
            }
            if (requestContent_content_ConnectCase != null)
            {
                request.Content.ConnectCase = requestContent_content_ConnectCase;
                requestContentIsNull = false;
            }
            Amazon.ConnectCases.Model.Contact requestContent_content_Contact = null;
            
             // populate Contact
            var requestContent_content_ContactIsNull = true;
            requestContent_content_Contact = new Amazon.ConnectCases.Model.Contact();
            System.String requestContent_content_Contact_contact_ContactArn = null;
            if (cmdletContext.Contact_ContactArn != null)
            {
                requestContent_content_Contact_contact_ContactArn = cmdletContext.Contact_ContactArn;
            }
            if (requestContent_content_Contact_contact_ContactArn != null)
            {
                requestContent_content_Contact.ContactArn = requestContent_content_Contact_contact_ContactArn;
                requestContent_content_ContactIsNull = false;
            }
             // determine if requestContent_content_Contact should be set to null
            if (requestContent_content_ContactIsNull)
            {
                requestContent_content_Contact = null;
            }
            if (requestContent_content_Contact != null)
            {
                request.Content.Contact = requestContent_content_Contact;
                requestContentIsNull = false;
            }
            Amazon.ConnectCases.Model.CustomInputContent requestContent_content_Custom = null;
            
             // populate Custom
            var requestContent_content_CustomIsNull = true;
            requestContent_content_Custom = new Amazon.ConnectCases.Model.CustomInputContent();
            List<Amazon.ConnectCases.Model.FieldValue> requestContent_content_Custom_custom_Field = null;
            if (cmdletContext.Custom_Field != null)
            {
                requestContent_content_Custom_custom_Field = cmdletContext.Custom_Field;
            }
            if (requestContent_content_Custom_custom_Field != null)
            {
                requestContent_content_Custom.Fields = requestContent_content_Custom_custom_Field;
                requestContent_content_CustomIsNull = false;
            }
             // determine if requestContent_content_Custom should be set to null
            if (requestContent_content_CustomIsNull)
            {
                requestContent_content_Custom = null;
            }
            if (requestContent_content_Custom != null)
            {
                request.Content.Custom = requestContent_content_Custom;
                requestContentIsNull = false;
            }
            Amazon.ConnectCases.Model.FileContent requestContent_content_File = null;
            
             // populate File
            var requestContent_content_FileIsNull = true;
            requestContent_content_File = new Amazon.ConnectCases.Model.FileContent();
            System.String requestContent_content_File_file_FileArn = null;
            if (cmdletContext.File_FileArn != null)
            {
                requestContent_content_File_file_FileArn = cmdletContext.File_FileArn;
            }
            if (requestContent_content_File_file_FileArn != null)
            {
                requestContent_content_File.FileArn = requestContent_content_File_file_FileArn;
                requestContent_content_FileIsNull = false;
            }
             // determine if requestContent_content_File should be set to null
            if (requestContent_content_FileIsNull)
            {
                requestContent_content_File = null;
            }
            if (requestContent_content_File != null)
            {
                request.Content.File = requestContent_content_File;
                requestContentIsNull = false;
            }
            Amazon.ConnectCases.Model.SlaInputContent requestContent_content_Sla = null;
            
             // populate Sla
            var requestContent_content_SlaIsNull = true;
            requestContent_content_Sla = new Amazon.ConnectCases.Model.SlaInputContent();
            Amazon.ConnectCases.Model.SlaInputConfiguration requestContent_content_Sla_content_Sla_SlaInputConfiguration = null;
            
             // populate SlaInputConfiguration
            var requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull = true;
            requestContent_content_Sla_content_Sla_SlaInputConfiguration = new Amazon.ConnectCases.Model.SlaInputConfiguration();
            System.String requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_FieldId = null;
            if (cmdletContext.SlaInputConfiguration_FieldId != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_FieldId = cmdletContext.SlaInputConfiguration_FieldId;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_FieldId != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration.FieldId = requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_FieldId;
                requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull = false;
            }
            System.String requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_Name = null;
            if (cmdletContext.SlaInputConfiguration_Name != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_Name = cmdletContext.SlaInputConfiguration_Name;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_Name != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration.Name = requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_Name;
                requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull = false;
            }
            List<Amazon.ConnectCases.Model.FieldValueUnion> requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_TargetFieldValue = null;
            if (cmdletContext.SlaInputConfiguration_TargetFieldValue != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_TargetFieldValue = cmdletContext.SlaInputConfiguration_TargetFieldValue;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_TargetFieldValue != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration.TargetFieldValues = requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_TargetFieldValue;
                requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull = false;
            }
            System.Int64? requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_TargetSlaMinute = null;
            if (cmdletContext.SlaInputConfiguration_TargetSlaMinute != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_TargetSlaMinute = cmdletContext.SlaInputConfiguration_TargetSlaMinute.Value;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_TargetSlaMinute != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration.TargetSlaMinutes = requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_TargetSlaMinute.Value;
                requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull = false;
            }
            Amazon.ConnectCases.SlaType requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_Type = null;
            if (cmdletContext.SlaInputConfiguration_Type != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_Type = cmdletContext.SlaInputConfiguration_Type;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_Type != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration.Type = requestContent_content_Sla_content_Sla_SlaInputConfiguration_slaInputConfiguration_Type;
                requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull = false;
            }
             // determine if requestContent_content_Sla_content_Sla_SlaInputConfiguration should be set to null
            if (requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration = null;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration != null)
            {
                requestContent_content_Sla.SlaInputConfiguration = requestContent_content_Sla_content_Sla_SlaInputConfiguration;
                requestContent_content_SlaIsNull = false;
            }
             // determine if requestContent_content_Sla should be set to null
            if (requestContent_content_SlaIsNull)
            {
                requestContent_content_Sla = null;
            }
            if (requestContent_content_Sla != null)
            {
                request.Content.Sla = requestContent_content_Sla;
                requestContentIsNull = false;
            }
            Amazon.ConnectCases.Model.CommentContent requestContent_content_Comment = null;
            
             // populate Comment
            var requestContent_content_CommentIsNull = true;
            requestContent_content_Comment = new Amazon.ConnectCases.Model.CommentContent();
            System.String requestContent_content_Comment_comment_Body = null;
            if (cmdletContext.Comment_Body != null)
            {
                requestContent_content_Comment_comment_Body = cmdletContext.Comment_Body;
            }
            if (requestContent_content_Comment_comment_Body != null)
            {
                requestContent_content_Comment.Body = requestContent_content_Comment_comment_Body;
                requestContent_content_CommentIsNull = false;
            }
            Amazon.ConnectCases.CommentBodyTextType requestContent_content_Comment_comment_ContentType = null;
            if (cmdletContext.Comment_ContentType != null)
            {
                requestContent_content_Comment_comment_ContentType = cmdletContext.Comment_ContentType;
            }
            if (requestContent_content_Comment_comment_ContentType != null)
            {
                requestContent_content_Comment.ContentType = requestContent_content_Comment_comment_ContentType;
                requestContent_content_CommentIsNull = false;
            }
             // determine if requestContent_content_Comment should be set to null
            if (requestContent_content_CommentIsNull)
            {
                requestContent_content_Comment = null;
            }
            if (requestContent_content_Comment != null)
            {
                request.Content.Comment = requestContent_content_Comment;
                requestContentIsNull = false;
            }
             // determine if request.Content should be set to null
            if (requestContentIsNull)
            {
                request.Content = null;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            
             // populate PerformedBy
            var requestPerformedByIsNull = true;
            request.PerformedBy = new Amazon.ConnectCases.Model.UserUnion();
            System.String requestPerformedBy_performedBy_CustomEntity = null;
            if (cmdletContext.PerformedBy_CustomEntity != null)
            {
                requestPerformedBy_performedBy_CustomEntity = cmdletContext.PerformedBy_CustomEntity;
            }
            if (requestPerformedBy_performedBy_CustomEntity != null)
            {
                request.PerformedBy.CustomEntity = requestPerformedBy_performedBy_CustomEntity;
                requestPerformedByIsNull = false;
            }
            System.String requestPerformedBy_performedBy_UserArn = null;
            if (cmdletContext.PerformedBy_UserArn != null)
            {
                requestPerformedBy_performedBy_UserArn = cmdletContext.PerformedBy_UserArn;
            }
            if (requestPerformedBy_performedBy_UserArn != null)
            {
                request.PerformedBy.UserArn = requestPerformedBy_performedBy_UserArn;
                requestPerformedByIsNull = false;
            }
             // determine if request.PerformedBy should be set to null
            if (requestPerformedByIsNull)
            {
                request.PerformedBy = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.ConnectCases.Model.CreateRelatedItemResponse CallAWSServiceOperation(IAmazonConnectCases client, Amazon.ConnectCases.Model.CreateRelatedItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Cases", "CreateRelatedItem");
            try
            {
                #if DESKTOP
                return client.CreateRelatedItem(request);
                #elif CORECLR
                return client.CreateRelatedItemAsync(request).GetAwaiter().GetResult();
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
            public System.String CaseId { get; set; }
            public System.String Comment_Body { get; set; }
            public Amazon.ConnectCases.CommentBodyTextType Comment_ContentType { get; set; }
            public System.String ConnectCase_CaseId { get; set; }
            public System.String Contact_ContactArn { get; set; }
            public List<Amazon.ConnectCases.Model.FieldValue> Custom_Field { get; set; }
            public System.String File_FileArn { get; set; }
            public System.String SlaInputConfiguration_FieldId { get; set; }
            public System.String SlaInputConfiguration_Name { get; set; }
            public List<Amazon.ConnectCases.Model.FieldValueUnion> SlaInputConfiguration_TargetFieldValue { get; set; }
            public System.Int64? SlaInputConfiguration_TargetSlaMinute { get; set; }
            public Amazon.ConnectCases.SlaType SlaInputConfiguration_Type { get; set; }
            public System.String DomainId { get; set; }
            public System.String PerformedBy_CustomEntity { get; set; }
            public System.String PerformedBy_UserArn { get; set; }
            public Amazon.ConnectCases.RelatedItemType Type { get; set; }
            public System.Func<Amazon.ConnectCases.Model.CreateRelatedItemResponse, NewCCASRelatedItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
