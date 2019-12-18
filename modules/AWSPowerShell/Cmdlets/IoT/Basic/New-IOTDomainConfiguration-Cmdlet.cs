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
    /// Creates a domain configuration.
    /// 
    ///  <note><para>
    /// The domain configuration feature is in public preview and is subject to change.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "IOTDomainConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateDomainConfigurationResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateDomainConfiguration API operation.", Operation = new[] {"CreateDomainConfiguration"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateDomainConfigurationResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateDomainConfigurationResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateDomainConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTDomainConfigurationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AuthorizerConfig_AllowAuthorizerOverride
        /// <summary>
        /// <para>
        /// <para>A Boolean that specifies whether the domain configuration's authorization service
        /// can be overridden.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AuthorizerConfig_AllowAuthorizerOverride { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfig_DefaultAuthorizerName
        /// <summary>
        /// <para>
        /// <para>The name of the authorization service for a domain configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerConfig_DefaultAuthorizerName { get; set; }
        #endregion
        
        #region Parameter DomainConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the domain configuration. This value must be unique to a region.</para>
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
        public System.String DomainConfigurationName { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter ServerCertificateArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the certificates that AWS IoT passes to the device during the TLS handshake.
        /// Currently you can specify only one certificate ARN. This value is not required for
        /// AWS-managed domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServerCertificateArns")]
        public System.String[] ServerCertificateArn { get; set; }
        #endregion
        
        #region Parameter ServiceType
        /// <summary>
        /// <para>
        /// <para>The type of service delivered by the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.ServiceType")]
        public Amazon.IoT.ServiceType ServiceType { get; set; }
        #endregion
        
        #region Parameter ValidationCertificateArn
        /// <summary>
        /// <para>
        /// <para>The certificate used to validate the server certificate and prove domain name ownership.
        /// This certificate must be signed by a public certificate authority. This value is not
        /// required for AWS-managed domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValidationCertificateArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateDomainConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateDomainConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainConfigurationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainConfigurationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainConfigurationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTDomainConfiguration (CreateDomainConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateDomainConfigurationResponse, NewIOTDomainConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainConfigurationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuthorizerConfig_AllowAuthorizerOverride = this.AuthorizerConfig_AllowAuthorizerOverride;
            context.AuthorizerConfig_DefaultAuthorizerName = this.AuthorizerConfig_DefaultAuthorizerName;
            context.DomainConfigurationName = this.DomainConfigurationName;
            #if MODULAR
            if (this.DomainConfigurationName == null && ParameterWasBound(nameof(this.DomainConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainName = this.DomainName;
            if (this.ServerCertificateArn != null)
            {
                context.ServerCertificateArn = new List<System.String>(this.ServerCertificateArn);
            }
            context.ServiceType = this.ServiceType;
            context.ValidationCertificateArn = this.ValidationCertificateArn;
            
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
            var request = new Amazon.IoT.Model.CreateDomainConfigurationRequest();
            
            
             // populate AuthorizerConfig
            var requestAuthorizerConfigIsNull = true;
            request.AuthorizerConfig = new Amazon.IoT.Model.AuthorizerConfig();
            System.Boolean? requestAuthorizerConfig_authorizerConfig_AllowAuthorizerOverride = null;
            if (cmdletContext.AuthorizerConfig_AllowAuthorizerOverride != null)
            {
                requestAuthorizerConfig_authorizerConfig_AllowAuthorizerOverride = cmdletContext.AuthorizerConfig_AllowAuthorizerOverride.Value;
            }
            if (requestAuthorizerConfig_authorizerConfig_AllowAuthorizerOverride != null)
            {
                request.AuthorizerConfig.AllowAuthorizerOverride = requestAuthorizerConfig_authorizerConfig_AllowAuthorizerOverride.Value;
                requestAuthorizerConfigIsNull = false;
            }
            System.String requestAuthorizerConfig_authorizerConfig_DefaultAuthorizerName = null;
            if (cmdletContext.AuthorizerConfig_DefaultAuthorizerName != null)
            {
                requestAuthorizerConfig_authorizerConfig_DefaultAuthorizerName = cmdletContext.AuthorizerConfig_DefaultAuthorizerName;
            }
            if (requestAuthorizerConfig_authorizerConfig_DefaultAuthorizerName != null)
            {
                request.AuthorizerConfig.DefaultAuthorizerName = requestAuthorizerConfig_authorizerConfig_DefaultAuthorizerName;
                requestAuthorizerConfigIsNull = false;
            }
             // determine if request.AuthorizerConfig should be set to null
            if (requestAuthorizerConfigIsNull)
            {
                request.AuthorizerConfig = null;
            }
            if (cmdletContext.DomainConfigurationName != null)
            {
                request.DomainConfigurationName = cmdletContext.DomainConfigurationName;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.ServerCertificateArn != null)
            {
                request.ServerCertificateArns = cmdletContext.ServerCertificateArn;
            }
            if (cmdletContext.ServiceType != null)
            {
                request.ServiceType = cmdletContext.ServiceType;
            }
            if (cmdletContext.ValidationCertificateArn != null)
            {
                request.ValidationCertificateArn = cmdletContext.ValidationCertificateArn;
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
        
        private Amazon.IoT.Model.CreateDomainConfigurationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateDomainConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateDomainConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateDomainConfiguration(request);
                #elif CORECLR
                return client.CreateDomainConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AuthorizerConfig_AllowAuthorizerOverride { get; set; }
            public System.String AuthorizerConfig_DefaultAuthorizerName { get; set; }
            public System.String DomainConfigurationName { get; set; }
            public System.String DomainName { get; set; }
            public List<System.String> ServerCertificateArn { get; set; }
            public Amazon.IoT.ServiceType ServiceType { get; set; }
            public System.String ValidationCertificateArn { get; set; }
            public System.Func<Amazon.IoT.Model.CreateDomainConfigurationResponse, NewIOTDomainConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
