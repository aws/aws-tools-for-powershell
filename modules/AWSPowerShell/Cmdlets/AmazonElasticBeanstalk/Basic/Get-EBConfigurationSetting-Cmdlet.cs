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
    /// Returns a description of the settings for the specified configuration set, that is,
    /// either a configuration template or the configuration set associated with a running
    /// environment. 
    /// 
    ///  
    /// <para>
    ///  When describing the settings for the configuration set associated with a running
    /// environment, it is possible to receive two sets of setting descriptions. One is the
    /// deployed configuration set, and the other is a draft configuration of an environment
    /// that is either in the process of deployment or that failed to deploy. 
    /// </para><para>
    /// Related Topics
    /// </para><ul><li><a>DeleteEnvironmentConfiguration</a></li></ul>
    /// </summary>
    [Cmdlet("Get", "EBConfigurationSetting")]
    [OutputType("Amazon.ElasticBeanstalk.Model.ConfigurationSettingsDescription")]
    [AWSCmdlet("Invokes the DescribeConfigurationSettings operation against AWS Elastic Beanstalk.", Operation = new[] {"DescribeConfigurationSettings"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.ConfigurationSettingsDescription",
        "This cmdlet returns a collection of ConfigurationSettingsDescription objects.",
        "The service call response (type DescribeConfigurationSettingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEBConfigurationSettingCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The application for the environment or configuration template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ApplicationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the environment to describe. </para><para> Condition: You must specify either this or a TemplateName, but not both. If you specify
        /// both, AWS Elastic Beanstalk returns an <code>InvalidParameterCombination</code> error.
        /// If you do not specify either, AWS Elastic Beanstalk returns <code>MissingRequiredParameter</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String EnvironmentName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the configuration template to describe. </para><para> Conditional: You must specify either this parameter or an EnvironmentName, but not
        /// both. If you specify both, AWS Elastic Beanstalk returns an <code>InvalidParameterCombination</code>
        /// error. If you do not specify either, AWS Elastic Beanstalk returns a <code>MissingRequiredParameter</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String TemplateName { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ApplicationName = this.ApplicationName;
            context.EnvironmentName = this.EnvironmentName;
            context.TemplateName = this.TemplateName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeConfigurationSettingsRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
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
                var response = client.DescribeConfigurationSettings(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ConfigurationSettings;
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
            public String EnvironmentName { get; set; }
            public String TemplateName { get; set; }
        }
        
    }
}
