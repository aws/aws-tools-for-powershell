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
        "The service call response (type CreateDeploymentGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewCDDeploymentGroupCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of an existing AWS CodeDeploy application associated with the applicable
        /// IAM user or AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String ApplicationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of associated Auto Scaling groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoScalingGroups")]
        public System.String[] AutoScalingGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>If specified, the deployment configuration name must be one of the predefined values,
        /// or it can be a custom deployment configuration:</para><ul><li>CodeDeployDefault.AllAtOnce deploys an application revision to up to all
        /// of the instances at once. The overall deployment succeeds if the application revision
        /// deploys to at least one of the instances. The overall deployment fails after the application
        /// revision fails to deploy to all of the instances. For example, for 9 instances, deploy
        /// to up to all 9 instances at once. The overall deployment succeeds if any of the 9
        /// instances is successfully deployed to, and it fails if all 9 instances fail to be
        /// deployed to.</li><li>CodeDeployDefault.HalfAtATime deploys to up to half of the instances
        /// at a time (with fractions rounded down). The overall deployment succeeds if the application
        /// revision deploys to at least half of the instances (with fractions rounded up); otherwise,
        /// the deployment fails. For example, for 9 instances, deploy to up to 4 instances at
        /// a time. The overall deployment succeeds if 5 or more instances are successfully deployed
        /// to; otherwise, the deployment fails. Note that the deployment may successfully deploy
        /// to some instances, even if the overall deployment fails.</li><li>CodeDeployDefault.OneAtATime
        /// deploys the application revision to only one of the instances at a time. The overall
        /// deployment succeeds if the application revision deploys to all of the instances. The
        /// overall deployment fails after the application revision first fails to deploy to any
        /// one instances. For example, for 9 instances, deploy to one instance at a time. The
        /// overall deployment succeeds if all 9 instances are successfully deployed to, and it
        /// fails if any of one of the 9 instances fail to be deployed to. Note that the deployment
        /// may successfully deploy to some instances, even if the overall deployment fails. This
        /// is the default deployment configuration if a configuration isn't specified for either
        /// the deployment or the deployment group.</li></ul><para>To create a custom deployment configuration, call the create deployment configuration
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeploymentConfigName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of an existing deployment group for the specified application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeploymentGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 tags to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Ec2TagFilters")]
        public Amazon.CodeDeploy.Model.EC2TagFilter[] Ec2TagFilter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The on-premises instance tags to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OnPremisesInstanceTagFilters")]
        public Amazon.CodeDeploy.Model.TagFilter[] OnPremisesInstanceTagFilter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A service role ARN that allows AWS CodeDeploy to act on the user's behalf when interacting
        /// with AWS services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ServiceRoleArn { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
                context.AutoScalingGroups = new List<String>(this.AutoScalingGroup);
            }
            context.DeploymentConfigName = this.DeploymentConfigName;
            context.DeploymentGroupName = this.DeploymentGroupName;
            if (this.Ec2TagFilter != null)
            {
                context.Ec2TagFilters = new List<EC2TagFilter>(this.Ec2TagFilter);
            }
            if (this.OnPremisesInstanceTagFilter != null)
            {
                context.OnPremisesInstanceTagFilters = new List<TagFilter>(this.OnPremisesInstanceTagFilter);
            }
            context.ServiceRoleArn = this.ServiceRoleArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateDeploymentGroupRequest();
            
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
            public String ApplicationName { get; set; }
            public List<String> AutoScalingGroups { get; set; }
            public String DeploymentConfigName { get; set; }
            public String DeploymentGroupName { get; set; }
            public List<EC2TagFilter> Ec2TagFilters { get; set; }
            public List<TagFilter> OnPremisesInstanceTagFilters { get; set; }
            public String ServiceRoleArn { get; set; }
        }
        
    }
}
