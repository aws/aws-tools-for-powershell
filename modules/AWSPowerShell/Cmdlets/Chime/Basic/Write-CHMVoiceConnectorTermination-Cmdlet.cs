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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Adds termination settings for the specified Amazon Chime Voice Connector.
    /// 
    ///  <note><para>
    /// If emergency calling is configured for the Amazon Chime Voice Connector, it must be
    /// deleted prior to turning off termination settings.
    /// </para></note><important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_voice-chime_PutVoiceConnectorTermination.html">PutVoiceConnectorTermination</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Write", "CHMVoiceConnectorTermination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.Termination")]
    [AWSCmdlet("Calls the Amazon Chime PutVoiceConnectorTermination API operation.", Operation = new[] {"PutVoiceConnectorTermination"}, SelectReturnType = typeof(Amazon.Chime.Model.PutVoiceConnectorTerminationResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.Termination or Amazon.Chime.Model.PutVoiceConnectorTerminationResponse",
        "This cmdlet returns an Amazon.Chime.Model.Termination object.",
        "The service call response (type Amazon.Chime.Model.PutVoiceConnectorTerminationResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Replaced by PutVoiceConnectorTermination in the Amazon Chime SDK Voice Namespace")]
    public partial class WriteCHMVoiceConnectorTerminationCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para>The IP addresses allowed to make calls, in CIDR format. Required.</para>
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
        /// <para>The default caller ID phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Termination_DefaultPhoneNumber { get; set; }
        #endregion
        
        #region Parameter Termination_Disabled
        /// <summary>
        /// <para>
        /// <para>When termination settings are disabled, outbound calls can not be made.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Termination_Disabled { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Termination'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.PutVoiceConnectorTerminationResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.PutVoiceConnectorTerminationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Termination";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVoiceConnectorTermination (PutVoiceConnectorTermination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.PutVoiceConnectorTerminationResponse, WriteCHMVoiceConnectorTerminationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.Chime.Model.PutVoiceConnectorTerminationRequest();
            
            
             // populate Termination
            var requestTerminationIsNull = true;
            request.Termination = new Amazon.Chime.Model.Termination();
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
        
        private Amazon.Chime.Model.PutVoiceConnectorTerminationResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.PutVoiceConnectorTerminationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "PutVoiceConnectorTermination");
            try
            {
                return client.PutVoiceConnectorTerminationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Chime.Model.PutVoiceConnectorTerminationResponse, WriteCHMVoiceConnectorTerminationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Termination;
        }
        
    }
}
