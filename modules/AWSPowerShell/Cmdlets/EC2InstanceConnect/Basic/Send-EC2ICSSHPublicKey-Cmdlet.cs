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
using Amazon.EC2InstanceConnect;
using Amazon.EC2InstanceConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IC
{
    /// <summary>
    /// Pushes an SSH public key to the specified EC2 instance for use by the specified user.
    /// The key remains for 60 seconds. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Connect-using-EC2-Instance-Connect.html">Connect
    /// to your Linux instance using EC2 Instance Connect</a> in the <i>Amazon EC2 User Guide</i>.
    /// </summary>
    [Cmdlet("Send", "EC2ICSSHPublicKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the AWS EC2 Instance Connect SendSSHPublicKey API operation.", Operation = new[] {"SendSSHPublicKey"}, SelectReturnType = typeof(Amazon.EC2InstanceConnect.Model.SendSSHPublicKeyResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2InstanceConnect.Model.SendSSHPublicKeyResponse",
        "This cmdlet returns a collection of System.Boolean objects.",
        "The service call response (type Amazon.EC2InstanceConnect.Model.SendSSHPublicKeyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendEC2ICSSHPublicKeyCmdlet : AmazonEC2InstanceConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which the EC2 instance was launched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
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
        
        #region Parameter InstanceOSUser
        /// <summary>
        /// <para>
        /// <para>The OS user on the EC2 instance for whom the key can be used to authenticate.</para>
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
        public System.String InstanceOSUser { get; set; }
        #endregion
        
        #region Parameter SSHPublicKey
        /// <summary>
        /// <para>
        /// <para>The public key material. To use the public key, you must have the matching private
        /// key.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2InstanceConnect.Model.SendSSHPublicKeyResponse).
        /// Specifying the name of a property of type Amazon.EC2InstanceConnect.Model.SendSSHPublicKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Success";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-EC2ICSSHPublicKey (SendSSHPublicKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2InstanceConnect.Model.SendSSHPublicKeyResponse, SendEC2ICSSHPublicKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceOSUser = this.InstanceOSUser;
            #if MODULAR
            if (this.InstanceOSUser == null && ParameterWasBound(nameof(this.InstanceOSUser)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceOSUser which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.EC2InstanceConnect.Model.SendSSHPublicKeyRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.InstanceOSUser != null)
            {
                request.InstanceOSUser = cmdletContext.InstanceOSUser;
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
        
        private Amazon.EC2InstanceConnect.Model.SendSSHPublicKeyResponse CallAWSServiceOperation(IAmazonEC2InstanceConnect client, Amazon.EC2InstanceConnect.Model.SendSSHPublicKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS EC2 Instance Connect", "SendSSHPublicKey");
            try
            {
                return client.SendSSHPublicKeyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String InstanceId { get; set; }
            public System.String InstanceOSUser { get; set; }
            public System.String SSHPublicKey { get; set; }
            public System.Func<Amazon.EC2InstanceConnect.Model.SendSSHPublicKeyResponse, SendEC2ICSSHPublicKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Success;
        }
        
    }
}
