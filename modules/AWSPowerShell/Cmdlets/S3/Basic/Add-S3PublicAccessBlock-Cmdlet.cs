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
    /// Amazon.S3.IAmazonS3.PutPublicAccessBlock
    /// </summary>
    [Cmdlet("Add", "S3PublicAccessBlock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutPublicAccessBlock API operation.", Operation = new[] {"PutPublicAccessBlock"}, SelectReturnType = typeof(Amazon.S3.Model.PutPublicAccessBlockResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutPublicAccessBlockResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutPublicAccessBlockResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddS3PublicAccessBlockCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter PublicAccessBlockConfiguration_BlockPublicAcl
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should block public ACLs for this bucket. Setting this
        /// element to <code>TRUE</code> causes the following behavior:</para><ul><li><para>PUT Bucket acl and PUT Object acl calls will fail if the specified ACL allows public
        /// access.</para></li><li><para>PUT Object calls will fail if the request includes an object ACL.</para></li></ul><para>Note that enabling this setting doesn't affect existing policies or ACLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicAccessBlockConfiguration_BlockPublicAcls")]
        public System.Boolean? PublicAccessBlockConfiguration_BlockPublicAcl { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_BlockPublicPolicy
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should block public bucket policies for this bucket. Setting
        /// this element to <code>TRUE</code> causes Amazon S3 to reject calls to PUT Bucket policy
        /// if the specified bucket policy allows public access. </para><para>Note that enabling this setting doesn't affect existing bucket policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublicAccessBlockConfiguration_BlockPublicPolicy { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket whose Public Access Block configuration you want
        /// to set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>Indicates the algorithm used to create the checksum for the object. Amazon S3 will
        /// fail the request with a 400 error if there is no checksum associated with the object.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">
        /// Checking object integrity</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// <para>The MD5 hash of the <code>PutPublicAccessBlock</code> request body. </para><para>For requests made using the Amazon Web Services Command Line Interface (CLI) or Amazon
        /// Web Services SDKs, this field is calculated automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// The account ID of the expected bucket owner. 
        /// If the bucket is owned by a different account, the request will fail with an HTTP 403 (Access Denied) error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_IgnorePublicAcl
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should ignore public ACLs for this bucket. Setting this
        /// element to <code>TRUE</code> causes Amazon S3 to ignore all public ACLs on this bucket
        /// and any objects that it contains. </para><para>Note that enabling this setting doesn't affect the persistence of any existing ACLs
        /// and doesn't prevent new public ACLs from being set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicAccessBlockConfiguration_IgnorePublicAcls")]
        public System.Boolean? PublicAccessBlockConfiguration_IgnorePublicAcl { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_RestrictPublicBucket
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should restrict public bucket policies for this bucket.
        /// Setting this element to <code>TRUE</code> restricts access to this bucket to only
        /// Amazon Web Service principals and authorized users within this account if the bucket
        /// has a public policy.</para><para>Enabling this setting doesn't affect previously stored bucket policies, except that
        /// public and cross-account access within any public bucket policy, including non-public
        /// delegation to specific accounts, is blocked.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicAccessBlockConfiguration_RestrictPublicBuckets")]
        public System.Boolean? PublicAccessBlockConfiguration_RestrictPublicBucket { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutPublicAccessBlockResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-S3PublicAccessBlock (PutPublicAccessBlock)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutPublicAccessBlockResponse, AddS3PublicAccessBlockCmdlet>(Select) ??
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
            context.ContentMD5 = this.ContentMD5;
            context.PublicAccessBlockConfiguration_BlockPublicAcl = this.PublicAccessBlockConfiguration_BlockPublicAcl;
            context.PublicAccessBlockConfiguration_IgnorePublicAcl = this.PublicAccessBlockConfiguration_IgnorePublicAcl;
            context.PublicAccessBlockConfiguration_BlockPublicPolicy = this.PublicAccessBlockConfiguration_BlockPublicPolicy;
            context.PublicAccessBlockConfiguration_RestrictPublicBucket = this.PublicAccessBlockConfiguration_RestrictPublicBucket;
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
            var request = new Amazon.S3.Model.PutPublicAccessBlockRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            
             // populate PublicAccessBlockConfiguration
            var requestPublicAccessBlockConfigurationIsNull = true;
            request.PublicAccessBlockConfiguration = new Amazon.S3.Model.PublicAccessBlockConfiguration();
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl = null;
            if (cmdletContext.PublicAccessBlockConfiguration_BlockPublicAcl != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl = cmdletContext.PublicAccessBlockConfiguration_BlockPublicAcl.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl != null)
            {
                request.PublicAccessBlockConfiguration.BlockPublicAcls = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl = null;
            if (cmdletContext.PublicAccessBlockConfiguration_IgnorePublicAcl != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl = cmdletContext.PublicAccessBlockConfiguration_IgnorePublicAcl.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl != null)
            {
                request.PublicAccessBlockConfiguration.IgnorePublicAcls = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy = null;
            if (cmdletContext.PublicAccessBlockConfiguration_BlockPublicPolicy != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy = cmdletContext.PublicAccessBlockConfiguration_BlockPublicPolicy.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy != null)
            {
                request.PublicAccessBlockConfiguration.BlockPublicPolicy = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket = null;
            if (cmdletContext.PublicAccessBlockConfiguration_RestrictPublicBucket != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket = cmdletContext.PublicAccessBlockConfiguration_RestrictPublicBucket.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket != null)
            {
                request.PublicAccessBlockConfiguration.RestrictPublicBuckets = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
             // determine if request.PublicAccessBlockConfiguration should be set to null
            if (requestPublicAccessBlockConfigurationIsNull)
            {
                request.PublicAccessBlockConfiguration = null;
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
        
        private Amazon.S3.Model.PutPublicAccessBlockResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutPublicAccessBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutPublicAccessBlock");
            try
            {
                #if DESKTOP
                return client.PutPublicAccessBlock(request);
                #elif CORECLR
                return client.PutPublicAccessBlockAsync(request).GetAwaiter().GetResult();
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
            public System.String ContentMD5 { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_BlockPublicAcl { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_IgnorePublicAcl { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_BlockPublicPolicy { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_RestrictPublicBucket { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.PutPublicAccessBlockResponse, AddS3PublicAccessBlockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
