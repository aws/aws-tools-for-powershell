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
using Amazon.Route53RecoveryControlConfig;
using Amazon.Route53RecoveryControlConfig.Model;

namespace Amazon.PowerShell.Cmdlets.R53RC
{
    /// <summary>
    /// Updates a control panel. The only update you can make to a control panel is to change
    /// the name of the control panel.
    /// </summary>
    [Cmdlet("Update", "R53RCControlPanel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53RecoveryControlConfig.Model.ControlPanel")]
    [AWSCmdlet("Calls the AWS Route53 Recovery Control Config UpdateControlPanel API operation.", Operation = new[] {"UpdateControlPanel"}, SelectReturnType = typeof(Amazon.Route53RecoveryControlConfig.Model.UpdateControlPanelResponse))]
    [AWSCmdletOutput("Amazon.Route53RecoveryControlConfig.Model.ControlPanel or Amazon.Route53RecoveryControlConfig.Model.UpdateControlPanelResponse",
        "This cmdlet returns an Amazon.Route53RecoveryControlConfig.Model.ControlPanel object.",
        "The service call response (type Amazon.Route53RecoveryControlConfig.Model.UpdateControlPanelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateR53RCControlPanelCmdlet : AmazonRoute53RecoveryControlConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ControlPanelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the control panel.</para>
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
        public System.String ControlPanelArn { get; set; }
        #endregion
        
        #region Parameter ControlPanelName
        /// <summary>
        /// <para>
        /// <para>The name of the control panel.</para>
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
        public System.String ControlPanelName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ControlPanel'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryControlConfig.Model.UpdateControlPanelResponse).
        /// Specifying the name of a property of type Amazon.Route53RecoveryControlConfig.Model.UpdateControlPanelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ControlPanel";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ControlPanelArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53RCControlPanel (UpdateControlPanel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryControlConfig.Model.UpdateControlPanelResponse, UpdateR53RCControlPanelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ControlPanelArn = this.ControlPanelArn;
            #if MODULAR
            if (this.ControlPanelArn == null && ParameterWasBound(nameof(this.ControlPanelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ControlPanelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ControlPanelName = this.ControlPanelName;
            #if MODULAR
            if (this.ControlPanelName == null && ParameterWasBound(nameof(this.ControlPanelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ControlPanelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53RecoveryControlConfig.Model.UpdateControlPanelRequest();
            
            if (cmdletContext.ControlPanelArn != null)
            {
                request.ControlPanelArn = cmdletContext.ControlPanelArn;
            }
            if (cmdletContext.ControlPanelName != null)
            {
                request.ControlPanelName = cmdletContext.ControlPanelName;
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
        
        private Amazon.Route53RecoveryControlConfig.Model.UpdateControlPanelResponse CallAWSServiceOperation(IAmazonRoute53RecoveryControlConfig client, Amazon.Route53RecoveryControlConfig.Model.UpdateControlPanelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route53 Recovery Control Config", "UpdateControlPanel");
            try
            {
                return client.UpdateControlPanelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ControlPanelArn { get; set; }
            public System.String ControlPanelName { get; set; }
            public System.Func<Amazon.Route53RecoveryControlConfig.Model.UpdateControlPanelResponse, UpdateR53RCControlPanelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ControlPanel;
        }
        
    }
}
