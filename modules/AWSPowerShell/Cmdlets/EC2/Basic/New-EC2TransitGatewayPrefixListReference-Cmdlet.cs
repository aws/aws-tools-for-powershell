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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a reference (route) to a prefix list in a specified transit gateway route
    /// table.
    /// </summary>
    [Cmdlet("New", "EC2TransitGatewayPrefixListReference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayPrefixListReference")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateTransitGatewayPrefixListReference API operation.", Operation = new[] {"CreateTransitGatewayPrefixListReference"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateTransitGatewayPrefixListReferenceResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayPrefixListReference or Amazon.EC2.Model.CreateTransitGatewayPrefixListReferenceResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayPrefixListReference object.",
        "The service call response (type Amazon.EC2.Model.CreateTransitGatewayPrefixListReferenceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2TransitGatewayPrefixListReferenceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Blackhole
        /// <summary>
        /// <para>
        /// <para>Indicates whether to drop traffic that matches this route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Blackhole { get; set; }
        #endregion
        
        #region Parameter PrefixListId
        /// <summary>
        /// <para>
        /// <para>The ID of the prefix list that is used for destination matches.</para>
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
        public System.String PrefixListId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the attachment to which traffic is routed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayAttachmentId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayRouteTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway route table.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayPrefixListReference'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateTransitGatewayPrefixListReferenceResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateTransitGatewayPrefixListReferenceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayPrefixListReference";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayRouteTableId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2TransitGatewayPrefixListReference (CreateTransitGatewayPrefixListReference)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateTransitGatewayPrefixListReferenceResponse, NewEC2TransitGatewayPrefixListReferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Blackhole = this.Blackhole;
            context.PrefixListId = this.PrefixListId;
            #if MODULAR
            if (this.PrefixListId == null && ParameterWasBound(nameof(this.PrefixListId)))
            {
                WriteWarning("You are passing $null as a value for parameter PrefixListId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransitGatewayAttachmentId = this.TransitGatewayAttachmentId;
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
            var request = new Amazon.EC2.Model.CreateTransitGatewayPrefixListReferenceRequest();
            
            if (cmdletContext.Blackhole != null)
            {
                request.Blackhole = cmdletContext.Blackhole.Value;
            }
            if (cmdletContext.PrefixListId != null)
            {
                request.PrefixListId = cmdletContext.PrefixListId;
            }
            if (cmdletContext.TransitGatewayAttachmentId != null)
            {
                request.TransitGatewayAttachmentId = cmdletContext.TransitGatewayAttachmentId;
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
        
        private Amazon.EC2.Model.CreateTransitGatewayPrefixListReferenceResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateTransitGatewayPrefixListReferenceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateTransitGatewayPrefixListReference");
            try
            {
                return client.CreateTransitGatewayPrefixListReferenceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Blackhole { get; set; }
            public System.String PrefixListId { get; set; }
            public System.String TransitGatewayAttachmentId { get; set; }
            public System.String TransitGatewayRouteTableId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateTransitGatewayPrefixListReferenceResponse, NewEC2TransitGatewayPrefixListReferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayPrefixListReference;
        }
        
    }
}
