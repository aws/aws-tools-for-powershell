/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Accepts a resource type and returns a list of resource identifiers that are aggregated
    /// for a specific resource type across accounts and regions. A resource identifier includes
    /// the resource type, ID, (if available) the custom resource name, source account, and
    /// source region. You can narrow the results to include only resources that have specific
    /// resource IDs, or a resource name, or source account ID, or source region.
    /// 
    ///  
    /// <para>
    /// For example, if the input consists of accountID 12345678910 and the region is us-east-1
    /// for resource type <code>AWS::EC2::Instance</code> then the API returns all the EC2
    /// instance identifiers of accountID 12345678910 and region us-east-1.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "CFGAggregateDiscoveredResourceList")]
    [OutputType("Amazon.ConfigService.Model.AggregateResourceIdentifier")]
    [AWSCmdlet("Calls the AWS Config ListAggregateDiscoveredResources API operation.", Operation = new[] {"ListAggregateDiscoveredResources"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.AggregateResourceIdentifier",
        "This cmdlet returns a collection of AggregateResourceIdentifier objects.",
        "The service call response (type Amazon.ConfigService.Model.ListAggregateDiscoveredResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCFGAggregateDiscoveredResourceListCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_AccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit source account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filters_AccountId { get; set; }
        #endregion
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter Filters_Region
        /// <summary>
        /// <para>
        /// <para>The source region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filters_Region { get; set; }
        #endregion
        
        #region Parameter Filters_ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filters_ResourceId { get; set; }
        #endregion
        
        #region Parameter Filters_ResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filters_ResourceName { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of resources that you want AWS Config to list in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ConfigService.ResourceType")]
        public Amazon.ConfigService.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of resource identifiers returned on each page. The default is 100.
        /// You cannot specify a number greater than 100. If you specify 0, AWS Config uses the
        /// default.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
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
            
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            context.Filters_AccountId = this.Filters_AccountId;
            context.Filters_Region = this.Filters_Region;
            context.Filters_ResourceId = this.Filters_ResourceId;
            context.Filters_ResourceName = this.Filters_ResourceName;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            context.ResourceType = this.ResourceType;
            
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
            var request = new Amazon.ConfigService.Model.ListAggregateDiscoveredResourcesRequest();
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            
             // populate Filters
            bool requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.ResourceFilters();
            System.String requestFilters_filters_AccountId = null;
            if (cmdletContext.Filters_AccountId != null)
            {
                requestFilters_filters_AccountId = cmdletContext.Filters_AccountId;
            }
            if (requestFilters_filters_AccountId != null)
            {
                request.Filters.AccountId = requestFilters_filters_AccountId;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_Region = null;
            if (cmdletContext.Filters_Region != null)
            {
                requestFilters_filters_Region = cmdletContext.Filters_Region;
            }
            if (requestFilters_filters_Region != null)
            {
                request.Filters.Region = requestFilters_filters_Region;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_ResourceId = null;
            if (cmdletContext.Filters_ResourceId != null)
            {
                requestFilters_filters_ResourceId = cmdletContext.Filters_ResourceId;
            }
            if (requestFilters_filters_ResourceId != null)
            {
                request.Filters.ResourceId = requestFilters_filters_ResourceId;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_ResourceName = null;
            if (cmdletContext.Filters_ResourceName != null)
            {
                requestFilters_filters_ResourceName = cmdletContext.Filters_ResourceName;
            }
            if (requestFilters_filters_ResourceName != null)
            {
                request.Filters.ResourceName = requestFilters_filters_ResourceName;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
            {
                _emitLimit = cmdletContext.Limit;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken") || ParameterWasBound("Limit");
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.ResourceIdentifiers;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ResourceIdentifiers.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
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
        
        private Amazon.ConfigService.Model.ListAggregateDiscoveredResourcesResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.ListAggregateDiscoveredResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "ListAggregateDiscoveredResources");
            try
            {
                #if DESKTOP
                return client.ListAggregateDiscoveredResources(request);
                #elif CORECLR
                return client.ListAggregateDiscoveredResourcesAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationAggregatorName { get; set; }
            public System.String Filters_AccountId { get; set; }
            public System.String Filters_Region { get; set; }
            public System.String Filters_ResourceId { get; set; }
            public System.String Filters_ResourceName { get; set; }
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ConfigService.ResourceType ResourceType { get; set; }
        }
        
    }
}
