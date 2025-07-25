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
    /// Update the properties of an Event Trigger.
    /// </summary>
    [Cmdlet("Update", "CPFEventTrigger", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.UpdateEventTriggerResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles UpdateEventTrigger API operation.", Operation = new[] {"UpdateEventTrigger"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.UpdateEventTriggerResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.UpdateEventTriggerResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.UpdateEventTriggerResponse object containing multiple properties."
    )]
    public partial class UpdateCPFEventTriggerCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the event trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
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
        
        #region Parameter EventTriggerLimits_EventExpiration
        /// <summary>
        /// <para>
        /// <para>In milliseconds. Specifies that an event will only trigger the destination if it is
        /// processed within a certain latency period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? EventTriggerLimits_EventExpiration { get; set; }
        #endregion
        
        #region Parameter EventTriggerCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions that determine when an event should trigger the destination.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventTriggerConditions")]
        public Amazon.CustomerProfiles.Model.EventTriggerCondition[] EventTriggerCondition { get; set; }
        #endregion
        
        #region Parameter EventTriggerName
        /// <summary>
        /// <para>
        /// <para>The unique name of the event trigger.</para>
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
        public System.String EventTriggerName { get; set; }
        #endregion
        
        #region Parameter ObjectTypeName
        /// <summary>
        /// <para>
        /// <para>The unique name of the object type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ObjectTypeName { get; set; }
        #endregion
        
        #region Parameter EventTriggerLimits_Period
        /// <summary>
        /// <para>
        /// <para>A list of time periods during which the limits apply.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventTriggerLimits_Periods")]
        public Amazon.CustomerProfiles.Model.Period[] EventTriggerLimits_Period { get; set; }
        #endregion
        
        #region Parameter SegmentFilter
        /// <summary>
        /// <para>
        /// <para>The destination is triggered only for profiles that meet the criteria of a segment
        /// definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SegmentFilter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.UpdateEventTriggerResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.UpdateEventTriggerResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EventTriggerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CPFEventTrigger (UpdateEventTrigger)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.UpdateEventTriggerResponse, UpdateCPFEventTriggerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EventTriggerCondition != null)
            {
                context.EventTriggerCondition = new List<Amazon.CustomerProfiles.Model.EventTriggerCondition>(this.EventTriggerCondition);
            }
            context.EventTriggerLimits_EventExpiration = this.EventTriggerLimits_EventExpiration;
            if (this.EventTriggerLimits_Period != null)
            {
                context.EventTriggerLimits_Period = new List<Amazon.CustomerProfiles.Model.Period>(this.EventTriggerLimits_Period);
            }
            context.EventTriggerName = this.EventTriggerName;
            #if MODULAR
            if (this.EventTriggerName == null && ParameterWasBound(nameof(this.EventTriggerName)))
            {
                WriteWarning("You are passing $null as a value for parameter EventTriggerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ObjectTypeName = this.ObjectTypeName;
            context.SegmentFilter = this.SegmentFilter;
            
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
            var request = new Amazon.CustomerProfiles.Model.UpdateEventTriggerRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.EventTriggerCondition != null)
            {
                request.EventTriggerConditions = cmdletContext.EventTriggerCondition;
            }
            
             // populate EventTriggerLimits
            var requestEventTriggerLimitsIsNull = true;
            request.EventTriggerLimits = new Amazon.CustomerProfiles.Model.EventTriggerLimits();
            System.Int64? requestEventTriggerLimits_eventTriggerLimits_EventExpiration = null;
            if (cmdletContext.EventTriggerLimits_EventExpiration != null)
            {
                requestEventTriggerLimits_eventTriggerLimits_EventExpiration = cmdletContext.EventTriggerLimits_EventExpiration.Value;
            }
            if (requestEventTriggerLimits_eventTriggerLimits_EventExpiration != null)
            {
                request.EventTriggerLimits.EventExpiration = requestEventTriggerLimits_eventTriggerLimits_EventExpiration.Value;
                requestEventTriggerLimitsIsNull = false;
            }
            List<Amazon.CustomerProfiles.Model.Period> requestEventTriggerLimits_eventTriggerLimits_Period = null;
            if (cmdletContext.EventTriggerLimits_Period != null)
            {
                requestEventTriggerLimits_eventTriggerLimits_Period = cmdletContext.EventTriggerLimits_Period;
            }
            if (requestEventTriggerLimits_eventTriggerLimits_Period != null)
            {
                request.EventTriggerLimits.Periods = requestEventTriggerLimits_eventTriggerLimits_Period;
                requestEventTriggerLimitsIsNull = false;
            }
             // determine if request.EventTriggerLimits should be set to null
            if (requestEventTriggerLimitsIsNull)
            {
                request.EventTriggerLimits = null;
            }
            if (cmdletContext.EventTriggerName != null)
            {
                request.EventTriggerName = cmdletContext.EventTriggerName;
            }
            if (cmdletContext.ObjectTypeName != null)
            {
                request.ObjectTypeName = cmdletContext.ObjectTypeName;
            }
            if (cmdletContext.SegmentFilter != null)
            {
                request.SegmentFilter = cmdletContext.SegmentFilter;
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
        
        private Amazon.CustomerProfiles.Model.UpdateEventTriggerResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.UpdateEventTriggerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "UpdateEventTrigger");
            try
            {
                return client.UpdateEventTriggerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DomainName { get; set; }
            public List<Amazon.CustomerProfiles.Model.EventTriggerCondition> EventTriggerCondition { get; set; }
            public System.Int64? EventTriggerLimits_EventExpiration { get; set; }
            public List<Amazon.CustomerProfiles.Model.Period> EventTriggerLimits_Period { get; set; }
            public System.String EventTriggerName { get; set; }
            public System.String ObjectTypeName { get; set; }
            public System.String SegmentFilter { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.UpdateEventTriggerResponse, UpdateCPFEventTriggerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
