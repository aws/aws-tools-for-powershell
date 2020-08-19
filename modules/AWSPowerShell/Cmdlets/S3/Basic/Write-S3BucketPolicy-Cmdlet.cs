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
    /// Applies an Amazon S3 bucket policy to an Amazon S3 bucket. If you are using an identity
    /// other than the root user of the AWS account that owns the bucket, the calling identity
    /// must have the <code>PutBucketPolicy</code> permissions on the specified bucket and
    /// belong to the bucket owner's account in order to use this operation.
    /// 
    ///  
    /// <para>
    /// If you don't have <code>PutBucketPolicy</code> permissions, Amazon S3 returns a <code>403
    /// Access Denied</code> error. If you have the correct permissions, but you're not using
    /// an identity that belongs to the bucket owner's account, Amazon S3 returns a <code>405
    /// Method Not Allowed</code> error.
    /// </para><important><para>
    ///  As a security precaution, the root user of the AWS account that owns a bucket can
    /// always use this operation, even if the policy explicitly denies the root user the
    /// ability to perform this action. 
    /// </para></important><para>
    /// For more information about bucket policies, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-iam-policies.html">Using
    /// Bucket Policies and User Policies</a>.
    /// </para><para>
    /// The following operations are related to <code>PutBucketPolicy</code>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucket.html">CreateBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucket.html">DeleteBucket</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3BucketPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketPolicy API operation.", Operation = new[] {"PutBucketPolicy"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3BucketPolicyCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ConfirmRemoveSelfBucketAccess
        /// <summary>
        /// <para>
        /// Set this parameter to true to confirm that you want to remove your 
        /// permissions to change this bucket policy in the future.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConfirmRemoveSelfBucketAccess { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// The base64 encoded 128-bit MD5 digest of the message (without the headers) according to RFC 1864. 
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// The account id of the expected bucket owner. 
        /// If the bucket is owned by a different account, the request will fail with an HTTP 403 (Access Denied) error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// The bucket policy as a JSON document.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketPolicyResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketPolicy (PutBucketPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketPolicyResponse, WriteS3BucketPolicyCmdlet>(Select) ??
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
            context.ContentMD5 = this.ContentMD5;
            context.Policy = this.Policy;
            context.ConfirmRemoveSelfBucketAccess = this.ConfirmRemoveSelfBucketAccess;
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
            var request = new Amazon.S3.Model.PutBucketPolicyRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.ConfirmRemoveSelfBucketAccess != null)
            {
                request.ConfirmRemoveSelfBucketAccess = cmdletContext.ConfirmRemoveSelfBucketAccess.Value;
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
        
        private Amazon.S3.Model.PutBucketPolicyResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketPolicy");
            try
            {
                #if DESKTOP
                return client.PutBucketPolicy(request);
                #elif CORECLR
                return client.PutBucketPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ContentMD5 { get; set; }
            public System.String Policy { get; set; }
            public System.Boolean? ConfirmRemoveSelfBucketAccess { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketPolicyResponse, WriteS3BucketPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
