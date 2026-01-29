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
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.GameLift;
using Amazon.GameLift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// <b>This API works with the following fleet types:</b> EC2, Anywhere, Container
    /// 
    ///  
    /// <para>
    /// Updates the configuration of a game session queue, which determines how the queue
    /// processes new game session requests. To update settings, specify the queue name to
    /// be updated and provide the new settings. When updating destinations, provide a complete
    /// list of destinations. 
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/queues-intro.html">
    /// Using Multi-Region Queues</a></para>
    /// </summary>
    [Cmdlet("Update", "GMLGameSessionQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSessionQueue")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateGameSessionQueue API operation.", Operation = new[] {"UpdateGameSessionQueue"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateGameSessionQueueResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSessionQueue or Amazon.GameLift.Model.UpdateGameSessionQueueResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameSessionQueue object.",
        "The service call response (type Amazon.GameLift.Model.UpdateGameSessionQueueResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateGMLGameSessionQueueCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FilterConfiguration_AllowedLocation
        /// <summary>
        /// <para>
        /// <para> A list of locations to allow game session placement in, in the form of Amazon Web
        /// Services Region codes such as <c>us-west-2</c>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// alias ARN, and are listed in order of placement preference. When updating this list,
        /// provide a complete list of destinations.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destinations")]
        public Amazon.GameLift.Model.GameSessionQueueDestination[] Destination { get; set; }
        #endregion
        
        #region Parameter IsDestinationsSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.GameLift.Model.UpdateGameSessionQueueRequest.Destinations" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// <para>If this property is set to false the property <seealso cref="P:Amazon.GameLift.Model.UpdateGameSessionQueueRequest.Destinations" /> will be reset to null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsDestinationsSet { get; set; }
        #endregion
        
        #region Parameter IsPlayerLatencyPoliciesSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.GameLift.Model.UpdateGameSessionQueueRequest.PlayerLatencyPolicies" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// <para>If this property is set to false the property <seealso cref="P:Amazon.GameLift.Model.UpdateGameSessionQueueRequest.PlayerLatencyPolicies" /> will be reset to null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsPlayerLatencyPoliciesSet { get; set; }
        #endregion
        
        #region Parameter PriorityConfiguration_LocationOrder
        /// <summary>
        /// <para>
        /// <para>The prioritization order to use for fleet locations, when the <c>PriorityOrder</c>
        /// property includes <c>LOCATION</c>. Locations can include Amazon Web Services Region
        /// codes (such as <c>us-west-2</c>), local zones, and custom locations (for Anywhere
        /// fleets). Each location must be listed only once. For details, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-regions.html">Amazon
        /// GameLift Servers service locations.</a></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PriorityConfiguration_LocationOrder { get; set; }
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
        /// <para>A set of policies that enforce a sliding cap on player latency when processing game
        /// sessions placement requests. Use multiple policies to gradually relax the cap over
        /// time if Amazon GameLift Servers can't make a placement. Policies are evaluated in
        /// order starting with the lowest maximum latency value. When updating policies, provide
        /// a complete collection of policies.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlayerLatencyPolicies")]
        public Amazon.GameLift.Model.PlayerLatencyPolicy[] PlayerLatencyPolicy { get; set; }
        #endregion
        
        #region Parameter PriorityConfiguration_PriorityOrder
        /// <summary>
        /// <para>
        /// <para>A custom sequence to use when prioritizing where to place new game sessions. Each
        /// priority type is listed once.</para><ul><li><para><c>LATENCY</c> -- Amazon GameLift Servers prioritizes locations where the average
        /// player latency is lowest. Player latency data is provided in each game session placement
        /// request.</para></li><li><para><c>COST</c> -- Amazon GameLift Servers prioritizes queue destinations with the lowest
        /// current hosting costs. Cost is evaluated based on the destination's location, instance
        /// type, and fleet type (Spot or On-Demand).</para></li><li><para><c>DESTINATION</c> -- Amazon GameLift Servers prioritizes based on the list order
        /// of destinations in the queue configuration.</para></li><li><para><c>LOCATION</c> -- Amazon GameLift Servers prioritizes based on the provided order
        /// of locations, as defined in <c>LocationOrder</c>. </para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PriorityConfiguration_PriorityOrder { get; set; }
        #endregion
        
        #region Parameter TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that a new game session placement request remains in
        /// the queue. When a request exceeds this time, the game session placement changes to
        /// a <c>TIMED_OUT</c> status.</para><note><para>The minimum value is 10 and the maximum value is 600.</para></note>
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
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateGameSessionQueueResponse, UpdateGMLGameSessionQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CustomEventData = this.CustomEventData;
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.GameLift.Model.GameSessionQueueDestination>(this.Destination);
            }
            context.IsDestinationsSet = this.IsDestinationsSet;
            if (!ParameterWasBound(nameof(this.IsDestinationsSet)) && this.Destination != null)
            {
                context.IsDestinationsSet = true;
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
            context.IsPlayerLatencyPoliciesSet = this.IsPlayerLatencyPoliciesSet;
            if (!ParameterWasBound(nameof(this.IsPlayerLatencyPoliciesSet)) && this.PlayerLatencyPolicy != null)
            {
                context.IsPlayerLatencyPoliciesSet = true;
            }
            if (this.PriorityConfiguration_LocationOrder != null)
            {
                context.PriorityConfiguration_LocationOrder = new List<System.String>(this.PriorityConfiguration_LocationOrder);
            }
            if (this.PriorityConfiguration_PriorityOrder != null)
            {
                context.PriorityConfiguration_PriorityOrder = new List<System.String>(this.PriorityConfiguration_PriorityOrder);
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
            
            if (cmdletContext.CustomEventData != null)
            {
                request.CustomEventData = cmdletContext.CustomEventData;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            if (cmdletContext.IsDestinationsSet != null)
            {
                request.IsDestinationsSet = cmdletContext.IsDestinationsSet.Value;
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
            if (cmdletContext.IsPlayerLatencyPoliciesSet != null)
            {
                request.IsPlayerLatencyPoliciesSet = cmdletContext.IsPlayerLatencyPoliciesSet.Value;
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
                return client.UpdateGameSessionQueueAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? IsDestinationsSet { get; set; }
            public List<System.String> FilterConfiguration_AllowedLocation { get; set; }
            public System.String Name { get; set; }
            public System.String NotificationTarget { get; set; }
            public List<Amazon.GameLift.Model.PlayerLatencyPolicy> PlayerLatencyPolicy { get; set; }
            public System.Boolean? IsPlayerLatencyPoliciesSet { get; set; }
            public List<System.String> PriorityConfiguration_LocationOrder { get; set; }
            public List<System.String> PriorityConfiguration_PriorityOrder { get; set; }
            public System.Int32? TimeoutInSecond { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateGameSessionQueueResponse, UpdateGMLGameSessionQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSessionQueue;
        }
        
    }
}
