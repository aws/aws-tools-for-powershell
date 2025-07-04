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
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDRR
{
    /// <summary>
    /// The action to apply a guardrail.
    /// 
    ///  
    /// <para>
    /// For troubleshooting some of the common errors you might encounter when using the <c>ApplyGuardrail</c>
    /// API, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/troubleshooting-api-error-codes.html">Troubleshooting
    /// Amazon Bedrock API Error Codes</a> in the Amazon Bedrock User Guide
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "BDRRGuardrail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockRuntime.Model.ApplyGuardrailResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Runtime ApplyGuardrail API operation.", Operation = new[] {"ApplyGuardrail"}, SelectReturnType = typeof(Amazon.BedrockRuntime.Model.ApplyGuardrailResponse))]
    [AWSCmdletOutput("Amazon.BedrockRuntime.Model.ApplyGuardrailResponse",
        "This cmdlet returns an Amazon.BedrockRuntime.Model.ApplyGuardrailResponse object containing multiple properties."
    )]
    public partial class InvokeBDRRGuardrailCmdlet : AmazonBedrockRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The content details used in the request to apply the guardrail.</para><para />
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
        public Amazon.BedrockRuntime.Model.GuardrailContentBlock[] Content { get; set; }
        #endregion
        
        #region Parameter GuardrailIdentifier
        /// <summary>
        /// <para>
        /// <para>The guardrail identifier used in the request to apply the guardrail.</para>
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
        public System.String GuardrailIdentifier { get; set; }
        #endregion
        
        #region Parameter GuardrailVersion
        /// <summary>
        /// <para>
        /// <para>The guardrail version used in the request to apply the guardrail.</para>
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
        public System.String GuardrailVersion { get; set; }
        #endregion
        
        #region Parameter OutputScope
        /// <summary>
        /// <para>
        /// <para>Specifies the scope of the output that you get in the response. Set to <c>FULL</c>
        /// to return the entire output, including any detected and non-detected entries in the
        /// response for enhanced debugging.</para><para>Note that the full output scope doesn't apply to word filters or regex in sensitive
        /// information filters. It does apply to all other filtering policies, including sensitive
        /// information with filters that can detect personally identifiable information (PII).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockRuntime.GuardrailOutputScope")]
        public Amazon.BedrockRuntime.GuardrailOutputScope OutputScope { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The source of data used in the request to apply the guardrail.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockRuntime.GuardrailContentSource")]
        public Amazon.BedrockRuntime.GuardrailContentSource Source { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockRuntime.Model.ApplyGuardrailResponse).
        /// Specifying the name of a property of type Amazon.BedrockRuntime.Model.ApplyGuardrailResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GuardrailIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BDRRGuardrail (ApplyGuardrail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockRuntime.Model.ApplyGuardrailResponse, InvokeBDRRGuardrailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Content != null)
            {
                context.Content = new List<Amazon.BedrockRuntime.Model.GuardrailContentBlock>(this.Content);
            }
            #if MODULAR
            if (this.Content == null && ParameterWasBound(nameof(this.Content)))
            {
                WriteWarning("You are passing $null as a value for parameter Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GuardrailIdentifier = this.GuardrailIdentifier;
            #if MODULAR
            if (this.GuardrailIdentifier == null && ParameterWasBound(nameof(this.GuardrailIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GuardrailIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GuardrailVersion = this.GuardrailVersion;
            #if MODULAR
            if (this.GuardrailVersion == null && ParameterWasBound(nameof(this.GuardrailVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter GuardrailVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputScope = this.OutputScope;
            context.Source = this.Source;
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockRuntime.Model.ApplyGuardrailRequest();
            
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.GuardrailIdentifier != null)
            {
                request.GuardrailIdentifier = cmdletContext.GuardrailIdentifier;
            }
            if (cmdletContext.GuardrailVersion != null)
            {
                request.GuardrailVersion = cmdletContext.GuardrailVersion;
            }
            if (cmdletContext.OutputScope != null)
            {
                request.OutputScope = cmdletContext.OutputScope;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
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
        
        private Amazon.BedrockRuntime.Model.ApplyGuardrailResponse CallAWSServiceOperation(IAmazonBedrockRuntime client, Amazon.BedrockRuntime.Model.ApplyGuardrailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Runtime", "ApplyGuardrail");
            try
            {
                return client.ApplyGuardrailAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.BedrockRuntime.Model.GuardrailContentBlock> Content { get; set; }
            public System.String GuardrailIdentifier { get; set; }
            public System.String GuardrailVersion { get; set; }
            public Amazon.BedrockRuntime.GuardrailOutputScope OutputScope { get; set; }
            public Amazon.BedrockRuntime.GuardrailContentSource Source { get; set; }
            public System.Func<Amazon.BedrockRuntime.Model.ApplyGuardrailResponse, InvokeBDRRGuardrailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
