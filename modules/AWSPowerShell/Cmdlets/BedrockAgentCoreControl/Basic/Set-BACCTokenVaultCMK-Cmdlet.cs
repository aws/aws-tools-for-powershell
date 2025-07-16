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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Sets the customer master key (CMK) for a token vault.
    /// </summary>
    [Cmdlet("Set", "BACCTokenVaultCMK", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer SetTokenVaultCMK API operation.", Operation = new[] {"SetTokenVaultCMK"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKResponse object containing multiple properties."
    )]
    public partial class SetBACCTokenVaultCMKCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KmsConfiguration_KeyType
        /// <summary>
        /// <para>
        /// <para>The type of KMS key (CustomerManagedKey or ServiceManagedKey).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.KeyType")]
        public Amazon.BedrockAgentCoreControl.KeyType KmsConfiguration_KeyType { get; set; }
        #endregion
        
        #region Parameter KmsConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter TokenVaultId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the token vault to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenVaultId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KmsConfiguration_KeyType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KmsConfiguration_KeyType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KmsConfiguration_KeyType' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TokenVaultId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-BACCTokenVaultCMK (SetTokenVaultCMK)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKResponse, SetBACCTokenVaultCMKCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KmsConfiguration_KeyType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.KmsConfiguration_KeyType = this.KmsConfiguration_KeyType;
            #if MODULAR
            if (this.KmsConfiguration_KeyType == null && ParameterWasBound(nameof(this.KmsConfiguration_KeyType)))
            {
                WriteWarning("You are passing $null as a value for parameter KmsConfiguration_KeyType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsConfiguration_KmsKeyArn = this.KmsConfiguration_KmsKeyArn;
            context.TokenVaultId = this.TokenVaultId;
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKRequest();
            
            
             // populate KmsConfiguration
            var requestKmsConfigurationIsNull = true;
            request.KmsConfiguration = new Amazon.BedrockAgentCoreControl.Model.KmsConfiguration();
            Amazon.BedrockAgentCoreControl.KeyType requestKmsConfiguration_kmsConfiguration_KeyType = null;
            if (cmdletContext.KmsConfiguration_KeyType != null)
            {
                requestKmsConfiguration_kmsConfiguration_KeyType = cmdletContext.KmsConfiguration_KeyType;
            }
            if (requestKmsConfiguration_kmsConfiguration_KeyType != null)
            {
                request.KmsConfiguration.KeyType = requestKmsConfiguration_kmsConfiguration_KeyType;
                requestKmsConfigurationIsNull = false;
            }
            System.String requestKmsConfiguration_kmsConfiguration_KmsKeyArn = null;
            if (cmdletContext.KmsConfiguration_KmsKeyArn != null)
            {
                requestKmsConfiguration_kmsConfiguration_KmsKeyArn = cmdletContext.KmsConfiguration_KmsKeyArn;
            }
            if (requestKmsConfiguration_kmsConfiguration_KmsKeyArn != null)
            {
                request.KmsConfiguration.KmsKeyArn = requestKmsConfiguration_kmsConfiguration_KmsKeyArn;
                requestKmsConfigurationIsNull = false;
            }
             // determine if request.KmsConfiguration should be set to null
            if (requestKmsConfigurationIsNull)
            {
                request.KmsConfiguration = null;
            }
            if (cmdletContext.TokenVaultId != null)
            {
                request.TokenVaultId = cmdletContext.TokenVaultId;
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
        
        private Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "SetTokenVaultCMK");
            try
            {
                #if DESKTOP
                return client.SetTokenVaultCMK(request);
                #elif CORECLR
                return client.SetTokenVaultCMKAsync(request).GetAwaiter().GetResult();
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
            public Amazon.BedrockAgentCoreControl.KeyType KmsConfiguration_KeyType { get; set; }
            public System.String KmsConfiguration_KmsKeyArn { get; set; }
            public System.String TokenVaultId { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.SetTokenVaultCMKResponse, SetBACCTokenVaultCMKCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
