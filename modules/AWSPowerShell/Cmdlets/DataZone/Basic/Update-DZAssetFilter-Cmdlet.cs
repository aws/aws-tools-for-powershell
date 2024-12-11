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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Updates an asset filter.
    /// </summary>
    [Cmdlet("Update", "DZAssetFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.UpdateAssetFilterResponse")]
    [AWSCmdlet("Calls the Amazon DataZone UpdateAssetFilter API operation.", Operation = new[] {"UpdateAssetFilter"}, SelectReturnType = typeof(Amazon.DataZone.Model.UpdateAssetFilterResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.UpdateAssetFilterResponse",
        "This cmdlet returns an Amazon.DataZone.Model.UpdateAssetFilterResponse object containing multiple properties."
    )]
    public partial class UpdateDZAssetFilterCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RowFilter_And
        /// <summary>
        /// <para>
        /// <para>The 'and' clause of the row filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_And")]
        public Amazon.DataZone.Model.RowFilter[] RowFilter_And { get; set; }
        #endregion
        
        #region Parameter AssetIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the data asset.</para>
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
        public System.String AssetIdentifier { get; set; }
        #endregion
        
        #region Parameter EqualTo_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_EqualTo_ColumnName")]
        public System.String EqualTo_ColumnName { get; set; }
        #endregion
        
        #region Parameter GreaterThan_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_GreaterThan_ColumnName")]
        public System.String GreaterThan_ColumnName { get; set; }
        #endregion
        
        #region Parameter GreaterThanOrEqualTo_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo_ColumnName")]
        public System.String GreaterThanOrEqualTo_ColumnName { get; set; }
        #endregion
        
        #region Parameter In_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_In_ColumnName")]
        public System.String In_ColumnName { get; set; }
        #endregion
        
        #region Parameter IsNotNull_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_IsNotNull_ColumnName")]
        public System.String IsNotNull_ColumnName { get; set; }
        #endregion
        
        #region Parameter IsNull_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_IsNull_ColumnName")]
        public System.String IsNull_ColumnName { get; set; }
        #endregion
        
        #region Parameter LessThan_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_LessThan_ColumnName")]
        public System.String LessThan_ColumnName { get; set; }
        #endregion
        
        #region Parameter LessThanOrEqualTo_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo_ColumnName")]
        public System.String LessThanOrEqualTo_ColumnName { get; set; }
        #endregion
        
        #region Parameter Like_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_Like_ColumnName")]
        public System.String Like_ColumnName { get; set; }
        #endregion
        
        #region Parameter NotEqualTo_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_NotEqualTo_ColumnName")]
        public System.String NotEqualTo_ColumnName { get; set; }
        #endregion
        
        #region Parameter NotIn_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_NotIn_ColumnName")]
        public System.String NotIn_ColumnName { get; set; }
        #endregion
        
        #region Parameter NotLike_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_NotLike_ColumnName")]
        public System.String NotLike_ColumnName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the asset filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the domain where you want to update an asset filter.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The ID of the asset filter.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter ColumnConfiguration_IncludedColumnName
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include column names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ColumnConfiguration_IncludedColumnNames")]
        public System.String[] ColumnConfiguration_IncludedColumnName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the asset filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RowFilter_Or
        /// <summary>
        /// <para>
        /// <para>The 'or' clause of the row filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Or")]
        public Amazon.DataZone.Model.RowFilter[] RowFilter_Or { get; set; }
        #endregion
        
        #region Parameter RowConfiguration_Sensitive
        /// <summary>
        /// <para>
        /// <para>Specifies whether the row filter is sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_Sensitive")]
        public System.Boolean? RowConfiguration_Sensitive { get; set; }
        #endregion
        
        #region Parameter EqualTo_Value
        /// <summary>
        /// <para>
        /// <para>The value that might be equal to an expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_EqualTo_Value")]
        public System.String EqualTo_Value { get; set; }
        #endregion
        
        #region Parameter GreaterThan_Value
        /// <summary>
        /// <para>
        /// <para>The value that might be greater than an expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_GreaterThan_Value")]
        public System.String GreaterThan_Value { get; set; }
        #endregion
        
        #region Parameter GreaterThanOrEqualTo_Value
        /// <summary>
        /// <para>
        /// <para>The value that might be greater than or equal to an expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo_Value")]
        public System.String GreaterThanOrEqualTo_Value { get; set; }
        #endregion
        
        #region Parameter LessThan_Value
        /// <summary>
        /// <para>
        /// <para>The value that might be less than the expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_LessThan_Value")]
        public System.String LessThan_Value { get; set; }
        #endregion
        
        #region Parameter LessThanOrEqualTo_Value
        /// <summary>
        /// <para>
        /// <para>The value that might be less than or equal to an expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo_Value")]
        public System.String LessThanOrEqualTo_Value { get; set; }
        #endregion
        
        #region Parameter Like_Value
        /// <summary>
        /// <para>
        /// <para>The value that might be like the expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_Like_Value")]
        public System.String Like_Value { get; set; }
        #endregion
        
        #region Parameter NotEqualTo_Value
        /// <summary>
        /// <para>
        /// <para>The value that might not be equal to the expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_NotEqualTo_Value")]
        public System.String NotEqualTo_Value { get; set; }
        #endregion
        
        #region Parameter NotLike_Value
        /// <summary>
        /// <para>
        /// <para>The value that might not be like the expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_NotLike_Value")]
        public System.String NotLike_Value { get; set; }
        #endregion
        
        #region Parameter In_Value
        /// <summary>
        /// <para>
        /// <para>The values that might be in the expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_In_Values")]
        public System.String[] In_Value { get; set; }
        #endregion
        
        #region Parameter NotIn_Value
        /// <summary>
        /// <para>
        /// <para>The value that might not be in the expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_RowConfiguration_RowFilter_Expression_NotIn_Values")]
        public System.String[] NotIn_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.UpdateAssetFilterResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.UpdateAssetFilterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DZAssetFilter (UpdateAssetFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.UpdateAssetFilterResponse, UpdateDZAssetFilterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetIdentifier = this.AssetIdentifier;
            #if MODULAR
            if (this.AssetIdentifier == null && ParameterWasBound(nameof(this.AssetIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ColumnConfiguration_IncludedColumnName != null)
            {
                context.ColumnConfiguration_IncludedColumnName = new List<System.String>(this.ColumnConfiguration_IncludedColumnName);
            }
            if (this.RowFilter_And != null)
            {
                context.RowFilter_And = new List<Amazon.DataZone.Model.RowFilter>(this.RowFilter_And);
            }
            context.EqualTo_ColumnName = this.EqualTo_ColumnName;
            context.EqualTo_Value = this.EqualTo_Value;
            context.GreaterThan_ColumnName = this.GreaterThan_ColumnName;
            context.GreaterThan_Value = this.GreaterThan_Value;
            context.GreaterThanOrEqualTo_ColumnName = this.GreaterThanOrEqualTo_ColumnName;
            context.GreaterThanOrEqualTo_Value = this.GreaterThanOrEqualTo_Value;
            context.In_ColumnName = this.In_ColumnName;
            if (this.In_Value != null)
            {
                context.In_Value = new List<System.String>(this.In_Value);
            }
            context.IsNotNull_ColumnName = this.IsNotNull_ColumnName;
            context.IsNull_ColumnName = this.IsNull_ColumnName;
            context.LessThan_ColumnName = this.LessThan_ColumnName;
            context.LessThan_Value = this.LessThan_Value;
            context.LessThanOrEqualTo_ColumnName = this.LessThanOrEqualTo_ColumnName;
            context.LessThanOrEqualTo_Value = this.LessThanOrEqualTo_Value;
            context.Like_ColumnName = this.Like_ColumnName;
            context.Like_Value = this.Like_Value;
            context.NotEqualTo_ColumnName = this.NotEqualTo_ColumnName;
            context.NotEqualTo_Value = this.NotEqualTo_Value;
            context.NotIn_ColumnName = this.NotIn_ColumnName;
            if (this.NotIn_Value != null)
            {
                context.NotIn_Value = new List<System.String>(this.NotIn_Value);
            }
            context.NotLike_ColumnName = this.NotLike_ColumnName;
            context.NotLike_Value = this.NotLike_Value;
            if (this.RowFilter_Or != null)
            {
                context.RowFilter_Or = new List<Amazon.DataZone.Model.RowFilter>(this.RowFilter_Or);
            }
            context.RowConfiguration_Sensitive = this.RowConfiguration_Sensitive;
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            
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
            var request = new Amazon.DataZone.Model.UpdateAssetFilterRequest();
            
            if (cmdletContext.AssetIdentifier != null)
            {
                request.AssetIdentifier = cmdletContext.AssetIdentifier;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.DataZone.Model.AssetFilterConfiguration();
            Amazon.DataZone.Model.ColumnFilterConfiguration requestConfiguration_configuration_ColumnConfiguration = null;
            
             // populate ColumnConfiguration
            var requestConfiguration_configuration_ColumnConfigurationIsNull = true;
            requestConfiguration_configuration_ColumnConfiguration = new Amazon.DataZone.Model.ColumnFilterConfiguration();
            List<System.String> requestConfiguration_configuration_ColumnConfiguration_columnConfiguration_IncludedColumnName = null;
            if (cmdletContext.ColumnConfiguration_IncludedColumnName != null)
            {
                requestConfiguration_configuration_ColumnConfiguration_columnConfiguration_IncludedColumnName = cmdletContext.ColumnConfiguration_IncludedColumnName;
            }
            if (requestConfiguration_configuration_ColumnConfiguration_columnConfiguration_IncludedColumnName != null)
            {
                requestConfiguration_configuration_ColumnConfiguration.IncludedColumnNames = requestConfiguration_configuration_ColumnConfiguration_columnConfiguration_IncludedColumnName;
                requestConfiguration_configuration_ColumnConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ColumnConfiguration should be set to null
            if (requestConfiguration_configuration_ColumnConfigurationIsNull)
            {
                requestConfiguration_configuration_ColumnConfiguration = null;
            }
            if (requestConfiguration_configuration_ColumnConfiguration != null)
            {
                request.Configuration.ColumnConfiguration = requestConfiguration_configuration_ColumnConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.DataZone.Model.RowFilterConfiguration requestConfiguration_configuration_RowConfiguration = null;
            
             // populate RowConfiguration
            var requestConfiguration_configuration_RowConfigurationIsNull = true;
            requestConfiguration_configuration_RowConfiguration = new Amazon.DataZone.Model.RowFilterConfiguration();
            System.Boolean? requestConfiguration_configuration_RowConfiguration_rowConfiguration_Sensitive = null;
            if (cmdletContext.RowConfiguration_Sensitive != null)
            {
                requestConfiguration_configuration_RowConfiguration_rowConfiguration_Sensitive = cmdletContext.RowConfiguration_Sensitive.Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_rowConfiguration_Sensitive != null)
            {
                requestConfiguration_configuration_RowConfiguration.Sensitive = requestConfiguration_configuration_RowConfiguration_rowConfiguration_Sensitive.Value;
                requestConfiguration_configuration_RowConfigurationIsNull = false;
            }
            Amazon.DataZone.Model.RowFilter requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter = null;
            
             // populate RowFilter
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilterIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter = new Amazon.DataZone.Model.RowFilter();
            List<Amazon.DataZone.Model.RowFilter> requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_rowFilter_And = null;
            if (cmdletContext.RowFilter_And != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_rowFilter_And = cmdletContext.RowFilter_And;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_rowFilter_And != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter.And = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_rowFilter_And;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilterIsNull = false;
            }
            List<Amazon.DataZone.Model.RowFilter> requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_rowFilter_Or = null;
            if (cmdletContext.RowFilter_Or != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_rowFilter_Or = cmdletContext.RowFilter_Or;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_rowFilter_Or != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter.Or = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_rowFilter_Or;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilterIsNull = false;
            }
            Amazon.DataZone.Model.RowFilterExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression = null;
            
             // populate Expression
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression = new Amazon.DataZone.Model.RowFilterExpression();
            Amazon.DataZone.Model.IsNotNullExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull = null;
            
             // populate IsNotNull
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNullIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull = new Amazon.DataZone.Model.IsNotNullExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull_isNotNull_ColumnName = null;
            if (cmdletContext.IsNotNull_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull_isNotNull_ColumnName = cmdletContext.IsNotNull_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull_isNotNull_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull_isNotNull_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNullIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNullIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.IsNotNull = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNotNull;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.IsNullExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull = null;
            
             // populate IsNull
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNullIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull = new Amazon.DataZone.Model.IsNullExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull_isNull_ColumnName = null;
            if (cmdletContext.IsNull_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull_isNull_ColumnName = cmdletContext.IsNull_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull_isNull_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull_isNull_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNullIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNullIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.IsNull = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_IsNull;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.EqualToExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo = null;
            
             // populate EqualTo
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualToIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo = new Amazon.DataZone.Model.EqualToExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo_equalTo_ColumnName = null;
            if (cmdletContext.EqualTo_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo_equalTo_ColumnName = cmdletContext.EqualTo_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo_equalTo_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo_equalTo_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualToIsNull = false;
            }
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo_equalTo_Value = null;
            if (cmdletContext.EqualTo_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo_equalTo_Value = cmdletContext.EqualTo_Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo_equalTo_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo.Value = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo_equalTo_Value;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualToIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualToIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.EqualTo = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_EqualTo;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.GreaterThanExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan = null;
            
             // populate GreaterThan
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan = new Amazon.DataZone.Model.GreaterThanExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan_greaterThan_ColumnName = null;
            if (cmdletContext.GreaterThan_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan_greaterThan_ColumnName = cmdletContext.GreaterThan_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan_greaterThan_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan_greaterThan_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanIsNull = false;
            }
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan_greaterThan_Value = null;
            if (cmdletContext.GreaterThan_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan_greaterThan_Value = cmdletContext.GreaterThan_Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan_greaterThan_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan.Value = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan_greaterThan_Value;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.GreaterThan = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThan;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.GreaterThanOrEqualToExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo = null;
            
             // populate GreaterThanOrEqualTo
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualToIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo = new Amazon.DataZone.Model.GreaterThanOrEqualToExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo_greaterThanOrEqualTo_ColumnName = null;
            if (cmdletContext.GreaterThanOrEqualTo_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo_greaterThanOrEqualTo_ColumnName = cmdletContext.GreaterThanOrEqualTo_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo_greaterThanOrEqualTo_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo_greaterThanOrEqualTo_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualToIsNull = false;
            }
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo_greaterThanOrEqualTo_Value = null;
            if (cmdletContext.GreaterThanOrEqualTo_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo_greaterThanOrEqualTo_Value = cmdletContext.GreaterThanOrEqualTo_Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo_greaterThanOrEqualTo_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo.Value = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo_greaterThanOrEqualTo_Value;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualToIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualToIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.GreaterThanOrEqualTo = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_GreaterThanOrEqualTo;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.InExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In = null;
            
             // populate In
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_InIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In = new Amazon.DataZone.Model.InExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In_in_ColumnName = null;
            if (cmdletContext.In_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In_in_ColumnName = cmdletContext.In_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In_in_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In_in_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_InIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In_in_Value = null;
            if (cmdletContext.In_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In_in_Value = cmdletContext.In_Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In_in_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In.Values = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In_in_Value;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_InIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_InIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.In = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_In;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.LessThanExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan = null;
            
             // populate LessThan
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan = new Amazon.DataZone.Model.LessThanExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan_lessThan_ColumnName = null;
            if (cmdletContext.LessThan_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan_lessThan_ColumnName = cmdletContext.LessThan_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan_lessThan_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan_lessThan_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanIsNull = false;
            }
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan_lessThan_Value = null;
            if (cmdletContext.LessThan_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan_lessThan_Value = cmdletContext.LessThan_Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan_lessThan_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan.Value = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan_lessThan_Value;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.LessThan = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThan;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.LessThanOrEqualToExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo = null;
            
             // populate LessThanOrEqualTo
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualToIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo = new Amazon.DataZone.Model.LessThanOrEqualToExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo_lessThanOrEqualTo_ColumnName = null;
            if (cmdletContext.LessThanOrEqualTo_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo_lessThanOrEqualTo_ColumnName = cmdletContext.LessThanOrEqualTo_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo_lessThanOrEqualTo_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo_lessThanOrEqualTo_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualToIsNull = false;
            }
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo_lessThanOrEqualTo_Value = null;
            if (cmdletContext.LessThanOrEqualTo_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo_lessThanOrEqualTo_Value = cmdletContext.LessThanOrEqualTo_Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo_lessThanOrEqualTo_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo.Value = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo_lessThanOrEqualTo_Value;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualToIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualToIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.LessThanOrEqualTo = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LessThanOrEqualTo;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.LikeExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like = null;
            
             // populate Like
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LikeIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like = new Amazon.DataZone.Model.LikeExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like_like_ColumnName = null;
            if (cmdletContext.Like_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like_like_ColumnName = cmdletContext.Like_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like_like_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like_like_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LikeIsNull = false;
            }
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like_like_Value = null;
            if (cmdletContext.Like_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like_like_Value = cmdletContext.Like_Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like_like_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like.Value = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like_like_Value;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LikeIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_LikeIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.Like = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_Like;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.NotEqualToExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo = null;
            
             // populate NotEqualTo
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualToIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo = new Amazon.DataZone.Model.NotEqualToExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo_notEqualTo_ColumnName = null;
            if (cmdletContext.NotEqualTo_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo_notEqualTo_ColumnName = cmdletContext.NotEqualTo_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo_notEqualTo_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo_notEqualTo_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualToIsNull = false;
            }
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo_notEqualTo_Value = null;
            if (cmdletContext.NotEqualTo_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo_notEqualTo_Value = cmdletContext.NotEqualTo_Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo_notEqualTo_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo.Value = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo_notEqualTo_Value;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualToIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualToIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.NotEqualTo = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotEqualTo;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.NotInExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn = null;
            
             // populate NotIn
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotInIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn = new Amazon.DataZone.Model.NotInExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn_notIn_ColumnName = null;
            if (cmdletContext.NotIn_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn_notIn_ColumnName = cmdletContext.NotIn_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn_notIn_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn_notIn_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotInIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn_notIn_Value = null;
            if (cmdletContext.NotIn_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn_notIn_Value = cmdletContext.NotIn_Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn_notIn_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn.Values = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn_notIn_Value;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotInIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotInIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.NotIn = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotIn;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
            Amazon.DataZone.Model.NotLikeExpression requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike = null;
            
             // populate NotLike
            var requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLikeIsNull = true;
            requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike = new Amazon.DataZone.Model.NotLikeExpression();
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike_notLike_ColumnName = null;
            if (cmdletContext.NotLike_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike_notLike_ColumnName = cmdletContext.NotLike_ColumnName;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike_notLike_ColumnName != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike.ColumnName = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike_notLike_ColumnName;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLikeIsNull = false;
            }
            System.String requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike_notLike_Value = null;
            if (cmdletContext.NotLike_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike_notLike_Value = cmdletContext.NotLike_Value;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike_notLike_Value != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike.Value = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike_notLike_Value;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLikeIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLikeIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression.NotLike = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression_configuration_RowConfiguration_RowFilter_Expression_NotLike;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_ExpressionIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression != null)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter.Expression = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter_configuration_RowConfiguration_RowFilter_Expression;
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilterIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter should be set to null
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilterIsNull)
            {
                requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter = null;
            }
            if (requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter != null)
            {
                requestConfiguration_configuration_RowConfiguration.RowFilter = requestConfiguration_configuration_RowConfiguration_configuration_RowConfiguration_RowFilter;
                requestConfiguration_configuration_RowConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_RowConfiguration should be set to null
            if (requestConfiguration_configuration_RowConfigurationIsNull)
            {
                requestConfiguration_configuration_RowConfiguration = null;
            }
            if (requestConfiguration_configuration_RowConfiguration != null)
            {
                request.Configuration.RowConfiguration = requestConfiguration_configuration_RowConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.DataZone.Model.UpdateAssetFilterResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.UpdateAssetFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "UpdateAssetFilter");
            try
            {
                #if DESKTOP
                return client.UpdateAssetFilter(request);
                #elif CORECLR
                return client.UpdateAssetFilterAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetIdentifier { get; set; }
            public List<System.String> ColumnConfiguration_IncludedColumnName { get; set; }
            public List<Amazon.DataZone.Model.RowFilter> RowFilter_And { get; set; }
            public System.String EqualTo_ColumnName { get; set; }
            public System.String EqualTo_Value { get; set; }
            public System.String GreaterThan_ColumnName { get; set; }
            public System.String GreaterThan_Value { get; set; }
            public System.String GreaterThanOrEqualTo_ColumnName { get; set; }
            public System.String GreaterThanOrEqualTo_Value { get; set; }
            public System.String In_ColumnName { get; set; }
            public List<System.String> In_Value { get; set; }
            public System.String IsNotNull_ColumnName { get; set; }
            public System.String IsNull_ColumnName { get; set; }
            public System.String LessThan_ColumnName { get; set; }
            public System.String LessThan_Value { get; set; }
            public System.String LessThanOrEqualTo_ColumnName { get; set; }
            public System.String LessThanOrEqualTo_Value { get; set; }
            public System.String Like_ColumnName { get; set; }
            public System.String Like_Value { get; set; }
            public System.String NotEqualTo_ColumnName { get; set; }
            public System.String NotEqualTo_Value { get; set; }
            public System.String NotIn_ColumnName { get; set; }
            public List<System.String> NotIn_Value { get; set; }
            public System.String NotLike_ColumnName { get; set; }
            public System.String NotLike_Value { get; set; }
            public List<Amazon.DataZone.Model.RowFilter> RowFilter_Or { get; set; }
            public System.Boolean? RowConfiguration_Sensitive { get; set; }
            public System.String Description { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String Identifier { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.DataZone.Model.UpdateAssetFilterResponse, UpdateDZAssetFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
