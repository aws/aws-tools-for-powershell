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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Enables Allowed AMIs for your account in the specified Amazon Web Services Region.
    /// Two values are accepted:
    /// 
    ///  <ul><li><para><c>enabled</c>: The image criteria in your Allowed AMIs settings are applied. As
    /// a result, only AMIs matching these criteria are discoverable and can be used by your
    /// account to launch instances.
    /// </para></li><li><para><c>audit-mode</c>: The image criteria in your Allowed AMIs settings are not applied.
    /// No restrictions are placed on AMI discoverability or usage. Users in your account
    /// can launch instances using any public AMI or AMI shared with your account.
    /// </para><para>
    /// The purpose of <c>audit-mode</c> is to indicate which AMIs will be affected when Allowed
    /// AMIs is <c>enabled</c>. In <c>audit-mode</c>, each AMI displays either <c>"ImageAllowed":
    /// true</c> or <c>"ImageAllowed": false</c> to indicate whether the AMI will be discoverable
    /// and available to users in the account when Allowed AMIs is enabled.
    /// </para></li></ul><note><para>
    /// The Allowed AMIs feature does not restrict the AMIs owned by your account. Regardless
    /// of the criteria you set, the AMIs created by your account will always be discoverable
    /// and usable by users in your account.
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-allowed-amis.html">Control
    /// the discovery and use of AMIs in Amazon EC2 with Allowed AMIs</a> in <i>Amazon EC2
    /// User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "EC2AllowedImagesSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.AllowedImagesSettingsEnabledState")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) EnableAllowedImagesSettings API operation.", Operation = new[] {"EnableAllowedImagesSettings"}, SelectReturnType = typeof(Amazon.EC2.Model.EnableAllowedImagesSettingsResponse))]
    [AWSCmdletOutput("Amazon.EC2.AllowedImagesSettingsEnabledState or Amazon.EC2.Model.EnableAllowedImagesSettingsResponse",
        "This cmdlet returns an Amazon.EC2.AllowedImagesSettingsEnabledState object.",
        "The service call response (type Amazon.EC2.Model.EnableAllowedImagesSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableEC2AllowedImagesSettingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowedImagesSettingsState
        /// <summary>
        /// <para>
        /// <para>Specify <c>enabled</c> to apply the image criteria specified by the Allowed AMIs settings.
        /// Specify <c>audit-mode</c> so that you can check which AMIs will be allowed or not
        /// allowed by the image criteria.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.AllowedImagesSettingsEnabledState")]
        public Amazon.EC2.AllowedImagesSettingsEnabledState AllowedImagesSettingsState { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AllowedImagesSettingsState'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.EnableAllowedImagesSettingsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.EnableAllowedImagesSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AllowedImagesSettingsState";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AllowedImagesSettingsState parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AllowedImagesSettingsState' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AllowedImagesSettingsState' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AllowedImagesSettingsState), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-EC2AllowedImagesSetting (EnableAllowedImagesSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.EnableAllowedImagesSettingsResponse, EnableEC2AllowedImagesSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AllowedImagesSettingsState;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllowedImagesSettingsState = this.AllowedImagesSettingsState;
            #if MODULAR
            if (this.AllowedImagesSettingsState == null && ParameterWasBound(nameof(this.AllowedImagesSettingsState)))
            {
                WriteWarning("You are passing $null as a value for parameter AllowedImagesSettingsState which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.EnableAllowedImagesSettingsRequest();
            
            if (cmdletContext.AllowedImagesSettingsState != null)
            {
                request.AllowedImagesSettingsState = cmdletContext.AllowedImagesSettingsState;
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
        
        private Amazon.EC2.Model.EnableAllowedImagesSettingsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.EnableAllowedImagesSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "EnableAllowedImagesSettings");
            try
            {
                #if DESKTOP
                return client.EnableAllowedImagesSettings(request);
                #elif CORECLR
                return client.EnableAllowedImagesSettingsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.AllowedImagesSettingsEnabledState AllowedImagesSettingsState { get; set; }
            public System.Func<Amazon.EC2.Model.EnableAllowedImagesSettingsResponse, EnableEC2AllowedImagesSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AllowedImagesSettingsState;
        }
        
    }
}
