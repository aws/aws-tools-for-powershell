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
    /// Modify VPC Block Public Access (BPA) options. VPC Block public Access (BPA) enables
    /// you to block resources in VPCs and subnets that you own in a Region from reaching
    /// or being reached from the internet through internet gateways and egress-only internet
    /// gateways. To learn more about VPC BPA, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/security-vpc-bpa.html">Block
    /// public access to VPCs and subnets</a> in the <i>Amazon VPC User Guide</i>.
    /// </summary>
    [Cmdlet("Edit", "EC2VpcBlockPublicAccessOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpcBlockPublicAccessOptions")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpcBlockPublicAccessOptions API operation.", Operation = new[] {"ModifyVpcBlockPublicAccessOptions"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpcBlockPublicAccessOptionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpcBlockPublicAccessOptions or Amazon.EC2.Model.ModifyVpcBlockPublicAccessOptionsResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpcBlockPublicAccessOptions object.",
        "The service call response (type Amazon.EC2.Model.ModifyVpcBlockPublicAccessOptionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2VpcBlockPublicAccessOptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InternetGatewayBlockMode
        /// <summary>
        /// <para>
        /// <para>The mode of VPC BPA.</para><ul><li><para><c>bidirectional-access-allowed</c>: VPC BPA is not enabled and traffic is allowed
        /// to and from internet gateways and egress-only internet gateways in this Region.</para></li><li><para><c>bidirectional-access-blocked</c>: Block all traffic to and from internet gateways
        /// and egress-only internet gateways in this Region (except for excluded VPCs and subnets).</para></li><li><para><c>ingress-access-blocked</c>: Block all internet traffic to the VPCs in this Region
        /// (except for VPCs or subnets which are excluded). Only traffic to and from NAT gateways
        /// and egress-only internet gateways is allowed because these gateways only allow outbound
        /// connections to be established.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.InternetGatewayBlockMode")]
        public Amazon.EC2.InternetGatewayBlockMode InternetGatewayBlockMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcBlockPublicAccessOptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpcBlockPublicAccessOptionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVpcBlockPublicAccessOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcBlockPublicAccessOptions";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcBlockPublicAccessOption (ModifyVpcBlockPublicAccessOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpcBlockPublicAccessOptionsResponse, EditEC2VpcBlockPublicAccessOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InternetGatewayBlockMode = this.InternetGatewayBlockMode;
            #if MODULAR
            if (this.InternetGatewayBlockMode == null && ParameterWasBound(nameof(this.InternetGatewayBlockMode)))
            {
                WriteWarning("You are passing $null as a value for parameter InternetGatewayBlockMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVpcBlockPublicAccessOptionsRequest();
            
            if (cmdletContext.InternetGatewayBlockMode != null)
            {
                request.InternetGatewayBlockMode = cmdletContext.InternetGatewayBlockMode;
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
        
        private Amazon.EC2.Model.ModifyVpcBlockPublicAccessOptionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcBlockPublicAccessOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpcBlockPublicAccessOptions");
            try
            {
                #if DESKTOP
                return client.ModifyVpcBlockPublicAccessOptions(request);
                #elif CORECLR
                return client.ModifyVpcBlockPublicAccessOptionsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.InternetGatewayBlockMode InternetGatewayBlockMode { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpcBlockPublicAccessOptionsResponse, EditEC2VpcBlockPublicAccessOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcBlockPublicAccessOptions;
        }
        
    }
}
