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
    /// Updates application properties.
    /// </summary>
    [Cmdlet("Update", "SSOADMNApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin UpdateApplication API operation.", Operation = new[] {"UpdateApplication"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.UpdateApplicationResponse))]
    [AWSCmdletOutput("None or Amazon.SSOAdmin.Model.UpdateApplicationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSOAdmin.Model.UpdateApplicationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSSOADMNApplicationCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the application. For more information about ARNs, see <a href="/general/latest/gr/aws-arns-and-namespaces.html">Amazon
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
        public System.String ApplicationArn { get; set; }
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the updated name for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.UpdateApplicationResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSOADMNApplication (UpdateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.UpdateApplicationResponse, UpdateSSOADMNApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationArn = this.ApplicationArn;
            #if MODULAR
            if (this.ApplicationArn == null && ParameterWasBound(nameof(this.ApplicationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            context.SignInOptions_ApplicationUrl = this.SignInOptions_ApplicationUrl;
            context.SignInOptions_Origin = this.SignInOptions_Origin;
            context.Status = this.Status;
            
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
            var request = new Amazon.SSOAdmin.Model.UpdateApplicationRequest();
            
            if (cmdletContext.ApplicationArn != null)
            {
                request.ApplicationArn = cmdletContext.ApplicationArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PortalOptions
            var requestPortalOptionsIsNull = true;
            request.PortalOptions = new Amazon.SSOAdmin.Model.UpdateApplicationPortalOptions();
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
        
        private Amazon.SSOAdmin.Model.UpdateApplicationResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.UpdateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "UpdateApplication");
            try
            {
                #if DESKTOP
                return client.UpdateApplication(request);
                #elif CORECLR
                return client.UpdateApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationArn { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String SignInOptions_ApplicationUrl { get; set; }
            public Amazon.SSOAdmin.SignInOrigin SignInOptions_Origin { get; set; }
            public Amazon.SSOAdmin.ApplicationStatus Status { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.UpdateApplicationResponse, UpdateSSOADMNApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
