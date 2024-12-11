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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Changes the size of the cluster. You can change the cluster's type, or change the
    /// number or type of nodes. The default behavior is to use the elastic resize method.
    /// With an elastic resize, your cluster is available for read and write operations more
    /// quickly than with the classic resize method. 
    /// 
    ///  
    /// <para>
    /// Elastic resize operations have the following restrictions:
    /// </para><ul><li><para>
    /// You can only resize clusters of the following types:
    /// </para><ul><li><para>
    /// dc2.large
    /// </para></li><li><para>
    /// dc2.8xlarge
    /// </para></li><li><para>
    /// ra3.large
    /// </para></li><li><para>
    /// ra3.xlplus
    /// </para></li><li><para>
    /// ra3.4xlarge
    /// </para></li><li><para>
    /// ra3.16xlarge
    /// </para></li></ul></li><li><para>
    /// The type of nodes that you add must match the node type for the cluster.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Set", "RSClusterSize", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon Redshift ResizeCluster API operation.", Operation = new[] {"ResizeCluster"}, SelectReturnType = typeof(Amazon.Redshift.Model.ResizeClusterResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster or Amazon.Redshift.Model.ResizeClusterResponse",
        "This cmdlet returns an Amazon.Redshift.Model.Cluster object.",
        "The service call response (type Amazon.Redshift.Model.ResizeClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetRSClusterSizeCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Classic
        /// <summary>
        /// <para>
        /// <para>A boolean value indicating whether the resize operation is using the classic resize
        /// process. If you don't provide this parameter or set the value to <c>false</c>, the
        /// resize type is elastic. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Classic { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the cluster to resize.</para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ClusterType
        /// <summary>
        /// <para>
        /// <para>The new cluster type for the specified cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterType { get; set; }
        #endregion
        
        #region Parameter NodeType
        /// <summary>
        /// <para>
        /// <para>The new node type for the nodes you are adding. If not specified, the cluster's current
        /// node type is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NodeType { get; set; }
        #endregion
        
        #region Parameter NumberOfNode
        /// <summary>
        /// <para>
        /// <para>The new number of nodes for the cluster. If not specified, the cluster's current number
        /// of nodes is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumberOfNodes")]
        public System.Int32? NumberOfNode { get; set; }
        #endregion
        
        #region Parameter ReservedNodeId
        /// <summary>
        /// <para>
        /// <para>The identifier of the reserved node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReservedNodeId { get; set; }
        #endregion
        
        #region Parameter TargetReservedNodeOfferingId
        /// <summary>
        /// <para>
        /// <para>The identifier of the target reserved node offering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetReservedNodeOfferingId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.ResizeClusterResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.ResizeClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-RSClusterSize (ResizeCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.ResizeClusterResponse, SetRSClusterSizeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Classic = this.Classic;
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterType = this.ClusterType;
            context.NodeType = this.NodeType;
            context.NumberOfNode = this.NumberOfNode;
            context.ReservedNodeId = this.ReservedNodeId;
            context.TargetReservedNodeOfferingId = this.TargetReservedNodeOfferingId;
            
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
            var request = new Amazon.Redshift.Model.ResizeClusterRequest();
            
            if (cmdletContext.Classic != null)
            {
                request.Classic = cmdletContext.Classic.Value;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.ClusterType != null)
            {
                request.ClusterType = cmdletContext.ClusterType;
            }
            if (cmdletContext.NodeType != null)
            {
                request.NodeType = cmdletContext.NodeType;
            }
            if (cmdletContext.NumberOfNode != null)
            {
                request.NumberOfNodes = cmdletContext.NumberOfNode.Value;
            }
            if (cmdletContext.ReservedNodeId != null)
            {
                request.ReservedNodeId = cmdletContext.ReservedNodeId;
            }
            if (cmdletContext.TargetReservedNodeOfferingId != null)
            {
                request.TargetReservedNodeOfferingId = cmdletContext.TargetReservedNodeOfferingId;
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
        
        private Amazon.Redshift.Model.ResizeClusterResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.ResizeClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "ResizeCluster");
            try
            {
                #if DESKTOP
                return client.ResizeCluster(request);
                #elif CORECLR
                return client.ResizeClusterAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Classic { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.String ClusterType { get; set; }
            public System.String NodeType { get; set; }
            public System.Int32? NumberOfNode { get; set; }
            public System.String ReservedNodeId { get; set; }
            public System.String TargetReservedNodeOfferingId { get; set; }
            public System.Func<Amazon.Redshift.Model.ResizeClusterResponse, SetRSClusterSizeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
