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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Gets information about one or more repositories.
    /// 
    ///  <note><para>
    /// The description field for a repository accepts all HTML characters and all valid Unicode
    /// characters. Applications that do not HTML-encode the description and display it in
    /// a web page could expose users to potentially malicious code. Make sure that you HTML-encode
    /// the description field in any application that uses this API to display the repository
    /// description on a web page.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CCRepositoryBatch")]
    [OutputType("Amazon.CodeCommit.Model.BatchGetRepositoriesResponse")]
    [AWSCmdlet("Invokes the BatchGetRepositories operation against AWS CodeCommit.", Operation = new[] {"BatchGetRepositories"})]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.BatchGetRepositoriesResponse",
        "This cmdlet returns a Amazon.CodeCommit.Model.BatchGetRepositoriesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCCRepositoryBatchCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The names of the repositories to get information about.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("RepositoryNames")]
        public System.String[] RepositoryName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.RepositoryName != null)
            {
                context.RepositoryNames = new List<System.String>(this.RepositoryName);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodeCommit.Model.BatchGetRepositoriesRequest();
            
            if (cmdletContext.RepositoryNames != null)
            {
                request.RepositoryNames = cmdletContext.RepositoryNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.BatchGetRepositories(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> RepositoryNames { get; set; }
        }
        
    }
}
