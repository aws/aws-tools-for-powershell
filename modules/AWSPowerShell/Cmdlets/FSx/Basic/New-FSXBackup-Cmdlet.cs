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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates a backup of an existing Amazon FSx for Windows File Server file system, Amazon
    /// FSx for Lustre file system, Amazon FSx for NetApp ONTAP volume, or Amazon FSx for
    /// OpenZFS file system. We recommend creating regular backups so that you can restore
    /// a file system or volume from a backup if an issue arises with the original file system
    /// or volume.
    /// 
    ///  
    /// <para>
    /// For Amazon FSx for Lustre file systems, you can create a backup only for file systems
    /// that have the following configuration:
    /// </para><ul><li><para>
    /// A Persistent deployment type
    /// </para></li><li><para>
    /// Are <i>not</i> linked to a data repository
    /// </para></li></ul><para>
    /// For more information about backups, see the following:
    /// </para><ul><li><para>
    /// For Amazon FSx for Lustre, see <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/using-backups-fsx.html">Working
    /// with FSx for Lustre backups</a>.
    /// </para></li><li><para>
    /// For Amazon FSx for Windows, see <a href="https://docs.aws.amazon.com/fsx/latest/WindowsGuide/using-backups.html">Working
    /// with FSx for Windows backups</a>.
    /// </para></li><li><para>
    /// For Amazon FSx for NetApp ONTAP, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/using-backups.html">Working
    /// with FSx for NetApp ONTAP backups</a>.
    /// </para></li><li><para>
    /// For Amazon FSx for OpenZFS, see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/using-backups.html">Working
    /// with FSx for OpenZFS backups</a>.
    /// </para></li></ul><para>
    /// If a backup with the specified client request token exists and the parameters match,
    /// this operation returns the description of the existing backup. If a backup with the
    /// specified client request token exists and the parameters don't match, this operation
    /// returns <code>IncompatibleParameterError</code>. If a backup with the specified client
    /// request token doesn't exist, <code>CreateBackup</code> does the following: 
    /// </para><ul><li><para>
    /// Creates a new Amazon FSx backup with an assigned ID, and an initial lifecycle state
    /// of <code>CREATING</code>.
    /// </para></li><li><para>
    /// Returns the description of the backup.
    /// </para></li></ul><para>
    /// By using the idempotent operation, you can retry a <code>CreateBackup</code> operation
    /// without the risk of creating an extra backup. This approach can be useful when an
    /// initial call fails in a way that makes it unclear whether a backup was created. If
    /// you use the same client request token and the initial call created a backup, the operation
    /// returns a successful result because all the parameters are the same.
    /// </para><para>
    /// The <code>CreateBackup</code> operation returns while the backup's lifecycle state
    /// is still <code>CREATING</code>. You can check the backup creation status by calling
    /// the <a href="https://docs.aws.amazon.com/fsx/latest/APIReference/API_DescribeBackups.html">DescribeBackups</a>
    /// operation, which returns the backup state along with other information.
    /// </para>
    /// </summary>
    [Cmdlet("New", "FSXBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.Backup")]
    [AWSCmdlet("Calls the Amazon FSx CreateBackup API operation.", Operation = new[] {"CreateBackup"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateBackupResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.Backup or Amazon.FSx.Model.CreateBackupResponse",
        "This cmdlet returns an Amazon.FSx.Model.Backup object.",
        "The service call response (type Amazon.FSx.Model.CreateBackupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFSXBackupCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>(Optional) A string of up to 63 ASCII characters that Amazon FSx uses to ensure idempotent
        /// creation. This string is automatically filled on your behalf when you use the Command
        /// Line Interface (CLI) or an Amazon Web Services SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the file system to back up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>(Optional) The tags to apply to the backup at backup creation. The key value of the
        /// <code>Name</code> tag appears in the console as the backup name. If you have set <code>CopyTagsToBackups</code>
        /// to <code>true</code>, and you specify one or more tags using the <code>CreateBackup</code>
        /// operation, no existing file system tags are copied from the file system to the backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>(Optional) The ID of the FSx for ONTAP volume to back up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VolumeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Backup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateBackupResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateBackupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Backup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FileSystemId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FileSystemId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FileSystemId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXBackup (CreateBackup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateBackupResponse, NewFSXBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FileSystemId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.FileSystemId = this.FileSystemId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FSx.Model.Tag>(this.Tag);
            }
            context.VolumeId = this.VolumeId;
            
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
            var request = new Amazon.FSx.Model.CreateBackupRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeId = cmdletContext.VolumeId;
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
        
        private Amazon.FSx.Model.CreateBackupResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateBackup");
            try
            {
                #if DESKTOP
                return client.CreateBackup(request);
                #elif CORECLR
                return client.CreateBackupAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String FileSystemId { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public System.String VolumeId { get; set; }
            public System.Func<Amazon.FSx.Model.CreateBackupResponse, NewFSXBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Backup;
        }
        
    }
}
