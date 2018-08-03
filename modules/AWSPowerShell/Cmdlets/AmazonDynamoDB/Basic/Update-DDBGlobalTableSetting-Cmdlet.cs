/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Updates settings for a global table.
    /// </summary>
    [Cmdlet("Update", "DDBGlobalTableSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB UpdateGlobalTableSettings API operation.", Operation = new[] {"UpdateGlobalTableSettings"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse",
        "This cmdlet returns a Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDDBGlobalTableSettingCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled
        /// <summary>
        /// <para>
        /// <para>Disabled autoscaling for this global table or global secondary index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled { get; set; }
        #endregion
        
        #region Parameter GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn
        /// <summary>
        /// <para>
        /// <para>Role ARN used for configuring autoscaling policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_DisableScaleIn
        /// <summary>
        /// <para>
        /// <para>Indicates whether scale in by the target tracking policy is disabled. If the value
        /// is true, scale in is disabled and the target tracking policy won't remove capacity
        /// from the scalable resource. Otherwise, scale in is enabled and the target tracking
        /// policy can remove capacity from the scalable resource. The default value is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_DisableScaleIn")]
        public System.Boolean TargetTrackingScalingPolicyConfiguration_DisableScaleIn { get; set; }
        #endregion
        
        #region Parameter GlobalTableGlobalSecondaryIndexSettingsUpdate
        /// <summary>
        /// <para>
        /// <para>Represents the settings of a global secondary index for a global table that will be
        /// modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.DynamoDBv2.Model.GlobalTableGlobalSecondaryIndexSettingsUpdate[] GlobalTableGlobalSecondaryIndexSettingsUpdate { get; set; }
        #endregion
        
        #region Parameter GlobalTableName
        /// <summary>
        /// <para>
        /// <para>The name of the global table</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String GlobalTableName { get; set; }
        #endregion
        
        #region Parameter GlobalTableProvisionedWriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The maximum number of writes consumed per second before DynamoDB returns a <code>ThrottlingException.</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalTableProvisionedWriteCapacityUnits")]
        public System.Int64 GlobalTableProvisionedWriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnit
        /// <summary>
        /// <para>
        /// <para>The maximum capacity units that a global table or global secondary index should be
        /// scaled up to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnits")]
        public System.Int64 GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnit { get; set; }
        #endregion
        
        #region Parameter GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnit
        /// <summary>
        /// <para>
        /// <para>The minimum capacity units that a global table or global secondary index should be
        /// scaled down to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnits")]
        public System.Int64 GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnit { get; set; }
        #endregion
        
        #region Parameter ScalingPolicyUpdate_PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the scaling policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_PolicyName")]
        public System.String ScalingPolicyUpdate_PolicyName { get; set; }
        #endregion
        
        #region Parameter ReplicaSettingsUpdate
        /// <summary>
        /// <para>
        /// <para>Represents the settings for a global table in a region that will be modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.DynamoDBv2.Model.ReplicaSettingsUpdate[] ReplicaSettingsUpdate { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_ScaleInCooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scale in activity completes before another
        /// scale in activity can start. The cooldown period is used to block subsequent scale
        /// in requests until it has expired. You should scale in conservatively to protect your
        /// application's availability. However, if another alarm triggers a scale out policy
        /// during the cooldown period after a scale-in, application autoscaling scales out your
        /// scalable target immediately. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown")]
        public System.Int32 TargetTrackingScalingPolicyConfiguration_ScaleInCooldown { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scale out activity completes before another
        /// scale out activity can start. While the cooldown period is in effect, the capacity
        /// that has been added by the previous scale out event that initiated the cooldown is
        /// calculated as part of the desired capacity for the next scale out. You should continuously
        /// (but not excessively) scale out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown")]
        public System.Int32 TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_TargetValue
        /// <summary>
        /// <para>
        /// <para>The target value for the metric. The range is 8.515920e-109 to 1.174271e+108 (Base
        /// 10) or 2e-360 to 2e360 (Base 2).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_TargetValue")]
        public System.Double TargetTrackingScalingPolicyConfiguration_TargetValue { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GlobalTableName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBGlobalTableSetting (UpdateGlobalTableSettings)"))
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
            
            if (this.GlobalTableGlobalSecondaryIndexSettingsUpdate != null)
            {
                context.GlobalTableGlobalSecondaryIndexSettingsUpdate = new List<Amazon.DynamoDBv2.Model.GlobalTableGlobalSecondaryIndexSettingsUpdate>(this.GlobalTableGlobalSecondaryIndexSettingsUpdate);
            }
            context.GlobalTableName = this.GlobalTableName;
            if (ParameterWasBound("GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled"))
                context.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled = this.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled;
            context.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn = this.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn;
            if (ParameterWasBound("GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnit"))
                context.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnits = this.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnit;
            if (ParameterWasBound("GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnit"))
                context.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnits = this.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnit;
            context.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_PolicyName = this.ScalingPolicyUpdate_PolicyName;
            if (ParameterWasBound("TargetTrackingScalingPolicyConfiguration_DisableScaleIn"))
                context.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_DisableScaleIn = this.TargetTrackingScalingPolicyConfiguration_DisableScaleIn;
            if (ParameterWasBound("TargetTrackingScalingPolicyConfiguration_ScaleInCooldown"))
                context.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown = this.TargetTrackingScalingPolicyConfiguration_ScaleInCooldown;
            if (ParameterWasBound("TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown"))
                context.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown = this.TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown;
            if (ParameterWasBound("TargetTrackingScalingPolicyConfiguration_TargetValue"))
                context.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_TargetValue = this.TargetTrackingScalingPolicyConfiguration_TargetValue;
            if (ParameterWasBound("GlobalTableProvisionedWriteCapacityUnit"))
                context.GlobalTableProvisionedWriteCapacityUnits = this.GlobalTableProvisionedWriteCapacityUnit;
            if (this.ReplicaSettingsUpdate != null)
            {
                context.ReplicaSettingsUpdate = new List<Amazon.DynamoDBv2.Model.ReplicaSettingsUpdate>(this.ReplicaSettingsUpdate);
            }
            
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
            var request = new Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsRequest();
            
            if (cmdletContext.GlobalTableGlobalSecondaryIndexSettingsUpdate != null)
            {
                request.GlobalTableGlobalSecondaryIndexSettingsUpdate = cmdletContext.GlobalTableGlobalSecondaryIndexSettingsUpdate;
            }
            if (cmdletContext.GlobalTableName != null)
            {
                request.GlobalTableName = cmdletContext.GlobalTableName;
            }
            
             // populate GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate
            bool requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdateIsNull = true;
            request.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate = new Amazon.DynamoDBv2.Model.AutoScalingSettingsUpdate();
            System.Boolean? requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled = null;
            if (cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled = cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled.Value;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled != null)
            {
                request.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate.AutoScalingDisabled = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled.Value;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdateIsNull = false;
            }
            System.String requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn = null;
            if (cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn = cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn != null)
            {
                request.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate.AutoScalingRoleArn = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdateIsNull = false;
            }
            System.Int64? requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnit = null;
            if (cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnits != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnit = cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnits.Value;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnit != null)
            {
                request.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate.MaximumUnits = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnit.Value;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdateIsNull = false;
            }
            System.Int64? requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnit = null;
            if (cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnits != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnit = cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnits.Value;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnit != null)
            {
                request.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate.MinimumUnits = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnit.Value;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdateIsNull = false;
            }
            Amazon.DynamoDBv2.Model.AutoScalingPolicyUpdate requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate = null;
            
             // populate ScalingPolicyUpdate
            bool requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdateIsNull = true;
            requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate = new Amazon.DynamoDBv2.Model.AutoScalingPolicyUpdate();
            System.String requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_scalingPolicyUpdate_PolicyName = null;
            if (cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_PolicyName != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_scalingPolicyUpdate_PolicyName = cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_PolicyName;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_scalingPolicyUpdate_PolicyName != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate.PolicyName = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_scalingPolicyUpdate_PolicyName;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdateIsNull = false;
            }
            Amazon.DynamoDBv2.Model.AutoScalingTargetTrackingScalingPolicyConfigurationUpdate requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration = null;
            
             // populate TargetTrackingScalingPolicyConfiguration
            bool requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfigurationIsNull = true;
            requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration = new Amazon.DynamoDBv2.Model.AutoScalingTargetTrackingScalingPolicyConfigurationUpdate();
            System.Boolean? requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_DisableScaleIn = null;
            if (cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_DisableScaleIn != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_DisableScaleIn = cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_DisableScaleIn.Value;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_DisableScaleIn != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration.DisableScaleIn = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_DisableScaleIn.Value;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleInCooldown = null;
            if (cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleInCooldown = cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown.Value;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleInCooldown != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration.ScaleInCooldown = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleInCooldown.Value;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleOutCooldown = null;
            if (cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleOutCooldown = cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown.Value;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleOutCooldown != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration.ScaleOutCooldown = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleOutCooldown.Value;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Double? requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_TargetValue = null;
            if (cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_TargetValue != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_TargetValue = cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_TargetValue.Value;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_TargetValue != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration.TargetValue = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_TargetValue.Value;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
             // determine if requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration should be set to null
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfigurationIsNull)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration = null;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration != null)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate.TargetTrackingScalingPolicyConfiguration = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdateIsNull = false;
            }
             // determine if requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate should be set to null
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdateIsNull)
            {
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate = null;
            }
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate != null)
            {
                request.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate.ScalingPolicyUpdate = requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_globalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate;
                requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdateIsNull = false;
            }
             // determine if request.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate should be set to null
            if (requestGlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdateIsNull)
            {
                request.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate = null;
            }
            if (cmdletContext.GlobalTableProvisionedWriteCapacityUnits != null)
            {
                request.GlobalTableProvisionedWriteCapacityUnits = cmdletContext.GlobalTableProvisionedWriteCapacityUnits.Value;
            }
            if (cmdletContext.ReplicaSettingsUpdate != null)
            {
                request.ReplicaSettingsUpdate = cmdletContext.ReplicaSettingsUpdate;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "UpdateGlobalTableSettings");
            try
            {
                #if DESKTOP
                return client.UpdateGlobalTableSettings(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateGlobalTableSettingsAsync(request);
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
            public List<Amazon.DynamoDBv2.Model.GlobalTableGlobalSecondaryIndexSettingsUpdate> GlobalTableGlobalSecondaryIndexSettingsUpdate { get; set; }
            public System.String GlobalTableName { get; set; }
            public System.Boolean? GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingDisabled { get; set; }
            public System.String GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_AutoScalingRoleArn { get; set; }
            public System.Int64? GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MaximumUnits { get; set; }
            public System.Int64? GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_MinimumUnits { get; set; }
            public System.String GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_PolicyName { get; set; }
            public System.Boolean? GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_DisableScaleIn { get; set; }
            public System.Int32? GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown { get; set; }
            public System.Int32? GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown { get; set; }
            public System.Double? GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate_ScalingPolicyUpdate_TargetTrackingScalingPolicyConfiguration_TargetValue { get; set; }
            public System.Int64? GlobalTableProvisionedWriteCapacityUnits { get; set; }
            public List<Amazon.DynamoDBv2.Model.ReplicaSettingsUpdate> ReplicaSettingsUpdate { get; set; }
        }
        
    }
}
