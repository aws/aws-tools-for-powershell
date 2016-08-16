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
    /// Represents the failure of a job as returned to the pipeline by a job worker. Only
    /// used for custom actions.
    /// </summary>
    [Cmdlet("Write", "CPJobFailureResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutJobFailureResult operation against AWS CodePipeline.", Operation = new[] {"PutJobFailureResult"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the JobId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CodePipeline.Model.PutJobFailureResultResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCPJobFailureResultCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        #region Parameter FailureDetails_ExternalExecutionId
        /// <summary>
        /// <para>
        /// <para>The external ID of the run of the action that failed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FailureDetails_ExternalExecutionId { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The unique system-generated ID of the job that failed. This is the same ID returned
        /// from PollForJobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter FailureDetails_Message
        /// <summary>
        /// <para>
        /// <para>The message about the failure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FailureDetails_Message { get; set; }
        #endregion
        
        #region Parameter FailureDetails_Type
        /// <summary>
        /// <para>
        /// <para>The type of the failure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodePipeline.FailureType")]
        public Amazon.CodePipeline.FailureType FailureDetails_Type { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the JobId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPJobFailureResult (PutJobFailureResult)"))
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
            
            context.FailureDetails_ExternalExecutionId = this.FailureDetails_ExternalExecutionId;
            context.FailureDetails_Message = this.FailureDetails_Message;
            context.FailureDetails_Type = this.FailureDetails_Type;
            context.JobId = this.JobId;
            
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
            var request = new Amazon.CodePipeline.Model.PutJobFailureResultRequest();
            
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.CodePipeline.Model.PutJobFailureResultResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.PutJobFailureResultRequest request)
        {
            #if DESKTOP
            return client.PutJobFailureResult(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutJobFailureResultAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String FailureDetails_ExternalExecutionId { get; set; }
            public System.String FailureDetails_Message { get; set; }
            public Amazon.CodePipeline.FailureType FailureDetails_Type { get; set; }
            public System.String JobId { get; set; }
        }
        
    }
}
