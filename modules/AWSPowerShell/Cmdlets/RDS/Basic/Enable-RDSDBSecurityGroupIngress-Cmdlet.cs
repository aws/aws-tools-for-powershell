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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Enables ingress to a DBSecurityGroup using one of two forms of authorization. First,
    /// EC2 or VPC security groups can be added to the DBSecurityGroup if the application
    /// using the database is running on EC2 or VPC instances. Second, IP ranges are available
    /// if the application accessing your database is running on the internet. Required parameters
    /// for this API are one of CIDR range, EC2SecurityGroupId for VPC, or (EC2SecurityGroupOwnerId
    /// and either EC2SecurityGroupName or EC2SecurityGroupId for non-VPC).
    /// 
    ///  
    /// <para>
    /// You can't authorize ingress from an EC2 security group in one Amazon Web Services
    /// Region to an Amazon RDS DB instance in another. You can't authorize ingress from a
    /// VPC security group in one VPC to an Amazon RDS DB instance in another.
    /// </para><para>
    /// For an overview of CIDR ranges, go to the <a href="http://en.wikipedia.org/wiki/Classless_Inter-Domain_Routing">Wikipedia
    /// Tutorial</a>.
    /// </para><note><para>
    /// EC2-Classic was retired on August 15, 2022. If you haven't migrated from EC2-Classic
    /// to a VPC, we recommend that you migrate as soon as possible. For more information,
    /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/vpc-migrate.html">Migrate
    /// from EC2-Classic to a VPC</a> in the <i>Amazon EC2 User Guide</i>, the blog <a href="http://aws.amazon.com/blogs/aws/ec2-classic-is-retiring-heres-how-to-prepare/">EC2-Classic
    /// Networking is Retiring – Here’s How to Prepare</a>, and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_VPC.Non-VPC2VPC.html">Moving
    /// a DB instance not in a VPC into a VPC</a> in the <i>Amazon RDS User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Enable", "RDSDBSecurityGroupIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBSecurityGroup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service AuthorizeDBSecurityGroupIngress API operation.", Operation = new[] {"AuthorizeDBSecurityGroupIngress"}, SelectReturnType = typeof(Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSecurityGroup or Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBSecurityGroup object.",
        "The service call response (type Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableRDSDBSecurityGroupIngressCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CIDRIP
        /// <summary>
        /// <para>
        /// <para>The IP range to authorize.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String CIDRIP { get; set; }
        #endregion
        
        #region Parameter DBSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB security group to add authorization to.</para>
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
        /// <para>Id of the EC2 security group to authorize. For VPC DB security groups, <c>EC2SecurityGroupId</c>
        /// must be provided. Otherwise, <c>EC2SecurityGroupOwnerId</c> and either <c>EC2SecurityGroupName</c>
        /// or <c>EC2SecurityGroupId</c> must be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupName
        /// <summary>
        /// <para>
        /// <para>Name of the EC2 security group to authorize. For VPC DB security groups, <c>EC2SecurityGroupId</c>
        /// must be provided. Otherwise, <c>EC2SecurityGroupOwnerId</c> and either <c>EC2SecurityGroupName</c>
        /// or <c>EC2SecurityGroupId</c> must be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupOwnerId
        /// <summary>
        /// <para>
        /// <para>Amazon Web Services account number of the owner of the EC2 security group specified
        /// in the <c>EC2SecurityGroupName</c> parameter. The Amazon Web Services access key ID
        /// isn't an acceptable value. For VPC DB security groups, <c>EC2SecurityGroupId</c> must
        /// be provided. Otherwise, <c>EC2SecurityGroupOwnerId</c> and either <c>EC2SecurityGroupName</c>
        /// or <c>EC2SecurityGroupId</c> must be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EC2SecurityGroupOwnerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBSecurityGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBSecurityGroup";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-RDSDBSecurityGroupIngress (AuthorizeDBSecurityGroupIngress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressResponse, EnableRDSDBSecurityGroupIngressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
        
        private Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "AuthorizeDBSecurityGroupIngress");
            try
            {
                #if DESKTOP
                return client.AuthorizeDBSecurityGroupIngress(request);
                #elif CORECLR
                return client.AuthorizeDBSecurityGroupIngressAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.RDS.Model.AuthorizeDBSecurityGroupIngressResponse, EnableRDSDBSecurityGroupIngressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBSecurityGroup;
        }
        
    }
}
