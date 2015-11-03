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
    [AWSCmdlet("Invokes the UpdateDevicePool operation against AWS Device Farm.", Operation = new[] {"UpdateDevicePool"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.DevicePool",
        "This cmdlet returns a DevicePool object.",
        "The service call response (type Amazon.DeviceFarm.Model.UpdateDevicePoolResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateDFDevicePoolCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The Amazon Resourc Name (ARN) of the Device Farm device pool you wish to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Arn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A description of the device pool you wish to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A string representing the name of the device pool you wish to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        
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
            
            context.Arn = this.Arn;
            context.Description = this.Description;
            context.Name = this.Name;
            if (this.Rule != null)
            {
                context.Rules = new List<Amazon.DeviceFarm.Model.Rule>(this.Rule);
            }
            
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
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
                var response = client.UpdateDevicePool(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Arn { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.DeviceFarm.Model.Rule> Rules { get; set; }
        }
        
    }
}
