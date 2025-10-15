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
using Amazon.TimestreamInfluxDB;
using Amazon.TimestreamInfluxDB.Model;

namespace Amazon.PowerShell.Cmdlets.TIDB
{
    /// <summary>
    /// Creates a new Timestream for InfluxDB DB parameter group to associate with DB instances.
    /// </summary>
    [Cmdlet("New", "TIDBDbParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse")]
    [AWSCmdlet("Calls the Amazon Timestream InfluxDB CreateDbParameterGroup API operation.", Operation = new[] {"CreateDbParameterGroup"}, SelectReturnType = typeof(Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse))]
    [AWSCmdletOutput("Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse",
        "This cmdlet returns an Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse object containing multiple properties."
    )]
    public partial class NewTIDBDbParameterGroupCmdlet : AmazonTimestreamInfluxDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InfluxDBv3Core_ExecMemPoolBytes_Absolute
        /// <summary>
        /// <para>
        /// <para>Absolute long for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ExecMemPoolBytes_Absolute")]
        public System.Int64? InfluxDBv3Core_ExecMemPoolBytes_Absolute { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_ForceSnapshotMemThreshold_Absolute
        /// <summary>
        /// <para>
        /// <para>Absolute long for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ForceSnapshotMemThreshold_Absolute")]
        public System.Int64? InfluxDBv3Core_ForceSnapshotMemThreshold_Absolute { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_ParquetMemCacheSize_Absolute
        /// <summary>
        /// <para>
        /// <para>Absolute long for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ParquetMemCacheSize_Absolute")]
        public System.Int64? InfluxDBv3Core_ParquetMemCacheSize_Absolute { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ExecMemPoolBytes_Absolute
        /// <summary>
        /// <para>
        /// <para>Absolute long for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ExecMemPoolBytes_Absolute")]
        public System.Int64? InfluxDBv3Enterprise_ExecMemPoolBytes_Absolute { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute
        /// <summary>
        /// <para>
        /// <para>Absolute long for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute")]
        public System.Int64? InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ParquetMemCacheSize_Absolute
        /// <summary>
        /// <para>
        /// <para>Absolute long for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ParquetMemCacheSize_Absolute")]
        public System.Int64? InfluxDBv3Enterprise_ParquetMemCacheSize_Absolute { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_CompactionMaxNumFilesPerPlan
        /// <summary>
        /// <para>
        /// <para>Sets the maximum number of files included in any compaction plan.</para><para>Default: 500</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CompactionMaxNumFilesPerPlan")]
        public System.Int32? InfluxDBv3Enterprise_CompactionMaxNumFilesPerPlan { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_CompactionMultiplier
        /// <summary>
        /// <para>
        /// <para>Specifies a comma-separated list of multiples defining the duration of each level
        /// of compaction. The number of elements in the list determines the number of compaction
        /// levels. The first element specifies the duration of the first level (gen3); subsequent
        /// levels are multiples of the previous level.</para><para>Default: 3,4,6,5</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CompactionMultipliers")]
        public System.String InfluxDBv3Enterprise_CompactionMultiplier { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_CompactionRowLimit
        /// <summary>
        /// <para>
        /// <para>Specifies the soft limit for the number of rows per file that the compactor writes.
        /// The compactor may write more rows than this limit.</para><para>Default: 1000000</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CompactionRowLimit")]
        public System.Int32? InfluxDBv3Enterprise_CompactionRowLimit { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionConfig
        /// <summary>
        /// <para>
        /// <para>Provides custom configuration to DataFusion as a comma-separated list of key:value
        /// pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionConfig")]
        public System.String InfluxDBv3Core_DataFusionConfig { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionConfig
        /// <summary>
        /// <para>
        /// <para>Provides custom configuration to DataFusion as a comma-separated list of key:value
        /// pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionConfig")]
        public System.String InfluxDBv3Enterprise_DataFusionConfig { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionMaxParquetFanout
        /// <summary>
        /// <para>
        /// <para>When multiple parquet files are required in a sorted way (deduplication for example),
        /// specifies the maximum fanout.</para><para>Default: 1000</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionMaxParquetFanout")]
        public System.Int32? InfluxDBv3Core_DataFusionMaxParquetFanout { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionMaxParquetFanout
        /// <summary>
        /// <para>
        /// <para>When multiple parquet files are required in a sorted way (deduplication for example),
        /// specifies the maximum fanout.</para><para>Default: 1000</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionMaxParquetFanout")]
        public System.Int32? InfluxDBv3Enterprise_DataFusionMaxParquetFanout { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionNumThread
        /// <summary>
        /// <para>
        /// <para>Sets the maximum number of DataFusion runtime threads to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionNumThreads")]
        public System.Int32? InfluxDBv3Core_DataFusionNumThread { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionNumThread
        /// <summary>
        /// <para>
        /// <para>Sets the maximum number of DataFusion runtime threads to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionNumThreads")]
        public System.Int32? InfluxDBv3Enterprise_DataFusionNumThread { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionRuntimeDisableLifoSlot
        /// <summary>
        /// <para>
        /// <para>Disables the LIFO slot of the DataFusion runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionRuntimeDisableLifoSlot")]
        public System.Boolean? InfluxDBv3Core_DataFusionRuntimeDisableLifoSlot { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot
        /// <summary>
        /// <para>
        /// <para>Disables the LIFO slot of the DataFusion runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot")]
        public System.Boolean? InfluxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionRuntimeEventInterval
        /// <summary>
        /// <para>
        /// <para>Sets the number of scheduler ticks after which the scheduler of the DataFusion tokio
        /// runtime polls for external events–for example: timers, I/O.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionRuntimeEventInterval")]
        public System.Int32? InfluxDBv3Core_DataFusionRuntimeEventInterval { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionRuntimeEventInterval
        /// <summary>
        /// <para>
        /// <para>Sets the number of scheduler ticks after which the scheduler of the DataFusion tokio
        /// runtime polls for external events–for example: timers, I/O.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionRuntimeEventInterval")]
        public System.Int32? InfluxDBv3Enterprise_DataFusionRuntimeEventInterval { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionRuntimeGlobalQueueInterval
        /// <summary>
        /// <para>
        /// <para>Sets the number of scheduler ticks after which the scheduler of the DataFusion runtime
        /// polls the global task queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionRuntimeGlobalQueueInterval")]
        public System.Int32? InfluxDBv3Core_DataFusionRuntimeGlobalQueueInterval { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval
        /// <summary>
        /// <para>
        /// <para>Sets the number of scheduler ticks after which the scheduler of the DataFusion runtime
        /// polls the global task queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval")]
        public System.Int32? InfluxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionRuntimeMaxBlockingThread
        /// <summary>
        /// <para>
        /// <para>Specifies the limit for additional threads spawned by the DataFusion runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionRuntimeMaxBlockingThreads")]
        public System.Int32? InfluxDBv3Core_DataFusionRuntimeMaxBlockingThread { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread
        /// <summary>
        /// <para>
        /// <para>Specifies the limit for additional threads spawned by the DataFusion runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionRuntimeMaxBlockingThreads")]
        public System.Int32? InfluxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick
        /// <summary>
        /// <para>
        /// <para>Configures the maximum number of events processed per tick by the tokio DataFusion
        /// runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick")]
        public System.Int32? InfluxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick
        /// <summary>
        /// <para>
        /// <para>Configures the maximum number of events processed per tick by the tokio DataFusion
        /// runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick")]
        public System.Int32? InfluxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionRuntimeThreadPriority
        /// <summary>
        /// <para>
        /// <para>Sets the thread priority for tokio DataFusion runtime workers.</para><para>Default: 10</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionRuntimeThreadPriority")]
        public System.Int32? InfluxDBv3Core_DataFusionRuntimeThreadPriority { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionRuntimeThreadPriority
        /// <summary>
        /// <para>
        /// <para>Sets the thread priority for tokio DataFusion runtime workers.</para><para>Default: 10</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadPriority")]
        public System.Int32? InfluxDBv3Enterprise_DataFusionRuntimeThreadPriority { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionRuntimeType
        /// <summary>
        /// <para>
        /// <para>Specifies the DataFusion tokio runtime type.</para><para>Default: multi-thread</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionRuntimeType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DataFusionRuntimeType")]
        public Amazon.TimestreamInfluxDB.DataFusionRuntimeType InfluxDBv3Core_DataFusionRuntimeType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionRuntimeType
        /// <summary>
        /// <para>
        /// <para>Specifies the DataFusion tokio runtime type.</para><para>Default: multi-thread</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionRuntimeType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DataFusionRuntimeType")]
        public Amazon.TimestreamInfluxDB.DataFusionRuntimeType InfluxDBv3Enterprise_DataFusionRuntimeType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionUseCachedParquetLoader
        /// <summary>
        /// <para>
        /// <para>Uses a cached parquet loader when reading parquet files from the object store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionUseCachedParquetLoader")]
        public System.Boolean? InfluxDBv3Core_DataFusionUseCachedParquetLoader { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionUseCachedParquetLoader
        /// <summary>
        /// <para>
        /// <para>Uses a cached parquet loader when reading parquet files from the object store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionUseCachedParquetLoader")]
        public System.Boolean? InfluxDBv3Enterprise_DataFusionUseCachedParquetLoader { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DedicatedCompactor
        /// <summary>
        /// <para>
        /// <para>Specifies if the compactor instance should be a standalone instance or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DedicatedCompactor")]
        public System.Boolean? InfluxDBv3Enterprise_DedicatedCompactor { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the DB parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DisableParquetMemCache
        /// <summary>
        /// <para>
        /// <para>Disables the in-memory Parquet cache. By default, the cache is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DisableParquetMemCache")]
        public System.Boolean? InfluxDBv3Core_DisableParquetMemCache { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DisableParquetMemCache
        /// <summary>
        /// <para>
        /// <para>Disables the in-memory Parquet cache. By default, the cache is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DisableParquetMemCache")]
        public System.Boolean? InfluxDBv3Enterprise_DisableParquetMemCache { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DistinctValueCacheDisableFromHistory
        /// <summary>
        /// <para>
        /// <para>Disables populating the distinct value cache from historical data. If disabled, the
        /// cache is still populated with data from the write-ahead log (WAL).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DistinctValueCacheDisableFromHistory")]
        public System.Boolean? InfluxDBv3Enterprise_DistinctValueCacheDisableFromHistory { get; set; }
        #endregion
        
        #region Parameter HttpIdleTimeout_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_HttpIdleTimeout_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType HttpIdleTimeout_DurationType { get; set; }
        #endregion
        
        #region Parameter HttpReadHeaderTimeout_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_HttpReadHeaderTimeout_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType HttpReadHeaderTimeout_DurationType { get; set; }
        #endregion
        
        #region Parameter HttpReadTimeout_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_HttpReadTimeout_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType HttpReadTimeout_DurationType { get; set; }
        #endregion
        
        #region Parameter HttpWriteTimeout_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_HttpWriteTimeout_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType HttpWriteTimeout_DurationType { get; set; }
        #endregion
        
        #region Parameter StorageCacheSnapshotWriteColdDuration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType StorageCacheSnapshotWriteColdDuration_DurationType { get; set; }
        #endregion
        
        #region Parameter StorageCompactFullWriteColdDuration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageCompactFullWriteColdDuration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType StorageCompactFullWriteColdDuration_DurationType { get; set; }
        #endregion
        
        #region Parameter StorageRetentionCheckInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageRetentionCheckInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType StorageRetentionCheckInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter StorageWalMaxWriteDelay_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageWalMaxWriteDelay_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType StorageWalMaxWriteDelay_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DeleteGracePeriod_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DeleteGracePeriod_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_DeleteGracePeriod_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_Gen1Duration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_Gen1Duration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_Gen1Duration_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_Gen1LookbackDuration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_Gen1LookbackDuration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_Gen1LookbackDuration_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_HardDeleteDefaultDuration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_HardDeleteDefaultDuration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_HardDeleteDefaultDuration_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_LastCacheEvictionInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_LastCacheEvictionInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_LastCacheEvictionInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_PreemptiveCacheAge_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_PreemptiveCacheAge_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_PreemptiveCacheAge_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_RetentionCheckInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_RetentionCheckInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_RetentionCheckInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter CatalogSyncInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CatalogSyncInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType CatalogSyncInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter CompactionCheckInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CompactionCheckInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType CompactionCheckInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter CompactionCleanupWait_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CompactionCleanupWait_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType CompactionCleanupWait_DurationType { get; set; }
        #endregion
        
        #region Parameter CompactionGen2Duration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CompactionGen2Duration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType CompactionGen2Duration_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DeleteGracePeriod_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DeleteGracePeriod_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_DeleteGracePeriod_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_Gen1Duration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_Gen1Duration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_Gen1Duration_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType { get; set; }
        #endregion
        
        #region Parameter ReplicationInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ReplicationInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType ReplicationInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_RetentionCheckInterval_DurationType
        /// <summary>
        /// <para>
        /// <para>The type of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_RetentionCheckInterval_DurationType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DurationType")]
        public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_RetentionCheckInterval_DurationType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_FluxLogEnabled
        /// <summary>
        /// <para>
        /// <para>Include option to show detailed logs for Flux queries.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_FluxLogEnabled")]
        public System.Boolean? InfluxDBv2_FluxLogEnabled { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_InfluxqlMaxSelectBucket
        /// <summary>
        /// <para>
        /// <para>Maximum number of group by time buckets a SELECT statement can create. 0 allows an
        /// unlimited number of buckets.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_InfluxqlMaxSelectBuckets")]
        public System.Int64? InfluxDBv2_InfluxqlMaxSelectBucket { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_InfluxqlMaxSelectPoint
        /// <summary>
        /// <para>
        /// <para>Maximum number of points a SELECT statement can process. 0 allows an unlimited number
        /// of points. InfluxDB checks the point count every second (so queries exceeding the
        /// maximum aren’t immediately aborted).</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_InfluxqlMaxSelectPoint")]
        public System.Int64? InfluxDBv2_InfluxqlMaxSelectPoint { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_InfluxqlMaxSelectSeries
        /// <summary>
        /// <para>
        /// <para>Maximum number of series a SELECT statement can return. 0 allows an unlimited number
        /// of series.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_InfluxqlMaxSelectSeries")]
        public System.Int64? InfluxDBv2_InfluxqlMaxSelectSeries { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_IngestQueryInstance
        /// <summary>
        /// <para>
        /// <para>Specifies number of instances in the DbCluster which can both ingest and query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_IngestQueryInstances")]
        public System.Int32? InfluxDBv3Enterprise_IngestQueryInstance { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_LastValueCacheDisableFromHistory
        /// <summary>
        /// <para>
        /// <para>Disables populating the last-N-value cache from historical data. If disabled, the
        /// cache is still populated with data from the write-ahead log (WAL).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_LastValueCacheDisableFromHistory")]
        public System.Boolean? InfluxDBv3Enterprise_LastValueCacheDisableFromHistory { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_LogFilter
        /// <summary>
        /// <para>
        /// <para>Sets the filter directive for logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_LogFilter")]
        public System.String InfluxDBv3Core_LogFilter { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_LogFilter
        /// <summary>
        /// <para>
        /// <para>Sets the filter directive for logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_LogFilter")]
        public System.String InfluxDBv3Enterprise_LogFilter { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_LogFormat
        /// <summary>
        /// <para>
        /// <para>Defines the message format for logs.</para><para>Default: full</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_LogFormat")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.LogFormats")]
        public Amazon.TimestreamInfluxDB.LogFormats InfluxDBv3Core_LogFormat { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_LogFormat
        /// <summary>
        /// <para>
        /// <para>Defines the message format for logs.</para><para>Default: full</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_LogFormat")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.LogFormats")]
        public Amazon.TimestreamInfluxDB.LogFormats InfluxDBv3Enterprise_LogFormat { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_LogLevel
        /// <summary>
        /// <para>
        /// <para>Log output level. InfluxDB outputs log entries with severity levels greater than or
        /// equal to the level specified.</para><para>Default: info</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_LogLevel")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.LogLevel")]
        public Amazon.TimestreamInfluxDB.LogLevel InfluxDBv2_LogLevel { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_MaxHttpRequestSize
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum size of HTTP requests.</para><para>Default: 10485760</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_MaxHttpRequestSize")]
        public System.Int64? InfluxDBv3Core_MaxHttpRequestSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_MaxHttpRequestSize
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum size of HTTP requests.</para><para>Default: 10485760</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_MaxHttpRequestSize")]
        public System.Int64? InfluxDBv3Enterprise_MaxHttpRequestSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_MetricsDisabled
        /// <summary>
        /// <para>
        /// <para>Disable the HTTP /metrics endpoint which exposes <a href="https://docs.influxdata.com/influxdb/v2/reference/internals/metrics/">internal
        /// InfluxDB metrics</a>.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_MetricsDisabled")]
        public System.Boolean? InfluxDBv2_MetricsDisabled { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group. The name must be unique per customer and per region.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_NoTask
        /// <summary>
        /// <para>
        /// <para>Disable the task scheduler. If problematic tasks prevent InfluxDB from starting, use
        /// this option to start InfluxDB without scheduling or executing tasks.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_NoTasks")]
        public System.Boolean? InfluxDBv2_NoTask { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_ParquetMemCachePrunePercentage
        /// <summary>
        /// <para>
        /// <para>Specifies the percentage of entries to prune during a prune operation on the in-memory
        /// Parquet cache.</para><para>Default: 0.1</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ParquetMemCachePrunePercentage")]
        public System.Single? InfluxDBv3Core_ParquetMemCachePrunePercentage { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ParquetMemCachePrunePercentage
        /// <summary>
        /// <para>
        /// <para>Specifies the percentage of entries to prune during a prune operation on the in-memory
        /// Parquet cache.</para><para>Default: 0.1</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ParquetMemCachePrunePercentage")]
        public System.Single? InfluxDBv3Enterprise_ParquetMemCachePrunePercentage { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_ExecMemPoolBytes_Percent
        /// <summary>
        /// <para>
        /// <para>Percent for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ExecMemPoolBytes_Percent")]
        public System.String InfluxDBv3Core_ExecMemPoolBytes_Percent { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_ForceSnapshotMemThreshold_Percent
        /// <summary>
        /// <para>
        /// <para>Percent for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ForceSnapshotMemThreshold_Percent")]
        public System.String InfluxDBv3Core_ForceSnapshotMemThreshold_Percent { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_ParquetMemCacheSize_Percent
        /// <summary>
        /// <para>
        /// <para>Percent for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ParquetMemCacheSize_Percent")]
        public System.String InfluxDBv3Core_ParquetMemCacheSize_Percent { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ExecMemPoolBytes_Percent
        /// <summary>
        /// <para>
        /// <para>Percent for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ExecMemPoolBytes_Percent")]
        public System.String InfluxDBv3Enterprise_ExecMemPoolBytes_Percent { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Percent
        /// <summary>
        /// <para>
        /// <para>Percent for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Percent")]
        public System.String InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Percent { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ParquetMemCacheSize_Percent
        /// <summary>
        /// <para>
        /// <para>Percent for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ParquetMemCacheSize_Percent")]
        public System.String InfluxDBv3Enterprise_ParquetMemCacheSize_Percent { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_PprofDisabled
        /// <summary>
        /// <para>
        /// <para>Disable the /debug/pprof HTTP endpoint. This endpoint provides runtime profiling data
        /// and can be helpful when debugging.</para><para>Default: true</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_PprofDisabled")]
        public System.Boolean? InfluxDBv2_PprofDisabled { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_QueryConcurrency
        /// <summary>
        /// <para>
        /// <para>Number of queries allowed to execute concurrently. Setting to 0 allows an unlimited
        /// number of concurrent queries.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_QueryConcurrency")]
        public System.Int32? InfluxDBv2_QueryConcurrency { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_QueryFileLimit
        /// <summary>
        /// <para>
        /// <para>Limits the number of Parquet files a query can access. If a query attempts to read
        /// more than this limit, InfluxDB 3 returns an error.</para><para>Default: 432</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_QueryFileLimit")]
        public System.Int32? InfluxDBv3Core_QueryFileLimit { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_QueryFileLimit
        /// <summary>
        /// <para>
        /// <para>Limits the number of Parquet files a query can access. If a query attempts to read
        /// more than this limit, InfluxDB 3 returns an error.</para><para>Default: 432</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_QueryFileLimit")]
        public System.Int32? InfluxDBv3Enterprise_QueryFileLimit { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_QueryInitialMemoryByte
        /// <summary>
        /// <para>
        /// <para>Initial bytes of memory allocated for a query.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_QueryInitialMemoryBytes")]
        public System.Int64? InfluxDBv2_QueryInitialMemoryByte { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_QueryLogSize
        /// <summary>
        /// <para>
        /// <para>Defines the size of the query log. Up to this many queries remain in the log before
        /// older queries are evicted to make room for new ones.</para><para>Default: 1000</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_QueryLogSize")]
        public System.Int32? InfluxDBv3Core_QueryLogSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_QueryLogSize
        /// <summary>
        /// <para>
        /// <para>Defines the size of the query log. Up to this many queries remain in the log before
        /// older queries are evicted to make room for new ones.</para><para>Default: 1000</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_QueryLogSize")]
        public System.Int32? InfluxDBv3Enterprise_QueryLogSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_QueryMaxMemoryByte
        /// <summary>
        /// <para>
        /// <para>Maximum number of queries allowed in execution queue. When queue limit is reached,
        /// new queries are rejected. Setting to 0 allows an unlimited number of queries in the
        /// queue.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_QueryMaxMemoryBytes")]
        public System.Int64? InfluxDBv2_QueryMaxMemoryByte { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_QueryMemoryByte
        /// <summary>
        /// <para>
        /// <para>Maximum bytes of memory allowed for a single query. Must be greater or equal to queryInitialMemoryBytes.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_QueryMemoryBytes")]
        public System.Int64? InfluxDBv2_QueryMemoryByte { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_QueryOnlyInstance
        /// <summary>
        /// <para>
        /// <para>Specifies number of instances in the DbCluster which can only query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_QueryOnlyInstances")]
        public System.Int32? InfluxDBv3Enterprise_QueryOnlyInstance { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_QueryQueueSize
        /// <summary>
        /// <para>
        /// <para>Maximum number of queries allowed in execution queue. When queue limit is reached,
        /// new queries are rejected. Setting to 0 allows an unlimited number of queries in the
        /// queue.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_QueryQueueSize")]
        public System.Int32? InfluxDBv2_QueryQueueSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_SessionLength
        /// <summary>
        /// <para>
        /// <para>Specifies the Time to Live (TTL) in minutes for newly created user sessions.</para><para>Default: 60</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_SessionLength")]
        public System.Int32? InfluxDBv2_SessionLength { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_SessionRenewDisabled
        /// <summary>
        /// <para>
        /// <para>Disables automatically extending a user’s session TTL on each request. By default,
        /// every request sets the session’s expiration time to five minutes from now. When disabled,
        /// sessions expire after the specified <a href="https://docs.influxdata.com/influxdb/v2/reference/config-options/#session-length">session
        /// length</a> and the user is redirected to the login page, even if recently active.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_SessionRenewDisabled")]
        public System.Boolean? InfluxDBv2_SessionRenewDisabled { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_SnapshottedWalFilesToKeep
        /// <summary>
        /// <para>
        /// <para>Specifies the number of snapshotted WAL files to retain in the object store. Flushing
        /// the WAL files does not clear the WAL files immediately; they are deleted when the
        /// number of snapshotted WAL files exceeds this number.</para><para>Default: 300</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_SnapshottedWalFilesToKeep")]
        public System.Int32? InfluxDBv3Core_SnapshottedWalFilesToKeep { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_SnapshottedWalFilesToKeep
        /// <summary>
        /// <para>
        /// <para>Specifies the number of snapshotted WAL files to retain in the object store. Flushing
        /// the WAL files does not clear the WAL files immediately; they are deleted when the
        /// number of snapshotted WAL files exceeds this number.</para><para>Default: 300</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_SnapshottedWalFilesToKeep")]
        public System.Int32? InfluxDBv3Enterprise_SnapshottedWalFilesToKeep { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_StorageCacheMaxMemorySize
        /// <summary>
        /// <para>
        /// <para>Maximum size (in bytes) a shard’s cache can reach before it starts rejecting writes.
        /// Must be greater than storageCacheSnapShotMemorySize and lower than instance’s total
        /// memory capacity. We recommend setting it to below 15% of the total memory capacity.</para><para>Default: 1073741824</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageCacheMaxMemorySize")]
        public System.Int64? InfluxDBv2_StorageCacheMaxMemorySize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_StorageCacheSnapshotMemorySize
        /// <summary>
        /// <para>
        /// <para>Size (in bytes) at which the storage engine will snapshot the cache and write it to
        /// a TSM file to make more memory available. Must not be greater than storageCacheMaxMemorySize.</para><para>Default: 26214400</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageCacheSnapshotMemorySize")]
        public System.Int64? InfluxDBv2_StorageCacheSnapshotMemorySize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_StorageCompactThroughputBurst
        /// <summary>
        /// <para>
        /// <para>Rate limit (in bytes per second) that TSM compactions can write to disk.</para><para>Default: 50331648</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageCompactThroughputBurst")]
        public System.Int64? InfluxDBv2_StorageCompactThroughputBurst { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_StorageMaxConcurrentCompaction
        /// <summary>
        /// <para>
        /// <para>Maximum number of full and level compactions that can run concurrently. A value of
        /// 0 results in 50% of runtime.GOMAXPROCS(0) used at runtime. Any number greater than
        /// zero limits compactions to that value. This setting does not apply to cache snapshotting.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageMaxConcurrentCompactions")]
        public System.Int32? InfluxDBv2_StorageMaxConcurrentCompaction { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_StorageMaxIndexLogFileSize
        /// <summary>
        /// <para>
        /// <para>Size (in bytes) at which an index write-ahead log (WAL) file will compact into an
        /// index file. Lower sizes will cause log files to be compacted more quickly and result
        /// in lower heap usage at the expense of write throughput.</para><para>Default: 1048576</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageMaxIndexLogFileSize")]
        public System.Int64? InfluxDBv2_StorageMaxIndexLogFileSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_StorageNoValidateFieldSize
        /// <summary>
        /// <para>
        /// <para>Skip field size validation on incoming write requests.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageNoValidateFieldSize")]
        public System.Boolean? InfluxDBv2_StorageNoValidateFieldSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction
        /// <summary>
        /// <para>
        /// <para>Maximum number of snapshot compactions that can run concurrently across all series
        /// partitions in a database.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompactions")]
        public System.Int32? InfluxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_StorageSeriesIdSetCacheSize
        /// <summary>
        /// <para>
        /// <para>Size of the internal cache used in the TSI index to store previously calculated series
        /// results. Cached results are returned quickly rather than needing to be recalculated
        /// when a subsequent query with the same tag key/value predicate is executed. Setting
        /// this value to 0 will disable the cache and may decrease query performance.</para><para>Default: 100</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageSeriesIdSetCacheSize")]
        public System.Int64? InfluxDBv2_StorageSeriesIdSetCacheSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_StorageWalMaxConcurrentWrite
        /// <summary>
        /// <para>
        /// <para>Maximum number writes to the WAL directory to attempt at the same time. Setting this
        /// value to 0 results in number of processing units available x2.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageWalMaxConcurrentWrites")]
        public System.Int32? InfluxDBv2_StorageWalMaxConcurrentWrite { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_TableIndexCacheConcurrencyLimit
        /// <summary>
        /// <para>
        /// <para>Limits the concurrency level for table index cache operations.</para><para>Default: 8</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_TableIndexCacheConcurrencyLimit")]
        public System.Int32? InfluxDBv3Core_TableIndexCacheConcurrencyLimit { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_TableIndexCacheConcurrencyLimit
        /// <summary>
        /// <para>
        /// <para>Limits the concurrency level for table index cache operations.</para><para>Default: 8</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_TableIndexCacheConcurrencyLimit")]
        public System.Int32? InfluxDBv3Enterprise_TableIndexCacheConcurrencyLimit { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_TableIndexCacheMaxEntry
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of entries in the table index cache.</para><para>Default: 1000</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_TableIndexCacheMaxEntries")]
        public System.Int32? InfluxDBv3Core_TableIndexCacheMaxEntry { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_TableIndexCacheMaxEntry
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of entries in the table index cache.</para><para>Default: 1000</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_TableIndexCacheMaxEntries")]
        public System.Int32? InfluxDBv3Enterprise_TableIndexCacheMaxEntry { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the DB parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_TracingType
        /// <summary>
        /// <para>
        /// <para>Enable tracing in InfluxDB and specifies the tracing type. Tracing is disabled by
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_TracingType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.TracingType")]
        public Amazon.TimestreamInfluxDB.TracingType InfluxDBv2_TracingType { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_UiDisabled
        /// <summary>
        /// <para>
        /// <para>Disable the InfluxDB user interface (UI). The UI is enabled by default.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_UiDisabled")]
        public System.Boolean? InfluxDBv2_UiDisabled { get; set; }
        #endregion
        
        #region Parameter HttpIdleTimeout_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_HttpIdleTimeout_Value")]
        public System.Int64? HttpIdleTimeout_Value { get; set; }
        #endregion
        
        #region Parameter HttpReadHeaderTimeout_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_HttpReadHeaderTimeout_Value")]
        public System.Int64? HttpReadHeaderTimeout_Value { get; set; }
        #endregion
        
        #region Parameter HttpReadTimeout_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_HttpReadTimeout_Value")]
        public System.Int64? HttpReadTimeout_Value { get; set; }
        #endregion
        
        #region Parameter HttpWriteTimeout_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_HttpWriteTimeout_Value")]
        public System.Int64? HttpWriteTimeout_Value { get; set; }
        #endregion
        
        #region Parameter StorageCacheSnapshotWriteColdDuration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration_Value")]
        public System.Int64? StorageCacheSnapshotWriteColdDuration_Value { get; set; }
        #endregion
        
        #region Parameter StorageCompactFullWriteColdDuration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageCompactFullWriteColdDuration_Value")]
        public System.Int64? StorageCompactFullWriteColdDuration_Value { get; set; }
        #endregion
        
        #region Parameter StorageRetentionCheckInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageRetentionCheckInterval_Value")]
        public System.Int64? StorageRetentionCheckInterval_Value { get; set; }
        #endregion
        
        #region Parameter StorageWalMaxWriteDelay_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_StorageWalMaxWriteDelay_Value")]
        public System.Int64? StorageWalMaxWriteDelay_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value")]
        public System.Int64? InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DeleteGracePeriod_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DeleteGracePeriod_Value")]
        public System.Int64? InfluxDBv3Core_DeleteGracePeriod_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_DistinctCacheEvictionInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_DistinctCacheEvictionInterval_Value")]
        public System.Int64? InfluxDBv3Core_DistinctCacheEvictionInterval_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_Gen1Duration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_Gen1Duration_Value")]
        public System.Int64? InfluxDBv3Core_Gen1Duration_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_Gen1LookbackDuration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_Gen1LookbackDuration_Value")]
        public System.Int64? InfluxDBv3Core_Gen1LookbackDuration_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_HardDeleteDefaultDuration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_HardDeleteDefaultDuration_Value")]
        public System.Int64? InfluxDBv3Core_HardDeleteDefaultDuration_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_LastCacheEvictionInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_LastCacheEvictionInterval_Value")]
        public System.Int64? InfluxDBv3Core_LastCacheEvictionInterval_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_ParquetMemCachePruneInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ParquetMemCachePruneInterval_Value")]
        public System.Int64? InfluxDBv3Core_ParquetMemCachePruneInterval_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_ParquetMemCacheQueryPathDuration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration_Value")]
        public System.Int64? InfluxDBv3Core_ParquetMemCacheQueryPathDuration_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_PreemptiveCacheAge_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_PreemptiveCacheAge_Value")]
        public System.Int64? InfluxDBv3Core_PreemptiveCacheAge_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_RetentionCheckInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_RetentionCheckInterval_Value")]
        public System.Int64? InfluxDBv3Core_RetentionCheckInterval_Value { get; set; }
        #endregion
        
        #region Parameter CatalogSyncInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CatalogSyncInterval_Value")]
        public System.Int64? CatalogSyncInterval_Value { get; set; }
        #endregion
        
        #region Parameter CompactionCheckInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CompactionCheckInterval_Value")]
        public System.Int64? CompactionCheckInterval_Value { get; set; }
        #endregion
        
        #region Parameter CompactionCleanupWait_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CompactionCleanupWait_Value")]
        public System.Int64? CompactionCleanupWait_Value { get; set; }
        #endregion
        
        #region Parameter CompactionGen2Duration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_CompactionGen2Duration_Value")]
        public System.Int64? CompactionGen2Duration_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value")]
        public System.Int64? InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DeleteGracePeriod_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DeleteGracePeriod_Value")]
        public System.Int64? InfluxDBv3Enterprise_DeleteGracePeriod_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_DistinctCacheEvictionInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval_Value")]
        public System.Int64? InfluxDBv3Enterprise_DistinctCacheEvictionInterval_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_Gen1Duration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_Gen1Duration_Value")]
        public System.Int64? InfluxDBv3Enterprise_Gen1Duration_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_Gen1LookbackDuration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_Gen1LookbackDuration_Value")]
        public System.Int64? InfluxDBv3Enterprise_Gen1LookbackDuration_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_HardDeleteDefaultDuration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration_Value")]
        public System.Int64? InfluxDBv3Enterprise_HardDeleteDefaultDuration_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_LastCacheEvictionInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval_Value")]
        public System.Int64? InfluxDBv3Enterprise_LastCacheEvictionInterval_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ParquetMemCachePruneInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval_Value")]
        public System.Int64? InfluxDBv3Enterprise_ParquetMemCachePruneInterval_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value")]
        public System.Int64? InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_PreemptiveCacheAge_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_PreemptiveCacheAge_Value")]
        public System.Int64? InfluxDBv3Enterprise_PreemptiveCacheAge_Value { get; set; }
        #endregion
        
        #region Parameter ReplicationInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_ReplicationInterval_Value")]
        public System.Int64? ReplicationInterval_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_RetentionCheckInterval_Value
        /// <summary>
        /// <para>
        /// <para>The value of duration for InfluxDB parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_RetentionCheckInterval_Value")]
        public System.Int64? InfluxDBv3Enterprise_RetentionCheckInterval_Value { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_WalMaxWriteBufferSize
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of write requests that can be buffered before a flush
        /// must be executed and succeed.</para><para>Default: 100000</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_WalMaxWriteBufferSize")]
        public System.Int32? InfluxDBv3Core_WalMaxWriteBufferSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_WalMaxWriteBufferSize
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of write requests that can be buffered before a flush
        /// must be executed and succeed.</para><para>Default: 100000</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_WalMaxWriteBufferSize")]
        public System.Int32? InfluxDBv3Enterprise_WalMaxWriteBufferSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_WalReplayConcurrencyLimit
        /// <summary>
        /// <para>
        /// <para>Concurrency limit during WAL replay. Setting this number too high can lead to OOM.
        /// The default is dynamically determined.</para><para>Default: max(num_cpus, 10)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_WalReplayConcurrencyLimit")]
        public System.Int32? InfluxDBv3Core_WalReplayConcurrencyLimit { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_WalReplayConcurrencyLimit
        /// <summary>
        /// <para>
        /// <para>Concurrency limit during WAL replay. Setting this number too high can lead to OOM.
        /// The default is dynamically determined.</para><para>Default: max(num_cpus, 10)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_WalReplayConcurrencyLimit")]
        public System.Int32? InfluxDBv3Enterprise_WalReplayConcurrencyLimit { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_WalReplayFailOnError
        /// <summary>
        /// <para>
        /// <para>Determines whether WAL replay should fail when encountering errors.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_WalReplayFailOnError")]
        public System.Boolean? InfluxDBv3Core_WalReplayFailOnError { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_WalReplayFailOnError
        /// <summary>
        /// <para>
        /// <para>Determines whether WAL replay should fail when encountering errors.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_WalReplayFailOnError")]
        public System.Boolean? InfluxDBv3Enterprise_WalReplayFailOnError { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Core_WalSnapshotSize
        /// <summary>
        /// <para>
        /// <para>Defines the number of WAL files to attempt to remove in a snapshot. This, multiplied
        /// by the interval, determines how often snapshots are taken.</para><para>Default: 600</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Core_WalSnapshotSize")]
        public System.Int32? InfluxDBv3Core_WalSnapshotSize { get; set; }
        #endregion
        
        #region Parameter InfluxDBv3Enterprise_WalSnapshotSize
        /// <summary>
        /// <para>
        /// <para>Defines the number of WAL files to attempt to remove in a snapshot. This, multiplied
        /// by the interval, determines how often snapshots are taken.</para><para>Default: 600</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv3Enterprise_WalSnapshotSize")]
        public System.Int32? InfluxDBv3Enterprise_WalSnapshotSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TIDBDbParameterGroup (CreateDbParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse, NewTIDBDbParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InfluxDBv2_FluxLogEnabled = this.InfluxDBv2_FluxLogEnabled;
            context.HttpIdleTimeout_DurationType = this.HttpIdleTimeout_DurationType;
            context.HttpIdleTimeout_Value = this.HttpIdleTimeout_Value;
            context.HttpReadHeaderTimeout_DurationType = this.HttpReadHeaderTimeout_DurationType;
            context.HttpReadHeaderTimeout_Value = this.HttpReadHeaderTimeout_Value;
            context.HttpReadTimeout_DurationType = this.HttpReadTimeout_DurationType;
            context.HttpReadTimeout_Value = this.HttpReadTimeout_Value;
            context.HttpWriteTimeout_DurationType = this.HttpWriteTimeout_DurationType;
            context.HttpWriteTimeout_Value = this.HttpWriteTimeout_Value;
            context.InfluxDBv2_InfluxqlMaxSelectBucket = this.InfluxDBv2_InfluxqlMaxSelectBucket;
            context.InfluxDBv2_InfluxqlMaxSelectPoint = this.InfluxDBv2_InfluxqlMaxSelectPoint;
            context.InfluxDBv2_InfluxqlMaxSelectSeries = this.InfluxDBv2_InfluxqlMaxSelectSeries;
            context.InfluxDBv2_LogLevel = this.InfluxDBv2_LogLevel;
            context.InfluxDBv2_MetricsDisabled = this.InfluxDBv2_MetricsDisabled;
            context.InfluxDBv2_NoTask = this.InfluxDBv2_NoTask;
            context.InfluxDBv2_PprofDisabled = this.InfluxDBv2_PprofDisabled;
            context.InfluxDBv2_QueryConcurrency = this.InfluxDBv2_QueryConcurrency;
            context.InfluxDBv2_QueryInitialMemoryByte = this.InfluxDBv2_QueryInitialMemoryByte;
            context.InfluxDBv2_QueryMaxMemoryByte = this.InfluxDBv2_QueryMaxMemoryByte;
            context.InfluxDBv2_QueryMemoryByte = this.InfluxDBv2_QueryMemoryByte;
            context.InfluxDBv2_QueryQueueSize = this.InfluxDBv2_QueryQueueSize;
            context.InfluxDBv2_SessionLength = this.InfluxDBv2_SessionLength;
            context.InfluxDBv2_SessionRenewDisabled = this.InfluxDBv2_SessionRenewDisabled;
            context.InfluxDBv2_StorageCacheMaxMemorySize = this.InfluxDBv2_StorageCacheMaxMemorySize;
            context.InfluxDBv2_StorageCacheSnapshotMemorySize = this.InfluxDBv2_StorageCacheSnapshotMemorySize;
            context.StorageCacheSnapshotWriteColdDuration_DurationType = this.StorageCacheSnapshotWriteColdDuration_DurationType;
            context.StorageCacheSnapshotWriteColdDuration_Value = this.StorageCacheSnapshotWriteColdDuration_Value;
            context.StorageCompactFullWriteColdDuration_DurationType = this.StorageCompactFullWriteColdDuration_DurationType;
            context.StorageCompactFullWriteColdDuration_Value = this.StorageCompactFullWriteColdDuration_Value;
            context.InfluxDBv2_StorageCompactThroughputBurst = this.InfluxDBv2_StorageCompactThroughputBurst;
            context.InfluxDBv2_StorageMaxConcurrentCompaction = this.InfluxDBv2_StorageMaxConcurrentCompaction;
            context.InfluxDBv2_StorageMaxIndexLogFileSize = this.InfluxDBv2_StorageMaxIndexLogFileSize;
            context.InfluxDBv2_StorageNoValidateFieldSize = this.InfluxDBv2_StorageNoValidateFieldSize;
            context.StorageRetentionCheckInterval_DurationType = this.StorageRetentionCheckInterval_DurationType;
            context.StorageRetentionCheckInterval_Value = this.StorageRetentionCheckInterval_Value;
            context.InfluxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction = this.InfluxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction;
            context.InfluxDBv2_StorageSeriesIdSetCacheSize = this.InfluxDBv2_StorageSeriesIdSetCacheSize;
            context.InfluxDBv2_StorageWalMaxConcurrentWrite = this.InfluxDBv2_StorageWalMaxConcurrentWrite;
            context.StorageWalMaxWriteDelay_DurationType = this.StorageWalMaxWriteDelay_DurationType;
            context.StorageWalMaxWriteDelay_Value = this.StorageWalMaxWriteDelay_Value;
            context.InfluxDBv2_TracingType = this.InfluxDBv2_TracingType;
            context.InfluxDBv2_UiDisabled = this.InfluxDBv2_UiDisabled;
            context.InfluxDBv3Core_DataFusionConfig = this.InfluxDBv3Core_DataFusionConfig;
            context.InfluxDBv3Core_DataFusionMaxParquetFanout = this.InfluxDBv3Core_DataFusionMaxParquetFanout;
            context.InfluxDBv3Core_DataFusionNumThread = this.InfluxDBv3Core_DataFusionNumThread;
            context.InfluxDBv3Core_DataFusionRuntimeDisableLifoSlot = this.InfluxDBv3Core_DataFusionRuntimeDisableLifoSlot;
            context.InfluxDBv3Core_DataFusionRuntimeEventInterval = this.InfluxDBv3Core_DataFusionRuntimeEventInterval;
            context.InfluxDBv3Core_DataFusionRuntimeGlobalQueueInterval = this.InfluxDBv3Core_DataFusionRuntimeGlobalQueueInterval;
            context.InfluxDBv3Core_DataFusionRuntimeMaxBlockingThread = this.InfluxDBv3Core_DataFusionRuntimeMaxBlockingThread;
            context.InfluxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick = this.InfluxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick;
            context.InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType = this.InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType;
            context.InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value = this.InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value;
            context.InfluxDBv3Core_DataFusionRuntimeThreadPriority = this.InfluxDBv3Core_DataFusionRuntimeThreadPriority;
            context.InfluxDBv3Core_DataFusionRuntimeType = this.InfluxDBv3Core_DataFusionRuntimeType;
            context.InfluxDBv3Core_DataFusionUseCachedParquetLoader = this.InfluxDBv3Core_DataFusionUseCachedParquetLoader;
            context.InfluxDBv3Core_DeleteGracePeriod_DurationType = this.InfluxDBv3Core_DeleteGracePeriod_DurationType;
            context.InfluxDBv3Core_DeleteGracePeriod_Value = this.InfluxDBv3Core_DeleteGracePeriod_Value;
            context.InfluxDBv3Core_DisableParquetMemCache = this.InfluxDBv3Core_DisableParquetMemCache;
            context.InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType = this.InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType;
            context.InfluxDBv3Core_DistinctCacheEvictionInterval_Value = this.InfluxDBv3Core_DistinctCacheEvictionInterval_Value;
            context.InfluxDBv3Core_ExecMemPoolBytes_Absolute = this.InfluxDBv3Core_ExecMemPoolBytes_Absolute;
            context.InfluxDBv3Core_ExecMemPoolBytes_Percent = this.InfluxDBv3Core_ExecMemPoolBytes_Percent;
            context.InfluxDBv3Core_ForceSnapshotMemThreshold_Absolute = this.InfluxDBv3Core_ForceSnapshotMemThreshold_Absolute;
            context.InfluxDBv3Core_ForceSnapshotMemThreshold_Percent = this.InfluxDBv3Core_ForceSnapshotMemThreshold_Percent;
            context.InfluxDBv3Core_Gen1Duration_DurationType = this.InfluxDBv3Core_Gen1Duration_DurationType;
            context.InfluxDBv3Core_Gen1Duration_Value = this.InfluxDBv3Core_Gen1Duration_Value;
            context.InfluxDBv3Core_Gen1LookbackDuration_DurationType = this.InfluxDBv3Core_Gen1LookbackDuration_DurationType;
            context.InfluxDBv3Core_Gen1LookbackDuration_Value = this.InfluxDBv3Core_Gen1LookbackDuration_Value;
            context.InfluxDBv3Core_HardDeleteDefaultDuration_DurationType = this.InfluxDBv3Core_HardDeleteDefaultDuration_DurationType;
            context.InfluxDBv3Core_HardDeleteDefaultDuration_Value = this.InfluxDBv3Core_HardDeleteDefaultDuration_Value;
            context.InfluxDBv3Core_LastCacheEvictionInterval_DurationType = this.InfluxDBv3Core_LastCacheEvictionInterval_DurationType;
            context.InfluxDBv3Core_LastCacheEvictionInterval_Value = this.InfluxDBv3Core_LastCacheEvictionInterval_Value;
            context.InfluxDBv3Core_LogFilter = this.InfluxDBv3Core_LogFilter;
            context.InfluxDBv3Core_LogFormat = this.InfluxDBv3Core_LogFormat;
            context.InfluxDBv3Core_MaxHttpRequestSize = this.InfluxDBv3Core_MaxHttpRequestSize;
            context.InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType = this.InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType;
            context.InfluxDBv3Core_ParquetMemCachePruneInterval_Value = this.InfluxDBv3Core_ParquetMemCachePruneInterval_Value;
            context.InfluxDBv3Core_ParquetMemCachePrunePercentage = this.InfluxDBv3Core_ParquetMemCachePrunePercentage;
            context.InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType = this.InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType;
            context.InfluxDBv3Core_ParquetMemCacheQueryPathDuration_Value = this.InfluxDBv3Core_ParquetMemCacheQueryPathDuration_Value;
            context.InfluxDBv3Core_ParquetMemCacheSize_Absolute = this.InfluxDBv3Core_ParquetMemCacheSize_Absolute;
            context.InfluxDBv3Core_ParquetMemCacheSize_Percent = this.InfluxDBv3Core_ParquetMemCacheSize_Percent;
            context.InfluxDBv3Core_PreemptiveCacheAge_DurationType = this.InfluxDBv3Core_PreemptiveCacheAge_DurationType;
            context.InfluxDBv3Core_PreemptiveCacheAge_Value = this.InfluxDBv3Core_PreemptiveCacheAge_Value;
            context.InfluxDBv3Core_QueryFileLimit = this.InfluxDBv3Core_QueryFileLimit;
            context.InfluxDBv3Core_QueryLogSize = this.InfluxDBv3Core_QueryLogSize;
            context.InfluxDBv3Core_RetentionCheckInterval_DurationType = this.InfluxDBv3Core_RetentionCheckInterval_DurationType;
            context.InfluxDBv3Core_RetentionCheckInterval_Value = this.InfluxDBv3Core_RetentionCheckInterval_Value;
            context.InfluxDBv3Core_SnapshottedWalFilesToKeep = this.InfluxDBv3Core_SnapshottedWalFilesToKeep;
            context.InfluxDBv3Core_TableIndexCacheConcurrencyLimit = this.InfluxDBv3Core_TableIndexCacheConcurrencyLimit;
            context.InfluxDBv3Core_TableIndexCacheMaxEntry = this.InfluxDBv3Core_TableIndexCacheMaxEntry;
            context.InfluxDBv3Core_WalMaxWriteBufferSize = this.InfluxDBv3Core_WalMaxWriteBufferSize;
            context.InfluxDBv3Core_WalReplayConcurrencyLimit = this.InfluxDBv3Core_WalReplayConcurrencyLimit;
            context.InfluxDBv3Core_WalReplayFailOnError = this.InfluxDBv3Core_WalReplayFailOnError;
            context.InfluxDBv3Core_WalSnapshotSize = this.InfluxDBv3Core_WalSnapshotSize;
            context.CatalogSyncInterval_DurationType = this.CatalogSyncInterval_DurationType;
            context.CatalogSyncInterval_Value = this.CatalogSyncInterval_Value;
            context.CompactionCheckInterval_DurationType = this.CompactionCheckInterval_DurationType;
            context.CompactionCheckInterval_Value = this.CompactionCheckInterval_Value;
            context.CompactionCleanupWait_DurationType = this.CompactionCleanupWait_DurationType;
            context.CompactionCleanupWait_Value = this.CompactionCleanupWait_Value;
            context.CompactionGen2Duration_DurationType = this.CompactionGen2Duration_DurationType;
            context.CompactionGen2Duration_Value = this.CompactionGen2Duration_Value;
            context.InfluxDBv3Enterprise_CompactionMaxNumFilesPerPlan = this.InfluxDBv3Enterprise_CompactionMaxNumFilesPerPlan;
            context.InfluxDBv3Enterprise_CompactionMultiplier = this.InfluxDBv3Enterprise_CompactionMultiplier;
            context.InfluxDBv3Enterprise_CompactionRowLimit = this.InfluxDBv3Enterprise_CompactionRowLimit;
            context.InfluxDBv3Enterprise_DataFusionConfig = this.InfluxDBv3Enterprise_DataFusionConfig;
            context.InfluxDBv3Enterprise_DataFusionMaxParquetFanout = this.InfluxDBv3Enterprise_DataFusionMaxParquetFanout;
            context.InfluxDBv3Enterprise_DataFusionNumThread = this.InfluxDBv3Enterprise_DataFusionNumThread;
            context.InfluxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot = this.InfluxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot;
            context.InfluxDBv3Enterprise_DataFusionRuntimeEventInterval = this.InfluxDBv3Enterprise_DataFusionRuntimeEventInterval;
            context.InfluxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval = this.InfluxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval;
            context.InfluxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread = this.InfluxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread;
            context.InfluxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick = this.InfluxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick;
            context.InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType = this.InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType;
            context.InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value = this.InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value;
            context.InfluxDBv3Enterprise_DataFusionRuntimeThreadPriority = this.InfluxDBv3Enterprise_DataFusionRuntimeThreadPriority;
            context.InfluxDBv3Enterprise_DataFusionRuntimeType = this.InfluxDBv3Enterprise_DataFusionRuntimeType;
            context.InfluxDBv3Enterprise_DataFusionUseCachedParquetLoader = this.InfluxDBv3Enterprise_DataFusionUseCachedParquetLoader;
            context.InfluxDBv3Enterprise_DedicatedCompactor = this.InfluxDBv3Enterprise_DedicatedCompactor;
            context.InfluxDBv3Enterprise_DeleteGracePeriod_DurationType = this.InfluxDBv3Enterprise_DeleteGracePeriod_DurationType;
            context.InfluxDBv3Enterprise_DeleteGracePeriod_Value = this.InfluxDBv3Enterprise_DeleteGracePeriod_Value;
            context.InfluxDBv3Enterprise_DisableParquetMemCache = this.InfluxDBv3Enterprise_DisableParquetMemCache;
            context.InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType = this.InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType;
            context.InfluxDBv3Enterprise_DistinctCacheEvictionInterval_Value = this.InfluxDBv3Enterprise_DistinctCacheEvictionInterval_Value;
            context.InfluxDBv3Enterprise_DistinctValueCacheDisableFromHistory = this.InfluxDBv3Enterprise_DistinctValueCacheDisableFromHistory;
            context.InfluxDBv3Enterprise_ExecMemPoolBytes_Absolute = this.InfluxDBv3Enterprise_ExecMemPoolBytes_Absolute;
            context.InfluxDBv3Enterprise_ExecMemPoolBytes_Percent = this.InfluxDBv3Enterprise_ExecMemPoolBytes_Percent;
            context.InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute = this.InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute;
            context.InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Percent = this.InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Percent;
            context.InfluxDBv3Enterprise_Gen1Duration_DurationType = this.InfluxDBv3Enterprise_Gen1Duration_DurationType;
            context.InfluxDBv3Enterprise_Gen1Duration_Value = this.InfluxDBv3Enterprise_Gen1Duration_Value;
            context.InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType = this.InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType;
            context.InfluxDBv3Enterprise_Gen1LookbackDuration_Value = this.InfluxDBv3Enterprise_Gen1LookbackDuration_Value;
            context.InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType = this.InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType;
            context.InfluxDBv3Enterprise_HardDeleteDefaultDuration_Value = this.InfluxDBv3Enterprise_HardDeleteDefaultDuration_Value;
            context.InfluxDBv3Enterprise_IngestQueryInstance = this.InfluxDBv3Enterprise_IngestQueryInstance;
            context.InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType = this.InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType;
            context.InfluxDBv3Enterprise_LastCacheEvictionInterval_Value = this.InfluxDBv3Enterprise_LastCacheEvictionInterval_Value;
            context.InfluxDBv3Enterprise_LastValueCacheDisableFromHistory = this.InfluxDBv3Enterprise_LastValueCacheDisableFromHistory;
            context.InfluxDBv3Enterprise_LogFilter = this.InfluxDBv3Enterprise_LogFilter;
            context.InfluxDBv3Enterprise_LogFormat = this.InfluxDBv3Enterprise_LogFormat;
            context.InfluxDBv3Enterprise_MaxHttpRequestSize = this.InfluxDBv3Enterprise_MaxHttpRequestSize;
            context.InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType = this.InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType;
            context.InfluxDBv3Enterprise_ParquetMemCachePruneInterval_Value = this.InfluxDBv3Enterprise_ParquetMemCachePruneInterval_Value;
            context.InfluxDBv3Enterprise_ParquetMemCachePrunePercentage = this.InfluxDBv3Enterprise_ParquetMemCachePrunePercentage;
            context.InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType = this.InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType;
            context.InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value = this.InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value;
            context.InfluxDBv3Enterprise_ParquetMemCacheSize_Absolute = this.InfluxDBv3Enterprise_ParquetMemCacheSize_Absolute;
            context.InfluxDBv3Enterprise_ParquetMemCacheSize_Percent = this.InfluxDBv3Enterprise_ParquetMemCacheSize_Percent;
            context.InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType = this.InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType;
            context.InfluxDBv3Enterprise_PreemptiveCacheAge_Value = this.InfluxDBv3Enterprise_PreemptiveCacheAge_Value;
            context.InfluxDBv3Enterprise_QueryFileLimit = this.InfluxDBv3Enterprise_QueryFileLimit;
            context.InfluxDBv3Enterprise_QueryLogSize = this.InfluxDBv3Enterprise_QueryLogSize;
            context.InfluxDBv3Enterprise_QueryOnlyInstance = this.InfluxDBv3Enterprise_QueryOnlyInstance;
            context.ReplicationInterval_DurationType = this.ReplicationInterval_DurationType;
            context.ReplicationInterval_Value = this.ReplicationInterval_Value;
            context.InfluxDBv3Enterprise_RetentionCheckInterval_DurationType = this.InfluxDBv3Enterprise_RetentionCheckInterval_DurationType;
            context.InfluxDBv3Enterprise_RetentionCheckInterval_Value = this.InfluxDBv3Enterprise_RetentionCheckInterval_Value;
            context.InfluxDBv3Enterprise_SnapshottedWalFilesToKeep = this.InfluxDBv3Enterprise_SnapshottedWalFilesToKeep;
            context.InfluxDBv3Enterprise_TableIndexCacheConcurrencyLimit = this.InfluxDBv3Enterprise_TableIndexCacheConcurrencyLimit;
            context.InfluxDBv3Enterprise_TableIndexCacheMaxEntry = this.InfluxDBv3Enterprise_TableIndexCacheMaxEntry;
            context.InfluxDBv3Enterprise_WalMaxWriteBufferSize = this.InfluxDBv3Enterprise_WalMaxWriteBufferSize;
            context.InfluxDBv3Enterprise_WalReplayConcurrencyLimit = this.InfluxDBv3Enterprise_WalReplayConcurrencyLimit;
            context.InfluxDBv3Enterprise_WalReplayFailOnError = this.InfluxDBv3Enterprise_WalReplayFailOnError;
            context.InfluxDBv3Enterprise_WalSnapshotSize = this.InfluxDBv3Enterprise_WalSnapshotSize;
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
            var request = new Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Parameters
            var requestParametersIsNull = true;
            request.Parameters = new Amazon.TimestreamInfluxDB.Model.Parameters();
            Amazon.TimestreamInfluxDB.Model.InfluxDBv2Parameters requestParameters_parameters_InfluxDBv2 = null;
            
             // populate InfluxDBv2
            var requestParameters_parameters_InfluxDBv2IsNull = true;
            requestParameters_parameters_InfluxDBv2 = new Amazon.TimestreamInfluxDB.Model.InfluxDBv2Parameters();
            System.Boolean? requestParameters_parameters_InfluxDBv2_influxDBv2_FluxLogEnabled = null;
            if (cmdletContext.InfluxDBv2_FluxLogEnabled != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_FluxLogEnabled = cmdletContext.InfluxDBv2_FluxLogEnabled.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_FluxLogEnabled != null)
            {
                requestParameters_parameters_InfluxDBv2.FluxLogEnabled = requestParameters_parameters_InfluxDBv2_influxDBv2_FluxLogEnabled.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectBucket = null;
            if (cmdletContext.InfluxDBv2_InfluxqlMaxSelectBucket != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectBucket = cmdletContext.InfluxDBv2_InfluxqlMaxSelectBucket.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectBucket != null)
            {
                requestParameters_parameters_InfluxDBv2.InfluxqlMaxSelectBuckets = requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectBucket.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectPoint = null;
            if (cmdletContext.InfluxDBv2_InfluxqlMaxSelectPoint != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectPoint = cmdletContext.InfluxDBv2_InfluxqlMaxSelectPoint.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectPoint != null)
            {
                requestParameters_parameters_InfluxDBv2.InfluxqlMaxSelectPoint = requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectPoint.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectSeries = null;
            if (cmdletContext.InfluxDBv2_InfluxqlMaxSelectSeries != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectSeries = cmdletContext.InfluxDBv2_InfluxqlMaxSelectSeries.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectSeries != null)
            {
                requestParameters_parameters_InfluxDBv2.InfluxqlMaxSelectSeries = requestParameters_parameters_InfluxDBv2_influxDBv2_InfluxqlMaxSelectSeries.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.LogLevel requestParameters_parameters_InfluxDBv2_influxDBv2_LogLevel = null;
            if (cmdletContext.InfluxDBv2_LogLevel != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_LogLevel = cmdletContext.InfluxDBv2_LogLevel;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_LogLevel != null)
            {
                requestParameters_parameters_InfluxDBv2.LogLevel = requestParameters_parameters_InfluxDBv2_influxDBv2_LogLevel;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv2_influxDBv2_MetricsDisabled = null;
            if (cmdletContext.InfluxDBv2_MetricsDisabled != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_MetricsDisabled = cmdletContext.InfluxDBv2_MetricsDisabled.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_MetricsDisabled != null)
            {
                requestParameters_parameters_InfluxDBv2.MetricsDisabled = requestParameters_parameters_InfluxDBv2_influxDBv2_MetricsDisabled.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv2_influxDBv2_NoTask = null;
            if (cmdletContext.InfluxDBv2_NoTask != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_NoTask = cmdletContext.InfluxDBv2_NoTask.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_NoTask != null)
            {
                requestParameters_parameters_InfluxDBv2.NoTasks = requestParameters_parameters_InfluxDBv2_influxDBv2_NoTask.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv2_influxDBv2_PprofDisabled = null;
            if (cmdletContext.InfluxDBv2_PprofDisabled != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_PprofDisabled = cmdletContext.InfluxDBv2_PprofDisabled.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_PprofDisabled != null)
            {
                requestParameters_parameters_InfluxDBv2.PprofDisabled = requestParameters_parameters_InfluxDBv2_influxDBv2_PprofDisabled.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv2_influxDBv2_QueryConcurrency = null;
            if (cmdletContext.InfluxDBv2_QueryConcurrency != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_QueryConcurrency = cmdletContext.InfluxDBv2_QueryConcurrency.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_QueryConcurrency != null)
            {
                requestParameters_parameters_InfluxDBv2.QueryConcurrency = requestParameters_parameters_InfluxDBv2_influxDBv2_QueryConcurrency.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_QueryInitialMemoryByte = null;
            if (cmdletContext.InfluxDBv2_QueryInitialMemoryByte != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_QueryInitialMemoryByte = cmdletContext.InfluxDBv2_QueryInitialMemoryByte.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_QueryInitialMemoryByte != null)
            {
                requestParameters_parameters_InfluxDBv2.QueryInitialMemoryBytes = requestParameters_parameters_InfluxDBv2_influxDBv2_QueryInitialMemoryByte.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_QueryMaxMemoryByte = null;
            if (cmdletContext.InfluxDBv2_QueryMaxMemoryByte != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_QueryMaxMemoryByte = cmdletContext.InfluxDBv2_QueryMaxMemoryByte.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_QueryMaxMemoryByte != null)
            {
                requestParameters_parameters_InfluxDBv2.QueryMaxMemoryBytes = requestParameters_parameters_InfluxDBv2_influxDBv2_QueryMaxMemoryByte.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_QueryMemoryByte = null;
            if (cmdletContext.InfluxDBv2_QueryMemoryByte != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_QueryMemoryByte = cmdletContext.InfluxDBv2_QueryMemoryByte.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_QueryMemoryByte != null)
            {
                requestParameters_parameters_InfluxDBv2.QueryMemoryBytes = requestParameters_parameters_InfluxDBv2_influxDBv2_QueryMemoryByte.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv2_influxDBv2_QueryQueueSize = null;
            if (cmdletContext.InfluxDBv2_QueryQueueSize != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_QueryQueueSize = cmdletContext.InfluxDBv2_QueryQueueSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_QueryQueueSize != null)
            {
                requestParameters_parameters_InfluxDBv2.QueryQueueSize = requestParameters_parameters_InfluxDBv2_influxDBv2_QueryQueueSize.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv2_influxDBv2_SessionLength = null;
            if (cmdletContext.InfluxDBv2_SessionLength != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_SessionLength = cmdletContext.InfluxDBv2_SessionLength.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_SessionLength != null)
            {
                requestParameters_parameters_InfluxDBv2.SessionLength = requestParameters_parameters_InfluxDBv2_influxDBv2_SessionLength.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv2_influxDBv2_SessionRenewDisabled = null;
            if (cmdletContext.InfluxDBv2_SessionRenewDisabled != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_SessionRenewDisabled = cmdletContext.InfluxDBv2_SessionRenewDisabled.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_SessionRenewDisabled != null)
            {
                requestParameters_parameters_InfluxDBv2.SessionRenewDisabled = requestParameters_parameters_InfluxDBv2_influxDBv2_SessionRenewDisabled.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCacheMaxMemorySize = null;
            if (cmdletContext.InfluxDBv2_StorageCacheMaxMemorySize != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCacheMaxMemorySize = cmdletContext.InfluxDBv2_StorageCacheMaxMemorySize.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCacheMaxMemorySize != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageCacheMaxMemorySize = requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCacheMaxMemorySize.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCacheSnapshotMemorySize = null;
            if (cmdletContext.InfluxDBv2_StorageCacheSnapshotMemorySize != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCacheSnapshotMemorySize = cmdletContext.InfluxDBv2_StorageCacheSnapshotMemorySize.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCacheSnapshotMemorySize != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageCacheSnapshotMemorySize = requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCacheSnapshotMemorySize.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCompactThroughputBurst = null;
            if (cmdletContext.InfluxDBv2_StorageCompactThroughputBurst != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCompactThroughputBurst = cmdletContext.InfluxDBv2_StorageCompactThroughputBurst.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCompactThroughputBurst != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageCompactThroughputBurst = requestParameters_parameters_InfluxDBv2_influxDBv2_StorageCompactThroughputBurst.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv2_influxDBv2_StorageMaxConcurrentCompaction = null;
            if (cmdletContext.InfluxDBv2_StorageMaxConcurrentCompaction != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_StorageMaxConcurrentCompaction = cmdletContext.InfluxDBv2_StorageMaxConcurrentCompaction.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_StorageMaxConcurrentCompaction != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageMaxConcurrentCompactions = requestParameters_parameters_InfluxDBv2_influxDBv2_StorageMaxConcurrentCompaction.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_StorageMaxIndexLogFileSize = null;
            if (cmdletContext.InfluxDBv2_StorageMaxIndexLogFileSize != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_StorageMaxIndexLogFileSize = cmdletContext.InfluxDBv2_StorageMaxIndexLogFileSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_StorageMaxIndexLogFileSize != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageMaxIndexLogFileSize = requestParameters_parameters_InfluxDBv2_influxDBv2_StorageMaxIndexLogFileSize.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv2_influxDBv2_StorageNoValidateFieldSize = null;
            if (cmdletContext.InfluxDBv2_StorageNoValidateFieldSize != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_StorageNoValidateFieldSize = cmdletContext.InfluxDBv2_StorageNoValidateFieldSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_StorageNoValidateFieldSize != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageNoValidateFieldSize = requestParameters_parameters_InfluxDBv2_influxDBv2_StorageNoValidateFieldSize.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv2_influxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction = null;
            if (cmdletContext.InfluxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction = cmdletContext.InfluxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageSeriesFileMaxConcurrentSnapshotCompactions = requestParameters_parameters_InfluxDBv2_influxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_influxDBv2_StorageSeriesIdSetCacheSize = null;
            if (cmdletContext.InfluxDBv2_StorageSeriesIdSetCacheSize != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_StorageSeriesIdSetCacheSize = cmdletContext.InfluxDBv2_StorageSeriesIdSetCacheSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_StorageSeriesIdSetCacheSize != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageSeriesIdSetCacheSize = requestParameters_parameters_InfluxDBv2_influxDBv2_StorageSeriesIdSetCacheSize.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv2_influxDBv2_StorageWalMaxConcurrentWrite = null;
            if (cmdletContext.InfluxDBv2_StorageWalMaxConcurrentWrite != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_StorageWalMaxConcurrentWrite = cmdletContext.InfluxDBv2_StorageWalMaxConcurrentWrite.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_StorageWalMaxConcurrentWrite != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageWalMaxConcurrentWrites = requestParameters_parameters_InfluxDBv2_influxDBv2_StorageWalMaxConcurrentWrite.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.TracingType requestParameters_parameters_InfluxDBv2_influxDBv2_TracingType = null;
            if (cmdletContext.InfluxDBv2_TracingType != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_TracingType = cmdletContext.InfluxDBv2_TracingType;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_TracingType != null)
            {
                requestParameters_parameters_InfluxDBv2.TracingType = requestParameters_parameters_InfluxDBv2_influxDBv2_TracingType;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv2_influxDBv2_UiDisabled = null;
            if (cmdletContext.InfluxDBv2_UiDisabled != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_UiDisabled = cmdletContext.InfluxDBv2_UiDisabled.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_UiDisabled != null)
            {
                requestParameters_parameters_InfluxDBv2.UiDisabled = requestParameters_parameters_InfluxDBv2_influxDBv2_UiDisabled.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout = null;
            
             // populate HttpIdleTimeout
            var requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeoutIsNull = true;
            requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout_httpIdleTimeout_DurationType = null;
            if (cmdletContext.HttpIdleTimeout_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout_httpIdleTimeout_DurationType = cmdletContext.HttpIdleTimeout_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout_httpIdleTimeout_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout.DurationType = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout_httpIdleTimeout_DurationType;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeoutIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout_httpIdleTimeout_Value = null;
            if (cmdletContext.HttpIdleTimeout_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout_httpIdleTimeout_Value = cmdletContext.HttpIdleTimeout_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout_httpIdleTimeout_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout.Value = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout_httpIdleTimeout_Value.Value;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeoutIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout should be set to null
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeoutIsNull)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout = null;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout != null)
            {
                requestParameters_parameters_InfluxDBv2.HttpIdleTimeout = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpIdleTimeout;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout = null;
            
             // populate HttpReadHeaderTimeout
            var requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeoutIsNull = true;
            requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout_httpReadHeaderTimeout_DurationType = null;
            if (cmdletContext.HttpReadHeaderTimeout_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout_httpReadHeaderTimeout_DurationType = cmdletContext.HttpReadHeaderTimeout_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout_httpReadHeaderTimeout_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout.DurationType = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout_httpReadHeaderTimeout_DurationType;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeoutIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout_httpReadHeaderTimeout_Value = null;
            if (cmdletContext.HttpReadHeaderTimeout_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout_httpReadHeaderTimeout_Value = cmdletContext.HttpReadHeaderTimeout_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout_httpReadHeaderTimeout_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout.Value = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout_httpReadHeaderTimeout_Value.Value;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeoutIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout should be set to null
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeoutIsNull)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout = null;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout != null)
            {
                requestParameters_parameters_InfluxDBv2.HttpReadHeaderTimeout = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadHeaderTimeout;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout = null;
            
             // populate HttpReadTimeout
            var requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeoutIsNull = true;
            requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout_httpReadTimeout_DurationType = null;
            if (cmdletContext.HttpReadTimeout_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout_httpReadTimeout_DurationType = cmdletContext.HttpReadTimeout_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout_httpReadTimeout_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout.DurationType = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout_httpReadTimeout_DurationType;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeoutIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout_httpReadTimeout_Value = null;
            if (cmdletContext.HttpReadTimeout_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout_httpReadTimeout_Value = cmdletContext.HttpReadTimeout_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout_httpReadTimeout_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout.Value = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout_httpReadTimeout_Value.Value;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeoutIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout should be set to null
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeoutIsNull)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout = null;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout != null)
            {
                requestParameters_parameters_InfluxDBv2.HttpReadTimeout = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpReadTimeout;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout = null;
            
             // populate HttpWriteTimeout
            var requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeoutIsNull = true;
            requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout_httpWriteTimeout_DurationType = null;
            if (cmdletContext.HttpWriteTimeout_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout_httpWriteTimeout_DurationType = cmdletContext.HttpWriteTimeout_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout_httpWriteTimeout_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout.DurationType = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout_httpWriteTimeout_DurationType;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeoutIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout_httpWriteTimeout_Value = null;
            if (cmdletContext.HttpWriteTimeout_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout_httpWriteTimeout_Value = cmdletContext.HttpWriteTimeout_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout_httpWriteTimeout_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout.Value = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout_httpWriteTimeout_Value.Value;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeoutIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout should be set to null
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeoutIsNull)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout = null;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout != null)
            {
                requestParameters_parameters_InfluxDBv2.HttpWriteTimeout = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_HttpWriteTimeout;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration = null;
            
             // populate StorageCacheSnapshotWriteColdDuration
            var requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDurationIsNull = true;
            requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration_storageCacheSnapshotWriteColdDuration_DurationType = null;
            if (cmdletContext.StorageCacheSnapshotWriteColdDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration_storageCacheSnapshotWriteColdDuration_DurationType = cmdletContext.StorageCacheSnapshotWriteColdDuration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration_storageCacheSnapshotWriteColdDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration.DurationType = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration_storageCacheSnapshotWriteColdDuration_DurationType;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration_storageCacheSnapshotWriteColdDuration_Value = null;
            if (cmdletContext.StorageCacheSnapshotWriteColdDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration_storageCacheSnapshotWriteColdDuration_Value = cmdletContext.StorageCacheSnapshotWriteColdDuration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration_storageCacheSnapshotWriteColdDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration.Value = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration_storageCacheSnapshotWriteColdDuration_Value.Value;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration should be set to null
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDurationIsNull)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration = null;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageCacheSnapshotWriteColdDuration = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCacheSnapshotWriteColdDuration;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration = null;
            
             // populate StorageCompactFullWriteColdDuration
            var requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDurationIsNull = true;
            requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration_storageCompactFullWriteColdDuration_DurationType = null;
            if (cmdletContext.StorageCompactFullWriteColdDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration_storageCompactFullWriteColdDuration_DurationType = cmdletContext.StorageCompactFullWriteColdDuration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration_storageCompactFullWriteColdDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration.DurationType = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration_storageCompactFullWriteColdDuration_DurationType;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration_storageCompactFullWriteColdDuration_Value = null;
            if (cmdletContext.StorageCompactFullWriteColdDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration_storageCompactFullWriteColdDuration_Value = cmdletContext.StorageCompactFullWriteColdDuration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration_storageCompactFullWriteColdDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration.Value = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration_storageCompactFullWriteColdDuration_Value.Value;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration should be set to null
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDurationIsNull)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration = null;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageCompactFullWriteColdDuration = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageCompactFullWriteColdDuration;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval = null;
            
             // populate StorageRetentionCheckInterval
            var requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval_storageRetentionCheckInterval_DurationType = null;
            if (cmdletContext.StorageRetentionCheckInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval_storageRetentionCheckInterval_DurationType = cmdletContext.StorageRetentionCheckInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval_storageRetentionCheckInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval.DurationType = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval_storageRetentionCheckInterval_DurationType;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval_storageRetentionCheckInterval_Value = null;
            if (cmdletContext.StorageRetentionCheckInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval_storageRetentionCheckInterval_Value = cmdletContext.StorageRetentionCheckInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval_storageRetentionCheckInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval.Value = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval_storageRetentionCheckInterval_Value.Value;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval should be set to null
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageRetentionCheckInterval = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageRetentionCheckInterval;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay = null;
            
             // populate StorageWalMaxWriteDelay
            var requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelayIsNull = true;
            requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay_storageWalMaxWriteDelay_DurationType = null;
            if (cmdletContext.StorageWalMaxWriteDelay_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay_storageWalMaxWriteDelay_DurationType = cmdletContext.StorageWalMaxWriteDelay_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay_storageWalMaxWriteDelay_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay.DurationType = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay_storageWalMaxWriteDelay_DurationType;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelayIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay_storageWalMaxWriteDelay_Value = null;
            if (cmdletContext.StorageWalMaxWriteDelay_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay_storageWalMaxWriteDelay_Value = cmdletContext.StorageWalMaxWriteDelay_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay_storageWalMaxWriteDelay_Value != null)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay.Value = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay_storageWalMaxWriteDelay_Value.Value;
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelayIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay should be set to null
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelayIsNull)
            {
                requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay = null;
            }
            if (requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay != null)
            {
                requestParameters_parameters_InfluxDBv2.StorageWalMaxWriteDelay = requestParameters_parameters_InfluxDBv2_parameters_InfluxDBv2_StorageWalMaxWriteDelay;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv2 should be set to null
            if (requestParameters_parameters_InfluxDBv2IsNull)
            {
                requestParameters_parameters_InfluxDBv2 = null;
            }
            if (requestParameters_parameters_InfluxDBv2 != null)
            {
                request.Parameters.InfluxDBv2 = requestParameters_parameters_InfluxDBv2;
                requestParametersIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.InfluxDBv3CoreParameters requestParameters_parameters_InfluxDBv3Core = null;
            
             // populate InfluxDBv3Core
            var requestParameters_parameters_InfluxDBv3CoreIsNull = true;
            requestParameters_parameters_InfluxDBv3Core = new Amazon.TimestreamInfluxDB.Model.InfluxDBv3CoreParameters();
            System.String requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionConfig = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionConfig != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionConfig = cmdletContext.InfluxDBv3Core_DataFusionConfig;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionConfig != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionConfig = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionConfig;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionMaxParquetFanout = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionMaxParquetFanout != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionMaxParquetFanout = cmdletContext.InfluxDBv3Core_DataFusionMaxParquetFanout.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionMaxParquetFanout != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionMaxParquetFanout = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionMaxParquetFanout.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionNumThread = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionNumThread != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionNumThread = cmdletContext.InfluxDBv3Core_DataFusionNumThread.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionNumThread != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionNumThreads = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionNumThread.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeDisableLifoSlot = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionRuntimeDisableLifoSlot != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeDisableLifoSlot = cmdletContext.InfluxDBv3Core_DataFusionRuntimeDisableLifoSlot.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeDisableLifoSlot != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionRuntimeDisableLifoSlot = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeDisableLifoSlot.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeEventInterval = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionRuntimeEventInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeEventInterval = cmdletContext.InfluxDBv3Core_DataFusionRuntimeEventInterval.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeEventInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionRuntimeEventInterval = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeEventInterval.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeGlobalQueueInterval = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionRuntimeGlobalQueueInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeGlobalQueueInterval = cmdletContext.InfluxDBv3Core_DataFusionRuntimeGlobalQueueInterval.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeGlobalQueueInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionRuntimeGlobalQueueInterval = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeGlobalQueueInterval.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeMaxBlockingThread = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionRuntimeMaxBlockingThread != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeMaxBlockingThread = cmdletContext.InfluxDBv3Core_DataFusionRuntimeMaxBlockingThread.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeMaxBlockingThread != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionRuntimeMaxBlockingThreads = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeMaxBlockingThread.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick = cmdletContext.InfluxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionRuntimeMaxIoEventsPerTick = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeThreadPriority = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionRuntimeThreadPriority != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeThreadPriority = cmdletContext.InfluxDBv3Core_DataFusionRuntimeThreadPriority.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeThreadPriority != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionRuntimeThreadPriority = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeThreadPriority.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.DataFusionRuntimeType requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeType = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionRuntimeType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeType = cmdletContext.InfluxDBv3Core_DataFusionRuntimeType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeType != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionRuntimeType = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionRuntimeType;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionUseCachedParquetLoader = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionUseCachedParquetLoader != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionUseCachedParquetLoader = cmdletContext.InfluxDBv3Core_DataFusionUseCachedParquetLoader.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionUseCachedParquetLoader != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionUseCachedParquetLoader = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DataFusionUseCachedParquetLoader.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DisableParquetMemCache = null;
            if (cmdletContext.InfluxDBv3Core_DisableParquetMemCache != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DisableParquetMemCache = cmdletContext.InfluxDBv3Core_DisableParquetMemCache.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DisableParquetMemCache != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DisableParquetMemCache = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_DisableParquetMemCache.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.String requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_LogFilter = null;
            if (cmdletContext.InfluxDBv3Core_LogFilter != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_LogFilter = cmdletContext.InfluxDBv3Core_LogFilter;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_LogFilter != null)
            {
                requestParameters_parameters_InfluxDBv3Core.LogFilter = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_LogFilter;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.LogFormats requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_LogFormat = null;
            if (cmdletContext.InfluxDBv3Core_LogFormat != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_LogFormat = cmdletContext.InfluxDBv3Core_LogFormat;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_LogFormat != null)
            {
                requestParameters_parameters_InfluxDBv3Core.LogFormat = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_LogFormat;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_MaxHttpRequestSize = null;
            if (cmdletContext.InfluxDBv3Core_MaxHttpRequestSize != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_MaxHttpRequestSize = cmdletContext.InfluxDBv3Core_MaxHttpRequestSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_MaxHttpRequestSize != null)
            {
                requestParameters_parameters_InfluxDBv3Core.MaxHttpRequestSize = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_MaxHttpRequestSize.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Single? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_ParquetMemCachePrunePercentage = null;
            if (cmdletContext.InfluxDBv3Core_ParquetMemCachePrunePercentage != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_ParquetMemCachePrunePercentage = cmdletContext.InfluxDBv3Core_ParquetMemCachePrunePercentage.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_ParquetMemCachePrunePercentage != null)
            {
                requestParameters_parameters_InfluxDBv3Core.ParquetMemCachePrunePercentage = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_ParquetMemCachePrunePercentage.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_QueryFileLimit = null;
            if (cmdletContext.InfluxDBv3Core_QueryFileLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_QueryFileLimit = cmdletContext.InfluxDBv3Core_QueryFileLimit.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_QueryFileLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Core.QueryFileLimit = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_QueryFileLimit.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_QueryLogSize = null;
            if (cmdletContext.InfluxDBv3Core_QueryLogSize != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_QueryLogSize = cmdletContext.InfluxDBv3Core_QueryLogSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_QueryLogSize != null)
            {
                requestParameters_parameters_InfluxDBv3Core.QueryLogSize = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_QueryLogSize.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_SnapshottedWalFilesToKeep = null;
            if (cmdletContext.InfluxDBv3Core_SnapshottedWalFilesToKeep != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_SnapshottedWalFilesToKeep = cmdletContext.InfluxDBv3Core_SnapshottedWalFilesToKeep.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_SnapshottedWalFilesToKeep != null)
            {
                requestParameters_parameters_InfluxDBv3Core.SnapshottedWalFilesToKeep = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_SnapshottedWalFilesToKeep.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_TableIndexCacheConcurrencyLimit = null;
            if (cmdletContext.InfluxDBv3Core_TableIndexCacheConcurrencyLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_TableIndexCacheConcurrencyLimit = cmdletContext.InfluxDBv3Core_TableIndexCacheConcurrencyLimit.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_TableIndexCacheConcurrencyLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Core.TableIndexCacheConcurrencyLimit = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_TableIndexCacheConcurrencyLimit.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_TableIndexCacheMaxEntry = null;
            if (cmdletContext.InfluxDBv3Core_TableIndexCacheMaxEntry != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_TableIndexCacheMaxEntry = cmdletContext.InfluxDBv3Core_TableIndexCacheMaxEntry.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_TableIndexCacheMaxEntry != null)
            {
                requestParameters_parameters_InfluxDBv3Core.TableIndexCacheMaxEntries = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_TableIndexCacheMaxEntry.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalMaxWriteBufferSize = null;
            if (cmdletContext.InfluxDBv3Core_WalMaxWriteBufferSize != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalMaxWriteBufferSize = cmdletContext.InfluxDBv3Core_WalMaxWriteBufferSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalMaxWriteBufferSize != null)
            {
                requestParameters_parameters_InfluxDBv3Core.WalMaxWriteBufferSize = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalMaxWriteBufferSize.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalReplayConcurrencyLimit = null;
            if (cmdletContext.InfluxDBv3Core_WalReplayConcurrencyLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalReplayConcurrencyLimit = cmdletContext.InfluxDBv3Core_WalReplayConcurrencyLimit.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalReplayConcurrencyLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Core.WalReplayConcurrencyLimit = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalReplayConcurrencyLimit.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalReplayFailOnError = null;
            if (cmdletContext.InfluxDBv3Core_WalReplayFailOnError != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalReplayFailOnError = cmdletContext.InfluxDBv3Core_WalReplayFailOnError.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalReplayFailOnError != null)
            {
                requestParameters_parameters_InfluxDBv3Core.WalReplayFailOnError = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalReplayFailOnError.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalSnapshotSize = null;
            if (cmdletContext.InfluxDBv3Core_WalSnapshotSize != null)
            {
                requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalSnapshotSize = cmdletContext.InfluxDBv3Core_WalSnapshotSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalSnapshotSize != null)
            {
                requestParameters_parameters_InfluxDBv3Core.WalSnapshotSize = requestParameters_parameters_InfluxDBv3Core_influxDBv3Core_WalSnapshotSize.Value;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive = null;
            
             // populate DataFusionRuntimeThreadKeepAlive
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAliveIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_influxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_influxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType = cmdletContext.InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_influxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_influxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAliveIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_influxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value = null;
            if (cmdletContext.InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_influxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value = cmdletContext.InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_influxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_influxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAliveIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAliveIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DataFusionRuntimeThreadKeepAlive = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod = null;
            
             // populate DeleteGracePeriod
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriodIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod_influxDBv3Core_DeleteGracePeriod_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_DeleteGracePeriod_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod_influxDBv3Core_DeleteGracePeriod_DurationType = cmdletContext.InfluxDBv3Core_DeleteGracePeriod_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod_influxDBv3Core_DeleteGracePeriod_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod_influxDBv3Core_DeleteGracePeriod_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriodIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod_influxDBv3Core_DeleteGracePeriod_Value = null;
            if (cmdletContext.InfluxDBv3Core_DeleteGracePeriod_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod_influxDBv3Core_DeleteGracePeriod_Value = cmdletContext.InfluxDBv3Core_DeleteGracePeriod_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod_influxDBv3Core_DeleteGracePeriod_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod_influxDBv3Core_DeleteGracePeriod_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriodIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriodIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DeleteGracePeriod = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DeleteGracePeriod;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval = null;
            
             // populate DistinctCacheEvictionInterval
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval_influxDBv3Core_DistinctCacheEvictionInterval_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval_influxDBv3Core_DistinctCacheEvictionInterval_DurationType = cmdletContext.InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval_influxDBv3Core_DistinctCacheEvictionInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval_influxDBv3Core_DistinctCacheEvictionInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval_influxDBv3Core_DistinctCacheEvictionInterval_Value = null;
            if (cmdletContext.InfluxDBv3Core_DistinctCacheEvictionInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval_influxDBv3Core_DistinctCacheEvictionInterval_Value = cmdletContext.InfluxDBv3Core_DistinctCacheEvictionInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval_influxDBv3Core_DistinctCacheEvictionInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval_influxDBv3Core_DistinctCacheEvictionInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Core.DistinctCacheEvictionInterval = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_DistinctCacheEvictionInterval;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes = null;
            
             // populate ExecMemPoolBytes
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytesIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes = new Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong();
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes_influxDBv3Core_ExecMemPoolBytes_Absolute = null;
            if (cmdletContext.InfluxDBv3Core_ExecMemPoolBytes_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes_influxDBv3Core_ExecMemPoolBytes_Absolute = cmdletContext.InfluxDBv3Core_ExecMemPoolBytes_Absolute.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes_influxDBv3Core_ExecMemPoolBytes_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes.Absolute = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes_influxDBv3Core_ExecMemPoolBytes_Absolute.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytesIsNull = false;
            }
            System.String requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes_influxDBv3Core_ExecMemPoolBytes_Percent = null;
            if (cmdletContext.InfluxDBv3Core_ExecMemPoolBytes_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes_influxDBv3Core_ExecMemPoolBytes_Percent = cmdletContext.InfluxDBv3Core_ExecMemPoolBytes_Percent;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes_influxDBv3Core_ExecMemPoolBytes_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes.Percent = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes_influxDBv3Core_ExecMemPoolBytes_Percent;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytesIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytesIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes != null)
            {
                requestParameters_parameters_InfluxDBv3Core.ExecMemPoolBytes = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ExecMemPoolBytes;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold = null;
            
             // populate ForceSnapshotMemThreshold
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThresholdIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold = new Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong();
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold_influxDBv3Core_ForceSnapshotMemThreshold_Absolute = null;
            if (cmdletContext.InfluxDBv3Core_ForceSnapshotMemThreshold_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold_influxDBv3Core_ForceSnapshotMemThreshold_Absolute = cmdletContext.InfluxDBv3Core_ForceSnapshotMemThreshold_Absolute.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold_influxDBv3Core_ForceSnapshotMemThreshold_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold.Absolute = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold_influxDBv3Core_ForceSnapshotMemThreshold_Absolute.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThresholdIsNull = false;
            }
            System.String requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold_influxDBv3Core_ForceSnapshotMemThreshold_Percent = null;
            if (cmdletContext.InfluxDBv3Core_ForceSnapshotMemThreshold_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold_influxDBv3Core_ForceSnapshotMemThreshold_Percent = cmdletContext.InfluxDBv3Core_ForceSnapshotMemThreshold_Percent;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold_influxDBv3Core_ForceSnapshotMemThreshold_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold.Percent = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold_influxDBv3Core_ForceSnapshotMemThreshold_Percent;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThresholdIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThresholdIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold != null)
            {
                requestParameters_parameters_InfluxDBv3Core.ForceSnapshotMemThreshold = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ForceSnapshotMemThreshold;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration = null;
            
             // populate Gen1Duration
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1DurationIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration_influxDBv3Core_Gen1Duration_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_Gen1Duration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration_influxDBv3Core_Gen1Duration_DurationType = cmdletContext.InfluxDBv3Core_Gen1Duration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration_influxDBv3Core_Gen1Duration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration_influxDBv3Core_Gen1Duration_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1DurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration_influxDBv3Core_Gen1Duration_Value = null;
            if (cmdletContext.InfluxDBv3Core_Gen1Duration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration_influxDBv3Core_Gen1Duration_Value = cmdletContext.InfluxDBv3Core_Gen1Duration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration_influxDBv3Core_Gen1Duration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration_influxDBv3Core_Gen1Duration_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1DurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1DurationIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration != null)
            {
                requestParameters_parameters_InfluxDBv3Core.Gen1Duration = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1Duration;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration = null;
            
             // populate Gen1LookbackDuration
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDurationIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration_influxDBv3Core_Gen1LookbackDuration_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_Gen1LookbackDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration_influxDBv3Core_Gen1LookbackDuration_DurationType = cmdletContext.InfluxDBv3Core_Gen1LookbackDuration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration_influxDBv3Core_Gen1LookbackDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration_influxDBv3Core_Gen1LookbackDuration_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration_influxDBv3Core_Gen1LookbackDuration_Value = null;
            if (cmdletContext.InfluxDBv3Core_Gen1LookbackDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration_influxDBv3Core_Gen1LookbackDuration_Value = cmdletContext.InfluxDBv3Core_Gen1LookbackDuration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration_influxDBv3Core_Gen1LookbackDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration_influxDBv3Core_Gen1LookbackDuration_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDurationIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration != null)
            {
                requestParameters_parameters_InfluxDBv3Core.Gen1LookbackDuration = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_Gen1LookbackDuration;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration = null;
            
             // populate HardDeleteDefaultDuration
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDurationIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration_influxDBv3Core_HardDeleteDefaultDuration_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_HardDeleteDefaultDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration_influxDBv3Core_HardDeleteDefaultDuration_DurationType = cmdletContext.InfluxDBv3Core_HardDeleteDefaultDuration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration_influxDBv3Core_HardDeleteDefaultDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration_influxDBv3Core_HardDeleteDefaultDuration_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration_influxDBv3Core_HardDeleteDefaultDuration_Value = null;
            if (cmdletContext.InfluxDBv3Core_HardDeleteDefaultDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration_influxDBv3Core_HardDeleteDefaultDuration_Value = cmdletContext.InfluxDBv3Core_HardDeleteDefaultDuration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration_influxDBv3Core_HardDeleteDefaultDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration_influxDBv3Core_HardDeleteDefaultDuration_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDurationIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration != null)
            {
                requestParameters_parameters_InfluxDBv3Core.HardDeleteDefaultDuration = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_HardDeleteDefaultDuration;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval = null;
            
             // populate LastCacheEvictionInterval
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval_influxDBv3Core_LastCacheEvictionInterval_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_LastCacheEvictionInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval_influxDBv3Core_LastCacheEvictionInterval_DurationType = cmdletContext.InfluxDBv3Core_LastCacheEvictionInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval_influxDBv3Core_LastCacheEvictionInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval_influxDBv3Core_LastCacheEvictionInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval_influxDBv3Core_LastCacheEvictionInterval_Value = null;
            if (cmdletContext.InfluxDBv3Core_LastCacheEvictionInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval_influxDBv3Core_LastCacheEvictionInterval_Value = cmdletContext.InfluxDBv3Core_LastCacheEvictionInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval_influxDBv3Core_LastCacheEvictionInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval_influxDBv3Core_LastCacheEvictionInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Core.LastCacheEvictionInterval = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_LastCacheEvictionInterval;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval = null;
            
             // populate ParquetMemCachePruneInterval
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval_influxDBv3Core_ParquetMemCachePruneInterval_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval_influxDBv3Core_ParquetMemCachePruneInterval_DurationType = cmdletContext.InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval_influxDBv3Core_ParquetMemCachePruneInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval_influxDBv3Core_ParquetMemCachePruneInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval_influxDBv3Core_ParquetMemCachePruneInterval_Value = null;
            if (cmdletContext.InfluxDBv3Core_ParquetMemCachePruneInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval_influxDBv3Core_ParquetMemCachePruneInterval_Value = cmdletContext.InfluxDBv3Core_ParquetMemCachePruneInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval_influxDBv3Core_ParquetMemCachePruneInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval_influxDBv3Core_ParquetMemCachePruneInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Core.ParquetMemCachePruneInterval = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCachePruneInterval;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration = null;
            
             // populate ParquetMemCacheQueryPathDuration
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDurationIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration_influxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration_influxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType = cmdletContext.InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration_influxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration_influxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration_influxDBv3Core_ParquetMemCacheQueryPathDuration_Value = null;
            if (cmdletContext.InfluxDBv3Core_ParquetMemCacheQueryPathDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration_influxDBv3Core_ParquetMemCacheQueryPathDuration_Value = cmdletContext.InfluxDBv3Core_ParquetMemCacheQueryPathDuration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration_influxDBv3Core_ParquetMemCacheQueryPathDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration_influxDBv3Core_ParquetMemCacheQueryPathDuration_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDurationIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration != null)
            {
                requestParameters_parameters_InfluxDBv3Core.ParquetMemCacheQueryPathDuration = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheQueryPathDuration;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize = null;
            
             // populate ParquetMemCacheSize
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSizeIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize = new Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong();
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize_influxDBv3Core_ParquetMemCacheSize_Absolute = null;
            if (cmdletContext.InfluxDBv3Core_ParquetMemCacheSize_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize_influxDBv3Core_ParquetMemCacheSize_Absolute = cmdletContext.InfluxDBv3Core_ParquetMemCacheSize_Absolute.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize_influxDBv3Core_ParquetMemCacheSize_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize.Absolute = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize_influxDBv3Core_ParquetMemCacheSize_Absolute.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSizeIsNull = false;
            }
            System.String requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize_influxDBv3Core_ParquetMemCacheSize_Percent = null;
            if (cmdletContext.InfluxDBv3Core_ParquetMemCacheSize_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize_influxDBv3Core_ParquetMemCacheSize_Percent = cmdletContext.InfluxDBv3Core_ParquetMemCacheSize_Percent;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize_influxDBv3Core_ParquetMemCacheSize_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize.Percent = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize_influxDBv3Core_ParquetMemCacheSize_Percent;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSizeIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSizeIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize != null)
            {
                requestParameters_parameters_InfluxDBv3Core.ParquetMemCacheSize = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_ParquetMemCacheSize;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge = null;
            
             // populate PreemptiveCacheAge
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAgeIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge_influxDBv3Core_PreemptiveCacheAge_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_PreemptiveCacheAge_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge_influxDBv3Core_PreemptiveCacheAge_DurationType = cmdletContext.InfluxDBv3Core_PreemptiveCacheAge_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge_influxDBv3Core_PreemptiveCacheAge_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge_influxDBv3Core_PreemptiveCacheAge_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAgeIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge_influxDBv3Core_PreemptiveCacheAge_Value = null;
            if (cmdletContext.InfluxDBv3Core_PreemptiveCacheAge_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge_influxDBv3Core_PreemptiveCacheAge_Value = cmdletContext.InfluxDBv3Core_PreemptiveCacheAge_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge_influxDBv3Core_PreemptiveCacheAge_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge_influxDBv3Core_PreemptiveCacheAge_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAgeIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAgeIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge != null)
            {
                requestParameters_parameters_InfluxDBv3Core.PreemptiveCacheAge = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_PreemptiveCacheAge;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval = null;
            
             // populate RetentionCheckInterval
            var requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval_influxDBv3Core_RetentionCheckInterval_DurationType = null;
            if (cmdletContext.InfluxDBv3Core_RetentionCheckInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval_influxDBv3Core_RetentionCheckInterval_DurationType = cmdletContext.InfluxDBv3Core_RetentionCheckInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval_influxDBv3Core_RetentionCheckInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval.DurationType = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval_influxDBv3Core_RetentionCheckInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval_influxDBv3Core_RetentionCheckInterval_Value = null;
            if (cmdletContext.InfluxDBv3Core_RetentionCheckInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval_influxDBv3Core_RetentionCheckInterval_Value = cmdletContext.InfluxDBv3Core_RetentionCheckInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval_influxDBv3Core_RetentionCheckInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval.Value = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval_influxDBv3Core_RetentionCheckInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Core.RetentionCheckInterval = requestParameters_parameters_InfluxDBv3Core_parameters_InfluxDBv3Core_RetentionCheckInterval;
                requestParameters_parameters_InfluxDBv3CoreIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Core should be set to null
            if (requestParameters_parameters_InfluxDBv3CoreIsNull)
            {
                requestParameters_parameters_InfluxDBv3Core = null;
            }
            if (requestParameters_parameters_InfluxDBv3Core != null)
            {
                request.Parameters.InfluxDBv3Core = requestParameters_parameters_InfluxDBv3Core;
                requestParametersIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.InfluxDBv3EnterpriseParameters requestParameters_parameters_InfluxDBv3Enterprise = null;
            
             // populate InfluxDBv3Enterprise
            var requestParameters_parameters_InfluxDBv3EnterpriseIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise = new Amazon.TimestreamInfluxDB.Model.InfluxDBv3EnterpriseParameters();
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionMaxNumFilesPerPlan = null;
            if (cmdletContext.InfluxDBv3Enterprise_CompactionMaxNumFilesPerPlan != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionMaxNumFilesPerPlan = cmdletContext.InfluxDBv3Enterprise_CompactionMaxNumFilesPerPlan.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionMaxNumFilesPerPlan != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.CompactionMaxNumFilesPerPlan = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionMaxNumFilesPerPlan.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.String requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionMultiplier = null;
            if (cmdletContext.InfluxDBv3Enterprise_CompactionMultiplier != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionMultiplier = cmdletContext.InfluxDBv3Enterprise_CompactionMultiplier;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionMultiplier != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.CompactionMultipliers = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionMultiplier;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionRowLimit = null;
            if (cmdletContext.InfluxDBv3Enterprise_CompactionRowLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionRowLimit = cmdletContext.InfluxDBv3Enterprise_CompactionRowLimit.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionRowLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.CompactionRowLimit = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_CompactionRowLimit.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.String requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionConfig = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionConfig != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionConfig = cmdletContext.InfluxDBv3Enterprise_DataFusionConfig;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionConfig != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionConfig = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionConfig;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionMaxParquetFanout = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionMaxParquetFanout != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionMaxParquetFanout = cmdletContext.InfluxDBv3Enterprise_DataFusionMaxParquetFanout.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionMaxParquetFanout != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionMaxParquetFanout = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionMaxParquetFanout.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionNumThread = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionNumThread != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionNumThread = cmdletContext.InfluxDBv3Enterprise_DataFusionNumThread.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionNumThread != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionNumThreads = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionNumThread.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot = cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionRuntimeDisableLifoSlot = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeEventInterval = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeEventInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeEventInterval = cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeEventInterval.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeEventInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionRuntimeEventInterval = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeEventInterval.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval = cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionRuntimeGlobalQueueInterval = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread = cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionRuntimeMaxBlockingThreads = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick = cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionRuntimeMaxIoEventsPerTick = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeThreadPriority = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeThreadPriority != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeThreadPriority = cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeThreadPriority.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeThreadPriority != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionRuntimeThreadPriority = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeThreadPriority.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.DataFusionRuntimeType requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeType = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeType = cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionRuntimeType = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionRuntimeType;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionUseCachedParquetLoader = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionUseCachedParquetLoader != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionUseCachedParquetLoader = cmdletContext.InfluxDBv3Enterprise_DataFusionUseCachedParquetLoader.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionUseCachedParquetLoader != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionUseCachedParquetLoader = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DataFusionUseCachedParquetLoader.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DedicatedCompactor = null;
            if (cmdletContext.InfluxDBv3Enterprise_DedicatedCompactor != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DedicatedCompactor = cmdletContext.InfluxDBv3Enterprise_DedicatedCompactor.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DedicatedCompactor != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DedicatedCompactor = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DedicatedCompactor.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DisableParquetMemCache = null;
            if (cmdletContext.InfluxDBv3Enterprise_DisableParquetMemCache != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DisableParquetMemCache = cmdletContext.InfluxDBv3Enterprise_DisableParquetMemCache.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DisableParquetMemCache != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DisableParquetMemCache = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DisableParquetMemCache.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DistinctValueCacheDisableFromHistory = null;
            if (cmdletContext.InfluxDBv3Enterprise_DistinctValueCacheDisableFromHistory != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DistinctValueCacheDisableFromHistory = cmdletContext.InfluxDBv3Enterprise_DistinctValueCacheDisableFromHistory.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DistinctValueCacheDisableFromHistory != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DistinctValueCacheDisableFromHistory = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_DistinctValueCacheDisableFromHistory.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_IngestQueryInstance = null;
            if (cmdletContext.InfluxDBv3Enterprise_IngestQueryInstance != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_IngestQueryInstance = cmdletContext.InfluxDBv3Enterprise_IngestQueryInstance.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_IngestQueryInstance != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.IngestQueryInstances = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_IngestQueryInstance.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LastValueCacheDisableFromHistory = null;
            if (cmdletContext.InfluxDBv3Enterprise_LastValueCacheDisableFromHistory != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LastValueCacheDisableFromHistory = cmdletContext.InfluxDBv3Enterprise_LastValueCacheDisableFromHistory.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LastValueCacheDisableFromHistory != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.LastValueCacheDisableFromHistory = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LastValueCacheDisableFromHistory.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.String requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LogFilter = null;
            if (cmdletContext.InfluxDBv3Enterprise_LogFilter != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LogFilter = cmdletContext.InfluxDBv3Enterprise_LogFilter;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LogFilter != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.LogFilter = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LogFilter;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.LogFormats requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LogFormat = null;
            if (cmdletContext.InfluxDBv3Enterprise_LogFormat != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LogFormat = cmdletContext.InfluxDBv3Enterprise_LogFormat;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LogFormat != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.LogFormat = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_LogFormat;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_MaxHttpRequestSize = null;
            if (cmdletContext.InfluxDBv3Enterprise_MaxHttpRequestSize != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_MaxHttpRequestSize = cmdletContext.InfluxDBv3Enterprise_MaxHttpRequestSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_MaxHttpRequestSize != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.MaxHttpRequestSize = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_MaxHttpRequestSize.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Single? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_ParquetMemCachePrunePercentage = null;
            if (cmdletContext.InfluxDBv3Enterprise_ParquetMemCachePrunePercentage != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_ParquetMemCachePrunePercentage = cmdletContext.InfluxDBv3Enterprise_ParquetMemCachePrunePercentage.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_ParquetMemCachePrunePercentage != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.ParquetMemCachePrunePercentage = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_ParquetMemCachePrunePercentage.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryFileLimit = null;
            if (cmdletContext.InfluxDBv3Enterprise_QueryFileLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryFileLimit = cmdletContext.InfluxDBv3Enterprise_QueryFileLimit.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryFileLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.QueryFileLimit = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryFileLimit.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryLogSize = null;
            if (cmdletContext.InfluxDBv3Enterprise_QueryLogSize != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryLogSize = cmdletContext.InfluxDBv3Enterprise_QueryLogSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryLogSize != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.QueryLogSize = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryLogSize.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryOnlyInstance = null;
            if (cmdletContext.InfluxDBv3Enterprise_QueryOnlyInstance != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryOnlyInstance = cmdletContext.InfluxDBv3Enterprise_QueryOnlyInstance.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryOnlyInstance != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.QueryOnlyInstances = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_QueryOnlyInstance.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_SnapshottedWalFilesToKeep = null;
            if (cmdletContext.InfluxDBv3Enterprise_SnapshottedWalFilesToKeep != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_SnapshottedWalFilesToKeep = cmdletContext.InfluxDBv3Enterprise_SnapshottedWalFilesToKeep.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_SnapshottedWalFilesToKeep != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.SnapshottedWalFilesToKeep = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_SnapshottedWalFilesToKeep.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_TableIndexCacheConcurrencyLimit = null;
            if (cmdletContext.InfluxDBv3Enterprise_TableIndexCacheConcurrencyLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_TableIndexCacheConcurrencyLimit = cmdletContext.InfluxDBv3Enterprise_TableIndexCacheConcurrencyLimit.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_TableIndexCacheConcurrencyLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.TableIndexCacheConcurrencyLimit = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_TableIndexCacheConcurrencyLimit.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_TableIndexCacheMaxEntry = null;
            if (cmdletContext.InfluxDBv3Enterprise_TableIndexCacheMaxEntry != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_TableIndexCacheMaxEntry = cmdletContext.InfluxDBv3Enterprise_TableIndexCacheMaxEntry.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_TableIndexCacheMaxEntry != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.TableIndexCacheMaxEntries = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_TableIndexCacheMaxEntry.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalMaxWriteBufferSize = null;
            if (cmdletContext.InfluxDBv3Enterprise_WalMaxWriteBufferSize != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalMaxWriteBufferSize = cmdletContext.InfluxDBv3Enterprise_WalMaxWriteBufferSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalMaxWriteBufferSize != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.WalMaxWriteBufferSize = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalMaxWriteBufferSize.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalReplayConcurrencyLimit = null;
            if (cmdletContext.InfluxDBv3Enterprise_WalReplayConcurrencyLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalReplayConcurrencyLimit = cmdletContext.InfluxDBv3Enterprise_WalReplayConcurrencyLimit.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalReplayConcurrencyLimit != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.WalReplayConcurrencyLimit = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalReplayConcurrencyLimit.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalReplayFailOnError = null;
            if (cmdletContext.InfluxDBv3Enterprise_WalReplayFailOnError != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalReplayFailOnError = cmdletContext.InfluxDBv3Enterprise_WalReplayFailOnError.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalReplayFailOnError != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.WalReplayFailOnError = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalReplayFailOnError.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalSnapshotSize = null;
            if (cmdletContext.InfluxDBv3Enterprise_WalSnapshotSize != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalSnapshotSize = cmdletContext.InfluxDBv3Enterprise_WalSnapshotSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalSnapshotSize != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.WalSnapshotSize = requestParameters_parameters_InfluxDBv3Enterprise_influxDBv3Enterprise_WalSnapshotSize.Value;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval = null;
            
             // populate CatalogSyncInterval
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval_catalogSyncInterval_DurationType = null;
            if (cmdletContext.CatalogSyncInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval_catalogSyncInterval_DurationType = cmdletContext.CatalogSyncInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval_catalogSyncInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval_catalogSyncInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval_catalogSyncInterval_Value = null;
            if (cmdletContext.CatalogSyncInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval_catalogSyncInterval_Value = cmdletContext.CatalogSyncInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval_catalogSyncInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval_catalogSyncInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.CatalogSyncInterval = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CatalogSyncInterval;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval = null;
            
             // populate CompactionCheckInterval
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval_compactionCheckInterval_DurationType = null;
            if (cmdletContext.CompactionCheckInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval_compactionCheckInterval_DurationType = cmdletContext.CompactionCheckInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval_compactionCheckInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval_compactionCheckInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval_compactionCheckInterval_Value = null;
            if (cmdletContext.CompactionCheckInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval_compactionCheckInterval_Value = cmdletContext.CompactionCheckInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval_compactionCheckInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval_compactionCheckInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.CompactionCheckInterval = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCheckInterval;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait = null;
            
             // populate CompactionCleanupWait
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWaitIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait_compactionCleanupWait_DurationType = null;
            if (cmdletContext.CompactionCleanupWait_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait_compactionCleanupWait_DurationType = cmdletContext.CompactionCleanupWait_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait_compactionCleanupWait_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait_compactionCleanupWait_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWaitIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait_compactionCleanupWait_Value = null;
            if (cmdletContext.CompactionCleanupWait_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait_compactionCleanupWait_Value = cmdletContext.CompactionCleanupWait_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait_compactionCleanupWait_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait_compactionCleanupWait_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWaitIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWaitIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.CompactionCleanupWait = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionCleanupWait;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration = null;
            
             // populate CompactionGen2Duration
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2DurationIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration_compactionGen2Duration_DurationType = null;
            if (cmdletContext.CompactionGen2Duration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration_compactionGen2Duration_DurationType = cmdletContext.CompactionGen2Duration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration_compactionGen2Duration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration_compactionGen2Duration_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2DurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration_compactionGen2Duration_Value = null;
            if (cmdletContext.CompactionGen2Duration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration_compactionGen2Duration_Value = cmdletContext.CompactionGen2Duration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration_compactionGen2Duration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration_compactionGen2Duration_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2DurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2DurationIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.CompactionGen2Duration = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_CompactionGen2Duration;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive = null;
            
             // populate DataFusionRuntimeThreadKeepAlive
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAliveIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_influxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_influxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType = cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_influxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_influxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAliveIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_influxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_influxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value = cmdletContext.InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_influxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_influxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAliveIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAliveIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DataFusionRuntimeThreadKeepAlive = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod = null;
            
             // populate DeleteGracePeriod
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriodIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod_influxDBv3Enterprise_DeleteGracePeriod_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_DeleteGracePeriod_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod_influxDBv3Enterprise_DeleteGracePeriod_DurationType = cmdletContext.InfluxDBv3Enterprise_DeleteGracePeriod_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod_influxDBv3Enterprise_DeleteGracePeriod_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod_influxDBv3Enterprise_DeleteGracePeriod_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriodIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod_influxDBv3Enterprise_DeleteGracePeriod_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_DeleteGracePeriod_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod_influxDBv3Enterprise_DeleteGracePeriod_Value = cmdletContext.InfluxDBv3Enterprise_DeleteGracePeriod_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod_influxDBv3Enterprise_DeleteGracePeriod_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod_influxDBv3Enterprise_DeleteGracePeriod_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriodIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriodIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DeleteGracePeriod = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DeleteGracePeriod;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval = null;
            
             // populate DistinctCacheEvictionInterval
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval_influxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval_influxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType = cmdletContext.InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval_influxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval_influxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval_influxDBv3Enterprise_DistinctCacheEvictionInterval_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_DistinctCacheEvictionInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval_influxDBv3Enterprise_DistinctCacheEvictionInterval_Value = cmdletContext.InfluxDBv3Enterprise_DistinctCacheEvictionInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval_influxDBv3Enterprise_DistinctCacheEvictionInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval_influxDBv3Enterprise_DistinctCacheEvictionInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.DistinctCacheEvictionInterval = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_DistinctCacheEvictionInterval;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes = null;
            
             // populate ExecMemPoolBytes
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytesIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes = new Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong();
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes_influxDBv3Enterprise_ExecMemPoolBytes_Absolute = null;
            if (cmdletContext.InfluxDBv3Enterprise_ExecMemPoolBytes_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes_influxDBv3Enterprise_ExecMemPoolBytes_Absolute = cmdletContext.InfluxDBv3Enterprise_ExecMemPoolBytes_Absolute.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes_influxDBv3Enterprise_ExecMemPoolBytes_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes.Absolute = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes_influxDBv3Enterprise_ExecMemPoolBytes_Absolute.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytesIsNull = false;
            }
            System.String requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes_influxDBv3Enterprise_ExecMemPoolBytes_Percent = null;
            if (cmdletContext.InfluxDBv3Enterprise_ExecMemPoolBytes_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes_influxDBv3Enterprise_ExecMemPoolBytes_Percent = cmdletContext.InfluxDBv3Enterprise_ExecMemPoolBytes_Percent;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes_influxDBv3Enterprise_ExecMemPoolBytes_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes.Percent = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes_influxDBv3Enterprise_ExecMemPoolBytes_Percent;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytesIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytesIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.ExecMemPoolBytes = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ExecMemPoolBytes;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold = null;
            
             // populate ForceSnapshotMemThreshold
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThresholdIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold = new Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong();
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold_influxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute = null;
            if (cmdletContext.InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold_influxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute = cmdletContext.InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold_influxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold.Absolute = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold_influxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThresholdIsNull = false;
            }
            System.String requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold_influxDBv3Enterprise_ForceSnapshotMemThreshold_Percent = null;
            if (cmdletContext.InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold_influxDBv3Enterprise_ForceSnapshotMemThreshold_Percent = cmdletContext.InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Percent;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold_influxDBv3Enterprise_ForceSnapshotMemThreshold_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold.Percent = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold_influxDBv3Enterprise_ForceSnapshotMemThreshold_Percent;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThresholdIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThresholdIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.ForceSnapshotMemThreshold = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ForceSnapshotMemThreshold;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration = null;
            
             // populate Gen1Duration
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1DurationIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration_influxDBv3Enterprise_Gen1Duration_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_Gen1Duration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration_influxDBv3Enterprise_Gen1Duration_DurationType = cmdletContext.InfluxDBv3Enterprise_Gen1Duration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration_influxDBv3Enterprise_Gen1Duration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration_influxDBv3Enterprise_Gen1Duration_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1DurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration_influxDBv3Enterprise_Gen1Duration_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_Gen1Duration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration_influxDBv3Enterprise_Gen1Duration_Value = cmdletContext.InfluxDBv3Enterprise_Gen1Duration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration_influxDBv3Enterprise_Gen1Duration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration_influxDBv3Enterprise_Gen1Duration_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1DurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1DurationIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.Gen1Duration = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1Duration;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration = null;
            
             // populate Gen1LookbackDuration
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDurationIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration_influxDBv3Enterprise_Gen1LookbackDuration_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration_influxDBv3Enterprise_Gen1LookbackDuration_DurationType = cmdletContext.InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration_influxDBv3Enterprise_Gen1LookbackDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration_influxDBv3Enterprise_Gen1LookbackDuration_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration_influxDBv3Enterprise_Gen1LookbackDuration_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_Gen1LookbackDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration_influxDBv3Enterprise_Gen1LookbackDuration_Value = cmdletContext.InfluxDBv3Enterprise_Gen1LookbackDuration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration_influxDBv3Enterprise_Gen1LookbackDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration_influxDBv3Enterprise_Gen1LookbackDuration_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDurationIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.Gen1LookbackDuration = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_Gen1LookbackDuration;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration = null;
            
             // populate HardDeleteDefaultDuration
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDurationIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration_influxDBv3Enterprise_HardDeleteDefaultDuration_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration_influxDBv3Enterprise_HardDeleteDefaultDuration_DurationType = cmdletContext.InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration_influxDBv3Enterprise_HardDeleteDefaultDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration_influxDBv3Enterprise_HardDeleteDefaultDuration_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration_influxDBv3Enterprise_HardDeleteDefaultDuration_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_HardDeleteDefaultDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration_influxDBv3Enterprise_HardDeleteDefaultDuration_Value = cmdletContext.InfluxDBv3Enterprise_HardDeleteDefaultDuration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration_influxDBv3Enterprise_HardDeleteDefaultDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration_influxDBv3Enterprise_HardDeleteDefaultDuration_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDurationIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.HardDeleteDefaultDuration = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_HardDeleteDefaultDuration;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval = null;
            
             // populate LastCacheEvictionInterval
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval_influxDBv3Enterprise_LastCacheEvictionInterval_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval_influxDBv3Enterprise_LastCacheEvictionInterval_DurationType = cmdletContext.InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval_influxDBv3Enterprise_LastCacheEvictionInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval_influxDBv3Enterprise_LastCacheEvictionInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval_influxDBv3Enterprise_LastCacheEvictionInterval_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_LastCacheEvictionInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval_influxDBv3Enterprise_LastCacheEvictionInterval_Value = cmdletContext.InfluxDBv3Enterprise_LastCacheEvictionInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval_influxDBv3Enterprise_LastCacheEvictionInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval_influxDBv3Enterprise_LastCacheEvictionInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.LastCacheEvictionInterval = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_LastCacheEvictionInterval;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval = null;
            
             // populate ParquetMemCachePruneInterval
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval_influxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval_influxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType = cmdletContext.InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval_influxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval_influxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval_influxDBv3Enterprise_ParquetMemCachePruneInterval_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_ParquetMemCachePruneInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval_influxDBv3Enterprise_ParquetMemCachePruneInterval_Value = cmdletContext.InfluxDBv3Enterprise_ParquetMemCachePruneInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval_influxDBv3Enterprise_ParquetMemCachePruneInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval_influxDBv3Enterprise_ParquetMemCachePruneInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.ParquetMemCachePruneInterval = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCachePruneInterval;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration = null;
            
             // populate ParquetMemCacheQueryPathDuration
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDurationIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_influxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_influxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType = cmdletContext.InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_influxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_influxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDurationIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_influxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_influxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value = cmdletContext.InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_influxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_influxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDurationIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDurationIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.ParquetMemCacheQueryPathDuration = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize = null;
            
             // populate ParquetMemCacheSize
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSizeIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize = new Amazon.TimestreamInfluxDB.Model.PercentOrAbsoluteLong();
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize_influxDBv3Enterprise_ParquetMemCacheSize_Absolute = null;
            if (cmdletContext.InfluxDBv3Enterprise_ParquetMemCacheSize_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize_influxDBv3Enterprise_ParquetMemCacheSize_Absolute = cmdletContext.InfluxDBv3Enterprise_ParquetMemCacheSize_Absolute.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize_influxDBv3Enterprise_ParquetMemCacheSize_Absolute != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize.Absolute = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize_influxDBv3Enterprise_ParquetMemCacheSize_Absolute.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSizeIsNull = false;
            }
            System.String requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize_influxDBv3Enterprise_ParquetMemCacheSize_Percent = null;
            if (cmdletContext.InfluxDBv3Enterprise_ParquetMemCacheSize_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize_influxDBv3Enterprise_ParquetMemCacheSize_Percent = cmdletContext.InfluxDBv3Enterprise_ParquetMemCacheSize_Percent;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize_influxDBv3Enterprise_ParquetMemCacheSize_Percent != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize.Percent = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize_influxDBv3Enterprise_ParquetMemCacheSize_Percent;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSizeIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSizeIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.ParquetMemCacheSize = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ParquetMemCacheSize;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge = null;
            
             // populate PreemptiveCacheAge
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAgeIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge_influxDBv3Enterprise_PreemptiveCacheAge_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge_influxDBv3Enterprise_PreemptiveCacheAge_DurationType = cmdletContext.InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge_influxDBv3Enterprise_PreemptiveCacheAge_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge_influxDBv3Enterprise_PreemptiveCacheAge_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAgeIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge_influxDBv3Enterprise_PreemptiveCacheAge_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_PreemptiveCacheAge_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge_influxDBv3Enterprise_PreemptiveCacheAge_Value = cmdletContext.InfluxDBv3Enterprise_PreemptiveCacheAge_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge_influxDBv3Enterprise_PreemptiveCacheAge_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge_influxDBv3Enterprise_PreemptiveCacheAge_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAgeIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAgeIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.PreemptiveCacheAge = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_PreemptiveCacheAge;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval = null;
            
             // populate ReplicationInterval
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval_replicationInterval_DurationType = null;
            if (cmdletContext.ReplicationInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval_replicationInterval_DurationType = cmdletContext.ReplicationInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval_replicationInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval_replicationInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval_replicationInterval_Value = null;
            if (cmdletContext.ReplicationInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval_replicationInterval_Value = cmdletContext.ReplicationInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval_replicationInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval_replicationInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.ReplicationInterval = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_ReplicationInterval;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
            Amazon.TimestreamInfluxDB.Model.Duration requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval = null;
            
             // populate RetentionCheckInterval
            var requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckIntervalIsNull = true;
            requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval = new Amazon.TimestreamInfluxDB.Model.Duration();
            Amazon.TimestreamInfluxDB.DurationType requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval_influxDBv3Enterprise_RetentionCheckInterval_DurationType = null;
            if (cmdletContext.InfluxDBv3Enterprise_RetentionCheckInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval_influxDBv3Enterprise_RetentionCheckInterval_DurationType = cmdletContext.InfluxDBv3Enterprise_RetentionCheckInterval_DurationType;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval_influxDBv3Enterprise_RetentionCheckInterval_DurationType != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval.DurationType = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval_influxDBv3Enterprise_RetentionCheckInterval_DurationType;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckIntervalIsNull = false;
            }
            System.Int64? requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval_influxDBv3Enterprise_RetentionCheckInterval_Value = null;
            if (cmdletContext.InfluxDBv3Enterprise_RetentionCheckInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval_influxDBv3Enterprise_RetentionCheckInterval_Value = cmdletContext.InfluxDBv3Enterprise_RetentionCheckInterval_Value.Value;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval_influxDBv3Enterprise_RetentionCheckInterval_Value != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval.Value = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval_influxDBv3Enterprise_RetentionCheckInterval_Value.Value;
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckIntervalIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval should be set to null
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckIntervalIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval != null)
            {
                requestParameters_parameters_InfluxDBv3Enterprise.RetentionCheckInterval = requestParameters_parameters_InfluxDBv3Enterprise_parameters_InfluxDBv3Enterprise_RetentionCheckInterval;
                requestParameters_parameters_InfluxDBv3EnterpriseIsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv3Enterprise should be set to null
            if (requestParameters_parameters_InfluxDBv3EnterpriseIsNull)
            {
                requestParameters_parameters_InfluxDBv3Enterprise = null;
            }
            if (requestParameters_parameters_InfluxDBv3Enterprise != null)
            {
                request.Parameters.InfluxDBv3Enterprise = requestParameters_parameters_InfluxDBv3Enterprise;
                requestParametersIsNull = false;
            }
             // determine if request.Parameters should be set to null
            if (requestParametersIsNull)
            {
                request.Parameters = null;
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
        
        private Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse CallAWSServiceOperation(IAmazonTimestreamInfluxDB client, Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream InfluxDB", "CreateDbParameterGroup");
            try
            {
                #if DESKTOP
                return client.CreateDbParameterGroup(request);
                #elif CORECLR
                return client.CreateDbParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? InfluxDBv2_FluxLogEnabled { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType HttpIdleTimeout_DurationType { get; set; }
            public System.Int64? HttpIdleTimeout_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType HttpReadHeaderTimeout_DurationType { get; set; }
            public System.Int64? HttpReadHeaderTimeout_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType HttpReadTimeout_DurationType { get; set; }
            public System.Int64? HttpReadTimeout_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType HttpWriteTimeout_DurationType { get; set; }
            public System.Int64? HttpWriteTimeout_Value { get; set; }
            public System.Int64? InfluxDBv2_InfluxqlMaxSelectBucket { get; set; }
            public System.Int64? InfluxDBv2_InfluxqlMaxSelectPoint { get; set; }
            public System.Int64? InfluxDBv2_InfluxqlMaxSelectSeries { get; set; }
            public Amazon.TimestreamInfluxDB.LogLevel InfluxDBv2_LogLevel { get; set; }
            public System.Boolean? InfluxDBv2_MetricsDisabled { get; set; }
            public System.Boolean? InfluxDBv2_NoTask { get; set; }
            public System.Boolean? InfluxDBv2_PprofDisabled { get; set; }
            public System.Int32? InfluxDBv2_QueryConcurrency { get; set; }
            public System.Int64? InfluxDBv2_QueryInitialMemoryByte { get; set; }
            public System.Int64? InfluxDBv2_QueryMaxMemoryByte { get; set; }
            public System.Int64? InfluxDBv2_QueryMemoryByte { get; set; }
            public System.Int32? InfluxDBv2_QueryQueueSize { get; set; }
            public System.Int32? InfluxDBv2_SessionLength { get; set; }
            public System.Boolean? InfluxDBv2_SessionRenewDisabled { get; set; }
            public System.Int64? InfluxDBv2_StorageCacheMaxMemorySize { get; set; }
            public System.Int64? InfluxDBv2_StorageCacheSnapshotMemorySize { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType StorageCacheSnapshotWriteColdDuration_DurationType { get; set; }
            public System.Int64? StorageCacheSnapshotWriteColdDuration_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType StorageCompactFullWriteColdDuration_DurationType { get; set; }
            public System.Int64? StorageCompactFullWriteColdDuration_Value { get; set; }
            public System.Int64? InfluxDBv2_StorageCompactThroughputBurst { get; set; }
            public System.Int32? InfluxDBv2_StorageMaxConcurrentCompaction { get; set; }
            public System.Int64? InfluxDBv2_StorageMaxIndexLogFileSize { get; set; }
            public System.Boolean? InfluxDBv2_StorageNoValidateFieldSize { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType StorageRetentionCheckInterval_DurationType { get; set; }
            public System.Int64? StorageRetentionCheckInterval_Value { get; set; }
            public System.Int32? InfluxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction { get; set; }
            public System.Int64? InfluxDBv2_StorageSeriesIdSetCacheSize { get; set; }
            public System.Int32? InfluxDBv2_StorageWalMaxConcurrentWrite { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType StorageWalMaxWriteDelay_DurationType { get; set; }
            public System.Int64? StorageWalMaxWriteDelay_Value { get; set; }
            public Amazon.TimestreamInfluxDB.TracingType InfluxDBv2_TracingType { get; set; }
            public System.Boolean? InfluxDBv2_UiDisabled { get; set; }
            public System.String InfluxDBv3Core_DataFusionConfig { get; set; }
            public System.Int32? InfluxDBv3Core_DataFusionMaxParquetFanout { get; set; }
            public System.Int32? InfluxDBv3Core_DataFusionNumThread { get; set; }
            public System.Boolean? InfluxDBv3Core_DataFusionRuntimeDisableLifoSlot { get; set; }
            public System.Int32? InfluxDBv3Core_DataFusionRuntimeEventInterval { get; set; }
            public System.Int32? InfluxDBv3Core_DataFusionRuntimeGlobalQueueInterval { get; set; }
            public System.Int32? InfluxDBv3Core_DataFusionRuntimeMaxBlockingThread { get; set; }
            public System.Int32? InfluxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value { get; set; }
            public System.Int32? InfluxDBv3Core_DataFusionRuntimeThreadPriority { get; set; }
            public Amazon.TimestreamInfluxDB.DataFusionRuntimeType InfluxDBv3Core_DataFusionRuntimeType { get; set; }
            public System.Boolean? InfluxDBv3Core_DataFusionUseCachedParquetLoader { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_DeleteGracePeriod_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_DeleteGracePeriod_Value { get; set; }
            public System.Boolean? InfluxDBv3Core_DisableParquetMemCache { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_DistinctCacheEvictionInterval_Value { get; set; }
            public System.Int64? InfluxDBv3Core_ExecMemPoolBytes_Absolute { get; set; }
            public System.String InfluxDBv3Core_ExecMemPoolBytes_Percent { get; set; }
            public System.Int64? InfluxDBv3Core_ForceSnapshotMemThreshold_Absolute { get; set; }
            public System.String InfluxDBv3Core_ForceSnapshotMemThreshold_Percent { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_Gen1Duration_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_Gen1Duration_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_Gen1LookbackDuration_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_Gen1LookbackDuration_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_HardDeleteDefaultDuration_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_HardDeleteDefaultDuration_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_LastCacheEvictionInterval_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_LastCacheEvictionInterval_Value { get; set; }
            public System.String InfluxDBv3Core_LogFilter { get; set; }
            public Amazon.TimestreamInfluxDB.LogFormats InfluxDBv3Core_LogFormat { get; set; }
            public System.Int64? InfluxDBv3Core_MaxHttpRequestSize { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_ParquetMemCachePruneInterval_Value { get; set; }
            public System.Single? InfluxDBv3Core_ParquetMemCachePrunePercentage { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_ParquetMemCacheQueryPathDuration_Value { get; set; }
            public System.Int64? InfluxDBv3Core_ParquetMemCacheSize_Absolute { get; set; }
            public System.String InfluxDBv3Core_ParquetMemCacheSize_Percent { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_PreemptiveCacheAge_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_PreemptiveCacheAge_Value { get; set; }
            public System.Int32? InfluxDBv3Core_QueryFileLimit { get; set; }
            public System.Int32? InfluxDBv3Core_QueryLogSize { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Core_RetentionCheckInterval_DurationType { get; set; }
            public System.Int64? InfluxDBv3Core_RetentionCheckInterval_Value { get; set; }
            public System.Int32? InfluxDBv3Core_SnapshottedWalFilesToKeep { get; set; }
            public System.Int32? InfluxDBv3Core_TableIndexCacheConcurrencyLimit { get; set; }
            public System.Int32? InfluxDBv3Core_TableIndexCacheMaxEntry { get; set; }
            public System.Int32? InfluxDBv3Core_WalMaxWriteBufferSize { get; set; }
            public System.Int32? InfluxDBv3Core_WalReplayConcurrencyLimit { get; set; }
            public System.Boolean? InfluxDBv3Core_WalReplayFailOnError { get; set; }
            public System.Int32? InfluxDBv3Core_WalSnapshotSize { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType CatalogSyncInterval_DurationType { get; set; }
            public System.Int64? CatalogSyncInterval_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType CompactionCheckInterval_DurationType { get; set; }
            public System.Int64? CompactionCheckInterval_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType CompactionCleanupWait_DurationType { get; set; }
            public System.Int64? CompactionCleanupWait_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType CompactionGen2Duration_DurationType { get; set; }
            public System.Int64? CompactionGen2Duration_Value { get; set; }
            public System.Int32? InfluxDBv3Enterprise_CompactionMaxNumFilesPerPlan { get; set; }
            public System.String InfluxDBv3Enterprise_CompactionMultiplier { get; set; }
            public System.Int32? InfluxDBv3Enterprise_CompactionRowLimit { get; set; }
            public System.String InfluxDBv3Enterprise_DataFusionConfig { get; set; }
            public System.Int32? InfluxDBv3Enterprise_DataFusionMaxParquetFanout { get; set; }
            public System.Int32? InfluxDBv3Enterprise_DataFusionNumThread { get; set; }
            public System.Boolean? InfluxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot { get; set; }
            public System.Int32? InfluxDBv3Enterprise_DataFusionRuntimeEventInterval { get; set; }
            public System.Int32? InfluxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval { get; set; }
            public System.Int32? InfluxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread { get; set; }
            public System.Int32? InfluxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value { get; set; }
            public System.Int32? InfluxDBv3Enterprise_DataFusionRuntimeThreadPriority { get; set; }
            public Amazon.TimestreamInfluxDB.DataFusionRuntimeType InfluxDBv3Enterprise_DataFusionRuntimeType { get; set; }
            public System.Boolean? InfluxDBv3Enterprise_DataFusionUseCachedParquetLoader { get; set; }
            public System.Boolean? InfluxDBv3Enterprise_DedicatedCompactor { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_DeleteGracePeriod_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_DeleteGracePeriod_Value { get; set; }
            public System.Boolean? InfluxDBv3Enterprise_DisableParquetMemCache { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_DistinctCacheEvictionInterval_Value { get; set; }
            public System.Boolean? InfluxDBv3Enterprise_DistinctValueCacheDisableFromHistory { get; set; }
            public System.Int64? InfluxDBv3Enterprise_ExecMemPoolBytes_Absolute { get; set; }
            public System.String InfluxDBv3Enterprise_ExecMemPoolBytes_Percent { get; set; }
            public System.Int64? InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute { get; set; }
            public System.String InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Percent { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_Gen1Duration_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_Gen1Duration_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_Gen1LookbackDuration_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_HardDeleteDefaultDuration_Value { get; set; }
            public System.Int32? InfluxDBv3Enterprise_IngestQueryInstance { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_LastCacheEvictionInterval_Value { get; set; }
            public System.Boolean? InfluxDBv3Enterprise_LastValueCacheDisableFromHistory { get; set; }
            public System.String InfluxDBv3Enterprise_LogFilter { get; set; }
            public Amazon.TimestreamInfluxDB.LogFormats InfluxDBv3Enterprise_LogFormat { get; set; }
            public System.Int64? InfluxDBv3Enterprise_MaxHttpRequestSize { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_ParquetMemCachePruneInterval_Value { get; set; }
            public System.Single? InfluxDBv3Enterprise_ParquetMemCachePrunePercentage { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value { get; set; }
            public System.Int64? InfluxDBv3Enterprise_ParquetMemCacheSize_Absolute { get; set; }
            public System.String InfluxDBv3Enterprise_ParquetMemCacheSize_Percent { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_PreemptiveCacheAge_Value { get; set; }
            public System.Int32? InfluxDBv3Enterprise_QueryFileLimit { get; set; }
            public System.Int32? InfluxDBv3Enterprise_QueryLogSize { get; set; }
            public System.Int32? InfluxDBv3Enterprise_QueryOnlyInstance { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType ReplicationInterval_DurationType { get; set; }
            public System.Int64? ReplicationInterval_Value { get; set; }
            public Amazon.TimestreamInfluxDB.DurationType InfluxDBv3Enterprise_RetentionCheckInterval_DurationType { get; set; }
            public System.Int64? InfluxDBv3Enterprise_RetentionCheckInterval_Value { get; set; }
            public System.Int32? InfluxDBv3Enterprise_SnapshottedWalFilesToKeep { get; set; }
            public System.Int32? InfluxDBv3Enterprise_TableIndexCacheConcurrencyLimit { get; set; }
            public System.Int32? InfluxDBv3Enterprise_TableIndexCacheMaxEntry { get; set; }
            public System.Int32? InfluxDBv3Enterprise_WalMaxWriteBufferSize { get; set; }
            public System.Int32? InfluxDBv3Enterprise_WalReplayConcurrencyLimit { get; set; }
            public System.Boolean? InfluxDBv3Enterprise_WalReplayFailOnError { get; set; }
            public System.Int32? InfluxDBv3Enterprise_WalSnapshotSize { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse, NewTIDBDbParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
