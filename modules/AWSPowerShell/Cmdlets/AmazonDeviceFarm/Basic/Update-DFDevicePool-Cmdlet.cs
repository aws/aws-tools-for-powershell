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
    /// Modifies the name, description, and rules in a device pool given the attributes and
    /// the pool ARN. Rule updates are all-or-nothing, meaning they can only be updated as
    /// a whole (or not at all).
    /// </summary>
    [Cmdlet("Update", "DFDevicePool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DeviceFarm.Model.DevicePool")]
    [AWSCmdlet("Calls the AWS Device Farm UpdateDevicePool API operation.", Operation = new[] {"UpdateDevicePool"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.DevicePool",
        "This cmdlet returns a DevicePool object.",
        "The service call response (type Amazon.DeviceFarm.Model.UpdateDevicePoolResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDFDevicePoolCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resourc Name (ARN) of the Device Farm device pool you wish to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ClearMaxDevice
        /// <summary>
        /// <para>
        /// <para>Sets whether the <code>maxDevices</code> parameter applies to your device pool. If
        /// you set this parameter to <code>true</code>, the <code>maxDevices</code> parameter
        /// does not apply, and Device Farm does not limit the number of devices that it adds
        /// to your device pool. In this case, Device Farm adds all available devices that meet
        /// the criteria that are specified for the <code>rules</code> parameter.</para><para>If you use this parameter in your request, you cannot use the <code>maxDevices</code>
        /// parameter in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ClearMaxDevices")]
        public System.Boolean ClearMaxDevice { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the device pool you wish to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MaxDevice
        /// <summary>
        /// <para>
        /// <para>The number of devices that Device Farm can add to your device pool. Device Farm adds
        /// devices that are available and that meet the criteria that you assign for the <code>rules</code>
        /// parameter. Depending on how many devices meet these constraints, your device pool
        /// might contain fewer devices than the value for this parameter.</para><para>By specifying the maximum number of devices, you can control the costs that you incur
        /// by running tests.</para><para>If you use this parameter in your request, you cannot use the <code>clearMaxDevices</code>
        /// parameter in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxDevices")]
        public System.Int32 MaxDevice { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A string representing the name of the device pool you wish to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>Represents the rules you wish to modify for the device pool. Updating rules is optional;
        /// however, if you choose to update rules for your request, the update will replace the
        /// existing rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Rules")]
        public Amazon.DeviceFarm.Model.Rule[] Rule { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Arn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DFDevicePool (UpdateDevicePool)"))
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
            
            context.Arn = this.Arn;
            if (ParameterWasBound("ClearMaxDevice"))
                context.ClearMaxDevices = this.ClearMaxDevice;
            context.Description = this.Description;
            if (ParameterWasBound("MaxDevice"))
                context.MaxDevices = this.MaxDevice;
            context.Name = this.Name;
            if (this.Rule != null)
            {
                context.Rules = new List<Amazon.DeviceFarm.Model.Rule>(this.Rule);
            }
            
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
            var request = new Amazon.DeviceFarm.Model.UpdateDevicePoolRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.ClearMaxDevices != null)
            {
                request.ClearMaxDevices = cmdletContext.ClearMaxDevices.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MaxDevices != null)
            {
                request.MaxDevices = cmdletContext.MaxDevices.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Rules != null)
            {
                request.Rules = cmdletContext.Rules;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DevicePool;
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
        
        private Amazon.DeviceFarm.Model.UpdateDevicePoolResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.UpdateDevicePoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "UpdateDevicePool");
            try
            {
                #if DESKTOP
                return client.UpdateDevicePool(request);
                #elif CORECLR
                return client.UpdateDevicePoolAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.Boolean? ClearMaxDevices { get; set; }
            public System.String Description { get; set; }
            public System.Int32? MaxDevices { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.DeviceFarm.Model.Rule> Rules { get; set; }
        }
        
    }
}
