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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// This API is deprecated. Amazon CloudFront is deprecating real-time messaging protocol
    /// (RTMP) distributions on December 31, 2020. For more information, <a href="http://forums.aws.amazon.com/ann.jspa?annID=7356">read
    /// the announcement</a> on the Amazon CloudFront discussion forum.
    /// </summary>
    [Cmdlet("New", "CFStreamingDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateStreamingDistributionResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateStreamingDistribution API operation.", Operation = new[] {"CreateStreamingDistribution"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateStreamingDistributionResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateStreamingDistributionResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateStreamingDistributionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFStreamingDistributionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter Logging_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket to store the access logs in, for example, <code>myawslogbucket.s3.amazonaws.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_Logging_Bucket")]
        public System.String Logging_Bucket { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique value (for example, a date-time stamp) that ensures that the request can't
        /// be replayed.</para><para>If the value of <code>CallerReference</code> is new (regardless of the content of
        /// the <code>StreamingDistributionConfig</code> object), CloudFront creates a new distribution.</para><para>If <code>CallerReference</code> is a value that you already sent in a previous request
        /// to create a distribution, CloudFront returns a <code>DistributionAlreadyExists</code>
        /// error.</para>
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
        public System.String StreamingDistributionConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_Comment
        /// <summary>
        /// <para>
        /// <para>Any comments you want to include about the streaming distribution. </para>
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
        public System.String StreamingDistributionConfig_Comment { get; set; }
        #endregion
        
        #region Parameter S3Origin_DomainName
        /// <summary>
        /// <para>
        /// <para>The DNS name of the Amazon S3 origin. </para>
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
        [Alias("StreamingDistributionConfig_S3Origin_DomainName")]
        public System.String S3Origin_DomainName { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether the streaming distribution is enabled to accept user requests for content.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? StreamingDistributionConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter Logging_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want CloudFront to save access logs to an Amazon S3 bucket.
        /// If you don't want to enable logging when you create a streaming distribution or if
        /// you want to disable logging for an existing streaming distribution, specify <code>false</code>
        /// for <code>Enabled</code>, and specify <code>empty Bucket</code> and <code>Prefix</code>
        /// elements. If you specify <code>false</code> for <code>Enabled</code> but you specify
        /// values for <code>Bucket</code> and <code>Prefix</code>, the values are automatically
        /// deleted. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_Logging_Enabled")]
        public System.Boolean? Logging_Enabled { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Enabled
        /// <summary>
        /// <para>
        /// <para>This field is <code>true</code> if any of the accounts have public keys that CloudFront
        /// can use to verify the signatures of signed URLs and signed cookies. If not, this field
        /// is <code>false</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StreamingDistributionConfig_TrustedSigners_Enabled")]
        public System.Boolean? TrustedSigners_Enabled { get; set; }
        #endregion
        
        #region Parameter Aliases_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains the CNAME aliases, if any, that you want to associate
        /// with this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_Aliases_Items")]
        public System.String[] Aliases_Item { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Item
        /// <summary>
        /// <para>
        /// <para>A list of account identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_TrustedSigners_Items")]
        public System.String[] TrustedSigners_Item { get; set; }
        #endregion
        
        #region Parameter S3Origin_OriginAccessIdentity
        /// <summary>
        /// <para>
        /// <para>The CloudFront origin access identity to associate with the distribution. Use an origin
        /// access identity to configure the distribution so that end users can only access objects
        /// in an Amazon S3 bucket through CloudFront.</para><para>If you want end users to be able to access objects using either the CloudFront URL
        /// or the Amazon S3 URL, specify an empty <code>OriginAccessIdentity</code> element.</para><para>To delete the origin access identity from an existing distribution, update the distribution
        /// configuration and include an empty <code>OriginAccessIdentity</code> element.</para><para>To replace the origin access identity, update the distribution configuration and specify
        /// the new origin access identity.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/private-content-restricting-access-to-s3.html">Using
        /// an Origin Access Identity to Restrict Access to Your Amazon S3 Content</a> in the
        /// <i> Amazon CloudFront Developer Guide</i>.</para>
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
        [Alias("StreamingDistributionConfig_S3Origin_OriginAccessIdentity")]
        public System.String S3Origin_OriginAccessIdentity { get; set; }
        #endregion
        
        #region Parameter Logging_Prefix
        /// <summary>
        /// <para>
        /// <para>An optional string that you want CloudFront to prefix to the access log filenames
        /// for this streaming distribution, for example, <code>myprefix/</code>. If you want
        /// to enable logging, but you don't want to specify a prefix, you still must include
        /// an empty <code>Prefix</code> element in the <code>Logging</code> element.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_Logging_Prefix")]
        public System.String Logging_Prefix { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_PriceClass
        /// <summary>
        /// <para>
        /// <para>A complex type that contains information about price class for this streaming distribution.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFront.PriceClass")]
        public Amazon.CloudFront.PriceClass StreamingDistributionConfig_PriceClass { get; set; }
        #endregion
        
        #region Parameter Aliases_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of CNAME aliases, if any, that you want to associate with this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingDistributionConfig_Aliases_Quantity")]
        public System.Int32? Aliases_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of accounts in the list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StreamingDistributionConfig_TrustedSigners_Quantity")]
        public System.Int32? TrustedSigners_Quantity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateStreamingDistributionResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateStreamingDistributionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the S3Origin_DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^S3Origin_DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^S3Origin_DomainName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.S3Origin_DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFStreamingDistribution (CreateStreamingDistribution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateStreamingDistributionResponse, NewCFStreamingDistributionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.S3Origin_DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Aliases_Item != null)
            {
                context.Aliases_Item = new List<System.String>(this.Aliases_Item);
            }
            context.Aliases_Quantity = this.Aliases_Quantity;
            context.StreamingDistributionConfig_CallerReference = this.StreamingDistributionConfig_CallerReference;
            #if MODULAR
            if (this.StreamingDistributionConfig_CallerReference == null && ParameterWasBound(nameof(this.StreamingDistributionConfig_CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamingDistributionConfig_CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamingDistributionConfig_Comment = this.StreamingDistributionConfig_Comment;
            #if MODULAR
            if (this.StreamingDistributionConfig_Comment == null && ParameterWasBound(nameof(this.StreamingDistributionConfig_Comment)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamingDistributionConfig_Comment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamingDistributionConfig_Enabled = this.StreamingDistributionConfig_Enabled;
            #if MODULAR
            if (this.StreamingDistributionConfig_Enabled == null && ParameterWasBound(nameof(this.StreamingDistributionConfig_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamingDistributionConfig_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Logging_Bucket = this.Logging_Bucket;
            context.Logging_Enabled = this.Logging_Enabled;
            context.Logging_Prefix = this.Logging_Prefix;
            context.StreamingDistributionConfig_PriceClass = this.StreamingDistributionConfig_PriceClass;
            context.S3Origin_DomainName = this.S3Origin_DomainName;
            #if MODULAR
            if (this.S3Origin_DomainName == null && ParameterWasBound(nameof(this.S3Origin_DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Origin_DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Origin_OriginAccessIdentity = this.S3Origin_OriginAccessIdentity;
            #if MODULAR
            if (this.S3Origin_OriginAccessIdentity == null && ParameterWasBound(nameof(this.S3Origin_OriginAccessIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Origin_OriginAccessIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrustedSigners_Enabled = this.TrustedSigners_Enabled;
            #if MODULAR
            if (this.TrustedSigners_Enabled == null && ParameterWasBound(nameof(this.TrustedSigners_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustedSigners_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TrustedSigners_Item != null)
            {
                context.TrustedSigners_Item = new List<System.String>(this.TrustedSigners_Item);
            }
            context.TrustedSigners_Quantity = this.TrustedSigners_Quantity;
            #if MODULAR
            if (this.TrustedSigners_Quantity == null && ParameterWasBound(nameof(this.TrustedSigners_Quantity)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustedSigners_Quantity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFront.Model.CreateStreamingDistributionRequest();
            
            
             // populate StreamingDistributionConfig
            var requestStreamingDistributionConfigIsNull = true;
            request.StreamingDistributionConfig = new Amazon.CloudFront.Model.StreamingDistributionConfig();
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_CallerReference = null;
            if (cmdletContext.StreamingDistributionConfig_CallerReference != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_CallerReference = cmdletContext.StreamingDistributionConfig_CallerReference;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_CallerReference != null)
            {
                request.StreamingDistributionConfig.CallerReference = requestStreamingDistributionConfig_streamingDistributionConfig_CallerReference;
                requestStreamingDistributionConfigIsNull = false;
            }
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_Comment = null;
            if (cmdletContext.StreamingDistributionConfig_Comment != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Comment = cmdletContext.StreamingDistributionConfig_Comment;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Comment != null)
            {
                request.StreamingDistributionConfig.Comment = requestStreamingDistributionConfig_streamingDistributionConfig_Comment;
                requestStreamingDistributionConfigIsNull = false;
            }
            System.Boolean? requestStreamingDistributionConfig_streamingDistributionConfig_Enabled = null;
            if (cmdletContext.StreamingDistributionConfig_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Enabled = cmdletContext.StreamingDistributionConfig_Enabled.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Enabled != null)
            {
                request.StreamingDistributionConfig.Enabled = requestStreamingDistributionConfig_streamingDistributionConfig_Enabled.Value;
                requestStreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.PriceClass requestStreamingDistributionConfig_streamingDistributionConfig_PriceClass = null;
            if (cmdletContext.StreamingDistributionConfig_PriceClass != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_PriceClass = cmdletContext.StreamingDistributionConfig_PriceClass;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_PriceClass != null)
            {
                request.StreamingDistributionConfig.PriceClass = requestStreamingDistributionConfig_streamingDistributionConfig_PriceClass;
                requestStreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Aliases requestStreamingDistributionConfig_streamingDistributionConfig_Aliases = null;
            
             // populate Aliases
            var requestStreamingDistributionConfig_streamingDistributionConfig_AliasesIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_Aliases = new Amazon.CloudFront.Model.Aliases();
            List<System.String> requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item = null;
            if (cmdletContext.Aliases_Item != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item = cmdletContext.Aliases_Item;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases.Items = requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item;
                requestStreamingDistributionConfig_streamingDistributionConfig_AliasesIsNull = false;
            }
            System.Int32? requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Quantity = null;
            if (cmdletContext.Aliases_Quantity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Quantity = cmdletContext.Aliases_Quantity.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Quantity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases.Quantity = requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Quantity.Value;
                requestStreamingDistributionConfig_streamingDistributionConfig_AliasesIsNull = false;
            }
             // determine if requestStreamingDistributionConfig_streamingDistributionConfig_Aliases should be set to null
            if (requestStreamingDistributionConfig_streamingDistributionConfig_AliasesIsNull)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases = null;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Aliases != null)
            {
                request.StreamingDistributionConfig.Aliases = requestStreamingDistributionConfig_streamingDistributionConfig_Aliases;
                requestStreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.S3Origin requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin = null;
            
             // populate S3Origin
            var requestStreamingDistributionConfig_streamingDistributionConfig_S3OriginIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin = new Amazon.CloudFront.Model.S3Origin();
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName = null;
            if (cmdletContext.S3Origin_DomainName != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName = cmdletContext.S3Origin_DomainName;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin.DomainName = requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName;
                requestStreamingDistributionConfig_streamingDistributionConfig_S3OriginIsNull = false;
            }
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity = null;
            if (cmdletContext.S3Origin_OriginAccessIdentity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity = cmdletContext.S3Origin_OriginAccessIdentity;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin.OriginAccessIdentity = requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity;
                requestStreamingDistributionConfig_streamingDistributionConfig_S3OriginIsNull = false;
            }
             // determine if requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin should be set to null
            if (requestStreamingDistributionConfig_streamingDistributionConfig_S3OriginIsNull)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin = null;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin != null)
            {
                request.StreamingDistributionConfig.S3Origin = requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin;
                requestStreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.StreamingLoggingConfig requestStreamingDistributionConfig_streamingDistributionConfig_Logging = null;
            
             // populate Logging
            var requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_Logging = new Amazon.CloudFront.Model.StreamingLoggingConfig();
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket = null;
            if (cmdletContext.Logging_Bucket != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket = cmdletContext.Logging_Bucket;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging.Bucket = requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket;
                requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled = null;
            if (cmdletContext.Logging_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled = cmdletContext.Logging_Enabled.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging.Enabled = requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled.Value;
                requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = false;
            }
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Prefix = null;
            if (cmdletContext.Logging_Prefix != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Prefix = cmdletContext.Logging_Prefix;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Prefix != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging.Prefix = requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Prefix;
                requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = false;
            }
             // determine if requestStreamingDistributionConfig_streamingDistributionConfig_Logging should be set to null
            if (requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging = null;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Logging != null)
            {
                request.StreamingDistributionConfig.Logging = requestStreamingDistributionConfig_streamingDistributionConfig_Logging;
                requestStreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.TrustedSigners requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners = null;
            
             // populate TrustedSigners
            var requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners = new Amazon.CloudFront.Model.TrustedSigners();
            System.Boolean? requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled = null;
            if (cmdletContext.TrustedSigners_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled = cmdletContext.TrustedSigners_Enabled.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners.Enabled = requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled.Value;
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = false;
            }
            List<System.String> requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item = null;
            if (cmdletContext.TrustedSigners_Item != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item = cmdletContext.TrustedSigners_Item;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners.Items = requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item;
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = false;
            }
            System.Int32? requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Quantity = null;
            if (cmdletContext.TrustedSigners_Quantity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Quantity = cmdletContext.TrustedSigners_Quantity.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Quantity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners.Quantity = requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Quantity.Value;
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = false;
            }
             // determine if requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners should be set to null
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners = null;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners != null)
            {
                request.StreamingDistributionConfig.TrustedSigners = requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners;
                requestStreamingDistributionConfigIsNull = false;
            }
             // determine if request.StreamingDistributionConfig should be set to null
            if (requestStreamingDistributionConfigIsNull)
            {
                request.StreamingDistributionConfig = null;
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
        
        private Amazon.CloudFront.Model.CreateStreamingDistributionResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateStreamingDistributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateStreamingDistribution");
            try
            {
                #if DESKTOP
                return client.CreateStreamingDistribution(request);
                #elif CORECLR
                return client.CreateStreamingDistributionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Aliases_Item { get; set; }
            public System.Int32? Aliases_Quantity { get; set; }
            public System.String StreamingDistributionConfig_CallerReference { get; set; }
            public System.String StreamingDistributionConfig_Comment { get; set; }
            public System.Boolean? StreamingDistributionConfig_Enabled { get; set; }
            public System.String Logging_Bucket { get; set; }
            public System.Boolean? Logging_Enabled { get; set; }
            public System.String Logging_Prefix { get; set; }
            public Amazon.CloudFront.PriceClass StreamingDistributionConfig_PriceClass { get; set; }
            public System.String S3Origin_DomainName { get; set; }
            public System.String S3Origin_OriginAccessIdentity { get; set; }
            public System.Boolean? TrustedSigners_Enabled { get; set; }
            public List<System.String> TrustedSigners_Item { get; set; }
            public System.Int32? TrustedSigners_Quantity { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateStreamingDistributionResponse, NewCFStreamingDistributionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
