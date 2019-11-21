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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Creates a new domain name.
    /// </summary>
    [Cmdlet("New", "AGDomainName", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateDomainNameResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateDomainName API operation.", Operation = new[] {"CreateDomainName"}, SelectReturnType = typeof(Amazon.APIGateway.Model.CreateDomainNameResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateDomainNameResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.CreateDomainNameResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter CertificateBody
        /// <summary>
        /// <para>
        /// <para>[Deprecated] The body of the server certificate that will be used by edge-optimized
        /// endpoint for this domain name provided by your certificate authority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateChain { get; set; }
        #endregion
        
        #region Parameter CertificateName
        /// <summary>
        /// <para>
        /// <para>The user-friendly name of the certificate that will be used by edge-optimized endpoint
        /// for this domain name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateName { get; set; }
        #endregion
        
        #region Parameter CertificatePrivateKey
        /// <summary>
        /// <para>
        /// <para>[Deprecated] Your edge-optimized endpoint's domain name certificate's private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificatePrivateKey { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>[Required] The name of the <a>DomainName</a> resource.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter RegionalCertificateArn
        /// <summary>
        /// <para>
        /// <para>The reference to an AWS-managed certificate that will be used by regional endpoint
        /// for this domain name. AWS Certificate Manager is the only supported source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegionalCertificateArn { get; set; }
        #endregion
        
        #region Parameter RegionalCertificateName
        /// <summary>
        /// <para>
        /// <para>The user-friendly name of the certificate that will be used by regional endpoint for
        /// this domain name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegionalCertificateName { get; set; }
        #endregion
        
        #region Parameter SecurityPolicy
        /// <summary>
        /// <para>
        /// <para>The Transport Layer Security (TLS) version + cipher suite for this <a>DomainName</a>.
        /// The valid values are <code>TLS_1_0</code> and <code>TLS_1_2</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.APIGateway.SecurityPolicy")]
        public Amazon.APIGateway.SecurityPolicy SecurityPolicy { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value map of strings. The valid character set is [a-zA-Z+-=._:/]. The tag
        /// key can be up to 128 characters and must not start with <code>aws:</code>. The tag
        /// value can be up to 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>A list of endpoint types of an API (<a>RestApi</a>) or its custom domain name (<a>DomainName</a>).
        /// For an edge-optimized API and its custom domain name, the endpoint type is <code>"EDGE"</code>.
        /// For a regional API and its custom domain name, the endpoint type is <code>REGIONAL</code>.
        /// For a private API, the endpoint type is <code>PRIVATE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfiguration_Types")]
        public System.String[] EndpointConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>A list of VpcEndpointIds of an API (<a>RestApi</a>) against which to create Route53
        /// ALIASes. It is only supported for <code>PRIVATE</code> endpoint type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfiguration_VpcEndpointIds")]
        public System.String[] EndpointConfiguration_VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.CreateDomainNameResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.CreateDomainNameResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGDomainName (CreateDomainName)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.CreateDomainNameResponse, NewAGDomainNameCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateArn = this.CertificateArn;
            context.CertificateBody = this.CertificateBody;
            context.CertificateChain = this.CertificateChain;
            context.CertificateName = this.CertificateName;
            context.CertificatePrivateKey = this.CertificatePrivateKey;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EndpointConfiguration_Type != null)
            {
                context.EndpointConfiguration_Type = new List<System.String>(this.EndpointConfiguration_Type);
            }
            if (this.EndpointConfiguration_VpcEndpointId != null)
            {
                context.EndpointConfiguration_VpcEndpointId = new List<System.String>(this.EndpointConfiguration_VpcEndpointId);
            }
            context.RegionalCertificateArn = this.RegionalCertificateArn;
            context.RegionalCertificateName = this.RegionalCertificateName;
            context.SecurityPolicy = this.SecurityPolicy;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var requestEndpointConfigurationIsNull = true;
            request.EndpointConfiguration = new Amazon.APIGateway.Model.EndpointConfiguration();
            List<System.String> requestEndpointConfiguration_endpointConfiguration_Type = null;
            if (cmdletContext.EndpointConfiguration_Type != null)
            {
                requestEndpointConfiguration_endpointConfiguration_Type = cmdletContext.EndpointConfiguration_Type;
            }
            if (requestEndpointConfiguration_endpointConfiguration_Type != null)
            {
                request.EndpointConfiguration.Types = requestEndpointConfiguration_endpointConfiguration_Type;
                requestEndpointConfigurationIsNull = false;
            }
            List<System.String> requestEndpointConfiguration_endpointConfiguration_VpcEndpointId = null;
            if (cmdletContext.EndpointConfiguration_VpcEndpointId != null)
            {
                requestEndpointConfiguration_endpointConfiguration_VpcEndpointId = cmdletContext.EndpointConfiguration_VpcEndpointId;
            }
            if (requestEndpointConfiguration_endpointConfiguration_VpcEndpointId != null)
            {
                request.EndpointConfiguration.VpcEndpointIds = requestEndpointConfiguration_endpointConfiguration_VpcEndpointId;
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
            if (cmdletContext.SecurityPolicy != null)
            {
                request.SecurityPolicy = cmdletContext.SecurityPolicy;
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
        
        private Amazon.APIGateway.Model.CreateDomainNameResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateDomainNameRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateDomainName");
            try
            {
                #if DESKTOP
                return client.CreateDomainName(request);
                #elif CORECLR
                return client.CreateDomainNameAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> EndpointConfiguration_Type { get; set; }
            public List<System.String> EndpointConfiguration_VpcEndpointId { get; set; }
            public System.String RegionalCertificateArn { get; set; }
            public System.String RegionalCertificateName { get; set; }
            public Amazon.APIGateway.SecurityPolicy SecurityPolicy { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.APIGateway.Model.CreateDomainNameResponse, NewAGDomainNameCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
