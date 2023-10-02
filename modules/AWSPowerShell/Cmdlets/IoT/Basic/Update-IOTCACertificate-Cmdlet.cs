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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates a registered CA certificate.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateCACertificate</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTCACertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT UpdateCACertificate API operation.", Operation = new[] {"UpdateCACertificate"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateCACertificateResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.UpdateCACertificateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.UpdateCACertificateResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTCACertificateCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CertificateId
        /// <summary>
        /// <para>
        /// <para>The CA certificate identifier.</para>
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
        public System.String CertificateId { get; set; }
        #endregion
        
        #region Parameter NewAutoRegistrationStatus
        /// <summary>
        /// <para>
        /// <para>The new value for the auto registration status. Valid values are: "ENABLE" or "DISABLE".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.AutoRegistrationStatus")]
        public Amazon.IoT.AutoRegistrationStatus NewAutoRegistrationStatus { get; set; }
        #endregion
        
        #region Parameter NewStatus
        /// <summary>
        /// <para>
        /// <para>The updated status of the CA certificate.</para><para><b>Note:</b> The status value REGISTER_INACTIVE is deprecated and should not be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.CACertificateStatus")]
        public Amazon.IoT.CACertificateStatus NewStatus { get; set; }
        #endregion
        
        #region Parameter RemoveAutoRegistration
        /// <summary>
        /// <para>
        /// <para>If true, removes auto registration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveAutoRegistration { get; set; }
        #endregion
        
        #region Parameter RegistrationConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrationConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter RegistrationConfig_TemplateBody
        /// <summary>
        /// <para>
        /// <para>The template body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrationConfig_TemplateBody { get; set; }
        #endregion
        
        #region Parameter RegistrationConfig_TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the provisioning template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrationConfig_TemplateName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateCACertificateResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTCACertificate (UpdateCACertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateCACertificateResponse, UpdateIOTCACertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateId = this.CertificateId;
            #if MODULAR
            if (this.CertificateId == null && ParameterWasBound(nameof(this.CertificateId)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewAutoRegistrationStatus = this.NewAutoRegistrationStatus;
            context.NewStatus = this.NewStatus;
            context.RegistrationConfig_RoleArn = this.RegistrationConfig_RoleArn;
            context.RegistrationConfig_TemplateBody = this.RegistrationConfig_TemplateBody;
            context.RegistrationConfig_TemplateName = this.RegistrationConfig_TemplateName;
            context.RemoveAutoRegistration = this.RemoveAutoRegistration;
            
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
            var request = new Amazon.IoT.Model.UpdateCACertificateRequest();
            
            if (cmdletContext.CertificateId != null)
            {
                request.CertificateId = cmdletContext.CertificateId;
            }
            if (cmdletContext.NewAutoRegistrationStatus != null)
            {
                request.NewAutoRegistrationStatus = cmdletContext.NewAutoRegistrationStatus;
            }
            if (cmdletContext.NewStatus != null)
            {
                request.NewStatus = cmdletContext.NewStatus;
            }
            
             // populate RegistrationConfig
            var requestRegistrationConfigIsNull = true;
            request.RegistrationConfig = new Amazon.IoT.Model.RegistrationConfig();
            System.String requestRegistrationConfig_registrationConfig_RoleArn = null;
            if (cmdletContext.RegistrationConfig_RoleArn != null)
            {
                requestRegistrationConfig_registrationConfig_RoleArn = cmdletContext.RegistrationConfig_RoleArn;
            }
            if (requestRegistrationConfig_registrationConfig_RoleArn != null)
            {
                request.RegistrationConfig.RoleArn = requestRegistrationConfig_registrationConfig_RoleArn;
                requestRegistrationConfigIsNull = false;
            }
            System.String requestRegistrationConfig_registrationConfig_TemplateBody = null;
            if (cmdletContext.RegistrationConfig_TemplateBody != null)
            {
                requestRegistrationConfig_registrationConfig_TemplateBody = cmdletContext.RegistrationConfig_TemplateBody;
            }
            if (requestRegistrationConfig_registrationConfig_TemplateBody != null)
            {
                request.RegistrationConfig.TemplateBody = requestRegistrationConfig_registrationConfig_TemplateBody;
                requestRegistrationConfigIsNull = false;
            }
            System.String requestRegistrationConfig_registrationConfig_TemplateName = null;
            if (cmdletContext.RegistrationConfig_TemplateName != null)
            {
                requestRegistrationConfig_registrationConfig_TemplateName = cmdletContext.RegistrationConfig_TemplateName;
            }
            if (requestRegistrationConfig_registrationConfig_TemplateName != null)
            {
                request.RegistrationConfig.TemplateName = requestRegistrationConfig_registrationConfig_TemplateName;
                requestRegistrationConfigIsNull = false;
            }
             // determine if request.RegistrationConfig should be set to null
            if (requestRegistrationConfigIsNull)
            {
                request.RegistrationConfig = null;
            }
            if (cmdletContext.RemoveAutoRegistration != null)
            {
                request.RemoveAutoRegistration = cmdletContext.RemoveAutoRegistration.Value;
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
        
        private Amazon.IoT.Model.UpdateCACertificateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateCACertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateCACertificate");
            try
            {
                #if DESKTOP
                return client.UpdateCACertificate(request);
                #elif CORECLR
                return client.UpdateCACertificateAsync(request).GetAwaiter().GetResult();
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
            public System.String CertificateId { get; set; }
            public Amazon.IoT.AutoRegistrationStatus NewAutoRegistrationStatus { get; set; }
            public Amazon.IoT.CACertificateStatus NewStatus { get; set; }
            public System.String RegistrationConfig_RoleArn { get; set; }
            public System.String RegistrationConfig_TemplateBody { get; set; }
            public System.String RegistrationConfig_TemplateName { get; set; }
            public System.Boolean? RemoveAutoRegistration { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateCACertificateResponse, UpdateIOTCACertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
