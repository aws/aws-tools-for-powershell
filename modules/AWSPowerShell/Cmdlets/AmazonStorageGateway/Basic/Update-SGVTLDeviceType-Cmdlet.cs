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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// This operation updates the type of medium changer in a gateway-VTL. When you activate
    /// a gateway-VTL, you select a medium changer type for the gateway-VTL. This operation
    /// enables you to select a different type of medium changer after a gateway-VTL is activated.
    /// </summary>
    [Cmdlet("Update", "SGVTLDeviceType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the UpdateVTLDeviceType operation against AWS Storage Gateway.", Operation = new[] {"UpdateVTLDeviceType"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type UpdateVTLDeviceTypeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateSGVTLDeviceTypeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The type of medium changer you want to select.</para><para><i>Valid Values</i>: "STK-L700", "AWS-Gateway-VTL"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeviceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the medium changer you want to select.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String VTLDeviceARN { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VTLDeviceARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGVTLDeviceType (UpdateVTLDeviceType)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DeviceType = this.DeviceType;
            context.VTLDeviceARN = this.VTLDeviceARN;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateVTLDeviceTypeRequest();
            
            if (cmdletContext.DeviceType != null)
            {
                request.DeviceType = cmdletContext.DeviceType;
            }
            if (cmdletContext.VTLDeviceARN != null)
            {
                request.VTLDeviceARN = cmdletContext.VTLDeviceARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateVTLDeviceType(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
            public String DeviceType { get; set; }
            public String VTLDeviceARN { get; set; }
        }
        
    }
}
