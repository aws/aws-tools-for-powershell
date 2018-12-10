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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates a new Amazon FSx file system from an existing Amazon FSx for Windows File
    /// Server backup.
    /// 
    ///  
    /// <para>
    /// If a file system with the specified client request token exists and the parameters
    /// match, this call returns the description of the existing file system. If a client
    /// request token specified by the file system exists and the parameters don't match,
    /// this call returns <code>IncompatibleParameterError</code>. If a file system with the
    /// specified client request token doesn't exist, this operation does the following:
    /// </para><ul><li><para>
    /// Creates a new Amazon FSx file system from backup with an assigned ID, and an initial
    /// lifecycle state of <code>CREATING</code>.
    /// </para></li><li><para>
    /// Returns the description of the file system.
    /// </para></li></ul><para>
    /// Parameters like Active Directory, default share name, automatic backup, and backup
    /// settings default to the parameters of the file system that was backed up, unless overridden.
    /// You can explicitly supply other settings.
    /// </para><para>
    /// By using the idempotent operation, you can retry a <code>CreateFileSystemFromBackup</code>
    /// call without the risk of creating an extra file system. This approach can be useful
    /// when an initial call fails in a way that makes it unclear whether a file system was
    /// created. Examples are if a transport level timeout occurred, or your connection was
    /// reset. If you use the same client request token and the initial call created a file
    /// system, the client receives success as long as the parameters are the same.
    /// </para><note><para>
    /// The <code>CreateFileSystemFromBackup</code> call returns while the file system's lifecycle
    /// state is still <code>CREATING</code>. You can check the file-system creation status
    /// by calling the <a>DescribeFileSystems</a> operation, which returns the file system
    /// state along with other information.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "FSXFileSystemFromBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.FileSystem")]
    [AWSCmdlet("Calls the Amazon FSx CreateFileSystemFromBackup API operation.", Operation = new[] {"CreateFileSystemFromBackup"})]
    [AWSCmdletOutput("Amazon.FSx.Model.FileSystem",
        "This cmdlet returns a FileSystem object.",
        "The service call response (type Amazon.FSx.Model.CreateFileSystemFromBackupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFSXFileSystemFromBackupCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        #region Parameter BackupId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BackupId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>(Optional) A string of up to 64 ASCII characters that Amazon FSx uses to ensure idempotent
        /// creation. This string is automatically filled on your behalf when you use the AWS
        /// Command Line Interface (AWS CLI) or an AWS SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of IDs for the security groups that apply to the specified network interfaces
        /// created for file system access. These security groups apply to all network interfaces.
        /// This value isn't returned in later describe requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of IDs for the subnets that the file system will be accessible from. Currently,
        /// you can specify only one subnet. The file server is also launched in that subnet's
        /// Availability Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be applied to the file system at file system creation. The key value of
        /// the <code>Name</code> tag appears in the console as the file system name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter WindowsConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration for this Microsoft Windows file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.FSx.Model.CreateFileSystemWindowsConfiguration WindowsConfiguration { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BackupId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXFileSystemFromBackup (CreateFileSystemFromBackup)"))
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
            
            context.BackupId = this.BackupId;
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupIds = new List<System.String>(this.SecurityGroupId);
            }
            if (this.SubnetId != null)
            {
                context.SubnetIds = new List<System.String>(this.SubnetId);
            }
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.FSx.Model.Tag>(this.Tag);
            }
            context.WindowsConfiguration = this.WindowsConfiguration;
            
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
            var request = new Amazon.FSx.Model.CreateFileSystemFromBackupRequest();
            
            if (cmdletContext.BackupId != null)
            {
                request.BackupId = cmdletContext.BackupId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.SecurityGroupIds != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupIds;
            }
            if (cmdletContext.SubnetIds != null)
            {
                request.SubnetIds = cmdletContext.SubnetIds;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.WindowsConfiguration != null)
            {
                request.WindowsConfiguration = cmdletContext.WindowsConfiguration;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FileSystem;
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
        
        private Amazon.FSx.Model.CreateFileSystemFromBackupResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateFileSystemFromBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateFileSystemFromBackup");
            try
            {
                #if DESKTOP
                return client.CreateFileSystemFromBackup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateFileSystemFromBackupAsync(request);
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
            public System.String BackupId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public List<System.String> SecurityGroupIds { get; set; }
            public List<System.String> SubnetIds { get; set; }
            public List<Amazon.FSx.Model.Tag> Tags { get; set; }
            public Amazon.FSx.Model.CreateFileSystemWindowsConfiguration WindowsConfiguration { get; set; }
        }
        
    }
}
