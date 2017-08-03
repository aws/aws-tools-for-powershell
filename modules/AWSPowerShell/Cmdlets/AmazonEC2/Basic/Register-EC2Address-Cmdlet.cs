/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Associates an Elastic IP address with an instance or a network interface.
    /// 
    ///  
    /// <para>
    /// An Elastic IP address is for use in either the EC2-Classic platform or in a VPC. For
    /// more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/elastic-ip-addresses-eip.html">Elastic
    /// IP Addresses</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><para>
    /// [EC2-Classic, VPC in an EC2-VPC-only account] If the Elastic IP address is already
    /// associated with a different instance, it is disassociated from that instance and associated
    /// with the specified instance. If you associate an Elastic IP address with an instance
    /// that has an existing Elastic IP address, the existing address is disassociated from
    /// the instance, but remains allocated to your account.
    /// </para><para>
    /// [VPC in an EC2-Classic account] If you don't specify a private IP address, the Elastic
    /// IP address is associated with the primary IP address. If the Elastic IP address is
    /// already associated with a different instance or a network interface, you get an error
    /// unless you allow reassociation. You cannot associate an Elastic IP address with an
    /// instance or network interface that has an existing Elastic IP address.
    /// </para><important><para>
    /// This is an idempotent operation. If you perform the operation more than once, Amazon
    /// EC2 doesn't return an error, and you may be charged for each time the Elastic IP address
    /// is remapped to the same instance. For more information, see the <i>Elastic IP Addresses</i>
    /// section of <a href="http://aws.amazon.com/ec2/pricing/">Amazon EC2 Pricing</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Register", "EC2Address", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the AssociateAddress operation against Amazon Elastic Compute Cloud.", Operation = new[] {"AssociateAddress"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.EC2.Model.AssociateAddressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterEC2AddressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AllocationId
        /// <summary>
        /// <para>
        /// <para>[EC2-VPC] The allocation ID. This is required for EC2-VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String AllocationId { get; set; }
        #endregion
        
        #region Parameter AllowReassociation
        /// <summary>
        /// <para>
        /// <para>[EC2-VPC] For a VPC in an EC2-Classic account, specify true to allow an Elastic IP
        /// address that is already associated with an instance or network interface to be reassociated
        /// with the specified instance or network interface. Otherwise, the operation fails.
        /// In a VPC in an EC2-VPC-only account, reassociation is automatic, therefore you can
        /// specify false to ensure the operation fails if the Elastic IP address is already associated
        /// with another resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AllowReassociation { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance. This is required for EC2-Classic. For EC2-VPC, you can specify
        /// either the instance ID or the network interface ID, but not both. The operation fails
        /// if you specify an instance ID unless exactly one network interface is attached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>[EC2-VPC] The ID of the network interface. If the instance has more than one network
        /// interface, you must specify a network interface ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>[EC2-VPC] The primary or secondary private IP address to associate with the Elastic
        /// IP address. If no private IP address is specified, the Elastic IP address is associated
        /// with the primary private IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter PublicIp
        /// <summary>
        /// <para>
        /// <para>The Elastic IP address. This is required for EC2-Classic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String PublicIp { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2Address (AssociateAddress)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AllocationId = this.AllocationId;
            if (ParameterWasBound("AllowReassociation"))
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AssociationId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "AssociateAddress");
            #if DESKTOP
            return client.AssociateAddress(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AssociateAddressAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
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
        }
        
    }
}
