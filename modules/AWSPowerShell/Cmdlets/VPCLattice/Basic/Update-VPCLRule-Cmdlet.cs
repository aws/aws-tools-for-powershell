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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Updates a specified rule for the listener. You can't modify a default listener rule.
    /// To modify a default listener rule, use <c>UpdateListener</c>.
    /// </summary>
    [Cmdlet("Update", "VPCLRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.UpdateRuleResponse")]
    [AWSCmdlet("Calls the VPC Lattice UpdateRule API operation.", Operation = new[] {"UpdateRule"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.UpdateRuleResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.UpdateRuleResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.UpdateRuleResponse object containing multiple properties."
    )]
    public partial class UpdateVPCLRuleCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PathMatch_CaseSensitive
        /// <summary>
        /// <para>
        /// <para>Indicates whether the match is case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_HttpMatch_PathMatch_CaseSensitive")]
        public System.Boolean? PathMatch_CaseSensitive { get; set; }
        #endregion
        
        #region Parameter Match_Exact
        /// <summary>
        /// <para>
        /// <para>An exact match of the path.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_HttpMatch_PathMatch_Match_Exact")]
        public System.String Match_Exact { get; set; }
        #endregion
        
        #region Parameter HttpMatch_HeaderMatch
        /// <summary>
        /// <para>
        /// <para>The header matches. Matches incoming requests with rule based on request header value
        /// before applying rule action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_HttpMatch_HeaderMatches")]
        public Amazon.VPCLattice.Model.HeaderMatch[] HttpMatch_HeaderMatch { get; set; }
        #endregion
        
        #region Parameter ListenerIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the listener.</para>
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
        public System.String ListenerIdentifier { get; set; }
        #endregion
        
        #region Parameter HttpMatch_Method
        /// <summary>
        /// <para>
        /// <para>The HTTP method type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_HttpMatch_Method")]
        public System.String HttpMatch_Method { get; set; }
        #endregion
        
        #region Parameter Match_Prefix
        /// <summary>
        /// <para>
        /// <para>A prefix match of the path.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Match_HttpMatch_PathMatch_Match_Prefix")]
        public System.String Match_Prefix { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The rule priority. A listener can't have multiple rules with the same priority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter RuleIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the rule.</para>
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
        public System.String RuleIdentifier { get; set; }
        #endregion
        
        #region Parameter ServiceIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the service.</para>
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
        public System.String ServiceIdentifier { get; set; }
        #endregion
        
        #region Parameter FixedResponse_StatusCode
        /// <summary>
        /// <para>
        /// <para>The HTTP response code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_FixedResponse_StatusCode")]
        public System.Int32? FixedResponse_StatusCode { get; set; }
        #endregion
        
        #region Parameter Forward_TargetGroup
        /// <summary>
        /// <para>
        /// <para>The target groups. Traffic matching the rule is forwarded to the specified target
        /// groups. With forward actions, you can assign a weight that controls the prioritization
        /// and selection of each target group. This means that requests are distributed to individual
        /// target groups based on their weights. For example, if two target groups have the same
        /// weight, each target group receives half of the traffic.</para><para>The default value is 1. This means that if only one target group is provided, there
        /// is no need to set the weight; 100% of the traffic goes to that target group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Action_Forward_TargetGroups")]
        public Amazon.VPCLattice.Model.WeightedTargetGroup[] Forward_TargetGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.UpdateRuleResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.UpdateRuleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ListenerIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-VPCLRule (UpdateRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.UpdateRuleResponse, UpdateVPCLRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FixedResponse_StatusCode = this.FixedResponse_StatusCode;
            if (this.Forward_TargetGroup != null)
            {
                context.Forward_TargetGroup = new List<Amazon.VPCLattice.Model.WeightedTargetGroup>(this.Forward_TargetGroup);
            }
            context.ListenerIdentifier = this.ListenerIdentifier;
            #if MODULAR
            if (this.ListenerIdentifier == null && ParameterWasBound(nameof(this.ListenerIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ListenerIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.HttpMatch_HeaderMatch != null)
            {
                context.HttpMatch_HeaderMatch = new List<Amazon.VPCLattice.Model.HeaderMatch>(this.HttpMatch_HeaderMatch);
            }
            context.HttpMatch_Method = this.HttpMatch_Method;
            context.PathMatch_CaseSensitive = this.PathMatch_CaseSensitive;
            context.Match_Exact = this.Match_Exact;
            context.Match_Prefix = this.Match_Prefix;
            context.Priority = this.Priority;
            context.RuleIdentifier = this.RuleIdentifier;
            #if MODULAR
            if (this.RuleIdentifier == null && ParameterWasBound(nameof(this.RuleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceIdentifier = this.ServiceIdentifier;
            #if MODULAR
            if (this.ServiceIdentifier == null && ParameterWasBound(nameof(this.ServiceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.UpdateRuleRequest();
            
            
             // populate Action
            var requestActionIsNull = true;
            request.Action = new Amazon.VPCLattice.Model.RuleAction();
            Amazon.VPCLattice.Model.FixedResponseAction requestAction_action_FixedResponse = null;
            
             // populate FixedResponse
            var requestAction_action_FixedResponseIsNull = true;
            requestAction_action_FixedResponse = new Amazon.VPCLattice.Model.FixedResponseAction();
            System.Int32? requestAction_action_FixedResponse_fixedResponse_StatusCode = null;
            if (cmdletContext.FixedResponse_StatusCode != null)
            {
                requestAction_action_FixedResponse_fixedResponse_StatusCode = cmdletContext.FixedResponse_StatusCode.Value;
            }
            if (requestAction_action_FixedResponse_fixedResponse_StatusCode != null)
            {
                requestAction_action_FixedResponse.StatusCode = requestAction_action_FixedResponse_fixedResponse_StatusCode.Value;
                requestAction_action_FixedResponseIsNull = false;
            }
             // determine if requestAction_action_FixedResponse should be set to null
            if (requestAction_action_FixedResponseIsNull)
            {
                requestAction_action_FixedResponse = null;
            }
            if (requestAction_action_FixedResponse != null)
            {
                request.Action.FixedResponse = requestAction_action_FixedResponse;
                requestActionIsNull = false;
            }
            Amazon.VPCLattice.Model.ForwardAction requestAction_action_Forward = null;
            
             // populate Forward
            var requestAction_action_ForwardIsNull = true;
            requestAction_action_Forward = new Amazon.VPCLattice.Model.ForwardAction();
            List<Amazon.VPCLattice.Model.WeightedTargetGroup> requestAction_action_Forward_forward_TargetGroup = null;
            if (cmdletContext.Forward_TargetGroup != null)
            {
                requestAction_action_Forward_forward_TargetGroup = cmdletContext.Forward_TargetGroup;
            }
            if (requestAction_action_Forward_forward_TargetGroup != null)
            {
                requestAction_action_Forward.TargetGroups = requestAction_action_Forward_forward_TargetGroup;
                requestAction_action_ForwardIsNull = false;
            }
             // determine if requestAction_action_Forward should be set to null
            if (requestAction_action_ForwardIsNull)
            {
                requestAction_action_Forward = null;
            }
            if (requestAction_action_Forward != null)
            {
                request.Action.Forward = requestAction_action_Forward;
                requestActionIsNull = false;
            }
             // determine if request.Action should be set to null
            if (requestActionIsNull)
            {
                request.Action = null;
            }
            if (cmdletContext.ListenerIdentifier != null)
            {
                request.ListenerIdentifier = cmdletContext.ListenerIdentifier;
            }
            
             // populate Match
            var requestMatchIsNull = true;
            request.Match = new Amazon.VPCLattice.Model.RuleMatch();
            Amazon.VPCLattice.Model.HttpMatch requestMatch_match_HttpMatch = null;
            
             // populate HttpMatch
            var requestMatch_match_HttpMatchIsNull = true;
            requestMatch_match_HttpMatch = new Amazon.VPCLattice.Model.HttpMatch();
            List<Amazon.VPCLattice.Model.HeaderMatch> requestMatch_match_HttpMatch_httpMatch_HeaderMatch = null;
            if (cmdletContext.HttpMatch_HeaderMatch != null)
            {
                requestMatch_match_HttpMatch_httpMatch_HeaderMatch = cmdletContext.HttpMatch_HeaderMatch;
            }
            if (requestMatch_match_HttpMatch_httpMatch_HeaderMatch != null)
            {
                requestMatch_match_HttpMatch.HeaderMatches = requestMatch_match_HttpMatch_httpMatch_HeaderMatch;
                requestMatch_match_HttpMatchIsNull = false;
            }
            System.String requestMatch_match_HttpMatch_httpMatch_Method = null;
            if (cmdletContext.HttpMatch_Method != null)
            {
                requestMatch_match_HttpMatch_httpMatch_Method = cmdletContext.HttpMatch_Method;
            }
            if (requestMatch_match_HttpMatch_httpMatch_Method != null)
            {
                requestMatch_match_HttpMatch.Method = requestMatch_match_HttpMatch_httpMatch_Method;
                requestMatch_match_HttpMatchIsNull = false;
            }
            Amazon.VPCLattice.Model.PathMatch requestMatch_match_HttpMatch_match_HttpMatch_PathMatch = null;
            
             // populate PathMatch
            var requestMatch_match_HttpMatch_match_HttpMatch_PathMatchIsNull = true;
            requestMatch_match_HttpMatch_match_HttpMatch_PathMatch = new Amazon.VPCLattice.Model.PathMatch();
            System.Boolean? requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_pathMatch_CaseSensitive = null;
            if (cmdletContext.PathMatch_CaseSensitive != null)
            {
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_pathMatch_CaseSensitive = cmdletContext.PathMatch_CaseSensitive.Value;
            }
            if (requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_pathMatch_CaseSensitive != null)
            {
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch.CaseSensitive = requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_pathMatch_CaseSensitive.Value;
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatchIsNull = false;
            }
            Amazon.VPCLattice.Model.PathMatchType requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match = null;
            
             // populate Match
            var requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_MatchIsNull = true;
            requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match = new Amazon.VPCLattice.Model.PathMatchType();
            System.String requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match_match_Exact = null;
            if (cmdletContext.Match_Exact != null)
            {
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match_match_Exact = cmdletContext.Match_Exact;
            }
            if (requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match_match_Exact != null)
            {
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match.Exact = requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match_match_Exact;
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_MatchIsNull = false;
            }
            System.String requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match_match_Prefix = null;
            if (cmdletContext.Match_Prefix != null)
            {
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match_match_Prefix = cmdletContext.Match_Prefix;
            }
            if (requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match_match_Prefix != null)
            {
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match.Prefix = requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match_match_Prefix;
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_MatchIsNull = false;
            }
             // determine if requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match should be set to null
            if (requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_MatchIsNull)
            {
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match = null;
            }
            if (requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match != null)
            {
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch.Match = requestMatch_match_HttpMatch_match_HttpMatch_PathMatch_match_HttpMatch_PathMatch_Match;
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatchIsNull = false;
            }
             // determine if requestMatch_match_HttpMatch_match_HttpMatch_PathMatch should be set to null
            if (requestMatch_match_HttpMatch_match_HttpMatch_PathMatchIsNull)
            {
                requestMatch_match_HttpMatch_match_HttpMatch_PathMatch = null;
            }
            if (requestMatch_match_HttpMatch_match_HttpMatch_PathMatch != null)
            {
                requestMatch_match_HttpMatch.PathMatch = requestMatch_match_HttpMatch_match_HttpMatch_PathMatch;
                requestMatch_match_HttpMatchIsNull = false;
            }
             // determine if requestMatch_match_HttpMatch should be set to null
            if (requestMatch_match_HttpMatchIsNull)
            {
                requestMatch_match_HttpMatch = null;
            }
            if (requestMatch_match_HttpMatch != null)
            {
                request.Match.HttpMatch = requestMatch_match_HttpMatch;
                requestMatchIsNull = false;
            }
             // determine if request.Match should be set to null
            if (requestMatchIsNull)
            {
                request.Match = null;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.RuleIdentifier != null)
            {
                request.RuleIdentifier = cmdletContext.RuleIdentifier;
            }
            if (cmdletContext.ServiceIdentifier != null)
            {
                request.ServiceIdentifier = cmdletContext.ServiceIdentifier;
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
        
        private Amazon.VPCLattice.Model.UpdateRuleResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.UpdateRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "UpdateRule");
            try
            {
                return client.UpdateRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? FixedResponse_StatusCode { get; set; }
            public List<Amazon.VPCLattice.Model.WeightedTargetGroup> Forward_TargetGroup { get; set; }
            public System.String ListenerIdentifier { get; set; }
            public List<Amazon.VPCLattice.Model.HeaderMatch> HttpMatch_HeaderMatch { get; set; }
            public System.String HttpMatch_Method { get; set; }
            public System.Boolean? PathMatch_CaseSensitive { get; set; }
            public System.String Match_Exact { get; set; }
            public System.String Match_Prefix { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String RuleIdentifier { get; set; }
            public System.String ServiceIdentifier { get; set; }
            public System.Func<Amazon.VPCLattice.Model.UpdateRuleResponse, UpdateVPCLRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
