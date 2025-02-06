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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Provides the response to a manual approval request to CodePipeline. Valid responses
    /// include Approved and Rejected.
    /// </summary>
    [Cmdlet("Write", "CPApprovalResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.DateTime")]
    [AWSCmdlet("Calls the AWS CodePipeline PutApprovalResult API operation.", Operation = new[] {"PutApprovalResult"}, SelectReturnType = typeof(Amazon.CodePipeline.Model.PutApprovalResultResponse))]
    [AWSCmdletOutput("System.DateTime or Amazon.CodePipeline.Model.PutApprovalResultResponse",
        "This cmdlet returns a System.DateTime object.",
        "The service call response (type Amazon.CodePipeline.Model.PutApprovalResultResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCPApprovalResultCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActionName
        /// <summary>
        /// <para>
        /// <para>The name of the action for which approval is requested.</para>
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
        public System.String ActionName { get; set; }
        #endregion
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline that contains the action. </para>
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
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name of the stage that contains the action.</para>
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
        public System.String StageName { get; set; }
        #endregion
        
        #region Parameter Result_Status
        /// <summary>
        /// <para>
        /// <para>The response submitted by a reviewer assigned to an approval action request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodePipeline.ApprovalStatus")]
        public Amazon.CodePipeline.ApprovalStatus Result_Status { get; set; }
        #endregion
        
        #region Parameter Result_Summary
        /// <summary>
        /// <para>
        /// <para>The summary of the current status of the approval request.</para>
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
        public System.String Result_Summary { get; set; }
        #endregion
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para>The system-generated token used to identify a unique approval request. The token for
        /// each open approval request can be obtained using the <a>GetPipelineState</a> action.
        /// It is used to validate that the approval request corresponding to this token is still
        /// valid.</para><important><para>For a pipeline where the execution mode is set to PARALLEL, the token required to
        /// approve/reject approval request as detailed above is not available. Instead, use the
        /// <c>externalExecutionId</c> from the <c>GetPipelineState</c> action as the token in
        /// the approval request.</para></important>
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
        public System.String Token { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApprovedAt'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodePipeline.Model.PutApprovalResultResponse).
        /// Specifying the name of a property of type Amazon.CodePipeline.Model.PutApprovalResultResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApprovedAt";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PipelineName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PipelineName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PipelineName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPApprovalResult (PutApprovalResult)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodePipeline.Model.PutApprovalResultResponse, WriteCPApprovalResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PipelineName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActionName = this.ActionName;
            #if MODULAR
            if (this.ActionName == null && ParameterWasBound(nameof(this.ActionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PipelineName = this.PipelineName;
            #if MODULAR
            if (this.PipelineName == null && ParameterWasBound(nameof(this.PipelineName)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Result_Status = this.Result_Status;
            #if MODULAR
            if (this.Result_Status == null && ParameterWasBound(nameof(this.Result_Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Result_Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Result_Summary = this.Result_Summary;
            #if MODULAR
            if (this.Result_Summary == null && ParameterWasBound(nameof(this.Result_Summary)))
            {
                WriteWarning("You are passing $null as a value for parameter Result_Summary which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StageName = this.StageName;
            #if MODULAR
            if (this.StageName == null && ParameterWasBound(nameof(this.StageName)))
            {
                WriteWarning("You are passing $null as a value for parameter StageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Token = this.Token;
            #if MODULAR
            if (this.Token == null && ParameterWasBound(nameof(this.Token)))
            {
                WriteWarning("You are passing $null as a value for parameter Token which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodePipeline.Model.PutApprovalResultRequest();
            
            if (cmdletContext.ActionName != null)
            {
                request.ActionName = cmdletContext.ActionName;
            }
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
            }
            
             // populate Result
            var requestResultIsNull = true;
            request.Result = new Amazon.CodePipeline.Model.ApprovalResult();
            Amazon.CodePipeline.ApprovalStatus requestResult_result_Status = null;
            if (cmdletContext.Result_Status != null)
            {
                requestResult_result_Status = cmdletContext.Result_Status;
            }
            if (requestResult_result_Status != null)
            {
                request.Result.Status = requestResult_result_Status;
                requestResultIsNull = false;
            }
            System.String requestResult_result_Summary = null;
            if (cmdletContext.Result_Summary != null)
            {
                requestResult_result_Summary = cmdletContext.Result_Summary;
            }
            if (requestResult_result_Summary != null)
            {
                request.Result.Summary = requestResult_result_Summary;
                requestResultIsNull = false;
            }
             // determine if request.Result should be set to null
            if (requestResultIsNull)
            {
                request.Result = null;
            }
            if (cmdletContext.StageName != null)
            {
                request.StageName = cmdletContext.StageName;
            }
            if (cmdletContext.Token != null)
            {
                request.Token = cmdletContext.Token;
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
        
        private Amazon.CodePipeline.Model.PutApprovalResultResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.PutApprovalResultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "PutApprovalResult");
            try
            {
                #if DESKTOP
                return client.PutApprovalResult(request);
                #elif CORECLR
                return client.PutApprovalResultAsync(request).GetAwaiter().GetResult();
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
            public System.String ActionName { get; set; }
            public System.String PipelineName { get; set; }
            public Amazon.CodePipeline.ApprovalStatus Result_Status { get; set; }
            public System.String Result_Summary { get; set; }
            public System.String StageName { get; set; }
            public System.String Token { get; set; }
            public System.Func<Amazon.CodePipeline.Model.PutApprovalResultResponse, WriteCPApprovalResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApprovedAt;
        }
        
    }
}
