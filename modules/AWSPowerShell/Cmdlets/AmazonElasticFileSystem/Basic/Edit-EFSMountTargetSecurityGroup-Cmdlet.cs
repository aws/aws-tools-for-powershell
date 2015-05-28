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
    /// Modifies the set of security groups in effect for a mount target.
    /// 
    ///  
    /// <para>
    /// When you create a mount target, Amazon EFS also creates a new network interface (see
    /// <a>CreateMountTarget</a>). This operation replaces the security groups in effect for
    /// the network interface associated with a mount target, with the <code>SecurityGroups</code>
    /// provided in the request. This operation requires that the network interface of the
    /// mount target has been created and the life cycle state of the mount target is not
    /// "deleted". 
    /// </para><para>
    /// The operation requires permissions for the following actions:
    /// </para><ul><li><code>elasticfilesystem:ModifyMountTargetSecurityGroups</code> action on
    /// the mount target's file system. </li><li><code>ec2:ModifyNetworkInterfaceAttribute</code>
    /// action on the mount target's network interface. </li></ul>
    /// </summary>
    [Cmdlet("Edit", "EFSMountTargetSecurityGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ModifyMountTargetSecurityGroups operation against Amazon Elastic File System.", Operation = new[] {"ModifyMountTargetSecurityGroups"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the SecurityGroup parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type ModifyMountTargetSecurityGroupsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditEFSMountTargetSecurityGroupCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The ID of the mount target whose security groups you want to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String MountTargetId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of up to five VPC security group IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        
        /// <summary>
        /// Returns the value passed to the SecurityGroup parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("MountTargetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EFSMountTargetSecurityGroup (ModifyMountTargetSecurityGroups)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.MountTargetId = this.MountTargetId;
            if (this.SecurityGroup != null)
            {
                context.SecurityGroups = new List<String>(this.SecurityGroup);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ModifyMountTargetSecurityGroupsRequest();
            
            if (cmdletContext.MountTargetId != null)
            {
                request.MountTargetId = cmdletContext.MountTargetId;
            }
            if (cmdletContext.SecurityGroups != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroups;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ModifyMountTargetSecurityGroups(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.SecurityGroup;
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
            public String MountTargetId { get; set; }
            public List<String> SecurityGroups { get; set; }
        }
        
    }
}
