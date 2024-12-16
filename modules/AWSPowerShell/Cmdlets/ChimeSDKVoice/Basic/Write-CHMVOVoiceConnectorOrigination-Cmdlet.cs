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
    /// Updates a Voice Connector's origination settings.
    /// </summary>
    [Cmdlet("Write", "CHMVOVoiceConnectorOrigination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.Origination")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice PutVoiceConnectorOrigination API operation.", Operation = new[] {"PutVoiceConnectorOrigination"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.PutVoiceConnectorOriginationResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.Origination or Amazon.ChimeSDKVoice.Model.PutVoiceConnectorOriginationResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.Origination object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorOriginationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCHMVOVoiceConnectorOriginationCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Origination_Disabled
        /// <summary>
        /// <para>
        /// <para>When origination settings are disabled, inbound calls are not enabled for your Amazon
        /// Chime SDK Voice Connector. This parameter is not required, but you must specify this
        /// parameter or <c>Routes</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Origination_Disabled { get; set; }
        #endregion
        
        #region Parameter Origination_Route
        /// <summary>
        /// <para>
        /// <para>The call distribution properties defined for your SIP hosts. Valid range: Minimum
        /// value of 1. Maximum value of 20. This parameter is not required, but you must specify
        /// this parameter or <c>Disabled</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Origination_Routes")]
        public Amazon.ChimeSDKVoice.Model.OriginationRoute[] Origination_Route { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorId
        /// <summary>
        /// <para>
        /// <para>The Voice Connector ID.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Origination'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.PutVoiceConnectorOriginationResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorOriginationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Origination";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVOVoiceConnectorOrigination (PutVoiceConnectorOrigination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorOriginationResponse, WriteCHMVOVoiceConnectorOriginationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Origination_Disabled = this.Origination_Disabled;
            if (this.Origination_Route != null)
            {
                context.Origination_Route = new List<Amazon.ChimeSDKVoice.Model.OriginationRoute>(this.Origination_Route);
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
            var request = new Amazon.ChimeSDKVoice.Model.PutVoiceConnectorOriginationRequest();
            
            
             // populate Origination
            var requestOriginationIsNull = true;
            request.Origination = new Amazon.ChimeSDKVoice.Model.Origination();
            System.Boolean? requestOrigination_origination_Disabled = null;
            if (cmdletContext.Origination_Disabled != null)
            {
                requestOrigination_origination_Disabled = cmdletContext.Origination_Disabled.Value;
            }
            if (requestOrigination_origination_Disabled != null)
            {
                request.Origination.Disabled = requestOrigination_origination_Disabled.Value;
                requestOriginationIsNull = false;
            }
            List<Amazon.ChimeSDKVoice.Model.OriginationRoute> requestOrigination_origination_Route = null;
            if (cmdletContext.Origination_Route != null)
            {
                requestOrigination_origination_Route = cmdletContext.Origination_Route;
            }
            if (requestOrigination_origination_Route != null)
            {
                request.Origination.Routes = requestOrigination_origination_Route;
                requestOriginationIsNull = false;
            }
             // determine if request.Origination should be set to null
            if (requestOriginationIsNull)
            {
                request.Origination = null;
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
        
        private Amazon.ChimeSDKVoice.Model.PutVoiceConnectorOriginationResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.PutVoiceConnectorOriginationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "PutVoiceConnectorOrigination");
            try
            {
                #if DESKTOP
                return client.PutVoiceConnectorOrigination(request);
                #elif CORECLR
                return client.PutVoiceConnectorOriginationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Origination_Disabled { get; set; }
            public List<Amazon.ChimeSDKVoice.Model.OriginationRoute> Origination_Route { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorOriginationResponse, WriteCHMVOVoiceConnectorOriginationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Origination;
        }
        
    }
}
