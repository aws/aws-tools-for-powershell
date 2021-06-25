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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Starts a new instance refresh operation. An instance refresh performs a rolling replacement
    /// of all or some instances in an Auto Scaling group. Each instance is terminated first
    /// and then replaced, which temporarily reduces the capacity available within your Auto
    /// Scaling group.
    /// 
    ///  
    /// <para>
    /// This operation is part of the <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-instance-refresh.html">instance
    /// refresh feature</a> in Amazon EC2 Auto Scaling, which helps you update instances in
    /// your Auto Scaling group. This feature is helpful, for example, when you have a new
    /// AMI or a new user data script. You just need to create a new launch template that
    /// specifies the new AMI or user data script. Then start an instance refresh to immediately
    /// begin the process of updating instances in the group. 
    /// </para><para>
    /// If the call succeeds, it creates a new instance refresh request with a unique ID that
    /// you can use to track its progress. To query its status, call the <a>DescribeInstanceRefreshes</a>
    /// API. To describe the instance refreshes that have already run, call the <a>DescribeInstanceRefreshes</a>
    /// API. To cancel an instance refresh operation in progress, use the <a>CancelInstanceRefresh</a>
    /// API. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "ASInstanceRefresh", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Auto Scaling StartInstanceRefresh API operation.", Operation = new[] {"StartInstanceRefresh"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.StartInstanceRefreshResponse))]
    [AWSCmdletOutput("System.String or Amazon.AutoScaling.Model.StartInstanceRefreshResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AutoScaling.Model.StartInstanceRefreshResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartASInstanceRefreshCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
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
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter Preferences_CheckpointDelay
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, to wait after a checkpoint before continuing. This
        /// property is optional, but if you specify a value for it, you must also specify a value
        /// for <code>CheckpointPercentages</code>. If you specify a value for <code>CheckpointPercentages</code>
        /// and not for <code>CheckpointDelay</code>, the <code>CheckpointDelay</code> defaults
        /// to <code>3600</code> (1 hour). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Preferences_CheckpointDelay { get; set; }
        #endregion
        
        #region Parameter Preferences_CheckpointPercentage
        /// <summary>
        /// <para>
        /// <para>Threshold values for each checkpoint in ascending order. Each number must be unique.
        /// To replace all instances in the Auto Scaling group, the last number in the array must
        /// be <code>100</code>.</para><para>For usage examples, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-adding-checkpoints-instance-refresh.html">Adding
        /// checkpoints to an instance refresh</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_CheckpointPercentages")]
        public System.Int32[] Preferences_CheckpointPercentage { get; set; }
        #endregion
        
        #region Parameter Preferences_InstanceWarmup
        /// <summary>
        /// <para>
        /// <para>The number of seconds until a newly launched instance is configured and ready to use.
        /// During this time, Amazon EC2 Auto Scaling does not immediately move on to the next
        /// replacement. The default is to use the value for the health check grace period defined
        /// for the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Preferences_InstanceWarmup { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template. To get the template ID, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplates.html">DescribeLaunchTemplates</a>
        /// API operation. New launch templates can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplate.html">CreateLaunchTemplate</a>
        /// API. </para><para>Conditional: You must specify either a <code>LaunchTemplateId</code> or a <code>LaunchTemplateName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredConfiguration_LaunchTemplate_LaunchTemplateId")]
        public System.String LaunchTemplate_LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template. To get the template name, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplates.html">DescribeLaunchTemplates</a>
        /// API operation. New launch templates can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplate.html">CreateLaunchTemplate</a>
        /// API. </para><para>Conditional: You must specify either a <code>LaunchTemplateId</code> or a <code>LaunchTemplateName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredConfiguration_LaunchTemplate_LaunchTemplateName")]
        public System.String LaunchTemplate_LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter Preferences_MinHealthyPercentage
        /// <summary>
        /// <para>
        /// <para>The amount of capacity in the Auto Scaling group that must remain healthy during an
        /// instance refresh to allow the operation to continue. The value is expressed as a percentage
        /// of the desired capacity of the Auto Scaling group (rounded up to the nearest integer).
        /// The default is <code>90</code>.</para><para>Setting the minimum healthy percentage to 100 percent limits the rate of replacement
        /// to one instance at a time. In contrast, setting it to 0 percent has the effect of
        /// replacing all instances at the same time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Preferences_MinHealthyPercentage { get; set; }
        #endregion
        
        #region Parameter DesiredConfiguration_MixedInstancesPolicy
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AutoScaling.Model.MixedInstancesPolicy DesiredConfiguration_MixedInstancesPolicy { get; set; }
        #endregion
        
        #region Parameter Preferences_SkipMatching
        /// <summary>
        /// <para>
        /// <para>A boolean value that indicates whether skip matching is enabled. If true, then Amazon
        /// EC2 Auto Scaling skips replacing instances that match the desired configuration. If
        /// no desired configuration is specified, then it skips replacing instances that have
        /// the same configuration that is already set on the group. The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Preferences_SkipMatching { get; set; }
        #endregion
        
        #region Parameter Strategy
        /// <summary>
        /// <para>
        /// <para>The strategy to use for the instance refresh. The only valid value is <code>Rolling</code>.</para><para>A rolling update helps you update your instances gradually. A rolling update can fail
        /// due to failed health checks or if instances are on standby or are protected from scale
        /// in. If the rolling update process fails, any instances that are replaced are not rolled
        /// back to their previous configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AutoScaling.RefreshStrategy")]
        public Amazon.AutoScaling.RefreshStrategy Strategy { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version number, <code>$Latest</code>, or <code>$Default</code>. To get the version
        /// number, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeLaunchTemplateVersions.html">DescribeLaunchTemplateVersions</a>
        /// API operation. New launch template versions can be created using the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateLaunchTemplateVersion.html">CreateLaunchTemplateVersion</a>
        /// API. If the value is <code>$Latest</code>, Amazon EC2 Auto Scaling selects the latest
        /// version of the launch template when launching instances. If the value is <code>$Default</code>,
        /// Amazon EC2 Auto Scaling selects the default version of the launch template when launching
        /// instances. The default value is <code>$Default</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredConfiguration_LaunchTemplate_Version")]
        public System.String LaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceRefreshId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.StartInstanceRefreshResponse).
        /// Specifying the name of a property of type Amazon.AutoScaling.Model.StartInstanceRefreshResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceRefreshId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutoScalingGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ASInstanceRefresh (StartInstanceRefresh)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.StartInstanceRefreshResponse, StartASInstanceRefreshCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutoScalingGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LaunchTemplate_LaunchTemplateId = this.LaunchTemplate_LaunchTemplateId;
            context.LaunchTemplate_LaunchTemplateName = this.LaunchTemplate_LaunchTemplateName;
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            context.DesiredConfiguration_MixedInstancesPolicy = this.DesiredConfiguration_MixedInstancesPolicy;
            context.Preferences_CheckpointDelay = this.Preferences_CheckpointDelay;
            if (this.Preferences_CheckpointPercentage != null)
            {
                context.Preferences_CheckpointPercentage = new List<System.Int32>(this.Preferences_CheckpointPercentage);
            }
            context.Preferences_InstanceWarmup = this.Preferences_InstanceWarmup;
            context.Preferences_MinHealthyPercentage = this.Preferences_MinHealthyPercentage;
            context.Preferences_SkipMatching = this.Preferences_SkipMatching;
            context.Strategy = this.Strategy;
            
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
            var request = new Amazon.AutoScaling.Model.StartInstanceRefreshRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            
             // populate DesiredConfiguration
            var requestDesiredConfigurationIsNull = true;
            request.DesiredConfiguration = new Amazon.AutoScaling.Model.DesiredConfiguration();
            Amazon.AutoScaling.Model.MixedInstancesPolicy requestDesiredConfiguration_desiredConfiguration_MixedInstancesPolicy = null;
            if (cmdletContext.DesiredConfiguration_MixedInstancesPolicy != null)
            {
                requestDesiredConfiguration_desiredConfiguration_MixedInstancesPolicy = cmdletContext.DesiredConfiguration_MixedInstancesPolicy;
            }
            if (requestDesiredConfiguration_desiredConfiguration_MixedInstancesPolicy != null)
            {
                request.DesiredConfiguration.MixedInstancesPolicy = requestDesiredConfiguration_desiredConfiguration_MixedInstancesPolicy;
                requestDesiredConfigurationIsNull = false;
            }
            Amazon.AutoScaling.Model.LaunchTemplateSpecification requestDesiredConfiguration_desiredConfiguration_LaunchTemplate = null;
            
             // populate LaunchTemplate
            var requestDesiredConfiguration_desiredConfiguration_LaunchTemplateIsNull = true;
            requestDesiredConfiguration_desiredConfiguration_LaunchTemplate = new Amazon.AutoScaling.Model.LaunchTemplateSpecification();
            System.String requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateId = null;
            if (cmdletContext.LaunchTemplate_LaunchTemplateId != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateId = cmdletContext.LaunchTemplate_LaunchTemplateId;
            }
            if (requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateId != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate.LaunchTemplateId = requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateId;
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplateIsNull = false;
            }
            System.String requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateName = null;
            if (cmdletContext.LaunchTemplate_LaunchTemplateName != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateName = cmdletContext.LaunchTemplate_LaunchTemplateName;
            }
            if (requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateName != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate.LaunchTemplateName = requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_LaunchTemplateName;
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplateIsNull = false;
            }
            System.String requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_Version = null;
            if (cmdletContext.LaunchTemplate_Version != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_Version = cmdletContext.LaunchTemplate_Version;
            }
            if (requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_Version != null)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate.Version = requestDesiredConfiguration_desiredConfiguration_LaunchTemplate_launchTemplate_Version;
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplateIsNull = false;
            }
             // determine if requestDesiredConfiguration_desiredConfiguration_LaunchTemplate should be set to null
            if (requestDesiredConfiguration_desiredConfiguration_LaunchTemplateIsNull)
            {
                requestDesiredConfiguration_desiredConfiguration_LaunchTemplate = null;
            }
            if (requestDesiredConfiguration_desiredConfiguration_LaunchTemplate != null)
            {
                request.DesiredConfiguration.LaunchTemplate = requestDesiredConfiguration_desiredConfiguration_LaunchTemplate;
                requestDesiredConfigurationIsNull = false;
            }
             // determine if request.DesiredConfiguration should be set to null
            if (requestDesiredConfigurationIsNull)
            {
                request.DesiredConfiguration = null;
            }
            
             // populate Preferences
            var requestPreferencesIsNull = true;
            request.Preferences = new Amazon.AutoScaling.Model.RefreshPreferences();
            System.Int32? requestPreferences_preferences_CheckpointDelay = null;
            if (cmdletContext.Preferences_CheckpointDelay != null)
            {
                requestPreferences_preferences_CheckpointDelay = cmdletContext.Preferences_CheckpointDelay.Value;
            }
            if (requestPreferences_preferences_CheckpointDelay != null)
            {
                request.Preferences.CheckpointDelay = requestPreferences_preferences_CheckpointDelay.Value;
                requestPreferencesIsNull = false;
            }
            List<System.Int32> requestPreferences_preferences_CheckpointPercentage = null;
            if (cmdletContext.Preferences_CheckpointPercentage != null)
            {
                requestPreferences_preferences_CheckpointPercentage = cmdletContext.Preferences_CheckpointPercentage;
            }
            if (requestPreferences_preferences_CheckpointPercentage != null)
            {
                request.Preferences.CheckpointPercentages = requestPreferences_preferences_CheckpointPercentage;
                requestPreferencesIsNull = false;
            }
            System.Int32? requestPreferences_preferences_InstanceWarmup = null;
            if (cmdletContext.Preferences_InstanceWarmup != null)
            {
                requestPreferences_preferences_InstanceWarmup = cmdletContext.Preferences_InstanceWarmup.Value;
            }
            if (requestPreferences_preferences_InstanceWarmup != null)
            {
                request.Preferences.InstanceWarmup = requestPreferences_preferences_InstanceWarmup.Value;
                requestPreferencesIsNull = false;
            }
            System.Int32? requestPreferences_preferences_MinHealthyPercentage = null;
            if (cmdletContext.Preferences_MinHealthyPercentage != null)
            {
                requestPreferences_preferences_MinHealthyPercentage = cmdletContext.Preferences_MinHealthyPercentage.Value;
            }
            if (requestPreferences_preferences_MinHealthyPercentage != null)
            {
                request.Preferences.MinHealthyPercentage = requestPreferences_preferences_MinHealthyPercentage.Value;
                requestPreferencesIsNull = false;
            }
            System.Boolean? requestPreferences_preferences_SkipMatching = null;
            if (cmdletContext.Preferences_SkipMatching != null)
            {
                requestPreferences_preferences_SkipMatching = cmdletContext.Preferences_SkipMatching.Value;
            }
            if (requestPreferences_preferences_SkipMatching != null)
            {
                request.Preferences.SkipMatching = requestPreferences_preferences_SkipMatching.Value;
                requestPreferencesIsNull = false;
            }
             // determine if request.Preferences should be set to null
            if (requestPreferencesIsNull)
            {
                request.Preferences = null;
            }
            if (cmdletContext.Strategy != null)
            {
                request.Strategy = cmdletContext.Strategy;
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
        
        private Amazon.AutoScaling.Model.StartInstanceRefreshResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.StartInstanceRefreshRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "StartInstanceRefresh");
            try
            {
                #if DESKTOP
                return client.StartInstanceRefresh(request);
                #elif CORECLR
                return client.StartInstanceRefreshAsync(request).GetAwaiter().GetResult();
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
            public System.String AutoScalingGroupName { get; set; }
            public System.String LaunchTemplate_LaunchTemplateId { get; set; }
            public System.String LaunchTemplate_LaunchTemplateName { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public Amazon.AutoScaling.Model.MixedInstancesPolicy DesiredConfiguration_MixedInstancesPolicy { get; set; }
            public System.Int32? Preferences_CheckpointDelay { get; set; }
            public List<System.Int32> Preferences_CheckpointPercentage { get; set; }
            public System.Int32? Preferences_InstanceWarmup { get; set; }
            public System.Int32? Preferences_MinHealthyPercentage { get; set; }
            public System.Boolean? Preferences_SkipMatching { get; set; }
            public Amazon.AutoScaling.RefreshStrategy Strategy { get; set; }
            public System.Func<Amazon.AutoScaling.Model.StartInstanceRefreshResponse, StartASInstanceRefreshCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceRefreshId;
        }
        
    }
}
