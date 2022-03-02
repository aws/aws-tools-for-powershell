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
using Amazon.Keyspaces;
using Amazon.Keyspaces.Model;

namespace Amazon.PowerShell.Cmdlets.KS
{
    /// <summary>
    /// Restores the specified table to the specified point in time within the <code>earliest_restorable_timestamp</code>
    /// and the current time. For more information about restore points, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/PointInTimeRecovery_HowItWorks.html#howitworks_backup_window">
    /// Time window for PITR continuous backups</a> in the <i>Amazon Keyspaces Developer Guide</i>.
    /// 
    /// 
    ///  
    /// <para>
    ///  Any number of users can execute up to 4 concurrent restores (any type of restore)
    /// in a given account.
    /// </para><para>
    /// When you restore using point in time recovery, Amazon Keyspaces restores your source
    /// table's schema and data to the state based on the selected timestamp <code>(day:hour:minute:second)</code>
    /// to a new table. The Time to Live (TTL) settings are also restored to the state based
    /// on the selected timestamp.
    /// </para><para>
    /// In addition to the table's schema, data, and TTL settings, <code>RestoreTable</code>
    /// restores the capacity mode, encryption, and point-in-time recovery settings from the
    /// source table. Unlike the table's schema data and TTL settings, which are restored
    /// based on the selected timestamp, these settings are always restored based on the table's
    /// settings as of the current time or when the table was deleted.
    /// </para><para>
    /// You can also overwrite these settings during restore:
    /// </para><ul><li><para>
    /// Read/write capacity mode
    /// </para></li><li><para>
    /// Provisioned throughput capacity settings
    /// </para></li><li><para>
    /// Point-in-time (PITR) settings
    /// </para></li><li><para>
    /// Tags
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/PointInTimeRecovery_HowItWorks.html#howitworks_backup_settings">PITR
    /// restore settings</a> in the <i>Amazon Keyspaces Developer Guide</i>.
    /// </para><para>
    /// The following settings are not restored, and you must configure them manually for
    /// the new table. 
    /// </para><ul><li><para>
    /// Automatic scaling policies (for tables that use provisioned capacity mode)
    /// </para></li><li><para>
    /// Identity and Access Management (IAM) policies
    /// </para></li><li><para>
    /// Amazon CloudWatch metrics and alarms
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Restore", "KSTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Keyspaces RestoreTable API operation.", Operation = new[] {"RestoreTable"}, SelectReturnType = typeof(Amazon.Keyspaces.Model.RestoreTableResponse))]
    [AWSCmdletOutput("System.String or Amazon.Keyspaces.Model.RestoreTableResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Keyspaces.Model.RestoreTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreKSTableCmdlet : AmazonKeyspacesClientCmdlet, IExecutor
    {
        
        #region Parameter EncryptionSpecificationOverride_KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer managed KMS key, for example <code>kms_key_identifier:ARN</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSpecificationOverride_KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter CapacitySpecificationOverride_ReadCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The throughput capacity specified for <code>read</code> operations defined in <code>read
        /// capacity units</code><code>(RCUs)</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacitySpecificationOverride_ReadCapacityUnits")]
        public System.Int64? CapacitySpecificationOverride_ReadCapacityUnit { get; set; }
        #endregion
        
        #region Parameter RestoreTimestamp
        /// <summary>
        /// <para>
        /// <para>The restore timestamp in ISO 8601 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RestoreTimestamp { get; set; }
        #endregion
        
        #region Parameter SourceKeyspaceName
        /// <summary>
        /// <para>
        /// <para>The keyspace name of the source table.</para>
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
        public System.String SourceKeyspaceName { get; set; }
        #endregion
        
        #region Parameter SourceTableName
        /// <summary>
        /// <para>
        /// <para>The name of the source table.</para>
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
        public System.String SourceTableName { get; set; }
        #endregion
        
        #region Parameter PointInTimeRecoveryOverride_Status
        /// <summary>
        /// <para>
        /// <para>The options are:</para><ul><li><para><code>ENABLED</code></para></li><li><para><code>DISABLED</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.PointInTimeRecoveryStatus")]
        public Amazon.Keyspaces.PointInTimeRecoveryStatus PointInTimeRecoveryOverride_Status { get; set; }
        #endregion
        
        #region Parameter TagsOverride
        /// <summary>
        /// <para>
        /// <para>A list of key-value pair tags to be attached to the restored table. </para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/tagging-keyspaces.html">Adding
        /// tags and labels to Amazon Keyspaces resources</a> in the <i>Amazon Keyspaces Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Keyspaces.Model.Tag[] TagsOverride { get; set; }
        #endregion
        
        #region Parameter TargetKeyspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the target keyspace.</para>
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
        public System.String TargetKeyspaceName { get; set; }
        #endregion
        
        #region Parameter TargetTableName
        /// <summary>
        /// <para>
        /// <para>The name of the target table.</para>
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
        public System.String TargetTableName { get; set; }
        #endregion
        
        #region Parameter CapacitySpecificationOverride_ThroughputMode
        /// <summary>
        /// <para>
        /// <para>The read/write throughput capacity mode for a table. The options are:</para><ul><li><para><code>throughputMode:PAY_PER_REQUEST</code> and </para></li><li><para><code>throughputMode:PROVISIONED</code>. The provisioned capacity mode requires <code>readCapacityUnits</code>
        /// and <code>writeCapacityUnits</code> as inputs. </para></li></ul><para>The default is <code>throughput_mode:PAY_PER_REQUEST</code>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/ReadWriteCapacityMode.html">Read/write
        /// capacity modes</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.ThroughputMode")]
        public Amazon.Keyspaces.ThroughputMode CapacitySpecificationOverride_ThroughputMode { get; set; }
        #endregion
        
        #region Parameter EncryptionSpecificationOverride_Type
        /// <summary>
        /// <para>
        /// <para> The encryption option specified for the table. You can choose one of the following
        /// KMS keys (KMS keys):</para><ul><li><para><code>type:AWS_OWNED_KMS_KEY</code> - This key is owned by Amazon Keyspaces. </para></li><li><para><code>type:CUSTOMER_MANAGED_KMS_KEY</code> - This key is stored in your account and
        /// is created, owned, and managed by you. This option requires the <code>kms_key_identifier</code>
        /// of the KMS key in Amazon Resource Name (ARN) format as input. </para></li></ul><para>The default is <code>type:AWS_OWNED_KMS_KEY</code>. </para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/EncryptionAtRest.html">Encryption
        /// at rest</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.EncryptionType")]
        public Amazon.Keyspaces.EncryptionType EncryptionSpecificationOverride_Type { get; set; }
        #endregion
        
        #region Parameter CapacitySpecificationOverride_WriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The throughput capacity specified for <code>write</code> operations defined in <code>write
        /// capacity units</code><code>(WCUs)</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacitySpecificationOverride_WriteCapacityUnits")]
        public System.Int64? CapacitySpecificationOverride_WriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RestoredTableARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Keyspaces.Model.RestoreTableResponse).
        /// Specifying the name of a property of type Amazon.Keyspaces.Model.RestoreTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RestoredTableARN";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-KSTable (RestoreTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Keyspaces.Model.RestoreTableResponse, RestoreKSTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacitySpecificationOverride_ReadCapacityUnit = this.CapacitySpecificationOverride_ReadCapacityUnit;
            context.CapacitySpecificationOverride_ThroughputMode = this.CapacitySpecificationOverride_ThroughputMode;
            context.CapacitySpecificationOverride_WriteCapacityUnit = this.CapacitySpecificationOverride_WriteCapacityUnit;
            context.EncryptionSpecificationOverride_KmsKeyIdentifier = this.EncryptionSpecificationOverride_KmsKeyIdentifier;
            context.EncryptionSpecificationOverride_Type = this.EncryptionSpecificationOverride_Type;
            context.PointInTimeRecoveryOverride_Status = this.PointInTimeRecoveryOverride_Status;
            context.RestoreTimestamp = this.RestoreTimestamp;
            context.SourceKeyspaceName = this.SourceKeyspaceName;
            #if MODULAR
            if (this.SourceKeyspaceName == null && ParameterWasBound(nameof(this.SourceKeyspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceKeyspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceTableName = this.SourceTableName;
            #if MODULAR
            if (this.SourceTableName == null && ParameterWasBound(nameof(this.SourceTableName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceTableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagsOverride != null)
            {
                context.TagsOverride = new List<Amazon.Keyspaces.Model.Tag>(this.TagsOverride);
            }
            context.TargetKeyspaceName = this.TargetKeyspaceName;
            #if MODULAR
            if (this.TargetKeyspaceName == null && ParameterWasBound(nameof(this.TargetKeyspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetKeyspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetTableName = this.TargetTableName;
            #if MODULAR
            if (this.TargetTableName == null && ParameterWasBound(nameof(this.TargetTableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetTableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Keyspaces.Model.RestoreTableRequest();
            
            
             // populate CapacitySpecificationOverride
            var requestCapacitySpecificationOverrideIsNull = true;
            request.CapacitySpecificationOverride = new Amazon.Keyspaces.Model.CapacitySpecification();
            System.Int64? requestCapacitySpecificationOverride_capacitySpecificationOverride_ReadCapacityUnit = null;
            if (cmdletContext.CapacitySpecificationOverride_ReadCapacityUnit != null)
            {
                requestCapacitySpecificationOverride_capacitySpecificationOverride_ReadCapacityUnit = cmdletContext.CapacitySpecificationOverride_ReadCapacityUnit.Value;
            }
            if (requestCapacitySpecificationOverride_capacitySpecificationOverride_ReadCapacityUnit != null)
            {
                request.CapacitySpecificationOverride.ReadCapacityUnits = requestCapacitySpecificationOverride_capacitySpecificationOverride_ReadCapacityUnit.Value;
                requestCapacitySpecificationOverrideIsNull = false;
            }
            Amazon.Keyspaces.ThroughputMode requestCapacitySpecificationOverride_capacitySpecificationOverride_ThroughputMode = null;
            if (cmdletContext.CapacitySpecificationOverride_ThroughputMode != null)
            {
                requestCapacitySpecificationOverride_capacitySpecificationOverride_ThroughputMode = cmdletContext.CapacitySpecificationOverride_ThroughputMode;
            }
            if (requestCapacitySpecificationOverride_capacitySpecificationOverride_ThroughputMode != null)
            {
                request.CapacitySpecificationOverride.ThroughputMode = requestCapacitySpecificationOverride_capacitySpecificationOverride_ThroughputMode;
                requestCapacitySpecificationOverrideIsNull = false;
            }
            System.Int64? requestCapacitySpecificationOverride_capacitySpecificationOverride_WriteCapacityUnit = null;
            if (cmdletContext.CapacitySpecificationOverride_WriteCapacityUnit != null)
            {
                requestCapacitySpecificationOverride_capacitySpecificationOverride_WriteCapacityUnit = cmdletContext.CapacitySpecificationOverride_WriteCapacityUnit.Value;
            }
            if (requestCapacitySpecificationOverride_capacitySpecificationOverride_WriteCapacityUnit != null)
            {
                request.CapacitySpecificationOverride.WriteCapacityUnits = requestCapacitySpecificationOverride_capacitySpecificationOverride_WriteCapacityUnit.Value;
                requestCapacitySpecificationOverrideIsNull = false;
            }
             // determine if request.CapacitySpecificationOverride should be set to null
            if (requestCapacitySpecificationOverrideIsNull)
            {
                request.CapacitySpecificationOverride = null;
            }
            
             // populate EncryptionSpecificationOverride
            var requestEncryptionSpecificationOverrideIsNull = true;
            request.EncryptionSpecificationOverride = new Amazon.Keyspaces.Model.EncryptionSpecification();
            System.String requestEncryptionSpecificationOverride_encryptionSpecificationOverride_KmsKeyIdentifier = null;
            if (cmdletContext.EncryptionSpecificationOverride_KmsKeyIdentifier != null)
            {
                requestEncryptionSpecificationOverride_encryptionSpecificationOverride_KmsKeyIdentifier = cmdletContext.EncryptionSpecificationOverride_KmsKeyIdentifier;
            }
            if (requestEncryptionSpecificationOverride_encryptionSpecificationOverride_KmsKeyIdentifier != null)
            {
                request.EncryptionSpecificationOverride.KmsKeyIdentifier = requestEncryptionSpecificationOverride_encryptionSpecificationOverride_KmsKeyIdentifier;
                requestEncryptionSpecificationOverrideIsNull = false;
            }
            Amazon.Keyspaces.EncryptionType requestEncryptionSpecificationOverride_encryptionSpecificationOverride_Type = null;
            if (cmdletContext.EncryptionSpecificationOverride_Type != null)
            {
                requestEncryptionSpecificationOverride_encryptionSpecificationOverride_Type = cmdletContext.EncryptionSpecificationOverride_Type;
            }
            if (requestEncryptionSpecificationOverride_encryptionSpecificationOverride_Type != null)
            {
                request.EncryptionSpecificationOverride.Type = requestEncryptionSpecificationOverride_encryptionSpecificationOverride_Type;
                requestEncryptionSpecificationOverrideIsNull = false;
            }
             // determine if request.EncryptionSpecificationOverride should be set to null
            if (requestEncryptionSpecificationOverrideIsNull)
            {
                request.EncryptionSpecificationOverride = null;
            }
            
             // populate PointInTimeRecoveryOverride
            var requestPointInTimeRecoveryOverrideIsNull = true;
            request.PointInTimeRecoveryOverride = new Amazon.Keyspaces.Model.PointInTimeRecovery();
            Amazon.Keyspaces.PointInTimeRecoveryStatus requestPointInTimeRecoveryOverride_pointInTimeRecoveryOverride_Status = null;
            if (cmdletContext.PointInTimeRecoveryOverride_Status != null)
            {
                requestPointInTimeRecoveryOverride_pointInTimeRecoveryOverride_Status = cmdletContext.PointInTimeRecoveryOverride_Status;
            }
            if (requestPointInTimeRecoveryOverride_pointInTimeRecoveryOverride_Status != null)
            {
                request.PointInTimeRecoveryOverride.Status = requestPointInTimeRecoveryOverride_pointInTimeRecoveryOverride_Status;
                requestPointInTimeRecoveryOverrideIsNull = false;
            }
             // determine if request.PointInTimeRecoveryOverride should be set to null
            if (requestPointInTimeRecoveryOverrideIsNull)
            {
                request.PointInTimeRecoveryOverride = null;
            }
            if (cmdletContext.RestoreTimestamp != null)
            {
                request.RestoreTimestamp = cmdletContext.RestoreTimestamp.Value;
            }
            if (cmdletContext.SourceKeyspaceName != null)
            {
                request.SourceKeyspaceName = cmdletContext.SourceKeyspaceName;
            }
            if (cmdletContext.SourceTableName != null)
            {
                request.SourceTableName = cmdletContext.SourceTableName;
            }
            if (cmdletContext.TagsOverride != null)
            {
                request.TagsOverride = cmdletContext.TagsOverride;
            }
            if (cmdletContext.TargetKeyspaceName != null)
            {
                request.TargetKeyspaceName = cmdletContext.TargetKeyspaceName;
            }
            if (cmdletContext.TargetTableName != null)
            {
                request.TargetTableName = cmdletContext.TargetTableName;
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
        
        private Amazon.Keyspaces.Model.RestoreTableResponse CallAWSServiceOperation(IAmazonKeyspaces client, Amazon.Keyspaces.Model.RestoreTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces", "RestoreTable");
            try
            {
                #if DESKTOP
                return client.RestoreTable(request);
                #elif CORECLR
                return client.RestoreTableAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? CapacitySpecificationOverride_ReadCapacityUnit { get; set; }
            public Amazon.Keyspaces.ThroughputMode CapacitySpecificationOverride_ThroughputMode { get; set; }
            public System.Int64? CapacitySpecificationOverride_WriteCapacityUnit { get; set; }
            public System.String EncryptionSpecificationOverride_KmsKeyIdentifier { get; set; }
            public Amazon.Keyspaces.EncryptionType EncryptionSpecificationOverride_Type { get; set; }
            public Amazon.Keyspaces.PointInTimeRecoveryStatus PointInTimeRecoveryOverride_Status { get; set; }
            public System.DateTime? RestoreTimestamp { get; set; }
            public System.String SourceKeyspaceName { get; set; }
            public System.String SourceTableName { get; set; }
            public List<Amazon.Keyspaces.Model.Tag> TagsOverride { get; set; }
            public System.String TargetKeyspaceName { get; set; }
            public System.String TargetTableName { get; set; }
            public System.Func<Amazon.Keyspaces.Model.RestoreTableResponse, RestoreKSTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RestoredTableARN;
        }
        
    }
}
