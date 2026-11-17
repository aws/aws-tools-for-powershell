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
    /// Creates a function. A function analyzes a feed by building a request from the feed's
    /// media and metadata, optionally sending that request to an Amazon Bedrock model in
    /// your account, and publishing the result to the feed's metadata timeline. 
    /// 
    ///  
    /// <para>
    /// A function runs only after you attach it to a feed as a function output. For more
    /// information, see <a href="https://docs.aws.amazon.com/elemental-inference/latest/userguide/functions.html">Using
    /// functions</a> in the <i>AWS Elemental Inference User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "EMIFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElementalInference.Model.CreateFunctionResponse")]
    [AWSCmdlet("Calls the AWS Elemental Inference CreateFunction API operation.", Operation = new[] {"CreateFunction"}, SelectReturnType = typeof(Amazon.ElementalInference.Model.CreateFunctionResponse))]
    [AWSCmdletOutput("Amazon.ElementalInference.Model.CreateFunctionResponse",
        "This cmdlet returns an Amazon.ElementalInference.Model.CreateFunctionResponse object containing multiple properties."
    )]
    public partial class NewEMIFunctionCmdlet : AmazonElementalInferenceClientCmdlet, IExecutor
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
        /// <para>The description of the function. Maximum length: 1,024 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventBridgeDelivery
        /// <summary>
        /// <para>
        /// <para>Specifies whether Elemental Inference also sends this function's results to Amazon
        /// EventBridge. Elemental Inference sends a result only when the result is a JSON object
        /// with a top-level <c>eventBridge</c> field set to <c>true</c>. It sends the result,
        /// unchanged, as a Function Metadata Generated event to the default event bus in your
        /// account, after the result is available from GetMetadata. If the result is larger than
        /// 64 KB, the event has <c>resultOmitted</c> set to <c>true</c> in place of the result.
        /// </para><para>Valid values:</para><ul><li><para>ENABLED – Elemental Inference sends each marked result as an event.</para></li><li><para>DISABLED (default) – Elemental Inference doesn't send events.</para></li></ul><para>For a Bedrock target, ENABLED requires a response expression, because the model response
        /// itself never has a top-level <c>eventBridge</c> field. A feed output that runs a function
        /// with ENABLED can't use a fixedInterval trigger shorter than 4 seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElementalInference.EventBridgeDeliveryMode")]
        public Amazon.ElementalInference.EventBridgeDeliveryMode EventBridgeDelivery { get; set; }
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
        /// <para>A name for this function.</para>
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
        /// <para>The JSONata expression that builds the request. Elemental Inference evaluates it against
        /// the media object of the feed, which holds the media and metadata that the function
        /// asked for. Maximum length: 5,120 characters. </para><para>When you save the function, Elemental Inference evaluates the expression against sample
        /// media and rejects it if the evaluation fails. For a Bedrock target, the result must
        /// be a JSON object; Elemental Inference doesn't check that the object is a valid request
        /// body for the model. The expression can reference at most one of media.transcript,
        /// media.contextual, and media.clip. For a passthrough target, it can't reference media.frames.
        /// </para>
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
        public System.String RequestExpression { get; set; }
        #endregion
        
        #region Parameter ResponseExpression
        /// <summary>
        /// <para>
        /// <para>The JSONata expression that selects what to store. Elemental Inference evaluates it
        /// against the result as its root: the model response for a Bedrock target, or the output
        /// of the request expression for a passthrough target. If a function has no response
        /// expression, Elemental Inference stores the entire result. Maximum length: 5,120 characters.
        /// </para><para>When you save the function, Elemental Inference checks that the expression is valid
        /// JSONata. For a passthrough target, it also evaluates the request and response expressions
        /// together against sample media, and rejects them if they produce no value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResponseExpression { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with this function.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElementalInference.Model.CreateFunctionResponse).
        /// Specifying the name of a property of type Amazon.ElementalInference.Model.CreateFunctionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMIFunction (CreateFunction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElementalInference.Model.CreateFunctionResponse, NewEMIFunctionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.EventBridgeDelivery = this.EventBridgeDelivery;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RequestExpression = this.RequestExpression;
            #if MODULAR
            if (this.RequestExpression == null && ParameterWasBound(nameof(this.RequestExpression)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestExpression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResponseExpression = this.ResponseExpression;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.ElementalInference.Model.CreateFunctionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventBridgeDelivery != null)
            {
                request.EventBridgeDelivery = cmdletContext.EventBridgeDelivery;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ElementalInference.Model.CreateFunctionResponse CallAWSServiceOperation(IAmazonElementalInference client, Amazon.ElementalInference.Model.CreateFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental Inference", "CreateFunction");
            try
            {
                return client.CreateFunctionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String RequestExpression { get; set; }
            public System.String ResponseExpression { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.ElementalInference.BedrockApi Target_Bedrock_Api { get; set; }
            public System.String Target_Bedrock_Model { get; set; }
            public Amazon.ElementalInference.Model.PassthroughFunctionTarget Target_Passthrough { get; set; }
            public System.Func<Amazon.ElementalInference.Model.CreateFunctionResponse, NewEMIFunctionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
