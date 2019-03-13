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
    /// Update public key information. Note that the only value you can change is the comment.
    /// </summary>
    [Cmdlet("Update", "CFPublicKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.PublicKey")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdatePublicKey API operation.", Operation = new[] {"UpdatePublicKey"})]
    [AWSCmdletOutput("Amazon.CloudFront.Model.PublicKey",
        "This cmdlet returns a PublicKey object.",
        "The service call response (type Amazon.CloudFront.Model.UpdatePublicKeyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: ETag (type System.String)"
    )]
    public partial class UpdateCFPublicKeyCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter PublicKeyConfig_CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique number that ensures that the request can't be replayed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PublicKeyConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter PublicKeyConfig_Comment
        /// <summary>
        /// <para>
        /// <para>An optional comment about a public key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PublicKeyConfig_Comment { get; set; }
        #endregion
        
        #region Parameter PublicKeyConfig_EncodedKey
        /// <summary>
        /// <para>
        /// <para>The encoded public key that you want to add to CloudFront to use with features like
        /// field-level encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PublicKeyConfig_EncodedKey { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>ID of the public key to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The value of the <code>ETag</code> header that you received when retrieving the public
        /// key to update. For example: <code>E2QWRUHAPOMQZL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter PublicKeyConfig_Name
        /// <summary>
        /// <para>
        /// <para>The name for a public key you add to CloudFront to use with features like field-level
        /// encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PublicKeyConfig_Name { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFPublicKey (UpdatePublicKey)"))
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
            
            context.Id = this.Id;
            context.IfMatch = this.IfMatch;
            context.PublicKeyConfig_CallerReference = this.PublicKeyConfig_CallerReference;
            context.PublicKeyConfig_Comment = this.PublicKeyConfig_Comment;
            context.PublicKeyConfig_EncodedKey = this.PublicKeyConfig_EncodedKey;
            context.PublicKeyConfig_Name = this.PublicKeyConfig_Name;
            
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
            var request = new Amazon.CloudFront.Model.UpdatePublicKeyRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            
             // populate PublicKeyConfig
            bool requestPublicKeyConfigIsNull = true;
            request.PublicKeyConfig = new Amazon.CloudFront.Model.PublicKeyConfig();
            System.String requestPublicKeyConfig_publicKeyConfig_CallerReference = null;
            if (cmdletContext.PublicKeyConfig_CallerReference != null)
            {
                requestPublicKeyConfig_publicKeyConfig_CallerReference = cmdletContext.PublicKeyConfig_CallerReference;
            }
            if (requestPublicKeyConfig_publicKeyConfig_CallerReference != null)
            {
                request.PublicKeyConfig.CallerReference = requestPublicKeyConfig_publicKeyConfig_CallerReference;
                requestPublicKeyConfigIsNull = false;
            }
            System.String requestPublicKeyConfig_publicKeyConfig_Comment = null;
            if (cmdletContext.PublicKeyConfig_Comment != null)
            {
                requestPublicKeyConfig_publicKeyConfig_Comment = cmdletContext.PublicKeyConfig_Comment;
            }
            if (requestPublicKeyConfig_publicKeyConfig_Comment != null)
            {
                request.PublicKeyConfig.Comment = requestPublicKeyConfig_publicKeyConfig_Comment;
                requestPublicKeyConfigIsNull = false;
            }
            System.String requestPublicKeyConfig_publicKeyConfig_EncodedKey = null;
            if (cmdletContext.PublicKeyConfig_EncodedKey != null)
            {
                requestPublicKeyConfig_publicKeyConfig_EncodedKey = cmdletContext.PublicKeyConfig_EncodedKey;
            }
            if (requestPublicKeyConfig_publicKeyConfig_EncodedKey != null)
            {
                request.PublicKeyConfig.EncodedKey = requestPublicKeyConfig_publicKeyConfig_EncodedKey;
                requestPublicKeyConfigIsNull = false;
            }
            System.String requestPublicKeyConfig_publicKeyConfig_Name = null;
            if (cmdletContext.PublicKeyConfig_Name != null)
            {
                requestPublicKeyConfig_publicKeyConfig_Name = cmdletContext.PublicKeyConfig_Name;
            }
            if (requestPublicKeyConfig_publicKeyConfig_Name != null)
            {
                request.PublicKeyConfig.Name = requestPublicKeyConfig_publicKeyConfig_Name;
                requestPublicKeyConfigIsNull = false;
            }
             // determine if request.PublicKeyConfig should be set to null
            if (requestPublicKeyConfigIsNull)
            {
                request.PublicKeyConfig = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PublicKey;
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
        
        #region AWS Service Operation Call
        
        private Amazon.CloudFront.Model.UpdatePublicKeyResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdatePublicKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdatePublicKey");
            try
            {
                #if DESKTOP
                return client.UpdatePublicKey(request);
                #elif CORECLR
                return client.UpdatePublicKeyAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.String PublicKeyConfig_CallerReference { get; set; }
            public System.String PublicKeyConfig_Comment { get; set; }
            public System.String PublicKeyConfig_EncodedKey { get; set; }
            public System.String PublicKeyConfig_Name { get; set; }
        }
        
    }
}
