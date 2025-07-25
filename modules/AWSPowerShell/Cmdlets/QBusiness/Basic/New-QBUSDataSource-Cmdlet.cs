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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Creates a data source connector for an Amazon Q Business application.
    /// 
    ///  
    /// <para><c>CreateDataSource</c> is a synchronous operation. The operation returns 200 if
    /// the data source was successfully created. Otherwise, an exception is raised.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QBUSDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QBusiness.Model.CreateDataSourceResponse")]
    [AWSCmdlet("Calls the Amazon QBusiness CreateDataSource API operation.", Operation = new[] {"CreateDataSource"}, SelectReturnType = typeof(Amazon.QBusiness.Model.CreateDataSourceResponse))]
    [AWSCmdletOutput("Amazon.QBusiness.Model.CreateDataSourceResponse",
        "This cmdlet returns an Amazon.QBusiness.Model.CreateDataSourceResponse object containing multiple properties."
    )]
    public partial class NewQBUSDataSourceCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para> The identifier of the Amazon Q Business application the data source will be attached
        /// to.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter AudioExtractionConfiguration_AudioExtractionStatus
        /// <summary>
        /// <para>
        /// <para>The status of audio extraction (ENABLED or DISABLED) for processing audio content
        /// from files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus")]
        [AWSConstantClassSource("Amazon.QBusiness.AudioExtractionStatus")]
        public Amazon.QBusiness.AudioExtractionStatus AudioExtractionConfiguration_AudioExtractionStatus { get; set; }
        #endregion
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>Configuration information to connect your data source repository to Amazon Q Business.
        /// Use this parameter to provide a JSON schema with configuration information specific
        /// to your data source connector.</para><para>Each data source has a JSON schema provided by Amazon Q Business that you must use.
        /// For example, the Amazon S3 and Web Crawler connectors require the following JSON schemas:</para><ul><li><para><a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/s3-api.html">Amazon
        /// S3 JSON schema</a></para></li><li><para><a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/web-crawler-api.html">Web
        /// Crawler JSON schema</a></para></li></ul><para>You can find configuration templates for your specific data source using the following
        /// steps:</para><ol><li><para>Navigate to the <a href="https://docs.aws.amazon.com/amazonq/latest/business-use-dg/connectors-list.html">Supported
        /// connectors</a> page in the Amazon Q Business User Guide, and select the data source
        /// of your choice.</para></li><li><para>Then, from your specific data source connector page, select <b>Using the API</b>.
        /// You will find the JSON schema for your data source, including parameter descriptions,
        /// in this section.</para></li></ol>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Management.Automation.PSObject Configuration { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PostInvocationCondition_DateValue
        /// <summary>
        /// <para>
        /// <para>A date expressed as an ISO 8601 string.</para><para>It's important for the time zone to be included in the ISO 8601 date-time format.
        /// For example, 2012-03-25T12:30:10+01:00 is the ISO 8601 date-time format for March
        /// 25th 2012 at 12:30PM (plus 10 seconds) in Central European Time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_DateValue")]
        public System.DateTime? DocumentEnrichmentConfiguration_PostInvocationCondition_DateValue { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PreInvocationCondition_DateValue
        /// <summary>
        /// <para>
        /// <para>A date expressed as an ISO 8601 string.</para><para>It's important for the time zone to be included in the ISO 8601 date-time format.
        /// For example, 2012-03-25T12:30:10+01:00 is the ISO 8601 date-time format for March
        /// 25th 2012 at 12:30PM (plus 10 seconds) in Central European Time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_DateValue")]
        public System.DateTime? DocumentEnrichmentConfiguration_PreInvocationCondition_DateValue { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the data source connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A name for the data source connector.</para>
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ImageExtractionConfiguration_ImageExtractionStatus
        /// <summary>
        /// <para>
        /// <para>Specify whether to extract semantic meaning from images and visuals from documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus")]
        [AWSConstantClassSource("Amazon.QBusiness.ImageExtractionStatus")]
        public Amazon.QBusiness.ImageExtractionStatus ImageExtractionConfiguration_ImageExtractionStatus { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index that you want to use with the data source connector.</para>
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
        
        #region Parameter DocumentEnrichmentConfiguration_InlineConfiguration
        /// <summary>
        /// <para>
        /// <para>Configuration information to alter document attributes or metadata fields and content
        /// when ingesting documents into Amazon Q Business.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_InlineConfigurations")]
        public Amazon.QBusiness.Model.InlineDocumentEnrichmentConfiguration[] DocumentEnrichmentConfiguration_InlineConfiguration { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PostInvocationCondition_Key
        /// <summary>
        /// <para>
        /// <para>The identifier of the document attribute used for the condition.</para><para>For example, 'Source_URI' could be an identifier for the attribute or metadata field
        /// that contains source URIs associated with the documents.</para><para>Amazon Q Business currently doesn't support <c>_document_body</c> as an attribute
        /// key used for the condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Key")]
        public System.String DocumentEnrichmentConfiguration_PostInvocationCondition_Key { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PreInvocationCondition_Key
        /// <summary>
        /// <para>
        /// <para>The identifier of the document attribute used for the condition.</para><para>For example, 'Source_URI' could be an identifier for the attribute or metadata field
        /// that contains source URIs associated with the documents.</para><para>Amazon Q Business currently doesn't support <c>_document_body</c> as an attribute
        /// key used for the condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Key")]
        public System.String DocumentEnrichmentConfiguration_PreInvocationCondition_Key { get; set; }
        #endregion
        
        #region Parameter PostExtractionHookConfiguration_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function during ingestion. For more information,
        /// see <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/cde-lambda-operations.html">Using
        /// Lambda functions for Amazon Q Business document enrichment</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_LambdaArn")]
        public System.String PostExtractionHookConfiguration_LambdaArn { get; set; }
        #endregion
        
        #region Parameter PreExtractionHookConfiguration_LambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function during ingestion. For more information,
        /// see <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/cde-lambda-operations.html">Using
        /// Lambda functions for Amazon Q Business document enrichment</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_LambdaArn")]
        public System.String PreExtractionHookConfiguration_LambdaArn { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PostInvocationCondition_LongValue
        /// <summary>
        /// <para>
        /// <para>A long integer value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_LongValue")]
        public System.Int64? DocumentEnrichmentConfiguration_PostInvocationCondition_LongValue { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PreInvocationCondition_LongValue
        /// <summary>
        /// <para>
        /// <para>A long integer value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_LongValue")]
        public System.Int64? DocumentEnrichmentConfiguration_PreInvocationCondition_LongValue { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PostInvocationCondition_Operator
        /// <summary>
        /// <para>
        /// <para>The identifier of the document attribute used for the condition.</para><para>For example, 'Source_URI' could be an identifier for the attribute or metadata field
        /// that contains source URIs associated with the documents.</para><para>Amazon Q Business currently does not support <c>_document_body</c> as an attribute
        /// key used for the condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator")]
        [AWSConstantClassSource("Amazon.QBusiness.DocumentEnrichmentConditionOperator")]
        public Amazon.QBusiness.DocumentEnrichmentConditionOperator DocumentEnrichmentConfiguration_PostInvocationCondition_Operator { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PreInvocationCondition_Operator
        /// <summary>
        /// <para>
        /// <para>The identifier of the document attribute used for the condition.</para><para>For example, 'Source_URI' could be an identifier for the attribute or metadata field
        /// that contains source URIs associated with the documents.</para><para>Amazon Q Business currently does not support <c>_document_body</c> as an attribute
        /// key used for the condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator")]
        [AWSConstantClassSource("Amazon.QBusiness.DocumentEnrichmentConditionOperator")]
        public Amazon.QBusiness.DocumentEnrichmentConditionOperator DocumentEnrichmentConfiguration_PreInvocationCondition_Operator { get; set; }
        #endregion
        
        #region Parameter PostExtractionHookConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role with permission to run <c>PreExtractionHookConfiguration</c>
        /// and <c>PostExtractionHookConfiguration</c> for altering document metadata and content
        /// during the document ingestion process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_RoleArn")]
        public System.String PostExtractionHookConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter PreExtractionHookConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role with permission to run <c>PreExtractionHookConfiguration</c>
        /// and <c>PostExtractionHookConfiguration</c> for altering document metadata and content
        /// during the document ingestion process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_RoleArn")]
        public System.String PreExtractionHookConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role with permission to access the data source
        /// and required resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter PostExtractionHookConfiguration_S3BucketName
        /// <summary>
        /// <para>
        /// <para>Stores the original, raw documents or the structured, parsed documents before and
        /// after altering them. For more information, see <a href="https://docs.aws.amazon.com/amazonq/latest/business-use-dg/cde-lambda-operations.html#cde-lambda-operations-data-contracts">Data
        /// contracts for Lambda functions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_S3BucketName")]
        public System.String PostExtractionHookConfiguration_S3BucketName { get; set; }
        #endregion
        
        #region Parameter PreExtractionHookConfiguration_S3BucketName
        /// <summary>
        /// <para>
        /// <para>Stores the original, raw documents or the structured, parsed documents before and
        /// after altering them. For more information, see <a href="https://docs.aws.amazon.com/amazonq/latest/business-use-dg/cde-lambda-operations.html#cde-lambda-operations-data-contracts">Data
        /// contracts for Lambda functions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_S3BucketName")]
        public System.String PreExtractionHookConfiguration_S3BucketName { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of identifiers of security groups within your Amazon VPC. The security groups
        /// should enable Amazon Q Business to connect to the data source.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SecurityGroupIds")]
        public System.String[] VpcConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PostInvocationCondition_StringListValue
        /// <summary>
        /// <para>
        /// <para>A list of strings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_StringListValue")]
        public System.String[] DocumentEnrichmentConfiguration_PostInvocationCondition_StringListValue { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PreInvocationCondition_StringListValue
        /// <summary>
        /// <para>
        /// <para>A list of strings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_StringListValue")]
        public System.String[] DocumentEnrichmentConfiguration_PreInvocationCondition_StringListValue { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PostInvocationCondition_StringValue
        /// <summary>
        /// <para>
        /// <para>A string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_StringValue")]
        public System.String DocumentEnrichmentConfiguration_PostInvocationCondition_StringValue { get; set; }
        #endregion
        
        #region Parameter DocumentEnrichmentConfiguration_PreInvocationCondition_StringValue
        /// <summary>
        /// <para>
        /// <para>A string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_StringValue")]
        public System.String DocumentEnrichmentConfiguration_PreInvocationCondition_StringValue { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of identifiers for subnets within your Amazon VPC. The subnets should be able
        /// to connect to each other in the VPC, and they should have outgoing access to the Internet
        /// through a NAT device.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SubnetIds")]
        public System.String[] VpcConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter SyncSchedule
        /// <summary>
        /// <para>
        /// <para>Sets the frequency for Amazon Q Business to check the documents in your data source
        /// repository and update your index. If you don't set a schedule, Amazon Q Business won't
        /// periodically update the index.</para><para>Specify a <c>cron-</c> format schedule string or an empty string to indicate that
        /// the index is updated on demand. You can't specify the <c>Schedule</c> parameter when
        /// the <c>Type</c> parameter is set to <c>CUSTOM</c>. If you do, you receive a <c>ValidationException</c>
        /// exception. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SyncSchedule { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that identify or categorize the data source connector. You
        /// can also use tags to help control access to the data source connector. Tag keys and
        /// values can consist of Unicode letters, digits, white space, and any of the following
        /// symbols: _ . : / = + - @.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QBusiness.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VideoExtractionConfiguration_VideoExtractionStatus
        /// <summary>
        /// <para>
        /// <para>The status of video extraction (ENABLED or DISABLED) for processing video content
        /// from files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus")]
        [AWSConstantClassSource("Amazon.QBusiness.VideoExtractionStatus")]
        public Amazon.QBusiness.VideoExtractionStatus VideoExtractionConfiguration_VideoExtractionStatus { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token you provide to identify a request to create a data source connector. Multiple
        /// calls to the <c>CreateDataSource</c> API with the same client token will create only
        /// one data source connector. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.CreateDataSourceResponse).
        /// Specifying the name of a property of type Amazon.QBusiness.Model.CreateDataSourceResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QBUSDataSource (CreateDataSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.CreateDataSourceResponse, NewQBUSDataSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Configuration = this.Configuration;
            #if MODULAR
            if (this.Configuration == null && ParameterWasBound(nameof(this.Configuration)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DocumentEnrichmentConfiguration_InlineConfiguration != null)
            {
                context.DocumentEnrichmentConfiguration_InlineConfiguration = new List<Amazon.QBusiness.Model.InlineDocumentEnrichmentConfiguration>(this.DocumentEnrichmentConfiguration_InlineConfiguration);
            }
            context.DocumentEnrichmentConfiguration_PostInvocationCondition_Key = this.DocumentEnrichmentConfiguration_PostInvocationCondition_Key;
            context.DocumentEnrichmentConfiguration_PostInvocationCondition_Operator = this.DocumentEnrichmentConfiguration_PostInvocationCondition_Operator;
            context.DocumentEnrichmentConfiguration_PostInvocationCondition_DateValue = this.DocumentEnrichmentConfiguration_PostInvocationCondition_DateValue;
            context.DocumentEnrichmentConfiguration_PostInvocationCondition_LongValue = this.DocumentEnrichmentConfiguration_PostInvocationCondition_LongValue;
            if (this.DocumentEnrichmentConfiguration_PostInvocationCondition_StringListValue != null)
            {
                context.DocumentEnrichmentConfiguration_PostInvocationCondition_StringListValue = new List<System.String>(this.DocumentEnrichmentConfiguration_PostInvocationCondition_StringListValue);
            }
            context.DocumentEnrichmentConfiguration_PostInvocationCondition_StringValue = this.DocumentEnrichmentConfiguration_PostInvocationCondition_StringValue;
            context.PostExtractionHookConfiguration_LambdaArn = this.PostExtractionHookConfiguration_LambdaArn;
            context.PostExtractionHookConfiguration_RoleArn = this.PostExtractionHookConfiguration_RoleArn;
            context.PostExtractionHookConfiguration_S3BucketName = this.PostExtractionHookConfiguration_S3BucketName;
            context.DocumentEnrichmentConfiguration_PreInvocationCondition_Key = this.DocumentEnrichmentConfiguration_PreInvocationCondition_Key;
            context.DocumentEnrichmentConfiguration_PreInvocationCondition_Operator = this.DocumentEnrichmentConfiguration_PreInvocationCondition_Operator;
            context.DocumentEnrichmentConfiguration_PreInvocationCondition_DateValue = this.DocumentEnrichmentConfiguration_PreInvocationCondition_DateValue;
            context.DocumentEnrichmentConfiguration_PreInvocationCondition_LongValue = this.DocumentEnrichmentConfiguration_PreInvocationCondition_LongValue;
            if (this.DocumentEnrichmentConfiguration_PreInvocationCondition_StringListValue != null)
            {
                context.DocumentEnrichmentConfiguration_PreInvocationCondition_StringListValue = new List<System.String>(this.DocumentEnrichmentConfiguration_PreInvocationCondition_StringListValue);
            }
            context.DocumentEnrichmentConfiguration_PreInvocationCondition_StringValue = this.DocumentEnrichmentConfiguration_PreInvocationCondition_StringValue;
            context.PreExtractionHookConfiguration_LambdaArn = this.PreExtractionHookConfiguration_LambdaArn;
            context.PreExtractionHookConfiguration_RoleArn = this.PreExtractionHookConfiguration_RoleArn;
            context.PreExtractionHookConfiguration_S3BucketName = this.PreExtractionHookConfiguration_S3BucketName;
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AudioExtractionConfiguration_AudioExtractionStatus = this.AudioExtractionConfiguration_AudioExtractionStatus;
            context.ImageExtractionConfiguration_ImageExtractionStatus = this.ImageExtractionConfiguration_ImageExtractionStatus;
            context.VideoExtractionConfiguration_VideoExtractionStatus = this.VideoExtractionConfiguration_VideoExtractionStatus;
            context.RoleArn = this.RoleArn;
            context.SyncSchedule = this.SyncSchedule;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QBusiness.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.QBusiness.Model.CreateDataSourceRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Configuration);
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            
             // populate DocumentEnrichmentConfiguration
            var requestDocumentEnrichmentConfigurationIsNull = true;
            request.DocumentEnrichmentConfiguration = new Amazon.QBusiness.Model.DocumentEnrichmentConfiguration();
            List<Amazon.QBusiness.Model.InlineDocumentEnrichmentConfiguration> requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_InlineConfiguration = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_InlineConfiguration != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_InlineConfiguration = cmdletContext.DocumentEnrichmentConfiguration_InlineConfiguration;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_InlineConfiguration != null)
            {
                request.DocumentEnrichmentConfiguration.InlineConfigurations = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_InlineConfiguration;
                requestDocumentEnrichmentConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.HookConfiguration requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration = null;
            
             // populate PostExtractionHookConfiguration
            var requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull = true;
            requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration = new Amazon.QBusiness.Model.HookConfiguration();
            System.String requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_LambdaArn = null;
            if (cmdletContext.PostExtractionHookConfiguration_LambdaArn != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_LambdaArn = cmdletContext.PostExtractionHookConfiguration_LambdaArn;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_LambdaArn != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration.LambdaArn = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_LambdaArn;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull = false;
            }
            System.String requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_RoleArn = null;
            if (cmdletContext.PostExtractionHookConfiguration_RoleArn != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_RoleArn = cmdletContext.PostExtractionHookConfiguration_RoleArn;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_RoleArn != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration.RoleArn = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_RoleArn;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull = false;
            }
            System.String requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_S3BucketName = null;
            if (cmdletContext.PostExtractionHookConfiguration_S3BucketName != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_S3BucketName = cmdletContext.PostExtractionHookConfiguration_S3BucketName;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_S3BucketName != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration.S3BucketName = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_postExtractionHookConfiguration_S3BucketName;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.DocumentAttributeCondition requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition = null;
            
             // populate InvocationCondition
            var requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationConditionIsNull = true;
            requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition = new Amazon.QBusiness.Model.DocumentAttributeCondition();
            System.String requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostInvocationCondition_Key = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_Key != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostInvocationCondition_Key = cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_Key;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostInvocationCondition_Key != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition.Key = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostInvocationCondition_Key;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
            Amazon.QBusiness.DocumentEnrichmentConditionOperator requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostInvocationCondition_Operator = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_Operator != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostInvocationCondition_Operator = cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_Operator;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostInvocationCondition_Operator != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition.Operator = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostInvocationCondition_Operator;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
            Amazon.QBusiness.Model.DocumentAttributeValue requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value = null;
            
             // populate Value
            var requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ValueIsNull = true;
            requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value = new Amazon.QBusiness.Model.DocumentAttributeValue();
            System.DateTime? requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_DateValue = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_DateValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_DateValue = cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_DateValue.Value;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_DateValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value.DateValue = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_DateValue.Value;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ValueIsNull = false;
            }
            System.Int64? requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_LongValue = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_LongValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_LongValue = cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_LongValue.Value;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_LongValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value.LongValue = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_LongValue.Value;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ValueIsNull = false;
            }
            List<System.String> requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_StringListValue = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_StringListValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_StringListValue = cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_StringListValue;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_StringListValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value.StringListValue = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_StringListValue;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ValueIsNull = false;
            }
            System.String requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_StringValue = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_StringValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_StringValue = cmdletContext.DocumentEnrichmentConfiguration_PostInvocationCondition_StringValue;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_StringValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value.StringValue = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PostInvocationCondition_StringValue;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ValueIsNull = false;
            }
             // determine if requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value should be set to null
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_ValueIsNull)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value = null;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition.Value = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Value;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
             // determine if requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition should be set to null
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationConditionIsNull)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition = null;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration.InvocationCondition = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull = false;
            }
             // determine if requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration should be set to null
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfigurationIsNull)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration = null;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration != null)
            {
                request.DocumentEnrichmentConfiguration.PostExtractionHookConfiguration = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PostExtractionHookConfiguration;
                requestDocumentEnrichmentConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.HookConfiguration requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration = null;
            
             // populate PreExtractionHookConfiguration
            var requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull = true;
            requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration = new Amazon.QBusiness.Model.HookConfiguration();
            System.String requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_LambdaArn = null;
            if (cmdletContext.PreExtractionHookConfiguration_LambdaArn != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_LambdaArn = cmdletContext.PreExtractionHookConfiguration_LambdaArn;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_LambdaArn != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration.LambdaArn = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_LambdaArn;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull = false;
            }
            System.String requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_RoleArn = null;
            if (cmdletContext.PreExtractionHookConfiguration_RoleArn != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_RoleArn = cmdletContext.PreExtractionHookConfiguration_RoleArn;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_RoleArn != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration.RoleArn = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_RoleArn;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull = false;
            }
            System.String requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_S3BucketName = null;
            if (cmdletContext.PreExtractionHookConfiguration_S3BucketName != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_S3BucketName = cmdletContext.PreExtractionHookConfiguration_S3BucketName;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_S3BucketName != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration.S3BucketName = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_preExtractionHookConfiguration_S3BucketName;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.DocumentAttributeCondition requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition = null;
            
             // populate InvocationCondition
            var requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationConditionIsNull = true;
            requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition = new Amazon.QBusiness.Model.DocumentAttributeCondition();
            System.String requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreInvocationCondition_Key = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_Key != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreInvocationCondition_Key = cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_Key;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreInvocationCondition_Key != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition.Key = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreInvocationCondition_Key;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
            Amazon.QBusiness.DocumentEnrichmentConditionOperator requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreInvocationCondition_Operator = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_Operator != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreInvocationCondition_Operator = cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_Operator;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreInvocationCondition_Operator != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition.Operator = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreInvocationCondition_Operator;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
            Amazon.QBusiness.Model.DocumentAttributeValue requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value = null;
            
             // populate Value
            var requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ValueIsNull = true;
            requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value = new Amazon.QBusiness.Model.DocumentAttributeValue();
            System.DateTime? requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_DateValue = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_DateValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_DateValue = cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_DateValue.Value;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_DateValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value.DateValue = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_DateValue.Value;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ValueIsNull = false;
            }
            System.Int64? requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_LongValue = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_LongValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_LongValue = cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_LongValue.Value;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_LongValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value.LongValue = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_LongValue.Value;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ValueIsNull = false;
            }
            List<System.String> requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_StringListValue = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_StringListValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_StringListValue = cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_StringListValue;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_StringListValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value.StringListValue = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_StringListValue;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ValueIsNull = false;
            }
            System.String requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_StringValue = null;
            if (cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_StringValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_StringValue = cmdletContext.DocumentEnrichmentConfiguration_PreInvocationCondition_StringValue;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_StringValue != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value.StringValue = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value_documentEnrichmentConfiguration_PreInvocationCondition_StringValue;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ValueIsNull = false;
            }
             // determine if requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value should be set to null
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_ValueIsNull)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value = null;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition.Value = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Value;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationConditionIsNull = false;
            }
             // determine if requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition should be set to null
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationConditionIsNull)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition = null;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition != null)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration.InvocationCondition = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition;
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull = false;
            }
             // determine if requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration should be set to null
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfigurationIsNull)
            {
                requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration = null;
            }
            if (requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration != null)
            {
                request.DocumentEnrichmentConfiguration.PreExtractionHookConfiguration = requestDocumentEnrichmentConfiguration_documentEnrichmentConfiguration_PreExtractionHookConfiguration;
                requestDocumentEnrichmentConfigurationIsNull = false;
            }
             // determine if request.DocumentEnrichmentConfiguration should be set to null
            if (requestDocumentEnrichmentConfigurationIsNull)
            {
                request.DocumentEnrichmentConfiguration = null;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            
             // populate MediaExtractionConfiguration
            var requestMediaExtractionConfigurationIsNull = true;
            request.MediaExtractionConfiguration = new Amazon.QBusiness.Model.MediaExtractionConfiguration();
            Amazon.QBusiness.Model.AudioExtractionConfiguration requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration = null;
            
             // populate AudioExtractionConfiguration
            var requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfigurationIsNull = true;
            requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration = new Amazon.QBusiness.Model.AudioExtractionConfiguration();
            Amazon.QBusiness.AudioExtractionStatus requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_audioExtractionConfiguration_AudioExtractionStatus = null;
            if (cmdletContext.AudioExtractionConfiguration_AudioExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_audioExtractionConfiguration_AudioExtractionStatus = cmdletContext.AudioExtractionConfiguration_AudioExtractionStatus;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_audioExtractionConfiguration_AudioExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration.AudioExtractionStatus = requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_audioExtractionConfiguration_AudioExtractionStatus;
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfigurationIsNull = false;
            }
             // determine if requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration should be set to null
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfigurationIsNull)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration = null;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration != null)
            {
                request.MediaExtractionConfiguration.AudioExtractionConfiguration = requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration;
                requestMediaExtractionConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.ImageExtractionConfiguration requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration = null;
            
             // populate ImageExtractionConfiguration
            var requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfigurationIsNull = true;
            requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration = new Amazon.QBusiness.Model.ImageExtractionConfiguration();
            Amazon.QBusiness.ImageExtractionStatus requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_imageExtractionConfiguration_ImageExtractionStatus = null;
            if (cmdletContext.ImageExtractionConfiguration_ImageExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_imageExtractionConfiguration_ImageExtractionStatus = cmdletContext.ImageExtractionConfiguration_ImageExtractionStatus;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_imageExtractionConfiguration_ImageExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration.ImageExtractionStatus = requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_imageExtractionConfiguration_ImageExtractionStatus;
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfigurationIsNull = false;
            }
             // determine if requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration should be set to null
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfigurationIsNull)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration = null;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration != null)
            {
                request.MediaExtractionConfiguration.ImageExtractionConfiguration = requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration;
                requestMediaExtractionConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.VideoExtractionConfiguration requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration = null;
            
             // populate VideoExtractionConfiguration
            var requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfigurationIsNull = true;
            requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration = new Amazon.QBusiness.Model.VideoExtractionConfiguration();
            Amazon.QBusiness.VideoExtractionStatus requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_videoExtractionConfiguration_VideoExtractionStatus = null;
            if (cmdletContext.VideoExtractionConfiguration_VideoExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_videoExtractionConfiguration_VideoExtractionStatus = cmdletContext.VideoExtractionConfiguration_VideoExtractionStatus;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_videoExtractionConfiguration_VideoExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration.VideoExtractionStatus = requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_videoExtractionConfiguration_VideoExtractionStatus;
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfigurationIsNull = false;
            }
             // determine if requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration should be set to null
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfigurationIsNull)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration = null;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration != null)
            {
                request.MediaExtractionConfiguration.VideoExtractionConfiguration = requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration;
                requestMediaExtractionConfigurationIsNull = false;
            }
             // determine if request.MediaExtractionConfiguration should be set to null
            if (requestMediaExtractionConfigurationIsNull)
            {
                request.MediaExtractionConfiguration = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SyncSchedule != null)
            {
                request.SyncSchedule = cmdletContext.SyncSchedule;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VpcConfiguration
            var requestVpcConfigurationIsNull = true;
            request.VpcConfiguration = new Amazon.QBusiness.Model.DataSourceVpcConfiguration();
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
        
        private Amazon.QBusiness.Model.CreateDataSourceResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.CreateDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "CreateDataSource");
            try
            {
                return client.CreateDataSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String ClientToken { get; set; }
            public System.Management.Automation.PSObject Configuration { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public List<Amazon.QBusiness.Model.InlineDocumentEnrichmentConfiguration> DocumentEnrichmentConfiguration_InlineConfiguration { get; set; }
            public System.String DocumentEnrichmentConfiguration_PostInvocationCondition_Key { get; set; }
            public Amazon.QBusiness.DocumentEnrichmentConditionOperator DocumentEnrichmentConfiguration_PostInvocationCondition_Operator { get; set; }
            public System.DateTime? DocumentEnrichmentConfiguration_PostInvocationCondition_DateValue { get; set; }
            public System.Int64? DocumentEnrichmentConfiguration_PostInvocationCondition_LongValue { get; set; }
            public List<System.String> DocumentEnrichmentConfiguration_PostInvocationCondition_StringListValue { get; set; }
            public System.String DocumentEnrichmentConfiguration_PostInvocationCondition_StringValue { get; set; }
            public System.String PostExtractionHookConfiguration_LambdaArn { get; set; }
            public System.String PostExtractionHookConfiguration_RoleArn { get; set; }
            public System.String PostExtractionHookConfiguration_S3BucketName { get; set; }
            public System.String DocumentEnrichmentConfiguration_PreInvocationCondition_Key { get; set; }
            public Amazon.QBusiness.DocumentEnrichmentConditionOperator DocumentEnrichmentConfiguration_PreInvocationCondition_Operator { get; set; }
            public System.DateTime? DocumentEnrichmentConfiguration_PreInvocationCondition_DateValue { get; set; }
            public System.Int64? DocumentEnrichmentConfiguration_PreInvocationCondition_LongValue { get; set; }
            public List<System.String> DocumentEnrichmentConfiguration_PreInvocationCondition_StringListValue { get; set; }
            public System.String DocumentEnrichmentConfiguration_PreInvocationCondition_StringValue { get; set; }
            public System.String PreExtractionHookConfiguration_LambdaArn { get; set; }
            public System.String PreExtractionHookConfiguration_RoleArn { get; set; }
            public System.String PreExtractionHookConfiguration_S3BucketName { get; set; }
            public System.String IndexId { get; set; }
            public Amazon.QBusiness.AudioExtractionStatus AudioExtractionConfiguration_AudioExtractionStatus { get; set; }
            public Amazon.QBusiness.ImageExtractionStatus ImageExtractionConfiguration_ImageExtractionStatus { get; set; }
            public Amazon.QBusiness.VideoExtractionStatus VideoExtractionConfiguration_VideoExtractionStatus { get; set; }
            public System.String RoleArn { get; set; }
            public System.String SyncSchedule { get; set; }
            public List<Amazon.QBusiness.Model.Tag> Tag { get; set; }
            public List<System.String> VpcConfiguration_SecurityGroupId { get; set; }
            public List<System.String> VpcConfiguration_SubnetId { get; set; }
            public System.Func<Amazon.QBusiness.Model.CreateDataSourceResponse, NewQBUSDataSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
