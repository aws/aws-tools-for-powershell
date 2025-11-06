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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates details about a contact evaluation in the specified Amazon Connect instance.
    /// A contact evaluation must be in draft state. Answers included in the request are merged
    /// with existing answers for the given evaluation. An answer or note can be deleted by
    /// passing an empty object (<c>{}</c>) to the question identifier.
    /// </summary>
    [Cmdlet("Update", "CONNContactEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.UpdateContactEvaluationResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateContactEvaluation API operation.", Operation = new[] {"UpdateContactEvaluation"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateContactEvaluationResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.UpdateContactEvaluationResponse",
        "This cmdlet returns an Amazon.Connect.Model.UpdateContactEvaluationResponse object containing multiple properties."
    )]
    public partial class UpdateCONNContactEvaluationCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Answer
        /// <summary>
        /// <para>
        /// <para>A map of question identifiers to answer value.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Answers")]
        public System.Collections.Hashtable Answer { get; set; }
        #endregion
        
        #region Parameter UpdatedBy_ConnectUserArn
        /// <summary>
        /// <para>
        /// <para>Represents the Amazon Connect ARN of the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedBy_ConnectUserArn { get; set; }
        #endregion
        
        #region Parameter EvaluationId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the contact evaluation.</para>
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
        public System.String EvaluationId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Note
        /// <summary>
        /// <para>
        /// <para>A map of question identifiers to note value.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Notes")]
        public System.Collections.Hashtable Note { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateContactEvaluationResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.UpdateContactEvaluationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EvaluationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNContactEvaluation (UpdateContactEvaluation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateContactEvaluationResponse, UpdateCONNContactEvaluationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Answer != null)
            {
                context.Answer = new Dictionary<System.String, Amazon.Connect.Model.EvaluationAnswerInput>(StringComparer.Ordinal);
                foreach (var hashKey in this.Answer.Keys)
                {
                    context.Answer.Add((String)hashKey, (Amazon.Connect.Model.EvaluationAnswerInput)(this.Answer[hashKey]));
                }
            }
            context.EvaluationId = this.EvaluationId;
            #if MODULAR
            if (this.EvaluationId == null && ParameterWasBound(nameof(this.EvaluationId)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Note != null)
            {
                context.Note = new Dictionary<System.String, Amazon.Connect.Model.EvaluationNote>(StringComparer.Ordinal);
                foreach (var hashKey in this.Note.Keys)
                {
                    context.Note.Add((String)hashKey, (Amazon.Connect.Model.EvaluationNote)(this.Note[hashKey]));
                }
            }
            context.UpdatedBy_ConnectUserArn = this.UpdatedBy_ConnectUserArn;
            
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
            var request = new Amazon.Connect.Model.UpdateContactEvaluationRequest();
            
            if (cmdletContext.Answer != null)
            {
                request.Answers = cmdletContext.Answer;
            }
            if (cmdletContext.EvaluationId != null)
            {
                request.EvaluationId = cmdletContext.EvaluationId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Note != null)
            {
                request.Notes = cmdletContext.Note;
            }
            
             // populate UpdatedBy
            var requestUpdatedByIsNull = true;
            request.UpdatedBy = new Amazon.Connect.Model.EvaluatorUserUnion();
            System.String requestUpdatedBy_updatedBy_ConnectUserArn = null;
            if (cmdletContext.UpdatedBy_ConnectUserArn != null)
            {
                requestUpdatedBy_updatedBy_ConnectUserArn = cmdletContext.UpdatedBy_ConnectUserArn;
            }
            if (requestUpdatedBy_updatedBy_ConnectUserArn != null)
            {
                request.UpdatedBy.ConnectUserArn = requestUpdatedBy_updatedBy_ConnectUserArn;
                requestUpdatedByIsNull = false;
            }
             // determine if request.UpdatedBy should be set to null
            if (requestUpdatedByIsNull)
            {
                request.UpdatedBy = null;
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
        
        private Amazon.Connect.Model.UpdateContactEvaluationResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateContactEvaluationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateContactEvaluation");
            try
            {
                return client.UpdateContactEvaluationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.Connect.Model.EvaluationAnswerInput> Answer { get; set; }
            public System.String EvaluationId { get; set; }
            public System.String InstanceId { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.EvaluationNote> Note { get; set; }
            public System.String UpdatedBy_ConnectUserArn { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateContactEvaluationResponse, UpdateCONNContactEvaluationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
