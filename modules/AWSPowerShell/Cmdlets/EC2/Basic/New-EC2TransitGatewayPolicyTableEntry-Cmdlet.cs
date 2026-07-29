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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates an entry in a transit gateway policy table to route matching traffic to a
    /// specified route table.
    /// </summary>
    [Cmdlet("New", "EC2TransitGatewayPolicyTableEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayPolicyTableEntry")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateTransitGatewayPolicyTableEntry API operation.", Operation = new[] {"CreateTransitGatewayPolicyTableEntry"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateTransitGatewayPolicyTableEntryResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayPolicyTableEntry or Amazon.EC2.Model.CreateTransitGatewayPolicyTableEntryResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayPolicyTableEntry object.",
        "The service call response (type Amazon.EC2.Model.CreateTransitGatewayPolicyTableEntryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2TransitGatewayPolicyTableEntryCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PolicyRule_DestinationCidrBlock
        /// <summary>
        /// <para>
        /// <para>The destination CIDR block for the policy rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyRule_DestinationCidrBlock { get; set; }
        #endregion
        
        #region Parameter PolicyRule_DestinationPortRange
        /// <summary>
        /// <para>
        /// <para>The destination port or port range for the policy rule. You can specify a port range
        /// only when <c>Protocol</c> is <c>6</c> (TCP) or <c>17</c> (UDP); for all other protocols,
        /// this value must be <c>*</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyRule_DestinationPortRange { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter PolicyRule_MetaData_MetaDataKey
        /// <summary>
        /// <para>
        /// <para>The key of the metadata pair for the policy rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyRule_MetaData_MetaDataKey { get; set; }
        #endregion
        
        #region Parameter PolicyRule_MetaData_MetaDataValue
        /// <summary>
        /// <para>
        /// <para>The value of the metadata pair for the policy rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyRule_MetaData_MetaDataValue { get; set; }
        #endregion
        
        #region Parameter PolicyRuleNumber
        /// <summary>
        /// <para>
        /// <para>The rule number for the policy table entry. Lower rule numbers are evaluated first
        /// and take precedence.</para>
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
        public System.String PolicyRuleNumber { get; set; }
        #endregion
        
        #region Parameter PolicyRule_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol for the policy rule. Valid values are <c>1</c> (ICMP), <c>6</c> (TCP),
        /// <c>17</c> (UDP), <c>47</c> (GRE), or <c>*</c> for all protocols.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyRule_Protocol { get; set; }
        #endregion
        
        #region Parameter PolicyRule_SourceCidrBlock
        /// <summary>
        /// <para>
        /// <para>The source CIDR block for the policy rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyRule_SourceCidrBlock { get; set; }
        #endregion
        
        #region Parameter PolicyRule_SourcePortRange
        /// <summary>
        /// <para>
        /// <para>The source port or port range for the policy rule. You can specify a port range only
        /// when <c>Protocol</c> is <c>6</c> (TCP) or <c>17</c> (UDP); for all other protocols,
        /// this value must be <c>*</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyRule_SourcePortRange { get; set; }
        #endregion
        
        #region Parameter TargetRouteTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway route table to use for traffic matching this rule.</para>
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
        public System.String TargetRouteTableId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayPolicyTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway policy table.</para>
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
        public System.String TransitGatewayPolicyTableId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayPolicyTableEntry'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateTransitGatewayPolicyTableEntryResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateTransitGatewayPolicyTableEntryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayPolicyTableEntry";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2TransitGatewayPolicyTableEntry (CreateTransitGatewayPolicyTableEntry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateTransitGatewayPolicyTableEntryResponse, NewEC2TransitGatewayPolicyTableEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.PolicyRule_DestinationCidrBlock = this.PolicyRule_DestinationCidrBlock;
            context.PolicyRule_DestinationPortRange = this.PolicyRule_DestinationPortRange;
            context.PolicyRule_MetaData_MetaDataKey = this.PolicyRule_MetaData_MetaDataKey;
            context.PolicyRule_MetaData_MetaDataValue = this.PolicyRule_MetaData_MetaDataValue;
            context.PolicyRule_Protocol = this.PolicyRule_Protocol;
            context.PolicyRule_SourceCidrBlock = this.PolicyRule_SourceCidrBlock;
            context.PolicyRule_SourcePortRange = this.PolicyRule_SourcePortRange;
            context.PolicyRuleNumber = this.PolicyRuleNumber;
            #if MODULAR
            if (this.PolicyRuleNumber == null && ParameterWasBound(nameof(this.PolicyRuleNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyRuleNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetRouteTableId = this.TargetRouteTableId;
            #if MODULAR
            if (this.TargetRouteTableId == null && ParameterWasBound(nameof(this.TargetRouteTableId)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetRouteTableId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransitGatewayPolicyTableId = this.TransitGatewayPolicyTableId;
            #if MODULAR
            if (this.TransitGatewayPolicyTableId == null && ParameterWasBound(nameof(this.TransitGatewayPolicyTableId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayPolicyTableId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateTransitGatewayPolicyTableEntryRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate PolicyRule
            var requestPolicyRuleIsNull = true;
            request.PolicyRule = new Amazon.EC2.Model.TransitGatewayRequestPolicyRule();
            System.String requestPolicyRule_policyRule_DestinationCidrBlock = null;
            if (cmdletContext.PolicyRule_DestinationCidrBlock != null)
            {
                requestPolicyRule_policyRule_DestinationCidrBlock = cmdletContext.PolicyRule_DestinationCidrBlock;
            }
            if (requestPolicyRule_policyRule_DestinationCidrBlock != null)
            {
                request.PolicyRule.DestinationCidrBlock = requestPolicyRule_policyRule_DestinationCidrBlock;
                requestPolicyRuleIsNull = false;
            }
            System.String requestPolicyRule_policyRule_DestinationPortRange = null;
            if (cmdletContext.PolicyRule_DestinationPortRange != null)
            {
                requestPolicyRule_policyRule_DestinationPortRange = cmdletContext.PolicyRule_DestinationPortRange;
            }
            if (requestPolicyRule_policyRule_DestinationPortRange != null)
            {
                request.PolicyRule.DestinationPortRange = requestPolicyRule_policyRule_DestinationPortRange;
                requestPolicyRuleIsNull = false;
            }
            System.String requestPolicyRule_policyRule_Protocol = null;
            if (cmdletContext.PolicyRule_Protocol != null)
            {
                requestPolicyRule_policyRule_Protocol = cmdletContext.PolicyRule_Protocol;
            }
            if (requestPolicyRule_policyRule_Protocol != null)
            {
                request.PolicyRule.Protocol = requestPolicyRule_policyRule_Protocol;
                requestPolicyRuleIsNull = false;
            }
            System.String requestPolicyRule_policyRule_SourceCidrBlock = null;
            if (cmdletContext.PolicyRule_SourceCidrBlock != null)
            {
                requestPolicyRule_policyRule_SourceCidrBlock = cmdletContext.PolicyRule_SourceCidrBlock;
            }
            if (requestPolicyRule_policyRule_SourceCidrBlock != null)
            {
                request.PolicyRule.SourceCidrBlock = requestPolicyRule_policyRule_SourceCidrBlock;
                requestPolicyRuleIsNull = false;
            }
            System.String requestPolicyRule_policyRule_SourcePortRange = null;
            if (cmdletContext.PolicyRule_SourcePortRange != null)
            {
                requestPolicyRule_policyRule_SourcePortRange = cmdletContext.PolicyRule_SourcePortRange;
            }
            if (requestPolicyRule_policyRule_SourcePortRange != null)
            {
                request.PolicyRule.SourcePortRange = requestPolicyRule_policyRule_SourcePortRange;
                requestPolicyRuleIsNull = false;
            }
            Amazon.EC2.Model.TransitGatewayRequestPolicyRuleMetaData requestPolicyRule_policyRule_MetaData = null;
            
             // populate MetaData
            var requestPolicyRule_policyRule_MetaDataIsNull = true;
            requestPolicyRule_policyRule_MetaData = new Amazon.EC2.Model.TransitGatewayRequestPolicyRuleMetaData();
            System.String requestPolicyRule_policyRule_MetaData_policyRule_MetaData_MetaDataKey = null;
            if (cmdletContext.PolicyRule_MetaData_MetaDataKey != null)
            {
                requestPolicyRule_policyRule_MetaData_policyRule_MetaData_MetaDataKey = cmdletContext.PolicyRule_MetaData_MetaDataKey;
            }
            if (requestPolicyRule_policyRule_MetaData_policyRule_MetaData_MetaDataKey != null)
            {
                requestPolicyRule_policyRule_MetaData.MetaDataKey = requestPolicyRule_policyRule_MetaData_policyRule_MetaData_MetaDataKey;
                requestPolicyRule_policyRule_MetaDataIsNull = false;
            }
            System.String requestPolicyRule_policyRule_MetaData_policyRule_MetaData_MetaDataValue = null;
            if (cmdletContext.PolicyRule_MetaData_MetaDataValue != null)
            {
                requestPolicyRule_policyRule_MetaData_policyRule_MetaData_MetaDataValue = cmdletContext.PolicyRule_MetaData_MetaDataValue;
            }
            if (requestPolicyRule_policyRule_MetaData_policyRule_MetaData_MetaDataValue != null)
            {
                requestPolicyRule_policyRule_MetaData.MetaDataValue = requestPolicyRule_policyRule_MetaData_policyRule_MetaData_MetaDataValue;
                requestPolicyRule_policyRule_MetaDataIsNull = false;
            }
             // determine if requestPolicyRule_policyRule_MetaData should be set to null
            if (requestPolicyRule_policyRule_MetaDataIsNull)
            {
                requestPolicyRule_policyRule_MetaData = null;
            }
            if (requestPolicyRule_policyRule_MetaData != null)
            {
                request.PolicyRule.MetaData = requestPolicyRule_policyRule_MetaData;
                requestPolicyRuleIsNull = false;
            }
             // determine if request.PolicyRule should be set to null
            if (requestPolicyRuleIsNull)
            {
                request.PolicyRule = null;
            }
            if (cmdletContext.PolicyRuleNumber != null)
            {
                request.PolicyRuleNumber = cmdletContext.PolicyRuleNumber;
            }
            if (cmdletContext.TargetRouteTableId != null)
            {
                request.TargetRouteTableId = cmdletContext.TargetRouteTableId;
            }
            if (cmdletContext.TransitGatewayPolicyTableId != null)
            {
                request.TransitGatewayPolicyTableId = cmdletContext.TransitGatewayPolicyTableId;
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
        
        private Amazon.EC2.Model.CreateTransitGatewayPolicyTableEntryResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateTransitGatewayPolicyTableEntryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateTransitGatewayPolicyTableEntry");
            try
            {
                return client.CreateTransitGatewayPolicyTableEntryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String PolicyRule_DestinationCidrBlock { get; set; }
            public System.String PolicyRule_DestinationPortRange { get; set; }
            public System.String PolicyRule_MetaData_MetaDataKey { get; set; }
            public System.String PolicyRule_MetaData_MetaDataValue { get; set; }
            public System.String PolicyRule_Protocol { get; set; }
            public System.String PolicyRule_SourceCidrBlock { get; set; }
            public System.String PolicyRule_SourcePortRange { get; set; }
            public System.String PolicyRuleNumber { get; set; }
            public System.String TargetRouteTableId { get; set; }
            public System.String TransitGatewayPolicyTableId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateTransitGatewayPolicyTableEntryResponse, NewEC2TransitGatewayPolicyTableEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayPolicyTableEntry;
        }
        
    }
}
