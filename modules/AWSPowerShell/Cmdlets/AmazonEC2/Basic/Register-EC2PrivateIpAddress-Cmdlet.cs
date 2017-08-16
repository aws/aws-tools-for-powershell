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
    /// Assigns one or more secondary private IP addresses to the specified network interface.
    /// You can specify one or more specific secondary IP addresses, or you can specify the
    /// number of secondary IP addresses to be automatically assigned within the subnet's
    /// CIDR block range. The number of secondary IP addresses that you can assign to an instance
    /// varies by instance type. For information about instance types, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
    /// Types</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>. For more information
    /// about Elastic IP addresses, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/elastic-ip-addresses-eip.html">Elastic
    /// IP Addresses</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// 
    ///  
    /// <para>
    /// AssignPrivateIpAddresses is available only in EC2-VPC.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2PrivateIpAddress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the AssignPrivateIpAddresses operation against Amazon Elastic Compute Cloud.", Operation = new[] {"AssignPrivateIpAddresses"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the NetworkInterfaceId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.AssignPrivateIpAddressesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterEC2PrivateIpAddressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AllowReassignment
        /// <summary>
        /// <para>
        /// <para>Indicates whether to allow an IP address that is already assigned to another network
        /// interface or instance to be reassigned to the specified network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.Boolean AllowReassignment { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>One or more IP addresses to be assigned as a secondary private IP address to the network
        /// interface. You can't specify this parameter when also specifying a number of secondary
        /// IP addresses.</para><para>If you don't specify an IP address, Amazon EC2 automatically selects an IP address
        /// within the subnet range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("PrivateIpAddresses")]
        public System.String[] PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter SecondaryPrivateIpAddressCount
        /// <summary>
        /// <para>
        /// <para>The number of secondary IP addresses to assign to the network interface. You can't
        /// specify this parameter when also specifying private IP addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 SecondaryPrivateIpAddressCount { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the NetworkInterfaceId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("NetworkInterfaceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2PrivateIpAddress (AssignPrivateIpAddresses)"))
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
            
            if (ParameterWasBound("AllowReassignment"))
                context.AllowReassignment = this.AllowReassignment;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            if (this.PrivateIpAddress != null)
            {
                context.PrivateIpAddresses = new List<System.String>(this.PrivateIpAddress);
            }
            if (ParameterWasBound("SecondaryPrivateIpAddressCount"))
                context.SecondaryPrivateIpAddressCount = this.SecondaryPrivateIpAddressCount;
            
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
            var request = new Amazon.EC2.Model.AssignPrivateIpAddressesRequest();
            
            if (cmdletContext.AllowReassignment != null)
            {
                request.AllowReassignment = cmdletContext.AllowReassignment.Value;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.PrivateIpAddresses != null)
            {
                request.PrivateIpAddresses = cmdletContext.PrivateIpAddresses;
            }
            if (cmdletContext.SecondaryPrivateIpAddressCount != null)
            {
                request.SecondaryPrivateIpAddressCount = cmdletContext.SecondaryPrivateIpAddressCount.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.NetworkInterfaceId;
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
        
        private Amazon.EC2.Model.AssignPrivateIpAddressesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AssignPrivateIpAddressesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "AssignPrivateIpAddresses");
            try
            {
                #if DESKTOP
                return client.AssignPrivateIpAddresses(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AssignPrivateIpAddressesAsync(request);
                return task.Result;
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
            public System.Boolean? AllowReassignment { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public List<System.String> PrivateIpAddresses { get; set; }
            public System.Int32? SecondaryPrivateIpAddressCount { get; set; }
        }
        
    }
}
