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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns AWS resource descriptions for running and deleted stacks. If <code>StackName</code>
    /// is specified, all the associated resources that are part of the stack are returned.
    /// If <code>PhysicalResourceId</code> is specified, the associated resources of the stack
    /// that the resource belongs to are returned.
    /// 
    ///  <note>Only the first 100 resources will be returned. If your stack has more resources
    /// than this, you should use <code>ListStackResources</code> instead.</note><para>
    /// For deleted stacks, <code>DescribeStackResources</code> returns resource information
    /// for up to 90 days after the stack has been deleted.
    /// </para><para>
    /// You must specify either <code>StackName</code> or <code>PhysicalResourceId</code>,
    /// but not both. In addition, you can specify <code>LogicalResourceId</code> to filter
    /// the returned result. For more information about resources, the <code>LogicalResourceId</code>
    /// and <code>PhysicalResourceId</code>, go to the <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide">AWS
    /// CloudFormation User Guide</a>.
    /// </para><note>A <code>ValidationError</code> is returned if you specify both <code>StackName</code>
    /// and <code>PhysicalResourceId</code> in the same request.</note>
    /// </summary>
    [Cmdlet("Get", "CFNStackResources")]
    [OutputType("Amazon.CloudFormation.Model.StackResource")]
    [AWSCmdlet("Invokes the DescribeStackResources operation against AWS CloudFormation.", Operation = new[] {"DescribeStackResources"})]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.StackResource",
        "This cmdlet returns a collection of StackResource objects.",
        "The service call response (type DescribeStackResourcesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCFNStackResourcesCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The logical name of the resource as specified in the template.</para><para>Default: There is no default value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String LogicalResourceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name or unique identifier that corresponds to a physical instance ID of a resource
        /// supported by AWS CloudFormation.</para><para>For example, for an Amazon Elastic Compute Cloud (EC2) instance, <code>PhysicalResourceId</code>
        /// corresponds to the <code>InstanceId</code>. You can pass the EC2 <code>InstanceId</code>
        /// to <code>DescribeStackResources</code> to find which stack the instance belongs to
        /// and what other resources are part of the stack.</para><para>Required: Conditional. If you do not specify <code>PhysicalResourceId</code>, you
        /// must specify <code>StackName</code>.</para><para>Default: There is no default value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String PhysicalResourceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name or the unique stack ID that is associated with the stack, which are not always
        /// interchangeable:</para><ul><li>Running stacks: You can specify either the stack's name or its unique stack
        /// ID.</li><li>Deleted stacks: You must specify the unique stack ID.</li></ul><para>Default: There is no default value.</para><para>Required: Conditional. If you do not specify <code>StackName</code>, you must specify
        /// <code>PhysicalResourceId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String StackName { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.LogicalResourceId = this.LogicalResourceId;
            context.PhysicalResourceId = this.PhysicalResourceId;
            context.StackName = this.StackName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeStackResourcesRequest();
            
            if (cmdletContext.LogicalResourceId != null)
            {
                request.LogicalResourceId = cmdletContext.LogicalResourceId;
            }
            if (cmdletContext.PhysicalResourceId != null)
            {
                request.PhysicalResourceId = cmdletContext.PhysicalResourceId;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeStackResources(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StackResources;
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
            public String LogicalResourceId { get; set; }
            public String PhysicalResourceId { get; set; }
            public String StackName { get; set; }
        }
        
    }
}
