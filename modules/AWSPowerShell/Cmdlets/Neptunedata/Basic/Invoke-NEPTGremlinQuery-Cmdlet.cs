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
using Amazon.Neptunedata;
using Amazon.Neptunedata.Model;

namespace Amazon.PowerShell.Cmdlets.NEPT
{
    /// <summary>
    /// This commands executes a Gremlin query. Amazon Neptune is compatible with Apache TinkerPop3
    /// and Gremlin, so you can use the Gremlin traversal language to query the graph, as
    /// described under <a href="https://tinkerpop.apache.org/docs/current/reference/#graph">The
    /// Graph</a> in the Apache TinkerPop3 documentation. More details can also be found in
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/access-graph-gremlin.html">Accessing
    /// a Neptune graph with Gremlin</a>.
    /// 
    ///  
    /// <para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that enables one
    /// of the following IAM actions in that cluster, depending on the query:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#readdataviaquery">neptune-db:ReadDataViaQuery</a></para></li><li><para><a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#writedataviaquery">neptune-db:WriteDataViaQuery</a></para></li><li><para><a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#deletedataviaquery">neptune-db:DeleteDataViaQuery</a></para></li></ul><para>
    /// Note that the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-data-condition-keys.html#iam-neptune-condition-keys">neptune-db:QueryLanguage:Gremlin</a>
    /// IAM condition key can be used in the policy document to restrict the use of Gremlin
    /// queries (see <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-data-condition-keys.html">Condition
    /// keys available in Neptune IAM data-access policy statements</a>).
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "NEPTGremlinQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptunedata.Model.ExecuteGremlinQueryResponse")]
    [AWSCmdlet("Calls the Amazon NeptuneData ExecuteGremlinQuery API operation.", Operation = new[] {"ExecuteGremlinQuery"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.ExecuteGremlinQueryResponse))]
    [AWSCmdletOutput("Amazon.Neptunedata.Model.ExecuteGremlinQueryResponse",
        "This cmdlet returns an Amazon.Neptunedata.Model.ExecuteGremlinQueryResponse object containing multiple properties."
    )]
    public partial class InvokeNEPTGremlinQueryCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GremlinQuery
        /// <summary>
        /// <para>
        /// <para>Using this API, you can run Gremlin queries in string format much as you can using
        /// the HTTP endpoint. The interface is compatible with whatever Gremlin version your
        /// DB cluster is using (see the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/access-graph-gremlin-client.html#best-practices-gremlin-java-latest">Tinkerpop
        /// client section</a> to determine which Gremlin releases your engine version supports).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String GremlinQuery { get; set; }
        #endregion
        
        #region Parameter Serializer
        /// <summary>
        /// <para>
        /// <para>If non-null, the query results are returned in a serialized response message in the
        /// format specified by this parameter. See the <a href="https://tinkerpop.apache.org/docs/current/reference/#_graphson">GraphSON</a>
        /// section in the TinkerPop documentation for a list of the formats that are currently
        /// supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Serializer { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.ExecuteGremlinQueryResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.ExecuteGremlinQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-NEPTGremlinQuery (ExecuteGremlinQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.ExecuteGremlinQueryResponse, InvokeNEPTGremlinQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GremlinQuery = this.GremlinQuery;
            #if MODULAR
            if (this.GremlinQuery == null && ParameterWasBound(nameof(this.GremlinQuery)))
            {
                WriteWarning("You are passing $null as a value for parameter GremlinQuery which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Serializer = this.Serializer;
            
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
            var request = new Amazon.Neptunedata.Model.ExecuteGremlinQueryRequest();
            
            if (cmdletContext.GremlinQuery != null)
            {
                request.GremlinQuery = cmdletContext.GremlinQuery;
            }
            if (cmdletContext.Serializer != null)
            {
                request.Serializer = cmdletContext.Serializer;
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
        
        private Amazon.Neptunedata.Model.ExecuteGremlinQueryResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.ExecuteGremlinQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "ExecuteGremlinQuery");
            try
            {
                #if DESKTOP
                return client.ExecuteGremlinQuery(request);
                #elif CORECLR
                return client.ExecuteGremlinQueryAsync(request).GetAwaiter().GetResult();
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
            public System.String GremlinQuery { get; set; }
            public System.String Serializer { get; set; }
            public System.Func<Amazon.Neptunedata.Model.ExecuteGremlinQueryResponse, InvokeNEPTGremlinQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
