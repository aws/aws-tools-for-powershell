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
using System.Text;
using System.Threading;
using Amazon.PowerShell.Common;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Pauses execution of the script until the desired CloudFormation Stack status has been reached
    /// or timeout occurs.
    /// </summary>
    [Cmdlet("Wait", "CFNStack")]
    [OutputType("Amazon.CloudFormation.Model.Stack")]
    [AWSCmdlet("Pauses execution of a script until a stack reaches a specified status or timeout occurs. The DescribeStacks API is used to obtain the status of the stack.", Operation = new[] { "DescribeStacks" })]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.Stack",
        "This cmdlet returns an Amazon.CloudFormation.Model.Stack object.",
        "The service call response (type Amazon.CloudFormation.Model.DescribeStacksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WaitCFNStackCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        private const int DefaultTimeoutInSeconds = 60;
        private const int PollSleepInSeconds = 2;

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

        #region Parameter Timeout
        /// <summary>
        /// The number of seconds that the command should run for before timing out and throwing an exception.
        /// If not specified the command waits for 60 seconds.
        /// </summary>
        [System.Management.Automation.Parameter]
        public int Timeout { get; set; }
        #endregion

        private CmdletContext _cmdletContext;
        private DateTime _startTime;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            _startTime = DateTime.UtcNow;
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            _cmdletContext = new CmdletContext
            {
                Region = Region,
                Credentials = CurrentCredentials
            };

            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(_cmdletContext);

            _cmdletContext.StackName = StackName;
            _cmdletContext.Status = ParameterWasBound("Status")
                ? new HashSet<StackStatus>(Status, new TestCFNStackCmdlet.StackStatusComparer())
                : TestCFNStackCmdlet.DefaultCompletionStates;
            _cmdletContext.Timeout = ParameterWasBound("Timeout") ? Timeout : DefaultTimeoutInSeconds;

            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(_cmdletContext);
        }

        protected override void EndProcessing()
        {
            WriteVerbose(string.Format("Waiting for {0} seconds for stack {1} in region {2} to reach one of state(s): {3}",
                                       _cmdletContext.Timeout,
                                       _cmdletContext.StackName,
                                       _cmdletContext.Region.SystemName,
                                       TestCFNStackCmdlet.StateSetToFormattedString(_cmdletContext.Status)));

            while (true)
            {
                var output = Execute(_cmdletContext) as CmdletOutput;
                if (output != null)
                {
                    var stack = output.PipelineOutput as Stack;
                    if (stack != null)
                    {
                        if (TestCFNStackCmdlet.IsStackInState(stack.StackStatus, _cmdletContext.Status))
                        {
                            ProcessOutput(output);
                            break;
                        }
                    }
                }

                var now = DateTime.UtcNow;
                if ((now - _startTime).TotalSeconds > _cmdletContext.Timeout)
                {
                    var err = string.Format("Timed out after {0} seconds waiting for CloudFormation stack {1} in region {2} to reach one of state(s): {3}",
                                             _cmdletContext.Timeout,
                                             _cmdletContext.StackName, 
                                             _cmdletContext.Region.SystemName, 
                                             TestCFNStackCmdlet.StateSetToFormattedString(_cmdletContext.Status));
                    ThrowExecutionError(err, this);
                }

                WriteVerbose(string.Format("Sleeping for {0} seconds", PollSleepInSeconds));
                Thread.Sleep(PollSleepInSeconds * 1000);
            }

            base.EndProcessing();
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new DescribeStacksRequest {StackName = cmdletContext.StackName};

            CmdletOutput output;

            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                output = new CmdletOutput
                {
                    PipelineOutput = response.Stacks.FirstOrDefault(),
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

        private Amazon.CloudFormation.Model.DescribeStacksResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DescribeStacksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DescribeStacks");
#if DESKTOP
            return client.DescribeStacks(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeStacksAsync(request);
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
            public int Timeout { get; set; }
        }
    }
}
