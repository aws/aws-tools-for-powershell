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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates or updates a destination. A destination encapsulates a physical resource (such
    /// as an Amazon Kinesis stream) and enables you to subscribe to a real-time stream of
    /// log events for a different account, ingested using <a>PutLogEvents</a>. Currently,
    /// the only supported physical resource is a Kinesis stream belonging to the same account
    /// as the destination.
    /// 
    ///  
    /// <para>
    /// Through an access policy, a destination controls what is written to its Kinesis stream.
    /// By default, <code>PutDestination</code> does not set any access policy with the destination,
    /// which means a cross-account user cannot call <a>PutSubscriptionFilter</a> against
    /// this destination. To enable this, the destination owner must call <a>PutDestinationPolicy</a>
    /// after <code>PutDestination</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.Destination")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutDestination API operation.", Operation = new[] {"PutDestination"})]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.Destination",
        "This cmdlet returns a Destination object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.PutDestinationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWLDestinationCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter DestinationName
        /// <summary>
        /// <para>
        /// <para>A name for the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DestinationName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that grants CloudWatch Logs permissions to call the Amazon
        /// Kinesis PutRecord operation on the destination stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an Amazon Kinesis stream to which to deliver matching log events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DestinationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLDestination (PutDestination)"))
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
            
            context.DestinationName = this.DestinationName;
            context.RoleArn = this.RoleArn;
            context.TargetArn = this.TargetArn;
            
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
            var request = new Amazon.CloudWatchLogs.Model.PutDestinationRequest();
            
            if (cmdletContext.DestinationName != null)
            {
                request.DestinationName = cmdletContext.DestinationName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Destination;
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
        
        private Amazon.CloudWatchLogs.Model.PutDestinationResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutDestination");
            try
            {
                #if DESKTOP
                return client.PutDestination(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutDestinationAsync(request);
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
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String DestinationName { get; set; }
            public System.String RoleArn { get; set; }
            public System.String TargetArn { get; set; }
        }
        
    }
}
