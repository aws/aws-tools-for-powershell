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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3.Model;
using Amazon.S3;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <para>
    /// Deletes the specified object, object version or set of objects from S3. The DeleteObject operation removes 
    /// the specified object from Amazon S3.Once deleted, there is no method to restore or undelete an object.
    /// </para>
    /// <para>
    /// You can pipe Amazon.S3.Model.S3Object or Amazon.S3.Model.S3ObjectVersion instances to this cmdlet and their 
    /// members will be used to satisfy the BucketName, Key (and VersionId if an S3ObjectVersion instance is supplied) 
    /// parameters.
    /// <br/><br/>
    /// <b>Note: </b>When piping a collection of Amazon.S3.Model.S3Object or Amazon.S3.Model.S3ObjectVersion instances
    /// to identify the objects to be deleted the cmdlet receives the elements from the piped collection 
    /// one element at a time and will therefore make one service call per collection element to be deleted. To perform 
    /// the deletion as a batch up to 1000 objects with a single call to the service specify the collection as the value 
    /// of the -InputObject parameter. The -KeyCollection and -KeyAndVersionCollection parameters also automatically 
    /// process as a batch and make a single call to the service to delete up to 1000 objects identified in the collections
    /// supplied to the parameters.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "S3Object", DefaultParameterSetName = ParamSet_WithKey, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(typeof(DeleteObjectResponse), typeof(DeleteObjectsResponse))]
    [AWSCmdlet("Deletes one or more objects in an Amazon S3 bucket.", Operation = new [] {"DeleteObjects"})]
    [AWSCmdletOutput("Amazon.S3.Model.DeleteObjectResponse", "When deleting a single object.")]
    [AWSCmdletOutput("Amazon.S3.Model.DeleteObjectsResponse", "When deleting multiple objects.")]
    public class RemoveS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        private const string ParamSet_WithKey = "WithKey";
        private const string ParamSet_WithKeyVersionCollection = "WithKeyVersionCollection";
        private const string ParamSet_WithS3ObjectCollection = "WithS3ObjectCollection";
        private const string ParamSet_WithKeyCollection = "WithKeyCollection";

        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The bucket name of the bucket containing the object. 
        /// </para>
        ///  
        /// <para>
        ///  <b>Directory buckets</b> - When you use this operation with a directory bucket, you
        /// must use virtual-hosted-style requests in the format <c> <i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
        /// Path-style requests are not supported. Directory bucket names must be unique in the
        /// chosen Availability Zone. Bucket names must follow the format <c> <i>bucket_base_name</i>--<i>az-id</i>--x-s3</c>
        /// (for example, <c> <i>DOC-EXAMPLE-BUCKET</i>--<i>usw2-az1</i>--x-s3</c>). For information
        /// about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
        /// bucket naming rules</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  
        /// <para>
        ///  <b>Access points</b> - When you use this action with an access point, you must provide
        /// the alias of the access point in place of the bucket name or specify the access point
        /// ARN. When using the access point ARN, you must direct requests to the access point
        /// hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  <note> 
        /// <para>
        /// Access points and Object Lambda access points are not supported by directory buckets.
        /// </para>
        ///  </note> 
        /// <para>
        ///  <b>S3 on Outposts</b> - When you use this action with Amazon S3 on Outposts, you
        /// must direct requests to the S3 on Outposts hostname. The S3 on Outposts hostname takes
        /// the form <c> <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</c>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts?</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true, ParameterSetName = ParamSet_WithKey)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true, ParameterSetName = ParamSet_WithKeyVersionCollection)]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true, ParameterSetName = ParamSet_WithKeyCollection)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BucketName { get; set; }
        #endregion

        #region Parameter Key
        /// <summary>
        /// The object key identifying the object to be deleted.
        /// </summary>
        [Parameter(Position = 1, ParameterSetName = ParamSet_WithKey, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Key { get; set; }
        #endregion

        #region Parameter VersionId
        /// <summary>
        /// Version identifier of the S3 object to be deleted, for buckets with versioning enabled.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = ParamSet_WithKey, ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion

        #region Parameter VersionKey
        /// <summary>
        /// Collection of Amazon.S3.Model.KeyVersion objects describing the S3 objects to be deleted.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_WithKeyVersionCollection, ValueFromPipelineByPropertyName = true)]
        [Alias("VersionKeys", "VersionKey")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.S3.Model.KeyVersion[] KeyAndVersionCollection { get; set; }
        #endregion

        #region Parameter InputObject
        /// <summary>
        /// Collection of S3Object or S3ObjectVersion instances describing the S3 objects to be deleted. 
        /// <br/>
        /// <b>Note: </b>the objects must all belong to the same bucket.
        /// </summary>
        [Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = ParamSet_WithS3ObjectCollection)]
        [Alias("InputObjects", "S3ObjectCollection")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.S3.Model.S3Object[] InputObject { get; set; }
        #endregion

        #region Parameter KeyCollection
        /// <summary>
        /// Collection of key names describing the S3 objects to be deleted.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ParamSet_WithKeyCollection, ValueFromPipelineByPropertyName = true)]
        [Alias("Keys")]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] KeyCollection { get; set; }
        #endregion

        #region Parameter ReportErrorsOnly
        /// <summary>
        /// <para>
        /// If set when deleting multiple objects the service response will include only those 
        /// keys for objects on which the delete operation failed. By default this switch is not 
        /// set and keys for both successful multi-object deletes and failures are returned in the 
        /// response.
        /// </para>
        /// <para>
        /// This parameter is used only when deleting multiple objects using the <code>-KeyCollection</code>
        /// parameter.
        /// </para>
        /// </summary>
        [Alias("Quiet")]
        [Parameter(ParameterSetName = ParamSet_WithKeyCollection, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_WithS3ObjectCollection, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParamSet_WithKeyVersionCollection, ValueFromPipelineByPropertyName = true)]
        public SwitchParameter ReportErrorsOnly { get; set; }
        #endregion

        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// Indicates the algorithm you want Amazon S3 to use to create the checksum for the object.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">Checking
        /// object integrity</a> in the <i>Amazon S3 User Guide</i>.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_WithKeyVersionCollection)]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ParamSet_WithKeyCollection)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion

        #region Shared Parameters

        #region Parameter SerialNumber
        /// <summary>
        /// <para>
        /// Specifies the serial number of the multi-factor authentication device 
        /// associated with your AWS Account. 
        /// </para>
        /// <para>
        /// This is a required property for this request if:<br />
        /// 1. EnableMfaDelete was configured on the bucket containing this object's version.<br />
        /// 2. You are deleting an object's version
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MfaCodes_First")]
        public System.String SerialNumber { get; set; }
        #endregion

        #region Parameter AuthenticationValue
        /// <summary>
        /// <para>
        /// Specifies the current token/code displayed on the multi-factor authentication device 
        /// associated with your AWS Account. 
        /// </para>
        /// <para>
        /// This is a required property for this request if:<br />
        /// 1. EnableMfaDelete was configured on the bucket containing this object's version.<br />
        /// 2. You are deleting an object's version
        /// </para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MfaCodes_Second")]
        public System.String AuthenticationValue { get; set; }
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

        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var isSingleObjectDelete = this.ParameterSetName == ParamSet_WithKey;

            var context = new CmdletContext
            {
                BucketName = this.BucketName
            };

            string resourceIdentifiersText;
            if (isSingleObjectDelete)
            {
                resourceIdentifiersText = context.Key;

                context.Key = AmazonS3Helper.CleanKey(this.Key);
                base.UserAgentAddition = AmazonS3Helper.GetCleanKeyUserAgentAdditionString(this.Key, context.Key);
                context.VersionId = this.VersionId;
            }
            else
            {
                resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("KeyCollection", MyInvocation.BoundParameters);

                if (this.KeyCollection != null && this.KeyCollection.Length > 0)
                    context.KeyCollection = new List<string>(this.KeyCollection);
                if (this.KeyAndVersionCollection != null && this.KeyAndVersionCollection.Length > 0)
                    context.KeyAndVersionCollection = new List<KeyVersion>(this.KeyAndVersionCollection);
                if (this.InputObject != null && this.InputObject.Length > 0)
                    context.S3ObjectCollection = new List<S3Object>(this.InputObject);

                if (this.ChecksumAlgorithm != null)
                    context.ChecksumAlgorithm = this.ChecksumAlgorithm;

                if (this.ReportErrorsOnly.IsPresent)
                    context.Quiet = true;
            }

            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-S3Object (DeleteObjects)"))
                return;

            context.SerialNumber = this.SerialNumber;
            context.AuthenticationValue = this.AuthenticationValue;

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            if (this.ParameterSetName == ParamSet_WithKey)
                return DeleteSingleS3Object(cmdletContext);
            else
                return DeleteMultiS3Object(cmdletContext);
        }

        CmdletOutput DeleteSingleS3Object(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var request = new DeleteObjectRequest
            {
                BucketName = cmdletContext.BucketName,
                Key = cmdletContext.Key
            };

            if (!string.IsNullOrEmpty(cmdletContext.VersionId))
                request.VersionId = cmdletContext.VersionId;

            if (!string.IsNullOrEmpty(cmdletContext.SerialNumber)
                    && !string.IsNullOrEmpty(cmdletContext.AuthenticationValue))
            {
                request.MfaCodes = new MfaCodes
                {
                    SerialNumber = cmdletContext.SerialNumber,
                    AuthenticationValue = cmdletContext.AuthenticationValue
                };
            }

            using (var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint))
            {
                CmdletOutput output;
                try
                {
                    var response = CallAWSServiceOperation(client, request);

                    output = new CmdletOutput
                    {
                        PipelineOutput = response,
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

        CmdletOutput DeleteMultiS3Object(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var request = new DeleteObjectsRequest
            {
                Quiet = cmdletContext.Quiet,
                ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm
            };

            if (cmdletContext.KeyCollection != null)
            {
                request.BucketName = cmdletContext.BucketName;
                foreach (var key in cmdletContext.KeyCollection)
                {
                    request.AddKey(key);
                }
            }
            else if (cmdletContext.KeyAndVersionCollection != null)
            {
                request.BucketName = cmdletContext.BucketName;
                foreach (var key in cmdletContext.KeyAndVersionCollection)
                {
                    request.AddKey(key.Key, key.VersionId);
                }
            }
            else if (cmdletContext.S3ObjectCollection != null)
            {
                request.BucketName = cmdletContext.S3ObjectCollection[0].BucketName;
                foreach (var s3Object in cmdletContext.S3ObjectCollection)
                {
                    var s3ObjectVersion = s3Object as S3ObjectVersion;
                    if (s3ObjectVersion != null)
                        request.AddKey(s3ObjectVersion.Key, s3ObjectVersion.VersionId);
                    else
                        request.AddKey(s3Object.Key);
                }
            }

            if (!string.IsNullOrEmpty(cmdletContext.SerialNumber)
                    && !string.IsNullOrEmpty(cmdletContext.AuthenticationValue))
            {
                request.MfaCodes = new MfaCodes
                {
                    SerialNumber = cmdletContext.SerialNumber,
                    AuthenticationValue = cmdletContext.AuthenticationValue
                };
            }

            using (var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint))
            {
                CmdletOutput output;
                try
                {
                    var response = CallAWSServiceOperation(client, request);

                    output = new CmdletOutput
                    {
                        PipelineOutput = response.DeletedObjects,
                        ServiceResponse = response,
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

        private Amazon.S3.Model.DeleteObjectResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.DeleteObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3", "DeleteObject");

            try
            {
#if DESKTOP
                return client.DeleteObject(request);
#elif CORECLR
                return client.DeleteObjectAsync(request).GetAwaiter().GetResult();
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

        private Amazon.S3.Model.DeleteObjectsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.DeleteObjectsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3", "DeleteObject");

            try
            {
#if DESKTOP
                return client.DeleteObjects(request);
#elif CORECLR
                return client.DeleteObjectsAsync(request).GetAwaiter().GetResult();
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

        internal class CmdletContext : ExecutorContext
        {
            public String BucketName { get; set; }

            public String Key { get; set; }
            public String VersionId { get; set; }
            
            public Boolean Quiet { get; set; }
            public List<KeyVersion> KeyAndVersionCollection { get; set; }
            public List<S3Object> S3ObjectCollection { get; set; }
            public List<string> KeyCollection { get; set; }

            public String SerialNumber { get; set; }
            public String AuthenticationValue { get; set; }

            public ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        }
    }
}
