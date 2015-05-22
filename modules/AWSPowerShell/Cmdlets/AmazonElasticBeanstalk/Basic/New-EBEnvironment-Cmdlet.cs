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
    /// Launches an environment for the specified application using the specified configuration.
    /// </summary>
    [Cmdlet("New", "EBEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse")]
    [AWSCmdlet("Invokes the CreateEnvironment operation against AWS Elastic Beanstalk.", Operation = new[] {"CreateEnvironment"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.CreateEnvironmentResponse",
        "This cmdlet returns a CreateEnvironmentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEBEnvironmentCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The name of the application that contains the version to be deployed. </para><para> If no application is found with this name, <code>CreateEnvironment</code> returns
        /// an <code>InvalidParameterValue</code> error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ApplicationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, the environment attempts to use this value as the prefix for the CNAME.
        /// If not specified, the CNAME is generated automatically by appending a random alphanumeric
        /// string to the environment name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CNAMEPrefix { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Describes this environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A unique name for the deployment environment. Used in the application URL. </para><para>Constraint: Must be from 4 to 23 characters in length. The name can contain only letters,
        /// numbers, and hyphens. It cannot start or end with a hyphen. This name must be unique
        /// in your account. If the specified name already exists, AWS Elastic Beanstalk returns
        /// an <code>InvalidParameterValue</code> error. </para><para>Default: If the CNAME parameter is not specified, the environment name becomes part
        /// of the CNAME, and therefore part of the visible URL for your application.</para>
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
        /// <para> If specified, AWS Elastic Beanstalk sets the specified configuration options to the
        /// requested value in the configuration set for the new environment. These override the
        /// values obtained from the solution stack or the configuration template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OptionSettings")]
        public Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting[] OptionSetting { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A list of custom user-defined configuration options to remove from the configuration
        /// set for this new environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ElasticBeanstalk.Model.OptionSpecification[] OptionsToRemove { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> This specifies the tags applied to resources in the environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ElasticBeanstalk.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the configuration template to use in deployment. If no configuration
        /// template is found with this name, AWS Elastic Beanstalk returns an <code>InvalidParameterValue</code>
        /// error. </para><para> Condition: You must specify either this parameter or a <code>SolutionStackName</code>,
        /// but not both. If you specify both, AWS Elastic Beanstalk returns an <code>InvalidParameterCombination</code>
        /// error. If you do not specify either, AWS Elastic Beanstalk returns a <code>MissingRequiredParameter</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// <para>The name of the application version to deploy.</para><para> If the specified application has no associated application versions, AWS Elastic
        /// Beanstalk <code>UpdateEnvironment</code> returns an <code>InvalidParameterValue</code>
        /// error. </para><para> Default: If not specified, AWS Elastic Beanstalk attempts to launch the sample application
        /// in the container. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String VersionLabel { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> This is an alternative to specifying a configuration name. If specified, AWS Elastic
        /// Beanstalk sets the configuration values to the default values associated with the
        /// specified solution stack. </para><para> Condition: You must specify either this or a <code>TemplateName</code>, but not both.
        /// If you specify both, AWS Elastic Beanstalk returns an <code>InvalidParameterCombination</code>
        /// error. If you do not specify either, AWS Elastic Beanstalk returns a <code>MissingRequiredParameter</code>
        /// error. </para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EBEnvironment (CreateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ApplicationName = this.ApplicationName;
            context.CNAMEPrefix = this.CNAMEPrefix;
            context.Description = this.Description;
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
            if (this.Tag != null)
            {
                context.Tags = new List<Tag>(this.Tag);
            }
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
            var request = new CreateEnvironmentRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.CNAMEPrefix != null)
            {
                request.CNAMEPrefix = cmdletContext.CNAMEPrefix;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
                var response = client.CreateEnvironment(request);
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
            public String ApplicationName { get; set; }
            public String CNAMEPrefix { get; set; }
            public String Description { get; set; }
            public String EnvironmentName { get; set; }
            public List<ConfigurationOptionSetting> OptionSettings { get; set; }
            public List<OptionSpecification> OptionsToRemove { get; set; }
            public String SolutionStackName { get; set; }
            public List<Tag> Tags { get; set; }
            public String TemplateName { get; set; }
            public String Tier_Name { get; set; }
            public String Tier_Type { get; set; }
            public String Tier_Version { get; set; }
            public String VersionLabel { get; set; }
        }
        
    }
}
