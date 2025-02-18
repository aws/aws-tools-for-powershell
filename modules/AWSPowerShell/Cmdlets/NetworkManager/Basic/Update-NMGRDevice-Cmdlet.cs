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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Updates the details for an existing device. To remove information for any of the parameters,
    /// specify an empty string.
    /// </summary>
    [Cmdlet("Update", "NMGRDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.Device")]
    [AWSCmdlet("Calls the AWS Network Manager UpdateDevice API operation.", Operation = new[] {"UpdateDevice"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.UpdateDeviceResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.Device or Amazon.NetworkManager.Model.UpdateDeviceResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.Device object.",
        "The service call response (type Amazon.NetworkManager.Model.UpdateDeviceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateNMGRDeviceCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Location_Address
        /// <summary>
        /// <para>
        /// <para>The physical address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_Address { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the device.</para><para>Constraints: Maximum length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DeviceId
        /// <summary>
        /// <para>
        /// <para>The ID of the device.</para>
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
        public System.String DeviceId { get; set; }
        #endregion
        
        #region Parameter GlobalNetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the global network.</para>
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
        public System.String GlobalNetworkId { get; set; }
        #endregion
        
        #region Parameter Location_Latitude
        /// <summary>
        /// <para>
        /// <para>The latitude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_Latitude { get; set; }
        #endregion
        
        #region Parameter Location_Longitude
        /// <summary>
        /// <para>
        /// <para>The longitude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location_Longitude { get; set; }
        #endregion
        
        #region Parameter Model
        /// <summary>
        /// <para>
        /// <para>The model of the device.</para><para>Constraints: Maximum length of 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model { get; set; }
        #endregion
        
        #region Parameter SerialNumber
        /// <summary>
        /// <para>
        /// <para>The serial number of the device.</para><para>Constraints: Maximum length of 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SerialNumber { get; set; }
        #endregion
        
        #region Parameter SiteId
        /// <summary>
        /// <para>
        /// <para>The ID of the site.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SiteId { get; set; }
        #endregion
        
        #region Parameter AWSLocation_SubnetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the subnet that the device is located in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AWSLocation_SubnetArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Type { get; set; }
        #endregion
        
        #region Parameter Vendor
        /// <summary>
        /// <para>
        /// <para>The vendor of the device.</para><para>Constraints: Maximum length of 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Vendor { get; set; }
        #endregion
        
        #region Parameter AWSLocation_Zone
        /// <summary>
        /// <para>
        /// <para>The Zone that the device is located in. Specify the ID of an Availability Zone, Local
        /// Zone, Wavelength Zone, or an Outpost.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AWSLocation_Zone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Device'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.UpdateDeviceResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.UpdateDeviceResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeviceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NMGRDevice (UpdateDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.UpdateDeviceResponse, UpdateNMGRDeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AWSLocation_SubnetArn = this.AWSLocation_SubnetArn;
            context.AWSLocation_Zone = this.AWSLocation_Zone;
            context.Description = this.Description;
            context.DeviceId = this.DeviceId;
            #if MODULAR
            if (this.DeviceId == null && ParameterWasBound(nameof(this.DeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GlobalNetworkId = this.GlobalNetworkId;
            #if MODULAR
            if (this.GlobalNetworkId == null && ParameterWasBound(nameof(this.GlobalNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Location_Address = this.Location_Address;
            context.Location_Latitude = this.Location_Latitude;
            context.Location_Longitude = this.Location_Longitude;
            context.Model = this.Model;
            context.SerialNumber = this.SerialNumber;
            context.SiteId = this.SiteId;
            context.Type = this.Type;
            context.Vendor = this.Vendor;
            
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
            var request = new Amazon.NetworkManager.Model.UpdateDeviceRequest();
            
            
             // populate AWSLocation
            var requestAWSLocationIsNull = true;
            request.AWSLocation = new Amazon.NetworkManager.Model.AWSLocation();
            System.String requestAWSLocation_aWSLocation_SubnetArn = null;
            if (cmdletContext.AWSLocation_SubnetArn != null)
            {
                requestAWSLocation_aWSLocation_SubnetArn = cmdletContext.AWSLocation_SubnetArn;
            }
            if (requestAWSLocation_aWSLocation_SubnetArn != null)
            {
                request.AWSLocation.SubnetArn = requestAWSLocation_aWSLocation_SubnetArn;
                requestAWSLocationIsNull = false;
            }
            System.String requestAWSLocation_aWSLocation_Zone = null;
            if (cmdletContext.AWSLocation_Zone != null)
            {
                requestAWSLocation_aWSLocation_Zone = cmdletContext.AWSLocation_Zone;
            }
            if (requestAWSLocation_aWSLocation_Zone != null)
            {
                request.AWSLocation.Zone = requestAWSLocation_aWSLocation_Zone;
                requestAWSLocationIsNull = false;
            }
             // determine if request.AWSLocation should be set to null
            if (requestAWSLocationIsNull)
            {
                request.AWSLocation = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DeviceId != null)
            {
                request.DeviceId = cmdletContext.DeviceId;
            }
            if (cmdletContext.GlobalNetworkId != null)
            {
                request.GlobalNetworkId = cmdletContext.GlobalNetworkId;
            }
            
             // populate Location
            var requestLocationIsNull = true;
            request.Location = new Amazon.NetworkManager.Model.Location();
            System.String requestLocation_location_Address = null;
            if (cmdletContext.Location_Address != null)
            {
                requestLocation_location_Address = cmdletContext.Location_Address;
            }
            if (requestLocation_location_Address != null)
            {
                request.Location.Address = requestLocation_location_Address;
                requestLocationIsNull = false;
            }
            System.String requestLocation_location_Latitude = null;
            if (cmdletContext.Location_Latitude != null)
            {
                requestLocation_location_Latitude = cmdletContext.Location_Latitude;
            }
            if (requestLocation_location_Latitude != null)
            {
                request.Location.Latitude = requestLocation_location_Latitude;
                requestLocationIsNull = false;
            }
            System.String requestLocation_location_Longitude = null;
            if (cmdletContext.Location_Longitude != null)
            {
                requestLocation_location_Longitude = cmdletContext.Location_Longitude;
            }
            if (requestLocation_location_Longitude != null)
            {
                request.Location.Longitude = requestLocation_location_Longitude;
                requestLocationIsNull = false;
            }
             // determine if request.Location should be set to null
            if (requestLocationIsNull)
            {
                request.Location = null;
            }
            if (cmdletContext.Model != null)
            {
                request.Model = cmdletContext.Model;
            }
            if (cmdletContext.SerialNumber != null)
            {
                request.SerialNumber = cmdletContext.SerialNumber;
            }
            if (cmdletContext.SiteId != null)
            {
                request.SiteId = cmdletContext.SiteId;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.Vendor != null)
            {
                request.Vendor = cmdletContext.Vendor;
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
        
        private Amazon.NetworkManager.Model.UpdateDeviceResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.UpdateDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "UpdateDevice");
            try
            {
                return client.UpdateDeviceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AWSLocation_SubnetArn { get; set; }
            public System.String AWSLocation_Zone { get; set; }
            public System.String Description { get; set; }
            public System.String DeviceId { get; set; }
            public System.String GlobalNetworkId { get; set; }
            public System.String Location_Address { get; set; }
            public System.String Location_Latitude { get; set; }
            public System.String Location_Longitude { get; set; }
            public System.String Model { get; set; }
            public System.String SerialNumber { get; set; }
            public System.String SiteId { get; set; }
            public System.String Type { get; set; }
            public System.String Vendor { get; set; }
            public System.Func<Amazon.NetworkManager.Model.UpdateDeviceResponse, UpdateNMGRDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Device;
        }
        
    }
}
