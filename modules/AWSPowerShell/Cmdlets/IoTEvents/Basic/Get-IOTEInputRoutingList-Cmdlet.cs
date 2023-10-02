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
using Amazon.IoTEvents;
using Amazon.IoTEvents.Model;

namespace Amazon.PowerShell.Cmdlets.IOTE
{
    /// <summary>
    /// Lists one or more input routings.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IOTEInputRoutingList")]
    [OutputType("Amazon.IoTEvents.Model.RoutedResource")]
    [AWSCmdlet("Calls the AWS IoT Events ListInputRoutings API operation.", Operation = new[] {"ListInputRoutings"}, SelectReturnType = typeof(Amazon.IoTEvents.Model.ListInputRoutingsResponse))]
    [AWSCmdletOutput("Amazon.IoTEvents.Model.RoutedResource or Amazon.IoTEvents.Model.ListInputRoutingsResponse",
        "This cmdlet returns a collection of Amazon.IoTEvents.Model.RoutedResource objects.",
        "The service call response (type Amazon.IoTEvents.Model.ListInputRoutingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIOTEInputRoutingListCmdlet : AmazonIoTEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IotSiteWiseAssetModelPropertyIdentifier_AssetModelId
        /// <summary>
        /// <para>
        /// <para> The ID of the AWS IoT SiteWise asset model. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier_AssetModelId")]
        public System.String IotSiteWiseAssetModelPropertyIdentifier_AssetModelId { get; set; }
        #endregion
        
        #region Parameter IotEventsInputIdentifier_InputName
        /// <summary>
        /// <para>
        /// <para> The name of the input routed to AWS IoT Events. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputIdentifier_IotEventsInputIdentifier_InputName")]
        public System.String IotEventsInputIdentifier_InputName { get; set; }
        #endregion
        
        #region Parameter IotSiteWiseAssetModelPropertyIdentifier_PropertyId
        /// <summary>
        /// <para>
        /// <para> The ID of the AWS IoT SiteWise asset property. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier_PropertyId")]
        public System.String IotSiteWiseAssetModelPropertyIdentifier_PropertyId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of results to be returned per request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> The token that you can use to return the next set of results. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RoutedResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTEvents.Model.ListInputRoutingsResponse).
        /// Specifying the name of a property of type Amazon.IoTEvents.Model.ListInputRoutingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RoutedResources";
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
                context.Select = CreateSelectDelegate<Amazon.IoTEvents.Model.ListInputRoutingsResponse, GetIOTEInputRoutingListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IotEventsInputIdentifier_InputName = this.IotEventsInputIdentifier_InputName;
            context.IotSiteWiseAssetModelPropertyIdentifier_AssetModelId = this.IotSiteWiseAssetModelPropertyIdentifier_AssetModelId;
            context.IotSiteWiseAssetModelPropertyIdentifier_PropertyId = this.IotSiteWiseAssetModelPropertyIdentifier_PropertyId;
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
            var request = new Amazon.IoTEvents.Model.ListInputRoutingsRequest();
            
            
             // populate InputIdentifier
            var requestInputIdentifierIsNull = true;
            request.InputIdentifier = new Amazon.IoTEvents.Model.InputIdentifier();
            Amazon.IoTEvents.Model.IotEventsInputIdentifier requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier = null;
            
             // populate IotEventsInputIdentifier
            var requestInputIdentifier_inputIdentifier_IotEventsInputIdentifierIsNull = true;
            requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier = new Amazon.IoTEvents.Model.IotEventsInputIdentifier();
            System.String requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier_iotEventsInputIdentifier_InputName = null;
            if (cmdletContext.IotEventsInputIdentifier_InputName != null)
            {
                requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier_iotEventsInputIdentifier_InputName = cmdletContext.IotEventsInputIdentifier_InputName;
            }
            if (requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier_iotEventsInputIdentifier_InputName != null)
            {
                requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier.InputName = requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier_iotEventsInputIdentifier_InputName;
                requestInputIdentifier_inputIdentifier_IotEventsInputIdentifierIsNull = false;
            }
             // determine if requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier should be set to null
            if (requestInputIdentifier_inputIdentifier_IotEventsInputIdentifierIsNull)
            {
                requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier = null;
            }
            if (requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier != null)
            {
                request.InputIdentifier.IotEventsInputIdentifier = requestInputIdentifier_inputIdentifier_IotEventsInputIdentifier;
                requestInputIdentifierIsNull = false;
            }
            Amazon.IoTEvents.Model.IotSiteWiseInputIdentifier requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier = null;
            
             // populate IotSiteWiseInputIdentifier
            var requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifierIsNull = true;
            requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier = new Amazon.IoTEvents.Model.IotSiteWiseInputIdentifier();
            Amazon.IoTEvents.Model.IotSiteWiseAssetModelPropertyIdentifier requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier = null;
            
             // populate IotSiteWiseAssetModelPropertyIdentifier
            var requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifierIsNull = true;
            requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier = new Amazon.IoTEvents.Model.IotSiteWiseAssetModelPropertyIdentifier();
            System.String requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier_iotSiteWiseAssetModelPropertyIdentifier_AssetModelId = null;
            if (cmdletContext.IotSiteWiseAssetModelPropertyIdentifier_AssetModelId != null)
            {
                requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier_iotSiteWiseAssetModelPropertyIdentifier_AssetModelId = cmdletContext.IotSiteWiseAssetModelPropertyIdentifier_AssetModelId;
            }
            if (requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier_iotSiteWiseAssetModelPropertyIdentifier_AssetModelId != null)
            {
                requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier.AssetModelId = requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier_iotSiteWiseAssetModelPropertyIdentifier_AssetModelId;
                requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifierIsNull = false;
            }
            System.String requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier_iotSiteWiseAssetModelPropertyIdentifier_PropertyId = null;
            if (cmdletContext.IotSiteWiseAssetModelPropertyIdentifier_PropertyId != null)
            {
                requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier_iotSiteWiseAssetModelPropertyIdentifier_PropertyId = cmdletContext.IotSiteWiseAssetModelPropertyIdentifier_PropertyId;
            }
            if (requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier_iotSiteWiseAssetModelPropertyIdentifier_PropertyId != null)
            {
                requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier.PropertyId = requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier_iotSiteWiseAssetModelPropertyIdentifier_PropertyId;
                requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifierIsNull = false;
            }
             // determine if requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier should be set to null
            if (requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifierIsNull)
            {
                requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier = null;
            }
            if (requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier != null)
            {
                requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier.IotSiteWiseAssetModelPropertyIdentifier = requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier_IotSiteWiseAssetModelPropertyIdentifier;
                requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifierIsNull = false;
            }
             // determine if requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier should be set to null
            if (requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifierIsNull)
            {
                requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier = null;
            }
            if (requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier != null)
            {
                request.InputIdentifier.IotSiteWiseInputIdentifier = requestInputIdentifier_inputIdentifier_IotSiteWiseInputIdentifier;
                requestInputIdentifierIsNull = false;
            }
             // determine if request.InputIdentifier should be set to null
            if (requestInputIdentifierIsNull)
            {
                request.InputIdentifier = null;
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
        
        private Amazon.IoTEvents.Model.ListInputRoutingsResponse CallAWSServiceOperation(IAmazonIoTEvents client, Amazon.IoTEvents.Model.ListInputRoutingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Events", "ListInputRoutings");
            try
            {
                #if DESKTOP
                return client.ListInputRoutings(request);
                #elif CORECLR
                return client.ListInputRoutingsAsync(request).GetAwaiter().GetResult();
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
            public System.String IotEventsInputIdentifier_InputName { get; set; }
            public System.String IotSiteWiseAssetModelPropertyIdentifier_AssetModelId { get; set; }
            public System.String IotSiteWiseAssetModelPropertyIdentifier_PropertyId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IoTEvents.Model.ListInputRoutingsResponse, GetIOTEInputRoutingListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RoutedResources;
        }
        
    }
}
