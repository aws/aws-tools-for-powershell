/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Launches an EC2 Fleet.
    /// 
    ///  
    /// <para>
    /// You can create a single EC2 Fleet that includes multiple launch specifications that
    /// vary by instance type, AMI, Availability Zone, or subnet.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-fleet.html">Launching
    /// an EC2 Fleet</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Fleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateFleet API operation.", Operation = new[] {"CreateFleet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.EC2.Model.CreateFleetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2FleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter SpotOptions_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates how to allocate the target capacity across the Spot pools specified by the
        /// Spot Fleet request. The default is <code>lowestPrice</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.SpotAllocationStrategy")]
        public Amazon.EC2.SpotAllocationStrategy SpotOptions_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_DefaultTargetCapacityType
        /// <summary>
        /// <para>
        /// <para>The default <code>TotalTargetCapacity</code>, which is either <code>Spot</code> or
        /// <code>On-Demand</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.DefaultTargetCapacityType")]
        public Amazon.EC2.DefaultTargetCapacityType TargetCapacitySpecification_DefaultTargetCapacityType { get; set; }
        #endregion
        
        #region Parameter ExcessCapacityTerminationPolicy
        /// <summary>
        /// <para>
        /// <para>Indicates whether running instances should be terminated if the total target capacity
        /// of the EC2 Fleet is decreased below the current size of the EC2 Fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.FleetExcessCapacityTerminationPolicy")]
        public Amazon.EC2.FleetExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
        #endregion
        
        #region Parameter SpotOptions_InstanceInterruptionBehavior
        /// <summary>
        /// <para>
        /// <para>The behavior when a Spot Instance is interrupted. The default is <code>terminate</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.SpotInstanceInterruptionBehavior")]
        public Amazon.EC2.SpotInstanceInterruptionBehavior SpotOptions_InstanceInterruptionBehavior { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateConfig
        /// <summary>
        /// <para>
        /// <para>The configuration for the EC2 Fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("LaunchTemplateConfigs")]
        public Amazon.EC2.Model.FleetLaunchTemplateConfigRequest[] LaunchTemplateConfig { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_OnDemandTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of On-Demand units to request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TargetCapacitySpecification_OnDemandTargetCapacity { get; set; }
        #endregion
        
        #region Parameter ReplaceUnhealthyInstance
        /// <summary>
        /// <para>
        /// <para>Indicates whether EC2 Fleet should replace unhealthy instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReplaceUnhealthyInstances")]
        public System.Boolean ReplaceUnhealthyInstance { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_SpotTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of Spot units to request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TargetCapacitySpecification_SpotTargetCapacity { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags for an EC2 Fleet resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TerminateInstancesWithExpiration
        /// <summary>
        /// <para>
        /// <para>Indicates whether running instances should be terminated when the EC2 Fleet expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean TerminateInstancesWithExpiration { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_TotalTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of units to request, filled using <code>DefaultTargetCapacityType</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TargetCapacitySpecification_TotalTargetCapacity { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of request. Indicates whether the EC2 Fleet only <code>requests</code> the
        /// target capacity, or also attempts to <code>maintain</code> it. If you request a certain
        /// target capacity, EC2 Fleet only places the required requests. It does not attempt
        /// to replenish instances if capacity is diminished, and does not submit requests in
        /// alternative capacity pools if capacity is unavailable. To maintain a certain target
        /// capacity, EC2 Fleet places the required requests to meet this target capacity. It
        /// also automatically replenishes any interrupted Spot Instances. Default: <code>maintain</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.FleetType")]
        public Amazon.EC2.FleetType Type { get; set; }
        #endregion
        
        #region Parameter ValidFrom
        /// <summary>
        /// <para>
        /// <para>The start date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// The default is to start fulfilling the request immediately.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ValidFrom { get; set; }
        #endregion
        
        #region Parameter ValidUntil
        /// <summary>
        /// <para>
        /// <para>The end date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// At this point, no new EC2 Fleet requests are placed or able to fulfill the request.
        /// The default end date is 7 days from the current date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ValidUntil { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LaunchTemplateConfig", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Fleet (CreateFleet)"))
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
            
            context.ClientToken = this.ClientToken;
            context.ExcessCapacityTerminationPolicy = this.ExcessCapacityTerminationPolicy;
            if (this.LaunchTemplateConfig != null)
            {
                context.LaunchTemplateConfigs = new List<Amazon.EC2.Model.FleetLaunchTemplateConfigRequest>(this.LaunchTemplateConfig);
            }
            if (ParameterWasBound("ReplaceUnhealthyInstance"))
                context.ReplaceUnhealthyInstances = this.ReplaceUnhealthyInstance;
            context.SpotOptions_AllocationStrategy = this.SpotOptions_AllocationStrategy;
            context.SpotOptions_InstanceInterruptionBehavior = this.SpotOptions_InstanceInterruptionBehavior;
            if (this.TagSpecification != null)
            {
                context.TagSpecifications = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TargetCapacitySpecification_DefaultTargetCapacityType = this.TargetCapacitySpecification_DefaultTargetCapacityType;
            if (ParameterWasBound("TargetCapacitySpecification_OnDemandTargetCapacity"))
                context.TargetCapacitySpecification_OnDemandTargetCapacity = this.TargetCapacitySpecification_OnDemandTargetCapacity;
            if (ParameterWasBound("TargetCapacitySpecification_SpotTargetCapacity"))
                context.TargetCapacitySpecification_SpotTargetCapacity = this.TargetCapacitySpecification_SpotTargetCapacity;
            if (ParameterWasBound("TargetCapacitySpecification_TotalTargetCapacity"))
                context.TargetCapacitySpecification_TotalTargetCapacity = this.TargetCapacitySpecification_TotalTargetCapacity;
            if (ParameterWasBound("TerminateInstancesWithExpiration"))
                context.TerminateInstancesWithExpiration = this.TerminateInstancesWithExpiration;
            context.Type = this.Type;
            if (ParameterWasBound("ValidFrom"))
                context.ValidFrom = this.ValidFrom;
            if (ParameterWasBound("ValidUntil"))
                context.ValidUntil = this.ValidUntil;
            
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
            var request = new Amazon.EC2.Model.CreateFleetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExcessCapacityTerminationPolicy != null)
            {
                request.ExcessCapacityTerminationPolicy = cmdletContext.ExcessCapacityTerminationPolicy;
            }
            if (cmdletContext.LaunchTemplateConfigs != null)
            {
                request.LaunchTemplateConfigs = cmdletContext.LaunchTemplateConfigs;
            }
            if (cmdletContext.ReplaceUnhealthyInstances != null)
            {
                request.ReplaceUnhealthyInstances = cmdletContext.ReplaceUnhealthyInstances.Value;
            }
            
             // populate SpotOptions
            bool requestSpotOptionsIsNull = true;
            request.SpotOptions = new Amazon.EC2.Model.SpotOptionsRequest();
            Amazon.EC2.SpotAllocationStrategy requestSpotOptions_spotOptions_AllocationStrategy = null;
            if (cmdletContext.SpotOptions_AllocationStrategy != null)
            {
                requestSpotOptions_spotOptions_AllocationStrategy = cmdletContext.SpotOptions_AllocationStrategy;
            }
            if (requestSpotOptions_spotOptions_AllocationStrategy != null)
            {
                request.SpotOptions.AllocationStrategy = requestSpotOptions_spotOptions_AllocationStrategy;
                requestSpotOptionsIsNull = false;
            }
            Amazon.EC2.SpotInstanceInterruptionBehavior requestSpotOptions_spotOptions_InstanceInterruptionBehavior = null;
            if (cmdletContext.SpotOptions_InstanceInterruptionBehavior != null)
            {
                requestSpotOptions_spotOptions_InstanceInterruptionBehavior = cmdletContext.SpotOptions_InstanceInterruptionBehavior;
            }
            if (requestSpotOptions_spotOptions_InstanceInterruptionBehavior != null)
            {
                request.SpotOptions.InstanceInterruptionBehavior = requestSpotOptions_spotOptions_InstanceInterruptionBehavior;
                requestSpotOptionsIsNull = false;
            }
             // determine if request.SpotOptions should be set to null
            if (requestSpotOptionsIsNull)
            {
                request.SpotOptions = null;
            }
            if (cmdletContext.TagSpecifications != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecifications;
            }
            
             // populate TargetCapacitySpecification
            bool requestTargetCapacitySpecificationIsNull = true;
            request.TargetCapacitySpecification = new Amazon.EC2.Model.TargetCapacitySpecificationRequest();
            Amazon.EC2.DefaultTargetCapacityType requestTargetCapacitySpecification_targetCapacitySpecification_DefaultTargetCapacityType = null;
            if (cmdletContext.TargetCapacitySpecification_DefaultTargetCapacityType != null)
            {
                requestTargetCapacitySpecification_targetCapacitySpecification_DefaultTargetCapacityType = cmdletContext.TargetCapacitySpecification_DefaultTargetCapacityType;
            }
            if (requestTargetCapacitySpecification_targetCapacitySpecification_DefaultTargetCapacityType != null)
            {
                request.TargetCapacitySpecification.DefaultTargetCapacityType = requestTargetCapacitySpecification_targetCapacitySpecification_DefaultTargetCapacityType;
                requestTargetCapacitySpecificationIsNull = false;
            }
            System.Int32? requestTargetCapacitySpecification_targetCapacitySpecification_OnDemandTargetCapacity = null;
            if (cmdletContext.TargetCapacitySpecification_OnDemandTargetCapacity != null)
            {
                requestTargetCapacitySpecification_targetCapacitySpecification_OnDemandTargetCapacity = cmdletContext.TargetCapacitySpecification_OnDemandTargetCapacity.Value;
            }
            if (requestTargetCapacitySpecification_targetCapacitySpecification_OnDemandTargetCapacity != null)
            {
                request.TargetCapacitySpecification.OnDemandTargetCapacity = requestTargetCapacitySpecification_targetCapacitySpecification_OnDemandTargetCapacity.Value;
                requestTargetCapacitySpecificationIsNull = false;
            }
            System.Int32? requestTargetCapacitySpecification_targetCapacitySpecification_SpotTargetCapacity = null;
            if (cmdletContext.TargetCapacitySpecification_SpotTargetCapacity != null)
            {
                requestTargetCapacitySpecification_targetCapacitySpecification_SpotTargetCapacity = cmdletContext.TargetCapacitySpecification_SpotTargetCapacity.Value;
            }
            if (requestTargetCapacitySpecification_targetCapacitySpecification_SpotTargetCapacity != null)
            {
                request.TargetCapacitySpecification.SpotTargetCapacity = requestTargetCapacitySpecification_targetCapacitySpecification_SpotTargetCapacity.Value;
                requestTargetCapacitySpecificationIsNull = false;
            }
            System.Int32? requestTargetCapacitySpecification_targetCapacitySpecification_TotalTargetCapacity = null;
            if (cmdletContext.TargetCapacitySpecification_TotalTargetCapacity != null)
            {
                requestTargetCapacitySpecification_targetCapacitySpecification_TotalTargetCapacity = cmdletContext.TargetCapacitySpecification_TotalTargetCapacity.Value;
            }
            if (requestTargetCapacitySpecification_targetCapacitySpecification_TotalTargetCapacity != null)
            {
                request.TargetCapacitySpecification.TotalTargetCapacity = requestTargetCapacitySpecification_targetCapacitySpecification_TotalTargetCapacity.Value;
                requestTargetCapacitySpecificationIsNull = false;
            }
             // determine if request.TargetCapacitySpecification should be set to null
            if (requestTargetCapacitySpecificationIsNull)
            {
                request.TargetCapacitySpecification = null;
            }
            if (cmdletContext.TerminateInstancesWithExpiration != null)
            {
                request.TerminateInstancesWithExpiration = cmdletContext.TerminateInstancesWithExpiration.Value;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.ValidFrom != null)
            {
                request.ValidFrom = cmdletContext.ValidFrom.Value;
            }
            if (cmdletContext.ValidUntil != null)
            {
                request.ValidUntil = cmdletContext.ValidUntil.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FleetId;
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
        
        private Amazon.EC2.Model.CreateFleetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateFleet");
            try
            {
                #if DESKTOP
                return client.CreateFleet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateFleetAsync(request);
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
            public System.String ClientToken { get; set; }
            public Amazon.EC2.FleetExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
            public List<Amazon.EC2.Model.FleetLaunchTemplateConfigRequest> LaunchTemplateConfigs { get; set; }
            public System.Boolean? ReplaceUnhealthyInstances { get; set; }
            public Amazon.EC2.SpotAllocationStrategy SpotOptions_AllocationStrategy { get; set; }
            public Amazon.EC2.SpotInstanceInterruptionBehavior SpotOptions_InstanceInterruptionBehavior { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecifications { get; set; }
            public Amazon.EC2.DefaultTargetCapacityType TargetCapacitySpecification_DefaultTargetCapacityType { get; set; }
            public System.Int32? TargetCapacitySpecification_OnDemandTargetCapacity { get; set; }
            public System.Int32? TargetCapacitySpecification_SpotTargetCapacity { get; set; }
            public System.Int32? TargetCapacitySpecification_TotalTargetCapacity { get; set; }
            public System.Boolean? TerminateInstancesWithExpiration { get; set; }
            public Amazon.EC2.FleetType Type { get; set; }
            public System.DateTime? ValidFrom { get; set; }
            public System.DateTime? ValidUntil { get; set; }
        }
        
    }
}
