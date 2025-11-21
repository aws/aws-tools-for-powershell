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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Sets the account-level enforced guardrail configuration.
    /// </summary>
    [Cmdlet("Write", "BDREnforcedGuardrailConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock PutEnforcedGuardrailConfiguration API operation.", Operation = new[] {"PutEnforcedGuardrailConfiguration"}, SelectReturnType = typeof(Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationResponse object containing multiple properties."
    )]
    public partial class WriteBDREnforcedGuardrailConfigurationCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigId
        /// <summary>
        /// <para>
        /// <para>Unique ID for the account enforced configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigId { get; set; }
        #endregion
        
        #region Parameter GuardrailInferenceConfig_GuardrailIdentifier
        /// <summary>
        /// <para>
        /// <para>Identifier for the guardrail, could be the ID or the ARN.</para>
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
        public System.String GuardrailInferenceConfig_GuardrailIdentifier { get; set; }
        #endregion
        
        #region Parameter GuardrailInferenceConfig_GuardrailVersion
        /// <summary>
        /// <para>
        /// <para>Numerical guardrail version.</para>
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
        public System.String GuardrailInferenceConfig_GuardrailVersion { get; set; }
        #endregion
        
        #region Parameter GuardrailInferenceConfig_InputTag
        /// <summary>
        /// <para>
        /// <para>Whether to honor or ignore input tags at runtime.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("GuardrailInferenceConfig_InputTags")]
        [AWSConstantClassSource("Amazon.Bedrock.InputTags")]
        public Amazon.Bedrock.InputTags GuardrailInferenceConfig_InputTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GuardrailInferenceConfig_GuardrailIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BDREnforcedGuardrailConfiguration (PutEnforcedGuardrailConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationResponse, WriteBDREnforcedGuardrailConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigId = this.ConfigId;
            context.GuardrailInferenceConfig_GuardrailIdentifier = this.GuardrailInferenceConfig_GuardrailIdentifier;
            #if MODULAR
            if (this.GuardrailInferenceConfig_GuardrailIdentifier == null && ParameterWasBound(nameof(this.GuardrailInferenceConfig_GuardrailIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GuardrailInferenceConfig_GuardrailIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GuardrailInferenceConfig_GuardrailVersion = this.GuardrailInferenceConfig_GuardrailVersion;
            #if MODULAR
            if (this.GuardrailInferenceConfig_GuardrailVersion == null && ParameterWasBound(nameof(this.GuardrailInferenceConfig_GuardrailVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter GuardrailInferenceConfig_GuardrailVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GuardrailInferenceConfig_InputTag = this.GuardrailInferenceConfig_InputTag;
            #if MODULAR
            if (this.GuardrailInferenceConfig_InputTag == null && ParameterWasBound(nameof(this.GuardrailInferenceConfig_InputTag)))
            {
                WriteWarning("You are passing $null as a value for parameter GuardrailInferenceConfig_InputTag which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationRequest();
            
            if (cmdletContext.ConfigId != null)
            {
                request.ConfigId = cmdletContext.ConfigId;
            }
            
             // populate GuardrailInferenceConfig
            var requestGuardrailInferenceConfigIsNull = true;
            request.GuardrailInferenceConfig = new Amazon.Bedrock.Model.AccountEnforcedGuardrailInferenceInputConfiguration();
            System.String requestGuardrailInferenceConfig_guardrailInferenceConfig_GuardrailIdentifier = null;
            if (cmdletContext.GuardrailInferenceConfig_GuardrailIdentifier != null)
            {
                requestGuardrailInferenceConfig_guardrailInferenceConfig_GuardrailIdentifier = cmdletContext.GuardrailInferenceConfig_GuardrailIdentifier;
            }
            if (requestGuardrailInferenceConfig_guardrailInferenceConfig_GuardrailIdentifier != null)
            {
                request.GuardrailInferenceConfig.GuardrailIdentifier = requestGuardrailInferenceConfig_guardrailInferenceConfig_GuardrailIdentifier;
                requestGuardrailInferenceConfigIsNull = false;
            }
            System.String requestGuardrailInferenceConfig_guardrailInferenceConfig_GuardrailVersion = null;
            if (cmdletContext.GuardrailInferenceConfig_GuardrailVersion != null)
            {
                requestGuardrailInferenceConfig_guardrailInferenceConfig_GuardrailVersion = cmdletContext.GuardrailInferenceConfig_GuardrailVersion;
            }
            if (requestGuardrailInferenceConfig_guardrailInferenceConfig_GuardrailVersion != null)
            {
                request.GuardrailInferenceConfig.GuardrailVersion = requestGuardrailInferenceConfig_guardrailInferenceConfig_GuardrailVersion;
                requestGuardrailInferenceConfigIsNull = false;
            }
            Amazon.Bedrock.InputTags requestGuardrailInferenceConfig_guardrailInferenceConfig_InputTag = null;
            if (cmdletContext.GuardrailInferenceConfig_InputTag != null)
            {
                requestGuardrailInferenceConfig_guardrailInferenceConfig_InputTag = cmdletContext.GuardrailInferenceConfig_InputTag;
            }
            if (requestGuardrailInferenceConfig_guardrailInferenceConfig_InputTag != null)
            {
                request.GuardrailInferenceConfig.InputTags = requestGuardrailInferenceConfig_guardrailInferenceConfig_InputTag;
                requestGuardrailInferenceConfigIsNull = false;
            }
             // determine if request.GuardrailInferenceConfig should be set to null
            if (requestGuardrailInferenceConfigIsNull)
            {
                request.GuardrailInferenceConfig = null;
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
        
        private Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "PutEnforcedGuardrailConfiguration");
            try
            {
                return client.PutEnforcedGuardrailConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigId { get; set; }
            public System.String GuardrailInferenceConfig_GuardrailIdentifier { get; set; }
            public System.String GuardrailInferenceConfig_GuardrailVersion { get; set; }
            public Amazon.Bedrock.InputTags GuardrailInferenceConfig_InputTag { get; set; }
            public System.Func<Amazon.Bedrock.Model.PutEnforcedGuardrailConfigurationResponse, WriteBDREnforcedGuardrailConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
