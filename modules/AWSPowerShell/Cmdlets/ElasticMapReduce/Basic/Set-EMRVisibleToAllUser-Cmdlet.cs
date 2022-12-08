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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// <important><para>
    /// The SetVisibleToAllUsers parameter is no longer supported. Your cluster may be visible
    /// to all users in your account. To restrict cluster access using an IAM policy, see
    /// <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-plan-access-iam.html">Identity
    /// and Access Management for EMR</a>. 
    /// </para></important><para>
    /// Sets the <a>Cluster$VisibleToAllUsers</a> value for an EMR cluster. When <code>true</code>,
    /// IAM principals in the Amazon Web Services account can perform EMR cluster actions
    /// that their IAM policies allow. When <code>false</code>, only the IAM principal that
    /// created the cluster and the Amazon Web Services account root user can perform EMR
    /// actions on the cluster, regardless of IAM permissions policies attached to other IAM
    /// principals.
    /// </para><para>
    /// This action works on running clusters. When you create a cluster, use the <a>RunJobFlowInput$VisibleToAllUsers</a>
    /// parameter.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/security_iam_emr-with-iam.html#security_set_visible_to_all_users">Understanding
    /// the EMR Cluster VisibleToAllUsers Setting</a> in the <i>Amazon EMRManagement Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "EMRVisibleToAllUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce SetVisibleToAllUsers API operation.", Operation = new[] {"SetVisibleToAllUsers"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersResponse), LegacyAlias="Set-EMRVisibleToAllUsers")]
    [AWSCmdletOutput("None or Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetEMRVisibleToAllUserCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter JobFlowId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the job flow (cluster).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("JobFlowIds")]
        public System.String[] JobFlowId { get; set; }
        #endregion
        
        #region Parameter VisibleToAllUser
        /// <summary>
        /// <para>
        /// <para>A value of <code>true</code> indicates that an IAM principal in the Amazon Web Services
        /// account can perform EMR actions on the cluster that the IAM policies attached to the
        /// principal allow. A value of <code>false</code> indicates that only the IAM principal
        /// that created the cluster and the Amazon Web Services root user can perform EMR actions
        /// on the cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("VisibleToAllUsers")]
        public System.Boolean? VisibleToAllUser { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobFlowId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobFlowId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobFlowId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobFlowId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EMRVisibleToAllUser (SetVisibleToAllUsers)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersResponse, SetEMRVisibleToAllUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobFlowId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.JobFlowId != null)
            {
                context.JobFlowId = new List<System.String>(this.JobFlowId);
            }
            #if MODULAR
            if (this.JobFlowId == null && ParameterWasBound(nameof(this.JobFlowId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobFlowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VisibleToAllUser = this.VisibleToAllUser;
            #if MODULAR
            if (this.VisibleToAllUser == null && ParameterWasBound(nameof(this.VisibleToAllUser)))
            {
                WriteWarning("You are passing $null as a value for parameter VisibleToAllUser which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersRequest();
            
            if (cmdletContext.JobFlowId != null)
            {
                request.JobFlowIds = cmdletContext.JobFlowId;
            }
            if (cmdletContext.VisibleToAllUser != null)
            {
                request.VisibleToAllUsers = cmdletContext.VisibleToAllUser.Value;
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
        
        private Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "SetVisibleToAllUsers");
            try
            {
                #if DESKTOP
                return client.SetVisibleToAllUsers(request);
                #elif CORECLR
                return client.SetVisibleToAllUsersAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> JobFlowId { get; set; }
            public System.Boolean? VisibleToAllUser { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersResponse, SetEMRVisibleToAllUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
