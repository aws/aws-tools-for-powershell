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
    /// Updates an existing calculated attribute definition. When updating the Conditions,
    /// note that increasing the date range of a calculated attribute will not trigger inclusion
    /// of historical data greater than the current date range.
    /// </summary>
    [Cmdlet("Update", "CPFCalculatedAttributeDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles UpdateCalculatedAttributeDefinition API operation.", Operation = new[] {"UpdateCalculatedAttributeDefinition"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionResponse object containing multiple properties."
    )]
    public partial class UpdateCPFCalculatedAttributeDefinitionCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CPFCalculatedAttributeDefinition (UpdateCalculatedAttributeDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionResponse, UpdateCPFCalculatedAttributeDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionRequest();
            
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
        
        private Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "UpdateCalculatedAttributeDefinition");
            try
            {
                return client.UpdateCalculatedAttributeDefinitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionResponse, UpdateCPFCalculatedAttributeDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
