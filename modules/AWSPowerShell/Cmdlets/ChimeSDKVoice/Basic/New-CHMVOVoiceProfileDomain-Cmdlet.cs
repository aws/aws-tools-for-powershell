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
    /// Creates a voice profile domain, a collection of voice profiles, their voice prints,
    /// and encrypted enrollment audio.
    /// 
    ///  <important><para>
    /// Before creating any voice profiles, you must provide all notices and obtain all consents
    /// from the speaker as required under applicable privacy and biometrics laws, and as
    /// required under the <a href="https://aws.amazon.com/service-terms/">AWS service terms</a>
    /// for the Amazon Chime SDK.
    /// </para></important><para>
    /// For more information about voice profile domains, see <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/pstn-voice-analytics.html">Using
    /// Amazon Chime SDK Voice Analytics</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CHMVOVoiceProfileDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.VoiceProfileDomain")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice CreateVoiceProfileDomain API operation.", Operation = new[] {"CreateVoiceProfileDomain"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.CreateVoiceProfileDomainResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.VoiceProfileDomain or Amazon.ChimeSDKVoice.Model.CreateVoiceProfileDomainResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.VoiceProfileDomain object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.CreateVoiceProfileDomainResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCHMVOVoiceProfileDomainCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the client request. Use a different token for different
        /// domain creation requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the voice profile domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key used to encrypt the enrollment data in a voice profile domain.
        /// Asymmetric customer managed keys are not supported.</para>
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
        public System.String ServerSideEncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the voice profile domain.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ChimeSDKVoice.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VoiceProfileDomain'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.CreateVoiceProfileDomainResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.CreateVoiceProfileDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VoiceProfileDomain";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMVOVoiceProfileDomain (CreateVoiceProfileDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.CreateVoiceProfileDomainResponse, NewCHMVOVoiceProfileDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerSideEncryptionConfiguration_KmsKeyArn = this.ServerSideEncryptionConfiguration_KmsKeyArn;
            #if MODULAR
            if (this.ServerSideEncryptionConfiguration_KmsKeyArn == null && ParameterWasBound(nameof(this.ServerSideEncryptionConfiguration_KmsKeyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerSideEncryptionConfiguration_KmsKeyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.CreateVoiceProfileDomainRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ServerSideEncryptionConfiguration
            var requestServerSideEncryptionConfigurationIsNull = true;
            request.ServerSideEncryptionConfiguration = new Amazon.ChimeSDKVoice.Model.ServerSideEncryptionConfiguration();
            System.String requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.ServerSideEncryptionConfiguration_KmsKeyArn != null)
            {
                requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyArn = cmdletContext.ServerSideEncryptionConfiguration_KmsKeyArn;
            }
            if (requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyArn != null)
            {
                request.ServerSideEncryptionConfiguration.KmsKeyArn = requestServerSideEncryptionConfiguration_serverSideEncryptionConfiguration_KmsKeyArn;
                requestServerSideEncryptionConfigurationIsNull = false;
            }
             // determine if request.ServerSideEncryptionConfiguration should be set to null
            if (requestServerSideEncryptionConfigurationIsNull)
            {
                request.ServerSideEncryptionConfiguration = null;
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
        
        private Amazon.ChimeSDKVoice.Model.CreateVoiceProfileDomainResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.CreateVoiceProfileDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "CreateVoiceProfileDomain");
            try
            {
                #if DESKTOP
                return client.CreateVoiceProfileDomain(request);
                #elif CORECLR
                return client.CreateVoiceProfileDomainAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String ServerSideEncryptionConfiguration_KmsKeyArn { get; set; }
            public List<Amazon.ChimeSDKVoice.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.CreateVoiceProfileDomainResponse, NewCHMVOVoiceProfileDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VoiceProfileDomain;
        }
        
    }
}
