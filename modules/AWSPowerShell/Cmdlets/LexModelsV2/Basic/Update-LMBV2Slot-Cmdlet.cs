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
    /// Updates the settings for a slot.
    /// </summary>
    [Cmdlet("Update", "LMBV2Slot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.UpdateSlotResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 UpdateSlot API operation.", Operation = new[] {"UpdateSlot"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.UpdateSlotResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.UpdateSlotResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.UpdateSlotResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMBV2SlotCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        #region Parameter CaptureConditional_Active
        /// <summary>
        /// <para>
        /// <para>Determines whether a conditional branch is active. When <code>active</code> is false,
        /// the conditions are not evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_Active")]
        public System.Boolean? CaptureConditional_Active { get; set; }
        #endregion
        
        #region Parameter CodeHook_Active
        /// <summary>
        /// <para>
        /// <para>Determines whether a dialog code hook is used when the intent is activated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_Active")]
        public System.Boolean? CodeHook_Active { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active
        /// <summary>
        /// <para>
        /// <para>Determines whether a conditional branch is active. When <code>active</code> is false,
        /// the conditions are not evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active { get; set; }
        #endregion
        
        #region Parameter SuccessConditional_Active
        /// <summary>
        /// <para>
        /// <para>Determines whether a conditional branch is active. When <code>active</code> is false,
        /// the conditions are not evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_Active")]
        public System.Boolean? SuccessConditional_Active { get; set; }
        #endregion
        
        #region Parameter TimeoutConditional_Active
        /// <summary>
        /// <para>
        /// <para>Determines whether a conditional branch is active. When <code>active</code> is false,
        /// the conditions are not evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_Active")]
        public System.Boolean? TimeoutConditional_Active { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureConditional_Active
        /// <summary>
        /// <para>
        /// <para>Determines whether a conditional branch is active. When <code>active</code> is false,
        /// the conditions are not evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_FailureConditional_Active { get; set; }
        #endregion
        
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
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter CaptureResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CaptureResponse_AllowInterrupt")]
        public System.Boolean? CaptureResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter SuccessResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse_AllowInterrupt")]
        public System.Boolean? SuccessResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter TimeoutResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse_AllowInterrupt")]
        public System.Boolean? TimeoutResponse_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt
        /// <summary>
        /// <para>
        /// <para>Indicates whether the user can interrupt a speech response from Amazon Lex.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt { get; set; }
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
        /// <para>The unique identifier of the bot that contains the slot.</para>
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
        /// <para>The version of the bot that contains the slot. Must always be <code>DRAFT</code>.</para>
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
        
        #region Parameter CaptureConditional_ConditionalBranch
        /// <summary>
        /// <para>
        /// <para>A list of conditional branches. A conditional branch is made up of a condition, a
        /// response and a next step. The response and next step are executed when the condition
        /// is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_ConditionalBranches")]
        public Amazon.LexModelsV2.Model.ConditionalBranch[] CaptureConditional_ConditionalBranch { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches
        /// <summary>
        /// <para>
        /// <para>A list of conditional branches. A conditional branch is made up of a condition, a
        /// response and a next step. The response and next step are executed when the condition
        /// is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.ConditionalBranch[] ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches { get; set; }
        #endregion
        
        #region Parameter SuccessConditional_ConditionalBranch
        /// <summary>
        /// <para>
        /// <para>A list of conditional branches. A conditional branch is made up of a condition, a
        /// response and a next step. The response and next step are executed when the condition
        /// is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_ConditionalBranches")]
        public Amazon.LexModelsV2.Model.ConditionalBranch[] SuccessConditional_ConditionalBranch { get; set; }
        #endregion
        
        #region Parameter TimeoutConditional_ConditionalBranch
        /// <summary>
        /// <para>
        /// <para>A list of conditional branches. A conditional branch is made up of a condition, a
        /// response and a next step. The response and next step are executed when the condition
        /// is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_ConditionalBranches")]
        public Amazon.LexModelsV2.Model.ConditionalBranch[] TimeoutConditional_ConditionalBranch { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches
        /// <summary>
        /// <para>
        /// <para>A list of conditional branches. A conditional branch is made up of a condition, a
        /// response and a next step. The response and next step are executed when the condition
        /// is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.ConditionalBranch[] ValueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches { get; set; }
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
        /// <para>The new description for the slot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter CodeHook_EnableCodeHookInvocation
        /// <summary>
        /// <para>
        /// <para>Indicates whether a Lambda function should be invoked for the dialog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_EnableCodeHookInvocation")]
        public System.Boolean? CodeHook_EnableCodeHookInvocation { get; set; }
        #endregion
        
        #region Parameter ElicitationCodeHook_EnableCodeHookInvocation
        /// <summary>
        /// <para>
        /// <para>Indicates whether a Lambda function should be invoked for the dialog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook_EnableCodeHookInvocation")]
        public System.Boolean? ElicitationCodeHook_EnableCodeHookInvocation { get; set; }
        #endregion
        
        #region Parameter SubSlotSetting_Expression
        /// <summary>
        /// <para>
        /// <para>The expression text for defining the constituent sub slots in the composite slot using
        /// logical AND and OR operators.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubSlotSetting_Expression { get; set; }
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
        
        #region Parameter CodeHook_InvocationLabel
        /// <summary>
        /// <para>
        /// <para>A label that indicates the dialog step from which the dialog code hook is happening.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_InvocationLabel")]
        public System.String CodeHook_InvocationLabel { get; set; }
        #endregion
        
        #region Parameter ElicitationCodeHook_InvocationLabel
        /// <summary>
        /// <para>
        /// <para>A label that indicates the dialog step from which the dialog code hook is happening.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook_InvocationLabel")]
        public System.String ElicitationCodeHook_InvocationLabel { get; set; }
        #endregion
        
        #region Parameter LocaleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the language and locale that contains the slot. The string must
        /// match one of the supported locales. For more information, see <a href="https://docs.aws.amazon.com/lexv2/latest/dg/how-languages.html">Supported
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
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.MessageGroup[] ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups { get; set; }
        #endregion
        
        #region Parameter CaptureResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CaptureResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] CaptureResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.MessageGroup[] ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.MessageGroup[] ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.MessageGroup[] ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups { get; set; }
        #endregion
        
        #region Parameter SuccessResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] SuccessResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.MessageGroup[] ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups { get; set; }
        #endregion
        
        #region Parameter TimeoutResponse_MessageGroup
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse_MessageGroups")]
        public Amazon.LexModelsV2.Model.MessageGroup[] TimeoutResponse_MessageGroup { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.MessageGroup[] ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups
        /// <summary>
        /// <para>
        /// <para>A collection of responses that Amazon Lex can send to the user. Amazon Lex chooses
        /// the actual response to send at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LexModelsV2.Model.MessageGroup[] ValueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups { get; set; }
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
        
        #region Parameter PromptSpecification_MessageSelectionStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates how a message is selected from a message group among retries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_PromptSpecification_MessageSelectionStrategy")]
        [AWSConstantClassSource("Amazon.LexModelsV2.MessageSelectionStrategy")]
        public Amazon.LexModelsV2.MessageSelectionStrategy PromptSpecification_MessageSelectionStrategy { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Only required when you're switching intents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Only required when you're switching intents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Only required when you're switching intents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Only required when you're switching intents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Only required when you're switching intents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Only required when you're switching intents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Only required when you're switching intents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Only required when you're switching intents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Only required when you're switching intents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name
        /// <summary>
        /// <para>
        /// <para>The name of the intent. Only required when you're switching intents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name { get; set; }
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
        
        #region Parameter PromptSpecification_PromptAttemptsSpecification
        /// <summary>
        /// <para>
        /// <para>Specifies the advanced settings on each attempt of the prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_PromptSpecification_PromptAttemptsSpecification")]
        public System.Collections.Hashtable PromptSpecification_PromptAttemptsSpecification { get; set; }
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
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes { get; set; }
        #endregion
        
        #region Parameter CaptureNextStep_SessionAttribute
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_SessionAttributes")]
        public System.Collections.Hashtable CaptureNextStep_SessionAttribute { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes { get; set; }
        #endregion
        
        #region Parameter SuccessNextStep_SessionAttribute
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_SessionAttributes")]
        public System.Collections.Hashtable SuccessNextStep_SessionAttribute { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes { get; set; }
        #endregion
        
        #region Parameter TimeoutNextStep_SessionAttribute
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_SessionAttributes")]
        public System.Collections.Hashtable TimeoutNextStep_SessionAttribute { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes
        /// <summary>
        /// <para>
        /// <para>Map of key/value pairs representing session-specific context information. It contains
        /// application information passed between Amazon Lex and a client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes { get; set; }
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
        
        #region Parameter SlotId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the slot to update.</para>
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
        public System.String SlotId { get; set; }
        #endregion
        
        #region Parameter SlotName
        /// <summary>
        /// <para>
        /// <para>The new name for the slot.</para>
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
        public System.String SlotName { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots
        /// <summary>
        /// <para>
        /// <para>A map of all of the slot value overrides for the intent. The name of the slot maps
        /// to the value of the slot. Slots that are not included in the map aren't overridden.,</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots
        /// <summary>
        /// <para>
        /// <para>A map of all of the slot value overrides for the intent. The name of the slot maps
        /// to the value of the slot. Slots that are not included in the map aren't overridden.,</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots
        /// <summary>
        /// <para>
        /// <para>A map of all of the slot value overrides for the intent. The name of the slot maps
        /// to the value of the slot. Slots that are not included in the map aren't overridden.,</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots
        /// <summary>
        /// <para>
        /// <para>A map of all of the slot value overrides for the intent. The name of the slot maps
        /// to the value of the slot. Slots that are not included in the map aren't overridden.,</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots
        /// <summary>
        /// <para>
        /// <para>A map of all of the slot value overrides for the intent. The name of the slot maps
        /// to the value of the slot. Slots that are not included in the map aren't overridden.,</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots
        /// <summary>
        /// <para>
        /// <para>A map of all of the slot value overrides for the intent. The name of the slot maps
        /// to the value of the slot. Slots that are not included in the map aren't overridden.,</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots
        /// <summary>
        /// <para>
        /// <para>A map of all of the slot value overrides for the intent. The name of the slot maps
        /// to the value of the slot. Slots that are not included in the map aren't overridden.,</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots
        /// <summary>
        /// <para>
        /// <para>A map of all of the slot value overrides for the intent. The name of the slot maps
        /// to the value of the slot. Slots that are not included in the map aren't overridden.,</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots
        /// <summary>
        /// <para>
        /// <para>A map of all of the slot value overrides for the intent. The name of the slot maps
        /// to the value of the slot. Slots that are not included in the map aren't overridden.,</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots
        /// <summary>
        /// <para>
        /// <para>A map of all of the slot value overrides for the intent. The name of the slot maps
        /// to the value of the slot. Slots that are not included in the map aren't overridden.,</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots { get; set; }
        #endregion
        
        #region Parameter SubSlotSetting_SlotSpecification
        /// <summary>
        /// <para>
        /// <para>Specifications for the constituent sub slots of a composite slot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubSlotSetting_SlotSpecifications")]
        public System.Collections.Hashtable SubSlotSetting_SlotSpecification { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>If the dialog action is <code>ElicitSlot</code>, defines the slot to elicit from the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>If the dialog action is <code>ElicitSlot</code>, defines the slot to elicit from the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>If the dialog action is <code>ElicitSlot</code>, defines the slot to elicit from the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>If the dialog action is <code>ElicitSlot</code>, defines the slot to elicit from the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>If the dialog action is <code>ElicitSlot</code>, defines the slot to elicit from the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>If the dialog action is <code>ElicitSlot</code>, defines the slot to elicit from the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>If the dialog action is <code>ElicitSlot</code>, defines the slot to elicit from the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>If the dialog action is <code>ElicitSlot</code>, defines the slot to elicit from the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>If the dialog action is <code>ElicitSlot</code>, defines the slot to elicit from the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit
        /// <summary>
        /// <para>
        /// <para>If the dialog action is <code>ElicitSlot</code>, defines the slot to elicit from the
        /// user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit { get; set; }
        #endregion
        
        #region Parameter SlotTypeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the new slot type to associate with this slot. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SlotTypeId { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage
        /// <summary>
        /// <para>
        /// <para>When true the next message for the intent is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage
        /// <summary>
        /// <para>
        /// <para>When true the next message for the intent is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage
        /// <summary>
        /// <para>
        /// <para>When true the next message for the intent is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage
        /// <summary>
        /// <para>
        /// <para>When true the next message for the intent is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage
        /// <summary>
        /// <para>
        /// <para>When true the next message for the intent is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage
        /// <summary>
        /// <para>
        /// <para>When true the next message for the intent is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage
        /// <summary>
        /// <para>
        /// <para>When true the next message for the intent is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage
        /// <summary>
        /// <para>
        /// <para>When true the next message for the intent is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage
        /// <summary>
        /// <para>
        /// <para>When true the next message for the intent is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage
        /// <summary>
        /// <para>
        /// <para>When true the next message for the intent is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage { get; set; }
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
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The action that the bot should execute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.DialogActionType")]
        public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The action that the bot should execute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.DialogActionType")]
        public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The action that the bot should execute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.DialogActionType")]
        public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The action that the bot should execute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.DialogActionType")]
        public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The action that the bot should execute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.DialogActionType")]
        public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The action that the bot should execute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.DialogActionType")]
        public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The action that the bot should execute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.DialogActionType")]
        public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The action that the bot should execute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.DialogActionType")]
        public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The action that the bot should execute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.DialogActionType")]
        public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type
        /// <summary>
        /// <para>
        /// <para>The action that the bot should execute. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.DialogActionType")]
        public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.UpdateSlotResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.UpdateSlotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SlotId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SlotId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SlotId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SlotId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMBV2Slot (UpdateSlot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.UpdateSlotResponse, UpdateLMBV2SlotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SlotId;
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
            context.SlotId = this.SlotId;
            #if MODULAR
            if (this.SlotId == null && ParameterWasBound(nameof(this.SlotId)))
            {
                WriteWarning("You are passing $null as a value for parameter SlotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SlotName = this.SlotName;
            #if MODULAR
            if (this.SlotName == null && ParameterWasBound(nameof(this.SlotName)))
            {
                WriteWarning("You are passing $null as a value for parameter SlotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SlotTypeId = this.SlotTypeId;
            context.SubSlotSetting_Expression = this.SubSlotSetting_Expression;
            if (this.SubSlotSetting_SlotSpecification != null)
            {
                context.SubSlotSetting_SlotSpecification = new Dictionary<System.String, Amazon.LexModelsV2.Model.Specifications>(StringComparer.Ordinal);
                foreach (var hashKey in this.SubSlotSetting_SlotSpecification.Keys)
                {
                    context.SubSlotSetting_SlotSpecification.Add((String)hashKey, (Specifications)(this.SubSlotSetting_SlotSpecification[hashKey]));
                }
            }
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
            context.PromptSpecification_MessageSelectionStrategy = this.PromptSpecification_MessageSelectionStrategy;
            if (this.PromptSpecification_PromptAttemptsSpecification != null)
            {
                context.PromptSpecification_PromptAttemptsSpecification = new Dictionary<System.String, Amazon.LexModelsV2.Model.PromptAttemptSpecification>(StringComparer.Ordinal);
                foreach (var hashKey in this.PromptSpecification_PromptAttemptsSpecification.Keys)
                {
                    context.PromptSpecification_PromptAttemptsSpecification.Add((String)hashKey, (PromptAttemptSpecification)(this.PromptSpecification_PromptAttemptsSpecification[hashKey]));
                }
            }
            if (this.ValueElicitationSetting_SampleUtterance != null)
            {
                context.ValueElicitationSetting_SampleUtterance = new List<Amazon.LexModelsV2.Model.SampleUtterance>(this.ValueElicitationSetting_SampleUtterance);
            }
            context.CaptureConditional_Active = this.CaptureConditional_Active;
            if (this.CaptureConditional_ConditionalBranch != null)
            {
                context.CaptureConditional_ConditionalBranch = new List<Amazon.LexModelsV2.Model.ConditionalBranch>(this.CaptureConditional_ConditionalBranch);
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
            context.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage;
            context.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type = this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type;
            context.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name = this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots = new Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots.Add((String)hashKey, (SlotValueOverride)(this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots[hashKey]));
                }
            }
            if (this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes.Add((String)hashKey, (String)(this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes[hashKey]));
                }
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt = this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups);
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit = this.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit;
            context.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage = this.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage;
            context.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type = this.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type;
            context.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name = this.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots = new Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots.Add((String)hashKey, (SlotValueOverride)(this.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots[hashKey]));
                }
            }
            if (this.CaptureNextStep_SessionAttribute != null)
            {
                context.CaptureNextStep_SessionAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CaptureNextStep_SessionAttribute.Keys)
                {
                    context.CaptureNextStep_SessionAttribute.Add((String)hashKey, (String)(this.CaptureNextStep_SessionAttribute[hashKey]));
                }
            }
            context.CaptureResponse_AllowInterrupt = this.CaptureResponse_AllowInterrupt;
            if (this.CaptureResponse_MessageGroup != null)
            {
                context.CaptureResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.CaptureResponse_MessageGroup);
            }
            context.CodeHook_Active = this.CodeHook_Active;
            context.CodeHook_EnableCodeHookInvocation = this.CodeHook_EnableCodeHookInvocation;
            context.CodeHook_InvocationLabel = this.CodeHook_InvocationLabel;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches = new List<Amazon.LexModelsV2.Model.ConditionalBranch>(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches);
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots = new Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots.Add((String)hashKey, (SlotValueOverride)(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots[hashKey]));
                }
            }
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes.Add((String)hashKey, (String)(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes[hashKey]));
                }
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups);
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots = new Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots.Add((String)hashKey, (SlotValueOverride)(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots[hashKey]));
                }
            }
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes.Add((String)hashKey, (String)(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes[hashKey]));
                }
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups);
            }
            context.SuccessConditional_Active = this.SuccessConditional_Active;
            if (this.SuccessConditional_ConditionalBranch != null)
            {
                context.SuccessConditional_ConditionalBranch = new List<Amazon.LexModelsV2.Model.ConditionalBranch>(this.SuccessConditional_ConditionalBranch);
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots = new Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots.Add((String)hashKey, (SlotValueOverride)(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots[hashKey]));
                }
            }
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes.Add((String)hashKey, (String)(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes[hashKey]));
                }
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups);
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots = new Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots.Add((String)hashKey, (SlotValueOverride)(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots[hashKey]));
                }
            }
            if (this.SuccessNextStep_SessionAttribute != null)
            {
                context.SuccessNextStep_SessionAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SuccessNextStep_SessionAttribute.Keys)
                {
                    context.SuccessNextStep_SessionAttribute.Add((String)hashKey, (String)(this.SuccessNextStep_SessionAttribute[hashKey]));
                }
            }
            context.SuccessResponse_AllowInterrupt = this.SuccessResponse_AllowInterrupt;
            if (this.SuccessResponse_MessageGroup != null)
            {
                context.SuccessResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.SuccessResponse_MessageGroup);
            }
            context.TimeoutConditional_Active = this.TimeoutConditional_Active;
            if (this.TimeoutConditional_ConditionalBranch != null)
            {
                context.TimeoutConditional_ConditionalBranch = new List<Amazon.LexModelsV2.Model.ConditionalBranch>(this.TimeoutConditional_ConditionalBranch);
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots = new Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots.Add((String)hashKey, (SlotValueOverride)(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots[hashKey]));
                }
            }
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes.Add((String)hashKey, (String)(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes[hashKey]));
                }
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups);
            }
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type;
            context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name = this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name;
            if (this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots = new Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots.Add((String)hashKey, (SlotValueOverride)(this.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots[hashKey]));
                }
            }
            if (this.TimeoutNextStep_SessionAttribute != null)
            {
                context.TimeoutNextStep_SessionAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TimeoutNextStep_SessionAttribute.Keys)
                {
                    context.TimeoutNextStep_SessionAttribute.Add((String)hashKey, (String)(this.TimeoutNextStep_SessionAttribute[hashKey]));
                }
            }
            context.TimeoutResponse_AllowInterrupt = this.TimeoutResponse_AllowInterrupt;
            if (this.TimeoutResponse_MessageGroup != null)
            {
                context.TimeoutResponse_MessageGroup = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.TimeoutResponse_MessageGroup);
            }
            context.ElicitationCodeHook_EnableCodeHookInvocation = this.ElicitationCodeHook_EnableCodeHookInvocation;
            context.ElicitationCodeHook_InvocationLabel = this.ElicitationCodeHook_InvocationLabel;
            context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_Active = this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_Active;
            if (this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches = new List<Amazon.LexModelsV2.Model.ConditionalBranch>(this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches);
            }
            context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
            context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage;
            context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type = this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type;
            context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name = this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name;
            if (this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots = new Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots.Add((String)hashKey, (SlotValueOverride)(this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots[hashKey]));
                }
            }
            if (this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes.Add((String)hashKey, (String)(this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes[hashKey]));
                }
            }
            context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt = this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt;
            if (this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups);
            }
            context.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit = this.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit;
            context.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage = this.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage;
            context.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type = this.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type;
            context.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name = this.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name;
            if (this.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots = new Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots.Add((String)hashKey, (SlotValueOverride)(this.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots[hashKey]));
                }
            }
            if (this.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes.Keys)
                {
                    context.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes.Add((String)hashKey, (String)(this.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes[hashKey]));
                }
            }
            context.ValueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt = this.ValueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt;
            if (this.ValueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups != null)
            {
                context.ValueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups = new List<Amazon.LexModelsV2.Model.MessageGroup>(this.ValueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups);
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
            var request = new Amazon.LexModelsV2.Model.UpdateSlotRequest();
            
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
            if (cmdletContext.SlotId != null)
            {
                request.SlotId = cmdletContext.SlotId;
            }
            if (cmdletContext.SlotName != null)
            {
                request.SlotName = cmdletContext.SlotName;
            }
            if (cmdletContext.SlotTypeId != null)
            {
                request.SlotTypeId = cmdletContext.SlotTypeId;
            }
            
             // populate SubSlotSetting
            var requestSubSlotSettingIsNull = true;
            request.SubSlotSetting = new Amazon.LexModelsV2.Model.SubSlotSetting();
            System.String requestSubSlotSetting_subSlotSetting_Expression = null;
            if (cmdletContext.SubSlotSetting_Expression != null)
            {
                requestSubSlotSetting_subSlotSetting_Expression = cmdletContext.SubSlotSetting_Expression;
            }
            if (requestSubSlotSetting_subSlotSetting_Expression != null)
            {
                request.SubSlotSetting.Expression = requestSubSlotSetting_subSlotSetting_Expression;
                requestSubSlotSettingIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.Specifications> requestSubSlotSetting_subSlotSetting_SlotSpecification = null;
            if (cmdletContext.SubSlotSetting_SlotSpecification != null)
            {
                requestSubSlotSetting_subSlotSetting_SlotSpecification = cmdletContext.SubSlotSetting_SlotSpecification;
            }
            if (requestSubSlotSetting_subSlotSetting_SlotSpecification != null)
            {
                request.SubSlotSetting.SlotSpecifications = requestSubSlotSetting_subSlotSetting_SlotSpecification;
                requestSubSlotSettingIsNull = false;
            }
             // determine if request.SubSlotSetting should be set to null
            if (requestSubSlotSettingIsNull)
            {
                request.SubSlotSetting = null;
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
            Amazon.LexModelsV2.MessageSelectionStrategy requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MessageSelectionStrategy = null;
            if (cmdletContext.PromptSpecification_MessageSelectionStrategy != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MessageSelectionStrategy = cmdletContext.PromptSpecification_MessageSelectionStrategy;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MessageSelectionStrategy != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification.MessageSelectionStrategy = requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_MessageSelectionStrategy;
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecificationIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.PromptAttemptSpecification> requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_PromptAttemptsSpecification = null;
            if (cmdletContext.PromptSpecification_PromptAttemptsSpecification != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_PromptAttemptsSpecification = cmdletContext.PromptSpecification_PromptAttemptsSpecification;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_PromptAttemptsSpecification != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_PromptSpecification.PromptAttemptsSpecification = requestValueElicitationSetting_valueElicitationSetting_PromptSpecification_promptSpecification_PromptAttemptsSpecification;
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
            Amazon.LexModelsV2.Model.SlotCaptureSetting requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting = null;
            
             // populate SlotCaptureSetting
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSettingIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting = new Amazon.LexModelsV2.Model.SlotCaptureSetting();
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse = null;
            
             // populate CaptureResponse
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse_captureResponse_AllowInterrupt = null;
            if (cmdletContext.CaptureResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse_captureResponse_AllowInterrupt = cmdletContext.CaptureResponse_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse_captureResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse_captureResponse_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse_captureResponse_MessageGroup = null;
            if (cmdletContext.CaptureResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse_captureResponse_MessageGroup = cmdletContext.CaptureResponse_MessageGroup;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse_captureResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse_captureResponse_MessageGroup;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting.CaptureResponse = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureResponse;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.ElicitationCodeHookInvocationSetting requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook = null;
            
             // populate ElicitationCodeHook
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHookIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook = new Amazon.LexModelsV2.Model.ElicitationCodeHookInvocationSetting();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook_elicitationCodeHook_EnableCodeHookInvocation = null;
            if (cmdletContext.ElicitationCodeHook_EnableCodeHookInvocation != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook_elicitationCodeHook_EnableCodeHookInvocation = cmdletContext.ElicitationCodeHook_EnableCodeHookInvocation.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook_elicitationCodeHook_EnableCodeHookInvocation != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook.EnableCodeHookInvocation = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook_elicitationCodeHook_EnableCodeHookInvocation.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHookIsNull = false;
            }
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook_elicitationCodeHook_InvocationLabel = null;
            if (cmdletContext.ElicitationCodeHook_InvocationLabel != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook_elicitationCodeHook_InvocationLabel = cmdletContext.ElicitationCodeHook_InvocationLabel;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook_elicitationCodeHook_InvocationLabel != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook.InvocationLabel = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook_elicitationCodeHook_InvocationLabel;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHookIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHookIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting.ElicitationCodeHook = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_ElicitationCodeHook;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse = null;
            
             // populate FailureResponse
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse_valueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse_valueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse_valueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse_valueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse_valueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse_valueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse_valueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse_valueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting.FailureResponse = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureResponse;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.ConditionalSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional = null;
            
             // populate CaptureConditional
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditionalIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional = new Amazon.LexModelsV2.Model.ConditionalSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_captureConditional_Active = null;
            if (cmdletContext.CaptureConditional_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_captureConditional_Active = cmdletContext.CaptureConditional_Active.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_captureConditional_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional.Active = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_captureConditional_Active.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditionalIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.ConditionalBranch> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_captureConditional_ConditionalBranch = null;
            if (cmdletContext.CaptureConditional_ConditionalBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_captureConditional_ConditionalBranch = cmdletContext.CaptureConditional_ConditionalBranch;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_captureConditional_ConditionalBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional.ConditionalBranches = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_captureConditional_ConditionalBranch;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditionalIsNull = false;
            }
            Amazon.LexModelsV2.Model.DefaultConditionalBranch requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch = null;
            
             // populate DefaultBranch
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranchIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch = new Amazon.LexModelsV2.Model.DefaultConditionalBranch();
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response = null;
            
             // populate Response
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_ResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_ResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_ResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_ResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch.Response = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranchIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogState requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep = null;
            
             // populate NextStep
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStepIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep = new Amazon.LexModelsV2.Model.DialogState();
            Dictionary<System.String, System.String> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep.SessionAttributes = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentOverride requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent = null;
            
             // populate Intent
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_IntentIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent = new Amazon.LexModelsV2.Model.IntentOverride();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent.Name = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent.Slots = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_IntentIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_IntentIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep.Intent = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogAction requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction = null;
            
             // populate DialogAction
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogActionIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction = new Amazon.LexModelsV2.Model.DialogAction();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction.SlotToElicit = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction.SuppressNextMessage = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
            Amazon.LexModelsV2.DialogActionType requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction.Type = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogActionIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep.DialogAction = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStepIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStepIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch.NextStep = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranchIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranchIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional.DefaultBranch = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_valueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditionalIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditionalIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting.CaptureConditional = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureConditional;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogState requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep = null;
            
             // populate CaptureNextStep
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStepIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep = new Amazon.LexModelsV2.Model.DialogState();
            Dictionary<System.String, System.String> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_captureNextStep_SessionAttribute = null;
            if (cmdletContext.CaptureNextStep_SessionAttribute != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_captureNextStep_SessionAttribute = cmdletContext.CaptureNextStep_SessionAttribute;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_captureNextStep_SessionAttribute != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep.SessionAttributes = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_captureNextStep_SessionAttribute;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentOverride requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent = null;
            
             // populate Intent
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_IntentIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent = new Amazon.LexModelsV2.Model.IntentOverride();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent.Name = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent.Slots = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_IntentIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_IntentIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep.Intent = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogAction requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction = null;
            
             // populate DialogAction
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogActionIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction = new Amazon.LexModelsV2.Model.DialogAction();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction.SlotToElicit = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogActionIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction.SuppressNextMessage = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogActionIsNull = false;
            }
            Amazon.LexModelsV2.DialogActionType requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction.Type = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogActionIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogActionIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep.DialogAction = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStepIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStepIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting.CaptureNextStep = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CaptureNextStep;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.ConditionalSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional = null;
            
             // populate FailureConditional
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditionalIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional = new Amazon.LexModelsV2.Model.ConditionalSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_Active = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_Active = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_Active.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional.Active = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_Active.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditionalIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.ConditionalBranch> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional.ConditionalBranches = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditionalIsNull = false;
            }
            Amazon.LexModelsV2.Model.DefaultConditionalBranch requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch = null;
            
             // populate DefaultBranch
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranchIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch = new Amazon.LexModelsV2.Model.DefaultConditionalBranch();
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response = null;
            
             // populate Response
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_ResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_ResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_ResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_ResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch.Response = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranchIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogState requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep = null;
            
             // populate NextStep
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStepIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep = new Amazon.LexModelsV2.Model.DialogState();
            Dictionary<System.String, System.String> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep.SessionAttributes = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentOverride requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent = null;
            
             // populate Intent
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_IntentIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent = new Amazon.LexModelsV2.Model.IntentOverride();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent.Name = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent.Slots = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_IntentIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_IntentIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep.Intent = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogAction requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction = null;
            
             // populate DialogAction
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogActionIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction = new Amazon.LexModelsV2.Model.DialogAction();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction.SlotToElicit = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction.SuppressNextMessage = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
            Amazon.LexModelsV2.DialogActionType requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction.Type = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogActionIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep.DialogAction = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStepIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStepIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch.NextStep = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranchIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranchIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional.DefaultBranch = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional_valueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditionalIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditionalIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting.FailureConditional = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureConditional;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogState requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep = null;
            
             // populate FailureNextStep
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStepIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep = new Amazon.LexModelsV2.Model.DialogState();
            Dictionary<System.String, System.String> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep.SessionAttributes = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentOverride requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent = null;
            
             // populate Intent
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_IntentIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent = new Amazon.LexModelsV2.Model.IntentOverride();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent.Name = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent.Slots = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_IntentIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_IntentIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep.Intent = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogAction requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction = null;
            
             // populate DialogAction
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogActionIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction = new Amazon.LexModelsV2.Model.DialogAction();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction.SlotToElicit = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogActionIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction.SuppressNextMessage = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogActionIsNull = false;
            }
            Amazon.LexModelsV2.DialogActionType requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction.Type = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogActionIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogActionIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep.DialogAction = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStepIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStepIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting.FailureNextStep = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_FailureNextStep;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSettingIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogCodeHookInvocationSetting requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook = null;
            
             // populate CodeHook
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHookIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook = new Amazon.LexModelsV2.Model.DialogCodeHookInvocationSetting();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_Active = null;
            if (cmdletContext.CodeHook_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_Active = cmdletContext.CodeHook_Active.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook.Active = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_Active.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHookIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_EnableCodeHookInvocation = null;
            if (cmdletContext.CodeHook_EnableCodeHookInvocation != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_EnableCodeHookInvocation = cmdletContext.CodeHook_EnableCodeHookInvocation.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_EnableCodeHookInvocation != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook.EnableCodeHookInvocation = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_EnableCodeHookInvocation.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHookIsNull = false;
            }
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_InvocationLabel = null;
            if (cmdletContext.CodeHook_InvocationLabel != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_InvocationLabel = cmdletContext.CodeHook_InvocationLabel;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_InvocationLabel != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook.InvocationLabel = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_codeHook_InvocationLabel;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHookIsNull = false;
            }
            Amazon.LexModelsV2.Model.PostDialogCodeHookInvocationSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification = null;
            
             // populate PostCodeHookSpecification
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification = new Amazon.LexModelsV2.Model.PostDialogCodeHookInvocationSpecification();
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse = null;
            
             // populate FailureResponse
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification.FailureResponse = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse = null;
            
             // populate SuccessResponse
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse_successResponse_AllowInterrupt = null;
            if (cmdletContext.SuccessResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse_successResponse_AllowInterrupt = cmdletContext.SuccessResponse_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse_successResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse_successResponse_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse_successResponse_MessageGroup = null;
            if (cmdletContext.SuccessResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse_successResponse_MessageGroup = cmdletContext.SuccessResponse_MessageGroup;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse_successResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse_successResponse_MessageGroup;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification.SuccessResponse = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessResponse;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse = null;
            
             // populate TimeoutResponse
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse_timeoutResponse_AllowInterrupt = null;
            if (cmdletContext.TimeoutResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse_timeoutResponse_AllowInterrupt = cmdletContext.TimeoutResponse_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse_timeoutResponse_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse_timeoutResponse_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse_timeoutResponse_MessageGroup = null;
            if (cmdletContext.TimeoutResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse_timeoutResponse_MessageGroup = cmdletContext.TimeoutResponse_MessageGroup;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse_timeoutResponse_MessageGroup != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse_timeoutResponse_MessageGroup;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification.TimeoutResponse = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutResponse;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.ConditionalSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional = null;
            
             // populate FailureConditional
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditionalIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional = new Amazon.LexModelsV2.Model.ConditionalSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional.Active = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditionalIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.ConditionalBranch> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional.ConditionalBranches = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditionalIsNull = false;
            }
            Amazon.LexModelsV2.Model.DefaultConditionalBranch requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch = null;
            
             // populate DefaultBranch
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranchIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch = new Amazon.LexModelsV2.Model.DefaultConditionalBranch();
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response = null;
            
             // populate Response
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_ResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_ResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_ResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_ResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch.Response = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranchIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogState requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep = null;
            
             // populate NextStep
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStepIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep = new Amazon.LexModelsV2.Model.DialogState();
            Dictionary<System.String, System.String> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep.SessionAttributes = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentOverride requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent = null;
            
             // populate Intent
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_IntentIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent = new Amazon.LexModelsV2.Model.IntentOverride();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent.Name = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent.Slots = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_IntentIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_IntentIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep.Intent = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogAction requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction = null;
            
             // populate DialogAction
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogActionIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction = new Amazon.LexModelsV2.Model.DialogAction();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction.SlotToElicit = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction.SuppressNextMessage = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
            Amazon.LexModelsV2.DialogActionType requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction.Type = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogActionIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep.DialogAction = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStepIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStepIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch.NextStep = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranchIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranchIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional.DefaultBranch = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditionalIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditionalIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification.FailureConditional = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogState requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep = null;
            
             // populate FailureNextStep
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStepIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep = new Amazon.LexModelsV2.Model.DialogState();
            Dictionary<System.String, System.String> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep.SessionAttributes = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentOverride requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent = null;
            
             // populate Intent
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_IntentIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent = new Amazon.LexModelsV2.Model.IntentOverride();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent.Name = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent.Slots = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_IntentIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_IntentIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep.Intent = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogAction requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction = null;
            
             // populate DialogAction
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogActionIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction = new Amazon.LexModelsV2.Model.DialogAction();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction.SlotToElicit = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogActionIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction.SuppressNextMessage = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogActionIsNull = false;
            }
            Amazon.LexModelsV2.DialogActionType requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction.Type = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogActionIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogActionIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep.DialogAction = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStepIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStepIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification.FailureNextStep = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.ConditionalSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional = null;
            
             // populate SuccessConditional
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditionalIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional = new Amazon.LexModelsV2.Model.ConditionalSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_successConditional_Active = null;
            if (cmdletContext.SuccessConditional_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_successConditional_Active = cmdletContext.SuccessConditional_Active.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_successConditional_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional.Active = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_successConditional_Active.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditionalIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.ConditionalBranch> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_successConditional_ConditionalBranch = null;
            if (cmdletContext.SuccessConditional_ConditionalBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_successConditional_ConditionalBranch = cmdletContext.SuccessConditional_ConditionalBranch;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_successConditional_ConditionalBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional.ConditionalBranches = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_successConditional_ConditionalBranch;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditionalIsNull = false;
            }
            Amazon.LexModelsV2.Model.DefaultConditionalBranch requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch = null;
            
             // populate DefaultBranch
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranchIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch = new Amazon.LexModelsV2.Model.DefaultConditionalBranch();
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response = null;
            
             // populate Response
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_ResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_ResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_ResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_ResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch.Response = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranchIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogState requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep = null;
            
             // populate NextStep
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStepIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep = new Amazon.LexModelsV2.Model.DialogState();
            Dictionary<System.String, System.String> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep.SessionAttributes = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentOverride requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent = null;
            
             // populate Intent
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_IntentIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent = new Amazon.LexModelsV2.Model.IntentOverride();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent.Name = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent.Slots = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_IntentIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_IntentIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep.Intent = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogAction requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction = null;
            
             // populate DialogAction
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogActionIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction = new Amazon.LexModelsV2.Model.DialogAction();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction.SlotToElicit = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction.SuppressNextMessage = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
            Amazon.LexModelsV2.DialogActionType requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction.Type = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogActionIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep.DialogAction = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStepIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStepIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch.NextStep = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranchIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranchIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional.DefaultBranch = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditionalIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditionalIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification.SuccessConditional = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogState requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep = null;
            
             // populate SuccessNextStep
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStepIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep = new Amazon.LexModelsV2.Model.DialogState();
            Dictionary<System.String, System.String> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_successNextStep_SessionAttribute = null;
            if (cmdletContext.SuccessNextStep_SessionAttribute != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_successNextStep_SessionAttribute = cmdletContext.SuccessNextStep_SessionAttribute;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_successNextStep_SessionAttribute != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep.SessionAttributes = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_successNextStep_SessionAttribute;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentOverride requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent = null;
            
             // populate Intent
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_IntentIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent = new Amazon.LexModelsV2.Model.IntentOverride();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent.Name = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent.Slots = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_IntentIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_IntentIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep.Intent = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogAction requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction = null;
            
             // populate DialogAction
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogActionIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction = new Amazon.LexModelsV2.Model.DialogAction();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction.SlotToElicit = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogActionIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction.SuppressNextMessage = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogActionIsNull = false;
            }
            Amazon.LexModelsV2.DialogActionType requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction.Type = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogActionIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogActionIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep.DialogAction = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStepIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStepIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification.SuccessNextStep = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.ConditionalSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional = null;
            
             // populate TimeoutConditional
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditionalIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional = new Amazon.LexModelsV2.Model.ConditionalSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_timeoutConditional_Active = null;
            if (cmdletContext.TimeoutConditional_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_timeoutConditional_Active = cmdletContext.TimeoutConditional_Active.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_timeoutConditional_Active != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional.Active = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_timeoutConditional_Active.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditionalIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.ConditionalBranch> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_timeoutConditional_ConditionalBranch = null;
            if (cmdletContext.TimeoutConditional_ConditionalBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_timeoutConditional_ConditionalBranch = cmdletContext.TimeoutConditional_ConditionalBranch;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_timeoutConditional_ConditionalBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional.ConditionalBranches = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_timeoutConditional_ConditionalBranch;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditionalIsNull = false;
            }
            Amazon.LexModelsV2.Model.DefaultConditionalBranch requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch = null;
            
             // populate DefaultBranch
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranchIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch = new Amazon.LexModelsV2.Model.DefaultConditionalBranch();
            Amazon.LexModelsV2.Model.ResponseSpecification requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response = null;
            
             // populate Response
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_ResponseIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response = new Amazon.LexModelsV2.Model.ResponseSpecification();
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response.AllowInterrupt = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_ResponseIsNull = false;
            }
            List<Amazon.LexModelsV2.Model.MessageGroup> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response.MessageGroups = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_ResponseIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_ResponseIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch.Response = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranchIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogState requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep = null;
            
             // populate NextStep
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStepIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep = new Amazon.LexModelsV2.Model.DialogState();
            Dictionary<System.String, System.String> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep.SessionAttributes = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentOverride requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent = null;
            
             // populate Intent
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_IntentIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent = new Amazon.LexModelsV2.Model.IntentOverride();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent.Name = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent.Slots = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_IntentIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_IntentIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep.Intent = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogAction requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction = null;
            
             // populate DialogAction
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogActionIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction = new Amazon.LexModelsV2.Model.DialogAction();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction.SlotToElicit = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction.SuppressNextMessage = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
            Amazon.LexModelsV2.DialogActionType requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction.Type = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogActionIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogActionIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep.DialogAction = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStepIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStepIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch.NextStep = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranchIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranchIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional.DefaultBranch = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditionalIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditionalIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification.TimeoutConditional = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogState requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep = null;
            
             // populate TimeoutNextStep
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStepIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep = new Amazon.LexModelsV2.Model.DialogState();
            Dictionary<System.String, System.String> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_timeoutNextStep_SessionAttribute = null;
            if (cmdletContext.TimeoutNextStep_SessionAttribute != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_timeoutNextStep_SessionAttribute = cmdletContext.TimeoutNextStep_SessionAttribute;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_timeoutNextStep_SessionAttribute != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep.SessionAttributes = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_timeoutNextStep_SessionAttribute;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.IntentOverride requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent = null;
            
             // populate Intent
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_IntentIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent = new Amazon.LexModelsV2.Model.IntentOverride();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent.Name = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_IntentIsNull = false;
            }
            Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent.Slots = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_IntentIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_IntentIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep.Intent = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStepIsNull = false;
            }
            Amazon.LexModelsV2.Model.DialogAction requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction = null;
            
             // populate DialogAction
            var requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogActionIsNull = true;
            requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction = new Amazon.LexModelsV2.Model.DialogAction();
            System.String requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction.SlotToElicit = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogActionIsNull = false;
            }
            System.Boolean? requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage.Value;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction.SuppressNextMessage = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage.Value;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogActionIsNull = false;
            }
            Amazon.LexModelsV2.DialogActionType requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type = null;
            if (cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type = cmdletContext.ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction.Type = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogActionIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogActionIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep.DialogAction = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStepIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStepIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification.TimeoutNextStep = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecificationIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook.PostCodeHookSpecification = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook_valueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHookIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHookIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook != null)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting.CodeHook = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting_valueElicitationSetting_SlotCaptureSetting_CodeHook;
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSettingIsNull = false;
            }
             // determine if requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting should be set to null
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSettingIsNull)
            {
                requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting = null;
            }
            if (requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting != null)
            {
                request.ValueElicitationSetting.SlotCaptureSetting = requestValueElicitationSetting_valueElicitationSetting_SlotCaptureSetting;
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
        
        private Amazon.LexModelsV2.Model.UpdateSlotResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.UpdateSlotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "UpdateSlot");
            try
            {
                #if DESKTOP
                return client.UpdateSlot(request);
                #elif CORECLR
                return client.UpdateSlotAsync(request).GetAwaiter().GetResult();
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
            public System.String SlotId { get; set; }
            public System.String SlotName { get; set; }
            public System.String SlotTypeId { get; set; }
            public System.String SubSlotSetting_Expression { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.Specifications> SubSlotSetting_SlotSpecification { get; set; }
            public List<Amazon.LexModelsV2.Model.SlotDefaultValue> DefaultValueSpecification_DefaultValueList { get; set; }
            public System.Boolean? PromptSpecification_AllowInterrupt { get; set; }
            public System.Int32? PromptSpecification_MaxRetry { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> PromptSpecification_MessageGroup { get; set; }
            public Amazon.LexModelsV2.MessageSelectionStrategy PromptSpecification_MessageSelectionStrategy { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.PromptAttemptSpecification> PromptSpecification_PromptAttemptsSpecification { get; set; }
            public List<Amazon.LexModelsV2.Model.SampleUtterance> ValueElicitationSetting_SampleUtterance { get; set; }
            public System.Boolean? CaptureConditional_Active { get; set; }
            public List<Amazon.LexModelsV2.Model.ConditionalBranch> CaptureConditional_ConditionalBranch { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage { get; set; }
            public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_Intent_Slots { get; set; }
            public Dictionary<System.String, System.String> ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_SessionAttributes { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_Response_MessageGroups { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SlotToElicit { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_SuppressNextMessage { get; set; }
            public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_Intent_Slots { get; set; }
            public Dictionary<System.String, System.String> CaptureNextStep_SessionAttribute { get; set; }
            public System.Boolean? CaptureResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> CaptureResponse_MessageGroup { get; set; }
            public System.Boolean? CodeHook_Active { get; set; }
            public System.Boolean? CodeHook_EnableCodeHookInvocation { get; set; }
            public System.String CodeHook_InvocationLabel { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_Active { get; set; }
            public List<Amazon.LexModelsV2.Model.ConditionalBranch> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_ConditionalBranches { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage { get; set; }
            public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_Intent_Slots { get; set; }
            public Dictionary<System.String, System.String> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_SessionAttributes { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_Response_MessageGroups { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SlotToElicit { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_SuppressNextMessage { get; set; }
            public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_Intent_Slots { get; set; }
            public Dictionary<System.String, System.String> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_SessionAttributes { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureResponse_MessageGroups { get; set; }
            public System.Boolean? SuccessConditional_Active { get; set; }
            public List<Amazon.LexModelsV2.Model.ConditionalBranch> SuccessConditional_ConditionalBranch { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage { get; set; }
            public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_Intent_Slots { get; set; }
            public Dictionary<System.String, System.String> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_SessionAttributes { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_Response_MessageGroups { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SlotToElicit { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_SuppressNextMessage { get; set; }
            public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_Intent_Slots { get; set; }
            public Dictionary<System.String, System.String> SuccessNextStep_SessionAttribute { get; set; }
            public System.Boolean? SuccessResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> SuccessResponse_MessageGroup { get; set; }
            public System.Boolean? TimeoutConditional_Active { get; set; }
            public List<Amazon.LexModelsV2.Model.ConditionalBranch> TimeoutConditional_ConditionalBranch { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage { get; set; }
            public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_Intent_Slots { get; set; }
            public Dictionary<System.String, System.String> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_SessionAttributes { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_Response_MessageGroups { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SlotToElicit { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_SuppressNextMessage { get; set; }
            public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_Intent_Slots { get; set; }
            public Dictionary<System.String, System.String> TimeoutNextStep_SessionAttribute { get; set; }
            public System.Boolean? TimeoutResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> TimeoutResponse_MessageGroup { get; set; }
            public System.Boolean? ElicitationCodeHook_EnableCodeHookInvocation { get; set; }
            public System.String ElicitationCodeHook_InvocationLabel { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_FailureConditional_Active { get; set; }
            public List<Amazon.LexModelsV2.Model.ConditionalBranch> ValueElicitationSetting_SlotCaptureSetting_FailureConditional_ConditionalBranches { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SlotToElicit { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_SuppressNextMessage { get; set; }
            public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_Intent_Slots { get; set; }
            public Dictionary<System.String, System.String> ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_SessionAttributes { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_Response_MessageGroups { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SlotToElicit { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_SuppressNextMessage { get; set; }
            public Amazon.LexModelsV2.DialogActionType ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type { get; set; }
            public System.String ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Name { get; set; }
            public Dictionary<System.String, Amazon.LexModelsV2.Model.SlotValueOverride> ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_Intent_Slots { get; set; }
            public Dictionary<System.String, System.String> ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_SessionAttributes { get; set; }
            public System.Boolean? ValueElicitationSetting_SlotCaptureSetting_FailureResponse_AllowInterrupt { get; set; }
            public List<Amazon.LexModelsV2.Model.MessageGroup> ValueElicitationSetting_SlotCaptureSetting_FailureResponse_MessageGroups { get; set; }
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
            public System.Func<Amazon.LexModelsV2.Model.UpdateSlotResponse, UpdateLMBV2SlotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
