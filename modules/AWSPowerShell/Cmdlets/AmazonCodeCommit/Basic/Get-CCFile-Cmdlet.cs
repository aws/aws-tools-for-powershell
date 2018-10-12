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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Returns the base-64 encoded contents of a specified file and its metadata.
    /// </summary>
    [Cmdlet("Get", "CCFile")]
    [OutputType("Amazon.CodeCommit.Model.GetFileResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit GetFile API operation.", Operation = new[] {"GetFile"})]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.GetFileResponse",
        "This cmdlet returns a Amazon.CodeCommit.Model.GetFileResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCCFileCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter CommitSpecifier
        /// <summary>
        /// <para>
        /// <para>The fully-quaified reference that identifies the commit that contains the file. For
        /// example, you could specify a full commit ID, a tag, a branch name, or a reference
        /// such as refs/heads/master. If none is provided, then the head commit will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CommitSpecifier { get; set; }
        #endregion
        
        #region Parameter FilePath
        /// <summary>
        /// <para>
        /// <para>The fully-qualified path to the file, including the full name and extension of the
        /// file. For example, /examples/file.md is the fully-qualified path to a file named file.md
        /// in a folder named examples.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FilePath { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository that contains the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RepositoryName { get; set; }
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
            
            context.CommitSpecifier = this.CommitSpecifier;
            context.FilePath = this.FilePath;
            context.RepositoryName = this.RepositoryName;
            
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
            var request = new Amazon.CodeCommit.Model.GetFileRequest();
            
            if (cmdletContext.CommitSpecifier != null)
            {
                request.CommitSpecifier = cmdletContext.CommitSpecifier;
            }
            if (cmdletContext.FilePath != null)
            {
                request.FilePath = cmdletContext.FilePath;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
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
        
        private Amazon.CodeCommit.Model.GetFileResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.GetFileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "GetFile");
            try
            {
                #if DESKTOP
                return client.GetFile(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetFileAsync(request);
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
            public System.String CommitSpecifier { get; set; }
            public System.String FilePath { get; set; }
            public System.String RepositoryName { get; set; }
        }
        
    }
}
