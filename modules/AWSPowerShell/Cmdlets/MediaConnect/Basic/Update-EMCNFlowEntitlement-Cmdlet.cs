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
    /// Updates an entitlement. You can change an entitlement's description, subscribers,
    /// and encryption. If you change the subscribers, the service will remove the outputs
    /// that are are used by the subscribers that are removed.
    /// </summary>
    [Cmdlet("Update", "EMCNFlowEntitlement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Entitlement")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateFlowEntitlement API operation.", Operation = new[] {"UpdateFlowEntitlement"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateFlowEntitlementResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Entitlement or Amazon.MediaConnect.Model.UpdateFlowEntitlementResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.Entitlement object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateFlowEntitlementResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEMCNFlowEntitlementCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A description of the entitlement. This description appears only on the MediaConnect
        /// console and will not be seen by the subscriber or end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Encryption
        /// <summary>
        /// <para>
        /// <para> The type of encryption that will be used on the output associated with this entitlement.
        /// Allowable encryption types: static-key, speke.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaConnect.Model.UpdateEncryption Encryption { get; set; }
        #endregion
        
        #region Parameter EntitlementArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the entitlement that you want to update.</para>
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
        public System.String EntitlementArn { get; set; }
        #endregion
        
        #region Parameter EntitlementStatus
        /// <summary>
        /// <para>
        /// <para> An indication of whether you want to enable the entitlement to allow access, or disable
        /// it to stop streaming content to the subscriber’s flow temporarily. If you don’t specify
        /// the <c>entitlementStatus</c> field in your request, MediaConnect leaves the value
        /// unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.EntitlementStatus")]
        public Amazon.MediaConnect.EntitlementStatus EntitlementStatus { get; set; }
        #endregion
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the flow that is associated with the entitlement that you want to update.</para>
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
        public System.String FlowArn { get; set; }
        #endregion
        
        #region Parameter Subscriber
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services account IDs that you want to share your content with. The
        /// receiving accounts (subscribers) will be allowed to create their own flow using your
        /// content as the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subscribers")]
        public System.String[] Subscriber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Entitlement'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateFlowEntitlementResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateFlowEntitlementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Entitlement";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EntitlementArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlowEntitlement (UpdateFlowEntitlement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateFlowEntitlementResponse, UpdateEMCNFlowEntitlementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Encryption = this.Encryption;
            context.EntitlementArn = this.EntitlementArn;
            #if MODULAR
            if (this.EntitlementArn == null && ParameterWasBound(nameof(this.EntitlementArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EntitlementArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntitlementStatus = this.EntitlementStatus;
            context.FlowArn = this.FlowArn;
            #if MODULAR
            if (this.FlowArn == null && ParameterWasBound(nameof(this.FlowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Subscriber != null)
            {
                context.Subscriber = new List<System.String>(this.Subscriber);
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
            var request = new Amazon.MediaConnect.Model.UpdateFlowEntitlementRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Encryption != null)
            {
                request.Encryption = cmdletContext.Encryption;
            }
            if (cmdletContext.EntitlementArn != null)
            {
                request.EntitlementArn = cmdletContext.EntitlementArn;
            }
            if (cmdletContext.EntitlementStatus != null)
            {
                request.EntitlementStatus = cmdletContext.EntitlementStatus;
            }
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            if (cmdletContext.Subscriber != null)
            {
                request.Subscribers = cmdletContext.Subscriber;
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
        
        private Amazon.MediaConnect.Model.UpdateFlowEntitlementResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateFlowEntitlementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateFlowEntitlement");
            try
            {
                return client.UpdateFlowEntitlementAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.MediaConnect.Model.UpdateEncryption Encryption { get; set; }
            public System.String EntitlementArn { get; set; }
            public Amazon.MediaConnect.EntitlementStatus EntitlementStatus { get; set; }
            public System.String FlowArn { get; set; }
            public List<System.String> Subscriber { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateFlowEntitlementResponse, UpdateEMCNFlowEntitlementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Entitlement;
        }
        
    }
}
