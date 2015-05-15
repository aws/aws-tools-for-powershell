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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// This operation updates the Challenge-Handshake Authentication Protocol (CHAP) credentials
    /// for a specified iSCSI target. By default, a gateway does not have CHAP enabled; however,
    /// for added security, you might use it.
    /// 
    ///  <important><para>
    /// When you update CHAP credentials, all existing connections on the target are closed
    /// and initiators must reconnect with the new credentials.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "SGChapCredentials", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StorageGateway.Model.UpdateChapCredentialsResult")]
    [AWSCmdlet("Invokes the UpdateChapCredentials operation against AWS Storage Gateway.", Operation = new[] {"UpdateChapCredentials"})]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.UpdateChapCredentialsResult",
        "This cmdlet returns a UpdateChapCredentialsResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateSGChapCredentialsCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The iSCSI initiator that connects to the target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String InitiatorName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The secret key that the initiator (e.g. Windows client) must provide to participate
        /// in mutual CHAP with the target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String SecretToAuthenticateInitiator { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The secret key that the target must provide to participate in mutual CHAP with the
        /// initiator (e.g. Windows client).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public String SecretToAuthenticateTarget { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the iSCSI volume target. Use the <a>DescribeStorediSCSIVolumes</a>
        /// operation to return to retrieve the TargetARN for specified VolumeARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String TargetARN { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InitiatorName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGChapCredentials (UpdateChapCredentials)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.InitiatorName = this.InitiatorName;
            context.SecretToAuthenticateInitiator = this.SecretToAuthenticateInitiator;
            context.SecretToAuthenticateTarget = this.SecretToAuthenticateTarget;
            context.TargetARN = this.TargetARN;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateChapCredentialsRequest();
            
            if (cmdletContext.InitiatorName != null)
            {
                request.InitiatorName = cmdletContext.InitiatorName;
            }
            if (cmdletContext.SecretToAuthenticateInitiator != null)
            {
                request.SecretToAuthenticateInitiator = cmdletContext.SecretToAuthenticateInitiator;
            }
            if (cmdletContext.SecretToAuthenticateTarget != null)
            {
                request.SecretToAuthenticateTarget = cmdletContext.SecretToAuthenticateTarget;
            }
            if (cmdletContext.TargetARN != null)
            {
                request.TargetARN = cmdletContext.TargetARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateChapCredentials(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
            public String InitiatorName { get; set; }
            public String SecretToAuthenticateInitiator { get; set; }
            public String SecretToAuthenticateTarget { get; set; }
            public String TargetARN { get; set; }
        }
        
    }
}
