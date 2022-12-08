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
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

namespace Amazon.PowerShell.Cmdlets.CCAS
{
    /// <summary>
    /// Creates a related item (comments, tasks, and contacts) and associates it with a case.
    /// 
    ///  <note><para>
    /// A Related Item is a resource that is associated with a case. It may or may not have
    /// an external identifier linking it to an external resource (for example, a <code>contactArn</code>).
    /// All Related Items have their own internal identifier, the <code>relatedItemArn</code>.
    /// Examples of related items include <code>comments</code> and <code>contacts</code>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CCASRelatedItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCases.Model.CreateRelatedItemResponse")]
    [AWSCmdlet("Calls the Amazon Connect Cases CreateRelatedItem API operation.", Operation = new[] {"CreateRelatedItem"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.CreateRelatedItemResponse))]
    [AWSCmdletOutput("Amazon.ConnectCases.Model.CreateRelatedItemResponse",
        "This cmdlet returns an Amazon.ConnectCases.Model.CreateRelatedItemResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCCASRelatedItemCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        #region Parameter Comment_Body
        /// <summary>
        /// <para>
        /// <para>Text in the body of a <code>Comment</code> on a case.</para>
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
        /// <para>Type of the text in the box of a <code>Comment</code> on a case.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Comment_ContentType")]
        [AWSConstantClassSource("Amazon.ConnectCases.CommentBodyTextType")]
        public Amazon.ConnectCases.CommentBodyTextType Comment_ContentType { get; set; }
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
            context.Contact_ContactArn = this.Contact_ContactArn;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            public System.String Contact_ContactArn { get; set; }
            public System.String DomainId { get; set; }
            public Amazon.ConnectCases.RelatedItemType Type { get; set; }
            public System.Func<Amazon.ConnectCases.Model.CreateRelatedItemResponse, NewCCASRelatedItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
