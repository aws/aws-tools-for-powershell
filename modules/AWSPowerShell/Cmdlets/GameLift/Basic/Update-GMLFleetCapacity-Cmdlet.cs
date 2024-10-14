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
    /// <b>This operation has been expanded to use with the Amazon GameLift containers feature,
    /// which is currently in public preview.</b><para>
    /// Updates capacity settings for a managed EC2 fleet or container fleet. For these fleets,
    /// you adjust capacity by changing the number of instances in the fleet. Fleet capacity
    /// determines the number of game sessions and players that the fleet can host based on
    /// its configuration. For fleets with multiple locations, use this operation to manage
    /// capacity settings in each location individually.
    /// </para><para>
    /// Use this operation to set these fleet capacity properties: 
    /// </para><ul><li><para>
    /// Minimum/maximum size: Set hard limits on the number of Amazon EC2 instances allowed.
    /// If Amazon GameLift receives a request--either through manual update or automatic scaling--it
    /// won't change the capacity to a value outside of this range.
    /// </para></li><li><para>
    /// Desired capacity: As an alternative to automatic scaling, manually set the number
    /// of Amazon EC2 instances to be maintained. Before changing a fleet's desired capacity,
    /// check the maximum capacity of the fleet's Amazon EC2 instance type by calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeEC2InstanceLimits.html">DescribeEC2InstanceLimits</a>.
    /// </para></li></ul><para>
    /// To update capacity for a fleet's home Region, or if the fleet has no remote locations,
    /// omit the <c>Location</c> parameter. The fleet must be in <c>ACTIVE</c> status. 
    /// </para><para>
    /// To update capacity for a fleet's remote location, set the <c>Location</c> parameter
    /// to the location to update. The location must be in <c>ACTIVE</c> status.
    /// </para><para>
    /// If successful, Amazon GameLift updates the capacity settings and returns the identifiers
    /// for the updated fleet and/or location. If a requested change to desired capacity exceeds
    /// the instance type's limit, the <c>LimitExceeded</c> exception occurs. 
    /// </para><para>
    /// Updates often prompt an immediate change in fleet capacity, such as when current capacity
    /// is different than the new desired capacity or outside the new limits. In this scenario,
    /// Amazon GameLift automatically initiates steps to add or remove instances in the fleet
    /// location. You can track a fleet's current capacity by calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeFleetCapacity.html">DescribeFleetCapacity</a>
    /// or <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_DescribeFleetLocationCapacity.html">DescribeFleetLocationCapacity</a>.
    /// 
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-manage-capacity.html">Scaling
    /// fleet capacity</a></para>
    /// </summary>
    [Cmdlet("Update", "GMLFleetCapacity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateFleetCapacity API operation.", Operation = new[] {"UpdateFleetCapacity"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateFleetCapacityResponse))]
    [AWSCmdletOutput("System.String or Amazon.GameLift.Model.UpdateFleetCapacityResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GameLift.Model.UpdateFleetCapacityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateGMLFleetCapacityCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DesiredInstance
        /// <summary>
        /// <para>
        /// <para>The number of Amazon EC2 instances you want to maintain in the specified fleet location.
        /// This value must fall between the minimum and maximum size limits. Changes in desired
        /// instance value can take up to 1 minute to be reflected when viewing the fleet's capacity
        /// settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredInstances")]
        public System.Int32? DesiredInstance { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet to update capacity settings for. You can use either
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
        
        #region Parameter Location
        /// <summary>
        /// <para>
        /// <para>The name of a remote location to update fleet capacity settings for, in the form of
        /// an Amazon Web Services Region code such as <c>us-west-2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Location { get; set; }
        #endregion
        
        #region Parameter MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of instances that are allowed in the specified fleet location.
        /// If this parameter is not set, the default is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxSize { get; set; }
        #endregion
        
        #region Parameter MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum number of instances that are allowed in the specified fleet location.
        /// If this parameter is not set, the default is 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FleetId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateFleetCapacityResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateFleetCapacityResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLFleetCapacity (UpdateFleetCapacity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateFleetCapacityResponse, UpdateGMLFleetCapacityCmdlet>(Select) ??
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
            context.DesiredInstance = this.DesiredInstance;
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Location = this.Location;
            context.MaxSize = this.MaxSize;
            context.MinSize = this.MinSize;
            
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
            var request = new Amazon.GameLift.Model.UpdateFleetCapacityRequest();
            
            if (cmdletContext.DesiredInstance != null)
            {
                request.DesiredInstances = cmdletContext.DesiredInstance.Value;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.Location != null)
            {
                request.Location = cmdletContext.Location;
            }
            if (cmdletContext.MaxSize != null)
            {
                request.MaxSize = cmdletContext.MaxSize.Value;
            }
            if (cmdletContext.MinSize != null)
            {
                request.MinSize = cmdletContext.MinSize.Value;
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
        
        private Amazon.GameLift.Model.UpdateFleetCapacityResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateFleetCapacityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateFleetCapacity");
            try
            {
                #if DESKTOP
                return client.UpdateFleetCapacity(request);
                #elif CORECLR
                return client.UpdateFleetCapacityAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DesiredInstance { get; set; }
            public System.String FleetId { get; set; }
            public System.String Location { get; set; }
            public System.Int32? MaxSize { get; set; }
            public System.Int32? MinSize { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateFleetCapacityResponse, UpdateGMLFleetCapacityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FleetId;
        }
        
    }
}
