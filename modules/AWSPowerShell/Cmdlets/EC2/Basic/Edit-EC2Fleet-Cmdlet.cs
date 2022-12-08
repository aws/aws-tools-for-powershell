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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified EC2 Fleet.
    /// 
    ///  
    /// <para>
    /// You can only modify an EC2 Fleet request of type <code>maintain</code>.
    /// </para><para>
    /// While the EC2 Fleet is being modified, it is in the <code>modifying</code> state.
    /// </para><para>
    /// To scale up your EC2 Fleet, increase its target capacity. The EC2 Fleet launches the
    /// additional Spot Instances according to the allocation strategy for the EC2 Fleet request.
    /// If the allocation strategy is <code>lowest-price</code>, the EC2 Fleet launches instances
    /// using the Spot Instance pool with the lowest price. If the allocation strategy is
    /// <code>diversified</code>, the EC2 Fleet distributes the instances across the Spot
    /// Instance pools. If the allocation strategy is <code>capacity-optimized</code>, EC2
    /// Fleet launches instances from Spot Instance pools with optimal capacity for the number
    /// of instances that are launching.
    /// </para><para>
    /// To scale down your EC2 Fleet, decrease its target capacity. First, the EC2 Fleet cancels
    /// any open requests that exceed the new target capacity. You can request that the EC2
    /// Fleet terminate Spot Instances until the size of the fleet no longer exceeds the new
    /// target capacity. If the allocation strategy is <code>lowest-price</code>, the EC2
    /// Fleet terminates the instances with the highest price per unit. If the allocation
    /// strategy is <code>capacity-optimized</code>, the EC2 Fleet terminates the instances
    /// in the Spot Instance pools that have the least available Spot Instance capacity. If
    /// the allocation strategy is <code>diversified</code>, the EC2 Fleet terminates instances
    /// across the Spot Instance pools. Alternatively, you can request that the EC2 Fleet
    /// keep the fleet at its current size, but not replace any Spot Instances that are interrupted
    /// or that you terminate manually.
    /// </para><para>
    /// If you are finished with your EC2 Fleet for now, but will use it again later, you
    /// can set the target capacity to 0.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2Fleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyFleet API operation.", Operation = new[] {"ModifyFleet"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyFleetResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ModifyFleetResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyFleetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2FleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_DefaultTargetCapacityType
        /// <summary>
        /// <para>
        /// <para>The default <code>TotalTargetCapacity</code>, which is either <code>Spot</code> or
        /// <code>On-Demand</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.FleetExcessCapacityTerminationPolicy")]
        public Amazon.EC2.FleetExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>The ID of the EC2 Fleet.</para>
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
        
        #region Parameter LaunchTemplateConfig
        /// <summary>
        /// <para>
        /// <para>The launch template and overrides.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchTemplateConfigs")]
        public Amazon.EC2.Model.FleetLaunchTemplateConfigRequest[] LaunchTemplateConfig { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_OnDemandTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of On-Demand units to request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetCapacitySpecification_OnDemandTargetCapacity { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_SpotTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of Spot units to request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetCapacitySpecification_SpotTargetCapacity { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_TargetCapacityUnitType
        /// <summary>
        /// <para>
        /// <para>The unit for the target capacity.</para><para>Default: <code>units</code> (translates to number of instances)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TargetCapacityUnitType")]
        public Amazon.EC2.TargetCapacityUnitType TargetCapacitySpecification_TargetCapacityUnitType { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_TotalTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of units to request, filled using <code>DefaultTargetCapacityType</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetCapacitySpecification_TotalTargetCapacity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyFleetResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyFleetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2Fleet (ModifyFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyFleetResponse, EditEC2FleetCmdlet>(Select) ??
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
            context.Context = this.Context;
            context.ExcessCapacityTerminationPolicy = this.ExcessCapacityTerminationPolicy;
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LaunchTemplateConfig != null)
            {
                context.LaunchTemplateConfig = new List<Amazon.EC2.Model.FleetLaunchTemplateConfigRequest>(this.LaunchTemplateConfig);
            }
            context.TargetCapacitySpecification_DefaultTargetCapacityType = this.TargetCapacitySpecification_DefaultTargetCapacityType;
            context.TargetCapacitySpecification_OnDemandTargetCapacity = this.TargetCapacitySpecification_OnDemandTargetCapacity;
            context.TargetCapacitySpecification_SpotTargetCapacity = this.TargetCapacitySpecification_SpotTargetCapacity;
            context.TargetCapacitySpecification_TargetCapacityUnitType = this.TargetCapacitySpecification_TargetCapacityUnitType;
            context.TargetCapacitySpecification_TotalTargetCapacity = this.TargetCapacitySpecification_TotalTargetCapacity;
            
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
            var request = new Amazon.EC2.Model.ModifyFleetRequest();
            
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.ExcessCapacityTerminationPolicy != null)
            {
                request.ExcessCapacityTerminationPolicy = cmdletContext.ExcessCapacityTerminationPolicy;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.LaunchTemplateConfig != null)
            {
                request.LaunchTemplateConfigs = cmdletContext.LaunchTemplateConfig;
            }
            
             // populate TargetCapacitySpecification
            var requestTargetCapacitySpecificationIsNull = true;
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
            Amazon.EC2.TargetCapacityUnitType requestTargetCapacitySpecification_targetCapacitySpecification_TargetCapacityUnitType = null;
            if (cmdletContext.TargetCapacitySpecification_TargetCapacityUnitType != null)
            {
                requestTargetCapacitySpecification_targetCapacitySpecification_TargetCapacityUnitType = cmdletContext.TargetCapacitySpecification_TargetCapacityUnitType;
            }
            if (requestTargetCapacitySpecification_targetCapacitySpecification_TargetCapacityUnitType != null)
            {
                request.TargetCapacitySpecification.TargetCapacityUnitType = requestTargetCapacitySpecification_targetCapacitySpecification_TargetCapacityUnitType;
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
        
        private Amazon.EC2.Model.ModifyFleetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyFleet");
            try
            {
                #if DESKTOP
                return client.ModifyFleet(request);
                #elif CORECLR
                return client.ModifyFleetAsync(request).GetAwaiter().GetResult();
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
            public System.String Context { get; set; }
            public Amazon.EC2.FleetExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
            public System.String FleetId { get; set; }
            public List<Amazon.EC2.Model.FleetLaunchTemplateConfigRequest> LaunchTemplateConfig { get; set; }
            public Amazon.EC2.DefaultTargetCapacityType TargetCapacitySpecification_DefaultTargetCapacityType { get; set; }
            public System.Int32? TargetCapacitySpecification_OnDemandTargetCapacity { get; set; }
            public System.Int32? TargetCapacitySpecification_SpotTargetCapacity { get; set; }
            public Amazon.EC2.TargetCapacityUnitType TargetCapacitySpecification_TargetCapacityUnitType { get; set; }
            public System.Int32? TargetCapacitySpecification_TotalTargetCapacity { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyFleetResponse, EditEC2FleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
