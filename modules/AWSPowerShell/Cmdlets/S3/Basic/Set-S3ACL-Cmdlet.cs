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
    /// Amazon.S3.IAmazonS3.PutACL
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
        /// The display name of the owner.
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
        /// <para>When using this API with an access point, you must direct requests to the access point hostname. 
        /// The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com. 
        /// When using this operation with an access point through the AWS SDKs, you provide the access point ARN in place of the bucket name. 
        /// For more information about access point ARNs, see 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-access-points.html">Using Access Points</a> in the <i>Amazon Simple Storage Service Developer Guide</i>.</para><para>When using this API with Amazon S3 on Outposts, you must direct requests to the S3 on Outposts hostname. 
        /// The S3 on Outposts hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com. 
        /// When using this operation using S3 on Outposts through the AWS SDKs, you provide the Outposts bucket ARN in place of the bucket name. 
        /// For more information about S3 on Outposts ARNs, see 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/S3onOutposts.html">Using S3 on Outposts</a> in the <i>Amazon Simple Storage Service Developer Guide</i>.</para>
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
