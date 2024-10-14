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
using Amazon.VPCLattice;
using Amazon.VPCLattice.Model;

namespace Amazon.PowerShell.Cmdlets.VPCL
{
    /// <summary>
    /// Updates the specified target group.
    /// </summary>
    [Cmdlet("Update", "VPCLTargetGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VPCLattice.Model.UpdateTargetGroupResponse")]
    [AWSCmdlet("Calls the VPC Lattice UpdateTargetGroup API operation.", Operation = new[] {"UpdateTargetGroup"}, SelectReturnType = typeof(Amazon.VPCLattice.Model.UpdateTargetGroupResponse))]
    [AWSCmdletOutput("Amazon.VPCLattice.Model.UpdateTargetGroupResponse",
        "This cmdlet returns an Amazon.VPCLattice.Model.UpdateTargetGroupResponse object containing multiple properties."
    )]
    public partial class UpdateVPCLTargetGroupCmdlet : AmazonVPCLatticeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HealthCheck_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether health checking is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HealthCheck_Enabled { get; set; }
        #endregion
        
        #region Parameter HealthCheck_HealthCheckIntervalSecond
        /// <summary>
        /// <para>
        /// <para>The approximate amount of time, in seconds, between health checks of an individual
        /// target. The range is 5–300 seconds. The default is 30 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheck_HealthCheckIntervalSeconds")]
        public System.Int32? HealthCheck_HealthCheckIntervalSecond { get; set; }
        #endregion
        
        #region Parameter HealthCheck_HealthCheckTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, to wait before reporting a target as unhealthy. The
        /// range is 1–120 seconds. The default is 5 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheck_HealthCheckTimeoutSeconds")]
        public System.Int32? HealthCheck_HealthCheckTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter HealthCheck_HealthyThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive successful health checks required before considering an
        /// unhealthy target healthy. The range is 2–10. The default is 5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheck_HealthyThresholdCount { get; set; }
        #endregion
        
        #region Parameter Matcher_HttpCode
        /// <summary>
        /// <para>
        /// <para>The HTTP code to use when checking for a successful response from a target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheck_Matcher_HttpCode")]
        public System.String Matcher_HttpCode { get; set; }
        #endregion
        
        #region Parameter HealthCheck_Path
        /// <summary>
        /// <para>
        /// <para>The destination for health checks on the targets. If the protocol version is <c>HTTP/1.1</c>
        /// or <c>HTTP/2</c>, specify a valid URI (for example, <c>/path?query</c>). The default
        /// path is <c>/</c>. Health checks are not supported if the protocol version is <c>gRPC</c>,
        /// however, you can choose <c>HTTP/1.1</c> or <c>HTTP/2</c> and specify a valid URI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheck_Path { get; set; }
        #endregion
        
        #region Parameter HealthCheck_Port
        /// <summary>
        /// <para>
        /// <para>The port used when performing health checks on targets. The default setting is the
        /// port that a target receives traffic on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheck_Port { get; set; }
        #endregion
        
        #region Parameter HealthCheck_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol used when performing health checks on targets. The possible protocols
        /// are <c>HTTP</c> and <c>HTTPS</c>. The default is <c>HTTP</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VPCLattice.TargetGroupProtocol")]
        public Amazon.VPCLattice.TargetGroupProtocol HealthCheck_Protocol { get; set; }
        #endregion
        
        #region Parameter HealthCheck_ProtocolVersion
        /// <summary>
        /// <para>
        /// <para>The protocol version used when performing health checks on targets. The possible protocol
        /// versions are <c>HTTP1</c> and <c>HTTP2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VPCLattice.HealthCheckProtocolVersion")]
        public Amazon.VPCLattice.HealthCheckProtocolVersion HealthCheck_ProtocolVersion { get; set; }
        #endregion
        
