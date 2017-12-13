/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the AWS CodeDeploy CreateDeploymentConfig API operation.", Operation = new[] {"CreateDeploymentConfig"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CodeDeploy.Model.CreateDeploymentConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCDDeploymentConfigCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter TimeBasedCanary_CanaryInterval
        /// <summary>
        /// <para>
        /// <para>The number of minutes between the first and second traffic shifts of a <code>TimeBasedCanary</code>
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrafficRoutingConfig_TimeBasedCanary_CanaryInterval")]
        public System.Int32 TimeBasedCanary_CanaryInterval { get; set; }
        #endregion
        
        #region Parameter TimeBasedCanary_CanaryPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of traffic to shift in the first increment of a <code>TimeBasedCanary</code>
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrafficRoutingConfig_TimeBasedCanary_CanaryPercentage")]
        public System.Int32 TimeBasedCanary_CanaryPercentage { get; set; }
        #endregion
        
        #region Parameter ComputePlatform
        /// <summary>
        /// <para>
        /// <para>The destination platform type for the deployment (<code>Lambda</code> or <code>Server</code>&gt;).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.ComputePlatform")]
        public Amazon.CodeDeploy.ComputePlatform ComputePlatform { get; set; }
        #endregion
        
        #region Parameter DeploymentConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the deployment configuration to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeploymentConfigName { get; set; }
        #endregion
        
        #region Parameter TimeBasedLinear_LinearInterval
        /// <summary>
        /// <para>
        /// <para>The number of minutes between each incremental traffic shift of a <code>TimeBasedLinear</code>
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrafficRoutingConfig_TimeBasedLinear_LinearInterval")]
        public System.Int32 TimeBasedLinear_LinearInterval { get; set; }
        #endregion
        
        #region Parameter TimeBasedLinear_LinearPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of traffic that is shifted at the start of each increment of a <code>TimeBasedLinear</code>
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrafficRoutingConfig_TimeBasedLinear_LinearPercentage")]
        public System.Int32 TimeBasedLinear_LinearPercentage { get; set; }
        #endregion
        
        #region Parameter MinimumHealthyHosts_Type
        /// <summary>
        /// <para>
        /// <para>The minimum healthy instance type:</para><ul><li><para>HOST_COUNT: The minimum number of healthy instance as an absolute value.</para></li><li><para>FLEET_PERCENT: The minimum number of healthy instance as a percentage of the total
        /// number of instance in the deployment.</para></li></ul><para>In an example of nine instance, if a HOST_COUNT of six is specified, deploy to up
        /// to three instances at a time. The deployment will be successful if six or more instances
        /// are deployed to successfully; otherwise, the deployment fails. If a FLEET_PERCENT
        /// of 40 is specified, deploy to up to five instance at a time. The deployment will be
        /// successful if four or more instance are deployed to successfully; otherwise, the deployment
        /// fails.</para><note><para>In a call to the get deployment configuration operation, CodeDeployDefault.OneAtATime
        /// will return a minimum healthy instance type of MOST_CONCURRENCY and a value of 1.
        /// This means a deployment to only one instance at a time. (You cannot set the type to
        /// MOST_CONCURRENCY, only to HOST_COUNT or FLEET_PERCENT.) In addition, with CodeDeployDefault.OneAtATime,
        /// AWS CodeDeploy will try to ensure that all instances but one are kept in a healthy
        /// state during the deployment. Although this allows one instance at a time to be taken
        /// offline for a new deployment, it also means that if the deployment to the last instance
        /// fails, the overall deployment still succeeds.</para></note><para>For more information, see <a href="http://docs.aws.amazon.com/codedeploy/latest/userguide/instances-health.html">AWS
        /// CodeDeploy Instance Health</a> in the <i>AWS CodeDeploy User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.MinimumHealthyHostsType")]
        public Amazon.CodeDeploy.MinimumHealthyHostsType MinimumHealthyHosts_Type { get; set; }
        #endregion
        
        #region Parameter TrafficRoutingConfig_Type
        /// <summary>
        /// <para>
        /// <para>The type of traffic shifting (<code>TimeBasedCanary</code> or <code>TimeBasedLinear</code>)
        /// used by a deployment configuration .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeDeploy.TrafficRoutingType")]
        public Amazon.CodeDeploy.TrafficRoutingType TrafficRoutingConfig_Type { get; set; }
        #endregion
        
        #region Parameter MinimumHealthyHosts_Value
        /// <summary>
        /// <para>
        /// <para>The minimum healthy instance value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MinimumHealthyHosts_Value { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DeploymentConfigName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CDDeploymentConfig (CreateDeploymentConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ComputePlatform = this.ComputePlatform;
            context.DeploymentConfigName = this.DeploymentConfigName;
            context.MinimumHealthyHosts_Type = this.MinimumHealthyHosts_Type;
            if (ParameterWasBound("MinimumHealthyHosts_Value"))
                context.MinimumHealthyHosts_Value = this.MinimumHealthyHosts_Value;
            if (ParameterWasBound("TimeBasedCanary_CanaryInterval"))
                context.TrafficRoutingConfig_TimeBasedCanary_CanaryInterval = this.TimeBasedCanary_CanaryInterval;
            if (ParameterWasBound("TimeBasedCanary_CanaryPercentage"))
                context.TrafficRoutingConfig_TimeBasedCanary_CanaryPercentage = this.TimeBasedCanary_CanaryPercentage;
            if (ParameterWasBound("TimeBasedLinear_LinearInterval"))
                context.TrafficRoutingConfig_TimeBasedLinear_LinearInterval = this.TimeBasedLinear_LinearInterval;
            if (ParameterWasBound("TimeBasedLinear_LinearPercentage"))
                context.TrafficRoutingConfig_TimeBasedLinear_LinearPercentage = this.TimeBasedLinear_LinearPercentage;
            context.TrafficRoutingConfig_Type = this.TrafficRoutingConfig_Type;
            
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
            bool requestMinimumHealthyHostsIsNull = true;
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
            bool requestTrafficRoutingConfigIsNull = true;
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
            bool requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanaryIsNull = true;
            requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary = new Amazon.CodeDeploy.Model.TimeBasedCanary();
            System.Int32? requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryInterval = null;
            if (cmdletContext.TrafficRoutingConfig_TimeBasedCanary_CanaryInterval != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryInterval = cmdletContext.TrafficRoutingConfig_TimeBasedCanary_CanaryInterval.Value;
            }
            if (requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryInterval != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary.CanaryInterval = requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryInterval.Value;
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanaryIsNull = false;
            }
            System.Int32? requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryPercentage = null;
            if (cmdletContext.TrafficRoutingConfig_TimeBasedCanary_CanaryPercentage != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedCanary_timeBasedCanary_CanaryPercentage = cmdletContext.TrafficRoutingConfig_TimeBasedCanary_CanaryPercentage.Value;
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
            bool requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinearIsNull = true;
            requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear = new Amazon.CodeDeploy.Model.TimeBasedLinear();
            System.Int32? requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearInterval = null;
            if (cmdletContext.TrafficRoutingConfig_TimeBasedLinear_LinearInterval != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearInterval = cmdletContext.TrafficRoutingConfig_TimeBasedLinear_LinearInterval.Value;
            }
            if (requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearInterval != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear.LinearInterval = requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearInterval.Value;
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinearIsNull = false;
            }
            System.Int32? requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearPercentage = null;
            if (cmdletContext.TrafficRoutingConfig_TimeBasedLinear_LinearPercentage != null)
            {
                requestTrafficRoutingConfig_trafficRoutingConfig_TimeBasedLinear_timeBasedLinear_LinearPercentage = cmdletContext.TrafficRoutingConfig_TimeBasedLinear_LinearPercentage.Value;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DeploymentConfigId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDeploymentConfigAsync(request);
                return task.Result;
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
            public System.Int32? TrafficRoutingConfig_TimeBasedCanary_CanaryInterval { get; set; }
            public System.Int32? TrafficRoutingConfig_TimeBasedCanary_CanaryPercentage { get; set; }
            public System.Int32? TrafficRoutingConfig_TimeBasedLinear_LinearInterval { get; set; }
            public System.Int32? TrafficRoutingConfig_TimeBasedLinear_LinearPercentage { get; set; }
            public Amazon.CodeDeploy.TrafficRoutingType TrafficRoutingConfig_Type { get; set; }
        }
        
    }
}
