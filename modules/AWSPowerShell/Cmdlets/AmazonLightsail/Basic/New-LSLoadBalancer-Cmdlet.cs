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
    /// Creates a Lightsail load balancer. To learn more about deciding whether to load balance
    /// your application, see <a href="https://lightsail.aws.amazon.com/ls/docs/how-to/article/configure-lightsail-instances-for-load-balancing">Configure
    /// your Lightsail instances for load balancing</a>. You can create up to 5 load balancers
    /// per AWS Region in your account.
    /// 
    ///  
    /// <para>
    /// When you create a load balancer, you can specify a unique name and port settings.
    /// To change additional load balancer settings, use the <code>UpdateLoadBalancerAttribute</code>
    /// operation.
    /// </para><para>
    /// The <code>create load balancer</code> operation supports tag-based access control
    /// via request tags. For more information, see the <a href="https://lightsail.aws.amazon.com/ls/docs/en/articles/amazon-lightsail-controlling-access-using-tags">Lightsail
    /// Dev Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSLoadBalancer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateLoadBalancer API operation.", Operation = new[] {"CreateLoadBalancer"})]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation",
        "This cmdlet returns a collection of Operation objects.",
        "The service call response (type Amazon.Lightsail.Model.CreateLoadBalancerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSLoadBalancerCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateAlternativeName
        /// <summary>
        /// <para>
        /// <para>The optional alternative domains and subdomains to use with your SSL/TLS certificate
        /// (e.g., <code>www.example.com</code>, <code>example.com</code>, <code>m.example.com</code>,
        /// <code>blog.example.com</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CertificateAlternativeNames")]
        public System.String[] CertificateAlternativeName { get; set; }
        #endregion
        
        #region Parameter CertificateDomainName
        /// <summary>
        /// <para>
        /// <para>The domain name with which your certificate is associated (e.g., <code>example.com</code>).</para><para>If you specify <code>certificateDomainName</code>, then <code>certificateName</code>
        /// is required (and vice-versa).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateDomainName { get; set; }
        #endregion
        
        #region Parameter CertificateName
        /// <summary>
        /// <para>
        /// <para>The name of the SSL/TLS certificate.</para><para>If you specify <code>certificateName</code>, then <code>certificateDomainName</code>
        /// is required (and vice-versa).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateName { get; set; }
        #endregion
        
        #region Parameter HealthCheckPath
        /// <summary>
        /// <para>
        /// <para>The path you provided to perform the load balancer health check. If you didn't specify
        /// a health check path, Lightsail uses the root path of your website (e.g., <code>"/"</code>).</para><para>You may want to specify a custom health check path other than the root of your application
        /// if your home page loads slowly or has a lot of media or scripting on it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckPath { get; set; }
        #endregion
        
        #region Parameter InstancePort
        /// <summary>
        /// <para>
        /// <para>The instance port where you're creating your load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 InstancePort { get; set; }
        #endregion
        
        #region Parameter LoadBalancerName
        /// <summary>
        /// <para>
        /// <para>The name of your load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LoadBalancerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSLoadBalancer (CreateLoadBalancer)"))
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
            context.HealthCheckPath = this.HealthCheckPath;
            if (ParameterWasBound("InstancePort"))
                context.InstancePort = this.InstancePort;
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
            var request = new Amazon.Lightsail.Model.CreateLoadBalancerRequest();
            
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
            if (cmdletContext.HealthCheckPath != null)
            {
                request.HealthCheckPath = cmdletContext.HealthCheckPath;
            }
            if (cmdletContext.InstancePort != null)
            {
                request.InstancePort = cmdletContext.InstancePort.Value;
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
        
        private Amazon.Lightsail.Model.CreateLoadBalancerResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateLoadBalancerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateLoadBalancer");
            try
            {
                #if DESKTOP
                return client.CreateLoadBalancer(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateLoadBalancerAsync(request);
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
            public List<System.String> CertificateAlternativeNames { get; set; }
            public System.String CertificateDomainName { get; set; }
            public System.String CertificateName { get; set; }
            public System.String HealthCheckPath { get; set; }
            public System.Int32? InstancePort { get; set; }
            public System.String LoadBalancerName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tags { get; set; }
        }
        
    }
}
