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
    /// Describes the configuration options that are used in a particular configuration template
    /// or environment, or that a specified solution stack defines. The description includes
    /// the values the options, their default values, and an indication of the required action
    /// on a running environment if an option value is changed.
    /// </summary>
    [Cmdlet("Get", "EBConfigurationOption")]
    [OutputType("Amazon.ElasticBeanstalk.Model.ConfigurationOptionDescription")]
    [AWSCmdlet("Invokes the DescribeConfigurationOptions operation against AWS Elastic Beanstalk.", Operation = new[] {"DescribeConfigurationOptions"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.ConfigurationOptionDescription",
        "This cmdlet returns a collection of ConfigurationOptionDescription objects.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.DescribeConfigurationOptionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: SolutionStackName (type System.String)"
    )]
    public class GetEBConfigurationOptionCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The name of the application associated with the configuration template or environment.
        /// Only needed if you want to describe the configuration options associated with either
        /// the configuration template or environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the environment whose configuration options you want to describe. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, restricts the descriptions to only the specified options. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Options")]
        public Amazon.ElasticBeanstalk.Model.OptionSpecification[] Option { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the configuration template whose configuration options you want to describe.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the solution stack whose configuration options you want to describe.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SolutionStackName { get; set; }
        
        
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
            if (this.Option != null)
            {
                context.Options = new List<Amazon.ElasticBeanstalk.Model.OptionSpecification>(this.Option);
            }
            context.SolutionStackName = this.SolutionStackName;
            context.TemplateName = this.TemplateName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticBeanstalk.Model.DescribeConfigurationOptionsRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.Options != null)
            {
                request.Options = cmdletContext.Options;
            }
            if (cmdletContext.SolutionStackName != null)
            {
                request.SolutionStackName = cmdletContext.SolutionStackName;
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
                var response = client.DescribeConfigurationOptions(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Options;
                notes = new Dictionary<string, object>();
                notes["SolutionStackName"] = response.SolutionStackName;
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
            public System.String EnvironmentName { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.OptionSpecification> Options { get; set; }
            public System.String SolutionStackName { get; set; }
            public System.String TemplateName { get; set; }
        }
        
    }
}
