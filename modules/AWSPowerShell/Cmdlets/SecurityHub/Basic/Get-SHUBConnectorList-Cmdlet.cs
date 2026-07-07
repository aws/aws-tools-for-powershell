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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Lists the CSPM connectors and their metadata for the calling account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SHUBConnectorList")]
    [OutputType("Amazon.SecurityHub.Model.CspmConnectorSummary")]
    [AWSCmdlet("Calls the AWS Security Hub ListConnectors API operation.", Operation = new[] {"ListConnectors"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.ListConnectorsResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.CspmConnectorSummary or Amazon.SecurityHub.Model.ListConnectorsResponse",
        "This cmdlet returns a collection of Amazon.SecurityHub.Model.CspmConnectorSummary objects.",
        "The service call response (type Amazon.SecurityHub.Model.ListConnectorsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHUBConnectorListCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectorStatus
        /// <summary>
        /// <para>
        /// <para>The connectivity status to filter connectors by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.CspmConnectorStatus")]
        public Amazon.SecurityHub.CspmConnectorStatus ConnectorStatus { get; set; }
        #endregion
        
        #region Parameter EnablementStatus
        /// <summary>
        /// <para>
        /// <para>The enablement status to filter connectors by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.CspmEnablementStatus")]
        public Amazon.SecurityHub.CspmEnablementStatus EnablementStatus { get; set; }
        #endregion
        
        #region Parameter ProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the cloud provider to filter connectors by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.CspmConnectorProviderName")]
        public Amazon.SecurityHub.CspmConnectorProviderName ProviderName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token to request the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Connectors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.ListConnectorsResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.ListConnectorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Connectors";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.ListConnectorsResponse, GetSHUBConnectorListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorStatus = this.ConnectorStatus;
            context.EnablementStatus = this.EnablementStatus;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProviderName = this.ProviderName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SecurityHub.Model.ListConnectorsRequest();
            
            if (cmdletContext.ConnectorStatus != null)
            {
                request.ConnectorStatus = cmdletContext.ConnectorStatus;
            }
            if (cmdletContext.EnablementStatus != null)
            {
                request.EnablementStatus = cmdletContext.EnablementStatus;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ProviderName != null)
            {
                request.ProviderName = cmdletContext.ProviderName;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SecurityHub.Model.ListConnectorsResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.ListConnectorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "ListConnectors");
            try
            {
                return client.ListConnectorsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SecurityHub.CspmConnectorStatus ConnectorStatus { get; set; }
            public Amazon.SecurityHub.CspmEnablementStatus EnablementStatus { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.SecurityHub.CspmConnectorProviderName ProviderName { get; set; }
            public System.Func<Amazon.SecurityHub.Model.ListConnectorsResponse, GetSHUBConnectorListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Connectors;
        }
        
    }
}
