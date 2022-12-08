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
    /// Creates a placement queue that processes requests for new game sessions. A queue uses
    /// FleetIQ algorithms to determine the best placement locations and find an available
    /// game server there, then prompts the game server process to start a new game session.
    /// 
    /// 
    ///  
    /// <para>
    /// A game session queue is configured with a set of destinations (GameLift fleets or
    /// aliases), which determine the locations where the queue can place new game sessions.
    /// These destinations can span multiple fleet types (Spot and On-Demand), instance types,
    /// and Amazon Web Services Regions. If the queue includes multi-location fleets, the
    /// queue is able to place game sessions in all of a fleet's remote locations. You can
    /// opt to filter out individual locations if needed.
    /// </para><para>
    /// The queue configuration also determines how FleetIQ selects the best available placement
    /// for a new game session. Before searching for an available game server, FleetIQ first
    /// prioritizes the queue's destinations and locations, with the best placement locations
    /// on top. You can set up the queue to use the FleetIQ default prioritization or provide
    /// an alternate set of priorities.
    /// </para><para>
    /// To create a new queue, provide a name, timeout value, and a list of destinations.
    /// Optionally, specify a sort configuration and/or a filter, and define a set of latency
    /// cap policies. You can also include the ARN for an Amazon Simple Notification Service
    /// (SNS) topic to receive notifications of game session placement activity. Notifications
    /// using SNS or CloudWatch events is the preferred way to track placement activity.
    /// </para><para>
    /// If successful, a new <code>GameSessionQueue</code> object is returned with an assigned
    /// queue ARN. New game session requests, which are submitted to queue with <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_StartGameSessionPlacement.html">StartGameSessionPlacement</a>
    /// or <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_StartMatchmaking.html">StartMatchmaking</a>,
    /// reference a queue's name or ARN. 
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/queues-design.html">
    /// Design a game session queue</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/queues-creating.html">
    /// Create a game session queue</a></para><para><b>Related actions</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_CreateGameSessionQueue.html">CreateGameSessionQueue</a>
    /// | <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeGameSessionQueues.html">DescribeGameSessionQueues</a>
    /// | <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_UpdateGameSessionQueue.html">UpdateGameSessionQueue</a>
    /// | <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DeleteGameSessionQueue.html">DeleteGameSessionQueue</a>
    /// | <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-awssdk.html#reference-awssdk-resources-fleets">All
    /// APIs by task</a></para>
    /// </summary>
    [Cmdlet("New", "GMLGameSessionQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSessionQueue")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateGameSessionQueue API operation.", Operation = new[] {"CreateGameSessionQueue"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateGameSessionQueueResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSessionQueue or Amazon.GameLift.Model.CreateGameSessionQueueResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameSessionQueue object.",
        "The service call response (type Amazon.GameLift.Model.CreateGameSessionQueueResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLGameSessionQueueCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter FilterConfiguration_AllowedLocation
        /// <summary>
        /// <para>
        /// <para> A list of locations to allow game session placement in, in the form of Amazon Web
        /// Services Region codes such as <code>us-west-2</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterConfiguration_AllowedLocations")]
        public System.String[] FilterConfiguration_AllowedLocation { get; set; }
        #endregion
        
        #region Parameter CustomEventData
        /// <summary>
        /// <para>
        /// <para>Information to be added to all events that are related to this game session queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomEventData { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>A list of fleets and/or fleet aliases that can be used to fulfill game session placement
        /// requests in the queue. Destinations are identified by either a fleet ARN or a fleet
        /// alias ARN, and are listed in order of placement preference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destinations")]
        public Amazon.GameLift.Model.GameSessionQueueDestination[] Destination { get; set; }
        #endregion
        
        #region Parameter PriorityConfiguration_LocationOrder
        /// <summary>
        /// <para>
        /// <para>The prioritization order to use for fleet locations, when the <code>PriorityOrder</code>
        /// property includes <code>LOCATION</code>. Locations are identified by Amazon Web Services
        /// Region codes such as <code>us-west-2</code>. Each location can only be listed once.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PriorityConfiguration_LocationOrder { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive label that is associated with game session queue. Queue names must be
        /// unique within each Region.</para>
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
        
        #region Parameter NotificationTarget
        /// <summary>
        /// <para>
        /// <para>An SNS topic ARN that is set up to receive game session placement notifications. See
        /// <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/queue-notification.html">
        /// Setting up notifications for game session placement</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationTarget { get; set; }
        #endregion
        
        #region Parameter PlayerLatencyPolicy
        /// <summary>
        /// <para>
        /// <para>A set of policies that act as a sliding cap on player latency. FleetIQ works to deliver
        /// low latency for most players in a game session. These policies ensure that no individual
        /// player can be placed into a game with unreasonably high latency. Use multiple policies
        /// to gradually relax latency requirements a step at a time. Multiple policies are applied
        /// based on their maximum allowed latency, starting with the lowest value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlayerLatencyPolicies")]
        public Amazon.GameLift.Model.PlayerLatencyPolicy[] PlayerLatencyPolicy { get; set; }
        #endregion
        
        #region Parameter PriorityConfiguration_PriorityOrder
        /// <summary>
        /// <para>
        /// <para>The recommended sequence to use when prioritizing where to place new game sessions.
        /// Each type can only be listed once.</para><ul><li><para><code>LATENCY</code> -- FleetIQ prioritizes locations where the average player latency
        /// (provided in each game session request) is lowest. </para></li><li><para><code>COST</code> -- FleetIQ prioritizes destinations with the lowest current hosting
        /// costs. Cost is evaluated based on the location, instance type, and fleet type (Spot
        /// or On-Demand) for each destination in the queue.</para></li><li><para><code>DESTINATION</code> -- FleetIQ prioritizes based on the order that destinations
        /// are listed in the queue configuration.</para></li><li><para><code>LOCATION</code> -- FleetIQ prioritizes based on the provided order of locations,
        /// as defined in <code>LocationOrder</code>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PriorityConfiguration_PriorityOrder { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of labels to assign to the new game session queue resource. Tags are developer-defined
        /// key-value pairs. Tagging Amazon Web Services resources are useful for resource management,
        /// access management and cost allocation. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">
        /// Tagging Amazon Web Services Resources</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.GameLift.Model.Tag[] Tag { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.CreateGameSessionQueueResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.CreateGameSessionQueueResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLGameSessionQueue (CreateGameSessionQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.CreateGameSessionQueueResponse, NewGMLGameSessionQueueCmdlet>(Select) ??
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
            context.CustomEventData = this.CustomEventData;
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.GameLift.Model.GameSessionQueueDestination>(this.Destination);
            }
            if (this.FilterConfiguration_AllowedLocation != null)
            {
                context.FilterConfiguration_AllowedLocation = new List<System.String>(this.FilterConfiguration_AllowedLocation);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationTarget = this.NotificationTarget;
            if (this.PlayerLatencyPolicy != null)
            {
                context.PlayerLatencyPolicy = new List<Amazon.GameLift.Model.PlayerLatencyPolicy>(this.PlayerLatencyPolicy);
            }
            if (this.PriorityConfiguration_LocationOrder != null)
            {
                context.PriorityConfiguration_LocationOrder = new List<System.String>(this.PriorityConfiguration_LocationOrder);
            }
            if (this.PriorityConfiguration_PriorityOrder != null)
            {
                context.PriorityConfiguration_PriorityOrder = new List<System.String>(this.PriorityConfiguration_PriorityOrder);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.GameLift.Model.Tag>(this.Tag);
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
            var request = new Amazon.GameLift.Model.CreateGameSessionQueueRequest();
            
            if (cmdletContext.CustomEventData != null)
            {
                request.CustomEventData = cmdletContext.CustomEventData;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            
             // populate FilterConfiguration
            var requestFilterConfigurationIsNull = true;
            request.FilterConfiguration = new Amazon.GameLift.Model.FilterConfiguration();
            List<System.String> requestFilterConfiguration_filterConfiguration_AllowedLocation = null;
            if (cmdletContext.FilterConfiguration_AllowedLocation != null)
            {
                requestFilterConfiguration_filterConfiguration_AllowedLocation = cmdletContext.FilterConfiguration_AllowedLocation;
            }
            if (requestFilterConfiguration_filterConfiguration_AllowedLocation != null)
            {
                request.FilterConfiguration.AllowedLocations = requestFilterConfiguration_filterConfiguration_AllowedLocation;
                requestFilterConfigurationIsNull = false;
            }
             // determine if request.FilterConfiguration should be set to null
            if (requestFilterConfigurationIsNull)
            {
                request.FilterConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NotificationTarget != null)
            {
                request.NotificationTarget = cmdletContext.NotificationTarget;
            }
            if (cmdletContext.PlayerLatencyPolicy != null)
            {
                request.PlayerLatencyPolicies = cmdletContext.PlayerLatencyPolicy;
            }
            
             // populate PriorityConfiguration
            var requestPriorityConfigurationIsNull = true;
            request.PriorityConfiguration = new Amazon.GameLift.Model.PriorityConfiguration();
            List<System.String> requestPriorityConfiguration_priorityConfiguration_LocationOrder = null;
            if (cmdletContext.PriorityConfiguration_LocationOrder != null)
            {
                requestPriorityConfiguration_priorityConfiguration_LocationOrder = cmdletContext.PriorityConfiguration_LocationOrder;
            }
            if (requestPriorityConfiguration_priorityConfiguration_LocationOrder != null)
            {
                request.PriorityConfiguration.LocationOrder = requestPriorityConfiguration_priorityConfiguration_LocationOrder;
                requestPriorityConfigurationIsNull = false;
            }
            List<System.String> requestPriorityConfiguration_priorityConfiguration_PriorityOrder = null;
            if (cmdletContext.PriorityConfiguration_PriorityOrder != null)
            {
                requestPriorityConfiguration_priorityConfiguration_PriorityOrder = cmdletContext.PriorityConfiguration_PriorityOrder;
            }
            if (requestPriorityConfiguration_priorityConfiguration_PriorityOrder != null)
            {
                request.PriorityConfiguration.PriorityOrder = requestPriorityConfiguration_priorityConfiguration_PriorityOrder;
                requestPriorityConfigurationIsNull = false;
            }
             // determine if request.PriorityConfiguration should be set to null
            if (requestPriorityConfigurationIsNull)
            {
                request.PriorityConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.GameLift.Model.CreateGameSessionQueueResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateGameSessionQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateGameSessionQueue");
            try
            {
                #if DESKTOP
                return client.CreateGameSessionQueue(request);
                #elif CORECLR
                return client.CreateGameSessionQueueAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomEventData { get; set; }
            public List<Amazon.GameLift.Model.GameSessionQueueDestination> Destination { get; set; }
            public List<System.String> FilterConfiguration_AllowedLocation { get; set; }
            public System.String Name { get; set; }
            public System.String NotificationTarget { get; set; }
            public List<Amazon.GameLift.Model.PlayerLatencyPolicy> PlayerLatencyPolicy { get; set; }
            public List<System.String> PriorityConfiguration_LocationOrder { get; set; }
            public List<System.String> PriorityConfiguration_PriorityOrder { get; set; }
            public List<Amazon.GameLift.Model.Tag> Tag { get; set; }
            public System.Int32? TimeoutInSecond { get; set; }
            public System.Func<Amazon.GameLift.Model.CreateGameSessionQueueResponse, NewGMLGameSessionQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSessionQueue;
        }
        
    }
}
