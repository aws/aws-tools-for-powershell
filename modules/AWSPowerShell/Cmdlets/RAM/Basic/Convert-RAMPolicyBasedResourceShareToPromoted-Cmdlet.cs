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
using Amazon.RAM;
using Amazon.RAM.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RAM
{
    /// <summary>
    /// When you attach a resource-based policy to a resource, RAM automatically creates a
    /// resource share of <c>featureSet</c>=<c>CREATED_FROM_POLICY</c> with a managed permission
    /// that has the same IAM permissions as the original resource-based policy. However,
    /// this type of managed permission is visible to only the resource share owner, and the
    /// associated resource share can't be modified by using RAM.
    /// 
    ///  
    /// <para>
    /// This operation promotes the resource share to a <c>STANDARD</c> resource share that
    /// is fully manageable in RAM. When you promote a resource share, you can then manage
    /// the resource share in RAM and it becomes visible to all of the principals you shared
    /// it with.
    /// </para><important><para>
    /// Before you perform this operation, you should first run <a>PromotePermissionCreatedFromPolicy</a>to
    /// ensure that you have an appropriate customer managed permission that can be associated
    /// with this resource share after its is promoted. If this operation can't find a managed
    /// permission that exactly matches the existing <c>CREATED_FROM_POLICY</c> permission,
    /// then this operation fails.
    /// </para></important>
    /// </summary>
    [Cmdlet("Convert", "RAMPolicyBasedResourceShareToPromoted", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the AWS Resource Access Manager (RAM) PromoteResourceShareCreatedFromPolicy API operation.", Operation = new[] {"PromoteResourceShareCreatedFromPolicy"}, SelectReturnType = typeof(Amazon.RAM.Model.PromoteResourceShareCreatedFromPolicyResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.RAM.Model.PromoteResourceShareCreatedFromPolicyResponse",
        "This cmdlet returns a collection of System.Boolean objects.",
        "The service call response (type Amazon.RAM.Model.PromoteResourceShareCreatedFromPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConvertRAMPolicyBasedResourceShareToPromotedCmdlet : AmazonRAMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResourceShareArn
        /// <summary>
        /// <para>
        /// <para>Specifies the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of the resource share to promote.</para>
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
        public System.String ResourceShareArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReturnValue'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RAM.Model.PromoteResourceShareCreatedFromPolicyResponse).
        /// Specifying the name of a property of type Amazon.RAM.Model.PromoteResourceShareCreatedFromPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReturnValue";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceShareArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Convert-RAMPolicyBasedResourceShareToPromoted (PromoteResourceShareCreatedFromPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RAM.Model.PromoteResourceShareCreatedFromPolicyResponse, ConvertRAMPolicyBasedResourceShareToPromotedCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResourceShareArn = this.ResourceShareArn;
            #if MODULAR
            if (this.ResourceShareArn == null && ParameterWasBound(nameof(this.ResourceShareArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceShareArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RAM.Model.PromoteResourceShareCreatedFromPolicyRequest();
            
            if (cmdletContext.ResourceShareArn != null)
            {
                request.ResourceShareArn = cmdletContext.ResourceShareArn;
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
        
        private Amazon.RAM.Model.PromoteResourceShareCreatedFromPolicyResponse CallAWSServiceOperation(IAmazonRAM client, Amazon.RAM.Model.PromoteResourceShareCreatedFromPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Access Manager (RAM)", "PromoteResourceShareCreatedFromPolicy");
            try
            {
                return client.PromoteResourceShareCreatedFromPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResourceShareArn { get; set; }
            public System.Func<Amazon.RAM.Model.PromoteResourceShareCreatedFromPolicyResponse, ConvertRAMPolicyBasedResourceShareToPromotedCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReturnValue;
        }
        
    }
}
