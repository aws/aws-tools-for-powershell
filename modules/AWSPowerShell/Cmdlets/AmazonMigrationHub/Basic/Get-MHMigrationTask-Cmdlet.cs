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
using Amazon.MigrationHub;
using Amazon.MigrationHub.Model;

namespace Amazon.PowerShell.Cmdlets.MH
{
    /// <summary>
    /// Retrieves a list of all attributes associated with a specific migration task.
    /// </summary>
    [Cmdlet("Get", "MHMigrationTask")]
    [OutputType("Amazon.MigrationHub.Model.MigrationTask")]
    [AWSCmdlet("Calls the AWS Migration Hub DescribeMigrationTask API operation.", Operation = new[] {"DescribeMigrationTask"})]
    [AWSCmdletOutput("Amazon.MigrationHub.Model.MigrationTask",
        "This cmdlet returns a MigrationTask object.",
        "The service call response (type Amazon.MigrationHub.Model.DescribeMigrationTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMHMigrationTaskCmdlet : AmazonMigrationHubClientCmdlet, IExecutor
    {
        
        #region Parameter MigrationTaskName
        /// <summary>
        /// <para>
        /// <para>The identifier given to the MigrationTask.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String MigrationTaskName { get; set; }
        #endregion
        
        #region Parameter ProgressUpdateStream
        /// <summary>
        /// <para>
        /// <para>The name of the ProgressUpdateStream. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProgressUpdateStream { get; set; }
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
            
            context.MigrationTaskName = this.MigrationTaskName;
            context.ProgressUpdateStream = this.ProgressUpdateStream;
            
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
            var request = new Amazon.MigrationHub.Model.DescribeMigrationTaskRequest();
            
            if (cmdletContext.MigrationTaskName != null)
            {
                request.MigrationTaskName = cmdletContext.MigrationTaskName;
            }
            if (cmdletContext.ProgressUpdateStream != null)
            {
                request.ProgressUpdateStream = cmdletContext.ProgressUpdateStream;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.MigrationTask;
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
        
        private Amazon.MigrationHub.Model.DescribeMigrationTaskResponse CallAWSServiceOperation(IAmazonMigrationHub client, Amazon.MigrationHub.Model.DescribeMigrationTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub", "DescribeMigrationTask");
            try
            {
                #if DESKTOP
                return client.DescribeMigrationTask(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeMigrationTaskAsync(request);
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
            public System.String MigrationTaskName { get; set; }
            public System.String ProgressUpdateStream { get; set; }
        }
        
    }
}
