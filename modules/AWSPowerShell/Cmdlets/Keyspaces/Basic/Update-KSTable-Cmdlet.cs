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
    /// Adds new columns to the table or updates one of the table's settings, for example
    /// capacity mode, encryption, point-in-time recovery, or ttl settings. Note that you
    /// can only update one specific table setting per update operation.
    /// </summary>
    [Cmdlet("Update", "KSTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Keyspaces UpdateTable API operation.", Operation = new[] {"UpdateTable"}, SelectReturnType = typeof(Amazon.Keyspaces.Model.UpdateTableResponse))]
    [AWSCmdletOutput("System.String or Amazon.Keyspaces.Model.UpdateTableResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Keyspaces.Model.UpdateTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKSTableCmdlet : AmazonKeyspacesClientCmdlet, IExecutor
    {
        
        #region Parameter AddColumn
        /// <summary>
        /// <para>
        /// <para>For each column to be added to the specified table:</para><para>• <code>name</code> - The name of the column.</para><para>• <code>type</code> - An Amazon Keyspaces data type. For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/cql.elements.html#cql.data-types">Data
        /// types</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddColumns")]
        public Amazon.Keyspaces.Model.ColumnDefinition[] AddColumn { get; set; }
        #endregion
        
        #region Parameter DefaultTimeToLive
        /// <summary>
        /// <para>
        /// <para>The default Time to Live setting in seconds for the table.</para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/TTL-how-it-works.html#ttl-howitworks_default_ttl">Setting
        /// the default TTL value for a table</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultTimeToLive { get; set; }
        #endregion
        
        #region Parameter KeyspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the keyspace the specified table is stored in.</para>
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
        public System.String KeyspaceName { get; set; }
        #endregion
        
        #region Parameter EncryptionSpecification_KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer managed KMS key, for example <code>kms_key_identifier:ARN</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSpecification_KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter CapacitySpecification_ReadCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The throughput capacity specified for <code>read</code> operations defined in <code>read
        /// capacity units</code><code>(RCUs)</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacitySpecification_ReadCapacityUnits")]
        public System.Int64? CapacitySpecification_ReadCapacityUnit { get; set; }
        #endregion
        
        #region Parameter PointInTimeRecovery_Status
        /// <summary>
        /// <para>
        /// <para>The options are:</para><para>• <code>ENABLED</code></para><para>• <code>DISABLED</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.PointInTimeRecoveryStatus")]
        public Amazon.Keyspaces.PointInTimeRecoveryStatus PointInTimeRecovery_Status { get; set; }
        #endregion
        
        #region Parameter Ttl_Status
        /// <summary>
        /// <para>
        /// <para>Shows how to enable custom Time to Live (TTL) settings for the specified table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.TimeToLiveStatus")]
        public Amazon.Keyspaces.TimeToLiveStatus Ttl_Status { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter CapacitySpecification_ThroughputMode
        /// <summary>
        /// <para>
        /// <para>The read/write throughput capacity mode for a table. The options are:</para><para>• <code>throughputMode:PAY_PER_REQUEST</code> and </para><para>• <code>throughputMode:PROVISIONED</code> - Provisioned capacity mode requires <code>readCapacityUnits</code>
        /// and <code>writeCapacityUnits</code> as input.</para><para>The default is <code>throughput_mode:PAY_PER_REQUEST</code>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/ReadWriteCapacityMode.html">Read/write
        /// capacity modes</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.ThroughputMode")]
        public Amazon.Keyspaces.ThroughputMode CapacitySpecification_ThroughputMode { get; set; }
        #endregion
        
        #region Parameter EncryptionSpecification_Type
        /// <summary>
        /// <para>
        /// <para>The encryption option specified for the table. You can choose one of the following
        /// KMS keys (KMS keys):</para><para>• <code>type:AWS_OWNED_KMS_KEY</code> - This key is owned by Amazon Keyspaces. </para><para>• <code>type:CUSTOMER_MANAGED_KMS_KEY</code> - This key is stored in your account
        /// and is created, owned, and managed by you. This option requires the <code>kms_key_identifier</code>
        /// of the KMS key in Amazon Resource Name (ARN) format as input. </para><para>The default is <code>type:AWS_OWNED_KMS_KEY</code>. </para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/EncryptionAtRest.html">Encryption
        /// at rest</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.EncryptionType")]
        public Amazon.Keyspaces.EncryptionType EncryptionSpecification_Type { get; set; }
        #endregion
        
        #region Parameter CapacitySpecification_WriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The throughput capacity specified for <code>write</code> operations defined in <code>write
        /// capacity units</code><code>(WCUs)</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacitySpecification_WriteCapacityUnits")]
        public System.Int64? CapacitySpecification_WriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Keyspaces.Model.UpdateTableResponse).
        /// Specifying the name of a property of type Amazon.Keyspaces.Model.UpdateTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KSTable (UpdateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Keyspaces.Model.UpdateTableResponse, UpdateKSTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddColumn != null)
            {
                context.AddColumn = new List<Amazon.Keyspaces.Model.ColumnDefinition>(this.AddColumn);
            }
            context.CapacitySpecification_ReadCapacityUnit = this.CapacitySpecification_ReadCapacityUnit;
            context.CapacitySpecification_ThroughputMode = this.CapacitySpecification_ThroughputMode;
            context.CapacitySpecification_WriteCapacityUnit = this.CapacitySpecification_WriteCapacityUnit;
            context.DefaultTimeToLive = this.DefaultTimeToLive;
            context.EncryptionSpecification_KmsKeyIdentifier = this.EncryptionSpecification_KmsKeyIdentifier;
            context.EncryptionSpecification_Type = this.EncryptionSpecification_Type;
            context.KeyspaceName = this.KeyspaceName;
            #if MODULAR
            if (this.KeyspaceName == null && ParameterWasBound(nameof(this.KeyspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PointInTimeRecovery_Status = this.PointInTimeRecovery_Status;
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Ttl_Status = this.Ttl_Status;
            
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
            var request = new Amazon.Keyspaces.Model.UpdateTableRequest();
            
            if (cmdletContext.AddColumn != null)
            {
                request.AddColumns = cmdletContext.AddColumn;
            }
            
             // populate CapacitySpecification
            var requestCapacitySpecificationIsNull = true;
            request.CapacitySpecification = new Amazon.Keyspaces.Model.CapacitySpecification();
            System.Int64? requestCapacitySpecification_capacitySpecification_ReadCapacityUnit = null;
            if (cmdletContext.CapacitySpecification_ReadCapacityUnit != null)
            {
                requestCapacitySpecification_capacitySpecification_ReadCapacityUnit = cmdletContext.CapacitySpecification_ReadCapacityUnit.Value;
            }
            if (requestCapacitySpecification_capacitySpecification_ReadCapacityUnit != null)
            {
                request.CapacitySpecification.ReadCapacityUnits = requestCapacitySpecification_capacitySpecification_ReadCapacityUnit.Value;
                requestCapacitySpecificationIsNull = false;
            }
            Amazon.Keyspaces.ThroughputMode requestCapacitySpecification_capacitySpecification_ThroughputMode = null;
            if (cmdletContext.CapacitySpecification_ThroughputMode != null)
            {
                requestCapacitySpecification_capacitySpecification_ThroughputMode = cmdletContext.CapacitySpecification_ThroughputMode;
            }
            if (requestCapacitySpecification_capacitySpecification_ThroughputMode != null)
            {
                request.CapacitySpecification.ThroughputMode = requestCapacitySpecification_capacitySpecification_ThroughputMode;
                requestCapacitySpecificationIsNull = false;
            }
            System.Int64? requestCapacitySpecification_capacitySpecification_WriteCapacityUnit = null;
            if (cmdletContext.CapacitySpecification_WriteCapacityUnit != null)
            {
                requestCapacitySpecification_capacitySpecification_WriteCapacityUnit = cmdletContext.CapacitySpecification_WriteCapacityUnit.Value;
            }
            if (requestCapacitySpecification_capacitySpecification_WriteCapacityUnit != null)
            {
                request.CapacitySpecification.WriteCapacityUnits = requestCapacitySpecification_capacitySpecification_WriteCapacityUnit.Value;
                requestCapacitySpecificationIsNull = false;
            }
             // determine if request.CapacitySpecification should be set to null
            if (requestCapacitySpecificationIsNull)
            {
                request.CapacitySpecification = null;
            }
            if (cmdletContext.DefaultTimeToLive != null)
            {
                request.DefaultTimeToLive = cmdletContext.DefaultTimeToLive.Value;
            }
            
             // populate EncryptionSpecification
            var requestEncryptionSpecificationIsNull = true;
            request.EncryptionSpecification = new Amazon.Keyspaces.Model.EncryptionSpecification();
            System.String requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier = null;
            if (cmdletContext.EncryptionSpecification_KmsKeyIdentifier != null)
            {
                requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier = cmdletContext.EncryptionSpecification_KmsKeyIdentifier;
            }
            if (requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier != null)
            {
                request.EncryptionSpecification.KmsKeyIdentifier = requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier;
                requestEncryptionSpecificationIsNull = false;
            }
            Amazon.Keyspaces.EncryptionType requestEncryptionSpecification_encryptionSpecification_Type = null;
            if (cmdletContext.EncryptionSpecification_Type != null)
            {
                requestEncryptionSpecification_encryptionSpecification_Type = cmdletContext.EncryptionSpecification_Type;
            }
            if (requestEncryptionSpecification_encryptionSpecification_Type != null)
            {
                request.EncryptionSpecification.Type = requestEncryptionSpecification_encryptionSpecification_Type;
                requestEncryptionSpecificationIsNull = false;
            }
             // determine if request.EncryptionSpecification should be set to null
            if (requestEncryptionSpecificationIsNull)
            {
                request.EncryptionSpecification = null;
            }
            if (cmdletContext.KeyspaceName != null)
            {
                request.KeyspaceName = cmdletContext.KeyspaceName;
            }
            
             // populate PointInTimeRecovery
            var requestPointInTimeRecoveryIsNull = true;
            request.PointInTimeRecovery = new Amazon.Keyspaces.Model.PointInTimeRecovery();
            Amazon.Keyspaces.PointInTimeRecoveryStatus requestPointInTimeRecovery_pointInTimeRecovery_Status = null;
            if (cmdletContext.PointInTimeRecovery_Status != null)
            {
                requestPointInTimeRecovery_pointInTimeRecovery_Status = cmdletContext.PointInTimeRecovery_Status;
            }
            if (requestPointInTimeRecovery_pointInTimeRecovery_Status != null)
            {
                request.PointInTimeRecovery.Status = requestPointInTimeRecovery_pointInTimeRecovery_Status;
                requestPointInTimeRecoveryIsNull = false;
            }
             // determine if request.PointInTimeRecovery should be set to null
            if (requestPointInTimeRecoveryIsNull)
            {
                request.PointInTimeRecovery = null;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
             // populate Ttl
            var requestTtlIsNull = true;
            request.Ttl = new Amazon.Keyspaces.Model.TimeToLive();
            Amazon.Keyspaces.TimeToLiveStatus requestTtl_ttl_Status = null;
            if (cmdletContext.Ttl_Status != null)
            {
                requestTtl_ttl_Status = cmdletContext.Ttl_Status;
            }
            if (requestTtl_ttl_Status != null)
            {
                request.Ttl.Status = requestTtl_ttl_Status;
                requestTtlIsNull = false;
            }
             // determine if request.Ttl should be set to null
            if (requestTtlIsNull)
            {
                request.Ttl = null;
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
        
        private Amazon.Keyspaces.Model.UpdateTableResponse CallAWSServiceOperation(IAmazonKeyspaces client, Amazon.Keyspaces.Model.UpdateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces", "UpdateTable");
            try
            {
                #if DESKTOP
                return client.UpdateTable(request);
                #elif CORECLR
                return client.UpdateTableAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Keyspaces.Model.ColumnDefinition> AddColumn { get; set; }
            public System.Int64? CapacitySpecification_ReadCapacityUnit { get; set; }
            public Amazon.Keyspaces.ThroughputMode CapacitySpecification_ThroughputMode { get; set; }
            public System.Int64? CapacitySpecification_WriteCapacityUnit { get; set; }
            public System.Int32? DefaultTimeToLive { get; set; }
            public System.String EncryptionSpecification_KmsKeyIdentifier { get; set; }
            public Amazon.Keyspaces.EncryptionType EncryptionSpecification_Type { get; set; }
            public System.String KeyspaceName { get; set; }
            public Amazon.Keyspaces.PointInTimeRecoveryStatus PointInTimeRecovery_Status { get; set; }
            public System.String TableName { get; set; }
            public Amazon.Keyspaces.TimeToLiveStatus Ttl_Status { get; set; }
            public System.Func<Amazon.Keyspaces.Model.UpdateTableResponse, UpdateKSTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceArn;
        }
        
    }
}
