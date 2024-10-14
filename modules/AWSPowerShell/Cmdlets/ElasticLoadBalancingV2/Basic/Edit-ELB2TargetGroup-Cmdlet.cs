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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Modifies the health checks used when evaluating the health state of the targets in
    /// the specified target group.
    /// </summary>
    [Cmdlet("Edit", "ELB2TargetGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.TargetGroup")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 ModifyTargetGroup API operation.", Operation = new[] {"ModifyTargetGroup"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.TargetGroup or Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.TargetGroup objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditELB2TargetGroupCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Matcher_GrpcCode
        /// <summary>
        /// <para>
        /// <para>You can specify values between 0 and 99. You can specify multiple values (for example,
        /// "0,1") or a range of values (for example, "0-5"). The default value is 12.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Matcher_GrpcCode { get; set; }
        #endregion
        
        #region Parameter HealthCheckEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether health checks are enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HealthCheckEnabled { get; set; }
        #endregion
        
        #region Parameter HealthCheckIntervalSecond
        /// <summary>
        /// <para>
        /// <para>The approximate amount of time, in seconds, between health checks of an individual
        /// target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckIntervalSeconds")]
        public System.Int32? HealthCheckIntervalSecond { get; set; }
        #endregion
        
        #region Parameter HealthCheckPath
        /// <summary>
        /// <para>
        /// <para>[HTTP/HTTPS health checks] The destination for health checks on the targets.</para><para>[HTTP1 or HTTP2 protocol version] The ping path. The default is /.</para><para>[GRPC protocol version] The path of a custom health check method with the format /package.service/method.
        /// The default is /Amazon Web Services.ALB/healthcheck.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckPath { get; set; }
        #endregion
        
        #region Parameter HealthCheckPort
        /// <summary>
        /// <para>
        /// <para>The port the load balancer uses when performing health checks on targets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckPort { get; set; }
        #endregion
        
        #region Parameter HealthCheckProtocol
        /// <summary>
        /// <para>
        /// <para>The protocol the load balancer uses when performing health checks on targets. For
        /// Application Load Balancers, the default is HTTP. For Network Load Balancers and Gateway
        /// Load Balancers, the default is TCP. The TCP protocol is not supported for health checks
        /// if the protocol of the target group is HTTP or HTTPS. It is supported for health checks
        /// only if the protocol of the target group is TCP, TLS, UDP, or TCP_UDP. The GENEVE,
        /// TLS, UDP, and TCP_UDP protocols are not supported for health checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.ProtocolEnum")]
        public Amazon.ElasticLoadBalancingV2.ProtocolEnum HealthCheckProtocol { get; set; }
        #endregion
        
        #region Parameter HealthCheckTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>[HTTP/HTTPS health checks] The amount of time, in seconds, during which no response
        /// means a failed health check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckTimeoutSeconds")]
        public System.Int32? HealthCheckTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter HealthyThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks successes required before considering an unhealthy
        /// target healthy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthyThresholdCount { get; set; }
        #endregion
        
        #region Parameter Matcher_HttpCode
        /// <summary>
        /// <para>
        /// <para>For Application Load Balancers, you can specify values between 200 and 499, with the
        /// default value being 200. You can specify multiple values (for example, "200,202")
        /// or a range of values (for example, "200-299").</para><para>For Network Load Balancers, you can specify values between 200 and 599, with the default
        /// value being 200-399. You can specify multiple values (for example, "200,202") or a
        /// range of values (for example, "200-299").</para><para>For Gateway Load Balancers, this must be "200–399".</para><para>Note that when using shorthand syntax, some values such as commas need to be escaped.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Matcher_HttpCode { get; set; }
        #endregion
        
        #region Parameter TargetGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the target group.</para>
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
        public System.String TargetGroupArn { get; set; }
        #endregion
        
        #region Parameter UnhealthyThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health check failures required before considering the target
        /// unhealthy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UnhealthyThresholdCount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TargetGroups'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TargetGroups";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetGroupArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetGroupArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetGroupArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetGroupArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ELB2TargetGroup (ModifyTargetGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupResponse, EditELB2TargetGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetGroupArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HealthCheckEnabled = this.HealthCheckEnabled;
            context.HealthCheckIntervalSecond = this.HealthCheckIntervalSecond;
            context.HealthCheckPath = this.HealthCheckPath;
            context.HealthCheckPort = this.HealthCheckPort;
            context.HealthCheckProtocol = this.HealthCheckProtocol;
            context.HealthCheckTimeoutSecond = this.HealthCheckTimeoutSecond;
            context.HealthyThresholdCount = this.HealthyThresholdCount;
            context.Matcher_GrpcCode = this.Matcher_GrpcCode;
            context.Matcher_HttpCode = this.Matcher_HttpCode;
            context.TargetGroupArn = this.TargetGroupArn;
            #if MODULAR
            if (this.TargetGroupArn == null && ParameterWasBound(nameof(this.TargetGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UnhealthyThresholdCount = this.UnhealthyThresholdCount;
            
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupRequest();
            
            if (cmdletContext.HealthCheckEnabled != null)
            {
                request.HealthCheckEnabled = cmdletContext.HealthCheckEnabled.Value;
            }
            if (cmdletContext.HealthCheckIntervalSecond != null)
            {
                request.HealthCheckIntervalSeconds = cmdletContext.HealthCheckIntervalSecond.Value;
            }
            if (cmdletContext.HealthCheckPath != null)
            {
                request.HealthCheckPath = cmdletContext.HealthCheckPath;
            }
            if (cmdletContext.HealthCheckPort != null)
            {
                request.HealthCheckPort = cmdletContext.HealthCheckPort;
            }
            if (cmdletContext.HealthCheckProtocol != null)
            {
                request.HealthCheckProtocol = cmdletContext.HealthCheckProtocol;
            }
            if (cmdletContext.HealthCheckTimeoutSecond != null)
            {
                request.HealthCheckTimeoutSeconds = cmdletContext.HealthCheckTimeoutSecond.Value;
            }
            if (cmdletContext.HealthyThresholdCount != null)
            {
                request.HealthyThresholdCount = cmdletContext.HealthyThresholdCount.Value;
            }
            
             // populate Matcher
            var requestMatcherIsNull = true;
            request.Matcher = new Amazon.ElasticLoadBalancingV2.Model.Matcher();
            System.String requestMatcher_matcher_GrpcCode = null;
            if (cmdletContext.Matcher_GrpcCode != null)
            {
                requestMatcher_matcher_GrpcCode = cmdletContext.Matcher_GrpcCode;
            }
            if (requestMatcher_matcher_GrpcCode != null)
            {
                request.Matcher.GrpcCode = requestMatcher_matcher_GrpcCode;
                requestMatcherIsNull = false;
            }
            System.String requestMatcher_matcher_HttpCode = null;
            if (cmdletContext.Matcher_HttpCode != null)
            {
                requestMatcher_matcher_HttpCode = cmdletContext.Matcher_HttpCode;
            }
            if (requestMatcher_matcher_HttpCode != null)
            {
                request.Matcher.HttpCode = requestMatcher_matcher_HttpCode;
                requestMatcherIsNull = false;
            }
             // determine if request.Matcher should be set to null
            if (requestMatcherIsNull)
            {
                request.Matcher = null;
            }
            if (cmdletContext.TargetGroupArn != null)
            {
                request.TargetGroupArn = cmdletContext.TargetGroupArn;
            }
            if (cmdletContext.UnhealthyThresholdCount != null)
            {
                request.UnhealthyThresholdCount = cmdletContext.UnhealthyThresholdCount.Value;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "ModifyTargetGroup");
            try
            {
                #if DESKTOP
                return client.ModifyTargetGroup(request);
                #elif CORECLR
                return client.ModifyTargetGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? HealthCheckEnabled { get; set; }
            public System.Int32? HealthCheckIntervalSecond { get; set; }
            public System.String HealthCheckPath { get; set; }
            public System.String HealthCheckPort { get; set; }
            public Amazon.ElasticLoadBalancingV2.ProtocolEnum HealthCheckProtocol { get; set; }
            public System.Int32? HealthCheckTimeoutSecond { get; set; }
            public System.Int32? HealthyThresholdCount { get; set; }
            public System.String Matcher_GrpcCode { get; set; }
            public System.String Matcher_HttpCode { get; set; }
            public System.String TargetGroupArn { get; set; }
            public System.Int32? UnhealthyThresholdCount { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupResponse, EditELB2TargetGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TargetGroups;
        }
        
    }
}
