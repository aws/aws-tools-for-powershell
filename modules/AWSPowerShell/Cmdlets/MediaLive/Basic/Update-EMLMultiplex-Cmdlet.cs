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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Updates a multiplex.
    /// </summary>
    [Cmdlet("Update", "EMLMultiplex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.Multiplex")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive UpdateMultiplex API operation.", Operation = new[] {"UpdateMultiplex"}, SelectReturnType = typeof(Amazon.MediaLive.Model.UpdateMultiplexResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Multiplex or Amazon.MediaLive.Model.UpdateMultiplexResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.Multiplex object.",
        "The service call response (type Amazon.MediaLive.Model.UpdateMultiplexResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEMLMultiplexCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MultiplexSettings_MaximumVideoBufferDelayMillisecond
        /// <summary>
        /// <para>
        /// Maximum video buffer
        /// delay in milliseconds.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiplexSettings_MaximumVideoBufferDelayMilliseconds")]
        public System.Int32? MultiplexSettings_MaximumVideoBufferDelayMillisecond { get; set; }
        #endregion
        
        #region Parameter MultiplexId
        /// <summary>
        /// <para>
        /// ID of the multiplex to update.
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
        public System.String MultiplexId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Name of the multiplex.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PacketIdentifiersMapping
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable PacketIdentifiersMapping { get; set; }
        #endregion
        
        #region Parameter MultiplexSettings_TransportStreamBitrate
        /// <summary>
        /// <para>
        /// Transport stream bit rate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MultiplexSettings_TransportStreamBitrate { get; set; }
        #endregion
        
        #region Parameter MultiplexSettings_TransportStreamId
        /// <summary>
        /// <para>
        /// Transport stream ID.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MultiplexSettings_TransportStreamId { get; set; }
        #endregion
        
        #region Parameter MultiplexSettings_TransportStreamReservedBitrate
        /// <summary>
        /// <para>
        /// Transport stream reserved
        /// bit rate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MultiplexSettings_TransportStreamReservedBitrate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Multiplex'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.UpdateMultiplexResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.UpdateMultiplexResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Multiplex";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MultiplexId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMLMultiplex (UpdateMultiplex)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.UpdateMultiplexResponse, UpdateEMLMultiplexCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MultiplexId = this.MultiplexId;
            #if MODULAR
            if (this.MultiplexId == null && ParameterWasBound(nameof(this.MultiplexId)))
            {
                WriteWarning("You are passing $null as a value for parameter MultiplexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MultiplexSettings_MaximumVideoBufferDelayMillisecond = this.MultiplexSettings_MaximumVideoBufferDelayMillisecond;
            context.MultiplexSettings_TransportStreamBitrate = this.MultiplexSettings_TransportStreamBitrate;
            context.MultiplexSettings_TransportStreamId = this.MultiplexSettings_TransportStreamId;
            context.MultiplexSettings_TransportStreamReservedBitrate = this.MultiplexSettings_TransportStreamReservedBitrate;
            context.Name = this.Name;
            if (this.PacketIdentifiersMapping != null)
            {
                context.PacketIdentifiersMapping = new Dictionary<System.String, Amazon.MediaLive.Model.MultiplexProgramPacketIdentifiersMap>(StringComparer.Ordinal);
                foreach (var hashKey in this.PacketIdentifiersMapping.Keys)
                {
                    context.PacketIdentifiersMapping.Add((String)hashKey, (Amazon.MediaLive.Model.MultiplexProgramPacketIdentifiersMap)(this.PacketIdentifiersMapping[hashKey]));
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
            var request = new Amazon.MediaLive.Model.UpdateMultiplexRequest();
            
            if (cmdletContext.MultiplexId != null)
            {
                request.MultiplexId = cmdletContext.MultiplexId;
            }
            
             // populate MultiplexSettings
            var requestMultiplexSettingsIsNull = true;
            request.MultiplexSettings = new Amazon.MediaLive.Model.MultiplexSettings();
            System.Int32? requestMultiplexSettings_multiplexSettings_MaximumVideoBufferDelayMillisecond = null;
            if (cmdletContext.MultiplexSettings_MaximumVideoBufferDelayMillisecond != null)
            {
                requestMultiplexSettings_multiplexSettings_MaximumVideoBufferDelayMillisecond = cmdletContext.MultiplexSettings_MaximumVideoBufferDelayMillisecond.Value;
            }
            if (requestMultiplexSettings_multiplexSettings_MaximumVideoBufferDelayMillisecond != null)
            {
                request.MultiplexSettings.MaximumVideoBufferDelayMilliseconds = requestMultiplexSettings_multiplexSettings_MaximumVideoBufferDelayMillisecond.Value;
                requestMultiplexSettingsIsNull = false;
            }
            System.Int32? requestMultiplexSettings_multiplexSettings_TransportStreamBitrate = null;
            if (cmdletContext.MultiplexSettings_TransportStreamBitrate != null)
            {
                requestMultiplexSettings_multiplexSettings_TransportStreamBitrate = cmdletContext.MultiplexSettings_TransportStreamBitrate.Value;
            }
            if (requestMultiplexSettings_multiplexSettings_TransportStreamBitrate != null)
            {
                request.MultiplexSettings.TransportStreamBitrate = requestMultiplexSettings_multiplexSettings_TransportStreamBitrate.Value;
                requestMultiplexSettingsIsNull = false;
            }
            System.Int32? requestMultiplexSettings_multiplexSettings_TransportStreamId = null;
            if (cmdletContext.MultiplexSettings_TransportStreamId != null)
            {
                requestMultiplexSettings_multiplexSettings_TransportStreamId = cmdletContext.MultiplexSettings_TransportStreamId.Value;
            }
            if (requestMultiplexSettings_multiplexSettings_TransportStreamId != null)
            {
                request.MultiplexSettings.TransportStreamId = requestMultiplexSettings_multiplexSettings_TransportStreamId.Value;
                requestMultiplexSettingsIsNull = false;
            }
            System.Int32? requestMultiplexSettings_multiplexSettings_TransportStreamReservedBitrate = null;
            if (cmdletContext.MultiplexSettings_TransportStreamReservedBitrate != null)
            {
                requestMultiplexSettings_multiplexSettings_TransportStreamReservedBitrate = cmdletContext.MultiplexSettings_TransportStreamReservedBitrate.Value;
            }
            if (requestMultiplexSettings_multiplexSettings_TransportStreamReservedBitrate != null)
            {
                request.MultiplexSettings.TransportStreamReservedBitrate = requestMultiplexSettings_multiplexSettings_TransportStreamReservedBitrate.Value;
                requestMultiplexSettingsIsNull = false;
            }
             // determine if request.MultiplexSettings should be set to null
            if (requestMultiplexSettingsIsNull)
            {
                request.MultiplexSettings = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PacketIdentifiersMapping != null)
            {
                request.PacketIdentifiersMapping = cmdletContext.PacketIdentifiersMapping;
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
        
        private Amazon.MediaLive.Model.UpdateMultiplexResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.UpdateMultiplexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "UpdateMultiplex");
            try
            {
                #if DESKTOP
                return client.UpdateMultiplex(request);
                #elif CORECLR
                return client.UpdateMultiplexAsync(request).GetAwaiter().GetResult();
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
            public System.String MultiplexId { get; set; }
            public System.Int32? MultiplexSettings_MaximumVideoBufferDelayMillisecond { get; set; }
            public System.Int32? MultiplexSettings_TransportStreamBitrate { get; set; }
            public System.Int32? MultiplexSettings_TransportStreamId { get; set; }
            public System.Int32? MultiplexSettings_TransportStreamReservedBitrate { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, Amazon.MediaLive.Model.MultiplexProgramPacketIdentifiersMap> PacketIdentifiersMapping { get; set; }
            public System.Func<Amazon.MediaLive.Model.UpdateMultiplexResponse, UpdateEMLMultiplexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Multiplex;
        }
        
    }
}
