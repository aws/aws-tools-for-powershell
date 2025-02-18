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

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Create a new program in the multiplex.
    /// </summary>
    [Cmdlet("New", "EMLMultiplexProgram", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.MultiplexProgram")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive CreateMultiplexProgram API operation.", Operation = new[] {"CreateMultiplexProgram"}, SelectReturnType = typeof(Amazon.MediaLive.Model.CreateMultiplexProgramResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.MultiplexProgram or Amazon.MediaLive.Model.CreateMultiplexProgramResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.MultiplexProgram object.",
        "The service call response (type Amazon.MediaLive.Model.CreateMultiplexProgramResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEMLMultiplexProgramCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter VideoSettings_ConstantBitrate
        /// <summary>
        /// <para>
        /// The constant bitrate configuration for
        /// the video encode.When this field is defined, StatmuxSettings must be undefined.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiplexProgramSettings_VideoSettings_ConstantBitrate")]
        public System.Int32? VideoSettings_ConstantBitrate { get; set; }
        #endregion
        
        #region Parameter StatmuxSettings_MaximumBitrate
        /// <summary>
        /// <para>
        /// Maximum statmux bitrate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiplexProgramSettings_VideoSettings_StatmuxSettings_MaximumBitrate")]
        public System.Int32? StatmuxSettings_MaximumBitrate { get; set; }
        #endregion
        
        #region Parameter StatmuxSettings_MinimumBitrate
        /// <summary>
        /// <para>
        /// Minimum statmux bitrate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiplexProgramSettings_VideoSettings_StatmuxSettings_MinimumBitrate")]
        public System.Int32? StatmuxSettings_MinimumBitrate { get; set; }
        #endregion
        
        #region Parameter MultiplexId
        /// <summary>
        /// <para>
        /// ID of the multiplex where the program is to
        /// be created.
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
        public System.String MultiplexId { get; set; }
        #endregion
        
        #region Parameter MultiplexProgramSettings_PreferredChannelPipeline
        /// <summary>
        /// <para>
        /// Indicates which pipeline is preferred
        /// by the multiplex for program ingest.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.PreferredChannelPipeline")]
        public Amazon.MediaLive.PreferredChannelPipeline MultiplexProgramSettings_PreferredChannelPipeline { get; set; }
        #endregion
        
        #region Parameter StatmuxSettings_Priority
        /// <summary>
        /// <para>
        /// The purpose of the priority is to use a combination
        /// of the\nmultiplex rate control algorithm and the QVBR capability of the\nencoder to
        /// prioritize the video quality of some channels in a\nmultiplex over others. Channels
        /// that have a higher priority will\nget higher video quality at the expense of the video
        /// quality of\nother channels in the multiplex with lower priority.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiplexProgramSettings_VideoSettings_StatmuxSettings_Priority")]
        public System.Int32? StatmuxSettings_Priority { get; set; }
        #endregion
        
        #region Parameter ProgramName
        /// <summary>
        /// <para>
        /// Name of multiplex program.
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
        public System.String ProgramName { get; set; }
        #endregion
        
        #region Parameter MultiplexProgramSettings_ProgramNumber
        /// <summary>
        /// <para>
        /// Unique program number.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? MultiplexProgramSettings_ProgramNumber { get; set; }
        #endregion
        
        #region Parameter ServiceDescriptor_ProviderName
        /// <summary>
        /// <para>
        /// Name of the provider.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiplexProgramSettings_ServiceDescriptor_ProviderName")]
        public System.String ServiceDescriptor_ProviderName { get; set; }
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
        
        #region Parameter ServiceDescriptor_ServiceName
        /// <summary>
        /// <para>
        /// Name of the service.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiplexProgramSettings_ServiceDescriptor_ServiceName")]
        public System.String ServiceDescriptor_ServiceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MultiplexProgram'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.CreateMultiplexProgramResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.CreateMultiplexProgramResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MultiplexProgram";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProgramName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMLMultiplexProgram (CreateMultiplexProgram)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.CreateMultiplexProgramResponse, NewEMLMultiplexProgramCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MultiplexId = this.MultiplexId;
            #if MODULAR
            if (this.MultiplexId == null && ParameterWasBound(nameof(this.MultiplexId)))
            {
                WriteWarning("You are passing $null as a value for parameter MultiplexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MultiplexProgramSettings_PreferredChannelPipeline = this.MultiplexProgramSettings_PreferredChannelPipeline;
            context.MultiplexProgramSettings_ProgramNumber = this.MultiplexProgramSettings_ProgramNumber;
            #if MODULAR
            if (this.MultiplexProgramSettings_ProgramNumber == null && ParameterWasBound(nameof(this.MultiplexProgramSettings_ProgramNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter MultiplexProgramSettings_ProgramNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceDescriptor_ProviderName = this.ServiceDescriptor_ProviderName;
            context.ServiceDescriptor_ServiceName = this.ServiceDescriptor_ServiceName;
            context.VideoSettings_ConstantBitrate = this.VideoSettings_ConstantBitrate;
            context.StatmuxSettings_MaximumBitrate = this.StatmuxSettings_MaximumBitrate;
            context.StatmuxSettings_MinimumBitrate = this.StatmuxSettings_MinimumBitrate;
            context.StatmuxSettings_Priority = this.StatmuxSettings_Priority;
            context.ProgramName = this.ProgramName;
            #if MODULAR
            if (this.ProgramName == null && ParameterWasBound(nameof(this.ProgramName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProgramName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RequestId = this.RequestId;
            
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
            var request = new Amazon.MediaLive.Model.CreateMultiplexProgramRequest();
            
            if (cmdletContext.MultiplexId != null)
            {
                request.MultiplexId = cmdletContext.MultiplexId;
            }
            
             // populate MultiplexProgramSettings
            var requestMultiplexProgramSettingsIsNull = true;
            request.MultiplexProgramSettings = new Amazon.MediaLive.Model.MultiplexProgramSettings();
            Amazon.MediaLive.PreferredChannelPipeline requestMultiplexProgramSettings_multiplexProgramSettings_PreferredChannelPipeline = null;
            if (cmdletContext.MultiplexProgramSettings_PreferredChannelPipeline != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_PreferredChannelPipeline = cmdletContext.MultiplexProgramSettings_PreferredChannelPipeline;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_PreferredChannelPipeline != null)
            {
                request.MultiplexProgramSettings.PreferredChannelPipeline = requestMultiplexProgramSettings_multiplexProgramSettings_PreferredChannelPipeline;
                requestMultiplexProgramSettingsIsNull = false;
            }
            System.Int32? requestMultiplexProgramSettings_multiplexProgramSettings_ProgramNumber = null;
            if (cmdletContext.MultiplexProgramSettings_ProgramNumber != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_ProgramNumber = cmdletContext.MultiplexProgramSettings_ProgramNumber.Value;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_ProgramNumber != null)
            {
                request.MultiplexProgramSettings.ProgramNumber = requestMultiplexProgramSettings_multiplexProgramSettings_ProgramNumber.Value;
                requestMultiplexProgramSettingsIsNull = false;
            }
            Amazon.MediaLive.Model.MultiplexProgramServiceDescriptor requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor = null;
            
             // populate ServiceDescriptor
            var requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptorIsNull = true;
            requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor = new Amazon.MediaLive.Model.MultiplexProgramServiceDescriptor();
            System.String requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor_serviceDescriptor_ProviderName = null;
            if (cmdletContext.ServiceDescriptor_ProviderName != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor_serviceDescriptor_ProviderName = cmdletContext.ServiceDescriptor_ProviderName;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor_serviceDescriptor_ProviderName != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor.ProviderName = requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor_serviceDescriptor_ProviderName;
                requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptorIsNull = false;
            }
            System.String requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor_serviceDescriptor_ServiceName = null;
            if (cmdletContext.ServiceDescriptor_ServiceName != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor_serviceDescriptor_ServiceName = cmdletContext.ServiceDescriptor_ServiceName;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor_serviceDescriptor_ServiceName != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor.ServiceName = requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor_serviceDescriptor_ServiceName;
                requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptorIsNull = false;
            }
             // determine if requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor should be set to null
            if (requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptorIsNull)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor = null;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor != null)
            {
                request.MultiplexProgramSettings.ServiceDescriptor = requestMultiplexProgramSettings_multiplexProgramSettings_ServiceDescriptor;
                requestMultiplexProgramSettingsIsNull = false;
            }
            Amazon.MediaLive.Model.MultiplexVideoSettings requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings = null;
            
             // populate VideoSettings
            var requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettingsIsNull = true;
            requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings = new Amazon.MediaLive.Model.MultiplexVideoSettings();
            System.Int32? requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_videoSettings_ConstantBitrate = null;
            if (cmdletContext.VideoSettings_ConstantBitrate != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_videoSettings_ConstantBitrate = cmdletContext.VideoSettings_ConstantBitrate.Value;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_videoSettings_ConstantBitrate != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings.ConstantBitrate = requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_videoSettings_ConstantBitrate.Value;
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettingsIsNull = false;
            }
            Amazon.MediaLive.Model.MultiplexStatmuxVideoSettings requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings = null;
            
             // populate StatmuxSettings
            var requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettingsIsNull = true;
            requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings = new Amazon.MediaLive.Model.MultiplexStatmuxVideoSettings();
            System.Int32? requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_MaximumBitrate = null;
            if (cmdletContext.StatmuxSettings_MaximumBitrate != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_MaximumBitrate = cmdletContext.StatmuxSettings_MaximumBitrate.Value;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_MaximumBitrate != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings.MaximumBitrate = requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_MaximumBitrate.Value;
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettingsIsNull = false;
            }
            System.Int32? requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_MinimumBitrate = null;
            if (cmdletContext.StatmuxSettings_MinimumBitrate != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_MinimumBitrate = cmdletContext.StatmuxSettings_MinimumBitrate.Value;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_MinimumBitrate != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings.MinimumBitrate = requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_MinimumBitrate.Value;
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettingsIsNull = false;
            }
            System.Int32? requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_Priority = null;
            if (cmdletContext.StatmuxSettings_Priority != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_Priority = cmdletContext.StatmuxSettings_Priority.Value;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_Priority != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings.Priority = requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings_statmuxSettings_Priority.Value;
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettingsIsNull = false;
            }
             // determine if requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings should be set to null
            if (requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettingsIsNull)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings = null;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings != null)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings.StatmuxSettings = requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings_multiplexProgramSettings_VideoSettings_StatmuxSettings;
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettingsIsNull = false;
            }
             // determine if requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings should be set to null
            if (requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettingsIsNull)
            {
                requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings = null;
            }
            if (requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings != null)
            {
                request.MultiplexProgramSettings.VideoSettings = requestMultiplexProgramSettings_multiplexProgramSettings_VideoSettings;
                requestMultiplexProgramSettingsIsNull = false;
            }
             // determine if request.MultiplexProgramSettings should be set to null
            if (requestMultiplexProgramSettingsIsNull)
            {
                request.MultiplexProgramSettings = null;
            }
            if (cmdletContext.ProgramName != null)
            {
                request.ProgramName = cmdletContext.ProgramName;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
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
        
        private Amazon.MediaLive.Model.CreateMultiplexProgramResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.CreateMultiplexProgramRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "CreateMultiplexProgram");
            try
            {
                return client.CreateMultiplexProgramAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.MediaLive.PreferredChannelPipeline MultiplexProgramSettings_PreferredChannelPipeline { get; set; }
            public System.Int32? MultiplexProgramSettings_ProgramNumber { get; set; }
            public System.String ServiceDescriptor_ProviderName { get; set; }
            public System.String ServiceDescriptor_ServiceName { get; set; }
            public System.Int32? VideoSettings_ConstantBitrate { get; set; }
            public System.Int32? StatmuxSettings_MaximumBitrate { get; set; }
            public System.Int32? StatmuxSettings_MinimumBitrate { get; set; }
            public System.Int32? StatmuxSettings_Priority { get; set; }
            public System.String ProgramName { get; set; }
            public System.String RequestId { get; set; }
            public System.Func<Amazon.MediaLive.Model.CreateMultiplexProgramResponse, NewEMLMultiplexProgramCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MultiplexProgram;
        }
        
    }
}
