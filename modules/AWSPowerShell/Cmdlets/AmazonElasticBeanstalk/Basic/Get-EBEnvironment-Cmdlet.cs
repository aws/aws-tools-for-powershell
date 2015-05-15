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
    /// Returns descriptions for existing environments.
    /// </summary>
    [Cmdlet("Get", "EBEnvironment")]
    [OutputType("Amazon.ElasticBeanstalk.Model.EnvironmentDescription")]
    [AWSCmdlet("Invokes the DescribeEnvironments operation against AWS Elastic Beanstalk.", Operation = new[] {"DescribeEnvironments"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.EnvironmentDescription",
        "This cmdlet returns a collection of EnvironmentDescription objects.",
        "The service call response (type DescribeEnvironmentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEBEnvironmentCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that are associated with this application. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ApplicationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that have the specified IDs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentIds")]
        public System.String[] EnvironmentId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that have the specified names. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentNames")]
        public System.String[] EnvironmentName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified when <code>IncludeDeleted</code> is set to <code>true</code>, then environments
        /// deleted after this date are displayed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime IncludedDeletedBackTo { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include deleted environments: </para><para><code>true</code>: Environments that have been deleted after <code>IncludedDeletedBackTo</code>
        /// are displayed. </para><para><code>false</code>: Do not include deleted environments. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean IncludeDeleted { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that are associated with this application version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public String VersionLabel { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ApplicationName = this.ApplicationName;
            if (this.EnvironmentId != null)
            {
                context.EnvironmentIds = new List<String>(this.EnvironmentId);
            }
            if (this.EnvironmentName != null)
            {
                context.EnvironmentNames = new List<String>(this.EnvironmentName);
            }
            if (ParameterWasBound("IncludedDeletedBackTo"))
                context.IncludedDeletedBackTo = this.IncludedDeletedBackTo;
            if (ParameterWasBound("IncludeDeleted"))
                context.IncludeDeleted = this.IncludeDeleted;
            context.VersionLabel = this.VersionLabel;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeEnvironmentsRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.EnvironmentIds != null)
            {
                request.EnvironmentIds = cmdletContext.EnvironmentIds;
            }
            if (cmdletContext.EnvironmentNames != null)
            {
                request.EnvironmentNames = cmdletContext.EnvironmentNames;
            }
            if (cmdletContext.IncludedDeletedBackTo != null)
            {
                request.IncludedDeletedBackTo = cmdletContext.IncludedDeletedBackTo.Value;
            }
            if (cmdletContext.IncludeDeleted != null)
            {
                request.IncludeDeleted = cmdletContext.IncludeDeleted.Value;
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
                var response = client.DescribeEnvironments(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Environments;
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
            public List<String> EnvironmentIds { get; set; }
            public List<String> EnvironmentNames { get; set; }
            public DateTime? IncludedDeletedBackTo { get; set; }
            public Boolean? IncludeDeleted { get; set; }
            public String VersionLabel { get; set; }
        }
        
    }
}
