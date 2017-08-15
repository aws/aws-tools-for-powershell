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
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;
using Amazon.Runtime;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Tests a CloudFormation stack to determine if it's in a certain status.
    /// The command returns true or false, depending on whether or not the specified stack is in a given status.
    /// </summary>
    [Cmdlet("Test", "CFNStack")]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Tests the status of a stack using the DescribeStacks API operation to retrieve the stack's status.", Operation = new[] { "DescribeStacks" })]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean value.",
        "The service call response (type Amazon.CloudFormation.Model.DescribeStacksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestCFNStackCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        internal static HashSet<StackStatus> DefaultCompletionStates = new HashSet<StackStatus>(new StackStatusComparer())
        {
            StackStatus.UPDATE_ROLLBACK_COMPLETE,
            StackStatus.CREATE_COMPLETE,
            StackStatus.ROLLBACK_COMPLETE,
            StackStatus.UPDATE_COMPLETE
        };

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
                ? new HashSet<StackStatus>(Status, new StackStatusComparer()) 
                : DefaultCompletionStates;

            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            CmdletOutput output;

            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                WriteVerbose(string.Format("Testing stack {0} in region {1} is in state(s): {2}", 
                                           cmdletContext.StackName, 
                                           cmdletContext.Region.SystemName, 
                                           StateSetToFormattedString(cmdletContext.Status)));

                output = new CmdletOutput
                {
                    PipelineOutput = IsStackInState(client, cmdletContext.StackName, cmdletContext.Status, false)
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

        internal static bool IsStackInState(IAmazonCloudFormation client, string stackName, HashSet<StackStatus> desiredStates, bool throwOnError)
        {
            try
            {
                var request = new DescribeStacksRequest { StackName = stackName };

#if DESKTOP
                var response = client.DescribeStacks(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeStacksAsync(request);
            var response = task.Result;
#else
#error "Unknown build edition"
#endif

                return IsStackInState(response.Stacks[0].StackStatus, desiredStates);
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
            catch (Exception)
            {
                if (throwOnError)
                    throw;
            }

            return false;
        }

        internal static bool IsStackInState(StackStatus status, HashSet<StackStatus> desiredStates)
        {
            return desiredStates.Contains(status);
        }

        internal static string StateSetToFormattedString(IEnumerable<StackStatus> states)
        {
            if (states == null)
                throw new ArgumentNullException("states");

            var sb = new StringBuilder();
            foreach (var s in states)
            {
                if (sb.Length > 0)
                    sb.Append(",");
                sb.Append(s);
            }

            return sb.ToString();
        }

        internal class CmdletContext : ExecutorContext
        {
            public System.String StackName { get; set; }
            public HashSet<StackStatus> Status { get; set; }
        }

        internal class StackStatusComparer : IEqualityComparer<StackStatus>
        {
            public bool Equals(StackStatus x, StackStatus y)
            {
                return string.Compare(x, y, StringComparison.OrdinalIgnoreCase) == 0;
            }

            public int GetHashCode(StackStatus obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
