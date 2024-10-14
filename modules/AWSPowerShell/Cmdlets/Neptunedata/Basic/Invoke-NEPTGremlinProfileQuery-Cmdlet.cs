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
    /// Executes a Gremlin Profile query, which runs a specified traversal, collects various
    /// metrics about the run, and produces a profile report as output. See <a href="https://docs.aws.amazon.com/neptune/latest/userguide/gremlin-profile-api.html">Gremlin
    /// profile API in Neptune</a> for details.
    /// 
    ///  
    /// <para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#readdataviaquery">neptune-db:ReadDataViaQuery</a>
    /// IAM action in that cluster.
    /// </para><para>
    /// Note that the <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-data-condition-keys.html#iam-neptune-condition-keys">neptune-db:QueryLanguage:Gremlin</a>
    /// IAM condition key can be used in the policy document to restrict the use of Gremlin
    /// queries (see <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-data-condition-keys.html">Condition
    /// keys available in Neptune IAM data-access policy statements</a>).
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "NEPTGremlinProfileQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.IO.MemoryStream")]
    [AWSCmdlet("Calls the Amazon NeptuneData ExecuteGremlinProfileQuery API operation.", Operation = new[] {"ExecuteGremlinProfileQuery"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.ExecuteGremlinProfileQueryResponse))]
    [AWSCmdletOutput("System.IO.MemoryStream or Amazon.Neptunedata.Model.ExecuteGremlinProfileQueryResponse",
        "This cmdlet returns a System.IO.MemoryStream object.",
        "The service call response (type Amazon.Neptunedata.Model.ExecuteGremlinProfileQueryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeNEPTGremlinProfileQueryCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Chop
        /// <summary>
        /// <para>
        /// <para>If non-zero, causes the results string to be truncated at that number of characters.
        /// If set to zero, the string contains all the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Chop { get; set; }
        #endregion
        
        #region Parameter GremlinQuery
        /// <summary>
        /// <para>
        /// <para>The Gremlin query string to profile.</para>
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
        
        #region Parameter IndexOp
        /// <summary>
        /// <para>
        /// <para>If this flag is set to <c>TRUE</c>, the results include a detailed report of all index
        /// operations that took place during query execution and serialization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IndexOps")]
        public System.Boolean? IndexOp { get; set; }
        #endregion
        
        #region Parameter Result
        /// <summary>
        /// <para>
        /// <para>If this flag is set to <c>TRUE</c>, the query results are gathered and displayed as
        /// part of the profile report. If <c>FALSE</c>, only the result count is displayed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Results")]
        public System.Boolean? Result { get; set; }
        #endregion
        
        #region Parameter Serializer
        /// <summary>
        /// <para>
        /// <para>If non-null, the gathered results are returned in a serialized response message in
        /// the format specified by this parameter. See <a href="https://docs.aws.amazon.com/neptune/latest/userguide/gremlin-profile-api.html">Gremlin
        /// profile API in Neptune</a> for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Serializer { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Output'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.ExecuteGremlinProfileQueryResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.ExecuteGremlinProfileQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Output";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-NEPTGremlinProfileQuery (ExecuteGremlinProfileQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.ExecuteGremlinProfileQueryResponse, InvokeNEPTGremlinProfileQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Chop = this.Chop;
            context.GremlinQuery = this.GremlinQuery;
            #if MODULAR
            if (this.GremlinQuery == null && ParameterWasBound(nameof(this.GremlinQuery)))
            {
                WriteWarning("You are passing $null as a value for parameter GremlinQuery which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IndexOp = this.IndexOp;
            context.Result = this.Result;
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
            var request = new Amazon.Neptunedata.Model.ExecuteGremlinProfileQueryRequest();
            
            if (cmdletContext.Chop != null)
            {
                request.Chop = cmdletContext.Chop.Value;
            }
            if (cmdletContext.GremlinQuery != null)
            {
                request.GremlinQuery = cmdletContext.GremlinQuery;
            }
            if (cmdletContext.IndexOp != null)
            {
                request.IndexOps = cmdletContext.IndexOp.Value;
            }
            if (cmdletContext.Result != null)
            {
                request.Results = cmdletContext.Result.Value;
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
        
        private Amazon.Neptunedata.Model.ExecuteGremlinProfileQueryResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.ExecuteGremlinProfileQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "ExecuteGremlinProfileQuery");
            try
            {
                #if DESKTOP
                return client.ExecuteGremlinProfileQuery(request);
                #elif CORECLR
                return client.ExecuteGremlinProfileQueryAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? Chop { get; set; }
            public System.String GremlinQuery { get; set; }
            public System.Boolean? IndexOp { get; set; }
            public System.Boolean? Result { get; set; }
            public System.String Serializer { get; set; }
            public System.Func<Amazon.Neptunedata.Model.ExecuteGremlinProfileQueryResponse, InvokeNEPTGremlinProfileQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Output;
        }
        
    }
}
