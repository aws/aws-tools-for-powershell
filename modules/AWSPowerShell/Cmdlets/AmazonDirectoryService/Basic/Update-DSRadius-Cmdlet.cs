/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// for an AD Connector directory.
    /// </summary>
    [Cmdlet("Update", "DSRadius", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateRadius operation against AWS Directory Service.", Operation = new[] {"UpdateRadius"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DirectoryId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.DirectoryService.Model.UpdateRadiusResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateDSRadiusCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The protocol specified for your RADIUS endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.DirectoryService.RadiusAuthenticationProtocol RadiusSettings_AuthenticationProtocol { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory for which to update the RADIUS server information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Not currently used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RadiusSettings_DisplayLabel { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The port that your RADIUS server is using for communications. Your on-premises network
        /// must allow inbound traffic over this port from the AWS Directory Service servers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 RadiusSettings_RadiusPort { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of times that communication with the RADIUS server is attempted.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RadiusSettings_RadiusRetries")]
        public System.Int32 RadiusSettings_RadiusRetry { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of strings that contains the IP addresses of the RADIUS server endpoints,
        /// or the IP addresses of your RADIUS server load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RadiusSettings_RadiusServers")]
        public System.String[] RadiusSettings_RadiusServer { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, to wait for the RADIUS server to respond.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 RadiusSettings_RadiusTimeout { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The shared secret code that was specified when your RADIUS endpoints were created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RadiusSettings_SharedSecret { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Not currently used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RadiusSettings_UseSameUsername { get; set; }
        
        /// <summary>
        /// Returns the value passed to the DirectoryId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectoryId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSRadius (UpdateRadius)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DirectoryId = this.DirectoryId;
            context.RadiusSettings_AuthenticationProtocol = this.RadiusSettings_AuthenticationProtocol;
            context.RadiusSettings_DisplayLabel = this.RadiusSettings_DisplayLabel;
            if (ParameterWasBound("RadiusSettings_RadiusPort"))
                context.RadiusSettings_RadiusPort = this.RadiusSettings_RadiusPort;
            if (ParameterWasBound("RadiusSettings_RadiusRetry"))
                context.RadiusSettings_RadiusRetries = this.RadiusSettings_RadiusRetry;
            if (this.RadiusSettings_RadiusServer != null)
            {
                context.RadiusSettings_RadiusServers = new List<System.String>(this.RadiusSettings_RadiusServer);
            }
            if (ParameterWasBound("RadiusSettings_RadiusTimeout"))
                context.RadiusSettings_RadiusTimeout = this.RadiusSettings_RadiusTimeout;
            context.RadiusSettings_SharedSecret = this.RadiusSettings_SharedSecret;
            if (ParameterWasBound("RadiusSettings_UseSameUsername"))
                context.RadiusSettings_UseSameUsername = this.RadiusSettings_UseSameUsername;
            
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
            bool requestRadiusSettingsIsNull = true;
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
            if (cmdletContext.RadiusSettings_RadiusRetries != null)
            {
                requestRadiusSettings_radiusSettings_RadiusRetry = cmdletContext.RadiusSettings_RadiusRetries.Value;
            }
            if (requestRadiusSettings_radiusSettings_RadiusRetry != null)
            {
                request.RadiusSettings.RadiusRetries = requestRadiusSettings_radiusSettings_RadiusRetry.Value;
                requestRadiusSettingsIsNull = false;
            }
            List<System.String> requestRadiusSettings_radiusSettings_RadiusServer = null;
            if (cmdletContext.RadiusSettings_RadiusServers != null)
            {
                requestRadiusSettings_radiusSettings_RadiusServer = cmdletContext.RadiusSettings_RadiusServers;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateRadius(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.DirectoryId;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DirectoryId { get; set; }
            public Amazon.DirectoryService.RadiusAuthenticationProtocol RadiusSettings_AuthenticationProtocol { get; set; }
            public System.String RadiusSettings_DisplayLabel { get; set; }
            public System.Int32? RadiusSettings_RadiusPort { get; set; }
            public System.Int32? RadiusSettings_RadiusRetries { get; set; }
            public List<System.String> RadiusSettings_RadiusServers { get; set; }
            public System.Int32? RadiusSettings_RadiusTimeout { get; set; }
            public System.String RadiusSettings_SharedSecret { get; set; }
            public System.Boolean? RadiusSettings_UseSameUsername { get; set; }
        }
        
    }
}
