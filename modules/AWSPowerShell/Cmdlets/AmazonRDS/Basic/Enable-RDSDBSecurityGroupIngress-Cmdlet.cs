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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Enables ingress to a DBSecurityGroup using one of two forms of authorization. First,
    /// EC2 or VPC security groups can be added to the DBSecurityGroup if the application
    /// using the database is running on EC2 or VPC instances. Second, IP ranges are available
    /// if the application accessing your database is running on the Internet. Required parameters
    /// for this API are one of CIDR range, EC2SecurityGroupId for VPC, or (EC2SecurityGroupOwnerId
    /// and either EC2SecurityGroupName or EC2SecurityGroupId for non-VPC). 
    /// 
    ///  <note> You cannot authorize ingress from an EC2 security group in one region to an
    /// Amazon RDS DB instance in another. You cannot authorize ingress from a VPC security
    /// group in one VPC to an Amazon RDS DB instance in another. </note><para>
    /// For an overview of CIDR ranges, go to the <a href="http://en.wikipedia.org/wiki/Classless_Inter-Domain_Routing">Wikipedia
    /// Tutorial</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "RDSDBSecurityGroupIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBSecurityGroup")]
    [AWSCmdlet("Invokes the AuthorizeDBSecurityGroupIngress operation against Amazon Relational Database Service.", Operation = new[] {"AuthorizeDBSecurityGroupIngress"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSecurityGroup",
        "This cmdlet returns a DBSecurityGroup object.",
        "The service call response (type Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EnableRDSDBSecurityGroupIngressCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The IP range to authorize. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String CIDRIP { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the DB security group to add authorization to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBSecurityGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Id of the EC2 security group to authorize. For VPC DB security groups, <code>EC2SecurityGroupId</code>
        /// must be provided. Otherwise, <code>EC2SecurityGroupOwnerId</code> and either <code>EC2SecurityGroupName</code>
        /// or <code>EC2SecurityGroupId</code> must be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Name of the EC2 security group to authorize. For VPC DB security groups, <code>EC2SecurityGroupId</code>
        /// must be provided. Otherwise, <code>EC2SecurityGroupOwnerId</code> and either <code>EC2SecurityGroupName</code>
        /// or <code>EC2SecurityGroupId</code> must be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> AWS account number of the owner of the EC2 security group specified in the <code>EC2SecurityGroupName</code>
        /// parameter. The AWS Access Key ID is not an acceptable value. For VPC DB security groups,
        /// <code>EC2SecurityGroupId</code> must be provided. Otherwise, <code>EC2SecurityGroupOwnerId</code>
        /// and either <code>EC2SecurityGroupName</code> or <code>EC2SecurityGroupId</code> must
        /// be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupOwnerId { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBSecurityGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-RDSDBSecurityGroupIngress (AuthorizeDBSecurityGroupIngress)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CIDRIP = this.CIDRIP;
            context.DBSecurityGroupName = this.DBSecurityGroupName;
            context.EC2SecurityGroupId = this.EC2SecurityGroupId;
            context.EC2SecurityGroupName = this.EC2SecurityGroupName;
            context.EC2SecurityGroupOwnerId = this.EC2SecurityGroupOwnerId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressRequest();
            
            if (cmdletContext.CIDRIP != null)
            {
                request.CIDRIP = cmdletContext.CIDRIP;
            }
            if (cmdletContext.DBSecurityGroupName != null)
            {
                request.DBSecurityGroupName = cmdletContext.DBSecurityGroupName;
            }
            if (cmdletContext.EC2SecurityGroupId != null)
            {
                request.EC2SecurityGroupId = cmdletContext.EC2SecurityGroupId;
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
                var response = client.AuthorizeDBSecurityGroupIngress(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBSecurityGroup;
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
            public System.String CIDRIP { get; set; }
            public System.String DBSecurityGroupName { get; set; }
            public System.String EC2SecurityGroupId { get; set; }
            public System.String EC2SecurityGroupName { get; set; }
            public System.String EC2SecurityGroupOwnerId { get; set; }
        }
        
    }
}
