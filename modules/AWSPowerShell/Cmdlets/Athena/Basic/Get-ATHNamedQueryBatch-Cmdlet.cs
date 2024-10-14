/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// provide as an array of query ID strings. Requires you to have access to the workgroup
    /// in which the queries were saved. Use <a>ListNamedQueriesInput</a> to get the list
    /// of named query IDs in the specified workgroup. If information could not be retrieved
    /// for a submitted query ID, information about the query ID submitted is listed under
    /// <a>UnprocessedNamedQueryId</a>. Named queries differ from executed queries. Use <a>BatchGetQueryExecutionInput</a>
    /// to get details about each unique query execution, and <a>ListQueryExecutionsInput</a>
    /// to get a list of query execution IDs.
    /// </summary>
    [Cmdlet("Get", "ATHNamedQueryBatch")]
    [OutputType("Amazon.Athena.Model.BatchGetNamedQueryResponse")]
    [AWSCmdlet("Calls the Amazon Athena BatchGetNamedQuery API operation.", Operation = new[] {"BatchGetNamedQuery"}, SelectReturnType = typeof(Amazon.Athena.Model.BatchGetNamedQueryResponse))]
    [AWSCmdletOutput("Amazon.Athena.Model.BatchGetNamedQueryResponse",
        "This cmdlet returns an Amazon.Athena.Model.BatchGetNamedQueryResponse object containing multiple properties."
    )]
    public partial class GetATHNamedQueryBatchCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NamedQueryId
        /// <summary>
        /// <para>
        /// <para>An array of query IDs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NamedQueryIds")]
        public System.String[] NamedQueryId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.BatchGetNamedQueryResponse).
        /// Specifying the name of a property of type Amazon.Athena.Model.BatchGetNamedQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NamedQueryId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NamedQueryId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NamedQueryId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.BatchGetNamedQueryResponse, GetATHNamedQueryBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NamedQueryId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.NamedQueryId != null)
            {
                context.NamedQueryId = new List<System.String>(this.NamedQueryId);
            }
            #if MODULAR
            if (this.NamedQueryId == null && ParameterWasBound(nameof(this.NamedQueryId)))
            {
                WriteWarning("You are passing $null as a value for parameter NamedQueryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            
            if (cmdletContext.NamedQueryId != null)
            {
                request.NamedQueryIds = cmdletContext.NamedQueryId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.BatchGetNamedQueryAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> NamedQueryId { get; set; }
            public System.Func<Amazon.Athena.Model.BatchGetNamedQueryResponse, GetATHNamedQueryBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
