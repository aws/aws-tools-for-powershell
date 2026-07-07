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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Lists connectors in your account. Results are paginated. Use the <c>nextToken</c>
    /// parameter to retrieve the next page of results.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "INS2ConnectorList")]
    [OutputType("Amazon.Inspector2.Model.Connector")]
    [AWSCmdlet("Calls the Inspector2 ListConnectors API operation.", Operation = new[] {"ListConnectors"}, SelectReturnType = typeof(Amazon.Inspector2.Model.ListConnectorsResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.Connector or Amazon.Inspector2.Model.ListConnectorsResponse",
        "This cmdlet returns a collection of Amazon.Inspector2.Model.Connector objects.",
        "The service call response (type Amazon.Inspector2.Model.ListConnectorsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINS2ConnectorListCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FilterCriteria_Account
        /// <summary>
        /// <para>
        /// <para>Filter by Amazon Web Services account IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_Accounts")]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Account { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_AwsConfigConnectorArn
        /// <summary>
        /// <para>
        /// <para>Filter by Amazon Web Services Config connector ARNs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_AwsConfigConnectorArns")]
        public Amazon.Inspector2.Model.AwsConfigConnectorArnFilter[] FilterCriteria_AwsConfigConnectorArn { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ConnectorArn
        /// <summary>
        /// <para>
        /// <para>Filter by connector ARNs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_ConnectorArns")]
        public Amazon.Inspector2.Model.ConnectorArnFilter[] FilterCriteria_ConnectorArn { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ConnectorType
        /// <summary>
        /// <para>
        /// <para>Filter by connector type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.ConnectorTypeFilter[] FilterCriteria_ConnectorType { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Provider
        /// <summary>
        /// <para>
        /// <para>Filter by cloud provider.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.ProviderFilter[] FilterCriteria_Provider { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. To retrieve the remaining
        /// results, make another request with the <c>nextToken</c> value returned from this request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to use for paginating results. Set this value to null for the first request.
        /// For subsequent calls, use the <c>nextToken</c> value returned from the previous request.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.ListConnectorsResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.ListConnectorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.ListConnectorsResponse, GetINS2ConnectorListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterCriteria_Account != null)
            {
                context.FilterCriteria_Account = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Account);
            }
            if (this.FilterCriteria_AwsConfigConnectorArn != null)
            {
                context.FilterCriteria_AwsConfigConnectorArn = new List<Amazon.Inspector2.Model.AwsConfigConnectorArnFilter>(this.FilterCriteria_AwsConfigConnectorArn);
            }
            if (this.FilterCriteria_ConnectorArn != null)
            {
                context.FilterCriteria_ConnectorArn = new List<Amazon.Inspector2.Model.ConnectorArnFilter>(this.FilterCriteria_ConnectorArn);
            }
            if (this.FilterCriteria_ConnectorType != null)
            {
                context.FilterCriteria_ConnectorType = new List<Amazon.Inspector2.Model.ConnectorTypeFilter>(this.FilterCriteria_ConnectorType);
            }
            if (this.FilterCriteria_Provider != null)
            {
                context.FilterCriteria_Provider = new List<Amazon.Inspector2.Model.ProviderFilter>(this.FilterCriteria_Provider);
            }
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Inspector2.Model.ListConnectorsRequest();
            
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Inspector2.Model.ConnectorFilterCriteria();
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Account = null;
            if (cmdletContext.FilterCriteria_Account != null)
            {
                requestFilterCriteria_filterCriteria_Account = cmdletContext.FilterCriteria_Account;
            }
            if (requestFilterCriteria_filterCriteria_Account != null)
            {
                request.FilterCriteria.Accounts = requestFilterCriteria_filterCriteria_Account;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.AwsConfigConnectorArnFilter> requestFilterCriteria_filterCriteria_AwsConfigConnectorArn = null;
            if (cmdletContext.FilterCriteria_AwsConfigConnectorArn != null)
            {
                requestFilterCriteria_filterCriteria_AwsConfigConnectorArn = cmdletContext.FilterCriteria_AwsConfigConnectorArn;
            }
            if (requestFilterCriteria_filterCriteria_AwsConfigConnectorArn != null)
            {
                request.FilterCriteria.AwsConfigConnectorArns = requestFilterCriteria_filterCriteria_AwsConfigConnectorArn;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.ConnectorArnFilter> requestFilterCriteria_filterCriteria_ConnectorArn = null;
            if (cmdletContext.FilterCriteria_ConnectorArn != null)
            {
                requestFilterCriteria_filterCriteria_ConnectorArn = cmdletContext.FilterCriteria_ConnectorArn;
            }
            if (requestFilterCriteria_filterCriteria_ConnectorArn != null)
            {
                request.FilterCriteria.ConnectorArns = requestFilterCriteria_filterCriteria_ConnectorArn;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.ConnectorTypeFilter> requestFilterCriteria_filterCriteria_ConnectorType = null;
            if (cmdletContext.FilterCriteria_ConnectorType != null)
            {
                requestFilterCriteria_filterCriteria_ConnectorType = cmdletContext.FilterCriteria_ConnectorType;
            }
            if (requestFilterCriteria_filterCriteria_ConnectorType != null)
            {
                request.FilterCriteria.ConnectorType = requestFilterCriteria_filterCriteria_ConnectorType;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.ProviderFilter> requestFilterCriteria_filterCriteria_Provider = null;
            if (cmdletContext.FilterCriteria_Provider != null)
            {
                requestFilterCriteria_filterCriteria_Provider = cmdletContext.FilterCriteria_Provider;
            }
            if (requestFilterCriteria_filterCriteria_Provider != null)
            {
                request.FilterCriteria.Provider = requestFilterCriteria_filterCriteria_Provider;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
        
        private Amazon.Inspector2.Model.ListConnectorsResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.ListConnectorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "ListConnectors");
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
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Account { get; set; }
            public List<Amazon.Inspector2.Model.AwsConfigConnectorArnFilter> FilterCriteria_AwsConfigConnectorArn { get; set; }
            public List<Amazon.Inspector2.Model.ConnectorArnFilter> FilterCriteria_ConnectorArn { get; set; }
            public List<Amazon.Inspector2.Model.ConnectorTypeFilter> FilterCriteria_ConnectorType { get; set; }
            public List<Amazon.Inspector2.Model.ProviderFilter> FilterCriteria_Provider { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Inspector2.Model.ListConnectorsResponse, GetINS2ConnectorListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
