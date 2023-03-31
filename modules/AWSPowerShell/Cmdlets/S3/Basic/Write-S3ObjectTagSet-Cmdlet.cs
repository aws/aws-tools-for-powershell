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
    /// Amazon.S3.IAmazonS3.PutObjectTagging
    /// </summary>
    [Cmdlet("Write", "S3ObjectTagSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutObjectTagging API operation.", Operation = new[] {"PutObjectTagging"}, SelectReturnType = typeof(Amazon.S3.Model.PutObjectTaggingResponse))]
    [AWSCmdletOutput("System.String or Amazon.S3.Model.PutObjectTaggingResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.S3.Model.PutObjectTaggingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3ObjectTagSetCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name containing the object. </para><para>When using this action with an access point, you must direct requests to the access
        /// point hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.</para><para>When you use this action with Amazon S3 on Outposts, you must direct requests to the
        /// S3 on Outposts hostname. The S3 on Outposts hostname takes the form <code><i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</code>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the bucket is owned by a different
        /// account, the request will fail with an HTTP <code>403 (Access Denied)</code> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// This key is used to identify the object in S3.
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
        
        #region Parameter Tagging_TagSet
        /// <summary>
        /// <para>
        /// TagSet
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3.Model.Tag[] Tagging_TagSet { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>The versionId of the object that the tag-set will be added to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VersionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutObjectTaggingResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.PutObjectTaggingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VersionId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3ObjectTagSet (PutObjectTagging)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutObjectTaggingResponse, WriteS3ObjectTagSetCmdlet>(Select) ??
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
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.Key = this.Key;
            context.RequestPayer = this.RequestPayer;
            if (this.Tagging_TagSet != null)
            {
                context.Tagging_TagSet = new List<Amazon.S3.Model.Tag>(this.Tagging_TagSet);
            }
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
            var request = new Amazon.S3.Model.PutObjectTaggingRequest();
            
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
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            
             // populate Tagging
            var requestTaggingIsNull = true;
            request.Tagging = new Amazon.S3.Model.Tagging();
            List<Amazon.S3.Model.Tag> requestTagging_tagging_TagSet = null;
            if (cmdletContext.Tagging_TagSet != null)
            {
                requestTagging_tagging_TagSet = cmdletContext.Tagging_TagSet;
            }
            if (requestTagging_tagging_TagSet != null)
            {
                request.Tagging.TagSet = requestTagging_tagging_TagSet;
                requestTaggingIsNull = false;
            }
             // determine if request.Tagging should be set to null
            if (requestTaggingIsNull)
            {
                request.Tagging = null;
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
        
        private Amazon.S3.Model.PutObjectTaggingResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutObjectTaggingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutObjectTagging");
            try
            {
                #if DESKTOP
                return client.PutObjectTagging(request);
                #elif CORECLR
                return client.PutObjectTaggingAsync(request).GetAwaiter().GetResult();
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
            public System.String ExpectedBucketOwner { get; set; }
            public System.String Key { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public List<Amazon.S3.Model.Tag> Tagging_TagSet { get; set; }
            public System.String VersionId { get; set; }
            public System.Func<Amazon.S3.Model.PutObjectTaggingResponse, WriteS3ObjectTagSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VersionId;
        }
        
    }
}
