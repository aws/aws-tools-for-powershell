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
    /// Returns a list of all Amazon S3 directory buckets owned by the authenticated sender
    /// of the request. For more information about directory buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-buckets-overview.html">Directory
    /// buckets</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    ///  <note><para><b>Directory buckets </b> - For directory buckets, you must make requests for this
    /// API operation to the Regional endpoint. These endpoints support path-style requests
    /// in the format <c>https://s3express-control.<i>region-code</i>.amazonaws.com/<i>bucket-name</i></c>. Virtual-hosted-style requests aren't supported. For more information about endpoints
    /// in Availability Zones, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-Regions-and-Zones.html">Regional
    /// and Zonal endpoints for directory buckets in Availability Zones</a> in the <i>Amazon
    /// S3 User Guide</i>. For more information about endpoints in Local Zones, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-lzs-for-directory-buckets.html">Available
    /// Local Zone for directory buckets</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></note><dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3express:ListAllMyDirectoryBuckets</c> permission in an IAM
    /// identity-based policy instead of a bucket policy. Cross-account access to this API
    /// operation isn't supported. This operation can only be performed by the Amazon Web
    /// Services account that owns the resource. For more information about directory bucket
    /// policies and permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-security-iam.html">Amazon
    /// Web Services Identity and Access Management (IAM) for S3 Express One Zone</a> in the
    /// <i>Amazon S3 User Guide</i>.
    /// </para></dd><dt>HTTP Host header syntax</dt><dd><para><b>Directory buckets </b> - The HTTP Host header syntax is <c>s3express-control.<i>region</i>.amazonaws.com</c>.
    /// </para></dd></dl><note><para>
    ///  The <c>BucketRegion</c> response element is not part of the <c>ListDirectoryBuckets</c>
    /// Response Syntax.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "S3DirectoryBucket")]
    [OutputType("Amazon.S3.Model.ListDirectoryBucketsResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) ListDirectoryBuckets API operation.", Operation = new[] {"ListDirectoryBuckets"}, SelectReturnType = typeof(Amazon.S3.Model.ListDirectoryBucketsResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.ListDirectoryBucketsResponse",
        "This cmdlet returns an Amazon.S3.Model.ListDirectoryBucketsResponse object containing multiple properties."
    )]
    public partial class GetS3DirectoryBucketCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContinuationToken
        /// <summary>
        /// <para>
        /// <para><code>ContinuationToken</code> indicates to Amazon S3 that the list is being continued
        /// on this bucket with a token. <code>ContinuationToken</code> is obfuscated and is not
        /// a real key. You can use this <code>ContinuationToken</code> for pagination of the
        /// list results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContinuationToken { get; set; }
        #endregion
        
        #region Parameter MaxDirectoryBucket
        /// <summary>
        /// <para>
        /// <para>Maximum number of buckets to be returned in response. When the number is more than
        /// the count of buckets that are owned by an Amazon Web Services account, return all
        /// the buckets in response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxDirectoryBuckets")]
        public System.Int32? MaxDirectoryBucket { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.ListDirectoryBucketsResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.ListDirectoryBucketsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.S3.Model.ListDirectoryBucketsResponse, GetS3DirectoryBucketCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContinuationToken = this.ContinuationToken;
            context.MaxDirectoryBucket = this.MaxDirectoryBucket;
            
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
            var request = new Amazon.S3.Model.ListDirectoryBucketsRequest();
            
            if (cmdletContext.ContinuationToken != null)
            {
                request.ContinuationToken = cmdletContext.ContinuationToken;
            }
            if (cmdletContext.MaxDirectoryBucket != null)
            {
                request.MaxDirectoryBuckets = cmdletContext.MaxDirectoryBucket.Value;
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
        
        private Amazon.S3.Model.ListDirectoryBucketsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListDirectoryBucketsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "ListDirectoryBuckets");
            try
            {
                #if DESKTOP
                return client.ListDirectoryBuckets(request);
                #elif CORECLR
                return client.ListDirectoryBucketsAsync(request).GetAwaiter().GetResult();
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
            public System.String ContinuationToken { get; set; }
            public System.Int32? MaxDirectoryBucket { get; set; }
            public System.Func<Amazon.S3.Model.ListDirectoryBucketsResponse, GetS3DirectoryBucketCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
