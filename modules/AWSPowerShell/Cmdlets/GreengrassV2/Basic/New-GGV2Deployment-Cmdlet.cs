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
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GGV2
{
    /// <summary>
    /// Creates a continuous deployment for a target, which is a Greengrass core device or
    /// group of core devices. When you add a new core device to a group of core devices that
    /// has a deployment, IoT Greengrass deploys that group's deployment to the new device.
    /// 
    ///  
    /// <para>
    /// You can define one deployment for each target. When you create a new deployment for
    /// a target that has an existing deployment, you replace the previous deployment. IoT
    /// Greengrass applies the new deployment to the target devices.
    /// </para><para>
    /// Every deployment has a revision number that indicates how many deployment revisions
    /// you define for a target. Use this operation to create a new revision of an existing
    /// deployment.
    /// </para><para>
    /// For more information, see the <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/create-deployments.html">Create
    /// deployments</a> in the <i>IoT Greengrass V2 Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GGV2Deployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GreengrassV2.Model.CreateDeploymentResponse")]
    [AWSCmdlet("Calls the AWS GreengrassV2 CreateDeployment API operation.", Operation = new[] {"CreateDeployment"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.CreateDeploymentResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.CreateDeploymentResponse",
        "This cmdlet returns an Amazon.GreengrassV2.Model.CreateDeploymentResponse object containing multiple properties."
    )]
    public partial class NewGGV2DeploymentCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComponentUpdatePolicy_Action
        /// <summary>
        /// <para>
        /// <para>Whether or not to notify components and wait for components to become safe to update.
        /// Choose from the following options:</para><ul><li><para><c>NOTIFY_COMPONENTS</c> – The deployment notifies each component before it stops
        /// and updates that component. Components can use the <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/interprocess-communication.html#ipc-operation-subscribetocomponentupdates">SubscribeToComponentUpdates</a>
        /// IPC operation to receive these notifications. Then, components can respond with the
        /// <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/interprocess-communication.html#ipc-operation-defercomponentupdate">DeferComponentUpdate</a>
        /// IPC operation. For more information, see <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/create-deployments.html">Create
        /// deployments</a> in the <i>IoT Greengrass V2 Developer Guide</i>.</para></li><li><para><c>SKIP_NOTIFY_COMPONENTS</c> – The deployment doesn't notify components or wait
        /// for them to be safe to update.</para></li></ul><para>Default: <c>NOTIFY_COMPONENTS</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentPolicies_ComponentUpdatePolicy_Action")]
        [AWSConstantClassSource("Amazon.GreengrassV2.DeploymentComponentUpdatePolicyAction")]
        public Amazon.GreengrassV2.DeploymentComponentUpdatePolicyAction ComponentUpdatePolicy_Action { get; set; }
        #endregion
        
        #region Parameter ExponentialRate_BaseRatePerMinute
        /// <summary>
        /// <para>
        /// <para>The minimum number of devices that receive a pending job notification, per minute,
        /// when the job starts. This parameter defines the initial rollout rate of the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_BaseRatePerMinute")]
        public System.Int32? ExponentialRate_BaseRatePerMinute { get; set; }
        #endregion
        
        #region Parameter Component
        /// <summary>
        /// <para>
        /// <para>The components to deploy. This is a dictionary, where each key is the name of a component,
        /// and each key's value is the version and configuration to deploy for that component.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Components")]
        public System.Collections.Hashtable Component { get; set; }
        #endregion
        
        #region Parameter AbortConfig_CriteriaList
        /// <summary>
        /// <para>
        /// <para>The list of criteria that define when and how to cancel the configuration deployment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IotJobConfiguration_AbortConfig_CriteriaList")]
        public Amazon.GreengrassV2.Model.IoTJobAbortCriteria[] AbortConfig_CriteriaList { get; set; }
        #endregion
        
        #region Parameter DeploymentName
        /// <summary>
        /// <para>
        /// <para>The name of the deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentName { get; set; }
        #endregion
        
        #region Parameter DeploymentPolicies_FailureHandlingPolicy
        /// <summary>
        /// <para>
        /// <para>The failure handling policy for the configuration deployment. This policy defines
        /// what to do if the deployment fails.</para><para>Default: <c>ROLLBACK</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GreengrassV2.DeploymentFailureHandlingPolicy")]
        public Amazon.GreengrassV2.DeploymentFailureHandlingPolicy DeploymentPolicies_FailureHandlingPolicy { get; set; }
        #endregion
        
        #region Parameter ExponentialRate_IncrementFactor
        /// <summary>
        /// <para>
        /// <para>The exponential factor to increase the rollout rate for the job.</para><para>This parameter supports up to one digit after the decimal (for example, you can specify
        /// <c>1.5</c>, but not <c>1.55</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_IncrementFactor")]
        public System.Double? ExponentialRate_IncrementFactor { get; set; }
        #endregion
        
        #region Parameter TimeoutConfig_InProgressTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time, in minutes, that devices have to complete the job. The timer starts
        /// when the job status is set to <c>IN_PROGRESS</c>. If the job status doesn't change
        /// to a terminal state before the time expires, then the job status is set to <c>TIMED_OUT</c>.</para><para>The timeout interval must be between 1 minute and 7 days (10080 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IotJobConfiguration_TimeoutConfig_InProgressTimeoutInMinutes")]
        public System.Int64? TimeoutConfig_InProgressTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter JobExecutionsRolloutConfig_MaximumPerMinute
        /// <summary>
        /// <para>
        /// <para>The maximum number of devices that receive a pending job notification, per minute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IotJobConfiguration_JobExecutionsRolloutConfig_MaximumPerMinute")]
        public System.Int32? JobExecutionsRolloutConfig_MaximumPerMinute { get; set; }
        #endregion
        
        #region Parameter RateIncreaseCriteria_NumberOfNotifiedThing
        /// <summary>
        /// <para>
        /// <para>The number of devices to receive the job notification before the rollout rate increases.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_NumberOfNotifiedThings")]
        public System.Int32? RateIncreaseCriteria_NumberOfNotifiedThing { get; set; }
        #endregion
        
        #region Parameter RateIncreaseCriteria_NumberOfSucceededThing
        /// <summary>
        /// <para>
        /// <para>The number of devices to successfully run the configuration job before the rollout
        /// rate increases.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_NumberOfSucceededThings")]
        public System.Int32? RateIncreaseCriteria_NumberOfSucceededThing { get; set; }
        #endregion
        
        #region Parameter ParentTargetArn
        /// <summary>
        /// <para>
        /// <para>The parent deployment's target <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// within a subdeployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentTargetArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that contain metadata for the resource. For more information,
        /// see <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/tag-resources.html">Tag
        /// your resources</a> in the <i>IoT Greengrass V2 Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the target IoT thing or thing group. When creating a subdeployment, the targetARN
        /// can only be a thing group.</para>
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
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter ComponentUpdatePolicy_TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time in seconds that each component on a device has to report that it's
        /// safe to update. If the component waits for longer than this timeout, then the deployment
        /// proceeds on the device.</para><para>Default: <c>60</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentPolicies_ComponentUpdatePolicy_TimeoutInSeconds")]
        public System.Int32? ComponentUpdatePolicy_TimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter ConfigurationValidationPolicy_TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time in seconds that a component can validate its configuration updates.
        /// If the validation time exceeds this timeout, then the deployment proceeds for the
        /// device.</para><para>Default: <c>30</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentPolicies_ConfigurationValidationPolicy_TimeoutInSeconds")]
        public System.Int32? ConfigurationValidationPolicy_TimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you can provide to ensure that the request
        /// is idempotent. Idempotency means that the request is successfully processed only once,
        /// even if you send the request multiple times. When a request succeeds, and you specify
        /// the same client token for subsequent successful requests, the IoT Greengrass V2 service
        /// returns the successful response that it caches from the previous request. IoT Greengrass
        /// V2 caches successful responses for idempotent requests for up to 8 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.CreateDeploymentResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.CreateDeploymentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGV2Deployment (CreateDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.CreateDeploymentResponse, NewGGV2DeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.Component != null)
            {
                context.Component = new Dictionary<System.String, Amazon.GreengrassV2.Model.ComponentDeploymentSpecification>(StringComparer.Ordinal);
                foreach (var hashKey in this.Component.Keys)
                {
                    context.Component.Add((String)hashKey, (Amazon.GreengrassV2.Model.ComponentDeploymentSpecification)(this.Component[hashKey]));
                }
            }
            context.DeploymentName = this.DeploymentName;
            context.ComponentUpdatePolicy_Action = this.ComponentUpdatePolicy_Action;
            context.ComponentUpdatePolicy_TimeoutInSecond = this.ComponentUpdatePolicy_TimeoutInSecond;
            context.ConfigurationValidationPolicy_TimeoutInSecond = this.ConfigurationValidationPolicy_TimeoutInSecond;
            context.DeploymentPolicies_FailureHandlingPolicy = this.DeploymentPolicies_FailureHandlingPolicy;
            if (this.AbortConfig_CriteriaList != null)
            {
                context.AbortConfig_CriteriaList = new List<Amazon.GreengrassV2.Model.IoTJobAbortCriteria>(this.AbortConfig_CriteriaList);
            }
            context.ExponentialRate_BaseRatePerMinute = this.ExponentialRate_BaseRatePerMinute;
            context.ExponentialRate_IncrementFactor = this.ExponentialRate_IncrementFactor;
            context.RateIncreaseCriteria_NumberOfNotifiedThing = this.RateIncreaseCriteria_NumberOfNotifiedThing;
            context.RateIncreaseCriteria_NumberOfSucceededThing = this.RateIncreaseCriteria_NumberOfSucceededThing;
            context.JobExecutionsRolloutConfig_MaximumPerMinute = this.JobExecutionsRolloutConfig_MaximumPerMinute;
            context.TimeoutConfig_InProgressTimeoutInMinute = this.TimeoutConfig_InProgressTimeoutInMinute;
            context.ParentTargetArn = this.ParentTargetArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TargetArn = this.TargetArn;
            #if MODULAR
            if (this.TargetArn == null && ParameterWasBound(nameof(this.TargetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GreengrassV2.Model.CreateDeploymentRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Component != null)
            {
                request.Components = cmdletContext.Component;
            }
            if (cmdletContext.DeploymentName != null)
            {
                request.DeploymentName = cmdletContext.DeploymentName;
            }
            
             // populate DeploymentPolicies
            var requestDeploymentPoliciesIsNull = true;
            request.DeploymentPolicies = new Amazon.GreengrassV2.Model.DeploymentPolicies();
            Amazon.GreengrassV2.DeploymentFailureHandlingPolicy requestDeploymentPolicies_deploymentPolicies_FailureHandlingPolicy = null;
            if (cmdletContext.DeploymentPolicies_FailureHandlingPolicy != null)
            {
                requestDeploymentPolicies_deploymentPolicies_FailureHandlingPolicy = cmdletContext.DeploymentPolicies_FailureHandlingPolicy;
            }
            if (requestDeploymentPolicies_deploymentPolicies_FailureHandlingPolicy != null)
            {
                request.DeploymentPolicies.FailureHandlingPolicy = requestDeploymentPolicies_deploymentPolicies_FailureHandlingPolicy;
                requestDeploymentPoliciesIsNull = false;
            }
            Amazon.GreengrassV2.Model.DeploymentConfigurationValidationPolicy requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy = null;
            
             // populate ConfigurationValidationPolicy
            var requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicyIsNull = true;
            requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy = new Amazon.GreengrassV2.Model.DeploymentConfigurationValidationPolicy();
            System.Int32? requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy_configurationValidationPolicy_TimeoutInSecond = null;
            if (cmdletContext.ConfigurationValidationPolicy_TimeoutInSecond != null)
            {
                requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy_configurationValidationPolicy_TimeoutInSecond = cmdletContext.ConfigurationValidationPolicy_TimeoutInSecond.Value;
            }
            if (requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy_configurationValidationPolicy_TimeoutInSecond != null)
            {
                requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy.TimeoutInSeconds = requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy_configurationValidationPolicy_TimeoutInSecond.Value;
                requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicyIsNull = false;
            }
             // determine if requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy should be set to null
            if (requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicyIsNull)
            {
                requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy = null;
            }
            if (requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy != null)
            {
                request.DeploymentPolicies.ConfigurationValidationPolicy = requestDeploymentPolicies_deploymentPolicies_ConfigurationValidationPolicy;
                requestDeploymentPoliciesIsNull = false;
            }
            Amazon.GreengrassV2.Model.DeploymentComponentUpdatePolicy requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy = null;
            
             // populate ComponentUpdatePolicy
            var requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicyIsNull = true;
            requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy = new Amazon.GreengrassV2.Model.DeploymentComponentUpdatePolicy();
            Amazon.GreengrassV2.DeploymentComponentUpdatePolicyAction requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy_componentUpdatePolicy_Action = null;
            if (cmdletContext.ComponentUpdatePolicy_Action != null)
            {
                requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy_componentUpdatePolicy_Action = cmdletContext.ComponentUpdatePolicy_Action;
            }
            if (requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy_componentUpdatePolicy_Action != null)
            {
                requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy.Action = requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy_componentUpdatePolicy_Action;
                requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicyIsNull = false;
            }
            System.Int32? requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy_componentUpdatePolicy_TimeoutInSecond = null;
            if (cmdletContext.ComponentUpdatePolicy_TimeoutInSecond != null)
            {
                requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy_componentUpdatePolicy_TimeoutInSecond = cmdletContext.ComponentUpdatePolicy_TimeoutInSecond.Value;
            }
            if (requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy_componentUpdatePolicy_TimeoutInSecond != null)
            {
                requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy.TimeoutInSeconds = requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy_componentUpdatePolicy_TimeoutInSecond.Value;
                requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicyIsNull = false;
            }
             // determine if requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy should be set to null
            if (requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicyIsNull)
            {
                requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy = null;
            }
            if (requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy != null)
            {
                request.DeploymentPolicies.ComponentUpdatePolicy = requestDeploymentPolicies_deploymentPolicies_ComponentUpdatePolicy;
                requestDeploymentPoliciesIsNull = false;
            }
             // determine if request.DeploymentPolicies should be set to null
            if (requestDeploymentPoliciesIsNull)
            {
                request.DeploymentPolicies = null;
            }
            
             // populate IotJobConfiguration
            var requestIotJobConfigurationIsNull = true;
            request.IotJobConfiguration = new Amazon.GreengrassV2.Model.DeploymentIoTJobConfiguration();
            Amazon.GreengrassV2.Model.IoTJobAbortConfig requestIotJobConfiguration_iotJobConfiguration_AbortConfig = null;
            
             // populate AbortConfig
            var requestIotJobConfiguration_iotJobConfiguration_AbortConfigIsNull = true;
            requestIotJobConfiguration_iotJobConfiguration_AbortConfig = new Amazon.GreengrassV2.Model.IoTJobAbortConfig();
            List<Amazon.GreengrassV2.Model.IoTJobAbortCriteria> requestIotJobConfiguration_iotJobConfiguration_AbortConfig_abortConfig_CriteriaList = null;
            if (cmdletContext.AbortConfig_CriteriaList != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_AbortConfig_abortConfig_CriteriaList = cmdletContext.AbortConfig_CriteriaList;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_AbortConfig_abortConfig_CriteriaList != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_AbortConfig.CriteriaList = requestIotJobConfiguration_iotJobConfiguration_AbortConfig_abortConfig_CriteriaList;
                requestIotJobConfiguration_iotJobConfiguration_AbortConfigIsNull = false;
            }
             // determine if requestIotJobConfiguration_iotJobConfiguration_AbortConfig should be set to null
            if (requestIotJobConfiguration_iotJobConfiguration_AbortConfigIsNull)
            {
                requestIotJobConfiguration_iotJobConfiguration_AbortConfig = null;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_AbortConfig != null)
            {
                request.IotJobConfiguration.AbortConfig = requestIotJobConfiguration_iotJobConfiguration_AbortConfig;
                requestIotJobConfigurationIsNull = false;
            }
            Amazon.GreengrassV2.Model.IoTJobTimeoutConfig requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig = null;
            
             // populate TimeoutConfig
            var requestIotJobConfiguration_iotJobConfiguration_TimeoutConfigIsNull = true;
            requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig = new Amazon.GreengrassV2.Model.IoTJobTimeoutConfig();
            System.Int64? requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig_timeoutConfig_InProgressTimeoutInMinute = null;
            if (cmdletContext.TimeoutConfig_InProgressTimeoutInMinute != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig_timeoutConfig_InProgressTimeoutInMinute = cmdletContext.TimeoutConfig_InProgressTimeoutInMinute.Value;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig_timeoutConfig_InProgressTimeoutInMinute != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig.InProgressTimeoutInMinutes = requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig_timeoutConfig_InProgressTimeoutInMinute.Value;
                requestIotJobConfiguration_iotJobConfiguration_TimeoutConfigIsNull = false;
            }
             // determine if requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig should be set to null
            if (requestIotJobConfiguration_iotJobConfiguration_TimeoutConfigIsNull)
            {
                requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig = null;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig != null)
            {
                request.IotJobConfiguration.TimeoutConfig = requestIotJobConfiguration_iotJobConfiguration_TimeoutConfig;
                requestIotJobConfigurationIsNull = false;
            }
            Amazon.GreengrassV2.Model.IoTJobExecutionsRolloutConfig requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig = null;
            
             // populate JobExecutionsRolloutConfig
            var requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfigIsNull = true;
            requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig = new Amazon.GreengrassV2.Model.IoTJobExecutionsRolloutConfig();
            System.Int32? requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_jobExecutionsRolloutConfig_MaximumPerMinute = null;
            if (cmdletContext.JobExecutionsRolloutConfig_MaximumPerMinute != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_jobExecutionsRolloutConfig_MaximumPerMinute = cmdletContext.JobExecutionsRolloutConfig_MaximumPerMinute.Value;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_jobExecutionsRolloutConfig_MaximumPerMinute != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig.MaximumPerMinute = requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_jobExecutionsRolloutConfig_MaximumPerMinute.Value;
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfigIsNull = false;
            }
            Amazon.GreengrassV2.Model.IoTJobExponentialRolloutRate requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate = null;
            
             // populate ExponentialRate
            var requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRateIsNull = true;
            requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate = new Amazon.GreengrassV2.Model.IoTJobExponentialRolloutRate();
            System.Int32? requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_exponentialRate_BaseRatePerMinute = null;
            if (cmdletContext.ExponentialRate_BaseRatePerMinute != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_exponentialRate_BaseRatePerMinute = cmdletContext.ExponentialRate_BaseRatePerMinute.Value;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_exponentialRate_BaseRatePerMinute != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate.BaseRatePerMinute = requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_exponentialRate_BaseRatePerMinute.Value;
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRateIsNull = false;
            }
            System.Double? requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_exponentialRate_IncrementFactor = null;
            if (cmdletContext.ExponentialRate_IncrementFactor != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_exponentialRate_IncrementFactor = cmdletContext.ExponentialRate_IncrementFactor.Value;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_exponentialRate_IncrementFactor != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate.IncrementFactor = requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_exponentialRate_IncrementFactor.Value;
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRateIsNull = false;
            }
            Amazon.GreengrassV2.Model.IoTJobRateIncreaseCriteria requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria = null;
            
             // populate RateIncreaseCriteria
            requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria = new Amazon.GreengrassV2.Model.IoTJobRateIncreaseCriteria();
            System.Int32? requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing = null;
            if (cmdletContext.RateIncreaseCriteria_NumberOfNotifiedThing != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing = cmdletContext.RateIncreaseCriteria_NumberOfNotifiedThing.Value;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria.NumberOfNotifiedThings = requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing.Value;
            }
            System.Int32? requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing = null;
            if (cmdletContext.RateIncreaseCriteria_NumberOfSucceededThing != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing = cmdletContext.RateIncreaseCriteria_NumberOfSucceededThing.Value;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria.NumberOfSucceededThings = requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing.Value;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate.RateIncreaseCriteria = requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria;
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRateIsNull = false;
            }
             // determine if requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate should be set to null
            if (requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRateIsNull)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate = null;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate != null)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig.ExponentialRate = requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig_iotJobConfiguration_JobExecutionsRolloutConfig_ExponentialRate;
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfigIsNull = false;
            }
             // determine if requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig should be set to null
            if (requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfigIsNull)
            {
                requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig = null;
            }
            if (requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig != null)
            {
                request.IotJobConfiguration.JobExecutionsRolloutConfig = requestIotJobConfiguration_iotJobConfiguration_JobExecutionsRolloutConfig;
                requestIotJobConfigurationIsNull = false;
            }
             // determine if request.IotJobConfiguration should be set to null
            if (requestIotJobConfigurationIsNull)
            {
                request.IotJobConfiguration = null;
            }
            if (cmdletContext.ParentTargetArn != null)
            {
                request.ParentTargetArn = cmdletContext.ParentTargetArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
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
        
        private Amazon.GreengrassV2.Model.CreateDeploymentResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.CreateDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "CreateDeployment");
            try
            {
                return client.CreateDeploymentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, Amazon.GreengrassV2.Model.ComponentDeploymentSpecification> Component { get; set; }
            public System.String DeploymentName { get; set; }
            public Amazon.GreengrassV2.DeploymentComponentUpdatePolicyAction ComponentUpdatePolicy_Action { get; set; }
            public System.Int32? ComponentUpdatePolicy_TimeoutInSecond { get; set; }
            public System.Int32? ConfigurationValidationPolicy_TimeoutInSecond { get; set; }
            public Amazon.GreengrassV2.DeploymentFailureHandlingPolicy DeploymentPolicies_FailureHandlingPolicy { get; set; }
            public List<Amazon.GreengrassV2.Model.IoTJobAbortCriteria> AbortConfig_CriteriaList { get; set; }
            public System.Int32? ExponentialRate_BaseRatePerMinute { get; set; }
            public System.Double? ExponentialRate_IncrementFactor { get; set; }
            public System.Int32? RateIncreaseCriteria_NumberOfNotifiedThing { get; set; }
            public System.Int32? RateIncreaseCriteria_NumberOfSucceededThing { get; set; }
            public System.Int32? JobExecutionsRolloutConfig_MaximumPerMinute { get; set; }
            public System.Int64? TimeoutConfig_InProgressTimeoutInMinute { get; set; }
            public System.String ParentTargetArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TargetArn { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.CreateDeploymentResponse, NewGGV2DeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
