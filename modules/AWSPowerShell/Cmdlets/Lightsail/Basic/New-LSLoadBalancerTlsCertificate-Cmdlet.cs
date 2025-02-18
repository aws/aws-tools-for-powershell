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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates an SSL/TLS certificate for an Amazon Lightsail load balancer.
    /// 
    ///  
    /// <para>
    /// TLS is just an updated, more secure version of Secure Socket Layer (SSL).
    /// </para><para>
    /// The <c>CreateLoadBalancerTlsCertificate</c> operation supports tag-based access control
    /// via resource tags applied to the resource identified by <c>load balancer name</c>.
    /// For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-controlling-access-using-tags">Amazon
    /// Lightsail Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSLoadBalancerTlsCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateLoadBalancerTlsCertificate API operation.", Operation = new[] {"CreateLoadBalancerTlsCertificate"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLSLoadBalancerTlsCertificateCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateAlternativeName
        /// <summary>
        /// <para>
        /// <para>An array of strings listing alternative domains and subdomains for your SSL/TLS certificate.
        /// Lightsail will de-dupe the names for you. You can have a maximum of 9 alternative
        /// names (in addition to the 1 primary domain). We do not support wildcards (<c>*.example.com</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CertificateAlternativeNames")]
        public System.String[] CertificateAlternativeName { get; set; }
        #endregion
        
        #region Parameter CertificateDomainName
        /// <summary>
        /// <para>
        /// <para>The domain name (<c>example.com</c>) for your SSL/TLS certificate.</para>
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
        public System.String CertificateDomainName { get; set; }
        #endregion
        
        #region Parameter CertificateName
        /// <summary>
        /// <para>
        /// <para>The SSL/TLS certificate name.</para><para>You can have up to 10 certificates in your account at one time. Each Lightsail load
        /// balancer can have up to 2 certificates associated with it at one time. There is also
        /// an overall limit to the number of certificates that can be issue in a 365-day period.
        /// For more information, see <a href="http://docs.aws.amazon.com/acm/latest/userguide/acm-limits.html">Limits</a>.</para>
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
        public System.String CertificateName { get; set; }
        #endregion
        
        #region Parameter LoadBalancerName
        /// <summary>
        /// <para>
        /// <para>The load balancer name where you want to create the SSL/TLS certificate.</para>
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
        public System.String LoadBalancerName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag keys and optional values to add to the resource during create.</para><para>Use the <c>TagResource</c> action to tag a resource after it's created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Lightsail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operations";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSLoadBalancerTlsCertificate (CreateLoadBalancerTlsCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateResponse, NewLSLoadBalancerTlsCertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CertificateAlternativeName != null)
            {
                context.CertificateAlternativeName = new List<System.String>(this.CertificateAlternativeName);
            }
            context.CertificateDomainName = this.CertificateDomainName;
            #if MODULAR
            if (this.CertificateDomainName == null && ParameterWasBound(nameof(this.CertificateDomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateDomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateName = this.CertificateName;
            #if MODULAR
            if (this.CertificateName == null && ParameterWasBound(nameof(this.CertificateName)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoadBalancerName = this.LoadBalancerName;
            #if MODULAR
            if (this.LoadBalancerName == null && ParameterWasBound(nameof(this.LoadBalancerName)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Lightsail.Model.Tag>(this.Tag);
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
            var request = new Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateRequest();
            
            if (cmdletContext.CertificateAlternativeName != null)
            {
                request.CertificateAlternativeNames = cmdletContext.CertificateAlternativeName;
            }
            if (cmdletContext.CertificateDomainName != null)
            {
                request.CertificateDomainName = cmdletContext.CertificateDomainName;
            }
            if (cmdletContext.CertificateName != null)
            {
                request.CertificateName = cmdletContext.CertificateName;
            }
            if (cmdletContext.LoadBalancerName != null)
            {
                request.LoadBalancerName = cmdletContext.LoadBalancerName;
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
        
        private Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateLoadBalancerTlsCertificate");
            try
            {
                return client.CreateLoadBalancerTlsCertificateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CertificateAlternativeName { get; set; }
            public System.String CertificateDomainName { get; set; }
            public System.String CertificateName { get; set; }
            public System.String LoadBalancerName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateResponse, NewLSLoadBalancerTlsCertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operations;
        }
        
    }
}
