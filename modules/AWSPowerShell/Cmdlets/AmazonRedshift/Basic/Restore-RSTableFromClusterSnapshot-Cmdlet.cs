/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Creates a new table from a table in an Amazon Redshift cluster snapshot. You must
    /// create the new table within the Amazon Redshift cluster that the snapshot was taken
    /// from.
    /// 
    ///  
    /// <para>
    /// You cannot use <code>RestoreTableFromClusterSnapshot</code> to restore a table with
    /// the same name as an existing table in an Amazon Redshift cluster. That is, you cannot
    /// overwrite an existing table in a cluster with a restored table. If you want to replace
    /// your original table with a new, restored table, then rename or drop your original
    /// table before you call <code>RestoreTableFromClusterSnapshot</code>. When you have
    /// renamed your original table, then you can pass the original name of the table as the
    /// <code>NewTableName</code> parameter value in the call to <code>RestoreTableFromClusterSnapshot</code>.
    /// This way, you can replace the original table with the table created from the snapshot.
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "RSTableFromClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.TableRestoreStatus")]
    [AWSCmdlet("Invokes the RestoreTableFromClusterSnapshot operation against Amazon Redshift.", Operation = new[] {"RestoreTableFromClusterSnapshot"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.TableRestoreStatus",
        "This cmdlet returns a TableRestoreStatus object.",
        "The service call response (type Amazon.Redshift.Model.RestoreTableFromClusterSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RestoreRSTableFromClusterSnapshotCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Redshift cluster to restore the table to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter NewTableName
        /// <summary>
        /// <para>
        /// <para>The name of the table to create as a result of the current request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewTableName { get; set; }
        #endregion
        
        #region Parameter SnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the snapshot to restore the table from. This snapshot must have
        /// been created from the Amazon Redshift cluster specified by the <code>ClusterIdentifier</code>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the source database that contains the table to restore from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceDatabaseName { get; set; }
        #endregion
        
        #region Parameter SourceSchemaName
        /// <summary>
        /// <para>
        /// <para>The name of the source schema that contains the table to restore from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceSchemaName { get; set; }
        #endregion
        
        #region Parameter SourceTableName
        /// <summary>
        /// <para>
        /// <para>The name of the source table to restore from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceTableName { get; set; }
        #endregion
        
        #region Parameter TargetDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database to restore the table to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetDatabaseName { get; set; }
        #endregion
        
        #region Parameter TargetSchemaName
        /// <summary>
        /// <para>
        /// <para>The name of the schema to restore the table to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetSchemaName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SnapshotIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RSTableFromClusterSnapshot (RestoreTableFromClusterSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.NewTableName = this.NewTableName;
            context.SnapshotIdentifier = this.SnapshotIdentifier;
            context.SourceDatabaseName = this.SourceDatabaseName;
            context.SourceSchemaName = this.SourceSchemaName;
            context.SourceTableName = this.SourceTableName;
            context.TargetDatabaseName = this.TargetDatabaseName;
            context.TargetSchemaName = this.TargetSchemaName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Redshift.Model.RestoreTableFromClusterSnapshotRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.NewTableName != null)
            {
                request.NewTableName = cmdletContext.NewTableName;
            }
            if (cmdletContext.SnapshotIdentifier != null)
            {
                request.SnapshotIdentifier = cmdletContext.SnapshotIdentifier;
            }
            if (cmdletContext.SourceDatabaseName != null)
            {
                request.SourceDatabaseName = cmdletContext.SourceDatabaseName;
            }
            if (cmdletContext.SourceSchemaName != null)
            {
                request.SourceSchemaName = cmdletContext.SourceSchemaName;
            }
            if (cmdletContext.SourceTableName != null)
            {
                request.SourceTableName = cmdletContext.SourceTableName;
            }
            if (cmdletContext.TargetDatabaseName != null)
            {
                request.TargetDatabaseName = cmdletContext.TargetDatabaseName;
            }
            if (cmdletContext.TargetSchemaName != null)
            {
                request.TargetSchemaName = cmdletContext.TargetSchemaName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RestoreTableFromClusterSnapshot(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TableRestoreStatus;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClusterIdentifier { get; set; }
            public System.String NewTableName { get; set; }
            public System.String SnapshotIdentifier { get; set; }
            public System.String SourceDatabaseName { get; set; }
            public System.String SourceSchemaName { get; set; }
            public System.String SourceTableName { get; set; }
            public System.String TargetDatabaseName { get; set; }
            public System.String TargetSchemaName { get; set; }
        }
        
    }
}
