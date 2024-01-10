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
    /// Creates an Amazon Web Services IoT Core certificate provider. You can use Amazon Web
    /// Services IoT Core certificate provider to customize how to sign a certificate signing
    /// request (CSR) in IoT fleet provisioning. For more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/provisioning-cert-provider.html">Customizing
    /// certificate signing using Amazon Web Services IoT Core certificate provider</a> from
    /// <i>Amazon Web Services IoT Core Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateCertificateProvider</a>
    /// action.
    /// </para><important><para>
    /// After you create a certificate provider, the behavior of <a href="https://docs.aws.amazon.com/iot/latest/developerguide/fleet-provision-api.html#create-cert-csr"><c>CreateCertificateFromCsr</c> API for fleet provisioning</a> will change and all
    /// API calls to <c>CreateCertificateFromCsr</c> will invoke the certificate provider
    /// to create the certificates. It can take up to a few minutes for this behavior to change
    /// after a certificate provider is created.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "IOTCertificateProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateCertificateProviderResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateCertificateProvider API operation.", Operation = new[] {"CreateCertificateProvider"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateCertificateProviderResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateCertificateProviderResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateCertificateProviderResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTCertificateProviderCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountDefaultForOperation
        /// <summary>
        /// <para>
        /// <para>A list of the operations that the certificate provider will use to generate certificates.
        /// Valid value: <c>CreateCertificateFromCsr</c>.</para>
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
        [Alias("AccountDefaultForOperations")]
        public System.String[] AccountDefaultForOperation { get; set; }
        #endregion
        
        #region Parameter CertificateProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the certificate provider.</para>
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
        public System.String CertificateProviderName { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Lambda function that defines the authentication logic.</para>
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
        public System.String LambdaFunctionArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata which can be used to manage the certificate provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A string that you can optionally pass in the <c>CreateCertificateProvider</c> request
        /// to make sure the request is idempotent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateCertificateProviderResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateCertificateProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CertificateProviderName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CertificateProviderName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CertificateProviderName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateProviderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTCertificateProvider (CreateCertificateProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateCertificateProviderResponse, NewIOTCertificateProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CertificateProviderName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccountDefaultForOperation != null)
            {
                context.AccountDefaultForOperation = new List<System.String>(this.AccountDefaultForOperation);
            }
            #if MODULAR
            if (this.AccountDefaultForOperation == null && ParameterWasBound(nameof(this.AccountDefaultForOperation)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountDefaultForOperation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateProviderName = this.CertificateProviderName;
            #if MODULAR
            if (this.CertificateProviderName == null && ParameterWasBound(nameof(this.CertificateProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.LambdaFunctionArn = this.LambdaFunctionArn;
            #if MODULAR
            if (this.LambdaFunctionArn == null && ParameterWasBound(nameof(this.LambdaFunctionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LambdaFunctionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoT.Model.Tag>(this.Tag);
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
            var request = new Amazon.IoT.Model.CreateCertificateProviderRequest();
            
            if (cmdletContext.AccountDefaultForOperation != null)
            {
                request.AccountDefaultForOperations = cmdletContext.AccountDefaultForOperation;
            }
            if (cmdletContext.CertificateProviderName != null)
            {
                request.CertificateProviderName = cmdletContext.CertificateProviderName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.LambdaFunctionArn != null)
            {
                request.LambdaFunctionArn = cmdletContext.LambdaFunctionArn;
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
        
        private Amazon.IoT.Model.CreateCertificateProviderResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateCertificateProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateCertificateProvider");
            try
            {
                #if DESKTOP
                return client.CreateCertificateProvider(request);
                #elif CORECLR
                return client.CreateCertificateProviderAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountDefaultForOperation { get; set; }
            public System.String CertificateProviderName { get; set; }
            public System.String ClientToken { get; set; }
            public System.String LambdaFunctionArn { get; set; }
            public List<Amazon.IoT.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoT.Model.CreateCertificateProviderResponse, NewIOTCertificateProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
