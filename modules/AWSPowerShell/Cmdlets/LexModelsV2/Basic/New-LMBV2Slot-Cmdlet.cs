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
    /// Creates a slot in an intent. A slot is a variable needed to fulfill an intent. For
    /// example, an <code>OrderPizza</code> intent might need slots for size, crust, and number
    /// of pizzas. For each slot, you define one or more utterances that Amazon Lex uses to
    /// elicit a response from the user.
    /// </summary>
    [Cmdlet("New", "LMBV2Slot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.CreateSlotResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 CreateSlot API operation.", Operation = new[] {"CreateSlot"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.CreateSlotResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.CreateSlotResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.CreateSlotResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLMBV2SlotCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter WaitAndContinueSpecification_Active
        /// <summary>
        /// <para>
        /// <para>Specifies whether the bot will wait for a user to respond. When this field is false,
        /// wait and continue responses for a slot aren't used. If the <code>active</code> field
        /// isn't specified, the default is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_WaitAndContinueSpecification_Active")]
        public System.Boolean? WaitAndContinueSpecification_Active { get; set; }
        #endregion
        
        #region Parameter PromptSpecification_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech prompt from the bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_PromptSpecification_AllowInterrupt")]
        public System.Boolean? PromptSpecification_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter ContinueResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_WaitAndContinueSpecification_ContinueResponse_AllowInterrupt")]
        public System.Boolean? ContinueResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter StillWaitingResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates that the user can interrupt the response by speaking while the message is
        /// being played.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_AllowInterrupt")]
        public System.Boolean? StillWaitingResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter WaitingResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_WaitAndContinueSpecification_WaitingResponse_AllowInterrupt")]
        public System.Boolean? WaitingResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter MultipleValuesSetting_AllowMultipleValue
        /// <summary>
        /// <para>
        /// <para>Indicates whether a slot can return multiple values. When <code>true</code>, the slot
        /// may return more than one value in a response. When <code>false</code>, the slot returns
        /// only a single value.</para><para>Multi-value slots are only available in the en-US locale. If you set this value to
        /// <code>true</code> in any other locale, Amazon Lex throws a <code>ValidationException</code>.</para><para>If the <code>allowMutlipleValues</code> is not set, the default value is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultipleValuesSetting_AllowMultipleValues")]
        public System.Boolean? MultipleValuesSetting_AllowMultipleValue { get; set; }
        #endregion
        
        #region Parameter BotId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bot associated with the slot.</para>
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
        /// <para>The version of the bot associated with the slot.</para>
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
        
        #region Parameter DefaultValueSpecification_DefaultValueList
        /// <summary>
        /// <para>
        /// <para>A list of default values. Amazon Lex chooses the default value to use in the order
        /// that they are presented in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_DefaultValueSpecification_DefaultValueList")]
        public Amazon.LexModelsV2.Model.SlotDefaultValue[] DefaultValueSpecification_DefaultValueList { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the slot. Use this to help identify the slot in lists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter StillWaitingResponse_FrequencyInSecond
        /// <summary>
        /// <para>
        /// <para>How often a message should be sent to the user. Minimum of 1 second, maximum of 5
        /// minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_FrequencyInSeconds")]
        public System.Int32? StillWaitingResponse_FrequencyInSecond { get; set; }
        #endregion
        
        #region Parameter IntentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the intent that contains the slot.</para>
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
        public System.String IntentId { get; set; }
        #endregion
        
        #region Parameter LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the language and locale that the slot will be used in. The string
        /// must match one of the supported locales. All of the bots, intents, slot types used
        /// by the slot must have the same locale. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
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
        
        #region Parameter PromptSpecification_MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of times the bot tries to elicit a response from the user using
        /// this prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_PromptSpecification_MaxRetries")]
        public System.Int32? PromptSpecification_MaxRetry { get; set; }
        #endregion
        
        #region Parameter PromptSpecification_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of messages that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual message to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_PromptSpecification_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] PromptSpecification_MessageGroup { get; set; }
        #endregion
        
        #region Parameter ContinueResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_WaitAndContinueSpecification_ContinueResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] ContinueResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter StillWaitingResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>One or more message groups, each containing one or more messages, that define the
        /// prompts that Amazon Lex sends to the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] StillWaitingResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter WaitingResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_WaitAndContinueSpecification_WaitingResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] WaitingResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter ObfuscationSetting_ObfuscationSettingType
        /// <summary>
        /// <para>
        /// <para>Value that determines whether Amazon Lex obscures slot values in conversation logs.
        /// The default is to obscure the values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.ObfuscationSettingType")]
        public Amazon.LexModelsV2.ObfuscationSettingType ObfuscationSetting_ObfuscationSettingType { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SampleUtterance
        /// <summary>
        /// <para>
        /// <para>If you know a specific pattern that users might respond to an Amazon Lex request for
        /// a slot value, you can provide those utterances to improve accuracy. This is optional.
        /// In most cases, Amazon Lex is capable of understanding user utterances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SampleUtterances")]
        public Amazon.LexModelsV2.Model.SampleUtterance[] ValueElicitationSetting_SampleUtterance { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotConstraint
        /// <summary>
        /// <para>
        /// <para>Specifies whether the slot is required or optional.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LexModelsV2.SlotConstraint")]
        public Amazon.LexModelsV2.SlotConstraint ValueElicitationSetting_SlotConstraint { get; set; }
        #endregion
        
        #region Parameter SlotName
        /// <summary>
        /// <para>
        /// <para>The name of the slot. Slot names must be unique within the bot that contains the slot.</para>
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
        public System.String SlotName { get; set; }
        #endregion
        
        #region Parameter SlotTypeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the slot type associated with this slot. The slot type determines
        /// the values that can be entered into the slot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SlotTypeId { get; set; }
        #endregion
        
        #region Parameter StillWaitingResponse_TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>If Amazon Lex waits longer than this length of time for a response, it will stop sending
        /// messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_TimeoutInSeconds")]
        public System.Int32? StillWaitingResponse_TimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.CreateSlotResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.CreateSlotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SlotName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SlotName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SlotName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SlotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMBV2Slot (CreateSlot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.CreateSlotResponse, NewLMBV2SlotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SlotName;
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
            context.IntentId = this.IntentId;
            #if MODULAR
            if (this.IntentId == null && ParameterWasBound(nameof(this.IntentId)))
            {
                WriteWarning("You are passing $null as a value for parameter IntentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LocaleId = this.LocaleId;
            #if MODULAR
            if (this.LocaleId == null && ParameterWasBound(nameof(this.LocaleId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocaleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MultipleValuesSetting_AllowMultipleValue = this.MultipleValuesSetting_AllowMultipleValue;
            context.ObfuscationSetting_ObfuscationSettingType = this.ObfuscationSetting_ObfuscationSettingType;
            context.SlotName = this.SlotName;
            #if MODULAR
            if (this.SlotName == null && ParameterWasBound(nameof(this.SlotName)))
            {
                WriteWarning("You are passing $null as a value for parameter SlotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SlotTypeId = this.SlotTypeId;
            if (this.DefaultValueSpecification_DefaultValueList != null)
            {
                context.DefaultValueSpecification_DefaultValueList = new List<Amazon.LexModelsV2.Model.SlotDefaultValue>(this.DefaultValueSpecification_DefaultValueList);
            }
            context.PromptSpecification_AllowInterrupt = this.PromptSpecification_AllowInterrupt;
            context.PromptSpecification_MaxRetry = this.PromptSpecification_MaxRetry;
            if (this.PromptSpecification_MessageGroup != null)
            {
                context.PromptSpecification_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.PromptSpecification_MessageGroup);
            }
            if (this.ValueElicitationSetting_SampleUtterance != null)
            {
                context.ValueElicitationSetting_SampleUtterance = new List<Amazon.LexModelsV2.Model.SampleUtterance>(this.ValueElicitationSetting_SampleUtterance);
            }
            context.ValueElicitationSetting_SlotConstraint = this.ValueElicitationSetting_SlotConstraint;
            #if MODULAR
            if (this.ValueElicitationSetting_SlotConstraint == null && ParameterWasBound(nameof(this.ValueElicitationSetting_SlotConstraint)))
            {
                WriteWarning("You are passing $null as a value for parameter ValueElicitationSetting_SlotConstraint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WaitAndContinueSpecification_Active = this.WaitAndContinueSpecification_Active;
            context.ContinueResponse_AllowInterrupt = this.ContinueResponse_AllowInterrupt;
            if (this.ContinueResponse_MessageGroup != null)
            {
                context.ContinueResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.ContinueResponse_MessageGroup);
            }
            context.StillWaitingResponse_AllowInterrupt = this.StillWaitingResponse_AllowInterrupt;
            context.StillWaitingResponse_FrequencyInSecond = this.StillWaitingResponse_FrequencyInSecond;
            if (this.StillWaitingResponse_MessageGroup != null)
            {
                context.StillWaitingResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.StillWaitingResponse_MessageGroup);
            }
            context.StillWaitingResponse_TimeoutInSecond = this.StillWaitingResponse_TimeoutInSecond;
            context.WaitingResponse_AllowInterrupt = this.WaitingResponse_AllowInterrupt;
            if (this.WaitingResponse_MessageGroup != null)
            {
                context.WaitingResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.WaitingResponse_MessageGroup);
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
            var request = new Amazon.LexModelsV2.Model.CreateSlotRequest();
            
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
            if (cmdletContext.IntentId != null)
            {
                request.IntentId = cmdletContext.IntentId;
            }
            if (cmdletContext.LocaleId != null)
            {
                request.LocaleId = cmdletContext.LocaleId;
            }
            
             // populate MultipleValuesSetting
            var requestMultipleValuesSettingIsNull = true;
            request.MultipleValuesSetting = new Amazon.LexModelsV2.Model.MultipleValuesSetting();
            System.Boolean? requestMultipleValuesSetting_multipleValuesSetting_AllowMultipleValue = null;
            if (cmdletContext.MultipleValuesSetting_AllowMultipleValue != null)
            {
                requestMultipleValuesSetting_multipleValuesSetting_AllowMultipleValue = cmdletContext.MultipleValuesSetting_AllowMultipleValue.Value;
            }
            if (requestMultipleValuesSetting_multipleValuesSetting_AllowMultipleValue != null)
            {
                request.MultipleValuesSetting.AllowMultipleValues = requestMultipleValuesSetting_multipleValuesSetting_AllowMultipleValue.Value;
                requestMultipleValuesSettingIsNull = false;
            }
             // determine if request.MultipleValuesSetting should be set to null
            if (requestMultipleValuesSettingIsNull)
            {
                request.MultipleValuesSetting = null;
            }
            
             // populate ObfuscationSetting
            var requestObfuscationSettingIsNull = true;
            request.ObfuscationSetting = new Amazon.LexModelsV2.Model.ObfuscationSetting();
            Amazon.LexModelsV2.ObfuscationSettingType requestObfuscationSetting_obfuscationSetting_ObfuscationSettingType = null;
            if (cmdletContext.ObfuscationSetting_ObfuscationSettingType != null)
            {
                requestObfuscationSetting_obfuscationSetting_ObfuscationSettingType = cmdletContext.ObfuscationSetting_ObfuscationSettingType;
            }
            if (requestObfuscationSetting_obfuscationSetting_ObfuscationSettingType != null)
            {
                request.ObfuscationSetting.ObfuscationSettingType = requestObfuscationSetting_obfuscationSetting_ObfuscationSettingType;
                requestObfuscationSettingIsNull = false;
            }
             // determine if request.ObfuscationSetting should be set to null
            if (requestObfuscationSettingIsNull)
            {
                request.ObfuscationSetting = null;
            }
            if (cmdletContext.SlotName != null)
            {
                request.SlotName = cmdletContext.SlotName;
            }
            if (cmdletContext.SlotTypeId != null)
            {
                request.SlotTypeId = cmdletContext.SlotTypeId;
            }
            
             // populate ValueElicitationSetting
            var requestValueElicitationSettingIsNull = true;
            request.ValueElicitationSetting = new Amazon.LexModelsV2.Model.SlotValueElicitationSetting();
            List<Amazon.LexModelsV2.Model.SampleUtterance> requestValueElicitationSetting_valueElicitationSetting_SampleUtterance = null;
            if (cmdletContext.ValueElicitationSetting_SampleUtterance != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SampleUtterance = cmdletContext.ValueElicitationSetting_SampleUtterance;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SampleUtterance != null)
            {
                request.ValueElicitationSetting.SampleUtterances = requestValueElicitationSetting_valueElicitationSetting_SampleUtterance;
                requestValueElicitationSettingIsNull = false;
            }
            Amazon.LexModelsV2.SlotConstraint requestValueElicitationSetting_valueElicitationSetting_SlotConstraint = null;
            if (cmdletContext.ValueElicitationSetting_SlotConstraint != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotConstraint = cmdletContext.ValueElicitationSetting_SlotConstraint;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotConstraint != null)
            {
                request.ValueElicitationSetting.SlotConstraint = requestValueElicitationSetting_valueElicitationSetting_SlotConstraint;
                requestValueElicitationSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.SlotDefaultValueSpecification requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification = null;
            
             // populate DefaultValueSpecification
            var requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecificationIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification = new Amazon.LexModelsV2.Model.SlotDefaultValueSpecification();
            List<Amazon.LexModelsV2.Model.SlotDefaultValue> requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification_defaultValueSpecification_DefaultValueList = null;
            if (cmdletContext.DefaultValueSpecification_DefaultValueList != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification_defaultValueSpecification_DefaultValueList = cmdletContext.DefaultValueSpecification_DefaultValueList;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification_defaultValueSpecification_DefaultValueList != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification.DefaultValueList = requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification_defaultValueSpecification_DefaultValueList;
                requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecificationIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecificationIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification != null)
            {
                request.ValueElicitationSetting.DefaultValueSpecification = requestValueElicitationSetting_valueElicitationSetting_DefaultValueSpecification;
                requestValueElicitationSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.PromptSpecification requestValueElicitationSetting_valueElicitationSetting_PromptSpecification = null;
            
             // populate PromptSpecification
            var requestValueElicitationSetting_valueElicitationSetting_PromptSpecificationIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_PromptSpecification = new Amazon.LexModelsV2.Model.PromptSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_AllowInterrupt = null;
            if (cmdletContext.PromptSpecification_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_AllowInterrupt = cmdletContext.PromptSpecification_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecificationIsNull = false;
            }
            System.Int32? requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MaxRetry = null;
            if (cmdletContext.PromptSpecification_MaxRetry != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MaxRetry = cmdletContext.PromptSpecification_MaxRetry.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MaxRetry != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification.MaxRetries = requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MaxRetry.Value;
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecificationIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MessageGroup = null;
            if (cmdletContext.PromptSpecification_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MessageGroup = cmdletContext.PromptSpecification_MessageGroup;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MessageGroup;
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecificationIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_PromptSpecification should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_PromptSpecificationIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_PromptSpecification != null)
            {
                request.ValueElicitationSetting.PromptSpecification = requestValueElicitationSetting_valueElicitationSetting_PromptSpecification;
                requestValueElicitationSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.WaitAndContinueSpecification requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification = null;
            
             // populate WaitAndContinueSpecification
            var requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecificationIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification = new Amazon.LexModelsV2.Model.WaitAndContinueSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_waitAndContinueSpecification_Active = null;
            if (cmdletContext.WaitAndContinueSpecification_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_waitAndContinueSpecification_Active = cmdletContext.WaitAndContinueSpecification_Active.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_waitAndContinueSpecification_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification.Active = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_waitAndContinueSpecification_Active.Value;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse = null;
            
             // populate ContinueResponse
            var requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse_continueResponse_AllowInterrupt = null;
            if (cmdletContext.ContinueResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse_continueResponse_AllowInterrupt = cmdletContext.ContinueResponse_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse_continueResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse_continueResponse_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse_continueResponse_MessageGroup = null;
            if (cmdletContext.ContinueResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse_continueResponse_MessageGroup = cmdletContext.ContinueResponse_MessageGroup;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse_continueResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse_continueResponse_MessageGroup;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification.ContinueResponse = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_ContinueResponse;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse = null;
            
             // populate WaitingResponse
            var requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse_waitingResponse_AllowInterrupt = null;
            if (cmdletContext.WaitingResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse_waitingResponse_AllowInterrupt = cmdletContext.WaitingResponse_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse_waitingResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse_waitingResponse_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse_waitingResponse_MessageGroup = null;
            if (cmdletContext.WaitingResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse_waitingResponse_MessageGroup = cmdletContext.WaitingResponse_MessageGroup;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse_waitingResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse_waitingResponse_MessageGroup;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification.WaitingResponse = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_WaitingResponse;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.StillWaitingResponseSpecification requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse = null;
            
             // populate StillWaitingResponse
            var requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse = new Amazon.LexModelsV2.Model.StillWaitingResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_AllowInterrupt = null;
            if (cmdletContext.StillWaitingResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_AllowInterrupt = cmdletContext.StillWaitingResponse_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponseIsNull = false;
            }
            System.Int32? requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_FrequencyInSecond = null;
            if (cmdletContext.StillWaitingResponse_FrequencyInSecond != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_FrequencyInSecond = cmdletContext.StillWaitingResponse_FrequencyInSecond.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_FrequencyInSecond != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse.FrequencyInSeconds = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_FrequencyInSecond.Value;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_MessageGroup = null;
            if (cmdletContext.StillWaitingResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_MessageGroup = cmdletContext.StillWaitingResponse_MessageGroup;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_MessageGroup;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponseIsNull = false;
            }
            System.Int32? requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_TimeoutInSecond = null;
            if (cmdletContext.StillWaitingResponse_TimeoutInSecond != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_TimeoutInSecond = cmdletContext.StillWaitingResponse_TimeoutInSecond.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_TimeoutInSecond != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse.TimeoutInSeconds = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse_stillWaitingResponse_TimeoutInSecond.Value;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification.StillWaitingResponse = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification_valueElicitationSetting_WaitAndContinueSpecification_StillWaitingResponse;
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecificationIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecificationIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification != null)
            {
                request.ValueElicitationSetting.WaitAndContinueSpecification = requestValueElicitationSetting_valueElicitationSetting_WaitAndContinueSpecification;
                requestValueElicitationSettingIsNull = false;
            }
             // determine if request.ValueElicitationSetting should be set to null
            if (requestValueElicitationSettingIsNull)
            {
                request.ValueElicitationSetting = null;
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
        
        private Amazon.LexModelsV2.Model.CreateSlotResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.CreateSlotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "CreateSlot");
            try
            {
                #if DESKTOP
                return client.CreateSlot(request);
                #elif CORECLR
                return client.CreateSlotAsync(request).GetAwaiter().GetResult();
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
            public System.String IntentId { get; set; }
            public System.String LocaleId { get; set; }
            public System.Boolean? MultipleValuesSetting_AllowMultipleValue { get; set; }
            public Amazon.LexModelsV2.ObfuscationSettingType ObfuscationSetting_ObfuscationSettingType { get; set; }
            public System.String SlotName { get; set; }
            public System.String SlotTypeId { get; set; }
            public List<Amazon.LexModelsV2.Model.SlotDefaultValue> DefaultValueSpecification_DefaultValueList { get; set; }
            public System.Boolean? PromptSpecification_AllowInterrupt { get; set; }
            public System.Int32? PromptSpecification_MaxRetry { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> PromptSpecification_MessageGroup { get; set; }
            public List<Amazon.LexModelsV2.Model.SampleUtterance> ValueElicitationSetting_SampleUtterance { get; set; }
            public Amazon.LexModelsV2.SlotConstraint ValueElicitationSetting_SlotConstraint { get; set; }
            public System.Boolean? WaitAndContinueSpecification_Active { get; set; }
            public System.Boolean? ContinueResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> ContinueResponse_MessageGroup { get; set; }
            public System.Boolean? StillWaitingResponse_AllowInterrupt { get; set; }
            public System.Int32? StillWaitingResponse_FrequencyInSecond { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> StillWaitingResponse_MessageGroup { get; set; }
            public System.Int32? StillWaitingResponse_TimeoutInSecond { get; set; }
            public System.Boolean? WaitingResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> WaitingResponse_MessageGroup { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.CreateSlotResponse, NewLMBV2SlotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
