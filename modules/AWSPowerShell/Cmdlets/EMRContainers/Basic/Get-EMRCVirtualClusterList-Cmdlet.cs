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
using Amazon.EMRContainers;
using Amazon.EMRContainers.Model;

namespace Amazon.PowerShell.Cmdlets.EMRC
{
    /// <summary>
    /// Lists information about the specified virtual cluster. Virtual cluster is a managed
    /// entity on Amazon EMR on EKS. You can create, describe, list and delete virtual clusters.
    /// They do not consume any additional resource in your system. A single virtual cluster
    /// maps to a single Kubernetes namespace. Given this relationship, you can model virtual
    /// clusters the same way you model Kubernetes namespaces to meet your requirements.
    /// </summary>
    [Cmdlet("Get", "EMRCVirtualClusterList")]
    [OutputType("Amazon.EMRContainers.Model.VirtualCluster")]
    [AWSCmdlet("Calls the Amazon EMR Containers ListVirtualClusters API operation.", Operation = new[] {"ListVirtualClusters"}, SelectReturnType = typeof(Amazon.EMRContainers.Model.ListVirtualClustersResponse))]
    [AWSCmdletOutput("Amazon.EMRContainers.Model.VirtualCluster or Amazon.EMRContainers.Model.ListVirtualClustersResponse",
        "This cmdlet returns a collection of Amazon.EMRContainers.Model.VirtualCluster objects.",
        "The service call response (type Amazon.EMRContainers.Model.ListVirtualClustersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEMRCVirtualClusterListCmdlet : AmazonEMRContainersClientCmdlet, IExecutor
    {
        
        #region Parameter ContainerProviderId
        /// <summary>
        /// <para>
        /// <para>The container provider ID of the virtual cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerProviderId { get; set; }
        #endregion
        
        #region Parameter ContainerProviderType
        /// <summary>
        /// <para>
        /// <para>The container provider type of the virtual cluster. EKS is the only supported type
        /// as of now.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EMRContainers.ContainerProviderType")]
        public Amazon.EMRContainers.ContainerProviderType ContainerProviderType { get; set; }
        #endregion
        
        #region Parameter CreatedAfter
        /// <summary>
        /// <para>
        /// <para>The date and time after which the virtual clusters are created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAfter { get; set; }
        #endregion
        
        #region Parameter CreatedBefore
        /// <summary>
        /// <para>
        /// <para>The date and time before which the virtual clusters are created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedBefore { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The states of the requested virtual clusters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("States")]
        public System.String[] State { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of virtual clusters that can be listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of virtual clusters to return. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VirtualClusters'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRContainers.Model.ListVirtualClustersResponse).
        /// Specifying the name of a property of type Amazon.EMRContainers.Model.ListVirtualClustersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VirtualClusters";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EMRContainers.Model.ListVirtualClustersResponse, GetEMRCVirtualClusterListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContainerProviderId = this.ContainerProviderId;
            context.ContainerProviderType = this.ContainerProviderType;
            context.CreatedAfter = this.CreatedAfter;
            context.CreatedBefore = this.CreatedBefore;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.State != null)
            {
                context.State = new List<System.String>(this.State);
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
            var request = new Amazon.EMRContainers.Model.ListVirtualClustersRequest();
            
            if (cmdletContext.ContainerProviderId != null)
            {
                request.ContainerProviderId = cmdletContext.ContainerProviderId;
            }
            if (cmdletContext.ContainerProviderType != null)
            {
                request.ContainerProviderType = cmdletContext.ContainerProviderType;
            }
            if (cmdletContext.CreatedAfter != null)
            {
                request.CreatedAfter = cmdletContext.CreatedAfter.Value;
            }
            if (cmdletContext.CreatedBefore != null)
            {
                request.CreatedBefore = cmdletContext.CreatedBefore.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.State != null)
            {
                request.States = cmdletContext.State;
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
        
        private Amazon.EMRContainers.Model.ListVirtualClustersResponse CallAWSServiceOperation(IAmazonEMRContainers client, Amazon.EMRContainers.Model.ListVirtualClustersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EMR Containers", "ListVirtualClusters");
            try
            {
                #if DESKTOP
                return client.ListVirtualClusters(request);
                #elif CORECLR
                return client.ListVirtualClustersAsync(request).GetAwaiter().GetResult();
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
            public System.String ContainerProviderId { get; set; }
            public Amazon.EMRContainers.ContainerProviderType ContainerProviderType { get; set; }
            public System.DateTime? CreatedAfter { get; set; }
            public System.DateTime? CreatedBefore { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> State { get; set; }
            public System.Func<Amazon.EMRContainers.Model.ListVirtualClustersResponse, GetEMRCVirtualClusterListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VirtualClusters;
        }
        
    }
}
