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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Retires a grant. To clean up, you can retire a grant when you're done using it. You
    /// should revoke a grant when you intend to actively deny operations that depend on it.
    /// The following are permitted to call this API:
    /// 
    ///  <ul><li><para>
    /// The AWS account (root user) under which the grant was created
    /// </para></li><li><para>
    /// The <code>RetiringPrincipal</code>, if present in the grant
    /// </para></li><li><para>
    /// The <code>GranteePrincipal</code>, if <code>RetireGrant</code> is an operation specified
    /// in the grant
    /// </para></li></ul><para>
    /// You must identify the grant to retire by its grant token or by a combination of the
    /// grant ID and the Amazon Resource Name (ARN) of the customer master key (CMK). A grant
    /// token is a unique variable-length base64-encoded string. A grant ID is a 64 character
    /// unique identifier of a grant. The <a>CreateGrant</a> operation returns both.
    /// </para>
    /// </summary>
    [Cmdlet("Disable", "KMSGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service RetireGrant API operation.", Operation = new[] {"RetireGrant"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.KeyManagementService.Model.RetireGrantResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DisableKMSGrantCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter GrantId
        /// <summary>
        /// <para>
        /// <para>Unique identifier of the grant to retire. The grant ID is returned in the response
        /// to a <code>CreateGrant</code> operation.</para><ul><li><para>Grant ID Example - 0123456789012345678901234567890123456789012345678901234567890123</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GrantId { get; set; }
        #endregion
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>Token that identifies the grant to be retired.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GrantToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the CMK associated with the grant. </para><para>For example: <code>arn:aws:kms:us-east-2:444455556666:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GrantToken", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-KMSGrant (RetireGrant)"))
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
            
            context.GrantId = this.GrantId;
            context.GrantToken = this.GrantToken;
            context.KeyId = this.KeyId;
            
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
            var request = new Amazon.KeyManagementService.Model.RetireGrantRequest();
            
            if (cmdletContext.GrantId != null)
            {
                request.GrantId = cmdletContext.GrantId;
            }
            if (cmdletContext.GrantToken != null)
            {
                request.GrantToken = cmdletContext.GrantToken;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.KeyManagementService.Model.RetireGrantResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.RetireGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "RetireGrant");
            try
            {
                #if DESKTOP
                return client.RetireGrant(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RetireGrantAsync(request);
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
            public System.String GrantId { get; set; }
            public System.String GrantToken { get; set; }
            public System.String KeyId { get; set; }
        }
        
    }
}
