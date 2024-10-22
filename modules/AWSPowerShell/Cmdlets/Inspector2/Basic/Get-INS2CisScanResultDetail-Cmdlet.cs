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
    /// Retrieves CIS scan result details.
    /// </summary>
    [Cmdlet("Get", "INS2CisScanResultDetail")]
    [OutputType("Amazon.Inspector2.Model.CisScanResultDetails")]
    [AWSCmdlet("Calls the Inspector2 GetCisScanResultDetails API operation.", Operation = new[] {"GetCisScanResultDetails"}, SelectReturnType = typeof(Amazon.Inspector2.Model.GetCisScanResultDetailsResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.CisScanResultDetails or Amazon.Inspector2.Model.GetCisScanResultDetailsResponse",
        "This cmdlet returns a collection of Amazon.Inspector2.Model.CisScanResultDetails objects.",
        "The service call response (type Amazon.Inspector2.Model.GetCisScanResultDetailsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetINS2CisScanResultDetailCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The account ID.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CheckIdFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's check ID filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_CheckIdFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_CheckIdFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FindingArnFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's finding ARN filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_FindingArnFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_FindingArnFilter { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FindingStatusFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's finding status filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_FindingStatusFilters")]
        public Amazon.Inspector2.Model.CisFindingStatusFilter[] FilterCriteria_FindingStatusFilter { get; set; }
        #endregion
        
        #region Parameter ScanArn
        /// <summary>
        /// <para>
        /// <para>The scan ARN.</para>
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
        public System.String ScanArn { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_SecurityLevelFilter
        /// <summary>
        /// <para>
        /// <para> The criteria's security level filters. . Security level refers to the Benchmark levels
        /// that CIS assigns to a profile. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_SecurityLevelFilters")]
        public Amazon.Inspector2.Model.CisSecurityLevelFilter[] FilterCriteria_SecurityLevelFilter { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The sort by order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.CisScanResultDetailsSortBy")]
        public Amazon.Inspector2.CisScanResultDetailsSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.CisSortOrder")]
        public Amazon.Inspector2.CisSortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter TargetResourceId
        /// <summary>
        /// <para>
        /// <para>The target resource ID.</para>
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
        public System.String TargetResourceId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_TitleFilter
        /// <summary>
        /// <para>
        /// <para>The criteria's title filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_TitleFilters")]
        public Amazon.Inspector2.Model.CisStringFilter[] FilterCriteria_TitleFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of CIS scan result details to be returned in a single page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token from a previous request that's used to retrieve the next page
        /// of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScanResultDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.GetCisScanResultDetailsResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.GetCisScanResultDetailsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScanResultDetails";
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
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.GetCisScanResultDetailsResponse, GetINS2CisScanResultDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FilterCriteria_CheckIdFilter != null)
            {
                context.FilterCriteria_CheckIdFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_CheckIdFilter);
            }
            if (this.FilterCriteria_FindingArnFilter != null)
            {
                context.FilterCriteria_FindingArnFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_FindingArnFilter);
            }
            if (this.FilterCriteria_FindingStatusFilter != null)
            {
                context.FilterCriteria_FindingStatusFilter = new List<Amazon.Inspector2.Model.CisFindingStatusFilter>(this.FilterCriteria_FindingStatusFilter);
            }
            if (this.FilterCriteria_SecurityLevelFilter != null)
            {
                context.FilterCriteria_SecurityLevelFilter = new List<Amazon.Inspector2.Model.CisSecurityLevelFilter>(this.FilterCriteria_SecurityLevelFilter);
            }
            if (this.FilterCriteria_TitleFilter != null)
            {
                context.FilterCriteria_TitleFilter = new List<Amazon.Inspector2.Model.CisStringFilter>(this.FilterCriteria_TitleFilter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ScanArn = this.ScanArn;
            #if MODULAR
            if (this.ScanArn == null && ParameterWasBound(nameof(this.ScanArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.TargetResourceId = this.TargetResourceId;
            #if MODULAR
            if (this.TargetResourceId == null && ParameterWasBound(nameof(this.TargetResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Inspector2.Model.GetCisScanResultDetailsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Inspector2.Model.CisScanResultDetailsFilterCriteria();
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_CheckIdFilter = null;
            if (cmdletContext.FilterCriteria_CheckIdFilter != null)
            {
                requestFilterCriteria_filterCriteria_CheckIdFilter = cmdletContext.FilterCriteria_CheckIdFilter;
            }
            if (requestFilterCriteria_filterCriteria_CheckIdFilter != null)
            {
                request.FilterCriteria.CheckIdFilters = requestFilterCriteria_filterCriteria_CheckIdFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_FindingArnFilter = null;
            if (cmdletContext.FilterCriteria_FindingArnFilter != null)
            {
                requestFilterCriteria_filterCriteria_FindingArnFilter = cmdletContext.FilterCriteria_FindingArnFilter;
            }
            if (requestFilterCriteria_filterCriteria_FindingArnFilter != null)
            {
                request.FilterCriteria.FindingArnFilters = requestFilterCriteria_filterCriteria_FindingArnFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisFindingStatusFilter> requestFilterCriteria_filterCriteria_FindingStatusFilter = null;
            if (cmdletContext.FilterCriteria_FindingStatusFilter != null)
            {
                requestFilterCriteria_filterCriteria_FindingStatusFilter = cmdletContext.FilterCriteria_FindingStatusFilter;
            }
            if (requestFilterCriteria_filterCriteria_FindingStatusFilter != null)
            {
                request.FilterCriteria.FindingStatusFilters = requestFilterCriteria_filterCriteria_FindingStatusFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisSecurityLevelFilter> requestFilterCriteria_filterCriteria_SecurityLevelFilter = null;
            if (cmdletContext.FilterCriteria_SecurityLevelFilter != null)
            {
                requestFilterCriteria_filterCriteria_SecurityLevelFilter = cmdletContext.FilterCriteria_SecurityLevelFilter;
            }
            if (requestFilterCriteria_filterCriteria_SecurityLevelFilter != null)
            {
                request.FilterCriteria.SecurityLevelFilters = requestFilterCriteria_filterCriteria_SecurityLevelFilter;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.CisStringFilter> requestFilterCriteria_filterCriteria_TitleFilter = null;
            if (cmdletContext.FilterCriteria_TitleFilter != null)
            {
                requestFilterCriteria_filterCriteria_TitleFilter = cmdletContext.FilterCriteria_TitleFilter;
            }
            if (requestFilterCriteria_filterCriteria_TitleFilter != null)
            {
                request.FilterCriteria.TitleFilters = requestFilterCriteria_filterCriteria_TitleFilter;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ScanArn != null)
            {
                request.ScanArn = cmdletContext.ScanArn;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.TargetResourceId != null)
            {
                request.TargetResourceId = cmdletContext.TargetResourceId;
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
        
        private Amazon.Inspector2.Model.GetCisScanResultDetailsResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.GetCisScanResultDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "GetCisScanResultDetails");
            try
            {
                #if DESKTOP
                return client.GetCisScanResultDetails(request);
                #elif CORECLR
                return client.GetCisScanResultDetailsAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_CheckIdFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_FindingArnFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisFindingStatusFilter> FilterCriteria_FindingStatusFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisSecurityLevelFilter> FilterCriteria_SecurityLevelFilter { get; set; }
            public List<Amazon.Inspector2.Model.CisStringFilter> FilterCriteria_TitleFilter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ScanArn { get; set; }
            public Amazon.Inspector2.CisScanResultDetailsSortBy SortBy { get; set; }
            public Amazon.Inspector2.CisSortOrder SortOrder { get; set; }
            public System.String TargetResourceId { get; set; }
            public System.Func<Amazon.Inspector2.Model.GetCisScanResultDetailsResponse, GetINS2CisScanResultDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScanResultDetails;
        }
        
    }
}
