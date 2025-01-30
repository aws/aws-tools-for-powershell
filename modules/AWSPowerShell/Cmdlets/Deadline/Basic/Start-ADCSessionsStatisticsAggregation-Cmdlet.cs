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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Starts an asynchronous request for getting aggregated statistics about queues and
    /// farms. Get the statistics using the <c>GetSessionsStatisticsAggregation</c> operation.
    /// You can only have one running aggregation for your Deadline Cloud farm. Call the <c>GetSessionsStatisticsAggregation</c>
    /// operation and check the <c>status</c> field to see if an aggregation is running. Statistics
    /// are available for 1 hour after you call the <c>StartSessionsStatisticsAggregation</c>
    /// operation.
    /// </summary>
    [Cmdlet("Start", "ADCSessionsStatisticsAggregation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWSDeadlineCloud StartSessionsStatisticsAggregation API operation.", Operation = new[] {"StartSessionsStatisticsAggregation"}, SelectReturnType = typeof(Amazon.Deadline.Model.StartSessionsStatisticsAggregationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Deadline.Model.StartSessionsStatisticsAggregationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Deadline.Model.StartSessionsStatisticsAggregationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartADCSessionsStatisticsAggregationCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The Linux timestamp of the date and time that the statistics end.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The identifier of the farm that contains queues or fleets to return statistics for.</para>
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
        public System.String FarmId { get; set; }
        #endregion
        
        #region Parameter ResourceIds_FleetId
        /// <summary>
        /// <para>
        /// <para>One to 10 fleet IDs that specify the fleets to return statistics for. If you specify
        /// the <c>fleetIds</c> field, you can't specify the <c>queueIds</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIds_FleetIds")]
        public System.String[] ResourceIds_FleetId { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>The field to use to group the statistics.</para>
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
        public System.String[] GroupBy { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The period to aggregate the statistics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.Period")]
        public Amazon.Deadline.Period Period { get; set; }
        #endregion
        
        #region Parameter ResourceIds_QueueId
        /// <summary>
        /// <para>
        /// <para>One to 10 queue IDs that specify the queues to return statistics for. If you specify
        /// the <c>queueIds</c> field, you can't specify the <c>fleetIds</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceIds_QueueIds")]
        public System.String[] ResourceIds_QueueId { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The Linux timestamp of the date and time that the statistics start.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para>One to four statistics to return.</para>
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
        [Alias("Statistics")]
        public System.String[] Statistic { get; set; }
        #endregion
        
        #region Parameter Timezone
        /// <summary>
        /// <para>
        /// <para>The timezone to use for the statistics. Use UTC notation such as "UTC+8."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Timezone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AggregationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.StartSessionsStatisticsAggregationResponse).
        /// Specifying the name of a property of type Amazon.Deadline.Model.StartSessionsStatisticsAggregationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AggregationId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FarmId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ADCSessionsStatisticsAggregation (StartSessionsStatisticsAggregation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.StartSessionsStatisticsAggregationResponse, StartADCSessionsStatisticsAggregationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FarmId = this.FarmId;
            #if MODULAR
            if (this.FarmId == null && ParameterWasBound(nameof(this.FarmId)))
            {
                WriteWarning("You are passing $null as a value for parameter FarmId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GroupBy != null)
            {
                context.GroupBy = new List<System.String>(this.GroupBy);
            }
            #if MODULAR
            if (this.GroupBy == null && ParameterWasBound(nameof(this.GroupBy)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupBy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Period = this.Period;
            if (this.ResourceIds_FleetId != null)
            {
                context.ResourceIds_FleetId = new List<System.String>(this.ResourceIds_FleetId);
            }
            if (this.ResourceIds_QueueId != null)
            {
                context.ResourceIds_QueueId = new List<System.String>(this.ResourceIds_QueueId);
            }
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Statistic != null)
            {
                context.Statistic = new List<System.String>(this.Statistic);
            }
            #if MODULAR
            if (this.Statistic == null && ParameterWasBound(nameof(this.Statistic)))
            {
                WriteWarning("You are passing $null as a value for parameter Statistic which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Timezone = this.Timezone;
            
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
            var request = new Amazon.Deadline.Model.StartSessionsStatisticsAggregationRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.FarmId != null)
            {
                request.FarmId = cmdletContext.FarmId;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period;
            }
            
             // populate ResourceIds
            var requestResourceIdsIsNull = true;
            request.ResourceIds = new Amazon.Deadline.Model.SessionsStatisticsResources();
            List<System.String> requestResourceIds_resourceIds_FleetId = null;
            if (cmdletContext.ResourceIds_FleetId != null)
            {
                requestResourceIds_resourceIds_FleetId = cmdletContext.ResourceIds_FleetId;
            }
            if (requestResourceIds_resourceIds_FleetId != null)
            {
                request.ResourceIds.FleetIds = requestResourceIds_resourceIds_FleetId;
                requestResourceIdsIsNull = false;
            }
            List<System.String> requestResourceIds_resourceIds_QueueId = null;
            if (cmdletContext.ResourceIds_QueueId != null)
            {
                requestResourceIds_resourceIds_QueueId = cmdletContext.ResourceIds_QueueId;
            }
            if (requestResourceIds_resourceIds_QueueId != null)
            {
                request.ResourceIds.QueueIds = requestResourceIds_resourceIds_QueueId;
                requestResourceIdsIsNull = false;
            }
             // determine if request.ResourceIds should be set to null
            if (requestResourceIdsIsNull)
            {
                request.ResourceIds = null;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Statistic != null)
            {
                request.Statistics = cmdletContext.Statistic;
            }
            if (cmdletContext.Timezone != null)
            {
                request.Timezone = cmdletContext.Timezone;
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
        
        private Amazon.Deadline.Model.StartSessionsStatisticsAggregationResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.StartSessionsStatisticsAggregationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "StartSessionsStatisticsAggregation");
            try
            {
                #if DESKTOP
                return client.StartSessionsStatisticsAggregation(request);
                #elif CORECLR
                return client.StartSessionsStatisticsAggregationAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String FarmId { get; set; }
            public List<System.String> GroupBy { get; set; }
            public Amazon.Deadline.Period Period { get; set; }
            public List<System.String> ResourceIds_FleetId { get; set; }
            public List<System.String> ResourceIds_QueueId { get; set; }
            public System.DateTime? StartTime { get; set; }
            public List<System.String> Statistic { get; set; }
            public System.String Timezone { get; set; }
            public System.Func<Amazon.Deadline.Model.StartSessionsStatisticsAggregationResponse, StartADCSessionsStatisticsAggregationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AggregationId;
        }
        
    }
}
