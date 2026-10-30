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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Provides a list of analysis segments for a real-time chat analysis session. This API
    /// supports CHAT channels only. 
    /// 
    ///  <important><para>
    /// This API does not support VOICE. If you attempt to use it for VOICE, an <c>InvalidRequestException</c>
    /// occurs.
    /// </para></important><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CONNRealtimeContactAnalysisSegmentsV2List")]
    [OutputType("Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Response")]
    [AWSCmdlet("Calls the Amazon Connect Service ListRealtimeContactAnalysisSegmentsV2 API operation.", Operation = new[] {"ListRealtimeContactAnalysisSegmentsV2"}, SelectReturnType = typeof(Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Response))]
    [AWSCmdletOutput("Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Response",
        "This cmdlet returns an Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Response object containing multiple properties."
    )]
    public partial class GetCONNRealtimeContactAnalysisSegmentsV2ListCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact in this instance of Connect Customer. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ContactId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter ListFilter_CategoriesAttributeFilter_OrCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions that the filter evaluates using OR logic. A category segment
        /// matches when at least one of the conditions in the list is met.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ListFilter_CategoriesAttributeFilter_OrConditions")]
        public Amazon.Connect.Model.CategoriesAttributeAndCondition[] ListFilter_CategoriesAttributeFilter_OrCondition { get; set; }
        #endregion
        
        #region Parameter OutputType
        /// <summary>
        /// <para>
        /// <para>The Contact Lens output type to be returned.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.RealTimeContactAnalysisOutputType")]
        public Amazon.Connect.RealTimeContactAnalysisOutputType OutputType { get; set; }
        #endregion
        
        #region Parameter SegmentType
        /// <summary>
        /// <para>
        /// <para>Enum with segment types . Each value corresponds to a segment type returned in the
        /// segments list of the API. Each segment type has its own structure. Different channels
        /// may have different sets of supported segment types.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SegmentTypes")]
        public System.String[] SegmentType { get; set; }
        #endregion
        
        #region Parameter ListFilter_CategoriesAttributeFilter_AndCondition_TagCondition
        /// <summary>
        /// <para>
        /// <para>A list of tag conditions. All of the tag conditions must be met for the condition
        /// to match.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ListFilter_CategoriesAttributeFilter_AndCondition_TagConditions")]
        public Amazon.Connect.Model.TagCondition[] ListFilter_CategoriesAttributeFilter_AndCondition_TagCondition { get; set; }
        #endregion
        
        #region Parameter ListFilter_CategoriesAttributeFilter_TagCondition_TagKey
        /// <summary>
        /// <para>
        /// <para>The tag key in the tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ListFilter_CategoriesAttributeFilter_TagCondition_TagKey { get; set; }
        #endregion
        
        #region Parameter ListFilter_CategoriesAttributeFilter_TagCondition_TagValue
        /// <summary>
        /// <para>
        /// <para>The tag value in the tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ListFilter_CategoriesAttributeFilter_TagCondition_TagValue { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Response).
        /// Specifying the name of a property of type Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Response, GetCONNRealtimeContactAnalysisSegmentsV2ListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContactId = this.ContactId;
            #if MODULAR
            if (this.ContactId == null && ParameterWasBound(nameof(this.ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ListFilter_CategoriesAttributeFilter_AndCondition_TagCondition != null)
            {
                context.ListFilter_CategoriesAttributeFilter_AndCondition_TagCondition = new List<Amazon.Connect.Model.TagCondition>(this.ListFilter_CategoriesAttributeFilter_AndCondition_TagCondition);
            }
            if (this.ListFilter_CategoriesAttributeFilter_OrCondition != null)
            {
                context.ListFilter_CategoriesAttributeFilter_OrCondition = new List<Amazon.Connect.Model.CategoriesAttributeAndCondition>(this.ListFilter_CategoriesAttributeFilter_OrCondition);
            }
            context.ListFilter_CategoriesAttributeFilter_TagCondition_TagKey = this.ListFilter_CategoriesAttributeFilter_TagCondition_TagKey;
            context.ListFilter_CategoriesAttributeFilter_TagCondition_TagValue = this.ListFilter_CategoriesAttributeFilter_TagCondition_TagValue;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OutputType = this.OutputType;
            #if MODULAR
            if (this.OutputType == null && ParameterWasBound(nameof(this.OutputType)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SegmentType != null)
            {
                context.SegmentType = new List<System.String>(this.SegmentType);
            }
            #if MODULAR
            if (this.SegmentType == null && ParameterWasBound(nameof(this.SegmentType)))
            {
                WriteWarning("You are passing $null as a value for parameter SegmentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Request();
            
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate ListFilter
            var requestListFilterIsNull = true;
            request.ListFilter = new Amazon.Connect.Model.RealTimeContactAnalysisSegmentsFilter();
            Amazon.Connect.Model.CategoriesAttributeFilter requestListFilter_listFilter_CategoriesAttributeFilter = null;
            
             // populate CategoriesAttributeFilter
            var requestListFilter_listFilter_CategoriesAttributeFilterIsNull = true;
            requestListFilter_listFilter_CategoriesAttributeFilter = new Amazon.Connect.Model.CategoriesAttributeFilter();
            List<Amazon.Connect.Model.CategoriesAttributeAndCondition> requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_OrCondition = null;
            if (cmdletContext.ListFilter_CategoriesAttributeFilter_OrCondition != null)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_OrCondition = cmdletContext.ListFilter_CategoriesAttributeFilter_OrCondition;
            }
            if (requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_OrCondition != null)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter.OrConditions = requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_OrCondition;
                requestListFilter_listFilter_CategoriesAttributeFilterIsNull = false;
            }
            Amazon.Connect.Model.CategoriesAttributeAndCondition requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition = null;
            
             // populate AndCondition
            var requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndConditionIsNull = true;
            requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition = new Amazon.Connect.Model.CategoriesAttributeAndCondition();
            List<Amazon.Connect.Model.TagCondition> requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition_listFilter_CategoriesAttributeFilter_AndCondition_TagCondition = null;
            if (cmdletContext.ListFilter_CategoriesAttributeFilter_AndCondition_TagCondition != null)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition_listFilter_CategoriesAttributeFilter_AndCondition_TagCondition = cmdletContext.ListFilter_CategoriesAttributeFilter_AndCondition_TagCondition;
            }
            if (requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition_listFilter_CategoriesAttributeFilter_AndCondition_TagCondition != null)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition.TagConditions = requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition_listFilter_CategoriesAttributeFilter_AndCondition_TagCondition;
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndConditionIsNull = false;
            }
             // determine if requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition should be set to null
            if (requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndConditionIsNull)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition = null;
            }
            if (requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition != null)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter.AndCondition = requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_AndCondition;
                requestListFilter_listFilter_CategoriesAttributeFilterIsNull = false;
            }
            Amazon.Connect.Model.TagCondition requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition = null;
            
             // populate TagCondition
            var requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagConditionIsNull = true;
            requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition = new Amazon.Connect.Model.TagCondition();
            System.String requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition_listFilter_CategoriesAttributeFilter_TagCondition_TagKey = null;
            if (cmdletContext.ListFilter_CategoriesAttributeFilter_TagCondition_TagKey != null)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition_listFilter_CategoriesAttributeFilter_TagCondition_TagKey = cmdletContext.ListFilter_CategoriesAttributeFilter_TagCondition_TagKey;
            }
            if (requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition_listFilter_CategoriesAttributeFilter_TagCondition_TagKey != null)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition.TagKey = requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition_listFilter_CategoriesAttributeFilter_TagCondition_TagKey;
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagConditionIsNull = false;
            }
            System.String requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition_listFilter_CategoriesAttributeFilter_TagCondition_TagValue = null;
            if (cmdletContext.ListFilter_CategoriesAttributeFilter_TagCondition_TagValue != null)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition_listFilter_CategoriesAttributeFilter_TagCondition_TagValue = cmdletContext.ListFilter_CategoriesAttributeFilter_TagCondition_TagValue;
            }
            if (requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition_listFilter_CategoriesAttributeFilter_TagCondition_TagValue != null)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition.TagValue = requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition_listFilter_CategoriesAttributeFilter_TagCondition_TagValue;
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagConditionIsNull = false;
            }
             // determine if requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition should be set to null
            if (requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagConditionIsNull)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition = null;
            }
            if (requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition != null)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter.TagCondition = requestListFilter_listFilter_CategoriesAttributeFilter_listFilter_CategoriesAttributeFilter_TagCondition;
                requestListFilter_listFilter_CategoriesAttributeFilterIsNull = false;
            }
             // determine if requestListFilter_listFilter_CategoriesAttributeFilter should be set to null
            if (requestListFilter_listFilter_CategoriesAttributeFilterIsNull)
            {
                requestListFilter_listFilter_CategoriesAttributeFilter = null;
            }
            if (requestListFilter_listFilter_CategoriesAttributeFilter != null)
            {
                request.ListFilter.CategoriesAttributeFilter = requestListFilter_listFilter_CategoriesAttributeFilter;
                requestListFilterIsNull = false;
            }
             // determine if request.ListFilter should be set to null
            if (requestListFilterIsNull)
            {
                request.ListFilter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.OutputType != null)
            {
                request.OutputType = cmdletContext.OutputType;
            }
            if (cmdletContext.SegmentType != null)
            {
                request.SegmentTypes = cmdletContext.SegmentType;
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
        
        private Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Response CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "ListRealtimeContactAnalysisSegmentsV2");
            try
            {
                return client.ListRealtimeContactAnalysisSegmentsV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContactId { get; set; }
            public System.String InstanceId { get; set; }
            public List<Amazon.Connect.Model.TagCondition> ListFilter_CategoriesAttributeFilter_AndCondition_TagCondition { get; set; }
            public List<Amazon.Connect.Model.CategoriesAttributeAndCondition> ListFilter_CategoriesAttributeFilter_OrCondition { get; set; }
            public System.String ListFilter_CategoriesAttributeFilter_TagCondition_TagKey { get; set; }
            public System.String ListFilter_CategoriesAttributeFilter_TagCondition_TagValue { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Connect.RealTimeContactAnalysisOutputType OutputType { get; set; }
            public List<System.String> SegmentType { get; set; }
            public System.Func<Amazon.Connect.Model.ListRealtimeContactAnalysisSegmentsV2Response, GetCONNRealtimeContactAnalysisSegmentsV2ListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
