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
using Amazon.EC2InstanceConnect;
using Amazon.EC2InstanceConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IC
{
    /// <summary>
    /// Pushes an SSH public key to the specified EC2 instance. The key remains for 60 seconds,
    /// which gives you 60 seconds to establish a serial console connection to the instance
    /// using SSH. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-serial-console.html">EC2
    /// Serial Console</a> in the <i>Amazon EC2 User Guide</i>.
    /// </summary>
    [Cmdlet("Send", "EC2ICSerialConsoleSSHPublicKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the AWS EC2 Instance Connect SendSerialConsoleSSHPublicKey API operation.", Operation = new[] {"SendSerialConsoleSSHPublicKey"}, SelectReturnType = typeof(Amazon.EC2InstanceConnect.Model.SendSerialConsoleSSHPublicKeyResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2InstanceConnect.Model.SendSerialConsoleSSHPublicKeyResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.EC2InstanceConnect.Model.SendSerialConsoleSSHPublicKeyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendEC2ICSerialConsoleSSHPublicKeyCmdlet : AmazonEC2InstanceConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the EC2 instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter SerialPort
        /// <summary>
        /// <para>
        /// <para>The serial port of the EC2 instance. Currently only port 0 is supported.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SerialPort { get; set; }
        #endregion
        
        #region Parameter SSHPublicKey
        /// <summary>
        /// <para>
        /// <para>The public key material. To use the public key, you must have the matching private
        /// key. For information about the supported key formats and lengths, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-key-pairs.html#how-to-generate-your-own-key-and-import-it-to-aws">Requirements
        /// for key pairs</a> in the <i>Amazon EC2 User Guide</i>.</para>
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
        public System.String SSHPublicKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Success'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2InstanceConnect.Model.SendSerialConsoleSSHPublicKeyResponse).
        /// Specifying the name of a property of type Amazon.EC2InstanceConnect.Model.SendSerialConsoleSSHPublicKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Success";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-EC2ICSerialConsoleSSHPublicKey (SendSerialConsoleSSHPublicKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2InstanceConnect.Model.SendSerialConsoleSSHPublicKeyResponse, SendEC2ICSerialConsoleSSHPublicKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SerialPort = this.SerialPort;
            context.SSHPublicKey = this.SSHPublicKey;
            #if MODULAR
            if (this.SSHPublicKey == null && ParameterWasBound(nameof(this.SSHPublicKey)))
            {
                WriteWarning("You are passing $null as a value for parameter SSHPublicKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2InstanceConnect.Model.SendSerialConsoleSSHPublicKeyRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.SerialPort != null)
            {
                request.SerialPort = cmdletContext.SerialPort.Value;
            }
            if (cmdletContext.SSHPublicKey != null)
            {
                request.SSHPublicKey = cmdletContext.SSHPublicKey;
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
        
        private Amazon.EC2InstanceConnect.Model.SendSerialConsoleSSHPublicKeyResponse CallAWSServiceOperation(IAmazonEC2InstanceConnect client, Amazon.EC2InstanceConnect.Model.SendSerialConsoleSSHPublicKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS EC2 Instance Connect", "SendSerialConsoleSSHPublicKey");
            try
            {
                #if DESKTOP
                return client.SendSerialConsoleSSHPublicKey(request);
                #elif CORECLR
                return client.SendSerialConsoleSSHPublicKeyAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.Int32? SerialPort { get; set; }
            public System.String SSHPublicKey { get; set; }
            public System.Func<Amazon.EC2InstanceConnect.Model.SendSerialConsoleSSHPublicKeyResponse, SendEC2ICSerialConsoleSSHPublicKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Success;
        }
        
    }
}
