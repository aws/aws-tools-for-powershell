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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Exports routes from the specified transit gateway route table to the specified S3
    /// bucket. By default, all routes are exported. Alternatively, you can filter by CIDR
    /// range.
    /// 
    ///  
    /// <para>
    /// The routes are saved to the specified bucket in a JSON file. For more information,
    /// see <a href="https://docs.aws.amazon.com/vpc/latest/tgw/tgw-route-tables.html#tgw-export-route-tables">Export
    /// route tables to Amazon S3</a> in the <i>Amazon Web Services Transit Gateways Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Export", "EC2TransitGatewayRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ExportTransitGatewayRoutes API operation.", Operation = new[] {"ExportTransitGatewayRoutes"}, SelectReturnType = typeof(Amazon.EC2.Model.ExportTransitGatewayRoutesResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.ExportTransitGatewayRoutesResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.ExportTransitGatewayRoutesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ExportEC2TransitGatewayRouteCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters. The possible values are:</para><ul><li><para><c>attachment.transit-gateway-attachment-id</c> - The id of the transit gateway attachment.</para></li><li><para><c>attachment.resource-id</c> - The resource id of the transit gateway attachment.</para></li><li><para><c>route-search.exact-match</c> - The exact match of the specified filter.</para></li><li><para><c>route-search.longest-prefix-match</c> - The longest prefix that matches the route.</para></li><li><para><c>route-search.subnet-of-match</c> - The routes with a subnet that match the specified
        /// CIDR filter.</para></li><li><para><c>route-search.supernet-of-match</c> - The routes with a CIDR that encompass the
        /// CIDR filter. For example, if you have 10.0.1.0/29 and 10.0.1.0/31 routes in your route
        /// table and you specify supernet-of-match as 10.0.1.0/30, then the result returns 10.0.1.0/29.</para></li><li><para><c>state</c> - The state of the route (<c>active</c> | <c>blackhole</c>).</para></li><li><para><c>transit-gateway-route-destination-cidr-block</c> - The CIDR range.</para></li><li><para><c>type</c> - The type of route (<c>propagated</c> | <c>static</c>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter S3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String S3Bucket { get; set; }
        #endregion
        
        #region Parameter TransitGatewayRouteTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the route table.</para>
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
        public System.String TransitGatewayRouteTableId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'S3Location'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ExportTransitGatewayRoutesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ExportTransitGatewayRoutesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "S3Location";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayRouteTableId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-EC2TransitGatewayRoute (ExportTransitGatewayRoutes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ExportTransitGatewayRoutesResponse, ExportEC2TransitGatewayRouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.S3Bucket = this.S3Bucket;
            #if MODULAR
            if (this.S3Bucket == null && ParameterWasBound(nameof(this.S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransitGatewayRouteTableId = this.TransitGatewayRouteTableId;
            #if MODULAR
            if (this.TransitGatewayRouteTableId == null && ParameterWasBound(nameof(this.TransitGatewayRouteTableId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayRouteTableId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ExportTransitGatewayRoutesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.S3Bucket != null)
            {
                request.S3Bucket = cmdletContext.S3Bucket;
            }
            if (cmdletContext.TransitGatewayRouteTableId != null)
            {
                request.TransitGatewayRouteTableId = cmdletContext.TransitGatewayRouteTableId;
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
        
        private Amazon.EC2.Model.ExportTransitGatewayRoutesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ExportTransitGatewayRoutesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ExportTransitGatewayRoutes");
            try
            {
                #if DESKTOP
                return client.ExportTransitGatewayRoutes(request);
                #elif CORECLR
                return client.ExportTransitGatewayRoutesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.String S3Bucket { get; set; }
            public System.String TransitGatewayRouteTableId { get; set; }
            public System.Func<Amazon.EC2.Model.ExportTransitGatewayRoutesResponse, ExportEC2TransitGatewayRouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.S3Location;
        }
        
    }
}
