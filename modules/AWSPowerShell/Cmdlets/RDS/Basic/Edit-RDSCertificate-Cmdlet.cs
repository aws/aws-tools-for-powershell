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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Override the system-default Secure Sockets Layer/Transport Layer Security (SSL/TLS)
    /// certificate for Amazon RDS for new DB instances, or remove the override.
    /// 
    ///  
    /// <para>
    /// By using this operation, you can specify an RDS-approved SSL/TLS certificate for new
    /// DB instances that is different from the default certificate provided by RDS. You can
    /// also use this operation to remove the override, so that new DB instances use the default
    /// certificate provided by RDS.
    /// </para><para>
    /// You might need to override the default certificate in the following situations:
    /// </para><ul><li><para>
    /// You already migrated your applications to support the latest certificate authority
    /// (CA) certificate, but the new CA certificate is not yet the RDS default CA certificate
    /// for the specified Amazon Web Services Region.
    /// </para></li><li><para>
    /// RDS has already moved to a new default CA certificate for the specified Amazon Web
    /// Services Region, but you are still in the process of supporting the new CA certificate.
    /// In this case, you temporarily need additional time to finish your application changes.
    /// </para></li></ul><para>
    /// For more information about rotating your SSL/TLS certificate for RDS DB engines, see
    /// <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/UsingWithRDS.SSL-certificate-rotation.html">
    /// Rotating Your SSL/TLS Certificate</a> in the <i>Amazon RDS User Guide</i>.
    /// </para><para>
    /// For more information about rotating your SSL/TLS certificate for Aurora DB engines,
    /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/UsingWithRDS.SSL-certificate-rotation.html">
    /// Rotating Your SSL/TLS Certificate</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RDSCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.Certificate")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyCertificates API operation.", Operation = new[] {"ModifyCertificates"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyCertificatesResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.Certificate or Amazon.RDS.Model.ModifyCertificatesResponse",
        "This cmdlet returns an Amazon.RDS.Model.Certificate object.",
        "The service call response (type Amazon.RDS.Model.ModifyCertificatesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRDSCertificateCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateIdentifier
        /// <summary>
        /// <para>
        /// <para>The new default certificate identifier to override the current one with.</para><para>To determine the valid values, use the <code>describe-certificates</code> CLI command
        /// or the <code>DescribeCertificates</code> API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CertificateIdentifier { get; set; }
        #endregion
        
        #region Parameter RemoveCustomerOverride
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to remove the override for the default certificate.
        /// If the override is removed, the default certificate is the system default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveCustomerOverride { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Certificate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyCertificatesResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyCertificatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Certificate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CertificateIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CertificateIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CertificateIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSCertificate (ModifyCertificates)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyCertificatesResponse, EditRDSCertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CertificateIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateIdentifier = this.CertificateIdentifier;
            context.RemoveCustomerOverride = this.RemoveCustomerOverride;
            
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
            var request = new Amazon.RDS.Model.ModifyCertificatesRequest();
            
            if (cmdletContext.CertificateIdentifier != null)
            {
                request.CertificateIdentifier = cmdletContext.CertificateIdentifier;
            }
            if (cmdletContext.RemoveCustomerOverride != null)
            {
                request.RemoveCustomerOverride = cmdletContext.RemoveCustomerOverride.Value;
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
        
        private Amazon.RDS.Model.ModifyCertificatesResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyCertificatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyCertificates");
            try
            {
                #if DESKTOP
                return client.ModifyCertificates(request);
                #elif CORECLR
                return client.ModifyCertificatesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? RemoveCustomerOverride { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyCertificatesResponse, EditRDSCertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Certificate;
        }
        
    }
}
