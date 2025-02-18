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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Updates a worker.
    /// </summary>
    [Cmdlet("Update", "ADCWorker", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Deadline.Model.LogConfiguration")]
    [AWSCmdlet("Calls the AWSDeadlineCloud UpdateWorker API operation.", Operation = new[] {"UpdateWorker"}, SelectReturnType = typeof(Amazon.Deadline.Model.UpdateWorkerResponse))]
    [AWSCmdletOutput("Amazon.Deadline.Model.LogConfiguration or Amazon.Deadline.Model.UpdateWorkerResponse",
        "This cmdlet returns an Amazon.Deadline.Model.LogConfiguration object.",
        "The service call response (type Amazon.Deadline.Model.UpdateWorkerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateADCWorkerCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Capabilities_Amount
        /// <summary>
        /// <para>
        /// <para>The worker capabilities amounts on a list of worker capabilities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_Amounts")]
        public Amazon.Deadline.Model.WorkerAmountCapability[] Capabilities_Amount { get; set; }
        #endregion
        
        #region Parameter Capabilities_Attribute
        /// <summary>
        /// <para>
        /// <para>The worker attribute capabilities in the list of attribute capabilities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_Attributes")]
        public Amazon.Deadline.Model.WorkerAttributeCapability[] Capabilities_Attribute { get; set; }
        #endregion
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The farm ID to update.</para>
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
        public System.String FarmId { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>The fleet ID to update.</para>
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
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter HostProperties_HostName
        /// <summary>
        /// <para>
        /// <para>The host name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostProperties_HostName { get; set; }
        #endregion
        
        #region Parameter IpAddresses_IpV4Address
        /// <summary>
        /// <para>
        /// <para>The IpV4 address of the network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HostProperties_IpAddresses_IpV4Addresses")]
        public System.String[] IpAddresses_IpV4Address { get; set; }
        #endregion
        
        #region Parameter IpAddresses_IpV6Address
        /// <summary>
        /// <para>
        /// <para>The IpV6 address for the network and node component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HostProperties_IpAddresses_IpV6Addresses")]
        public System.String[] IpAddresses_IpV6Address { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The worker status to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.UpdatedWorkerStatus")]
        public Amazon.Deadline.UpdatedWorkerStatus Status { get; set; }
        #endregion
        
        #region Parameter WorkerId
        /// <summary>
        /// <para>
        /// <para>The worker ID to update.</para>
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
        public System.String WorkerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Log'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.UpdateWorkerResponse).
        /// Specifying the name of a property of type Amazon.Deadline.Model.UpdateWorkerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Log";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ADCWorker (UpdateWorker)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.UpdateWorkerResponse, UpdateADCWorkerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Capabilities_Amount != null)
            {
                context.Capabilities_Amount = new List<Amazon.Deadline.Model.WorkerAmountCapability>(this.Capabilities_Amount);
            }
            if (this.Capabilities_Attribute != null)
            {
                context.Capabilities_Attribute = new List<Amazon.Deadline.Model.WorkerAttributeCapability>(this.Capabilities_Attribute);
            }
            context.FarmId = this.FarmId;
            #if MODULAR
            if (this.FarmId == null && ParameterWasBound(nameof(this.FarmId)))
            {
                WriteWarning("You are passing $null as a value for parameter FarmId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HostProperties_HostName = this.HostProperties_HostName;
            if (this.IpAddresses_IpV4Address != null)
            {
                context.IpAddresses_IpV4Address = new List<System.String>(this.IpAddresses_IpV4Address);
            }
            if (this.IpAddresses_IpV6Address != null)
            {
                context.IpAddresses_IpV6Address = new List<System.String>(this.IpAddresses_IpV6Address);
            }
            context.Status = this.Status;
            context.WorkerId = this.WorkerId;
            #if MODULAR
            if (this.WorkerId == null && ParameterWasBound(nameof(this.WorkerId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Deadline.Model.UpdateWorkerRequest();
            
            
             // populate Capabilities
            var requestCapabilitiesIsNull = true;
            request.Capabilities = new Amazon.Deadline.Model.WorkerCapabilities();
            List<Amazon.Deadline.Model.WorkerAmountCapability> requestCapabilities_capabilities_Amount = null;
            if (cmdletContext.Capabilities_Amount != null)
            {
                requestCapabilities_capabilities_Amount = cmdletContext.Capabilities_Amount;
            }
            if (requestCapabilities_capabilities_Amount != null)
            {
                request.Capabilities.Amounts = requestCapabilities_capabilities_Amount;
                requestCapabilitiesIsNull = false;
            }
            List<Amazon.Deadline.Model.WorkerAttributeCapability> requestCapabilities_capabilities_Attribute = null;
            if (cmdletContext.Capabilities_Attribute != null)
            {
                requestCapabilities_capabilities_Attribute = cmdletContext.Capabilities_Attribute;
            }
            if (requestCapabilities_capabilities_Attribute != null)
            {
                request.Capabilities.Attributes = requestCapabilities_capabilities_Attribute;
                requestCapabilitiesIsNull = false;
            }
             // determine if request.Capabilities should be set to null
            if (requestCapabilitiesIsNull)
            {
                request.Capabilities = null;
            }
            if (cmdletContext.FarmId != null)
            {
                request.FarmId = cmdletContext.FarmId;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            
             // populate HostProperties
            var requestHostPropertiesIsNull = true;
            request.HostProperties = new Amazon.Deadline.Model.HostPropertiesRequest();
            System.String requestHostProperties_hostProperties_HostName = null;
            if (cmdletContext.HostProperties_HostName != null)
            {
                requestHostProperties_hostProperties_HostName = cmdletContext.HostProperties_HostName;
            }
            if (requestHostProperties_hostProperties_HostName != null)
            {
                request.HostProperties.HostName = requestHostProperties_hostProperties_HostName;
                requestHostPropertiesIsNull = false;
            }
            Amazon.Deadline.Model.IpAddresses requestHostProperties_hostProperties_IpAddresses = null;
            
             // populate IpAddresses
            var requestHostProperties_hostProperties_IpAddressesIsNull = true;
            requestHostProperties_hostProperties_IpAddresses = new Amazon.Deadline.Model.IpAddresses();
            List<System.String> requestHostProperties_hostProperties_IpAddresses_ipAddresses_IpV4Address = null;
            if (cmdletContext.IpAddresses_IpV4Address != null)
            {
                requestHostProperties_hostProperties_IpAddresses_ipAddresses_IpV4Address = cmdletContext.IpAddresses_IpV4Address;
            }
            if (requestHostProperties_hostProperties_IpAddresses_ipAddresses_IpV4Address != null)
            {
                requestHostProperties_hostProperties_IpAddresses.IpV4Addresses = requestHostProperties_hostProperties_IpAddresses_ipAddresses_IpV4Address;
                requestHostProperties_hostProperties_IpAddressesIsNull = false;
            }
            List<System.String> requestHostProperties_hostProperties_IpAddresses_ipAddresses_IpV6Address = null;
            if (cmdletContext.IpAddresses_IpV6Address != null)
            {
                requestHostProperties_hostProperties_IpAddresses_ipAddresses_IpV6Address = cmdletContext.IpAddresses_IpV6Address;
            }
            if (requestHostProperties_hostProperties_IpAddresses_ipAddresses_IpV6Address != null)
            {
                requestHostProperties_hostProperties_IpAddresses.IpV6Addresses = requestHostProperties_hostProperties_IpAddresses_ipAddresses_IpV6Address;
                requestHostProperties_hostProperties_IpAddressesIsNull = false;
            }
             // determine if requestHostProperties_hostProperties_IpAddresses should be set to null
            if (requestHostProperties_hostProperties_IpAddressesIsNull)
            {
                requestHostProperties_hostProperties_IpAddresses = null;
            }
            if (requestHostProperties_hostProperties_IpAddresses != null)
            {
                request.HostProperties.IpAddresses = requestHostProperties_hostProperties_IpAddresses;
                requestHostPropertiesIsNull = false;
            }
             // determine if request.HostProperties should be set to null
            if (requestHostPropertiesIsNull)
            {
                request.HostProperties = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.WorkerId != null)
            {
                request.WorkerId = cmdletContext.WorkerId;
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
        
        private Amazon.Deadline.Model.UpdateWorkerResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.UpdateWorkerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "UpdateWorker");
            try
            {
                return client.UpdateWorkerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Deadline.Model.WorkerAmountCapability> Capabilities_Amount { get; set; }
            public List<Amazon.Deadline.Model.WorkerAttributeCapability> Capabilities_Attribute { get; set; }
            public System.String FarmId { get; set; }
            public System.String FleetId { get; set; }
            public System.String HostProperties_HostName { get; set; }
            public List<System.String> IpAddresses_IpV4Address { get; set; }
            public List<System.String> IpAddresses_IpV6Address { get; set; }
            public Amazon.Deadline.UpdatedWorkerStatus Status { get; set; }
            public System.String WorkerId { get; set; }
            public System.Func<Amazon.Deadline.Model.UpdateWorkerResponse, UpdateADCWorkerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Log;
        }
        
    }
}
