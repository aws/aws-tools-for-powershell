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
    /// Returns the details of a single query execution or a list of up to 50 query executions,
    /// which you provide as an array of query execution ID strings. Requires you to have
    /// access to the workgroup in which the queries ran. To get a list of query execution
    /// IDs, use <a>ListQueryExecutionsInput$WorkGroup</a>. Query executions differ from named
    /// (saved) queries. Use <a>BatchGetNamedQueryInput</a> to get details about named queries.
    /// </summary>
    [Cmdlet("Get", "ATHQueryExecutionBatch")]
    [OutputType("Amazon.Athena.Model.BatchGetQueryExecutionResponse")]
    [AWSCmdlet("Calls the Amazon Athena BatchGetQueryExecution API operation.", Operation = new[] {"BatchGetQueryExecution"})]
    [AWSCmdletOutput("Amazon.Athena.Model.BatchGetQueryExecutionResponse",
        "This cmdlet returns a Amazon.Athena.Model.BatchGetQueryExecutionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetATHQueryExecutionBatchCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        #region Parameter QueryExecutionId
        /// <summary>
        /// <para>
        /// <para>An array of query execution IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("QueryExecutionIds")]
        public System.String[] QueryExecutionId { get; set; }
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
            
            if (this.QueryExecutionId != null)
            {
                context.QueryExecutionIds = new List<System.String>(this.QueryExecutionId);
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
            var request = new Amazon.Athena.Model.BatchGetQueryExecutionRequest();
            
            if (cmdletContext.QueryExecutionIds != null)
            {
                request.QueryExecutionIds = cmdletContext.QueryExecutionIds;
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
        
        private Amazon.Athena.Model.BatchGetQueryExecutionResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.BatchGetQueryExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "BatchGetQueryExecution");
            try
            {
                #if DESKTOP
                return client.BatchGetQueryExecution(request);
                #elif CORECLR
                return client.BatchGetQueryExecutionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> QueryExecutionIds { get; set; }
        }
        
    }
}
