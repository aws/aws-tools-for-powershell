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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Lists Amazon Inspector coverage statistics for your environment.
    /// </summary>
    [Cmdlet("Get", "INS2CoverageStatisticList")]
    [OutputType("Amazon.Inspector2.Model.ListCoverageStatisticsResponse")]
    [AWSCmdlet("Calls the Inspector2 ListCoverageStatistics API operation.", Operation = new[] {"ListCoverageStatistics"}, SelectReturnType = typeof(Amazon.Inspector2.Model.ListCoverageStatisticsResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.ListCoverageStatisticsResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.ListCoverageStatisticsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetINS2CoverageStatisticListCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        #region Parameter FilterCriteria_AccountId
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Web Services account IDs to return coverage statistics for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_AccountId { get; set; }
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
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>The value to group the results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Inspector2.GroupKey")]
        public Amazon.Inspector2.GroupKey GroupBy { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionName
        /// <summary>
        /// <para>
        /// <para>Returns coverage statistics for AWS Lambda functions filtered by function names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_LambdaFunctionName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionRuntime
        /// <summary>
        /// <para>
        /// <para>Returns coverage statistics for AWS Lambda functions filtered by runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_LambdaFunctionRuntime { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionTag
        /// <summary>
        /// <para>
        /// <para>Returns coverage statistics for AWS Lambda functions filtered by tag.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_LambdaFunctionTags")]
        public Amazon.Inspector2.Model.CoverageMapFilter[] FilterCriteria_LambdaFunctionTag { get; set; }
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
        /// The values can be <code>AWS_EC2_INSTANCE</code> or <code>AWS_ECR_REPOSITORY</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.CoverageStringFilter[] FilterCriteria_ResourceType { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ScanStatusCode
        /// <summary>
        /// <para>
        /// <para>The scan status code to filter on.</para>
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
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to use for paginating results that are returned in the response. Set the value
        /// of this parameter to null for the first request to a list action. For subsequent calls,
        /// use the <code>NextToken</code> value returned from the previous request to continue
        /// listing results after the first page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.ListCoverageStatisticsResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.ListCoverageStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GroupBy parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GroupBy' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GroupBy' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.ListCoverageStatisticsResponse, GetINS2CoverageStatisticListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GroupBy;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.FilterCriteria_AccountId != null)
            {
                context.FilterCriteria_AccountId = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_AccountId);
            }
            if (this.FilterCriteria_Ec2InstanceTag != null)
            {
                context.FilterCriteria_Ec2InstanceTag = new List<Amazon.Inspector2.Model.CoverageMapFilter>(this.FilterCriteria_Ec2InstanceTag);
            }
            if (this.FilterCriteria_EcrImageTag != null)
            {
                context.FilterCriteria_EcrImageTag = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_EcrImageTag);
            }
            if (this.FilterCriteria_EcrRepositoryName != null)
            {
                context.FilterCriteria_EcrRepositoryName = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_EcrRepositoryName);
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
            if (this.FilterCriteria_ResourceId != null)
            {
                context.FilterCriteria_ResourceId = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_ResourceId);
            }
            if (this.FilterCriteria_ResourceType != null)
            {
                context.FilterCriteria_ResourceType = new List<Amazon.Inspector2.Model.CoverageStringFilter>(this.FilterCriteria_ResourceType);
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
            context.GroupBy = this.GroupBy;
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
            // create request
            var request = new Amazon.Inspector2.Model.ListCoverageStatisticsRequest();
            
            
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
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Inspector2.Model.ListCoverageStatisticsResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.ListCoverageStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "ListCoverageStatistics");
            try
            {
                #if DESKTOP
                return client.ListCoverageStatistics(request);
                #elif CORECLR
                return client.ListCoverageStatisticsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_AccountId { get; set; }
            public List<Amazon.Inspector2.Model.CoverageMapFilter> FilterCriteria_Ec2InstanceTag { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_EcrImageTag { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_EcrRepositoryName { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_LambdaFunctionName { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_LambdaFunctionRuntime { get; set; }
            public List<Amazon.Inspector2.Model.CoverageMapFilter> FilterCriteria_LambdaFunctionTag { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ResourceId { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ResourceType { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ScanStatusCode { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ScanStatusReason { get; set; }
            public List<Amazon.Inspector2.Model.CoverageStringFilter> FilterCriteria_ScanType { get; set; }
            public Amazon.Inspector2.GroupKey GroupBy { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Inspector2.Model.ListCoverageStatisticsResponse, GetINS2CoverageStatisticListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
