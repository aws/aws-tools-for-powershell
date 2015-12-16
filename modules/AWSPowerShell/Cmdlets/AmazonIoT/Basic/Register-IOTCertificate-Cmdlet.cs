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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// RegisterCertificate lets callers provision their own certificate with AWS IoT. This
    /// is useful in case you do not want AWS IoT to generate certificate for you but you
    /// want to bring your own pre-generated certificate and provision it with AWSIoT.
    /// </summary>
    [Cmdlet("Register", "IOTCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.RegisterCertificateResponse")]
    [AWSCmdlet("Invokes the RegisterCertificate operation against AWS IoT.", Operation = new[] {"RegisterCertificate"})]
    [AWSCmdletOutput("Amazon.IoT.Model.RegisterCertificateResponse",
        "This cmdlet returns a Amazon.IoT.Model.RegisterCertificateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RegisterIOTCertificateCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The PEM format string representation of X509 certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificatePem { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Sets the certificate to active (ready to be used) if true is passed</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SetAsActive { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Base64 encoded signature (SHA256withRSA) where the signed string is the X509 certificate's
        /// string representation. The corresponding private key for the X509 certificate is used
        /// to sign. This is a optional argument. If this value it is not specified, the X509
        /// certificate will still be provisioned but since you have not proved that you have
        /// the corresponding private key (by providing a signature), this certificate can be
        /// claimed by another AWS account holder, in the future, by providing signature value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Signature { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CertificatePem", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-IOTCertificate (RegisterCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CertificatePem = this.CertificatePem;
            if (ParameterWasBound("SetAsActive"))
                context.SetAsActive = this.SetAsActive;
            context.Signature = this.Signature;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IoT.Model.RegisterCertificateRequest();
            
            if (cmdletContext.CertificatePem != null)
            {
                request.CertificatePem = cmdletContext.CertificatePem;
            }
            if (cmdletContext.SetAsActive != null)
            {
                request.SetAsActive = cmdletContext.SetAsActive.Value;
            }
            if (cmdletContext.Signature != null)
            {
                request.Signature = cmdletContext.Signature;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RegisterCertificate(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String CertificatePem { get; set; }
            public System.Boolean? SetAsActive { get; set; }
            public System.String Signature { get; set; }
        }
        
    }
}
