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
using Amazon.SageMakerGeospatial;
using Amazon.SageMakerGeospatial.Model;

namespace Amazon.PowerShell.Cmdlets.SMGS
{
    /// <summary>
    /// Use this operation to get a list of the Earth Observation jobs associated with the
    /// calling Amazon Web Services account.
    /// </summary>
    [Cmdlet("Get", "SMGSEarthObservationJobList")]
    [OutputType("Amazon.SageMakerGeospatial.Model.ListEarthObservationJobOutputConfig")]
    [AWSCmdlet("Calls the SageMaker Geospatial ListEarthObservationJobs API operation.", Operation = new[] {"ListEarthObservationJobs"}, SelectReturnType = typeof(Amazon.SageMakerGeospatial.Model.ListEarthObservationJobsResponse))]
    [AWSCmdletOutput("Amazon.SageMakerGeospatial.Model.ListEarthObservationJobOutputConfig or Amazon.SageMakerGeospatial.Model.ListEarthObservationJobsResponse",
        "This cmdlet returns a collection of Amazon.SageMakerGeospatial.Model.ListEarthObservationJobOutputConfig objects.",
        "The service call response (type Amazon.SageMakerGeospatial.Model.ListEarthObservationJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSMGSEarthObservationJobListCmdlet : AmazonSageMakerGeospatialClientCmdlet, IExecutor
    {
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The parameter by which to sort the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>An optional value that specifies whether you want the results sorted in <code>Ascending</code>
        /// or <code>Descending</code> order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.SortOrder")]
        public Amazon.SageMakerGeospatial.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter StatusEqual
        /// <summary>
        /// <para>
        /// <para>A filter that retrieves only jobs with a specific status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusEquals")]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.EarthObservationJobStatus")]
        public Amazon.SageMakerGeospatial.EarthObservationJobStatus StatusEqual { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The total number of items to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was truncated, you receive this token. Use it in your next
        /// request to receive the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EarthObservationJobSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerGeospatial.Model.ListEarthObservationJobsResponse).
        /// Specifying the name of a property of type Amazon.SageMakerGeospatial.Model.ListEarthObservationJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EarthObservationJobSummaries";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerGeospatial.Model.ListEarthObservationJobsResponse, GetSMGSEarthObservationJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.StatusEqual = this.StatusEqual;
            
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
            var request = new Amazon.SageMakerGeospatial.Model.ListEarthObservationJobsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.StatusEqual != null)
            {
                request.StatusEquals = cmdletContext.StatusEqual;
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
        
        private Amazon.SageMakerGeospatial.Model.ListEarthObservationJobsResponse CallAWSServiceOperation(IAmazonSageMakerGeospatial client, Amazon.SageMakerGeospatial.Model.ListEarthObservationJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "SageMaker Geospatial", "ListEarthObservationJobs");
            try
            {
                #if DESKTOP
                return client.ListEarthObservationJobs(request);
                #elif CORECLR
                return client.ListEarthObservationJobsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SortBy { get; set; }
            public Amazon.SageMakerGeospatial.SortOrder SortOrder { get; set; }
            public Amazon.SageMakerGeospatial.EarthObservationJobStatus StatusEqual { get; set; }
            public System.Func<Amazon.SageMakerGeospatial.Model.ListEarthObservationJobsResponse, GetSMGSEarthObservationJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EarthObservationJobSummaries;
        }
        
    }
}
