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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Fetches the queries that are suggested to your users.
    /// 
    ///  
    /// <para><c>GetQuerySuggestions</c> is currently not supported in the Amazon Web Services
    /// GovCloud (US-West) region.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KNDRQuerySuggestion")]
    [OutputType("Amazon.Kendra.Model.GetQuerySuggestionsResponse")]
    [AWSCmdlet("Calls the Amazon Kendra GetQuerySuggestions API operation.", Operation = new[] {"GetQuerySuggestions"}, SelectReturnType = typeof(Amazon.Kendra.Model.GetQuerySuggestionsResponse))]
    [AWSCmdletOutput("Amazon.Kendra.Model.GetQuerySuggestionsResponse",
        "This cmdlet returns an Amazon.Kendra.Model.GetQuerySuggestionsResponse object containing multiple properties."
    )]
    public partial class GetKNDRQuerySuggestionCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeSuggestionsConfig_AdditionalResponseAttribute
        /// <summary>
        /// <para>
        /// <para>The list of additional document field/attribute keys or field names to include in
        /// the response. You can use additional fields to provide extra information in the response.
        /// Additional fields are not used to based suggestions on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeSuggestionsConfig_AdditionalResponseAttributes")]
        public System.String[] AttributeSuggestionsConfig_AdditionalResponseAttribute { get; set; }
        #endregion
        
        #region Parameter AttributeSuggestionsConfig_AttributeFilter
        /// <summary>
        /// <para>
        /// <para>Filters the search results based on document fields/attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Kendra.Model.AttributeFilter AttributeSuggestionsConfig_AttributeFilter { get; set; }
        #endregion
        
        #region Parameter UserContext_DataSourceGroup
        /// <summary>
        /// <para>
        /// <para>The list of data source groups you want to filter search results based on groups'
        /// access to documents in that data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeSuggestionsConfig_UserContext_DataSourceGroups")]
        public Amazon.Kendra.Model.DataSourceGroup[] UserContext_DataSourceGroup { get; set; }
        #endregion
        
        #region Parameter UserContext_Group
        /// <summary>
        /// <para>
        /// <para>The list of groups you want to filter search results based on the groups' access to
        /// documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeSuggestionsConfig_UserContext_Groups")]
        public System.String[] UserContext_Group { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index you want to get query suggestions from.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter MaxSuggestionsCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of query suggestions you want to show to your users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxSuggestionsCount { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The text of a user's query to generate query suggestions.</para><para>A query is suggested if the query prefix matches what a user starts to type as their
        /// query.</para><para>Amazon Kendra does not show any suggestions if a user types fewer than two characters
        /// or more than 60 characters. A query must also have at least one search result and
        /// contain at least one word of more than four characters.</para>
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
        public System.String QueryText { get; set; }
        #endregion
        
        #region Parameter AttributeSuggestionsConfig_SuggestionAttribute
        /// <summary>
        /// <para>
        /// <para>The list of document field/attribute keys or field names to use for query suggestions.
        /// If the content within any of the fields match what your user starts typing as their
        /// query, then the field content is returned as a query suggestion.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeSuggestionsConfig_SuggestionAttributes")]
        public System.String[] AttributeSuggestionsConfig_SuggestionAttribute { get; set; }
        #endregion
        
        #region Parameter SuggestionType
        /// <summary>
        /// <para>
        /// <para>The suggestions type to base query suggestions on. The suggestion types are query
        /// history or document fields/attributes. You can set one type or the other.</para><para>If you set query history as your suggestions type, Amazon Kendra suggests queries
        /// relevant to your users based on popular queries in the query history.</para><para>If you set document fields/attributes as your suggestions type, Amazon Kendra suggests
        /// queries relevant to your users based on the contents of document fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SuggestionTypes")]
        public System.String[] SuggestionType { get; set; }
        #endregion
        
        #region Parameter UserContext_Token
        /// <summary>
        /// <para>
        /// <para>The user context token for filtering search results for a user. It must be a JWT or
        /// a JSON token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeSuggestionsConfig_UserContext_Token")]
        public System.String UserContext_Token { get; set; }
        #endregion
        
        #region Parameter UserContext_UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user you want to filter search results based on their access
        /// to documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeSuggestionsConfig_UserContext_UserId")]
        public System.String UserContext_UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.GetQuerySuggestionsResponse).
        /// Specifying the name of a property of type Amazon.Kendra.Model.GetQuerySuggestionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.GetQuerySuggestionsResponse, GetKNDRQuerySuggestionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AttributeSuggestionsConfig_AdditionalResponseAttribute != null)
            {
                context.AttributeSuggestionsConfig_AdditionalResponseAttribute = new List<System.String>(this.AttributeSuggestionsConfig_AdditionalResponseAttribute);
            }
            context.AttributeSuggestionsConfig_AttributeFilter = this.AttributeSuggestionsConfig_AttributeFilter;
            if (this.AttributeSuggestionsConfig_SuggestionAttribute != null)
            {
                context.AttributeSuggestionsConfig_SuggestionAttribute = new List<System.String>(this.AttributeSuggestionsConfig_SuggestionAttribute);
            }
            if (this.UserContext_DataSourceGroup != null)
            {
                context.UserContext_DataSourceGroup = new List<Amazon.Kendra.Model.DataSourceGroup>(this.UserContext_DataSourceGroup);
            }
            if (this.UserContext_Group != null)
            {
                context.UserContext_Group = new List<System.String>(this.UserContext_Group);
            }
            context.UserContext_Token = this.UserContext_Token;
            context.UserContext_UserId = this.UserContext_UserId;
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxSuggestionsCount = this.MaxSuggestionsCount;
            context.QueryText = this.QueryText;
            #if MODULAR
            if (this.QueryText == null && ParameterWasBound(nameof(this.QueryText)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SuggestionType != null)
            {
                context.SuggestionType = new List<System.String>(this.SuggestionType);
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
            var request = new Amazon.Kendra.Model.GetQuerySuggestionsRequest();
            
            
             // populate AttributeSuggestionsConfig
            var requestAttributeSuggestionsConfigIsNull = true;
            request.AttributeSuggestionsConfig = new Amazon.Kendra.Model.AttributeSuggestionsGetConfig();
            List<System.String> requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AdditionalResponseAttribute = null;
            if (cmdletContext.AttributeSuggestionsConfig_AdditionalResponseAttribute != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AdditionalResponseAttribute = cmdletContext.AttributeSuggestionsConfig_AdditionalResponseAttribute;
            }
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AdditionalResponseAttribute != null)
            {
                request.AttributeSuggestionsConfig.AdditionalResponseAttributes = requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AdditionalResponseAttribute;
                requestAttributeSuggestionsConfigIsNull = false;
            }
            Amazon.Kendra.Model.AttributeFilter requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AttributeFilter = null;
            if (cmdletContext.AttributeSuggestionsConfig_AttributeFilter != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AttributeFilter = cmdletContext.AttributeSuggestionsConfig_AttributeFilter;
            }
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AttributeFilter != null)
            {
                request.AttributeSuggestionsConfig.AttributeFilter = requestAttributeSuggestionsConfig_attributeSuggestionsConfig_AttributeFilter;
                requestAttributeSuggestionsConfigIsNull = false;
            }
            List<System.String> requestAttributeSuggestionsConfig_attributeSuggestionsConfig_SuggestionAttribute = null;
            if (cmdletContext.AttributeSuggestionsConfig_SuggestionAttribute != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_SuggestionAttribute = cmdletContext.AttributeSuggestionsConfig_SuggestionAttribute;
            }
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_SuggestionAttribute != null)
            {
                request.AttributeSuggestionsConfig.SuggestionAttributes = requestAttributeSuggestionsConfig_attributeSuggestionsConfig_SuggestionAttribute;
                requestAttributeSuggestionsConfigIsNull = false;
            }
            Amazon.Kendra.Model.UserContext requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext = null;
            
             // populate UserContext
            var requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContextIsNull = true;
            requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext = new Amazon.Kendra.Model.UserContext();
            List<Amazon.Kendra.Model.DataSourceGroup> requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_DataSourceGroup = null;
            if (cmdletContext.UserContext_DataSourceGroup != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_DataSourceGroup = cmdletContext.UserContext_DataSourceGroup;
            }
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_DataSourceGroup != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext.DataSourceGroups = requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_DataSourceGroup;
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContextIsNull = false;
            }
            List<System.String> requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_Group = null;
            if (cmdletContext.UserContext_Group != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_Group = cmdletContext.UserContext_Group;
            }
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_Group != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext.Groups = requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_Group;
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContextIsNull = false;
            }
            System.String requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_Token = null;
            if (cmdletContext.UserContext_Token != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_Token = cmdletContext.UserContext_Token;
            }
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_Token != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext.Token = requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_Token;
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContextIsNull = false;
            }
            System.String requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_UserId = null;
            if (cmdletContext.UserContext_UserId != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_UserId = cmdletContext.UserContext_UserId;
            }
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_UserId != null)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext.UserId = requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext_userContext_UserId;
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContextIsNull = false;
            }
             // determine if requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext should be set to null
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContextIsNull)
            {
                requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext = null;
            }
            if (requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext != null)
            {
                request.AttributeSuggestionsConfig.UserContext = requestAttributeSuggestionsConfig_attributeSuggestionsConfig_UserContext;
                requestAttributeSuggestionsConfigIsNull = false;
            }
             // determine if request.AttributeSuggestionsConfig should be set to null
            if (requestAttributeSuggestionsConfigIsNull)
            {
                request.AttributeSuggestionsConfig = null;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.MaxSuggestionsCount != null)
            {
                request.MaxSuggestionsCount = cmdletContext.MaxSuggestionsCount.Value;
            }
            if (cmdletContext.QueryText != null)
            {
                request.QueryText = cmdletContext.QueryText;
            }
            if (cmdletContext.SuggestionType != null)
            {
                request.SuggestionTypes = cmdletContext.SuggestionType;
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
        
        private Amazon.Kendra.Model.GetQuerySuggestionsResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.GetQuerySuggestionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "GetQuerySuggestions");
            try
            {
                #if DESKTOP
                return client.GetQuerySuggestions(request);
                #elif CORECLR
                return client.GetQuerySuggestionsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AttributeSuggestionsConfig_AdditionalResponseAttribute { get; set; }
            public Amazon.Kendra.Model.AttributeFilter AttributeSuggestionsConfig_AttributeFilter { get; set; }
            public List<System.String> AttributeSuggestionsConfig_SuggestionAttribute { get; set; }
            public List<Amazon.Kendra.Model.DataSourceGroup> UserContext_DataSourceGroup { get; set; }
            public List<System.String> UserContext_Group { get; set; }
            public System.String UserContext_Token { get; set; }
            public System.String UserContext_UserId { get; set; }
            public System.String IndexId { get; set; }
            public System.Int32? MaxSuggestionsCount { get; set; }
            public System.String QueryText { get; set; }
            public List<System.String> SuggestionType { get; set; }
            public System.Func<Amazon.Kendra.Model.GetQuerySuggestionsResponse, GetKNDRQuerySuggestionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
