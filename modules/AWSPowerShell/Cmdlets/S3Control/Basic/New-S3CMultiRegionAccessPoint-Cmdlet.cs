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
    /// Creates a Multi-Region Access Point and associates it with the specified buckets.
    /// For more information about creating Multi-Region Access Points, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/CreatingMultiRegionAccessPoints.html">Creating
    /// Multi-Region Access Points</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    ///  
    /// <para>
    /// This action will always be routed to the US West (Oregon) Region. For more information
    /// about the restrictions around managing Multi-Region Access Points, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/ManagingMultiRegionAccessPoints.html">Managing
    /// Multi-Region Access Points</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// This request is asynchronous, meaning that you might receive a response before the
    /// command has completed. When this request provides a response, it provides a token
    /// that you can use to monitor the status of the request with <code>DescribeMultiRegionAccessPointOperation</code>.
    /// </para><para>
    /// The following actions are related to <code>CreateMultiRegionAccessPoint</code>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_DeleteMultiRegionAccessPoint.html">DeleteMultiRegionAccessPoint</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_DescribeMultiRegionAccessPointOperation.html">DescribeMultiRegionAccessPointOperation</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetMultiRegionAccessPoint.html">GetMultiRegionAccessPoint</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_ListMultiRegionAccessPoints.html">ListMultiRegionAccessPoints</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "S3CMultiRegionAccessPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon S3 Control CreateMultiRegionAccessPoint API operation.", Operation = new[] {"CreateMultiRegionAccessPoint"}, SelectReturnType = typeof(Amazon.S3Control.Model.CreateMultiRegionAccessPointResponse))]
    [AWSCmdletOutput("System.String or Amazon.S3Control.Model.CreateMultiRegionAccessPointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.S3Control.Model.CreateMultiRegionAccessPointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewS3CMultiRegionAccessPointCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID for the owner of the Multi-Region Access Point.
        /// The owner of the Multi-Region Access Point also must own the underlying buckets.</para>
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
        
        #region Parameter PublicAccessBlock_BlockPublicAcl
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should block public access control lists (ACLs) for buckets
        /// in this account. Setting this element to <code>TRUE</code> causes the following behavior:</para><ul><li><para><code>PutBucketAcl</code> and <code>PutObjectAcl</code> calls fail if the specified
        /// ACL is public.</para></li><li><para>PUT Object calls fail if the request includes a public ACL.</para></li><li><para>PUT Bucket calls fail if the request includes a public ACL.</para></li></ul><para>Enabling this setting doesn't affect existing policies or ACLs.</para><para>This property is not supported for Amazon S3 on Outposts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_PublicAccessBlock_BlockPublicAcls")]
        public System.Boolean? PublicAccessBlock_BlockPublicAcl { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlock_BlockPublicPolicy
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should block public bucket policies for buckets in this
        /// account. Setting this element to <code>TRUE</code> causes Amazon S3 to reject calls
        /// to PUT Bucket policy if the specified bucket policy allows public access. </para><para>Enabling this setting doesn't affect existing bucket policies.</para><para>This property is not supported for Amazon S3 on Outposts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_PublicAccessBlock_BlockPublicPolicy")]
        public System.Boolean? PublicAccessBlock_BlockPublicPolicy { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlock_IgnorePublicAcl
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should ignore public ACLs for buckets in this account.
        /// Setting this element to <code>TRUE</code> causes Amazon S3 to ignore all public ACLs
        /// on buckets in this account and any objects that they contain. </para><para>Enabling this setting doesn't affect the persistence of any existing ACLs and doesn't
        /// prevent new public ACLs from being set.</para><para>This property is not supported for Amazon S3 on Outposts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_PublicAccessBlock_IgnorePublicAcls")]
        public System.Boolean? PublicAccessBlock_IgnorePublicAcl { get; set; }
        #endregion
        
        #region Parameter Details_Name
        /// <summary>
        /// <para>
        /// <para>The name of the Multi-Region Access Point associated with this request.</para>
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
        public System.String Details_Name { get; set; }
        #endregion
        
        #region Parameter Details_Region
        /// <summary>
        /// <para>
        /// <para>The buckets in different Regions that are associated with the Multi-Region Access
        /// Point.</para>
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
        [Alias("Details_Regions")]
        public Amazon.S3Control.Model.Region[] Details_Region { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlock_RestrictPublicBucket
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should restrict public bucket policies for buckets in
        /// this account. Setting this element to <code>TRUE</code> restricts access to buckets
        /// with public policies to only Amazon Web Service principals and authorized users within
        /// this account.</para><para>Enabling this setting doesn't affect previously stored bucket policies, except that
        /// public and cross-account access within any public bucket policy, including non-public
        /// delegation to specific accounts, is blocked.</para><para>This property is not supported for Amazon S3 on Outposts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Details_PublicAccessBlock_RestrictPublicBuckets")]
        public System.Boolean? PublicAccessBlock_RestrictPublicBucket { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token used to identify the request and guarantee that requests are
        /// unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RequestTokenARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.CreateMultiRegionAccessPointResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.CreateMultiRegionAccessPointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RequestTokenARN";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3CMultiRegionAccessPoint (CreateMultiRegionAccessPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.CreateMultiRegionAccessPointResponse, NewS3CMultiRegionAccessPointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Details_Name = this.Details_Name;
            #if MODULAR
            if (this.Details_Name == null && ParameterWasBound(nameof(this.Details_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Details_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublicAccessBlock_BlockPublicAcl = this.PublicAccessBlock_BlockPublicAcl;
            context.PublicAccessBlock_BlockPublicPolicy = this.PublicAccessBlock_BlockPublicPolicy;
            context.PublicAccessBlock_IgnorePublicAcl = this.PublicAccessBlock_IgnorePublicAcl;
            context.PublicAccessBlock_RestrictPublicBucket = this.PublicAccessBlock_RestrictPublicBucket;
            if (this.Details_Region != null)
            {
                context.Details_Region = new List<Amazon.S3Control.Model.Region>(this.Details_Region);
            }
            #if MODULAR
            if (this.Details_Region == null && ParameterWasBound(nameof(this.Details_Region)))
            {
                WriteWarning("You are passing $null as a value for parameter Details_Region which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Control.Model.CreateMultiRegionAccessPointRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Details
            var requestDetailsIsNull = true;
            request.Details = new Amazon.S3Control.Model.CreateMultiRegionAccessPointInput();
            System.String requestDetails_details_Name = null;
            if (cmdletContext.Details_Name != null)
            {
                requestDetails_details_Name = cmdletContext.Details_Name;
            }
            if (requestDetails_details_Name != null)
            {
                request.Details.Name = requestDetails_details_Name;
                requestDetailsIsNull = false;
            }
            List<Amazon.S3Control.Model.Region> requestDetails_details_Region = null;
            if (cmdletContext.Details_Region != null)
            {
                requestDetails_details_Region = cmdletContext.Details_Region;
            }
            if (requestDetails_details_Region != null)
            {
                request.Details.Regions = requestDetails_details_Region;
                requestDetailsIsNull = false;
            }
            Amazon.S3Control.Model.PublicAccessBlockConfiguration requestDetails_details_PublicAccessBlock = null;
            
             // populate PublicAccessBlock
            var requestDetails_details_PublicAccessBlockIsNull = true;
            requestDetails_details_PublicAccessBlock = new Amazon.S3Control.Model.PublicAccessBlockConfiguration();
            System.Boolean? requestDetails_details_PublicAccessBlock_publicAccessBlock_BlockPublicAcl = null;
            if (cmdletContext.PublicAccessBlock_BlockPublicAcl != null)
            {
                requestDetails_details_PublicAccessBlock_publicAccessBlock_BlockPublicAcl = cmdletContext.PublicAccessBlock_BlockPublicAcl.Value;
            }
            if (requestDetails_details_PublicAccessBlock_publicAccessBlock_BlockPublicAcl != null)
            {
                requestDetails_details_PublicAccessBlock.BlockPublicAcls = requestDetails_details_PublicAccessBlock_publicAccessBlock_BlockPublicAcl.Value;
                requestDetails_details_PublicAccessBlockIsNull = false;
            }
            System.Boolean? requestDetails_details_PublicAccessBlock_publicAccessBlock_BlockPublicPolicy = null;
            if (cmdletContext.PublicAccessBlock_BlockPublicPolicy != null)
            {
                requestDetails_details_PublicAccessBlock_publicAccessBlock_BlockPublicPolicy = cmdletContext.PublicAccessBlock_BlockPublicPolicy.Value;
            }
            if (requestDetails_details_PublicAccessBlock_publicAccessBlock_BlockPublicPolicy != null)
            {
                requestDetails_details_PublicAccessBlock.BlockPublicPolicy = requestDetails_details_PublicAccessBlock_publicAccessBlock_BlockPublicPolicy.Value;
                requestDetails_details_PublicAccessBlockIsNull = false;
            }
            System.Boolean? requestDetails_details_PublicAccessBlock_publicAccessBlock_IgnorePublicAcl = null;
            if (cmdletContext.PublicAccessBlock_IgnorePublicAcl != null)
            {
                requestDetails_details_PublicAccessBlock_publicAccessBlock_IgnorePublicAcl = cmdletContext.PublicAccessBlock_IgnorePublicAcl.Value;
            }
            if (requestDetails_details_PublicAccessBlock_publicAccessBlock_IgnorePublicAcl != null)
            {
                requestDetails_details_PublicAccessBlock.IgnorePublicAcls = requestDetails_details_PublicAccessBlock_publicAccessBlock_IgnorePublicAcl.Value;
                requestDetails_details_PublicAccessBlockIsNull = false;
            }
            System.Boolean? requestDetails_details_PublicAccessBlock_publicAccessBlock_RestrictPublicBucket = null;
            if (cmdletContext.PublicAccessBlock_RestrictPublicBucket != null)
            {
                requestDetails_details_PublicAccessBlock_publicAccessBlock_RestrictPublicBucket = cmdletContext.PublicAccessBlock_RestrictPublicBucket.Value;
            }
            if (requestDetails_details_PublicAccessBlock_publicAccessBlock_RestrictPublicBucket != null)
            {
                requestDetails_details_PublicAccessBlock.RestrictPublicBuckets = requestDetails_details_PublicAccessBlock_publicAccessBlock_RestrictPublicBucket.Value;
                requestDetails_details_PublicAccessBlockIsNull = false;
            }
             // determine if requestDetails_details_PublicAccessBlock should be set to null
            if (requestDetails_details_PublicAccessBlockIsNull)
            {
                requestDetails_details_PublicAccessBlock = null;
            }
            if (requestDetails_details_PublicAccessBlock != null)
            {
                request.Details.PublicAccessBlock = requestDetails_details_PublicAccessBlock;
                requestDetailsIsNull = false;
            }
             // determine if request.Details should be set to null
            if (requestDetailsIsNull)
            {
                request.Details = null;
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
        
        private Amazon.S3Control.Model.CreateMultiRegionAccessPointResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.CreateMultiRegionAccessPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "CreateMultiRegionAccessPoint");
            try
            {
                #if DESKTOP
                return client.CreateMultiRegionAccessPoint(request);
                #elif CORECLR
                return client.CreateMultiRegionAccessPointAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Details_Name { get; set; }
            public System.Boolean? PublicAccessBlock_BlockPublicAcl { get; set; }
            public System.Boolean? PublicAccessBlock_BlockPublicPolicy { get; set; }
            public System.Boolean? PublicAccessBlock_IgnorePublicAcl { get; set; }
            public System.Boolean? PublicAccessBlock_RestrictPublicBucket { get; set; }
            public List<Amazon.S3Control.Model.Region> Details_Region { get; set; }
            public System.Func<Amazon.S3Control.Model.CreateMultiRegionAccessPointResponse, NewS3CMultiRegionAccessPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RequestTokenARN;
        }
        
    }
}
