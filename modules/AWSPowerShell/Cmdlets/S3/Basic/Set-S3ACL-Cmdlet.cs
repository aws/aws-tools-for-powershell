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
    /// Sets the permissions on an existing bucket using access control lists (ACL). For more
    /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/S3_ACLs_UsingACLs.html">Using
    /// ACLs</a>. To set the ACL of a bucket, you must have <code>WRITE_ACP</code> permission.
    /// 
    ///  
    /// <para>
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
    /// return the <code>AccessControlListNotSupported</code> error code. Requests to read
    /// ACLs are still supported. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/about-object-ownership.html">Controlling
    /// object ownership</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></important><dl><dt>Permissions</dt><dd><para>
    /// You can set access permissions by using one of the following methods:
    /// </para><ul><li><para>
    /// Specify a canned ACL with the <code>x-amz-acl</code> request header. Amazon S3 supports
    /// a set of predefined ACLs, known as <i>canned ACLs</i>. Each canned ACL has a predefined
    /// set of grantees and permissions. Specify the canned ACL name as the value of <code>x-amz-acl</code>.
    /// If you use this header, you cannot use other access control-specific headers in your
    /// request. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/acl-overview.html#CannedACL">Canned
    /// ACL</a>.
    /// </para></li><li><para>
    /// Specify access permissions explicitly with the <code>x-amz-grant-read</code>, <code>x-amz-grant-read-acp</code>,
    /// <code>x-amz-grant-write-acp</code>, and <code>x-amz-grant-full-control</code> headers.
    /// When using these headers, you specify explicit access permissions and grantees (Amazon
    /// Web Services accounts or Amazon S3 groups) who will receive the permission. If you
    /// use these ACL-specific headers, you cannot use the <code>x-amz-acl</code> header to
    /// set a canned ACL. These parameters map to the set of permissions that Amazon S3 supports
    /// in an ACL. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/acl-overview.html">Access
    /// Control List (ACL) Overview</a>.
    /// </para><para>
    /// You specify each grantee as a type=value pair, where the type is one of the following:
    /// </para><ul><li><para><code>id</code> – if the value specified is the canonical user ID of an Amazon Web
    /// Services account
    /// </para></li><li><para><code>uri</code> – if you are granting permissions to a predefined group
    /// </para></li><li><para><code>emailAddress</code> – if the value specified is the email address of an Amazon
    /// Web Services account
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
    /// For example, the following <code>x-amz-grant-write</code> header grants create, overwrite,
    /// and delete objects permission to LogDelivery group predefined by Amazon S3 and two
    /// Amazon Web Services accounts identified by their email addresses.
    /// </para><para><code>x-amz-grant-write: uri="http://acs.amazonaws.com/groups/s3/LogDelivery", id="111122223333",
    /// id="555566667777" </code></para></li></ul><para>
    /// You can use either a canned ACL or specify access permissions explicitly. You cannot
    /// do both.
    /// </para></dd><dt>Grantee Values</dt><dd><para>
    /// You can specify the person (grantee) to whom you're assigning access rights (using
    /// request elements) in the following ways:
    /// </para><ul><li><para>
    /// By the person's ID:
    /// </para><para><code>&lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="CanonicalUser"&gt;&lt;ID&gt;&lt;&gt;ID&lt;&gt;&lt;/ID&gt;&lt;DisplayName&gt;&lt;&gt;GranteesEmail&lt;&gt;&lt;/DisplayName&gt;
    /// &lt;/Grantee&gt;</code></para><para>
    /// DisplayName is optional and ignored in the request
    /// </para></li><li><para>
    /// By URI:
    /// </para><para><code>&lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="Group"&gt;&lt;URI&gt;&lt;&gt;http://acs.amazonaws.com/groups/global/AuthenticatedUsers&lt;&gt;&lt;/URI&gt;&lt;/Grantee&gt;</code></para></li><li><para>
    /// By Email address:
    /// </para><para><code>&lt;Grantee xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:type="AmazonCustomerByEmail"&gt;&lt;EmailAddress&gt;&lt;&gt;Grantees@email.com&lt;&gt;&lt;/EmailAddress&gt;&amp;&lt;/Grantee&gt;</code></para><para>
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
    /// The following operations are related to <code>PutBucketAcl</code>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucket.html">CreateBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucket.html">DeleteBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectAcl.html">GetObjectAcl</a></para></li></ul>
    /// </summary>
    [Cmdlet("Set", "S3ACL", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutACL API operation.", Operation = new[] {"PutACL"}, SelectReturnType = typeof(Amazon.S3.Model.PutACLResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutACLResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutACLResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetS3ACLCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name that contains the object to which you want to attach the ACL.</para><para>When using this API with an access point, you must direct requests to the access point hostname. 
        /// The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com. 
        /// When using this operation with an access point through the AWS SDKs, you provide the access point 
        /// ARN in place of the bucket name. For more information about access point ARNs, see 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-access-points.html">Using Access Points</a> 
        /// in the <i>Amazon Simple Storage Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter CannedACL
        /// <summary>
        /// <para>
        /// The canned ACL to apply to the bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CannedACLName")]
        [AWSConstantClassSource("Amazon.S3.S3CannedACL")]
        public Amazon.S3.S3CannedACL CannedACL { get; set; }
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
        
        #region Parameter Owner_DisplayName
        /// <summary>
        /// <para>
        /// <para>Container for the display name of the owner. This value is only supported in the following
        /// Amazon Web Services Regions:</para><ul><li><para>US East (N. Virginia)</para></li><li><para>US West (N. California)</para></li><li><para>US West (Oregon)</para></li><li><para>Asia Pacific (Singapore)</para></li><li><para>Asia Pacific (Sydney)</para></li><li><para>Asia Pacific (Tokyo)</para></li><li><para>Europe (Ireland)</para></li><li><para>South America (São Paulo)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [Alias("AccessControlList_Owner_DisplayName","ACL_Owner_DisplayName","OwnerDisplayName")]
        public System.String Owner_DisplayName { get; set; }
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
        
        #region Parameter AccessControlList_Grant
        /// <summary>
        /// <para>
        /// A collection of grants.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        [Alias("AccessControlList_Grants","ACL_Grants","Grant","Grants")]
        public Amazon.S3.Model.S3Grant[] AccessControlList_Grant { get; set; }
        #endregion
        
        #region Parameter Owner_Id
        /// <summary>
        /// <para>
        /// The unique identifier of the owner.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("AccessControlList_Owner_Id","ACL_Owner_Id","OwnerId")]
        public System.String Owner_Id { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// The key of an S3 object.
        /// If not specified, the ACLs are applied to the bucket.
        /// <para>Key for which the PUT action was initiated.</para><para>When using this action with an access point, you must direct requests to the access point hostname.
        /// The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com. 
        /// When using this action with an access point through the Amazon Web Services SDKs, you provide the access point ARN in place of the bucket name. 
        /// For more information about access point ARNs, see 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using Access Points</a> in the <i>Amazon S3 User Guide</i>.</para><para>When you use this action with Amazon S3 on Outposts, you must direct requests to the S3 on Outposts hostname. 
        /// The S3 on Outposts hostname takes the form <code><i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</code>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs, you provide the Outposts access point ARN in place of the bucket name. 
        /// For more information about S3 on Outposts ARNs, see 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts">What is S3 on Outposts</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// If set and an object key has been specified, the ACLs are applied
        /// to the specific version of the object.
        /// This property is ignored if the ACL is to be set on a Bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 5, ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutACLResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Key), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-S3ACL (PutACL)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutACLResponse, SetS3ACLCmdlet>(Select) ??
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
            context.Owner_DisplayName = this.Owner_DisplayName;
            context.Owner_Id = this.Owner_Id;
            if (this.AccessControlList_Grant != null)
            {
                context.AccessControlList_Grant = new List<Amazon.S3.Model.S3Grant>(this.AccessControlList_Grant);
            }
            context.CannedACL = this.CannedACL;
            context.BucketName = this.BucketName;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.Key = this.Key;
            context.VersionId = this.VersionId;
            
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
            var request = new Amazon.S3.Model.PutACLRequest();
            
            
             // populate AccessControlList
            var requestAccessControlListIsNull = true;
            request.AccessControlList = new Amazon.S3.Model.S3AccessControlList();
            List<Amazon.S3.Model.S3Grant> requestAccessControlList_accessControlList_Grant = null;
            if (cmdletContext.AccessControlList_Grant != null)
            {
                requestAccessControlList_accessControlList_Grant = cmdletContext.AccessControlList_Grant;
            }
            if (requestAccessControlList_accessControlList_Grant != null)
            {
                request.AccessControlList.Grants = requestAccessControlList_accessControlList_Grant;
                requestAccessControlListIsNull = false;
            }
            Amazon.S3.Model.Owner requestAccessControlList_accessControlList_Owner = null;
            
             // populate Owner
            var requestAccessControlList_accessControlList_OwnerIsNull = true;
            requestAccessControlList_accessControlList_Owner = new Amazon.S3.Model.Owner();
            System.String requestAccessControlList_accessControlList_Owner_owner_DisplayName = null;
            if (cmdletContext.Owner_DisplayName != null)
            {
                requestAccessControlList_accessControlList_Owner_owner_DisplayName = cmdletContext.Owner_DisplayName;
            }
            if (requestAccessControlList_accessControlList_Owner_owner_DisplayName != null)
            {
                requestAccessControlList_accessControlList_Owner.DisplayName = requestAccessControlList_accessControlList_Owner_owner_DisplayName;
                requestAccessControlList_accessControlList_OwnerIsNull = false;
            }
            System.String requestAccessControlList_accessControlList_Owner_owner_Id = null;
            if (cmdletContext.Owner_Id != null)
            {
                requestAccessControlList_accessControlList_Owner_owner_Id = cmdletContext.Owner_Id;
            }
            if (requestAccessControlList_accessControlList_Owner_owner_Id != null)
            {
                requestAccessControlList_accessControlList_Owner.Id = requestAccessControlList_accessControlList_Owner_owner_Id;
                requestAccessControlList_accessControlList_OwnerIsNull = false;
            }
             // determine if requestAccessControlList_accessControlList_Owner should be set to null
            if (requestAccessControlList_accessControlList_OwnerIsNull)
            {
                requestAccessControlList_accessControlList_Owner = null;
            }
            if (requestAccessControlList_accessControlList_Owner != null)
            {
                request.AccessControlList.Owner = requestAccessControlList_accessControlList_Owner;
                requestAccessControlListIsNull = false;
            }
             // determine if request.AccessControlList should be set to null
            if (requestAccessControlListIsNull)
            {
                request.AccessControlList = null;
            }
            if (cmdletContext.CannedACL != null)
            {
                request.CannedACL = cmdletContext.CannedACL;
            }
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
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
        
        private Amazon.S3.Model.PutACLResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutACLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutACL");
            try
            {
                #if DESKTOP
                return client.PutACL(request);
                #elif CORECLR
                return client.PutACLAsync(request).GetAwaiter().GetResult();
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
            public System.String Owner_DisplayName { get; set; }
            public System.String Owner_Id { get; set; }
            public List<Amazon.S3.Model.S3Grant> AccessControlList_Grant { get; set; }
            public Amazon.S3.S3CannedACL CannedACL { get; set; }
            public System.String BucketName { get; set; }
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.String Key { get; set; }
            public System.String VersionId { get; set; }
            public System.Func<Amazon.S3.Model.PutACLResponse, SetS3ACLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
