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
    /// Creates a dashboard from either a template or directly with a <c>DashboardDefinition</c>.
    /// To first create a template, see the <c><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_CreateTemplate.html">CreateTemplate</a></c> API operation.
    /// 
    ///  
    /// <para>
    /// A dashboard is an entity in Amazon QuickSight that identifies Amazon QuickSight reports,
    /// created from analyses. You can share Amazon QuickSight dashboards. With the right
    /// permissions, you can create scheduled email reports from them. If you have the correct
    /// permissions, you can create a dashboard from a template that exists in a different
    /// Amazon Web Services account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QSDashboard", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateDashboardResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateDashboard API operation.", Operation = new[] {"CreateDashboard"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateDashboardResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateDashboardResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateDashboardResponse object containing multiple properties."
    )]
    public partial class NewQSDashboardCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SourceTemplate_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceEntity_SourceTemplate_Arn")]
        public System.String SourceTemplate_Arn { get; set; }
        #endregion
        
        #region Parameter AdHocFilteringOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>Availability status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_AdHocFilteringOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior AdHocFilteringOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter DataPointDrillUpDownOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>The status of the drill down options of data points.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_DataPointDrillUpDownOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior DataPointDrillUpDownOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter DataPointMenuLabelOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>The status of the data point menu options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_DataPointMenuLabelOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior DataPointMenuLabelOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter DataPointTooltipOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>The status of the data point tool tip options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_DataPointTooltipOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior DataPointTooltipOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter DataQAEnabledOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>The status of the Data Q&amp;A option on the dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_DataQAEnabledOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior DataQAEnabledOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter ExportToCSVOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>Availability status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_ExportToCSVOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior ExportToCSVOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter ExportWithHiddenFieldsOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>The status of the export with hidden fields options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_ExportWithHiddenFieldsOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior ExportWithHiddenFieldsOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter SheetLayoutElementMaximizationOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>The status of the sheet layout maximization options of a dashbaord.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_SheetLayoutElementMaximizationOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior SheetLayoutElementMaximizationOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter VisualAxisSortOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>The availaiblity status of a visual's axis sort options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_VisualAxisSortOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior VisualAxisSortOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter VisualMenuOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>The availaiblity status of a visual's menu options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_VisualMenuOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior VisualMenuOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter ExportHiddenFieldsOption_AvailabilityStatus
        /// <summary>
        /// <para>
        /// <para>The status of the export hidden fields options of a dashbaord.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption_AvailabilityStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardBehavior")]
        public Amazon.QuickSight.DashboardBehavior ExportHiddenFieldsOption_AvailabilityStatus { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account where you want to create the dashboard.</para>
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
        
        #region Parameter PaperMargin_Bottom
        /// <summary>
        /// <para>
        /// <para>Define the bottom spacing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_Bottom")]
        public System.String PaperMargin_Bottom { get; set; }
        #endregion
        
        #region Parameter Definition_CalculatedField
        /// <summary>
        /// <para>
        /// <para>An array of calculated field definitions for the dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_CalculatedFields")]
        public Amazon.QuickSight.Model.CalculatedField[] Definition_CalculatedField { get; set; }
        #endregion
        
        #region Parameter Definition_ColumnConfiguration
        /// <summary>
        /// <para>
        /// <para>An array of dashboard-level column configurations. Column configurations are used
        /// to set the default formatting for a column that is used throughout a dashboard. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_ColumnConfigurations")]
        public Amazon.QuickSight.Model.ColumnConfiguration[] Definition_ColumnConfiguration { get; set; }
        #endregion
        
        #region Parameter DashboardId
        /// <summary>
        /// <para>
        /// <para>The ID for the dashboard, also added to the IAM policy.</para>
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
        public System.String DashboardId { get; set; }
        #endregion
        
        #region Parameter Definition_DataSetIdentifierDeclaration
        /// <summary>
        /// <para>
        /// <para>An array of dataset identifier declarations. With this mapping,you can use dataset
        /// identifiers instead of dataset Amazon Resource Names (ARNs) throughout the dashboard's
        /// sub-structures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_DataSetIdentifierDeclarations")]
        public Amazon.QuickSight.Model.DataSetIdentifierDeclaration[] Definition_DataSetIdentifierDeclaration { get; set; }
        #endregion
        
        #region Parameter SourceTemplate_DataSetReference
        /// <summary>
        /// <para>
        /// <para>Dataset references.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceEntity_SourceTemplate_DataSetReferences")]
        public Amazon.QuickSight.Model.DataSetReference[] SourceTemplate_DataSetReference { get; set; }
        #endregion
        
        #region Parameter Parameters_DateTimeParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of date-time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_DateTimeParameters")]
        public Amazon.QuickSight.Model.DateTimeParameter[] Parameters_DateTimeParameter { get; set; }
        #endregion
        
        #region Parameter Parameters_DecimalParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of decimal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_DecimalParameters")]
        public Amazon.QuickSight.Model.DecimalParameter[] Parameters_DecimalParameter { get; set; }
        #endregion
        
        #region Parameter Options_ExcludedDataSetArn
        /// <summary>
        /// <para>
        /// <para>A list of dataset ARNS to exclude from Dashboard Q&amp;A.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Options_ExcludedDataSetArns")]
        public System.String[] Options_ExcludedDataSetArn { get; set; }
        #endregion
        
        #region Parameter Definition_FilterGroup
        /// <summary>
        /// <para>
        /// <para>The filter definitions for a dashboard.</para><para>For more information, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/adding-a-filter.html">Filtering
        /// Data in Amazon QuickSight</a> in the <i>Amazon QuickSight User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_FilterGroups")]
        public Amazon.QuickSight.Model.FilterGroup[] Definition_FilterGroup { get; set; }
        #endregion
        
        #region Parameter FolderArn
        /// <summary>
        /// <para>
        /// <para>When you create the dashboard, Amazon QuickSight adds the dashboard to these folders.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FolderArns")]
        public System.String[] FolderArn { get; set; }
        #endregion
        
        #region Parameter Parameters_IntegerParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of integer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_IntegerParameters")]
        public Amazon.QuickSight.Model.IntegerParameter[] Parameters_IntegerParameter { get; set; }
        #endregion
        
        #region Parameter PaperMargin_Left
        /// <summary>
        /// <para>
        /// <para>Define the left spacing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_Left")]
        public System.String PaperMargin_Left { get; set; }
        #endregion
        
        #region Parameter LinkEntity
        /// <summary>
        /// <para>
        /// <para>A list of analysis Amazon Resource Names (ARNs) to be linked to the dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LinkEntities")]
        public System.String[] LinkEntity { get; set; }
        #endregion
        
        #region Parameter ValidationStrategy_Mode
        /// <summary>
        /// <para>
        /// <para>The mode of validation for the asset to be created or updated. When you set this value
        /// to <c>STRICT</c>, strict validation for every error is enforced. When you set this
        /// value to <c>LENIENT</c>, validation is skipped for specific UI errors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.ValidationStrategyMode")]
        public Amazon.QuickSight.ValidationStrategyMode ValidationStrategy_Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The display name of the dashboard.</para>
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
        
        #region Parameter Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth
        /// <summary>
        /// <para>
        /// <para>The width that the view port will be optimized for when the layout renders.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScreenCanvasSizeOptions_OptimizedViewPortWidth")]
        public System.String Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth { get; set; }
        #endregion
        
        #region Parameter Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth
        /// <summary>
        /// <para>
        /// <para>The width that the view port will be optimized for when the layout renders.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth { get; set; }
        #endregion
        
        #region Parameter PaperCanvasSizeOptions_PaperOrientation
        /// <summary>
        /// <para>
        /// <para>The paper orientation that is used to define canvas dimensions. Choose one of the
        /// following options:</para><ul><li><para>PORTRAIT</para></li><li><para>LANDSCAPE</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperOrientation")]
        [AWSConstantClassSource("Amazon.QuickSight.PaperOrientation")]
        public Amazon.QuickSight.PaperOrientation PaperCanvasSizeOptions_PaperOrientation { get; set; }
        #endregion
        
        #region Parameter PaperCanvasSizeOptions_PaperSize
        /// <summary>
        /// <para>
        /// <para>The paper size that is used to define canvas dimensions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperSize")]
        [AWSConstantClassSource("Amazon.QuickSight.PaperSize")]
        public Amazon.QuickSight.PaperSize PaperCanvasSizeOptions_PaperSize { get; set; }
        #endregion
        
        #region Parameter Definition_ParameterDeclaration
        /// <summary>
        /// <para>
        /// <para>The parameter declarations for a dashboard. Parameters are named variables that can
        /// transfer a value for use by an action or an object.</para><para>For more information, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/parameters-in-quicksight.html">Parameters
        /// in Amazon QuickSight</a> in the <i>Amazon QuickSight User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_ParameterDeclarations")]
        public Amazon.QuickSight.Model.ParameterDeclaration[] Definition_ParameterDeclaration { get; set; }
        #endregion
        
        #region Parameter LinkSharingConfiguration_Permission
        /// <summary>
        /// <para>
        /// <para>A structure that contains the permissions of a shareable link.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LinkSharingConfiguration_Permissions")]
        public Amazon.QuickSight.Model.ResourcePermission[] LinkSharingConfiguration_Permission { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>A structure that contains the permissions of the dashboard. You can use this structure
        /// for granting permissions by providing a list of IAM action information for each principal
        /// ARN. </para><para>To specify no permissions, omit the permissions list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permissions")]
        public Amazon.QuickSight.Model.ResourcePermission[] Permission { get; set; }
        #endregion
        
        #region Parameter Options_QBusinessInsightsStatus
        /// <summary>
        /// <para>
        /// <para>Determines whether insight summaries from Amazon Q Business are allowed in Dashboard
        /// Q&amp;A.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Options_QBusinessInsightsStatus")]
        [AWSConstantClassSource("Amazon.QuickSight.QBusinessInsightsStatus")]
        public Amazon.QuickSight.QBusinessInsightsStatus Options_QBusinessInsightsStatus { get; set; }
        #endregion
        
        #region Parameter ScreenCanvasSizeOptions_ResizeOption
        /// <summary>
        /// <para>
        /// <para>This value determines the layout behavior when the viewport is resized.</para><ul><li><para><c>FIXED</c>: A fixed width will be used when optimizing the layout. In the Amazon
        /// QuickSight console, this option is called <c>Classic</c>.</para></li><li><para><c>RESPONSIVE</c>: The width of the canvas will be responsive and optimized to the
        /// view port. In the Amazon QuickSight console, this option is called <c>Tiled</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_ResizeOption")]
        [AWSConstantClassSource("Amazon.QuickSight.ResizeOption")]
        public Amazon.QuickSight.ResizeOption ScreenCanvasSizeOptions_ResizeOption { get; set; }
        #endregion
        
        #region Parameter PaperMargin_Right
        /// <summary>
        /// <para>
        /// <para>Define the right spacing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_Right")]
        public System.String PaperMargin_Right { get; set; }
        #endregion
        
        #region Parameter DefaultNewSheetConfiguration_SheetContentType
        /// <summary>
        /// <para>
        /// <para>The option that determines the sheet content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_AnalysisDefaults_DefaultNewSheetConfiguration_SheetContentType")]
        [AWSConstantClassSource("Amazon.QuickSight.SheetContentType")]
        public Amazon.QuickSight.SheetContentType DefaultNewSheetConfiguration_SheetContentType { get; set; }
        #endregion
        
        #region Parameter Definition_Sheet
        /// <summary>
        /// <para>
        /// <para>An array of sheet definitions for a dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Sheets")]
        public Amazon.QuickSight.Model.SheetDefinition[] Definition_Sheet { get; set; }
        #endregion
        
        #region Parameter Definition_StaticFile
        /// <summary>
        /// <para>
        /// <para>The static files for the definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_StaticFiles")]
        public Amazon.QuickSight.Model.StaticFile[] Definition_StaticFile { get; set; }
        #endregion
        
        #region Parameter Parameters_StringParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_StringParameters")]
        public Amazon.QuickSight.Model.StringParameter[] Parameters_StringParameter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Contains a map of the key-value pairs for the resource tag or tags assigned to the
        /// dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QuickSight.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ThemeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the theme that is being used for this dashboard.
        /// If you add a value for this field, it overrides the value that is used in the source
        /// entity. The theme ARN must exist in the same Amazon Web Services account where you
        /// create the dashboard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThemeArn { get; set; }
        #endregion
        
        #region Parameter Options_Timezone
        /// <summary>
        /// <para>
        /// <para>Determines the timezone for the analysis.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Options_Timezone")]
        public System.String Options_Timezone { get; set; }
        #endregion
        
        #region Parameter PaperMargin_Top
        /// <summary>
        /// <para>
        /// <para>Define the top spacing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_Top")]
        public System.String PaperMargin_Top { get; set; }
        #endregion
        
        #region Parameter HighlightOperation_Trigger
        /// <summary>
        /// <para>
        /// <para>Specifies whether a highlight operation is initiated by a click or hover, or whether
        /// it's disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Options_CustomActionDefaults_HighlightOperation_Trigger")]
        [AWSConstantClassSource("Amazon.QuickSight.VisualHighlightTrigger")]
        public Amazon.QuickSight.VisualHighlightTrigger HighlightOperation_Trigger { get; set; }
        #endregion
        
        #region Parameter VersionDescription
        /// <summary>
        /// <para>
        /// <para>A description for the first version of the dashboard being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionDescription { get; set; }
        #endregion
        
        #region Parameter SheetControlsOption_VisibilityState
        /// <summary>
        /// <para>
        /// <para>Visibility state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DashboardPublishOptions_SheetControlsOption_VisibilityState")]
        [AWSConstantClassSource("Amazon.QuickSight.DashboardUIState")]
        public Amazon.QuickSight.DashboardUIState SheetControlsOption_VisibilityState { get; set; }
        #endregion
        
        #region Parameter Options_WeekStart
        /// <summary>
        /// <para>
        /// <para>Determines the week start day for an analysis.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Options_WeekStart")]
        [AWSConstantClassSource("Amazon.QuickSight.DayOfTheWeek")]
        public Amazon.QuickSight.DayOfTheWeek Options_WeekStart { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateDashboardResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateDashboardResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DashboardId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DashboardId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DashboardId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DashboardId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSDashboard (CreateDashboard)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateDashboardResponse, NewQSDashboardCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DashboardId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DashboardId = this.DashboardId;
            #if MODULAR
            if (this.DashboardId == null && ParameterWasBound(nameof(this.DashboardId)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AdHocFilteringOption_AvailabilityStatus = this.AdHocFilteringOption_AvailabilityStatus;
            context.DataPointDrillUpDownOption_AvailabilityStatus = this.DataPointDrillUpDownOption_AvailabilityStatus;
            context.DataPointMenuLabelOption_AvailabilityStatus = this.DataPointMenuLabelOption_AvailabilityStatus;
            context.DataPointTooltipOption_AvailabilityStatus = this.DataPointTooltipOption_AvailabilityStatus;
            context.DataQAEnabledOption_AvailabilityStatus = this.DataQAEnabledOption_AvailabilityStatus;
            context.ExportToCSVOption_AvailabilityStatus = this.ExportToCSVOption_AvailabilityStatus;
            context.ExportWithHiddenFieldsOption_AvailabilityStatus = this.ExportWithHiddenFieldsOption_AvailabilityStatus;
            context.SheetControlsOption_VisibilityState = this.SheetControlsOption_VisibilityState;
            context.SheetLayoutElementMaximizationOption_AvailabilityStatus = this.SheetLayoutElementMaximizationOption_AvailabilityStatus;
            context.VisualAxisSortOption_AvailabilityStatus = this.VisualAxisSortOption_AvailabilityStatus;
            context.VisualMenuOption_AvailabilityStatus = this.VisualMenuOption_AvailabilityStatus;
            context.ExportHiddenFieldsOption_AvailabilityStatus = this.ExportHiddenFieldsOption_AvailabilityStatus;
            context.Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth = this.Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth;
            context.Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth = this.Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth;
            context.ScreenCanvasSizeOptions_ResizeOption = this.ScreenCanvasSizeOptions_ResizeOption;
            context.PaperMargin_Bottom = this.PaperMargin_Bottom;
            context.PaperMargin_Left = this.PaperMargin_Left;
            context.PaperMargin_Right = this.PaperMargin_Right;
            context.PaperMargin_Top = this.PaperMargin_Top;
            context.PaperCanvasSizeOptions_PaperOrientation = this.PaperCanvasSizeOptions_PaperOrientation;
            context.PaperCanvasSizeOptions_PaperSize = this.PaperCanvasSizeOptions_PaperSize;
            context.DefaultNewSheetConfiguration_SheetContentType = this.DefaultNewSheetConfiguration_SheetContentType;
            if (this.Definition_CalculatedField != null)
            {
                context.Definition_CalculatedField = new List<Amazon.QuickSight.Model.CalculatedField>(this.Definition_CalculatedField);
            }
            if (this.Definition_ColumnConfiguration != null)
            {
                context.Definition_ColumnConfiguration = new List<Amazon.QuickSight.Model.ColumnConfiguration>(this.Definition_ColumnConfiguration);
            }
            if (this.Definition_DataSetIdentifierDeclaration != null)
            {
                context.Definition_DataSetIdentifierDeclaration = new List<Amazon.QuickSight.Model.DataSetIdentifierDeclaration>(this.Definition_DataSetIdentifierDeclaration);
            }
            if (this.Definition_FilterGroup != null)
            {
                context.Definition_FilterGroup = new List<Amazon.QuickSight.Model.FilterGroup>(this.Definition_FilterGroup);
            }
            context.HighlightOperation_Trigger = this.HighlightOperation_Trigger;
            if (this.Options_ExcludedDataSetArn != null)
            {
                context.Options_ExcludedDataSetArn = new List<System.String>(this.Options_ExcludedDataSetArn);
            }
            context.Options_QBusinessInsightsStatus = this.Options_QBusinessInsightsStatus;
            context.Options_Timezone = this.Options_Timezone;
            context.Options_WeekStart = this.Options_WeekStart;
            if (this.Definition_ParameterDeclaration != null)
            {
                context.Definition_ParameterDeclaration = new List<Amazon.QuickSight.Model.ParameterDeclaration>(this.Definition_ParameterDeclaration);
            }
            if (this.Definition_Sheet != null)
            {
                context.Definition_Sheet = new List<Amazon.QuickSight.Model.SheetDefinition>(this.Definition_Sheet);
            }
            if (this.Definition_StaticFile != null)
            {
                context.Definition_StaticFile = new List<Amazon.QuickSight.Model.StaticFile>(this.Definition_StaticFile);
            }
            if (this.FolderArn != null)
            {
                context.FolderArn = new List<System.String>(this.FolderArn);
            }
            if (this.LinkEntity != null)
            {
                context.LinkEntity = new List<System.String>(this.LinkEntity);
            }
            if (this.LinkSharingConfiguration_Permission != null)
            {
                context.LinkSharingConfiguration_Permission = new List<Amazon.QuickSight.Model.ResourcePermission>(this.LinkSharingConfiguration_Permission);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameters_DateTimeParameter != null)
            {
                context.Parameters_DateTimeParameter = new List<Amazon.QuickSight.Model.DateTimeParameter>(this.Parameters_DateTimeParameter);
            }
            if (this.Parameters_DecimalParameter != null)
            {
                context.Parameters_DecimalParameter = new List<Amazon.QuickSight.Model.DecimalParameter>(this.Parameters_DecimalParameter);
            }
            if (this.Parameters_IntegerParameter != null)
            {
                context.Parameters_IntegerParameter = new List<Amazon.QuickSight.Model.IntegerParameter>(this.Parameters_IntegerParameter);
            }
            if (this.Parameters_StringParameter != null)
            {
                context.Parameters_StringParameter = new List<Amazon.QuickSight.Model.StringParameter>(this.Parameters_StringParameter);
            }
            if (this.Permission != null)
            {
                context.Permission = new List<Amazon.QuickSight.Model.ResourcePermission>(this.Permission);
            }
            context.SourceTemplate_Arn = this.SourceTemplate_Arn;
            if (this.SourceTemplate_DataSetReference != null)
            {
                context.SourceTemplate_DataSetReference = new List<Amazon.QuickSight.Model.DataSetReference>(this.SourceTemplate_DataSetReference);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
            }
            context.ThemeArn = this.ThemeArn;
            context.ValidationStrategy_Mode = this.ValidationStrategy_Mode;
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
            var request = new Amazon.QuickSight.Model.CreateDashboardRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.DashboardId != null)
            {
                request.DashboardId = cmdletContext.DashboardId;
            }
            
             // populate DashboardPublishOptions
            var requestDashboardPublishOptionsIsNull = true;
            request.DashboardPublishOptions = new Amazon.QuickSight.Model.DashboardPublishOptions();
            Amazon.QuickSight.Model.AdHocFilteringOption requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption = null;
            
             // populate AdHocFilteringOption
            var requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption = new Amazon.QuickSight.Model.AdHocFilteringOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption_adHocFilteringOption_AvailabilityStatus = null;
            if (cmdletContext.AdHocFilteringOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption_adHocFilteringOption_AvailabilityStatus = cmdletContext.AdHocFilteringOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption_adHocFilteringOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption_adHocFilteringOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption != null)
            {
                request.DashboardPublishOptions.AdHocFilteringOption = requestDashboardPublishOptions_dashboardPublishOptions_AdHocFilteringOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.DataPointDrillUpDownOption requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption = null;
            
             // populate DataPointDrillUpDownOption
            var requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption = new Amazon.QuickSight.Model.DataPointDrillUpDownOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption_dataPointDrillUpDownOption_AvailabilityStatus = null;
            if (cmdletContext.DataPointDrillUpDownOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption_dataPointDrillUpDownOption_AvailabilityStatus = cmdletContext.DataPointDrillUpDownOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption_dataPointDrillUpDownOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption_dataPointDrillUpDownOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption != null)
            {
                request.DashboardPublishOptions.DataPointDrillUpDownOption = requestDashboardPublishOptions_dashboardPublishOptions_DataPointDrillUpDownOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.DataPointMenuLabelOption requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption = null;
            
             // populate DataPointMenuLabelOption
            var requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption = new Amazon.QuickSight.Model.DataPointMenuLabelOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption_dataPointMenuLabelOption_AvailabilityStatus = null;
            if (cmdletContext.DataPointMenuLabelOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption_dataPointMenuLabelOption_AvailabilityStatus = cmdletContext.DataPointMenuLabelOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption_dataPointMenuLabelOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption_dataPointMenuLabelOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption != null)
            {
                request.DashboardPublishOptions.DataPointMenuLabelOption = requestDashboardPublishOptions_dashboardPublishOptions_DataPointMenuLabelOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.DataPointTooltipOption requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption = null;
            
             // populate DataPointTooltipOption
            var requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption = new Amazon.QuickSight.Model.DataPointTooltipOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption_dataPointTooltipOption_AvailabilityStatus = null;
            if (cmdletContext.DataPointTooltipOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption_dataPointTooltipOption_AvailabilityStatus = cmdletContext.DataPointTooltipOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption_dataPointTooltipOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption_dataPointTooltipOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption != null)
            {
                request.DashboardPublishOptions.DataPointTooltipOption = requestDashboardPublishOptions_dashboardPublishOptions_DataPointTooltipOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.DataQAEnabledOption requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption = null;
            
             // populate DataQAEnabledOption
            var requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption = new Amazon.QuickSight.Model.DataQAEnabledOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption_dataQAEnabledOption_AvailabilityStatus = null;
            if (cmdletContext.DataQAEnabledOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption_dataQAEnabledOption_AvailabilityStatus = cmdletContext.DataQAEnabledOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption_dataQAEnabledOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption_dataQAEnabledOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption != null)
            {
                request.DashboardPublishOptions.DataQAEnabledOption = requestDashboardPublishOptions_dashboardPublishOptions_DataQAEnabledOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.ExportToCSVOption requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption = null;
            
             // populate ExportToCSVOption
            var requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption = new Amazon.QuickSight.Model.ExportToCSVOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption_exportToCSVOption_AvailabilityStatus = null;
            if (cmdletContext.ExportToCSVOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption_exportToCSVOption_AvailabilityStatus = cmdletContext.ExportToCSVOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption_exportToCSVOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption_exportToCSVOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption != null)
            {
                request.DashboardPublishOptions.ExportToCSVOption = requestDashboardPublishOptions_dashboardPublishOptions_ExportToCSVOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.ExportWithHiddenFieldsOption requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption = null;
            
             // populate ExportWithHiddenFieldsOption
            var requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption = new Amazon.QuickSight.Model.ExportWithHiddenFieldsOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption_exportWithHiddenFieldsOption_AvailabilityStatus = null;
            if (cmdletContext.ExportWithHiddenFieldsOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption_exportWithHiddenFieldsOption_AvailabilityStatus = cmdletContext.ExportWithHiddenFieldsOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption_exportWithHiddenFieldsOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption_exportWithHiddenFieldsOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption != null)
            {
                request.DashboardPublishOptions.ExportWithHiddenFieldsOption = requestDashboardPublishOptions_dashboardPublishOptions_ExportWithHiddenFieldsOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.SheetControlsOption requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption = null;
            
             // populate SheetControlsOption
            var requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption = new Amazon.QuickSight.Model.SheetControlsOption();
            Amazon.QuickSight.DashboardUIState requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption_sheetControlsOption_VisibilityState = null;
            if (cmdletContext.SheetControlsOption_VisibilityState != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption_sheetControlsOption_VisibilityState = cmdletContext.SheetControlsOption_VisibilityState;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption_sheetControlsOption_VisibilityState != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption.VisibilityState = requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption_sheetControlsOption_VisibilityState;
                requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption != null)
            {
                request.DashboardPublishOptions.SheetControlsOption = requestDashboardPublishOptions_dashboardPublishOptions_SheetControlsOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.SheetLayoutElementMaximizationOption requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption = null;
            
             // populate SheetLayoutElementMaximizationOption
            var requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption = new Amazon.QuickSight.Model.SheetLayoutElementMaximizationOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption_sheetLayoutElementMaximizationOption_AvailabilityStatus = null;
            if (cmdletContext.SheetLayoutElementMaximizationOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption_sheetLayoutElementMaximizationOption_AvailabilityStatus = cmdletContext.SheetLayoutElementMaximizationOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption_sheetLayoutElementMaximizationOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption_sheetLayoutElementMaximizationOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption != null)
            {
                request.DashboardPublishOptions.SheetLayoutElementMaximizationOption = requestDashboardPublishOptions_dashboardPublishOptions_SheetLayoutElementMaximizationOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.VisualAxisSortOption requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption = null;
            
             // populate VisualAxisSortOption
            var requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption = new Amazon.QuickSight.Model.VisualAxisSortOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption_visualAxisSortOption_AvailabilityStatus = null;
            if (cmdletContext.VisualAxisSortOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption_visualAxisSortOption_AvailabilityStatus = cmdletContext.VisualAxisSortOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption_visualAxisSortOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption_visualAxisSortOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption != null)
            {
                request.DashboardPublishOptions.VisualAxisSortOption = requestDashboardPublishOptions_dashboardPublishOptions_VisualAxisSortOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.VisualMenuOption requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption = null;
            
             // populate VisualMenuOption
            var requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption = new Amazon.QuickSight.Model.VisualMenuOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption_visualMenuOption_AvailabilityStatus = null;
            if (cmdletContext.VisualMenuOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption_visualMenuOption_AvailabilityStatus = cmdletContext.VisualMenuOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption_visualMenuOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption_visualMenuOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption != null)
            {
                request.DashboardPublishOptions.VisualMenuOption = requestDashboardPublishOptions_dashboardPublishOptions_VisualMenuOption;
                requestDashboardPublishOptionsIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Amazon.QuickSight.Model.DashboardVisualPublishOptions requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions = null;
            
             // populate VisualPublishOptions
            var requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptionsIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions = new Amazon.QuickSight.Model.DashboardVisualPublishOptions();
            Amazon.QuickSight.Model.ExportHiddenFieldsOption requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption = null;
            
             // populate ExportHiddenFieldsOption
            var requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOptionIsNull = true;
            requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption = new Amazon.QuickSight.Model.ExportHiddenFieldsOption();
            Amazon.QuickSight.DashboardBehavior requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption_exportHiddenFieldsOption_AvailabilityStatus = null;
            if (cmdletContext.ExportHiddenFieldsOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption_exportHiddenFieldsOption_AvailabilityStatus = cmdletContext.ExportHiddenFieldsOption_AvailabilityStatus;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption_exportHiddenFieldsOption_AvailabilityStatus != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption.AvailabilityStatus = requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption_exportHiddenFieldsOption_AvailabilityStatus;
                requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOptionIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOptionIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption != null)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions.ExportHiddenFieldsOption = requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions_dashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption;
                requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptionsIsNull = false;
            }
             // determine if requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions should be set to null
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptionsIsNull)
            {
                requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions = null;
            }
            if (requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions != null)
            {
                request.DashboardPublishOptions.VisualPublishOptions = requestDashboardPublishOptions_dashboardPublishOptions_VisualPublishOptions;
                requestDashboardPublishOptionsIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if request.DashboardPublishOptions should be set to null
            if (requestDashboardPublishOptionsIsNull)
            {
                request.DashboardPublishOptions = null;
            }
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.QuickSight.Model.DashboardVersionDefinition();
            List<Amazon.QuickSight.Model.CalculatedField> requestDefinition_definition_CalculatedField = null;
            if (cmdletContext.Definition_CalculatedField != null)
            {
                requestDefinition_definition_CalculatedField = cmdletContext.Definition_CalculatedField;
            }
            if (requestDefinition_definition_CalculatedField != null)
            {
                request.Definition.CalculatedFields = requestDefinition_definition_CalculatedField;
                requestDefinitionIsNull = false;
            }
            List<Amazon.QuickSight.Model.ColumnConfiguration> requestDefinition_definition_ColumnConfiguration = null;
            if (cmdletContext.Definition_ColumnConfiguration != null)
            {
                requestDefinition_definition_ColumnConfiguration = cmdletContext.Definition_ColumnConfiguration;
            }
            if (requestDefinition_definition_ColumnConfiguration != null)
            {
                request.Definition.ColumnConfigurations = requestDefinition_definition_ColumnConfiguration;
                requestDefinitionIsNull = false;
            }
            List<Amazon.QuickSight.Model.DataSetIdentifierDeclaration> requestDefinition_definition_DataSetIdentifierDeclaration = null;
            if (cmdletContext.Definition_DataSetIdentifierDeclaration != null)
            {
                requestDefinition_definition_DataSetIdentifierDeclaration = cmdletContext.Definition_DataSetIdentifierDeclaration;
            }
            if (requestDefinition_definition_DataSetIdentifierDeclaration != null)
            {
                request.Definition.DataSetIdentifierDeclarations = requestDefinition_definition_DataSetIdentifierDeclaration;
                requestDefinitionIsNull = false;
            }
            List<Amazon.QuickSight.Model.FilterGroup> requestDefinition_definition_FilterGroup = null;
            if (cmdletContext.Definition_FilterGroup != null)
            {
                requestDefinition_definition_FilterGroup = cmdletContext.Definition_FilterGroup;
            }
            if (requestDefinition_definition_FilterGroup != null)
            {
                request.Definition.FilterGroups = requestDefinition_definition_FilterGroup;
                requestDefinitionIsNull = false;
            }
            List<Amazon.QuickSight.Model.ParameterDeclaration> requestDefinition_definition_ParameterDeclaration = null;
            if (cmdletContext.Definition_ParameterDeclaration != null)
            {
                requestDefinition_definition_ParameterDeclaration = cmdletContext.Definition_ParameterDeclaration;
            }
            if (requestDefinition_definition_ParameterDeclaration != null)
            {
                request.Definition.ParameterDeclarations = requestDefinition_definition_ParameterDeclaration;
                requestDefinitionIsNull = false;
            }
            List<Amazon.QuickSight.Model.SheetDefinition> requestDefinition_definition_Sheet = null;
            if (cmdletContext.Definition_Sheet != null)
            {
                requestDefinition_definition_Sheet = cmdletContext.Definition_Sheet;
            }
            if (requestDefinition_definition_Sheet != null)
            {
                request.Definition.Sheets = requestDefinition_definition_Sheet;
                requestDefinitionIsNull = false;
            }
            List<Amazon.QuickSight.Model.StaticFile> requestDefinition_definition_StaticFile = null;
            if (cmdletContext.Definition_StaticFile != null)
            {
                requestDefinition_definition_StaticFile = cmdletContext.Definition_StaticFile;
            }
            if (requestDefinition_definition_StaticFile != null)
            {
                request.Definition.StaticFiles = requestDefinition_definition_StaticFile;
                requestDefinitionIsNull = false;
            }
            Amazon.QuickSight.Model.AnalysisDefaults requestDefinition_definition_AnalysisDefaults = null;
            
             // populate AnalysisDefaults
            var requestDefinition_definition_AnalysisDefaultsIsNull = true;
            requestDefinition_definition_AnalysisDefaults = new Amazon.QuickSight.Model.AnalysisDefaults();
            Amazon.QuickSight.Model.DefaultNewSheetConfiguration requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration = null;
            
             // populate DefaultNewSheetConfiguration
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration = new Amazon.QuickSight.Model.DefaultNewSheetConfiguration();
            Amazon.QuickSight.SheetContentType requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_defaultNewSheetConfiguration_SheetContentType = null;
            if (cmdletContext.DefaultNewSheetConfiguration_SheetContentType != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_defaultNewSheetConfiguration_SheetContentType = cmdletContext.DefaultNewSheetConfiguration_SheetContentType;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_defaultNewSheetConfiguration_SheetContentType != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration.SheetContentType = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_defaultNewSheetConfiguration_SheetContentType;
            }
            Amazon.QuickSight.Model.DefaultPaginatedLayoutConfiguration requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration = null;
            
             // populate PaginatedLayoutConfiguration
            var requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfigurationIsNull = true;
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration = new Amazon.QuickSight.Model.DefaultPaginatedLayoutConfiguration();
            Amazon.QuickSight.Model.DefaultSectionBasedLayoutConfiguration requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased = null;
            
             // populate SectionBased
            var requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBasedIsNull = true;
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased = new Amazon.QuickSight.Model.DefaultSectionBasedLayoutConfiguration();
            Amazon.QuickSight.Model.SectionBasedLayoutCanvasSizeOptions requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions = null;
            
             // populate CanvasSizeOptions
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions = new Amazon.QuickSight.Model.SectionBasedLayoutCanvasSizeOptions();
            Amazon.QuickSight.Model.SectionBasedLayoutPaperCanvasSizeOptions requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions = null;
            
             // populate PaperCanvasSizeOptions
            var requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptionsIsNull = true;
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions = new Amazon.QuickSight.Model.SectionBasedLayoutPaperCanvasSizeOptions();
            Amazon.QuickSight.PaperOrientation requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_paperCanvasSizeOptions_PaperOrientation = null;
            if (cmdletContext.PaperCanvasSizeOptions_PaperOrientation != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_paperCanvasSizeOptions_PaperOrientation = cmdletContext.PaperCanvasSizeOptions_PaperOrientation;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_paperCanvasSizeOptions_PaperOrientation != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions.PaperOrientation = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_paperCanvasSizeOptions_PaperOrientation;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptionsIsNull = false;
            }
            Amazon.QuickSight.PaperSize requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_paperCanvasSizeOptions_PaperSize = null;
            if (cmdletContext.PaperCanvasSizeOptions_PaperSize != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_paperCanvasSizeOptions_PaperSize = cmdletContext.PaperCanvasSizeOptions_PaperSize;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_paperCanvasSizeOptions_PaperSize != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions.PaperSize = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_paperCanvasSizeOptions_PaperSize;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptionsIsNull = false;
            }
            Amazon.QuickSight.Model.Spacing requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin = null;
            
             // populate PaperMargin
            var requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMarginIsNull = true;
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin = new Amazon.QuickSight.Model.Spacing();
            System.String requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Bottom = null;
            if (cmdletContext.PaperMargin_Bottom != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Bottom = cmdletContext.PaperMargin_Bottom;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Bottom != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin.Bottom = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Bottom;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMarginIsNull = false;
            }
            System.String requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Left = null;
            if (cmdletContext.PaperMargin_Left != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Left = cmdletContext.PaperMargin_Left;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Left != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin.Left = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Left;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMarginIsNull = false;
            }
            System.String requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Right = null;
            if (cmdletContext.PaperMargin_Right != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Right = cmdletContext.PaperMargin_Right;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Right != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin.Right = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Right;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMarginIsNull = false;
            }
            System.String requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Top = null;
            if (cmdletContext.PaperMargin_Top != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Top = cmdletContext.PaperMargin_Top;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Top != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin.Top = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin_paperMargin_Top;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMarginIsNull = false;
            }
             // determine if requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin should be set to null
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMarginIsNull)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin = null;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions.PaperMargin = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperMargin;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptionsIsNull = false;
            }
             // determine if requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions should be set to null
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptionsIsNull)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions = null;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions.PaperCanvasSizeOptions = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased.CanvasSizeOptions = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBasedIsNull = false;
            }
             // determine if requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased should be set to null
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBasedIsNull)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased = null;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration.SectionBased = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfigurationIsNull = false;
            }
             // determine if requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration should be set to null
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfigurationIsNull)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration = null;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration.PaginatedLayoutConfiguration = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration;
            }
            Amazon.QuickSight.Model.DefaultInteractiveLayoutConfiguration requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration = null;
            
             // populate InteractiveLayoutConfiguration
            var requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfigurationIsNull = true;
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration = new Amazon.QuickSight.Model.DefaultInteractiveLayoutConfiguration();
            Amazon.QuickSight.Model.DefaultFreeFormLayoutConfiguration requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm = null;
            
             // populate FreeForm
            var requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeFormIsNull = true;
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm = new Amazon.QuickSight.Model.DefaultFreeFormLayoutConfiguration();
            Amazon.QuickSight.Model.FreeFormLayoutCanvasSizeOptions requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions = null;
            
             // populate CanvasSizeOptions
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions = new Amazon.QuickSight.Model.FreeFormLayoutCanvasSizeOptions();
            Amazon.QuickSight.Model.FreeFormLayoutScreenCanvasSizeOptions requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions = null;
            
             // populate ScreenCanvasSizeOptions
            var requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptionsIsNull = true;
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions = new Amazon.QuickSight.Model.FreeFormLayoutScreenCanvasSizeOptions();
            System.String requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth = null;
            if (cmdletContext.Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth = cmdletContext.Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions.OptimizedViewPortWidth = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptionsIsNull = false;
            }
             // determine if requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions should be set to null
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptionsIsNull)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions = null;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions.ScreenCanvasSizeOptions = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm.CanvasSizeOptions = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeFormIsNull = false;
            }
             // determine if requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm should be set to null
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeFormIsNull)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm = null;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration.FreeForm = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.DefaultGridLayoutConfiguration requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid = null;
            
             // populate Grid
            var requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_GridIsNull = true;
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid = new Amazon.QuickSight.Model.DefaultGridLayoutConfiguration();
            Amazon.QuickSight.Model.GridLayoutCanvasSizeOptions requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions = null;
            
             // populate CanvasSizeOptions
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions = new Amazon.QuickSight.Model.GridLayoutCanvasSizeOptions();
            Amazon.QuickSight.Model.GridLayoutScreenCanvasSizeOptions requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions = null;
            
             // populate ScreenCanvasSizeOptions
            var requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptionsIsNull = true;
            requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions = new Amazon.QuickSight.Model.GridLayoutScreenCanvasSizeOptions();
            System.String requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth = null;
            if (cmdletContext.Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth = cmdletContext.Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions.OptimizedViewPortWidth = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptionsIsNull = false;
            }
            Amazon.QuickSight.ResizeOption requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_screenCanvasSizeOptions_ResizeOption = null;
            if (cmdletContext.ScreenCanvasSizeOptions_ResizeOption != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_screenCanvasSizeOptions_ResizeOption = cmdletContext.ScreenCanvasSizeOptions_ResizeOption;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_screenCanvasSizeOptions_ResizeOption != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions.ResizeOption = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_screenCanvasSizeOptions_ResizeOption;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptionsIsNull = false;
            }
             // determine if requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions should be set to null
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptionsIsNull)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions = null;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions.ScreenCanvasSizeOptions = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid.CanvasSizeOptions = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_GridIsNull = false;
            }
             // determine if requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid should be set to null
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_GridIsNull)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid = null;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration.Grid = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid;
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfigurationIsNull = false;
            }
             // determine if requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration should be set to null
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfigurationIsNull)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration = null;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration != null)
            {
                requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration.InteractiveLayoutConfiguration = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration_definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration;
            }
            if (requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration != null)
            {
                requestDefinition_definition_AnalysisDefaults.DefaultNewSheetConfiguration = requestDefinition_definition_AnalysisDefaults_definition_AnalysisDefaults_DefaultNewSheetConfiguration;
                requestDefinition_definition_AnalysisDefaultsIsNull = false;
            }
             // determine if requestDefinition_definition_AnalysisDefaults should be set to null
            if (requestDefinition_definition_AnalysisDefaultsIsNull)
            {
                requestDefinition_definition_AnalysisDefaults = null;
            }
            if (requestDefinition_definition_AnalysisDefaults != null)
            {
                request.Definition.AnalysisDefaults = requestDefinition_definition_AnalysisDefaults;
                requestDefinitionIsNull = false;
            }
            Amazon.QuickSight.Model.AssetOptions requestDefinition_definition_Options = null;
            
             // populate Options
            var requestDefinition_definition_OptionsIsNull = true;
            requestDefinition_definition_Options = new Amazon.QuickSight.Model.AssetOptions();
            List<System.String> requestDefinition_definition_Options_options_ExcludedDataSetArn = null;
            if (cmdletContext.Options_ExcludedDataSetArn != null)
            {
                requestDefinition_definition_Options_options_ExcludedDataSetArn = cmdletContext.Options_ExcludedDataSetArn;
            }
            if (requestDefinition_definition_Options_options_ExcludedDataSetArn != null)
            {
                requestDefinition_definition_Options.ExcludedDataSetArns = requestDefinition_definition_Options_options_ExcludedDataSetArn;
                requestDefinition_definition_OptionsIsNull = false;
            }
            Amazon.QuickSight.QBusinessInsightsStatus requestDefinition_definition_Options_options_QBusinessInsightsStatus = null;
            if (cmdletContext.Options_QBusinessInsightsStatus != null)
            {
                requestDefinition_definition_Options_options_QBusinessInsightsStatus = cmdletContext.Options_QBusinessInsightsStatus;
            }
            if (requestDefinition_definition_Options_options_QBusinessInsightsStatus != null)
            {
                requestDefinition_definition_Options.QBusinessInsightsStatus = requestDefinition_definition_Options_options_QBusinessInsightsStatus;
                requestDefinition_definition_OptionsIsNull = false;
            }
            System.String requestDefinition_definition_Options_options_Timezone = null;
            if (cmdletContext.Options_Timezone != null)
            {
                requestDefinition_definition_Options_options_Timezone = cmdletContext.Options_Timezone;
            }
            if (requestDefinition_definition_Options_options_Timezone != null)
            {
                requestDefinition_definition_Options.Timezone = requestDefinition_definition_Options_options_Timezone;
                requestDefinition_definition_OptionsIsNull = false;
            }
            Amazon.QuickSight.DayOfTheWeek requestDefinition_definition_Options_options_WeekStart = null;
            if (cmdletContext.Options_WeekStart != null)
            {
                requestDefinition_definition_Options_options_WeekStart = cmdletContext.Options_WeekStart;
            }
            if (requestDefinition_definition_Options_options_WeekStart != null)
            {
                requestDefinition_definition_Options.WeekStart = requestDefinition_definition_Options_options_WeekStart;
                requestDefinition_definition_OptionsIsNull = false;
            }
            Amazon.QuickSight.Model.VisualCustomActionDefaults requestDefinition_definition_Options_definition_Options_CustomActionDefaults = null;
            
             // populate CustomActionDefaults
            var requestDefinition_definition_Options_definition_Options_CustomActionDefaultsIsNull = true;
            requestDefinition_definition_Options_definition_Options_CustomActionDefaults = new Amazon.QuickSight.Model.VisualCustomActionDefaults();
            Amazon.QuickSight.Model.VisualHighlightOperation requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation = null;
            
             // populate HighlightOperation
            var requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperationIsNull = true;
            requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation = new Amazon.QuickSight.Model.VisualHighlightOperation();
            Amazon.QuickSight.VisualHighlightTrigger requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation_highlightOperation_Trigger = null;
            if (cmdletContext.HighlightOperation_Trigger != null)
            {
                requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation_highlightOperation_Trigger = cmdletContext.HighlightOperation_Trigger;
            }
            if (requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation_highlightOperation_Trigger != null)
            {
                requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation.Trigger = requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation_highlightOperation_Trigger;
                requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperationIsNull = false;
            }
             // determine if requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation should be set to null
            if (requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperationIsNull)
            {
                requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation = null;
            }
            if (requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation != null)
            {
                requestDefinition_definition_Options_definition_Options_CustomActionDefaults.HighlightOperation = requestDefinition_definition_Options_definition_Options_CustomActionDefaults_definition_Options_CustomActionDefaults_HighlightOperation;
                requestDefinition_definition_Options_definition_Options_CustomActionDefaultsIsNull = false;
            }
             // determine if requestDefinition_definition_Options_definition_Options_CustomActionDefaults should be set to null
            if (requestDefinition_definition_Options_definition_Options_CustomActionDefaultsIsNull)
            {
                requestDefinition_definition_Options_definition_Options_CustomActionDefaults = null;
            }
            if (requestDefinition_definition_Options_definition_Options_CustomActionDefaults != null)
            {
                requestDefinition_definition_Options.CustomActionDefaults = requestDefinition_definition_Options_definition_Options_CustomActionDefaults;
                requestDefinition_definition_OptionsIsNull = false;
            }
             // determine if requestDefinition_definition_Options should be set to null
            if (requestDefinition_definition_OptionsIsNull)
            {
                requestDefinition_definition_Options = null;
            }
            if (requestDefinition_definition_Options != null)
            {
                request.Definition.Options = requestDefinition_definition_Options;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
            }
            if (cmdletContext.FolderArn != null)
            {
                request.FolderArns = cmdletContext.FolderArn;
            }
            if (cmdletContext.LinkEntity != null)
            {
                request.LinkEntities = cmdletContext.LinkEntity;
            }
            
             // populate LinkSharingConfiguration
            var requestLinkSharingConfigurationIsNull = true;
            request.LinkSharingConfiguration = new Amazon.QuickSight.Model.LinkSharingConfiguration();
            List<Amazon.QuickSight.Model.ResourcePermission> requestLinkSharingConfiguration_linkSharingConfiguration_Permission = null;
            if (cmdletContext.LinkSharingConfiguration_Permission != null)
            {
                requestLinkSharingConfiguration_linkSharingConfiguration_Permission = cmdletContext.LinkSharingConfiguration_Permission;
            }
            if (requestLinkSharingConfiguration_linkSharingConfiguration_Permission != null)
            {
                request.LinkSharingConfiguration.Permissions = requestLinkSharingConfiguration_linkSharingConfiguration_Permission;
                requestLinkSharingConfigurationIsNull = false;
            }
             // determine if request.LinkSharingConfiguration should be set to null
            if (requestLinkSharingConfigurationIsNull)
            {
                request.LinkSharingConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Parameters
            var requestParametersIsNull = true;
            request.Parameters = new Amazon.QuickSight.Model.Parameters();
            List<Amazon.QuickSight.Model.DateTimeParameter> requestParameters_parameters_DateTimeParameter = null;
            if (cmdletContext.Parameters_DateTimeParameter != null)
            {
                requestParameters_parameters_DateTimeParameter = cmdletContext.Parameters_DateTimeParameter;
            }
            if (requestParameters_parameters_DateTimeParameter != null)
            {
                request.Parameters.DateTimeParameters = requestParameters_parameters_DateTimeParameter;
                requestParametersIsNull = false;
            }
            List<Amazon.QuickSight.Model.DecimalParameter> requestParameters_parameters_DecimalParameter = null;
            if (cmdletContext.Parameters_DecimalParameter != null)
            {
                requestParameters_parameters_DecimalParameter = cmdletContext.Parameters_DecimalParameter;
            }
            if (requestParameters_parameters_DecimalParameter != null)
            {
                request.Parameters.DecimalParameters = requestParameters_parameters_DecimalParameter;
                requestParametersIsNull = false;
            }
            List<Amazon.QuickSight.Model.IntegerParameter> requestParameters_parameters_IntegerParameter = null;
            if (cmdletContext.Parameters_IntegerParameter != null)
            {
                requestParameters_parameters_IntegerParameter = cmdletContext.Parameters_IntegerParameter;
            }
            if (requestParameters_parameters_IntegerParameter != null)
            {
                request.Parameters.IntegerParameters = requestParameters_parameters_IntegerParameter;
                requestParametersIsNull = false;
            }
            List<Amazon.QuickSight.Model.StringParameter> requestParameters_parameters_StringParameter = null;
            if (cmdletContext.Parameters_StringParameter != null)
            {
                requestParameters_parameters_StringParameter = cmdletContext.Parameters_StringParameter;
            }
            if (requestParameters_parameters_StringParameter != null)
            {
                request.Parameters.StringParameters = requestParameters_parameters_StringParameter;
                requestParametersIsNull = false;
            }
             // determine if request.Parameters should be set to null
            if (requestParametersIsNull)
            {
                request.Parameters = null;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permissions = cmdletContext.Permission;
            }
            
             // populate SourceEntity
            var requestSourceEntityIsNull = true;
            request.SourceEntity = new Amazon.QuickSight.Model.DashboardSourceEntity();
            Amazon.QuickSight.Model.DashboardSourceTemplate requestSourceEntity_sourceEntity_SourceTemplate = null;
            
             // populate SourceTemplate
            var requestSourceEntity_sourceEntity_SourceTemplateIsNull = true;
            requestSourceEntity_sourceEntity_SourceTemplate = new Amazon.QuickSight.Model.DashboardSourceTemplate();
            System.String requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn = null;
            if (cmdletContext.SourceTemplate_Arn != null)
            {
                requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn = cmdletContext.SourceTemplate_Arn;
            }
            if (requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn != null)
            {
                requestSourceEntity_sourceEntity_SourceTemplate.Arn = requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_Arn;
                requestSourceEntity_sourceEntity_SourceTemplateIsNull = false;
            }
            List<Amazon.QuickSight.Model.DataSetReference> requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_DataSetReference = null;
            if (cmdletContext.SourceTemplate_DataSetReference != null)
            {
                requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_DataSetReference = cmdletContext.SourceTemplate_DataSetReference;
            }
            if (requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_DataSetReference != null)
            {
                requestSourceEntity_sourceEntity_SourceTemplate.DataSetReferences = requestSourceEntity_sourceEntity_SourceTemplate_sourceTemplate_DataSetReference;
                requestSourceEntity_sourceEntity_SourceTemplateIsNull = false;
            }
             // determine if requestSourceEntity_sourceEntity_SourceTemplate should be set to null
            if (requestSourceEntity_sourceEntity_SourceTemplateIsNull)
            {
                requestSourceEntity_sourceEntity_SourceTemplate = null;
            }
            if (requestSourceEntity_sourceEntity_SourceTemplate != null)
            {
                request.SourceEntity.SourceTemplate = requestSourceEntity_sourceEntity_SourceTemplate;
                requestSourceEntityIsNull = false;
            }
             // determine if request.SourceEntity should be set to null
            if (requestSourceEntityIsNull)
            {
                request.SourceEntity = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ThemeArn != null)
            {
                request.ThemeArn = cmdletContext.ThemeArn;
            }
            
             // populate ValidationStrategy
            var requestValidationStrategyIsNull = true;
            request.ValidationStrategy = new Amazon.QuickSight.Model.ValidationStrategy();
            Amazon.QuickSight.ValidationStrategyMode requestValidationStrategy_validationStrategy_Mode = null;
            if (cmdletContext.ValidationStrategy_Mode != null)
            {
                requestValidationStrategy_validationStrategy_Mode = cmdletContext.ValidationStrategy_Mode;
            }
            if (requestValidationStrategy_validationStrategy_Mode != null)
            {
                request.ValidationStrategy.Mode = requestValidationStrategy_validationStrategy_Mode;
                requestValidationStrategyIsNull = false;
            }
             // determine if request.ValidationStrategy should be set to null
            if (requestValidationStrategyIsNull)
            {
                request.ValidationStrategy = null;
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
        
        private Amazon.QuickSight.Model.CreateDashboardResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateDashboardRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateDashboard");
            try
            {
                #if DESKTOP
                return client.CreateDashboard(request);
                #elif CORECLR
                return client.CreateDashboardAsync(request).GetAwaiter().GetResult();
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
            public System.String DashboardId { get; set; }
            public Amazon.QuickSight.DashboardBehavior AdHocFilteringOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardBehavior DataPointDrillUpDownOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardBehavior DataPointMenuLabelOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardBehavior DataPointTooltipOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardBehavior DataQAEnabledOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardBehavior ExportToCSVOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardBehavior ExportWithHiddenFieldsOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardUIState SheetControlsOption_VisibilityState { get; set; }
            public Amazon.QuickSight.DashboardBehavior SheetLayoutElementMaximizationOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardBehavior VisualAxisSortOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardBehavior VisualMenuOption_AvailabilityStatus { get; set; }
            public Amazon.QuickSight.DashboardBehavior ExportHiddenFieldsOption_AvailabilityStatus { get; set; }
            public System.String Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_FreeForm_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth { get; set; }
            public System.String Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_OptimizedViewPortWidth { get; set; }
            public Amazon.QuickSight.ResizeOption ScreenCanvasSizeOptions_ResizeOption { get; set; }
            public System.String PaperMargin_Bottom { get; set; }
            public System.String PaperMargin_Left { get; set; }
            public System.String PaperMargin_Right { get; set; }
            public System.String PaperMargin_Top { get; set; }
            public Amazon.QuickSight.PaperOrientation PaperCanvasSizeOptions_PaperOrientation { get; set; }
            public Amazon.QuickSight.PaperSize PaperCanvasSizeOptions_PaperSize { get; set; }
            public Amazon.QuickSight.SheetContentType DefaultNewSheetConfiguration_SheetContentType { get; set; }
            public List<Amazon.QuickSight.Model.CalculatedField> Definition_CalculatedField { get; set; }
            public List<Amazon.QuickSight.Model.ColumnConfiguration> Definition_ColumnConfiguration { get; set; }
            public List<Amazon.QuickSight.Model.DataSetIdentifierDeclaration> Definition_DataSetIdentifierDeclaration { get; set; }
            public List<Amazon.QuickSight.Model.FilterGroup> Definition_FilterGroup { get; set; }
            public Amazon.QuickSight.VisualHighlightTrigger HighlightOperation_Trigger { get; set; }
            public List<System.String> Options_ExcludedDataSetArn { get; set; }
            public Amazon.QuickSight.QBusinessInsightsStatus Options_QBusinessInsightsStatus { get; set; }
            public System.String Options_Timezone { get; set; }
            public Amazon.QuickSight.DayOfTheWeek Options_WeekStart { get; set; }
            public List<Amazon.QuickSight.Model.ParameterDeclaration> Definition_ParameterDeclaration { get; set; }
            public List<Amazon.QuickSight.Model.SheetDefinition> Definition_Sheet { get; set; }
            public List<Amazon.QuickSight.Model.StaticFile> Definition_StaticFile { get; set; }
            public List<System.String> FolderArn { get; set; }
            public List<System.String> LinkEntity { get; set; }
            public List<Amazon.QuickSight.Model.ResourcePermission> LinkSharingConfiguration_Permission { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.QuickSight.Model.DateTimeParameter> Parameters_DateTimeParameter { get; set; }
            public List<Amazon.QuickSight.Model.DecimalParameter> Parameters_DecimalParameter { get; set; }
            public List<Amazon.QuickSight.Model.IntegerParameter> Parameters_IntegerParameter { get; set; }
            public List<Amazon.QuickSight.Model.StringParameter> Parameters_StringParameter { get; set; }
            public List<Amazon.QuickSight.Model.ResourcePermission> Permission { get; set; }
            public System.String SourceTemplate_Arn { get; set; }
            public List<Amazon.QuickSight.Model.DataSetReference> SourceTemplate_DataSetReference { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public System.String ThemeArn { get; set; }
            public Amazon.QuickSight.ValidationStrategyMode ValidationStrategy_Mode { get; set; }
            public System.String VersionDescription { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateDashboardResponse, NewQSDashboardCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
