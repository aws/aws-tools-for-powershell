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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Start a maintenance window for the specified input device. Starting a maintenance
    /// window will give the device up to two hours to install software. If the device was
    /// streaming prior to the maintenance, it will resume streaming when the software is
    /// fully installed. Devices automatically install updates while they are powered on and
    /// their MediaLive channels are stopped. A maintenance window allows you to update a
    /// device without having to stop MediaLive channels that use the device. The device must
    /// remain powered on and connected to the internet for the duration of the maintenance.
    /// </summary>
    [Cmdlet("Start", "EMLInputDeviceMaintenanceWindow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive StartInputDeviceMaintenanceWindow API operation.", Operation = new[] {"StartInputDeviceMaintenanceWindow"}, SelectReturnType = typeof(Amazon.MediaLive.Model.StartInputDeviceMaintenanceWindowResponse))]
    [AWSCmdletOutput("None or Amazon.MediaLive.Model.StartInputDeviceMaintenanceWindowResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MediaLive.Model.StartInputDeviceMaintenanceWindowResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartEMLInputDeviceMaintenanceWindowCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InputDeviceId
        /// <summary>
        /// <para>
        /// The unique ID of the input device to start
        /// a maintenance window for. For example, hd-123456789abcdef.
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
        public System.String InputDeviceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.StartInputDeviceMaintenanceWindowResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InputDeviceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EMLInputDeviceMaintenanceWindow (StartInputDeviceMaintenanceWindow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.StartInputDeviceMaintenanceWindowResponse, StartEMLInputDeviceMaintenanceWindowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InputDeviceId = this.InputDeviceId;
            #if MODULAR
            if (this.InputDeviceId == null && ParameterWasBound(nameof(this.InputDeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaLive.Model.StartInputDeviceMaintenanceWindowRequest();
            
            if (cmdletContext.InputDeviceId != null)
            {
                request.InputDeviceId = cmdletContext.InputDeviceId;
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
        
        private Amazon.MediaLive.Model.StartInputDeviceMaintenanceWindowResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.StartInputDeviceMaintenanceWindowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "StartInputDeviceMaintenanceWindow");
            try
            {
                #if DESKTOP
                return client.StartInputDeviceMaintenanceWindow(request);
                #elif CORECLR
                return client.StartInputDeviceMaintenanceWindowAsync(request).GetAwaiter().GetResult();
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
            public System.String InputDeviceId { get; set; }
            public System.Func<Amazon.MediaLive.Model.StartInputDeviceMaintenanceWindowResponse, StartEMLInputDeviceMaintenanceWindowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
