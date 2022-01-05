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
    /// Creates a custom slot type
    /// 
    ///  
    /// <para>
    ///  To create a custom slot type, specify a name for the slot type and a set of enumeration
    /// values, the values that a slot of this type can assume. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "LMBV2SlotType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.CreateSlotTypeResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 CreateSlotType API operation.", Operation = new[] {"CreateSlotType"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.CreateSlotTypeResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.CreateSlotTypeResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.CreateSlotTypeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLMBV2SlotTypeCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter AdvancedRecognitionSetting_AudioRecognitionStrategy
        /// <summary>
        /// <para>
        /// <para>Enables using the slot values as a custom vocabulary for recognizing user utterances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueSelectionSetting_AdvancedRecognitionSetting_AudioRecognitionStrategy")]
        [AWSConstantClassSource("Amazon.LexModelsV2.AudioRecognitionStrategy")]
        public Amazon.LexModelsV2.AudioRecognitionStrategy AdvancedRecognitionSetting_AudioRecognitionStrategy { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot associated with this slot type.</para>
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
        
        #region Parameter BotVersion
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot version associated with this slot type.</para>
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the slot type. Use the description to help identify the slot type
        /// in lists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Source_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon KMS key required to decrypt the contents of the grammar, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExternalSourceSetting_GrammarSlotTypeSetting_Source_KmsKeyArn")]
        public System.String Source_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the language and locale that the slot type will be used in. The
        /// string must match one of the supported locales. All of the bots, intents, and slots
        /// used by the slot type must have the same locale. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
        /// languages</a>.</para>
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
        
        #region Parameter ParentSlotTypeSignature
        /// <summary>
        /// <para>
        /// <para>The built-in slot type used as a parent of this slot type. When you define a parent
        /// slot type, the new slot type has the configuration of the parent slot type.</para><para>Only <code>AMAZON.AlphaNumeric</code> is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentSlotTypeSignature { get; set; }
        #endregion
        
        #region Parameter RegexFilter_Pattern
        /// <summary>
        /// <para>
        /// <para>A regular expression used to validate the value of a slot.</para><para> Use a standard regular expression. Amazon Lex supports the following characters in
        /// the regular expression: </para><ul><li><para>A-Z, a-z</para></li><li><para>0-9</para></li><li><para>Unicode characters ("\ u&lt;Unicode&gt;")</para></li></ul><para> Represent Unicode characters with four digits, for example "\u0041" or "\u005A".
        /// </para><para> The following regular expression operators are not supported: </para><ul><li><para>Infinite repeaters: *, +, or {x,} with no upper bound.</para></li><li><para>Wild card (.)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueSelectionSetting_RegexFilter_Pattern")]
        public System.String RegexFilter_Pattern { get; set; }
        #endregion
        
        #region Parameter ValueSelectionSetting_ResolutionStrategy
        /// <summary>
        /// <para>
        /// <para>Determines the slot resolution strategy that Amazon Lex uses to return slot type values.
        /// The field can be set to one of the following values:</para><ul><li><para>OriginalValue - Returns the value entered by the user, if the user value is similar
        /// to the slot value.</para></li><li><para>TopResolution - If there is a resolution list for the slot, return the first value
        /// in the resolution list as the slot type value. If there is no resolution list, null
        /// is returned.</para></li></ul><para>If you don't specify the valueSelectionStrategy, the default is OriginalValue. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.SlotValueResolutionStrategy")]
        public Amazon.LexModelsV2.SlotValueResolutionStrategy ValueSelectionSetting_ResolutionStrategy { get; set; }
        #endregion
        
        #region Parameter Source_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket that contains the grammar source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExternalSourceSetting_GrammarSlotTypeSetting_Source_S3BucketName")]
        public System.String Source_S3BucketName { get; set; }
        #endregion
        
        #region Parameter Source_S3ObjectKey
        /// <summary>
        /// <para>
        /// <para>The path to the grammar in the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExternalSourceSetting_GrammarSlotTypeSetting_Source_S3ObjectKey")]
        public System.String Source_S3ObjectKey { get; set; }
        #endregion
        
        #region Parameter SlotTypeName
        /// <summary>
        /// <para>
        /// <para>The name for the slot. A slot type name must be unique within the account.</para>
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
        public System.String SlotTypeName { get; set; }
        #endregion
        
        #region Parameter SlotTypeValue
        /// <summary>
        /// <para>
        /// <para>A list of <code>SlotTypeValue</code> objects that defines the values that the slot
        /// type can take. Each value can have a list of synonyms, additional values that help
        /// train the machine learning model about the values that it resolves for a slot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SlotTypeValues")]
        public Amazon.LexModelsV2.Model.SlotTypeValue[] SlotTypeValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.CreateSlotTypeResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.CreateSlotTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SlotTypeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SlotTypeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SlotTypeName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SlotTypeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMBV2SlotType (CreateSlotType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.CreateSlotTypeResponse, NewLMBV2SlotTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SlotTypeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BotId = this.BotId;
            #if MODULAR
            if (this.BotId == null && ParameterWasBound(nameof(this.BotId)))
            {
                WriteWarning("You are passing $null as a value for parameter BotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotVersion = this.BotVersion;
            #if MODULAR
            if (this.BotVersion == null && ParameterWasBound(nameof(this.BotVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter BotVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Source_KmsKeyArn = this.Source_KmsKeyArn;
            context.Source_S3BucketName = this.Source_S3BucketName;
            context.Source_S3ObjectKey = this.Source_S3ObjectKey;
            context.LocaleId = this.LocaleId;
            #if MODULAR
            if (this.LocaleId == null && ParameterWasBound(nameof(this.LocaleId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocaleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParentSlotTypeSignature = this.ParentSlotTypeSignature;
            context.SlotTypeName = this.SlotTypeName;
            #if MODULAR
            if (this.SlotTypeName == null && ParameterWasBound(nameof(this.SlotTypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter SlotTypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SlotTypeValue != null)
            {
                context.SlotTypeValue = new List<Amazon.LexModelsV2.Model.SlotTypeValue>(this.SlotTypeValue);
            }
            context.AdvancedRecognitionSetting_AudioRecognitionStrategy = this.AdvancedRecognitionSetting_AudioRecognitionStrategy;
            context.RegexFilter_Pattern = this.RegexFilter_Pattern;
            context.ValueSelectionSetting_ResolutionStrategy = this.ValueSelectionSetting_ResolutionStrategy;
            
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
            var request = new Amazon.LexModelsV2.Model.CreateSlotTypeRequest();
            
            if (cmdletContext.BotId != null)
            {
                request.BotId = cmdletContext.BotId;
            }
            if (cmdletContext.BotVersion != null)
            {
                request.BotVersion = cmdletContext.BotVersion;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate ExternalSourceSetting
            var requestExternalSourceSettingIsNull = true;
            request.ExternalSourceSetting = new Amazon.LexModelsV2.Model.ExternalSourceSetting();
            Amazon.LexModelsV2.Model.GrammarSlotTypeSetting requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting = null;
            
             // populate GrammarSlotTypeSetting
            var requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSettingIsNull = true;
            requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting = new Amazon.LexModelsV2.Model.GrammarSlotTypeSetting();
            Amazon.LexModelsV2.Model.GrammarSlotTypeSource requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source = null;
            
             // populate Source
            var requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_SourceIsNull = true;
            requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source = new Amazon.LexModelsV2.Model.GrammarSlotTypeSource();
            System.String requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_KmsKeyArn = null;
            if (cmdletContext.Source_KmsKeyArn != null)
            {
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_KmsKeyArn = cmdletContext.Source_KmsKeyArn;
            }
            if (requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_KmsKeyArn != null)
            {
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source.KmsKeyArn = requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_KmsKeyArn;
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_SourceIsNull = false;
            }
            System.String requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_S3BucketName = null;
            if (cmdletContext.Source_S3BucketName != null)
            {
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_S3BucketName = cmdletContext.Source_S3BucketName;
            }
            if (requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_S3BucketName != null)
            {
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source.S3BucketName = requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_S3BucketName;
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_SourceIsNull = false;
            }
            System.String requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_S3ObjectKey = null;
            if (cmdletContext.Source_S3ObjectKey != null)
            {
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_S3ObjectKey = cmdletContext.Source_S3ObjectKey;
            }
            if (requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_S3ObjectKey != null)
            {
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source.S3ObjectKey = requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source_source_S3ObjectKey;
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_SourceIsNull = false;
            }
             // determine if requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source should be set to null
            if (requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_SourceIsNull)
            {
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source = null;
            }
            if (requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source != null)
            {
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting.Source = requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting_externalSourceSetting_GrammarSlotTypeSetting_Source;
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSettingIsNull = false;
            }
             // determine if requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting should be set to null
            if (requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSettingIsNull)
            {
                requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting = null;
            }
            if (requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting != null)
            {
                request.ExternalSourceSetting.GrammarSlotTypeSetting = requestExternalSourceSetting_externalSourceSetting_GrammarSlotTypeSetting;
                requestExternalSourceSettingIsNull = false;
            }
             // determine if request.ExternalSourceSetting should be set to null
            if (requestExternalSourceSettingIsNull)
            {
                request.ExternalSourceSetting = null;
            }
            if (cmdletContext.LocaleId != null)
            {
                request.LocaleId = cmdletContext.LocaleId;
            }
            if (cmdletContext.ParentSlotTypeSignature != null)
            {
                request.ParentSlotTypeSignature = cmdletContext.ParentSlotTypeSignature;
            }
            if (cmdletContext.SlotTypeName != null)
            {
                request.SlotTypeName = cmdletContext.SlotTypeName;
            }
            if (cmdletContext.SlotTypeValue != null)
            {
                request.SlotTypeValues = cmdletContext.SlotTypeValue;
            }
            
             // populate ValueSelectionSetting
            var requestValueSelectionSettingIsNull = true;
            request.ValueSelectionSetting = new Amazon.LexModelsV2.Model.SlotValueSelectionSetting();
            Amazon.LexModelsV2.SlotValueResolutionStrategy requestValueSelectionSetting_valueSelectionSetting_ResolutionStrategy = null;
            if (cmdletContext.ValueSelectionSetting_ResolutionStrategy != null)
            {
                requestValueSelectionSetting_valueSelectionSetting_ResolutionStrategy = cmdletContext.ValueSelectionSetting_ResolutionStrategy;
            }
            if (requestValueSelectionSetting_valueSelectionSetting_ResolutionStrategy != null)
            {
                request.ValueSelectionSetting.ResolutionStrategy = requestValueSelectionSetting_valueSelectionSetting_ResolutionStrategy;
                requestValueSelectionSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.AdvancedRecognitionSetting requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting = null;
            
             // populate AdvancedRecognitionSetting
            var requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSettingIsNull = true;
            requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting = new Amazon.LexModelsV2.Model.AdvancedRecognitionSetting();
            Amazon.LexModelsV2.AudioRecognitionStrategy requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting_advancedRecognitionSetting_AudioRecognitionStrategy = null;
            if (cmdletContext.AdvancedRecognitionSetting_AudioRecognitionStrategy != null)
            {
                requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting_advancedRecognitionSetting_AudioRecognitionStrategy = cmdletContext.AdvancedRecognitionSetting_AudioRecognitionStrategy;
            }
            if (requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting_advancedRecognitionSetting_AudioRecognitionStrategy != null)
            {
                requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting.AudioRecognitionStrategy = requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting_advancedRecognitionSetting_AudioRecognitionStrategy;
                requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSettingIsNull = false;
            }
             // determine if requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting should be set to null
            if (requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSettingIsNull)
            {
                requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting = null;
            }
            if (requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting != null)
            {
                request.ValueSelectionSetting.AdvancedRecognitionSetting = requestValueSelectionSetting_valueSelectionSetting_AdvancedRecognitionSetting;
                requestValueSelectionSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.SlotValueRegexFilter requestValueSelectionSetting_valueSelectionSetting_RegexFilter = null;
            
             // populate RegexFilter
            var requestValueSelectionSetting_valueSelectionSetting_RegexFilterIsNull = true;
            requestValueSelectionSetting_valueSelectionSetting_RegexFilter = new Amazon.LexModelsV2.Model.SlotValueRegexFilter();
            System.String requestValueSelectionSetting_valueSelectionSetting_RegexFilter_regexFilter_Pattern = null;
            if (cmdletContext.RegexFilter_Pattern != null)
            {
                requestValueSelectionSetting_valueSelectionSetting_RegexFilter_regexFilter_Pattern = cmdletContext.RegexFilter_Pattern;
            }
            if (requestValueSelectionSetting_valueSelectionSetting_RegexFilter_regexFilter_Pattern != null)
            {
                requestValueSelectionSetting_valueSelectionSetting_RegexFilter.Pattern = requestValueSelectionSetting_valueSelectionSetting_RegexFilter_regexFilter_Pattern;
                requestValueSelectionSetting_valueSelectionSetting_RegexFilterIsNull = false;
            }
             // determine if requestValueSelectionSetting_valueSelectionSetting_RegexFilter should be set to null
            if (requestValueSelectionSetting_valueSelectionSetting_RegexFilterIsNull)
            {
                requestValueSelectionSetting_valueSelectionSetting_RegexFilter = null;
            }
            if (requestValueSelectionSetting_valueSelectionSetting_RegexFilter != null)
            {
                request.ValueSelectionSetting.RegexFilter = requestValueSelectionSetting_valueSelectionSetting_RegexFilter;
                requestValueSelectionSettingIsNull = false;
            }
             // determine if request.ValueSelectionSetting should be set to null
            if (requestValueSelectionSettingIsNull)
            {
                request.ValueSelectionSetting = null;
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
        
        private Amazon.LexModelsV2.Model.CreateSlotTypeResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.CreateSlotTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "CreateSlotType");
            try
            {
                #if DESKTOP
                return client.CreateSlotType(request);
                #elif CORECLR
                return client.CreateSlotTypeAsync(request).GetAwaiter().GetResult();
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
            public System.String BotVersion { get; set; }
            public System.String Description { get; set; }
            public System.String Source_KmsKeyArn { get; set; }
            public System.String Source_S3BucketName { get; set; }
            public System.String Source_S3ObjectKey { get; set; }
            public System.String LocaleId { get; set; }
            public System.String ParentSlotTypeSignature { get; set; }
            public System.String SlotTypeName { get; set; }
            public List<Amazon.LexModelsV2.Model.SlotTypeValue> SlotTypeValue { get; set; }
            public Amazon.LexModelsV2.AudioRecognitionStrategy AdvancedRecognitionSetting_AudioRecognitionStrategy { get; set; }
            public System.String RegexFilter_Pattern { get; set; }
            public Amazon.LexModelsV2.SlotValueResolutionStrategy ValueSelectionSetting_ResolutionStrategy { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.CreateSlotTypeResponse, NewLMBV2SlotTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
