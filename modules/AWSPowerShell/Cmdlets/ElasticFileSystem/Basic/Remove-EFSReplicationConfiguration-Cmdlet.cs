/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Deletes a replication configuration. Deleting a replication configuration ends the
    /// replication process. After a replication configuration is deleted, the destination
    /// file system becomes <c>Writeable</c> and its replication overwrite protection is re-enabled.
    /// For more information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/delete-replications.html">Delete
    /// a replication configuration</a>.
    /// 
    ///  
    /// <para>
    /// This operation requires permissions for the <c>elasticfilesystem:DeleteReplicationConfiguration</c>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "EFSReplicationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic File System DeleteReplicationConfiguration API operation.", Operation = new[] {"DeleteReplicationConfiguration"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.DeleteReplicationConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticFileSystem.Model.DeleteReplicationConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticFileSystem.Model.DeleteReplicationConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveEFSReplicationConfigurationCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeletionMode
        /// <summary>
        /// <para>
        /// <para>When replicating across Amazon Web Services accounts or across Amazon Web Services
        /// Regions, Amazon EFS deletes the replication configuration from both the source and
        /// destination account or Region (<c>ALL_CONFIGURATIONS</c>) by default. If there's a
        /// configuration or permissions issue that prevents Amazon EFS from deleting the replication
        /// configuration from both sides, you can use the <c>LOCAL_CONFIGURATION_ONLY</c> mode
        /// to delete the replication configuration from only the local side (the account or Region
        /// from which the delete is performed). </para><note><para>Only use the <c>LOCAL_CONFIGURATION_ONLY</c> mode in the case that Amazon EFS is unable
        /// to delete the replication configuration in both the source and destination account
        /// or Region. Deleting the local configuration leaves the configuration in the other
        /// account or Region unrecoverable.</para><para>Additionally, do not use this mode for same-account, same-region replication as doing
        /// so results in a BadRequest exception error.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticFileSystem.DeletionMode")]
        public Amazon.ElasticFileSystem.DeletionMode DeletionMode { get; set; }
        #endregion
        
        #region Parameter SourceFileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the source file system in the replication configuration.</para>
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
        public System.String SourceFileSystemId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.DeleteReplicationConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceFileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EFSReplicationConfiguration (DeleteReplicationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.DeleteReplicationConfigurationResponse, RemoveEFSReplicationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeletionMode = this.DeletionMode;
            context.SourceFileSystemId = this.SourceFileSystemId;
            #if MODULAR
            if (this.SourceFileSystemId == null && ParameterWasBound(nameof(this.SourceFileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceFileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ElasticFileSystem.Model.DeleteReplicationConfigurationRequest();
            
            if (cmdletContext.DeletionMode != null)
            {
                request.DeletionMode = cmdletContext.DeletionMode;
            }
            if (cmdletContext.SourceFileSystemId != null)
            {
                request.SourceFileSystemId = cmdletContext.SourceFileSystemId;
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
        
        private Amazon.ElasticFileSystem.Model.DeleteReplicationConfigurationResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.DeleteReplicationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "DeleteReplicationConfiguration");
            try
            {
                return client.DeleteReplicationConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ElasticFileSystem.DeletionMode DeletionMode { get; set; }
            public System.String SourceFileSystemId { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.DeleteReplicationConfigurationResponse, RemoveEFSReplicationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
