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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates all properties for an attribute using all properties from CreateDataTableAttribute.
    /// There are no other granular update endpoints. It does not act as a patch operation
    /// - all properties must be provided. System managed attributes are not mutable by customers.
    /// Changing an attribute's validation does not invalidate existing values since validation
    /// only runs when values are created or updated.
    /// </summary>
    [Cmdlet("Update", "CONNDataTableAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.UpdateDataTableAttributeResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateDataTableAttribute API operation.", Operation = new[] {"UpdateDataTableAttribute"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateDataTableAttributeResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.UpdateDataTableAttributeResponse",
        "This cmdlet returns an Amazon.Connect.Model.UpdateDataTableAttributeResponse object containing multiple properties."
    )]
    public partial class UpdateCONNDataTableAttributeCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>The current name of the attribute to update. Used as an identifier since attribute
        /// names can be changed.</para>
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
        public System.String AttributeName { get; set; }
        #endregion
        
        #region Parameter DataTableId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the data table. Must also accept the table ARN with or without
        /// a version alias.</para>
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
        public System.String DataTableId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description for the attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Validation_ExclusiveMaximum
        /// <summary>
        /// <para>
        /// <para>The largest exclusive numeric value for NUMBER value type. Can be provided alongside
        /// Maximum where both operate independently. Must be greater than ExclusiveMinimum and
        /// Minimum. Applies to NUMBER and values within NUMBER_LIST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Validation_ExclusiveMaximum { get; set; }
        #endregion
        
        #region Parameter Validation_ExclusiveMinimum
        /// <summary>
        /// <para>
        /// <para>The smallest exclusive numeric value for NUMBER value type. Can be provided alongside
        /// Minimum where both operate independently. Must be less than ExclusiveMaximum and Maximum.
        /// Applies to NUMBER and values within NUMBER_LIST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Validation_ExclusiveMinimum { get; set; }
        #endregion
        
        #region Parameter Validation_IgnoreCase
        /// <summary>
        /// <para>
        /// <para>Boolean that defaults to false. Applies to text lists and text primary attributes.
        /// When true, enforces case-insensitive uniqueness for primary attributes and allows
        /// case-insensitive lookups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Validation_IgnoreCase { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the Amazon Connect instance.</para>
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
        
        #region Parameter Validation_Maximum
        /// <summary>
        /// <para>
        /// <para>The largest inclusive numeric value for NUMBER value type. Can be provided alongside
        /// ExclusiveMaximum where both operate independently. Must be greater than or equal to
        /// Minimum and greater than ExclusiveMinimum. Applies to NUMBER and values within NUMBER_LIST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Validation_Maximum { get; set; }
        #endregion
        
        #region Parameter Validation_MaxLength
        /// <summary>
        /// <para>
        /// <para>The maximum number of characters a text value can contain. Applies to TEXT value type
        /// and values within a TEXT_LIST. Must be greater than or equal to MinLength.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Validation_MaxLength { get; set; }
        #endregion
        
        #region Parameter Validation_MaxValue
        /// <summary>
        /// <para>
        /// <para>The maximum number of values in a list. Must be an integer greater than or equal to
        /// 0 and greater than or equal to MinValues. Applies to all list types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Validation_MaxValues")]
        public System.Int32? Validation_MaxValue { get; set; }
        #endregion
        
        #region Parameter Validation_Minimum
        /// <summary>
        /// <para>
        /// <para>The smallest inclusive numeric value for NUMBER value type. Cannot be provided when
        /// ExclusiveMinimum is also provided. Must be less than or equal to Maximum and less
        /// than ExclusiveMaximum. Applies to NUMBER and values within NUMBER_LIST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Validation_Minimum { get; set; }
        #endregion
        
        #region Parameter Validation_MinLength
        /// <summary>
        /// <para>
        /// <para>The minimum number of characters a text value can contain. Applies to TEXT value type
        /// and values within a TEXT_LIST. Must be less than or equal to MaxLength.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Validation_MinLength { get; set; }
        #endregion
        
        #region Parameter Validation_MinValue
        /// <summary>
        /// <para>
        /// <para>The minimum number of values in a list. Must be an integer greater than or equal to
        /// 0 and less than or equal to MaxValues. Applies to all list types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Validation_MinValues")]
        public System.Int32? Validation_MinValue { get; set; }
        #endregion
        
        #region Parameter Validation_MultipleOf
        /// <summary>
        /// <para>
        /// <para>Specifies that numeric values must be multiples of this number. Must be greater than
        /// 0. The result of dividing a value by this multiple must result in an integer. Applies
        /// to NUMBER and values within NUMBER_LIST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Validation_MultipleOf { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new name for the attribute. Must conform to Connect human readable string specification
        /// and be unique within the data table.</para>
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
        
        #region Parameter Primary
        /// <summary>
        /// <para>
        /// <para>Whether the attribute should be treated as a primary key. Converting to primary attribute
        /// requires existing values to maintain uniqueness.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Primary { get; set; }
        #endregion
        
        #region Parameter Enum_Strict
        /// <summary>
        /// <para>
        /// <para>Boolean that defaults to false. When true, only values specified in the enum list
        /// are allowed. When false, custom values beyond the enumerated list are permitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Validation_Enum_Strict")]
        public System.Boolean? Enum_Strict { get; set; }
        #endregion
        
        #region Parameter Enum_Value
        /// <summary>
        /// <para>
        /// <para>A list of predefined values that are allowed for this attribute. These values are
        /// always permitted regardless of the Strict setting.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Validation_Enum_Values")]
        public System.String[] Enum_Value { get; set; }
        #endregion
        
        #region Parameter ValueType
        /// <summary>
        /// <para>
        /// <para>The updated value type for the attribute. When changing value types, existing values
        /// are not deleted but may return default values if incompatible.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.DataTableAttributeValueType")]
        public Amazon.Connect.DataTableAttributeValueType ValueType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateDataTableAttributeResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.UpdateDataTableAttributeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNDataTableAttribute (UpdateDataTableAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateDataTableAttributeResponse, UpdateCONNDataTableAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttributeName = this.AttributeName;
            #if MODULAR
            if (this.AttributeName == null && ParameterWasBound(nameof(this.AttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataTableId = this.DataTableId;
            #if MODULAR
            if (this.DataTableId == null && ParameterWasBound(nameof(this.DataTableId)))
            {
                WriteWarning("You are passing $null as a value for parameter DataTableId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.Primary = this.Primary;
            context.Enum_Strict = this.Enum_Strict;
            if (this.Enum_Value != null)
            {
                context.Enum_Value = new List<System.String>(this.Enum_Value);
            }
            context.Validation_ExclusiveMaximum = this.Validation_ExclusiveMaximum;
            context.Validation_ExclusiveMinimum = this.Validation_ExclusiveMinimum;
            context.Validation_IgnoreCase = this.Validation_IgnoreCase;
            context.Validation_Maximum = this.Validation_Maximum;
            context.Validation_MaxLength = this.Validation_MaxLength;
            context.Validation_MaxValue = this.Validation_MaxValue;
            context.Validation_Minimum = this.Validation_Minimum;
            context.Validation_MinLength = this.Validation_MinLength;
            context.Validation_MinValue = this.Validation_MinValue;
            context.Validation_MultipleOf = this.Validation_MultipleOf;
            context.ValueType = this.ValueType;
            #if MODULAR
            if (this.ValueType == null && ParameterWasBound(nameof(this.ValueType)))
            {
                WriteWarning("You are passing $null as a value for parameter ValueType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateDataTableAttributeRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeName = cmdletContext.AttributeName;
            }
            if (cmdletContext.DataTableId != null)
            {
                request.DataTableId = cmdletContext.DataTableId;
            }
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
            if (cmdletContext.Primary != null)
            {
                request.Primary = cmdletContext.Primary.Value;
            }
            
             // populate Validation
            var requestValidationIsNull = true;
            request.Validation = new Amazon.Connect.Model.Validation();
            System.Double? requestValidation_validation_ExclusiveMaximum = null;
            if (cmdletContext.Validation_ExclusiveMaximum != null)
            {
                requestValidation_validation_ExclusiveMaximum = cmdletContext.Validation_ExclusiveMaximum.Value;
            }
            if (requestValidation_validation_ExclusiveMaximum != null)
            {
                request.Validation.ExclusiveMaximum = requestValidation_validation_ExclusiveMaximum.Value;
                requestValidationIsNull = false;
            }
            System.Double? requestValidation_validation_ExclusiveMinimum = null;
            if (cmdletContext.Validation_ExclusiveMinimum != null)
            {
                requestValidation_validation_ExclusiveMinimum = cmdletContext.Validation_ExclusiveMinimum.Value;
            }
            if (requestValidation_validation_ExclusiveMinimum != null)
            {
                request.Validation.ExclusiveMinimum = requestValidation_validation_ExclusiveMinimum.Value;
                requestValidationIsNull = false;
            }
            System.Boolean? requestValidation_validation_IgnoreCase = null;
            if (cmdletContext.Validation_IgnoreCase != null)
            {
                requestValidation_validation_IgnoreCase = cmdletContext.Validation_IgnoreCase.Value;
            }
            if (requestValidation_validation_IgnoreCase != null)
            {
                request.Validation.IgnoreCase = requestValidation_validation_IgnoreCase.Value;
                requestValidationIsNull = false;
            }
            System.Double? requestValidation_validation_Maximum = null;
            if (cmdletContext.Validation_Maximum != null)
            {
                requestValidation_validation_Maximum = cmdletContext.Validation_Maximum.Value;
            }
            if (requestValidation_validation_Maximum != null)
            {
                request.Validation.Maximum = requestValidation_validation_Maximum.Value;
                requestValidationIsNull = false;
            }
            System.Int32? requestValidation_validation_MaxLength = null;
            if (cmdletContext.Validation_MaxLength != null)
            {
                requestValidation_validation_MaxLength = cmdletContext.Validation_MaxLength.Value;
            }
            if (requestValidation_validation_MaxLength != null)
            {
                request.Validation.MaxLength = requestValidation_validation_MaxLength.Value;
                requestValidationIsNull = false;
            }
            System.Int32? requestValidation_validation_MaxValue = null;
            if (cmdletContext.Validation_MaxValue != null)
            {
                requestValidation_validation_MaxValue = cmdletContext.Validation_MaxValue.Value;
            }
            if (requestValidation_validation_MaxValue != null)
            {
                request.Validation.MaxValues = requestValidation_validation_MaxValue.Value;
                requestValidationIsNull = false;
            }
            System.Double? requestValidation_validation_Minimum = null;
            if (cmdletContext.Validation_Minimum != null)
            {
                requestValidation_validation_Minimum = cmdletContext.Validation_Minimum.Value;
            }
            if (requestValidation_validation_Minimum != null)
            {
                request.Validation.Minimum = requestValidation_validation_Minimum.Value;
                requestValidationIsNull = false;
            }
            System.Int32? requestValidation_validation_MinLength = null;
            if (cmdletContext.Validation_MinLength != null)
            {
                requestValidation_validation_MinLength = cmdletContext.Validation_MinLength.Value;
            }
            if (requestValidation_validation_MinLength != null)
            {
                request.Validation.MinLength = requestValidation_validation_MinLength.Value;
                requestValidationIsNull = false;
            }
            System.Int32? requestValidation_validation_MinValue = null;
            if (cmdletContext.Validation_MinValue != null)
            {
                requestValidation_validation_MinValue = cmdletContext.Validation_MinValue.Value;
            }
            if (requestValidation_validation_MinValue != null)
            {
                request.Validation.MinValues = requestValidation_validation_MinValue.Value;
                requestValidationIsNull = false;
            }
            System.Double? requestValidation_validation_MultipleOf = null;
            if (cmdletContext.Validation_MultipleOf != null)
            {
                requestValidation_validation_MultipleOf = cmdletContext.Validation_MultipleOf.Value;
            }
            if (requestValidation_validation_MultipleOf != null)
            {
                request.Validation.MultipleOf = requestValidation_validation_MultipleOf.Value;
                requestValidationIsNull = false;
            }
            Amazon.Connect.Model.ValidationEnum requestValidation_validation_Enum = null;
            
             // populate Enum
            var requestValidation_validation_EnumIsNull = true;
            requestValidation_validation_Enum = new Amazon.Connect.Model.ValidationEnum();
            System.Boolean? requestValidation_validation_Enum_enum_Strict = null;
            if (cmdletContext.Enum_Strict != null)
            {
                requestValidation_validation_Enum_enum_Strict = cmdletContext.Enum_Strict.Value;
            }
            if (requestValidation_validation_Enum_enum_Strict != null)
            {
                requestValidation_validation_Enum.Strict = requestValidation_validation_Enum_enum_Strict.Value;
                requestValidation_validation_EnumIsNull = false;
            }
            List<System.String> requestValidation_validation_Enum_enum_Value = null;
            if (cmdletContext.Enum_Value != null)
            {
                requestValidation_validation_Enum_enum_Value = cmdletContext.Enum_Value;
            }
            if (requestValidation_validation_Enum_enum_Value != null)
            {
                requestValidation_validation_Enum.Values = requestValidation_validation_Enum_enum_Value;
                requestValidation_validation_EnumIsNull = false;
            }
             // determine if requestValidation_validation_Enum should be set to null
            if (requestValidation_validation_EnumIsNull)
            {
                requestValidation_validation_Enum = null;
            }
            if (requestValidation_validation_Enum != null)
            {
                request.Validation.Enum = requestValidation_validation_Enum;
                requestValidationIsNull = false;
            }
             // determine if request.Validation should be set to null
            if (requestValidationIsNull)
            {
                request.Validation = null;
            }
            if (cmdletContext.ValueType != null)
            {
                request.ValueType = cmdletContext.ValueType;
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
        
        private Amazon.Connect.Model.UpdateDataTableAttributeResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateDataTableAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateDataTableAttribute");
            try
            {
                return client.UpdateDataTableAttributeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AttributeName { get; set; }
            public System.String DataTableId { get; set; }
            public System.String Description { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? Primary { get; set; }
            public System.Boolean? Enum_Strict { get; set; }
            public List<System.String> Enum_Value { get; set; }
            public System.Double? Validation_ExclusiveMaximum { get; set; }
            public System.Double? Validation_ExclusiveMinimum { get; set; }
            public System.Boolean? Validation_IgnoreCase { get; set; }
            public System.Double? Validation_Maximum { get; set; }
            public System.Int32? Validation_MaxLength { get; set; }
            public System.Int32? Validation_MaxValue { get; set; }
            public System.Double? Validation_Minimum { get; set; }
            public System.Int32? Validation_MinLength { get; set; }
            public System.Int32? Validation_MinValue { get; set; }
            public System.Double? Validation_MultipleOf { get; set; }
            public Amazon.Connect.DataTableAttributeValueType ValueType { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateDataTableAttributeResponse, UpdateCONNDataTableAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
