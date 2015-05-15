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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Updates the environment description, deploys a new application version, updates the
    /// configuration settings to an entirely new configuration template, or updates select
    /// configuration option values in the running environment. 
    /// 
    ///  
    /// <para>
    ///  Attempting to update both the release and configuration is not allowed and AWS Elastic
    /// Beanstalk returns an <code>InvalidParameterCombination</code> error. 
    /// </para><para>
    ///  When updating the configuration settings to a new template or individual settings,
    /// a draft configuration is created and <a>DescribeConfigurationSettings</a> for this
    /// environment returns two setting descriptions with different <code>DeploymentStatus</code>
    /// values. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EBEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResult")]
    [AWSCmdlet("Invokes the UpdateEnvironment operation against AWS Elastic Beanstalk.", Operation = new[] {"UpdateEnvironment"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.UpdateEnvironmentResult",
        "This cmdlet returns a UpdateEnvironmentResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateEBEnvironmentCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> If this parameter is specified, AWS Elastic Beanstalk updates the description of
        /// this environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the environment to update.</para><para> If no environment with this ID exists, AWS Elastic Beanstalk returns an <code>InvalidParameterValue</code>
        /// error. </para><para> Condition: You must specify either this or an EnvironmentName, or both. If you do
        /// not specify either, AWS Elastic Beanstalk returns <code>MissingRequiredParameter</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String EnvironmentId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the environment to update. If no environment with this name exists, AWS
        /// Elastic Beanstalk returns an <code>InvalidParameterValue</code> error. </para><para> Condition: You must specify either this or an EnvironmentId, or both. If you do not
        /// specify either, AWS Elastic Beanstalk returns <code>MissingRequiredParameter</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String EnvironmentName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of this environment tier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Tier_Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk updates the configuration set associated with
        /// the running environment and sets the specified configuration options to the requested
        /// value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OptionSettings")]
        public Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting[] OptionSetting { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A list of custom user-defined configuration options to remove from the configuration
        /// set for this environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ElasticBeanstalk.Model.OptionSpecification[] OptionsToRemove { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If this parameter is specified, AWS Elastic Beanstalk deploys this configuration
        /// template to the environment. If no such configuration template is found, AWS Elastic
        /// Beanstalk returns an <code>InvalidParameterValue</code> error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public String TemplateName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The type of this environment tier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Tier_Type { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The version of this environment tier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Tier_Version { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If this parameter is specified, AWS Elastic Beanstalk deploys the named application
        /// version to the environment. If no such application version is found, returns an <code>InvalidParameterValue</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public String VersionLabel { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> This specifies the platform version that the environment will run after the environment
        /// is updated. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String SolutionStackName { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EnvironmentId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EBEnvironment (UpdateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Description = this.Description;
            context.EnvironmentId = this.EnvironmentId;
            context.EnvironmentName = this.EnvironmentName;
            if (this.OptionSetting != null)
            {
                context.OptionSettings = new List<ConfigurationOptionSetting>(this.OptionSetting);
            }
            if (this.OptionsToRemove != null)
            {
                context.OptionsToRemove = new List<OptionSpecification>(this.OptionsToRemove);
            }
            context.SolutionStackName = this.SolutionStackName;
            context.TemplateName = this.TemplateName;
            context.Tier_Name = this.Tier_Name;
            context.Tier_Type = this.Tier_Type;
            context.Tier_Version = this.Tier_Version;
            context.VersionLabel = this.VersionLabel;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateEnvironmentRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.OptionSettings != null)
            {
                request.OptionSettings = cmdletContext.OptionSettings;
            }
            if (cmdletContext.OptionsToRemove != null)
            {
                request.OptionsToRemove = cmdletContext.OptionsToRemove;
            }
            if (cmdletContext.SolutionStackName != null)
            {
                request.SolutionStackName = cmdletContext.SolutionStackName;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
            }
            
             // populate Tier
            bool requestTierIsNull = true;
            request.Tier = new EnvironmentTier();
            String requestTier_tier_Name = null;
            if (cmdletContext.Tier_Name != null)
            {
                requestTier_tier_Name = cmdletContext.Tier_Name;
            }
            if (requestTier_tier_Name != null)
            {
                request.Tier.Name = requestTier_tier_Name;
                requestTierIsNull = false;
            }
            String requestTier_tier_Type = null;
            if (cmdletContext.Tier_Type != null)
            {
                requestTier_tier_Type = cmdletContext.Tier_Type;
            }
            if (requestTier_tier_Type != null)
            {
                request.Tier.Type = requestTier_tier_Type;
                requestTierIsNull = false;
            }
            String requestTier_tier_Version = null;
            if (cmdletContext.Tier_Version != null)
            {
                requestTier_tier_Version = cmdletContext.Tier_Version;
            }
            if (requestTier_tier_Version != null)
            {
                request.Tier.Version = requestTier_tier_Version;
                requestTierIsNull = false;
            }
             // determine if request.Tier should be set to null
            if (requestTierIsNull)
            {
                request.Tier = null;
            }
            if (cmdletContext.VersionLabel != null)
            {
                request.VersionLabel = cmdletContext.VersionLabel;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateEnvironment(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String Description { get; set; }
            public String EnvironmentId { get; set; }
            public String EnvironmentName { get; set; }
            public List<ConfigurationOptionSetting> OptionSettings { get; set; }
            public List<OptionSpecification> OptionsToRemove { get; set; }
            public String SolutionStackName { get; set; }
            public String TemplateName { get; set; }
            public String Tier_Name { get; set; }
            public String Tier_Type { get; set; }
            public String Tier_Version { get; set; }
            public String VersionLabel { get; set; }
        }
        
    }
}
