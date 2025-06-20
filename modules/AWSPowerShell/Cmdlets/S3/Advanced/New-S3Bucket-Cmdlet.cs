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
using System.Management.Automation;
using System.Threading;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Creates a new bucket with the supplied name and permissions.
    /// </summary>
    [Cmdlet("New", "S3Bucket", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low)]
    [OutputType("Amazon.S3.Model.S3Bucket")]
    [AWSCmdlet("Creates a new bucket in Amazon S3.", Operation = new [] {"PutBucket"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.S3Bucket or Amazon.S3.Model.PutBucketResponse",
        "Returns an Amazon.S3.Model.S3Bucket instance representing the new bucket.",
        "The service call response(s) (type Amazon.S3.Model.PutBucketResponse) can be returned by specifying '-Select *'."
    )]
    public class NewS3BucketCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket to create.
        /// </para>
        ///  
        /// <para>
        ///  <b>General purpose buckets</b> - For information about bucket naming restrictions,
        /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/bucketnamingrules.html">Bucket
        /// naming rules</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  
        /// <para>
        ///  <b>Directory buckets </b> - When you use this operation with a directory bucket,
        /// you must use path-style requests in the format <c>https://s3express-control.<i>region_code</i>.amazonaws.com/<i>bucket-name</i>
        /// </c>. Virtual-hosted-style requests aren't supported. Directory bucket names must
        /// be unique in the chosen Availability Zone. Bucket names must also follow the format
        /// <c> <i>bucket_base_name</i>--<i>az_id</i>--x-s3</c> (for example, <c> <i>amzn-s3-demo-bucket</i>--<i>usw2-az1</i>--x-s3</c>).
        /// For information about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
        /// bucket naming rules</a> in the <i>Amazon S3 User Guide</i> 
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BucketName { get; set; }
        #endregion

        #region Parameter CannedACLName
        /// <summary>
        /// Specifies the name of the canned ACL (access control list) of permissions to be applied to the S3 bucket.
        /// Please refer to <a href="http://docs.aws.amazon.com/sdkfornet/v4/apidocs/Index.html?page=S3/TS3_S3CannedACL.html&tocid=Amazon_S3_S3CannedACL">Amazon.S3.Model.S3CannedACL</a> for information on S3 Canned ACLs.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.S3CannedACL")]
        public Amazon.S3.S3CannedACL CannedACLName { get; set; }
        #endregion

        #region Parameter PublicReadOnly 
        /// <summary>
        /// If set, applies an ACL making the bucket public with read-only permissions
        /// This parameter is obsolete. Use CannedACLName instead.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is obsolete. Use CannedACLName instead.")]
        public SwitchParameter PublicReadOnly { get; set; }
        #endregion

        #region Parameter PublicReadWrite
        /// <summary>
        /// If set, applies an ACL making the bucket public with read-write permissions.
        /// This parameter is obsolete. Use CannedACLName instead.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Obsolete("This parameter is obsolete. Use CannedACLName instead.")]
        public SwitchParameter PublicReadWrite { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion

        #region Parameter ObjectLockEnabledForBucket
        /// <summary>
        /// Specifies whether you want S3 Object Lock to be enabled for the new bucket.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool? ObjectLockEnabledForBucket { get; set; }
        #endregion

        #region Parameter BucketConfiguration
        /// <summary>
        /// The configuration information for a bucket
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3.Model.PutBucketConfiguration BucketConfiguration { get; set; }
        #endregion

        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter]
        public string Select { get; set; } = "*";
        #endregion

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.BucketName, "New-S3Bucket (PutBucket)"))
                return;

            var context = new CmdletContext
            {
                BucketName = this.BucketName
            };

            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketResponse, NewS3BucketCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }

            if (!string.IsNullOrEmpty(this.CannedACLName))
                context.CannedACL = this.CannedACLName;
#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            else if (this.PublicReadOnly.IsPresent)
                context.CannedACL = S3CannedACL.PublicRead;
            else if (this.PublicReadWrite.IsPresent)
                context.CannedACL = S3CannedACL.PublicReadWrite;
#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute

            context.ObjectLockEnabledForBucket = this.ObjectLockEnabledForBucket;
            context.PutBucketConfiguration = this.BucketConfiguration;

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new PutBucketRequest();
            
            if (cmdletContext.BucketName != null)
                request.BucketName = cmdletContext.BucketName;

            if (cmdletContext.CannedACL != null)
                request.CannedACL = cmdletContext.CannedACL.Value;

            if (cmdletContext.PutBucketConfiguration != null)
                request.PutBucketConfiguration = cmdletContext.PutBucketConfiguration;

            // Forcibly set a location constraint to match whatever Region argument was used 
            // with the cmdlet; this will prevent S3 issuing the "unspecified location constraint 
            // didn't match" message, potentially confusing new users.
            request.BucketRegionName = _RegionEndpoint.SystemName;

            if (cmdletContext.ObjectLockEnabledForBucket != null)
            {
                request.ObjectLockEnabledForBucket = cmdletContext.ObjectLockEnabledForBucket.Value;
            }

            using (var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint))
            {
                CmdletOutput output;
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
                    this.WriteError(new ErrorRecord(e, $"Failed to create the specified bucket.\r\nAmazon S3 error: {e.Message}", ErrorCategory.InvalidOperation, this));
                }

                return output;
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.S3.Model.PutBucketResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3", "PutBucket");

            try
            {
                return client.PutBucketAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }
            public S3CannedACL CannedACL { get; set; }
            public bool? ObjectLockEnabledForBucket { get; set; }
            public PutBucketConfiguration PutBucketConfiguration { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketResponse, NewS3BucketCmdlet, object> Select { get; set; } =
                // since S3 bucket has only a name and a creation date, take a simple route to
                // emit the instance rather than a ListBuckets/search approach
                (response, cmdlet) => new S3Bucket { BucketName = cmdlet.BucketName, CreationDate = DateTime.UtcNow };
        }
        
    }
}
