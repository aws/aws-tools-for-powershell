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
using Amazon.HealthLake;
using Amazon.HealthLake.Model;

namespace Amazon.PowerShell.Cmdlets.AHL
{
    /// <summary>
    /// Lists all FHIR import jobs associated with an account and their statuses.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "AHLFHIRImportJobList")]
    [OutputType("Amazon.HealthLake.Model.ImportJobProperties")]
    [AWSCmdlet("Calls the Amazon HealthLake ListFHIRImportJobs API operation.", Operation = new[] {"ListFHIRImportJobs"}, SelectReturnType = typeof(Amazon.HealthLake.Model.ListFHIRImportJobsResponse))]
    [AWSCmdletOutput("Amazon.HealthLake.Model.ImportJobProperties or Amazon.HealthLake.Model.ListFHIRImportJobsResponse",
        "This cmdlet returns a collection of Amazon.HealthLake.Model.ImportJobProperties objects.",
        "The service call response (type Amazon.HealthLake.Model.ListFHIRImportJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAHLFHIRImportJobListCmdlet : AmazonHealthLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatastoreId
        /// <summary>
        /// <para>
        /// <para> This parameter limits the response to the import job with the specified data store
        /// ID. </para>
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
        public System.String DatastoreId { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para> This parameter limits the response to the import job with the specified job name.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter JobStatus
        /// <summary>
        /// <para>
        /// <para> This parameter limits the response to the import job with the specified job status.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.HealthLake.JobStatus")]
        public Amazon.HealthLake.JobStatus JobStatus { get; set; }
        #endregion
        
        #region Parameter SubmittedAfter
        /// <summary>
        /// <para>
        /// <para> This parameter limits the response to FHIR import jobs submitted after a user specified
        /// date. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SubmittedAfter { get; set; }
        #endregion
        
        #region Parameter SubmittedBefore
        /// <summary>
        /// <para>
        /// <para> This parameter limits the response to FHIR import jobs submitted before a user specified
        /// date. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SubmittedBefore { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> This parameter limits the number of results returned for a ListFHIRImportJobs to
        /// a maximum quantity specified by the user. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> A pagination token used to identify the next page of results to return for a ListFHIRImportJobs
        /// query. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImportJobPropertiesList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.HealthLake.Model.ListFHIRImportJobsResponse).
        /// Specifying the name of a property of type Amazon.HealthLake.Model.ListFHIRImportJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImportJobPropertiesList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatastoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatastoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatastoreId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
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
                context.Select = CreateSelectDelegate<Amazon.HealthLake.Model.ListFHIRImportJobsResponse, GetAHLFHIRImportJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatastoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DatastoreId = this.DatastoreId;
            #if MODULAR
            if (this.DatastoreId == null && ParameterWasBound(nameof(this.DatastoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatastoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobName = this.JobName;
            context.JobStatus = this.JobStatus;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SubmittedAfter = this.SubmittedAfter;
            context.SubmittedBefore = this.SubmittedBefore;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.HealthLake.Model.ListFHIRImportJobsRequest();
            
            if (cmdletContext.DatastoreId != null)
            {
                request.DatastoreId = cmdletContext.DatastoreId;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.JobStatus != null)
            {
                request.JobStatus = cmdletContext.JobStatus;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SubmittedAfter != null)
            {
                request.SubmittedAfter = cmdletContext.SubmittedAfter.Value;
            }
            if (cmdletContext.SubmittedBefore != null)
            {
                request.SubmittedBefore = cmdletContext.SubmittedBefore.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
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
        
        private Amazon.HealthLake.Model.ListFHIRImportJobsResponse CallAWSServiceOperation(IAmazonHealthLake client, Amazon.HealthLake.Model.ListFHIRImportJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon HealthLake", "ListFHIRImportJobs");
            try
            {
                #if DESKTOP
                return client.ListFHIRImportJobs(request);
                #elif CORECLR
                return client.ListFHIRImportJobsAsync(request).GetAwaiter().GetResult();
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
            public System.String DatastoreId { get; set; }
            public System.String JobName { get; set; }
            public Amazon.HealthLake.JobStatus JobStatus { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? SubmittedAfter { get; set; }
            public System.DateTime? SubmittedBefore { get; set; }
            public System.Func<Amazon.HealthLake.Model.ListFHIRImportJobsResponse, GetAHLFHIRImportJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImportJobPropertiesList;
        }
        
    }
}
