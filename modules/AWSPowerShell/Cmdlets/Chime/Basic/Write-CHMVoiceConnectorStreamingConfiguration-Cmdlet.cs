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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Adds a streaming configuration for the specified Amazon Chime Voice Connector. The
    /// streaming configuration specifies whether media streaming is enabled for sending to
    /// Kinesis. It also sets the retention period, in hours, for the Amazon Kinesis data.
    /// 
    ///  <important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_voice-chime_PutVoiceConnectorStreamingConfiguration.html">PutVoiceConnectorStreamingConfiguration</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Write", "CHMVoiceConnectorStreamingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.StreamingConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime PutVoiceConnectorStreamingConfiguration API operation.", Operation = new[] {"PutVoiceConnectorStreamingConfiguration"}, SelectReturnType = typeof(Amazon.Chime.Model.PutVoiceConnectorStreamingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.StreamingConfiguration or Amazon.Chime.Model.PutVoiceConnectorStreamingConfigurationResponse",
        "This cmdlet returns an Amazon.Chime.Model.StreamingConfiguration object.",
        "The service call response (type Amazon.Chime.Model.PutVoiceConnectorStreamingConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("Replaced by PutVoiceConnectorStreamingConfiguration in the Amazon Chime SDK Voice Namespace")]
    public partial class WriteCHMVoiceConnectorStreamingConfigurationCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter StreamingConfiguration_DataRetentionInHour
        /// <summary>
        /// <para>
        /// <para>The retention period, in hours, for the Amazon Kinesis data.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StreamingConfiguration_DataRetentionInHours")]
        public System.Int32? StreamingConfiguration_DataRetentionInHour { get; set; }
        #endregion
        
        #region Parameter StreamingConfiguration_Disabled
        /// <summary>
        /// <para>
        /// <para>When true, media streaming to Amazon Kinesis is turned off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StreamingConfiguration_Disabled { get; set; }
        #endregion
        
        #region Parameter StreamingConfiguration_StreamingNotificationTarget
        /// <summary>
        /// <para>
        /// <para>The streaming notification targets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingConfiguration_StreamingNotificationTargets")]
        public Amazon.Chime.Model.StreamingNotificationTarget[] StreamingConfiguration_StreamingNotificationTarget { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime Voice Connector ID.</para>
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
        public System.String VoiceConnectorId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StreamingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.PutVoiceConnectorStreamingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.PutVoiceConnectorStreamingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StreamingConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VoiceConnectorId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VoiceConnectorId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VoiceConnectorId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVoiceConnectorStreamingConfiguration (PutVoiceConnectorStreamingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.PutVoiceConnectorStreamingConfigurationResponse, WriteCHMVoiceConnectorStreamingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VoiceConnectorId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.StreamingConfiguration_DataRetentionInHour = this.StreamingConfiguration_DataRetentionInHour;
            #if MODULAR
            if (this.StreamingConfiguration_DataRetentionInHour == null && ParameterWasBound(nameof(this.StreamingConfiguration_DataRetentionInHour)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamingConfiguration_DataRetentionInHour which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamingConfiguration_Disabled = this.StreamingConfiguration_Disabled;
            if (this.StreamingConfiguration_StreamingNotificationTarget != null)
            {
                context.StreamingConfiguration_StreamingNotificationTarget = new List<Amazon.Chime.Model.StreamingNotificationTarget>(this.StreamingConfiguration_StreamingNotificationTarget);
            }
            context.VoiceConnectorId = this.VoiceConnectorId;
            #if MODULAR
            if (this.VoiceConnectorId == null && ParameterWasBound(nameof(this.VoiceConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Chime.Model.PutVoiceConnectorStreamingConfigurationRequest();
            
            
             // populate StreamingConfiguration
            var requestStreamingConfigurationIsNull = true;
            request.StreamingConfiguration = new Amazon.Chime.Model.StreamingConfiguration();
            System.Int32? requestStreamingConfiguration_streamingConfiguration_DataRetentionInHour = null;
            if (cmdletContext.StreamingConfiguration_DataRetentionInHour != null)
            {
                requestStreamingConfiguration_streamingConfiguration_DataRetentionInHour = cmdletContext.StreamingConfiguration_DataRetentionInHour.Value;
            }
            if (requestStreamingConfiguration_streamingConfiguration_DataRetentionInHour != null)
            {
                request.StreamingConfiguration.DataRetentionInHours = requestStreamingConfiguration_streamingConfiguration_DataRetentionInHour.Value;
                requestStreamingConfigurationIsNull = false;
            }
            System.Boolean? requestStreamingConfiguration_streamingConfiguration_Disabled = null;
            if (cmdletContext.StreamingConfiguration_Disabled != null)
            {
                requestStreamingConfiguration_streamingConfiguration_Disabled = cmdletContext.StreamingConfiguration_Disabled.Value;
            }
            if (requestStreamingConfiguration_streamingConfiguration_Disabled != null)
            {
                request.StreamingConfiguration.Disabled = requestStreamingConfiguration_streamingConfiguration_Disabled.Value;
                requestStreamingConfigurationIsNull = false;
            }
            List<Amazon.Chime.Model.StreamingNotificationTarget> requestStreamingConfiguration_streamingConfiguration_StreamingNotificationTarget = null;
            if (cmdletContext.StreamingConfiguration_StreamingNotificationTarget != null)
            {
                requestStreamingConfiguration_streamingConfiguration_StreamingNotificationTarget = cmdletContext.StreamingConfiguration_StreamingNotificationTarget;
            }
            if (requestStreamingConfiguration_streamingConfiguration_StreamingNotificationTarget != null)
            {
                request.StreamingConfiguration.StreamingNotificationTargets = requestStreamingConfiguration_streamingConfiguration_StreamingNotificationTarget;
                requestStreamingConfigurationIsNull = false;
            }
             // determine if request.StreamingConfiguration should be set to null
            if (requestStreamingConfigurationIsNull)
            {
                request.StreamingConfiguration = null;
            }
            if (cmdletContext.VoiceConnectorId != null)
            {
                request.VoiceConnectorId = cmdletContext.VoiceConnectorId;
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
        
        private Amazon.Chime.Model.PutVoiceConnectorStreamingConfigurationResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.PutVoiceConnectorStreamingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "PutVoiceConnectorStreamingConfiguration");
            try
            {
                #if DESKTOP
                return client.PutVoiceConnectorStreamingConfiguration(request);
                #elif CORECLR
                return client.PutVoiceConnectorStreamingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? StreamingConfiguration_DataRetentionInHour { get; set; }
            public System.Boolean? StreamingConfiguration_Disabled { get; set; }
            public List<Amazon.Chime.Model.StreamingNotificationTarget> StreamingConfiguration_StreamingNotificationTarget { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.Chime.Model.PutVoiceConnectorStreamingConfigurationResponse, WriteCHMVoiceConnectorStreamingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StreamingConfiguration;
        }
        
    }
}
