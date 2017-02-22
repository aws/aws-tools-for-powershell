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
    /// Establishes a new queue for processing requests for new game sessions. A queue identifies
    /// where new game sessions can be hosted--by specifying a list of fleet destinations--and
    /// how long a request can remain in the queue waiting to be placed before timing out.
    /// Requests for new game sessions are added to a queue by calling <a>StartGameSessionPlacement</a>
    /// and referencing the queue name.
    /// 
    ///  
    /// <para>
    /// When processing a request for a game session, Amazon GameLift tries each destination
    /// in order until it finds one with available resources to host the new game session.
    /// A queue's default order is determined by how destinations are listed. This default
    /// order can be overridden in a game session placement request.
    /// </para><para>
    /// To create a new queue, provide a name, timeout value, and a list of destinations.
    /// If successful, a new queue object is returned.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GMLGameSessionQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSessionQueue")]
    [AWSCmdlet("Invokes the CreateGameSessionQueue operation against Amazon GameLift Service.", Operation = new[] {"CreateGameSessionQueue"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSessionQueue",
        "This cmdlet returns a GameSessionQueue object.",
        "The service call response (type Amazon.GameLift.Model.CreateGameSessionQueueResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLGameSessionQueueCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>List of fleets that can be used to fulfill game session placement requests in the
        /// queue. Fleets are identified by either a fleet ARN or a fleet alias ARN. Destinations
        /// are listed in default preference order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Destinations")]
        public Amazon.GameLift.Model.GameSessionQueueDestination[] Destination { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label that is associated with queue. Queue names must be unique within
        /// each region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>Maximum time, in seconds, that a new game session placement request remains in the
        /// queue. When a request exceeds this time, the game session placement changes to a TIMED_OUT
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLGameSessionQueue (CreateGameSessionQueue)"))
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
            var request = new Amazon.GameLift.Model.CreateGameSessionQueueRequest();
            
            if (cmdletContext.Destinations != null)
            {
                request.Destinations = cmdletContext.Destinations;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private static Amazon.GameLift.Model.CreateGameSessionQueueResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateGameSessionQueueRequest request)
        {
            #if DESKTOP
            return client.CreateGameSessionQueue(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateGameSessionQueueAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.GameLift.Model.GameSessionQueueDestination> Destinations { get; set; }
            public System.String Name { get; set; }
            public System.Int32? TimeoutInSeconds { get; set; }
        }
        
    }
}
