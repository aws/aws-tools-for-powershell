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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Enables an IPAM policy.
    /// 
    ///  
    /// <para>
    /// An IPAM policy is a set of rules that define how public IPv4 addresses from IPAM pools
    /// are allocated to Amazon Web Services resources. Each rule maps an Amazon Web Services
    /// service to IPAM pools that the service will use to get IP addresses. A single policy
    /// can have multiple rules and be applied to multiple Amazon Web Services Regions. If
    /// the IPAM pool run out of addresses then the services fallback to Amazon-provided IP
    /// addresses. A policy can be applied to an individual Amazon Web Services account or
    /// an entity within Amazon Web Services Organizations.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/define-public-ipv4-allocation-strategy-with-ipam-policies.html">Define
    /// public IPv4 allocation strategy with IPAM policies</a> in the <i>Amazon VPC IPAM User
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "EC2IpamPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) EnableIpamPolicy API operation.", Operation = new[] {"EnableIpamPolicy"}, SelectReturnType = typeof(Amazon.EC2.Model.EnableIpamPolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.EnableIpamPolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.EnableIpamPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableEC2IpamPolicyCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IpamPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPAM policy to enable.</para>
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
        public System.String IpamPolicyId { get; set; }
        #endregion
        
        #region Parameter OrganizationTargetId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Organizations target for which to enable the IPAM
        /// policy. This parameter is required only when IPAM is integrated with Amazon Web Services
        /// Organizations. When IPAM is not integrated with Amazon Web Services Organizations,
        /// omit this parameter and the policy will apply to the current account.</para><para>A target can be an individual Amazon Web Services account or an entity within an Amazon
        /// Web Services Organization to which an IPAM policy can be applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationTargetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IpamPolicyId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.EnableIpamPolicyResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.EnableIpamPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IpamPolicyId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IpamPolicyId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IpamPolicyId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IpamPolicyId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IpamPolicyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-EC2IpamPolicy (EnableIpamPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.EnableIpamPolicyResponse, EnableEC2IpamPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IpamPolicyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IpamPolicyId = this.IpamPolicyId;
            #if MODULAR
            if (this.IpamPolicyId == null && ParameterWasBound(nameof(this.IpamPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter IpamPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationTargetId = this.OrganizationTargetId;
            
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
            var request = new Amazon.EC2.Model.EnableIpamPolicyRequest();
            
            if (cmdletContext.IpamPolicyId != null)
            {
                request.IpamPolicyId = cmdletContext.IpamPolicyId;
            }
            if (cmdletContext.OrganizationTargetId != null)
            {
                request.OrganizationTargetId = cmdletContext.OrganizationTargetId;
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
        
        private Amazon.EC2.Model.EnableIpamPolicyResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.EnableIpamPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "EnableIpamPolicy");
            try
            {
                #if DESKTOP
                return client.EnableIpamPolicy(request);
                #elif CORECLR
                return client.EnableIpamPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String IpamPolicyId { get; set; }
            public System.String OrganizationTargetId { get; set; }
            public System.Func<Amazon.EC2.Model.EnableIpamPolicyResponse, EnableEC2IpamPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IpamPolicyId;
        }
        
    }
}
