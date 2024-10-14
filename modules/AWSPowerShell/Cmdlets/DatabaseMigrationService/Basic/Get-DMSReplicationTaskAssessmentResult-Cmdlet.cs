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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Returns the task assessment results from the Amazon S3 bucket that DMS creates in
    /// your Amazon Web Services account. This action always returns the latest results.
    /// 
    ///  
    /// <para>
    /// For more information about DMS task assessments, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tasks.AssessmentReport.html">Creating
    /// a task assessment report</a> in the <i>Database Migration Service User Guide</i>.
    /// </para><br/><br/>In the AWS.Tools.DatabaseMigrationService module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DMSReplicationTaskAssessmentResult")]
    [OutputType("Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsResponse")]
    [AWSCmdlet("Calls the AWS Database Migration Service DescribeReplicationTaskAssessmentResults API operation.", Operation = new[] {"DescribeReplicationTaskAssessmentResults"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsResponse object containing multiple properties."
    )]
    public partial class GetDMSReplicationTaskAssessmentResultCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReplicationTaskArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) string that uniquely identifies the task. When this
        /// input parameter is specified, the API returns only one result and ignore the values
        /// of the <c>MaxRecords</c> and <c>Marker</c> parameters. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationTaskArn { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para> An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the marker, up to the value specified
        /// by <c>MaxRecords</c>. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.DatabaseMigrationService module, this parameter is only used if you are manually controlling output pagination of the service API call.
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
        /// <para> The maximum number of records to include in the response. If more records exist than
        /// the specified <c>MaxRecords</c> value, a pagination token called a marker is included
        /// in the response so that the remaining results can be retrieved. </para><para>Default: 100</para><para>Constraints: Minimum 20, maximum 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReplicationTaskArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReplicationTaskArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReplicationTaskArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
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
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsResponse, GetDMSReplicationTaskAssessmentResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReplicationTaskArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            context.ReplicationTaskArn = this.ReplicationTaskArn;
            
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
            var request = new Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsRequest();
            
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            if (cmdletContext.ReplicationTaskArn != null)
            {
                request.ReplicationTaskArn = cmdletContext.ReplicationTaskArn;
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
            // create request
            var request = new Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            if (cmdletContext.ReplicationTaskArn != null)
            {
                request.ReplicationTaskArn = cmdletContext.ReplicationTaskArn;
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "DescribeReplicationTaskAssessmentResults");
            try
            {
                #if DESKTOP
                return client.DescribeReplicationTaskAssessmentResults(request);
                #elif CORECLR
                return client.DescribeReplicationTaskAssessmentResultsAsync(request).GetAwaiter().GetResult();
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
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.String ReplicationTaskArn { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.DescribeReplicationTaskAssessmentResultsResponse, GetDMSReplicationTaskAssessmentResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
