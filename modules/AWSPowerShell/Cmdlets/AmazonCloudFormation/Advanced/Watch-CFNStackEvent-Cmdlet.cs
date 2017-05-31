/*******************************************************************************
 *  Copyright 2012-2017 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.PowerShell.Common;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Pauses execution of the script until the desired CloudFormation Stack status has been reached and prints 
    /// out new events while waiting.
    /// </summary>
    [Cmdlet("Watch", "CFNStackEvent")]
    [OutputType("Amazon.CloudFormation.Model.StackEvent")]
    [AWSCmdlet("Pauses execution of a script until a stack reaches a specified status, printing out stack events while waiting. The DescribeStacks and DescribeStackEvents APIs are used to obtain the status of the stack.", Operation = new[] { "DescribeStacks", "DescribeStackEvents" })]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.StackEvent",
        "This cmdlet outputs the collection of events received while waiting for the stack to reach the required state.",
        "The service call response (type Amazon.CloudFormation.Model.DescribeStacksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WatchCFNStackEventCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        private const int DefaultIntervalInSeconds = 5;

        #region Parameter StackName
        /// <summary>
        /// The name or unique stack ID of the of the CloudFormation stack whose status will be monitored.
        /// </summary>
        [System.Management.Automation.Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackName { get; set; }
        #endregion

        #region Parameter Status
        /// <summary>
        /// <para>
        /// The CloudFormation status. You can tab-complete the values for this parameter or view a list of all
        /// supported CloudFormation status types in the AWS documentation: https://goo.gl/cpSu29.
        /// </para>
        /// <para>
        /// If not specified the command checks the stack's status against the states 
        /// 'UPDATE_ROLLBACK_COMPLETE', 'CREATE_COMPLETE', 'ROLLBACK_COMPLETE' and 'UPDATE_COMPLETE'.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.StackStatus")]
        public Amazon.CloudFormation.StackStatus[] Status { get; set; }
        #endregion

        #region Interval
        /// <summary>
        /// The interval to pause, in seconds, between requests to obtain the stack's status
        /// and latest events.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public int Interval { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var context = new CmdletContext
            {
                Region = Region,
                Credentials = CurrentCredentials
            };

            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);

            context.StackName = StackName;
            context.Status = ParameterWasBound("Status")
                ? new HashSet<StackStatus>(Status, new TestCFNStackCmdlet.StackStatusComparer())
                : TestCFNStackCmdlet.DefaultCompletionStates;
            context.Interval = ParameterWasBound("Interval") ? Interval : DefaultIntervalInSeconds;

            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);

            WriteVerbose(string.Format("Watching stack {0} in region {1} to reach one of state(s): {2}",
                                       context.StackName,
                                       context.Region.SystemName,
                                       TestCFNStackCmdlet.StateSetToFormattedString(context.Status)));

            while (true)
            {
                var output = Execute(context) as CmdletOutput;
                ProcessOutput(output);

                if (TestCFNStackCmdlet.IsStackInState(Client, context.StackName, context.Status))
                    break;

                WriteVerbose(string.Format("Stack not in desired state, sleeping for {0} seconds", context.Interval));
                Thread.Sleep(context.Interval * 1000);
            }
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var request = new DescribeStackEventsRequest {StackName = cmdletContext.StackName};
            CmdletOutput output;

            var now = DateTime.UtcNow;
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                WriteVerbose("Polling for fresh events on stack");
                var response = CallAWSServiceOperation(client, request);

                var events = response.StackEvents.Where(e => (now - e.Timestamp.ToUniversalTime()).TotalSeconds < cmdletContext.Interval).ToList();
                output = new CmdletOutput
                {
                    PipelineOutput = events,
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

        private Amazon.CloudFormation.Model.DescribeStackEventsResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DescribeStackEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DescribeStackEvents");
#if DESKTOP
            return client.DescribeStackEvents(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeStackEventsAsync(request);
            return task.Result;
#else
#error "Unknown build edition"
#endif
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public System.String StackName { get; set; }
            public HashSet<StackStatus> Status { get; set; }
            public int Interval { get; set; }
        }

    }
}
