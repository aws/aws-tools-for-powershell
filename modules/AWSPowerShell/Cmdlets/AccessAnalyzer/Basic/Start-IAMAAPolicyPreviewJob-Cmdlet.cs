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
using Amazon.AccessAnalyzer;
using Amazon.AccessAnalyzer.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IAMAA
{
    /// <summary>
    /// Creates a policy preview analysis job to evaluate the impact of Service Control Policies
    /// (SCPs) before deployment. The analysis uses historical CloudTrail authorization events
    /// to identify potential access denials, helping you prevent service disruptions.
    /// 
    ///  
    /// <para>
    /// The job analyzes CloudTrail events within a specified time window and generates a
    /// report identifying which events would be denied by the proposed policy. The report
    /// is stored in the specified Amazon S3 location.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "IAMAAPolicyPreviewJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IAM Access Analyzer StartPolicyPreviewJob API operation.", Operation = new[] {"StartPolicyPreviewJob"}, SelectReturnType = typeof(Amazon.AccessAnalyzer.Model.StartPolicyPreviewJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.AccessAnalyzer.Model.StartPolicyPreviewJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AccessAnalyzer.Model.StartPolicyPreviewJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartIAMAAPolicyPreviewJobCmdlet : AmazonAccessAnalyzerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the analysis window. If not specified, defaults to the time of the request.
        /// The analysis will evaluate CloudTrail events up to this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter OutputS3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI where the completed analysis report will be stored. The Amazon S3
        /// bucket must grant access to the IAM Access Analyzer service principal in its resource
        /// policy. The report will be stored at the path: <c>outputS3Uri/jobId/timestamp/</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String OutputS3Uri { get; set; }
        #endregion
        
        #region Parameter PolicyConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of policy configurations to analyze. Currently limited to one configuration
        /// per request. Each configuration specifies the job type, target ID, and policy documents
        /// to test.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("PolicyConfigurations")]
        public Amazon.AccessAnalyzer.Model.PolicyConfiguration[] PolicyConfiguration { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the CloudTrail event analysis window. The analysis will evaluate events
        /// from this time forward.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, subsequent retries
        /// with the same client token return the result from the original successful request
        /// and have no additional effect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AccessAnalyzer.Model.StartPolicyPreviewJobResponse).
        /// Specifying the name of a property of type Amazon.AccessAnalyzer.Model.StartPolicyPreviewJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IAMAAPolicyPreviewJob (StartPolicyPreviewJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AccessAnalyzer.Model.StartPolicyPreviewJobResponse, StartIAMAAPolicyPreviewJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EndTime = this.EndTime;
            context.OutputS3Uri = this.OutputS3Uri;
            #if MODULAR
            if (this.OutputS3Uri == null && ParameterWasBound(nameof(this.OutputS3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputS3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PolicyConfiguration != null)
            {
                context.PolicyConfiguration = new List<Amazon.AccessAnalyzer.Model.PolicyConfiguration>(this.PolicyConfiguration);
            }
            #if MODULAR
            if (this.PolicyConfiguration == null && ParameterWasBound(nameof(this.PolicyConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AccessAnalyzer.Model.StartPolicyPreviewJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.OutputS3Uri != null)
            {
                request.OutputS3Uri = cmdletContext.OutputS3Uri;
            }
            if (cmdletContext.PolicyConfiguration != null)
            {
                request.PolicyConfigurations = cmdletContext.PolicyConfiguration;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.AccessAnalyzer.Model.StartPolicyPreviewJobResponse CallAWSServiceOperation(IAmazonAccessAnalyzer client, Amazon.AccessAnalyzer.Model.StartPolicyPreviewJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IAM Access Analyzer", "StartPolicyPreviewJob");
            try
            {
                return client.StartPolicyPreviewJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.String OutputS3Uri { get; set; }
            public List<Amazon.AccessAnalyzer.Model.PolicyConfiguration> PolicyConfiguration { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.AccessAnalyzer.Model.StartPolicyPreviewJobResponse, StartIAMAAPolicyPreviewJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
