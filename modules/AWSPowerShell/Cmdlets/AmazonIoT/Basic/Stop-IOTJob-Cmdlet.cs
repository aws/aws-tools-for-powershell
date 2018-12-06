/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Cancels a job.
    /// </summary>
    [Cmdlet("Stop", "IOTJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CancelJobResponse")]
    [AWSCmdlet("Calls the AWS IoT CancelJob API operation.", Operation = new[] {"CancelJob"})]
    [AWSCmdletOutput("Amazon.IoT.Model.CancelJobResponse",
        "This cmdlet returns a Amazon.IoT.Model.CancelJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StopIOTJobCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>An optional comment string describing why the job was canceled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter Enforce
        /// <summary>
        /// <para>
        /// <para>(Optional) If <code>true</code> job executions with status "IN_PROGRESS" and "QUEUED"
        /// are canceled, otherwise only job executions with status "QUEUED" are canceled. The
        /// default is <code>false</code>.</para><para>Canceling a job which is "IN_PROGRESS", will cause a device which is executing the
        /// job to be unable to update the job execution status. Use caution and ensure that each
        /// device executing a job which is canceled is able to recover to a valid state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Enforce { get; set; }
        #endregion
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The unique identifier you assigned to this job when it was created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter ReasonCode
        /// <summary>
        /// <para>
        /// <para>(Optional)A reason code string that explains why the job was canceled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReasonCode { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-IOTJob (CancelJob)"))
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
            
            context.Comment = this.Comment;
            if (ParameterWasBound("Enforce"))
                context.Enforce = this.Enforce;
            context.JobId = this.JobId;
            context.ReasonCode = this.ReasonCode;
            
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
            var request = new Amazon.IoT.Model.CancelJobRequest();
            
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.Enforce != null)
            {
                request.Force = cmdletContext.Enforce.Value;
            }
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
            }
            if (cmdletContext.ReasonCode != null)
            {
                request.ReasonCode = cmdletContext.ReasonCode;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.IoT.Model.CancelJobResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CancelJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CancelJob");
            try
            {
                #if DESKTOP
                return client.CancelJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CancelJobAsync(request);
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
            public System.String Comment { get; set; }
            public System.Boolean? Enforce { get; set; }
            public System.String JobId { get; set; }
            public System.String ReasonCode { get; set; }
        }
        
    }
}
