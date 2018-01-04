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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Specifies and starts a remote access session.
    /// </summary>
    [Cmdlet("New", "DFRemoteAccessSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DeviceFarm.Model.RemoteAccessSession")]
    [AWSCmdlet("Calls the AWS Device Farm CreateRemoteAccessSession API operation.", Operation = new[] {"CreateRemoteAccessSession"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.RemoteAccessSession",
        "This cmdlet returns a RemoteAccessSession object.",
        "The service call response (type Amazon.DeviceFarm.Model.CreateRemoteAccessSessionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDFRemoteAccessSessionCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter Configuration_BillingMethod
        /// <summary>
        /// <para>
        /// <para>Returns the billing method for purposes of configuring a remote access session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DeviceFarm.BillingMethod")]
        public Amazon.DeviceFarm.BillingMethod Configuration_BillingMethod { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the client. If you want access to multiple devices on the same
        /// client, you should pass the same <code>clientId</code> value in each call to <code>CreateRemoteAccessSession</code>.
        /// This is required only if <code>remoteDebugEnabled</code> is set to true <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter DeviceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the device for which you want to create a remote
        /// access session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DeviceArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the remote access session that you wish to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the project for which you want to create a remote
        /// access session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter RemoteDebugEnabled
        /// <summary>
        /// <para>
        /// <para>Set to <code>true</code> if you want to access devices remotely for debugging in your
        /// remote access session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RemoteDebugEnabled { get; set; }
        #endregion
        
        #region Parameter SshPublicKey
        /// <summary>
        /// <para>
        /// <para>The public key of the <code>ssh</code> key pair you want to use for connecting to
        /// remote devices in your remote debugging session. This is only required if <code>remoteDebugEnabled</code>
        /// is set to <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SshPublicKey { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DeviceArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DFRemoteAccessSession (CreateRemoteAccessSession)"))
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
            
            context.ClientId = this.ClientId;
            context.Configuration_BillingMethod = this.Configuration_BillingMethod;
            context.DeviceArn = this.DeviceArn;
            context.Name = this.Name;
            context.ProjectArn = this.ProjectArn;
            if (ParameterWasBound("RemoteDebugEnabled"))
                context.RemoteDebugEnabled = this.RemoteDebugEnabled;
            context.SshPublicKey = this.SshPublicKey;
            
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
            var request = new Amazon.DeviceFarm.Model.CreateRemoteAccessSessionRequest();
            
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            
             // populate Configuration
            bool requestConfigurationIsNull = true;
            request.Configuration = new Amazon.DeviceFarm.Model.CreateRemoteAccessSessionConfiguration();
            Amazon.DeviceFarm.BillingMethod requestConfiguration_configuration_BillingMethod = null;
            if (cmdletContext.Configuration_BillingMethod != null)
            {
                requestConfiguration_configuration_BillingMethod = cmdletContext.Configuration_BillingMethod;
            }
            if (requestConfiguration_configuration_BillingMethod != null)
            {
                request.Configuration.BillingMethod = requestConfiguration_configuration_BillingMethod;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.DeviceArn != null)
            {
                request.DeviceArn = cmdletContext.DeviceArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            if (cmdletContext.RemoteDebugEnabled != null)
            {
                request.RemoteDebugEnabled = cmdletContext.RemoteDebugEnabled.Value;
            }
            if (cmdletContext.SshPublicKey != null)
            {
                request.SshPublicKey = cmdletContext.SshPublicKey;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RemoteAccessSession;
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
        
        private Amazon.DeviceFarm.Model.CreateRemoteAccessSessionResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.CreateRemoteAccessSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "CreateRemoteAccessSession");
            try
            {
                #if DESKTOP
                return client.CreateRemoteAccessSession(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateRemoteAccessSessionAsync(request);
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
            public System.String ClientId { get; set; }
            public Amazon.DeviceFarm.BillingMethod Configuration_BillingMethod { get; set; }
            public System.String DeviceArn { get; set; }
            public System.String Name { get; set; }
            public System.String ProjectArn { get; set; }
            public System.Boolean? RemoteDebugEnabled { get; set; }
            public System.String SshPublicKey { get; set; }
        }
        
    }
}
