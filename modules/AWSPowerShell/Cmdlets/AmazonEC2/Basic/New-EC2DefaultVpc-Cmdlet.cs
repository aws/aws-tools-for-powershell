/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// VPC, see <a href="https://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/default-vpc.html">Default
    /// VPC and Default Subnets</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// You cannot specify the components of the default VPC yourself.
    /// 
    ///  
    /// <para>
    /// If you deleted your previous default VPC, you can create a default VPC. You cannot
    /// have more than one default VPC per Region.
    /// </para><para>
    /// If your account supports EC2-Classic, you cannot use this action to create a default
    /// VPC in a Region that supports EC2-Classic. If you want a default VPC in a Region that
    /// supports EC2-Classic, see "I really want a default VPC for my existing EC2 account.
    /// Is that possible?" in the <a href="http://aws.amazon.com/vpc/faqs/#Default_VPCs">Default
    /// VPCs FAQ</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2DefaultVpc", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Vpc")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateDefaultVpc API operation.", Operation = new[] {"CreateDefaultVpc"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Vpc",
        "This cmdlet returns a Vpc object.",
        "The service call response (type Amazon.EC2.Model.CreateDefaultVpcResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2DefaultVpcCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2DefaultVpc (CreateDefaultVpc)"))
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Vpc;
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
        
        private Amazon.EC2.Model.CreateDefaultVpcResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateDefaultVpcRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateDefaultVpc");
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
        }
        
    }
}
