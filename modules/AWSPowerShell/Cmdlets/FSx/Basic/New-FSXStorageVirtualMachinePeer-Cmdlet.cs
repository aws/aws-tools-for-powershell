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
    /// Creates a storage virtual machine (SVM) peer relationship between an SVM on an Amazon
    /// FSx for NetApp ONTAP file system and another SVM.
    /// 
    ///  
    /// <para>
    /// The <c>CreateStorageVirtualMachinePeer</c> operation returns while the SVM peer's
    /// lifecycle state is still <c>CREATING</c>. You can check the SVM peer creation status
    /// by calling the DescribeStorageVirtualMachinePeers operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "FSXStorageVirtualMachinePeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.StorageVirtualMachinePeer")]
    [AWSCmdlet("Calls the Amazon FSx CreateStorageVirtualMachinePeer API operation.", Operation = new[] {"CreateStorageVirtualMachinePeer"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateStorageVirtualMachinePeerResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.StorageVirtualMachinePeer or Amazon.FSx.Model.CreateStorageVirtualMachinePeerResponse",
        "This cmdlet returns an Amazon.FSx.Model.StorageVirtualMachinePeer object.",
        "The service call response (type Amazon.FSx.Model.CreateStorageVirtualMachinePeerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFSXStorageVirtualMachinePeerCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>Specifies the applications that the SVM peer relationship authorizes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter PeerClusterName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the peer cluster that the peer SVM is on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PeerClusterName { get; set; }
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
        
        #region Parameter PeerSvmName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the SVM to peer with.</para>
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
        public System.String PeerSvmName { get; set; }
        #endregion
        
        #region Parameter StorageVirtualMachineId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the SVM on which to create the SVM peer relationship.</para>
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
        public System.String StorageVirtualMachineId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StorageVirtualMachinePeer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateStorageVirtualMachinePeerResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateStorageVirtualMachinePeerResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.StorageVirtualMachineId),
                nameof(this.PeerSvmName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXStorageVirtualMachinePeer (CreateStorageVirtualMachinePeer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateStorageVirtualMachinePeerResponse, NewFSXStorageVirtualMachinePeerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Application != null)
            {
                context.Application = new List<System.String>(this.Application);
            }
            #if MODULAR
            if (this.Application == null && ParameterWasBound(nameof(this.Application)))
            {
                WriteWarning("You are passing $null as a value for parameter Application which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.PeerClusterName = this.PeerClusterName;
            context.PeerSvmAlias = this.PeerSvmAlias;
            context.PeerSvmName = this.PeerSvmName;
            #if MODULAR
            if (this.PeerSvmName == null && ParameterWasBound(nameof(this.PeerSvmName)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerSvmName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageVirtualMachineId = this.StorageVirtualMachineId;
            #if MODULAR
            if (this.StorageVirtualMachineId == null && ParameterWasBound(nameof(this.StorageVirtualMachineId)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageVirtualMachineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FSx.Model.Tag>(this.Tag);
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
            var request = new Amazon.FSx.Model.CreateStorageVirtualMachinePeerRequest();
            
            if (cmdletContext.Application != null)
            {
                request.Applications = cmdletContext.Application;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.PeerClusterName != null)
            {
                request.PeerClusterName = cmdletContext.PeerClusterName;
            }
            if (cmdletContext.PeerSvmAlias != null)
            {
                request.PeerSvmAlias = cmdletContext.PeerSvmAlias;
            }
            if (cmdletContext.PeerSvmName != null)
            {
                request.PeerSvmName = cmdletContext.PeerSvmName;
            }
            if (cmdletContext.StorageVirtualMachineId != null)
            {
                request.StorageVirtualMachineId = cmdletContext.StorageVirtualMachineId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.FSx.Model.CreateStorageVirtualMachinePeerResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateStorageVirtualMachinePeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateStorageVirtualMachinePeer");
            try
            {
                return client.CreateStorageVirtualMachinePeerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PeerClusterName { get; set; }
            public System.String PeerSvmAlias { get; set; }
            public System.String PeerSvmName { get; set; }
            public System.String StorageVirtualMachineId { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.FSx.Model.CreateStorageVirtualMachinePeerResponse, NewFSXStorageVirtualMachinePeerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StorageVirtualMachinePeer;
        }
        
    }
}
