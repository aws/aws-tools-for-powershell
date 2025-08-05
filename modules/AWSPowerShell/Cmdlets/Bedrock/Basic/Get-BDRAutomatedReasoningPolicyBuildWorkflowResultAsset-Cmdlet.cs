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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Retrieves the resulting assets from a completed Automated Reasoning policy build workflow,
    /// including build logs, quality reports, and generated policy artifacts.
    /// </summary>
    [Cmdlet("Get", "BDRAutomatedReasoningPolicyBuildWorkflowResultAsset")]
    [OutputType("Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock GetAutomatedReasoningPolicyBuildWorkflowResultAssets API operation.", Operation = new[] {"GetAutomatedReasoningPolicyBuildWorkflowResultAssets"}, SelectReturnType = typeof(Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsResponse object containing multiple properties."
    )]
    public partial class GetBDRAutomatedReasoningPolicyBuildWorkflowResultAssetCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssetType
        /// <summary>
        /// <para>
        /// <para>The type of asset to retrieve (e.g., BUILD_LOG, QUALITY_REPORT, POLICY_DEFINITION).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Bedrock.AutomatedReasoningPolicyBuildResultAssetType")]
        public Amazon.Bedrock.AutomatedReasoningPolicyBuildResultAssetType AssetType { get; set; }
        #endregion
        
        #region Parameter BuildWorkflowId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the build workflow whose result assets you want to retrieve.</para>
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
        public System.String BuildWorkflowId { get; set; }
        #endregion
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Automated Reasoning policy whose build workflow
        /// assets you want to retrieve.</para>
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
        public System.String PolicyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsResponse, GetBDRAutomatedReasoningPolicyBuildWorkflowResultAssetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssetType = this.AssetType;
            #if MODULAR
            if (this.AssetType == null && ParameterWasBound(nameof(this.AssetType)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BuildWorkflowId = this.BuildWorkflowId;
            #if MODULAR
            if (this.BuildWorkflowId == null && ParameterWasBound(nameof(this.BuildWorkflowId)))
            {
                WriteWarning("You are passing $null as a value for parameter BuildWorkflowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyArn = this.PolicyArn;
            #if MODULAR
            if (this.PolicyArn == null && ParameterWasBound(nameof(this.PolicyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsRequest();
            
            if (cmdletContext.AssetType != null)
            {
                request.AssetType = cmdletContext.AssetType;
            }
            if (cmdletContext.BuildWorkflowId != null)
            {
                request.BuildWorkflowId = cmdletContext.BuildWorkflowId;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
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
        
        private Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "GetAutomatedReasoningPolicyBuildWorkflowResultAssets");
            try
            {
                #if DESKTOP
                return client.GetAutomatedReasoningPolicyBuildWorkflowResultAssets(request);
                #elif CORECLR
                return client.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Bedrock.AutomatedReasoningPolicyBuildResultAssetType AssetType { get; set; }
            public System.String BuildWorkflowId { get; set; }
            public System.String PolicyArn { get; set; }
            public System.Func<Amazon.Bedrock.Model.GetAutomatedReasoningPolicyBuildWorkflowResultAssetsResponse, GetBDRAutomatedReasoningPolicyBuildWorkflowResultAssetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
