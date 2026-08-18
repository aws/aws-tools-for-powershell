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
using Amazon.MarketplaceCatalog;
using Amazon.MarketplaceCatalog.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MCAT
{
    /// <summary>
    /// Returns a paginated list of assessments associated with an entity or change set in
    /// AWS Marketplace. An <i>assessment</i> is the result of evaluating a product or change
    /// set against a framework, such as AMI Security or Container Security.
    /// 
    ///  
    /// <para>
    /// Use the <c>AssessmentTargetFilter</c> to scope results to a specific entity or change
    /// set, and use <c>FrameworkFilters</c> to scope results to a single framework. To retrieve
    /// detailed control-level results for an individual assessment, use the <c>DescribeAssessment</c>
    /// action.
    /// </para><para>
    /// Results are sorted by assessment creation time in descending order.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "MCATAssessmentList")]
    [OutputType("Amazon.MarketplaceCatalog.Model.AssessmentSummary")]
    [AWSCmdlet("Calls the AWS Marketplace Catalog Service ListAssessments API operation.", Operation = new[] {"ListAssessments"}, SelectReturnType = typeof(Amazon.MarketplaceCatalog.Model.ListAssessmentsResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceCatalog.Model.AssessmentSummary or Amazon.MarketplaceCatalog.Model.ListAssessmentsResponse",
        "This cmdlet returns a collection of Amazon.MarketplaceCatalog.Model.AssessmentSummary objects.",
        "The service call response (type Amazon.MarketplaceCatalog.Model.ListAssessmentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMCATAssessmentListCmdlet : AmazonMarketplaceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog related to the request. Fixed value: <c>AWSMarketplace</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter AssessmentTargetFilter_ChangeSetId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the change set that triggered the assessments you want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssessmentTargetFilter_ChangeSetId { get; set; }
        #endregion
        
        #region Parameter FrameworkFilters_AMISecurityFilters_DeliveryOptionId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the delivery option whose AMI Security assessments you want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FrameworkFilters_AMISecurityFilters_DeliveryOptionId { get; set; }
        #endregion
        
        #region Parameter FrameworkFilters_ContainerSecurityFilters_DeliveryOptionId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the delivery option whose Container Security assessments you want
        /// to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FrameworkFilters_ContainerSecurityFilters_DeliveryOptionId { get; set; }
        #endregion
        
        #region Parameter AssessmentTargetFilter_EntityId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the entity whose assessments you want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssessmentTargetFilter_EntityId { get; set; }
        #endregion
        
        #region Parameter FrameworkId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of a framework. When specified, only assessments performed against
        /// this framework are returned. For example, <c>AMISecurity</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FrameworkId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the upper limit of the elements on a single page. If a value isn't provided,
        /// the default value is 20. Valid values range from 1 to 100.</para>
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
        /// <para>The value of the next token, if it exists. <c>null</c> if there are no more results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssessmentSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceCatalog.Model.ListAssessmentsResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceCatalog.Model.ListAssessmentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssessmentSummaryList";
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
                context.Select = CreateSelectDelegate<Amazon.MarketplaceCatalog.Model.ListAssessmentsResponse, GetMCATAssessmentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssessmentTargetFilter_ChangeSetId = this.AssessmentTargetFilter_ChangeSetId;
            context.AssessmentTargetFilter_EntityId = this.AssessmentTargetFilter_EntityId;
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FrameworkFilters_AMISecurityFilters_DeliveryOptionId = this.FrameworkFilters_AMISecurityFilters_DeliveryOptionId;
            context.FrameworkFilters_ContainerSecurityFilters_DeliveryOptionId = this.FrameworkFilters_ContainerSecurityFilters_DeliveryOptionId;
            context.FrameworkId = this.FrameworkId;
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
            var request = new Amazon.MarketplaceCatalog.Model.ListAssessmentsRequest();
            
            
             // populate AssessmentTargetFilter
            var requestAssessmentTargetFilterIsNull = true;
            request.AssessmentTargetFilter = new Amazon.MarketplaceCatalog.Model.AssessmentTargetFilter();
            System.String requestAssessmentTargetFilter_assessmentTargetFilter_ChangeSetId = null;
            if (cmdletContext.AssessmentTargetFilter_ChangeSetId != null)
            {
                requestAssessmentTargetFilter_assessmentTargetFilter_ChangeSetId = cmdletContext.AssessmentTargetFilter_ChangeSetId;
            }
            if (requestAssessmentTargetFilter_assessmentTargetFilter_ChangeSetId != null)
            {
                request.AssessmentTargetFilter.ChangeSetId = requestAssessmentTargetFilter_assessmentTargetFilter_ChangeSetId;
                requestAssessmentTargetFilterIsNull = false;
            }
            System.String requestAssessmentTargetFilter_assessmentTargetFilter_EntityId = null;
            if (cmdletContext.AssessmentTargetFilter_EntityId != null)
            {
                requestAssessmentTargetFilter_assessmentTargetFilter_EntityId = cmdletContext.AssessmentTargetFilter_EntityId;
            }
            if (requestAssessmentTargetFilter_assessmentTargetFilter_EntityId != null)
            {
                request.AssessmentTargetFilter.EntityId = requestAssessmentTargetFilter_assessmentTargetFilter_EntityId;
                requestAssessmentTargetFilterIsNull = false;
            }
             // determine if request.AssessmentTargetFilter should be set to null
            if (requestAssessmentTargetFilterIsNull)
            {
                request.AssessmentTargetFilter = null;
            }
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            
             // populate FrameworkFilters
            var requestFrameworkFiltersIsNull = true;
            request.FrameworkFilters = new Amazon.MarketplaceCatalog.Model.FrameworkFilters();
            Amazon.MarketplaceCatalog.Model.AMISecurityFilters requestFrameworkFilters_frameworkFilters_AMISecurityFilters = null;
            
             // populate AMISecurityFilters
            var requestFrameworkFilters_frameworkFilters_AMISecurityFiltersIsNull = true;
            requestFrameworkFilters_frameworkFilters_AMISecurityFilters = new Amazon.MarketplaceCatalog.Model.AMISecurityFilters();
            System.String requestFrameworkFilters_frameworkFilters_AMISecurityFilters_frameworkFilters_AMISecurityFilters_DeliveryOptionId = null;
            if (cmdletContext.FrameworkFilters_AMISecurityFilters_DeliveryOptionId != null)
            {
                requestFrameworkFilters_frameworkFilters_AMISecurityFilters_frameworkFilters_AMISecurityFilters_DeliveryOptionId = cmdletContext.FrameworkFilters_AMISecurityFilters_DeliveryOptionId;
            }
            if (requestFrameworkFilters_frameworkFilters_AMISecurityFilters_frameworkFilters_AMISecurityFilters_DeliveryOptionId != null)
            {
                requestFrameworkFilters_frameworkFilters_AMISecurityFilters.DeliveryOptionId = requestFrameworkFilters_frameworkFilters_AMISecurityFilters_frameworkFilters_AMISecurityFilters_DeliveryOptionId;
                requestFrameworkFilters_frameworkFilters_AMISecurityFiltersIsNull = false;
            }
             // determine if requestFrameworkFilters_frameworkFilters_AMISecurityFilters should be set to null
            if (requestFrameworkFilters_frameworkFilters_AMISecurityFiltersIsNull)
            {
                requestFrameworkFilters_frameworkFilters_AMISecurityFilters = null;
            }
            if (requestFrameworkFilters_frameworkFilters_AMISecurityFilters != null)
            {
                request.FrameworkFilters.AMISecurityFilters = requestFrameworkFilters_frameworkFilters_AMISecurityFilters;
                requestFrameworkFiltersIsNull = false;
            }
            Amazon.MarketplaceCatalog.Model.ContainerSecurityFilters requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters = null;
            
             // populate ContainerSecurityFilters
            var requestFrameworkFilters_frameworkFilters_ContainerSecurityFiltersIsNull = true;
            requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters = new Amazon.MarketplaceCatalog.Model.ContainerSecurityFilters();
            System.String requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters_frameworkFilters_ContainerSecurityFilters_DeliveryOptionId = null;
            if (cmdletContext.FrameworkFilters_ContainerSecurityFilters_DeliveryOptionId != null)
            {
                requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters_frameworkFilters_ContainerSecurityFilters_DeliveryOptionId = cmdletContext.FrameworkFilters_ContainerSecurityFilters_DeliveryOptionId;
            }
            if (requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters_frameworkFilters_ContainerSecurityFilters_DeliveryOptionId != null)
            {
                requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters.DeliveryOptionId = requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters_frameworkFilters_ContainerSecurityFilters_DeliveryOptionId;
                requestFrameworkFilters_frameworkFilters_ContainerSecurityFiltersIsNull = false;
            }
             // determine if requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters should be set to null
            if (requestFrameworkFilters_frameworkFilters_ContainerSecurityFiltersIsNull)
            {
                requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters = null;
            }
            if (requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters != null)
            {
                request.FrameworkFilters.ContainerSecurityFilters = requestFrameworkFilters_frameworkFilters_ContainerSecurityFilters;
                requestFrameworkFiltersIsNull = false;
            }
             // determine if request.FrameworkFilters should be set to null
            if (requestFrameworkFiltersIsNull)
            {
                request.FrameworkFilters = null;
            }
            if (cmdletContext.FrameworkId != null)
            {
                request.FrameworkId = cmdletContext.FrameworkId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
        
        private Amazon.MarketplaceCatalog.Model.ListAssessmentsResponse CallAWSServiceOperation(IAmazonMarketplaceCatalog client, Amazon.MarketplaceCatalog.Model.ListAssessmentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Catalog Service", "ListAssessments");
            try
            {
                return client.ListAssessmentsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssessmentTargetFilter_ChangeSetId { get; set; }
            public System.String AssessmentTargetFilter_EntityId { get; set; }
            public System.String Catalog { get; set; }
            public System.String FrameworkFilters_AMISecurityFilters_DeliveryOptionId { get; set; }
            public System.String FrameworkFilters_ContainerSecurityFilters_DeliveryOptionId { get; set; }
            public System.String FrameworkId { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.MarketplaceCatalog.Model.ListAssessmentsResponse, GetMCATAssessmentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssessmentSummaryList;
        }
        
    }
}
