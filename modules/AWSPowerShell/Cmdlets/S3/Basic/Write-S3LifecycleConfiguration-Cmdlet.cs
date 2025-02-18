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

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Creates a new lifecycle configuration for the bucket or replaces an existing lifecycle
    /// configuration. Keep in mind that this will overwrite an existing lifecycle configuration,
    /// so if you want to retain any configuration details, they must be included in the new
    /// lifecycle configuration. For information about lifecycle configuration, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/object-lifecycle-mgmt.html">Managing
    /// your storage lifecycle</a>.
    /// 
    ///  <note><para>
    /// Bucket lifecycle configuration now supports specifying a lifecycle rule using an object
    /// key name prefix, one or more object tags, object size, or any combination of these.
    /// Accordingly, this section describes the latest API. The previous version of the API
    /// supported filtering based only on an object key name prefix, which is supported for
    /// backward compatibility. For the related API description, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketLifecycle.html">PutBucketLifecycle</a>.
    /// </para></note><dl><dt>Rules</dt><dt>Permissions</dt><dt>HTTP Host header syntax</dt><dd><para>
    /// You specify the lifecycle configuration in your request body. The lifecycle configuration
    /// is specified as XML consisting of one or more rules. An Amazon S3 Lifecycle configuration
    /// can have up to 1,000 rules. This limit is not adjustable.
    /// </para><para>
    /// Bucket lifecycle configuration supports specifying a lifecycle rule using an object
    /// key name prefix, one or more object tags, object size, or any combination of these.
    /// Accordingly, this section describes the latest API. The previous version of the API
    /// supported filtering based only on an object key name prefix, which is supported for
    /// backward compatibility for general purpose buckets. For the related API description,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketLifecycle.html">PutBucketLifecycle</a>.
    /// 
    /// </para><note><para>
    /// Lifecyle configurations for directory buckets only support expiring objects and cancelling
    /// multipart uploads. Expiring of versioned objects,transitions and tag filters are not
    /// supported.
    /// </para></note><para>
    /// A lifecycle rule consists of the following:
    /// </para><ul><li><para>
    /// A filter identifying a subset of objects to which the rule applies. The filter can
    /// be based on a key name prefix, object tags, object size, or any combination of these.
    /// </para></li><li><para>
    /// A status indicating whether the rule is in effect.
    /// </para></li><li><para>
    /// One or more lifecycle transition and expiration actions that you want Amazon S3 to
    /// perform on the objects identified by the filter. If the state of your bucket is versioning-enabled
    /// or versioning-suspended, you can have many versions of the same object (one current
    /// version and zero or more noncurrent versions). Amazon S3 provides predefined actions
    /// that you can specify for current and noncurrent object versions.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/object-lifecycle-mgmt.html">Object
    /// Lifecycle Management</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/intro-lifecycle-rules.html">Lifecycle
    /// Configuration Elements</a>.
    /// </para></dd><dd><ul><li><para><b>General purpose bucket permissions</b> - By default, all Amazon S3 resources are
    /// private, including buckets, objects, and related subresources (for example, lifecycle
    /// configuration and website configuration). Only the resource owner (that is, the Amazon
    /// Web Services account that created it) can access the resource. The resource owner
    /// can optionally grant access permissions to others by writing an access policy. For
    /// this operation, a user must have the <c>s3:PutLifecycleConfiguration</c> permission.
    /// </para><para>
    /// You can also explicitly deny permissions. An explicit deny also supersedes any other
    /// permissions. If you want to block users or accounts from removing or deleting objects
    /// from your bucket, you must deny them permissions for the following actions:
    /// </para><ul><li><para><c>s3:DeleteObject</c></para></li><li><para><c>s3:DeleteObjectVersion</c></para></li><li><para><c>s3:PutLifecycleConfiguration</c></para><para>
    /// For more information about permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-access-control.html">Managing
    /// Access Permissions to Your Amazon S3 Resources</a>.
    /// </para></li></ul></li></ul><ul><li><para><b>Directory bucket permissions</b> - You must have the <c>s3express:PutLifecycleConfiguration</c>
    /// permission in an IAM identity-based policy to use this operation. Cross-account access
    /// to this API operation isn't supported. The resource owner can optionally grant access
    /// permissions to others by creating a role or user for them as long as they are within
    /// the same account as the owner and resource.
    /// </para><para>
    /// For more information about directory bucket policies and permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-security-iam.html">Authorizing
    /// Regional endpoint APIs with IAM</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><note><para><b>Directory buckets </b> - For directory buckets, you must make requests for this
    /// API operation to the Regional endpoint. These endpoints support path-style requests
    /// in the format <c>https://s3express-control.<i>region-code</i>.amazonaws.com/<i>bucket-name</i></c>. Virtual-hosted-style requests aren't supported. For more information about endpoints
    /// in Availability Zones, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-Regions-and-Zones.html">Regional
    /// and Zonal endpoints for directory buckets in Availability Zones</a> in the <i>Amazon
    /// S3 User Guide</i>. For more information about endpoints in Local Zones, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-lzs-for-directory-buckets.html">Available
    /// Local Zone for directory buckets</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></note></li></ul></dd><dd><para><b>Directory buckets </b> - The HTTP Host header syntax is <c>s3express-control.<i>region</i>.amazonaws.com</c>.
    /// </para><para>
    /// The following operations are related to <c>PutBucketLifecycleConfiguration</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketLifecycleConfiguration.html">GetBucketLifecycleConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketLifecycle.html">DeleteBucketLifecycle</a></para></li></ul></dd></dl>
    /// </summary>
    [Cmdlet("Write", "S3LifecycleConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.TransitionDefaultMinimumObjectSize")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutLifecycleConfiguration API operation.", Operation = new[] {"PutLifecycleConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.PutLifecycleConfigurationResponse))]
    [AWSCmdletOutput("Amazon.S3.TransitionDefaultMinimumObjectSize or Amazon.S3.Model.PutLifecycleConfigurationResponse",
        "This cmdlet returns an Amazon.S3.TransitionDefaultMinimumObjectSize object.",
        "The service call response (type Amazon.S3.Model.PutLifecycleConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteS3LifecycleConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket for which to set the configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
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
        
        #region Parameter Configuration_Rule
        /// <summary>
        /// <para>
        /// These rules defined the lifecycle configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Rules")]
        public Amazon.S3.Model.LifecycleRule[] Configuration_Rule { get; set; }
        #endregion
        
        #region Parameter TransitionDefaultMinimumObjectSize
        /// <summary>
        /// <para>
        /// <para>Indicates which default minimum object size behavior is applied to the lifecycle configuration.</para><ul><li><para><c>all_storage_classes_128K</c> - Objects smaller than 128 KB will not transition
        /// to any storage class by default. </para></li><li><para><c>varies_by_storage_class</c> - Objects smaller than 128 KB will transition to Glacier
        /// Flexible Retrieval or Glacier Deep Archive storage classes. By default, all other
        /// storage classes will prevent transitions smaller than 128 KB. </para></li></ul><para>To customize the minimum object size for any transition you can add a filter that
        /// specifies a custom <c>ObjectSizeGreaterThan</c> or <c>ObjectSizeLessThan</c> in the
        /// body of your transition rule. Custom filters always take precedence over the default
        /// transition behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.TransitionDefaultMinimumObjectSize")]
        public Amazon.S3.TransitionDefaultMinimumObjectSize TransitionDefaultMinimumObjectSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitionDefaultMinimumObjectSize'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutLifecycleConfigurationResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.PutLifecycleConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitionDefaultMinimumObjectSize";
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
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3LifecycleConfiguration (PutLifecycleConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutLifecycleConfigurationResponse, WriteS3LifecycleConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            if (this.Configuration_Rule != null)
            {
                context.Configuration_Rule = new List<Amazon.S3.Model.LifecycleRule>(this.Configuration_Rule);
            }
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.TransitionDefaultMinimumObjectSize = this.TransitionDefaultMinimumObjectSize;
            
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
            var request = new Amazon.S3.Model.PutLifecycleConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.S3.Model.LifecycleConfiguration();
            List<Amazon.S3.Model.LifecycleRule> requestConfiguration_configuration_Rule = null;
            if (cmdletContext.Configuration_Rule != null)
            {
                requestConfiguration_configuration_Rule = cmdletContext.Configuration_Rule;
            }
            if (requestConfiguration_configuration_Rule != null)
            {
                request.Configuration.Rules = requestConfiguration_configuration_Rule;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.TransitionDefaultMinimumObjectSize != null)
            {
                request.TransitionDefaultMinimumObjectSize = cmdletContext.TransitionDefaultMinimumObjectSize;
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
        
        private Amazon.S3.Model.PutLifecycleConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutLifecycleConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutLifecycleConfiguration");
            try
            {
                return client.PutLifecycleConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.S3.Model.LifecycleRule> Configuration_Rule { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public Amazon.S3.TransitionDefaultMinimumObjectSize TransitionDefaultMinimumObjectSize { get; set; }
            public System.Func<Amazon.S3.Model.PutLifecycleConfigurationResponse, WriteS3LifecycleConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitionDefaultMinimumObjectSize;
        }
        
    }
}
