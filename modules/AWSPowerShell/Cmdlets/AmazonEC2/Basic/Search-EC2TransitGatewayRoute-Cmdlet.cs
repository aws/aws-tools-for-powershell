/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Searches for routes in the specified transit gateway route table.
    /// </summary>
    [Cmdlet("Search", "EC2TransitGatewayRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.SearchTransitGatewayRoutesResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud SearchTransitGatewayRoutes API operation.", Operation = new[] {"SearchTransitGatewayRoutes"})]
    [AWSCmdletOutput("Amazon.EC2.Model.SearchTransitGatewayRoutesResponse",
        "This cmdlet returns a Amazon.EC2.Model.SearchTransitGatewayRoutesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchEC2TransitGatewayRouteCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters. The possible values are:</para><ul><li><para><code>attachment.transit-gateway-attachment-id</code>- The id of the transit gateway
        /// attachment.</para></li><li><para><code>attachment.resource-id</code> - The resource id of the transit gateway attachment.</para></li><li><para><code>attachment.resource-type</code> - The attachment resource type (<code>vpc</code>
        /// | <code>vpn</code>).</para></li><li><para><code>route-search.exact-match</code> - The exact match of the specified filter.</para></li><li><para><code>route-search.longest-prefix-match</code> - The longest prefix that matches
        /// the route.</para></li><li><para><code>route-search.subnet-of-match</code> - The routes with a subnet that match the
        /// specified CIDR filter.</para></li><li><para><code>route-search.supernet-of-match</code> - The routes with a CIDR that encompass
        /// the CIDR filter. For example, if you have 10.0.1.0/29 and 10.0.1.0/31 routes in your
        /// route table and you specify supernet-of-match as 10.0.1.0/30, then the result returns
        /// 10.0.1.0/29.</para></li><li><para><code>state</code> - The state of the attachment (<code>available</code> | <code>deleted</code>
        /// | <code>deleting</code> | <code>failed</code> | <code>modifying</code> | <code>pendingAcceptance</code>
        /// | <code>pending</code> | <code>rollingBack</code> | <code>rejected</code> | <code>rejecting</code>).</para></li><li><para><code>type</code> - The type of roue (<code>active</code> | <code>blackhole</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter TransitGatewayRouteTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway route table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TransitGatewayRouteTableId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of routes to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TransitGatewayRouteTableId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-EC2TransitGatewayRoute (SearchTransitGatewayRoutes)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.TransitGatewayRouteTableId = this.TransitGatewayRouteTableId;
            
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
            var request = new Amazon.EC2.Model.SearchTransitGatewayRoutesRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.TransitGatewayRouteTableId != null)
            {
                request.TransitGatewayRouteTableId = cmdletContext.TransitGatewayRouteTableId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.EC2.Model.SearchTransitGatewayRoutesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.SearchTransitGatewayRoutesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "SearchTransitGatewayRoutes");
            try
            {
                #if DESKTOP
                return client.SearchTransitGatewayRoutes(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SearchTransitGatewayRoutesAsync(request);
                return task.Result;
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
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String TransitGatewayRouteTableId { get; set; }
        }
        
    }
}
