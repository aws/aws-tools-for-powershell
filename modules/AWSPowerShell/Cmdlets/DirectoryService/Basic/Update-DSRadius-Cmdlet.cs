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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Updates the Remote Authentication Dial In User Service (RADIUS) server information
    /// for an AD Connector or Microsoft AD directory.
    /// </summary>
    [Cmdlet("Update", "DSRadius", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Directory Service UpdateRadius API operation.", Operation = new[] {"UpdateRadius"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.UpdateRadiusResponse))]
    [AWSCmdletOutput("None or Amazon.DirectoryService.Model.UpdateRadiusResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DirectoryService.Model.UpdateRadiusResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateDSRadiusCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RadiusSettings_AuthenticationProtocol
        /// <summary>
        /// <para>
        /// <para>The protocol specified for your RADIUS endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectoryService.RadiusAuthenticationProtocol")]
        public Amazon.DirectoryService.RadiusAuthenticationProtocol RadiusSettings_AuthenticationProtocol { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory for which to update the RADIUS server information.</para>
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
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter RadiusSettings_DisplayLabel
        /// <summary>
        /// <para>
        /// <para>Not currently used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RadiusSettings_DisplayLabel { get; set; }
        #endregion
        
        #region Parameter RadiusSettings_RadiusPort
        /// <summary>
        /// <para>
        /// <para>The port that your RADIUS server is using for communications. Your self-managed network
        /// must allow inbound traffic over this port from the Directory Service servers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RadiusSettings_RadiusPort { get; set; }
        #endregion
        
        #region Parameter RadiusSettings_RadiusRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of times that communication with the RADIUS server is retried after
        /// the initial attempt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RadiusSettings_RadiusRetries")]
        public System.Int32? RadiusSettings_RadiusRetry { get; set; }
        #endregion
        
        #region Parameter RadiusSettings_RadiusServer
        /// <summary>
        /// <para>
        /// <para>An array of strings that contains the fully qualified domain name (FQDN) or IP addresses
        /// of the RADIUS server endpoints, or the FQDN or IP addresses of your RADIUS server
        /// load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RadiusSettings_RadiusServers")]
        public System.String[] RadiusSettings_RadiusServer { get; set; }
        #endregion
        
        #region Parameter RadiusSettings_RadiusTimeout
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, to wait for the RADIUS server to respond.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RadiusSettings_RadiusTimeout { get; set; }
        #endregion
        
        #region Parameter RadiusSettings_SharedSecret
        /// <summary>
        /// <para>
        /// <para>Required for enabling RADIUS on the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RadiusSettings_SharedSecret { get; set; }
        #endregion
        
        #region Parameter RadiusSettings_UseSameUsername
        /// <summary>
        /// <para>
        /// <para>Not currently used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RadiusSettings_UseSameUsername { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.UpdateRadiusResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSRadius (UpdateRadius)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.UpdateRadiusResponse, UpdateDSRadiusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RadiusSettings_AuthenticationProtocol = this.RadiusSettings_AuthenticationProtocol;
            context.RadiusSettings_DisplayLabel = this.RadiusSettings_DisplayLabel;
            context.RadiusSettings_RadiusPort = this.RadiusSettings_RadiusPort;
            context.RadiusSettings_RadiusRetry = this.RadiusSettings_RadiusRetry;
            if (this.RadiusSettings_RadiusServer != null)
            {
                context.RadiusSettings_RadiusServer = new List<System.String>(this.RadiusSettings_RadiusServer);
            }
            context.RadiusSettings_RadiusTimeout = this.RadiusSettings_RadiusTimeout;
            context.RadiusSettings_SharedSecret = this.RadiusSettings_SharedSecret;
            context.RadiusSettings_UseSameUsername = this.RadiusSettings_UseSameUsername;
            
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
            var request = new Amazon.DirectoryService.Model.UpdateRadiusRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            
             // populate RadiusSettings
            var requestRadiusSettingsIsNull = true;
            request.RadiusSettings = new Amazon.DirectoryService.Model.RadiusSettings();
            Amazon.DirectoryService.RadiusAuthenticationProtocol requestRadiusSettings_radiusSettings_AuthenticationProtocol = null;
            if (cmdletContext.RadiusSettings_AuthenticationProtocol != null)
            {
                requestRadiusSettings_radiusSettings_AuthenticationProtocol = cmdletContext.RadiusSettings_AuthenticationProtocol;
            }
            if (requestRadiusSettings_radiusSettings_AuthenticationProtocol != null)
            {
                request.RadiusSettings.AuthenticationProtocol = requestRadiusSettings_radiusSettings_AuthenticationProtocol;
                requestRadiusSettingsIsNull = false;
            }
            System.String requestRadiusSettings_radiusSettings_DisplayLabel = null;
            if (cmdletContext.RadiusSettings_DisplayLabel != null)
            {
                requestRadiusSettings_radiusSettings_DisplayLabel = cmdletContext.RadiusSettings_DisplayLabel;
            }
            if (requestRadiusSettings_radiusSettings_DisplayLabel != null)
            {
                request.RadiusSettings.DisplayLabel = requestRadiusSettings_radiusSettings_DisplayLabel;
                requestRadiusSettingsIsNull = false;
            }
            System.Int32? requestRadiusSettings_radiusSettings_RadiusPort = null;
            if (cmdletContext.RadiusSettings_RadiusPort != null)
            {
                requestRadiusSettings_radiusSettings_RadiusPort = cmdletContext.RadiusSettings_RadiusPort.Value;
            }
            if (requestRadiusSettings_radiusSettings_RadiusPort != null)
            {
                request.RadiusSettings.RadiusPort = requestRadiusSettings_radiusSettings_RadiusPort.Value;
                requestRadiusSettingsIsNull = false;
            }
            System.Int32? requestRadiusSettings_radiusSettings_RadiusRetry = null;
            if (cmdletContext.RadiusSettings_RadiusRetry != null)
            {
                requestRadiusSettings_radiusSettings_RadiusRetry = cmdletContext.RadiusSettings_RadiusRetry.Value;
            }
            if (requestRadiusSettings_radiusSettings_RadiusRetry != null)
            {
                request.RadiusSettings.RadiusRetries = requestRadiusSettings_radiusSettings_RadiusRetry.Value;
                requestRadiusSettingsIsNull = false;
            }
            List<System.String> requestRadiusSettings_radiusSettings_RadiusServer = null;
            if (cmdletContext.RadiusSettings_RadiusServer != null)
            {
                requestRadiusSettings_radiusSettings_RadiusServer = cmdletContext.RadiusSettings_RadiusServer;
            }
            if (requestRadiusSettings_radiusSettings_RadiusServer != null)
            {
                request.RadiusSettings.RadiusServers = requestRadiusSettings_radiusSettings_RadiusServer;
                requestRadiusSettingsIsNull = false;
            }
            System.Int32? requestRadiusSettings_radiusSettings_RadiusTimeout = null;
            if (cmdletContext.RadiusSettings_RadiusTimeout != null)
            {
                requestRadiusSettings_radiusSettings_RadiusTimeout = cmdletContext.RadiusSettings_RadiusTimeout.Value;
            }
            if (requestRadiusSettings_radiusSettings_RadiusTimeout != null)
            {
                request.RadiusSettings.RadiusTimeout = requestRadiusSettings_radiusSettings_RadiusTimeout.Value;
                requestRadiusSettingsIsNull = false;
            }
            System.String requestRadiusSettings_radiusSettings_SharedSecret = null;
            if (cmdletContext.RadiusSettings_SharedSecret != null)
            {
                requestRadiusSettings_radiusSettings_SharedSecret = cmdletContext.RadiusSettings_SharedSecret;
            }
            if (requestRadiusSettings_radiusSettings_SharedSecret != null)
            {
                request.RadiusSettings.SharedSecret = requestRadiusSettings_radiusSettings_SharedSecret;
                requestRadiusSettingsIsNull = false;
            }
            System.Boolean? requestRadiusSettings_radiusSettings_UseSameUsername = null;
            if (cmdletContext.RadiusSettings_UseSameUsername != null)
            {
                requestRadiusSettings_radiusSettings_UseSameUsername = cmdletContext.RadiusSettings_UseSameUsername.Value;
            }
            if (requestRadiusSettings_radiusSettings_UseSameUsername != null)
            {
                request.RadiusSettings.UseSameUsername = requestRadiusSettings_radiusSettings_UseSameUsername.Value;
                requestRadiusSettingsIsNull = false;
            }
             // determine if request.RadiusSettings should be set to null
            if (requestRadiusSettingsIsNull)
            {
                request.RadiusSettings = null;
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
        
        private Amazon.DirectoryService.Model.UpdateRadiusResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.UpdateRadiusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "UpdateRadius");
            try
            {
                #if DESKTOP
                return client.UpdateRadius(request);
                #elif CORECLR
                return client.UpdateRadiusAsync(request).GetAwaiter().GetResult();
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
            public System.String DirectoryId { get; set; }
            public Amazon.DirectoryService.RadiusAuthenticationProtocol RadiusSettings_AuthenticationProtocol { get; set; }
            public System.String RadiusSettings_DisplayLabel { get; set; }
            public System.Int32? RadiusSettings_RadiusPort { get; set; }
            public System.Int32? RadiusSettings_RadiusRetry { get; set; }
            public List<System.String> RadiusSettings_RadiusServer { get; set; }
            public System.Int32? RadiusSettings_RadiusTimeout { get; set; }
            public System.String RadiusSettings_SharedSecret { get; set; }
            public System.Boolean? RadiusSettings_UseSameUsername { get; set; }
            public System.Func<Amazon.DirectoryService.Model.UpdateRadiusResponse, UpdateDSRadiusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
