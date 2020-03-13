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
    /// Updates capacity settings for a fleet. Use this action to specify the number of EC2
    /// instances (hosts) that you want this fleet to contain. Before calling this action,
    /// you may want to call <a>DescribeEC2InstanceLimits</a> to get the maximum capacity
    /// based on the fleet's EC2 instance type.
    /// 
    ///  
    /// <para>
    /// Specify minimum and maximum number of instances. Amazon GameLift will not change fleet
    /// capacity to values fall outside of this range. This is particularly important when
    /// using auto-scaling (see <a>PutScalingPolicy</a>) to allow capacity to adjust based
    /// on player demand while imposing limits on automatic adjustments.
    /// </para><para>
    /// To update fleet capacity, specify the fleet ID and the number of instances you want
    /// the fleet to host. If successful, Amazon GameLift starts or terminates instances so
    /// that the fleet's active instance count matches the desired instance count. You can
    /// view a fleet's current capacity information by calling <a>DescribeFleetCapacity</a>.
    /// If the desired instance count is higher than the instance type's limit, the "Limit
    /// Exceeded" exception occurs.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-intro.html">Setting
    /// up GameLift Fleets</a></para><para><b>Related operations</b></para><ul><li><para><a>CreateFleet</a></para></li><li><para><a>ListFleets</a></para></li><li><para><a>DeleteFleet</a></para></li><li><para><a>DescribeFleetAttributes</a></para></li><li><para>
    /// Update fleets:
    /// </para><ul><li><para><a>UpdateFleetAttributes</a></para></li><li><para><a>UpdateFleetCapacity</a></para></li><li><para><a>UpdateFleetPortSettings</a></para></li><li><para><a>UpdateRuntimeConfiguration</a></para></li></ul></li><li><para><a>StartFleetActions</a> or <a>StopFleetActions</a></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "GMLFleetCapacity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateFleetCapacity API operation.", Operation = new[] {"UpdateFleetCapacity"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateFleetCapacityResponse))]
    [AWSCmdletOutput("System.String or Amazon.GameLift.Model.UpdateFleetCapacityResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GameLift.Model.UpdateFleetCapacityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGMLFleetCapacityCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter DesiredInstance
        /// <summary>
        /// <para>
        /// <para>Number of EC2 instances you want this fleet to host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredInstances")]
        public System.Int32? DesiredInstance { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a fleet to update capacity for. You can use either the fleet
        /// ID or ARN value.</para>
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
        
        #region Parameter MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum value allowed for the fleet's instance count. Default if not set is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxSize { get; set; }
        #endregion
        
        #region Parameter MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum value allowed for the fleet's instance count. Default if not set is 0.</para>
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
            public System.Int32? MaxSize { get; set; }
            public System.Int32? MinSize { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateFleetCapacityResponse, UpdateGMLFleetCapacityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FleetId;
        }
        
    }
}
