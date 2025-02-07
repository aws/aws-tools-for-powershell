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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Creates an application in IAM Identity Center for the given application provider.
    /// </summary>
    [Cmdlet("New", "SSOADMNApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("System.String or Amazon.SSOAdmin.Model.CreateApplicationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SSOAdmin.Model.CreateApplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSSOADMNApplicationCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationProviderArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the application provider under which the operation will run.</para>
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
        public System.String ApplicationProviderArn { get; set; }
        #endregion
        
        #region Parameter SignInOptions_ApplicationUrl
        /// <summary>
        /// <para>
        /// <para>The URL that accepts authentication requests for an application. This is a required
        /// parameter if the <c>Origin</c> parameter is <c>APPLICATION</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortalOptions_SignInOptions_ApplicationUrl")]
        public System.String SignInOptions_ApplicationUrl { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the instance of IAM Identity Center under which the operation will run.
        /// For more information about ARNs, see <a href="/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a> in the <i>Amazon
        /// Web Services General Reference</i>.</para>
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
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the .</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SignInOptions_Origin
        /// <summary>
        /// <para>
        /// <para>This determines how IAM Identity Center navigates the user to the target application.
        /// It can be one of the following values:</para><ul><li><para><c>APPLICATION</c>: IAM Identity Center redirects the customer to the configured
        /// <c>ApplicationUrl</c>.</para></li><li><para><c>IDENTITY_CENTER</c>: IAM Identity Center uses SAML identity-provider initiated
        /// authentication to sign the customer directly into a SAML-based application.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortalOptions_SignInOptions_Origin")]
        [AWSConstantClassSource("Amazon.SSOAdmin.SignInOrigin")]
        public Amazon.SSOAdmin.SignInOrigin SignInOptions_Origin { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Specifies whether the application is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SSOAdmin.ApplicationStatus")]
        public Amazon.SSOAdmin.ApplicationStatus Status { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies tags to be attached to the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SSOAdmin.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter PortalOptions_Visibility
        /// <summary>
        /// <para>
        /// <para>Indicates whether this application is visible in the access portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SSOAdmin.ApplicationVisibility")]
        public Amazon.SSOAdmin.ApplicationVisibility PortalOptions_Visibility { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive ID that you provide to ensure the idempotency of
        /// the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>IdempotentParameterMismatch</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.SSOAdmin.Model.CreateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSOADMNApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.CreateApplicationResponse, NewSSOADMNApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationProviderArn = this.ApplicationProviderArn;
            #if MODULAR
            if (this.ApplicationProviderArn == null && ParameterWasBound(nameof(this.ApplicationProviderArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationProviderArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SignInOptions_ApplicationUrl = this.SignInOptions_ApplicationUrl;
            context.SignInOptions_Origin = this.SignInOptions_Origin;
            context.PortalOptions_Visibility = this.PortalOptions_Visibility;
            context.Status = this.Status;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SSOAdmin.Model.Tag>(this.Tag);
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
            var request = new Amazon.SSOAdmin.Model.CreateApplicationRequest();
            
            if (cmdletContext.ApplicationProviderArn != null)
            {
                request.ApplicationProviderArn = cmdletContext.ApplicationProviderArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PortalOptions
            var requestPortalOptionsIsNull = true;
            request.PortalOptions = new Amazon.SSOAdmin.Model.PortalOptions();
            Amazon.SSOAdmin.ApplicationVisibility requestPortalOptions_portalOptions_Visibility = null;
            if (cmdletContext.PortalOptions_Visibility != null)
            {
                requestPortalOptions_portalOptions_Visibility = cmdletContext.PortalOptions_Visibility;
            }
            if (requestPortalOptions_portalOptions_Visibility != null)
            {
                request.PortalOptions.Visibility = requestPortalOptions_portalOptions_Visibility;
                requestPortalOptionsIsNull = false;
            }
            Amazon.SSOAdmin.Model.SignInOptions requestPortalOptions_portalOptions_SignInOptions = null;
            
             // populate SignInOptions
            var requestPortalOptions_portalOptions_SignInOptionsIsNull = true;
            requestPortalOptions_portalOptions_SignInOptions = new Amazon.SSOAdmin.Model.SignInOptions();
            System.String requestPortalOptions_portalOptions_SignInOptions_signInOptions_ApplicationUrl = null;
            if (cmdletContext.SignInOptions_ApplicationUrl != null)
            {
                requestPortalOptions_portalOptions_SignInOptions_signInOptions_ApplicationUrl = cmdletContext.SignInOptions_ApplicationUrl;
            }
            if (requestPortalOptions_portalOptions_SignInOptions_signInOptions_ApplicationUrl != null)
            {
                requestPortalOptions_portalOptions_SignInOptions.ApplicationUrl = requestPortalOptions_portalOptions_SignInOptions_signInOptions_ApplicationUrl;
                requestPortalOptions_portalOptions_SignInOptionsIsNull = false;
            }
            Amazon.SSOAdmin.SignInOrigin requestPortalOptions_portalOptions_SignInOptions_signInOptions_Origin = null;
            if (cmdletContext.SignInOptions_Origin != null)
            {
                requestPortalOptions_portalOptions_SignInOptions_signInOptions_Origin = cmdletContext.SignInOptions_Origin;
            }
            if (requestPortalOptions_portalOptions_SignInOptions_signInOptions_Origin != null)
            {
                requestPortalOptions_portalOptions_SignInOptions.Origin = requestPortalOptions_portalOptions_SignInOptions_signInOptions_Origin;
                requestPortalOptions_portalOptions_SignInOptionsIsNull = false;
            }
             // determine if requestPortalOptions_portalOptions_SignInOptions should be set to null
            if (requestPortalOptions_portalOptions_SignInOptionsIsNull)
            {
                requestPortalOptions_portalOptions_SignInOptions = null;
            }
            if (requestPortalOptions_portalOptions_SignInOptions != null)
            {
                request.PortalOptions.SignInOptions = requestPortalOptions_portalOptions_SignInOptions;
                requestPortalOptionsIsNull = false;
            }
             // determine if request.PortalOptions should be set to null
            if (requestPortalOptionsIsNull)
            {
                request.PortalOptions = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SSOAdmin.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "CreateApplication");
            try
            {
                #if DESKTOP
                return client.CreateApplication(request);
                #elif CORECLR
                return client.CreateApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationProviderArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String InstanceArn { get; set; }
            public System.String Name { get; set; }
            public System.String SignInOptions_ApplicationUrl { get; set; }
            public Amazon.SSOAdmin.SignInOrigin SignInOptions_Origin { get; set; }
            public Amazon.SSOAdmin.ApplicationVisibility PortalOptions_Visibility { get; set; }
            public Amazon.SSOAdmin.ApplicationStatus Status { get; set; }
            public List<Amazon.SSOAdmin.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.CreateApplicationResponse, NewSSOADMNApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationArn;
        }
        
    }
}
