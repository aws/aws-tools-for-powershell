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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Retrieves content from knowledge sources based on a query.
    /// </summary>
    [Cmdlet("Invoke", "QCRetrieve", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.RetrieveResult")]
    [AWSCmdlet("Calls the Amazon Q Connect Retrieve API operation.", Operation = new[] {"Retrieve"}, SelectReturnType = typeof(Amazon.QConnect.Model.RetrieveResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.RetrieveResult or Amazon.QConnect.Model.RetrieveResponse",
        "This cmdlet returns a collection of Amazon.QConnect.Model.RetrieveResult objects.",
        "The service call response (type Amazon.QConnect.Model.RetrieveResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeQCRetrieveCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_AndAll
        /// <summary>
        /// <para>
        /// <para>Filter configuration that requires all conditions to be met.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_AndAll")]
        public Amazon.QConnect.Model.RetrievalFilterConfiguration[] Filter_AndAll { get; set; }
        #endregion
        
        #region Parameter KnowledgeSource_AssistantAssociationId
        /// <summary>
        /// <para>
        /// <para>The list of assistant association identifiers for the knowledge source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_KnowledgeSource_AssistantAssociationIds")]
        public System.String[] KnowledgeSource_AssistantAssociationId { get; set; }
        #endregion
        
        #region Parameter AssistantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect assistant for content retrieval.</para>
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
        public System.String AssistantId { get; set; }
        #endregion
        
        #region Parameter Equals_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_Equals_Key")]
        public System.String Equals_Key { get; set; }
        #endregion
        
        #region Parameter GreaterThan_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_GreaterThan_Key")]
        public System.String GreaterThan_Key { get; set; }
        #endregion
        
        #region Parameter GreaterThanOrEquals_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_GreaterThanOrEquals_Key")]
        public System.String GreaterThanOrEquals_Key { get; set; }
        #endregion
        
        #region Parameter In_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_In_Key")]
        public System.String In_Key { get; set; }
        #endregion
        
        #region Parameter LessThan_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_LessThan_Key")]
        public System.String LessThan_Key { get; set; }
        #endregion
        
        #region Parameter LessThanOrEquals_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_LessThanOrEquals_Key")]
        public System.String LessThanOrEquals_Key { get; set; }
        #endregion
        
        #region Parameter ListContains_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_ListContains_Key")]
        public System.String ListContains_Key { get; set; }
        #endregion
        
        #region Parameter NotEquals_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_NotEquals_Key")]
        public System.String NotEquals_Key { get; set; }
        #endregion
        
        #region Parameter NotIn_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_NotIn_Key")]
        public System.String NotIn_Key { get; set; }
        #endregion
        
        #region Parameter StartsWith_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_StartsWith_Key")]
        public System.String StartsWith_Key { get; set; }
        #endregion
        
        #region Parameter StringContains_Key
        /// <summary>
        /// <para>
        /// <para>The key of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_StringContains_Key")]
        public System.String StringContains_Key { get; set; }
        #endregion
        
        #region Parameter RetrievalConfiguration_NumberOfResult
        /// <summary>
        /// <para>
        /// <para>The number of results to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_NumberOfResults")]
        public System.Int32? RetrievalConfiguration_NumberOfResult { get; set; }
        #endregion
        
        #region Parameter Filter_OrAll
        /// <summary>
        /// <para>
        /// <para>Filter configuration where any condition can be met.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_OrAll")]
        public Amazon.QConnect.Model.RetrievalFilterConfiguration[] Filter_OrAll { get; set; }
        #endregion
        
        #region Parameter RetrievalConfiguration_OverrideKnowledgeBaseSearchType
        /// <summary>
        /// <para>
        /// <para>Override setting for the knowledge base search type during retrieval.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QConnect.KnowledgeBaseSearchType")]
        public Amazon.QConnect.KnowledgeBaseSearchType RetrievalConfiguration_OverrideKnowledgeBaseSearchType { get; set; }
        #endregion
        
        #region Parameter RetrievalQuery
        /// <summary>
        /// <para>
        /// <para>The query for content retrieval.</para>
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
        public System.String RetrievalQuery { get; set; }
        #endregion
        
        #region Parameter Equals_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_Equals_Value")]
        public System.Management.Automation.PSObject Equals_Value { get; set; }
        #endregion
        
        #region Parameter GreaterThan_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_GreaterThan_Value")]
        public System.Management.Automation.PSObject GreaterThan_Value { get; set; }
        #endregion
        
        #region Parameter GreaterThanOrEquals_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_GreaterThanOrEquals_Value")]
        public System.Management.Automation.PSObject GreaterThanOrEquals_Value { get; set; }
        #endregion
        
        #region Parameter In_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_In_Value")]
        public System.Management.Automation.PSObject In_Value { get; set; }
        #endregion
        
        #region Parameter LessThan_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_LessThan_Value")]
        public System.Management.Automation.PSObject LessThan_Value { get; set; }
        #endregion
        
        #region Parameter LessThanOrEquals_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_LessThanOrEquals_Value")]
        public System.Management.Automation.PSObject LessThanOrEquals_Value { get; set; }
        #endregion
        
        #region Parameter ListContains_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_ListContains_Value")]
        public System.Management.Automation.PSObject ListContains_Value { get; set; }
        #endregion
        
        #region Parameter NotEquals_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_NotEquals_Value")]
        public System.Management.Automation.PSObject NotEquals_Value { get; set; }
        #endregion
        
        #region Parameter NotIn_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_NotIn_Value")]
        public System.Management.Automation.PSObject NotIn_Value { get; set; }
        #endregion
        
        #region Parameter StartsWith_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_StartsWith_Value")]
        public System.Management.Automation.PSObject StartsWith_Value { get; set; }
        #endregion
        
        #region Parameter StringContains_Value
        /// <summary>
        /// <para>
        /// <para>The value of the filter attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetrievalConfiguration_Filter_StringContains_Value")]
        public System.Management.Automation.PSObject StringContains_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.RetrieveResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.RetrieveResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssistantId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-QCRetrieve (Retrieve)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.RetrieveResponse, InvokeQCRetrieveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filter_AndAll != null)
            {
                context.Filter_AndAll = new List<Amazon.QConnect.Model.RetrievalFilterConfiguration>(this.Filter_AndAll);
            }
            context.Equals_Key = this.Equals_Key;
            context.Equals_Value = this.Equals_Value;
            context.GreaterThan_Key = this.GreaterThan_Key;
            context.GreaterThan_Value = this.GreaterThan_Value;
            context.GreaterThanOrEquals_Key = this.GreaterThanOrEquals_Key;
            context.GreaterThanOrEquals_Value = this.GreaterThanOrEquals_Value;
            context.In_Key = this.In_Key;
            context.In_Value = this.In_Value;
            context.LessThan_Key = this.LessThan_Key;
            context.LessThan_Value = this.LessThan_Value;
            context.LessThanOrEquals_Key = this.LessThanOrEquals_Key;
            context.LessThanOrEquals_Value = this.LessThanOrEquals_Value;
            context.ListContains_Key = this.ListContains_Key;
            context.ListContains_Value = this.ListContains_Value;
            context.NotEquals_Key = this.NotEquals_Key;
            context.NotEquals_Value = this.NotEquals_Value;
            context.NotIn_Key = this.NotIn_Key;
            context.NotIn_Value = this.NotIn_Value;
            if (this.Filter_OrAll != null)
            {
                context.Filter_OrAll = new List<Amazon.QConnect.Model.RetrievalFilterConfiguration>(this.Filter_OrAll);
            }
            context.StartsWith_Key = this.StartsWith_Key;
            context.StartsWith_Value = this.StartsWith_Value;
            context.StringContains_Key = this.StringContains_Key;
            context.StringContains_Value = this.StringContains_Value;
            if (this.KnowledgeSource_AssistantAssociationId != null)
            {
                context.KnowledgeSource_AssistantAssociationId = new List<System.String>(this.KnowledgeSource_AssistantAssociationId);
            }
            context.RetrievalConfiguration_NumberOfResult = this.RetrievalConfiguration_NumberOfResult;
            context.RetrievalConfiguration_OverrideKnowledgeBaseSearchType = this.RetrievalConfiguration_OverrideKnowledgeBaseSearchType;
            context.RetrievalQuery = this.RetrievalQuery;
            #if MODULAR
            if (this.RetrievalQuery == null && ParameterWasBound(nameof(this.RetrievalQuery)))
            {
                WriteWarning("You are passing $null as a value for parameter RetrievalQuery which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.RetrieveRequest();
            
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            
             // populate RetrievalConfiguration
            var requestRetrievalConfigurationIsNull = true;
            request.RetrievalConfiguration = new Amazon.QConnect.Model.RetrievalConfiguration();
            System.Int32? requestRetrievalConfiguration_retrievalConfiguration_NumberOfResult = null;
            if (cmdletContext.RetrievalConfiguration_NumberOfResult != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_NumberOfResult = cmdletContext.RetrievalConfiguration_NumberOfResult.Value;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_NumberOfResult != null)
            {
                request.RetrievalConfiguration.NumberOfResults = requestRetrievalConfiguration_retrievalConfiguration_NumberOfResult.Value;
                requestRetrievalConfigurationIsNull = false;
            }
            Amazon.QConnect.KnowledgeBaseSearchType requestRetrievalConfiguration_retrievalConfiguration_OverrideKnowledgeBaseSearchType = null;
            if (cmdletContext.RetrievalConfiguration_OverrideKnowledgeBaseSearchType != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_OverrideKnowledgeBaseSearchType = cmdletContext.RetrievalConfiguration_OverrideKnowledgeBaseSearchType;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_OverrideKnowledgeBaseSearchType != null)
            {
                request.RetrievalConfiguration.OverrideKnowledgeBaseSearchType = requestRetrievalConfiguration_retrievalConfiguration_OverrideKnowledgeBaseSearchType;
                requestRetrievalConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.KnowledgeSource requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource = null;
            
             // populate KnowledgeSource
            var requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSourceIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource = new Amazon.QConnect.Model.KnowledgeSource();
            List<System.String> requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource_knowledgeSource_AssistantAssociationId = null;
            if (cmdletContext.KnowledgeSource_AssistantAssociationId != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource_knowledgeSource_AssistantAssociationId = cmdletContext.KnowledgeSource_AssistantAssociationId;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource_knowledgeSource_AssistantAssociationId != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource.AssistantAssociationIds = requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource_knowledgeSource_AssistantAssociationId;
                requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSourceIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSourceIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource != null)
            {
                request.RetrievalConfiguration.KnowledgeSource = requestRetrievalConfiguration_retrievalConfiguration_KnowledgeSource;
                requestRetrievalConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.RetrievalFilterConfiguration requestRetrievalConfiguration_retrievalConfiguration_Filter = null;
            
             // populate Filter
            var requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter = new Amazon.QConnect.Model.RetrievalFilterConfiguration();
            List<Amazon.QConnect.Model.RetrievalFilterConfiguration> requestRetrievalConfiguration_retrievalConfiguration_Filter_filter_AndAll = null;
            if (cmdletContext.Filter_AndAll != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_filter_AndAll = cmdletContext.Filter_AndAll;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_filter_AndAll != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.AndAll = requestRetrievalConfiguration_retrievalConfiguration_Filter_filter_AndAll;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            List<Amazon.QConnect.Model.RetrievalFilterConfiguration> requestRetrievalConfiguration_retrievalConfiguration_Filter_filter_OrAll = null;
            if (cmdletContext.Filter_OrAll != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_filter_OrAll = cmdletContext.Filter_OrAll;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_filter_OrAll != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.OrAll = requestRetrievalConfiguration_retrievalConfiguration_Filter_filter_OrAll;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals = null;
            
             // populate Equals
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_EqualsIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals_equals_Key = null;
            if (cmdletContext.Equals_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals_equals_Key = cmdletContext.Equals_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals_equals_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals_equals_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_EqualsIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals_equals_Value = null;
            if (cmdletContext.Equals_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals_equals_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Equals_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals_equals_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals_equals_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_EqualsIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_EqualsIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.Equals = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_Equals;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan = null;
            
             // populate GreaterThan
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan_greaterThan_Key = null;
            if (cmdletContext.GreaterThan_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan_greaterThan_Key = cmdletContext.GreaterThan_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan_greaterThan_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan_greaterThan_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan_greaterThan_Value = null;
            if (cmdletContext.GreaterThan_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan_greaterThan_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.GreaterThan_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan_greaterThan_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan_greaterThan_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.GreaterThan = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThan;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals = null;
            
             // populate GreaterThanOrEquals
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEqualsIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Key = null;
            if (cmdletContext.GreaterThanOrEquals_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Key = cmdletContext.GreaterThanOrEquals_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEqualsIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Value = null;
            if (cmdletContext.GreaterThanOrEquals_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.GreaterThanOrEquals_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals_greaterThanOrEquals_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEqualsIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEqualsIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.GreaterThanOrEquals = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_GreaterThanOrEquals;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In = null;
            
             // populate In
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_InIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In_in_Key = null;
            if (cmdletContext.In_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In_in_Key = cmdletContext.In_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In_in_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In_in_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_InIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In_in_Value = null;
            if (cmdletContext.In_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In_in_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.In_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In_in_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In_in_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_InIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_InIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.In = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_In;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan = null;
            
             // populate LessThan
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan_lessThan_Key = null;
            if (cmdletContext.LessThan_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan_lessThan_Key = cmdletContext.LessThan_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan_lessThan_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan_lessThan_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan_lessThan_Value = null;
            if (cmdletContext.LessThan_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan_lessThan_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.LessThan_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan_lessThan_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan_lessThan_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.LessThan = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThan;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals = null;
            
             // populate LessThanOrEquals
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEqualsIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Key = null;
            if (cmdletContext.LessThanOrEquals_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Key = cmdletContext.LessThanOrEquals_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEqualsIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Value = null;
            if (cmdletContext.LessThanOrEquals_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.LessThanOrEquals_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals_lessThanOrEquals_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEqualsIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEqualsIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.LessThanOrEquals = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_LessThanOrEquals;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains = null;
            
             // populate ListContains
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContainsIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains_listContains_Key = null;
            if (cmdletContext.ListContains_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains_listContains_Key = cmdletContext.ListContains_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains_listContains_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains_listContains_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContainsIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains_listContains_Value = null;
            if (cmdletContext.ListContains_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains_listContains_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.ListContains_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains_listContains_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains_listContains_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContainsIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContainsIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.ListContains = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_ListContains;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals = null;
            
             // populate NotEquals
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEqualsIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals_notEquals_Key = null;
            if (cmdletContext.NotEquals_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals_notEquals_Key = cmdletContext.NotEquals_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals_notEquals_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals_notEquals_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEqualsIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals_notEquals_Value = null;
            if (cmdletContext.NotEquals_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals_notEquals_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.NotEquals_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals_notEquals_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals_notEquals_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEqualsIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEqualsIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.NotEquals = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotEquals;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn = null;
            
             // populate NotIn
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotInIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn_notIn_Key = null;
            if (cmdletContext.NotIn_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn_notIn_Key = cmdletContext.NotIn_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn_notIn_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn_notIn_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotInIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn_notIn_Value = null;
            if (cmdletContext.NotIn_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn_notIn_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.NotIn_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn_notIn_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn_notIn_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotInIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotInIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.NotIn = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_NotIn;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith = null;
            
             // populate StartsWith
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWithIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith_startsWith_Key = null;
            if (cmdletContext.StartsWith_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith_startsWith_Key = cmdletContext.StartsWith_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith_startsWith_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith_startsWith_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWithIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith_startsWith_Value = null;
            if (cmdletContext.StartsWith_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith_startsWith_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.StartsWith_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith_startsWith_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith_startsWith_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWithIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWithIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.StartsWith = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StartsWith;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
            Amazon.QConnect.Model.FilterAttribute requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains = null;
            
             // populate StringContains
            var requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContainsIsNull = true;
            requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains = new Amazon.QConnect.Model.FilterAttribute();
            System.String requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains_stringContains_Key = null;
            if (cmdletContext.StringContains_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains_stringContains_Key = cmdletContext.StringContains_Key;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains_stringContains_Key != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains.Key = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains_stringContains_Key;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContainsIsNull = false;
            }
            Amazon.Runtime.Documents.Document? requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains_stringContains_Value = null;
            if (cmdletContext.StringContains_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains_stringContains_Value = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.StringContains_Value);
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains_stringContains_Value != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains.Value = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains_stringContains_Value.Value;
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContainsIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContainsIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains != null)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter.StringContains = requestRetrievalConfiguration_retrievalConfiguration_Filter_retrievalConfiguration_Filter_StringContains;
                requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull = false;
            }
             // determine if requestRetrievalConfiguration_retrievalConfiguration_Filter should be set to null
            if (requestRetrievalConfiguration_retrievalConfiguration_FilterIsNull)
            {
                requestRetrievalConfiguration_retrievalConfiguration_Filter = null;
            }
            if (requestRetrievalConfiguration_retrievalConfiguration_Filter != null)
            {
                request.RetrievalConfiguration.Filter = requestRetrievalConfiguration_retrievalConfiguration_Filter;
                requestRetrievalConfigurationIsNull = false;
            }
             // determine if request.RetrievalConfiguration should be set to null
            if (requestRetrievalConfigurationIsNull)
            {
                request.RetrievalConfiguration = null;
            }
            if (cmdletContext.RetrievalQuery != null)
            {
                request.RetrievalQuery = cmdletContext.RetrievalQuery;
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
        
        private Amazon.QConnect.Model.RetrieveResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.RetrieveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "Retrieve");
            try
            {
                #if DESKTOP
                return client.Retrieve(request);
                #elif CORECLR
                return client.RetrieveAsync(request).GetAwaiter().GetResult();
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
            public System.String AssistantId { get; set; }
            public List<Amazon.QConnect.Model.RetrievalFilterConfiguration> Filter_AndAll { get; set; }
            public System.String Equals_Key { get; set; }
            public System.Management.Automation.PSObject Equals_Value { get; set; }
            public System.String GreaterThan_Key { get; set; }
            public System.Management.Automation.PSObject GreaterThan_Value { get; set; }
            public System.String GreaterThanOrEquals_Key { get; set; }
            public System.Management.Automation.PSObject GreaterThanOrEquals_Value { get; set; }
            public System.String In_Key { get; set; }
            public System.Management.Automation.PSObject In_Value { get; set; }
            public System.String LessThan_Key { get; set; }
            public System.Management.Automation.PSObject LessThan_Value { get; set; }
            public System.String LessThanOrEquals_Key { get; set; }
            public System.Management.Automation.PSObject LessThanOrEquals_Value { get; set; }
            public System.String ListContains_Key { get; set; }
            public System.Management.Automation.PSObject ListContains_Value { get; set; }
            public System.String NotEquals_Key { get; set; }
            public System.Management.Automation.PSObject NotEquals_Value { get; set; }
            public System.String NotIn_Key { get; set; }
            public System.Management.Automation.PSObject NotIn_Value { get; set; }
            public List<Amazon.QConnect.Model.RetrievalFilterConfiguration> Filter_OrAll { get; set; }
            public System.String StartsWith_Key { get; set; }
            public System.Management.Automation.PSObject StartsWith_Value { get; set; }
            public System.String StringContains_Key { get; set; }
            public System.Management.Automation.PSObject StringContains_Value { get; set; }
            public List<System.String> KnowledgeSource_AssistantAssociationId { get; set; }
            public System.Int32? RetrievalConfiguration_NumberOfResult { get; set; }
            public Amazon.QConnect.KnowledgeBaseSearchType RetrievalConfiguration_OverrideKnowledgeBaseSearchType { get; set; }
            public System.String RetrievalQuery { get; set; }
            public System.Func<Amazon.QConnect.Model.RetrieveResponse, InvokeQCRetrieveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
