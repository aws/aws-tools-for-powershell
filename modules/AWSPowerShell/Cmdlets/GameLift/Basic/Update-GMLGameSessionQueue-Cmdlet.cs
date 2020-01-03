/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    ///  <ul><li><para><a>CreateGameSessionQueue</a></para></li><li><para><a>DescribeGameSessionQueues</a></para></li><li><para><a>UpdateGameSessionQueue</a></para></li><li><para><a>DeleteGameSessionQueue</a></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "GMLGameSessionQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSessionQueue")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateGameSessionQueue API operation.", Operation = new[] {"UpdateGameSessionQueue"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateGameSessionQueueResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSessionQueue or Amazon.GameLift.Model.UpdateGameSessionQueueResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameSessionQueue object.",
        "The service call response (type Amazon.GameLift.Model.UpdateGameSessionQueueResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGMLGameSessionQueueCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>A list of fleets that can be used to fulfill game session placement requests in the
        /// queue. Fleets are identified by either a fleet ARN or a fleet alias ARN. Destinations
        /// are listed in default preference order. When updating this list, provide a complete
        /// list of destinations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destinations")]
        public Amazon.GameLift.Model.GameSessionQueueDestination[] Destination { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive label that is associated with game session queue. Queue names must be
        /// unique within each Region. You can use either the queue ID or ARN value. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PlayerLatencyPolicy
        /// <summary>
        /// <para>
        /// <para>A collection of latency policies to apply when processing game sessions placement
        /// requests with player latency information. Multiple policies are evaluated in order
        /// of the maximum latency value, starting with the lowest latency values. With just one
        /// policy, the policy is enforced at the start of the game session placement for the
        /// duration period. With multiple policies, each policy is enforced consecutively for
        /// its duration period. For example, a queue might enforce a 60-second policy followed
        /// by a 120-second policy, and then no policy for the remainder of the placement. When
        /// updating policies, provide a complete collection of policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlayerLatencyPolicies")]
        public Amazon.GameLift.Model.PlayerLatencyPolicy[] PlayerLatencyPolicy { get; set; }
        #endregion
        
        #region Parameter TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that a new game session placement request remains in
        /// the queue. When a request exceeds this time, the game session placement changes to
        /// a <code>TIMED_OUT</code> status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutInSeconds")]
        public System.Int32? TimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameSessionQueue'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateGameSessionQueueResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateGameSessionQueueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameSessionQueue";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLGameSessionQueue (UpdateGameSessionQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateGameSessionQueueResponse, UpdateGMLGameSessionQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.GameLift.Model.GameSessionQueueDestination>(this.Destination);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PlayerLatencyPolicy != null)
            {
                context.PlayerLatencyPolicy = new List<Amazon.GameLift.Model.PlayerLatencyPolicy>(this.PlayerLatencyPolicy);
            }
            context.TimeoutInSecond = this.TimeoutInSecond;
            
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
            
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PlayerLatencyPolicy != null)
            {
                request.PlayerLatencyPolicies = cmdletContext.PlayerLatencyPolicy;
            }
            if (cmdletContext.TimeoutInSecond != null)
            {
                request.TimeoutInSeconds = cmdletContext.TimeoutInSecond.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
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
        
        private Amazon.GameLift.Model.UpdateGameSessionQueueResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateGameSessionQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateGameSessionQueue");
            try
            {
                #if DESKTOP
                return client.UpdateGameSessionQueue(request);
                #elif CORECLR
                return client.UpdateGameSessionQueueAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.GameLift.Model.GameSessionQueueDestination> Destination { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.GameLift.Model.PlayerLatencyPolicy> PlayerLatencyPolicy { get; set; }
            public System.Int32? TimeoutInSecond { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateGameSessionQueueResponse, UpdateGMLGameSessionQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSessionQueue;
        }
        
    }
}
