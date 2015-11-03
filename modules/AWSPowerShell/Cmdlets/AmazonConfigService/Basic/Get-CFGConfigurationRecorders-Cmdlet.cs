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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the name of one or more specified configuration recorders. If the recorder
    /// name is not specified, this action returns the names of all the configuration recorders
    /// associated with the account. 
    /// 
    ///  <note><para>
    /// Currently, you can specify only one configuration recorder per account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGConfigurationRecorders")]
    [OutputType("Amazon.ConfigService.Model.ConfigurationRecorder")]
    [AWSCmdlet("Invokes the DescribeConfigurationRecorders operation against Amazon Config.", Operation = new[] {"DescribeConfigurationRecorders"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigurationRecorder",
        "This cmdlet returns a collection of ConfigurationRecorder objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeConfigurationRecordersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCFGConfigurationRecordersCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationRecorderName
        /// <summary>
        /// <para>
        /// <para>A list of configuration recorder names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConfigurationRecorderNames")]
        public System.String[] ConfigurationRecorderName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ConfigurationRecorderName != null)
            {
                context.ConfigurationRecorderNames = new List<System.String>(this.ConfigurationRecorderName);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ConfigService.Model.DescribeConfigurationRecordersRequest();
            
            if (cmdletContext.ConfigurationRecorderNames != null)
            {
                request.ConfigurationRecorderNames = cmdletContext.ConfigurationRecorderNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeConfigurationRecorders(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ConfigurationRecorders;
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
            public List<System.String> ConfigurationRecorderNames { get; set; }
        }
        
    }
}
