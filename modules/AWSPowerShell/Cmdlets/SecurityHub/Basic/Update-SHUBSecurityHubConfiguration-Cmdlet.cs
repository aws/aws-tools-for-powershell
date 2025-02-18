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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Updates configuration options for Security Hub.
    /// </summary>
    [Cmdlet("Update", "SHUBSecurityHubConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Hub UpdateSecurityHubConfiguration API operation.", Operation = new[] {"UpdateSecurityHubConfiguration"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.UpdateSecurityHubConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityHub.Model.UpdateSecurityHubConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityHub.Model.UpdateSecurityHubConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSHUBSecurityHubConfigurationCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoEnableControl
        /// <summary>
        /// <para>
        /// <para>Whether to automatically enable new controls when they are added to standards that
        /// are enabled.</para><para>By default, this is set to <c>true</c>, and new controls are enabled automatically.
        /// To not automatically enable new controls, set this to <c>false</c>. </para><para>When you automatically enable new controls, you can interact with the controls in
        /// the console and programmatically immediately after release. However, automatically
        /// enabled controls have a temporary default status of <c>DISABLED</c>. It can take up
        /// to several days for Security Hub to process the control release and designate the
        /// control as <c>ENABLED</c> in your account. During the processing period, you can manually
        /// enable or disable a control, and Security Hub will maintain that designation regardless
        /// of whether you have <c>AutoEnableControls</c> set to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("AutoEnableControls")]
        public System.Boolean? AutoEnableControl { get; set; }
        #endregion
        
        #region Parameter ControlFindingGenerator
        /// <summary>
        /// <para>
        /// <para>Updates whether the calling account has consolidated control findings turned on. If
        /// the value for this field is set to <c>SECURITY_CONTROL</c>, Security Hub generates
        /// a single finding for a control check even when the check applies to multiple enabled
        /// standards.</para><para>If the value for this field is set to <c>STANDARD_CONTROL</c>, Security Hub generates
        /// separate findings for a control check when the check applies to multiple enabled standards.</para><para>For accounts that are part of an organization, this value can only be updated in the
        /// administrator account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.ControlFindingGenerator")]
        public Amazon.SecurityHub.ControlFindingGenerator ControlFindingGenerator { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.UpdateSecurityHubConfigurationResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoEnableControl), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHUBSecurityHubConfiguration (UpdateSecurityHubConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.UpdateSecurityHubConfigurationResponse, UpdateSHUBSecurityHubConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoEnableControl = this.AutoEnableControl;
            context.ControlFindingGenerator = this.ControlFindingGenerator;
            
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
            var request = new Amazon.SecurityHub.Model.UpdateSecurityHubConfigurationRequest();
            
            if (cmdletContext.AutoEnableControl != null)
            {
                request.AutoEnableControls = cmdletContext.AutoEnableControl.Value;
            }
            if (cmdletContext.ControlFindingGenerator != null)
            {
                request.ControlFindingGenerator = cmdletContext.ControlFindingGenerator;
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
        
        private Amazon.SecurityHub.Model.UpdateSecurityHubConfigurationResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.UpdateSecurityHubConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "UpdateSecurityHubConfiguration");
            try
            {
                return client.UpdateSecurityHubConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AutoEnableControl { get; set; }
            public Amazon.SecurityHub.ControlFindingGenerator ControlFindingGenerator { get; set; }
            public System.Func<Amazon.SecurityHub.Model.UpdateSecurityHubConfigurationResponse, UpdateSHUBSecurityHubConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