        #region Parameter TargetGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or Amazon Resource Name (ARN) of the target group.</para>
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
        public System.String TargetGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter HealthCheck_UnhealthyThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive failed health checks required before considering a target
        /// unhealthy. The range is 2–10. The default is 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheck_UnhealthyThresholdCount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VPCLattice.Model.UpdateTargetGroupResponse).
        /// Specifying the name of a property of type Amazon.VPCLattice.Model.UpdateTargetGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetGroupIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetGroupIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetGroupIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetGroupIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-VPCLTargetGroup (UpdateTargetGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VPCLattice.Model.UpdateTargetGroupResponse, UpdateVPCLTargetGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetGroupIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HealthCheck_Enabled = this.HealthCheck_Enabled;
            context.HealthCheck_HealthCheckIntervalSecond = this.HealthCheck_HealthCheckIntervalSecond;
            context.HealthCheck_HealthCheckTimeoutSecond = this.HealthCheck_HealthCheckTimeoutSecond;
            context.HealthCheck_HealthyThresholdCount = this.HealthCheck_HealthyThresholdCount;
            context.Matcher_HttpCode = this.Matcher_HttpCode;
            context.HealthCheck_Path = this.HealthCheck_Path;
            context.HealthCheck_Port = this.HealthCheck_Port;
            context.HealthCheck_Protocol = this.HealthCheck_Protocol;
            context.HealthCheck_ProtocolVersion = this.HealthCheck_ProtocolVersion;
            context.HealthCheck_UnhealthyThresholdCount = this.HealthCheck_UnhealthyThresholdCount;
            context.TargetGroupIdentifier = this.TargetGroupIdentifier;
            #if MODULAR
            if (this.TargetGroupIdentifier == null && ParameterWasBound(nameof(this.TargetGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VPCLattice.Model.UpdateTargetGroupRequest();
            
            
             // populate HealthCheck
            var requestHealthCheckIsNull = true;
            request.HealthCheck = new Amazon.VPCLattice.Model.HealthCheckConfig();
            System.Boolean? requestHealthCheck_healthCheck_Enabled = null;
            if (cmdletContext.HealthCheck_Enabled != null)
            {
                requestHealthCheck_healthCheck_Enabled = cmdletContext.HealthCheck_Enabled.Value;
            }
            if (requestHealthCheck_healthCheck_Enabled != null)
            {
                request.HealthCheck.Enabled = requestHealthCheck_healthCheck_Enabled.Value;
                requestHealthCheckIsNull = false;
            }
            System.Int32? requestHealthCheck_healthCheck_HealthCheckIntervalSecond = null;
            if (cmdletContext.HealthCheck_HealthCheckIntervalSecond != null)
            {
                requestHealthCheck_healthCheck_HealthCheckIntervalSecond = cmdletContext.HealthCheck_HealthCheckIntervalSecond.Value;
            }
            if (requestHealthCheck_healthCheck_HealthCheckIntervalSecond != null)
            {
                request.HealthCheck.HealthCheckIntervalSeconds = requestHealthCheck_healthCheck_HealthCheckIntervalSecond.Value;
                requestHealthCheckIsNull = false;
            }
            System.Int32? requestHealthCheck_healthCheck_HealthCheckTimeoutSecond = null;
            if (cmdletContext.HealthCheck_HealthCheckTimeoutSecond != null)
            {
                requestHealthCheck_healthCheck_HealthCheckTimeoutSecond = cmdletContext.HealthCheck_HealthCheckTimeoutSecond.Value;
            }
            if (requestHealthCheck_healthCheck_HealthCheckTimeoutSecond != null)
            {
                request.HealthCheck.HealthCheckTimeoutSeconds = requestHealthCheck_healthCheck_HealthCheckTimeoutSecond.Value;
                requestHealthCheckIsNull = false;
            }
            System.Int32? requestHealthCheck_healthCheck_HealthyThresholdCount = null;
            if (cmdletContext.HealthCheck_HealthyThresholdCount != null)
            {
                requestHealthCheck_healthCheck_HealthyThresholdCount = cmdletContext.HealthCheck_HealthyThresholdCount.Value;
            }
            if (requestHealthCheck_healthCheck_HealthyThresholdCount != null)
            {
                request.HealthCheck.HealthyThresholdCount = requestHealthCheck_healthCheck_HealthyThresholdCount.Value;
                requestHealthCheckIsNull = false;
            }
            System.String requestHealthCheck_healthCheck_Path = null;
            if (cmdletContext.HealthCheck_Path != null)
            {
                requestHealthCheck_healthCheck_Path = cmdletContext.HealthCheck_Path;
            }
            if (requestHealthCheck_healthCheck_Path != null)
            {
                request.HealthCheck.Path = requestHealthCheck_healthCheck_Path;
                requestHealthCheckIsNull = false;
            }
            System.Int32? requestHealthCheck_healthCheck_Port = null;
            if (cmdletContext.HealthCheck_Port != null)
            {
                requestHealthCheck_healthCheck_Port = cmdletContext.HealthCheck_Port.Value;
            }
            if (requestHealthCheck_healthCheck_Port != null)
            {
                request.HealthCheck.Port = requestHealthCheck_healthCheck_Port.Value;
                requestHealthCheckIsNull = false;
            }
            Amazon.VPCLattice.TargetGroupProtocol requestHealthCheck_healthCheck_Protocol = null;
            if (cmdletContext.HealthCheck_Protocol != null)
            {
                requestHealthCheck_healthCheck_Protocol = cmdletContext.HealthCheck_Protocol;
            }
            if (requestHealthCheck_healthCheck_Protocol != null)
            {
                request.HealthCheck.Protocol = requestHealthCheck_healthCheck_Protocol;
                requestHealthCheckIsNull = false;
            }
            Amazon.VPCLattice.HealthCheckProtocolVersion requestHealthCheck_healthCheck_ProtocolVersion = null;
            if (cmdletContext.HealthCheck_ProtocolVersion != null)
            {
                requestHealthCheck_healthCheck_ProtocolVersion = cmdletContext.HealthCheck_ProtocolVersion;
            }
            if (requestHealthCheck_healthCheck_ProtocolVersion != null)
            {
                request.HealthCheck.ProtocolVersion = requestHealthCheck_healthCheck_ProtocolVersion;
                requestHealthCheckIsNull = false;
            }
            System.Int32? requestHealthCheck_healthCheck_UnhealthyThresholdCount = null;
            if (cmdletContext.HealthCheck_UnhealthyThresholdCount != null)
            {
                requestHealthCheck_healthCheck_UnhealthyThresholdCount = cmdletContext.HealthCheck_UnhealthyThresholdCount.Value;
            }
            if (requestHealthCheck_healthCheck_UnhealthyThresholdCount != null)
            {
                request.HealthCheck.UnhealthyThresholdCount = requestHealthCheck_healthCheck_UnhealthyThresholdCount.Value;
                requestHealthCheckIsNull = false;
            }
            Amazon.VPCLattice.Model.Matcher requestHealthCheck_healthCheck_Matcher = null;
            
             // populate Matcher
            var requestHealthCheck_healthCheck_MatcherIsNull = true;
            requestHealthCheck_healthCheck_Matcher = new Amazon.VPCLattice.Model.Matcher();
            System.String requestHealthCheck_healthCheck_Matcher_matcher_HttpCode = null;
            if (cmdletContext.Matcher_HttpCode != null)
            {
                requestHealthCheck_healthCheck_Matcher_matcher_HttpCode = cmdletContext.Matcher_HttpCode;
            }
            if (requestHealthCheck_healthCheck_Matcher_matcher_HttpCode != null)
            {
                requestHealthCheck_healthCheck_Matcher.HttpCode = requestHealthCheck_healthCheck_Matcher_matcher_HttpCode;
                requestHealthCheck_healthCheck_MatcherIsNull = false;
            }
             // determine if requestHealthCheck_healthCheck_Matcher should be set to null
            if (requestHealthCheck_healthCheck_MatcherIsNull)
            {
                requestHealthCheck_healthCheck_Matcher = null;
            }
            if (requestHealthCheck_healthCheck_Matcher != null)
            {
                request.HealthCheck.Matcher = requestHealthCheck_healthCheck_Matcher;
                requestHealthCheckIsNull = false;
            }
             // determine if request.HealthCheck should be set to null
            if (requestHealthCheckIsNull)
            {
                request.HealthCheck = null;
            }
            if (cmdletContext.TargetGroupIdentifier != null)
            {
                request.TargetGroupIdentifier = cmdletContext.TargetGroupIdentifier;
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
        
        private Amazon.VPCLattice.Model.UpdateTargetGroupResponse CallAWSServiceOperation(IAmazonVPCLattice client, Amazon.VPCLattice.Model.UpdateTargetGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "VPC Lattice", "UpdateTargetGroup");
            try
            {
                #if DESKTOP
                return client.UpdateTargetGroup(request);
                #elif CORECLR
                return client.UpdateTargetGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? HealthCheck_Enabled { get; set; }
            public System.Int32? HealthCheck_HealthCheckIntervalSecond { get; set; }
            public System.Int32? HealthCheck_HealthCheckTimeoutSecond { get; set; }
            public System.Int32? HealthCheck_HealthyThresholdCount { get; set; }
            public System.String Matcher_HttpCode { get; set; }
            public System.String HealthCheck_Path { get; set; }
            public System.Int32? HealthCheck_Port { get; set; }
            public Amazon.VPCLattice.TargetGroupProtocol HealthCheck_Protocol { get; set; }
            public Amazon.VPCLattice.HealthCheckProtocolVersion HealthCheck_ProtocolVersion { get; set; }
            public System.Int32? HealthCheck_UnhealthyThresholdCount { get; set; }
            public System.String TargetGroupIdentifier { get; set; }
            public System.Func<Amazon.VPCLattice.Model.UpdateTargetGroupResponse, UpdateVPCLTargetGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
