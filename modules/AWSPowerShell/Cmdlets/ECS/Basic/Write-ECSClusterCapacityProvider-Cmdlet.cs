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
    /// Modifies the available capacity providers and the default capacity provider strategy
    /// for a cluster.
    /// 
    ///  
    /// <para>
    /// You must specify both the available capacity providers and a default capacity provider
    /// strategy for the cluster. If the specified cluster has existing capacity providers
    /// associated with it, you must specify all existing capacity providers in addition to
    /// any new ones you want to add. Any existing capacity providers that are associated
    /// with a cluster that are omitted from a <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_PutClusterCapacityProviders.html">PutClusterCapacityProviders</a>
    /// API call will be disassociated with the cluster. You can only disassociate an existing
    /// capacity provider from a cluster if it's not being used by any existing tasks.
    /// </para><para>
    /// When creating a service or running a task on a cluster, if no capacity provider or
    /// launch type is specified, then the cluster's default capacity provider strategy is
    /// used. We recommend that you define a default capacity provider strategy for your cluster.
    /// However, you must specify an empty array (<c>[]</c>) to bypass defining a default
    /// strategy.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ECSClusterCapacityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service PutClusterCapacityProviders API operation.", Operation = new[] {"PutClusterCapacityProviders"}, SelectReturnType = typeof(Amazon.ECS.Model.PutClusterCapacityProvidersResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.Cluster or Amazon.ECS.Model.PutClusterCapacityProvidersResponse",
        "This cmdlet returns an Amazon.ECS.Model.Cluster object.",
        "The service call response (type Amazon.ECS.Model.PutClusterCapacityProvidersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteECSClusterCapacityProviderCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityProvider
        /// <summary>
        /// <para>
        /// <para>The name of one or more capacity providers to associate with the cluster.</para><para>If specifying a capacity provider that uses an Auto Scaling group, the capacity provider
        /// must already be created. New capacity providers can be created with the <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_CreateCapacityProvider.html">CreateCapacityProvider</a>
        /// API operation.</para><para>To use a Fargate capacity provider, specify either the <c>FARGATE</c> or <c>FARGATE_SPOT</c>
        /// capacity providers. The Fargate capacity providers are available to all accounts and
        /// only need to be associated with a cluster to be used.</para>
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
        [Alias("CapacityProviders")]
        public System.String[] CapacityProvider { get; set; }
        #endregion
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster to modify the capacity
        /// provider settings for. If you don't specify a cluster, the default cluster is assumed.</para>
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
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter DefaultCapacityProviderStrategy
        /// <summary>
        /// <para>
        /// <para>The capacity provider strategy to use by default for the cluster.</para><para>When creating a service or running a task on a cluster, if no capacity provider or
        /// launch type is specified then the default capacity provider strategy for the cluster
        /// is used.</para><para>A capacity provider strategy consists of one or more capacity providers along with
        /// the <c>base</c> and <c>weight</c> to assign to them. A capacity provider must be associated
        /// with the cluster to be used in a capacity provider strategy. The <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_PutClusterCapacityProviders.html">PutClusterCapacityProviders</a>
        /// API is used to associate a capacity provider with a cluster. Only capacity providers
        /// with an <c>ACTIVE</c> or <c>UPDATING</c> status can be used.</para><para>If specifying a capacity provider that uses an Auto Scaling group, the capacity provider
        /// must already be created. New capacity providers can be created with the <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_CreateCapacityProvider.html">CreateCapacityProvider</a>
        /// API operation.</para><para>To use a Fargate capacity provider, specify either the <c>FARGATE</c> or <c>FARGATE_SPOT</c>
        /// capacity providers. The Fargate capacity providers are available to all accounts and
        /// only need to be associated with a cluster to be used.</para>
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
        public Amazon.ECS.Model.CapacityProviderStrategyItem[] DefaultCapacityProviderStrategy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.PutClusterCapacityProvidersResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.PutClusterCapacityProvidersResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Cluster), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ECSClusterCapacityProvider (PutClusterCapacityProviders)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.PutClusterCapacityProvidersResponse, WriteECSClusterCapacityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CapacityProvider != null)
            {
                context.CapacityProvider = new List<System.String>(this.CapacityProvider);
            }
            #if MODULAR
            if (this.CapacityProvider == null && ParameterWasBound(nameof(this.CapacityProvider)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityProvider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Cluster = this.Cluster;
            #if MODULAR
            if (this.Cluster == null && ParameterWasBound(nameof(this.Cluster)))
            {
                WriteWarning("You are passing $null as a value for parameter Cluster which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DefaultCapacityProviderStrategy != null)
            {
                context.DefaultCapacityProviderStrategy = new List<Amazon.ECS.Model.CapacityProviderStrategyItem>(this.DefaultCapacityProviderStrategy);
            }
            #if MODULAR
            if (this.DefaultCapacityProviderStrategy == null && ParameterWasBound(nameof(this.DefaultCapacityProviderStrategy)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultCapacityProviderStrategy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.PutClusterCapacityProvidersRequest();
            
            if (cmdletContext.CapacityProvider != null)
            {
                request.CapacityProviders = cmdletContext.CapacityProvider;
            }
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.DefaultCapacityProviderStrategy != null)
            {
                request.DefaultCapacityProviderStrategy = cmdletContext.DefaultCapacityProviderStrategy;
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
        
        private Amazon.ECS.Model.PutClusterCapacityProvidersResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.PutClusterCapacityProvidersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "PutClusterCapacityProviders");
            try
            {
                #if DESKTOP
                return client.PutClusterCapacityProviders(request);
                #elif CORECLR
                return client.PutClusterCapacityProvidersAsync(request).GetAwaiter().GetResult();
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
            public System.String Cluster { get; set; }
            public List<Amazon.ECS.Model.CapacityProviderStrategyItem> DefaultCapacityProviderStrategy { get; set; }
            public System.Func<Amazon.ECS.Model.PutClusterCapacityProvidersResponse, WriteECSClusterCapacityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
