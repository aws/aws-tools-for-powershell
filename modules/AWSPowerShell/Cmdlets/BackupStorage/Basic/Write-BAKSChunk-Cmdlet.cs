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
using Amazon.BackupStorage;
using Amazon.BackupStorage.Model;

namespace Amazon.PowerShell.Cmdlets.BAKS
{
    /// <summary>
    /// Upload chunk.
    /// </summary>
    [Cmdlet("Write", "BAKSChunk", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BackupStorage.Model.PutChunkResponse")]
    [AWSCmdlet("Calls the AWS Backup Storage PutChunk API operation.", Operation = new[] {"PutChunk"}, SelectReturnType = typeof(Amazon.BackupStorage.Model.PutChunkResponse))]
    [AWSCmdletOutput("Amazon.BackupStorage.Model.PutChunkResponse",
        "This cmdlet returns an Amazon.BackupStorage.Model.PutChunkResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteBAKSChunkCmdlet : AmazonBackupStorageClientCmdlet, IExecutor
    {
        
        #region Parameter BackupJobId
        /// <summary>
        /// <para>
        /// Backup job Id for the in-progress backup.
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
        public System.String BackupJobId { get; set; }
        #endregion
        
        #region Parameter Checksum
        /// <summary>
        /// <para>
        /// Data checksum
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
        public System.String Checksum { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// Checksum algorithm
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BackupStorage.DataChecksumAlgorithm")]
        public Amazon.BackupStorage.DataChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ChunkIndex
        /// <summary>
        /// <para>
        /// Describes this chunk's position relative to
        /// the other chunks
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? ChunkIndex { get; set; }
        #endregion
        
        #region Parameter Data
        /// <summary>
        /// <para>
        /// Data to be uploaded
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public object Data { get; set; }
        #endregion
        
        #region Parameter Length
        /// <summary>
        /// <para>
        /// Data length
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? Length { get; set; }
        #endregion
        
        #region Parameter UploadId
        /// <summary>
        /// <para>
        /// Upload Id for the in-progress upload.
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
        public System.String UploadId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BackupStorage.Model.PutChunkResponse).
        /// Specifying the name of a property of type Amazon.BackupStorage.Model.PutChunkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Data parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Data' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Data' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UploadId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BAKSChunk (PutChunk)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BackupStorage.Model.PutChunkResponse, WriteBAKSChunkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Data;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupJobId = this.BackupJobId;
            #if MODULAR
            if (this.BackupJobId == null && ParameterWasBound(nameof(this.BackupJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Checksum = this.Checksum;
            #if MODULAR
            if (this.Checksum == null && ParameterWasBound(nameof(this.Checksum)))
            {
                WriteWarning("You are passing $null as a value for parameter Checksum which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            #if MODULAR
            if (this.ChecksumAlgorithm == null && ParameterWasBound(nameof(this.ChecksumAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter ChecksumAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChunkIndex = this.ChunkIndex;
            #if MODULAR
            if (this.ChunkIndex == null && ParameterWasBound(nameof(this.ChunkIndex)))
            {
                WriteWarning("You are passing $null as a value for parameter ChunkIndex which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Data = this.Data;
            #if MODULAR
            if (this.Data == null && ParameterWasBound(nameof(this.Data)))
            {
                WriteWarning("You are passing $null as a value for parameter Data which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Length = this.Length;
            #if MODULAR
            if (this.Length == null && ParameterWasBound(nameof(this.Length)))
            {
                WriteWarning("You are passing $null as a value for parameter Length which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UploadId = this.UploadId;
            #if MODULAR
            if (this.UploadId == null && ParameterWasBound(nameof(this.UploadId)))
            {
                WriteWarning("You are passing $null as a value for parameter UploadId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.Stream _DataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.BackupStorage.Model.PutChunkRequest();
                
                if (cmdletContext.BackupJobId != null)
                {
                    request.BackupJobId = cmdletContext.BackupJobId;
                }
                if (cmdletContext.Checksum != null)
                {
                    request.Checksum = cmdletContext.Checksum;
                }
                if (cmdletContext.ChecksumAlgorithm != null)
                {
                    request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
                }
                if (cmdletContext.ChunkIndex != null)
                {
                    request.ChunkIndex = cmdletContext.ChunkIndex.Value;
                }
                if (cmdletContext.Data != null)
                {
                    _DataStream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.Data);
                    request.Data = _DataStream;
                }
                if (cmdletContext.Length != null)
                {
                    request.Length = cmdletContext.Length.Value;
                }
                if (cmdletContext.UploadId != null)
                {
                    request.UploadId = cmdletContext.UploadId;
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
            finally
            {
                if( _DataStream != null)
                {
                    _DataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.BackupStorage.Model.PutChunkResponse CallAWSServiceOperation(IAmazonBackupStorage client, Amazon.BackupStorage.Model.PutChunkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup Storage", "PutChunk");
            try
            {
                #if DESKTOP
                return client.PutChunk(request);
                #elif CORECLR
                return client.PutChunkAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupJobId { get; set; }
            public System.String Checksum { get; set; }
            public Amazon.BackupStorage.DataChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.Int64? ChunkIndex { get; set; }
            public object Data { get; set; }
            public System.Int64? Length { get; set; }
            public System.String UploadId { get; set; }
            public System.Func<Amazon.BackupStorage.Model.PutChunkResponse, WriteBAKSChunkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
