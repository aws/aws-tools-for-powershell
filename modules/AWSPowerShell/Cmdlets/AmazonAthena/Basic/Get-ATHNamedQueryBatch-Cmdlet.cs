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
using Amazon.Athena;
using Amazon.Athena.Model;

namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Returns the details of a single named query or a list of up to 50 queries, which you
    /// provide as an array of query ID strings. Use <a>ListNamedQueries</a> to get the list
    /// of named query IDs. If information could not be retrieved for a submitted query ID,
    /// information about the query ID submitted is listed under <a>UnprocessedNamedQueryId</a>.
    /// Named queries are different from executed queries. Use <a>BatchGetQueryExecution</a>
    /// to get details about each unique query execution, and <a>ListQueryExecutions</a> to
    /// get a list of query execution IDs.
    /// </summary>
    [Cmdlet("Get", "ATHNamedQueryBatch")]
    [OutputType("Amazon.Athena.Model.BatchGetNamedQueryResponse")]
    [AWSCmdlet("Calls the Amazon Athena BatchGetNamedQuery API operation.", Operation = new[] {"BatchGetNamedQuery"})]
    [AWSCmdletOutput("Amazon.Athena.Model.BatchGetNamedQueryResponse",
        "This cmdlet returns a Amazon.Athena.Model.BatchGetNamedQueryResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetATHNamedQueryBatchCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        #region Parameter NamedQueryId
        /// <summary>
        /// <para>
        /// <para>An array of query IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("NamedQueryIds")]
        public System.String[] NamedQueryId { get; set; }
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
            
            if (this.NamedQueryId != null)
            {
                context.NamedQueryIds = new List<System.String>(this.NamedQueryId);
            }
            
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
            var request = new Amazon.Athena.Model.BatchGetNamedQueryRequest();
            
            if (cmdletContext.NamedQueryIds != null)
            {
                request.NamedQueryIds = cmdletContext.NamedQueryIds;
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
        
        private Amazon.Athena.Model.BatchGetNamedQueryResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.BatchGetNamedQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "BatchGetNamedQuery");
            try
            {
                #if DESKTOP
                return client.BatchGetNamedQuery(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.BatchGetNamedQueryAsync(request);
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
            public List<System.String> NamedQueryIds { get; set; }
        }
        
    }
}
