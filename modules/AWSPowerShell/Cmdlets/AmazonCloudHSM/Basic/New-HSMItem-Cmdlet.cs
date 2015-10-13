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
using Amazon.CloudHSM;
using Amazon.CloudHSM.Model;

namespace Amazon.PowerShell.Cmdlets.HSM
{
    /// <summary>
    /// Creates an uninitialized HSM instance. Running this command provisions an HSM appliance
    /// and will result in charges to your AWS account for the HSM.
    /// </summary>
    [Cmdlet("New", "HSMItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateHsm operation against AWS Cloud HSM.", Operation = new[] {"CreateHsm"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudHSM.Model.CreateHsmResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewHSMItemCmdlet : AmazonCloudHSMClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A user-defined token to ensure idempotence. Subsequent calls to this action with the
        /// same token will be ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The IP address to assign to the HSM's ENI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EniIp { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The external ID from <b>IamRoleArn</b>, if present.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExternalId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role to enable the AWS CloudHSM service to allocate an ENI on your
        /// behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String IamRoleArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The SSH public key to install on the HSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SshKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier of the subnet in your VPC in which to place the HSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SubnetId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The subscription type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CloudHSM.SubscriptionType SubscriptionType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The IP address for the syslog monitoring server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SyslogIp { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-HSMItem (CreateHsm)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClientToken = this.ClientToken;
            context.EniIp = this.EniIp;
            context.ExternalId = this.ExternalId;
            context.IamRoleArn = this.IamRoleArn;
            context.SshKey = this.SshKey;
            context.SubnetId = this.SubnetId;
            context.SubscriptionType = this.SubscriptionType;
            context.SyslogIp = this.SyslogIp;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudHSM.Model.CreateHsmRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EniIp != null)
            {
                request.EniIp = cmdletContext.EniIp;
            }
            if (cmdletContext.ExternalId != null)
            {
                request.ExternalId = cmdletContext.ExternalId;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.SshKey != null)
            {
                request.SshKey = cmdletContext.SshKey;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.SubscriptionType != null)
            {
                request.SubscriptionType = cmdletContext.SubscriptionType;
            }
            if (cmdletContext.SyslogIp != null)
            {
                request.SyslogIp = cmdletContext.SyslogIp;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateHsm(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.HsmArn;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClientToken { get; set; }
            public System.String EniIp { get; set; }
            public System.String ExternalId { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String SshKey { get; set; }
            public System.String SubnetId { get; set; }
            public Amazon.CloudHSM.SubscriptionType SubscriptionType { get; set; }
            public System.String SyslogIp { get; set; }
        }
        
    }
}
