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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Creates a new calculated attribute definition. After creation, new object data ingested
    /// into Customer Profiles will be included in the calculated attribute, which can be
    /// retrieved for a profile using the <a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_GetCalculatedAttributeForProfile.html">GetCalculatedAttributeForProfile</a>
    /// API. Defining a calculated attribute makes it available for all profiles within a
    /// domain. Each calculated attribute can only reference one <c>ObjectType</c> and at
    /// most, two fields from that <c>ObjectType</c>.
    /// </summary>
    [Cmdlet("New", "CPFCalculatedAttributeDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles CreateCalculatedAttributeDefinition API operation.", Operation = new[] {"CreateCalculatedAttributeDefinition"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionResponse object containing multiple properties."
    )]
    public partial class NewCPFCalculatedAttributeDefinitionCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttributeDetails_Attribute
        /// <summary>
        /// <para>
        /// <para>A list of attribute items specified in the mathematical expression.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("AttributeDetails_Attributes")]
        public Amazon.CustomerProfiles.Model.AttributeItem[] AttributeDetails_Attribute { get; set; }
        #endregion
        
        #region Parameter CalculatedAttributeName
        /// <summary>
        /// <para>
        /// <para>The unique name of the calculated attribute.</para>
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
        public System.String CalculatedAttributeName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the calculated attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the calculated attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter ValueRange_End
        /// <summary>
        /// <para>
        /// <para>The end time of when to include objects. Use positive numbers to indicate that the
        /// starting point is in the past, and negative numbers to indicate it is in the future.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Conditions_Range_ValueRange_End")]
        public System.Int32? ValueRange_End { get; set; }
        #endregion
        
        #region Parameter AttributeDetails_Expression
        /// <summary>
        /// <para>
        /// <para>Mathematical expression that is performed on attribute items provided in the attribute
        /// list. Each element in the expression should follow the structure of \"{ObjectTypeName.AttributeName}\".</para>
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
        public System.String AttributeDetails_Expression { get; set; }
        #endregion
        
        #region Parameter Filter_Group
        /// <summary>
        /// <para>
        /// <para>Holds the list of Filter groups within the Filter definition.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Groups")]
        public Amazon.CustomerProfiles.Model.FilterGroup[] Filter_Group { get; set; }
        #endregion
        
        #region Parameter Filter_Include
        /// <summary>
        /// <para>
        /// <para>Define whether to include or exclude objects for Calculated Attributed calculation
        /// that fit the filter groups criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CustomerProfiles.Include")]
        public Amazon.CustomerProfiles.Include Filter_Include { get; set; }
        #endregion
        
        #region Parameter Conditions_ObjectCount
        /// <summary>
        /// <para>
        /// <para>The number of profile objects used for the calculated attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Conditions_ObjectCount { get; set; }
        #endregion
        
        #region Parameter Threshold_Operator
        /// <summary>
        /// <para>
        /// <para>The operator of the threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Conditions_Threshold_Operator")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.Operator")]
        public Amazon.CustomerProfiles.Operator Threshold_Operator { get; set; }
        #endregion
        
        #region Parameter ValueRange_Start
        /// <summary>
        /// <para>
        /// <para>The start time of when to include objects. Use positive numbers to indicate that the
        /// starting point is in the past, and negative numbers to indicate it is in the future.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Conditions_Range_ValueRange_Start")]
        public System.Int32? ValueRange_Start { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para>The aggregation operation to perform for the calculated attribute.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CustomerProfiles.Statistic")]
        public Amazon.CustomerProfiles.Statistic Statistic { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Range_TimestampFormat
        /// <summary>
        /// <para>
        /// <para>The format the timestamp field in your JSON object is specified. This value should
        /// be one of EPOCHMILLI (for Unix epoch timestamps with second/millisecond level precision)
        /// or ISO_8601 (following ISO_8601 format with second/millisecond level precision, with
        /// an optional offset of Z or in the format HH:MM or HHMM.). E.g. if your object type
        /// is MyType and source JSON is {"generatedAt": {"timestamp": "2001-07-04T12:08:56.235-0700"}},
        /// then TimestampFormat should be "ISO_8601".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Conditions_Range_TimestampFormat")]
        public System.String Range_TimestampFormat { get; set; }
        #endregion
        
        #region Parameter Range_TimestampSource
        /// <summary>
        /// <para>
        /// <para>An expression specifying the field in your JSON object from which the date should
        /// be parsed. The expression should follow the structure of \"{ObjectTypeName.&lt;Location
        /// of timestamp field in JSON pointer format&gt;}\". E.g. if your object type is MyType
        /// and source JSON is {"generatedAt": {"timestamp": "1737587945945"}}, then TimestampSource
        /// should be "{MyType.generatedAt.timestamp}".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Conditions_Range_TimestampSource")]
        public System.String Range_TimestampSource { get; set; }
        #endregion
        
        #region Parameter Range_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Conditions_Range_Unit")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.Unit")]
        public Amazon.CustomerProfiles.Unit Range_Unit { get; set; }
        #endregion
        
        #region Parameter UseHistoricalData
        /// <summary>
        /// <para>
        /// <para>Whether historical data ingested before the Calculated Attribute was created should
        /// be included in calculations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseHistoricalData { get; set; }
        #endregion
        
        #region Parameter Range_Value
        /// <summary>
        /// <para>
        /// <para>The amount of time of the specified unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Conditions_Range_Value")]
        public System.Int32? Range_Value { get; set; }
        #endregion
        
        #region Parameter Threshold_Value
        /// <summary>
        /// <para>
        /// <para>The value of the threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Conditions_Threshold_Value")]
        public System.String Threshold_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CPFCalculatedAttributeDefinition (CreateCalculatedAttributeDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionResponse, NewCPFCalculatedAttributeDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AttributeDetails_Attribute != null)
            {
                context.AttributeDetails_Attribute = new List<Amazon.CustomerProfiles.Model.AttributeItem>(this.AttributeDetails_Attribute);
            }
            #if MODULAR
            if (this.AttributeDetails_Attribute == null && ParameterWasBound(nameof(this.AttributeDetails_Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeDetails_Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttributeDetails_Expression = this.AttributeDetails_Expression;
            #if MODULAR
            if (this.AttributeDetails_Expression == null && ParameterWasBound(nameof(this.AttributeDetails_Expression)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeDetails_Expression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CalculatedAttributeName = this.CalculatedAttributeName;
            #if MODULAR
            if (this.CalculatedAttributeName == null && ParameterWasBound(nameof(this.CalculatedAttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter CalculatedAttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Conditions_ObjectCount = this.Conditions_ObjectCount;
            context.Range_TimestampFormat = this.Range_TimestampFormat;
            context.Range_TimestampSource = this.Range_TimestampSource;
            context.Range_Unit = this.Range_Unit;
            context.Range_Value = this.Range_Value;
            context.ValueRange_End = this.ValueRange_End;
            context.ValueRange_Start = this.ValueRange_Start;
            context.Threshold_Operator = this.Threshold_Operator;
            context.Threshold_Value = this.Threshold_Value;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filter_Group != null)
            {
                context.Filter_Group = new List<Amazon.CustomerProfiles.Model.FilterGroup>(this.Filter_Group);
            }
            context.Filter_Include = this.Filter_Include;
            context.Statistic = this.Statistic;
            #if MODULAR
            if (this.Statistic == null && ParameterWasBound(nameof(this.Statistic)))
            {
                WriteWarning("You are passing $null as a value for parameter Statistic which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.UseHistoricalData = this.UseHistoricalData;
            
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
            var request = new Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionRequest();
            
            
             // populate AttributeDetails
            var requestAttributeDetailsIsNull = true;
            request.AttributeDetails = new Amazon.CustomerProfiles.Model.AttributeDetails();
            List<Amazon.CustomerProfiles.Model.AttributeItem> requestAttributeDetails_attributeDetails_Attribute = null;
            if (cmdletContext.AttributeDetails_Attribute != null)
            {
                requestAttributeDetails_attributeDetails_Attribute = cmdletContext.AttributeDetails_Attribute;
            }
            if (requestAttributeDetails_attributeDetails_Attribute != null)
            {
                request.AttributeDetails.Attributes = requestAttributeDetails_attributeDetails_Attribute;
                requestAttributeDetailsIsNull = false;
            }
            System.String requestAttributeDetails_attributeDetails_Expression = null;
            if (cmdletContext.AttributeDetails_Expression != null)
            {
                requestAttributeDetails_attributeDetails_Expression = cmdletContext.AttributeDetails_Expression;
            }
            if (requestAttributeDetails_attributeDetails_Expression != null)
            {
                request.AttributeDetails.Expression = requestAttributeDetails_attributeDetails_Expression;
                requestAttributeDetailsIsNull = false;
            }
             // determine if request.AttributeDetails should be set to null
            if (requestAttributeDetailsIsNull)
            {
                request.AttributeDetails = null;
            }
            if (cmdletContext.CalculatedAttributeName != null)
            {
                request.CalculatedAttributeName = cmdletContext.CalculatedAttributeName;
            }
            
             // populate Conditions
            var requestConditionsIsNull = true;
            request.Conditions = new Amazon.CustomerProfiles.Model.Conditions();
            System.Int32? requestConditions_conditions_ObjectCount = null;
            if (cmdletContext.Conditions_ObjectCount != null)
            {
                requestConditions_conditions_ObjectCount = cmdletContext.Conditions_ObjectCount.Value;
            }
            if (requestConditions_conditions_ObjectCount != null)
            {
                request.Conditions.ObjectCount = requestConditions_conditions_ObjectCount.Value;
                requestConditionsIsNull = false;
            }
            Amazon.CustomerProfiles.Model.Threshold requestConditions_conditions_Threshold = null;
            
             // populate Threshold
            var requestConditions_conditions_ThresholdIsNull = true;
            requestConditions_conditions_Threshold = new Amazon.CustomerProfiles.Model.Threshold();
            Amazon.CustomerProfiles.Operator requestConditions_conditions_Threshold_threshold_Operator = null;
            if (cmdletContext.Threshold_Operator != null)
            {
                requestConditions_conditions_Threshold_threshold_Operator = cmdletContext.Threshold_Operator;
            }
            if (requestConditions_conditions_Threshold_threshold_Operator != null)
            {
                requestConditions_conditions_Threshold.Operator = requestConditions_conditions_Threshold_threshold_Operator;
                requestConditions_conditions_ThresholdIsNull = false;
            }
            System.String requestConditions_conditions_Threshold_threshold_Value = null;
            if (cmdletContext.Threshold_Value != null)
            {
                requestConditions_conditions_Threshold_threshold_Value = cmdletContext.Threshold_Value;
            }
            if (requestConditions_conditions_Threshold_threshold_Value != null)
            {
                requestConditions_conditions_Threshold.Value = requestConditions_conditions_Threshold_threshold_Value;
                requestConditions_conditions_ThresholdIsNull = false;
            }
             // determine if requestConditions_conditions_Threshold should be set to null
            if (requestConditions_conditions_ThresholdIsNull)
            {
                requestConditions_conditions_Threshold = null;
            }
            if (requestConditions_conditions_Threshold != null)
            {
                request.Conditions.Threshold = requestConditions_conditions_Threshold;
                requestConditionsIsNull = false;
            }
            Amazon.CustomerProfiles.Model.Range requestConditions_conditions_Range = null;
            
             // populate Range
            var requestConditions_conditions_RangeIsNull = true;
            requestConditions_conditions_Range = new Amazon.CustomerProfiles.Model.Range();
            System.String requestConditions_conditions_Range_range_TimestampFormat = null;
            if (cmdletContext.Range_TimestampFormat != null)
            {
                requestConditions_conditions_Range_range_TimestampFormat = cmdletContext.Range_TimestampFormat;
            }
            if (requestConditions_conditions_Range_range_TimestampFormat != null)
            {
                requestConditions_conditions_Range.TimestampFormat = requestConditions_conditions_Range_range_TimestampFormat;
                requestConditions_conditions_RangeIsNull = false;
            }
            System.String requestConditions_conditions_Range_range_TimestampSource = null;
            if (cmdletContext.Range_TimestampSource != null)
            {
                requestConditions_conditions_Range_range_TimestampSource = cmdletContext.Range_TimestampSource;
            }
            if (requestConditions_conditions_Range_range_TimestampSource != null)
            {
                requestConditions_conditions_Range.TimestampSource = requestConditions_conditions_Range_range_TimestampSource;
                requestConditions_conditions_RangeIsNull = false;
            }
            Amazon.CustomerProfiles.Unit requestConditions_conditions_Range_range_Unit = null;
            if (cmdletContext.Range_Unit != null)
            {
                requestConditions_conditions_Range_range_Unit = cmdletContext.Range_Unit;
            }
            if (requestConditions_conditions_Range_range_Unit != null)
            {
                requestConditions_conditions_Range.Unit = requestConditions_conditions_Range_range_Unit;
                requestConditions_conditions_RangeIsNull = false;
            }
            System.Int32? requestConditions_conditions_Range_range_Value = null;
            if (cmdletContext.Range_Value != null)
            {
                requestConditions_conditions_Range_range_Value = cmdletContext.Range_Value.Value;
            }
            if (requestConditions_conditions_Range_range_Value != null)
            {
                requestConditions_conditions_Range.Value = requestConditions_conditions_Range_range_Value.Value;
                requestConditions_conditions_RangeIsNull = false;
            }
            Amazon.CustomerProfiles.Model.ValueRange requestConditions_conditions_Range_conditions_Range_ValueRange = null;
            
             // populate ValueRange
            var requestConditions_conditions_Range_conditions_Range_ValueRangeIsNull = true;
            requestConditions_conditions_Range_conditions_Range_ValueRange = new Amazon.CustomerProfiles.Model.ValueRange();
            System.Int32? requestConditions_conditions_Range_conditions_Range_ValueRange_valueRange_End = null;
            if (cmdletContext.ValueRange_End != null)
            {
                requestConditions_conditions_Range_conditions_Range_ValueRange_valueRange_End = cmdletContext.ValueRange_End.Value;
            }
            if (requestConditions_conditions_Range_conditions_Range_ValueRange_valueRange_End != null)
            {
                requestConditions_conditions_Range_conditions_Range_ValueRange.End = requestConditions_conditions_Range_conditions_Range_ValueRange_valueRange_End.Value;
                requestConditions_conditions_Range_conditions_Range_ValueRangeIsNull = false;
            }
            System.Int32? requestConditions_conditions_Range_conditions_Range_ValueRange_valueRange_Start = null;
            if (cmdletContext.ValueRange_Start != null)
            {
                requestConditions_conditions_Range_conditions_Range_ValueRange_valueRange_Start = cmdletContext.ValueRange_Start.Value;
            }
            if (requestConditions_conditions_Range_conditions_Range_ValueRange_valueRange_Start != null)
            {
                requestConditions_conditions_Range_conditions_Range_ValueRange.Start = requestConditions_conditions_Range_conditions_Range_ValueRange_valueRange_Start.Value;
                requestConditions_conditions_Range_conditions_Range_ValueRangeIsNull = false;
            }
             // determine if requestConditions_conditions_Range_conditions_Range_ValueRange should be set to null
            if (requestConditions_conditions_Range_conditions_Range_ValueRangeIsNull)
            {
                requestConditions_conditions_Range_conditions_Range_ValueRange = null;
            }
            if (requestConditions_conditions_Range_conditions_Range_ValueRange != null)
            {
                requestConditions_conditions_Range.ValueRange = requestConditions_conditions_Range_conditions_Range_ValueRange;
                requestConditions_conditions_RangeIsNull = false;
            }
             // determine if requestConditions_conditions_Range should be set to null
            if (requestConditions_conditions_RangeIsNull)
            {
                requestConditions_conditions_Range = null;
            }
            if (requestConditions_conditions_Range != null)
            {
                request.Conditions.Range = requestConditions_conditions_Range;
                requestConditionsIsNull = false;
            }
             // determine if request.Conditions should be set to null
            if (requestConditionsIsNull)
            {
                request.Conditions = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.CustomerProfiles.Model.Filter();
            List<Amazon.CustomerProfiles.Model.FilterGroup> requestFilter_filter_Group = null;
            if (cmdletContext.Filter_Group != null)
            {
                requestFilter_filter_Group = cmdletContext.Filter_Group;
            }
            if (requestFilter_filter_Group != null)
            {
                request.Filter.Groups = requestFilter_filter_Group;
                requestFilterIsNull = false;
            }
            Amazon.CustomerProfiles.Include requestFilter_filter_Include = null;
            if (cmdletContext.Filter_Include != null)
            {
                requestFilter_filter_Include = cmdletContext.Filter_Include;
            }
            if (requestFilter_filter_Include != null)
            {
                request.Filter.Include = requestFilter_filter_Include;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.Statistic != null)
            {
                request.Statistic = cmdletContext.Statistic;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UseHistoricalData != null)
            {
                request.UseHistoricalData = cmdletContext.UseHistoricalData.Value;
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
        
        private Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "CreateCalculatedAttributeDefinition");
            try
            {
                return client.CreateCalculatedAttributeDefinitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CustomerProfiles.Model.AttributeItem> AttributeDetails_Attribute { get; set; }
            public System.String AttributeDetails_Expression { get; set; }
            public System.String CalculatedAttributeName { get; set; }
            public System.Int32? Conditions_ObjectCount { get; set; }
            public System.String Range_TimestampFormat { get; set; }
            public System.String Range_TimestampSource { get; set; }
            public Amazon.CustomerProfiles.Unit Range_Unit { get; set; }
            public System.Int32? Range_Value { get; set; }
            public System.Int32? ValueRange_End { get; set; }
            public System.Int32? ValueRange_Start { get; set; }
            public Amazon.CustomerProfiles.Operator Threshold_Operator { get; set; }
            public System.String Threshold_Value { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String DomainName { get; set; }
            public List<Amazon.CustomerProfiles.Model.FilterGroup> Filter_Group { get; set; }
            public Amazon.CustomerProfiles.Include Filter_Include { get; set; }
            public Amazon.CustomerProfiles.Statistic Statistic { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Boolean? UseHistoricalData { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.CreateCalculatedAttributeDefinitionResponse, NewCPFCalculatedAttributeDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
