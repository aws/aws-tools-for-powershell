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
using Amazon.FSx;
using Amazon.FSx.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Updates an Amazon FSx for NetApp ONTAP storage virtual machine (SVM) peer relationship.
    /// </summary>
    [Cmdlet("Update", "FSXStorageVirtualMachinePeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.StorageVirtualMachinePeer")]
    [AWSCmdlet("Calls the Amazon FSx UpdateStorageVirtualMachinePeer API operation.", Operation = new[] {"UpdateStorageVirtualMachinePeer"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateStorageVirtualMachinePeerResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.StorageVirtualMachinePeer or Amazon.FSx.Model.UpdateStorageVirtualMachinePeerResponse",
        "This cmdlet returns an Amazon.FSx.Model.StorageVirtualMachinePeer object.",
        "The service call response (type Amazon.FSx.Model.UpdateStorageVirtualMachinePeerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateFSXStorageVirtualMachinePeerCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>Specifies the applications that the SVM peer relationship authorizes. The applications
        /// that you specify replace the existing applications.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Applications")]
        public System.String[] Application { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter PeerSvmAlias
        /// <summary>
        /// <para>
        /// <para>Specifies the name that the local cluster uses to identify the peer SVM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PeerSvmAlias { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>Specifies the state to set for the SVM peer relationship:</para><ul><li><para><c>PEERED</c> – Accepts a pending peering request, or resumes a suspended SVM peer
        /// relationship.</para></li><li><para><c>SUSPENDED</c> – Suspends the SVM peer relationship.</para></li><li><para><c>REJECTED</c> – Rejects a pending peering request.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.StorageVirtualMachinePeerUpdateState")]
        public Amazon.FSx.StorageVirtualMachinePeerUpdateState State { get; set; }
        #endregion
        
        #region Parameter StorageVirtualMachinePeerId
        /// <summary>
        /// <para>
        /// <para>The ID of the SVM peer that you want to update.</para>
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
        public System.String StorageVirtualMachinePeerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StorageVirtualMachinePeer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.UpdateStorageVirtualMachinePeerResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.UpdateStorageVirtualMachinePeerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StorageVirtualMachinePeer";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StorageVirtualMachinePeerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FSXStorageVirtualMachinePeer (UpdateStorageVirtualMachinePeer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateStorageVirtualMachinePeerResponse, UpdateFSXStorageVirtualMachinePeerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Application != null)
            {
                context.Application = new List<System.String>(this.Application);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.PeerSvmAlias = this.PeerSvmAlias;
            context.State = this.State;
            context.StorageVirtualMachinePeerId = this.StorageVirtualMachinePeerId;
            #if MODULAR
            if (this.StorageVirtualMachinePeerId == null && ParameterWasBound(nameof(this.StorageVirtualMachinePeerId)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageVirtualMachinePeerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FSx.Model.UpdateStorageVirtualMachinePeerRequest();
            
            if (cmdletContext.Application != null)
            {
                request.Applications = cmdletContext.Application;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.PeerSvmAlias != null)
            {
                request.PeerSvmAlias = cmdletContext.PeerSvmAlias;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.StorageVirtualMachinePeerId != null)
            {
                request.StorageVirtualMachinePeerId = cmdletContext.StorageVirtualMachinePeerId;
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
        
        private Amazon.FSx.Model.UpdateStorageVirtualMachinePeerResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.UpdateStorageVirtualMachinePeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "UpdateStorageVirtualMachinePeer");
            try
            {
                return client.UpdateStorageVirtualMachinePeerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Application { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String PeerSvmAlias { get; set; }
            public Amazon.FSx.StorageVirtualMachinePeerUpdateState State { get; set; }
            public System.String StorageVirtualMachinePeerId { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateStorageVirtualMachinePeerResponse, UpdateFSXStorageVirtualMachinePeerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StorageVirtualMachinePeer;
        }
        
    }
}
