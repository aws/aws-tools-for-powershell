/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Creates a Simple AD directory.
    /// </summary>
    [Cmdlet("New", "DSDirectory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateDirectory operation against AWS Directory Service.", Operation = new[] {"CreateDirectory"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type CreateDirectoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewDSDirectoryCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A textual description for the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The fully qualified name for the directory, such as <code>corp.example.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The password for the directory administrator. The directory creation process creates
        /// a directory administrator account with the username <code>Administrator</code> and
        /// this password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String Password { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The short name of the directory, such as <code>CORP</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ShortName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The size of the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DirectorySize Size { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets for the directory servers. The two subnets must be
        /// in different Availability Zones. AWS Directory Service creates a directory server
        /// and a DNS server in each of these subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcSettings_SubnetIds")]
        public System.String[] VpcSettings_SubnetId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC to create the Simple AD directory in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String VpcSettings_VpcId { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSDirectory (CreateDirectory)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Description = this.Description;
            context.Name = this.Name;
            context.Password = this.Password;
            context.ShortName = this.ShortName;
            context.Size = this.Size;
            if (this.VpcSettings_SubnetId != null)
            {
                context.VpcSettings_SubnetIds = new List<String>(this.VpcSettings_SubnetId);
            }
            context.VpcSettings_VpcId = this.VpcSettings_VpcId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateDirectoryRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.ShortName != null)
            {
                request.ShortName = cmdletContext.ShortName;
            }
            if (cmdletContext.Size != null)
            {
                request.Size = cmdletContext.Size;
            }
            
             // populate VpcSettings
            bool requestVpcSettingsIsNull = true;
            request.VpcSettings = new DirectoryVpcSettings();
            List<String> requestVpcSettings_vpcSettings_SubnetId = null;
            if (cmdletContext.VpcSettings_SubnetIds != null)
            {
                requestVpcSettings_vpcSettings_SubnetId = cmdletContext.VpcSettings_SubnetIds;
            }
            if (requestVpcSettings_vpcSettings_SubnetId != null)
            {
                request.VpcSettings.SubnetIds = requestVpcSettings_vpcSettings_SubnetId;
                requestVpcSettingsIsNull = false;
            }
            String requestVpcSettings_vpcSettings_VpcId = null;
            if (cmdletContext.VpcSettings_VpcId != null)
            {
                requestVpcSettings_vpcSettings_VpcId = cmdletContext.VpcSettings_VpcId;
            }
            if (requestVpcSettings_vpcSettings_VpcId != null)
            {
                request.VpcSettings.VpcId = requestVpcSettings_vpcSettings_VpcId;
                requestVpcSettingsIsNull = false;
            }
             // determine if request.VpcSettings should be set to null
            if (requestVpcSettingsIsNull)
            {
                request.VpcSettings = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateDirectory(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DirectoryId;
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
            public String Description { get; set; }
            public String Name { get; set; }
            public String Password { get; set; }
            public String ShortName { get; set; }
            public DirectorySize Size { get; set; }
            public List<String> VpcSettings_SubnetIds { get; set; }
            public String VpcSettings_VpcId { get; set; }
        }
        
    }
}
