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
    /// Creates a cluster peer relationship between an Amazon FSx for NetApp ONTAP file system
    /// and another ONTAP cluster.
    /// 
    ///  
    /// <para>
    /// The <c>CreateClusterPeer</c> operation returns while the cluster peer's lifecycle
    /// state is still <c>CREATING</c>. You can check the cluster peer creation status by
    /// calling the DescribeClusterPeers operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "FSXClusterPeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.ClusterPeer")]
    [AWSCmdlet("Calls the Amazon FSx CreateClusterPeer API operation.", Operation = new[] {"CreateClusterPeer"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateClusterPeerResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.ClusterPeer or Amazon.FSx.Model.CreateClusterPeerResponse",
        "This cmdlet returns an Amazon.FSx.Model.ClusterPeer object.",
        "The service call response (type Amazon.FSx.Model.CreateClusterPeerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFSXClusterPeerCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowedSvmId
        /// <summary>
        /// <para>
        /// <para>Specifies the IDs of the SVMs on the file system that are preauthorized for SVM peering
        /// with the peer cluster. You can specify <c>AllowedSvmIds</c> only when <c>AllowedSvmMode</c>
        /// is <c>SPECIFIED</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedSvmIds")]
        public System.String[] AllowedSvmId { get; set; }
        #endregion
        
        #region Parameter AllowedSvmMode
        /// <summary>
        /// <para>
        /// <para>Specifies which SVMs on the file system are preauthorized for SVM peering with the
        /// peer cluster.</para><ul><li><para><c>ALL</c> – All SVMs on the file system are preauthorized. You can't specify <c>AllowedSvmIds</c>
        /// along with this property.</para></li><li><para><c>NONE</c> – No SVMs on the file system are preauthorized. You can't specify <c>AllowedSvmIds</c>
        /// along with this property.</para></li><li><para><c>SPECIFIED</c> – Only the SVMs in <c>AllowedSvmIds</c> are preauthorized. You must
        /// specify <c>AllowedSvmIds</c> along with this property.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FSx.AllowedSvmMode")]
        public Amazon.FSx.AllowedSvmMode AllowedSvmMode { get; set; }
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
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the Amazon FSx for NetApp ONTAP file system on which to create
        /// the cluster peer relationship.</para>
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
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter PassphraseSecretArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the Amazon Web Services Secrets Manager
        /// secret containing the cluster peering passphrase. Store the passphrase as a plaintext
        /// secret value, not as a key-value pair. The secret must be in the same Amazon Web Services
        /// Region as the file system. You must use the same passphrase when you create the cluster
        /// peer relationship on the peer cluster.</para>
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
        public System.String PassphraseSecretArn { get; set; }
        #endregion
        
        #region Parameter PeerAddress
        /// <summary>
        /// <para>
        /// <para>Specifies the IP addresses of the intercluster logical interfaces (LIFs) on the peer
        /// cluster.</para><para />
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
        [Alias("PeerAddresses")]
        public System.String[] PeerAddress { get; set; }
        #endregion
        
        #region Parameter PeerClusterName
        /// <summary>
        /// <para>
        /// <para>Specifies the name that the file system uses to identify the peer cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PeerClusterName { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ClusterPeer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateClusterPeerResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateClusterPeerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ClusterPeer";
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
                nameof(this.FileSystemId),
                nameof(this.PassphraseSecretArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXClusterPeer (CreateClusterPeer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateClusterPeerResponse, NewFSXClusterPeerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedSvmId != null)
            {
                context.AllowedSvmId = new List<System.String>(this.AllowedSvmId);
            }
            context.AllowedSvmMode = this.AllowedSvmMode;
            #if MODULAR
            if (this.AllowedSvmMode == null && ParameterWasBound(nameof(this.AllowedSvmMode)))
            {
                WriteWarning("You are passing $null as a value for parameter AllowedSvmMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PassphraseSecretArn = this.PassphraseSecretArn;
            #if MODULAR
            if (this.PassphraseSecretArn == null && ParameterWasBound(nameof(this.PassphraseSecretArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PassphraseSecretArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PeerAddress != null)
            {
                context.PeerAddress = new List<System.String>(this.PeerAddress);
            }
            #if MODULAR
            if (this.PeerAddress == null && ParameterWasBound(nameof(this.PeerAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PeerClusterName = this.PeerClusterName;
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
            var request = new Amazon.FSx.Model.CreateClusterPeerRequest();
            
            if (cmdletContext.AllowedSvmId != null)
            {
                request.AllowedSvmIds = cmdletContext.AllowedSvmId;
            }
            if (cmdletContext.AllowedSvmMode != null)
            {
                request.AllowedSvmMode = cmdletContext.AllowedSvmMode;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.PassphraseSecretArn != null)
            {
                request.PassphraseSecretArn = cmdletContext.PassphraseSecretArn;
            }
            if (cmdletContext.PeerAddress != null)
            {
                request.PeerAddresses = cmdletContext.PeerAddress;
            }
            if (cmdletContext.PeerClusterName != null)
            {
                request.PeerClusterName = cmdletContext.PeerClusterName;
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
        
        private Amazon.FSx.Model.CreateClusterPeerResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateClusterPeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateClusterPeer");
            try
            {
                return client.CreateClusterPeerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AllowedSvmId { get; set; }
            public Amazon.FSx.AllowedSvmMode AllowedSvmMode { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String FileSystemId { get; set; }
            public System.String PassphraseSecretArn { get; set; }
            public List<System.String> PeerAddress { get; set; }
            public System.String PeerClusterName { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.FSx.Model.CreateClusterPeerResponse, NewFSXClusterPeerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ClusterPeer;
        }
        
    }
}
