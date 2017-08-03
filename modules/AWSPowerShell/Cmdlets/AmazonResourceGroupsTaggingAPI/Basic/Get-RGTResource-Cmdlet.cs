/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ResourceGroupsTaggingAPI;
using Amazon.ResourceGroupsTaggingAPI.Model;

namespace Amazon.PowerShell.Cmdlets.RGT
{
    /// <summary>
    /// Returns all the tagged resources that are associated with the specified tags (keys
    /// and values) located in the specified region for the AWS account. The tags and the
    /// resource types that you specify in the request are known as <i>filters</i>. The response
    /// includes all tags that are associated with the requested resources. If no filter is
    /// provided, this action returns a paginated resource list with the associated tags.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "RGTResource")]
    [OutputType("Amazon.ResourceGroupsTaggingAPI.Model.ResourceTagMapping")]
    [AWSCmdlet("Invokes the GetResources operation against AWS Resource Groups Tagging API.", Operation = new[] {"GetResources"})]
    [AWSCmdletOutput("Amazon.ResourceGroupsTaggingAPI.Model.ResourceTagMapping",
        "This cmdlet returns a collection of ResourceTagMapping objects.",
        "The service call response (type Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: PaginationToken (type System.String)"
    )]
    public partial class GetRGTResourceCmdlet : AmazonResourceGroupsTaggingAPIClientCmdlet, IExecutor
    {
        
        #region Parameter ResourcesPerPage
        /// <summary>
        /// <para>
        /// <para>A limit that restricts the number of resources returned by GetResources in paginated
        /// output. You can set ResourcesPerPage to a minimum of 1 item and the maximum of 50
        /// items. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ResourcesPerPage { get; set; }
        #endregion
        
        #region Parameter ResourceTypeFilter
        /// <summary>
        /// <para>
        /// <para>The constraints on the resources that you want returned. The format of each resource
        /// type is <code>service[:resourceType]</code>. For example, specifying a resource type
        /// of <code>ec2</code> returns all tagged Amazon EC2 resources (which includes tagged
        /// EC2 instances). Specifying a resource type of <code>ec2:instance</code> returns only
        /// EC2 instances. </para><para>The string for each service name and resource type is the same as that embedded in
        /// a resource's Amazon Resource Name (ARN). Consult the <i>AWS General Reference</i>
        /// for the following:</para><ul><li><para>For a list of service name strings, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#genref-aws-service-namespaces">AWS
        /// Service Namespaces</a>.</para></li><li><para>For resource type strings, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arns-syntax">Example
        /// ARNs</a>.</para></li><li><para>For more information about ARNs, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ResourceTypeFilters")]
        public System.String[] ResourceTypeFilter { get; set; }
        #endregion
        
        #region Parameter TagFilter
        /// <summary>
        /// <para>
        /// <para>A list of tags (keys and values). A request can include up to 50 keys, and each key
        /// can include up to 20 values.</para><para>If you specify multiple filters connected by an AND operator in a single request,
        /// the response returns only those resources that are associated with every specified
        /// filter.</para><para>If you specify multiple filters connected by an OR operator in a single request, the
        /// response returns all resources that are associated with at least one or possibly more
        /// of the specified filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagFilters")]
        public Amazon.ResourceGroupsTaggingAPI.Model.TagFilter[] TagFilter { get; set; }
        #endregion
        
        #region Parameter TagsPerPage
        /// <summary>
        /// <para>
        /// <para>A limit that restricts the number of tags (key and value pairs) returned by GetResources
        /// in paginated output. A resource with no tags is counted as having one tag (one key
        /// and value pair).</para><para><code>GetResources</code> does not split a resource and its associated tags across
        /// pages. If the specified <code>TagsPerPage</code> would cause such a break, a <code>PaginationToken</code>
        /// is returned in place of the affected resource and its tags. Use that token in another
        /// request to get the remaining data. For example, if you specify a <code>TagsPerPage</code>
        /// of <code>100</code> and the account has 22 resources with 10 tags each (meaning that
        /// each resource has 10 key and value pairs), the output will consist of 3 pages, with
        /// the first page displaying the first 10 resources, each with its 10 tags, the second
        /// page displaying the next 10 resources each with its 10 tags, and the third page displaying
        /// the remaining 2 resources, each with its 10 tags.</para><para>You can set <code>TagsPerPage</code> to a minimum of 100 items and the maximum of
        /// 500 items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int TagsPerPage { get; set; }
        #endregion
        
        #region Parameter PaginationToken
        /// <summary>
        /// <para>
        /// <para>A string that indicates that additional data is available. Leave this value empty
        /// for your initial request. If the response includes a <code>PaginationToken</code>,
        /// use that string for this value to request an additional page of data.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String PaginationToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.PaginationToken = this.PaginationToken;
            if (ParameterWasBound("ResourcesPerPage"))
                context.ResourcesPerPage = this.ResourcesPerPage;
            if (this.ResourceTypeFilter != null)
            {
                context.ResourceTypeFilters = new List<System.String>(this.ResourceTypeFilter);
            }
            if (this.TagFilter != null)
            {
                context.TagFilters = new List<Amazon.ResourceGroupsTaggingAPI.Model.TagFilter>(this.TagFilter);
            }
            if (ParameterWasBound("TagsPerPage"))
                context.TagsPerPage = this.TagsPerPage;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesRequest();
            if (cmdletContext.ResourcesPerPage != null)
            {
                request.ResourcesPerPage = cmdletContext.ResourcesPerPage.Value;
            }
            if (cmdletContext.ResourceTypeFilters != null)
            {
                request.ResourceTypeFilters = cmdletContext.ResourceTypeFilters;
            }
            if (cmdletContext.TagFilters != null)
            {
                request.TagFilters = cmdletContext.TagFilters;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 100;
            if (AutoIterationHelpers.HasValue(cmdletContext.PaginationToken))
            {
                _nextMarker = cmdletContext.PaginationToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.TagsPerPage))
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.TagsPerPage;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.PaginationToken) || AutoIterationHelpers.HasValue(cmdletContext.TagsPerPage);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.PaginationToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.TagsPerPage = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.TagsPerPage))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.TagsPerPage);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.TagsPerPage = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.ResourceTagMappingList;
                        notes = new Dictionary<string, object>();
                        notes["PaginationToken"] = response.PaginationToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ResourceTagMappingList.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.PaginationToken));
                        }
                        
                        _nextMarker = response.PaginationToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    // The service has a maximum page size of 100 and the user has set a retrieval limit.
                    // Deduce what's left to fetch and if less than one page update _emitLimit to fetch just
                    // what's left to match the user's request.
                    
                    var _remainingItems = _emitLimit - _retrievedSoFar;
                    if (_remainingItems < _pageSize)
                    {
                        _emitLimit = _remainingItems;
                    }
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse CallAWSServiceOperation(IAmazonResourceGroupsTaggingAPI client, Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Groups Tagging API", "GetResources");
            #if DESKTOP
            return client.GetResources(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetResourcesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String PaginationToken { get; set; }
            public System.Int32? ResourcesPerPage { get; set; }
            public List<System.String> ResourceTypeFilters { get; set; }
            public List<Amazon.ResourceGroupsTaggingAPI.Model.TagFilter> TagFilters { get; set; }
            public int? TagsPerPage { get; set; }
        }
        
    }
}
