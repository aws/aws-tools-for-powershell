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
using Amazon.Panorama;
using Amazon.Panorama.Model;

namespace Amazon.PowerShell.Cmdlets.PAN
{
    /// <summary>
    /// Creates a job to run on one or more devices. A job can update a device's software
    /// or reboot it.
    /// </summary>
    [Cmdlet("New", "PANJobForDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Panorama.Model.Job")]
    [AWSCmdlet("Calls the AWS Panorama CreateJobForDevices API operation.", Operation = new[] {"CreateJobForDevices"}, SelectReturnType = typeof(Amazon.Panorama.Model.CreateJobForDevicesResponse))]
    [AWSCmdletOutput("Amazon.Panorama.Model.Job or Amazon.Panorama.Model.CreateJobForDevicesResponse",
        "This cmdlet returns a collection of Amazon.Panorama.Model.Job objects.",
        "The service call response (type Amazon.Panorama.Model.CreateJobForDevicesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPANJobForDeviceCmdlet : AmazonPanoramaClientCmdlet, IExecutor
    {
        
        #region Parameter DeviceId
        /// <summary>
        /// <para>
        /// <para>IDs of target devices.</para>
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
        [Alias("DeviceIds")]
        public System.String[] DeviceId { get; set; }
        #endregion
        
        #region Parameter OTAJobConfig_ImageVersion
        /// <summary>
        /// <para>
        /// <para>The target version of the device software.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceJobConfig_OTAJobConfig_ImageVersion")]
        public System.String OTAJobConfig_ImageVersion { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// <para>The type of job to run.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Panorama.JobType")]
        public Amazon.Panorama.JobType JobType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Jobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Panorama.Model.CreateJobForDevicesResponse).
        /// Specifying the name of a property of type Amazon.Panorama.Model.CreateJobForDevicesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Jobs";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PANJobForDevice (CreateJobForDevices)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Panorama.Model.CreateJobForDevicesResponse, NewPANJobForDeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DeviceId != null)
            {
                context.DeviceId = new List<System.String>(this.DeviceId);
            }
            #if MODULAR
            if (this.DeviceId == null && ParameterWasBound(nameof(this.DeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OTAJobConfig_ImageVersion = this.OTAJobConfig_ImageVersion;
            context.JobType = this.JobType;
            #if MODULAR
            if (this.JobType == null && ParameterWasBound(nameof(this.JobType)))
            {
                WriteWarning("You are passing $null as a value for parameter JobType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Panorama.Model.CreateJobForDevicesRequest();
            
            if (cmdletContext.DeviceId != null)
            {
                request.DeviceIds = cmdletContext.DeviceId;
            }
            
             // populate DeviceJobConfig
            var requestDeviceJobConfigIsNull = true;
            request.DeviceJobConfig = new Amazon.Panorama.Model.DeviceJobConfig();
            Amazon.Panorama.Model.OTAJobConfig requestDeviceJobConfig_deviceJobConfig_OTAJobConfig = null;
            
             // populate OTAJobConfig
            var requestDeviceJobConfig_deviceJobConfig_OTAJobConfigIsNull = true;
            requestDeviceJobConfig_deviceJobConfig_OTAJobConfig = new Amazon.Panorama.Model.OTAJobConfig();
            System.String requestDeviceJobConfig_deviceJobConfig_OTAJobConfig_oTAJobConfig_ImageVersion = null;
            if (cmdletContext.OTAJobConfig_ImageVersion != null)
            {
                requestDeviceJobConfig_deviceJobConfig_OTAJobConfig_oTAJobConfig_ImageVersion = cmdletContext.OTAJobConfig_ImageVersion;
            }
            if (requestDeviceJobConfig_deviceJobConfig_OTAJobConfig_oTAJobConfig_ImageVersion != null)
            {
                requestDeviceJobConfig_deviceJobConfig_OTAJobConfig.ImageVersion = requestDeviceJobConfig_deviceJobConfig_OTAJobConfig_oTAJobConfig_ImageVersion;
                requestDeviceJobConfig_deviceJobConfig_OTAJobConfigIsNull = false;
            }
             // determine if requestDeviceJobConfig_deviceJobConfig_OTAJobConfig should be set to null
            if (requestDeviceJobConfig_deviceJobConfig_OTAJobConfigIsNull)
            {
                requestDeviceJobConfig_deviceJobConfig_OTAJobConfig = null;
            }
            if (requestDeviceJobConfig_deviceJobConfig_OTAJobConfig != null)
            {
                request.DeviceJobConfig.OTAJobConfig = requestDeviceJobConfig_deviceJobConfig_OTAJobConfig;
                requestDeviceJobConfigIsNull = false;
            }
             // determine if request.DeviceJobConfig should be set to null
            if (requestDeviceJobConfigIsNull)
            {
                request.DeviceJobConfig = null;
            }
            if (cmdletContext.JobType != null)
            {
                request.JobType = cmdletContext.JobType;
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
        
        private Amazon.Panorama.Model.CreateJobForDevicesResponse CallAWSServiceOperation(IAmazonPanorama client, Amazon.Panorama.Model.CreateJobForDevicesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Panorama", "CreateJobForDevices");
            try
            {
                #if DESKTOP
                return client.CreateJobForDevices(request);
                #elif CORECLR
                return client.CreateJobForDevicesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DeviceId { get; set; }
            public System.String OTAJobConfig_ImageVersion { get; set; }
            public Amazon.Panorama.JobType JobType { get; set; }
            public System.Func<Amazon.Panorama.Model.CreateJobForDevicesResponse, NewPANJobForDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Jobs;
        }
        
    }
}
