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
    /// Describes a gateway route, including its status, the service it routes traffic to,
    /// and the service-specific infrastructure, such as target groups and listener rules,
    /// that the gateway manages for it.
    /// </summary>
    [Cmdlet("Get", "ECSGatewayRouteDetail")]
    [OutputType("Amazon.ECS.Model.GatewayRoute")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service DescribeGatewayRoute API operation.", Operation = new[] {"DescribeGatewayRoute"}, SelectReturnType = typeof(Amazon.ECS.Model.DescribeGatewayRouteResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.GatewayRoute or Amazon.ECS.Model.DescribeGatewayRouteResponse",
        "This cmdlet returns an Amazon.ECS.Model.GatewayRoute object.",
        "The service call response (type Amazon.ECS.Model.DescribeGatewayRouteResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECSGatewayRouteDetailCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GatewayRouteArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the gateway route to describe.</para>
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
        public System.String GatewayRouteArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GatewayRoute'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.DescribeGatewayRouteResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.DescribeGatewayRouteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GatewayRoute";
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
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.DescribeGatewayRouteResponse, GetECSGatewayRouteDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GatewayRouteArn = this.GatewayRouteArn;
            #if MODULAR
            if (this.GatewayRouteArn == null && ParameterWasBound(nameof(this.GatewayRouteArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayRouteArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.DescribeGatewayRouteRequest();
            
            if (cmdletContext.GatewayRouteArn != null)
            {
                request.GatewayRouteArn = cmdletContext.GatewayRouteArn;
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
        
        private Amazon.ECS.Model.DescribeGatewayRouteResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.DescribeGatewayRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "DescribeGatewayRoute");
            try
            {
                return client.DescribeGatewayRouteAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GatewayRouteArn { get; set; }
            public System.Func<Amazon.ECS.Model.DescribeGatewayRouteResponse, GetECSGatewayRouteDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GatewayRoute;
        }
        
    }
}
