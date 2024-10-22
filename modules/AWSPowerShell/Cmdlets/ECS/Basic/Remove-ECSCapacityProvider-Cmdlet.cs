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
    /// Deletes the specified capacity provider.
    /// 
    ///  <note><para>
    /// The <c>FARGATE</c> and <c>FARGATE_SPOT</c> capacity providers are reserved and can't
    /// be deleted. You can disassociate them from a cluster using either <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_PutCapacityProviderProviders.html">PutCapacityProviderProviders</a>
    /// or by deleting the cluster.
    /// </para></note><para>
    /// Prior to a capacity provider being deleted, the capacity provider must be removed
    /// from the capacity provider strategy from all services. The <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_UpdateService.html">UpdateService</a>
    /// API can be used to remove a capacity provider from a service's capacity provider strategy.
    /// When updating a service, the <c>forceNewDeployment</c> option can be used to ensure
    /// that any tasks using the Amazon EC2 instance capacity provided by the capacity provider
    /// are transitioned to use the capacity from the remaining capacity providers. Only capacity
    /// providers that aren't associated with a cluster can be deleted. To remove a capacity
    /// provider from a cluster, you can either use <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_PutCapacityProviderProviders.html">PutCapacityProviderProviders</a>
    /// or delete the cluster.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "ECSCapacityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ECS.Model.CapacityProvider")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service DeleteCapacityProvider API operation.", Operation = new[] {"DeleteCapacityProvider"}, SelectReturnType = typeof(Amazon.ECS.Model.DeleteCapacityProviderResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.CapacityProvider or Amazon.ECS.Model.DeleteCapacityProviderResponse",
        "This cmdlet returns an Amazon.ECS.Model.CapacityProvider object.",
        "The service call response (type Amazon.ECS.Model.DeleteCapacityProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveECSCapacityProviderCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityProvider
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the capacity provider to delete.</para>
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
        public System.String CapacityProvider { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.DeleteCapacityProviderResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.DeleteCapacityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityProvider";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapacityProvider), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ECSCapacityProvider (DeleteCapacityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.DeleteCapacityProviderResponse, RemoveECSCapacityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityProvider = this.CapacityProvider;
            #if MODULAR
            if (this.CapacityProvider == null && ParameterWasBound(nameof(this.CapacityProvider)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityProvider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.DeleteCapacityProviderRequest();
            
            if (cmdletContext.CapacityProvider != null)
            {
                request.CapacityProvider = cmdletContext.CapacityProvider;
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
        
        private Amazon.ECS.Model.DeleteCapacityProviderResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.DeleteCapacityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "DeleteCapacityProvider");
            try
            {
                #if DESKTOP
                return client.DeleteCapacityProvider(request);
                #elif CORECLR
                return client.DeleteCapacityProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String CapacityProvider { get; set; }
            public System.Func<Amazon.ECS.Model.DeleteCapacityProviderResponse, RemoveECSCapacityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityProvider;
        }
        
    }
}
