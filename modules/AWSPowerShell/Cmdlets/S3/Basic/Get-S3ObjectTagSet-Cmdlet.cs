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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <note><para>
    /// This operation is not supported for directory buckets.
    /// </para></note><para>
    /// Returns the tag-set of an object. You send the GET request against the tagging subresource
    /// associated with the object.
    /// </para><para>
    /// To use this operation, you must have permission to perform the <c>s3:GetObjectTagging</c>
    /// action. By default, the GET action returns information about current version of an
    /// object. For a versioned bucket, you can have multiple versions of an object in your
    /// bucket. To retrieve tags of any other version, use the versionId query parameter.
    /// You also need permission for the <c>s3:GetObjectVersionTagging</c> action.
    /// </para><para>
    ///  By default, the bucket owner has this permission and can grant this permission to
    /// others.
    /// </para><para>
    ///  For information about the Amazon S3 object tagging feature, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/object-tagging.html">Object
    /// Tagging</a>.
    /// </para><para>
    /// The following actions are related to <c>GetObjectTagging</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteObjectTagging.html">DeleteObjectTagging</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectAttributes.html">GetObjectAttributes</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutObjectTagging.html">PutObjectTagging</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "S3ObjectTagSet")]
    [OutputType("Amazon.S3.Model.Tag")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) GetObjectTagging API operation.", Operation = new[] {"GetObjectTagging"}, SelectReturnType = typeof(Amazon.S3.Model.GetObjectTaggingResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.Tag or Amazon.S3.Model.GetObjectTaggingResponse",
        "This cmdlet returns a collection of Amazon.S3.Model.Tag objects.",
        "The service call response (type Amazon.S3.Model.GetObjectTaggingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3ObjectTagSetCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name containing the object for which to get the tagging information. </para><para><b>Access points</b> - When you use this action with an access point, you must provide
        /// the alias of the access point in place of the bucket name or specify the access point
        /// ARN. When using the access point ARN, you must direct requests to the access point
        /// hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.</para><para><b>S3 on Outposts</b> - When you use this action with Amazon S3 on Outposts, you
        /// must direct requests to the S3 on Outposts hostname. The S3 on Outposts hostname takes
        /// the form <code><i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</code>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts?</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <code>403 Forbidden</code> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>Object key for which to get the tagging information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter RequestPayer
        /// <summary>
        /// <para>
        /// <para>Confirms that the requester knows that they will be charged for the request. 
        /// Bucket owners need not specify this parameter in their requests</para>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.RequestPayer")]
        public Amazon.S3.RequestPayer RequestPayer { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>The versionId of the object for which to get the tagging information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Tagging'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.GetObjectTaggingResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.GetObjectTaggingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Tagging";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Key parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Key' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Key' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.GetObjectTaggingResponse, GetS3ObjectTagSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Key;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.Key = this.Key;
            context.RequestPayer = this.RequestPayer;
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
            var request = new Amazon.S3.Model.GetObjectTaggingRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
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
        
        private Amazon.S3.Model.GetObjectTaggingResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.GetObjectTaggingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "GetObjectTagging");
            try
            {
                #if DESKTOP
                return client.GetObjectTagging(request);
                #elif CORECLR
                return client.GetObjectTaggingAsync(request).GetAwaiter().GetResult();
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
            public System.String ExpectedBucketOwner { get; set; }
            public System.String Key { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String VersionId { get; set; }
            public System.Func<Amazon.S3.Model.GetObjectTaggingResponse, GetS3ObjectTagSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Tagging;
        }
        
    }
}
