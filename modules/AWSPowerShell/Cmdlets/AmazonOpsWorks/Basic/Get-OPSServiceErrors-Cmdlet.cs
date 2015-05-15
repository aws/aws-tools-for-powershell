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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Describes AWS OpsWorks service errors.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Show, Deploy,
    /// or Manage permissions level for the stack, or an attached policy that explicitly grants
    /// permissions. For more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "OPSServiceErrors")]
    [OutputType("Amazon.OpsWorks.Model.ServiceError")]
    [AWSCmdlet("Invokes the DescribeServiceErrors operation against AWS OpsWorks.", Operation = new[] {"DescribeServiceErrors"})]
    [AWSCmdletOutput("Amazon.OpsWorks.Model.ServiceError",
        "This cmdlet returns a collection of ServiceError objects.",
        "The service call response (type DescribeServiceErrorsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetOPSServiceErrorsCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The instance ID. If you use this parameter, <code>DescribeServiceErrors</code> returns
        /// descriptions of the errors associated with the specified instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String InstanceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of service error IDs. If you use this parameter, <code>DescribeServiceErrors</code>
        /// returns descriptions of the specified errors. Otherwise, it returns a description
        /// of every error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("ServiceErrorIds")]
        public System.String[] ServiceErrorId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The stack ID. If you use this parameter, <code>DescribeServiceErrors</code> returns
        /// descriptions of the errors associated with the specified stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String StackId { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.InstanceId = this.InstanceId;
            if (this.ServiceErrorId != null)
            {
                context.ServiceErrorIds = new List<String>(this.ServiceErrorId);
            }
            context.StackId = this.StackId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeServiceErrorsRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.ServiceErrorIds != null)
            {
                request.ServiceErrorIds = cmdletContext.ServiceErrorIds;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeServiceErrors(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ServiceErrors;
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
            public String InstanceId { get; set; }
            public List<String> ServiceErrorIds { get; set; }
            public String StackId { get; set; }
        }
        
    }
}
