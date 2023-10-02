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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// <note><para>
    /// This action creates an Amazon S3 on Outposts bucket. To create an S3 bucket, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucket.html">Create
    /// Bucket</a> in the <i>Amazon S3 API Reference</i>. 
    /// </para></note><para>
    /// Creates a new Outposts bucket. By creating the bucket, you become the bucket owner.
    /// To create an Outposts bucket, you must have S3 on Outposts. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">Using
    /// Amazon S3 on Outposts</a> in <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// Not every string is an acceptable bucket name. For information on bucket naming restrictions,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/BucketRestrictions.html#bucketnamingrules">Working
    /// with Amazon S3 Buckets</a>.
    /// </para><para>
    /// S3 on Outposts buckets support:
    /// </para><ul><li><para>
    /// Tags
    /// </para></li><li><para>
    /// LifecycleConfigurations for deleting expired objects
    /// </para></li></ul><para>
    /// For a complete list of restrictions and Amazon S3 feature limitations on S3 on Outposts,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3OnOutpostsRestrictionsLimitations.html">
    /// Amazon S3 on Outposts Restrictions and Limitations</a>.
    /// </para><para>
    /// For an example of the request syntax for Amazon S3 on Outposts that uses the S3 on
    /// Outposts endpoint hostname prefix and <code>x-amz-outpost-id</code> in your API request,
    /// see the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_CreateBucket.html#API_control_CreateBucket_Examples">Examples</a>
    /// section.
    /// </para><para>
    /// The following actions are related to <code>CreateBucket</code> for Amazon S3 on Outposts:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutObject.html">PutObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetBucket.html">GetBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_DeleteBucket.html">DeleteBucket</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_CreateAccessPoint.html">CreateAccessPoint</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_PutAccessPointPolicy.html">PutAccessPointPolicy</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "S3CBucket", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Control.Model.CreateBucketResponse")]
    [AWSCmdlet("Calls the Amazon S3 Control CreateBucket API operation.", Operation = new[] {"CreateBucket"}, SelectReturnType = typeof(Amazon.S3Control.Model.CreateBucketResponse))]
    [AWSCmdletOutput("Amazon.S3Control.Model.CreateBucketResponse",
        "This cmdlet returns an Amazon.S3Control.Model.CreateBucketResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewS3CBucketCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ACL
        /// <summary>
        /// <para>
        /// <para>The canned ACL to apply to the bucket.</para><note><para>This is not supported by Amazon S3 on Outposts buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.BucketCannedACL")]
        public Amazon.S3Control.BucketCannedACL ACL { get; set; }
        #endregion
        
        #region Parameter Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the bucket.</para>
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
        public System.String Bucket { get; set; }
        #endregion
        
        #region Parameter GrantFullControl
        /// <summary>
        /// <para>
        /// <para>Allows grantee the read, write, read ACP, and write ACP permissions on the bucket.</para><note><para>This is not supported by Amazon S3 on Outposts buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantFullControl { get; set; }
        #endregion
        
        #region Parameter GrantRead
        /// <summary>
        /// <para>
        /// <para>Allows grantee to list the objects in the bucket.</para><note><para>This is not supported by Amazon S3 on Outposts buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantRead { get; set; }
        #endregion
        
        #region Parameter GrantReadACP
        /// <summary>
        /// <para>
        /// <para>Allows grantee to read the bucket ACL.</para><note><para>This is not supported by Amazon S3 on Outposts buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantReadACP { get; set; }
        #endregion
        
        #region Parameter GrantWrite
        /// <summary>
        /// <para>
        /// <para>Allows grantee to create, overwrite, and delete any object in the bucket.</para><note><para>This is not supported by Amazon S3 on Outposts buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantWrite { get; set; }
        #endregion
        
        #region Parameter GrantWriteACP
        /// <summary>
        /// <para>
        /// <para>Allows grantee to write the ACL for the applicable bucket.</para><note><para>This is not supported by Amazon S3 on Outposts buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantWriteACP { get; set; }
        #endregion
        
        #region Parameter CreateBucketConfiguration_LocationConstraint
        /// <summary>
        /// <para>
        /// <para>Specifies the Region where the bucket will be created. If you are creating a bucket
        /// on the US East (N. Virginia) Region (us-east-1), you do not need to specify the location.
        /// </para><note><para>This is not supported by Amazon S3 on Outposts buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.BucketLocationConstraint")]
        public Amazon.S3Control.BucketLocationConstraint CreateBucketConfiguration_LocationConstraint { get; set; }
        #endregion
        
        #region Parameter ObjectLockEnabledForBucket
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want S3 Object Lock to be enabled for the new bucket.</para><note><para>This is not supported by Amazon S3 on Outposts buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ObjectLockEnabledForBucket { get; set; }
        #endregion
        
        #region Parameter OutpostId
        /// <summary>
        /// <para>
        /// <para>The ID of the Outposts where the bucket is being created.</para><note><para>This ID is required by Amazon S3 on Outposts buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutpostId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.CreateBucketResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.CreateBucketResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Bucket parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Bucket' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Bucket' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutpostId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3CBucket (CreateBucket)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.CreateBucketResponse, NewS3CBucketCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Bucket;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ACL = this.ACL;
            context.Bucket = this.Bucket;
            #if MODULAR
            if (this.Bucket == null && ParameterWasBound(nameof(this.Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CreateBucketConfiguration_LocationConstraint = this.CreateBucketConfiguration_LocationConstraint;
            context.GrantFullControl = this.GrantFullControl;
            context.GrantRead = this.GrantRead;
            context.GrantReadACP = this.GrantReadACP;
            context.GrantWrite = this.GrantWrite;
            context.GrantWriteACP = this.GrantWriteACP;
            context.ObjectLockEnabledForBucket = this.ObjectLockEnabledForBucket;
            context.OutpostId = this.OutpostId;
            
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
            var request = new Amazon.S3Control.Model.CreateBucketRequest();
            
            if (cmdletContext.ACL != null)
            {
                request.ACL = cmdletContext.ACL;
            }
            if (cmdletContext.Bucket != null)
            {
                request.Bucket = cmdletContext.Bucket;
            }
            
             // populate CreateBucketConfiguration
            var requestCreateBucketConfigurationIsNull = true;
            request.CreateBucketConfiguration = new Amazon.S3Control.Model.CreateBucketConfiguration();
            Amazon.S3Control.BucketLocationConstraint requestCreateBucketConfiguration_createBucketConfiguration_LocationConstraint = null;
            if (cmdletContext.CreateBucketConfiguration_LocationConstraint != null)
            {
                requestCreateBucketConfiguration_createBucketConfiguration_LocationConstraint = cmdletContext.CreateBucketConfiguration_LocationConstraint;
            }
            if (requestCreateBucketConfiguration_createBucketConfiguration_LocationConstraint != null)
            {
                request.CreateBucketConfiguration.LocationConstraint = requestCreateBucketConfiguration_createBucketConfiguration_LocationConstraint;
                requestCreateBucketConfigurationIsNull = false;
            }
             // determine if request.CreateBucketConfiguration should be set to null
            if (requestCreateBucketConfigurationIsNull)
            {
                request.CreateBucketConfiguration = null;
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
            if (cmdletContext.ObjectLockEnabledForBucket != null)
            {
                request.ObjectLockEnabledForBucket = cmdletContext.ObjectLockEnabledForBucket.Value;
            }
            if (cmdletContext.OutpostId != null)
            {
                request.OutpostId = cmdletContext.OutpostId;
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
        
        private Amazon.S3Control.Model.CreateBucketResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.CreateBucketRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "CreateBucket");
            try
            {
                #if DESKTOP
                return client.CreateBucket(request);
                #elif CORECLR
                return client.CreateBucketAsync(request).GetAwaiter().GetResult();
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
            public Amazon.S3Control.BucketCannedACL ACL { get; set; }
            public System.String Bucket { get; set; }
            public Amazon.S3Control.BucketLocationConstraint CreateBucketConfiguration_LocationConstraint { get; set; }
            public System.String GrantFullControl { get; set; }
            public System.String GrantRead { get; set; }
            public System.String GrantReadACP { get; set; }
            public System.String GrantWrite { get; set; }
            public System.String GrantWriteACP { get; set; }
            public System.Boolean? ObjectLockEnabledForBucket { get; set; }
            public System.String OutpostId { get; set; }
            public System.Func<Amazon.S3Control.Model.CreateBucketResponse, NewS3CBucketCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
