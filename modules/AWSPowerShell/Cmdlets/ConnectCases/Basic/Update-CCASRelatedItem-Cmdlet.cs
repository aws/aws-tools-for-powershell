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
    /// Updates the content of a related item associated with a case. The following related
    /// item types are supported:
    /// 
    ///  <ul><li><para><b>Comment</b> - Update the text content of an existing comment
    /// </para></li><li><para><b>Custom</b> - Update the fields of a custom related item. You can add, modify,
    /// and remove fields from a custom related item. There's a quota for the number of fields
    /// allowed in a Custom type related item. See <a href="https://docs.aws.amazon.com/connect/latest/adminguide/amazon-connect-service-limits.html#cases-quotas">Amazon
    /// Connect Cases quotas</a>.
    /// </para></li></ul><para><b>Important things to know</b></para><ul><li><para>
    /// When updating a Custom related item, all existing and new fields, and their associated
    /// values should be included in the request. Fields not included as part of this request
    /// will be removed.
    /// </para></li><li><para>
    /// If you provide a value for <c>performedBy.userArn</c> you must also have <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DescribeUser.html">DescribeUser</a>
    /// permission on the ARN of the user that you provide.
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/connect/latest/adminguide/case-fields.html#system-case-fields">System
    /// case fields</a> cannot be used in a custom related item.
    /// </para></li></ul><para><b>Endpoints</b>: See <a href="https://docs.aws.amazon.com/general/latest/gr/connect_region.html">Amazon
    /// Connect endpoints and quotas</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CCASRelatedItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCases.Model.UpdateRelatedItemResponse")]
    [AWSCmdlet("Calls the Amazon Connect Cases UpdateRelatedItem API operation.", Operation = new[] {"UpdateRelatedItem"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.UpdateRelatedItemResponse))]
    [AWSCmdletOutput("Amazon.ConnectCases.Model.UpdateRelatedItemResponse",
        "This cmdlet returns an Amazon.ConnectCases.Model.UpdateRelatedItemResponse object containing multiple properties."
    )]
    public partial class UpdateCCASRelatedItemCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Content_Comment_Body
        /// <summary>
        /// <para>
        /// <para>Updated text in the body of a <c>Comment</c> on a case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Comment_Body { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter Content_Custom_Field
        /// <summary>
        /// <para>
        /// <para>List of updated field values for the <c>Custom</c> related item. All existing and
        /// new fields, and their associated values should be included. Fields not included as
        /// part of this request will be removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Custom_Fields")]
        public Amazon.ConnectCases.Model.FieldValue[] Content_Custom_Field { get; set; }
        #endregion
        
        #region Parameter RelatedItemId
        /// <summary>
        /// <para>
        /// <para>Unique identifier of a related item.</para>
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
        public System.String RelatedItemId { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCases.Model.UpdateRelatedItemResponse).
        /// Specifying the name of a property of type Amazon.ConnectCases.Model.UpdateRelatedItemResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RelatedItemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CCASRelatedItem (UpdateRelatedItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.UpdateRelatedItemResponse, UpdateCCASRelatedItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CaseId = this.CaseId;
            #if MODULAR
            if (this.CaseId == null && ParameterWasBound(nameof(this.CaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter CaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Content_Comment_Body = this.Content_Comment_Body;
            context.Content_Comment_ContentType = this.Content_Comment_ContentType;
            if (this.Content_Custom_Field != null)
            {
                context.Content_Custom_Field = new List<Amazon.ConnectCases.Model.FieldValue>(this.Content_Custom_Field);
            }
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PerformedBy_CustomEntity = this.PerformedBy_CustomEntity;
            context.PerformedBy_UserArn = this.PerformedBy_UserArn;
            context.RelatedItemId = this.RelatedItemId;
            #if MODULAR
            if (this.RelatedItemId == null && ParameterWasBound(nameof(this.RelatedItemId)))
            {
                WriteWarning("You are passing $null as a value for parameter RelatedItemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectCases.Model.UpdateRelatedItemRequest();
            
            if (cmdletContext.CaseId != null)
            {
                request.CaseId = cmdletContext.CaseId;
            }
            
             // populate Content
            var requestContentIsNull = true;
            request.Content = new Amazon.ConnectCases.Model.RelatedItemUpdateContent();
            Amazon.ConnectCases.Model.CustomUpdateContent requestContent_content_Custom = null;
            
             // populate Custom
            var requestContent_content_CustomIsNull = true;
            requestContent_content_Custom = new Amazon.ConnectCases.Model.CustomUpdateContent();
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
            Amazon.ConnectCases.Model.CommentUpdateContent requestContent_content_Comment = null;
            
             // populate Comment
            var requestContent_content_CommentIsNull = true;
            requestContent_content_Comment = new Amazon.ConnectCases.Model.CommentUpdateContent();
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
            if (cmdletContext.RelatedItemId != null)
            {
                request.RelatedItemId = cmdletContext.RelatedItemId;
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
        
        private Amazon.ConnectCases.Model.UpdateRelatedItemResponse CallAWSServiceOperation(IAmazonConnectCases client, Amazon.ConnectCases.Model.UpdateRelatedItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Cases", "UpdateRelatedItem");
            try
            {
                #if DESKTOP
                return client.UpdateRelatedItem(request);
                #elif CORECLR
                return client.UpdateRelatedItemAsync(request).GetAwaiter().GetResult();
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
            public System.String Content_Comment_Body { get; set; }
            public Amazon.ConnectCases.CommentBodyTextType Content_Comment_ContentType { get; set; }
            public List<Amazon.ConnectCases.Model.FieldValue> Content_Custom_Field { get; set; }
            public System.String DomainId { get; set; }
            public System.String PerformedBy_CustomEntity { get; set; }
            public System.String PerformedBy_UserArn { get; set; }
            public System.String RelatedItemId { get; set; }
            public System.Func<Amazon.ConnectCases.Model.UpdateRelatedItemResponse, UpdateCCASRelatedItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
