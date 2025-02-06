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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Creates a relay resource which can be used in rules to relay incoming emails to defined
    /// relay destinations.
    /// </summary>
    [Cmdlet("New", "MMGRRelay", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager CreateRelay API operation.", Operation = new[] {"CreateRelay"}, SelectReturnType = typeof(Amazon.MailManager.Model.CreateRelayResponse))]
    [AWSCmdletOutput("System.String or Amazon.MailManager.Model.CreateRelayResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MailManager.Model.CreateRelayResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMMGRRelayCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Authentication_NoAuthentication
        /// <summary>
        /// <para>
        /// <para>Keep an empty structure if the relay destination server does not require SMTP credential
        /// authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MailManager.Model.NoAuthentication Authentication_NoAuthentication { get; set; }
        #endregion
        
        #region Parameter RelayName
        /// <summary>
        /// <para>
        /// <para>The unique name of the relay resource.</para>
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
        public System.String RelayName { get; set; }
        #endregion
        
        #region Parameter Authentication_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the secret created in secrets manager where the relay server's SMTP credentials
        /// are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Authentication_SecretArn { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para>The destination relay server address.</para>
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
        public System.String ServerName { get; set; }
        #endregion
        
        #region Parameter ServerPort
        /// <summary>
        /// <para>
        /// <para>The destination relay server port.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ServerPort { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for the resource. For example,
        /// { "tags": {"key1":"value1", "key2":"value2"} }.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.MailManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that Amazon SES uses to recognize subsequent retries of the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RelayId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.CreateRelayResponse).
        /// Specifying the name of a property of type Amazon.MailManager.Model.CreateRelayResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RelayId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RelayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MMGRRelay (CreateRelay)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.CreateRelayResponse, NewMMGRRelayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Authentication_NoAuthentication = this.Authentication_NoAuthentication;
            context.Authentication_SecretArn = this.Authentication_SecretArn;
            context.ClientToken = this.ClientToken;
            context.RelayName = this.RelayName;
            #if MODULAR
            if (this.RelayName == null && ParameterWasBound(nameof(this.RelayName)))
            {
                WriteWarning("You are passing $null as a value for parameter RelayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerName = this.ServerName;
            #if MODULAR
            if (this.ServerName == null && ParameterWasBound(nameof(this.ServerName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerPort = this.ServerPort;
            #if MODULAR
            if (this.ServerPort == null && ParameterWasBound(nameof(this.ServerPort)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerPort which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.MailManager.Model.Tag>(this.Tag);
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
            var request = new Amazon.MailManager.Model.CreateRelayRequest();
            
            
             // populate Authentication
            var requestAuthenticationIsNull = true;
            request.Authentication = new Amazon.MailManager.Model.RelayAuthentication();
            Amazon.MailManager.Model.NoAuthentication requestAuthentication_authentication_NoAuthentication = null;
            if (cmdletContext.Authentication_NoAuthentication != null)
            {
                requestAuthentication_authentication_NoAuthentication = cmdletContext.Authentication_NoAuthentication;
            }
            if (requestAuthentication_authentication_NoAuthentication != null)
            {
                request.Authentication.NoAuthentication = requestAuthentication_authentication_NoAuthentication;
                requestAuthenticationIsNull = false;
            }
            System.String requestAuthentication_authentication_SecretArn = null;
            if (cmdletContext.Authentication_SecretArn != null)
            {
                requestAuthentication_authentication_SecretArn = cmdletContext.Authentication_SecretArn;
            }
            if (requestAuthentication_authentication_SecretArn != null)
            {
                request.Authentication.SecretArn = requestAuthentication_authentication_SecretArn;
                requestAuthenticationIsNull = false;
            }
             // determine if request.Authentication should be set to null
            if (requestAuthenticationIsNull)
            {
                request.Authentication = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.RelayName != null)
            {
                request.RelayName = cmdletContext.RelayName;
            }
            if (cmdletContext.ServerName != null)
            {
                request.ServerName = cmdletContext.ServerName;
            }
            if (cmdletContext.ServerPort != null)
            {
                request.ServerPort = cmdletContext.ServerPort.Value;
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
        
        private Amazon.MailManager.Model.CreateRelayResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.CreateRelayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "CreateRelay");
            try
            {
                #if DESKTOP
                return client.CreateRelay(request);
                #elif CORECLR
                return client.CreateRelayAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MailManager.Model.NoAuthentication Authentication_NoAuthentication { get; set; }
            public System.String Authentication_SecretArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String RelayName { get; set; }
            public System.String ServerName { get; set; }
            public System.Int32? ServerPort { get; set; }
            public List<Amazon.MailManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.MailManager.Model.CreateRelayResponse, NewMMGRRelayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RelayId;
        }
        
    }
}
