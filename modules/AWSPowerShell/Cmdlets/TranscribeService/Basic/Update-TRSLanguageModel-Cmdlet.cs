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
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TRS
{
    /// <summary>
    /// Updates the encryption configuration for an existing custom language model. You can
    /// use this operation to change the KMS key used to encrypt your model artifacts. The
    /// model artifacts are re-encrypted in place. No model training is required.
    /// 
    ///  
    /// <para>
    /// Your custom language model must not be in the <c>IN_PROGRESS</c> state when you call
    /// this operation. You cannot submit another update while a previous update is in progress.
    /// Use to check the current state of your model.
    /// </para><para>
    /// Your custom language model remains available for transcription jobs while the update
    /// is being processed.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "TRSLanguageModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TranscribeService.Model.UpdateLanguageModelResponse")]
    [AWSCmdlet("Calls the Amazon Transcribe Service UpdateLanguageModel API operation.", Operation = new[] {"UpdateLanguageModel"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.UpdateLanguageModelResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.UpdateLanguageModelResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.UpdateLanguageModelResponse object containing multiple properties."
    )]
    public partial class UpdateTRSLanguageModelCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role. If you include <c>EncryptionConfiguration</c>
        /// in your request, this role must have permissions to access the specified KMS key.
        /// If the role that you specify doesn't have the appropriate permissions, your request
        /// fails.</para><para>IAM role ARNs have the format <c>arn:partition:iam::account:role/role-name-with-path</c>.
        /// For example: <c>arn:aws:iam::111122223333:role/Admin</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-arns">IAM
        /// ARNs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KMSEncryptionContext
        /// <summary>
        /// <para>
        /// <para>A map of plain text, non-secret key:value pairs, known as encryption context pairs,
        /// that provide an added layer of security for your data. For more information, see <a href="https://docs.aws.amazon.com/transcribe/latest/dg/key-management.html#kms-context">KMS
        /// encryption context</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionConfiguration_KMSEncryptionContext { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KMSKey
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key you want to use to encrypt your resource
        /// artifacts. Only full KMS key ARN format is supported.</para><para>KMS key ARNs have the format <c>arn:partition:kms:region:account:key/key-id</c>. For
        /// example: <c>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id-key-ARN">KMS
        /// key ARNs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KMSKey { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>The name of the custom language model you want to update. Model names are case sensitive.</para>
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
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.UpdateLanguageModelResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.UpdateLanguageModelResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TRSLanguageModel (UpdateLanguageModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.UpdateLanguageModelResponse, UpdateTRSLanguageModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            if (this.EncryptionConfiguration_KMSEncryptionContext != null)
            {
                context.EncryptionConfiguration_KMSEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EncryptionConfiguration_KMSEncryptionContext.Keys)
                {
                    context.EncryptionConfiguration_KMSEncryptionContext.Add((String)hashKey, (System.String)(this.EncryptionConfiguration_KMSEncryptionContext[hashKey]));
                }
            }
            context.EncryptionConfiguration_KMSKey = this.EncryptionConfiguration_KMSKey;
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TranscribeService.Model.UpdateLanguageModelRequest();
            
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.TranscribeService.Model.EncryptionConfiguration();
            Dictionary<System.String, System.String> requestEncryptionConfiguration_encryptionConfiguration_KMSEncryptionContext = null;
            if (cmdletContext.EncryptionConfiguration_KMSEncryptionContext != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KMSEncryptionContext = cmdletContext.EncryptionConfiguration_KMSEncryptionContext;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KMSEncryptionContext != null)
            {
                request.EncryptionConfiguration.KMSEncryptionContext = requestEncryptionConfiguration_encryptionConfiguration_KMSEncryptionContext;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KMSKey = null;
            if (cmdletContext.EncryptionConfiguration_KMSKey != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KMSKey = cmdletContext.EncryptionConfiguration_KMSKey;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KMSKey != null)
            {
                request.EncryptionConfiguration.KMSKey = requestEncryptionConfiguration_encryptionConfiguration_KMSKey;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
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
        
        private Amazon.TranscribeService.Model.UpdateLanguageModelResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.UpdateLanguageModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "UpdateLanguageModel");
            try
            {
                return client.UpdateLanguageModelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DataAccessRoleArn { get; set; }
            public Dictionary<System.String, System.String> EncryptionConfiguration_KMSEncryptionContext { get; set; }
            public System.String EncryptionConfiguration_KMSKey { get; set; }
            public System.String ModelName { get; set; }
            public System.Func<Amazon.TranscribeService.Model.UpdateLanguageModelResponse, UpdateTRSLanguageModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
