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
using Amazon.AmplifyUIBuilder;
using Amazon.AmplifyUIBuilder.Model;

namespace Amazon.PowerShell.Cmdlets.AMPUI
{
    /// <summary>
    /// Creates a new form for an Amplify app.
    /// </summary>
    [Cmdlet("New", "AMPUIForm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyUIBuilder.Model.Form")]
    [AWSCmdlet("Calls the AWS Amplify UI Builder CreateForm API operation.", Operation = new[] {"CreateForm"}, SelectReturnType = typeof(Amazon.AmplifyUIBuilder.Model.CreateFormResponse))]
    [AWSCmdletOutput("Amazon.AmplifyUIBuilder.Model.Form or Amazon.AmplifyUIBuilder.Model.CreateFormResponse",
        "This cmdlet returns an Amazon.AmplifyUIBuilder.Model.Form object.",
        "The service call response (type Amazon.AmplifyUIBuilder.Model.CreateFormResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAMPUIFormCmdlet : AmazonAmplifyUIBuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the Amplify app to associate with the form.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Cta_Cancel_Position_Below
        /// <summary>
        /// <para>
        /// <para>The field position is below the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Create_Form_Cancel_Position_Below")]
        public System.String FormToCreate_Cta_Cancel_Position_Below { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Cta_Clear_Position_Below
        /// <summary>
        /// <para>
        /// <para>The field position is below the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Create_Form_Clear_Position_Below")]
        public System.String FormToCreate_Cta_Clear_Position_Below { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Cta_Submit_Position_Below
        /// <summary>
        /// <para>
        /// <para>The field position is below the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Create_Form_Submit_Position_Below")]
        public System.String FormToCreate_Cta_Submit_Position_Below { get; set; }
        #endregion
        
        #region Parameter Cancel_Child
        /// <summary>
        /// <para>
        /// <para>Describes the button's properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Cta_Cancel_Children")]
        public System.String Cancel_Child { get; set; }
        #endregion
        
        #region Parameter Clear_Child
        /// <summary>
        /// <para>
        /// <para>Describes the button's properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Cta_Clear_Children")]
        public System.String Clear_Child { get; set; }
        #endregion
        
        #region Parameter Submit_Child
        /// <summary>
        /// <para>
        /// <para>Describes the button's properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Cta_Submit_Children")]
        public System.String Submit_Child { get; set; }
        #endregion
        
        #region Parameter DataType_DataSourceType
        /// <summary>
        /// <para>
        /// <para>The data source type, either an Amplify DataStore model or a custom data type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FormToCreate_DataType_DataSourceType")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FormDataSourceType")]
        public Amazon.AmplifyUIBuilder.FormDataSourceType DataType_DataSourceType { get; set; }
        #endregion
        
        #region Parameter DataType_DataTypeName
        /// <summary>
        /// <para>
        /// <para>The unique name of the data type you are using as the data source for the form.</para>
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
        [Alias("FormToCreate_DataType_DataTypeName")]
        public System.String DataType_DataTypeName { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the backend environment that is a part of the Amplify app.</para>
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
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter Cancel_Excluded
        /// <summary>
        /// <para>
        /// <para>Specifies whether the button is visible on the form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Cta_Cancel_Excluded")]
        public System.Boolean? Cancel_Excluded { get; set; }
        #endregion
        
        #region Parameter Clear_Excluded
        /// <summary>
        /// <para>
        /// <para>Specifies whether the button is visible on the form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Cta_Clear_Excluded")]
        public System.Boolean? Clear_Excluded { get; set; }
        #endregion
        
        #region Parameter Submit_Excluded
        /// <summary>
        /// <para>
        /// <para>Specifies whether the button is visible on the form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Cta_Submit_Excluded")]
        public System.Boolean? Submit_Excluded { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Field
        /// <summary>
        /// <para>
        /// <para>The configuration information for the form's fields.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FormToCreate_Fields")]
        public System.Collections.Hashtable FormToCreate_Field { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Cta_Cancel_Position_Fixed
        /// <summary>
        /// <para>
        /// <para>The field position is fixed and doesn't change in relation to other fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Create_Form_Cancel_Position_Fixed")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FixedPosition")]
        public Amazon.AmplifyUIBuilder.FixedPosition FormToCreate_Cta_Cancel_Position_Fixed { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Cta_Clear_Position_Fixed
        /// <summary>
        /// <para>
        /// <para>The field position is fixed and doesn't change in relation to other fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Create_Form_Clear_Position_Fixed")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FixedPosition")]
        public Amazon.AmplifyUIBuilder.FixedPosition FormToCreate_Cta_Clear_Position_Fixed { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Cta_Submit_Position_Fixed
        /// <summary>
        /// <para>
        /// <para>The field position is fixed and doesn't change in relation to other fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Create_Form_Submit_Position_Fixed")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FixedPosition")]
        public Amazon.AmplifyUIBuilder.FixedPosition FormToCreate_Cta_Submit_Position_Fixed { get; set; }
        #endregion
        
        #region Parameter FormToCreate_FormActionType
        /// <summary>
        /// <para>
        /// <para>Specifies whether to perform a create or update action on the form.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FormActionType")]
        public Amazon.AmplifyUIBuilder.FormActionType FormToCreate_FormActionType { get; set; }
        #endregion
        
        #region Parameter FormToCreate_LabelDecorator
        /// <summary>
        /// <para>
        /// <para>Specifies an icon or decoration to display on the form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.LabelDecorator")]
        public Amazon.AmplifyUIBuilder.LabelDecorator FormToCreate_LabelDecorator { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the form.</para>
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
        public System.String FormToCreate_Name { get; set; }
        #endregion
        
        #region Parameter Cta_Position
        /// <summary>
        /// <para>
        /// <para>The position of the button.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Cta_Position")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FormButtonsPosition")]
        public Amazon.AmplifyUIBuilder.FormButtonsPosition Cta_Position { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Cta_Cancel_Position_RightOf
        /// <summary>
        /// <para>
        /// <para>The field position is to the right of the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Create_Form_Cancel_Position_RightOf")]
        public System.String FormToCreate_Cta_Cancel_Position_RightOf { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Cta_Clear_Position_RightOf
        /// <summary>
        /// <para>
        /// <para>The field position is to the right of the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Create_Form_Clear_Position_RightOf")]
        public System.String FormToCreate_Cta_Clear_Position_RightOf { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Cta_Submit_Position_RightOf
        /// <summary>
        /// <para>
        /// <para>The field position is to the right of the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Create_Form_Submit_Position_RightOf")]
        public System.String FormToCreate_Cta_Submit_Position_RightOf { get; set; }
        #endregion
        
        #region Parameter FormToCreate_SchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the form.</para>
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
        public System.String FormToCreate_SchemaVersion { get; set; }
        #endregion
        
        #region Parameter FormToCreate_SectionalElement
        /// <summary>
        /// <para>
        /// <para>The configuration information for the visual helper elements for the form. These elements
        /// are not associated with any data.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FormToCreate_SectionalElements")]
        public System.Collections.Hashtable FormToCreate_SectionalElement { get; set; }
        #endregion
        
        #region Parameter FormToCreate_Tag
        /// <summary>
        /// <para>
        /// <para>One or more key-value pairs to use when tagging the form data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Tags")]
        public System.Collections.Hashtable FormToCreate_Tag { get; set; }
        #endregion
        
        #region Parameter HorizontalGap_TokenReference
        /// <summary>
        /// <para>
        /// <para>A reference to a design token to use to bind the form's style properties to an existing
        /// theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Style_HorizontalGap_TokenReference")]
        public System.String HorizontalGap_TokenReference { get; set; }
        #endregion
        
        #region Parameter OuterPadding_TokenReference
        /// <summary>
        /// <para>
        /// <para>A reference to a design token to use to bind the form's style properties to an existing
        /// theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Style_OuterPadding_TokenReference")]
        public System.String OuterPadding_TokenReference { get; set; }
        #endregion
        
        #region Parameter VerticalGap_TokenReference
        /// <summary>
        /// <para>
        /// <para>A reference to a design token to use to bind the form's style properties to an existing
        /// theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Style_VerticalGap_TokenReference")]
        public System.String VerticalGap_TokenReference { get; set; }
        #endregion
        
        #region Parameter HorizontalGap_Value
        /// <summary>
        /// <para>
        /// <para>The value of the style setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Style_HorizontalGap_Value")]
        public System.String HorizontalGap_Value { get; set; }
        #endregion
        
        #region Parameter OuterPadding_Value
        /// <summary>
        /// <para>
        /// <para>The value of the style setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Style_OuterPadding_Value")]
        public System.String OuterPadding_Value { get; set; }
        #endregion
        
        #region Parameter VerticalGap_Value
        /// <summary>
        /// <para>
        /// <para>The value of the style setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FormToCreate_Style_VerticalGap_Value")]
        public System.String VerticalGap_Value { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The unique client token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Entity'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyUIBuilder.Model.CreateFormResponse).
        /// Specifying the name of a property of type Amazon.AmplifyUIBuilder.Model.CreateFormResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entity";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPUIForm (CreateForm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyUIBuilder.Model.CreateFormResponse, NewAMPUIFormCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EnvironmentName = this.EnvironmentName;
            #if MODULAR
            if (this.EnvironmentName == null && ParameterWasBound(nameof(this.EnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Cancel_Child = this.Cancel_Child;
            context.Cancel_Excluded = this.Cancel_Excluded;
            context.FormToCreate_Cta_Cancel_Position_Below = this.FormToCreate_Cta_Cancel_Position_Below;
            context.FormToCreate_Cta_Cancel_Position_Fixed = this.FormToCreate_Cta_Cancel_Position_Fixed;
            context.FormToCreate_Cta_Cancel_Position_RightOf = this.FormToCreate_Cta_Cancel_Position_RightOf;
            context.Clear_Child = this.Clear_Child;
            context.Clear_Excluded = this.Clear_Excluded;
            context.FormToCreate_Cta_Clear_Position_Below = this.FormToCreate_Cta_Clear_Position_Below;
            context.FormToCreate_Cta_Clear_Position_Fixed = this.FormToCreate_Cta_Clear_Position_Fixed;
            context.FormToCreate_Cta_Clear_Position_RightOf = this.FormToCreate_Cta_Clear_Position_RightOf;
            context.Cta_Position = this.Cta_Position;
            context.Submit_Child = this.Submit_Child;
            context.Submit_Excluded = this.Submit_Excluded;
            context.FormToCreate_Cta_Submit_Position_Below = this.FormToCreate_Cta_Submit_Position_Below;
            context.FormToCreate_Cta_Submit_Position_Fixed = this.FormToCreate_Cta_Submit_Position_Fixed;
            context.FormToCreate_Cta_Submit_Position_RightOf = this.FormToCreate_Cta_Submit_Position_RightOf;
            context.DataType_DataSourceType = this.DataType_DataSourceType;
            #if MODULAR
            if (this.DataType_DataSourceType == null && ParameterWasBound(nameof(this.DataType_DataSourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter DataType_DataSourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataType_DataTypeName = this.DataType_DataTypeName;
            #if MODULAR
            if (this.DataType_DataTypeName == null && ParameterWasBound(nameof(this.DataType_DataTypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter DataType_DataTypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FormToCreate_Field != null)
            {
                context.FormToCreate_Field = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.FieldConfig>(StringComparer.Ordinal);
                foreach (var hashKey in this.FormToCreate_Field.Keys)
                {
                    context.FormToCreate_Field.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.FieldConfig)(this.FormToCreate_Field[hashKey]));
                }
            }
            #if MODULAR
            if (this.FormToCreate_Field == null && ParameterWasBound(nameof(this.FormToCreate_Field)))
            {
                WriteWarning("You are passing $null as a value for parameter FormToCreate_Field which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FormToCreate_FormActionType = this.FormToCreate_FormActionType;
            #if MODULAR
            if (this.FormToCreate_FormActionType == null && ParameterWasBound(nameof(this.FormToCreate_FormActionType)))
            {
                WriteWarning("You are passing $null as a value for parameter FormToCreate_FormActionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FormToCreate_LabelDecorator = this.FormToCreate_LabelDecorator;
            context.FormToCreate_Name = this.FormToCreate_Name;
            #if MODULAR
            if (this.FormToCreate_Name == null && ParameterWasBound(nameof(this.FormToCreate_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter FormToCreate_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FormToCreate_SchemaVersion = this.FormToCreate_SchemaVersion;
            #if MODULAR
            if (this.FormToCreate_SchemaVersion == null && ParameterWasBound(nameof(this.FormToCreate_SchemaVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter FormToCreate_SchemaVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FormToCreate_SectionalElement != null)
            {
                context.FormToCreate_SectionalElement = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.SectionalElement>(StringComparer.Ordinal);
                foreach (var hashKey in this.FormToCreate_SectionalElement.Keys)
                {
                    context.FormToCreate_SectionalElement.Add((String)hashKey, (Amazon.AmplifyUIBuilder.Model.SectionalElement)(this.FormToCreate_SectionalElement[hashKey]));
                }
            }
            #if MODULAR
            if (this.FormToCreate_SectionalElement == null && ParameterWasBound(nameof(this.FormToCreate_SectionalElement)))
            {
                WriteWarning("You are passing $null as a value for parameter FormToCreate_SectionalElement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HorizontalGap_TokenReference = this.HorizontalGap_TokenReference;
            context.HorizontalGap_Value = this.HorizontalGap_Value;
            context.OuterPadding_TokenReference = this.OuterPadding_TokenReference;
            context.OuterPadding_Value = this.OuterPadding_Value;
            context.VerticalGap_TokenReference = this.VerticalGap_TokenReference;
            context.VerticalGap_Value = this.VerticalGap_Value;
            if (this.FormToCreate_Tag != null)
            {
                context.FormToCreate_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.FormToCreate_Tag.Keys)
                {
                    context.FormToCreate_Tag.Add((String)hashKey, (System.String)(this.FormToCreate_Tag[hashKey]));
                }
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
            var request = new Amazon.AmplifyUIBuilder.Model.CreateFormRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            
             // populate FormToCreate
            var requestFormToCreateIsNull = true;
            request.FormToCreate = new Amazon.AmplifyUIBuilder.Model.CreateFormData();
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.FieldConfig> requestFormToCreate_formToCreate_Field = null;
            if (cmdletContext.FormToCreate_Field != null)
            {
                requestFormToCreate_formToCreate_Field = cmdletContext.FormToCreate_Field;
            }
            if (requestFormToCreate_formToCreate_Field != null)
            {
                request.FormToCreate.Fields = requestFormToCreate_formToCreate_Field;
                requestFormToCreateIsNull = false;
            }
            Amazon.AmplifyUIBuilder.FormActionType requestFormToCreate_formToCreate_FormActionType = null;
            if (cmdletContext.FormToCreate_FormActionType != null)
            {
                requestFormToCreate_formToCreate_FormActionType = cmdletContext.FormToCreate_FormActionType;
            }
            if (requestFormToCreate_formToCreate_FormActionType != null)
            {
                request.FormToCreate.FormActionType = requestFormToCreate_formToCreate_FormActionType;
                requestFormToCreateIsNull = false;
            }
            Amazon.AmplifyUIBuilder.LabelDecorator requestFormToCreate_formToCreate_LabelDecorator = null;
            if (cmdletContext.FormToCreate_LabelDecorator != null)
            {
                requestFormToCreate_formToCreate_LabelDecorator = cmdletContext.FormToCreate_LabelDecorator;
            }
            if (requestFormToCreate_formToCreate_LabelDecorator != null)
            {
                request.FormToCreate.LabelDecorator = requestFormToCreate_formToCreate_LabelDecorator;
                requestFormToCreateIsNull = false;
            }
            System.String requestFormToCreate_formToCreate_Name = null;
            if (cmdletContext.FormToCreate_Name != null)
            {
                requestFormToCreate_formToCreate_Name = cmdletContext.FormToCreate_Name;
            }
            if (requestFormToCreate_formToCreate_Name != null)
            {
                request.FormToCreate.Name = requestFormToCreate_formToCreate_Name;
                requestFormToCreateIsNull = false;
            }
            System.String requestFormToCreate_formToCreate_SchemaVersion = null;
            if (cmdletContext.FormToCreate_SchemaVersion != null)
            {
                requestFormToCreate_formToCreate_SchemaVersion = cmdletContext.FormToCreate_SchemaVersion;
            }
            if (requestFormToCreate_formToCreate_SchemaVersion != null)
            {
                request.FormToCreate.SchemaVersion = requestFormToCreate_formToCreate_SchemaVersion;
                requestFormToCreateIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.SectionalElement> requestFormToCreate_formToCreate_SectionalElement = null;
            if (cmdletContext.FormToCreate_SectionalElement != null)
            {
                requestFormToCreate_formToCreate_SectionalElement = cmdletContext.FormToCreate_SectionalElement;
            }
            if (requestFormToCreate_formToCreate_SectionalElement != null)
            {
                request.FormToCreate.SectionalElements = requestFormToCreate_formToCreate_SectionalElement;
                requestFormToCreateIsNull = false;
            }
            Dictionary<System.String, System.String> requestFormToCreate_formToCreate_Tag = null;
            if (cmdletContext.FormToCreate_Tag != null)
            {
                requestFormToCreate_formToCreate_Tag = cmdletContext.FormToCreate_Tag;
            }
            if (requestFormToCreate_formToCreate_Tag != null)
            {
                request.FormToCreate.Tags = requestFormToCreate_formToCreate_Tag;
                requestFormToCreateIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormDataTypeConfig requestFormToCreate_formToCreate_DataType = null;
            
             // populate DataType
            var requestFormToCreate_formToCreate_DataTypeIsNull = true;
            requestFormToCreate_formToCreate_DataType = new Amazon.AmplifyUIBuilder.Model.FormDataTypeConfig();
            Amazon.AmplifyUIBuilder.FormDataSourceType requestFormToCreate_formToCreate_DataType_dataType_DataSourceType = null;
            if (cmdletContext.DataType_DataSourceType != null)
            {
                requestFormToCreate_formToCreate_DataType_dataType_DataSourceType = cmdletContext.DataType_DataSourceType;
            }
            if (requestFormToCreate_formToCreate_DataType_dataType_DataSourceType != null)
            {
                requestFormToCreate_formToCreate_DataType.DataSourceType = requestFormToCreate_formToCreate_DataType_dataType_DataSourceType;
                requestFormToCreate_formToCreate_DataTypeIsNull = false;
            }
            System.String requestFormToCreate_formToCreate_DataType_dataType_DataTypeName = null;
            if (cmdletContext.DataType_DataTypeName != null)
            {
                requestFormToCreate_formToCreate_DataType_dataType_DataTypeName = cmdletContext.DataType_DataTypeName;
            }
            if (requestFormToCreate_formToCreate_DataType_dataType_DataTypeName != null)
            {
                requestFormToCreate_formToCreate_DataType.DataTypeName = requestFormToCreate_formToCreate_DataType_dataType_DataTypeName;
                requestFormToCreate_formToCreate_DataTypeIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_DataType should be set to null
            if (requestFormToCreate_formToCreate_DataTypeIsNull)
            {
                requestFormToCreate_formToCreate_DataType = null;
            }
            if (requestFormToCreate_formToCreate_DataType != null)
            {
                request.FormToCreate.DataType = requestFormToCreate_formToCreate_DataType;
                requestFormToCreateIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormStyle requestFormToCreate_formToCreate_Style = null;
            
             // populate Style
            requestFormToCreate_formToCreate_Style = new Amazon.AmplifyUIBuilder.Model.FormStyle();
            Amazon.AmplifyUIBuilder.Model.FormStyleConfig requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap = null;
            
             // populate HorizontalGap
            var requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGapIsNull = true;
            requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap = new Amazon.AmplifyUIBuilder.Model.FormStyleConfig();
            System.String requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap_horizontalGap_TokenReference = null;
            if (cmdletContext.HorizontalGap_TokenReference != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap_horizontalGap_TokenReference = cmdletContext.HorizontalGap_TokenReference;
            }
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap_horizontalGap_TokenReference != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap.TokenReference = requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap_horizontalGap_TokenReference;
                requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGapIsNull = false;
            }
            System.String requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap_horizontalGap_Value = null;
            if (cmdletContext.HorizontalGap_Value != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap_horizontalGap_Value = cmdletContext.HorizontalGap_Value;
            }
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap_horizontalGap_Value != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap.Value = requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap_horizontalGap_Value;
                requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGapIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap should be set to null
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGapIsNull)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap = null;
            }
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap != null)
            {
                requestFormToCreate_formToCreate_Style.HorizontalGap = requestFormToCreate_formToCreate_Style_formToCreate_Style_HorizontalGap;
            }
            Amazon.AmplifyUIBuilder.Model.FormStyleConfig requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding = null;
            
             // populate OuterPadding
            var requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPaddingIsNull = true;
            requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding = new Amazon.AmplifyUIBuilder.Model.FormStyleConfig();
            System.String requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding_outerPadding_TokenReference = null;
            if (cmdletContext.OuterPadding_TokenReference != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding_outerPadding_TokenReference = cmdletContext.OuterPadding_TokenReference;
            }
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding_outerPadding_TokenReference != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding.TokenReference = requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding_outerPadding_TokenReference;
                requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPaddingIsNull = false;
            }
            System.String requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding_outerPadding_Value = null;
            if (cmdletContext.OuterPadding_Value != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding_outerPadding_Value = cmdletContext.OuterPadding_Value;
            }
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding_outerPadding_Value != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding.Value = requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding_outerPadding_Value;
                requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPaddingIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding should be set to null
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPaddingIsNull)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding = null;
            }
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding != null)
            {
                requestFormToCreate_formToCreate_Style.OuterPadding = requestFormToCreate_formToCreate_Style_formToCreate_Style_OuterPadding;
            }
            Amazon.AmplifyUIBuilder.Model.FormStyleConfig requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap = null;
            
             // populate VerticalGap
            var requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGapIsNull = true;
            requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap = new Amazon.AmplifyUIBuilder.Model.FormStyleConfig();
            System.String requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap_verticalGap_TokenReference = null;
            if (cmdletContext.VerticalGap_TokenReference != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap_verticalGap_TokenReference = cmdletContext.VerticalGap_TokenReference;
            }
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap_verticalGap_TokenReference != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap.TokenReference = requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap_verticalGap_TokenReference;
                requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGapIsNull = false;
            }
            System.String requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap_verticalGap_Value = null;
            if (cmdletContext.VerticalGap_Value != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap_verticalGap_Value = cmdletContext.VerticalGap_Value;
            }
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap_verticalGap_Value != null)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap.Value = requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap_verticalGap_Value;
                requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGapIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap should be set to null
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGapIsNull)
            {
                requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap = null;
            }
            if (requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap != null)
            {
                requestFormToCreate_formToCreate_Style.VerticalGap = requestFormToCreate_formToCreate_Style_formToCreate_Style_VerticalGap;
            }
            if (requestFormToCreate_formToCreate_Style != null)
            {
                request.FormToCreate.Style = requestFormToCreate_formToCreate_Style;
                requestFormToCreateIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormCTA requestFormToCreate_formToCreate_Cta = null;
            
             // populate Cta
            var requestFormToCreate_formToCreate_CtaIsNull = true;
            requestFormToCreate_formToCreate_Cta = new Amazon.AmplifyUIBuilder.Model.FormCTA();
            Amazon.AmplifyUIBuilder.FormButtonsPosition requestFormToCreate_formToCreate_Cta_cta_Position = null;
            if (cmdletContext.Cta_Position != null)
            {
                requestFormToCreate_formToCreate_Cta_cta_Position = cmdletContext.Cta_Position;
            }
            if (requestFormToCreate_formToCreate_Cta_cta_Position != null)
            {
                requestFormToCreate_formToCreate_Cta.Position = requestFormToCreate_formToCreate_Cta_cta_Position;
                requestFormToCreate_formToCreate_CtaIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormButton requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel = null;
            
             // populate Cancel
            var requestFormToCreate_formToCreate_Cta_formToCreate_Cta_CancelIsNull = true;
            requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel = new Amazon.AmplifyUIBuilder.Model.FormButton();
            System.String requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_cancel_Child = null;
            if (cmdletContext.Cancel_Child != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_cancel_Child = cmdletContext.Cancel_Child;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_cancel_Child != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel.Children = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_cancel_Child;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_CancelIsNull = false;
            }
            System.Boolean? requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_cancel_Excluded = null;
            if (cmdletContext.Cancel_Excluded != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_cancel_Excluded = cmdletContext.Cancel_Excluded.Value;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_cancel_Excluded != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel.Excluded = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_cancel_Excluded.Value;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_CancelIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FieldPosition requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position = null;
            
             // populate Position
            var requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_PositionIsNull = true;
            requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position = new Amazon.AmplifyUIBuilder.Model.FieldPosition();
            System.String requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_Below = null;
            if (cmdletContext.FormToCreate_Cta_Cancel_Position_Below != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_Below = cmdletContext.FormToCreate_Cta_Cancel_Position_Below;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_Below != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position.Below = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_Below;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_PositionIsNull = false;
            }
            Amazon.AmplifyUIBuilder.FixedPosition requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_Fixed = null;
            if (cmdletContext.FormToCreate_Cta_Cancel_Position_Fixed != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_Fixed = cmdletContext.FormToCreate_Cta_Cancel_Position_Fixed;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_Fixed != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position.Fixed = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_Fixed;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_PositionIsNull = false;
            }
            System.String requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_RightOf = null;
            if (cmdletContext.FormToCreate_Cta_Cancel_Position_RightOf != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_RightOf = cmdletContext.FormToCreate_Cta_Cancel_Position_RightOf;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_RightOf != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position.RightOf = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position_formToCreate_Cta_Cancel_Position_RightOf;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_PositionIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position should be set to null
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_PositionIsNull)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position = null;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel.Position = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel_formToCreate_Cta_Cancel_Position;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_CancelIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel should be set to null
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_CancelIsNull)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel = null;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel != null)
            {
                requestFormToCreate_formToCreate_Cta.Cancel = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Cancel;
                requestFormToCreate_formToCreate_CtaIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormButton requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear = null;
            
             // populate Clear
            var requestFormToCreate_formToCreate_Cta_formToCreate_Cta_ClearIsNull = true;
            requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear = new Amazon.AmplifyUIBuilder.Model.FormButton();
            System.String requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_clear_Child = null;
            if (cmdletContext.Clear_Child != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_clear_Child = cmdletContext.Clear_Child;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_clear_Child != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear.Children = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_clear_Child;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_ClearIsNull = false;
            }
            System.Boolean? requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_clear_Excluded = null;
            if (cmdletContext.Clear_Excluded != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_clear_Excluded = cmdletContext.Clear_Excluded.Value;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_clear_Excluded != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear.Excluded = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_clear_Excluded.Value;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_ClearIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FieldPosition requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position = null;
            
             // populate Position
            var requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_PositionIsNull = true;
            requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position = new Amazon.AmplifyUIBuilder.Model.FieldPosition();
            System.String requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_Below = null;
            if (cmdletContext.FormToCreate_Cta_Clear_Position_Below != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_Below = cmdletContext.FormToCreate_Cta_Clear_Position_Below;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_Below != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position.Below = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_Below;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_PositionIsNull = false;
            }
            Amazon.AmplifyUIBuilder.FixedPosition requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_Fixed = null;
            if (cmdletContext.FormToCreate_Cta_Clear_Position_Fixed != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_Fixed = cmdletContext.FormToCreate_Cta_Clear_Position_Fixed;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_Fixed != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position.Fixed = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_Fixed;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_PositionIsNull = false;
            }
            System.String requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_RightOf = null;
            if (cmdletContext.FormToCreate_Cta_Clear_Position_RightOf != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_RightOf = cmdletContext.FormToCreate_Cta_Clear_Position_RightOf;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_RightOf != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position.RightOf = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position_formToCreate_Cta_Clear_Position_RightOf;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_PositionIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position should be set to null
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_PositionIsNull)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position = null;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear.Position = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear_formToCreate_Cta_Clear_Position;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_ClearIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear should be set to null
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_ClearIsNull)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear = null;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear != null)
            {
                requestFormToCreate_formToCreate_Cta.Clear = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Clear;
                requestFormToCreate_formToCreate_CtaIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormButton requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit = null;
            
             // populate Submit
            var requestFormToCreate_formToCreate_Cta_formToCreate_Cta_SubmitIsNull = true;
            requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit = new Amazon.AmplifyUIBuilder.Model.FormButton();
            System.String requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_submit_Child = null;
            if (cmdletContext.Submit_Child != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_submit_Child = cmdletContext.Submit_Child;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_submit_Child != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit.Children = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_submit_Child;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_SubmitIsNull = false;
            }
            System.Boolean? requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_submit_Excluded = null;
            if (cmdletContext.Submit_Excluded != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_submit_Excluded = cmdletContext.Submit_Excluded.Value;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_submit_Excluded != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit.Excluded = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_submit_Excluded.Value;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_SubmitIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FieldPosition requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position = null;
            
             // populate Position
            var requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_PositionIsNull = true;
            requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position = new Amazon.AmplifyUIBuilder.Model.FieldPosition();
            System.String requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_Below = null;
            if (cmdletContext.FormToCreate_Cta_Submit_Position_Below != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_Below = cmdletContext.FormToCreate_Cta_Submit_Position_Below;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_Below != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position.Below = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_Below;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_PositionIsNull = false;
            }
            Amazon.AmplifyUIBuilder.FixedPosition requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_Fixed = null;
            if (cmdletContext.FormToCreate_Cta_Submit_Position_Fixed != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_Fixed = cmdletContext.FormToCreate_Cta_Submit_Position_Fixed;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_Fixed != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position.Fixed = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_Fixed;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_PositionIsNull = false;
            }
            System.String requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_RightOf = null;
            if (cmdletContext.FormToCreate_Cta_Submit_Position_RightOf != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_RightOf = cmdletContext.FormToCreate_Cta_Submit_Position_RightOf;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_RightOf != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position.RightOf = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position_formToCreate_Cta_Submit_Position_RightOf;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_PositionIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position should be set to null
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_PositionIsNull)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position = null;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position != null)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit.Position = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit_formToCreate_Cta_Submit_Position;
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_SubmitIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit should be set to null
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_SubmitIsNull)
            {
                requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit = null;
            }
            if (requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit != null)
            {
                requestFormToCreate_formToCreate_Cta.Submit = requestFormToCreate_formToCreate_Cta_formToCreate_Cta_Submit;
                requestFormToCreate_formToCreate_CtaIsNull = false;
            }
             // determine if requestFormToCreate_formToCreate_Cta should be set to null
            if (requestFormToCreate_formToCreate_CtaIsNull)
            {
                requestFormToCreate_formToCreate_Cta = null;
            }
            if (requestFormToCreate_formToCreate_Cta != null)
            {
                request.FormToCreate.Cta = requestFormToCreate_formToCreate_Cta;
                requestFormToCreateIsNull = false;
            }
             // determine if request.FormToCreate should be set to null
            if (requestFormToCreateIsNull)
            {
                request.FormToCreate = null;
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
        
        private Amazon.AmplifyUIBuilder.Model.CreateFormResponse CallAWSServiceOperation(IAmazonAmplifyUIBuilder client, Amazon.AmplifyUIBuilder.Model.CreateFormRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify UI Builder", "CreateForm");
            try
            {
                #if DESKTOP
                return client.CreateForm(request);
                #elif CORECLR
                return client.CreateFormAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EnvironmentName { get; set; }
            public System.String Cancel_Child { get; set; }
            public System.Boolean? Cancel_Excluded { get; set; }
            public System.String FormToCreate_Cta_Cancel_Position_Below { get; set; }
            public Amazon.AmplifyUIBuilder.FixedPosition FormToCreate_Cta_Cancel_Position_Fixed { get; set; }
            public System.String FormToCreate_Cta_Cancel_Position_RightOf { get; set; }
            public System.String Clear_Child { get; set; }
            public System.Boolean? Clear_Excluded { get; set; }
            public System.String FormToCreate_Cta_Clear_Position_Below { get; set; }
            public Amazon.AmplifyUIBuilder.FixedPosition FormToCreate_Cta_Clear_Position_Fixed { get; set; }
            public System.String FormToCreate_Cta_Clear_Position_RightOf { get; set; }
            public Amazon.AmplifyUIBuilder.FormButtonsPosition Cta_Position { get; set; }
            public System.String Submit_Child { get; set; }
            public System.Boolean? Submit_Excluded { get; set; }
            public System.String FormToCreate_Cta_Submit_Position_Below { get; set; }
            public Amazon.AmplifyUIBuilder.FixedPosition FormToCreate_Cta_Submit_Position_Fixed { get; set; }
            public System.String FormToCreate_Cta_Submit_Position_RightOf { get; set; }
            public Amazon.AmplifyUIBuilder.FormDataSourceType DataType_DataSourceType { get; set; }
            public System.String DataType_DataTypeName { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.FieldConfig> FormToCreate_Field { get; set; }
            public Amazon.AmplifyUIBuilder.FormActionType FormToCreate_FormActionType { get; set; }
            public Amazon.AmplifyUIBuilder.LabelDecorator FormToCreate_LabelDecorator { get; set; }
            public System.String FormToCreate_Name { get; set; }
            public System.String FormToCreate_SchemaVersion { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.SectionalElement> FormToCreate_SectionalElement { get; set; }
            public System.String HorizontalGap_TokenReference { get; set; }
            public System.String HorizontalGap_Value { get; set; }
            public System.String OuterPadding_TokenReference { get; set; }
            public System.String OuterPadding_Value { get; set; }
            public System.String VerticalGap_TokenReference { get; set; }
            public System.String VerticalGap_Value { get; set; }
            public Dictionary<System.String, System.String> FormToCreate_Tag { get; set; }
            public System.Func<Amazon.AmplifyUIBuilder.Model.CreateFormResponse, NewAMPUIFormCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entity;
        }
        
    }
}
