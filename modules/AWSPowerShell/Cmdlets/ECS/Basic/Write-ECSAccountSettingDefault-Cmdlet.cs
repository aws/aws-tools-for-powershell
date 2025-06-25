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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Modifies an account setting for all users on an account for whom no individual account
    /// setting has been specified. Account settings are set on a per-Region basis.
    /// </summary>
    [Cmdlet("Write", "ECSAccountSettingDefault", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Setting")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service PutAccountSettingDefault API operation.", Operation = new[] {"PutAccountSettingDefault"}, SelectReturnType = typeof(Amazon.ECS.Model.PutAccountSettingDefaultResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.Setting or Amazon.ECS.Model.PutAccountSettingDefaultResponse",
        "This cmdlet returns an Amazon.ECS.Model.Setting object.",
        "The service call response (type Amazon.ECS.Model.PutAccountSettingDefaultResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteECSAccountSettingDefaultCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The resource name for which to modify the account setting.</para><para>The following are the valid values for the account setting name.</para><ul><li><para><c>serviceLongArnFormat</c> - When modified, the Amazon Resource Name (ARN) and resource
        /// ID format of the resource type for a specified user, role, or the root user for an
        /// account is affected. The opt-in and opt-out account setting must be set for each Amazon
        /// ECS resource separately. The ARN and resource ID format of a resource is defined by
        /// the opt-in status of the user or role that created the resource. You must turn on
        /// this setting to use Amazon ECS features such as resource tagging.</para></li><li><para><c>taskLongArnFormat</c> - When modified, the Amazon Resource Name (ARN) and resource
        /// ID format of the resource type for a specified user, role, or the root user for an
        /// account is affected. The opt-in and opt-out account setting must be set for each Amazon
        /// ECS resource separately. The ARN and resource ID format of a resource is defined by
        /// the opt-in status of the user or role that created the resource. You must turn on
        /// this setting to use Amazon ECS features such as resource tagging.</para></li><li><para><c>containerInstanceLongArnFormat</c> - When modified, the Amazon Resource Name (ARN)
        /// and resource ID format of the resource type for a specified user, role, or the root
        /// user for an account is affected. The opt-in and opt-out account setting must be set
        /// for each Amazon ECS resource separately. The ARN and resource ID format of a resource
        /// is defined by the opt-in status of the user or role that created the resource. You
        /// must turn on this setting to use Amazon ECS features such as resource tagging.</para></li><li><para><c>awsvpcTrunking</c> - When modified, the elastic network interface (ENI) limit
        /// for any new container instances that support the feature is changed. If <c>awsvpcTrunking</c>
        /// is turned on, any new container instances that support the feature are launched have
        /// the increased ENI limits available to them. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/container-instance-eni.html">Elastic
        /// Network Interface Trunking</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para></li><li><para><c>containerInsights</c> - Container Insights with enhanced observability provides
        /// all the Container Insights metrics, plus additional task and container metrics. This
        /// version supports enhanced observability for Amazon ECS clusters using the Amazon EC2
        /// and Fargate launch types. After you configure Container Insights with enhanced observability
        /// on Amazon ECS, Container Insights auto-collects detailed infrastructure telemetry
        /// from the cluster level down to the container level in your environment and displays
        /// these critical performance data in curated dashboards removing the heavy lifting in
        /// observability set-up. </para><para>To use Container Insights with enhanced observability, set the <c>containerInsights</c>
        /// account setting to <c>enhanced</c>.</para><para>To use Container Insights, set the <c>containerInsights</c> account setting to <c>enabled</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/cloudwatch-container-insights.html">Monitor
        /// Amazon ECS containers using Container Insights with enhanced observability</a> in
        /// the <i>Amazon Elastic Container Service Developer Guide</i>.</para></li><li><para><c>dualStackIPv6</c> - When turned on, when using a VPC in dual stack mode, your
        /// tasks using the <c>awsvpc</c> network mode can have an IPv6 address assigned. For
        /// more information on using IPv6 with tasks launched on Amazon EC2 instances, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-networking-awsvpc.html#task-networking-vpc-dual-stack">Using
        /// a VPC in dual-stack mode</a>. For more information on using IPv6 with tasks launched
        /// on Fargate, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/fargate-task-networking.html#fargate-task-networking-vpc-dual-stack">Using
        /// a VPC in dual-stack mode</a>.</para></li><li><para><c>fargateFIPSMode</c> - If you specify <c>fargateFIPSMode</c>, Fargate FIPS 140
        /// compliance is affected.</para></li><li><para><c>fargateTaskRetirementWaitPeriod</c> - When Amazon Web Services determines that
        /// a security or infrastructure update is needed for an Amazon ECS task hosted on Fargate,
        /// the tasks need to be stopped and new tasks launched to replace them. Use <c>fargateTaskRetirementWaitPeriod</c>
        /// to configure the wait time to retire a Fargate task. For information about the Fargate
        /// tasks maintenance, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-maintenance.html">Amazon
        /// Web Services Fargate task maintenance</a> in the <i>Amazon ECS Developer Guide</i>.</para></li><li><para><c>tagResourceAuthorization</c> - Amazon ECS is introducing tagging authorization
        /// for resource creation. Users must have permissions for actions that create the resource,
        /// such as <c>ecsCreateCluster</c>. If tags are specified when you create a resource,
        /// Amazon Web Services performs additional authorization to verify if users or roles
        /// have permissions to create tags. Therefore, you must grant explicit permissions to
        /// use the <c>ecs:TagResource</c> action. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/supported-iam-actions-tagging.html">Grant
        /// permission to tag resources on creation</a> in the <i>Amazon ECS Developer Guide</i>.</para></li><li><para><c>defaultLogDriverMode</c> -Amazon ECS supports setting a default delivery mode
        /// of log messages from a container to the <c>logDriver</c> that you specify in the container's
        /// <c>logConfiguration</c>. The delivery mode affects application stability when the
        /// flow of logs from the container to the log driver is interrupted. The <c>defaultLogDriverMode</c>
        /// setting supports two values: <c>blocking</c> and <c>non-blocking</c>. If you don't
        /// specify a delivery mode in your container definition's <c>logConfiguration</c>, the
        /// mode you specify using this account setting will be used as the default. For more
        /// information about log delivery modes, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_LogConfiguration.html">LogConfiguration</a>.</para><note><para>On June 25, 2025, Amazon ECS changed the default log driver mode from <c>blocking</c>
        /// to <c>non-blocking</c> to prioritize task availability over logging. To continue using
        /// the <c>blocking</c> mode after this change, do one of the following:</para><ul><li><para>Set the <c>mode</c> option in your container definition's <c>logConfiguration</c>
        /// as <c>blocking</c>.</para></li><li><para>Set the <c>defaultLogDriverMode</c> account setting to <c>blocking</c>.</para></li></ul></note></li><li><para><c>guardDutyActivate</c> - The <c>guardDutyActivate</c> parameter is read-only in
        /// Amazon ECS and indicates whether Amazon ECS Runtime Monitoring is enabled or disabled
        /// by your security administrator in your Amazon ECS account. Amazon GuardDuty controls
        /// this account setting on your behalf. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-guard-duty-integration.html">Protecting
        /// Amazon ECS workloads with Amazon ECS Runtime Monitoring</a>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ECS.SettingName")]
        public Amazon.ECS.SettingName Name { get; set; }
        #endregion
        
        #region Parameter Value
        /// <summary>
        /// <para>
        /// <para>The account setting value for the specified principal ARN. Accepted values are <c>enabled</c>,
        /// <c>disabled</c>, <c>on</c>, <c>enhanced</c>, and <c>off</c>.</para><para>When you specify <c>fargateTaskRetirementWaitPeriod</c> for the <c>name</c>, the following
        /// are the valid values:</para><ul><li><para><c>0</c> - Amazon Web Services sends the notification, and immediately retires the
        /// affected tasks.</para></li><li><para><c>7</c> - Amazon Web Services sends the notification, and waits 7 calendar days
        /// to retire the tasks.</para></li><li><para><c>14</c> - Amazon Web Services sends the notification, and waits 14 calendar days
        /// to retire the tasks.</para></li></ul>
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
        public System.String Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Setting'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.PutAccountSettingDefaultResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.PutAccountSettingDefaultResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Setting";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ECSAccountSettingDefault (PutAccountSettingDefault)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.PutAccountSettingDefaultResponse, WriteECSAccountSettingDefaultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Value = this.Value;
            #if MODULAR
            if (this.Value == null && ParameterWasBound(nameof(this.Value)))
            {
                WriteWarning("You are passing $null as a value for parameter Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.PutAccountSettingDefaultRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Value != null)
            {
                request.Value = cmdletContext.Value;
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
        
        private Amazon.ECS.Model.PutAccountSettingDefaultResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.PutAccountSettingDefaultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "PutAccountSettingDefault");
            try
            {
                #if DESKTOP
                return client.PutAccountSettingDefault(request);
                #elif CORECLR
                return client.PutAccountSettingDefaultAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ECS.SettingName Name { get; set; }
            public System.String Value { get; set; }
            public System.Func<Amazon.ECS.Model.PutAccountSettingDefaultResponse, WriteECSAccountSettingDefaultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Setting;
        }
        
    }
}
