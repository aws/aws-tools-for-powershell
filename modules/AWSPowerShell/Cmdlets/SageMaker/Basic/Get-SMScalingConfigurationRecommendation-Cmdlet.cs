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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Starts an Amazon SageMaker Inference Recommender autoscaling recommendation job. Returns
    /// recommendations for autoscaling policies that you can apply to your SageMaker endpoint.
    /// </summary>
    [Cmdlet("Get", "SMScalingConfigurationRecommendation")]
    [OutputType("Amazon.SageMaker.Model.GetScalingConfigurationRecommendationResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service GetScalingConfigurationRecommendation API operation.", Operation = new[] {"GetScalingConfigurationRecommendation"}, SelectReturnType = typeof(Amazon.SageMaker.Model.GetScalingConfigurationRecommendationResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.GetScalingConfigurationRecommendationResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.GetScalingConfigurationRecommendationResponse object containing multiple properties."
    )]
    public partial class GetSMScalingConfigurationRecommendationCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of an endpoint benchmarked during a previously completed inference recommendation
        /// job. This name should come from one of the recommendations returned by the job specified
        /// in the <c>InferenceRecommendationsJobName</c> field.</para><para>Specify either this field or the <c>RecommendationId</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter InferenceRecommendationsJobName
        /// <summary>
        /// <para>
        /// <para>The name of a previously completed Inference Recommender job.</para>
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
        public System.String InferenceRecommendationsJobName { get; set; }
        #endregion
        
        #region Parameter ScalingPolicyObjective_MaxInvocationsPerMinute
        /// <summary>
        /// <para>
        /// <para>The maximum number of expected requests to your endpoint per minute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingPolicyObjective_MaxInvocationsPerMinute { get; set; }
        #endregion
        
        #region Parameter ScalingPolicyObjective_MinInvocationsPerMinute
        /// <summary>
        /// <para>
        /// <para>The minimum number of expected requests to your endpoint per minute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingPolicyObjective_MinInvocationsPerMinute { get; set; }
        #endregion
        
        #region Parameter RecommendationId
        /// <summary>
        /// <para>
        /// <para>The recommendation ID of a previously completed inference recommendation. This ID
        /// should come from one of the recommendations returned by the job specified in the <c>InferenceRecommendationsJobName</c>
        /// field.</para><para>Specify either this field or the <c>EndpointName</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecommendationId { get; set; }
        #endregion
        
        #region Parameter TargetCpuUtilizationPerCore
        /// <summary>
        /// <para>
        /// <para>The percentage of how much utilization you want an instance to use before autoscaling.
        /// The default value is 50%.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetCpuUtilizationPerCore { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.GetScalingConfigurationRecommendationResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.GetScalingConfigurationRecommendationResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.GetScalingConfigurationRecommendationResponse, GetSMScalingConfigurationRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndpointName = this.EndpointName;
            context.InferenceRecommendationsJobName = this.InferenceRecommendationsJobName;
            #if MODULAR
            if (this.InferenceRecommendationsJobName == null && ParameterWasBound(nameof(this.InferenceRecommendationsJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter InferenceRecommendationsJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecommendationId = this.RecommendationId;
            context.ScalingPolicyObjective_MaxInvocationsPerMinute = this.ScalingPolicyObjective_MaxInvocationsPerMinute;
            context.ScalingPolicyObjective_MinInvocationsPerMinute = this.ScalingPolicyObjective_MinInvocationsPerMinute;
            context.TargetCpuUtilizationPerCore = this.TargetCpuUtilizationPerCore;
            
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
            var request = new Amazon.SageMaker.Model.GetScalingConfigurationRecommendationRequest();
            
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.InferenceRecommendationsJobName != null)
            {
                request.InferenceRecommendationsJobName = cmdletContext.InferenceRecommendationsJobName;
            }
            if (cmdletContext.RecommendationId != null)
            {
                request.RecommendationId = cmdletContext.RecommendationId;
            }
            
             // populate ScalingPolicyObjective
            var requestScalingPolicyObjectiveIsNull = true;
            request.ScalingPolicyObjective = new Amazon.SageMaker.Model.ScalingPolicyObjective();
            System.Int32? requestScalingPolicyObjective_scalingPolicyObjective_MaxInvocationsPerMinute = null;
            if (cmdletContext.ScalingPolicyObjective_MaxInvocationsPerMinute != null)
            {
                requestScalingPolicyObjective_scalingPolicyObjective_MaxInvocationsPerMinute = cmdletContext.ScalingPolicyObjective_MaxInvocationsPerMinute.Value;
            }
            if (requestScalingPolicyObjective_scalingPolicyObjective_MaxInvocationsPerMinute != null)
            {
                request.ScalingPolicyObjective.MaxInvocationsPerMinute = requestScalingPolicyObjective_scalingPolicyObjective_MaxInvocationsPerMinute.Value;
                requestScalingPolicyObjectiveIsNull = false;
            }
            System.Int32? requestScalingPolicyObjective_scalingPolicyObjective_MinInvocationsPerMinute = null;
            if (cmdletContext.ScalingPolicyObjective_MinInvocationsPerMinute != null)
            {
                requestScalingPolicyObjective_scalingPolicyObjective_MinInvocationsPerMinute = cmdletContext.ScalingPolicyObjective_MinInvocationsPerMinute.Value;
            }
            if (requestScalingPolicyObjective_scalingPolicyObjective_MinInvocationsPerMinute != null)
            {
                request.ScalingPolicyObjective.MinInvocationsPerMinute = requestScalingPolicyObjective_scalingPolicyObjective_MinInvocationsPerMinute.Value;
                requestScalingPolicyObjectiveIsNull = false;
            }
             // determine if request.ScalingPolicyObjective should be set to null
            if (requestScalingPolicyObjectiveIsNull)
            {
                request.ScalingPolicyObjective = null;
            }
            if (cmdletContext.TargetCpuUtilizationPerCore != null)
            {
                request.TargetCpuUtilizationPerCore = cmdletContext.TargetCpuUtilizationPerCore.Value;
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
        
        private Amazon.SageMaker.Model.GetScalingConfigurationRecommendationResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.GetScalingConfigurationRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "GetScalingConfigurationRecommendation");
            try
            {
                return client.GetScalingConfigurationRecommendationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EndpointName { get; set; }
            public System.String InferenceRecommendationsJobName { get; set; }
            public System.String RecommendationId { get; set; }
            public System.Int32? ScalingPolicyObjective_MaxInvocationsPerMinute { get; set; }
            public System.Int32? ScalingPolicyObjective_MinInvocationsPerMinute { get; set; }
            public System.Int32? TargetCpuUtilizationPerCore { get; set; }
            public System.Func<Amazon.SageMaker.Model.GetScalingConfigurationRecommendationResponse, GetSMScalingConfigurationRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
