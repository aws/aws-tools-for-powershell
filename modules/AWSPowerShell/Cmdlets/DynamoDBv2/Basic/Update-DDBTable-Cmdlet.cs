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
    /// Modifies the provisioned throughput settings, global secondary indexes, or DynamoDB
    /// Streams settings for a given table.
    /// 
    ///  <important><para>
    /// This operation only applies to <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/globaltables.V2.html">Version
    /// 2019.11.21 (Current)</a> of global tables. 
    /// </para></important><para>
    /// You can only perform one of the following operations at once:
    /// </para><ul><li><para>
    /// Modify the provisioned throughput settings of the table.
    /// </para></li><li><para>
    /// Remove a global secondary index from the table.
    /// </para></li><li><para>
    /// Create a new global secondary index on the table. After the index begins backfilling,
    /// you can use <c>UpdateTable</c> to perform other operations.
    /// </para></li></ul><para><c>UpdateTable</c> is an asynchronous operation; while it's executing, the table
    /// status changes from <c>ACTIVE</c> to <c>UPDATING</c>. While it's <c>UPDATING</c>,
    /// you can't issue another <c>UpdateTable</c> request. When the table returns to the
    /// <c>ACTIVE</c> state, the <c>UpdateTable</c> operation is complete.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DDBTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB UpdateTable API operation.", Operation = new[] {"UpdateTable"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.UpdateTableResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TableDescription or Amazon.DynamoDBv2.Model.UpdateTableResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.TableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.UpdateTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDDBTableCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeDefinition
        /// <summary>
        /// <para>
        /// <para>An array of attributes that describe the key schema for the table and indexes. If
        /// you are adding a new global secondary index to the table, <c>AttributeDefinitions</c>
        /// must include the key element(s) of the new index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeDefinitions")]
        public Amazon.DynamoDBv2.Model.AttributeDefinition[] AttributeDefinition { get; set; }
        #endregion
        
        #region Parameter BillingMode
        /// <summary>
        /// <para>
        /// <para>Controls how you are charged for read and write throughput and how you manage capacity.
        /// When switching from pay-per-request to provisioned capacity, initial provisioned capacity
        /// values must be set. The initial provisioned capacity values are estimated based on
        /// the consumed read and write capacity of your table and global secondary indexes over
        /// the past 30 minutes.</para><ul><li><para><c>PROVISIONED</c> - We recommend using <c>PROVISIONED</c> for predictable workloads.
        /// <c>PROVISIONED</c> sets the billing mode to <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadWriteCapacityMode.html#HowItWorks.ProvisionedThroughput.Manual">Provisioned
        /// Mode</a>.</para></li><li><para><c>PAY_PER_REQUEST</c> - We recommend using <c>PAY_PER_REQUEST</c> for unpredictable
        /// workloads. <c>PAY_PER_REQUEST</c> sets the billing mode to <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadWriteCapacityMode.html#HowItWorks.OnDemand">On-Demand
        /// Mode</a>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.BillingMode")]
        public Amazon.DynamoDBv2.BillingMode BillingMode { get; set; }
        #endregion
        
        #region Parameter DeletionProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether deletion protection is to be enabled (true) or disabled (false)
        /// on the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter SSESpecification_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether server-side encryption is done using an Amazon Web Services managed
        /// key or an Amazon Web Services owned key. If enabled (true), server-side encryption
        /// type is set to <c>KMS</c> and an Amazon Web Services managed key is used (KMS charges
        /// apply). If disabled (false) or not specified, server-side encryption is set to Amazon
        /// Web Services owned key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SSESpecification_Enabled { get; set; }
        #endregion
        
        #region Parameter GlobalSecondaryIndexUpdate
        /// <summary>
        /// <para>
        /// <para>An array of one or more global secondary indexes for the table. For each index in
        /// the array, you can request one action:</para><ul><li><para><c>Create</c> - add a new global secondary index to the table.</para></li><li><para><c>Update</c> - modify the provisioned throughput settings of an existing global
        /// secondary index.</para></li><li><para><c>Delete</c> - remove a global secondary index from the table.</para></li></ul><para>You can create or delete only one global secondary index per <c>UpdateTable</c> operation.</para><para>For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/GSI.OnlineOps.html">Managing
        /// Global Secondary Indexes</a> in the <i>Amazon DynamoDB Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GlobalSecondaryIndexUpdates")]
        public Amazon.DynamoDBv2.Model.GlobalSecondaryIndexUpdate[] GlobalSecondaryIndexUpdate { get; set; }
        #endregion
        
        #region Parameter SSESpecification_KMSMasterKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key that should be used for the KMS encryption. To specify a key, use its
        /// key ID, Amazon Resource Name (ARN), alias name, or alias ARN. Note that you should
        /// only provide this parameter if the key is different from the default DynamoDB key
        /// <c>alias/aws/dynamodb</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SSESpecification_KMSMasterKeyId { get; set; }
        #endregion
        
        #region Parameter ReadCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum number of strongly consistent reads consumed per second before DynamoDB
        /// returns a <c>ThrottlingException</c>. For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ProvisionedThroughput.html">Specifying
        /// Read and Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para><para>If read/write capacity mode is <c>PAY_PER_REQUEST</c> the value is set to 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisionedThroughput_ReadCapacityUnits")]
        public System.Int64? ReadCapacity { get; set; }
        #endregion
        
        #region Parameter ReplicaUpdate
        /// <summary>
        /// <para>
        /// <para>A list of replica update actions (create, delete, or update) for the table.</para><note><para>This property only applies to <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/globaltables.V2.html">Version
        /// 2019.11.21 (Current)</a> of global tables. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplicaUpdates")]
        public Amazon.DynamoDBv2.Model.ReplicationGroupUpdate[] ReplicaUpdate { get; set; }
        #endregion
        
        #region Parameter SSESpecification_SSEType
        /// <summary>
        /// <para>
        /// <para>Server-side encryption type. The only supported value is:</para><ul><li><para><c>KMS</c> - Server-side encryption that uses Key Management Service. The key is
        /// stored in your account and is managed by KMS (KMS charges apply).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.SSEType")]
        public Amazon.DynamoDBv2.SSEType SSESpecification_SSEType { get; set; }
        #endregion
        
        #region Parameter StreamSpecification_StreamEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether DynamoDB Streams is enabled (true) or disabled (false) on the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StreamSpecification_StreamEnabled { get; set; }
        #endregion
        
        #region Parameter StreamSpecification_StreamViewType
        /// <summary>
        /// <para>
        /// <para> When an item in the table is modified, <c>StreamViewType</c> determines what information
        /// is written to the stream for this table. Valid values for <c>StreamViewType</c> are:</para><ul><li><para><c>KEYS_ONLY</c> - Only the key attributes of the modified item are written to the
        /// stream.</para></li><li><para><c>NEW_IMAGE</c> - The entire item, as it appears after it was modified, is written
        /// to the stream.</para></li><li><para><c>OLD_IMAGE</c> - The entire item, as it appeared before it was modified, is written
        /// to the stream.</para></li><li><para><c>NEW_AND_OLD_IMAGES</c> - Both the new and the old item images of the item are
        /// written to the stream.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.StreamViewType")]
        public Amazon.DynamoDBv2.StreamViewType StreamSpecification_StreamViewType { get; set; }
        #endregion
        
        #region Parameter TableClass
        /// <summary>
        /// <para>
        /// <para>The table class of the table to be updated. Valid values are <c>STANDARD</c> and <c>STANDARD_INFREQUENT_ACCESS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.TableClass")]
        public Amazon.DynamoDBv2.TableClass TableClass { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table to be updated. You can also provide the Amazon Resource Name
        /// (ARN) of the table in this parameter.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter WriteCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum number of writes consumed per second before DynamoDB returns a <c>ThrottlingException</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ProvisionedThroughput.html">Specifying
        /// Read and Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para><para>If read/write capacity mode is <c>PAY_PER_REQUEST</c> the value is set to 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisionedThroughput_WriteCapacityUnits")]
        public System.Int64? WriteCapacity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TableDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.UpdateTableResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.UpdateTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TableDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TableName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TableName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TableName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBTable (UpdateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.UpdateTableResponse, UpdateDDBTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TableName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AttributeDefinition != null)
            {
                context.AttributeDefinition = new List<Amazon.DynamoDBv2.Model.AttributeDefinition>(this.AttributeDefinition);
            }
            context.BillingMode = this.BillingMode;
            context.DeletionProtectionEnabled = this.DeletionProtectionEnabled;
            if (this.GlobalSecondaryIndexUpdate != null)
            {
                context.GlobalSecondaryIndexUpdate = new List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndexUpdate>(this.GlobalSecondaryIndexUpdate);
            }
            context.ReadCapacity = this.ReadCapacity;
            context.WriteCapacity = this.WriteCapacity;
            if (this.ReplicaUpdate != null)
            {
                context.ReplicaUpdate = new List<Amazon.DynamoDBv2.Model.ReplicationGroupUpdate>(this.ReplicaUpdate);
            }
            context.SSESpecification_Enabled = this.SSESpecification_Enabled;
            context.SSESpecification_KMSMasterKeyId = this.SSESpecification_KMSMasterKeyId;
            context.SSESpecification_SSEType = this.SSESpecification_SSEType;
            context.StreamSpecification_StreamEnabled = this.StreamSpecification_StreamEnabled;
            context.StreamSpecification_StreamViewType = this.StreamSpecification_StreamViewType;
            context.TableClass = this.TableClass;
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.UpdateTableRequest();
            
            if (cmdletContext.AttributeDefinition != null)
            {
                request.AttributeDefinitions = cmdletContext.AttributeDefinition;
            }
            if (cmdletContext.BillingMode != null)
            {
                request.BillingMode = cmdletContext.BillingMode;
            }
            if (cmdletContext.DeletionProtectionEnabled != null)
            {
                request.DeletionProtectionEnabled = cmdletContext.DeletionProtectionEnabled.Value;
            }
            if (cmdletContext.GlobalSecondaryIndexUpdate != null)
            {
                request.GlobalSecondaryIndexUpdates = cmdletContext.GlobalSecondaryIndexUpdate;
            }
            
             // populate ProvisionedThroughput
            var requestProvisionedThroughputIsNull = true;
            request.ProvisionedThroughput = new Amazon.DynamoDBv2.Model.ProvisionedThroughput();
            System.Int64? requestProvisionedThroughput_readCapacity = null;
            if (cmdletContext.ReadCapacity != null)
            {
                requestProvisionedThroughput_readCapacity = cmdletContext.ReadCapacity.Value;
            }
            if (requestProvisionedThroughput_readCapacity != null)
            {
                request.ProvisionedThroughput.ReadCapacityUnits = requestProvisionedThroughput_readCapacity.Value;
                requestProvisionedThroughputIsNull = false;
            }
            System.Int64? requestProvisionedThroughput_writeCapacity = null;
            if (cmdletContext.WriteCapacity != null)
            {
                requestProvisionedThroughput_writeCapacity = cmdletContext.WriteCapacity.Value;
            }
            if (requestProvisionedThroughput_writeCapacity != null)
            {
                request.ProvisionedThroughput.WriteCapacityUnits = requestProvisionedThroughput_writeCapacity.Value;
                requestProvisionedThroughputIsNull = false;
            }
             // determine if request.ProvisionedThroughput should be set to null
            if (requestProvisionedThroughputIsNull)
            {
                request.ProvisionedThroughput = null;
            }
            if (cmdletContext.ReplicaUpdate != null)
            {
                request.ReplicaUpdates = cmdletContext.ReplicaUpdate;
            }
            
             // populate SSESpecification
            var requestSSESpecificationIsNull = true;
            request.SSESpecification = new Amazon.DynamoDBv2.Model.SSESpecification();
            System.Boolean? requestSSESpecification_sSESpecification_Enabled = null;
            if (cmdletContext.SSESpecification_Enabled != null)
            {
                requestSSESpecification_sSESpecification_Enabled = cmdletContext.SSESpecification_Enabled.Value;
            }
            if (requestSSESpecification_sSESpecification_Enabled != null)
            {
                request.SSESpecification.Enabled = requestSSESpecification_sSESpecification_Enabled.Value;
                requestSSESpecificationIsNull = false;
            }
            System.String requestSSESpecification_sSESpecification_KMSMasterKeyId = null;
            if (cmdletContext.SSESpecification_KMSMasterKeyId != null)
            {
                requestSSESpecification_sSESpecification_KMSMasterKeyId = cmdletContext.SSESpecification_KMSMasterKeyId;
            }
            if (requestSSESpecification_sSESpecification_KMSMasterKeyId != null)
            {
                request.SSESpecification.KMSMasterKeyId = requestSSESpecification_sSESpecification_KMSMasterKeyId;
                requestSSESpecificationIsNull = false;
            }
            Amazon.DynamoDBv2.SSEType requestSSESpecification_sSESpecification_SSEType = null;
            if (cmdletContext.SSESpecification_SSEType != null)
            {
                requestSSESpecification_sSESpecification_SSEType = cmdletContext.SSESpecification_SSEType;
            }
            if (requestSSESpecification_sSESpecification_SSEType != null)
            {
                request.SSESpecification.SSEType = requestSSESpecification_sSESpecification_SSEType;
                requestSSESpecificationIsNull = false;
            }
             // determine if request.SSESpecification should be set to null
            if (requestSSESpecificationIsNull)
            {
                request.SSESpecification = null;
            }
            
             // populate StreamSpecification
            var requestStreamSpecificationIsNull = true;
            request.StreamSpecification = new Amazon.DynamoDBv2.Model.StreamSpecification();
            System.Boolean? requestStreamSpecification_streamSpecification_StreamEnabled = null;
            if (cmdletContext.StreamSpecification_StreamEnabled != null)
            {
                requestStreamSpecification_streamSpecification_StreamEnabled = cmdletContext.StreamSpecification_StreamEnabled.Value;
            }
            if (requestStreamSpecification_streamSpecification_StreamEnabled != null)
            {
                request.StreamSpecification.StreamEnabled = requestStreamSpecification_streamSpecification_StreamEnabled.Value;
                requestStreamSpecificationIsNull = false;
            }
            Amazon.DynamoDBv2.StreamViewType requestStreamSpecification_streamSpecification_StreamViewType = null;
            if (cmdletContext.StreamSpecification_StreamViewType != null)
            {
                requestStreamSpecification_streamSpecification_StreamViewType = cmdletContext.StreamSpecification_StreamViewType;
            }
            if (requestStreamSpecification_streamSpecification_StreamViewType != null)
            {
                request.StreamSpecification.StreamViewType = requestStreamSpecification_streamSpecification_StreamViewType;
                requestStreamSpecificationIsNull = false;
            }
             // determine if request.StreamSpecification should be set to null
            if (requestStreamSpecificationIsNull)
            {
                request.StreamSpecification = null;
            }
            if (cmdletContext.TableClass != null)
            {
                request.TableClass = cmdletContext.TableClass;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
        
        private Amazon.DynamoDBv2.Model.UpdateTableResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.UpdateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "UpdateTable");
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
            public List<Amazon.DynamoDBv2.Model.AttributeDefinition> AttributeDefinition { get; set; }
            public Amazon.DynamoDBv2.BillingMode BillingMode { get; set; }
            public System.Boolean? DeletionProtectionEnabled { get; set; }
            public List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndexUpdate> GlobalSecondaryIndexUpdate { get; set; }
            public System.Int64? ReadCapacity { get; set; }
            public System.Int64? WriteCapacity { get; set; }
            public List<Amazon.DynamoDBv2.Model.ReplicationGroupUpdate> ReplicaUpdate { get; set; }
            public System.Boolean? SSESpecification_Enabled { get; set; }
            public System.String SSESpecification_KMSMasterKeyId { get; set; }
            public Amazon.DynamoDBv2.SSEType SSESpecification_SSEType { get; set; }
            public System.Boolean? StreamSpecification_StreamEnabled { get; set; }
            public Amazon.DynamoDBv2.StreamViewType StreamSpecification_StreamViewType { get; set; }
            public Amazon.DynamoDBv2.TableClass TableClass { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.UpdateTableResponse, UpdateDDBTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TableDescription;
        }
        
    }
}
