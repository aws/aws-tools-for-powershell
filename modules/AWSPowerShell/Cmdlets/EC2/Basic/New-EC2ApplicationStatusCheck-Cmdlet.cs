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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates an application status check for monitoring the health of applications running
    /// on your instances. You can configure the protocol, port, path, and thresholds for
    /// the health check. The following rules apply:
    /// 
    ///  <ul><li><para>
    /// You can create a maximum of 50 application status checks per account.
    /// </para></li><li><para>
    /// Health checks do not start until you associate the check with instances or tags using
    /// <c>AssociateApplicationStatusCheck</c>.
    /// </para></li><li><para>
    /// The <c>Timeout</c> value must be less than the <c>Interval</c> value.
    /// </para></li><li><para>
    /// The <c>Path</c> must start with a forward slash (<c>/</c>). Default: <c>/</c>.
    /// </para></li><li><para>
    /// If you do not specify <c>Aggregation</c>, it defaults to <c>included</c>, which means
    /// the check contributes to the instance-level application status.
    /// </para></li><li><para>
    /// Default values: <c>Interval</c> is 60 seconds, <c>Timeout</c> is 6 seconds, <c>FailureThreshold</c>
    /// is 2, <c>SuccessThreshold</c> is 5, <c>StatusCodeMatcher</c> is <c>200</c>, <c>InitializationGracePeriodSeconds</c>
    /// is 300 seconds.
    /// </para></li><li><para>
    /// You can tag the application status check during creation. For more information, see
    /// <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html">Tag
    /// your Amazon EC2 resources</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "EC2ApplicationStatusCheck", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ApplicationStatusCheckResponseObject")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateApplicationStatusCheck API operation.", Operation = new[] {"CreateApplicationStatusCheck"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateApplicationStatusCheckResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ApplicationStatusCheckResponseObject or Amazon.EC2.Model.CreateApplicationStatusCheckResponse",
        "This cmdlet returns an Amazon.EC2.Model.ApplicationStatusCheckResponseObject object.",
        "The service call response (type Amazon.EC2.Model.CreateApplicationStatusCheckResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2ApplicationStatusCheckCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Aggregation
        /// <summary>
        /// <para>
        /// <para>The aggregation setting for the application status check. When set to <c>included</c>,
        /// the result of this check contributes to the instance-level application status reported
        /// by <c>DescribeApplicationStatus</c>. When set to <c>excluded</c>, the check runs independently
        /// and does not affect the instance-level status. Valid values: <c>included</c> | <c>excluded</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.AggregationStatusEnum")]
        public Amazon.EC2.AggregationStatusEnum Aggregation { get; set; }
        #endregion
        
        #region Parameter DeviceIndex
        /// <summary>
        /// <para>
        /// <para>The index of the network device to use for the health check. The value must be greater
        /// than or equal to 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DeviceIndex { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the operation, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter FailureThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive failed health checks before the application status is considered
        /// impaired. The value must be greater than 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? FailureThreshold { get; set; }
        #endregion
        
        #region Parameter HealthCheckPath
        /// <summary>
        /// <para>
        /// <para>The health check paths to use for the application status check. Health check paths
        /// define the network path from a source subnet to one or more destination subnets for
        /// cross-Availability Zone or Availability Zone to Local Zone health checking. If omitted,
        /// health checks are performed in the same subnet as the instance.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckPaths")]
        public Amazon.EC2.Model.HealthCheckPathRequestObject[] HealthCheckPath { get; set; }
        #endregion
        
        #region Parameter InitializationGracePeriodSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds to wait before starting health checks after an instance is launched.
        /// Valid values: 1 to 600.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InitializationGracePeriodSeconds")]
        public System.Int32? InitializationGracePeriodSecond { get; set; }
        #endregion
        
        #region Parameter Interval
        /// <summary>
        /// <para>
        /// <para>The interval, in seconds, between health checks. Valid value: 60.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Interval { get; set; }
        #endregion
        
        #region Parameter IpScope
        /// <summary>
        /// <para>
        /// <para>The IP scope to use for the health check. Valid value: <c>private</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpScopeEnum")]
        public Amazon.EC2.IpScopeEnum IpScope { get; set; }
        #endregion
        
        #region Parameter IpVersion
        /// <summary>
        /// <para>
        /// <para>The IP version to use for the health check. Valid values: <c>ipv4</c> and <c>ipv6</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.IpVersionEnum")]
        public Amazon.EC2.IpVersionEnum IpVersion { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The URL path to use for the health check HTTP request (for example, <c>/health</c>
        /// or <c>/status</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port to use for the health check. Valid values: 1 to 65535.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol to use for the health check. Valid values: <c>http</c> | <c>https</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.NetworkProtocolEnum")]
        public Amazon.EC2.NetworkProtocolEnum Protocol { get; set; }
        #endregion
        
        #region Parameter StatusCodeMatcher
        /// <summary>
        /// <para>
        /// <para>The HTTP status codes that indicate a successful health check response. Specify a
        /// comma-separated list of individual status codes or ranges, for example, <c>200,202,300-399</c>.
        /// For a range, the first value must be less than the second value. Maximum length: 64
        /// characters. Default: <c>200</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StatusCodeMatcher { get; set; }
        #endregion
        
        #region Parameter SuccessThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive successful health checks before the application status is
        /// considered healthy. The value must be greater than 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SuccessThreshold { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the application status check.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, to wait for a health check response before considering
        /// it failed. Valid values: 1 to 30. The value must be less than <c>Interval</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationStatusCheck'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateApplicationStatusCheckResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateApplicationStatusCheckResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationStatusCheck";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2ApplicationStatusCheck (CreateApplicationStatusCheck)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateApplicationStatusCheckResponse, NewEC2ApplicationStatusCheckCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Aggregation = this.Aggregation;
            context.ClientToken = this.ClientToken;
            context.DeviceIndex = this.DeviceIndex;
            context.DryRun = this.DryRun;
            context.FailureThreshold = this.FailureThreshold;
            if (this.HealthCheckPath != null)
            {
                context.HealthCheckPath = new List<Amazon.EC2.Model.HealthCheckPathRequestObject>(this.HealthCheckPath);
            }
            context.InitializationGracePeriodSecond = this.InitializationGracePeriodSecond;
            context.Interval = this.Interval;
            context.IpScope = this.IpScope;
            context.IpVersion = this.IpVersion;
            context.Path = this.Path;
            context.Port = this.Port;
            #if MODULAR
            if (this.Port == null && ParameterWasBound(nameof(this.Port)))
            {
                WriteWarning("You are passing $null as a value for parameter Port which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Protocol = this.Protocol;
            #if MODULAR
            if (this.Protocol == null && ParameterWasBound(nameof(this.Protocol)))
            {
                WriteWarning("You are passing $null as a value for parameter Protocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StatusCodeMatcher = this.StatusCodeMatcher;
            context.SuccessThreshold = this.SuccessThreshold;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.Timeout = this.Timeout;
            
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
            var request = new Amazon.EC2.Model.CreateApplicationStatusCheckRequest();
            
            if (cmdletContext.Aggregation != null)
            {
                request.Aggregation = cmdletContext.Aggregation;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeviceIndex != null)
            {
                request.DeviceIndex = cmdletContext.DeviceIndex.Value;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.FailureThreshold != null)
            {
                request.FailureThreshold = cmdletContext.FailureThreshold.Value;
            }
            if (cmdletContext.HealthCheckPath != null)
            {
                request.HealthCheckPaths = cmdletContext.HealthCheckPath;
            }
            if (cmdletContext.InitializationGracePeriodSecond != null)
            {
                request.InitializationGracePeriodSeconds = cmdletContext.InitializationGracePeriodSecond.Value;
            }
            if (cmdletContext.Interval != null)
            {
                request.Interval = cmdletContext.Interval.Value;
            }
            if (cmdletContext.IpScope != null)
            {
                request.IpScope = cmdletContext.IpScope;
            }
            if (cmdletContext.IpVersion != null)
            {
                request.IpVersion = cmdletContext.IpVersion;
            }
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.StatusCodeMatcher != null)
            {
                request.StatusCodeMatcher = cmdletContext.StatusCodeMatcher;
            }
            if (cmdletContext.SuccessThreshold != null)
            {
                request.SuccessThreshold = cmdletContext.SuccessThreshold.Value;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
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
        
        private Amazon.EC2.Model.CreateApplicationStatusCheckResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateApplicationStatusCheckRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateApplicationStatusCheck");
            try
            {
                return client.CreateApplicationStatusCheckAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EC2.AggregationStatusEnum Aggregation { get; set; }
            public System.String ClientToken { get; set; }
            public System.Int32? DeviceIndex { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Int32? FailureThreshold { get; set; }
            public List<Amazon.EC2.Model.HealthCheckPathRequestObject> HealthCheckPath { get; set; }
            public System.Int32? InitializationGracePeriodSecond { get; set; }
            public System.Int32? Interval { get; set; }
            public Amazon.EC2.IpScopeEnum IpScope { get; set; }
            public Amazon.EC2.IpVersionEnum IpVersion { get; set; }
            public System.String Path { get; set; }
            public System.Int32? Port { get; set; }
            public Amazon.EC2.NetworkProtocolEnum Protocol { get; set; }
            public System.String StatusCodeMatcher { get; set; }
            public System.Int32? SuccessThreshold { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Int32? Timeout { get; set; }
            public System.Func<Amazon.EC2.Model.CreateApplicationStatusCheckResponse, NewEC2ApplicationStatusCheckCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationStatusCheck;
        }
        
    }
}
