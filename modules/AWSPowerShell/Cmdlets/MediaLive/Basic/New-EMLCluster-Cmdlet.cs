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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Create a new Cluster.
    /// </summary>
    [Cmdlet("New", "EMLCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.CreateClusterResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.MediaLive.Model.CreateClusterResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.CreateClusterResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.CreateClusterResponse object containing multiple properties."
    )]
    public partial class NewEMLClusterCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterType
        /// <summary>
        /// <para>
        /// Specify a type. All the Nodes that you later
        /// add to this Cluster must be this type of hardware. One Cluster instance can't contain
        /// different hardware types. You won't be able to change this parameter after you create
        /// the Cluster.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.ClusterType")]
        public Amazon.MediaLive.ClusterType ClusterType { get; set; }
        #endregion
        
        #region Parameter NetworkSettings_DefaultRoute
        /// <summary>
        /// <para>
        /// Specify one network interface as the default
        /// route for traffic to and from the Node. MediaLive Anywhere uses this default when
        /// the destination for the traffic isn't covered by the route table for any of the networks.
        /// Specify the value of the appropriate logicalInterfaceName parameter that you create
        /// in the interfaceMappings.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkSettings_DefaultRoute { get; set; }
        #endregion
        
        #region Parameter InstanceRoleArn
        /// <summary>
        /// <para>
        /// The ARN of the IAM role for the Node in
        /// this Cluster. The role must include all the operations that you expect these Node
        /// to perform. If necessary, create a role in IAM, then attach it here.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceRoleArn { get; set; }
        #endregion
        
        #region Parameter NetworkSettings_InterfaceMapping
        /// <summary>
        /// <para>
        /// An array of interfaceMapping objects
        /// for this Cluster. You must create a mapping for node interfaces that you plan to use
        /// for encoding traffic. You typically don't create a mapping for the management interface.
        /// You define this mapping in the Cluster so that the mapping can be used by all the
        /// Nodes. Each mapping logically connects one interface on the nodes with one Network.
        /// Each mapping consists of a pair of parameters. The logicalInterfaceName parameter
        /// creates a logical name for the Node interface that handles a specific type of traffic.
        /// For example, my-Inputs-Interface. The networkID parameter refers to the ID of the
        /// network. When you create the Nodes in this Cluster, you will associate the logicalInterfaceName
        /// with the appropriate physical interface.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkSettings_InterfaceMappings")]
        public Amazon.MediaLive.Model.InterfaceMappingCreateRequest[] NetworkSettings_InterfaceMapping { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Specify a name that is unique in the AWS account.
        /// We recommend that you assign a name that hints at the types of Nodes in the Cluster.
        /// Names are case-sensitive.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// The unique ID of the request.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// A collection of key-value pairs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.CreateClusterResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMLCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.CreateClusterResponse, NewEMLClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterType = this.ClusterType;
            context.InstanceRoleArn = this.InstanceRoleArn;
            context.Name = this.Name;
            context.NetworkSettings_DefaultRoute = this.NetworkSettings_DefaultRoute;
            if (this.NetworkSettings_InterfaceMapping != null)
            {
                context.NetworkSettings_InterfaceMapping = new List<Amazon.MediaLive.Model.InterfaceMappingCreateRequest>(this.NetworkSettings_InterfaceMapping);
            }
            context.RequestId = this.RequestId;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.MediaLive.Model.CreateClusterRequest();
            
            if (cmdletContext.ClusterType != null)
            {
                request.ClusterType = cmdletContext.ClusterType;
            }
            if (cmdletContext.InstanceRoleArn != null)
            {
                request.InstanceRoleArn = cmdletContext.InstanceRoleArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NetworkSettings
            var requestNetworkSettingsIsNull = true;
            request.NetworkSettings = new Amazon.MediaLive.Model.ClusterNetworkSettingsCreateRequest();
            System.String requestNetworkSettings_networkSettings_DefaultRoute = null;
            if (cmdletContext.NetworkSettings_DefaultRoute != null)
            {
                requestNetworkSettings_networkSettings_DefaultRoute = cmdletContext.NetworkSettings_DefaultRoute;
            }
            if (requestNetworkSettings_networkSettings_DefaultRoute != null)
            {
                request.NetworkSettings.DefaultRoute = requestNetworkSettings_networkSettings_DefaultRoute;
                requestNetworkSettingsIsNull = false;
            }
            List<Amazon.MediaLive.Model.InterfaceMappingCreateRequest> requestNetworkSettings_networkSettings_InterfaceMapping = null;
            if (cmdletContext.NetworkSettings_InterfaceMapping != null)
            {
                requestNetworkSettings_networkSettings_InterfaceMapping = cmdletContext.NetworkSettings_InterfaceMapping;
            }
            if (requestNetworkSettings_networkSettings_InterfaceMapping != null)
            {
                request.NetworkSettings.InterfaceMappings = requestNetworkSettings_networkSettings_InterfaceMapping;
                requestNetworkSettingsIsNull = false;
            }
             // determine if request.NetworkSettings should be set to null
            if (requestNetworkSettingsIsNull)
            {
                request.NetworkSettings = null;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
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
        
        private Amazon.MediaLive.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "CreateCluster");
            try
            {
                #if DESKTOP
                return client.CreateCluster(request);
                #elif CORECLR
                return client.CreateClusterAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MediaLive.ClusterType ClusterType { get; set; }
            public System.String InstanceRoleArn { get; set; }
            public System.String Name { get; set; }
            public System.String NetworkSettings_DefaultRoute { get; set; }
            public List<Amazon.MediaLive.Model.InterfaceMappingCreateRequest> NetworkSettings_InterfaceMapping { get; set; }
            public System.String RequestId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaLive.Model.CreateClusterResponse, NewEMLClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
