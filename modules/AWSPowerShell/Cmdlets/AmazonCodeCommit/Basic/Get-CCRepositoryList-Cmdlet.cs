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
    /// </summary>
    [Cmdlet("Get", "CCRepositoryList")]
    [OutputType("Amazon.CodeCommit.Model.RepositoryNameIdPair")]
    [AWSCmdlet("Invokes the ListRepositories operation against AWS CodeCommit.", Operation = new[] {"ListRepositories"})]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.RepositoryNameIdPair",
        "This cmdlet returns a collection of RepositoryNameIdPair objects.",
        "The service call response (type Amazon.CodeCommit.Model.ListRepositoriesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetCCRepositoryListCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The order in which to sort the results of a list repositories operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CodeCommit.OrderEnum Order { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The criteria used to sort the results of a list repositories operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CodeCommit.SortByEnum SortBy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An enumeration token that allows the operation to batch the results of the operation.
        /// Batch sizes are 1,000 for list repository operations. When the client sends the token
        /// back to AWS CodeCommit, another page of 1,000 records is retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.NextToken = this.NextToken;
            context.Order = this.Order;
            context.SortBy = this.SortBy;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodeCommit.Model.ListRepositoriesRequest();
            
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Order != null)
            {
                request.Order = cmdletContext.Order;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListRepositories(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Repositories;
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
            public System.String NextToken { get; set; }
            public Amazon.CodeCommit.OrderEnum Order { get; set; }
            public Amazon.CodeCommit.SortByEnum SortBy { get; set; }
        }
        
    }
}
