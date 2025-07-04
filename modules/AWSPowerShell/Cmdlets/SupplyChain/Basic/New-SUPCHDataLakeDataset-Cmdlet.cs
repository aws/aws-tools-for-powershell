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
using System.Threading;
using Amazon.SupplyChain;
using Amazon.SupplyChain.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SUPCH
{
    /// <summary>
    /// Enables you to programmatically create an Amazon Web Services Supply Chain data lake
    /// dataset. Developers can create the datasets using their pre-defined or custom schema
    /// for a given instance ID, namespace, and dataset name.
    /// </summary>
    [Cmdlet("New", "SUPCHDataLakeDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SupplyChain.Model.DataLakeDataset")]
    [AWSCmdlet("Calls the AWS Supply Chain CreateDataLakeDataset API operation.", Operation = new[] {"CreateDataLakeDataset"}, SelectReturnType = typeof(Amazon.SupplyChain.Model.CreateDataLakeDatasetResponse))]
    [AWSCmdletOutput("Amazon.SupplyChain.Model.DataLakeDataset or Amazon.SupplyChain.Model.CreateDataLakeDatasetResponse",
        "This cmdlet returns an Amazon.SupplyChain.Model.DataLakeDataset object.",
        "The service call response (type Amazon.SupplyChain.Model.CreateDataLakeDatasetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSUPCHDataLakeDatasetCmdlet : AmazonSupplyChainClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter PartitionSpec_Field
        /// <summary>
        /// <para>
        /// <para>The fields on which to partition a dataset. The partitions will be applied hierarchically
        /// based on the order of this list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PartitionSpec_Fields")]
        public Amazon.SupplyChain.Model.DataLakeDatasetPartitionField[] PartitionSpec_Field { get; set; }
        #endregion
        
        #region Parameter Schema_Field
        /// <summary>
        /// <para>
        /// <para>The list of field details of the dataset schema.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schema_Fields")]
        public Amazon.SupplyChain.Model.DataLakeDatasetSchemaField[] Schema_Field { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Supply Chain instance identifier.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the dataset. For <b>asc</b> name space, the name must be one of the supported
        /// data entities under <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/data-model-asc.html">https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/data-model-asc.html</a>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Schema_Name
        /// <summary>
        /// <para>
        /// <para>The name of the dataset schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schema_Name { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the dataset, besides the custom defined namespace, every instance
        /// comes with below pre-defined namespaces:</para><ul><li><para><b>asc</b> - For information on the Amazon Web Services Supply Chain supported datasets
        /// see <a href="https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/data-model-asc.html">https://docs.aws.amazon.com/aws-supply-chain/latest/userguide/data-model-asc.html</a>.</para></li><li><para><b>default</b> - For datasets with custom user-defined schemas.</para></li></ul>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Schema_PrimaryKey
        /// <summary>
        /// <para>
        /// <para>The list of primary key fields for the dataset. Primary keys defined can help data
        /// ingestion methods to ensure data uniqueness: CreateDataIntegrationFlow's dedupe strategy
        /// will leverage primary keys to perform records deduplication before write to dataset;
        /// SendDataIntegrationEvent's UPSERT and DELETE can only work with dataset with primary
        /// keys. For more details, refer to those data ingestion documentations.</para><para>Note that defining primary keys does not necessarily mean the dataset cannot have
        /// duplicate records, duplicate records can still be ingested if CreateDataIntegrationFlow's
        /// dedupe disabled or through SendDataIntegrationEvent's APPEND operation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schema_PrimaryKeys")]
        public Amazon.SupplyChain.Model.DataLakeDatasetPrimaryKeyField[] Schema_PrimaryKey { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags of the dataset.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Dataset'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupplyChain.Model.CreateDataLakeDatasetResponse).
        /// Specifying the name of a property of type Amazon.SupplyChain.Model.CreateDataLakeDatasetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Dataset";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SUPCHDataLakeDataset (CreateDataLakeDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupplyChain.Model.CreateDataLakeDatasetResponse, NewSUPCHDataLakeDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PartitionSpec_Field != null)
            {
                context.PartitionSpec_Field = new List<Amazon.SupplyChain.Model.DataLakeDatasetPartitionField>(this.PartitionSpec_Field);
            }
            if (this.Schema_Field != null)
            {
                context.Schema_Field = new List<Amazon.SupplyChain.Model.DataLakeDatasetSchemaField>(this.Schema_Field);
            }
            context.Schema_Name = this.Schema_Name;
            if (this.Schema_PrimaryKey != null)
            {
                context.Schema_PrimaryKey = new List<Amazon.SupplyChain.Model.DataLakeDatasetPrimaryKeyField>(this.Schema_PrimaryKey);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.SupplyChain.Model.CreateDataLakeDatasetRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            
             // populate PartitionSpec
            var requestPartitionSpecIsNull = true;
            request.PartitionSpec = new Amazon.SupplyChain.Model.DataLakeDatasetPartitionSpec();
            List<Amazon.SupplyChain.Model.DataLakeDatasetPartitionField> requestPartitionSpec_partitionSpec_Field = null;
            if (cmdletContext.PartitionSpec_Field != null)
            {
                requestPartitionSpec_partitionSpec_Field = cmdletContext.PartitionSpec_Field;
            }
            if (requestPartitionSpec_partitionSpec_Field != null)
            {
                request.PartitionSpec.Fields = requestPartitionSpec_partitionSpec_Field;
                requestPartitionSpecIsNull = false;
            }
             // determine if request.PartitionSpec should be set to null
            if (requestPartitionSpecIsNull)
            {
                request.PartitionSpec = null;
            }
            
             // populate Schema
            var requestSchemaIsNull = true;
            request.Schema = new Amazon.SupplyChain.Model.DataLakeDatasetSchema();
            List<Amazon.SupplyChain.Model.DataLakeDatasetSchemaField> requestSchema_schema_Field = null;
            if (cmdletContext.Schema_Field != null)
            {
                requestSchema_schema_Field = cmdletContext.Schema_Field;
            }
            if (requestSchema_schema_Field != null)
            {
                request.Schema.Fields = requestSchema_schema_Field;
                requestSchemaIsNull = false;
            }
            System.String requestSchema_schema_Name = null;
            if (cmdletContext.Schema_Name != null)
            {
                requestSchema_schema_Name = cmdletContext.Schema_Name;
            }
            if (requestSchema_schema_Name != null)
            {
                request.Schema.Name = requestSchema_schema_Name;
                requestSchemaIsNull = false;
            }
            List<Amazon.SupplyChain.Model.DataLakeDatasetPrimaryKeyField> requestSchema_schema_PrimaryKey = null;
            if (cmdletContext.Schema_PrimaryKey != null)
            {
                requestSchema_schema_PrimaryKey = cmdletContext.Schema_PrimaryKey;
            }
            if (requestSchema_schema_PrimaryKey != null)
            {
                request.Schema.PrimaryKeys = requestSchema_schema_PrimaryKey;
                requestSchemaIsNull = false;
            }
             // determine if request.Schema should be set to null
            if (requestSchemaIsNull)
            {
                request.Schema = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SupplyChain.Model.CreateDataLakeDatasetResponse CallAWSServiceOperation(IAmazonSupplyChain client, Amazon.SupplyChain.Model.CreateDataLakeDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Supply Chain", "CreateDataLakeDataset");
            try
            {
                return client.CreateDataLakeDatasetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public System.String Namespace { get; set; }
            public List<Amazon.SupplyChain.Model.DataLakeDatasetPartitionField> PartitionSpec_Field { get; set; }
            public List<Amazon.SupplyChain.Model.DataLakeDatasetSchemaField> Schema_Field { get; set; }
            public System.String Schema_Name { get; set; }
            public List<Amazon.SupplyChain.Model.DataLakeDatasetPrimaryKeyField> Schema_PrimaryKey { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SupplyChain.Model.CreateDataLakeDatasetResponse, NewSUPCHDataLakeDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Dataset;
        }
        
    }
}
