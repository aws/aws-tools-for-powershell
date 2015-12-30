/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Create a new streaming distribution.
    /// </summary>
    [Cmdlet("New", "CFStreamingDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateStreamingDistributionResponse")]
    [AWSCmdlet("Invokes the CreateStreamingDistribution operation against Amazon CloudFront.", Operation = new[] {"CreateStreamingDistribution"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateStreamingDistributionResponse",
        "This cmdlet returns a Amazon.CloudFront.Model.CreateStreamingDistributionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewCFStreamingDistributionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter Logging_Bucket
        /// <summary>
        /// <para>
        /// The Amazon S3 bucket to store the access logs in,
        /// for example, myawslogbucket.s3.amazonaws.com.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfig_Logging_Bucket")]
        public System.String Logging_Bucket { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_CallerReference
        /// <summary>
        /// <para>
        /// A unique number that ensures the request
        /// can't be replayed. If the CallerReference is new (no matter the content of the StreamingDistributionConfig
        /// object), a new streaming distribution is created. If the CallerReference is a value
        /// you already sent in a previous request to create a streaming distribution, and the
        /// content of the StreamingDistributionConfig is identical to the original request (ignoring
        /// white space), the response includes the same information returned to the original
        /// request. If the CallerReference is a value you already sent in a previous request
        /// to create a streaming distribution but the content of the StreamingDistributionConfig
        /// is different from the original request, CloudFront returns a DistributionAlreadyExists
        /// error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StreamingDistributionConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_Comment
        /// <summary>
        /// <para>
        /// Any comments you want to include about the streaming
        /// distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StreamingDistributionConfig_Comment { get; set; }
        #endregion
        
        #region Parameter S3Origin_DomainName
        /// <summary>
        /// <para>
        /// The DNS name of the S3 origin.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfig_S3Origin_DomainName")]
        public System.String S3Origin_DomainName { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_Enabled
        /// <summary>
        /// <para>
        /// Whether the streaming distribution is enabled
        /// to accept end user requests for content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean StreamingDistributionConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter Logging_Enabled
        /// <summary>
        /// <para>
        /// Specifies whether you want CloudFront to save
        /// access logs to an Amazon S3 bucket. If you do not want to enable logging when you
        /// create a streaming distribution or if you want to disable logging for an existing
        /// streaming distribution, specify false for Enabled, and specify empty Bucket and Prefix
        /// elements. If you specify false for Enabled but you specify values for Bucket and Prefix,
        /// the values are automatically deleted.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfig_Logging_Enabled")]
        public System.Boolean Logging_Enabled { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Enabled
        /// <summary>
        /// <para>
        /// Specifies whether you want to require end users
        /// to use signed URLs to access the files specified by PathPattern and TargetOriginId.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfig_TrustedSigners_Enabled")]
        public System.Boolean TrustedSigners_Enabled { get; set; }
        #endregion
        
        #region Parameter Aliases_Item
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains CNAME elements,
        /// if any, for this distribution. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfig_Aliases_Items")]
        public System.String[] Aliases_Item { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Item
        /// <summary>
        /// <para>
        /// Optional: A complex type that contains trusted signers
        /// for this cache behavior. If Quantity is 0, you can omit Items.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfig_TrustedSigners_Items")]
        public System.String[] TrustedSigners_Item { get; set; }
        #endregion
        
        #region Parameter S3Origin_OriginAccessIdentity
        /// <summary>
        /// <para>
        /// Your S3 origin's origin access identity.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfig_S3Origin_OriginAccessIdentity")]
        public System.String S3Origin_OriginAccessIdentity { get; set; }
        #endregion
        
        #region Parameter Logging_Prefix
        /// <summary>
        /// <para>
        /// An optional string that you want CloudFront to
        /// prefix to the access log filenames for this streaming distribution, for example, myprefix/.
        /// If you want to enable logging, but you do not want to specify a prefix, you still
        /// must include an empty Prefix element in the Logging element.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfig_Logging_Prefix")]
        public System.String Logging_Prefix { get; set; }
        #endregion
        
        #region Parameter StreamingDistributionConfig_PriceClass
        /// <summary>
        /// <para>
        /// A complex type that contains information about
        /// price class for this streaming distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudFront.PriceClass")]
        public Amazon.CloudFront.PriceClass StreamingDistributionConfig_PriceClass { get; set; }
        #endregion
        
        #region Parameter Aliases_Quantity
        /// <summary>
        /// <para>
        /// The number of CNAMEs, if any, for this distribution.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfig_Aliases_Quantity")]
        public System.Int32 Aliases_Quantity { get; set; }
        #endregion
        
        #region Parameter TrustedSigners_Quantity
        /// <summary>
        /// <para>
        /// The number of trusted signers for this cache
        /// behavior.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StreamingDistributionConfig_TrustedSigners_Quantity")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("S3Origin_DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFStreamingDistribution (CreateStreamingDistribution)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Aliases_Item != null)
            {
                context.StreamingDistributionConfig_Aliases_Items = new List<System.String>(this.Aliases_Item);
            }
            if (ParameterWasBound("Aliases_Quantity"))
                context.StreamingDistributionConfig_Aliases_Quantity = this.Aliases_Quantity;
            context.StreamingDistributionConfig_CallerReference = this.StreamingDistributionConfig_CallerReference;
            context.StreamingDistributionConfig_Comment = this.StreamingDistributionConfig_Comment;
            if (ParameterWasBound("StreamingDistributionConfig_Enabled"))
                context.StreamingDistributionConfig_Enabled = this.StreamingDistributionConfig_Enabled;
            context.StreamingDistributionConfig_Logging_Bucket = this.Logging_Bucket;
            if (ParameterWasBound("Logging_Enabled"))
                context.StreamingDistributionConfig_Logging_Enabled = this.Logging_Enabled;
            context.StreamingDistributionConfig_Logging_Prefix = this.Logging_Prefix;
            context.StreamingDistributionConfig_PriceClass = this.StreamingDistributionConfig_PriceClass;
            context.StreamingDistributionConfig_S3Origin_DomainName = this.S3Origin_DomainName;
            context.StreamingDistributionConfig_S3Origin_OriginAccessIdentity = this.S3Origin_OriginAccessIdentity;
            if (ParameterWasBound("TrustedSigners_Enabled"))
                context.StreamingDistributionConfig_TrustedSigners_Enabled = this.TrustedSigners_Enabled;
            if (this.TrustedSigners_Item != null)
            {
                context.StreamingDistributionConfig_TrustedSigners_Items = new List<System.String>(this.TrustedSigners_Item);
            }
            if (ParameterWasBound("TrustedSigners_Quantity"))
                context.StreamingDistributionConfig_TrustedSigners_Quantity = this.TrustedSigners_Quantity;
            
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
            bool requestStreamingDistributionConfigIsNull = true;
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
            bool requestStreamingDistributionConfig_streamingDistributionConfig_AliasesIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_Aliases = new Amazon.CloudFront.Model.Aliases();
            List<System.String> requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item = null;
            if (cmdletContext.StreamingDistributionConfig_Aliases_Items != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item = cmdletContext.StreamingDistributionConfig_Aliases_Items;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases.Items = requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Item;
                requestStreamingDistributionConfig_streamingDistributionConfig_AliasesIsNull = false;
            }
            System.Int32? requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Quantity = null;
            if (cmdletContext.StreamingDistributionConfig_Aliases_Quantity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Aliases_aliases_Quantity = cmdletContext.StreamingDistributionConfig_Aliases_Quantity.Value;
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
            bool requestStreamingDistributionConfig_streamingDistributionConfig_S3OriginIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin = new Amazon.CloudFront.Model.S3Origin();
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName = null;
            if (cmdletContext.StreamingDistributionConfig_S3Origin_DomainName != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName = cmdletContext.StreamingDistributionConfig_S3Origin_DomainName;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin.DomainName = requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_DomainName;
                requestStreamingDistributionConfig_streamingDistributionConfig_S3OriginIsNull = false;
            }
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity = null;
            if (cmdletContext.StreamingDistributionConfig_S3Origin_OriginAccessIdentity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_S3Origin_s3Origin_OriginAccessIdentity = cmdletContext.StreamingDistributionConfig_S3Origin_OriginAccessIdentity;
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
            bool requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_Logging = new Amazon.CloudFront.Model.StreamingLoggingConfig();
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket = null;
            if (cmdletContext.StreamingDistributionConfig_Logging_Bucket != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket = cmdletContext.StreamingDistributionConfig_Logging_Bucket;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging.Bucket = requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Bucket;
                requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = false;
            }
            System.Boolean? requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled = null;
            if (cmdletContext.StreamingDistributionConfig_Logging_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled = cmdletContext.StreamingDistributionConfig_Logging_Enabled.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging.Enabled = requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Enabled.Value;
                requestStreamingDistributionConfig_streamingDistributionConfig_LoggingIsNull = false;
            }
            System.String requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Prefix = null;
            if (cmdletContext.StreamingDistributionConfig_Logging_Prefix != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_Logging_logging_Prefix = cmdletContext.StreamingDistributionConfig_Logging_Prefix;
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
            bool requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = true;
            requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners = new Amazon.CloudFront.Model.TrustedSigners();
            System.Boolean? requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled = null;
            if (cmdletContext.StreamingDistributionConfig_TrustedSigners_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled = cmdletContext.StreamingDistributionConfig_TrustedSigners_Enabled.Value;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners.Enabled = requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Enabled.Value;
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = false;
            }
            List<System.String> requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item = null;
            if (cmdletContext.StreamingDistributionConfig_TrustedSigners_Items != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item = cmdletContext.StreamingDistributionConfig_TrustedSigners_Items;
            }
            if (requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners.Items = requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Item;
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSignersIsNull = false;
            }
            System.Int32? requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Quantity = null;
            if (cmdletContext.StreamingDistributionConfig_TrustedSigners_Quantity != null)
            {
                requestStreamingDistributionConfig_streamingDistributionConfig_TrustedSigners_trustedSigners_Quantity = cmdletContext.StreamingDistributionConfig_TrustedSigners_Quantity.Value;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateStreamingDistribution(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> StreamingDistributionConfig_Aliases_Items { get; set; }
            public System.Int32? StreamingDistributionConfig_Aliases_Quantity { get; set; }
            public System.String StreamingDistributionConfig_CallerReference { get; set; }
            public System.String StreamingDistributionConfig_Comment { get; set; }
            public System.Boolean? StreamingDistributionConfig_Enabled { get; set; }
            public System.String StreamingDistributionConfig_Logging_Bucket { get; set; }
            public System.Boolean? StreamingDistributionConfig_Logging_Enabled { get; set; }
            public System.String StreamingDistributionConfig_Logging_Prefix { get; set; }
            public Amazon.CloudFront.PriceClass StreamingDistributionConfig_PriceClass { get; set; }
            public System.String StreamingDistributionConfig_S3Origin_DomainName { get; set; }
            public System.String StreamingDistributionConfig_S3Origin_OriginAccessIdentity { get; set; }
            public System.Boolean? StreamingDistributionConfig_TrustedSigners_Enabled { get; set; }
            public List<System.String> StreamingDistributionConfig_TrustedSigners_Items { get; set; }
            public System.Int32? StreamingDistributionConfig_TrustedSigners_Quantity { get; set; }
        }
        
    }
}
