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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Removes the specified policy from the specified certificate.
    /// </summary>
    [Cmdlet("Remove", "IOTPrincipalPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the DetachPrincipalPolicy operation against AWS IoT.", Operation = new[] {"DetachPrincipalPolicy"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.IoT.Model.DetachPrincipalPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveIOTPrincipalPolicyCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the policy to detach.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The principal.</para><para>If the principal is a certificate, specify the certificate ARN. If the principal is
        /// an Amazon Cognito identity, specify the identity ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Principal { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PolicyName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IOTPrincipalPolicy (DetachPrincipalPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.PolicyName = this.PolicyName;
            context.Principal = this.Principal;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IoT.Model.DetachPrincipalPolicyRequest();
            
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principal = cmdletContext.Principal;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DetachPrincipalPolicy(request);
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
            public System.String PolicyName { get; set; }
            public System.String Principal { get; set; }
        }
        
    }
}
