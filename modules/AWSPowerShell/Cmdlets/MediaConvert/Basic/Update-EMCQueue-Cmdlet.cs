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
using Amazon.MediaConvert;
using Amazon.MediaConvert.Model;

namespace Amazon.PowerShell.Cmdlets.EMC
{
    /// <summary>
    /// Modify one of your existing queues.
    /// </summary>
    [Cmdlet("Update", "EMCQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConvert.Model.Queue")]
    [AWSCmdlet("Calls the AWS Elemental MediaConvert UpdateQueue API operation.", Operation = new[] {"UpdateQueue"}, SelectReturnType = typeof(Amazon.MediaConvert.Model.UpdateQueueResponse))]
    [AWSCmdletOutput("Amazon.MediaConvert.Model.Queue or Amazon.MediaConvert.Model.UpdateQueueResponse",
        "This cmdlet returns an Amazon.MediaConvert.Model.Queue object.",
        "The service call response (type Amazon.MediaConvert.Model.UpdateQueueResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEMCQueueCmdlet : AmazonMediaConvertClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ReservationPlanSettings_Commitment
        /// <summary>
        /// <para>
        /// The length of the term of your reserved queue
        /// pricing plan commitment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConvert.Commitment")]
        public Amazon.MediaConvert.Commitment ReservationPlanSettings_Commitment { get; set; }
        #endregion
        
        #region Parameter ConcurrentJob
        /// <summary>
        /// <para>
        /// Specify the maximum number of jobs your
        /// queue can process concurrently. For on-demand queues, the value you enter is constrained
        /// by your service quotas for Maximum concurrent jobs, per on-demand queue and Maximum
        /// concurrent jobs, per account. For reserved queues, update your reservation plan instead
        /// in order to increase your yearly commitment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConcurrentJobs")]
        public System.Int32? ConcurrentJob { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The new description for the queue, if you
        /// are changing it.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the queue that you are modifying.
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
        
        #region Parameter ReservationPlanSettings_RenewalType
        /// <summary>
        /// <para>
        /// Specifies whether the term of your reserved
        /// queue pricing plan is automatically extended (AUTO_RENEW) or expires (EXPIRE) at the
        /// end of the term. When your term is auto renewed, you extend your commitment by 12
        /// months from the auto renew date. You can cancel this commitment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConvert.RenewalType")]
        public Amazon.MediaConvert.RenewalType ReservationPlanSettings_RenewalType { get; set; }
        #endregion
        
        #region Parameter ReservationPlanSettings_ReservedSlot
        /// <summary>
        /// <para>
        /// Specifies the number of reserved transcode
        /// slots (RTS) for this queue. The number of RTS determines how many jobs the queue can
        /// process in parallel; each RTS can process one job at a time. You can't decrease the
        /// number of RTS in your reserved queue. You can increase the number of RTS by extending
        /// your existing commitment with a new 12-month commitment for the larger number. The
        /// new commitment begins when you purchase the additional capacity. You can't cancel
        /// your commitment or revert to your original commitment after you increase the capacity.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReservationPlanSettings_ReservedSlots")]
        public System.Int32? ReservationPlanSettings_ReservedSlot { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// Pause or activate a queue by changing its status
        /// between ACTIVE and PAUSED. If you pause a queue, jobs in that queue won't begin. Jobs
        /// that are running when you pause the queue continue to run until they finish or result
        /// in an error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConvert.QueueStatus")]
        public Amazon.MediaConvert.QueueStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Queue'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConvert.Model.UpdateQueueResponse).
        /// Specifying the name of a property of type Amazon.MediaConvert.Model.UpdateQueueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Queue";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCQueue (UpdateQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConvert.Model.UpdateQueueResponse, UpdateEMCQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConcurrentJob = this.ConcurrentJob;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReservationPlanSettings_Commitment = this.ReservationPlanSettings_Commitment;
            context.ReservationPlanSettings_RenewalType = this.ReservationPlanSettings_RenewalType;
            context.ReservationPlanSettings_ReservedSlot = this.ReservationPlanSettings_ReservedSlot;
            context.Status = this.Status;
            
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
            var request = new Amazon.MediaConvert.Model.UpdateQueueRequest();
            
            if (cmdletContext.ConcurrentJob != null)
            {
                request.ConcurrentJobs = cmdletContext.ConcurrentJob.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ReservationPlanSettings
            var requestReservationPlanSettingsIsNull = true;
            request.ReservationPlanSettings = new Amazon.MediaConvert.Model.ReservationPlanSettings();
            Amazon.MediaConvert.Commitment requestReservationPlanSettings_reservationPlanSettings_Commitment = null;
            if (cmdletContext.ReservationPlanSettings_Commitment != null)
            {
                requestReservationPlanSettings_reservationPlanSettings_Commitment = cmdletContext.ReservationPlanSettings_Commitment;
            }
            if (requestReservationPlanSettings_reservationPlanSettings_Commitment != null)
            {
                request.ReservationPlanSettings.Commitment = requestReservationPlanSettings_reservationPlanSettings_Commitment;
                requestReservationPlanSettingsIsNull = false;
            }
            Amazon.MediaConvert.RenewalType requestReservationPlanSettings_reservationPlanSettings_RenewalType = null;
            if (cmdletContext.ReservationPlanSettings_RenewalType != null)
            {
                requestReservationPlanSettings_reservationPlanSettings_RenewalType = cmdletContext.ReservationPlanSettings_RenewalType;
            }
            if (requestReservationPlanSettings_reservationPlanSettings_RenewalType != null)
            {
                request.ReservationPlanSettings.RenewalType = requestReservationPlanSettings_reservationPlanSettings_RenewalType;
                requestReservationPlanSettingsIsNull = false;
            }
            System.Int32? requestReservationPlanSettings_reservationPlanSettings_ReservedSlot = null;
            if (cmdletContext.ReservationPlanSettings_ReservedSlot != null)
            {
                requestReservationPlanSettings_reservationPlanSettings_ReservedSlot = cmdletContext.ReservationPlanSettings_ReservedSlot.Value;
            }
            if (requestReservationPlanSettings_reservationPlanSettings_ReservedSlot != null)
            {
                request.ReservationPlanSettings.ReservedSlots = requestReservationPlanSettings_reservationPlanSettings_ReservedSlot.Value;
                requestReservationPlanSettingsIsNull = false;
            }
             // determine if request.ReservationPlanSettings should be set to null
            if (requestReservationPlanSettingsIsNull)
            {
                request.ReservationPlanSettings = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.MediaConvert.Model.UpdateQueueResponse CallAWSServiceOperation(IAmazonMediaConvert client, Amazon.MediaConvert.Model.UpdateQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConvert", "UpdateQueue");
            try
            {
                return client.UpdateQueueAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ConcurrentJob { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Amazon.MediaConvert.Commitment ReservationPlanSettings_Commitment { get; set; }
            public Amazon.MediaConvert.RenewalType ReservationPlanSettings_RenewalType { get; set; }
            public System.Int32? ReservationPlanSettings_ReservedSlot { get; set; }
            public Amazon.MediaConvert.QueueStatus Status { get; set; }
            public System.Func<Amazon.MediaConvert.Model.UpdateQueueResponse, UpdateEMCQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Queue;
        }
        
    }
}
