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
    /// Creates a default VPC with a size <code>/16</code> IPv4 CIDR block and a default subnet
    /// in each Availability Zone. For more information about the components of a default
    /// VPC, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/default-vpc.html">Default
    /// VPCs</a> in the <i>Amazon VPC User Guide</i>. You cannot specify the components of
    /// the default VPC yourself.
    /// 
    ///  
    /// <para>
    /// If you deleted your previous default VPC, you can create a default VPC. You cannot
    /// have more than one default VPC per Region.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2DefaultVpc", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Vpc")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateDefaultVpc API operation.", Operation = new[] {"CreateDefaultVpc"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateDefaultVpcResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Vpc or Amazon.EC2.Model.CreateDefaultVpcResponse",
        "This cmdlet returns an Amazon.EC2.Model.Vpc object.",
        "The service call response (type Amazon.EC2.Model.CreateDefaultVpcResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2DefaultVpcCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Vpc'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateDefaultVpcResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateDefaultVpcResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Vpc";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2DefaultVpc (CreateDefaultVpc)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateDefaultVpcResponse, NewEC2DefaultVpcCmdlet>(Select) ??
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
            var request = new Amazon.EC2.Model.CreateDefaultVpcRequest();
            
            
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
        
        private Amazon.EC2.Model.CreateDefaultVpcResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateDefaultVpcRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateDefaultVpc");
            try
            {
                #if DESKTOP
                return client.CreateDefaultVpc(request);
                #elif CORECLR
                return client.CreateDefaultVpcAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.EC2.Model.CreateDefaultVpcResponse, NewEC2DefaultVpcCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Vpc;
        }
        
    }
}
