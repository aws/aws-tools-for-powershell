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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the DB parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
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
        
        #region Parameter InfluxDBv2_PprofDisabled
        /// <summary>
        /// <para>
        /// <para>Disable the /debug/pprof HTTP endpoint. This endpoint provides runtime profiling data
        /// and can be helpful when debugging.</para><para>Default: false</para>
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
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse, NewTIDBDbParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
