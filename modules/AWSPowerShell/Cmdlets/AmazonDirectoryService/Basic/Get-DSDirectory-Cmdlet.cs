/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Obtains information about the directories that belong to this account.
    /// 
    ///  
    /// <para>
    /// You can retrieve information about specific directories by passing the directory identifiers
    /// in the <i>DirectoryIds</i> parameter. Otherwise, all directories that belong to the
    /// current account are returned.
    /// </para><para>
    /// This operation supports pagination with the use of the <i>NextToken</i> request and
    /// response parameters. If more results are available, the <i>DescribeDirectoriesResult.NextToken</i>
    /// member contains a token that you pass in the next call to <a>DescribeDirectories</a>
    /// to retrieve the next set of items.
    /// </para><para>
    /// You can also specify a maximum number of return results with the <i>Limit</i> parameter.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DSDirectory")]
    [OutputType("Amazon.DirectoryService.Model.DirectoryDescription")]
    [AWSCmdlet("Invokes the DescribeDirectories operation against AWS Directory Service.", Operation = new[] {"DescribeDirectories"})]
    [AWSCmdletOutput("Amazon.DirectoryService.Model.DirectoryDescription",
        "This cmdlet returns a collection of DirectoryDescription objects.",
        "The service call response (type DescribeDirectoriesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetDSDirectoryCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A list of identifiers of the directories to obtain the information for. If this member
        /// is null, all directories that belong to the current account are returned.</para><para>An empty list results in an <code>InvalidParameterException</code> being thrown.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("DirectoryIds")]
        public System.String[] DirectoryId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return. If this value is zero, the maximum number of
        /// items is specified by the limitations of the operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Limit { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <i>DescribeDirectoriesResult.NextToken</i> value from a previous call to <a>DescribeDirectories</a>.
        /// Pass null if this is the first call.</para>
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
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeDirectoriesRequest();
            
            if (cmdletContext.DirectoryIds != null)
            {
                request.DirectoryIds = cmdletContext.DirectoryIds;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
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
                var response = client.DescribeDirectories(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DirectoryDescriptions;
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
            public Int32? Limit { get; set; }
            public String NextToken { get; set; }
        }
        
    }
}
