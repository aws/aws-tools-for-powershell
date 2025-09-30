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
    /// Creates an Amazon Chime SDK Voice Connector. For more information about Voice Connectors,
    /// see <a href="https://docs.aws.amazon.com/chime-sdk/latest/ag/voice-connector-groups.html">Managing
    /// Amazon Chime SDK Voice Connector groups</a> in the <i>Amazon Chime SDK Administrator
    /// Guide</i>.
    /// </summary>
    [Cmdlet("New", "CHMVOVoiceConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.VoiceConnector")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice CreateVoiceConnector API operation.", Operation = new[] {"CreateVoiceConnector"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.CreateVoiceConnectorResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.VoiceConnector or Amazon.ChimeSDKVoice.Model.CreateVoiceConnectorResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.VoiceConnector object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.CreateVoiceConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCHMVOVoiceConnectorCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsRegion
        /// <summary>
        /// <para>
        /// <para>The AWS Region in which the Amazon Chime SDK Voice Connector is created. Default value:
        /// <c>us-east-1</c> .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.VoiceConnectorAwsRegion")]
        public Amazon.ChimeSDKVoice.VoiceConnectorAwsRegion AwsRegion { get; set; }
        #endregion
        
        #region Parameter IntegrationType
        /// <summary>
        /// <para>
        /// <para>The connectors for use with Amazon Connect.</para><para>The following options are available:</para><ul><li><para><c>CONNECT_CALL_TRANSFER_CONNECTOR</c> - Enables enterprises to integrate Amazon
        /// Connect with other voice systems to directly transfer voice calls and metadata without
        /// using the public telephone network. They can use Amazon Connect telephony and Interactive
        /// Voice Response (IVR) with their existing voice systems to modernize the IVR experience
        /// of their existing contact center and their enterprise and branch voice systems. Additionally,
        /// enterprises migrating their contact center to Amazon Connect can start with Connect
        /// telephony and IVR for immediate modernization ahead of agent migration.</para></li><li><para><c>CONNECT_ANALYTICS_CONNECTOR</c> - Enables enterprises to integrate Amazon Connect
        /// with other voice systems for real-time and post-call analytics. They can use Amazon
        /// Connect Contact Lens with their existing voice systems to provides call recordings,
        /// conversational analytics (including contact transcript, sensitive data redaction,
        /// content categorization, theme detection, sentiment analysis, real-time alerts, and
        /// post-contact summary), and agent performance evaluations (including evaluation forms,
        /// automated evaluation, supervisor review) with a rich user experience to display, search
        /// and filter customer interactions, and programmatic access to data streams and the
        /// data lake. Additionally, enterprises migrating their contact center to Amazon Connect
        /// can start with Contact Lens analytics and performance insights ahead of agent migration.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.VoiceConnectorIntegrationType")]
        public Amazon.ChimeSDKVoice.VoiceConnectorIntegrationType IntegrationType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Voice Connector.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The type of network for the Voice Connector. Either IPv4 only or dual-stack (IPv4
        /// and IPv6).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.NetworkType")]
        public Amazon.ChimeSDKVoice.NetworkType NetworkType { get; set; }
        #endregion
        
        #region Parameter RequireEncryption
        /// <summary>
        /// <para>
        /// <para>Enables or disables encryption for the Voice Connector.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? RequireEncryption { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the Voice Connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ChimeSDKVoice.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VoiceConnector'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.CreateVoiceConnectorResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.CreateVoiceConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VoiceConnector";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMVOVoiceConnector (CreateVoiceConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.CreateVoiceConnectorResponse, NewCHMVOVoiceConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsRegion = this.AwsRegion;
            context.IntegrationType = this.IntegrationType;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkType = this.NetworkType;
            context.RequireEncryption = this.RequireEncryption;
            #if MODULAR
            if (this.RequireEncryption == null && ParameterWasBound(nameof(this.RequireEncryption)))
            {
                WriteWarning("You are passing $null as a value for parameter RequireEncryption which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ChimeSDKVoice.Model.Tag>(this.Tag);
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
            var request = new Amazon.ChimeSDKVoice.Model.CreateVoiceConnectorRequest();
            
            if (cmdletContext.AwsRegion != null)
            {
                request.AwsRegion = cmdletContext.AwsRegion;
            }
            if (cmdletContext.IntegrationType != null)
            {
                request.IntegrationType = cmdletContext.IntegrationType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NetworkType != null)
            {
                request.NetworkType = cmdletContext.NetworkType;
            }
            if (cmdletContext.RequireEncryption != null)
            {
                request.RequireEncryption = cmdletContext.RequireEncryption.Value;
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
        
        private Amazon.ChimeSDKVoice.Model.CreateVoiceConnectorResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.CreateVoiceConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "CreateVoiceConnector");
            try
            {
                #if DESKTOP
                return client.CreateVoiceConnector(request);
                #elif CORECLR
                return client.CreateVoiceConnectorAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ChimeSDKVoice.VoiceConnectorAwsRegion AwsRegion { get; set; }
            public Amazon.ChimeSDKVoice.VoiceConnectorIntegrationType IntegrationType { get; set; }
            public System.String Name { get; set; }
            public Amazon.ChimeSDKVoice.NetworkType NetworkType { get; set; }
            public System.Boolean? RequireEncryption { get; set; }
            public List<Amazon.ChimeSDKVoice.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.CreateVoiceConnectorResponse, NewCHMVOVoiceConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VoiceConnector;
        }
        
    }
}
