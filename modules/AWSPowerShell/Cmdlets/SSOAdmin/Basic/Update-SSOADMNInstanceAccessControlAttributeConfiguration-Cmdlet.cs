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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Updates the Amazon Web Services SSO identity store attributes that you can use with
    /// the Amazon Web Services SSO instance for attributes-based access control (ABAC). When
    /// using an external identity provider as an identity source, you can pass attributes
    /// through the SAML assertion as an alternative to configuring attributes from the Amazon
    /// Web Services SSO identity store. If a SAML assertion passes any of these attributes,
    /// Amazon Web Services SSO replaces the attribute value with the value from the Amazon
    /// Web Services SSO identity store. For more information about ABAC, see <a href="/singlesignon/latest/userguide/abac.html">Attribute-Based
    /// Access Control</a> in the <i>Amazon Web Services SSO User Guide</i>.
    /// </summary>
    [Cmdlet("Update", "SSOADMNInstanceAccessControlAttributeConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin UpdateInstanceAccessControlAttributeConfiguration API operation.", Operation = new[] {"UpdateInstanceAccessControlAttributeConfiguration"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.UpdateInstanceAccessControlAttributeConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.SSOAdmin.Model.UpdateInstanceAccessControlAttributeConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSOAdmin.Model.UpdateInstanceAccessControlAttributeConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSSOADMNInstanceAccessControlAttributeConfigurationCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        #region Parameter InstanceAccessControlAttributeConfiguration_AccessControlAttribute
        /// <summary>
        /// <para>
        /// <para>Lists the attributes that are configured for ABAC in the specified Amazon Web Services
        /// SSO instance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InstanceAccessControlAttributeConfiguration_AccessControlAttributes")]
        public Amazon.SSOAdmin.Model.AccessControlAttribute[] InstanceAccessControlAttributeConfiguration_AccessControlAttribute { get; set; }
        #endregion
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services SSO instance under which the operation will be
        /// executed.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.UpdateInstanceAccessControlAttributeConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSOADMNInstanceAccessControlAttributeConfiguration (UpdateInstanceAccessControlAttributeConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.UpdateInstanceAccessControlAttributeConfigurationResponse, UpdateSSOADMNInstanceAccessControlAttributeConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.InstanceAccessControlAttributeConfiguration_AccessControlAttribute != null)
            {
                context.InstanceAccessControlAttributeConfiguration_AccessControlAttribute = new List<Amazon.SSOAdmin.Model.AccessControlAttribute>(this.InstanceAccessControlAttributeConfiguration_AccessControlAttribute);
            }
            #if MODULAR
            if (this.InstanceAccessControlAttributeConfiguration_AccessControlAttribute == null && ParameterWasBound(nameof(this.InstanceAccessControlAttributeConfiguration_AccessControlAttribute)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceAccessControlAttributeConfiguration_AccessControlAttribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSOAdmin.Model.UpdateInstanceAccessControlAttributeConfigurationRequest();
            
            
             // populate InstanceAccessControlAttributeConfiguration
            var requestInstanceAccessControlAttributeConfigurationIsNull = true;
            request.InstanceAccessControlAttributeConfiguration = new Amazon.SSOAdmin.Model.InstanceAccessControlAttributeConfiguration();
            List<Amazon.SSOAdmin.Model.AccessControlAttribute> requestInstanceAccessControlAttributeConfiguration_instanceAccessControlAttributeConfiguration_AccessControlAttribute = null;
            if (cmdletContext.InstanceAccessControlAttributeConfiguration_AccessControlAttribute != null)
            {
                requestInstanceAccessControlAttributeConfiguration_instanceAccessControlAttributeConfiguration_AccessControlAttribute = cmdletContext.InstanceAccessControlAttributeConfiguration_AccessControlAttribute;
            }
            if (requestInstanceAccessControlAttributeConfiguration_instanceAccessControlAttributeConfiguration_AccessControlAttribute != null)
            {
                request.InstanceAccessControlAttributeConfiguration.AccessControlAttributes = requestInstanceAccessControlAttributeConfiguration_instanceAccessControlAttributeConfiguration_AccessControlAttribute;
                requestInstanceAccessControlAttributeConfigurationIsNull = false;
            }
             // determine if request.InstanceAccessControlAttributeConfiguration should be set to null
            if (requestInstanceAccessControlAttributeConfigurationIsNull)
            {
                request.InstanceAccessControlAttributeConfiguration = null;
            }
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
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
        
        private Amazon.SSOAdmin.Model.UpdateInstanceAccessControlAttributeConfigurationResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.UpdateInstanceAccessControlAttributeConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "UpdateInstanceAccessControlAttributeConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateInstanceAccessControlAttributeConfiguration(request);
                #elif CORECLR
                return client.UpdateInstanceAccessControlAttributeConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SSOAdmin.Model.AccessControlAttribute> InstanceAccessControlAttributeConfiguration_AccessControlAttribute { get; set; }
            public System.String InstanceArn { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.UpdateInstanceAccessControlAttributeConfigurationResponse, UpdateSSOADMNInstanceAccessControlAttributeConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
