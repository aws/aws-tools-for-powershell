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
    /// Deletes the specified version of the specified policy. You cannot delete the default
    /// version of a policy using this API. To delete the default version of a policy, use
    /// <a>DeletePolicy</a>. To find out which version of a policy is marked as the default
    /// version, use ListPolicyVersions.
    /// </summary>
    [Cmdlet("Remove", "IOTPolicyVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the DeletePolicyVersion operation against AWS IoT.", Operation = new[] {"DeletePolicyVersion"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the PolicyName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IoT.Model.DeletePolicyVersionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveIOTPolicyVersionCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter PolicyVersionId
        /// <summary>
        /// <para>
        /// <para>The policy version ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PolicyVersionId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the PolicyName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PolicyVersionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IOTPolicyVersion (DeletePolicyVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.PolicyName = this.PolicyName;
            context.PolicyVersionId = this.PolicyVersionId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IoT.Model.DeletePolicyVersionRequest();
            
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            if (cmdletContext.PolicyVersionId != null)
            {
                request.PolicyVersionId = cmdletContext.PolicyVersionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DeletePolicyVersion(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.PolicyName;
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
            public System.String PolicyVersionId { get; set; }
        }
        
    }
}
