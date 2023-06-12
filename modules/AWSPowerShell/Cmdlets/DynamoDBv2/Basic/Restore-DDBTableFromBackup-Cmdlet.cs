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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Creates a new table from an existing backup. Any number of users can execute up to
    /// 50 concurrent restores (any type of restore) in a given account. 
    /// 
    ///  
    /// <para>
    /// You can call <code>RestoreTableFromBackup</code> at a maximum rate of 10 times per
    /// second.
    /// </para><para>
    /// You must manually set up the following on the restored table:
    /// </para><ul><li><para>
    /// Auto scaling policies
    /// </para></li><li><para>
    /// IAM policies
    /// </para></li><li><para>
    /// Amazon CloudWatch metrics and alarms
    /// </para></li><li><para>
    /// Tags
    /// </para></li><li><para>
    /// Stream settings
    /// </para></li><li><para>
    /// Time to Live (TTL) settings
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Restore", "DDBTableFromBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB RestoreTableFromBackup API operation.", Operation = new[] {"RestoreTableFromBackup"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TableDescription or Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.TableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreDDBTableFromBackupCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter BackupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) associated with the backup.</para>
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
        public System.String BackupArn { get; set; }
        #endregion
        
        #region Parameter BillingModeOverride
        /// <summary>
        /// <para>
        /// <para>The billing mode of the restored table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.BillingMode")]
        public Amazon.DynamoDBv2.BillingMode BillingModeOverride { get; set; }
        #endregion
        
        #region Parameter SSESpecificationOverride_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether server-side encryption is done using an Amazon Web Services managed
        /// key or an Amazon Web Services owned key. If enabled (true), server-side encryption
        /// type is set to <code>KMS</code> and an Amazon Web Services managed key is used (KMS
        /// charges apply). If disabled (false) or not specified, server-side encryption is set
        /// to Amazon Web Services owned key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SSESpecificationOverride_Enabled { get; set; }
        #endregion
        
        #region Parameter GlobalSecondaryIndexOverride
        /// <summary>
        /// <para>
        /// <para>List of global secondary indexes for the restored table. The indexes provided should
        /// match existing secondary indexes. You can choose to exclude some or all of the indexes
        /// at the time of restore.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DynamoDBv2.Model.GlobalSecondaryIndex[] GlobalSecondaryIndexOverride { get; set; }
        #endregion
        
        #region Parameter SSESpecificationOverride_KMSMasterKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key that should be used for the KMS encryption. To specify a key, use its
        /// key ID, Amazon Resource Name (ARN), alias name, or alias ARN. Note that you should
        /// only provide this parameter if the key is different from the default DynamoDB key
        /// <code>alias/aws/dynamodb</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SSESpecificationOverride_KMSMasterKeyId { get; set; }
        #endregion
        
        #region Parameter LocalSecondaryIndexOverride
        /// <summary>
        /// <para>
        /// <para>List of local secondary indexes for the restored table. The indexes provided should
        /// match existing secondary indexes. You can choose to exclude some or all of the indexes
        /// at the time of restore.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DynamoDBv2.Model.LocalSecondaryIndex[] LocalSecondaryIndexOverride { get; set; }
        #endregion
        
        #region Parameter ProvisionedThroughputOverride_ReadCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The maximum number of strongly consistent reads consumed per second before DynamoDB
        /// returns a <code>ThrottlingException</code>. For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ProvisionedThroughput.html">Specifying
        /// Read and Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para><para>If read/write capacity mode is <code>PAY_PER_REQUEST</code> the value is set to 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisionedThroughputOverride_ReadCapacityUnits")]
        public System.Int64? ProvisionedThroughputOverride_ReadCapacityUnit { get; set; }
        #endregion
        
        #region Parameter SSESpecificationOverride_SSEType
        /// <summary>
        /// <para>
        /// <para>Server-side encryption type. The only supported value is:</para><ul><li><para><code>KMS</code> - Server-side encryption that uses Key Management Service. The key
        /// is stored in your account and is managed by KMS (KMS charges apply).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.SSEType")]
        public Amazon.DynamoDBv2.SSEType SSESpecificationOverride_SSEType { get; set; }
        #endregion
        
        #region Parameter TargetTableName
        /// <summary>
        /// <para>
        /// <para>The name of the new table to which the backup must be restored.</para>
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
        public System.String TargetTableName { get; set; }
        #endregion
        
        #region Parameter ProvisionedThroughputOverride_WriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The maximum number of writes consumed per second before DynamoDB returns a <code>ThrottlingException</code>.
        /// For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ProvisionedThroughput.html">Specifying
        /// Read and Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para><para>If read/write capacity mode is <code>PAY_PER_REQUEST</code> the value is set to 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisionedThroughputOverride_WriteCapacityUnits")]
        public System.Int64? ProvisionedThroughputOverride_WriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TableDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TableDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetTableName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetTableName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetTableName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetTableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-DDBTableFromBackup (RestoreTableFromBackup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse, RestoreDDBTableFromBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetTableName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupArn = this.BackupArn;
            #if MODULAR
            if (this.BackupArn == null && ParameterWasBound(nameof(this.BackupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BillingModeOverride = this.BillingModeOverride;
            if (this.GlobalSecondaryIndexOverride != null)
            {
                context.GlobalSecondaryIndexOverride = new List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndex>(this.GlobalSecondaryIndexOverride);
            }
            if (this.LocalSecondaryIndexOverride != null)
            {
                context.LocalSecondaryIndexOverride = new List<Amazon.DynamoDBv2.Model.LocalSecondaryIndex>(this.LocalSecondaryIndexOverride);
            }
            context.ProvisionedThroughputOverride_ReadCapacityUnit = this.ProvisionedThroughputOverride_ReadCapacityUnit;
            context.ProvisionedThroughputOverride_WriteCapacityUnit = this.ProvisionedThroughputOverride_WriteCapacityUnit;
            context.SSESpecificationOverride_Enabled = this.SSESpecificationOverride_Enabled;
            context.SSESpecificationOverride_KMSMasterKeyId = this.SSESpecificationOverride_KMSMasterKeyId;
            context.SSESpecificationOverride_SSEType = this.SSESpecificationOverride_SSEType;
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
            var request = new Amazon.DynamoDBv2.Model.RestoreTableFromBackupRequest();
            
            if (cmdletContext.BackupArn != null)
            {
                request.BackupArn = cmdletContext.BackupArn;
            }
            if (cmdletContext.BillingModeOverride != null)
            {
                request.BillingModeOverride = cmdletContext.BillingModeOverride;
            }
            if (cmdletContext.GlobalSecondaryIndexOverride != null)
            {
                request.GlobalSecondaryIndexOverride = cmdletContext.GlobalSecondaryIndexOverride;
            }
            if (cmdletContext.LocalSecondaryIndexOverride != null)
            {
                request.LocalSecondaryIndexOverride = cmdletContext.LocalSecondaryIndexOverride;
            }
            
             // populate ProvisionedThroughputOverride
            var requestProvisionedThroughputOverrideIsNull = true;
            request.ProvisionedThroughputOverride = new Amazon.DynamoDBv2.Model.ProvisionedThroughput();
            System.Int64? requestProvisionedThroughputOverride_provisionedThroughputOverride_ReadCapacityUnit = null;
            if (cmdletContext.ProvisionedThroughputOverride_ReadCapacityUnit != null)
            {
                requestProvisionedThroughputOverride_provisionedThroughputOverride_ReadCapacityUnit = cmdletContext.ProvisionedThroughputOverride_ReadCapacityUnit.Value;
            }
            if (requestProvisionedThroughputOverride_provisionedThroughputOverride_ReadCapacityUnit != null)
            {
                request.ProvisionedThroughputOverride.ReadCapacityUnits = requestProvisionedThroughputOverride_provisionedThroughputOverride_ReadCapacityUnit.Value;
                requestProvisionedThroughputOverrideIsNull = false;
            }
            System.Int64? requestProvisionedThroughputOverride_provisionedThroughputOverride_WriteCapacityUnit = null;
            if (cmdletContext.ProvisionedThroughputOverride_WriteCapacityUnit != null)
            {
                requestProvisionedThroughputOverride_provisionedThroughputOverride_WriteCapacityUnit = cmdletContext.ProvisionedThroughputOverride_WriteCapacityUnit.Value;
            }
            if (requestProvisionedThroughputOverride_provisionedThroughputOverride_WriteCapacityUnit != null)
            {
                request.ProvisionedThroughputOverride.WriteCapacityUnits = requestProvisionedThroughputOverride_provisionedThroughputOverride_WriteCapacityUnit.Value;
                requestProvisionedThroughputOverrideIsNull = false;
            }
             // determine if request.ProvisionedThroughputOverride should be set to null
            if (requestProvisionedThroughputOverrideIsNull)
            {
                request.ProvisionedThroughputOverride = null;
            }
            
             // populate SSESpecificationOverride
            var requestSSESpecificationOverrideIsNull = true;
            request.SSESpecificationOverride = new Amazon.DynamoDBv2.Model.SSESpecification();
            System.Boolean? requestSSESpecificationOverride_sSESpecificationOverride_Enabled = null;
            if (cmdletContext.SSESpecificationOverride_Enabled != null)
            {
                requestSSESpecificationOverride_sSESpecificationOverride_Enabled = cmdletContext.SSESpecificationOverride_Enabled.Value;
            }
            if (requestSSESpecificationOverride_sSESpecificationOverride_Enabled != null)
            {
                request.SSESpecificationOverride.Enabled = requestSSESpecificationOverride_sSESpecificationOverride_Enabled.Value;
                requestSSESpecificationOverrideIsNull = false;
            }
            System.String requestSSESpecificationOverride_sSESpecificationOverride_KMSMasterKeyId = null;
            if (cmdletContext.SSESpecificationOverride_KMSMasterKeyId != null)
            {
                requestSSESpecificationOverride_sSESpecificationOverride_KMSMasterKeyId = cmdletContext.SSESpecificationOverride_KMSMasterKeyId;
            }
            if (requestSSESpecificationOverride_sSESpecificationOverride_KMSMasterKeyId != null)
            {
                request.SSESpecificationOverride.KMSMasterKeyId = requestSSESpecificationOverride_sSESpecificationOverride_KMSMasterKeyId;
                requestSSESpecificationOverrideIsNull = false;
            }
            Amazon.DynamoDBv2.SSEType requestSSESpecificationOverride_sSESpecificationOverride_SSEType = null;
            if (cmdletContext.SSESpecificationOverride_SSEType != null)
            {
                requestSSESpecificationOverride_sSESpecificationOverride_SSEType = cmdletContext.SSESpecificationOverride_SSEType;
            }
            if (requestSSESpecificationOverride_sSESpecificationOverride_SSEType != null)
            {
                request.SSESpecificationOverride.SSEType = requestSSESpecificationOverride_sSESpecificationOverride_SSEType;
                requestSSESpecificationOverrideIsNull = false;
            }
             // determine if request.SSESpecificationOverride should be set to null
            if (requestSSESpecificationOverrideIsNull)
            {
                request.SSESpecificationOverride = null;
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
        
        private Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.RestoreTableFromBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "RestoreTableFromBackup");
            try
            {
                #if DESKTOP
                return client.RestoreTableFromBackup(request);
                #elif CORECLR
                return client.RestoreTableFromBackupAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupArn { get; set; }
            public Amazon.DynamoDBv2.BillingMode BillingModeOverride { get; set; }
            public List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndex> GlobalSecondaryIndexOverride { get; set; }
            public List<Amazon.DynamoDBv2.Model.LocalSecondaryIndex> LocalSecondaryIndexOverride { get; set; }
            public System.Int64? ProvisionedThroughputOverride_ReadCapacityUnit { get; set; }
            public System.Int64? ProvisionedThroughputOverride_WriteCapacityUnit { get; set; }
            public System.Boolean? SSESpecificationOverride_Enabled { get; set; }
            public System.String SSESpecificationOverride_KMSMasterKeyId { get; set; }
            public Amazon.DynamoDBv2.SSEType SSESpecificationOverride_SSEType { get; set; }
            public System.String TargetTableName { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse, RestoreDDBTableFromBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TableDescription;
        }
        
    }
}
