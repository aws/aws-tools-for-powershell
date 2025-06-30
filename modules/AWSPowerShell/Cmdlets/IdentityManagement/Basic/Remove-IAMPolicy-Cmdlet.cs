/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Deletes the specified managed policy.
    /// 
    ///  
    /// <para>
    /// Before you can delete a managed policy, you must first detach the policy from all
    /// users, groups, and roles that it is attached to. In addition, you must delete all
    /// the policy's versions. The following steps describe the process for deleting a managed
    /// policy:
    /// </para><ul><li><para>
    /// Detach the policy from all users, groups, and roles that the policy is attached to,
    /// using <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_DetachUserPolicy.html">DetachUserPolicy</a>,
    /// <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_DetachGroupPolicy.html">DetachGroupPolicy</a>,
    /// or <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_DetachRolePolicy.html">DetachRolePolicy</a>.
    /// To list all the users, groups, and roles that a policy is attached to, use <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_ListEntitiesForPolicy.html">ListEntitiesForPolicy</a>.
    /// </para></li><li><para>
    /// Delete all versions of the policy using <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_DeletePolicyVersion.html">DeletePolicyVersion</a>.
    /// To list the policy's versions, use <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_ListPolicyVersions.html">ListPolicyVersions</a>.
    /// You cannot use <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_DeletePolicyVersion.html">DeletePolicyVersion</a>
    /// to delete the version that is marked as the default version. You delete the policy's
    /// default version in the next step of the process.
    /// </para></li><li><para>
    /// Delete the policy (this automatically deletes the policy's default version) using
    /// this operation.
    /// </para></li></ul><para>
    /// For information about managed policies, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/policies-managed-vs-inline.html">Managed
    /// policies and inline policies</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "IAMPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management DeletePolicy API operation.", Operation = new[] {"DeletePolicy"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.DeletePolicyResponse))]
    [AWSCmdletOutput("None or Amazon.IdentityManagement.Model.DeletePolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IdentityManagement.Model.DeletePolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveIAMPolicyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM policy you want to delete.</para><para>For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PolicyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.DeletePolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IAMPolicy (DeletePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.DeletePolicyResponse, RemoveIAMPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PolicyArn = this.PolicyArn;
            #if MODULAR
            if (this.PolicyArn == null && ParameterWasBound(nameof(this.PolicyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.IdentityManagement.Model.DeletePolicyRequest();
            
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.IdentityManagement.Model.DeletePolicyResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.DeletePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "DeletePolicy");
            try
            {
                #if DESKTOP
                return client.DeletePolicy(request);
                #elif CORECLR
                return client.DeletePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String PolicyArn { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.DeletePolicyResponse, RemoveIAMPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
