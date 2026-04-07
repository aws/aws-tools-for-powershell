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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Invokes an operating system-level action on a browser session in Amazon Bedrock AgentCore.
    /// This operation provides direct OS-level control over browser sessions, enabling mouse
    /// actions, keyboard input, and screenshots that the WebSocket-based Chrome DevTools
    /// Protocol (CDP) cannot handle — such as interacting with print dialogs, context menus,
    /// and JavaScript alerts.
    /// 
    ///  
    /// <para>
    /// You send a request with exactly one action in the <c>BrowserAction</c> union, and
    /// receive a corresponding result in the <c>BrowserActionResult</c> union.
    /// </para><para>
    /// The following operations are related to <c>InvokeBrowser</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_StartBrowserSession.html">StartBrowserSession</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_GetBrowserSession.html">GetBrowserSession</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_StopBrowserSession.html">StopBrowserSession</a></para></li></ul>
    /// </summary>
    [Cmdlet("Invoke", "BACBrowser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.InvokeBrowserResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer InvokeBrowser API operation.", Operation = new[] {"InvokeBrowser"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.InvokeBrowserResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.InvokeBrowserResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.InvokeBrowserResponse object containing multiple properties."
    )]
    public partial class InvokeBACBrowserCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BrowserIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the browser associated with the session. This must match
        /// the identifier used when creating the session with <c>StartBrowserSession</c>.</para>
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
        public System.String BrowserIdentifier { get; set; }
        #endregion
        
        #region Parameter Action_MouseClick_Button
        /// <summary>
        /// <para>
        /// <para>The mouse button to use. Defaults to <c>LEFT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.MouseButton")]
        public Amazon.BedrockAgentCore.MouseButton Action_MouseClick_Button { get; set; }
        #endregion
        
        #region Parameter Action_MouseDrag_Button
        /// <summary>
        /// <para>
        /// <para>The mouse button to use for the drag. Defaults to <c>LEFT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.MouseButton")]
        public Amazon.BedrockAgentCore.MouseButton Action_MouseDrag_Button { get; set; }
        #endregion
        
        #region Parameter Action_MouseClick_ClickCount
        /// <summary>
        /// <para>
        /// <para>The number of clicks to perform. Valid range: 1–10. Defaults to 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseClick_ClickCount { get; set; }
        #endregion
        
        #region Parameter Action_MouseScroll_DeltaX
        /// <summary>
        /// <para>
        /// <para>The horizontal scroll delta. Valid range: -1000 to 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseScroll_DeltaX { get; set; }
        #endregion
        
        #region Parameter Action_MouseScroll_DeltaY
        /// <summary>
        /// <para>
        /// <para>The vertical scroll delta. Valid range: -1000 to 1000. Negative values scroll down.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseScroll_DeltaY { get; set; }
        #endregion
        
        #region Parameter Action_MouseDrag_EndX
        /// <summary>
        /// <para>
        /// <para>The ending X coordinate for the drag.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseDrag_EndX { get; set; }
        #endregion
        
        #region Parameter Action_MouseDrag_EndY
        /// <summary>
        /// <para>
        /// <para>The ending Y coordinate for the drag.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseDrag_EndY { get; set; }
        #endregion
        
        #region Parameter Action_Screenshot_Format
        /// <summary>
        /// <para>
        /// <para>The image format for the screenshot. Defaults to <c>PNG</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.ScreenshotFormat")]
        public Amazon.BedrockAgentCore.ScreenshotFormat Action_Screenshot_Format { get; set; }
        #endregion
        
        #region Parameter Action_KeyPress_Key
        /// <summary>
        /// <para>
        /// <para>The key name to press (for example, <c>enter</c>, <c>tab</c>, <c>escape</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Action_KeyPress_Key { get; set; }
        #endregion
        
        #region Parameter Action_KeyShortcut_Key
        /// <summary>
        /// <para>
        /// <para>The key combination to press (for example, <c>["ctrl", "s"]</c>). Maximum 5 keys.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_KeyShortcut_Keys")]
        public System.String[] Action_KeyShortcut_Key { get; set; }
        #endregion
        
        #region Parameter Action_KeyPress_Press
        /// <summary>
        /// <para>
        /// <para>The number of times to press the key. Valid range: 1–100. Defaults to 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_KeyPress_Presses")]
        public System.Int32? Action_KeyPress_Press { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the browser session on which to perform the action. This
        /// must be an active session created with <c>StartBrowserSession</c>.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Action_MouseDrag_StartX
        /// <summary>
        /// <para>
        /// <para>The starting X coordinate for the drag.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseDrag_StartX { get; set; }
        #endregion
        
        #region Parameter Action_MouseDrag_StartY
        /// <summary>
        /// <para>
        /// <para>The starting Y coordinate for the drag.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseDrag_StartY { get; set; }
        #endregion
        
        #region Parameter Action_KeyType_Text
        /// <summary>
        /// <para>
        /// <para>The text string to type. Maximum length: 10,000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Action_KeyType_Text { get; set; }
        #endregion
        
        #region Parameter Action_MouseClick_X
        /// <summary>
        /// <para>
        /// <para>The X coordinate on screen where the click occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseClick_X { get; set; }
        #endregion
        
        #region Parameter Action_MouseMove_X
        /// <summary>
        /// <para>
        /// <para>The target X coordinate on screen.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseMove_X { get; set; }
        #endregion
        
        #region Parameter Action_MouseScroll_X
        /// <summary>
        /// <para>
        /// <para>The X coordinate on screen where the scroll occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseScroll_X { get; set; }
        #endregion
        
        #region Parameter Action_MouseClick_Y
        /// <summary>
        /// <para>
        /// <para>The Y coordinate on screen where the click occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseClick_Y { get; set; }
        #endregion
        
        #region Parameter Action_MouseMove_Y
        /// <summary>
        /// <para>
        /// <para>The target Y coordinate on screen.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseMove_Y { get; set; }
        #endregion
        
        #region Parameter Action_MouseScroll_Y
        /// <summary>
        /// <para>
        /// <para>The Y coordinate on screen where the scroll occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Action_MouseScroll_Y { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.InvokeBrowserResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.InvokeBrowserResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BrowserIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BACBrowser (InvokeBrowser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.InvokeBrowserResponse, InvokeBACBrowserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action_KeyPress_Key = this.Action_KeyPress_Key;
            context.Action_KeyPress_Press = this.Action_KeyPress_Press;
            if (this.Action_KeyShortcut_Key != null)
            {
                context.Action_KeyShortcut_Key = new List<System.String>(this.Action_KeyShortcut_Key);
            }
            context.Action_KeyType_Text = this.Action_KeyType_Text;
            context.Action_MouseClick_Button = this.Action_MouseClick_Button;
            context.Action_MouseClick_ClickCount = this.Action_MouseClick_ClickCount;
            context.Action_MouseClick_X = this.Action_MouseClick_X;
            context.Action_MouseClick_Y = this.Action_MouseClick_Y;
            context.Action_MouseDrag_Button = this.Action_MouseDrag_Button;
            context.Action_MouseDrag_EndX = this.Action_MouseDrag_EndX;
            context.Action_MouseDrag_EndY = this.Action_MouseDrag_EndY;
            context.Action_MouseDrag_StartX = this.Action_MouseDrag_StartX;
            context.Action_MouseDrag_StartY = this.Action_MouseDrag_StartY;
            context.Action_MouseMove_X = this.Action_MouseMove_X;
            context.Action_MouseMove_Y = this.Action_MouseMove_Y;
            context.Action_MouseScroll_DeltaX = this.Action_MouseScroll_DeltaX;
            context.Action_MouseScroll_DeltaY = this.Action_MouseScroll_DeltaY;
            context.Action_MouseScroll_X = this.Action_MouseScroll_X;
            context.Action_MouseScroll_Y = this.Action_MouseScroll_Y;
            context.Action_Screenshot_Format = this.Action_Screenshot_Format;
            context.BrowserIdentifier = this.BrowserIdentifier;
            #if MODULAR
            if (this.BrowserIdentifier == null && ParameterWasBound(nameof(this.BrowserIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter BrowserIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCore.Model.InvokeBrowserRequest();
            
            
             // populate Action
            var requestActionIsNull = true;
            request.Action = new Amazon.BedrockAgentCore.Model.BrowserAction();
            Amazon.BedrockAgentCore.Model.KeyShortcutArguments requestAction_action_KeyShortcut = null;
            
             // populate KeyShortcut
            var requestAction_action_KeyShortcutIsNull = true;
            requestAction_action_KeyShortcut = new Amazon.BedrockAgentCore.Model.KeyShortcutArguments();
            List<System.String> requestAction_action_KeyShortcut_action_KeyShortcut_Key = null;
            if (cmdletContext.Action_KeyShortcut_Key != null)
            {
                requestAction_action_KeyShortcut_action_KeyShortcut_Key = cmdletContext.Action_KeyShortcut_Key;
            }
            if (requestAction_action_KeyShortcut_action_KeyShortcut_Key != null)
            {
                requestAction_action_KeyShortcut.Keys = requestAction_action_KeyShortcut_action_KeyShortcut_Key;
                requestAction_action_KeyShortcutIsNull = false;
            }
             // determine if requestAction_action_KeyShortcut should be set to null
            if (requestAction_action_KeyShortcutIsNull)
            {
                requestAction_action_KeyShortcut = null;
            }
            if (requestAction_action_KeyShortcut != null)
            {
                request.Action.KeyShortcut = requestAction_action_KeyShortcut;
                requestActionIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.KeyTypeArguments requestAction_action_KeyType = null;
            
             // populate KeyType
            var requestAction_action_KeyTypeIsNull = true;
            requestAction_action_KeyType = new Amazon.BedrockAgentCore.Model.KeyTypeArguments();
            System.String requestAction_action_KeyType_action_KeyType_Text = null;
            if (cmdletContext.Action_KeyType_Text != null)
            {
                requestAction_action_KeyType_action_KeyType_Text = cmdletContext.Action_KeyType_Text;
            }
            if (requestAction_action_KeyType_action_KeyType_Text != null)
            {
                requestAction_action_KeyType.Text = requestAction_action_KeyType_action_KeyType_Text;
                requestAction_action_KeyTypeIsNull = false;
            }
             // determine if requestAction_action_KeyType should be set to null
            if (requestAction_action_KeyTypeIsNull)
            {
                requestAction_action_KeyType = null;
            }
            if (requestAction_action_KeyType != null)
            {
                request.Action.KeyType = requestAction_action_KeyType;
                requestActionIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.ScreenshotArguments requestAction_action_Screenshot = null;
            
             // populate Screenshot
            var requestAction_action_ScreenshotIsNull = true;
            requestAction_action_Screenshot = new Amazon.BedrockAgentCore.Model.ScreenshotArguments();
            Amazon.BedrockAgentCore.ScreenshotFormat requestAction_action_Screenshot_action_Screenshot_Format = null;
            if (cmdletContext.Action_Screenshot_Format != null)
            {
                requestAction_action_Screenshot_action_Screenshot_Format = cmdletContext.Action_Screenshot_Format;
            }
            if (requestAction_action_Screenshot_action_Screenshot_Format != null)
            {
                requestAction_action_Screenshot.Format = requestAction_action_Screenshot_action_Screenshot_Format;
                requestAction_action_ScreenshotIsNull = false;
            }
             // determine if requestAction_action_Screenshot should be set to null
            if (requestAction_action_ScreenshotIsNull)
            {
                requestAction_action_Screenshot = null;
            }
            if (requestAction_action_Screenshot != null)
            {
                request.Action.Screenshot = requestAction_action_Screenshot;
                requestActionIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.KeyPressArguments requestAction_action_KeyPress = null;
            
             // populate KeyPress
            var requestAction_action_KeyPressIsNull = true;
            requestAction_action_KeyPress = new Amazon.BedrockAgentCore.Model.KeyPressArguments();
            System.String requestAction_action_KeyPress_action_KeyPress_Key = null;
            if (cmdletContext.Action_KeyPress_Key != null)
            {
                requestAction_action_KeyPress_action_KeyPress_Key = cmdletContext.Action_KeyPress_Key;
            }
            if (requestAction_action_KeyPress_action_KeyPress_Key != null)
            {
                requestAction_action_KeyPress.Key = requestAction_action_KeyPress_action_KeyPress_Key;
                requestAction_action_KeyPressIsNull = false;
            }
            System.Int32? requestAction_action_KeyPress_action_KeyPress_Press = null;
            if (cmdletContext.Action_KeyPress_Press != null)
            {
                requestAction_action_KeyPress_action_KeyPress_Press = cmdletContext.Action_KeyPress_Press.Value;
            }
            if (requestAction_action_KeyPress_action_KeyPress_Press != null)
            {
                requestAction_action_KeyPress.Presses = requestAction_action_KeyPress_action_KeyPress_Press.Value;
                requestAction_action_KeyPressIsNull = false;
            }
             // determine if requestAction_action_KeyPress should be set to null
            if (requestAction_action_KeyPressIsNull)
            {
                requestAction_action_KeyPress = null;
            }
            if (requestAction_action_KeyPress != null)
            {
                request.Action.KeyPress = requestAction_action_KeyPress;
                requestActionIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.MouseMoveArguments requestAction_action_MouseMove = null;
            
             // populate MouseMove
            var requestAction_action_MouseMoveIsNull = true;
            requestAction_action_MouseMove = new Amazon.BedrockAgentCore.Model.MouseMoveArguments();
            System.Int32? requestAction_action_MouseMove_action_MouseMove_X = null;
            if (cmdletContext.Action_MouseMove_X != null)
            {
                requestAction_action_MouseMove_action_MouseMove_X = cmdletContext.Action_MouseMove_X.Value;
            }
            if (requestAction_action_MouseMove_action_MouseMove_X != null)
            {
                requestAction_action_MouseMove.X = requestAction_action_MouseMove_action_MouseMove_X.Value;
                requestAction_action_MouseMoveIsNull = false;
            }
            System.Int32? requestAction_action_MouseMove_action_MouseMove_Y = null;
            if (cmdletContext.Action_MouseMove_Y != null)
            {
                requestAction_action_MouseMove_action_MouseMove_Y = cmdletContext.Action_MouseMove_Y.Value;
            }
            if (requestAction_action_MouseMove_action_MouseMove_Y != null)
            {
                requestAction_action_MouseMove.Y = requestAction_action_MouseMove_action_MouseMove_Y.Value;
                requestAction_action_MouseMoveIsNull = false;
            }
             // determine if requestAction_action_MouseMove should be set to null
            if (requestAction_action_MouseMoveIsNull)
            {
                requestAction_action_MouseMove = null;
            }
            if (requestAction_action_MouseMove != null)
            {
                request.Action.MouseMove = requestAction_action_MouseMove;
                requestActionIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.MouseClickArguments requestAction_action_MouseClick = null;
            
             // populate MouseClick
            var requestAction_action_MouseClickIsNull = true;
            requestAction_action_MouseClick = new Amazon.BedrockAgentCore.Model.MouseClickArguments();
            Amazon.BedrockAgentCore.MouseButton requestAction_action_MouseClick_action_MouseClick_Button = null;
            if (cmdletContext.Action_MouseClick_Button != null)
            {
                requestAction_action_MouseClick_action_MouseClick_Button = cmdletContext.Action_MouseClick_Button;
            }
            if (requestAction_action_MouseClick_action_MouseClick_Button != null)
            {
                requestAction_action_MouseClick.Button = requestAction_action_MouseClick_action_MouseClick_Button;
                requestAction_action_MouseClickIsNull = false;
            }
            System.Int32? requestAction_action_MouseClick_action_MouseClick_ClickCount = null;
            if (cmdletContext.Action_MouseClick_ClickCount != null)
            {
                requestAction_action_MouseClick_action_MouseClick_ClickCount = cmdletContext.Action_MouseClick_ClickCount.Value;
            }
            if (requestAction_action_MouseClick_action_MouseClick_ClickCount != null)
            {
                requestAction_action_MouseClick.ClickCount = requestAction_action_MouseClick_action_MouseClick_ClickCount.Value;
                requestAction_action_MouseClickIsNull = false;
            }
            System.Int32? requestAction_action_MouseClick_action_MouseClick_X = null;
            if (cmdletContext.Action_MouseClick_X != null)
            {
                requestAction_action_MouseClick_action_MouseClick_X = cmdletContext.Action_MouseClick_X.Value;
            }
            if (requestAction_action_MouseClick_action_MouseClick_X != null)
            {
                requestAction_action_MouseClick.X = requestAction_action_MouseClick_action_MouseClick_X.Value;
                requestAction_action_MouseClickIsNull = false;
            }
            System.Int32? requestAction_action_MouseClick_action_MouseClick_Y = null;
            if (cmdletContext.Action_MouseClick_Y != null)
            {
                requestAction_action_MouseClick_action_MouseClick_Y = cmdletContext.Action_MouseClick_Y.Value;
            }
            if (requestAction_action_MouseClick_action_MouseClick_Y != null)
            {
                requestAction_action_MouseClick.Y = requestAction_action_MouseClick_action_MouseClick_Y.Value;
                requestAction_action_MouseClickIsNull = false;
            }
             // determine if requestAction_action_MouseClick should be set to null
            if (requestAction_action_MouseClickIsNull)
            {
                requestAction_action_MouseClick = null;
            }
            if (requestAction_action_MouseClick != null)
            {
                request.Action.MouseClick = requestAction_action_MouseClick;
                requestActionIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.MouseScrollArguments requestAction_action_MouseScroll = null;
            
             // populate MouseScroll
            var requestAction_action_MouseScrollIsNull = true;
            requestAction_action_MouseScroll = new Amazon.BedrockAgentCore.Model.MouseScrollArguments();
            System.Int32? requestAction_action_MouseScroll_action_MouseScroll_DeltaX = null;
            if (cmdletContext.Action_MouseScroll_DeltaX != null)
            {
                requestAction_action_MouseScroll_action_MouseScroll_DeltaX = cmdletContext.Action_MouseScroll_DeltaX.Value;
            }
            if (requestAction_action_MouseScroll_action_MouseScroll_DeltaX != null)
            {
                requestAction_action_MouseScroll.DeltaX = requestAction_action_MouseScroll_action_MouseScroll_DeltaX.Value;
                requestAction_action_MouseScrollIsNull = false;
            }
            System.Int32? requestAction_action_MouseScroll_action_MouseScroll_DeltaY = null;
            if (cmdletContext.Action_MouseScroll_DeltaY != null)
            {
                requestAction_action_MouseScroll_action_MouseScroll_DeltaY = cmdletContext.Action_MouseScroll_DeltaY.Value;
            }
            if (requestAction_action_MouseScroll_action_MouseScroll_DeltaY != null)
            {
                requestAction_action_MouseScroll.DeltaY = requestAction_action_MouseScroll_action_MouseScroll_DeltaY.Value;
                requestAction_action_MouseScrollIsNull = false;
            }
            System.Int32? requestAction_action_MouseScroll_action_MouseScroll_X = null;
            if (cmdletContext.Action_MouseScroll_X != null)
            {
                requestAction_action_MouseScroll_action_MouseScroll_X = cmdletContext.Action_MouseScroll_X.Value;
            }
            if (requestAction_action_MouseScroll_action_MouseScroll_X != null)
            {
                requestAction_action_MouseScroll.X = requestAction_action_MouseScroll_action_MouseScroll_X.Value;
                requestAction_action_MouseScrollIsNull = false;
            }
            System.Int32? requestAction_action_MouseScroll_action_MouseScroll_Y = null;
            if (cmdletContext.Action_MouseScroll_Y != null)
            {
                requestAction_action_MouseScroll_action_MouseScroll_Y = cmdletContext.Action_MouseScroll_Y.Value;
            }
            if (requestAction_action_MouseScroll_action_MouseScroll_Y != null)
            {
                requestAction_action_MouseScroll.Y = requestAction_action_MouseScroll_action_MouseScroll_Y.Value;
                requestAction_action_MouseScrollIsNull = false;
            }
             // determine if requestAction_action_MouseScroll should be set to null
            if (requestAction_action_MouseScrollIsNull)
            {
                requestAction_action_MouseScroll = null;
            }
            if (requestAction_action_MouseScroll != null)
            {
                request.Action.MouseScroll = requestAction_action_MouseScroll;
                requestActionIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.MouseDragArguments requestAction_action_MouseDrag = null;
            
             // populate MouseDrag
            var requestAction_action_MouseDragIsNull = true;
            requestAction_action_MouseDrag = new Amazon.BedrockAgentCore.Model.MouseDragArguments();
            Amazon.BedrockAgentCore.MouseButton requestAction_action_MouseDrag_action_MouseDrag_Button = null;
            if (cmdletContext.Action_MouseDrag_Button != null)
            {
                requestAction_action_MouseDrag_action_MouseDrag_Button = cmdletContext.Action_MouseDrag_Button;
            }
            if (requestAction_action_MouseDrag_action_MouseDrag_Button != null)
            {
                requestAction_action_MouseDrag.Button = requestAction_action_MouseDrag_action_MouseDrag_Button;
                requestAction_action_MouseDragIsNull = false;
            }
            System.Int32? requestAction_action_MouseDrag_action_MouseDrag_EndX = null;
            if (cmdletContext.Action_MouseDrag_EndX != null)
            {
                requestAction_action_MouseDrag_action_MouseDrag_EndX = cmdletContext.Action_MouseDrag_EndX.Value;
            }
            if (requestAction_action_MouseDrag_action_MouseDrag_EndX != null)
            {
                requestAction_action_MouseDrag.EndX = requestAction_action_MouseDrag_action_MouseDrag_EndX.Value;
                requestAction_action_MouseDragIsNull = false;
            }
            System.Int32? requestAction_action_MouseDrag_action_MouseDrag_EndY = null;
            if (cmdletContext.Action_MouseDrag_EndY != null)
            {
                requestAction_action_MouseDrag_action_MouseDrag_EndY = cmdletContext.Action_MouseDrag_EndY.Value;
            }
            if (requestAction_action_MouseDrag_action_MouseDrag_EndY != null)
            {
                requestAction_action_MouseDrag.EndY = requestAction_action_MouseDrag_action_MouseDrag_EndY.Value;
                requestAction_action_MouseDragIsNull = false;
            }
            System.Int32? requestAction_action_MouseDrag_action_MouseDrag_StartX = null;
            if (cmdletContext.Action_MouseDrag_StartX != null)
            {
                requestAction_action_MouseDrag_action_MouseDrag_StartX = cmdletContext.Action_MouseDrag_StartX.Value;
            }
            if (requestAction_action_MouseDrag_action_MouseDrag_StartX != null)
            {
                requestAction_action_MouseDrag.StartX = requestAction_action_MouseDrag_action_MouseDrag_StartX.Value;
                requestAction_action_MouseDragIsNull = false;
            }
            System.Int32? requestAction_action_MouseDrag_action_MouseDrag_StartY = null;
            if (cmdletContext.Action_MouseDrag_StartY != null)
            {
                requestAction_action_MouseDrag_action_MouseDrag_StartY = cmdletContext.Action_MouseDrag_StartY.Value;
            }
            if (requestAction_action_MouseDrag_action_MouseDrag_StartY != null)
            {
                requestAction_action_MouseDrag.StartY = requestAction_action_MouseDrag_action_MouseDrag_StartY.Value;
                requestAction_action_MouseDragIsNull = false;
            }
             // determine if requestAction_action_MouseDrag should be set to null
            if (requestAction_action_MouseDragIsNull)
            {
                requestAction_action_MouseDrag = null;
            }
            if (requestAction_action_MouseDrag != null)
            {
                request.Action.MouseDrag = requestAction_action_MouseDrag;
                requestActionIsNull = false;
            }
             // determine if request.Action should be set to null
            if (requestActionIsNull)
            {
                request.Action = null;
            }
            if (cmdletContext.BrowserIdentifier != null)
            {
                request.BrowserIdentifier = cmdletContext.BrowserIdentifier;
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
        
        private Amazon.BedrockAgentCore.Model.InvokeBrowserResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.InvokeBrowserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "InvokeBrowser");
            try
            {
                return client.InvokeBrowserAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Action_KeyPress_Key { get; set; }
            public System.Int32? Action_KeyPress_Press { get; set; }
            public List<System.String> Action_KeyShortcut_Key { get; set; }
            public System.String Action_KeyType_Text { get; set; }
            public Amazon.BedrockAgentCore.MouseButton Action_MouseClick_Button { get; set; }
            public System.Int32? Action_MouseClick_ClickCount { get; set; }
            public System.Int32? Action_MouseClick_X { get; set; }
            public System.Int32? Action_MouseClick_Y { get; set; }
            public Amazon.BedrockAgentCore.MouseButton Action_MouseDrag_Button { get; set; }
            public System.Int32? Action_MouseDrag_EndX { get; set; }
            public System.Int32? Action_MouseDrag_EndY { get; set; }
            public System.Int32? Action_MouseDrag_StartX { get; set; }
            public System.Int32? Action_MouseDrag_StartY { get; set; }
            public System.Int32? Action_MouseMove_X { get; set; }
            public System.Int32? Action_MouseMove_Y { get; set; }
            public System.Int32? Action_MouseScroll_DeltaX { get; set; }
            public System.Int32? Action_MouseScroll_DeltaY { get; set; }
            public System.Int32? Action_MouseScroll_X { get; set; }
            public System.Int32? Action_MouseScroll_Y { get; set; }
            public Amazon.BedrockAgentCore.ScreenshotFormat Action_Screenshot_Format { get; set; }
            public System.String BrowserIdentifier { get; set; }
            public System.String SessionId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.InvokeBrowserResponse, InvokeBACBrowserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
