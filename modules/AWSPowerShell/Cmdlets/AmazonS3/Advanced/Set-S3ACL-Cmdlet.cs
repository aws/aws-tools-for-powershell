/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Sets an S3AccessControlList on the specified bucket or object.
    /// </summary>
    [Cmdlet("Set", "S3ACL", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType(new Type[] { typeof(string) })]
    [AWSCmdlet("Invokes the SetACL operation against Amazon S3.", Operation = new [] {"SetACL"})]
    [AWSCmdletOutput("String",
                     "This cmdlet returns the version ID of the S3 object.",
                     "The service response (type Amazon.S3.Model.SetACLResponse) is added to the cmdlet entry in the $AWSHistory stack."
                        + " Additionally, the following properties are added as notes to the response: Headers of type System.Net.WebHeaderCollection"
    )]
    public class SetS3ACLCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        #region Parameter BucketName 
        /// <summary>
        /// The name of the bucket. If an object key is not specified, the ACLs are applied to the bucket.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String BucketName { get; set; }
        #endregion

        #region Parameter Key
        /// <summary>
        /// The key of an S3 object. If not specified, the ACLs are applied to the bucket.
        /// </summary>
        [Parameter(Position = 1, ValueFromPipelineByPropertyName=true)]
        public System.String Key { get; set; }
        #endregion

        #region Parameter CannedACLName
        /// <summary>
        /// Specifies the canned ACL (access control list) of permissions to be applied to the S3 bucket.
        /// Please refer to <a href="http://docs.aws.amazon.com/sdkfornet/v3/apidocs/Index.html?page=S3/TS3_S3CannedACL.html&tocid=Amazon_S3_S3CannedACL">Amazon.S3.Model.S3CannedACL</a> for information on S3 Canned ACLs.
        /// </summary>
        [Parameter]
        [AWSConstantClassSource("Amazon.S3.S3CannedACL")]
        public Amazon.S3.S3CannedACL CannedACLName { get; set; }
        #endregion

        #region Parameter PublicReadOnly
        /// <summary>
        /// If set, applies an ACL making the bucket public with read-only permissions
        /// </summary>
        [Parameter]
        public SwitchParameter PublicReadOnly { get; set; }
        #endregion

        #region Parameter PublicReadWrite
        /// <summary>
        /// If set, applies an ACL making the bucket public with read-write permissions
        /// </summary>
        [Parameter]
        public SwitchParameter PublicReadWrite { get; set; }
        #endregion

        #region Parameter OwnerId
        /// <summary>
        /// The unique identifier of the bucket owner.
        /// </summary>
        [Parameter(Position = 3)]
        [Alias("ACL_Owner_Id")]
        public System.String OwnerId { get; set; }
        #endregion

        #region Parameter OwnerDisplayName
        /// <summary>
        /// The display name of the bucket owner.
        /// </summary>
        [Parameter(Position = 4)]
        [Alias("ACL_Owner_DisplayName")]
        public System.String OwnerDisplayName { get; set; }
        #endregion

        #region Parameter Grant 
        /// <summary>
        /// A collection of grants, where each Grant is a Grantee and a Permission.
        /// </summary>
        [Parameter(Position = 5)]
        [Alias("ACL_Grants,Grants")]
        public System.Collections.Generic.List<Amazon.S3.Model.S3Grant> Grant { get; set; }
        #endregion

        #region Parameter VersionId
        /// <summary>
        /// If set and an object key has been specified, the ACLs are applied
        /// to the specific version of the object.
        /// This property is ignored if the ACL is to be set on a Bucket.
        /// </summary>
        [Parameter(Position = 6, ValueFromPipelineByPropertyName=true)]
        public System.String VersionId { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }
        #endregion

        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }

        #endregion

        #region Parameter UseDualstackEndpoint
        /// <summary>
        /// Configures the request to Amazon S3 to use the dualstack endpoint for a region.
        /// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.
        /// The dualstack mode of Amazon S3 cannot be used with accelerate mode.
        /// </summary>
        [Parameter]
        public SwitchParameter UseDualstackEndpoint { get; set; }

        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.Key, "Set-S3ACL (SetACL)"))
                return;

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                BucketName = this.BucketName,
                Key = AmazonS3Helper.CleanKey(this.Key),
                ACL_Owner_Id = this.OwnerId,
                ACL_Owner_DisplayName = this.OwnerDisplayName,
                ACL_Grants = this.Grant,
                VersionId = this.VersionId
            };


            if (!string.IsNullOrEmpty(this.CannedACLName))
            {
                context.CannedACL = this.CannedACLName;
            }
            else if (this.PublicReadOnly.IsPresent)
            {
                context.CannedACL = S3CannedACL.PublicRead;
            }
            else if (this.PublicReadWrite.IsPresent)
            {
                context.CannedACL = S3CannedACL.PublicReadWrite;
            }
            
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new PutACLRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            
            if (cmdletContext.CannedACL != null)
            {
                request.CannedACL = cmdletContext.CannedACL.Value;
            }
            else
            {
                // populate ACL
                bool requestACLIsNull = true;
                request.AccessControlList = new S3AccessControlList();
                List<S3Grant> requestACL_aCL_Grants = null;
                if (cmdletContext.ACL_Grants != null)
                {
                    requestACL_aCL_Grants = cmdletContext.ACL_Grants;
                }
                if (requestACL_aCL_Grants != null)
                {
                    request.AccessControlList.Grants = requestACL_aCL_Grants;
                    requestACLIsNull = false;
                }
                Owner requestACL_aCL_Owner = null;

                // populate Owner
                bool requestACL_aCL_OwnerIsNull = true;
                requestACL_aCL_Owner = new Owner();
                String requestACL_aCL_Owner_aCL_Owner_Id = null;
                if (cmdletContext.ACL_Owner_Id != null)
                {
                    requestACL_aCL_Owner_aCL_Owner_Id = cmdletContext.ACL_Owner_Id;
                }
                if (requestACL_aCL_Owner_aCL_Owner_Id != null)
                {
                    requestACL_aCL_Owner.Id = requestACL_aCL_Owner_aCL_Owner_Id;
                    requestACL_aCL_OwnerIsNull = false;
                }
                String requestACL_aCL_Owner_aCL_Owner_DisplayName = null;
                if (cmdletContext.ACL_Owner_DisplayName != null)
                {
                    requestACL_aCL_Owner_aCL_Owner_DisplayName = cmdletContext.ACL_Owner_DisplayName;
                }
                if (requestACL_aCL_Owner_aCL_Owner_DisplayName != null)
                {
                    requestACL_aCL_Owner.DisplayName = requestACL_aCL_Owner_aCL_Owner_DisplayName;
                    requestACL_aCL_OwnerIsNull = false;
                }
                // determine if requestACL_aCL_Owner should be set to null
                if (requestACL_aCL_OwnerIsNull)
                {
                    requestACL_aCL_Owner = null;
                }
                if (requestACL_aCL_Owner != null)
                {
                    request.AccessControlList.Owner = requestACL_aCL_Owner;
                    requestACLIsNull = false;
                }
                if (requestACLIsNull)
                {
                    request.AccessControlList = null;
                }
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
            }

            // issue call
            using (var client = Client ?? CreateClient(context.Credentials, context.Region))
            {
                CmdletOutput output;
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    output = new CmdletOutput
                    {
                        ServiceResponse = response
                    };
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
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

        private static Amazon.S3.Model.PutACLResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutACLRequest request)
        {
#if DESKTOP
            return client.PutACL(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutACLAsync(request);
            return task.Result;
#else
#error "Unknown build edition"
#endif
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }
            public String Key { get; set; }
            public S3CannedACL CannedACL { get; set; }
            public String ACL_Owner_Id { get; set; }
            public String ACL_Owner_DisplayName { get; set; }
            public List<S3Grant> ACL_Grants { get; set; }
            public String VersionId { get; set; }
        }
        
    }
}
