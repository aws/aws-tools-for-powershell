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
using System.Threading;
using Amazon.BackupGateway;
using Amazon.BackupGateway.Model;

namespace Amazon.PowerShell.Cmdlets.BUGW
{
    /// <summary>
    /// Tests your hypervisor configuration to validate that backup gateway can connect with
    /// the hypervisor and its resources.
    /// </summary>
    [Cmdlet("Test", "BUGWHypervisorConfiguration")]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Backup Gateway TestHypervisorConfiguration API operation.", Operation = new[] {"TestHypervisorConfiguration"}, SelectReturnType = typeof(Amazon.BackupGateway.Model.TestHypervisorConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.BackupGateway.Model.TestHypervisorConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.BackupGateway.Model.TestHypervisorConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class TestBUGWHypervisorConfigurationCmdlet : AmazonBackupGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GatewayArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the gateway to the hypervisor to test.</para>
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
        public System.String GatewayArn { get; set; }
        #endregion
        
        #region Parameter HypervisorHost
        /// <summary>
        /// <para>
        /// <para>The server host of the hypervisor. This can be either an IP address or a fully-qualified
        /// domain name (FQDN).</para>
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
        [Alias("Host")]
        public System.String HypervisorHost { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password for the hypervisor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The username for the hypervisor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupGateway.Model.TestHypervisorConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BackupGateway.Model.TestHypervisorConfigurationResponse, TestBUGWHypervisorConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GatewayArn = this.GatewayArn;
            #if MODULAR
            if (this.GatewayArn == null && ParameterWasBound(nameof(this.GatewayArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HypervisorHost = this.HypervisorHost;
            #if MODULAR
            if (this.HypervisorHost == null && ParameterWasBound(nameof(this.HypervisorHost)))
            {
                WriteWarning("You are passing $null as a value for parameter HypervisorHost which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Password = this.Password;
            context.Username = this.Username;
            
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
            var request = new Amazon.BackupGateway.Model.TestHypervisorConfigurationRequest();
            
            if (cmdletContext.GatewayArn != null)
            {
                request.GatewayArn = cmdletContext.GatewayArn;
            }
            if (cmdletContext.HypervisorHost != null)
            {
                request.Host = cmdletContext.HypervisorHost;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
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
        
        private Amazon.BackupGateway.Model.TestHypervisorConfigurationResponse CallAWSServiceOperation(IAmazonBackupGateway client, Amazon.BackupGateway.Model.TestHypervisorConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Gateway", "TestHypervisorConfiguration");
            try
            {
                return client.TestHypervisorConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GatewayArn { get; set; }
            public System.String HypervisorHost { get; set; }
            public System.String Password { get; set; }
            public System.String Username { get; set; }
            public System.Func<Amazon.BackupGateway.Model.TestHypervisorConfigurationResponse, TestBUGWHypervisorConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
