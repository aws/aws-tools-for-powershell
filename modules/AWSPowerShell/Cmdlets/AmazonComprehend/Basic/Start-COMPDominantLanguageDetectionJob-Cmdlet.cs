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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Starts an asynchronous dominant language detection job for a collection of documents.
    /// Use the operation to track the status of a job.
    /// </summary>
    [Cmdlet("Start", "COMPDominantLanguageDetectionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Comprehend.Model.StartDominantLanguageDetectionJobResponse")]
    [AWSCmdlet("Calls the Amazon Comprehend StartDominantLanguageDetectionJob API operation.", Operation = new[] {"StartDominantLanguageDetectionJob"})]
    [AWSCmdletOutput("Amazon.Comprehend.Model.StartDominantLanguageDetectionJobResponse",
        "This cmdlet returns a Amazon.Comprehend.Model.StartDominantLanguageDetectionJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCOMPDominantLanguageDetectionJobCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the request. If you do not set the client request token, Amazon
        /// Comprehend generates one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Access Management (IAM) role
        /// that grants Amazon Comprehend read access to your input data. For more information,
        /// see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/access-control-managing-permissions.html#auth-role-permissions">https://docs.aws.amazon.com/comprehend/latest/dg/access-control-managing-permissions.html#auth-role-permissions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter InputDataConfig
        /// <summary>
        /// <para>
        /// <para>Specifies the format and location of the input data for the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public Amazon.Comprehend.Model.InputDataConfig InputDataConfig { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>An identifier for the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig
        /// <summary>
        /// <para>
        /// <para>Specifies where to send the output files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Comprehend.Model.OutputDataConfig OutputDataConfig { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-COMPDominantLanguageDetectionJob (StartDominantLanguageDetectionJob)"))
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
            
            context.ClientRequestToken = this.ClientRequestToken;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            context.InputDataConfig = this.InputDataConfig;
            context.JobName = this.JobName;
            context.OutputDataConfig = this.OutputDataConfig;
            
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
            var request = new Amazon.Comprehend.Model.StartDominantLanguageDetectionJobRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            if (cmdletContext.InputDataConfig != null)
            {
                request.InputDataConfig = cmdletContext.InputDataConfig;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.OutputDataConfig != null)
            {
                request.OutputDataConfig = cmdletContext.OutputDataConfig;
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
        
        private Amazon.Comprehend.Model.StartDominantLanguageDetectionJobResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.StartDominantLanguageDetectionJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "StartDominantLanguageDetectionJob");
            try
            {
                #if DESKTOP
                return client.StartDominantLanguageDetectionJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartDominantLanguageDetectionJobAsync(request);
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
            public System.String ClientRequestToken { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public Amazon.Comprehend.Model.InputDataConfig InputDataConfig { get; set; }
            public System.String JobName { get; set; }
            public Amazon.Comprehend.Model.OutputDataConfig OutputDataConfig { get; set; }
        }
        
    }
}
