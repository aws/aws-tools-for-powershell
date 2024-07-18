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
    /// Searches tags used in an Amazon Connect instance using optional search criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "CONNResourceTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.TagSet")]
    [AWSCmdlet("Calls the Amazon Connect Service SearchResourceTags API operation.", Operation = new[] {"SearchResourceTags"}, SelectReturnType = typeof(Amazon.Connect.Model.SearchResourceTagsResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.TagSet or Amazon.Connect.Model.SearchResourceTagsResponse",
        "This cmdlet returns a collection of Amazon.Connect.Model.TagSet objects.",
        "The service call response (type Amazon.Connect.Model.SearchResourceTagsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchCONNResourceTagCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can find the instanceId in the
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
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The list of resource types to be used to search tags from. If not provided or if any
        /// empty list is provided, this API will search from all supported resource types.</para><para><b>Supported resource types</b></para><ul><li><para>AGENT</para></li><li><para>ROUTING_PROFILE</para></li><li><para>STANDARD_QUEUE</para></li><li><para>SECURITY_PROFILE</para></li><li><para>OPERATING_HOURS</para></li><li><para>PROMPT</para></li><li><para>CONTACT_FLOW</para></li><li><para>FLOW_MODULE</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter TagSearchCondition_TagKey
        /// <summary>
        /// <para>
        /// <para>The tag key used in the tag search condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_TagSearchCondition_TagKey")]
        public System.String TagSearchCondition_TagKey { get; set; }
        #endregion
        
        #region Parameter TagSearchCondition_TagKeyComparisonType
        /// <summary>
        /// <para>
        /// <para>The type of comparison to be made when evaluating the tag key in tag search condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_TagSearchCondition_TagKeyComparisonType")]
        [AWSConstantClassSource("Amazon.Connect.StringComparisonType")]
        public Amazon.Connect.StringComparisonType TagSearchCondition_TagKeyComparisonType { get; set; }
        #endregion
        
        #region Parameter TagSearchCondition_TagValue
        /// <summary>
        /// <para>
        /// <para>The tag value used in the tag search condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_TagSearchCondition_TagValue")]
        public System.String TagSearchCondition_TagValue { get; set; }
        #endregion
        
        #region Parameter TagSearchCondition_TagValueComparisonType
        /// <summary>
        /// <para>
        /// <para>The type of comparison to be made when evaluating the tag value in tag search condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_TagSearchCondition_TagValueComparisonType")]
        [AWSConstantClassSource("Amazon.Connect.StringComparisonType")]
        public Amazon.Connect.StringComparisonType TagSearchCondition_TagValueComparisonType { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Tags'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.SearchResourceTagsResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.SearchResourceTagsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Tags";
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
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-CONNResourceTag (SearchResourceTags)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.SearchResourceTagsResponse, SearchCONNResourceTagCmdlet>(Select) ??
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
            if (this.ResourceType != null)
            {
                context.ResourceType = new List<System.String>(this.ResourceType);
            }
            context.TagSearchCondition_TagKey = this.TagSearchCondition_TagKey;
            context.TagSearchCondition_TagKeyComparisonType = this.TagSearchCondition_TagKeyComparisonType;
            context.TagSearchCondition_TagValue = this.TagSearchCondition_TagValue;
            context.TagSearchCondition_TagValueComparisonType = this.TagSearchCondition_TagValueComparisonType;
            
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
            var request = new Amazon.Connect.Model.SearchResourceTagsRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceTypes = cmdletContext.ResourceType;
            }
            
             // populate SearchCriteria
            var requestSearchCriteriaIsNull = true;
            request.SearchCriteria = new Amazon.Connect.Model.ResourceTagsSearchCriteria();
            Amazon.Connect.Model.TagSearchCondition requestSearchCriteria_searchCriteria_TagSearchCondition = null;
            
             // populate TagSearchCondition
            var requestSearchCriteria_searchCriteria_TagSearchConditionIsNull = true;
            requestSearchCriteria_searchCriteria_TagSearchCondition = new Amazon.Connect.Model.TagSearchCondition();
            System.String requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagKey = null;
            if (cmdletContext.TagSearchCondition_TagKey != null)
            {
                requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagKey = cmdletContext.TagSearchCondition_TagKey;
            }
            if (requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagKey != null)
            {
                requestSearchCriteria_searchCriteria_TagSearchCondition.TagKey = requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagKey;
                requestSearchCriteria_searchCriteria_TagSearchConditionIsNull = false;
            }
            Amazon.Connect.StringComparisonType requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagKeyComparisonType = null;
            if (cmdletContext.TagSearchCondition_TagKeyComparisonType != null)
            {
                requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagKeyComparisonType = cmdletContext.TagSearchCondition_TagKeyComparisonType;
            }
            if (requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagKeyComparisonType != null)
            {
                requestSearchCriteria_searchCriteria_TagSearchCondition.TagKeyComparisonType = requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagKeyComparisonType;
                requestSearchCriteria_searchCriteria_TagSearchConditionIsNull = false;
            }
            System.String requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagValue = null;
            if (cmdletContext.TagSearchCondition_TagValue != null)
            {
                requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagValue = cmdletContext.TagSearchCondition_TagValue;
            }
            if (requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagValue != null)
            {
                requestSearchCriteria_searchCriteria_TagSearchCondition.TagValue = requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagValue;
                requestSearchCriteria_searchCriteria_TagSearchConditionIsNull = false;
            }
            Amazon.Connect.StringComparisonType requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagValueComparisonType = null;
            if (cmdletContext.TagSearchCondition_TagValueComparisonType != null)
            {
                requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagValueComparisonType = cmdletContext.TagSearchCondition_TagValueComparisonType;
            }
            if (requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagValueComparisonType != null)
            {
                requestSearchCriteria_searchCriteria_TagSearchCondition.TagValueComparisonType = requestSearchCriteria_searchCriteria_TagSearchCondition_tagSearchCondition_TagValueComparisonType;
                requestSearchCriteria_searchCriteria_TagSearchConditionIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_TagSearchCondition should be set to null
            if (requestSearchCriteria_searchCriteria_TagSearchConditionIsNull)
            {
                requestSearchCriteria_searchCriteria_TagSearchCondition = null;
            }
            if (requestSearchCriteria_searchCriteria_TagSearchCondition != null)
            {
                request.SearchCriteria.TagSearchCondition = requestSearchCriteria_searchCriteria_TagSearchCondition;
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
        
        private Amazon.Connect.Model.SearchResourceTagsResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.SearchResourceTagsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "SearchResourceTags");
            try
            {
                #if DESKTOP
                return client.SearchResourceTags(request);
                #elif CORECLR
                return client.SearchResourceTagsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ResourceType { get; set; }
            public System.String TagSearchCondition_TagKey { get; set; }
            public Amazon.Connect.StringComparisonType TagSearchCondition_TagKeyComparisonType { get; set; }
            public System.String TagSearchCondition_TagValue { get; set; }
            public Amazon.Connect.StringComparisonType TagSearchCondition_TagValueComparisonType { get; set; }
            public System.Func<Amazon.Connect.Model.SearchResourceTagsResponse, SearchCONNResourceTagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Tags;
        }
        
    }
}
