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
using Amazon.CloudControlApi;
using Amazon.CloudControlApi.Model;

namespace Amazon.PowerShell.Cmdlets.CCA
{
    /// <summary>
    /// Returns existing resource operation requests. This includes requests of all status
    /// types. For more information, see <a href="https://docs.aws.amazon.com/cloudcontrolapi/latest/userguide/resource-operations-manage-requests.html#resource-operations-manage-requests-list">Listing
    /// active resource operation requests</a> in the <i>Amazon Web Services Cloud Control
    /// API User Guide</i>.
    /// 
    ///  <note><para>
    /// Resource operation requests expire after 7 days.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CCAResourceRequestList")]
    [OutputType("Amazon.CloudControlApi.Model.ProgressEvent")]
    [AWSCmdlet("Calls the AWS Cloud Control API ListResourceRequests API operation.", Operation = new[] {"ListResourceRequests"}, SelectReturnType = typeof(Amazon.CloudControlApi.Model.ListResourceRequestsResponse))]
    [AWSCmdletOutput("Amazon.CloudControlApi.Model.ProgressEvent or Amazon.CloudControlApi.Model.ListResourceRequestsResponse",
        "This cmdlet returns a collection of Amazon.CloudControlApi.Model.ProgressEvent objects.",
        "The service call response (type Amazon.CloudControlApi.Model.ListResourceRequestsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCCAResourceRequestListCmdlet : AmazonCloudControlApiClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceRequestStatusFilter_Operation
        /// <summary>
        /// <para>
        /// <para>The operation types to include in the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceRequestStatusFilter_Operations")]
        public System.String[] ResourceRequestStatusFilter_Operation { get; set; }
        #endregion
        
        #region Parameter ResourceRequestStatusFilter_OperationStatus
        /// <summary>
        /// <para>
        /// <para>The operation statuses to include in the filter.</para><ul><li><para><c>PENDING</c>: The operation has been requested, but not yet initiated.</para></li><li><para><c>IN_PROGRESS</c>: The operation is in progress.</para></li><li><para><c>SUCCESS</c>: The operation completed.</para></li><li><para><c>FAILED</c>: The operation failed.</para></li><li><para><c>CANCEL_IN_PROGRESS</c>: The operation is in the process of being canceled.</para></li><li><para><c>CANCEL_COMPLETE</c>: The operation has been canceled.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceRequestStatusFilter_OperationStatuses")]
        public System.String[] ResourceRequestStatusFilter_OperationStatus { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned with a single call. If the number of
        /// available results exceeds this maximum, the response includes a <c>NextToken</c> value
        /// that you can assign to the <c>NextToken</c> request parameter to get the next set
        /// of results.</para><para>The default is <c>20</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous paginated request didn't return all of the remaining results, the
        /// response object's <c>NextToken</c> parameter value is set to a token. To retrieve
        /// the next set of results, call this action again and assign that token to the request
        /// object's <c>NextToken</c> parameter. If there are no remaining results, the previous
        /// response object's <c>NextToken</c> parameter is set to <c>null</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceRequestStatusSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudControlApi.Model.ListResourceRequestsResponse).
        /// Specifying the name of a property of type Amazon.CloudControlApi.Model.ListResourceRequestsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceRequestStatusSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.CloudControlApi.Model.ListResourceRequestsResponse, GetCCAResourceRequestListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.ResourceRequestStatusFilter_Operation != null)
            {
                context.ResourceRequestStatusFilter_Operation = new List<System.String>(this.ResourceRequestStatusFilter_Operation);
            }
            if (this.ResourceRequestStatusFilter_OperationStatus != null)
            {
                context.ResourceRequestStatusFilter_OperationStatus = new List<System.String>(this.ResourceRequestStatusFilter_OperationStatus);
            }
            
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
            var request = new Amazon.CloudControlApi.Model.ListResourceRequestsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate ResourceRequestStatusFilter
            var requestResourceRequestStatusFilterIsNull = true;
            request.ResourceRequestStatusFilter = new Amazon.CloudControlApi.Model.ResourceRequestStatusFilter();
            List<System.String> requestResourceRequestStatusFilter_resourceRequestStatusFilter_Operation = null;
            if (cmdletContext.ResourceRequestStatusFilter_Operation != null)
            {
                requestResourceRequestStatusFilter_resourceRequestStatusFilter_Operation = cmdletContext.ResourceRequestStatusFilter_Operation;
            }
            if (requestResourceRequestStatusFilter_resourceRequestStatusFilter_Operation != null)
            {
                request.ResourceRequestStatusFilter.Operations = requestResourceRequestStatusFilter_resourceRequestStatusFilter_Operation;
                requestResourceRequestStatusFilterIsNull = false;
            }
            List<System.String> requestResourceRequestStatusFilter_resourceRequestStatusFilter_OperationStatus = null;
            if (cmdletContext.ResourceRequestStatusFilter_OperationStatus != null)
            {
                requestResourceRequestStatusFilter_resourceRequestStatusFilter_OperationStatus = cmdletContext.ResourceRequestStatusFilter_OperationStatus;
            }
            if (requestResourceRequestStatusFilter_resourceRequestStatusFilter_OperationStatus != null)
            {
                request.ResourceRequestStatusFilter.OperationStatuses = requestResourceRequestStatusFilter_resourceRequestStatusFilter_OperationStatus;
                requestResourceRequestStatusFilterIsNull = false;
            }
             // determine if request.ResourceRequestStatusFilter should be set to null
            if (requestResourceRequestStatusFilterIsNull)
            {
                request.ResourceRequestStatusFilter = null;
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
        
        private Amazon.CloudControlApi.Model.ListResourceRequestsResponse CallAWSServiceOperation(IAmazonCloudControlApi client, Amazon.CloudControlApi.Model.ListResourceRequestsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Control API", "ListResourceRequests");
            try
            {
                #if DESKTOP
                return client.ListResourceRequests(request);
                #elif CORECLR
                return client.ListResourceRequestsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ResourceRequestStatusFilter_Operation { get; set; }
            public List<System.String> ResourceRequestStatusFilter_OperationStatus { get; set; }
            public System.Func<Amazon.CloudControlApi.Model.ListResourceRequestsResponse, GetCCAResourceRequestListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceRequestStatusSummaries;
        }
        
    }
}
