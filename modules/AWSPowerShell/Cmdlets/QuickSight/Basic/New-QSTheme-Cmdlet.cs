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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates a theme.
    /// 
    ///  
    /// <para>
    /// A <i>theme</i> is set of configuration options for color and layout. Themes apply
    /// to analyses and dashboards. For more information, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/themes-in-quicksight.html">Using
    /// Themes in Amazon QuickSight</a> in the <i>Amazon QuickSight User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QSTheme", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateThemeResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateTheme API operation.", Operation = new[] {"CreateTheme"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateThemeResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateThemeResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateThemeResponse object containing multiple properties."
    )]
    public partial class NewQSThemeCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter UIColorPalette_Accent
        /// <summary>
        /// <para>
        /// <para>This color is that applies to selected states and buttons.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_Accent")]
        public System.String UIColorPalette_Accent { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_AccentForeground
        /// <summary>
        /// <para>
        /// <para>The foreground color that applies to any text or other elements that appear over the
        /// accent color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_AccentForeground")]
        public System.String UIColorPalette_AccentForeground { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account where you want to store the new theme. </para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter BaseThemeId
        /// <summary>
        /// <para>
        /// <para>The ID of the theme that a custom theme will inherit from. All themes inherit from
        /// one of the starting themes defined by Amazon QuickSight. For a list of the starting
        /// themes, use <c>ListThemes</c> or choose <b>Themes</b> from within an analysis. </para>
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
        public System.String BaseThemeId { get; set; }
        #endregion
        
        #region Parameter DataColorPalette_Color
        /// <summary>
        /// <para>
        /// <para>The hexadecimal codes for the colors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_DataColorPalette_Colors")]
        public System.String[] DataColorPalette_Color { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_Danger
        /// <summary>
        /// <para>
        /// <para>The color that applies to error messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_Danger")]
        public System.String UIColorPalette_Danger { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_DangerForeground
        /// <summary>
        /// <para>
        /// <para>The foreground color that applies to any text or other elements that appear over the
        /// error color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_DangerForeground")]
        public System.String UIColorPalette_DangerForeground { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_Dimension
        /// <summary>
        /// <para>
        /// <para>The color that applies to the names of fields that are identified as dimensions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_Dimension")]
        public System.String UIColorPalette_Dimension { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_DimensionForeground
        /// <summary>
        /// <para>
        /// <para>The foreground color that applies to any text or other elements that appear over the
        /// dimension color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_DimensionForeground")]
        public System.String UIColorPalette_DimensionForeground { get; set; }
        #endregion
        
        #region Parameter DataColorPalette_EmptyFillColor
        /// <summary>
        /// <para>
        /// <para>The hexadecimal code of a color that applies to charts where a lack of data is highlighted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_DataColorPalette_EmptyFillColor")]
        public System.String DataColorPalette_EmptyFillColor { get; set; }
        #endregion
        
        #region Parameter Typography_FontFamily
        /// <summary>
        /// <para>
        /// <para>Determines the list of font families.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_FontFamilies")]
        public Amazon.QuickSight.Model.Font[] Typography_FontFamily { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_Measure
        /// <summary>
        /// <para>
        /// <para>The color that applies to the names of fields that are identified as measures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_Measure")]
        public System.String UIColorPalette_Measure { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_MeasureForeground
        /// <summary>
        /// <para>
        /// <para>The foreground color that applies to any text or other elements that appear over the
        /// measure color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_MeasureForeground")]
        public System.String UIColorPalette_MeasureForeground { get; set; }
        #endregion
        
        #region Parameter DataColorPalette_MinMaxGradient
        /// <summary>
        /// <para>
        /// <para>The minimum and maximum hexadecimal codes that describe a color gradient. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_DataColorPalette_MinMaxGradient")]
        public System.String[] DataColorPalette_MinMaxGradient { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A display name for the theme.</para>
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
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>A valid grouping of resource permissions to apply to the new theme. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permissions")]
        public Amazon.QuickSight.Model.ResourcePermission[] Permission { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_PrimaryBackground
        /// <summary>
        /// <para>
        /// <para>The background color that applies to visuals and other high emphasis UI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_PrimaryBackground")]
        public System.String UIColorPalette_PrimaryBackground { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_PrimaryForeground
        /// <summary>
        /// <para>
        /// <para>The color of text and other foreground elements that appear over the primary background
        /// regions, such as grid lines, borders, table banding, icons, and so on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_PrimaryForeground")]
        public System.String UIColorPalette_PrimaryForeground { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_SecondaryBackground
        /// <summary>
        /// <para>
        /// <para>The background color that applies to the sheet background and sheet controls.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_SecondaryBackground")]
        public System.String UIColorPalette_SecondaryBackground { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_SecondaryForeground
        /// <summary>
        /// <para>
        /// <para>The foreground color that applies to any sheet title, sheet control text, or UI that
        /// appears over the secondary background.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_SecondaryForeground")]
        public System.String UIColorPalette_SecondaryForeground { get; set; }
        #endregion
        
        #region Parameter Border_Show
        /// <summary>
        /// <para>
        /// <para>The option to enable display of borders for visuals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Sheet_Tile_Border_Show")]
        public System.Boolean? Border_Show { get; set; }
        #endregion
        
        #region Parameter Gutter_Show
        /// <summary>
        /// <para>
        /// <para>This Boolean value controls whether to display a gutter space between sheet tiles.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Sheet_TileLayout_Gutter_Show")]
        public System.Boolean? Gutter_Show { get; set; }
        #endregion
        
        #region Parameter Margin_Show
        /// <summary>
        /// <para>
        /// <para>This Boolean value controls whether to display sheet margins.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Sheet_TileLayout_Margin_Show")]
        public System.Boolean? Margin_Show { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_Success
        /// <summary>
        /// <para>
        /// <para>The color that applies to success messages, for example the check mark for a successful
        /// download.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_Success")]
        public System.String UIColorPalette_Success { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_SuccessForeground
        /// <summary>
        /// <para>
        /// <para>The foreground color that applies to any text or other elements that appear over the
        /// success color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_SuccessForeground")]
        public System.String UIColorPalette_SuccessForeground { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of the key-value pairs for the resource tag or tags that you want to add to
        /// the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QuickSight.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ThemeId
        /// <summary>
        /// <para>
        /// <para>An ID for the theme that you want to create. The theme ID is unique per Amazon Web
        /// Services Region in each Amazon Web Services account.</para>
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
        public System.String ThemeId { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>A description of the first version of the theme that you're creating. Every time <c>UpdateTheme</c>
        /// is called, a new version is created. Each version of the theme has a description of
        /// the version in the <c>VersionDescription</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionDescription { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_Warning
        /// <summary>
        /// <para>
        /// <para>This color that applies to warning and informational messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_Warning")]
        public System.String UIColorPalette_Warning { get; set; }
        #endregion
        
        #region Parameter UIColorPalette_WarningForeground
        /// <summary>
        /// <para>
        /// <para>The foreground color that applies to any text or other elements that appear over the
        /// warning color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UIColorPalette_WarningForeground")]
        public System.String UIColorPalette_WarningForeground { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateThemeResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateThemeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThemeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSTheme (CreateTheme)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateThemeResponse, NewQSThemeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BaseThemeId = this.BaseThemeId;
            #if MODULAR
            if (this.BaseThemeId == null && ParameterWasBound(nameof(this.BaseThemeId)))
            {
                WriteWarning("You are passing $null as a value for parameter BaseThemeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DataColorPalette_Color != null)
            {
                context.DataColorPalette_Color = new List<System.String>(this.DataColorPalette_Color);
            }
            context.DataColorPalette_EmptyFillColor = this.DataColorPalette_EmptyFillColor;
            if (this.DataColorPalette_MinMaxGradient != null)
            {
                context.DataColorPalette_MinMaxGradient = new List<System.String>(this.DataColorPalette_MinMaxGradient);
            }
            context.Border_Show = this.Border_Show;
            context.Gutter_Show = this.Gutter_Show;
            context.Margin_Show = this.Margin_Show;
            if (this.Typography_FontFamily != null)
            {
                context.Typography_FontFamily = new List<Amazon.QuickSight.Model.Font>(this.Typography_FontFamily);
            }
            context.UIColorPalette_Accent = this.UIColorPalette_Accent;
            context.UIColorPalette_AccentForeground = this.UIColorPalette_AccentForeground;
            context.UIColorPalette_Danger = this.UIColorPalette_Danger;
            context.UIColorPalette_DangerForeground = this.UIColorPalette_DangerForeground;
            context.UIColorPalette_Dimension = this.UIColorPalette_Dimension;
            context.UIColorPalette_DimensionForeground = this.UIColorPalette_DimensionForeground;
            context.UIColorPalette_Measure = this.UIColorPalette_Measure;
            context.UIColorPalette_MeasureForeground = this.UIColorPalette_MeasureForeground;
            context.UIColorPalette_PrimaryBackground = this.UIColorPalette_PrimaryBackground;
            context.UIColorPalette_PrimaryForeground = this.UIColorPalette_PrimaryForeground;
            context.UIColorPalette_SecondaryBackground = this.UIColorPalette_SecondaryBackground;
            context.UIColorPalette_SecondaryForeground = this.UIColorPalette_SecondaryForeground;
            context.UIColorPalette_Success = this.UIColorPalette_Success;
            context.UIColorPalette_SuccessForeground = this.UIColorPalette_SuccessForeground;
            context.UIColorPalette_Warning = this.UIColorPalette_Warning;
            context.UIColorPalette_WarningForeground = this.UIColorPalette_WarningForeground;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Permission != null)
            {
                context.Permission = new List<Amazon.QuickSight.Model.ResourcePermission>(this.Permission);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
            }
            context.ThemeId = this.ThemeId;
            #if MODULAR
            if (this.ThemeId == null && ParameterWasBound(nameof(this.ThemeId)))
            {
                WriteWarning("You are passing $null as a value for parameter ThemeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VersionDescription = this.VersionDescription;
            
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
            var request = new Amazon.QuickSight.Model.CreateThemeRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.BaseThemeId != null)
            {
                request.BaseThemeId = cmdletContext.BaseThemeId;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.QuickSight.Model.ThemeConfiguration();
            Amazon.QuickSight.Model.Typography requestConfiguration_configuration_Typography = null;
            
             // populate Typography
            var requestConfiguration_configuration_TypographyIsNull = true;
            requestConfiguration_configuration_Typography = new Amazon.QuickSight.Model.Typography();
            List<Amazon.QuickSight.Model.Font> requestConfiguration_configuration_Typography_typography_FontFamily = null;
            if (cmdletContext.Typography_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_typography_FontFamily = cmdletContext.Typography_FontFamily;
            }
            if (requestConfiguration_configuration_Typography_typography_FontFamily != null)
            {
                requestConfiguration_configuration_Typography.FontFamilies = requestConfiguration_configuration_Typography_typography_FontFamily;
                requestConfiguration_configuration_TypographyIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography should be set to null
            if (requestConfiguration_configuration_TypographyIsNull)
            {
                requestConfiguration_configuration_Typography = null;
            }
            if (requestConfiguration_configuration_Typography != null)
            {
                request.Configuration.Typography = requestConfiguration_configuration_Typography;
                requestConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.SheetStyle requestConfiguration_configuration_Sheet = null;
            
             // populate Sheet
            var requestConfiguration_configuration_SheetIsNull = true;
            requestConfiguration_configuration_Sheet = new Amazon.QuickSight.Model.SheetStyle();
            Amazon.QuickSight.Model.TileStyle requestConfiguration_configuration_Sheet_configuration_Sheet_Tile = null;
            
             // populate Tile
            var requestConfiguration_configuration_Sheet_configuration_Sheet_TileIsNull = true;
            requestConfiguration_configuration_Sheet_configuration_Sheet_Tile = new Amazon.QuickSight.Model.TileStyle();
            Amazon.QuickSight.Model.BorderStyle requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border = null;
            
             // populate Border
            var requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_BorderIsNull = true;
            requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border = new Amazon.QuickSight.Model.BorderStyle();
            System.Boolean? requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Show = null;
            if (cmdletContext.Border_Show != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Show = cmdletContext.Border_Show.Value;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Show != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border.Show = requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Show.Value;
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_BorderIsNull = false;
            }
             // determine if requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border should be set to null
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_BorderIsNull)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border = null;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile.Border = requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border;
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileIsNull = false;
            }
             // determine if requestConfiguration_configuration_Sheet_configuration_Sheet_Tile should be set to null
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_TileIsNull)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile = null;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Tile != null)
            {
                requestConfiguration_configuration_Sheet.Tile = requestConfiguration_configuration_Sheet_configuration_Sheet_Tile;
                requestConfiguration_configuration_SheetIsNull = false;
            }
            Amazon.QuickSight.Model.TileLayoutStyle requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout = null;
            
             // populate TileLayout
            var requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayoutIsNull = true;
            requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout = new Amazon.QuickSight.Model.TileLayoutStyle();
            Amazon.QuickSight.Model.GutterStyle requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter = null;
            
             // populate Gutter
            var requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_GutterIsNull = true;
            requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter = new Amazon.QuickSight.Model.GutterStyle();
            System.Boolean? requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter_gutter_Show = null;
            if (cmdletContext.Gutter_Show != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter_gutter_Show = cmdletContext.Gutter_Show.Value;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter_gutter_Show != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter.Show = requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter_gutter_Show.Value;
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_GutterIsNull = false;
            }
             // determine if requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter should be set to null
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_GutterIsNull)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter = null;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout.Gutter = requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Gutter;
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayoutIsNull = false;
            }
            Amazon.QuickSight.Model.MarginStyle requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin = null;
            
             // populate Margin
            var requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_MarginIsNull = true;
            requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin = new Amazon.QuickSight.Model.MarginStyle();
            System.Boolean? requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin_margin_Show = null;
            if (cmdletContext.Margin_Show != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin_margin_Show = cmdletContext.Margin_Show.Value;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin_margin_Show != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin.Show = requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin_margin_Show.Value;
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_MarginIsNull = false;
            }
             // determine if requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin should be set to null
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_MarginIsNull)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin = null;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout.Margin = requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout_configuration_Sheet_TileLayout_Margin;
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayoutIsNull = false;
            }
             // determine if requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout should be set to null
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayoutIsNull)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout = null;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout != null)
            {
                requestConfiguration_configuration_Sheet.TileLayout = requestConfiguration_configuration_Sheet_configuration_Sheet_TileLayout;
                requestConfiguration_configuration_SheetIsNull = false;
            }
             // determine if requestConfiguration_configuration_Sheet should be set to null
            if (requestConfiguration_configuration_SheetIsNull)
            {
                requestConfiguration_configuration_Sheet = null;
            }
            if (requestConfiguration_configuration_Sheet != null)
            {
                request.Configuration.Sheet = requestConfiguration_configuration_Sheet;
                requestConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.DataColorPalette requestConfiguration_configuration_DataColorPalette = null;
            
             // populate DataColorPalette
            var requestConfiguration_configuration_DataColorPaletteIsNull = true;
            requestConfiguration_configuration_DataColorPalette = new Amazon.QuickSight.Model.DataColorPalette();
            List<System.String> requestConfiguration_configuration_DataColorPalette_dataColorPalette_Color = null;
            if (cmdletContext.DataColorPalette_Color != null)
            {
                requestConfiguration_configuration_DataColorPalette_dataColorPalette_Color = cmdletContext.DataColorPalette_Color;
            }
            if (requestConfiguration_configuration_DataColorPalette_dataColorPalette_Color != null)
            {
                requestConfiguration_configuration_DataColorPalette.Colors = requestConfiguration_configuration_DataColorPalette_dataColorPalette_Color;
                requestConfiguration_configuration_DataColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_DataColorPalette_dataColorPalette_EmptyFillColor = null;
            if (cmdletContext.DataColorPalette_EmptyFillColor != null)
            {
                requestConfiguration_configuration_DataColorPalette_dataColorPalette_EmptyFillColor = cmdletContext.DataColorPalette_EmptyFillColor;
            }
            if (requestConfiguration_configuration_DataColorPalette_dataColorPalette_EmptyFillColor != null)
            {
                requestConfiguration_configuration_DataColorPalette.EmptyFillColor = requestConfiguration_configuration_DataColorPalette_dataColorPalette_EmptyFillColor;
                requestConfiguration_configuration_DataColorPaletteIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_DataColorPalette_dataColorPalette_MinMaxGradient = null;
            if (cmdletContext.DataColorPalette_MinMaxGradient != null)
            {
                requestConfiguration_configuration_DataColorPalette_dataColorPalette_MinMaxGradient = cmdletContext.DataColorPalette_MinMaxGradient;
            }
            if (requestConfiguration_configuration_DataColorPalette_dataColorPalette_MinMaxGradient != null)
            {
                requestConfiguration_configuration_DataColorPalette.MinMaxGradient = requestConfiguration_configuration_DataColorPalette_dataColorPalette_MinMaxGradient;
                requestConfiguration_configuration_DataColorPaletteIsNull = false;
            }
             // determine if requestConfiguration_configuration_DataColorPalette should be set to null
            if (requestConfiguration_configuration_DataColorPaletteIsNull)
            {
                requestConfiguration_configuration_DataColorPalette = null;
            }
            if (requestConfiguration_configuration_DataColorPalette != null)
            {
                request.Configuration.DataColorPalette = requestConfiguration_configuration_DataColorPalette;
                requestConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.UIColorPalette requestConfiguration_configuration_UIColorPalette = null;
            
             // populate UIColorPalette
            var requestConfiguration_configuration_UIColorPaletteIsNull = true;
            requestConfiguration_configuration_UIColorPalette = new Amazon.QuickSight.Model.UIColorPalette();
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_Accent = null;
            if (cmdletContext.UIColorPalette_Accent != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_Accent = cmdletContext.UIColorPalette_Accent;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_Accent != null)
            {
                requestConfiguration_configuration_UIColorPalette.Accent = requestConfiguration_configuration_UIColorPalette_uIColorPalette_Accent;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_AccentForeground = null;
            if (cmdletContext.UIColorPalette_AccentForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_AccentForeground = cmdletContext.UIColorPalette_AccentForeground;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_AccentForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette.AccentForeground = requestConfiguration_configuration_UIColorPalette_uIColorPalette_AccentForeground;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_Danger = null;
            if (cmdletContext.UIColorPalette_Danger != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_Danger = cmdletContext.UIColorPalette_Danger;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_Danger != null)
            {
                requestConfiguration_configuration_UIColorPalette.Danger = requestConfiguration_configuration_UIColorPalette_uIColorPalette_Danger;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_DangerForeground = null;
            if (cmdletContext.UIColorPalette_DangerForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_DangerForeground = cmdletContext.UIColorPalette_DangerForeground;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_DangerForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette.DangerForeground = requestConfiguration_configuration_UIColorPalette_uIColorPalette_DangerForeground;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_Dimension = null;
            if (cmdletContext.UIColorPalette_Dimension != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_Dimension = cmdletContext.UIColorPalette_Dimension;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_Dimension != null)
            {
                requestConfiguration_configuration_UIColorPalette.Dimension = requestConfiguration_configuration_UIColorPalette_uIColorPalette_Dimension;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_DimensionForeground = null;
            if (cmdletContext.UIColorPalette_DimensionForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_DimensionForeground = cmdletContext.UIColorPalette_DimensionForeground;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_DimensionForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette.DimensionForeground = requestConfiguration_configuration_UIColorPalette_uIColorPalette_DimensionForeground;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_Measure = null;
            if (cmdletContext.UIColorPalette_Measure != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_Measure = cmdletContext.UIColorPalette_Measure;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_Measure != null)
            {
                requestConfiguration_configuration_UIColorPalette.Measure = requestConfiguration_configuration_UIColorPalette_uIColorPalette_Measure;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_MeasureForeground = null;
            if (cmdletContext.UIColorPalette_MeasureForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_MeasureForeground = cmdletContext.UIColorPalette_MeasureForeground;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_MeasureForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette.MeasureForeground = requestConfiguration_configuration_UIColorPalette_uIColorPalette_MeasureForeground;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_PrimaryBackground = null;
            if (cmdletContext.UIColorPalette_PrimaryBackground != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_PrimaryBackground = cmdletContext.UIColorPalette_PrimaryBackground;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_PrimaryBackground != null)
            {
                requestConfiguration_configuration_UIColorPalette.PrimaryBackground = requestConfiguration_configuration_UIColorPalette_uIColorPalette_PrimaryBackground;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_PrimaryForeground = null;
            if (cmdletContext.UIColorPalette_PrimaryForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_PrimaryForeground = cmdletContext.UIColorPalette_PrimaryForeground;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_PrimaryForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette.PrimaryForeground = requestConfiguration_configuration_UIColorPalette_uIColorPalette_PrimaryForeground;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_SecondaryBackground = null;
            if (cmdletContext.UIColorPalette_SecondaryBackground != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_SecondaryBackground = cmdletContext.UIColorPalette_SecondaryBackground;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_SecondaryBackground != null)
            {
                requestConfiguration_configuration_UIColorPalette.SecondaryBackground = requestConfiguration_configuration_UIColorPalette_uIColorPalette_SecondaryBackground;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_SecondaryForeground = null;
            if (cmdletContext.UIColorPalette_SecondaryForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_SecondaryForeground = cmdletContext.UIColorPalette_SecondaryForeground;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_SecondaryForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette.SecondaryForeground = requestConfiguration_configuration_UIColorPalette_uIColorPalette_SecondaryForeground;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_Success = null;
            if (cmdletContext.UIColorPalette_Success != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_Success = cmdletContext.UIColorPalette_Success;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_Success != null)
            {
                requestConfiguration_configuration_UIColorPalette.Success = requestConfiguration_configuration_UIColorPalette_uIColorPalette_Success;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_SuccessForeground = null;
            if (cmdletContext.UIColorPalette_SuccessForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_SuccessForeground = cmdletContext.UIColorPalette_SuccessForeground;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_SuccessForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette.SuccessForeground = requestConfiguration_configuration_UIColorPalette_uIColorPalette_SuccessForeground;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_Warning = null;
            if (cmdletContext.UIColorPalette_Warning != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_Warning = cmdletContext.UIColorPalette_Warning;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_Warning != null)
            {
                requestConfiguration_configuration_UIColorPalette.Warning = requestConfiguration_configuration_UIColorPalette_uIColorPalette_Warning;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
            System.String requestConfiguration_configuration_UIColorPalette_uIColorPalette_WarningForeground = null;
            if (cmdletContext.UIColorPalette_WarningForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette_uIColorPalette_WarningForeground = cmdletContext.UIColorPalette_WarningForeground;
            }
            if (requestConfiguration_configuration_UIColorPalette_uIColorPalette_WarningForeground != null)
            {
                requestConfiguration_configuration_UIColorPalette.WarningForeground = requestConfiguration_configuration_UIColorPalette_uIColorPalette_WarningForeground;
                requestConfiguration_configuration_UIColorPaletteIsNull = false;
            }
             // determine if requestConfiguration_configuration_UIColorPalette should be set to null
            if (requestConfiguration_configuration_UIColorPaletteIsNull)
            {
                requestConfiguration_configuration_UIColorPalette = null;
            }
            if (requestConfiguration_configuration_UIColorPalette != null)
            {
                request.Configuration.UIColorPalette = requestConfiguration_configuration_UIColorPalette;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permissions = cmdletContext.Permission;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ThemeId != null)
            {
                request.ThemeId = cmdletContext.ThemeId;
            }
            if (cmdletContext.VersionDescription != null)
            {
                request.VersionDescription = cmdletContext.VersionDescription;
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
        
        private Amazon.QuickSight.Model.CreateThemeResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateThemeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateTheme");
            try
            {
                return client.CreateThemeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String BaseThemeId { get; set; }
            public List<System.String> DataColorPalette_Color { get; set; }
            public System.String DataColorPalette_EmptyFillColor { get; set; }
            public List<System.String> DataColorPalette_MinMaxGradient { get; set; }
            public System.Boolean? Border_Show { get; set; }
            public System.Boolean? Gutter_Show { get; set; }
            public System.Boolean? Margin_Show { get; set; }
            public List<Amazon.QuickSight.Model.Font> Typography_FontFamily { get; set; }
            public System.String UIColorPalette_Accent { get; set; }
            public System.String UIColorPalette_AccentForeground { get; set; }
            public System.String UIColorPalette_Danger { get; set; }
            public System.String UIColorPalette_DangerForeground { get; set; }
            public System.String UIColorPalette_Dimension { get; set; }
            public System.String UIColorPalette_DimensionForeground { get; set; }
            public System.String UIColorPalette_Measure { get; set; }
            public System.String UIColorPalette_MeasureForeground { get; set; }
            public System.String UIColorPalette_PrimaryBackground { get; set; }
            public System.String UIColorPalette_PrimaryForeground { get; set; }
            public System.String UIColorPalette_SecondaryBackground { get; set; }
            public System.String UIColorPalette_SecondaryForeground { get; set; }
            public System.String UIColorPalette_Success { get; set; }
            public System.String UIColorPalette_SuccessForeground { get; set; }
            public System.String UIColorPalette_Warning { get; set; }
            public System.String UIColorPalette_WarningForeground { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.QuickSight.Model.ResourcePermission> Permission { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public System.String ThemeId { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateThemeResponse, NewQSThemeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
