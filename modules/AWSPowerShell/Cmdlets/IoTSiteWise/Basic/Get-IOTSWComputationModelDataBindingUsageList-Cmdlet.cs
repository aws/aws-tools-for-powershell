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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Lists all data binding usages for computation models. This allows to identify where
    /// specific data bindings are being utilized across the computation models. This track
    /// dependencies between data sources and computation models.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IOTSWComputationModelDataBindingUsageList")]
    [OutputType("Amazon.IoTSiteWise.Model.ComputationModelDataBindingUsageSummary")]
    [AWSCmdlet("Calls the AWS IoT SiteWise ListComputationModelDataBindingUsages API operation.", Operation = new[] {"ListComputationModelDataBindingUsages"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.ListComputationModelDataBindingUsagesResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.ComputationModelDataBindingUsageSummary or Amazon.IoTSiteWise.Model.ListComputationModelDataBindingUsagesResponse",
        "This cmdlet returns a collection of Amazon.IoTSiteWise.Model.ComputationModelDataBindingUsageSummary objects.",
        "The service call response (type Amazon.IoTSiteWise.Model.ListComputationModelDataBindingUsagesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTSWComputationModelDataBindingUsageListCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Asset_AssetId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset to filter data bindings by. Only data bindings referencing this
        /// specific asset are matched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataBindingValueFilter_Asset_AssetId")]
        public System.String Asset_AssetId { get; set; }
        #endregion
        
        #region Parameter AssetProperty_AssetId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset containing the property to filter by. This identifies the specific
        /// asset instance containing the property of interest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataBindingValueFilter_AssetProperty_AssetId")]
        public System.String AssetProperty_AssetId { get; set; }
        #endregion
        
        #region Parameter AssetModel_AssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset model to filter data bindings by. Only data bindings referemncing
        /// this specific asset model are matched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataBindingValueFilter_AssetModel_AssetModelId")]
        public System.String AssetModel_AssetModelId { get; set; }
        #endregion
        
        #region Parameter AssetModelProperty_AssetModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset model containing the filter property. This identifies the specific
        /// asset model that contains the property of interest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataBindingValueFilter_AssetModelProperty_AssetModelId")]
        public System.String AssetModelProperty_AssetModelId { get; set; }
        #endregion
        
        #region Parameter AssetModelProperty_PropertyId
        /// <summary>
        /// <para>
        /// <para>The ID of the property within the asset model to filter by. Only data bindings referencing
        /// this specific property of the specified asset model are matched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataBindingValueFilter_AssetModelProperty_PropertyId")]
        public System.String AssetModelProperty_PropertyId { get; set; }
        #endregion
        
        #region Parameter AssetProperty_PropertyId
        /// <summary>
        /// <para>
        /// <para>The ID of the property within the asset to filter by. Only data bindings referencing
        /// this specific property of the specified asset are matched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataBindingValueFilter_AssetProperty_PropertyId")]
        public System.String AssetProperty_PropertyId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results returned for each paginated request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token used for the next set of paginated results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataBindingUsageSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.ListComputationModelDataBindingUsagesResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.ListComputationModelDataBindingUsagesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataBindingUsageSummaries";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.ListComputationModelDataBindingUsagesResponse, GetIOTSWComputationModelDataBindingUsageListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Asset_AssetId = this.Asset_AssetId;
            context.AssetModel_AssetModelId = this.AssetModel_AssetModelId;
            context.AssetModelProperty_AssetModelId = this.AssetModelProperty_AssetModelId;
            context.AssetModelProperty_PropertyId = this.AssetModelProperty_PropertyId;
            context.AssetProperty_AssetId = this.AssetProperty_AssetId;
            context.AssetProperty_PropertyId = this.AssetProperty_PropertyId;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.IoTSiteWise.Model.ListComputationModelDataBindingUsagesRequest();
            
            
             // populate DataBindingValueFilter
            var requestDataBindingValueFilterIsNull = true;
            request.DataBindingValueFilter = new Amazon.IoTSiteWise.Model.DataBindingValueFilter();
            Amazon.IoTSiteWise.Model.AssetBindingValueFilter requestDataBindingValueFilter_dataBindingValueFilter_Asset = null;
            
             // populate Asset
            var requestDataBindingValueFilter_dataBindingValueFilter_AssetIsNull = true;
            requestDataBindingValueFilter_dataBindingValueFilter_Asset = new Amazon.IoTSiteWise.Model.AssetBindingValueFilter();
            System.String requestDataBindingValueFilter_dataBindingValueFilter_Asset_asset_AssetId = null;
            if (cmdletContext.Asset_AssetId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_Asset_asset_AssetId = cmdletContext.Asset_AssetId;
            }
            if (requestDataBindingValueFilter_dataBindingValueFilter_Asset_asset_AssetId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_Asset.AssetId = requestDataBindingValueFilter_dataBindingValueFilter_Asset_asset_AssetId;
                requestDataBindingValueFilter_dataBindingValueFilter_AssetIsNull = false;
            }
             // determine if requestDataBindingValueFilter_dataBindingValueFilter_Asset should be set to null
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetIsNull)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_Asset = null;
            }
            if (requestDataBindingValueFilter_dataBindingValueFilter_Asset != null)
            {
                request.DataBindingValueFilter.Asset = requestDataBindingValueFilter_dataBindingValueFilter_Asset;
                requestDataBindingValueFilterIsNull = false;
            }
            Amazon.IoTSiteWise.Model.AssetModelBindingValueFilter requestDataBindingValueFilter_dataBindingValueFilter_AssetModel = null;
            
             // populate AssetModel
            var requestDataBindingValueFilter_dataBindingValueFilter_AssetModelIsNull = true;
            requestDataBindingValueFilter_dataBindingValueFilter_AssetModel = new Amazon.IoTSiteWise.Model.AssetModelBindingValueFilter();
            System.String requestDataBindingValueFilter_dataBindingValueFilter_AssetModel_assetModel_AssetModelId = null;
            if (cmdletContext.AssetModel_AssetModelId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModel_assetModel_AssetModelId = cmdletContext.AssetModel_AssetModelId;
            }
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetModel_assetModel_AssetModelId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModel.AssetModelId = requestDataBindingValueFilter_dataBindingValueFilter_AssetModel_assetModel_AssetModelId;
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModelIsNull = false;
            }
             // determine if requestDataBindingValueFilter_dataBindingValueFilter_AssetModel should be set to null
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetModelIsNull)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModel = null;
            }
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetModel != null)
            {
                request.DataBindingValueFilter.AssetModel = requestDataBindingValueFilter_dataBindingValueFilter_AssetModel;
                requestDataBindingValueFilterIsNull = false;
            }
            Amazon.IoTSiteWise.Model.AssetModelPropertyBindingValueFilter requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty = null;
            
             // populate AssetModelProperty
            var requestDataBindingValueFilter_dataBindingValueFilter_AssetModelPropertyIsNull = true;
            requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty = new Amazon.IoTSiteWise.Model.AssetModelPropertyBindingValueFilter();
            System.String requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty_assetModelProperty_AssetModelId = null;
            if (cmdletContext.AssetModelProperty_AssetModelId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty_assetModelProperty_AssetModelId = cmdletContext.AssetModelProperty_AssetModelId;
            }
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty_assetModelProperty_AssetModelId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty.AssetModelId = requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty_assetModelProperty_AssetModelId;
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModelPropertyIsNull = false;
            }
            System.String requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty_assetModelProperty_PropertyId = null;
            if (cmdletContext.AssetModelProperty_PropertyId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty_assetModelProperty_PropertyId = cmdletContext.AssetModelProperty_PropertyId;
            }
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty_assetModelProperty_PropertyId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty.PropertyId = requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty_assetModelProperty_PropertyId;
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModelPropertyIsNull = false;
            }
             // determine if requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty should be set to null
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetModelPropertyIsNull)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty = null;
            }
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty != null)
            {
                request.DataBindingValueFilter.AssetModelProperty = requestDataBindingValueFilter_dataBindingValueFilter_AssetModelProperty;
                requestDataBindingValueFilterIsNull = false;
            }
            Amazon.IoTSiteWise.Model.AssetPropertyBindingValueFilter requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty = null;
            
             // populate AssetProperty
            var requestDataBindingValueFilter_dataBindingValueFilter_AssetPropertyIsNull = true;
            requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty = new Amazon.IoTSiteWise.Model.AssetPropertyBindingValueFilter();
            System.String requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty_assetProperty_AssetId = null;
            if (cmdletContext.AssetProperty_AssetId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty_assetProperty_AssetId = cmdletContext.AssetProperty_AssetId;
            }
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty_assetProperty_AssetId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty.AssetId = requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty_assetProperty_AssetId;
                requestDataBindingValueFilter_dataBindingValueFilter_AssetPropertyIsNull = false;
            }
            System.String requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty_assetProperty_PropertyId = null;
            if (cmdletContext.AssetProperty_PropertyId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty_assetProperty_PropertyId = cmdletContext.AssetProperty_PropertyId;
            }
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty_assetProperty_PropertyId != null)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty.PropertyId = requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty_assetProperty_PropertyId;
                requestDataBindingValueFilter_dataBindingValueFilter_AssetPropertyIsNull = false;
            }
             // determine if requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty should be set to null
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetPropertyIsNull)
            {
                requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty = null;
            }
            if (requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty != null)
            {
                request.DataBindingValueFilter.AssetProperty = requestDataBindingValueFilter_dataBindingValueFilter_AssetProperty;
                requestDataBindingValueFilterIsNull = false;
            }
             // determine if request.DataBindingValueFilter should be set to null
            if (requestDataBindingValueFilterIsNull)
            {
                request.DataBindingValueFilter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.IoTSiteWise.Model.ListComputationModelDataBindingUsagesResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.ListComputationModelDataBindingUsagesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "ListComputationModelDataBindingUsages");
            try
            {
                #if DESKTOP
                return client.ListComputationModelDataBindingUsages(request);
                #elif CORECLR
                return client.ListComputationModelDataBindingUsagesAsync(request).GetAwaiter().GetResult();
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
            public System.String Asset_AssetId { get; set; }
            public System.String AssetModel_AssetModelId { get; set; }
            public System.String AssetModelProperty_AssetModelId { get; set; }
            public System.String AssetModelProperty_PropertyId { get; set; }
            public System.String AssetProperty_AssetId { get; set; }
            public System.String AssetProperty_PropertyId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.ListComputationModelDataBindingUsagesResponse, GetIOTSWComputationModelDataBindingUsageListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataBindingUsageSummaries;
        }
        
    }
}
