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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Searches for profiles within a specific domain using one or more predefined search
    /// keys (e.g., _fullName, _phone, _email, _account, etc.) and/or custom-defined search
    /// keys. A search key is a data type pair that consists of a <c>KeyName</c> and <c>Values</c>
    /// list.
    /// 
    ///  
    /// <para>
    /// This operation supports searching for profiles with a minimum of 1 key-value(s) pair
    /// and up to 5 key-value(s) pairs using either <c>AND</c> or <c>OR</c> logic.
    /// </para>
    /// </summary>
    [Cmdlet("Search", "CPFProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.Profile")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles SearchProfiles API operation.", Operation = new[] {"SearchProfiles"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.SearchProfilesResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.Profile or Amazon.CustomerProfiles.Model.SearchProfilesResponse",
        "This cmdlet returns a collection of Amazon.CustomerProfiles.Model.Profile objects.",
        "The service call response (type Amazon.CustomerProfiles.Model.SearchProfilesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchCPFProfileCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalSearchKey
        /// <summary>
        /// <para>
        /// <para>A list of <c>AdditionalSearchKey</c> objects that are each searchable identifiers
        /// of a profile. Each <c>AdditionalSearchKey</c> object contains a <c>KeyName</c> and
        /// a list of <c>Values</c> associated with that specific key (i.e., a key-value(s) pair).
        /// These additional search keys will be used in conjunction with the <c>LogicalOperator</c>
        /// and the required <c>KeyName</c> and <c>Values</c> parameters to search for profiles
        /// that satisfy the search criteria. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalSearchKeys")]
        public Amazon.CustomerProfiles.Model.AdditionalSearchKey[] AdditionalSearchKey { get; set; }
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
        
        #region Parameter KeyName
        /// <summary>
        /// <para>
        /// <para>A searchable identifier of a customer profile. The predefined keys you can use to
        /// search include: _account, _profileId, _assetId, _caseId, _orderId, _fullName, _phone,
        /// _email, _ctrContactId, _marketoLeadId, _salesforceAccountId, _salesforceContactId,
        /// _salesforceAssetId, _zendeskUserId, _zendeskExternalId, _zendeskTicketId, _serviceNowSystemId,
        /// _serviceNowIncidentId, _segmentUserId, _shopifyCustomerId, _shopifyOrderId.</para>
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
        public System.String KeyName { get; set; }
        #endregion
        
        #region Parameter LogicalOperator
        /// <summary>
        /// <para>
        /// <para>Relationship between all specified search keys that will be used to search for profiles.
        /// This includes the required <c>KeyName</c> and <c>Values</c> parameters as well as
        /// any key-value(s) pairs specified in the <c>AdditionalSearchKeys</c> list.</para><para>This parameter influences which profiles will be returned in the response in the following
        /// manner:</para><ul><li><para><c>AND</c> - The response only includes profiles that match all of the search keys.</para></li><li><para><c>OR</c> - The response includes profiles that match at least one of the search
        /// keys.</para></li></ul><para>The <c>OR</c> relationship is the default behavior if this parameter is not included
        /// in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CustomerProfiles.LogicalOperator")]
        public Amazon.CustomerProfiles.LogicalOperator LogicalOperator { get; set; }
        #endregion
        
        #region Parameter Value
        /// <summary>
        /// <para>
        /// <para>A list of key values.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Values")]
        public System.String[] Value { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of objects returned per page.</para><para>The default is 20 if this parameter is not included in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token from the previous SearchProfiles API call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.SearchProfilesResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.SearchProfilesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-CPFProfile (SearchProfiles)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.SearchProfilesResponse, SearchCPFProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalSearchKey != null)
            {
                context.AdditionalSearchKey = new List<Amazon.CustomerProfiles.Model.AdditionalSearchKey>(this.AdditionalSearchKey);
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyName = this.KeyName;
            #if MODULAR
            if (this.KeyName == null && ParameterWasBound(nameof(this.KeyName)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogicalOperator = this.LogicalOperator;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.Value != null)
            {
                context.Value = new List<System.String>(this.Value);
            }
            #if MODULAR
            if (this.Value == null && ParameterWasBound(nameof(this.Value)))
            {
                WriteWarning("You are passing $null as a value for parameter Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CustomerProfiles.Model.SearchProfilesRequest();
            
            if (cmdletContext.AdditionalSearchKey != null)
            {
                request.AdditionalSearchKeys = cmdletContext.AdditionalSearchKey;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.KeyName != null)
            {
                request.KeyName = cmdletContext.KeyName;
            }
            if (cmdletContext.LogicalOperator != null)
            {
                request.LogicalOperator = cmdletContext.LogicalOperator;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Value != null)
            {
                request.Values = cmdletContext.Value;
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
        
        private Amazon.CustomerProfiles.Model.SearchProfilesResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.SearchProfilesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "SearchProfiles");
            try
            {
                #if DESKTOP
                return client.SearchProfiles(request);
                #elif CORECLR
                return client.SearchProfilesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CustomerProfiles.Model.AdditionalSearchKey> AdditionalSearchKey { get; set; }
            public System.String DomainName { get; set; }
            public System.String KeyName { get; set; }
            public Amazon.CustomerProfiles.LogicalOperator LogicalOperator { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> Value { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.SearchProfilesResponse, SearchCPFProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
