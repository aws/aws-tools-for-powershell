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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Updates the network profile.
    /// </summary>
    [Cmdlet("Update", "DFNetworkProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DeviceFarm.Model.NetworkProfile")]
    [AWSCmdlet("Calls the AWS Device Farm UpdateNetworkProfile API operation.", Operation = new[] {"UpdateNetworkProfile"}, SelectReturnType = typeof(Amazon.DeviceFarm.Model.UpdateNetworkProfileResponse))]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.NetworkProfile or Amazon.DeviceFarm.Model.UpdateNetworkProfileResponse",
        "This cmdlet returns an Amazon.DeviceFarm.Model.NetworkProfile object.",
        "The service call response (type Amazon.DeviceFarm.Model.UpdateNetworkProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateDFNetworkProfileCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the project for which you want to update network
        /// profile settings.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the network profile about which you are returning information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DownlinkBandwidthBit
        /// <summary>
        /// <para>
        /// <para>The data throughput rate in bits per second, as an integer from 0 to 104857600.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DownlinkBandwidthBits")]
        public System.Int64? DownlinkBandwidthBit { get; set; }
        #endregion
        
        #region Parameter DownlinkDelayMs
        /// <summary>
        /// <para>
        /// <para>Delay time for all packets to destination in milliseconds as an integer from 0 to
        /// 2000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? DownlinkDelayMs { get; set; }
        #endregion
        
        #region Parameter DownlinkJitterMs
        /// <summary>
        /// <para>
        /// <para>Time variation in the delay of received packets in milliseconds as an integer from
        /// 0 to 2000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? DownlinkJitterMs { get; set; }
        #endregion
        
        #region Parameter DownlinkLossPercent
        /// <summary>
        /// <para>
        /// <para>Proportion of received packets that fail to arrive from 0 to 100 percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DownlinkLossPercent { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the network profile about which you are returning information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of network profile to return information about. Valid values are listed here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DeviceFarm.NetworkProfileType")]
        public Amazon.DeviceFarm.NetworkProfileType Type { get; set; }
        #endregion
        
        #region Parameter UplinkBandwidthBit
        /// <summary>
        /// <para>
        /// <para>The data throughput rate in bits per second, as an integer from 0 to 104857600.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UplinkBandwidthBits")]
        public System.Int64? UplinkBandwidthBit { get; set; }
        #endregion
        
        #region Parameter UplinkDelayMs
        /// <summary>
        /// <para>
        /// <para>Delay time for all packets to destination in milliseconds as an integer from 0 to
        /// 2000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? UplinkDelayMs { get; set; }
        #endregion
        
        #region Parameter UplinkJitterMs
        /// <summary>
        /// <para>
        /// <para>Time variation in the delay of received packets in milliseconds as an integer from
        /// 0 to 2000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? UplinkJitterMs { get; set; }
        #endregion
        
        #region Parameter UplinkLossPercent
        /// <summary>
        /// <para>
        /// <para>Proportion of transmitted packets that fail to arrive from 0 to 100 percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UplinkLossPercent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DeviceFarm.Model.UpdateNetworkProfileResponse).
        /// Specifying the name of a property of type Amazon.DeviceFarm.Model.UpdateNetworkProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkProfile";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DFNetworkProfile (UpdateNetworkProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DeviceFarm.Model.UpdateNetworkProfileResponse, UpdateDFNetworkProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.DownlinkBandwidthBit = this.DownlinkBandwidthBit;
            context.DownlinkDelayMs = this.DownlinkDelayMs;
            context.DownlinkJitterMs = this.DownlinkJitterMs;
            context.DownlinkLossPercent = this.DownlinkLossPercent;
            context.Name = this.Name;
            context.Type = this.Type;
            context.UplinkBandwidthBit = this.UplinkBandwidthBit;
            context.UplinkDelayMs = this.UplinkDelayMs;
            context.UplinkJitterMs = this.UplinkJitterMs;
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
            var request = new Amazon.DeviceFarm.Model.UpdateNetworkProfileRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DownlinkBandwidthBit != null)
            {
                request.DownlinkBandwidthBits = cmdletContext.DownlinkBandwidthBit.Value;
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
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.UplinkBandwidthBit != null)
            {
                request.UplinkBandwidthBits = cmdletContext.UplinkBandwidthBit.Value;
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
        
        private Amazon.DeviceFarm.Model.UpdateNetworkProfileResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.UpdateNetworkProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "UpdateNetworkProfile");
            try
            {
                return client.UpdateNetworkProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String Description { get; set; }
            public System.Int64? DownlinkBandwidthBit { get; set; }
            public System.Int64? DownlinkDelayMs { get; set; }
            public System.Int64? DownlinkJitterMs { get; set; }
            public System.Int32? DownlinkLossPercent { get; set; }
            public System.String Name { get; set; }
            public Amazon.DeviceFarm.NetworkProfileType Type { get; set; }
            public System.Int64? UplinkBandwidthBit { get; set; }
            public System.Int64? UplinkDelayMs { get; set; }
            public System.Int64? UplinkJitterMs { get; set; }
            public System.Int32? UplinkLossPercent { get; set; }
            public System.Func<Amazon.DeviceFarm.Model.UpdateNetworkProfileResponse, UpdateDFNetworkProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkProfile;
        }
        
    }
}
