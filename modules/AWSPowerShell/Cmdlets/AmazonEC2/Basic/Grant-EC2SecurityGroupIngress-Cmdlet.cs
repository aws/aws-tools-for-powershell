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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Adds one or more ingress rules to a security group.
    /// 
    ///  
    /// <para>
    /// Rule changes are propagated to instances within the security group as quickly as possible.
    /// However, a small delay might occur.
    /// </para><para>
    /// [EC2-Classic] This action gives one or more IPv4 CIDR address ranges permission to
    /// access a security group in your account, or gives one or more security groups (called
    /// the <i>source groups</i>) permission to access a security group for your account.
    /// A source group can be for your own AWS account, or another. You can have up to 100
    /// rules per group.
    /// </para><para>
    /// [EC2-VPC] This action gives one or more IPv4 or IPv6 CIDR address ranges permission
    /// to access a security group in your VPC, or gives one or more other security groups
    /// (called the <i>source groups</i>) permission to access a security group for your VPC.
    /// The security groups must all be for the same VPC or a peer VPC in a VPC peering connection.
    /// For more information about VPC security group limits, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_Appendix_Limits.html">Amazon
    /// VPC Limits</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Grant", "EC2SecurityGroupIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the AuthorizeSecurityGroupIngress operation against Amazon Elastic Compute Cloud.", Operation = new[] {"AuthorizeSecurityGroupIngress"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the GroupId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.AuthorizeSecurityGroupIngressResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GrantEC2SecurityGroupIngressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the security group. Required for a nondefault VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GroupId { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>[EC2-Classic, default VPC] The name of the security group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter IpPermission
        /// <summary>
        /// <para>
        /// <para>A set of IP permissions. Can be used to specify multiple rules in a single command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IpPermissions")]
        public Amazon.EC2.Model.IpPermission[] IpPermission { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the GroupId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GroupId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Grant-EC2SecurityGroupIngress (AuthorizeSecurityGroupIngress)"))
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
            
            context.GroupId = this.GroupId;
            context.GroupName = this.GroupName;
            if (this.IpPermission != null)
            {
                context.IpPermissions = new List<Amazon.EC2.Model.IpPermission>(this.IpPermission);
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
            var request = new Amazon.EC2.Model.AuthorizeSecurityGroupIngressRequest();
            
            if (cmdletContext.GroupId != null)
            {
                request.GroupId = cmdletContext.GroupId;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.IpPermissions != null)
            {
                request.IpPermissions = cmdletContext.IpPermissions;
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
                    pipelineOutput = this.GroupId;
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
        
        private static Amazon.EC2.Model.AuthorizeSecurityGroupIngressResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AuthorizeSecurityGroupIngressRequest request)
        {
            #if DESKTOP
            return client.AuthorizeSecurityGroupIngress(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AuthorizeSecurityGroupIngressAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String GroupId { get; set; }
            public System.String GroupName { get; set; }
            public List<Amazon.EC2.Model.IpPermission> IpPermissions { get; set; }
        }
        
    }
}
