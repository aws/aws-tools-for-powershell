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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates an SSL/TLS certificate that secures traffic for your website. After the certificate
    /// is created, it is installed on the specified Lightsail instance.
    /// 
    ///  
    /// <para>
    /// If you provide more than one domain name in the request, at least one name must be
    /// less than or equal to 63 characters in length.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "LSInstanceHttp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail SetupInstanceHttps API operation.", Operation = new[] {"SetupInstanceHttps"}, SelectReturnType = typeof(Amazon.Lightsail.Model.SetupInstanceHttpsResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.SetupInstanceHttpsResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.SetupInstanceHttpsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetLSInstanceHttpCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CertificateProvider
        /// <summary>
        /// <para>
        /// <para>The certificate authority that issues the SSL/TLS certificate.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.CertificateProvider")]
        public Amazon.Lightsail.CertificateProvider CertificateProvider { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain and subdomains that were specified for the SSL/TLS certificate.</para>
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
        [Alias("DomainNames")]
        public System.String[] DomainName { get; set; }
        #endregion
        
        #region Parameter EmailAddress
        /// <summary>
        /// <para>
        /// <para>The contact method for SSL/TLS certificate renewal alerts. You can enter one email
        /// address. </para>
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
        public System.String EmailAddress { get; set; }
        #endregion
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the Lightsail instance.</para>
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
        public System.String InstanceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.SetupInstanceHttpsResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.SetupInstanceHttpsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-LSInstanceHttp (SetupInstanceHttps)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.SetupInstanceHttpsResponse, SetLSInstanceHttpCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateProvider = this.CertificateProvider;
            #if MODULAR
            if (this.CertificateProvider == null && ParameterWasBound(nameof(this.CertificateProvider)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateProvider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DomainName != null)
            {
                context.DomainName = new List<System.String>(this.DomainName);
            }
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailAddress = this.EmailAddress;
            #if MODULAR
            if (this.EmailAddress == null && ParameterWasBound(nameof(this.EmailAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceName = this.InstanceName;
            #if MODULAR
            if (this.InstanceName == null && ParameterWasBound(nameof(this.InstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Lightsail.Model.SetupInstanceHttpsRequest();
            
            if (cmdletContext.CertificateProvider != null)
            {
                request.CertificateProvider = cmdletContext.CertificateProvider;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainNames = cmdletContext.DomainName;
            }
            if (cmdletContext.EmailAddress != null)
            {
                request.EmailAddress = cmdletContext.EmailAddress;
            }
            if (cmdletContext.InstanceName != null)
            {
                request.InstanceName = cmdletContext.InstanceName;
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
        
        private Amazon.Lightsail.Model.SetupInstanceHttpsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.SetupInstanceHttpsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "SetupInstanceHttps");
            try
            {
                #if DESKTOP
                return client.SetupInstanceHttps(request);
                #elif CORECLR
                return client.SetupInstanceHttpsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Lightsail.CertificateProvider CertificateProvider { get; set; }
            public List<System.String> DomainName { get; set; }
            public System.String EmailAddress { get; set; }
            public System.String InstanceName { get; set; }
            public System.Func<Amazon.Lightsail.Model.SetupInstanceHttpsResponse, SetLSInstanceHttpCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
