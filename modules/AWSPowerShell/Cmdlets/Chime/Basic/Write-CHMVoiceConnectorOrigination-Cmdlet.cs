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
    /// Adds origination settings for the specified Amazon Chime Voice Connector.
    /// 
    ///  <note><para>
    /// If emergency calling is configured for the Amazon Chime Voice Connector, it must be
    /// deleted prior to turning off origination settings.
    /// </para></note><important><para><b>This API is is no longer supported and will not be updated.</b> We recommend using
    /// the latest version, <a href="https://docs.aws.amazon.com/chime-sdk/latest/APIReference/API_voice-chime_PutVoiceConnectorOrigination.html">PutVoiceConnectorOrigination</a>,
    /// in the Amazon Chime SDK.
    /// </para><para>
    /// Using the latest version requires migrating to a dedicated namespace. For more information,
    /// refer to <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/migrate-from-chm-namespace.html">Migrating
    /// from the Amazon Chime namespace</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para></important><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Write", "CHMVoiceConnectorOrigination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.Origination")]
    [AWSCmdlet("Calls the Amazon Chime PutVoiceConnectorOrigination API operation.", Operation = new[] {"PutVoiceConnectorOrigination"}, SelectReturnType = typeof(Amazon.Chime.Model.PutVoiceConnectorOriginationResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.Origination or Amazon.Chime.Model.PutVoiceConnectorOriginationResponse",
        "This cmdlet returns an Amazon.Chime.Model.Origination object.",
        "The service call response (type Amazon.Chime.Model.PutVoiceConnectorOriginationResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("Replaced by PutVoiceConnectorOrigination in the Amazon Chime SDK Voice Namespace")]
    public partial class WriteCHMVoiceConnectorOriginationCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Origination_Disabled
        /// <summary>
        /// <para>
        /// <para>When origination settings are disabled, inbound calls are not enabled for your Amazon
        /// Chime Voice Connector. This parameter is not required, but you must specify this parameter
        /// or <c>Routes</c>.</para>
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
        public Amazon.Chime.Model.OriginationRoute[] Origination_Route { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Origination'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.PutVoiceConnectorOriginationResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.PutVoiceConnectorOriginationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVoiceConnectorOrigination (PutVoiceConnectorOrigination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.PutVoiceConnectorOriginationResponse, WriteCHMVoiceConnectorOriginationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Origination_Disabled = this.Origination_Disabled;
            if (this.Origination_Route != null)
            {
                context.Origination_Route = new List<Amazon.Chime.Model.OriginationRoute>(this.Origination_Route);
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
            var request = new Amazon.Chime.Model.PutVoiceConnectorOriginationRequest();
            
            
             // populate Origination
            var requestOriginationIsNull = true;
            request.Origination = new Amazon.Chime.Model.Origination();
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
            List<Amazon.Chime.Model.OriginationRoute> requestOrigination_origination_Route = null;
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
        
        private Amazon.Chime.Model.PutVoiceConnectorOriginationResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.PutVoiceConnectorOriginationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "PutVoiceConnectorOrigination");
            try
            {
                return client.PutVoiceConnectorOriginationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Chime.Model.OriginationRoute> Origination_Route { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.Chime.Model.PutVoiceConnectorOriginationResponse, WriteCHMVoiceConnectorOriginationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Origination;
        }
        
    }
}
