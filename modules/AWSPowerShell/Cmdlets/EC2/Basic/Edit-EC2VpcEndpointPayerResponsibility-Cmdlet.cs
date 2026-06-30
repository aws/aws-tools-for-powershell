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
    /// Modifies the billing account for VPC endpoint usage/charges.
    /// </summary>
    [Cmdlet("Edit", "EC2VpcEndpointPayerResponsibility", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpcEndpointPayerResponsibility API operation.", Operation = new[] {"ModifyVpcEndpointPayerResponsibility"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityResponse",
        "This cmdlet returns an Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityResponse object containing multiple properties."
    )]
    public partial class EditEC2VpcEndpointPayerResponsibilityCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter PayerResponsibility
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account to which the usage of VPC endpoint is charged.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.PayerResponsibilityType")]
        public Amazon.EC2.PayerResponsibilityType PayerResponsibility { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The scope of usage/charges for which the billing account is being modified.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.PayerResponsibilityScope")]
        public Amazon.EC2.PayerResponsibilityScope Scope { get; set; }
        #endregion
        
        #region Parameter ServiceId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC endpoint service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceId { get; set; }
        #endregion
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC endpoint.</para>
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
        public System.String VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpcEndpointPayerResponsibility (ModifyVpcEndpointPayerResponsibility)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityResponse, EditEC2VpcEndpointPayerResponsibilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.PayerResponsibility = this.PayerResponsibility;
            #if MODULAR
            if (this.PayerResponsibility == null && ParameterWasBound(nameof(this.PayerResponsibility)))
            {
                WriteWarning("You are passing $null as a value for parameter PayerResponsibility which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceId = this.ServiceId;
            context.VpcEndpointId = this.VpcEndpointId;
            #if MODULAR
            if (this.VpcEndpointId == null && ParameterWasBound(nameof(this.VpcEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.PayerResponsibility != null)
            {
                request.PayerResponsibility = cmdletContext.PayerResponsibility;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.ServiceId != null)
            {
                request.ServiceId = cmdletContext.ServiceId;
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
        
        private Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpcEndpointPayerResponsibility");
            try
            {
                return client.ModifyVpcEndpointPayerResponsibilityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public Amazon.EC2.PayerResponsibilityType PayerResponsibility { get; set; }
            public Amazon.EC2.PayerResponsibilityScope Scope { get; set; }
            public System.String ServiceId { get; set; }
            public System.String VpcEndpointId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpcEndpointPayerResponsibilityResponse, EditEC2VpcEndpointPayerResponsibilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
