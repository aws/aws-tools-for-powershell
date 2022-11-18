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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    
    /// </summary>
    [Cmdlet("New", "CHMVOProxySession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.ProxySession")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice CreateProxySession API operation.", Operation = new[] {"CreateProxySession"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.CreateProxySessionResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.ProxySession or Amazon.ChimeSDKVoice.Model.CreateProxySessionResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.ProxySession object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.CreateProxySessionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCHMVOProxySessionCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        #region Parameter GeoMatchParams_AreaCode
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GeoMatchParams_AreaCode { get; set; }
        #endregion
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter GeoMatchParams_Country
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GeoMatchParams_Country { get; set; }
        #endregion
        
        #region Parameter ExpiryMinute
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpiryMinutes")]
        public System.Int32? ExpiryMinute { get; set; }
        #endregion
        
        #region Parameter GeoMatchLevel
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.GeoMatchLevel")]
        public Amazon.ChimeSDKVoice.GeoMatchLevel GeoMatchLevel { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NumberSelectionBehavior
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.NumberSelectionBehavior")]
        public Amazon.ChimeSDKVoice.NumberSelectionBehavior NumberSelectionBehavior { get; set; }
        #endregion
        
        #region Parameter ParticipantPhoneNumber
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        [Alias("ParticipantPhoneNumbers")]
        public System.String[] ParticipantPhoneNumber { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProxySession'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.CreateProxySessionResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.CreateProxySessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProxySession";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMVOProxySession (CreateProxySession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.CreateProxySessionResponse, NewCHMVOProxySessionCmdlet>(Select) ??
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
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            #if MODULAR
            if (this.Capability == null && ParameterWasBound(nameof(this.Capability)))
            {
                WriteWarning("You are passing $null as a value for parameter Capability which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpiryMinute = this.ExpiryMinute;
            context.GeoMatchLevel = this.GeoMatchLevel;
            context.GeoMatchParams_AreaCode = this.GeoMatchParams_AreaCode;
            context.GeoMatchParams_Country = this.GeoMatchParams_Country;
            context.Name = this.Name;
            context.NumberSelectionBehavior = this.NumberSelectionBehavior;
            if (this.ParticipantPhoneNumber != null)
            {
                context.ParticipantPhoneNumber = new List<System.String>(this.ParticipantPhoneNumber);
            }
            #if MODULAR
            if (this.ParticipantPhoneNumber == null && ParameterWasBound(nameof(this.ParticipantPhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter ParticipantPhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.ChimeSDKVoice.Model.CreateProxySessionRequest();
            
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            if (cmdletContext.ExpiryMinute != null)
            {
                request.ExpiryMinutes = cmdletContext.ExpiryMinute.Value;
            }
            if (cmdletContext.GeoMatchLevel != null)
            {
                request.GeoMatchLevel = cmdletContext.GeoMatchLevel;
            }
            
             // populate GeoMatchParams
            var requestGeoMatchParamsIsNull = true;
            request.GeoMatchParams = new Amazon.ChimeSDKVoice.Model.GeoMatchParams();
            System.String requestGeoMatchParams_geoMatchParams_AreaCode = null;
            if (cmdletContext.GeoMatchParams_AreaCode != null)
            {
                requestGeoMatchParams_geoMatchParams_AreaCode = cmdletContext.GeoMatchParams_AreaCode;
            }
            if (requestGeoMatchParams_geoMatchParams_AreaCode != null)
            {
                request.GeoMatchParams.AreaCode = requestGeoMatchParams_geoMatchParams_AreaCode;
                requestGeoMatchParamsIsNull = false;
            }
            System.String requestGeoMatchParams_geoMatchParams_Country = null;
            if (cmdletContext.GeoMatchParams_Country != null)
            {
                requestGeoMatchParams_geoMatchParams_Country = cmdletContext.GeoMatchParams_Country;
            }
            if (requestGeoMatchParams_geoMatchParams_Country != null)
            {
                request.GeoMatchParams.Country = requestGeoMatchParams_geoMatchParams_Country;
                requestGeoMatchParamsIsNull = false;
            }
             // determine if request.GeoMatchParams should be set to null
            if (requestGeoMatchParamsIsNull)
            {
                request.GeoMatchParams = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NumberSelectionBehavior != null)
            {
                request.NumberSelectionBehavior = cmdletContext.NumberSelectionBehavior;
            }
            if (cmdletContext.ParticipantPhoneNumber != null)
            {
                request.ParticipantPhoneNumbers = cmdletContext.ParticipantPhoneNumber;
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
        
        private Amazon.ChimeSDKVoice.Model.CreateProxySessionResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.CreateProxySessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "CreateProxySession");
            try
            {
                #if DESKTOP
                return client.CreateProxySession(request);
                #elif CORECLR
                return client.CreateProxySessionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Capability { get; set; }
            public System.Int32? ExpiryMinute { get; set; }
            public Amazon.ChimeSDKVoice.GeoMatchLevel GeoMatchLevel { get; set; }
            public System.String GeoMatchParams_AreaCode { get; set; }
            public System.String GeoMatchParams_Country { get; set; }
            public System.String Name { get; set; }
            public Amazon.ChimeSDKVoice.NumberSelectionBehavior NumberSelectionBehavior { get; set; }
            public List<System.String> ParticipantPhoneNumber { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.CreateProxySessionResponse, NewCHMVOProxySessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProxySession;
        }
        
    }
}
