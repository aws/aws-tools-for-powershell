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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Returns the name of all Elasticsearch domains owned by the current user's account.
    /// </summary>
    [Cmdlet("Get", "ESDomainNameList")]
    [OutputType("Amazon.Elasticsearch.Model.DomainInfo")]
    [AWSCmdlet("Calls the Amazon Elasticsearch ListDomainNames API operation.", Operation = new[] {"ListDomainNames"}, SelectReturnType = typeof(Amazon.Elasticsearch.Model.ListDomainNamesResponse))]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.DomainInfo or Amazon.Elasticsearch.Model.ListDomainNamesResponse",
        "This cmdlet returns a collection of Amazon.Elasticsearch.Model.DomainInfo objects.",
        "The service call response (type Amazon.Elasticsearch.Model.ListDomainNamesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetESDomainNameListCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EngineType
        /// <summary>
        /// <para>
        /// <para> Optional parameter to filter the output by domain engine type. Acceptable values
        /// are 'Elasticsearch' and 'OpenSearch'. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Elasticsearch.EngineType")]
        public Amazon.Elasticsearch.EngineType EngineType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainNames'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Elasticsearch.Model.ListDomainNamesResponse).
        /// Specifying the name of a property of type Amazon.Elasticsearch.Model.ListDomainNamesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainNames";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Elasticsearch.Model.ListDomainNamesResponse, GetESDomainNameListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EngineType = this.EngineType;
            
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
            var request = new Amazon.Elasticsearch.Model.ListDomainNamesRequest();
            
            if (cmdletContext.EngineType != null)
            {
                request.EngineType = cmdletContext.EngineType;
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
        
        private Amazon.Elasticsearch.Model.ListDomainNamesResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.ListDomainNamesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "ListDomainNames");
            try
            {
                return client.ListDomainNamesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Elasticsearch.EngineType EngineType { get; set; }
            public System.Func<Amazon.Elasticsearch.Model.ListDomainNamesResponse, GetESDomainNameListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainNames;
        }
        
    }
}
