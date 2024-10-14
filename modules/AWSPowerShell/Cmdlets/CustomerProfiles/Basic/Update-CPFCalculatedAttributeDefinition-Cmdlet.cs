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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

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
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CalculatedAttributeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CalculatedAttributeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CalculatedAttributeName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CPFCalculatedAttributeDefinition (UpdateCalculatedAttributeDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.UpdateCalculatedAttributeDefinitionResponse, UpdateCPFCalculatedAttributeDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CalculatedAttributeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CalculatedAttributeName = this.CalculatedAttributeName;
            #if MODULAR
            if (this.CalculatedAttributeName == null && ParameterWasBound(nameof(this.CalculatedAttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter CalculatedAttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Conditions_ObjectCount = this.Conditions_ObjectCount;
            context.Range_Unit = this.Range_Unit;
            context.Range_Value = this.Range_Value;
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
            Amazon.CustomerProfiles.Model.Range requestConditions_conditions_Range = null;
            
             // populate Range
            var requestConditions_conditions_RangeIsNull = true;
            requestConditions_conditions_Range = new Amazon.CustomerProfiles.Model.Range();
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
                #if DESKTOP
                return client.UpdateCalculatedAttributeDefinition(request);
                #elif CORECLR
                return client.UpdateCalculatedAttributeDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String CalculatedAttributeName { get; set; }
            public System.Int32? Conditions_ObjectCount { get; set; }
            public Amazon.CustomerProfiles.Unit Range_Unit { get; set; }
            public System.Int32? Range_Value { get; set; }
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
