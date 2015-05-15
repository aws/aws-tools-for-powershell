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

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modify an attribute on a VPC.
    /// </summary>
    [Cmdlet("Edit", "EC2VpcAttribute", DefaultParameterSetName = ParamSet_DnsSupport, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the ModifyVpcAttribute against Amazon Elastic Compute Cloud.", Operation = new [] {"ModifyVpcAttribute"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. Only one attribute can be modified per call."
            + "The service response (type ModifyVpcAttributeResponse) is added to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditEC2VpcAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        const string ParamSet_DnsSupport = "DnsSupportParamSet";
        const string ParamSet_DnsHostnames = "DnsHostnamesParamSet";

        /// <summary>
        /// <para>
        /// VPC ID to modify.
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName=true, ValueFromPipeline = true, Mandatory = true)]
        public String VpcId { get; set; }
        
        /// <summary>
        /// <para>
        /// Whether Dns is supported.
        /// </para>
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_DnsSupport, Mandatory = true)]
        public Boolean? EnableDnsSupport { get; set; }
        
        /// <summary>
        /// <para>
        /// Whether Dns hostnames are enabled.
        /// </para>
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_DnsHostnames, Mandatory = true)]
        public Boolean? EnableDnsHostnames { get; set; }

        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ModifyVpcAttribute(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String VpcId { get; set; }
            public Boolean? EnableDnsSupport { get; set; }
            public Boolean? EnableDnsHostnames { get; set; }
        }
        
    }
}
