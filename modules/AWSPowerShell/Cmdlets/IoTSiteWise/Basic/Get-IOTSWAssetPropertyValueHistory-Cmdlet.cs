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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Gets the history of an asset property's values. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/query-industrial-data.html#historical-values">Querying
    /// historical values</a> in the <i>IoT SiteWise User Guide</i>.
    /// 
    ///  
    /// <para>
    /// To identify an asset property, you must specify one of the following:
    /// </para><ul><li><para>
    /// The <c>assetId</c> and <c>propertyId</c> of an asset property.
    /// </para></li><li><para>
    /// A <c>propertyAlias</c>, which is a data stream alias (for example, <c>/company/windfarm/3/turbine/7/temperature</c>).
    /// To define an asset property's alias, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/APIReference/API_UpdateAssetProperty.html">UpdateAssetProperty</a>.
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IOTSWAssetPropertyValueHistory")]
    [OutputType("Amazon.IoTSiteWise.Model.AssetPropertyValue")]
    [AWSCmdlet("Calls the AWS IoT SiteWise GetAssetPropertyValueHistory API operation.", Operation = new[] {"GetAssetPropertyValueHistory"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.GetAssetPropertyValueHistoryResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.AssetPropertyValue or Amazon.IoTSiteWise.Model.GetAssetPropertyValueHistoryResponse",
        "This cmdlet returns a collection of Amazon.IoTSiteWise.Model.AssetPropertyValue objects.",
        "The service call response (type Amazon.IoTSiteWise.Model.GetAssetPropertyValueHistoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTSWAssetPropertyValueHistoryCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssetId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset, in UUID format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssetId { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The inclusive end of the range from which to query historical data, expressed in seconds
        /// in Unix epoch time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDate { get; set; }
        #endregion
        
        #region Parameter PropertyAlias
        /// <summary>
        /// <para>
        /// <para>The alias that identifies the property, such as an OPC-UA server data stream path
        /// (for example, <c>/company/windfarm/3/turbine/7/temperature</c>). For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/connect-data-streams.html">Mapping
        /// industrial data streams to asset properties</a> in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PropertyAlias { get; set; }
        #endregion
        
        #region Parameter PropertyId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset property, in UUID format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PropertyId { get; set; }
        #endregion
        
        #region Parameter Quality
        /// <summary>
        /// <para>
        /// <para>The quality by which to filter asset data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Qualities")]
        public System.String[] Quality { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>The exclusive start of the range from which to query historical data, expressed in
        /// seconds in Unix epoch time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartDate { get; set; }
        #endregion
        
        #region Parameter TimeOrdering
        /// <summary>
        /// <para>
        /// <para>The chronological sorting order of the requested information.</para><para>Default: <c>ASCENDING</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.TimeOrdering")]
        public Amazon.IoTSiteWise.TimeOrdering TimeOrdering { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return for each paginated request. A result set is
        /// returned in the two cases, whichever occurs first.</para><ul><li><para>The size of the result set is equal to 4 MB.</para></li><li><para>The number of data points in the result set is equal to the value of <c>maxResults</c>.
        /// The maximum value of <c>maxResults</c> is 20000.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to be used for the next set of paginated results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssetPropertyValueHistory'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.GetAssetPropertyValueHistoryResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.GetAssetPropertyValueHistoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssetPropertyValueHistory";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.GetAssetPropertyValueHistoryResponse, GetIOTSWAssetPropertyValueHistoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetId = this.AssetId;
            context.EndDate = this.EndDate;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PropertyAlias = this.PropertyAlias;
            context.PropertyId = this.PropertyId;
            if (this.Quality != null)
            {
                context.Quality = new List<System.String>(this.Quality);
            }
            context.StartDate = this.StartDate;
            context.TimeOrdering = this.TimeOrdering;
            
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
            var request = new Amazon.IoTSiteWise.Model.GetAssetPropertyValueHistoryRequest();
            
            if (cmdletContext.AssetId != null)
            {
                request.AssetId = cmdletContext.AssetId;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.PropertyAlias != null)
            {
                request.PropertyAlias = cmdletContext.PropertyAlias;
            }
            if (cmdletContext.PropertyId != null)
            {
                request.PropertyId = cmdletContext.PropertyId;
            }
            if (cmdletContext.Quality != null)
            {
                request.Qualities = cmdletContext.Quality;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate.Value;
            }
            if (cmdletContext.TimeOrdering != null)
            {
                request.TimeOrdering = cmdletContext.TimeOrdering;
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
        
        private Amazon.IoTSiteWise.Model.GetAssetPropertyValueHistoryResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.GetAssetPropertyValueHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "GetAssetPropertyValueHistory");
            try
            {
                return client.GetAssetPropertyValueHistoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssetId { get; set; }
            public System.DateTime? EndDate { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PropertyAlias { get; set; }
            public System.String PropertyId { get; set; }
            public List<System.String> Quality { get; set; }
            public System.DateTime? StartDate { get; set; }
            public Amazon.IoTSiteWise.TimeOrdering TimeOrdering { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.GetAssetPropertyValueHistoryResponse, GetIOTSWAssetPropertyValueHistoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssetPropertyValueHistory;
        }
        
    }
}
