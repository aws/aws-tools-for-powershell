/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Defines a file system on a Network File System (NFS) server that can be read from
    /// or written to.
    /// </summary>
    [Cmdlet("New", "DSYNLocationNfs", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationNfs API operation.", Operation = new[] {"CreateLocationNfs"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateLocationNfsResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateLocationNfsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationNfsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSYNLocationNfsCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        #region Parameter OnPremConfig_AgentArn
        /// <summary>
        /// <para>
        /// <para>ARNs of the agents to use for an NFS location.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("OnPremConfig_AgentArns")]
        public System.String[] OnPremConfig_AgentArn { get; set; }
        #endregion
        
        #region Parameter ServerHostname
        /// <summary>
        /// <para>
        /// <para>The name of the NFS server. This value is the IP address or Domain Name Service (DNS)
        /// name of the NFS server. An agent that is installed on-premises uses this hostname
        /// to mount the NFS server in a network. </para><para>If you are copying data to or from your Snowcone device, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-nfs-location.html#nfs-on-snowcone">NFS
        /// Server on Snowcone</a> for more information.</para><note><para>This name must either be DNS-compliant or must be an IP version 4 (IPv4) address.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServerHostname { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>The subdirectory in the NFS file system that is used to read data from the NFS source
        /// location or write data to the NFS destination. The NFS path should be a path that's
        /// exported by the NFS server, or a subdirectory of that path. The path should be such
        /// that it can be mounted by other NFS clients in your network. </para><para>To see all the paths exported by your NFS server, run "<code>showmount -e nfs-server-name</code>"
        /// from an NFS client that has access to your server. You can specify any directory that
        /// appears in the results, and any subdirectory of that directory. Ensure that the NFS
        /// export is accessible without Kerberos authentication. </para><para>To transfer all the data in the folder you specified, DataSync needs to have permissions
        /// to read all the data. To ensure this, either configure the NFS export with <code>no_root_squash,</code>
        /// or ensure that the permissions for all of the files that you want DataSync allow read
        /// access for all users. Doing either enables the agent to read the files. For the agent
        /// to access directories, you must additionally enable all execute access.</para><para>If you are copying data to or from your Snowcone device, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-nfs-location.html#nfs-on-snowcone">NFS
        /// Server on Snowcone</a> for more information.</para><para>For information about NFS export configuration, see 18.7. The /etc/exports Configuration
        /// File in the Red Hat Enterprise Linux documentation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair that represents the tag that you want to add to the location. The
        /// value can be an empty string. We recommend using tags to name your resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter MountOptions_Version
        /// <summary>
        /// <para>
        /// <para>Specifies the NFS version that you want DataSync to use when mounting your NFS share.
        /// If the server refuses to use the version specified, the task fails.</para><para>You can specify the following options:</para><ul><li><para><code>AUTOMATIC</code> (default): DataSync chooses NFS version 4.1.</para></li><li><para><code>NFS3</code>: Stateless protocol version that allows for asynchronous writes
        /// on the server.</para></li><li><para><code>NFSv4_0</code>: Stateful, firewall-friendly protocol version that supports
        /// delegations and pseudo file systems.</para></li><li><para><code>NFSv4_1</code>: Stateful protocol version that supports sessions, directory
        /// delegations, and parallel data processing. NFS version 4.1 also includes all features
        /// available in version 4.0.</para></li></ul><note><para>DataSync currently only supports NFS version 3 with Amazon FSx for NetApp ONTAP locations.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.NfsVersion")]
        public Amazon.DataSync.NfsVersion MountOptions_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateLocationNfsResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateLocationNfsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocationArn";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationNfs (CreateLocationNfs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateLocationNfsResponse, NewDSYNLocationNfsCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MountOptions_Version = this.MountOptions_Version;
            if (this.OnPremConfig_AgentArn != null)
            {
                context.OnPremConfig_AgentArn = new List<System.String>(this.OnPremConfig_AgentArn);
            }
            #if MODULAR
            if (this.OnPremConfig_AgentArn == null && ParameterWasBound(nameof(this.OnPremConfig_AgentArn)))
            {
                WriteWarning("You are passing $null as a value for parameter OnPremConfig_AgentArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerHostname = this.ServerHostname;
            #if MODULAR
            if (this.ServerHostname == null && ParameterWasBound(nameof(this.ServerHostname)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerHostname which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Subdirectory = this.Subdirectory;
            #if MODULAR
            if (this.Subdirectory == null && ParameterWasBound(nameof(this.Subdirectory)))
            {
                WriteWarning("You are passing $null as a value for parameter Subdirectory which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DataSync.Model.CreateLocationNfsRequest();
            
            
             // populate MountOptions
            var requestMountOptionsIsNull = true;
            request.MountOptions = new Amazon.DataSync.Model.NfsMountOptions();
            Amazon.DataSync.NfsVersion requestMountOptions_mountOptions_Version = null;
            if (cmdletContext.MountOptions_Version != null)
            {
                requestMountOptions_mountOptions_Version = cmdletContext.MountOptions_Version;
            }
            if (requestMountOptions_mountOptions_Version != null)
            {
                request.MountOptions.Version = requestMountOptions_mountOptions_Version;
                requestMountOptionsIsNull = false;
            }
             // determine if request.MountOptions should be set to null
            if (requestMountOptionsIsNull)
            {
                request.MountOptions = null;
            }
            
             // populate OnPremConfig
            var requestOnPremConfigIsNull = true;
            request.OnPremConfig = new Amazon.DataSync.Model.OnPremConfig();
            List<System.String> requestOnPremConfig_onPremConfig_AgentArn = null;
            if (cmdletContext.OnPremConfig_AgentArn != null)
            {
                requestOnPremConfig_onPremConfig_AgentArn = cmdletContext.OnPremConfig_AgentArn;
            }
            if (requestOnPremConfig_onPremConfig_AgentArn != null)
            {
                request.OnPremConfig.AgentArns = requestOnPremConfig_onPremConfig_AgentArn;
                requestOnPremConfigIsNull = false;
            }
             // determine if request.OnPremConfig should be set to null
            if (requestOnPremConfigIsNull)
            {
                request.OnPremConfig = null;
            }
            if (cmdletContext.ServerHostname != null)
            {
                request.ServerHostname = cmdletContext.ServerHostname;
            }
            if (cmdletContext.Subdirectory != null)
            {
                request.Subdirectory = cmdletContext.Subdirectory;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        #region AWS Service Operation Call
        
        private Amazon.DataSync.Model.CreateLocationNfsResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationNfsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationNfs");
            try
            {
                #if DESKTOP
                return client.CreateLocationNfs(request);
                #elif CORECLR
                return client.CreateLocationNfsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Amazon.DataSync.NfsVersion MountOptions_Version { get; set; }
            public List<System.String> OnPremConfig_AgentArn { get; set; }
            public System.String ServerHostname { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateLocationNfsResponse, NewDSYNLocationNfsCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocationArn;
        }
        
    }
}
