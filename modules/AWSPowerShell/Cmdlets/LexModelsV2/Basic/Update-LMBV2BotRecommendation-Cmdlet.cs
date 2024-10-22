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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// Updates an existing bot recommendation request.
    /// </summary>
    [Cmdlet("Update", "LMBV2BotRecommendation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.UpdateBotRecommendationResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 UpdateBotRecommendation API operation.", Operation = new[] {"UpdateBotRecommendation"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.UpdateBotRecommendationResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.UpdateBotRecommendationResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.UpdateBotRecommendationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMBV2BotRecommendationCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EncryptionSetting_AssociatedTranscriptsPassword
        /// <summary>
        /// <para>
        /// <para>The password used to encrypt the associated transcript file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSetting_AssociatedTranscriptsPassword { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the bot containing the bot recommendation to be updated.</para>
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
        public System.String BotId { get; set; }
        #endregion
        
        #region Parameter EncryptionSetting_BotLocaleExportPassword
        /// <summary>
        /// <para>
        /// <para>The password used to encrypt the recommended bot recommendation file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSetting_BotLocaleExportPassword { get; set; }
        #endregion
        
        #region Parameter BotRecommendationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the bot recommendation to be updated.</para>
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
        public System.String BotRecommendationId { get; set; }
        #endregion
        
        #region Parameter BotVersion
        /// <summary>
        /// <para>
        /// <para>The version of the bot containing the bot recommendation to be updated.</para>
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
        public System.String BotVersion { get; set; }
        #endregion
        
        #region Parameter EncryptionSetting_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN used to encrypt the metadata associated with the bot recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSetting_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the language and locale of the bot recommendation to update. The
        /// string must match one of the supported locales. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
        /// languages</a></para>
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
        public System.String LocaleId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.UpdateBotRecommendationResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.UpdateBotRecommendationResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BotRecommendationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMBV2BotRecommendation (UpdateBotRecommendation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.UpdateBotRecommendationResponse, UpdateLMBV2BotRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotRecommendationId = this.BotRecommendationId;
            #if MODULAR
            if (this.BotRecommendationId == null && ParameterWasBound(nameof(this.BotRecommendationId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotRecommendationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotVersion = this.BotVersion;
            #if MODULAR
            if (this.BotVersion == null && ParameterWasBound(nameof(this.BotVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter BotVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionSetting_AssociatedTranscriptsPassword = this.EncryptionSetting_AssociatedTranscriptsPassword;
            context.EncryptionSetting_BotLocaleExportPassword = this.EncryptionSetting_BotLocaleExportPassword;
            context.EncryptionSetting_KmsKeyArn = this.EncryptionSetting_KmsKeyArn;
            context.LocaleId = this.LocaleId;
            #if MODULAR
            if (this.LocaleId == null && ParameterWasBound(nameof(this.LocaleId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocaleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LexModelsV2.Model.UpdateBotRecommendationRequest();
            
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.BotRecommendationId != null)
            {
                request.BotRecommendationId = cmdletContext.BotRecommendationId;
            }
            if (cmdletContext.BotVersion != null)
            {
                request.BotVersion = cmdletContext.BotVersion;
            }
            
             // populate EncryptionSetting
            var requestEncryptionSettingIsNull = true;
            request.EncryptionSetting = new Amazon.LexModelsV2.Model.EncryptionSetting();
            System.String requestEncryptionSetting_encryptionSetting_AssociatedTranscriptsPassword = null;
            if (cmdletContext.EncryptionSetting_AssociatedTranscriptsPassword != null)
            {
                requestEncryptionSetting_encryptionSetting_AssociatedTranscriptsPassword = cmdletContext.EncryptionSetting_AssociatedTranscriptsPassword;
            }
            if (requestEncryptionSetting_encryptionSetting_AssociatedTranscriptsPassword != null)
            {
                request.EncryptionSetting.AssociatedTranscriptsPassword = requestEncryptionSetting_encryptionSetting_AssociatedTranscriptsPassword;
                requestEncryptionSettingIsNull = false;
            }
            System.String requestEncryptionSetting_encryptionSetting_BotLocaleExportPassword = null;
            if (cmdletContext.EncryptionSetting_BotLocaleExportPassword != null)
            {
                requestEncryptionSetting_encryptionSetting_BotLocaleExportPassword = cmdletContext.EncryptionSetting_BotLocaleExportPassword;
            }
            if (requestEncryptionSetting_encryptionSetting_BotLocaleExportPassword != null)
            {
                request.EncryptionSetting.BotLocaleExportPassword = requestEncryptionSetting_encryptionSetting_BotLocaleExportPassword;
                requestEncryptionSettingIsNull = false;
            }
            System.String requestEncryptionSetting_encryptionSetting_KmsKeyArn = null;
            if (cmdletContext.EncryptionSetting_KmsKeyArn != null)
            {
                requestEncryptionSetting_encryptionSetting_KmsKeyArn = cmdletContext.EncryptionSetting_KmsKeyArn;
            }
            if (requestEncryptionSetting_encryptionSetting_KmsKeyArn != null)
            {
                request.EncryptionSetting.KmsKeyArn = requestEncryptionSetting_encryptionSetting_KmsKeyArn;
                requestEncryptionSettingIsNull = false;
            }
             // determine if request.EncryptionSetting should be set to null
            if (requestEncryptionSettingIsNull)
            {
                request.EncryptionSetting = null;
            }
            if (cmdletContext.LocaleId != null)
            {
                request.LocaleId = cmdletContext.LocaleId;
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
        
        private Amazon.LexModelsV2.Model.UpdateBotRecommendationResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.UpdateBotRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "UpdateBotRecommendation");
            try
            {
                #if DESKTOP
                return client.UpdateBotRecommendation(request);
                #elif CORECLR
                return client.UpdateBotRecommendationAsync(request).GetAwaiter().GetResult();
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
            public System.String BotId { get; set; }
            public System.String BotRecommendationId { get; set; }
            public System.String BotVersion { get; set; }
            public System.String EncryptionSetting_AssociatedTranscriptsPassword { get; set; }
            public System.String EncryptionSetting_BotLocaleExportPassword { get; set; }
            public System.String EncryptionSetting_KmsKeyArn { get; set; }
            public System.String LocaleId { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.UpdateBotRecommendationResponse, UpdateLMBV2BotRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
