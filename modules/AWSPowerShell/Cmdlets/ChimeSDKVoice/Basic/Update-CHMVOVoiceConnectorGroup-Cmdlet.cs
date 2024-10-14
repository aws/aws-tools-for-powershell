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
    /// Updates the settings for the specified Amazon Chime SDK Voice Connector group.
    /// </summary>
    [Cmdlet("Update", "CHMVOVoiceConnectorGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.VoiceConnectorGroup")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice UpdateVoiceConnectorGroup API operation.", Operation = new[] {"UpdateVoiceConnectorGroup"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.UpdateVoiceConnectorGroupResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.VoiceConnectorGroup or Amazon.ChimeSDKVoice.Model.UpdateVoiceConnectorGroupResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.VoiceConnectorGroup object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.UpdateVoiceConnectorGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCHMVOVoiceConnectorGroupCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Voice Connector group.</para>
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
        
        #region Parameter VoiceConnectorGroupId
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
        public System.String VoiceConnectorGroupId { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorItem
        /// <summary>
        /// <para>
        /// <para>The <c>VoiceConnectorItems</c> to associate with the Voice Connector group.</para>
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
        [Alias("VoiceConnectorItems")]
        public Amazon.ChimeSDKVoice.Model.VoiceConnectorItem[] VoiceConnectorItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VoiceConnectorGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.UpdateVoiceConnectorGroupResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.UpdateVoiceConnectorGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VoiceConnectorGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VoiceConnectorGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VoiceConnectorGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VoiceConnectorGroupId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceConnectorGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMVOVoiceConnectorGroup (UpdateVoiceConnectorGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.UpdateVoiceConnectorGroupResponse, UpdateCHMVOVoiceConnectorGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VoiceConnectorGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VoiceConnectorGroupId = this.VoiceConnectorGroupId;
            #if MODULAR
            if (this.VoiceConnectorGroupId == null && ParameterWasBound(nameof(this.VoiceConnectorGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceConnectorGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VoiceConnectorItem != null)
            {
                context.VoiceConnectorItem = new List<Amazon.ChimeSDKVoice.Model.VoiceConnectorItem>(this.VoiceConnectorItem);
            }
            #if MODULAR
            if (this.VoiceConnectorItem == null && ParameterWasBound(nameof(this.VoiceConnectorItem)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceConnectorItem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.UpdateVoiceConnectorGroupRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.VoiceConnectorGroupId != null)
            {
                request.VoiceConnectorGroupId = cmdletContext.VoiceConnectorGroupId;
            }
            if (cmdletContext.VoiceConnectorItem != null)
            {
                request.VoiceConnectorItems = cmdletContext.VoiceConnectorItem;
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
        
        private Amazon.ChimeSDKVoice.Model.UpdateVoiceConnectorGroupResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.UpdateVoiceConnectorGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "UpdateVoiceConnectorGroup");
            try
            {
                #if DESKTOP
                return client.UpdateVoiceConnectorGroup(request);
                #elif CORECLR
                return client.UpdateVoiceConnectorGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String VoiceConnectorGroupId { get; set; }
            public List<Amazon.ChimeSDKVoice.Model.VoiceConnectorItem> VoiceConnectorItem { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.UpdateVoiceConnectorGroupResponse, UpdateCHMVOVoiceConnectorGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VoiceConnectorGroup;
        }
        
    }
}
