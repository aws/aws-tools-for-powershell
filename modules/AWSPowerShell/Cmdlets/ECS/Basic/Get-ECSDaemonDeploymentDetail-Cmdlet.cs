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
    /// Describes one or more of your daemon deployments.
    /// 
    ///  
    /// <para>
    /// A daemon deployment orchestrates the progressive rollout of daemon task updates across
    /// container instances managed by the daemon's capacity providers. Each deployment includes
    /// circuit breaker and alarm-based rollback capabilities.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ECSDaemonDeploymentDetail")]
    [OutputType("Amazon.ECS.Model.DescribeDaemonDeploymentsResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service DescribeDaemonDeployments API operation.", Operation = new[] {"DescribeDaemonDeployments"}, SelectReturnType = typeof(Amazon.ECS.Model.DescribeDaemonDeploymentsResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.DescribeDaemonDeploymentsResponse",
        "This cmdlet returns an Amazon.ECS.Model.DescribeDaemonDeploymentsResponse object containing multiple properties."
    )]
    public partial class GetECSDaemonDeploymentDetailCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DaemonDeploymentArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the daemon deployments to describe. You can specify up to 20 ARNs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("DaemonDeploymentArns")]
        public System.String[] DaemonDeploymentArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.DescribeDaemonDeploymentsResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.DescribeDaemonDeploymentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.DescribeDaemonDeploymentsResponse, GetECSDaemonDeploymentDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DaemonDeploymentArn != null)
            {
                context.DaemonDeploymentArn = new List<System.String>(this.DaemonDeploymentArn);
            }
            #if MODULAR
            if (this.DaemonDeploymentArn == null && ParameterWasBound(nameof(this.DaemonDeploymentArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DaemonDeploymentArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.DescribeDaemonDeploymentsRequest();
            
            if (cmdletContext.DaemonDeploymentArn != null)
            {
                request.DaemonDeploymentArns = cmdletContext.DaemonDeploymentArn;
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
        
        private Amazon.ECS.Model.DescribeDaemonDeploymentsResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.DescribeDaemonDeploymentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "DescribeDaemonDeployments");
            try
            {
                return client.DescribeDaemonDeploymentsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> DaemonDeploymentArn { get; set; }
            public System.Func<Amazon.ECS.Model.DescribeDaemonDeploymentsResponse, GetECSDaemonDeploymentDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
