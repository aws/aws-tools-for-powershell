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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Returns a list of all flow operations ran in a specific firewall. You can optionally
    /// narrow the request scope by specifying the operation type or Availability Zone associated
    /// with a firewall's flow operations. 
    /// 
    ///  
    /// <para>
    /// Flow operations let you manage the flows tracked in the flow table, also known as
    /// the firewall table.
    /// </para><para>
    /// A flow is network traffic that is monitored by a firewall, either by stateful or stateless
    /// rules. For traffic to be considered part of a flow, it must share Destination, DestinationPort,
    /// Direction, Protocol, Source, and SourcePort. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "NWFWFlowOperationList")]
    [OutputType("Amazon.NetworkFirewall.Model.FlowOperationMetadata")]
    [AWSCmdlet("Calls the AWS Network Firewall ListFlowOperations API operation.", Operation = new[] {"ListFlowOperations"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.ListFlowOperationsResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.FlowOperationMetadata or Amazon.NetworkFirewall.Model.ListFlowOperationsResponse",
        "This cmdlet returns a collection of Amazon.NetworkFirewall.Model.FlowOperationMetadata objects.",
        "The service call response (type Amazon.NetworkFirewall.Model.ListFlowOperationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetNWFWFlowOperationListCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The ID of the Availability Zone where the firewall is located. For example, <c>us-east-2a</c>.</para><para>Defines the scope a flow operation. You can use up to 20 filters to configure a single
        /// flow operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter FirewallArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the firewall.</para>
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
        public System.String FirewallArn { get; set; }
        #endregion
        
        #region Parameter FlowOperationType
        /// <summary>
        /// <para>
        /// <para>An optional string that defines whether any or all operation types are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.FlowOperationType")]
        public Amazon.NetworkFirewall.FlowOperationType FlowOperationType { get; set; }
        #endregion
        
        #region Parameter VpcEndpointAssociationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a VPC endpoint association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcEndpointAssociationArn { get; set; }
        #endregion
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the primary endpoint associated with a firewall.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of objects that you want Network Firewall to return for this request.
        /// If more objects are available, in the response, Network Firewall provides a <c>NextToken</c>
        /// value that you can use in a subsequent call to get the next batch of objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>When you request a list of objects with a <c>MaxResults</c> setting, if the number
        /// of objects that are still available for retrieval exceeds the maximum you requested,
        /// Network Firewall returns a <c>NextToken</c> value in the response. To retrieve the
        /// next batch of objects, use the token returned from the prior request in your next
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FlowOperations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.ListFlowOperationsResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.ListFlowOperationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FlowOperations";
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
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.ListFlowOperationsResponse, GetNWFWFlowOperationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            context.FirewallArn = this.FirewallArn;
            #if MODULAR
            if (this.FirewallArn == null && ParameterWasBound(nameof(this.FirewallArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FlowOperationType = this.FlowOperationType;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.VpcEndpointAssociationArn = this.VpcEndpointAssociationArn;
            context.VpcEndpointId = this.VpcEndpointId;
            
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
            var request = new Amazon.NetworkFirewall.Model.ListFlowOperationsRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.FirewallArn != null)
            {
                request.FirewallArn = cmdletContext.FirewallArn;
            }
            if (cmdletContext.FlowOperationType != null)
            {
                request.FlowOperationType = cmdletContext.FlowOperationType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.VpcEndpointAssociationArn != null)
            {
                request.VpcEndpointAssociationArn = cmdletContext.VpcEndpointAssociationArn;
            }
            if (cmdletContext.VpcEndpointId != null)
            {
                request.VpcEndpointId = cmdletContext.VpcEndpointId;
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
        
        private Amazon.NetworkFirewall.Model.ListFlowOperationsResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.ListFlowOperationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "ListFlowOperations");
            try
            {
                return client.ListFlowOperationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String FirewallArn { get; set; }
            public Amazon.NetworkFirewall.FlowOperationType FlowOperationType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String VpcEndpointAssociationArn { get; set; }
            public System.String VpcEndpointId { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.ListFlowOperationsResponse, GetNWFWFlowOperationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FlowOperations;
        }
        
    }
}
