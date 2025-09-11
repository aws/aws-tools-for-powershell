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
using Amazon.EMRContainers;
using Amazon.EMRContainers.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMRC
{
    /// <summary>
    /// Creates a virtual cluster. Virtual cluster is a managed entity on Amazon EMR on EKS.
    /// You can create, describe, list and delete virtual clusters. They do not consume any
    /// additional resource in your system. A single virtual cluster maps to a single Kubernetes
    /// namespace. Given this relationship, you can model virtual clusters the same way you
    /// model Kubernetes namespaces to meet your requirements.
    /// </summary>
    [Cmdlet("New", "EMRCVirtualCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EMRContainers.Model.CreateVirtualClusterResponse")]
    [AWSCmdlet("Calls the Amazon EMR Containers CreateVirtualCluster API operation.", Operation = new[] {"CreateVirtualCluster"}, SelectReturnType = typeof(Amazon.EMRContainers.Model.CreateVirtualClusterResponse))]
    [AWSCmdletOutput("Amazon.EMRContainers.Model.CreateVirtualClusterResponse",
        "This cmdlet returns an Amazon.EMRContainers.Model.CreateVirtualClusterResponse object containing multiple properties."
    )]
    public partial class NewEMRCVirtualClusterCmdlet : AmazonEMRContainersClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContainerProvider_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the container cluster.</para>
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
        public System.String ContainerProvider_Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The specified name of the virtual cluster.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EksInfo_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespaces of the Amazon EKS cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProvider_Info_EksInfo_Namespace")]
        public System.String EksInfo_Namespace { get; set; }
        #endregion
        
        #region Parameter EksInfo_NodeLabel
        /// <summary>
        /// <para>
        /// <para>The nodeLabel of the nodes where the resources of this virtual cluster can get scheduled.
        /// It requires relevant scaling and policy engine addons.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProvider_Info_EksInfo_NodeLabel")]
        public System.String EksInfo_NodeLabel { get; set; }
        #endregion
        
        #region Parameter SecurityConfigurationId
        /// <summary>
        /// <para>
        /// <para>The ID of the security configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityConfigurationId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the virtual cluster.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ContainerProvider_Type
        /// <summary>
        /// <para>
        /// <para>The type of the container provider. Amazon EKS is the only supported type as of now.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EMRContainers.ContainerProviderType")]
        public Amazon.EMRContainers.ContainerProviderType ContainerProvider_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token of the virtual cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRContainers.Model.CreateVirtualClusterResponse).
        /// Specifying the name of a property of type Amazon.EMRContainers.Model.CreateVirtualClusterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMRCVirtualCluster (CreateVirtualCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EMRContainers.Model.CreateVirtualClusterResponse, NewEMRCVirtualClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ContainerProvider_Id = this.ContainerProvider_Id;
            #if MODULAR
            if (this.ContainerProvider_Id == null && ParameterWasBound(nameof(this.ContainerProvider_Id)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerProvider_Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EksInfo_Namespace = this.EksInfo_Namespace;
            context.EksInfo_NodeLabel = this.EksInfo_NodeLabel;
            context.ContainerProvider_Type = this.ContainerProvider_Type;
            #if MODULAR
            if (this.ContainerProvider_Type == null && ParameterWasBound(nameof(this.ContainerProvider_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerProvider_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecurityConfigurationId = this.SecurityConfigurationId;
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
            var request = new Amazon.EMRContainers.Model.CreateVirtualClusterRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ContainerProvider
            var requestContainerProviderIsNull = true;
            request.ContainerProvider = new Amazon.EMRContainers.Model.ContainerProvider();
            System.String requestContainerProvider_containerProvider_Id = null;
            if (cmdletContext.ContainerProvider_Id != null)
            {
                requestContainerProvider_containerProvider_Id = cmdletContext.ContainerProvider_Id;
            }
            if (requestContainerProvider_containerProvider_Id != null)
            {
                request.ContainerProvider.Id = requestContainerProvider_containerProvider_Id;
                requestContainerProviderIsNull = false;
            }
            Amazon.EMRContainers.ContainerProviderType requestContainerProvider_containerProvider_Type = null;
            if (cmdletContext.ContainerProvider_Type != null)
            {
                requestContainerProvider_containerProvider_Type = cmdletContext.ContainerProvider_Type;
            }
            if (requestContainerProvider_containerProvider_Type != null)
            {
                request.ContainerProvider.Type = requestContainerProvider_containerProvider_Type;
                requestContainerProviderIsNull = false;
            }
            Amazon.EMRContainers.Model.ContainerInfo requestContainerProvider_containerProvider_Info = null;
            
             // populate Info
            var requestContainerProvider_containerProvider_InfoIsNull = true;
            requestContainerProvider_containerProvider_Info = new Amazon.EMRContainers.Model.ContainerInfo();
            Amazon.EMRContainers.Model.EksInfo requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo = null;
            
             // populate EksInfo
            var requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfoIsNull = true;
            requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo = new Amazon.EMRContainers.Model.EksInfo();
            System.String requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_Namespace = null;
            if (cmdletContext.EksInfo_Namespace != null)
            {
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_Namespace = cmdletContext.EksInfo_Namespace;
            }
            if (requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_Namespace != null)
            {
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo.Namespace = requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_Namespace;
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfoIsNull = false;
            }
            System.String requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_NodeLabel = null;
            if (cmdletContext.EksInfo_NodeLabel != null)
            {
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_NodeLabel = cmdletContext.EksInfo_NodeLabel;
            }
            if (requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_NodeLabel != null)
            {
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo.NodeLabel = requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_NodeLabel;
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfoIsNull = false;
            }
             // determine if requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo should be set to null
            if (requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfoIsNull)
            {
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo = null;
            }
            if (requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo != null)
            {
                requestContainerProvider_containerProvider_Info.EksInfo = requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo;
                requestContainerProvider_containerProvider_InfoIsNull = false;
            }
             // determine if requestContainerProvider_containerProvider_Info should be set to null
            if (requestContainerProvider_containerProvider_InfoIsNull)
            {
                requestContainerProvider_containerProvider_Info = null;
            }
            if (requestContainerProvider_containerProvider_Info != null)
            {
                request.ContainerProvider.Info = requestContainerProvider_containerProvider_Info;
                requestContainerProviderIsNull = false;
            }
             // determine if request.ContainerProvider should be set to null
            if (requestContainerProviderIsNull)
            {
                request.ContainerProvider = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SecurityConfigurationId != null)
            {
                request.SecurityConfigurationId = cmdletContext.SecurityConfigurationId;
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
        
        private Amazon.EMRContainers.Model.CreateVirtualClusterResponse CallAWSServiceOperation(IAmazonEMRContainers client, Amazon.EMRContainers.Model.CreateVirtualClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EMR Containers", "CreateVirtualCluster");
            try
            {
                return client.CreateVirtualClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ContainerProvider_Id { get; set; }
            public System.String EksInfo_Namespace { get; set; }
            public System.String EksInfo_NodeLabel { get; set; }
            public Amazon.EMRContainers.ContainerProviderType ContainerProvider_Type { get; set; }
            public System.String Name { get; set; }
            public System.String SecurityConfigurationId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.EMRContainers.Model.CreateVirtualClusterResponse, NewEMRCVirtualClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
