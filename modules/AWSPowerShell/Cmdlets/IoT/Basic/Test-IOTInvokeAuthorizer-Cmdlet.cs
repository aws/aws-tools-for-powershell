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
    /// Tests a custom authorization behavior by invoking a specified custom authorizer. Use
    /// this to test and debug the custom authorization behavior of devices that connect to
    /// the IoT device gateway.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">TestInvokeAuthorizer</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "IOTInvokeAuthorizer")]
    [OutputType("Amazon.IoT.Model.TestInvokeAuthorizerResponse")]
    [AWSCmdlet("Calls the AWS IoT TestInvokeAuthorizer API operation.", Operation = new[] {"TestInvokeAuthorizer"}, SelectReturnType = typeof(Amazon.IoT.Model.TestInvokeAuthorizerResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.TestInvokeAuthorizerResponse",
        "This cmdlet returns an Amazon.IoT.Model.TestInvokeAuthorizerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestIOTInvokeAuthorizerCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AuthorizerName
        /// <summary>
        /// <para>
        /// <para>The custom authorizer name.</para>
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
        public System.String AuthorizerName { get; set; }
        #endregion
        
        #region Parameter MqttContext_ClientId
        /// <summary>
        /// <para>
        /// <para>The value of the <code>clientId</code> key in an MQTT authorization request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MqttContext_ClientId { get; set; }
        #endregion
        
        #region Parameter HttpContext_Header
        /// <summary>
        /// <para>
        /// <para>The header keys and values in an HTTP authorization request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HttpContext_Headers")]
        public System.Collections.Hashtable HttpContext_Header { get; set; }
        #endregion
        
        #region Parameter MqttContext_Password
        /// <summary>
        /// <para>
        /// <para>The value of the <code>password</code> key in an MQTT authorization request.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] MqttContext_Password { get; set; }
        #endregion
        
        #region Parameter HttpContext_QueryString
        /// <summary>
        /// <para>
        /// <para>The query string keys and values in an HTTP authorization request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpContext_QueryString { get; set; }
        #endregion
        
        #region Parameter TlsContext_ServerName
        /// <summary>
        /// <para>
        /// <para>The value of the <code>serverName</code> key in a TLS authorization request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TlsContext_ServerName { get; set; }
        #endregion
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para>The token returned by your custom authentication service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Token { get; set; }
        #endregion
        
        #region Parameter TokenSignature
        /// <summary>
        /// <para>
        /// <para>The signature made with the token and your custom authentication service's private
        /// key. This value must be Base-64-encoded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TokenSignature { get; set; }
        #endregion
        
        #region Parameter MqttContext_Username
        /// <summary>
        /// <para>
        /// <para>The value of the <code>username</code> key in an MQTT authorization request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MqttContext_Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.TestInvokeAuthorizerResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.TestInvokeAuthorizerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TokenSignature parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TokenSignature' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TokenSignature' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.TestInvokeAuthorizerResponse, TestIOTInvokeAuthorizerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TokenSignature;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuthorizerName = this.AuthorizerName;
            #if MODULAR
            if (this.AuthorizerName == null && ParameterWasBound(nameof(this.AuthorizerName)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.HttpContext_Header != null)
            {
                context.HttpContext_Header = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.HttpContext_Header.Keys)
                {
                    context.HttpContext_Header.Add((String)hashKey, (String)(this.HttpContext_Header[hashKey]));
                }
            }
            context.HttpContext_QueryString = this.HttpContext_QueryString;
            context.MqttContext_ClientId = this.MqttContext_ClientId;
            context.MqttContext_Password = this.MqttContext_Password;
            context.MqttContext_Username = this.MqttContext_Username;
            context.TlsContext_ServerName = this.TlsContext_ServerName;
            context.Token = this.Token;
            context.TokenSignature = this.TokenSignature;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _MqttContext_PasswordStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.IoT.Model.TestInvokeAuthorizerRequest();
                
                if (cmdletContext.AuthorizerName != null)
                {
                    request.AuthorizerName = cmdletContext.AuthorizerName;
                }
                
                 // populate HttpContext
                var requestHttpContextIsNull = true;
                request.HttpContext = new Amazon.IoT.Model.HttpContext();
                Dictionary<System.String, System.String> requestHttpContext_httpContext_Header = null;
                if (cmdletContext.HttpContext_Header != null)
                {
                    requestHttpContext_httpContext_Header = cmdletContext.HttpContext_Header;
                }
                if (requestHttpContext_httpContext_Header != null)
                {
                    request.HttpContext.Headers = requestHttpContext_httpContext_Header;
                    requestHttpContextIsNull = false;
                }
                System.String requestHttpContext_httpContext_QueryString = null;
                if (cmdletContext.HttpContext_QueryString != null)
                {
                    requestHttpContext_httpContext_QueryString = cmdletContext.HttpContext_QueryString;
                }
                if (requestHttpContext_httpContext_QueryString != null)
                {
                    request.HttpContext.QueryString = requestHttpContext_httpContext_QueryString;
                    requestHttpContextIsNull = false;
                }
                 // determine if request.HttpContext should be set to null
                if (requestHttpContextIsNull)
                {
                    request.HttpContext = null;
                }
                
                 // populate MqttContext
                var requestMqttContextIsNull = true;
                request.MqttContext = new Amazon.IoT.Model.MqttContext();
                System.String requestMqttContext_mqttContext_ClientId = null;
                if (cmdletContext.MqttContext_ClientId != null)
                {
                    requestMqttContext_mqttContext_ClientId = cmdletContext.MqttContext_ClientId;
                }
                if (requestMqttContext_mqttContext_ClientId != null)
                {
                    request.MqttContext.ClientId = requestMqttContext_mqttContext_ClientId;
                    requestMqttContextIsNull = false;
                }
                System.IO.MemoryStream requestMqttContext_mqttContext_Password = null;
                if (cmdletContext.MqttContext_Password != null)
                {
                    _MqttContext_PasswordStream = new System.IO.MemoryStream(cmdletContext.MqttContext_Password);
                    requestMqttContext_mqttContext_Password = _MqttContext_PasswordStream;
                }
                if (requestMqttContext_mqttContext_Password != null)
                {
                    request.MqttContext.Password = requestMqttContext_mqttContext_Password;
                    requestMqttContextIsNull = false;
                }
                System.String requestMqttContext_mqttContext_Username = null;
                if (cmdletContext.MqttContext_Username != null)
                {
                    requestMqttContext_mqttContext_Username = cmdletContext.MqttContext_Username;
                }
                if (requestMqttContext_mqttContext_Username != null)
                {
                    request.MqttContext.Username = requestMqttContext_mqttContext_Username;
                    requestMqttContextIsNull = false;
                }
                 // determine if request.MqttContext should be set to null
                if (requestMqttContextIsNull)
                {
                    request.MqttContext = null;
                }
                
                 // populate TlsContext
                var requestTlsContextIsNull = true;
                request.TlsContext = new Amazon.IoT.Model.TlsContext();
                System.String requestTlsContext_tlsContext_ServerName = null;
                if (cmdletContext.TlsContext_ServerName != null)
                {
                    requestTlsContext_tlsContext_ServerName = cmdletContext.TlsContext_ServerName;
                }
                if (requestTlsContext_tlsContext_ServerName != null)
                {
                    request.TlsContext.ServerName = requestTlsContext_tlsContext_ServerName;
                    requestTlsContextIsNull = false;
                }
                 // determine if request.TlsContext should be set to null
                if (requestTlsContextIsNull)
                {
                    request.TlsContext = null;
                }
                if (cmdletContext.Token != null)
                {
                    request.Token = cmdletContext.Token;
                }
                if (cmdletContext.TokenSignature != null)
                {
                    request.TokenSignature = cmdletContext.TokenSignature;
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
            finally
            {
                if( _MqttContext_PasswordStream != null)
                {
                    _MqttContext_PasswordStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IoT.Model.TestInvokeAuthorizerResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.TestInvokeAuthorizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "TestInvokeAuthorizer");
            try
            {
                #if DESKTOP
                return client.TestInvokeAuthorizer(request);
                #elif CORECLR
                return client.TestInvokeAuthorizerAsync(request).GetAwaiter().GetResult();
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
            public System.String AuthorizerName { get; set; }
            public Dictionary<System.String, System.String> HttpContext_Header { get; set; }
            public System.String HttpContext_QueryString { get; set; }
            public System.String MqttContext_ClientId { get; set; }
            public byte[] MqttContext_Password { get; set; }
            public System.String MqttContext_Username { get; set; }
            public System.String TlsContext_ServerName { get; set; }
            public System.String Token { get; set; }
            public System.String TokenSignature { get; set; }
            public System.Func<Amazon.IoT.Model.TestInvokeAuthorizerResponse, TestIOTInvokeAuthorizerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
