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
    /// Creates a new deployment group for application revisions to be deployed to.
    /// </summary>
    [Cmdlet("New", "CDDeploymentGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateDeploymentGroup operation against AWS CodeDeploy.", Operation = new[] {"CreateDeploymentGroup"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CodeDeploy.Model.CreateDeploymentGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewCDDeploymentGroupCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of an existing AWS CodeDeploy application associated with the applicable
        /// IAM user or AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroup
        /// <summary>
        /// <para>
        /// <para>A list of associated Auto Scaling groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoScalingGroups")]
        public System.String[] AutoScalingGroup { get; set; }
        #endregion
        
        #region Parameter DeploymentConfigName
        /// <summary>
        /// <para>
        /// <para>If specified, the deployment configuration name can be either one of the predefined
        /// configurations provided with AWS CodeDeploy, or a custom deployment configuration
        /// that you created by calling the create deployment configuration operation.</para><note><para>CodeDeployDefault.OneAtATime is the default deployment configuration that is used
        /// if a configuration isn't specified for either the deployment or the deployment group.</para></note><para>The predefined deployment configurations including the following:</para><ul><li><para><b>CodeDeployDefault.AllAtOnce</b> attempts to deploy an application revision to as
        /// many instances as possible at once. The status of the overall deployment will be displayed
        /// as <b>Succeeded</b> if the application revision is deployed to one or more of the
        /// instances. The status of the overall deployment will be displayed as <b>Failed</b>
        /// if the application revision is not deployed to any of the instances. Using an example
        /// of nine instances, CodeDeployDefault.AllAtOnce will attempt to deploy to all nine
        /// instances at once. The overall deployment will succeed if deployment to even a single
        /// instance is successful; it will fail only if deployments to all nine instances fail.
        /// </para></li><li><para><b>CodeDeployDefault.HalfAtATime</b> deploys to up to half of the instances at a time
        /// (with fractions rounded down). The overall deployment succeeds if the application
        /// revision deploys to at least half of the instances (with fractions rounded up); otherwise,
        /// the deployment fails. For example, for nine instances, deploy to up to four instances
        /// at a time. The overall deployment succeeds if deployment to five or more instances
        /// succeed; otherwise, the deployment fails. Note that the deployment may successfully
        /// deploy to some instances, even if the overall deployment fails.</para></li><li><para><b>CodeDeployDefault.OneAtATime</b> deploys the application revision to only one instance
        /// at a time.</para><para>For deployment groups that contain more than one instance:</para><ul><li><para>The overall deployment succeeds if the application revision deploys to all of the
        /// instances. The exception to this rule is that if deployment to the last instance fails,
        /// the overall deployment still succeeds. This is because AWS CodeDeploy allows only
        /// one instance to be taken offline at a time with the CodeDeployDefault.OneAtATime configuration.</para></li><li><para>The overall deployment fails as soon as the application revision fails to deploy to
        /// any but the last instance. Note that the deployment may successfully deploy to some
        /// instances, even if the overall deployment fails.</para></li><li><para>Example: For nine instances, deploy to one instance at a time. The overall deployment
        /// succeeds if the first eight instances are successfully deployed to, but it fails if
        /// deployment to any of the first eight instances fails.</para></li></ul><para>For deployment groups that contain only one instance, the overall deployment is of
        /// course successful only if deployment to the single instance succeeds.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeploymentConfigName { get; set; }
        #endregion
        
        #region Parameter DeploymentGroupName
        /// <summary>
        /// <para>
        /// <para>The name of a new deployment group for the specified application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeploymentGroupName { get; set; }
        #endregion
        
        #region Parameter Ec2TagFilter
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 tags to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Ec2TagFilters")]
        public Amazon.CodeDeploy.Model.EC2TagFilter[] Ec2TagFilter { get; set; }
        #endregion
        
        #region Parameter OnPremisesInstanceTagFilter
        /// <summary>
        /// <para>
        /// <para>The on-premises instance tags to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OnPremisesInstanceTagFilters")]
        public Amazon.CodeDeploy.Model.TagFilter[] OnPremisesInstanceTagFilter { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>A service role ARN that allows AWS CodeDeploy to act on the user's behalf when interacting
        /// with AWS services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter TriggerConfiguration
        /// <summary>
        /// <para>
        /// <para>Information about triggers to create when the deployment group is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TriggerConfigurations")]
        public Amazon.CodeDeploy.Model.TriggerConfig[] TriggerConfiguration { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CDDeploymentGroup (CreateDeploymentGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ApplicationName = this.ApplicationName;
            if (this.AutoScalingGroup != null)
            {
                context.AutoScalingGroups = new List<System.String>(this.AutoScalingGroup);
            }
            context.DeploymentConfigName = this.DeploymentConfigName;
            context.DeploymentGroupName = this.DeploymentGroupName;
            if (this.Ec2TagFilter != null)
            {
                context.Ec2TagFilters = new List<Amazon.CodeDeploy.Model.EC2TagFilter>(this.Ec2TagFilter);
            }
            if (this.OnPremisesInstanceTagFilter != null)
            {
                context.OnPremisesInstanceTagFilters = new List<Amazon.CodeDeploy.Model.TagFilter>(this.OnPremisesInstanceTagFilter);
            }
            context.ServiceRoleArn = this.ServiceRoleArn;
            if (this.TriggerConfiguration != null)
            {
                context.TriggerConfigurations = new List<Amazon.CodeDeploy.Model.TriggerConfig>(this.TriggerConfiguration);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodeDeploy.Model.CreateDeploymentGroupRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.AutoScalingGroups != null)
            {
                request.AutoScalingGroups = cmdletContext.AutoScalingGroups;
            }
            if (cmdletContext.DeploymentConfigName != null)
            {
                request.DeploymentConfigName = cmdletContext.DeploymentConfigName;
            }
            if (cmdletContext.DeploymentGroupName != null)
            {
                request.DeploymentGroupName = cmdletContext.DeploymentGroupName;
            }
            if (cmdletContext.Ec2TagFilters != null)
            {
                request.Ec2TagFilters = cmdletContext.Ec2TagFilters;
            }
            if (cmdletContext.OnPremisesInstanceTagFilters != null)
            {
                request.OnPremisesInstanceTagFilters = cmdletContext.OnPremisesInstanceTagFilters;
            }
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.TriggerConfigurations != null)
            {
                request.TriggerConfigurations = cmdletContext.TriggerConfigurations;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateDeploymentGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DeploymentGroupId;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ApplicationName { get; set; }
            public List<System.String> AutoScalingGroups { get; set; }
            public System.String DeploymentConfigName { get; set; }
            public System.String DeploymentGroupName { get; set; }
            public List<Amazon.CodeDeploy.Model.EC2TagFilter> Ec2TagFilters { get; set; }
            public List<Amazon.CodeDeploy.Model.TagFilter> OnPremisesInstanceTagFilters { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public List<Amazon.CodeDeploy.Model.TriggerConfig> TriggerConfigurations { get; set; }
        }
        
    }
}
