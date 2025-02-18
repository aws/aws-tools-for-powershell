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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Associate a virtual private cloud (VPC) subnet endpoint with your custom routing accelerator.
    /// 
    ///  
    /// <para>
    /// The listener port range must be large enough to support the number of IP addresses
    /// that can be specified in your subnet. The number of ports required is: subnet size
    /// times the number of ports per destination EC2 instances. For example, a subnet defined
    /// as /24 requires a listener port range of at least 255 ports. 
    /// </para><para>
    /// Note: You must have enough remaining listener ports available to map to the subnet
    /// ports, or the call will fail with a LimitExceededException.
    /// </para><para>
    /// By default, all destinations in a subnet in a custom routing accelerator cannot receive
    /// traffic. To enable all destinations to receive traffic, or to specify individual port
    /// mappings that can receive traffic, see the <a href="https://docs.aws.amazon.com/global-accelerator/latest/api/API_AllowCustomRoutingTraffic.html">
    /// AllowCustomRoutingTraffic</a> operation.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "GACLCustomRoutingEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsResponse")]
    [AWSCmdlet("Calls the AWS Global Accelerator AddCustomRoutingEndpoints API operation.", Operation = new[] {"AddCustomRoutingEndpoints"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsResponse object containing multiple properties."
    )]
    public partial class AddGACLCustomRoutingEndpointCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndpointConfiguration
        /// <summary>
        /// <para>
        /// <para>The list of endpoint objects to add to a custom routing accelerator.</para>
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
        [Alias("EndpointConfigurations")]
        public Amazon.GlobalAccelerator.Model.CustomRoutingEndpointConfiguration[] EndpointConfiguration { get; set; }
        #endregion
        
        #region Parameter EndpointGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the endpoint group for the custom routing endpoint.</para>
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
        public System.String EndpointGroupArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointGroupArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-GACLCustomRoutingEndpoint (AddCustomRoutingEndpoints)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsResponse, AddGACLCustomRoutingEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.EndpointConfiguration != null)
            {
                context.EndpointConfiguration = new List<Amazon.GlobalAccelerator.Model.CustomRoutingEndpointConfiguration>(this.EndpointConfiguration);
            }
            #if MODULAR
            if (this.EndpointConfiguration == null && ParameterWasBound(nameof(this.EndpointConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointGroupArn = this.EndpointGroupArn;
            #if MODULAR
            if (this.EndpointGroupArn == null && ParameterWasBound(nameof(this.EndpointGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsRequest();
            
            if (cmdletContext.EndpointConfiguration != null)
            {
                request.EndpointConfigurations = cmdletContext.EndpointConfiguration;
            }
            if (cmdletContext.EndpointGroupArn != null)
            {
                request.EndpointGroupArn = cmdletContext.EndpointGroupArn;
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
        
        private Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "AddCustomRoutingEndpoints");
            try
            {
                return client.AddCustomRoutingEndpointsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.GlobalAccelerator.Model.CustomRoutingEndpointConfiguration> EndpointConfiguration { get; set; }
            public System.String EndpointGroupArn { get; set; }
            public System.Func<Amazon.GlobalAccelerator.Model.AddCustomRoutingEndpointsResponse, AddGACLCustomRoutingEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
