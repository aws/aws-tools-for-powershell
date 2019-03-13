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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates a Lightsail load balancer TLS certificate.
    /// 
    ///  
    /// <para>
    /// TLS is just an updated, more secure version of Secure Socket Layer (SSL).
    /// </para><para>
    /// The <code>create load balancer tls certificate</code> operation supports tag-based
    /// access control via resource tags applied to the resource identified by loadBalancerName.
    /// For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en/articles/amazon-lightsail-controlling-access-using-tags">Lightsail
    /// Dev Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSLoadBalancerTlsCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateLoadBalancerTlsCertificate API operation.", Operation = new[] {"CreateLoadBalancerTlsCertificate"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a collection of Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSLoadBalancerTlsCertificateCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateAlternativeName
        /// <summary>
        /// <para>
        /// <para>An array of strings listing alternative domains and subdomains for your SSL/TLS certificate.
        /// Lightsail will de-dupe the names for you. You can have a maximum of 9 alternative
        /// names (in addition to the 1 primary domain). We do not support wildcards (e.g., <code>*.example.com</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CertificateAlternativeNames")]
        public System.String[] CertificateAlternativeName { get; set; }
        #endregion
        
        #region Parameter CertificateDomainName
        /// <summary>
        /// <para>
        /// <para>The domain name (e.g., <code>example.com</code>) for your SSL/TLS certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CertificateName { get; set; }
        #endregion
        
        #region Parameter LoadBalancerName
        /// <summary>
        /// <para>
        /// <para>The load balancer name where you want to create the SSL/TLS certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LoadBalancerName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag keys and optional values to add to the resource during create.</para><para>To tag a resource after it has been created, see the <code>tag resource</code> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Lightsail.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CertificateName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSLoadBalancerTlsCertificate (CreateLoadBalancerTlsCertificate)"))
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
            
            if (this.CertificateAlternativeName != null)
            {
                context.CertificateAlternativeNames = new List<System.String>(this.CertificateAlternativeName);
            }
            context.CertificateDomainName = this.CertificateDomainName;
            context.CertificateName = this.CertificateName;
            context.LoadBalancerName = this.LoadBalancerName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Lightsail.Model.Tag>(this.Tag);
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
            
            if (cmdletContext.CertificateAlternativeNames != null)
            {
                request.CertificateAlternativeNames = cmdletContext.CertificateAlternativeNames;
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
                object pipelineOutput = response.Operations;
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
        
        private Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateLoadBalancerTlsCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateLoadBalancerTlsCertificate");
            try
            {
                #if DESKTOP
                return client.CreateLoadBalancerTlsCertificate(request);
                #elif CORECLR
                return client.CreateLoadBalancerTlsCertificateAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CertificateAlternativeNames { get; set; }
            public System.String CertificateDomainName { get; set; }
            public System.String CertificateName { get; set; }
            public System.String LoadBalancerName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tags { get; set; }
        }
        
    }
}
