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
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

using Amazon.PowerShell.Cmdlets.DDB.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// <para>The <i>CreateTable</i> operation adds a new table to your account. In an AWS account, table names must be unique within each region.
    /// That is, you can have two tables with same name if you create the tables in different regions.</para><para><i>CreateTable</i> is an
    /// asynchronous operation. Upon receiving a <i>CreateTable</i> request, Amazon DynamoDB immediately returns a response with a
    /// <i>TableStatus</i> of <c>CREATING</c> . After the table is created, Amazon DynamoDB sets the <i>TableStatus</i> to <c>ACTIVE</c> . You can
    /// perform read and write operations only on an <c>ACTIVE</c> table. </para><para>If you want to create multiple tables with local secondary
    /// indexes on them, you must create them sequentially. Only one table with local secondary indexes can be in the <c>CREATING</c> state at any
    /// given time.</para><para>You can use the <i>DescribeTable</i> API to check the table status.</para>
    /// </summary>
    [Cmdlet("New", "DDBTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB CreateTable API operation.", Operation = new [] {"CreateTable"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.CreateTableResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TableDescription or Amazon.DynamoDBv2.Model.CreateTableResponse",
        "This cmdlet returns aN Amazon.DynamoDBv2.Model.TableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.CreateTableResponse) can be returned by specifying '-Select *'."
    )]
    public class NewDDBTableCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// The name of the table to create.
        /// </para> 
        /// <para>
        /// <b>Constraints:</b><list type="definition"><item><term>Length</term><description>3 - 255</description></item><item><term>Pattern</term><description>[a-zA-Z0-9_.-]+</description></item></list>
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TableName { get; set; }
        #endregion

        #region Parameter Schema
        /// <summary>
        /// TableSchema object containing the attribute and key schema information for the new
        /// table using the Write-DDBKeySchema and Write-DDBIndexSchema cmdlets.
        /// </summary>
        [Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Mandatory = true, Position = 1)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema Schema { get; set; }
        #endregion

        #region Parameter ReadCapacity 
        /// <summary>
        /// <para>
        /// The maximum number of strongly consistent reads consumed per second before Amazon DynamoDB returns a <i>ThrottlingException</i>. For more
        /// information, see <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithDDTables.html#ProvisionedThroughput">Specifying Read and
        /// Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.
        /// </para> 
        /// <para>
        /// <b>Constraints:</b><list type="definition"><item><term>Range</term><description>1 - </description></item></list>
        /// </para>
        /// <para>
        /// The settings can be modified using the <i>Update-DDBTable</i> cmdlet. For current minimum and maximum provisioned throughput values, see Limits in the <i>Amazon DynamoDB Developer
        /// Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.Int64? ReadCapacity { get; set; }
        #endregion

        #region Parameter WriteCapacity
        /// <summary>
        /// <para>
        /// The maximum number of strongly consistent writes consumed per second before Amazon DynamoDB returns a <i>ThrottlingException</i>. For more
        /// information, see <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithDDTables.html#ProvisionedThroughput">Specifying Read and
        /// Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.
        /// </para> 
        /// <para>
        /// <b>Constraints:</b><list type="definition"><item><term>Range</term><description>1 - </description></item></list>
        /// </para>
        /// <para>
        /// The settings can be modified using the <i>Update-DDBTable</i> cmdlet. For current minimum and maximum provisioned throughput values, see Limits in the <i>Amazon DynamoDB Developer
        /// Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.Int64? WriteCapacity { get; set; }
        #endregion

        #region Parameter BillingMode
        /// <summary>
        /// <para>
        /// <para>Controls how you are charged for read and write throughput and how you manage capacity. 
        /// This setting can be changed later.</para><ul><li><para><code>PROVISIONED</code> - We recommend using <code>PROVISIONED</code> for predictable
        /// workloads. <code>PROVISIONED</code> sets the billing mode to <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadWriteCapacityMode.html#HowItWorks.ProvisionedThroughput.Manual">Provisioned
        /// Mode</a>.</para></li><li><para><code>PAY_PER_REQUEST</code> - We recommend using <code>PAY_PER_REQUEST</code> for
        /// unpredictable workloads. <code>PAY_PER_REQUEST</code> sets the billing mode to <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadWriteCapacityMode.html#HowItWorks.OnDemand">On-Demand
        /// Mode</a>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.BillingMode")]
        public Amazon.DynamoDBv2.BillingMode BillingMode { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion


        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TableDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.CreateTableResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.CreateTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter]
        public string Select { get; set; } = "TableDescription";
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.TableName, "New-DDBTable (CreateTable)"))
                return;

            if (this.BillingMode != null && this.BillingMode == BillingMode.PAY_PER_REQUEST)
            {
                if (this.ReadCapacity != null)
                    throw new ArgumentException("ReadCapacity cannot be specified when BillingMode is PAY_PER_REQUEST.");

                if (this.WriteCapacity != null)
                    throw new ArgumentException("WriteCapacity cannot be specified when BillingMode is PAY_PER_REQUEST.");
            }

            // Default BillingMode is PROVISIONED.
            if (this.BillingMode == null || this.BillingMode == BillingMode.PROVISIONED)
            {
                if (this.ReadCapacity == null)
                    throw new ArgumentException("ReadCapacity must be specified when BillingMode is PROVISIONED.");

                if (this.WriteCapacity == null)
                    throw new ArgumentException("WriteCapacity must be specified when BillingMode is PROVISIONED.");
            }

            var context = new CmdletContext
            {
                BillingMode = this.BillingMode,
                TableName = this.TableName,
                SchemaObject = DDBSchemaCmdletHelper.TableSchemaFromParameter(Schema),
                ReadCapacityUnits = this.ReadCapacity,
                WriteCapacityUnits = this.WriteCapacity
            };

            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.CreateTableResponse, NewDDBTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateTableRequest
            {
                TableName = cmdletContext.TableName
            };

            PopulateRequestFromSchemaObject(cmdletContext.SchemaObject, request);

            // Both ReadCapacityUnits and WriteCapacityUnits would be specified for BillingMode PROVISIONED.
            if (cmdletContext.ReadCapacityUnits != null && cmdletContext.WriteCapacityUnits != null)
            {
                request.ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = cmdletContext.ReadCapacityUnits.Value,
                    WriteCapacityUnits = cmdletContext.WriteCapacityUnits.Value
                };
            }

            if (cmdletContext.BillingMode != null)
            {
                request.BillingMode = cmdletContext.BillingMode;
            }

            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            CmdletOutput output;
            
            // issue call
            try
            {
                var response = CallAWSServiceOperation(client, request);
                output = new CmdletOutput
                {
                    PipelineOutput = cmdletContext.Select(response, this),
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        private void PopulateRequestFromSchemaObject(TableSchema schemaObject, CreateTableRequest request)
        {
            if (!schemaObject.HasDefinedKeys)
                ThrowArgumentError("Key schema not defined on input object.", Schema);
            if (!schemaObject.HasDefinedAttributes)
                ThrowArgumentError("Attribute schema containing keys not defined on input object.", Schema);

            request.KeySchema = schemaObject.KeySchema;
            request.AttributeDefinitions = schemaObject.AttributeSchema;

            // optional
            if (schemaObject.HasDefinedLocalSecondaryIndices)
            {
                // reconstruct each lsi so that the schema builder cmdlets can opt to not
                // set the primary hash key element, thus enabling re-use on multiple
                // table creation pipelines
                var requestIndices = new List<LocalSecondaryIndex>();
                foreach (var definedLSI in schemaObject.LocalSecondaryIndexSchema)
                {
                    var lsi = new LocalSecondaryIndex
                    {
                        IndexName = definedLSI.IndexName,
                        KeySchema = new List<KeySchemaElement>()
                    };
                    var hashKey = definedLSI.KeySchema.FirstOrDefault(k => k.KeyType.Equals(KeyType.HASH));
                    if (hashKey == null)
                    {
                        hashKey = schemaObject.KeySchema.FirstOrDefault(k => k.KeyType.Equals(KeyType.HASH));
                        if (hashKey == null)
                            throw new ArgumentException(string.Format("Unable to determine primary hash key from supplied schema to use in local secondary index {0}", definedLSI.IndexName));

                        // DynamoDB requires the hash key be first in the collection
                        lsi.KeySchema.Add(hashKey);
                        lsi.KeySchema.AddRange(definedLSI.KeySchema);
                    }
                    else
                    {
                        // primary hash already set, possibly from earlier setup so just re-use
                        lsi.KeySchema.AddRange(definedLSI.KeySchema);
                    }

                    if (definedLSI.Projection != null)
                    {
                        lsi.Projection = new Projection
                        {
                            ProjectionType = definedLSI.Projection.ProjectionType,
                            NonKeyAttributes = definedLSI.Projection.NonKeyAttributes
                        };
                    }

                    requestIndices.Add(lsi);
                }

                request.LocalSecondaryIndexes = requestIndices;
            }

            // optional
            if (schemaObject.HasDefinedGlobalSecondaryIndices)
            {
                // reconstruct each lsi so that the schema builder cmdlets can opt to not
                // set the primary hash key element, thus enabling re-use on multiple
                // table creation pipelines
                var requestIndices = new List<GlobalSecondaryIndex>();
                foreach (var definedGSI in schemaObject.GlobalSecondaryIndexSchema)
                {
                    var gsi = new GlobalSecondaryIndex
                    {
                        IndexName = definedGSI.IndexName,
                        KeySchema = new List<KeySchemaElement>(),
                        ProvisionedThroughput = new ProvisionedThroughput
                        {
                            ReadCapacityUnits = definedGSI.ProvisionedThroughput.ReadCapacityUnits,
                            WriteCapacityUnits = definedGSI.ProvisionedThroughput.WriteCapacityUnits
                        }
                    };

                    var hashKey = definedGSI.KeySchema.FirstOrDefault(k => k.KeyType.Equals(KeyType.HASH));
                    if (hashKey == null)
                    {
                        hashKey = schemaObject.KeySchema.FirstOrDefault(k => k.KeyType.Equals(KeyType.HASH));
                        if (hashKey == null)
                            throw new ArgumentException(string.Format("Unable to determine primary hash key from supplied schema to use in global secondary index {0}", definedGSI.IndexName));

                        // DynamoDB requires the hash key be first in the collection
                        gsi.KeySchema.Add(hashKey);
                        gsi.KeySchema.AddRange(definedGSI.KeySchema);
                    }
                    else
                    {
                        // primary hash already set, possibly from earlier setup so just re-use
                        gsi.KeySchema.AddRange(definedGSI.KeySchema);
                    }

                    if (definedGSI.Projection != null)
                    {
                        gsi.Projection = new Projection
                        {
                            ProjectionType = definedGSI.Projection.ProjectionType,
                            NonKeyAttributes = definedGSI.Projection.NonKeyAttributes
                        };
                    }

                    requestIndices.Add(gsi);
                }

                request.GlobalSecondaryIndexes = requestIndices;
            }
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.DynamoDBv2.Model.CreateTableResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.CreateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "CreateTable");

            try
            {
#if DESKTOP
                return client.CreateTable(request);
#elif CORECLR
                return client.CreateTableAsync(request).GetAwaiter().GetResult();
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

        internal class CmdletContext : ExecutorContext
        {
            public List<AttributeDefinition> AttributeDefinitions { get; set; }
            public Amazon.DynamoDBv2.BillingMode BillingMode { get; set; }
            public String TableName { get; set; }
            public List<KeySchemaElement> KeySchema { get; set; }
            public List<LocalSecondaryIndex> LocalSecondaryIndexes { get; set; }
            public List<GlobalSecondaryIndex> GlobalSecondaryIndexes { get; set; }
            public Int64? ReadCapacityUnits { get; set; }
            public Int64? WriteCapacityUnits { get; set; }
            public TableSchema SchemaObject { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.CreateTableResponse, NewDDBTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TableDescription;
        }
        
    }
}
