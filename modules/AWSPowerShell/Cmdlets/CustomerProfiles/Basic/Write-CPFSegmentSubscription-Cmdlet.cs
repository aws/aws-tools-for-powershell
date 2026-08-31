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
    /// Creates or updates a segment subscription for membership events. When a subscription
    /// is created, an initial snapshot is taken and the system begins monitoring for membership
    /// changes. 
    /// 
    ///  
    /// <para>
    /// You can optionally set a schedule configuration interval to control how often membership
    /// snapshots are run. The interval can be from 1 to 24 hours. If not set, the interval
    /// defaults to 24 hours. Scheduled snapshots run on a best-effort basis. If a scheduled
    /// snapshot takes longer than the configured interval, the next scheduled run does not
    /// start until the in-progress snapshot completes, so a run might be delayed or skipped
    /// and is not guaranteed to occur at exactly the requested time. 
    /// </para><para>
    /// For Classic segments, membership events are generated from these scheduled snapshots
    /// and also in near real-time as profile attribute changes occur. For SQL segments, membership
    /// events are generated only from the scheduled snapshots. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CPFSegmentSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.PutSegmentSubscriptionResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles PutSegmentSubscription API operation.", Operation = new[] {"PutSegmentSubscription"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.PutSegmentSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.PutSegmentSubscriptionResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.PutSegmentSubscriptionResponse object containing multiple properties."
    )]
    public partial class WriteCPFSegmentSubscriptionCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter ScheduleConfiguration_Interval
        /// <summary>
        /// <para>
        /// <para>The interval between scheduled executions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScheduleConfiguration_Interval { get; set; }
        #endregion
        
        #region Parameter SegmentDefinitionName
        /// <summary>
        /// <para>
        /// <para>The unique name of the segment definition. </para>
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
        public System.String SegmentDefinitionName { get; set; }
        #endregion
        
        #region Parameter ScheduleConfiguration_Unit
        /// <summary>
        /// <para>
        /// <para>The unit for the interval. The following are valid values: </para><ul><li><para><b>HOURLY</b>: The interval is measured in hours. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CustomerProfiles.ScheduleConfigurationUnit")]
        public Amazon.CustomerProfiles.ScheduleConfigurationUnit ScheduleConfiguration_Unit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.PutSegmentSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.PutSegmentSubscriptionResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.DomainName),
                nameof(this.SegmentDefinitionName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPFSegmentSubscription (PutSegmentSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.PutSegmentSubscriptionResponse, WriteCPFSegmentSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleConfiguration_Interval = this.ScheduleConfiguration_Interval;
            context.ScheduleConfiguration_Unit = this.ScheduleConfiguration_Unit;
            context.SegmentDefinitionName = this.SegmentDefinitionName;
            #if MODULAR
            if (this.SegmentDefinitionName == null && ParameterWasBound(nameof(this.SegmentDefinitionName)))
            {
                WriteWarning("You are passing $null as a value for parameter SegmentDefinitionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CustomerProfiles.Model.PutSegmentSubscriptionRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate ScheduleConfiguration
            var requestScheduleConfigurationIsNull = true;
            request.ScheduleConfiguration = new Amazon.CustomerProfiles.Model.ScheduleConfiguration();
            System.Int32? requestScheduleConfiguration_scheduleConfiguration_Interval = null;
            if (cmdletContext.ScheduleConfiguration_Interval != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Interval = cmdletContext.ScheduleConfiguration_Interval.Value;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_Interval != null)
            {
                request.ScheduleConfiguration.Interval = requestScheduleConfiguration_scheduleConfiguration_Interval.Value;
                requestScheduleConfigurationIsNull = false;
            }
            Amazon.CustomerProfiles.ScheduleConfigurationUnit requestScheduleConfiguration_scheduleConfiguration_Unit = null;
            if (cmdletContext.ScheduleConfiguration_Unit != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_Unit = cmdletContext.ScheduleConfiguration_Unit;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_Unit != null)
            {
                request.ScheduleConfiguration.Unit = requestScheduleConfiguration_scheduleConfiguration_Unit;
                requestScheduleConfigurationIsNull = false;
            }
             // determine if request.ScheduleConfiguration should be set to null
            if (requestScheduleConfigurationIsNull)
            {
                request.ScheduleConfiguration = null;
            }
            if (cmdletContext.SegmentDefinitionName != null)
            {
                request.SegmentDefinitionName = cmdletContext.SegmentDefinitionName;
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
        
        private Amazon.CustomerProfiles.Model.PutSegmentSubscriptionResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.PutSegmentSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "PutSegmentSubscription");
            try
            {
                return client.PutSegmentSubscriptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public System.Int32? ScheduleConfiguration_Interval { get; set; }
            public Amazon.CustomerProfiles.ScheduleConfigurationUnit ScheduleConfiguration_Unit { get; set; }
            public System.String SegmentDefinitionName { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.PutSegmentSubscriptionResponse, WriteCPFSegmentSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
