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
    /// including <c>RenameObject</c>. For more information about authorization, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html"><c>CreateSession</c></a>. To learn more about Zonal endpoint APT operations, see
    /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-create-session.html">Authorizing
    /// Zonal endpoint API operations with CreateSession</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    /// </para></dd><dt>HTTP Host header syntax</dt><dd><para><b>Directory buckets </b> - The HTTP Host header syntax is <c><i>Bucket-name</i>.s3express-<i>zone-id</i>.<i>region-code</i>.amazonaws.com</c>.
    /// </para></dd></dl>
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
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket in which the object or directory will be renamed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter DestinationIfMatch
        /// <summary>
        /// <para>
        /// <para>If the specified entity tag (ETag) matches the destination object's ETag, Amazon S3
        /// will process the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationIfMatch { get; set; }
        #endregion
        
        #region Parameter DestinationIfModifiedSince
        /// <summary>
        /// <para>
        /// <para>If the destination object was modified after the specified time, Amazon S3 will process
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DestinationIfModifiedSince { get; set; }
        #endregion
        
        #region Parameter DestinationIfNoneMatch
        /// <summary>
        /// <para>
        /// <para>If the specified entity tag (ETag) does not match the destination object's ETag, Amazon S3
        /// will process the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationIfNoneMatch { get; set; }
        #endregion
        
        #region Parameter DestinationIfUnmodifiedSince
        /// <summary>
        /// <para>
        /// <para>If the destination object was not modified after the specified time, Amazon S3 will process
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DestinationIfUnmodifiedSince { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The new key name (full path) for the object or directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter RenameSource
        /// <summary>
        /// <para>
        /// <para>The key name (full path) of the source object or directory to be renamed. It must be URL-encoded.</para><para>Format: /bucket-name/object-key</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RenameSource { get; set; }
        #endregion
        
        #region Parameter SourceIfMatch
        /// <summary>
        /// <para>
        /// <para>If the specified entity tag (ETag) matches the source object's ETag, Amazon S3
        /// will process the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceIfMatch { get; set; }
        #endregion
        
        #region Parameter SourceIfModifiedSince
        /// <summary>
        /// <para>
        /// <para>If the source object was modified after the specified time, Amazon S3 will process
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SourceIfModifiedSince { get; set; }
        #endregion
        
        #region Parameter SourceIfNoneMatch
        /// <summary>
        /// <para>
        /// <para>If the specified entity tag (ETag) does not match the source object's ETag, Amazon S3
        /// will process the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceIfNoneMatch { get; set; }
        #endregion
        
        #region Parameter SourceIfUnmodifiedSince
        /// <summary>
        /// <para>
        /// <para>If the source object was not modified after the specified time, Amazon S3 will process
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SourceIfUnmodifiedSince { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token to ensure that the rename request is idempotent. It's suitable to use the same client token
        /// across multiple requests when you're retrying a failed operation.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Rename-S3Object (RenameObject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.RenameObjectResponse, RenameS3ObjectCmdlet>(Select) ??
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
            context.Key = this.Key;
            context.RenameSource = this.RenameSource;
            context.DestinationIfMatch = this.DestinationIfMatch;
            context.DestinationIfNoneMatch = this.DestinationIfNoneMatch;
            context.DestinationIfModifiedSince = this.DestinationIfModifiedSince;
            context.DestinationIfUnmodifiedSince = this.DestinationIfUnmodifiedSince;
            context.SourceIfMatch = this.SourceIfMatch;
            context.SourceIfNoneMatch = this.SourceIfNoneMatch;
            context.SourceIfModifiedSince = this.SourceIfModifiedSince;
            context.SourceIfUnmodifiedSince = this.SourceIfUnmodifiedSince;
            context.ClientToken = this.ClientToken;
            
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
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.RenameSource != null)
            {
                request.RenameSource = cmdletContext.RenameSource;
            }
            if (cmdletContext.DestinationIfMatch != null)
            {
                request.DestinationIfMatch = cmdletContext.DestinationIfMatch;
            }
            if (cmdletContext.DestinationIfNoneMatch != null)
            {
                request.DestinationIfNoneMatch = cmdletContext.DestinationIfNoneMatch;
            }
            if (cmdletContext.DestinationIfModifiedSince != null)
            {
                request.DestinationIfModifiedSince = cmdletContext.DestinationIfModifiedSince.Value;
            }
            if (cmdletContext.DestinationIfUnmodifiedSince != null)
            {
                request.DestinationIfUnmodifiedSince = cmdletContext.DestinationIfUnmodifiedSince.Value;
            }
            if (cmdletContext.SourceIfMatch != null)
            {
                request.SourceIfMatch = cmdletContext.SourceIfMatch;
            }
            if (cmdletContext.SourceIfNoneMatch != null)
            {
                request.SourceIfNoneMatch = cmdletContext.SourceIfNoneMatch;
            }
            if (cmdletContext.SourceIfModifiedSince != null)
            {
                request.SourceIfModifiedSince = cmdletContext.SourceIfModifiedSince.Value;
            }
            if (cmdletContext.SourceIfUnmodifiedSince != null)
            {
                request.SourceIfUnmodifiedSince = cmdletContext.SourceIfUnmodifiedSince.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
                #if DESKTOP
                return client.RenameObject(request);
                #elif CORECLR
                return client.RenameObjectAsync(request).GetAwaiter().GetResult();
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
            public System.String Key { get; set; }
            public System.String RenameSource { get; set; }
            public System.String DestinationIfMatch { get; set; }
            public System.String DestinationIfNoneMatch { get; set; }
            public System.DateTime? DestinationIfModifiedSince { get; set; }
            public System.DateTime? DestinationIfUnmodifiedSince { get; set; }
            public System.String SourceIfMatch { get; set; }
            public System.String SourceIfNoneMatch { get; set; }
            public System.DateTime? SourceIfModifiedSince { get; set; }
            public System.DateTime? SourceIfUnmodifiedSince { get; set; }
            public System.String ClientToken { get; set; }
            public System.Func<Amazon.S3.Model.RenameObjectResponse, RenameS3ObjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
