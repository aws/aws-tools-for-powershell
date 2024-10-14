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
    /// <note><para>
    /// This operation is not supported by directory buckets.
    /// </para></note><note><para>
    /// When you enable versioning on a bucket for the first time, it might take a short amount
    /// of time for the change to be fully propagated. We recommend that you wait for 15 minutes
    /// after enabling versioning before issuing write operations (<c>PUT</c> or <c>DELETE</c>)
    /// on objects in the bucket. 
    /// </para></note><para>
    /// Sets the versioning state of an existing bucket.
    /// </para><para>
    /// You can set the versioning state with one of the following values:
    /// </para><para><b>Enabled</b>—Enables versioning for the objects in the bucket. All objects added
    /// to the bucket receive a unique version ID.
    /// </para><para><b>Suspended</b>—Disables versioning for the objects in the bucket. All objects added
    /// to the bucket receive the version ID null.
    /// </para><para>
    /// If the versioning state has never been set on a bucket, it has no versioning state;
    /// a <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketVersioning.html">GetBucketVersioning</a>
    /// request does not return a versioning state value.
    /// </para><para>
    /// In order to enable MFA Delete, you must be the bucket owner. If you are the bucket
    /// owner and want to enable MFA Delete in the bucket versioning configuration, you must
    /// include the <c>x-amz-mfa request</c> header and the <c>Status</c> and the <c>MfaDelete</c>
    /// request elements in a request to set the versioning state of the bucket.
    /// </para><important><para>
    /// If you have an object expiration lifecycle configuration in your non-versioned bucket
    /// and you want to maintain the same permanent delete behavior when you enable versioning,
    /// you must add a noncurrent expiration policy. The noncurrent expiration lifecycle configuration
    /// will manage the deletes of the noncurrent object versions in the version-enabled bucket.
    /// (A version-enabled bucket maintains one current and zero or more noncurrent object
    /// versions.) For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/object-lifecycle-mgmt.html#lifecycle-and-other-bucket-config">Lifecycle
    /// and Versioning</a>.
    /// </para></important><para>
    /// The following operations are related to <c>PutBucketVersioning</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucket.html">CreateBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucket.html">DeleteBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketVersioning.html">GetBucketVersioning</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3BucketVersioning", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketVersioning API operation.", Operation = new[] {"PutBucketVersioning"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketVersioningResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketVersioningResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketVersioningResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3BucketVersioningCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MfaCodes_AuthenticationValue
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MfaCodes_AuthenticationValue { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket to be updated.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>Indicates the algorithm used to create the checksum for the object when you use the
        /// SDK. This header will not provide any additional functionality if you don't use the
        /// SDK. When you send this header, there must be a corresponding <code>x-amz-checksum</code>
        /// or <code>x-amz-trailer</code> header sent. Otherwise, Amazon S3 fails the request
        /// with the HTTP status code <code>400 Bad Request</code>. For more information, see
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">Checking
        /// object integrity</a> in the <i>Amazon S3 User Guide</i>.</para><para>If you provide an individual checksum, Amazon S3 ignores any provided <code>ChecksumAlgorithm</code>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter VersioningConfig_EnableMfaDelete
        /// <summary>
        /// <para>
        /// Specifies whether MFA Delete is enabled on this S3 Bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? VersioningConfig_EnableMfaDelete { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <code>403 Forbidden</code> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter MfaCodes_SerialNumber
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MfaCodes_SerialNumber { get; set; }
        #endregion
        
        #region Parameter VersioningConfig_Status
        /// <summary>
        /// <para>
        /// Versioning status for the bucket.
        /// Accepted values: Off, Enabled, Suspended.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.VersionStatus")]
        public Amazon.S3.VersionStatus VersioningConfig_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketVersioningResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketVersioning (PutBucketVersioning)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketVersioningResponse, WriteS3BucketVersioningCmdlet>(Select) ??
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
            context.MfaCodes_SerialNumber = this.MfaCodes_SerialNumber;
            context.MfaCodes_AuthenticationValue = this.MfaCodes_AuthenticationValue;
            context.VersioningConfig_EnableMfaDelete = this.VersioningConfig_EnableMfaDelete;
            context.VersioningConfig_Status = this.VersioningConfig_Status;
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
            var request = new Amazon.S3.Model.PutBucketVersioningRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            
             // populate MfaCodes
            var requestMfaCodesIsNull = true;
            request.MfaCodes = new Amazon.S3.Model.MfaCodes();
            System.String requestMfaCodes_mfaCodes_SerialNumber = null;
            if (cmdletContext.MfaCodes_SerialNumber != null)
            {
                requestMfaCodes_mfaCodes_SerialNumber = cmdletContext.MfaCodes_SerialNumber;
            }
            if (requestMfaCodes_mfaCodes_SerialNumber != null)
            {
                request.MfaCodes.SerialNumber = requestMfaCodes_mfaCodes_SerialNumber;
                requestMfaCodesIsNull = false;
            }
            System.String requestMfaCodes_mfaCodes_AuthenticationValue = null;
            if (cmdletContext.MfaCodes_AuthenticationValue != null)
            {
                requestMfaCodes_mfaCodes_AuthenticationValue = cmdletContext.MfaCodes_AuthenticationValue;
            }
            if (requestMfaCodes_mfaCodes_AuthenticationValue != null)
            {
                request.MfaCodes.AuthenticationValue = requestMfaCodes_mfaCodes_AuthenticationValue;
                requestMfaCodesIsNull = false;
            }
             // determine if request.MfaCodes should be set to null
            if (requestMfaCodesIsNull)
            {
                request.MfaCodes = null;
            }
            
             // populate VersioningConfig
            var requestVersioningConfigIsNull = true;
            request.VersioningConfig = new Amazon.S3.Model.S3BucketVersioningConfig();
            System.Boolean? requestVersioningConfig_versioningConfig_EnableMfaDelete = null;
            if (cmdletContext.VersioningConfig_EnableMfaDelete != null)
            {
                requestVersioningConfig_versioningConfig_EnableMfaDelete = cmdletContext.VersioningConfig_EnableMfaDelete.Value;
            }
            if (requestVersioningConfig_versioningConfig_EnableMfaDelete != null)
            {
                request.VersioningConfig.EnableMfaDelete = requestVersioningConfig_versioningConfig_EnableMfaDelete.Value;
                requestVersioningConfigIsNull = false;
            }
            Amazon.S3.VersionStatus requestVersioningConfig_versioningConfig_Status = null;
            if (cmdletContext.VersioningConfig_Status != null)
            {
                requestVersioningConfig_versioningConfig_Status = cmdletContext.VersioningConfig_Status;
            }
            if (requestVersioningConfig_versioningConfig_Status != null)
            {
                request.VersioningConfig.Status = requestVersioningConfig_versioningConfig_Status;
                requestVersioningConfigIsNull = false;
            }
             // determine if request.VersioningConfig should be set to null
            if (requestVersioningConfigIsNull)
            {
                request.VersioningConfig = null;
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
        
        private Amazon.S3.Model.PutBucketVersioningResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketVersioningRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketVersioning");
            try
            {
                #if DESKTOP
                return client.PutBucketVersioning(request);
                #elif CORECLR
                return client.PutBucketVersioningAsync(request).GetAwaiter().GetResult();
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
            public System.String MfaCodes_SerialNumber { get; set; }
            public System.String MfaCodes_AuthenticationValue { get; set; }
            public System.Boolean? VersioningConfig_EnableMfaDelete { get; set; }
            public Amazon.S3.VersionStatus VersioningConfig_Status { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketVersioningResponse, WriteS3BucketVersioningCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
