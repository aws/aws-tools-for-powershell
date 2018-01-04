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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Registers a CA certificate with AWS IoT. This CA certificate can then be used to sign
    /// device certificates, which can be then registered with AWS IoT. You can register up
    /// to 10 CA certificates per AWS account that have the same subject field. This enables
    /// you to have up to 10 certificate authorities sign your device certificates. If you
    /// have more than one CA certificate registered, make sure you pass the CA certificate
    /// when you register your device certificates with the RegisterCertificate API.
    /// </summary>
    [Cmdlet("Register", "IOTCACertificate")]
    [OutputType("Amazon.IoT.Model.RegisterCACertificateResponse")]
    [AWSCmdlet("Calls the AWS IoT RegisterCACertificate API operation.", Operation = new[] {"RegisterCACertificate"})]
    [AWSCmdletOutput("Amazon.IoT.Model.RegisterCACertificateResponse",
        "This cmdlet returns a Amazon.IoT.Model.RegisterCACertificateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterIOTCACertificateCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AllowAutoRegistration
        /// <summary>
        /// <para>
        /// <para>Allows this CA certificate to be used for auto registration of device certificates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AllowAutoRegistration { get; set; }
        #endregion
        
        #region Parameter CaCertificate
        /// <summary>
        /// <para>
        /// <para>The CA certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CaCertificate { get; set; }
        #endregion
        
        #region Parameter RegistrationConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrationConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter SetAsActive
        /// <summary>
        /// <para>
        /// <para>A boolean value that specifies if the CA certificate is set to active.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SetAsActive { get; set; }
        #endregion
        
        #region Parameter RegistrationConfig_TemplateBody
        /// <summary>
        /// <para>
        /// <para>The template body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegistrationConfig_TemplateBody { get; set; }
        #endregion
        
        #region Parameter VerificationCertificate
        /// <summary>
        /// <para>
        /// <para>The private key verification certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VerificationCertificate { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("AllowAutoRegistration"))
                context.AllowAutoRegistration = this.AllowAutoRegistration;
            context.CaCertificate = this.CaCertificate;
            context.RegistrationConfig_RoleArn = this.RegistrationConfig_RoleArn;
            context.RegistrationConfig_TemplateBody = this.RegistrationConfig_TemplateBody;
            if (ParameterWasBound("SetAsActive"))
                context.SetAsActive = this.SetAsActive;
            context.VerificationCertificate = this.VerificationCertificate;
            
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
            var request = new Amazon.IoT.Model.RegisterCACertificateRequest();
            
            if (cmdletContext.AllowAutoRegistration != null)
            {
                request.AllowAutoRegistration = cmdletContext.AllowAutoRegistration.Value;
            }
            if (cmdletContext.CaCertificate != null)
            {
                request.CaCertificate = cmdletContext.CaCertificate;
            }
            
             // populate RegistrationConfig
            bool requestRegistrationConfigIsNull = true;
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
             // determine if request.RegistrationConfig should be set to null
            if (requestRegistrationConfigIsNull)
            {
                request.RegistrationConfig = null;
            }
            if (cmdletContext.SetAsActive != null)
            {
                request.SetAsActive = cmdletContext.SetAsActive.Value;
            }
            if (cmdletContext.VerificationCertificate != null)
            {
                request.VerificationCertificate = cmdletContext.VerificationCertificate;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.IoT.Model.RegisterCACertificateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.RegisterCACertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "RegisterCACertificate");
            try
            {
                #if DESKTOP
                return client.RegisterCACertificate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RegisterCACertificateAsync(request);
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
            public System.Boolean? AllowAutoRegistration { get; set; }
            public System.String CaCertificate { get; set; }
            public System.String RegistrationConfig_RoleArn { get; set; }
            public System.String RegistrationConfig_TemplateBody { get; set; }
            public System.Boolean? SetAsActive { get; set; }
            public System.String VerificationCertificate { get; set; }
        }
        
    }
}
