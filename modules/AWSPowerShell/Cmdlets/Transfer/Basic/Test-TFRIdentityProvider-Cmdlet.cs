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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// If the <c>IdentityProviderType</c> of a file transfer protocol-enabled server is <c>AWS_DIRECTORY_SERVICE</c>
    /// or <c>API_Gateway</c>, tests whether your identity provider is set up successfully.
    /// We highly recommend that you call this operation to test your authentication method
    /// as soon as you create your server. By doing so, you can troubleshoot issues with the
    /// identity provider integration to ensure that your users can successfully use the service.
    /// 
    ///  
    /// <para>
    ///  The <c>ServerId</c> and <c>UserName</c> parameters are required. The <c>ServerProtocol</c>,
    /// <c>SourceIp</c>, and <c>UserPassword</c> are all optional. 
    /// </para><para>
    /// Note the following:
    /// </para><ul><li><para>
    ///  You cannot use <c>TestIdentityProvider</c> if the <c>IdentityProviderType</c> of
    /// your server is <c>SERVICE_MANAGED</c>.
    /// </para></li><li><para><c>TestIdentityProvider</c> does not work with keys: it only accepts passwords.
    /// </para></li><li><para><c>TestIdentityProvider</c> can test the password operation for a custom Identity
    /// Provider that handles keys and passwords.
    /// </para></li><li><para>
    ///  If you provide any incorrect values for any parameters, the <c>Response</c> field
    /// is empty. 
    /// </para></li><li><para>
    ///  If you provide a server ID for a server that uses service-managed users, you get
    /// an error: 
    /// </para><para><c> An error occurred (InvalidRequestException) when calling the TestIdentityProvider
    /// operation: s-<i>server-ID</i> not configured for external auth </c></para></li><li><para>
    ///  If you enter a Server ID for the <c>--server-id</c> parameter that does not identify
    /// an actual Transfer server, you receive the following error: 
    /// </para><para><c>An error occurred (ResourceNotFoundException) when calling the TestIdentityProvider
    /// operation: Unknown server</c>. 
    /// </para><para>
    /// It is possible your sever is in a different region. You can specify a region by adding
    /// the following: <c>--region region-code</c>, such as <c>--region us-east-2</c> to specify
    /// a server in <b>US East (Ohio)</b>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Test", "TFRIdentityProvider")]
    [OutputType("Amazon.Transfer.Model.TestIdentityProviderResponse")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP TestIdentityProvider API operation.", Operation = new[] {"TestIdentityProvider"}, SelectReturnType = typeof(Amazon.Transfer.Model.TestIdentityProviderResponse))]
    [AWSCmdletOutput("Amazon.Transfer.Model.TestIdentityProviderResponse",
        "This cmdlet returns an Amazon.Transfer.Model.TestIdentityProviderResponse object containing multiple properties."
    )]
    public partial class TestTFRIdentityProviderCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ServerId
        /// <summary>
        /// <para>
        /// <para>A system-assigned identifier for a specific server. That server's user authentication
        /// method is tested with a user name and password.</para>
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
        public System.String ServerId { get; set; }
        #endregion
        
        #region Parameter ServerProtocol
        /// <summary>
        /// <para>
        /// <para>The type of file transfer protocol to be tested.</para><para>The available protocols are:</para><ul><li><para>Secure Shell (SSH) File Transfer Protocol (SFTP)</para></li><li><para>File Transfer Protocol Secure (FTPS)</para></li><li><para>File Transfer Protocol (FTP)</para></li><li><para>Applicability Statement 2 (AS2)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.Protocol")]
        public Amazon.Transfer.Protocol ServerProtocol { get; set; }
        #endregion
        
        #region Parameter SourceIp
        /// <summary>
        /// <para>
        /// <para>The source IP address of the account to be tested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceIp { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The name of the account to be tested.</para>
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
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter UserPassword
        /// <summary>
        /// <para>
        /// <para>The password of the account to be tested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserPassword { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.TestIdentityProviderResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.TestIdentityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServerId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServerId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServerId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.TestIdentityProviderResponse, TestTFRIdentityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServerId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ServerId = this.ServerId;
            #if MODULAR
            if (this.ServerId == null && ParameterWasBound(nameof(this.ServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerProtocol = this.ServerProtocol;
            context.SourceIp = this.SourceIp;
            context.UserName = this.UserName;
            #if MODULAR
            if (this.UserName == null && ParameterWasBound(nameof(this.UserName)))
            {
                WriteWarning("You are passing $null as a value for parameter UserName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserPassword = this.UserPassword;
            
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
            var request = new Amazon.Transfer.Model.TestIdentityProviderRequest();
            
            if (cmdletContext.ServerId != null)
            {
                request.ServerId = cmdletContext.ServerId;
            }
            if (cmdletContext.ServerProtocol != null)
            {
                request.ServerProtocol = cmdletContext.ServerProtocol;
            }
            if (cmdletContext.SourceIp != null)
            {
                request.SourceIp = cmdletContext.SourceIp;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            if (cmdletContext.UserPassword != null)
            {
                request.UserPassword = cmdletContext.UserPassword;
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
        
        private Amazon.Transfer.Model.TestIdentityProviderResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.TestIdentityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "TestIdentityProvider");
            try
            {
                #if DESKTOP
                return client.TestIdentityProvider(request);
                #elif CORECLR
                return client.TestIdentityProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String ServerId { get; set; }
            public Amazon.Transfer.Protocol ServerProtocol { get; set; }
            public System.String SourceIp { get; set; }
            public System.String UserName { get; set; }
            public System.String UserPassword { get; set; }
            public System.Func<Amazon.Transfer.Model.TestIdentityProviderResponse, TestTFRIdentityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
