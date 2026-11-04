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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Returns a list of resources that contain a specific software package. You identify
    /// the package with <c>PackageName</c> and <c>PackageType</c>. To narrow the results
    /// to one version of the package, include <c>PackageVersion</c>.
    /// 
    ///  
    /// <para>
    /// You can use the <c>Scopes</c> parameter to define the data boundary for the query.
    /// Currently, <c>Scopes</c> supports <c>AwsOrganizations</c>, which lets you retrieve
    /// resources from your entire organization or from specific organizational units. Only
    /// the delegated administrator account can use <c>Scopes</c>.
    /// </para><para>
    /// You can use the <c>Filters</c> parameter to further refine results based on resource
    /// attributes, such as <c>ResourceType</c> or <c>Region</c>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SHUBSoftwareResourcesV2")]
    [OutputType("Amazon.SecurityHub.Model.SoftwareResourceResult")]
    [AWSCmdlet("Calls the AWS Security Hub GetSoftwareResourcesV2 API operation.", Operation = new[] {"GetSoftwareResourcesV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetSoftwareResourcesV2Response))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.SoftwareResourceResult or Amazon.SecurityHub.Model.GetSoftwareResourcesV2Response",
        "This cmdlet returns a collection of Amazon.SecurityHub.Model.SoftwareResourceResult objects.",
        "The service call response (type Amazon.SecurityHub.Model.GetSoftwareResourcesV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHUBSoftwareResourcesV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Scopes_AwsOrganization
        /// <summary>
        /// <para>
        /// <para>A list of Organizations scopes to include in the query results. Each entry in the
        /// list specifies an organization or organizational unit to include for the delegated
        /// administrator's account. If the list specifies multiple entries, the entries are combined
        /// using OR logic.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scopes_AwsOrganizations")]
        public Amazon.SecurityHub.Model.AwsOrganizationScope[] Scopes_AwsOrganization { get; set; }
        #endregion
        
        #region Parameter Filters_CompositeFilter
        /// <summary>
        /// <para>
        /// <para>A collection of complex filtering conditions that can be applied to software packages.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_CompositeFilters")]
        public Amazon.SecurityHub.Model.SoftwareCompositeFilter[] Filters_CompositeFilter { get; set; }
        #endregion
        
        #region Parameter Filters_CompositeOperator
        /// <summary>
        /// <para>
        /// <para>The logical operator used to combine multiple filter conditions in the structure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.AllowedOperators")]
        public Amazon.SecurityHub.AllowedOperators Filters_CompositeOperator { get; set; }
        #endregion
        
        #region Parameter PackageName
        /// <summary>
        /// <para>
        /// <para>The name of the software package, for example <c>openssl</c>. This value must match
        /// the <c>PackageName</c> returned by <c>GetSoftwareV2</c>.</para>
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
        public System.String PackageName { get; set; }
        #endregion
        
        #region Parameter PackageType
        /// <summary>
        /// <para>
        /// <para>The type of the software package, for example <c>operating-system</c>, <c>application</c>,
        /// or <c>library</c>. This value must match the <c>PackageType</c> returned by <c>GetSoftwareV2</c>.</para>
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
        public System.String PackageType { get; set; }
        #endregion
        
        #region Parameter PackageVersion
        /// <summary>
        /// <para>
        /// <para>The version of the software package, for example <c>3.0.8</c>. If you omit this value,
        /// the response includes resources that contain any version of the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageVersion { get; set; }
        #endregion
        
        #region Parameter SortCriterion
        /// <summary>
        /// <para>
        /// <para>The resource attribute used to sort the list of returned resources, for example <c>Region</c>
        /// or <c>ResourceType</c>. You can specify one sort criterion.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SortCriteria")]
        public Amazon.SecurityHub.Model.SortCriterion[] SortCriterion { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. Valid values are 1–100. The default is 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token required for pagination. On your first call, set the value of this parameter
        /// to <c>NULL</c>. For subsequent calls, to continue listing data, set the value of this
        /// parameter to the value returned in the previous response.</para><para>A token expires one hour after it's issued. If you change the request parameters between
        /// calls, the token is no longer valid and the request fails with a <c>ValidationException</c>.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SoftwareResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetSoftwareResourcesV2Response).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetSoftwareResourcesV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SoftwareResources";
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetSoftwareResourcesV2Response, GetSHUBSoftwareResourcesV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filters_CompositeFilter != null)
            {
                context.Filters_CompositeFilter = new List<Amazon.SecurityHub.Model.SoftwareCompositeFilter>(this.Filters_CompositeFilter);
            }
            context.Filters_CompositeOperator = this.Filters_CompositeOperator;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.PackageName = this.PackageName;
            #if MODULAR
            if (this.PackageName == null && ParameterWasBound(nameof(this.PackageName)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PackageType = this.PackageType;
            #if MODULAR
            if (this.PackageType == null && ParameterWasBound(nameof(this.PackageType)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PackageVersion = this.PackageVersion;
            if (this.Scopes_AwsOrganization != null)
            {
                context.Scopes_AwsOrganization = new List<Amazon.SecurityHub.Model.AwsOrganizationScope>(this.Scopes_AwsOrganization);
            }
            if (this.SortCriterion != null)
            {
                context.SortCriterion = new List<Amazon.SecurityHub.Model.SortCriterion>(this.SortCriterion);
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
            var request = new Amazon.SecurityHub.Model.GetSoftwareResourcesV2Request();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.SecurityHub.Model.SoftwareFilters();
            List<Amazon.SecurityHub.Model.SoftwareCompositeFilter> requestFilters_filters_CompositeFilter = null;
            if (cmdletContext.Filters_CompositeFilter != null)
            {
                requestFilters_filters_CompositeFilter = cmdletContext.Filters_CompositeFilter;
            }
            if (requestFilters_filters_CompositeFilter != null)
            {
                request.Filters.CompositeFilters = requestFilters_filters_CompositeFilter;
                requestFiltersIsNull = false;
            }
            Amazon.SecurityHub.AllowedOperators requestFilters_filters_CompositeOperator = null;
            if (cmdletContext.Filters_CompositeOperator != null)
            {
                requestFilters_filters_CompositeOperator = cmdletContext.Filters_CompositeOperator;
            }
            if (requestFilters_filters_CompositeOperator != null)
            {
                request.Filters.CompositeOperator = requestFilters_filters_CompositeOperator;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.PackageName != null)
            {
                request.PackageName = cmdletContext.PackageName;
            }
            if (cmdletContext.PackageType != null)
            {
                request.PackageType = cmdletContext.PackageType;
            }
            if (cmdletContext.PackageVersion != null)
            {
                request.PackageVersion = cmdletContext.PackageVersion;
            }
            
             // populate Scopes
            var requestScopesIsNull = true;
            request.Scopes = new Amazon.SecurityHub.Model.SoftwareScopes();
            List<Amazon.SecurityHub.Model.AwsOrganizationScope> requestScopes_scopes_AwsOrganization = null;
            if (cmdletContext.Scopes_AwsOrganization != null)
            {
                requestScopes_scopes_AwsOrganization = cmdletContext.Scopes_AwsOrganization;
            }
            if (requestScopes_scopes_AwsOrganization != null)
            {
                request.Scopes.AwsOrganizations = requestScopes_scopes_AwsOrganization;
                requestScopesIsNull = false;
            }
             // determine if request.Scopes should be set to null
            if (requestScopesIsNull)
            {
                request.Scopes = null;
            }
            if (cmdletContext.SortCriterion != null)
            {
                request.SortCriteria = cmdletContext.SortCriterion;
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
        
        private Amazon.SecurityHub.Model.GetSoftwareResourcesV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetSoftwareResourcesV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetSoftwareResourcesV2");
            try
            {
                return client.GetSoftwareResourcesV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.SoftwareCompositeFilter> Filters_CompositeFilter { get; set; }
            public Amazon.SecurityHub.AllowedOperators Filters_CompositeOperator { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PackageName { get; set; }
            public System.String PackageType { get; set; }
            public System.String PackageVersion { get; set; }
            public List<Amazon.SecurityHub.Model.AwsOrganizationScope> Scopes_AwsOrganization { get; set; }
            public List<Amazon.SecurityHub.Model.SortCriterion> SortCriterion { get; set; }
            public System.Func<Amazon.SecurityHub.Model.GetSoftwareResourcesV2Response, GetSHUBSoftwareResourcesV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SoftwareResources;
        }
        
    }
}
