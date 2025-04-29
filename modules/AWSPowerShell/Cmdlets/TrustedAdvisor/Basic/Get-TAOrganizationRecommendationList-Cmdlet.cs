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
    /// List a filterable set of Recommendations within an Organization. This API only supports
    /// prioritized recommendations.
    /// </summary>
    [Cmdlet("Get", "TAOrganizationRecommendationList")]
    [OutputType("Amazon.TrustedAdvisor.Model.OrganizationRecommendationSummary")]
    [AWSCmdlet("Calls the Trusted Advisor ListOrganizationRecommendations API operation.", Operation = new[] {"ListOrganizationRecommendations"}, SelectReturnType = typeof(Amazon.TrustedAdvisor.Model.ListOrganizationRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.TrustedAdvisor.Model.OrganizationRecommendationSummary or Amazon.TrustedAdvisor.Model.ListOrganizationRecommendationsResponse",
        "This cmdlet returns a collection of Amazon.TrustedAdvisor.Model.OrganizationRecommendationSummary objects.",
        "The service call response (type Amazon.TrustedAdvisor.Model.ListOrganizationRecommendationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetTAOrganizationRecommendationListCmdlet : AmazonTrustedAdvisorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AfterLastUpdatedAt
        /// <summary>
        /// <para>
        /// <para>After the last update of the Recommendation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? AfterLastUpdatedAt { get; set; }
        #endregion
        
        #region Parameter AwsService
        /// <summary>
        /// <para>
        /// <para>The aws service associated with the Recommendation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsService { get; set; }
        #endregion
        
        #region Parameter BeforeLastUpdatedAt
        /// <summary>
        /// <para>
        /// <para>Before the last update of the Recommendation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? BeforeLastUpdatedAt { get; set; }
        #endregion
        
        #region Parameter CheckIdentifier
        /// <summary>
        /// <para>
        /// <para>The check identifier of the Recommendation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CheckIdentifier { get; set; }
        #endregion
        
        #region Parameter Pillar
        /// <summary>
        /// <para>
        /// <para>The pillar of the Recommendation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.RecommendationPillar")]
        public Amazon.TrustedAdvisor.RecommendationPillar Pillar { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The source of the Recommendation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.RecommendationSource")]
        public Amazon.TrustedAdvisor.RecommendationSource Source { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the Recommendation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.RecommendationStatus")]
        public Amazon.TrustedAdvisor.RecommendationStatus Status { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the Recommendation</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TrustedAdvisor.RecommendationType")]
        public Amazon.TrustedAdvisor.RecommendationType Type { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OrganizationRecommendationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TrustedAdvisor.Model.ListOrganizationRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.TrustedAdvisor.Model.ListOrganizationRecommendationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OrganizationRecommendationSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.TrustedAdvisor.Model.ListOrganizationRecommendationsResponse, GetTAOrganizationRecommendationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AfterLastUpdatedAt = this.AfterLastUpdatedAt;
            context.AwsService = this.AwsService;
            context.BeforeLastUpdatedAt = this.BeforeLastUpdatedAt;
            context.CheckIdentifier = this.CheckIdentifier;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Pillar = this.Pillar;
            context.Source = this.Source;
            context.Status = this.Status;
            context.Type = this.Type;
            
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
            var request = new Amazon.TrustedAdvisor.Model.ListOrganizationRecommendationsRequest();
            
            if (cmdletContext.AfterLastUpdatedAt != null)
            {
                request.AfterLastUpdatedAt = cmdletContext.AfterLastUpdatedAt.Value;
            }
            if (cmdletContext.AwsService != null)
            {
                request.AwsService = cmdletContext.AwsService;
            }
            if (cmdletContext.BeforeLastUpdatedAt != null)
            {
                request.BeforeLastUpdatedAt = cmdletContext.BeforeLastUpdatedAt.Value;
            }
            if (cmdletContext.CheckIdentifier != null)
            {
                request.CheckIdentifier = cmdletContext.CheckIdentifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Pillar != null)
            {
                request.Pillar = cmdletContext.Pillar;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.TrustedAdvisor.Model.ListOrganizationRecommendationsResponse CallAWSServiceOperation(IAmazonTrustedAdvisor client, Amazon.TrustedAdvisor.Model.ListOrganizationRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Trusted Advisor", "ListOrganizationRecommendations");
            try
            {
                return client.ListOrganizationRecommendationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? AfterLastUpdatedAt { get; set; }
            public System.String AwsService { get; set; }
            public System.DateTime? BeforeLastUpdatedAt { get; set; }
            public System.String CheckIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.TrustedAdvisor.RecommendationPillar Pillar { get; set; }
            public Amazon.TrustedAdvisor.RecommendationSource Source { get; set; }
            public Amazon.TrustedAdvisor.RecommendationStatus Status { get; set; }
            public Amazon.TrustedAdvisor.RecommendationType Type { get; set; }
            public System.Func<Amazon.TrustedAdvisor.Model.ListOrganizationRecommendationsResponse, GetTAOrganizationRecommendationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OrganizationRecommendationSummaries;
        }
        
    }
}
