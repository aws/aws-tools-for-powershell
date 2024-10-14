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
using Amazon.Finspace;
using Amazon.Finspace.Model;

namespace Amazon.PowerShell.Cmdlets.FINSP
{
    /// <summary>
    /// Update your FinSpace environment.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Update", "FINSPEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Finspace.Model.Environment")]
    [AWSCmdlet("Calls the FinSpace User Environment Management Service UpdateEnvironment API operation.", Operation = new[] {"UpdateEnvironment"}, SelectReturnType = typeof(Amazon.Finspace.Model.UpdateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.Finspace.Model.Environment or Amazon.Finspace.Model.UpdateEnvironmentResponse",
        "This cmdlet returns an Amazon.Finspace.Model.Environment object.",
        "The service call response (type Amazon.Finspace.Model.UpdateEnvironmentResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This method will be discontinued.")]
    public partial class UpdateFINSPEnvironmentCmdlet : AmazonFinspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FederationParameters_ApplicationCallBackURL
        /// <summary>
        /// <para>
        /// <para>The redirect or sign-in URL that should be entered into the SAML 2.0 compliant identity
        /// provider configuration (IdP).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FederationParameters_ApplicationCallBackURL { get; set; }
        #endregion
        
        #region Parameter FederationParameters_AttributeMap
        /// <summary>
        /// <para>
        /// <para>SAML attribute name and value. The name must always be <c>Email</c> and the value
        /// should be set to the attribute definition in which user email is set. For example,
        /// name would be <c>Email</c> and value <c>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress</c>.
        /// Please check your SAML 2.0 compliant identity provider (IdP) documentation for details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable FederationParameters_AttributeMap { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the FinSpace environment.</para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter FederationMode
        /// <summary>
        /// <para>
        /// <para>Authentication mode for the environment.</para><ul><li><para><c>FEDERATED</c> - Users access FinSpace through Single Sign On (SSO) via your Identity
        /// provider.</para></li><li><para><c>LOCAL</c> - Users access FinSpace via email and password managed within the FinSpace
        /// environment.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Finspace.FederationMode")]
        public Amazon.Finspace.FederationMode FederationMode { get; set; }
        #endregion
        
        #region Parameter FederationParameters_FederationProviderName
        /// <summary>
        /// <para>
        /// <para>Name of the identity provider (IdP).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FederationParameters_FederationProviderName { get; set; }
        #endregion
        
        #region Parameter FederationParameters_FederationURN
        /// <summary>
        /// <para>
        /// <para>The Uniform Resource Name (URN). Also referred as Service Provider URN or Audience
        /// URI or Service Provider Entity ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FederationParameters_FederationURN { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter FederationParameters_SamlMetadataDocument
        /// <summary>
        /// <para>
        /// <para>SAML 2.0 Metadata document from identity provider (IdP).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FederationParameters_SamlMetadataDocument { get; set; }
        #endregion
        
        #region Parameter FederationParameters_SamlMetadataURL
        /// <summary>
        /// <para>
        /// <para>Provide the metadata URL from your SAML 2.0 compliant identity provider (IdP).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FederationParameters_SamlMetadataURL { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Environment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Finspace.Model.UpdateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.Finspace.Model.UpdateEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Environment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EnvironmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EnvironmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EnvironmentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FINSPEnvironment (UpdateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Finspace.Model.UpdateEnvironmentResponse, UpdateFINSPEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EnvironmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FederationMode = this.FederationMode;
            context.FederationParameters_ApplicationCallBackURL = this.FederationParameters_ApplicationCallBackURL;
            if (this.FederationParameters_AttributeMap != null)
            {
                context.FederationParameters_AttributeMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.FederationParameters_AttributeMap.Keys)
                {
                    context.FederationParameters_AttributeMap.Add((String)hashKey, (System.String)(this.FederationParameters_AttributeMap[hashKey]));
                }
            }
            context.FederationParameters_FederationProviderName = this.FederationParameters_FederationProviderName;
            context.FederationParameters_FederationURN = this.FederationParameters_FederationURN;
            context.FederationParameters_SamlMetadataDocument = this.FederationParameters_SamlMetadataDocument;
            context.FederationParameters_SamlMetadataURL = this.FederationParameters_SamlMetadataURL;
            context.Name = this.Name;
            
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
            var request = new Amazon.Finspace.Model.UpdateEnvironmentRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.FederationMode != null)
            {
                request.FederationMode = cmdletContext.FederationMode;
            }
            
             // populate FederationParameters
            var requestFederationParametersIsNull = true;
            request.FederationParameters = new Amazon.Finspace.Model.FederationParameters();
            System.String requestFederationParameters_federationParameters_ApplicationCallBackURL = null;
            if (cmdletContext.FederationParameters_ApplicationCallBackURL != null)
            {
                requestFederationParameters_federationParameters_ApplicationCallBackURL = cmdletContext.FederationParameters_ApplicationCallBackURL;
            }
            if (requestFederationParameters_federationParameters_ApplicationCallBackURL != null)
            {
                request.FederationParameters.ApplicationCallBackURL = requestFederationParameters_federationParameters_ApplicationCallBackURL;
                requestFederationParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestFederationParameters_federationParameters_AttributeMap = null;
            if (cmdletContext.FederationParameters_AttributeMap != null)
            {
                requestFederationParameters_federationParameters_AttributeMap = cmdletContext.FederationParameters_AttributeMap;
            }
            if (requestFederationParameters_federationParameters_AttributeMap != null)
            {
                request.FederationParameters.AttributeMap = requestFederationParameters_federationParameters_AttributeMap;
                requestFederationParametersIsNull = false;
            }
            System.String requestFederationParameters_federationParameters_FederationProviderName = null;
            if (cmdletContext.FederationParameters_FederationProviderName != null)
            {
                requestFederationParameters_federationParameters_FederationProviderName = cmdletContext.FederationParameters_FederationProviderName;
            }
            if (requestFederationParameters_federationParameters_FederationProviderName != null)
            {
                request.FederationParameters.FederationProviderName = requestFederationParameters_federationParameters_FederationProviderName;
                requestFederationParametersIsNull = false;
            }
            System.String requestFederationParameters_federationParameters_FederationURN = null;
            if (cmdletContext.FederationParameters_FederationURN != null)
            {
                requestFederationParameters_federationParameters_FederationURN = cmdletContext.FederationParameters_FederationURN;
            }
            if (requestFederationParameters_federationParameters_FederationURN != null)
            {
                request.FederationParameters.FederationURN = requestFederationParameters_federationParameters_FederationURN;
                requestFederationParametersIsNull = false;
            }
            System.String requestFederationParameters_federationParameters_SamlMetadataDocument = null;
            if (cmdletContext.FederationParameters_SamlMetadataDocument != null)
            {
                requestFederationParameters_federationParameters_SamlMetadataDocument = cmdletContext.FederationParameters_SamlMetadataDocument;
            }
            if (requestFederationParameters_federationParameters_SamlMetadataDocument != null)
            {
                request.FederationParameters.SamlMetadataDocument = requestFederationParameters_federationParameters_SamlMetadataDocument;
                requestFederationParametersIsNull = false;
            }
            System.String requestFederationParameters_federationParameters_SamlMetadataURL = null;
            if (cmdletContext.FederationParameters_SamlMetadataURL != null)
            {
                requestFederationParameters_federationParameters_SamlMetadataURL = cmdletContext.FederationParameters_SamlMetadataURL;
            }
            if (requestFederationParameters_federationParameters_SamlMetadataURL != null)
            {
                request.FederationParameters.SamlMetadataURL = requestFederationParameters_federationParameters_SamlMetadataURL;
                requestFederationParametersIsNull = false;
            }
             // determine if request.FederationParameters should be set to null
            if (requestFederationParametersIsNull)
            {
                request.FederationParameters = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Finspace.Model.UpdateEnvironmentResponse CallAWSServiceOperation(IAmazonFinspace client, Amazon.Finspace.Model.UpdateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace User Environment Management Service", "UpdateEnvironment");
            try
            {
                #if DESKTOP
                return client.UpdateEnvironment(request);
                #elif CORECLR
                return client.UpdateEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String EnvironmentId { get; set; }
            public Amazon.Finspace.FederationMode FederationMode { get; set; }
            public System.String FederationParameters_ApplicationCallBackURL { get; set; }
            public Dictionary<System.String, System.String> FederationParameters_AttributeMap { get; set; }
            public System.String FederationParameters_FederationProviderName { get; set; }
            public System.String FederationParameters_FederationURN { get; set; }
            public System.String FederationParameters_SamlMetadataDocument { get; set; }
            public System.String FederationParameters_SamlMetadataURL { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.Finspace.Model.UpdateEnvironmentResponse, UpdateFINSPEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Environment;
        }
        
    }
}
