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
    /// This request will send changes to your specified restore testing plan. <c>RestoreTestingPlanName</c>
    /// cannot be updated after it is created.
    /// 
    ///  
    /// <para><c>RecoveryPointSelection</c> can contain:
    /// </para><ul><li><para><c>Algorithm</c></para></li><li><para><c>ExcludeVaults</c></para></li><li><para><c>IncludeVaults</c></para></li><li><para><c>RecoveryPointTypes</c></para></li><li><para><c>SelectionWindowDays</c></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "BAKRestoreTestingPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.UpdateRestoreTestingPlanResponse")]
    [AWSCmdlet("Calls the AWS Backup UpdateRestoreTestingPlan API operation.", Operation = new[] {"UpdateRestoreTestingPlan"}, SelectReturnType = typeof(Amazon.Backup.Model.UpdateRestoreTestingPlanResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.UpdateRestoreTestingPlanResponse",
        "This cmdlet returns an Amazon.Backup.Model.UpdateRestoreTestingPlanResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBAKRestoreTestingPlanCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RecoveryPointSelection_Algorithm
        /// <summary>
        /// <para>
        /// <para>Acceptable values include "LATEST_WITHIN_WINDOW" or "RANDOM_WITHIN_WINDOW"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingPlan_RecoveryPointSelection_Algorithm")]
        [AWSConstantClassSource("Amazon.Backup.RestoreTestingRecoveryPointSelectionAlgorithm")]
        public Amazon.Backup.RestoreTestingRecoveryPointSelectionAlgorithm RecoveryPointSelection_Algorithm { get; set; }
        #endregion
        
        #region Parameter RecoveryPointSelection_ExcludeVault
        /// <summary>
        /// <para>
        /// <para>Accepted values include specific ARNs or list of selectors. Defaults to empty list
        /// if not listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingPlan_RecoveryPointSelection_ExcludeVaults")]
        public System.String[] RecoveryPointSelection_ExcludeVault { get; set; }
        #endregion
        
        #region Parameter RecoveryPointSelection_IncludeVault
        /// <summary>
        /// <para>
        /// <para>Accepted values include wildcard ["*"] or by specific ARNs or ARN wilcard replacement
        /// ["arn:aws:backup:us-west-2:123456789012:backup-vault:asdf", ...] ["arn:aws:backup:*:*:backup-vault:asdf-*",
        /// ...]</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingPlan_RecoveryPointSelection_IncludeVaults")]
        public System.String[] RecoveryPointSelection_IncludeVault { get; set; }
        #endregion
        
        #region Parameter RecoveryPointSelection_RecoveryPointType
        /// <summary>
        /// <para>
        /// <para>These are the types of recovery points.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingPlan_RecoveryPointSelection_RecoveryPointTypes")]
        public System.String[] RecoveryPointSelection_RecoveryPointType { get; set; }
        #endregion
        
        #region Parameter RestoreTestingPlanName
        /// <summary>
        /// <para>
        /// <para>This is the restore testing plan name you wish to update.</para>
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
        public System.String RestoreTestingPlanName { get; set; }
        #endregion
        
        #region Parameter RestoreTestingPlan_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>A CRON expression in specified timezone when a restore testing plan is executed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestoreTestingPlan_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter RestoreTestingPlan_ScheduleExpressionTimezone
        /// <summary>
        /// <para>
        /// <para>Optional. This is the timezone in which the schedule expression is set. By default,
        /// ScheduleExpressions are in UTC. You can modify this to a specified timezone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestoreTestingPlan_ScheduleExpressionTimezone { get; set; }
        #endregion
        
        #region Parameter RecoveryPointSelection_SelectionWindowDay
        /// <summary>
        /// <para>
        /// <para>Accepted values are integers from 1 to 365.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingPlan_RecoveryPointSelection_SelectionWindowDays")]
        public System.Int32? RecoveryPointSelection_SelectionWindowDay { get; set; }
        #endregion
        
        #region Parameter RestoreTestingPlan_StartWindowHour
        /// <summary>
        /// <para>
        /// <para>Defaults to 24 hours.</para><para>A value in hours after a restore test is scheduled before a job will be canceled if
        /// it doesn't start successfully. This value is optional. If this value is included,
        /// this parameter has a maximum value of 168 hours (one week).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestoreTestingPlan_StartWindowHours")]
        public System.Int32? RestoreTestingPlan_StartWindowHour { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.UpdateRestoreTestingPlanResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.UpdateRestoreTestingPlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RestoreTestingPlanName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RestoreTestingPlanName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RestoreTestingPlanName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RestoreTestingPlanName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BAKRestoreTestingPlan (UpdateRestoreTestingPlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.UpdateRestoreTestingPlanResponse, UpdateBAKRestoreTestingPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RestoreTestingPlanName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RecoveryPointSelection_Algorithm = this.RecoveryPointSelection_Algorithm;
            if (this.RecoveryPointSelection_ExcludeVault != null)
            {
                context.RecoveryPointSelection_ExcludeVault = new List<System.String>(this.RecoveryPointSelection_ExcludeVault);
            }
            if (this.RecoveryPointSelection_IncludeVault != null)
            {
                context.RecoveryPointSelection_IncludeVault = new List<System.String>(this.RecoveryPointSelection_IncludeVault);
            }
            if (this.RecoveryPointSelection_RecoveryPointType != null)
            {
                context.RecoveryPointSelection_RecoveryPointType = new List<System.String>(this.RecoveryPointSelection_RecoveryPointType);
            }
            context.RecoveryPointSelection_SelectionWindowDay = this.RecoveryPointSelection_SelectionWindowDay;
            context.RestoreTestingPlan_ScheduleExpression = this.RestoreTestingPlan_ScheduleExpression;
            context.RestoreTestingPlan_ScheduleExpressionTimezone = this.RestoreTestingPlan_ScheduleExpressionTimezone;
            context.RestoreTestingPlan_StartWindowHour = this.RestoreTestingPlan_StartWindowHour;
            context.RestoreTestingPlanName = this.RestoreTestingPlanName;
            #if MODULAR
            if (this.RestoreTestingPlanName == null && ParameterWasBound(nameof(this.RestoreTestingPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTestingPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.UpdateRestoreTestingPlanRequest();
            
            
             // populate RestoreTestingPlan
            var requestRestoreTestingPlanIsNull = true;
            request.RestoreTestingPlan = new Amazon.Backup.Model.RestoreTestingPlanForUpdate();
            System.String requestRestoreTestingPlan_restoreTestingPlan_ScheduleExpression = null;
            if (cmdletContext.RestoreTestingPlan_ScheduleExpression != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_ScheduleExpression = cmdletContext.RestoreTestingPlan_ScheduleExpression;
            }
            if (requestRestoreTestingPlan_restoreTestingPlan_ScheduleExpression != null)
            {
                request.RestoreTestingPlan.ScheduleExpression = requestRestoreTestingPlan_restoreTestingPlan_ScheduleExpression;
                requestRestoreTestingPlanIsNull = false;
            }
            System.String requestRestoreTestingPlan_restoreTestingPlan_ScheduleExpressionTimezone = null;
            if (cmdletContext.RestoreTestingPlan_ScheduleExpressionTimezone != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_ScheduleExpressionTimezone = cmdletContext.RestoreTestingPlan_ScheduleExpressionTimezone;
            }
            if (requestRestoreTestingPlan_restoreTestingPlan_ScheduleExpressionTimezone != null)
            {
                request.RestoreTestingPlan.ScheduleExpressionTimezone = requestRestoreTestingPlan_restoreTestingPlan_ScheduleExpressionTimezone;
                requestRestoreTestingPlanIsNull = false;
            }
            System.Int32? requestRestoreTestingPlan_restoreTestingPlan_StartWindowHour = null;
            if (cmdletContext.RestoreTestingPlan_StartWindowHour != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_StartWindowHour = cmdletContext.RestoreTestingPlan_StartWindowHour.Value;
            }
            if (requestRestoreTestingPlan_restoreTestingPlan_StartWindowHour != null)
            {
                request.RestoreTestingPlan.StartWindowHours = requestRestoreTestingPlan_restoreTestingPlan_StartWindowHour.Value;
                requestRestoreTestingPlanIsNull = false;
            }
            Amazon.Backup.Model.RestoreTestingRecoveryPointSelection requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection = null;
            
             // populate RecoveryPointSelection
            var requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelectionIsNull = true;
            requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection = new Amazon.Backup.Model.RestoreTestingRecoveryPointSelection();
            Amazon.Backup.RestoreTestingRecoveryPointSelectionAlgorithm requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_Algorithm = null;
            if (cmdletContext.RecoveryPointSelection_Algorithm != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_Algorithm = cmdletContext.RecoveryPointSelection_Algorithm;
            }
            if (requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_Algorithm != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection.Algorithm = requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_Algorithm;
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelectionIsNull = false;
            }
            List<System.String> requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_ExcludeVault = null;
            if (cmdletContext.RecoveryPointSelection_ExcludeVault != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_ExcludeVault = cmdletContext.RecoveryPointSelection_ExcludeVault;
            }
            if (requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_ExcludeVault != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection.ExcludeVaults = requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_ExcludeVault;
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelectionIsNull = false;
            }
            List<System.String> requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_IncludeVault = null;
            if (cmdletContext.RecoveryPointSelection_IncludeVault != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_IncludeVault = cmdletContext.RecoveryPointSelection_IncludeVault;
            }
            if (requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_IncludeVault != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection.IncludeVaults = requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_IncludeVault;
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelectionIsNull = false;
            }
            List<System.String> requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_RecoveryPointType = null;
            if (cmdletContext.RecoveryPointSelection_RecoveryPointType != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_RecoveryPointType = cmdletContext.RecoveryPointSelection_RecoveryPointType;
            }
            if (requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_RecoveryPointType != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection.RecoveryPointTypes = requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_RecoveryPointType;
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelectionIsNull = false;
            }
            System.Int32? requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_SelectionWindowDay = null;
            if (cmdletContext.RecoveryPointSelection_SelectionWindowDay != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_SelectionWindowDay = cmdletContext.RecoveryPointSelection_SelectionWindowDay.Value;
            }
            if (requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_SelectionWindowDay != null)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection.SelectionWindowDays = requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection_recoveryPointSelection_SelectionWindowDay.Value;
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelectionIsNull = false;
            }
             // determine if requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection should be set to null
            if (requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelectionIsNull)
            {
                requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection = null;
            }
            if (requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection != null)
            {
                request.RestoreTestingPlan.RecoveryPointSelection = requestRestoreTestingPlan_restoreTestingPlan_RecoveryPointSelection;
                requestRestoreTestingPlanIsNull = false;
            }
             // determine if request.RestoreTestingPlan should be set to null
            if (requestRestoreTestingPlanIsNull)
            {
                request.RestoreTestingPlan = null;
            }
            if (cmdletContext.RestoreTestingPlanName != null)
            {
                request.RestoreTestingPlanName = cmdletContext.RestoreTestingPlanName;
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
        
        private Amazon.Backup.Model.UpdateRestoreTestingPlanResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.UpdateRestoreTestingPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "UpdateRestoreTestingPlan");
            try
            {
                #if DESKTOP
                return client.UpdateRestoreTestingPlan(request);
                #elif CORECLR
                return client.UpdateRestoreTestingPlanAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Backup.RestoreTestingRecoveryPointSelectionAlgorithm RecoveryPointSelection_Algorithm { get; set; }
            public List<System.String> RecoveryPointSelection_ExcludeVault { get; set; }
            public List<System.String> RecoveryPointSelection_IncludeVault { get; set; }
            public List<System.String> RecoveryPointSelection_RecoveryPointType { get; set; }
            public System.Int32? RecoveryPointSelection_SelectionWindowDay { get; set; }
            public System.String RestoreTestingPlan_ScheduleExpression { get; set; }
            public System.String RestoreTestingPlan_ScheduleExpressionTimezone { get; set; }
            public System.Int32? RestoreTestingPlan_StartWindowHour { get; set; }
            public System.String RestoreTestingPlanName { get; set; }
            public System.Func<Amazon.Backup.Model.UpdateRestoreTestingPlanResponse, UpdateBAKRestoreTestingPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
