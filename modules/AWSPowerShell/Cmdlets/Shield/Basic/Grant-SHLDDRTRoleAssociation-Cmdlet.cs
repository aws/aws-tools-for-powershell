/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Authorizes the Shield Response Team (SRT) using the specified role, to access your
    /// Amazon Web Services account to assist with DDoS attack mitigation during potential
    /// attacks. This enables the SRT to inspect your WAF configuration and create or update
    /// WAF rules and web ACLs.
    /// 
    ///  
    /// <para>
    /// You can associate only one <code>RoleArn</code> with your subscription. If you submit
    /// an <code>AssociateDRTRole</code> request for an account that already has an associated
    /// role, the new <code>RoleArn</code> will replace the existing <code>RoleArn</code>.
    /// 
    /// </para><para>
    /// Prior to making the <code>AssociateDRTRole</code> request, you must attach the <code>AWSShieldDRTAccessPolicy</code>
    /// managed policy to the role that you'll specify in the request. You can access this
    /// policy in the IAM console at <a href="https://console.aws.amazon.com/iam/home?#/policies/arn:aws:iam::aws:policy/service-role/AWSShieldDRTAccessPolicy">AWSShieldDRTAccessPolicy</a>.
    /// For more information see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_manage-attach-detach.html">Adding
    /// and removing IAM identity permissions</a>. The role must also trust the service principal
    /// <code>drt.shield.amazonaws.com</code>. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_elements_principal.html">IAM
    /// JSON policy elements: Principal</a>.
    /// </para><para>
    /// The SRT will have access only to your WAF and Shield resources. By submitting this
    /// request, you authorize the SRT to inspect your WAF and Shield configuration and create
    /// and update WAF rules and web ACLs on your behalf. The SRT takes these actions only
    /// if explicitly authorized by you.
    /// </para><para>
    /// You must have the <code>iam:PassRole</code> permission to make an <code>AssociateDRTRole</code>
    /// request. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_use_passrole.html">Granting
    /// a user permissions to pass a role to an Amazon Web Services service</a>. 
    /// </para><para>
    /// To use the services of the SRT and make an <code>AssociateDRTRole</code> request,
    /// you must be subscribed to the <a href="https://docs.aws.amazon.com/premiumsupport/business-support/">Business
    /// Support plan</a> or the <a href="https://docs.aws.amazon.com/premiumsupport/enterprise-support/">Enterprise
    /// Support plan</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Grant", "SHLDDRTRoleAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Shield AssociateDRTRole API operation.", Operation = new[] {"AssociateDRTRole"}, SelectReturnType = typeof(Amazon.Shield.Model.AssociateDRTRoleResponse))]
    [AWSCmdletOutput("None or Amazon.Shield.Model.AssociateDRTRoleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Shield.Model.AssociateDRTRoleResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GrantSHLDDRTRoleAssociationCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role the SRT will use to access your Amazon
        /// Web Services account.</para><para>Prior to making the <code>AssociateDRTRole</code> request, you must attach the <a href="https://console.aws.amazon.com/iam/home?#/policies/arn:aws:iam::aws:policy/service-role/AWSShieldDRTAccessPolicy">AWSShieldDRTAccessPolicy</a>
        /// managed policy to this role. For more information see <a href=" https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_manage-attach-detach.html">Attaching
        /// and Detaching IAM Policies</a>.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.AssociateDRTRoleResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RoleArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RoleArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RoleArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Grant-SHLDDRTRoleAssociation (AssociateDRTRole)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.AssociateDRTRoleResponse, GrantSHLDDRTRoleAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RoleArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Shield.Model.AssociateDRTRoleRequest();
            
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Shield.Model.AssociateDRTRoleResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.AssociateDRTRoleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "AssociateDRTRole");
            try
            {
                #if DESKTOP
                return client.AssociateDRTRole(request);
                #elif CORECLR
                return client.AssociateDRTRoleAsync(request).GetAwaiter().GetResult();
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
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.Shield.Model.AssociateDRTRoleResponse, GrantSHLDDRTRoleAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
