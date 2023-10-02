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
using Amazon.MediaConvert;
using Amazon.MediaConvert.Model;

namespace Amazon.PowerShell.Cmdlets.EMC
{
    /// <summary>
    /// Create a new transcoding queue. For information about queues, see Working With Queues
    /// in the User Guide at https://docs.aws.amazon.com/mediaconvert/latest/ug/working-with-queues.html
    /// </summary>
    [Cmdlet("New", "EMCQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConvert.Model.Queue")]
    [AWSCmdlet("Calls the AWS Elemental MediaConvert CreateQueue API operation.", Operation = new[] {"CreateQueue"}, SelectReturnType = typeof(Amazon.MediaConvert.Model.CreateQueueResponse))]
    [AWSCmdletOutput("Amazon.MediaConvert.Model.Queue or Amazon.MediaConvert.Model.CreateQueueResponse",
        "This cmdlet returns an Amazon.MediaConvert.Model.Queue object.",
        "The service call response (type Amazon.MediaConvert.Model.CreateQueueResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMCQueueCmdlet : AmazonMediaConvertClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// Optional. A description of the queue that
        /// you are creating.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the queue that you are creating.
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
        
        #region Parameter PricingPlan
        /// <summary>
        /// <para>
        /// Specifies whether the pricing plan for the
        /// queue is on-demand or reserved. For on-demand, you pay per minute, billed in increments
        /// of .01 minute. For reserved, you pay for the transcoding capacity of the entire queue,
        /// regardless of how much or how little you use it. Reserved pricing requires a 12-month
        /// commitment. When you use the API to create a queue, the default is on-demand.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConvert.PricingPlan")]
        public Amazon.MediaConvert.PricingPlan PricingPlan { get; set; }
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
        /// Initial state of the queue. If you create a paused
        /// queue, then jobs in that queue won't begin.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConvert.QueueStatus")]
        public Amazon.MediaConvert.QueueStatus Status { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The tags that you want to add to the resource. You
        /// can tag resources with a key-value pair or with only a key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Queue'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConvert.Model.CreateQueueResponse).
        /// Specifying the name of a property of type Amazon.MediaConvert.Model.CreateQueueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Queue";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMCQueue (CreateQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConvert.Model.CreateQueueResponse, NewEMCQueueCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PricingPlan = this.PricingPlan;
            context.ReservationPlanSettings_Commitment = this.ReservationPlanSettings_Commitment;
            context.ReservationPlanSettings_RenewalType = this.ReservationPlanSettings_RenewalType;
            context.ReservationPlanSettings_ReservedSlot = this.ReservationPlanSettings_ReservedSlot;
            context.Status = this.Status;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.MediaConvert.Model.CreateQueueRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PricingPlan != null)
            {
                request.PricingPlan = cmdletContext.PricingPlan;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.MediaConvert.Model.CreateQueueResponse CallAWSServiceOperation(IAmazonMediaConvert client, Amazon.MediaConvert.Model.CreateQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConvert", "CreateQueue");
            try
            {
                #if DESKTOP
                return client.CreateQueue(request);
                #elif CORECLR
                return client.CreateQueueAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public Amazon.MediaConvert.PricingPlan PricingPlan { get; set; }
            public Amazon.MediaConvert.Commitment ReservationPlanSettings_Commitment { get; set; }
            public Amazon.MediaConvert.RenewalType ReservationPlanSettings_RenewalType { get; set; }
            public System.Int32? ReservationPlanSettings_ReservedSlot { get; set; }
            public Amazon.MediaConvert.QueueStatus Status { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaConvert.Model.CreateQueueResponse, NewEMCQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Queue;
        }
        
    }
}
