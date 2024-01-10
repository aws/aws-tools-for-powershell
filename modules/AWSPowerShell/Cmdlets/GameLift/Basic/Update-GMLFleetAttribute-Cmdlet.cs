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
    /// Updates a fleet's mutable attributes, including game session protection and resource
    /// creation limits.
    /// 
    ///  
    /// <para>
    /// To update fleet attributes, specify the fleet ID and the property values that you
    /// want to change. 
    /// </para><para>
    /// If successful, an updated <c>FleetAttributes</c> object is returned.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-intro.html">Setting
    /// up Amazon GameLift fleets</a></para>
    /// </summary>
    [Cmdlet("Update", "GMLFleetAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateFleetAttributes API operation.", Operation = new[] {"UpdateFleetAttributes"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateFleetAttributesResponse))]
    [AWSCmdletOutput("System.String or Amazon.GameLift.Model.UpdateFleetAttributesResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GameLift.Model.UpdateFleetAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGMLFleetAttributeCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnywhereConfiguration_Cost
        /// <summary>
        /// <para>
        /// <para>The cost to run your fleet per hour. Amazon GameLift uses the provided cost of your
        /// fleet to balance usage in queues. For more information about queues, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/queues-intro.html">Setting
        /// up queues</a> in the <i>Amazon GameLift Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnywhereConfiguration_Cost { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A human-readable description of a fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet to update attribute metadata for. You can use either
        /// the fleet ID or ARN value.</para>
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
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter MetricGroup
        /// <summary>
        /// <para>
        /// <para>The name of a metric group to add this fleet to. Use a metric group in Amazon CloudWatch
        /// to aggregate the metrics from multiple fleets. Provide an existing metric group name,
        /// or create a new metric group by providing a new name. A fleet can only be in one metric
        /// group at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricGroups")]
        public System.String[] MetricGroup { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive label that is associated with a fleet. Fleet names do not need to be
        /// unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NewGameSessionProtectionPolicy
        /// <summary>
        /// <para>
        /// <para>The game session protection policy to apply to all new game sessions created in this
        /// fleet. Game sessions that already exist are not affected. You can set protection for
        /// individual game sessions using <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_UpdateGameSession.html">UpdateGameSession</a>
        /// .</para><ul><li><para><b>NoProtection</b> -- The game session can be terminated during a scale-down event.</para></li><li><para><b>FullProtection</b> -- If the game session is in an <c>ACTIVE</c> status, it cannot
        /// be terminated during a scale-down event.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.ProtectionPolicy")]
        public Amazon.GameLift.ProtectionPolicy NewGameSessionProtectionPolicy { get; set; }
        #endregion
        
        #region Parameter ResourceCreationLimitPolicy_NewGameSessionsPerCreator
        /// <summary>
        /// <para>
        /// <para>A policy that puts limits on the number of game sessions that a player can create
        /// within a specified span of time. With this policy, you can control players' ability
        /// to consume available resources.</para><para>The policy is evaluated when a player tries to create a new game session. On receiving
        /// a <c>CreateGameSession</c> request, Amazon GameLift checks that the player (identified
        /// by <c>CreatorId</c>) has created fewer than game session limit in the specified time
        /// period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourceCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
        #endregion
        
        #region Parameter ResourceCreationLimitPolicy_PolicyPeriodInMinute
        /// <summary>
        /// <para>
        /// <para>The time span used in evaluating the resource creation limit policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceCreationLimitPolicy_PolicyPeriodInMinutes")]
        public System.Int32? ResourceCreationLimitPolicy_PolicyPeriodInMinute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FleetId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateFleetAttributesResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateFleetAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FleetId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FleetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FleetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FleetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FleetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLFleetAttribute (UpdateFleetAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateFleetAttributesResponse, UpdateGMLFleetAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FleetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnywhereConfiguration_Cost = this.AnywhereConfiguration_Cost;
            context.Description = this.Description;
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetricGroup != null)
            {
                context.MetricGroup = new List<System.String>(this.MetricGroup);
            }
            context.Name = this.Name;
            context.NewGameSessionProtectionPolicy = this.NewGameSessionProtectionPolicy;
            context.ResourceCreationLimitPolicy_NewGameSessionsPerCreator = this.ResourceCreationLimitPolicy_NewGameSessionsPerCreator;
            context.ResourceCreationLimitPolicy_PolicyPeriodInMinute = this.ResourceCreationLimitPolicy_PolicyPeriodInMinute;
            
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
            var request = new Amazon.GameLift.Model.UpdateFleetAttributesRequest();
            
            
             // populate AnywhereConfiguration
            var requestAnywhereConfigurationIsNull = true;
            request.AnywhereConfiguration = new Amazon.GameLift.Model.AnywhereConfiguration();
            System.String requestAnywhereConfiguration_anywhereConfiguration_Cost = null;
            if (cmdletContext.AnywhereConfiguration_Cost != null)
            {
                requestAnywhereConfiguration_anywhereConfiguration_Cost = cmdletContext.AnywhereConfiguration_Cost;
            }
            if (requestAnywhereConfiguration_anywhereConfiguration_Cost != null)
            {
                request.AnywhereConfiguration.Cost = requestAnywhereConfiguration_anywhereConfiguration_Cost;
                requestAnywhereConfigurationIsNull = false;
            }
             // determine if request.AnywhereConfiguration should be set to null
            if (requestAnywhereConfigurationIsNull)
            {
                request.AnywhereConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.MetricGroup != null)
            {
                request.MetricGroups = cmdletContext.MetricGroup;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NewGameSessionProtectionPolicy != null)
            {
                request.NewGameSessionProtectionPolicy = cmdletContext.NewGameSessionProtectionPolicy;
            }
            
             // populate ResourceCreationLimitPolicy
            var requestResourceCreationLimitPolicyIsNull = true;
            request.ResourceCreationLimitPolicy = new Amazon.GameLift.Model.ResourceCreationLimitPolicy();
            System.Int32? requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_NewGameSessionsPerCreator = null;
            if (cmdletContext.ResourceCreationLimitPolicy_NewGameSessionsPerCreator != null)
            {
                requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_NewGameSessionsPerCreator = cmdletContext.ResourceCreationLimitPolicy_NewGameSessionsPerCreator.Value;
            }
            if (requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_NewGameSessionsPerCreator != null)
            {
                request.ResourceCreationLimitPolicy.NewGameSessionsPerCreator = requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_NewGameSessionsPerCreator.Value;
                requestResourceCreationLimitPolicyIsNull = false;
            }
            System.Int32? requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_PolicyPeriodInMinute = null;
            if (cmdletContext.ResourceCreationLimitPolicy_PolicyPeriodInMinute != null)
            {
                requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_PolicyPeriodInMinute = cmdletContext.ResourceCreationLimitPolicy_PolicyPeriodInMinute.Value;
            }
            if (requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_PolicyPeriodInMinute != null)
            {
                request.ResourceCreationLimitPolicy.PolicyPeriodInMinutes = requestResourceCreationLimitPolicy_resourceCreationLimitPolicy_PolicyPeriodInMinute.Value;
                requestResourceCreationLimitPolicyIsNull = false;
            }
             // determine if request.ResourceCreationLimitPolicy should be set to null
            if (requestResourceCreationLimitPolicyIsNull)
            {
                request.ResourceCreationLimitPolicy = null;
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
        
        private Amazon.GameLift.Model.UpdateFleetAttributesResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateFleetAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateFleetAttributes");
            try
            {
                #if DESKTOP
                return client.UpdateFleetAttributes(request);
                #elif CORECLR
                return client.UpdateFleetAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.String AnywhereConfiguration_Cost { get; set; }
            public System.String Description { get; set; }
            public System.String FleetId { get; set; }
            public List<System.String> MetricGroup { get; set; }
            public System.String Name { get; set; }
            public Amazon.GameLift.ProtectionPolicy NewGameSessionProtectionPolicy { get; set; }
            public System.Int32? ResourceCreationLimitPolicy_NewGameSessionsPerCreator { get; set; }
            public System.Int32? ResourceCreationLimitPolicy_PolicyPeriodInMinute { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateFleetAttributesResponse, UpdateGMLFleetAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FleetId;
        }
        
    }
}
