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
    /// Creates an uninitialized HSM instance.
    /// 
    ///  
    /// <para>
    /// There is an upfront fee charged for each HSM instance that you create with the <a>CreateHsm</a>
    /// operation. If you accidentally provision an HSM and want to request a refund, delete
    /// the instance using the <a>DeleteHsm</a> operation, go to the <a href="https://console.aws.amazon.com/support/home#/">AWS
    /// Support Center</a>, create a new case, and select <b>Account and Billing Support</b>.
    /// </para><important><para>
    /// It can take up to 20 minutes to create and provision an HSM. You can monitor the status
    /// of the HSM with the <a>DescribeHsm</a> operation. The HSM is ready to be initialized
    /// when the status changes to <code>RUNNING</code>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "HSMItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateHsm operation against AWS Cloud HSM.", Operation = new[] {"CreateHsm"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudHSM.Model.CreateHsmResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewHSMItemCmdlet : AmazonCloudHSMClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A user-defined token to ensure idempotence. Subsequent calls to this operation with
        /// the same token will be ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter EniIp
        /// <summary>
        /// <para>
        /// <para>The IP address to assign to the HSM's ENI.</para><para>If an IP address is not specified, an IP address will be randomly chosen from the
        /// CIDR range of the subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EniIp { get; set; }
        #endregion
        
        #region Parameter ExternalId
        /// <summary>
        /// <para>
        /// <para>The external ID from <b>IamRoleArn</b>, if present.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExternalId { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role to enable the AWS CloudHSM service to allocate an ENI on your
        /// behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter SshKey
        /// <summary>
        /// <para>
        /// <para>The SSH public key to install on the HSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SshKey { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifier of the subnet in your VPC in which to place the HSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter SubscriptionType
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudHSM.SubscriptionType")]
        public Amazon.CloudHSM.SubscriptionType SubscriptionType { get; set; }
        #endregion
        
        #region Parameter SyslogIp
        /// <summary>
        /// <para>
        /// <para>The IP address for the syslog monitoring server. The AWS CloudHSM service only supports
        /// one syslog monitoring server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SyslogIp { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientToken = this.ClientToken;
            context.EniIp = this.EniIp;
            context.ExternalId = this.ExternalId;
            context.IamRoleArn = this.IamRoleArn;
            context.SshKey = this.SshKey;
            context.SubnetId = this.SubnetId;
            context.SubscriptionType = this.SubscriptionType;
            context.SyslogIp = this.SyslogIp;
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.CloudHSM.Model.CreateHsmResponse CallAWSServiceOperation(IAmazonCloudHSM client, Amazon.CloudHSM.Model.CreateHsmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud HSM", "CreateHsm");
            #if DESKTOP
            return client.CreateHsm(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateHsmAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
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
