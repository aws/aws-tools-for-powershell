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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns summary information about extension that have been registered with CloudFormation.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFNTypeList")]
    [OutputType("Amazon.CloudFormation.Model.TypeSummary")]
    [AWSCmdlet("Calls the AWS CloudFormation ListTypes API operation.", Operation = new[] {"ListTypes"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.ListTypesResponse))]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.TypeSummary or Amazon.CloudFormation.Model.ListTypesResponse",
        "This cmdlet returns a collection of Amazon.CloudFormation.Model.TypeSummary objects.",
        "The service call response (type Amazon.CloudFormation.Model.ListTypesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFNTypeListCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_Category
        /// <summary>
        /// <para>
        /// <para>The category of extensions to return.</para><ul><li><para><code>REGISTERED</code>: Private extensions that have been registered for this account
        /// and region.</para></li><li><para><code>ACTIVATED</code>: Public extensions that have been activated for this account
        /// and region.</para></li><li><para><code>THIRD_PARTY</code>: Extensions available for use from publishers other than
        /// Amazon. This includes:</para><ul><li><para>Private extensions registered in the account.</para></li><li><para>Public extensions from publishers other than Amazon, whether activated or not.</para></li></ul></li><li><para><code>AWS_TYPES</code>: Extensions available for use from Amazon.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.Category")]
        public Amazon.CloudFormation.Category Filters_Category { get; set; }
        #endregion
        
        #region Parameter DeprecatedStatus
        /// <summary>
        /// <para>
        /// <para>The deprecation status of the extension that you want to get summary information about.</para><para>Valid values include:</para><ul><li><para><code>LIVE</code>: The extension is registered for use in CloudFormation operations.</para></li><li><para><code>DEPRECATED</code>: The extension has been deregistered and can no longer be
        /// used in CloudFormation operations.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.DeprecatedStatus")]
        public Amazon.CloudFormation.DeprecatedStatus DeprecatedStatus { get; set; }
        #endregion
        
        #region Parameter ProvisioningType
        /// <summary>
        /// <para>
        /// <para>For resource types, the provisioning behavior of the resource type. CloudFormation
        /// determines the provisioning type during registration, based on the types of handlers
        /// in the schema handler package submitted.</para><para>Valid values include:</para><ul><li><para><code>FULLY_MUTABLE</code>: The resource type includes an update handler to process
        /// updates to the type during stack update operations.</para></li><li><para><code>IMMUTABLE</code>: The resource type doesn't include an update handler, so the
        /// type can't be updated and must instead be replaced during stack update operations.</para></li><li><para><code>NON_PROVISIONABLE</code>: The resource type doesn't include create, read, and
        /// delete handlers, and therefore can't actually be provisioned.</para></li></ul><para>The default is <code>FULLY_MUTABLE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.ProvisioningType")]
        public Amazon.CloudFormation.ProvisioningType ProvisioningType { get; set; }
        #endregion
        
        #region Parameter Filters_PublisherId
        /// <summary>
        /// <para>
        /// <para>The id of the publisher of the extension.</para><para>Extensions published by Amazon aren't assigned a publisher ID. Use the <code>AWS_TYPES</code>
        /// category to specify a list of types published by Amazon.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_PublisherId { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of extension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.RegistryType")]
        public Amazon.CloudFormation.RegistryType Type { get; set; }
        #endregion
        
        #region Parameter Filters_TypeNamePrefix
        /// <summary>
        /// <para>
        /// <para>A prefix to use as a filter for results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_TypeNamePrefix { get; set; }
        #endregion
        
        #region Parameter Visibility
        /// <summary>
        /// <para>
        /// <para>The scope at which the extensions are visible and usable in CloudFormation operations.</para><para>Valid values include:</para><ul><li><para><code>PRIVATE</code>: Extensions that are visible and usable within this account
        /// and region. This includes:</para><ul><li><para>Private extensions you have registered in this account and region.</para></li><li><para>Public extensions that you have activated in this account and region.</para></li></ul></li><li><para><code>PUBLIC</code>: Extensions that are publicly visible and available to be activated
        /// within any Amazon Web Services account. This includes extensions from Amazon Web Services,
        /// in addition to third-party publishers.</para></li></ul><para>The default is <code>PRIVATE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.Visibility")]
        public Amazon.CloudFormation.Visibility Visibility { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned with a single call. If the number of
        /// available results exceeds this maximum, the response includes a <code>NextToken</code>
        /// value that you can assign to the <code>NextToken</code> request parameter to get the
        /// next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous paginated request didn't return all the remaining results, the response
        /// object's <code>NextToken</code> parameter value is set to a token. To retrieve the
        /// next set of results, call this action again and assign that token to the request object's
        /// <code>NextToken</code> parameter. If there are no remaining results, the previous
        /// response object's <code>NextToken</code> parameter is set to <code>null</code>.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TypeSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.ListTypesResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.ListTypesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TypeSummaries";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.ListTypesResponse, GetCFNTypeListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeprecatedStatus = this.DeprecatedStatus;
            context.Filters_Category = this.Filters_Category;
            context.Filters_PublisherId = this.Filters_PublisherId;
            context.Filters_TypeNamePrefix = this.Filters_TypeNamePrefix;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProvisioningType = this.ProvisioningType;
            context.Type = this.Type;
            context.Visibility = this.Visibility;
            
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
            var request = new Amazon.CloudFormation.Model.ListTypesRequest();
            
            if (cmdletContext.DeprecatedStatus != null)
            {
                request.DeprecatedStatus = cmdletContext.DeprecatedStatus;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.CloudFormation.Model.TypeFilters();
            Amazon.CloudFormation.Category requestFilters_filters_Category = null;
            if (cmdletContext.Filters_Category != null)
            {
                requestFilters_filters_Category = cmdletContext.Filters_Category;
            }
            if (requestFilters_filters_Category != null)
            {
                request.Filters.Category = requestFilters_filters_Category;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_PublisherId = null;
            if (cmdletContext.Filters_PublisherId != null)
            {
                requestFilters_filters_PublisherId = cmdletContext.Filters_PublisherId;
            }
            if (requestFilters_filters_PublisherId != null)
            {
                request.Filters.PublisherId = requestFilters_filters_PublisherId;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_TypeNamePrefix = null;
            if (cmdletContext.Filters_TypeNamePrefix != null)
            {
                requestFilters_filters_TypeNamePrefix = cmdletContext.Filters_TypeNamePrefix;
            }
            if (requestFilters_filters_TypeNamePrefix != null)
            {
                request.Filters.TypeNamePrefix = requestFilters_filters_TypeNamePrefix;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ProvisioningType != null)
            {
                request.ProvisioningType = cmdletContext.ProvisioningType;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.Visibility != null)
            {
                request.Visibility = cmdletContext.Visibility;
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
        
        private Amazon.CloudFormation.Model.ListTypesResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.ListTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "ListTypes");
            try
            {
                #if DESKTOP
                return client.ListTypes(request);
                #elif CORECLR
                return client.ListTypesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CloudFormation.DeprecatedStatus DeprecatedStatus { get; set; }
            public Amazon.CloudFormation.Category Filters_Category { get; set; }
            public System.String Filters_PublisherId { get; set; }
            public System.String Filters_TypeNamePrefix { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.CloudFormation.ProvisioningType ProvisioningType { get; set; }
            public Amazon.CloudFormation.RegistryType Type { get; set; }
            public Amazon.CloudFormation.Visibility Visibility { get; set; }
            public System.Func<Amazon.CloudFormation.Model.ListTypesResponse, GetCFNTypeListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TypeSummaries;
        }
        
    }
}
