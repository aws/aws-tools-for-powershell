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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns a summary of resource evaluation for the specified resource evaluation ID
    /// from the proactive rules that were run. The results indicate which evaluation context
    /// was used to evaluate the rules, which resource details were evaluated, the evaluation
    /// mode that was run, and whether the resource details comply with the configuration
    /// of the proactive rules. 
    /// 
    ///  <note><para>
    /// To see additional information about the evaluation result, such as which rule flagged
    /// a resource as NON_COMPLIANT, use the <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_GetComplianceDetailsByResource.html">GetComplianceDetailsByResource</a>
    /// API. For more information, see the <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_GetResourceEvaluationSummary.html#API_GetResourceEvaluationSummary_Examples">Examples</a>
    /// section.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGResourceEvaluationSummary")]
    [OutputType("Amazon.ConfigService.Model.GetResourceEvaluationSummaryResponse")]
    [AWSCmdlet("Calls the AWS Config GetResourceEvaluationSummary API operation.", Operation = new[] {"GetResourceEvaluationSummary"}, SelectReturnType = typeof(Amazon.ConfigService.Model.GetResourceEvaluationSummaryResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.GetResourceEvaluationSummaryResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.GetResourceEvaluationSummaryResponse object containing multiple properties."
    )]
    public partial class GetCFGResourceEvaluationSummaryCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceEvaluationId
        /// <summary>
        /// <para>
        /// <para>The unique <c>ResourceEvaluationId</c> of Amazon Web Services resource execution for
        /// which you want to retrieve the evaluation summary.</para>
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
        public System.String ResourceEvaluationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.GetResourceEvaluationSummaryResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.GetResourceEvaluationSummaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceEvaluationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceEvaluationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceEvaluationId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.GetResourceEvaluationSummaryResponse, GetCFGResourceEvaluationSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceEvaluationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceEvaluationId = this.ResourceEvaluationId;
            #if MODULAR
            if (this.ResourceEvaluationId == null && ParameterWasBound(nameof(this.ResourceEvaluationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceEvaluationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.GetResourceEvaluationSummaryRequest();
            
            if (cmdletContext.ResourceEvaluationId != null)
            {
                request.ResourceEvaluationId = cmdletContext.ResourceEvaluationId;
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
        
        private Amazon.ConfigService.Model.GetResourceEvaluationSummaryResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetResourceEvaluationSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetResourceEvaluationSummary");
            try
            {
                #if DESKTOP
                return client.GetResourceEvaluationSummary(request);
                #elif CORECLR
                return client.GetResourceEvaluationSummaryAsync(request).GetAwaiter().GetResult();
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
            public System.String ResourceEvaluationId { get; set; }
            public System.Func<Amazon.ConfigService.Model.GetResourceEvaluationSummaryResponse, GetCFGResourceEvaluationSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
