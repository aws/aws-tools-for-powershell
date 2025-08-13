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
    /// <important><para>
    /// End of support notice: Beginning October 1, 2025, Amazon S3 will discontinue support
    /// for creating new Email Grantee Access Control Lists (ACL). Email Grantee ACLs created
    /// prior to this date will continue to work and remain accessible through the Amazon
    /// Web Services Management Console, Command Line Interface (CLI), SDKs, and REST API.
    /// However, you will no longer be able to create new Email Grantee ACLs. 
    /// </para><para>
    /// This change affects the following Amazon Web Services Regions: US East (N. Virginia)
    /// Region, US West (N. California) Region, US West (Oregon) Region, Asia Pacific (Singapore)
    /// Region, Asia Pacific (Sydney) Region, Asia Pacific (Tokyo) Region, Europe (Ireland)
    /// Region, and South America (São Paulo) Region.
    /// </para></important><note><para>
    /// This operation is not supported for directory buckets.
    /// </para></note><para>
    /// Sets the permissions on an existing bucket using access control lists (ACL). For more
    /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/S3_ACLs_UsingACLs.html">Using
    /// ACLs</a>. To set the ACL of a bucket, you must have the <c>WRITE_ACP</c> permission.
    /// </para><para>
    /// You can use one of the following two ways to set a bucket's permissions:
    /// </para><ul><li><para>
    /// Specify the ACL in the request body
    /// </para></li><li><para>
    /// Specify permissions using request headers
    /// </para></li></ul><note><para>
    /// You cannot specify access permission using both the body and the request headers.
    /// </para></note><para>
    /// Depending on your application needs, you may choose to set the ACL on a bucket using
    /// either the request body or the headers. For example, if you have an existing application
    /// that updates a bucket ACL using the request body, then you can continue to use that
    /// approach.
    /// </para><important><para>
    /// If your bucket uses the bucket owner enforced setting for S3 Object Ownership, ACLs
    /// are disabled and no longer affect permissions. You must use policies to grant access
    /// to your bucket and the objects in it. Requests to set ACLs or update ACLs fail and
    /// return the <c>AccessControlListNotSupported</c> error code. Requests to read ACLs
    /// are still supported. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/about-object-ownership.html">Controlling
    /// object ownership</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></important><dl><dt>Permissions</dt><dd><para>
    /// You can set access permissions by using one of the following methods:
    /// </para><ul><li><para>
    /// Specify a canned ACL with the <c>x-amz-acl</c> request header. Amazon S3 supports
    /// a set of predefined ACLs, known as <i>canned ACLs</i>. Each canned ACL has a predefined
    /// set of grantees and permissions. Specify the canned ACL name as the value of <c>x-amz-acl</c>.
    /// If you use this header, you cannot use other access control-specific headers in your
    /// request. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/acl-overview.html#CannedACL">Canned
    /// ACL</a>.
    /// </para></li><li><para>
    /// Specify access permissions explicitly with the <c>x-amz-grant-read</c>, <c>x-amz-grant-read-acp</c>,
    /// <c>x-amz-grant-write-acp</c>, and <c>x-amz-grant-full-control</c> headers. When using
    /// these headers, you specify explicit access permissions and grantees (Amazon Web Services
    /// accounts or Amazon S3 groups) who will receive the permission. If you use these ACL-specific
    /// headers, you cannot use the <c>x-amz-acl</c> header to set a canned ACL. These parameters
    /// map to the set of permissions that Amazon S3 supports in an ACL. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/acl-overview.html">Access
    /// Control List (ACL) Overview</a>.
    /// </para><para>
    /// You specify each grantee as a type=value pair, where the type is one of the following:
    /// </para><ul><li><para><c>id</c> – if the value specified is the canonical user ID of an Amazon Web Services
    /// account
    /// </para></li><li><para><c>uri</c> – if you are granting permissions to a predefined group
    /// </para></li><li><para><c>emailAddress</c> – if the value specified is the email address of an Amazon Web
    /// Services account
    /// </para><note><para>
    /// Using email addresses to specify a grantee is only supported in the following Amazon
    /// Web Services Regions: 
    /// </para><ul><li><para>
    /// US East (N. Virginia)
    /// </para></li><li><para>
    /// US West (N. California)
    /// </para></li><li><para>
    ///  US West (Oregon)
    /// </para></li><li><para>
    ///  Asia Pacific (Singapore)
    /// </para></li><li><para>
    /// Asia Pacific (Sydney)
    /// </para></li><li><para>
    /// Asia Pacific (Tokyo)
    /// </para></li><li><para>
    /// Europe (Ireland)
    /// </para></li><li><para>
    /// South America (São Paulo)
    /// </para></li></ul><para>
    /// For a list of all the Amazon S3 supported Regions and endpoints, see <a href="https://docs.aws.amazon.com/general/latest/gr/rande.html#s3_region">Regions
    /// and Endpoints</a> in the Amazon Web Services General Reference.
    /// </para></note></li></ul><para>
    /// For example, the following <c>x-amz-grant-write</c> header grants create, overwrite,
    /// and delete objects permission to LogDelivery group predefined by Amazon S3 and two
    /// Amazon Web Services accounts identified by their email addresses.
    /// </para><para><c>x-amz-grant-write: uri="http://acs.amazonaws.com/groups/s3/LogDelivery", id="111122223333",
    /// id="555566667777" </c></para></li></ul><para>
    /// You can use either a canned ACL or specify access permissions explicitly. You cannot
    /// do both.
    /// </para></dd><dt>Grantee Values</dt><dd><para>
    /// You can specify the person (grantee) to whom you're assigning access rights (using
    /// request elements) in the following ways. For examples of how to specify these grantee
    /// values in JSON format, see the Amazon Web Services CLI example in <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/enable-server-access-logging.html">
    /// Enabling Amazon S3 server access logging</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><ul><li><para>
    /// By the person's ID:
    /// </para><para><c>&lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="CanonicalUser"&gt;&lt;ID&gt;&lt;&gt;ID&lt;&gt;&lt;/ID&gt;&lt;DisplayName&gt;&lt;&gt;GranteesEmail&lt;&gt;&lt;/DisplayName&gt;
    /// &lt;/Grantee&gt;</c></para><para>
    /// DisplayName is optional and ignored in the request
    /// </para></li><li><para>
    /// By URI:
    /// </para><para><c>&lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="Group"&gt;&lt;URI&gt;&lt;&gt;http://acs.amazonaws.com/groups/global/AuthenticatedUsers&lt;&gt;&lt;/URI&gt;&lt;/Grantee&gt;</c></para></li><li><para>
    /// By Email address:
    /// </para><para><c>&lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="AmazonCustomerByEmail"&gt;&lt;EmailAddress&gt;&lt;&gt;Grantees@email.com&lt;&gt;&lt;/EmailAddress&gt;&amp;&lt;/Grantee&gt;</c></para><para>
    /// The grantee is resolved to the CanonicalUser and, in a response to a GET Object acl
    /// request, appears as the CanonicalUser. 
    /// </para><note><para>
    /// Using email addresses to specify a grantee is only supported in the following Amazon
    /// Web Services Regions: 
    /// </para><ul><li><para>
    /// US East (N. Virginia)
    /// </para></li><li><para>
    /// US West (N. California)
    /// </para></li><li><para>
    ///  US West (Oregon)
    /// </para></li><li><para>
    ///  Asia Pacific (Singapore)
    /// </para></li><li><para>
    /// Asia Pacific (Sydney)
    /// </para></li><li><para>
    /// Asia Pacific (Tokyo)
    /// </para></li><li><para>
    /// Europe (Ireland)
    /// </para></li><li><para>
    /// South America (São Paulo)
    /// </para></li></ul><para>
    /// For a list of all the Amazon S3 supported Regions and endpoints, see <a href="https://docs.aws.amazon.com/general/latest/gr/rande.html#s3_region">Regions
    /// and Endpoints</a> in the Amazon Web Services General Reference.
    /// </para></note></li></ul></dd></dl><para>
    /// The following operations are related to <c>PutBucketAcl</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucket.html">CreateBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucket.html">DeleteBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectAcl.html">GetObjectAcl</a></para></li></ul>
    /// </summary>
    [Cmdlet("Set", "S3BucketACL", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketAcl API operation.", Operation = new[] {"PutBucketAcl"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketAclResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketAclResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketAclResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetS3BucketACLCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ACL
        /// <summary>
        /// <para>
        /// <para>The canned ACL to apply to the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.S3CannedACL")]
        public Amazon.S3.S3CannedACL ACL { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket to which to apply the ACL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>Indicates the algorithm used to create the checksum for the request when you use the
        /// SDK. This header will not provide any additional functionality if you don't use the
        /// SDK. When you send this header, there must be a corresponding <c>x-amz-checksum</c>
        /// or <c>x-amz-trailer</c> header sent. Otherwise, Amazon S3 fails the request with the
        /// HTTP status code <c>400 Bad Request</c>. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">Checking
        /// object integrity</a> in the <i>Amazon S3 User Guide</i>.</para><para>If you provide an individual checksum, Amazon S3 ignores any provided <c>ChecksumAlgorithm</c>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// <para>The Base64 encoded 128-bit <c>MD5</c> digest of the data. This header must be used
        /// as a message integrity check to verify that the request body was not corrupted in
        /// transit. For more information, go to <a href="http://www.ietf.org/rfc/rfc1864.txt">RFC
        /// 1864.</a></para><para>For requests made using the Amazon Web Services Command Line Interface (CLI) or Amazon
        /// Web Services SDKs, this field is calculated automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter Owner_DisplayName
        /// <summary>
        /// <para>
        /// <para>Container for the display name of the owner. This value is only supported in the following
        /// Amazon Web Services Regions:</para><ul><li><para>US East (N. Virginia)</para></li><li><para>US West (N. California)</para></li><li><para>US West (Oregon)</para></li><li><para>Asia Pacific (Singapore)</para></li><li><para>Asia Pacific (Sydney)</para></li><li><para>Asia Pacific (Tokyo)</para></li><li><para>Europe (Ireland)</para></li><li><para>South America (São Paulo)</para></li></ul><note><para>This functionality is not supported for directory buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessControlPolicy_Owner_DisplayName")]
        public System.String Owner_DisplayName { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <c>403 Forbidden</c> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter GrantFullControl
        /// <summary>
        /// <para>
        /// <para>Allows grantee the read, write, read ACP, and write ACP permissions on the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantFullControl { get; set; }
        #endregion
        
        #region Parameter GrantRead
        /// <summary>
        /// <para>
        /// <para>Allows grantee to list the objects in the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantRead { get; set; }
        #endregion
        
        #region Parameter GrantReadACP
        /// <summary>
        /// <para>
        /// <para>Allows grantee to read the bucket ACL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantReadACP { get; set; }
        #endregion
        
        #region Parameter AccessControlPolicy_Grant
        /// <summary>
        /// <para>
        /// <para>A list of grants.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessControlPolicy_Grants")]
        public Amazon.S3.Model.S3Grant[] AccessControlPolicy_Grant { get; set; }
        #endregion
        
        #region Parameter GrantWrite
        /// <summary>
        /// <para>
        /// <para>Allows grantee to create new objects in the bucket.</para><para>For the bucket and object owners of existing objects, also allows deletions and overwrites
        /// of those objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantWrite { get; set; }
        #endregion
        
        #region Parameter GrantWriteACP
        /// <summary>
        /// <para>
        /// <para>Allows grantee to write the ACL for the applicable bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantWriteACP { get; set; }
        #endregion
        
        #region Parameter Owner_Id
        /// <summary>
        /// <para>
        /// <para>Container for the ID of the owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessControlPolicy_Owner_Id")]
        public System.String Owner_Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketAclResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-S3BucketACL (PutBucketAcl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketAclResponse, SetS3BucketACLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccessControlPolicy_Grant != null)
            {
                context.AccessControlPolicy_Grant = new List<Amazon.S3.Model.S3Grant>(this.AccessControlPolicy_Grant);
            }
            context.Owner_DisplayName = this.Owner_DisplayName;
            context.Owner_Id = this.Owner_Id;
            context.ACL = this.ACL;
            context.BucketName = this.BucketName;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ContentMD5 = this.ContentMD5;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.GrantFullControl = this.GrantFullControl;
            context.GrantRead = this.GrantRead;
            context.GrantReadACP = this.GrantReadACP;
            context.GrantWrite = this.GrantWrite;
            context.GrantWriteACP = this.GrantWriteACP;
            
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
            var request = new Amazon.S3.Model.PutBucketAclRequest();
            
            
             // populate AccessControlPolicy
            var requestAccessControlPolicyIsNull = true;
            request.AccessControlPolicy = new Amazon.S3.Model.S3AccessControlList();
            List<Amazon.S3.Model.S3Grant> requestAccessControlPolicy_accessControlPolicy_Grant = null;
            if (cmdletContext.AccessControlPolicy_Grant != null)
            {
                requestAccessControlPolicy_accessControlPolicy_Grant = cmdletContext.AccessControlPolicy_Grant;
            }
            if (requestAccessControlPolicy_accessControlPolicy_Grant != null)
            {
                request.AccessControlPolicy.Grants = requestAccessControlPolicy_accessControlPolicy_Grant;
                requestAccessControlPolicyIsNull = false;
            }
            Amazon.S3.Model.Owner requestAccessControlPolicy_accessControlPolicy_Owner = null;
            
             // populate Owner
            var requestAccessControlPolicy_accessControlPolicy_OwnerIsNull = true;
            requestAccessControlPolicy_accessControlPolicy_Owner = new Amazon.S3.Model.Owner();
            System.String requestAccessControlPolicy_accessControlPolicy_Owner_owner_DisplayName = null;
            if (cmdletContext.Owner_DisplayName != null)
            {
                requestAccessControlPolicy_accessControlPolicy_Owner_owner_DisplayName = cmdletContext.Owner_DisplayName;
            }
            if (requestAccessControlPolicy_accessControlPolicy_Owner_owner_DisplayName != null)
            {
                requestAccessControlPolicy_accessControlPolicy_Owner.DisplayName = requestAccessControlPolicy_accessControlPolicy_Owner_owner_DisplayName;
                requestAccessControlPolicy_accessControlPolicy_OwnerIsNull = false;
            }
            System.String requestAccessControlPolicy_accessControlPolicy_Owner_owner_Id = null;
            if (cmdletContext.Owner_Id != null)
            {
                requestAccessControlPolicy_accessControlPolicy_Owner_owner_Id = cmdletContext.Owner_Id;
            }
            if (requestAccessControlPolicy_accessControlPolicy_Owner_owner_Id != null)
            {
                requestAccessControlPolicy_accessControlPolicy_Owner.Id = requestAccessControlPolicy_accessControlPolicy_Owner_owner_Id;
                requestAccessControlPolicy_accessControlPolicy_OwnerIsNull = false;
            }
             // determine if requestAccessControlPolicy_accessControlPolicy_Owner should be set to null
            if (requestAccessControlPolicy_accessControlPolicy_OwnerIsNull)
            {
                requestAccessControlPolicy_accessControlPolicy_Owner = null;
            }
            if (requestAccessControlPolicy_accessControlPolicy_Owner != null)
            {
                request.AccessControlPolicy.Owner = requestAccessControlPolicy_accessControlPolicy_Owner;
                requestAccessControlPolicyIsNull = false;
            }
             // determine if request.AccessControlPolicy should be set to null
            if (requestAccessControlPolicyIsNull)
            {
                request.AccessControlPolicy = null;
            }
            if (cmdletContext.ACL != null)
            {
                request.ACL = cmdletContext.ACL;
            }
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
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.GrantFullControl != null)
            {
                request.GrantFullControl = cmdletContext.GrantFullControl;
            }
            if (cmdletContext.GrantRead != null)
            {
                request.GrantRead = cmdletContext.GrantRead;
            }
            if (cmdletContext.GrantReadACP != null)
            {
                request.GrantReadACP = cmdletContext.GrantReadACP;
            }
            if (cmdletContext.GrantWrite != null)
            {
                request.GrantWrite = cmdletContext.GrantWrite;
            }
            if (cmdletContext.GrantWriteACP != null)
            {
                request.GrantWriteACP = cmdletContext.GrantWriteACP;
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
        
        private Amazon.S3.Model.PutBucketAclResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketAclRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketAcl");
            try
            {
                return client.PutBucketAclAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.S3.Model.S3Grant> AccessControlPolicy_Grant { get; set; }
            public System.String Owner_DisplayName { get; set; }
            public System.String Owner_Id { get; set; }
            public Amazon.S3.S3CannedACL ACL { get; set; }
            public System.String BucketName { get; set; }
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String ContentMD5 { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.String GrantFullControl { get; set; }
            public System.String GrantRead { get; set; }
            public System.String GrantReadACP { get; set; }
            public System.String GrantWrite { get; set; }
            public System.String GrantWriteACP { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketAclResponse, SetS3BucketACLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
