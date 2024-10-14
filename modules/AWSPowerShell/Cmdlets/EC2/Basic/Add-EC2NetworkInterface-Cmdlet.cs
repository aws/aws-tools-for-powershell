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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Attaches a network interface to an instance.
    /// </summary>
    [Cmdlet("Add", "EC2NetworkInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AttachNetworkInterface API operation.", Operation = new[] {"AttachNetworkInterface"}, SelectReturnType = typeof(Amazon.EC2.Model.AttachNetworkInterfaceResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.AttachNetworkInterfaceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.AttachNetworkInterfaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddEC2NetworkInterfaceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeviceIndex
        /// <summary>
        /// <para>
        /// <para>The index of the device for the network interface attachment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? DeviceIndex { get; set; }
        #endregion
        
        #region Parameter EnaSrdSpecification_EnaSrdEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether ENA Express is enabled for the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnaSrdSpecification_EnaSrdEnabled { get; set; }
        #endregion
        
        #region Parameter EnaSrdUdpSpecification_EnaSrdUdpEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether UDP traffic to and from the instance uses ENA Express. To specify
        /// this setting, you must first enable ENA Express.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnaSrdSpecification_EnaSrdUdpSpecification_EnaSrdUdpEnabled")]
        public System.Boolean? EnaSrdUdpSpecification_EnaSrdUdpEnabled { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter NetworkCardIndex
        /// <summary>
        /// <para>
        /// <para>The index of the network card. Some instance types support multiple network cards.
        /// The primary network interface must be assigned to network card index 0. The default
        /// is network card index 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NetworkCardIndex { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AttachmentId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AttachNetworkInterfaceResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AttachNetworkInterfaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AttachmentId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EC2NetworkInterface (AttachNetworkInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AttachNetworkInterfaceResponse, AddEC2NetworkInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeviceIndex = this.DeviceIndex;
            #if MODULAR
            if (this.DeviceIndex == null && ParameterWasBound(nameof(this.DeviceIndex)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceIndex which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnaSrdSpecification_EnaSrdEnabled = this.EnaSrdSpecification_EnaSrdEnabled;
            context.EnaSrdUdpSpecification_EnaSrdUdpEnabled = this.EnaSrdUdpSpecification_EnaSrdUdpEnabled;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkCardIndex = this.NetworkCardIndex;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            #if MODULAR
            if (this.NetworkInterfaceId == null && ParameterWasBound(nameof(this.NetworkInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.AttachNetworkInterfaceRequest();
            
            if (cmdletContext.DeviceIndex != null)
            {
                request.DeviceIndex = cmdletContext.DeviceIndex.Value;
            }
            
             // populate EnaSrdSpecification
            var requestEnaSrdSpecificationIsNull = true;
            request.EnaSrdSpecification = new Amazon.EC2.Model.EnaSrdSpecification();
            System.Boolean? requestEnaSrdSpecification_enaSrdSpecification_EnaSrdEnabled = null;
            if (cmdletContext.EnaSrdSpecification_EnaSrdEnabled != null)
            {
                requestEnaSrdSpecification_enaSrdSpecification_EnaSrdEnabled = cmdletContext.EnaSrdSpecification_EnaSrdEnabled.Value;
            }
            if (requestEnaSrdSpecification_enaSrdSpecification_EnaSrdEnabled != null)
            {
                request.EnaSrdSpecification.EnaSrdEnabled = requestEnaSrdSpecification_enaSrdSpecification_EnaSrdEnabled.Value;
                requestEnaSrdSpecificationIsNull = false;
            }
            Amazon.EC2.Model.EnaSrdUdpSpecification requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification = null;
            
             // populate EnaSrdUdpSpecification
            var requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecificationIsNull = true;
            requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification = new Amazon.EC2.Model.EnaSrdUdpSpecification();
            System.Boolean? requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification_enaSrdUdpSpecification_EnaSrdUdpEnabled = null;
            if (cmdletContext.EnaSrdUdpSpecification_EnaSrdUdpEnabled != null)
            {
                requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification_enaSrdUdpSpecification_EnaSrdUdpEnabled = cmdletContext.EnaSrdUdpSpecification_EnaSrdUdpEnabled.Value;
            }
            if (requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification_enaSrdUdpSpecification_EnaSrdUdpEnabled != null)
            {
                requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification.EnaSrdUdpEnabled = requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification_enaSrdUdpSpecification_EnaSrdUdpEnabled.Value;
                requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecificationIsNull = false;
            }
             // determine if requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification should be set to null
            if (requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecificationIsNull)
            {
                requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification = null;
            }
            if (requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification != null)
            {
                request.EnaSrdSpecification.EnaSrdUdpSpecification = requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification;
                requestEnaSrdSpecificationIsNull = false;
            }
             // determine if request.EnaSrdSpecification should be set to null
            if (requestEnaSrdSpecificationIsNull)
            {
                request.EnaSrdSpecification = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.NetworkCardIndex != null)
            {
                request.NetworkCardIndex = cmdletContext.NetworkCardIndex.Value;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
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
        
        private Amazon.EC2.Model.AttachNetworkInterfaceResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AttachNetworkInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AttachNetworkInterface");
            try
            {
                #if DESKTOP
                return client.AttachNetworkInterface(request);
                #elif CORECLR
                return client.AttachNetworkInterfaceAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DeviceIndex { get; set; }
            public System.Boolean? EnaSrdSpecification_EnaSrdEnabled { get; set; }
            public System.Boolean? EnaSrdUdpSpecification_EnaSrdUdpEnabled { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int32? NetworkCardIndex { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.Func<Amazon.EC2.Model.AttachNetworkInterfaceResponse, AddEC2NetworkInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AttachmentId;
        }
        
    }
}
