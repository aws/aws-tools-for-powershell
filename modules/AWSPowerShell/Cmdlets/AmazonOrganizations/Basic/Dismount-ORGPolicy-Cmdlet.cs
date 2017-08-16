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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Detaches a policy from a target root, organizational unit, or account. If the policy
    /// being detached is a service control policy (SCP), the changes to permissions for IAM
    /// users and roles in affected accounts are immediate.
    /// 
    ///  
    /// <para><b>Note:</b> Every root, OU, and account must have at least one SCP attached. If
    /// you want to replace the default <code>FullAWSAccess</code> policy with one that limits
    /// the permissions that can be delegated, then you must attach the replacement policy
    /// before you can remove the default one. This is the authorization strategy of <a href="http://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_policies_about-scps.html#orgs_policies_whitelist">whitelisting</a>.
    /// If you instead attach a second SCP and leave the <code>FullAWSAccess</code> SCP still
    /// attached, and specify <code>"Effect": "Deny"</code> in the second SCP to override
    /// the <code>"Effect": "Allow"</code> in the <code>FullAWSAccess</code> policy (or any
    /// other attached SCP), then you are using the authorization strategy of <a href="http://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_policies_about-scps.html#orgs_policies_blacklist">blacklisting</a>.
    /// 
    /// </para><para>
    /// This operation can be called only from the organization's master account.
    /// </para>
    /// </summary>
    [Cmdlet("Dismount", "ORGPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the DetachPolicy operation against AWS Organizations.", Operation = new[] {"DetachPolicy"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the PolicyId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Organizations.Model.DetachPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DismountORGPolicyCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the policy you want to detach. You can get the ID from
        /// the <a>ListPolicies</a> or <a>ListPoliciesForTarget</a> operations.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for a policy ID string
        /// requires "p-" followed by from 8 to 128 lower-case letters or digits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PolicyId { get; set; }
        #endregion
        
        #region Parameter TargetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the root, OU, or account from which you want to detach
        /// the policy. You can get the ID from the <a>ListRoots</a>, <a>ListOrganizationalUnitsForParent</a>,
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Dismount-ORGPolicy (DetachPolicy)"))
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
            var request = new Amazon.Organizations.Model.DetachPolicyRequest();
            
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
        
        private Amazon.Organizations.Model.DetachPolicyResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.DetachPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "DetachPolicy");
            try
            {
                #if DESKTOP
                return client.DetachPolicy(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DetachPolicyAsync(request);
                return task.Result;
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
