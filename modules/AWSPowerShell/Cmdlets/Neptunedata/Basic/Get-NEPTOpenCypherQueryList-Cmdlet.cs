/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Neptunedata;
using Amazon.Neptunedata.Model;

namespace Amazon.PowerShell.Cmdlets.NEPT
{
    /// <summary>
    /// Lists active openCypher queries. See <a href="https://docs.aws.amazon.com/neptune/latest/userguide/access-graph-opencypher-status.html">Neptune
    /// openCypher status endpoint</a> for more information.
    /// 
    ///  
    /// <para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#getquerystatus">neptune-db:GetQueryStatus</a>
    /// IAM action in that cluster.
    /// </para><para>
    /// Note that the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-data-condition-keys.html#iam-neptune-condition-keys">neptune-db:QueryLanguage:OpenCypher</a>
    /// IAM condition key can be used in the policy document to restrict the use of openCypher
    /// queries (see <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-data-condition-keys.html">Condition
    /// keys available in Neptune IAM data-access policy statements</a>).
    /// </para>
    /// </summary>
    [Cmdlet("Get", "NEPTOpenCypherQueryList")]
    [OutputType("Amazon.Neptunedata.Model.ListOpenCypherQueriesResponse")]
    [AWSCmdlet("Calls the Amazon NeptuneData ListOpenCypherQueries API operation.", Operation = new[] {"ListOpenCypherQueries"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.ListOpenCypherQueriesResponse))]
    [AWSCmdletOutput("Amazon.Neptunedata.Model.ListOpenCypherQueriesResponse",
        "This cmdlet returns an Amazon.Neptunedata.Model.ListOpenCypherQueriesResponse object containing multiple properties."
    )]
    public partial class GetNEPTOpenCypherQueryListCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IncludeWaiting
        /// <summary>
        /// <para>
        /// <para> When set to <c>TRUE</c> and other parameters are not present, causes status information
        /// to be returned for waiting queries as well as for running queries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeWaiting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.ListOpenCypherQueriesResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.ListOpenCypherQueriesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.ListOpenCypherQueriesResponse, GetNEPTOpenCypherQueryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IncludeWaiting = this.IncludeWaiting;
            
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
            var request = new Amazon.Neptunedata.Model.ListOpenCypherQueriesRequest();
            
            if (cmdletContext.IncludeWaiting != null)
            {
                request.IncludeWaiting = cmdletContext.IncludeWaiting.Value;
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
        
        private Amazon.Neptunedata.Model.ListOpenCypherQueriesResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.ListOpenCypherQueriesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "ListOpenCypherQueries");
            try
            {
                return client.ListOpenCypherQueriesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeWaiting { get; set; }
            public System.Func<Amazon.Neptunedata.Model.ListOpenCypherQueriesResponse, GetNEPTOpenCypherQueryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
