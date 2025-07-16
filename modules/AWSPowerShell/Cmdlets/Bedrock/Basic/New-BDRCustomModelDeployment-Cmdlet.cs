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
    /// Deploys a custom model for on-demand inference in Amazon Bedrock. After you deploy
    /// your custom model, you use the deployment's Amazon Resource Name (ARN) as the <c>modelId</c>
    /// parameter when you submit prompts and generate responses with model inference.
    /// 
    ///  
    /// <para>
    ///  For more information about setting up on-demand inference for custom models, see
    /// <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-use.html">Set
    /// up inference for a custom model</a>. 
    /// </para><para>
    /// The following actions are related to the <c>CreateCustomModelDeployment</c> operation:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_GetCustomModelDeployment.html">GetCustomModelDeployment</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_ListCustomModelDeployments.html">ListCustomModelDeployments</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_DeleteCustomModelDeployment.html">DeleteCustomModelDeployment</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "BDRCustomModelDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateCustomModelDeployment API operation.", Operation = new[] {"CreateCustomModelDeployment"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateCustomModelDeploymentResponse))]
    [AWSCmdletOutput("System.String or Amazon.Bedrock.Model.CreateCustomModelDeploymentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Bedrock.Model.CreateCustomModelDeploymentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBDRCustomModelDeploymentCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the custom model deployment to help you identify its purpose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the custom model to deploy for on-demand inference.
        /// The custom model must be in the <c>Active</c> state.</para>
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
        public System.String ModelArn { get; set; }
        #endregion
        
        #region Parameter ModelDeploymentName
        /// <summary>
        /// <para>
        /// <para>The name for the custom model deployment. The name must be unique within your Amazon
        /// Web Services account and Region.</para>
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
        public System.String ModelDeploymentName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the custom model deployment. You can use tags to organize and track
        /// your Amazon Web Services resources for cost allocation and management purposes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Bedrock.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomModelDeploymentArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateCustomModelDeploymentResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateCustomModelDeploymentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomModelDeploymentArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelDeploymentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRCustomModelDeployment (CreateCustomModelDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateCustomModelDeploymentResponse, NewBDRCustomModelDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            context.ModelArn = this.ModelArn;
            #if MODULAR
            if (this.ModelArn == null && ParameterWasBound(nameof(this.ModelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelDeploymentName = this.ModelDeploymentName;
            #if MODULAR
            if (this.ModelDeploymentName == null && ParameterWasBound(nameof(this.ModelDeploymentName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelDeploymentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Bedrock.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.Bedrock.Model.CreateCustomModelDeploymentRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ModelArn != null)
            {
                request.ModelArn = cmdletContext.ModelArn;
            }
            if (cmdletContext.ModelDeploymentName != null)
            {
                request.ModelDeploymentName = cmdletContext.ModelDeploymentName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Bedrock.Model.CreateCustomModelDeploymentResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateCustomModelDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateCustomModelDeployment");
            try
            {
                return client.CreateCustomModelDeploymentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public System.String ModelArn { get; set; }
            public System.String ModelDeploymentName { get; set; }
            public List<Amazon.Bedrock.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateCustomModelDeploymentResponse, NewBDRCustomModelDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomModelDeploymentArn;
        }
        
    }
}
