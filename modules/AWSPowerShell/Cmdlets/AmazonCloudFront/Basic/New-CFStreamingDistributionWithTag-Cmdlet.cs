/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Create a new streaming distribution with tags.
    /// </summary>
    [Cmdlet("New", "CFStreamingDistributionWithTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateStreamingDistributionWithTagsResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateStreamingDistributionWithTags API operation.", Operation = new[] {"CreateStreamingDistributionWithTags"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateStreamingDistributionWithTagsResponse",
        "This cmdlet returns a Amazon.CloudFront.Model.CreateStreamingDistributionWithTagsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFStreamingDistributionWithTagCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter Logging_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket to store the access logs in, for example, <code>myawslogbucket.s3.amazonaws.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Bucket")]
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
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_CallerReference")]
        public System.String StreamingDistributionConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_Comment
        /// <summary>
        /// <para>
        /// <para>Any comments you want to include about the streaming distribution. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_Comment")]
        public System.String StreamingDistributionConfig_Comment { get; set; }
        #endregion
        
        #region Parameter S3Origin_DomainName
        /// <summary>
        /// <para>
        /// <para>The DNS name of the Amazon S3 origin. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_DomainName")]
        public System.String S3Origin_DomainName { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether the streaming distribution is enabled to accept user requests for content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_Enabled")]
        public System.Boolean StreamingDistributionConfig_Enabled { get; set; }
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
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Enabled")]
        public System.Boolean Logging_Enabled { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to require viewers to use signed URLs to access the files
        /// specified by <code>PathPattern</code> and <code>TargetOriginId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Enabled")]
        public System.Boolean TrustedSigners_Enabled { get; set; }
        #endregion
        
        #region Parameter Aliases_Item
        /// <summary>
        /// <para>
        /// <para>A complex type that contains the CNAME aliases, if any, that you want to associate
        /// with this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_Items")]
        public System.String[] Aliases_Item { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Item
        /// <summary>
        /// <para>
        /// <para><b>Optional</b>: A complex type that contains trusted signers for this cache behavior.
        /// If <code>Quantity</code> is <code>0</code>, you can omit <code>Items</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Items")]
        public System.String[] TrustedSigners_Item { get; set; }
        #endregion
        
        #region Parameter Tags_Item
        /// <summary>
        /// <para>
        /// <para> A complex type that contains <code>Tag</code> elements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_Tags_Items")]
        public Amazon.CloudFront.Model.Tag[] Tags_Item { get; set; }
        #endregion
        
        #region Parameter S3Origin_OriginAccessIdentity
        /// <summary>
        /// <para>
        /// <para>The CloudFront origin access identity to associate with the RTMP distribution. Use
        /// an origin access identity to configure the distribution so that end users can only
        /// access objects in an Amazon S3 bucket through CloudFront.</para><para>If you want end users to be able to access objects using either the CloudFront URL
        /// or the Amazon S3 URL, specify an empty <code>OriginAccessIdentity</code> element.</para><para>To delete the origin access identity from an existing distribution, update the distribution
        /// configuration and include an empty <code>OriginAccessIdentity</code> element.</para><para>To replace the origin access identity, update the distribution configuration and specify
        /// the new origin access identity.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/private-content-restricting-access-to-s3.html">Using
        /// an Origin Access Identity to Restrict Access to Your Amazon S3 Content</a> in the
        /// <i>Amazon Amazon CloudFront Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_OriginAccessIdentity")]
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
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Prefix")]
        public System.String Logging_Prefix { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_PriceClass
        /// <summary>
        /// <para>
        /// <para>A complex type that contains information about price class for this streaming distribution.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_PriceClass")]
        [AWSConstantClassSource("Amazon.CloudFront.PriceClass")]
        public Amazon.CloudFront.PriceClass StreamingDistributionConfig_PriceClass { get; set; }
        #endregion
        
        #region Parameter Aliases_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of CNAME aliases, if any, that you want to associate with this distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_Quantity")]
        public System.Int32 Aliases_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Quantity
        /// <summary>
        /// <para>
        /// <para>The number of trusted signers for this cache behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Quantity")]
        public System.Int32 TrustedSigners_Quantity { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFStreamingDistributionWithTag (CreateStreamingDistributionWithTags)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Aliases_Item != null)
            {
                context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_Items = new List<System.String>(this.Aliases_Item);
            }
            if (ParameterWasBound("Aliases_Quantity"))
                context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_Quantity = this.Aliases_Quantity;
            context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_CallerReference = this.StreamingDistributionConfig_CallerReference;
            context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Comment = this.StreamingDistributionConfig_Comment;
            if (ParameterWasBound("StreamingDistributionConfig_Enabled"))
                context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Enabled = this.StreamingDistributionConfig_Enabled;
            context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Bucket = this.Logging_Bucket;
            if (ParameterWasBound("Logging_Enabled"))
                context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Enabled = this.Logging_Enabled;
            context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Prefix = this.Logging_Prefix;
            context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_PriceClass = this.StreamingDistributionConfig_PriceClass;
            context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_DomainName = this.S3Origin_DomainName;
            context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_OriginAccessIdentity = this.S3Origin_OriginAccessIdentity;
            if (ParameterWasBound("TrustedSigners_Enabled"))
                context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Enabled = this.TrustedSigners_Enabled;
            if (this.TrustedSigners_Item != null)
            {
                context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Items = new List<System.String>(this.TrustedSigners_Item);
            }
            if (ParameterWasBound("TrustedSigners_Quantity"))
                context.StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Quantity = this.TrustedSigners_Quantity;
            if (this.Tags_Item != null)
            {
                context.StreamingDistributionConfigWithTags_Tags_Items = new List<Amazon.CloudFront.Model.Tag>(this.Tags_Item);
            }
            
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
            var request = new Amazon.CloudFront.Model.CreateStreamingDistributionWithTagsRequest();
            
            
             // populate StreamingDistributionConfigWithTags
            bool requestStreamingDistributionConfigWithTagsIsNull = true;
            request.StreamingDistributionConfigWithTags = new Amazon.CloudFront.Model.StreamingDistributionConfigWithTags();
            Amazon.CloudFront.Model.Tags requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags = null;
            
             // populate Tags
            bool requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_TagsIsNull = true;
            requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags = new Amazon.CloudFront.Model.Tags();
            List<Amazon.CloudFront.Model.Tag> requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags_tags_Item = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_Tags_Items != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags_tags_Item = cmdletContext.StreamingDistributionConfigWithTags_Tags_Items;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags_tags_Item != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags.Items = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags_tags_Item;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_TagsIsNull = false;
            }
             // determine if requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags should be set to null
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_TagsIsNull)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags = null;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags != null)
            {
                request.StreamingDistributionConfigWithTags.Tags = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_Tags;
                requestStreamingDistributionConfigWithTagsIsNull = false;
            }
            Amazon.CloudFront.Model.StreamingDistributionConfig requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig = null;
            
             // populate StreamingDistributionConfig
            bool requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfigIsNull = true;
            requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig = new Amazon.CloudFront.Model.StreamingDistributionConfig();
            System.String requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_CallerReference = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_CallerReference != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_CallerReference = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_CallerReference;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_CallerReference != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig.CallerReference = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_CallerReference;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfigIsNull = false;
            }
            System.String requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_Comment = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Comment != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_Comment = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Comment;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_Comment != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig.Comment = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_Comment;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfigIsNull = false;
            }
            System.Boolean? requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_Enabled = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Enabled != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_Enabled = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Enabled.Value;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_Enabled != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig.Enabled = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_Enabled.Value;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.PriceClass requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_PriceClass = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_PriceClass != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_PriceClass = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_PriceClass;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_PriceClass != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig.PriceClass = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfig_PriceClass;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.Aliases requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases = null;
            
             // populate Aliases
            bool requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_AliasesIsNull = true;
            requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases = new Amazon.CloudFront.Model.Aliases();
            List<System.String> requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_aliases_Item = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_Items != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_aliases_Item = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_Items;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_aliases_Item != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases.Items = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_aliases_Item;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_AliasesIsNull = false;
            }
            System.Int32? requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_aliases_Quantity = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_Quantity != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_aliases_Quantity = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_Quantity.Value;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_aliases_Quantity != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases.Quantity = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_aliases_Quantity.Value;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_AliasesIsNull = false;
            }
             // determine if requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases should be set to null
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_AliasesIsNull)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases = null;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig.Aliases = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.S3Origin requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin = null;
            
             // populate S3Origin
            bool requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3OriginIsNull = true;
            requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin = new Amazon.CloudFront.Model.S3Origin();
            System.String requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_s3Origin_DomainName = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_DomainName != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_s3Origin_DomainName = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_DomainName;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_s3Origin_DomainName != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin.DomainName = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_s3Origin_DomainName;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3OriginIsNull = false;
            }
            System.String requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_OriginAccessIdentity != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_OriginAccessIdentity;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin.OriginAccessIdentity = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3OriginIsNull = false;
            }
             // determine if requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin should be set to null
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3OriginIsNull)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin = null;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig.S3Origin = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.StreamingLoggingConfig requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging = null;
            
             // populate Logging
            bool requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_LoggingIsNull = true;
            requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging = new Amazon.CloudFront.Model.StreamingLoggingConfig();
            System.String requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Bucket = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Bucket != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Bucket = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Bucket;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Bucket != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging.Bucket = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Bucket;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Enabled = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Enabled != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Enabled = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Enabled.Value;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Enabled != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging.Enabled = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Enabled.Value;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_LoggingIsNull = false;
            }
            System.String requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Prefix = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Prefix != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Prefix = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Prefix;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Prefix != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging.Prefix = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_logging_Prefix;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_LoggingIsNull = false;
            }
             // determine if requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging should be set to null
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_LoggingIsNull)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging = null;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig.Logging = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_Logging;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfigIsNull = false;
            }
            Amazon.CloudFront.Model.TrustedSigners requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners = null;
            
             // populate TrustedSigners
            bool requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSignersIsNull = true;
            requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners = new Amazon.CloudFront.Model.TrustedSigners();
            System.Boolean? requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Enabled = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Enabled != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Enabled = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Enabled.Value;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Enabled != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners.Enabled = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Enabled.Value;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSignersIsNull = false;
            }
            List<System.String> requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Item = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Items != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Item = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Items;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Item != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners.Items = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Item;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSignersIsNull = false;
            }
            System.Int32? requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Quantity = null;
            if (cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Quantity != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Quantity = cmdletContext.StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Quantity.Value;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Quantity != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners.Quantity = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_trustedSigners_Quantity.Value;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSignersIsNull = false;
            }
             // determine if requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners should be set to null
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSignersIsNull)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners = null;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners != null)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig.TrustedSigners = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig_streamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners;
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfigIsNull = false;
            }
             // determine if requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig should be set to null
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfigIsNull)
            {
                requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig = null;
            }
            if (requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig != null)
            {
                request.StreamingDistributionConfigWithTags.StreamingDistributionConfig = requestStreamingDistributionConfigWithTags_streamingDistributionConfigWithTags_StreamingDistributionConfig;
                requestStreamingDistributionConfigWithTagsIsNull = false;
            }
             // determine if request.StreamingDistributionConfigWithTags should be set to null
            if (requestStreamingDistributionConfigWithTagsIsNull)
            {
                request.StreamingDistributionConfigWithTags = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.CloudFront.Model.CreateStreamingDistributionWithTagsResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateStreamingDistributionWithTagsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateStreamingDistributionWithTags");
            try
            {
                #if DESKTOP
                return client.CreateStreamingDistributionWithTags(request);
                #elif CORECLR
                return client.CreateStreamingDistributionWithTagsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> StreamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_Items { get; set; }
            public System.Int32? StreamingDistributionConfigWithTags_StreamingDistributionConfig_Aliases_Quantity { get; set; }
            public System.String StreamingDistributionConfigWithTags_StreamingDistributionConfig_CallerReference { get; set; }
            public System.String StreamingDistributionConfigWithTags_StreamingDistributionConfig_Comment { get; set; }
            public System.Boolean? StreamingDistributionConfigWithTags_StreamingDistributionConfig_Enabled { get; set; }
            public System.String StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Bucket { get; set; }
            public System.Boolean? StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Enabled { get; set; }
            public System.String StreamingDistributionConfigWithTags_StreamingDistributionConfig_Logging_Prefix { get; set; }
            public Amazon.CloudFront.PriceClass StreamingDistributionConfigWithTags_StreamingDistributionConfig_PriceClass { get; set; }
            public System.String StreamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_DomainName { get; set; }
            public System.String StreamingDistributionConfigWithTags_StreamingDistributionConfig_S3Origin_OriginAccessIdentity { get; set; }
            public System.Boolean? StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Enabled { get; set; }
            public List<System.String> StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Items { get; set; }
            public System.Int32? StreamingDistributionConfigWithTags_StreamingDistributionConfig_TrustedSigners_Quantity { get; set; }
            public List<Amazon.CloudFront.Model.Tag> StreamingDistributionConfigWithTags_Tags_Items { get; set; }
        }
        
    }
}
