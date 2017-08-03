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
    /// Updates a gateway's weekly maintenance start time information, including day and time
    /// of the week. The maintenance time is the time in your gateway's time zone.
    /// </summary>
    [Cmdlet("Update", "SGMaintenanceStartTime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateMaintenanceStartTime operation against AWS Storage Gateway.", Operation = new[] {"UpdateMaintenanceStartTime"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSGMaintenanceStartTimeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter DayOfWeek
        /// <summary>
        /// <para>
        /// <para>The maintenance start time day of the week represented as an ordinal number from 0
        /// to 6, where 0 represents Sunday and 6 Saturday.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.Int32 DayOfWeek { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter HourOfDay
        /// <summary>
        /// <para>
        /// <para>The hour component of the maintenance start time represented as <i>hh</i>, where <i>hh</i>
        /// is the hour (00 to 23). The hour of the day is in the time zone of the gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 HourOfDay { get; set; }
        #endregion
        
        #region Parameter MinuteOfHour
        /// <summary>
        /// <para>
        /// <para>The minute component of the maintenance start time represented as <i>mm</i>, where
        /// <i>mm</i> is the minute (00 to 59). The minute of the hour is in the time zone of
        /// the gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.Int32 MinuteOfHour { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GatewayARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGMaintenanceStartTime (UpdateMaintenanceStartTime)"))
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
            
            if (ParameterWasBound("DayOfWeek"))
                context.DayOfWeek = this.DayOfWeek;
            context.GatewayARN = this.GatewayARN;
            if (ParameterWasBound("HourOfDay"))
                context.HourOfDay = this.HourOfDay;
            if (ParameterWasBound("MinuteOfHour"))
                context.MinuteOfHour = this.MinuteOfHour;
            
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
            var request = new Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeRequest();
            
            if (cmdletContext.DayOfWeek != null)
            {
                request.DayOfWeek = cmdletContext.DayOfWeek.Value;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.HourOfDay != null)
            {
                request.HourOfDay = cmdletContext.HourOfDay.Value;
            }
            if (cmdletContext.MinuteOfHour != null)
            {
                request.MinuteOfHour = cmdletContext.MinuteOfHour.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GatewayARN;
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
        
        private Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.UpdateMaintenanceStartTimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "UpdateMaintenanceStartTime");
            #if DESKTOP
            return client.UpdateMaintenanceStartTime(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateMaintenanceStartTimeAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Int32? DayOfWeek { get; set; }
            public System.String GatewayARN { get; set; }
            public System.Int32? HourOfDay { get; set; }
            public System.Int32? MinuteOfHour { get; set; }
        }
        
    }
}
