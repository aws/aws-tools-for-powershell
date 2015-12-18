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
    /// Creates a new version of the specified managed policy. To update a managed policy,
    /// you create a new policy version. A managed policy can have up to five versions. If
    /// the policy has five versions, you must delete an existing version using <a>DeletePolicyVersion</a>
    /// before you create a new version. 
    /// 
    ///  
    /// <para>
    /// Optionally, you can set the new version as the policy's default version. The default
    /// version is the operative version; that is, the version that is in effect for the IAM
    /// users, groups, and roles that the policy is attached to. 
    /// </para><para>
    /// For more information about managed policy versions, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/policies-managed-versions.html">Versioning
    /// for Managed Policies</a> in the <i>IAM User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "IAMPolicyVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.PolicyVersion")]
    [AWSCmdlet("Invokes the CreatePolicyVersion operation against AWS Identity and Access Management.", Operation = new[] {"CreatePolicyVersion"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.PolicyVersion",
        "This cmdlet returns a PolicyVersion object.",
        "The service call response (type Amazon.IdentityManagement.Model.CreatePolicyVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewIAMPolicyVersionCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String PolicyArn { get; set; }
        #endregion
        
        #region Parameter PolicyDocument
        /// <summary>
        /// <para>
        /// <para>The policy document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String PolicyDocument { get; set; }
        #endregion
        
        #region Parameter SetAsDefault
        /// <summary>
        /// <para>
        /// <para>Specifies whether to set this version as the policy's default version.</para><para>When this parameter is <code>true</code>, the new policy version becomes the operative
        /// version; that is, the version that is in effect for the IAM users, groups, and roles
        /// that the policy is attached to.</para><para>For more information about managed policy versions, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/policies-managed-versions.html">Versioning
        /// for Managed Policies</a> in the <i>IAM User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SetAsDefault { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PolicyArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMPolicyVersion (CreatePolicyVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.PolicyArn = this.PolicyArn;
            context.PolicyDocument = this.PolicyDocument;
            if (ParameterWasBound("SetAsDefault"))
                context.SetAsDefault = this.SetAsDefault;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IdentityManagement.Model.CreatePolicyVersionRequest();
            
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
            }
            if (cmdletContext.PolicyDocument != null)
            {
                request.PolicyDocument = cmdletContext.PolicyDocument;
            }
            if (cmdletContext.SetAsDefault != null)
            {
                request.SetAsDefault = cmdletContext.SetAsDefault.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreatePolicyVersion(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PolicyVersion;
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
            public System.String PolicyArn { get; set; }
            public System.String PolicyDocument { get; set; }
            public System.Boolean? SetAsDefault { get; set; }
        }
        
    }
}
