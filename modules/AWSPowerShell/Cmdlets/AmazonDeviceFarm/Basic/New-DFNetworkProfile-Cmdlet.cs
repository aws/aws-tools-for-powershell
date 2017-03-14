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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Creates a network profile.
    /// </summary>
    [Cmdlet("New", "DFNetworkProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DeviceFarm.Model.NetworkProfile")]
    [AWSCmdlet("Invokes the CreateNetworkProfile operation against AWS Device Farm.", Operation = new[] {"CreateNetworkProfile"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.NetworkProfile",
        "This cmdlet returns a NetworkProfile object.",
        "The service call response (type Amazon.DeviceFarm.Model.CreateNetworkProfileResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDFNetworkProfileCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the network profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DownlinkBandwidthBit
        /// <summary>
        /// <para>
        /// <para>The data throughput rate in bits per second, as an integer from 0 to 104857600.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DownlinkBandwidthBits")]
        public System.Int64 DownlinkBandwidthBit { get; set; }
        #endregion
        
        #region Parameter DownlinkDelayMs
        /// <summary>
        /// <para>
        /// <para>Delay time for all packets to destination in milliseconds as an integer from 0 to
        /// 2000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 DownlinkDelayMs { get; set; }
        #endregion
        
        #region Parameter DownlinkJitterMs
        /// <summary>
        /// <para>
        /// <para>Time variation in the delay of received packets in milliseconds as an integer from
        /// 0 to 2000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 DownlinkJitterMs { get; set; }
        #endregion
        
        #region Parameter DownlinkLossPercent
        /// <summary>
        /// <para>
        /// <para>Proportion of received packets that fail to arrive from 0 to 100 percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DownlinkLossPercent { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name you wish to specify for the new network profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the project for which you want to create a network
        /// profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of network profile you wish to create. Valid values are listed below.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DeviceFarm.NetworkProfileType")]
        public Amazon.DeviceFarm.NetworkProfileType Type { get; set; }
        #endregion
        
        #region Parameter UplinkBandwidthBit
        /// <summary>
        /// <para>
        /// <para>The data throughput rate in bits per second, as an integer from 0 to 104857600.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UplinkBandwidthBits")]
        public System.Int64 UplinkBandwidthBit { get; set; }
        #endregion
        
        #region Parameter UplinkDelayMs
        /// <summary>
        /// <para>
        /// <para>Delay time for all packets to destination in milliseconds as an integer from 0 to
        /// 2000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 UplinkDelayMs { get; set; }
        #endregion
        
        #region Parameter UplinkJitterMs
        /// <summary>
        /// <para>
        /// <para>Time variation in the delay of received packets in milliseconds as an integer from
        /// 0 to 2000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 UplinkJitterMs { get; set; }
        #endregion
        
        #region Parameter UplinkLossPercent
        /// <summary>
        /// <para>
        /// <para>Proportion of transmitted packets that fail to arrive from 0 to 100 percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 UplinkLossPercent { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DFNetworkProfile (CreateNetworkProfile)"))
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
            if (ParameterWasBound("DownlinkBandwidthBit"))
                context.DownlinkBandwidthBits = this.DownlinkBandwidthBit;
            if (ParameterWasBound("DownlinkDelayMs"))
                context.DownlinkDelayMs = this.DownlinkDelayMs;
            if (ParameterWasBound("DownlinkJitterMs"))
                context.DownlinkJitterMs = this.DownlinkJitterMs;
            if (ParameterWasBound("DownlinkLossPercent"))
                context.DownlinkLossPercent = this.DownlinkLossPercent;
            context.Name = this.Name;
            context.ProjectArn = this.ProjectArn;
            context.Type = this.Type;
            if (ParameterWasBound("UplinkBandwidthBit"))
                context.UplinkBandwidthBits = this.UplinkBandwidthBit;
            if (ParameterWasBound("UplinkDelayMs"))
                context.UplinkDelayMs = this.UplinkDelayMs;
            if (ParameterWasBound("UplinkJitterMs"))
                context.UplinkJitterMs = this.UplinkJitterMs;
            if (ParameterWasBound("UplinkLossPercent"))
                context.UplinkLossPercent = this.UplinkLossPercent;
            
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
            var request = new Amazon.DeviceFarm.Model.CreateNetworkProfileRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DownlinkBandwidthBits != null)
            {
                request.DownlinkBandwidthBits = cmdletContext.DownlinkBandwidthBits.Value;
            }
            if (cmdletContext.DownlinkDelayMs != null)
            {
                request.DownlinkDelayMs = cmdletContext.DownlinkDelayMs.Value;
            }
            if (cmdletContext.DownlinkJitterMs != null)
            {
                request.DownlinkJitterMs = cmdletContext.DownlinkJitterMs.Value;
            }
            if (cmdletContext.DownlinkLossPercent != null)
            {
                request.DownlinkLossPercent = cmdletContext.DownlinkLossPercent.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.UplinkBandwidthBits != null)
            {
                request.UplinkBandwidthBits = cmdletContext.UplinkBandwidthBits.Value;
            }
            if (cmdletContext.UplinkDelayMs != null)
            {
                request.UplinkDelayMs = cmdletContext.UplinkDelayMs.Value;
            }
            if (cmdletContext.UplinkJitterMs != null)
            {
                request.UplinkJitterMs = cmdletContext.UplinkJitterMs.Value;
            }
            if (cmdletContext.UplinkLossPercent != null)
            {
                request.UplinkLossPercent = cmdletContext.UplinkLossPercent.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.NetworkProfile;
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
        
        private static Amazon.DeviceFarm.Model.CreateNetworkProfileResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.CreateNetworkProfileRequest request)
        {
            #if DESKTOP
            return client.CreateNetworkProfile(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateNetworkProfileAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Description { get; set; }
            public System.Int64? DownlinkBandwidthBits { get; set; }
            public System.Int64? DownlinkDelayMs { get; set; }
            public System.Int64? DownlinkJitterMs { get; set; }
            public System.Int32? DownlinkLossPercent { get; set; }
            public System.String Name { get; set; }
            public System.String ProjectArn { get; set; }
            public Amazon.DeviceFarm.NetworkProfileType Type { get; set; }
            public System.Int64? UplinkBandwidthBits { get; set; }
            public System.Int64? UplinkDelayMs { get; set; }
            public System.Int64? UplinkJitterMs { get; set; }
            public System.Int32? UplinkLossPercent { get; set; }
        }
        
    }
}
