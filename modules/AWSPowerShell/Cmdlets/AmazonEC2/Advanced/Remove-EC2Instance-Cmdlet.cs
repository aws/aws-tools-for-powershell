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
using Amazon.Runtime;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// <para>
    /// Terminates a stopped or running Amazon EC2 instance, prompting for confirmation before proceeding.
    /// </para>
    /// <para>
    /// <br/><br/>
    /// Note that terminated instances will remain visible after termination (for approximately one hour).
    /// The Terminate operation is idempotent; if you terminate an instance more than once, each call will succeed.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "EC2Instance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.InstanceStateChange")]
    [AWSCmdlet("Invokes the TerminateInstances operations on one or more EC2 instances.", Operation = new [] {"TerminateInstances"})]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceStateChange",
                     "This cmdlet returns 0 or more Amazon.EC2.Model.InstanceStateChange instances.",
                     "The service response (type Amazon.EC2.Model.TerminateInstancesResponse) is added to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveEC2InstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
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

        #region Parameter Force
        /// <summary>
        /// Suppresses prompts for confirmation before proceeding to terminate the specified instance(s).
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var instanceIds = AmazonEC2Helper.InstanceParamToIDs(this.InstanceId);

            var resourceIdentifiersText = string.Join(",", instanceIds.ToArray<string>());
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2Instance (TerminateInstances)"))
                return;

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                InstanceIds = instanceIds
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

            var request = new TerminateInstancesRequest {InstanceIds = cmdletContext.InstanceIds};
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            var response = CallAWSServiceOperation(client, request);
            output = new CmdletOutput
            {
                PipelineOutput = response.TerminatingInstances,
                ServiceResponse = response,
            };

            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private Amazon.EC2.Model.TerminateInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.TerminateInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2", "TerminateInstances");

            try
            {
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

        internal class CmdletContext : ExecutorContext
        {
            public List<string> InstanceIds { get; set; }
        }
        
    }
}
