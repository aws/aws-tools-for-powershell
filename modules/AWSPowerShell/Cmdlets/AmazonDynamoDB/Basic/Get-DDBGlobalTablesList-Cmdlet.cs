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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Lists all the global tables. Only those global tables that have replicas in the region
    /// specified as input are returned.
    /// </summary>
    [Cmdlet("Get", "DDBGlobalTablesList")]
    [OutputType("Amazon.DynamoDBv2.Model.ListGlobalTablesResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB ListGlobalTables API operation.", Operation = new[] {"ListGlobalTables"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.ListGlobalTablesResponse",
        "This cmdlet returns a Amazon.DynamoDBv2.Model.ListGlobalTablesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDDBGlobalTablesListCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter ExclusiveStartGlobalTableName
        /// <summary>
        /// <para>
        /// <para>The first global table name that this operation will evaluate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExclusiveStartGlobalTableName { get; set; }
        #endregion
        
        #region Parameter RegionName
        /// <summary>
        /// <para>
        /// <para>Lists the global tables in a specific region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegionName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of table names to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
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
            
            context.ExclusiveStartGlobalTableName = this.ExclusiveStartGlobalTableName;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.RegionName = this.RegionName;
            
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
            var request = new Amazon.DynamoDBv2.Model.ListGlobalTablesRequest();
            
            if (cmdletContext.ExclusiveStartGlobalTableName != null)
            {
                request.ExclusiveStartGlobalTableName = cmdletContext.ExclusiveStartGlobalTableName;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.RegionName != null)
            {
                request.RegionName = cmdletContext.RegionName;
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
        
        private Amazon.DynamoDBv2.Model.ListGlobalTablesResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.ListGlobalTablesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "ListGlobalTables");
            try
            {
                #if DESKTOP
                return client.ListGlobalTables(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListGlobalTablesAsync(request);
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
            public System.String ExclusiveStartGlobalTableName { get; set; }
            public int? Limit { get; set; }
            public System.String RegionName { get; set; }
        }
        
    }
}
