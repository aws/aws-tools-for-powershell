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
    /// Returns the default encryption configuration for an Amazon S3 bucket. By default,
    /// all buckets have a default encryption configuration that uses server-side encryption
    /// with Amazon S3 managed keys (SSE-S3). 
    /// 
    ///  <note><ul><li><para><b>General purpose buckets</b> - For information about the bucket default encryption
    /// feature, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/bucket-encryption.html">Amazon
    /// S3 Bucket Default Encryption</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></li><li><para><b>Directory buckets</b> - For directory buckets, there are only two supported options
    /// for server-side encryption: SSE-S3 and SSE-KMS. For information about the default
    /// encryption configuration in directory buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-bucket-encryption.html">Setting
    /// default server-side encryption behavior for directory buckets</a>.
    /// </para></li></ul></note><dl><dt>Permissions</dt><dd><ul><li><para><b>General purpose bucket permissions</b> - The <c>s3:GetEncryptionConfiguration</c>
    /// permission is required in a policy. The bucket owner has this permission by default.
    /// The bucket owner can grant this permission to others. For more information about permissions,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-with-s3-actions.html#using-with-s3-actions-related-to-bucket-subresources">Permissions
    /// Related to Bucket Operations</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-access-control.html">Managing
    /// Access Permissions to Your Amazon S3 Resources</a>.
    /// </para></li><li><para><b>Directory bucket permissions</b> - To grant access to this API operation, you
    /// must have the <c>s3express:GetEncryptionConfiguration</c> permission in an IAM identity-based
    /// policy instead of a bucket policy. Cross-account access to this API operation isn't
    /// supported. This operation can only be performed by the Amazon Web Services account
    /// that owns the resource. For more information about directory bucket policies and permissions,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-security-iam.html">Amazon
    /// Web Services Identity and Access Management (IAM) for S3 Express One Zone</a> in the
    /// <i>Amazon S3 User Guide</i>.
    /// </para></li></ul></dd><dt>HTTP Host header syntax</dt><dd><para><b>Directory buckets </b> - The HTTP Host header syntax is <c>s3express-control.<i>region-code</i>.amazonaws.com</c>.
    /// </para></dd></dl><para>
    /// The following operations are related to <c>GetBucketEncryption</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketEncryption.html">PutBucketEncryption</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketEncryption.html">DeleteBucketEncryption</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "S3BucketEncryption")]
    [OutputType("Amazon.S3.Model.ServerSideEncryptionConfiguration")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) GetBucketEncryption API operation.", Operation = new[] {"GetBucketEncryption"}, SelectReturnType = typeof(Amazon.S3.Model.GetBucketEncryptionResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.ServerSideEncryptionConfiguration or Amazon.S3.Model.GetBucketEncryptionResponse",
        "This cmdlet returns an Amazon.S3.Model.ServerSideEncryptionConfiguration object.",
        "The service call response (type Amazon.S3.Model.GetBucketEncryptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3BucketEncryptionCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket from which the server-side encryption configuration is retrieved.</para><para><b>Directory buckets </b> - When you use this operation with a directory bucket, you must use path-style requests 
        /// in the format <c>https://s3express-control.<i>region_code</i>.amazonaws.com/<i>bucket-name</i></c>. 
        /// 
        /// Virtual-hosted-style requests aren't supported. 
        /// Directory bucket names must be unique in the chosen Availability Zone. 
        /// Bucket names must also follow the format <c><i>bucket_base_name</i>--<i>az_id</i>--x-s3</c> (for example, <c><i>DOC-EXAMPLE-BUCKET</i>--<i>usw2-az1</i>--x-s3</c>). 
        /// 
        /// For information about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory bucket naming rules</a> 
        /// in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <c>403 Forbidden</c> (access denied).</para><para>For directory buckets, this header is not supported in this API operation. 
        /// If you specify this header, the request fails with the HTTP status code <c>501 Not Implemented</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerSideEncryptionConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.GetBucketEncryptionResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.GetBucketEncryptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerSideEncryptionConfiguration";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.GetBucketEncryptionResponse, GetS3BucketEncryptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
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
            var request = new Amazon.S3.Model.GetBucketEncryptionRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
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
        
        private Amazon.S3.Model.GetBucketEncryptionResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.GetBucketEncryptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "GetBucketEncryption");
            try
            {
                #if DESKTOP
                return client.GetBucketEncryption(request);
                #elif CORECLR
                return client.GetBucketEncryptionAsync(request).GetAwaiter().GetResult();
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
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.GetBucketEncryptionResponse, GetS3BucketEncryptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerSideEncryptionConfiguration;
        }
        
    }
}
