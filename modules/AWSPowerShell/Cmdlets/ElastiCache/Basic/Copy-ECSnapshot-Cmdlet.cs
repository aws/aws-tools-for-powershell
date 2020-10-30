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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Amazon.ElastiCache.IAmazonElastiCache.CopySnapshot
    /// </summary>
    [Cmdlet("Copy", "ECSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.Snapshot")]
    [AWSCmdlet("Calls the Amazon ElastiCache CopySnapshot API operation.", Operation = new[] {"CopySnapshot"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.CopySnapshotResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.Snapshot or Amazon.ElastiCache.Model.CopySnapshotResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.Snapshot object.",
        "The service call response (type Amazon.ElastiCache.Model.CopySnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyECSnapshotCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SourceSnapshotName { get; set; }
        #endregion
        
        #region Parameter TargetBucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket to which the snapshot is exported. This parameter is used only
        /// when exporting a snapshot for external access.</para><para>When using this parameter to export a snapshot, be sure Amazon ElastiCache has the
        /// needed permissions to this S3 bucket. For more information, see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/backups-exporting.html#backups-exporting-grant-access">Step
        /// 2: Grant ElastiCache Access to Your Amazon S3 Bucket</a> in the <i>Amazon ElastiCache
        /// User Guide</i>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/Snapshots.Exporting.html">Exporting
        /// a Snapshot</a> in the <i>Amazon ElastiCache User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetBucket { get; set; }
        #endregion
        
        #region Parameter TargetSnapshotName
        /// <summary>
        /// <para>
        /// <para>A name for the snapshot copy. ElastiCache does not permit overwriting a snapshot,
        /// therefore this name must be unique within its context - ElastiCache or an Amazon S3
        /// bucket if exporting.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TargetSnapshotName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Snapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.CopySnapshotResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.CopySnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Snapshot";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceSnapshotName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceSnapshotName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceSnapshotName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceSnapshotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-ECSnapshot (CopySnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.CopySnapshotResponse, CopyECSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceSnapshotName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.KmsKeyId = this.KmsKeyId;
            context.SourceSnapshotName = this.SourceSnapshotName;
            #if MODULAR
            if (this.SourceSnapshotName == null && ParameterWasBound(nameof(this.SourceSnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceSnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.ElastiCache.Model.CopySnapshotRequest();
            
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.SourceSnapshotName != null)
            {
                request.SourceSnapshotName = cmdletContext.SourceSnapshotName;
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
        
        private Amazon.ElastiCache.Model.CopySnapshotResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.CopySnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "CopySnapshot");
            try
            {
                #if DESKTOP
                return client.CopySnapshot(request);
                #elif CORECLR
                return client.CopySnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String KmsKeyId { get; set; }
            public System.String SourceSnapshotName { get; set; }
            public System.String TargetBucket { get; set; }
            public System.String TargetSnapshotName { get; set; }
            public System.Func<Amazon.ElastiCache.Model.CopySnapshotResponse, CopyECSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshot;
        }
        
    }
}
