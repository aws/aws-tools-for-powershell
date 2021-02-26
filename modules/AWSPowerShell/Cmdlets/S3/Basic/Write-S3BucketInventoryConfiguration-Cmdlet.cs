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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Amazon.S3.IAmazonS3.PutBucketInventoryConfiguration
    /// </summary>
    [Cmdlet("Write", "S3BucketInventoryConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketInventoryConfiguration API operation.", Operation = new[] {"PutBucketInventoryConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketInventoryConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketInventoryConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketInventoryConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3BucketInventoryConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter S3BucketDestination_AccountId
        /// <summary>
        /// <para>
        /// The ID of the account that owns the destination bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryConfiguration_Destination_S3BucketDestination_AccountId")]
        public System.String S3BucketDestination_AccountId { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket where the inventory configuration will be stored.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_BucketName
        /// <summary>
        /// <para>
        /// The Amazon resource name (ARN) of the bucket where inventory results will be published.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryConfiguration_Destination_S3BucketDestination_BucketName")]
        public System.String S3BucketDestination_BucketName { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// The account ID of the expected bucket owner. 
        /// If the bucket is owned by a different account, the request will fail with an HTTP 403 (Access Denied) error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Schedule_Frequency
        /// <summary>
        /// <para>
        /// Specifies how frequently inventory results are produced.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryConfiguration_Schedule_Frequency")]
        [AWSConstantClassSource("Amazon.S3.InventoryFrequency")]
        public Amazon.S3.InventoryFrequency Schedule_Frequency { get; set; }
        #endregion
        
        #region Parameter InventoryConfiguration_IncludedObjectVersion
        /// <summary>
        /// <para>
        /// Specifies which object version(s) to included in the inventory results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryConfiguration_IncludedObjectVersions")]
        [AWSConstantClassSource("Amazon.S3.InventoryIncludedObjectVersions")]
        public Amazon.S3.InventoryIncludedObjectVersions InventoryConfiguration_IncludedObjectVersion { get; set; }
        #endregion
        
        #region Parameter InventoryFilter_InventoryFilterPredicate
        /// <summary>
        /// <para>
        /// Filter Predicate setup for specific filter types.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryConfiguration_InventoryFilter_InventoryFilterPredicate")]
        public Amazon.S3.Model.InventoryFilterPredicate InventoryFilter_InventoryFilterPredicate { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_InventoryFormat
        /// <summary>
        /// <para>
        /// Specifies the output format of the inventory results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryConfiguration_Destination_S3BucketDestination_InventoryFormat")]
        [AWSConstantClassSource("Amazon.S3.InventoryFormat")]
        public Amazon.S3.InventoryFormat S3BucketDestination_InventoryFormat { get; set; }
        #endregion
        
        #region Parameter InventoryId
        /// <summary>
        /// <para>
        /// Specifies the inventory Id.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InventoryId { get; set; }
        #endregion
        
        #region Parameter InventoryConfiguration_InventoryId
        /// <summary>
        /// <para>
        /// The ID used to identify the inventory configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InventoryConfiguration_InventoryId { get; set; }
        #endregion
        
        #region Parameter InventoryConfiguration_InventoryOptionalField
        /// <summary>
        /// <para>
        /// Contains the optional fields that are included in the inventory results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryConfiguration_InventoryOptionalFields")]
        public Amazon.S3.InventoryOptionalField[] InventoryConfiguration_InventoryOptionalField { get; set; }
        #endregion
        
        #region Parameter InventoryConfiguration_IsEnabled
        /// <summary>
        /// <para>
        /// Specifies whether the inventory is enabled or disabled.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InventoryConfiguration_IsEnabled { get; set; }
        #endregion
        
        #region Parameter SSEKMS_KeyId
        /// <summary>
        /// <para>
        /// Specifies the ID of the AWS Key Management Service (KMS) 
        /// master encryption key to use for encrypting Inventory reports.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS_KeyId")]
        public System.String SSEKMS_KeyId { get; set; }
        #endregion
        
        #region Parameter S3BucketDestination_Prefix
        /// <summary>
        /// <para>
        /// The prefix that is prepended to all inventory results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryConfiguration_Destination_S3BucketDestination_Prefix")]
        public System.String S3BucketDestination_Prefix { get; set; }
        #endregion
        
        #region Parameter InventoryEncryption_SSES3
        /// <summary>
        /// <para>
        /// Specifies the use of SSE-S3 to encrypt delievered Inventory reports.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSES3")]
        public Amazon.S3.Model.SSES3 InventoryEncryption_SSES3 { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketInventoryConfigurationResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketInventoryConfiguration (PutBucketInventoryConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketInventoryConfigurationResponse, WriteS3BucketInventoryConfigurationCmdlet>(Select) ??
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
            context.InventoryId = this.InventoryId;
            context.S3BucketDestination_AccountId = this.S3BucketDestination_AccountId;
            context.S3BucketDestination_BucketName = this.S3BucketDestination_BucketName;
            context.S3BucketDestination_Prefix = this.S3BucketDestination_Prefix;
            context.S3BucketDestination_InventoryFormat = this.S3BucketDestination_InventoryFormat;
            context.InventoryEncryption_SSES3 = this.InventoryEncryption_SSES3;
            context.SSEKMS_KeyId = this.SSEKMS_KeyId;
            context.InventoryConfiguration_IsEnabled = this.InventoryConfiguration_IsEnabled;
            context.InventoryFilter_InventoryFilterPredicate = this.InventoryFilter_InventoryFilterPredicate;
            context.InventoryConfiguration_InventoryId = this.InventoryConfiguration_InventoryId;
            context.InventoryConfiguration_IncludedObjectVersion = this.InventoryConfiguration_IncludedObjectVersion;
            if (this.InventoryConfiguration_InventoryOptionalField != null)
            {
                context.InventoryConfiguration_InventoryOptionalField = new List<Amazon.S3.InventoryOptionalField>(this.InventoryConfiguration_InventoryOptionalField);
            }
            context.Schedule_Frequency = this.Schedule_Frequency;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            
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
            var request = new Amazon.S3.Model.PutBucketInventoryConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.InventoryId != null)
            {
                request.InventoryId = cmdletContext.InventoryId;
            }
            
             // populate InventoryConfiguration
            var requestInventoryConfigurationIsNull = true;
            request.InventoryConfiguration = new Amazon.S3.Model.InventoryConfiguration();
            System.Boolean? requestInventoryConfiguration_inventoryConfiguration_IsEnabled = null;
            if (cmdletContext.InventoryConfiguration_IsEnabled != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_IsEnabled = cmdletContext.InventoryConfiguration_IsEnabled.Value;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_IsEnabled != null)
            {
                request.InventoryConfiguration.IsEnabled = requestInventoryConfiguration_inventoryConfiguration_IsEnabled.Value;
                requestInventoryConfigurationIsNull = false;
            }
            System.String requestInventoryConfiguration_inventoryConfiguration_InventoryId = null;
            if (cmdletContext.InventoryConfiguration_InventoryId != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_InventoryId = cmdletContext.InventoryConfiguration_InventoryId;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_InventoryId != null)
            {
                request.InventoryConfiguration.InventoryId = requestInventoryConfiguration_inventoryConfiguration_InventoryId;
                requestInventoryConfigurationIsNull = false;
            }
            Amazon.S3.InventoryIncludedObjectVersions requestInventoryConfiguration_inventoryConfiguration_IncludedObjectVersion = null;
            if (cmdletContext.InventoryConfiguration_IncludedObjectVersion != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_IncludedObjectVersion = cmdletContext.InventoryConfiguration_IncludedObjectVersion;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_IncludedObjectVersion != null)
            {
                request.InventoryConfiguration.IncludedObjectVersions = requestInventoryConfiguration_inventoryConfiguration_IncludedObjectVersion;
                requestInventoryConfigurationIsNull = false;
            }
            List<Amazon.S3.InventoryOptionalField> requestInventoryConfiguration_inventoryConfiguration_InventoryOptionalField = null;
            if (cmdletContext.InventoryConfiguration_InventoryOptionalField != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_InventoryOptionalField = cmdletContext.InventoryConfiguration_InventoryOptionalField;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_InventoryOptionalField != null)
            {
                request.InventoryConfiguration.InventoryOptionalFields = requestInventoryConfiguration_inventoryConfiguration_InventoryOptionalField;
                requestInventoryConfigurationIsNull = false;
            }
            Amazon.S3.Model.InventoryDestination requestInventoryConfiguration_inventoryConfiguration_Destination = null;
            
             // populate Destination
            var requestInventoryConfiguration_inventoryConfiguration_DestinationIsNull = true;
            requestInventoryConfiguration_inventoryConfiguration_Destination = new Amazon.S3.Model.InventoryDestination();
            Amazon.S3.Model.InventoryS3BucketDestination requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination = null;
            
             // populate S3BucketDestination
            var requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = true;
            requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination = new Amazon.S3.Model.InventoryS3BucketDestination();
            System.String requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_AccountId = null;
            if (cmdletContext.S3BucketDestination_AccountId != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_AccountId = cmdletContext.S3BucketDestination_AccountId;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_AccountId != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination.AccountId = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_AccountId;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = false;
            }
            System.String requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_BucketName = null;
            if (cmdletContext.S3BucketDestination_BucketName != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_BucketName = cmdletContext.S3BucketDestination_BucketName;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_BucketName != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination.BucketName = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_BucketName;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = false;
            }
            System.String requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_Prefix = null;
            if (cmdletContext.S3BucketDestination_Prefix != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_Prefix = cmdletContext.S3BucketDestination_Prefix;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_Prefix != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination.Prefix = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_Prefix;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = false;
            }
            Amazon.S3.InventoryFormat requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_InventoryFormat = null;
            if (cmdletContext.S3BucketDestination_InventoryFormat != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_InventoryFormat = cmdletContext.S3BucketDestination_InventoryFormat;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_InventoryFormat != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination.InventoryFormat = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_s3BucketDestination_InventoryFormat;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = false;
            }
            Amazon.S3.Model.InventoryEncryption requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption = null;
            
             // populate InventoryEncryption
            var requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryptionIsNull = true;
            requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption = new Amazon.S3.Model.InventoryEncryption();
            Amazon.S3.Model.SSES3 requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryEncryption_SSES3 = null;
            if (cmdletContext.InventoryEncryption_SSES3 != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryEncryption_SSES3 = cmdletContext.InventoryEncryption_SSES3;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryEncryption_SSES3 != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption.SSES3 = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryEncryption_SSES3;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryptionIsNull = false;
            }
            Amazon.S3.Model.SSEKMS requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS = null;
            
             // populate SSEKMS
            var requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMSIsNull = true;
            requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS = new Amazon.S3.Model.SSEKMS();
            System.String requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS_sSEKMS_KeyId = null;
            if (cmdletContext.SSEKMS_KeyId != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS_sSEKMS_KeyId = cmdletContext.SSEKMS_KeyId;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS_sSEKMS_KeyId != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS.KeyId = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS_sSEKMS_KeyId;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMSIsNull = false;
            }
             // determine if requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS should be set to null
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMSIsNull)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS = null;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption.SSEKMS = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption_SSEKMS;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryptionIsNull = false;
            }
             // determine if requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption should be set to null
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryptionIsNull)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption = null;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination.InventoryEncryption = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination_inventoryConfiguration_Destination_S3BucketDestination_InventoryEncryption;
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull = false;
            }
             // determine if requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination should be set to null
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestinationIsNull)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination = null;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination.S3BucketDestination = requestInventoryConfiguration_inventoryConfiguration_Destination_inventoryConfiguration_Destination_S3BucketDestination;
                requestInventoryConfiguration_inventoryConfiguration_DestinationIsNull = false;
            }
             // determine if requestInventoryConfiguration_inventoryConfiguration_Destination should be set to null
            if (requestInventoryConfiguration_inventoryConfiguration_DestinationIsNull)
            {
                requestInventoryConfiguration_inventoryConfiguration_Destination = null;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Destination != null)
            {
                request.InventoryConfiguration.Destination = requestInventoryConfiguration_inventoryConfiguration_Destination;
                requestInventoryConfigurationIsNull = false;
            }
            Amazon.S3.Model.InventoryFilter requestInventoryConfiguration_inventoryConfiguration_InventoryFilter = null;
            
             // populate InventoryFilter
            var requestInventoryConfiguration_inventoryConfiguration_InventoryFilterIsNull = true;
            requestInventoryConfiguration_inventoryConfiguration_InventoryFilter = new Amazon.S3.Model.InventoryFilter();
            Amazon.S3.Model.InventoryFilterPredicate requestInventoryConfiguration_inventoryConfiguration_InventoryFilter_inventoryFilter_InventoryFilterPredicate = null;
            if (cmdletContext.InventoryFilter_InventoryFilterPredicate != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_InventoryFilter_inventoryFilter_InventoryFilterPredicate = cmdletContext.InventoryFilter_InventoryFilterPredicate;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_InventoryFilter_inventoryFilter_InventoryFilterPredicate != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_InventoryFilter.InventoryFilterPredicate = requestInventoryConfiguration_inventoryConfiguration_InventoryFilter_inventoryFilter_InventoryFilterPredicate;
                requestInventoryConfiguration_inventoryConfiguration_InventoryFilterIsNull = false;
            }
             // determine if requestInventoryConfiguration_inventoryConfiguration_InventoryFilter should be set to null
            if (requestInventoryConfiguration_inventoryConfiguration_InventoryFilterIsNull)
            {
                requestInventoryConfiguration_inventoryConfiguration_InventoryFilter = null;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_InventoryFilter != null)
            {
                request.InventoryConfiguration.InventoryFilter = requestInventoryConfiguration_inventoryConfiguration_InventoryFilter;
                requestInventoryConfigurationIsNull = false;
            }
            Amazon.S3.Model.InventorySchedule requestInventoryConfiguration_inventoryConfiguration_Schedule = null;
            
             // populate Schedule
            var requestInventoryConfiguration_inventoryConfiguration_ScheduleIsNull = true;
            requestInventoryConfiguration_inventoryConfiguration_Schedule = new Amazon.S3.Model.InventorySchedule();
            Amazon.S3.InventoryFrequency requestInventoryConfiguration_inventoryConfiguration_Schedule_schedule_Frequency = null;
            if (cmdletContext.Schedule_Frequency != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Schedule_schedule_Frequency = cmdletContext.Schedule_Frequency;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Schedule_schedule_Frequency != null)
            {
                requestInventoryConfiguration_inventoryConfiguration_Schedule.Frequency = requestInventoryConfiguration_inventoryConfiguration_Schedule_schedule_Frequency;
                requestInventoryConfiguration_inventoryConfiguration_ScheduleIsNull = false;
            }
             // determine if requestInventoryConfiguration_inventoryConfiguration_Schedule should be set to null
            if (requestInventoryConfiguration_inventoryConfiguration_ScheduleIsNull)
            {
                requestInventoryConfiguration_inventoryConfiguration_Schedule = null;
            }
            if (requestInventoryConfiguration_inventoryConfiguration_Schedule != null)
            {
                request.InventoryConfiguration.Schedule = requestInventoryConfiguration_inventoryConfiguration_Schedule;
                requestInventoryConfigurationIsNull = false;
            }
             // determine if request.InventoryConfiguration should be set to null
            if (requestInventoryConfigurationIsNull)
            {
                request.InventoryConfiguration = null;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
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
        
        private Amazon.S3.Model.PutBucketInventoryConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketInventoryConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketInventoryConfiguration");
            try
            {
                #if DESKTOP
                return client.PutBucketInventoryConfiguration(request);
                #elif CORECLR
                return client.PutBucketInventoryConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String InventoryId { get; set; }
            public System.String S3BucketDestination_AccountId { get; set; }
            public System.String S3BucketDestination_BucketName { get; set; }
            public System.String S3BucketDestination_Prefix { get; set; }
            public Amazon.S3.InventoryFormat S3BucketDestination_InventoryFormat { get; set; }
            public Amazon.S3.Model.SSES3 InventoryEncryption_SSES3 { get; set; }
            public System.String SSEKMS_KeyId { get; set; }
            public System.Boolean? InventoryConfiguration_IsEnabled { get; set; }
            public Amazon.S3.Model.InventoryFilterPredicate InventoryFilter_InventoryFilterPredicate { get; set; }
            public System.String InventoryConfiguration_InventoryId { get; set; }
            public Amazon.S3.InventoryIncludedObjectVersions InventoryConfiguration_IncludedObjectVersion { get; set; }
            public List<Amazon.S3.InventoryOptionalField> InventoryConfiguration_InventoryOptionalField { get; set; }
            public Amazon.S3.InventoryFrequency Schedule_Frequency { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketInventoryConfigurationResponse, WriteS3BucketInventoryConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
