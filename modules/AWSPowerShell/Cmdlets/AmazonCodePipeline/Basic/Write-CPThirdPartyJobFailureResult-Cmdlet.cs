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
    /// Represents the failure of a third party job as returned to the pipeline by a job worker.
    /// Only used for partner actions.
    /// </summary>
    [Cmdlet("Write", "CPThirdPartyJobFailureResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutThirdPartyJobFailureResult operation against AWS CodePipeline.", Operation = new[] {"PutThirdPartyJobFailureResult"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the JobId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCPThirdPartyJobFailureResultCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The clientToken portion of the clientId and clientToken pair used to verify that the
        /// calling entity is allowed access to the job and its details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The external ID of the run of the action that failed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FailureDetails_ExternalExecutionId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the job that failed. This is the same ID returned from PollForThirdPartyJobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String JobId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The message about the failure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FailureDetails_Message { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The type of the failure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CodePipeline.FailureType FailureDetails_Type { get; set; }
        
        /// <summary>
        /// Returns the value passed to the JobId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPThirdPartyJobFailureResult (PutThirdPartyJobFailureResult)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClientToken = this.ClientToken;
            context.FailureDetails_ExternalExecutionId = this.FailureDetails_ExternalExecutionId;
            context.FailureDetails_Message = this.FailureDetails_Message;
            context.FailureDetails_Type = this.FailureDetails_Type;
            context.JobId = this.JobId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodePipeline.Model.PutThirdPartyJobFailureResultRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate FailureDetails
            bool requestFailureDetailsIsNull = true;
            request.FailureDetails = new Amazon.CodePipeline.Model.FailureDetails();
            System.String requestFailureDetails_failureDetails_ExternalExecutionId = null;
            if (cmdletContext.FailureDetails_ExternalExecutionId != null)
            {
                requestFailureDetails_failureDetails_ExternalExecutionId = cmdletContext.FailureDetails_ExternalExecutionId;
            }
            if (requestFailureDetails_failureDetails_ExternalExecutionId != null)
            {
                request.FailureDetails.ExternalExecutionId = requestFailureDetails_failureDetails_ExternalExecutionId;
                requestFailureDetailsIsNull = false;
            }
            System.String requestFailureDetails_failureDetails_Message = null;
            if (cmdletContext.FailureDetails_Message != null)
            {
                requestFailureDetails_failureDetails_Message = cmdletContext.FailureDetails_Message;
            }
            if (requestFailureDetails_failureDetails_Message != null)
            {
                request.FailureDetails.Message = requestFailureDetails_failureDetails_Message;
                requestFailureDetailsIsNull = false;
            }
            Amazon.CodePipeline.FailureType requestFailureDetails_failureDetails_Type = null;
            if (cmdletContext.FailureDetails_Type != null)
            {
                requestFailureDetails_failureDetails_Type = cmdletContext.FailureDetails_Type;
            }
            if (requestFailureDetails_failureDetails_Type != null)
            {
                request.FailureDetails.Type = requestFailureDetails_failureDetails_Type;
                requestFailureDetailsIsNull = false;
            }
             // determine if request.FailureDetails should be set to null
            if (requestFailureDetailsIsNull)
            {
                request.FailureDetails = null;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutThirdPartyJobFailureResult(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.JobId;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClientToken { get; set; }
            public System.String FailureDetails_ExternalExecutionId { get; set; }
            public System.String FailureDetails_Message { get; set; }
            public Amazon.CodePipeline.FailureType FailureDetails_Type { get; set; }
            public System.String JobId { get; set; }
        }
        
    }
}
