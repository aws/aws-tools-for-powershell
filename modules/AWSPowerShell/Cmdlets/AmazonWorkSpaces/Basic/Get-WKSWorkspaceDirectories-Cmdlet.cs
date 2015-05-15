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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Retrieves information about the AWS Directory Service directories in the region that
    /// are registered with Amazon WorkSpaces and are available to your account.
    /// 
    ///  
    /// <para>
    /// This operation supports pagination with the use of the <code>NextToken</code> request
    /// and response parameters. If more results are available, the <code>NextToken</code>
    /// response member contains a token that you pass in the next call to this operation
    /// to retrieve the next set of items.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "WKSWorkspaceDirectories")]
    [OutputType("Amazon.WorkSpaces.Model.WorkspaceDirectory")]
    [AWSCmdlet("Invokes the DescribeWorkspaceDirectories operation against Amazon WorkSpaces.", Operation = new[] {"DescribeWorkspaceDirectories"})]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.WorkspaceDirectory",
        "This cmdlet returns a collection of WorkspaceDirectory objects.",
        "The service call response (type DescribeWorkspaceDirectoriesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetWKSWorkspaceDirectoriesCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>An array of strings that contains the directory identifiers to retrieve information
        /// for. If this member is null, all directories are retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("DirectoryIds")]
        public System.String[] DirectoryId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <code>NextToken</code> value from a previous call to this operation. Pass null
        /// if this is the first call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.DirectoryId != null)
            {
                context.DirectoryIds = new List<String>(this.DirectoryId);
            }
            context.NextToken = this.NextToken;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeWorkspaceDirectoriesRequest();
            
            if (cmdletContext.DirectoryIds != null)
            {
                request.DirectoryIds = cmdletContext.DirectoryIds;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeWorkspaceDirectories(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Directories;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
            public List<String> DirectoryIds { get; set; }
            public String NextToken { get; set; }
        }
        
    }
}
