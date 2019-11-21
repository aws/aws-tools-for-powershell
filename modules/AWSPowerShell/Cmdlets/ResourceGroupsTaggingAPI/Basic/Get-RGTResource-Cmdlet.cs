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
using Amazon.ResourceGroupsTaggingAPI;
using Amazon.ResourceGroupsTaggingAPI.Model;

namespace Amazon.PowerShell.Cmdlets.RGT
{
    /// <summary>
    /// Returns all the tagged or previously tagged resources that are located in the specified
    /// region for the AWS account. You can optionally specify <i>filters</i> (tags and resource
    /// types) in your request, depending on what information you want returned. The response
    /// includes all tags that are associated with the requested resources.
    /// 
    ///  <note><para>
    /// You can check the <code>PaginationToken</code> response parameter to determine if
    /// a query completed. Queries can occasionally return fewer results on a page than allowed.
    /// The <code>PaginationToken</code> response parameter value is <code>null</code><i>only</i>
    /// when there are no more results to display. 
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RGTResource")]
    [OutputType("Amazon.ResourceGroupsTaggingAPI.Model.ResourceTagMapping")]
    [AWSCmdlet("Calls the AWS Resource Groups Tagging API GetResources API operation.", Operation = new[] {"GetResources"}, SelectReturnType = typeof(Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse))]
    [AWSCmdletOutput("Amazon.ResourceGroupsTaggingAPI.Model.ResourceTagMapping or Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse",
        "This cmdlet returns a collection of Amazon.ResourceGroupsTaggingAPI.Model.ResourceTagMapping objects.",
        "The service call response (type Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRGTResourceCmdlet : AmazonResourceGroupsTaggingAPIClientCmdlet, IExecutor
    {
        
        #region Parameter ResourcesPerPage
        /// <summary>
        /// <para>
        /// <para>A limit that restricts the number of resources returned by GetResources in paginated
        /// output. You can set ResourcesPerPage to a minimum of 1 item and the maximum of 100
        /// items. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourcesPerPage { get; set; }
        #endregion
        
        #region Parameter ResourceTypeFilter
        /// <summary>
        /// <para>
        /// <para>The constraints on the resources that you want returned. The format of each resource
        /// type is <code>service[:resourceType]</code>. For example, specifying a resource type
        /// of <code>ec2</code> returns all Amazon EC2 resources (which includes EC2 instances).
        /// Specifying a resource type of <code>ec2:instance</code> returns only EC2 instances.
        /// </para><para>The string for each service name and resource type is the same as that embedded in
        /// a resource's Amazon Resource Name (ARN). Consult the <i>AWS General Reference</i>
        /// for the following:</para><ul><li><para>For a list of service name strings, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#genref-aws-service-namespaces">AWS
        /// Service Namespaces</a>.</para></li><li><para>For resource type strings, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arns-syntax">Example
        /// ARNs</a>.</para></li><li><para>For more information about ARNs, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>.</para></li></ul><para>You can specify multiple resource types by using an array. The array can include up
        /// to 100 items. Note that the length constraint requirement applies to each resource
        /// type filter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ResourceTypeFilters")]
        public System.String[] ResourceTypeFilter { get; set; }
        #endregion
        
        #region Parameter TagFilter
        /// <summary>
        /// <para>
        /// <para>A list of TagFilters (keys and values). Each TagFilter specified must contain a key
        /// with values as optional. A request can include up to 50 keys, and each key can include
        /// up to 20 values. </para><para>Note the following when deciding how to use TagFilters:</para><ul><li><para>If you <i>do</i> specify a TagFilter, the response returns only those resources that
        /// are currently associated with the specified tag. </para></li><li><para>If you <i>don't</i> specify a TagFilter, the response includes all resources that
        /// were ever associated with tags. Resources that currently don't have associated tags
        /// are shown with an empty tag set, like this: <code>"Tags": []</code>.</para></li><li><para>If you specify more than one filter in a single request, the response returns only
        /// those resources that satisfy all specified filters.</para></li><li><para>If you specify a filter that contains more than one value for a key, the response
        /// returns resources that match any of the specified values for that key.</para></li><li><para>If you don't specify any values for a key, the response returns resources that are
        /// tagged with that key irrespective of the value.</para><para>For example, for filters: filter1 = {key1, {value1}}, filter2 = {key2, {value2,value3,value4}}
        /// , filter3 = {key3}:</para><ul><li><para>GetResources( {filter1} ) returns resources tagged with key1=value1</para></li><li><para>GetResources( {filter2} ) returns resources tagged with key2=value2 or key2=value3
        /// or key2=value4</para></li><li><para>GetResources( {filter3} ) returns resources tagged with any tag containing key3 as
        /// its tag key, irrespective of its value</para></li><li><para>GetResources( {filter1,filter2,filter3} ) returns resources tagged with ( key1=value1)
        /// and ( key2=value2 or key2=value3 or key2=value4) and (key3, irrespective of the value)</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.Int32? TagsPerPage { get; set; }
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
        /// <br/>In order to manually control output pagination, use '-PaginationToken $null' for the first call and '-PaginationToken $AWSHistory.LastServiceResponse.PaginationToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String PaginationToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceTagMappingList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse).
        /// Specifying the name of a property of type Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceTagMappingList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceTypeFilter parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceTypeFilter' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceTypeFilter' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of PaginationToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse, GetRGTResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceTypeFilter;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PaginationToken = this.PaginationToken;
            context.ResourcesPerPage = this.ResourcesPerPage;
            if (this.ResourceTypeFilter != null)
            {
                context.ResourceTypeFilter = new List<System.String>(this.ResourceTypeFilter);
            }
            if (this.TagFilter != null)
            {
                context.TagFilter = new List<Amazon.ResourceGroupsTaggingAPI.Model.TagFilter>(this.TagFilter);
            }
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesRequest();
            
            if (cmdletContext.ResourcesPerPage != null)
            {
                request.ResourcesPerPage = cmdletContext.ResourcesPerPage.Value;
            }
            if (cmdletContext.ResourceTypeFilter != null)
            {
                request.ResourceTypeFilters = cmdletContext.ResourceTypeFilter;
            }
            if (cmdletContext.TagFilter != null)
            {
                request.TagFilters = cmdletContext.TagFilter;
            }
            if (cmdletContext.TagsPerPage != null)
            {
                request.TagsPerPage = cmdletContext.TagsPerPage.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.PaginationToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.PaginationToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.PaginationToken = _nextToken;
                
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
                    
                    _nextToken = response.PaginationToken;
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
        
        private Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse CallAWSServiceOperation(IAmazonResourceGroupsTaggingAPI client, Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Groups Tagging API", "GetResources");
            try
            {
                #if DESKTOP
                return client.GetResources(request);
                #elif CORECLR
                return client.GetResourcesAsync(request).GetAwaiter().GetResult();
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
            public System.String PaginationToken { get; set; }
            public System.Int32? ResourcesPerPage { get; set; }
            public List<System.String> ResourceTypeFilter { get; set; }
            public List<Amazon.ResourceGroupsTaggingAPI.Model.TagFilter> TagFilter { get; set; }
            public System.Int32? TagsPerPage { get; set; }
            public System.Func<Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse, GetRGTResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceTagMappingList;
        }
        
    }
}
