/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.PowerShell.Common;
using Amazon.EC2.Model;
using Amazon.PowerShell.Properties;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Stops or terminates an instance.
    /// 
    /// Instances that use Amazon EBS volumes as their root devices can be
    /// quickly stopped and started. When an instance is
    /// stopped, the compute resources are released and
    /// you are not billed for hourly instance usage. However,
    /// your root partition Amazon EBS volume remains,
    /// continues to persist your data, and you are charged
    /// for Amazon EBS volume usage. You can restart
    /// your instance at any time.
    /// 
    /// Before stopping an instance, make sure it is in a state from
    /// which it can be restarted. Stopping an instance does not preserve
    /// data stored in RAM.
    /// 
    /// Stopping an instance that uses an instance store as its
    /// root device returns an error.
    /// 
    /// The Terminate operation is idempotent; if you
    /// terminate an instance more than once, each
    /// call will succeed.
    /// 
    /// Terminated instances will remain visible after
    /// termination (approximately one hour).
    /// </summary>
    [Cmdlet("Stop", "EC2Instance", SupportsShouldProcess = true, DefaultParameterSetName = ParamSet_StopInstances)]
    [OutputType("Amazon.EC2.Model.InstanceStateChange")]
    [AWSCmdlet("Invokes the StopInstances or TerminateInstances operations on one or more EC2 instances.", Operation = new [] {"StopInstances", "TerminateInstances"})]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceStateChange",
                     "This cmdlet returns 0 or more Amazon.EC2.Model.InstanceStateChange instances.",
                     "The service response (type Amazon.EC2.Model.StopInstancesResponse or Amazon.EC2.Model.TerminateInstancesResponse) is added to the cmdlet entry in the $AWSHistory stack."
    )]
    public class StopEC2InstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        const string ParamSet_StopInstances = "StopInstancesParamSet";
        const string ParamSet_TerminateInstances = "TerminateInstancesParamSet";

        /// <summary>
        /// Identifies the set of instances to stop or terminate. Accepts a string instance ID 
        /// or a collection of RunningInstance or Reservation objects.
        /// If a Reservation object is supplied, all of the instances in the reservation are
        /// processed.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipeline=true)]
        public System.Object[] Instance { get; set; }

        /// <summary>
        /// Forces the instance to stop. The instance will not have an opportunity to flush file system caches nor file
        /// system meta data. If you use this option, you must perform file system check and repair procedures. This 
        /// option is not recommended for Windows instances.
        /// Note: this option is not compatible with the Terminate switch.
        /// </summary>
        [Parameter(ParameterSetName=ParamSet_StopInstances)]
        public SwitchParameter ForceStop { get; set; }

        /// <summary>
        /// Signals that the command should Terminate the instance, instead of just stopping it. If this
        /// option is specified, the cmdlet prompts for user confirmation unless the -Force switch is
        /// specified.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_TerminateInstances)]
        public SwitchParameter Terminate { get; set; }

        /// <summary>
        /// <para>
        /// If -Terminate is specified, the instance(s) specified are terminated with no further
        /// confirmation.
        /// </para>
        /// <para>
        /// If this is switch is not specified, the instance(s) are simply stopped and are thus
        /// available for restart. No confirmation is required to stop an instance.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_TerminateInstances)]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var instanceIds = AmazonEC2Helper.InstanceParamToIDs(this.Instance);

            var resourceIdentifiersText = string.Join(",", instanceIds.ToArray<string>());
            var operation = string.Format("Stop-EC2Instance ({0})", Terminate.IsPresent ? "TerminateInstances" : "StopInstances");
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, operation))
                return;

            var context = new CmdletContext
                              {
                                  Region = this.Region,
                                  Credentials = this.CurrentCredentials,
                                  InstanceIds = instanceIds,
                                  ForceStop = this.ForceStop,
                                  Terminate = this.Terminate
                              };

            // process standard parameters, if present

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            CmdletOutput output;

            if (cmdletContext.Terminate.GetValueOrDefault())
            {
                var request = new TerminateInstancesRequest {InstanceIds = cmdletContext.InstanceIds};
                var response = client.TerminateInstances(request);
                output = new CmdletOutput
                {
                    PipelineOutput = response.TerminatingInstances,
                    ServiceResponse = response,
                };
            }
            else
            {
                var request = new StopInstancesRequest {InstanceIds = cmdletContext.InstanceIds};
                if (cmdletContext.ForceStop != null)
                {
                    request.Force = cmdletContext.ForceStop.Value;
                }

                var response = client.StopInstances(request);
                output = new CmdletOutput
                {
                    PipelineOutput = response.StoppingInstances,
                    ServiceResponse = response,
                };
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
            public List<string> InstanceIds { get; set; }
            public Boolean? ForceStop { get; set; }
            public Boolean? Terminate { get; set; }
        }
        
    }
}
