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
    /// Deletes a link between gateways.
    /// 
    ///  
    /// <para>
    /// Permanently removes the connection between gateways. This action cannot be undone.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "RTBLink", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.RTBFabric.Model.DeleteLinkResponse")]
    [AWSCmdlet("Calls the Amazon RTBFabric DeleteLink API operation.", Operation = new[] {"DeleteLink"}, SelectReturnType = typeof(Amazon.RTBFabric.Model.DeleteLinkResponse))]
    [AWSCmdletOutput("Amazon.RTBFabric.Model.DeleteLinkResponse",
        "This cmdlet returns an Amazon.RTBFabric.Model.DeleteLinkResponse object containing multiple properties."
    )]
    public partial class RemoveRTBLinkCmdlet : AmazonRTBFabricClientCmdlet, IExecutor
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RTBFabric.Model.DeleteLinkResponse).
        /// Specifying the name of a property of type Amazon.RTBFabric.Model.DeleteLinkResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LinkId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RTBLink (DeleteLink)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RTBFabric.Model.DeleteLinkResponse, RemoveRTBLinkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.RTBFabric.Model.DeleteLinkRequest();
            
            if (cmdletContext.GatewayId != null)
            {
                request.GatewayId = cmdletContext.GatewayId;
            }
            if (cmdletContext.LinkId != null)
            {
                request.LinkId = cmdletContext.LinkId;
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
        
        private Amazon.RTBFabric.Model.DeleteLinkResponse CallAWSServiceOperation(IAmazonRTBFabric client, Amazon.RTBFabric.Model.DeleteLinkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon RTBFabric", "DeleteLink");
            try
            {
                return client.DeleteLinkAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GatewayId { get; set; }
            public System.String LinkId { get; set; }
            public System.Func<Amazon.RTBFabric.Model.DeleteLinkResponse, RemoveRTBLinkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
