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
    /// Describe VPC Block Public Access (BPA) options. VPC Block Public Access (BPA) enables
    /// you to block resources in VPCs and subnets that you own in a Region from reaching
    /// or being reached from the internet through internet gateways and egress-only internet
    /// gateways. To learn more about VPC BPA, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/security-vpc-bpa.html">Block
    /// public access to VPCs and subnets</a> in the <i>Amazon VPC User Guide</i>.
    /// </summary>
    [Cmdlet("Get", "EC2VpcBlockPublicAccessOption")]
    [OutputType("Amazon.EC2.Model.VpcBlockPublicAccessOptions")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeVpcBlockPublicAccessOptions API operation.", Operation = new[] {"DescribeVpcBlockPublicAccessOptions"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeVpcBlockPublicAccessOptionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpcBlockPublicAccessOptions or Amazon.EC2.Model.DescribeVpcBlockPublicAccessOptionsResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpcBlockPublicAccessOptions object.",
        "The service call response (type Amazon.EC2.Model.DescribeVpcBlockPublicAccessOptionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2VpcBlockPublicAccessOptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcBlockPublicAccessOptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeVpcBlockPublicAccessOptionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeVpcBlockPublicAccessOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcBlockPublicAccessOptions";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeVpcBlockPublicAccessOptionsResponse, GetEC2VpcBlockPublicAccessOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.EC2.Model.DescribeVpcBlockPublicAccessOptionsRequest();
            
            
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
        
        private Amazon.EC2.Model.DescribeVpcBlockPublicAccessOptionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeVpcBlockPublicAccessOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeVpcBlockPublicAccessOptions");
            try
            {
                #if DESKTOP
                return client.DescribeVpcBlockPublicAccessOptions(request);
                #elif CORECLR
                return client.DescribeVpcBlockPublicAccessOptionsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.EC2.Model.DescribeVpcBlockPublicAccessOptionsResponse, GetEC2VpcBlockPublicAccessOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcBlockPublicAccessOptions;
        }
        
    }
}
