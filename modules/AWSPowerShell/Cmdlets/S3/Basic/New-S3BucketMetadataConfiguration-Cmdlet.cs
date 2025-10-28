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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Creates an S3 Metadata V2 metadata configuration for a general purpose bucket. For
    /// more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-overview.html">Accelerating
    /// data discovery with S3 Metadata</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// To use this operation, you must have the following permissions. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-permissions.html">Setting
    /// up permissions for configuring metadata tables</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// If you want to encrypt your metadata tables with server-side encryption with Key Management
    /// Service (KMS) keys (SSE-KMS), you need additional permissions in your KMS key policy.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-permissions.html">
    /// Setting up permissions for configuring metadata tables</a> in the <i>Amazon S3 User
    /// Guide</i>.
    /// </para><para>
    /// If you also want to integrate your table bucket with Amazon Web Services analytics
    /// services so that you can query your metadata table, you need additional permissions.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-integrating-aws.html">
    /// Integrating Amazon S3 Tables with Amazon Web Services analytics services</a> in the
    /// <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// To query your metadata tables, you need additional permissions. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-bucket-query-permissions.html">
    /// Permissions for querying metadata tables</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><ul><li><para><c>s3:CreateBucketMetadataTableConfiguration</c></para><note><para>
    /// The IAM policy action name is the same for the V1 and V2 API operations.
    /// </para></note></li><li><para><c>s3tables:CreateTableBucket</c></para></li><li><para><c>s3tables:CreateNamespace</c></para></li><li><para><c>s3tables:GetTable</c></para></li><li><para><c>s3tables:CreateTable</c></para></li><li><para><c>s3tables:PutTablePolicy</c></para></li><li><para><c>s3tables:PutTableEncryption</c></para></li><li><para><c>kms:DescribeKey</c></para></li></ul></dd></dl><para>
    /// The following operations are related to <c>CreateBucketMetadataConfiguration</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketMetadataConfiguration.html">DeleteBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketMetadataConfiguration.html">GetBucketMetadataConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_UpdateBucketMetadataInventoryTableConfiguration.html">UpdateBucketMetadataInventoryTableConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_UpdateBucketMetadataJournalTableConfiguration.html">UpdateBucketMetadataJournalTableConfiguration</a></para></li></ul><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "S3BucketMetadataConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) CreateBucketMetadataConfiguration API operation.", Operation = new[] {"CreateBucketMetadataConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.CreateBucketMetadataConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.CreateBucketMetadataConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.CreateBucketMetadataConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewS3BucketMetadataConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter InventoryTableConfiguration_ConfigurationState
        /// <summary>
        /// <para>
        /// <para> The configuration state of the inventory table, indicating whether the inventory table is enabled or disabled. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataConfiguration_InventoryTableConfiguration_ConfigurationState")]
        [AWSConstantClassSource("Amazon.S3.InventoryConfigurationState")]
        public Amazon.S3.InventoryConfigurationState InventoryTableConfiguration_ConfigurationState { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter RecordExpiration_Day
        /// <summary>
        /// <para>
        /// <para> If you enable journal table record expiration, you can set the number of days to
        /// retain your journal table records. Journal table records must be retained for a minimum
        /// of 7 days. To set this value, specify any whole number from <c>7</c> to <c>2147483647</c>.
        /// For example, to retain your journal table records for one year, set this value to
        /// <c>365</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataConfiguration_JournalTableConfiguration_RecordExpiration_Days")]
        public System.Int32? RecordExpiration_Day { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter RecordExpiration_Expiration
        /// <summary>
        /// <para>
        /// <para> Specifies whether journal table record expiration is enabled or disabled. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataConfiguration_JournalTableConfiguration_RecordExpiration_Expiration")]
        [AWSConstantClassSource("Amazon.S3.ExpirationState")]
        public Amazon.S3.ExpirationState RecordExpiration_Expiration { get; set; }
        #endregion
        
        #region Parameter MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.TableSseAlgorithm")]
        public Amazon.S3.TableSseAlgorithm MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm { get; set; }
        #endregion
        
        #region Parameter MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.TableSseAlgorithm")]
        public Amazon.S3.TableSseAlgorithm MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.CreateBucketMetadataConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3BucketMetadataConfiguration (CreateBucketMetadataConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.CreateBucketMetadataConfigurationResponse, NewS3BucketMetadataConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ContentMD5 = this.ContentMD5;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.InventoryTableConfiguration_ConfigurationState = this.InventoryTableConfiguration_ConfigurationState;
            context.MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn = this.MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn;
            context.MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm = this.MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm;
            context.MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn = this.MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn;
            context.MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm = this.MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm;
            context.RecordExpiration_Day = this.RecordExpiration_Day;
            context.RecordExpiration_Expiration = this.RecordExpiration_Expiration;
            
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
            var request = new Amazon.S3.Model.CreateBucketMetadataConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            
             // populate MetadataConfiguration
            var requestMetadataConfigurationIsNull = true;
            request.MetadataConfiguration = new Amazon.S3.Model.MetadataConfiguration();
            Amazon.S3.Model.InventoryTableConfiguration requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration = null;
            
             // populate InventoryTableConfiguration
            var requestMetadataConfiguration_metadataConfiguration_InventoryTableConfigurationIsNull = true;
            requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration = new Amazon.S3.Model.InventoryTableConfiguration();
            Amazon.S3.InventoryConfigurationState requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_inventoryTableConfiguration_ConfigurationState = null;
            if (cmdletContext.InventoryTableConfiguration_ConfigurationState != null)
            {
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_inventoryTableConfiguration_ConfigurationState = cmdletContext.InventoryTableConfiguration_ConfigurationState;
            }
            if (requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_inventoryTableConfiguration_ConfigurationState != null)
            {
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration.ConfigurationState = requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_inventoryTableConfiguration_ConfigurationState;
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfigurationIsNull = false;
            }
            Amazon.S3.Model.MetadataTableEncryptionConfiguration requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfigurationIsNull = true;
            requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration = new Amazon.S3.Model.MetadataTableEncryptionConfiguration();
            System.String requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn != null)
            {
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn = cmdletContext.MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn;
            }
            if (requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn != null)
            {
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration.KmsKeyArn = requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn;
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfigurationIsNull = false;
            }
            Amazon.S3.TableSseAlgorithm requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm = null;
            if (cmdletContext.MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm != null)
            {
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm = cmdletContext.MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm;
            }
            if (requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm != null)
            {
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration.SseAlgorithm = requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm;
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfigurationIsNull = false;
            }
             // determine if requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration should be set to null
            if (requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfigurationIsNull)
            {
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration = null;
            }
            if (requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration != null)
            {
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration.EncryptionConfiguration = requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration_metadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration;
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfigurationIsNull = false;
            }
             // determine if requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration should be set to null
            if (requestMetadataConfiguration_metadataConfiguration_InventoryTableConfigurationIsNull)
            {
                requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration = null;
            }
            if (requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration != null)
            {
                request.MetadataConfiguration.InventoryTableConfiguration = requestMetadataConfiguration_metadataConfiguration_InventoryTableConfiguration;
                requestMetadataConfigurationIsNull = false;
            }
            Amazon.S3.Model.JournalTableConfiguration requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration = null;
            
             // populate JournalTableConfiguration
            var requestMetadataConfiguration_metadataConfiguration_JournalTableConfigurationIsNull = true;
            requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration = new Amazon.S3.Model.JournalTableConfiguration();
            Amazon.S3.Model.MetadataTableEncryptionConfiguration requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfigurationIsNull = true;
            requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration = new Amazon.S3.Model.MetadataTableEncryptionConfiguration();
            System.String requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn != null)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn = cmdletContext.MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn;
            }
            if (requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn != null)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration.KmsKeyArn = requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn;
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfigurationIsNull = false;
            }
            Amazon.S3.TableSseAlgorithm requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm = null;
            if (cmdletContext.MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm != null)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm = cmdletContext.MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm;
            }
            if (requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm != null)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration.SseAlgorithm = requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm;
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfigurationIsNull = false;
            }
             // determine if requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration should be set to null
            if (requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfigurationIsNull)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration = null;
            }
            if (requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration != null)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration.EncryptionConfiguration = requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_EncryptionConfiguration;
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfigurationIsNull = false;
            }
            Amazon.S3.Model.RecordExpiration requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration = null;
            
             // populate RecordExpiration
            var requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpirationIsNull = true;
            requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration = new Amazon.S3.Model.RecordExpiration();
            System.Int32? requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration_recordExpiration_Day = null;
            if (cmdletContext.RecordExpiration_Day != null)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration_recordExpiration_Day = cmdletContext.RecordExpiration_Day.Value;
            }
            if (requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration_recordExpiration_Day != null)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration.Days = requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration_recordExpiration_Day.Value;
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpirationIsNull = false;
            }
            Amazon.S3.ExpirationState requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration_recordExpiration_Expiration = null;
            if (cmdletContext.RecordExpiration_Expiration != null)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration_recordExpiration_Expiration = cmdletContext.RecordExpiration_Expiration;
            }
            if (requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration_recordExpiration_Expiration != null)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration.Expiration = requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration_recordExpiration_Expiration;
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpirationIsNull = false;
            }
             // determine if requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration should be set to null
            if (requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpirationIsNull)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration = null;
            }
            if (requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration != null)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration.RecordExpiration = requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration_metadataConfiguration_JournalTableConfiguration_RecordExpiration;
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfigurationIsNull = false;
            }
             // determine if requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration should be set to null
            if (requestMetadataConfiguration_metadataConfiguration_JournalTableConfigurationIsNull)
            {
                requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration = null;
            }
            if (requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration != null)
            {
                request.MetadataConfiguration.JournalTableConfiguration = requestMetadataConfiguration_metadataConfiguration_JournalTableConfiguration;
                requestMetadataConfigurationIsNull = false;
            }
             // determine if request.MetadataConfiguration should be set to null
            if (requestMetadataConfigurationIsNull)
            {
                request.MetadataConfiguration = null;
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
        
        private Amazon.S3.Model.CreateBucketMetadataConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.CreateBucketMetadataConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "CreateBucketMetadataConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateBucketMetadataConfiguration(request);
                #elif CORECLR
                return client.CreateBucketMetadataConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String ContentMD5 { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public Amazon.S3.InventoryConfigurationState InventoryTableConfiguration_ConfigurationState { get; set; }
            public System.String MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.S3.TableSseAlgorithm MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm { get; set; }
            public System.String MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.S3.TableSseAlgorithm MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm { get; set; }
            public System.Int32? RecordExpiration_Day { get; set; }
            public Amazon.S3.ExpirationState RecordExpiration_Expiration { get; set; }
            public System.Func<Amazon.S3.Model.CreateBucketMetadataConfigurationResponse, NewS3BucketMetadataConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
