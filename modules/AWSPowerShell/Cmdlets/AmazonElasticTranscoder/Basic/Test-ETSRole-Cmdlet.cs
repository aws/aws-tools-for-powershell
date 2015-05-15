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
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;

namespace Amazon.PowerShell.Cmdlets.ETS
{
    /// <summary>
    /// The TestRole operation tests the IAM role used to create the pipeline.
    /// 
    ///  
    /// <para>
    /// The <code>TestRole</code> action lets you determine whether the IAM role you are using
    /// has sufficient permissions to let Elastic Transcoder perform tasks associated with
    /// the transcoding process. The action attempts to assume the specified IAM role, checks
    /// read access to the input and output buckets, and tries to send a test notification
    /// to Amazon SNS topics that you specify.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "ETSRole")]
    [OutputType("Amazon.ElasticTranscoder.Model.TestRoleResult")]
    [AWSCmdlet("Invokes the TestRole operation against Amazon Elastic Transcoder.", Operation = new[] {"TestRole"})]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.TestRoleResult",
        "This cmdlet returns a TestRoleResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class TestETSRoleCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket that contains media files to be transcoded. The action attempts
        /// to read from this bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String InputBucket { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket that Elastic Transcoder will write transcoded media files to.
        /// The action attempts to read from this bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String OutputBucket { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The IAM Amazon Resource Name (ARN) for the role that you want Elastic Transcoder to
        /// test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Role { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARNs of one or more Amazon Simple Notification Service (Amazon SNS) topics that
        /// you want the action to send a test notification to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("Topics")]
        public System.String[] Topic { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.InputBucket = this.InputBucket;
            context.OutputBucket = this.OutputBucket;
            context.Role = this.Role;
            if (this.Topic != null)
            {
                context.Topics = new List<String>(this.Topic);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new TestRoleRequest();
            
            if (cmdletContext.InputBucket != null)
            {
                request.InputBucket = cmdletContext.InputBucket;
            }
            if (cmdletContext.OutputBucket != null)
            {
                request.OutputBucket = cmdletContext.OutputBucket;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Topics != null)
            {
                request.Topics = cmdletContext.Topics;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.TestRole(request);
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
            public String InputBucket { get; set; }
            public String OutputBucket { get; set; }
            public String Role { get; set; }
            public List<String> Topics { get; set; }
        }
        
    }
}
