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
using Amazon.TrustedAdvisor;
using Amazon.TrustedAdvisor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TA
{
    /// <summary>
    /// List Resources of a Recommendation
    /// </summary>
    [Cmdlet("Get", "TARecommendationResourceList")]
    [OutputType("Amazon.TrustedAdvisor.Model.RecommendationResourceSummary")]
    [AWSCmdlet("Calls the Trusted Advisor ListRecommendationResources API operation.", Operation = new[] {"ListRecommendationResources"}, SelectReturnType = typeof(Amazon.TrustedAdvisor.Model.ListRecommendationResourcesResponse))]
    [AWSCmdletOutput("Amazon.TrustedAdvisor.Model.RecommendationResourceSummary or Amazon.TrustedAdvisor.Model.ListRecommendationResourcesResponse",
        "This cmdlet returns a collection of Amazon.TrustedAdvisor.Model.RecommendationResourceSummary objects.",
        "The service call response (type Amazon.TrustedAdvisor.Model.ListRecommendationResourcesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetTARecommendationResourceListCmdlet : AmazonTrustedAdvisorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExclusionStatus
        /// <summary>
        /// <para>
        /// <para>The exclusion status of the resource</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.ExclusionStatus")]
        public Amazon.TrustedAdvisor.ExclusionStatus ExclusionStatus { get; set; }
        #endregion
        
        #region Parameter RecommendationIdentifier
        /// <summary>
        /// <para>
        /// <para>The Recommendation identifier</para>
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
        public System.String RecommendationIdentifier { get; set; }
        #endregion
        
        #region Parameter RegionCode
        /// <summary>
        /// <para>
        /// <para>The AWS Region code of the resource</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegionCode { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the resource</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.ResourceStatus")]
        public Amazon.TrustedAdvisor.ResourceStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommendationResourceSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TrustedAdvisor.Model.ListRecommendationResourcesResponse).
        /// Specifying the name of a property of type Amazon.TrustedAdvisor.Model.ListRecommendationResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommendationResourceSummaries";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TrustedAdvisor.Model.ListRecommendationResourcesResponse, GetTARecommendationResourceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExclusionStatus = this.ExclusionStatus;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RecommendationIdentifier = this.RecommendationIdentifier;
            #if MODULAR
            if (this.RecommendationIdentifier == null && ParameterWasBound(nameof(this.RecommendationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommendationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegionCode = this.RegionCode;
            context.Status = this.Status;
            
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
            var request = new Amazon.TrustedAdvisor.Model.ListRecommendationResourcesRequest();
            
            if (cmdletContext.ExclusionStatus != null)
            {
                request.ExclusionStatus = cmdletContext.ExclusionStatus;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.RecommendationIdentifier != null)
            {
                request.RecommendationIdentifier = cmdletContext.RecommendationIdentifier;
            }
            if (cmdletContext.RegionCode != null)
            {
                request.RegionCode = cmdletContext.RegionCode;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.TrustedAdvisor.Model.ListRecommendationResourcesResponse CallAWSServiceOperation(IAmazonTrustedAdvisor client, Amazon.TrustedAdvisor.Model.ListRecommendationResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Trusted Advisor", "ListRecommendationResources");
            try
            {
                return client.ListRecommendationResourcesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.TrustedAdvisor.ExclusionStatus ExclusionStatus { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String RecommendationIdentifier { get; set; }
            public System.String RegionCode { get; set; }
            public Amazon.TrustedAdvisor.ResourceStatus Status { get; set; }
            public System.Func<Amazon.TrustedAdvisor.Model.ListRecommendationResourcesResponse, GetTARecommendationResourceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommendationResourceSummaries;
        }
        
    }
}
