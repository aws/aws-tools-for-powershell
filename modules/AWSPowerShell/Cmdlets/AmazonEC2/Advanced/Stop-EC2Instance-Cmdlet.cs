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
using Amazon.EC2;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// <para>
    /// Stops or terminates an Amazon EC2 instance.
    /// </para>
    /// <para>
    /// Instances that use Amazon EBS volumes as their root devices can be
    /// quickly stopped and started. When an instance is stopped, the compute resources are released and
    /// you are not billed for hourly instance usage. However, your root partition Amazon EBS volume remains,
    /// continues to persist your data, and you are charged for Amazon EBS volume usage. You can restart
    /// your instance at any time.
    /// </para>
    /// <para>
    /// <br/><br/>
    /// Before stopping an instance, make sure it is in a state from which it can be restarted. Stopping an 
    /// instance does not preserve data stored in RAM. Stopping an instance that uses an instance store as its
    /// root device returns an error.
    /// </para>
    /// <para>
    /// <br/><br/>
    /// The Terminate operation is idempotent; if you terminate an instance more than once, each call will succeed.
    /// Terminated instances will remain visible after termination (approximately one hour).
    /// </para>
    /// <para>
    /// <br/><br/>
    /// <b>Note: Terminating instances using this cmdlet is considered deprecated.</b> Please use the <b><i>Remove-EC2Instance</i></b> 
    /// cmdlet for instance termination as it supports confirmation prompts when a shell's $ConfirmPreference 
    /// setting is at its default value (High). The Stop-EC2Instance cmdlet is marked as medium impact (for backwards compatibility) 
    /// and will not therefore trigger a confirmation prompt for both stop <b>and</b> termination operations unless $ConfirmPreference
    /// is set to Medium or lower. This could lead to accidental termination of instances. Use of the -Terminate switch is maintained 
    /// for backwards compatibility only.
    /// </para>
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
        const string ParamSet_StopInstances = "StopInstances";
        const string ParamSet_TerminateInstances = "TerminateInstances";

        #region Parameter InstanceId
        /// <summary>
        /// Identifies the set of instances to stop or terminate. Accepts one or more string instance IDs,
        /// or collections of Amazon.EC2.Model.Instance or Amazon.EC2.Model.Reservation objects.
        /// If a Reservation object is supplied, all of the instances in the reservation are
        /// processed.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipeline=true)]
        public System.Object[] InstanceId { get; set; }
        #endregion

        #region Parameter ForceStop
        /// <summary>
        /// Forces the instance to stop. The instance will not have an opportunity to flush file system caches nor file
        /// system meta data. If you use this option, you must perform file system check and repair procedures. This 
        /// option is not recommended for Windows instances.
        /// Note: this option is not compatible with the Terminate switch.
        /// </summary>
        [Parameter(ParameterSetName=ParamSet_StopInstances)]
        public SwitchParameter ForceStop { get; set; }
        #endregion

        #region Parameter Terminate
        /// <summary>
        /// <para>
        /// Signals that the command should Terminate the instance(s) instead of just stopping them.
        /// </para>
        /// <para>
        /// <br/>
        /// <b>Note:</b> This parameter is deprecated and maintained solely for backwards compatibility. Please
        /// use the Remove-EC2Instance cmdlet for instance termination.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_TerminateInstances)]
        public SwitchParameter Terminate { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// Suppresses prompts for confirmation. Note that this cmdlet is marked as medium impact for backwards
        /// compatibility and therefore will only trigger a confirmation prompt if the shell's $ConfirmPreference 
        /// setting is Medium or lower, regardless of whether you are stopping or terminating instances.
        /// </summary>
        [Parameter(ParameterSetName = ParamSet_TerminateInstances)]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var instanceIds = AmazonEC2Helper.InstanceParamToIDs(this.InstanceId);

            var resourceIdentifiersText = string.Join(",", instanceIds.ToArray<string>());
            var operation = string.Format("Stop-EC2Instance ({0})", Terminate.IsPresent ? "TerminateInstances" : "StopInstances");
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, operation))
                return;

            if (ParameterWasBound("Terminate"))
                WriteWarning("The -Terminate parameter has been deprecated and may be removed in a future release. Please use the Remove-EC2Instance cmdlet to terminate instances.");

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
            CmdletOutput output;

            var client = Client ?? CreateClient(context.Credentials, context.Region);

            if (cmdletContext.Terminate.GetValueOrDefault())
            {
                var request = new TerminateInstancesRequest {InstanceIds = cmdletContext.InstanceIds};
                var response = CallAWSServiceOperation(client, request);
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

                var response = CallAWSServiceOperation(client, request);
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

        #region AWS Service Operation Call

        private Amazon.EC2.Model.StopInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.StopInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2", "StopInstances");
#if DESKTOP
            return client.StopInstances(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.StopInstancesAsync(request);
            return task.Result;
#else
#error "Unknown build edition"
#endif
        }

        private Amazon.EC2.Model.TerminateInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.TerminateInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2", "TerminateInstances");
#if DESKTOP
            return client.TerminateInstances(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.TerminateInstancesAsync(request);
            return task.Result;
#else
#error "Unknown build edition"
#endif
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
