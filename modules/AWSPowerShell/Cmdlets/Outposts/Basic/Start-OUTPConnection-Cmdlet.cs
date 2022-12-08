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
using Amazon.Outposts;
using Amazon.Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// <note><para>
    ///  Amazon Web Services uses this action to install Outpost servers.
    /// </para></note><para>
    ///  Starts the connection required for Outpost server installation. 
    /// </para><para>
    ///  Use CloudTrail to monitor this action or Amazon Web Services managed policy for Amazon
    /// Web Services Outposts to secure it. For more information, see <a href="https://docs.aws.amazon.com/outposts/latest/userguide/security-iam-awsmanpol.html">
    /// Amazon Web Services managed policies for Amazon Web Services Outposts</a> and <a href="https://docs.aws.amazon.com/outposts/latest/userguide/logging-using-cloudtrail.html">
    /// Logging Amazon Web Services Outposts API calls with Amazon Web Services CloudTrail</a>
    /// in the <i>Amazon Web Services Outposts User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "OUTPConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Outposts.Model.StartConnectionResponse")]
    [AWSCmdlet("Calls the AWS Outposts StartConnection API operation.", Operation = new[] {"StartConnection"}, SelectReturnType = typeof(Amazon.Outposts.Model.StartConnectionResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.StartConnectionResponse",
        "This cmdlet returns an Amazon.Outposts.Model.StartConnectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartOUTPConnectionCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        #region Parameter AssetId
        /// <summary>
        /// <para>
        /// <para> The ID of the Outpost server. </para>
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
        public System.String AssetId { get; set; }
        #endregion
        
        #region Parameter ClientPublicKey
        /// <summary>
        /// <para>
        /// <para> The public key of the client. </para>
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
        public System.String ClientPublicKey { get; set; }
        #endregion
        
        #region Parameter DeviceSerialNumber
        /// <summary>
        /// <para>
        /// <para> The serial number of the dongle. </para>
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
        public System.String DeviceSerialNumber { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceDeviceIndex
        /// <summary>
        /// <para>
        /// <para> The device index of the network interface on the Outpost server. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? NetworkInterfaceDeviceIndex { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.StartConnectionResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.StartConnectionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-OUTPConnection (StartConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.StartConnectionResponse, StartOUTPConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssetId = this.AssetId;
            #if MODULAR
            if (this.AssetId == null && ParameterWasBound(nameof(this.AssetId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientPublicKey = this.ClientPublicKey;
            #if MODULAR
            if (this.ClientPublicKey == null && ParameterWasBound(nameof(this.ClientPublicKey)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientPublicKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceSerialNumber = this.DeviceSerialNumber;
            #if MODULAR
            if (this.DeviceSerialNumber == null && ParameterWasBound(nameof(this.DeviceSerialNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceSerialNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkInterfaceDeviceIndex = this.NetworkInterfaceDeviceIndex;
            #if MODULAR
            if (this.NetworkInterfaceDeviceIndex == null && ParameterWasBound(nameof(this.NetworkInterfaceDeviceIndex)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInterfaceDeviceIndex which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Outposts.Model.StartConnectionRequest();
            
            if (cmdletContext.AssetId != null)
            {
                request.AssetId = cmdletContext.AssetId;
            }
            if (cmdletContext.ClientPublicKey != null)
            {
                request.ClientPublicKey = cmdletContext.ClientPublicKey;
            }
            if (cmdletContext.DeviceSerialNumber != null)
            {
                request.DeviceSerialNumber = cmdletContext.DeviceSerialNumber;
            }
            if (cmdletContext.NetworkInterfaceDeviceIndex != null)
            {
                request.NetworkInterfaceDeviceIndex = cmdletContext.NetworkInterfaceDeviceIndex.Value;
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
        
        private Amazon.Outposts.Model.StartConnectionResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.StartConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "StartConnection");
            try
            {
                #if DESKTOP
                return client.StartConnection(request);
                #elif CORECLR
                return client.StartConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String AssetId { get; set; }
            public System.String ClientPublicKey { get; set; }
            public System.String DeviceSerialNumber { get; set; }
            public System.Int32? NetworkInterfaceDeviceIndex { get; set; }
            public System.Func<Amazon.Outposts.Model.StartConnectionResponse, StartOUTPConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
