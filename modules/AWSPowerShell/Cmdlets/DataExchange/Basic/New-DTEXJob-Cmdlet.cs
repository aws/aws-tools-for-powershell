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
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ImportAssetFromApiGatewayApi_ApiDescription
        /// <summary>
        /// <para>
        /// <para>The API description. Markdown supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromApiGatewayApi_ApiDescription")]
        public System.String ImportAssetFromApiGatewayApi_ApiDescription { get; set; }
        #endregion
        
        #region Parameter ImportAssetFromApiGatewayApi_ApiId
        /// <summary>
        /// <para>
        /// <para>The API Gateway API ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromApiGatewayApi_ApiId")]
        public System.String ImportAssetFromApiGatewayApi_ApiId { get; set; }
        #endregion
        
        #region Parameter ImportAssetFromApiGatewayApi_ApiKey
        /// <summary>
        /// <para>
        /// <para>The API Gateway API key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromApiGatewayApi_ApiKey")]
        public System.String ImportAssetFromApiGatewayApi_ApiKey { get; set; }
        #endregion
        
        #region Parameter ImportAssetFromApiGatewayApi_ApiName
        /// <summary>
        /// <para>
        /// <para>The API name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromApiGatewayApi_ApiName")]
        public System.String ImportAssetFromApiGatewayApi_ApiName { get; set; }
        #endregion
        
        #region Parameter ImportAssetFromApiGatewayApi_ApiSpecificationMd5Hash
        /// <summary>
        /// <para>
        /// <para>The Base64-encoded MD5 hash of the OpenAPI 3.0 JSON API specification file. It is
        /// used to ensure the integrity of the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromApiGatewayApi_ApiSpecificationMd5Hash")]
        public System.String ImportAssetFromApiGatewayApi_ApiSpecificationMd5Hash { get; set; }
        #endregion
        
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
        /// <para>The name of the asset. When importing from Amazon S3, the Amazon S3 object key is
        /// used as the asset name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromSignedUrl_AssetName")]
        public System.String ImportAssetFromSignedUrl_AssetName { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromRedshiftDataShares_AssetSource
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Redshift datashare assets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromRedshiftDataShares_AssetSources")]
        public Amazon.DataExchange.Model.RedshiftDataShareAssetSourceEntry[] ImportAssetsFromRedshiftDataShares_AssetSource { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromS3_AssetSource
        /// <summary>
        /// <para>
        /// <para>Is a list of Amazon S3 bucket and object key pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromS3_AssetSources")]
        public Amazon.DataExchange.Model.AssetSourceEntry[] ImportAssetsFromS3_AssetSource { get; set; }
        #endregion
        
        #region Parameter AssetSource_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket used for hosting shared data in the Amazon S3 data access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_CreateS3DataAccessFromS3Bucket_AssetSource_Bucket")]
        public System.String AssetSource_Bucket { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromLakeFormationTagPolicy_CatalogId
        /// <summary>
        /// <para>
        /// <para>The identifier for the AWS Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromLakeFormationTagPolicy_CatalogId")]
        public System.String ImportAssetsFromLakeFormationTagPolicy_CatalogId { get; set; }
        #endregion
        
        #region Parameter CreateS3DataAccessFromS3Bucket_DataSetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the data set associated with the creation of this Amazon
        /// S3 data access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_CreateS3DataAccessFromS3Bucket_DataSetId")]
        public System.String CreateS3DataAccessFromS3Bucket_DataSetId { get; set; }
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
        
        #region Parameter ImportAssetFromApiGatewayApi_DataSetId
        /// <summary>
        /// <para>
        /// <para>The data set ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromApiGatewayApi_DataSetId")]
        public System.String ImportAssetFromApiGatewayApi_DataSetId { get; set; }
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
        
        #region Parameter ImportAssetsFromLakeFormationTagPolicy_DataSetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the data set associated with this import job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromLakeFormationTagPolicy_DataSetId")]
        public System.String ImportAssetsFromLakeFormationTagPolicy_DataSetId { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromRedshiftDataShares_DataSetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the data set associated with this import job.</para>
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
        
        #region Parameter Database_Expression
        /// <summary>
        /// <para>
        /// <para>A list of LF-tag conditions that apply to database resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromLakeFormationTagPolicy_Database_Expression")]
        public Amazon.DataExchange.Model.LFTag[] Database_Expression { get; set; }
        #endregion
        
        #region Parameter Table_Expression
        /// <summary>
        /// <para>
        /// <para>A list of LF-tag conditions that apply to table resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromLakeFormationTagPolicy_Table_Expression")]
        public Amazon.DataExchange.Model.LFTag[] Table_Expression { get; set; }
        #endregion
        
        #region Parameter AssetSource_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>Organizes Amazon S3 asset key prefixes stored in an Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_CreateS3DataAccessFromS3Bucket_AssetSource_KeyPrefixes")]
        public System.String[] AssetSource_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter AssetSource_Key
        /// <summary>
        /// <para>
        /// <para>The keys used to create the Amazon S3 data access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_CreateS3DataAccessFromS3Bucket_AssetSource_Keys")]
        public System.String[] AssetSource_Key { get; set; }
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
        
        #region Parameter AssetSource_KmsKeysToGrant
        /// <summary>
        /// <para>
        /// <para>List of AWS KMS CMKs (Key Management System Customer Managed Keys) and ARNs used to
        /// encrypt S3 objects being shared in this S3 Data Access asset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_CreateS3DataAccessFromS3Bucket_AssetSource_KmsKeysToGrant")]
        public Amazon.DataExchange.Model.KmsKeyToGrant[] AssetSource_KmsKeysToGrant { get; set; }
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
        
        #region Parameter Database_Permission
        /// <summary>
        /// <para>
        /// <para>The permissions granted to subscribers on database resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromLakeFormationTagPolicy_Database_Permissions")]
        public System.String[] Database_Permission { get; set; }
        #endregion
        
        #region Parameter Table_Permission
        /// <summary>
        /// <para>
        /// <para>The permissions granted to subscribers on table resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromLakeFormationTagPolicy_Table_Permissions")]
        public System.String[] Table_Permission { get; set; }
        #endregion
        
        #region Parameter ImportAssetFromApiGatewayApi_ProtocolType
        /// <summary>
        /// <para>
        /// <para>The protocol type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromApiGatewayApi_ProtocolType")]
        [AWSConstantClassSource("Amazon.DataExchange.ProtocolType")]
        public Amazon.DataExchange.ProtocolType ImportAssetFromApiGatewayApi_ProtocolType { get; set; }
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
        
        #region Parameter CreateS3DataAccessFromS3Bucket_RevisionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for a revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_CreateS3DataAccessFromS3Bucket_RevisionId")]
        public System.String CreateS3DataAccessFromS3Bucket_RevisionId { get; set; }
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
        
        #region Parameter ImportAssetFromApiGatewayApi_RevisionId
        /// <summary>
        /// <para>
        /// <para>The revision ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromApiGatewayApi_RevisionId")]
        public System.String ImportAssetFromApiGatewayApi_RevisionId { get; set; }
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
        
        #region Parameter ImportAssetsFromLakeFormationTagPolicy_RevisionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the revision associated with this import job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromLakeFormationTagPolicy_RevisionId")]
        public System.String ImportAssetsFromLakeFormationTagPolicy_RevisionId { get; set; }
        #endregion
        
        #region Parameter ImportAssetsFromRedshiftDataShares_RevisionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the revision associated with this import job.</para>
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
        
        #region Parameter ImportAssetsFromLakeFormationTagPolicy_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role's ARN that allows AWS Data Exchange to assume the role and grant and
        /// revoke permissions of subscribers to AWS Lake Formation data permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetsFromLakeFormationTagPolicy_RoleArn")]
        public System.String ImportAssetsFromLakeFormationTagPolicy_RoleArn { get; set; }
        #endregion
        
        #region Parameter ImportAssetFromApiGatewayApi_Stage
        /// <summary>
        /// <para>
        /// <para>The API stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_ImportAssetFromApiGatewayApi_Stage")]
        public System.String ImportAssetFromApiGatewayApi_Stage { get; set; }
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
            this._AWSSignerType = "v4";
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
            context.AssetSource_Bucket = this.AssetSource_Bucket;
            if (this.AssetSource_KeyPrefix != null)
            {
                context.AssetSource_KeyPrefix = new List<System.String>(this.AssetSource_KeyPrefix);
            }
            if (this.AssetSource_Key != null)
            {
                context.AssetSource_Key = new List<System.String>(this.AssetSource_Key);
            }
            if (this.AssetSource_KmsKeysToGrant != null)
            {
                context.AssetSource_KmsKeysToGrant = new List<Amazon.DataExchange.Model.KmsKeyToGrant>(this.AssetSource_KmsKeysToGrant);
            }
            context.CreateS3DataAccessFromS3Bucket_DataSetId = this.CreateS3DataAccessFromS3Bucket_DataSetId;
            context.CreateS3DataAccessFromS3Bucket_RevisionId = this.CreateS3DataAccessFromS3Bucket_RevisionId;
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
            context.ImportAssetFromApiGatewayApi_ApiDescription = this.ImportAssetFromApiGatewayApi_ApiDescription;
            context.ImportAssetFromApiGatewayApi_ApiId = this.ImportAssetFromApiGatewayApi_ApiId;
            context.ImportAssetFromApiGatewayApi_ApiKey = this.ImportAssetFromApiGatewayApi_ApiKey;
            context.ImportAssetFromApiGatewayApi_ApiName = this.ImportAssetFromApiGatewayApi_ApiName;
            context.ImportAssetFromApiGatewayApi_ApiSpecificationMd5Hash = this.ImportAssetFromApiGatewayApi_ApiSpecificationMd5Hash;
            context.ImportAssetFromApiGatewayApi_DataSetId = this.ImportAssetFromApiGatewayApi_DataSetId;
            context.ImportAssetFromApiGatewayApi_ProtocolType = this.ImportAssetFromApiGatewayApi_ProtocolType;
            context.ImportAssetFromApiGatewayApi_RevisionId = this.ImportAssetFromApiGatewayApi_RevisionId;
            context.ImportAssetFromApiGatewayApi_Stage = this.ImportAssetFromApiGatewayApi_Stage;
            context.ImportAssetFromSignedUrl_AssetName = this.ImportAssetFromSignedUrl_AssetName;
            context.ImportAssetFromSignedUrl_DataSetId = this.ImportAssetFromSignedUrl_DataSetId;
            context.ImportAssetFromSignedUrl_Md5Hash = this.ImportAssetFromSignedUrl_Md5Hash;
            context.ImportAssetFromSignedUrl_RevisionId = this.ImportAssetFromSignedUrl_RevisionId;
            context.ImportAssetsFromLakeFormationTagPolicy_CatalogId = this.ImportAssetsFromLakeFormationTagPolicy_CatalogId;
            if (this.Database_Expression != null)
            {
                context.Database_Expression = new List<Amazon.DataExchange.Model.LFTag>(this.Database_Expression);
            }
            if (this.Database_Permission != null)
            {
                context.Database_Permission = new List<System.String>(this.Database_Permission);
            }
            context.ImportAssetsFromLakeFormationTagPolicy_DataSetId = this.ImportAssetsFromLakeFormationTagPolicy_DataSetId;
            context.ImportAssetsFromLakeFormationTagPolicy_RevisionId = this.ImportAssetsFromLakeFormationTagPolicy_RevisionId;
            context.ImportAssetsFromLakeFormationTagPolicy_RoleArn = this.ImportAssetsFromLakeFormationTagPolicy_RoleArn;
            if (this.Table_Expression != null)
            {
                context.Table_Expression = new List<Amazon.DataExchange.Model.LFTag>(this.Table_Expression);
            }
            if (this.Table_Permission != null)
            {
                context.Table_Permission = new List<System.String>(this.Table_Permission);
            }
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
            Amazon.DataExchange.Model.CreateS3DataAccessFromS3BucketRequestDetails requestDetails_details_CreateS3DataAccessFromS3Bucket = null;
            
             // populate CreateS3DataAccessFromS3Bucket
            var requestDetails_details_CreateS3DataAccessFromS3BucketIsNull = true;
            requestDetails_details_CreateS3DataAccessFromS3Bucket = new Amazon.DataExchange.Model.CreateS3DataAccessFromS3BucketRequestDetails();
            System.String requestDetails_details_CreateS3DataAccessFromS3Bucket_createS3DataAccessFromS3Bucket_DataSetId = null;
            if (cmdletContext.CreateS3DataAccessFromS3Bucket_DataSetId != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_createS3DataAccessFromS3Bucket_DataSetId = cmdletContext.CreateS3DataAccessFromS3Bucket_DataSetId;
            }
            if (requestDetails_details_CreateS3DataAccessFromS3Bucket_createS3DataAccessFromS3Bucket_DataSetId != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket.DataSetId = requestDetails_details_CreateS3DataAccessFromS3Bucket_createS3DataAccessFromS3Bucket_DataSetId;
                requestDetails_details_CreateS3DataAccessFromS3BucketIsNull = false;
            }
            System.String requestDetails_details_CreateS3DataAccessFromS3Bucket_createS3DataAccessFromS3Bucket_RevisionId = null;
            if (cmdletContext.CreateS3DataAccessFromS3Bucket_RevisionId != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_createS3DataAccessFromS3Bucket_RevisionId = cmdletContext.CreateS3DataAccessFromS3Bucket_RevisionId;
            }
            if (requestDetails_details_CreateS3DataAccessFromS3Bucket_createS3DataAccessFromS3Bucket_RevisionId != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket.RevisionId = requestDetails_details_CreateS3DataAccessFromS3Bucket_createS3DataAccessFromS3Bucket_RevisionId;
                requestDetails_details_CreateS3DataAccessFromS3BucketIsNull = false;
            }
            Amazon.DataExchange.Model.S3DataAccessAssetSourceEntry requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource = null;
            
             // populate AssetSource
            var requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSourceIsNull = true;
            requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource = new Amazon.DataExchange.Model.S3DataAccessAssetSourceEntry();
            System.String requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_Bucket = null;
            if (cmdletContext.AssetSource_Bucket != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_Bucket = cmdletContext.AssetSource_Bucket;
            }
            if (requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_Bucket != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource.Bucket = requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_Bucket;
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSourceIsNull = false;
            }
            List<System.String> requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_KeyPrefix = null;
            if (cmdletContext.AssetSource_KeyPrefix != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_KeyPrefix = cmdletContext.AssetSource_KeyPrefix;
            }
            if (requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_KeyPrefix != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource.KeyPrefixes = requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_KeyPrefix;
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSourceIsNull = false;
            }
            List<System.String> requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_Key = null;
            if (cmdletContext.AssetSource_Key != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_Key = cmdletContext.AssetSource_Key;
            }
            if (requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_Key != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource.Keys = requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_Key;
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSourceIsNull = false;
            }
            List<Amazon.DataExchange.Model.KmsKeyToGrant> requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_KmsKeysToGrant = null;
            if (cmdletContext.AssetSource_KmsKeysToGrant != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_KmsKeysToGrant = cmdletContext.AssetSource_KmsKeysToGrant;
            }
            if (requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_KmsKeysToGrant != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource.KmsKeysToGrant = requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource_assetSource_KmsKeysToGrant;
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSourceIsNull = false;
            }
             // determine if requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource should be set to null
            if (requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSourceIsNull)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource = null;
            }
            if (requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource != null)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket.AssetSource = requestDetails_details_CreateS3DataAccessFromS3Bucket_details_CreateS3DataAccessFromS3Bucket_AssetSource;
                requestDetails_details_CreateS3DataAccessFromS3BucketIsNull = false;
            }
             // determine if requestDetails_details_CreateS3DataAccessFromS3Bucket should be set to null
            if (requestDetails_details_CreateS3DataAccessFromS3BucketIsNull)
            {
                requestDetails_details_CreateS3DataAccessFromS3Bucket = null;
            }
            if (requestDetails_details_CreateS3DataAccessFromS3Bucket != null)
            {
                request.Details.CreateS3DataAccessFromS3Bucket = requestDetails_details_CreateS3DataAccessFromS3Bucket;
                requestDetailsIsNull = false;
            }
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
            Amazon.DataExchange.Model.ImportAssetsFromLakeFormationTagPolicyRequestDetails requestDetails_details_ImportAssetsFromLakeFormationTagPolicy = null;
            
             // populate ImportAssetsFromLakeFormationTagPolicy
            var requestDetails_details_ImportAssetsFromLakeFormationTagPolicyIsNull = true;
            requestDetails_details_ImportAssetsFromLakeFormationTagPolicy = new Amazon.DataExchange.Model.ImportAssetsFromLakeFormationTagPolicyRequestDetails();
            System.String requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_CatalogId = null;
            if (cmdletContext.ImportAssetsFromLakeFormationTagPolicy_CatalogId != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_CatalogId = cmdletContext.ImportAssetsFromLakeFormationTagPolicy_CatalogId;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_CatalogId != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy.CatalogId = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_CatalogId;
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicyIsNull = false;
            }
            System.String requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_DataSetId = null;
            if (cmdletContext.ImportAssetsFromLakeFormationTagPolicy_DataSetId != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_DataSetId = cmdletContext.ImportAssetsFromLakeFormationTagPolicy_DataSetId;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_DataSetId != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy.DataSetId = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_DataSetId;
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicyIsNull = false;
            }
            System.String requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_RevisionId = null;
            if (cmdletContext.ImportAssetsFromLakeFormationTagPolicy_RevisionId != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_RevisionId = cmdletContext.ImportAssetsFromLakeFormationTagPolicy_RevisionId;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_RevisionId != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy.RevisionId = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_RevisionId;
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicyIsNull = false;
            }
            System.String requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_RoleArn = null;
            if (cmdletContext.ImportAssetsFromLakeFormationTagPolicy_RoleArn != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_RoleArn = cmdletContext.ImportAssetsFromLakeFormationTagPolicy_RoleArn;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_RoleArn != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy.RoleArn = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_importAssetsFromLakeFormationTagPolicy_RoleArn;
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicyIsNull = false;
            }
            Amazon.DataExchange.Model.DatabaseLFTagPolicyAndPermissions requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database = null;
            
             // populate Database
            var requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_DatabaseIsNull = true;
            requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database = new Amazon.DataExchange.Model.DatabaseLFTagPolicyAndPermissions();
            List<Amazon.DataExchange.Model.LFTag> requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database_database_Expression = null;
            if (cmdletContext.Database_Expression != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database_database_Expression = cmdletContext.Database_Expression;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database_database_Expression != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database.Expression = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database_database_Expression;
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_DatabaseIsNull = false;
            }
            List<System.String> requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database_database_Permission = null;
            if (cmdletContext.Database_Permission != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database_database_Permission = cmdletContext.Database_Permission;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database_database_Permission != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database.Permissions = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database_database_Permission;
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_DatabaseIsNull = false;
            }
             // determine if requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database should be set to null
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_DatabaseIsNull)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database = null;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy.Database = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Database;
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicyIsNull = false;
            }
            Amazon.DataExchange.Model.TableLFTagPolicyAndPermissions requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table = null;
            
             // populate Table
            var requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_TableIsNull = true;
            requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table = new Amazon.DataExchange.Model.TableLFTagPolicyAndPermissions();
            List<Amazon.DataExchange.Model.LFTag> requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table_table_Expression = null;
            if (cmdletContext.Table_Expression != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table_table_Expression = cmdletContext.Table_Expression;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table_table_Expression != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table.Expression = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table_table_Expression;
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_TableIsNull = false;
            }
            List<System.String> requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table_table_Permission = null;
            if (cmdletContext.Table_Permission != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table_table_Permission = cmdletContext.Table_Permission;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table_table_Permission != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table.Permissions = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table_table_Permission;
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_TableIsNull = false;
            }
             // determine if requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table should be set to null
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_TableIsNull)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table = null;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table != null)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy.Table = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy_details_ImportAssetsFromLakeFormationTagPolicy_Table;
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicyIsNull = false;
            }
             // determine if requestDetails_details_ImportAssetsFromLakeFormationTagPolicy should be set to null
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicyIsNull)
            {
                requestDetails_details_ImportAssetsFromLakeFormationTagPolicy = null;
            }
            if (requestDetails_details_ImportAssetsFromLakeFormationTagPolicy != null)
            {
                request.Details.ImportAssetsFromLakeFormationTagPolicy = requestDetails_details_ImportAssetsFromLakeFormationTagPolicy;
                requestDetailsIsNull = false;
            }
            Amazon.DataExchange.Model.ImportAssetFromApiGatewayApiRequestDetails requestDetails_details_ImportAssetFromApiGatewayApi = null;
            
             // populate ImportAssetFromApiGatewayApi
            var requestDetails_details_ImportAssetFromApiGatewayApiIsNull = true;
            requestDetails_details_ImportAssetFromApiGatewayApi = new Amazon.DataExchange.Model.ImportAssetFromApiGatewayApiRequestDetails();
            System.String requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiDescription = null;
            if (cmdletContext.ImportAssetFromApiGatewayApi_ApiDescription != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiDescription = cmdletContext.ImportAssetFromApiGatewayApi_ApiDescription;
            }
            if (requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiDescription != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi.ApiDescription = requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiDescription;
                requestDetails_details_ImportAssetFromApiGatewayApiIsNull = false;
            }
            System.String requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiId = null;
            if (cmdletContext.ImportAssetFromApiGatewayApi_ApiId != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiId = cmdletContext.ImportAssetFromApiGatewayApi_ApiId;
            }
            if (requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiId != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi.ApiId = requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiId;
                requestDetails_details_ImportAssetFromApiGatewayApiIsNull = false;
            }
            System.String requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiKey = null;
            if (cmdletContext.ImportAssetFromApiGatewayApi_ApiKey != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiKey = cmdletContext.ImportAssetFromApiGatewayApi_ApiKey;
            }
            if (requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiKey != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi.ApiKey = requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiKey;
                requestDetails_details_ImportAssetFromApiGatewayApiIsNull = false;
            }
            System.String requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiName = null;
            if (cmdletContext.ImportAssetFromApiGatewayApi_ApiName != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiName = cmdletContext.ImportAssetFromApiGatewayApi_ApiName;
            }
            if (requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiName != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi.ApiName = requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiName;
                requestDetails_details_ImportAssetFromApiGatewayApiIsNull = false;
            }
            System.String requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiSpecificationMd5Hash = null;
            if (cmdletContext.ImportAssetFromApiGatewayApi_ApiSpecificationMd5Hash != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiSpecificationMd5Hash = cmdletContext.ImportAssetFromApiGatewayApi_ApiSpecificationMd5Hash;
            }
            if (requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiSpecificationMd5Hash != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi.ApiSpecificationMd5Hash = requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ApiSpecificationMd5Hash;
                requestDetails_details_ImportAssetFromApiGatewayApiIsNull = false;
            }
            System.String requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_DataSetId = null;
            if (cmdletContext.ImportAssetFromApiGatewayApi_DataSetId != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_DataSetId = cmdletContext.ImportAssetFromApiGatewayApi_DataSetId;
            }
            if (requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_DataSetId != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi.DataSetId = requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_DataSetId;
                requestDetails_details_ImportAssetFromApiGatewayApiIsNull = false;
            }
            Amazon.DataExchange.ProtocolType requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ProtocolType = null;
            if (cmdletContext.ImportAssetFromApiGatewayApi_ProtocolType != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ProtocolType = cmdletContext.ImportAssetFromApiGatewayApi_ProtocolType;
            }
            if (requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ProtocolType != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi.ProtocolType = requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_ProtocolType;
                requestDetails_details_ImportAssetFromApiGatewayApiIsNull = false;
            }
            System.String requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_RevisionId = null;
            if (cmdletContext.ImportAssetFromApiGatewayApi_RevisionId != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_RevisionId = cmdletContext.ImportAssetFromApiGatewayApi_RevisionId;
            }
            if (requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_RevisionId != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi.RevisionId = requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_RevisionId;
                requestDetails_details_ImportAssetFromApiGatewayApiIsNull = false;
            }
            System.String requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_Stage = null;
            if (cmdletContext.ImportAssetFromApiGatewayApi_Stage != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_Stage = cmdletContext.ImportAssetFromApiGatewayApi_Stage;
            }
            if (requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_Stage != null)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi.Stage = requestDetails_details_ImportAssetFromApiGatewayApi_importAssetFromApiGatewayApi_Stage;
                requestDetails_details_ImportAssetFromApiGatewayApiIsNull = false;
            }
             // determine if requestDetails_details_ImportAssetFromApiGatewayApi should be set to null
            if (requestDetails_details_ImportAssetFromApiGatewayApiIsNull)
            {
                requestDetails_details_ImportAssetFromApiGatewayApi = null;
            }
            if (requestDetails_details_ImportAssetFromApiGatewayApi != null)
            {
                request.Details.ImportAssetFromApiGatewayApi = requestDetails_details_ImportAssetFromApiGatewayApi;
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
            public System.String AssetSource_Bucket { get; set; }
            public List<System.String> AssetSource_KeyPrefix { get; set; }
            public List<System.String> AssetSource_Key { get; set; }
            public List<Amazon.DataExchange.Model.KmsKeyToGrant> AssetSource_KmsKeysToGrant { get; set; }
            public System.String CreateS3DataAccessFromS3Bucket_DataSetId { get; set; }
            public System.String CreateS3DataAccessFromS3Bucket_RevisionId { get; set; }
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
            public System.String ImportAssetFromApiGatewayApi_ApiDescription { get; set; }
            public System.String ImportAssetFromApiGatewayApi_ApiId { get; set; }
            public System.String ImportAssetFromApiGatewayApi_ApiKey { get; set; }
            public System.String ImportAssetFromApiGatewayApi_ApiName { get; set; }
            public System.String ImportAssetFromApiGatewayApi_ApiSpecificationMd5Hash { get; set; }
            public System.String ImportAssetFromApiGatewayApi_DataSetId { get; set; }
            public Amazon.DataExchange.ProtocolType ImportAssetFromApiGatewayApi_ProtocolType { get; set; }
            public System.String ImportAssetFromApiGatewayApi_RevisionId { get; set; }
            public System.String ImportAssetFromApiGatewayApi_Stage { get; set; }
            public System.String ImportAssetFromSignedUrl_AssetName { get; set; }
            public System.String ImportAssetFromSignedUrl_DataSetId { get; set; }
            public System.String ImportAssetFromSignedUrl_Md5Hash { get; set; }
            public System.String ImportAssetFromSignedUrl_RevisionId { get; set; }
            public System.String ImportAssetsFromLakeFormationTagPolicy_CatalogId { get; set; }
            public List<Amazon.DataExchange.Model.LFTag> Database_Expression { get; set; }
            public List<System.String> Database_Permission { get; set; }
            public System.String ImportAssetsFromLakeFormationTagPolicy_DataSetId { get; set; }
            public System.String ImportAssetsFromLakeFormationTagPolicy_RevisionId { get; set; }
            public System.String ImportAssetsFromLakeFormationTagPolicy_RoleArn { get; set; }
            public List<Amazon.DataExchange.Model.LFTag> Table_Expression { get; set; }
            public List<System.String> Table_Permission { get; set; }
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
