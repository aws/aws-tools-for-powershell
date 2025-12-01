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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Creates a workspace that defines the user experience by mapping views to pages. Workspaces
    /// can be assigned to users or routing profiles.
    /// </summary>
    [Cmdlet("New", "CONNWorkspace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateWorkspaceResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateWorkspace API operation.", Operation = new[] {"CreateWorkspace"}, SelectReturnType = typeof(Amazon.Connect.Model.CreateWorkspaceResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateWorkspaceResponse",
        "This cmdlet returns an Amazon.Connect.Model.CreateWorkspaceResponse object containing multiple properties."
    )]
    public partial class NewCONNWorkspaceCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Theme_Dark_Palette_Primary_Active
        /// <summary>
        /// <para>
        /// <para>The primary color used for active states.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Primary_Active { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Primary_Active
        /// <summary>
        /// <para>
        /// <para>The primary color used for active states.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Primary_Active { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Canvas_ActiveBackground
        /// <summary>
        /// <para>
        /// <para>The background color for active elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Canvas_ActiveBackground { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Canvas_ActiveBackground
        /// <summary>
        /// <para>
        /// <para>The background color for active elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Canvas_ActiveBackground { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Header_Background
        /// <summary>
        /// <para>
        /// <para>The background color of the header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Header_Background { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Navigation_Background
        /// <summary>
        /// <para>
        /// <para>The background color of the navigation area.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Navigation_Background { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Header_Background
        /// <summary>
        /// <para>
        /// <para>The background color of the header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Header_Background { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Navigation_Background
        /// <summary>
        /// <para>
        /// <para>The background color of the navigation area.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Navigation_Background { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Canvas_ContainerBackground
        /// <summary>
        /// <para>
        /// <para>The background color for container elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Canvas_ContainerBackground { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Canvas_ContainerBackground
        /// <summary>
        /// <para>
        /// <para>The background color for container elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Canvas_ContainerBackground { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Primary_ContrastText
        /// <summary>
        /// <para>
        /// <para>The text color that contrasts with the primary color for readability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Primary_ContrastText { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Primary_ContrastText
        /// <summary>
        /// <para>
        /// <para>The text color that contrasts with the primary color for readability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Primary_ContrastText { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Images_Logo_Default
        /// <summary>
        /// <para>
        /// <para>The default logo image displayed in the workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Images_Logo_Default { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Primary_Default
        /// <summary>
        /// <para>
        /// <para>The default primary color used throughout the workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Primary_Default { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Typography_FontFamily_Default
        /// <summary>
        /// <para>
        /// <para>The default font family to use in the workspace theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.WorkspaceFontFamily")]
        public Amazon.Connect.WorkspaceFontFamily Theme_Dark_Typography_FontFamily_Default { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Images_Logo_Default
        /// <summary>
        /// <para>
        /// <para>The default logo image displayed in the workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Images_Logo_Default { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Primary_Default
        /// <summary>
        /// <para>
        /// <para>The default primary color used throughout the workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Primary_Default { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Typography_FontFamily_Default
        /// <summary>
        /// <para>
        /// <para>The default font family to use in the workspace theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.WorkspaceFontFamily")]
        public Amazon.Connect.WorkspaceFontFamily Theme_Light_Typography_FontFamily_Default { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the workspace. Maximum length is 250 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Images_Logo_Favicon
        /// <summary>
        /// <para>
        /// <para>The favicon image displayed in the browser tab.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Images_Logo_Favicon { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Images_Logo_Favicon
        /// <summary>
        /// <para>
        /// <para>The favicon image displayed in the browser tab.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Images_Logo_Favicon { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Header_InvertActionsColors
        /// <summary>
        /// <para>
        /// <para>Whether to invert the colors of action buttons in the header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Theme_Dark_Palette_Header_InvertActionsColors { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Navigation_InvertActionsColors
        /// <summary>
        /// <para>
        /// <para>Whether to invert the colors of action buttons in the navigation area.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Theme_Dark_Palette_Navigation_InvertActionsColors { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Header_InvertActionsColors
        /// <summary>
        /// <para>
        /// <para>Whether to invert the colors of action buttons in the header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Theme_Light_Palette_Header_InvertActionsColors { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Navigation_InvertActionsColors
        /// <summary>
        /// <para>
        /// <para>Whether to invert the colors of action buttons in the navigation area.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Theme_Light_Palette_Navigation_InvertActionsColors { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the workspace. Must be unique within the instance and can contain 1-127
        /// characters.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Canvas_PageBackground
        /// <summary>
        /// <para>
        /// <para>The background color for page elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Canvas_PageBackground { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Canvas_PageBackground
        /// <summary>
        /// <para>
        /// <para>The background color for page elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Canvas_PageBackground { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource. For example,
        /// <c>{ "Tags": {"key1":"value1", "key2":"value2"} }</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Header_Text
        /// <summary>
        /// <para>
        /// <para>The text color in the header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Header_Text { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Navigation_Text
        /// <summary>
        /// <para>
        /// <para>The text color in the navigation area.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Navigation_Text { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Header_Text
        /// <summary>
        /// <para>
        /// <para>The text color in the header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Header_Text { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Navigation_Text
        /// <summary>
        /// <para>
        /// <para>The text color in the navigation area.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Navigation_Text { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Navigation_TextActive
        /// <summary>
        /// <para>
        /// <para>The text color for active navigation items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Navigation_TextActive { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Navigation_TextActive
        /// <summary>
        /// <para>
        /// <para>The text color for active navigation items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Navigation_TextActive { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Navigation_TextBackgroundActive
        /// <summary>
        /// <para>
        /// <para>The background color for active navigation items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Navigation_TextBackgroundActive { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Navigation_TextBackgroundActive
        /// <summary>
        /// <para>
        /// <para>The background color for active navigation items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Navigation_TextBackgroundActive { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Navigation_TextBackgroundHover
        /// <summary>
        /// <para>
        /// <para>The background color when hovering over navigation text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Navigation_TextBackgroundHover { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Navigation_TextBackgroundHover
        /// <summary>
        /// <para>
        /// <para>The background color when hovering over navigation text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Navigation_TextBackgroundHover { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Header_TextHover
        /// <summary>
        /// <para>
        /// <para>The text color when hovering over header elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Header_TextHover { get; set; }
        #endregion
        
        #region Parameter Theme_Dark_Palette_Navigation_TextHover
        /// <summary>
        /// <para>
        /// <para>The text color when hovering over navigation items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Dark_Palette_Navigation_TextHover { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Header_TextHover
        /// <summary>
        /// <para>
        /// <para>The text color when hovering over header elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Header_TextHover { get; set; }
        #endregion
        
        #region Parameter Theme_Light_Palette_Navigation_TextHover
        /// <summary>
        /// <para>
        /// <para>The text color when hovering over navigation items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Theme_Light_Palette_Navigation_TextHover { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>The title displayed for the workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreateWorkspaceResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreateWorkspaceResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.InstanceId),
                nameof(this.Name)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNWorkspace (CreateWorkspace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreateWorkspaceResponse, NewCONNWorkspaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Theme_Dark_Images_Logo_Default = this.Theme_Dark_Images_Logo_Default;
            context.Theme_Dark_Images_Logo_Favicon = this.Theme_Dark_Images_Logo_Favicon;
            context.Theme_Dark_Palette_Canvas_ActiveBackground = this.Theme_Dark_Palette_Canvas_ActiveBackground;
            context.Theme_Dark_Palette_Canvas_ContainerBackground = this.Theme_Dark_Palette_Canvas_ContainerBackground;
            context.Theme_Dark_Palette_Canvas_PageBackground = this.Theme_Dark_Palette_Canvas_PageBackground;
            context.Theme_Dark_Palette_Header_Background = this.Theme_Dark_Palette_Header_Background;
            context.Theme_Dark_Palette_Header_InvertActionsColors = this.Theme_Dark_Palette_Header_InvertActionsColors;
            context.Theme_Dark_Palette_Header_Text = this.Theme_Dark_Palette_Header_Text;
            context.Theme_Dark_Palette_Header_TextHover = this.Theme_Dark_Palette_Header_TextHover;
            context.Theme_Dark_Palette_Navigation_Background = this.Theme_Dark_Palette_Navigation_Background;
            context.Theme_Dark_Palette_Navigation_InvertActionsColors = this.Theme_Dark_Palette_Navigation_InvertActionsColors;
            context.Theme_Dark_Palette_Navigation_Text = this.Theme_Dark_Palette_Navigation_Text;
            context.Theme_Dark_Palette_Navigation_TextActive = this.Theme_Dark_Palette_Navigation_TextActive;
            context.Theme_Dark_Palette_Navigation_TextBackgroundActive = this.Theme_Dark_Palette_Navigation_TextBackgroundActive;
            context.Theme_Dark_Palette_Navigation_TextBackgroundHover = this.Theme_Dark_Palette_Navigation_TextBackgroundHover;
            context.Theme_Dark_Palette_Navigation_TextHover = this.Theme_Dark_Palette_Navigation_TextHover;
            context.Theme_Dark_Palette_Primary_Active = this.Theme_Dark_Palette_Primary_Active;
            context.Theme_Dark_Palette_Primary_ContrastText = this.Theme_Dark_Palette_Primary_ContrastText;
            context.Theme_Dark_Palette_Primary_Default = this.Theme_Dark_Palette_Primary_Default;
            context.Theme_Dark_Typography_FontFamily_Default = this.Theme_Dark_Typography_FontFamily_Default;
            context.Theme_Light_Images_Logo_Default = this.Theme_Light_Images_Logo_Default;
            context.Theme_Light_Images_Logo_Favicon = this.Theme_Light_Images_Logo_Favicon;
            context.Theme_Light_Palette_Canvas_ActiveBackground = this.Theme_Light_Palette_Canvas_ActiveBackground;
            context.Theme_Light_Palette_Canvas_ContainerBackground = this.Theme_Light_Palette_Canvas_ContainerBackground;
            context.Theme_Light_Palette_Canvas_PageBackground = this.Theme_Light_Palette_Canvas_PageBackground;
            context.Theme_Light_Palette_Header_Background = this.Theme_Light_Palette_Header_Background;
            context.Theme_Light_Palette_Header_InvertActionsColors = this.Theme_Light_Palette_Header_InvertActionsColors;
            context.Theme_Light_Palette_Header_Text = this.Theme_Light_Palette_Header_Text;
            context.Theme_Light_Palette_Header_TextHover = this.Theme_Light_Palette_Header_TextHover;
            context.Theme_Light_Palette_Navigation_Background = this.Theme_Light_Palette_Navigation_Background;
            context.Theme_Light_Palette_Navigation_InvertActionsColors = this.Theme_Light_Palette_Navigation_InvertActionsColors;
            context.Theme_Light_Palette_Navigation_Text = this.Theme_Light_Palette_Navigation_Text;
            context.Theme_Light_Palette_Navigation_TextActive = this.Theme_Light_Palette_Navigation_TextActive;
            context.Theme_Light_Palette_Navigation_TextBackgroundActive = this.Theme_Light_Palette_Navigation_TextBackgroundActive;
            context.Theme_Light_Palette_Navigation_TextBackgroundHover = this.Theme_Light_Palette_Navigation_TextBackgroundHover;
            context.Theme_Light_Palette_Navigation_TextHover = this.Theme_Light_Palette_Navigation_TextHover;
            context.Theme_Light_Palette_Primary_Active = this.Theme_Light_Palette_Primary_Active;
            context.Theme_Light_Palette_Primary_ContrastText = this.Theme_Light_Palette_Primary_ContrastText;
            context.Theme_Light_Palette_Primary_Default = this.Theme_Light_Palette_Primary_Default;
            context.Theme_Light_Typography_FontFamily_Default = this.Theme_Light_Typography_FontFamily_Default;
            context.Title = this.Title;
            
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
            var request = new Amazon.Connect.Model.CreateWorkspaceRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Theme
            var requestThemeIsNull = true;
            request.Theme = new Amazon.Connect.Model.WorkspaceTheme();
            Amazon.Connect.Model.WorkspaceThemeConfig requestTheme_theme_Dark = null;
            
             // populate Dark
            var requestTheme_theme_DarkIsNull = true;
            requestTheme_theme_Dark = new Amazon.Connect.Model.WorkspaceThemeConfig();
            Amazon.Connect.Model.WorkspaceThemeImages requestTheme_theme_Dark_theme_Dark_Images = null;
            
             // populate Images
            var requestTheme_theme_Dark_theme_Dark_ImagesIsNull = true;
            requestTheme_theme_Dark_theme_Dark_Images = new Amazon.Connect.Model.WorkspaceThemeImages();
            Amazon.Connect.Model.ImagesLogo requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo = null;
            
             // populate Logo
            var requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_LogoIsNull = true;
            requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo = new Amazon.Connect.Model.ImagesLogo();
            System.String requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo_theme_Dark_Images_Logo_Default = null;
            if (cmdletContext.Theme_Dark_Images_Logo_Default != null)
            {
                requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo_theme_Dark_Images_Logo_Default = cmdletContext.Theme_Dark_Images_Logo_Default;
            }
            if (requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo_theme_Dark_Images_Logo_Default != null)
            {
                requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo.Default = requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo_theme_Dark_Images_Logo_Default;
                requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_LogoIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo_theme_Dark_Images_Logo_Favicon = null;
            if (cmdletContext.Theme_Dark_Images_Logo_Favicon != null)
            {
                requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo_theme_Dark_Images_Logo_Favicon = cmdletContext.Theme_Dark_Images_Logo_Favicon;
            }
            if (requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo_theme_Dark_Images_Logo_Favicon != null)
            {
                requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo.Favicon = requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo_theme_Dark_Images_Logo_Favicon;
                requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_LogoIsNull = false;
            }
             // determine if requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo should be set to null
            if (requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_LogoIsNull)
            {
                requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo = null;
            }
            if (requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo != null)
            {
                requestTheme_theme_Dark_theme_Dark_Images.Logo = requestTheme_theme_Dark_theme_Dark_Images_theme_Dark_Images_Logo;
                requestTheme_theme_Dark_theme_Dark_ImagesIsNull = false;
            }
             // determine if requestTheme_theme_Dark_theme_Dark_Images should be set to null
            if (requestTheme_theme_Dark_theme_Dark_ImagesIsNull)
            {
                requestTheme_theme_Dark_theme_Dark_Images = null;
            }
            if (requestTheme_theme_Dark_theme_Dark_Images != null)
            {
                requestTheme_theme_Dark.Images = requestTheme_theme_Dark_theme_Dark_Images;
                requestTheme_theme_DarkIsNull = false;
            }
            Amazon.Connect.Model.WorkspaceThemeTypography requestTheme_theme_Dark_theme_Dark_Typography = null;
            
             // populate Typography
            var requestTheme_theme_Dark_theme_Dark_TypographyIsNull = true;
            requestTheme_theme_Dark_theme_Dark_Typography = new Amazon.Connect.Model.WorkspaceThemeTypography();
            Amazon.Connect.Model.FontFamily requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily = null;
            
             // populate FontFamily
            var requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamilyIsNull = true;
            requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily = new Amazon.Connect.Model.FontFamily();
            Amazon.Connect.WorkspaceFontFamily requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily_theme_Dark_Typography_FontFamily_Default = null;
            if (cmdletContext.Theme_Dark_Typography_FontFamily_Default != null)
            {
                requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily_theme_Dark_Typography_FontFamily_Default = cmdletContext.Theme_Dark_Typography_FontFamily_Default;
            }
            if (requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily_theme_Dark_Typography_FontFamily_Default != null)
            {
                requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily.Default = requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily_theme_Dark_Typography_FontFamily_Default;
                requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamilyIsNull = false;
            }
             // determine if requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily should be set to null
            if (requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamilyIsNull)
            {
                requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily = null;
            }
            if (requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily != null)
            {
                requestTheme_theme_Dark_theme_Dark_Typography.FontFamily = requestTheme_theme_Dark_theme_Dark_Typography_theme_Dark_Typography_FontFamily;
                requestTheme_theme_Dark_theme_Dark_TypographyIsNull = false;
            }
             // determine if requestTheme_theme_Dark_theme_Dark_Typography should be set to null
            if (requestTheme_theme_Dark_theme_Dark_TypographyIsNull)
            {
                requestTheme_theme_Dark_theme_Dark_Typography = null;
            }
            if (requestTheme_theme_Dark_theme_Dark_Typography != null)
            {
                requestTheme_theme_Dark.Typography = requestTheme_theme_Dark_theme_Dark_Typography;
                requestTheme_theme_DarkIsNull = false;
            }
            Amazon.Connect.Model.WorkspaceThemePalette requestTheme_theme_Dark_theme_Dark_Palette = null;
            
             // populate Palette
            var requestTheme_theme_Dark_theme_Dark_PaletteIsNull = true;
            requestTheme_theme_Dark_theme_Dark_Palette = new Amazon.Connect.Model.WorkspaceThemePalette();
            Amazon.Connect.Model.PaletteCanvas requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas = null;
            
             // populate Canvas
            var requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_CanvasIsNull = true;
            requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas = new Amazon.Connect.Model.PaletteCanvas();
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_ActiveBackground = null;
            if (cmdletContext.Theme_Dark_Palette_Canvas_ActiveBackground != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_ActiveBackground = cmdletContext.Theme_Dark_Palette_Canvas_ActiveBackground;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_ActiveBackground != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas.ActiveBackground = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_ActiveBackground;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_CanvasIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_ContainerBackground = null;
            if (cmdletContext.Theme_Dark_Palette_Canvas_ContainerBackground != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_ContainerBackground = cmdletContext.Theme_Dark_Palette_Canvas_ContainerBackground;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_ContainerBackground != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas.ContainerBackground = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_ContainerBackground;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_CanvasIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_PageBackground = null;
            if (cmdletContext.Theme_Dark_Palette_Canvas_PageBackground != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_PageBackground = cmdletContext.Theme_Dark_Palette_Canvas_PageBackground;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_PageBackground != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas.PageBackground = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas_theme_Dark_Palette_Canvas_PageBackground;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_CanvasIsNull = false;
            }
             // determine if requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas should be set to null
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_CanvasIsNull)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas = null;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette.Canvas = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Canvas;
                requestTheme_theme_Dark_theme_Dark_PaletteIsNull = false;
            }
            Amazon.Connect.Model.PalettePrimary requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary = null;
            
             // populate Primary
            var requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_PrimaryIsNull = true;
            requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary = new Amazon.Connect.Model.PalettePrimary();
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_Active = null;
            if (cmdletContext.Theme_Dark_Palette_Primary_Active != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_Active = cmdletContext.Theme_Dark_Palette_Primary_Active;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_Active != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary.Active = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_Active;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_PrimaryIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_ContrastText = null;
            if (cmdletContext.Theme_Dark_Palette_Primary_ContrastText != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_ContrastText = cmdletContext.Theme_Dark_Palette_Primary_ContrastText;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_ContrastText != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary.ContrastText = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_ContrastText;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_PrimaryIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_Default = null;
            if (cmdletContext.Theme_Dark_Palette_Primary_Default != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_Default = cmdletContext.Theme_Dark_Palette_Primary_Default;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_Default != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary.Default = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary_theme_Dark_Palette_Primary_Default;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_PrimaryIsNull = false;
            }
             // determine if requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary should be set to null
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_PrimaryIsNull)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary = null;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette.Primary = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Primary;
                requestTheme_theme_Dark_theme_Dark_PaletteIsNull = false;
            }
            Amazon.Connect.Model.PaletteHeader requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header = null;
            
             // populate Header
            var requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_HeaderIsNull = true;
            requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header = new Amazon.Connect.Model.PaletteHeader();
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_Background = null;
            if (cmdletContext.Theme_Dark_Palette_Header_Background != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_Background = cmdletContext.Theme_Dark_Palette_Header_Background;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_Background != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header.Background = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_Background;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_HeaderIsNull = false;
            }
            System.Boolean? requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_InvertActionsColors = null;
            if (cmdletContext.Theme_Dark_Palette_Header_InvertActionsColors != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_InvertActionsColors = cmdletContext.Theme_Dark_Palette_Header_InvertActionsColors.Value;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_InvertActionsColors != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header.InvertActionsColors = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_InvertActionsColors.Value;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_HeaderIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_Text = null;
            if (cmdletContext.Theme_Dark_Palette_Header_Text != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_Text = cmdletContext.Theme_Dark_Palette_Header_Text;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_Text != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header.Text = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_Text;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_HeaderIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_TextHover = null;
            if (cmdletContext.Theme_Dark_Palette_Header_TextHover != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_TextHover = cmdletContext.Theme_Dark_Palette_Header_TextHover;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_TextHover != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header.TextHover = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header_theme_Dark_Palette_Header_TextHover;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_HeaderIsNull = false;
            }
             // determine if requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header should be set to null
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_HeaderIsNull)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header = null;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette.Header = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Header;
                requestTheme_theme_Dark_theme_Dark_PaletteIsNull = false;
            }
            Amazon.Connect.Model.PaletteNavigation requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation = null;
            
             // populate Navigation
            var requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_NavigationIsNull = true;
            requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation = new Amazon.Connect.Model.PaletteNavigation();
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_Background = null;
            if (cmdletContext.Theme_Dark_Palette_Navigation_Background != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_Background = cmdletContext.Theme_Dark_Palette_Navigation_Background;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_Background != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation.Background = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_Background;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_NavigationIsNull = false;
            }
            System.Boolean? requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_InvertActionsColors = null;
            if (cmdletContext.Theme_Dark_Palette_Navigation_InvertActionsColors != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_InvertActionsColors = cmdletContext.Theme_Dark_Palette_Navigation_InvertActionsColors.Value;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_InvertActionsColors != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation.InvertActionsColors = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_InvertActionsColors.Value;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_NavigationIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_Text = null;
            if (cmdletContext.Theme_Dark_Palette_Navigation_Text != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_Text = cmdletContext.Theme_Dark_Palette_Navigation_Text;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_Text != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation.Text = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_Text;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_NavigationIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextActive = null;
            if (cmdletContext.Theme_Dark_Palette_Navigation_TextActive != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextActive = cmdletContext.Theme_Dark_Palette_Navigation_TextActive;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextActive != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation.TextActive = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextActive;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_NavigationIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextBackgroundActive = null;
            if (cmdletContext.Theme_Dark_Palette_Navigation_TextBackgroundActive != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextBackgroundActive = cmdletContext.Theme_Dark_Palette_Navigation_TextBackgroundActive;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextBackgroundActive != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation.TextBackgroundActive = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextBackgroundActive;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_NavigationIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextBackgroundHover = null;
            if (cmdletContext.Theme_Dark_Palette_Navigation_TextBackgroundHover != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextBackgroundHover = cmdletContext.Theme_Dark_Palette_Navigation_TextBackgroundHover;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextBackgroundHover != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation.TextBackgroundHover = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextBackgroundHover;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_NavigationIsNull = false;
            }
            System.String requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextHover = null;
            if (cmdletContext.Theme_Dark_Palette_Navigation_TextHover != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextHover = cmdletContext.Theme_Dark_Palette_Navigation_TextHover;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextHover != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation.TextHover = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation_theme_Dark_Palette_Navigation_TextHover;
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_NavigationIsNull = false;
            }
             // determine if requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation should be set to null
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_NavigationIsNull)
            {
                requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation = null;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation != null)
            {
                requestTheme_theme_Dark_theme_Dark_Palette.Navigation = requestTheme_theme_Dark_theme_Dark_Palette_theme_Dark_Palette_Navigation;
                requestTheme_theme_Dark_theme_Dark_PaletteIsNull = false;
            }
             // determine if requestTheme_theme_Dark_theme_Dark_Palette should be set to null
            if (requestTheme_theme_Dark_theme_Dark_PaletteIsNull)
            {
                requestTheme_theme_Dark_theme_Dark_Palette = null;
            }
            if (requestTheme_theme_Dark_theme_Dark_Palette != null)
            {
                requestTheme_theme_Dark.Palette = requestTheme_theme_Dark_theme_Dark_Palette;
                requestTheme_theme_DarkIsNull = false;
            }
             // determine if requestTheme_theme_Dark should be set to null
            if (requestTheme_theme_DarkIsNull)
            {
                requestTheme_theme_Dark = null;
            }
            if (requestTheme_theme_Dark != null)
            {
                request.Theme.Dark = requestTheme_theme_Dark;
                requestThemeIsNull = false;
            }
            Amazon.Connect.Model.WorkspaceThemeConfig requestTheme_theme_Light = null;
            
             // populate Light
            var requestTheme_theme_LightIsNull = true;
            requestTheme_theme_Light = new Amazon.Connect.Model.WorkspaceThemeConfig();
            Amazon.Connect.Model.WorkspaceThemeImages requestTheme_theme_Light_theme_Light_Images = null;
            
             // populate Images
            var requestTheme_theme_Light_theme_Light_ImagesIsNull = true;
            requestTheme_theme_Light_theme_Light_Images = new Amazon.Connect.Model.WorkspaceThemeImages();
            Amazon.Connect.Model.ImagesLogo requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo = null;
            
             // populate Logo
            var requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_LogoIsNull = true;
            requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo = new Amazon.Connect.Model.ImagesLogo();
            System.String requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo_theme_Light_Images_Logo_Default = null;
            if (cmdletContext.Theme_Light_Images_Logo_Default != null)
            {
                requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo_theme_Light_Images_Logo_Default = cmdletContext.Theme_Light_Images_Logo_Default;
            }
            if (requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo_theme_Light_Images_Logo_Default != null)
            {
                requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo.Default = requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo_theme_Light_Images_Logo_Default;
                requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_LogoIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo_theme_Light_Images_Logo_Favicon = null;
            if (cmdletContext.Theme_Light_Images_Logo_Favicon != null)
            {
                requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo_theme_Light_Images_Logo_Favicon = cmdletContext.Theme_Light_Images_Logo_Favicon;
            }
            if (requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo_theme_Light_Images_Logo_Favicon != null)
            {
                requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo.Favicon = requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo_theme_Light_Images_Logo_Favicon;
                requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_LogoIsNull = false;
            }
             // determine if requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo should be set to null
            if (requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_LogoIsNull)
            {
                requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo = null;
            }
            if (requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo != null)
            {
                requestTheme_theme_Light_theme_Light_Images.Logo = requestTheme_theme_Light_theme_Light_Images_theme_Light_Images_Logo;
                requestTheme_theme_Light_theme_Light_ImagesIsNull = false;
            }
             // determine if requestTheme_theme_Light_theme_Light_Images should be set to null
            if (requestTheme_theme_Light_theme_Light_ImagesIsNull)
            {
                requestTheme_theme_Light_theme_Light_Images = null;
            }
            if (requestTheme_theme_Light_theme_Light_Images != null)
            {
                requestTheme_theme_Light.Images = requestTheme_theme_Light_theme_Light_Images;
                requestTheme_theme_LightIsNull = false;
            }
            Amazon.Connect.Model.WorkspaceThemeTypography requestTheme_theme_Light_theme_Light_Typography = null;
            
             // populate Typography
            var requestTheme_theme_Light_theme_Light_TypographyIsNull = true;
            requestTheme_theme_Light_theme_Light_Typography = new Amazon.Connect.Model.WorkspaceThemeTypography();
            Amazon.Connect.Model.FontFamily requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily = null;
            
             // populate FontFamily
            var requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamilyIsNull = true;
            requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily = new Amazon.Connect.Model.FontFamily();
            Amazon.Connect.WorkspaceFontFamily requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily_theme_Light_Typography_FontFamily_Default = null;
            if (cmdletContext.Theme_Light_Typography_FontFamily_Default != null)
            {
                requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily_theme_Light_Typography_FontFamily_Default = cmdletContext.Theme_Light_Typography_FontFamily_Default;
            }
            if (requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily_theme_Light_Typography_FontFamily_Default != null)
            {
                requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily.Default = requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily_theme_Light_Typography_FontFamily_Default;
                requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamilyIsNull = false;
            }
             // determine if requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily should be set to null
            if (requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamilyIsNull)
            {
                requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily = null;
            }
            if (requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily != null)
            {
                requestTheme_theme_Light_theme_Light_Typography.FontFamily = requestTheme_theme_Light_theme_Light_Typography_theme_Light_Typography_FontFamily;
                requestTheme_theme_Light_theme_Light_TypographyIsNull = false;
            }
             // determine if requestTheme_theme_Light_theme_Light_Typography should be set to null
            if (requestTheme_theme_Light_theme_Light_TypographyIsNull)
            {
                requestTheme_theme_Light_theme_Light_Typography = null;
            }
            if (requestTheme_theme_Light_theme_Light_Typography != null)
            {
                requestTheme_theme_Light.Typography = requestTheme_theme_Light_theme_Light_Typography;
                requestTheme_theme_LightIsNull = false;
            }
            Amazon.Connect.Model.WorkspaceThemePalette requestTheme_theme_Light_theme_Light_Palette = null;
            
             // populate Palette
            var requestTheme_theme_Light_theme_Light_PaletteIsNull = true;
            requestTheme_theme_Light_theme_Light_Palette = new Amazon.Connect.Model.WorkspaceThemePalette();
            Amazon.Connect.Model.PaletteCanvas requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas = null;
            
             // populate Canvas
            var requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_CanvasIsNull = true;
            requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas = new Amazon.Connect.Model.PaletteCanvas();
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_ActiveBackground = null;
            if (cmdletContext.Theme_Light_Palette_Canvas_ActiveBackground != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_ActiveBackground = cmdletContext.Theme_Light_Palette_Canvas_ActiveBackground;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_ActiveBackground != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas.ActiveBackground = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_ActiveBackground;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_CanvasIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_ContainerBackground = null;
            if (cmdletContext.Theme_Light_Palette_Canvas_ContainerBackground != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_ContainerBackground = cmdletContext.Theme_Light_Palette_Canvas_ContainerBackground;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_ContainerBackground != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas.ContainerBackground = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_ContainerBackground;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_CanvasIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_PageBackground = null;
            if (cmdletContext.Theme_Light_Palette_Canvas_PageBackground != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_PageBackground = cmdletContext.Theme_Light_Palette_Canvas_PageBackground;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_PageBackground != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas.PageBackground = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas_theme_Light_Palette_Canvas_PageBackground;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_CanvasIsNull = false;
            }
             // determine if requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas should be set to null
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_CanvasIsNull)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas = null;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas != null)
            {
                requestTheme_theme_Light_theme_Light_Palette.Canvas = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Canvas;
                requestTheme_theme_Light_theme_Light_PaletteIsNull = false;
            }
            Amazon.Connect.Model.PalettePrimary requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary = null;
            
             // populate Primary
            var requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_PrimaryIsNull = true;
            requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary = new Amazon.Connect.Model.PalettePrimary();
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_Active = null;
            if (cmdletContext.Theme_Light_Palette_Primary_Active != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_Active = cmdletContext.Theme_Light_Palette_Primary_Active;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_Active != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary.Active = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_Active;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_PrimaryIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_ContrastText = null;
            if (cmdletContext.Theme_Light_Palette_Primary_ContrastText != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_ContrastText = cmdletContext.Theme_Light_Palette_Primary_ContrastText;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_ContrastText != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary.ContrastText = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_ContrastText;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_PrimaryIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_Default = null;
            if (cmdletContext.Theme_Light_Palette_Primary_Default != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_Default = cmdletContext.Theme_Light_Palette_Primary_Default;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_Default != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary.Default = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary_theme_Light_Palette_Primary_Default;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_PrimaryIsNull = false;
            }
             // determine if requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary should be set to null
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_PrimaryIsNull)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary = null;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary != null)
            {
                requestTheme_theme_Light_theme_Light_Palette.Primary = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Primary;
                requestTheme_theme_Light_theme_Light_PaletteIsNull = false;
            }
            Amazon.Connect.Model.PaletteHeader requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header = null;
            
             // populate Header
            var requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_HeaderIsNull = true;
            requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header = new Amazon.Connect.Model.PaletteHeader();
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_Background = null;
            if (cmdletContext.Theme_Light_Palette_Header_Background != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_Background = cmdletContext.Theme_Light_Palette_Header_Background;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_Background != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header.Background = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_Background;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_HeaderIsNull = false;
            }
            System.Boolean? requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_InvertActionsColors = null;
            if (cmdletContext.Theme_Light_Palette_Header_InvertActionsColors != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_InvertActionsColors = cmdletContext.Theme_Light_Palette_Header_InvertActionsColors.Value;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_InvertActionsColors != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header.InvertActionsColors = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_InvertActionsColors.Value;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_HeaderIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_Text = null;
            if (cmdletContext.Theme_Light_Palette_Header_Text != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_Text = cmdletContext.Theme_Light_Palette_Header_Text;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_Text != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header.Text = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_Text;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_HeaderIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_TextHover = null;
            if (cmdletContext.Theme_Light_Palette_Header_TextHover != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_TextHover = cmdletContext.Theme_Light_Palette_Header_TextHover;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_TextHover != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header.TextHover = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header_theme_Light_Palette_Header_TextHover;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_HeaderIsNull = false;
            }
             // determine if requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header should be set to null
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_HeaderIsNull)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header = null;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header != null)
            {
                requestTheme_theme_Light_theme_Light_Palette.Header = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Header;
                requestTheme_theme_Light_theme_Light_PaletteIsNull = false;
            }
            Amazon.Connect.Model.PaletteNavigation requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation = null;
            
             // populate Navigation
            var requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_NavigationIsNull = true;
            requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation = new Amazon.Connect.Model.PaletteNavigation();
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_Background = null;
            if (cmdletContext.Theme_Light_Palette_Navigation_Background != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_Background = cmdletContext.Theme_Light_Palette_Navigation_Background;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_Background != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation.Background = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_Background;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_NavigationIsNull = false;
            }
            System.Boolean? requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_InvertActionsColors = null;
            if (cmdletContext.Theme_Light_Palette_Navigation_InvertActionsColors != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_InvertActionsColors = cmdletContext.Theme_Light_Palette_Navigation_InvertActionsColors.Value;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_InvertActionsColors != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation.InvertActionsColors = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_InvertActionsColors.Value;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_NavigationIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_Text = null;
            if (cmdletContext.Theme_Light_Palette_Navigation_Text != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_Text = cmdletContext.Theme_Light_Palette_Navigation_Text;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_Text != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation.Text = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_Text;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_NavigationIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextActive = null;
            if (cmdletContext.Theme_Light_Palette_Navigation_TextActive != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextActive = cmdletContext.Theme_Light_Palette_Navigation_TextActive;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextActive != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation.TextActive = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextActive;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_NavigationIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextBackgroundActive = null;
            if (cmdletContext.Theme_Light_Palette_Navigation_TextBackgroundActive != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextBackgroundActive = cmdletContext.Theme_Light_Palette_Navigation_TextBackgroundActive;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextBackgroundActive != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation.TextBackgroundActive = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextBackgroundActive;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_NavigationIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextBackgroundHover = null;
            if (cmdletContext.Theme_Light_Palette_Navigation_TextBackgroundHover != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextBackgroundHover = cmdletContext.Theme_Light_Palette_Navigation_TextBackgroundHover;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextBackgroundHover != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation.TextBackgroundHover = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextBackgroundHover;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_NavigationIsNull = false;
            }
            System.String requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextHover = null;
            if (cmdletContext.Theme_Light_Palette_Navigation_TextHover != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextHover = cmdletContext.Theme_Light_Palette_Navigation_TextHover;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextHover != null)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation.TextHover = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation_theme_Light_Palette_Navigation_TextHover;
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_NavigationIsNull = false;
            }
             // determine if requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation should be set to null
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_NavigationIsNull)
            {
                requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation = null;
            }
            if (requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation != null)
            {
                requestTheme_theme_Light_theme_Light_Palette.Navigation = requestTheme_theme_Light_theme_Light_Palette_theme_Light_Palette_Navigation;
                requestTheme_theme_Light_theme_Light_PaletteIsNull = false;
            }
             // determine if requestTheme_theme_Light_theme_Light_Palette should be set to null
            if (requestTheme_theme_Light_theme_Light_PaletteIsNull)
            {
                requestTheme_theme_Light_theme_Light_Palette = null;
            }
            if (requestTheme_theme_Light_theme_Light_Palette != null)
            {
                requestTheme_theme_Light.Palette = requestTheme_theme_Light_theme_Light_Palette;
                requestTheme_theme_LightIsNull = false;
            }
             // determine if requestTheme_theme_Light should be set to null
            if (requestTheme_theme_LightIsNull)
            {
                requestTheme_theme_Light = null;
            }
            if (requestTheme_theme_Light != null)
            {
                request.Theme.Light = requestTheme_theme_Light;
                requestThemeIsNull = false;
            }
             // determine if request.Theme should be set to null
            if (requestThemeIsNull)
            {
                request.Theme = null;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.Connect.Model.CreateWorkspaceResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateWorkspaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateWorkspace");
            try
            {
                #if DESKTOP
                return client.CreateWorkspace(request);
                #elif CORECLR
                return client.CreateWorkspaceAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Theme_Dark_Images_Logo_Default { get; set; }
            public System.String Theme_Dark_Images_Logo_Favicon { get; set; }
            public System.String Theme_Dark_Palette_Canvas_ActiveBackground { get; set; }
            public System.String Theme_Dark_Palette_Canvas_ContainerBackground { get; set; }
            public System.String Theme_Dark_Palette_Canvas_PageBackground { get; set; }
            public System.String Theme_Dark_Palette_Header_Background { get; set; }
            public System.Boolean? Theme_Dark_Palette_Header_InvertActionsColors { get; set; }
            public System.String Theme_Dark_Palette_Header_Text { get; set; }
            public System.String Theme_Dark_Palette_Header_TextHover { get; set; }
            public System.String Theme_Dark_Palette_Navigation_Background { get; set; }
            public System.Boolean? Theme_Dark_Palette_Navigation_InvertActionsColors { get; set; }
            public System.String Theme_Dark_Palette_Navigation_Text { get; set; }
            public System.String Theme_Dark_Palette_Navigation_TextActive { get; set; }
            public System.String Theme_Dark_Palette_Navigation_TextBackgroundActive { get; set; }
            public System.String Theme_Dark_Palette_Navigation_TextBackgroundHover { get; set; }
            public System.String Theme_Dark_Palette_Navigation_TextHover { get; set; }
            public System.String Theme_Dark_Palette_Primary_Active { get; set; }
            public System.String Theme_Dark_Palette_Primary_ContrastText { get; set; }
            public System.String Theme_Dark_Palette_Primary_Default { get; set; }
            public Amazon.Connect.WorkspaceFontFamily Theme_Dark_Typography_FontFamily_Default { get; set; }
            public System.String Theme_Light_Images_Logo_Default { get; set; }
            public System.String Theme_Light_Images_Logo_Favicon { get; set; }
            public System.String Theme_Light_Palette_Canvas_ActiveBackground { get; set; }
            public System.String Theme_Light_Palette_Canvas_ContainerBackground { get; set; }
            public System.String Theme_Light_Palette_Canvas_PageBackground { get; set; }
            public System.String Theme_Light_Palette_Header_Background { get; set; }
            public System.Boolean? Theme_Light_Palette_Header_InvertActionsColors { get; set; }
            public System.String Theme_Light_Palette_Header_Text { get; set; }
            public System.String Theme_Light_Palette_Header_TextHover { get; set; }
            public System.String Theme_Light_Palette_Navigation_Background { get; set; }
            public System.Boolean? Theme_Light_Palette_Navigation_InvertActionsColors { get; set; }
            public System.String Theme_Light_Palette_Navigation_Text { get; set; }
            public System.String Theme_Light_Palette_Navigation_TextActive { get; set; }
            public System.String Theme_Light_Palette_Navigation_TextBackgroundActive { get; set; }
            public System.String Theme_Light_Palette_Navigation_TextBackgroundHover { get; set; }
            public System.String Theme_Light_Palette_Navigation_TextHover { get; set; }
            public System.String Theme_Light_Palette_Primary_Active { get; set; }
            public System.String Theme_Light_Palette_Primary_ContrastText { get; set; }
            public System.String Theme_Light_Palette_Primary_Default { get; set; }
            public Amazon.Connect.WorkspaceFontFamily Theme_Light_Typography_FontFamily_Default { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.Connect.Model.CreateWorkspaceResponse, NewCONNWorkspaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
