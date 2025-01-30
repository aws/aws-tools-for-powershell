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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Sets the user interface (UI) customization information for a user pool's built-in
    /// app UI.
    /// 
    ///  
    /// <para>
    /// You can specify app UI customization settings for a single client (with a specific
    /// <c>clientId</c>) or for all clients (by setting the <c>clientId</c> to <c>ALL</c>).
    /// If you specify <c>ALL</c>, the default configuration is used for every client that
    /// has no previously set UI customization. If you specify UI customization settings for
    /// a particular client, it will no longer return to the <c>ALL</c> configuration.
    /// </para><note><para>
    /// To use this API, your user pool must have a domain associated with it. Otherwise,
    /// there is no place to host the app's pages, and the service will throw an error.
    /// </para></note>
    /// </summary>
    [Cmdlet("Set", "CGIPUICustomization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.UICustomizationType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider SetUICustomization API operation.", Operation = new[] {"SetUICustomization"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.SetUICustomizationResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.UICustomizationType or Amazon.CognitoIdentityProvider.Model.SetUICustomizationResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.UICustomizationType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.SetUICustomizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetCGIPUICustomizationCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CSS { get; set; }
        #endregion
        
        #region Parameter ImageFile
        /// <summary>
        /// <para>
        /// <para>The uploaded logo image for the UI customization.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] ImageFile { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UICustomization'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.SetUICustomizationResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.SetUICustomizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UICustomization";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserPoolId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserPoolId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserPoolId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIPUICustomization (SetUICustomization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.SetUICustomizationResponse, SetCGIPUICustomizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserPoolId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientId = this.ClientId;
            context.CSS = this.CSS;
            context.ImageFile = this.ImageFile;
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            try
            {
                #if DESKTOP
                return client.SetUICustomization(request);
                #elif CORECLR
                return client.SetUICustomizationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientId { get; set; }
            public System.String CSS { get; set; }
            public byte[] ImageFile { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.SetUICustomizationResponse, SetCGIPUICustomizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UICustomization;
        }
        
    }
}
