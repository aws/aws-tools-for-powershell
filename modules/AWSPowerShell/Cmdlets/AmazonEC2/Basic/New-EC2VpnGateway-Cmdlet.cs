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
    /// Creates a virtual private gateway. A virtual private gateway is the endpoint on the
    /// VPC side of your VPN connection. You can create a virtual private gateway before creating
    /// the VPC itself.
    /// 
    ///  
    /// <para>
    /// For more information about virtual private gateways, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_VPN.html">AWS
    /// Managed VPN Connections</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2VpnGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpnGateway")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateVpnGateway API operation.", Operation = new[] {"CreateVpnGateway"})]
    [AWSCmdletOutput("Amazon.EC2.Model.VpnGateway",
        "This cmdlet returns a VpnGateway object.",
        "The service call response (type Amazon.EC2.Model.CreateVpnGatewayResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2VpnGatewayCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AmazonSideAsn
        /// <summary>
        /// <para>
        /// <para>A private Autonomous System Number (ASN) for the Amazon side of a BGP session. If
        /// you're using a 16-bit ASN, it must be in the 64512 to 65534 range. If you're using
        /// a 32-bit ASN, it must be in the 4200000000 to 4294967294 range.</para><para>Default: 64512</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 AmazonSideAsn { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone for the virtual private gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of VPN connection this virtual private gateway supports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.EC2.GatewayType")]
        public Amazon.EC2.GatewayType Type { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Type", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VpnGateway (CreateVpnGateway)"))
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
            
            if (ParameterWasBound("AmazonSideAsn"))
                context.AmazonSideAsn = this.AmazonSideAsn;
            context.AvailabilityZone = this.AvailabilityZone;
            context.Type = this.Type;
            
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
            var request = new Amazon.EC2.Model.CreateVpnGatewayRequest();
            
            if (cmdletContext.AmazonSideAsn != null)
            {
                request.AmazonSideAsn = cmdletContext.AmazonSideAsn.Value;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VpnGateway;
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
        
        private Amazon.EC2.Model.CreateVpnGatewayResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpnGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateVpnGateway");
            try
            {
                #if DESKTOP
                return client.CreateVpnGateway(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateVpnGatewayAsync(request);
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
            public System.Int64? AmazonSideAsn { get; set; }
            public System.String AvailabilityZone { get; set; }
            public Amazon.EC2.GatewayType Type { get; set; }
        }
        
    }
}
