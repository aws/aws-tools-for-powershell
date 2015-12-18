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
    /// Update an origin access identity.
    /// </summary>
    [Cmdlet("Update", "CFCloudFrontOriginAccessIdentity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CloudFrontOriginAccessIdentity")]
    [AWSCmdlet("Invokes the UpdateCloudFrontOriginAccessIdentity operation against Amazon CloudFront.", Operation = new[] {"UpdateCloudFrontOriginAccessIdentity"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CloudFrontOriginAccessIdentity",
        "This cmdlet returns a CloudFrontOriginAccessIdentity object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: ETag (type System.String)"
    )]
    public class UpdateCFCloudFrontOriginAccessIdentityCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter CloudFrontOriginAccessIdentityConfig_CallerReference
        /// <summary>
        /// <para>
        /// A unique number that ensures the request
        /// can't be replayed. If the CallerReference is new (no matter the content of the CloudFrontOriginAccessIdentityConfig
        /// object), a new origin access identity is created. If the CallerReference is a value
        /// you already sent in a previous request to create an identity, and the content of the
        /// CloudFrontOriginAccessIdentityConfig is identical to the original request (ignoring
        /// white space), the response includes the same information returned to the original
        /// request. If the CallerReference is a value you already sent in a previous request
        /// to create an identity but the content of the CloudFrontOriginAccessIdentityConfig
        /// is different from the original request, CloudFront returns a CloudFrontOriginAccessIdentityAlreadyExists
        /// error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloudFrontOriginAccessIdentityConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter CloudFrontOriginAccessIdentityConfig_Comment
        /// <summary>
        /// <para>
        /// Any comments you want to include about the origin
        /// access identity.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloudFrontOriginAccessIdentityConfig_Comment { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The identity's id.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// The value of the ETag header you received when
        /// retrieving the identity's configuration. For example: E2QWRUHAPOMQZL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String IfMatch { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Id", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFCloudFrontOriginAccessIdentity (UpdateCloudFrontOriginAccessIdentity)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CloudFrontOriginAccessIdentityConfig_CallerReference = this.CloudFrontOriginAccessIdentityConfig_CallerReference;
            context.CloudFrontOriginAccessIdentityConfig_Comment = this.CloudFrontOriginAccessIdentityConfig_Comment;
            context.Id = this.Id;
            context.IfMatch = this.IfMatch;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudFront.Model.UpdateCloudFrontOriginAccessIdentityRequest();
            
            
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
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateCloudFrontOriginAccessIdentity(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CloudFrontOriginAccessIdentity;
                notes = new Dictionary<string, object>();
                notes["ETag"] = response.ETag;
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
            public System.String CloudFrontOriginAccessIdentityConfig_CallerReference { get; set; }
            public System.String CloudFrontOriginAccessIdentityConfig_Comment { get; set; }
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
        }
        
    }
}
