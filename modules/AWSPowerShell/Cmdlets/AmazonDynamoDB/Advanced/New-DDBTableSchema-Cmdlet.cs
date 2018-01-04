/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.PowerShell.Cmdlets.DDB.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Returns a new TableSchema object for constructing an Amazon DynamoDB key schema for use with New-DDBTable.
    /// </summary>
    [Cmdlet("New", "DDBTableSchema")]
    [OutputType("TableSchema")]
    [AWSCmdlet("Returns a new Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema object for constructing an Amazon DynamoDB key schema for use with New-DDBTable.")]
    [AWSCmdletOutput("Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema", "This cmdlet returns a new Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema object.")]
    public class NewDDBTableSchemaCmdlet : BaseCmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                WriteObject(TableSchema.From(null));
            }
            catch (Exception e)
            {
                ThrowError(e);
            }
        }
    }
}
