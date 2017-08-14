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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Sets the UI customization information for a user pool's built-in app UI.
    /// 
    ///  
    /// <para>
    /// You can specify app UI customization settings for a single client (with a specific
    /// <code>clientId</code>) or for all clients (by setting the <code>clientId</code> to
    /// <code>ALL</code>). If you specify <code>ALL</code>, the default configuration will
    /// be used for every client that has no UI customization set previously. If you specify
    /// UI customization settings for a particular client, it will no longer fall back to
    /// the <code>ALL</code> configuration. 
    /// </para><note><para>
    /// To use this API, your user pool must have a domain associated with it. Otherwise,
    /// there is no place to host the app's pages, and the service will throw an error.
    /// </para></note>
    /// </summary>
    [Cmdlet("Set", "CGIPUICustomization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.UICustomizationType")]
    [AWSCmdlet("Invokes the SetUICustomization operation against Amazon Cognito Identity Provider.", Operation = new[] {"SetUICustomization"})]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.UICustomizationType",
        "This cmdlet returns a UICustomizationType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.SetUICustomizationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetCGIPUICustomizationCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the client app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter CSS
        /// <summary>
        /// <para>
        /// <para>The CSS values in the UI customization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CSS { get; set; }
        #endregion
        
        #region Parameter ImageFile
        /// <summary>
        /// <para>
        /// <para>The uploaded logo image for the UI customization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] ImageFile { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID for the user pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserPoolId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserPoolId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIPUICustomization (SetUICustomization)"))
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
            
            context.ClientId = this.ClientId;
            context.CSS = this.CSS;
            context.ImageFile = this.ImageFile;
            context.UserPoolId = this.UserPoolId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _ImageFileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.CognitoIdentityProvider.Model.SetUICustomizationRequest();
                
                if (cmdletContext.ClientId != null)
                {
                    request.ClientId = cmdletContext.ClientId;
                }
                if (cmdletContext.CSS != null)
                {
                    request.CSS = cmdletContext.CSS;
                }
                if (cmdletContext.ImageFile != null)
                {
                    _ImageFileStream = new System.IO.MemoryStream(cmdletContext.ImageFile);
                    request.ImageFile = _ImageFileStream;
                }
                if (cmdletContext.UserPoolId != null)
                {
                    request.UserPoolId = cmdletContext.UserPoolId;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response.UICustomization;
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
            finally
            {
                if( _ImageFileStream != null)
                {
                    _ImageFileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CognitoIdentityProvider.Model.SetUICustomizationResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.SetUICustomizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "SetUICustomization");
            #if DESKTOP
            return client.SetUICustomization(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.SetUICustomizationAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ClientId { get; set; }
            public System.String CSS { get; set; }
            public byte[] ImageFile { get; set; }
            public System.String UserPoolId { get; set; }
        }
        
    }
}
