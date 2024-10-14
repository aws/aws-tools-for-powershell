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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Returns information about DB snapshots. This API action supports pagination.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RDSDBSnapshot")]
    [OutputType("Amazon.RDS.Model.DBSnapshot")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeDBSnapshots API operation.", Operation = new[] {"DescribeDBSnapshots"}, SelectReturnType = typeof(Amazon.RDS.Model.DescribeDBSnapshotsResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSnapshot or Amazon.RDS.Model.DescribeDBSnapshotsResponse",
        "This cmdlet returns a collection of Amazon.RDS.Model.DBSnapshot objects.",
        "The service call response (type Amazon.RDS.Model.DescribeDBSnapshotsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRDSDBSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the DB instance to retrieve the list of DB snapshots for. This parameter
        /// isn't case-sensitive.</para><para>Constraints:</para><ul><li><para>If supplied, must match the identifier of an existing DBInstance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DbiResourceId
        /// <summary>
        /// <para>
        /// <para>A specific DB resource ID to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbiResourceId { get; set; }
        #endregion
        
        #region Parameter DBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>A specific DB snapshot identifier to describe. This value is stored as a lowercase
        /// string.</para><para>Constraints:</para><ul><li><para>If supplied, must match the identifier of an existing DBSnapshot.</para></li><li><para>If this identifier is for an automated snapshot, the <c>SnapshotType</c> parameter
        /// must also be specified.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String DBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>A filter that specifies one or more DB snapshots to describe.</para><para>Supported filters:</para><ul><li><para><c>db-instance-id</c> - Accepts DB instance identifiers and DB instance Amazon Resource
        /// Names (ARNs).</para></li><li><para><c>db-snapshot-id</c> - Accepts DB snapshot identifiers.</para></li><li><para><c>dbi-resource-id</c> - Accepts identifiers of source DB instances.</para></li><li><para><c>snapshot-type</c> - Accepts types of DB snapshots.</para></li><li><para><c>engine</c> - Accepts names of database engines.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter IncludePublic
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include manual DB cluster snapshots that are public and can be
        /// copied or restored by any Amazon Web Services account. By default, the public snapshots
        /// are not included.</para><para>You can share a manual DB snapshot as public by using the <a>ModifyDBSnapshotAttribute</a>
        /// API.</para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludePublic { get; set; }
        #endregion
        
        #region Parameter IncludeShared
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include shared manual DB cluster snapshots from other Amazon
        /// Web Services accounts that this Amazon Web Services account has been given permission
        /// to copy or restore. By default, these snapshots are not included.</para><para>You can give an Amazon Web Services account permission to restore a manual DB snapshot
        /// from another Amazon Web Services account by using the <c>ModifyDBSnapshotAttribute</c>
        /// API action.</para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeShared { get; set; }
        #endregion
        
        #region Parameter SnapshotType
        /// <summary>
        /// <para>
        /// <para>The type of snapshots to be returned. You can specify one of the following values:</para><ul><li><para><c>automated</c> - Return all DB snapshots that have been automatically taken by
        /// Amazon RDS for my Amazon Web Services account.</para></li><li><para><c>manual</c> - Return all DB snapshots that have been taken by my Amazon Web Services
        /// account.</para></li><li><para><c>shared</c> - Return all manual DB snapshots that have been shared to my Amazon
        /// Web Services account.</para></li><li><para><c>public</c> - Return all DB snapshots that have been marked as public.</para></li><li><para><c>awsbackup</c> - Return the DB snapshots managed by the Amazon Web Services Backup
        /// service.</para><para>For information about Amazon Web Services Backup, see the <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/whatisbackup.html"><i>Amazon Web Services Backup Developer Guide.</i></a></para><para>The <c>awsbackup</c> type does not apply to Aurora.</para></li></ul><para>If you don't specify a <c>SnapshotType</c> value, then both automated and manual snapshots
        /// are returned. Shared and public DB snapshots are not included in the returned results
        /// by default. You can include shared snapshots with these results by enabling the <c>IncludeShared</c>
        /// parameter. You can include public snapshots with these results by enabling the <c>IncludePublic</c>
        /// parameter.</para><para>The <c>IncludeShared</c> and <c>IncludePublic</c> parameters don't apply for <c>SnapshotType</c>
        /// values of <c>manual</c> or <c>automated</c>. The <c>IncludePublic</c> parameter doesn't
        /// apply when <c>SnapshotType</c> is set to <c>shared</c>. The <c>IncludeShared</c> parameter
        /// doesn't apply when <c>SnapshotType</c> is set to <c>public</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotType { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous <c>DescribeDBSnapshots</c> request.
        /// If this parameter is specified, the response includes only records beyond the marker,
        /// up to the value specified by <c>MaxRecords</c>.</para>
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
        /// in the response so that you can retrieve the remaining results.</para><para>Default: 100</para><para>Constraints: Minimum 20, maximum 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxRecords")]
        public int? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBSnapshots'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DescribeDBSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DescribeDBSnapshotsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBSnapshots";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBInstanceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DescribeDBSnapshotsResponse, GetRDSDBSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBInstanceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            context.DbiResourceId = this.DbiResourceId;
            context.DBSnapshotIdentifier = this.DBSnapshotIdentifier;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.RDS.Model.Filter>(this.Filter);
            }
            context.IncludePublic = this.IncludePublic;
            context.IncludeShared = this.IncludeShared;
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxRecord)) && this.MaxRecord.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxRecord parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxRecord" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.SnapshotType = this.SnapshotType;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.RDS.Model.DescribeDBSnapshotsRequest();
            
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
            if (cmdletContext.IncludePublic != null)
            {
                request.IncludePublic = cmdletContext.IncludePublic.Value;
            }
            if (cmdletContext.IncludeShared != null)
            {
                request.IncludeShared = cmdletContext.IncludeShared.Value;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecord.Value);
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.RDS.Model.DescribeDBSnapshotsRequest();
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
            if (cmdletContext.IncludePublic != null)
            {
                request.IncludePublic = cmdletContext.IncludePublic.Value;
            }
            if (cmdletContext.IncludeShared != null)
            {
                request.IncludeShared = cmdletContext.IncludeShared.Value;
            }
            if (cmdletContext.SnapshotType != null)
            {
                request.SnapshotType = cmdletContext.SnapshotType;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextToken = cmdletContext.Marker;
            }
            if (cmdletContext.MaxRecord.HasValue)
            {
                _emitLimit = cmdletContext.MaxRecord;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                }
                
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
                    int _receivedThisCall = response.DBSnapshots.Count;
                    
                    _nextToken = response.Marker;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.RDS.Model.DescribeDBSnapshotsResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeDBSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeDBSnapshots");
            try
            {
                #if DESKTOP
                return client.DescribeDBSnapshots(request);
                #elif CORECLR
                return client.DescribeDBSnapshotsAsync(request).GetAwaiter().GetResult();
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
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DbiResourceId { get; set; }
            public System.String DBSnapshotIdentifier { get; set; }
            public List<Amazon.RDS.Model.Filter> Filter { get; set; }
            public System.Boolean? IncludePublic { get; set; }
            public System.Boolean? IncludeShared { get; set; }
            public System.String Marker { get; set; }
            public int? MaxRecord { get; set; }
            public System.String SnapshotType { get; set; }
            public System.Func<Amazon.RDS.Model.DescribeDBSnapshotsResponse, GetRDSDBSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBSnapshots;
        }
        
    }
}
