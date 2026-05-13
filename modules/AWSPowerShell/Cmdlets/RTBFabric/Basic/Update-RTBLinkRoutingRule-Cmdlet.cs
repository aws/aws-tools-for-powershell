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
using Amazon.RTBFabric;
using Amazon.RTBFabric.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RTB
{
    /// <summary>
    /// Updates a routing rule for a link.
    /// </summary>
    [Cmdlet("Update", "RTBLinkRoutingRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RTBFabric.Model.UpdateLinkRoutingRuleResponse")]
    [AWSCmdlet("Calls the Amazon RTBFabric UpdateLinkRoutingRule API operation.", Operation = new[] {"UpdateLinkRoutingRule"}, SelectReturnType = typeof(Amazon.RTBFabric.Model.UpdateLinkRoutingRuleResponse))]
    [AWSCmdletOutput("Amazon.RTBFabric.Model.UpdateLinkRoutingRuleResponse",
        "This cmdlet returns an Amazon.RTBFabric.Model.UpdateLinkRoutingRuleResponse object containing multiple properties."
    )]
    public partial class UpdateRTBLinkRoutingRuleCmdlet : AmazonRTBFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the gateway.</para>
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
        public System.String GatewayId { get; set; }
        #endregion
        
        #region Parameter Conditions_HostHeader
        /// <summary>
        /// <para>
        /// <para>Exact host match — RFC 3986 unreserved characters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Conditions_HostHeader { get; set; }
        #endregion
        
        #region Parameter Conditions_HostHeaderWildcard
        /// <summary>
        /// <para>
        /// <para>Wildcard host pattern (e.g., *.example.com) — RFC 3986 unreserved plus *</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Conditions_HostHeaderWildcard { get; set; }
        #endregion
        
        #region Parameter Conditions_QueryStringEquals_Key
        /// <summary>
        /// <para>
        /// <para>RFC 3986 unreserved characters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Conditions_QueryStringEquals_Key { get; set; }
        #endregion
        
        #region Parameter LinkId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the link.</para>
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
        public System.String LinkId { get; set; }
        #endregion
        
        #region Parameter Conditions_PathExact
        /// <summary>
        /// <para>
        /// <para>Exact path match — must start with /; RFC 3986 unreserved plus /</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Conditions_PathExact { get; set; }
        #endregion
        
        #region Parameter Conditions_PathPrefix
        /// <summary>
        /// <para>
        /// <para>Path prefix matching — strict starts-with, no wildcard (preferred for new rules).
        /// Must start with /; RFC 3986 unreserved plus /</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Conditions_PathPrefix { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The updated priority of the routing rule. Lower numbers are evaluated first. Valid
        /// values are 1 to 1000. Priority must be unique among non-deleted rules within a link.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter Conditions_QueryStringExist
        /// <summary>
        /// <para>
        /// <para>Query string key presence check (any value accepted) — RFC 3986 unreserved characters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Conditions_QueryStringExists")]
        public System.String Conditions_QueryStringExist { get; set; }
        #endregion
        
        #region Parameter RuleId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the routing rule.</para>
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
        public System.String RuleId { get; set; }
        #endregion
        
        #region Parameter Conditions_QueryStringEquals_Value
        /// <summary>
        /// <para>
        /// <para>RFC 3986 unreserved characters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Conditions_QueryStringEquals_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RTBFabric.Model.UpdateLinkRoutingRuleResponse).
        /// Specifying the name of a property of type Amazon.RTBFabric.Model.UpdateLinkRoutingRuleResponse will result in that property being returned.
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
                nameof(this.GatewayId),
                nameof(this.LinkId),
                nameof(this.RuleId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RTBLinkRoutingRule (UpdateLinkRoutingRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RTBFabric.Model.UpdateLinkRoutingRuleResponse, UpdateRTBLinkRoutingRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Conditions_HostHeader = this.Conditions_HostHeader;
            context.Conditions_HostHeaderWildcard = this.Conditions_HostHeaderWildcard;
            context.Conditions_PathExact = this.Conditions_PathExact;
            context.Conditions_PathPrefix = this.Conditions_PathPrefix;
            context.Conditions_QueryStringEquals_Key = this.Conditions_QueryStringEquals_Key;
            context.Conditions_QueryStringEquals_Value = this.Conditions_QueryStringEquals_Value;
            context.Conditions_QueryStringExist = this.Conditions_QueryStringExist;
            context.GatewayId = this.GatewayId;
            #if MODULAR
            if (this.GatewayId == null && ParameterWasBound(nameof(this.GatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LinkId = this.LinkId;
            #if MODULAR
            if (this.LinkId == null && ParameterWasBound(nameof(this.LinkId)))
            {
                WriteWarning("You are passing $null as a value for parameter LinkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Priority = this.Priority;
            #if MODULAR
            if (this.Priority == null && ParameterWasBound(nameof(this.Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleId = this.RuleId;
            #if MODULAR
            if (this.RuleId == null && ParameterWasBound(nameof(this.RuleId)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RTBFabric.Model.UpdateLinkRoutingRuleRequest();
            
            
             // populate Conditions
            var requestConditionsIsNull = true;
            request.Conditions = new Amazon.RTBFabric.Model.RuleCondition();
            System.String requestConditions_conditions_HostHeader = null;
            if (cmdletContext.Conditions_HostHeader != null)
            {
                requestConditions_conditions_HostHeader = cmdletContext.Conditions_HostHeader;
            }
            if (requestConditions_conditions_HostHeader != null)
            {
                request.Conditions.HostHeader = requestConditions_conditions_HostHeader;
                requestConditionsIsNull = false;
            }
            System.String requestConditions_conditions_HostHeaderWildcard = null;
            if (cmdletContext.Conditions_HostHeaderWildcard != null)
            {
                requestConditions_conditions_HostHeaderWildcard = cmdletContext.Conditions_HostHeaderWildcard;
            }
            if (requestConditions_conditions_HostHeaderWildcard != null)
            {
                request.Conditions.HostHeaderWildcard = requestConditions_conditions_HostHeaderWildcard;
                requestConditionsIsNull = false;
            }
            System.String requestConditions_conditions_PathExact = null;
            if (cmdletContext.Conditions_PathExact != null)
            {
                requestConditions_conditions_PathExact = cmdletContext.Conditions_PathExact;
            }
            if (requestConditions_conditions_PathExact != null)
            {
                request.Conditions.PathExact = requestConditions_conditions_PathExact;
                requestConditionsIsNull = false;
            }
            System.String requestConditions_conditions_PathPrefix = null;
            if (cmdletContext.Conditions_PathPrefix != null)
            {
                requestConditions_conditions_PathPrefix = cmdletContext.Conditions_PathPrefix;
            }
            if (requestConditions_conditions_PathPrefix != null)
            {
                request.Conditions.PathPrefix = requestConditions_conditions_PathPrefix;
                requestConditionsIsNull = false;
            }
            System.String requestConditions_conditions_QueryStringExist = null;
            if (cmdletContext.Conditions_QueryStringExist != null)
            {
                requestConditions_conditions_QueryStringExist = cmdletContext.Conditions_QueryStringExist;
            }
            if (requestConditions_conditions_QueryStringExist != null)
            {
                request.Conditions.QueryStringExists = requestConditions_conditions_QueryStringExist;
                requestConditionsIsNull = false;
            }
            Amazon.RTBFabric.Model.QueryStringKeyValuePair requestConditions_conditions_QueryStringEquals = null;
            
             // populate QueryStringEquals
            var requestConditions_conditions_QueryStringEqualsIsNull = true;
            requestConditions_conditions_QueryStringEquals = new Amazon.RTBFabric.Model.QueryStringKeyValuePair();
            System.String requestConditions_conditions_QueryStringEquals_conditions_QueryStringEquals_Key = null;
            if (cmdletContext.Conditions_QueryStringEquals_Key != null)
            {
                requestConditions_conditions_QueryStringEquals_conditions_QueryStringEquals_Key = cmdletContext.Conditions_QueryStringEquals_Key;
            }
            if (requestConditions_conditions_QueryStringEquals_conditions_QueryStringEquals_Key != null)
            {
                requestConditions_conditions_QueryStringEquals.Key = requestConditions_conditions_QueryStringEquals_conditions_QueryStringEquals_Key;
                requestConditions_conditions_QueryStringEqualsIsNull = false;
            }
            System.String requestConditions_conditions_QueryStringEquals_conditions_QueryStringEquals_Value = null;
            if (cmdletContext.Conditions_QueryStringEquals_Value != null)
            {
                requestConditions_conditions_QueryStringEquals_conditions_QueryStringEquals_Value = cmdletContext.Conditions_QueryStringEquals_Value;
            }
            if (requestConditions_conditions_QueryStringEquals_conditions_QueryStringEquals_Value != null)
            {
                requestConditions_conditions_QueryStringEquals.Value = requestConditions_conditions_QueryStringEquals_conditions_QueryStringEquals_Value;
                requestConditions_conditions_QueryStringEqualsIsNull = false;
            }
             // determine if requestConditions_conditions_QueryStringEquals should be set to null
            if (requestConditions_conditions_QueryStringEqualsIsNull)
            {
                requestConditions_conditions_QueryStringEquals = null;
            }
            if (requestConditions_conditions_QueryStringEquals != null)
            {
                request.Conditions.QueryStringEquals = requestConditions_conditions_QueryStringEquals;
                requestConditionsIsNull = false;
            }
             // determine if request.Conditions should be set to null
            if (requestConditionsIsNull)
            {
                request.Conditions = null;
            }
            if (cmdletContext.GatewayId != null)
            {
                request.GatewayId = cmdletContext.GatewayId;
            }
            if (cmdletContext.LinkId != null)
            {
                request.LinkId = cmdletContext.LinkId;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.RuleId != null)
            {
                request.RuleId = cmdletContext.RuleId;
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
        
        private Amazon.RTBFabric.Model.UpdateLinkRoutingRuleResponse CallAWSServiceOperation(IAmazonRTBFabric client, Amazon.RTBFabric.Model.UpdateLinkRoutingRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon RTBFabric", "UpdateLinkRoutingRule");
            try
            {
                return client.UpdateLinkRoutingRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Conditions_HostHeader { get; set; }
            public System.String Conditions_HostHeaderWildcard { get; set; }
            public System.String Conditions_PathExact { get; set; }
            public System.String Conditions_PathPrefix { get; set; }
            public System.String Conditions_QueryStringEquals_Key { get; set; }
            public System.String Conditions_QueryStringEquals_Value { get; set; }
            public System.String Conditions_QueryStringExist { get; set; }
            public System.String GatewayId { get; set; }
            public System.String LinkId { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String RuleId { get; set; }
            public System.Func<Amazon.RTBFabric.Model.UpdateLinkRoutingRuleResponse, UpdateRTBLinkRoutingRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
