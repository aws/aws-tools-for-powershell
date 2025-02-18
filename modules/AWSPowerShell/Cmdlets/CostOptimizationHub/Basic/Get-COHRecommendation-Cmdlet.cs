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
    /// Returns both the current and recommended resource configuration and the estimated
    /// cost impact for a recommendation.
    /// 
    ///  
    /// <para>
    /// The <c>recommendationId</c> is only valid for up to a maximum of 24 hours as recommendations
    /// are refreshed daily. To retrieve the <c>recommendationId</c>, use the <c>ListRecommendations</c>
    /// API.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "COHRecommendation")]
    [OutputType("Amazon.CostOptimizationHub.Model.GetRecommendationResponse")]
    [AWSCmdlet("Calls the Cost Optimization Hub GetRecommendation API operation.", Operation = new[] {"GetRecommendation"}, SelectReturnType = typeof(Amazon.CostOptimizationHub.Model.GetRecommendationResponse))]
    [AWSCmdletOutput("Amazon.CostOptimizationHub.Model.GetRecommendationResponse",
        "This cmdlet returns an Amazon.CostOptimizationHub.Model.GetRecommendationResponse object containing multiple properties."
    )]
    public partial class GetCOHRecommendationCmdlet : AmazonCostOptimizationHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RecommendationId
        /// <summary>
        /// <para>
        /// <para>The ID for the recommendation.</para>
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
        public System.String RecommendationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostOptimizationHub.Model.GetRecommendationResponse).
        /// Specifying the name of a property of type Amazon.CostOptimizationHub.Model.GetRecommendationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CostOptimizationHub.Model.GetRecommendationResponse, GetCOHRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RecommendationId = this.RecommendationId;
            #if MODULAR
            if (this.RecommendationId == null && ParameterWasBound(nameof(this.RecommendationId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommendationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CostOptimizationHub.Model.GetRecommendationRequest();
            
            if (cmdletContext.RecommendationId != null)
            {
                request.RecommendationId = cmdletContext.RecommendationId;
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
        
        private Amazon.CostOptimizationHub.Model.GetRecommendationResponse CallAWSServiceOperation(IAmazonCostOptimizationHub client, Amazon.CostOptimizationHub.Model.GetRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Cost Optimization Hub", "GetRecommendation");
            try
            {
                return client.GetRecommendationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RecommendationId { get; set; }
            public System.Func<Amazon.CostOptimizationHub.Model.GetRecommendationResponse, GetCOHRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
