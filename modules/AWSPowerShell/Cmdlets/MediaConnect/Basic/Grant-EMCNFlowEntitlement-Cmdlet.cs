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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Grants entitlements to an existing flow.
    /// </summary>
    [Cmdlet("Grant", "EMCNFlowEntitlement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Entitlement")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect GrantFlowEntitlements API operation.", Operation = new[] {"GrantFlowEntitlements"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.GrantFlowEntitlementsResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Entitlement or Amazon.MediaConnect.Model.GrantFlowEntitlementsResponse",
        "This cmdlet returns a collection of Amazon.MediaConnect.Model.Entitlement objects.",
        "The service call response (type Amazon.MediaConnect.Model.GrantFlowEntitlementsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GrantEMCNFlowEntitlementCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Entitlement
        /// <summary>
        /// <para>
        /// The list of entitlements that you want to
        /// grant.
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
        [Alias("Entitlements")]
        public Amazon.MediaConnect.Model.GrantEntitlementRequest[] Entitlement { get; set; }
        #endregion
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The flow that you want to grant entitlements on.
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
        public System.String FlowArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Entitlements'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.GrantFlowEntitlementsResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.GrantFlowEntitlementsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entitlements";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FlowArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Grant-EMCNFlowEntitlement (GrantFlowEntitlements)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.GrantFlowEntitlementsResponse, GrantEMCNFlowEntitlementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Entitlement != null)
            {
                context.Entitlement = new List<Amazon.MediaConnect.Model.GrantEntitlementRequest>(this.Entitlement);
            }
            #if MODULAR
            if (this.Entitlement == null && ParameterWasBound(nameof(this.Entitlement)))
            {
                WriteWarning("You are passing $null as a value for parameter Entitlement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FlowArn = this.FlowArn;
            #if MODULAR
            if (this.FlowArn == null && ParameterWasBound(nameof(this.FlowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaConnect.Model.GrantFlowEntitlementsRequest();
            
            if (cmdletContext.Entitlement != null)
            {
                request.Entitlements = cmdletContext.Entitlement;
            }
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
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
        
        private Amazon.MediaConnect.Model.GrantFlowEntitlementsResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.GrantFlowEntitlementsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "GrantFlowEntitlements");
            try
            {
                return client.GrantFlowEntitlementsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.MediaConnect.Model.GrantEntitlementRequest> Entitlement { get; set; }
            public System.String FlowArn { get; set; }
            public System.Func<Amazon.MediaConnect.Model.GrantFlowEntitlementsResponse, GrantEMCNFlowEntitlementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entitlements;
        }
        
    }
}
