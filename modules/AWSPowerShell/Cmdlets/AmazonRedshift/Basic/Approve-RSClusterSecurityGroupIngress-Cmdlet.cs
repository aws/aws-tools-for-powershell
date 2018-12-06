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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Adds an inbound (ingress) rule to an Amazon Redshift security group. Depending on
    /// whether the application accessing your cluster is running on the Internet or an Amazon
    /// EC2 instance, you can authorize inbound access to either a Classless Interdomain Routing
    /// (CIDR)/Internet Protocol (IP) range or to an Amazon EC2 security group. You can add
    /// as many as 20 ingress rules to an Amazon Redshift security group.
    /// 
    ///  
    /// <para>
    /// If you authorize access to an Amazon EC2 security group, specify <i>EC2SecurityGroupName</i>
    /// and <i>EC2SecurityGroupOwnerId</i>. The Amazon EC2 security group and Amazon Redshift
    /// cluster must be in the same AWS Region. 
    /// </para><para>
    /// If you authorize access to a CIDR/IP address range, specify <i>CIDRIP</i>. For an
    /// overview of CIDR blocks, see the Wikipedia article on <a href="http://en.wikipedia.org/wiki/Classless_Inter-Domain_Routing">Classless
    /// Inter-Domain Routing</a>. 
    /// </para><para>
    /// You must also associate the security group with a cluster so that clients running
    /// on these IP addresses or the EC2 instance are authorized to connect to the cluster.
    /// For information about managing security groups, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-security-groups.html">Working
    /// with Security Groups</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Approve", "RSClusterSecurityGroupIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ClusterSecurityGroup")]
    [AWSCmdlet("Calls the Amazon Redshift AuthorizeClusterSecurityGroupIngress API operation.", Operation = new[] {"AuthorizeClusterSecurityGroupIngress"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.ClusterSecurityGroup",
        "This cmdlet returns a ClusterSecurityGroup object.",
        "The service call response (type Amazon.Redshift.Model.AuthorizeClusterSecurityGroupIngressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ApproveRSClusterSecurityGroupIngressCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter CIDRIP
        /// <summary>
        /// <para>
        /// <para>The IP range to be added the Amazon Redshift security group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String CIDRIP { get; set; }
        #endregion
        
        #region Parameter ClusterSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the security group to which the ingress rule is added.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupName
        /// <summary>
        /// <para>
        /// <para>The EC2 security group to be added the Amazon Redshift security group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupOwnerId
        /// <summary>
        /// <para>
        /// <para>The AWS account number of the owner of the security group specified by the <i>EC2SecurityGroupName</i>
        /// parameter. The AWS Access Key ID is not an acceptable value. </para><para>Example: <code>111122223333</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupOwnerId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterSecurityGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-RSClusterSecurityGroupIngress (AuthorizeClusterSecurityGroupIngress)"))
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
            
            context.CIDRIP = this.CIDRIP;
            context.ClusterSecurityGroupName = this.ClusterSecurityGroupName;
            context.EC2SecurityGroupName = this.EC2SecurityGroupName;
            context.EC2SecurityGroupOwnerId = this.EC2SecurityGroupOwnerId;
            
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
            var request = new Amazon.Redshift.Model.AuthorizeClusterSecurityGroupIngressRequest();
            
            if (cmdletContext.CIDRIP != null)
            {
                request.CIDRIP = cmdletContext.CIDRIP;
            }
            if (cmdletContext.ClusterSecurityGroupName != null)
            {
                request.ClusterSecurityGroupName = cmdletContext.ClusterSecurityGroupName;
            }
            if (cmdletContext.EC2SecurityGroupName != null)
            {
                request.EC2SecurityGroupName = cmdletContext.EC2SecurityGroupName;
            }
            if (cmdletContext.EC2SecurityGroupOwnerId != null)
            {
                request.EC2SecurityGroupOwnerId = cmdletContext.EC2SecurityGroupOwnerId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ClusterSecurityGroup;
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
        
        private Amazon.Redshift.Model.AuthorizeClusterSecurityGroupIngressResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.AuthorizeClusterSecurityGroupIngressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "AuthorizeClusterSecurityGroupIngress");
            try
            {
                #if DESKTOP
                return client.AuthorizeClusterSecurityGroupIngress(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AuthorizeClusterSecurityGroupIngressAsync(request);
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
            public System.String CIDRIP { get; set; }
            public System.String ClusterSecurityGroupName { get; set; }
            public System.String EC2SecurityGroupName { get; set; }
            public System.String EC2SecurityGroupOwnerId { get; set; }
        }
        
    }
}
