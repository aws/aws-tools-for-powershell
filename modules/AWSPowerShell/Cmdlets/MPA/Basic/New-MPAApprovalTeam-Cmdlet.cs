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
using System.Threading;
using Amazon.MPA;
using Amazon.MPA.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MPA
{
    /// <summary>
    /// Creates a new approval team. For more information, see <a href="https://docs.aws.amazon.com/mpa/latest/userguide/mpa-concepts.html">Approval
    /// team</a> in the <i>Multi-party approval User Guide</i>.
    /// </summary>
    [Cmdlet("New", "MPAApprovalTeam", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MPA.Model.CreateApprovalTeamResponse")]
    [AWSCmdlet("Calls the AWS Multi-party Approval CreateApprovalTeam API operation.", Operation = new[] {"CreateApprovalTeam"}, SelectReturnType = typeof(Amazon.MPA.Model.CreateApprovalTeamResponse))]
    [AWSCmdletOutput("Amazon.MPA.Model.CreateApprovalTeamResponse",
        "This cmdlet returns an Amazon.MPA.Model.CreateApprovalTeamResponse object containing multiple properties."
    )]
    public partial class NewMPAApprovalTeamCmdlet : AmazonMPAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Approver
        /// <summary>
        /// <para>
        /// <para>An array of <c>ApprovalTeamRequesterApprovers</c> objects. Contains details for the
        /// approvers in the team.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Approvers")]
        public Amazon.MPA.Model.ApprovalTeamRequestApprover[] Approver { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description for the team.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MofN_MinApprovalsRequired
        /// <summary>
        /// <para>
        /// <para>Minimum number of approvals (M) required for a total number of approvers (N).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApprovalStrategy_MofN_MinApprovalsRequired")]
        public System.Int32? MofN_MinApprovalsRequired { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the team.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>An array of <c>PolicyReference</c> objects. Contains a list of policies that define
        /// the permissions for team resources.</para><para>The protected operation for a service integration might require specific permissions.
        /// For more information, see <a href="https://docs.aws.amazon.com/mpa/latest/userguide/mpa-integrations.html">How
        /// other services work with Multi-party approval</a> in the <i>Multi-party approval User
        /// Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Policies")]
        public Amazon.MPA.Model.PolicyReference[] Policy { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags you want to attach to the team.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. If not provided, the Amazon Web Services populates this field.</para><note><para><b>What is idempotency?</b></para><para>When you make a mutating API request, the request typically returns a result before
        /// the operation's asynchronous workflows have completed. Operations might also time
        /// out or encounter other server issues before they complete, even though the request
        /// has already returned a result. This could make it difficult to determine whether the
        /// request succeeded or not, and could lead to multiple retries to ensure that the operation
        /// completes successfully. However, if the original request and the subsequent retries
        /// are successful, the operation is completed multiple times. This means that you might
        /// create more resources than you intended.</para><para><i>Idempotency</i> ensures that an API request completes no more than one time. With
        /// an idempotent request, if the original request completes successfully, any subsequent
        /// retries complete successfully without performing any further actions.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MPA.Model.CreateApprovalTeamResponse).
        /// Specifying the name of a property of type Amazon.MPA.Model.CreateApprovalTeamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MPAApprovalTeam (CreateApprovalTeam)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MPA.Model.CreateApprovalTeamResponse, NewMPAApprovalTeamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MofN_MinApprovalsRequired = this.MofN_MinApprovalsRequired;
            if (this.Approver != null)
            {
                context.Approver = new List<Amazon.MPA.Model.ApprovalTeamRequestApprover>(this.Approver);
            }
            #if MODULAR
            if (this.Approver == null && ParameterWasBound(nameof(this.Approver)))
            {
                WriteWarning("You are passing $null as a value for parameter Approver which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Policy != null)
            {
                context.Policy = new List<Amazon.MPA.Model.PolicyReference>(this.Policy);
            }
            #if MODULAR
            if (this.Policy == null && ParameterWasBound(nameof(this.Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.MPA.Model.CreateApprovalTeamRequest();
            
            
             // populate ApprovalStrategy
            var requestApprovalStrategyIsNull = true;
            request.ApprovalStrategy = new Amazon.MPA.Model.ApprovalStrategy();
            Amazon.MPA.Model.MofNApprovalStrategy requestApprovalStrategy_approvalStrategy_MofN = null;
            
             // populate MofN
            var requestApprovalStrategy_approvalStrategy_MofNIsNull = true;
            requestApprovalStrategy_approvalStrategy_MofN = new Amazon.MPA.Model.MofNApprovalStrategy();
            System.Int32? requestApprovalStrategy_approvalStrategy_MofN_mofN_MinApprovalsRequired = null;
            if (cmdletContext.MofN_MinApprovalsRequired != null)
            {
                requestApprovalStrategy_approvalStrategy_MofN_mofN_MinApprovalsRequired = cmdletContext.MofN_MinApprovalsRequired.Value;
            }
            if (requestApprovalStrategy_approvalStrategy_MofN_mofN_MinApprovalsRequired != null)
            {
                requestApprovalStrategy_approvalStrategy_MofN.MinApprovalsRequired = requestApprovalStrategy_approvalStrategy_MofN_mofN_MinApprovalsRequired.Value;
                requestApprovalStrategy_approvalStrategy_MofNIsNull = false;
            }
             // determine if requestApprovalStrategy_approvalStrategy_MofN should be set to null
            if (requestApprovalStrategy_approvalStrategy_MofNIsNull)
            {
                requestApprovalStrategy_approvalStrategy_MofN = null;
            }
            if (requestApprovalStrategy_approvalStrategy_MofN != null)
            {
                request.ApprovalStrategy.MofN = requestApprovalStrategy_approvalStrategy_MofN;
                requestApprovalStrategyIsNull = false;
            }
             // determine if request.ApprovalStrategy should be set to null
            if (requestApprovalStrategyIsNull)
            {
                request.ApprovalStrategy = null;
            }
            if (cmdletContext.Approver != null)
            {
                request.Approvers = cmdletContext.Approver;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policies = cmdletContext.Policy;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.MPA.Model.CreateApprovalTeamResponse CallAWSServiceOperation(IAmazonMPA client, Amazon.MPA.Model.CreateApprovalTeamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Multi-party Approval", "CreateApprovalTeam");
            try
            {
                return client.CreateApprovalTeamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? MofN_MinApprovalsRequired { get; set; }
            public List<Amazon.MPA.Model.ApprovalTeamRequestApprover> Approver { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.MPA.Model.PolicyReference> Policy { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MPA.Model.CreateApprovalTeamResponse, NewMPAApprovalTeamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
