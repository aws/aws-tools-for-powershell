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
    /// Updates a registered CA certificate.
    /// </summary>
    [Cmdlet("Update", "IOTCACertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT UpdateCACertificate API operation.", Operation = new[] {"UpdateCACertificate"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.IoT.Model.UpdateCACertificateResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTCACertificateCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateId
        /// <summary>
        /// <para>
        /// <para>The CA certificate identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateId { get; set; }
        #endregion
        
        #region Parameter NewAutoRegistrationStatus
        /// <summary>
        /// <para>
        /// <para>The new value for the auto registration status. Valid values are: "ENABLE" or "DISABLE".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.AutoRegistrationStatus")]
        public Amazon.IoT.AutoRegistrationStatus NewAutoRegistrationStatus { get; set; }
        #endregion
        
        #region Parameter NewStatus
        /// <summary>
        /// <para>
        /// <para>The updated status of the CA certificate.</para><para><b>Note:</b> The status value REGISTER_INACTIVE is deprecated and should not be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.CACertificateStatus")]
        public Amazon.IoT.CACertificateStatus NewStatus { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CertificateId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTCACertificate (UpdateCACertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CertificateId = this.CertificateId;
            context.NewAutoRegistrationStatus = this.NewAutoRegistrationStatus;
            context.NewStatus = this.NewStatus;
            
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.IoT.Model.UpdateCACertificateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateCACertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateCACertificate");
            try
            {
                #if DESKTOP
                return client.UpdateCACertificate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateCACertificateAsync(request);
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
            public System.String CertificateId { get; set; }
            public Amazon.IoT.AutoRegistrationStatus NewAutoRegistrationStatus { get; set; }
            public Amazon.IoT.CACertificateStatus NewStatus { get; set; }
        }
        
    }
}
