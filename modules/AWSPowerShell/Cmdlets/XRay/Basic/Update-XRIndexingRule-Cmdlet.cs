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
    /// Modifies an indexing rule’s configuration. 
    /// 
    ///  
    /// <para>
    /// Indexing rules are used for determining the sampling rate for spans indexed from CloudWatch
    /// Logs. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Transaction-Search.html">Transaction
    /// Search</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "XRIndexingRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.XRay.Model.IndexingRule")]
    [AWSCmdlet("Calls the AWS X-Ray UpdateIndexingRule API operation.", Operation = new[] {"UpdateIndexingRule"}, SelectReturnType = typeof(Amazon.XRay.Model.UpdateIndexingRuleResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.IndexingRule or Amazon.XRay.Model.UpdateIndexingRuleResponse",
        "This cmdlet returns an Amazon.XRay.Model.IndexingRule object.",
        "The service call response (type Amazon.XRay.Model.UpdateIndexingRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateXRIndexingRuleCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Probabilistic_DesiredSamplingPercentage
        /// <summary>
        /// <para>
        /// <para> Configured sampling percentage of traceIds. Note that sampling can be subject to
        /// limits to ensure completeness of data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Probabilistic_DesiredSamplingPercentage")]
        public System.Double? Probabilistic_DesiredSamplingPercentage { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> Name of the indexing rule to be updated. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IndexingRule'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.UpdateIndexingRuleResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.UpdateIndexingRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IndexingRule";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-XRIndexingRule (UpdateIndexingRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.UpdateIndexingRuleResponse, UpdateXRIndexingRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Probabilistic_DesiredSamplingPercentage = this.Probabilistic_DesiredSamplingPercentage;
            
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
            var request = new Amazon.XRay.Model.UpdateIndexingRuleRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Rule
            var requestRuleIsNull = true;
            request.Rule = new Amazon.XRay.Model.IndexingRuleValueUpdate();
            Amazon.XRay.Model.ProbabilisticRuleValueUpdate requestRule_rule_Probabilistic = null;
            
             // populate Probabilistic
            var requestRule_rule_ProbabilisticIsNull = true;
            requestRule_rule_Probabilistic = new Amazon.XRay.Model.ProbabilisticRuleValueUpdate();
            System.Double? requestRule_rule_Probabilistic_probabilistic_DesiredSamplingPercentage = null;
            if (cmdletContext.Probabilistic_DesiredSamplingPercentage != null)
            {
                requestRule_rule_Probabilistic_probabilistic_DesiredSamplingPercentage = cmdletContext.Probabilistic_DesiredSamplingPercentage.Value;
            }
            if (requestRule_rule_Probabilistic_probabilistic_DesiredSamplingPercentage != null)
            {
                requestRule_rule_Probabilistic.DesiredSamplingPercentage = requestRule_rule_Probabilistic_probabilistic_DesiredSamplingPercentage.Value;
                requestRule_rule_ProbabilisticIsNull = false;
            }
             // determine if requestRule_rule_Probabilistic should be set to null
            if (requestRule_rule_ProbabilisticIsNull)
            {
                requestRule_rule_Probabilistic = null;
            }
            if (requestRule_rule_Probabilistic != null)
            {
                request.Rule.Probabilistic = requestRule_rule_Probabilistic;
                requestRuleIsNull = false;
            }
             // determine if request.Rule should be set to null
            if (requestRuleIsNull)
            {
                request.Rule = null;
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
        
        private Amazon.XRay.Model.UpdateIndexingRuleResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.UpdateIndexingRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "UpdateIndexingRule");
            try
            {
                return client.UpdateIndexingRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.Double? Probabilistic_DesiredSamplingPercentage { get; set; }
            public System.Func<Amazon.XRay.Model.UpdateIndexingRuleResponse, UpdateXRIndexingRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IndexingRule;
        }
        
    }
}
