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
    /// Modifies the specified Amazon Web Services Verified Access endpoint policy.
    /// </summary>
    [Cmdlet("Edit", "EC2VerifiedAccessEndpointPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVerifiedAccessEndpointPolicy API operation.", Operation = new[] {"ModifyVerifiedAccessEndpointPolicy"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyResponse",
        "This cmdlet returns an Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VerifiedAccessEndpointPolicyCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SseSpecification_CustomerManagedKeyEnabled
        /// <summary>
        /// <para>
        /// <para> Enable or disable the use of customer managed KMS keys for server side encryption.
        /// </para><para>Valid values: <c>True</c> | <c>False</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SseSpecification_CustomerManagedKeyEnabled { get; set; }
        #endregion
        
        #region Parameter SseSpecification_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the KMS key. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SseSpecification_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter PolicyDocument
        /// <summary>
        /// <para>
        /// <para>The Verified Access policy document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyDocument { get; set; }
        #endregion
        
        #region Parameter PolicyEnabled
        /// <summary>
        /// <para>
        /// <para>The status of the Verified Access policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PolicyEnabled { get; set; }
        #endregion
        
        #region Parameter VerifiedAccessEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Verified Access endpoint.</para>
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
        public System.String VerifiedAccessEndpointId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure idempotency of your modification
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VerifiedAccessEndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VerifiedAccessEndpointPolicy (ModifyVerifiedAccessEndpointPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyResponse, EditEC2VerifiedAccessEndpointPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.PolicyDocument = this.PolicyDocument;
            context.PolicyEnabled = this.PolicyEnabled;
            context.SseSpecification_CustomerManagedKeyEnabled = this.SseSpecification_CustomerManagedKeyEnabled;
            context.SseSpecification_KmsKeyArn = this.SseSpecification_KmsKeyArn;
            context.VerifiedAccessEndpointId = this.VerifiedAccessEndpointId;
            #if MODULAR
            if (this.VerifiedAccessEndpointId == null && ParameterWasBound(nameof(this.VerifiedAccessEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter VerifiedAccessEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.PolicyDocument != null)
            {
                request.PolicyDocument = cmdletContext.PolicyDocument;
            }
            if (cmdletContext.PolicyEnabled != null)
            {
                request.PolicyEnabled = cmdletContext.PolicyEnabled.Value;
            }
            
             // populate SseSpecification
            var requestSseSpecificationIsNull = true;
            request.SseSpecification = new Amazon.EC2.Model.VerifiedAccessSseSpecificationRequest();
            System.Boolean? requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled = null;
            if (cmdletContext.SseSpecification_CustomerManagedKeyEnabled != null)
            {
                requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled = cmdletContext.SseSpecification_CustomerManagedKeyEnabled.Value;
            }
            if (requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled != null)
            {
                request.SseSpecification.CustomerManagedKeyEnabled = requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled.Value;
                requestSseSpecificationIsNull = false;
            }
            System.String requestSseSpecification_sseSpecification_KmsKeyArn = null;
            if (cmdletContext.SseSpecification_KmsKeyArn != null)
            {
                requestSseSpecification_sseSpecification_KmsKeyArn = cmdletContext.SseSpecification_KmsKeyArn;
            }
            if (requestSseSpecification_sseSpecification_KmsKeyArn != null)
            {
                request.SseSpecification.KmsKeyArn = requestSseSpecification_sseSpecification_KmsKeyArn;
                requestSseSpecificationIsNull = false;
            }
             // determine if request.SseSpecification should be set to null
            if (requestSseSpecificationIsNull)
            {
                request.SseSpecification = null;
            }
            if (cmdletContext.VerifiedAccessEndpointId != null)
            {
                request.VerifiedAccessEndpointId = cmdletContext.VerifiedAccessEndpointId;
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
        
        private Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVerifiedAccessEndpointPolicy");
            try
            {
                #if DESKTOP
                return client.ModifyVerifiedAccessEndpointPolicy(request);
                #elif CORECLR
                return client.ModifyVerifiedAccessEndpointPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String PolicyDocument { get; set; }
            public System.Boolean? PolicyEnabled { get; set; }
            public System.Boolean? SseSpecification_CustomerManagedKeyEnabled { get; set; }
            public System.String SseSpecification_KmsKeyArn { get; set; }
            public System.String VerifiedAccessEndpointId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVerifiedAccessEndpointPolicyResponse, EditEC2VerifiedAccessEndpointPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
