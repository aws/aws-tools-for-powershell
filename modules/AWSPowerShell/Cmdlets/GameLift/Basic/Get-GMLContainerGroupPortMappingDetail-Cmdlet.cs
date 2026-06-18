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
    /// <b>This API works with the following fleet types:</b> Container
    /// 
    ///  
    /// <para>
    /// Retrieves the port mappings for a container group running on a container fleet. Port
    /// mappings show how container ports are mapped to connection ports on the fleet instance.
    /// Use this operation to find the connection port for a specific container on a fleet
    /// instance.
    /// </para><para><b>Request options</b></para><ul><li><para>
    /// Get port mappings for a game server container group. Provide the fleet ID, set <c>ContainerGroupType</c>
    /// to <c>GAME_SERVER</c>, and specify the <c>ComputeName</c> for the game server container
    /// group.
    /// </para></li><li><para>
    /// Get port mappings for a per-instance container group. Provide the fleet ID, set <c>ContainerGroupType</c>
    /// to <c>PER_INSTANCE</c>, and specify the <c>InstanceId</c> for the instance.
    /// </para></li><li><para>
    /// Optionally filter results to a single container by providing a <c>ContainerName</c>.
    /// </para></li></ul><para><b>Results</b></para><para>
    /// This operation returns the fleet ID, fleet ARN, location, container group definition
    /// ARN, container group type, compute name (for game server container groups), instance
    /// ID, and a list of <c>ContainerGroupPortMapping</c> objects. Each object contains the
    /// container name, runtime ID, and a list of port mappings that show how container ports
    /// map to connection ports on the instance.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/containers-remote-access.html">Connect
    /// to containers</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/containers-create-groups.html">Create
    /// a container group definition</a></para>
    /// </summary>
    [Cmdlet("Get", "GMLContainerGroupPortMappingDetail")]
    [OutputType("Amazon.GameLift.Model.DescribeContainerGroupPortMappingsResponse")]
    [AWSCmdlet("Calls the Amazon GameLift Service DescribeContainerGroupPortMappings API operation.", Operation = new[] {"DescribeContainerGroupPortMappings"}, SelectReturnType = typeof(Amazon.GameLift.Model.DescribeContainerGroupPortMappingsResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.DescribeContainerGroupPortMappingsResponse",
        "This cmdlet returns an Amazon.GameLift.Model.DescribeContainerGroupPortMappingsResponse object containing multiple properties."
    )]
    public partial class GetGMLContainerGroupPortMappingDetailCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComputeName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the compute resource for which to retrieve port mappings.
        /// For a container fleet, a compute represents a game server container group running
        /// on a fleet instance. You can use either the compute name or ARN value.</para><para>When <c>ContainerGroupType</c> is <c>GAME_SERVER</c>, this parameter is required.</para><para>When <c>ContainerGroupType</c> is <c>PER_INSTANCE</c>, do not provide this parameter.
        /// If you provide a compute name with <c>PER_INSTANCE</c>, the request fails with an
        /// <c>InvalidRequestException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeName { get; set; }
        #endregion
        
        #region Parameter ContainerGroupType
        /// <summary>
        /// <para>
        /// <para>The type of container group to retrieve port mappings for.</para><ul><li><para><c>GAME_SERVER</c> -- Get port mappings for a game server container group.</para></li><li><para><c>PER_INSTANCE</c> -- Get port mappings for a per-instance container group.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GameLift.ContainerGroupType")]
        public Amazon.GameLift.ContainerGroupType ContainerGroupType { get; set; }
        #endregion
        
        #region Parameter ContainerName
        /// <summary>
        /// <para>
        /// <para>A container name to filter the results. When provided, the operation returns port
        /// mappings for the specified container only. If no container with the specified name
        /// exists in the container group, the request fails with a <c>NotFoundException</c>.</para><para>If not provided, the operation returns port mappings for all containers in the container
        /// group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerName { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the container fleet. You can use either the fleet ID or ARN
        /// value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet instance to retrieve port mappings for.</para><para>When <c>ContainerGroupType</c> is <c>PER_INSTANCE</c>, this parameter is required.</para><para>When <c>ContainerGroupType</c> is <c>GAME_SERVER</c>, this parameter is optional.
        /// If you provide an instance ID, it must match the instance that's running the specified
        /// compute. If the instance ID doesn't match, the request fails with an <c>InvalidRequestException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.DescribeContainerGroupPortMappingsResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.DescribeContainerGroupPortMappingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.DescribeContainerGroupPortMappingsResponse, GetGMLContainerGroupPortMappingDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComputeName = this.ComputeName;
            context.ContainerGroupType = this.ContainerGroupType;
            #if MODULAR
            if (this.ContainerGroupType == null && ParameterWasBound(nameof(this.ContainerGroupType)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerGroupType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContainerName = this.ContainerName;
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            
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
            var request = new Amazon.GameLift.Model.DescribeContainerGroupPortMappingsRequest();
            
            if (cmdletContext.ComputeName != null)
            {
                request.ComputeName = cmdletContext.ComputeName;
            }
            if (cmdletContext.ContainerGroupType != null)
            {
                request.ContainerGroupType = cmdletContext.ContainerGroupType;
            }
            if (cmdletContext.ContainerName != null)
            {
                request.ContainerName = cmdletContext.ContainerName;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.GameLift.Model.DescribeContainerGroupPortMappingsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DescribeContainerGroupPortMappingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DescribeContainerGroupPortMappings");
            try
            {
                return client.DescribeContainerGroupPortMappingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ComputeName { get; set; }
            public Amazon.GameLift.ContainerGroupType ContainerGroupType { get; set; }
            public System.String ContainerName { get; set; }
            public System.String FleetId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.GameLift.Model.DescribeContainerGroupPortMappingsResponse, GetGMLContainerGroupPortMappingDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
