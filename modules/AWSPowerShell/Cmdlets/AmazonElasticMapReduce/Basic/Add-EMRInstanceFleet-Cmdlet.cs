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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Adds an instance fleet to a running cluster.
    /// 
    ///  <note><para>
    /// The instance fleet configuration is available only in Amazon EMR versions 4.8.0 and
    /// later, excluding 5.0.x.
    /// </para></note>
    /// </summary>
    [Cmdlet("Add", "EMRInstanceFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse")]
    [AWSCmdlet("Invokes the AddInstanceFleet operation against Amazon Elastic MapReduce.", Operation = new[] {"AddInstanceFleet"})]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse",
        "This cmdlet returns a Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddEMRInstanceFleetCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter SpotSpecification_BlockDurationMinute
        /// <summary>
        /// <para>
        /// <para>The defined duration for Spot instances (also known as Spot blocks) in minutes. When
        /// specified, the Spot instance does not terminate before the defined duration expires,
        /// and defined duration pricing for Spot instances applies. Valid values are 60, 120,
        /// 180, 240, 300, or 360. The duration period starts as soon as a Spot instance receives
        /// its instance ID. At the end of the duration, Amazon EC2 marks the Spot instance for
        /// termination and provides a Spot instance termination notice, which gives the instance
        /// a two-minute warning before it terminates. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InstanceFleet_LaunchSpecifications_SpotSpecification_BlockDurationMinutes")]
        public System.Int32 SpotSpecification_BlockDurationMinute { get; set; }
        #endregion
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_InstanceFleetType
        /// <summary>
        /// <para>
        /// <para>The node type that the instance fleet hosts. Valid values are MASTER,CORE,and TASK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.InstanceFleetType")]
        public Amazon.ElasticMapReduce.InstanceFleetType InstanceFleet_InstanceFleetType { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_InstanceTypeConfig
        /// <summary>
        /// <para>
        /// <para>The instance type configurations that define the EC2 instances in the instance fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InstanceFleet_InstanceTypeConfigs")]
        public Amazon.ElasticMapReduce.Model.InstanceTypeConfig[] InstanceFleet_InstanceTypeConfig { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_Name
        /// <summary>
        /// <para>
        /// <para>The friendly name of the instance fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceFleet_Name { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_TargetOnDemandCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity of On-Demand units for the instance fleet, which determines how
        /// many On-Demand instances to provision. When the instance fleet launches, Amazon EMR
        /// tries to provision On-Demand instances as specified by <a>InstanceTypeConfig</a>.
        /// Each instance configuration has a specified <code>WeightedCapacity</code>. When an
        /// On-Demand instance is provisioned, the <code>WeightedCapacity</code> units count toward
        /// the target capacity. Amazon EMR provisions instances until the target capacity is
        /// totally fulfilled, even if this results in an overage. For example, if there are 2
        /// units remaining to fulfill capacity, and Amazon EMR can only provision an instance
        /// with a <code>WeightedCapacity</code> of 5 units, the instance is provisioned, and
        /// the target capacity is exceeded by 3 units.</para><note><para>If not specified or set to 0, only Spot instances are provisioned for the instance
        /// fleet using <code>TargetSpotCapacity</code>. At least one of <code>TargetSpotCapacity</code>
        /// and <code>TargetOnDemandCapacity</code> should be greater than 0. For a master instance
        /// fleet, only one of <code>TargetSpotCapacity</code> and <code>TargetOnDemandCapacity</code>
        /// can be specified, and its value must be 1.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 InstanceFleet_TargetOnDemandCapacity { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_TargetSpotCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity of Spot units for the instance fleet, which determines how many
        /// Spot instances to provision. When the instance fleet launches, Amazon EMR tries to
        /// provision Spot instances as specified by <a>InstanceTypeConfig</a>. Each instance
        /// configuration has a specified <code>WeightedCapacity</code>. When a Spot instance
        /// is provisioned, the <code>WeightedCapacity</code> units count toward the target capacity.
        /// Amazon EMR provisions instances until the target capacity is totally fulfilled, even
        /// if this results in an overage. For example, if there are 2 units remaining to fulfill
        /// capacity, and Amazon EMR can only provision an instance with a <code>WeightedCapacity</code>
        /// of 5 units, the instance is provisioned, and the target capacity is exceeded by 3
        /// units.</para><note><para>If not specified or set to 0, only On-Demand instances are provisioned for the instance
        /// fleet. At least one of <code>TargetSpotCapacity</code> and <code>TargetOnDemandCapacity</code>
        /// should be greater than 0. For a master instance fleet, only one of <code>TargetSpotCapacity</code>
        /// and <code>TargetOnDemandCapacity</code> can be specified, and its value must be 1.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 InstanceFleet_TargetSpotCapacity { get; set; }
        #endregion
        
        #region Parameter SpotSpecification_TimeoutAction
        /// <summary>
        /// <para>
        /// <para>The action to take when <code>TargetSpotCapacity</code> has not been fulfilled when
        /// the <code>TimeoutDurationMinutes</code> has expired. Spot instances are not uprovisioned
        /// within the Spot provisioining timeout. Valid values are <code>TERMINATE_CLUSTER</code>
        /// and <code>SWITCH_TO_ON_DEMAND</code>. SWITCH_TO_ON_DEMAND specifies that if no Spot
        /// instances are available, On-Demand Instances should be provisioned to fulfill any
        /// remaining Spot capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutAction")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.SpotProvisioningTimeoutAction")]
        public Amazon.ElasticMapReduce.SpotProvisioningTimeoutAction SpotSpecification_TimeoutAction { get; set; }
        #endregion
        
        #region Parameter SpotSpecification_TimeoutDurationMinute
        /// <summary>
        /// <para>
        /// <para>The spot provisioning timeout period in minutes. If Spot instances are not provisioned
        /// within this time period, the <code>TimeOutAction</code> is taken. Minimum value is
        /// 5 and maximum value is 1440. The timeout applies only during initial provisioning,
        /// when the cluster is first created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutDurationMinutes")]
        public System.Int32 SpotSpecification_TimeoutDurationMinute { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EMRInstanceFleet (AddInstanceFleet)"))
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
            
            context.ClusterId = this.ClusterId;
            context.InstanceFleet_InstanceFleetType = this.InstanceFleet_InstanceFleetType;
            if (this.InstanceFleet_InstanceTypeConfig != null)
            {
                context.InstanceFleet_InstanceTypeConfigs = new List<Amazon.ElasticMapReduce.Model.InstanceTypeConfig>(this.InstanceFleet_InstanceTypeConfig);
            }
            if (ParameterWasBound("SpotSpecification_BlockDurationMinute"))
                context.InstanceFleet_LaunchSpecifications_SpotSpecification_BlockDurationMinutes = this.SpotSpecification_BlockDurationMinute;
            context.InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutAction = this.SpotSpecification_TimeoutAction;
            if (ParameterWasBound("SpotSpecification_TimeoutDurationMinute"))
                context.InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutDurationMinutes = this.SpotSpecification_TimeoutDurationMinute;
            context.InstanceFleet_Name = this.InstanceFleet_Name;
            if (ParameterWasBound("InstanceFleet_TargetOnDemandCapacity"))
                context.InstanceFleet_TargetOnDemandCapacity = this.InstanceFleet_TargetOnDemandCapacity;
            if (ParameterWasBound("InstanceFleet_TargetSpotCapacity"))
                context.InstanceFleet_TargetSpotCapacity = this.InstanceFleet_TargetSpotCapacity;
            
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
            var request = new Amazon.ElasticMapReduce.Model.AddInstanceFleetRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            
             // populate InstanceFleet
            bool requestInstanceFleetIsNull = true;
            request.InstanceFleet = new Amazon.ElasticMapReduce.Model.InstanceFleetConfig();
            Amazon.ElasticMapReduce.InstanceFleetType requestInstanceFleet_instanceFleet_InstanceFleetType = null;
            if (cmdletContext.InstanceFleet_InstanceFleetType != null)
            {
                requestInstanceFleet_instanceFleet_InstanceFleetType = cmdletContext.InstanceFleet_InstanceFleetType;
            }
            if (requestInstanceFleet_instanceFleet_InstanceFleetType != null)
            {
                request.InstanceFleet.InstanceFleetType = requestInstanceFleet_instanceFleet_InstanceFleetType;
                requestInstanceFleetIsNull = false;
            }
            List<Amazon.ElasticMapReduce.Model.InstanceTypeConfig> requestInstanceFleet_instanceFleet_InstanceTypeConfig = null;
            if (cmdletContext.InstanceFleet_InstanceTypeConfigs != null)
            {
                requestInstanceFleet_instanceFleet_InstanceTypeConfig = cmdletContext.InstanceFleet_InstanceTypeConfigs;
            }
            if (requestInstanceFleet_instanceFleet_InstanceTypeConfig != null)
            {
                request.InstanceFleet.InstanceTypeConfigs = requestInstanceFleet_instanceFleet_InstanceTypeConfig;
                requestInstanceFleetIsNull = false;
            }
            System.String requestInstanceFleet_instanceFleet_Name = null;
            if (cmdletContext.InstanceFleet_Name != null)
            {
                requestInstanceFleet_instanceFleet_Name = cmdletContext.InstanceFleet_Name;
            }
            if (requestInstanceFleet_instanceFleet_Name != null)
            {
                request.InstanceFleet.Name = requestInstanceFleet_instanceFleet_Name;
                requestInstanceFleetIsNull = false;
            }
            System.Int32? requestInstanceFleet_instanceFleet_TargetOnDemandCapacity = null;
            if (cmdletContext.InstanceFleet_TargetOnDemandCapacity != null)
            {
                requestInstanceFleet_instanceFleet_TargetOnDemandCapacity = cmdletContext.InstanceFleet_TargetOnDemandCapacity.Value;
            }
            if (requestInstanceFleet_instanceFleet_TargetOnDemandCapacity != null)
            {
                request.InstanceFleet.TargetOnDemandCapacity = requestInstanceFleet_instanceFleet_TargetOnDemandCapacity.Value;
                requestInstanceFleetIsNull = false;
            }
            System.Int32? requestInstanceFleet_instanceFleet_TargetSpotCapacity = null;
            if (cmdletContext.InstanceFleet_TargetSpotCapacity != null)
            {
                requestInstanceFleet_instanceFleet_TargetSpotCapacity = cmdletContext.InstanceFleet_TargetSpotCapacity.Value;
            }
            if (requestInstanceFleet_instanceFleet_TargetSpotCapacity != null)
            {
                request.InstanceFleet.TargetSpotCapacity = requestInstanceFleet_instanceFleet_TargetSpotCapacity.Value;
                requestInstanceFleetIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.InstanceFleetProvisioningSpecifications requestInstanceFleet_instanceFleet_LaunchSpecifications = null;
            
             // populate LaunchSpecifications
            bool requestInstanceFleet_instanceFleet_LaunchSpecificationsIsNull = true;
            requestInstanceFleet_instanceFleet_LaunchSpecifications = new Amazon.ElasticMapReduce.Model.InstanceFleetProvisioningSpecifications();
            Amazon.ElasticMapReduce.Model.SpotProvisioningSpecification requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification = null;
            
             // populate SpotSpecification
            bool requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull = true;
            requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification = new Amazon.ElasticMapReduce.Model.SpotProvisioningSpecification();
            System.Int32? requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_BlockDurationMinute = null;
            if (cmdletContext.InstanceFleet_LaunchSpecifications_SpotSpecification_BlockDurationMinutes != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_BlockDurationMinute = cmdletContext.InstanceFleet_LaunchSpecifications_SpotSpecification_BlockDurationMinutes.Value;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_BlockDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification.BlockDurationMinutes = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_BlockDurationMinute.Value;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull = false;
            }
            Amazon.ElasticMapReduce.SpotProvisioningTimeoutAction requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutAction = null;
            if (cmdletContext.InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutAction != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutAction = cmdletContext.InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutAction;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutAction != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification.TimeoutAction = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutAction;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull = false;
            }
            System.Int32? requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutDurationMinute = null;
            if (cmdletContext.InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutDurationMinutes != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutDurationMinute = cmdletContext.InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutDurationMinutes.Value;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification.TimeoutDurationMinutes = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutDurationMinute.Value;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification should be set to null
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification = null;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications.SpotSpecification = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification;
                requestInstanceFleet_instanceFleet_LaunchSpecificationsIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_LaunchSpecifications should be set to null
            if (requestInstanceFleet_instanceFleet_LaunchSpecificationsIsNull)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications = null;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications != null)
            {
                request.InstanceFleet.LaunchSpecifications = requestInstanceFleet_instanceFleet_LaunchSpecifications;
                requestInstanceFleetIsNull = false;
            }
             // determine if request.InstanceFleet should be set to null
            if (requestInstanceFleetIsNull)
            {
                request.InstanceFleet = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.AddInstanceFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "AddInstanceFleet");
            #if DESKTOP
            return client.AddInstanceFleet(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AddInstanceFleetAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ClusterId { get; set; }
            public Amazon.ElasticMapReduce.InstanceFleetType InstanceFleet_InstanceFleetType { get; set; }
            public List<Amazon.ElasticMapReduce.Model.InstanceTypeConfig> InstanceFleet_InstanceTypeConfigs { get; set; }
            public System.Int32? InstanceFleet_LaunchSpecifications_SpotSpecification_BlockDurationMinutes { get; set; }
            public Amazon.ElasticMapReduce.SpotProvisioningTimeoutAction InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutAction { get; set; }
            public System.Int32? InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutDurationMinutes { get; set; }
            public System.String InstanceFleet_Name { get; set; }
            public System.Int32? InstanceFleet_TargetOnDemandCapacity { get; set; }
            public System.Int32? InstanceFleet_TargetSpotCapacity { get; set; }
        }
        
    }
}
