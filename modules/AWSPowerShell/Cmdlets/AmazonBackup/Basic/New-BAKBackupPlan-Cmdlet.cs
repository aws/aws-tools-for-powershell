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
    /// Backup plans are documents that contain information that AWS Backup uses to schedule
    /// tasks that create recovery points of resources.
    /// 
    ///  
    /// <para>
    /// If you call <code>CreateBackupPlan</code> with a plan that already exists, the existing
    /// <code>backupPlanId</code> is returned.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BAKBackupPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateBackupPlanResponse")]
    [AWSCmdlet("Calls the Amazon Backup CreateBackupPlan API operation.", Operation = new[] {"CreateBackupPlan"})]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateBackupPlanResponse",
        "This cmdlet returns a Amazon.Backup.Model.CreateBackupPlanResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBAKBackupPlanCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        #region Parameter BackupPlan_BackupPlanName
        /// <summary>
        /// <para>
        /// <para>The display name of a backup plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String BackupPlan_BackupPlanName { get; set; }
        #endregion
        
        #region Parameter BackupPlanTag
        /// <summary>
        /// <para>
        /// <para>To help organize your resources, you can assign your own metadata to the resources
        /// that you create. Each tag is a key-value pair. The specified tags are assigned to
        /// all backups created with this plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BackupPlanTags")]
        public System.Collections.Hashtable BackupPlanTag { get; set; }
        #endregion
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>Identifies the request and allows failed requests to be retried without the risk of
        /// executing the operation twice. If the request includes a <code>CreatorRequestId</code>
        /// that matches an existing backup plan, that plan is returned. This parameter is optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter BackupPlan_Rule
        /// <summary>
        /// <para>
        /// <para>An array of <code>BackupRule</code> objects, each of which specifies a scheduled task
        /// that is used to back up a selection of resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BackupPlan_Rules")]
        public Amazon.Backup.Model.BackupRuleInput[] BackupPlan_Rule { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKBackupPlan (CreateBackupPlan)"))
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
            
            context.BackupPlan_BackupPlanName = this.BackupPlan_BackupPlanName;
            if (this.BackupPlan_Rule != null)
            {
                context.BackupPlan_Rules = new List<Amazon.Backup.Model.BackupRuleInput>(this.BackupPlan_Rule);
            }
            if (this.BackupPlanTag != null)
            {
                context.BackupPlanTags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BackupPlanTag.Keys)
                {
                    context.BackupPlanTags.Add((String)hashKey, (String)(this.BackupPlanTag[hashKey]));
                }
            }
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
            var request = new Amazon.Backup.Model.CreateBackupPlanRequest();
            
            
             // populate BackupPlan
            bool requestBackupPlanIsNull = true;
            request.BackupPlan = new Amazon.Backup.Model.BackupPlanInput();
            System.String requestBackupPlan_backupPlan_BackupPlanName = null;
            if (cmdletContext.BackupPlan_BackupPlanName != null)
            {
                requestBackupPlan_backupPlan_BackupPlanName = cmdletContext.BackupPlan_BackupPlanName;
            }
            if (requestBackupPlan_backupPlan_BackupPlanName != null)
            {
                request.BackupPlan.BackupPlanName = requestBackupPlan_backupPlan_BackupPlanName;
                requestBackupPlanIsNull = false;
            }
            List<Amazon.Backup.Model.BackupRuleInput> requestBackupPlan_backupPlan_Rule = null;
            if (cmdletContext.BackupPlan_Rules != null)
            {
                requestBackupPlan_backupPlan_Rule = cmdletContext.BackupPlan_Rules;
            }
            if (requestBackupPlan_backupPlan_Rule != null)
            {
                request.BackupPlan.Rules = requestBackupPlan_backupPlan_Rule;
                requestBackupPlanIsNull = false;
            }
             // determine if request.BackupPlan should be set to null
            if (requestBackupPlanIsNull)
            {
                request.BackupPlan = null;
            }
            if (cmdletContext.BackupPlanTags != null)
            {
                request.BackupPlanTags = cmdletContext.BackupPlanTags;
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
        
        private Amazon.Backup.Model.CreateBackupPlanResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.CreateBackupPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Backup", "CreateBackupPlan");
            try
            {
                #if DESKTOP
                return client.CreateBackupPlan(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateBackupPlanAsync(request);
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
            public System.String BackupPlan_BackupPlanName { get; set; }
            public List<Amazon.Backup.Model.BackupRuleInput> BackupPlan_Rules { get; set; }
            public Dictionary<System.String, System.String> BackupPlanTags { get; set; }
            public System.String CreatorRequestId { get; set; }
        }
        
    }
}
