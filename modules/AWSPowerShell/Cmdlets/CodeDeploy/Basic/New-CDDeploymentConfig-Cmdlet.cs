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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Creates a deployment configuration.
    /// </summary>
    [Cmdlet("New", "CDDeploymentConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeDeploy CreateDeploymentConfig API operation.", Operation = new[] {"CreateDeploymentConfig"}, SelectReturnType = typeof(Amazon.CodeDeploy.Model.CreateDeploymentConfigResponse))]
    [AWSCmdletOutput("System.String or Amazon.CodeDeploy.Model.CreateDeploymentConfigResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CodeDeploy.Model.CreateDeploymentConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCDDeploymentConfigCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TimeBasedCanary_CanaryInterval
        /// <summary>
        /// <para>
        /// <para>The number of minutes between the first and second traffic shifts of a <c>TimeBasedCanary</c>
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrafficRoutingConfig_TimeBasedCanary_CanaryInterval")]
        public System.Int32? TimeBasedCanary_CanaryInterval { get; set; }
        #endregion
        
        #region Parameter TimeBasedCanary_CanaryPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of traffic to shift in the first increment of a <c>TimeBasedCanary</c>
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrafficRoutingConfig_TimeBasedCanary_CanaryPercentage")]
        public System.Int32? TimeBasedCanary_CanaryPercentage { get; set; }
        #endregion
        
        #region Parameter ComputePlatform
        /// <summary>
        /// <para>
        /// <para>The destination platform type for the deployment (<c>Lambda</c>, <c>Server</c>, or
        /// <c>ECS</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeDeploy.ComputePlatform")]
        public Amazon.CodeDeploy.ComputePlatform ComputePlatform { get; set; }
        #endregion
        
        #region Parameter DeploymentConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the deployment configuration to create.</para>
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
        public System.String DeploymentConfigName { get; set; }
        #endregion
        
        #region Parameter ZonalConfig_FirstZoneMonitorDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, that CodeDeploy must wait after completing a deployment
        /// to the <i>first</i> Availability Zone. CodeDeploy will wait this amount of time before
        /// starting a deployment to the second Availability Zone. You might set this option if
        /// you want to allow extra bake time for the first Availability Zone. If you don't specify
        /// a value for <c>firstZoneMonitorDurationInSeconds</c>, then CodeDeploy uses the <c>monitorDurationInSeconds</c>
        /// value for the first Availability Zone.</para><para>For more information about the zonal configuration feature, see <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/deployment-configurations-create.html#zonal-config">zonal
        /// configuration</a> in the <i>CodeDeploy User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ZonalConfig_FirstZoneMonitorDurationInSeconds")]
        public System.Int64? ZonalConfig_FirstZoneMonitorDurationInSecond { get; set; }
        #endregion
        
        #region Parameter TimeBasedLinear_LinearInterval
        /// <summary>
        /// <para>
        /// <para>The number of minutes between each incremental traffic shift of a <c>TimeBasedLinear</c>
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrafficRoutingConfig_TimeBasedLinear_LinearInterval")]
        public System.Int32? TimeBasedLinear_LinearInterval { get; set; }
        #endregion
        
        #region Parameter TimeBasedLinear_LinearPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of traffic that is shifted at the start of each increment of a <c>TimeBasedLinear</c>
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrafficRoutingConfig_TimeBasedLinear_LinearPercentage")]
        public System.Int32? TimeBasedLinear_LinearPercentage { get; set; }
        #endregion
        
        #region Parameter ZonalConfig_MonitorDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, that CodeDeploy must wait after completing a deployment
        /// to an Availability Zone. CodeDeploy will wait this amount of time before starting
        /// a deployment to the next Availability Zone. Consider adding a monitor duration to
        /// give the deployment some time to prove itself (or 'bake') in one Availability Zone
        /// before it is released in the next zone. If you don't specify a <c>monitorDurationInSeconds</c>,
        /// CodeDeploy starts deploying to the next Availability Zone immediately.</para><para>For more information about the zonal configuration feature, see <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/deployment-configurations-create.html#zonal-config">zonal
        /// configuration</a> in the <i>CodeDeploy User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ZonalConfig_MonitorDurationInSeconds")]
        public System.Int64? ZonalConfig_MonitorDurationInSecond { get; set; }
        #endregion
        
        #region Parameter MinimumHealthyHosts_Type
        /// <summary>
        /// <para>
        /// <para>The minimum healthy instance type:</para><ul><li><para><c>HOST_COUNT</c>: The minimum number of healthy instances as an absolute value.</para></li><li><para><c>FLEET_PERCENT</c>: The minimum number of healthy instances as a percentage of
        /// the total number of instances in the deployment.</para></li></ul><para>In an example of nine instances, if a HOST_COUNT of six is specified, deploy to up
        /// to three instances at a time. The deployment is successful if six or more instances
        /// are deployed to successfully. Otherwise, the deployment fails. If a FLEET_PERCENT
        /// of 40 is specified, deploy to up to five instances at a time. The deployment is successful
        /// if four or more instances are deployed to successfully. Otherwise, the deployment
        /// fails.</para><note><para>In a call to the <c>GetDeploymentConfig</c>, CodeDeployDefault.OneAtATime returns
        /// a minimum healthy instance type of MOST_CONCURRENCY and a value of 1. This means a
        /// deployment to only one instance at a time. (You cannot set the type to MOST_CONCURRENCY,
        /// only to HOST_COUNT or FLEET_PERCENT.) In addition, with CodeDeployDefault.OneAtATime,
        /// CodeDeploy attempts to ensure that all instances but one are kept in a healthy state
        /// during the deployment. Although this allows one instance at a time to be taken offline
        /// for a new deployment, it also means that if the deployment to the last instance fails,
        /// the overall deployment is still successful.</para></note><para>For more information, see <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/instances-health.html">CodeDeploy
        /// Instance Health</a> in the <i>CodeDeploy User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeDeploy.MinimumHealthyHostsType")]
        public Amazon.CodeDeploy.MinimumHealthyHostsType MinimumHealthyHosts_Type { get; set; }
        #endregion
        
        #region Parameter TrafficRoutingConfig_Type
        /// <summary>
        /// <para>
        /// <para>The type of traffic shifting (<c>TimeBasedCanary</c> or <c>TimeBasedLinear</c>) used
        /// by a deployment configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeDeploy.TrafficRoutingType")]
        public Amazon.CodeDeploy.TrafficRoutingType TrafficRoutingConfig_Type { get; set; }
        #endregion
        
        #region Parameter MinimumHealthyHostsPerZone_Type
        /// <summary>
        /// <para>
        /// <para>The <c>type</c> associated with the <c>MinimumHealthyHostsPerZone</c> option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ZonalConfig_MinimumHealthyHostsPerZone_Type")]
        [AWSConstantClassSource("Amazon.CodeDeploy.MinimumHealthyHostsPerZoneType")]
        public Amazon.CodeDeploy.MinimumHealthyHostsPerZoneType MinimumHealthyHostsPerZone_Type { get; set; }
        #endregion
        
        #region Parameter MinimumHealthyHosts_Value
        /// <summary>
        /// <para>
        /// <para>The minimum healthy instance value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinimumHealthyHosts_Value { get; set; }
        #endregion
        
        #region Parameter MinimumHealthyHostsPerZone_Value
        /// <summary>
        /// <para>
        /// <para>The <c>value</c> associated with the <c>MinimumHealthyHostsPerZone</c> option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ZonalConfig_MinimumHealthyHostsPerZone_Value")]
        public System.Int32? MinimumHealthyHostsPerZone_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeploymentConfigId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeDeploy.Model.CreateDeploymentConfigResponse).
        /// Specifying the name of a property of type Amazon.CodeDeploy.Model.CreateDeploymentConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeploymentConfigId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeploymentConfigName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CDDeploymentConfig (CreateDeploymentConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeDeploy.Model.CreateDeploymentConfigResponse, NewCDDeploymentConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComputePlatform = this.ComputePlatform;
            context.DeploymentConfigName = this.DeploymentConfigName;
            #if MODULAR
            if (this.DeploymentConfigName == null && ParameterWasBound(nameof(this.DeploymentConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinimumHealthyHosts_Type = this.MinimumHealthyHosts_Type;
            context.MinimumHealthyHosts_Value = this.MinimumHealthyHosts_Value;
            context.TimeBasedCanary_CanaryInterval = this.TimeBasedCanary_CanaryInterval;
            context.TimeBasedCanary_CanaryPercentage = this.TimeBasedCanary_CanaryPercentage;
            context.TimeBasedLinear_LinearInterval = this.TimeBasedLinear_LinearInterval;
            context.TimeBasedLinear_LinearPercentage = this.TimeBasedLinear_LinearPercentage;
            context.TrafficRoutingConfig_Type = this.TrafficRoutingConfig_Type;
            context.ZonalConfig_FirstZoneMonitorDurationInSecond = this.ZonalConfig_FirstZoneMonitorDurationInSecond;
            context.MinimumHealthyHostsPerZone_Type = this.MinimumHealthyHostsPerZone_Type;
            context.MinimumHealthyHostsPerZone_Value = this.MinimumHealthyHostsPerZone_Value;
            context.ZonalConfig_MonitorDurationInSecond = this.ZonalConfig_MonitorDurationInSecond;
            
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
            var request = new Amazon.CodeDeploy.Model.CreateDeploymentConfigRequest();
            
            if (cmdletContext.ComputePlatform != null)
            {
                request.ComputePlatform = cmdletContext.ComputePlatform;
            }
            if (cmdletContext.DeploymentConfigName != null)
            {
                request.DeploymentConfigName = cmdletContext.DeploymentConfigName;
            }
            
             // populate MinimumHealthyHosts
            var requestMinimumHealthyHostsIsNull = true;
            request.MinimumHealthyHosts = new Amazon.CodeDeploy.Model.MinimumHealthyHosts();
            Amazon.CodeDeploy.MinimumHealthyHostsType requestMinimumHealthyHosts_minimumHealthyHosts_Type = null;
            if (cmdletContext.MinimumHealthyHosts_Type != null)
            {
                requestMinimumHealthyHosts_minimumHealthyHosts_Type = cmdletContext.MinimumHealthyHosts_Type;
            }
            if (requestMinimumHealthyHosts_minimumHealthyHosts_Type != null)
            {
                request.MinimumHealthyHosts.Type = requestMinimumHealthyHosts_minimumHealthyHosts_Type;
                requestMinimumHealthyHostsIsNull = false;
            }
            System.Int32? requestMinimumHealthyHosts_minimumHealthyHosts_Value = null;
            if (cmdletContext.MinimumHealthyHosts_Value != null)
            {
                requestMinimumHealthyHosts_minimumHealthyHosts_Value = cmdletContext.MinimumHealthyHosts_Value.Value;
            }
            if (requestMinimumHealthyHosts_minimumHealthyHosts_Value != null)
            {
                request.MinimumHealthyHosts.Value = requestMinimumHealthyHosts_minimumHealthyHosts_Value.Value;
                requestMinimumHealthyHostsIsNull = false;
            }
             // determine if request.MinimumHealthyHosts should be set to null
            if (requestMinimumHealthyHostsIsNull)
            {
                request.MinimumHealthyHosts = null;
            }
            
             // populate TrafficRoutingConfig
            var requestTrafficRoutingConfigIsNull = true;
            request.TrafficRoutingConfig = new Amazon.CodeDeploy.Model.TrafficRoutingConfig();
            Amazon.CodeDeploy.TrafficRoutingType requestTrafficRoutingConfig_trafficRoutingConfig_Type = null;
            if (cmdletContext.TrafficRoutingConfig_Type != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_Type = cmdletContext.TrafficRoutingConfig_Type;
            }
            if (requestTrafficRoutingConfig_trafficRoutingConfig_Type != null)
            {
                request.TrafficRoutingConfig.Type = requestTrafficRoutingConfig_trafficRoutingConfig_Type;
                requestTrafficRoutingConfigIsNull = false;
            }
            Amazon.CodeDeploy.Model.TimeBasedCanary requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary = null;
            
             // populate TimeBasedCanary
            var requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanaryIsNull = true;
            requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary = new Amazon.CodeDeploy.Model.TimeBasedCanary();
            System.Int32? requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryInterval = null;
            if (cmdletContext.TimeBasedCanary_CanaryInterval != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryInterval = cmdletContext.TimeBasedCanary_CanaryInterval.Value;
            }
            if (requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryInterval != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary.CanaryInterval = requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryInterval.Value;
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanaryIsNull = false;
            }
            System.Int32? requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryPercentage = null;
            if (cmdletContext.TimeBasedCanary_CanaryPercentage != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryPercentage = cmdletContext.TimeBasedCanary_CanaryPercentage.Value;
            }
            if (requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryPercentage != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary.CanaryPercentage = requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryPercentage.Value;
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanaryIsNull = false;
            }
             // determine if requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary should be set to null
            if (requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanaryIsNull)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary = null;
            }
            if (requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary != null)
            {
                request.TrafficRoutingConfig.TimeBasedCanary = requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary;
                requestTrafficRoutingConfigIsNull = false;
            }
            Amazon.CodeDeploy.Model.TimeBasedLinear requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear = null;
            
             // populate TimeBasedLinear
            var requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinearIsNull = true;
            requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear = new Amazon.CodeDeploy.Model.TimeBasedLinear();
            System.Int32? requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearInterval = null;
            if (cmdletContext.TimeBasedLinear_LinearInterval != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearInterval = cmdletContext.TimeBasedLinear_LinearInterval.Value;
            }
            if (requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearInterval != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear.LinearInterval = requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearInterval.Value;
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinearIsNull = false;
            }
            System.Int32? requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearPercentage = null;
            if (cmdletContext.TimeBasedLinear_LinearPercentage != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearPercentage = cmdletContext.TimeBasedLinear_LinearPercentage.Value;
            }
            if (requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearPercentage != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear.LinearPercentage = requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearPercentage.Value;
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinearIsNull = false;
            }
             // determine if requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear should be set to null
            if (requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinearIsNull)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear = null;
            }
            if (requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear != null)
            {
                request.TrafficRoutingConfig.TimeBasedLinear = requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear;
                requestTrafficRoutingConfigIsNull = false;
            }
             // determine if request.TrafficRoutingConfig should be set to null
            if (requestTrafficRoutingConfigIsNull)
            {
                request.TrafficRoutingConfig = null;
            }
            
             // populate ZonalConfig
            var requestZonalConfigIsNull = true;
            request.ZonalConfig = new Amazon.CodeDeploy.Model.ZonalConfig();
            System.Int64? requestZonalConfig_zonalConfig_FirstZoneMonitorDurationInSecond = null;
            if (cmdletContext.ZonalConfig_FirstZoneMonitorDurationInSecond != null)
            {
                requestZonalConfig_zonalConfig_FirstZoneMonitorDurationInSecond = cmdletContext.ZonalConfig_FirstZoneMonitorDurationInSecond.Value;
            }
            if (requestZonalConfig_zonalConfig_FirstZoneMonitorDurationInSecond != null)
            {
                request.ZonalConfig.FirstZoneMonitorDurationInSeconds = requestZonalConfig_zonalConfig_FirstZoneMonitorDurationInSecond.Value;
                requestZonalConfigIsNull = false;
            }
            System.Int64? requestZonalConfig_zonalConfig_MonitorDurationInSecond = null;
            if (cmdletContext.ZonalConfig_MonitorDurationInSecond != null)
            {
                requestZonalConfig_zonalConfig_MonitorDurationInSecond = cmdletContext.ZonalConfig_MonitorDurationInSecond.Value;
            }
            if (requestZonalConfig_zonalConfig_MonitorDurationInSecond != null)
            {
                request.ZonalConfig.MonitorDurationInSeconds = requestZonalConfig_zonalConfig_MonitorDurationInSecond.Value;
                requestZonalConfigIsNull = false;
            }
            Amazon.CodeDeploy.Model.MinimumHealthyHostsPerZone requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone = null;
            
             // populate MinimumHealthyHostsPerZone
            var requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZoneIsNull = true;
            requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone = new Amazon.CodeDeploy.Model.MinimumHealthyHostsPerZone();
            Amazon.CodeDeploy.MinimumHealthyHostsPerZoneType requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone_minimumHealthyHostsPerZone_Type = null;
            if (cmdletContext.MinimumHealthyHostsPerZone_Type != null)
            {
                requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone_minimumHealthyHostsPerZone_Type = cmdletContext.MinimumHealthyHostsPerZone_Type;
            }
            if (requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone_minimumHealthyHostsPerZone_Type != null)
            {
                requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone.Type = requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone_minimumHealthyHostsPerZone_Type;
                requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZoneIsNull = false;
            }
            System.Int32? requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone_minimumHealthyHostsPerZone_Value = null;
            if (cmdletContext.MinimumHealthyHostsPerZone_Value != null)
            {
                requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone_minimumHealthyHostsPerZone_Value = cmdletContext.MinimumHealthyHostsPerZone_Value.Value;
            }
            if (requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone_minimumHealthyHostsPerZone_Value != null)
            {
                requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone.Value = requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone_minimumHealthyHostsPerZone_Value.Value;
                requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZoneIsNull = false;
            }
             // determine if requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone should be set to null
            if (requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZoneIsNull)
            {
                requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone = null;
            }
            if (requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone != null)
            {
                request.ZonalConfig.MinimumHealthyHostsPerZone = requestZonalConfig_zonalConfig_MinimumHealthyHostsPerZone;
                requestZonalConfigIsNull = false;
            }
             // determine if request.ZonalConfig should be set to null
            if (requestZonalConfigIsNull)
            {
                request.ZonalConfig = null;
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
        
        private Amazon.CodeDeploy.Model.CreateDeploymentConfigResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.CreateDeploymentConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "CreateDeploymentConfig");
            try
            {
                #if DESKTOP
                return client.CreateDeploymentConfig(request);
                #elif CORECLR
                return client.CreateDeploymentConfigAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CodeDeploy.ComputePlatform ComputePlatform { get; set; }
            public System.String DeploymentConfigName { get; set; }
            public Amazon.CodeDeploy.MinimumHealthyHostsType MinimumHealthyHosts_Type { get; set; }
            public System.Int32? MinimumHealthyHosts_Value { get; set; }
            public System.Int32? TimeBasedCanary_CanaryInterval { get; set; }
            public System.Int32? TimeBasedCanary_CanaryPercentage { get; set; }
            public System.Int32? TimeBasedLinear_LinearInterval { get; set; }
            public System.Int32? TimeBasedLinear_LinearPercentage { get; set; }
            public Amazon.CodeDeploy.TrafficRoutingType TrafficRoutingConfig_Type { get; set; }
            public System.Int64? ZonalConfig_FirstZoneMonitorDurationInSecond { get; set; }
            public Amazon.CodeDeploy.MinimumHealthyHostsPerZoneType MinimumHealthyHostsPerZone_Type { get; set; }
            public System.Int32? MinimumHealthyHostsPerZone_Value { get; set; }
            public System.Int64? ZonalConfig_MonitorDurationInSecond { get; set; }
            public System.Func<Amazon.CodeDeploy.Model.CreateDeploymentConfigResponse, NewCDDeploymentConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeploymentConfigId;
        }
        
    }
}
