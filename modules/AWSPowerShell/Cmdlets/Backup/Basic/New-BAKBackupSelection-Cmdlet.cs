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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Creates a JSON document that specifies a set of resources to assign to a backup plan.
    /// For examples, see <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/assigning-resources.html#assigning-resources-json">Assigning
    /// resources programmatically</a>.
    /// </summary>
    [Cmdlet("New", "BAKBackupSelection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateBackupSelectionResponse")]
    [AWSCmdlet("Calls the AWS Backup CreateBackupSelection API operation.", Operation = new[] {"CreateBackupSelection"}, SelectReturnType = typeof(Amazon.Backup.Model.CreateBackupSelectionResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateBackupSelectionResponse",
        "This cmdlet returns an Amazon.Backup.Model.CreateBackupSelectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBAKBackupSelectionCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        #region Parameter BackupPlanId
        /// <summary>
        /// <para>
        /// <para>Uniquely identifies the backup plan to be associated with the selection of resources.</para>
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
        public System.String BackupPlanId { get; set; }
        #endregion
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and allows failed requests to be retried
        /// without the risk of running the operation twice. This parameter is optional.</para><para>If used, this parameter must contain 1 to 50 alphanumeric or '-_.' characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter BackupSelection_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that Backup uses to authenticate when backing up the target
        /// resource; for example, <code>arn:aws:iam::123456789012:role/S3Access</code>.</para>
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
        public System.String BackupSelection_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter BackupSelection_ListOfTag
        /// <summary>
        /// <para>
        /// <para>A list of conditions that you define to assign resources to your backup plans using
        /// tags. For example, <code>"StringEquals": {"Department": "accounting"</code>. Condition
        /// operators are case sensitive.</para><para><code>ListOfTags</code> differs from <code>Conditions</code> as follows:</para><ul><li><para>When you specify more than one condition, you assign all resources that match AT LEAST
        /// ONE condition (using OR logic).</para></li><li><para><code>ListOfTags</code> only supports <code>StringEquals</code>. <code>Conditions</code>
        /// supports <code>StringEquals</code>, <code>StringLike</code>, <code>StringNotEquals</code>,
        /// and <code>StringNotLike</code>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupSelection_ListOfTags")]
        public Amazon.Backup.Model.Condition[] BackupSelection_ListOfTag { get; set; }
        #endregion
        
        #region Parameter BackupSelection_NotResource
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Resource Names (ARNs) to exclude from a backup plan. The maximum
        /// number of ARNs is 500 without wildcards, or 30 ARNs with wildcards.</para><para>If you need to exclude many resources from a backup plan, consider a different resource
        /// selection strategy, such as assigning only one or a few resource types or refining
        /// your resource selection using tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupSelection_NotResources")]
        public System.String[] BackupSelection_NotResource { get; set; }
        #endregion
        
        #region Parameter BackupSelection_Resource
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Resource Names (ARNs) to assign to a backup plan. The maximum number
        /// of ARNs is 500 without wildcards, or 30 ARNs with wildcards.</para><para>If you need to assign many resources to a backup plan, consider a different resource
        /// selection strategy, such as assigning all resources of a resource type or refining
        /// your resource selection using tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupSelection_Resources")]
        public System.String[] BackupSelection_Resource { get; set; }
        #endregion
        
        #region Parameter BackupSelection_SelectionName
        /// <summary>
        /// <para>
        /// <para>The display name of a resource selection document. Must contain 1 to 50 alphanumeric
        /// or '-_.' characters.</para>
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
        public System.String BackupSelection_SelectionName { get; set; }
        #endregion
        
        #region Parameter Conditions_StringEqual
        /// <summary>
        /// <para>
        /// <para>Filters the values of your tagged resources for only those resources that you tagged
        /// with the same value. Also called "exact matching."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupSelection_Conditions_StringEquals")]
        public Amazon.Backup.Model.ConditionParameter[] Conditions_StringEqual { get; set; }
        #endregion
        
        #region Parameter Conditions_StringLike
        /// <summary>
        /// <para>
        /// <para>Filters the values of your tagged resources for matching tag values with the use of
        /// a wildcard character (*) anywhere in the string. For example, "prod*" or "*rod*" matches
        /// the tag value "production".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupSelection_Conditions_StringLike")]
        public Amazon.Backup.Model.ConditionParameter[] Conditions_StringLike { get; set; }
        #endregion
        
        #region Parameter Conditions_StringNotEqual
        /// <summary>
        /// <para>
        /// <para>Filters the values of your tagged resources for only those resources that you tagged
        /// that do not have the same value. Also called "negated matching."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupSelection_Conditions_StringNotEquals")]
        public Amazon.Backup.Model.ConditionParameter[] Conditions_StringNotEqual { get; set; }
        #endregion
        
        #region Parameter Conditions_StringNotLike
        /// <summary>
        /// <para>
        /// <para>Filters the values of your tagged resources for non-matching tag values with the use
        /// of a wildcard character (*) anywhere in the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupSelection_Conditions_StringNotLike")]
        public Amazon.Backup.Model.ConditionParameter[] Conditions_StringNotLike { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.CreateBackupSelectionResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.CreateBackupSelectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BackupPlanId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BackupPlanId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BackupPlanId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BackupPlanId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKBackupSelection (CreateBackupSelection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.CreateBackupSelectionResponse, NewBAKBackupSelectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BackupPlanId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupPlanId = this.BackupPlanId;
            #if MODULAR
            if (this.BackupPlanId == null && ParameterWasBound(nameof(this.BackupPlanId)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupPlanId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Conditions_StringEqual != null)
            {
                context.Conditions_StringEqual = new List<Amazon.Backup.Model.ConditionParameter>(this.Conditions_StringEqual);
            }
            if (this.Conditions_StringLike != null)
            {
                context.Conditions_StringLike = new List<Amazon.Backup.Model.ConditionParameter>(this.Conditions_StringLike);
            }
            if (this.Conditions_StringNotEqual != null)
            {
                context.Conditions_StringNotEqual = new List<Amazon.Backup.Model.ConditionParameter>(this.Conditions_StringNotEqual);
            }
            if (this.Conditions_StringNotLike != null)
            {
                context.Conditions_StringNotLike = new List<Amazon.Backup.Model.ConditionParameter>(this.Conditions_StringNotLike);
            }
            context.BackupSelection_IamRoleArn = this.BackupSelection_IamRoleArn;
            #if MODULAR
            if (this.BackupSelection_IamRoleArn == null && ParameterWasBound(nameof(this.BackupSelection_IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupSelection_IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.BackupSelection_ListOfTag != null)
            {
                context.BackupSelection_ListOfTag = new List<Amazon.Backup.Model.Condition>(this.BackupSelection_ListOfTag);
            }
            if (this.BackupSelection_NotResource != null)
            {
                context.BackupSelection_NotResource = new List<System.String>(this.BackupSelection_NotResource);
            }
            if (this.BackupSelection_Resource != null)
            {
                context.BackupSelection_Resource = new List<System.String>(this.BackupSelection_Resource);
            }
            context.BackupSelection_SelectionName = this.BackupSelection_SelectionName;
            #if MODULAR
            if (this.BackupSelection_SelectionName == null && ParameterWasBound(nameof(this.BackupSelection_SelectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupSelection_SelectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CreatorRequestId = this.CreatorRequestId;
            
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
            var request = new Amazon.Backup.Model.CreateBackupSelectionRequest();
            
            if (cmdletContext.BackupPlanId != null)
            {
                request.BackupPlanId = cmdletContext.BackupPlanId;
            }
            
             // populate BackupSelection
            var requestBackupSelectionIsNull = true;
            request.BackupSelection = new Amazon.Backup.Model.BackupSelection();
            System.String requestBackupSelection_backupSelection_IamRoleArn = null;
            if (cmdletContext.BackupSelection_IamRoleArn != null)
            {
                requestBackupSelection_backupSelection_IamRoleArn = cmdletContext.BackupSelection_IamRoleArn;
            }
            if (requestBackupSelection_backupSelection_IamRoleArn != null)
            {
                request.BackupSelection.IamRoleArn = requestBackupSelection_backupSelection_IamRoleArn;
                requestBackupSelectionIsNull = false;
            }
            List<Amazon.Backup.Model.Condition> requestBackupSelection_backupSelection_ListOfTag = null;
            if (cmdletContext.BackupSelection_ListOfTag != null)
            {
                requestBackupSelection_backupSelection_ListOfTag = cmdletContext.BackupSelection_ListOfTag;
            }
            if (requestBackupSelection_backupSelection_ListOfTag != null)
            {
                request.BackupSelection.ListOfTags = requestBackupSelection_backupSelection_ListOfTag;
                requestBackupSelectionIsNull = false;
            }
            List<System.String> requestBackupSelection_backupSelection_NotResource = null;
            if (cmdletContext.BackupSelection_NotResource != null)
            {
                requestBackupSelection_backupSelection_NotResource = cmdletContext.BackupSelection_NotResource;
            }
            if (requestBackupSelection_backupSelection_NotResource != null)
            {
                request.BackupSelection.NotResources = requestBackupSelection_backupSelection_NotResource;
                requestBackupSelectionIsNull = false;
            }
            List<System.String> requestBackupSelection_backupSelection_Resource = null;
            if (cmdletContext.BackupSelection_Resource != null)
            {
                requestBackupSelection_backupSelection_Resource = cmdletContext.BackupSelection_Resource;
            }
            if (requestBackupSelection_backupSelection_Resource != null)
            {
                request.BackupSelection.Resources = requestBackupSelection_backupSelection_Resource;
                requestBackupSelectionIsNull = false;
            }
            System.String requestBackupSelection_backupSelection_SelectionName = null;
            if (cmdletContext.BackupSelection_SelectionName != null)
            {
                requestBackupSelection_backupSelection_SelectionName = cmdletContext.BackupSelection_SelectionName;
            }
            if (requestBackupSelection_backupSelection_SelectionName != null)
            {
                request.BackupSelection.SelectionName = requestBackupSelection_backupSelection_SelectionName;
                requestBackupSelectionIsNull = false;
            }
            Amazon.Backup.Model.Conditions requestBackupSelection_backupSelection_Conditions = null;
            
             // populate Conditions
            var requestBackupSelection_backupSelection_ConditionsIsNull = true;
            requestBackupSelection_backupSelection_Conditions = new Amazon.Backup.Model.Conditions();
            List<Amazon.Backup.Model.ConditionParameter> requestBackupSelection_backupSelection_Conditions_conditions_StringEqual = null;
            if (cmdletContext.Conditions_StringEqual != null)
            {
                requestBackupSelection_backupSelection_Conditions_conditions_StringEqual = cmdletContext.Conditions_StringEqual;
            }
            if (requestBackupSelection_backupSelection_Conditions_conditions_StringEqual != null)
            {
                requestBackupSelection_backupSelection_Conditions.StringEquals = requestBackupSelection_backupSelection_Conditions_conditions_StringEqual;
                requestBackupSelection_backupSelection_ConditionsIsNull = false;
            }
            List<Amazon.Backup.Model.ConditionParameter> requestBackupSelection_backupSelection_Conditions_conditions_StringLike = null;
            if (cmdletContext.Conditions_StringLike != null)
            {
                requestBackupSelection_backupSelection_Conditions_conditions_StringLike = cmdletContext.Conditions_StringLike;
            }
            if (requestBackupSelection_backupSelection_Conditions_conditions_StringLike != null)
            {
                requestBackupSelection_backupSelection_Conditions.StringLike = requestBackupSelection_backupSelection_Conditions_conditions_StringLike;
                requestBackupSelection_backupSelection_ConditionsIsNull = false;
            }
            List<Amazon.Backup.Model.ConditionParameter> requestBackupSelection_backupSelection_Conditions_conditions_StringNotEqual = null;
            if (cmdletContext.Conditions_StringNotEqual != null)
            {
                requestBackupSelection_backupSelection_Conditions_conditions_StringNotEqual = cmdletContext.Conditions_StringNotEqual;
            }
            if (requestBackupSelection_backupSelection_Conditions_conditions_StringNotEqual != null)
            {
                requestBackupSelection_backupSelection_Conditions.StringNotEquals = requestBackupSelection_backupSelection_Conditions_conditions_StringNotEqual;
                requestBackupSelection_backupSelection_ConditionsIsNull = false;
            }
            List<Amazon.Backup.Model.ConditionParameter> requestBackupSelection_backupSelection_Conditions_conditions_StringNotLike = null;
            if (cmdletContext.Conditions_StringNotLike != null)
            {
                requestBackupSelection_backupSelection_Conditions_conditions_StringNotLike = cmdletContext.Conditions_StringNotLike;
            }
            if (requestBackupSelection_backupSelection_Conditions_conditions_StringNotLike != null)
            {
                requestBackupSelection_backupSelection_Conditions.StringNotLike = requestBackupSelection_backupSelection_Conditions_conditions_StringNotLike;
                requestBackupSelection_backupSelection_ConditionsIsNull = false;
            }
             // determine if requestBackupSelection_backupSelection_Conditions should be set to null
            if (requestBackupSelection_backupSelection_ConditionsIsNull)
            {
                requestBackupSelection_backupSelection_Conditions = null;
            }
            if (requestBackupSelection_backupSelection_Conditions != null)
            {
                request.BackupSelection.Conditions = requestBackupSelection_backupSelection_Conditions;
                requestBackupSelectionIsNull = false;
            }
             // determine if request.BackupSelection should be set to null
            if (requestBackupSelectionIsNull)
            {
                request.BackupSelection = null;
            }
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
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
        
        private Amazon.Backup.Model.CreateBackupSelectionResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.CreateBackupSelectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "CreateBackupSelection");
            try
            {
                #if DESKTOP
                return client.CreateBackupSelection(request);
                #elif CORECLR
                return client.CreateBackupSelectionAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupPlanId { get; set; }
            public List<Amazon.Backup.Model.ConditionParameter> Conditions_StringEqual { get; set; }
            public List<Amazon.Backup.Model.ConditionParameter> Conditions_StringLike { get; set; }
            public List<Amazon.Backup.Model.ConditionParameter> Conditions_StringNotEqual { get; set; }
            public List<Amazon.Backup.Model.ConditionParameter> Conditions_StringNotLike { get; set; }
            public System.String BackupSelection_IamRoleArn { get; set; }
            public List<Amazon.Backup.Model.Condition> BackupSelection_ListOfTag { get; set; }
            public List<System.String> BackupSelection_NotResource { get; set; }
            public List<System.String> BackupSelection_Resource { get; set; }
            public System.String BackupSelection_SelectionName { get; set; }
            public System.String CreatorRequestId { get; set; }
            public System.Func<Amazon.Backup.Model.CreateBackupSelectionResponse, NewBAKBackupSelectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
