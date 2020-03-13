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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Creates a new Amazon ECS cluster. By default, your account receives a <code>default</code>
    /// cluster when you launch your first container instance. However, you can create your
    /// own cluster with a unique name with the <code>CreateCluster</code> action.
    /// 
    ///  <note><para>
    /// When you call the <a>CreateCluster</a> API operation, Amazon ECS attempts to create
    /// the Amazon ECS service-linked role for your account so that required resources in
    /// other AWS services can be managed on your behalf. However, if the IAM user that makes
    /// the call does not have permissions to create the service-linked role, it is not created.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/using-service-linked-roles.html">Using
    /// Service-Linked Roles for Amazon ECS</a> in the <i>Amazon Elastic Container Service
    /// Developer Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "ECSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.ECS.Model.CreateClusterResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.Cluster or Amazon.ECS.Model.CreateClusterResponse",
        "This cmdlet returns an Amazon.ECS.Model.Cluster object.",
        "The service call response (type Amazon.ECS.Model.CreateClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewECSClusterCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter CapacityProvider
        /// <summary>
        /// <para>
        /// <para>The short name of one or more capacity providers to associate with the cluster.</para><para>If specifying a capacity provider that uses an Auto Scaling group, the capacity provider
        /// must already be created and not already associated with another cluster. New capacity
        /// providers can be created with the <a>CreateCapacityProvider</a> API operation.</para><para>To use a AWS Fargate capacity provider, specify either the <code>FARGATE</code> or
        /// <code>FARGATE_SPOT</code> capacity providers. The AWS Fargate capacity providers are
        /// available to all accounts and only need to be associated with a cluster to be used.</para><para>The <a>PutClusterCapacityProviders</a> API operation is used to update the list of
        /// available capacity providers for a cluster after the cluster is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityProviders")]
        public System.String[] CapacityProvider { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of your cluster. If you do not specify a name for your cluster, you create
        /// a cluster named <code>default</code>. Up to 255 letters (uppercase and lowercase),
        /// numbers, and hyphens are allowed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter DefaultCapacityProviderStrategy
        /// <summary>
        /// <para>
        /// <para>The capacity provider strategy to use by default for the cluster.</para><para>When creating a service or running a task on a cluster, if no capacity provider or
        /// launch type is specified then the default capacity provider strategy for the cluster
        /// is used.</para><para>A capacity provider strategy consists of one or more capacity providers along with
        /// the <code>base</code> and <code>weight</code> to assign to them. A capacity provider
        /// must be associated with the cluster to be used in a capacity provider strategy. The
        /// <a>PutClusterCapacityProviders</a> API is used to associate a capacity provider with
        /// a cluster. Only capacity providers with an <code>ACTIVE</code> or <code>UPDATING</code>
        /// status can be used.</para><para>If specifying a capacity provider that uses an Auto Scaling group, the capacity provider
        /// must already be created. New capacity providers can be created with the <a>CreateCapacityProvider</a>
        /// API operation.</para><para>To use a AWS Fargate capacity provider, specify either the <code>FARGATE</code> or
        /// <code>FARGATE_SPOT</code> capacity providers. The AWS Fargate capacity providers are
        /// available to all accounts and only need to be associated with a cluster to be used.</para><para>If a default capacity provider strategy is not defined for a cluster during creation,
        /// it can be defined later with the <a>PutClusterCapacityProviders</a> API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.CapacityProviderStrategyItem[] DefaultCapacityProviderStrategy { get; set; }
        #endregion
        
        #region Parameter Setting
        /// <summary>
        /// <para>
        /// <para>The setting to use when creating a cluster. This parameter is used to enable CloudWatch
        /// Container Insights for a cluster. If this value is specified, it will override the
        /// <code>containerInsights</code> value set with <a>PutAccountSetting</a> or <a>PutAccountSettingDefault</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings")]
        public Amazon.ECS.Model.ClusterSetting[] Setting { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the cluster to help you categorize and organize them.
        /// Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case-sensitive.</para></li><li><para>Do not use <code>aws:</code>, <code>AWS:</code>, or any upper or lowercase combination
        /// of such as a prefix for either keys or values as it is reserved for AWS use. You cannot
        /// edit or delete tag keys or values with this prefix. Tags with this prefix do not count
        /// against your tags per resource limit.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ECS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.CreateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECSCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.CreateClusterResponse, NewECSClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CapacityProvider != null)
            {
                context.CapacityProvider = new List<System.String>(this.CapacityProvider);
            }
            context.ClusterName = this.ClusterName;
            if (this.DefaultCapacityProviderStrategy != null)
            {
                context.DefaultCapacityProviderStrategy = new List<Amazon.ECS.Model.CapacityProviderStrategyItem>(this.DefaultCapacityProviderStrategy);
            }
            if (this.Setting != null)
            {
                context.Setting = new List<Amazon.ECS.Model.ClusterSetting>(this.Setting);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ECS.Model.Tag>(this.Tag);
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
            var request = new Amazon.ECS.Model.CreateClusterRequest();
            
            if (cmdletContext.CapacityProvider != null)
            {
                request.CapacityProviders = cmdletContext.CapacityProvider;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.DefaultCapacityProviderStrategy != null)
            {
                request.DefaultCapacityProviderStrategy = cmdletContext.DefaultCapacityProviderStrategy;
            }
            if (cmdletContext.Setting != null)
            {
                request.Settings = cmdletContext.Setting;
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
        
        private Amazon.ECS.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "CreateCluster");
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
            public List<System.String> CapacityProvider { get; set; }
            public System.String ClusterName { get; set; }
            public List<Amazon.ECS.Model.CapacityProviderStrategyItem> DefaultCapacityProviderStrategy { get; set; }
            public List<Amazon.ECS.Model.ClusterSetting> Setting { get; set; }
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ECS.Model.CreateClusterResponse, NewECSClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
