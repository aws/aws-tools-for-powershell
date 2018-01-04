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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Provides information to AWS CodePipeline about new revisions to a source.
    /// </summary>
    [Cmdlet("Write", "CPActionRevision", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodePipeline.Model.PutActionRevisionResponse")]
    [AWSCmdlet("Calls the AWS CodePipeline PutActionRevision API operation.", Operation = new[] {"PutActionRevision"})]
    [AWSCmdletOutput("Amazon.CodePipeline.Model.PutActionRevisionResponse",
        "This cmdlet returns a Amazon.CodePipeline.Model.PutActionRevisionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCPActionRevisionCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        #region Parameter ActionName
        /// <summary>
        /// <para>
        /// <para>The name of the action that will process the revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ActionName { get; set; }
        #endregion
        
        #region Parameter ActionRevision_Created
        /// <summary>
        /// <para>
        /// <para>The date and time when the most recent version of the action was created, in timestamp
        /// format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ActionRevision_Created { get; set; }
        #endregion
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline that will start processing the revision to the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter ActionRevision_RevisionChangeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the change that set the state to this revision, for example
        /// a deployment ID or timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ActionRevision_RevisionChangeId { get; set; }
        #endregion
        
        #region Parameter ActionRevision_RevisionId
        /// <summary>
        /// <para>
        /// <para>The system-generated unique ID that identifies the revision number of the action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ActionRevision_RevisionId { get; set; }
        #endregion
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name of the stage that contains the action that will act upon the revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StageName { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPActionRevision (PutActionRevision)"))
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
            if (ParameterWasBound("ActionRevision_Created"))
                context.ActionRevision_Created = this.ActionRevision_Created;
            context.ActionRevision_RevisionChangeId = this.ActionRevision_RevisionChangeId;
            context.ActionRevision_RevisionId = this.ActionRevision_RevisionId;
            context.PipelineName = this.PipelineName;
            context.StageName = this.StageName;
            
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
            var request = new Amazon.CodePipeline.Model.PutActionRevisionRequest();
            
            if (cmdletContext.ActionName != null)
            {
                request.ActionName = cmdletContext.ActionName;
            }
            
             // populate ActionRevision
            bool requestActionRevisionIsNull = true;
            request.ActionRevision = new Amazon.CodePipeline.Model.ActionRevision();
            System.DateTime? requestActionRevision_actionRevision_Created = null;
            if (cmdletContext.ActionRevision_Created != null)
            {
                requestActionRevision_actionRevision_Created = cmdletContext.ActionRevision_Created.Value;
            }
            if (requestActionRevision_actionRevision_Created != null)
            {
                request.ActionRevision.Created = requestActionRevision_actionRevision_Created.Value;
                requestActionRevisionIsNull = false;
            }
            System.String requestActionRevision_actionRevision_RevisionChangeId = null;
            if (cmdletContext.ActionRevision_RevisionChangeId != null)
            {
                requestActionRevision_actionRevision_RevisionChangeId = cmdletContext.ActionRevision_RevisionChangeId;
            }
            if (requestActionRevision_actionRevision_RevisionChangeId != null)
            {
                request.ActionRevision.RevisionChangeId = requestActionRevision_actionRevision_RevisionChangeId;
                requestActionRevisionIsNull = false;
            }
            System.String requestActionRevision_actionRevision_RevisionId = null;
            if (cmdletContext.ActionRevision_RevisionId != null)
            {
                requestActionRevision_actionRevision_RevisionId = cmdletContext.ActionRevision_RevisionId;
            }
            if (requestActionRevision_actionRevision_RevisionId != null)
            {
                request.ActionRevision.RevisionId = requestActionRevision_actionRevision_RevisionId;
                requestActionRevisionIsNull = false;
            }
             // determine if request.ActionRevision should be set to null
            if (requestActionRevisionIsNull)
            {
                request.ActionRevision = null;
            }
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
            }
            if (cmdletContext.StageName != null)
            {
                request.StageName = cmdletContext.StageName;
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
        
        private Amazon.CodePipeline.Model.PutActionRevisionResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.PutActionRevisionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "PutActionRevision");
            try
            {
                #if DESKTOP
                return client.PutActionRevision(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutActionRevisionAsync(request);
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
            public System.DateTime? ActionRevision_Created { get; set; }
            public System.String ActionRevision_RevisionChangeId { get; set; }
            public System.String ActionRevision_RevisionId { get; set; }
            public System.String PipelineName { get; set; }
            public System.String StageName { get; set; }
        }
        
    }
}
