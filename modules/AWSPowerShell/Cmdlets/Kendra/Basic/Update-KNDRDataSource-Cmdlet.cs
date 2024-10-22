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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Updates an Amazon Kendra data source connector.
    /// </summary>
    [Cmdlet("Update", "KNDRDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kendra UpdateDataSource API operation.", Operation = new[] {"UpdateDataSource"}, SelectReturnType = typeof(Amazon.Kendra.Model.UpdateDataSourceResponse))]
    [AWSCmdletOutput("None or Amazon.Kendra.Model.UpdateDataSourceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kendra.Model.UpdateDataSourceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKNDRDataSourceCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey
        /// <summary>
        /// <para>
        /// <para>The identifier of the document attribute used for the condition.</para><para>For example, 'Source_URI' could be an identifier for the attribute or metadata field
        /// that contains source URIs associated with the documents.</para><para>Amazon Kendra currently does not support <c>_document_body</c> as an attribute key
        /// used for the condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey")]
        public System.String CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey
        /// <summary>
        /// <para>
        /// <para>The identifier of the document attribute used for the condition.</para><para>For example, 'Source_URI' could be an identifier for the attribute or metadata field
        /// that contains source URIs associated with the documents.</para><para>Amazon Kendra currently does not support <c>_document_body</c> as an attribute key
        /// used for the condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey")]
        public System.String CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey { get; set; }
        #endregion
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>Configuration information you want to update for the data source connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Kendra.Model.DataSourceConfiguration Configuration { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue
        /// <summary>
        /// <para>
        /// <para>A date expressed as an ISO 8601 string.</para><para>It is important for the time zone to be included in the ISO 8601 date-time format.
        /// For example, 2012-03-25T12:30:10+01:00 is the ISO 8601 date-time format for March
        /// 25th 2012 at 12:30PM (plus 10 seconds) in Central European Time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue")]
        public System.DateTime? CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue
        /// <summary>
        /// <para>
        /// <para>A date expressed as an ISO 8601 string.</para><para>It is important for the time zone to be included in the ISO 8601 date-time format.
        /// For example, 2012-03-25T12:30:10+01:00 is the ISO 8601 date-time format for March
        /// 25th 2012 at 12:30PM (plus 10 seconds) in Central European Time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue")]
        public System.DateTime? CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the data source connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the data source connector you want to update.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index used with the data source connector.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_InlineConfiguration
        /// <summary>
        /// <para>
        /// <para>Configuration information to alter document attributes or metadata fields and content
        /// when ingesting documents into Amazon Kendra.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomDocumentEnrichmentConfiguration_InlineConfigurations")]
        public Amazon.Kendra.Model.InlineCustomDocumentEnrichmentConfiguration[] CustomDocumentEnrichmentConfiguration_InlineConfiguration { get; set; }
        #endregion
        
        #region Parameter PostExtractionHookConfiguration_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role with permission to run a Lambda function
        /// during ingestion. For more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/iam-roles.html">IAM
        /// roles for Amazon Kendra</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_LambdaArn")]
        public System.String PostExtractionHookConfiguration_LambdaArn { get; set; }
        #endregion
        
        #region Parameter PreExtractionHookConfiguration_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role with permission to run a Lambda function
        /// during ingestion. For more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/iam-roles.html">IAM
        /// roles for Amazon Kendra</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_LambdaArn")]
        public System.String PreExtractionHookConfiguration_LambdaArn { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The code for a language you want to update for the data source connector. This allows
        /// you to support a language for all documents when updating the data source. English
        /// is supported by default. For more information on supported languages, including their
        /// codes, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/in-adding-languages.html">Adding
        /// documents in languages other than English</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LanguageCode { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue
        /// <summary>
        /// <para>
        /// <para>A long integer value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue")]
        public System.Int64? CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue
        /// <summary>
        /// <para>
        /// <para>A long integer value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue")]
        public System.Int64? CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A new name for the data source connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator
        /// <summary>
        /// <para>
        /// <para>The condition operator.</para><para>For example, you can use 'Contains' to partially match a string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostExtractionHookConfiguration_InvocationCondition_Operator")]
        [AWSConstantClassSource("Amazon.Kendra.ConditionOperator")]
        public Amazon.Kendra.ConditionOperator CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator
        /// <summary>
        /// <para>
        /// <para>The condition operator.</para><para>For example, you can use 'Contains' to partially match a string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PreExtractionHookConfiguration_InvocationCondition_Operator")]
        [AWSConstantClassSource("Amazon.Kendra.ConditionOperator")]
        public Amazon.Kendra.ConditionOperator CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role with permission to run <c>PreExtractionHookConfiguration</c>
        /// and <c>PostExtractionHookConfiguration</c> for altering document metadata and content
        /// during the document ingestion process. For more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/iam-roles.html">IAM
        /// roles for Amazon Kendra</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDocumentEnrichmentConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role with permission to access the data source
        /// and required resources. For more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/iam-roles.html">IAM
        /// roles for Amazon Kendra</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter PostExtractionHookConfiguration_S3Bucket
        /// <summary>
        /// <para>
        /// <para>Stores the original, raw documents or the structured, parsed documents before and
        /// after altering them. For more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/custom-document-enrichment.html#cde-data-contracts-lambda">Data
        /// contracts for Lambda functions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_S3Bucket")]
        public System.String PostExtractionHookConfiguration_S3Bucket { get; set; }
        #endregion
        
        #region Parameter PreExtractionHookConfiguration_S3Bucket
        /// <summary>
        /// <para>
        /// <para>Stores the original, raw documents or the structured, parsed documents before and
        /// after altering them. For more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/custom-document-enrichment.html#cde-data-contracts-lambda">Data
        /// contracts for Lambda functions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_S3Bucket")]
        public System.String PreExtractionHookConfiguration_S3Bucket { get; set; }
        #endregion
        
        #region Parameter Schedule
        /// <summary>
        /// <para>
        /// <para>The sync schedule you want to update for the data source connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of identifiers of security groups within your Amazon VPC. The security groups
        /// should enable Amazon Kendra to connect to the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SecurityGroupIds")]
        public System.String[] VpcConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue
        /// <summary>
        /// <para>
        /// <para>A list of strings. The default maximum length or number of strings is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue")]
        public System.String[] CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue
        /// <summary>
        /// <para>
        /// <para>A list of strings. The default maximum length or number of strings is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue")]
        public System.String[] CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue
        /// <summary>
        /// <para>
        /// <para>A string, such as "department".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue")]
        public System.String CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue { get; set; }
        #endregion
        
        #region Parameter CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue
        /// <summary>
        /// <para>
        /// <para>A string, such as "department".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue")]
        public System.String CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of identifiers for subnets within your Amazon VPC. The subnets should be able
        /// to connect to each other in the VPC, and they should have outgoing access to the Internet
        /// through a NAT device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SubnetIds")]
        public System.String[] VpcConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.UpdateDataSourceResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KNDRDataSource (UpdateDataSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.UpdateDataSourceResponse, UpdateKNDRDataSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration = this.Configuration;
            if (this.CustomDocumentEnrichmentConfiguration_InlineConfiguration != null)
            {
                context.CustomDocumentEnrichmentConfiguration_InlineConfiguration = new List<Amazon.Kendra.Model.InlineCustomDocumentEnrichmentConfiguration>(this.CustomDocumentEnrichmentConfiguration_InlineConfiguration);
            }
            context.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey = this.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey;
            context.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue = this.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue;
            context.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue = this.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue;
            if (this.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue != null)
            {
                context.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue = new List<System.String>(this.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue);
            }
            context.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue = this.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue;
            context.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator = this.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator;
            context.PostExtractionHookConfiguration_LambdaArn = this.PostExtractionHookConfiguration_LambdaArn;
            context.PostExtractionHookConfiguration_S3Bucket = this.PostExtractionHookConfiguration_S3Bucket;
            context.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey = this.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey;
            context.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue = this.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue;
            context.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue = this.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue;
            if (this.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue != null)
            {
                context.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue = new List<System.String>(this.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue);
            }
            context.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue = this.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue;
            context.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator = this.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator;
            context.PreExtractionHookConfiguration_LambdaArn = this.PreExtractionHookConfiguration_LambdaArn;
            context.PreExtractionHookConfiguration_S3Bucket = this.PreExtractionHookConfiguration_S3Bucket;
            context.CustomDocumentEnrichmentConfiguration_RoleArn = this.CustomDocumentEnrichmentConfiguration_RoleArn;
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LanguageCode = this.LanguageCode;
            context.Name = this.Name;
            context.RoleArn = this.RoleArn;
            context.Schedule = this.Schedule;
            if (this.VpcConfiguration_SecurityGroupId != null)
            {
                context.VpcConfiguration_SecurityGroupId = new List<System.String>(this.VpcConfiguration_SecurityGroupId);
            }
            if (this.VpcConfiguration_SubnetId != null)
            {
                context.VpcConfiguration_SubnetId = new List<System.String>(this.VpcConfiguration_SubnetId);
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
            var request = new Amazon.Kendra.Model.UpdateDataSourceRequest();
            
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = cmdletContext.Configuration;
            }
            
             // populate CustomDocumentEnrichmentConfiguration
            var requestCustomDocumentEnrichmentConfigurationIsNull = true;
            request.CustomDocumentEnrichmentConfiguration = new Amazon.Kendra.Model.CustomDocumentEnrichmentConfiguration();
            List<Amazon.Kendra.Model.InlineCustomDocumentEnrichmentConfiguration> requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_InlineConfiguration = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_InlineConfiguration != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_InlineConfiguration = cmdletContext.CustomDocumentEnrichmentConfiguration_InlineConfiguration;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_InlineConfiguration != null)
            {
                request.CustomDocumentEnrichmentConfiguration.InlineConfigurations = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_InlineConfiguration;
                requestCustomDocumentEnrichmentConfigurationIsNull = false;
            }
            System.String requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_RoleArn = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_RoleArn != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_RoleArn = cmdletContext.CustomDocumentEnrichmentConfiguration_RoleArn;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_RoleArn != null)
            {
                request.CustomDocumentEnrichmentConfiguration.RoleArn = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_RoleArn;
                requestCustomDocumentEnrichmentConfigurationIsNull = false;
            }
            Amazon.Kendra.Model.HookConfiguration requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration = null;
            
             // populate PostExtractionHookConfiguration
            var requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull = true;
            requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration = new Amazon.Kendra.Model.HookConfiguration();
            System.String requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_LambdaArn = null;
            if (cmdletContext.PostExtractionHookConfiguration_LambdaArn != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_LambdaArn = cmdletContext.PostExtractionHookConfiguration_LambdaArn;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_LambdaArn != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration.LambdaArn = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_LambdaArn;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull = false;
            }
            System.String requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_S3Bucket = null;
            if (cmdletContext.PostExtractionHookConfiguration_S3Bucket != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_S3Bucket = cmdletContext.PostExtractionHookConfiguration_S3Bucket;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_S3Bucket != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration.S3Bucket = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_S3Bucket;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull = false;
            }
            Amazon.Kendra.Model.DocumentAttributeCondition requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition = null;
            
             // populate InvocationCondition
            var requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationConditionIsNull = true;
            requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition = new Amazon.Kendra.Model.DocumentAttributeCondition();
            System.String requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey = cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition.ConditionDocumentAttributeKey = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
            Amazon.Kendra.ConditionOperator requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator = cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition.Operator = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
            Amazon.Kendra.Model.DocumentAttributeValue requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue = null;
            
             // populate ConditionOnValue
            var requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull = true;
            requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue = new Amazon.Kendra.Model.DocumentAttributeValue();
            System.DateTime? requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue = cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue.Value;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue.DateValue = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue.Value;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull = false;
            }
            System.Int64? requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue = cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue.Value;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue.LongValue = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue.Value;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull = false;
            }
            List<System.String> requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue = cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue.StringListValue = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull = false;
            }
            System.String requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue = cmdletContext.CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue.StringValue = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull = false;
            }
             // determine if requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue should be set to null
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue = null;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition.ConditionOnValue = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
             // determine if requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition should be set to null
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationConditionIsNull)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition = null;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration.InvocationCondition = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull = false;
            }
             // determine if requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration should be set to null
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration = null;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration != null)
            {
                request.CustomDocumentEnrichmentConfiguration.PostExtractionHookConfiguration = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PostExtractionHookConfiguration;
                requestCustomDocumentEnrichmentConfigurationIsNull = false;
            }
            Amazon.Kendra.Model.HookConfiguration requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration = null;
            
             // populate PreExtractionHookConfiguration
            var requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull = true;
            requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration = new Amazon.Kendra.Model.HookConfiguration();
            System.String requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_LambdaArn = null;
            if (cmdletContext.PreExtractionHookConfiguration_LambdaArn != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_LambdaArn = cmdletContext.PreExtractionHookConfiguration_LambdaArn;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_LambdaArn != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration.LambdaArn = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_LambdaArn;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull = false;
            }
            System.String requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_S3Bucket = null;
            if (cmdletContext.PreExtractionHookConfiguration_S3Bucket != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_S3Bucket = cmdletContext.PreExtractionHookConfiguration_S3Bucket;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_S3Bucket != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration.S3Bucket = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_S3Bucket;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull = false;
            }
            Amazon.Kendra.Model.DocumentAttributeCondition requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition = null;
            
             // populate InvocationCondition
            var requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationConditionIsNull = true;
            requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition = new Amazon.Kendra.Model.DocumentAttributeCondition();
            System.String requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey = cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition.ConditionDocumentAttributeKey = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
            Amazon.Kendra.ConditionOperator requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator = cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition.Operator = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
            Amazon.Kendra.Model.DocumentAttributeValue requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue = null;
            
             // populate ConditionOnValue
            var requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull = true;
            requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue = new Amazon.Kendra.Model.DocumentAttributeValue();
            System.DateTime? requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue = cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue.Value;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue.DateValue = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue.Value;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull = false;
            }
            System.Int64? requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue = cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue.Value;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue.LongValue = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue.Value;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull = false;
            }
            List<System.String> requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue = cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue.StringListValue = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull = false;
            }
            System.String requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue = null;
            if (cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue = cmdletContext.CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue.StringValue = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull = false;
            }
             // determine if requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue should be set to null
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValueIsNull)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue = null;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition.ConditionOnValue = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
             // determine if requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition should be set to null
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationConditionIsNull)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition = null;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition != null)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration.InvocationCondition = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition;
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull = false;
            }
             // determine if requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration should be set to null
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull)
            {
                requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration = null;
            }
            if (requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration != null)
            {
                request.CustomDocumentEnrichmentConfiguration.PreExtractionHookConfiguration = requestCustomDocumentEnrichmentConfiguration_customDocumentEnrichmentConfiguration_PreExtractionHookConfiguration;
                requestCustomDocumentEnrichmentConfigurationIsNull = false;
            }
             // determine if request.CustomDocumentEnrichmentConfiguration should be set to null
            if (requestCustomDocumentEnrichmentConfigurationIsNull)
            {
                request.CustomDocumentEnrichmentConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Schedule != null)
            {
                request.Schedule = cmdletContext.Schedule;
            }
            
             // populate VpcConfiguration
            var requestVpcConfigurationIsNull = true;
            request.VpcConfiguration = new Amazon.Kendra.Model.DataSourceVpcConfiguration();
            List<System.String> requestVpcConfiguration_vpcConfiguration_SecurityGroupId = null;
            if (cmdletContext.VpcConfiguration_SecurityGroupId != null)
            {
                requestVpcConfiguration_vpcConfiguration_SecurityGroupId = cmdletContext.VpcConfiguration_SecurityGroupId;
            }
            if (requestVpcConfiguration_vpcConfiguration_SecurityGroupId != null)
            {
                request.VpcConfiguration.SecurityGroupIds = requestVpcConfiguration_vpcConfiguration_SecurityGroupId;
                requestVpcConfigurationIsNull = false;
            }
            List<System.String> requestVpcConfiguration_vpcConfiguration_SubnetId = null;
            if (cmdletContext.VpcConfiguration_SubnetId != null)
            {
                requestVpcConfiguration_vpcConfiguration_SubnetId = cmdletContext.VpcConfiguration_SubnetId;
            }
            if (requestVpcConfiguration_vpcConfiguration_SubnetId != null)
            {
                request.VpcConfiguration.SubnetIds = requestVpcConfiguration_vpcConfiguration_SubnetId;
                requestVpcConfigurationIsNull = false;
            }
             // determine if request.VpcConfiguration should be set to null
            if (requestVpcConfigurationIsNull)
            {
                request.VpcConfiguration = null;
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
        
        private Amazon.Kendra.Model.UpdateDataSourceResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.UpdateDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "UpdateDataSource");
            try
            {
                #if DESKTOP
                return client.UpdateDataSource(request);
                #elif CORECLR
                return client.UpdateDataSourceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Kendra.Model.DataSourceConfiguration Configuration { get; set; }
            public List<Amazon.Kendra.Model.InlineCustomDocumentEnrichmentConfiguration> CustomDocumentEnrichmentConfiguration_InlineConfiguration { get; set; }
            public System.String CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey { get; set; }
            public System.DateTime? CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue { get; set; }
            public System.Int64? CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue { get; set; }
            public List<System.String> CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue { get; set; }
            public System.String CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue { get; set; }
            public Amazon.Kendra.ConditionOperator CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator { get; set; }
            public System.String PostExtractionHookConfiguration_LambdaArn { get; set; }
            public System.String PostExtractionHookConfiguration_S3Bucket { get; set; }
            public System.String CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionDocumentAttributeKey { get; set; }
            public System.DateTime? CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_DateValue { get; set; }
            public System.Int64? CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_LongValue { get; set; }
            public List<System.String> CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringListValue { get; set; }
            public System.String CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ConditionOnValue_StringValue { get; set; }
            public Amazon.Kendra.ConditionOperator CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator { get; set; }
            public System.String PreExtractionHookConfiguration_LambdaArn { get; set; }
            public System.String PreExtractionHookConfiguration_S3Bucket { get; set; }
            public System.String CustomDocumentEnrichmentConfiguration_RoleArn { get; set; }
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String IndexId { get; set; }
            public System.String LanguageCode { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.String Schedule { get; set; }
            public List<System.String> VpcConfiguration_SecurityGroupId { get; set; }
            public List<System.String> VpcConfiguration_SubnetId { get; set; }
            public System.Func<Amazon.Kendra.Model.UpdateDataSourceResponse, UpdateKNDRDataSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
