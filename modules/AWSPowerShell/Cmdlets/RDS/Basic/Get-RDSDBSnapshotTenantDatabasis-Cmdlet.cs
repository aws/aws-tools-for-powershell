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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Describes the tenant databases that exist in a DB snapshot. This command only applies
    /// to RDS for Oracle DB instances in the multi-tenant configuration.
    /// 
    ///  
    /// <para>
    /// You can use this command to inspect the tenant databases within a snapshot before
    /// restoring it. You can't directly interact with the tenant databases in a DB snapshot.
    /// If you restore a snapshot that was taken from DB instance using the multi-tenant configuration,
    /// you restore all its tenant databases.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RDSDBSnapshotTenantDatabasis")]
    [OutputType("Amazon.RDS.Model.DBSnapshotTenantDatabase")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeDBSnapshotTenantDatabases API operation.", Operation = new[] {"DescribeDBSnapshotTenantDatabases"}, SelectReturnType = typeof(Amazon.RDS.Model.DescribeDBSnapshotTenantDatabasesResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSnapshotTenantDatabase or Amazon.RDS.Model.DescribeDBSnapshotTenantDatabasesResponse",
        "This cmdlet returns a collection of Amazon.RDS.Model.DBSnapshotTenantDatabase objects.",
        "The service call response (type Amazon.RDS.Model.DescribeDBSnapshotTenantDatabasesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRDSDBSnapshotTenantDatabasisCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the DB instance used to create the DB snapshots. This parameter isn't case-sensitive.</para><para>Constraints:</para><ul><li><para>If supplied, must match the identifier of an existing <c>DBInstance</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DbiResourceId
        /// <summary>
        /// <para>
        /// <para>A specific DB resource identifier to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbiResourceId { get; set; }
        #endregion
        
        #region Parameter DBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of a DB snapshot that contains the tenant databases to describe. This value
        /// is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>If you specify this parameter, the value must match the ID of an existing DB snapshot.</para></li><li><para>If you specify an automatic snapshot, you must also specify <c>SnapshotType</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A filter that specifies one or more tenant databases to describe.</para><para>Supported filters:</para><ul><li><para><c>tenant-db-name</c> - Tenant database names. The results list only includes information
        /// about the tenant databases that match these tenant DB names.</para></li><li><para><c>tenant-database-resource-id</c> - Tenant database resource identifiers. The results
        /// list only includes information about the tenant databases contained within the DB
        /// snapshots.</para></li><li><para><c>dbi-resource-id</c> - DB instance resource identifiers. The results list only
        /// includes information about snapshots containing tenant databases contained within
        /// the DB instances identified by these resource identifiers.</para></li><li><para><c>db-instance-id</c> - Accepts DB instance identifiers and DB instance Amazon Resource
        /// Names (ARNs).</para></li><li><para><c>db-snapshot-id</c> - Accepts DB snapshot identifiers.</para></li><li><para><c>snapshot-type</c> - Accepts types of DB snapshots.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SnapshotType
        /// <summary>
        /// <para>
        /// <para>The type of DB snapshots to be returned. You can specify one of the following values:</para><ul><li><para><c>automated</c> – All DB snapshots that have been automatically taken by Amazon
        /// RDS for my Amazon Web Services account.</para></li><li><para><c>manual</c> – All DB snapshots that have been taken by my Amazon Web Services account.</para></li><li><para><c>shared</c> – All manual DB snapshots that have been shared to my Amazon Web Services
        /// account.</para></li><li><para><c>public</c> – All DB snapshots that have been marked as public.</para></li><li><para><c>awsbackup</c> – All DB snapshots managed by the Amazon Web Services Backup service.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotType { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous <c>DescribeDBSnapshotTenantDatabases</c>
        /// request. If this parameter is specified, the response includes only records beyond
        /// the marker, up to the value specified by <c>MaxRecords</c>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in the response. If more records exist than
        /// the specified <c>MaxRecords</c> value, a pagination token called a marker is included
        /// in the response so that you can retrieve the remaining results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBSnapshotTenantDatabases'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DescribeDBSnapshotTenantDatabasesResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DescribeDBSnapshotTenantDatabasesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBSnapshotTenantDatabases";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DescribeDBSnapshotTenantDatabasesResponse, GetRDSDBSnapshotTenantDatabasisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            context.DbiResourceId = this.DbiResourceId;
            context.DBSnapshotIdentifier = this.DBSnapshotIdentifier;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.RDS.Model.Filter>(this.Filter);
            }
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            context.SnapshotType = this.SnapshotType;
            
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
            var request = new Amazon.RDS.Model.DescribeDBSnapshotTenantDatabasesRequest();
            
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.DbiResourceId != null)
            {
                request.DbiResourceId = cmdletContext.DbiResourceId;
            }
            if (cmdletContext.DBSnapshotIdentifier != null)
            {
                request.DBSnapshotIdentifier = cmdletContext.DBSnapshotIdentifier;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            if (cmdletContext.SnapshotType != null)
            {
                request.SnapshotType = cmdletContext.SnapshotType;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.RDS.Model.DescribeDBSnapshotTenantDatabasesResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeDBSnapshotTenantDatabasesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeDBSnapshotTenantDatabases");
            try
            {
                return client.DescribeDBSnapshotTenantDatabasesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DbiResourceId { get; set; }
            public System.String DBSnapshotIdentifier { get; set; }
            public List<Amazon.RDS.Model.Filter> Filter { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.String SnapshotType { get; set; }
            public System.Func<Amazon.RDS.Model.DescribeDBSnapshotTenantDatabasesResponse, GetRDSDBSnapshotTenantDatabasisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBSnapshotTenantDatabases;
        }
        
    }
}
