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
using Amazon.CostOptimizationHub;
using Amazon.CostOptimizationHub.Model;

namespace Amazon.PowerShell.Cmdlets.COH
{
    /// <summary>
    /// Retrieves the enrollment status for an account. It can also return the list of accounts
    /// that are enrolled under the organization.
    /// </summary>
    [Cmdlet("Get", "COHEnrollmentStatusList")]
    [OutputType("Amazon.CostOptimizationHub.Model.AccountEnrollmentStatus")]
    [AWSCmdlet("Calls the Cost Optimization Hub ListEnrollmentStatuses API operation.", Operation = new[] {"ListEnrollmentStatuses"}, SelectReturnType = typeof(Amazon.CostOptimizationHub.Model.ListEnrollmentStatusesResponse))]
    [AWSCmdletOutput("Amazon.CostOptimizationHub.Model.AccountEnrollmentStatus or Amazon.CostOptimizationHub.Model.ListEnrollmentStatusesResponse",
        "This cmdlet returns a collection of Amazon.CostOptimizationHub.Model.AccountEnrollmentStatus objects.",
        "The service call response (type Amazon.CostOptimizationHub.Model.ListEnrollmentStatusesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCOHEnrollmentStatusListCmdlet : AmazonCostOptimizationHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The account ID of a member account in the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter IncludeOrganizationInfo
        /// <summary>
        /// <para>
        /// <para>Indicates whether to return the enrollment status for the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeOrganizationInfo { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of objects that are returned for the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostOptimizationHub.Model.ListEnrollmentStatusesResponse).
        /// Specifying the name of a property of type Amazon.CostOptimizationHub.Model.ListEnrollmentStatusesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.CostOptimizationHub.Model.ListEnrollmentStatusesResponse, GetCOHEnrollmentStatusListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            context.IncludeOrganizationInfo = this.IncludeOrganizationInfo;
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
            var request = new Amazon.CostOptimizationHub.Model.ListEnrollmentStatusesRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.IncludeOrganizationInfo != null)
            {
                request.IncludeOrganizationInfo = cmdletContext.IncludeOrganizationInfo.Value;
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
        
        private Amazon.CostOptimizationHub.Model.ListEnrollmentStatusesResponse CallAWSServiceOperation(IAmazonCostOptimizationHub client, Amazon.CostOptimizationHub.Model.ListEnrollmentStatusesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Cost Optimization Hub", "ListEnrollmentStatuses");
            try
            {
                return client.ListEnrollmentStatusesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.Boolean? IncludeOrganizationInfo { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CostOptimizationHub.Model.ListEnrollmentStatusesResponse, GetCOHEnrollmentStatusListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
