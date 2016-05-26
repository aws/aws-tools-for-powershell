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
    /// Creates a configuration template. Templates are associated with a specific application
    /// and are used to deploy different versions of the application with the same configuration
    /// settings.
    /// 
    ///  
    /// <para>
    /// Related Topics
    /// </para><ul><li><a>DescribeConfigurationOptions</a></li><li><a>DescribeConfigurationSettings</a></li><li><a>ListAvailableSolutionStacks</a></li></ul>
    /// </summary>
    [Cmdlet("New", "EBConfigurationTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.CreateConfigurationTemplateResponse")]
    [AWSCmdlet("Invokes the CreateConfigurationTemplate operation against AWS Elastic Beanstalk.", Operation = new[] {"CreateConfigurationTemplate"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.CreateConfigurationTemplateResponse",
        "This cmdlet returns a Amazon.ElasticBeanstalk.Model.CreateConfigurationTemplateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEBConfigurationTemplateCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application to associate with this configuration template. If no application
        /// is found with this name, AWS Elastic Beanstalk returns an <code>InvalidParameterValue</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application associated with the configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceConfiguration_ApplicationName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Describes this configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the environment used with this configuration template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter OptionSetting
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk sets the specified configuration option to the
        /// requested value. The new value overrides the value obtained from the solution stack
        /// or the source configuration template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OptionSettings")]
        public Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting[] OptionSetting { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceConfiguration_TemplateName { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration template.</para><para>Constraint: This name must be unique per application. </para><para>Default: If a configuration template already exists with this name, AWS Elastic Beanstalk
        /// returns an <code>InvalidParameterValue</code> error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter SolutionStackName
        /// <summary>
        /// <para>
        /// <para>The name of the solution stack used by this configuration. The solution stack specifies
        /// the operating system, architecture, and application server for a configuration template.
        /// It determines the set of configuration options as well as the possible and default
        /// values. </para><para> Use <a>ListAvailableSolutionStacks</a> to obtain a list of available solution stacks.
        /// </para><para> A solution stack name or a source configuration parameter must be specified, otherwise
        /// AWS Elastic Beanstalk returns an <code>InvalidParameterValue</code> error. </para><para> If a solution stack name is not specified and the source configuration parameter
        /// is specified, AWS Elastic Beanstalk uses the same solution stack as the source configuration
        /// template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String SolutionStackName { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EBConfigurationTemplate (CreateConfigurationTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ApplicationName = this.ApplicationName;
            context.Description = this.Description;
            context.EnvironmentId = this.EnvironmentId;
            if (this.OptionSetting != null)
            {
                context.OptionSettings = new List<Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting>(this.OptionSetting);
            }
            context.SolutionStackName = this.SolutionStackName;
            context.SourceConfiguration_ApplicationName = this.SourceConfiguration_ApplicationName;
            context.SourceConfiguration_TemplateName = this.SourceConfiguration_TemplateName;
            context.TemplateName = this.TemplateName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticBeanstalk.Model.CreateConfigurationTemplateRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.OptionSettings != null)
            {
                request.OptionSettings = cmdletContext.OptionSettings;
            }
            if (cmdletContext.SolutionStackName != null)
            {
                request.SolutionStackName = cmdletContext.SolutionStackName;
            }
            
             // populate SourceConfiguration
            bool requestSourceConfigurationIsNull = true;
            request.SourceConfiguration = new Amazon.ElasticBeanstalk.Model.SourceConfiguration();
            System.String requestSourceConfiguration_sourceConfiguration_ApplicationName = null;
            if (cmdletContext.SourceConfiguration_ApplicationName != null)
            {
                requestSourceConfiguration_sourceConfiguration_ApplicationName = cmdletContext.SourceConfiguration_ApplicationName;
            }
            if (requestSourceConfiguration_sourceConfiguration_ApplicationName != null)
            {
                request.SourceConfiguration.ApplicationName = requestSourceConfiguration_sourceConfiguration_ApplicationName;
                requestSourceConfigurationIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_TemplateName = null;
            if (cmdletContext.SourceConfiguration_TemplateName != null)
            {
                requestSourceConfiguration_sourceConfiguration_TemplateName = cmdletContext.SourceConfiguration_TemplateName;
            }
            if (requestSourceConfiguration_sourceConfiguration_TemplateName != null)
            {
                request.SourceConfiguration.TemplateName = requestSourceConfiguration_sourceConfiguration_TemplateName;
                requestSourceConfigurationIsNull = false;
            }
             // determine if request.SourceConfiguration should be set to null
            if (requestSourceConfigurationIsNull)
            {
                request.SourceConfiguration = null;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
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
        
        private static Amazon.ElasticBeanstalk.Model.CreateConfigurationTemplateResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.CreateConfigurationTemplateRequest request)
        {
            return client.CreateConfigurationTemplate(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ApplicationName { get; set; }
            public System.String Description { get; set; }
            public System.String EnvironmentId { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting> OptionSettings { get; set; }
            public System.String SolutionStackName { get; set; }
            public System.String SourceConfiguration_ApplicationName { get; set; }
            public System.String SourceConfiguration_TemplateName { get; set; }
            public System.String TemplateName { get; set; }
        }
        
    }
}
