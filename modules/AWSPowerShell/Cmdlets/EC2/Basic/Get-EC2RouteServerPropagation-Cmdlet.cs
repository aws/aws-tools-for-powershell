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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Gets information about the route propagations for the specified route server.
    /// 
    ///  
    /// <para>
    /// When enabled, route server propagation installs the routes in the FIB on the route
    /// table you've specified. Route server supports IPv4 and IPv6 route propagation.
    /// </para><para>
    /// Amazon VPC Route Server simplifies routing for traffic between workloads that are
    /// deployed within a VPC and its internet gateways. With this feature, VPC Route Server
    /// dynamically updates VPC and internet gateway route tables with your preferred IPv4
    /// or IPv6 routes to achieve routing fault tolerance for those workloads. This enables
    /// you to automatically reroute traffic within a VPC, which increases the manageability
    /// of VPC routing and interoperability with third-party workloads.
    /// </para><para>
    /// Route server supports the follow route table types:
    /// </para><ul><li><para>
    /// VPC route tables not associated with subnets
    /// </para></li><li><para>
    /// Subnet route tables
    /// </para></li><li><para>
    /// Internet gateway route tables
    /// </para></li></ul><para>
    /// Route server does not support route tables associated with virtual private gateways.
    /// To propagate routes into a transit gateway route table, use <a href="https://docs.aws.amazon.com/vpc/latest/tgw/tgw-connect.html">Transit
    /// Gateway Connect</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2RouteServerPropagation")]
    [OutputType("Amazon.EC2.Model.RouteServerPropagation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetRouteServerPropagations API operation.", Operation = new[] {"GetRouteServerPropagations"}, SelectReturnType = typeof(Amazon.EC2.Model.GetRouteServerPropagationsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.RouteServerPropagation or Amazon.EC2.Model.GetRouteServerPropagationsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.RouteServerPropagation objects.",
        "The service call response (type Amazon.EC2.Model.GetRouteServerPropagationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2RouteServerPropagationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RouteServerId
        /// <summary>
        /// <para>
        /// <para>The ID of the route server for which to get propagation information.</para>
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
        public System.String RouteServerId { get; set; }
        #endregion
        
        #region Parameter RouteTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the route table for which to get propagation information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RouteTableId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RouteServerPropagations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetRouteServerPropagationsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetRouteServerPropagationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RouteServerPropagations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RouteServerId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RouteServerId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RouteServerId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetRouteServerPropagationsResponse, GetEC2RouteServerPropagationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RouteServerId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RouteServerId = this.RouteServerId;
            #if MODULAR
            if (this.RouteServerId == null && ParameterWasBound(nameof(this.RouteServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter RouteServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RouteTableId = this.RouteTableId;
            
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
            var request = new Amazon.EC2.Model.GetRouteServerPropagationsRequest();
            
            if (cmdletContext.RouteServerId != null)
            {
                request.RouteServerId = cmdletContext.RouteServerId;
            }
            if (cmdletContext.RouteTableId != null)
            {
                request.RouteTableId = cmdletContext.RouteTableId;
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
        
        private Amazon.EC2.Model.GetRouteServerPropagationsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetRouteServerPropagationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetRouteServerPropagations");
            try
            {
                #if DESKTOP
                return client.GetRouteServerPropagations(request);
                #elif CORECLR
                return client.GetRouteServerPropagationsAsync(request).GetAwaiter().GetResult();
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
            public System.String RouteServerId { get; set; }
            public System.String RouteTableId { get; set; }
            public System.Func<Amazon.EC2.Model.GetRouteServerPropagationsResponse, GetEC2RouteServerPropagationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RouteServerPropagations;
        }
        
    }
}
