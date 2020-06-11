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
    /// Provides a list of individual assessments that you can specify for a new premigration
    /// assessment run, given one or more parameters.
    /// 
    ///  
    /// <para>
    /// If you specify an existing migration task, this operation provides the default individual
    /// assessments you can specify for that task. Otherwise, the specified parameters model
    /// elements of a possible migration task on which to base a premigration assessment run.
    /// </para><para>
    /// To use these migration task modeling parameters, you must specify an existing replication
    /// instance, a source database engine, a target database engine, and a migration type.
    /// This combination of parameters potentially limits the default individual assessments
    /// available for an assessment run created for a corresponding migration task.
    /// </para><para>
    /// If you specify no parameters, this operation provides a list of all possible individual
    /// assessments that you can specify for an assessment run. If you specify any one of
    /// the task modeling parameters, you must specify all of them or the operation cannot
    /// provide a list of individual assessments. The only parameter that you can specify
    /// alone is for an existing migration task. The specified task definition then determines
    /// the default list of individual assessments that you can specify in an assessment run
    /// for the task.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DMSApplicableIndividualAssessment")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Database Migration Service DescribeApplicableIndividualAssessments API operation.", Operation = new[] {"DescribeApplicableIndividualAssessments"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.DescribeApplicableIndividualAssessmentsResponse))]
    [AWSCmdletOutput("System.String or Amazon.DatabaseMigrationService.Model.DescribeApplicableIndividualAssessmentsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.DescribeApplicableIndividualAssessmentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDMSApplicableIndividualAssessmentCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter MigrationType
        /// <summary>
        /// <para>
        /// <para>Name of the migration type that each provided individual assessment must support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.MigrationTypeValue")]
        public Amazon.DatabaseMigrationService.MigrationTypeValue MigrationType { get; set; }
        #endregion
        
        #region Parameter ReplicationInstanceArn
        /// <summary>
        /// <para>
        /// <para>ARN of a replication instance on which you want to base the default list of individual
        /// assessments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationInstanceArn { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of a migration task on which you want to base the default
        /// list of individual assessments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationTaskArn { get; set; }
        #endregion
        
        #region Parameter SourceEngineName
        /// <summary>
        /// <para>
        /// <para>Name of a database engine that the specified replication instance supports as a source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceEngineName { get; set; }
        #endregion
        
        #region Parameter TargetEngineName
        /// <summary>
        /// <para>
        /// <para>Name of a database engine that the specified replication instance supports as a target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetEngineName { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Optional pagination token provided by a previous request. If this parameter is specified,
        /// the response includes only records beyond the marker, up to the value specified by
        /// <code>MaxRecords</code>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-Marker $null' for the first call and '-Marker $AWSHistory.LastServiceResponse.Marker' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>Maximum number of records to include in the response. If more records exist than the
        /// specified <code>MaxRecords</code> value, a pagination token called a marker is included
        /// in the response so that the remaining results can be retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IndividualAssessmentNames'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.DescribeApplicableIndividualAssessmentsResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.DescribeApplicableIndividualAssessmentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IndividualAssessmentNames";
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.DescribeApplicableIndividualAssessmentsResponse, GetDMSApplicableIndividualAssessmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            context.MigrationType = this.MigrationType;
            context.ReplicationInstanceArn = this.ReplicationInstanceArn;
            context.ReplicationTaskArn = this.ReplicationTaskArn;
            context.SourceEngineName = this.SourceEngineName;
            context.TargetEngineName = this.TargetEngineName;
            
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
            var request = new Amazon.DatabaseMigrationService.Model.DescribeApplicableIndividualAssessmentsRequest();
            
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            if (cmdletContext.MigrationType != null)
            {
                request.MigrationType = cmdletContext.MigrationType;
            }
            if (cmdletContext.ReplicationInstanceArn != null)
            {
                request.ReplicationInstanceArn = cmdletContext.ReplicationInstanceArn;
            }
            if (cmdletContext.ReplicationTaskArn != null)
            {
                request.ReplicationTaskArn = cmdletContext.ReplicationTaskArn;
            }
            if (cmdletContext.SourceEngineName != null)
            {
                request.SourceEngineName = cmdletContext.SourceEngineName;
            }
            if (cmdletContext.TargetEngineName != null)
            {
                request.TargetEngineName = cmdletContext.TargetEngineName;
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
        
        private Amazon.DatabaseMigrationService.Model.DescribeApplicableIndividualAssessmentsResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.DescribeApplicableIndividualAssessmentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "DescribeApplicableIndividualAssessments");
            try
            {
                #if DESKTOP
                return client.DescribeApplicableIndividualAssessments(request);
                #elif CORECLR
                return client.DescribeApplicableIndividualAssessmentsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DatabaseMigrationService.MigrationTypeValue MigrationType { get; set; }
            public System.String ReplicationInstanceArn { get; set; }
            public System.String ReplicationTaskArn { get; set; }
            public System.String SourceEngineName { get; set; }
            public System.String TargetEngineName { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.DescribeApplicableIndividualAssessmentsResponse, GetDMSApplicableIndividualAssessmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IndividualAssessmentNames;
        }
        
    }
}
