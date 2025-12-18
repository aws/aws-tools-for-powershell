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
using Amazon.BedrockDataAutomation;
using Amazon.BedrockDataAutomation.Model;

namespace Amazon.PowerShell.Cmdlets.BDA
{
    /// <summary>
    /// Invoke an async job to perform Blueprint Optimization
    /// </summary>
    [Cmdlet("Invoke", "BDABlueprintOptimizationAsync", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Data Automation for Amazon Bedrock InvokeBlueprintOptimizationAsync API operation.", Operation = new[] {"InvokeBlueprintOptimizationAsync"}, SelectReturnType = typeof(Amazon.BedrockDataAutomation.Model.InvokeBlueprintOptimizationAsyncResponse))]
    [AWSCmdletOutput("System.String or Amazon.BedrockDataAutomation.Model.InvokeBlueprintOptimizationAsyncResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BedrockDataAutomation.Model.InvokeBlueprintOptimizationAsyncResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeBDABlueprintOptimizationAsyncCmdlet : AmazonBedrockDataAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Blueprint_BlueprintArn
        /// <summary>
        /// <para>
        /// <para>Arn of blueprint.</para>
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
        public System.String Blueprint_BlueprintArn { get; set; }
        #endregion
        
        #region Parameter DataAutomationProfileArn
        /// <summary>
        /// <para>
        /// <para>Data automation profile ARN</para>
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
        public System.String DataAutomationProfileArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsEncryptionContext
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionConfiguration_KmsEncryptionContext { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_S3Object_S3Uri
        /// <summary>
        /// <para>
        /// <para>S3 uri.</para>
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
        public System.String OutputConfiguration_S3Object_S3Uri { get; set; }
        #endregion
        
        #region Parameter Sample
        /// <summary>
        /// <para>
        /// <para>List of Blueprint Optimization Samples</para>
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
        [Alias("Samples")]
        public Amazon.BedrockDataAutomation.Model.BlueprintOptimizationSample[] Sample { get; set; }
        #endregion
        
        #region Parameter Blueprint_Stage
        /// <summary>
        /// <para>
        /// <para>Stage of blueprint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.BlueprintStage")]
        public Amazon.BedrockDataAutomation.BlueprintStage Blueprint_Stage { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>List of tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.BedrockDataAutomation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter OutputConfiguration_S3Object_Version
        /// <summary>
        /// <para>
        /// <para>S3 object version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfiguration_S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomation.Model.InvokeBlueprintOptimizationAsyncResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomation.Model.InvokeBlueprintOptimizationAsyncResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvocationArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DataAutomationProfileArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DataAutomationProfileArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DataAutomationProfileArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataAutomationProfileArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BDABlueprintOptimizationAsync (InvokeBlueprintOptimizationAsync)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomation.Model.InvokeBlueprintOptimizationAsyncResponse, InvokeBDABlueprintOptimizationAsyncCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DataAutomationProfileArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Blueprint_BlueprintArn = this.Blueprint_BlueprintArn;
            #if MODULAR
            if (this.Blueprint_BlueprintArn == null && ParameterWasBound(nameof(this.Blueprint_BlueprintArn)))
            {
                WriteWarning("You are passing $null as a value for parameter Blueprint_BlueprintArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Blueprint_Stage = this.Blueprint_Stage;
            context.DataAutomationProfileArn = this.DataAutomationProfileArn;
            #if MODULAR
            if (this.DataAutomationProfileArn == null && ParameterWasBound(nameof(this.DataAutomationProfileArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAutomationProfileArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EncryptionConfiguration_KmsEncryptionContext != null)
            {
                context.EncryptionConfiguration_KmsEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EncryptionConfiguration_KmsEncryptionContext.Keys)
                {
                    context.EncryptionConfiguration_KmsEncryptionContext.Add((String)hashKey, (System.String)(this.EncryptionConfiguration_KmsEncryptionContext[hashKey]));
                }
            }
            context.EncryptionConfiguration_KmsKeyId = this.EncryptionConfiguration_KmsKeyId;
            context.OutputConfiguration_S3Object_S3Uri = this.OutputConfiguration_S3Object_S3Uri;
            #if MODULAR
            if (this.OutputConfiguration_S3Object_S3Uri == null && ParameterWasBound(nameof(this.OutputConfiguration_S3Object_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfiguration_S3Object_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputConfiguration_S3Object_Version = this.OutputConfiguration_S3Object_Version;
            if (this.Sample != null)
            {
                context.Sample = new List<Amazon.BedrockDataAutomation.Model.BlueprintOptimizationSample>(this.Sample);
            }
            #if MODULAR
            if (this.Sample == null && ParameterWasBound(nameof(this.Sample)))
            {
                WriteWarning("You are passing $null as a value for parameter Sample which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.BedrockDataAutomation.Model.Tag>(this.Tag);
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
            var request = new Amazon.BedrockDataAutomation.Model.InvokeBlueprintOptimizationAsyncRequest();
            
            
             // populate Blueprint
            var requestBlueprintIsNull = true;
            request.Blueprint = new Amazon.BedrockDataAutomation.Model.BlueprintOptimizationObject();
            System.String requestBlueprint_blueprint_BlueprintArn = null;
            if (cmdletContext.Blueprint_BlueprintArn != null)
            {
                requestBlueprint_blueprint_BlueprintArn = cmdletContext.Blueprint_BlueprintArn;
            }
            if (requestBlueprint_blueprint_BlueprintArn != null)
            {
                request.Blueprint.BlueprintArn = requestBlueprint_blueprint_BlueprintArn;
                requestBlueprintIsNull = false;
            }
            Amazon.BedrockDataAutomation.BlueprintStage requestBlueprint_blueprint_Stage = null;
            if (cmdletContext.Blueprint_Stage != null)
            {
                requestBlueprint_blueprint_Stage = cmdletContext.Blueprint_Stage;
            }
            if (requestBlueprint_blueprint_Stage != null)
            {
                request.Blueprint.Stage = requestBlueprint_blueprint_Stage;
                requestBlueprintIsNull = false;
            }
             // determine if request.Blueprint should be set to null
            if (requestBlueprintIsNull)
            {
                request.Blueprint = null;
            }
            if (cmdletContext.DataAutomationProfileArn != null)
            {
                request.DataAutomationProfileArn = cmdletContext.DataAutomationProfileArn;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.BedrockDataAutomation.Model.EncryptionConfiguration();
            Dictionary<System.String, System.String> requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext = null;
            if (cmdletContext.EncryptionConfiguration_KmsEncryptionContext != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext = cmdletContext.EncryptionConfiguration_KmsEncryptionContext;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext != null)
            {
                request.EncryptionConfiguration.KmsEncryptionContext = requestEncryptionConfiguration_encryptionConfiguration_KmsEncryptionContext;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId = cmdletContext.EncryptionConfiguration_KmsKeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId != null)
            {
                request.EncryptionConfiguration.KmsKeyId = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyId;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            
             // populate OutputConfiguration
            var requestOutputConfigurationIsNull = true;
            request.OutputConfiguration = new Amazon.BedrockDataAutomation.Model.BlueprintOptimizationOutputConfiguration();
            Amazon.BedrockDataAutomation.Model.S3Object requestOutputConfiguration_outputConfiguration_S3Object = null;
            
             // populate S3Object
            var requestOutputConfiguration_outputConfiguration_S3ObjectIsNull = true;
            requestOutputConfiguration_outputConfiguration_S3Object = new Amazon.BedrockDataAutomation.Model.S3Object();
            System.String requestOutputConfiguration_outputConfiguration_S3Object_outputConfiguration_S3Object_S3Uri = null;
            if (cmdletContext.OutputConfiguration_S3Object_S3Uri != null)
            {
                requestOutputConfiguration_outputConfiguration_S3Object_outputConfiguration_S3Object_S3Uri = cmdletContext.OutputConfiguration_S3Object_S3Uri;
            }
            if (requestOutputConfiguration_outputConfiguration_S3Object_outputConfiguration_S3Object_S3Uri != null)
            {
                requestOutputConfiguration_outputConfiguration_S3Object.S3Uri = requestOutputConfiguration_outputConfiguration_S3Object_outputConfiguration_S3Object_S3Uri;
                requestOutputConfiguration_outputConfiguration_S3ObjectIsNull = false;
            }
            System.String requestOutputConfiguration_outputConfiguration_S3Object_outputConfiguration_S3Object_Version = null;
            if (cmdletContext.OutputConfiguration_S3Object_Version != null)
            {
                requestOutputConfiguration_outputConfiguration_S3Object_outputConfiguration_S3Object_Version = cmdletContext.OutputConfiguration_S3Object_Version;
            }
            if (requestOutputConfiguration_outputConfiguration_S3Object_outputConfiguration_S3Object_Version != null)
            {
                requestOutputConfiguration_outputConfiguration_S3Object.Version = requestOutputConfiguration_outputConfiguration_S3Object_outputConfiguration_S3Object_Version;
                requestOutputConfiguration_outputConfiguration_S3ObjectIsNull = false;
            }
             // determine if requestOutputConfiguration_outputConfiguration_S3Object should be set to null
            if (requestOutputConfiguration_outputConfiguration_S3ObjectIsNull)
            {
                requestOutputConfiguration_outputConfiguration_S3Object = null;
            }
            if (requestOutputConfiguration_outputConfiguration_S3Object != null)
            {
                request.OutputConfiguration.S3Object = requestOutputConfiguration_outputConfiguration_S3Object;
                requestOutputConfigurationIsNull = false;
            }
             // determine if request.OutputConfiguration should be set to null
            if (requestOutputConfigurationIsNull)
            {
                request.OutputConfiguration = null;
            }
            if (cmdletContext.Sample != null)
            {
                request.Samples = cmdletContext.Sample;
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
        
        private Amazon.BedrockDataAutomation.Model.InvokeBlueprintOptimizationAsyncResponse CallAWSServiceOperation(IAmazonBedrockDataAutomation client, Amazon.BedrockDataAutomation.Model.InvokeBlueprintOptimizationAsyncRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Data Automation for Amazon Bedrock", "InvokeBlueprintOptimizationAsync");
            try
            {
                #if DESKTOP
                return client.InvokeBlueprintOptimizationAsync(request);
                #elif CORECLR
                return client.InvokeBlueprintOptimizationAsyncAsync(request).GetAwaiter().GetResult();
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
            public System.String Blueprint_BlueprintArn { get; set; }
            public Amazon.BedrockDataAutomation.BlueprintStage Blueprint_Stage { get; set; }
            public System.String DataAutomationProfileArn { get; set; }
            public Dictionary<System.String, System.String> EncryptionConfiguration_KmsEncryptionContext { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public System.String OutputConfiguration_S3Object_S3Uri { get; set; }
            public System.String OutputConfiguration_S3Object_Version { get; set; }
            public List<Amazon.BedrockDataAutomation.Model.BlueprintOptimizationSample> Sample { get; set; }
            public List<Amazon.BedrockDataAutomation.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.BedrockDataAutomation.Model.InvokeBlueprintOptimizationAsyncResponse, InvokeBDABlueprintOptimizationAsyncCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvocationArn;
        }
        
    }
}
