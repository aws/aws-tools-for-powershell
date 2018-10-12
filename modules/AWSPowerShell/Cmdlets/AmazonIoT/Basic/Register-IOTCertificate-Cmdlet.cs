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
    /// Registers a device certificate with AWS IoT. If you have more than one CA certificate
    /// that has the same subject field, you must specify the CA certificate that was used
    /// to sign the device certificate being registered.
    /// </summary>
    [Cmdlet("Register", "IOTCertificate")]
    [OutputType("Amazon.IoT.Model.RegisterCertificateResponse")]
    [AWSCmdlet("Calls the AWS IoT RegisterCertificate API operation.", Operation = new[] {"RegisterCertificate"})]
    [AWSCmdletOutput("Amazon.IoT.Model.RegisterCertificateResponse",
        "This cmdlet returns a Amazon.IoT.Model.RegisterCertificateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterIOTCertificateCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter CaCertificatePem
        /// <summary>
        /// <para>
        /// <para>The CA certificate used to sign the device certificate being registered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CaCertificatePem { get; set; }
        #endregion
        
        #region Parameter CertificatePem
        /// <summary>
        /// <para>
        /// <para>The certificate data, in PEM format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificatePem { get; set; }
        #endregion
        
        #region Parameter SetAsActive
        /// <summary>
        /// <para>
        /// <para>A boolean value that specifies if the CA certificate is set to active.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This property is deprecated")]
        public System.Boolean SetAsActive { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the register certificate request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.CertificateStatus")]
        public Amazon.IoT.CertificateStatus Status { get; set; }
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
            
            context.CaCertificatePem = this.CaCertificatePem;
            context.CertificatePem = this.CertificatePem;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("SetAsActive"))
                context.SetAsActive = this.SetAsActive;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.IoT.Model.RegisterCertificateRequest();
            
            if (cmdletContext.CaCertificatePem != null)
            {
                request.CaCertificatePem = cmdletContext.CaCertificatePem;
            }
            if (cmdletContext.CertificatePem != null)
            {
                request.CertificatePem = cmdletContext.CertificatePem;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.SetAsActive != null)
            {
                request.SetAsActive = cmdletContext.SetAsActive.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.IoT.Model.RegisterCertificateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.RegisterCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "RegisterCertificate");
            try
            {
                #if DESKTOP
                return client.RegisterCertificate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RegisterCertificateAsync(request);
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
            public System.String CaCertificatePem { get; set; }
            public System.String CertificatePem { get; set; }
            [System.ObsoleteAttribute]
            public System.Boolean? SetAsActive { get; set; }
            public Amazon.IoT.CertificateStatus Status { get; set; }
        }
        
    }
}
