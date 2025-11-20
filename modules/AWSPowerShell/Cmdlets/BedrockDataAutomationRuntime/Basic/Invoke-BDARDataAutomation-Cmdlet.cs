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
using Amazon.BedrockDataAutomationRuntime;
using Amazon.BedrockDataAutomationRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDAR
{
    /// <summary>
    /// Sync API: Invoke data automation.
    /// </summary>
    [Cmdlet("Invoke", "BDARDataAutomation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationResponse")]
    [AWSCmdlet("Calls the Runtime for Amazon Bedrock Data Automation InvokeDataAutomation API operation.", Operation = new[] {"InvokeDataAutomation"}, SelectReturnType = typeof(Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationResponse))]
    [AWSCmdletOutput("Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationResponse",
        "This cmdlet returns an Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationResponse object containing multiple properties."
    )]
    public partial class InvokeBDARDataAutomationCmdlet : AmazonBedrockDataAutomationRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Blueprint
        /// <summary>
        /// <para>
        /// <para>Blueprint list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Blueprints")]
        public Amazon.BedrockDataAutomationRuntime.Model.Blueprint[] Blueprint { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_Byte
        /// <summary>
        /// <para>
        /// <para>Input data as bytes</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfiguration_Bytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] InputConfiguration_Byte { get; set; }
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
        
        #region Parameter DataAutomationConfiguration_DataAutomationProjectArn
        /// <summary>
        /// <para>
        /// <para>Data automation project arn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataAutomationConfiguration_DataAutomationProjectArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsEncryptionContext
        /// <summary>
        /// <para>
        /// <para>KMS encryption context.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionConfiguration_KmsEncryptionContext { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>Customer KMS key used for encryption</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter InputConfiguration_S3Uri
        /// <summary>
        /// <para>
        /// <para>S3 URI of the input data</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfiguration_S3Uri { get; set; }
        #endregion
        
        #region Parameter DataAutomationConfiguration_Stage
        /// <summary>
        /// <para>
        /// <para>Data automation stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomationRuntime.DataAutomationStage")]
        public Amazon.BedrockDataAutomationRuntime.DataAutomationStage DataAutomationConfiguration_Stage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataAutomationProfileArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BDARDataAutomation (InvokeDataAutomation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationResponse, InvokeBDARDataAutomationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Blueprint != null)
            {
                context.Blueprint = new List<Amazon.BedrockDataAutomationRuntime.Model.Blueprint>(this.Blueprint);
            }
            context.DataAutomationConfiguration_DataAutomationProjectArn = this.DataAutomationConfiguration_DataAutomationProjectArn;
            context.DataAutomationConfiguration_Stage = this.DataAutomationConfiguration_Stage;
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
            context.InputConfiguration_Byte = this.InputConfiguration_Byte;
            context.InputConfiguration_S3Uri = this.InputConfiguration_S3Uri;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _InputConfiguration_ByteStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationRequest();
                
                if (cmdletContext.Blueprint != null)
                {
                    request.Blueprints = cmdletContext.Blueprint;
                }
                
                 // populate DataAutomationConfiguration
                var requestDataAutomationConfigurationIsNull = true;
                request.DataAutomationConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.DataAutomationConfiguration();
                System.String requestDataAutomationConfiguration_dataAutomationConfiguration_DataAutomationProjectArn = null;
                if (cmdletContext.DataAutomationConfiguration_DataAutomationProjectArn != null)
                {
                    requestDataAutomationConfiguration_dataAutomationConfiguration_DataAutomationProjectArn = cmdletContext.DataAutomationConfiguration_DataAutomationProjectArn;
                }
                if (requestDataAutomationConfiguration_dataAutomationConfiguration_DataAutomationProjectArn != null)
                {
                    request.DataAutomationConfiguration.DataAutomationProjectArn = requestDataAutomationConfiguration_dataAutomationConfiguration_DataAutomationProjectArn;
                    requestDataAutomationConfigurationIsNull = false;
                }
                Amazon.BedrockDataAutomationRuntime.DataAutomationStage requestDataAutomationConfiguration_dataAutomationConfiguration_Stage = null;
                if (cmdletContext.DataAutomationConfiguration_Stage != null)
                {
                    requestDataAutomationConfiguration_dataAutomationConfiguration_Stage = cmdletContext.DataAutomationConfiguration_Stage;
                }
                if (requestDataAutomationConfiguration_dataAutomationConfiguration_Stage != null)
                {
                    request.DataAutomationConfiguration.Stage = requestDataAutomationConfiguration_dataAutomationConfiguration_Stage;
                    requestDataAutomationConfigurationIsNull = false;
                }
                 // determine if request.DataAutomationConfiguration should be set to null
                if (requestDataAutomationConfigurationIsNull)
                {
                    request.DataAutomationConfiguration = null;
                }
                if (cmdletContext.DataAutomationProfileArn != null)
                {
                    request.DataAutomationProfileArn = cmdletContext.DataAutomationProfileArn;
                }
                
                 // populate EncryptionConfiguration
                var requestEncryptionConfigurationIsNull = true;
                request.EncryptionConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.EncryptionConfiguration();
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
                
                 // populate InputConfiguration
                var requestInputConfigurationIsNull = true;
                request.InputConfiguration = new Amazon.BedrockDataAutomationRuntime.Model.SyncInputConfiguration();
                System.IO.MemoryStream requestInputConfiguration_inputConfiguration_Byte = null;
                if (cmdletContext.InputConfiguration_Byte != null)
                {
                    _InputConfiguration_ByteStream = new System.IO.MemoryStream(cmdletContext.InputConfiguration_Byte);
                    requestInputConfiguration_inputConfiguration_Byte = _InputConfiguration_ByteStream;
                }
                if (requestInputConfiguration_inputConfiguration_Byte != null)
                {
                    request.InputConfiguration.Bytes = requestInputConfiguration_inputConfiguration_Byte;
                    requestInputConfigurationIsNull = false;
                }
                System.String requestInputConfiguration_inputConfiguration_S3Uri = null;
                if (cmdletContext.InputConfiguration_S3Uri != null)
                {
                    requestInputConfiguration_inputConfiguration_S3Uri = cmdletContext.InputConfiguration_S3Uri;
                }
                if (requestInputConfiguration_inputConfiguration_S3Uri != null)
                {
                    request.InputConfiguration.S3Uri = requestInputConfiguration_inputConfiguration_S3Uri;
                    requestInputConfigurationIsNull = false;
                }
                 // determine if request.InputConfiguration should be set to null
                if (requestInputConfigurationIsNull)
                {
                    request.InputConfiguration = null;
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
            finally
            {
                if( _InputConfiguration_ByteStream != null)
                {
                    _InputConfiguration_ByteStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationResponse CallAWSServiceOperation(IAmazonBedrockDataAutomationRuntime client, Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Runtime for Amazon Bedrock Data Automation", "InvokeDataAutomation");
            try
            {
                return client.InvokeDataAutomationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.BedrockDataAutomationRuntime.Model.Blueprint> Blueprint { get; set; }
            public System.String DataAutomationConfiguration_DataAutomationProjectArn { get; set; }
            public Amazon.BedrockDataAutomationRuntime.DataAutomationStage DataAutomationConfiguration_Stage { get; set; }
            public System.String DataAutomationProfileArn { get; set; }
            public Dictionary<System.String, System.String> EncryptionConfiguration_KmsEncryptionContext { get; set; }
            public System.String EncryptionConfiguration_KmsKeyId { get; set; }
            public byte[] InputConfiguration_Byte { get; set; }
            public System.String InputConfiguration_S3Uri { get; set; }
            public System.Func<Amazon.BedrockDataAutomationRuntime.Model.InvokeDataAutomationResponse, InvokeBDARDataAutomationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
