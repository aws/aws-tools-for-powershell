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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Gets information about a connection group by using the endpoint that you specify.
    /// </summary>
    [Cmdlet("Get", "CFConnectionGroupByRoutingEndpoint")]
    [OutputType("Amazon.CloudFront.Model.ConnectionGroup")]
    [AWSCmdlet("Calls the Amazon CloudFront GetConnectionGroupByRoutingEndpoint API operation.", Operation = new[] {"GetConnectionGroupByRoutingEndpoint"}, SelectReturnType = typeof(Amazon.CloudFront.Model.GetConnectionGroupByRoutingEndpointResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.ConnectionGroup or Amazon.CloudFront.Model.GetConnectionGroupByRoutingEndpointResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.ConnectionGroup object.",
        "The service call response (type Amazon.CloudFront.Model.GetConnectionGroupByRoutingEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFConnectionGroupByRoutingEndpointCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RoutingEndpoint
        /// <summary>
        /// <para>
        /// <para>The routing endpoint for the target connection group, such as d111111abcdef8.cloudfront.net.</para>
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
        public System.String RoutingEndpoint { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectionGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.GetConnectionGroupByRoutingEndpointResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.GetConnectionGroupByRoutingEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectionGroup";
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
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.GetConnectionGroupByRoutingEndpointResponse, GetCFConnectionGroupByRoutingEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RoutingEndpoint = this.RoutingEndpoint;
            #if MODULAR
            if (this.RoutingEndpoint == null && ParameterWasBound(nameof(this.RoutingEndpoint)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingEndpoint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFront.Model.GetConnectionGroupByRoutingEndpointRequest();
            
            if (cmdletContext.RoutingEndpoint != null)
            {
                request.RoutingEndpoint = cmdletContext.RoutingEndpoint;
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
        
        private Amazon.CloudFront.Model.GetConnectionGroupByRoutingEndpointResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.GetConnectionGroupByRoutingEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "GetConnectionGroupByRoutingEndpoint");
            try
            {
                return client.GetConnectionGroupByRoutingEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RoutingEndpoint { get; set; }
            public System.Func<Amazon.CloudFront.Model.GetConnectionGroupByRoutingEndpointResponse, GetCFConnectionGroupByRoutingEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectionGroup;
        }
        
    }
}
