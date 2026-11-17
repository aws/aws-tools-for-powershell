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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Updates the enablement status or encryption configuration of an Agent Insight Store.
    /// </summary>
    [Cmdlet("Update", "BACCAgentInsightStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Control UpdateAgentInsightStore API operation.", Operation = new[] {"UpdateAgentInsightStore"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreResponse object containing multiple properties."
    )]
    public partial class UpdateBACCAgentInsightStoreCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentInsightStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the unique identifier of the Agent Insight Store to update.</para>
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
        public System.String AgentInsightStoreId { get; set; }
        #endregion
        
        #region Parameter EnablementStatus
        /// <summary>
        /// <para>
        /// <para>Specifies whether the Agent Insight Store accepts new Agent Insights. If you don't
        /// specify this parameter, the store's current enablement setting remains unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.AgentInsightStoreEnablementStatus")]
        public Amazon.BedrockAgentCoreControl.AgentInsightStoreEnablementStatus EnablementStatus { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the customer managed AWS KMS key that
        /// you use to encrypt new Agent Insights. This field is required when <c>mode</c> is
        /// <c>CUSTOMER_MANAGED_KMS</c> and cannot be specified when <c>mode</c> is <c>AWS_OWNED_KMS_KEY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_Mode
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption mode used to protect new Agent Insights.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.AgentInsightStoreEncryptionMode")]
        public Amazon.BedrockAgentCoreControl.AgentInsightStoreEncryptionMode EncryptionConfiguration_Mode { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If you don't specify this field, a value is randomly generated for
        /// you. If this token matches a previous request, the service ignores the request, but
        /// doesn't return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentInsightStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BACCAgentInsightStore (UpdateAgentInsightStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreResponse, UpdateBACCAgentInsightStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentInsightStoreId = this.AgentInsightStoreId;
            #if MODULAR
            if (this.AgentInsightStoreId == null && ParameterWasBound(nameof(this.AgentInsightStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentInsightStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EnablementStatus = this.EnablementStatus;
            context.EncryptionConfiguration_KmsKeyArn = this.EncryptionConfiguration_KmsKeyArn;
            context.EncryptionConfiguration_Mode = this.EncryptionConfiguration_Mode;
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreRequest();
            
            if (cmdletContext.AgentInsightStoreId != null)
            {
                request.AgentInsightStoreId = cmdletContext.AgentInsightStoreId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnablementStatus != null)
            {
                request.EnablementStatus = cmdletContext.EnablementStatus;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.BedrockAgentCoreControl.Model.AgentInsightStoreEncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = cmdletContext.EncryptionConfiguration_KmsKeyArn;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn != null)
            {
                request.EncryptionConfiguration.KmsKeyArn = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.AgentInsightStoreEncryptionMode requestEncryptionConfiguration_encryptionConfiguration_Mode = null;
            if (cmdletContext.EncryptionConfiguration_Mode != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_Mode = cmdletContext.EncryptionConfiguration_Mode;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_Mode != null)
            {
                request.EncryptionConfiguration.Mode = requestEncryptionConfiguration_encryptionConfiguration_Mode;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Control", "UpdateAgentInsightStore");
            try
            {
                return client.UpdateAgentInsightStoreAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentInsightStoreId { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.BedrockAgentCoreControl.AgentInsightStoreEnablementStatus EnablementStatus { get; set; }
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.BedrockAgentCoreControl.AgentInsightStoreEncryptionMode EncryptionConfiguration_Mode { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.UpdateAgentInsightStoreResponse, UpdateBACCAgentInsightStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
