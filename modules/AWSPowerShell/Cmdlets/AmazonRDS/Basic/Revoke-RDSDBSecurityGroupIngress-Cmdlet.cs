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
    /// Revokes ingress from a DBSecurityGroup for previously authorized IP ranges or EC2
    /// or VPC Security Groups. Required parameters for this API are one of CIDRIP, EC2SecurityGroupId
    /// for VPC, or (EC2SecurityGroupOwnerId and either EC2SecurityGroupName or EC2SecurityGroupId).
    /// </summary>
    [Cmdlet("Revoke", "RDSDBSecurityGroupIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBSecurityGroup")]
    [AWSCmdlet("Invokes the RevokeDBSecurityGroupIngress operation against Amazon Relational Database Service.", Operation = new[] {"RevokeDBSecurityGroupIngress"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSecurityGroup",
        "This cmdlet returns a DBSecurityGroup object.",
        "The service call response (type Amazon.RDS.Model.RevokeDBSecurityGroupIngressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RevokeRDSDBSecurityGroupIngressCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter CIDRIP
        /// <summary>
        /// <para>
        /// <para> The IP range to revoke access from. Must be a valid CIDR range. If <code>CIDRIP</code>
        /// is specified, <code>EC2SecurityGroupName</code>, <code>EC2SecurityGroupId</code> and
        /// <code>EC2SecurityGroupOwnerId</code> cannot be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String CIDRIP { get; set; }
        #endregion
        
        #region Parameter DBSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB security group to revoke ingress from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupId
        /// <summary>
        /// <para>
        /// <para> The id of the EC2 security group to revoke access from. For VPC DB security groups,
        /// <code>EC2SecurityGroupId</code> must be provided. Otherwise, EC2SecurityGroupOwnerId
        /// and either <code>EC2SecurityGroupName</code> or <code>EC2SecurityGroupId</code> must
        /// be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the EC2 security group to revoke access from. For VPC DB security groups,
        /// <code>EC2SecurityGroupId</code> must be provided. Otherwise, EC2SecurityGroupOwnerId
        /// and either <code>EC2SecurityGroupName</code> or <code>EC2SecurityGroupId</code> must
        /// be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupOwnerId
        /// <summary>
        /// <para>
        /// <para> The AWS Account Number of the owner of the EC2 security group specified in the <code>EC2SecurityGroupName</code>
        /// parameter. The AWS Access Key ID is not an acceptable value. For VPC DB security groups,
        /// <code>EC2SecurityGroupId</code> must be provided. Otherwise, EC2SecurityGroupOwnerId
        /// and either <code>EC2SecurityGroupName</code> or <code>EC2SecurityGroupId</code> must
        /// be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBSecurityGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Revoke-RDSDBSecurityGroupIngress (RevokeDBSecurityGroupIngress)"))
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
            context.DBSecurityGroupName = this.DBSecurityGroupName;
            context.EC2SecurityGroupId = this.EC2SecurityGroupId;
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
            var request = new Amazon.RDS.Model.RevokeDBSecurityGroupIngressRequest();
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.RDS.Model.RevokeDBSecurityGroupIngressResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.RevokeDBSecurityGroupIngressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "RevokeDBSecurityGroupIngress");
            try
            {
                #if DESKTOP
                return client.RevokeDBSecurityGroupIngress(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RevokeDBSecurityGroupIngressAsync(request);
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
            public System.String DBSecurityGroupName { get; set; }
            public System.String EC2SecurityGroupId { get; set; }
            public System.String EC2SecurityGroupName { get; set; }
            public System.String EC2SecurityGroupOwnerId { get; set; }
        }
        
    }
}
