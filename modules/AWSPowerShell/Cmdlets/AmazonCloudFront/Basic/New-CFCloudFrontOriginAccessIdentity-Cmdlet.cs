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
    /// Creates a new origin access identity. If you're using Amazon S3 for your origin, you
    /// can use an origin access identity to require users to access your content using a
    /// CloudFront URL instead of the Amazon S3 URL. For more information about how to use
    /// origin access identities, see <a href="http://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/PrivateContent.html">Serving
    /// Private Content through CloudFront</a> in the <i>Amazon CloudFront Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "CFCloudFrontOriginAccessIdentity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse")]
    [AWSCmdlet("Invokes the CreateCloudFrontOriginAccessIdentity operation against Amazon CloudFront.", Operation = new[] {"CreateCloudFrontOriginAccessIdentity"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse",
        "This cmdlet returns a Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFCloudFrontOriginAccessIdentityCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter CloudFrontOriginAccessIdentityConfig_CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique number that ensures the request can't be replayed.</para><para>If the <code>CallerReference</code> is new (no matter the content of the <code>CloudFrontOriginAccessIdentityConfig</code>
        /// object), a new origin access identity is created.</para><para>If the <code>CallerReference</code> is a value already sent in a previous identity
        /// request, and the content of the <code>CloudFrontOriginAccessIdentityConfig</code>
        /// is identical to the original request (ignoring white space), the response includes
        /// the same information returned to the original request. </para><para>If the <code>CallerReference</code> is a value you already sent in a previous request
        /// to create an identity, but the content of the <code>CloudFrontOriginAccessIdentityConfig</code>
        /// is different from the original request, CloudFront returns a <code>CloudFrontOriginAccessIdentityAlreadyExists</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloudFrontOriginAccessIdentityConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter CloudFrontOriginAccessIdentityConfig_Comment
        /// <summary>
        /// <para>
        /// <para>Any comments you want to include about the origin access identity. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloudFrontOriginAccessIdentityConfig_Comment { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFCloudFrontOriginAccessIdentity (CreateCloudFrontOriginAccessIdentity)"))
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
            
            context.CloudFrontOriginAccessIdentityConfig_CallerReference = this.CloudFrontOriginAccessIdentityConfig_CallerReference;
            context.CloudFrontOriginAccessIdentityConfig_Comment = this.CloudFrontOriginAccessIdentityConfig_Comment;
            
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
            var request = new Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityRequest();
            
            
             // populate CloudFrontOriginAccessIdentityConfig
            bool requestCloudFrontOriginAccessIdentityConfigIsNull = true;
            request.CloudFrontOriginAccessIdentityConfig = new Amazon.CloudFront.Model.CloudFrontOriginAccessIdentityConfig();
            System.String requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_CallerReference = null;
            if (cmdletContext.CloudFrontOriginAccessIdentityConfig_CallerReference != null)
            {
                requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_CallerReference = cmdletContext.CloudFrontOriginAccessIdentityConfig_CallerReference;
            }
            if (requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_CallerReference != null)
            {
                request.CloudFrontOriginAccessIdentityConfig.CallerReference = requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_CallerReference;
                requestCloudFrontOriginAccessIdentityConfigIsNull = false;
            }
            System.String requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_Comment = null;
            if (cmdletContext.CloudFrontOriginAccessIdentityConfig_Comment != null)
            {
                requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_Comment = cmdletContext.CloudFrontOriginAccessIdentityConfig_Comment;
            }
            if (requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_Comment != null)
            {
                request.CloudFrontOriginAccessIdentityConfig.Comment = requestCloudFrontOriginAccessIdentityConfig_cloudFrontOriginAccessIdentityConfig_Comment;
                requestCloudFrontOriginAccessIdentityConfigIsNull = false;
            }
             // determine if request.CloudFrontOriginAccessIdentityConfig should be set to null
            if (requestCloudFrontOriginAccessIdentityConfigIsNull)
            {
                request.CloudFrontOriginAccessIdentityConfig = null;
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
        
        private static Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityRequest request)
        {
            #if DESKTOP
            return client.CreateCloudFrontOriginAccessIdentity(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateCloudFrontOriginAccessIdentityAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String CloudFrontOriginAccessIdentityConfig_CallerReference { get; set; }
            public System.String CloudFrontOriginAccessIdentityConfig_Comment { get; set; }
        }
        
    }
}
