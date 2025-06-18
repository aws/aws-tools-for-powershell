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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Lists coverage details for your environment.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "INS2CoverageList")]
    [OutputType("Amazon.Inspector2.Model.CoveredResource")]
    [AWSCmdlet("Calls the Inspector2 ListCoverage API operation.", Operation = new[] {"ListCoverage"}, SelectReturnType = typeof(Amazon.Inspector2.Model.ListCoverageResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.CoveredResource or Amazon.Inspector2.Model.ListCoverageResponse",
        "This cmdlet returns a collection of Amazon.Inspector2.Model.CoveredResource objects.",
        "The service call response (type Amazon.Inspector2.Model.ListCoverageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINS2CoverageListCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FilterCriteria_AccountId
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Web Services account IDs to return coverage statistics for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_AccountId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeRepositoryProjectName
        /// <summary>
        /// <para>
        /// <para>Filter criteria for code repositories based on project name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_CodeRepositoryProjectName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeRepositoryProviderType
        /// <summary>
        /// <para>
        /// <para>Filter criteria for code repositories based on provider type (such as GitHub, GitLab,
        /// etc.).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_CodeRepositoryProviderType { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeRepositoryProviderTypeVisibility
        /// <summary>
        /// <para>
        /// <para>Filter criteria for code repositories based on visibility setting (public or private).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_CodeRepositoryProviderTypeVisibility { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Ec2InstanceTag
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 instance tags to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_Ec2InstanceTags")]
        public Amazon.Inspector2.Model.CoverageMapFilter[] FilterCriteria_Ec2InstanceTag { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageInUseCount
        /// <summary>
        /// <para>
        /// <para>The number of Amazon ECR images in use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageNumberFilter[] FilterCriteria_EcrImageInUseCount { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageLastInUseAt
        /// <summary>
        /// <para>
        /// <para>The Amazon ECR image that was last in use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageDateFilter[] FilterCriteria_EcrImageLastInUseAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageTag
        /// <summary>
        /// <para>
        /// <para>The Amazon ECR image tags to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_EcrImageTags")]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_EcrImageTag { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrRepositoryName
        /// <summary>
        /// <para>
        /// <para>The Amazon ECR repository name to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_EcrRepositoryName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ImagePulledAt
        /// <summary>
        /// <para>
        /// <para>The date an image was last pulled at.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageDateFilter[] FilterCriteria_ImagePulledAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionName
        /// <summary>
        /// <para>
        /// <para>Returns coverage statistics for Amazon Web Services Lambda functions filtered by function
        /// names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_LambdaFunctionName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionRuntime
        /// <summary>
        /// <para>
        /// <para>Returns coverage statistics for Amazon Web Services Lambda functions filtered by runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_LambdaFunctionRuntime { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionTag
        /// <summary>
        /// <para>
        /// <para>Returns coverage statistics for Amazon Web Services Lambda functions filtered by tag.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_LambdaFunctionTags")]
        public Amazon.Inspector2.Model.CoverageMapFilter[] FilterCriteria_LambdaFunctionTag { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LastScannedAt
        /// <summary>
        /// <para>
        /// <para>Filters Amazon Web Services resources based on whether Amazon Inspector has checked
        /// them for vulnerabilities within the specified time range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageDateFilter[] FilterCriteria_LastScannedAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LastScannedCommitId
        /// <summary>
        /// <para>
        /// <para>Filter criteria for code repositories based on the ID of the last scanned commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_LastScannedCommitId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ResourceId
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Web Services resource IDs to return coverage statistics for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_ResourceId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ResourceType
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Web Services resource types to return coverage statistics for.
        /// The values can be <c>AWS_EC2_INSTANCE</c>, <c>AWS_LAMBDA_FUNCTION</c>, <c>AWS_ECR_CONTAINER_IMAGE</c>,
        /// <c>AWS_ECR_REPOSITORY</c> or <c>AWS_ACCOUNT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_ResourceType { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScanMode
        /// <summary>
        /// <para>
        /// <para>The filter to search for Amazon EC2 instance coverage by scan mode. Valid values are
        /// <c>EC2_SSM_AGENT_BASED</c> and <c>EC2_AGENTLESS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_ScanMode { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScanStatusCode
        /// <summary>
        /// <para>
        /// <para>The scan status code to filter on. Valid values are: <c>ValidationException</c>, <c>InternalServerException</c>,
        /// <c>ResourceNotFoundException</c>, <c>BadRequestException</c>, and <c>ThrottlingException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_ScanStatusCode { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScanStatusReason
        /// <summary>
        /// <para>
        /// <para>The scan status reason to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_ScanStatusReason { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScanType
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Inspector scan types to return coverage statistics for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_ScanType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results the response can return. If your request would return
        /// more than the maximum the response will return a <c>nextToken</c> value, use this
        /// value when you call the action again to get the remaining results.</para>
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
        /// <para>A token to use for paginating results that are returned in the response. Set the value
        /// of this parameter to null for the first request to a list action. If your response
        /// returns more than the <c>maxResults</c> maximum value it will also return a <c>nextToken</c>
        /// value. For subsequent calls, use the <c>nextToken</c> value returned from the previous
        /// request to continue listing results after the first page.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CoveredResources'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.ListCoverageResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.ListCoverageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CoveredResources";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
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
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.ListCoverageResponse, GetINS2CoverageListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterCriteria_AccountId != null)
            {
                context.FilterCriteria_AccountId = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_AccountId);
            }
            if (this.FilterCriteria_CodeRepositoryProjectName != null)
            {
                context.FilterCriteria_CodeRepositoryProjectName = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_CodeRepositoryProjectName);
            }
            if (this.FilterCriteria_CodeRepositoryProviderType != null)
            {
                context.FilterCriteria_CodeRepositoryProviderType = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_CodeRepositoryProviderType);
            }
            if (this.FilterCriteria_CodeRepositoryProviderTypeVisibility != null)
            {
                context.FilterCriteria_CodeRepositoryProviderTypeVisibility = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_CodeRepositoryProviderTypeVisibility);
            }
            if (this.FilterCriteria_Ec2InstanceTag != null)
            {
                context.FilterCriteria_Ec2InstanceTag = new List<Amazon.Inspector2.Model.CoverageMapFilter>(this.FilterCriteria_Ec2InstanceTag);
            }
            if (this.FilterCriteria_EcrImageInUseCount != null)
            {
                context.FilterCriteria_EcrImageInUseCount = new List<Amazon.Inspector2.Model.CoverageNumberFilter>(this.FilterCriteria_EcrImageInUseCount);
            }
            if (this.FilterCriteria_EcrImageLastInUseAt != null)
            {
                context.FilterCriteria_EcrImageLastInUseAt = new List<Amazon.Inspector2.Model.CoverageDateFilter>(this.FilterCriteria_EcrImageLastInUseAt);
            }
            if (this.FilterCriteria_EcrImageTag != null)
            {
                context.FilterCriteria_EcrImageTag = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_EcrImageTag);
            }
            if (this.FilterCriteria_EcrRepositoryName != null)
            {
                context.FilterCriteria_EcrRepositoryName = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_EcrRepositoryName);
            }
            if (this.FilterCriteria_ImagePulledAt != null)
            {
                context.FilterCriteria_ImagePulledAt = new List<Amazon.Inspector2.Model.CoverageDateFilter>(this.FilterCriteria_ImagePulledAt);
            }
            if (this.FilterCriteria_LambdaFunctionName != null)
            {
                context.FilterCriteria_LambdaFunctionName = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_LambdaFunctionName);
            }
            if (this.FilterCriteria_LambdaFunctionRuntime != null)
            {
                context.FilterCriteria_LambdaFunctionRuntime = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_LambdaFunctionRuntime);
            }
            if (this.FilterCriteria_LambdaFunctionTag != null)
            {
                context.FilterCriteria_LambdaFunctionTag = new List<Amazon.Inspector2.Model.CoverageMapFilter>(this.FilterCriteria_LambdaFunctionTag);
            }
            if (this.FilterCriteria_LastScannedAt != null)
            {
                context.FilterCriteria_LastScannedAt = new List<Amazon.Inspector2.Model.CoverageDateFilter>(this.FilterCriteria_LastScannedAt);
            }
            if (this.FilterCriteria_LastScannedCommitId != null)
            {
                context.FilterCriteria_LastScannedCommitId = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_LastScannedCommitId);
            }
            if (this.FilterCriteria_ResourceId != null)
            {
                context.FilterCriteria_ResourceId = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_ResourceId);
            }
            if (this.FilterCriteria_ResourceType != null)
            {
                context.FilterCriteria_ResourceType = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_ResourceType);
            }
            if (this.FilterCriteria_ScanMode != null)
            {
                context.FilterCriteria_ScanMode = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_ScanMode);
            }
            if (this.FilterCriteria_ScanStatusCode != null)
            {
                context.FilterCriteria_ScanStatusCode = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_ScanStatusCode);
            }
            if (this.FilterCriteria_ScanStatusReason != null)
            {
                context.FilterCriteria_ScanStatusReason = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_ScanStatusReason);
            }
            if (this.FilterCriteria_ScanType != null)
            {
                context.FilterCriteria_ScanType = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_ScanType);
            }
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
            var request = new Amazon.Inspector2.Model.ListCoverageRequest();
            
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Inspector2.Model.CoverageFilterCriteria();
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_AccountId = null;
            if (cmdletContext.FilterCriteria_AccountId != null)
            {
                requestFilterCriteria_filterCriteria_AccountId = cmdletContext.FilterCriteria_AccountId;
            }
            if (requestFilterCriteria_filterCriteria_AccountId != null)
            {
                request.FilterCriteria.AccountId = requestFilterCriteria_filterCriteria_AccountId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_CodeRepositoryProjectName = null;
            if (cmdletContext.FilterCriteria_CodeRepositoryProjectName != null)
            {
                requestFilterCriteria_filterCriteria_CodeRepositoryProjectName = cmdletContext.FilterCriteria_CodeRepositoryProjectName;
            }
            if (requestFilterCriteria_filterCriteria_CodeRepositoryProjectName != null)
            {
                request.FilterCriteria.CodeRepositoryProjectName = requestFilterCriteria_filterCriteria_CodeRepositoryProjectName;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_CodeRepositoryProviderType = null;
            if (cmdletContext.FilterCriteria_CodeRepositoryProviderType != null)
            {
                requestFilterCriteria_filterCriteria_CodeRepositoryProviderType = cmdletContext.FilterCriteria_CodeRepositoryProviderType;
            }
            if (requestFilterCriteria_filterCriteria_CodeRepositoryProviderType != null)
            {
                request.FilterCriteria.CodeRepositoryProviderType = requestFilterCriteria_filterCriteria_CodeRepositoryProviderType;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_CodeRepositoryProviderTypeVisibility = null;
            if (cmdletContext.FilterCriteria_CodeRepositoryProviderTypeVisibility != null)
            {
                requestFilterCriteria_filterCriteria_CodeRepositoryProviderTypeVisibility = cmdletContext.FilterCriteria_CodeRepositoryProviderTypeVisibility;
            }
            if (requestFilterCriteria_filterCriteria_CodeRepositoryProviderTypeVisibility != null)
            {
                request.FilterCriteria.CodeRepositoryProviderTypeVisibility = requestFilterCriteria_filterCriteria_CodeRepositoryProviderTypeVisibility;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageMapFilter> requestFilterCriteria_filterCriteria_Ec2InstanceTag = null;
            if (cmdletContext.FilterCriteria_Ec2InstanceTag != null)
            {
                requestFilterCriteria_filterCriteria_Ec2InstanceTag = cmdletContext.FilterCriteria_Ec2InstanceTag;
            }
            if (requestFilterCriteria_filterCriteria_Ec2InstanceTag != null)
            {
                request.FilterCriteria.Ec2InstanceTags = requestFilterCriteria_filterCriteria_Ec2InstanceTag;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageNumberFilter> requestFilterCriteria_filterCriteria_EcrImageInUseCount = null;
            if (cmdletContext.FilterCriteria_EcrImageInUseCount != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageInUseCount = cmdletContext.FilterCriteria_EcrImageInUseCount;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageInUseCount != null)
            {
                request.FilterCriteria.EcrImageInUseCount = requestFilterCriteria_filterCriteria_EcrImageInUseCount;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageDateFilter> requestFilterCriteria_filterCriteria_EcrImageLastInUseAt = null;
            if (cmdletContext.FilterCriteria_EcrImageLastInUseAt != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageLastInUseAt = cmdletContext.FilterCriteria_EcrImageLastInUseAt;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageLastInUseAt != null)
            {
                request.FilterCriteria.EcrImageLastInUseAt = requestFilterCriteria_filterCriteria_EcrImageLastInUseAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_EcrImageTag = null;
            if (cmdletContext.FilterCriteria_EcrImageTag != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageTag = cmdletContext.FilterCriteria_EcrImageTag;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageTag != null)
            {
                request.FilterCriteria.EcrImageTags = requestFilterCriteria_filterCriteria_EcrImageTag;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_EcrRepositoryName = null;
            if (cmdletContext.FilterCriteria_EcrRepositoryName != null)
            {
                requestFilterCriteria_filterCriteria_EcrRepositoryName = cmdletContext.FilterCriteria_EcrRepositoryName;
            }
            if (requestFilterCriteria_filterCriteria_EcrRepositoryName != null)
            {
                request.FilterCriteria.EcrRepositoryName = requestFilterCriteria_filterCriteria_EcrRepositoryName;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageDateFilter> requestFilterCriteria_filterCriteria_ImagePulledAt = null;
            if (cmdletContext.FilterCriteria_ImagePulledAt != null)
            {
                requestFilterCriteria_filterCriteria_ImagePulledAt = cmdletContext.FilterCriteria_ImagePulledAt;
            }
            if (requestFilterCriteria_filterCriteria_ImagePulledAt != null)
            {
                request.FilterCriteria.ImagePulledAt = requestFilterCriteria_filterCriteria_ImagePulledAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_LambdaFunctionName = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionName != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionName = cmdletContext.FilterCriteria_LambdaFunctionName;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionName != null)
            {
                request.FilterCriteria.LambdaFunctionName = requestFilterCriteria_filterCriteria_LambdaFunctionName;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_LambdaFunctionRuntime = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionRuntime != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionRuntime = cmdletContext.FilterCriteria_LambdaFunctionRuntime;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionRuntime != null)
            {
                request.FilterCriteria.LambdaFunctionRuntime = requestFilterCriteria_filterCriteria_LambdaFunctionRuntime;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageMapFilter> requestFilterCriteria_filterCriteria_LambdaFunctionTag = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionTag != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionTag = cmdletContext.FilterCriteria_LambdaFunctionTag;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionTag != null)
            {
                request.FilterCriteria.LambdaFunctionTags = requestFilterCriteria_filterCriteria_LambdaFunctionTag;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageDateFilter> requestFilterCriteria_filterCriteria_LastScannedAt = null;
            if (cmdletContext.FilterCriteria_LastScannedAt != null)
            {
                requestFilterCriteria_filterCriteria_LastScannedAt = cmdletContext.FilterCriteria_LastScannedAt;
            }
            if (requestFilterCriteria_filterCriteria_LastScannedAt != null)
            {
                request.FilterCriteria.LastScannedAt = requestFilterCriteria_filterCriteria_LastScannedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_LastScannedCommitId = null;
            if (cmdletContext.FilterCriteria_LastScannedCommitId != null)
            {
                requestFilterCriteria_filterCriteria_LastScannedCommitId = cmdletContext.FilterCriteria_LastScannedCommitId;
            }
            if (requestFilterCriteria_filterCriteria_LastScannedCommitId != null)
            {
                request.FilterCriteria.LastScannedCommitId = requestFilterCriteria_filterCriteria_LastScannedCommitId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_ResourceId = null;
            if (cmdletContext.FilterCriteria_ResourceId != null)
            {
                requestFilterCriteria_filterCriteria_ResourceId = cmdletContext.FilterCriteria_ResourceId;
            }
            if (requestFilterCriteria_filterCriteria_ResourceId != null)
            {
                request.FilterCriteria.ResourceId = requestFilterCriteria_filterCriteria_ResourceId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_ResourceType = null;
            if (cmdletContext.FilterCriteria_ResourceType != null)
            {
                requestFilterCriteria_filterCriteria_ResourceType = cmdletContext.FilterCriteria_ResourceType;
            }
            if (requestFilterCriteria_filterCriteria_ResourceType != null)
            {
                request.FilterCriteria.ResourceType = requestFilterCriteria_filterCriteria_ResourceType;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_ScanMode = null;
            if (cmdletContext.FilterCriteria_ScanMode != null)
            {
                requestFilterCriteria_filterCriteria_ScanMode = cmdletContext.FilterCriteria_ScanMode;
            }
            if (requestFilterCriteria_filterCriteria_ScanMode != null)
            {
                request.FilterCriteria.ScanMode = requestFilterCriteria_filterCriteria_ScanMode;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_ScanStatusCode = null;
            if (cmdletContext.FilterCriteria_ScanStatusCode != null)
            {
                requestFilterCriteria_filterCriteria_ScanStatusCode = cmdletContext.FilterCriteria_ScanStatusCode;
            }
            if (requestFilterCriteria_filterCriteria_ScanStatusCode != null)
            {
                request.FilterCriteria.ScanStatusCode = requestFilterCriteria_filterCriteria_ScanStatusCode;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_ScanStatusReason = null;
            if (cmdletContext.FilterCriteria_ScanStatusReason != null)
            {
                requestFilterCriteria_filterCriteria_ScanStatusReason = cmdletContext.FilterCriteria_ScanStatusReason;
            }
            if (requestFilterCriteria_filterCriteria_ScanStatusReason != null)
            {
                request.FilterCriteria.ScanStatusReason = requestFilterCriteria_filterCriteria_ScanStatusReason;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CoverageStringFilter> requestFilterCriteria_filterCriteria_ScanType = null;
            if (cmdletContext.FilterCriteria_ScanType != null)
            {
                requestFilterCriteria_filterCriteria_ScanType = cmdletContext.FilterCriteria_ScanType;
            }
            if (requestFilterCriteria_filterCriteria_ScanType != null)
            {
                request.FilterCriteria.ScanType = requestFilterCriteria_filterCriteria_ScanType;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.Inspector2.Model.ListCoverageResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.ListCoverageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "ListCoverage");
            try
            {
                return client.ListCoverageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_AccountId { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_CodeRepositoryProjectName { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_CodeRepositoryProviderType { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_CodeRepositoryProviderTypeVisibility { get; set; }
            public List<Amazon.Inspector2.Model.CoverageMapFilter> FilterCriteria_Ec2InstanceTag { get; set; }
            public List<Amazon.Inspector2.Model.CoverageNumberFilter> FilterCriteria_EcrImageInUseCount { get; set; }
            public List<Amazon.Inspector2.Model.CoverageDateFilter> FilterCriteria_EcrImageLastInUseAt { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_EcrImageTag { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_EcrRepositoryName { get; set; }
            public List<Amazon.Inspector2.Model.CoverageDateFilter> FilterCriteria_ImagePulledAt { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_LambdaFunctionName { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_LambdaFunctionRuntime { get; set; }
            public List<Amazon.Inspector2.Model.CoverageMapFilter> FilterCriteria_LambdaFunctionTag { get; set; }
            public List<Amazon.Inspector2.Model.CoverageDateFilter> FilterCriteria_LastScannedAt { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_LastScannedCommitId { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ResourceId { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ResourceType { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ScanMode { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ScanStatusCode { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ScanStatusReason { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ScanType { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Inspector2.Model.ListCoverageResponse, GetINS2CoverageListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CoveredResources;
        }
        
    }
}
