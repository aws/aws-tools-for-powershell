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

using System.Collections.Generic;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.DynamoDBv2.Model;

using Amazon.PowerShell.Cmdlets.DDB.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    public abstract class DDBSchemaCmdletHelper
    {
        internal static readonly string KeyType_Hash = "HASH";
        internal static readonly string KeyType_Range = "RANGE";

        /// <summary>
        /// Returns the schema object to manipulate.
        /// </summary>
        /// <param name="inputObjectParameter">
        /// The pipeline object supplied as the value of the -Schema parameter 
        /// or piped into cmdlet.
        /// </param>
        /// <returns>
        /// The supplied object as TableSchema.
        /// </returns>
        public static TableSchema TableSchemaFromParameter(object inputObjectParameter)
        {
            var schemaObject = inputObjectParameter as TableSchema;
            if (schemaObject == null && inputObjectParameter is PSObject)
                schemaObject = (inputObjectParameter as PSObject).BaseObject as TableSchema;

            return schemaObject;
        }
    }
}
