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
using Amazon.FMS;
using Amazon.FMS.Model;

namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Permanently deletes an Firewall Manager policy.
    /// </summary>
    [Cmdlet("Remove", "FMSPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Firewall Management Service DeletePolicy API operation.", Operation = new[] {"DeletePolicy"}, SelectReturnType = typeof(Amazon.FMS.Model.DeletePolicyResponse))]
    [AWSCmdletOutput("None or Amazon.FMS.Model.DeletePolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.FMS.Model.DeletePolicyResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveFMSPolicyCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeleteAllPolicyResource
        /// <summary>
        /// <para>
        /// <para>If <c>True</c>, the request performs cleanup according to the policy type. </para><para>For WAF and Shield Advanced policies, the cleanup does the following:</para><ul><li><para>Deletes rule groups created by Firewall Manager</para></li><li><para>Removes web ACLs from in-scope resources</para></li><li><para>Deletes web ACLs that contain no rules or rule groups</para></li></ul><para>For security group policies, the cleanup does the following for each security group
        /// in the policy:</para><ul><li><para>Disassociates the security group from in-scope resources </para></li><li><para>Deletes the security group if it was created through Firewall Manager and if it's
        /// no longer associated with any resources through another policy</para></li></ul><note><para>For security group common policies, even if set to <c>False</c>, Firewall Manager
        /// deletes all security groups created by Firewall Manager that aren't associated with
        /// any other resources through another policy.</para></note><para>After the cleanup, in-scope resources are no longer protected by web ACLs in this
        /// policy. Protection of out-of-scope resources remains unchanged. Scope is determined
        /// by tags that you create and accounts that you associate with the policy. When creating
        /// the policy, if you specify that only resources in specific accounts or with specific
        /// tags are in scope of the policy, those accounts and resources are handled by the policy.
        /// All others are out of scope. If you don't specify tags or accounts, all resources
        /// are in scope. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteAllPolicyResources")]
        public System.Boolean? DeleteAllPolicyResource { get; set; }
        #endregion
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the policy that you want to delete. You can retrieve this ID from <c>PutPolicy</c>
        /// and <c>ListPolicies</c>.</para>
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
        public System.String PolicyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FMS.Model.DeletePolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-FMSPolicy (DeletePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FMS.Model.DeletePolicyResponse, RemoveFMSPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeleteAllPolicyResource = this.DeleteAllPolicyResource;
            context.PolicyId = this.PolicyId;
            #if MODULAR
            if (this.PolicyId == null && ParameterWasBound(nameof(this.PolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FMS.Model.DeletePolicyRequest();
            
            if (cmdletContext.DeleteAllPolicyResource != null)
            {
                request.DeleteAllPolicyResources = cmdletContext.DeleteAllPolicyResource.Value;
            }
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyId = cmdletContext.PolicyId;
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
        
        private Amazon.FMS.Model.DeletePolicyResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.DeletePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "DeletePolicy");
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
            public System.Boolean? DeleteAllPolicyResource { get; set; }
            public System.String PolicyId { get; set; }
            public System.Func<Amazon.FMS.Model.DeletePolicyResponse, RemoveFMSPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
