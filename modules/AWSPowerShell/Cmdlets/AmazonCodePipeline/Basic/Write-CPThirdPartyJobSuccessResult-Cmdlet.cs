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
    /// Represents the success of a third party job as returned to the pipeline by a job worker.
    /// Only used for partner actions.
    /// </summary>
    [Cmdlet("Write", "CPThirdPartyJobSuccessResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutThirdPartyJobSuccessResult operation against AWS CodePipeline.", Operation = new[] {"PutThirdPartyJobSuccessResult"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the JobId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CodePipeline.Model.PutThirdPartyJobSuccessResultResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCPThirdPartyJobSuccessResultCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The change identifier for the current revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CurrentRevision_ChangeIdentifier { get; set; }
        
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
        /// <para>A system-generated token, such as a AWS CodeDeploy deployment ID, that a job uses
        /// in order to continue the job asynchronously.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContinuationToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The system-generated unique ID of this action used to identify this job worker in
        /// any external systems, such as AWS CodeDeploy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExecutionDetails_ExternalExecutionId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the job that successfully completed. This is the same ID returned from PollForThirdPartyJobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String JobId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The percentage of work completed on the action, represented on a scale of zero to
        /// one hundred percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ExecutionDetails_PercentComplete { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The revision ID of the current version of an artifact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CurrentRevision_Revision { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The summary of the current status of the actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExecutionDetails_Summary { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPThirdPartyJobSuccessResult (PutThirdPartyJobSuccessResult)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClientToken = this.ClientToken;
            context.ContinuationToken = this.ContinuationToken;
            context.CurrentRevision_ChangeIdentifier = this.CurrentRevision_ChangeIdentifier;
            context.CurrentRevision_Revision = this.CurrentRevision_Revision;
            context.ExecutionDetails_ExternalExecutionId = this.ExecutionDetails_ExternalExecutionId;
            if (ParameterWasBound("ExecutionDetails_PercentComplete"))
                context.ExecutionDetails_PercentComplete = this.ExecutionDetails_PercentComplete;
            context.ExecutionDetails_Summary = this.ExecutionDetails_Summary;
            context.JobId = this.JobId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodePipeline.Model.PutThirdPartyJobSuccessResultRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContinuationToken != null)
            {
                request.ContinuationToken = cmdletContext.ContinuationToken;
            }
            
             // populate CurrentRevision
            bool requestCurrentRevisionIsNull = true;
            request.CurrentRevision = new Amazon.CodePipeline.Model.CurrentRevision();
            System.String requestCurrentRevision_currentRevision_ChangeIdentifier = null;
            if (cmdletContext.CurrentRevision_ChangeIdentifier != null)
            {
                requestCurrentRevision_currentRevision_ChangeIdentifier = cmdletContext.CurrentRevision_ChangeIdentifier;
            }
            if (requestCurrentRevision_currentRevision_ChangeIdentifier != null)
            {
                request.CurrentRevision.ChangeIdentifier = requestCurrentRevision_currentRevision_ChangeIdentifier;
                requestCurrentRevisionIsNull = false;
            }
            System.String requestCurrentRevision_currentRevision_Revision = null;
            if (cmdletContext.CurrentRevision_Revision != null)
            {
                requestCurrentRevision_currentRevision_Revision = cmdletContext.CurrentRevision_Revision;
            }
            if (requestCurrentRevision_currentRevision_Revision != null)
            {
                request.CurrentRevision.Revision = requestCurrentRevision_currentRevision_Revision;
                requestCurrentRevisionIsNull = false;
            }
             // determine if request.CurrentRevision should be set to null
            if (requestCurrentRevisionIsNull)
            {
                request.CurrentRevision = null;
            }
            
             // populate ExecutionDetails
            bool requestExecutionDetailsIsNull = true;
            request.ExecutionDetails = new Amazon.CodePipeline.Model.ExecutionDetails();
            System.String requestExecutionDetails_executionDetails_ExternalExecutionId = null;
            if (cmdletContext.ExecutionDetails_ExternalExecutionId != null)
            {
                requestExecutionDetails_executionDetails_ExternalExecutionId = cmdletContext.ExecutionDetails_ExternalExecutionId;
            }
            if (requestExecutionDetails_executionDetails_ExternalExecutionId != null)
            {
                request.ExecutionDetails.ExternalExecutionId = requestExecutionDetails_executionDetails_ExternalExecutionId;
                requestExecutionDetailsIsNull = false;
            }
            System.Int32? requestExecutionDetails_executionDetails_PercentComplete = null;
            if (cmdletContext.ExecutionDetails_PercentComplete != null)
            {
                requestExecutionDetails_executionDetails_PercentComplete = cmdletContext.ExecutionDetails_PercentComplete.Value;
            }
            if (requestExecutionDetails_executionDetails_PercentComplete != null)
            {
                request.ExecutionDetails.PercentComplete = requestExecutionDetails_executionDetails_PercentComplete.Value;
                requestExecutionDetailsIsNull = false;
            }
            System.String requestExecutionDetails_executionDetails_Summary = null;
            if (cmdletContext.ExecutionDetails_Summary != null)
            {
                requestExecutionDetails_executionDetails_Summary = cmdletContext.ExecutionDetails_Summary;
            }
            if (requestExecutionDetails_executionDetails_Summary != null)
            {
                request.ExecutionDetails.Summary = requestExecutionDetails_executionDetails_Summary;
                requestExecutionDetailsIsNull = false;
            }
             // determine if request.ExecutionDetails should be set to null
            if (requestExecutionDetailsIsNull)
            {
                request.ExecutionDetails = null;
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
                var response = client.PutThirdPartyJobSuccessResult(request);
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
            public System.String ContinuationToken { get; set; }
            public System.String CurrentRevision_ChangeIdentifier { get; set; }
            public System.String CurrentRevision_Revision { get; set; }
            public System.String ExecutionDetails_ExternalExecutionId { get; set; }
            public System.Int32? ExecutionDetails_PercentComplete { get; set; }
            public System.String ExecutionDetails_Summary { get; set; }
            public System.String JobId { get; set; }
        }
        
    }
}
