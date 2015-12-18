/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Invokes the CreateTable operation against Amazon DynamoDB.", Operation = new [] {"CreateTable"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TableDescription",
        "This cmdlet returns aN Amazon.DynamoDBv2.Model.TableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.CreateTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
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
        public System.String TableName { get; set; }
        #endregion

        #region Parameter Schema
        /// <summary>
        /// TableSchema object containing the attribute and key schema information for the new
        /// table using the Write-DDBKeySchema and Write-DDBIndexSchema cmdlets.
        /// </summary>
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1)]
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
        [Parameter(Mandatory = true, Position = 2)]
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
        [Parameter(Mandatory = true, Position = 3)]
        public System.Int64? WriteCapacity { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.TableName, "New-DDBTable (CreateTable)"))
                return;

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                TableName = this.TableName,
                SchemaObject = DDBSchemaCmdletHelper.TableSchemaFromParameter(Schema),
                ReadCapacityUnits = this.ReadCapacity,
                WriteCapacityUnits = this.WriteCapacity
            };

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

            request.ProvisionedThroughput = new ProvisionedThroughput
            {
                ReadCapacityUnits = cmdletContext.ReadCapacityUnits.Value,
                WriteCapacityUnits = cmdletContext.WriteCapacityUnits.Value
            };
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateTable(request);
                output = new CmdletOutput
                {
                    PipelineOutput = response.TableDescription,
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<AttributeDefinition> AttributeDefinitions { get; set; }
            public String TableName { get; set; }
            public List<KeySchemaElement> KeySchema { get; set; }
            public List<LocalSecondaryIndex> LocalSecondaryIndexes { get; set; }
            public List<GlobalSecondaryIndex> GlobalSecondaryIndexes { get; set; }
            public Int64? ReadCapacityUnits { get; set; }
            public Int64? WriteCapacityUnits { get; set; }
            public TableSchema SchemaObject { get; set; }
        }
        
    }
}
