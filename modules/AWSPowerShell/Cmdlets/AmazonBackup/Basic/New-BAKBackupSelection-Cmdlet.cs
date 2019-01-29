/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Resources can be included by specifying patterns for a <code>ListOfTags</code> and
    /// selected <code>Resources</code>. 
    /// 
    ///  
    /// <para>
    /// For example, consider the following patterns:
    /// </para><ul><li><para><code>Resources: "arn:aws:ec2:region:account-id:volume/volume-id"</code></para></li><li><para><code>ConditionKey:"department"</code></para><para><code>ConditionValue:"finance"</code></para><para><code>ConditionType:"StringEquals"</code></para></li><li><para><code>ConditionKey:"importance"</code></para><para><code>ConditionValue:"critical"</code></para><para><code>ConditionType:"StringEquals"</code></para></li></ul><para>
    /// Using these patterns would back up all Amazon Elastic Block Store (Amazon EBS) volumes
    /// that are tagged as <code>"department=finance"</code>, <code>"importance=critical"</code>,
    /// in addition to an EBS volume with the specified volume Id.
    /// </para><para>
    /// Resources and conditions are additive in that all resources that match the pattern
    /// are selected. This shouldn't be confused with a logical AND, where all conditions
    /// must match. The matching patterns are logically 'put together using the OR operator.
    /// In other words, all patterns that match are selected for backup.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BAKBackupSelection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateBackupSelectionResponse")]
    [AWSCmdlet("Calls the Amazon Backup CreateBackupSelection API operation.", Operation = new[] {"CreateBackupSelection"})]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateBackupSelectionResponse",
        "This cmdlet returns a Amazon.Backup.Model.CreateBackupSelectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBAKBackupSelectionCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        #region Parameter BackupPlanId
        /// <summary>
        /// <para>
        /// <para>Uniquely identifies the backup plan to be associated with the selection of resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BackupPlanId { get; set; }
        #endregion
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and allows failed requests to be retried
        /// without the risk of executing the operation twice.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter BackupSelection_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that AWS Backup uses to authenticate when restoring the target
        /// resource; for example, <code>arn:aws:iam::123456789012:role/S3Access</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BackupSelection_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter BackupSelection_ListOfTag
        /// <summary>
        /// <para>
        /// <para>An array of conditions used to specify a set of resources to assign to a backup plan;
        /// for example, <code>"StringEquals": {"ec2:ResourceTag/Department": "accounting"</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BackupSelection_ListOfTags")]
        public Amazon.Backup.Model.Condition[] BackupSelection_ListOfTag { get; set; }
        #endregion
        
        #region Parameter BackupSelection_Resource
        /// <summary>
        /// <para>
        /// <para>An array of strings that either contain Amazon Resource Names (ARNs) or match patterns
        /// such as "<code>arn:aws:ec2:us-east-1:123456789012:volume/*</code>" of resources to
        /// assign to a backup plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BackupSelection_Resources")]
        public System.String[] BackupSelection_Resource { get; set; }
        #endregion
        
        #region Parameter BackupSelection_SelectionName
        /// <summary>
        /// <para>
        /// <para>The display name of a resource selection document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BackupSelection_SelectionName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BackupPlanId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKBackupSelection (CreateBackupSelection)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.BackupPlanId = this.BackupPlanId;
            context.BackupSelection_IamRoleArn = this.BackupSelection_IamRoleArn;
            if (this.BackupSelection_ListOfTag != null)
            {
                context.BackupSelection_ListOfTags = new List<Amazon.Backup.Model.Condition>(this.BackupSelection_ListOfTag);
            }
            if (this.BackupSelection_Resource != null)
            {
                context.BackupSelection_Resources = new List<System.String>(this.BackupSelection_Resource);
            }
            context.BackupSelection_SelectionName = this.BackupSelection_SelectionName;
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
            bool requestBackupSelectionIsNull = true;
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
            if (cmdletContext.BackupSelection_ListOfTags != null)
            {
                requestBackupSelection_backupSelection_ListOfTag = cmdletContext.BackupSelection_ListOfTags;
            }
            if (requestBackupSelection_backupSelection_ListOfTag != null)
            {
                request.BackupSelection.ListOfTags = requestBackupSelection_backupSelection_ListOfTag;
                requestBackupSelectionIsNull = false;
            }
            List<System.String> requestBackupSelection_backupSelection_Resource = null;
            if (cmdletContext.BackupSelection_Resources != null)
            {
                requestBackupSelection_backupSelection_Resource = cmdletContext.BackupSelection_Resources;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Backup", "CreateBackupSelection");
            try
            {
                #if DESKTOP
                return client.CreateBackupSelection(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateBackupSelectionAsync(request);
                return task.Result;
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
            public System.String BackupSelection_IamRoleArn { get; set; }
            public List<Amazon.Backup.Model.Condition> BackupSelection_ListOfTags { get; set; }
            public List<System.String> BackupSelection_Resources { get; set; }
            public System.String BackupSelection_SelectionName { get; set; }
            public System.String CreatorRequestId { get; set; }
        }
        
    }
}
