/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates an endpoint for a Network File System (NFS) file system.
    /// </summary>
    [Cmdlet("New", "DSYNLocationNfs", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationNfs API operation.", Operation = new[] {"CreateLocationNfs"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationNfsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSYNLocationNfsCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        #region Parameter OnPremConfig_AgentArn
        /// <summary>
        /// <para>
        /// <para>ARNs)of the agents to use for an NFS location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OnPremConfig_AgentArns")]
        public System.String[] OnPremConfig_AgentArn { get; set; }
        #endregion
        
        #region Parameter ServerHostname
        /// <summary>
        /// <para>
        /// <para>The name of the NFS server. This value is the IP address or Domain Name Service (DNS)
        /// name of the NFS server. An agent that is installed on-premises uses this host name
        /// to mount the NFS server in a network. </para><note><para>This name must either be DNS-compliant or must be an IP version 4 (IPv4) address.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServerHostname { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>The subdirectory in the NFS file system that is used to read data from the NFS source
        /// location or write data to the NFS destination. The NFS path should be a path that's
        /// exported by the NFS server, or a subdirectory of that path. The path should be such
        /// that it can be mounted by other NFS clients in your network. </para><para>To see all the paths exported by your NFS server. run "<code>showmount -e nfs-server-name</code>"
        /// from an NFS client that has access to your server. You can specify any directory that
        /// appears in the results, and any subdirectory of that directory. Ensure that the NFS
        /// export is accessible without Kerberos authentication. </para><para>To transfer all the data in the folder you specified, DataSync needs to have permissions
        /// to read all the data. To ensure this, either configure the NFS export with <code>no_root_squash,</code>
        /// or ensure that the permissions for all of the files that you want sync allow read
        /// access for all users. Doing either enables the agent to read the files. For the agent
        /// to access directories, you must additionally enable all execute access. For information
        /// about NFS export configuration, see <a href="https://www.centos.org/docs/5/html/Deployment_Guide-en-US/s1-nfs-server-config-exports.html">18.7.
        /// The /etc/exports Configuration File</a> in the Centos documentation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair that represents the tag that you want to add to the location. The
        /// value can be an empty string. We recommend using tags to name your resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationNfs (CreateLocationNfs)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.OnPremConfig_AgentArn != null)
            {
                context.OnPremConfig_AgentArns = new List<System.String>(this.OnPremConfig_AgentArn);
            }
            context.ServerHostname = this.ServerHostname;
            context.Subdirectory = this.Subdirectory;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
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
            
            
             // populate OnPremConfig
            bool requestOnPremConfigIsNull = true;
            request.OnPremConfig = new Amazon.DataSync.Model.OnPremConfig();
            List<System.String> requestOnPremConfig_onPremConfig_AgentArn = null;
            if (cmdletContext.OnPremConfig_AgentArns != null)
            {
                requestOnPremConfig_onPremConfig_AgentArn = cmdletContext.OnPremConfig_AgentArns;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.LocationArn;
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
        
        #region AWS Service Operation Call
        
        private Amazon.DataSync.Model.CreateLocationNfsResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationNfsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationNfs");
            try
            {
                #if DESKTOP
                return client.CreateLocationNfs(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateLocationNfsAsync(request);
                return task.Result;
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
            public List<System.String> OnPremConfig_AgentArns { get; set; }
            public System.String ServerHostname { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tags { get; set; }
        }
        
    }
}
