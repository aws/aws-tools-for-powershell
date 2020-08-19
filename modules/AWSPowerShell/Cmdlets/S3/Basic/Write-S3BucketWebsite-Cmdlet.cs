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
    /// Sets the configuration of the website that is specified in the <code>website</code>
    /// subresource. To configure a bucket as a website, you can add this subresource on the
    /// bucket with website configuration information such as the file name of the index document
    /// and any redirect rules. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/WebsiteHosting.html">Hosting
    /// Websites on Amazon S3</a>.
    /// 
    ///  
    /// <para>
    /// This PUT operation requires the <code>S3:PutBucketWebsite</code> permission. By default,
    /// only the bucket owner can configure the website attached to a bucket; however, bucket
    /// owners can allow other users to set the website configuration by writing a bucket
    /// policy that grants them the <code>S3:PutBucketWebsite</code> permission.
    /// </para><para>
    /// To redirect all website requests sent to the bucket's website endpoint, you add a
    /// website configuration with the following elements. Because all requests are sent to
    /// another website, you don't need to provide index document name for the bucket.
    /// </para><ul><li><para><code>WebsiteConfiguration</code></para></li><li><para><code>RedirectAllRequestsTo</code></para></li><li><para><code>HostName</code></para></li><li><para><code>Protocol</code></para></li></ul><para>
    /// If you want granular control over redirects, you can use the following elements to
    /// add routing rules that describe conditions for redirecting requests and information
    /// about the redirect destination. In this case, the website configuration must provide
    /// an index document for the bucket, because some requests might not be redirected. 
    /// </para><ul><li><para><code>WebsiteConfiguration</code></para></li><li><para><code>IndexDocument</code></para></li><li><para><code>Suffix</code></para></li><li><para><code>ErrorDocument</code></para></li><li><para><code>Key</code></para></li><li><para><code>RoutingRules</code></para></li><li><para><code>RoutingRule</code></para></li><li><para><code>Condition</code></para></li><li><para><code>HttpErrorCodeReturnedEquals</code></para></li><li><para><code>KeyPrefixEquals</code></para></li><li><para><code>Redirect</code></para></li><li><para><code>Protocol</code></para></li><li><para><code>HostName</code></para></li><li><para><code>ReplaceKeyPrefixWith</code></para></li><li><para><code>ReplaceKeyWith</code></para></li><li><para><code>HttpRedirectCode</code></para></li></ul><para>
    /// Amazon S3 has a limitation of 50 routing rules per website configuration. If you require
    /// more than 50 routing rules, you can use object redirect. For more information, see
    /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/how-to-page-redirect.html">Configuring
    /// an Object Redirect</a> in the <i>Amazon Simple Storage Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "S3BucketWebsite", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketWebsite API operation.", Operation = new[] {"PutBucketWebsite"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketWebsiteResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketWebsiteResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketWebsiteResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3BucketWebsiteCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket to apply the configuration to.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter WebsiteConfiguration_ErrorDocument
        /// <summary>
        /// <para>
        /// The ErrorDocument value, an object key name to use when a 4XX class error occurs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WebsiteConfiguration_ErrorDocument { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// The account id of the expected bucket owner. 
        /// If the bucket is owned by a different account, the request will fail with an HTTP 403 (Access Denied) error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter RedirectAllRequestsTo_HostName
        /// <summary>
        /// <para>
        /// Name of the host where requests will be redirected.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WebsiteConfiguration_RedirectAllRequestsTo_HostName")]
        public System.String RedirectAllRequestsTo_HostName { get; set; }
        #endregion
        
        #region Parameter RedirectAllRequestsTo_HttpRedirectCode
        /// <summary>
        /// <para>
        /// The HTTP redirect code to use on the response. Not required if one of the siblings is present.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WebsiteConfiguration_RedirectAllRequestsTo_HttpRedirectCode")]
        public System.String RedirectAllRequestsTo_HttpRedirectCode { get; set; }
        #endregion
        
        #region Parameter WebsiteConfiguration_IndexDocumentSuffix
        /// <summary>
        /// <para>
        /// <para>This value is a suffix that is appended to a request that is for a "directory" 
        /// on the website endpoint (e.g. if the suffix is index.html and
        /// you make a request to samplebucket/images/ the data that
        /// is returned will be for the object with the key name
        /// images/index.html)</para><para>The suffix must not be empty and must not include a slash
        /// character.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WebsiteConfiguration_IndexDocumentSuffix { get; set; }
        #endregion
        
        #region Parameter RedirectAllRequestsTo_Protocol
        /// <summary>
        /// <para>
        /// Protocol to use (http, https) when redirecting requests. The default is the protocol that is used in the original request.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WebsiteConfiguration_RedirectAllRequestsTo_Protocol")]
        public System.String RedirectAllRequestsTo_Protocol { get; set; }
        #endregion
        
        #region Parameter RedirectAllRequestsTo_ReplaceKeyPrefixWith
        /// <summary>
        /// <para>
        /// The object key prefix to use in the redirect request. For example, to redirect requests for all pages with prefix docs/ (objects in the
        /// docs/ folder) to documents/, you can set a condition block with KeyPrefixEquals set to docs/ and in the Redirect set ReplaceKeyPrefixWith to
        /// /documents. Not required if one of the siblings is present. Can be present only if ReplaceKeyWith is not provided.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyPrefixWith")]
        public System.String RedirectAllRequestsTo_ReplaceKeyPrefixWith { get; set; }
        #endregion
        
        #region Parameter RedirectAllRequestsTo_ReplaceKeyWith
        /// <summary>
        /// <para>
        /// The specific object key to use in the redirect request. For example, redirect request to error.html. Not required if one of the sibling is
        /// present. Can be present only if ReplaceKeyPrefixWith is not provided.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyWith")]
        public System.String RedirectAllRequestsTo_ReplaceKeyWith { get; set; }
        #endregion
        
        #region Parameter WebsiteConfiguration_RoutingRule
        /// <summary>
        /// <para>
        /// The list of routing rules that can be used for configuring redirects if certain conditions are meet.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WebsiteConfiguration_RoutingRules")]
        public Amazon.S3.Model.RoutingRule[] WebsiteConfiguration_RoutingRule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketWebsiteResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketWebsite (PutBucketWebsite)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketWebsiteResponse, WriteS3BucketWebsiteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            context.WebsiteConfiguration_ErrorDocument = this.WebsiteConfiguration_ErrorDocument;
            context.WebsiteConfiguration_IndexDocumentSuffix = this.WebsiteConfiguration_IndexDocumentSuffix;
            context.RedirectAllRequestsTo_HostName = this.RedirectAllRequestsTo_HostName;
            context.RedirectAllRequestsTo_HttpRedirectCode = this.RedirectAllRequestsTo_HttpRedirectCode;
            context.RedirectAllRequestsTo_Protocol = this.RedirectAllRequestsTo_Protocol;
            context.RedirectAllRequestsTo_ReplaceKeyPrefixWith = this.RedirectAllRequestsTo_ReplaceKeyPrefixWith;
            context.RedirectAllRequestsTo_ReplaceKeyWith = this.RedirectAllRequestsTo_ReplaceKeyWith;
            if (this.WebsiteConfiguration_RoutingRule != null)
            {
                context.WebsiteConfiguration_RoutingRule = new List<Amazon.S3.Model.RoutingRule>(this.WebsiteConfiguration_RoutingRule);
            }
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            
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
            var request = new Amazon.S3.Model.PutBucketWebsiteRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            
             // populate WebsiteConfiguration
            var requestWebsiteConfigurationIsNull = true;
            request.WebsiteConfiguration = new Amazon.S3.Model.WebsiteConfiguration();
            System.String requestWebsiteConfiguration_websiteConfiguration_ErrorDocument = null;
            if (cmdletContext.WebsiteConfiguration_ErrorDocument != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_ErrorDocument = cmdletContext.WebsiteConfiguration_ErrorDocument;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_ErrorDocument != null)
            {
                request.WebsiteConfiguration.ErrorDocument = requestWebsiteConfiguration_websiteConfiguration_ErrorDocument;
                requestWebsiteConfigurationIsNull = false;
            }
            System.String requestWebsiteConfiguration_websiteConfiguration_IndexDocumentSuffix = null;
            if (cmdletContext.WebsiteConfiguration_IndexDocumentSuffix != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_IndexDocumentSuffix = cmdletContext.WebsiteConfiguration_IndexDocumentSuffix;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_IndexDocumentSuffix != null)
            {
                request.WebsiteConfiguration.IndexDocumentSuffix = requestWebsiteConfiguration_websiteConfiguration_IndexDocumentSuffix;
                requestWebsiteConfigurationIsNull = false;
            }
            List<Amazon.S3.Model.RoutingRule> requestWebsiteConfiguration_websiteConfiguration_RoutingRule = null;
            if (cmdletContext.WebsiteConfiguration_RoutingRule != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RoutingRule = cmdletContext.WebsiteConfiguration_RoutingRule;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RoutingRule != null)
            {
                request.WebsiteConfiguration.RoutingRules = requestWebsiteConfiguration_websiteConfiguration_RoutingRule;
                requestWebsiteConfigurationIsNull = false;
            }
            Amazon.S3.Model.RoutingRuleRedirect requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo = null;
            
             // populate RedirectAllRequestsTo
            var requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = true;
            requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo = new Amazon.S3.Model.RoutingRuleRedirect();
            System.String requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HostName = null;
            if (cmdletContext.RedirectAllRequestsTo_HostName != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HostName = cmdletContext.RedirectAllRequestsTo_HostName;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HostName != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo.HostName = requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HostName;
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = false;
            }
            System.String requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HttpRedirectCode = null;
            if (cmdletContext.RedirectAllRequestsTo_HttpRedirectCode != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HttpRedirectCode = cmdletContext.RedirectAllRequestsTo_HttpRedirectCode;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HttpRedirectCode != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo.HttpRedirectCode = requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HttpRedirectCode;
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = false;
            }
            System.String requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_Protocol = null;
            if (cmdletContext.RedirectAllRequestsTo_Protocol != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_Protocol = cmdletContext.RedirectAllRequestsTo_Protocol;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_Protocol != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo.Protocol = requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_Protocol;
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = false;
            }
            System.String requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyPrefixWith = null;
            if (cmdletContext.RedirectAllRequestsTo_ReplaceKeyPrefixWith != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyPrefixWith = cmdletContext.RedirectAllRequestsTo_ReplaceKeyPrefixWith;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyPrefixWith != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo.ReplaceKeyPrefixWith = requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyPrefixWith;
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = false;
            }
            System.String requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyWith = null;
            if (cmdletContext.RedirectAllRequestsTo_ReplaceKeyWith != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyWith = cmdletContext.RedirectAllRequestsTo_ReplaceKeyWith;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyWith != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo.ReplaceKeyWith = requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyWith;
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = false;
            }
             // determine if requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo should be set to null
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo = null;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo != null)
            {
                request.WebsiteConfiguration.RedirectAllRequestsTo = requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo;
                requestWebsiteConfigurationIsNull = false;
            }
             // determine if request.WebsiteConfiguration should be set to null
            if (requestWebsiteConfigurationIsNull)
            {
                request.WebsiteConfiguration = null;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
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
        
        private Amazon.S3.Model.PutBucketWebsiteResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketWebsiteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketWebsite");
            try
            {
                #if DESKTOP
                return client.PutBucketWebsite(request);
                #elif CORECLR
                return client.PutBucketWebsiteAsync(request).GetAwaiter().GetResult();
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
            public System.String WebsiteConfiguration_ErrorDocument { get; set; }
            public System.String WebsiteConfiguration_IndexDocumentSuffix { get; set; }
            public System.String RedirectAllRequestsTo_HostName { get; set; }
            public System.String RedirectAllRequestsTo_HttpRedirectCode { get; set; }
            public System.String RedirectAllRequestsTo_Protocol { get; set; }
            public System.String RedirectAllRequestsTo_ReplaceKeyPrefixWith { get; set; }
            public System.String RedirectAllRequestsTo_ReplaceKeyWith { get; set; }
            public List<Amazon.S3.Model.RoutingRule> WebsiteConfiguration_RoutingRule { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketWebsiteResponse, WriteS3BucketWebsiteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
