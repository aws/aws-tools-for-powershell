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
using Amazon.ECS;
using Amazon.ECS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Updates the specified daemon. When you update a daemon, a new deployment is triggered
    /// that progressively rolls out the changes to the container instances associated with
    /// the daemon's capacity providers. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/daemon-deployments.html">Daemon
    /// deployments</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// Amazon ECS drains existing container instances and provisions new instances with the
    /// updated daemon. Amazon ECS automatically launches replacement tasks for your services.
    /// </para><important><para>
    /// Updating a daemon triggers a rolling deployment that drains and replaces container
    /// instances. Plan updates during maintenance windows to minimize impact on running services.
    /// </para></important><note><para>
    /// ECS Managed Daemons is only supported for Amazon ECS Managed Instances Capacity Providers.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "ECSDaemon", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.UpdateDaemonResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateDaemon API operation.", Operation = new[] {"UpdateDaemon"}, SelectReturnType = typeof(Amazon.ECS.Model.UpdateDaemonResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.UpdateDaemonResponse",
        "This cmdlet returns an Amazon.ECS.Model.UpdateDaemonResponse object containing multiple properties."
    )]
    public partial class UpdateECSDaemonCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeploymentConfiguration_Alarms_AlarmName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch alarm names to monitor during a daemon deployment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_Alarms_AlarmNames")]
        public System.String[] DeploymentConfiguration_Alarms_AlarmName { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_BakeTimeInMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time (in minutes) to wait after a successful deployment step before
        /// proceeding. This allows time to monitor for issues before continuing. The default
        /// value is 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_BakeTimeInMinutes")]
        public System.Int32? DeploymentConfiguration_BakeTimeInMinute { get; set; }
        #endregion
        
        #region Parameter CapacityProviderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the capacity providers to associate with the daemon.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("CapacityProviderArns")]
        public System.String[] CapacityProviderArn { get; set; }
        #endregion
        
        #region Parameter DaemonArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the daemon to update.</para>
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
        public System.String DaemonArn { get; set; }
        #endregion
        
        #region Parameter DaemonTaskDefinitionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the daemon task definition to use for the updated
        /// daemon.</para>
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
        public System.String DaemonTaskDefinitionArn { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_DrainPercent
        /// <summary>
        /// <para>
        /// <para>The percentage of container instances to drain simultaneously during a daemon deployment.
        /// Valid values are between 0.0 and 100.0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? DeploymentConfiguration_DrainPercent { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_Alarms_Enable
        /// <summary>
        /// <para>
        /// <para>Determines whether to use the CloudWatch alarm option in the daemon deployment process.
        /// The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeploymentConfiguration_Alarms_Enable { get; set; }
        #endregion
        
        #region Parameter EnableECSManagedTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to turn on Amazon ECS managed tags for the tasks in the daemon.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-using-tags.html">Tagging
        /// your Amazon ECS resources</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableECSManagedTags")]
        public System.Boolean? EnableECSManagedTag { get; set; }
        #endregion
        
        #region Parameter EnableExecuteCommand
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, the execute command functionality is turned on for all tasks in the
        /// daemon. If <c>false</c>, the execute command functionality is turned off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableExecuteCommand { get; set; }
        #endregion
        
        #region Parameter PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate the tags from the daemon to the daemon tasks. If you
        /// don't specify a value, the tags aren't propagated. You can only propagate tags to
        /// daemon tasks during task creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagateTags")]
        [AWSConstantClassSource("Amazon.ECS.DaemonPropagateTags")]
        public Amazon.ECS.DaemonPropagateTags PropagateTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.UpdateDaemonResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.UpdateDaemonResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DaemonArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSDaemon (UpdateDaemon)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.UpdateDaemonResponse, UpdateECSDaemonCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CapacityProviderArn != null)
            {
                context.CapacityProviderArn = new List<System.String>(this.CapacityProviderArn);
            }
            #if MODULAR
            if (this.CapacityProviderArn == null && ParameterWasBound(nameof(this.CapacityProviderArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityProviderArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DaemonArn = this.DaemonArn;
            #if MODULAR
            if (this.DaemonArn == null && ParameterWasBound(nameof(this.DaemonArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DaemonArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DaemonTaskDefinitionArn = this.DaemonTaskDefinitionArn;
            #if MODULAR
            if (this.DaemonTaskDefinitionArn == null && ParameterWasBound(nameof(this.DaemonTaskDefinitionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DaemonTaskDefinitionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DeploymentConfiguration_Alarms_AlarmName != null)
            {
                context.DeploymentConfiguration_Alarms_AlarmName = new List<System.String>(this.DeploymentConfiguration_Alarms_AlarmName);
            }
            context.DeploymentConfiguration_Alarms_Enable = this.DeploymentConfiguration_Alarms_Enable;
            context.DeploymentConfiguration_BakeTimeInMinute = this.DeploymentConfiguration_BakeTimeInMinute;
            context.DeploymentConfiguration_DrainPercent = this.DeploymentConfiguration_DrainPercent;
            context.EnableECSManagedTag = this.EnableECSManagedTag;
            context.EnableExecuteCommand = this.EnableExecuteCommand;
            context.PropagateTag = this.PropagateTag;
            
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
            var request = new Amazon.ECS.Model.UpdateDaemonRequest();
            
            if (cmdletContext.CapacityProviderArn != null)
            {
                request.CapacityProviderArns = cmdletContext.CapacityProviderArn;
            }
            if (cmdletContext.DaemonArn != null)
            {
                request.DaemonArn = cmdletContext.DaemonArn;
            }
            if (cmdletContext.DaemonTaskDefinitionArn != null)
            {
                request.DaemonTaskDefinitionArn = cmdletContext.DaemonTaskDefinitionArn;
            }
            
             // populate DeploymentConfiguration
            var requestDeploymentConfigurationIsNull = true;
            request.DeploymentConfiguration = new Amazon.ECS.Model.DaemonDeploymentConfiguration();
            System.Int32? requestDeploymentConfiguration_deploymentConfiguration_BakeTimeInMinute = null;
            if (cmdletContext.DeploymentConfiguration_BakeTimeInMinute != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_BakeTimeInMinute = cmdletContext.DeploymentConfiguration_BakeTimeInMinute.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_BakeTimeInMinute != null)
            {
                request.DeploymentConfiguration.BakeTimeInMinutes = requestDeploymentConfiguration_deploymentConfiguration_BakeTimeInMinute.Value;
                requestDeploymentConfigurationIsNull = false;
            }
            System.Double? requestDeploymentConfiguration_deploymentConfiguration_DrainPercent = null;
            if (cmdletContext.DeploymentConfiguration_DrainPercent != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DrainPercent = cmdletContext.DeploymentConfiguration_DrainPercent.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_DrainPercent != null)
            {
                request.DeploymentConfiguration.DrainPercent = requestDeploymentConfiguration_deploymentConfiguration_DrainPercent.Value;
                requestDeploymentConfigurationIsNull = false;
            }
            Amazon.ECS.Model.DaemonAlarmConfiguration requestDeploymentConfiguration_deploymentConfiguration_Alarms = null;
            
             // populate Alarms
            var requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = true;
            requestDeploymentConfiguration_deploymentConfiguration_Alarms = new Amazon.ECS.Model.DaemonAlarmConfiguration();
            List<System.String> requestDeploymentConfiguration_deploymentConfiguration_Alarms_deploymentConfiguration_Alarms_AlarmName = null;
            if (cmdletContext.DeploymentConfiguration_Alarms_AlarmName != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms_deploymentConfiguration_Alarms_AlarmName = cmdletContext.DeploymentConfiguration_Alarms_AlarmName;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms_deploymentConfiguration_Alarms_AlarmName != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms.AlarmNames = requestDeploymentConfiguration_deploymentConfiguration_Alarms_deploymentConfiguration_Alarms_AlarmName;
                requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = false;
            }
            System.Boolean? requestDeploymentConfiguration_deploymentConfiguration_Alarms_deploymentConfiguration_Alarms_Enable = null;
            if (cmdletContext.DeploymentConfiguration_Alarms_Enable != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms_deploymentConfiguration_Alarms_Enable = cmdletContext.DeploymentConfiguration_Alarms_Enable.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms_deploymentConfiguration_Alarms_Enable != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms.Enable = requestDeploymentConfiguration_deploymentConfiguration_Alarms_deploymentConfiguration_Alarms_Enable.Value;
                requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = false;
            }
             // determine if requestDeploymentConfiguration_deploymentConfiguration_Alarms should be set to null
            if (requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms = null;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms != null)
            {
                request.DeploymentConfiguration.Alarms = requestDeploymentConfiguration_deploymentConfiguration_Alarms;
                requestDeploymentConfigurationIsNull = false;
            }
             // determine if request.DeploymentConfiguration should be set to null
            if (requestDeploymentConfigurationIsNull)
            {
                request.DeploymentConfiguration = null;
            }
            if (cmdletContext.EnableECSManagedTag != null)
            {
                request.EnableECSManagedTags = cmdletContext.EnableECSManagedTag.Value;
            }
            if (cmdletContext.EnableExecuteCommand != null)
            {
                request.EnableExecuteCommand = cmdletContext.EnableExecuteCommand.Value;
            }
            if (cmdletContext.PropagateTag != null)
            {
                request.PropagateTags = cmdletContext.PropagateTag;
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
        
        private Amazon.ECS.Model.UpdateDaemonResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.UpdateDaemonRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "UpdateDaemon");
            try
            {
                return client.UpdateDaemonAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CapacityProviderArn { get; set; }
            public System.String DaemonArn { get; set; }
            public System.String DaemonTaskDefinitionArn { get; set; }
            public List<System.String> DeploymentConfiguration_Alarms_AlarmName { get; set; }
            public System.Boolean? DeploymentConfiguration_Alarms_Enable { get; set; }
            public System.Int32? DeploymentConfiguration_BakeTimeInMinute { get; set; }
            public System.Double? DeploymentConfiguration_DrainPercent { get; set; }
            public System.Boolean? EnableECSManagedTag { get; set; }
            public System.Boolean? EnableExecuteCommand { get; set; }
            public Amazon.ECS.DaemonPropagateTags PropagateTag { get; set; }
            public System.Func<Amazon.ECS.Model.UpdateDaemonResponse, UpdateECSDaemonCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
