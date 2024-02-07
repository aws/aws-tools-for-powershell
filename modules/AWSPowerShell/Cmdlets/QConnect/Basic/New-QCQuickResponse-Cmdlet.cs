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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Creates an Amazon Q quick response.
    /// </summary>
    [Cmdlet("New", "QCQuickResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.QuickResponseData")]
    [AWSCmdlet("Calls the Amazon Q Connect CreateQuickResponse API operation.", Operation = new[] {"CreateQuickResponse"}, SelectReturnType = typeof(Amazon.QConnect.Model.CreateQuickResponseResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.QuickResponseData or Amazon.QConnect.Model.CreateQuickResponseResponse",
        "This cmdlet returns an Amazon.QConnect.Model.QuickResponseData object.",
        "The service call response (type Amazon.QConnect.Model.CreateQuickResponseResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewQCQuickResponseCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Channel
        /// <summary>
        /// <para>
        /// <para>The Amazon Connect channels this quick response applies to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Channels")]
        public System.String[] Channel { get; set; }
        #endregion
        
        #region Parameter Content_Content
        /// <summary>
        /// <para>
        /// <para>The content of the quick response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Content { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The media type of the quick response content.</para><ul><li><para>Use <c>application/x.quickresponse;format=plain</c> for a quick response written in
        /// plain text.</para></li><li><para>Use <c>application/x.quickresponse;format=markdown</c> for a quick response written
        /// in richtext.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter GroupingConfiguration_Criterion
        /// <summary>
        /// <para>
        /// <para>The criteria used for grouping Amazon Q users.</para><para>The following is the list of supported criteria values.</para><ul><li><para><c>RoutingProfileArn</c>: Grouping the users by their <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_RoutingProfile.html">Amazon
        /// Connect routing profile ARN</a>. User should have <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_SearchRoutingProfiles.html">SearchRoutingProfile</a>
        /// and <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_DescribeRoutingProfile.html">DescribeRoutingProfile</a>
        /// permissions when setting criteria to this value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupingConfiguration_Criteria")]
        public System.String GroupingConfiguration_Criterion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the quick response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IsActive
        /// <summary>
        /// <para>
        /// <para>Whether the quick response is active.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsActive { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base. This should not be a QUICK_RESPONSES type knowledge
        /// base if you're storing Amazon Q Content resource to it. Can be either the ID or the
        /// ARN. URLs cannot contain the ARN.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The language code value for the language in which the quick response is written. The
        /// supported language codes include <c>de_DE</c>, <c>en_US</c>, <c>es_ES</c>, <c>fr_FR</c>,
        /// <c>id_ID</c>, <c>it_IT</c>, <c>ja_JP</c>, <c>ko_KR</c>, <c>pt_BR</c>, <c>zh_CN</c>,
        /// <c>zh_TW</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Language { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the quick response.</para>
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
        
        #region Parameter ShortcutKey
        /// <summary>
        /// <para>
        /// <para>The shortcut key of the quick response. The value should be unique across the knowledge
        /// base. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShortcutKey { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter GroupingConfiguration_Value
        /// <summary>
        /// <para>
        /// <para>The list of values that define different groups of Amazon Q users.</para><ul><li><para>When setting <c>criteria</c> to <c>RoutingProfileArn</c>, you need to provide a list
        /// of ARNs of <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_RoutingProfile.html">Amazon
        /// Connect routing profiles</a> as values of this parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupingConfiguration_Values")]
        public System.String[] GroupingConfiguration_Value { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QuickResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.CreateQuickResponseResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.CreateQuickResponseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QuickResponse";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KnowledgeBaseId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KnowledgeBaseId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QCQuickResponse (CreateQuickResponse)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.CreateQuickResponseResponse, NewQCQuickResponseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KnowledgeBaseId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Channel != null)
            {
                context.Channel = new List<System.String>(this.Channel);
            }
            context.ClientToken = this.ClientToken;
            context.Content_Content = this.Content_Content;
            context.ContentType = this.ContentType;
            context.Description = this.Description;
            context.GroupingConfiguration_Criterion = this.GroupingConfiguration_Criterion;
            if (this.GroupingConfiguration_Value != null)
            {
                context.GroupingConfiguration_Value = new List<System.String>(this.GroupingConfiguration_Value);
            }
            context.IsActive = this.IsActive;
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Language = this.Language;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShortcutKey = this.ShortcutKey;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.QConnect.Model.CreateQuickResponseRequest();
            
            if (cmdletContext.Channel != null)
            {
                request.Channels = cmdletContext.Channel;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Content
            var requestContentIsNull = true;
            request.Content = new Amazon.QConnect.Model.QuickResponseDataProvider();
            System.String requestContent_content_Content = null;
            if (cmdletContext.Content_Content != null)
            {
                requestContent_content_Content = cmdletContext.Content_Content;
            }
            if (requestContent_content_Content != null)
            {
                request.Content.Content = requestContent_content_Content;
                requestContentIsNull = false;
            }
             // determine if request.Content should be set to null
            if (requestContentIsNull)
            {
                request.Content = null;
            }
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate GroupingConfiguration
            var requestGroupingConfigurationIsNull = true;
            request.GroupingConfiguration = new Amazon.QConnect.Model.GroupingConfiguration();
            System.String requestGroupingConfiguration_groupingConfiguration_Criterion = null;
            if (cmdletContext.GroupingConfiguration_Criterion != null)
            {
                requestGroupingConfiguration_groupingConfiguration_Criterion = cmdletContext.GroupingConfiguration_Criterion;
            }
            if (requestGroupingConfiguration_groupingConfiguration_Criterion != null)
            {
                request.GroupingConfiguration.Criteria = requestGroupingConfiguration_groupingConfiguration_Criterion;
                requestGroupingConfigurationIsNull = false;
            }
            List<System.String> requestGroupingConfiguration_groupingConfiguration_Value = null;
            if (cmdletContext.GroupingConfiguration_Value != null)
            {
                requestGroupingConfiguration_groupingConfiguration_Value = cmdletContext.GroupingConfiguration_Value;
            }
            if (requestGroupingConfiguration_groupingConfiguration_Value != null)
            {
                request.GroupingConfiguration.Values = requestGroupingConfiguration_groupingConfiguration_Value;
                requestGroupingConfigurationIsNull = false;
            }
             // determine if request.GroupingConfiguration should be set to null
            if (requestGroupingConfigurationIsNull)
            {
                request.GroupingConfiguration = null;
            }
            if (cmdletContext.IsActive != null)
            {
                request.IsActive = cmdletContext.IsActive.Value;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ShortcutKey != null)
            {
                request.ShortcutKey = cmdletContext.ShortcutKey;
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
        
        private Amazon.QConnect.Model.CreateQuickResponseResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.CreateQuickResponseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "CreateQuickResponse");
            try
            {
                #if DESKTOP
                return client.CreateQuickResponse(request);
                #elif CORECLR
                return client.CreateQuickResponseAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Channel { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Content_Content { get; set; }
            public System.String ContentType { get; set; }
            public System.String Description { get; set; }
            public System.String GroupingConfiguration_Criterion { get; set; }
            public List<System.String> GroupingConfiguration_Value { get; set; }
            public System.Boolean? IsActive { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public System.String Language { get; set; }
            public System.String Name { get; set; }
            public System.String ShortcutKey { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.QConnect.Model.CreateQuickResponseResponse, NewQCQuickResponseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QuickResponse;
        }
        
    }
}
