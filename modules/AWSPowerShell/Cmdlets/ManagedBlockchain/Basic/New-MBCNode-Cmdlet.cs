/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ManagedBlockchain;
using Amazon.ManagedBlockchain.Model;

namespace Amazon.PowerShell.Cmdlets.MBC
{
    /// <summary>
    /// Creates a node on the specified blockchain network.
    /// 
    ///  
    /// <para>
    /// Applies to Hyperledger Fabric and Ethereum.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MBCNode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain CreateNode API operation.", Operation = new[] {"CreateNode"}, SelectReturnType = typeof(Amazon.ManagedBlockchain.Model.CreateNodeResponse))]
    [AWSCmdletOutput("System.String or Amazon.ManagedBlockchain.Model.CreateNodeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ManagedBlockchain.Model.CreateNodeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMBCNodeCmdlet : AmazonManagedBlockchainClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NodeConfiguration_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which the node exists. Required for Ethereum nodes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NodeConfiguration_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the operation. An idempotent operation completes no more than one time. This identifier
        /// is required only if you make a service request directly using an HTTP client. It is
        /// generated automatically if you use an Amazon Web Services SDK or the CLI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter LogPublishingConfiguration_Fabric
        /// <summary>
        /// <para>
        /// <para>Configuration properties for logging events associated with a node that is owned by
        /// a member of a Managed Blockchain network using the Hyperledger Fabric framework.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeConfiguration_LogPublishingConfiguration_Fabric")]
        public Amazon.ManagedBlockchain.Model.NodeFabricLogPublishingConfiguration LogPublishingConfiguration_Fabric { get; set; }
        #endregion
        
        #region Parameter NodeConfiguration_InstanceType
        /// <summary>
        /// <para>
        /// <para>The Amazon Managed Blockchain instance type for the node.</para>
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
        public System.String NodeConfiguration_InstanceType { get; set; }
        #endregion
        
        #region Parameter MemberId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the member that owns this node.</para><para>Applies only to Hyperledger Fabric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MemberId { get; set; }
        #endregion
        
        #region Parameter NetworkId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the network for the node.</para><para>Ethereum public networks have the following <c>NetworkId</c>s:</para><ul><li><para><c>n-ethereum-mainnet</c></para></li><li><para><c>n-ethereum-goerli</c></para></li></ul>
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
        public System.String NetworkId { get; set; }
        #endregion
        
        #region Parameter NodeConfiguration_StateDB
        /// <summary>
        /// <para>
        /// <para>The state database that the node uses. Values are <c>LevelDB</c> or <c>CouchDB</c>.
        /// When using an Amazon Managed Blockchain network with Hyperledger Fabric version 1.4
        /// or later, the default is <c>CouchDB</c>.</para><para>Applies only to Hyperledger Fabric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ManagedBlockchain.StateDBType")]
        public Amazon.ManagedBlockchain.StateDBType NodeConfiguration_StateDB { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the node.</para><para> Each tag consists of a key and an optional value. You can specify multiple key-value
        /// pairs in a single request with an overall maximum of 50 tags allowed per resource.</para><para>For more information about tags, see <a href="https://docs.aws.amazon.com/managed-blockchain/latest/ethereum-dev/tagging-resources.html">Tagging
        /// Resources</a> in the <i>Amazon Managed Blockchain Ethereum Developer Guide</i>, or
        /// <a href="https://docs.aws.amazon.com/managed-blockchain/latest/hyperledger-fabric-dev/tagging-resources.html">Tagging
        /// Resources</a> in the <i>Amazon Managed Blockchain Hyperledger Fabric Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NodeId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchain.Model.CreateNodeResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchain.Model.CreateNodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NodeId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MBCNode (CreateNode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchain.Model.CreateNodeResponse, NewMBCNodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.MemberId = this.MemberId;
            context.NetworkId = this.NetworkId;
            #if MODULAR
            if (this.NetworkId == null && ParameterWasBound(nameof(this.NetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NodeConfiguration_AvailabilityZone = this.NodeConfiguration_AvailabilityZone;
            context.NodeConfiguration_InstanceType = this.NodeConfiguration_InstanceType;
            #if MODULAR
            if (this.NodeConfiguration_InstanceType == null && ParameterWasBound(nameof(this.NodeConfiguration_InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeConfiguration_InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogPublishingConfiguration_Fabric = this.LogPublishingConfiguration_Fabric;
            context.NodeConfiguration_StateDB = this.NodeConfiguration_StateDB;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.ManagedBlockchain.Model.CreateNodeRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.MemberId != null)
            {
                request.MemberId = cmdletContext.MemberId;
            }
            if (cmdletContext.NetworkId != null)
            {
                request.NetworkId = cmdletContext.NetworkId;
            }
            
             // populate NodeConfiguration
            var requestNodeConfigurationIsNull = true;
            request.NodeConfiguration = new Amazon.ManagedBlockchain.Model.NodeConfiguration();
            System.String requestNodeConfiguration_nodeConfiguration_AvailabilityZone = null;
            if (cmdletContext.NodeConfiguration_AvailabilityZone != null)
            {
                requestNodeConfiguration_nodeConfiguration_AvailabilityZone = cmdletContext.NodeConfiguration_AvailabilityZone;
            }
            if (requestNodeConfiguration_nodeConfiguration_AvailabilityZone != null)
            {
                request.NodeConfiguration.AvailabilityZone = requestNodeConfiguration_nodeConfiguration_AvailabilityZone;
                requestNodeConfigurationIsNull = false;
            }
            System.String requestNodeConfiguration_nodeConfiguration_InstanceType = null;
            if (cmdletContext.NodeConfiguration_InstanceType != null)
            {
                requestNodeConfiguration_nodeConfiguration_InstanceType = cmdletContext.NodeConfiguration_InstanceType;
            }
            if (requestNodeConfiguration_nodeConfiguration_InstanceType != null)
            {
                request.NodeConfiguration.InstanceType = requestNodeConfiguration_nodeConfiguration_InstanceType;
                requestNodeConfigurationIsNull = false;
            }
            Amazon.ManagedBlockchain.StateDBType requestNodeConfiguration_nodeConfiguration_StateDB = null;
            if (cmdletContext.NodeConfiguration_StateDB != null)
            {
                requestNodeConfiguration_nodeConfiguration_StateDB = cmdletContext.NodeConfiguration_StateDB;
            }
            if (requestNodeConfiguration_nodeConfiguration_StateDB != null)
            {
                request.NodeConfiguration.StateDB = requestNodeConfiguration_nodeConfiguration_StateDB;
                requestNodeConfigurationIsNull = false;
            }
            Amazon.ManagedBlockchain.Model.NodeLogPublishingConfiguration requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration = null;
            
             // populate LogPublishingConfiguration
            var requestNodeConfiguration_nodeConfiguration_LogPublishingConfigurationIsNull = true;
            requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration = new Amazon.ManagedBlockchain.Model.NodeLogPublishingConfiguration();
            Amazon.ManagedBlockchain.Model.NodeFabricLogPublishingConfiguration requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration_logPublishingConfiguration_Fabric = null;
            if (cmdletContext.LogPublishingConfiguration_Fabric != null)
            {
                requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration_logPublishingConfiguration_Fabric = cmdletContext.LogPublishingConfiguration_Fabric;
            }
            if (requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration_logPublishingConfiguration_Fabric != null)
            {
                requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration.Fabric = requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration_logPublishingConfiguration_Fabric;
                requestNodeConfiguration_nodeConfiguration_LogPublishingConfigurationIsNull = false;
            }
             // determine if requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration should be set to null
            if (requestNodeConfiguration_nodeConfiguration_LogPublishingConfigurationIsNull)
            {
                requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration = null;
            }
            if (requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration != null)
            {
                request.NodeConfiguration.LogPublishingConfiguration = requestNodeConfiguration_nodeConfiguration_LogPublishingConfiguration;
                requestNodeConfigurationIsNull = false;
            }
             // determine if request.NodeConfiguration should be set to null
            if (requestNodeConfigurationIsNull)
            {
                request.NodeConfiguration = null;
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
        
        private Amazon.ManagedBlockchain.Model.CreateNodeResponse CallAWSServiceOperation(IAmazonManagedBlockchain client, Amazon.ManagedBlockchain.Model.CreateNodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain", "CreateNode");
            try
            {
                #if DESKTOP
                return client.CreateNode(request);
                #elif CORECLR
                return client.CreateNodeAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String ClientRequestToken { get; set; }
            public System.String MemberId { get; set; }
            public System.String NetworkId { get; set; }
            public System.String NodeConfiguration_AvailabilityZone { get; set; }
            public System.String NodeConfiguration_InstanceType { get; set; }
            public Amazon.ManagedBlockchain.Model.NodeFabricLogPublishingConfiguration LogPublishingConfiguration_Fabric { get; set; }
            public Amazon.ManagedBlockchain.StateDBType NodeConfiguration_StateDB { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ManagedBlockchain.Model.CreateNodeResponse, NewMBCNodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NodeId;
        }
        
    }
}
