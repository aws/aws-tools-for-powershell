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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Launches a specified number of instances in an Auto Scaling group. Returns instance
    /// IDs and other details if launch is successful or error details if launch is unsuccessful.
    /// </summary>
    [Cmdlet("Add", "ASInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AutoScaling.Model.LaunchInstancesResponse")]
    [AWSCmdlet("Calls the AWS Auto Scaling LaunchInstances API operation.", Operation = new[] {"LaunchInstances"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.LaunchInstancesResponse))]
    [AWSCmdletOutput("Amazon.AutoScaling.Model.LaunchInstancesResponse",
        "This cmdlet returns an Amazon.AutoScaling.Model.LaunchInstancesResponse object containing multiple properties."
    )]
    public partial class AddASInstanceCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the Auto Scaling group to launch instances into. </para>
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
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para> A list of Availability Zone IDs where instances should be launched. Must match or
        /// be included in the group's AZ configuration. You cannot specify both AvailabilityZones
        /// and AvailabilityZoneIds. Required for multi-AZ groups, optional for single-AZ groups.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZoneIds")]
        public System.String[] AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para> The Availability Zones for the instance launch. Must match or be included in the
        /// Auto Scaling group's Availability Zone configuration. Either <c>AvailabilityZones</c>
        /// or <c>SubnetIds</c> must be specified for groups with multiple Availability Zone configurations.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter RequestedCapacity
        /// <summary>
        /// <para>
        /// <para> The number of instances to launch. Although this value can exceed 100 for instance
        /// weights, the actual instance count is limited to 100 instances per launch. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? RequestedCapacity { get; set; }
        #endregion
        
        #region Parameter RetryStrategy
        /// <summary>
        /// <para>
        /// <para> Specifies whether to retry asynchronously if the synchronous launch fails. Valid
        /// values are NONE (default, no async retry) and RETRY_WITH_GROUP_CONFIGURATION (increase
        /// desired capacity and retry with group configuration). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AutoScaling.RetryStrategy")]
        public Amazon.AutoScaling.RetryStrategy RetryStrategy { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para> The subnet IDs for the instance launch. Either <c>AvailabilityZones</c> or <c>SubnetIds</c>
        /// must be specified. If both are specified, the subnets must reside in the specified
        /// Availability Zones. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique, case-sensitive identifier to ensure idempotency of the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.LaunchInstancesResponse).
        /// Specifying the name of a property of type Amazon.AutoScaling.Model.LaunchInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-ASInstance (LaunchInstances)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.LaunchInstancesResponse, AddASInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AvailabilityZoneId != null)
            {
                context.AvailabilityZoneId = new List<System.String>(this.AvailabilityZoneId);
            }
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZone = new List<System.String>(this.AvailabilityZone);
            }
            context.ClientToken = this.ClientToken;
            context.RequestedCapacity = this.RequestedCapacity;
            #if MODULAR
            if (this.RequestedCapacity == null && ParameterWasBound(nameof(this.RequestedCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestedCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetryStrategy = this.RetryStrategy;
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            
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
            var request = new Amazon.AutoScaling.Model.LaunchInstancesRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneIds = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.RequestedCapacity != null)
            {
                request.RequestedCapacity = cmdletContext.RequestedCapacity.Value;
            }
            if (cmdletContext.RetryStrategy != null)
            {
                request.RetryStrategy = cmdletContext.RetryStrategy;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
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
        
        private Amazon.AutoScaling.Model.LaunchInstancesResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.LaunchInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "LaunchInstances");
            try
            {
                return client.LaunchInstancesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AutoScalingGroupName { get; set; }
            public List<System.String> AvailabilityZoneId { get; set; }
            public List<System.String> AvailabilityZone { get; set; }
            public System.String ClientToken { get; set; }
            public System.Int32? RequestedCapacity { get; set; }
            public Amazon.AutoScaling.RetryStrategy RetryStrategy { get; set; }
            public List<System.String> SubnetId { get; set; }
            public System.Func<Amazon.AutoScaling.Model.LaunchInstancesResponse, AddASInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
