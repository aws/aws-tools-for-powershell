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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Updates a Voice Connector's termination settings.
    /// </summary>
    [Cmdlet("Write", "CHMVOVoiceConnectorTermination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.Termination")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice PutVoiceConnectorTermination API operation.", Operation = new[] {"PutVoiceConnectorTermination"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.PutVoiceConnectorTerminationResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.Termination or Amazon.ChimeSDKVoice.Model.PutVoiceConnectorTerminationResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.Termination object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorTerminationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCHMVOVoiceConnectorTerminationCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Termination_CallingRegion
        /// <summary>
        /// <para>
        /// <para>The countries to which calls are allowed, in ISO 3166-1 alpha-2 format. Required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Termination_CallingRegions")]
        public System.String[] Termination_CallingRegion { get; set; }
        #endregion
        
        #region Parameter Termination_CidrAllowedList
        /// <summary>
        /// <para>
        /// <para>The IP addresses allowed to make calls, in CIDR format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Termination_CidrAllowedList { get; set; }
        #endregion
        
        #region Parameter Termination_CpsLimit
        /// <summary>
        /// <para>
        /// <para>The limit on calls per second. Max value based on account service quota. Default value
        /// of 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Termination_CpsLimit { get; set; }
        #endregion
        
        #region Parameter Termination_DefaultPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The default outbound calling number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Termination_DefaultPhoneNumber { get; set; }
        #endregion
        
        #region Parameter Termination_Disabled
        /// <summary>
        /// <para>
        /// <para>When termination is disabled, outbound calls cannot be made.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Termination_Disabled { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Termination'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.PutVoiceConnectorTerminationResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorTerminationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Termination";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVOVoiceConnectorTermination (PutVoiceConnectorTermination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorTerminationResponse, WriteCHMVOVoiceConnectorTerminationCmdlet>(Select) ??
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
            if (this.Termination_CallingRegion != null)
            {
                context.Termination_CallingRegion = new List<System.String>(this.Termination_CallingRegion);
            }
            if (this.Termination_CidrAllowedList != null)
            {
                context.Termination_CidrAllowedList = new List<System.String>(this.Termination_CidrAllowedList);
            }
            context.Termination_CpsLimit = this.Termination_CpsLimit;
            context.Termination_DefaultPhoneNumber = this.Termination_DefaultPhoneNumber;
            context.Termination_Disabled = this.Termination_Disabled;
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
            var request = new Amazon.ChimeSDKVoice.Model.PutVoiceConnectorTerminationRequest();
            
            
             // populate Termination
            var requestTerminationIsNull = true;
            request.Termination = new Amazon.ChimeSDKVoice.Model.Termination();
            List<System.String> requestTermination_termination_CallingRegion = null;
            if (cmdletContext.Termination_CallingRegion != null)
            {
                requestTermination_termination_CallingRegion = cmdletContext.Termination_CallingRegion;
            }
            if (requestTermination_termination_CallingRegion != null)
            {
                request.Termination.CallingRegions = requestTermination_termination_CallingRegion;
                requestTerminationIsNull = false;
            }
            List<System.String> requestTermination_termination_CidrAllowedList = null;
            if (cmdletContext.Termination_CidrAllowedList != null)
            {
                requestTermination_termination_CidrAllowedList = cmdletContext.Termination_CidrAllowedList;
            }
            if (requestTermination_termination_CidrAllowedList != null)
            {
                request.Termination.CidrAllowedList = requestTermination_termination_CidrAllowedList;
                requestTerminationIsNull = false;
            }
            System.Int32? requestTermination_termination_CpsLimit = null;
            if (cmdletContext.Termination_CpsLimit != null)
            {
                requestTermination_termination_CpsLimit = cmdletContext.Termination_CpsLimit.Value;
            }
            if (requestTermination_termination_CpsLimit != null)
            {
                request.Termination.CpsLimit = requestTermination_termination_CpsLimit.Value;
                requestTerminationIsNull = false;
            }
            System.String requestTermination_termination_DefaultPhoneNumber = null;
            if (cmdletContext.Termination_DefaultPhoneNumber != null)
            {
                requestTermination_termination_DefaultPhoneNumber = cmdletContext.Termination_DefaultPhoneNumber;
            }
            if (requestTermination_termination_DefaultPhoneNumber != null)
            {
                request.Termination.DefaultPhoneNumber = requestTermination_termination_DefaultPhoneNumber;
                requestTerminationIsNull = false;
            }
            System.Boolean? requestTermination_termination_Disabled = null;
            if (cmdletContext.Termination_Disabled != null)
            {
                requestTermination_termination_Disabled = cmdletContext.Termination_Disabled.Value;
            }
            if (requestTermination_termination_Disabled != null)
            {
                request.Termination.Disabled = requestTermination_termination_Disabled.Value;
                requestTerminationIsNull = false;
            }
             // determine if request.Termination should be set to null
            if (requestTerminationIsNull)
            {
                request.Termination = null;
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
        
        private Amazon.ChimeSDKVoice.Model.PutVoiceConnectorTerminationResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.PutVoiceConnectorTerminationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "PutVoiceConnectorTermination");
            try
            {
                #if DESKTOP
                return client.PutVoiceConnectorTermination(request);
                #elif CORECLR
                return client.PutVoiceConnectorTerminationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Termination_CallingRegion { get; set; }
            public List<System.String> Termination_CidrAllowedList { get; set; }
            public System.Int32? Termination_CpsLimit { get; set; }
            public System.String Termination_DefaultPhoneNumber { get; set; }
            public System.Boolean? Termination_Disabled { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorTerminationResponse, WriteCHMVOVoiceConnectorTerminationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Termination;
        }
        
    }
}
