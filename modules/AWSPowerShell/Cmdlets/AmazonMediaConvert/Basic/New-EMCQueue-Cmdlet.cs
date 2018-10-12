/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Create a new transcoding queue. For information about job templates see the User Guide
    /// at http://docs.aws.amazon.com/mediaconvert/latest/ug/what-is.html
    /// </summary>
    [Cmdlet("New", "EMCQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConvert.Model.Queue")]
    [AWSCmdlet("Calls the AWS Elemental MediaConvert CreateQueue API operation.", Operation = new[] {"CreateQueue"})]
    [AWSCmdletOutput("Amazon.MediaConvert.Model.Queue",
        "This cmdlet returns a Queue object.",
        "The service call response (type Amazon.MediaConvert.Model.CreateQueueResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMCQueueCmdlet : AmazonMediaConvertClientCmdlet, IExecutor
    {
        
        #region Parameter ReservationPlanSettings_Commitment
        /// <summary>
        /// <para>
        /// The length of time that you commit to when
        /// you set up a pricing plan contract for a reserved queue.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the queue that you are creating.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PricingPlan
        /// <summary>
        /// <para>
        /// Optional; default is on-demand. Specifies
        /// whether the pricing plan for the queue is on-demand or reserved. The pricing plan
        /// for the queue determines whether you pay on-demand or reserved pricing for the transcoding
        /// jobs you run through the queue. For reserved queue pricing, you must set up a contract.
        /// You can create a reserved queue contract through the AWS Elemental MediaConvert console.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MediaConvert.PricingPlan")]
        public Amazon.MediaConvert.PricingPlan PricingPlan { get; set; }
        #endregion
        
        #region Parameter ReservationPlanSettings_RenewalType
        /// <summary>
        /// <para>
        /// Specifies whether the pricing plan contract
        /// for your reserved queue automatically renews (AUTO_RENEW) or expires (EXPIRE) at the
        /// end of the contract period.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MediaConvert.RenewalType")]
        public Amazon.MediaConvert.RenewalType ReservationPlanSettings_RenewalType { get; set; }
        #endregion
        
        #region Parameter ReservationPlanSettings_ReservedSlot
        /// <summary>
        /// <para>
        /// Specifies the number of reserved transcode
        /// slots (RTSs) for this queue. The number of RTS determines how many jobs the queue
        /// can process in parallel; each RTS can process one job at a time. To increase this
        /// number, create a replacement contract through the AWS Elemental MediaConvert console.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReservationPlanSettings_ReservedSlots")]
        public System.Int32 ReservationPlanSettings_ReservedSlot { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The tags that you want to add to the resource. You
        /// can tag resources with a key-value pair or with only a key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMCQueue (CreateQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Description = this.Description;
            context.Name = this.Name;
            context.PricingPlan = this.PricingPlan;
            context.ReservationPlanSettings_Commitment = this.ReservationPlanSettings_Commitment;
            context.ReservationPlanSettings_RenewalType = this.ReservationPlanSettings_RenewalType;
            if (ParameterWasBound("ReservationPlanSettings_ReservedSlot"))
                context.ReservationPlanSettings_ReservedSlots = this.ReservationPlanSettings_ReservedSlot;
            if (this.Tag != null)
            {
                context.Tags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tags.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            bool requestReservationPlanSettingsIsNull = true;
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
            if (cmdletContext.ReservationPlanSettings_ReservedSlots != null)
            {
                requestReservationPlanSettings_reservationPlanSettings_ReservedSlot = cmdletContext.ReservationPlanSettings_ReservedSlots.Value;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Queue;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateQueueAsync(request);
                return task.Result;
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
            public System.Int32? ReservationPlanSettings_ReservedSlots { get; set; }
            public Dictionary<System.String, System.String> Tags { get; set; }
        }
        
    }
}
