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
using Amazon.MigrationHub;
using Amazon.MigrationHub.Model;

namespace Amazon.PowerShell.Cmdlets.MH
{
    /// <summary>
    /// Deletes a progress update stream, including all of its tasks, which was previously
    /// created as an AWS resource used for access control. This API has the following traits:
    /// 
    ///  <ul><li><para>
    /// The only parameter needed for <code>DeleteProgressUpdateStream</code> is the stream
    /// name (same as a <code>CreateProgressUpdateStream</code> call).
    /// </para></li><li><para>
    /// The call will return, and a background process will asynchronously delete the stream
    /// and all of its resources (tasks, associated resources, resource attributes, created
    /// artifacts).
    /// </para></li><li><para>
    /// If the stream takes time to be deleted, it might still show up on a <code>ListProgressUpdateStreams</code>
    /// call.
    /// </para></li><li><para><code>CreateProgressUpdateStream</code>, <code>ImportMigrationTask</code>, <code>NotifyMigrationTaskState</code>,
    /// and all Associate[*] APIs realted to the tasks belonging to the stream will throw
    /// "InvalidInputException" if the stream of the same name is in the process of being
    /// deleted.
    /// </para></li><li><para>
    /// Once the stream and all of its resources are deleted, <code>CreateProgressUpdateStream</code>
    /// for a stream of the same name will succeed, and that stream will be an entirely new
    /// logical resource (without any resources associated with the old stream).
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "MHProgressUpdateStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Migration Hub DeleteProgressUpdateStream API operation.", Operation = new[] {"DeleteProgressUpdateStream"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ProgressUpdateStreamName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.MigrationHub.Model.DeleteProgressUpdateStreamResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveMHProgressUpdateStreamCmdlet : AmazonMigrationHubClientCmdlet, IExecutor
    {
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Optional boolean flag to indicate whether any effect should take place. Used to test
        /// if the caller has permission to make the call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DryRun { get; set; }
        #endregion
        
        #region Parameter ProgressUpdateStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the ProgressUpdateStream. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ProgressUpdateStreamName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ProgressUpdateStreamName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ProgressUpdateStreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-MHProgressUpdateStream (DeleteProgressUpdateStream)"))
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
            
            if (ParameterWasBound("DryRun"))
                context.DryRun = this.DryRun;
            context.ProgressUpdateStreamName = this.ProgressUpdateStreamName;
            
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
            var request = new Amazon.MigrationHub.Model.DeleteProgressUpdateStreamRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.ProgressUpdateStreamName != null)
            {
                request.ProgressUpdateStreamName = cmdletContext.ProgressUpdateStreamName;
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
                    pipelineOutput = this.ProgressUpdateStreamName;
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
        
        private Amazon.MigrationHub.Model.DeleteProgressUpdateStreamResponse CallAWSServiceOperation(IAmazonMigrationHub client, Amazon.MigrationHub.Model.DeleteProgressUpdateStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub", "DeleteProgressUpdateStream");
            try
            {
                #if DESKTOP
                return client.DeleteProgressUpdateStream(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteProgressUpdateStreamAsync(request);
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
            public System.Boolean? DryRun { get; set; }
            public System.String ProgressUpdateStreamName { get; set; }
        }
        
    }
}
