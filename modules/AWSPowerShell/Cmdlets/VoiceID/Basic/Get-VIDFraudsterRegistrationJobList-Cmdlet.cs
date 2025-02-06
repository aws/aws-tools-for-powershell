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
using Amazon.VoiceID;
using Amazon.VoiceID.Model;

namespace Amazon.PowerShell.Cmdlets.VID
{
    /// <summary>
    /// Lists all the fraudster registration jobs in the domain with the given <c>JobStatus</c>.
    /// If <c>JobStatus</c> is not provided, this lists all fraudster registration jobs in
    /// the given domain.
    /// </summary>
    [Cmdlet("Get", "VIDFraudsterRegistrationJobList")]
    [OutputType("Amazon.VoiceID.Model.FraudsterRegistrationJobSummary")]
    [AWSCmdlet("Calls the Amazon Voice ID ListFraudsterRegistrationJobs API operation.", Operation = new[] {"ListFraudsterRegistrationJobs"}, SelectReturnType = typeof(Amazon.VoiceID.Model.ListFraudsterRegistrationJobsResponse))]
    [AWSCmdletOutput("Amazon.VoiceID.Model.FraudsterRegistrationJobSummary or Amazon.VoiceID.Model.ListFraudsterRegistrationJobsResponse",
        "This cmdlet returns a collection of Amazon.VoiceID.Model.FraudsterRegistrationJobSummary objects.",
        "The service call response (type Amazon.VoiceID.Model.ListFraudsterRegistrationJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetVIDFraudsterRegistrationJobListCmdlet : AmazonVoiceIDClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The identifier of the domain that contains the fraudster registration Jobs.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter JobStatus
        /// <summary>
        /// <para>
        /// <para>Provides the status of your fraudster registration job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VoiceID.FraudsterRegistrationJobStatus")]
        public Amazon.VoiceID.FraudsterRegistrationJobStatus JobStatus { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that are returned per call. You can use <c>NextToken</c>
        /// to obtain more pages of results. The default is 100; the maximum allowed page size
        /// is also 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If <c>NextToken</c> is returned, there are more results available. The value of <c>NextToken</c>
        /// is a unique pagination token for each page. Make the call again using the returned
        /// token to retrieve the next page. Keep all other arguments unchanged. Each pagination
        /// token expires after 24 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VoiceID.Model.ListFraudsterRegistrationJobsResponse).
        /// Specifying the name of a property of type Amazon.VoiceID.Model.ListFraudsterRegistrationJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobSummaries";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VoiceID.Model.ListFraudsterRegistrationJobsResponse, GetVIDFraudsterRegistrationJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobStatus = this.JobStatus;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.VoiceID.Model.ListFraudsterRegistrationJobsRequest();
            
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            if (cmdletContext.JobStatus != null)
            {
                request.JobStatus = cmdletContext.JobStatus;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.VoiceID.Model.ListFraudsterRegistrationJobsResponse CallAWSServiceOperation(IAmazonVoiceID client, Amazon.VoiceID.Model.ListFraudsterRegistrationJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Voice ID", "ListFraudsterRegistrationJobs");
            try
            {
                #if DESKTOP
                return client.ListFraudsterRegistrationJobs(request);
                #elif CORECLR
                return client.ListFraudsterRegistrationJobsAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public Amazon.VoiceID.FraudsterRegistrationJobStatus JobStatus { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.VoiceID.Model.ListFraudsterRegistrationJobsResponse, GetVIDFraudsterRegistrationJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobSummaries;
        }
        
    }
}
