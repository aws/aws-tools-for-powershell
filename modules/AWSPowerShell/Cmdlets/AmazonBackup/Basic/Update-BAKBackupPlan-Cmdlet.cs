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
    /// Replaces the body of a saved backup plan identified by its <code>backupPlanId</code>
    /// with the input document in JSON format. The new version is uniquely identified by
    /// a <code>VersionId</code>.
    /// </summary>
    [Cmdlet("Update", "BAKBackupPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.UpdateBackupPlanResponse")]
    [AWSCmdlet("Calls the Amazon Backup UpdateBackupPlan API operation.", Operation = new[] {"UpdateBackupPlan"})]
    [AWSCmdletOutput("Amazon.Backup.Model.UpdateBackupPlanResponse",
        "This cmdlet returns a Amazon.Backup.Model.UpdateBackupPlanResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBAKBackupPlanCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        #region Parameter BackupPlanId
        /// <summary>
        /// <para>
        /// <para>Uniquely identifies a backup plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BackupPlanId { get; set; }
        #endregion
        
        #region Parameter BackupPlan_BackupPlanName
        /// <summary>
        /// <para>
        /// <para>The display name of a backup plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String BackupPlan_BackupPlanName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BackupPlanId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BAKBackupPlan (UpdateBackupPlan)"))
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
            context.BackupPlanId = this.BackupPlanId;
            
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
            var request = new Amazon.Backup.Model.UpdateBackupPlanRequest();
            
            
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
            if (cmdletContext.BackupPlanId != null)
            {
                request.BackupPlanId = cmdletContext.BackupPlanId;
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
        
        private Amazon.Backup.Model.UpdateBackupPlanResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.UpdateBackupPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Backup", "UpdateBackupPlan");
            try
            {
                #if DESKTOP
                return client.UpdateBackupPlan(request);
                #elif CORECLR
                return client.UpdateBackupPlanAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupPlanId { get; set; }
        }
        
    }
}
