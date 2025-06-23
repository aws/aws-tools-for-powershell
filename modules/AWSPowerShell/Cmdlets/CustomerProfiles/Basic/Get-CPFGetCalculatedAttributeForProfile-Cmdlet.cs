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
    /// Fetch the possible attribute values given the attribute name.
    /// </summary>
    [Cmdlet("Get", "CPFGetCalculatedAttributeForProfile")]
    [OutputType("Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles BatchGetCalculatedAttributeForProfile API operation.", Operation = new[] {"BatchGetCalculatedAttributeForProfile"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileResponse object containing multiple properties."
    )]
    public partial class GetCPFGetCalculatedAttributeForProfileCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
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
        
        #region Parameter Range_End
        /// <summary>
        /// <para>
        /// <para>The end time of when to include objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConditionOverrides_Range_End")]
        public System.Int32? Range_End { get; set; }
        #endregion
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para>List of unique identifiers for customer profiles to retrieve.</para><para />
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
        [Alias("ProfileIds")]
        public System.String[] ProfileId { get; set; }
        #endregion
        
        #region Parameter Range_Start
        /// <summary>
        /// <para>
        /// <para>The start time of when to include objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConditionOverrides_Range_Start")]
        public System.Int32? Range_Start { get; set; }
        #endregion
        
        #region Parameter Range_Unit
        /// <summary>
        /// <para>
        /// <para>The unit for start and end.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConditionOverrides_Range_Unit")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.RangeUnit")]
        public Amazon.CustomerProfiles.RangeUnit Range_Unit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileResponse, GetCPFGetCalculatedAttributeForProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CalculatedAttributeName = this.CalculatedAttributeName;
            #if MODULAR
            if (this.CalculatedAttributeName == null && ParameterWasBound(nameof(this.CalculatedAttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter CalculatedAttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Range_End = this.Range_End;
            context.Range_Start = this.Range_Start;
            context.Range_Unit = this.Range_Unit;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ProfileId != null)
            {
                context.ProfileId = new List<System.String>(this.ProfileId);
            }
            #if MODULAR
            if (this.ProfileId == null && ParameterWasBound(nameof(this.ProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileRequest();
            
            if (cmdletContext.CalculatedAttributeName != null)
            {
                request.CalculatedAttributeName = cmdletContext.CalculatedAttributeName;
            }
            
             // populate ConditionOverrides
            var requestConditionOverridesIsNull = true;
            request.ConditionOverrides = new Amazon.CustomerProfiles.Model.ConditionOverrides();
            Amazon.CustomerProfiles.Model.RangeOverride requestConditionOverrides_conditionOverrides_Range = null;
            
             // populate Range
            var requestConditionOverrides_conditionOverrides_RangeIsNull = true;
            requestConditionOverrides_conditionOverrides_Range = new Amazon.CustomerProfiles.Model.RangeOverride();
            System.Int32? requestConditionOverrides_conditionOverrides_Range_range_End = null;
            if (cmdletContext.Range_End != null)
            {
                requestConditionOverrides_conditionOverrides_Range_range_End = cmdletContext.Range_End.Value;
            }
            if (requestConditionOverrides_conditionOverrides_Range_range_End != null)
            {
                requestConditionOverrides_conditionOverrides_Range.End = requestConditionOverrides_conditionOverrides_Range_range_End.Value;
                requestConditionOverrides_conditionOverrides_RangeIsNull = false;
            }
            System.Int32? requestConditionOverrides_conditionOverrides_Range_range_Start = null;
            if (cmdletContext.Range_Start != null)
            {
                requestConditionOverrides_conditionOverrides_Range_range_Start = cmdletContext.Range_Start.Value;
            }
            if (requestConditionOverrides_conditionOverrides_Range_range_Start != null)
            {
                requestConditionOverrides_conditionOverrides_Range.Start = requestConditionOverrides_conditionOverrides_Range_range_Start.Value;
                requestConditionOverrides_conditionOverrides_RangeIsNull = false;
            }
            Amazon.CustomerProfiles.RangeUnit requestConditionOverrides_conditionOverrides_Range_range_Unit = null;
            if (cmdletContext.Range_Unit != null)
            {
                requestConditionOverrides_conditionOverrides_Range_range_Unit = cmdletContext.Range_Unit;
            }
            if (requestConditionOverrides_conditionOverrides_Range_range_Unit != null)
            {
                requestConditionOverrides_conditionOverrides_Range.Unit = requestConditionOverrides_conditionOverrides_Range_range_Unit;
                requestConditionOverrides_conditionOverrides_RangeIsNull = false;
            }
             // determine if requestConditionOverrides_conditionOverrides_Range should be set to null
            if (requestConditionOverrides_conditionOverrides_RangeIsNull)
            {
                requestConditionOverrides_conditionOverrides_Range = null;
            }
            if (requestConditionOverrides_conditionOverrides_Range != null)
            {
                request.ConditionOverrides.Range = requestConditionOverrides_conditionOverrides_Range;
                requestConditionOverridesIsNull = false;
            }
             // determine if request.ConditionOverrides should be set to null
            if (requestConditionOverridesIsNull)
            {
                request.ConditionOverrides = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileIds = cmdletContext.ProfileId;
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
        
        private Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "BatchGetCalculatedAttributeForProfile");
            try
            {
                return client.BatchGetCalculatedAttributeForProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Range_End { get; set; }
            public System.Int32? Range_Start { get; set; }
            public Amazon.CustomerProfiles.RangeUnit Range_Unit { get; set; }
            public System.String DomainName { get; set; }
            public List<System.String> ProfileId { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.BatchGetCalculatedAttributeForProfileResponse, GetCPFGetCalculatedAttributeForProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
