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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// <b>This API works with the following fleet types:</b> EC2 (FleetIQ)
    /// 
    ///  
    /// <para>
    /// Updates Amazon GameLift Servers FleetIQ-specific properties for a game server group.
    /// Many Auto Scaling group properties are updated on the Auto Scaling group directly,
    /// including the launch template, Auto Scaling policies, and maximum/minimum/desired
    /// instance counts.
    /// </para><para>
    /// To update the game server group, specify the game server group ID and provide the
    /// updated values. Before applying the updates, the new values are validated to ensure
    /// that Amazon GameLift Servers FleetIQ can continue to perform instance balancing activity.
    /// If successful, a <c>GameServerGroup</c> object is returned.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/fleetiqguide/gsg-intro.html">Amazon
    /// GameLift Servers FleetIQ Guide</a></para>
    /// </summary>
    [Cmdlet("Update", "GMLGameServerGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameServerGroup")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateGameServerGroup API operation.", Operation = new[] {"UpdateGameServerGroup"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateGameServerGroupResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameServerGroup or Amazon.GameLift.Model.UpdateGameServerGroupResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameServerGroup object.",
        "The service call response (type Amazon.GameLift.Model.UpdateGameServerGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateGMLGameServerGroupCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BalancingStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates how Amazon GameLift Servers FleetIQ balances the use of Spot Instances and
        /// On-Demand Instances in the game server group. Method options include the following:</para><ul><li><para><c>SPOT_ONLY</c> - Only Spot Instances are used in the game server group. If Spot
        /// Instances are unavailable or not viable for game hosting, the game server group provides
        /// no hosting capacity until Spot Instances can again be used. Until then, no new instances
        /// are started, and the existing nonviable Spot Instances are terminated (after current
        /// gameplay ends) and are not replaced.</para></li><li><para><c>SPOT_PREFERRED</c> - (default value) Spot Instances are used whenever available
        /// in the game server group. If Spot Instances are unavailable, the game server group
        /// continues to provide hosting capacity by falling back to On-Demand Instances. Existing
        /// nonviable Spot Instances are terminated (after current gameplay ends) and are replaced
        /// with new On-Demand Instances.</para></li><li><para><c>ON_DEMAND_ONLY</c> - Only On-Demand Instances are used in the game server group.
        /// No Spot Instances are used, even when available, while this balancing strategy is
        /// in force.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.BalancingStrategy")]
        public Amazon.GameLift.BalancingStrategy BalancingStrategy { get; set; }
        #endregion
        
        #region Parameter GameServerGroupName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the game server group. Use either the name or ARN value.</para>
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
        public System.String GameServerGroupName { get; set; }
        #endregion
        
        #region Parameter GameServerProtectionPolicy
        /// <summary>
        /// <para>
        /// <para>A flag that indicates whether instances in the game server group are protected from
        /// early termination. Unprotected instances that have active game servers running might
        /// be terminated during a scale-down event, causing players to be dropped from the game.
        /// Protected instances cannot be terminated while there are active game servers running
        /// except in the event of a forced game server group deletion (see ). An exception to
        /// this is with Spot Instances, which can be terminated by Amazon Web Services regardless
        /// of protection status. This property is set to <c>NO_PROTECTION</c> by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.GameServerProtectionPolicy")]
        public Amazon.GameLift.GameServerProtectionPolicy GameServerProtectionPolicy { get; set; }
        #endregion
        
        #region Parameter InstanceDefinition
        /// <summary>
        /// <para>
        /// <para>An updated list of Amazon EC2 instance types to use in the Auto Scaling group. The
        /// instance definitions must specify at least two different instance types that are supported
        /// by Amazon GameLift Servers FleetIQ. This updated list replaces the entire current
        /// list of instance definitions for the game server group. For more information on instance
        /// types, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">EC2
        /// Instance Types</a> in the <i>Amazon EC2 User Guide</i>. You can optionally specify
        /// capacity weighting for each instance type. If no weight value is specified for an
        /// instance type, it is set to the default value "1". For more information about capacity
        /// weighting, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-instance-weighting.html">
        /// Instance Weighting for Amazon EC2 Auto Scaling</a> in the Amazon EC2 Auto Scaling
        /// User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceDefinitions")]
        public Amazon.GameLift.Model.InstanceDefinition[] InstanceDefinition { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (<a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/s3-arn-format.html">ARN</a>)
        /// for an IAM role that allows Amazon GameLift Servers to access your Amazon EC2 Auto
        /// Scaling groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameServerGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateGameServerGroupResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateGameServerGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameServerGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GameServerGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GameServerGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GameServerGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameServerGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLGameServerGroup (UpdateGameServerGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateGameServerGroupResponse, UpdateGMLGameServerGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GameServerGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BalancingStrategy = this.BalancingStrategy;
            context.GameServerGroupName = this.GameServerGroupName;
            #if MODULAR
            if (this.GameServerGroupName == null && ParameterWasBound(nameof(this.GameServerGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter GameServerGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GameServerProtectionPolicy = this.GameServerProtectionPolicy;
            if (this.InstanceDefinition != null)
            {
                context.InstanceDefinition = new List<Amazon.GameLift.Model.InstanceDefinition>(this.InstanceDefinition);
            }
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.GameLift.Model.UpdateGameServerGroupRequest();
            
            if (cmdletContext.BalancingStrategy != null)
            {
                request.BalancingStrategy = cmdletContext.BalancingStrategy;
            }
            if (cmdletContext.GameServerGroupName != null)
            {
                request.GameServerGroupName = cmdletContext.GameServerGroupName;
            }
            if (cmdletContext.GameServerProtectionPolicy != null)
            {
                request.GameServerProtectionPolicy = cmdletContext.GameServerProtectionPolicy;
            }
            if (cmdletContext.InstanceDefinition != null)
            {
                request.InstanceDefinitions = cmdletContext.InstanceDefinition;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.GameLift.Model.UpdateGameServerGroupResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateGameServerGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateGameServerGroup");
            try
            {
                #if DESKTOP
                return client.UpdateGameServerGroup(request);
                #elif CORECLR
                return client.UpdateGameServerGroupAsync(request).GetAwaiter().GetResult();
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
            public Amazon.GameLift.BalancingStrategy BalancingStrategy { get; set; }
            public System.String GameServerGroupName { get; set; }
            public Amazon.GameLift.GameServerProtectionPolicy GameServerProtectionPolicy { get; set; }
            public List<Amazon.GameLift.Model.InstanceDefinition> InstanceDefinition { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateGameServerGroupResponse, UpdateGMLGameServerGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameServerGroup;
        }
        
    }
}
