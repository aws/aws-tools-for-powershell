/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Used by an Lambda function to deliver evaluation results to Config. This action is
    /// required in every Lambda function that is invoked by an Config rule.
    /// </summary>
    [Cmdlet("Write", "CFGEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.Evaluation")]
    [AWSCmdlet("Calls the AWS Config PutEvaluations API operation.", Operation = new[] {"PutEvaluations"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutEvaluationsResponse), LegacyAlias="Write-CFGEvaluations")]
    [AWSCmdletOutput("Amazon.ConfigService.Model.Evaluation or Amazon.ConfigService.Model.PutEvaluationsResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.Evaluation objects.",
        "The service call response (type Amazon.ConfigService.Model.PutEvaluationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGEvaluationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Evaluation
        /// <summary>
        /// <para>
        /// <para>The assessments that the Lambda function performs. Each evaluation identifies an Amazon
        /// Web Services resource and indicates whether it complies with the Config rule that
        /// invokes the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Evaluations")]
        public Amazon.ConfigService.Model.Evaluation[] Evaluation { get; set; }
        #endregion
        
        #region Parameter ResultToken
        /// <summary>
        /// <para>
        /// <para>An encrypted token that associates an evaluation with an Config rule. Identifies the
        /// rule and the event that triggered the evaluation.</para>
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
        public System.String ResultToken { get; set; }
        #endregion
        
        #region Parameter TestMode
        /// <summary>
        /// <para>
        /// <para>Use this parameter to specify a test run for <code>PutEvaluations</code>. You can
        /// verify whether your Lambda function will deliver evaluation results to Config. No
        /// updates occur to your existing evaluations, and evaluation results are not sent to
        /// Config.</para><note><para>When <code>TestMode</code> is <code>true</code>, <code>PutEvaluations</code> doesn't
        /// require a valid value for the <code>ResultToken</code> parameter, but the value cannot
        /// be null.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TestMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedEvaluations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutEvaluationsResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutEvaluationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedEvaluations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Evaluation parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Evaluation' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Evaluation' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Evaluation), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGEvaluation (PutEvaluations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutEvaluationsResponse, WriteCFGEvaluationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Evaluation;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Evaluation != null)
            {
                context.Evaluation = new List<Amazon.ConfigService.Model.Evaluation>(this.Evaluation);
            }
            context.ResultToken = this.ResultToken;
            #if MODULAR
            if (this.ResultToken == null && ParameterWasBound(nameof(this.ResultToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ResultToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TestMode = this.TestMode;
            
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
            var request = new Amazon.ConfigService.Model.PutEvaluationsRequest();
            
            if (cmdletContext.Evaluation != null)
            {
                request.Evaluations = cmdletContext.Evaluation;
            }
            if (cmdletContext.ResultToken != null)
            {
                request.ResultToken = cmdletContext.ResultToken;
            }
            if (cmdletContext.TestMode != null)
            {
                request.TestMode = cmdletContext.TestMode.Value;
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
        
        private Amazon.ConfigService.Model.PutEvaluationsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutEvaluationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutEvaluations");
            try
            {
                #if DESKTOP
                return client.PutEvaluations(request);
                #elif CORECLR
                return client.PutEvaluationsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public List<Amazon.ConfigService.Model.Evaluation> Evaluation { get; set; }
            public System.String ResultToken { get; set; }
            public System.Boolean? TestMode { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutEvaluationsResponse, WriteCFGEvaluationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedEvaluations;
        }
        
    }
}
