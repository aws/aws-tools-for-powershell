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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Predefined attributes that meet certain criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "CONNPredefinedAttribute")]
    [OutputType("Amazon.Connect.Model.SearchPredefinedAttributesResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service SearchPredefinedAttributes API operation.", Operation = new[] {"SearchPredefinedAttributes"}, SelectReturnType = typeof(Amazon.Connect.Model.SearchPredefinedAttributesResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.SearchPredefinedAttributesResponse",
        "This cmdlet returns an Amazon.Connect.Model.SearchPredefinedAttributesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchCONNPredefinedAttributeCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SearchCriteria_AndCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions which would be applied together with an <code>AND</code> condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_AndConditions")]
        public Amazon.Connect.Model.PredefinedAttributeSearchCriteria[] SearchCriteria_AndCondition { get; set; }
        #endregion
        
        #region Parameter StringCondition_ComparisonType
        /// <summary>
        /// <para>
        /// <para>The type of comparison to be made when evaluating the string condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_StringCondition_ComparisonType")]
        [AWSConstantClassSource("Amazon.Connect.StringComparisonType")]
        public Amazon.Connect.StringComparisonType StringCondition_ComparisonType { get; set; }
        #endregion
        
        #region Parameter StringCondition_FieldName
        /// <summary>
        /// <para>
        /// <para>The name of the field in the string condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_StringCondition_FieldName")]
        public System.String StringCondition_FieldName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can find the instance ID in the
        /// Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_OrCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions which would be applied together with an <code>OR</code> condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_OrConditions")]
        public Amazon.Connect.Model.PredefinedAttributeSearchCriteria[] SearchCriteria_OrCondition { get; set; }
        #endregion
        
        #region Parameter StringCondition_Value
        /// <summary>
        /// <para>
        /// <para>The value of the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_StringCondition_Value")]
        public System.String StringCondition_Value { get; set; }
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
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.SearchPredefinedAttributesResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.SearchPredefinedAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.SearchPredefinedAttributesResponse, SearchCONNPredefinedAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SearchCriteria_AndCondition != null)
            {
                context.SearchCriteria_AndCondition = new List<Amazon.Connect.Model.PredefinedAttributeSearchCriteria>(this.SearchCriteria_AndCondition);
            }
            if (this.SearchCriteria_OrCondition != null)
            {
                context.SearchCriteria_OrCondition = new List<Amazon.Connect.Model.PredefinedAttributeSearchCriteria>(this.SearchCriteria_OrCondition);
            }
            context.StringCondition_ComparisonType = this.StringCondition_ComparisonType;
            context.StringCondition_FieldName = this.StringCondition_FieldName;
            context.StringCondition_Value = this.StringCondition_Value;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Connect.Model.SearchPredefinedAttributesRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate SearchCriteria
            var requestSearchCriteriaIsNull = true;
            request.SearchCriteria = new Amazon.Connect.Model.PredefinedAttributeSearchCriteria();
            List<Amazon.Connect.Model.PredefinedAttributeSearchCriteria> requestSearchCriteria_searchCriteria_AndCondition = null;
            if (cmdletContext.SearchCriteria_AndCondition != null)
            {
                requestSearchCriteria_searchCriteria_AndCondition = cmdletContext.SearchCriteria_AndCondition;
            }
            if (requestSearchCriteria_searchCriteria_AndCondition != null)
            {
                request.SearchCriteria.AndConditions = requestSearchCriteria_searchCriteria_AndCondition;
                requestSearchCriteriaIsNull = false;
            }
            List<Amazon.Connect.Model.PredefinedAttributeSearchCriteria> requestSearchCriteria_searchCriteria_OrCondition = null;
            if (cmdletContext.SearchCriteria_OrCondition != null)
            {
                requestSearchCriteria_searchCriteria_OrCondition = cmdletContext.SearchCriteria_OrCondition;
            }
            if (requestSearchCriteria_searchCriteria_OrCondition != null)
            {
                request.SearchCriteria.OrConditions = requestSearchCriteria_searchCriteria_OrCondition;
                requestSearchCriteriaIsNull = false;
            }
            Amazon.Connect.Model.StringCondition requestSearchCriteria_searchCriteria_StringCondition = null;
            
             // populate StringCondition
            var requestSearchCriteria_searchCriteria_StringConditionIsNull = true;
            requestSearchCriteria_searchCriteria_StringCondition = new Amazon.Connect.Model.StringCondition();
            Amazon.Connect.StringComparisonType requestSearchCriteria_searchCriteria_StringCondition_stringCondition_ComparisonType = null;
            if (cmdletContext.StringCondition_ComparisonType != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition_stringCondition_ComparisonType = cmdletContext.StringCondition_ComparisonType;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition_stringCondition_ComparisonType != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition.ComparisonType = requestSearchCriteria_searchCriteria_StringCondition_stringCondition_ComparisonType;
                requestSearchCriteria_searchCriteria_StringConditionIsNull = false;
            }
            System.String requestSearchCriteria_searchCriteria_StringCondition_stringCondition_FieldName = null;
            if (cmdletContext.StringCondition_FieldName != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition_stringCondition_FieldName = cmdletContext.StringCondition_FieldName;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition_stringCondition_FieldName != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition.FieldName = requestSearchCriteria_searchCriteria_StringCondition_stringCondition_FieldName;
                requestSearchCriteria_searchCriteria_StringConditionIsNull = false;
            }
            System.String requestSearchCriteria_searchCriteria_StringCondition_stringCondition_Value = null;
            if (cmdletContext.StringCondition_Value != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition_stringCondition_Value = cmdletContext.StringCondition_Value;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition_stringCondition_Value != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition.Value = requestSearchCriteria_searchCriteria_StringCondition_stringCondition_Value;
                requestSearchCriteria_searchCriteria_StringConditionIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_StringCondition should be set to null
            if (requestSearchCriteria_searchCriteria_StringConditionIsNull)
            {
                requestSearchCriteria_searchCriteria_StringCondition = null;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition != null)
            {
                request.SearchCriteria.StringCondition = requestSearchCriteria_searchCriteria_StringCondition;
                requestSearchCriteriaIsNull = false;
            }
             // determine if request.SearchCriteria should be set to null
            if (requestSearchCriteriaIsNull)
            {
                request.SearchCriteria = null;
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
        
        private Amazon.Connect.Model.SearchPredefinedAttributesResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.SearchPredefinedAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "SearchPredefinedAttributes");
            try
            {
                #if DESKTOP
                return client.SearchPredefinedAttributes(request);
                #elif CORECLR
                return client.SearchPredefinedAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.Connect.Model.PredefinedAttributeSearchCriteria> SearchCriteria_AndCondition { get; set; }
            public List<Amazon.Connect.Model.PredefinedAttributeSearchCriteria> SearchCriteria_OrCondition { get; set; }
            public Amazon.Connect.StringComparisonType StringCondition_ComparisonType { get; set; }
            public System.String StringCondition_FieldName { get; set; }
            public System.String StringCondition_Value { get; set; }
            public System.Func<Amazon.Connect.Model.SearchPredefinedAttributesResponse, SearchCONNPredefinedAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
