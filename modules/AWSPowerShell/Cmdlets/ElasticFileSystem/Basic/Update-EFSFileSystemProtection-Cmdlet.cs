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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Updates protection on the file system.
    /// 
    ///  
    /// <para>
    /// This operation requires permissions for the <c>elasticfilesystem:UpdateFileSystemProtection</c>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EFSFileSystemProtection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.ReplicationOverwriteProtection")]
    [AWSCmdlet("Calls the Amazon Elastic File System UpdateFileSystemProtection API operation.", Operation = new[] {"UpdateFileSystemProtection"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.UpdateFileSystemProtectionResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.ReplicationOverwriteProtection or Amazon.ElasticFileSystem.Model.UpdateFileSystemProtectionResponse",
        "This cmdlet returns an Amazon.ElasticFileSystem.ReplicationOverwriteProtection object.",
        "The service call response (type Amazon.ElasticFileSystem.Model.UpdateFileSystemProtectionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEFSFileSystemProtectionCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the file system to update. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter ReplicationOverwriteProtection
        /// <summary>
        /// <para>
        /// <para>The status of the file system's replication overwrite protection.</para><ul><li><para><c>ENABLED</c> – The file system cannot be used as the destination file system in
        /// a replication configuration. The file system is writeable. Replication overwrite protection
        /// is <c>ENABLED</c> by default. </para></li><li><para><c>DISABLED</c> – The file system can be used as the destination file system in a
        /// replication configuration. The file system is read-only and can only be modified by
        /// EFS replication.</para></li><li><para><c>REPLICATING</c> – The file system is being used as the destination file system
        /// in a replication configuration. The file system is read-only and is only modified
        /// only by EFS replication.</para></li></ul><para>If the replication configuration is deleted, the file system's replication overwrite
        /// protection is re-enabled, the file system becomes writeable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticFileSystem.ReplicationOverwriteProtection")]
        public Amazon.ElasticFileSystem.ReplicationOverwriteProtection ReplicationOverwriteProtection { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationOverwriteProtection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.UpdateFileSystemProtectionResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.UpdateFileSystemProtectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationOverwriteProtection";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EFSFileSystemProtection (UpdateFileSystemProtection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.UpdateFileSystemProtectionResponse, UpdateEFSFileSystemProtectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationOverwriteProtection = this.ReplicationOverwriteProtection;
            
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
            var request = new Amazon.ElasticFileSystem.Model.UpdateFileSystemProtectionRequest();
            
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.ReplicationOverwriteProtection != null)
            {
                request.ReplicationOverwriteProtection = cmdletContext.ReplicationOverwriteProtection;
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
        
        private Amazon.ElasticFileSystem.Model.UpdateFileSystemProtectionResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.UpdateFileSystemProtectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "UpdateFileSystemProtection");
            try
            {
                #if DESKTOP
                return client.UpdateFileSystemProtection(request);
                #elif CORECLR
                return client.UpdateFileSystemProtectionAsync(request).GetAwaiter().GetResult();
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
            public System.String FileSystemId { get; set; }
            public Amazon.ElasticFileSystem.ReplicationOverwriteProtection ReplicationOverwriteProtection { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.UpdateFileSystemProtectionResponse, UpdateEFSFileSystemProtectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationOverwriteProtection;
        }
        
    }
}
