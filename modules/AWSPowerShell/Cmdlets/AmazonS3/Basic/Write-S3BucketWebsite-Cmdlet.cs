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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Set the website configuration for a bucket.
    /// </summary>
    [Cmdlet("Write", "S3BucketWebsite", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service PutBucketWebsite API operation.", Operation = new[] {"PutBucketWebsite"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the BucketName parameter. Otherwise, this cmdlet does not return any output. " +
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
        [System.Management.Automation.Parameter]
        public System.String WebsiteConfiguration_ErrorDocument { get; set; }
        #endregion
        
        #region Parameter RedirectAllRequestsTo_HostName
        /// <summary>
        /// <para>
        /// Name of the host where requests will be redirected.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WebsiteConfiguration_RedirectAllRequestsTo_HostName")]
        public System.String RedirectAllRequestsTo_HostName { get; set; }
        #endregion
        
        #region Parameter RedirectAllRequestsTo_HttpRedirectCode
        /// <summary>
        /// <para>
        /// The HTTP redirect code to use on the response. Not required if one of the siblings is present.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String WebsiteConfiguration_IndexDocumentSuffix { get; set; }
        #endregion
        
        #region Parameter RedirectAllRequestsTo_Protocol
        /// <summary>
        /// <para>
        /// Protocol to use (http, https) when redirecting requests. The default is the protocol that is used in the original request.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyWith")]
        public System.String RedirectAllRequestsTo_ReplaceKeyWith { get; set; }
        #endregion
        
        #region Parameter WebsiteConfiguration_RoutingRule
        /// <summary>
        /// <para>
        /// The list of routing rules that can be used for configuring redirects if certain conditions are meet.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WebsiteConfiguration_RoutingRules")]
        public Amazon.S3.Model.RoutingRule[] WebsiteConfiguration_RoutingRule { get; set; }
        #endregion
        
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        
        #endregion
        
        #region Parameter UseDualstackEndpoint
        /// <summary>
        /// Configures the request to Amazon S3 to use the dualstack endpoint for a region.
        /// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.
        /// The dualstack mode of Amazon S3 cannot be used with accelerate mode.
        /// </summary>
        [Parameter]
        public SwitchParameter UseDualstackEndpoint { get; set; }
        
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the BucketName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BucketName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketWebsite (PutBucketWebsite)"))
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
            
            context.BucketName = this.BucketName;
            context.WebsiteConfiguration_ErrorDocument = this.WebsiteConfiguration_ErrorDocument;
            context.WebsiteConfiguration_IndexDocumentSuffix = this.WebsiteConfiguration_IndexDocumentSuffix;
            context.WebsiteConfiguration_RedirectAllRequestsTo_HostName = this.RedirectAllRequestsTo_HostName;
            context.WebsiteConfiguration_RedirectAllRequestsTo_HttpRedirectCode = this.RedirectAllRequestsTo_HttpRedirectCode;
            context.WebsiteConfiguration_RedirectAllRequestsTo_Protocol = this.RedirectAllRequestsTo_Protocol;
            context.WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyPrefixWith = this.RedirectAllRequestsTo_ReplaceKeyPrefixWith;
            context.WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyWith = this.RedirectAllRequestsTo_ReplaceKeyWith;
            if (this.WebsiteConfiguration_RoutingRule != null)
            {
                context.WebsiteConfiguration_RoutingRules = new List<Amazon.S3.Model.RoutingRule>(this.WebsiteConfiguration_RoutingRule);
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
            var request = new Amazon.S3.Model.PutBucketWebsiteRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            
             // populate WebsiteConfiguration
            bool requestWebsiteConfigurationIsNull = true;
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
            if (cmdletContext.WebsiteConfiguration_RoutingRules != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RoutingRule = cmdletContext.WebsiteConfiguration_RoutingRules;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RoutingRule != null)
            {
                request.WebsiteConfiguration.RoutingRules = requestWebsiteConfiguration_websiteConfiguration_RoutingRule;
                requestWebsiteConfigurationIsNull = false;
            }
            Amazon.S3.Model.RoutingRuleRedirect requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo = null;
            
             // populate RedirectAllRequestsTo
            bool requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = true;
            requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo = new Amazon.S3.Model.RoutingRuleRedirect();
            System.String requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HostName = null;
            if (cmdletContext.WebsiteConfiguration_RedirectAllRequestsTo_HostName != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HostName = cmdletContext.WebsiteConfiguration_RedirectAllRequestsTo_HostName;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HostName != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo.HostName = requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HostName;
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = false;
            }
            System.String requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HttpRedirectCode = null;
            if (cmdletContext.WebsiteConfiguration_RedirectAllRequestsTo_HttpRedirectCode != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HttpRedirectCode = cmdletContext.WebsiteConfiguration_RedirectAllRequestsTo_HttpRedirectCode;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HttpRedirectCode != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo.HttpRedirectCode = requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_HttpRedirectCode;
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = false;
            }
            System.String requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_Protocol = null;
            if (cmdletContext.WebsiteConfiguration_RedirectAllRequestsTo_Protocol != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_Protocol = cmdletContext.WebsiteConfiguration_RedirectAllRequestsTo_Protocol;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_Protocol != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo.Protocol = requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_Protocol;
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = false;
            }
            System.String requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyPrefixWith = null;
            if (cmdletContext.WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyPrefixWith != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyPrefixWith = cmdletContext.WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyPrefixWith;
            }
            if (requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyPrefixWith != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo.ReplaceKeyPrefixWith = requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyPrefixWith;
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsToIsNull = false;
            }
            System.String requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyWith = null;
            if (cmdletContext.WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyWith != null)
            {
                requestWebsiteConfiguration_websiteConfiguration_RedirectAllRequestsTo_redirectAllRequestsTo_ReplaceKeyWith = cmdletContext.WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyWith;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.BucketName;
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
        
        private Amazon.S3.Model.PutBucketWebsiteResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketWebsiteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service", "PutBucketWebsite");
            try
            {
                #if DESKTOP
                return client.PutBucketWebsite(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutBucketWebsiteAsync(request);
                return task.Result;
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
            public System.String WebsiteConfiguration_RedirectAllRequestsTo_HostName { get; set; }
            public System.String WebsiteConfiguration_RedirectAllRequestsTo_HttpRedirectCode { get; set; }
            public System.String WebsiteConfiguration_RedirectAllRequestsTo_Protocol { get; set; }
            public System.String WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyPrefixWith { get; set; }
            public System.String WebsiteConfiguration_RedirectAllRequestsTo_ReplaceKeyWith { get; set; }
            public List<Amazon.S3.Model.RoutingRule> WebsiteConfiguration_RoutingRules { get; set; }
        }
        
    }
}
