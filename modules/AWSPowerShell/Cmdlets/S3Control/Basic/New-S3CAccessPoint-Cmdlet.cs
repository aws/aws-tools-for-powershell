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
    /// Creates an access point and associates it to a specified bucket. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-points.html">Managing
    /// access to shared datasets with access points</a> or <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-points-directory-buckets.html">Managing
    /// access to shared datasets in directory buckets with access points</a> in the <i>Amazon
    /// S3 User Guide</i>.
    /// 
    ///  
    /// <para>
    /// To create an access point and attach it to a volume on an Amazon FSx file system,
    /// see <a href="https://docs.aws.amazon.com/fsx/latest/APIReference/API_CreateAndAttachS3AccessPoint.html">CreateAndAttachS3AccessPoint</a>
    /// in the <i>Amazon FSx API Reference</i>.
    /// </para><note><para>
    /// S3 on Outposts only supports VPC-style access points. 
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">
    /// Accessing Amazon S3 on Outposts using virtual private cloud (VPC) only access points</a>
    /// in the <i>Amazon S3 User Guide</i>.
    /// </para></note><para>
    /// All Amazon S3 on Outposts REST API requests for this action require an additional
    /// parameter of <c>x-amz-outpost-id</c> to be passed with the request. In addition, you
    /// must use an S3 on Outposts endpoint hostname prefix instead of <c>s3-control</c>.
    /// For an example of the request syntax for Amazon S3 on Outposts that uses the S3 on
    /// Outposts endpoint hostname prefix and the <c>x-amz-outpost-id</c> derived by using
    /// the access point ARN, see the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_CreateAccessPoint.html#API_control_CreateAccessPoint_Examples">Examples</a>
    /// section.
    /// </para><para>
    /// The following actions are related to <c>CreateAccessPoint</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetAccessPoint.html">GetAccessPoint</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_DeleteAccessPoint.html">DeleteAccessPoint</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_ListAccessPoints.html">ListAccessPoints</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_ListAccessPointsForDirectoryBuckets.html">ListAccessPointsForDirectoryBuckets</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "S3CAccessPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon S3 Control CreateAccessPoint API operation.", Operation = new[] {"CreateAccessPoint"}, SelectReturnType = typeof(Amazon.S3Control.Model.CreateAccessPointResponse))]
    [AWSCmdletOutput("System.String or Amazon.S3Control.Model.CreateAccessPointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.S3Control.Model.CreateAccessPointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewS3CAccessPointCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID for the account that owns the specified access
        /// point.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_BlockPublicAcl
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should block public access control lists (ACLs) for buckets
        /// in this account. Setting this element to <c>TRUE</c> causes the following behavior:</para><ul><li><para><c>PutBucketAcl</c> and <c>PutObjectAcl</c> calls fail if the specified ACL is public.</para></li><li><para>PUT Object calls fail if the request includes a public ACL.</para></li><li><para>PUT Bucket calls fail if the request includes a public ACL.</para></li></ul><para>Enabling this setting doesn't affect existing policies or ACLs.</para><para>This property is not supported for Amazon S3 on Outposts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicAccessBlockConfiguration_BlockPublicAcls")]
        public System.Boolean? PublicAccessBlockConfiguration_BlockPublicAcl { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_BlockPublicPolicy
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should block public bucket policies for buckets in this
        /// account. Setting this element to <c>TRUE</c> causes Amazon S3 to reject calls to PUT
        /// Bucket policy if the specified bucket policy allows public access. </para><para>Enabling this setting doesn't affect existing bucket policies.</para><para>This property is not supported for Amazon S3 on Outposts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublicAccessBlockConfiguration_BlockPublicPolicy { get; set; }
        #endregion
        
        #region Parameter Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the bucket that you want to associate this access point with.</para><para>For using this parameter with Amazon S3 on Outposts with the REST API, you must specify
        /// the name and the x-amz-outpost-id as well.</para><para>For using this parameter with S3 on Outposts with the Amazon Web Services SDK and
        /// CLI, you must specify the ARN of the bucket accessed in the format <c>arn:aws:s3-outposts:&lt;Region&gt;:&lt;account-id&gt;:outpost/&lt;outpost-id&gt;/bucket/&lt;my-bucket-name&gt;</c>.
        /// For example, to access the bucket <c>reports</c> through Outpost <c>my-outpost</c>
        /// owned by account <c>123456789012</c> in Region <c>us-west-2</c>, use the URL encoding
        /// of <c>arn:aws:s3-outposts:us-west-2:123456789012:outpost/my-outpost/bucket/reports</c>.
        /// The value must be URL encoded. </para>
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
        
        #region Parameter BucketAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the S3 bucket associated with this
        /// access point.</para><para>For same account access point when your bucket and access point belong to the same
        /// account owner, the <c>BucketAccountId</c> is not required. For cross-account access
        /// point when your bucket and access point are not in the same account, the <c>BucketAccountId</c>
        /// is required. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BucketAccountId { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_IgnorePublicAcl
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should ignore public ACLs for buckets in this account.
        /// Setting this element to <c>TRUE</c> causes Amazon S3 to ignore all public ACLs on
        /// buckets in this account and any objects that they contain. </para><para>Enabling this setting doesn't affect the persistence of any existing ACLs and doesn't
        /// prevent new public ACLs from being set.</para><para>This property is not supported for Amazon S3 on Outposts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicAccessBlockConfiguration_IgnorePublicAcls")]
        public System.Boolean? PublicAccessBlockConfiguration_IgnorePublicAcl { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name you want to assign to this access point.</para><para>For directory buckets, the access point name must consist of a base name that you
        /// provide and suffix that includes the <c>ZoneID</c> (Amazon Web Services Availability
        /// Zone or Local Zone) of your bucket location, followed by <c>--xa-s3</c>. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-points-directory-buckets.html">Managing
        /// access to shared datasets in directory buckets with access points</a> in the <i>Amazon
        /// S3 User Guide</i>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Scope_Permission
        /// <summary>
        /// <para>
        /// <para>You can include one or more API operations as permissions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scope_Permissions")]
        public System.String[] Scope_Permission { get; set; }
        #endregion
        
        #region Parameter Scope_Prefix
        /// <summary>
        /// <para>
        /// <para>You can specify any amount of prefixes, but the total length of characters of all
        /// prefixes must be less than 256 bytes in size.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scope_Prefixes")]
        public System.String[] Scope_Prefix { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfiguration_RestrictPublicBucket
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should restrict public bucket policies for buckets in
        /// this account. Setting this element to <c>TRUE</c> restricts access to buckets with
        /// public policies to only Amazon Web Services service principals and authorized users
        /// within this account.</para><para>Enabling this setting doesn't affect previously stored bucket policies, except that
        /// public and cross-account access within any public bucket policy, including non-public
        /// delegation to specific accounts, is blocked.</para><para>This property is not supported for Amazon S3 on Outposts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublicAccessBlockConfiguration_RestrictPublicBuckets")]
        public System.Boolean? PublicAccessBlockConfiguration_RestrictPublicBucket { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_VpcId
        /// <summary>
        /// <para>
        /// <para>If this field is specified, this access point will only allow connections from the
        /// specified VPC ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcConfiguration_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccessPointArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.CreateAccessPointResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.CreateAccessPointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccessPointArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Bucket), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3CAccessPoint (CreateAccessPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.CreateAccessPointResponse, NewS3CAccessPointCmdlet>(Select) ??
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
            context.BucketAccountId = this.BucketAccountId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublicAccessBlockConfiguration_BlockPublicAcl = this.PublicAccessBlockConfiguration_BlockPublicAcl;
            context.PublicAccessBlockConfiguration_BlockPublicPolicy = this.PublicAccessBlockConfiguration_BlockPublicPolicy;
            context.PublicAccessBlockConfiguration_IgnorePublicAcl = this.PublicAccessBlockConfiguration_IgnorePublicAcl;
            context.PublicAccessBlockConfiguration_RestrictPublicBucket = this.PublicAccessBlockConfiguration_RestrictPublicBucket;
            if (this.Scope_Permission != null)
            {
                context.Scope_Permission = new List<System.String>(this.Scope_Permission);
            }
            if (this.Scope_Prefix != null)
            {
                context.Scope_Prefix = new List<System.String>(this.Scope_Prefix);
            }
            context.VpcConfiguration_VpcId = this.VpcConfiguration_VpcId;
            
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
            var request = new Amazon.S3Control.Model.CreateAccessPointRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.Bucket != null)
            {
                request.Bucket = cmdletContext.Bucket;
            }
            if (cmdletContext.BucketAccountId != null)
            {
                request.BucketAccountId = cmdletContext.BucketAccountId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PublicAccessBlockConfiguration
            var requestPublicAccessBlockConfigurationIsNull = true;
            request.PublicAccessBlockConfiguration = new Amazon.S3Control.Model.PublicAccessBlockConfiguration();
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl = null;
            if (cmdletContext.PublicAccessBlockConfiguration_BlockPublicAcl != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl = cmdletContext.PublicAccessBlockConfiguration_BlockPublicAcl.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl != null)
            {
                request.PublicAccessBlockConfiguration.BlockPublicAcls = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicAcl.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy = null;
            if (cmdletContext.PublicAccessBlockConfiguration_BlockPublicPolicy != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy = cmdletContext.PublicAccessBlockConfiguration_BlockPublicPolicy.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy != null)
            {
                request.PublicAccessBlockConfiguration.BlockPublicPolicy = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_BlockPublicPolicy.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl = null;
            if (cmdletContext.PublicAccessBlockConfiguration_IgnorePublicAcl != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl = cmdletContext.PublicAccessBlockConfiguration_IgnorePublicAcl.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl != null)
            {
                request.PublicAccessBlockConfiguration.IgnorePublicAcls = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_IgnorePublicAcl.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket = null;
            if (cmdletContext.PublicAccessBlockConfiguration_RestrictPublicBucket != null)
            {
                requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket = cmdletContext.PublicAccessBlockConfiguration_RestrictPublicBucket.Value;
            }
            if (requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket != null)
            {
                request.PublicAccessBlockConfiguration.RestrictPublicBuckets = requestPublicAccessBlockConfiguration_publicAccessBlockConfiguration_RestrictPublicBucket.Value;
                requestPublicAccessBlockConfigurationIsNull = false;
            }
             // determine if request.PublicAccessBlockConfiguration should be set to null
            if (requestPublicAccessBlockConfigurationIsNull)
            {
                request.PublicAccessBlockConfiguration = null;
            }
            
             // populate Scope
            var requestScopeIsNull = true;
            request.Scope = new Amazon.S3Control.Model.Scope();
            List<System.String> requestScope_scope_Permission = null;
            if (cmdletContext.Scope_Permission != null)
            {
                requestScope_scope_Permission = cmdletContext.Scope_Permission;
            }
            if (requestScope_scope_Permission != null)
            {
                request.Scope.Permissions = requestScope_scope_Permission;
                requestScopeIsNull = false;
            }
            List<System.String> requestScope_scope_Prefix = null;
            if (cmdletContext.Scope_Prefix != null)
            {
                requestScope_scope_Prefix = cmdletContext.Scope_Prefix;
            }
            if (requestScope_scope_Prefix != null)
            {
                request.Scope.Prefixes = requestScope_scope_Prefix;
                requestScopeIsNull = false;
            }
             // determine if request.Scope should be set to null
            if (requestScopeIsNull)
            {
                request.Scope = null;
            }
            
             // populate VpcConfiguration
            var requestVpcConfigurationIsNull = true;
            request.VpcConfiguration = new Amazon.S3Control.Model.VpcConfiguration();
            System.String requestVpcConfiguration_vpcConfiguration_VpcId = null;
            if (cmdletContext.VpcConfiguration_VpcId != null)
            {
                requestVpcConfiguration_vpcConfiguration_VpcId = cmdletContext.VpcConfiguration_VpcId;
            }
            if (requestVpcConfiguration_vpcConfiguration_VpcId != null)
            {
                request.VpcConfiguration.VpcId = requestVpcConfiguration_vpcConfiguration_VpcId;
                requestVpcConfigurationIsNull = false;
            }
             // determine if request.VpcConfiguration should be set to null
            if (requestVpcConfigurationIsNull)
            {
                request.VpcConfiguration = null;
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
        
        private Amazon.S3Control.Model.CreateAccessPointResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.CreateAccessPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "CreateAccessPoint");
            try
            {
                return client.CreateAccessPointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BucketAccountId { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_BlockPublicAcl { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_BlockPublicPolicy { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_IgnorePublicAcl { get; set; }
            public System.Boolean? PublicAccessBlockConfiguration_RestrictPublicBucket { get; set; }
            public List<System.String> Scope_Permission { get; set; }
            public List<System.String> Scope_Prefix { get; set; }
            public System.String VpcConfiguration_VpcId { get; set; }
            public System.Func<Amazon.S3Control.Model.CreateAccessPointResponse, NewS3CAccessPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccessPointArn;
        }
        
    }
}
