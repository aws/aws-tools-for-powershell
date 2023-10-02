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
    /// </para><para>
    /// You can't use this operation to restore tables with <a href="https://docs.aws.amazon.com/redshift/latest/dg/t_Sorting_data.html#t_Sorting_data-interleaved">interleaved
    /// sort keys</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "RSTableFromClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.TableRestoreStatus")]
    [AWSCmdlet("Calls the Amazon Redshift RestoreTableFromClusterSnapshot API operation.", Operation = new[] {"RestoreTableFromClusterSnapshot"}, SelectReturnType = typeof(Amazon.Redshift.Model.RestoreTableFromClusterSnapshotResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.TableRestoreStatus or Amazon.Redshift.Model.RestoreTableFromClusterSnapshotResponse",
        "This cmdlet returns an Amazon.Redshift.Model.TableRestoreStatus object.",
        "The service call response (type Amazon.Redshift.Model.RestoreTableFromClusterSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreRSTableFromClusterSnapshotCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Redshift cluster to restore the table to.</para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter EnableCaseSensitiveIdentifier
        /// <summary>
        /// <para>
        /// <para>Indicates whether name identifiers for database, schema, and table are case sensitive.
        /// If <code>true</code>, the names are case sensitive. If <code>false</code> (default),
        /// the names are not case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableCaseSensitiveIdentifier { get; set; }
        #endregion
        
        #region Parameter NewTableName
        /// <summary>
        /// <para>
        /// <para>The name of the table to create as a result of the current request.</para>
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the source database that contains the table to restore from.</para>
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
        public System.String SourceDatabaseName { get; set; }
        #endregion
        
        #region Parameter SourceSchemaName
        /// <summary>
        /// <para>
        /// <para>The name of the source schema that contains the table to restore from. If you do not
        /// specify a <code>SourceSchemaName</code> value, the default is <code>public</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceSchemaName { get; set; }
        #endregion
        
        #region Parameter SourceTableName
        /// <summary>
        /// <para>
        /// <para>The name of the source table to restore from.</para>
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
        public System.String SourceTableName { get; set; }
        #endregion
        
        #region Parameter TargetDatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database to restore the table to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetDatabaseName { get; set; }
        #endregion
        
        #region Parameter TargetSchemaName
        /// <summary>
        /// <para>
        /// <para>The name of the schema to restore the table to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetSchemaName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TableRestoreStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.RestoreTableFromClusterSnapshotResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.RestoreTableFromClusterSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TableRestoreStatus";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RSTableFromClusterSnapshot (RestoreTableFromClusterSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.RestoreTableFromClusterSnapshotResponse, RestoreRSTableFromClusterSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnableCaseSensitiveIdentifier = this.EnableCaseSensitiveIdentifier;
            context.NewTableName = this.NewTableName;
            #if MODULAR
            if (this.NewTableName == null && ParameterWasBound(nameof(this.NewTableName)))
            {
                WriteWarning("You are passing $null as a value for parameter NewTableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotIdentifier = this.SnapshotIdentifier;
            #if MODULAR
            if (this.SnapshotIdentifier == null && ParameterWasBound(nameof(this.SnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceDatabaseName = this.SourceDatabaseName;
            #if MODULAR
            if (this.SourceDatabaseName == null && ParameterWasBound(nameof(this.SourceDatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceSchemaName = this.SourceSchemaName;
            context.SourceTableName = this.SourceTableName;
            #if MODULAR
            if (this.SourceTableName == null && ParameterWasBound(nameof(this.SourceTableName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceTableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetDatabaseName = this.TargetDatabaseName;
            context.TargetSchemaName = this.TargetSchemaName;
            
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
            var request = new Amazon.Redshift.Model.RestoreTableFromClusterSnapshotRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.EnableCaseSensitiveIdentifier != null)
            {
                request.EnableCaseSensitiveIdentifier = cmdletContext.EnableCaseSensitiveIdentifier.Value;
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
        
        private Amazon.Redshift.Model.RestoreTableFromClusterSnapshotResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.RestoreTableFromClusterSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "RestoreTableFromClusterSnapshot");
            try
            {
                #if DESKTOP
                return client.RestoreTableFromClusterSnapshot(request);
                #elif CORECLR
                return client.RestoreTableFromClusterSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterIdentifier { get; set; }
            public System.Boolean? EnableCaseSensitiveIdentifier { get; set; }
            public System.String NewTableName { get; set; }
            public System.String SnapshotIdentifier { get; set; }
            public System.String SourceDatabaseName { get; set; }
            public System.String SourceSchemaName { get; set; }
            public System.String SourceTableName { get; set; }
            public System.String TargetDatabaseName { get; set; }
            public System.String TargetSchemaName { get; set; }
            public System.Func<Amazon.Redshift.Model.RestoreTableFromClusterSnapshotResponse, RestoreRSTableFromClusterSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TableRestoreStatus;
        }
        
    }
}
