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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Retrieves a subset of information about one or more classification jobs.
    /// </summary>
    [Cmdlet("Get", "MAC2ClassificationJobList")]
    [OutputType("Amazon.Macie2.Model.JobSummary")]
    [AWSCmdlet("Calls the Amazon Macie 2 ListClassificationJobs API operation.", Operation = new[] {"ListClassificationJobs"}, SelectReturnType = typeof(Amazon.Macie2.Model.ListClassificationJobsResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.JobSummary or Amazon.Macie2.Model.ListClassificationJobsResponse",
        "This cmdlet returns a collection of Amazon.Macie2.Model.JobSummary objects.",
        "The service call response (type Amazon.Macie2.Model.ListClassificationJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMAC2ClassificationJobListCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        #region Parameter SortCriteria_AttributeName
        /// <summary>
        /// <para>
        /// <para>The property to sort the results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.ListJobsSortAttributeName")]
        public Amazon.Macie2.ListJobsSortAttributeName SortCriteria_AttributeName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Exclude
        /// <summary>
        /// <para>
        /// <para>An array of objects, one for each condition that determines which jobs to exclude
        /// from the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_Excludes")]
        public Amazon.Macie2.Model.ListJobsFilterTerm[] FilterCriteria_Exclude { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Include
        /// <summary>
        /// <para>
        /// <para>An array of objects, one for each condition that determines which jobs to include
        /// in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_Includes")]
        public Amazon.Macie2.Model.ListJobsFilterTerm[] FilterCriteria_Include { get; set; }
        #endregion
        
        #region Parameter SortCriteria_OrderBy
        /// <summary>
        /// <para>
        /// <para>The sort order to apply to the results, based on the value for the property specified
        /// by the attributeName property. Valid values are: ASC, sort the results in ascending
        /// order; and, DESC, sort the results in descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.OrderBy")]
        public Amazon.Macie2.OrderBy SortCriteria_OrderBy { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to include in each page of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The nextToken string that specifies which page of results to return in a paginated
        /// response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.ListClassificationJobsResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.ListClassificationJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.ListClassificationJobsResponse, GetMAC2ClassificationJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterCriteria_Exclude != null)
            {
                context.FilterCriteria_Exclude = new List<Amazon.Macie2.Model.ListJobsFilterTerm>(this.FilterCriteria_Exclude);
            }
            if (this.FilterCriteria_Include != null)
            {
                context.FilterCriteria_Include = new List<Amazon.Macie2.Model.ListJobsFilterTerm>(this.FilterCriteria_Include);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortCriteria_AttributeName = this.SortCriteria_AttributeName;
            context.SortCriteria_OrderBy = this.SortCriteria_OrderBy;
            
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
            var request = new Amazon.Macie2.Model.ListClassificationJobsRequest();
            
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Macie2.Model.ListJobsFilterCriteria();
            List<Amazon.Macie2.Model.ListJobsFilterTerm> requestFilterCriteria_filterCriteria_Exclude = null;
            if (cmdletContext.FilterCriteria_Exclude != null)
            {
                requestFilterCriteria_filterCriteria_Exclude = cmdletContext.FilterCriteria_Exclude;
            }
            if (requestFilterCriteria_filterCriteria_Exclude != null)
            {
                request.FilterCriteria.Excludes = requestFilterCriteria_filterCriteria_Exclude;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Macie2.Model.ListJobsFilterTerm> requestFilterCriteria_filterCriteria_Include = null;
            if (cmdletContext.FilterCriteria_Include != null)
            {
                requestFilterCriteria_filterCriteria_Include = cmdletContext.FilterCriteria_Include;
            }
            if (requestFilterCriteria_filterCriteria_Include != null)
            {
                request.FilterCriteria.Includes = requestFilterCriteria_filterCriteria_Include;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate SortCriteria
            var requestSortCriteriaIsNull = true;
            request.SortCriteria = new Amazon.Macie2.Model.ListJobsSortCriteria();
            Amazon.Macie2.ListJobsSortAttributeName requestSortCriteria_sortCriteria_AttributeName = null;
            if (cmdletContext.SortCriteria_AttributeName != null)
            {
                requestSortCriteria_sortCriteria_AttributeName = cmdletContext.SortCriteria_AttributeName;
            }
            if (requestSortCriteria_sortCriteria_AttributeName != null)
            {
                request.SortCriteria.AttributeName = requestSortCriteria_sortCriteria_AttributeName;
                requestSortCriteriaIsNull = false;
            }
            Amazon.Macie2.OrderBy requestSortCriteria_sortCriteria_OrderBy = null;
            if (cmdletContext.SortCriteria_OrderBy != null)
            {
                requestSortCriteria_sortCriteria_OrderBy = cmdletContext.SortCriteria_OrderBy;
            }
            if (requestSortCriteria_sortCriteria_OrderBy != null)
            {
                request.SortCriteria.OrderBy = requestSortCriteria_sortCriteria_OrderBy;
                requestSortCriteriaIsNull = false;
            }
             // determine if request.SortCriteria should be set to null
            if (requestSortCriteriaIsNull)
            {
                request.SortCriteria = null;
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
        
        private Amazon.Macie2.Model.ListClassificationJobsResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.ListClassificationJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "ListClassificationJobs");
            try
            {
                #if DESKTOP
                return client.ListClassificationJobs(request);
                #elif CORECLR
                return client.ListClassificationJobsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Macie2.Model.ListJobsFilterTerm> FilterCriteria_Exclude { get; set; }
            public List<Amazon.Macie2.Model.ListJobsFilterTerm> FilterCriteria_Include { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Macie2.ListJobsSortAttributeName SortCriteria_AttributeName { get; set; }
            public Amazon.Macie2.OrderBy SortCriteria_OrderBy { get; set; }
            public System.Func<Amazon.Macie2.Model.ListClassificationJobsResponse, GetMAC2ClassificationJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
