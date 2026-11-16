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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Associates a transit gateway with a context store. The transit gateway must be registered
    /// with the global network of the context store, and can't be associated with more than
    /// one context store. The context store must be in the <c>AVAILABLE</c> state.
    /// 
    ///  
    /// <para>
    /// The association is in the <c>ASSOCIATING</c> state when it's created, and changes
    /// to <c>ASSOCIATED</c> when it's complete.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "NMGRContextStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.ContextStoreAssociation")]
    [AWSCmdlet("Calls the AWS Network Manager AssociateContextStore API operation.", Operation = new[] {"AssociateContextStore"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.AssociateContextStoreResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.ContextStoreAssociation or Amazon.NetworkManager.Model.AssociateContextStoreResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.ContextStoreAssociation object.",
        "The service call response (type Amazon.NetworkManager.Model.AssociateContextStoreResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddNMGRContextStoreCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContextStoreId
        /// <summary>
        /// <para>
        /// <para>The ID of the context store.</para>
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
        public System.String ContextStoreId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the transit gateway to associate with the context
        /// store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContextStoreAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.AssociateContextStoreResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.AssociateContextStoreResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContextStoreAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContextStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-NMGRContextStore (AssociateContextStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.AssociateContextStoreResponse, AddNMGRContextStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContextStoreId = this.ContextStoreId;
            #if MODULAR
            if (this.ContextStoreId == null && ParameterWasBound(nameof(this.ContextStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContextStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransitGatewayArn = this.TransitGatewayArn;
            
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
            var request = new Amazon.NetworkManager.Model.AssociateContextStoreRequest();
            
            if (cmdletContext.ContextStoreId != null)
            {
                request.ContextStoreId = cmdletContext.ContextStoreId;
            }
            if (cmdletContext.TransitGatewayArn != null)
            {
                request.TransitGatewayArn = cmdletContext.TransitGatewayArn;
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
        
        private Amazon.NetworkManager.Model.AssociateContextStoreResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.AssociateContextStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "AssociateContextStore");
            try
            {
                return client.AssociateContextStoreAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContextStoreId { get; set; }
            public System.String TransitGatewayArn { get; set; }
            public System.Func<Amazon.NetworkManager.Model.AssociateContextStoreResponse, AddNMGRContextStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContextStoreAssociation;
        }
        
    }
}
