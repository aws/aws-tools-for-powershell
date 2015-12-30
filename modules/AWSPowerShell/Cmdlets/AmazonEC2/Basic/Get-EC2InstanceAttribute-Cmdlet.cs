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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the specified attribute of the specified instance. You can specify only
    /// one attribute at a time. Valid attribute values are: <code>instanceType</code> | <code>kernel</code>
    /// | <code>ramdisk</code> | <code>userData</code> | <code>disableApiTermination</code>
    /// | <code>instanceInitiatedShutdownBehavior</code> | <code>rootDeviceName</code> | <code>blockDeviceMapping</code>
    /// | <code>productCodes</code> | <code>sourceDestCheck</code> | <code>groupSet</code>
    /// | <code>ebsOptimized</code> | <code>sriovNetSupport</code>
    /// </summary>
    [Cmdlet("Get", "EC2InstanceAttribute")]
    [OutputType("Amazon.EC2.Model.InstanceAttribute")]
    [AWSCmdlet("Invokes the DescribeInstanceAttribute operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeInstanceAttribute"})]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceAttribute",
        "This cmdlet returns a InstanceAttribute object.",
        "The service call response (type Amazon.EC2.Model.DescribeInstanceAttributeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2InstanceAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The instance attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [AWSConstantClassSource("Amazon.EC2.InstanceAttributeName")]
        public Amazon.EC2.InstanceAttributeName Attribute { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Attribute = this.Attribute;
            context.InstanceId = this.InstanceId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeInstanceAttributeRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attribute = cmdletContext.Attribute;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeInstanceAttribute(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InstanceAttribute;
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
            public Amazon.EC2.InstanceAttributeName Attribute { get; set; }
            public System.String InstanceId { get; set; }
        }
        
    }
}
