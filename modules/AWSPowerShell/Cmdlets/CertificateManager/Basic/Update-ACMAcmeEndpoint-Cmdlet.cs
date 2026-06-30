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
using System.Threading;
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Updates the configuration of an existing ACME endpoint. You can change the authorization
    /// behavior, contact requirement, or certificate authority settings.
    /// </summary>
    [Cmdlet("Update", "ACMAcmeEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Certificate Manager UpdateAcmeEndpoint API operation.", Operation = new[] {"UpdateAcmeEndpoint"}, SelectReturnType = typeof(Amazon.CertificateManager.Model.UpdateAcmeEndpointResponse))]
    [AWSCmdletOutput("None or Amazon.CertificateManager.Model.UpdateAcmeEndpointResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CertificateManager.Model.UpdateAcmeEndpointResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateACMAcmeEndpointCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AcmeEndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the ACME endpoint to update.</para>
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
        public System.String AcmeEndpointArn { get; set; }
        #endregion
        
        #region Parameter CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm
        /// <summary>
        /// <para>
        /// <para>The key algorithms allowed for certificates issued by this certificate authority.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithms")]
        public System.String[] CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm { get; set; }
        #endregion
        
        #region Parameter AuthorizationBehavior
        /// <summary>
        /// <para>
        /// <para>The updated authorization behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CertificateManager.AcmeAuthorizationBehavior")]
        public Amazon.CertificateManager.AcmeAuthorizationBehavior AuthorizationBehavior { get; set; }
        #endregion
        
        #region Parameter Contact
        /// <summary>
        /// <para>
        /// <para>The updated contact requirement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CertificateManager.AcmeContact")]
        public Amazon.CertificateManager.AcmeContact Contact { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CertificateManager.Model.UpdateAcmeEndpointResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AcmeEndpointArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ACMAcmeEndpoint (UpdateAcmeEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CertificateManager.Model.UpdateAcmeEndpointResponse, UpdateACMAcmeEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcmeEndpointArn = this.AcmeEndpointArn;
            #if MODULAR
            if (this.AcmeEndpointArn == null && ParameterWasBound(nameof(this.AcmeEndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AcmeEndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthorizationBehavior = this.AuthorizationBehavior;
            if (this.CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm != null)
            {
                context.CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm = new List<System.String>(this.CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm);
            }
            context.Contact = this.Contact;
            
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
            var request = new Amazon.CertificateManager.Model.UpdateAcmeEndpointRequest();
            
            if (cmdletContext.AcmeEndpointArn != null)
            {
                request.AcmeEndpointArn = cmdletContext.AcmeEndpointArn;
            }
            if (cmdletContext.AuthorizationBehavior != null)
            {
                request.AuthorizationBehavior = cmdletContext.AuthorizationBehavior;
            }
            
             // populate CertificateAuthority
            var requestCertificateAuthorityIsNull = true;
            request.CertificateAuthority = new Amazon.CertificateManager.Model.CertificateAuthority();
            Amazon.CertificateManager.Model.PublicCertificateAuthority requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority = null;
            
             // populate PublicCertificateAuthority
            var requestCertificateAuthority_certificateAuthority_PublicCertificateAuthorityIsNull = true;
            requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority = new Amazon.CertificateManager.Model.PublicCertificateAuthority();
            List<System.String> requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority_certificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm = null;
            if (cmdletContext.CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm != null)
            {
                requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority_certificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm = cmdletContext.CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm;
            }
            if (requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority_certificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm != null)
            {
                requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority.AllowedKeyAlgorithms = requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority_certificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm;
                requestCertificateAuthority_certificateAuthority_PublicCertificateAuthorityIsNull = false;
            }
             // determine if requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority should be set to null
            if (requestCertificateAuthority_certificateAuthority_PublicCertificateAuthorityIsNull)
            {
                requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority = null;
            }
            if (requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority != null)
            {
                request.CertificateAuthority.PublicCertificateAuthority = requestCertificateAuthority_certificateAuthority_PublicCertificateAuthority;
                requestCertificateAuthorityIsNull = false;
            }
             // determine if request.CertificateAuthority should be set to null
            if (requestCertificateAuthorityIsNull)
            {
                request.CertificateAuthority = null;
            }
            if (cmdletContext.Contact != null)
            {
                request.Contact = cmdletContext.Contact;
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
        
        private Amazon.CertificateManager.Model.UpdateAcmeEndpointResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.UpdateAcmeEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "UpdateAcmeEndpoint");
            try
            {
                return client.UpdateAcmeEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AcmeEndpointArn { get; set; }
            public Amazon.CertificateManager.AcmeAuthorizationBehavior AuthorizationBehavior { get; set; }
            public List<System.String> CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm { get; set; }
            public Amazon.CertificateManager.AcmeContact Contact { get; set; }
            public System.Func<Amazon.CertificateManager.Model.UpdateAcmeEndpointResponse, UpdateACMAcmeEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
