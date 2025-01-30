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
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// Creates a prefetch schedule for a playback configuration. A prefetch schedule allows
    /// you to tell MediaTailor to fetch and prepare certain ads before an ad break happens.
    /// For more information about ad prefetching, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/prefetching-ads.html">Using
    /// ad prefetching</a> in the <i>MediaTailor User Guide</i>.
    /// </summary>
    [Cmdlet("New", "EMTPrefetchSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor CreatePrefetchSchedule API operation.", Operation = new[] {"CreatePrefetchSchedule"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse))]
    [AWSCmdletOutput("Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse",
        "This cmdlet returns an Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse object containing multiple properties."
    )]
    public partial class NewEMTPrefetchScheduleCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Consumption_AvailMatchingCriterion
        /// <summary>
        /// <para>
        /// <para>If you only want MediaTailor to insert prefetched ads into avails (ad breaks) that
        /// match specific dynamic variables, such as <c>scte.event_id</c>, set the avail matching
        /// criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Consumption_AvailMatchingCriteria")]
        public Amazon.MediaTailor.Model.AvailMatchingCriteria[] Consumption_AvailMatchingCriterion { get; set; }
        #endregion
        
        #region Parameter Retrieval_DynamicVariable
        /// <summary>
        /// <para>
        /// <para>The dynamic variables to use for substitution during prefetch requests to the ad decision
        /// server (ADS).</para><para>You initially configure <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/variables.html">dynamic
        /// variables</a> for the ADS URL when you set up your playback configuration. When you
        /// specify <c>DynamicVariables</c> for prefetch retrieval, MediaTailor includes the dynamic
        /// variables in the request to the ADS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Retrieval_DynamicVariables")]
        public System.Collections.Hashtable Retrieval_DynamicVariable { get; set; }
        #endregion
        
        #region Parameter Consumption_EndTime
        /// <summary>
        /// <para>
        /// <para>The time when MediaTailor no longer considers the prefetched ads for use in an ad
        /// break. MediaTailor automatically deletes prefetch schedules no less than seven days
        /// after the end time. If you'd like to manually delete the prefetch schedule, you can
        /// call <c>DeletePrefetchSchedule</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? Consumption_EndTime { get; set; }
        #endregion
        
        #region Parameter Retrieval_EndTime
        /// <summary>
        /// <para>
        /// <para>The time when prefetch retrieval ends for the ad break. Prefetching will be attempted
        /// for manifest requests that occur at or before this time.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? Retrieval_EndTime { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name to assign to the schedule request.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PlaybackConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name to assign to the playback configuration.</para>
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
        public System.String PlaybackConfigurationName { get; set; }
        #endregion
        
        #region Parameter Consumption_StartTime
        /// <summary>
        /// <para>
        /// <para>The time when prefetched ads are considered for use in an ad break. If you don't specify
        /// <c>StartTime</c>, the prefetched ads are available after MediaTailor retrieves them
        /// from the ad decision server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Consumption_StartTime { get; set; }
        #endregion
        
        #region Parameter Retrieval_StartTime
        /// <summary>
        /// <para>
        /// <para>The time when prefetch retrievals can start for this break. Ad prefetching will be
        /// attempted for manifest requests that occur at or after this time. Defaults to the
        /// current time. If not specified, the prefetch retrieval starts as soon as possible.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Retrieval_StartTime { get; set; }
        #endregion
        
        #region Parameter StreamId
        /// <summary>
        /// <para>
        /// <para>An optional stream identifier that MediaTailor uses to prefetch ads for multiple streams
        /// that use the same playback configuration. If <c>StreamId</c> is specified, MediaTailor
        /// returns all of the prefetch schedules with an exact match on <c>StreamId</c>. If not
        /// specified, MediaTailor returns all of the prefetch schedules for the playback configuration,
        /// regardless of <c>StreamId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse).
        /// Specifying the name of a property of type Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMTPrefetchSchedule (CreatePrefetchSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse, NewEMTPrefetchScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Consumption_AvailMatchingCriterion != null)
            {
                context.Consumption_AvailMatchingCriterion = new List<Amazon.MediaTailor.Model.AvailMatchingCriteria>(this.Consumption_AvailMatchingCriterion);
            }
            context.Consumption_EndTime = this.Consumption_EndTime;
            #if MODULAR
            if (this.Consumption_EndTime == null && ParameterWasBound(nameof(this.Consumption_EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter Consumption_EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Consumption_StartTime = this.Consumption_StartTime;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlaybackConfigurationName = this.PlaybackConfigurationName;
            #if MODULAR
            if (this.PlaybackConfigurationName == null && ParameterWasBound(nameof(this.PlaybackConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter PlaybackConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Retrieval_DynamicVariable != null)
            {
                context.Retrieval_DynamicVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Retrieval_DynamicVariable.Keys)
                {
                    context.Retrieval_DynamicVariable.Add((String)hashKey, (System.String)(this.Retrieval_DynamicVariable[hashKey]));
                }
            }
            context.Retrieval_EndTime = this.Retrieval_EndTime;
            #if MODULAR
            if (this.Retrieval_EndTime == null && ParameterWasBound(nameof(this.Retrieval_EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter Retrieval_EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Retrieval_StartTime = this.Retrieval_StartTime;
            context.StreamId = this.StreamId;
            
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
            var request = new Amazon.MediaTailor.Model.CreatePrefetchScheduleRequest();
            
            
             // populate Consumption
            var requestConsumptionIsNull = true;
            request.Consumption = new Amazon.MediaTailor.Model.PrefetchConsumption();
            List<Amazon.MediaTailor.Model.AvailMatchingCriteria> requestConsumption_consumption_AvailMatchingCriterion = null;
            if (cmdletContext.Consumption_AvailMatchingCriterion != null)
            {
                requestConsumption_consumption_AvailMatchingCriterion = cmdletContext.Consumption_AvailMatchingCriterion;
            }
            if (requestConsumption_consumption_AvailMatchingCriterion != null)
            {
                request.Consumption.AvailMatchingCriteria = requestConsumption_consumption_AvailMatchingCriterion;
                requestConsumptionIsNull = false;
            }
            System.DateTime? requestConsumption_consumption_EndTime = null;
            if (cmdletContext.Consumption_EndTime != null)
            {
                requestConsumption_consumption_EndTime = cmdletContext.Consumption_EndTime.Value;
            }
            if (requestConsumption_consumption_EndTime != null)
            {
                request.Consumption.EndTime = requestConsumption_consumption_EndTime.Value;
                requestConsumptionIsNull = false;
            }
            System.DateTime? requestConsumption_consumption_StartTime = null;
            if (cmdletContext.Consumption_StartTime != null)
            {
                requestConsumption_consumption_StartTime = cmdletContext.Consumption_StartTime.Value;
            }
            if (requestConsumption_consumption_StartTime != null)
            {
                request.Consumption.StartTime = requestConsumption_consumption_StartTime.Value;
                requestConsumptionIsNull = false;
            }
             // determine if request.Consumption should be set to null
            if (requestConsumptionIsNull)
            {
                request.Consumption = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PlaybackConfigurationName != null)
            {
                request.PlaybackConfigurationName = cmdletContext.PlaybackConfigurationName;
            }
            
             // populate Retrieval
            var requestRetrievalIsNull = true;
            request.Retrieval = new Amazon.MediaTailor.Model.PrefetchRetrieval();
            Dictionary<System.String, System.String> requestRetrieval_retrieval_DynamicVariable = null;
            if (cmdletContext.Retrieval_DynamicVariable != null)
            {
                requestRetrieval_retrieval_DynamicVariable = cmdletContext.Retrieval_DynamicVariable;
            }
            if (requestRetrieval_retrieval_DynamicVariable != null)
            {
                request.Retrieval.DynamicVariables = requestRetrieval_retrieval_DynamicVariable;
                requestRetrievalIsNull = false;
            }
            System.DateTime? requestRetrieval_retrieval_EndTime = null;
            if (cmdletContext.Retrieval_EndTime != null)
            {
                requestRetrieval_retrieval_EndTime = cmdletContext.Retrieval_EndTime.Value;
            }
            if (requestRetrieval_retrieval_EndTime != null)
            {
                request.Retrieval.EndTime = requestRetrieval_retrieval_EndTime.Value;
                requestRetrievalIsNull = false;
            }
            System.DateTime? requestRetrieval_retrieval_StartTime = null;
            if (cmdletContext.Retrieval_StartTime != null)
            {
                requestRetrieval_retrieval_StartTime = cmdletContext.Retrieval_StartTime.Value;
            }
            if (requestRetrieval_retrieval_StartTime != null)
            {
                request.Retrieval.StartTime = requestRetrieval_retrieval_StartTime.Value;
                requestRetrievalIsNull = false;
            }
             // determine if request.Retrieval should be set to null
            if (requestRetrievalIsNull)
            {
                request.Retrieval = null;
            }
            if (cmdletContext.StreamId != null)
            {
                request.StreamId = cmdletContext.StreamId;
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
        
        private Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.CreatePrefetchScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "CreatePrefetchSchedule");
            try
            {
                #if DESKTOP
                return client.CreatePrefetchSchedule(request);
                #elif CORECLR
                return client.CreatePrefetchScheduleAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.MediaTailor.Model.AvailMatchingCriteria> Consumption_AvailMatchingCriterion { get; set; }
            public System.DateTime? Consumption_EndTime { get; set; }
            public System.DateTime? Consumption_StartTime { get; set; }
            public System.String Name { get; set; }
            public System.String PlaybackConfigurationName { get; set; }
            public Dictionary<System.String, System.String> Retrieval_DynamicVariable { get; set; }
            public System.DateTime? Retrieval_EndTime { get; set; }
            public System.DateTime? Retrieval_StartTime { get; set; }
            public System.String StreamId { get; set; }
            public System.Func<Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse, NewEMTPrefetchScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
