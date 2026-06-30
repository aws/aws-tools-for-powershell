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
    /// Creates an ACME endpoint, which is a managed ACME server with a unique endpoint URL.
    /// After creation, ACME clients can use the endpoint URL to automate certificate issuance
    /// using the ACME protocol.
    /// </summary>
    [Cmdlet("New", "ACMAcmeEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager CreateAcmeEndpoint API operation.", Operation = new[] {"CreateAcmeEndpoint"}, SelectReturnType = typeof(Amazon.CertificateManager.Model.CreateAcmeEndpointResponse))]
    [AWSCmdletOutput("System.String or Amazon.CertificateManager.Model.CreateAcmeEndpointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CertificateManager.Model.CreateAcmeEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewACMAcmeEndpointCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para>The authorization behavior for the ACME endpoint.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CertificateManager.AcmeAuthorizationBehavior")]
        public Amazon.CertificateManager.AcmeAuthorizationBehavior AuthorizationBehavior { get; set; }
        #endregion
        
        #region Parameter CertificateTag
        /// <summary>
        /// <para>
        /// <para>Tags to apply to certificates issued through this ACME endpoint.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CertificateTags")]
        public Amazon.CertificateManager.Model.Tag[] CertificateTag { get; set; }
        #endregion
        
        #region Parameter Contact
        /// <summary>
        /// <para>
        /// <para>Specifies whether ACME clients must provide contact information during account registration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CertificateManager.AcmeContact")]
        public Amazon.CertificateManager.AcmeContact Contact { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags to associate with the ACME endpoint.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CertificateManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AcmeEndpointArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CertificateManager.Model.CreateAcmeEndpointResponse).
        /// Specifying the name of a property of type Amazon.CertificateManager.Model.CreateAcmeEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AcmeEndpointArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AuthorizationBehavior), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ACMAcmeEndpoint (CreateAcmeEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CertificateManager.Model.CreateAcmeEndpointResponse, NewACMAcmeEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthorizationBehavior = this.AuthorizationBehavior;
            #if MODULAR
            if (this.AuthorizationBehavior == null && ParameterWasBound(nameof(this.AuthorizationBehavior)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizationBehavior which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm != null)
            {
                context.CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm = new List<System.String>(this.CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm);
            }
            if (this.CertificateTag != null)
            {
                context.CertificateTag = new List<Amazon.CertificateManager.Model.Tag>(this.CertificateTag);
            }
            context.Contact = this.Contact;
            context.IdempotencyToken = this.IdempotencyToken;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CertificateManager.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.CertificateManager.Model.CreateAcmeEndpointRequest();
            
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
            if (cmdletContext.CertificateTag != null)
            {
                request.CertificateTags = cmdletContext.CertificateTag;
            }
            if (cmdletContext.Contact != null)
            {
                request.Contact = cmdletContext.Contact;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CertificateManager.Model.CreateAcmeEndpointResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.CreateAcmeEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "CreateAcmeEndpoint");
            try
            {
                return client.CreateAcmeEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CertificateManager.AcmeAuthorizationBehavior AuthorizationBehavior { get; set; }
            public List<System.String> CertificateAuthority_PublicCertificateAuthority_AllowedKeyAlgorithm { get; set; }
            public List<Amazon.CertificateManager.Model.Tag> CertificateTag { get; set; }
            public Amazon.CertificateManager.AcmeContact Contact { get; set; }
            public System.String IdempotencyToken { get; set; }
            public List<Amazon.CertificateManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.CertificateManager.Model.CreateAcmeEndpointResponse, NewACMAcmeEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AcmeEndpointArn;
        }
        
    }
}
