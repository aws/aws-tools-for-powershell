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
    /// Edit or change an OpsItem. You must have permission in Identity and Access Management
    /// (IAM) to update an OpsItem. For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/OpsCenter-setup.html">Set
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
    [Cmdlet("Update", "SSMOpsItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager UpdateOpsItem API operation.", Operation = new[] {"UpdateOpsItem"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.UpdateOpsItemResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleSystemsManagement.Model.UpdateOpsItemResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleSystemsManagement.Model.UpdateOpsItemResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSSMOpsItemCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>Specify a new category for an OpsItem.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Category { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>User-defined text that contains information about the OpsItem, in Markdown format.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// <para>Add new keys or edit existing key-value pairs of the OperationalData map in the OpsItem
        /// object.</para><para>Operational data is custom data that provides useful reference details about the OpsItem.
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
        
        #region Parameter OperationalDataToDelete
        /// <summary>
        /// <para>
        /// <para>Keys that you want to remove from the OperationalData map.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OperationalDataToDelete { get; set; }
        #endregion
        
        #region Parameter OpsItemArn
        /// <summary>
        /// <para>
        /// <para>The OpsItem Amazon Resource Name (ARN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpsItemArn { get; set; }
        #endregion
        
        #region Parameter OpsItemId
        /// <summary>
        /// <para>
        /// <para>The ID of the OpsItem.</para>
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
        public System.String OpsItemId { get; set; }
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
        /// <para>Specify a new severity for an OpsItem.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Severity { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The OpsItem status. For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/OpsCenter-working-with-OpsItems-editing-details.html">Editing
        /// OpsItem details</a> in the <i>Amazon Web Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.OpsItemStatus")]
        public Amazon.SimpleSystemsManagement.OpsItemStatus Status { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>A short heading that describes the nature of the OpsItem and the impacted resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.UpdateOpsItemResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OpsItemId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OpsItemId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OpsItemId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OpsItemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMOpsItem (UpdateOpsItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.UpdateOpsItemResponse, UpdateSSMOpsItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OpsItemId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActualEndTime = this.ActualEndTime;
            context.ActualStartTime = this.ActualStartTime;
            context.Category = this.Category;
            context.Description = this.Description;
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
            if (this.OperationalDataToDelete != null)
            {
                context.OperationalDataToDelete = new List<System.String>(this.OperationalDataToDelete);
            }
            context.OpsItemArn = this.OpsItemArn;
            context.OpsItemId = this.OpsItemId;
            #if MODULAR
            if (this.OpsItemId == null && ParameterWasBound(nameof(this.OpsItemId)))
            {
                WriteWarning("You are passing $null as a value for parameter OpsItemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlannedEndTime = this.PlannedEndTime;
            context.PlannedStartTime = this.PlannedStartTime;
            context.Priority = this.Priority;
            if (this.RelatedOpsItem != null)
            {
                context.RelatedOpsItem = new List<Amazon.SimpleSystemsManagement.Model.RelatedOpsItem>(this.RelatedOpsItem);
            }
            context.Severity = this.Severity;
            context.Status = this.Status;
            context.Title = this.Title;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.UpdateOpsItemRequest();
            
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
            if (cmdletContext.OperationalDataToDelete != null)
            {
                request.OperationalDataToDelete = cmdletContext.OperationalDataToDelete;
            }
            if (cmdletContext.OpsItemArn != null)
            {
                request.OpsItemArn = cmdletContext.OpsItemArn;
            }
            if (cmdletContext.OpsItemId != null)
            {
                request.OpsItemId = cmdletContext.OpsItemId;
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
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.SimpleSystemsManagement.Model.UpdateOpsItemResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.UpdateOpsItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "UpdateOpsItem");
            try
            {
                #if DESKTOP
                return client.UpdateOpsItem(request);
                #elif CORECLR
                return client.UpdateOpsItemAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? ActualEndTime { get; set; }
            public System.DateTime? ActualStartTime { get; set; }
            public System.String Category { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.OpsItemNotification> Notification { get; set; }
            public Dictionary<System.String, Amazon.SimpleSystemsManagement.Model.OpsItemDataValue> OperationalData { get; set; }
            public List<System.String> OperationalDataToDelete { get; set; }
            public System.String OpsItemArn { get; set; }
            public System.String OpsItemId { get; set; }
            public System.DateTime? PlannedEndTime { get; set; }
            public System.DateTime? PlannedStartTime { get; set; }
            public System.Int32? Priority { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.RelatedOpsItem> RelatedOpsItem { get; set; }
            public System.String Severity { get; set; }
            public Amazon.SimpleSystemsManagement.OpsItemStatus Status { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.UpdateOpsItemResponse, UpdateSSMOpsItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
