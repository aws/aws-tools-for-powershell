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
using Amazon.AmplifyUIBuilder;
using Amazon.AmplifyUIBuilder.Model;

namespace Amazon.PowerShell.Cmdlets.AMPUI
{
    /// <summary>
    /// Updates an existing form.
    /// </summary>
    [Cmdlet("Update", "AMPUIForm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyUIBuilder.Model.Form")]
    [AWSCmdlet("Calls the AWS Amplify UI Builder UpdateForm API operation.", Operation = new[] {"UpdateForm"}, SelectReturnType = typeof(Amazon.AmplifyUIBuilder.Model.UpdateFormResponse))]
    [AWSCmdletOutput("Amazon.AmplifyUIBuilder.Model.Form or Amazon.AmplifyUIBuilder.Model.UpdateFormResponse",
        "This cmdlet returns an Amazon.AmplifyUIBuilder.Model.Form object.",
        "The service call response (type Amazon.AmplifyUIBuilder.Model.UpdateFormResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAMPUIFormCmdlet : AmazonAmplifyUIBuilderClientCmdlet, IExecutor
    {
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The unique ID for the Amplify app.</para>
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
        
        #region Parameter UpdatedForm_Cta_Cancel_Position_Below
        /// <summary>
        /// <para>
        /// <para>The field position is below the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_Form_Cancel_Position_Below")]
        public System.String UpdatedForm_Cta_Cancel_Position_Below { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_Cta_Clear_Position_Below
        /// <summary>
        /// <para>
        /// <para>The field position is below the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_Form_Clear_Position_Below")]
        public System.String UpdatedForm_Cta_Clear_Position_Below { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_Cta_Submit_Position_Below
        /// <summary>
        /// <para>
        /// <para>The field position is below the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_Form_Submit_Position_Below")]
        public System.String UpdatedForm_Cta_Submit_Position_Below { get; set; }
        #endregion
        
        #region Parameter Cancel_Child
        /// <summary>
        /// <para>
        /// <para>Describes the button's properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Cta_Cancel_Children")]
        public System.String Cancel_Child { get; set; }
        #endregion
        
        #region Parameter Clear_Child
        /// <summary>
        /// <para>
        /// <para>Describes the button's properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Cta_Clear_Children")]
        public System.String Clear_Child { get; set; }
        #endregion
        
        #region Parameter Submit_Child
        /// <summary>
        /// <para>
        /// <para>Describes the button's properties.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Cta_Submit_Children")]
        public System.String Submit_Child { get; set; }
        #endregion
        
        #region Parameter DataType_DataSourceType
        /// <summary>
        /// <para>
        /// <para>The data source type, either an Amplify DataStore model or a custom data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_DataType_DataSourceType")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FormDataSourceType")]
        public Amazon.AmplifyUIBuilder.FormDataSourceType DataType_DataSourceType { get; set; }
        #endregion
        
        #region Parameter DataType_DataTypeName
        /// <summary>
        /// <para>
        /// <para>The unique name of the data type you are using as the data source for the form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_DataType_DataTypeName")]
        public System.String DataType_DataTypeName { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the backend environment that is part of the Amplify app.</para>
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
        [Alias("UpdatedForm_Cta_Cancel_Excluded")]
        public System.Boolean? Cancel_Excluded { get; set; }
        #endregion
        
        #region Parameter Clear_Excluded
        /// <summary>
        /// <para>
        /// <para>Specifies whether the button is visible on the form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Cta_Clear_Excluded")]
        public System.Boolean? Clear_Excluded { get; set; }
        #endregion
        
        #region Parameter Submit_Excluded
        /// <summary>
        /// <para>
        /// <para>Specifies whether the button is visible on the form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Cta_Submit_Excluded")]
        public System.Boolean? Submit_Excluded { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_Field
        /// <summary>
        /// <para>
        /// <para>The configuration information for the form's fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Fields")]
        public System.Collections.Hashtable UpdatedForm_Field { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_Cta_Cancel_Position_Fixed
        /// <summary>
        /// <para>
        /// <para>The field position is fixed and doesn't change in relation to other fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_Form_Cancel_Position_Fixed")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FixedPosition")]
        public Amazon.AmplifyUIBuilder.FixedPosition UpdatedForm_Cta_Cancel_Position_Fixed { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_Cta_Clear_Position_Fixed
        /// <summary>
        /// <para>
        /// <para>The field position is fixed and doesn't change in relation to other fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_Form_Clear_Position_Fixed")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FixedPosition")]
        public Amazon.AmplifyUIBuilder.FixedPosition UpdatedForm_Cta_Clear_Position_Fixed { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_Cta_Submit_Position_Fixed
        /// <summary>
        /// <para>
        /// <para>The field position is fixed and doesn't change in relation to other fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_Form_Submit_Position_Fixed")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FixedPosition")]
        public Amazon.AmplifyUIBuilder.FixedPosition UpdatedForm_Cta_Submit_Position_Fixed { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_FormActionType
        /// <summary>
        /// <para>
        /// <para>Specifies whether to perform a create or update action on the form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FormActionType")]
        public Amazon.AmplifyUIBuilder.FormActionType UpdatedForm_FormActionType { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique ID for the form.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_Name
        /// <summary>
        /// <para>
        /// <para>The name of the form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedForm_Name { get; set; }
        #endregion
        
        #region Parameter Cta_Position
        /// <summary>
        /// <para>
        /// <para>The position of the button.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Cta_Position")]
        [AWSConstantClassSource("Amazon.AmplifyUIBuilder.FormButtonsPosition")]
        public Amazon.AmplifyUIBuilder.FormButtonsPosition Cta_Position { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_Cta_Cancel_Position_RightOf
        /// <summary>
        /// <para>
        /// <para>The field position is to the right of the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_Form_Cancel_Position_RightOf")]
        public System.String UpdatedForm_Cta_Cancel_Position_RightOf { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_Cta_Clear_Position_RightOf
        /// <summary>
        /// <para>
        /// <para>The field position is to the right of the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_Form_Clear_Position_RightOf")]
        public System.String UpdatedForm_Cta_Clear_Position_RightOf { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_Cta_Submit_Position_RightOf
        /// <summary>
        /// <para>
        /// <para>The field position is to the right of the field specified by the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_Form_Submit_Position_RightOf")]
        public System.String UpdatedForm_Cta_Submit_Position_RightOf { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_SchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedForm_SchemaVersion { get; set; }
        #endregion
        
        #region Parameter UpdatedForm_SectionalElement
        /// <summary>
        /// <para>
        /// <para>The configuration information for the visual helper elements for the form. These elements
        /// are not associated with any data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_SectionalElements")]
        public System.Collections.Hashtable UpdatedForm_SectionalElement { get; set; }
        #endregion
        
        #region Parameter HorizontalGap_TokenReference
        /// <summary>
        /// <para>
        /// <para>A reference to a design token to use to bind the form's style properties to an existing
        /// theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Style_HorizontalGap_TokenReference")]
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
        [Alias("UpdatedForm_Style_OuterPadding_TokenReference")]
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
        [Alias("UpdatedForm_Style_VerticalGap_TokenReference")]
        public System.String VerticalGap_TokenReference { get; set; }
        #endregion
        
        #region Parameter HorizontalGap_Value
        /// <summary>
        /// <para>
        /// <para>The value of the style setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Style_HorizontalGap_Value")]
        public System.String HorizontalGap_Value { get; set; }
        #endregion
        
        #region Parameter OuterPadding_Value
        /// <summary>
        /// <para>
        /// <para>The value of the style setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Style_OuterPadding_Value")]
        public System.String OuterPadding_Value { get; set; }
        #endregion
        
        #region Parameter VerticalGap_Value
        /// <summary>
        /// <para>
        /// <para>The value of the style setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatedForm_Style_VerticalGap_Value")]
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyUIBuilder.Model.UpdateFormResponse).
        /// Specifying the name of a property of type Amazon.AmplifyUIBuilder.Model.UpdateFormResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMPUIForm (UpdateForm)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyUIBuilder.Model.UpdateFormResponse, UpdateAMPUIFormCmdlet>(Select) ??
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
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Cancel_Child = this.Cancel_Child;
            context.Cancel_Excluded = this.Cancel_Excluded;
            context.UpdatedForm_Cta_Cancel_Position_Below = this.UpdatedForm_Cta_Cancel_Position_Below;
            context.UpdatedForm_Cta_Cancel_Position_Fixed = this.UpdatedForm_Cta_Cancel_Position_Fixed;
            context.UpdatedForm_Cta_Cancel_Position_RightOf = this.UpdatedForm_Cta_Cancel_Position_RightOf;
            context.Clear_Child = this.Clear_Child;
            context.Clear_Excluded = this.Clear_Excluded;
            context.UpdatedForm_Cta_Clear_Position_Below = this.UpdatedForm_Cta_Clear_Position_Below;
            context.UpdatedForm_Cta_Clear_Position_Fixed = this.UpdatedForm_Cta_Clear_Position_Fixed;
            context.UpdatedForm_Cta_Clear_Position_RightOf = this.UpdatedForm_Cta_Clear_Position_RightOf;
            context.Cta_Position = this.Cta_Position;
            context.Submit_Child = this.Submit_Child;
            context.Submit_Excluded = this.Submit_Excluded;
            context.UpdatedForm_Cta_Submit_Position_Below = this.UpdatedForm_Cta_Submit_Position_Below;
            context.UpdatedForm_Cta_Submit_Position_Fixed = this.UpdatedForm_Cta_Submit_Position_Fixed;
            context.UpdatedForm_Cta_Submit_Position_RightOf = this.UpdatedForm_Cta_Submit_Position_RightOf;
            context.DataType_DataSourceType = this.DataType_DataSourceType;
            context.DataType_DataTypeName = this.DataType_DataTypeName;
            if (this.UpdatedForm_Field != null)
            {
                context.UpdatedForm_Field = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.FieldConfig>(StringComparer.Ordinal);
                foreach (var hashKey in this.UpdatedForm_Field.Keys)
                {
                    context.UpdatedForm_Field.Add((String)hashKey, (FieldConfig)(this.UpdatedForm_Field[hashKey]));
                }
            }
            context.UpdatedForm_FormActionType = this.UpdatedForm_FormActionType;
            context.UpdatedForm_Name = this.UpdatedForm_Name;
            context.UpdatedForm_SchemaVersion = this.UpdatedForm_SchemaVersion;
            if (this.UpdatedForm_SectionalElement != null)
            {
                context.UpdatedForm_SectionalElement = new Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.SectionalElement>(StringComparer.Ordinal);
                foreach (var hashKey in this.UpdatedForm_SectionalElement.Keys)
                {
                    context.UpdatedForm_SectionalElement.Add((String)hashKey, (SectionalElement)(this.UpdatedForm_SectionalElement[hashKey]));
                }
            }
            context.HorizontalGap_TokenReference = this.HorizontalGap_TokenReference;
            context.HorizontalGap_Value = this.HorizontalGap_Value;
            context.OuterPadding_TokenReference = this.OuterPadding_TokenReference;
            context.OuterPadding_Value = this.OuterPadding_Value;
            context.VerticalGap_TokenReference = this.VerticalGap_TokenReference;
            context.VerticalGap_Value = this.VerticalGap_Value;
            
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
            var request = new Amazon.AmplifyUIBuilder.Model.UpdateFormRequest();
            
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
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate UpdatedForm
            var requestUpdatedFormIsNull = true;
            request.UpdatedForm = new Amazon.AmplifyUIBuilder.Model.UpdateFormData();
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.FieldConfig> requestUpdatedForm_updatedForm_Field = null;
            if (cmdletContext.UpdatedForm_Field != null)
            {
                requestUpdatedForm_updatedForm_Field = cmdletContext.UpdatedForm_Field;
            }
            if (requestUpdatedForm_updatedForm_Field != null)
            {
                request.UpdatedForm.Fields = requestUpdatedForm_updatedForm_Field;
                requestUpdatedFormIsNull = false;
            }
            Amazon.AmplifyUIBuilder.FormActionType requestUpdatedForm_updatedForm_FormActionType = null;
            if (cmdletContext.UpdatedForm_FormActionType != null)
            {
                requestUpdatedForm_updatedForm_FormActionType = cmdletContext.UpdatedForm_FormActionType;
            }
            if (requestUpdatedForm_updatedForm_FormActionType != null)
            {
                request.UpdatedForm.FormActionType = requestUpdatedForm_updatedForm_FormActionType;
                requestUpdatedFormIsNull = false;
            }
            System.String requestUpdatedForm_updatedForm_Name = null;
            if (cmdletContext.UpdatedForm_Name != null)
            {
                requestUpdatedForm_updatedForm_Name = cmdletContext.UpdatedForm_Name;
            }
            if (requestUpdatedForm_updatedForm_Name != null)
            {
                request.UpdatedForm.Name = requestUpdatedForm_updatedForm_Name;
                requestUpdatedFormIsNull = false;
            }
            System.String requestUpdatedForm_updatedForm_SchemaVersion = null;
            if (cmdletContext.UpdatedForm_SchemaVersion != null)
            {
                requestUpdatedForm_updatedForm_SchemaVersion = cmdletContext.UpdatedForm_SchemaVersion;
            }
            if (requestUpdatedForm_updatedForm_SchemaVersion != null)
            {
                request.UpdatedForm.SchemaVersion = requestUpdatedForm_updatedForm_SchemaVersion;
                requestUpdatedFormIsNull = false;
            }
            Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.SectionalElement> requestUpdatedForm_updatedForm_SectionalElement = null;
            if (cmdletContext.UpdatedForm_SectionalElement != null)
            {
                requestUpdatedForm_updatedForm_SectionalElement = cmdletContext.UpdatedForm_SectionalElement;
            }
            if (requestUpdatedForm_updatedForm_SectionalElement != null)
            {
                request.UpdatedForm.SectionalElements = requestUpdatedForm_updatedForm_SectionalElement;
                requestUpdatedFormIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormDataTypeConfig requestUpdatedForm_updatedForm_DataType = null;
            
             // populate DataType
            var requestUpdatedForm_updatedForm_DataTypeIsNull = true;
            requestUpdatedForm_updatedForm_DataType = new Amazon.AmplifyUIBuilder.Model.FormDataTypeConfig();
            Amazon.AmplifyUIBuilder.FormDataSourceType requestUpdatedForm_updatedForm_DataType_dataType_DataSourceType = null;
            if (cmdletContext.DataType_DataSourceType != null)
            {
                requestUpdatedForm_updatedForm_DataType_dataType_DataSourceType = cmdletContext.DataType_DataSourceType;
            }
            if (requestUpdatedForm_updatedForm_DataType_dataType_DataSourceType != null)
            {
                requestUpdatedForm_updatedForm_DataType.DataSourceType = requestUpdatedForm_updatedForm_DataType_dataType_DataSourceType;
                requestUpdatedForm_updatedForm_DataTypeIsNull = false;
            }
            System.String requestUpdatedForm_updatedForm_DataType_dataType_DataTypeName = null;
            if (cmdletContext.DataType_DataTypeName != null)
            {
                requestUpdatedForm_updatedForm_DataType_dataType_DataTypeName = cmdletContext.DataType_DataTypeName;
            }
            if (requestUpdatedForm_updatedForm_DataType_dataType_DataTypeName != null)
            {
                requestUpdatedForm_updatedForm_DataType.DataTypeName = requestUpdatedForm_updatedForm_DataType_dataType_DataTypeName;
                requestUpdatedForm_updatedForm_DataTypeIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_DataType should be set to null
            if (requestUpdatedForm_updatedForm_DataTypeIsNull)
            {
                requestUpdatedForm_updatedForm_DataType = null;
            }
            if (requestUpdatedForm_updatedForm_DataType != null)
            {
                request.UpdatedForm.DataType = requestUpdatedForm_updatedForm_DataType;
                requestUpdatedFormIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormStyle requestUpdatedForm_updatedForm_Style = null;
            
             // populate Style
            var requestUpdatedForm_updatedForm_StyleIsNull = true;
            requestUpdatedForm_updatedForm_Style = new Amazon.AmplifyUIBuilder.Model.FormStyle();
            Amazon.AmplifyUIBuilder.Model.FormStyleConfig requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap = null;
            
             // populate HorizontalGap
            var requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGapIsNull = true;
            requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap = new Amazon.AmplifyUIBuilder.Model.FormStyleConfig();
            System.String requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap_horizontalGap_TokenReference = null;
            if (cmdletContext.HorizontalGap_TokenReference != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap_horizontalGap_TokenReference = cmdletContext.HorizontalGap_TokenReference;
            }
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap_horizontalGap_TokenReference != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap.TokenReference = requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap_horizontalGap_TokenReference;
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGapIsNull = false;
            }
            System.String requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap_horizontalGap_Value = null;
            if (cmdletContext.HorizontalGap_Value != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap_horizontalGap_Value = cmdletContext.HorizontalGap_Value;
            }
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap_horizontalGap_Value != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap.Value = requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap_horizontalGap_Value;
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGapIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap should be set to null
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGapIsNull)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap = null;
            }
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap != null)
            {
                requestUpdatedForm_updatedForm_Style.HorizontalGap = requestUpdatedForm_updatedForm_Style_updatedForm_Style_HorizontalGap;
                requestUpdatedForm_updatedForm_StyleIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormStyleConfig requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding = null;
            
             // populate OuterPadding
            var requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPaddingIsNull = true;
            requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding = new Amazon.AmplifyUIBuilder.Model.FormStyleConfig();
            System.String requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding_outerPadding_TokenReference = null;
            if (cmdletContext.OuterPadding_TokenReference != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding_outerPadding_TokenReference = cmdletContext.OuterPadding_TokenReference;
            }
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding_outerPadding_TokenReference != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding.TokenReference = requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding_outerPadding_TokenReference;
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPaddingIsNull = false;
            }
            System.String requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding_outerPadding_Value = null;
            if (cmdletContext.OuterPadding_Value != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding_outerPadding_Value = cmdletContext.OuterPadding_Value;
            }
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding_outerPadding_Value != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding.Value = requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding_outerPadding_Value;
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPaddingIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding should be set to null
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPaddingIsNull)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding = null;
            }
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding != null)
            {
                requestUpdatedForm_updatedForm_Style.OuterPadding = requestUpdatedForm_updatedForm_Style_updatedForm_Style_OuterPadding;
                requestUpdatedForm_updatedForm_StyleIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormStyleConfig requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap = null;
            
             // populate VerticalGap
            var requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGapIsNull = true;
            requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap = new Amazon.AmplifyUIBuilder.Model.FormStyleConfig();
            System.String requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap_verticalGap_TokenReference = null;
            if (cmdletContext.VerticalGap_TokenReference != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap_verticalGap_TokenReference = cmdletContext.VerticalGap_TokenReference;
            }
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap_verticalGap_TokenReference != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap.TokenReference = requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap_verticalGap_TokenReference;
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGapIsNull = false;
            }
            System.String requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap_verticalGap_Value = null;
            if (cmdletContext.VerticalGap_Value != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap_verticalGap_Value = cmdletContext.VerticalGap_Value;
            }
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap_verticalGap_Value != null)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap.Value = requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap_verticalGap_Value;
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGapIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap should be set to null
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGapIsNull)
            {
                requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap = null;
            }
            if (requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap != null)
            {
                requestUpdatedForm_updatedForm_Style.VerticalGap = requestUpdatedForm_updatedForm_Style_updatedForm_Style_VerticalGap;
                requestUpdatedForm_updatedForm_StyleIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Style should be set to null
            if (requestUpdatedForm_updatedForm_StyleIsNull)
            {
                requestUpdatedForm_updatedForm_Style = null;
            }
            if (requestUpdatedForm_updatedForm_Style != null)
            {
                request.UpdatedForm.Style = requestUpdatedForm_updatedForm_Style;
                requestUpdatedFormIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormCTA requestUpdatedForm_updatedForm_Cta = null;
            
             // populate Cta
            var requestUpdatedForm_updatedForm_CtaIsNull = true;
            requestUpdatedForm_updatedForm_Cta = new Amazon.AmplifyUIBuilder.Model.FormCTA();
            Amazon.AmplifyUIBuilder.FormButtonsPosition requestUpdatedForm_updatedForm_Cta_cta_Position = null;
            if (cmdletContext.Cta_Position != null)
            {
                requestUpdatedForm_updatedForm_Cta_cta_Position = cmdletContext.Cta_Position;
            }
            if (requestUpdatedForm_updatedForm_Cta_cta_Position != null)
            {
                requestUpdatedForm_updatedForm_Cta.Position = requestUpdatedForm_updatedForm_Cta_cta_Position;
                requestUpdatedForm_updatedForm_CtaIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormButton requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel = null;
            
             // populate Cancel
            var requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_CancelIsNull = true;
            requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel = new Amazon.AmplifyUIBuilder.Model.FormButton();
            System.String requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_cancel_Child = null;
            if (cmdletContext.Cancel_Child != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_cancel_Child = cmdletContext.Cancel_Child;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_cancel_Child != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel.Children = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_cancel_Child;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_CancelIsNull = false;
            }
            System.Boolean? requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_cancel_Excluded = null;
            if (cmdletContext.Cancel_Excluded != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_cancel_Excluded = cmdletContext.Cancel_Excluded.Value;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_cancel_Excluded != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel.Excluded = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_cancel_Excluded.Value;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_CancelIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FieldPosition requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position = null;
            
             // populate Position
            var requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_PositionIsNull = true;
            requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position = new Amazon.AmplifyUIBuilder.Model.FieldPosition();
            System.String requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_Below = null;
            if (cmdletContext.UpdatedForm_Cta_Cancel_Position_Below != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_Below = cmdletContext.UpdatedForm_Cta_Cancel_Position_Below;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_Below != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position.Below = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_Below;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_PositionIsNull = false;
            }
            Amazon.AmplifyUIBuilder.FixedPosition requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_Fixed = null;
            if (cmdletContext.UpdatedForm_Cta_Cancel_Position_Fixed != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_Fixed = cmdletContext.UpdatedForm_Cta_Cancel_Position_Fixed;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_Fixed != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position.Fixed = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_Fixed;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_PositionIsNull = false;
            }
            System.String requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_RightOf = null;
            if (cmdletContext.UpdatedForm_Cta_Cancel_Position_RightOf != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_RightOf = cmdletContext.UpdatedForm_Cta_Cancel_Position_RightOf;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_RightOf != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position.RightOf = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position_updatedForm_Cta_Cancel_Position_RightOf;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_PositionIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position should be set to null
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_PositionIsNull)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position = null;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel.Position = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel_updatedForm_Cta_Cancel_Position;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_CancelIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel should be set to null
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_CancelIsNull)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel = null;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel != null)
            {
                requestUpdatedForm_updatedForm_Cta.Cancel = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Cancel;
                requestUpdatedForm_updatedForm_CtaIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormButton requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear = null;
            
             // populate Clear
            var requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_ClearIsNull = true;
            requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear = new Amazon.AmplifyUIBuilder.Model.FormButton();
            System.String requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_clear_Child = null;
            if (cmdletContext.Clear_Child != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_clear_Child = cmdletContext.Clear_Child;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_clear_Child != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear.Children = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_clear_Child;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_ClearIsNull = false;
            }
            System.Boolean? requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_clear_Excluded = null;
            if (cmdletContext.Clear_Excluded != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_clear_Excluded = cmdletContext.Clear_Excluded.Value;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_clear_Excluded != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear.Excluded = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_clear_Excluded.Value;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_ClearIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FieldPosition requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position = null;
            
             // populate Position
            var requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_PositionIsNull = true;
            requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position = new Amazon.AmplifyUIBuilder.Model.FieldPosition();
            System.String requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_Below = null;
            if (cmdletContext.UpdatedForm_Cta_Clear_Position_Below != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_Below = cmdletContext.UpdatedForm_Cta_Clear_Position_Below;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_Below != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position.Below = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_Below;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_PositionIsNull = false;
            }
            Amazon.AmplifyUIBuilder.FixedPosition requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_Fixed = null;
            if (cmdletContext.UpdatedForm_Cta_Clear_Position_Fixed != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_Fixed = cmdletContext.UpdatedForm_Cta_Clear_Position_Fixed;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_Fixed != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position.Fixed = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_Fixed;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_PositionIsNull = false;
            }
            System.String requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_RightOf = null;
            if (cmdletContext.UpdatedForm_Cta_Clear_Position_RightOf != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_RightOf = cmdletContext.UpdatedForm_Cta_Clear_Position_RightOf;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_RightOf != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position.RightOf = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position_updatedForm_Cta_Clear_Position_RightOf;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_PositionIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position should be set to null
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_PositionIsNull)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position = null;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear.Position = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear_updatedForm_Cta_Clear_Position;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_ClearIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear should be set to null
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_ClearIsNull)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear = null;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear != null)
            {
                requestUpdatedForm_updatedForm_Cta.Clear = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Clear;
                requestUpdatedForm_updatedForm_CtaIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FormButton requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit = null;
            
             // populate Submit
            var requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_SubmitIsNull = true;
            requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit = new Amazon.AmplifyUIBuilder.Model.FormButton();
            System.String requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_submit_Child = null;
            if (cmdletContext.Submit_Child != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_submit_Child = cmdletContext.Submit_Child;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_submit_Child != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit.Children = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_submit_Child;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_SubmitIsNull = false;
            }
            System.Boolean? requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_submit_Excluded = null;
            if (cmdletContext.Submit_Excluded != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_submit_Excluded = cmdletContext.Submit_Excluded.Value;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_submit_Excluded != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit.Excluded = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_submit_Excluded.Value;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_SubmitIsNull = false;
            }
            Amazon.AmplifyUIBuilder.Model.FieldPosition requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position = null;
            
             // populate Position
            var requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_PositionIsNull = true;
            requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position = new Amazon.AmplifyUIBuilder.Model.FieldPosition();
            System.String requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_Below = null;
            if (cmdletContext.UpdatedForm_Cta_Submit_Position_Below != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_Below = cmdletContext.UpdatedForm_Cta_Submit_Position_Below;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_Below != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position.Below = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_Below;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_PositionIsNull = false;
            }
            Amazon.AmplifyUIBuilder.FixedPosition requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_Fixed = null;
            if (cmdletContext.UpdatedForm_Cta_Submit_Position_Fixed != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_Fixed = cmdletContext.UpdatedForm_Cta_Submit_Position_Fixed;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_Fixed != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position.Fixed = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_Fixed;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_PositionIsNull = false;
            }
            System.String requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_RightOf = null;
            if (cmdletContext.UpdatedForm_Cta_Submit_Position_RightOf != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_RightOf = cmdletContext.UpdatedForm_Cta_Submit_Position_RightOf;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_RightOf != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position.RightOf = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position_updatedForm_Cta_Submit_Position_RightOf;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_PositionIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position should be set to null
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_PositionIsNull)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position = null;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position != null)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit.Position = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit_updatedForm_Cta_Submit_Position;
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_SubmitIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit should be set to null
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_SubmitIsNull)
            {
                requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit = null;
            }
            if (requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit != null)
            {
                requestUpdatedForm_updatedForm_Cta.Submit = requestUpdatedForm_updatedForm_Cta_updatedForm_Cta_Submit;
                requestUpdatedForm_updatedForm_CtaIsNull = false;
            }
             // determine if requestUpdatedForm_updatedForm_Cta should be set to null
            if (requestUpdatedForm_updatedForm_CtaIsNull)
            {
                requestUpdatedForm_updatedForm_Cta = null;
            }
            if (requestUpdatedForm_updatedForm_Cta != null)
            {
                request.UpdatedForm.Cta = requestUpdatedForm_updatedForm_Cta;
                requestUpdatedFormIsNull = false;
            }
             // determine if request.UpdatedForm should be set to null
            if (requestUpdatedFormIsNull)
            {
                request.UpdatedForm = null;
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
        
        private Amazon.AmplifyUIBuilder.Model.UpdateFormResponse CallAWSServiceOperation(IAmazonAmplifyUIBuilder client, Amazon.AmplifyUIBuilder.Model.UpdateFormRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify UI Builder", "UpdateForm");
            try
            {
                #if DESKTOP
                return client.UpdateForm(request);
                #elif CORECLR
                return client.UpdateFormAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String Cancel_Child { get; set; }
            public System.Boolean? Cancel_Excluded { get; set; }
            public System.String UpdatedForm_Cta_Cancel_Position_Below { get; set; }
            public Amazon.AmplifyUIBuilder.FixedPosition UpdatedForm_Cta_Cancel_Position_Fixed { get; set; }
            public System.String UpdatedForm_Cta_Cancel_Position_RightOf { get; set; }
            public System.String Clear_Child { get; set; }
            public System.Boolean? Clear_Excluded { get; set; }
            public System.String UpdatedForm_Cta_Clear_Position_Below { get; set; }
            public Amazon.AmplifyUIBuilder.FixedPosition UpdatedForm_Cta_Clear_Position_Fixed { get; set; }
            public System.String UpdatedForm_Cta_Clear_Position_RightOf { get; set; }
            public Amazon.AmplifyUIBuilder.FormButtonsPosition Cta_Position { get; set; }
            public System.String Submit_Child { get; set; }
            public System.Boolean? Submit_Excluded { get; set; }
            public System.String UpdatedForm_Cta_Submit_Position_Below { get; set; }
            public Amazon.AmplifyUIBuilder.FixedPosition UpdatedForm_Cta_Submit_Position_Fixed { get; set; }
            public System.String UpdatedForm_Cta_Submit_Position_RightOf { get; set; }
            public Amazon.AmplifyUIBuilder.FormDataSourceType DataType_DataSourceType { get; set; }
            public System.String DataType_DataTypeName { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.FieldConfig> UpdatedForm_Field { get; set; }
            public Amazon.AmplifyUIBuilder.FormActionType UpdatedForm_FormActionType { get; set; }
            public System.String UpdatedForm_Name { get; set; }
            public System.String UpdatedForm_SchemaVersion { get; set; }
            public Dictionary<System.String, Amazon.AmplifyUIBuilder.Model.SectionalElement> UpdatedForm_SectionalElement { get; set; }
            public System.String HorizontalGap_TokenReference { get; set; }
            public System.String HorizontalGap_Value { get; set; }
            public System.String OuterPadding_TokenReference { get; set; }
            public System.String OuterPadding_Value { get; set; }
            public System.String VerticalGap_TokenReference { get; set; }
            public System.String VerticalGap_Value { get; set; }
            public System.Func<Amazon.AmplifyUIBuilder.Model.UpdateFormResponse, UpdateAMPUIFormCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entity;
        }
        
    }
}
