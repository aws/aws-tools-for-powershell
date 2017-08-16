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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Uploads the specified certificate.
    /// </summary>
    [Cmdlet("Import", "DMSCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.Certificate")]
    [AWSCmdlet("Invokes the ImportCertificate operation against AWS Database Migration Service.", Operation = new[] {"ImportCertificate"})]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.Certificate",
        "This cmdlet returns a Certificate object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.ImportCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportDMSCertificateCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateIdentifier
        /// <summary>
        /// <para>
        /// <para>The customer-assigned name of the certificate. Valid characters are A-z and 0-9.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateIdentifier { get; set; }
        #endregion
        
        #region Parameter CertificatePem
        /// <summary>
        /// <para>
        /// <para>The contents of the .pem X.509 certificate file for the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CertificatePem { get; set; }
        #endregion
        
        #region Parameter CertificateWallet
        /// <summary>
        /// <para>
        /// <para>The location of the imported Oracle Wallet certificate for use with SSL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] CertificateWallet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CertificatePem", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-DMSCertificate (ImportCertificate)"))
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
            
            context.CertificateIdentifier = this.CertificateIdentifier;
            context.CertificatePem = this.CertificatePem;
            context.CertificateWallet = this.CertificateWallet;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _CertificateWalletStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.DatabaseMigrationService.Model.ImportCertificateRequest();
                
                if (cmdletContext.CertificateIdentifier != null)
                {
                    request.CertificateIdentifier = cmdletContext.CertificateIdentifier;
                }
                if (cmdletContext.CertificatePem != null)
                {
                    request.CertificatePem = cmdletContext.CertificatePem;
                }
                if (cmdletContext.CertificateWallet != null)
                {
                    _CertificateWalletStream = new System.IO.MemoryStream(cmdletContext.CertificateWallet);
                    request.CertificateWallet = _CertificateWalletStream;
                }
                if (cmdletContext.Tags != null)
                {
                    request.Tags = cmdletContext.Tags;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response.Certificate;
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
            finally
            {
                if( _CertificateWalletStream != null)
                {
                    _CertificateWalletStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DatabaseMigrationService.Model.ImportCertificateResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.ImportCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "ImportCertificate");
            try
            {
                #if DESKTOP
                return client.ImportCertificate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ImportCertificateAsync(request);
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
            public System.String CertificateIdentifier { get; set; }
            public System.String CertificatePem { get; set; }
            public byte[] CertificateWallet { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tags { get; set; }
        }
        
    }
}
