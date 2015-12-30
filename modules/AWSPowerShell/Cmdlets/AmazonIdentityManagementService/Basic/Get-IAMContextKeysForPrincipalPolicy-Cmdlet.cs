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
    /// Gets a list of all of the context keys referenced in <code>Condition</code> elements
    /// in all of the IAM policies attached to the specified IAM entity. The entity can be
    /// an IAM user, group, or role. If you specify a user, then the request also includes
    /// all of the policies attached to groups that the user is a member of.
    /// 
    ///  
    /// <para>
    /// You can optionally include a list of one or more additional policies, specified as
    /// strings. If you want to include only a list of policies by string, use <a>GetContextKeysForCustomPolicy</a>
    /// instead.
    /// </para><para><b>Note:</b> This API discloses information about the permissions granted to other
    /// users. If you do not want users to see other user's permissions, then consider allowing
    /// them to use <a>GetContextKeysForCustomPolicy</a> instead.
    /// </para><para>
    /// Context keys are variables maintained by AWS and its services that provide details
    /// about the context of an API query request, and can be evaluated by using the <code>Condition</code>
    /// element of an IAM policy. Use GetContextKeysForPrincipalPolicy to understand what
    /// key names and values you must supply when you call <a>SimulatePrincipalPolicy</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMContextKeysForPrincipalPolicy")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the GetContextKeysForPrincipalPolicy operation against AWS Identity and Access Management.", Operation = new[] {"GetContextKeysForPrincipalPolicy"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetIAMContextKeysForPrincipalPolicyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyInputList
        /// <summary>
        /// <para>
        /// <para>A optional list of additional policies for which you want list of context keys used
        /// in <code>Condition</code> elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] PolicyInputList { get; set; }
        #endregion
        
        #region Parameter PolicySourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of a user, group, or role whose policies contain the context keys that you
        /// want listed. If you specify a user, the list includes context keys that are found
        /// in all policies attached to the user as well as to all groups that the user is a member
        /// of. If you pick a group or a role, then it includes only those context keys that are
        /// found in policies attached to that entity. Note that all parameters are shown in unencoded
        /// form here for clarity, but must be URL encoded to be included as a part of a real
        /// HTML request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PolicySourceArn { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.PolicyInputList != null)
            {
                context.PolicyInputList = new List<System.String>(this.PolicyInputList);
            }
            context.PolicySourceArn = this.PolicySourceArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IdentityManagement.Model.GetContextKeysForPrincipalPolicyRequest();
            
            if (cmdletContext.PolicyInputList != null)
            {
                request.PolicyInputList = cmdletContext.PolicyInputList;
            }
            if (cmdletContext.PolicySourceArn != null)
            {
                request.PolicySourceArn = cmdletContext.PolicySourceArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetContextKeysForPrincipalPolicy(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ContextKeyNames;
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
            public List<System.String> PolicyInputList { get; set; }
            public System.String PolicySourceArn { get; set; }
        }
        
    }
}
