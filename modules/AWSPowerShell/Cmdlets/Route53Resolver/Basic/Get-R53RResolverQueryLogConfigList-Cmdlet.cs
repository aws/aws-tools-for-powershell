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
using Amazon.Route53Resolver;
using Amazon.Route53Resolver.Model;

namespace Amazon.PowerShell.Cmdlets.R53R
{
    /// <summary>
    /// Lists information about the specified query logging configurations. Each configuration
    /// defines where you want Resolver to save DNS query logs and specifies the VPCs that
    /// you want to log queries for.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "R53RResolverQueryLogConfigList")]
    [OutputType("Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 Resolver ListResolverQueryLogConfigs API operation.", Operation = new[] {"ListResolverQueryLogConfigs"}, SelectReturnType = typeof(Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsResponse))]
    [AWSCmdletOutput("Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsResponse",
        "This cmdlet returns an Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsResponse object containing multiple properties."
    )]
    public partial class GetR53RResolverQueryLogConfigListCmdlet : AmazonRoute53ResolverClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>An optional specification to return a subset of query logging configurations.</para><note><para>If you submit a second or subsequent <c>ListResolverQueryLogConfigs</c> request and
        /// specify the <c>NextToken</c> parameter, you must use the same values for <c>Filters</c>,
        /// if any, as in the previous request.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.Route53Resolver.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The element that you want Resolver to sort query logging configurations by. </para><note><para>If you submit a second or subsequent <c>ListResolverQueryLogConfigs</c> request and
        /// specify the <c>NextToken</c> parameter, you must use the same value for <c>SortBy</c>,
        /// if any, as in the previous request.</para></note><para>Valid values include the following elements:</para><ul><li><para><c>Arn</c>: The ARN of the query logging configuration</para></li><li><para><c>AssociationCount</c>: The number of VPCs that are associated with the specified
        /// configuration </para></li><li><para><c>CreationTime</c>: The date and time that Resolver returned when the configuration
        /// was created</para></li><li><para><c>CreatorRequestId</c>: The value that was specified for <c>CreatorRequestId</c>
        /// when the configuration was created</para></li><li><para><c>DestinationArn</c>: The location that logs are sent to</para></li><li><para><c>Id</c>: The ID of the configuration</para></li><li><para><c>Name</c>: The name of the configuration</para></li><li><para><c>OwnerId</c>: The Amazon Web Services account number of the account that created
        /// the configuration</para></li><li><para><c>ShareStatus</c>: Whether the configuration is shared with other Amazon Web Services
        /// accounts or shared with the current account by another Amazon Web Services account.
        /// Sharing is configured through Resource Access Manager (RAM).</para></li><li><para><c>Status</c>: The current status of the configuration. Valid values include the
        /// following:</para><ul><li><para><c>CREATING</c>: Resolver is creating the query logging configuration.</para></li><li><para><c>CREATED</c>: The query logging configuration was successfully created. Resolver
        /// is logging queries that originate in the specified VPC.</para></li><li><para><c>DELETING</c>: Resolver is deleting this query logging configuration.</para></li><li><para><c>FAILED</c>: Resolver either couldn't create or couldn't delete the query logging
        /// configuration. Here are two common causes:</para><ul><li><para>The specified destination (for example, an Amazon S3 bucket) was deleted.</para></li><li><para>Permissions don't allow sending logs to the destination.</para></li></ul></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>If you specified a value for <c>SortBy</c>, the order that you want query logging
        /// configurations to be listed in, <c>ASCENDING</c> or <c>DESCENDING</c>.</para><note><para>If you submit a second or subsequent <c>ListResolverQueryLogConfigs</c> request and
        /// specify the <c>NextToken</c> parameter, you must use the same value for <c>SortOrder</c>,
        /// if any, as in the previous request.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Resolver.SortOrder")]
        public Amazon.Route53Resolver.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of query logging configurations that you want to return in the
        /// response to a <c>ListResolverQueryLogConfigs</c> request. If you don't specify a value
        /// for <c>MaxResults</c>, Resolver returns up to 100 query logging configurations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>For the first <c>ListResolverQueryLogConfigs</c> request, omit this value.</para><para>If there are more than <c>MaxResults</c> query logging configurations that match the
        /// values that you specify for <c>Filters</c>, you can submit another <c>ListResolverQueryLogConfigs</c>
        /// request to get the next group of configurations. In the next request, specify the
        /// value of <c>NextToken</c> from the previous response. </para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsResponse).
        /// Specifying the name of a property of type Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsResponse, GetR53RResolverQueryLogConfigListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.Route53Resolver.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
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
            var request = new Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
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
        
        private Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsResponse CallAWSServiceOperation(IAmazonRoute53Resolver client, Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Resolver", "ListResolverQueryLogConfigs");
            try
            {
                return client.ListResolverQueryLogConfigsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Route53Resolver.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SortBy { get; set; }
            public Amazon.Route53Resolver.SortOrder SortOrder { get; set; }
            public System.Func<Amazon.Route53Resolver.Model.ListResolverQueryLogConfigsResponse, GetR53RResolverQueryLogConfigListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
