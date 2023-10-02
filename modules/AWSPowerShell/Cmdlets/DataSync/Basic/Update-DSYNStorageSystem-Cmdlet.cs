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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Modifies some configurations of an on-premises storage system resource that you're
    /// using with DataSync Discovery.
    /// </summary>
    [Cmdlet("Update", "DSYNStorageSystem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS DataSync UpdateStorageSystem API operation.", Operation = new[] {"UpdateStorageSystem"}, SelectReturnType = typeof(Amazon.DataSync.Model.UpdateStorageSystemResponse))]
    [AWSCmdletOutput("None or Amazon.DataSync.Model.UpdateStorageSystemResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataSync.Model.UpdateStorageSystemResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDSYNStorageSystemCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the DataSync agent that connects to and
        /// reads your on-premises storage system. You can only specify one ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentArns")]
        public System.String[] AgentArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogGroupArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the Amazon CloudWatch log group for monitoring and logging discovery
        /// job events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogGroupArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies a familiar name for your on-premises storage system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Credentials_Password
        /// <summary>
        /// <para>
        /// <para>Specifies the password for your storage system's management interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credentials_Password { get; set; }
        #endregion
        
        #region Parameter ServerConfiguration_ServerHostname
        /// <summary>
        /// <para>
        /// <para>The domain name or IP address of your storage system's management interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerConfiguration_ServerHostname { get; set; }
        #endregion
        
        #region Parameter ServerConfiguration_ServerPort
        /// <summary>
        /// <para>
        /// <para>The network port for accessing the storage system's management interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ServerConfiguration_ServerPort { get; set; }
        #endregion
        
        #region Parameter StorageSystemArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the on-premises storage system that you want reconfigure.</para>
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
        public System.String StorageSystemArn { get; set; }
        #endregion
        
        #region Parameter Credentials_Username
        /// <summary>
        /// <para>
        /// <para>Specifies the user name for your storage system's management interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Credentials_Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.UpdateStorageSystemResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StorageSystemArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StorageSystemArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StorageSystemArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StorageSystemArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSYNStorageSystem (UpdateStorageSystem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.UpdateStorageSystemResponse, UpdateDSYNStorageSystemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StorageSystemArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AgentArn != null)
            {
                context.AgentArn = new List<System.String>(this.AgentArn);
            }
            context.CloudWatchLogGroupArn = this.CloudWatchLogGroupArn;
            context.Credentials_Password = this.Credentials_Password;
            context.Credentials_Username = this.Credentials_Username;
            context.Name = this.Name;
            context.ServerConfiguration_ServerHostname = this.ServerConfiguration_ServerHostname;
            context.ServerConfiguration_ServerPort = this.ServerConfiguration_ServerPort;
            context.StorageSystemArn = this.StorageSystemArn;
            #if MODULAR
            if (this.StorageSystemArn == null && ParameterWasBound(nameof(this.StorageSystemArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageSystemArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.DataSync.Model.UpdateStorageSystemRequest();
            
            if (cmdletContext.AgentArn != null)
            {
                request.AgentArns = cmdletContext.AgentArn;
            }
            if (cmdletContext.CloudWatchLogGroupArn != null)
            {
                request.CloudWatchLogGroupArn = cmdletContext.CloudWatchLogGroupArn;
            }
            
             // populate Credentials
            var requestCredentialsIsNull = true;
            request.Credentials = new Amazon.DataSync.Model.Credentials();
            System.String requestCredentials_credentials_Password = null;
            if (cmdletContext.Credentials_Password != null)
            {
                requestCredentials_credentials_Password = cmdletContext.Credentials_Password;
            }
            if (requestCredentials_credentials_Password != null)
            {
                request.Credentials.Password = requestCredentials_credentials_Password;
                requestCredentialsIsNull = false;
            }
            System.String requestCredentials_credentials_Username = null;
            if (cmdletContext.Credentials_Username != null)
            {
                requestCredentials_credentials_Username = cmdletContext.Credentials_Username;
            }
            if (requestCredentials_credentials_Username != null)
            {
                request.Credentials.Username = requestCredentials_credentials_Username;
                requestCredentialsIsNull = false;
            }
             // determine if request.Credentials should be set to null
            if (requestCredentialsIsNull)
            {
                request.Credentials = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ServerConfiguration
            var requestServerConfigurationIsNull = true;
            request.ServerConfiguration = new Amazon.DataSync.Model.DiscoveryServerConfiguration();
            System.String requestServerConfiguration_serverConfiguration_ServerHostname = null;
            if (cmdletContext.ServerConfiguration_ServerHostname != null)
            {
                requestServerConfiguration_serverConfiguration_ServerHostname = cmdletContext.ServerConfiguration_ServerHostname;
            }
            if (requestServerConfiguration_serverConfiguration_ServerHostname != null)
            {
                request.ServerConfiguration.ServerHostname = requestServerConfiguration_serverConfiguration_ServerHostname;
                requestServerConfigurationIsNull = false;
            }
            System.Int32? requestServerConfiguration_serverConfiguration_ServerPort = null;
            if (cmdletContext.ServerConfiguration_ServerPort != null)
            {
                requestServerConfiguration_serverConfiguration_ServerPort = cmdletContext.ServerConfiguration_ServerPort.Value;
            }
            if (requestServerConfiguration_serverConfiguration_ServerPort != null)
            {
                request.ServerConfiguration.ServerPort = requestServerConfiguration_serverConfiguration_ServerPort.Value;
                requestServerConfigurationIsNull = false;
            }
             // determine if request.ServerConfiguration should be set to null
            if (requestServerConfigurationIsNull)
            {
                request.ServerConfiguration = null;
            }
            if (cmdletContext.StorageSystemArn != null)
            {
                request.StorageSystemArn = cmdletContext.StorageSystemArn;
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
        
        private Amazon.DataSync.Model.UpdateStorageSystemResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.UpdateStorageSystemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "UpdateStorageSystem");
            try
            {
                #if DESKTOP
                return client.UpdateStorageSystem(request);
                #elif CORECLR
                return client.UpdateStorageSystemAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AgentArn { get; set; }
            public System.String CloudWatchLogGroupArn { get; set; }
            public System.String Credentials_Password { get; set; }
            public System.String Credentials_Username { get; set; }
            public System.String Name { get; set; }
            public System.String ServerConfiguration_ServerHostname { get; set; }
            public System.Int32? ServerConfiguration_ServerPort { get; set; }
            public System.String StorageSystemArn { get; set; }
            public System.Func<Amazon.DataSync.Model.UpdateStorageSystemResponse, UpdateDSYNStorageSystemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
