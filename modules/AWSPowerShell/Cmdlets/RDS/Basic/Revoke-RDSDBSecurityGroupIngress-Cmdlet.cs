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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Revokes ingress from a DBSecurityGroup for previously authorized IP ranges or EC2
    /// or VPC security groups. Required parameters for this API are one of CIDRIP, EC2SecurityGroupId
    /// for VPC, or (EC2SecurityGroupOwnerId and either EC2SecurityGroupName or EC2SecurityGroupId).
    /// 
    ///  <note><para>
    /// EC2-Classic was retired on August 15, 2022. If you haven't migrated from EC2-Classic
    /// to a VPC, we recommend that you migrate as soon as possible. For more information,
    /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/vpc-migrate.html">Migrate
    /// from EC2-Classic to a VPC</a> in the <i>Amazon EC2 User Guide</i>, the blog <a href="http://aws.amazon.com/blogs/aws/ec2-classic-is-retiring-heres-how-to-prepare/">EC2-Classic
    /// Networking is Retiring – Here’s How to Prepare</a>, and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_VPC.Non-VPC2VPC.html">Moving
    /// a DB instance not in a VPC into a VPC</a> in the <i>Amazon RDS User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Revoke", "RDSDBSecurityGroupIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBSecurityGroup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service RevokeDBSecurityGroupIngress API operation.", Operation = new[] {"RevokeDBSecurityGroupIngress"}, SelectReturnType = typeof(Amazon.RDS.Model.RevokeDBSecurityGroupIngressResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSecurityGroup or Amazon.RDS.Model.RevokeDBSecurityGroupIngressResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBSecurityGroup object.",
        "The service call response (type Amazon.RDS.Model.RevokeDBSecurityGroupIngressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RevokeRDSDBSecurityGroupIngressCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter CIDRIP
        /// <summary>
        /// <para>
        /// <para>The IP range to revoke access from. Must be a valid CIDR range. If <code>CIDRIP</code>
        /// is specified, <code>EC2SecurityGroupName</code>, <code>EC2SecurityGroupId</code> and
        /// <code>EC2SecurityGroupOwnerId</code> can't be provided.</para>
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DBSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The id of the EC2 security group to revoke access from. For VPC DB security groups,
        /// <code>EC2SecurityGroupId</code> must be provided. Otherwise, EC2SecurityGroupOwnerId
        /// and either <code>EC2SecurityGroupName</code> or <code>EC2SecurityGroupId</code> must
        /// be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the EC2 security group to revoke access from. For VPC DB security groups,
        /// <code>EC2SecurityGroupId</code> must be provided. Otherwise, EC2SecurityGroupOwnerId
        /// and either <code>EC2SecurityGroupName</code> or <code>EC2SecurityGroupId</code> must
        /// be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupOwnerId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account number of the owner of the EC2 security group specified
        /// in the <code>EC2SecurityGroupName</code> parameter. The Amazon Web Services access
        /// key ID isn't an acceptable value. For VPC DB security groups, <code>EC2SecurityGroupId</code>
        /// must be provided. Otherwise, EC2SecurityGroupOwnerId and either <code>EC2SecurityGroupName</code>
        /// or <code>EC2SecurityGroupId</code> must be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupOwnerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBSecurityGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.RevokeDBSecurityGroupIngressResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.RevokeDBSecurityGroupIngressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBSecurityGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBSecurityGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBSecurityGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBSecurityGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBSecurityGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Revoke-RDSDBSecurityGroupIngress (RevokeDBSecurityGroupIngress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.RevokeDBSecurityGroupIngressResponse, RevokeRDSDBSecurityGroupIngressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBSecurityGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CIDRIP = this.CIDRIP;
            context.DBSecurityGroupName = this.DBSecurityGroupName;
            #if MODULAR
            if (this.DBSecurityGroupName == null && ParameterWasBound(nameof(this.DBSecurityGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBSecurityGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
        
        private Amazon.RDS.Model.RevokeDBSecurityGroupIngressResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.RevokeDBSecurityGroupIngressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "RevokeDBSecurityGroupIngress");
            try
            {
                #if DESKTOP
                return client.RevokeDBSecurityGroupIngress(request);
                #elif CORECLR
                return client.RevokeDBSecurityGroupIngressAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.RDS.Model.RevokeDBSecurityGroupIngressResponse, RevokeRDSDBSecurityGroupIngressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBSecurityGroup;
        }
        
    }
}
