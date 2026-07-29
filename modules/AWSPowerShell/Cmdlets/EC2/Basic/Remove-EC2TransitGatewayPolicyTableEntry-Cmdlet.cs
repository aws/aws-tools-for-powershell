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
    /// Deletes the specified transit gateway policy table entry.
    /// </summary>
    [Cmdlet("Remove", "EC2TransitGatewayPolicyTableEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.TransitGatewayPolicyTableEntry")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DeleteTransitGatewayPolicyTableEntry API operation.", Operation = new[] {"DeleteTransitGatewayPolicyTableEntry"}, SelectReturnType = typeof(Amazon.EC2.Model.DeleteTransitGatewayPolicyTableEntryResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayPolicyTableEntry or Amazon.EC2.Model.DeleteTransitGatewayPolicyTableEntryResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayPolicyTableEntry object.",
        "The service call response (type Amazon.EC2.Model.DeleteTransitGatewayPolicyTableEntryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveEC2TransitGatewayPolicyTableEntryCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter PolicyRuleNumber
        /// <summary>
        /// <para>
        /// <para>The rule number of the policy table entry to delete.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DeleteTransitGatewayPolicyTableEntryResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DeleteTransitGatewayPolicyTableEntryResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2TransitGatewayPolicyTableEntry (DeleteTransitGatewayPolicyTableEntry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DeleteTransitGatewayPolicyTableEntryResponse, RemoveEC2TransitGatewayPolicyTableEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.PolicyRuleNumber = this.PolicyRuleNumber;
            #if MODULAR
            if (this.PolicyRuleNumber == null && ParameterWasBound(nameof(this.PolicyRuleNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyRuleNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.DeleteTransitGatewayPolicyTableEntryRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.PolicyRuleNumber != null)
            {
                request.PolicyRuleNumber = cmdletContext.PolicyRuleNumber;
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
        
        private Amazon.EC2.Model.DeleteTransitGatewayPolicyTableEntryResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DeleteTransitGatewayPolicyTableEntryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DeleteTransitGatewayPolicyTableEntry");
            try
            {
                return client.DeleteTransitGatewayPolicyTableEntryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PolicyRuleNumber { get; set; }
            public System.String TransitGatewayPolicyTableId { get; set; }
            public System.Func<Amazon.EC2.Model.DeleteTransitGatewayPolicyTableEntryResponse, RemoveEC2TransitGatewayPolicyTableEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayPolicyTableEntry;
        }
        
    }
}
