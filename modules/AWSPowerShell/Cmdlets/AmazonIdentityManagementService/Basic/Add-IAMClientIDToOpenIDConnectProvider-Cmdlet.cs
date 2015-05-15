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
    /// Adds a new client ID (also known as audience) to the list of client IDs already registered
    /// for the specified IAM OpenID Connect provider.
    /// 
    ///  
    /// <para>
    /// This action is idempotent; it does not fail or return an error if you add an existing
    /// client ID to the provider.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "IAMClientIDToOpenIDConnectProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the AddClientIDToOpenIDConnectProvider operation against AWS Identity and Access Management.", Operation = new[] {"AddClientIDToOpenIDConnectProvider"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type AddClientIDToOpenIDConnectProviderResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class AddIAMClientIDToOpenIDConnectProviderCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The client ID (also known as audience) to add to the IAM OpenID Connect provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ClientID { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM OpenID Connect (OIDC) provider to add the
        /// client ID to. You can get a list of OIDC provider ARNs by using the <a>ListOpenIDConnectProviders</a>
        /// action. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String OpenIDConnectProviderArn { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-IAMClientIDToOpenIDConnectProvider (AddClientIDToOpenIDConnectProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClientID = this.ClientID;
            context.OpenIDConnectProviderArn = this.OpenIDConnectProviderArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new AddClientIDToOpenIDConnectProviderRequest();
            
            if (cmdletContext.ClientID != null)
            {
                request.ClientID = cmdletContext.ClientID;
            }
            if (cmdletContext.OpenIDConnectProviderArn != null)
            {
                request.OpenIDConnectProviderArn = cmdletContext.OpenIDConnectProviderArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.AddClientIDToOpenIDConnectProvider(request);
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
            public String ClientID { get; set; }
            public String OpenIDConnectProviderArn { get; set; }
        }
        
    }
}
