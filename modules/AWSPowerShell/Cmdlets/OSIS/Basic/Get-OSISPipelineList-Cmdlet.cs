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
using Amazon.OSIS;
using Amazon.OSIS.Model;

namespace Amazon.PowerShell.Cmdlets.OSIS
{
    /// <summary>
    /// Lists all OpenSearch Ingestion pipelines in the current Amazon Web Services account
    /// and Region. For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/list-pipeline.html">Viewing
    /// Amazon OpenSearch Ingestion pipelines</a>.
    /// </summary>
    [Cmdlet("Get", "OSISPipelineList")]
    [OutputType("Amazon.OSIS.Model.PipelineSummary")]
    [AWSCmdlet("Calls the Amazon OpenSearch Ingestion ListPipelines API operation.", Operation = new[] {"ListPipelines"}, SelectReturnType = typeof(Amazon.OSIS.Model.ListPipelinesResponse))]
    [AWSCmdletOutput("Amazon.OSIS.Model.PipelineSummary or Amazon.OSIS.Model.ListPipelinesResponse",
        "This cmdlet returns a collection of Amazon.OSIS.Model.PipelineSummary objects.",
        "The service call response (type Amazon.OSIS.Model.ListPipelinesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOSISPipelineListCmdlet : AmazonOSISClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the maximum number of results to return. You
        /// can use <c>nextToken</c> to get the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If your initial <c>ListPipelines</c> operation returns a <c>nextToken</c>, you can
        /// include the returned <c>nextToken</c> in subsequent <c>ListPipelines</c> operations,
        /// which returns results in the next page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Pipelines'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OSIS.Model.ListPipelinesResponse).
        /// Specifying the name of a property of type Amazon.OSIS.Model.ListPipelinesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Pipelines";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OSIS.Model.ListPipelinesResponse, GetOSISPipelineListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.OSIS.Model.ListPipelinesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.OSIS.Model.ListPipelinesResponse CallAWSServiceOperation(IAmazonOSIS client, Amazon.OSIS.Model.ListPipelinesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Ingestion", "ListPipelines");
            try
            {
                #if DESKTOP
                return client.ListPipelines(request);
                #elif CORECLR
                return client.ListPipelinesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.OSIS.Model.ListPipelinesResponse, GetOSISPipelineListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Pipelines;
        }
        
    }
}
