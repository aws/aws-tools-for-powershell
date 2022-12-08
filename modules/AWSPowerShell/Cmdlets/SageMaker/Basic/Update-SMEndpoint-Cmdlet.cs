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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Deploys the new <code>EndpointConfig</code> specified in the request, switches to
    /// using newly created endpoint, and then deletes resources provisioned for the endpoint
    /// using the previous <code>EndpointConfig</code> (there is no availability loss). 
    /// 
    ///  
    /// <para>
    /// When SageMaker receives the request, it sets the endpoint status to <code>Updating</code>.
    /// After updating the endpoint, it sets the status to <code>InService</code>. To check
    /// the status of an endpoint, use the <a>DescribeEndpoint</a> API. 
    /// </para><note><para>
    /// You must not delete an <code>EndpointConfig</code> in use by an endpoint that is live
    /// or while the <code>UpdateEndpoint</code> or <code>CreateEndpoint</code> operations
    /// are being performed on the endpoint. To update an endpoint, you must create a new
    /// <code>EndpointConfig</code>.
    /// </para><para>
    /// If you delete the <code>EndpointConfig</code> of an endpoint that is active or being
    /// created or updated you may lose visibility into the instance type the endpoint is
    /// using. The endpoint must be deleted in order to stop incurring charges.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SMEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateEndpoint API operation.", Operation = new[] {"UpdateEndpoint"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateEndpointResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateEndpointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMEndpointCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter AutoRollbackConfiguration_Alarm
        /// <summary>
        /// <para>
        /// <para>List of CloudWatch alarms in your account that are configured to monitor metrics on
        /// an endpoint. If any alarms are tripped during a deployment, SageMaker rolls back the
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_AutoRollbackConfiguration_Alarms")]
        public Amazon.SageMaker.Model.Alarm[] AutoRollbackConfiguration_Alarm { get; set; }
        #endregion
        
        #region Parameter EndpointConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the new endpoint configuration.</para>
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
        public System.String EndpointConfigName { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint whose configuration you want to update.</para>
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
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter ExcludeRetainedVariantProperty
        /// <summary>
        /// <para>
        /// <para>When you are updating endpoint resources with <a>UpdateEndpointInput$RetainAllVariantProperties</a>,
        /// whose value is set to <code>true</code>, <code>ExcludeRetainedVariantProperties</code>
        /// specifies the list of type <a>VariantProperty</a> to override with the values provided
        /// by <code>EndpointConfig</code>. If you don't specify a value for <code>ExcludeAllVariantProperties</code>,
        /// no variant properties are overridden. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludeRetainedVariantProperties")]
        public Amazon.SageMaker.Model.VariantProperty[] ExcludeRetainedVariantProperty { get; set; }
        #endregion
        
        #region Parameter BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>Maximum execution timeout for the deployment. Note that the timeout value should be
        /// larger than the total waiting time specified in <code>TerminationWaitInSeconds</code>
        /// and <code>WaitIntervalInSeconds</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSeconds")]
        public System.Int32? BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter RetainAllVariantProperty
        /// <summary>
        /// <para>
        /// <para>When updating endpoint resources, enables or disables the retention of <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_VariantProperty.html">variant
        /// properties</a>, such as the instance count or the variant weight. To retain the variant
        /// properties of an endpoint when updating it, set <code>RetainAllVariantProperties</code>
        /// to <code>true</code>. To use the variant properties specified in a new <code>EndpointConfig</code>
        /// call when updating an endpoint, set <code>RetainAllVariantProperties</code> to <code>false</code>.
        /// The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetainAllVariantProperties")]
        public System.Boolean? RetainAllVariantProperty { get; set; }
        #endregion
        
        #region Parameter RetainDeploymentConfig
        /// <summary>
        /// <para>
        /// <para>Specifies whether to reuse the last deployment configuration. The default value is
        /// false (the configuration is not reused).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RetainDeploymentConfig { get; set; }
        #endregion
        
        #region Parameter BlueGreenUpdatePolicy_TerminationWaitInSecond
        /// <summary>
        /// <para>
        /// <para>Additional waiting time in seconds after the completion of an endpoint deployment
        /// before terminating the old endpoint fleet. Default is 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TerminationWaitInSeconds")]
        public System.Int32? BlueGreenUpdatePolicy_TerminationWaitInSecond { get; set; }
        #endregion
        
        #region Parameter CanarySize_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint capacity type.</para><ul><li><para><code>INSTANCE_COUNT</code>: The endpoint activates based on the number of instances.</para></li><li><para><code>CAPACITY_PERCENT</code>: The endpoint activates based on the specified percentage
        /// of capacity.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.CapacitySizeType")]
        public Amazon.SageMaker.CapacitySizeType CanarySize_Type { get; set; }
        #endregion
        
        #region Parameter LinearStepSize_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint capacity type.</para><ul><li><para><code>INSTANCE_COUNT</code>: The endpoint activates based on the number of instances.</para></li><li><para><code>CAPACITY_PERCENT</code>: The endpoint activates based on the specified percentage
        /// of capacity.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.CapacitySizeType")]
        public Amazon.SageMaker.CapacitySizeType LinearStepSize_Type { get; set; }
        #endregion
        
        #region Parameter TrafficRoutingConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>Traffic routing strategy type.</para><ul><li><para><code>ALL_AT_ONCE</code>: Endpoint traffic shifts to the new fleet in a single step.
        /// </para></li><li><para><code>CANARY</code>: Endpoint traffic shifts to the new fleet in two steps. The first
        /// step is the canary, which is a small portion of the traffic. The second step is the
        /// remainder of the traffic. </para></li><li><para><code>LINEAR</code>: Endpoint traffic shifts to the new fleet in n steps of a configurable
        /// size. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.TrafficRoutingConfigType")]
        public Amazon.SageMaker.TrafficRoutingConfigType TrafficRoutingConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter CanarySize_Value
        /// <summary>
        /// <para>
        /// <para>Defines the capacity size, either as a number of instances or a capacity percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_Value")]
        public System.Int32? CanarySize_Value { get; set; }
        #endregion
        
        #region Parameter LinearStepSize_Value
        /// <summary>
        /// <para>
        /// <para>Defines the capacity size, either as a number of instances or a capacity percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_Value")]
        public System.Int32? LinearStepSize_Value { get; set; }
        #endregion
        
        #region Parameter TrafficRoutingConfiguration_WaitIntervalInSecond
        /// <summary>
        /// <para>
        /// <para>The waiting time (in seconds) between incremental steps to turn on traffic on the
        /// new endpoint fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_WaitIntervalInSeconds")]
        public System.Int32? TrafficRoutingConfiguration_WaitIntervalInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EndpointArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateEndpointResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EndpointConfigName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EndpointConfigName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EndpointConfigName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMEndpoint (UpdateEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateEndpointResponse, UpdateSMEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EndpointConfigName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AutoRollbackConfiguration_Alarm != null)
            {
                context.AutoRollbackConfiguration_Alarm = new List<Amazon.SageMaker.Model.Alarm>(this.AutoRollbackConfiguration_Alarm);
            }
            context.BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond = this.BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond;
            context.BlueGreenUpdatePolicy_TerminationWaitInSecond = this.BlueGreenUpdatePolicy_TerminationWaitInSecond;
            context.CanarySize_Type = this.CanarySize_Type;
            context.CanarySize_Value = this.CanarySize_Value;
            context.LinearStepSize_Type = this.LinearStepSize_Type;
            context.LinearStepSize_Value = this.LinearStepSize_Value;
            context.TrafficRoutingConfiguration_Type = this.TrafficRoutingConfiguration_Type;
            context.TrafficRoutingConfiguration_WaitIntervalInSecond = this.TrafficRoutingConfiguration_WaitIntervalInSecond;
            context.EndpointConfigName = this.EndpointConfigName;
            #if MODULAR
            if (this.EndpointConfigName == null && ParameterWasBound(nameof(this.EndpointConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExcludeRetainedVariantProperty != null)
            {
                context.ExcludeRetainedVariantProperty = new List<Amazon.SageMaker.Model.VariantProperty>(this.ExcludeRetainedVariantProperty);
            }
            context.RetainAllVariantProperty = this.RetainAllVariantProperty;
            context.RetainDeploymentConfig = this.RetainDeploymentConfig;
            
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
            var request = new Amazon.SageMaker.Model.UpdateEndpointRequest();
            
            
             // populate DeploymentConfig
            var requestDeploymentConfigIsNull = true;
            request.DeploymentConfig = new Amazon.SageMaker.Model.DeploymentConfig();
            Amazon.SageMaker.Model.AutoRollbackConfig requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = null;
            
             // populate AutoRollbackConfiguration
            var requestDeploymentConfig_deploymentConfig_AutoRollbackConfigurationIsNull = true;
            requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = new Amazon.SageMaker.Model.AutoRollbackConfig();
            List<Amazon.SageMaker.Model.Alarm> requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm = null;
            if (cmdletContext.AutoRollbackConfiguration_Alarm != null)
            {
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm = cmdletContext.AutoRollbackConfiguration_Alarm;
            }
            if (requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm != null)
            {
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration.Alarms = requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm;
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfigurationIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration should be set to null
            if (requestDeploymentConfig_deploymentConfig_AutoRollbackConfigurationIsNull)
            {
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = null;
            }
            if (requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration != null)
            {
                request.DeploymentConfig.AutoRollbackConfiguration = requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration;
                requestDeploymentConfigIsNull = false;
            }
            Amazon.SageMaker.Model.BlueGreenUpdatePolicy requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy = null;
            
             // populate BlueGreenUpdatePolicy
            var requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicyIsNull = true;
            requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy = new Amazon.SageMaker.Model.BlueGreenUpdatePolicy();
            System.Int32? requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond = null;
            if (cmdletContext.BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond = cmdletContext.BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy.MaximumExecutionTimeoutInSeconds = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond.Value;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicyIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_TerminationWaitInSecond = null;
            if (cmdletContext.BlueGreenUpdatePolicy_TerminationWaitInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_TerminationWaitInSecond = cmdletContext.BlueGreenUpdatePolicy_TerminationWaitInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_TerminationWaitInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy.TerminationWaitInSeconds = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_TerminationWaitInSecond.Value;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicyIsNull = false;
            }
            Amazon.SageMaker.Model.TrafficRoutingConfig requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration = null;
            
             // populate TrafficRoutingConfiguration
            var requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull = true;
            requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration = new Amazon.SageMaker.Model.TrafficRoutingConfig();
            Amazon.SageMaker.TrafficRoutingConfigType requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_Type = null;
            if (cmdletContext.TrafficRoutingConfiguration_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_Type = cmdletContext.TrafficRoutingConfiguration_Type;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration.Type = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_Type;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_WaitIntervalInSecond = null;
            if (cmdletContext.TrafficRoutingConfiguration_WaitIntervalInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_WaitIntervalInSecond = cmdletContext.TrafficRoutingConfiguration_WaitIntervalInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_WaitIntervalInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration.WaitIntervalInSeconds = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_WaitIntervalInSecond.Value;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull = false;
            }
            Amazon.SageMaker.Model.CapacitySize requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize = null;
            
             // populate CanarySize
            var requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySizeIsNull = true;
            requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize = new Amazon.SageMaker.Model.CapacitySize();
            Amazon.SageMaker.CapacitySizeType requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Type = null;
            if (cmdletContext.CanarySize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Type = cmdletContext.CanarySize_Type;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize.Type = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Type;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySizeIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Value = null;
            if (cmdletContext.CanarySize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Value = cmdletContext.CanarySize_Value.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize.Value = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Value.Value;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySizeIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize should be set to null
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySizeIsNull)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize = null;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration.CanarySize = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull = false;
            }
            Amazon.SageMaker.Model.CapacitySize requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize = null;
            
             // populate LinearStepSize
            var requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSizeIsNull = true;
            requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize = new Amazon.SageMaker.Model.CapacitySize();
            Amazon.SageMaker.CapacitySizeType requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Type = null;
            if (cmdletContext.LinearStepSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Type = cmdletContext.LinearStepSize_Type;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize.Type = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Type;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSizeIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Value = null;
            if (cmdletContext.LinearStepSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Value = cmdletContext.LinearStepSize_Value.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize.Value = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Value.Value;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSizeIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize should be set to null
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSizeIsNull)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize = null;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration.LinearStepSize = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration should be set to null
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration = null;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy.TrafficRoutingConfiguration = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicyIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy should be set to null
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicyIsNull)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy = null;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy != null)
            {
                request.DeploymentConfig.BlueGreenUpdatePolicy = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy;
                requestDeploymentConfigIsNull = false;
            }
             // determine if request.DeploymentConfig should be set to null
            if (requestDeploymentConfigIsNull)
            {
                request.DeploymentConfig = null;
            }
            if (cmdletContext.EndpointConfigName != null)
            {
                request.EndpointConfigName = cmdletContext.EndpointConfigName;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.ExcludeRetainedVariantProperty != null)
            {
                request.ExcludeRetainedVariantProperties = cmdletContext.ExcludeRetainedVariantProperty;
            }
            if (cmdletContext.RetainAllVariantProperty != null)
            {
                request.RetainAllVariantProperties = cmdletContext.RetainAllVariantProperty.Value;
            }
            if (cmdletContext.RetainDeploymentConfig != null)
            {
                request.RetainDeploymentConfig = cmdletContext.RetainDeploymentConfig.Value;
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
        
        private Amazon.SageMaker.Model.UpdateEndpointResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateEndpoint");
            try
            {
                #if DESKTOP
                return client.UpdateEndpoint(request);
                #elif CORECLR
                return client.UpdateEndpointAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.Alarm> AutoRollbackConfiguration_Alarm { get; set; }
            public System.Int32? BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond { get; set; }
            public System.Int32? BlueGreenUpdatePolicy_TerminationWaitInSecond { get; set; }
            public Amazon.SageMaker.CapacitySizeType CanarySize_Type { get; set; }
            public System.Int32? CanarySize_Value { get; set; }
            public Amazon.SageMaker.CapacitySizeType LinearStepSize_Type { get; set; }
            public System.Int32? LinearStepSize_Value { get; set; }
            public Amazon.SageMaker.TrafficRoutingConfigType TrafficRoutingConfiguration_Type { get; set; }
            public System.Int32? TrafficRoutingConfiguration_WaitIntervalInSecond { get; set; }
            public System.String EndpointConfigName { get; set; }
            public System.String EndpointName { get; set; }
            public List<Amazon.SageMaker.Model.VariantProperty> ExcludeRetainedVariantProperty { get; set; }
            public System.Boolean? RetainAllVariantProperty { get; set; }
            public System.Boolean? RetainDeploymentConfig { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateEndpointResponse, UpdateSMEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointArn;
        }
        
    }
}
