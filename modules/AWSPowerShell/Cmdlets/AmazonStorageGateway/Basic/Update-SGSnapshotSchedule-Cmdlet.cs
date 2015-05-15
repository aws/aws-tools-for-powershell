/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// This operation updates a snapshot schedule configured for a gateway volume.
    /// 
    ///  
    /// <para>
    /// The default snapshot schedule for volume is once every 24 hours, starting at the creation
    /// time of the volume. You can use this API to change the snapshot schedule configured
    /// for the volume.
    /// </para><para>
    /// In the request you must identify the gateway volume whose snapshot schedule you want
    /// to update, and the schedule information, including when you want the snapshot to begin
    /// on a day and the frequency (in hours) of snapshots.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SGSnapshotSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateSnapshotSchedule operation against AWS Storage Gateway.", Operation = new[] {"UpdateSnapshotSchedule"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type UpdateSnapshotScheduleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateSGSnapshotScheduleCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Optional description of the snapshot that overwrites the existing description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Frequency of snapshots. Specify the number of hours between snapshots.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public Int32 RecurrenceInHours { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The hour of the day at which the snapshot schedule begins represented as <i>hh</i>,
        /// where <i>hh</i> is the hour (0 to 23). The hour of the day is in the time zone of
        /// the gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public Int32 StartAt { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the volume. Use the <a>ListVolumes</a> operation
        /// to return a list of gateway volumes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String VolumeARN { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VolumeARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGSnapshotSchedule (UpdateSnapshotSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Description = this.Description;
            if (ParameterWasBound("RecurrenceInHours"))
                context.RecurrenceInHours = this.RecurrenceInHours;
            if (ParameterWasBound("StartAt"))
                context.StartAt = this.StartAt;
            context.VolumeARN = this.VolumeARN;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateSnapshotScheduleRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.RecurrenceInHours != null)
            {
                request.RecurrenceInHours = cmdletContext.RecurrenceInHours.Value;
            }
            if (cmdletContext.StartAt != null)
            {
                request.StartAt = cmdletContext.StartAt.Value;
            }
            if (cmdletContext.VolumeARN != null)
            {
                request.VolumeARN = cmdletContext.VolumeARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateSnapshotSchedule(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VolumeARN;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String Description { get; set; }
            public Int32? RecurrenceInHours { get; set; }
            public Int32? StartAt { get; set; }
            public String VolumeARN { get; set; }
        }
        
    }
}
