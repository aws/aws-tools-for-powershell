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
using Amazon.ResourceGroupsTaggingAPI;
using Amazon.ResourceGroupsTaggingAPI.Model;

namespace Amazon.PowerShell.Cmdlets.RGT
{
    /// <summary>
    /// Returns all the tagged or previously tagged resources that are located in the specified
    /// Amazon Web Services Region for the account.
    /// 
    ///  
    /// <para>
    /// Depending on what information you want returned, you can also specify the following:
    /// </para><ul><li><para><i>Filters</i> that specify what tags and resource types you want returned. The response
    /// includes all tags that are associated with the requested resources.
    /// </para></li><li><para>
    /// Information about compliance with the account's effective tag policy. For more information
    /// on tag policies, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_policies_tag-policies.html">Tag
    /// Policies</a> in the <i>Organizations User Guide.</i></para></li></ul><para>
    /// This operation supports pagination, where the response can be sent in multiple pages.
    /// You should check the <c>PaginationToken</c> response parameter to determine if there
    /// are additional results available to return. Repeat the query, passing the <c>PaginationToken</c>
    /// response parameter value as an input to the next request until you recieve a <c>null</c>
    /// value. A null value for <c>PaginationToken</c> indicates that there are no more results
    /// waiting to be returned.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RGTResource")]
    [OutputType("Amazon.ResourceGroupsTaggingAPI.Model.ResourceTagMapping")]
    [AWSCmdlet("Calls the AWS Resource Groups Tagging API GetResources API operation.", Operation = new[] {"GetResources"}, SelectReturnType = typeof(Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse))]
    [AWSCmdletOutput("Amazon.ResourceGroupsTaggingAPI.Model.ResourceTagMapping or Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse",
        "This cmdlet returns a collection of Amazon.ResourceGroupsTaggingAPI.Model.ResourceTagMapping objects.",
        "The service call response (type Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRGTResourceCmdlet : AmazonResourceGroupsTaggingAPIClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExcludeCompliantResource
        /// <summary>
        /// <para>
        /// <para>Specifies whether to exclude resources that are compliant with the tag policy. Set
        /// this to <c>true</c> if you are interested in retrieving information on noncompliant
        /// resources only.</para><para>You can use this parameter only if the <c>IncludeComplianceDetails</c> parameter is
        /// also set to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludeCompliantResources")]
        public System.Boolean? ExcludeCompliantResource { get; set; }
        #endregion
        
        #region Parameter IncludeComplianceDetail
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include details regarding the compliance with the effective tag
        /// policy. Set this to <c>true</c> to determine whether resources are compliant with
        /// the tag policy and to get details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeComplianceDetails")]
        public System.Boolean? IncludeComplianceDetail { get; set; }
        #endregion
        
        #region Parameter ResourceARNList
        /// <summary>
        /// <para>
        /// <para>Specifies a list of ARNs of resources for which you want to retrieve tag data. You
        /// can't specify both this parameter and any of the pagination parameters (<c>ResourcesPerPage</c>,
        /// <c>TagsPerPage</c>, <c>PaginationToken</c>) in the same request. If you specify both,
        /// you get an <c>Invalid Parameter</c> exception.</para><para>If a resource specified by this parameter doesn't exist, it doesn't generate an error;
        /// it simply isn't included in the response.</para><para>An ARN (Amazon Resource Name) uniquely identifies a resource. For more information,
        /// see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a> in the <i>Amazon
        /// Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ResourceARNList { get; set; }
        #endregion
        
        #region Parameter ResourcesPerPage
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of results to be returned in each page. A query can return
        /// fewer than this maximum, even if there are more results still to return. You should
        /// always check the <c>PaginationToken</c> response value to see if there are more results.
        /// You can specify a minimum of 1 and a maximum value of 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourcesPerPage { get; set; }
        #endregion
        
        #region Parameter ResourceTypeFilter
        /// <summary>
        /// <para>
        /// <para>Specifies the resource types that you want included in the response. The format of
        /// each resource type is <c>service[:resourceType]</c>. For example, specifying a resource
        /// type of <c>ec2</c> returns all Amazon EC2 resources (which includes EC2 instances).
        /// Specifying a resource type of <c>ec2:instance</c> returns only EC2 instances. </para><para>The string for each service name and resource type is the same as that embedded in
        /// a resource's Amazon Resource Name (ARN). For the list of services whose resources
        /// you can use in this parameter, see <a href="https://docs.aws.amazon.com/resourcegroupstagging/latest/APIReference/supported-services.html">Services
        /// that support the Resource Groups Tagging API</a>.</para><para>You can specify multiple resource types by using an array. The array can include up
        /// to 100 items. Note that the length constraint requirement applies to each resource
        /// type filter. For example, the following string would limit the response to only Amazon
        /// EC2 instances, Amazon S3 buckets, or any Audit Manager resource:</para><para><c>ec2:instance,s3:bucket,auditmanager</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ResourceTypeFilters")]
        public System.String[] ResourceTypeFilter { get; set; }
        #endregion
        
        #region Parameter TagFilter
        /// <summary>
        /// <para>
        /// <para>Specifies a list of TagFilters (keys and values) to restrict the output to only those
        /// resources that have tags with the specified keys and, if included, the specified values.
        /// Each <c>TagFilter</c> must contain a key with values optional. A request can include
        /// up to 50 keys, and each key can include up to 20 values. </para><para>Note the following when deciding how to use TagFilters:</para><ul><li><para>If you <i>don't</i> specify a <c>TagFilter</c>, the response includes all resources
        /// that are currently tagged or ever had a tag. Resources that currently don't have tags
        /// are shown with an empty tag set, like this: <c>"Tags": []</c>.</para></li><li><para>If you specify more than one filter in a single request, the response returns only
        /// those resources that satisfy all filters.</para></li><li><para>If you specify a filter that contains more than one value for a key, the response
        /// returns resources that match <i>any</i> of the specified values for that key.</para></li><li><para>If you don't specify a value for a key, the response returns all resources that are
        /// tagged with that key, with any or no value.</para><para>For example, for the following filters: <c>filter1= {keyA,{value1}}</c>, <c>filter2={keyB,{value2,value3,value4}}</c>,
        /// <c>filter3= {keyC}</c>:</para><ul><li><para><c>GetResources({filter1})</c> returns resources tagged with <c>key1=value1</c></para></li><li><para><c>GetResources({filter2})</c> returns resources tagged with <c>key2=value2</c> or
        /// <c>key2=value3</c> or <c>key2=value4</c></para></li><li><para><c>GetResources({filter3})</c> returns resources tagged with any tag with the key
        /// <c>key3</c>, and with any or no value</para></li><li><para><c>GetResources({filter1,filter2,filter3})</c> returns resources tagged with <c>(key1=value1)
        /// and (key2=value2 or key2=value3 or key2=value4) and (key3, any or no value)</c></para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagFilters")]
        public Amazon.ResourceGroupsTaggingAPI.Model.TagFilter[] TagFilter { get; set; }
        #endregion
        
        #region Parameter TagsPerPage
        /// <summary>
        /// <para>
        /// <para>Amazon Web Services recommends using <c>ResourcesPerPage</c> instead of this parameter.</para><para>A limit that restricts the number of tags (key and value pairs) returned by <c>GetResources</c>
        /// in paginated output. A resource with no tags is counted as having one tag (one key
        /// and value pair).</para><para><c>GetResources</c> does not split a resource and its associated tags across pages.
        /// If the specified <c>TagsPerPage</c> would cause such a break, a <c>PaginationToken</c>
        /// is returned in place of the affected resource and its tags. Use that token in another
        /// request to get the remaining data. For example, if you specify a <c>TagsPerPage</c>
        /// of <c>100</c> and the account has 22 resources with 10 tags each (meaning that each
        /// resource has 10 key and value pairs), the output will consist of three pages. The
        /// first page displays the first 10 resources, each with its 10 tags. The second page
        /// displays the next 10 resources, each with its 10 tags. The third page displays the
        /// remaining 2 resources, each with its 10 tags.</para><para>You can set <c>TagsPerPage</c> to a minimum of 100 items up to a maximum of 500 items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.Int32? TagsPerPage { get; set; }
        #endregion
        
        #region Parameter PaginationToken
        /// <summary>
        /// <para>
        /// <para>Specifies a <c>PaginationToken</c> response value from a previous request to indicate
        /// that you want the next page of results. Leave this parameter empty in your initial
        /// request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'PaginationToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-PaginationToken' to null for the first call then set the 'PaginationToken' using the same property output from the previous call for subsequent calls.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse, GetRGTResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExcludeCompliantResource = this.ExcludeCompliantResource;
            context.IncludeComplianceDetail = this.IncludeComplianceDetail;
            context.PaginationToken = this.PaginationToken;
            if (this.ResourceARNList != null)
            {
                context.ResourceARNList = new List<System.String>(this.ResourceARNList);
            }
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesRequest();
            
            if (cmdletContext.ExcludeCompliantResource != null)
            {
                request.ExcludeCompliantResources = cmdletContext.ExcludeCompliantResource.Value;
            }
            if (cmdletContext.IncludeComplianceDetail != null)
            {
                request.IncludeComplianceDetails = cmdletContext.IncludeComplianceDetail.Value;
            }
            if (cmdletContext.ResourceARNList != null)
            {
                request.ResourceARNList = cmdletContext.ResourceARNList;
            }
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
            public System.Boolean? ExcludeCompliantResource { get; set; }
            public System.Boolean? IncludeComplianceDetail { get; set; }
            public System.String PaginationToken { get; set; }
            public List<System.String> ResourceARNList { get; set; }
            public System.Int32? ResourcesPerPage { get; set; }
            public List<System.String> ResourceTypeFilter { get; set; }
            public List<Amazon.ResourceGroupsTaggingAPI.Model.TagFilter> TagFilter { get; set; }
            public System.Int32? TagsPerPage { get; set; }
            public System.Func<Amazon.ResourceGroupsTaggingAPI.Model.GetResourcesResponse, GetRGTResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceTagMappingList;
        }
        
    }
}
