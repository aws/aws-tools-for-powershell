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
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;

namespace Amazon.PowerShell.Cmdlets.R53D
{
    /// <summary>
    /// This operation returns all the domain names registered with Amazon Route 53 for the
    /// current Amazon Web Services account if no filtering conditions are used.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "R53DDomainList")]
    [OutputType("Amazon.Route53Domains.Model.DomainSummary")]
    [AWSCmdlet("Calls the Amazon Route 53 Domains ListDomains API operation.", Operation = new[] {"ListDomains"}, SelectReturnType = typeof(Amazon.Route53Domains.Model.ListDomainsResponse), LegacyAlias="Get-R53DDomains")]
    [AWSCmdletOutput("Amazon.Route53Domains.Model.DomainSummary or Amazon.Route53Domains.Model.ListDomainsResponse",
        "This cmdlet returns a collection of Amazon.Route53Domains.Model.DomainSummary objects.",
        "The service call response (type Amazon.Route53Domains.Model.ListDomainsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53DDomainListCmdlet : AmazonRoute53DomainsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FilterCondition
        /// <summary>
        /// <para>
        /// <para>A complex type that contains information about the filters applied during the <c>ListDomains</c>
        /// request. The filter conditions can include domain name and domain expiration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterConditions")]
        public Amazon.Route53Domains.Model.FilterCondition[] FilterCondition { get; set; }
        #endregion
        
        #region Parameter SortCondition_Name
        /// <summary>
        /// <para>
        /// <para>Field to be used for sorting the list of domains. It can be either the name or the
        /// expiration for a domain. Note that if <c>filterCondition</c> is used in the same <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_domains__ListDomains.html">ListDomains</a>
        /// call, the field used for sorting has to be the same as the field used for filtering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Domains.ListDomainsAttributeName")]
        public Amazon.Route53Domains.ListDomainsAttributeName SortCondition_Name { get; set; }
        #endregion
        
        #region Parameter SortCondition_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order for a list of domains. Either ascending (ASC) or descending (DES).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53Domains.SortOrder")]
        public Amazon.Route53Domains.SortOrder SortCondition_SortOrder { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>For an initial request for a list of domains, omit this element. If the number of
        /// domains that are associated with the current Amazon Web Services account is greater
        /// than the value that you specified for <c>MaxItems</c>, you can use <c>Marker</c> to
        /// return additional domains. Get the value of <c>NextPageMarker</c> from the previous
        /// response, and submit another request that includes the value of <c>NextPageMarker</c>
        /// in the <c>Marker</c> element.</para><para>Constraints: The marker must match the value specified in the previous request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Number of domains to be returned.</para><para>Default: 20</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("MaxItems")]
        public System.Int32? MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Domains'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53Domains.Model.ListDomainsResponse).
        /// Specifying the name of a property of type Amazon.Route53Domains.Model.ListDomainsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Domains";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MaxItem parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MaxItem' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MaxItem' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
                context.Select = CreateSelectDelegate<Amazon.Route53Domains.Model.ListDomainsResponse, GetR53DDomainListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MaxItem;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FilterCondition != null)
            {
                context.FilterCondition = new List<Amazon.Route53Domains.Model.FilterCondition>(this.FilterCondition);
            }
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            context.SortCondition_Name = this.SortCondition_Name;
            context.SortCondition_SortOrder = this.SortCondition_SortOrder;
            
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
            var request = new Amazon.Route53Domains.Model.ListDomainsRequest();
            
            if (cmdletContext.FilterCondition != null)
            {
                request.FilterConditions = cmdletContext.FilterCondition;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem.Value;
            }
            
             // populate SortCondition
            var requestSortConditionIsNull = true;
            request.SortCondition = new Amazon.Route53Domains.Model.SortCondition();
            Amazon.Route53Domains.ListDomainsAttributeName requestSortCondition_sortCondition_Name = null;
            if (cmdletContext.SortCondition_Name != null)
            {
                requestSortCondition_sortCondition_Name = cmdletContext.SortCondition_Name;
            }
            if (requestSortCondition_sortCondition_Name != null)
            {
                request.SortCondition.Name = requestSortCondition_sortCondition_Name;
                requestSortConditionIsNull = false;
            }
            Amazon.Route53Domains.SortOrder requestSortCondition_sortCondition_SortOrder = null;
            if (cmdletContext.SortCondition_SortOrder != null)
            {
                requestSortCondition_sortCondition_SortOrder = cmdletContext.SortCondition_SortOrder;
            }
            if (requestSortCondition_sortCondition_SortOrder != null)
            {
                request.SortCondition.SortOrder = requestSortCondition_sortCondition_SortOrder;
                requestSortConditionIsNull = false;
            }
             // determine if request.SortCondition should be set to null
            if (requestSortConditionIsNull)
            {
                request.SortCondition = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.NextPageMarker;
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
        
        private Amazon.Route53Domains.Model.ListDomainsResponse CallAWSServiceOperation(IAmazonRoute53Domains client, Amazon.Route53Domains.Model.ListDomainsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53 Domains", "ListDomains");
            try
            {
                #if DESKTOP
                return client.ListDomains(request);
                #elif CORECLR
                return client.ListDomainsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Route53Domains.Model.FilterCondition> FilterCondition { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxItem { get; set; }
            public Amazon.Route53Domains.ListDomainsAttributeName SortCondition_Name { get; set; }
            public Amazon.Route53Domains.SortOrder SortCondition_SortOrder { get; set; }
            public System.Func<Amazon.Route53Domains.Model.ListDomainsResponse, GetR53DDomainListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Domains;
        }
        
    }
}
