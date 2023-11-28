/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// RetrieveAndGenerate API
    /// </summary>
    [Cmdlet("Invoke", "BARRetrieveAndGenerate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime RetrieveAndGenerate API operation.", Operation = new[] {"RetrieveAndGenerate"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeBARRetrieveAndGenerateCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SessionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The KMS key arn to encrypt the customer data of the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseConfiguration_KnowledgeBaseId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_KnowledgeBaseId")]
        public System.String KnowledgeBaseConfiguration_KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseConfiguration_ModelArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_ModelArn")]
        public System.String KnowledgeBaseConfiguration_ModelArn { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Input_Text
        /// <summary>
        /// <para>
        /// <para>Customer input of the turn in text</para>
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
        public System.String Input_Text { get; set; }
        #endregion
        
        #region Parameter RetrieveAndGenerateConfiguration_Type
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.RetrieveAndGenerateType")]
        public Amazon.BedrockAgentRuntime.RetrieveAndGenerateType RetrieveAndGenerateConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Input_Text parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Input_Text' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Input_Text' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BARRetrieveAndGenerate (RetrieveAndGenerate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse, InvokeBARRetrieveAndGenerateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Input_Text;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Input_Text = this.Input_Text;
            #if MODULAR
            if (this.Input_Text == null && ParameterWasBound(nameof(this.Input_Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Input_Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KnowledgeBaseConfiguration_KnowledgeBaseId = this.KnowledgeBaseConfiguration_KnowledgeBaseId;
            context.KnowledgeBaseConfiguration_ModelArn = this.KnowledgeBaseConfiguration_ModelArn;
            context.RetrieveAndGenerateConfiguration_Type = this.RetrieveAndGenerateConfiguration_Type;
            context.SessionConfiguration_KmsKeyArn = this.SessionConfiguration_KmsKeyArn;
            context.SessionId = this.SessionId;
            
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
            var request = new Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateRequest();
            
            
             // populate Input
            var requestInputIsNull = true;
            request.Input = new Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateInput();
            System.String requestInput_input_Text = null;
            if (cmdletContext.Input_Text != null)
            {
                requestInput_input_Text = cmdletContext.Input_Text;
            }
            if (requestInput_input_Text != null)
            {
                request.Input.Text = requestInput_input_Text;
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
            }
            
             // populate RetrieveAndGenerateConfiguration
            var requestRetrieveAndGenerateConfigurationIsNull = true;
            request.RetrieveAndGenerateConfiguration = new Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateConfiguration();
            Amazon.BedrockAgentRuntime.RetrieveAndGenerateType requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_Type = null;
            if (cmdletContext.RetrieveAndGenerateConfiguration_Type != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_Type = cmdletContext.RetrieveAndGenerateConfiguration_Type;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_Type != null)
            {
                request.RetrieveAndGenerateConfiguration.Type = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_Type;
                requestRetrieveAndGenerateConfigurationIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.KnowledgeBaseRetrieveAndGenerateConfiguration requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration = null;
            
             // populate KnowledgeBaseConfiguration
            var requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfigurationIsNull = true;
            requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration = new Amazon.BedrockAgentRuntime.Model.KnowledgeBaseRetrieveAndGenerateConfiguration();
            System.String requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseId = null;
            if (cmdletContext.KnowledgeBaseConfiguration_KnowledgeBaseId != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseId = cmdletContext.KnowledgeBaseConfiguration_KnowledgeBaseId;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseId != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration.KnowledgeBaseId = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_KnowledgeBaseId;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfigurationIsNull = false;
            }
            System.String requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_ModelArn = null;
            if (cmdletContext.KnowledgeBaseConfiguration_ModelArn != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_ModelArn = cmdletContext.KnowledgeBaseConfiguration_ModelArn;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_ModelArn != null)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration.ModelArn = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_knowledgeBaseConfiguration_ModelArn;
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfigurationIsNull = false;
            }
             // determine if requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration should be set to null
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfigurationIsNull)
            {
                requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration = null;
            }
            if (requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration != null)
            {
                request.RetrieveAndGenerateConfiguration.KnowledgeBaseConfiguration = requestRetrieveAndGenerateConfiguration_retrieveAndGenerateConfiguration_KnowledgeBaseConfiguration;
                requestRetrieveAndGenerateConfigurationIsNull = false;
            }
             // determine if request.RetrieveAndGenerateConfiguration should be set to null
            if (requestRetrieveAndGenerateConfigurationIsNull)
            {
                request.RetrieveAndGenerateConfiguration = null;
            }
            
             // populate SessionConfiguration
            var requestSessionConfigurationIsNull = true;
            request.SessionConfiguration = new Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateSessionConfiguration();
            System.String requestSessionConfiguration_sessionConfiguration_KmsKeyArn = null;
            if (cmdletContext.SessionConfiguration_KmsKeyArn != null)
            {
                requestSessionConfiguration_sessionConfiguration_KmsKeyArn = cmdletContext.SessionConfiguration_KmsKeyArn;
            }
            if (requestSessionConfiguration_sessionConfiguration_KmsKeyArn != null)
            {
                request.SessionConfiguration.KmsKeyArn = requestSessionConfiguration_sessionConfiguration_KmsKeyArn;
                requestSessionConfigurationIsNull = false;
            }
             // determine if request.SessionConfiguration should be set to null
            if (requestSessionConfigurationIsNull)
            {
                request.SessionConfiguration = null;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
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
        
        private Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "RetrieveAndGenerate");
            try
            {
                #if DESKTOP
                return client.RetrieveAndGenerate(request);
                #elif CORECLR
                return client.RetrieveAndGenerateAsync(request).GetAwaiter().GetResult();
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
            public System.String Input_Text { get; set; }
            public System.String KnowledgeBaseConfiguration_KnowledgeBaseId { get; set; }
            public System.String KnowledgeBaseConfiguration_ModelArn { get; set; }
            public Amazon.BedrockAgentRuntime.RetrieveAndGenerateType RetrieveAndGenerateConfiguration_Type { get; set; }
            public System.String SessionConfiguration_KmsKeyArn { get; set; }
            public System.String SessionId { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.RetrieveAndGenerateResponse, InvokeBARRetrieveAndGenerateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
