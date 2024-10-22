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
using Amazon.CloudWatchEvents;
using Amazon.CloudWatchEvents.Model;

namespace Amazon.PowerShell.Cmdlets.CWE
{
    /// <summary>
    /// Starts the specified replay. Events are not necessarily replayed in the exact same
    /// order that they were added to the archive. A replay processes events to replay based
    /// on the time in the event, and replays them using 1 minute intervals. If you specify
    /// an <c>EventStartTime</c> and an <c>EventEndTime</c> that covers a 20 minute time range,
    /// the events are replayed from the first minute of that 20 minute range first. Then
    /// the events from the second minute are replayed. You can use <c>DescribeReplay</c>
    /// to determine the progress of a replay. The value returned for <c>EventLastReplayedTime</c>
    /// indicates the time within the specified time range associated with the last event
    /// replayed.
    /// </summary>
    [Cmdlet("Start", "CWEReplay", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchEvents.Model.StartReplayResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Events StartReplay API operation.", Operation = new[] {"StartReplay"}, SelectReturnType = typeof(Amazon.CloudWatchEvents.Model.StartReplayResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvents.Model.StartReplayResponse",
        "This cmdlet returns an Amazon.CloudWatchEvents.Model.StartReplayResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCWEReplayCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Destination_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the event bus to replay event to. You can replay events only to the event
        /// bus specified to create the archive.</para>
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
        public System.String Destination_Arn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the replay to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventEndTime
        /// <summary>
        /// <para>
        /// <para>A time stamp for the time to stop replaying events. Only events that occurred between
        /// the <c>EventStartTime</c> and <c>EventEndTime</c> are replayed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EventEndTime { get; set; }
        #endregion
        
        #region Parameter EventSourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the archive to replay events from.</para>
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
        public System.String EventSourceArn { get; set; }
        #endregion
        
        #region Parameter EventStartTime
        /// <summary>
        /// <para>
        /// <para>A time stamp for the time to start replaying events. Only events that occurred between
        /// the <c>EventStartTime</c> and <c>EventEndTime</c> are replayed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EventStartTime { get; set; }
        #endregion
        
        #region Parameter Destination_FilterArn
        /// <summary>
        /// <para>
        /// <para>A list of ARNs for rules to replay events to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_FilterArns")]
        public System.String[] Destination_FilterArn { get; set; }
        #endregion
        
        #region Parameter ReplayName
        /// <summary>
        /// <para>
        /// <para>The name of the replay to start.</para>
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
        public System.String ReplayName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvents.Model.StartReplayResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvents.Model.StartReplayResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CWEReplay (StartReplay)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvents.Model.StartReplayResponse, StartCWEReplayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Destination_Arn = this.Destination_Arn;
            #if MODULAR
            if (this.Destination_Arn == null && ParameterWasBound(nameof(this.Destination_Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination_Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Destination_FilterArn != null)
            {
                context.Destination_FilterArn = new List<System.String>(this.Destination_FilterArn);
            }
            context.EventEndTime = this.EventEndTime;
            #if MODULAR
            if (this.EventEndTime == null && ParameterWasBound(nameof(this.EventEndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EventEndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventSourceArn = this.EventSourceArn;
            #if MODULAR
            if (this.EventSourceArn == null && ParameterWasBound(nameof(this.EventSourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventSourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventStartTime = this.EventStartTime;
            #if MODULAR
            if (this.EventStartTime == null && ParameterWasBound(nameof(this.EventStartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EventStartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplayName = this.ReplayName;
            #if MODULAR
            if (this.ReplayName == null && ParameterWasBound(nameof(this.ReplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchEvents.Model.StartReplayRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Destination
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.CloudWatchEvents.Model.ReplayDestination();
            System.String requestDestination_destination_Arn = null;
            if (cmdletContext.Destination_Arn != null)
            {
                requestDestination_destination_Arn = cmdletContext.Destination_Arn;
            }
            if (requestDestination_destination_Arn != null)
            {
                request.Destination.Arn = requestDestination_destination_Arn;
                requestDestinationIsNull = false;
            }
            List<System.String> requestDestination_destination_FilterArn = null;
            if (cmdletContext.Destination_FilterArn != null)
            {
                requestDestination_destination_FilterArn = cmdletContext.Destination_FilterArn;
            }
            if (requestDestination_destination_FilterArn != null)
            {
                request.Destination.FilterArns = requestDestination_destination_FilterArn;
                requestDestinationIsNull = false;
            }
             // determine if request.Destination should be set to null
            if (requestDestinationIsNull)
            {
                request.Destination = null;
            }
            if (cmdletContext.EventEndTime != null)
            {
                request.EventEndTime = cmdletContext.EventEndTime.Value;
            }
            if (cmdletContext.EventSourceArn != null)
            {
                request.EventSourceArn = cmdletContext.EventSourceArn;
            }
            if (cmdletContext.EventStartTime != null)
            {
                request.EventStartTime = cmdletContext.EventStartTime.Value;
            }
            if (cmdletContext.ReplayName != null)
            {
                request.ReplayName = cmdletContext.ReplayName;
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
        
        private Amazon.CloudWatchEvents.Model.StartReplayResponse CallAWSServiceOperation(IAmazonCloudWatchEvents client, Amazon.CloudWatchEvents.Model.StartReplayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Events", "StartReplay");
            try
            {
                #if DESKTOP
                return client.StartReplay(request);
                #elif CORECLR
                return client.StartReplayAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Destination_Arn { get; set; }
            public List<System.String> Destination_FilterArn { get; set; }
            public System.DateTime? EventEndTime { get; set; }
            public System.String EventSourceArn { get; set; }
            public System.DateTime? EventStartTime { get; set; }
            public System.String ReplayName { get; set; }
            public System.Func<Amazon.CloudWatchEvents.Model.StartReplayResponse, StartCWEReplayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
