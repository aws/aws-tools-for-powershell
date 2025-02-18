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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Creates a new origin access identity. If you're using Amazon S3 for your origin, you
    /// can use an origin access identity to require users to access your content using a
    /// CloudFront URL instead of the Amazon S3 URL. For more information about how to use
    /// origin access identities, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/PrivateContent.html">Serving
    /// Private Content through CloudFront</a> in the <i>Amazon CloudFront Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "CFCloudFrontOriginAccessIdentity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateCloudFrontOriginAccessIdentity API operation.", Operation = new[] {"CreateCloudFrontOriginAccessIdentity"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse object containing multiple properties."
    )]
    public partial class NewCFCloudFrontOriginAccessIdentityCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CloudFrontOriginAccessIdentityConfig_CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique value (for example, a date-time stamp) that ensures that the request can't
        /// be replayed.</para><para>If the value of <c>CallerReference</c> is new (regardless of the content of the <c>CloudFrontOriginAccessIdentityConfig</c>
        /// object), a new origin access identity is created.</para><para>If the <c>CallerReference</c> is a value already sent in a previous identity request,
        /// and the content of the <c>CloudFrontOriginAccessIdentityConfig</c> is identical to
        /// the original request (ignoring white space), the response includes the same information
        /// returned to the original request.</para><para>If the <c>CallerReference</c> is a value you already sent in a previous request to
        /// create an identity, but the content of the <c>CloudFrontOriginAccessIdentityConfig</c>
        /// is different from the original request, CloudFront returns a <c>CloudFrontOriginAccessIdentityAlreadyExists</c>
        /// error. </para>
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
        public System.String CloudFrontOriginAccessIdentityConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter CloudFrontOriginAccessIdentityConfig_Comment
        /// <summary>
        /// <para>
        /// <para>A comment to describe the origin access identity. The comment cannot be longer than
        /// 128 characters.</para>
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
        public System.String CloudFrontOriginAccessIdentityConfig_Comment { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFCloudFrontOriginAccessIdentity (CreateCloudFrontOriginAccessIdentity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse, NewCFCloudFrontOriginAccessIdentityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CloudFrontOriginAccessIdentityConfig_CallerReference = this.CloudFrontOriginAccessIdentityConfig_CallerReference;
            #if MODULAR
            if (this.CloudFrontOriginAccessIdentityConfig_CallerReference == null && ParameterWasBound(nameof(this.CloudFrontOriginAccessIdentityConfig_CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudFrontOriginAccessIdentityConfig_CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudFrontOriginAccessIdentityConfig_Comment = this.CloudFrontOriginAccessIdentityConfig_Comment;
            #if MODULAR
            if (this.CloudFrontOriginAccessIdentityConfig_Comment == null && ParameterWasBound(nameof(this.CloudFrontOriginAccessIdentityConfig_Comment)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudFrontOriginAccessIdentityConfig_Comment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityRequest();
            
            
             // populate CloudFrontOriginAccessIdentityConfig
            var requestCloudFrontOriginAccessIdentityConfigIsNull = true;
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
        
        private Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateCloudFrontOriginAccessIdentity");
            try
            {
                return client.CreateCloudFrontOriginAccessIdentityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CloudFrontOriginAccessIdentityConfig_CallerReference { get; set; }
            public System.String CloudFrontOriginAccessIdentityConfig_Comment { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateCloudFrontOriginAccessIdentityResponse, NewCFCloudFrontOriginAccessIdentityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
