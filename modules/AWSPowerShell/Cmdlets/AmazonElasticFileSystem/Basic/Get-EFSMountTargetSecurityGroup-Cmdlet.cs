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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Returns the security groups currently in effect for a mount target. This operation
    /// requires that the network interface of the mount target has been created and the life
    /// cycle state of the mount target is not "deleted".
    /// 
    ///  
    /// <para>
    /// This operation requires permissions for the following actions:
    /// </para><ul><li><code>elasticfilesystem:DescribeMountTargetSecurityGroups</code> action
    /// on the mount target's file system. </li><li><code>ec2:DescribeNetworkInterfaceAttribute</code>
    /// action on the mount target's network interface. </li></ul>
    /// </summary>
    [Cmdlet("Get", "EFSMountTargetSecurityGroup")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the DescribeMountTargetSecurityGroups operation against Amazon Elastic File System.", Operation = new[] {"DescribeMountTargetSecurityGroups"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEFSMountTargetSecurityGroupCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        #region Parameter MountTargetId
        /// <summary>
        /// <para>
        /// <para>The ID of the mount target whose security groups you want to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String MountTargetId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.MountTargetId = this.MountTargetId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticFileSystem.Model.DescribeMountTargetSecurityGroupsRequest();
            
            if (cmdletContext.MountTargetId != null)
            {
                request.MountTargetId = cmdletContext.MountTargetId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeMountTargetSecurityGroups(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SecurityGroups;
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
            public System.String MountTargetId { get; set; }
        }
        
    }
}
