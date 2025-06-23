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
    /// Creates a prompt router that manages the routing of requests between multiple foundation
    /// models based on the routing criteria.
    /// </summary>
    [Cmdlet("New", "BDRPromptRouter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock CreatePromptRouter API operation.", Operation = new[] {"CreatePromptRouter"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreatePromptRouterResponse))]
    [AWSCmdletOutput("System.String or Amazon.Bedrock.Model.CreatePromptRouterResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Bedrock.Model.CreatePromptRouterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBDRPromptRouterCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure idempotency of your
        /// requests. If not specified, the Amazon Web Services SDK automatically generates one
        /// for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the prompt router to help identify its purpose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FallbackModel_ModelArn
        /// <summary>
        /// <para>
        /// <para>The target model's ARN.</para>
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
        public System.String FallbackModel_ModelArn { get; set; }
        #endregion
        
        #region Parameter Model
        /// <summary>
        /// <para>
        /// <para>A list of foundation models that the prompt router can route requests to. At least
        /// one model must be specified.</para><para />
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
        [Alias("Models")]
        public Amazon.Bedrock.Model.PromptRouterTargetModel[] Model { get; set; }
        #endregion
        
        #region Parameter PromptRouterName
        /// <summary>
        /// <para>
        /// <para>The name of the prompt router. The name must be unique within your Amazon Web Services
        /// account in the current region.</para>
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
        public System.String PromptRouterName { get; set; }
        #endregion
        
        #region Parameter RoutingCriteria_ResponseQualityDifference
        /// <summary>
        /// <para>
        /// <para>The criteria's response quality difference.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? RoutingCriteria_ResponseQualityDifference { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs to apply to this resource as tags. You can use tags to
        /// categorize and manage your Amazon Web Services resources.</para><para />
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PromptRouterArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreatePromptRouterResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreatePromptRouterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PromptRouterArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PromptRouterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRPromptRouter (CreatePromptRouter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreatePromptRouterResponse, NewBDRPromptRouterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            context.FallbackModel_ModelArn = this.FallbackModel_ModelArn;
            #if MODULAR
            if (this.FallbackModel_ModelArn == null && ParameterWasBound(nameof(this.FallbackModel_ModelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FallbackModel_ModelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Model != null)
            {
                context.Model = new List<Amazon.Bedrock.Model.PromptRouterTargetModel>(this.Model);
            }
            #if MODULAR
            if (this.Model == null && ParameterWasBound(nameof(this.Model)))
            {
                WriteWarning("You are passing $null as a value for parameter Model which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PromptRouterName = this.PromptRouterName;
            #if MODULAR
            if (this.PromptRouterName == null && ParameterWasBound(nameof(this.PromptRouterName)))
            {
                WriteWarning("You are passing $null as a value for parameter PromptRouterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoutingCriteria_ResponseQualityDifference = this.RoutingCriteria_ResponseQualityDifference;
            #if MODULAR
            if (this.RoutingCriteria_ResponseQualityDifference == null && ParameterWasBound(nameof(this.RoutingCriteria_ResponseQualityDifference)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingCriteria_ResponseQualityDifference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.CreatePromptRouterRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate FallbackModel
            var requestFallbackModelIsNull = true;
            request.FallbackModel = new Amazon.Bedrock.Model.PromptRouterTargetModel();
            System.String requestFallbackModel_fallbackModel_ModelArn = null;
            if (cmdletContext.FallbackModel_ModelArn != null)
            {
                requestFallbackModel_fallbackModel_ModelArn = cmdletContext.FallbackModel_ModelArn;
            }
            if (requestFallbackModel_fallbackModel_ModelArn != null)
            {
                request.FallbackModel.ModelArn = requestFallbackModel_fallbackModel_ModelArn;
                requestFallbackModelIsNull = false;
            }
             // determine if request.FallbackModel should be set to null
            if (requestFallbackModelIsNull)
            {
                request.FallbackModel = null;
            }
            if (cmdletContext.Model != null)
            {
                request.Models = cmdletContext.Model;
            }
            if (cmdletContext.PromptRouterName != null)
            {
                request.PromptRouterName = cmdletContext.PromptRouterName;
            }
            
             // populate RoutingCriteria
            var requestRoutingCriteriaIsNull = true;
            request.RoutingCriteria = new Amazon.Bedrock.Model.RoutingCriteria();
            System.Double? requestRoutingCriteria_routingCriteria_ResponseQualityDifference = null;
            if (cmdletContext.RoutingCriteria_ResponseQualityDifference != null)
            {
                requestRoutingCriteria_routingCriteria_ResponseQualityDifference = cmdletContext.RoutingCriteria_ResponseQualityDifference.Value;
            }
            if (requestRoutingCriteria_routingCriteria_ResponseQualityDifference != null)
            {
                request.RoutingCriteria.ResponseQualityDifference = requestRoutingCriteria_routingCriteria_ResponseQualityDifference.Value;
                requestRoutingCriteriaIsNull = false;
            }
             // determine if request.RoutingCriteria should be set to null
            if (requestRoutingCriteriaIsNull)
            {
                request.RoutingCriteria = null;
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
        
        private Amazon.Bedrock.Model.CreatePromptRouterResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreatePromptRouterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreatePromptRouter");
            try
            {
                return client.CreatePromptRouterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FallbackModel_ModelArn { get; set; }
            public List<Amazon.Bedrock.Model.PromptRouterTargetModel> Model { get; set; }
            public System.String PromptRouterName { get; set; }
            public System.Double? RoutingCriteria_ResponseQualityDifference { get; set; }
            public List<Amazon.Bedrock.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreatePromptRouterResponse, NewBDRPromptRouterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PromptRouterArn;
        }
        
    }
}
