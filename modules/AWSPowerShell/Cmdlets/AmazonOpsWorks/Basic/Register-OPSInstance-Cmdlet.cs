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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Registers instances with a specified stack that were created outside of AWS OpsWorks.
    /// 
    ///  <note>We do not recommend using this action to register instances. The complete registration
    /// operation has two primary steps, installing the AWS OpsWorks agent on the instance
    /// and registering the instance with the stack. <code>RegisterInstance</code> handles
    /// only the second step. You should instead use the AWS CLI <code>register</code> command,
    /// which performs the entire registration operation.</note><para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "OPSInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RegisterInstance operation against AWS OpsWorks.", Operation = new[] {"RegisterInstance"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type RegisterInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RegisterOPSInstanceCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A JSON document that contains the metadata. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String InstanceIdentity_Document { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance's hostname.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Hostname { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance's private IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PrivateIp { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance's public IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PublicIp { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instances public RSA key. This key is used to encrypt communication between the
        /// instance and the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RsaPublicKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instances public RSA key fingerprint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RsaPublicKeyFingerprint { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A signature that can be used to verify the document's accuracy and authenticity. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String InstanceIdentity_Signature { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the stack that the instance is to be registered with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String StackId { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-OPSInstance (RegisterInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Hostname = this.Hostname;
            context.InstanceIdentity_Document = this.InstanceIdentity_Document;
            context.InstanceIdentity_Signature = this.InstanceIdentity_Signature;
            context.PrivateIp = this.PrivateIp;
            context.PublicIp = this.PublicIp;
            context.RsaPublicKey = this.RsaPublicKey;
            context.RsaPublicKeyFingerprint = this.RsaPublicKeyFingerprint;
            context.StackId = this.StackId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new RegisterInstanceRequest();
            
            if (cmdletContext.Hostname != null)
            {
                request.Hostname = cmdletContext.Hostname;
            }
            
             // populate InstanceIdentity
            bool requestInstanceIdentityIsNull = true;
            request.InstanceIdentity = new InstanceIdentity();
            String requestInstanceIdentity_instanceIdentity_Document = null;
            if (cmdletContext.InstanceIdentity_Document != null)
            {
                requestInstanceIdentity_instanceIdentity_Document = cmdletContext.InstanceIdentity_Document;
            }
            if (requestInstanceIdentity_instanceIdentity_Document != null)
            {
                request.InstanceIdentity.Document = requestInstanceIdentity_instanceIdentity_Document;
                requestInstanceIdentityIsNull = false;
            }
            String requestInstanceIdentity_instanceIdentity_Signature = null;
            if (cmdletContext.InstanceIdentity_Signature != null)
            {
                requestInstanceIdentity_instanceIdentity_Signature = cmdletContext.InstanceIdentity_Signature;
            }
            if (requestInstanceIdentity_instanceIdentity_Signature != null)
            {
                request.InstanceIdentity.Signature = requestInstanceIdentity_instanceIdentity_Signature;
                requestInstanceIdentityIsNull = false;
            }
             // determine if request.InstanceIdentity should be set to null
            if (requestInstanceIdentityIsNull)
            {
                request.InstanceIdentity = null;
            }
            if (cmdletContext.PrivateIp != null)
            {
                request.PrivateIp = cmdletContext.PrivateIp;
            }
            if (cmdletContext.PublicIp != null)
            {
                request.PublicIp = cmdletContext.PublicIp;
            }
            if (cmdletContext.RsaPublicKey != null)
            {
                request.RsaPublicKey = cmdletContext.RsaPublicKey;
            }
            if (cmdletContext.RsaPublicKeyFingerprint != null)
            {
                request.RsaPublicKeyFingerprint = cmdletContext.RsaPublicKeyFingerprint;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RegisterInstance(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InstanceId;
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
            public String Hostname { get; set; }
            public String InstanceIdentity_Document { get; set; }
            public String InstanceIdentity_Signature { get; set; }
            public String PrivateIp { get; set; }
            public String PublicIp { get; set; }
            public String RsaPublicKey { get; set; }
            public String RsaPublicKeyFingerprint { get; set; }
            public String StackId { get; set; }
        }
        
    }
}
