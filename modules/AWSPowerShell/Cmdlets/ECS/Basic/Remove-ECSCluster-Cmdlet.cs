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
using Amazon.ECS;
using Amazon.ECS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Deletes the specified cluster. The cluster transitions to the <c>INACTIVE</c> state.
    /// Clusters with an <c>INACTIVE</c> status might remain discoverable in your account
    /// for a period of time. However, this behavior is subject to change in the future. We
    /// don't recommend that you rely on <c>INACTIVE</c> clusters persisting.
    /// 
    ///  
    /// <para>
    /// You must deregister all container instances from this cluster before you may delete
    /// it. You can list the container instances in a cluster with <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_ListContainerInstances.html">ListContainerInstances</a>
    /// and deregister them with <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_DeregisterContainerInstance.html">DeregisterContainerInstance</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "ECSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ECS.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service DeleteCluster API operation.", Operation = new[] {"DeleteCluster"}, SelectReturnType = typeof(Amazon.ECS.Model.DeleteClusterResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.Cluster or Amazon.ECS.Model.DeleteClusterResponse",
        "This cmdlet returns an Amazon.ECS.Model.Cluster object.",
        "The service call response (type Amazon.ECS.Model.DeleteClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveECSClusterCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster to delete.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.DeleteClusterResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.DeleteClusterResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Cluster), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ECSCluster (DeleteCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.DeleteClusterResponse, RemoveECSClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Cluster = this.Cluster;
            #if MODULAR
            if (this.Cluster == null && ParameterWasBound(nameof(this.Cluster)))
            {
                WriteWarning("You are passing $null as a value for parameter Cluster which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.DeleteClusterRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
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
        
        private Amazon.ECS.Model.DeleteClusterResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.DeleteClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "DeleteCluster");
            try
            {
                return client.DeleteClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Cluster { get; set; }
            public System.Func<Amazon.ECS.Model.DeleteClusterResponse, RemoveECSClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
