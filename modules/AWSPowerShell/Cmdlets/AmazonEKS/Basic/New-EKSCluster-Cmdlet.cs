/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Creates an Amazon EKS control plane. 
    /// 
    ///  
    /// <para>
    /// The Amazon EKS control plane consists of control plane instances that run the Kubernetes
    /// software, like <code>etcd</code> and the API server. The control plane runs in an
    /// account managed by AWS, and the Kubernetes API is exposed via the Amazon EKS API server
    /// endpoint. Each Amazon EKS cluster control plane is single-tenant and unique, and runs
    /// on its own set of Amazon EC2 instances.
    /// </para><para>
    /// The cluster control plane is provisioned across multiple Availability Zones and fronted
    /// by an Elastic Load Balancing Network Load Balancer. Amazon EKS also provisions elastic
    /// network interfaces in your VPC subnets to provide connectivity from the control plane
    /// instances to the worker nodes (for example, to support <code>kubectl exec</code>,
    /// <code>logs</code>, and <code>proxy</code> data flows).
    /// </para><para>
    /// Amazon EKS worker nodes run in your AWS account and connect to your cluster's control
    /// plane via the Kubernetes API server endpoint and a certificate file that is created
    /// for your cluster.
    /// </para><para>
    /// You can use the <code>endpointPublicAccess</code> and <code>endpointPrivateAccess</code>
    /// parameters to enable or disable public and private access to your cluster's Kubernetes
    /// API server endpoint. By default, public access is enabled and private access is disabled.
    /// For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/cluster-endpoint.html">Amazon
    /// EKS Cluster Endpoint Access Control</a> in the <i><i>Amazon EKS User Guide</i></i>.
    /// 
    /// </para><para>
    /// You can use the <code>logging</code> parameter to enable or disable exporting the
    /// Kubernetes control plane logs for your cluster to CloudWatch Logs. By default, cluster
    /// control plane logs are not exported to CloudWatch Logs. For more information, see
    /// <a href="https://docs.aws.amazon.com/eks/latest/userguide/control-plane-logs.html">Amazon
    /// EKS Cluster Control Plane Logs</a> in the <i><i>Amazon EKS User Guide</i></i>.
    /// </para><note><para>
    /// CloudWatch Logs ingestion, archive storage, and data scanning rates apply to exported
    /// control plane logs. For more information, see <a href="http://aws.amazon.com/cloudwatch/pricing/">Amazon
    /// CloudWatch Pricing</a>.
    /// </para></note><para>
    /// Cluster creation typically takes between 10 and 15 minutes. After you create an Amazon
    /// EKS cluster, you must configure your Kubernetes tooling to communicate with the API
    /// server and launch worker nodes into your cluster. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/managing-auth.html">Managing
    /// Cluster Authentication</a> and <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-workers.html">Launching
    /// Amazon EKS Worker Nodes</a> in the <i>Amazon EKS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EKSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes CreateCluster API operation.", Operation = new[] {"CreateCluster"})]
    [AWSCmdletOutput("Amazon.EKS.Model.Cluster",
        "This cmdlet returns a Cluster object.",
        "The service call response (type Amazon.EKS.Model.CreateClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEKSClusterCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Logging_ClusterLogging
        /// <summary>
        /// <para>
        /// <para>The cluster control plane logging configuration for your cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EKS.Model.LogSetup[] Logging_ClusterLogging { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The unique name to give to your cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResourcesVpcConfig
        /// <summary>
        /// <para>
        /// <para>The VPC configuration used by the cluster control plane. Amazon EKS VPC resources
        /// have specific requirements to work properly with Kubernetes. For more information,
        /// see <a href="https://docs.aws.amazon.com/eks/latest/userguide/network_reqs.html">Cluster
        /// VPC Considerations</a> and <a href="https://docs.aws.amazon.com/eks/latest/userguide/sec-group-reqs.html">Cluster
        /// Security Group Considerations</a> in the <i>Amazon EKS User Guide</i>. You must specify
        /// at least two subnets. You may specify up to five security groups, but we recommend
        /// that you use a dedicated security group for your cluster control plane.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EKS.Model.VpcConfigRequest ResourcesVpcConfig { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that provides permissions for Amazon
        /// EKS to make calls to other AWS API operations on your behalf. For more information,
        /// see <a href="https://docs.aws.amazon.com/eks/latest/userguide/service_IAM_role.html">Amazon
        /// EKS Service IAM Role</a> in the <i><i>Amazon EKS User Guide</i></i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The desired Kubernetes version for your cluster. If you do not specify a value here,
        /// the latest version available in Amazon EKS is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EKSCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.Logging_ClusterLogging != null)
            {
                context.Logging_ClusterLogging = new List<Amazon.EKS.Model.LogSetup>(this.Logging_ClusterLogging);
            }
            context.Name = this.Name;
            context.ResourcesVpcConfig = this.ResourcesVpcConfig;
            context.RoleArn = this.RoleArn;
            context.Version = this.Version;
            
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
            var request = new Amazon.EKS.Model.CreateClusterRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate Logging
            bool requestLoggingIsNull = true;
            request.Logging = new Amazon.EKS.Model.Logging();
            List<Amazon.EKS.Model.LogSetup> requestLogging_logging_ClusterLogging = null;
            if (cmdletContext.Logging_ClusterLogging != null)
            {
                requestLogging_logging_ClusterLogging = cmdletContext.Logging_ClusterLogging;
            }
            if (requestLogging_logging_ClusterLogging != null)
            {
                request.Logging.ClusterLogging = requestLogging_logging_ClusterLogging;
                requestLoggingIsNull = false;
            }
             // determine if request.Logging should be set to null
            if (requestLoggingIsNull)
            {
                request.Logging = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ResourcesVpcConfig != null)
            {
                request.ResourcesVpcConfig = cmdletContext.ResourcesVpcConfig;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Cluster;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.EKS.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "CreateCluster");
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
            public System.String ClientRequestToken { get; set; }
            public List<Amazon.EKS.Model.LogSetup> Logging_ClusterLogging { get; set; }
            public System.String Name { get; set; }
            public Amazon.EKS.Model.VpcConfigRequest ResourcesVpcConfig { get; set; }
            public System.String RoleArn { get; set; }
            public System.String Version { get; set; }
        }
        
    }
}
