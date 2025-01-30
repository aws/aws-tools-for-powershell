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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Provides the functionality to export the serverless cache snapshot data to Amazon
    /// S3. Available for Valkey and Redis OSS only.
    /// </summary>
    [Cmdlet("Export", "ECServerlessCacheSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ServerlessCacheSnapshot")]
    [AWSCmdlet("Calls the Amazon ElastiCache ExportServerlessCacheSnapshot API operation.", Operation = new[] {"ExportServerlessCacheSnapshot"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.ExportServerlessCacheSnapshotResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ServerlessCacheSnapshot or Amazon.ElastiCache.Model.ExportServerlessCacheSnapshotResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ServerlessCacheSnapshot object.",
        "The service call response (type Amazon.ElastiCache.Model.ExportServerlessCacheSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ExportECServerlessCacheSnapshotCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3BucketName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon S3 bucket to export the snapshot to. The Amazon S3 bucket must
        /// also be in same region as the snapshot. Available for Valkey and Redis OSS only.</para>
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
        public System.String S3BucketName { get; set; }
        #endregion
        
        #region Parameter ServerlessCacheSnapshotName
        /// <summary>
        /// <para>
        /// <para>The identifier of the serverless cache snapshot to be exported to S3. Available for
        /// Valkey and Redis OSS only.</para>
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
        public System.String ServerlessCacheSnapshotName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerlessCacheSnapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.ExportServerlessCacheSnapshotResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.ExportServerlessCacheSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerlessCacheSnapshot";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServerlessCacheSnapshotName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServerlessCacheSnapshotName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServerlessCacheSnapshotName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerlessCacheSnapshotName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-ECServerlessCacheSnapshot (ExportServerlessCacheSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.ExportServerlessCacheSnapshotResponse, ExportECServerlessCacheSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServerlessCacheSnapshotName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3BucketName = this.S3BucketName;
            #if MODULAR
            if (this.S3BucketName == null && ParameterWasBound(nameof(this.S3BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerlessCacheSnapshotName = this.ServerlessCacheSnapshotName;
            #if MODULAR
            if (this.ServerlessCacheSnapshotName == null && ParameterWasBound(nameof(this.ServerlessCacheSnapshotName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerlessCacheSnapshotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElastiCache.Model.ExportServerlessCacheSnapshotRequest();
            
            if (cmdletContext.S3BucketName != null)
            {
                request.S3BucketName = cmdletContext.S3BucketName;
            }
            if (cmdletContext.ServerlessCacheSnapshotName != null)
            {
                request.ServerlessCacheSnapshotName = cmdletContext.ServerlessCacheSnapshotName;
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
        
        private Amazon.ElastiCache.Model.ExportServerlessCacheSnapshotResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ExportServerlessCacheSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ExportServerlessCacheSnapshot");
            try
            {
                #if DESKTOP
                return client.ExportServerlessCacheSnapshot(request);
                #elif CORECLR
                return client.ExportServerlessCacheSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String S3BucketName { get; set; }
            public System.String ServerlessCacheSnapshotName { get; set; }
            public System.Func<Amazon.ElastiCache.Model.ExportServerlessCacheSnapshotResponse, ExportECServerlessCacheSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerlessCacheSnapshot;
        }
        
    }
}
