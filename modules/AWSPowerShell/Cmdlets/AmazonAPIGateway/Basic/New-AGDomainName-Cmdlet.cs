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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Creates a new domain name.
    /// </summary>
    [Cmdlet("New", "AGDomainName", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateDomainNameResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateDomainName API operation.", Operation = new[] {"CreateDomainName"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateDomainNameResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.CreateDomainNameResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAGDomainNameCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>The reference to an AWS-managed certificate that will be used by edge-optimized endpoint
        /// for this domain name. AWS Certificate Manager is the only supported source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter CertificateBody
        /// <summary>
        /// <para>
        /// <para>[Deprecated] The body of the server certificate that will be used by edge-optimized
        /// endpoint for this domain name provided by your certificate authority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateBody { get; set; }
        #endregion
        
        #region Parameter CertificateChain
        /// <summary>
        /// <para>
        /// <para>[Deprecated] The intermediate certificates and optionally the root certificate, one
        /// after the other without any blank lines, used by an edge-optimized endpoint for this
        /// domain name. If you include the root certificate, your certificate chain must start
        /// with intermediate certificates and end with the root certificate. Use the intermediate
        /// certificates that were provided by your certificate authority. Do not include any
        /// intermediaries that are not in the chain of trust path.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateChain { get; set; }
        #endregion
        
        #region Parameter CertificateName
        /// <summary>
        /// <para>
        /// <para>The user-friendly name of the certificate that will be used by edge-optimized endpoint
        /// for this domain name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateName { get; set; }
        #endregion
        
        #region Parameter CertificatePrivateKey
        /// <summary>
        /// <para>
        /// <para>[Deprecated] Your edge-optimized endpoint's domain name certificate's private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificatePrivateKey { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>(Required) The name of the <a>DomainName</a> resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter RegionalCertificateArn
        /// <summary>
        /// <para>
        /// <para>The reference to an AWS-managed certificate that will be used by regional endpoint
        /// for this domain name. AWS Certificate Manager is the only supported source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegionalCertificateArn { get; set; }
        #endregion
        
        #region Parameter RegionalCertificateName
        /// <summary>
        /// <para>
        /// <para>The user-friendly name of the certificate that will be used by regional endpoint for
        /// this domain name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RegionalCertificateName { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>A list of endpoint types of an API (<a>RestApi</a>) or its custom domain name (<a>DomainName</a>).
        /// For an edge-optimized API and its custom domain name, the endpoint type is <code>"EDGE"</code>.
        /// For a regional API and its custom domain name, the endpoint type is <code>REGIONAL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointConfiguration_Types")]
        public System.String[] EndpointConfiguration_Type { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGDomainName (CreateDomainName)"))
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
            
            context.CertificateArn = this.CertificateArn;
            context.CertificateBody = this.CertificateBody;
            context.CertificateChain = this.CertificateChain;
            context.CertificateName = this.CertificateName;
            context.CertificatePrivateKey = this.CertificatePrivateKey;
            context.DomainName = this.DomainName;
            if (this.EndpointConfiguration_Type != null)
            {
                context.EndpointConfiguration_Types = new List<System.String>(this.EndpointConfiguration_Type);
            }
            context.RegionalCertificateArn = this.RegionalCertificateArn;
            context.RegionalCertificateName = this.RegionalCertificateName;
            
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
            var request = new Amazon.APIGateway.Model.CreateDomainNameRequest();
            
            if (cmdletContext.CertificateArn != null)
            {
                request.CertificateArn = cmdletContext.CertificateArn;
            }
            if (cmdletContext.CertificateBody != null)
            {
                request.CertificateBody = cmdletContext.CertificateBody;
            }
            if (cmdletContext.CertificateChain != null)
            {
                request.CertificateChain = cmdletContext.CertificateChain;
            }
            if (cmdletContext.CertificateName != null)
            {
                request.CertificateName = cmdletContext.CertificateName;
            }
            if (cmdletContext.CertificatePrivateKey != null)
            {
                request.CertificatePrivateKey = cmdletContext.CertificatePrivateKey;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate EndpointConfiguration
            bool requestEndpointConfigurationIsNull = true;
            request.EndpointConfiguration = new Amazon.APIGateway.Model.EndpointConfiguration();
            List<System.String> requestEndpointConfiguration_endpointConfiguration_Type = null;
            if (cmdletContext.EndpointConfiguration_Types != null)
            {
                requestEndpointConfiguration_endpointConfiguration_Type = cmdletContext.EndpointConfiguration_Types;
            }
            if (requestEndpointConfiguration_endpointConfiguration_Type != null)
            {
                request.EndpointConfiguration.Types = requestEndpointConfiguration_endpointConfiguration_Type;
                requestEndpointConfigurationIsNull = false;
            }
             // determine if request.EndpointConfiguration should be set to null
            if (requestEndpointConfigurationIsNull)
            {
                request.EndpointConfiguration = null;
            }
            if (cmdletContext.RegionalCertificateArn != null)
            {
                request.RegionalCertificateArn = cmdletContext.RegionalCertificateArn;
            }
            if (cmdletContext.RegionalCertificateName != null)
            {
                request.RegionalCertificateName = cmdletContext.RegionalCertificateName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.APIGateway.Model.CreateDomainNameResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateDomainNameRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateDomainName");
            try
            {
                #if DESKTOP
                return client.CreateDomainName(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDomainNameAsync(request);
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
            public System.String CertificateArn { get; set; }
            public System.String CertificateBody { get; set; }
            public System.String CertificateChain { get; set; }
            public System.String CertificateName { get; set; }
            public System.String CertificatePrivateKey { get; set; }
            public System.String DomainName { get; set; }
            public List<System.String> EndpointConfiguration_Types { get; set; }
            public System.String RegionalCertificateArn { get; set; }
            public System.String RegionalCertificateName { get; set; }
        }
        
    }
}
