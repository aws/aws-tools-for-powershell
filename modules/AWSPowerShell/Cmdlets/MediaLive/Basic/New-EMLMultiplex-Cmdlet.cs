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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Create a new multiplex.
    /// </summary>
    [Cmdlet("New", "EMLMultiplex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.Multiplex")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive CreateMultiplex API operation.", Operation = new[] {"CreateMultiplex"}, SelectReturnType = typeof(Amazon.MediaLive.Model.CreateMultiplexResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Multiplex or Amazon.MediaLive.Model.CreateMultiplexResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.Multiplex object.",
        "The service call response (type Amazon.MediaLive.Model.CreateMultiplexResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEMLMultiplexCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// A list of availability zones for the
        /// multiplex. You must specify exactly two.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Name of multiplex.
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
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// Unique request ID. This prevents retries from
        /// creating multipleresources.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// A collection of key-value pairs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter MultiplexSettings_TransportStreamBitrate
        /// <summary>
        /// <para>
        /// Transport stream bit rate.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? MultiplexSettings_TransportStreamBitrate { get; set; }
        #endregion
        
        #region Parameter MultiplexSettings_TransportStreamId
        /// <summary>
        /// <para>
        /// Transport stream ID.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.CreateMultiplexResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.CreateMultiplexResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMLMultiplex (CreateMultiplex)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.CreateMultiplexResponse, NewEMLMultiplexCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZone = new List<System.String>(this.AvailabilityZone);
            }
            #if MODULAR
            if (this.AvailabilityZone == null && ParameterWasBound(nameof(this.AvailabilityZone)))
            {
                WriteWarning("You are passing $null as a value for parameter AvailabilityZone which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MultiplexSettings_MaximumVideoBufferDelayMillisecond = this.MultiplexSettings_MaximumVideoBufferDelayMillisecond;
            context.MultiplexSettings_TransportStreamBitrate = this.MultiplexSettings_TransportStreamBitrate;
            #if MODULAR
            if (this.MultiplexSettings_TransportStreamBitrate == null && ParameterWasBound(nameof(this.MultiplexSettings_TransportStreamBitrate)))
            {
                WriteWarning("You are passing $null as a value for parameter MultiplexSettings_TransportStreamBitrate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MultiplexSettings_TransportStreamId = this.MultiplexSettings_TransportStreamId;
            #if MODULAR
            if (this.MultiplexSettings_TransportStreamId == null && ParameterWasBound(nameof(this.MultiplexSettings_TransportStreamId)))
            {
                WriteWarning("You are passing $null as a value for parameter MultiplexSettings_TransportStreamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MultiplexSettings_TransportStreamReservedBitrate = this.MultiplexSettings_TransportStreamReservedBitrate;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RequestId = this.RequestId;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.MediaLive.Model.CreateMultiplexRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZone;
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
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
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
        
        private Amazon.MediaLive.Model.CreateMultiplexResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.CreateMultiplexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "CreateMultiplex");
            try
            {
                return client.CreateMultiplexAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AvailabilityZone { get; set; }
            public System.Int32? MultiplexSettings_MaximumVideoBufferDelayMillisecond { get; set; }
            public System.Int32? MultiplexSettings_TransportStreamBitrate { get; set; }
            public System.Int32? MultiplexSettings_TransportStreamId { get; set; }
            public System.Int32? MultiplexSettings_TransportStreamReservedBitrate { get; set; }
            public System.String Name { get; set; }
            public System.String RequestId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaLive.Model.CreateMultiplexResponse, NewEMLMultiplexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Multiplex;
        }
        
    }
}
