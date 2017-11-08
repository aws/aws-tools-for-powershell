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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Updates settings for a game session queue, which determines how new game session requests
    /// in the queue are processed. To update settings, specify the queue name to be updated
    /// and provide the new settings. When updating destinations, provide a complete list
    /// of destinations. 
    /// 
    ///  
    /// <para>
    /// Queue-related operations include:
    /// </para><ul><li><para><a>CreateGameSessionQueue</a></para></li><li><para><a>DescribeGameSessionQueues</a></para></li><li><para><a>UpdateGameSessionQueue</a></para></li><li><para><a>DeleteGameSessionQueue</a></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "GMLGameSessionQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSessionQueue")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateGameSessionQueue API operation.", Operation = new[] {"UpdateGameSessionQueue"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSessionQueue",
        "This cmdlet returns a GameSessionQueue object.",
        "The service call response (type Amazon.GameLift.Model.UpdateGameSessionQueueResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGMLGameSessionQueueCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>List of fleets that can be used to fulfill game session placement requests in the
        /// queue. Fleets are identified by either a fleet ARN or a fleet alias ARN. Destinations
        /// are listed in default preference order. When updating this list, provide a complete
        /// list of destinations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Destinations")]
        public Amazon.GameLift.Model.GameSessionQueueDestination[] Destination { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label that is associated with game session queue. Queue names must be
        /// unique within each region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PlayerLatencyPolicy
        /// <summary>
        /// <para>
        /// <para>Collection of latency policies to apply when processing game sessions placement requests
        /// with player latency information. Multiple policies are evaluated in order of the maximum
        /// latency value, starting with the lowest latency values. With just one policy, it is
        /// enforced at the start of the game session placement for the duration period. With
        /// multiple policies, each policy is enforced consecutively for its duration period.
        /// For example, a queue might enforce a 60-second policy followed by a 120-second policy,
        /// and then no policy for the remainder of the placement. When updating policies, provide
        /// a complete collection of policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PlayerLatencyPolicies")]
        public Amazon.GameLift.Model.PlayerLatencyPolicy[] PlayerLatencyPolicy { get; set; }
        #endregion
        
        #region Parameter TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>Maximum time, in seconds, that a new game session placement request remains in the
        /// queue. When a request exceeds this time, the game session placement changes to a <code>TIMED_OUT</code>
        /// status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TimeoutInSeconds")]
        public System.Int32 TimeoutInSecond { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLGameSessionQueue (UpdateGameSessionQueue)"))
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
            
            if (this.Destination != null)
            {
                context.Destinations = new List<Amazon.GameLift.Model.GameSessionQueueDestination>(this.Destination);
            }
            context.Name = this.Name;
            if (this.PlayerLatencyPolicy != null)
            {
                context.PlayerLatencyPolicies = new List<Amazon.GameLift.Model.PlayerLatencyPolicy>(this.PlayerLatencyPolicy);
            }
            if (ParameterWasBound("TimeoutInSecond"))
                context.TimeoutInSeconds = this.TimeoutInSecond;
            
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
            var request = new Amazon.GameLift.Model.UpdateGameSessionQueueRequest();
            
            if (cmdletContext.Destinations != null)
            {
                request.Destinations = cmdletContext.Destinations;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PlayerLatencyPolicies != null)
            {
                request.PlayerLatencyPolicies = cmdletContext.PlayerLatencyPolicies;
            }
            if (cmdletContext.TimeoutInSeconds != null)
            {
                request.TimeoutInSeconds = cmdletContext.TimeoutInSeconds.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GameSessionQueue;
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
        
        private Amazon.GameLift.Model.UpdateGameSessionQueueResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateGameSessionQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateGameSessionQueue");
            try
            {
                #if DESKTOP
                return client.UpdateGameSessionQueue(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateGameSessionQueueAsync(request);
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
            public List<Amazon.GameLift.Model.GameSessionQueueDestination> Destinations { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.GameLift.Model.PlayerLatencyPolicy> PlayerLatencyPolicies { get; set; }
            public System.Int32? TimeoutInSeconds { get; set; }
        }
        
    }
}
