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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Fetches the recommendations for a profile in the input Customer Profiles domain. Fetches
    /// all the profile recommendations
    /// </summary>
    [Cmdlet("Get", "CPFProfileRecommendation")]
    [OutputType("Amazon.CustomerProfiles.Model.Recommendation")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles GetProfileRecommendations API operation.", Operation = new[] {"GetProfileRecommendations"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.GetProfileRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.Recommendation or Amazon.CustomerProfiles.Model.GetProfileRecommendationsResponse",
        "This cmdlet returns a collection of Amazon.CustomerProfiles.Model.Recommendation objects.",
        "The service call response (type Amazon.CustomerProfiles.Model.GetProfileRecommendationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCPFProfileRecommendationCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CandidateId
        /// <summary>
        /// <para>
        /// <para>A list of item IDs to rank for the user. Use this when you want to re-rank a specific
        /// set of items rather than getting recommendations from the full item catalog. Required
        /// for personalized-ranking use cases.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CandidateIds")]
        public System.String[] CandidateId { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>The contextual metadata used to provide dynamic runtime information to tailor recommendations.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Context { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter MetadataConfig_MetadataColumn
        /// <summary>
        /// <para>
        /// <para>A list of metadata column names from your Items dataset to include in the recommendation
        /// response.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataConfig_MetadataColumns")]
        public System.String[] MetadataConfig_MetadataColumn { get; set; }
        #endregion
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the profile for which to retrieve recommendations.</para>
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
        public System.String ProfileId { get; set; }
        #endregion
        
        #region Parameter RecommenderFilter
        /// <summary>
        /// <para>
        /// <para>A list of filters to apply to the returned recommendations. Filters define criteria
        /// for including or excluding items from the recommendation results.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommenderFilters")]
        public Amazon.CustomerProfiles.Model.RecommenderFilter[] RecommenderFilter { get; set; }
        #endregion
        
        #region Parameter RecommenderName
        /// <summary>
        /// <para>
        /// <para>The unique name of the recommender.</para>
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
        public System.String RecommenderName { get; set; }
        #endregion
        
        #region Parameter RecommenderPromotionalFilter
        /// <summary>
        /// <para>
        /// <para>A list of promotional filters to apply to the recommendations. Promotional filters
        /// allow you to promote specific items within a configurable subset of recommendation
        /// results.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommenderPromotionalFilters")]
        public Amazon.CustomerProfiles.Model.RecommenderPromotionalFilter[] RecommenderPromotionalFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of recommendations to return. The default value is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Recommendations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.GetProfileRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.GetProfileRecommendationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Recommendations";
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
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.GetProfileRecommendationsResponse, GetCPFProfileRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CandidateId != null)
            {
                context.CandidateId = new List<System.String>(this.CandidateId);
            }
            if (this.Context != null)
            {
                context.Context = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Context.Keys)
                {
                    context.Context.Add((String)hashKey, (System.String)(this.Context[hashKey]));
                }
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            if (this.MetadataConfig_MetadataColumn != null)
            {
                context.MetadataConfig_MetadataColumn = new List<System.String>(this.MetadataConfig_MetadataColumn);
            }
            context.ProfileId = this.ProfileId;
            #if MODULAR
            if (this.ProfileId == null && ParameterWasBound(nameof(this.ProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RecommenderFilter != null)
            {
                context.RecommenderFilter = new List<Amazon.CustomerProfiles.Model.RecommenderFilter>(this.RecommenderFilter);
            }
            context.RecommenderName = this.RecommenderName;
            #if MODULAR
            if (this.RecommenderName == null && ParameterWasBound(nameof(this.RecommenderName)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommenderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RecommenderPromotionalFilter != null)
            {
                context.RecommenderPromotionalFilter = new List<Amazon.CustomerProfiles.Model.RecommenderPromotionalFilter>(this.RecommenderPromotionalFilter);
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
            // create request
            var request = new Amazon.CustomerProfiles.Model.GetProfileRecommendationsRequest();
            
            if (cmdletContext.CandidateId != null)
            {
                request.CandidateIds = cmdletContext.CandidateId;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate MetadataConfig
            var requestMetadataConfigIsNull = true;
            request.MetadataConfig = new Amazon.CustomerProfiles.Model.MetadataConfig();
            List<System.String> requestMetadataConfig_metadataConfig_MetadataColumn = null;
            if (cmdletContext.MetadataConfig_MetadataColumn != null)
            {
                requestMetadataConfig_metadataConfig_MetadataColumn = cmdletContext.MetadataConfig_MetadataColumn;
            }
            if (requestMetadataConfig_metadataConfig_MetadataColumn != null)
            {
                request.MetadataConfig.MetadataColumns = requestMetadataConfig_metadataConfig_MetadataColumn;
                requestMetadataConfigIsNull = false;
            }
             // determine if request.MetadataConfig should be set to null
            if (requestMetadataConfigIsNull)
            {
                request.MetadataConfig = null;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileId = cmdletContext.ProfileId;
            }
            if (cmdletContext.RecommenderFilter != null)
            {
                request.RecommenderFilters = cmdletContext.RecommenderFilter;
            }
            if (cmdletContext.RecommenderName != null)
            {
                request.RecommenderName = cmdletContext.RecommenderName;
            }
            if (cmdletContext.RecommenderPromotionalFilter != null)
            {
                request.RecommenderPromotionalFilters = cmdletContext.RecommenderPromotionalFilter;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CustomerProfiles.Model.GetProfileRecommendationsResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.GetProfileRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "GetProfileRecommendations");
            try
            {
                return client.GetProfileRecommendationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CandidateId { get; set; }
            public Dictionary<System.String, System.String> Context { get; set; }
            public System.String DomainName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<System.String> MetadataConfig_MetadataColumn { get; set; }
            public System.String ProfileId { get; set; }
            public List<Amazon.CustomerProfiles.Model.RecommenderFilter> RecommenderFilter { get; set; }
            public System.String RecommenderName { get; set; }
            public List<Amazon.CustomerProfiles.Model.RecommenderPromotionalFilter> RecommenderPromotionalFilter { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.GetProfileRecommendationsResponse, GetCPFProfileRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Recommendations;
        }
        
    }
}
