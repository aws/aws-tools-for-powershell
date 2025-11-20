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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates a theme.
    /// </summary>
    [Cmdlet("Update", "QSTheme", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateThemeResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateTheme API operation.", Operation = new[] {"UpdateTheme"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateThemeResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateThemeResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateThemeResponse object containing multiple properties."
    )]
    public partial class UpdateQSThemeCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute
        /// <summary>
        /// <para>
        /// <para>The font size that you want to use in px.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AxisLabelFontSize_Absolute")]
        public System.String Configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute
        /// <summary>
        /// <para>
        /// <para>The font size that you want to use in px.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AxisTitleFontSize_Absolute")]
        public System.String Configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute
        /// <summary>
        /// <para>
        /// <para>The font size that you want to use in px.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLabelFontSize_Absolute")]
        public System.String Configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute
        /// <summary>
        /// <para>
        /// <para>The font size that you want to use in px.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LegendTitleFontSize_Absolute")]
        public System.String Configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute
        /// <summary>
        /// <para>
        /// <para>The font size that you want to use in px.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LegendValueFontSize_Absolute")]
        public System.String Configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute
        /// <summary>
        /// <para>
        /// <para>The font size that you want to use in px.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualSubtitleFontSize_Absolute")]
        public System.String Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute
        /// <summary>
        /// <para>
        /// <para>The font size that you want to use in px.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualTitleFontSize_Absolute")]
        public System.String Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute { get; set; }
        #endregion
        
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
        /// <para>The ID of the Amazon Web Services account that contains the theme that you're updating.</para>
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
        
        #region Parameter Tile_BackgroundColor
        /// <summary>
        /// <para>
        /// <para>The background color of a tile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Sheet_Tile_BackgroundColor")]
        public System.String Tile_BackgroundColor { get; set; }
        #endregion
        
        #region Parameter BaseThemeId
        /// <summary>
        /// <para>
        /// <para>The theme ID, defined by Amazon Quick Sight, that a custom theme inherits from. All
        /// themes initially inherit from a default Quick Sight theme.</para>
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
        
        #region Parameter Tile_BorderRadius
        /// <summary>
        /// <para>
        /// <para>The border radius of a tile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Sheet_Tile_BorderRadius")]
        public System.String Tile_BorderRadius { get; set; }
        #endregion
        
        #region Parameter Background_Color
        /// <summary>
        /// <para>
        /// <para>The solid color background option for sheets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Sheet_Background_Color")]
        public System.String Background_Color { get; set; }
        #endregion
        
        #region Parameter Border_Color
        /// <summary>
        /// <para>
        /// <para>The option to add color for tile borders for visuals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Sheet_Tile_Border_Color")]
        public System.String Border_Color { get; set; }
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
        
        #region Parameter AxisLabelFontConfiguration_FontColor
        /// <summary>
        /// <para>
        /// <para>Determines the color of the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_AxisLabelFontConfiguration_FontColor")]
        public System.String AxisLabelFontConfiguration_FontColor { get; set; }
        #endregion
        
        #region Parameter AxisTitleFontConfiguration_FontColor
        /// <summary>
        /// <para>
        /// <para>Determines the color of the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_AxisTitleFontConfiguration_FontColor")]
        public System.String AxisTitleFontConfiguration_FontColor { get; set; }
        #endregion
        
        #region Parameter DataLabelFontConfiguration_FontColor
        /// <summary>
        /// <para>
        /// <para>Determines the color of the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_DataLabelFontConfiguration_FontColor")]
        public System.String DataLabelFontConfiguration_FontColor { get; set; }
        #endregion
        
        #region Parameter LegendTitleFontConfiguration_FontColor
        /// <summary>
        /// <para>
        /// <para>Determines the color of the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_LegendTitleFontConfiguration_FontColor")]
        public System.String LegendTitleFontConfiguration_FontColor { get; set; }
        #endregion
        
        #region Parameter LegendValueFontConfiguration_FontColor
        /// <summary>
        /// <para>
        /// <para>Determines the color of the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_LegendValueFontConfiguration_FontColor")]
        public System.String LegendValueFontConfiguration_FontColor { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor
        /// <summary>
        /// <para>
        /// <para>Determines the color of the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualSubtitleFontColor")]
        public System.String Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor
        /// <summary>
        /// <para>
        /// <para>Determines the color of the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualTitleFontColor")]
        public System.String Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor { get; set; }
        #endregion
        
        #region Parameter AxisLabelFontConfiguration_FontDecoration
        /// <summary>
        /// <para>
        /// <para>Determines the appearance of decorative lines on the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_AxisLabelFontConfiguration_FontDecoration")]
        [AWSConstantClassSource("Amazon.QuickSight.FontDecoration")]
        public Amazon.QuickSight.FontDecoration AxisLabelFontConfiguration_FontDecoration { get; set; }
        #endregion
        
        #region Parameter AxisTitleFontConfiguration_FontDecoration
        /// <summary>
        /// <para>
        /// <para>Determines the appearance of decorative lines on the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_AxisTitleFontConfiguration_FontDecoration")]
        [AWSConstantClassSource("Amazon.QuickSight.FontDecoration")]
        public Amazon.QuickSight.FontDecoration AxisTitleFontConfiguration_FontDecoration { get; set; }
        #endregion
        
        #region Parameter DataLabelFontConfiguration_FontDecoration
        /// <summary>
        /// <para>
        /// <para>Determines the appearance of decorative lines on the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_DataLabelFontConfiguration_FontDecoration")]
        [AWSConstantClassSource("Amazon.QuickSight.FontDecoration")]
        public Amazon.QuickSight.FontDecoration DataLabelFontConfiguration_FontDecoration { get; set; }
        #endregion
        
        #region Parameter LegendTitleFontConfiguration_FontDecoration
        /// <summary>
        /// <para>
        /// <para>Determines the appearance of decorative lines on the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_LegendTitleFontConfiguration_FontDecoration")]
        [AWSConstantClassSource("Amazon.QuickSight.FontDecoration")]
        public Amazon.QuickSight.FontDecoration LegendTitleFontConfiguration_FontDecoration { get; set; }
        #endregion
        
        #region Parameter LegendValueFontConfiguration_FontDecoration
        /// <summary>
        /// <para>
        /// <para>Determines the appearance of decorative lines on the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_LegendValueFontConfiguration_FontDecoration")]
        [AWSConstantClassSource("Amazon.QuickSight.FontDecoration")]
        public Amazon.QuickSight.FontDecoration LegendValueFontConfiguration_FontDecoration { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration
        /// <summary>
        /// <para>
        /// <para>Determines the appearance of decorative lines on the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualSubtitleFontDecoration")]
        [AWSConstantClassSource("Amazon.QuickSight.FontDecoration")]
        public Amazon.QuickSight.FontDecoration Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration
        /// <summary>
        /// <para>
        /// <para>Determines the appearance of decorative lines on the text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualTitleFontDecoration")]
        [AWSConstantClassSource("Amazon.QuickSight.FontDecoration")]
        public Amazon.QuickSight.FontDecoration Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration { get; set; }
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
        
        #region Parameter AxisLabelFontConfiguration_FontFamily
        /// <summary>
        /// <para>
        /// <para>The font family that you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_AxisLabelFontConfiguration_FontFamily")]
        public System.String AxisLabelFontConfiguration_FontFamily { get; set; }
        #endregion
        
        #region Parameter AxisTitleFontConfiguration_FontFamily
        /// <summary>
        /// <para>
        /// <para>The font family that you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_AxisTitleFontConfiguration_FontFamily")]
        public System.String AxisTitleFontConfiguration_FontFamily { get; set; }
        #endregion
        
        #region Parameter DataLabelFontConfiguration_FontFamily
        /// <summary>
        /// <para>
        /// <para>The font family that you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_DataLabelFontConfiguration_FontFamily")]
        public System.String DataLabelFontConfiguration_FontFamily { get; set; }
        #endregion
        
        #region Parameter LegendTitleFontConfiguration_FontFamily
        /// <summary>
        /// <para>
        /// <para>The font family that you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_LegendTitleFontConfiguration_FontFamily")]
        public System.String LegendTitleFontConfiguration_FontFamily { get; set; }
        #endregion
        
        #region Parameter LegendValueFontConfiguration_FontFamily
        /// <summary>
        /// <para>
        /// <para>The font family that you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_LegendValueFontConfiguration_FontFamily")]
        public System.String LegendValueFontConfiguration_FontFamily { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily
        /// <summary>
        /// <para>
        /// <para>The font family that you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualSubtitleFontFamily")]
        public System.String Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily
        /// <summary>
        /// <para>
        /// <para>The font family that you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualTitleFontFamily")]
        public System.String Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily { get; set; }
        #endregion
        
        #region Parameter AxisLabelFontConfiguration_FontStyle
        /// <summary>
        /// <para>
        /// <para>Determines the text display face that is inherited by the given font family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_AxisLabelFontConfiguration_FontStyle")]
        [AWSConstantClassSource("Amazon.QuickSight.FontStyle")]
        public Amazon.QuickSight.FontStyle AxisLabelFontConfiguration_FontStyle { get; set; }
        #endregion
        
        #region Parameter AxisTitleFontConfiguration_FontStyle
        /// <summary>
        /// <para>
        /// <para>Determines the text display face that is inherited by the given font family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_AxisTitleFontConfiguration_FontStyle")]
        [AWSConstantClassSource("Amazon.QuickSight.FontStyle")]
        public Amazon.QuickSight.FontStyle AxisTitleFontConfiguration_FontStyle { get; set; }
        #endregion
        
        #region Parameter DataLabelFontConfiguration_FontStyle
        /// <summary>
        /// <para>
        /// <para>Determines the text display face that is inherited by the given font family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_DataLabelFontConfiguration_FontStyle")]
        [AWSConstantClassSource("Amazon.QuickSight.FontStyle")]
        public Amazon.QuickSight.FontStyle DataLabelFontConfiguration_FontStyle { get; set; }
        #endregion
        
        #region Parameter LegendTitleFontConfiguration_FontStyle
        /// <summary>
        /// <para>
        /// <para>Determines the text display face that is inherited by the given font family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_LegendTitleFontConfiguration_FontStyle")]
        [AWSConstantClassSource("Amazon.QuickSight.FontStyle")]
        public Amazon.QuickSight.FontStyle LegendTitleFontConfiguration_FontStyle { get; set; }
        #endregion
        
        #region Parameter LegendValueFontConfiguration_FontStyle
        /// <summary>
        /// <para>
        /// <para>Determines the text display face that is inherited by the given font family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_LegendValueFontConfiguration_FontStyle")]
        [AWSConstantClassSource("Amazon.QuickSight.FontStyle")]
        public Amazon.QuickSight.FontStyle LegendValueFontConfiguration_FontStyle { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle
        /// <summary>
        /// <para>
        /// <para>Determines the text display face that is inherited by the given font family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualSubtitleFontStyle")]
        [AWSConstantClassSource("Amazon.QuickSight.FontStyle")]
        public Amazon.QuickSight.FontStyle Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle
        /// <summary>
        /// <para>
        /// <para>Determines the text display face that is inherited by the given font family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualTitleFontStyle")]
        [AWSConstantClassSource("Amazon.QuickSight.FontStyle")]
        public Amazon.QuickSight.FontStyle Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle { get; set; }
        #endregion
        
        #region Parameter Background_Gradient
        /// <summary>
        /// <para>
        /// <para>The gradient background option for sheets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Sheet_Background_Gradient")]
        public System.String Background_Gradient { get; set; }
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
        
        #region Parameter Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name
        /// <summary>
        /// <para>
        /// <para>The lexical name for the level of boldness of the text display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AxisLabelFontWeight_Name")]
        [AWSConstantClassSource("Amazon.QuickSight.FontWeightName")]
        public Amazon.QuickSight.FontWeightName Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name
        /// <summary>
        /// <para>
        /// <para>The lexical name for the level of boldness of the text display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AxisTitleFontWeight_Name")]
        [AWSConstantClassSource("Amazon.QuickSight.FontWeightName")]
        public Amazon.QuickSight.FontWeightName Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name
        /// <summary>
        /// <para>
        /// <para>The lexical name for the level of boldness of the text display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLabelFontWeight_Name")]
        [AWSConstantClassSource("Amazon.QuickSight.FontWeightName")]
        public Amazon.QuickSight.FontWeightName Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name
        /// <summary>
        /// <para>
        /// <para>The lexical name for the level of boldness of the text display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LegendTitleFontWeight_Name")]
        [AWSConstantClassSource("Amazon.QuickSight.FontWeightName")]
        public Amazon.QuickSight.FontWeightName Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name
        /// <summary>
        /// <para>
        /// <para>The lexical name for the level of boldness of the text display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LegendValueFontWeight_Name")]
        [AWSConstantClassSource("Amazon.QuickSight.FontWeightName")]
        public Amazon.QuickSight.FontWeightName Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name
        /// <summary>
        /// <para>
        /// <para>The lexical name for the level of boldness of the text display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualSubtitleFontWeight_Name")]
        [AWSConstantClassSource("Amazon.QuickSight.FontWeightName")]
        public Amazon.QuickSight.FontWeightName Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name
        /// <summary>
        /// <para>
        /// <para>The lexical name for the level of boldness of the text display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualTitleFontWeight_Name")]
        [AWSConstantClassSource("Amazon.QuickSight.FontWeightName")]
        public Amazon.QuickSight.FontWeightName Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tile_Padding
        /// <summary>
        /// <para>
        /// <para>The padding of a tile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Sheet_Tile_Padding")]
        public System.String Tile_Padding { get; set; }
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
        
        #region Parameter Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative
        /// <summary>
        /// <para>
        /// <para>The lexical name for the text size, proportional to its surrounding context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AxisLabelFontSize_Relative")]
        [AWSConstantClassSource("Amazon.QuickSight.RelativeFontSize")]
        public Amazon.QuickSight.RelativeFontSize Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative
        /// <summary>
        /// <para>
        /// <para>The lexical name for the text size, proportional to its surrounding context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AxisTitleFontSize_Relative")]
        [AWSConstantClassSource("Amazon.QuickSight.RelativeFontSize")]
        public Amazon.QuickSight.RelativeFontSize Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative
        /// <summary>
        /// <para>
        /// <para>The lexical name for the text size, proportional to its surrounding context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLabelFontSize_Relative")]
        [AWSConstantClassSource("Amazon.QuickSight.RelativeFontSize")]
        public Amazon.QuickSight.RelativeFontSize Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative
        /// <summary>
        /// <para>
        /// <para>The lexical name for the text size, proportional to its surrounding context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LegendTitleFontSize_Relative")]
        [AWSConstantClassSource("Amazon.QuickSight.RelativeFontSize")]
        public Amazon.QuickSight.RelativeFontSize Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative
        /// <summary>
        /// <para>
        /// <para>The lexical name for the text size, proportional to its surrounding context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LegendValueFontSize_Relative")]
        [AWSConstantClassSource("Amazon.QuickSight.RelativeFontSize")]
        public Amazon.QuickSight.RelativeFontSize Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative
        /// <summary>
        /// <para>
        /// <para>The lexical name for the text size, proportional to its surrounding context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualSubtitleFontSize_Relative")]
        [AWSConstantClassSource("Amazon.QuickSight.RelativeFontSize")]
        public Amazon.QuickSight.RelativeFontSize Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative { get; set; }
        #endregion
        
        #region Parameter Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative
        /// <summary>
        /// <para>
        /// <para>The lexical name for the text size, proportional to its surrounding context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualTitleFontSize_Relative")]
        [AWSConstantClassSource("Amazon.QuickSight.RelativeFontSize")]
        public Amazon.QuickSight.RelativeFontSize Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative { get; set; }
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
        
        #region Parameter VisualSubtitleFontConfiguration_TextAlignment
        /// <summary>
        /// <para>
        /// <para>Determines the alignment of visual sub-title.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_VisualSubtitleFontConfiguration_TextAlignment")]
        [AWSConstantClassSource("Amazon.QuickSight.HorizontalTextAlignment")]
        public Amazon.QuickSight.HorizontalTextAlignment VisualSubtitleFontConfiguration_TextAlignment { get; set; }
        #endregion
        
        #region Parameter VisualTitleFontConfiguration_TextAlignment
        /// <summary>
        /// <para>
        /// <para>Determines the alignment of visual title.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_VisualTitleFontConfiguration_TextAlignment")]
        [AWSConstantClassSource("Amazon.QuickSight.HorizontalTextAlignment")]
        public Amazon.QuickSight.HorizontalTextAlignment VisualTitleFontConfiguration_TextAlignment { get; set; }
        #endregion
        
        #region Parameter VisualSubtitleFontConfiguration_TextTransform
        /// <summary>
        /// <para>
        /// <para>Determines the text transformation of visual sub-title.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_VisualSubtitleFontConfiguration_TextTransform")]
        [AWSConstantClassSource("Amazon.QuickSight.TextTransform")]
        public Amazon.QuickSight.TextTransform VisualSubtitleFontConfiguration_TextTransform { get; set; }
        #endregion
        
        #region Parameter VisualTitleFontConfiguration_TextTransform
        /// <summary>
        /// <para>
        /// <para>Determines the text transformation of visual title.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Typography_VisualTitleFontConfiguration_TextTransform")]
        [AWSConstantClassSource("Amazon.QuickSight.TextTransform")]
        public Amazon.QuickSight.TextTransform VisualTitleFontConfiguration_TextTransform { get; set; }
        #endregion
        
        #region Parameter ThemeId
        /// <summary>
        /// <para>
        /// <para>The ID for the theme.</para>
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
        /// <para>A description of the theme version that you're updating Every time that you call <c>UpdateTheme</c>,
        /// you create a new version of the theme. Each version of the theme maintains a description
        /// of the version in <c>VersionDescription</c>.</para>
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
        
        #region Parameter Border_Width
        /// <summary>
        /// <para>
        /// <para>The option to set the width of tile borders for visuals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Sheet_Tile_Border_Width")]
        public System.String Border_Width { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateThemeResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateThemeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ThemeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ThemeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ThemeId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThemeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSTheme (UpdateTheme)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateThemeResponse, UpdateQSThemeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ThemeId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.Background_Color = this.Background_Color;
            context.Background_Gradient = this.Background_Gradient;
            context.Tile_BackgroundColor = this.Tile_BackgroundColor;
            context.Border_Color = this.Border_Color;
            context.Border_Show = this.Border_Show;
            context.Border_Width = this.Border_Width;
            context.Tile_BorderRadius = this.Tile_BorderRadius;
            context.Tile_Padding = this.Tile_Padding;
            context.Gutter_Show = this.Gutter_Show;
            context.Margin_Show = this.Margin_Show;
            context.AxisLabelFontConfiguration_FontColor = this.AxisLabelFontConfiguration_FontColor;
            context.AxisLabelFontConfiguration_FontDecoration = this.AxisLabelFontConfiguration_FontDecoration;
            context.AxisLabelFontConfiguration_FontFamily = this.AxisLabelFontConfiguration_FontFamily;
            context.Configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute = this.Configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute;
            context.Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative = this.Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative;
            context.AxisLabelFontConfiguration_FontStyle = this.AxisLabelFontConfiguration_FontStyle;
            context.Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name = this.Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name;
            context.AxisTitleFontConfiguration_FontColor = this.AxisTitleFontConfiguration_FontColor;
            context.AxisTitleFontConfiguration_FontDecoration = this.AxisTitleFontConfiguration_FontDecoration;
            context.AxisTitleFontConfiguration_FontFamily = this.AxisTitleFontConfiguration_FontFamily;
            context.Configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute = this.Configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute;
            context.Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative = this.Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative;
            context.AxisTitleFontConfiguration_FontStyle = this.AxisTitleFontConfiguration_FontStyle;
            context.Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name = this.Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name;
            context.DataLabelFontConfiguration_FontColor = this.DataLabelFontConfiguration_FontColor;
            context.DataLabelFontConfiguration_FontDecoration = this.DataLabelFontConfiguration_FontDecoration;
            context.DataLabelFontConfiguration_FontFamily = this.DataLabelFontConfiguration_FontFamily;
            context.Configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute = this.Configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute;
            context.Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative = this.Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative;
            context.DataLabelFontConfiguration_FontStyle = this.DataLabelFontConfiguration_FontStyle;
            context.Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name = this.Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name;
            if (this.Typography_FontFamily != null)
            {
                context.Typography_FontFamily = new List<Amazon.QuickSight.Model.Font>(this.Typography_FontFamily);
            }
            context.LegendTitleFontConfiguration_FontColor = this.LegendTitleFontConfiguration_FontColor;
            context.LegendTitleFontConfiguration_FontDecoration = this.LegendTitleFontConfiguration_FontDecoration;
            context.LegendTitleFontConfiguration_FontFamily = this.LegendTitleFontConfiguration_FontFamily;
            context.Configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute = this.Configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute;
            context.Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative = this.Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative;
            context.LegendTitleFontConfiguration_FontStyle = this.LegendTitleFontConfiguration_FontStyle;
            context.Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name = this.Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name;
            context.LegendValueFontConfiguration_FontColor = this.LegendValueFontConfiguration_FontColor;
            context.LegendValueFontConfiguration_FontDecoration = this.LegendValueFontConfiguration_FontDecoration;
            context.LegendValueFontConfiguration_FontFamily = this.LegendValueFontConfiguration_FontFamily;
            context.Configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute = this.Configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute;
            context.Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative = this.Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative;
            context.LegendValueFontConfiguration_FontStyle = this.LegendValueFontConfiguration_FontStyle;
            context.Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name = this.Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name;
            context.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor = this.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor;
            context.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration = this.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration;
            context.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily = this.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily;
            context.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute = this.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute;
            context.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative = this.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative;
            context.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle = this.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle;
            context.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name = this.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name;
            context.VisualSubtitleFontConfiguration_TextAlignment = this.VisualSubtitleFontConfiguration_TextAlignment;
            context.VisualSubtitleFontConfiguration_TextTransform = this.VisualSubtitleFontConfiguration_TextTransform;
            context.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor = this.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor;
            context.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration = this.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration;
            context.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily = this.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily;
            context.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute = this.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute;
            context.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative = this.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative;
            context.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle = this.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle;
            context.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name = this.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name;
            context.VisualTitleFontConfiguration_TextAlignment = this.VisualTitleFontConfiguration_TextAlignment;
            context.VisualTitleFontConfiguration_TextTransform = this.VisualTitleFontConfiguration_TextTransform;
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
            var request = new Amazon.QuickSight.Model.UpdateThemeRequest();
            
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
            Amazon.QuickSight.Model.SheetStyle requestConfiguration_configuration_Sheet = null;
            
             // populate Sheet
            var requestConfiguration_configuration_SheetIsNull = true;
            requestConfiguration_configuration_Sheet = new Amazon.QuickSight.Model.SheetStyle();
            Amazon.QuickSight.Model.SheetBackgroundStyle requestConfiguration_configuration_Sheet_configuration_Sheet_Background = null;
            
             // populate Background
            var requestConfiguration_configuration_Sheet_configuration_Sheet_BackgroundIsNull = true;
            requestConfiguration_configuration_Sheet_configuration_Sheet_Background = new Amazon.QuickSight.Model.SheetBackgroundStyle();
            System.String requestConfiguration_configuration_Sheet_configuration_Sheet_Background_background_Color = null;
            if (cmdletContext.Background_Color != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Background_background_Color = cmdletContext.Background_Color;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Background_background_Color != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Background.Color = requestConfiguration_configuration_Sheet_configuration_Sheet_Background_background_Color;
                requestConfiguration_configuration_Sheet_configuration_Sheet_BackgroundIsNull = false;
            }
            System.String requestConfiguration_configuration_Sheet_configuration_Sheet_Background_background_Gradient = null;
            if (cmdletContext.Background_Gradient != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Background_background_Gradient = cmdletContext.Background_Gradient;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Background_background_Gradient != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Background.Gradient = requestConfiguration_configuration_Sheet_configuration_Sheet_Background_background_Gradient;
                requestConfiguration_configuration_Sheet_configuration_Sheet_BackgroundIsNull = false;
            }
             // determine if requestConfiguration_configuration_Sheet_configuration_Sheet_Background should be set to null
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_BackgroundIsNull)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Background = null;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Background != null)
            {
                requestConfiguration_configuration_Sheet.Background = requestConfiguration_configuration_Sheet_configuration_Sheet_Background;
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
            Amazon.QuickSight.Model.TileStyle requestConfiguration_configuration_Sheet_configuration_Sheet_Tile = null;
            
             // populate Tile
            var requestConfiguration_configuration_Sheet_configuration_Sheet_TileIsNull = true;
            requestConfiguration_configuration_Sheet_configuration_Sheet_Tile = new Amazon.QuickSight.Model.TileStyle();
            System.String requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_BackgroundColor = null;
            if (cmdletContext.Tile_BackgroundColor != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_BackgroundColor = cmdletContext.Tile_BackgroundColor;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_BackgroundColor != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile.BackgroundColor = requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_BackgroundColor;
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileIsNull = false;
            }
            System.String requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_BorderRadius = null;
            if (cmdletContext.Tile_BorderRadius != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_BorderRadius = cmdletContext.Tile_BorderRadius;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_BorderRadius != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile.BorderRadius = requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_BorderRadius;
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileIsNull = false;
            }
            System.String requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_Padding = null;
            if (cmdletContext.Tile_Padding != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_Padding = cmdletContext.Tile_Padding;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_Padding != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile.Padding = requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_tile_Padding;
                requestConfiguration_configuration_Sheet_configuration_Sheet_TileIsNull = false;
            }
            Amazon.QuickSight.Model.BorderStyle requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border = null;
            
             // populate Border
            var requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_BorderIsNull = true;
            requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border = new Amazon.QuickSight.Model.BorderStyle();
            System.String requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Color = null;
            if (cmdletContext.Border_Color != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Color = cmdletContext.Border_Color;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Color != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border.Color = requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Color;
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_BorderIsNull = false;
            }
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
            System.String requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Width = null;
            if (cmdletContext.Border_Width != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Width = cmdletContext.Border_Width;
            }
            if (requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Width != null)
            {
                requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border.Width = requestConfiguration_configuration_Sheet_configuration_Sheet_Tile_configuration_Sheet_Tile_Border_border_Width;
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
            Amazon.QuickSight.Model.VisualSubtitleFontConfiguration requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration = null;
            
             // populate VisualSubtitleFontConfiguration
            var requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfigurationIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration = new Amazon.QuickSight.Model.VisualSubtitleFontConfiguration();
            Amazon.QuickSight.HorizontalTextAlignment requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_visualSubtitleFontConfiguration_TextAlignment = null;
            if (cmdletContext.VisualSubtitleFontConfiguration_TextAlignment != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_visualSubtitleFontConfiguration_TextAlignment = cmdletContext.VisualSubtitleFontConfiguration_TextAlignment;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_visualSubtitleFontConfiguration_TextAlignment != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration.TextAlignment = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_visualSubtitleFontConfiguration_TextAlignment;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.TextTransform requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_visualSubtitleFontConfiguration_TextTransform = null;
            if (cmdletContext.VisualSubtitleFontConfiguration_TextTransform != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_visualSubtitleFontConfiguration_TextTransform = cmdletContext.VisualSubtitleFontConfiguration_TextTransform;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_visualSubtitleFontConfiguration_TextTransform != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration.TextTransform = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_visualSubtitleFontConfiguration_TextTransform;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontConfiguration requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration = null;
            
             // populate FontConfiguration
            var requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfigurationIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration = new Amazon.QuickSight.Model.FontConfiguration();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor = null;
            if (cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor = cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration.FontColor = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontDecoration requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration = null;
            if (cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration = cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration.FontDecoration = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily = null;
            if (cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily = cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration.FontFamily = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontStyle requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle = null;
            if (cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle = cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration.FontStyle = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontWeight requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight = null;
            
             // populate FontWeight
            var requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeightIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight = new Amazon.QuickSight.Model.FontWeight();
            Amazon.QuickSight.FontWeightName requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name = null;
            if (cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name = cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight.Name = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeightIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeightIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration.FontWeight = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontSize requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize = null;
            
             // populate FontSize
            var requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSizeIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize = new Amazon.QuickSight.Model.FontSize();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute = null;
            if (cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute = cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize.Absolute = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSizeIsNull = false;
            }
            Amazon.QuickSight.RelativeFontSize requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative = null;
            if (cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative = cmdletContext.Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize.Relative = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSizeIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSizeIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration.FontSize = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfigurationIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration.FontConfiguration = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration_configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfigurationIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration != null)
            {
                requestConfiguration_configuration_Typography.VisualSubtitleFontConfiguration = requestConfiguration_configuration_Typography_configuration_Typography_VisualSubtitleFontConfiguration;
                requestConfiguration_configuration_TypographyIsNull = false;
            }
            Amazon.QuickSight.Model.VisualTitleFontConfiguration requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration = null;
            
             // populate VisualTitleFontConfiguration
            var requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfigurationIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration = new Amazon.QuickSight.Model.VisualTitleFontConfiguration();
            Amazon.QuickSight.HorizontalTextAlignment requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_visualTitleFontConfiguration_TextAlignment = null;
            if (cmdletContext.VisualTitleFontConfiguration_TextAlignment != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_visualTitleFontConfiguration_TextAlignment = cmdletContext.VisualTitleFontConfiguration_TextAlignment;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_visualTitleFontConfiguration_TextAlignment != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration.TextAlignment = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_visualTitleFontConfiguration_TextAlignment;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.TextTransform requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_visualTitleFontConfiguration_TextTransform = null;
            if (cmdletContext.VisualTitleFontConfiguration_TextTransform != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_visualTitleFontConfiguration_TextTransform = cmdletContext.VisualTitleFontConfiguration_TextTransform;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_visualTitleFontConfiguration_TextTransform != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration.TextTransform = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_visualTitleFontConfiguration_TextTransform;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontConfiguration requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration = null;
            
             // populate FontConfiguration
            var requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfigurationIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration = new Amazon.QuickSight.Model.FontConfiguration();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor = null;
            if (cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor = cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration.FontColor = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontDecoration requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration = null;
            if (cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration = cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration.FontDecoration = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily = null;
            if (cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily = cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration.FontFamily = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontStyle requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle = null;
            if (cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle = cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration.FontStyle = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontWeight requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight = null;
            
             // populate FontWeight
            var requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeightIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight = new Amazon.QuickSight.Model.FontWeight();
            Amazon.QuickSight.FontWeightName requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name = null;
            if (cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name = cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight.Name = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeightIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeightIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration.FontWeight = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontSize requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize = null;
            
             // populate FontSize
            var requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSizeIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize = new Amazon.QuickSight.Model.FontSize();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute = null;
            if (cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute = cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize.Absolute = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSizeIsNull = false;
            }
            Amazon.QuickSight.RelativeFontSize requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative = null;
            if (cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative = cmdletContext.Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize.Relative = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSizeIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSizeIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration.FontSize = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfigurationIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration.FontConfiguration = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration_configuration_Typography_VisualTitleFontConfiguration_FontConfiguration;
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfigurationIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration != null)
            {
                requestConfiguration_configuration_Typography.VisualTitleFontConfiguration = requestConfiguration_configuration_Typography_configuration_Typography_VisualTitleFontConfiguration;
                requestConfiguration_configuration_TypographyIsNull = false;
            }
            Amazon.QuickSight.Model.FontConfiguration requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration = null;
            
             // populate AxisLabelFontConfiguration
            var requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfigurationIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration = new Amazon.QuickSight.Model.FontConfiguration();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontColor = null;
            if (cmdletContext.AxisLabelFontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontColor = cmdletContext.AxisLabelFontConfiguration_FontColor;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration.FontColor = requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontColor;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontDecoration requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontDecoration = null;
            if (cmdletContext.AxisLabelFontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontDecoration = cmdletContext.AxisLabelFontConfiguration_FontDecoration;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration.FontDecoration = requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontDecoration;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontFamily = null;
            if (cmdletContext.AxisLabelFontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontFamily = cmdletContext.AxisLabelFontConfiguration_FontFamily;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration.FontFamily = requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontFamily;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontStyle requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontStyle = null;
            if (cmdletContext.AxisLabelFontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontStyle = cmdletContext.AxisLabelFontConfiguration_FontStyle;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration.FontStyle = requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_axisLabelFontConfiguration_FontStyle;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontWeight requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight = null;
            
             // populate FontWeight
            var requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeightIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight = new Amazon.QuickSight.Model.FontWeight();
            Amazon.QuickSight.FontWeightName requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight_configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name = null;
            if (cmdletContext.Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight_configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name = cmdletContext.Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight_configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight.Name = requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight_configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeightIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeightIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration.FontWeight = requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontWeight;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontSize requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize = null;
            
             // populate FontSize
            var requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSizeIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize = new Amazon.QuickSight.Model.FontSize();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize_configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute = null;
            if (cmdletContext.Configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize_configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute = cmdletContext.Configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize_configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize.Absolute = requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize_configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSizeIsNull = false;
            }
            Amazon.QuickSight.RelativeFontSize requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize_configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative = null;
            if (cmdletContext.Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize_configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative = cmdletContext.Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize_configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize.Relative = requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize_configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSizeIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSizeIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration.FontSize = requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration_configuration_Typography_AxisLabelFontConfiguration_FontSize;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfigurationIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration != null)
            {
                requestConfiguration_configuration_Typography.AxisLabelFontConfiguration = requestConfiguration_configuration_Typography_configuration_Typography_AxisLabelFontConfiguration;
                requestConfiguration_configuration_TypographyIsNull = false;
            }
            Amazon.QuickSight.Model.FontConfiguration requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration = null;
            
             // populate AxisTitleFontConfiguration
            var requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfigurationIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration = new Amazon.QuickSight.Model.FontConfiguration();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontColor = null;
            if (cmdletContext.AxisTitleFontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontColor = cmdletContext.AxisTitleFontConfiguration_FontColor;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration.FontColor = requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontColor;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontDecoration requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontDecoration = null;
            if (cmdletContext.AxisTitleFontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontDecoration = cmdletContext.AxisTitleFontConfiguration_FontDecoration;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration.FontDecoration = requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontDecoration;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontFamily = null;
            if (cmdletContext.AxisTitleFontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontFamily = cmdletContext.AxisTitleFontConfiguration_FontFamily;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration.FontFamily = requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontFamily;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontStyle requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontStyle = null;
            if (cmdletContext.AxisTitleFontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontStyle = cmdletContext.AxisTitleFontConfiguration_FontStyle;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration.FontStyle = requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_axisTitleFontConfiguration_FontStyle;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontWeight requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight = null;
            
             // populate FontWeight
            var requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeightIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight = new Amazon.QuickSight.Model.FontWeight();
            Amazon.QuickSight.FontWeightName requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight_configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name = null;
            if (cmdletContext.Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight_configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name = cmdletContext.Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight_configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight.Name = requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight_configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeightIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeightIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration.FontWeight = requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontWeight;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontSize requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize = null;
            
             // populate FontSize
            var requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSizeIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize = new Amazon.QuickSight.Model.FontSize();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize_configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute = null;
            if (cmdletContext.Configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize_configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute = cmdletContext.Configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize_configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize.Absolute = requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize_configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSizeIsNull = false;
            }
            Amazon.QuickSight.RelativeFontSize requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize_configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative = null;
            if (cmdletContext.Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize_configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative = cmdletContext.Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize_configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize.Relative = requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize_configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSizeIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSizeIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration.FontSize = requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration_configuration_Typography_AxisTitleFontConfiguration_FontSize;
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfigurationIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration != null)
            {
                requestConfiguration_configuration_Typography.AxisTitleFontConfiguration = requestConfiguration_configuration_Typography_configuration_Typography_AxisTitleFontConfiguration;
                requestConfiguration_configuration_TypographyIsNull = false;
            }
            Amazon.QuickSight.Model.FontConfiguration requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration = null;
            
             // populate DataLabelFontConfiguration
            var requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfigurationIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration = new Amazon.QuickSight.Model.FontConfiguration();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontColor = null;
            if (cmdletContext.DataLabelFontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontColor = cmdletContext.DataLabelFontConfiguration_FontColor;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration.FontColor = requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontColor;
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontDecoration requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontDecoration = null;
            if (cmdletContext.DataLabelFontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontDecoration = cmdletContext.DataLabelFontConfiguration_FontDecoration;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration.FontDecoration = requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontDecoration;
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontFamily = null;
            if (cmdletContext.DataLabelFontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontFamily = cmdletContext.DataLabelFontConfiguration_FontFamily;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration.FontFamily = requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontFamily;
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontStyle requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontStyle = null;
            if (cmdletContext.DataLabelFontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontStyle = cmdletContext.DataLabelFontConfiguration_FontStyle;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration.FontStyle = requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_dataLabelFontConfiguration_FontStyle;
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontWeight requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight = null;
            
             // populate FontWeight
            var requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeightIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight = new Amazon.QuickSight.Model.FontWeight();
            Amazon.QuickSight.FontWeightName requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight_configuration_Typography_DataLabelFontConfiguration_FontWeight_Name = null;
            if (cmdletContext.Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight_configuration_Typography_DataLabelFontConfiguration_FontWeight_Name = cmdletContext.Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight_configuration_Typography_DataLabelFontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight.Name = requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight_configuration_Typography_DataLabelFontConfiguration_FontWeight_Name;
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeightIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeightIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration.FontWeight = requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontWeight;
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontSize requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize = null;
            
             // populate FontSize
            var requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSizeIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize = new Amazon.QuickSight.Model.FontSize();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize_configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute = null;
            if (cmdletContext.Configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize_configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute = cmdletContext.Configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize_configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize.Absolute = requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize_configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute;
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSizeIsNull = false;
            }
            Amazon.QuickSight.RelativeFontSize requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize_configuration_Typography_DataLabelFontConfiguration_FontSize_Relative = null;
            if (cmdletContext.Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize_configuration_Typography_DataLabelFontConfiguration_FontSize_Relative = cmdletContext.Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize_configuration_Typography_DataLabelFontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize.Relative = requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize_configuration_Typography_DataLabelFontConfiguration_FontSize_Relative;
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSizeIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSizeIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration.FontSize = requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration_configuration_Typography_DataLabelFontConfiguration_FontSize;
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfigurationIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration != null)
            {
                requestConfiguration_configuration_Typography.DataLabelFontConfiguration = requestConfiguration_configuration_Typography_configuration_Typography_DataLabelFontConfiguration;
                requestConfiguration_configuration_TypographyIsNull = false;
            }
            Amazon.QuickSight.Model.FontConfiguration requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration = null;
            
             // populate LegendTitleFontConfiguration
            var requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfigurationIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration = new Amazon.QuickSight.Model.FontConfiguration();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontColor = null;
            if (cmdletContext.LegendTitleFontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontColor = cmdletContext.LegendTitleFontConfiguration_FontColor;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration.FontColor = requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontColor;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontDecoration requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontDecoration = null;
            if (cmdletContext.LegendTitleFontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontDecoration = cmdletContext.LegendTitleFontConfiguration_FontDecoration;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration.FontDecoration = requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontDecoration;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontFamily = null;
            if (cmdletContext.LegendTitleFontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontFamily = cmdletContext.LegendTitleFontConfiguration_FontFamily;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration.FontFamily = requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontFamily;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontStyle requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontStyle = null;
            if (cmdletContext.LegendTitleFontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontStyle = cmdletContext.LegendTitleFontConfiguration_FontStyle;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration.FontStyle = requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_legendTitleFontConfiguration_FontStyle;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontWeight requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight = null;
            
             // populate FontWeight
            var requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeightIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight = new Amazon.QuickSight.Model.FontWeight();
            Amazon.QuickSight.FontWeightName requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight_configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name = null;
            if (cmdletContext.Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight_configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name = cmdletContext.Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight_configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight.Name = requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight_configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeightIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeightIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration.FontWeight = requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontWeight;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontSize requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize = null;
            
             // populate FontSize
            var requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSizeIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize = new Amazon.QuickSight.Model.FontSize();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize_configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute = null;
            if (cmdletContext.Configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize_configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute = cmdletContext.Configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize_configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize.Absolute = requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize_configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSizeIsNull = false;
            }
            Amazon.QuickSight.RelativeFontSize requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize_configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative = null;
            if (cmdletContext.Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize_configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative = cmdletContext.Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize_configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize.Relative = requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize_configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSizeIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSizeIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration.FontSize = requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration_configuration_Typography_LegendTitleFontConfiguration_FontSize;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfigurationIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration != null)
            {
                requestConfiguration_configuration_Typography.LegendTitleFontConfiguration = requestConfiguration_configuration_Typography_configuration_Typography_LegendTitleFontConfiguration;
                requestConfiguration_configuration_TypographyIsNull = false;
            }
            Amazon.QuickSight.Model.FontConfiguration requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration = null;
            
             // populate LegendValueFontConfiguration
            var requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfigurationIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration = new Amazon.QuickSight.Model.FontConfiguration();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontColor = null;
            if (cmdletContext.LegendValueFontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontColor = cmdletContext.LegendValueFontConfiguration_FontColor;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontColor != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration.FontColor = requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontColor;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontDecoration requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontDecoration = null;
            if (cmdletContext.LegendValueFontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontDecoration = cmdletContext.LegendValueFontConfiguration_FontDecoration;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontDecoration != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration.FontDecoration = requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontDecoration;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontFamily = null;
            if (cmdletContext.LegendValueFontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontFamily = cmdletContext.LegendValueFontConfiguration_FontFamily;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontFamily != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration.FontFamily = requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontFamily;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.FontStyle requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontStyle = null;
            if (cmdletContext.LegendValueFontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontStyle = cmdletContext.LegendValueFontConfiguration_FontStyle;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontStyle != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration.FontStyle = requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_legendValueFontConfiguration_FontStyle;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontWeight requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight = null;
            
             // populate FontWeight
            var requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeightIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight = new Amazon.QuickSight.Model.FontWeight();
            Amazon.QuickSight.FontWeightName requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight_configuration_Typography_LegendValueFontConfiguration_FontWeight_Name = null;
            if (cmdletContext.Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight_configuration_Typography_LegendValueFontConfiguration_FontWeight_Name = cmdletContext.Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight_configuration_Typography_LegendValueFontConfiguration_FontWeight_Name != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight.Name = requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight_configuration_Typography_LegendValueFontConfiguration_FontWeight_Name;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeightIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeightIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration.FontWeight = requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontWeight;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.FontSize requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize = null;
            
             // populate FontSize
            var requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSizeIsNull = true;
            requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize = new Amazon.QuickSight.Model.FontSize();
            System.String requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize_configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute = null;
            if (cmdletContext.Configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize_configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute = cmdletContext.Configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize_configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize.Absolute = requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize_configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSizeIsNull = false;
            }
            Amazon.QuickSight.RelativeFontSize requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize_configuration_Typography_LegendValueFontConfiguration_FontSize_Relative = null;
            if (cmdletContext.Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize_configuration_Typography_LegendValueFontConfiguration_FontSize_Relative = cmdletContext.Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize_configuration_Typography_LegendValueFontConfiguration_FontSize_Relative != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize.Relative = requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize_configuration_Typography_LegendValueFontConfiguration_FontSize_Relative;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSizeIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSizeIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize != null)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration.FontSize = requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration_configuration_Typography_LegendValueFontConfiguration_FontSize;
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration should be set to null
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfigurationIsNull)
            {
                requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration = null;
            }
            if (requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration != null)
            {
                requestConfiguration_configuration_Typography.LegendValueFontConfiguration = requestConfiguration_configuration_Typography_configuration_Typography_LegendValueFontConfiguration;
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
        
        private Amazon.QuickSight.Model.UpdateThemeResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateThemeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateTheme");
            try
            {
                #if DESKTOP
                return client.UpdateTheme(request);
                #elif CORECLR
                return client.UpdateThemeAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String BaseThemeId { get; set; }
            public List<System.String> DataColorPalette_Color { get; set; }
            public System.String DataColorPalette_EmptyFillColor { get; set; }
            public List<System.String> DataColorPalette_MinMaxGradient { get; set; }
            public System.String Background_Color { get; set; }
            public System.String Background_Gradient { get; set; }
            public System.String Tile_BackgroundColor { get; set; }
            public System.String Border_Color { get; set; }
            public System.Boolean? Border_Show { get; set; }
            public System.String Border_Width { get; set; }
            public System.String Tile_BorderRadius { get; set; }
            public System.String Tile_Padding { get; set; }
            public System.Boolean? Gutter_Show { get; set; }
            public System.Boolean? Margin_Show { get; set; }
            public System.String AxisLabelFontConfiguration_FontColor { get; set; }
            public Amazon.QuickSight.FontDecoration AxisLabelFontConfiguration_FontDecoration { get; set; }
            public System.String AxisLabelFontConfiguration_FontFamily { get; set; }
            public System.String Configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute { get; set; }
            public Amazon.QuickSight.RelativeFontSize Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative { get; set; }
            public Amazon.QuickSight.FontStyle AxisLabelFontConfiguration_FontStyle { get; set; }
            public Amazon.QuickSight.FontWeightName Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name { get; set; }
            public System.String AxisTitleFontConfiguration_FontColor { get; set; }
            public Amazon.QuickSight.FontDecoration AxisTitleFontConfiguration_FontDecoration { get; set; }
            public System.String AxisTitleFontConfiguration_FontFamily { get; set; }
            public System.String Configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute { get; set; }
            public Amazon.QuickSight.RelativeFontSize Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative { get; set; }
            public Amazon.QuickSight.FontStyle AxisTitleFontConfiguration_FontStyle { get; set; }
            public Amazon.QuickSight.FontWeightName Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name { get; set; }
            public System.String DataLabelFontConfiguration_FontColor { get; set; }
            public Amazon.QuickSight.FontDecoration DataLabelFontConfiguration_FontDecoration { get; set; }
            public System.String DataLabelFontConfiguration_FontFamily { get; set; }
            public System.String Configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute { get; set; }
            public Amazon.QuickSight.RelativeFontSize Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative { get; set; }
            public Amazon.QuickSight.FontStyle DataLabelFontConfiguration_FontStyle { get; set; }
            public Amazon.QuickSight.FontWeightName Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name { get; set; }
            public List<Amazon.QuickSight.Model.Font> Typography_FontFamily { get; set; }
            public System.String LegendTitleFontConfiguration_FontColor { get; set; }
            public Amazon.QuickSight.FontDecoration LegendTitleFontConfiguration_FontDecoration { get; set; }
            public System.String LegendTitleFontConfiguration_FontFamily { get; set; }
            public System.String Configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute { get; set; }
            public Amazon.QuickSight.RelativeFontSize Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative { get; set; }
            public Amazon.QuickSight.FontStyle LegendTitleFontConfiguration_FontStyle { get; set; }
            public Amazon.QuickSight.FontWeightName Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name { get; set; }
            public System.String LegendValueFontConfiguration_FontColor { get; set; }
            public Amazon.QuickSight.FontDecoration LegendValueFontConfiguration_FontDecoration { get; set; }
            public System.String LegendValueFontConfiguration_FontFamily { get; set; }
            public System.String Configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute { get; set; }
            public Amazon.QuickSight.RelativeFontSize Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative { get; set; }
            public Amazon.QuickSight.FontStyle LegendValueFontConfiguration_FontStyle { get; set; }
            public Amazon.QuickSight.FontWeightName Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name { get; set; }
            public System.String Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor { get; set; }
            public Amazon.QuickSight.FontDecoration Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration { get; set; }
            public System.String Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily { get; set; }
            public System.String Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute { get; set; }
            public Amazon.QuickSight.RelativeFontSize Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative { get; set; }
            public Amazon.QuickSight.FontStyle Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle { get; set; }
            public Amazon.QuickSight.FontWeightName Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name { get; set; }
            public Amazon.QuickSight.HorizontalTextAlignment VisualSubtitleFontConfiguration_TextAlignment { get; set; }
            public Amazon.QuickSight.TextTransform VisualSubtitleFontConfiguration_TextTransform { get; set; }
            public System.String Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor { get; set; }
            public Amazon.QuickSight.FontDecoration Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration { get; set; }
            public System.String Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily { get; set; }
            public System.String Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute { get; set; }
            public Amazon.QuickSight.RelativeFontSize Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative { get; set; }
            public Amazon.QuickSight.FontStyle Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle { get; set; }
            public Amazon.QuickSight.FontWeightName Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name { get; set; }
            public Amazon.QuickSight.HorizontalTextAlignment VisualTitleFontConfiguration_TextAlignment { get; set; }
            public Amazon.QuickSight.TextTransform VisualTitleFontConfiguration_TextTransform { get; set; }
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
            public System.String ThemeId { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateThemeResponse, UpdateQSThemeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
