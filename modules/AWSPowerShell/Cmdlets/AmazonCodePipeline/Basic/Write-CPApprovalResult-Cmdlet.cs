/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Provides the response to a manual approval request to AWS CodePipeline. Valid responses
    /// include Approved and Rejected.
    /// </summary>
    [Cmdlet("Write", "CPApprovalResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.DateTime")]
    [AWSCmdlet("Calls the AWS CodePipeline PutApprovalResult API operation.", Operation = new[] {"PutApprovalResult"})]
    [AWSCmdletOutput("System.DateTime",
        "This cmdlet returns a DateTime object.",
        "The service call response (type Amazon.CodePipeline.Model.PutApprovalResultResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCPApprovalResultCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        #region Parameter ActionName
        /// <summary>
        /// <para>
        /// <para>The name of the action for which approval is requested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ActionName { get; set; }
        #endregion
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline that contains the action. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name of the stage that contains the action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StageName { get; set; }
        #endregion
        
        #region Parameter Result_Status
        /// <summary>
        /// <para>
        /// <para>The response submitted by a reviewer assigned to an approval action request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodePipeline.ApprovalStatus")]
        public Amazon.CodePipeline.ApprovalStatus Result_Status { get; set; }
        #endregion
        
        #region Parameter Result_Summary
        /// <summary>
        /// <para>
        /// <para>The summary of the current status of the approval request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Result_Summary { get; set; }
        #endregion
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para>The system-generated token used to identify a unique approval request. The token for
        /// each open approval request can be obtained using the <a>GetPipelineState</a> action
        /// and is used to validate that the approval request corresponding to this token is still
        /// valid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Token { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ActionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPApprovalResult (PutApprovalResult)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ActionName = this.ActionName;
            context.PipelineName = this.PipelineName;
            context.Result_Status = this.Result_Status;
            context.Result_Summary = this.Result_Summary;
            context.StageName = this.StageName;
            context.Token = this.Token;
            
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
            bool requestResultIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ApprovedAt;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutApprovalResultAsync(request);
                return task.Result;
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
        }
        
    }
}
