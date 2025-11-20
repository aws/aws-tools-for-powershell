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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies a transit gateway metering policy.
    /// </summary>
    [Cmdlet("Edit", "EC2TransitGatewayMeteringPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayMeteringPolicy")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyTransitGatewayMeteringPolicy API operation.", Operation = new[] {"ModifyTransitGatewayMeteringPolicy"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyTransitGatewayMeteringPolicyResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayMeteringPolicy or Amazon.EC2.Model.ModifyTransitGatewayMeteringPolicyResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayMeteringPolicy object.",
        "The service call response (type Amazon.EC2.Model.ModifyTransitGatewayMeteringPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2TransitGatewayMeteringPolicyCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AddMiddleboxAttachmentId
        /// <summary>
        /// <para>
        /// <para>The IDs of middlebox attachments to add to the metering policy.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddMiddleboxAttachmentIds")]
        public System.String[] AddMiddleboxAttachmentId { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter RemoveMiddleboxAttachmentId
        /// <summary>
        /// <para>
        /// <para>The IDs of middlebox attachments to remove from the metering policy.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveMiddleboxAttachmentIds")]
        public System.String[] RemoveMiddleboxAttachmentId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayMeteringPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway metering policy to modify.</para>
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
        public System.String TransitGatewayMeteringPolicyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayMeteringPolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyTransitGatewayMeteringPolicyResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyTransitGatewayMeteringPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayMeteringPolicy";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2TransitGatewayMeteringPolicy (ModifyTransitGatewayMeteringPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyTransitGatewayMeteringPolicyResponse, EditEC2TransitGatewayMeteringPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddMiddleboxAttachmentId != null)
            {
                context.AddMiddleboxAttachmentId = new List<System.String>(this.AddMiddleboxAttachmentId);
            }
            context.DryRun = this.DryRun;
            if (this.RemoveMiddleboxAttachmentId != null)
            {
                context.RemoveMiddleboxAttachmentId = new List<System.String>(this.RemoveMiddleboxAttachmentId);
            }
            context.TransitGatewayMeteringPolicyId = this.TransitGatewayMeteringPolicyId;
            #if MODULAR
            if (this.TransitGatewayMeteringPolicyId == null && ParameterWasBound(nameof(this.TransitGatewayMeteringPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayMeteringPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyTransitGatewayMeteringPolicyRequest();
            
            if (cmdletContext.AddMiddleboxAttachmentId != null)
            {
                request.AddMiddleboxAttachmentIds = cmdletContext.AddMiddleboxAttachmentId;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.RemoveMiddleboxAttachmentId != null)
            {
                request.RemoveMiddleboxAttachmentIds = cmdletContext.RemoveMiddleboxAttachmentId;
            }
            if (cmdletContext.TransitGatewayMeteringPolicyId != null)
            {
                request.TransitGatewayMeteringPolicyId = cmdletContext.TransitGatewayMeteringPolicyId;
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
        
        private Amazon.EC2.Model.ModifyTransitGatewayMeteringPolicyResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyTransitGatewayMeteringPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyTransitGatewayMeteringPolicy");
            try
            {
                return client.ModifyTransitGatewayMeteringPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AddMiddleboxAttachmentId { get; set; }
            public System.Boolean? DryRun { get; set; }
            public List<System.String> RemoveMiddleboxAttachmentId { get; set; }
            public System.String TransitGatewayMeteringPolicyId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyTransitGatewayMeteringPolicyResponse, EditEC2TransitGatewayMeteringPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayMeteringPolicy;
        }
        
    }
}
