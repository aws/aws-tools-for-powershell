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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Modifies multiple properties related to SAML 2.0 authentication, including the enablement
    /// status, user access URL, and relay state parameter name that are used for configuring
    /// federation with an SAML 2.0 identity provider.
    /// </summary>
    [Cmdlet("Edit", "WKSSamlProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ModifySamlProperties API operation.", Operation = new[] {"ModifySamlProperties"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ModifySamlPropertiesResponse))]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.Model.ModifySamlPropertiesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkSpaces.Model.ModifySamlPropertiesResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditWKSSamlPropertyCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PropertiesToDelete
        /// <summary>
        /// <para>
        /// <para>The SAML properties to delete as part of your request.</para><para>Specify one of the following options:</para><ul><li><para><c>SAML_PROPERTIES_USER_ACCESS_URL</c> to delete the user access URL.</para></li><li><para><c>SAML_PROPERTIES_RELAY_STATE_PARAMETER_NAME</c> to delete the relay state parameter
        /// name.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PropertiesToDelete { get; set; }
        #endregion
        
        #region Parameter SamlProperties_RelayStateParameterName
        /// <summary>
        /// <para>
        /// <para>The relay state parameter name supported by the SAML 2.0 identity provider (IdP).
        /// When the end user is redirected to the user access URL from the WorkSpaces client
        /// application, this relay state parameter name is appended as a query parameter to the
        /// URL along with the relay state endpoint to return the user to the client application
        /// session.</para><para>To use SAML 2.0 authentication with WorkSpaces, the IdP must support IdP-initiated
        /// deep linking for the relay state URL. Consult your IdP documentation for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamlProperties_RelayStateParameterName { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The directory identifier for which you want to configure SAML properties.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter SamlProperties_Status
        /// <summary>
        /// <para>
        /// <para>Indicates the status of SAML 2.0 authentication. These statuses include the following.</para><ul><li><para>If the setting is <c>DISABLED</c>, end users will be directed to login with their
        /// directory credentials.</para></li><li><para>If the setting is <c>ENABLED</c>, end users will be directed to login via the user
        /// access URL. Users attempting to connect to WorkSpaces from a client application that
        /// does not support SAML 2.0 authentication will not be able to connect.</para></li><li><para>If the setting is <c>ENABLED_WITH_DIRECTORY_LOGIN_FALLBACK</c>, end users will be
        /// directed to login via the user access URL on supported client applications, but will
        /// not prevent clients that do not support SAML 2.0 authentication from connecting as
        /// if SAML 2.0 authentication was disabled.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.SamlStatusEnum")]
        public Amazon.WorkSpaces.SamlStatusEnum SamlProperties_Status { get; set; }
        #endregion
        
        #region Parameter SamlProperties_UserAccessUrl
        /// <summary>
        /// <para>
        /// <para>The SAML 2.0 identity provider (IdP) user access URL is the URL a user would navigate
        /// to in their web browser in order to federate from the IdP and directly access the
        /// application, without any SAML 2.0 service provider (SP) bindings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamlProperties_UserAccessUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ModifySamlPropertiesResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSSamlProperty (ModifySamlProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ModifySamlPropertiesResponse, EditWKSSamlPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.PropertiesToDelete != null)
            {
                context.PropertiesToDelete = new List<System.String>(this.PropertiesToDelete);
            }
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamlProperties_RelayStateParameterName = this.SamlProperties_RelayStateParameterName;
            context.SamlProperties_Status = this.SamlProperties_Status;
            context.SamlProperties_UserAccessUrl = this.SamlProperties_UserAccessUrl;
            
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
            var request = new Amazon.WorkSpaces.Model.ModifySamlPropertiesRequest();
            
            if (cmdletContext.PropertiesToDelete != null)
            {
                request.PropertiesToDelete = cmdletContext.PropertiesToDelete;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            
             // populate SamlProperties
            var requestSamlPropertiesIsNull = true;
            request.SamlProperties = new Amazon.WorkSpaces.Model.SamlProperties();
            System.String requestSamlProperties_samlProperties_RelayStateParameterName = null;
            if (cmdletContext.SamlProperties_RelayStateParameterName != null)
            {
                requestSamlProperties_samlProperties_RelayStateParameterName = cmdletContext.SamlProperties_RelayStateParameterName;
            }
            if (requestSamlProperties_samlProperties_RelayStateParameterName != null)
            {
                request.SamlProperties.RelayStateParameterName = requestSamlProperties_samlProperties_RelayStateParameterName;
                requestSamlPropertiesIsNull = false;
            }
            Amazon.WorkSpaces.SamlStatusEnum requestSamlProperties_samlProperties_Status = null;
            if (cmdletContext.SamlProperties_Status != null)
            {
                requestSamlProperties_samlProperties_Status = cmdletContext.SamlProperties_Status;
            }
            if (requestSamlProperties_samlProperties_Status != null)
            {
                request.SamlProperties.Status = requestSamlProperties_samlProperties_Status;
                requestSamlPropertiesIsNull = false;
            }
            System.String requestSamlProperties_samlProperties_UserAccessUrl = null;
            if (cmdletContext.SamlProperties_UserAccessUrl != null)
            {
                requestSamlProperties_samlProperties_UserAccessUrl = cmdletContext.SamlProperties_UserAccessUrl;
            }
            if (requestSamlProperties_samlProperties_UserAccessUrl != null)
            {
                request.SamlProperties.UserAccessUrl = requestSamlProperties_samlProperties_UserAccessUrl;
                requestSamlPropertiesIsNull = false;
            }
             // determine if request.SamlProperties should be set to null
            if (requestSamlPropertiesIsNull)
            {
                request.SamlProperties = null;
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
        
        private Amazon.WorkSpaces.Model.ModifySamlPropertiesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ModifySamlPropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ModifySamlProperties");
            try
            {
                #if DESKTOP
                return client.ModifySamlProperties(request);
                #elif CORECLR
                return client.ModifySamlPropertiesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> PropertiesToDelete { get; set; }
            public System.String ResourceId { get; set; }
            public System.String SamlProperties_RelayStateParameterName { get; set; }
            public Amazon.WorkSpaces.SamlStatusEnum SamlProperties_Status { get; set; }
            public System.String SamlProperties_UserAccessUrl { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ModifySamlPropertiesResponse, EditWKSSamlPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
