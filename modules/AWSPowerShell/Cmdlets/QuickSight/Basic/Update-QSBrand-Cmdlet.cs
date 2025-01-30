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
    /// Updates a brand.
    /// </summary>
    [Cmdlet("Update", "QSBrand", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateBrandResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateBrand API operation.", Operation = new[] {"UpdateBrand"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateBrandResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateBrandResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateBrandResponse object containing multiple properties."
    )]
    public partial class UpdateQSBrandCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LogoConfiguration_AltText
        /// <summary>
        /// <para>
        /// <para>The alt text for the logo.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_LogoConfiguration_AltText")]
        public System.String LogoConfiguration_AltText { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the brand.</para>
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
        
        #region Parameter Accent_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Accent_Background")]
        public System.String Accent_Background { get; set; }
        #endregion
        
        #region Parameter Danger_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Danger_Background")]
        public System.String Danger_Background { get; set; }
        #endregion
        
        #region Parameter Dimension_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Dimension_Background")]
        public System.String Dimension_Background { get; set; }
        #endregion
        
        #region Parameter Info_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Info_Background")]
        public System.String Info_Background { get; set; }
        #endregion
        
        #region Parameter Measure_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Measure_Background")]
        public System.String Measure_Background { get; set; }
        #endregion
        
        #region Parameter Primary_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Primary_Background")]
        public System.String Primary_Background { get; set; }
        #endregion
        
        #region Parameter Secondary_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Secondary_Background")]
        public System.String Secondary_Background { get; set; }
        #endregion
        
        #region Parameter Success_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Success_Background")]
        public System.String Success_Background { get; set; }
        #endregion
        
        #region Parameter Warning_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Warning_Background")]
        public System.String Warning_Background { get; set; }
        #endregion
        
        #region Parameter ContextualNavbar_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar_Background")]
        public System.String ContextualNavbar_Background { get; set; }
        #endregion
        
        #region Parameter GlobalNavbar_Background
        /// <summary>
        /// <para>
        /// <para>The background color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar_Background")]
        public System.String GlobalNavbar_Background { get; set; }
        #endregion
        
        #region Parameter BrandId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon QuickSight brand.</para>
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
        public System.String BrandId { get; set; }
        #endregion
        
        #region Parameter BrandDefinition_BrandName
        /// <summary>
        /// <para>
        /// <para>The name of the brand.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BrandDefinition_BrandName { get; set; }
        #endregion
        
        #region Parameter BrandDefinition_Description
        /// <summary>
        /// <para>
        /// <para>The description of the brand.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BrandDefinition_Description { get; set; }
        #endregion
        
        #region Parameter Accent_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Accent_Foreground")]
        public System.String Accent_Foreground { get; set; }
        #endregion
        
        #region Parameter Danger_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Danger_Foreground")]
        public System.String Danger_Foreground { get; set; }
        #endregion
        
        #region Parameter Dimension_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Dimension_Foreground")]
        public System.String Dimension_Foreground { get; set; }
        #endregion
        
        #region Parameter Info_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Info_Foreground")]
        public System.String Info_Foreground { get; set; }
        #endregion
        
        #region Parameter Measure_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Measure_Foreground")]
        public System.String Measure_Foreground { get; set; }
        #endregion
        
        #region Parameter Primary_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Primary_Foreground")]
        public System.String Primary_Foreground { get; set; }
        #endregion
        
        #region Parameter Secondary_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Secondary_Foreground")]
        public System.String Secondary_Foreground { get; set; }
        #endregion
        
        #region Parameter Success_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Success_Foreground")]
        public System.String Success_Foreground { get; set; }
        #endregion
        
        #region Parameter Warning_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandColorPalette_Warning_Foreground")]
        public System.String Warning_Foreground { get; set; }
        #endregion
        
        #region Parameter ContextualNavbar_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar_Foreground")]
        public System.String ContextualNavbar_Foreground { get; set; }
        #endregion
        
        #region Parameter GlobalNavbar_Foreground
        /// <summary>
        /// <para>
        /// <para>The foreground color.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar_Foreground")]
        public System.String GlobalNavbar_Foreground { get; set; }
        #endregion
        
        #region Parameter Favicon_PublicUrl
        /// <summary>
        /// <para>
        /// <para>The public URL that points to the source image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source_PublicUrl")]
        public System.String Favicon_PublicUrl { get; set; }
        #endregion
        
        #region Parameter Primary_PublicUrl
        /// <summary>
        /// <para>
        /// <para>The public URL that points to the source image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source_PublicUrl")]
        public System.String Primary_PublicUrl { get; set; }
        #endregion
        
        #region Parameter Favicon_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI that points to the source image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source_S3Uri")]
        public System.String Favicon_S3Uri { get; set; }
        #endregion
        
        #region Parameter Primary_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI that points to the source image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source_S3Uri")]
        public System.String Primary_S3Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateBrandResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateBrandResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BrandId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BrandId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BrandId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BrandId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSBrand (UpdateBrand)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateBrandResponse, UpdateQSBrandCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BrandId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Accent_Background = this.Accent_Background;
            context.Accent_Foreground = this.Accent_Foreground;
            context.Danger_Background = this.Danger_Background;
            context.Danger_Foreground = this.Danger_Foreground;
            context.Dimension_Background = this.Dimension_Background;
            context.Dimension_Foreground = this.Dimension_Foreground;
            context.Info_Background = this.Info_Background;
            context.Info_Foreground = this.Info_Foreground;
            context.Measure_Background = this.Measure_Background;
            context.Measure_Foreground = this.Measure_Foreground;
            context.Primary_Background = this.Primary_Background;
            context.Primary_Foreground = this.Primary_Foreground;
            context.Secondary_Background = this.Secondary_Background;
            context.Secondary_Foreground = this.Secondary_Foreground;
            context.Success_Background = this.Success_Background;
            context.Success_Foreground = this.Success_Foreground;
            context.Warning_Background = this.Warning_Background;
            context.Warning_Foreground = this.Warning_Foreground;
            context.ContextualNavbar_Background = this.ContextualNavbar_Background;
            context.ContextualNavbar_Foreground = this.ContextualNavbar_Foreground;
            context.GlobalNavbar_Background = this.GlobalNavbar_Background;
            context.GlobalNavbar_Foreground = this.GlobalNavbar_Foreground;
            context.BrandDefinition_BrandName = this.BrandDefinition_BrandName;
            context.BrandDefinition_Description = this.BrandDefinition_Description;
            context.LogoConfiguration_AltText = this.LogoConfiguration_AltText;
            context.Favicon_PublicUrl = this.Favicon_PublicUrl;
            context.Favicon_S3Uri = this.Favicon_S3Uri;
            context.Primary_PublicUrl = this.Primary_PublicUrl;
            context.Primary_S3Uri = this.Primary_S3Uri;
            context.BrandId = this.BrandId;
            #if MODULAR
            if (this.BrandId == null && ParameterWasBound(nameof(this.BrandId)))
            {
                WriteWarning("You are passing $null as a value for parameter BrandId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.UpdateBrandRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate BrandDefinition
            var requestBrandDefinitionIsNull = true;
            request.BrandDefinition = new Amazon.QuickSight.Model.BrandDefinition();
            System.String requestBrandDefinition_brandDefinition_BrandName = null;
            if (cmdletContext.BrandDefinition_BrandName != null)
            {
                requestBrandDefinition_brandDefinition_BrandName = cmdletContext.BrandDefinition_BrandName;
            }
            if (requestBrandDefinition_brandDefinition_BrandName != null)
            {
                request.BrandDefinition.BrandName = requestBrandDefinition_brandDefinition_BrandName;
                requestBrandDefinitionIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_Description = null;
            if (cmdletContext.BrandDefinition_Description != null)
            {
                requestBrandDefinition_brandDefinition_Description = cmdletContext.BrandDefinition_Description;
            }
            if (requestBrandDefinition_brandDefinition_Description != null)
            {
                request.BrandDefinition.Description = requestBrandDefinition_brandDefinition_Description;
                requestBrandDefinitionIsNull = false;
            }
            Amazon.QuickSight.Model.ApplicationTheme requestBrandDefinition_brandDefinition_ApplicationTheme = null;
            
             // populate ApplicationTheme
            var requestBrandDefinition_brandDefinition_ApplicationThemeIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme = new Amazon.QuickSight.Model.ApplicationTheme();
            Amazon.QuickSight.Model.BrandElementStyle requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle = null;
            
             // populate BrandElementStyle
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyleIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle = new Amazon.QuickSight.Model.BrandElementStyle();
            Amazon.QuickSight.Model.NavbarStyle requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle = null;
            
             // populate NavbarStyle
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyleIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle = new Amazon.QuickSight.Model.NavbarStyle();
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar = null;
            
             // populate ContextualNavbar
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbarIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar_contextualNavbar_Background = null;
            if (cmdletContext.ContextualNavbar_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar_contextualNavbar_Background = cmdletContext.ContextualNavbar_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar_contextualNavbar_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar_contextualNavbar_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbarIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar_contextualNavbar_Foreground = null;
            if (cmdletContext.ContextualNavbar_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar_contextualNavbar_Foreground = cmdletContext.ContextualNavbar_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar_contextualNavbar_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar_contextualNavbar_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbarIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbarIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle.ContextualNavbar = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_ContextualNavbar;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyleIsNull = false;
            }
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar = null;
            
             // populate GlobalNavbar
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbarIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar_globalNavbar_Background = null;
            if (cmdletContext.GlobalNavbar_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar_globalNavbar_Background = cmdletContext.GlobalNavbar_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar_globalNavbar_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar_globalNavbar_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbarIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar_globalNavbar_Foreground = null;
            if (cmdletContext.GlobalNavbar_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar_globalNavbar_Foreground = cmdletContext.GlobalNavbar_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar_globalNavbar_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar_globalNavbar_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbarIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbarIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle.GlobalNavbar = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle_GlobalNavbar;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyleIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyleIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle.NavbarStyle = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle_brandDefinition_ApplicationTheme_BrandElementStyle_NavbarStyle;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyleIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyleIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme.BrandElementStyle = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandElementStyle;
                requestBrandDefinition_brandDefinition_ApplicationThemeIsNull = false;
            }
            Amazon.QuickSight.Model.BrandColorPalette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette = null;
            
             // populate BrandColorPalette
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette = new Amazon.QuickSight.Model.BrandColorPalette();
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent = null;
            
             // populate Accent
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_AccentIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent_accent_Background = null;
            if (cmdletContext.Accent_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent_accent_Background = cmdletContext.Accent_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent_accent_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent_accent_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_AccentIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent_accent_Foreground = null;
            if (cmdletContext.Accent_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent_accent_Foreground = cmdletContext.Accent_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent_accent_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent_accent_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_AccentIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_AccentIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette.Accent = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Accent;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull = false;
            }
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger = null;
            
             // populate Danger
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_DangerIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger_danger_Background = null;
            if (cmdletContext.Danger_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger_danger_Background = cmdletContext.Danger_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger_danger_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger_danger_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_DangerIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger_danger_Foreground = null;
            if (cmdletContext.Danger_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger_danger_Foreground = cmdletContext.Danger_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger_danger_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger_danger_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_DangerIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_DangerIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette.Danger = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Danger;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull = false;
            }
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension = null;
            
             // populate Dimension
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_DimensionIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension_dimension_Background = null;
            if (cmdletContext.Dimension_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension_dimension_Background = cmdletContext.Dimension_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension_dimension_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension_dimension_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_DimensionIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension_dimension_Foreground = null;
            if (cmdletContext.Dimension_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension_dimension_Foreground = cmdletContext.Dimension_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension_dimension_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension_dimension_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_DimensionIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_DimensionIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette.Dimension = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Dimension;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull = false;
            }
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info = null;
            
             // populate Info
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_InfoIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info_info_Background = null;
            if (cmdletContext.Info_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info_info_Background = cmdletContext.Info_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info_info_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info_info_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_InfoIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info_info_Foreground = null;
            if (cmdletContext.Info_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info_info_Foreground = cmdletContext.Info_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info_info_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info_info_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_InfoIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_InfoIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette.Info = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Info;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull = false;
            }
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure = null;
            
             // populate Measure
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_MeasureIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure_measure_Background = null;
            if (cmdletContext.Measure_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure_measure_Background = cmdletContext.Measure_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure_measure_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure_measure_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_MeasureIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure_measure_Foreground = null;
            if (cmdletContext.Measure_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure_measure_Foreground = cmdletContext.Measure_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure_measure_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure_measure_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_MeasureIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_MeasureIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette.Measure = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Measure;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull = false;
            }
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary = null;
            
             // populate Primary
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_PrimaryIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary_primary_Background = null;
            if (cmdletContext.Primary_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary_primary_Background = cmdletContext.Primary_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary_primary_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary_primary_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_PrimaryIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary_primary_Foreground = null;
            if (cmdletContext.Primary_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary_primary_Foreground = cmdletContext.Primary_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary_primary_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary_primary_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_PrimaryIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_PrimaryIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette.Primary = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Primary;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull = false;
            }
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary = null;
            
             // populate Secondary
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_SecondaryIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary_secondary_Background = null;
            if (cmdletContext.Secondary_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary_secondary_Background = cmdletContext.Secondary_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary_secondary_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary_secondary_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_SecondaryIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary_secondary_Foreground = null;
            if (cmdletContext.Secondary_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary_secondary_Foreground = cmdletContext.Secondary_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary_secondary_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary_secondary_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_SecondaryIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_SecondaryIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette.Secondary = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Secondary;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull = false;
            }
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success = null;
            
             // populate Success
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_SuccessIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success_success_Background = null;
            if (cmdletContext.Success_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success_success_Background = cmdletContext.Success_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success_success_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success_success_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_SuccessIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success_success_Foreground = null;
            if (cmdletContext.Success_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success_success_Foreground = cmdletContext.Success_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success_success_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success_success_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_SuccessIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_SuccessIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette.Success = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Success;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull = false;
            }
            Amazon.QuickSight.Model.Palette requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning = null;
            
             // populate Warning
            var requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_WarningIsNull = true;
            requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning = new Amazon.QuickSight.Model.Palette();
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning_warning_Background = null;
            if (cmdletContext.Warning_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning_warning_Background = cmdletContext.Warning_Background;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning_warning_Background != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning.Background = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning_warning_Background;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_WarningIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning_warning_Foreground = null;
            if (cmdletContext.Warning_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning_warning_Foreground = cmdletContext.Warning_Foreground;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning_warning_Foreground != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning.Foreground = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning_warning_Foreground;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_WarningIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_WarningIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette.Warning = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette_brandDefinition_ApplicationTheme_BrandColorPalette_Warning;
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPaletteIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette != null)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme.BrandColorPalette = requestBrandDefinition_brandDefinition_ApplicationTheme_brandDefinition_ApplicationTheme_BrandColorPalette;
                requestBrandDefinition_brandDefinition_ApplicationThemeIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_ApplicationTheme should be set to null
            if (requestBrandDefinition_brandDefinition_ApplicationThemeIsNull)
            {
                requestBrandDefinition_brandDefinition_ApplicationTheme = null;
            }
            if (requestBrandDefinition_brandDefinition_ApplicationTheme != null)
            {
                request.BrandDefinition.ApplicationTheme = requestBrandDefinition_brandDefinition_ApplicationTheme;
                requestBrandDefinitionIsNull = false;
            }
            Amazon.QuickSight.Model.LogoConfiguration requestBrandDefinition_brandDefinition_LogoConfiguration = null;
            
             // populate LogoConfiguration
            var requestBrandDefinition_brandDefinition_LogoConfigurationIsNull = true;
            requestBrandDefinition_brandDefinition_LogoConfiguration = new Amazon.QuickSight.Model.LogoConfiguration();
            System.String requestBrandDefinition_brandDefinition_LogoConfiguration_logoConfiguration_AltText = null;
            if (cmdletContext.LogoConfiguration_AltText != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_logoConfiguration_AltText = cmdletContext.LogoConfiguration_AltText;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_logoConfiguration_AltText != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration.AltText = requestBrandDefinition_brandDefinition_LogoConfiguration_logoConfiguration_AltText;
                requestBrandDefinition_brandDefinition_LogoConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.LogoSetConfiguration requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet = null;
            
             // populate LogoSet
            var requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSetIsNull = true;
            requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet = new Amazon.QuickSight.Model.LogoSetConfiguration();
            Amazon.QuickSight.Model.ImageSetConfiguration requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon = null;
            
             // populate Favicon
            var requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_FaviconIsNull = true;
            requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon = new Amazon.QuickSight.Model.ImageSetConfiguration();
            Amazon.QuickSight.Model.ImageConfiguration requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original = null;
            
             // populate Original
            var requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_OriginalIsNull = true;
            requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original = new Amazon.QuickSight.Model.ImageConfiguration();
            Amazon.QuickSight.Model.ImageSource requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source = null;
            
             // populate Source
            var requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_SourceIsNull = true;
            requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source = new Amazon.QuickSight.Model.ImageSource();
            System.String requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source_favicon_PublicUrl = null;
            if (cmdletContext.Favicon_PublicUrl != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source_favicon_PublicUrl = cmdletContext.Favicon_PublicUrl;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source_favicon_PublicUrl != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source.PublicUrl = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source_favicon_PublicUrl;
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_SourceIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source_favicon_S3Uri = null;
            if (cmdletContext.Favicon_S3Uri != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source_favicon_S3Uri = cmdletContext.Favicon_S3Uri;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source_favicon_S3Uri != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source.S3Uri = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source_favicon_S3Uri;
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_SourceIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source should be set to null
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_SourceIsNull)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source = null;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original.Source = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original_Source;
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_OriginalIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original should be set to null
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_OriginalIsNull)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original = null;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon.Original = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon_brandDefinition_LogoConfiguration_LogoSet_Favicon_Original;
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_FaviconIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon should be set to null
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_FaviconIsNull)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon = null;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet.Favicon = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Favicon;
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSetIsNull = false;
            }
            Amazon.QuickSight.Model.ImageSetConfiguration requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary = null;
            
             // populate Primary
            var requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_PrimaryIsNull = true;
            requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary = new Amazon.QuickSight.Model.ImageSetConfiguration();
            Amazon.QuickSight.Model.ImageConfiguration requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original = null;
            
             // populate Original
            var requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_OriginalIsNull = true;
            requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original = new Amazon.QuickSight.Model.ImageConfiguration();
            Amazon.QuickSight.Model.ImageSource requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source = null;
            
             // populate Source
            var requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_SourceIsNull = true;
            requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source = new Amazon.QuickSight.Model.ImageSource();
            System.String requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source_primary_PublicUrl = null;
            if (cmdletContext.Primary_PublicUrl != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source_primary_PublicUrl = cmdletContext.Primary_PublicUrl;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source_primary_PublicUrl != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source.PublicUrl = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source_primary_PublicUrl;
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_SourceIsNull = false;
            }
            System.String requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source_primary_S3Uri = null;
            if (cmdletContext.Primary_S3Uri != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source_primary_S3Uri = cmdletContext.Primary_S3Uri;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source_primary_S3Uri != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source.S3Uri = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source_primary_S3Uri;
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_SourceIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source should be set to null
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_SourceIsNull)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source = null;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original.Source = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_brandDefinition_LogoConfiguration_LogoSet_Primary_Original_Source;
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_OriginalIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original should be set to null
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_OriginalIsNull)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original = null;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary.Original = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary_brandDefinition_LogoConfiguration_LogoSet_Primary_Original;
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_PrimaryIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary should be set to null
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_PrimaryIsNull)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary = null;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet.Primary = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet_brandDefinition_LogoConfiguration_LogoSet_Primary;
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSetIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet should be set to null
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSetIsNull)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet = null;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet != null)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration.LogoSet = requestBrandDefinition_brandDefinition_LogoConfiguration_brandDefinition_LogoConfiguration_LogoSet;
                requestBrandDefinition_brandDefinition_LogoConfigurationIsNull = false;
            }
             // determine if requestBrandDefinition_brandDefinition_LogoConfiguration should be set to null
            if (requestBrandDefinition_brandDefinition_LogoConfigurationIsNull)
            {
                requestBrandDefinition_brandDefinition_LogoConfiguration = null;
            }
            if (requestBrandDefinition_brandDefinition_LogoConfiguration != null)
            {
                request.BrandDefinition.LogoConfiguration = requestBrandDefinition_brandDefinition_LogoConfiguration;
                requestBrandDefinitionIsNull = false;
            }
             // determine if request.BrandDefinition should be set to null
            if (requestBrandDefinitionIsNull)
            {
                request.BrandDefinition = null;
            }
            if (cmdletContext.BrandId != null)
            {
                request.BrandId = cmdletContext.BrandId;
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
        
        private Amazon.QuickSight.Model.UpdateBrandResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateBrandRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateBrand");
            try
            {
                #if DESKTOP
                return client.UpdateBrand(request);
                #elif CORECLR
                return client.UpdateBrandAsync(request).GetAwaiter().GetResult();
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
            public System.String Accent_Background { get; set; }
            public System.String Accent_Foreground { get; set; }
            public System.String Danger_Background { get; set; }
            public System.String Danger_Foreground { get; set; }
            public System.String Dimension_Background { get; set; }
            public System.String Dimension_Foreground { get; set; }
            public System.String Info_Background { get; set; }
            public System.String Info_Foreground { get; set; }
            public System.String Measure_Background { get; set; }
            public System.String Measure_Foreground { get; set; }
            public System.String Primary_Background { get; set; }
            public System.String Primary_Foreground { get; set; }
            public System.String Secondary_Background { get; set; }
            public System.String Secondary_Foreground { get; set; }
            public System.String Success_Background { get; set; }
            public System.String Success_Foreground { get; set; }
            public System.String Warning_Background { get; set; }
            public System.String Warning_Foreground { get; set; }
            public System.String ContextualNavbar_Background { get; set; }
            public System.String ContextualNavbar_Foreground { get; set; }
            public System.String GlobalNavbar_Background { get; set; }
            public System.String GlobalNavbar_Foreground { get; set; }
            public System.String BrandDefinition_BrandName { get; set; }
            public System.String BrandDefinition_Description { get; set; }
            public System.String LogoConfiguration_AltText { get; set; }
            public System.String Favicon_PublicUrl { get; set; }
            public System.String Favicon_S3Uri { get; set; }
            public System.String Primary_PublicUrl { get; set; }
            public System.String Primary_S3Uri { get; set; }
            public System.String BrandId { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateBrandResponse, UpdateQSBrandCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
