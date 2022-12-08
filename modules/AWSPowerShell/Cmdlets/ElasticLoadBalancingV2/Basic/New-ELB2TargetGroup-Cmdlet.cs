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
    /// Creates a target group.
    /// 
    ///  
    /// <para>
    /// For more information, see the following:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/load-balancer-target-groups.html">Target
    /// groups for your Application Load Balancers</a></para></li><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/load-balancer-target-groups.html">Target
    /// groups for your Network Load Balancers</a></para></li><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/gateway/target-groups.html">Target
    /// groups for your Gateway Load Balancers</a></para></li></ul><para>
    /// This operation is idempotent, which means that it completes at most one time. If you
    /// attempt to create multiple target groups with the same settings, each call succeeds.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELB2TargetGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.TargetGroup")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 CreateTargetGroup API operation.", Operation = new[] {"CreateTargetGroup"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.CreateTargetGroupResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.TargetGroup or Amazon.ElasticLoadBalancingV2.Model.CreateTargetGroupResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.TargetGroup objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.CreateTargetGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewELB2TargetGroupCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
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
        /// <para>Indicates whether health checks are enabled. If the target type is <code>lambda</code>,
        /// health checks are disabled by default but can be enabled. If the target type is <code>instance</code>,
        /// <code>ip</code>, or <code>alb</code>, health checks are always enabled and cannot
        /// be disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HealthCheckEnabled { get; set; }
        #endregion
        
        #region Parameter HealthCheckIntervalSecond
        /// <summary>
        /// <para>
        /// <para>The approximate amount of time, in seconds, between health checks of an individual
        /// target. The range is 5-300. If the target group protocol is TCP, TLS, UDP, TCP_UDP,
        /// HTTP or HTTPS, the default is 30 seconds. If the target group protocol is GENEVE,
        /// the default is 10 seconds. If the target type is <code>lambda</code>, the default
        /// is 35 seconds.</para>
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
        /// <para>The port the load balancer uses when performing health checks on targets. If the protocol
        /// is HTTP, HTTPS, TCP, TLS, UDP, or TCP_UDP, the default is <code>traffic-port</code>,
        /// which is the port on which each target receives traffic from the load balancer. If
        /// the protocol is GENEVE, the default is port 80.</para>
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
        /// if the protocol of the target group is HTTP or HTTPS. The GENEVE, TLS, UDP, and TCP_UDP
        /// protocols are not supported for health checks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.ProtocolEnum")]
        public Amazon.ElasticLoadBalancingV2.ProtocolEnum HealthCheckProtocol { get; set; }
        #endregion
        
        #region Parameter HealthCheckTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, during which no response from a target means a failed
        /// health check. The range is 2–120 seconds. For target groups with a protocol of HTTP,
        /// the default is 6 seconds. For target groups with a protocol of TCP, TLS or HTTPS,
        /// the default is 10 seconds. For target groups with a protocol of GENEVE, the default
        /// is 5 seconds. If the target type is <code>lambda</code>, the default is 30 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckTimeoutSeconds")]
        public System.Int32? HealthCheckTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter HealthyThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health check successes required before considering a target
        /// healthy. The range is 2-10. If the target group protocol is TCP, TCP_UDP, UDP, TLS,
        /// HTTP or HTTPS, the default is 5. For target groups with a protocol of GENEVE, the
        /// default is 3. If the target type is <code>lambda</code>, the default is 5.</para>
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
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The type of IP address used for this target group. The possible values are <code>ipv4</code>
        /// and <code>ipv6</code>. This is an optional parameter. If not specified, the IP address
        /// type defaults to <code>ipv4</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.TargetGroupIpAddressTypeEnum")]
        public Amazon.ElasticLoadBalancingV2.TargetGroupIpAddressTypeEnum IpAddressType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the target group.</para><para>This name must be unique per region per account, can have a maximum of 32 characters,
        /// must contain only alphanumeric characters or hyphens, and must not begin or end with
        /// a hyphen.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port on which the targets receive traffic. This port is used unless you specify
        /// a port override when registering the target. If the target is a Lambda function, this
        /// parameter does not apply. If the protocol is GENEVE, the supported port is 6081.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol to use for routing traffic to the targets. For Application Load Balancers,
        /// the supported protocols are HTTP and HTTPS. For Network Load Balancers, the supported
        /// protocols are TCP, TLS, UDP, or TCP_UDP. For Gateway Load Balancers, the supported
        /// protocol is GENEVE. A TCP_UDP listener must be associated with a TCP_UDP target group.
        /// If the target is a Lambda function, this parameter does not apply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.ProtocolEnum")]
        public Amazon.ElasticLoadBalancingV2.ProtocolEnum Protocol { get; set; }
        #endregion
        
        #region Parameter ProtocolVersion
        /// <summary>
        /// <para>
        /// <para>[HTTP/HTTPS protocol] The protocol version. Specify <code>GRPC</code> to send requests
        /// to targets using gRPC. Specify <code>HTTP2</code> to send requests to targets using
        /// HTTP/2. The default is <code>HTTP1</code>, which sends requests to targets using HTTP/1.1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProtocolVersion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the target group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticLoadBalancingV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetType
        /// <summary>
        /// <para>
        /// <para>The type of target that you must specify when registering targets with this target
        /// group. You can't specify targets for a target group using more than one target type.</para><ul><li><para><code>instance</code> - Register targets by instance ID. This is the default value.</para></li><li><para><code>ip</code> - Register targets by IP address. You can specify IP addresses from
        /// the subnets of the virtual private cloud (VPC) for the target group, the RFC 1918
        /// range (10.0.0.0/8, 172.16.0.0/12, and 192.168.0.0/16), and the RFC 6598 range (100.64.0.0/10).
        /// You can't specify publicly routable IP addresses.</para></li><li><para><code>lambda</code> - Register a single Lambda function as a target.</para></li><li><para><code>alb</code> - Register a single Application Load Balancer as a target.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.TargetTypeEnum")]
        public Amazon.ElasticLoadBalancingV2.TargetTypeEnum TargetType { get; set; }
        #endregion
        
        #region Parameter UnhealthyThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health check failures required before considering a target
        /// unhealthy. The range is 2-10. If the target group protocol is TCP, TCP_UDP, UDP, TLS,
        /// HTTP or HTTPS, the default is 2. For target groups with a protocol of GENEVE, the
        /// default is 3. If the target type is <code>lambda</code>, the default is 5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UnhealthyThresholdCount { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The identifier of the virtual private cloud (VPC). If the target is a Lambda function,
        /// this parameter does not apply. Otherwise, this parameter is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TargetGroups'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.CreateTargetGroupResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.CreateTargetGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TargetGroups";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELB2TargetGroup (CreateTargetGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.CreateTargetGroupResponse, NewELB2TargetGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HealthCheckEnabled = this.HealthCheckEnabled;
            context.HealthCheckIntervalSecond = this.HealthCheckIntervalSecond;
            context.HealthCheckPath = this.HealthCheckPath;
            context.HealthCheckPort = this.HealthCheckPort;
            context.HealthCheckProtocol = this.HealthCheckProtocol;
            context.HealthCheckTimeoutSecond = this.HealthCheckTimeoutSecond;
            context.HealthyThresholdCount = this.HealthyThresholdCount;
            context.IpAddressType = this.IpAddressType;
            context.Matcher_GrpcCode = this.Matcher_GrpcCode;
            context.Matcher_HttpCode = this.Matcher_HttpCode;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Port = this.Port;
            context.Protocol = this.Protocol;
            context.ProtocolVersion = this.ProtocolVersion;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticLoadBalancingV2.Model.Tag>(this.Tag);
            }
            context.TargetType = this.TargetType;
            context.UnhealthyThresholdCount = this.UnhealthyThresholdCount;
            context.VpcId = this.VpcId;
            
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.CreateTargetGroupRequest();
            
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
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.ProtocolVersion != null)
            {
                request.ProtocolVersion = cmdletContext.ProtocolVersion;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetType != null)
            {
                request.TargetType = cmdletContext.TargetType;
            }
            if (cmdletContext.UnhealthyThresholdCount != null)
            {
                request.UnhealthyThresholdCount = cmdletContext.UnhealthyThresholdCount.Value;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.CreateTargetGroupResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.CreateTargetGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "CreateTargetGroup");
            try
            {
                #if DESKTOP
                return client.CreateTargetGroup(request);
                #elif CORECLR
                return client.CreateTargetGroupAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ElasticLoadBalancingV2.TargetGroupIpAddressTypeEnum IpAddressType { get; set; }
            public System.String Matcher_GrpcCode { get; set; }
            public System.String Matcher_HttpCode { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Port { get; set; }
            public Amazon.ElasticLoadBalancingV2.ProtocolEnum Protocol { get; set; }
            public System.String ProtocolVersion { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.Tag> Tag { get; set; }
            public Amazon.ElasticLoadBalancingV2.TargetTypeEnum TargetType { get; set; }
            public System.Int32? UnhealthyThresholdCount { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.CreateTargetGroupResponse, NewELB2TargetGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TargetGroups;
        }
        
    }
}
