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
using Amazon.Runtime;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /* not yet ready for release
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

        private DateTime? _lastPollTime;

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
                try
                {
                    Execute(context);

                    if (TestCFNStackCmdlet.IsStackInState(Client, context.StackName, context.Status, true))
                    {
                        WriteVerbose("Stack reached requested state, exiting poll loop");
                        break;
                    }

                    WriteVerbose(string.Format("...stack not in desired state, sleeping for {0} seconds before next event poll", context.Interval));
                    Thread.Sleep(context.Interval * 1000);
                }
                catch (Exception)
                {
                    // ...of course we don't know from the error cfn gives us if this is truly
                    // delete completed, or 'stack doesn't exist because you have wrong name/not yours'
                    // scenario
                    if (context.Status.Contains(StackStatus.DELETE_COMPLETE))
                    {
                        WriteVerbose("...status test on stack threw exception, assuming stack has reached termination as states to test included 'DELETE_COMPLETE'.");
                        // cannot send exception back in output object here, as it will
                        // stop the pipeline with an error
                        ProcessOutput(new CmdletOutput());
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var request = new DescribeStackEventsRequest {StackName = cmdletContext.StackName};

            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                if (_lastPollTime != null)
                {
                    WriteVerbose("...polling for events on stack since " + _lastPollTime.Value.ToString("u"));
                }
                else
                {
                    WriteVerbose("...polling for events on stack");     
                }

                var lastPollTime = _lastPollTime;
                _lastPollTime = DateTime.UtcNow;

                var response = CallAWSServiceOperation(client, request);

                var events = lastPollTime == null 
                    ? response.StackEvents
                    : response.StackEvents.Where(e => e.Timestamp.ToUniversalTime() > lastPollTime).ToList();

                Console.WriteLine("Captured last poll time at {0}", _lastPollTime.Value.ToString("u"));
                Console.WriteLine("Emitting {0} events", events.Count);

                WriteObject(events, true);
            }
            catch (Exception e)
            {
                var errorMsg = "Error polling for stack events";
                if (e.InnerException != null)
                    errorMsg += ": " + e.InnerException.Message;
                ThrowExecutionError(errorMsg, this, e);
            }

            return null;
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

            try
            {
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
            public System.String StackName { get; set; }
            public HashSet<StackStatus> Status { get; set; }
            public int Interval { get; set; }
        }

    }
    */
}
