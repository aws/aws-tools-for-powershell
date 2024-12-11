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
    /// </para></note><para>
    /// Returns a list of all buckets owned by the authenticated sender of the request. To
    /// use this operation, you must have the <c>s3:ListAllMyBuckets</c> permission. 
    /// </para><para>
    /// For information about Amazon S3 buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html">Creating,
    /// configuring, and working with Amazon S3 buckets</a>.
    /// </para><important><para>
    /// We strongly recommend using only paginated requests. Unpaginated requests are only
    /// supported for Amazon Web Services accounts set to the default general purpose bucket
    /// quota of 10,000. If you have an approved general purpose bucket quota above 10,000,
    /// you must send paginated requests to list your account’s buckets. All unpaginated ListBuckets
    /// requests will be rejected for Amazon Web Services accounts with a general purpose
    /// bucket quota greater than 10,000. 
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "S3Bucket")]
    [OutputType("Amazon.S3.Model.S3Bucket")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) ListBuckets API operation.", Operation = new[] {"ListBuckets"}, SelectReturnType = typeof(Amazon.S3.Model.ListBucketsResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.S3Bucket or Amazon.S3.Model.ListBucketsResponse",
        "This cmdlet returns a collection of Amazon.S3.Model.S3Bucket objects.",
        "The service call response (type Amazon.S3.Model.ListBucketsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3BucketCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketRegion
        /// <summary>
        /// <para>
        /// <para>Limits the response to buckets that are located in the specified Amazon Web Services region.</para><note><para>Requests made to an endpoint in a region that is different from the bucket-region parameter are not supported. For example, if you want to limit the response to your buckets in us-west-2 region, the request must be made to an endpoint in us-west-2.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BucketRegion { get; set; }
        #endregion
        
        #region Parameter ContinuationToken
        /// <summary>
        /// <para>
        /// <para><c>ContinuationToken</c> indicates to Amazon S3 that the list is being continued on this bucket with a token. 
        /// <c>ContinuationToken</c> is obfuscated and is not a real key. You can use this <c>ContinuationToken</c> for pagination of the list results. </para><para>Length Constraints: Minimum length of 0. Maximum length of 1024.</para><para>Required: No.</para><note><para>If you specify the <c>bucket-region</c>, <c>prefix</c>, or <c>continuation-token</c> query parameters without using <c>max-buckets</c> 
        /// to set the maximum number of buckets returned in the response, Amazon S3 applies a default page size of 10,000 and provides a continuation token if there are more buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContinuationToken { get; set; }
        #endregion
        
        #region Parameter MaxBucket
        /// <summary>
        /// <para>
        /// <para>Maximum number of buckets to be returned in response. When the number is more than the count of buckets that are
        /// owned by an Amazon Web Services account, return all the buckets in response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxBuckets")]
        public System.Int32? MaxBucket { get; set; }
        #endregion
        
        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// Limits the response to bucket names that begin with the specified bucket name prefix.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Prefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Buckets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.ListBucketsResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.ListBucketsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Buckets";
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
                context.Select = CreateSelectDelegate<Amazon.S3.Model.ListBucketsResponse, GetS3BucketCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContinuationToken = this.ContinuationToken;
            context.MaxBucket = this.MaxBucket;
            context.Prefix = this.Prefix;
            context.BucketRegion = this.BucketRegion;
            
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
            var request = new Amazon.S3.Model.ListBucketsRequest();
            
            if (cmdletContext.ContinuationToken != null)
            {
                request.ContinuationToken = cmdletContext.ContinuationToken;
            }
            if (cmdletContext.MaxBucket != null)
            {
                request.MaxBuckets = cmdletContext.MaxBucket.Value;
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            if (cmdletContext.BucketRegion != null)
            {
                request.BucketRegion = cmdletContext.BucketRegion;
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
        
        private Amazon.S3.Model.ListBucketsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListBucketsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "ListBuckets");
            try
            {
                #if DESKTOP
                return client.ListBuckets(request);
                #elif CORECLR
                return client.ListBucketsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxBucket { get; set; }
            public System.String Prefix { get; set; }
            public System.String BucketRegion { get; set; }
            public System.Func<Amazon.S3.Model.ListBucketsResponse, GetS3BucketCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Buckets;
        }
        
    }
}
