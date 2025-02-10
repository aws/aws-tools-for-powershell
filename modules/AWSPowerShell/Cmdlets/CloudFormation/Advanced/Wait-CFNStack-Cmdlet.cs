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
using System.Threading;
using Amazon.PowerShell.Common;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Pauses execution of the script until the desired CloudFormation Stack status has been reached
    /// or timeout occurs.
    /// </summary>
    [Cmdlet("Wait", "CFNStack")]
    [OutputType("Amazon.CloudFormation.Model.Stack", "None")]
    [AWSCmdlet("Pauses execution of a script until a stack reaches a specified status or timeout occurs. The DescribeStacks API is used to obtain the status of the stack.", Operation = new[] { "DescribeStacks" })]
    [AWSCmdletOutput("None or Amazon.CloudFormation.Model.Stack",
        "If the stack exists when one of the requested states is reached the cmdlet returns an Amazon.CloudFormation.Model.Stack object, otherwise it returns nothing.",
        "The service call response (type Amazon.CloudFormation.Model.DescribeStacksResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WaitCFNStackCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        private const int DefaultTimeoutInSeconds = 120;
        private const int PollSleepInSeconds = 2;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();


        #region Parameter StackName
        /// <summary>
        /// The name or unique stack ID of the of the CloudFormation stack whose status will be monitored.
        /// </summary>
        [System.Management.Automation.Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// <para>If the set of states contains 'DELETE_COMPLETE' the cmdlet will wait for the underlying
        /// DescribeStacks API call to return an error indicating the stack no longer exists before 
        /// exiting. No output is emitted to the pipeline in this scenario.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.StackStatus")]
        public Amazon.CloudFormation.StackStatus[] Status { get; set; }
        #endregion

        #region Parameter Timeout
        /// <summary>
        /// The number of seconds that the command should run for before timing out and throwing an exception.
        /// If not specified the command waits for 120 seconds.
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

        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            _cmdletContext = new CmdletContext();

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
                                       _RegionEndpoint.SystemName,
                                       TestCFNStackCmdlet.StateSetToFormattedString(_cmdletContext.Status)));

            while (true)
            {
                // if the user specified DELETE_COMPLETE then we are in fact watching for the
                // stack to disappear (and an exception to be thrown from DescribeStacks)...
                try
                {
                    var output = Execute(_cmdletContext) as CmdletOutput;
                    if (output != null)
                    {
                        if (output.PipelineOutput != null)
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
                        else if (output.ErrorResponse != null)
                            throw new Exception(output.ErrorResponse.Message);
                    }

                    var now = DateTime.UtcNow;
                    if ((now - _startTime).TotalSeconds > _cmdletContext.Timeout)
                    {
                        var err = string.Format("Stack did not reach one of expected states {0} after {1} seconds waiting. Abandoning execution.\nUse the -Timeout parameter to extend the waiting time if needed.",
                                                TestCFNStackCmdlet.StateSetToFormattedString(_cmdletContext.Status),
                                                _cmdletContext.Timeout);
                        ThrowExecutionError(err, this);
                    }

                    WriteVerbose(string.Format("...sleeping for {0} seconds before re-testing status", PollSleepInSeconds));
                    Thread.Sleep(PollSleepInSeconds * 1000);
                }
                catch (Exception e)
                {
                    // ...of course we don't know from the error cfn gives us if this is truly
                    // delete completed, or 'stack doesn't exist because you have wrong name/not yours'
                    // scenario
                    if (_cmdletContext.Status.Contains(StackStatus.DELETE_COMPLETE) && e.Message.Contains("does not exist"))
                    {
                        WriteVerbose("Status query on stack threw exception indicating stack does not exist");
                        WriteVerbose("Assuming stack has reached termination as states to test included 'DELETE_COMPLETE'.");
                        // cannot send exception back in output object here, as it will
                        // stop the pipeline with an error
                        ProcessOutput(new CmdletOutput());
                        break;
                    }

                    throw;
                }
            }

            base.EndProcessing();
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new DescribeStacksRequest {StackName = cmdletContext.StackName};

            CmdletOutput output;

            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                var stack = response.Stacks.FirstOrDefault();
                WriteVerbose("DescribeStacks query on stack yielded current status " + stack.StackStatus);
                output = new CmdletOutput
                {
                    PipelineOutput = stack,
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

            try
            {
                return client.DescribeStacksAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public int Timeout { get; set; }
        }
    }
}
