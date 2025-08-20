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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates a new table optimizer for a specific function.
    /// </summary>
    [Cmdlet("New", "GLUETableOptimizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue CreateTableOptimizer API operation.", Operation = new[] {"CreateTableOptimizer"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateTableOptimizerResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.CreateTableOptimizerResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.CreateTableOptimizerResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewGLUETableOptimizerCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The Catalog ID of the table.</para>
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
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter IcebergConfiguration_CleanExpiredFile
        /// <summary>
        /// <para>
        /// <para>If set to false, snapshots are only deleted from table metadata, and the underlying
        /// data and metadata files are not deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_CleanExpiredFiles")]
        public System.Boolean? IcebergConfiguration_CleanExpiredFile { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database in the catalog in which the table resides.</para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter IcebergConfiguration_DeleteFileThreshold
        /// <summary>
        /// <para>
        /// <para>The minimum number of deletes that must be present in a data file to make it eligible
        /// for compaction. This parameter helps optimize compaction by focusing on files that
        /// contain a significant number of delete operations, which can improve query performance
        /// by removing deleted records. If an input is not provided, the default value 1 will
        /// be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_DeleteFileThreshold")]
        public System.Int32? IcebergConfiguration_DeleteFileThreshold { get; set; }
        #endregion
        
        #region Parameter TableOptimizerConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether table optimization is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TableOptimizerConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_GlueConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the Glue connection used for the VPC for the table optimizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableOptimizerConfiguration_VpcConfiguration_GlueConnectionName")]
        public System.String VpcConfiguration_GlueConnectionName { get; set; }
        #endregion
        
        #region Parameter IcebergConfiguration_Location
        /// <summary>
        /// <para>
        /// <para>Specifies a directory in which to look for files (defaults to the table's location).
        /// You may choose a sub-directory rather than the top-level table location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_Location")]
        public System.String IcebergConfiguration_Location { get; set; }
        #endregion
        
        #region Parameter IcebergConfiguration_MinInputFile
        /// <summary>
        /// <para>
        /// <para>The minimum number of data files that must be present in a partition before compaction
        /// will actually compact files. This parameter helps control when compaction is triggered,
        /// preventing unnecessary compaction operations on partitions with few files. If an input
        /// is not provided, the default value 100 will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_MinInputFiles")]
        public System.Int32? IcebergConfiguration_MinInputFile { get; set; }
        #endregion
        
        #region Parameter IcebergConfiguration_NumberOfSnapshotsToRetain
        /// <summary>
        /// <para>
        /// <para>The number of Iceberg snapshots to retain within the retention period. If an input
        /// is not provided, the corresponding Iceberg table configuration field will be used
        /// or if not present, the default value 1 will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_NumberOfSnapshotsToRetain")]
        public System.Int32? IcebergConfiguration_NumberOfSnapshotsToRetain { get; set; }
        #endregion
        
        #region Parameter IcebergConfiguration_OrphanFileRetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The number of days that orphan files should be retained before file deletion. If an
        /// input is not provided, the default value 3 will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_OrphanFileRetentionPeriodInDays")]
        public System.Int32? IcebergConfiguration_OrphanFileRetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter TableOptimizerConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>A role passed by the caller which gives the service permission to update the resources
        /// associated with the optimizer on the caller's behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TableOptimizerConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours
        /// <summary>
        /// <para>
        /// <para>The interval in hours between orphan file deletion job runs. This parameter controls
        /// how frequently the orphan file deletion optimizer will run to clean up orphan files.
        /// The value must be between 3 and 168 hours (7 days). If an input is not provided, the
        /// default value 24 will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours { get; set; }
        #endregion
        
        #region Parameter TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours
        /// <summary>
        /// <para>
        /// <para>The interval in hours between retention job runs. This parameter controls how frequently
        /// the retention optimizer will run to clean up expired snapshots. The value must be
        /// between 3 and 168 hours (7 days). If an input is not provided, the default value 24
        /// will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours { get; set; }
        #endregion
        
        #region Parameter IcebergConfiguration_SnapshotRetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The number of days to retain the Iceberg snapshots. If an input is not provided, the
        /// corresponding Iceberg table configuration field will be used or if not present, the
        /// default value 5 will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_SnapshotRetentionPeriodInDays")]
        public System.Int32? IcebergConfiguration_SnapshotRetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter IcebergConfiguration_Strategy
        /// <summary>
        /// <para>
        /// <para>The strategy to use for compaction. Valid values are:</para><ul><li><para><c>binpack</c>: Combines small files into larger files, typically targeting sizes
        /// over 100MB, while applying any pending deletes. This is the recommended compaction
        /// strategy for most use cases. </para></li><li><para><c>sort</c>: Organizes data based on specified columns which are sorted hierarchically
        /// during compaction, improving query performance for filtered operations. This strategy
        /// is recommended when your queries frequently filter on specific columns. To use this
        /// strategy, you must first define a sort order in your Iceberg table properties using
        /// the <c>sort_order</c> table property.</para></li><li><para><c>z-order</c>: Optimizes data organization by blending multiple attributes into
        /// a single scalar value that can be used for sorting, allowing efficient querying across
        /// multiple dimensions. This strategy is recommended when you need to query data across
        /// multiple dimensions simultaneously. To use this strategy, you must first define a
        /// sort order in your Iceberg table properties using the <c>sort_order</c> table property.
        /// </para></li></ul><para>If an input is not provided, the default value 'binpack' will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_Strategy")]
        [AWSConstantClassSource("Amazon.Glue.CompactionStrategy")]
        public Amazon.Glue.CompactionStrategy IcebergConfiguration_Strategy { get; set; }
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of table optimizer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Glue.TableOptimizerType")]
        public Amazon.Glue.TableOptimizerType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateTableOptimizerResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUETableOptimizer (CreateTableOptimizer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateTableOptimizerResponse, NewGLUETableOptimizerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CatalogId = this.CatalogId;
            #if MODULAR
            if (this.CatalogId == null && ParameterWasBound(nameof(this.CatalogId)))
            {
                WriteWarning("You are passing $null as a value for parameter CatalogId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IcebergConfiguration_DeleteFileThreshold = this.IcebergConfiguration_DeleteFileThreshold;
            context.IcebergConfiguration_MinInputFile = this.IcebergConfiguration_MinInputFile;
            context.IcebergConfiguration_Strategy = this.IcebergConfiguration_Strategy;
            context.TableOptimizerConfiguration_Enabled = this.TableOptimizerConfiguration_Enabled;
            context.IcebergConfiguration_Location = this.IcebergConfiguration_Location;
            context.IcebergConfiguration_OrphanFileRetentionPeriodInDay = this.IcebergConfiguration_OrphanFileRetentionPeriodInDay;
            context.TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours = this.TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours;
            context.IcebergConfiguration_CleanExpiredFile = this.IcebergConfiguration_CleanExpiredFile;
            context.IcebergConfiguration_NumberOfSnapshotsToRetain = this.IcebergConfiguration_NumberOfSnapshotsToRetain;
            context.TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours = this.TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours;
            context.IcebergConfiguration_SnapshotRetentionPeriodInDay = this.IcebergConfiguration_SnapshotRetentionPeriodInDay;
            context.TableOptimizerConfiguration_RoleArn = this.TableOptimizerConfiguration_RoleArn;
            context.VpcConfiguration_GlueConnectionName = this.VpcConfiguration_GlueConnectionName;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.CreateTableOptimizerRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
             // populate TableOptimizerConfiguration
            request.TableOptimizerConfiguration = new Amazon.Glue.Model.TableOptimizerConfiguration();
            System.Boolean? requestTableOptimizerConfiguration_tableOptimizerConfiguration_Enabled = null;
            if (cmdletContext.TableOptimizerConfiguration_Enabled != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_Enabled = cmdletContext.TableOptimizerConfiguration_Enabled.Value;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_Enabled != null)
            {
                request.TableOptimizerConfiguration.Enabled = requestTableOptimizerConfiguration_tableOptimizerConfiguration_Enabled.Value;
            }
            System.String requestTableOptimizerConfiguration_tableOptimizerConfiguration_RoleArn = null;
            if (cmdletContext.TableOptimizerConfiguration_RoleArn != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RoleArn = cmdletContext.TableOptimizerConfiguration_RoleArn;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_RoleArn != null)
            {
                request.TableOptimizerConfiguration.RoleArn = requestTableOptimizerConfiguration_tableOptimizerConfiguration_RoleArn;
            }
            Amazon.Glue.Model.CompactionConfiguration requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration = null;
            
             // populate CompactionConfiguration
            var requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfigurationIsNull = true;
            requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration = new Amazon.Glue.Model.CompactionConfiguration();
            Amazon.Glue.Model.IcebergCompactionConfiguration requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration = null;
            
             // populate IcebergConfiguration
            var requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfigurationIsNull = true;
            requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration = new Amazon.Glue.Model.IcebergCompactionConfiguration();
            System.Int32? requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_DeleteFileThreshold = null;
            if (cmdletContext.IcebergConfiguration_DeleteFileThreshold != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_DeleteFileThreshold = cmdletContext.IcebergConfiguration_DeleteFileThreshold.Value;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_DeleteFileThreshold != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration.DeleteFileThreshold = requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_DeleteFileThreshold.Value;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfigurationIsNull = false;
            }
            System.Int32? requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_MinInputFile = null;
            if (cmdletContext.IcebergConfiguration_MinInputFile != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_MinInputFile = cmdletContext.IcebergConfiguration_MinInputFile.Value;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_MinInputFile != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration.MinInputFiles = requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_MinInputFile.Value;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfigurationIsNull = false;
            }
            Amazon.Glue.CompactionStrategy requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_Strategy = null;
            if (cmdletContext.IcebergConfiguration_Strategy != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_Strategy = cmdletContext.IcebergConfiguration_Strategy;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_Strategy != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration.Strategy = requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration_icebergConfiguration_Strategy;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfigurationIsNull = false;
            }
             // determine if requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration should be set to null
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfigurationIsNull)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration = null;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration.IcebergConfiguration = requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration_tableOptimizerConfiguration_CompactionConfiguration_IcebergConfiguration;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfigurationIsNull = false;
            }
             // determine if requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration should be set to null
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfigurationIsNull)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration = null;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration != null)
            {
                request.TableOptimizerConfiguration.CompactionConfiguration = requestTableOptimizerConfiguration_tableOptimizerConfiguration_CompactionConfiguration;
            }
            Amazon.Glue.Model.OrphanFileDeletionConfiguration requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration = null;
            
             // populate OrphanFileDeletionConfiguration
            var requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfigurationIsNull = true;
            requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration = new Amazon.Glue.Model.OrphanFileDeletionConfiguration();
            Amazon.Glue.Model.IcebergOrphanFileDeletionConfiguration requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration = null;
            
             // populate IcebergConfiguration
            var requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfigurationIsNull = true;
            requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration = new Amazon.Glue.Model.IcebergOrphanFileDeletionConfiguration();
            System.String requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_icebergConfiguration_Location = null;
            if (cmdletContext.IcebergConfiguration_Location != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_icebergConfiguration_Location = cmdletContext.IcebergConfiguration_Location;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_icebergConfiguration_Location != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration.Location = requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_icebergConfiguration_Location;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfigurationIsNull = false;
            }
            System.Int32? requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_icebergConfiguration_OrphanFileRetentionPeriodInDay = null;
            if (cmdletContext.IcebergConfiguration_OrphanFileRetentionPeriodInDay != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_icebergConfiguration_OrphanFileRetentionPeriodInDay = cmdletContext.IcebergConfiguration_OrphanFileRetentionPeriodInDay.Value;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_icebergConfiguration_OrphanFileRetentionPeriodInDay != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration.OrphanFileRetentionPeriodInDays = requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_icebergConfiguration_OrphanFileRetentionPeriodInDay.Value;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfigurationIsNull = false;
            }
            System.Int32? requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours = null;
            if (cmdletContext.TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours = cmdletContext.TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours.Value;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration.RunRateInHours = requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours.Value;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfigurationIsNull = false;
            }
             // determine if requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration should be set to null
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfigurationIsNull)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration = null;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration.IcebergConfiguration = requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfigurationIsNull = false;
            }
             // determine if requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration should be set to null
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfigurationIsNull)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration = null;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration != null)
            {
                request.TableOptimizerConfiguration.OrphanFileDeletionConfiguration = requestTableOptimizerConfiguration_tableOptimizerConfiguration_OrphanFileDeletionConfiguration;
            }
            Amazon.Glue.Model.RetentionConfiguration requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration = null;
            
             // populate RetentionConfiguration
            var requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfigurationIsNull = true;
            requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration = new Amazon.Glue.Model.RetentionConfiguration();
            Amazon.Glue.Model.IcebergRetentionConfiguration requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration = null;
            
             // populate IcebergConfiguration
            var requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfigurationIsNull = true;
            requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration = new Amazon.Glue.Model.IcebergRetentionConfiguration();
            System.Boolean? requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_CleanExpiredFile = null;
            if (cmdletContext.IcebergConfiguration_CleanExpiredFile != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_CleanExpiredFile = cmdletContext.IcebergConfiguration_CleanExpiredFile.Value;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_CleanExpiredFile != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration.CleanExpiredFiles = requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_CleanExpiredFile.Value;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfigurationIsNull = false;
            }
            System.Int32? requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_NumberOfSnapshotsToRetain = null;
            if (cmdletContext.IcebergConfiguration_NumberOfSnapshotsToRetain != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_NumberOfSnapshotsToRetain = cmdletContext.IcebergConfiguration_NumberOfSnapshotsToRetain.Value;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_NumberOfSnapshotsToRetain != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration.NumberOfSnapshotsToRetain = requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_NumberOfSnapshotsToRetain.Value;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfigurationIsNull = false;
            }
            System.Int32? requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours = null;
            if (cmdletContext.TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours = cmdletContext.TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours.Value;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration.RunRateInHours = requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours.Value;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfigurationIsNull = false;
            }
            System.Int32? requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_SnapshotRetentionPeriodInDay = null;
            if (cmdletContext.IcebergConfiguration_SnapshotRetentionPeriodInDay != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_SnapshotRetentionPeriodInDay = cmdletContext.IcebergConfiguration_SnapshotRetentionPeriodInDay.Value;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_SnapshotRetentionPeriodInDay != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration.SnapshotRetentionPeriodInDays = requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_icebergConfiguration_SnapshotRetentionPeriodInDay.Value;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfigurationIsNull = false;
            }
             // determine if requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration should be set to null
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfigurationIsNull)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration = null;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration.IcebergConfiguration = requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration_tableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfigurationIsNull = false;
            }
             // determine if requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration should be set to null
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfigurationIsNull)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration = null;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration != null)
            {
                request.TableOptimizerConfiguration.RetentionConfiguration = requestTableOptimizerConfiguration_tableOptimizerConfiguration_RetentionConfiguration;
            }
            Amazon.Glue.Model.TableOptimizerVpcConfiguration requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration = null;
            
             // populate VpcConfiguration
            var requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfigurationIsNull = true;
            requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration = new Amazon.Glue.Model.TableOptimizerVpcConfiguration();
            System.String requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration_vpcConfiguration_GlueConnectionName = null;
            if (cmdletContext.VpcConfiguration_GlueConnectionName != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration_vpcConfiguration_GlueConnectionName = cmdletContext.VpcConfiguration_GlueConnectionName;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration_vpcConfiguration_GlueConnectionName != null)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration.GlueConnectionName = requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration_vpcConfiguration_GlueConnectionName;
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfigurationIsNull = false;
            }
             // determine if requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration should be set to null
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfigurationIsNull)
            {
                requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration = null;
            }
            if (requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration != null)
            {
                request.TableOptimizerConfiguration.VpcConfiguration = requestTableOptimizerConfiguration_tableOptimizerConfiguration_VpcConfiguration;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.Glue.Model.CreateTableOptimizerResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateTableOptimizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateTableOptimizer");
            try
            {
                #if DESKTOP
                return client.CreateTableOptimizer(request);
                #elif CORECLR
                return client.CreateTableOptimizerAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogId { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String TableName { get; set; }
            public System.Int32? IcebergConfiguration_DeleteFileThreshold { get; set; }
            public System.Int32? IcebergConfiguration_MinInputFile { get; set; }
            public Amazon.Glue.CompactionStrategy IcebergConfiguration_Strategy { get; set; }
            public System.Boolean? TableOptimizerConfiguration_Enabled { get; set; }
            public System.String IcebergConfiguration_Location { get; set; }
            public System.Int32? IcebergConfiguration_OrphanFileRetentionPeriodInDay { get; set; }
            public System.Int32? TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours { get; set; }
            public System.Boolean? IcebergConfiguration_CleanExpiredFile { get; set; }
            public System.Int32? IcebergConfiguration_NumberOfSnapshotsToRetain { get; set; }
            public System.Int32? TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours { get; set; }
            public System.Int32? IcebergConfiguration_SnapshotRetentionPeriodInDay { get; set; }
            public System.String TableOptimizerConfiguration_RoleArn { get; set; }
            public System.String VpcConfiguration_GlueConnectionName { get; set; }
            public Amazon.Glue.TableOptimizerType Type { get; set; }
            public System.Func<Amazon.Glue.Model.CreateTableOptimizerResponse, NewGLUETableOptimizerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
