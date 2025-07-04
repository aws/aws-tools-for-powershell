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
using System.Threading;
using Amazon.PI;
using Amazon.PI.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PI
{
    /// <summary>
    /// For a specific time period, retrieve the top <c>N</c> dimension keys for a metric.
    /// 
    /// 
    ///  <note><para>
    /// Each response element returns a maximum of 500 bytes. For larger elements, such as
    /// SQL statements, only the first 500 bytes are returned.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "PIDimensionKey")]
    [OutputType("Amazon.PI.Model.DescribeDimensionKeysResponse")]
    [AWSCmdlet("Calls the AWS Performance Insights DescribeDimensionKeys API operation.", Operation = new[] {"DescribeDimensionKeys"}, SelectReturnType = typeof(Amazon.PI.Model.DescribeDimensionKeysResponse))]
    [AWSCmdletOutput("Amazon.PI.Model.DescribeDimensionKeysResponse",
        "This cmdlet returns an Amazon.PI.Model.DescribeDimensionKeysResponse object containing multiple properties."
    )]
    public partial class GetPIDimensionKeyCmdlet : AmazonPIClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalMetric
        /// <summary>
        /// <para>
        /// <para>Additional metrics for the top <c>N</c> dimension keys. If the specified dimension
        /// group in the <c>GroupBy</c> parameter is <c>db.sql_tokenized</c>, you can specify
        /// per-SQL metrics to get the values for the top <c>N</c> SQL digests. The response syntax
        /// is as follows: <c>"AdditionalMetrics" : { "<i>string</i>" : "<i>string</i>" }</c>.</para><para>The only supported statistic function is <c>.avg</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalMetrics")]
        public System.String[] AdditionalMetric { get; set; }
        #endregion
        
        #region Parameter GroupBy_Dimension
        /// <summary>
        /// <para>
        /// <para>A list of specific dimensions from a dimension group. If this parameter is not present,
        /// then it signifies that all of the dimensions in the group were requested, or are present
        /// in the response.</para><para>Valid values for elements in the <c>Dimensions</c> array are:</para><ul><li><para><c>db.application.name</c> - The name of the application that is connected to the
        /// database. Valid values are as follows: </para><ul><li><para>Aurora PostgreSQL</para></li><li><para>Amazon RDS PostgreSQL</para></li><li><para>Amazon DocumentDB</para></li></ul></li><li><para><c>db.blocking_sql.id</c> - The ID for each of the SQL queries blocking the most
        /// DB load.</para></li><li><para><c>db.blocking_sql.sql</c> - The SQL text for each of the SQL queries blocking the
        /// most DB load.</para></li><li><para><c>db.blocking_session.id</c> - The ID for each of the sessions blocking the most
        /// DB load.</para></li><li><para><c>db.blocking_object.id</c> - The ID for each of the object resources acquired by
        /// other sessions that are blocking the most DB load.</para></li><li><para><c>db.blocking_object.type</c> - The object type for each of the object resources
        /// acquired by other sessions that are blocking the most DB load.</para></li><li><para><c>db.blocking_object.value</c> - The value for each of the object resources acquired
        /// by other sessions that are blocking the most DB load.</para></li><li><para><c>db.host.id</c> - The host ID of the connected client (all engines).</para></li><li><para><c>db.host.name</c> - The host name of the connected client (all engines).</para></li><li><para><c>db.name</c> - The name of the database to which the client is connected. Valid
        /// values are as follows:</para><ul><li><para>Aurora PostgreSQL</para></li><li><para>Amazon RDS PostgreSQL</para></li><li><para>Aurora MySQL</para></li><li><para>Amazon RDS MySQL</para></li><li><para>Amazon RDS MariaDB</para></li><li><para>Amazon DocumentDB</para></li></ul></li><li><para><c>db.query.id</c> - The query ID generated by Performance Insights (only Amazon
        /// DocumentDB).</para></li><li><para><c>db.query.db_id</c> - The query ID generated by the database (only Amazon DocumentDB).</para></li><li><para><c>db.query.statement</c> - The text of the query that is being run (only Amazon
        /// DocumentDB).</para></li><li><para><c>db.query.tokenized_id</c></para></li><li><para><c>db.query.tokenized.id</c> - The query digest ID generated by Performance Insights
        /// (only Amazon DocumentDB).</para></li><li><para><c>db.query.tokenized.db_id</c> - The query digest ID generated by Performance Insights
        /// (only Amazon DocumentDB).</para></li><li><para><c>db.query.tokenized.statement</c> - The text of the query digest (only Amazon DocumentDB).</para></li><li><para><c>db.session_type.name</c> - The type of the current session (only Amazon DocumentDB).</para></li><li><para><c>db.sql.id</c> - The hash of the full, non-tokenized SQL statement generated by
        /// Performance Insights (all engines except Amazon DocumentDB).</para></li><li><para><c>db.sql.db_id</c> - Either the SQL ID generated by the database engine, or a value
        /// generated by Performance Insights that begins with <c>pi-</c> (all engines except
        /// Amazon DocumentDB).</para></li><li><para><c>db.sql.statement</c> - The full text of the SQL statement that is running, as
        /// in <c>SELECT * FROM employees</c> (all engines except Amazon DocumentDB)</para></li><li><para><c>db.sql.tokenized_id</c> - The hash of the SQL digest generated by Performance
        /// Insights (all engines except Amazon DocumentDB). The <c>db.sql.tokenized_id</c> dimension
        /// fetches the value of the <c>db.sql_tokenized.id</c> dimension. Amazon RDS returns
        /// <c>db.sql.tokenized_id</c> from the <c>db.sql</c> dimension group. </para></li><li><para><c>db.sql_tokenized.id</c> - The hash of the SQL digest generated by Performance
        /// Insights (all engines except Amazon DocumentDB). In the console, <c>db.sql_tokenized.id</c>
        /// is called the Support ID because Amazon Web Services Support can look at this data
        /// to help you troubleshoot database issues.</para></li><li><para><c>db.sql_tokenized.db_id</c> - Either the native database ID used to refer to the
        /// SQL statement, or a synthetic ID such as <c>pi-2372568224</c> that Performance Insights
        /// generates if the native database ID isn't available (all engines except Amazon DocumentDB).</para></li><li><para><c>db.sql_tokenized.statement</c> - The text of the SQL digest, as in <c>SELECT *
        /// FROM employees WHERE employee_id = ?</c> (all engines except Amazon DocumentDB)</para></li><li><para><c>db.user.id</c> - The ID of the user logged in to the database (all engines except
        /// Amazon DocumentDB).</para></li><li><para><c>db.user.name</c> - The name of the user logged in to the database (all engines
        /// except Amazon DocumentDB).</para></li><li><para><c>db.wait_event.name</c> - The event for which the backend is waiting (all engines
        /// except Amazon DocumentDB).</para></li><li><para><c>db.wait_event.type</c> - The type of event for which the backend is waiting (all
        /// engines except Amazon DocumentDB).</para></li><li><para><c>db.wait_event_type.name</c> - The name of the event type for which the backend
        /// is waiting (all engines except Amazon DocumentDB).</para></li><li><para><c>db.wait_state.name</c> - The event for which the backend is waiting (only Amazon
        /// DocumentDB).</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupBy_Dimensions")]
        public System.String[] GroupBy_Dimension { get; set; }
        #endregion
        
        #region Parameter PartitionBy_Dimension
        /// <summary>
        /// <para>
        /// <para>A list of specific dimensions from a dimension group. If this parameter is not present,
        /// then it signifies that all of the dimensions in the group were requested, or are present
        /// in the response.</para><para>Valid values for elements in the <c>Dimensions</c> array are:</para><ul><li><para><c>db.application.name</c> - The name of the application that is connected to the
        /// database. Valid values are as follows: </para><ul><li><para>Aurora PostgreSQL</para></li><li><para>Amazon RDS PostgreSQL</para></li><li><para>Amazon DocumentDB</para></li></ul></li><li><para><c>db.blocking_sql.id</c> - The ID for each of the SQL queries blocking the most
        /// DB load.</para></li><li><para><c>db.blocking_sql.sql</c> - The SQL text for each of the SQL queries blocking the
        /// most DB load.</para></li><li><para><c>db.blocking_session.id</c> - The ID for each of the sessions blocking the most
        /// DB load.</para></li><li><para><c>db.blocking_object.id</c> - The ID for each of the object resources acquired by
        /// other sessions that are blocking the most DB load.</para></li><li><para><c>db.blocking_object.type</c> - The object type for each of the object resources
        /// acquired by other sessions that are blocking the most DB load.</para></li><li><para><c>db.blocking_object.value</c> - The value for each of the object resources acquired
        /// by other sessions that are blocking the most DB load.</para></li><li><para><c>db.host.id</c> - The host ID of the connected client (all engines).</para></li><li><para><c>db.host.name</c> - The host name of the connected client (all engines).</para></li><li><para><c>db.name</c> - The name of the database to which the client is connected. Valid
        /// values are as follows:</para><ul><li><para>Aurora PostgreSQL</para></li><li><para>Amazon RDS PostgreSQL</para></li><li><para>Aurora MySQL</para></li><li><para>Amazon RDS MySQL</para></li><li><para>Amazon RDS MariaDB</para></li><li><para>Amazon DocumentDB</para></li></ul></li><li><para><c>db.query.id</c> - The query ID generated by Performance Insights (only Amazon
        /// DocumentDB).</para></li><li><para><c>db.query.db_id</c> - The query ID generated by the database (only Amazon DocumentDB).</para></li><li><para><c>db.query.statement</c> - The text of the query that is being run (only Amazon
        /// DocumentDB).</para></li><li><para><c>db.query.tokenized_id</c></para></li><li><para><c>db.query.tokenized.id</c> - The query digest ID generated by Performance Insights
        /// (only Amazon DocumentDB).</para></li><li><para><c>db.query.tokenized.db_id</c> - The query digest ID generated by Performance Insights
        /// (only Amazon DocumentDB).</para></li><li><para><c>db.query.tokenized.statement</c> - The text of the query digest (only Amazon DocumentDB).</para></li><li><para><c>db.session_type.name</c> - The type of the current session (only Amazon DocumentDB).</para></li><li><para><c>db.sql.id</c> - The hash of the full, non-tokenized SQL statement generated by
        /// Performance Insights (all engines except Amazon DocumentDB).</para></li><li><para><c>db.sql.db_id</c> - Either the SQL ID generated by the database engine, or a value
        /// generated by Performance Insights that begins with <c>pi-</c> (all engines except
        /// Amazon DocumentDB).</para></li><li><para><c>db.sql.statement</c> - The full text of the SQL statement that is running, as
        /// in <c>SELECT * FROM employees</c> (all engines except Amazon DocumentDB)</para></li><li><para><c>db.sql.tokenized_id</c> - The hash of the SQL digest generated by Performance
        /// Insights (all engines except Amazon DocumentDB). The <c>db.sql.tokenized_id</c> dimension
        /// fetches the value of the <c>db.sql_tokenized.id</c> dimension. Amazon RDS returns
        /// <c>db.sql.tokenized_id</c> from the <c>db.sql</c> dimension group. </para></li><li><para><c>db.sql_tokenized.id</c> - The hash of the SQL digest generated by Performance
        /// Insights (all engines except Amazon DocumentDB). In the console, <c>db.sql_tokenized.id</c>
        /// is called the Support ID because Amazon Web Services Support can look at this data
        /// to help you troubleshoot database issues.</para></li><li><para><c>db.sql_tokenized.db_id</c> - Either the native database ID used to refer to the
        /// SQL statement, or a synthetic ID such as <c>pi-2372568224</c> that Performance Insights
        /// generates if the native database ID isn't available (all engines except Amazon DocumentDB).</para></li><li><para><c>db.sql_tokenized.statement</c> - The text of the SQL digest, as in <c>SELECT *
        /// FROM employees WHERE employee_id = ?</c> (all engines except Amazon DocumentDB)</para></li><li><para><c>db.user.id</c> - The ID of the user logged in to the database (all engines except
        /// Amazon DocumentDB).</para></li><li><para><c>db.user.name</c> - The name of the user logged in to the database (all engines
        /// except Amazon DocumentDB).</para></li><li><para><c>db.wait_event.name</c> - The event for which the backend is waiting (all engines
        /// except Amazon DocumentDB).</para></li><li><para><c>db.wait_event.type</c> - The type of event for which the backend is waiting (all
        /// engines except Amazon DocumentDB).</para></li><li><para><c>db.wait_event_type.name</c> - The name of the event type for which the backend
        /// is waiting (all engines except Amazon DocumentDB).</para></li><li><para><c>db.wait_state.name</c> - The event for which the backend is waiting (only Amazon
        /// DocumentDB).</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PartitionBy_Dimensions")]
        public System.String[] PartitionBy_Dimension { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The date and time specifying the end of the requested time series data. The value
        /// specified is <i>exclusive</i>, which means that data points less than (but not equal
        /// to) <c>EndTime</c> are returned.</para><para>The value for <c>EndTime</c> must be later than the value for <c>StartTime</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters to apply in the request. Restrictions:</para><ul><li><para>Any number of filters by the same dimension, as specified in the <c>GroupBy</c> or
        /// <c>Partition</c> parameters.</para></li><li><para>A single filter for any other dimension in this dimension group.</para></li></ul><note><para>The <c>db.sql.db_id</c> filter isn't available for RDS for SQL Server DB instances.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Filter { get; set; }
        #endregion
        
        #region Parameter GroupBy_Group
        /// <summary>
        /// <para>
        /// <para>The name of the dimension group. Valid values are as follows:</para><ul><li><para><c>db</c> - The name of the database to which the client is connected. The following
        /// values are permitted:</para><ul><li><para>Aurora PostgreSQL</para></li><li><para>Amazon RDS PostgreSQL</para></li><li><para>Aurora MySQL</para></li><li><para>Amazon RDS MySQL</para></li><li><para>Amazon RDS MariaDB</para></li><li><para>Amazon DocumentDB</para></li></ul></li><li><para><c>db.application</c> - The name of the application that is connected to the database.
        /// The following values are permitted:</para><ul><li><para>Aurora PostgreSQL</para></li><li><para>Amazon RDS PostgreSQL</para></li><li><para>Amazon DocumentDB</para></li></ul></li><li><para><c>db.blocking_sql</c> - The SQL queries blocking the most DB load.</para></li><li><para><c>db.blocking_session</c> - The sessions blocking the most DB load.</para></li><li><para><c>db.blocking_object</c> - The object resources acquired by other sessions that
        /// are blocking the most DB load.</para></li><li><para><c>db.host</c> - The host name of the connected client (all engines).</para></li><li><para><c>db.plans</c> - The execution plans for the query (only Aurora PostgreSQL).</para></li><li><para><c>db.query</c> - The query that is currently running (only Amazon DocumentDB).</para></li><li><para><c>db.query_tokenized</c> - The digest query (only Amazon DocumentDB).</para></li><li><para><c>db.session_type</c> - The type of the current session (only Aurora PostgreSQL
        /// and RDS PostgreSQL).</para></li><li><para><c>db.sql</c> - The text of the SQL statement that is currently running (all engines
        /// except Amazon DocumentDB).</para></li><li><para><c>db.sql_tokenized</c> - The SQL digest (all engines except Amazon DocumentDB).</para></li><li><para><c>db.user</c> - The user logged in to the database (all engines except Amazon DocumentDB).</para></li><li><para><c>db.wait_event</c> - The event for which the database backend is waiting (all engines
        /// except Amazon DocumentDB).</para></li><li><para><c>db.wait_event_type</c> - The type of event for which the database backend is waiting
        /// (all engines except Amazon DocumentDB).</para></li><li><para><c>db.wait_state</c> - The event for which the database backend is waiting (only
        /// Amazon DocumentDB).</para></li></ul>
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
        public System.String GroupBy_Group { get; set; }
        #endregion
        
        #region Parameter PartitionBy_Group
        /// <summary>
        /// <para>
        /// <para>The name of the dimension group. Valid values are as follows:</para><ul><li><para><c>db</c> - The name of the database to which the client is connected. The following
        /// values are permitted:</para><ul><li><para>Aurora PostgreSQL</para></li><li><para>Amazon RDS PostgreSQL</para></li><li><para>Aurora MySQL</para></li><li><para>Amazon RDS MySQL</para></li><li><para>Amazon RDS MariaDB</para></li><li><para>Amazon DocumentDB</para></li></ul></li><li><para><c>db.application</c> - The name of the application that is connected to the database.
        /// The following values are permitted:</para><ul><li><para>Aurora PostgreSQL</para></li><li><para>Amazon RDS PostgreSQL</para></li><li><para>Amazon DocumentDB</para></li></ul></li><li><para><c>db.blocking_sql</c> - The SQL queries blocking the most DB load.</para></li><li><para><c>db.blocking_session</c> - The sessions blocking the most DB load.</para></li><li><para><c>db.blocking_object</c> - The object resources acquired by other sessions that
        /// are blocking the most DB load.</para></li><li><para><c>db.host</c> - The host name of the connected client (all engines).</para></li><li><para><c>db.plans</c> - The execution plans for the query (only Aurora PostgreSQL).</para></li><li><para><c>db.query</c> - The query that is currently running (only Amazon DocumentDB).</para></li><li><para><c>db.query_tokenized</c> - The digest query (only Amazon DocumentDB).</para></li><li><para><c>db.session_type</c> - The type of the current session (only Aurora PostgreSQL
        /// and RDS PostgreSQL).</para></li><li><para><c>db.sql</c> - The text of the SQL statement that is currently running (all engines
        /// except Amazon DocumentDB).</para></li><li><para><c>db.sql_tokenized</c> - The SQL digest (all engines except Amazon DocumentDB).</para></li><li><para><c>db.user</c> - The user logged in to the database (all engines except Amazon DocumentDB).</para></li><li><para><c>db.wait_event</c> - The event for which the database backend is waiting (all engines
        /// except Amazon DocumentDB).</para></li><li><para><c>db.wait_event_type</c> - The type of event for which the database backend is waiting
        /// (all engines except Amazon DocumentDB).</para></li><li><para><c>db.wait_state</c> - The event for which the database backend is waiting (only
        /// Amazon DocumentDB).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PartitionBy_Group { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>An immutable, Amazon Web Services Region-unique identifier for a data source. Performance
        /// Insights gathers metrics from this data source.</para><para>To use an Amazon RDS instance as a data source, you specify its <c>DbiResourceId</c>
        /// value. For example, specify <c>db-FAIHNTYBKTGAUSUZQYPDS2GW4A</c>. </para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter GroupBy_Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to fetch for this dimension group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? GroupBy_Limit { get; set; }
        #endregion
        
        #region Parameter PartitionBy_Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to fetch for this dimension group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PartitionBy_Limit { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>The name of a Performance Insights metric to be measured.</para><para>Valid values for <c>Metric</c> are:</para><ul><li><para><c>db.load.avg</c> - A scaled representation of the number of active sessions for
        /// the database engine. </para></li><li><para><c>db.sampledload.avg</c> - The raw number of active sessions for the database engine.
        /// </para></li></ul><para>If the number of active sessions is less than an internal Performance Insights threshold,
        /// <c>db.load.avg</c> and <c>db.sampledload.avg</c> are the same value. If the number
        /// of active sessions is greater than the internal threshold, Performance Insights samples
        /// the active sessions, with <c>db.load.avg</c> showing the scaled values, <c>db.sampledload.avg</c>
        /// showing the raw values, and <c>db.sampledload.avg</c> less than <c>db.load.avg</c>.
        /// For most use cases, you can query <c>db.load.avg</c> only. </para>
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
        public System.String Metric { get; set; }
        #endregion
        
        #region Parameter PeriodInSecond
        /// <summary>
        /// <para>
        /// <para>The granularity, in seconds, of the data points returned from Performance Insights.
        /// A period can be as short as one second, or as long as one day (86400 seconds). Valid
        /// values are: </para><ul><li><para><c>1</c> (one second)</para></li><li><para><c>60</c> (one minute)</para></li><li><para><c>300</c> (five minutes)</para></li><li><para><c>3600</c> (one hour)</para></li><li><para><c>86400</c> (twenty-four hours)</para></li></ul><para>If you don't specify <c>PeriodInSeconds</c>, then Performance Insights chooses a value
        /// for you, with a goal of returning roughly 100-200 data points in the response. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PeriodInSeconds")]
        public System.Int32? PeriodInSecond { get; set; }
        #endregion
        
        #region Parameter ServiceType
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services service for which Performance Insights will return metrics.
        /// Valid values are as follows:</para><ul><li><para><c>RDS</c></para></li><li><para><c>DOCDB</c></para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PI.ServiceType")]
        public Amazon.PI.ServiceType ServiceType { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time specifying the beginning of the requested time series data. You
        /// must specify a <c>StartTime</c> within the past 7 days. The value specified is <i>inclusive</i>,
        /// which means that data points equal to or greater than <c>StartTime</c> are returned.
        /// </para><para>The value for <c>StartTime</c> must be earlier than the value for <c>EndTime</c>.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in the response. If more items exist than the
        /// specified <c>MaxRecords</c> value, a pagination token is included in the response
        /// so that the remaining results can be retrieved. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the token, up to the value specified
        /// by <c>MaxRecords</c>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PI.Model.DescribeDimensionKeysResponse).
        /// Specifying the name of a property of type Amazon.PI.Model.DescribeDimensionKeysResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PI.Model.DescribeDimensionKeysResponse, GetPIDimensionKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalMetric != null)
            {
                context.AdditionalMetric = new List<System.String>(this.AdditionalMetric);
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filter != null)
            {
                context.Filter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filter.Keys)
                {
                    context.Filter.Add((String)hashKey, (System.String)(this.Filter[hashKey]));
                }
            }
            if (this.GroupBy_Dimension != null)
            {
                context.GroupBy_Dimension = new List<System.String>(this.GroupBy_Dimension);
            }
            context.GroupBy_Group = this.GroupBy_Group;
            #if MODULAR
            if (this.GroupBy_Group == null && ParameterWasBound(nameof(this.GroupBy_Group)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupBy_Group which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GroupBy_Limit = this.GroupBy_Limit;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.Metric = this.Metric;
            #if MODULAR
            if (this.Metric == null && ParameterWasBound(nameof(this.Metric)))
            {
                WriteWarning("You are passing $null as a value for parameter Metric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            if (this.PartitionBy_Dimension != null)
            {
                context.PartitionBy_Dimension = new List<System.String>(this.PartitionBy_Dimension);
            }
            context.PartitionBy_Group = this.PartitionBy_Group;
            context.PartitionBy_Limit = this.PartitionBy_Limit;
            context.PeriodInSecond = this.PeriodInSecond;
            context.ServiceType = this.ServiceType;
            #if MODULAR
            if (this.ServiceType == null && ParameterWasBound(nameof(this.ServiceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.PI.Model.DescribeDimensionKeysRequest();
            
            if (cmdletContext.AdditionalMetric != null)
            {
                request.AdditionalMetrics = cmdletContext.AdditionalMetric;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            
             // populate GroupBy
            var requestGroupByIsNull = true;
            request.GroupBy = new Amazon.PI.Model.DimensionGroup();
            List<System.String> requestGroupBy_groupBy_Dimension = null;
            if (cmdletContext.GroupBy_Dimension != null)
            {
                requestGroupBy_groupBy_Dimension = cmdletContext.GroupBy_Dimension;
            }
            if (requestGroupBy_groupBy_Dimension != null)
            {
                request.GroupBy.Dimensions = requestGroupBy_groupBy_Dimension;
                requestGroupByIsNull = false;
            }
            System.String requestGroupBy_groupBy_Group = null;
            if (cmdletContext.GroupBy_Group != null)
            {
                requestGroupBy_groupBy_Group = cmdletContext.GroupBy_Group;
            }
            if (requestGroupBy_groupBy_Group != null)
            {
                request.GroupBy.Group = requestGroupBy_groupBy_Group;
                requestGroupByIsNull = false;
            }
            System.Int32? requestGroupBy_groupBy_Limit = null;
            if (cmdletContext.GroupBy_Limit != null)
            {
                requestGroupBy_groupBy_Limit = cmdletContext.GroupBy_Limit.Value;
            }
            if (requestGroupBy_groupBy_Limit != null)
            {
                request.GroupBy.Limit = requestGroupBy_groupBy_Limit.Value;
                requestGroupByIsNull = false;
            }
             // determine if request.GroupBy should be set to null
            if (requestGroupByIsNull)
            {
                request.GroupBy = null;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Metric != null)
            {
                request.Metric = cmdletContext.Metric;
            }
            
             // populate PartitionBy
            var requestPartitionByIsNull = true;
            request.PartitionBy = new Amazon.PI.Model.DimensionGroup();
            List<System.String> requestPartitionBy_partitionBy_Dimension = null;
            if (cmdletContext.PartitionBy_Dimension != null)
            {
                requestPartitionBy_partitionBy_Dimension = cmdletContext.PartitionBy_Dimension;
            }
            if (requestPartitionBy_partitionBy_Dimension != null)
            {
                request.PartitionBy.Dimensions = requestPartitionBy_partitionBy_Dimension;
                requestPartitionByIsNull = false;
            }
            System.String requestPartitionBy_partitionBy_Group = null;
            if (cmdletContext.PartitionBy_Group != null)
            {
                requestPartitionBy_partitionBy_Group = cmdletContext.PartitionBy_Group;
            }
            if (requestPartitionBy_partitionBy_Group != null)
            {
                request.PartitionBy.Group = requestPartitionBy_partitionBy_Group;
                requestPartitionByIsNull = false;
            }
            System.Int32? requestPartitionBy_partitionBy_Limit = null;
            if (cmdletContext.PartitionBy_Limit != null)
            {
                requestPartitionBy_partitionBy_Limit = cmdletContext.PartitionBy_Limit.Value;
            }
            if (requestPartitionBy_partitionBy_Limit != null)
            {
                request.PartitionBy.Limit = requestPartitionBy_partitionBy_Limit.Value;
                requestPartitionByIsNull = false;
            }
             // determine if request.PartitionBy should be set to null
            if (requestPartitionByIsNull)
            {
                request.PartitionBy = null;
            }
            if (cmdletContext.PeriodInSecond != null)
            {
                request.PeriodInSeconds = cmdletContext.PeriodInSecond.Value;
            }
            if (cmdletContext.ServiceType != null)
            {
                request.ServiceType = cmdletContext.ServiceType;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.PI.Model.DescribeDimensionKeysResponse CallAWSServiceOperation(IAmazonPI client, Amazon.PI.Model.DescribeDimensionKeysRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Performance Insights", "DescribeDimensionKeys");
            try
            {
                return client.DescribeDimensionKeysAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AdditionalMetric { get; set; }
            public System.DateTime? EndTime { get; set; }
            public Dictionary<System.String, System.String> Filter { get; set; }
            public List<System.String> GroupBy_Dimension { get; set; }
            public System.String GroupBy_Group { get; set; }
            public System.Int32? GroupBy_Limit { get; set; }
            public System.String Identifier { get; set; }
            public int? MaxResult { get; set; }
            public System.String Metric { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> PartitionBy_Dimension { get; set; }
            public System.String PartitionBy_Group { get; set; }
            public System.Int32? PartitionBy_Limit { get; set; }
            public System.Int32? PeriodInSecond { get; set; }
            public Amazon.PI.ServiceType ServiceType { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.PI.Model.DescribeDimensionKeysResponse, GetPIDimensionKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
