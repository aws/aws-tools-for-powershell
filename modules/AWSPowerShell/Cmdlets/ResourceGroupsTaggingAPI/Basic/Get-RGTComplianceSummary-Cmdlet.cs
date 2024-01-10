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
    /// Returns a table that shows counts of resources that are noncompliant with their tag
    /// policies.
    /// 
    ///  
    /// <para>
    /// For more information on tag policies, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_policies_tag-policies.html">Tag
    /// Policies</a> in the <i>Organizations User Guide.</i></para><para>
    /// You can call this operation only from the organization's management account and from
    /// the us-east-1 Region.
    /// </para><para>
    /// This operation supports pagination, where the response can be sent in multiple pages.
    /// You should check the <c>PaginationToken</c> response parameter to determine if there
    /// are additional results available to return. Repeat the query, passing the <c>PaginationToken</c>
    /// response parameter value as an input to the next request until you recieve a <c>null</c>
    /// value. A null value for <c>PaginationToken</c> indicates that there are no more results
    /// waiting to be returned.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RGTComplianceSummary")]
    [OutputType("Amazon.ResourceGroupsTaggingAPI.Model.Summary")]
    [AWSCmdlet("Calls the AWS Resource Groups Tagging API GetComplianceSummary API operation.", Operation = new[] {"GetComplianceSummary"}, SelectReturnType = typeof(Amazon.ResourceGroupsTaggingAPI.Model.GetComplianceSummaryResponse))]
    [AWSCmdletOutput("Amazon.ResourceGroupsTaggingAPI.Model.Summary or Amazon.ResourceGroupsTaggingAPI.Model.GetComplianceSummaryResponse",
        "This cmdlet returns a collection of Amazon.ResourceGroupsTaggingAPI.Model.Summary objects.",
        "The service call response (type Amazon.ResourceGroupsTaggingAPI.Model.GetComplianceSummaryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetRGTComplianceSummaryCmdlet : AmazonResourceGroupsTaggingAPIClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>Specifies a list of attributes to group the counts of noncompliant resources by. If
        /// supplied, the counts are sorted by those attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] GroupBy { get; set; }
        #endregion
        
        #region Parameter RegionFilter
        /// <summary>
        /// <para>
        /// <para>Specifies a list of Amazon Web Services Regions to limit the output to. If you use
        /// this parameter, the count of returned noncompliant resources includes only resources
        /// in the specified Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RegionFilters")]
        public System.String[] RegionFilter { get; set; }
        #endregion
        
        #region Parameter ResourceTypeFilter
        /// <summary>
        /// <para>
        /// <para>Specifies that you want the response to include information for only resources of
        /// the specified types. The format of each resource type is <c>service[:resourceType]</c>.
        /// For example, specifying a resource type of <c>ec2</c> returns all Amazon EC2 resources
        /// (which includes EC2 instances). Specifying a resource type of <c>ec2:instance</c>
        /// returns only EC2 instances.</para><para>The string for each service name and resource type is the same as that embedded in
        /// a resource's Amazon Resource Name (ARN). Consult the <i><a href="https://docs.aws.amazon.com/general/latest/gr/">Amazon
        /// Web Services General Reference</a></i> for the following:</para><ul><li><para>For a list of service name strings, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#genref-aws-service-namespaces">Amazon
        /// Web Services Service Namespaces</a>.</para></li><li><para>For resource type strings, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arns-syntax">Example
        /// ARNs</a>.</para></li><li><para>For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a>.</para></li></ul><para>You can specify multiple resource types by using a comma separated array. The array
        /// can include up to 100 items. Note that the length constraint requirement applies to
        /// each resource type filter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTypeFilters")]
        public System.String[] ResourceTypeFilter { get; set; }
        #endregion
        
        #region Parameter TagKeyFilter
        /// <summary>
        /// <para>
        /// <para>Specifies that you want the response to include information for only resources that
        /// have tags with the specified tag keys. If you use this parameter, the count of returned
        /// noncompliant resources includes only resources that have the specified tag keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagKeyFilters")]
        public System.String[] TagKeyFilter { get; set; }
        #endregion
        
        #region Parameter TargetIdFilter
        /// <summary>
        /// <para>
        /// <para>Specifies target identifiers (usually, specific account IDs) to limit the output by.
        /// If you use this parameter, the count of returned noncompliant resources includes only
        /// resources with the specified target IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetIdFilters")]
        public System.String[] TargetIdFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of results to be returned in each page. A query can return
        /// fewer than this maximum, even if there are more results still to return. You should
        /// always check the <c>PaginationToken</c> response value to see if there are more results.
        /// You can specify a minimum of 1 and a maximum value of 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
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
        /// <br/>In order to manually control output pagination, use '-PaginationToken $null' for the first call and '-PaginationToken $AWSHistory.LastServiceResponse.PaginationToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String PaginationToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceGroupsTaggingAPI.Model.GetComplianceSummaryResponse).
        /// Specifying the name of a property of type Amazon.ResourceGroupsTaggingAPI.Model.GetComplianceSummaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SummaryList";
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
                context.Select = CreateSelectDelegate<Amazon.ResourceGroupsTaggingAPI.Model.GetComplianceSummaryResponse, GetRGTComplianceSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.GroupBy != null)
            {
                context.GroupBy = new List<System.String>(this.GroupBy);
            }
            context.MaxResult = this.MaxResult;
            context.PaginationToken = this.PaginationToken;
            if (this.RegionFilter != null)
            {
                context.RegionFilter = new List<System.String>(this.RegionFilter);
            }
            if (this.ResourceTypeFilter != null)
            {
                context.ResourceTypeFilter = new List<System.String>(this.ResourceTypeFilter);
            }
            if (this.TagKeyFilter != null)
            {
                context.TagKeyFilter = new List<System.String>(this.TagKeyFilter);
            }
            if (this.TargetIdFilter != null)
            {
                context.TargetIdFilter = new List<System.String>(this.TargetIdFilter);
            }
            
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
            var request = new Amazon.ResourceGroupsTaggingAPI.Model.GetComplianceSummaryRequest();
            
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.RegionFilter != null)
            {
                request.RegionFilters = cmdletContext.RegionFilter;
            }
            if (cmdletContext.ResourceTypeFilter != null)
            {
                request.ResourceTypeFilters = cmdletContext.ResourceTypeFilter;
            }
            if (cmdletContext.TagKeyFilter != null)
            {
                request.TagKeyFilters = cmdletContext.TagKeyFilter;
            }
            if (cmdletContext.TargetIdFilter != null)
            {
                request.TargetIdFilters = cmdletContext.TargetIdFilter;
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
        
        private Amazon.ResourceGroupsTaggingAPI.Model.GetComplianceSummaryResponse CallAWSServiceOperation(IAmazonResourceGroupsTaggingAPI client, Amazon.ResourceGroupsTaggingAPI.Model.GetComplianceSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Groups Tagging API", "GetComplianceSummary");
            try
            {
                #if DESKTOP
                return client.GetComplianceSummary(request);
                #elif CORECLR
                return client.GetComplianceSummaryAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> GroupBy { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String PaginationToken { get; set; }
            public List<System.String> RegionFilter { get; set; }
            public List<System.String> ResourceTypeFilter { get; set; }
            public List<System.String> TagKeyFilter { get; set; }
            public List<System.String> TargetIdFilter { get; set; }
            public System.Func<Amazon.ResourceGroupsTaggingAPI.Model.GetComplianceSummaryResponse, GetRGTComplianceSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SummaryList;
        }
        
    }
}
