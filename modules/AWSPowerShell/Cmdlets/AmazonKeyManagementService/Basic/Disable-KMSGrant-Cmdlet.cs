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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Retires a grant. You can retire a grant when you're done using it to clean up. You
    /// should revoke a grant when you intend to actively deny operations that depend on it.
    /// The following are permitted to call this API: <ul><li>The account that created the
    /// grant</li><li>The <code>RetiringPrincipal</code>, if present</li><li>The <code>GranteePrincipal</code>,
    /// if <code>RetireGrant</code> is a grantee operation</li></ul> The grant to retire
    /// must be identified by its grant token or by a combination of the key ARN and the grant
    /// ID. A grant token is a unique variable-length base64-encoded string. A grant ID is
    /// a 64 character unique identifier of a grant. Both are returned by the <code>CreateGrant</code>
    /// function.
    /// </summary>
    [Cmdlet("Disable", "KMSGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the RetireGrant operation against AWS Key Management Service.", Operation = new[] {"RetireGrant"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type RetireGrantResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class DisableKMSGrantCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> Unique identifier of the grant to be retired. The grant ID is returned by the <code>CreateGrant</code>
        /// function. <ul><li>Grant ID Example - 0123456789012345678901234567890123456789012345678901234567890123</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String GrantId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Token that identifies the grant to be retired.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String GrantToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the customer master key associated with the grant. This value
        /// can be a globally unique identifier or a fully specified ARN of the key. <ul><li>Key
        /// ARN Example - arn:aws:kms:us-east-1:123456789012:key/12345678-1234-1234-1234-123456789012</li><li>Globally Unique Key ID Example - 12345678-1234-1234-1234-123456789012</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String KeyId { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GrantToken", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-KMSGrant (RetireGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.GrantId = this.GrantId;
            context.GrantToken = this.GrantToken;
            context.KeyId = this.KeyId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new RetireGrantRequest();
            
            if (cmdletContext.GrantId != null)
            {
                request.GrantId = cmdletContext.GrantId;
            }
            if (cmdletContext.GrantToken != null)
            {
                request.GrantToken = cmdletContext.GrantToken;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RetireGrant(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
            public String GrantId { get; set; }
            public String GrantToken { get; set; }
            public String KeyId { get; set; }
        }
        
    }
}
