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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Retrieves <a>ProtectionGroup</a> objects for the account. You can retrieve all protection
    /// groups or you can provide filtering criteria and retrieve just the subset of protection
    /// groups that match the criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SHLDProtectionGroupList")]
    [OutputType("Amazon.Shield.Model.ProtectionGroup")]
    [AWSCmdlet("Calls the AWS Shield ListProtectionGroups API operation.", Operation = new[] {"ListProtectionGroups"}, SelectReturnType = typeof(Amazon.Shield.Model.ListProtectionGroupsResponse))]
    [AWSCmdletOutput("Amazon.Shield.Model.ProtectionGroup or Amazon.Shield.Model.ListProtectionGroupsResponse",
        "This cmdlet returns a collection of Amazon.Shield.Model.ProtectionGroup objects.",
        "The service call response (type Amazon.Shield.Model.ListProtectionGroupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSHLDProtectionGroupListCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InclusionFilters_Aggregation
        /// <summary>
        /// <para>
        /// <para>The aggregation setting of the protection groups that you want to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InclusionFilters_Aggregations")]
        public System.String[] InclusionFilters_Aggregation { get; set; }
        #endregion
        
        #region Parameter InclusionFilters_Pattern
        /// <summary>
        /// <para>
        /// <para>The pattern specification of the protection groups that you want to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InclusionFilters_Patterns")]
        public System.String[] InclusionFilters_Pattern { get; set; }
        #endregion
        
        #region Parameter InclusionFilters_ProtectionGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the protection group that you want to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InclusionFilters_ProtectionGroupIds")]
        public System.String[] InclusionFilters_ProtectionGroupId { get; set; }
        #endregion
        
        #region Parameter InclusionFilters_ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type configuration of the protection groups that you want to retrieve.
        /// In the protection group configuration, you specify the resource type when you set
        /// the group's <c>Pattern</c> to <c>BY_RESOURCE_TYPE</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InclusionFilters_ResourceTypes")]
        public System.String[] InclusionFilters_ResourceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The greatest number of objects that you want Shield Advanced to return to the list
        /// request. Shield Advanced might return fewer objects than you indicate in this setting,
        /// even if more objects are available. If there are more objects remaining, Shield Advanced
        /// will always also return a <c>NextToken</c> value in the response.</para><para>The default setting is 20.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>When you request a list of objects from Shield Advanced, if the response does not
        /// include all of the remaining available objects, Shield Advanced includes a <c>NextToken</c>
        /// value in the response. You can retrieve the next batch of objects by requesting the
        /// list again and providing the token that was returned by the prior call in your request.
        /// </para><para>You can indicate the maximum number of objects that you want Shield Advanced to return
        /// for a single call with the <c>MaxResults</c> setting. Shield Advanced will not return
        /// more than <c>MaxResults</c> objects, but may return fewer, even if more objects are
        /// still available.</para><para>Whenever more objects remain that Shield Advanced has not yet returned to you, the
        /// response will include a <c>NextToken</c> value.</para><para>On your first call to a list operation, leave this setting empty.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProtectionGroups'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.ListProtectionGroupsResponse).
        /// Specifying the name of a property of type Amazon.Shield.Model.ListProtectionGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProtectionGroups";
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
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.ListProtectionGroupsResponse, GetSHLDProtectionGroupListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.InclusionFilters_Aggregation != null)
            {
                context.InclusionFilters_Aggregation = new List<System.String>(this.InclusionFilters_Aggregation);
            }
            if (this.InclusionFilters_Pattern != null)
            {
                context.InclusionFilters_Pattern = new List<System.String>(this.InclusionFilters_Pattern);
            }
            if (this.InclusionFilters_ProtectionGroupId != null)
            {
                context.InclusionFilters_ProtectionGroupId = new List<System.String>(this.InclusionFilters_ProtectionGroupId);
            }
            if (this.InclusionFilters_ResourceType != null)
            {
                context.InclusionFilters_ResourceType = new List<System.String>(this.InclusionFilters_ResourceType);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Shield.Model.ListProtectionGroupsRequest();
            
            
             // populate InclusionFilters
            var requestInclusionFiltersIsNull = true;
            request.InclusionFilters = new Amazon.Shield.Model.InclusionProtectionGroupFilters();
            List<System.String> requestInclusionFilters_inclusionFilters_Aggregation = null;
            if (cmdletContext.InclusionFilters_Aggregation != null)
            {
                requestInclusionFilters_inclusionFilters_Aggregation = cmdletContext.InclusionFilters_Aggregation;
            }
            if (requestInclusionFilters_inclusionFilters_Aggregation != null)
            {
                request.InclusionFilters.Aggregations = requestInclusionFilters_inclusionFilters_Aggregation;
                requestInclusionFiltersIsNull = false;
            }
            List<System.String> requestInclusionFilters_inclusionFilters_Pattern = null;
            if (cmdletContext.InclusionFilters_Pattern != null)
            {
                requestInclusionFilters_inclusionFilters_Pattern = cmdletContext.InclusionFilters_Pattern;
            }
            if (requestInclusionFilters_inclusionFilters_Pattern != null)
            {
                request.InclusionFilters.Patterns = requestInclusionFilters_inclusionFilters_Pattern;
                requestInclusionFiltersIsNull = false;
            }
            List<System.String> requestInclusionFilters_inclusionFilters_ProtectionGroupId = null;
            if (cmdletContext.InclusionFilters_ProtectionGroupId != null)
            {
                requestInclusionFilters_inclusionFilters_ProtectionGroupId = cmdletContext.InclusionFilters_ProtectionGroupId;
            }
            if (requestInclusionFilters_inclusionFilters_ProtectionGroupId != null)
            {
                request.InclusionFilters.ProtectionGroupIds = requestInclusionFilters_inclusionFilters_ProtectionGroupId;
                requestInclusionFiltersIsNull = false;
            }
            List<System.String> requestInclusionFilters_inclusionFilters_ResourceType = null;
            if (cmdletContext.InclusionFilters_ResourceType != null)
            {
                requestInclusionFilters_inclusionFilters_ResourceType = cmdletContext.InclusionFilters_ResourceType;
            }
            if (requestInclusionFilters_inclusionFilters_ResourceType != null)
            {
                request.InclusionFilters.ResourceTypes = requestInclusionFilters_inclusionFilters_ResourceType;
                requestInclusionFiltersIsNull = false;
            }
             // determine if request.InclusionFilters should be set to null
            if (requestInclusionFiltersIsNull)
            {
                request.InclusionFilters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.Shield.Model.ListProtectionGroupsResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.ListProtectionGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "ListProtectionGroups");
            try
            {
                #if DESKTOP
                return client.ListProtectionGroups(request);
                #elif CORECLR
                return client.ListProtectionGroupsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> InclusionFilters_Aggregation { get; set; }
            public List<System.String> InclusionFilters_Pattern { get; set; }
            public List<System.String> InclusionFilters_ProtectionGroupId { get; set; }
            public List<System.String> InclusionFilters_ResourceType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Shield.Model.ListProtectionGroupsResponse, GetSHLDProtectionGroupListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProtectionGroups;
        }
        
    }
}
