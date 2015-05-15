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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Replaces the existing list of server certificate thumbprints with a new list. 
    /// 
    ///  
    /// <para>
    /// The list that you pass with this action completely replaces the existing list of thumbprints.
    /// (The lists are not merged.)
    /// </para><para>
    /// Typically, you need to update a thumbprint only when the identity provider's certificate
    /// changes, which occurs rarely. However, if the provider's certificate <i>does</i> change,
    /// any attempt to assume an IAM role that specifies the OIDC provider as a principal
    /// will fail until the certificate thumbprint is updated.
    /// </para><note>Because trust for the OpenID Connect provider is ultimately derived from the
    /// provider's certificate and is validated by the thumbprint, it is a best practice to
    /// limit access to the <code>UpdateOpenIDConnectProviderThumbprint</code> action to highly-privileged
    /// users. </note>
    /// </summary>
    [Cmdlet("Update", "IAMOpenIDConnectProviderThumbprint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the UpdateOpenIDConnectProviderThumbprint operation against AWS Identity and Access Management.", Operation = new[] {"UpdateOpenIDConnectProviderThumbprint"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type UpdateOpenIDConnectProviderThumbprintResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateIAMOpenIDConnectProviderThumbprintCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM OpenID Connect (OIDC) provider to update
        /// the thumbprint for. You can get a list of OIDC provider ARNs by using the <a>ListOpenIDConnectProviders</a>
        /// action. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String OpenIDConnectProviderArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of certificate thumbprints that are associated with the specified IAM OpenID
        /// Connect provider. For more information, see <a>CreateOpenIDConnectProvider</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ThumbprintList { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("OpenIDConnectProviderArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMOpenIDConnectProviderThumbprint (UpdateOpenIDConnectProviderThumbprint)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.OpenIDConnectProviderArn = this.OpenIDConnectProviderArn;
            if (this.ThumbprintList != null)
            {
                context.ThumbprintList = new List<String>(this.ThumbprintList);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateOpenIDConnectProviderThumbprintRequest();
            
            if (cmdletContext.OpenIDConnectProviderArn != null)
            {
                request.OpenIDConnectProviderArn = cmdletContext.OpenIDConnectProviderArn;
            }
            if (cmdletContext.ThumbprintList != null)
            {
                request.ThumbprintList = cmdletContext.ThumbprintList;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateOpenIDConnectProviderThumbprint(request);
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
            public String OpenIDConnectProviderArn { get; set; }
            public List<String> ThumbprintList { get; set; }
        }
        
    }
}
