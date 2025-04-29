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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Download an Amazon Web Services-provided sample configuration file to be used with
    /// the customer gateway device specified for your Site-to-Site VPN connection.
    /// </summary>
    [Cmdlet("Get", "EC2VpnConnectionDeviceSampleConfiguration")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetVpnConnectionDeviceSampleConfiguration API operation.", Operation = new[] {"GetVpnConnectionDeviceSampleConfiguration"}, SelectReturnType = typeof(Amazon.EC2.Model.GetVpnConnectionDeviceSampleConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.GetVpnConnectionDeviceSampleConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.GetVpnConnectionDeviceSampleConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2VpnConnectionDeviceSampleConfigurationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter InternetKeyExchangeVersion
        /// <summary>
        /// <para>
        /// <para>The IKE version to be used in the sample configuration file for your customer gateway
        /// device. You can specify one of the following versions: <c>ikev1</c> or <c>ikev2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InternetKeyExchangeVersion { get; set; }
        #endregion
        
        #region Parameter VpnConnectionDeviceTypeId
        /// <summary>
        /// <para>
        /// <para>Device identifier provided by the <c>GetVpnConnectionDeviceTypes</c> API.</para>
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
        public System.String VpnConnectionDeviceTypeId { get; set; }
        #endregion
        
        #region Parameter VpnConnectionId
        /// <summary>
        /// <para>
        /// <para>The <c>VpnConnectionId</c> specifies the Site-to-Site VPN connection used for the
        /// sample configuration.</para>
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
        public System.String VpnConnectionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpnConnectionDeviceSampleConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetVpnConnectionDeviceSampleConfigurationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetVpnConnectionDeviceSampleConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpnConnectionDeviceSampleConfiguration";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetVpnConnectionDeviceSampleConfigurationResponse, GetEC2VpnConnectionDeviceSampleConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.InternetKeyExchangeVersion = this.InternetKeyExchangeVersion;
            context.VpnConnectionDeviceTypeId = this.VpnConnectionDeviceTypeId;
            #if MODULAR
            if (this.VpnConnectionDeviceTypeId == null && ParameterWasBound(nameof(this.VpnConnectionDeviceTypeId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpnConnectionDeviceTypeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpnConnectionId = this.VpnConnectionId;
            #if MODULAR
            if (this.VpnConnectionId == null && ParameterWasBound(nameof(this.VpnConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpnConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.GetVpnConnectionDeviceSampleConfigurationRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.InternetKeyExchangeVersion != null)
            {
                request.InternetKeyExchangeVersion = cmdletContext.InternetKeyExchangeVersion;
            }
            if (cmdletContext.VpnConnectionDeviceTypeId != null)
            {
                request.VpnConnectionDeviceTypeId = cmdletContext.VpnConnectionDeviceTypeId;
            }
            if (cmdletContext.VpnConnectionId != null)
            {
                request.VpnConnectionId = cmdletContext.VpnConnectionId;
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
        
        private Amazon.EC2.Model.GetVpnConnectionDeviceSampleConfigurationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetVpnConnectionDeviceSampleConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetVpnConnectionDeviceSampleConfiguration");
            try
            {
                return client.GetVpnConnectionDeviceSampleConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String InternetKeyExchangeVersion { get; set; }
            public System.String VpnConnectionDeviceTypeId { get; set; }
            public System.String VpnConnectionId { get; set; }
            public System.Func<Amazon.EC2.Model.GetVpnConnectionDeviceSampleConfigurationResponse, GetEC2VpnConnectionDeviceSampleConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpnConnectionDeviceSampleConfiguration;
        }
        
    }
}
