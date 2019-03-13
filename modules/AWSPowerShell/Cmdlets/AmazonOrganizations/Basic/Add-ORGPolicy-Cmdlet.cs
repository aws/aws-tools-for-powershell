/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Attaches a policy to a root, an organizational unit (OU), or an individual account.
    /// How the policy affects accounts depends on the type of policy:
    /// 
    ///  <ul><li><para><b>Service control policy (SCP)</b> - An SCP specifies what permissions can be delegated
    /// to users in affected member accounts. The scope of influence for a policy depends
    /// on what you attach the policy to:
    /// </para><ul><li><para>
    /// If you attach an SCP to a root, it affects all accounts in the organization.
    /// </para></li><li><para>
    /// If you attach an SCP to an OU, it affects all accounts in that OU and in any child
    /// OUs.
    /// </para></li><li><para>
    /// If you attach the policy directly to an account, then it affects only that account.
    /// </para></li></ul><para>
    /// SCPs are JSON policies that specify the maximum permissions for an organization or
    /// organizational unit (OU). When you attach one SCP to a higher level root or OU, and
    /// you also attach a different SCP to a child OU or to an account, the child policy can
    /// further restrict only the permissions that pass through the parent filter and are
    /// available to the child. An SCP that is attached to a child cannot grant a permission
    /// that is not already granted by the parent. For example, imagine that the parent SCP
    /// allows permissions A, B, C, D, and E. The child SCP allows C, D, E, F, and G. The
    /// result is that the accounts affected by the child SCP are allowed to use only C, D,
    /// and E. They cannot use A or B because they were filtered out by the child OU. They
    /// also cannot use F and G because they were filtered out by the parent OU. They cannot
    /// be granted back by the child SCP; child SCPs can only filter the permissions they
    /// receive from the parent SCP.
    /// </para><para>
    /// AWS Organizations attaches a default SCP named <code>"FullAWSAccess</code> to every
    /// root, OU, and account. This default SCP allows all services and actions, enabling
    /// any new child OU or account to inherit the permissions of the parent root or OU. If
    /// you detach the default policy, you must replace it with a policy that specifies the
    /// permissions that you want to allow in that OU or account.
    /// </para><para>
    /// For more information about how Organizations policies permissions work, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_policies_scp.html">Using
    /// Service Control Policies</a> in the <i>AWS Organizations User Guide</i>.
    /// </para></li></ul><para>
    /// This operation can be called only from the organization's master account.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "ORGPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Organizations AttachPolicy API operation.", Operation = new[] {"AttachPolicy"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the PolicyId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Organizations.Model.AttachPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddORGPolicyCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the policy that you want to attach to the target. You
        /// can get the ID for the policy by calling the <a>ListPolicies</a> operation.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for a policy ID string
        /// requires "p-" followed by from 8 to 128 lower-case letters or digits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PolicyId { get; set; }
        #endregion
        
        #region Parameter TargetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the root, OU, or account that you want to attach the
        /// policy to. You can get the ID by calling the <a>ListRoots</a>, <a>ListOrganizationalUnitsForParent</a>,
        /// or <a>ListAccounts</a> operations.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for a target ID string
        /// requires one of the following:</para><ul><li><para>Root: a string that begins with "r-" followed by from 4 to 32 lower-case letters or
        /// digits.</para></li><li><para>Account: a string that consists of exactly 12 digits.</para></li><li><para>Organizational unit (OU): a string that begins with "ou-" followed by from 4 to 32
        /// lower-case letters or digits (the ID of the root that the OU is in) followed by a
        /// second "-" dash and from 8 to 32 additional lower-case letters or digits.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the PolicyId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PolicyId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-ORGPolicy (AttachPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.PolicyId = this.PolicyId;
            context.TargetId = this.TargetId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Organizations.Model.AttachPolicyRequest();
            
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyId = cmdletContext.PolicyId;
            }
            if (cmdletContext.TargetId != null)
            {
                request.TargetId = cmdletContext.TargetId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.PolicyId;
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
        
        private Amazon.Organizations.Model.AttachPolicyResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.AttachPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "AttachPolicy");
            try
            {
                #if DESKTOP
                return client.AttachPolicy(request);
                #elif CORECLR
                return client.AttachPolicyAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String PolicyId { get; set; }
            public System.String TargetId { get; set; }
        }
        
    }
}
