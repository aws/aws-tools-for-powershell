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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <code>GetFileUploadURL</code> operation generates and returns a temporary URL.
    /// You use the temporary URL to retrieve a file uploaded by a Worker as an answer to
    /// a FileUploadAnswer question for a HIT. The temporary URL is generated the instant
    /// the GetFileUploadURL operation is called, and is valid for 60 seconds. You can get
    /// a temporary file upload URL any time until the HIT is disposed. After the HIT is disposed,
    /// any uploaded files are deleted, and cannot be retrieved.
    /// </summary>
    [Cmdlet("Get", "MTRFileUploadURL")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon MTurk Service GetFileUploadURL API operation.", Operation = new[] {"GetFileUploadURL"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.MTurk.Model.GetFileUploadURLResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMTRFileUploadURLCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter AssignmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the assignment that contains the question with a FileUploadAnswer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AssignmentId { get; set; }
        #endregion
        
        #region Parameter QuestionIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the question with a FileUploadAnswer, as specified in the QuestionForm
        /// of the HIT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String QuestionIdentifier { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AssignmentId = this.AssignmentId;
            context.QuestionIdentifier = this.QuestionIdentifier;
            
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
            var request = new Amazon.MTurk.Model.GetFileUploadURLRequest();
            
            if (cmdletContext.AssignmentId != null)
            {
                request.AssignmentId = cmdletContext.AssignmentId;
            }
            if (cmdletContext.QuestionIdentifier != null)
            {
                request.QuestionIdentifier = cmdletContext.QuestionIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FileUploadURL;
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
        
        private Amazon.MTurk.Model.GetFileUploadURLResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.GetFileUploadURLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "GetFileUploadURL");
            try
            {
                #if DESKTOP
                return client.GetFileUploadURL(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetFileUploadURLAsync(request);
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
            public System.String AssignmentId { get; set; }
            public System.String QuestionIdentifier { get; set; }
        }
        
    }
}
