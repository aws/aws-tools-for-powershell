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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Creates a new OpsItem. You must have permission in Identity and Access Management
    /// (IAM) to create a new OpsItem. For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/OpsCenter-setup.html">Set
    /// up OpsCenter</a> in the <i>Amazon Web Services Systems Manager User Guide</i>.
    /// 
    ///  
    /// <para>
    /// Operations engineers and IT professionals use Amazon Web Services Systems Manager
    /// OpsCenter to view, investigate, and remediate operational issues impacting the performance
    /// and health of their Amazon Web Services resources. For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/OpsCenter.html">Amazon
    /// Web Services Systems Manager OpsCenter</a> in the <i>Amazon Web Services Systems Manager
    /// User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "SSMOpsItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager CreateOpsItem API operation.", Operation = new[] {"CreateOpsItem"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.CreateOpsItemResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleSystemsManagement.Model.CreateOpsItemResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.CreateOpsItemResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSMOpsItemCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The target Amazon Web Services account where you want to create an OpsItem. To make
        /// this call, your account must be configured to work with OpsItems across accounts.
        /// For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/OpsCenter-setup.html">Set
        /// up OpsCenter</a> in the <i>Amazon Web Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter ActualEndTime
        /// <summary>
        /// <para>
        /// <para>The time a runbook workflow ended. Currently reported only for the OpsItem type <c>/aws/changerequest</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ActualEndTime { get; set; }
        #endregion
        
        #region Parameter ActualStartTime
        /// <summary>
        /// <para>
        /// <para>The time a runbook workflow started. Currently reported only for the OpsItem type
        /// <c>/aws/changerequest</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ActualStartTime { get; set; }
        #endregion
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// <para>Specify a category to assign to an OpsItem. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Category { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>User-defined text that contains information about the OpsItem, in Markdown format.
        /// </para><note><para>Provide enough information so that users viewing this OpsItem for the first time understand
        /// the issue. </para></note>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Notification
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an SNS topic where notifications are sent when this
        /// OpsItem is edited or changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Notifications")]
        public Amazon.SimpleSystemsManagement.Model.OpsItemNotification[] Notification { get; set; }
        #endregion
        
        #region Parameter OperationalData
        /// <summary>
        /// <para>
        /// <para>Operational data is custom data that provides useful reference details about the OpsItem.
        /// For example, you can specify log files, error strings, license keys, troubleshooting
        /// tips, or other relevant data. You enter operational data as key-value pairs. The key
        /// has a maximum length of 128 characters. The value has a maximum size of 20 KB.</para><important><para>Operational data keys <i>can't</i> begin with the following: <c>amazon</c>, <c>aws</c>,
        /// <c>amzn</c>, <c>ssm</c>, <c>/amazon</c>, <c>/aws</c>, <c>/amzn</c>, <c>/ssm</c>.</para></important><para>You can choose to make the data searchable by other users in the account or you can
        /// restrict search access. Searchable data means that all users with access to the OpsItem
        /// Overview page (as provided by the <a>DescribeOpsItems</a> API operation) can view
        /// and search on the specified data. Operational data that isn't searchable is only viewable
        /// by users who have access to the OpsItem (as provided by the <a>GetOpsItem</a> API
        /// operation).</para><para>Use the <c>/aws/resources</c> key in OperationalData to specify a related resource
        /// in the request. Use the <c>/aws/automations</c> key in OperationalData to associate
        /// an Automation runbook with the OpsItem. To view Amazon Web Services CLI example commands
        /// that use these keys, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/OpsCenter-manually-create-OpsItems.html">Creating
        /// OpsItems manually</a> in the <i>Amazon Web Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable OperationalData { get; set; }
        #endregion
        
        #region Parameter OpsItemType
        /// <summary>
        /// <para>
        /// <para>The type of OpsItem to create. Systems Manager supports the following types of OpsItems:</para><ul><li><para><c>/aws/issue</c></para><para>This type of OpsItem is used for default OpsItems created by OpsCenter. </para></li><li><para><c>/aws/changerequest</c></para><para>This type of OpsItem is used by Change Manager for reviewing and approving or rejecting
        /// change requests. </para></li><li><para><c>/aws/insight</c></para><para>This type of OpsItem is used by OpsCenter for aggregating and reporting on duplicate
        /// OpsItems. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpsItemType { get; set; }
        #endregion
        
        #region Parameter PlannedEndTime
        /// <summary>
        /// <para>
        /// <para>The time specified in a change request for a runbook workflow to end. Currently supported
        /// only for the OpsItem type <c>/aws/changerequest</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? PlannedEndTime { get; set; }
        #endregion
        
        #region Parameter PlannedStartTime
        /// <summary>
        /// <para>
        /// <para>The time specified in a change request for a runbook workflow to start. Currently
        /// supported only for the OpsItem type <c>/aws/changerequest</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? PlannedStartTime { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The importance of this OpsItem in relation to other OpsItems in the system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter RelatedOpsItem
        /// <summary>
        /// <para>
        /// <para>One or more OpsItems that share something in common with the current OpsItems. For
        /// example, related OpsItems can include OpsItems with similar error messages, impacted
        /// resources, or statuses for the impacted resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RelatedOpsItems")]
        public Amazon.SimpleSystemsManagement.Model.RelatedOpsItem[] RelatedOpsItem { get; set; }
        #endregion
        
        #region Parameter Severity
        /// <summary>
        /// <para>
        /// <para>Specify a severity to assign to an OpsItem.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Severity { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The origin of the OpsItem, such as Amazon EC2 or Systems Manager.</para><note><para>The source name can't contain the following strings: <c>aws</c>, <c>amazon</c>, and
        /// <c>amzn</c>. </para></note>
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
        public System.String Source { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you assign to a resource.</para><para>Tags use a key-value pair. For example:</para><para><c>Key=Department,Value=Finance</c></para><important><para>To add tags to a new OpsItem, a user must have IAM permissions for both the <c>ssm:CreateOpsItems</c>
        /// operation and the <c>ssm:AddTagsToResource</c> operation. To add tags to an existing
        /// OpsItem, use the <a>AddTagsToResource</a> operation.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleSystemsManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>A short heading that describes the nature of the OpsItem and the impacted resource.</para>
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
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OpsItemId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.CreateOpsItemResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.CreateOpsItemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OpsItemId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Title parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Title' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Title' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Title), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMOpsItem (CreateOpsItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.CreateOpsItemResponse, NewSSMOpsItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Title;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            context.ActualEndTime = this.ActualEndTime;
            context.ActualStartTime = this.ActualStartTime;
            context.Category = this.Category;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Notification != null)
            {
                context.Notification = new List<Amazon.SimpleSystemsManagement.Model.OpsItemNotification>(this.Notification);
            }
            if (this.OperationalData != null)
            {
                context.OperationalData = new Dictionary<System.String, Amazon.SimpleSystemsManagement.Model.OpsItemDataValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.OperationalData.Keys)
                {
                    context.OperationalData.Add((String)hashKey, (Amazon.SimpleSystemsManagement.Model.OpsItemDataValue)(this.OperationalData[hashKey]));
                }
            }
            context.OpsItemType = this.OpsItemType;
            context.PlannedEndTime = this.PlannedEndTime;
            context.PlannedStartTime = this.PlannedStartTime;
            context.Priority = this.Priority;
            if (this.RelatedOpsItem != null)
            {
                context.RelatedOpsItem = new List<Amazon.SimpleSystemsManagement.Model.RelatedOpsItem>(this.RelatedOpsItem);
            }
            context.Severity = this.Severity;
            context.Source = this.Source;
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleSystemsManagement.Model.Tag>(this.Tag);
            }
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreateOpsItemRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.ActualEndTime != null)
            {
                request.ActualEndTime = cmdletContext.ActualEndTime.Value;
            }
            if (cmdletContext.ActualStartTime != null)
            {
                request.ActualStartTime = cmdletContext.ActualStartTime.Value;
            }
            if (cmdletContext.Category != null)
            {
                request.Category = cmdletContext.Category;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Notification != null)
            {
                request.Notifications = cmdletContext.Notification;
            }
            if (cmdletContext.OperationalData != null)
            {
                request.OperationalData = cmdletContext.OperationalData;
            }
            if (cmdletContext.OpsItemType != null)
            {
                request.OpsItemType = cmdletContext.OpsItemType;
            }
            if (cmdletContext.PlannedEndTime != null)
            {
                request.PlannedEndTime = cmdletContext.PlannedEndTime.Value;
            }
            if (cmdletContext.PlannedStartTime != null)
            {
                request.PlannedStartTime = cmdletContext.PlannedStartTime.Value;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.RelatedOpsItem != null)
            {
                request.RelatedOpsItems = cmdletContext.RelatedOpsItem;
            }
            if (cmdletContext.Severity != null)
            {
                request.Severity = cmdletContext.Severity;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreateOpsItemResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreateOpsItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreateOpsItem");
            try
            {
                #if DESKTOP
                return client.CreateOpsItem(request);
                #elif CORECLR
                return client.CreateOpsItemAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.DateTime? ActualEndTime { get; set; }
            public System.DateTime? ActualStartTime { get; set; }
            public System.String Category { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.OpsItemNotification> Notification { get; set; }
            public Dictionary<System.String, Amazon.SimpleSystemsManagement.Model.OpsItemDataValue> OperationalData { get; set; }
            public System.String OpsItemType { get; set; }
            public System.DateTime? PlannedEndTime { get; set; }
            public System.DateTime? PlannedStartTime { get; set; }
            public System.Int32? Priority { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.RelatedOpsItem> RelatedOpsItem { get; set; }
            public System.String Severity { get; set; }
            public System.String Source { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Tag> Tag { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.CreateOpsItemResponse, NewSSMOpsItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OpsItemId;
        }
        
    }
}
