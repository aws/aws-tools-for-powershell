/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ObservabilityAdmin;
using Amazon.ObservabilityAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.CWOADMN
{
    /// <summary>
    /// Updates an existing centralization rule that applies across an Amazon Web Services
    /// Organization. This operation can only be called by the organization's management account
    /// or a delegated administrator account.
    /// </summary>
    [Cmdlet("Update", "CWOADMNCentralizationRuleForOrganization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service UpdateCentralizationRuleForOrganization API operation.", Operation = new[] {"UpdateCentralizationRuleForOrganization"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.UpdateCentralizationRuleForOrganizationResponse))]
    [AWSCmdletOutput("System.String or Amazon.ObservabilityAdmin.Model.UpdateCentralizationRuleForOrganizationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.UpdateCentralizationRuleForOrganizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWOADMNCentralizationRuleForOrganizationCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Destination_Account
        /// <summary>
        /// <para>
        /// <para>The destination account (within the organization) to which the telemetry data should
        /// be centralized.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Destination_Account")]
        public System.String Destination_Account { get; set; }
        #endregion
        
        #region Parameter SourceLogsConfiguration_EncryptedLogGroupStrategy
        /// <summary>
        /// <para>
        /// <para>A strategy determining whether to centralize source log groups that are encrypted
        /// with customer managed KMS keys (CMK). ALLOW will consider CMK encrypted source log
        /// groups for centralization while SKIP will skip CMK encrypted source log groups from
        /// centralization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Source_SourceLogsConfiguration_EncryptedLogGroupStrategy")]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.EncryptedLogGroupStrategy")]
        public Amazon.ObservabilityAdmin.EncryptedLogGroupStrategy SourceLogsConfiguration_EncryptedLogGroupStrategy { get; set; }
        #endregion
        
        #region Parameter LogsEncryptionConfiguration_EncryptionConflictResolutionStrategy
        /// <summary>
        /// <para>
        /// <para>Conflict resolution strategy for centralization if the encryption strategy is set
        /// to CUSTOMER_MANAGED and the destination log group is encrypted with an AWS_OWNED KMS
        /// Key. ALLOW lets centralization go through while SKIP prevents centralization into
        /// the destination log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_EncryptionConflictResolutionStrategy")]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.EncryptionConflictResolutionStrategy")]
        public Amazon.ObservabilityAdmin.EncryptionConflictResolutionStrategy LogsEncryptionConfiguration_EncryptionConflictResolutionStrategy { get; set; }
        #endregion
        
        #region Parameter LogsEncryptionConfiguration_EncryptionStrategy
        /// <summary>
        /// <para>
        /// <para>Configuration that determines the encryption strategy of the destination log groups.
        /// CUSTOMER_MANAGED uses the configured KmsKeyArn to encrypt newly created destination
        /// log groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_EncryptionStrategy")]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.EncryptionStrategy")]
        public Amazon.ObservabilityAdmin.EncryptionStrategy LogsEncryptionConfiguration_EncryptionStrategy { get; set; }
        #endregion
        
        #region Parameter BackupConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>KMS Key arn belonging to the primary destination account and backup region, to encrypt
        /// newly created central log groups in the backup destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Destination_DestinationLogsConfiguration_BackupConfiguration_KmsKeyArn")]
        public System.String BackupConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter LogsEncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>KMS Key arn belonging to the primary destination account and region, to encrypt newly
        /// created central log groups in the primary destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_KmsKeyArn")]
        public System.String LogsEncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter SourceLogsConfiguration_LogGroupSelectionCriterion
        /// <summary>
        /// <para>
        /// <para>The selection criteria that specifies which source log groups to centralize. The selection
        /// criteria uses the same format as OAM link filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Source_SourceLogsConfiguration_LogGroupSelectionCriteria")]
        public System.String SourceLogsConfiguration_LogGroupSelectionCriterion { get; set; }
        #endregion
        
        #region Parameter BackupConfiguration_Region
        /// <summary>
        /// <para>
        /// <para>Logs specific backup destination region within the primary destination account to
        /// which log data should be centralized.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Destination_DestinationLogsConfiguration_BackupConfiguration_Region")]
        public System.String BackupConfiguration_Region { get; set; }
        #endregion
        
        #region Parameter Destination_Region
        /// <summary>
        /// <para>
        /// <para>The primary destination region to which telemetry data should be centralized.</para>
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
        [Alias("Rule_Destination_Region")]
        public System.String Destination_Region { get; set; }
        #endregion
        
        #region Parameter Source_Region
        /// <summary>
        /// <para>
        /// <para>The list of source regions from which telemetry data should be centralized.</para>
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
        [Alias("Rule_Source_Regions")]
        public System.String[] Source_Region { get; set; }
        #endregion
        
        #region Parameter RuleIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier (name or ARN) of the organization centralization rule to update.</para>
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
        public System.String RuleIdentifier { get; set; }
        #endregion
        
        #region Parameter Source_Scope
        /// <summary>
        /// <para>
        /// <para>The organizational scope from which telemetry data should be centralized, specified
        /// using organization id, accounts or organizational unit ids.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Source_Scope")]
        public System.String Source_Scope { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RuleArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.UpdateCentralizationRuleForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.UpdateCentralizationRuleForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RuleArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWOADMNCentralizationRuleForOrganization (UpdateCentralizationRuleForOrganization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.UpdateCentralizationRuleForOrganizationResponse, UpdateCWOADMNCentralizationRuleForOrganizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Destination_Account = this.Destination_Account;
            context.BackupConfiguration_KmsKeyArn = this.BackupConfiguration_KmsKeyArn;
            context.BackupConfiguration_Region = this.BackupConfiguration_Region;
            context.LogsEncryptionConfiguration_EncryptionConflictResolutionStrategy = this.LogsEncryptionConfiguration_EncryptionConflictResolutionStrategy;
            context.LogsEncryptionConfiguration_EncryptionStrategy = this.LogsEncryptionConfiguration_EncryptionStrategy;
            context.LogsEncryptionConfiguration_KmsKeyArn = this.LogsEncryptionConfiguration_KmsKeyArn;
            context.Destination_Region = this.Destination_Region;
            #if MODULAR
            if (this.Destination_Region == null && ParameterWasBound(nameof(this.Destination_Region)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination_Region which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Source_Region != null)
            {
                context.Source_Region = new List<System.String>(this.Source_Region);
            }
            #if MODULAR
            if (this.Source_Region == null && ParameterWasBound(nameof(this.Source_Region)))
            {
                WriteWarning("You are passing $null as a value for parameter Source_Region which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Source_Scope = this.Source_Scope;
            context.SourceLogsConfiguration_EncryptedLogGroupStrategy = this.SourceLogsConfiguration_EncryptedLogGroupStrategy;
            context.SourceLogsConfiguration_LogGroupSelectionCriterion = this.SourceLogsConfiguration_LogGroupSelectionCriterion;
            context.RuleIdentifier = this.RuleIdentifier;
            #if MODULAR
            if (this.RuleIdentifier == null && ParameterWasBound(nameof(this.RuleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ObservabilityAdmin.Model.UpdateCentralizationRuleForOrganizationRequest();
            
            
             // populate Rule
            var requestRuleIsNull = true;
            request.Rule = new Amazon.ObservabilityAdmin.Model.CentralizationRule();
            Amazon.ObservabilityAdmin.Model.CentralizationRuleDestination requestRule_rule_Destination = null;
            
             // populate Destination
            var requestRule_rule_DestinationIsNull = true;
            requestRule_rule_Destination = new Amazon.ObservabilityAdmin.Model.CentralizationRuleDestination();
            System.String requestRule_rule_Destination_destination_Account = null;
            if (cmdletContext.Destination_Account != null)
            {
                requestRule_rule_Destination_destination_Account = cmdletContext.Destination_Account;
            }
            if (requestRule_rule_Destination_destination_Account != null)
            {
                requestRule_rule_Destination.Account = requestRule_rule_Destination_destination_Account;
                requestRule_rule_DestinationIsNull = false;
            }
            System.String requestRule_rule_Destination_destination_Region = null;
            if (cmdletContext.Destination_Region != null)
            {
                requestRule_rule_Destination_destination_Region = cmdletContext.Destination_Region;
            }
            if (requestRule_rule_Destination_destination_Region != null)
            {
                requestRule_rule_Destination.Region = requestRule_rule_Destination_destination_Region;
                requestRule_rule_DestinationIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.DestinationLogsConfiguration requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration = null;
            
             // populate DestinationLogsConfiguration
            var requestRule_rule_Destination_rule_Destination_DestinationLogsConfigurationIsNull = true;
            requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration = new Amazon.ObservabilityAdmin.Model.DestinationLogsConfiguration();
            Amazon.ObservabilityAdmin.Model.LogsBackupConfiguration requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration = null;
            
             // populate BackupConfiguration
            var requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfigurationIsNull = true;
            requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration = new Amazon.ObservabilityAdmin.Model.LogsBackupConfiguration();
            System.String requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration_backupConfiguration_KmsKeyArn = null;
            if (cmdletContext.BackupConfiguration_KmsKeyArn != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration_backupConfiguration_KmsKeyArn = cmdletContext.BackupConfiguration_KmsKeyArn;
            }
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration_backupConfiguration_KmsKeyArn != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration.KmsKeyArn = requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration_backupConfiguration_KmsKeyArn;
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfigurationIsNull = false;
            }
            System.String requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration_backupConfiguration_Region = null;
            if (cmdletContext.BackupConfiguration_Region != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration_backupConfiguration_Region = cmdletContext.BackupConfiguration_Region;
            }
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration_backupConfiguration_Region != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration.Region = requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration_backupConfiguration_Region;
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfigurationIsNull = false;
            }
             // determine if requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration should be set to null
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfigurationIsNull)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration = null;
            }
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration.BackupConfiguration = requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_BackupConfiguration;
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfigurationIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.LogsEncryptionConfiguration requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration = null;
            
             // populate LogsEncryptionConfiguration
            var requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfigurationIsNull = true;
            requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration = new Amazon.ObservabilityAdmin.Model.LogsEncryptionConfiguration();
            Amazon.ObservabilityAdmin.EncryptionConflictResolutionStrategy requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_EncryptionConflictResolutionStrategy = null;
            if (cmdletContext.LogsEncryptionConfiguration_EncryptionConflictResolutionStrategy != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_EncryptionConflictResolutionStrategy = cmdletContext.LogsEncryptionConfiguration_EncryptionConflictResolutionStrategy;
            }
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_EncryptionConflictResolutionStrategy != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration.EncryptionConflictResolutionStrategy = requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_EncryptionConflictResolutionStrategy;
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfigurationIsNull = false;
            }
            Amazon.ObservabilityAdmin.EncryptionStrategy requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_EncryptionStrategy = null;
            if (cmdletContext.LogsEncryptionConfiguration_EncryptionStrategy != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_EncryptionStrategy = cmdletContext.LogsEncryptionConfiguration_EncryptionStrategy;
            }
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_EncryptionStrategy != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration.EncryptionStrategy = requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_EncryptionStrategy;
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfigurationIsNull = false;
            }
            System.String requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.LogsEncryptionConfiguration_KmsKeyArn != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_KmsKeyArn = cmdletContext.LogsEncryptionConfiguration_KmsKeyArn;
            }
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_KmsKeyArn != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration.KmsKeyArn = requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration_logsEncryptionConfiguration_KmsKeyArn;
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfigurationIsNull = false;
            }
             // determine if requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration should be set to null
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfigurationIsNull)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration = null;
            }
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration != null)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration.LogsEncryptionConfiguration = requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration_rule_Destination_DestinationLogsConfiguration_LogsEncryptionConfiguration;
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfigurationIsNull = false;
            }
             // determine if requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration should be set to null
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfigurationIsNull)
            {
                requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration = null;
            }
            if (requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration != null)
            {
                requestRule_rule_Destination.DestinationLogsConfiguration = requestRule_rule_Destination_rule_Destination_DestinationLogsConfiguration;
                requestRule_rule_DestinationIsNull = false;
            }
             // determine if requestRule_rule_Destination should be set to null
            if (requestRule_rule_DestinationIsNull)
            {
                requestRule_rule_Destination = null;
            }
            if (requestRule_rule_Destination != null)
            {
                request.Rule.Destination = requestRule_rule_Destination;
                requestRuleIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.CentralizationRuleSource requestRule_rule_Source = null;
            
             // populate Source
            var requestRule_rule_SourceIsNull = true;
            requestRule_rule_Source = new Amazon.ObservabilityAdmin.Model.CentralizationRuleSource();
            List<System.String> requestRule_rule_Source_source_Region = null;
            if (cmdletContext.Source_Region != null)
            {
                requestRule_rule_Source_source_Region = cmdletContext.Source_Region;
            }
            if (requestRule_rule_Source_source_Region != null)
            {
                requestRule_rule_Source.Regions = requestRule_rule_Source_source_Region;
                requestRule_rule_SourceIsNull = false;
            }
            System.String requestRule_rule_Source_source_Scope = null;
            if (cmdletContext.Source_Scope != null)
            {
                requestRule_rule_Source_source_Scope = cmdletContext.Source_Scope;
            }
            if (requestRule_rule_Source_source_Scope != null)
            {
                requestRule_rule_Source.Scope = requestRule_rule_Source_source_Scope;
                requestRule_rule_SourceIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.SourceLogsConfiguration requestRule_rule_Source_rule_Source_SourceLogsConfiguration = null;
            
             // populate SourceLogsConfiguration
            var requestRule_rule_Source_rule_Source_SourceLogsConfigurationIsNull = true;
            requestRule_rule_Source_rule_Source_SourceLogsConfiguration = new Amazon.ObservabilityAdmin.Model.SourceLogsConfiguration();
            Amazon.ObservabilityAdmin.EncryptedLogGroupStrategy requestRule_rule_Source_rule_Source_SourceLogsConfiguration_sourceLogsConfiguration_EncryptedLogGroupStrategy = null;
            if (cmdletContext.SourceLogsConfiguration_EncryptedLogGroupStrategy != null)
            {
                requestRule_rule_Source_rule_Source_SourceLogsConfiguration_sourceLogsConfiguration_EncryptedLogGroupStrategy = cmdletContext.SourceLogsConfiguration_EncryptedLogGroupStrategy;
            }
            if (requestRule_rule_Source_rule_Source_SourceLogsConfiguration_sourceLogsConfiguration_EncryptedLogGroupStrategy != null)
            {
                requestRule_rule_Source_rule_Source_SourceLogsConfiguration.EncryptedLogGroupStrategy = requestRule_rule_Source_rule_Source_SourceLogsConfiguration_sourceLogsConfiguration_EncryptedLogGroupStrategy;
                requestRule_rule_Source_rule_Source_SourceLogsConfigurationIsNull = false;
            }
            System.String requestRule_rule_Source_rule_Source_SourceLogsConfiguration_sourceLogsConfiguration_LogGroupSelectionCriterion = null;
            if (cmdletContext.SourceLogsConfiguration_LogGroupSelectionCriterion != null)
            {
                requestRule_rule_Source_rule_Source_SourceLogsConfiguration_sourceLogsConfiguration_LogGroupSelectionCriterion = cmdletContext.SourceLogsConfiguration_LogGroupSelectionCriterion;
            }
            if (requestRule_rule_Source_rule_Source_SourceLogsConfiguration_sourceLogsConfiguration_LogGroupSelectionCriterion != null)
            {
                requestRule_rule_Source_rule_Source_SourceLogsConfiguration.LogGroupSelectionCriteria = requestRule_rule_Source_rule_Source_SourceLogsConfiguration_sourceLogsConfiguration_LogGroupSelectionCriterion;
                requestRule_rule_Source_rule_Source_SourceLogsConfigurationIsNull = false;
            }
             // determine if requestRule_rule_Source_rule_Source_SourceLogsConfiguration should be set to null
            if (requestRule_rule_Source_rule_Source_SourceLogsConfigurationIsNull)
            {
                requestRule_rule_Source_rule_Source_SourceLogsConfiguration = null;
            }
            if (requestRule_rule_Source_rule_Source_SourceLogsConfiguration != null)
            {
                requestRule_rule_Source.SourceLogsConfiguration = requestRule_rule_Source_rule_Source_SourceLogsConfiguration;
                requestRule_rule_SourceIsNull = false;
            }
             // determine if requestRule_rule_Source should be set to null
            if (requestRule_rule_SourceIsNull)
            {
                requestRule_rule_Source = null;
            }
            if (requestRule_rule_Source != null)
            {
                request.Rule.Source = requestRule_rule_Source;
                requestRuleIsNull = false;
            }
             // determine if request.Rule should be set to null
            if (requestRuleIsNull)
            {
                request.Rule = null;
            }
            if (cmdletContext.RuleIdentifier != null)
            {
                request.RuleIdentifier = cmdletContext.RuleIdentifier;
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
        
        private Amazon.ObservabilityAdmin.Model.UpdateCentralizationRuleForOrganizationResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.UpdateCentralizationRuleForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "UpdateCentralizationRuleForOrganization");
            try
            {
                #if DESKTOP
                return client.UpdateCentralizationRuleForOrganization(request);
                #elif CORECLR
                return client.UpdateCentralizationRuleForOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.String Destination_Account { get; set; }
            public System.String BackupConfiguration_KmsKeyArn { get; set; }
            public System.String BackupConfiguration_Region { get; set; }
            public Amazon.ObservabilityAdmin.EncryptionConflictResolutionStrategy LogsEncryptionConfiguration_EncryptionConflictResolutionStrategy { get; set; }
            public Amazon.ObservabilityAdmin.EncryptionStrategy LogsEncryptionConfiguration_EncryptionStrategy { get; set; }
            public System.String LogsEncryptionConfiguration_KmsKeyArn { get; set; }
            public System.String Destination_Region { get; set; }
            public List<System.String> Source_Region { get; set; }
            public System.String Source_Scope { get; set; }
            public Amazon.ObservabilityAdmin.EncryptedLogGroupStrategy SourceLogsConfiguration_EncryptedLogGroupStrategy { get; set; }
            public System.String SourceLogsConfiguration_LogGroupSelectionCriterion { get; set; }
            public System.String RuleIdentifier { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.UpdateCentralizationRuleForOrganizationResponse, UpdateCWOADMNCentralizationRuleForOrganizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RuleArn;
        }
        
    }
}
