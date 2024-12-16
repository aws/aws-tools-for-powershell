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
    /// Creates a static route for the specified local gateway route table. You must specify
    /// one of the following targets: 
    /// 
    ///  <ul><li><para><c>LocalGatewayVirtualInterfaceGroupId</c></para></li><li><para><c>NetworkInterfaceId</c></para></li></ul>
    /// </summary>
    [Cmdlet("New", "EC2LocalGatewayRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.LocalGatewayRoute")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateLocalGatewayRoute API operation.", Operation = new[] {"CreateLocalGatewayRoute"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateLocalGatewayRouteResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.LocalGatewayRoute or Amazon.EC2.Model.CreateLocalGatewayRouteResponse",
        "This cmdlet returns an Amazon.EC2.Model.LocalGatewayRoute object.",
        "The service call response (type Amazon.EC2.Model.CreateLocalGatewayRouteResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2LocalGatewayRouteCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationCidrBlock
        /// <summary>
        /// <para>
        /// <para>The CIDR range used for destination matches. Routing decisions are based on the most
        /// specific match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationCidrBlock { get; set; }
        #endregion
        
        #region Parameter DestinationPrefixListId
        /// <summary>
        /// <para>
        /// <para> The ID of the prefix list. Use a prefix list in place of <c>DestinationCidrBlock</c>.
        /// You cannot use <c>DestinationPrefixListId</c> and <c>DestinationCidrBlock</c> in the
        /// same request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationPrefixListId { get; set; }
        #endregion
        
        #region Parameter LocalGatewayRouteTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the local gateway route table.</para>
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
        public System.String LocalGatewayRouteTableId { get; set; }
        #endregion
        
        #region Parameter LocalGatewayVirtualInterfaceGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual interface group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocalGatewayVirtualInterfaceGroupId { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Route'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateLocalGatewayRouteResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateLocalGatewayRouteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Route";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LocalGatewayRouteTableId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2LocalGatewayRoute (CreateLocalGatewayRoute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateLocalGatewayRouteResponse, NewEC2LocalGatewayRouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationCidrBlock = this.DestinationCidrBlock;
            context.DestinationPrefixListId = this.DestinationPrefixListId;
            context.LocalGatewayRouteTableId = this.LocalGatewayRouteTableId;
            #if MODULAR
            if (this.LocalGatewayRouteTableId == null && ParameterWasBound(nameof(this.LocalGatewayRouteTableId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocalGatewayRouteTableId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LocalGatewayVirtualInterfaceGroupId = this.LocalGatewayVirtualInterfaceGroupId;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            
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
            var request = new Amazon.EC2.Model.CreateLocalGatewayRouteRequest();
            
            if (cmdletContext.DestinationCidrBlock != null)
            {
                request.DestinationCidrBlock = cmdletContext.DestinationCidrBlock;
            }
            if (cmdletContext.DestinationPrefixListId != null)
            {
                request.DestinationPrefixListId = cmdletContext.DestinationPrefixListId;
            }
            if (cmdletContext.LocalGatewayRouteTableId != null)
            {
                request.LocalGatewayRouteTableId = cmdletContext.LocalGatewayRouteTableId;
            }
            if (cmdletContext.LocalGatewayVirtualInterfaceGroupId != null)
            {
                request.LocalGatewayVirtualInterfaceGroupId = cmdletContext.LocalGatewayVirtualInterfaceGroupId;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
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
        
        private Amazon.EC2.Model.CreateLocalGatewayRouteResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateLocalGatewayRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateLocalGatewayRoute");
            try
            {
                #if DESKTOP
                return client.CreateLocalGatewayRoute(request);
                #elif CORECLR
                return client.CreateLocalGatewayRouteAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationCidrBlock { get; set; }
            public System.String DestinationPrefixListId { get; set; }
            public System.String LocalGatewayRouteTableId { get; set; }
            public System.String LocalGatewayVirtualInterfaceGroupId { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateLocalGatewayRouteResponse, NewEC2LocalGatewayRouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Route;
        }
        
    }
}
