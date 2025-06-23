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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Disassociates the specified phone numbers from the specified Amazon Chime SDK Voice
    /// Connector group.
    /// </summary>
    [Cmdlet("Remove", "CHMVOPhoneNumbersFromVoiceConnectorGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ChimeSDKVoice.Model.PhoneNumberError")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice DisassociatePhoneNumbersFromVoiceConnectorGroup API operation.", Operation = new[] {"DisassociatePhoneNumbersFromVoiceConnectorGroup"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.DisassociatePhoneNumbersFromVoiceConnectorGroupResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.PhoneNumberError or Amazon.ChimeSDKVoice.Model.DisassociatePhoneNumbersFromVoiceConnectorGroupResponse",
        "This cmdlet returns a collection of Amazon.ChimeSDKVoice.Model.PhoneNumberError objects.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.DisassociatePhoneNumbersFromVoiceConnectorGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveCHMVOPhoneNumbersFromVoiceConnectorGroupCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter E164PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The list of phone numbers, in E.164 format.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("E164PhoneNumbers")]
        public System.String[] E164PhoneNumber { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorGroupId
        /// <summary>
        /// <para>
        /// <para>The Voice Connector group ID.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PhoneNumberErrors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.DisassociatePhoneNumbersFromVoiceConnectorGroupResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.DisassociatePhoneNumbersFromVoiceConnectorGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PhoneNumberErrors";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceConnectorGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CHMVOPhoneNumbersFromVoiceConnectorGroup (DisassociatePhoneNumbersFromVoiceConnectorGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.DisassociatePhoneNumbersFromVoiceConnectorGroupResponse, RemoveCHMVOPhoneNumbersFromVoiceConnectorGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.E164PhoneNumber != null)
            {
                context.E164PhoneNumber = new List<System.String>(this.E164PhoneNumber);
            }
            #if MODULAR
            if (this.E164PhoneNumber == null && ParameterWasBound(nameof(this.E164PhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter E164PhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VoiceConnectorGroupId = this.VoiceConnectorGroupId;
            #if MODULAR
            if (this.VoiceConnectorGroupId == null && ParameterWasBound(nameof(this.VoiceConnectorGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceConnectorGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.DisassociatePhoneNumbersFromVoiceConnectorGroupRequest();
            
            if (cmdletContext.E164PhoneNumber != null)
            {
                request.E164PhoneNumbers = cmdletContext.E164PhoneNumber;
            }
            if (cmdletContext.VoiceConnectorGroupId != null)
            {
                request.VoiceConnectorGroupId = cmdletContext.VoiceConnectorGroupId;
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
        
        private Amazon.ChimeSDKVoice.Model.DisassociatePhoneNumbersFromVoiceConnectorGroupResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.DisassociatePhoneNumbersFromVoiceConnectorGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "DisassociatePhoneNumbersFromVoiceConnectorGroup");
            try
            {
                return client.DisassociatePhoneNumbersFromVoiceConnectorGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> E164PhoneNumber { get; set; }
            public System.String VoiceConnectorGroupId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.DisassociatePhoneNumbersFromVoiceConnectorGroupResponse, RemoveCHMVOPhoneNumbersFromVoiceConnectorGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PhoneNumberErrors;
        }
        
    }
}
