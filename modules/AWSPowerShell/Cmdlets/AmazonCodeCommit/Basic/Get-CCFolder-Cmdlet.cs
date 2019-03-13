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
    /// Returns the contents of a specified folder in a repository.
    /// </summary>
    [Cmdlet("Get", "CCFolder")]
    [OutputType("Amazon.CodeCommit.Model.GetFolderResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit GetFolder API operation.", Operation = new[] {"GetFolder"})]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.GetFolderResponse",
        "This cmdlet returns a Amazon.CodeCommit.Model.GetFolderResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCCFolderCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter CommitSpecifier
        /// <summary>
        /// <para>
        /// <para>A fully-qualified reference used to identify a commit that contains the version of
        /// the folder's content to return. A fully-qualified reference can be a commit ID, branch
        /// name, tag, or reference such as HEAD. If no specifier is provided, the folder content
        /// will be returned as it exists in the HEAD commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CommitSpecifier { get; set; }
        #endregion
        
        #region Parameter FolderPath
        /// <summary>
        /// <para>
        /// <para>The fully-qualified path to the folder whose contents will be returned, including
        /// the folder name. For example, /examples is a fully-qualified path to a folder named
        /// examples that was created off of the root directory (/) of a repository. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FolderPath { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository.</para>
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
            context.FolderPath = this.FolderPath;
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
            var request = new Amazon.CodeCommit.Model.GetFolderRequest();
            
            if (cmdletContext.CommitSpecifier != null)
            {
                request.CommitSpecifier = cmdletContext.CommitSpecifier;
            }
            if (cmdletContext.FolderPath != null)
            {
                request.FolderPath = cmdletContext.FolderPath;
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
        
        private Amazon.CodeCommit.Model.GetFolderResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.GetFolderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "GetFolder");
            try
            {
                #if DESKTOP
                return client.GetFolder(request);
                #elif CORECLR
                return client.GetFolderAsync(request).GetAwaiter().GetResult();
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
            public System.String FolderPath { get; set; }
            public System.String RepositoryName { get; set; }
        }
        
    }
}
