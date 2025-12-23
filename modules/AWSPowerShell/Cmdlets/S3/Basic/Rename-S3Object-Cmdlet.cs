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
using Amazon.S3;
using Amazon.S3.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Renames an existing object in a directory bucket that uses the S3 Express One Zone
    /// storage class. You can use <c>RenameObject</c> by specifying an existing object’s
    /// name as the source and the new name of the object as the destination within the same
    /// directory bucket.
    /// 
    ///  <note><para><c>RenameObject</c> is only supported for objects stored in the S3 Express One Zone
    /// storage class.
    /// </para></note><para>
    ///  To prevent overwriting an object, you can use the <c>If-None-Match</c> conditional
    /// header.
    /// </para><ul><li><para><b>If-None-Match</b> - Renames the object only if an object with the specified name
    /// does not already exist in the directory bucket. If you don't want to overwrite an
    /// existing object, you can add the <c>If-None-Match</c> conditional header with the
    /// value <c>‘*’</c> in the <c>RenameObject</c> request. Amazon S3 then returns a <c>412
    /// Precondition Failed</c> error if the object with the specified name already exists.
    /// For more information, see <a href="https://datatracker.ietf.org/doc/rfc7232/">RFC
    /// 7232</a>.
    /// </para></li></ul><dl><dt>Permissions</dt><dd><para>
    ///  To grant access to the <c>RenameObject</c> operation on a directory bucket, we recommend
    /// that you use the <c>CreateSession</c> operation for session-based authorization. Specifically,
    /// you grant the <c>s3express:CreateSession</c> permission to the directory bucket in
    /// a bucket policy or an IAM identity-based policy. Then, you make the <c>CreateSession</c>
    /// API call on the directory bucket to obtain a session token. With the session token
    /// in your request header, you can make API requests to this operation. After the session
    /// token expires, you make another <c>CreateSession</c> API call to generate a new session
    /// token for use. The Amazon Web Services CLI and SDKs will create and manage your session
    /// including refreshing the session token automatically to avoid service interruptions
    /// when a session expires. In your bucket policy, you can specify the <c>s3express:SessionMode</c>
    /// condition key to control who can create a <c>ReadWrite</c> or <c>ReadOnly</c> session.
    /// A <c>ReadWrite</c> session is required for executing all the Zonal endpoint API operations,
    /// including <c>RenameObject</c>. For more information about authorization, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html"><c>CreateSession</c></a>. To learn more about Zonal endpoint API operations, see
    /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-create-session.html">Authorizing
    /// Zonal endpoint API operations with CreateSession</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    /// </para></dd><dt>HTTP Host header syntax</dt><dd><para><b>Directory buckets </b> - The HTTP Host header syntax is <c><i>Bucket-name</i>.s3express-<i>zone-id</i>.<i>region-code</i>.amazonaws.com</c>.
    /// </para></dd></dl><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Rename", "S3Object", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) RenameObject API operation.", Operation = new[] {"RenameObject"}, SelectReturnType = typeof(Amazon.S3.Model.RenameObjectResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.RenameObjectResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.RenameObjectResponse) be returned by specifying '-Select *'."
    )]
    public partial class RenameS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name of the directory bucket containing the object.</para><para> You must use virtual-hosted-style requests in the format <c>Bucket-name.s3express-zone-id.region-code.amazonaws.com</c>.
        /// Path-style requests are not supported. Directory bucket names must be unique in the
        /// chosen Availability Zone. Bucket names must follow the format <c>bucket-base-name--zone-id--x-s3
        /// </c> (for example, <c>amzn-s3-demo-bucket--usw2-az1--x-s3</c>). For information about
        /// bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
        /// bucket naming rules</a> in the <i>Amazon S3 User Guide</i>.</para>
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
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter DestinationIfMatch
        /// <summary>
        /// <para>
        /// <para>Renames the object only if the ETag (entity tag) value provided during the operation
        /// matches the ETag of the object in S3. The <c>If-Match</c> header field makes the request
        /// method conditional on ETags. If the ETag values do not match, the operation returns
        /// a <c>412 Precondition Failed</c> error.</para><para>Expects the ETag value as a string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationIfMatch { get; set; }
        #endregion
        
        #region Parameter DestinationIfModifiedSince
        /// <summary>
        /// <para>
        /// <para>Renames the object if the destination exists and if it has been modified since the
        /// specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DestinationIfModifiedSince { get; set; }
        #endregion
        
        #region Parameter DestinationIfNoneMatch
        /// <summary>
        /// <para>
        /// <para> Renames the object only if the destination does not already exist in the specified
        /// directory bucket. If the object does exist when you send a request with <c>If-None-Match:*</c>,
        /// the S3 API will return a <c>412 Precondition Failed</c> error, preventing an overwrite.
        /// The <c>If-None-Match</c> header prevents overwrites of existing data by validating
        /// that there's not an object with the same key name already in your directory bucket.</para><para> Expects the <c>*</c> character (asterisk).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationIfNoneMatch { get; set; }
        #endregion
        
        #region Parameter DestinationIfUnmodifiedSince
        /// <summary>
        /// <para>
        /// <para>Renames the object if it hasn't been modified since the specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DestinationIfUnmodifiedSince { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>Key name of the object to rename.</para>
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
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter RenameSource
        /// <summary>
        /// <para>
        /// <para>Specifies the source for the rename operation. The value must be URL encoded.</para>
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
        public System.String RenameSource { get; set; }
        #endregion
        
        #region Parameter SourceIfMatch
        /// <summary>
        /// <para>
        /// <para>Renames the object if the source exists and if its entity tag (ETag) matches the specified
        /// ETag. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceIfMatch { get; set; }
        #endregion
        
        #region Parameter SourceIfModifiedSince
        /// <summary>
        /// <para>
        /// <para>Renames the object if the source exists and if it has been modified since the specified
        /// time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SourceIfModifiedSince { get; set; }
        #endregion
        
        #region Parameter SourceIfNoneMatch
        /// <summary>
        /// <para>
        /// <para>Renames the object if the source exists and if its entity tag (ETag) is different
        /// than the specified ETag. If an asterisk (<c>*</c>) character is provided, the operation
        /// will fail and return a <c>412 Precondition Failed</c> error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceIfNoneMatch { get; set; }
        #endregion
        
        #region Parameter SourceIfUnmodifiedSince
        /// <summary>
        /// <para>
        /// <para>Renames the object if the source exists and hasn't been modified since the specified
        /// time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SourceIfUnmodifiedSince { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique string with a max of 64 ASCII characters in the ASCII range of 33 - 126.</para><note><para><c>RenameObject</c> supports idempotency using a client token. To make an idempotent
        /// API request using <c>RenameObject</c>, specify a client token in the request. You
        /// should not reuse the same client token for other API requests. If you retry a request
        /// that completed successfully using the same client token and the same parameters, the
        /// retry succeeds without performing any further actions. If you retry a successful request
        /// using the same client token, but one or more of the parameters are different, the
        /// retry fails and an <c>IdempotentParameterMismatch</c> error is returned. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.RenameObjectResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Rename-S3Object (RenameObject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.RenameObjectResponse, RenameS3ObjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            #if MODULAR
            if (this.BucketName == null && ParameterWasBound(nameof(this.BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DestinationIfMatch = this.DestinationIfMatch;
            context.DestinationIfModifiedSince = this.DestinationIfModifiedSince;
            context.DestinationIfNoneMatch = this.DestinationIfNoneMatch;
            context.DestinationIfUnmodifiedSince = this.DestinationIfUnmodifiedSince;
            context.Key = this.Key;
            #if MODULAR
            if (this.Key == null && ParameterWasBound(nameof(this.Key)))
            {
                WriteWarning("You are passing $null as a value for parameter Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RenameSource = this.RenameSource;
            #if MODULAR
            if (this.RenameSource == null && ParameterWasBound(nameof(this.RenameSource)))
            {
                WriteWarning("You are passing $null as a value for parameter RenameSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceIfMatch = this.SourceIfMatch;
            context.SourceIfModifiedSince = this.SourceIfModifiedSince;
            context.SourceIfNoneMatch = this.SourceIfNoneMatch;
            context.SourceIfUnmodifiedSince = this.SourceIfUnmodifiedSince;
            
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
            var request = new Amazon.S3.Model.RenameObjectRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DestinationIfMatch != null)
            {
                request.DestinationIfMatch = cmdletContext.DestinationIfMatch;
            }
            if (cmdletContext.DestinationIfModifiedSince != null)
            {
                request.DestinationIfModifiedSince = cmdletContext.DestinationIfModifiedSince.Value;
            }
            if (cmdletContext.DestinationIfNoneMatch != null)
            {
                request.DestinationIfNoneMatch = cmdletContext.DestinationIfNoneMatch;
            }
            if (cmdletContext.DestinationIfUnmodifiedSince != null)
            {
                request.DestinationIfUnmodifiedSince = cmdletContext.DestinationIfUnmodifiedSince.Value;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.RenameSource != null)
            {
                request.RenameSource = cmdletContext.RenameSource;
            }
            if (cmdletContext.SourceIfMatch != null)
            {
                request.SourceIfMatch = cmdletContext.SourceIfMatch;
            }
            if (cmdletContext.SourceIfModifiedSince != null)
            {
                request.SourceIfModifiedSince = cmdletContext.SourceIfModifiedSince.Value;
            }
            if (cmdletContext.SourceIfNoneMatch != null)
            {
                request.SourceIfNoneMatch = cmdletContext.SourceIfNoneMatch;
            }
            if (cmdletContext.SourceIfUnmodifiedSince != null)
            {
                request.SourceIfUnmodifiedSince = cmdletContext.SourceIfUnmodifiedSince.Value;
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
        
        private Amazon.S3.Model.RenameObjectResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.RenameObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "RenameObject");
            try
            {
                return client.RenameObjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DestinationIfMatch { get; set; }
            public System.DateTime? DestinationIfModifiedSince { get; set; }
            public System.String DestinationIfNoneMatch { get; set; }
            public System.DateTime? DestinationIfUnmodifiedSince { get; set; }
            public System.String Key { get; set; }
            public System.String RenameSource { get; set; }
            public System.String SourceIfMatch { get; set; }
            public System.DateTime? SourceIfModifiedSince { get; set; }
            public System.String SourceIfNoneMatch { get; set; }
            public System.DateTime? SourceIfUnmodifiedSince { get; set; }
            public System.Func<Amazon.S3.Model.RenameObjectResponse, RenameS3ObjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
