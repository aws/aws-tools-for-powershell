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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Deletes a virtual MFA device.
    /// 
    ///  <note><para>
    ///  You must deactivate a user's virtual MFA device before you can delete it. For information
    /// about deactivating MFA devices, see <a>DeactivateMFADevice</a>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "IAMVirtualMFADevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management DeleteVirtualMFADevice API operation.", Operation = new[] {"DeleteVirtualMFADevice"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.DeleteVirtualMFADeviceResponse))]
    [AWSCmdletOutput("None or Amazon.IdentityManagement.Model.DeleteVirtualMFADeviceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IdentityManagement.Model.DeleteVirtualMFADeviceResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveIAMVirtualMFADeviceCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SerialNumber
        /// <summary>
        /// <para>
        /// <para>The serial number that uniquely identifies the MFA device. For virtual MFA devices,
        /// the serial number is the same as the ARN.</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of upper and lowercase alphanumeric
        /// characters with no spaces. You can also include any of the following characters: =,.@:/-</para>
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
        public System.String SerialNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.DeleteVirtualMFADeviceResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SerialNumber), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IAMVirtualMFADevice (DeleteVirtualMFADevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.DeleteVirtualMFADeviceResponse, RemoveIAMVirtualMFADeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SerialNumber = this.SerialNumber;
            #if MODULAR
            if (this.SerialNumber == null && ParameterWasBound(nameof(this.SerialNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter SerialNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.DeleteVirtualMFADeviceRequest();
            
            if (cmdletContext.SerialNumber != null)
            {
                request.SerialNumber = cmdletContext.SerialNumber;
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
        
        private Amazon.IdentityManagement.Model.DeleteVirtualMFADeviceResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.DeleteVirtualMFADeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "DeleteVirtualMFADevice");
            try
            {
                return client.DeleteVirtualMFADeviceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SerialNumber { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.DeleteVirtualMFADeviceResponse, RemoveIAMVirtualMFADeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
