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
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCAS
{
    /// <summary>
    /// Creates a comment and associates it with multiple cases in a single request. All cases
    /// must belong to the same domain. This operation supports only the Comment related item
    /// type.
    /// 
    ///  
    /// <para>
    /// Each case is processed independently. If some cases fail, the remaining cases still
    /// receive the related item. To determine whether individual items failed, inspect the
    /// <c>failedItems</c> array in the response.
    /// </para><para>
    /// The entire request fails, and no related items are created, in the following cases:
    /// </para><ul><li><para>
    /// The specified domain doesn't exist.
    /// </para></li><li><para>
    /// A reference ID doesn't match any case in the domain.
    /// </para></li><li><para>
    /// The request contains duplicate case IDs.
    /// </para></li><li><para>
    /// The content isn't comment content.
    /// </para></li></ul><note><para>
    /// This operation uses the same IAM action as <a href="https://docs.aws.amazon.com/cases/latest/APIReference/API_CreateRelatedItem.html">CreateRelatedItem</a>
    /// (<c>cases:CreateRelatedItem</c>). You can use the <c>cases:IsBatchAction</c> condition
    /// key in IAM policies to allow or deny batch operations independently from single-case
    /// operations.
    /// </para></note><note><para>
    /// If you provide a value for <c>performedBy.userArn</c>, you must also have <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DescribeUser.html">DescribeUser</a>
    /// permission on the ARN of the user that you provide.
    /// </para></note><para><b>Endpoints</b>: See <a href="https://docs.aws.amazon.com/general/latest/gr/connect_region.html">Connect
    /// Customer endpoints and quotas</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CCASRelatedItemBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCases.Model.BatchCreateRelatedItemResponse")]
    [AWSCmdlet("Calls the Amazon Connect Cases BatchCreateRelatedItem API operation.", Operation = new[] {"BatchCreateRelatedItem"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.BatchCreateRelatedItemResponse))]
    [AWSCmdletOutput("Amazon.ConnectCases.Model.BatchCreateRelatedItemResponse",
        "This cmdlet returns an Amazon.ConnectCases.Model.BatchCreateRelatedItemResponse object containing multiple properties."
    )]
    public partial class NewCCASRelatedItemBatchCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Content_Comment_Body
        /// <summary>
        /// <para>
        /// <para>Text in the body of a <c>Comment</c> on a case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Comment_Body { get; set; }
        #endregion
        
        #region Parameter Content_ConnectCase_CaseId
        /// <summary>
        /// <para>
        /// <para>A unique identifier of the case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_ConnectCase_CaseId { get; set; }
        #endregion
        
        #region Parameter Case
        /// <summary>
        /// <para>
        /// <para>The list of cases to associate the related item with. All cases must belong to the
        /// same domain.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Cases")]
        public Amazon.ConnectCases.Model.BatchCreateRelatedItemIdentifier[] Case { get; set; }
        #endregion
        
        #region Parameter Content_Contact_ContactArn
        /// <summary>
        /// <para>
        /// <para>A unique identifier of a contact in Connect Customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Contact_ContactArn { get; set; }
        #endregion
        
        #region Parameter Content_Comment_ContentType
        /// <summary>
        /// <para>
        /// <para>Type of the text in the box of a <c>Comment</c> on a case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectCases.CommentBodyTextType")]
        public Amazon.ConnectCases.CommentBodyTextType Content_Comment_ContentType { get; set; }
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
        
        #region Parameter Content_Sla_SlaInputConfiguration_FieldId
        /// <summary>
        /// <para>
        /// <para>Unique identifier of a field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Sla_SlaInputConfiguration_FieldId { get; set; }
        #endregion
        
        #region Parameter Content_Custom_Field
        /// <summary>
        /// <para>
        /// <para>List of field values for the <c>Custom</c> related item.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Custom_Fields")]
        public Amazon.ConnectCases.Model.FieldValue[] Content_Custom_Field { get; set; }
        #endregion
        
        #region Parameter Content_File_FileArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a File in Connect Customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_File_FileArn { get; set; }
        #endregion
        
        #region Parameter Content_Sla_SlaInputConfiguration_Name
        /// <summary>
        /// <para>
        /// <para>Name of an SLA.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Sla_SlaInputConfiguration_Name { get; set; }
        #endregion
        
        #region Parameter Content_Sla_SlaInputConfiguration_TargetFieldValue
        /// <summary>
        /// <para>
        /// <para>Represents a list of target field values for the fieldId specified in SlaInputConfiguration.
        /// The SLA is considered met if any one of these target field values matches the actual
        /// field value.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Sla_SlaInputConfiguration_TargetFieldValues")]
        public Amazon.ConnectCases.Model.FieldValueUnion[] Content_Sla_SlaInputConfiguration_TargetFieldValue { get; set; }
        #endregion
        
        #region Parameter Content_Sla_SlaInputConfiguration_TargetSlaMinute
        /// <summary>
        /// <para>
        /// <para>Target duration in minutes within which an SLA should be completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Sla_SlaInputConfiguration_TargetSlaMinutes")]
        public System.Int64? Content_Sla_SlaInputConfiguration_TargetSlaMinute { get; set; }
        #endregion
        
        #region Parameter Content_Sla_SlaInputConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>Type of SLA.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectCases.SlaType")]
        public Amazon.ConnectCases.SlaType Content_Sla_SlaInputConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter PerformedBy_UserArn
        /// <summary>
        /// <para>
        /// <para>Represents the Connect Customer ARN of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformedBy_UserArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para><para>If you retry a request with the same client token, the service returns the original
        /// response instead of processing the request again. If you reuse a client token with
        /// different request parameters, the request fails with a <c>ConflictException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCases.Model.BatchCreateRelatedItemResponse).
        /// Specifying the name of a property of type Amazon.ConnectCases.Model.BatchCreateRelatedItemResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCASRelatedItemBatch (BatchCreateRelatedItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.BatchCreateRelatedItemResponse, NewCCASRelatedItemBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Case != null)
            {
                context.Case = new List<Amazon.ConnectCases.Model.BatchCreateRelatedItemIdentifier>(this.Case);
            }
            #if MODULAR
            if (this.Case == null && ParameterWasBound(nameof(this.Case)))
            {
                WriteWarning("You are passing $null as a value for parameter Case which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Content_Comment_Body = this.Content_Comment_Body;
            context.Content_Comment_ContentType = this.Content_Comment_ContentType;
            context.Content_ConnectCase_CaseId = this.Content_ConnectCase_CaseId;
            context.Content_Contact_ContactArn = this.Content_Contact_ContactArn;
            if (this.Content_Custom_Field != null)
            {
                context.Content_Custom_Field = new List<Amazon.ConnectCases.Model.FieldValue>(this.Content_Custom_Field);
            }
            context.Content_File_FileArn = this.Content_File_FileArn;
            context.Content_Sla_SlaInputConfiguration_FieldId = this.Content_Sla_SlaInputConfiguration_FieldId;
            context.Content_Sla_SlaInputConfiguration_Name = this.Content_Sla_SlaInputConfiguration_Name;
            if (this.Content_Sla_SlaInputConfiguration_TargetFieldValue != null)
            {
                context.Content_Sla_SlaInputConfiguration_TargetFieldValue = new List<Amazon.ConnectCases.Model.FieldValueUnion>(this.Content_Sla_SlaInputConfiguration_TargetFieldValue);
            }
            context.Content_Sla_SlaInputConfiguration_TargetSlaMinute = this.Content_Sla_SlaInputConfiguration_TargetSlaMinute;
            context.Content_Sla_SlaInputConfiguration_Type = this.Content_Sla_SlaInputConfiguration_Type;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PerformedBy_CustomEntity = this.PerformedBy_CustomEntity;
            context.PerformedBy_UserArn = this.PerformedBy_UserArn;
            
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
            var request = new Amazon.ConnectCases.Model.BatchCreateRelatedItemRequest();
            
            if (cmdletContext.Case != null)
            {
                request.Cases = cmdletContext.Case;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Content
            var requestContentIsNull = true;
            request.Content = new Amazon.ConnectCases.Model.RelatedItemInputContent();
            Amazon.ConnectCases.Model.ConnectCaseInputContent requestContent_content_ConnectCase = null;
            
             // populate ConnectCase
            var requestContent_content_ConnectCaseIsNull = true;
            requestContent_content_ConnectCase = new Amazon.ConnectCases.Model.ConnectCaseInputContent();
            System.String requestContent_content_ConnectCase_content_ConnectCase_CaseId = null;
            if (cmdletContext.Content_ConnectCase_CaseId != null)
            {
                requestContent_content_ConnectCase_content_ConnectCase_CaseId = cmdletContext.Content_ConnectCase_CaseId;
            }
            if (requestContent_content_ConnectCase_content_ConnectCase_CaseId != null)
            {
                requestContent_content_ConnectCase.CaseId = requestContent_content_ConnectCase_content_ConnectCase_CaseId;
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
            System.String requestContent_content_Contact_content_Contact_ContactArn = null;
            if (cmdletContext.Content_Contact_ContactArn != null)
            {
                requestContent_content_Contact_content_Contact_ContactArn = cmdletContext.Content_Contact_ContactArn;
            }
            if (requestContent_content_Contact_content_Contact_ContactArn != null)
            {
                requestContent_content_Contact.ContactArn = requestContent_content_Contact_content_Contact_ContactArn;
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
            List<Amazon.ConnectCases.Model.FieldValue> requestContent_content_Custom_content_Custom_Field = null;
            if (cmdletContext.Content_Custom_Field != null)
            {
                requestContent_content_Custom_content_Custom_Field = cmdletContext.Content_Custom_Field;
            }
            if (requestContent_content_Custom_content_Custom_Field != null)
            {
                requestContent_content_Custom.Fields = requestContent_content_Custom_content_Custom_Field;
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
            System.String requestContent_content_File_content_File_FileArn = null;
            if (cmdletContext.Content_File_FileArn != null)
            {
                requestContent_content_File_content_File_FileArn = cmdletContext.Content_File_FileArn;
            }
            if (requestContent_content_File_content_File_FileArn != null)
            {
                requestContent_content_File.FileArn = requestContent_content_File_content_File_FileArn;
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
            System.String requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_FieldId = null;
            if (cmdletContext.Content_Sla_SlaInputConfiguration_FieldId != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_FieldId = cmdletContext.Content_Sla_SlaInputConfiguration_FieldId;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_FieldId != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration.FieldId = requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_FieldId;
                requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull = false;
            }
            System.String requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_Name = null;
            if (cmdletContext.Content_Sla_SlaInputConfiguration_Name != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_Name = cmdletContext.Content_Sla_SlaInputConfiguration_Name;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_Name != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration.Name = requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_Name;
                requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull = false;
            }
            List<Amazon.ConnectCases.Model.FieldValueUnion> requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_TargetFieldValue = null;
            if (cmdletContext.Content_Sla_SlaInputConfiguration_TargetFieldValue != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_TargetFieldValue = cmdletContext.Content_Sla_SlaInputConfiguration_TargetFieldValue;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_TargetFieldValue != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration.TargetFieldValues = requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_TargetFieldValue;
                requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull = false;
            }
            System.Int64? requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_TargetSlaMinute = null;
            if (cmdletContext.Content_Sla_SlaInputConfiguration_TargetSlaMinute != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_TargetSlaMinute = cmdletContext.Content_Sla_SlaInputConfiguration_TargetSlaMinute.Value;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_TargetSlaMinute != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration.TargetSlaMinutes = requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_TargetSlaMinute.Value;
                requestContent_content_Sla_content_Sla_SlaInputConfigurationIsNull = false;
            }
            Amazon.ConnectCases.SlaType requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_Type = null;
            if (cmdletContext.Content_Sla_SlaInputConfiguration_Type != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_Type = cmdletContext.Content_Sla_SlaInputConfiguration_Type;
            }
            if (requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_Type != null)
            {
                requestContent_content_Sla_content_Sla_SlaInputConfiguration.Type = requestContent_content_Sla_content_Sla_SlaInputConfiguration_content_Sla_SlaInputConfiguration_Type;
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
            System.String requestContent_content_Comment_content_Comment_Body = null;
            if (cmdletContext.Content_Comment_Body != null)
            {
                requestContent_content_Comment_content_Comment_Body = cmdletContext.Content_Comment_Body;
            }
            if (requestContent_content_Comment_content_Comment_Body != null)
            {
                requestContent_content_Comment.Body = requestContent_content_Comment_content_Comment_Body;
                requestContent_content_CommentIsNull = false;
            }
            Amazon.ConnectCases.CommentBodyTextType requestContent_content_Comment_content_Comment_ContentType = null;
            if (cmdletContext.Content_Comment_ContentType != null)
            {
                requestContent_content_Comment_content_Comment_ContentType = cmdletContext.Content_Comment_ContentType;
            }
            if (requestContent_content_Comment_content_Comment_ContentType != null)
            {
                requestContent_content_Comment.ContentType = requestContent_content_Comment_content_Comment_ContentType;
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
        
        private Amazon.ConnectCases.Model.BatchCreateRelatedItemResponse CallAWSServiceOperation(IAmazonConnectCases client, Amazon.ConnectCases.Model.BatchCreateRelatedItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Cases", "BatchCreateRelatedItem");
            try
            {
                return client.BatchCreateRelatedItemAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ConnectCases.Model.BatchCreateRelatedItemIdentifier> Case { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Content_Comment_Body { get; set; }
            public Amazon.ConnectCases.CommentBodyTextType Content_Comment_ContentType { get; set; }
            public System.String Content_ConnectCase_CaseId { get; set; }
            public System.String Content_Contact_ContactArn { get; set; }
            public List<Amazon.ConnectCases.Model.FieldValue> Content_Custom_Field { get; set; }
            public System.String Content_File_FileArn { get; set; }
            public System.String Content_Sla_SlaInputConfiguration_FieldId { get; set; }
            public System.String Content_Sla_SlaInputConfiguration_Name { get; set; }
            public List<Amazon.ConnectCases.Model.FieldValueUnion> Content_Sla_SlaInputConfiguration_TargetFieldValue { get; set; }
            public System.Int64? Content_Sla_SlaInputConfiguration_TargetSlaMinute { get; set; }
            public Amazon.ConnectCases.SlaType Content_Sla_SlaInputConfiguration_Type { get; set; }
            public System.String DomainId { get; set; }
            public System.String PerformedBy_CustomEntity { get; set; }
            public System.String PerformedBy_UserArn { get; set; }
            public System.Func<Amazon.ConnectCases.Model.BatchCreateRelatedItemResponse, NewCCASRelatedItemBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
