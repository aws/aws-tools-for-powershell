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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Creates or replaces the organization's retention storage record for a model provider.
    /// The organization is resolved from the authenticated caller's management context; the
    /// caller must be the organization's management account or a delegated administrator.
    /// Requires resolved organization-scope trusted access eligibility for a storage-capable
    /// program of the provider; otherwise returns ConflictException. Writes replace the whole
    /// record; the last write wins.
    /// 
    ///  
    /// <para>
    /// For <c>customer_managed</c> destinations, Amazon Bedrock validates the caller's and
    /// service's access to the bucket and key before saving the configuration. The bucket
    /// and key must be in the AWS Region where you register the configuration. Validation
    /// failures reject the write.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "BDROrganizationDataRetentionStorage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock PutOrganizationDataRetentionStorage API operation.", Operation = new[] {"PutOrganizationDataRetentionStorage"}, SelectReturnType = typeof(Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageResponse object containing multiple properties."
    )]
    public partial class WriteBDROrganizationDataRetentionStorageCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter StorageConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer managed AWS Key Management Service
        /// (AWS KMS) key you use to encrypt retained data. Specify an enabled symmetric encryption
        /// key in the AWS Region where you register the configuration. You cannot specify a key
        /// alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ModelProvider
        /// <summary>
        /// <para>
        /// <para>The model provider whose retention storage configuration is addressed by this request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Bedrock.DataRetentionStorageModelProvider")]
        public Amazon.Bedrock.DataRetentionStorageModelProvider ModelProvider { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_S3BucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon S3 bucket that receives retained data.
        /// The bucket must be in the AWS Region where you register the configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_S3BucketArn { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_S3BucketOwner
        /// <summary>
        /// <para>
        /// <para>The AWS account ID of the destination bucket's owner. You must specify the owner,
        /// even when the bucket belongs to another account. Amazon Bedrock uses this ID to verify
        /// bucket ownership for each delivery request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageConfiguration_S3BucketOwner { get; set; }
        #endregion
        
        #region Parameter StorageDestination
        /// <summary>
        /// <para>
        /// <para>Where retained data is delivered for this scope. customer_managed requires storageConfiguration;
        /// amazon_managed forbids it.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Bedrock.DataRetentionStorageDestination")]
        public Amazon.Bedrock.DataRetentionStorageDestination StorageDestination { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BDROrganizationDataRetentionStorage (PutOrganizationDataRetentionStorage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageResponse, WriteBDROrganizationDataRetentionStorageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ModelProvider = this.ModelProvider;
            #if MODULAR
            if (this.ModelProvider == null && ParameterWasBound(nameof(this.ModelProvider)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelProvider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageConfiguration_KmsKeyArn = this.StorageConfiguration_KmsKeyArn;
            context.StorageConfiguration_S3BucketArn = this.StorageConfiguration_S3BucketArn;
            context.StorageConfiguration_S3BucketOwner = this.StorageConfiguration_S3BucketOwner;
            context.StorageDestination = this.StorageDestination;
            #if MODULAR
            if (this.StorageDestination == null && ParameterWasBound(nameof(this.StorageDestination)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageDestination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageRequest();
            
            if (cmdletContext.ModelProvider != null)
            {
                request.ModelProvider = cmdletContext.ModelProvider;
            }
            
             // populate StorageConfiguration
            var requestStorageConfigurationIsNull = true;
            request.StorageConfiguration = new Amazon.Bedrock.Model.DataRetentionStorageConfiguration();
            System.String requestStorageConfiguration_storageConfiguration_KmsKeyArn = null;
            if (cmdletContext.StorageConfiguration_KmsKeyArn != null)
            {
                requestStorageConfiguration_storageConfiguration_KmsKeyArn = cmdletContext.StorageConfiguration_KmsKeyArn;
            }
            if (requestStorageConfiguration_storageConfiguration_KmsKeyArn != null)
            {
                request.StorageConfiguration.KmsKeyArn = requestStorageConfiguration_storageConfiguration_KmsKeyArn;
                requestStorageConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_S3BucketArn = null;
            if (cmdletContext.StorageConfiguration_S3BucketArn != null)
            {
                requestStorageConfiguration_storageConfiguration_S3BucketArn = cmdletContext.StorageConfiguration_S3BucketArn;
            }
            if (requestStorageConfiguration_storageConfiguration_S3BucketArn != null)
            {
                request.StorageConfiguration.S3BucketArn = requestStorageConfiguration_storageConfiguration_S3BucketArn;
                requestStorageConfigurationIsNull = false;
            }
            System.String requestStorageConfiguration_storageConfiguration_S3BucketOwner = null;
            if (cmdletContext.StorageConfiguration_S3BucketOwner != null)
            {
                requestStorageConfiguration_storageConfiguration_S3BucketOwner = cmdletContext.StorageConfiguration_S3BucketOwner;
            }
            if (requestStorageConfiguration_storageConfiguration_S3BucketOwner != null)
            {
                request.StorageConfiguration.S3BucketOwner = requestStorageConfiguration_storageConfiguration_S3BucketOwner;
                requestStorageConfigurationIsNull = false;
            }
             // determine if request.StorageConfiguration should be set to null
            if (requestStorageConfigurationIsNull)
            {
                request.StorageConfiguration = null;
            }
            if (cmdletContext.StorageDestination != null)
            {
                request.StorageDestination = cmdletContext.StorageDestination;
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
        
        private Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "PutOrganizationDataRetentionStorage");
            try
            {
                return client.PutOrganizationDataRetentionStorageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Bedrock.DataRetentionStorageModelProvider ModelProvider { get; set; }
            public System.String StorageConfiguration_KmsKeyArn { get; set; }
            public System.String StorageConfiguration_S3BucketArn { get; set; }
            public System.String StorageConfiguration_S3BucketOwner { get; set; }
            public Amazon.Bedrock.DataRetentionStorageDestination StorageDestination { get; set; }
            public System.Func<Amazon.Bedrock.Model.PutOrganizationDataRetentionStorageResponse, WriteBDROrganizationDataRetentionStorageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
