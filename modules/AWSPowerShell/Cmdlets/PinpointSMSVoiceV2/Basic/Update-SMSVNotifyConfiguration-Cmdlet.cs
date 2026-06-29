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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Updates an existing notify configuration. You can update the default template, pool
    /// association, enabled channels, enabled countries, and deletion protection settings.
    /// </summary>
    [Cmdlet("Update", "SMSVNotifyConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 UpdateNotifyConfiguration API operation.", Operation = new[] {"UpdateNotifyConfiguration"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateSMSVNotifyConfigurationCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DefaultTemplateId
        /// <summary>
        /// <para>
        /// <para>The default template identifier to associate with the notify configuration. If specified,
        /// this template is used when sending messages without an explicit template identifier.
        /// Pass the special value <c>UNSET_DEFAULT_TEMPLATE</c> to clear the current default
        /// template from the notify configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultTemplateId { get; set; }
        #endregion
        
        #region Parameter DeletionProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>When set to true the notify configuration can't be deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter EnabledChannel
        /// <summary>
        /// <para>
        /// <para>An array of channels to enable for the notify configuration. Supported values include
        /// <c>SMS</c> and <c>VOICE</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnabledChannels")]
        public System.String[] EnabledChannel { get; set; }
        #endregion
        
        #region Parameter EnabledCountry
        /// <summary>
        /// <para>
        /// <para>An array of two-character ISO country codes, in ISO 3166-1 alpha-2 format, that are
        /// enabled for the notify configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnabledCountries")]
        public System.String[] EnabledCountry { get; set; }
        #endregion
        
        #region Parameter NotifyConfigurationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the notify configuration to update. The NotifyConfigurationId can
        /// be found using the <a>DescribeNotifyConfigurations</a> operation.</para>
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
        public System.String NotifyConfigurationId { get; set; }
        #endregion
        
        #region Parameter PoolId
        /// <summary>
        /// <para>
        /// <para>The pool identifier or Amazon Resource Name (ARN) to associate with the notify configuration.
        /// Pass the special value <c>UNSET_DEFAULT_POOL_FOR_NOTIFY</c> to clear the current default
        /// pool from the notify configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NotifyConfigurationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMSVNotifyConfiguration (UpdateNotifyConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationResponse, UpdateSMSVNotifyConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefaultTemplateId = this.DefaultTemplateId;
            context.DeletionProtectionEnabled = this.DeletionProtectionEnabled;
            if (this.EnabledChannel != null)
            {
                context.EnabledChannel = new List<System.String>(this.EnabledChannel);
            }
            if (this.EnabledCountry != null)
            {
                context.EnabledCountry = new List<System.String>(this.EnabledCountry);
            }
            context.NotifyConfigurationId = this.NotifyConfigurationId;
            #if MODULAR
            if (this.NotifyConfigurationId == null && ParameterWasBound(nameof(this.NotifyConfigurationId)))
            {
                WriteWarning("You are passing $null as a value for parameter NotifyConfigurationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PoolId = this.PoolId;
            
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationRequest();
            
            if (cmdletContext.DefaultTemplateId != null)
            {
                request.DefaultTemplateId = cmdletContext.DefaultTemplateId;
            }
            if (cmdletContext.DeletionProtectionEnabled != null)
            {
                request.DeletionProtectionEnabled = cmdletContext.DeletionProtectionEnabled.Value;
            }
            if (cmdletContext.EnabledChannel != null)
            {
                request.EnabledChannels = cmdletContext.EnabledChannel;
            }
            if (cmdletContext.EnabledCountry != null)
            {
                request.EnabledCountries = cmdletContext.EnabledCountry;
            }
            if (cmdletContext.NotifyConfigurationId != null)
            {
                request.NotifyConfigurationId = cmdletContext.NotifyConfigurationId;
            }
            if (cmdletContext.PoolId != null)
            {
                request.PoolId = cmdletContext.PoolId;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "UpdateNotifyConfiguration");
            try
            {
                return client.UpdateNotifyConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DefaultTemplateId { get; set; }
            public System.Boolean? DeletionProtectionEnabled { get; set; }
            public List<System.String> EnabledChannel { get; set; }
            public List<System.String> EnabledCountry { get; set; }
            public System.String NotifyConfigurationId { get; set; }
            public System.String PoolId { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.UpdateNotifyConfigurationResponse, UpdateSMSVNotifyConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
