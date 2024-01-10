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
    /// Creates a session that establishes temporary security credentials to support fast
    /// authentication and authorization for the Zonal endpoint APIs on directory buckets.
    /// For more information about Zonal endpoint APIs that include the Availability Zone
    /// in the request endpoint, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-APIs.html">S3
    /// Express One Zone APIs</a> in the <i>Amazon S3 User Guide</i>. 
    /// 
    ///  
    /// <para>
    /// To make Zonal endpoint API requests on a directory bucket, use the <c>CreateSession</c>
    /// API operation. Specifically, you grant <c>s3express:CreateSession</c> permission to
    /// a bucket in a bucket policy or an IAM identity-based policy. Then, you use IAM credentials
    /// to make the <c>CreateSession</c> API request on the bucket, which returns temporary
    /// security credentials that include the access key ID, secret access key, session token,
    /// and expiration. These credentials have associated permissions to access the Zonal
    /// endpoint APIs. After the session is created, you don’t need to use other policies
    /// to grant permissions to each Zonal endpoint API individually. Instead, in your Zonal
    /// endpoint API requests, you sign your requests by applying the temporary security credentials
    /// of the session to the request headers and following the SigV4 protocol for authentication.
    /// You also apply the session token to the <c>x-amz-s3session-token</c> request header
    /// for authorization. Temporary security credentials are scoped to the bucket and expire
    /// after 5 minutes. After the expiration time, any calls that you make with those credentials
    /// will fail. You must use IAM credentials again to make a <c>CreateSession</c> API request
    /// that generates a new set of temporary credentials for use. Temporary credentials cannot
    /// be extended or refreshed beyond the original specified interval.
    /// </para><para>
    /// If you use Amazon Web Services SDKs, SDKs handle the session token refreshes automatically
    /// to avoid service interruptions when a session expires. We recommend that you use the
    /// Amazon Web Services SDKs to initiate and manage requests to the CreateSession API.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-optimizing-performance-guidelines-design-patterns.html#s3-express-optimizing-performance-session-authentication">Performance
    /// guidelines and design patterns</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><note><ul><li><para>
    /// You must make requests for this API operation to the Zonal endpoint. These endpoints
    /// support virtual-hosted-style requests in the format <c>https://<i>bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
    /// Path-style requests are not supported. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-Regions-and-Zones.html">Regional
    /// and Zonal endpoints</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></li><li><para><b><c>CopyObject</c> API operation</b> - Unlike other Zonal endpoint APIs, the <c>CopyObject</c>
    /// API operation doesn't use the temporary security credentials returned from the <c>CreateSession</c>
    /// API operation for authentication and authorization. For information about authentication
    /// and authorization of the <c>CopyObject</c> API operation on directory buckets, see
    /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CopyObject.html">CopyObject</a>.
    /// </para></li><li><para><b><c>HeadBucket</c> API operation</b> - Unlike other Zonal endpoint APIs, the <c>HeadBucket</c>
    /// API operation doesn't use the temporary security credentials returned from the <c>CreateSession</c>
    /// API operation for authentication and authorization. For information about authentication
    /// and authorization of the <c>HeadBucket</c> API operation on directory buckets, see
    /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_HeadBucket.html">HeadBucket</a>.
    /// </para></li></ul></note><dl><dt>Permissions</dt><dd><para>
    /// To obtain temporary security credentials, you must create a bucket policy or an IAM
    /// identity-based policy that grants <c>s3express:CreateSession</c> permission to the
    /// bucket. In a policy, you can have the <c>s3express:SessionMode</c> condition key to
    /// control who can create a <c>ReadWrite</c> or <c>ReadOnly</c> session. For more information
    /// about <c>ReadWrite</c> or <c>ReadOnly</c> sessions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html#API_CreateSession_RequestParameters"><c>x-amz-create-session-mode</c></a>. For example policies, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-security-iam-example-bucket-policies.html">Example
    /// bucket policies for S3 Express One Zone</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-security-iam-identity-policies.html">Amazon
    /// Web Services Identity and Access Management (IAM) identity-based policies for S3 Express
    /// One Zone</a> in the <i>Amazon S3 User Guide</i>. 
    /// </para><para>
    /// To grant cross-account access to Zonal endpoint APIs, the bucket policy should also
    /// grant both accounts the <c>s3express:CreateSession</c> permission.
    /// </para></dd><dt>HTTP Host header syntax</dt><dd><para><b>Directory buckets </b> - The HTTP Host header syntax is <c><i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("New", "S3Session", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.Model.SessionCredentials")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) CreateSession API operation.", Operation = new[] {"CreateSession"}, SelectReturnType = typeof(Amazon.S3.Model.CreateSessionResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.SessionCredentials or Amazon.S3.Model.CreateSessionResponse",
        "This cmdlet returns an Amazon.S3.Model.SessionCredentials object.",
        "The service call response (type Amazon.S3.Model.CreateSessionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewS3SessionCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter SessionMode
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.SessionMode")]
        public Amazon.S3.SessionMode SessionMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Credentials'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.CreateSessionResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.CreateSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Credentials";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3Session (CreateSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.CreateSessionResponse, NewS3SessionCmdlet>(Select) ??
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
            context.SessionMode = this.SessionMode;
            
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
            var request = new Amazon.S3.Model.CreateSessionRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.SessionMode != null)
            {
                request.SessionMode = cmdletContext.SessionMode;
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
        
        private Amazon.S3.Model.CreateSessionResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.CreateSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "CreateSession");
            try
            {
                #if DESKTOP
                return client.CreateSession(request);
                #elif CORECLR
                return client.CreateSessionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.S3.SessionMode SessionMode { get; set; }
            public System.Func<Amazon.S3.Model.CreateSessionResponse, NewS3SessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Credentials;
        }
        
    }
}
