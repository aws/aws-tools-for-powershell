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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Creates an AD Connector to connect to an on-premises directory.
    /// </summary>
    [Cmdlet("Connect", "DSDirectory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ConnectDirectory operation against AWS Directory Service.", Operation = new[] {"ConnectDirectory"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.DirectoryService.Model.ConnectDirectoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class ConnectDSDirectoryCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConnectSettings_CustomerDnsIp
        /// <summary>
        /// <para>
        /// <para>A list of one or more IP addresses of DNS servers or domain controllers in the on-premises
        /// directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConnectSettings_CustomerDnsIps")]
        public System.String[] ConnectSettings_CustomerDnsIp { get; set; }
        #endregion
        
        #region Parameter ConnectSettings_CustomerUserName
        /// <summary>
        /// <para>
        /// <para>The username of an account in the on-premises directory that is used to connect to
        /// the directory. This account must have the following privileges:</para><ul><li>Read users and groups</li><li>Create computer objects</li><li>Join computers
        /// to the domain</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConnectSettings_CustomerUserName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A textual description for the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The fully-qualified name of the on-premises directory, such as <code>corp.example.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password for the on-premises user account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter ShortName
        /// <summary>
        /// <para>
        /// <para>The NetBIOS name of the on-premises directory, such as <code>CORP</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ShortName { get; set; }
        #endregion
        
        #region Parameter Size
        /// <summary>
        /// <para>
        /// <para>The size of the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DirectoryService.DirectorySize")]
        public Amazon.DirectoryService.DirectorySize Size { get; set; }
        #endregion
        
        #region Parameter ConnectSettings_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet identifiers in the VPC in which the AD Connector is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ConnectSettings_SubnetIds")]
        public System.String[] ConnectSettings_SubnetId { get; set; }
        #endregion
        
        #region Parameter ConnectSettings_VpcId
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC in which the AD Connector is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConnectSettings_VpcId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-DSDirectory (ConnectDirectory)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ConnectSettings_CustomerDnsIp != null)
            {
                context.ConnectSettings_CustomerDnsIps = new List<System.String>(this.ConnectSettings_CustomerDnsIp);
            }
            context.ConnectSettings_CustomerUserName = this.ConnectSettings_CustomerUserName;
            if (this.ConnectSettings_SubnetId != null)
            {
                context.ConnectSettings_SubnetIds = new List<System.String>(this.ConnectSettings_SubnetId);
            }
            context.ConnectSettings_VpcId = this.ConnectSettings_VpcId;
            context.Description = this.Description;
            context.Name = this.Name;
            context.Password = this.Password;
            context.ShortName = this.ShortName;
            context.Size = this.Size;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DirectoryService.Model.ConnectDirectoryRequest();
            
            
             // populate ConnectSettings
            bool requestConnectSettingsIsNull = true;
            request.ConnectSettings = new Amazon.DirectoryService.Model.DirectoryConnectSettings();
            List<System.String> requestConnectSettings_connectSettings_CustomerDnsIp = null;
            if (cmdletContext.ConnectSettings_CustomerDnsIps != null)
            {
                requestConnectSettings_connectSettings_CustomerDnsIp = cmdletContext.ConnectSettings_CustomerDnsIps;
            }
            if (requestConnectSettings_connectSettings_CustomerDnsIp != null)
            {
                request.ConnectSettings.CustomerDnsIps = requestConnectSettings_connectSettings_CustomerDnsIp;
                requestConnectSettingsIsNull = false;
            }
            System.String requestConnectSettings_connectSettings_CustomerUserName = null;
            if (cmdletContext.ConnectSettings_CustomerUserName != null)
            {
                requestConnectSettings_connectSettings_CustomerUserName = cmdletContext.ConnectSettings_CustomerUserName;
            }
            if (requestConnectSettings_connectSettings_CustomerUserName != null)
            {
                request.ConnectSettings.CustomerUserName = requestConnectSettings_connectSettings_CustomerUserName;
                requestConnectSettingsIsNull = false;
            }
            List<System.String> requestConnectSettings_connectSettings_SubnetId = null;
            if (cmdletContext.ConnectSettings_SubnetIds != null)
            {
                requestConnectSettings_connectSettings_SubnetId = cmdletContext.ConnectSettings_SubnetIds;
            }
            if (requestConnectSettings_connectSettings_SubnetId != null)
            {
                request.ConnectSettings.SubnetIds = requestConnectSettings_connectSettings_SubnetId;
                requestConnectSettingsIsNull = false;
            }
            System.String requestConnectSettings_connectSettings_VpcId = null;
            if (cmdletContext.ConnectSettings_VpcId != null)
            {
                requestConnectSettings_connectSettings_VpcId = cmdletContext.ConnectSettings_VpcId;
            }
            if (requestConnectSettings_connectSettings_VpcId != null)
            {
                request.ConnectSettings.VpcId = requestConnectSettings_connectSettings_VpcId;
                requestConnectSettingsIsNull = false;
            }
             // determine if request.ConnectSettings should be set to null
            if (requestConnectSettingsIsNull)
            {
                request.ConnectSettings = null;
            }
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ConnectDirectory(request);
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
            public List<System.String> ConnectSettings_CustomerDnsIps { get; set; }
            public System.String ConnectSettings_CustomerUserName { get; set; }
            public List<System.String> ConnectSettings_SubnetIds { get; set; }
            public System.String ConnectSettings_VpcId { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String Password { get; set; }
            public System.String ShortName { get; set; }
            public Amazon.DirectoryService.DirectorySize Size { get; set; }
        }
        
    }
}
