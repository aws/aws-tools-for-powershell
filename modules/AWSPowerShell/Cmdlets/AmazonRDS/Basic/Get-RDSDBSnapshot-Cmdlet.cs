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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Returns information about DB snapshots. This API action supports pagination.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "RDSDBSnapshot")]
    [OutputType("Amazon.RDS.Model.DBSnapshot")]
    [AWSCmdlet("Invokes the DescribeDBSnapshots operation against Amazon Relational Database Service.", Operation = new[] {"DescribeDBSnapshots"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSnapshot",
        "This cmdlet returns a collection of DBSnapshot objects.",
        "The service call response (type Amazon.RDS.Model.DescribeDBSnapshotsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String)"
    )]
    public partial class GetRDSDBSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the DB instance to retrieve the list of DB snapshots for. This parameter
        /// cannot be used in conjunction with <code>DBSnapshotIdentifier</code>. This parameter
        /// is not case-sensitive. </para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para> A specific DB snapshot identifier to describe. This parameter cannot be used in conjunction
        /// with <code>DBInstanceIdentifier</code>. This value is stored as a lowercase string.
        /// </para><para>Constraints:</para><ul><li><para>Must be 1 to 255 alphanumeric characters.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li><li><para>If this identifier is for an automated snapshot, the <code>SnapshotType</code> parameter
        /// must also be specified.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String DBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>This parameter is not currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter IncludePublic
        /// <summary>
        /// <para>
        /// <para>Set this value to <code>true</code> to include manual DB snapshots that are public
        /// and can be copied or restored by any AWS account, otherwise set this value to <code>false</code>.
        /// The default is <code>false</code>.</para><para>You can share a manual DB snapshot as public by using the <a>ModifyDBSnapshotAttribute</a>
        /// API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean IncludePublic { get; set; }
        #endregion
        
        #region Parameter IncludeShared
        /// <summary>
        /// <para>
        /// <para>Set this value to <code>true</code> to include shared manual DB snapshots from other
        /// AWS accounts that this AWS account has been given permission to copy or restore, otherwise
        /// set this value to <code>false</code>. The default is <code>false</code>.</para><para>You can give an AWS account permission to restore a manual DB snapshot from another
        /// AWS account by using the <a>ModifyDBSnapshotAttribute</a> API action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean IncludeShared { get; set; }
        #endregion
        
        #region Parameter SnapshotType
        /// <summary>
        /// <para>
        /// <para>The type of snapshots to be returned. You can specify one of the following values:</para><ul><li><para><code>automated</code> - Return all DB snapshots that have been automatically taken
        /// by Amazon RDS for my AWS account.</para></li><li><para><code>manual</code> - Return all DB snapshots that have been taken by my AWS account.</para></li><li><para><code>shared</code> - Return all manual DB snapshots that have been shared to my
        /// AWS account.</para></li><li><para><code>public</code> - Return all DB snapshots that have been marked as public.</para></li></ul><para>If you don't specify a <code>SnapshotType</code> value, then both automated and manual
        /// snapshots are returned. Shared and public DB snapshots are not included in the returned
        /// results by default. You can include shared snapshots with these results by setting
        /// the <code>IncludeShared</code> parameter to <code>true</code>. You can include public
        /// snapshots with these results by setting the <code>IncludePublic</code> parameter to
        /// <code>true</code>.</para><para>The <code>IncludeShared</code> and <code>IncludePublic</code> parameters don't apply
        /// for <code>SnapshotType</code> values of <code>manual</code> or <code>automated</code>.
        /// The <code>IncludePublic</code> parameter doesn't apply when <code>SnapshotType</code>
        /// is set to <code>shared</code>. The <code>IncludeShared</code> parameter doesn't apply
        /// when <code>SnapshotType</code> is set to <code>public</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String SnapshotType { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para> An optional pagination token provided by a previous <code>DescribeDBSnapshots</code>
        /// request. If this parameter is specified, the response includes only records beyond
        /// the marker, up to the value specified by <code>MaxRecords</code>. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para> The maximum number of records to include in the response. If more records exist than
        /// the specified <code>MaxRecords</code> value, a pagination token called a marker is
        /// included in the response so that the remaining results can be retrieved. </para><para>Default: 100</para><para>Constraints: Minimum 20, maximum 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            context.DBSnapshotIdentifier = this.DBSnapshotIdentifier;
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.RDS.Model.Filter>(this.Filter);
            }
            if (ParameterWasBound("IncludePublic"))
                context.IncludePublic = this.IncludePublic;
            if (ParameterWasBound("IncludeShared"))
                context.IncludeShared = this.IncludeShared;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
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
            
            // create request and set iteration invariants
            var request = new Amazon.RDS.Model.DescribeDBSnapshotsRequest();
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.DBSnapshotIdentifier != null)
            {
                request.DBSnapshotIdentifier = cmdletContext.DBSnapshotIdentifier;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxRecords))
            {
                _emitLimit = cmdletContext.MaxRecords;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.Marker) || AutoIterationHelpers.HasValue(cmdletContext.MaxRecords);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.DBSnapshots;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.DBSnapshots.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeDBSnapshotsAsync(request);
                return task.Result;
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
            public System.String DBSnapshotIdentifier { get; set; }
            public List<Amazon.RDS.Model.Filter> Filters { get; set; }
            public System.Boolean? IncludePublic { get; set; }
            public System.Boolean? IncludeShared { get; set; }
            public System.String Marker { get; set; }
            public int? MaxRecords { get; set; }
            public System.String SnapshotType { get; set; }
        }
        
    }
}
