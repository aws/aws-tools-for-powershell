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

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Retrieves properties for a specific compute resource in an Amazon GameLift fleet.
    /// You can list all computes in a fleet by calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_ListCompute.html">ListCompute</a>.
    /// 
    /// 
    ///  
    /// <para><b>Request options</b></para><para>
    /// Provide the fleet ID and compute name. The compute name varies depending on the type
    /// of fleet.
    /// </para><ul><li><para>
    /// For a compute in a managed EC2 fleet, provide an instance ID. Each instance in the
    /// fleet is a compute.
    /// </para></li><li><para>
    /// For a compute in a managed container fleet, provide a compute name. In a container
    /// fleet, each game server container group on a fleet instance is assigned a compute
    /// name.
    /// </para></li><li><para>
    /// For a compute in an Anywhere fleet, provide a registered compute name. Anywhere fleet
    /// computes are created when you register a hosting resource with the fleet.
    /// </para></li></ul><para><b>Results</b></para><para>
    /// If successful, this operation returns details for the requested compute resource.
    /// Depending on the fleet's compute type, the result includes the following information:
    /// 
    /// </para><ul><li><para>
    /// For a managed EC2 fleet, this operation returns information about the EC2 instance.
    /// </para></li><li><para>
    /// For an Anywhere fleet, this operation returns information about the registered compute.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "GMLCompute")]
    [OutputType("Amazon.GameLift.Model.Compute")]
    [AWSCmdlet("Calls the Amazon GameLift Service DescribeCompute API operation.", Operation = new[] {"DescribeCompute"}, SelectReturnType = typeof(Amazon.GameLift.Model.DescribeComputeResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.Compute or Amazon.GameLift.Model.DescribeComputeResponse",
        "This cmdlet returns an Amazon.GameLift.Model.Compute object.",
        "The service call response (type Amazon.GameLift.Model.DescribeComputeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGMLComputeCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComputeName
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the compute resource to retrieve properties for. For a managed
        /// container fleet or Anywhere fleet, use a compute name. For an EC2 fleet, use an instance
        /// ID. To retrieve a fleet's compute identifiers, call <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_ListCompute.html">ListCompute</a>.</para>
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
        public System.String ComputeName { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet that the compute belongs to. You can use either
        /// the fleet ID or ARN value.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Compute'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.DescribeComputeResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.DescribeComputeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Compute";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.DescribeComputeResponse, GetGMLComputeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComputeName = this.ComputeName;
            #if MODULAR
            if (this.ComputeName == null && ParameterWasBound(nameof(this.ComputeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.GameLift.Model.DescribeComputeRequest();
            
            if (cmdletContext.ComputeName != null)
            {
                request.ComputeName = cmdletContext.ComputeName;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
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
        
        private Amazon.GameLift.Model.DescribeComputeResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DescribeComputeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DescribeCompute");
            try
            {
                return client.DescribeComputeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FleetId { get; set; }
            public System.Func<Amazon.GameLift.Model.DescribeComputeResponse, GetGMLComputeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Compute;
        }
        
    }
}
