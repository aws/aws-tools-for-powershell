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
    /// Associates an Elastic IP address, or carrier IP address (for instances that are in
    /// subnets in Wavelength Zones) with an instance or a network interface. Before you can
    /// use an Elastic IP address, you must allocate it to your account.
    /// 
    ///  
    /// <para>
    /// If the Elastic IP address is already associated with a different instance, it is disassociated
    /// from that instance and associated with the specified instance. If you associate an
    /// Elastic IP address with an instance that has an existing Elastic IP address, the existing
    /// address is disassociated from the instance, but remains allocated to your account.
    /// </para><para>
    /// [Subnets in Wavelength Zones] You can associate an IP address from the telecommunication
    /// carrier to the instance or network interface. 
    /// </para><para>
    /// You cannot associate an Elastic IP address with an interface in a different network
    /// border group.
    /// </para><important><para>
    /// This is an idempotent operation. If you perform the operation more than once, Amazon
    /// EC2 doesn't return an error, and you may be charged for each time the Elastic IP address
    /// is remapped to the same instance. For more information, see the <i>Elastic IP Addresses</i>
    /// section of <a href="http://aws.amazon.com/ec2/pricing/">Amazon EC2 Pricing</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Register", "EC2Address", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AssociateAddress API operation.", Operation = new[] {"AssociateAddress"}, SelectReturnType = typeof(Amazon.EC2.Model.AssociateAddressResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.AssociateAddressResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.AssociateAddressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterEC2AddressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllocationId
        /// <summary>
        /// <para>
        /// <para>The allocation ID. This is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AllocationId { get; set; }
        #endregion
        
        #region Parameter AllowReassociation
        /// <summary>
        /// <para>
        /// <para>Reassociation is automatic, but you can specify false to ensure the operation fails
        /// if the Elastic IP address is already associated with another resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowReassociation { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance. The instance must have exactly one attached network interface.
        /// You can specify either the instance ID or the network interface ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface. If the instance has more than one network interface,
        /// you must specify a network interface ID.</para><para>You can specify either the instance ID or the network interface ID, but not both.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>The primary or secondary private IP address to associate with the Elastic IP address.
        /// If no private IP address is specified, the Elastic IP address is associated with the
        /// primary private IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter PublicIp
        /// <summary>
        /// <para>
        /// <para>Deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String PublicIp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssociationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AssociateAddressResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AssociateAddressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssociationId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2Address (AssociateAddress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AssociateAddressResponse, RegisterEC2AddressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllocationId = this.AllocationId;
            context.AllowReassociation = this.AllowReassociation;
            context.InstanceId = this.InstanceId;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            context.PrivateIpAddress = this.PrivateIpAddress;
            context.PublicIp = this.PublicIp;
            
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
            var request = new Amazon.EC2.Model.AssociateAddressRequest();
            
            if (cmdletContext.AllocationId != null)
            {
                request.AllocationId = cmdletContext.AllocationId;
            }
            if (cmdletContext.AllowReassociation != null)
            {
                request.AllowReassociation = cmdletContext.AllowReassociation.Value;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.PrivateIpAddress != null)
            {
                request.PrivateIpAddress = cmdletContext.PrivateIpAddress;
            }
            if (cmdletContext.PublicIp != null)
            {
                request.PublicIp = cmdletContext.PublicIp;
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
        
        private Amazon.EC2.Model.AssociateAddressResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AssociateAddressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AssociateAddress");
            try
            {
                #if DESKTOP
                return client.AssociateAddress(request);
                #elif CORECLR
                return client.AssociateAddressAsync(request).GetAwaiter().GetResult();
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
            public System.String AllocationId { get; set; }
            public System.Boolean? AllowReassociation { get; set; }
            public System.String InstanceId { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.String PrivateIpAddress { get; set; }
            public System.String PublicIp { get; set; }
            public System.Func<Amazon.EC2.Model.AssociateAddressResponse, RegisterEC2AddressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssociationId;
        }
        
    }
}
