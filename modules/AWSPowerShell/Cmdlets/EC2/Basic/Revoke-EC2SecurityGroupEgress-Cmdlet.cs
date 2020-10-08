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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// [VPC only] Removes the specified egress rules from a security group for EC2-VPC. This
    /// action does not apply to security groups for use in EC2-Classic. To remove a rule,
    /// the values that you specify (for example, ports) must match the existing rule's values
    /// exactly.
    /// 
    ///  <note><para>
    /// [Default VPC] If the values you specify do not match the existing rule's values, no
    /// error is returned, and the output describes the security group rules that were not
    /// revoked. 
    /// </para><para>
    /// AWS recommends that you use <a>DescribeSecurityGroups</a> to verify that the rule
    /// has been removed.
    /// </para></note><para>
    /// Each rule consists of the protocol and the IPv4 or IPv6 CIDR range or source security
    /// group. For the TCP and UDP protocols, you must also specify the destination port or
    /// range of ports. For the ICMP protocol, you must also specify the ICMP type and code.
    /// If the security group rule has a description, you do not have to specify the description
    /// to revoke the rule.
    /// </para><para>
    /// Rule changes are propagated to instances within the security group as quickly as possible.
    /// However, a small delay might occur.
    /// </para>
    /// </summary>
    [Cmdlet("Revoke", "EC2SecurityGroupEgress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.RevokeSecurityGroupEgressResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) RevokeSecurityGroupEgress API operation.", Operation = new[] {"RevokeSecurityGroupEgress"}, SelectReturnType = typeof(Amazon.EC2.Model.RevokeSecurityGroupEgressResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.RevokeSecurityGroupEgressResponse",
        "This cmdlet returns an Amazon.EC2.Model.RevokeSecurityGroupEgressResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RevokeEC2SecurityGroupEgressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the security group.</para>
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
        public System.String GroupId { get; set; }
        #endregion
        
        #region Parameter IpPermission
        /// <summary>
        /// <para>
        /// <para>The sets of IP permissions. You can't specify a destination security group and a CIDR
        /// IP address range in the same set of permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("IpPermissions")]
        public Amazon.EC2.Model.IpPermission[] IpPermission { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.RevokeSecurityGroupEgressResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.RevokeSecurityGroupEgressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GroupId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Revoke-EC2SecurityGroupEgress (RevokeSecurityGroupEgress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.RevokeSecurityGroupEgressResponse, RevokeEC2SecurityGroupEgressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GroupId = this.GroupId;
            #if MODULAR
            if (this.GroupId == null && ParameterWasBound(nameof(this.GroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.IpPermission != null)
            {
                context.IpPermission = new List<Amazon.EC2.Model.IpPermission>(this.IpPermission);
            }
            
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
            var request = new Amazon.EC2.Model.RevokeSecurityGroupEgressRequest();
            
            if (cmdletContext.GroupId != null)
            {
                request.GroupId = cmdletContext.GroupId;
            }
            if (cmdletContext.IpPermission != null)
            {
                request.IpPermissions = cmdletContext.IpPermission;
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
        
        private Amazon.EC2.Model.RevokeSecurityGroupEgressResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RevokeSecurityGroupEgressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "RevokeSecurityGroupEgress");
            try
            {
                #if DESKTOP
                return client.RevokeSecurityGroupEgress(request);
                #elif CORECLR
                return client.RevokeSecurityGroupEgressAsync(request).GetAwaiter().GetResult();
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
            public System.String GroupId { get; set; }
            public List<Amazon.EC2.Model.IpPermission> IpPermission { get; set; }
            public System.Func<Amazon.EC2.Model.RevokeSecurityGroupEgressResponse, RevokeEC2SecurityGroupEgressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
