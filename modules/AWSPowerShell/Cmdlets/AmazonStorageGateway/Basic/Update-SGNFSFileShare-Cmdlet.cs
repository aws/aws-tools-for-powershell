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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Updates a file share. This operation is only supported in the file gateway architecture.
    /// 
    ///  <note><para>
    /// To leave a file share field unchanged, set the corresponding input field to null.
    /// </para></note><para>
    /// Updates the following file share setting:
    /// </para><ul><li><para>
    /// Default storage class for your S3 bucket
    /// </para></li><li><para>
    /// Metadata defaults for your S3 bucket
    /// </para></li><li><para>
    /// Allowed NFS clients for your file share
    /// </para></li><li><para>
    /// Squash settings
    /// </para></li><li><para>
    /// Write status of your file share
    /// </para></li></ul><note><para>
    /// To leave a file share field unchanged, set the corresponding input field to null.
    /// This operation is only supported in file gateways.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SGNFSFileShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateNFSFileShare operation against AWS Storage Gateway.", Operation = new[] {"UpdateNFSFileShare"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.StorageGateway.Model.UpdateNFSFileShareResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSGNFSFileShareCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter ClientList
        /// <summary>
        /// <para>
        /// <para>The list of clients that are allowed to access the file gateway. The list must contain
        /// either valid IP addresses or valid CIDR blocks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ClientList { get; set; }
        #endregion
        
        #region Parameter DefaultStorageClass
        /// <summary>
        /// <para>
        /// <para>The default storage class for objects put into an Amazon S3 bucket by a file gateway.
        /// Possible values are S3_STANDARD or S3_STANDARD_IA. If this field is not populated,
        /// the default value S3_STANDARD is used. Optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DefaultStorageClass { get; set; }
        #endregion
        
        #region Parameter NFSFileShareDefaults_DirectoryMode
        /// <summary>
        /// <para>
        /// <para>The Unix directory mode in the form "nnnn". For example, "0666" represents the default
        /// access mode for all directories inside the file share. The default value is 0777.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NFSFileShareDefaults_DirectoryMode { get; set; }
        #endregion
        
        #region Parameter NFSFileShareDefaults_FileMode
        /// <summary>
        /// <para>
        /// <para>The Unix file mode in the form "nnnn". For example, "0666" represents the default
        /// file mode inside the file share. The default value is 0666. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NFSFileShareDefaults_FileMode { get; set; }
        #endregion
        
        #region Parameter FileShareARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the file share to be updated. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FileShareARN { get; set; }
        #endregion
        
        #region Parameter NFSFileShareDefaults_GroupId
        /// <summary>
        /// <para>
        /// <para>The default group ID for the file share (unless the files have another group ID specified).
        /// The default value is nfsnobody. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 NFSFileShareDefaults_GroupId { get; set; }
        #endregion
        
        #region Parameter KMSEncrypted
        /// <summary>
        /// <para>
        /// <para>True to use Amazon S3 server side encryption with your own AWS KMS key, or false to
        /// use a key managed by Amazon S3. Optional. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean KMSEncrypted { get; set; }
        #endregion
        
        #region Parameter KMSKey
        /// <summary>
        /// <para>
        /// <para>The KMS key used for Amazon S3 server side encryption. This value can only be set
        /// when KmsEncrypted is true. Optional. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KMSKey { get; set; }
        #endregion
        
        #region Parameter NFSFileShareDefaults_OwnerId
        /// <summary>
        /// <para>
        /// <para>The default owner ID for files in the file share (unless the files have another owner
        /// ID specified). The default value is nfsnobody. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 NFSFileShareDefaults_OwnerId { get; set; }
        #endregion
        
        #region Parameter ReadOnly
        /// <summary>
        /// <para>
        /// <para>Sets the write status of a file share: "true" if the write status is read-only, otherwise
        /// "false".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ReadOnly { get; set; }
        #endregion
        
        #region Parameter Squash
        /// <summary>
        /// <para>
        /// <para>The user mapped to anonymous user. Valid options are the following:</para><ul><li><para>"RootSquash" - Only root is mapped to anonymous user.</para></li><li><para>"NoSquash" - No one is mapped to anonymous user</para></li><li><para>"AllSquash" - Everyone is mapped to anonymous user.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Squash { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FileShareARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGNFSFileShare (UpdateNFSFileShare)"))
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
            
            if (this.ClientList != null)
            {
                context.ClientList = new List<System.String>(this.ClientList);
            }
            context.DefaultStorageClass = this.DefaultStorageClass;
            context.FileShareARN = this.FileShareARN;
            if (ParameterWasBound("KMSEncrypted"))
                context.KMSEncrypted = this.KMSEncrypted;
            context.KMSKey = this.KMSKey;
            context.NFSFileShareDefaults_DirectoryMode = this.NFSFileShareDefaults_DirectoryMode;
            context.NFSFileShareDefaults_FileMode = this.NFSFileShareDefaults_FileMode;
            if (ParameterWasBound("NFSFileShareDefaults_GroupId"))
                context.NFSFileShareDefaults_GroupId = this.NFSFileShareDefaults_GroupId;
            if (ParameterWasBound("NFSFileShareDefaults_OwnerId"))
                context.NFSFileShareDefaults_OwnerId = this.NFSFileShareDefaults_OwnerId;
            if (ParameterWasBound("ReadOnly"))
                context.ReadOnly = this.ReadOnly;
            context.Squash = this.Squash;
            
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
            var request = new Amazon.StorageGateway.Model.UpdateNFSFileShareRequest();
            
            if (cmdletContext.ClientList != null)
            {
                request.ClientList = cmdletContext.ClientList;
            }
            if (cmdletContext.DefaultStorageClass != null)
            {
                request.DefaultStorageClass = cmdletContext.DefaultStorageClass;
            }
            if (cmdletContext.FileShareARN != null)
            {
                request.FileShareARN = cmdletContext.FileShareARN;
            }
            if (cmdletContext.KMSEncrypted != null)
            {
                request.KMSEncrypted = cmdletContext.KMSEncrypted.Value;
            }
            if (cmdletContext.KMSKey != null)
            {
                request.KMSKey = cmdletContext.KMSKey;
            }
            
             // populate NFSFileShareDefaults
            bool requestNFSFileShareDefaultsIsNull = true;
            request.NFSFileShareDefaults = new Amazon.StorageGateway.Model.NFSFileShareDefaults();
            System.String requestNFSFileShareDefaults_nFSFileShareDefaults_DirectoryMode = null;
            if (cmdletContext.NFSFileShareDefaults_DirectoryMode != null)
            {
                requestNFSFileShareDefaults_nFSFileShareDefaults_DirectoryMode = cmdletContext.NFSFileShareDefaults_DirectoryMode;
            }
            if (requestNFSFileShareDefaults_nFSFileShareDefaults_DirectoryMode != null)
            {
                request.NFSFileShareDefaults.DirectoryMode = requestNFSFileShareDefaults_nFSFileShareDefaults_DirectoryMode;
                requestNFSFileShareDefaultsIsNull = false;
            }
            System.String requestNFSFileShareDefaults_nFSFileShareDefaults_FileMode = null;
            if (cmdletContext.NFSFileShareDefaults_FileMode != null)
            {
                requestNFSFileShareDefaults_nFSFileShareDefaults_FileMode = cmdletContext.NFSFileShareDefaults_FileMode;
            }
            if (requestNFSFileShareDefaults_nFSFileShareDefaults_FileMode != null)
            {
                request.NFSFileShareDefaults.FileMode = requestNFSFileShareDefaults_nFSFileShareDefaults_FileMode;
                requestNFSFileShareDefaultsIsNull = false;
            }
            System.Int64? requestNFSFileShareDefaults_nFSFileShareDefaults_GroupId = null;
            if (cmdletContext.NFSFileShareDefaults_GroupId != null)
            {
                requestNFSFileShareDefaults_nFSFileShareDefaults_GroupId = cmdletContext.NFSFileShareDefaults_GroupId.Value;
            }
            if (requestNFSFileShareDefaults_nFSFileShareDefaults_GroupId != null)
            {
                request.NFSFileShareDefaults.GroupId = requestNFSFileShareDefaults_nFSFileShareDefaults_GroupId.Value;
                requestNFSFileShareDefaultsIsNull = false;
            }
            System.Int64? requestNFSFileShareDefaults_nFSFileShareDefaults_OwnerId = null;
            if (cmdletContext.NFSFileShareDefaults_OwnerId != null)
            {
                requestNFSFileShareDefaults_nFSFileShareDefaults_OwnerId = cmdletContext.NFSFileShareDefaults_OwnerId.Value;
            }
            if (requestNFSFileShareDefaults_nFSFileShareDefaults_OwnerId != null)
            {
                request.NFSFileShareDefaults.OwnerId = requestNFSFileShareDefaults_nFSFileShareDefaults_OwnerId.Value;
                requestNFSFileShareDefaultsIsNull = false;
            }
             // determine if request.NFSFileShareDefaults should be set to null
            if (requestNFSFileShareDefaultsIsNull)
            {
                request.NFSFileShareDefaults = null;
            }
            if (cmdletContext.ReadOnly != null)
            {
                request.ReadOnly = cmdletContext.ReadOnly.Value;
            }
            if (cmdletContext.Squash != null)
            {
                request.Squash = cmdletContext.Squash;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FileShareARN;
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
        
        private Amazon.StorageGateway.Model.UpdateNFSFileShareResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.UpdateNFSFileShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "UpdateNFSFileShare");
            #if DESKTOP
            return client.UpdateNFSFileShare(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateNFSFileShareAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<System.String> ClientList { get; set; }
            public System.String DefaultStorageClass { get; set; }
            public System.String FileShareARN { get; set; }
            public System.Boolean? KMSEncrypted { get; set; }
            public System.String KMSKey { get; set; }
            public System.String NFSFileShareDefaults_DirectoryMode { get; set; }
            public System.String NFSFileShareDefaults_FileMode { get; set; }
            public System.Int64? NFSFileShareDefaults_GroupId { get; set; }
            public System.Int64? NFSFileShareDefaults_OwnerId { get; set; }
            public System.Boolean? ReadOnly { get; set; }
            public System.String Squash { get; set; }
        }
        
    }
}
