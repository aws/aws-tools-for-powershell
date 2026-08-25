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
using Amazon.DevOpsAgent;
using Amazon.DevOpsAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOPS
{
    /// <summary>
    /// Updates an approval request with the terminal decision (APPROVED or REJECTED). A single
    /// operation handles both verbs via the action enum.
    /// </summary>
    [Cmdlet("Update", "DOPSApprovalAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DevOpsAgent.Model.UpdateApprovalActionResponse")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service UpdateApprovalAction API operation.", Operation = new[] {"UpdateApprovalAction"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.UpdateApprovalActionResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.UpdateApprovalActionResponse",
        "This cmdlet returns an Amazon.DevOpsAgent.Model.UpdateApprovalActionResponse object containing multiple properties."
    )]
    public partial class UpdateDOPSApprovalActionCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action to take on the approval request — APPROVED or REJECTED.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DevOpsAgent.ApprovalActionType")]
        public Amazon.DevOpsAgent.ApprovalActionType Action { get; set; }
        #endregion
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The agent space identifier — multi-tenant workspace scope. Bound from the request
        /// URI.</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter ApprovalId
        /// <summary>
        /// <para>
        /// <para>Identifier of the approval request being resolved. A UUID. Bound from the request
        /// URI.</para>
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
        public System.String ApprovalId { get; set; }
        #endregion
        
        #region Parameter FinalPattern_ArgumentPin
        /// <summary>
        /// <para>
        /// <para>Argument constraints that narrow which tool invocations the pattern matches. For AWS
        /// tools, the map must include `operation` (the IAM action, e.g. `ec2:AuthorizeSecurityGroupIngress`)
        /// and `resource_arn` (the resource ARN or ARN glob); additional narrowing arguments
        /// go in further pin keys. The same `{tool, argumentPins}` shape is used uniformly for
        /// AWS and third-party tools, with tool-specific keys for third-party tools. Requests
        /// whose argument pins are collectively too large are rejected with a ValidationException.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FinalPattern_ArgumentPins")]
        public System.Collections.Hashtable FinalPattern_ArgumentPin { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>Optional free-text rationale for the decision. Permitted when `action` is REJECTED;
        /// ignored when `action` is APPROVED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reason { get; set; }
        #endregion
        
        #region Parameter SingleUse
        /// <summary>
        /// <para>
        /// <para>Whether the approved action backs a single executed tool call (true) or is reusable
        /// within ttlSeconds (false). Required when `action` is APPROVED; must be absent when
        /// `action` is REJECTED. When true, ttlSeconds must be absent (the redemption window
        /// collapses to the single use). When false, ttlSeconds is required and bounds the reuse
        /// window. Cross-field invariants are enforced by service-side validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SingleUse { get; set; }
        #endregion
        
        #region Parameter FinalPattern_Tool
        /// <summary>
        /// <para>
        /// <para>Identifier of the tool the pattern applies to (e.g. `use_aws` for AWS actions, or
        /// a third-party tool name).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FinalPattern_Tool { get; set; }
        #endregion
        
        #region Parameter TtlSecond
        /// <summary>
        /// <para>
        /// <para>Approval lifetime in seconds, starting from when the decision is submitted. Required
        /// when `action` is APPROVED AND `singleUse` is false; must be absent when `action` is
        /// REJECTED or when `singleUse` is true (a single-use approval backs one executed action
        /// and the redemption window collapses). Cross-field invariants are enforced by service-side
        /// validation; the @range bound here is the operation-boundary check that always applies
        /// (a maximum of 4 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TtlSeconds")]
        public System.Int32? TtlSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.UpdateApprovalActionResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.UpdateApprovalActionResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.AgentSpaceId),
                nameof(this.ApprovalId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DOPSApprovalAction (UpdateApprovalAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.UpdateApprovalActionResponse, UpdateDOPSApprovalActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApprovalId = this.ApprovalId;
            #if MODULAR
            if (this.ApprovalId == null && ParameterWasBound(nameof(this.ApprovalId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FinalPattern_ArgumentPin != null)
            {
                context.FinalPattern_ArgumentPin = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.FinalPattern_ArgumentPin.Keys)
                {
                    context.FinalPattern_ArgumentPin.Add((String)hashKey, (System.String)(this.FinalPattern_ArgumentPin[hashKey]));
                }
            }
            context.FinalPattern_Tool = this.FinalPattern_Tool;
            context.Reason = this.Reason;
            context.SingleUse = this.SingleUse;
            context.TtlSecond = this.TtlSecond;
            
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
            var request = new Amazon.DevOpsAgent.Model.UpdateApprovalActionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            if (cmdletContext.ApprovalId != null)
            {
                request.ApprovalId = cmdletContext.ApprovalId;
            }
            
             // populate FinalPattern
            var requestFinalPatternIsNull = true;
            request.FinalPattern = new Amazon.DevOpsAgent.Model.ApprovalPattern();
            Dictionary<System.String, System.String> requestFinalPattern_finalPattern_ArgumentPin = null;
            if (cmdletContext.FinalPattern_ArgumentPin != null)
            {
                requestFinalPattern_finalPattern_ArgumentPin = cmdletContext.FinalPattern_ArgumentPin;
            }
            if (requestFinalPattern_finalPattern_ArgumentPin != null)
            {
                request.FinalPattern.ArgumentPins = requestFinalPattern_finalPattern_ArgumentPin;
                requestFinalPatternIsNull = false;
            }
            System.String requestFinalPattern_finalPattern_Tool = null;
            if (cmdletContext.FinalPattern_Tool != null)
            {
                requestFinalPattern_finalPattern_Tool = cmdletContext.FinalPattern_Tool;
            }
            if (requestFinalPattern_finalPattern_Tool != null)
            {
                request.FinalPattern.Tool = requestFinalPattern_finalPattern_Tool;
                requestFinalPatternIsNull = false;
            }
             // determine if request.FinalPattern should be set to null
            if (requestFinalPatternIsNull)
            {
                request.FinalPattern = null;
            }
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
            }
            if (cmdletContext.SingleUse != null)
            {
                request.SingleUse = cmdletContext.SingleUse.Value;
            }
            if (cmdletContext.TtlSecond != null)
            {
                request.TtlSeconds = cmdletContext.TtlSecond.Value;
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
        
        private Amazon.DevOpsAgent.Model.UpdateApprovalActionResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.UpdateApprovalActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "UpdateApprovalAction");
            try
            {
                return client.UpdateApprovalActionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.DevOpsAgent.ApprovalActionType Action { get; set; }
            public System.String AgentSpaceId { get; set; }
            public System.String ApprovalId { get; set; }
            public Dictionary<System.String, System.String> FinalPattern_ArgumentPin { get; set; }
            public System.String FinalPattern_Tool { get; set; }
            public System.String Reason { get; set; }
            public System.Boolean? SingleUse { get; set; }
            public System.Int32? TtlSecond { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.UpdateApprovalActionResponse, UpdateDOPSApprovalActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
