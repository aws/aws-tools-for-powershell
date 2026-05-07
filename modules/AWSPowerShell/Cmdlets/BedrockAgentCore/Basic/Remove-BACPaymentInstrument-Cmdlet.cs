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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Delete a payment instrument
    /// 
    ///  
    /// <para>
    /// Marks a payment instrument as deleted by updating its status to DELETED. This is a
    /// soft delete operation that preserves the record in the database for audit and compliance
    /// purposes. The record remains queryable for audit purposes but is excluded from normal
    /// list and get operations.
    /// </para><para>
    /// Deleting an already-deleted or non-existent instrument returns ResourceNotFoundException
    /// (404).
    /// </para><para>
    /// Authorization: The caller must own the instrument (accountId, userId, and paymentManagerId
    /// must match). If authorization fails, a 403 Forbidden error is returned.
    /// </para><para>
    /// Timestamp Management: The updatedAt timestamp is set to the current time, while createdAt
    /// is preserved. The version field is incremented for optimistic locking.
    /// </para><para>
    /// Errors:
    /// </para><ul><li>ResourceNotFoundException: The instrument does not exist or is already deleted</li><li>AccessDeniedException: The caller is not authorized to delete this instrument</li><li>ValidationException: Required fields are missing or invalid</li><li>InternalServerException:
    /// An unexpected server error occurred</li></ul>
    /// </summary>
    [Cmdlet("Remove", "BACPaymentInstrument", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.BedrockAgentCore.PaymentInstrumentStatus")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer DeletePaymentInstrument API operation.", Operation = new[] {"DeletePaymentInstrument"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.DeletePaymentInstrumentResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.PaymentInstrumentStatus or Amazon.BedrockAgentCore.Model.DeletePaymentInstrumentResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.PaymentInstrumentStatus object.",
        "The service call response (type Amazon.BedrockAgentCore.Model.DeletePaymentInstrumentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveBACPaymentInstrumentCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PaymentConnectorId
        /// <summary>
        /// <para>
        /// <para>The payment connector ID. Must match the instrument's paymentConnectorId.</para>
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
        public System.String PaymentConnectorId { get; set; }
        #endregion
        
        #region Parameter PaymentInstrumentId
        /// <summary>
        /// <para>
        /// <para>The payment instrument ID to delete.</para>
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
        public System.String PaymentInstrumentId { get; set; }
        #endregion
        
        #region Parameter PaymentManagerArn
        /// <summary>
        /// <para>
        /// <para>The payment manager ARN. Must match the instrument's paymentManagerArn.</para>
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
        public System.String PaymentManagerArn { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID making the delete request. Must match the instrument's userId.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.DeletePaymentInstrumentResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.DeletePaymentInstrumentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PaymentInstrumentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-BACPaymentInstrument (DeletePaymentInstrument)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.DeletePaymentInstrumentResponse, RemoveBACPaymentInstrumentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PaymentConnectorId = this.PaymentConnectorId;
            #if MODULAR
            if (this.PaymentConnectorId == null && ParameterWasBound(nameof(this.PaymentConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PaymentInstrumentId = this.PaymentInstrumentId;
            #if MODULAR
            if (this.PaymentInstrumentId == null && ParameterWasBound(nameof(this.PaymentInstrumentId)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentInstrumentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PaymentManagerArn = this.PaymentManagerArn;
            #if MODULAR
            if (this.PaymentManagerArn == null && ParameterWasBound(nameof(this.PaymentManagerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentManagerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserId = this.UserId;
            
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
            var request = new Amazon.BedrockAgentCore.Model.DeletePaymentInstrumentRequest();
            
            if (cmdletContext.PaymentConnectorId != null)
            {
                request.PaymentConnectorId = cmdletContext.PaymentConnectorId;
            }
            if (cmdletContext.PaymentInstrumentId != null)
            {
                request.PaymentInstrumentId = cmdletContext.PaymentInstrumentId;
            }
            if (cmdletContext.PaymentManagerArn != null)
            {
                request.PaymentManagerArn = cmdletContext.PaymentManagerArn;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.BedrockAgentCore.Model.DeletePaymentInstrumentResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.DeletePaymentInstrumentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "DeletePaymentInstrument");
            try
            {
                return client.DeletePaymentInstrumentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PaymentConnectorId { get; set; }
            public System.String PaymentInstrumentId { get; set; }
            public System.String PaymentManagerArn { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.DeletePaymentInstrumentResponse, RemoveBACPaymentInstrumentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
