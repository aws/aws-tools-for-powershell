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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Makes a copy of an existing snapshot.
    /// </summary>
    [Cmdlet("Copy", "MDBSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MemoryDB.Model.Snapshot")]
    [AWSCmdlet("Calls the Amazon MemoryDB CopySnapshot API operation.", Operation = new[] {"CopySnapshot"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.CopySnapshotResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.Snapshot or Amazon.MemoryDB.Model.CopySnapshotResponse",
        "This cmdlet returns an Amazon.MemoryDB.Model.Snapshot object.",
        "The service call response (type Amazon.MemoryDB.Model.CopySnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyMDBSnapshotCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the KMS key used to encrypt the target snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SourceSnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of an existing snapshot from which to make a copy.</para>
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
        public System.String SourceSnapshotName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to be added to this resource. A tag is a key-value pair. A tag key
        /// must be accompanied by a tag value, although null is accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.MemoryDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetBucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket to which the snapshot is exported. This parameter is used only
        /// when exporting a snapshot for external access. When using this parameter to export
        /// a snapshot, be sure MemoryDB has the needed permissions to this S3 bucket. For more
        /// information, see <a href="https://docs.aws.amazon.com/MemoryDB/latest/devguide/snapshots-exporting.html">Step
        /// 2: Grant MemoryDB Access to Your Amazon S3 Bucket</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetBucket { get; set; }
        #endregion
        
        #region Parameter TargetSnapshotName
        /// <summary>
        /// <para>
        /// <para>A name for the snapshot copy. MemoryDB does not permit overwriting a snapshot, therefore
        /// this name must be unique within its context - MemoryDB or an Amazon S3 bucket if exporting.</para>
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
        public System.String TargetSnapshotName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Snapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.CopySnapshotResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.CopySnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Snapshot";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetSnapshotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-MDBSnapshot (CopySnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.CopySnapshotResponse, CopyMDBSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KmsKeyId = this.KmsKeyId;
            context.SourceSnapshotName = this.SourceSnapshotName;
            #if MODULAR
            if (this.SourceSnapshotName == null && ParameterWasBound(nameof(this.SourceSnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceSnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.MemoryDB.Model.Tag>(this.Tag);
            }
            context.TargetBucket = this.TargetBucket;
            context.TargetSnapshotName = this.TargetSnapshotName;
            #if MODULAR
            if (this.TargetSnapshotName == null && ParameterWasBound(nameof(this.TargetSnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetSnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MemoryDB.Model.CopySnapshotRequest();
            
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.SourceSnapshotName != null)
            {
                request.SourceSnapshotName = cmdletContext.SourceSnapshotName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetBucket != null)
            {
                request.TargetBucket = cmdletContext.TargetBucket;
            }
            if (cmdletContext.TargetSnapshotName != null)
            {
                request.TargetSnapshotName = cmdletContext.TargetSnapshotName;
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
        
        private Amazon.MemoryDB.Model.CopySnapshotResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.CopySnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "CopySnapshot");
            try
            {
                return client.CopySnapshotAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KmsKeyId { get; set; }
            public System.String SourceSnapshotName { get; set; }
            public List<Amazon.MemoryDB.Model.Tag> Tag { get; set; }
            public System.String TargetBucket { get; set; }
            public System.String TargetSnapshotName { get; set; }
            public System.Func<Amazon.MemoryDB.Model.CopySnapshotResponse, CopyMDBSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshot;
        }
        
    }
}
