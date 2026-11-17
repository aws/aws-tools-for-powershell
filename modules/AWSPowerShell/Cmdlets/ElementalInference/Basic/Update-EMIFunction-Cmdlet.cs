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
using Amazon.ElementalInference;
using Amazon.ElementalInference.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMI
{
    /// <summary>
    /// Updates a function. Include only the parameters that you want to change; parameters
    /// that you don't include aren't affected. Elemental Inference validates the updated
    /// expressions in the same way as CreateFunction. 
    /// 
    ///  
    /// <para>
    /// While a feed references the function, you can change only its expressions and its
    /// description, and you can set eventBridgeDelivery to DISABLED but not to ENABLED. The
    /// request expression must keep referencing the same media context, as reported in contextTypes.
    /// Changing an expression changes the behavior of every feed that references the function.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EMIFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElementalInference.Model.UpdateFunctionResponse")]
    [AWSCmdlet("Calls the AWS Elemental Inference UpdateFunction API operation.", Operation = new[] {"UpdateFunction"}, SelectReturnType = typeof(Amazon.ElementalInference.Model.UpdateFunctionResponse))]
    [AWSCmdletOutput("Amazon.ElementalInference.Model.UpdateFunctionResponse",
        "This cmdlet returns an Amazon.ElementalInference.Model.UpdateFunctionResponse object containing multiple properties."
    )]
    public partial class UpdateEMIFunctionCmdlet : AmazonElementalInferenceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Target_Bedrock_Api
        /// <summary>
        /// <para>
        /// <para>The Amazon Bedrock API to call. The only valid value is INVOKE_MODEL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElementalInference.BedrockApi")]
        public Amazon.ElementalInference.BedrockApi Target_Bedrock_Api { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventBridgeDelivery
        /// <summary>
        /// <para>
        /// <para>Specifies whether Elemental Inference also sends this function's marked results to
        /// Amazon EventBridge, as described for CreateFunction. If you omit this parameter, the
        /// current value is kept. While a feed references the function, you can change this value
        /// to DISABLED, but not to ENABLED. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElementalInference.EventBridgeDeliveryMode")]
        public Amazon.ElementalInference.EventBridgeDeliveryMode EventBridgeDelivery { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the function.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Target_Bedrock_Model
        /// <summary>
        /// <para>
        /// <para>The model to invoke. Specify one of the following:</para><ul><li><para>A model ID.</para></li><li><para>An inference profile ID.</para></li><li><para>The ARN of a custom model.</para></li><li><para>The ARN of a provisioned model.</para></li></ul><para>Elemental Inference invokes the model in the Region of the feed. To use a model in
        /// other Regions, specify a cross-Region inference profile ID. A custom or provisioned
        /// model must be in the Region of the feed. </para><para>The request expression must produce a request body that this model accepts, and the
        /// model must accept the kind of media that the request expression references. For example,
        /// a text-only model can't accept a request that references media.frames. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_Bedrock_Model { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A new name for the function. You can't change the name while the function is referenced
        /// by a feed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Target_Passthrough
        /// <summary>
        /// <para>
        /// <para>Send the request nowhere. Use this target to reshape the metadata that Elemental Inference
        /// already produces, with no model invocation and no model charges. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElementalInference.Model.PassthroughFunctionTarget Target_Passthrough { get; set; }
        #endregion
        
        #region Parameter RequestExpression
        /// <summary>
        /// <para>
        /// <para>A new request expression for the function. Elemental Inference derives contextTypes
        /// again from the new expression. While a feed references the function, the new expression
        /// must reference the same media context as the current one. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestExpression { get; set; }
        #endregion
        
        #region Parameter ResponseExpression
        /// <summary>
        /// <para>
        /// <para>A new response expression for the function. To remove the response expression, specify
        /// an empty string. A function with a Bedrock target and eventBridgeDelivery set to ENABLED
        /// must keep a response expression. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseExpression { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElementalInference.Model.UpdateFunctionResponse).
        /// Specifying the name of a property of type Amazon.ElementalInference.Model.UpdateFunctionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMIFunction (UpdateFunction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElementalInference.Model.UpdateFunctionResponse, UpdateEMIFunctionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.EventBridgeDelivery = this.EventBridgeDelivery;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.RequestExpression = this.RequestExpression;
            context.ResponseExpression = this.ResponseExpression;
            context.Target_Bedrock_Api = this.Target_Bedrock_Api;
            context.Target_Bedrock_Model = this.Target_Bedrock_Model;
            context.Target_Passthrough = this.Target_Passthrough;
            
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
            var request = new Amazon.ElementalInference.Model.UpdateFunctionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventBridgeDelivery != null)
            {
                request.EventBridgeDelivery = cmdletContext.EventBridgeDelivery;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RequestExpression != null)
            {
                request.RequestExpression = cmdletContext.RequestExpression;
            }
            if (cmdletContext.ResponseExpression != null)
            {
                request.ResponseExpression = cmdletContext.ResponseExpression;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.ElementalInference.Model.FunctionTarget();
            Amazon.ElementalInference.Model.PassthroughFunctionTarget requestTarget_target_Passthrough = null;
            if (cmdletContext.Target_Passthrough != null)
            {
                requestTarget_target_Passthrough = cmdletContext.Target_Passthrough;
            }
            if (requestTarget_target_Passthrough != null)
            {
                request.Target.Passthrough = requestTarget_target_Passthrough;
                requestTargetIsNull = false;
            }
            Amazon.ElementalInference.Model.BedrockFunctionTarget requestTarget_target_Bedrock = null;
            
             // populate Bedrock
            var requestTarget_target_BedrockIsNull = true;
            requestTarget_target_Bedrock = new Amazon.ElementalInference.Model.BedrockFunctionTarget();
            Amazon.ElementalInference.BedrockApi requestTarget_target_Bedrock_target_Bedrock_Api = null;
            if (cmdletContext.Target_Bedrock_Api != null)
            {
                requestTarget_target_Bedrock_target_Bedrock_Api = cmdletContext.Target_Bedrock_Api;
            }
            if (requestTarget_target_Bedrock_target_Bedrock_Api != null)
            {
                requestTarget_target_Bedrock.Api = requestTarget_target_Bedrock_target_Bedrock_Api;
                requestTarget_target_BedrockIsNull = false;
            }
            System.String requestTarget_target_Bedrock_target_Bedrock_Model = null;
            if (cmdletContext.Target_Bedrock_Model != null)
            {
                requestTarget_target_Bedrock_target_Bedrock_Model = cmdletContext.Target_Bedrock_Model;
            }
            if (requestTarget_target_Bedrock_target_Bedrock_Model != null)
            {
                requestTarget_target_Bedrock.Model = requestTarget_target_Bedrock_target_Bedrock_Model;
                requestTarget_target_BedrockIsNull = false;
            }
             // determine if requestTarget_target_Bedrock should be set to null
            if (requestTarget_target_BedrockIsNull)
            {
                requestTarget_target_Bedrock = null;
            }
            if (requestTarget_target_Bedrock != null)
            {
                request.Target.Bedrock = requestTarget_target_Bedrock;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
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
        
        private Amazon.ElementalInference.Model.UpdateFunctionResponse CallAWSServiceOperation(IAmazonElementalInference client, Amazon.ElementalInference.Model.UpdateFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental Inference", "UpdateFunction");
            try
            {
                return client.UpdateFunctionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.ElementalInference.EventBridgeDeliveryMode EventBridgeDelivery { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public System.String RequestExpression { get; set; }
            public System.String ResponseExpression { get; set; }
            public Amazon.ElementalInference.BedrockApi Target_Bedrock_Api { get; set; }
            public System.String Target_Bedrock_Model { get; set; }
            public Amazon.ElementalInference.Model.PassthroughFunctionTarget Target_Passthrough { get; set; }
            public System.Func<Amazon.ElementalInference.Model.UpdateFunctionResponse, UpdateEMIFunctionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
