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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Deletes a sampling rule.
    /// </summary>
    [Cmdlet("Remove", "XRSamplingRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.XRay.Model.SamplingRuleRecord")]
    [AWSCmdlet("Calls the AWS X-Ray DeleteSamplingRule API operation.", Operation = new[] {"DeleteSamplingRule"}, SelectReturnType = typeof(Amazon.XRay.Model.DeleteSamplingRuleResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.SamplingRuleRecord or Amazon.XRay.Model.DeleteSamplingRuleResponse",
        "This cmdlet returns an Amazon.XRay.Model.SamplingRuleRecord object.",
        "The service call response (type Amazon.XRay.Model.DeleteSamplingRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveXRSamplingRuleCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RuleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the sampling rule. Specify a rule by either name or ARN, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuleARN { get; set; }
        #endregion
        
        #region Parameter RuleName
        /// <summary>
        /// <para>
        /// <para>The name of the sampling rule. Specify a rule by either name or ARN, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RuleName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SamplingRuleRecord'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.DeleteSamplingRuleResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.DeleteSamplingRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SamplingRuleRecord";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-XRSamplingRule (DeleteSamplingRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.DeleteSamplingRuleResponse, RemoveXRSamplingRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RuleARN = this.RuleARN;
            context.RuleName = this.RuleName;
            
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
            var request = new Amazon.XRay.Model.DeleteSamplingRuleRequest();
            
            if (cmdletContext.RuleARN != null)
            {
                request.RuleARN = cmdletContext.RuleARN;
            }
            if (cmdletContext.RuleName != null)
            {
                request.RuleName = cmdletContext.RuleName;
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
        
        private Amazon.XRay.Model.DeleteSamplingRuleResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.DeleteSamplingRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "DeleteSamplingRule");
            try
            {
                return client.DeleteSamplingRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RuleARN { get; set; }
            public System.String RuleName { get; set; }
            public System.Func<Amazon.XRay.Model.DeleteSamplingRuleResponse, RemoveXRSamplingRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SamplingRuleRecord;
        }
        
    }
}
