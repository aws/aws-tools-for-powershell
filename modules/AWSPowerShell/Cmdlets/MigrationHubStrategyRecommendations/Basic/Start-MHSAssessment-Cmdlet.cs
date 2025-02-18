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
using Amazon.MigrationHubStrategyRecommendations;
using Amazon.MigrationHubStrategyRecommendations.Model;

namespace Amazon.PowerShell.Cmdlets.MHS
{
    /// <summary>
    /// Starts the assessment of an on-premises environment.
    /// </summary>
    [Cmdlet("Start", "MHSAssessment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Migration Hub Strategy Recommendations StartAssessment API operation.", Operation = new[] {"StartAssessment"}, SelectReturnType = typeof(Amazon.MigrationHubStrategyRecommendations.Model.StartAssessmentResponse))]
    [AWSCmdletOutput("System.String or Amazon.MigrationHubStrategyRecommendations.Model.StartAssessmentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MigrationHubStrategyRecommendations.Model.StartAssessmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartMHSAssessmentCmdlet : AmazonMigrationHubStrategyRecommendationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssessmentDataSourceType
        /// <summary>
        /// <para>
        /// <para>The data source type of an assessment to be started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.AssessmentDataSourceType")]
        public Amazon.MigrationHubStrategyRecommendations.AssessmentDataSourceType AssessmentDataSourceType { get; set; }
        #endregion
        
        #region Parameter AssessmentTarget
        /// <summary>
        /// <para>
        /// <para>List of criteria for assessment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssessmentTargets")]
        public Amazon.MigrationHubStrategyRecommendations.Model.AssessmentTarget[] AssessmentTarget { get; set; }
        #endregion
        
        #region Parameter S3bucketForAnalysisData
        /// <summary>
        /// <para>
        /// <para> The S3 bucket used by the collectors to send analysis data to the service. The bucket
        /// name must begin with <c>migrationhub-strategy-</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3bucketForAnalysisData { get; set; }
        #endregion
        
        #region Parameter S3bucketForReportData
        /// <summary>
        /// <para>
        /// <para> The S3 bucket where all the reports generated by the service are stored. The bucket
        /// name must begin with <c>migrationhub-strategy-</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3bucketForReportData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssessmentId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubStrategyRecommendations.Model.StartAssessmentResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubStrategyRecommendations.Model.StartAssessmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssessmentId";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-MHSAssessment (StartAssessment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubStrategyRecommendations.Model.StartAssessmentResponse, StartMHSAssessmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssessmentDataSourceType = this.AssessmentDataSourceType;
            if (this.AssessmentTarget != null)
            {
                context.AssessmentTarget = new List<Amazon.MigrationHubStrategyRecommendations.Model.AssessmentTarget>(this.AssessmentTarget);
            }
            context.S3bucketForAnalysisData = this.S3bucketForAnalysisData;
            context.S3bucketForReportData = this.S3bucketForReportData;
            
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
            var request = new Amazon.MigrationHubStrategyRecommendations.Model.StartAssessmentRequest();
            
            if (cmdletContext.AssessmentDataSourceType != null)
            {
                request.AssessmentDataSourceType = cmdletContext.AssessmentDataSourceType;
            }
            if (cmdletContext.AssessmentTarget != null)
            {
                request.AssessmentTargets = cmdletContext.AssessmentTarget;
            }
            if (cmdletContext.S3bucketForAnalysisData != null)
            {
                request.S3bucketForAnalysisData = cmdletContext.S3bucketForAnalysisData;
            }
            if (cmdletContext.S3bucketForReportData != null)
            {
                request.S3bucketForReportData = cmdletContext.S3bucketForReportData;
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
        
        private Amazon.MigrationHubStrategyRecommendations.Model.StartAssessmentResponse CallAWSServiceOperation(IAmazonMigrationHubStrategyRecommendations client, Amazon.MigrationHubStrategyRecommendations.Model.StartAssessmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Migration Hub Strategy Recommendations", "StartAssessment");
            try
            {
                return client.StartAssessmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.MigrationHubStrategyRecommendations.AssessmentDataSourceType AssessmentDataSourceType { get; set; }
            public List<Amazon.MigrationHubStrategyRecommendations.Model.AssessmentTarget> AssessmentTarget { get; set; }
            public System.String S3bucketForAnalysisData { get; set; }
            public System.String S3bucketForReportData { get; set; }
            public System.Func<Amazon.MigrationHubStrategyRecommendations.Model.StartAssessmentResponse, StartMHSAssessmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssessmentId;
        }
        
    }
}
