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

namespace Amazon.PowerShell.Cmdlets.IAMAA
{
    /// <summary>
    /// Retrieves the policy that was generated using <c>StartPolicyGeneration</c>.
    /// </summary>
    [Cmdlet("Get", "IAMAAGeneratedPolicy")]
    [OutputType("Amazon.AccessAnalyzer.Model.GetGeneratedPolicyResponse")]
    [AWSCmdlet("Calls the AWS IAM Access Analyzer GetGeneratedPolicy API operation.", Operation = new[] {"GetGeneratedPolicy"}, SelectReturnType = typeof(Amazon.AccessAnalyzer.Model.GetGeneratedPolicyResponse))]
    [AWSCmdletOutput("Amazon.AccessAnalyzer.Model.GetGeneratedPolicyResponse",
        "This cmdlet returns an Amazon.AccessAnalyzer.Model.GetGeneratedPolicyResponse object containing multiple properties."
    )]
    public partial class GetIAMAAGeneratedPolicyCmdlet : AmazonAccessAnalyzerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IncludeResourcePlaceholder
        /// <summary>
        /// <para>
        /// <para>The level of detail that you want to generate. You can specify whether to generate
        /// policies with placeholders for resource ARNs for actions that support resource level
        /// granularity in policies.</para><para>For example, in the resource section of a policy, you can receive a placeholder such
        /// as <c>"Resource":"arn:aws:s3:::${BucketName}"</c> instead of <c>"*"</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeResourcePlaceholders")]
        public System.Boolean? IncludeResourcePlaceholder { get; set; }
        #endregion
        
        #region Parameter IncludeServiceLevelTemplate
        /// <summary>
        /// <para>
        /// <para>The level of detail that you want to generate. You can specify whether to generate
        /// service-level policies. </para><para>IAM Access Analyzer uses <c>iam:servicelastaccessed</c> to identify services that
        /// have been used recently to create this service-level template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeServiceLevelTemplate { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The <c>JobId</c> that is returned by the <c>StartPolicyGeneration</c> operation. The
        /// <c>JobId</c> can be used with <c>GetGeneratedPolicy</c> to retrieve the generated
        /// policies or used with <c>CancelPolicyGeneration</c> to cancel the policy generation
        /// request.</para>
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
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AccessAnalyzer.Model.GetGeneratedPolicyResponse).
        /// Specifying the name of a property of type Amazon.AccessAnalyzer.Model.GetGeneratedPolicyResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.AccessAnalyzer.Model.GetGeneratedPolicyResponse, GetIAMAAGeneratedPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IncludeResourcePlaceholder = this.IncludeResourcePlaceholder;
            context.IncludeServiceLevelTemplate = this.IncludeServiceLevelTemplate;
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AccessAnalyzer.Model.GetGeneratedPolicyRequest();
            
            if (cmdletContext.IncludeResourcePlaceholder != null)
            {
                request.IncludeResourcePlaceholders = cmdletContext.IncludeResourcePlaceholder.Value;
            }
            if (cmdletContext.IncludeServiceLevelTemplate != null)
            {
                request.IncludeServiceLevelTemplate = cmdletContext.IncludeServiceLevelTemplate.Value;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
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
        
        private Amazon.AccessAnalyzer.Model.GetGeneratedPolicyResponse CallAWSServiceOperation(IAmazonAccessAnalyzer client, Amazon.AccessAnalyzer.Model.GetGeneratedPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IAM Access Analyzer", "GetGeneratedPolicy");
            try
            {
                return client.GetGeneratedPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeResourcePlaceholder { get; set; }
            public System.Boolean? IncludeServiceLevelTemplate { get; set; }
            public System.String JobId { get; set; }
            public System.Func<Amazon.AccessAnalyzer.Model.GetGeneratedPolicyResponse, GetIAMAAGeneratedPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
