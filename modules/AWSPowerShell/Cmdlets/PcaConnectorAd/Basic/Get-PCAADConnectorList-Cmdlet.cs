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
using Amazon.PcaConnectorAd;
using Amazon.PcaConnectorAd.Model;

namespace Amazon.PowerShell.Cmdlets.PCAAD
{
    /// <summary>
    /// Lists the connectors that you created by using the <a href="https://docs.aws.amazon.com/pca-connector-ad/latest/APIReference/API_CreateConnector">https://docs.aws.amazon.com/pca-connector-ad/latest/APIReference/API_CreateConnector</a>
    /// action.
    /// </summary>
    [Cmdlet("Get", "PCAADConnectorList")]
    [OutputType("Amazon.PcaConnectorAd.Model.ConnectorSummary")]
    [AWSCmdlet("Calls the Pca Connector Ad ListConnectors API operation.", Operation = new[] {"ListConnectors"}, SelectReturnType = typeof(Amazon.PcaConnectorAd.Model.ListConnectorsResponse))]
    [AWSCmdletOutput("Amazon.PcaConnectorAd.Model.ConnectorSummary or Amazon.PcaConnectorAd.Model.ListConnectorsResponse",
        "This cmdlet returns a collection of Amazon.PcaConnectorAd.Model.ConnectorSummary objects.",
        "The service call response (type Amazon.PcaConnectorAd.Model.ListConnectorsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPCAADConnectorListCmdlet : AmazonPcaConnectorAdClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Use this parameter when paginating results to specify the maximum number of items
        /// to return in the response on each page. If additional items exist beyond the number
        /// you specify, the <c>NextToken</c> element is sent in the response. Use this <c>NextToken</c>
        /// value in a subsequent request to retrieve additional items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Use this parameter when paginating results in a subsequent request after you receive
        /// a response with truncated results. Set it to the value of the <c>NextToken</c> parameter
        /// from the response you just received.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Connectors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PcaConnectorAd.Model.ListConnectorsResponse).
        /// Specifying the name of a property of type Amazon.PcaConnectorAd.Model.ListConnectorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Connectors";
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
                context.Select = CreateSelectDelegate<Amazon.PcaConnectorAd.Model.ListConnectorsResponse, GetPCAADConnectorListCmdlet>(Select) ??
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
            var request = new Amazon.PcaConnectorAd.Model.ListConnectorsRequest();
            
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
        
        private Amazon.PcaConnectorAd.Model.ListConnectorsResponse CallAWSServiceOperation(IAmazonPcaConnectorAd client, Amazon.PcaConnectorAd.Model.ListConnectorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Pca Connector Ad", "ListConnectors");
            try
            {
                #if DESKTOP
                return client.ListConnectors(request);
                #elif CORECLR
                return client.ListConnectorsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.PcaConnectorAd.Model.ListConnectorsResponse, GetPCAADConnectorListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Connectors;
        }
        
    }
}
