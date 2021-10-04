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
using Amazon.DataExchange;
using Amazon.DataExchange.Model;

namespace Amazon.PowerShell.Cmdlets.DTEX
{
    /// <summary>
    /// This operation creates a job.
    /// </summary>
    [Cmdlet("New", "DTEXJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataExchange.Model.CreateJobResponse")]
    [AWSCmdlet("Calls the AWS Data Exchange CreateJob API operation.", Operation = new[] {"CreateJob"}, SelectReturnType = typeof(Amazon.DataExchange.Model.CreateJobResponse))]
    [AWSCmdletOutput("Amazon.DataExchange.Model.CreateJobResponse",
        "This cmdlet returns an Amazon.DataExchange.Model.CreateJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDTEXJobCmdlet : AmazonDataExchangeClientCmdlet, IExecutor
    {
        
        #region Parameter ExportAssetsToS3_AssetDestination
        /// <summary>
        /// <para>
        /// <para>The destination for the asset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ExportAssetsToS3_AssetDestinations")]
        public Amazon.DataExchange.Model.AssetDestinationEntry[] ExportAssetsToS3_AssetDestination { get; set; }
        #endregion
        
        #region Parameter ExportAssetToSignedUrl_AssetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the asset that is exported to a signed URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ExportAssetToSignedUrl_AssetId")]
        public System.String ExportAssetToSignedUrl_AssetId { get; set; }
        #endregion
        
        #region Parameter ImportAssetFromSignedUrl_AssetName
        /// <summary>
        /// <para>
        /// <para>The name of the asset. When importing from Amazon S3, the S3 object key is used as
        /// the asset name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromSignedUrl_AssetName")]
        public System.String ImportAssetFromSignedUrl_AssetName { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromRedshiftDataShares_AssetSource
        /// <summary>
        /// <para>
        /// A list of Amazon Redshift datashare assets.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromRedshiftDataShares_AssetSources")]
        public Amazon.DataExchange.Model.RedshiftDataShareAssetSourceEntry[] ImportAssetsFromRedshiftDataShares_AssetSource { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromS3_AssetSource
        /// <summary>
        /// <para>
        /// <para>Is a list of S3 bucket and object key pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromS3_AssetSources")]
        public Amazon.DataExchange.Model.AssetSourceEntry[] ImportAssetsFromS3_AssetSource { get; set; }
        #endregion
        
        #region Parameter ExportAssetsToS3_DataSetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the data set associated with this export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ExportAssetsToS3_DataSetId")]
        public System.String ExportAssetsToS3_DataSetId { get; set; }
        #endregion
        
        #region Parameter ExportAssetToSignedUrl_DataSetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the data set associated with this export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ExportAssetToSignedUrl_DataSetId")]
        public System.String ExportAssetToSignedUrl_DataSetId { get; set; }
        #endregion
        
        #region Parameter ExportRevisionsToS3_DataSetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the data set associated with this export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ExportRevisionsToS3_DataSetId")]
        public System.String ExportRevisionsToS3_DataSetId { get; set; }
        #endregion
        
        #region Parameter ImportAssetFromSignedUrl_DataSetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the data set associated with this import job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromSignedUrl_DataSetId")]
        public System.String ImportAssetFromSignedUrl_DataSetId { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromRedshiftDataShares_DataSetId
        /// <summary>
        /// <para>
        /// The unique identifier for the data set associated
        /// with this import job.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromRedshiftDataShares_DataSetId")]
        public System.String ImportAssetsFromRedshiftDataShares_DataSetId { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromS3_DataSetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the data set associated with this import job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromS3_DataSetId")]
        public System.String ImportAssetsFromS3_DataSetId { get; set; }
        #endregion
        
        #region Parameter Encryption_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS KMS key you want to use to encrypt the Amazon
        /// S3 objects. This parameter is required if you choose aws:kms as an encryption type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ExportAssetsToS3_Encryption_KmsKeyArn")]
        public System.String Encryption_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Details_ExportRevisionsToS3_Encryption_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS KMS key you want to use to encrypt the Amazon
        /// S3 objects. This parameter is required if you choose aws:kms as an encryption type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Details_ExportRevisionsToS3_Encryption_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ImportAssetFromSignedUrl_Md5Hash
        /// <summary>
        /// <para>
        /// <para>The Base64-encoded Md5 hash for the asset, used to ensure the integrity of the file
        /// at that location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromSignedUrl_Md5Hash")]
        public System.String ImportAssetFromSignedUrl_Md5Hash { get; set; }
        #endregion
        
        #region Parameter ExportRevisionsToS3_RevisionDestination
        /// <summary>
        /// <para>
        /// <para>The destination for the revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ExportRevisionsToS3_RevisionDestinations")]
        public Amazon.DataExchange.Model.RevisionDestinationEntry[] ExportRevisionsToS3_RevisionDestination { get; set; }
        #endregion
        
        #region Parameter ExportAssetsToS3_RevisionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the revision associated with this export request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ExportAssetsToS3_RevisionId")]
        public System.String ExportAssetsToS3_RevisionId { get; set; }
        #endregion
        
        #region Parameter ExportAssetToSignedUrl_RevisionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the revision associated with this export request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ExportAssetToSignedUrl_RevisionId")]
        public System.String ExportAssetToSignedUrl_RevisionId { get; set; }
        #endregion
        
        #region Parameter ImportAssetFromSignedUrl_RevisionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the revision associated with this import request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromSignedUrl_RevisionId")]
        public System.String ImportAssetFromSignedUrl_RevisionId { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromRedshiftDataShares_RevisionId
        /// <summary>
        /// <para>
        /// The unique identifier for the revision associated
        /// with this import job.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromRedshiftDataShares_RevisionId")]
        public System.String ImportAssetsFromRedshiftDataShares_RevisionId { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromS3_RevisionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the revision associated with this import request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromS3_RevisionId")]
        public System.String ImportAssetsFromS3_RevisionId { get; set; }
        #endregion
        
        #region Parameter Encryption_Type
        /// <summary>
        /// <para>
        /// <para>The type of server side encryption used for encrypting the objects in Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ExportAssetsToS3_Encryption_Type")]
        [AWSConstantClassSource("Amazon.DataExchange.ServerSideEncryptionTypes")]
        public Amazon.DataExchange.ServerSideEncryptionTypes Encryption_Type { get; set; }
        #endregion
        
        #region Parameter Details_ExportRevisionsToS3_Encryption_Type
        /// <summary>
        /// <para>
        /// <para>The type of server side encryption used for encrypting the objects in Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataExchange.ServerSideEncryptionTypes")]
        public Amazon.DataExchange.ServerSideEncryptionTypes Details_ExportRevisionsToS3_Encryption_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of job to be created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataExchange.Type")]
        public Amazon.DataExchange.Type Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataExchange.Model.CreateJobResponse).
        /// Specifying the name of a property of type Amazon.DataExchange.Model.CreateJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Type parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Type' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Type' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DTEXJob (CreateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataExchange.Model.CreateJobResponse, NewDTEXJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Type;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ExportAssetsToS3_AssetDestination != null)
            {
                context.ExportAssetsToS3_AssetDestination = new List<Amazon.DataExchange.Model.AssetDestinationEntry>(this.ExportAssetsToS3_AssetDestination);
            }
            context.ExportAssetsToS3_DataSetId = this.ExportAssetsToS3_DataSetId;
            context.Encryption_KmsKeyArn = this.Encryption_KmsKeyArn;
            context.Encryption_Type = this.Encryption_Type;
            context.ExportAssetsToS3_RevisionId = this.ExportAssetsToS3_RevisionId;
            context.ExportAssetToSignedUrl_AssetId = this.ExportAssetToSignedUrl_AssetId;
            context.ExportAssetToSignedUrl_DataSetId = this.ExportAssetToSignedUrl_DataSetId;
            context.ExportAssetToSignedUrl_RevisionId = this.ExportAssetToSignedUrl_RevisionId;
            context.ExportRevisionsToS3_DataSetId = this.ExportRevisionsToS3_DataSetId;
            context.Details_ExportRevisionsToS3_Encryption_KmsKeyArn = this.Details_ExportRevisionsToS3_Encryption_KmsKeyArn;
            context.Details_ExportRevisionsToS3_Encryption_Type = this.Details_ExportRevisionsToS3_Encryption_Type;
            if (this.ExportRevisionsToS3_RevisionDestination != null)
            {
                context.ExportRevisionsToS3_RevisionDestination = new List<Amazon.DataExchange.Model.RevisionDestinationEntry>(this.ExportRevisionsToS3_RevisionDestination);
            }
            context.ImportAssetFromSignedUrl_AssetName = this.ImportAssetFromSignedUrl_AssetName;
            context.ImportAssetFromSignedUrl_DataSetId = this.ImportAssetFromSignedUrl_DataSetId;
            context.ImportAssetFromSignedUrl_Md5Hash = this.ImportAssetFromSignedUrl_Md5Hash;
            context.ImportAssetFromSignedUrl_RevisionId = this.ImportAssetFromSignedUrl_RevisionId;
            if (this.ImportAssetsFromRedshiftDataShares_AssetSource != null)
            {
                context.ImportAssetsFromRedshiftDataShares_AssetSource = new List<Amazon.DataExchange.Model.RedshiftDataShareAssetSourceEntry>(this.ImportAssetsFromRedshiftDataShares_AssetSource);
            }
            context.ImportAssetsFromRedshiftDataShares_DataSetId = this.ImportAssetsFromRedshiftDataShares_DataSetId;
            context.ImportAssetsFromRedshiftDataShares_RevisionId = this.ImportAssetsFromRedshiftDataShares_RevisionId;
            if (this.ImportAssetsFromS3_AssetSource != null)
            {
                context.ImportAssetsFromS3_AssetSource = new List<Amazon.DataExchange.Model.AssetSourceEntry>(this.ImportAssetsFromS3_AssetSource);
            }
            context.ImportAssetsFromS3_DataSetId = this.ImportAssetsFromS3_DataSetId;
            context.ImportAssetsFromS3_RevisionId = this.ImportAssetsFromS3_RevisionId;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataExchange.Model.CreateJobRequest();
            
            
             // populate Details
            var requestDetailsIsNull = true;
            request.Details = new Amazon.DataExchange.Model.RequestDetails();
            Amazon.DataExchange.Model.ExportAssetToSignedUrlRequestDetails requestDetails_details_ExportAssetToSignedUrl = null;
            
             // populate ExportAssetToSignedUrl
            var requestDetails_details_ExportAssetToSignedUrlIsNull = true;
            requestDetails_details_ExportAssetToSignedUrl = new Amazon.DataExchange.Model.ExportAssetToSignedUrlRequestDetails();
            System.String requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_AssetId = null;
            if (cmdletContext.ExportAssetToSignedUrl_AssetId != null)
            {
                requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_AssetId = cmdletContext.ExportAssetToSignedUrl_AssetId;
            }
            if (requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_AssetId != null)
            {
                requestDetails_details_ExportAssetToSignedUrl.AssetId = requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_AssetId;
                requestDetails_details_ExportAssetToSignedUrlIsNull = false;
            }
            System.String requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_DataSetId = null;
            if (cmdletContext.ExportAssetToSignedUrl_DataSetId != null)
            {
                requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_DataSetId = cmdletContext.ExportAssetToSignedUrl_DataSetId;
            }
            if (requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_DataSetId != null)
            {
                requestDetails_details_ExportAssetToSignedUrl.DataSetId = requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_DataSetId;
                requestDetails_details_ExportAssetToSignedUrlIsNull = false;
            }
            System.String requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_RevisionId = null;
            if (cmdletContext.ExportAssetToSignedUrl_RevisionId != null)
            {
                requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_RevisionId = cmdletContext.ExportAssetToSignedUrl_RevisionId;
            }
            if (requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_RevisionId != null)
            {
                requestDetails_details_ExportAssetToSignedUrl.RevisionId = requestDetails_details_ExportAssetToSignedUrl_exportAssetToSignedUrl_RevisionId;
                requestDetails_details_ExportAssetToSignedUrlIsNull = false;
            }
             // determine if requestDetails_details_ExportAssetToSignedUrl should be set to null
            if (requestDetails_details_ExportAssetToSignedUrlIsNull)
            {
                requestDetails_details_ExportAssetToSignedUrl = null;
            }
            if (requestDetails_details_ExportAssetToSignedUrl != null)
            {
                request.Details.ExportAssetToSignedUrl = requestDetails_details_ExportAssetToSignedUrl;
                requestDetailsIsNull = false;
            }
            Amazon.DataExchange.Model.ExportRevisionsToS3RequestDetails requestDetails_details_ExportRevisionsToS3 = null;
            
             // populate ExportRevisionsToS3
            var requestDetails_details_ExportRevisionsToS3IsNull = true;
            requestDetails_details_ExportRevisionsToS3 = new Amazon.DataExchange.Model.ExportRevisionsToS3RequestDetails();
            System.String requestDetails_details_ExportRevisionsToS3_exportRevisionsToS3_DataSetId = null;
            if (cmdletContext.ExportRevisionsToS3_DataSetId != null)
            {
                requestDetails_details_ExportRevisionsToS3_exportRevisionsToS3_DataSetId = cmdletContext.ExportRevisionsToS3_DataSetId;
            }
            if (requestDetails_details_ExportRevisionsToS3_exportRevisionsToS3_DataSetId != null)
            {
                requestDetails_details_ExportRevisionsToS3.DataSetId = requestDetails_details_ExportRevisionsToS3_exportRevisionsToS3_DataSetId;
                requestDetails_details_ExportRevisionsToS3IsNull = false;
            }
            List<Amazon.DataExchange.Model.RevisionDestinationEntry> requestDetails_details_ExportRevisionsToS3_exportRevisionsToS3_RevisionDestination = null;
            if (cmdletContext.ExportRevisionsToS3_RevisionDestination != null)
            {
                requestDetails_details_ExportRevisionsToS3_exportRevisionsToS3_RevisionDestination = cmdletContext.ExportRevisionsToS3_RevisionDestination;
            }
            if (requestDetails_details_ExportRevisionsToS3_exportRevisionsToS3_RevisionDestination != null)
            {
                requestDetails_details_ExportRevisionsToS3.RevisionDestinations = requestDetails_details_ExportRevisionsToS3_exportRevisionsToS3_RevisionDestination;
                requestDetails_details_ExportRevisionsToS3IsNull = false;
            }
            Amazon.DataExchange.Model.ExportServerSideEncryption requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption = null;
            
             // populate Encryption
            var requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_EncryptionIsNull = true;
            requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption = new Amazon.DataExchange.Model.ExportServerSideEncryption();
            System.String requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption_details_ExportRevisionsToS3_Encryption_KmsKeyArn = null;
            if (cmdletContext.Details_ExportRevisionsToS3_Encryption_KmsKeyArn != null)
            {
                requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption_details_ExportRevisionsToS3_Encryption_KmsKeyArn = cmdletContext.Details_ExportRevisionsToS3_Encryption_KmsKeyArn;
            }
            if (requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption_details_ExportRevisionsToS3_Encryption_KmsKeyArn != null)
            {
                requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption.KmsKeyArn = requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption_details_ExportRevisionsToS3_Encryption_KmsKeyArn;
                requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_EncryptionIsNull = false;
            }
            Amazon.DataExchange.ServerSideEncryptionTypes requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption_details_ExportRevisionsToS3_Encryption_Type = null;
            if (cmdletContext.Details_ExportRevisionsToS3_Encryption_Type != null)
            {
                requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption_details_ExportRevisionsToS3_Encryption_Type = cmdletContext.Details_ExportRevisionsToS3_Encryption_Type;
            }
            if (requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption_details_ExportRevisionsToS3_Encryption_Type != null)
            {
                requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption.Type = requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption_details_ExportRevisionsToS3_Encryption_Type;
                requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_EncryptionIsNull = false;
            }
             // determine if requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption should be set to null
            if (requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_EncryptionIsNull)
            {
                requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption = null;
            }
            if (requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption != null)
            {
                requestDetails_details_ExportRevisionsToS3.Encryption = requestDetails_details_ExportRevisionsToS3_details_ExportRevisionsToS3_Encryption;
                requestDetails_details_ExportRevisionsToS3IsNull = false;
            }
             // determine if requestDetails_details_ExportRevisionsToS3 should be set to null
            if (requestDetails_details_ExportRevisionsToS3IsNull)
            {
                requestDetails_details_ExportRevisionsToS3 = null;
            }
            if (requestDetails_details_ExportRevisionsToS3 != null)
            {
                request.Details.ExportRevisionsToS3 = requestDetails_details_ExportRevisionsToS3;
                requestDetailsIsNull = false;
            }
            Amazon.DataExchange.Model.ImportAssetsFromRedshiftDataSharesRequestDetails requestDetails_details_ImportAssetsFromRedshiftDataShares = null;
            
             // populate ImportAssetsFromRedshiftDataShares
            var requestDetails_details_ImportAssetsFromRedshiftDataSharesIsNull = true;
            requestDetails_details_ImportAssetsFromRedshiftDataShares = new Amazon.DataExchange.Model.ImportAssetsFromRedshiftDataSharesRequestDetails();
            List<Amazon.DataExchange.Model.RedshiftDataShareAssetSourceEntry> requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_AssetSource = null;
            if (cmdletContext.ImportAssetsFromRedshiftDataShares_AssetSource != null)
            {
                requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_AssetSource = cmdletContext.ImportAssetsFromRedshiftDataShares_AssetSource;
            }
            if (requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_AssetSource != null)
            {
                requestDetails_details_ImportAssetsFromRedshiftDataShares.AssetSources = requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_AssetSource;
                requestDetails_details_ImportAssetsFromRedshiftDataSharesIsNull = false;
            }
            System.String requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_DataSetId = null;
            if (cmdletContext.ImportAssetsFromRedshiftDataShares_DataSetId != null)
            {
                requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_DataSetId = cmdletContext.ImportAssetsFromRedshiftDataShares_DataSetId;
            }
            if (requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_DataSetId != null)
            {
                requestDetails_details_ImportAssetsFromRedshiftDataShares.DataSetId = requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_DataSetId;
                requestDetails_details_ImportAssetsFromRedshiftDataSharesIsNull = false;
            }
            System.String requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_RevisionId = null;
            if (cmdletContext.ImportAssetsFromRedshiftDataShares_RevisionId != null)
            {
                requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_RevisionId = cmdletContext.ImportAssetsFromRedshiftDataShares_RevisionId;
            }
            if (requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_RevisionId != null)
            {
                requestDetails_details_ImportAssetsFromRedshiftDataShares.RevisionId = requestDetails_details_ImportAssetsFromRedshiftDataShares_importAssetsFromRedshiftDataShares_RevisionId;
                requestDetails_details_ImportAssetsFromRedshiftDataSharesIsNull = false;
            }
             // determine if requestDetails_details_ImportAssetsFromRedshiftDataShares should be set to null
            if (requestDetails_details_ImportAssetsFromRedshiftDataSharesIsNull)
            {
                requestDetails_details_ImportAssetsFromRedshiftDataShares = null;
            }
            if (requestDetails_details_ImportAssetsFromRedshiftDataShares != null)
            {
                request.Details.ImportAssetsFromRedshiftDataShares = requestDetails_details_ImportAssetsFromRedshiftDataShares;
                requestDetailsIsNull = false;
            }
            Amazon.DataExchange.Model.ImportAssetsFromS3RequestDetails requestDetails_details_ImportAssetsFromS3 = null;
            
             // populate ImportAssetsFromS3
            var requestDetails_details_ImportAssetsFromS3IsNull = true;
            requestDetails_details_ImportAssetsFromS3 = new Amazon.DataExchange.Model.ImportAssetsFromS3RequestDetails();
            List<Amazon.DataExchange.Model.AssetSourceEntry> requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_AssetSource = null;
            if (cmdletContext.ImportAssetsFromS3_AssetSource != null)
            {
                requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_AssetSource = cmdletContext.ImportAssetsFromS3_AssetSource;
            }
            if (requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_AssetSource != null)
            {
                requestDetails_details_ImportAssetsFromS3.AssetSources = requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_AssetSource;
                requestDetails_details_ImportAssetsFromS3IsNull = false;
            }
            System.String requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_DataSetId = null;
            if (cmdletContext.ImportAssetsFromS3_DataSetId != null)
            {
                requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_DataSetId = cmdletContext.ImportAssetsFromS3_DataSetId;
            }
            if (requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_DataSetId != null)
            {
                requestDetails_details_ImportAssetsFromS3.DataSetId = requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_DataSetId;
                requestDetails_details_ImportAssetsFromS3IsNull = false;
            }
            System.String requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_RevisionId = null;
            if (cmdletContext.ImportAssetsFromS3_RevisionId != null)
            {
                requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_RevisionId = cmdletContext.ImportAssetsFromS3_RevisionId;
            }
            if (requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_RevisionId != null)
            {
                requestDetails_details_ImportAssetsFromS3.RevisionId = requestDetails_details_ImportAssetsFromS3_importAssetsFromS3_RevisionId;
                requestDetails_details_ImportAssetsFromS3IsNull = false;
            }
             // determine if requestDetails_details_ImportAssetsFromS3 should be set to null
            if (requestDetails_details_ImportAssetsFromS3IsNull)
            {
                requestDetails_details_ImportAssetsFromS3 = null;
            }
            if (requestDetails_details_ImportAssetsFromS3 != null)
            {
                request.Details.ImportAssetsFromS3 = requestDetails_details_ImportAssetsFromS3;
                requestDetailsIsNull = false;
            }
            Amazon.DataExchange.Model.ExportAssetsToS3RequestDetails requestDetails_details_ExportAssetsToS3 = null;
            
             // populate ExportAssetsToS3
            var requestDetails_details_ExportAssetsToS3IsNull = true;
            requestDetails_details_ExportAssetsToS3 = new Amazon.DataExchange.Model.ExportAssetsToS3RequestDetails();
            List<Amazon.DataExchange.Model.AssetDestinationEntry> requestDetails_details_ExportAssetsToS3_exportAssetsToS3_AssetDestination = null;
            if (cmdletContext.ExportAssetsToS3_AssetDestination != null)
            {
                requestDetails_details_ExportAssetsToS3_exportAssetsToS3_AssetDestination = cmdletContext.ExportAssetsToS3_AssetDestination;
            }
            if (requestDetails_details_ExportAssetsToS3_exportAssetsToS3_AssetDestination != null)
            {
                requestDetails_details_ExportAssetsToS3.AssetDestinations = requestDetails_details_ExportAssetsToS3_exportAssetsToS3_AssetDestination;
                requestDetails_details_ExportAssetsToS3IsNull = false;
            }
            System.String requestDetails_details_ExportAssetsToS3_exportAssetsToS3_DataSetId = null;
            if (cmdletContext.ExportAssetsToS3_DataSetId != null)
            {
                requestDetails_details_ExportAssetsToS3_exportAssetsToS3_DataSetId = cmdletContext.ExportAssetsToS3_DataSetId;
            }
            if (requestDetails_details_ExportAssetsToS3_exportAssetsToS3_DataSetId != null)
            {
                requestDetails_details_ExportAssetsToS3.DataSetId = requestDetails_details_ExportAssetsToS3_exportAssetsToS3_DataSetId;
                requestDetails_details_ExportAssetsToS3IsNull = false;
            }
            System.String requestDetails_details_ExportAssetsToS3_exportAssetsToS3_RevisionId = null;
            if (cmdletContext.ExportAssetsToS3_RevisionId != null)
            {
                requestDetails_details_ExportAssetsToS3_exportAssetsToS3_RevisionId = cmdletContext.ExportAssetsToS3_RevisionId;
            }
            if (requestDetails_details_ExportAssetsToS3_exportAssetsToS3_RevisionId != null)
            {
                requestDetails_details_ExportAssetsToS3.RevisionId = requestDetails_details_ExportAssetsToS3_exportAssetsToS3_RevisionId;
                requestDetails_details_ExportAssetsToS3IsNull = false;
            }
            Amazon.DataExchange.Model.ExportServerSideEncryption requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption = null;
            
             // populate Encryption
            var requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_EncryptionIsNull = true;
            requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption = new Amazon.DataExchange.Model.ExportServerSideEncryption();
            System.String requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption_encryption_KmsKeyArn = null;
            if (cmdletContext.Encryption_KmsKeyArn != null)
            {
                requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption_encryption_KmsKeyArn = cmdletContext.Encryption_KmsKeyArn;
            }
            if (requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption_encryption_KmsKeyArn != null)
            {
                requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption.KmsKeyArn = requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption_encryption_KmsKeyArn;
                requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_EncryptionIsNull = false;
            }
            Amazon.DataExchange.ServerSideEncryptionTypes requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption_encryption_Type = null;
            if (cmdletContext.Encryption_Type != null)
            {
                requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption_encryption_Type = cmdletContext.Encryption_Type;
            }
            if (requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption_encryption_Type != null)
            {
                requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption.Type = requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption_encryption_Type;
                requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_EncryptionIsNull = false;
            }
             // determine if requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption should be set to null
            if (requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_EncryptionIsNull)
            {
                requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption = null;
            }
            if (requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption != null)
            {
                requestDetails_details_ExportAssetsToS3.Encryption = requestDetails_details_ExportAssetsToS3_details_ExportAssetsToS3_Encryption;
                requestDetails_details_ExportAssetsToS3IsNull = false;
            }
             // determine if requestDetails_details_ExportAssetsToS3 should be set to null
            if (requestDetails_details_ExportAssetsToS3IsNull)
            {
                requestDetails_details_ExportAssetsToS3 = null;
            }
            if (requestDetails_details_ExportAssetsToS3 != null)
            {
                request.Details.ExportAssetsToS3 = requestDetails_details_ExportAssetsToS3;
                requestDetailsIsNull = false;
            }
            Amazon.DataExchange.Model.ImportAssetFromSignedUrlRequestDetails requestDetails_details_ImportAssetFromSignedUrl = null;
            
             // populate ImportAssetFromSignedUrl
            var requestDetails_details_ImportAssetFromSignedUrlIsNull = true;
            requestDetails_details_ImportAssetFromSignedUrl = new Amazon.DataExchange.Model.ImportAssetFromSignedUrlRequestDetails();
            System.String requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_AssetName = null;
            if (cmdletContext.ImportAssetFromSignedUrl_AssetName != null)
            {
                requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_AssetName = cmdletContext.ImportAssetFromSignedUrl_AssetName;
            }
            if (requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_AssetName != null)
            {
                requestDetails_details_ImportAssetFromSignedUrl.AssetName = requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_AssetName;
                requestDetails_details_ImportAssetFromSignedUrlIsNull = false;
            }
            System.String requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_DataSetId = null;
            if (cmdletContext.ImportAssetFromSignedUrl_DataSetId != null)
            {
                requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_DataSetId = cmdletContext.ImportAssetFromSignedUrl_DataSetId;
            }
            if (requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_DataSetId != null)
            {
                requestDetails_details_ImportAssetFromSignedUrl.DataSetId = requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_DataSetId;
                requestDetails_details_ImportAssetFromSignedUrlIsNull = false;
            }
            System.String requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_Md5Hash = null;
            if (cmdletContext.ImportAssetFromSignedUrl_Md5Hash != null)
            {
                requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_Md5Hash = cmdletContext.ImportAssetFromSignedUrl_Md5Hash;
            }
            if (requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_Md5Hash != null)
            {
                requestDetails_details_ImportAssetFromSignedUrl.Md5Hash = requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_Md5Hash;
                requestDetails_details_ImportAssetFromSignedUrlIsNull = false;
            }
            System.String requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_RevisionId = null;
            if (cmdletContext.ImportAssetFromSignedUrl_RevisionId != null)
            {
                requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_RevisionId = cmdletContext.ImportAssetFromSignedUrl_RevisionId;
            }
            if (requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_RevisionId != null)
            {
                requestDetails_details_ImportAssetFromSignedUrl.RevisionId = requestDetails_details_ImportAssetFromSignedUrl_importAssetFromSignedUrl_RevisionId;
                requestDetails_details_ImportAssetFromSignedUrlIsNull = false;
            }
             // determine if requestDetails_details_ImportAssetFromSignedUrl should be set to null
            if (requestDetails_details_ImportAssetFromSignedUrlIsNull)
            {
                requestDetails_details_ImportAssetFromSignedUrl = null;
            }
            if (requestDetails_details_ImportAssetFromSignedUrl != null)
            {
                request.Details.ImportAssetFromSignedUrl = requestDetails_details_ImportAssetFromSignedUrl;
                requestDetailsIsNull = false;
            }
             // determine if request.Details should be set to null
            if (requestDetailsIsNull)
            {
                request.Details = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.DataExchange.Model.CreateJobResponse CallAWSServiceOperation(IAmazonDataExchange client, Amazon.DataExchange.Model.CreateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Exchange", "CreateJob");
            try
            {
                #if DESKTOP
                return client.CreateJob(request);
                #elif CORECLR
                return client.CreateJobAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DataExchange.Model.AssetDestinationEntry> ExportAssetsToS3_AssetDestination { get; set; }
            public System.String ExportAssetsToS3_DataSetId { get; set; }
            public System.String Encryption_KmsKeyArn { get; set; }
            public Amazon.DataExchange.ServerSideEncryptionTypes Encryption_Type { get; set; }
            public System.String ExportAssetsToS3_RevisionId { get; set; }
            public System.String ExportAssetToSignedUrl_AssetId { get; set; }
            public System.String ExportAssetToSignedUrl_DataSetId { get; set; }
            public System.String ExportAssetToSignedUrl_RevisionId { get; set; }
            public System.String ExportRevisionsToS3_DataSetId { get; set; }
            public System.String Details_ExportRevisionsToS3_Encryption_KmsKeyArn { get; set; }
            public Amazon.DataExchange.ServerSideEncryptionTypes Details_ExportRevisionsToS3_Encryption_Type { get; set; }
            public List<Amazon.DataExchange.Model.RevisionDestinationEntry> ExportRevisionsToS3_RevisionDestination { get; set; }
            public System.String ImportAssetFromSignedUrl_AssetName { get; set; }
            public System.String ImportAssetFromSignedUrl_DataSetId { get; set; }
            public System.String ImportAssetFromSignedUrl_Md5Hash { get; set; }
            public System.String ImportAssetFromSignedUrl_RevisionId { get; set; }
            public List<Amazon.DataExchange.Model.RedshiftDataShareAssetSourceEntry> ImportAssetsFromRedshiftDataShares_AssetSource { get; set; }
            public System.String ImportAssetsFromRedshiftDataShares_DataSetId { get; set; }
            public System.String ImportAssetsFromRedshiftDataShares_RevisionId { get; set; }
            public List<Amazon.DataExchange.Model.AssetSourceEntry> ImportAssetsFromS3_AssetSource { get; set; }
            public System.String ImportAssetsFromS3_DataSetId { get; set; }
            public System.String ImportAssetsFromS3_RevisionId { get; set; }
            public Amazon.DataExchange.Type Type { get; set; }
            public System.Func<Amazon.DataExchange.Model.CreateJobResponse, NewDTEXJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
