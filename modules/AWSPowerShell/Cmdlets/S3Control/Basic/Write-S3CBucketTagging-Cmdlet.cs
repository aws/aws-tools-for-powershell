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
using Amazon.S3Control;
using Amazon.S3Control.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// <note><para>
    /// This action puts tags on an Amazon S3 on Outposts bucket. To put tags on an S3 bucket,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketTagging.html">PutBucketTagging</a>
    /// in the <i>Amazon S3 API Reference</i>. 
    /// </para></note><para>
    /// Sets the tags for an S3 on Outposts bucket. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">Using
    /// Amazon S3 on Outposts</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// Use tags to organize your Amazon Web Services bill to reflect your own cost structure.
    /// To do this, sign up to get your Amazon Web Services account bill with tag key values
    /// included. Then, to see the cost of combined resources, organize your billing information
    /// according to resources with the same tag key values. For example, you can tag several
    /// resources with a specific application name, and then organize your billing information
    /// to see the total cost of that application across several services. For more information,
    /// see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html">Cost
    /// allocation and tagging</a>.
    /// </para><note><para>
    /// Within a bucket, if you add a tag that has the same key as an existing tag, the new
    /// value overwrites the old value. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/CostAllocTagging.html">
    /// Using cost allocation in Amazon S3 bucket tags</a>.
    /// </para></note><para>
    /// To use this action, you must have permissions to perform the <c>s3-outposts:PutBucketTagging</c>
    /// action. The Outposts bucket owner has this permission by default and can grant this
    /// permission to others. For more information about permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-with-s3-actions.html#using-with-s3-actions-related-to-bucket-subresources">
    /// Permissions Related to Bucket Subresource Operations</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-access-control.html">Managing
    /// access permissions to your Amazon S3 resources</a>.
    /// </para><para><c>PutBucketTagging</c> has the following special errors:
    /// </para><ul><li><para>
    /// Error code: <c>InvalidTagError</c></para><ul><li><para>
    /// Description: The tag provided was not a valid tag. This error can occur if the tag
    /// did not pass input validation. For information about tag restrictions, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/allocation-tag-restrictions.html">
    /// User-Defined Tag Restrictions</a> and <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/aws-tag-restrictions.html">
    /// Amazon Web Services-Generated Cost Allocation Tag Restrictions</a>.
    /// </para></li></ul></li><li><para>
    /// Error code: <c>MalformedXMLError</c></para><ul><li><para>
    /// Description: The XML provided does not match the schema.
    /// </para></li></ul></li><li><para>
    /// Error code: <c>OperationAbortedError </c></para><ul><li><para>
    /// Description: A conflicting conditional action is currently in progress against this
    /// resource. Try again.
    /// </para></li></ul></li><li><para>
    /// Error code: <c>InternalError</c></para><ul><li><para>
    /// Description: The service was unable to apply the provided tag to the bucket.
    /// </para></li></ul></li></ul><para>
    /// All Amazon S3 on Outposts REST API requests for this action require an additional
    /// parameter of <c>x-amz-outpost-id</c> to be passed with the request. In addition, you
    /// must use an S3 on Outposts endpoint hostname prefix instead of <c>s3-control</c>.
    /// For an example of the request syntax for Amazon S3 on Outposts that uses the S3 on
    /// Outposts endpoint hostname prefix and the <c>x-amz-outpost-id</c> derived by using
    /// the access point ARN, see the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_PutBucketTagging.html#API_control_PutBucketTagging_Examples">Examples</a>
    /// section.
    /// </para><para>
    /// The following actions are related to <c>PutBucketTagging</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetBucketTagging.html">GetBucketTagging</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_DeleteBucketTagging.html">DeleteBucketTagging</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3CBucketTagging", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Control PutBucketTagging API operation.", Operation = new[] {"PutBucketTagging"}, SelectReturnType = typeof(Amazon.S3Control.Model.PutBucketTaggingResponse))]
    [AWSCmdletOutput("None or Amazon.S3Control.Model.PutBucketTaggingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Control.Model.PutBucketTaggingResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3CBucketTaggingCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the Outposts bucket.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the bucket.</para><para>For using this parameter with Amazon S3 on Outposts with the REST API, you must specify
        /// the name and the x-amz-outpost-id as well.</para><para>For using this parameter with S3 on Outposts with the Amazon Web Services SDK and
        /// CLI, you must specify the ARN of the bucket accessed in the format <c>arn:aws:s3-outposts:&lt;Region&gt;:&lt;account-id&gt;:outpost/&lt;outpost-id&gt;/bucket/&lt;my-bucket-name&gt;</c>.
        /// For example, to access the bucket <c>reports</c> through Outpost <c>my-outpost</c>
        /// owned by account <c>123456789012</c> in Region <c>us-west-2</c>, use the URL encoding
        /// of <c>arn:aws:s3-outposts:us-west-2:123456789012:outpost/my-outpost/bucket/reports</c>.
        /// The value must be URL encoded. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Bucket { get; set; }
        #endregion
        
        #region Parameter Tagging_TagSet
        /// <summary>
        /// <para>
        /// <para>A collection for a set of tags.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.S3Control.Model.S3Tag[] Tagging_TagSet { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.PutBucketTaggingResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3CBucketTagging (PutBucketTagging)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.PutBucketTaggingResponse, WriteS3CBucketTaggingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Bucket = this.Bucket;
            #if MODULAR
            if (this.Bucket == null && ParameterWasBound(nameof(this.Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tagging_TagSet != null)
            {
                context.Tagging_TagSet = new List<Amazon.S3Control.Model.S3Tag>(this.Tagging_TagSet);
            }
            #if MODULAR
            if (this.Tagging_TagSet == null && ParameterWasBound(nameof(this.Tagging_TagSet)))
            {
                WriteWarning("You are passing $null as a value for parameter Tagging_TagSet which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.S3Control.Model.PutBucketTaggingRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.Bucket != null)
            {
                request.Bucket = cmdletContext.Bucket;
            }
            
             // populate Tagging
            var requestTaggingIsNull = true;
            request.Tagging = new Amazon.S3Control.Model.Tagging();
            List<Amazon.S3Control.Model.S3Tag> requestTagging_tagging_TagSet = null;
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
        
        private Amazon.S3Control.Model.PutBucketTaggingResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.PutBucketTaggingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "PutBucketTagging");
            try
            {
                return client.PutBucketTaggingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String Bucket { get; set; }
            public List<Amazon.S3Control.Model.S3Tag> Tagging_TagSet { get; set; }
            public System.Func<Amazon.S3Control.Model.PutBucketTaggingResponse, WriteS3CBucketTaggingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
