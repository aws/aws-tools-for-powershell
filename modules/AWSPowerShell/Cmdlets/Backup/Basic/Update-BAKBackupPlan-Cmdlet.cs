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
    /// Updates an existing backup plan identified by its <code>backupPlanId</code> with the
    /// input document in JSON format. The new version is uniquely identified by a <code>VersionId</code>.
    /// </summary>
    [Cmdlet("Update", "BAKBackupPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.UpdateBackupPlanResponse")]
    [AWSCmdlet("Calls the AWS Backup UpdateBackupPlan API operation.", Operation = new[] {"UpdateBackupPlan"}, SelectReturnType = typeof(Amazon.Backup.Model.UpdateBackupPlanResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.UpdateBackupPlanResponse",
        "This cmdlet returns an Amazon.Backup.Model.UpdateBackupPlanResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBAKBackupPlanCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        #region Parameter BackupPlan_AdvancedBackupSetting
        /// <summary>
        /// <para>
        /// <para>Specifies a list of <code>BackupOptions</code> for each resource type. These settings
        /// are only available for Windows Volume Shadow Copy Service (VSS) backup jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupPlan_AdvancedBackupSettings")]
        public Amazon.Backup.Model.AdvancedBackupSetting[] BackupPlan_AdvancedBackupSetting { get; set; }
        #endregion
        
        #region Parameter BackupPlanId
        /// <summary>
        /// <para>
        /// <para>Uniquely identifies a backup plan.</para>
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
        public System.String BackupPlanId { get; set; }
        #endregion
        
        #region Parameter BackupPlan_BackupPlanName
        /// <summary>
        /// <para>
        /// <para>The display name of a backup plan. Must contain 1 to 50 alphanumeric or '-_.' characters.</para>
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
        public System.String BackupPlan_BackupPlanName { get; set; }
        #endregion
        
        #region Parameter BackupPlan_Rule
        /// <summary>
        /// <para>
        /// <para>An array of <code>BackupRule</code> objects, each of which specifies a scheduled task
        /// that is used to back up a selection of resources.</para>
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
        [Alias("BackupPlan_Rules")]
        public Amazon.Backup.Model.BackupRuleInput[] BackupPlan_Rule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.UpdateBackupPlanResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.UpdateBackupPlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BackupPlan_BackupPlanName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BackupPlan_BackupPlanName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BackupPlan_BackupPlanName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BackupPlanId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BAKBackupPlan (UpdateBackupPlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.UpdateBackupPlanResponse, UpdateBAKBackupPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BackupPlan_BackupPlanName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BackupPlan_AdvancedBackupSetting != null)
            {
                context.BackupPlan_AdvancedBackupSetting = new List<Amazon.Backup.Model.AdvancedBackupSetting>(this.BackupPlan_AdvancedBackupSetting);
            }
            context.BackupPlan_BackupPlanName = this.BackupPlan_BackupPlanName;
            #if MODULAR
            if (this.BackupPlan_BackupPlanName == null && ParameterWasBound(nameof(this.BackupPlan_BackupPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupPlan_BackupPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.BackupPlan_Rule != null)
            {
                context.BackupPlan_Rule = new List<Amazon.Backup.Model.BackupRuleInput>(this.BackupPlan_Rule);
            }
            #if MODULAR
            if (this.BackupPlan_Rule == null && ParameterWasBound(nameof(this.BackupPlan_Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupPlan_Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BackupPlanId = this.BackupPlanId;
            #if MODULAR
            if (this.BackupPlanId == null && ParameterWasBound(nameof(this.BackupPlanId)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupPlanId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.UpdateBackupPlanRequest();
            
            
             // populate BackupPlan
            var requestBackupPlanIsNull = true;
            request.BackupPlan = new Amazon.Backup.Model.BackupPlanInput();
            List<Amazon.Backup.Model.AdvancedBackupSetting> requestBackupPlan_backupPlan_AdvancedBackupSetting = null;
            if (cmdletContext.BackupPlan_AdvancedBackupSetting != null)
            {
                requestBackupPlan_backupPlan_AdvancedBackupSetting = cmdletContext.BackupPlan_AdvancedBackupSetting;
            }
            if (requestBackupPlan_backupPlan_AdvancedBackupSetting != null)
            {
                request.BackupPlan.AdvancedBackupSettings = requestBackupPlan_backupPlan_AdvancedBackupSetting;
                requestBackupPlanIsNull = false;
            }
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
            if (cmdletContext.BackupPlan_Rule != null)
            {
                requestBackupPlan_backupPlan_Rule = cmdletContext.BackupPlan_Rule;
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
        
        private Amazon.Backup.Model.UpdateBackupPlanResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.UpdateBackupPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "UpdateBackupPlan");
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
            public List<Amazon.Backup.Model.AdvancedBackupSetting> BackupPlan_AdvancedBackupSetting { get; set; }
            public System.String BackupPlan_BackupPlanName { get; set; }
            public List<Amazon.Backup.Model.BackupRuleInput> BackupPlan_Rule { get; set; }
            public System.String BackupPlanId { get; set; }
            public System.Func<Amazon.Backup.Model.UpdateBackupPlanResponse, UpdateBAKBackupPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
