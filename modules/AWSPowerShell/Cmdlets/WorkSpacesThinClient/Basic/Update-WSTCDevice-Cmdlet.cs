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
using Amazon.WorkSpacesThinClient;
using Amazon.WorkSpacesThinClient.Model;

namespace Amazon.PowerShell.Cmdlets.WSTC
{
    /// <summary>
    /// Updates a thin client device.
    /// </summary>
    [Cmdlet("Update", "WSTCDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpacesThinClient.Model.DeviceSummary")]
    [AWSCmdlet("Calls the Amazon WorkSpaces Thin Client UpdateDevice API operation.", Operation = new[] {"UpdateDevice"}, SelectReturnType = typeof(Amazon.WorkSpacesThinClient.Model.UpdateDeviceResponse))]
    [AWSCmdletOutput("Amazon.WorkSpacesThinClient.Model.DeviceSummary or Amazon.WorkSpacesThinClient.Model.UpdateDeviceResponse",
        "This cmdlet returns an Amazon.WorkSpacesThinClient.Model.DeviceSummary object.",
        "The service call response (type Amazon.WorkSpacesThinClient.Model.UpdateDeviceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWSTCDeviceCmdlet : AmazonWorkSpacesThinClientClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DesiredSoftwareSetId
        /// <summary>
        /// <para>
        /// <para>The ID of the software set to apply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DesiredSoftwareSetId { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the device to update.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the device to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SoftwareSetUpdateSchedule
        /// <summary>
        /// <para>
        /// <para>An option to define if software updates should be applied within a maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpacesThinClient.SoftwareSetUpdateSchedule")]
        public Amazon.WorkSpacesThinClient.SoftwareSetUpdateSchedule SoftwareSetUpdateSchedule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Device'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpacesThinClient.Model.UpdateDeviceResponse).
        /// Specifying the name of a property of type Amazon.WorkSpacesThinClient.Model.UpdateDeviceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Device";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WSTCDevice (UpdateDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpacesThinClient.Model.UpdateDeviceResponse, UpdateWSTCDeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DesiredSoftwareSetId = this.DesiredSoftwareSetId;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.SoftwareSetUpdateSchedule = this.SoftwareSetUpdateSchedule;
            
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
            var request = new Amazon.WorkSpacesThinClient.Model.UpdateDeviceRequest();
            
            if (cmdletContext.DesiredSoftwareSetId != null)
            {
                request.DesiredSoftwareSetId = cmdletContext.DesiredSoftwareSetId;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SoftwareSetUpdateSchedule != null)
            {
                request.SoftwareSetUpdateSchedule = cmdletContext.SoftwareSetUpdateSchedule;
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
        
        private Amazon.WorkSpacesThinClient.Model.UpdateDeviceResponse CallAWSServiceOperation(IAmazonWorkSpacesThinClient client, Amazon.WorkSpacesThinClient.Model.UpdateDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces Thin Client", "UpdateDevice");
            try
            {
                #if DESKTOP
                return client.UpdateDevice(request);
                #elif CORECLR
                return client.UpdateDeviceAsync(request).GetAwaiter().GetResult();
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
            public System.String DesiredSoftwareSetId { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public Amazon.WorkSpacesThinClient.SoftwareSetUpdateSchedule SoftwareSetUpdateSchedule { get; set; }
            public System.Func<Amazon.WorkSpacesThinClient.Model.UpdateDeviceResponse, UpdateWSTCDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Device;
        }
        
    }
}
