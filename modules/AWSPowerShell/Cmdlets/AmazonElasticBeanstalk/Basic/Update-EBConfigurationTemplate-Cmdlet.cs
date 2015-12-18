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
    /// Updates the specified configuration template to have the specified properties or
    /// configuration option values. 
    /// 
    ///  <note> If a property (for example, <code>ApplicationName</code>) is not provided,
    /// its value remains unchanged. To clear such properties, specify an empty string. </note><para>
    /// Related Topics
    /// </para><ul><li><a>DescribeConfigurationOptions</a></li></ul>
    /// </summary>
    [Cmdlet("Update", "EBConfigurationTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.UpdateConfigurationTemplateResponse")]
    [AWSCmdlet("Invokes the UpdateConfigurationTemplate operation against AWS Elastic Beanstalk.", Operation = new[] {"UpdateConfigurationTemplate"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.UpdateConfigurationTemplateResponse",
        "This cmdlet returns a Amazon.ElasticBeanstalk.Model.UpdateConfigurationTemplateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateEBConfigurationTemplateCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>The name of the application associated with the configuration template to update.</para><para> If no application is found with this name, <code>UpdateConfigurationTemplate</code>
        /// returns an <code>InvalidParameterValue</code> error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OptionSetting
        /// <summary>
        /// <para>
        /// <para> A list of configuration option settings to update with the new specified option value.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("OptionSettings")]
        public Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting[] OptionSetting { get; set; }
        #endregion
        
        #region Parameter OptionsToRemove
        /// <summary>
        /// <para>
        /// <para> A list of configuration options to remove from the configuration set. </para><para> Constraint: You can remove only <code>UserDefined</code> configuration options. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public Amazon.ElasticBeanstalk.Model.OptionSpecification[] OptionsToRemove { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration template to update.</para><para> If no configuration template is found with this name, <code>UpdateConfigurationTemplate</code>
        /// returns an <code>InvalidParameterValue</code> error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String TemplateName { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EBConfigurationTemplate (UpdateConfigurationTemplate)"))
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
            if (this.OptionSetting != null)
            {
                context.OptionSettings = new List<Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting>(this.OptionSetting);
            }
            if (this.OptionsToRemove != null)
            {
                context.OptionsToRemove = new List<Amazon.ElasticBeanstalk.Model.OptionSpecification>(this.OptionsToRemove);
            }
            context.TemplateName = this.TemplateName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticBeanstalk.Model.UpdateConfigurationTemplateRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.OptionSettings != null)
            {
                request.OptionSettings = cmdletContext.OptionSettings;
            }
            if (cmdletContext.OptionsToRemove != null)
            {
                request.OptionsToRemove = cmdletContext.OptionsToRemove;
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
                var response = client.UpdateConfigurationTemplate(request);
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
            public System.String ApplicationName { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.ConfigurationOptionSetting> OptionSettings { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.OptionSpecification> OptionsToRemove { get; set; }
            public System.String TemplateName { get; set; }
        }
        
    }
}
