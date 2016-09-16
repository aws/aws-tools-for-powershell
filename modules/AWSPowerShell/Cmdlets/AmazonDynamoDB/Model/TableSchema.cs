using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB.Model
{
    /// <summary>
    /// Model class carrying details of an Amazon DynamoDB table schema under
    /// construction for use with the New-DDBTable cmdlet. This class is accepted
    /// as pipeline input by the schema builder cmdlets (Write-DDBAttributeSchema,
    /// Write-DDBKeySchema and Write-DDBIndexSchema).
    /// </summary>
    public class TableSchema
    {
        private readonly string[] _projectionTypes = new string[]
        {
            "KEYS_ONLY",
            "INCLUDE",
            "ALL"
        };

        #region Construction

        private TableSchema()
        {
        }

        /// <summary>
        /// Constructs a new table schema from a deep copy of the suppled object.
        /// Note that ICloneable is not supported on the coreclr platform, so we
        /// chose not to make the type derive from ICloneable but retained the 
        /// Clone method.
        /// </summary>
        /// <param name="source"></param>
        private TableSchema(TableSchema source)
        {
            CloneAttributeSchema(source.AttributeSchema);
            CloneKeySchema(source.KeySchema);
            CloneLocalSecondaryIndexSchema(source.LocalSecondaryIndexSchema);
            CloneGlobalSecondaryIndexSchema(source.GlobalSecondaryIndexSchema);
        }

        internal static TableSchema From(TableSchema source)
        {
            return source == null ? new TableSchema() : new TableSchema(source);
        }

        #endregion

        public object Clone()
        {
            return From(this);
        }

#region Properties

        List<AttributeDefinition> _attributeSchema = new List<AttributeDefinition>();
        public List<AttributeDefinition> AttributeSchema 
        {
            get { return _attributeSchema; }
        }

        internal bool HasDefinedAttributes
        {
            get { return _attributeSchema.Count > 0; }
        }

        List<KeySchemaElement> _keySchema = new List<KeySchemaElement>();
        public List<KeySchemaElement> KeySchema 
        {
            get { return _keySchema; }
        }

        internal bool HasDefinedKeys
        {
            get { return _keySchema.Count > 0; }
        }

        List<LocalSecondaryIndex> _localSecondaryIndexSchema = new List<LocalSecondaryIndex>();
        public List<LocalSecondaryIndex> LocalSecondaryIndexSchema 
        {
            get { return _localSecondaryIndexSchema; }
        }

        internal bool HasDefinedLocalSecondaryIndices
        {
            get { return _localSecondaryIndexSchema.Count > 0; }
        }

        List<GlobalSecondaryIndex> _globalSecondaryIndexSchema = new List<GlobalSecondaryIndex>();
        public List<GlobalSecondaryIndex> GlobalSecondaryIndexSchema
        {
            get { return _globalSecondaryIndexSchema; }
        }

        internal bool HasDefinedGlobalSecondaryIndices
        {
            get { return _globalSecondaryIndexSchema.Count > 0; }
        }
        #endregion

        #region Attribute Schema Operations

        private void CloneAttributeSchema(IEnumerable<AttributeDefinition> sourceSchema)
        {
            AttributeSchema.AddRange(sourceSchema.Select(attr => new AttributeDefinition
            {
                AttributeName = new string(attr.AttributeName.ToCharArray()),
                AttributeType = new DynamoDBv2.ScalarAttributeType(attr.AttributeType)
            }));
        }

        internal void AddAttribute(string attributeName, string attributeType)
        {
            if (string.IsNullOrEmpty(attributeType))
                throw new ArgumentException(string.Format("Attribute type must be specified", "AttributeType"));

            var existingAttr = AttributeSchema.FirstOrDefault(attr => attr.AttributeName.Equals(attributeName, StringComparison.OrdinalIgnoreCase));
            if (existingAttr != null)
            {
                if (!attributeType.Equals(existingAttr.AttributeType, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException(string.Format("An attribute with name {0} had been defined previously but conflicting type ({1} vs {2}) has already been defined.",
                                                     attributeName, existingAttr.AttributeType, attributeType),
                                                "AttributeName");

                return;
            }

            AttributeSchema.Add(new AttributeDefinition { AttributeName = attributeName, AttributeType = attributeType.ToUpper() });
        }

        #endregion

        #region Key Schema Operations

        private void CloneKeySchema(IEnumerable<KeySchemaElement> sourceSchema)
        {
            KeySchema.AddRange(sourceSchema.Select(key => new KeySchemaElement
            {
                AttributeName = new string(key.AttributeName.ToCharArray()),
                KeyType = new DynamoDBv2.KeyType(key.KeyType)
            }));
        }

        internal void AddKey(string keyName, string keyType, string dataType)
        {
            var keyElement = KeySchema.FirstOrDefault(key => key.AttributeName.Equals(keyName, StringComparison.OrdinalIgnoreCase));
            if (keyElement != null)
                throw new ArgumentException(string.Format("A key with name '{0}' has already been defined in the schema.", keyName), "KeyName");

            // if the key doesn't already exist as an attribute, add it
            var attribute = AttributeSchema.FirstOrDefault(a => a.AttributeName.Equals(keyName, StringComparison.OrdinalIgnoreCase));
            if (attribute == null)
            {
                if (string.IsNullOrEmpty(dataType))
                    throw new ArgumentException("An attribute for the key was not found in the supplied schema. The data type is needed before it can be added automatically.", "DataType");

                AttributeSchema.Add(new AttributeDefinition { AttributeName = keyName, AttributeType = dataType });
            }

            keyElement = new KeySchemaElement
            {
                AttributeName = keyName,
                KeyType = keyType
            };

            // allow for user possibly defining keys in any order; DDB requires the primary hash key to be first
            // and there may be multiple hash keys allowed in future.
            if (!HasDefinedKeys || keyType.Equals(Amazon.DynamoDBv2.KeyType.RANGE, StringComparison.OrdinalIgnoreCase))
                KeySchema.Add(keyElement);
            else if (KeySchema[0].KeyType.Equals(Amazon.DynamoDBv2.KeyType.HASH))
                KeySchema.Add(keyElement);
            else
                KeySchema.Insert(0, keyElement);
        }

        #endregion

        #region Local Secondary Index Schema Operations

        private void CloneLocalSecondaryIndexSchema(IEnumerable<LocalSecondaryIndex> sourceSchema)
        {
            foreach (var sourceIndex in sourceSchema)
            {
                var clonedIndex = new LocalSecondaryIndex
                {
                    IndexName = new string(sourceIndex.IndexName.ToCharArray()),
                    Projection = null,
                    KeySchema = new List<KeySchemaElement>()
                };

                foreach (var sourceKey in sourceIndex.KeySchema)
                {
                    var clonedKey = new KeySchemaElement
                    {
                        AttributeName = new string(sourceKey.AttributeName.ToCharArray()),
                        KeyType = new DynamoDBv2.KeyType(sourceKey.KeyType)
                    };
                    clonedIndex.KeySchema.Add(clonedKey);
                }

                if (sourceIndex.Projection != null)
                {
                    clonedIndex.Projection = new Projection
                    {
                        ProjectionType = new DynamoDBv2.ProjectionType(sourceIndex.Projection.ProjectionType),
                        NonKeyAttributes = new List<string>()
                    };
                    foreach (var nonKeyAttr in sourceIndex.Projection.NonKeyAttributes)
                    {
                        clonedIndex.Projection.NonKeyAttributes.Add(nonKeyAttr);
                    }
                }

                LocalSecondaryIndexSchema.Add(clonedIndex);
            }
        }

        /// <summary>
        /// Adds a new local secondary index or updates an index if it has been defined already
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="rangeKeyName"></param>
        /// <param name="rangeKeyDataType"></param>
        /// <param name="projectionType"></param>
        /// <param name="nonKeyAttributes"></param>
        internal void SetLocalSecondaryIndex(string indexName, string rangeKeyName, string rangeKeyDataType, string projectionType = null, string[] nonKeyAttributes = null)
        {
            // to add additional range keys, the user invokes this cmdlet multiple times in the
            // pipeline
            bool creatingNewIndex = false;
            var lsi = LocalSecondaryIndexSchema.FirstOrDefault(l => l.IndexName.Equals(indexName, StringComparison.OrdinalIgnoreCase));
            if (lsi == null)
            {
                creatingNewIndex = true;
                lsi = new LocalSecondaryIndex
                {
                    IndexName = indexName,
                    KeySchema = new List<KeySchemaElement>()
                };
            }

            if (AttributeSchema.FirstOrDefault(a => a.AttributeName.Equals(rangeKeyName, StringComparison.Ordinal)) == null)
            {
                // could validate that data type matches here
                AttributeSchema.Add(new AttributeDefinition { AttributeName = rangeKeyName, AttributeType = rangeKeyDataType });
            }

            lsi.KeySchema.Add(new KeySchemaElement { AttributeName = rangeKeyName, KeyType = Amazon.DynamoDBv2.KeyType.RANGE });

            if (!string.IsNullOrEmpty(projectionType))
            {
                lsi.Projection = new Projection();

                if (_projectionTypes.Contains(projectionType, StringComparer.OrdinalIgnoreCase))
                {
                    lsi.Projection.ProjectionType = projectionType.ToUpper();
                    if (nonKeyAttributes != null && nonKeyAttributes.Length > 0)
                    {
                        lsi.Projection.NonKeyAttributes.AddRange(nonKeyAttributes);
                    }
                }
                else
                    throw new ArgumentException(string.Format("Invalid ProjectionType '{0}'; allowed values: {1}.",
                                                                 projectionType,
                                                                 string.Join(", ", _projectionTypes)),
                                                "ProjectionType");
            }

            if (creatingNewIndex)
                LocalSecondaryIndexSchema.Add(lsi);
        }

        #endregion

        #region Global Secondary Index Schema Operations

        private void CloneGlobalSecondaryIndexSchema(IEnumerable<GlobalSecondaryIndex> sourceSchema)
        {
            foreach (var sourceIndex in sourceSchema)
            {
                var clonedIndex = new GlobalSecondaryIndex
                {
                    IndexName = new string(sourceIndex.IndexName.ToCharArray()),
                    Projection = null,
                    KeySchema = new List<KeySchemaElement>()
                };

                foreach (var sourceKey in sourceIndex.KeySchema)
                {
                    var clonedKey = new KeySchemaElement
                    {
                        AttributeName = new string(sourceKey.AttributeName.ToCharArray()),
                        KeyType = new DynamoDBv2.KeyType(sourceKey.KeyType)
                    };
                    clonedIndex.KeySchema.Add(clonedKey);
                }

                if (sourceIndex.Projection != null)
                {
                    clonedIndex.Projection = new Projection
                    {
                        ProjectionType = new DynamoDBv2.ProjectionType(sourceIndex.Projection.ProjectionType),
                        NonKeyAttributes = new List<string>()
                    };
                    foreach (var nonKeyAttr in sourceIndex.Projection.NonKeyAttributes)
                    {
                        clonedIndex.Projection.NonKeyAttributes.Add(nonKeyAttr);
                    }
                }

                clonedIndex.ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = sourceIndex.ProvisionedThroughput.ReadCapacityUnits,
                    WriteCapacityUnits = sourceIndex.ProvisionedThroughput.WriteCapacityUnits
                };

                GlobalSecondaryIndexSchema.Add(clonedIndex);
            }
        }

        /// <summary>
        /// Adds a new global secondary index or updates an index if it has been defined already.
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="hashKeyName"></param>
        /// <param name="hashKeyDataType"></param>
        /// <param name="rangeKeyName"></param>
        /// <param name="rangeKeyDataType"></param>
        /// <param name="readCapacityUnits"></param>
        /// <param name="writeCapacityUnits"></param>
        /// <param name="projectionType"></param>
        /// <param name="nonKeyAttributes"></param>
        internal void SetGlobalSecondaryIndex(string indexName,
                                              string hashKeyName,
                                              string hashKeyDataType,
                                              string rangeKeyName, 
                                              string rangeKeyDataType,
                                              Int64 readCapacityUnits,
                                              Int64 writeCapacityUnits,
                                              string projectionType = null, 
                                              string[] nonKeyAttributes = null)
        {
            // to add additional range keys, the user invokes this cmdlet multiple times in the
            // pipeline
            bool creatingNewIndex = false;
            var gsi = GlobalSecondaryIndexSchema.FirstOrDefault(g => g.IndexName.Equals(indexName, StringComparison.OrdinalIgnoreCase));
            if (gsi == null)
            {
                creatingNewIndex = true;
                gsi = new GlobalSecondaryIndex
                {
                    IndexName = indexName,
                    KeySchema = new List<KeySchemaElement>()
                };
            }

            // for a GSI, an additional hash key can be defined that does not have to match that used by the table
            if (!string.IsNullOrEmpty(hashKeyName))
            {
                if (AttributeSchema.FirstOrDefault(a => a.AttributeName.Equals(hashKeyName, StringComparison.Ordinal)) == null)
                {
                    // could validate that data type matches here
                    AttributeSchema.Add(new AttributeDefinition { AttributeName = hashKeyName, AttributeType = hashKeyDataType });
                }

                gsi.KeySchema.Add(new KeySchemaElement { AttributeName = hashKeyName, KeyType = Amazon.DynamoDBv2.KeyType.HASH });
            }

            // for global indexes, range key is optional (assuming a hash key has been specified); for local indexes the range key is
            // mandatory
            if (!string.IsNullOrEmpty(rangeKeyName))
            {
                if (AttributeSchema.FirstOrDefault(a => a.AttributeName.Equals(rangeKeyName, StringComparison.Ordinal)) == null)
                {
                    // could validate that data type matches here
                    AttributeSchema.Add(new AttributeDefinition { AttributeName = rangeKeyName, AttributeType = rangeKeyDataType });
                }

                gsi.KeySchema.Add(new KeySchemaElement { AttributeName = rangeKeyName, KeyType = Amazon.DynamoDBv2.KeyType.RANGE });
            }

            gsi.ProvisionedThroughput = new ProvisionedThroughput
            {
                ReadCapacityUnits = readCapacityUnits,
                WriteCapacityUnits = writeCapacityUnits
            };

            if (!string.IsNullOrEmpty(projectionType))
            {
                gsi.Projection = new Projection();

                if (_projectionTypes.Contains(projectionType, StringComparer.OrdinalIgnoreCase))
                {
                    gsi.Projection.ProjectionType = projectionType.ToUpper();
                    if (nonKeyAttributes != null && nonKeyAttributes.Length > 0)
                    {
                        gsi.Projection.NonKeyAttributes.AddRange(nonKeyAttributes);
                    }
                }
                else
                    throw new ArgumentException(string.Format("Invalid ProjectionType '{0}'; allowed values: {1}.",
                                                                 projectionType,
                                                                 string.Join(", ", _projectionTypes)),
                                                                "ProjectionType");
            }

            if (creatingNewIndex)
                GlobalSecondaryIndexSchema.Add(gsi);
        }

        #endregion
    }
}
