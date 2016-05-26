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
    /// which performs the entire registration operation. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/registered-instances-register.html">
    /// Registering an Instance with an AWS OpsWorks Stack</a>.</note><para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
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
        "The service call response (type Amazon.OpsWorks.Model.RegisterInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RegisterOPSInstanceCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        #region Parameter InstanceIdentity_Document
        /// <summary>
        /// <para>
        /// <para>A JSON document that contains the metadata. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceIdentity_Document { get; set; }
        #endregion
        
        #region Parameter Hostname
        /// <summary>
        /// <para>
        /// <para>The instance's hostname.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Hostname { get; set; }
        #endregion
        
        #region Parameter PrivateIp
        /// <summary>
        /// <para>
        /// <para>The instance's private IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PrivateIp { get; set; }
        #endregion
        
        #region Parameter PublicIp
        /// <summary>
        /// <para>
        /// <para>The instance's public IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PublicIp { get; set; }
        #endregion
        
        #region Parameter RsaPublicKey
        /// <summary>
        /// <para>
        /// <para>The instances public RSA key. This key is used to encrypt communication between the
        /// instance and the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RsaPublicKey { get; set; }
        #endregion
        
        #region Parameter RsaPublicKeyFingerprint
        /// <summary>
        /// <para>
        /// <para>The instances public RSA key fingerprint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RsaPublicKeyFingerprint { get; set; }
        #endregion
        
        #region Parameter InstanceIdentity_Signature
        /// <summary>
        /// <para>
        /// <para>A signature that can be used to verify the document's accuracy and authenticity. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceIdentity_Signature { get; set; }
        #endregion
        
        #region Parameter StackId
        /// <summary>
        /// <para>
        /// <para>The ID of the stack that the instance is to be registered with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackId { get; set; }
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
            var request = new Amazon.OpsWorks.Model.RegisterInstanceRequest();
            
            if (cmdletContext.Hostname != null)
            {
                request.Hostname = cmdletContext.Hostname;
            }
            
             // populate InstanceIdentity
            bool requestInstanceIdentityIsNull = true;
            request.InstanceIdentity = new Amazon.OpsWorks.Model.InstanceIdentity();
            System.String requestInstanceIdentity_instanceIdentity_Document = null;
            if (cmdletContext.InstanceIdentity_Document != null)
            {
                requestInstanceIdentity_instanceIdentity_Document = cmdletContext.InstanceIdentity_Document;
            }
            if (requestInstanceIdentity_instanceIdentity_Document != null)
            {
                request.InstanceIdentity.Document = requestInstanceIdentity_instanceIdentity_Document;
                requestInstanceIdentityIsNull = false;
            }
            System.String requestInstanceIdentity_instanceIdentity_Signature = null;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.OpsWorks.Model.RegisterInstanceResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.RegisterInstanceRequest request)
        {
            return client.RegisterInstance(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Hostname { get; set; }
            public System.String InstanceIdentity_Document { get; set; }
            public System.String InstanceIdentity_Signature { get; set; }
            public System.String PrivateIp { get; set; }
            public System.String PublicIp { get; set; }
            public System.String RsaPublicKey { get; set; }
            public System.String RsaPublicKeyFingerprint { get; set; }
            public System.String StackId { get; set; }
        }
        
    }
}
