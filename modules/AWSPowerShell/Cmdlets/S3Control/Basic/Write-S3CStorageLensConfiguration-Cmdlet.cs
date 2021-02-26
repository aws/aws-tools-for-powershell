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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// Puts an Amazon S3 Storage Lens configuration. For more information about S3 Storage
    /// Lens, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/storage_lens.html">Working
    /// with Amazon S3 Storage Lens</a> in the <i>Amazon Simple Storage Service User Guide</i>.
    /// 
    ///  <note><para>
    /// To use this action, you must have permission to perform the <code>s3:PutStorageLensConfiguration</code>
    /// action. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/storage_lens_iam_permissions.html">Setting
    /// permissions to use Amazon S3 Storage Lens</a> in the <i>Amazon Simple Storage Service
    /// User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "S3CStorageLensConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Control PutStorageLensConfiguration API operation.", Operation = new[] {"PutStorageLensConfiguration"}, SelectReturnType = typeof(Amazon.S3Control.Model.PutStorageLensConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3Control.Model.PutStorageLensConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Control.Model.PutStorageLensConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3CStorageLensConfigurationCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The account ID of the requester.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_AccountId
        /// <summary>
        /// <para>
        /// <para>The account ID of the owner of the S3 Storage Lens metrics export bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_DataExport_S3BucketDestination_AccountId")]
        public System.String S3BucketDestination_AccountId { get; set; }
        #endregion
        
        #region Parameter AwsOrg_Arn
        /// <summary>
        /// <para>
        /// <para>A container for the Amazon Resource Name (ARN) of the AWS organization. This property
        /// is read-only and follows the following format: <code> arn:aws:organizations:<i>us-east-1</i>:<i>example-account-id</i>:organization/<i>o-ex2l495dck</i></code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_AwsOrg_Arn")]
        public System.String AwsOrg_Arn { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the bucket. This property is read-only and follows
        /// the following format: <code> arn:aws:s3:<i>us-east-1</i>:<i>example-account-id</i>:bucket/<i>your-destination-bucket-name</i></code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_DataExport_S3BucketDestination_Arn")]
        public System.String S3BucketDestination_Arn { get; set; }
        #endregion
        
        #region Parameter Exclude_Bucket
        /// <summary>
        /// <para>
        /// <para>A container for the S3 Storage Lens bucket excludes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_Exclude_Buckets")]
        public System.String[] Exclude_Bucket { get; set; }
        #endregion
        
        #region Parameter Include_Bucket
        /// <summary>
        /// <para>
        /// <para>A container for the S3 Storage Lens bucket includes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_Include_Buckets")]
        public System.String[] Include_Bucket { get; set; }
        #endregion
        
        #region Parameter ConfigId
        /// <summary>
        /// <para>
        /// <para>The ID of the S3 Storage Lens configuration.</para>
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
        public System.String ConfigId { get; set; }
        #endregion
        
        #region Parameter SelectionCriteria_Delimiter
        /// <summary>
        /// <para>
        /// <para>A container for the delimiter of the selection criteria being used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_Delimiter")]
        public System.String SelectionCriteria_Delimiter { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_Format
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_DataExport_S3BucketDestination_Format")]
        [AWSConstantClassSource("Amazon.S3Control.Format")]
        public Amazon.S3Control.Format S3BucketDestination_Format { get; set; }
        #endregion
        
        #region Parameter StorageLensConfiguration_Id
        /// <summary>
        /// <para>
        /// <para>A container for the Amazon S3 Storage Lens configuration ID.</para>
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
        public System.String StorageLensConfiguration_Id { get; set; }
        #endregion
        
        #region Parameter StorageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled
        /// <summary>
        /// <para>
        /// <para>A container for whether the activity metrics are enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StorageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled { get; set; }
        #endregion
        
        #region Parameter StorageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled
        /// <summary>
        /// <para>
        /// <para>A container for whether the activity metrics are enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics_IsEnabled")]
        public System.Boolean? StorageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled { get; set; }
        #endregion
        
        #region Parameter StorageMetrics_IsEnabled
        /// <summary>
        /// <para>
        /// <para>A container for whether prefix-level storage metrics are enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_IsEnabled")]
        public System.Boolean? StorageMetrics_IsEnabled { get; set; }
        #endregion
        
        #region Parameter StorageLensConfiguration_IsEnabled
        /// <summary>
        /// <para>
        /// <para>A container for whether the S3 Storage Lens configuration is enabled.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? StorageLensConfiguration_IsEnabled { get; set; }
        #endregion
        
        #region Parameter SSEKMS_KeyId
        /// <summary>
        /// <para>
        /// <para>A container for the ARN of the SSE-KMS encryption. This property is read-only and
        /// follows the following format: <code> arn:aws:kms:<i>us-east-1</i>:<i>example-account-id</i>:key/<i>example-9a73-4afc-8d29-8f5900cef44e</i></code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS_KeyId")]
        public System.String SSEKMS_KeyId { get; set; }
        #endregion
        
        #region Parameter SelectionCriteria_MaxDepth
        /// <summary>
        /// <para>
        /// <para>The max depth of the selection criteria</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_MaxDepth")]
        public System.Int32? SelectionCriteria_MaxDepth { get; set; }
        #endregion
        
        #region Parameter SelectionCriteria_MinStorageBytesPercentage
        /// <summary>
        /// <para>
        /// <para>The minimum number of storage bytes percentage whose metrics will be selected.</para><note><para>You must choose a value greater than or equal to <code>1.0</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_MinStorageBytesPercentage")]
        public System.Double? SelectionCriteria_MinStorageBytesPercentage { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_OutputSchemaVersion
        /// <summary>
        /// <para>
        /// <para>The schema version of the export file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_DataExport_S3BucketDestination_OutputSchemaVersion")]
        [AWSConstantClassSource("Amazon.S3Control.OutputSchemaVersion")]
        public Amazon.S3Control.OutputSchemaVersion S3BucketDestination_OutputSchemaVersion { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix of the destination bucket where the metrics export will be delivered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_DataExport_S3BucketDestination_Prefix")]
        public System.String S3BucketDestination_Prefix { get; set; }
        #endregion
        
        #region Parameter Exclude_Region
        /// <summary>
        /// <para>
        /// <para>A container for the S3 Storage Lens Region excludes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_Exclude_Regions")]
        public System.String[] Exclude_Region { get; set; }
        #endregion
        
        #region Parameter Include_Region
        /// <summary>
        /// <para>
        /// <para>A container for the S3 Storage Lens Region includes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_Include_Regions")]
        public System.String[] Include_Region { get; set; }
        #endregion
        
        #region Parameter Encryption_SSES3
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSES3")]
        public Amazon.S3Control.Model.SSES3 Encryption_SSES3 { get; set; }
        #endregion
        
        #region Parameter StorageLensConfiguration_StorageLensArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the S3 Storage Lens configuration. This property
        /// is read-only and follows the following format: <code> arn:aws:s3:<i>us-east-1</i>:<i>example-account-id</i>:storage-lens/<i>your-dashboard-name</i></code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageLensConfiguration_StorageLensArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag set of the S3 Storage Lens configuration.</para><note><para>You can set up to a maximum of 50 tags.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.S3Control.Model.StorageLensTag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.PutStorageLensConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3CStorageLensConfiguration (PutStorageLensConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.PutStorageLensConfigurationResponse, WriteS3CStorageLensConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigId = this.ConfigId;
            #if MODULAR
            if (this.ConfigId == null && ParameterWasBound(nameof(this.ConfigId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled = this.StorageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled;
            context.StorageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled = this.StorageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled;
            context.StorageMetrics_IsEnabled = this.StorageMetrics_IsEnabled;
            context.SelectionCriteria_Delimiter = this.SelectionCriteria_Delimiter;
            context.SelectionCriteria_MaxDepth = this.SelectionCriteria_MaxDepth;
            context.SelectionCriteria_MinStorageBytesPercentage = this.SelectionCriteria_MinStorageBytesPercentage;
            context.AwsOrg_Arn = this.AwsOrg_Arn;
            context.S3BucketDestination_AccountId = this.S3BucketDestination_AccountId;
            context.S3BucketDestination_Arn = this.S3BucketDestination_Arn;
            context.SSEKMS_KeyId = this.SSEKMS_KeyId;
            context.Encryption_SSES3 = this.Encryption_SSES3;
            context.S3BucketDestination_Format = this.S3BucketDestination_Format;
            context.S3BucketDestination_OutputSchemaVersion = this.S3BucketDestination_OutputSchemaVersion;
            context.S3BucketDestination_Prefix = this.S3BucketDestination_Prefix;
            if (this.Exclude_Bucket != null)
            {
                context.Exclude_Bucket = new List<System.String>(this.Exclude_Bucket);
            }
            if (this.Exclude_Region != null)
            {
                context.Exclude_Region = new List<System.String>(this.Exclude_Region);
            }
            context.StorageLensConfiguration_Id = this.StorageLensConfiguration_Id;
            #if MODULAR
            if (this.StorageLensConfiguration_Id == null && ParameterWasBound(nameof(this.StorageLensConfiguration_Id)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageLensConfiguration_Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Include_Bucket != null)
            {
                context.Include_Bucket = new List<System.String>(this.Include_Bucket);
            }
            if (this.Include_Region != null)
            {
                context.Include_Region = new List<System.String>(this.Include_Region);
            }
            context.StorageLensConfiguration_IsEnabled = this.StorageLensConfiguration_IsEnabled;
            #if MODULAR
            if (this.StorageLensConfiguration_IsEnabled == null && ParameterWasBound(nameof(this.StorageLensConfiguration_IsEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageLensConfiguration_IsEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageLensConfiguration_StorageLensArn = this.StorageLensConfiguration_StorageLensArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.S3Control.Model.StorageLensTag>(this.Tag);
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
            var request = new Amazon.S3Control.Model.PutStorageLensConfigurationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.ConfigId != null)
            {
                request.ConfigId = cmdletContext.ConfigId;
            }
            
             // populate StorageLensConfiguration
            var requestStorageLensConfigurationIsNull = true;
            request.StorageLensConfiguration = new Amazon.S3Control.Model.StorageLensConfiguration();
            System.String requestStorageLensConfiguration_storageLensConfiguration_Id = null;
            if (cmdletContext.StorageLensConfiguration_Id != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Id = cmdletContext.StorageLensConfiguration_Id;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_Id != null)
            {
                request.StorageLensConfiguration.Id = requestStorageLensConfiguration_storageLensConfiguration_Id;
                requestStorageLensConfigurationIsNull = false;
            }
            System.Boolean? requestStorageLensConfiguration_storageLensConfiguration_IsEnabled = null;
            if (cmdletContext.StorageLensConfiguration_IsEnabled != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_IsEnabled = cmdletContext.StorageLensConfiguration_IsEnabled.Value;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_IsEnabled != null)
            {
                request.StorageLensConfiguration.IsEnabled = requestStorageLensConfiguration_storageLensConfiguration_IsEnabled.Value;
                requestStorageLensConfigurationIsNull = false;
            }
            System.String requestStorageLensConfiguration_storageLensConfiguration_StorageLensArn = null;
            if (cmdletContext.StorageLensConfiguration_StorageLensArn != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_StorageLensArn = cmdletContext.StorageLensConfiguration_StorageLensArn;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_StorageLensArn != null)
            {
                request.StorageLensConfiguration.StorageLensArn = requestStorageLensConfiguration_storageLensConfiguration_StorageLensArn;
                requestStorageLensConfigurationIsNull = false;
            }
            Amazon.S3Control.Model.StorageLensAwsOrg requestStorageLensConfiguration_storageLensConfiguration_AwsOrg = null;
            
             // populate AwsOrg
            var requestStorageLensConfiguration_storageLensConfiguration_AwsOrgIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_AwsOrg = new Amazon.S3Control.Model.StorageLensAwsOrg();
            System.String requestStorageLensConfiguration_storageLensConfiguration_AwsOrg_awsOrg_Arn = null;
            if (cmdletContext.AwsOrg_Arn != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AwsOrg_awsOrg_Arn = cmdletContext.AwsOrg_Arn;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AwsOrg_awsOrg_Arn != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AwsOrg.Arn = requestStorageLensConfiguration_storageLensConfiguration_AwsOrg_awsOrg_Arn;
                requestStorageLensConfiguration_storageLensConfiguration_AwsOrgIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_AwsOrg should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_AwsOrgIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AwsOrg = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AwsOrg != null)
            {
                request.StorageLensConfiguration.AwsOrg = requestStorageLensConfiguration_storageLensConfiguration_AwsOrg;
                requestStorageLensConfigurationIsNull = false;
            }
            Amazon.S3Control.Model.StorageLensDataExport requestStorageLensConfiguration_storageLensConfiguration_DataExport = null;
            
             // populate DataExport
            var requestStorageLensConfiguration_storageLensConfiguration_DataExportIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_DataExport = new Amazon.S3Control.Model.StorageLensDataExport();
            Amazon.S3Control.Model.S3BucketDestination requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination = null;
            
             // populate S3BucketDestination
            var requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestinationIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination = new Amazon.S3Control.Model.S3BucketDestination();
            System.String requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_AccountId = null;
            if (cmdletContext.S3BucketDestination_AccountId != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_AccountId = cmdletContext.S3BucketDestination_AccountId;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_AccountId != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination.AccountId = requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_AccountId;
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestinationIsNull = false;
            }
            System.String requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Arn = null;
            if (cmdletContext.S3BucketDestination_Arn != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Arn = cmdletContext.S3BucketDestination_Arn;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Arn != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination.Arn = requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Arn;
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestinationIsNull = false;
            }
            Amazon.S3Control.Format requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Format = null;
            if (cmdletContext.S3BucketDestination_Format != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Format = cmdletContext.S3BucketDestination_Format;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Format != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination.Format = requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Format;
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestinationIsNull = false;
            }
            Amazon.S3Control.OutputSchemaVersion requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_OutputSchemaVersion = null;
            if (cmdletContext.S3BucketDestination_OutputSchemaVersion != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_OutputSchemaVersion = cmdletContext.S3BucketDestination_OutputSchemaVersion;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_OutputSchemaVersion != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination.OutputSchemaVersion = requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_OutputSchemaVersion;
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestinationIsNull = false;
            }
            System.String requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Prefix = null;
            if (cmdletContext.S3BucketDestination_Prefix != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Prefix = cmdletContext.S3BucketDestination_Prefix;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Prefix != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination.Prefix = requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_s3BucketDestination_Prefix;
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestinationIsNull = false;
            }
            Amazon.S3Control.Model.StorageLensDataExportEncryption requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption = null;
            
             // populate Encryption
            var requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_EncryptionIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption = new Amazon.S3Control.Model.StorageLensDataExportEncryption();
            Amazon.S3Control.Model.SSES3 requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_encryption_SSES3 = null;
            if (cmdletContext.Encryption_SSES3 != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_encryption_SSES3 = cmdletContext.Encryption_SSES3;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_encryption_SSES3 != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption.SSES3 = requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_encryption_SSES3;
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_EncryptionIsNull = false;
            }
            Amazon.S3Control.Model.SSEKMS requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS = null;
            
             // populate SSEKMS
            var requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMSIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS = new Amazon.S3Control.Model.SSEKMS();
            System.String requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS_sSEKMS_KeyId = null;
            if (cmdletContext.SSEKMS_KeyId != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS_sSEKMS_KeyId = cmdletContext.SSEKMS_KeyId;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS_sSEKMS_KeyId != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS.KeyId = requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS_sSEKMS_KeyId;
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMSIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMSIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption.SSEKMS = requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_storageLensConfiguration_DataExport_S3BucketDestination_Encryption_SSEKMS;
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_EncryptionIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_EncryptionIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination.Encryption = requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination_storageLensConfiguration_DataExport_S3BucketDestination_Encryption;
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestinationIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestinationIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport.S3BucketDestination = requestStorageLensConfiguration_storageLensConfiguration_DataExport_storageLensConfiguration_DataExport_S3BucketDestination;
                requestStorageLensConfiguration_storageLensConfiguration_DataExportIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_DataExport should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExportIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_DataExport = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_DataExport != null)
            {
                request.StorageLensConfiguration.DataExport = requestStorageLensConfiguration_storageLensConfiguration_DataExport;
                requestStorageLensConfigurationIsNull = false;
            }
            Amazon.S3Control.Model.AccountLevel requestStorageLensConfiguration_storageLensConfiguration_AccountLevel = null;
            
             // populate AccountLevel
            var requestStorageLensConfiguration_storageLensConfiguration_AccountLevelIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_AccountLevel = new Amazon.S3Control.Model.AccountLevel();
            Amazon.S3Control.Model.ActivityMetrics requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics = null;
            
             // populate ActivityMetrics
            var requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetricsIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics = new Amazon.S3Control.Model.ActivityMetrics();
            System.Boolean? requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics_storageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled = null;
            if (cmdletContext.StorageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics_storageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled = cmdletContext.StorageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled.Value;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics_storageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics.IsEnabled = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics_storageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled.Value;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetricsIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetricsIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel.ActivityMetrics = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_ActivityMetrics;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevelIsNull = false;
            }
            Amazon.S3Control.Model.BucketLevel requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel = null;
            
             // populate BucketLevel
            var requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevelIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel = new Amazon.S3Control.Model.BucketLevel();
            Amazon.S3Control.Model.ActivityMetrics requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics = null;
            
             // populate ActivityMetrics
            var requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetricsIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics = new Amazon.S3Control.Model.ActivityMetrics();
            System.Boolean? requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics_storageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled = null;
            if (cmdletContext.StorageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics_storageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled = cmdletContext.StorageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled.Value;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics_storageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics.IsEnabled = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics_storageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled.Value;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetricsIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetricsIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel.ActivityMetrics = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_ActivityMetrics;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevelIsNull = false;
            }
            Amazon.S3Control.Model.PrefixLevel requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel = null;
            
             // populate PrefixLevel
            var requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevelIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel = new Amazon.S3Control.Model.PrefixLevel();
            Amazon.S3Control.Model.PrefixLevelStorageMetrics requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics = null;
            
             // populate StorageMetrics
            var requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetricsIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics = new Amazon.S3Control.Model.PrefixLevelStorageMetrics();
            System.Boolean? requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageMetrics_IsEnabled = null;
            if (cmdletContext.StorageMetrics_IsEnabled != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageMetrics_IsEnabled = cmdletContext.StorageMetrics_IsEnabled.Value;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageMetrics_IsEnabled != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics.IsEnabled = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageMetrics_IsEnabled.Value;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetricsIsNull = false;
            }
            Amazon.S3Control.Model.SelectionCriteria requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria = null;
            
             // populate SelectionCriteria
            var requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteriaIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria = new Amazon.S3Control.Model.SelectionCriteria();
            System.String requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_Delimiter = null;
            if (cmdletContext.SelectionCriteria_Delimiter != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_Delimiter = cmdletContext.SelectionCriteria_Delimiter;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_Delimiter != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria.Delimiter = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_Delimiter;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteriaIsNull = false;
            }
            System.Int32? requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_MaxDepth = null;
            if (cmdletContext.SelectionCriteria_MaxDepth != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_MaxDepth = cmdletContext.SelectionCriteria_MaxDepth.Value;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_MaxDepth != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria.MaxDepth = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_MaxDepth.Value;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteriaIsNull = false;
            }
            System.Double? requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_MinStorageBytesPercentage = null;
            if (cmdletContext.SelectionCriteria_MinStorageBytesPercentage != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_MinStorageBytesPercentage = cmdletContext.SelectionCriteria_MinStorageBytesPercentage.Value;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_MinStorageBytesPercentage != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria.MinStorageBytesPercentage = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria_selectionCriteria_MinStorageBytesPercentage.Value;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteriaIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteriaIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics.SelectionCriteria = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics_SelectionCriteria;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetricsIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetricsIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel.StorageMetrics = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel_StorageMetrics;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevelIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevelIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel.PrefixLevel = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel_storageLensConfiguration_AccountLevel_BucketLevel_PrefixLevel;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevelIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevelIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel.BucketLevel = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel_storageLensConfiguration_AccountLevel_BucketLevel;
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevelIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_AccountLevel should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevelIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_AccountLevel = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_AccountLevel != null)
            {
                request.StorageLensConfiguration.AccountLevel = requestStorageLensConfiguration_storageLensConfiguration_AccountLevel;
                requestStorageLensConfigurationIsNull = false;
            }
            Amazon.S3Control.Model.Exclude requestStorageLensConfiguration_storageLensConfiguration_Exclude = null;
            
             // populate Exclude
            var requestStorageLensConfiguration_storageLensConfiguration_ExcludeIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_Exclude = new Amazon.S3Control.Model.Exclude();
            List<System.String> requestStorageLensConfiguration_storageLensConfiguration_Exclude_exclude_Bucket = null;
            if (cmdletContext.Exclude_Bucket != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Exclude_exclude_Bucket = cmdletContext.Exclude_Bucket;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_Exclude_exclude_Bucket != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Exclude.Buckets = requestStorageLensConfiguration_storageLensConfiguration_Exclude_exclude_Bucket;
                requestStorageLensConfiguration_storageLensConfiguration_ExcludeIsNull = false;
            }
            List<System.String> requestStorageLensConfiguration_storageLensConfiguration_Exclude_exclude_Region = null;
            if (cmdletContext.Exclude_Region != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Exclude_exclude_Region = cmdletContext.Exclude_Region;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_Exclude_exclude_Region != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Exclude.Regions = requestStorageLensConfiguration_storageLensConfiguration_Exclude_exclude_Region;
                requestStorageLensConfiguration_storageLensConfiguration_ExcludeIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_Exclude should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_ExcludeIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Exclude = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_Exclude != null)
            {
                request.StorageLensConfiguration.Exclude = requestStorageLensConfiguration_storageLensConfiguration_Exclude;
                requestStorageLensConfigurationIsNull = false;
            }
            Amazon.S3Control.Model.Include requestStorageLensConfiguration_storageLensConfiguration_Include = null;
            
             // populate Include
            var requestStorageLensConfiguration_storageLensConfiguration_IncludeIsNull = true;
            requestStorageLensConfiguration_storageLensConfiguration_Include = new Amazon.S3Control.Model.Include();
            List<System.String> requestStorageLensConfiguration_storageLensConfiguration_Include_include_Bucket = null;
            if (cmdletContext.Include_Bucket != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Include_include_Bucket = cmdletContext.Include_Bucket;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_Include_include_Bucket != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Include.Buckets = requestStorageLensConfiguration_storageLensConfiguration_Include_include_Bucket;
                requestStorageLensConfiguration_storageLensConfiguration_IncludeIsNull = false;
            }
            List<System.String> requestStorageLensConfiguration_storageLensConfiguration_Include_include_Region = null;
            if (cmdletContext.Include_Region != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Include_include_Region = cmdletContext.Include_Region;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_Include_include_Region != null)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Include.Regions = requestStorageLensConfiguration_storageLensConfiguration_Include_include_Region;
                requestStorageLensConfiguration_storageLensConfiguration_IncludeIsNull = false;
            }
             // determine if requestStorageLensConfiguration_storageLensConfiguration_Include should be set to null
            if (requestStorageLensConfiguration_storageLensConfiguration_IncludeIsNull)
            {
                requestStorageLensConfiguration_storageLensConfiguration_Include = null;
            }
            if (requestStorageLensConfiguration_storageLensConfiguration_Include != null)
            {
                request.StorageLensConfiguration.Include = requestStorageLensConfiguration_storageLensConfiguration_Include;
                requestStorageLensConfigurationIsNull = false;
            }
             // determine if request.StorageLensConfiguration should be set to null
            if (requestStorageLensConfigurationIsNull)
            {
                request.StorageLensConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.S3Control.Model.PutStorageLensConfigurationResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.PutStorageLensConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "PutStorageLensConfiguration");
            try
            {
                #if DESKTOP
                return client.PutStorageLensConfiguration(request);
                #elif CORECLR
                return client.PutStorageLensConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigId { get; set; }
            public System.Boolean? StorageLensConfiguration_AccountLevel_ActivityMetrics_IsEnabled { get; set; }
            public System.Boolean? StorageLensConfiguration_BucketLevel_ActivityMetrics_IsEnabled { get; set; }
            public System.Boolean? StorageMetrics_IsEnabled { get; set; }
            public System.String SelectionCriteria_Delimiter { get; set; }
            public System.Int32? SelectionCriteria_MaxDepth { get; set; }
            public System.Double? SelectionCriteria_MinStorageBytesPercentage { get; set; }
            public System.String AwsOrg_Arn { get; set; }
            public System.String S3BucketDestination_AccountId { get; set; }
            public System.String S3BucketDestination_Arn { get; set; }
            public System.String SSEKMS_KeyId { get; set; }
            public Amazon.S3Control.Model.SSES3 Encryption_SSES3 { get; set; }
            public Amazon.S3Control.Format S3BucketDestination_Format { get; set; }
            public Amazon.S3Control.OutputSchemaVersion S3BucketDestination_OutputSchemaVersion { get; set; }
            public System.String S3BucketDestination_Prefix { get; set; }
            public List<System.String> Exclude_Bucket { get; set; }
            public List<System.String> Exclude_Region { get; set; }
            public System.String StorageLensConfiguration_Id { get; set; }
            public List<System.String> Include_Bucket { get; set; }
            public List<System.String> Include_Region { get; set; }
            public System.Boolean? StorageLensConfiguration_IsEnabled { get; set; }
            public System.String StorageLensConfiguration_StorageLensArn { get; set; }
            public List<Amazon.S3Control.Model.StorageLensTag> Tag { get; set; }
            public System.Func<Amazon.S3Control.Model.PutStorageLensConfigurationResponse, WriteS3CStorageLensConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
