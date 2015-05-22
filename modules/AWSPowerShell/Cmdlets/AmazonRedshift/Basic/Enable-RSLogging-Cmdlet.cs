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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Starts logging information, such as queries and connection attempts, for the specified
    /// Amazon Redshift cluster.
    /// </summary>
    [Cmdlet("Enable", "RSLogging", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.EnableLoggingResponse")]
    [AWSCmdlet("Invokes the EnableLogging operation against Amazon Redshift.", Operation = new[] {"EnableLogging"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.EnableLoggingResponse",
        "This cmdlet returns a EnableLoggingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EnableRSLoggingCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The name of an existing S3 bucket where the log files are to be stored. </para><para>Constraints:</para><ul><li>Must be in the same region as the cluster</li><li>The cluster must have
        /// read bucket and put object permissions</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String BucketName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The identifier of the cluster on which logging is to be started. </para><para>Example: <code>examplecluster</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ClusterIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The prefix applied to the log file names. </para><para>Constraints:</para><ul><li>Cannot exceed 512 characters</li><li>Cannot contain spaces( ), double quotes
        /// ("), single quotes ('), a backslash (\), or control characters. The hexadecimal codes
        /// for invalid characters are: <ul><li>x00 to x20</li><li>x22</li><li>x27</li><li>x5c</li><li>x7f or larger</li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String S3KeyPrefix { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BucketName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-RSLogging (EnableLogging)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.BucketName = this.BucketName;
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.S3KeyPrefix = this.S3KeyPrefix;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new EnableLoggingRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.S3KeyPrefix != null)
            {
                request.S3KeyPrefix = cmdletContext.S3KeyPrefix;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.EnableLogging(request);
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
            public String BucketName { get; set; }
            public String ClusterIdentifier { get; set; }
            public String S3KeyPrefix { get; set; }
        }
        
    }
}
