/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.EC2.Model;
using Amazon.EC2;
using Amazon.Runtime;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modify an attribute on a VPC.
    /// </summary>
    [Cmdlet("Edit", "EC2VpcAttribute", DefaultParameterSetName = ParamSet_DnsSupport, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyVpcAttribute API operation.", Operation = new[] { "ModifyVpcAttribute" })]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. Only one attribute can be modified per call."
            + "The service response (type Amazon.EC2.Model.ModifyVpcAttributeResponse) is added to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditEC2VpcAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        const string ParamSet_DnsSupport = "DnsSupport";
        const string ParamSet_DnsHostnames = "DnsHostnames";

        #region Parameter VpcId
        /// <summary>
        /// The ID of the VPC to modify.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName=true, ValueFromPipeline = true, Mandatory = true)]
        public System.String VpcId { get; set; }
        #endregion

        #region Parameter EnableDnsSupport
        /// <summary>
        /// <para>
        /// Indicates whether the DNS resolution is supported for the VPC. If enabled, queries to the Amazon 
        /// provided DNS server at the 169.254.169.253 IP address, or the reserved IP address at the base of the VPC 
        /// network range "plus two" will succeed. If disabled, the Amazon provided DNS service in the VPC that 
        /// resolves public DNS hostnames to IP addresses is not enabled.
        /// </para>
        /// <para>
        /// You cannot modify the DNS resolution and DNS hostnames attributes in the same request. Use separate 
        /// requests for each attribute.
        /// </para>
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_DnsSupport, Mandatory = true)]
        public System.Boolean? EnableDnsSupport { get; set; }
        #endregion

        #region Parameter EnableDnsHostnames
        /// <summary>
        /// <para>
        /// Indicates whether the instances launched in the VPC get DNS hostnames. If enabled, instances in the 
        /// VPC get DNS hostnames; otherwise, they do not.
        /// </para>
        /// <para>
        /// You cannot modify the DNS resolution and DNS hostnames attributes in the same request.Use separate requests for 
        /// each attribute. Additionally you can only enable DNS hostnames if you've enabled DNS support.
        /// </para>
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_DnsHostnames, Mandatory = true)]
        public System.Boolean? EnableDnsHostnames { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force the cmdlet to continue its operation. T
        /// his parameter should always be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.VpcId, "Edit-EC2VpcAttribute (ModifyVpcAttribute)"))
                return;

            var context = new CmdletContext
                              {
                                  Region = this.Region,
                                  Credentials = this.CurrentCredentials,
                                  VpcId = this.VpcId,
                                  EnableDnsSupport = this.EnableDnsSupport,
                                  EnableDnsHostnames = this.EnableDnsHostnames
                              };

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ModifyVpcAttributeRequest();
            
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
            }
            if (cmdletContext.EnableDnsSupport != null)
            {
                request.EnableDnsSupport = cmdletContext.EnableDnsSupport.Value;
            }
            if (cmdletContext.EnableDnsHostnames != null)
            {
                request.EnableDnsHostnames = cmdletContext.EnableDnsHostnames.Value;
            }

            var client = Client ?? CreateClient(context.Credentials, context.Region);
            CmdletOutput output;
            
            // issue call
            try
            {
                var response = CallAWSServiceOperation(client, request);
                output = new CmdletOutput
                {
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

        private Amazon.EC2.Model.ModifyVpcAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2", "ModifyVpcAttribute");

            try
            {
#if DESKTOP
                return client.ModifyVpcAttribute(request);
#elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyVpcAttributeAsync(request);
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

        internal class CmdletContext : ExecutorContext
        {
            public String VpcId { get; set; }
            public Boolean? EnableDnsSupport { get; set; }
            public Boolean? EnableDnsHostnames { get; set; }
        }
        
    }
}
