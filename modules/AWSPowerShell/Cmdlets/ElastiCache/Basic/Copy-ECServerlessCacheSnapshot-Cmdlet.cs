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
    /// Creates a copy of an existing serverless cache’s snapshot. Available for Redis OSS
    /// and Serverless Memcached only.
    /// </summary>
    [Cmdlet("Copy", "ECServerlessCacheSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ServerlessCacheSnapshot")]
    [AWSCmdlet("Calls the Amazon ElastiCache CopyServerlessCacheSnapshot API operation.", Operation = new[] {"CopyServerlessCacheSnapshot"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.CopyServerlessCacheSnapshotResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ServerlessCacheSnapshot or Amazon.ElastiCache.Model.CopyServerlessCacheSnapshotResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ServerlessCacheSnapshot object.",
        "The service call response (type Amazon.ElastiCache.Model.CopyServerlessCacheSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyECServerlessCacheSnapshotCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS key used to encrypt the target snapshot. Available for Redis
        /// OSS and Serverless Memcached only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter SourceServerlessCacheSnapshotName
        /// <summary>
        /// <para>
        /// <para>The identifier of the existing serverless cache’s snapshot to be copied. Available
        /// for Redis OSS and Serverless Memcached only.</para>
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
        public System.String SourceServerlessCacheSnapshotName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to be added to the target snapshot resource. A tag is a key-value pair.
        /// Available for Redis OSS and Serverless Memcached only. Default: NULL</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElastiCache.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetServerlessCacheSnapshotName
        /// <summary>
        /// <para>
        /// <para>The identifier for the snapshot to be created. Available for Redis OSS and Serverless
        /// Memcached only.</para>
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
        public System.String TargetServerlessCacheSnapshotName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerlessCacheSnapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.CopyServerlessCacheSnapshotResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.CopyServerlessCacheSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerlessCacheSnapshot";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceServerlessCacheSnapshotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-ECServerlessCacheSnapshot (CopyServerlessCacheSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.CopyServerlessCacheSnapshotResponse, CopyECServerlessCacheSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KmsKeyId = this.KmsKeyId;
            context.SourceServerlessCacheSnapshotName = this.SourceServerlessCacheSnapshotName;
            #if MODULAR
            if (this.SourceServerlessCacheSnapshotName == null && ParameterWasBound(nameof(this.SourceServerlessCacheSnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceServerlessCacheSnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElastiCache.Model.Tag>(this.Tag);
            }
            context.TargetServerlessCacheSnapshotName = this.TargetServerlessCacheSnapshotName;
            #if MODULAR
            if (this.TargetServerlessCacheSnapshotName == null && ParameterWasBound(nameof(this.TargetServerlessCacheSnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetServerlessCacheSnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElastiCache.Model.CopyServerlessCacheSnapshotRequest();
            
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.SourceServerlessCacheSnapshotName != null)
            {
                request.SourceServerlessCacheSnapshotName = cmdletContext.SourceServerlessCacheSnapshotName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetServerlessCacheSnapshotName != null)
            {
                request.TargetServerlessCacheSnapshotName = cmdletContext.TargetServerlessCacheSnapshotName;
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
        
        private Amazon.ElastiCache.Model.CopyServerlessCacheSnapshotResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.CopyServerlessCacheSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "CopyServerlessCacheSnapshot");
            try
            {
                #if DESKTOP
                return client.CopyServerlessCacheSnapshot(request);
                #elif CORECLR
                return client.CopyServerlessCacheSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String SourceServerlessCacheSnapshotName { get; set; }
            public List<Amazon.ElastiCache.Model.Tag> Tag { get; set; }
            public System.String TargetServerlessCacheSnapshotName { get; set; }
            public System.Func<Amazon.ElastiCache.Model.CopyServerlessCacheSnapshotResponse, CopyECServerlessCacheSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerlessCacheSnapshot;
        }
        
    }
}
